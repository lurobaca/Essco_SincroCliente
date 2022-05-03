'Imports System.Data.SqlClient
'Imports System.IO
'Imports System.Threading

'Public Class Enviar_Info_Deliver
'    Dim Servidor As Integer = 1
'    Public trd1 As Thread
'    Private Sub btn_Cambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cambiar.Click
'        Try
'            Label1.Visible = True
'            GroupBox7.Enabled = False
'            'Generar datos del agente y cargadrlos en el otro agente

'            If CBX_Param.Checked = True Then
'                ExportaParametros(Class_VariablesGlobales.SQL_Comman1, TextB_Agente1.Text, TextB_Agente2.Text)
'            End If

'            Carga_Inventario(Class_VariablesGlobales.SQL_Comman1, TextB_Agente1.Text, TextB_Agente2.Text)
'            Carga_Inventario(Class_VariablesGlobales.SQL_Comman1, TextB_Agente1.Text, TextB_Agente2.Text)
'            Carga_DeliverClientes(Class_VariablesGlobales.SQL_Comman1, TextB_Agente1.Text, TextB_Agente2.Text)
'            Carga_DeliverCxC(Class_VariablesGlobales.SQL_Comman1, TextB_Agente1.Text, TextB_Agente2.Text)
'            Carga_DeliverFacturas(Class_VariablesGlobales.SQL_Comman1, TextB_Agente1.Text, TextB_Agente2.Text)
'            Carga_Bancos(Class_VariablesGlobales.SQL_Comman1, TextB_Agente1.Text, TextB_Agente2.Text)
'            Carga_RazonNoVisita(Class_VariablesGlobales.SQL_Comman1, TextB_Agente1.Text, TextB_Agente2.Text)
'            Carga_UbiacionesCR(Class_VariablesGlobales.SQL_Comman1, TextB_Agente.Text, TextB_Agente.Text)

'            MessageBox.Show("Carga del agente Completa " & TextB_Agente1.Text, TextB_Agente2.Text)
'            TextB_Agente.Text = ""
'            TextB_Agente1.Text = ""
'            TextB_Agente2.Text = ""

'            CBX_Param.Checked = False
'            Label1.Visible = False
'            GroupBox7.Enabled = True

'        Catch ex As Exception
'            MessageBox.Show("[ " & Now & " ] ERROR EN btn_Cambiar_Click [ " & ex.Message & " ]")
'        End Try
'    End Sub


'    Public Function ExportaParametros(ByVal SQL_Comman1 As SqlCommand, ByVal Ruta As String, ByVal Ruta2 As String)
'        'OBTIENE LA INFORMACION DE CONFIGURACION
'        Dim TABLA As New DataTable
'        Dim Lineas As String
'        TABLA = Class_VariablesGlobales.Obj_Funciones_SQL.Obtiene_InfoConfiguracionChoferes(Class_VariablesGlobales.SQL_Comman2, Ruta)

'        Try
'            My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\parametros.mbg")
'        Catch ex As Exception

'        End Try


'        Dim CONT As Integer = 0
'        For Each row As DataRow In TABLA.Rows
'            Class_VariablesGlobales.Obj_Creaarchivo.Crear_in_ParamDeliver(TABLA, Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\parametros.mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta)
'            CONT += 1
'        Next
'        'CARGA EN FTO Y ENVIA CORREO 
'        If Class_VariablesGlobales.Obj_Creaarchivo.ObtieneTamanoFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\parametros.mbg") <> "0 Kb" Then
'            Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\parametros.mbg", "parametros.mbg", Ruta2, "Completo", Servidor)
'        End If

'    End Function
'    Public Sub Carga_RazonNoVisita(ByVal SQL_Comman1 As SqlCommand, ByVal Ruta As String, ByVal Ruta2 As String)
'        Try

'            Try
'                My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\RazonesNoVisita.mbg")
'            Catch ex As Exception

'            End Try


'            Class_VariablesGlobales.Obj_Creaarchivo.Eliminar(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\RazonesNoVisita.mbg")
'            Dim Tbl_Razones As New DataTable
'            Tbl_Razones = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneRazonesNoVisita(SQL_Comman1)
'            Class_VariablesGlobales.Obj_Creaarchivo.Crear_in_RazonesNoVisita(Tbl_Razones, Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\RazonesNoVisita.mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta)
'            If Class_VariablesGlobales.Obj_Creaarchivo.ObtieneTamanoFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\RazonesNoVisita.mbg") <> "0 Kb" Then
'                Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\RazonesNoVisita.mbg", "RazonesNoVisita.mbg", Ruta2, "Completo", Servidor)
'            End If

'            Tbl_Razones.Dispose()
'        Catch ex As Exception

'        End Try
'    End Sub
'    Public Sub Carga_Bancos(ByVal SQL_Comman1 As SqlCommand, ByVal Ruta As String, ByVal Ruta2 As String)
'        Try
'            Try
'                My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\bancos.mbg")
'            Catch ex As Exception

