Imports System.Data.SqlClient
Imports System.Data.Odbc

Public Class Class_VariablesGlobales

    'Almacena del RowIndex para saber a cual fila le coloca la respuesta de hcianeda
    Public Shared RoxIndexDGV As New Hashtable

    Public Shared obj_Validaconexion As New ValidaConexion

    Public Shared obj_SAP As New SAP_BUSSINES_ONE
       Public Shared oCompany As New SAPbobsCOM.Company ' si se genera una exepcion puede ser pro que el proyecto no esta complando en x86 posiblementeeste en AnyCPU en la propiedades del proyecto



    Public Shared RutaExcellPedidos As String
    Public Shared Patch_MR_SinPrcesar As String
    Public Shared Patch_MR_Procesadas As String

    'Public Shared RutaExcellPedidos As String = “C:\Users\Luis Roberto Bastos\Documents\pedidos\”
    Public Shared RutaFotosPlanilla As String

    Public Shared LimpiarGastoAgente As Boolean = True
    Public Shared LimpiarGastoChofer As Boolean = True

    Public Shared TotalLineas As Integer = 0
    Public Shared idInventario As String
    Public Shared DetalleCarga As String
    Public Shared Contador As Integer
    Public Shared ERRORES As String = ""
    Public Shared MisPropiedades As New Propiedades("", Admin_Depositos_Agentes)

    Public Shared VerDatosNube As String = ""

    Public Shared CREANDO_LIQ_AGENTE As Boolean = True
    Public Shared CREANDO_LIQ_CHOFER As Boolean = True
    Public Shared IMPRIMIENDO As String
    Public Shared Copias As Integer
    Public Shared LiquidacionRecuperada As String
    Public Shared Id_Usuario As String
    Public Shared Log_Usuario As String
    Public Shared IP As String
    Public Shared UsuarioWindows As String


    Public Shared CheqRC_Consecutivo As String
    Public Shared CheqRC_ItemCode As String
    Public Shared CheqRC_Descripcion As String
    Public Shared CheqRC_Cantidad As String
    Public Shared CheqRC_CodeBars As String
    Public Shared CheqRC_Bodega As String


    'Son de mis clases    
    Public Shared ConseRepDevoluciones As String = "0"


    'esto indica cuando es el chequeado de bodega el que esta entrando a la ventana Rutas-RepCarga 
    ' si esta en tru manda los datos a la ventana de chequeo por codigo de barras
    ' se pone en true en el menu PRINCIAL CHEQUEAR
    Public Shared ChequeadoBuscaRuta As Boolean = False


    'Son de mis clases


    Public Shared frmArticulos As Articulos
    Public Shared Ubicaciones_Modo As String
    ''' <summary>
    '''Obtener y enviar la cantidad de Filas de la cuadrícula de diseñar bodega
    ''' </summary>
    Public Shared WMS_Top_Filas As String
    ''' <summary>
    '''Obtener y enviar la cantidad de Columnas de la cuadrícula de diseñar bodega
    ''' </summary>
    Public Shared WMS_Top_Columnas As String
    ''' <summary>
    '''Obtener y enviar si se desea abrir otra bodega o cerrar el diseñador por completo
    ''' </summary>
    Public Shared WMS_Abrir_Bodega As Boolean
    ''' <summary>
    '''Obtener y enviar el código de la bodega seleccionada
    ''' </summary>
    Public Shared WMS_Codigo_Bodega As Integer


    Public Shared ClientesLlamadoDesde As String = ""
    Public Shared ArticulosLlamadoDesde As String = ""
    Public Shared LlamadoDesde As String = ""
    Public Shared ListaPedidoLlamadoDesde As String = ""
    Public Shared LlamadoDesdeControl As Boolean = False
    'Public Shared LlamadoDesdeConte As Boolean = False
    Public Shared LlamadoDesdefrmActualizaStocks As Boolean = False
    Public Shared LlamadoDesdeCruces As Boolean = False

    Public Shared ListaGruposLlamadoDesde As String

    Public Shared MiVariable As String
    Public Shared CodAgente As Integer = 2
    Public Shared backuoAgeEje As String
    Public Shared UserBod As String
    Public Shared CodArti As String
    Public Shared ConseRepCarga As String

    Public Shared FrmReporteFacturas As String

    Public Shared IDRepDev As String
    Public Shared Puesto As String
    Public Shared Usuario As String
    Public Shared TituloDetalleGasto As String
    Public Shared Conse_Repcarga As String
    Public Shared Conse_RepFacturas As String
    Public Shared Excepcion As Boolean = False

    Public Shared WMS_AdminUbicaciones_Codigo As String

    Public Shared LiquiAgente_ConseLiq As String
    Public Shared LiquiAgente_FechaIni As String
    Public Shared LiquiAgente_FechaFin As String
    Public Shared LiquiAgente_CodAgente As String

    Public Shared LiquiChoferes_ConseLiq As String
    Public Shared LiquiChoferes_FechaIni As String
    Public Shared LiquiChoferes_FechaFin As String
    Public Shared LiquiChoferes_FechaIni_Recibos As String
    Public Shared LiquiChoferes_FechaFin_Recibos As String
    'Public Shared LiquiChoferes_ConseRepFacturas As String
    Public Shared LiquiChoferes_CodAgente As String

    Public Shared ReporteFacturas_FacINI As String
    Public Shared ReporteFacturas_FacFIN As String
    Public Shared ReporteFacturas_Consecutivo As String

    Public Shared ReporteCarga_Consecutivo As String

    Public Shared Devolucion_DocNum As String
    'PARAMATROS DE CONEXION PROVENIENTES DE XML

    'PARAMETROS LICENCIA SINCRO SERVER
    Public Shared XML_LicenciaSincroServer As String
    Public Shared XML_LicenciaUserServer As String
    Public Shared XML_LicenciaPastwordServer As String

    'PARAMETROS LICENCIA SINCRO CLIENTE
    Public Shared XML_LicenciaSincroCliente As String
    Public Shared XML_LicenciaUserCliente As String
    Public Shared XML_LicenciaPastwordCliente As String

    'PARAMETROS SAP
    Public Shared XMLParamSAP_CompanyDB As String
    Public Shared XMLParamSAP_Password As String
    Public Shared XMLParamSAP_UserName As String
    Public Shared XMLParamSAP_Server As String
    Public Shared XMLParamSAP_DbUserName As String
    Public Shared XMLParamSAP_DbPassword As String
    Public Shared XMLParamSAP_LicenseServer As String

    'PARAMETROS SQL_Sic_Local_Web
    Public Shared XMLParamSQL_user As String
    Public Shared XMLParamSQL_clave As String
    Public Shared XMLParamSQL_dababase As String
    Public Shared XMLParamSQL_server As String

    'PARAMETROS FIREBIRD
    Public Shared XMLParamFIREBIRD_Dsn As String

    'PARAMETROS MYSQL
    Public Shared XMLParamMYSQL_Server As String
    Public Shared XMLParamMYSQL_MyDatabase As String
    Public Shared XMLParamMYSQL_myport As String
    Public Shared XMLParamMYSQL_userWEB As String
    Public Shared XMLParamMYSQL_claveWEB As String
    Public Shared XMLParamMYSQL_DsnWEB As String
    'PARAMETROS MYSQL _LOCAL
    Public Shared XMLParamMYSQL_Server_LOCAL As String
    Public Shared XMLParamMYSQL_MyDatabase_LOCAL As String
    Public Shared XMLParamMYSQL_myport_LOCAL As String
    Public Shared XMLParamMYSQL_userWEB_LOCAL As String
    Public Shared XMLParamMYSQL_claveWEB_LOCAL As String
    Public Shared XMLParamMYSQL_DsnWEB_LOCAL As String
    'PARAMETROS FTP
    Public Shared XMLParamFTP_Server As String
    Public Shared XMLParamFTP_user As String
    Public Shared XMLParamFTP_Password As String
    Public Shared XMLParamFTP_dirLocal As String
    'PARAMETROS FTP2
    Public Shared XMLParamFTP_Server2 As String
    Public Shared XMLParamFTP_user2 As String
    Public Shared XMLParamFTP_Password2 As String
    Public Shared XMLParamFTP_dirLocal2 As String

    'PARAMETROS CUENTAS
    Public Shared XMLParamCuentas_CashAccount As String
    Public Shared XMLParamCuentas_TransferAccountt As String
    Public Shared XMLParamCuentas_BancoPopular As String
    Public Shared XMLParamCuentas_BancoNacional As String
    Public Shared XMLParamCuentas_BancoCostaRica As String
    Public Shared XMLParamCuentas_BancoLaFise As String
    Public Shared XMLParamCuentas_BancoCoocique As String
    Public Shared XMLParamCuentas_BancoBCT As String
    Public Shared XMLParamCuentas_UsarBancosDeSAP As String


    Public Shared NumLiqui_Chofer As String
    Public Shared NumLiqui As String
    Public Shared TipoLiqui As String
    Public Shared Agente As String
    Public Shared Chofer As String
    Public Shared FechaIni As String
    Public Shared FechaFin As String
    Public Shared Lista_llamadaDesde As String
    Public Shared Gastos_llamadaDesde As String
    Public Shared LIQUIDANDO As String

    Public Shared Fac_Llamadas_Desde As String
    Public Shared RepFActurasUnidicado As Boolean = False
    'Public Shared frmLiqAge As Liquidacion_Agentes
    'Public Shared frmDetGastos As Detalle_Gastos
    'Public Shared frmDepos As Admin_Depositos



    Public Shared MYSQ_Comman As New OdbcCommand

    'Public Shared Obj_LiqAgentes As New Liquidacion_Agentes
    'Public Shared Obj_Creaarchivo As New CrearArchivo
    'Public Shared obj_FTP As New Class_FTP
    'Public Shared Obj_RepDCar As New ReportesDeCarga
    'Public Shared Obj_MAIL As New Class_MAIL
    'Public Shared Obj_Sonar As New Class_Sonar
    'Public Shared Obj_SQL_CONEXION As New CONEXION_TO_SQLSERVER
    'Public Shared Obj_Funciones_SQL As New Class_funcionesSQL
    'Public Shared Obj_Funciones_SQL As New Class_funcionesSQL
    Public Shared SQL_Comman1 As New SqlCommand
    'Public Shared Obj_SQL_CONEXION_CONEXION As New CONEXION_TO_SQLSERVER
    Public Shared Tbl_RepCarga As New DataTable
    Public Shared SQL_Comman, SQL_Comman2 As New SqlCommand
    'Public Shared Obj_Clas_XML As New Class_XML_Conexion
    'Public Shared Obj_Admin_Bodegueros As New Admin_Bodegueros
    'Public Shared Obj_Fecha As New FechaManager
    'Public Shared  oCompany As New SAPbobsCOM.Company
    Public Shared Obj_InforComputadora As New InforComputadora
    Public Shared Obj_Funciones_SQL As New Class_funcionesSQL
    Public Shared Obj_SQL_CONEXION As New CONEXION_TO_SQLSERVER
    Public Shared Obj_Funciones_MYSQL As New Class_Funciones_MYSQL
    Public Shared Obj_MySQL As New CONEXION_TO_MYSQL

    Public Shared LlamaListaChoferDesdeExportacion As Boolean = False


    Public Shared Entrar As Boolean = True
    Public Shared OrCom_ID As String
    Public Shared OrCom_NumDoc As String
    Public Shared OrCom_CardCode As String
    Public Shared OrCom_CardName As String
    Public Shared OrCom_ItemCode As String
    Public Shared OrCom_ItemName As String
    Public Shared OrCom_Fecha As String
    Public Shared OrCom_Alterno As String
    Public Shared OrCom_Emp As String
    Public Shared OrCom_Precio_Costo As String
    Public Shared OrCom_Venta_Unid As String
    Public Shared OrCom_Venta2_Unid As String
    Public Shared OrCom_Venta3_Unid As String
    Public Shared OrCom_Venta4_Unid As String
    Public Shared OrCom_Venta_Cjs As String
    Public Shared OrCom_Venta_Mont As String
    Public Shared OrCom_FIniVenta As String
    Public Shared OrCom_FFinVenta As String
    Public Shared OrCom_UGramaje As String
    Public Shared OrCom_DiasSinMoverse As String
    Public Shared OrCom_FechaUltimaCompra As String
    Public Shared OrCom_CodBarras As String
    Public Shared OrCom_Stock_Unidad As String
    Public Shared OrCom_Stock_Cjs As String
    Public Shared OrCom_PedidoXAgente As String
    Public Shared OrCom_Faltante As String
    Public Shared OrCom_Stock_Monto As String
    Public Shared OrCom_Stock_Dif As String
    Public Shared OrCom_Stock_Real As String
    Public Shared OrCom_Stock_RealCJS As String
    Public Shared OrCom_Stock_RealMonto As String
    Public Shared OrCom_Comprometido As String
    Public Shared OrCom_Comprometido_CJS As String
    Public Shared OrCom_Min As String
    Public Shared OrCom_Max As String
    Public Shared OrCom_Frecu As String
    Public Shared OrCom_Dias_Iv As String
    Public Shared OrCom_Pd_CJs As String
    Public Shared OrCom_Pd_Unid As String
    Public Shared OrCom_Pd_Total As String
    Public Shared OrCom_PromedioCompra As String
    Public Shared OrCom_PromedioVentaMes As String
    Public Shared OrCom_PromedioVentaDia As String
    Public Shared OrCom_Dias As String
    Public Shared OrCom_FCmp1 As String
    Public Shared OrCom_Cmp1 As String

    Public Shared OrCom_FCmp2 As String
    Public Shared OrCom_Cmp2 As String

    Public Shared OrCom_FCmp3 As String
    Public Shared OrCom_Cmp3 As String



    Public Shared CodChoferLiq As String
    Public Shared NomChoferLiq As String
    Public Shared NumLiqChoferLiq As String
    Public Shared CodAgenteLiq As String
    Public Shared NomAgenteLiq As String
    Public Shared NumLiqAgenteLiq As String
    Public Shared NumGastoBuscando As String
    Public Shared ConseGastoBuscando As String
    Public Shared NumDepBuscando As String
    Public Shared ConseDepBuscando As String


    Public Shared ConsecutivoRepFactura As String

    Public Shared ComprobanteACrear As String
    Public Shared VentanaComprobantesAbierta As Boolean = False


    Public Shared Desv_ItemCode As String
    Public Shared Desv_Descripcion As String
    Public Shared Desv_BodegaOrigen As String
    Public Shared Desv_Cantidad As String
    Public Shared Desv_Accion As String
    Public Shared Desv_CantMover As String
    Public Shared Desv_CodigoDestino As String
    Public Shared Desv_BodegaDestino As String
    Public Shared Desv_Consecutivo As String
    Public Shared Desv_Motivo As String

    Public Shared Obj_Conversion As New Unidad_A_Cajas


    '----------------------------------------------------------------------------------
    '--------------- DECLARACIONES DE FORMULARIO---------------------------------------
    '----------------------------------------------------------------------------------

    Public Shared Obj_RepDevoluciones As New ReporteDeDevoluciones
    Public Shared Obj_Creaarchivo As New CrearArchivo
    Public Shared obj_FTP As New Class_FTP
    Public Shared Obj_MAIL As New Class_MAIL
    Public Shared Obj_Sonar As New Class_Sonar
    Public Shared Obj_Clas_XML As New Class_XML_Conexion
    Public Shared Obj_Fecha As New FechaManager

    Public Shared Obj_DescFijos As New DescFijos
    Public Shared Obj_Reporte_Facturas As New Reporte_Facturas
    Public Shared Obj_RepDCar As New ReportesDeCarga
    Public Shared Obj_ChequearRepCarga As New ChequearRepCarga
    Public Shared Obj_Admin_Bodegueros As New Admin_Bodeguero
    Public Shared Obj_CantiChequeada As New CantiChequeada
    Public Shared Obj_ListaAgentes As New ListaAgentes

    Public Shared frmPrincipal As New Principal
    Public Shared frmEnviar_Info_Seller As New Enviar_Info_Seller

    Public Shared frmNotificacion_Cargando As New Notificacion_Cargando
    Public Shared frmDetalle_Gastos_Choferes As New Detalle_Gastos_Choferes

    Public Shared frmREPORTE_Choferes As Report_Faltantes_Choferes
    Public Shared frmREPORTE As Report_Faltantes

    Public Shared frmDescuentosFijos As DescFijos
    Public Shared frmDevolucionesPendientes As Devoluciones_Pendientes
    Public Shared frmDevoluciones As Devoluciones
    Public Shared Obj_LiqAgentes As New Liquidacion_Agentes
    Public Shared frmLiqChof As New Liquidacion_Choferes

    Public Shared frmLiqAge As New Liquidacion_Agentes

    Public Shared Obj_ReporteDeDevoluciones_Corregir As ReporteDeDevoluciones_Corregir

    Public Shared frmDetGastos_Choferes As New Detalle_Gastos_Choferes
    Public Shared frmDetGastos As New Detalle_Gastos

    Public Shared frmListaDetGastos As New Lista_Gastos

    Public Shared frmListaDetGastos_Choferes As New Lista_Gastos_Choferes

    Public Shared frmDeposAgente As New Admin_Depositos_Agentes
    Public Shared frmDeposChofer As New Admin_Depositos_Choferes
    Public Shared frmListaDepos As New Lista_Depositos
    Public Shared frmLista_Proveedores As New Lista_Proveedores
    Public Shared frmPedido_ListaPedidosGuardados As New Pedido_ListaPedidosGuardados

    Public Shared frmGastos_ListProveedores As New Gastos_ListProveedores

    Public Shared frmListaDeposChoferes As New Lista_Depositos_Choferes

    Public Shared frmPedido_VerDatosNube As New Pedido_VerDatosNube
    Public Shared frmEditaLinePedido As New Pedido_EditaLinea
    Public Shared frmCreaPedido_DetalleVenta As New Pedido_DetalleVenta
    Public Shared frmCreaPedido As New Pedido_Principal
    Public Shared frmRangoFechaOrdComp As New Pedido_RangoFechaOrdComp
    Public Shared frmNuevoConteo As New Inv_NuevoConteo
    Public Shared frmEmpleados As New Planilla_Empleados
    Public Shared frmPlanilla As New Planilla

    Public Shared frmDeduccionesAcreditaciones As New DeduccionesAcreditaciones

    Public Shared frmBuscaFactura As New BuscaFactura
    Public Shared frmBuscaMantenimiento_Camiones As New Admin_Mantenimiento_Camiones
    Public Shared frmAdmin_ClientesModificados As New Admin_ClientesModificados
    Public Shared frmLista_ClientesModificados As New Lista_ClientesModificados
    Public Shared frmLista_Admin_EstadoComprobantes As New Admin_EstadoComprobantes
    Public Shared frmLista_Admin_Acepta_Rechaza As New Acepta_Rechaza

    Public Shared frmLista_InfoMsjHacienda As New InfoMsjHacienda
    Public Shared frmLista_FE_Proveedores As New Acepta_Rechaza_Lista_Comprobantes
    Public Shared frmGruposConteo As New GruposConteo
    Public Shared frmListaInventarios As New Inv_ListaInventarios
    Public Shared frmDetConteXLinea As New Inv_DetConteXLinea
    Public Shared frmCruzar As New Inv_Cruzar
    Public Shared frmCroquisBodega As New WMS_CroquisBodega
    Public Shared frmMantenimientoBodegas As New WMS_MantenimientoBodegas
    Public Shared frmVerBodegas As New WMS_VerBodegas
    Public Shared frmStock_Manager As New Stock_Manager
    Public Shared frmFacturacion As New Facturacion
    Public Shared frmLista_Articulos As New Lista_Articulos

    Public Shared frmStock_Categorizaciones As New Stock_Categorizaciones
    Public Shared frmInv_ConteosRealizados As New Inv_ConteosRealizados
    Public Shared frmInv_Math_Hacienda As New Math_Hacienda

    Public Shared frmInv_WMS_LineaNueva As New WMS_LineaNueva
    Public Shared frmInv_MantenimientoLicencias As New MantenimientoLicencias
    Public Shared frmAdmin_Ubicaciones As New WMS_Admin_Ubicaciones
    Public Shared frmNivelesEnRack As New WMS_NivelesEnRack
    Public Shared frmControl As New Inv_Control
    Public Shared frmLista_GruposConteo As Inv_Lista_GruposConteo

    Public Shared frmWMS_PedidosChequeados As WMS_PedidosChequeados
    Public Shared frmWMS_PedidosChequeados_Detalle As WMS_PedidosChequeados_Detalle
    Public Shared frmWMS_BancosEssco As Admin_Bancos



End Class
