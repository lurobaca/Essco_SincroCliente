using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Claims;
using Essco.Application.Auditing;
using Essco.Application.Configuration;
using Essco.Application.Security;
using Essco.Application.Treasury;
using Essco.Domain.Treasury;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essco.Web.Pages.Treasury;

[Authorize(Policy = Permissions.Cash)]
public sealed class DepositsModel(DepositService service, DepositSapDispatchService sapDispatch, AuditService audit, IOptions<EsscoOptions> options) : PageModel
{
    [BindProperty] public InputModel Input { get; set; } = new();
    [BindProperty(SupportsGet = true)] public FilterModel Filter { get; set; } = new();
    public IReadOnlyCollection<Deposit> Items { get; private set; } = [];
    public IReadOnlyCollection<string> Banks { get; private set; } = [];
    [TempData] public string? StatusMessage { get; set; }
    public static IReadOnlyCollection<string> Types { get; } = ["AGENTES", "CHOFERES"];

    public async Task OnGetAsync(int? consecutive, CancellationToken token)
    {
        await LoadAsync(token);
        if (consecutive is not null)
        {
            var selected = await service.ListAsync(new DepositFilter(Consecutive: consecutive, IncludeAnnulled: true), token);
            var item = selected.SingleOrDefault();
            if (item is not null) Input = InputModel.From(item);
        }
    }

    public async Task<IActionResult> OnPostSaveAsync(CancellationToken token)
    {
        if (ModelState.IsValid)
        {
            var result = await service.SaveAsync(Input.ToDomain(), Input.IsNew, token);
            if (result.Succeeded)
            {
                await LogAsync("treasury.deposit-save", result.Consecutive, "Succeeded", token);
                StatusMessage = $"Depósito {result.Consecutive} guardado.";
                return RedirectToPage(Filter.RouteValues());
            }
            ModelState.AddModelError(string.Empty, result.Error ?? "No fue posible guardar el depósito.");
        }
        await LoadAsync(token);
        return Page();
    }

    public async Task<IActionResult> OnPostAnnulAsync(int consecutive, CancellationToken token)
    {
        var changed = await service.AnnulAsync(consecutive, token);
        await LogAsync("treasury.deposit-annul", consecutive, changed ? "Succeeded" : "Rejected", token);
        StatusMessage = changed ? $"Depósito {consecutive} anulado." : "El depósito no existe o ya estaba anulado.";
        return RedirectToPage(Filter.RouteValues());
    }

    public async Task<IActionResult> OnPostUploadAsync(int consecutive, CancellationToken token)
    {
        var result = await sapDispatch.DispatchAsync(consecutive, options.Value.DefaultCompany, User.Identity?.Name ?? "", token);
        await LogAsync("treasury.deposit-upload", consecutive, result.Succeeded ? "Queued" : "Rejected", token);
        StatusMessage = result.Succeeded ? $"Depósito encolado para SAP. Trabajo: {result.Job!.Id}" : result.Error;
        return RedirectToPage(Filter.RouteValues());
    }

    private async Task LoadAsync(CancellationToken token)
    {
        Banks = await service.ListBanksAsync(token);
        Items = await service.ListAsync(Filter.ToDomain(), token);
    }

    private async Task LogAsync(string operation, int consecutive, string result, CancellationToken token)
    {
        var userId = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), NumberStyles.None, CultureInfo.InvariantCulture, out var parsed) ? parsed : (int?)null;
        await audit.WriteAsync(userId, User.Identity?.Name ?? "", options.Value.DefaultCompany, operation, "Depositos", consecutive.ToString(CultureInfo.InvariantCulture), result, HttpContext.TraceIdentifier, HttpContext.Connection.RemoteIpAddress?.ToString(), token);
    }

    public sealed class FilterModel
    {
        [DataType(DataType.Date), Display(Name = "Desde")] public DateOnly? From { get; set; }
        [DataType(DataType.Date), Display(Name = "Hasta")] public DateOnly? To { get; set; }
        [Display(Name = "Empleado")] public string? Employee { get; set; }
        [Display(Name = "Número")] public string? Number { get; set; }
        [Display(Name = "Consecutivo")] public int? Consecutive { get; set; }
        [Display(Name = "Tipo")] public string? Type { get; set; }
        [Display(Name = "Subido")] public bool? Uploaded { get; set; }
        [Display(Name = "Incluir anulados")] public bool IncludeAnnulled { get; set; }
        public DepositFilter ToDomain() => new(From, To, Employee, Number, Consecutive, Uploaded, Type, IncludeAnnulled);
        public IReadOnlyDictionary<string, object?> RouteValues() => new Dictionary<string, object?>
        {
            ["Filter.From"] = From,
            ["Filter.To"] = To,
            ["Filter.Employee"] = Employee,
            ["Filter.Number"] = Number,
            ["Filter.Consecutive"] = Consecutive,
            ["Filter.Type"] = Type,
            ["Filter.Uploaded"] = Uploaded,
            ["Filter.IncludeAnnulled"] = IncludeAnnulled
        };
    }

    public sealed class InputModel
    {
        public bool IsNew { get; set; } = true;
        public int Consecutive { get; set; }
        [Required, StringLength(100), Display(Name = "Número de depósito")] public string Number { get; set; } = "";
        [DataType(DataType.Date), Display(Name = "Fecha")] public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Today);
        [Required, StringLength(200), Display(Name = "Banco")] public string Bank { get; set; } = "";
        [Range(typeof(decimal), "0.0001", "999999999999999"), Display(Name = "Monto")] public decimal Amount { get; set; }
        [Required, StringLength(50), Display(Name = "Código agente/chofer")] public string EmployeeCode { get; set; } = "";
        [StringLength(1000), Display(Name = "Comentario")] public string Notes { get; set; } = "";
        [StringLength(50), Display(Name = "Liquidación")] public string LiquidationNumber { get; set; } = "";
        [Required, Display(Name = "Tipo")] public string LiquidationType { get; set; } = "AGENTES";
        [DataType(DataType.Date), Display(Name = "Fecha contable")] public DateOnly AccountingDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
        [Display(Name = "Subido")] public bool IsUploaded { get; set; }
        public Deposit ToDomain() => new() { Consecutive = Consecutive, Number = Number, Date = Date, Bank = Bank, Amount = Amount, EmployeeCode = EmployeeCode, Notes = Notes, LiquidationNumber = LiquidationNumber, LiquidationType = LiquidationType, AccountingDate = AccountingDate, IsUploaded = IsUploaded };
        public static InputModel From(Deposit item) => new() { IsNew = false, Consecutive = item.Consecutive, Number = item.Number, Date = item.Date, Bank = item.Bank, Amount = item.Amount, EmployeeCode = item.EmployeeCode, Notes = item.Notes, LiquidationNumber = item.LiquidationNumber, LiquidationType = item.LiquidationType, AccountingDate = item.AccountingDate, IsUploaded = item.IsUploaded };
    }
}
