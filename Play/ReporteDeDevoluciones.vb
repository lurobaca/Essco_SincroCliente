Imports System.Data.SqlClient
Imports System.Threading
Imports System.IO

Public Class ReporteDeDevoluciones
    Public trd3 As Thread

    Private Sub ReporteDeDevoluciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txb_Numero.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivoRepCarga(Class_VariablesGlobales.SQL_Comman2, "Devoluciones")
        btn_Corregir.Enabled = False


    End Sub

#Region "Reporte de Devoluciones"

    Public Function RepDevoluciones_BackGroud()
        Try
            'PRIMERO SE GENERA EL ARCHIVO DE DEVOLUCIONES

            Dim Resultado As Integer
            ' para la conexion al comman
            ' SQL_Comman2.Connection = Obj_SQL_CONEXION_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim agente As String
            Dim tbl_reporte As New DataTable
            '9 SECTORES Y BLANCO ES BONIDICACION
            Dim SECTORES As Integer = 10
            Dim conse As Integer = 0
            ProgressBar1.Minimum = 0

            ProgressBar1.Value = 0
            Dim Consecutivo As String

            'If Trim(TXTB_INI.Text) > Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaUltimaFactura(Class_VariablesGlobales.SQL_Comman2, "Devolucion") Then
            'If Class_VariablesGlobales.Obj_Funciones_SQL.VerificaSiExiste(Trim(TXTB_INI.Text), Trim(TXTB_FIN.Text), Class_VariablesGlobales.SQL_Comman2, "Devoluciones") = True Then
            '    Progress_RepDevo.Value = 0
            '    Lbl_Detalle.Text = "ERROR [Este reporte ya ha sido generado]"
            'Else

            ''obtiene el consecutivo segun el sector
            Consecutivo = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivoRepCarga(Class_VariablesGlobales.SQL_Comman2, "Devoluciones")
            txb_Numero.Text = Consecutivo


            Lbl_Detalle.Text = "Generando Reporte de devoluciones"


            'obtiene la lista de articulos en el sector definido
            tbl_reporte = Class_VariablesGlobales.Obj_Funciones_SQL.GeneraReporteDevoluciones(Trim(Txtb_Desde.Text), Trim(Txtb_Hasta.Text), Class_VariablesGlobales.SQL_Comman2)
            ProgressBar1.Maximum = tbl_reporte.Rows.Count

            If tbl_reporte.Rows.Count > 0 Then
                'verifica si el reporte ya se habia generado
                Resultado = GUARDA_ReporteDevoluciones(tbl_reporte, Consecutivo, Trim(Txtb_Desde.Text), Trim(Txtb_Hasta.Text), Class_VariablesGlobales.SQL_Comman2)

                'Genera el archivo
                If Resultado = 0 Then
                    'Resultado = CreaArchivoDevoluciones(tbl_reporte, Consecutivo)

                    'incrementa el consecutivo y lo actualiza segun el sector
                    conse = CInt(Consecutivo) + 1
                    Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaConsecutivo(conse, Class_VariablesGlobales.SQL_Comman2, "Devoluciones")


                    Dgt_RepDevoluciones.DataSource = New DataTable
                    Dgt_RepDevoluciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepDevoluciones(Trim(Txtb_Desde.Text), Trim(Txtb_Hasta.Text), "", Class_VariablesGlobales.SQL_Comman2)


                    Lbl_Detalle.Text = "Enviando Correo a jede de Bodeguero"
                    Dim mensaje As String = "Nuevo Reporte de Devoluciones " & vbCrLf & vbCrLf & _
                                            "Desarrollador: Luis Roberto Bastos C" & vbCrLf & _
                                            "Bach: Informatica Emplesarial and Lic: Desarrollo Paginas WEB" & vbCrLf & _
                                            "E-mail: lurobaca@gmail.com" & vbCrLf & _
                                            "Tel: 8880-1662" & vbCrLf

                    Class_VariablesGlobales.Obj_MAIL.EnviarCorreo(mensaje, "Nuevo Reporte de Devoluciones [ " & Trim(Txtb_Desde.Text) & "," & Trim(Txtb_Hasta.Text) & " ]", "", "bodeguerosbourne@gmail.com", "", "", "")

                    'SEGUNDO GENERAMOS UN ARCHIVO CON EL INVENTARIO ACTUAL
                    'Dim table As New DataTable
                    'table = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneInventario(Class_VariablesGlobales.SQL_Comman2)
                    'GeneraArchivoInventario(table)

                    Lbl_Detalle.Text = "Proceso Finalizado ,Consecutivo siguiente [ " & conse & " ]"
                    MessageBox.Show("Proceso Finalizado ,Consecutivo siguiente [ " & conse & " ]")

                End If

            Else
                MessageBox.Show("[ " & Now & " ] No se pudo obtener la informacion del reporte")
            End If
            'End If


            'Class_VariablesGlobales.Obj_Funciones_SQL.InsertaUltimFactura(Class_VariablesGlobales.SQL_Comman2, Trim(TXTB_INI.Text), "Devoluciones")
            'Else
            '    Lbl_Detalle.Text = "Factura de inicio ya fue Generada"
            'End If



            ' Obj_SQL_CONEXION_CONEXION.Desconectar(SQL_Comman2)
            Navegar(CInt(Consecutivo))



        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN FuncionEn_BackGroud2 [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function GUARDA_ReporteDevoluciones(ByVal tbl_reporte As DataTable, ByVal Consecutivo As Integer, ByVal txt_FacturaINI As String, ByVal txt_FacturaFIN As String, ByVal SQL_Comman2 As SqlCommand)

        Try


            Dim ItemCode As String
            Dim Descripcion As String
            Dim Bodega As String
            Dim Bodega_Nombre As String
            Dim Cantidad As String
            Dim NumBoleta As String
            Dim Sistema As String
            Dim Motivo As String
            Dim Chofer As String
            Dim Nombre_Chofer As String

            Dim Dia As String = Now.Date.Day
            Dim Mes As String = Now.Date.Month
            Dim Ano As String = Now.Date.Year

            Dim Fecha As String = Ano & "-" & Mes & "-" & Dia
            Dim CONT As Integer = 0

            For Each row As DataRow In tbl_reporte.Rows

                ItemCode = tbl_reporte.Rows(CONT).Item("Codigo").ToString()
                Descripcion = tbl_reporte.Rows(CONT).Item("Articulo").ToString()
                Bodega = tbl_reporte.Rows(CONT).Item("Bodega").ToString()
                Bodega_Nombre = tbl_reporte.Rows(CONT).Item("Bodega_Nombre").ToString()
                Cantidad = CInt(Trim(tbl_reporte.Rows(CONT).Item("Cantidad").ToString()))
                NumBoleta = tbl_reporte.Rows(CONT).Item("u_boleta").ToString()
                Sistema = tbl_reporte.Rows(CONT).Item("Sistema").ToString()
                Motivo = tbl_reporte.Rows(CONT).Item("Motivo").ToString()
                Chofer = tbl_reporte.Rows(CONT).Item("U_Chofer").ToString()
                Nombre_Chofer = tbl_reporte.Rows(CONT).Item("Nombre_Chofer").ToString()

                Class_VariablesGlobales.Obj_Funciones_SQL.GUARDA_ReporteDevoluciones(Consecutivo, Fecha, ItemCode, Descripcion, Bodega, CInt(Cantidad), NumBoleta, Sistema, Motivo, Chofer, txt_FacturaINI, txt_FacturaFIN, Bodega_Nombre, Nombre_Chofer, SQL_Comman2)

                CONT += 1
                ProgressBar1.Value += 1
            Next
            Return 0
        Catch ex As Exception
            MessageBox.Show("ERROR EN GUARDA_ReporteDevoluciones " & ex.Message)
            Return 1


        End Try


    End Function
    Public Function CreaArchivoDevoluciones(ByVal tbl_reporte As DataTable, ByVal Consecutivo As String)

        Try
            Dim ftp_Admin As New Class_FTP
            Dim CONT As Integer
            Dim ItemCode As String
            Dim Descripcion As String
            Dim Bodega As String
            Dim Cantidad As String
            Dim NumBoleta As String
            Dim NumSistema As String
            Dim Motivo As String
            Dim Chofer As String
            Dim FacINI As String
            Dim FacFIN As String

            'Variables para crear archivos
            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
            Dim PathArchivo As String
            Dim Linea As String

            Dim Dia As String = Now.Date.Day
            Dim Mes As String = Now.Date.Month
            Dim Ano As String = Now.Date.Year

            Dim Fecha As String = Dia & "-" & Mes & "-" & Ano
            Dim RutaBase As String = "M:\IMPORTACION\Reportes_De_Devoluciones"


            'CREA LA CARPETA DEL DIA
            If Directory.Exists(RutaBase & "\" & Fecha) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(RutaBase & "\" & Fecha)
            End If

            'CREA LA DEL SECTOR

            If Directory.Exists(RutaBase & "\" & Fecha & "\Sin_Chequear\") = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(RutaBase & "\" & Fecha & "\Sin_Chequear\")
            End If

            Cursor.Current = Cursors.WaitCursor
            'Crea el archivo
            PathArchivo = RutaBase & "\" & Fecha & "\Sin_Chequear\" & Trim(Consecutivo) & ".mbg" ' Se determina el nombre del archivo 

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            For Each row As DataRow In tbl_reporte.Rows

                'obtiene los datos de una linea

                ItemCode = tbl_reporte.Rows(CONT).Item("Codigo").ToString()
                Descripcion = tbl_reporte.Rows(CONT).Item("Articulo").ToString()
                Bodega = tbl_reporte.Rows(CONT).Item("Bodega").ToString()
                Cantidad = tbl_reporte.Rows(CONT).Item("Cantidad").ToString()
                NumBoleta = tbl_reporte.Rows(CONT).Item("u_boleta").ToString()
                NumSistema = tbl_reporte.Rows(CONT).Item("Sistema").ToString()
                Motivo = tbl_reporte.Rows(CONT).Item("Motivo").ToString()
                Chofer = tbl_reporte.Rows(CONT).Item("U_Chofer").ToString()

                If ItemCode = "" Then
                    ItemCode = "0"
                End If
                If Descripcion = "" Then
                    Descripcion = "0"
                End If
                If Bodega = "" Then
                    Bodega = "0"
                End If
                If Cantidad = "" Then
                    Cantidad = "0"
                End If
                If NumBoleta = "" Then
                    NumBoleta = "0"
                End If
                If NumSistema = "" Then
                    NumSistema = "0"
                End If
                If Motivo = "" Then
                    Motivo = "0"
                End If
                If Chofer = "" Then
                    Chofer = "0"
                End If
                If FacINI = "" Then
                    FacINI = "0"
                End If
                If FacFIN = 0 Then
                    FacFIN = "0"
                End If
                Linea = Now.Date + "," + ItemCode + "," + Descripcion + "," + Bodega + "," & CInt(Cantidad) & "," + NumBoleta + "," + NumSistema + "," + Motivo + "," + Chofer + "," + FacINI + "," + FacFIN

                'ESCRIBE LA LINEA EN EL ARCHIVO
                strStreamWriter.WriteLine(Linea)
                Linea = ""
                CONT += 1
            Next

            ' LIMPIA MEMORIA
            ItemCode = Nothing
            Descripcion = Nothing
            Bodega = Nothing
            Cantidad = Nothing
            NumBoleta = Nothing
            NumSistema = Nothing
            Motivo = Nothing
            Chofer = Nothing
            FacINI = Nothing
            FacFIN = Nothing

            strStreamWriter.Close() ' cerramos
            'INICIO DE LIBERIACION DE MEMORIA
            sRenglon = Nothing
            strStreamW.Dispose()
            strStreamW = Nothing
            strStreamWriter.Dispose()
            strStreamWriter = Nothing

            ftp_Admin.Subir(PathArchivo, "ftp://bourneycia.net/bourneycia.net/Picking/RepDevo/impo/" & Trim(Consecutivo) & ".mbg", "arquitect", "tbh573")
        Catch ex As Exception
            MessageBox.Show("ERROR EN CreaArchivo  " & ex.Message)


        End Try

    End Function
    Public Function GeneraArchivoInventario(ByVal tbl_reporte As DataTable)

        Try
            Dim ftp_Admin As New Class_FTP
            Dim CONT As Integer
            Dim ItemCode As String
            Dim Descripcion As String
            Dim CodBar As String

            'Variables para crear archivos
            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
            Dim PathArchivo As String
            Dim Linea As String

            Dim Dia As String = Now.Date.Day
            Dim Mes As String = Now.Date.Month
            Dim Ano As String = Now.Date.Year

            Dim Fecha As String = Dia & "-" & Mes & "-" & Ano
            Dim RutaBase As String = "M:\IMPORTACION\Reportes_De_Devoluciones"


            'CREA LA CARPETA DEL DIA
            If Directory.Exists(RutaBase & "\" & Fecha) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(RutaBase & "\" & Fecha)
            End If

            'CREA LA DEL SECTOR

            If Directory.Exists(RutaBase & "\" & Fecha & "\Sin_Chequear\") = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(RutaBase & "\" & Fecha & "\Sin_Chequear\")
            End If

            Cursor.Current = Cursors.WaitCursor
            'Crea el archivo
            PathArchivo = RutaBase & "\" & Fecha & "\Sin_Chequear\Inventario.mbg" ' Se determina el nombre del archivo 

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            For Each row As DataRow In tbl_reporte.Rows

                'obtiene los datos de una linea

                ItemCode = tbl_reporte.Rows(CONT).Item("ItemCode").ToString()
                Descripcion = tbl_reporte.Rows(CONT).Item("ItemName").ToString()
                CodBar = tbl_reporte.Rows(CONT).Item("CodeBars").ToString()

                If ItemCode = "" Then
                    ItemCode = "0"
                End If
                If Descripcion = "" Then
                    Descripcion = "0"
                End If
                If CodBar = "" Then
                    CodBar = "0"
                End If

                Linea = Now.Date + "," + ItemCode + "," + Descripcion + "," + CodBar

                'ESCRIBE LA LINEA EN EL ARCHIVO
                strStreamWriter.WriteLine(Linea)
                Linea = ""
                CONT += 1
            Next

            ' LIMPIA MEMORIA
            ItemCode = Nothing
            Descripcion = Nothing
            CodBar = Nothing
            strStreamWriter.Close() ' cerramos
            'INICIO DE LIBERIACION DE MEMORIA
            sRenglon = Nothing
            strStreamW.Dispose()
            strStreamW = Nothing
            strStreamWriter.Dispose()
            strStreamWriter = Nothing

            'Sube el archivo Bodeguero
            ftp_Admin.Subir(PathArchivo, "ftp://bourneycia.net/bourneycia.net/Bodegueros/RepDevo/impo/Inventario.mbg", "arquitect", "tbh573")
        Catch ex As Exception
            MessageBox.Show("ERROR EN CreaArchivo  " & ex.Message)
        End Try

    End Function
    Private Sub BTN_Busca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Busca.Click
        BuscaReportDevoluciones.Show()
    End Sub

    Public Function CargaDetRepdevolucion(ByVal Conse_Repdevo As String, ByVal Accion As String)
        Try
            Dim total As Double
            Dim CUENTA As Integer
            ' SQL_Comman.Connection = Obj_SQL_CONEXION_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Class_VariablesGlobales.Tbl_RepCarga = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepDevo(Conse_Repdevo, Class_VariablesGlobales.SQL_Comman2, Accion)

            Dgt_RepDevoluciones.DataSource = Class_VariablesGlobales.Tbl_RepCarga

            Dim CONT As Integer
            For Each row As DataRow In Class_VariablesGlobales.Tbl_RepCarga.Rows
                Class_VariablesGlobales.Obj_RepDevoluciones.Txtb_Desde.Text = Class_VariablesGlobales.Tbl_RepCarga.Rows(CONT).Item("FacINI").ToString()
                Class_VariablesGlobales.Obj_RepDevoluciones.Txtb_Hasta.Text = Class_VariablesGlobales.Tbl_RepCarga.Rows(CONT).Item("FacFIN").ToString()

                If Class_VariablesGlobales.Tbl_RepCarga.Rows(CONT).Item("Anulado").ToString() = "1" Then
                    Class_VariablesGlobales.Obj_RepDevoluciones.Lbl_Anulado.Visible = True
                    Class_VariablesGlobales.Obj_RepDevoluciones.btn_eliminar.Visible = False
                Else
                    Class_VariablesGlobales.Obj_RepDevoluciones.Lbl_Anulado.Visible = False
                    Class_VariablesGlobales.Obj_RepDevoluciones.btn_eliminar.Visible = True
                End If
                If Class_VariablesGlobales.Tbl_RepCarga.Rows(CONT).Item("Corregido").ToString() = "1" Then
                    Class_VariablesGlobales.Obj_RepDevoluciones.lbl_Corregido.Visible = True
                    Class_VariablesGlobales.Obj_RepDevoluciones.btn_Corregir.Visible = False
                Else
                    Class_VariablesGlobales.Obj_RepDevoluciones.lbl_Corregido.Visible = False
                    Class_VariablesGlobales.Obj_RepDevoluciones.btn_Corregir.Visible = True
                End If

                Exit For

                CONT += 1
            Next
            'aqui se deben ocultas las columnas que no quiran mostrar
            ' [Fecha],[Consecutivo],[ItemCode],[Descripcion],[Bodega],[Cantidad],[NumBoleta],[NumSistema],[Motivo],[Chofer],
            '[FacINI],[FacFIN], [Chequeado], [Cant_Mover], [Accion], [CodArtCambiado], [Bodega_Nombre], [Chofer_Nombre], [Bod_Destino]
            Dgt_RepDevoluciones.Columns(0).Visible = False
            Dgt_RepDevoluciones.Columns(1).Visible = False
            Dgt_RepDevoluciones.Columns(2).Width = 100
            Dgt_RepDevoluciones.Columns(3).Width = 300
            Dgt_RepDevoluciones.Columns(4).Width = 50
            Dgt_RepDevoluciones.Columns(5).Width = 50
            Dgt_RepDevoluciones.Columns(6).Width = 50
            Dgt_RepDevoluciones.Columns(7).Width = 100
            Dgt_RepDevoluciones.Columns(8).Width = 100
            Dgt_RepDevoluciones.Columns(9).Visible = False
            Dgt_RepDevoluciones.Columns(10).Visible = False
            Dgt_RepDevoluciones.Columns(11).Visible = False
            Dgt_RepDevoluciones.Columns(12).Visible = False
            Dgt_RepDevoluciones.Columns(13).Width = 100
            Dgt_RepDevoluciones.Columns(14).Width = 100
            Dgt_RepDevoluciones.Columns(15).Width = 100
            Dgt_RepDevoluciones.Columns(16).Visible = False
            Dgt_RepDevoluciones.Columns(17).Visible = False
            Dgt_RepDevoluciones.Columns(18).Width = 100





        Catch ex As Exception
        End Try
    End Function
    Public Function CargaDetDevoluciones(ByVal SQL_Comman As SqlCommand, ByVal Conse_Repcarga As String)
        Dim tabla As New DataTable
        Dim cont As Integer
        Dim Total As Double
        tabla = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepDevo(Conse_Repcarga, SQL_Comman, "")
        DataDV_RepDev.DataSource = tabla
    End Function

#End Region
    Private Sub Brn_Genera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Brn_Genera.Click
        Try

            Lbl_Detalle.Text = FormatCurrency("0")
            'hilo de ejecucion constante
            trd3 = New Thread(AddressOf RepDevoluciones_BackGroud)
            trd3.IsBackground = Enabled
            'trd2.Priority = ThreadPriority.Highest
            trd3.Start()
            CheckForIllegalCrossThreadCalls = False

        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN Brn_Genera_Click [ " & ex.Message & " ]")
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        List_RepDevoluciones.Show()

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub


    Private Sub Btn_Atras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Atras.Click
        Navegar(CInt(txb_Numero.Text) - 1)
    End Sub

    Private Sub Btn_Adelante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Adelante.Click
        Navegar(CInt(txb_Numero.Text) + 1)
    End Sub

    Public Function Navegar(ByVal id As Integer)
        Class_VariablesGlobales.Obj_RepDevoluciones.Txtb_Desde.Text = ""
        Class_VariablesGlobales.Obj_RepDevoluciones.Txtb_Hasta.Text = ""
        Class_VariablesGlobales.Obj_RepDevoluciones.Txtb_Hasta.Text = ""
        Class_VariablesGlobales.Obj_RepDevoluciones.Lbl_Anulado.Visible = False
        Class_VariablesGlobales.Obj_RepDevoluciones.btn_eliminar.Visible = True

        txb_Numero.Text = id
        Class_VariablesGlobales.ConseRepDevoluciones = id
        Class_VariablesGlobales.Obj_RepDevoluciones.CargaDetRepdevolucion(Class_VariablesGlobales.ConseRepDevoluciones, "")

        If Txtb_Desde.Text = "" Then
            btn_Corregir.Enabled = False
        Else
            btn_Corregir.Enabled = True
        End If

    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Nuevo.Click
        Class_VariablesGlobales.Obj_RepDevoluciones.Txtb_Desde.Text = ""
        Class_VariablesGlobales.Obj_RepDevoluciones.Txtb_Hasta.Text = ""
        txb_Numero.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivoRepCarga(Class_VariablesGlobales.SQL_Comman2, "Devoluciones")
        Class_VariablesGlobales.Obj_RepDevoluciones.CargaDetRepdevolucion(txb_Numero.Text, "")
        Lbl_Anulado.Visible = False


    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Class_VariablesGlobales.Obj_Funciones_SQL.AnulaRepDevoluciones(Class_VariablesGlobales.SQL_Comman2, txb_Numero.Text)

        Lbl_Anulado.Visible = True
        btn_eliminar.Visible = False



    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged


        If ComboBox1.Text = "CORRECTO" Then
            Class_VariablesGlobales.Obj_RepDevoluciones.CargaDetRepdevolucion(Class_VariablesGlobales.ConseRepDevoluciones, "CORRECTO")
        ElseIf ComboBox1.Text = "CAMBIADO" Then
            Class_VariablesGlobales.Obj_RepDevoluciones.CargaDetRepdevolucion(Class_VariablesGlobales.ConseRepDevoluciones, "CAMBIADO")
        ElseIf ComboBox1.Text = "TRASLADO" Then
            Class_VariablesGlobales.Obj_RepDevoluciones.CargaDetRepdevolucion(Class_VariablesGlobales.ConseRepDevoluciones, "TRASLADO")
        ElseIf ComboBox1.Text = "TODO" Then
            Class_VariablesGlobales.Obj_RepDevoluciones.CargaDetRepdevolucion(Class_VariablesGlobales.ConseRepDevoluciones, "")
        End If

    End Sub

    Private Sub btn_Corregir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Corregir.Click
        Try
            'Primero obtendra las linea que necesitas TRASLADO, ENTRADA Y SALIDA esto segun el estado  de Accion que se le alla elegido
            Dim TablCambiado As DataTable
            Dim TablaLineasEntrada As DataTable
            Dim vCompany As SAPbobsCOM.Company

            TablCambiado = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepDevo(txb_Numero.Text, Class_VariablesGlobales.SQL_Comman2, "CAMBIADO")

            Class_VariablesGlobales.obj_SAP.CreaSalidaDeMercaderia(TablCambiado)
            Class_VariablesGlobales.obj_SAP.CreaEntradaDeMercaderia(TablCambiado)

            TablCambiado.Dispose()

            TablCambiado = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepDevo(txb_Numero.Text, Class_VariablesGlobales.SQL_Comman2, "TRASLADO")

            Class_VariablesGlobales.obj_SAP.CreaTrasladoDeMercaderia(TablCambiado)

            Class_VariablesGlobales.Obj_Funciones_SQL.CambiaStadoACorregido(txb_Numero.Text, Class_VariablesGlobales.SQL_Comman2)
            btn_Corregir.Visible = False


            lbl_Corregido.Visible = True


        Catch ex As Exception
            MsgBox("ERROR [ " & ex.Message & " ]", MsgBoxStyle.Information, "ERROR")
        End Try
    End Sub

    Private Sub Dgt_RepDevoluciones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgt_RepDevoluciones.CellContentClick

        Class_VariablesGlobales.Desv_ItemCode = Dgt_RepDevoluciones.Item(2, Dgt_RepDevoluciones.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.Desv_Descripcion = Dgt_RepDevoluciones.Item(3, Dgt_RepDevoluciones.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.Desv_BodegaOrigen = Dgt_RepDevoluciones.Item(4, Dgt_RepDevoluciones.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.Desv_Cantidad = Dgt_RepDevoluciones.Item(5, Dgt_RepDevoluciones.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.Desv_Accion = Dgt_RepDevoluciones.Item(14, Dgt_RepDevoluciones.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.Desv_CantMover = Dgt_RepDevoluciones.Item(13, Dgt_RepDevoluciones.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.Desv_CodigoDestino = Dgt_RepDevoluciones.Item(15, Dgt_RepDevoluciones.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.Desv_BodegaDestino = Dgt_RepDevoluciones.Item(18, Dgt_RepDevoluciones.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.Desv_Motivo = Dgt_RepDevoluciones.Item(8, Dgt_RepDevoluciones.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.Desv_Consecutivo = txb_Numero.Text



        Class_VariablesGlobales.Obj_ReporteDeDevoluciones_Corregir = New ReporteDeDevoluciones_Corregir
        Class_VariablesGlobales.Obj_ReporteDeDevoluciones_Corregir.MdiParent = Principal

        Class_VariablesGlobales.Obj_ReporteDeDevoluciones_Corregir.Show()




    End Sub
End Class
