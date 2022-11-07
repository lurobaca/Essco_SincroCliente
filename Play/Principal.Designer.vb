<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Principal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LbL_Errorres = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DetErrores = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Time_BorraError = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.FacturacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstadoDeTransmisionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesDeCargaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeFacturasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltimosConsecutivosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DescuentosFijosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformacionDelClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DevolucionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DevolucionesPendientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstadoComprobantesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AceptaRechazaFacturasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BodegaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeCargaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeDevolucionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrearPedidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChequearReporteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UbicacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BodegaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DiseñarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecepcionToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LineasNuevasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChequeoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdministrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgentesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BodeguerosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmpresaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChoferesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RutasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UniversosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambioInfoClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CamionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesModificadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesicionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LicenciasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BancosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LiquidacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GastosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DepositosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarFacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreditoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GastosToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DepositosToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RevisarDepositosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformacionAPickingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformacionAEliverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FaltantesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FaltanteSobranteLiquidacionChoferesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FaltanteSobranteLiquidacionAgentesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MathHaciendaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GruposToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GruposToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConteoActivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CruzarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConteoRealizadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlanillaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmpleadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeduccionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SistemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdenDeCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturacionToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotasDeCreditoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotasDeDebitoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DescuentosPorPeriodoYCantidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OfertasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComprasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdenDeCompraToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturacionToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotasDeCreditoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotasDeDebitoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarSesionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(17, 17)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LbL_Errorres, Me.ToolStripStatusLabel1, Me.DetErrores, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 582)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1473, 25)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LbL_Errorres
        '
        Me.LbL_Errorres.ForeColor = System.Drawing.Color.Red
        Me.LbL_Errorres.Name = "LbL_Errorres"
        Me.LbL_Errorres.Size = New System.Drawing.Size(0, 20)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Red
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.White
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 20)
        '
        'DetErrores
        '
        Me.DetErrores.ForeColor = System.Drawing.Color.Red
        Me.DetErrores.Name = "DetErrores"
        Me.DetErrores.Size = New System.Drawing.Size(128, 20)
        Me.DetErrores.Text = "Detalle de Errores"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(741, 20)
        Me.ToolStripStatusLabel2.Text = " es Desarrollado por Luis Roberto Bastos Castillo Cedula 603820988 Tel: 88801662 " &
    "Email: lurobaca@gmail.com"
        '
        'Time_BorraError
        '
        Me.Time_BorraError.Interval = 2000
        '
        'FacturacionToolStripMenuItem
        '
        Me.FacturacionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EstadoDeTransmisionesToolStripMenuItem, Me.ReportesDeCargaToolStripMenuItem, Me.ReporteDeFacturasToolStripMenuItem, Me.UltimosConsecutivosToolStripMenuItem, Me.DescuentosFijosToolStripMenuItem, Me.InformacionDelClienteToolStripMenuItem, Me.DevolucionesToolStripMenuItem, Me.DevolucionesPendientesToolStripMenuItem, Me.EstadoComprobantesToolStripMenuItem, Me.AceptaRechazaFacturasToolStripMenuItem})
        Me.FacturacionToolStripMenuItem.Name = "FacturacionToolStripMenuItem"
        Me.FacturacionToolStripMenuItem.Size = New System.Drawing.Size(96, 24)
        Me.FacturacionToolStripMenuItem.Text = "Facturacion"
        '
        'EstadoDeTransmisionesToolStripMenuItem
        '
        Me.EstadoDeTransmisionesToolStripMenuItem.Name = "EstadoDeTransmisionesToolStripMenuItem"
        Me.EstadoDeTransmisionesToolStripMenuItem.Size = New System.Drawing.Size(249, 26)
        Me.EstadoDeTransmisionesToolStripMenuItem.Text = "Estado de Transmisiones"
        '
        'ReportesDeCargaToolStripMenuItem
        '
        Me.ReportesDeCargaToolStripMenuItem.Name = "ReportesDeCargaToolStripMenuItem"
        Me.ReportesDeCargaToolStripMenuItem.Size = New System.Drawing.Size(249, 26)
        Me.ReportesDeCargaToolStripMenuItem.Text = "Reportes de Carga"
        Me.ReportesDeCargaToolStripMenuItem.Visible = False
        '
        'ReporteDeFacturasToolStripMenuItem
        '
        Me.ReporteDeFacturasToolStripMenuItem.Name = "ReporteDeFacturasToolStripMenuItem"
        Me.ReporteDeFacturasToolStripMenuItem.Size = New System.Drawing.Size(249, 26)
        Me.ReporteDeFacturasToolStripMenuItem.Text = "Reporte de Facturas"
        Me.ReporteDeFacturasToolStripMenuItem.Visible = False
        '
        'UltimosConsecutivosToolStripMenuItem
        '
        Me.UltimosConsecutivosToolStripMenuItem.Name = "UltimosConsecutivosToolStripMenuItem"
        Me.UltimosConsecutivosToolStripMenuItem.Size = New System.Drawing.Size(249, 26)
        Me.UltimosConsecutivosToolStripMenuItem.Text = "Ultimos Consecutivos"
        Me.UltimosConsecutivosToolStripMenuItem.Visible = False
        '
        'DescuentosFijosToolStripMenuItem
        '
        Me.DescuentosFijosToolStripMenuItem.Name = "DescuentosFijosToolStripMenuItem"
        Me.DescuentosFijosToolStripMenuItem.Size = New System.Drawing.Size(249, 26)
        Me.DescuentosFijosToolStripMenuItem.Text = "Descuentos Fijos"
        Me.DescuentosFijosToolStripMenuItem.Visible = False
        '
        'InformacionDelClienteToolStripMenuItem
        '
        Me.InformacionDelClienteToolStripMenuItem.Name = "InformacionDelClienteToolStripMenuItem"
        Me.InformacionDelClienteToolStripMenuItem.Size = New System.Drawing.Size(249, 26)
        Me.InformacionDelClienteToolStripMenuItem.Text = "Informacion del cliente"
        Me.InformacionDelClienteToolStripMenuItem.Visible = False
        '
        'DevolucionesToolStripMenuItem
        '
        Me.DevolucionesToolStripMenuItem.Name = "DevolucionesToolStripMenuItem"
        Me.DevolucionesToolStripMenuItem.Size = New System.Drawing.Size(249, 26)
        Me.DevolucionesToolStripMenuItem.Text = "Devoluciones"
        Me.DevolucionesToolStripMenuItem.Visible = False
        '
        'DevolucionesPendientesToolStripMenuItem
        '
        Me.DevolucionesPendientesToolStripMenuItem.Name = "DevolucionesPendientesToolStripMenuItem"
        Me.DevolucionesPendientesToolStripMenuItem.Size = New System.Drawing.Size(249, 26)
        Me.DevolucionesPendientesToolStripMenuItem.Text = "Devoluciones Pendientes"
        Me.DevolucionesPendientesToolStripMenuItem.Visible = False
        '
        'EstadoComprobantesToolStripMenuItem
        '
        Me.EstadoComprobantesToolStripMenuItem.Name = "EstadoComprobantesToolStripMenuItem"
        Me.EstadoComprobantesToolStripMenuItem.Size = New System.Drawing.Size(249, 26)
        Me.EstadoComprobantesToolStripMenuItem.Text = "Estado Comprobantes"
        Me.EstadoComprobantesToolStripMenuItem.Visible = False
        '
        'AceptaRechazaFacturasToolStripMenuItem
        '
        Me.AceptaRechazaFacturasToolStripMenuItem.Name = "AceptaRechazaFacturasToolStripMenuItem"
        Me.AceptaRechazaFacturasToolStripMenuItem.Size = New System.Drawing.Size(249, 26)
        Me.AceptaRechazaFacturasToolStripMenuItem.Text = "Acepta/Rechaza Facturas"
        Me.AceptaRechazaFacturasToolStripMenuItem.Visible = False
        '
        'BodegaToolStripMenuItem
        '
        Me.BodegaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReporteDeCargaToolStripMenuItem, Me.ReporteDeDevolucionesToolStripMenuItem, Me.CrearPedidoToolStripMenuItem, Me.ChequearReporteToolStripMenuItem, Me.UbicacionesToolStripMenuItem})
        Me.BodegaToolStripMenuItem.Name = "BodegaToolStripMenuItem"
        Me.BodegaToolStripMenuItem.Size = New System.Drawing.Size(73, 24)
        Me.BodegaToolStripMenuItem.Text = "Bodega"
        Me.BodegaToolStripMenuItem.Visible = False
        '
        'ReporteDeCargaToolStripMenuItem
        '
        Me.ReporteDeCargaToolStripMenuItem.Name = "ReporteDeCargaToolStripMenuItem"
        Me.ReporteDeCargaToolStripMenuItem.Size = New System.Drawing.Size(251, 26)
        Me.ReporteDeCargaToolStripMenuItem.Text = "Reporte de Carga"
        '
        'ReporteDeDevolucionesToolStripMenuItem
        '
        Me.ReporteDeDevolucionesToolStripMenuItem.Name = "ReporteDeDevolucionesToolStripMenuItem"
        Me.ReporteDeDevolucionesToolStripMenuItem.Size = New System.Drawing.Size(251, 26)
        Me.ReporteDeDevolucionesToolStripMenuItem.Text = "Reporte de Devoluciones"
        '
        'CrearPedidoToolStripMenuItem
        '
        Me.CrearPedidoToolStripMenuItem.Name = "CrearPedidoToolStripMenuItem"
        Me.CrearPedidoToolStripMenuItem.Size = New System.Drawing.Size(251, 26)
        Me.CrearPedidoToolStripMenuItem.Text = "Crear Pedido"
        '
        'ChequearReporteToolStripMenuItem
        '
        Me.ChequearReporteToolStripMenuItem.Name = "ChequearReporteToolStripMenuItem"
        Me.ChequearReporteToolStripMenuItem.Size = New System.Drawing.Size(251, 26)
        Me.ChequearReporteToolStripMenuItem.Text = "Chequear Reporte"
        Me.ChequearReporteToolStripMenuItem.Visible = False
        '
        'UbicacionesToolStripMenuItem
        '
        Me.UbicacionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BodegaToolStripMenuItem1, Me.RecepcionToolStripMenuItem1, Me.LineasNuevasToolStripMenuItem, Me.ChequeoToolStripMenuItem})
        Me.UbicacionesToolStripMenuItem.Name = "UbicacionesToolStripMenuItem"
        Me.UbicacionesToolStripMenuItem.Size = New System.Drawing.Size(251, 26)
        Me.UbicacionesToolStripMenuItem.Text = "WMS"
        '
        'BodegaToolStripMenuItem1
        '
        Me.BodegaToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DiseñarToolStripMenuItem1, Me.VerToolStripMenuItem})
        Me.BodegaToolStripMenuItem1.Name = "BodegaToolStripMenuItem1"
        Me.BodegaToolStripMenuItem1.Size = New System.Drawing.Size(177, 26)
        Me.BodegaToolStripMenuItem1.Text = "Bodega"
        '
        'DiseñarToolStripMenuItem1
        '
        Me.DiseñarToolStripMenuItem1.Name = "DiseñarToolStripMenuItem1"
        Me.DiseñarToolStripMenuItem1.Size = New System.Drawing.Size(134, 26)
        Me.DiseñarToolStripMenuItem1.Text = "Diseñar"
        '
        'VerToolStripMenuItem
        '
        Me.VerToolStripMenuItem.Name = "VerToolStripMenuItem"
        Me.VerToolStripMenuItem.Size = New System.Drawing.Size(134, 26)
        Me.VerToolStripMenuItem.Text = "Ver"
        '
        'RecepcionToolStripMenuItem1
        '
        Me.RecepcionToolStripMenuItem1.Name = "RecepcionToolStripMenuItem1"
        Me.RecepcionToolStripMenuItem1.Size = New System.Drawing.Size(177, 26)
        Me.RecepcionToolStripMenuItem1.Text = "Recepcion"
        '
        'LineasNuevasToolStripMenuItem
        '
        Me.LineasNuevasToolStripMenuItem.Name = "LineasNuevasToolStripMenuItem"
        Me.LineasNuevasToolStripMenuItem.Size = New System.Drawing.Size(177, 26)
        Me.LineasNuevasToolStripMenuItem.Text = "Lineas Nuevas"
        '
        'ChequeoToolStripMenuItem
        '
        Me.ChequeoToolStripMenuItem.Name = "ChequeoToolStripMenuItem"
        Me.ChequeoToolStripMenuItem.Size = New System.Drawing.Size(177, 26)
        Me.ChequeoToolStripMenuItem.Text = "Chequeados"
        '
        'AdministrarToolStripMenuItem
        '
        Me.AdministrarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgentesToolStripMenuItem, Me.BodeguerosToolStripMenuItem, Me.EmpresaToolStripMenuItem, Me.ChoferesToolStripMenuItem, Me.RutasToolStripMenuItem, Me.UniversosToolStripMenuItem, Me.CambioInfoClienteToolStripMenuItem, Me.UsuariosToolStripMenuItem, Me.CamionesToolStripMenuItem, Me.ClientesModificadosToolStripMenuItem, Me.DesicionesToolStripMenuItem, Me.LicenciasToolStripMenuItem, Me.BancosToolStripMenuItem})
        Me.AdministrarToolStripMenuItem.Name = "AdministrarToolStripMenuItem"
        Me.AdministrarToolStripMenuItem.Size = New System.Drawing.Size(98, 24)
        Me.AdministrarToolStripMenuItem.Text = "Administrar"
        '
        'AgentesToolStripMenuItem
        '
        Me.AgentesToolStripMenuItem.Name = "AgentesToolStripMenuItem"
        Me.AgentesToolStripMenuItem.Size = New System.Drawing.Size(226, 26)
        Me.AgentesToolStripMenuItem.Text = "Agente/Choferes"
        '
        'BodeguerosToolStripMenuItem
        '
        Me.BodeguerosToolStripMenuItem.Name = "BodeguerosToolStripMenuItem"
        Me.BodeguerosToolStripMenuItem.Size = New System.Drawing.Size(226, 26)
        Me.BodeguerosToolStripMenuItem.Text = "Bodegueros"
        Me.BodeguerosToolStripMenuItem.Visible = False
        '
        'EmpresaToolStripMenuItem
        '
        Me.EmpresaToolStripMenuItem.Name = "EmpresaToolStripMenuItem"
        Me.EmpresaToolStripMenuItem.Size = New System.Drawing.Size(226, 26)
        Me.EmpresaToolStripMenuItem.Text = "Empresa"
        '
        'ChoferesToolStripMenuItem
        '
        Me.ChoferesToolStripMenuItem.Name = "ChoferesToolStripMenuItem"
        Me.ChoferesToolStripMenuItem.Size = New System.Drawing.Size(226, 26)
        Me.ChoferesToolStripMenuItem.Text = "Choferes y Ayudantes"
        Me.ChoferesToolStripMenuItem.Visible = False
        '
        'RutasToolStripMenuItem
        '
        Me.RutasToolStripMenuItem.Name = "RutasToolStripMenuItem"
        Me.RutasToolStripMenuItem.Size = New System.Drawing.Size(226, 26)
        Me.RutasToolStripMenuItem.Text = "Rutas"
        Me.RutasToolStripMenuItem.Visible = False
        '
        'UniversosToolStripMenuItem
        '
        Me.UniversosToolStripMenuItem.Name = "UniversosToolStripMenuItem"
        Me.UniversosToolStripMenuItem.Size = New System.Drawing.Size(226, 26)
        Me.UniversosToolStripMenuItem.Text = "Universos"
        Me.UniversosToolStripMenuItem.Visible = False
        '
        'CambioInfoClienteToolStripMenuItem
        '
        Me.CambioInfoClienteToolStripMenuItem.Name = "CambioInfoClienteToolStripMenuItem"
        Me.CambioInfoClienteToolStripMenuItem.Size = New System.Drawing.Size(226, 26)
        Me.CambioInfoClienteToolStripMenuItem.Text = "Cambio Info cliente"
        Me.CambioInfoClienteToolStripMenuItem.Visible = False
        '
        'UsuariosToolStripMenuItem
        '
        Me.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem"
        Me.UsuariosToolStripMenuItem.Size = New System.Drawing.Size(226, 26)
        Me.UsuariosToolStripMenuItem.Text = "Usuarios"
        Me.UsuariosToolStripMenuItem.Visible = False
        '
        'CamionesToolStripMenuItem
        '
        Me.CamionesToolStripMenuItem.Name = "CamionesToolStripMenuItem"
        Me.CamionesToolStripMenuItem.Size = New System.Drawing.Size(226, 26)
        Me.CamionesToolStripMenuItem.Text = "Camiones"
        Me.CamionesToolStripMenuItem.Visible = False
        '
        'ClientesModificadosToolStripMenuItem
        '
        Me.ClientesModificadosToolStripMenuItem.Name = "ClientesModificadosToolStripMenuItem"
        Me.ClientesModificadosToolStripMenuItem.Size = New System.Drawing.Size(226, 26)
        Me.ClientesModificadosToolStripMenuItem.Text = "Clientes"
        '
        'DesicionesToolStripMenuItem
        '
        Me.DesicionesToolStripMenuItem.Name = "DesicionesToolStripMenuItem"
        Me.DesicionesToolStripMenuItem.Size = New System.Drawing.Size(226, 26)
        Me.DesicionesToolStripMenuItem.Text = "Decisiones"
        Me.DesicionesToolStripMenuItem.Visible = False
        '
        'LicenciasToolStripMenuItem
        '
        Me.LicenciasToolStripMenuItem.Name = "LicenciasToolStripMenuItem"
        Me.LicenciasToolStripMenuItem.Size = New System.Drawing.Size(226, 26)
        Me.LicenciasToolStripMenuItem.Text = "Licencias"
        Me.LicenciasToolStripMenuItem.Visible = False
        '
        'BancosToolStripMenuItem
        '
        Me.BancosToolStripMenuItem.Name = "BancosToolStripMenuItem"
        Me.BancosToolStripMenuItem.Size = New System.Drawing.Size(226, 26)
        Me.BancosToolStripMenuItem.Text = "Bancos"
        '
        'LiquidacionesToolStripMenuItem
        '
        Me.LiquidacionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContadoToolStripMenuItem, Me.CreditoToolStripMenuItem, Me.RevisarDepositosToolStripMenuItem})
        Me.LiquidacionesToolStripMenuItem.Name = "LiquidacionesToolStripMenuItem"
        Me.LiquidacionesToolStripMenuItem.Size = New System.Drawing.Size(112, 24)
        Me.LiquidacionesToolStripMenuItem.Text = "Liquidaciones"
        '
        'ContadoToolStripMenuItem
        '
        Me.ContadoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaToolStripMenuItem, Me.GastosToolStripMenuItem1, Me.DepositosToolStripMenuItem1, Me.BuscarFacturaToolStripMenuItem})
        Me.ContadoToolStripMenuItem.Name = "ContadoToolStripMenuItem"
        Me.ContadoToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.ContadoToolStripMenuItem.Text = "Choferes"
        Me.ContadoToolStripMenuItem.Visible = False
        '
        'NuevaToolStripMenuItem
        '
        Me.NuevaToolStripMenuItem.Name = "NuevaToolStripMenuItem"
        Me.NuevaToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.NuevaToolStripMenuItem.Text = "Nueva"
        '
        'GastosToolStripMenuItem1
        '
        Me.GastosToolStripMenuItem1.Name = "GastosToolStripMenuItem1"
        Me.GastosToolStripMenuItem1.Size = New System.Drawing.Size(216, 26)
        Me.GastosToolStripMenuItem1.Text = "Gastos"
        '
        'DepositosToolStripMenuItem1
        '
        Me.DepositosToolStripMenuItem1.Name = "DepositosToolStripMenuItem1"
        Me.DepositosToolStripMenuItem1.Size = New System.Drawing.Size(216, 26)
        Me.DepositosToolStripMenuItem1.Text = "Depositos"
        '
        'BuscarFacturaToolStripMenuItem
        '
        Me.BuscarFacturaToolStripMenuItem.Name = "BuscarFacturaToolStripMenuItem"
        Me.BuscarFacturaToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.BuscarFacturaToolStripMenuItem.Text = "Buscar Factura"
        '
        'CreditoToolStripMenuItem
        '
        Me.CreditoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaToolStripMenuItem1, Me.GastosToolStripMenuItem2, Me.DepositosToolStripMenuItem2})
        Me.CreditoToolStripMenuItem.Name = "CreditoToolStripMenuItem"
        Me.CreditoToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.CreditoToolStripMenuItem.Text = "Agentes"
        '
        'NuevaToolStripMenuItem1
        '
        Me.NuevaToolStripMenuItem1.Name = "NuevaToolStripMenuItem1"
        Me.NuevaToolStripMenuItem1.Size = New System.Drawing.Size(216, 26)
        Me.NuevaToolStripMenuItem1.Text = "Nueva"
        '
        'GastosToolStripMenuItem2
        '
        Me.GastosToolStripMenuItem2.Name = "GastosToolStripMenuItem2"
        Me.GastosToolStripMenuItem2.Size = New System.Drawing.Size(216, 26)
        Me.GastosToolStripMenuItem2.Text = "Gastos"
        '
        'DepositosToolStripMenuItem2
        '
        Me.DepositosToolStripMenuItem2.Name = "DepositosToolStripMenuItem2"
        Me.DepositosToolStripMenuItem2.Size = New System.Drawing.Size(216, 26)
        Me.DepositosToolStripMenuItem2.Text = "Depositos"
        '
        'RevisarDepositosToolStripMenuItem
        '
        Me.RevisarDepositosToolStripMenuItem.Name = "RevisarDepositosToolStripMenuItem"
        Me.RevisarDepositosToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.RevisarDepositosToolStripMenuItem.Text = "Revisar Depositos"
        Me.RevisarDepositosToolStripMenuItem.Visible = False
        '
        'ExportarToolStripMenuItem
        '
        Me.ExportarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InformacionToolStripMenuItem, Me.InformacionAPickingToolStripMenuItem, Me.InformacionAEliverToolStripMenuItem})
        Me.ExportarToolStripMenuItem.Name = "ExportarToolStripMenuItem"
        Me.ExportarToolStripMenuItem.Size = New System.Drawing.Size(77, 24)
        Me.ExportarToolStripMenuItem.Text = "Exportar"
        '
        'InformacionToolStripMenuItem
        '
        Me.InformacionToolStripMenuItem.Name = "InformacionToolStripMenuItem"
        Me.InformacionToolStripMenuItem.Size = New System.Drawing.Size(323, 26)
        Me.InformacionToolStripMenuItem.Text = "Informacion a Seller "
        '
        'InformacionAPickingToolStripMenuItem
        '
        Me.InformacionAPickingToolStripMenuItem.Name = "InformacionAPickingToolStripMenuItem"
        Me.InformacionAPickingToolStripMenuItem.Size = New System.Drawing.Size(323, 26)
        Me.InformacionAPickingToolStripMenuItem.Text = "Informacion a Picking  ( BODEGA )"
        Me.InformacionAPickingToolStripMenuItem.Visible = False
        '
        'InformacionAEliverToolStripMenuItem
        '
        Me.InformacionAEliverToolStripMenuItem.Name = "InformacionAEliverToolStripMenuItem"
        Me.InformacionAEliverToolStripMenuItem.Size = New System.Drawing.Size(323, 26)
        Me.InformacionAEliverToolStripMenuItem.Text = "Informacion a Deliver ( CAMIONES )"
        Me.InformacionAEliverToolStripMenuItem.Visible = False
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FaltantesToolStripMenuItem, Me.FaltanteSobranteLiquidacionChoferesToolStripMenuItem, Me.FaltanteSobranteLiquidacionAgentesToolStripMenuItem, Me.MathHaciendaToolStripMenuItem})
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(80, 24)
        Me.ReportesToolStripMenuItem.Text = "Reportes"
        '
        'FaltantesToolStripMenuItem
        '
        Me.FaltantesToolStripMenuItem.Name = "FaltantesToolStripMenuItem"
        Me.FaltantesToolStripMenuItem.Size = New System.Drawing.Size(345, 26)
        Me.FaltantesToolStripMenuItem.Text = "Faltantes en Facturacion"
        Me.FaltantesToolStripMenuItem.Visible = False
        '
        'FaltanteSobranteLiquidacionChoferesToolStripMenuItem
        '
        Me.FaltanteSobranteLiquidacionChoferesToolStripMenuItem.Name = "FaltanteSobranteLiquidacionChoferesToolStripMenuItem"
        Me.FaltanteSobranteLiquidacionChoferesToolStripMenuItem.Size = New System.Drawing.Size(345, 26)
        Me.FaltanteSobranteLiquidacionChoferesToolStripMenuItem.Text = "Faltante/Sobrante Liquidacion Choferes"
        Me.FaltanteSobranteLiquidacionChoferesToolStripMenuItem.Visible = False
        '
        'FaltanteSobranteLiquidacionAgentesToolStripMenuItem
        '
        Me.FaltanteSobranteLiquidacionAgentesToolStripMenuItem.Name = "FaltanteSobranteLiquidacionAgentesToolStripMenuItem"
        Me.FaltanteSobranteLiquidacionAgentesToolStripMenuItem.Size = New System.Drawing.Size(345, 26)
        Me.FaltanteSobranteLiquidacionAgentesToolStripMenuItem.Text = "Faltante/Sobrante Liquidacion Agentes"
        '
        'MathHaciendaToolStripMenuItem
        '
        Me.MathHaciendaToolStripMenuItem.Name = "MathHaciendaToolStripMenuItem"
        Me.MathHaciendaToolStripMenuItem.Size = New System.Drawing.Size(345, 26)
        Me.MathHaciendaToolStripMenuItem.Text = "Math Hacienda"
        Me.MathHaciendaToolStripMenuItem.Visible = False
        '
        'InventarioToolStripMenuItem
        '
        Me.InventarioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GruposToolStripMenuItem, Me.GruposToolStripMenuItem1, Me.ControlToolStripMenuItem, Me.ConteoActivoToolStripMenuItem, Me.CruzarToolStripMenuItem, Me.ConteoRealizadosToolStripMenuItem})
        Me.InventarioToolStripMenuItem.Name = "InventarioToolStripMenuItem"
        Me.InventarioToolStripMenuItem.Size = New System.Drawing.Size(110, 24)
        Me.InventarioToolStripMenuItem.Text = "Conteo Fisico"
        Me.InventarioToolStripMenuItem.Visible = False
        '
        'GruposToolStripMenuItem
        '
        Me.GruposToolStripMenuItem.Name = "GruposToolStripMenuItem"
        Me.GruposToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.GruposToolStripMenuItem.Text = "Nuevo"
        '
        'GruposToolStripMenuItem1
        '
        Me.GruposToolStripMenuItem1.Name = "GruposToolStripMenuItem1"
        Me.GruposToolStripMenuItem1.Size = New System.Drawing.Size(208, 26)
        Me.GruposToolStripMenuItem1.Text = "Grupos"
        '
        'ControlToolStripMenuItem
        '
        Me.ControlToolStripMenuItem.Name = "ControlToolStripMenuItem"
        Me.ControlToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.ControlToolStripMenuItem.Text = "Control"
        '
        'ConteoActivoToolStripMenuItem
        '
        Me.ConteoActivoToolStripMenuItem.Name = "ConteoActivoToolStripMenuItem"
        Me.ConteoActivoToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.ConteoActivoToolStripMenuItem.Text = "Conteo Activo"
        '
        'CruzarToolStripMenuItem
        '
        Me.CruzarToolStripMenuItem.Name = "CruzarToolStripMenuItem"
        Me.CruzarToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.CruzarToolStripMenuItem.Text = "Cruzar"
        '
        'ConteoRealizadosToolStripMenuItem
        '
        Me.ConteoRealizadosToolStripMenuItem.Name = "ConteoRealizadosToolStripMenuItem"
        Me.ConteoRealizadosToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.ConteoRealizadosToolStripMenuItem.Text = "Conteo Realizados"
        '
        'PlanillaToolStripMenuItem
        '
        Me.PlanillaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaToolStripMenuItem2, Me.EmpleadosToolStripMenuItem, Me.DeduccionesToolStripMenuItem})
        Me.PlanillaToolStripMenuItem.Name = "PlanillaToolStripMenuItem"
        Me.PlanillaToolStripMenuItem.Size = New System.Drawing.Size(69, 24)
        Me.PlanillaToolStripMenuItem.Text = "Planilla"
        Me.PlanillaToolStripMenuItem.Visible = False
        '
        'NuevaToolStripMenuItem2
        '
        Me.NuevaToolStripMenuItem2.Name = "NuevaToolStripMenuItem2"
        Me.NuevaToolStripMenuItem2.Size = New System.Drawing.Size(202, 26)
        Me.NuevaToolStripMenuItem2.Text = "Nueva"
        '
        'EmpleadosToolStripMenuItem
        '
        Me.EmpleadosToolStripMenuItem.Name = "EmpleadosToolStripMenuItem"
        Me.EmpleadosToolStripMenuItem.Size = New System.Drawing.Size(202, 26)
        Me.EmpleadosToolStripMenuItem.Text = "Empleados"
        '
        'DeduccionesToolStripMenuItem
        '
        Me.DeduccionesToolStripMenuItem.Name = "DeduccionesToolStripMenuItem"
        Me.DeduccionesToolStripMenuItem.Size = New System.Drawing.Size(202, 26)
        Me.DeduccionesToolStripMenuItem.Text = "Deducciones Fijas"
        '
        'AcercaDeToolStripMenuItem
        '
        Me.AcercaDeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SistemaToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        Me.AcercaDeToolStripMenuItem.Size = New System.Drawing.Size(87, 24)
        Me.AcercaDeToolStripMenuItem.Text = "Acerca de"
        Me.AcercaDeToolStripMenuItem.Visible = False
        '
        'SistemaToolStripMenuItem
        '
        Me.SistemaToolStripMenuItem.Name = "SistemaToolStripMenuItem"
        Me.SistemaToolStripMenuItem.Size = New System.Drawing.Size(136, 26)
        Me.SistemaToolStripMenuItem.Text = "Sistema"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(136, 26)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'VentasToolStripMenuItem
        '
        Me.VentasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OrdenDeCompraToolStripMenuItem, Me.FacturacionToolStripMenuItem1, Me.NotasDeCreditoToolStripMenuItem, Me.NotasDeDebitoToolStripMenuItem, Me.DescuentosPorPeriodoYCantidadToolStripMenuItem, Me.OfertasToolStripMenuItem})
        Me.VentasToolStripMenuItem.Name = "VentasToolStripMenuItem"
        Me.VentasToolStripMenuItem.Size = New System.Drawing.Size(64, 24)
        Me.VentasToolStripMenuItem.Text = "Ventas"
        Me.VentasToolStripMenuItem.Visible = False
        '
        'OrdenDeCompraToolStripMenuItem
        '
        Me.OrdenDeCompraToolStripMenuItem.Name = "OrdenDeCompraToolStripMenuItem"
        Me.OrdenDeCompraToolStripMenuItem.Size = New System.Drawing.Size(315, 26)
        Me.OrdenDeCompraToolStripMenuItem.Text = "Orden de Compra"
        '
        'FacturacionToolStripMenuItem1
        '
        Me.FacturacionToolStripMenuItem1.Name = "FacturacionToolStripMenuItem1"
        Me.FacturacionToolStripMenuItem1.Size = New System.Drawing.Size(315, 26)
        Me.FacturacionToolStripMenuItem1.Text = "Facturacion"
        '
        'NotasDeCreditoToolStripMenuItem
        '
        Me.NotasDeCreditoToolStripMenuItem.Name = "NotasDeCreditoToolStripMenuItem"
        Me.NotasDeCreditoToolStripMenuItem.Size = New System.Drawing.Size(315, 26)
        Me.NotasDeCreditoToolStripMenuItem.Text = "Notas de Credito"
        '
        'NotasDeDebitoToolStripMenuItem
        '
        Me.NotasDeDebitoToolStripMenuItem.Name = "NotasDeDebitoToolStripMenuItem"
        Me.NotasDeDebitoToolStripMenuItem.Size = New System.Drawing.Size(315, 26)
        Me.NotasDeDebitoToolStripMenuItem.Text = "Notas de Debito"
        '
        'DescuentosPorPeriodoYCantidadToolStripMenuItem
        '
        Me.DescuentosPorPeriodoYCantidadToolStripMenuItem.Name = "DescuentosPorPeriodoYCantidadToolStripMenuItem"
        Me.DescuentosPorPeriodoYCantidadToolStripMenuItem.Size = New System.Drawing.Size(315, 26)
        Me.DescuentosPorPeriodoYCantidadToolStripMenuItem.Text = "Descuentos Por Periodo y Cantidad"
        '
        'OfertasToolStripMenuItem
        '
        Me.OfertasToolStripMenuItem.Name = "OfertasToolStripMenuItem"
        Me.OfertasToolStripMenuItem.Size = New System.Drawing.Size(315, 26)
        Me.OfertasToolStripMenuItem.Text = "Ofertas"
        '
        'ComprasToolStripMenuItem
        '
        Me.ComprasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OrdenDeCompraToolStripMenuItem1, Me.FacturacionToolStripMenuItem2, Me.NotasDeCreditoToolStripMenuItem1, Me.NotasDeDebitoToolStripMenuItem1})
        Me.ComprasToolStripMenuItem.Name = "ComprasToolStripMenuItem"
        Me.ComprasToolStripMenuItem.Size = New System.Drawing.Size(80, 24)
        Me.ComprasToolStripMenuItem.Text = "Compras"
        Me.ComprasToolStripMenuItem.Visible = False
        '
        'OrdenDeCompraToolStripMenuItem1
        '
        Me.OrdenDeCompraToolStripMenuItem1.Name = "OrdenDeCompraToolStripMenuItem1"
        Me.OrdenDeCompraToolStripMenuItem1.Size = New System.Drawing.Size(203, 26)
        Me.OrdenDeCompraToolStripMenuItem1.Text = "Orden de Compra"
        '
        'FacturacionToolStripMenuItem2
        '
        Me.FacturacionToolStripMenuItem2.Name = "FacturacionToolStripMenuItem2"
        Me.FacturacionToolStripMenuItem2.Size = New System.Drawing.Size(203, 26)
        Me.FacturacionToolStripMenuItem2.Text = "Facturacion"
        '
        'NotasDeCreditoToolStripMenuItem1
        '
        Me.NotasDeCreditoToolStripMenuItem1.Name = "NotasDeCreditoToolStripMenuItem1"
        Me.NotasDeCreditoToolStripMenuItem1.Size = New System.Drawing.Size(203, 26)
        Me.NotasDeCreditoToolStripMenuItem1.Text = "Notas de Credito"
        '
        'NotasDeDebitoToolStripMenuItem1
        '
        Me.NotasDeDebitoToolStripMenuItem1.Name = "NotasDeDebitoToolStripMenuItem1"
        Me.NotasDeDebitoToolStripMenuItem1.Size = New System.Drawing.Size(203, 26)
        Me.NotasDeDebitoToolStripMenuItem1.Text = "Notas de Debito"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.AliceBlue
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(17, 17)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FacturacionToolStripMenuItem, Me.AdministrarToolStripMenuItem, Me.BodegaToolStripMenuItem, Me.LiquidacionesToolStripMenuItem, Me.ExportarToolStripMenuItem, Me.ReportesToolStripMenuItem, Me.InventarioToolStripMenuItem, Me.PlanillaToolStripMenuItem, Me.VentasToolStripMenuItem, Me.ToolStripMenuItem8, Me.ComprasToolStripMenuItem, Me.AcercaDeToolStripMenuItem, Me.CerrarSesionToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1473, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem9, Me.ToolStripMenuItem10, Me.ToolStripMenuItem11, Me.ToolStripMenuItem12, Me.ToolStripMenuItem13})
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(87, 24)
        Me.ToolStripMenuItem8.Text = "Inventario"
        Me.ToolStripMenuItem8.Visible = False
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(226, 26)
        Me.ToolStripMenuItem9.Text = "Manager de Articulos"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(226, 26)
        Me.ToolStripMenuItem10.Text = "Entradas"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(226, 26)
        Me.ToolStripMenuItem11.Text = "Salidas"
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(226, 26)
        Me.ToolStripMenuItem12.Text = "Traslados"
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(226, 26)
        Me.ToolStripMenuItem13.Text = "Bodegas"
        '
        'CerrarSesionToolStripMenuItem
        '
        Me.CerrarSesionToolStripMenuItem.Name = "CerrarSesionToolStripMenuItem"
        Me.CerrarSesionToolStripMenuItem.Size = New System.Drawing.Size(108, 24)
        Me.CerrarSesionToolStripMenuItem.Text = "Cerrar Sesion"
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BackgroundImage = Global.SincroCliente.My.Resources.Resources.Fondo
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1473, 607)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents LbL_Errorres As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Time_BorraError As System.Windows.Forms.Timer
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DetErrores As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents FacturacionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EstadoDeTransmisionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesDeCargaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteDeFacturasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UltimosConsecutivosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DescuentosFijosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InformacionDelClienteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DevolucionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DevolucionesPendientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EstadoComprobantesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AceptaRechazaFacturasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BodegaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteDeCargaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteDeDevolucionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CrearPedidoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChequearReporteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UbicacionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BodegaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DiseñarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents VerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RecepcionToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents AdministrarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AgentesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BodeguerosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmpresaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChoferesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RutasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UniversosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CambioInfoClienteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UsuariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CamionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientesModificadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LiquidacionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NuevaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GastosToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DepositosToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents BuscarFacturaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreditoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NuevaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents GastosToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents DepositosToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents RevisarDepositosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InformacionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InformacionAPickingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InformacionAEliverToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FaltantesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FaltanteSobranteLiquidacionChoferesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FaltanteSobranteLiquidacionAgentesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GruposToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GruposToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ControlToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConteoActivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CruzarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConteoRealizadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlanillaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NuevaToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents EmpleadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeduccionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SistemaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OrdenDeCompraToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FacturacionToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents NotasDeCreditoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NotasDeDebitoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DescuentosPorPeriodoYCantidadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OfertasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComprasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OrdenDeCompraToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents FacturacionToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents NotasDeCreditoToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents NotasDeDebitoToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents DesicionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MathHaciendaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem13 As ToolStripMenuItem
    Friend WithEvents LineasNuevasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LicenciasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChequeoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BancosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CerrarSesionToolStripMenuItem As ToolStripMenuItem
End Class
