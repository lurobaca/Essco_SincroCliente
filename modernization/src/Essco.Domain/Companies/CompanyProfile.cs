using System.Net.Mail;

namespace Essco.Domain.Companies;

public enum CompanyIdentificationType
{
    Physical = 0,
    LegalEntity = 1,
    Dimex = 2,
    Nite = 3
}

public enum DiscountGroupingType
{
    SpecificBusinessPartner = 2,
    CustomerGroup = 10
}

public sealed record CompanyProfile
{
    public required string TaxId { get; init; }
    public required CompanyIdentificationType IdentificationType { get; init; }
    public required string LegalName { get; init; }
    public required string TradeName { get; init; }
    public required string Phone { get; init; }
    public string? SecondaryPhone { get; init; }
    public required string Email { get; init; }
    public string? Website { get; init; }
    public required string Address { get; init; }
    public int ProvinceId { get; init; }
    public int CantonId { get; init; }
    public int DistrictId { get; init; }
    public int NeighborhoodId { get; init; }
    public string? EconomicActivityCode { get; init; }
    public string? EconomicActivityDescription { get; init; }
    public int MaximumInvoiceLines { get; init; }
    public decimal MaximumDiscountPercent { get; init; }
    public int LoadReportSequence { get; init; }
    public int ReturnReportSequence { get; init; }
    public int ExtensionDays { get; init; }
    public DiscountGroupingType DiscountGrouping { get; init; }

    public IReadOnlyCollection<string> Validate()
    {
        var errors = new List<string>();
        var expectedTaxIdLength = IdentificationType switch
        {
            CompanyIdentificationType.Physical => 9,
            CompanyIdentificationType.LegalEntity => 10,
            CompanyIdentificationType.Dimex => 12,
            CompanyIdentificationType.Nite => 10,
            _ => 0
        };
        if (TaxId.Length != expectedTaxIdLength || !TaxId.All(char.IsDigit))
            errors.Add($"La identificación debe contener {expectedTaxIdLength} dígitos.");
        Required(LegalName, 80, "Razón social", errors);
        Required(TradeName, 80, "Nombre comercial", errors);
        Required(Phone, 30, "Teléfono", errors);
        Required(Address, 500, "Dirección", errors);
        if (!string.IsNullOrWhiteSpace(SecondaryPhone) && SecondaryPhone.Length > 30)
            errors.Add("El teléfono secundario no puede superar 30 caracteres.");
        try { _ = new MailAddress(Email); }
        catch (FormatException) { errors.Add("El correo electrónico no es válido."); }
        if (Email.Length > 254) errors.Add("El correo electrónico no puede superar 254 caracteres.");
        if (MaximumInvoiceLines < 0) errors.Add("El máximo de líneas de factura no puede ser negativo.");
        if (MaximumDiscountPercent is < 0 or > 100) errors.Add("El descuento máximo debe estar entre 0 y 100.");
        if (LoadReportSequence < 0 || ReturnReportSequence < 0 || ExtensionDays < 0)
            errors.Add("Los consecutivos y días de extensión no pueden ser negativos.");
        if (!Enum.IsDefined(DiscountGrouping)) errors.Add("El tipo de agrupación de descuentos no es válido.");
        return errors;
    }

    private static void Required(string? value, int maximumLength, string name, ICollection<string> errors)
    {
        if (string.IsNullOrWhiteSpace(value)) errors.Add($"{name} es obligatorio.");
        else if (value.Trim().Length > maximumLength) errors.Add($"{name} no puede superar {maximumLength} caracteres.");
    }
}
