using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Claims;
using Essco.Application.Auditing;
using Essco.Application.Companies;
using Essco.Application.Configuration;
using Essco.Application.Customers;
using Essco.Application.Security;
using Essco.Domain.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace Essco.Web.Pages.Customers;

[Authorize(Policy = Permissions.Customers)]
public sealed class EditModel(CustomerChangeService service, IGeographyRepository geography,
    AuditService audit, IOptions<EsscoOptions> options) : PageModel
{
    [BindProperty] public InputModel Input { get; set; } = new();
    public IReadOnlyCollection<SelectListItem> Provinces { get; private set; } = [];
    public IReadOnlyCollection<SelectListItem> Cantons { get; private set; } = [];
    public IReadOnlyCollection<SelectListItem> Districts { get; private set; } = [];
    public IReadOnlyCollection<SelectListItem> Neighborhoods { get; private set; } = [];

    public async Task<IActionResult> OnGetAsync(long? id, CancellationToken token)
    {
        if (id is not null)
        {
            var existing = await service.GetAsync(id.Value, token);
            if (existing is null) return NotFound();
            Input = InputModel.From(existing);
        }
        await LoadLocationsAsync(token);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken token)
    {
        var existing = Input.Id == 0 ? null : await service.GetAsync(Input.Id, token);
        if (Input.Id != 0 && existing is null) return NotFound();
        if (ModelState.IsValid)
        {
            var request = Input.ToDomain(existing);
            var result = await service.SaveAsync(request, token);
            if (result.Succeeded)
            {
                var userId = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), NumberStyles.None, CultureInfo.InvariantCulture, out var parsed) ? parsed : (int?)null;
                await audit.WriteAsync(userId, User.Identity?.Name ?? "", options.Value.DefaultCompany,
                    Input.Id == 0 ? "customers.change-create" : "customers.change-update", "ClientesModificados", result.Id.ToString(CultureInfo.InvariantCulture), "Succeeded",
                    HttpContext.TraceIdentifier, HttpContext.Connection.RemoteIpAddress?.ToString(), token);
                TempData["StatusMessage"] = "La solicitud de cliente se guardó correctamente.";
                return RedirectToPage("Index");
            }
            foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error);
        }
        await LoadLocationsAsync(token);
        return Page();
    }

    public async Task<JsonResult> OnGetCantonsAsync(int provinceId, CancellationToken token) => new(await geography.GetCantonsAsync(provinceId, token));
    public async Task<JsonResult> OnGetDistrictsAsync(int provinceId, int cantonId, CancellationToken token) => new(await geography.GetDistrictsAsync(provinceId, cantonId, token));
    public async Task<JsonResult> OnGetNeighborhoodsAsync(int provinceId, int cantonId, int districtId, CancellationToken token) => new(await geography.GetNeighborhoodsAsync(provinceId, cantonId, districtId, token));
    private async Task LoadLocationsAsync(CancellationToken token)
    {
        Provinces = Items(await geography.GetProvincesAsync(token), Input.ProvinceId);
        Cantons = Input.ProvinceId > 0 ? Items(await geography.GetCantonsAsync(Input.ProvinceId, token), Input.CantonId) : [];
        Districts = Input.CantonId > 0 ? Items(await geography.GetDistrictsAsync(Input.ProvinceId, Input.CantonId, token), Input.DistrictId) : [];
        Neighborhoods = Input.DistrictId > 0 ? Items(await geography.GetNeighborhoodsAsync(Input.ProvinceId, Input.CantonId, Input.DistrictId, token), Input.NeighborhoodId) : [];
    }
    private static IReadOnlyCollection<SelectListItem> Items(IEnumerable<LocationOption> source, int selected) => source.Select(x => new SelectListItem(x.Name, x.Id.ToString(CultureInfo.InvariantCulture), x.Id == selected)).ToArray();

    public sealed class InputModel
    {
        public long Id { get; set; }
        [Required, StringLength(50), Display(Name = "Código")] public string Code { get; set; } = "";
        [Required, StringLength(200), Display(Name = "Nombre")] public string Name { get; set; } = "";
        [Required, StringLength(20), Display(Name = "Identificación")] public string TaxId { get; set; } = "";
        [Range(1, 4), Display(Name = "Tipo de identificación")] public int IdentificationType { get; set; } = 2;
        [StringLength(200), Display(Name = "Responsable tributario")] public string? TaxResponsible { get; set; }
        [StringLength(200), Display(Name = "Nombre comercial")] public string? TradeName { get; set; }
        [StringLength(50), Display(Name = "Teléfono")] public string? Phone1 { get; set; }
        [StringLength(50), Display(Name = "Teléfono secundario")] public string? Phone2 { get; set; }
        [EmailAddress, StringLength(254), Display(Name = "Correo")] public string? Email { get; set; }
        [StringLength(500), Display(Name = "Dirección")] public string? Address { get; set; }
        [StringLength(50), Display(Name = "Agente")] public string? AgentCode { get; set; }
        [StringLength(20), Display(Name = "Día de visita")] public string? VisitSchedule { get; set; }
        [DataType(DataType.Password), StringLength(512), Display(Name = "Nueva clave web")] public string? WebPassword { get; set; }
        [Range(-90, 90), Display(Name = "Latitud")] public decimal? Latitude { get; set; }
        [Range(-180, 180), Display(Name = "Longitud")] public decimal? Longitude { get; set; }
        [Range(1, int.MaxValue), Display(Name = "Provincia")] public int ProvinceId { get; set; }
        [Range(1, int.MaxValue), Display(Name = "Cantón")] public int CantonId { get; set; }
        [Range(1, int.MaxValue), Display(Name = "Distrito")] public int DistrictId { get; set; }
        [Range(1, int.MaxValue), Display(Name = "Barrio")] public int NeighborhoodId { get; set; }
        [Display(Name = "Tipo de solicitud")] public CustomerChangeState State { get; set; } = CustomerChangeState.Modified;
        [StringLength(20), Display(Name = "Tipo de socio")] public string? PartnerType { get; set; }
        public CustomerChangeRequest ToDomain(CustomerChangeRequest? old) => new() { Id = Id, Sequence = old?.Sequence ?? "", Code = old?.Code ?? Code, Name = Name, TaxId = TaxId, IdentificationType = IdentificationType, TaxResponsible = TaxResponsible, TradeName = TradeName, Phone1 = Phone1, Phone2 = Phone2, Email = Email, Address = Address, AgentCode = AgentCode, VisitSchedule = VisitSchedule, WebPassword = string.IsNullOrEmpty(WebPassword) ? old?.WebPassword : WebPassword, Latitude = Latitude, Longitude = Longitude, ProvinceId = ProvinceId, CantonId = CantonId, DistrictId = DistrictId, NeighborhoodId = NeighborhoodId, State = State, PartnerType = PartnerType, RequestedAt = old?.RequestedAt ?? DateTime.Now, Approved = old?.Approved ?? false, ExemptionDocumentType = old?.ExemptionDocumentType, ExemptionNumber = old?.ExemptionNumber, ExemptionInstitution = old?.ExemptionInstitution, ExemptionIssuedOn = old?.ExemptionIssuedOn, ExemptionPercent = old?.ExemptionPercent, ExemptionExpiresOn = old?.ExemptionExpiresOn };
        public static InputModel From(CustomerChangeRequest x) => new() { Id = x.Id, Code = x.Code, Name = x.Name, TaxId = x.TaxId, IdentificationType = x.IdentificationType, TaxResponsible = x.TaxResponsible, TradeName = x.TradeName, Phone1 = x.Phone1, Phone2 = x.Phone2, Email = x.Email, Address = x.Address, AgentCode = x.AgentCode, VisitSchedule = x.VisitSchedule, Latitude = x.Latitude, Longitude = x.Longitude, ProvinceId = x.ProvinceId, CantonId = x.CantonId, DistrictId = x.DistrictId, NeighborhoodId = x.NeighborhoodId, State = x.State, PartnerType = x.PartnerType };
    }
}
