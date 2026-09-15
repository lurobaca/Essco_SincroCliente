namespace Essco.Application.Security;

public static class LegacyRoles
{
    public const string SuperUser = "SuperUsuario";
    public const string Manager = "Manager";
    public const string Billing = "Facturacion";
    public const string Administration = "Administracion";
    public const string AccountsReceivable = "CuentasXCobrar";
    public const string Warehouse = "Bodega";
    public const string Accounting = "Contabilidad";
    public const string Reception = "Recepcion";

    public static IReadOnlyCollection<string> All { get; } =
    [SuperUser, Manager, Billing, Administration, AccountsReceivable, Warehouse, Accounting, Reception];
}

public static class Permissions
{
    public const string Billing = "billing.access";
    public const string Cash = "cash.access";
    public const string Administration = "administration.access";
    public const string Payroll = "payroll.access";
    public const string Export = "export.access";
    public const string Reports = "reports.access";
    public const string Users = "users.manage";
    public const string Company = "company.manage";
    public const string Warehouse = "warehouse.access";
    public const string LoadReports = "load-reports.access";
    public const string InvoiceReports = "invoice-reports.access";
    public const string LiquidationDifferences = "liquidation-differences.access";

    public static IReadOnlyCollection<string> All { get; } =
    [Billing, Cash, Administration, Payroll, Export, Reports, Users, Company, Warehouse,
        LoadReports, InvoiceReports, LiquidationDifferences];
}

public static class LegacyRolePermissions
{
    private static readonly IReadOnlyDictionary<string, IReadOnlySet<string>> Mapping =
        new Dictionary<string, IReadOnlySet<string>>(StringComparer.OrdinalIgnoreCase)
        {
            [LegacyRoles.SuperUser] = new HashSet<string>(Permissions.All, StringComparer.Ordinal),
            [LegacyRoles.Manager] = Set(Permissions.Billing, Permissions.Cash, Permissions.Administration,
                Permissions.Export, Permissions.Reports,
                Permissions.Company,
                Permissions.InvoiceReports, Permissions.LiquidationDifferences),
            [LegacyRoles.Billing] = Set(Permissions.Billing, Permissions.Administration,
                Permissions.Export, Permissions.Reports, Permissions.LoadReports, Permissions.InvoiceReports),
            [LegacyRoles.Administration] = Set(Permissions.Cash, Permissions.Administration,
                Permissions.Payroll, Permissions.Export, Permissions.Reports, Permissions.Users,
                Permissions.LiquidationDifferences),
            [LegacyRoles.AccountsReceivable] = Set(Permissions.Billing, Permissions.Administration,
                Permissions.Export, Permissions.Reports, Permissions.LiquidationDifferences),
            [LegacyRoles.Warehouse] = Set(Permissions.Administration, Permissions.Warehouse,
                Permissions.LoadReports, Permissions.InvoiceReports),
            [LegacyRoles.Accounting] = Set(Permissions.Export, Permissions.Reports,
                Permissions.LiquidationDifferences),
            [LegacyRoles.Reception] = Set(Permissions.Billing, Permissions.Administration,
                Permissions.Export, Permissions.Reports, Permissions.LiquidationDifferences)
        };

    public static bool HasPermission(string? role, string permission) =>
        role is not null && Mapping.TryGetValue(role, out var permissions) && permissions.Contains(permission);

    public static IReadOnlySet<string> GetPermissions(string? role) =>
        role is not null && Mapping.TryGetValue(role, out var permissions)
            ? permissions
            : new HashSet<string>(StringComparer.Ordinal);

    private static IReadOnlySet<string> Set(params string[] permissions) =>
        new HashSet<string>(permissions, StringComparer.Ordinal);
}
