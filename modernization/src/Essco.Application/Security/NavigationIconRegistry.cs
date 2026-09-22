namespace Essco.Application.Security;

public sealed record NavigationIcon(string Name, string Function, string Rationale);

/// <summary>
/// Matriz ejecutable de iconografía. La clave corresponde al control del menú WinForms;
/// la función se obtuvo siguiendo su evento Click hasta el formulario o proceso destino.
/// </summary>
public static class NavigationIconRegistry
{
    private static readonly IReadOnlyDictionary<string, NavigationIcon> Icons =
        new Dictionary<string, NavigationIcon>(StringComparer.Ordinal)
        {
            ["FacturacionToolStripMenuItem"] = I("receipt", "Procesos de facturación electrónica", "Documento comercial"),
            ["EstadoDeTransmisionesToolStripMenuItem"] = I("activity", "Seguimiento de transmisiones electrónicas", "Actividad de integración"),
            ["ReportesDeCargaToolStripMenuItem"] = I("file-chart-column", "Reporte de cargas procesadas", "Documento analítico"),
            ["ReporteDeFacturasToolStripMenuItem"] = I("file-chart-column", "Reporte de facturas emitidas", "Documento analítico"),
            ["UltimosConsecutivosToolStripMenuItem"] = I("hash", "Consulta de últimos consecutivos", "Numeración consecutiva"),
            ["DescuentosFijosToolStripMenuItem"] = I("badge-percent", "Mantenimiento de descuentos fijos", "Porcentaje comercial"),
            ["InformacionDelClienteToolStripMenuItem"] = I("contact", "Consulta de información del cliente", "Ficha de contacto"),
            ["DevolucionesToolStripMenuItem"] = I("undo-2", "Registro y consulta de devoluciones", "Retorno de mercancía"),
            ["DevolucionesPendientesToolStripMenuItem"] = I("clock-3", "Seguimiento de devoluciones pendientes", "Proceso pendiente"),
            ["EstadoComprobantesToolStripMenuItem"] = I("file-check-2", "Control de estados de comprobantes electrónicos", "Documento verificado"),
            ["AceptaRechazaFacturasToolStripMenuItem"] = I("circle-check-big", "Aceptación o rechazo de facturas", "Decisión sobre comprobante"),

            ["AdministrarToolStripMenuItem"] = I("settings", "Mantenimientos administrativos", "Configuración del sistema"),
            ["AgentesToolStripMenuItem"] = I("users", "Administración de agentes y choferes", "Personal operativo"),
            ["BodeguerosToolStripMenuItem"] = I("hard-hat", "Administración de personal de bodega", "Operador de bodega"),
            ["EmpresaToolStripMenuItem"] = I("building-2", "Configuración de la empresa", "Organización empresarial"),
            ["ChoferesToolStripMenuItem"] = I("truck", "Administración de choferes y ayudantes", "Transporte y reparto"),
            ["RutasToolStripMenuItem"] = I("route", "Mantenimiento de rutas", "Recorrido logístico"),
            ["UniversosToolStripMenuItem"] = I("orbit", "Configuración de universos comerciales", "Agrupación o universo"),
            ["CambioInfoClienteToolStripMenuItem"] = I("user-round-cog", "Cambio de información del cliente", "Edición de ficha personal"),
            ["UsuariosToolStripMenuItem"] = I("user-cog", "Administración de usuarios del sistema", "Cuenta y configuración"),
            ["CamionesToolStripMenuItem"] = I("truck", "Mantenimiento de camiones", "Vehículo de distribución"),
            ["ClientesModificadosToolStripMenuItem"] = I("contact", "Administración de solicitudes de clientes", "Ficha de cliente"),
            ["DesicionesToolStripMenuItem"] = I("scale", "Consulta gerencial para decisiones", "Evaluación gerencial"),
            ["LicenciasToolStripMenuItem"] = I("key-round", "Mantenimiento de licencias", "Clave de autorización"),
            ["BancosToolStripMenuItem"] = I("landmark", "Mantenimiento de bancos", "Entidad bancaria"),
            ["MotivosDeDevolucionToolStripMenuItem"] = I("message-square-warning", "Mantenimiento de motivos de devolución", "Motivo o incidencia"),
            ["ListaDePreciosToolStripMenuItem"] = I("tags", "Consulta de listas de precios", "Etiquetas de precio"),

            ["BodegaToolStripMenuItem"] = I("warehouse", "Operaciones generales de bodega", "Instalación de almacenamiento"),
            ["ReporteDeCargaToolStripMenuItem"] = I("file-up", "Reporte de carga de rutas", "Documento de carga"),
            ["ReporteDeDevolucionesToolStripMenuItem"] = I("file-down", "Reporte de devoluciones recibidas", "Documento de retorno"),
            ["CrearPedidoToolStripMenuItem"] = I("clipboard-plus", "Creación de pedidos", "Nueva orden"),
            ["ChequearReporteToolStripMenuItem"] = I("clipboard-check", "Verificación del reporte de carga", "Control de reporte"),
            ["UbicacionesToolStripMenuItem"] = I("boxes", "Operaciones del sistema WMS", "Inventario organizado"),
            ["BodegaToolStripMenuItem1"] = I("warehouse", "Diseño y consulta de bodegas WMS", "Estructura de bodega"),
            ["DiseñarToolStripMenuItem1"] = I("pencil-ruler", "Diseño de posiciones de bodega", "Diseño de estructura"),
            ["VerToolStripMenuItem"] = I("eye", "Visualización de bodegas", "Consulta visual"),
            ["RecepcionToolStripMenuItem1"] = I("package-open", "Recepción WMS sin handler activo", "Recepción de mercancía"),
            ["LineasNuevasToolStripMenuItem"] = I("list-plus", "Administración de líneas nuevas WMS", "Alta de líneas"),
            ["ChequeoToolStripMenuItem"] = I("badge-check", "Consulta de pedidos chequeados", "Pedido verificado"),

            ["LiquidacionesToolStripMenuItem"] = I("calculator", "Liquidaciones de choferes y agentes", "Cálculo de liquidación"),
            ["ContadoToolStripMenuItem"] = I("truck", "Liquidaciones de choferes", "Personal de reparto"),
            ["NuevaToolStripMenuItem"] = I("receipt", "Nueva liquidación de chofer", "Documento de liquidación"),
            ["GastosToolStripMenuItem1"] = I("badge-dollar-sign", "Detalle de gastos de chofer", "Egreso monetario"),
            ["DepositosToolStripMenuItem1"] = I("landmark", "Depósitos de choferes", "Movimiento bancario"),
            ["BuscarFacturaToolStripMenuItem"] = I("search", "Búsqueda de facturas", "Localización de documento"),
            ["CreditoToolStripMenuItem"] = I("users", "Liquidaciones de agentes", "Personal comercial"),
            ["NuevaToolStripMenuItem1"] = I("receipt", "Nueva liquidación de agente", "Documento de liquidación"),
            ["GastosToolStripMenuItem2"] = I("badge-dollar-sign", "Detalle de gastos de agente", "Egreso monetario"),
            ["DepositosToolStripMenuItem2"] = I("landmark", "Depósitos de agentes", "Movimiento bancario"),
            ["RevisarDepositosToolStripMenuItem"] = I("banknote", "Revisión de depósitos", "Validación de dinero"),

            ["ExportarToolStripMenuItem"] = I("send", "Exportación hacia aplicaciones móviles", "Envío de información"),
            ["InformacionToolStripMenuItem"] = I("smartphone", "Exportación de información a Seller", "Aplicación móvil comercial"),
            ["InformacionAPickingToolStripMenuItem"] = I("package-check", "Exportación de información a Picking", "Preparación de mercancía"),
            ["InformacionAEliverToolStripMenuItem"] = I("truck", "Exportación de información a Deliver", "Distribución en camión"),

            ["ReportesToolStripMenuItem"] = I("chart-no-axes-combined", "Reportes operativos y gerenciales", "Análisis de resultados"),
            ["FaltantesToolStripMenuItem"] = I("diff", "Reporte de faltantes de facturación", "Diferencia detectada"),
            ["FaltanteSobranteLiquidacionChoferesToolStripMenuItem"] = I("diff", "Faltantes o sobrantes de choferes", "Diferencia de liquidación"),
            ["FaltanteSobranteLiquidacionAgentesToolStripMenuItem"] = I("diff", "Faltantes o sobrantes de agentes", "Diferencia de liquidación"),
            ["MathHaciendaToolStripMenuItem"] = I("calculator", "Cálculos de conciliación con Hacienda", "Proceso matemático"),

            ["InventarioToolStripMenuItem"] = I("clipboard-list", "Conteos físicos de inventario", "Lista de conteo"),
            ["GruposToolStripMenuItem"] = I("clipboard-plus", "Creación de conteo físico", "Nuevo conteo"),
            ["GruposToolStripMenuItem1"] = I("users-round", "Administración de grupos de conteo", "Equipos de conteo"),
            ["ControlToolStripMenuItem"] = I("shield-check", "Control y supervisión del conteo", "Control operativo"),
            ["ConteoActivoToolStripMenuItem"] = I("activity", "Seguridad del conteo activo", "Proceso en ejecución"),
            ["CruzarToolStripMenuItem"] = I("arrow-right-left", "Cruce de conteos contra existencias", "Comparación bidireccional"),
            ["ConteoRealizadosToolStripMenuItem"] = I("history", "Consulta de conteos realizados", "Historial de procesos"),

            ["PlanillaToolStripMenuItem"] = I("wallet-cards", "Procesos de planilla", "Pago laboral"),
            ["NuevaToolStripMenuItem2"] = I("file-spreadsheet", "Creación y cálculo de planilla", "Documento tabular laboral"),
            ["EmpleadosToolStripMenuItem"] = I("briefcase-business", "Expediente y administración de empleados", "Colaborador y vínculo laboral"),
            ["AumentosToolStripMenuItem"] = I("trending-up", "Aplicación de aumentos salariales", "Incremento de remuneración"),
            ["DeduccionesToolStripMenuItem"] = I("badge-minus", "Deducciones y acreditaciones fijas", "Ajuste negativo de pago"),
            ["DesgloseDeRentaToolStripMenuItem"] = I("file-chart-column", "Desglose del impuesto de renta", "Detalle tributario"),
            ["DesgloseDeCCSSToolStripMenuItem"] = I("heart-pulse", "Desglose de cargas de la CCSS", "Seguridad social"),
            ["AsignaEmpleadoARutaToolStripMenuItem"] = I("map-pinned", "Asignación de empleado a ruta", "Persona ubicada en recorrido"),

            ["VentasToolStripMenuItem"] = I("shopping-cart", "Documentos del ciclo de ventas", "Operación comercial"),
            ["OrdenDeCompraToolStripMenuItem"] = I("clipboard-list", "Orden de compra o proforma de venta", "Documento previo a venta"),
            ["FacturacionToolStripMenuItem1"] = I("receipt", "Facturación de ventas", "Comprobante comercial"),
            ["NotasDeCreditoToolStripMenuItem"] = I("circle-minus", "Notas de crédito de ventas", "Disminución del saldo"),
            ["NotasDeDebitoToolStripMenuItem"] = I("circle-plus", "Notas de débito de ventas", "Aumento del saldo"),
            ["DescuentosPorPeriodoYCantidadToolStripMenuItem"] = I("badge-percent", "Descuentos por periodo y cantidad", "Regla porcentual"),
            ["OfertasToolStripMenuItem"] = I("tags", "Ofertas; handler original comentado", "Promoción comercial"),

            ["ToolStripMenuItem8"] = I("boxes", "Movimientos y maestros de inventario", "Conjunto de existencias"),
            ["ToolStripMenuItem9"] = I("package-search", "Manager de artículos", "Consulta y mantenimiento de producto"),
            ["ToolStripMenuItem10"] = I("package-plus", "Entradas de inventario", "Ingreso de mercancía"),
            ["ToolStripMenuItem11"] = I("package-minus", "Salidas de inventario", "Egreso de mercancía"),
            ["ToolStripMenuItem12"] = I("arrow-right-left", "Traslados entre bodegas", "Movimiento entre ubicaciones"),
            ["ToolStripMenuItem13"] = I("warehouse", "Mantenimiento de bodegas de inventario", "Lugar de almacenamiento"),

            ["ComprasToolStripMenuItem"] = I("shopping-cart", "Documentos del ciclo de compras", "Adquisición comercial"),
            ["OrdenDeCompraToolStripMenuItem1"] = I("clipboard-list", "Orden de compra a proveedor", "Documento de adquisición"),
            ["FacturacionToolStripMenuItem2"] = I("receipt", "Factura de compra", "Comprobante de proveedor"),
            ["NotasDeCreditoToolStripMenuItem1"] = I("circle-minus", "Nota de crédito de compra", "Disminución de obligación"),
            ["NotasDeDebitoToolStripMenuItem1"] = I("circle-plus", "Nota de débito de compra", "Aumento de obligación"),

            ["FinanzasToolStripMenuItem"] = I("landmark", "Operaciones financieras", "Gestión monetaria"),
            ["RecibosDeDineroToolStripMenuItem1"] = I("banknote", "Registro de recibos de dinero", "Ingreso monetario"),

            ["AcercaDeToolStripMenuItem"] = I("circle-help", "Información y salida del sistema", "Ayuda contextual"),
            ["SistemaToolStripMenuItem"] = I("badge-info", "Información de la aplicación", "Datos del sistema"),
            ["SalirToolStripMenuItem"] = I("log-out", "Cierre de la aplicación de escritorio", "Salida de sesión o aplicación")
        };

    public static NavigationIcon For(string originalControl) =>
        Icons.TryGetValue(originalControl, out var icon)
            ? icon
            : throw new InvalidOperationException($"No existe iconografía para {originalControl}.");

    private static NavigationIcon I(string name, string function, string rationale) =>
        new(name, function, rationale);
}