'            End Try


'            Class_VariablesGlobales.Obj_Creaarchivo.Eliminar(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\bancos.mbg")
'            Dim Tbl_Bancos As New DataTable
'            Tbl_Bancos = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneBancos(SQL_Comman1)
'            Class_VariablesGlobales.Obj_Creaarchivo.Crear_InBancos(Tbl_Bancos, Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\bancos.mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta)
'            If Class_VariablesGlobales.Obj_Creaarchivo.ObtieneTamanoFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\bancos.mbg") <> "0 Kb" Then
'                Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\bancos.mbg", "bancos.mbg", Ruta2, "Completo", Servidor)
'            End If

'            Tbl_Bancos.Dispose()
'        Catch ex As Exception

'        End Try
'    End Sub
'    Public Function Carga_Inventario(ByVal SQL_Comman1 As SqlCommand, ByVal Ruta As String, ByVal Ruta2 As String)
'        Try
'            Try
'                My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\inventario.mbg")
'            Catch ex As Exception

'            End Try


'            Class_VariablesGlobales.Obj_Creaarchivo.Eliminar(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\inventario.mbg")


'            Dim Tabla As New DataTable
'            Dim Tbl_Art_Restringidos As New DataTable
'            Dim Tbl_Art_PermitidosDeCasasRestringidas As New DataTable

'            'CONSULTA DATOS DE ARTICULOS 
'            Tabla = (Class_VariablesGlobales.Obj_Funciones_SQL.Articulos_Mobile(Tabla, SQL_Comman1))
'            'CONSULTA LAS LINEAS RESTRINGIDAS
'            Tbl_Art_Restringidos = Class_VariablesGlobales.Obj_Funciones_SQL.ArticulosRestringidos_Mobile(Ruta, Tbl_Art_Restringidos, SQL_Comman1)
'            'CONSULTA LAS LINEAS PERMITIDAS DE LAS CASAS RESTRINGIDAS
'            Tbl_Art_PermitidosDeCasasRestringidas = Class_VariablesGlobales.Obj_Funciones_SQL.ArticulosPermitidosDeCasaRestringida(Ruta, Tbl_Art_PermitidosDeCasasRestringidas, SQL_Comman1)

'            Class_VariablesGlobales.Obj_Creaarchivo.Crear(Tabla, Tbl_Art_Restringidos, Tbl_Art_PermitidosDeCasasRestringidas, Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\inventario.mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta)

'            'CARGA EN FTO Y ENVIA CORREO 
'            Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\inventario.mbg", "inventario.mbg", Ruta2, "Completo", Servidor)

'            Tabla.Dispose()
'            Tabla.Clear()
'            Tabla = Nothing

'            Tbl_Art_Restringidos.Dispose()
'            Tbl_Art_Restringidos.Clear()
'            Tbl_Art_Restringidos = Nothing

'            Tbl_Art_PermitidosDeCasasRestringidas.Dispose()
'            Tbl_Art_PermitidosDeCasasRestringidas.Clear()
'            Tbl_Art_PermitidosDeCasasRestringidas = Nothing


'        Catch ex As Exception

'        End Try
'    End Function

'    Public Sub Carga_UbiacionesCR(ByVal SQL_Comman1 As SqlCommand, ByVal Ruta As String, ByVal Ruta2 As String)
'        Try
'            Try
'                My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\ubicacionescr.mbg")
'            Catch ex As Exception

'            End Try
'            Class_VariablesGlobales.Obj_Creaarchivo.Eliminar(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\ubicacionescr.mbg")

'            Dim Tbl_Ubicaciones As New DataTable
'            Tbl_Ubicaciones = Class_VariablesGlobales.Obj_Funciones_SQL.Obtiene_UbicacionesCR(SQL_Comman1)
'            Class_VariablesGlobales.Obj_Creaarchivo.Crear_InUbicaciones(Tbl_Ubicaciones, Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\ubicacionescr.mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta)
'            If Class_VariablesGlobales.Obj_Creaarchivo.ObtieneTamanoFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\ubicacionescr.mbg") <> "0 Kb" Then
'                Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\ubicacionescr.mbg", "ubicacionescr.mbg", Ruta2, "Completo", Servidor)
'            End If

'            Tbl_Ubicaciones.Dispose()
'        Catch ex As Exception

'        End Try
'    End Sub
'    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged

'        Servidor = 1
'    End Sub

'    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged

'        Servidor = 2
'    End Sub

'    Private Sub btn_ExpoInfo_Click(sender As Object, e As EventArgs) Handles btn_ExpoInfo.Click
'        'Debe cargar Facturas,cxc y clientes segun el reporte de facturas
'        'Debe montrar las lineas que lleva la facturas por lo que el inventario es el que lleven las facturas 
'        'Debe monstrar solo las lineas de la factura seleccionada
'        'Debe montrar los clientes que llevan en las facturas
'        'Debe montrar solo las facturas que lleva de cada cliente para hacerle el recibo

