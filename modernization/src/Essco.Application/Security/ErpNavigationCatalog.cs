namespace Essco.Application.Security;

public enum NavigationMigrationState
{
    Partial,
    NotMigrated,
    ObsoleteReview
}

public sealed record NavigationOption(
    string Label,
    string OriginalControl,
    string? OriginalForm = null,
    NavigationMigrationState State = NavigationMigrationState.NotMigrated,
    string? Page = null,
    string? Permission = null,
    IReadOnlyList<NavigationOption>? Children = null)
{
    public bool IsNavigable => State == NavigationMigrationState.Partial && Page is not null;
    public IReadOnlyList<NavigationOption> Items => Children ?? [];
    public NavigationIcon Icon => NavigationIconRegistry.For(OriginalControl);
}

/// <summary>
/// Proyección para el usuario de Principal.MenuStrip1. Se mantiene explícita de forma intencional:
/// cambiar una opción de pendiente a disponible requiere revisar el cambio de estado y ruta.
/// </summary>
public static class ErpNavigationCatalog
{
    private static NavigationOption P(string label, string control, string form, string page, string permission) =>
        new(label, control, form, NavigationMigrationState.Partial, page, permission);
    private static NavigationOption N(string label, string control, string? form = null) => new(label, control, form);
    private static NavigationOption O(string label, string control, string? form = null) =>
        new(label, control, form, NavigationMigrationState.ObsoleteReview);
    private static NavigationOption G(string label, string control, params NavigationOption[] children) =>
        new(label, control, Children: children);

