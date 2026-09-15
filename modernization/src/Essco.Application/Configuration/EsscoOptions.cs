namespace Essco.Application.Configuration;

public sealed class EsscoOptions
{
    public const string SectionName = "Essco";

    public string DefaultCompany { get; init; } = "";
    public DatabaseEndpointOptions SqlServer { get; init; } = new();
    public DatabaseEndpointOptions MySql { get; init; } = new();
    public SapBridgeOptions SapBridge { get; init; } = new();

    public IReadOnlyCollection<string> Validate()
    {
        var errors = new List<string>();
        ValidateDatabase(SqlServer, "SqlServer", errors);
        ValidateDatabase(MySql, "MySql", errors);

        if (SapBridge.Enabled && string.IsNullOrWhiteSpace(SapBridge.Endpoint))
            errors.Add("Essco:SapBridge:Endpoint es obligatorio cuando SAP Bridge está habilitado.");
        if (SapBridge.Enabled && SapBridge.Transport.Equals("InMemory", StringComparison.OrdinalIgnoreCase))
            errors.Add("El transporte InMemory no puede utilizarse cuando SAP Bridge está habilitado.");

        return errors;
    }

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