'        Try
'            Label1.Visible = True
'            GroupBox7.Enabled = False
'            'hilo de ejecucion constante
'            trd1 = New Thread(AddressOf FuncionEn_BackGroud)
'            trd1.IsBackground = Enabled
'            'trd2.Priority = ThreadPriority.Highest
'            CheckForIllegalCrossThreadCalls = False
'            trd1.Start()

'        Catch ex As Exception
'            MessageBox.Show("[ " & Now & " ] ERROR EN btn_ExpoInfo_Click [ " & ex.Message & " ]")
'        End Try



'    End Sub

'    Public Function FuncionEn_BackGroud()

'        Try
'            If CBX_Param.Checked = True Then
'                ExportaParametros(Class_VariablesGlobales.SQL_Comman1, TextB_Agente1.Text, TextB_Agente2.Text)
'                Carga_Bancos(Class_VariablesGlobales.SQL_Comman1, TextB_Agente1.Text, TextB_Agente2.Text)
'                Carga_RazonNoVisita(Class_VariablesGlobales.SQL_Comman1, TextB_Agente1.Text, TextB_Agente2.Text)
'            End If

'            Carga_Inventario(Class_VariablesGlobales.SQL_Comman1, TextB_Agente1.Text, TextB_Agente2.Text)
'            Carga_DeliverClientes(Class_VariablesGlobales.SQL_Comman1, TextB_Agente1.Text, TextB_Agente2.Text)
'            Carga_DeliverCxC(Class_VariablesGlobales.SQL_Comman1, TextB_Agente1.Text, TextB_Agente2.Text)
'            Carga_DeliverFacturas(Class_VariablesGlobales.SQL_Comman1, TextB_Agente1.Text, TextB_Agente2.Text)

'            Label1.Visible = False
'            GroupBox7.Enabled = True
'            TextB_Agente.Text = ""
'            DTP_Fecha.Value = Now.Date
'            MessageBox.Show("Carga del Chofer Completa " & TextB_Agente.Text, TextB_Agente.Text)
'        Catch ex As Exception
'            MessageBox.Show("ERROR al cargar info al Chofer [" & ex.Message & "]" & TextB_Agente.Text, TextB_Agente.Text)
'        End Try
'    End Function


'    Public Sub Carga_DeliverClientes(ByVal SQL_Comman1 As SqlCommand, ByVal Ruta As String, ByVal Ruta2 As String)
'        Try
'            Dim Tabla_Universo As New DataTable
'            Tabla_Universo = Class_VariablesGlobales.Obj_Funciones_SQL.Obtiene_Universo_Chofer_X_RepFactura(Class_VariablesGlobales.SQL_Comman1, Ruta, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(String.Format(DTP_Fecha.Value, "yyyy-MM-dd")))
'            If File.Exists(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\clientes.mbg") Then
'                My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\clientes.mbg")
'            End If
'            Class_VariablesGlobales.Obj_Creaarchivo.Crear_InClientes(Tabla_Universo, Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\clientes.mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta, False)
'            Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\clientes.mbg", "clientes.mbg", Ruta2, "Completo", Servidor)


'        Catch ex As Exception

'        End Try
'    End Sub
'    Public Sub Carga_DeliverCxC(ByVal SQL_Comman1 As SqlCommand, ByVal Ruta As String, ByVal Ruta2 As String)
'        Try
'            Dim Tabla_CxC As New DataTable
'            Tabla_CxC = Class_VariablesGlobales.Obj_Funciones_SQL.Obtiene_cxc_ExportaChoferes(Class_VariablesGlobales.SQL_Comman1, Ruta, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(String.Format(DTP_Fecha.Value, "yyyy-MM-dd")))
'            If File.Exists(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\cxc.mbg") Then
'                My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\cxc.mbg")
'            End If

'            Class_VariablesGlobales.Obj_Creaarchivo.Crear_Cxc_Choferes(Tabla_CxC, Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\cxc.mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta, Ruta)
'            Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\cxc.mbg", "cxc.mbg", Ruta2, "Completo", Servidor)


'        Catch ex As Exception

'        End Try
'    End Sub
'    Public Sub Carga_DeliverFacturas(ByVal SQL_Comman1 As SqlCommand, ByVal Ruta As String, ByVal Ruta2 As String)
'        Try
'            Dim tbl_Facturas As New DataTable
'            tbl_Facturas = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneFacturas(Class_VariablesGlobales.SQL_Comman1, Ruta, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(String.Format(DTP_Fecha.Value, "yyyy-MM-dd")))

'            If File.Exists(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\Facturas.mbg") Then
'                My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\Facturas.mbg")
'            End If


'            Class_VariablesGlobales.Obj_Creaarchivo.Crear_InFacturass(tbl_Facturas, Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\Facturas.mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta, False)
'            Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\Facturas.mbg", "Facturas.mbg", Ruta2, "Completo", Servidor)

'        Catch ex As Exception

'        End Try
'    End Sub
'End Class