using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Claims;
using Essco.Application.Auditing;
using Essco.Application.Catalogs;
using Essco.Application.Configuration;
using Essco.Application.Security;
using Essco.Domain.Catalogs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essco.Web.Pages.Catalogs;

[Authorize(Policy = Permissions.Catalogs)]
public sealed class WarehouseOperatorsModel(WarehouseOperatorService service, AuditService audit, IOptions<EsscoOptions> options) : PageModel
{
    [BindProperty] public InputModel Input { get; set; } = new();
    public IReadOnlyCollection<WarehouseOperator> Items { get; private set; } = [];
    [TempData] public string? StatusMessage { get; set; }

    public async Task OnGetAsync(string? code, CancellationToken token)
    {
        Items = await service.ListAsync(token);
        var item = string.IsNullOrWhiteSpace(code) ? null : Items.FirstOrDefault(x => string.Equals(x.Code, code, StringComparison.OrdinalIgnoreCase));
        if (item is not null) Input = InputModel.From(item);
    }

    public async Task<IActionResult> OnPostSaveAsync(CancellationToken token)
    {
        if (ModelState.IsValid)
        {
            var result = await service.SaveAsync(Input.ToDomain(), Input.IsNew, Input.NewPassword, token);
            if (result.Succeeded)
            {
                await LogAsync("catalog.warehouse-operator-save", Input.Code, "Succeeded", token);
                StatusMessage = "Bodeguero guardado.";
                return RedirectToPage();
            }
            foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error);
        }
        Items = await service.ListAsync(token);
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(string code, CancellationToken token)
    {
        var changed = !string.IsNullOrWhiteSpace(code) && await service.DeleteAsync(code, token);
        await LogAsync("catalog.warehouse-operator-delete", code, changed ? "Succeeded" : "NotChanged", token);
        StatusMessage = changed ? "Bodeguero eliminado." : "El bodeguero ya no existía.";
        return RedirectToPage();
    }

    private async Task LogAsync(string operation, string code, string result, CancellationToken token)
    {
        var userId = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), NumberStyles.None, CultureInfo.InvariantCulture, out var parsed) ? parsed : (int?)null;
        await audit.WriteAsync(userId, User.Identity?.Name ?? "", options.Value.DefaultCompany, operation, "Bodegueros", code, result, HttpContext.TraceIdentifier, HttpContext.Connection.RemoteIpAddress?.ToString(), token);
    }

    public sealed class InputModel
    {
        public bool IsNew { get; set; } = true;
        [Required, StringLength(50), Display(Name = "Código")] public string Code { get; set; } = "";
        [Required, StringLength(200), Display(Name = "Nombre")] public string Name { get; set; } = "";
        [StringLength(50), Display(Name = "Teléfono")] public string Phone { get; set; } = "";
        [StringLength(50), Display(Name = "Consecutivo carga")] public string LoadSequence { get; set; } = "";
        [StringLength(50), Display(Name = "Consecutivo devoluciones")] public string ReturnSequence { get; set; } = "";
        [StringLength(254), EmailAddress, Display(Name = "Correo")] public string Email { get; set; } = "";
        [StringLength(500), Display(Name = "Ruta FTP")] public string FtpPath { get; set; } = "";
        [Required, StringLength(100), Display(Name = "Puesto")] public string Position { get; set; } = "";
        [StringLength(50), Display(Name = "Cédula")] public string Identification { get; set; } = "";
        [Required, StringLength(100), Display(Name = "Usuario móvil")] public string Username { get; set; } = "";
        [StringLength(200), DataType(DataType.Password), Display(Name = "Nueva clave móvil")] public string? NewPassword { get; set; }
        public List<int> Sectors { get; set; } = [];

        public WarehouseOperator ToDomain() => new() { Code = Code, Name = Name, Phone = Phone, LoadSequence = LoadSequence, ReturnSequence = ReturnSequence, Email = Email, FtpPath = FtpPath, Position = Position, Identification = Identification, Username = Username, Sectors = Sectors };
        public static InputModel From(WarehouseOperator item) => new() { IsNew = false, Code = item.Code, Name = item.Name, Phone = item.Phone, LoadSequence = item.LoadSequence, ReturnSequence = item.ReturnSequence, Email = item.Email, FtpPath = item.FtpPath, Position = item.Position, Identification = item.Identification, Username = item.Username, Sectors = item.Sectors.ToList() };
    }
}
