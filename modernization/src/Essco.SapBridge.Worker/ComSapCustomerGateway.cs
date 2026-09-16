using System.Runtime.InteropServices;
using Essco.Application.Configuration;
using Essco.Application.Customers;
using Essco.SapBridge.Contracts;
using Microsoft.Extensions.Options;

namespace Essco.SapBridge.Worker;

public sealed class ComSapCustomerGateway(IOptions<EsscoOptions> options, ILogger<ComSapCustomerGateway> logger) : ISapCustomerGateway
{
    public ValueTask<SapProcessingResult> ExecuteAsync(string operation, SapCustomerData customer, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (!options.Value.Sap.Enabled) return ValueTask.FromResult(new SapProcessingResult(false, null, "La conexión SAP no está habilitada.", false));
        var completion = new TaskCompletionSource<SapProcessingResult>(TaskCreationOptions.RunContinuationsAsynchronously);
        var thread = new Thread(() =>
        {
            try { completion.TrySetResult(Execute(operation, customer)); }
            catch (COMException ex) { logger.LogWarning("Error COM SAP {Code} en {Operation}", ex.ErrorCode, operation); completion.TrySetResult(new(false, null, $"Error COM SAP ({ex.ErrorCode}).", true)); }
            catch (Exception ex) { logger.LogError(ex, "Error no controlado ejecutando {Operation} en SAP", operation); completion.TrySetResult(new(false, null, "Error interno del adaptador SAP.", true)); }
        })
        { IsBackground = true, Name = "Essco SAP DI API" };
        thread.SetApartmentState(ApartmentState.STA); thread.Start();
        return new(completion.Task);
    }
    private SapProcessingResult Execute(string operation, SapCustomerData data)
    {
        dynamic? company = null; dynamic? partner = null;
        try
        {
            var type = Type.GetTypeFromProgID("SAPbobsCOM.Company") ?? throw new COMException("SAP Business One DI API no está registrada.");
            company = Activator.CreateInstance(type) ?? throw new COMException("No fue posible crear SAPbobsCOM.Company.");
            var config = options.Value.Sap; company.Server = config.Server; company.CompanyDB = config.CompanyDatabase; company.UserName = config.UserName; company.Password = config.Password; company.DbUserName = config.DatabaseUserName; company.DbPassword = config.DatabasePassword; company.LicenseServer = config.LicenseServer; company.DbServerType = config.DatabaseServerType; company.UseTrusted = false;
            var connectionResult = (int)company.Connect(); if (connectionResult != 0) return Failure(company, connectionResult, true);
            partner = company.GetBusinessObject(2); // BoObjectTypes.oBusinessPartners
            return operation switch
            {
                CustomerSapOperations.Create => Create(company, partner, data),
                CustomerSapOperations.Update => Update(company, partner, data),
                CustomerSapOperations.Close => Close(company, partner, data.Customer.Code),
                _ => new SapProcessingResult(false, null, "Operación SAP de cliente no soportada.", false)
            };
        }
        finally
        {
            Release(partner);
            try { if (company is not null && (bool)company.Connected) company.Disconnect(); } catch (COMException) { }
            Release(company);
        }
    }
    private static SapProcessingResult Create(dynamic company, dynamic partner, SapCustomerData data)
    {
        var c = data.Customer; partner.CardCode = c.Code; partner.CardName = c.Name; partner.CardType = c.PartnerType == "2" ? 1 : 0; ApplyCommon(partner, data, true); var result = (int)partner.Add(); return result == 0 ? new SapProcessingResult(true, c.Code, null, false) : Failure(company, result, false);
    }
    private static SapProcessingResult Update(dynamic company, dynamic partner, SapCustomerData data)
    {
        var c = data.Customer; if (!(bool)partner.GetByKey(c.Code)) return new SapProcessingResult(false, null, "El socio de negocio no existe en SAP.", false); partner.CardName = c.Name; ApplyCommon(partner, data, false); var result = (int)partner.Update(); return result == 0 ? new SapProcessingResult(true, c.Code, null, false) : Failure(company, result, false);
    }
    private static SapProcessingResult Close(dynamic company, dynamic partner, string code)
    {
        if (!(bool)partner.GetByKey(code)) return new SapProcessingResult(false, null, "El socio de negocio no existe en SAP.", false); SetUserField(partner, "U_AGENTE1", "0"); SetUserField(partner, "U_AGENTE2", "0"); SetUserField(partner, "U_AGENTE3", "0"); SetUserField(partner, "U_AGENTE4", "CL2"); partner.SalesPersonCode = 9; partner.Valid = 0; partner.Frozen = 1; partner.FrozenFrom = DateTime.Today; partner.FrozenTo = DateTime.Today; partner.ValidFrom = DateTime.Today; partner.ValidTo = DateTime.Today; partner.Notes = $"Cliente Cerrado [{DateTime.Now:O}]"; var result = (int)partner.Update(); return result == 0 ? new SapProcessingResult(true, code, null, false) : Failure(company, result, false);
    }
    private static void ApplyCommon(dynamic partner, SapCustomerData data, bool creating)
    {
        var c = data.Customer; partner.FederalTaxID = c.TaxId.PadLeft(12, '0'); partner.GlobalLocationNumber = $"0{c.IdentificationType}"; partner.Phone1 = c.Phone1 ?? ""; partner.Phone2 = c.Phone2 ?? ""; partner.EmailAddress = c.Email ?? ""; partner.ContactPerson = c.TaxResponsible ?? ""; partner.CardForeignName = c.TradeName ?? ""; partner.SalesPersonCode = int.TryParse(c.AgentCode, out var agent) ? agent : -1;
        SetUserField(partner, "U_Tipo_Cedula", $"0{c.IdentificationType}"); SetUserField(partner, "U_Visita", c.VisitSchedule ?? ""); SetUserField(partner, "U_ClaveWeb", c.WebPassword ?? c.Code.Replace("-", "").Replace("C", "B", StringComparison.OrdinalIgnoreCase)); SetUserField(partner, "U_Latitud", c.Latitude?.ToString(System.Globalization.CultureInfo.InvariantCulture) ?? ""); SetUserField(partner, "U_Longitud", c.Longitude?.ToString(System.Globalization.CultureInfo.InvariantCulture) ?? "");
        if (creating) { SetUserField(partner, "U_AGENTE4", "CL1"); SetUserField(partner, "U_Descuento", "15"); SetUserField(partner, "U_bodega", "1"); SetUserField(partner, "U_NVT_Medio_Pago", "01"); SetUserField(partner, "U_CargarCxC", "01"); partner.Currency = "COL"; partner.PayTermsGrpCode = -1; }
        partner.Addresses.SetCurrentLine(0); partner.Addresses.TypeOfAddress = 0; partner.Addresses.AddressType = 0; partner.Addresses.AddressName = (c.Address ?? "")[..Math.Min(50, (c.Address ?? "").Length)]; partner.Addresses.Street = c.Address ?? ""; partner.Addresses.State = ProvinceForSap(c.ProvinceId); partner.Addresses.City = data.Canton; partner.Addresses.County = data.District; partner.Addresses.Block = data.Neighborhood;
    }
    private static int ProvinceForSap(int id) => id switch { 1 => 1, 2 => 2, 3 => 4, 4 => 3, 5 => 7, 6 => 5, 7 => 6, _ => id };
    private static void SetUserField(dynamic partner, string name, object value) => partner.UserFields.Fields.Item(name).Value = value;
    private static SapProcessingResult Failure(dynamic company, int code, bool connection)
    { int actual = code; string message = ""; company.GetLastError(ref actual, ref message); var retryable = connection || actual is -1102 or -111 or -8004 or -8005; return new(false, null, $"SAP DI API ({actual}): {Sanitize(message)}", retryable); }
    private static string Sanitize(string value) { var cleaned = value.Replace('\r', ' ').Replace('\n', ' ').Trim(); return cleaned[..Math.Min(500, cleaned.Length)]; }
    private static void Release(object? value) { if (value is not null && Marshal.IsComObject(value)) Marshal.FinalReleaseComObject(value); }
}
