Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading

Public Class Enviar_Info_Seller

#Region "FUNCIONES CARGA CLIENTES,CXC,PARAMETROS"
    Public Servidor As Integer = 1
    Public trd1 As Thread

    Public Sub Carga_RazonNoVisita(ByVal SQL_Comman1 As SqlCommand, ByVal Ruta As String, ByVal Ruta2 As String)
        Try

            Try
                My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\RazonesNoVisita.mbg")
            Catch ex As Exception

            End Try


            Class_VariablesGlobales.Obj_Creaarchivo.Eliminar(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\RazonesNoVisita.mbg")
            Dim Tbl_Razones As New DataTable
            Tbl_Razones = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneRazonesNoVisita(SQL_Comman1)
            Class_VariablesGlobales.Obj_Creaarchivo.Crear_in_RazonesNoVisita(Tbl_Razones, Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\RazonesNoVisita.mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta)
            If Class_VariablesGlobales.Obj_Creaarchivo.ObtieneTamanoFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\RazonesNoVisita.mbg") <> "0 Kb" Then
                Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\RazonesNoVisita.mbg", "RazonesNoVisita.mbg", Ruta2, "Completo", Servidor)
            End If

            Tbl_Razones.Dispose()
        Catch ex As Exception

        End Try
    End Sub



    Public Sub Carga_Licencia(ByVal SQL_Comman1 As SqlCommand, ByVal Ruta As String, ByVal Ruta2 As String)
        Try
            Try
                My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\Licencia.mbg")
            Catch ex As Exception

            End Try

            Class_VariablesGlobales.Obj_Creaarchivo.Eliminar(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\Licencia.mbg")
            Dim Tbl_Licencia As New DataTable


            Tbl_Licencia = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLicencia(SQL_Comman1)


            Class_VariablesGlobales.Obj_Creaarchivo.Crear_InLicencia(Tbl_Licencia, Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\Licencia.mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta)
            If Class_VariablesGlobales.Obj_Creaarchivo.ObtieneTamanoFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\Licencia.mbg") <> "0 Kb" Then
                Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\Licencia.mbg", "Licencia.mbg", Ruta2, "Completo", Servidor)
            End If

            Tbl_Licencia.Dispose()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Carga_Bancos(ByVal SQL_Comman1 As SqlCommand, ByVal Ruta As String, ByVal Ruta2 As String)
        Try
            Try
                My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\bancos.mbg")
            Catch ex As Exception

            End Try

            Class_VariablesGlobales.Obj_Creaarchivo.Eliminar(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\bancos.mbg")
            Dim Tbl_Bancos As New DataTable

            If Class_VariablesGlobales.XMLParamCuentas_UsarBancosDeSAP = "SI" Then
                Tbl_Bancos = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneBancos(SQL_Comman1)
            Else
                Tbl_Bancos = (Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneBancosEssco(Class_VariablesGlobales.SQL_Comman2))
            End If

            Class_VariablesGlobales.Obj_Creaarchivo.Crear_InBancos(Tbl_Bancos, Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\bancos.mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta)
            If Class_VariablesGlobales.Obj_Creaarchivo.ObtieneTamanoFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\bancos.mbg") <> "0 Kb" Then
                Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\bancos.mbg", "bancos.mbg", Ruta2, "Completo", Servidor)
            End If

            Tbl_Bancos.Dispose()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Carga_Descuentos(ByVal SQL_Comman1 As SqlCommand, ByVal Ruta As String, ByVal Ruta2 As String, Rutas_Unidicar() As String)
        Try
            Try
                If Rutas_Unidicar Is Nothing Then



                    Class_VariablesGlobales.Obj_Creaarchivo.Eliminar(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\Descuentos.mbg")
                Else
                    'Carga varias rutas a una sola
                    For i As Integer = 0 To Rutas_Unidicar.Count - 1
                        Class_VariablesGlobales.Obj_Creaarchivo.Eliminar(Class_VariablesGlobales.XMLParamFTP_dirLocal & Rutas_Unidicar(i).ToString & "\Descuentos.mbg")
                    Next
                End If
            Catch ex As Exception

            End Try

            'OJO VER POR QUE SE DUPLICA LA INFORMACION DE LOS DESCUENTOS
            'DEBE SER POR QUE AL CAMBIAR LOS DESCUENTOS O NO SE BORRA EL ARCHIVO O SE RECORRE DOBLE
            Dim Tbl_Descuentos As New DataTable
            Tbl_Descuentos = Class_VariablesGlobales.Obj_Funciones_SQL.Obtiene_Descuentos(SQL_Comman1, Ruta2, Rutas_Unidicar)
            Class_VariablesGlobales.Obj_Creaarchivo.Crear_InDescuentos(Tbl_Descuentos, Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\Descuentos.mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2)
            If Class_VariablesGlobales.Obj_Creaarchivo.ObtieneTamanoFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\Descuentos.mbg") <> "0 Kb" Then
                Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\Descuentos.mbg", "Descuentos.mbg", Ruta2, "Completo", Servidor)
            End If


            Tbl_Descuentos.Dispose()




        Catch ex As Exception

        End Try
    End Sub
    Public Sub Carga_Clientes_Y_CXC(ByVal SQL_Comman1 As SqlCommand, ByVal Ruta As String, ByVal Ruta2 As String, ByVal VerDias As Boolean, Rutas_Unidicar() As String)

        Try
            If Rutas_Unidicar Is Nothing Then


                Class_VariablesGlobales.Obj_Creaarchivo.Eliminar(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\clientes.mbg")
                Class_VariablesGlobales.Obj_Creaarchivo.Eliminar(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\cxc.mbg")


            Else
                For i As Integer = 0 To Rutas_Unidicar.Count - 1
                    Class_VariablesGlobales.Obj_Creaarchivo.Eliminar(Class_VariablesGlobales.XMLParamFTP_dirLocal & Rutas_Unidicar(i).ToString & "\clientes.mbg")
                    Class_VariablesGlobales.Obj_Creaarchivo.Eliminar(Class_VariablesGlobales.XMLParamFTP_dirLocal & Rutas_Unidicar(i).ToString & "\cxc.mbg")
                Next
            End If


            Class_VariablesGlobales.Obj_Creaarchivo.Eliminar(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\clientes.mbg")
            Dim Tbl_Clientes As New DataTable
            'CONSULTA Los clientes

            Tbl_Clientes = Class_VariablesGlobales.Obj_Funciones_SQL.Obtieneclientes_X_Agente(txb_Grupo.Text, Ruta2, Tbl_Clientes, Rutas_Unidicar, SQL_Comman1)
            Try
                My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\clientes.mbg")
            Catch ex As Exception

            End Try

            'SI TIENE MARCADO EL CHECH DE CLIENTES CARGA LA INFO
            If Cbox_Clientes.Checked = True Then
                Class_VariablesGlobales.Obj_Creaarchivo.Crear_InClientes(Tbl_Clientes, Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\clientes.mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2, VerDias)
                'CARGA EN FTP Y ENVIA CORREO 
                If Class_VariablesGlobales.Obj_Creaarchivo.ObtieneTamanoFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\clientes.mbg") <> "0 Kb" Then
                    Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\clientes.mbg", "clientes.mbg", Ruta2, "Completo", Servidor)
                End If
            End If

            'SI TIENE MARCADO O NO EL CHECH DE CXC eliminar el archivo de cxc de destino
            Try
                My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\cxc.mbg")
            Catch ex As Exception
            End Try
            'Si lo tiene marcado obtiene la info y genera el archivo cxc
            If Cbox_Cxc.Checked = True Then
                Class_VariablesGlobales.Obj_Creaarchivo.Crear_InCxc(Tbl_Clientes, Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\cxc.mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2, Ruta2, Rutas_Unidicar, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(String.Format(DTP_FechaDesde.Value, "yyyy-MM-dd")), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(String.Format(DTP_FechaHasta.Value, "yyyy-MM-dd")))
            Else
                'Crea el archivo en blanco
                Dim strStreamW As Stream = Nothing
                Dim strStreamWriter As StreamWriter = Nothing
                strStreamW = File.Create(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\cxc.mbg") ' lo creamos
                strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura
                strStreamWriter.Close() ' cerramos
                strStreamWriter = Nothing
                strStreamW = Nothing
                'sube el archivo vacido
                Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\cxc.mbg", "cxc.mbg", Ruta2, "Completo", Servidor)

            End If

            'CARGA EN FTP Y ENVIA CORREO 
            If Class_VariablesGlobales.Obj_Creaarchivo.ObtieneTamanoFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\cxc.mbg") <> "0 Kb" Then
                Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\cxc.mbg", "cxc.mbg", Ruta2, "Completo", Servidor)
            End If

            Tbl_Clientes.Dispose()
            Tbl_Clientes.Clear()
            Tbl_Clientes = Nothing

        Catch ex As Exception

        End Try
    End Sub
    Public Function ExportaParametros(ByVal SQL_Comman1 As SqlCommand, ByVal Ruta As String, ByVal Ruta2 As String)
        'OBTIENE LA INFORMACION DE CONFIGURACION
        Dim TABLA As New DataTable
        Dim Lineas As String
        TABLA = Class_VariablesGlobales.Obj_Funciones_SQL.Obtiene_InfoConfiguracion(Class_VariablesGlobales.SQL_Comman2, Ruta)

        Try
            My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\parametros.mbg")
        Catch ex As Exception

        End Try


        Dim CONT As Integer = 0
        For Each row As DataRow In TABLA.Rows
            Class_VariablesGlobales.Obj_Creaarchivo.Crear_in_ParamSeller(TABLA, Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\parametros.mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta)
            CONT += 1
        Next
        'CARGA EN FTO Y ENVIA CORREO 
        If Class_VariablesGlobales.Obj_Creaarchivo.ObtieneTamanoFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\parametros.mbg") <> "0 Kb" Then
            Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\parametros.mbg", "parametros.mbg", Ruta2, "Completo", Servidor)
        End If

    End Function
    Public Sub Carga_UbiacionesCR(ByVal SQL_Comman1 As SqlCommand, ByVal Ruta As String, ByVal Ruta2 As String)
        Try
            Try
                My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\ubicacionescr.mbg")
            Catch ex As Exception

            End Try
            Class_VariablesGlobales.Obj_Creaarchivo.Eliminar(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\ubicacionescr.mbg")

            Dim Tbl_Ubicaciones As New DataTable
            Tbl_Ubicaciones = Class_VariablesGlobales.Obj_Funciones_SQL.Obtiene_UbicacionesCR(SQL_Comman1)
            Class_VariablesGlobales.Obj_Creaarchivo.Crear_InUbicaciones(Tbl_Ubicaciones, Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\ubicacionescr.mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta)
            If Class_VariablesGlobales.Obj_Creaarchivo.ObtieneTamanoFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\ubicacionescr.mbg") <> "0 Kb" Then
                Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\ubicacionescr.mbg", "ubicacionescr.mbg", Ruta2, "Completo", Servidor)
            End If

            Tbl_Ubicaciones.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Function Carga_Inventario(ByVal SQL_Comman1 As SqlCommand, ByVal Ruta As String, ByVal Ruta2 As String)
        Try
            Try
                My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\inventario1.mbg")
            Catch ex As Exception

            End Try


            Class_VariablesGlobales.Obj_Creaarchivo.Eliminar(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\inventario1.mbg")


            Dim Tabla As New DataTable
            Dim Tbl_Art_Restringidos As New DataTable
            Dim Tbl_Art_PermitidosDeCasasRestringidas As New DataTable

            'CONSULTA DATOS DE ARTICULOS 
            Tabla = (Class_VariablesGlobales.Obj_Funciones_SQL.Articulos_Mobile(Tabla, SQL_Comman1))
            'CONSULTA LAS LINEAS RESTRINGIDAS
            Tbl_Art_Restringidos = Class_VariablesGlobales.Obj_Funciones_SQL.ArticulosRestringidos_Mobile(Ruta, Tbl_Art_Restringidos, SQL_Comman1)
            'CONSULTA LAS LINEAS PERMITIDAS DE LAS CASAS RESTRINGIDAS
            Tbl_Art_PermitidosDeCasasRestringidas = Class_VariablesGlobales.Obj_Funciones_SQL.ArticulosPermitidosDeCasaRestringida(Ruta, Tbl_Art_PermitidosDeCasasRestringidas, SQL_Comman1)

            Class_VariablesGlobales.Obj_Creaarchivo.Crear(Tabla,
                                                          Tbl_Art_Restringidos,
                                                          Tbl_Art_PermitidosDeCasasRestringidas,
                                                          Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\inventario1.mbg",
                                                          Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta,
                                                          Ruta)

            'CARGA EN FTO Y ENVIA CORREO 
            Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\inventario1.mbg", "inventario1.mbg", Ruta, "Completo", Servidor)

            Tabla.Dispose()
            Tabla.Clear()
            Tabla = Nothing

            Tbl_Art_Restringidos.Dispose()
            Tbl_Art_Restringidos.Clear()
            Tbl_Art_Restringidos = Nothing

            Tbl_Art_PermitidosDeCasasRestringidas.Dispose()
            Tbl_Art_PermitidosDeCasasRestringidas.Clear()
            Tbl_Art_PermitidosDeCasasRestringidas = Nothing


        Catch ex As Exception

        End Try
    End Function

    Public Sub Carga_DeliverClientes(ByVal SQL_Comman1 As SqlCommand, ByVal Ruta As String, ByVal Ruta2 As String, Rutas_Unidicar() As String)
        Try
            Dim Tabla_Universo As New DataTable
            Tabla_Universo = Class_VariablesGlobales.Obj_Funciones_SQL.Obtiene_Universo_Chofer_X_RepFactura(Class_VariablesGlobales.SQL_Comman1, Ruta, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(String.Format(DTP_FechaDesde.Value, "yyyy-MM-dd")), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(String.Format(DTP_FechaHasta.Value, "yyyy-MM-dd")), Rutas_Unidicar)


            If File.Exists(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\clientes.mbg") Then
                    My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\clientes.mbg")
                End If


                If Rutas_Unidicar IsNot Nothing Then
                    For i As Integer = 0 To Rutas_Unidicar.Count - 1
                        If File.Exists(Class_VariablesGlobales.XMLParamFTP_dirLocal & Rutas_Unidicar(i).ToString & "\clientes.mbg") Then
                            My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Rutas_Unidicar(i).ToString & "\clientes.mbg")
                        End If
                    Next
                End If




                Class_VariablesGlobales.Obj_Creaarchivo.Crear_InClientes(Tabla_Universo, Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\clientes.mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta, False)
            Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\clientes.mbg", "clientes.mbg", Ruta2, "Completo", Servidor)


        Catch ex As Exception

        End Try
    End Sub
    Public Sub Carga_DeliverCxC(ByVal SQL_Comman1 As SqlCommand, ByVal Ruta As String, ByVal Ruta2 As String, Rutas_Unidicar() As String)
        Try
            Dim Tabla_CxC As New DataTable
            Tabla_CxC = Class_VariablesGlobales.Obj_Funciones_SQL.Obtiene_cxc_ExportaChoferes(Class_VariablesGlobales.SQL_Comman1, Ruta2, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(String.Format(DTP_FechaDesde.Value, "yyyy-MM-dd")), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(String.Format(DTP_FechaHasta.Value, "yyyy-MM-dd")), Rutas_Unidicar)


            If File.Exists(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\cxc.mbg") Then
                    My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta & "\cxc.mbg")
                End If
                If Rutas_Unidicar IsNot Nothing Then
                    For i As Integer = 0 To Rutas_Unidicar.Count - 1
                        If File.Exists(Class_VariablesGlobales.XMLParamFTP_dirLocal & Rutas_Unidicar(i).ToString & "\cxc.mbg") Then
                            My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Rutas_Unidicar(i).ToString & "\cxc.mbg")
                        End If
                    Next
                End If
                Class_VariablesGlobales.Obj_Creaarchivo.Crear_Cxc_Choferes(Tabla_CxC, Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\cxc.mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2, Ruta2)
            Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\cxc.mbg", "cxc.mbg", Ruta2, "Completo", Servidor)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Carga_DeliverFacturas(ByVal SQL_Comman1 As SqlCommand, ByVal Ruta As String, ByVal Ruta2 As String, Rutas_Unidicar() As String)
        Try
            Dim tbl_Facturas As New DataTable
            tbl_Facturas = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneFacturas(Class_VariablesGlobales.SQL_Comman1, Ruta2, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(String.Format(DTP_FechaDesde.Value, "yyyy-MM-dd")), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(String.Format(DTP_FechaHasta.Value, "yyyy-MM-dd")), Rutas_Unidicar)

            If File.Exists(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\Facturas.mbg") Then
                    My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\Facturas.mbg")
                End If

            If Rutas_Unidicar IsNot Nothing Then

                For i As Integer = 0 To Rutas_Unidicar.Count - 1
                    If File.Exists(Class_VariablesGlobales.XMLParamFTP_dirLocal & Rutas_Unidicar(i).ToString & "\Facturas.mbg") Then
                        My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & Rutas_Unidicar(i).ToString & "\Facturas.mbg")
                    End If
                Next
            End If


            Class_VariablesGlobales.Obj_Creaarchivo.Crear_InFacturass(tbl_Facturas, Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\Facturas.mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2, False)
            Class_VariablesGlobales.Obj_Creaarchivo.Subir_A_FTP(Class_VariablesGlobales.XMLParamFTP_dirLocal & Ruta2 & "\Facturas.mbg", "Facturas.mbg", Ruta2, "Completo", Servidor)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub btn_Cambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cambiar.Click
        Label1.Visible = True
        GroupBox7.Enabled = False
        Dim RutasOrigen As String

        Dim Rutas_Unidicar(Class_VariablesGlobales.frmEnviar_Info_Seller.ListV_Reportes.Items.Count - 1) As String
        'Recorre el list box para obtener todas las runas que unificara 
        For x = 0 To Class_VariablesGlobales.frmEnviar_Info_Seller.ListV_Reportes.Items.Count - 1

            Rutas_Unidicar(x) = Class_VariablesGlobales.frmEnviar_Info_Seller.ListV_Reportes.Items(x).Text
            RutasOrigen = RutasOrigen & "-" & Class_VariablesGlobales.frmEnviar_Info_Seller.ListV_Reportes.Items(x).Text
        Next



        If CBox_VERPuestos.Text = "AGENTE" Then
            Carga_Clientes_Y_CXC(Class_VariablesGlobales.SQL_Comman1, TextB_Agente1.Text, TextB_Agente2.Text, ChBox_ClientexDia.Checked, Rutas_Unidicar)
            Carga_Descuentos(Class_VariablesGlobales.SQL_Comman1, TextB_Agente1.Text, TextB_Agente2.Text, Rutas_Unidicar)
        Else
            If Cbox_Clientes.Checked = True Then
                Carga_DeliverClientes(Class_VariablesGlobales.SQL_Comman1, TextB_Agente1.Text, TextB_Agente2.Text, Rutas_Unidicar)
            End If

            If Cbox_Cxc.Checked = True Then
                Carga_DeliverCxC(Class_VariablesGlobales.SQL_Comman1, TextB_Agente1.Text, TextB_Agente2.Text, Rutas_Unidicar)
            End If
            If Cbox_Facturas.Checked = True Then
                Carga_DeliverFacturas(Class_VariablesGlobales.SQL_Comman1, TextB_Agente1.Text, TextB_Agente2.Text, Rutas_Unidicar)
            End If


        End If


        'Generar datos del agente y cargadrlos en el otro agente

        Carga_Inventario(Class_VariablesGlobales.SQL_Comman1, TextB_Agente2.Text, TextB_Agente2.Text)
        Carga_Licencia(Class_VariablesGlobales.SQL_Comman1, TextB_Agente2.Text, TextB_Agente2.Text)

        If Cbox_Bancos.Checked = True Then
            Carga_Bancos(Class_VariablesGlobales.SQL_Comman1, TextB_Agente2.Text, TextB_Agente2.Text)
        End If
        If Cbox_Razones.Checked = True Then
            Carga_RazonNoVisita(Class_VariablesGlobales.SQL_Comman1, TextB_Agente2.Text, TextB_Agente2.Text)
        End If
        If Cbox_Ubicaciones.Checked = True Then
            Carga_UbiacionesCR(Class_VariablesGlobales.SQL_Comman1, TextB_Agente2.Text, TextB_Agente2.Text)
        End If

        If CBX_Param.Checked = True Then
            ExportaParametros(Class_VariablesGlobales.SQL_Comman1, Rutas_Unidicar(0).ToString, TextB_Agente2.Text)
        End If

        MessageBox.Show("Las Rutas " & RutasOrigen & " se cargaron a la ruta " & TextB_Agente2.Text & " Correctamente")
        TextB_Agente.Text = ""
        TextB_Agente1.Text = ""
        TextB_Agente2.Text = ""
        txb_Grupo.Text = ""
        CBX_Param.Checked = False
        cbx_CatalogoDivido.Checked = False

        For x = 0 To ListV_Reportes.Items.Count - 1

            ListV_Reportes.Items.RemoveByKey(x)
        Next

        Label1.Visible = False
        GroupBox7.Enabled = True

    End Sub
    Private Sub btn_ExpoInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ExpoInfo.Click

        Try
            If TextB_Agente.Text <> "" Then
                Label1.Visible = True
                GroupBox7.Enabled = False
                'hilo de ejecucion constante
                trd1 = New Thread(AddressOf FuncionEn_BackGroud)
                trd1.IsBackground = Enabled
                'trd2.Priority = ThreadPriority.Highest
                CheckForIllegalCrossThreadCalls = False
                trd1.Start()
            Else
                MessageBox.Show("Debe indicar una ruta a cargar")
            End If
        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN btn_ExpoInfo_Click [ " & ex.Message & " ]")
        End Try
    End Sub

    Public Function FuncionEn_BackGroud()
        Try

            Dim Rutas_Unidicar() As String

            If CBox_VERPuestos.Text = "AGENTE" Then
                Carga_Clientes_Y_CXC(Class_VariablesGlobales.SQL_Comman1, TextB_Agente.Text, TextB_Agente.Text, ChBox_ClientexDia.Checked, Rutas_Unidicar)
                Carga_Descuentos(Class_VariablesGlobales.SQL_Comman1, TextB_Agente.Text, TextB_Agente.Text, Rutas_Unidicar)

            Else
                'CHOFER
                Carga_DeliverClientes(Class_VariablesGlobales.SQL_Comman1, TextB_Agente.Text, TextB_Agente.Text, Rutas_Unidicar)
                Carga_DeliverCxC(Class_VariablesGlobales.SQL_Comman1, TextB_Agente.Text, TextB_Agente.Text, Rutas_Unidicar)

            End If
            Carga_DeliverFacturas(Class_VariablesGlobales.SQL_Comman1, TextB_Agente.Text, TextB_Agente.Text, Rutas_Unidicar)

            Carga_Inventario(Class_VariablesGlobales.SQL_Comman1, TextB_Agente.Text, TextB_Agente.Text)
            Carga_RazonNoVisita(Class_VariablesGlobales.SQL_Comman1, TextB_Agente.Text, TextB_Agente.Text)
            Carga_Bancos(Class_VariablesGlobales.SQL_Comman1, TextB_Agente.Text, TextB_Agente.Text)
            Carga_UbiacionesCR(Class_VariablesGlobales.SQL_Comman1, TextB_Agente.Text, TextB_Agente.Text)
            Carga_Licencia(Class_VariablesGlobales.SQL_Comman1, TextB_Agente.Text, TextB_Agente.Text)

            If CBX_Param.Checked = True Then

                ExportaParametros(Class_VariablesGlobales.SQL_Comman1, TextB_Agente.Text, TextB_Agente.Text)

            End If

            MessageBox.Show("Informacion cargada correctamente " & TextB_Agente.Text, TextB_Agente.Text)
            TextB_Agente.Text = ""
            TextB_Agente1.Text = ""
            TextB_Agente2.Text = ""
            txb_Grupo.Text = ""
            CBX_Param.Checked = False
            cbx_CatalogoDivido.Checked = False
            Label1.Visible = False
            GroupBox7.Enabled = True
        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN FuncionEn_BackGroud [ " & ex.Message & " ]")
        End Try
    End Function
    Private Sub btn_EnviarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_EnviarTodos.Click


        trd1 = Nothing
        trd1 = New Thread(AddressOf CargaATodos)
        trd1.IsBackground = Enabled
        trd1.Priority = ThreadPriority.AboveNormal
        trd1.Start()
        CheckForIllegalCrossThreadCalls = False





    End Sub
    Public Function CargaATodos()
        btn_EnviarTodos.Enabled = False
        Dim Tbl_Agentes As New DataTable
        Dim cont As Integer = 0
        Dim Ruta As String = "0"
        Tbl_Agentes = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman2, CBox_VERPuestos.Text, "")
        Dim Rutas_Unidicar() As String

        Prgs_CargaAgentes.Value = 0
        Prgs_CargaAgentes.Maximum = Tbl_Agentes.Rows.Count
        lbl_AgentesProcesados.Text = cont
        lbl_TotalAgentes.Text = Prgs_CargaAgentes.Maximum


        For Each row As DataRow In Tbl_Agentes.Rows

            Ruta = CStr(Tbl_Agentes.Rows(cont).Item("CodAgente").ToString())
            lbl_DetalleCarga.Text = "Cargando info de agente [ " & Ruta & " ]"
            Carga_Clientes_Y_CXC(Class_VariablesGlobales.SQL_Comman1, Ruta, Ruta, ChBox_ClientexDia.Checked, Rutas_Unidicar)
            Carga_Descuentos(Class_VariablesGlobales.SQL_Comman1, Ruta, Ruta, Rutas_Unidicar)
            Carga_RazonNoVisita(Class_VariablesGlobales.SQL_Comman1, Ruta, Ruta)
            Carga_Bancos(Class_VariablesGlobales.SQL_Comman1, Ruta, Ruta)
            Carga_Inventario(Class_VariablesGlobales.SQL_Comman1, Ruta, Ruta)
            Carga_Licencia(Class_VariablesGlobales.SQL_Comman1, Ruta, Ruta)
            If CBX_Param.Checked = True Then

                ExportaParametros(Class_VariablesGlobales.SQL_Comman1, Ruta, Ruta)
            End If


            cont += 1
            lbl_AgentesProcesados.Text = cont
            Prgs_CargaAgentes.Value = cont

        Next

        MessageBox.Show("Carga Completa")
        Prgs_CargaAgentes.Value = 0
        Prgs_CargaAgentes.Maximum = Tbl_Agentes.Rows.Count
        lbl_AgentesProcesados.Text = cont
        lbl_TotalAgentes.Text = Prgs_CargaAgentes.Maximum

        btn_EnviarTodos.Enabled = True
    End Function
    Private Sub cbx_CatalogoDivido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbx_CatalogoDivido.CheckedChanged
        If cbx_CatalogoDivido.Checked = True Then
            txb_Grupo.Enabled = True
        Else
            txb_Grupo.Enabled = False
            txb_Grupo.Text = ""
        End If


    End Sub
    Private Sub CBX_Param_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBX_Param.CheckedChanged


    End Sub

#End Region

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged

        Servidor = 1
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged

        Servidor = 2
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_HabilitarServidores.Click



        Dim clavewindows = New ClaveParametros
        clavewindows.MdiParent = Principal
        clavewindows.Show()


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBox_VERPuestos.SelectedIndexChanged


        If CBox_VERPuestos.Text <> "" Then
            GroupBox7.Enabled = True

            btn_HabilitarServidores.Enabled = True

            'If CBox_VERPuestos.Text <> "AGENTE" Then
            cbx_CatalogoDivido.Visible = True
            txb_Grupo.Visible = True
            lbl_FechaReporte.Visible = True
            DTP_FechaDesde.Visible = True
            DTP_FechaHasta.Visible = True
            'End If
            'If CBox_VERPuestos.Text <> "CHOFER" Then
            'cbx_CatalogoDivido.Visible = True
            'txb_Grupo.Visible = True
            'lbl_FechaReporte.Visible = False
            'DTP_FechaDesde.Visible = False
            'DTP_FechaHasta.Visible = False
            'End If
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        Class_VariablesGlobales.Lista_llamadaDesde = "EXPORTAR"

        If CBox_VERPuestos.Text = "AGENTE" Then
            Class_VariablesGlobales.Obj_ListaAgentes = New ListaAgentes
            ' Class_VariablesGlobales.Obj_ListaAgentes.MdiParent = Principal
            Class_VariablesGlobales.Obj_ListaAgentes.Puesto = CBox_VERPuestos.Text
            Class_VariablesGlobales.Obj_ListaAgentes.TopMost = True
            Class_VariablesGlobales.Obj_ListaAgentes.Show()

        Else

            ListaChoferes.Show()

        End If

    End Sub

    Private Sub Enviar_Info_Seller_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Class_VariablesGlobales.Obj_ListaAgentes = New ListaAgentes
        ' Class_VariablesGlobales.Obj_ListaAgentes.MdiParent = Principal
        Class_VariablesGlobales.Obj_ListaAgentes.Puesto = CBox_VERPuestos.Text
        Class_VariablesGlobales.Obj_ListaAgentes.TopMost = True
        Class_VariablesGlobales.Obj_ListaAgentes.Show()
    End Sub
End Class