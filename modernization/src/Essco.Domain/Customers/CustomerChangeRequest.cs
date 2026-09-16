using System.Net.Mail;

namespace Essco.Domain.Customers;

public enum CustomerChangeState { Active = 0, Inactive = 1 }

public sealed record CustomerChangeRequest
{
    public long Id { get; init; }
    public required string Sequence { get; init; }
    public required string Code { get; init; }
    public required string Name { get; init; }
    public required string TaxId { get; init; }
    public string? TaxResponsible { get; init; }
    public string? VisitSchedule { get; init; }
    public string? WebPassword { get; init; }
    public string? Phone1 { get; init; }
    public string? Phone2 { get; init; }
    public string? Address { get; init; }
    public string? Email { get; init; }
    public string? TradeName { get; init; }
    public decimal? Latitude { get; init; }
    public decimal? Longitude { get; init; }
    public string? AgentCode { get; init; }
    public int ProvinceId { get; init; }
    public int CantonId { get; init; }
    public int DistrictId { get; init; }
    public int NeighborhoodId { get; init; }
    public CustomerChangeState State { get; init; }
    public int IdentificationType { get; init; }
    public DateTime RequestedAt { get; init; }
    public bool Approved { get; init; }
    public string? PartnerType { get; init; }
    public string? ExemptionDocumentType { get; init; }
    public string? ExemptionNumber { get; init; }
    public string? ExemptionInstitution { get; init; }
    public DateOnly? ExemptionIssuedOn { get; init; }
    public decimal? ExemptionPercent { get; init; }
    public DateOnly? ExemptionExpiresOn { get; init; }

    public IReadOnlyCollection<string> Validate()
    {
        var errors = new List<string>();
        Required(Code, 50, "Código", errors);
        Required(Name, 200, "Nombre", errors);
        Required(TaxId, 20, "Identificación", errors);
        Required(Sequence, 50, "Consecutivo", errors);
        if (!string.IsNullOrWhiteSpace(Email)) try { _ = new MailAddress(Email); } catch (FormatException) { errors.Add("El correo electrónico no es válido."); }
        if (Latitude is < -90 or > 90) errors.Add("La latitud debe estar entre -90 y 90.");
        if (Longitude is < -180 or > 180) errors.Add("La longitud debe estar entre -180 y 180.");
        if (ProvinceId <= 0 || CantonId <= 0 || DistrictId <= 0 || NeighborhoodId <= 0)
            errors.Add("La ubicación geográfica completa es obligatoria.");
        if (ExemptionPercent is < 0 or > 100) errors.Add("El porcentaje de exoneración debe estar entre 0 y 100.");
        if (ExemptionIssuedOn is not null && ExemptionExpiresOn < ExemptionIssuedOn)
            errors.Add("La fecha de vencimiento de la exoneración no puede ser anterior a su emisión.");
        return errors;
    }

    private static void Required(string? value, int max, string name, ICollection<string> errors)
    {
        if (string.IsNullOrWhiteSpace(value)) errors.Add($"{name} es obligatorio.");
        else if (value.Trim().Length > max) errors.Add($"{name} no puede superar {max} caracteres.");
    }
}
