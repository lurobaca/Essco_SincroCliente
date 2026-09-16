namespace Essco.Application.Configuration;

public sealed class EsscoOptions
{
    public const string SectionName = "Essco";

    public string DefaultCompany { get; init; } = "";
    public DatabaseEndpointOptions SqlServer { get; init; } = new();
    public DatabaseEndpointOptions MySql { get; init; } = new();
    public SapBridgeOptions SapBridge { get; init; } = new();
    public SapCompanyOptions Sap { get; init; } = new();

    public IReadOnlyCollection<string> Validate()
    {
        var errors = new List<string>();
        ValidateDatabase(SqlServer, "SqlServer", errors);
        ValidateDatabase(MySql, "MySql", errors);

        if (SapBridge.Enabled && !SapBridge.Transport.Equals("SqlServer", StringComparison.OrdinalIgnoreCase) && string.IsNullOrWhiteSpace(SapBridge.Endpoint))
            errors.Add("Essco:SapBridge:Endpoint es obligatorio cuando SAP Bridge está habilitado.");
        if (SapBridge.Enabled && SapBridge.Transport.Equals("InMemory", StringComparison.OrdinalIgnoreCase))
            errors.Add("El transporte InMemory no puede utilizarse cuando SAP Bridge está habilitado.");
        if (Sap.Enabled)
        {
            Required(Sap.Server, "Essco:Sap:Server", errors);
            Required(Sap.CompanyDatabase, "Essco:Sap:CompanyDatabase", errors);
            Required(Sap.UserName, "Essco:Sap:UserName", errors);
            Required(Sap.Password, "Essco:Sap:Password", errors);
            Required(Sap.DatabaseUserName, "Essco:Sap:DatabaseUserName", errors);
            Required(Sap.DatabasePassword, "Essco:Sap:DatabasePassword", errors);
            if (Sap.DatabaseServerType < 0) errors.Add("Essco:Sap:DatabaseServerType debe ser el valor numérico de BoDataServerTypes.");
        }

        return errors;
    }

    private static void Required(string value,string path,ICollection<string> errors)
    { if(string.IsNullOrWhiteSpace(value))errors.Add($"{path} es obligatorio cuando SAP está habilitado."); }

    private static void ValidateDatabase(DatabaseEndpointOptions options, string name, ICollection<string> errors)
    {
        if (options.Enabled && string.IsNullOrWhiteSpace(options.ConnectionStringName))
            errors.Add($"Essco:{name}:ConnectionStringName es obligatorio cuando la base está habilitada.");
        if (options.CommandTimeoutSeconds is < 1 or > 600)
            errors.Add($"Essco:{name}:CommandTimeoutSeconds debe estar entre 1 y 600.");
    }
}

public sealed class DatabaseEndpointOptions
{
    public bool Enabled { get; init; }
    public string ConnectionStringName { get; init; } = "";
    public int CommandTimeoutSeconds { get; init; } = 30;
}

public sealed class SapBridgeOptions
{
    public bool Enabled { get; init; }
    public string Transport { get; init; } = "InMemory";
    public string Endpoint { get; init; } = "";
}

public sealed class SapCompanyOptions
{
    public bool Enabled { get; init; }
    public string Server { get; init; } = "";
    public string CompanyDatabase { get; init; } = "";
    public string UserName { get; init; } = "";
    public string Password { get; init; } = "";
    public string DatabaseUserName { get; init; } = "";
    public string DatabasePassword { get; init; } = "";
    public string LicenseServer { get; init; } = "";
    public int DatabaseServerType { get; init; } = -1;
}