    public static IReadOnlyList<NavigationOption> Groups { get; } =
    [
        G("Facturación","FacturacionToolStripMenuItem",
            P("Estado de transmisiones","EstadoDeTransmisionesToolStripMenuItem","EstadoSubida","/Billing/Index",Permissions.Billing),
            N("Reportes de carga","ReportesDeCargaToolStripMenuItem","ReportesDeCarga"),
            P("Reporte de facturas","ReporteDeFacturasToolStripMenuItem","Reporte_Facturas","/Reports/Index",Permissions.Reports),
            N("Últimos consecutivos","UltimosConsecutivosToolStripMenuItem","UltimosConsecutivos"),
            P("Descuentos fijos","DescuentosFijosToolStripMenuItem","DescFijos / DescuentosFijos","/Products/Discounts",Permissions.Billing),
            P("Información del cliente","InformacionDelClienteToolStripMenuItem","ClientesShow","/Customers/Index",Permissions.Customers),
            P("Devoluciones","DevolucionesToolStripMenuItem","Devoluciones","/Returns/Index",Permissions.Billing),
            P("Devoluciones pendientes","DevolucionesPendientesToolStripMenuItem","Devoluciones_Pendientes","/Returns/Index",Permissions.Billing),
            P("Estado de comprobantes","EstadoComprobantesToolStripMenuItem","Admin_EstadoComprobantes","/Billing/Index",Permissions.Billing),
            P("Aceptar o rechazar facturas","AceptaRechazaFacturasToolStripMenuItem","Acepta_Rechaza","/Billing/Index",Permissions.Billing)),

        G("Administrar","AdministrarToolStripMenuItem",
            P("Agentes y choferes","AgentesToolStripMenuItem","Admin_Agentes","/Catalogs/SalesAgents",Permissions.Catalogs),
            P("Bodegueros","BodeguerosToolStripMenuItem","Admin_Bodeguero","/Catalogs/WarehouseOperators",Permissions.Catalogs),
            P("Empresa","EmpresaToolStripMenuItem","Manager_Empresa","/Companies/Profile",Permissions.Company),
            P("Choferes y ayudantes","ChoferesToolStripMenuItem","Admin_Choferes","/Catalogs/Drivers",Permissions.Catalogs),
            P("Rutas","RutasToolStripMenuItem","Admin_Rutas","/Catalogs/Routes",Permissions.Catalogs),
            N("Universos","UniversosToolStripMenuItem","Universos"),
            P("Cambio de información del cliente","CambioInfoClienteToolStripMenuItem","CambioInfoClientes","/Customers/Index",Permissions.Customers),
            N("Usuarios","UsuariosToolStripMenuItem","Usuarios"),
            N("Camiones","CamionesToolStripMenuItem","Admin_Mantenimiento_Camiones"),
            P("Clientes","ClientesModificadosToolStripMenuItem","Admin_Clientes","/Customers/Index",Permissions.Customers),
            N("Decisiones","DesicionesToolStripMenuItem","Gerencia"),
            N("Licencias","LicenciasToolStripMenuItem","MantenimientoLicencias"),
            P("Bancos","BancosToolStripMenuItem","Admin_Bancos","/Catalogs/Banks",Permissions.Catalogs),
            P("Motivos de devolución","MotivosDeDevolucionToolStripMenuItem","Admin_MotivosDevolucion","/Catalogs/ReturnReasons",Permissions.Catalogs),
            P("Lista de precios","ListaDePreciosToolStripMenuItem","ListaDePrecios","/Products/PriceLists",Permissions.Billing)),

        G("Bodega","BodegaToolStripMenuItem",
            N("Reporte de carga","ReporteDeCargaToolStripMenuItem","ReportesDeCarga"),
            N("Reporte de devoluciones","ReporteDeDevolucionesToolStripMenuItem","ReporteDeDevoluciones"),
            P("Crear pedido","CrearPedidoToolStripMenuItem","Pedido_Principal","/Purchasing/Index",Permissions.Billing),
            N("Chequear reporte","ChequearReporteToolStripMenuItem","Rutas_RepCarga"),
            G("WMS","UbicacionesToolStripMenuItem",
                G("Bodega","BodegaToolStripMenuItem1",
                    N("Diseñar","DiseñarToolStripMenuItem1","WMS_MantenimientoBodegas"),
                    N("Ver","VerToolStripMenuItem","WMS_VerBodegas")),
                O("Recepción","RecepcionToolStripMenuItem1"),
                N("Líneas nuevas","LineasNuevasToolStripMenuItem","WMS_LineaNueva"),
                N("Chequeados","ChequeoToolStripMenuItem","WMS_PedidosChequeados"))),

        G("Liquidaciones","LiquidacionesToolStripMenuItem",
            G("Choferes","ContadoToolStripMenuItem",
                P("Nueva","NuevaToolStripMenuItem","Liquidacion_Choferes","/Liquidations/Index",Permissions.LiquidationDifferences),
                P("Gastos","GastosToolStripMenuItem1","Detalle_Gastos_Choferes","/Liquidations/Expenses",Permissions.LiquidationDifferences),
                P("Depósitos","DepositosToolStripMenuItem1","Admin_Depositos_Choferes","/Treasury/Deposits",Permissions.Cash),
                N("Buscar factura","BuscarFacturaToolStripMenuItem","BuscaFactura")),
            G("Agentes","CreditoToolStripMenuItem",
                P("Nueva","NuevaToolStripMenuItem1","Liquidacion_Agentes","/Liquidations/Index",Permissions.LiquidationDifferences),
                P("Gastos","GastosToolStripMenuItem2","Detalle_Gastos","/Liquidations/Expenses",Permissions.LiquidationDifferences),
                P("Depósitos","DepositosToolStripMenuItem2","Admin_Depositos_Agentes","/Treasury/Deposits",Permissions.Cash)),
            P("Revisar depósitos","RevisarDepositosToolStripMenuItem","RevisaDepositos","/Treasury/Deposits",Permissions.Cash)),

        G("Exportar","ExportarToolStripMenuItem",
            N("Información a Seller","InformacionToolStripMenuItem","Enviar_Info_Seller"),
            N("Información a Picking (bodega)","InformacionAPickingToolStripMenuItem","Enviar_Info_Picking"),
            N("Información a Deliver (camiones)","InformacionAEliverToolStripMenuItem","Enviar_Info_Deliver")),

        G("Reportes","ReportesToolStripMenuItem",
            P("Faltantes en facturación","FaltantesToolStripMenuItem","Report_Faltantes","/Reports/Index",Permissions.Reports),
            P("Faltante o sobrante de choferes","FaltanteSobranteLiquidacionChoferesToolStripMenuItem","Report_Faltantes_Choferes","/Liquidations/Summary",Permissions.LiquidationDifferences),
            P("Faltante o sobrante de agentes","FaltanteSobranteLiquidacionAgentesToolStripMenuItem","Report_Faltantes","/Liquidations/Summary",Permissions.LiquidationDifferences),
            N("Math Hacienda","MathHaciendaToolStripMenuItem","Math_Hacienda")),

        G("Conteo físico","InventarioToolStripMenuItem",
            P("Nuevo","GruposToolStripMenuItem","Inv_NuevoConteo","/Inventory/Index",Permissions.Warehouse),
            P("Grupos","GruposToolStripMenuItem1","GruposConteo","/Inventory/Index",Permissions.Warehouse),
            P("Control","ControlToolStripMenuItem","Inv_Control","/Inventory/Index",Permissions.Warehouse),
            P("Conteo activo","ConteoActivoToolStripMenuItem","Inv_SeguridadConteoGrupos","/Inventory/Index",Permissions.Warehouse),
            P("Cruzar","CruzarToolStripMenuItem","Inv_Cruzar","/Inventory/Compare",Permissions.Warehouse),
            P("Conteos realizados","ConteoRealizadosToolStripMenuItem","Inv_ConteosRealizados","/Inventory/Index",Permissions.Warehouse)),

        G("Planilla","PlanillaToolStripMenuItem",
            P("Nueva","NuevaToolStripMenuItem2","Planilla","/Payroll/Index",Permissions.Payroll),
            P("Empleados","EmpleadosToolStripMenuItem","Planilla_Empleados","/Employees/Index",Permissions.EmployeesView),
            P("Aumentos","AumentosToolStripMenuItem","Planilla_AplicarAumento","/Employees/Index",Permissions.Payroll),
            P("Deducciones fijas","DeduccionesToolStripMenuItem","DeduccionesAcreditaciones","/Employees/Index",Permissions.Payroll),
            N("Desglose de renta","DesgloseDeRentaToolStripMenuItem","PlanillaDesgloseDeRenta"),
            N("Desglose de CCSS","DesgloseDeCCSSToolStripMenuItem","Planilla_DesgloceCCSS"),
            P("Asignar empleado a ruta","AsignaEmpleadoARutaToolStripMenuItem","PlanillaAsignaEmpleadoARuta","/Employees/Index",Permissions.Payroll)),

        G("Ventas","VentasToolStripMenuItem",
            N("Orden de compra / proforma","OrdenDeCompraToolStripMenuItem","Facturacion"),
            N("Facturación","FacturacionToolStripMenuItem1","Facturacion"),
            N("Notas de crédito","NotasDeCreditoToolStripMenuItem","Facturacion"),
            N("Notas de débito","NotasDeDebitoToolStripMenuItem","Facturacion"),
            P("Descuentos por periodo y cantidad","DescuentosPorPeriodoYCantidadToolStripMenuItem","Función comentada","/Products/Discounts",Permissions.Billing),
            O("Ofertas","OfertasToolStripMenuItem","Función comentada")),

        G("Inventario","ToolStripMenuItem8",
            P("Manager de artículos","ToolStripMenuItem9","Stock_Manager","/Products/Index",Permissions.Billing),
            N("Entradas","ToolStripMenuItem10"),
            N("Salidas","ToolStripMenuItem11"),
            N("Traslados","ToolStripMenuItem12"),
            P("Bodegas","ToolStripMenuItem13","Stock_Manager / pestaña bodegas","/Catalogs/Warehouses",Permissions.Catalogs)),

        G("Compras","ComprasToolStripMenuItem",
            P("Orden de compra","OrdenDeCompraToolStripMenuItem1","Pedido_Principal","/Purchasing/Index",Permissions.Billing),
            N("Facturación","FacturacionToolStripMenuItem2"),
            N("Notas de crédito","NotasDeCreditoToolStripMenuItem1"),
            N("Notas de débito","NotasDeDebitoToolStripMenuItem1")),

        G("Finanzas","FinanzasToolStripMenuItem",
            P("Recibos de dinero","RecibosDeDineroToolStripMenuItem1","RecibosDeDinero","/Treasury/Receipts",Permissions.Cash)),

        G("Acerca de","AcercaDeToolStripMenuItem",
            N("Sistema","SistemaToolStripMenuItem","AboutBox1"),
            O("Salir","SalirToolStripMenuItem","Cierre de aplicación de escritorio"))
    ];

    public static IEnumerable<NavigationOption> Descendants(IEnumerable<NavigationOption>? source = null) =>
        (source ?? Groups).SelectMany(x => new[] { x }.Concat(Descendants(x.Items)));
}
