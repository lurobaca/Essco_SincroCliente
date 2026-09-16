using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Claims;
using Essco.Application.Auditing;
using Essco.Application.Companies;
using Essco.Application.Configuration;
using Essco.Application.Security;
using Essco.Domain.Companies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace Essco.Web.Pages.Companies;

[Authorize(Policy = Permissions.Company)]
public sealed class ProfileModel(
    CompanyService companyService,
    IGeographyRepository geography,
    AuditService auditService,
    IOptions<EsscoOptions> options) : PageModel
{
    [BindProperty] public InputModel Input { get; set; } = new();
    public IReadOnlyCollection<SelectListItem> Provinces { get; private set; } = [];
    public IReadOnlyCollection<SelectListItem> Cantons { get; private set; } = [];
    public IReadOnlyCollection<SelectListItem> Districts { get; private set; } = [];
    public IReadOnlyCollection<SelectListItem> Neighborhoods { get; private set; } = [];
    [TempData] public string? StatusMessage { get; set; }

    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        var company = await companyService.GetAsync(cancellationToken);
        if (company is not null) Input = InputModel.From(company);
        await LoadLocationsAsync(cancellationToken);
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            var result = await companyService.SaveAsync(Input.ToDomain(), cancellationToken);
            if (result.Succeeded)
            {
                var userId = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), NumberStyles.None,
                    CultureInfo.InvariantCulture, out var parsed) ? parsed : (int?)null;
                await auditService.WriteAsync(userId, User.Identity?.Name ?? "", options.Value.DefaultCompany,
                    "company.profile-save", "Empresa", Input.TaxId, "Succeeded", HttpContext.TraceIdentifier,
                    HttpContext.Connection.RemoteIpAddress?.ToString(), cancellationToken);
                StatusMessage = "Los datos de la empresa se guardaron correctamente.";
                return RedirectToPage();
            }
            foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error);
        }
        await LoadLocationsAsync(cancellationToken);
        return Page();
    }

    public async Task<JsonResult> OnGetCantonsAsync(int provinceId, CancellationToken cancellationToken) =>
        new(await geography.GetCantonsAsync(provinceId, cancellationToken));
    public async Task<JsonResult> OnGetDistrictsAsync(int provinceId, int cantonId, CancellationToken cancellationToken) =>
        new(await geography.GetDistrictsAsync(provinceId, cantonId, cancellationToken));
    public async Task<JsonResult> OnGetNeighborhoodsAsync(int provinceId, int cantonId, int districtId, CancellationToken cancellationToken) =>
        new(await geography.GetNeighborhoodsAsync(provinceId, cantonId, districtId, cancellationToken));

    private async Task LoadLocationsAsync(CancellationToken cancellationToken)
    {
        Provinces = Items(await geography.GetProvincesAsync(cancellationToken), Input.ProvinceId);
        Cantons = Input.ProvinceId > 0 ? Items(await geography.GetCantonsAsync(Input.ProvinceId, cancellationToken), Input.CantonId) : [];
        Districts = Input.CantonId > 0 ? Items(await geography.GetDistrictsAsync(Input.ProvinceId, Input.CantonId, cancellationToken), Input.DistrictId) : [];
        Neighborhoods = Input.DistrictId > 0 ? Items(await geography.GetNeighborhoodsAsync(Input.ProvinceId, Input.CantonId, Input.DistrictId, cancellationToken), Input.NeighborhoodId) : [];
    }

    private static IReadOnlyCollection<SelectListItem> Items(IEnumerable<LocationOption> values, int selected) =>
        values.Select(x => new SelectListItem(x.Name, x.Id.ToString(CultureInfo.InvariantCulture), x.Id == selected)).ToArray();

    public sealed class InputModel
    {
        [Required, Display(Name="Identificación")] public string TaxId { get; set; } = "";
        [Display(Name="Tipo de identificación")] public CompanyIdentificationType IdentificationType { get; set; }
        [Required, StringLength(80), Display(Name="Razón social")] public string LegalName { get; set; } = "";
        [Required, StringLength(80), Display(Name="Nombre comercial")] public string TradeName { get; set; } = "";
        [Required, StringLength(30), Display(Name="Teléfono")] public string Phone { get; set; } = "";
        [StringLength(30), Display(Name="Teléfono secundario")] public string? SecondaryPhone { get; set; }
        [Required, EmailAddress, StringLength(254), Display(Name="Correo electrónico")] public string Email { get; set; } = "";
        [Url, StringLength(512), Display(Name="Sitio web")] public string? Website { get; set; }
        [Required, StringLength(500), Display(Name="Dirección exacta")] public string Address { get; set; } = "";
        [Range(1, int.MaxValue), Display(Name="Provincia")] public int ProvinceId { get; set; }
        [Range(1, int.MaxValue), Display(Name="Cantón")] public int CantonId { get; set; }
        [Range(1, int.MaxValue), Display(Name="Distrito")] public int DistrictId { get; set; }
        [Range(1, int.MaxValue), Display(Name="Barrio")] public int NeighborhoodId { get; set; }
        [StringLength(32), Display(Name="Código de actividad económica")] public string? EconomicActivityCode { get; set; }
        [StringLength(256), Display(Name="Actividad económica")] public string? EconomicActivityDescription { get; set; }
        [Range(0, int.MaxValue), Display(Name="Máximo de líneas por factura")] public int MaximumInvoiceLines { get; set; }
        [Range(typeof(decimal), "0", "100"), Display(Name="Descuento máximo (%)")] public decimal MaximumDiscountPercent { get; set; }
        [Range(0, int.MaxValue), Display(Name="Consecutivo reporte de carga")] public int LoadReportSequence { get; set; }
        [Range(0, int.MaxValue), Display(Name="Consecutivo reporte de devoluciones")] public int ReturnReportSequence { get; set; }
        [Range(0, int.MaxValue), Display(Name="Días de extensión")] public int ExtensionDays { get; set; }
        [Display(Name="Agrupación de descuentos")] public DiscountGroupingType DiscountGrouping { get; set; } = DiscountGroupingType.SpecificBusinessPartner;

        public CompanyProfile ToDomain() => new() { TaxId=TaxId.Trim(), IdentificationType=IdentificationType, LegalName=LegalName, TradeName=TradeName, Phone=Phone, SecondaryPhone=SecondaryPhone, Email=Email, Website=Website, Address=Address, ProvinceId=ProvinceId, CantonId=CantonId, DistrictId=DistrictId, NeighborhoodId=NeighborhoodId, EconomicActivityCode=EconomicActivityCode, EconomicActivityDescription=EconomicActivityDescription, MaximumInvoiceLines=MaximumInvoiceLines, MaximumDiscountPercent=MaximumDiscountPercent, LoadReportSequence=LoadReportSequence, ReturnReportSequence=ReturnReportSequence, ExtensionDays=ExtensionDays, DiscountGrouping=DiscountGrouping };
        public static InputModel From(CompanyProfile x) => new() { TaxId=x.TaxId, IdentificationType=x.IdentificationType, LegalName=x.LegalName, TradeName=x.TradeName, Phone=x.Phone, SecondaryPhone=x.SecondaryPhone, Email=x.Email, Website=x.Website, Address=x.Address, ProvinceId=x.ProvinceId, CantonId=x.CantonId, DistrictId=x.DistrictId, NeighborhoodId=x.NeighborhoodId, EconomicActivityCode=x.EconomicActivityCode, EconomicActivityDescription=x.EconomicActivityDescription, MaximumInvoiceLines=x.MaximumInvoiceLines, MaximumDiscountPercent=x.MaximumDiscountPercent, LoadReportSequence=x.LoadReportSequence, ReturnReportSequence=x.ReturnReportSequence, ExtensionDays=x.ExtensionDays, DiscountGrouping=x.DiscountGrouping };
    }
}
