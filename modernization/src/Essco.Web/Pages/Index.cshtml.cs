using Essco.Application.Configuration;
using Essco.Application.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
namespace Essco.Web.Pages;

[AllowAnonymous]
public sealed class IndexModel(IWebHostEnvironment environment,IOptions<EsscoOptions> options,
    IConfiguration configuration,IAuthorizationService authorization):PageModel
{
    public bool ShowSetup => environment.IsDevelopment();
    public bool SqlConfigured => options.Value.SqlServer.Enabled &&
        !string.IsNullOrWhiteSpace(configuration.GetConnectionString(options.Value.SqlServer.ConnectionStringName));
    public List<Module> Modules {get;}=[];
    public async Task OnGetAsync()
    {
        foreach(var module in Catalog)
            if(User.Identity?.IsAuthenticated!=true || (await authorization.AuthorizeAsync(User,module.Permission)).Succeeded)
                Modules.Add(module);
    }
    public sealed record Module(string Title,string Description,string Page,string Permission,string State);
    private static readonly Module[] Catalog=[
        new("Inventario","Conteos, reconteos, unificación por proveedor y plantilla SAP.","/Inventory/Index",Permissions.Warehouse,"Flujo para pruebas"),
        new("Clientes","Solicitudes, datos del cliente, exoneraciones y estado de cuenta.","/Customers/Index",Permissions.Customers,"Integración por validar"),
        new("Productos","Consulta de artículos, precios y descuentos.","/Products/Index",Permissions.Billing,"Consulta y mantenimiento"),
        new("Tesorería","Depósitos, recibos y sus vínculos con liquidaciones.","/Treasury/Deposits",Permissions.Cash,"Integración por validar"),
        new("Liquidaciones","Agentes y choferes, gastos y conciliación de diferencias.","/Liquidations/Index",Permissions.LiquidationDifferences,"Flujo parcial"),
        new("Planillas","Planillas, aguinaldo y preparación del asiento SAP.","/Payroll/Index",Permissions.Payroll,"TXT bancario en validación"),
        new("Empleados","Expedientes, movimientos y documentos adjuntos.","/Employees/Index",Permissions.Payroll,"Flujo para pruebas"),
        new("Facturación","Consulta de facturas electrónicas y sus detalles.","/Billing/Index",Permissions.Billing,"Emisión pendiente"),
        new("Pedidos","Pedidos a proveedores y seguimiento de integración.","/Purchasing/Index",Permissions.Billing,"Integración por validar"),
        new("Devoluciones","Bandeja de devoluciones y notas de crédito.","/Returns/Index",Permissions.Billing,"Flujo parcial"),
        new("Empresa y catálogos","Empresa, rutas, bodegas, agentes, bancos y motivos.","/Catalogs/Index",Permissions.Catalogs,"Mantenimientos"),
        new("Reportes","Exportaciones disponibles; reportes heredados aún en migración.","/Reports/Index",Permissions.Reports,"Exportaciones iniciales")
    ];
}
