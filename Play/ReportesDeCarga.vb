Imports System.Threading
Imports System.Data.SqlClient
Imports System.IO

Public Class ReportesDeCarga
  


    Private Sub ReportesDeCarga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        dtp_FechaReporte.Format = DateTimePickerFormat.Custom
        dtp_FechaReporte.CustomFormat = "dd/MM/yyyy"

        Dim Dia As String = Now.Date.Day
        Dim Mes As String = Now.Date.Month
        Dim Ano As String = Now.Date.Year

        Dim Hora As String = Now.TimeOfDay.Hours
        Dim Minutos As String = Now.TimeOfDay.Minutes
        Dim Segundo As String = Now.TimeOfDay.Seconds

        Dim Fecha As String = Dia & "/" & Mes & "/" & Ano
        Dim HoraDia As String = Hora & ":" & Minutos & ":" & Segundo

        TXB_Hora.Text = HoraDia

        If Class_VariablesGlobales.Puesto = "Facturacion" Or Class_VariablesGlobales.Puesto = "Manager" Then


            'btn_Anular.Visible = True
            btn_Generar.Visible = True
            'btn_cerrar.Visible = False
        End If

        'btn_Anular.Enabled = False
        ' btn_Anular.BackColor = Color.Gray
        If Class_VariablesGlobales.Puesto = "Bodega" Then
            Panel6.Visible = True
            txtb_Ruta.Enabled = False
            txtb_FACINI.Enabled = False
            txtb_FACFIN.Enabled = False

            Rb_ConBod1.Enabled = False
            Rb_SinBod1.Enabled = False



            ' btn_Anular.Visible = False
            btn_Generar.Visible = False
            ' btn_cerrar.Visible = True

        End If
        DataGV_RepCarSec.DataSource = New DataTable

        'If btn_cerrar.Text = "CERRADO" Then
        '    'btn_cerrar.Visible = False


        'End If
        txb_Numero.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivoRepCarga(Class_VariablesGlobales.SQL_Comman2, "Carga")
        ObtieneRutas()

        lbl_TotalRuta.Text = FormatCurrency("0.0")
        lbl_TotalFaltante.Text = FormatCurrency("0.0")
        Lbl_Peso.Text = "Kg " & FormatNumber("0.0")




    End Sub

    Public Function ObtieneRutas()
        Try


            Cbx_Rutas = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneRutas(Class_VariablesGlobales.SQL_Comman2, Cbx_Rutas)

            Cbx_Rutas.Items.Add("Seleccione una Ruta")


        Catch ex As Exception

        End Try
    End Function

#Region "Genera Reporte de Carga X Sector"
    Public TotalRuta As Double = 0
    Public trd1, trd2, trd3 As Thread

    'enviara el reporte de carga completo a cada bodeguero y picking se encargara de solo hacer que vea los sectores asignados
    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Generar.Click
        Try



            lbl_TotalRuta.Text = FormatCurrency(0)
            DataGV_RepCarSec.DataSource = New DataTable
            Class_VariablesGlobales.Obj_RepDCar.txtb_FACINI.Enabled = True
            Class_VariablesGlobales.Obj_RepDCar.txtb_FACFIN.Enabled = True
            Class_VariablesGlobales.Obj_RepDCar.txtb_Ruta.Enabled = True
            btn_Generar.Enabled = True

            If txtb_Ruta.Text <> "" And txtb_FACINI.Text <> "" And txtb_FACFIN.Text <> "" Then
                btn_Buscar.Enabled = False
                btn_Buscar.Enabled = False
                btn_Limpiar.Enabled = False
                btn_Generar.Enabled = False

                Dim result As Integer = MessageBox.Show("Realmente desea Generar el reporte de carga :" & vbCrLf & "Ruta [ " & txtb_Ruta.Text & " ] " & vbCrLf & "Desde [   " & txtb_FACINI.Text & "   ] Hasta [   " & txtb_FACFIN.Text & "   ] ", "CONFIRMAR", MessageBoxButtons.OKCancel)
                If result = DialogResult.OK Then
                    lbl_TotalRuta.Text = FormatCurrency("0")
                    'hilo de ejecucion constante
                    trd2 = New Thread(AddressOf FuncionEn_BackGroud)
                    trd2.IsBackground = Enabled
                    'trd2.Priority = ThreadPriority.Highest
                    CheckForIllegalCrossThreadCalls = False
                    trd2.Start()
                ElseIf result = DialogResult.Cancel Then


                End If



            Else
                MsgBox("Debe indicar el nombre de la ruta y el rango de facturas", MsgBoxStyle.Critical, "FALTA DE INFORMACION")

            End If


        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN btn_generar_Click [ " & ex.Message & " ]")
        End Try
    End Sub
    Public Function FuncionEn_BackGroud()
        Try
            ' para la conexion al comman
            '    SQL_Comman.Connection = Obj_SQL_CONEXION_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")

            Dim agente As String
            Dim tbl_reporte As New DataTable
            'Dim tbl_bodegueros As New DataTable
            '9 SECTORES Y BLANCO ES BONIDICACION
            Dim SECTORES As Integer = 10
            Dim CONT As Integer = 1
            Dim conse As Integer = 0

            Dim Consecutivo As String
            Dim CodBodeguero As String
            Dim Nombre As String
            Dim FacGenerada As Boolean

            ' tbl_bodegueros = Obj_Funciones_SQL.ConsultaBodegueros(Class_VariablesGlobales.SQL_Comman2)


            'Primero generamos todo el reporte y lo guardamos 
            ''obtiene el consecutivo segun el sector
            Consecutivo = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivoRepCarga(Class_VariablesGlobales.SQL_Comman2, "Carga")

            'verifica que existan las facturas del rango
            If Class_VariablesGlobales.Obj_Funciones_SQL.ExisteFactura(Trim(txtb_FACINI.Text), Class_VariablesGlobales.SQL_Comman2) = True And Class_VariablesGlobales.Obj_Funciones_SQL.ExisteFactura(Trim(txtb_FACFIN.Text), Class_VariablesGlobales.SQL_Comman2) = True Then



                'obtiene la lista de articulos en el sector definido
                tbl_reporte = Class_VariablesGlobales.Obj_Funciones_SQL.GeneraReporteCarga(Rb_ConBod1.Checked, Trim(txtb_FACINI.Text), Trim(txtb_FACFIN.Text), Class_VariablesGlobales.SQL_Comman2)

                'luego recorremos el reporte extrallendo cada sector y eliminandolo de la tabla 
                Dim TotalReporte As Double
                Dim TotalPeso As Double
                Dim TotalFaltante As Double
                Dim Valores(3) As Double
                Valores = GUARDA_Reporte(txtb_Ruta.Text, Rb_ConBod1.Checked, tbl_reporte, Consecutivo, Trim(txtb_FACINI.Text), Trim(txtb_FACFIN.Text), Trim(dtp_FechaReporte.Text), Trim(TXB_Hora.Text), Class_VariablesGlobales.SQL_Comman2)
                TotalReporte = Valores(0)
                TotalPeso = Valores(1)
                TotalFaltante = Valores(2)
                'Dim TotalRepFacturas As Double = Obj_Funciones_SQL.ObtieneTotalReporteFacturas(False, Trim(txtb_FACINI.Text), Trim(txtb_FACFIN.Text), SQL_Comman2)
                'If (Math.Round(TotalReporte, 2) = Math.Round(TotalRepFacturas, 2)) Then
                lbl_TotalRuta.Text = FormatCurrency(TotalReporte)
                lbl_TotalFaltante.Text = FormatCurrency(TotalFaltante)
                'convierte a kg
                Dim peso As Double = (TotalPeso / 1000)

                'si los kg son mas de mil  , entonces son toneladas
                If peso >= 1000 Then
                    Lbl_Peso.Text = "T " & FormatNumber(peso / 1000)
                Else
                    Lbl_Peso.Text = "Kg " & FormatNumber(peso)
                End If


                'muestra el total y preguntara si desea enviar el reporte a los bodegueros


                Dim result As Integer = MessageBox.Show("REVICION DE DATOS " & vbCrLf & "Ruta [ " & txtb_Ruta.Text & " ] " & vbCrLf & "Desde [   " & txtb_FACINI.Text & "   ] Hasta [   " & txtb_FACFIN.Text & "   ]" & vbCrLf & "Monto [ " & FormatCurrency(TotalReporte) & " ]", "CONFIRMAR", MessageBoxButtons.OKCancel)
                If result = DialogResult.OK Then


                    'incrementa el consecutivo y lo actualiza segun el sector
                    If TotalReporte <> 0 And TotalPeso <> 0 Then


                        conse = CInt(Consecutivo) + 1
                        Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaConsecutivo(conse, Class_VariablesGlobales.SQL_Comman2, "Carga")

                        'btn_Anular.Enabled = True


                        Dim mensaje As String = "Nuevo Reporte de Carga por Sector De la ruta [" & txtb_Ruta.Text & "]" & vbCrLf & vbCrLf & _
                                                "Desarrollador: Luis Roberto Bastos C" & vbCrLf & _
                                                "Bach: Informatica Emplesarial and Lic: Desarrollo Paginas WEB" & vbCrLf & _
                                                "E-mail: lurobaca@gmail.com" & vbCrLf & _
                                                "Tel: 8880-1662" & vbCrLf

                        Class_VariablesGlobales.Obj_MAIL.EnviarCorreo(mensaje, "Nuevo Reporte Ruta [" & txtb_Ruta.Text & "]", "", "bodeguerosbourne@gmail.com", "", "", "")
                        DataGV_RepCarSec.DataSource = New DataTable
                        DataGV_RepCarSec.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepCarXSector("TODO", "", Consecutivo, Class_VariablesGlobales.SQL_Comman2, "")
                    Else
                        MessageBox.Show("Las facturas ingresadas no son validad , verifique el rango de facturas")


                    End If

                    MessageBox.Show("Proceso Finalizado ,Consecutivo siguiente [ " & conse & " ]")
                    'lbl_Total.Text = FormatCurrency(TotalRuta)
                    TotalRuta = 0
                    btn_Buscar.Enabled = True
                    btn_Buscar.Enabled = True
                    btn_Limpiar.Enabled = True
                    btn_Generar.Enabled = True
                    btn_Limpiar.Focus()

                    'no guarda la ultima factura del reporte que se genere con bodega 1
                    If Rb_ConBod1.Checked = False Then
                        Class_VariablesGlobales.Obj_Funciones_SQL.InsertaUltimFactura(Class_VariablesGlobales.SQL_Comman2, Trim(txtb_FACFIN.Text), "Carga")
                    End If

                ElseIf result = DialogResult.Cancel Then


                End If


            Else
                MessageBox.Show("Verifique el rango de facturas, puede que no exista")

            End If

        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN FuncionEn_BackGroud [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function GUARDA_Reporte(ByVal NombreRuta As String, ByVal Conb1 As Boolean, ByVal tbl_reporte As DataTable, ByVal Consecutivo As Integer, ByVal txt_FacturaINI As String, ByVal txt_FacturaFIN As String, ByVal Fecha As String, ByVal Hora As String, ByVal SQL_Comman As SqlCommand)
        Dim TotalReporte As Double = 0
        Dim TotalPeso As Double = 0
        Dim TotalPesoXLinea As Double = 0
        Dim TotalFaltante As Double = 0
        Dim Valores(3) As Double

        Try

            Dim Sacado As String
            Dim Chequeado As String
            Dim Ruta As String
            Dim Bodeguero As String
            Dim ItemCode As String
            Dim Descripcion As String
            Dim sector As String
            Dim Cantidad As String
            Dim Total As String
            Dim U_Gramaje As String
            Dim Unidades_x_Caja As String
            Dim CodeBars As String
            Dim Cajas As String
            Dim Faltante As String
            Dim Motivo As String
            Dim Bodega As String
            Dim Marca As String
            Dim Precio As String
            Dim CONT As Integer
            Dim Bo1 As String

            For Each row As DataRow In tbl_reporte.Rows
                Sacado = "NO"
                Chequeado = "NO"
                Ruta = NombreRuta
                Bodeguero = ""
                ItemCode = tbl_reporte.Rows(CONT).Item("ItemCode").ToString()
                Descripcion = tbl_reporte.Rows(CONT).Item("Descripcion").ToString()
                sector = tbl_reporte.Rows(CONT).Item("sector").ToString()
                Cantidad = tbl_reporte.Rows(CONT).Item("Cantidad").ToString()

                Total = tbl_reporte.Rows(CONT).Item("Total").ToString()

                U_Gramaje = tbl_reporte.Rows(CONT).Item("U_Gramaje").ToString()
                Unidades_x_Caja = tbl_reporte.Rows(CONT).Item("Unidades_x_Caja").ToString()
                CodeBars = tbl_reporte.Rows(CONT).Item("CodeBars").ToString()
                Cajas = tbl_reporte.Rows(CONT).Item("Cajas").ToString()
                Bodega = tbl_reporte.Rows(CONT).Item("Bodega").ToString()
                Marca = tbl_reporte.Rows(CONT).Item("Marca").ToString()
                Precio = tbl_reporte.Rows(CONT).Item("Precio").ToString()
                Faltante = "0"
                Motivo = ""


                TotalReporte += CDbl(Total)
                If U_Gramaje = "" Then
                    TotalPeso += CDbl("1") * Cantidad
                    TotalPesoXLinea = CDbl("1") * Cantidad
                Else
                    TotalPeso += CDbl(U_Gramaje) * Cantidad
                    TotalPesoXLinea = CDbl(U_Gramaje) * Cantidad
                End If


                If CodeBars = "" Then
                    CodeBars = "0"
                End If
                If Unidades_x_Caja = "" Then
                    Unidades_x_Caja = "1"
                End If
                If U_Gramaje = "" Then
                    U_Gramaje = "0"
                End If

                If Cajas = "" Then
                    Cajas = "0"
                End If
                If Marca = "" Then
                    Marca = "Sin Marca"
                End If
                If Precio = "" Then
                    Precio = "0"
                End If
                If sector = "" Then
                    sector = "10"
                End If
                If Conb1 = True Then
                    Bo1 = "1"
                Else
                    Bo1 = "0"
                End If



                If ItemCode <> "" And Descripcion <> "" And sector <> "" And Cantidad <> "" And Total <> "" And U_Gramaje <> "" And Unidades_x_Caja <> "" And CodeBars <> "" And Cajas <> "" And Bodega <> "" And Marca <> "" Then
                    Class_VariablesGlobales.Obj_Funciones_SQL.GUARDA_ReporteCargaXSector(Consecutivo, Fecha, Hora, Chequeado, Ruta, Bodeguero, ItemCode, Descripcion, sector, Cantidad, Total, TotalPesoXLinea, Unidades_x_Caja, CodeBars, Cajas, Faltante, Motivo, Bodega, Marca, Precio, txt_FacturaINI, txt_FacturaFIN, Bo1, Class_VariablesGlobales.Log_Usuario, SQL_Comman, Sacado)
                End If

                ItemCode = ""
                Descripcion = ""
                sector = ""
                Cantidad = ""
                Total = ""
                U_Gramaje = ""
                Unidades_x_Caja = ""
                CodeBars = ""
                Cajas = ""
                Bodega = ""
                Marca = ""
                Precio = ""
                CONT += 1
            Next
        Catch ex As Exception
            MessageBox.Show("ERROR EN GUARDA_Reporte " & ex.Message)
            VariablesGlobales.Obj_Log.Log("ERROR en GUARDA_Reporte ('" & Consecutivo & "' ) [ " & ex.Message & " ]", "Otros")

        End Try

        Valores(0) = TotalReporte
        Valores(1) = TotalPeso
        Valores(2) = "0.0"
        Return Valores
    End Function
    'Divide el reporte segun el sector
    Public Function CreaArchivo(ByVal ConsecutivoRepCarga As String, ByVal tbl_reporte As DataTable, ByVal ruta As String, ByVal CodBodeguero As String)

        Try


            Dim ftp_Admin As New Class_FTP


            Dim CONT As Integer
            Dim ItemCode As String
            Dim Descripcion As String
            Dim sector As String
            Dim Cantidad As String
            Dim Total As String
            Dim U_Gramaje As String
            Dim Unidades_x_Caja As String
            Dim CodeBars As String
            Dim Cajas As String
            Dim Bodega As String
            Dim Marca As String

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
            Dim RutaBase As String = "M:\IMPORTACION\Reportes_De_Carga_X_Sector"


            'CREA LA CARPETA DEL DIA
            If Directory.Exists(RutaBase & "\" & Fecha) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(RutaBase & "\" & Fecha)
            End If

            'CREA LA DEL SECTOR

            If Directory.Exists(RutaBase & "\" & Fecha & "\" & CodBodeguero) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(RutaBase & "\" & Fecha & "\" & CodBodeguero)
            End If

            Cursor.Current = Cursors.WaitCursor
            'Crea el archivo
            PathArchivo = RutaBase & "\" & Fecha & "\" & CodBodeguero & "\RepCarga_" & ConsecutivoRepCarga & ".mbg" ' Se determina el nombre del archivo 

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo

            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura


            For CONT = 0 To tbl_reporte.Rows.Count - 1
                If tbl_reporte.Rows(CONT)("ItemCode").ToString() <> "" Then
                    ItemCode = tbl_reporte.Rows(CONT)("ItemCode").ToString()
                Else
                    ItemCode = "0"
                End If

                If tbl_reporte.Rows(CONT)("Descripcion").ToString() <> "" Then
                    Descripcion = tbl_reporte.Rows(CONT)("Descripcion").ToString()
                Else
                    Descripcion = "0"
                End If

                If tbl_reporte.Rows(CONT)("sector").ToString() <> "" Then
                    sector = CInt(tbl_reporte.Rows(CONT)("sector").ToString())
                Else
                    sector = "0"
                End If

                If tbl_reporte.Rows(CONT)("Cantidad").ToString() <> "" Then
                    Cantidad = CInt(tbl_reporte.Rows(CONT)("Cantidad").ToString())
                Else
                    Cantidad = "0"
                End If

                If tbl_reporte.Rows(CONT)("Total").ToString() <> "" Then
                    Total = CDbl(tbl_reporte.Rows(CONT)("Total").ToString())
                Else
                    Total = "0"
                End If

                If tbl_reporte.Rows(CONT)("U_Gramaje").ToString() <> "" Then
                    U_Gramaje = tbl_reporte.Rows(CONT)("U_Gramaje").ToString()
                Else
                    U_Gramaje = "0"
                End If

                If tbl_reporte.Rows(CONT)("Unidades_x_Caja").ToString() <> "" Then
                    Unidades_x_Caja = CInt(tbl_reporte.Rows(CONT)("Unidades_x_Caja").ToString())
                Else
                    Unidades_x_Caja = "0"
                End If
                If tbl_reporte.Rows(CONT)("CodeBars").ToString() <> "" Then
                    CodeBars = tbl_reporte.Rows(CONT)("CodeBars").ToString()
                Else
                    CodeBars = "0"
                End If
                If tbl_reporte.Rows(CONT)("Cajas").ToString() <> "" Then
                    Cajas = CDbl(tbl_reporte.Rows(CONT)("Cajas").ToString())
                Else
                    Cajas = "0"
                End If
                If tbl_reporte.Rows(CONT)("Bodega").ToString() <> "" Then
                    Bodega = CDbl(tbl_reporte.Rows(CONT)("Bodega").ToString())
                Else
                    Bodega = "0"
                End If
                If tbl_reporte.Rows(CONT)("Marca").ToString() <> "" Then
                    Marca = tbl_reporte.Rows(CONT)("Marca").ToString()
                Else
                    Marca = "0"
                End If

                TotalRuta += Total




                Linea = Now.Date + "," + ruta + "," + ItemCode + "," + Descripcion + "," + sector + "," + Cantidad + "," + Total + "," + U_Gramaje + "," + Unidades_x_Caja + "," + CodeBars + "," + Cajas + "," + Bodega + "," + Marca + "," + ConsecutivoRepCarga

                'ESCRIBE LA LINEA EN EL ARCHIVO
                strStreamWriter.WriteLine(Linea)
                Linea = ""

                ItemCode = ""
                Descripcion = ""
                sector = ""
                Cantidad = ""
                Total = ""
                U_Gramaje = ""
                Unidades_x_Caja = ""
                CodeBars = ""
                Cajas = ""
                Bodega = ""
                Marca = ""
            Next

            ' LIMPIA MEMORIA
            CONT = Nothing
            ItemCode = Nothing
            Descripcion = Nothing
            sector = Nothing
            Cantidad = Nothing
            Total = Nothing
            U_Gramaje = Nothing
            Unidades_x_Caja = Nothing
            CodeBars = Nothing
            Cajas = Nothing
            Marca = Nothing
            Bodega = Nothing

            strStreamWriter.Close() ' cerramos
            'INICIO DE LIBERIACION DE MEMORIA
            sRenglon = Nothing
            strStreamW.Dispose()
            strStreamW = Nothing
            strStreamWriter.Dispose()
            strStreamWriter = Nothing


            ftp_Admin.Subir(PathArchivo, Class_VariablesGlobales.XMLParamFTP_Server & "Picking/" & CodBodeguero & "/impo/RepCarga_" & ConsecutivoRepCarga & ".mbg", Class_VariablesGlobales.XMLParamFTP_user, Class_VariablesGlobales.XMLParamFTP_Password)

        Catch ex As Exception
            MessageBox.Show("ERROR EN CreaArchivo  " & ex.Message)
        End Try

    End Function

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Limpiar.Click

        Limpia()
    End Sub

    Public Function Limpia()
        Try


            txtb_FACFIN.Text = ""
            txtb_FACINI.Text = ""
            txtb_Ruta.Text = ""

            Lbl_Peso.Text = "Kg 0"

            Lb_lAnulado.Visible = False
            'btn_Anular.Enabled = True
            'btn_Anular.Enabled = False


            lbl_TotalRuta.Text = FormatCurrency(0)
            txb_Numero.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivoRepCarga(Class_VariablesGlobales.SQL_Comman2, "Carga")

            For i As Integer = 0 To DataGV_RepCarSec.RowCount - 2
                DataGV_RepCarSec.Rows.Remove(DataGV_RepCarSec.CurrentRow)
            Next
            'DataGV_RepCarSec.DataSource = ""
            'DataGV_RepCarSec.DataSource = New DataTable
            Class_VariablesGlobales.Obj_RepDCar.txtb_FACINI.Enabled = True
            Class_VariablesGlobales.Obj_RepDCar.txtb_FACFIN.Enabled = True
            Class_VariablesGlobales.Obj_RepDCar.txtb_Ruta.Enabled = True
            btn_Generar.Enabled = True
            txtb_Ruta.Focus()
        Catch ex As Exception
            MessageBox.Show("Error al Limpia")



        End Try
    End Function

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Buscar.Click
        Try


            Dim MDIForm As New Rutas_RepCarga
            MDIForm.MdiParent = Principal
            MDIForm.Show()
        Catch ex As Exception

        End Try
    End Sub
    Public Function BuscaReporte()
        Try

            Class_VariablesGlobales.Conse_Repcarga = txb_Numero.Text
            Dim selectedIndex As Integer
            selectedIndex = CBX_Sector.SelectedIndex
            Dim CUENTA As Integer
            Dim selectedItem As Object
            selectedItem = CBX_Sector.SelectedItem

            ' SQL_Comman.Connection = Obj_SQL_CONEXION_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")

            If CBX_Linea.Text = "Faltantes" And Class_VariablesGlobales.Conse_Repcarga <> Nothing Then
                Class_VariablesGlobales.Tbl_RepCarga = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepCarXSector("FALTANTES", selectedItem, Class_VariablesGlobales.Conse_Repcarga, Class_VariablesGlobales.SQL_Comman2, "")
            ElseIf CBX_Linea.Text = "Chequeado" And Class_VariablesGlobales.Conse_Repcarga <> Nothing Then
                Class_VariablesGlobales.Tbl_RepCarga = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepCarXSector("CHEQUEADO", selectedItem, Class_VariablesGlobales.Conse_Repcarga, Class_VariablesGlobales.SQL_Comman2, "")
            ElseIf CBX_Linea.Text = "No Chequeado" And Class_VariablesGlobales.Conse_Repcarga <> Nothing Then
                Class_VariablesGlobales.Tbl_RepCarga = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepCarXSector("NOCHEQUEADO", selectedItem, Class_VariablesGlobales.Conse_Repcarga, Class_VariablesGlobales.SQL_Comman2, "")

            ElseIf CBX_Linea.Text = "Sacado" And Class_VariablesGlobales.Conse_Repcarga <> Nothing Then
                Class_VariablesGlobales.Tbl_RepCarga = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepCarXSector("SACADO", selectedItem, Class_VariablesGlobales.Conse_Repcarga, Class_VariablesGlobales.SQL_Comman2, "")
            ElseIf CBX_Linea.Text = "No Sacado" And Class_VariablesGlobales.Conse_Repcarga <> Nothing Then
                Class_VariablesGlobales.Tbl_RepCarga = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepCarXSector("NOSACADO", selectedItem, Class_VariablesGlobales.Conse_Repcarga, Class_VariablesGlobales.SQL_Comman2, "")
            ElseIf CBX_Linea.Text = "TODOS" Then
                Class_VariablesGlobales.Tbl_RepCarga = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepCarXSector("TODO", selectedItem, Class_VariablesGlobales.Conse_Repcarga, Class_VariablesGlobales.SQL_Comman2, "")
            End If

            DataGV_RepCarSec.DataSource = Class_VariablesGlobales.Tbl_RepCarga


            Dim tabla As New DataTable
            Dim cont As Integer
            Dim TotalFaltante As Double
            Dim TotalPeso As Double
            Dim Total As Double


            tabla = Class_VariablesGlobales.Tbl_RepCarga

            For Each rowLocal As DataRow In tabla.Rows

                Total += CDbl(tabla.Rows(cont).Item("Total").ToString())

                If tabla.Rows(cont).Item("U_Gramaje").ToString() <> "" Then
                    TotalPeso += CDbl(CInt(tabla.Rows(cont).Item("U_Gramaje").ToString()) * CInt(tabla.Rows(cont).Item("Cantidad").ToString()))
                Else
                    TotalPeso += CDbl(CInt("0") * CInt(tabla.Rows(cont).Item("Cantidad").ToString()))
                End If

                If tabla.Rows(cont).Item("Faltante_Chequeador").ToString() <> "" Then
                    TotalFaltante += CDbl(CInt(tabla.Rows(cont).Item("Faltante_Chequeador").ToString()) * (CDbl(tabla.Rows(cont).Item("Total").ToString()) / CInt(tabla.Rows(cont).Item("Cantidad").ToString())))
                Else
                    TotalFaltante += CDbl("0")
                End If
                cont += 1
            Next

            Dim peso As Double
            peso = TotalPeso / 1000
            If peso > 1000 Then
                Class_VariablesGlobales.Obj_RepDCar.Lbl_Peso.Text = "T " & FormatNumber(peso / 1000)
            Else

                Class_VariablesGlobales.Obj_RepDCar.Lbl_Peso.Text = "Kg " & FormatNumber(peso)
            End If

            Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_TotalRuta.Text = Format(Val(Total), "currency")
            Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_TotalChequeo.Text = Format(Val(Class_VariablesGlobales.Obj_Funciones_SQL.SumaChequeadoRepCarga(Class_VariablesGlobales.CheqRC_Consecutivo, Class_VariablesGlobales.SQL_Comman)), "currency")
            Dim TRuta As Double = CDbl(Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_TotalRuta.Text)

            Dim TChequeado As Double = CDbl(Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_TotalChequeo.Text)


            Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_Diferencia.Text = Format(Val(TRuta - TChequeado), "currency")

            Class_VariablesGlobales.Obj_RepDCar.lbl_TotalFaltante.Text = FormatCurrency(TotalFaltante)
        Catch ex As Exception
            'MessageBox.Show("Error en BuscaReporte")


        End Try
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBX_Sector.SelectedIndexChanged
        ' BuscaReporte()
    End Sub
    Private Sub RB_Chec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RB_NOChec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' BuscaReporte()
    End Sub

    Private Sub RB_Sac_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'BuscaReporte()
    End Sub

    Private Sub RB_NoSac_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' BuscaReporte()
    End Sub

#End Region

    Private Sub txt_ruta_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtb_FACINI_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_FACINI.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtb_FACFIN_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_FACFIN.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btn_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cerrar.Click

        If btn_cerrar.Text = "Cerrar" Then

            Dim result1 As DialogResult = MessageBox.Show("Si cierre el reporte desaparecera del software Picking, Realmente desea Cerrar el reporte de carga ?", "IMPORTANTE", MessageBoxButtons.YesNo)
            If result1 = DialogResult.No Then
                'NO
            Else
                'SI
                Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaEstadoReporte(txb_Numero.Text, Class_VariablesGlobales.SQL_Comman1, "1")
                CargaDetRepCarga(Class_VariablesGlobales.SQL_Comman2, CInt(txb_Numero.Text), "")
                btn_cerrar.Image = My.Resources.Abrir1
                btn_cerrar.Text = "Abrir"
            End If

        Else

            Dim result1 As DialogResult = MessageBox.Show("Si abre el reporte aparecera nuevamente en el software Picking, Realmente desea Abrir el reporte de carga ?", "IMPORTANTE", MessageBoxButtons.YesNo)
            If result1 = DialogResult.No Then
                'NO
            Else
                'SI
                Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaEstadoReporte(txb_Numero.Text, Class_VariablesGlobales.SQL_Comman1, "0")
                CargaDetRepCarga(Class_VariablesGlobales.SQL_Comman2, CInt(txb_Numero.Text), "")
                btn_cerrar.Image = My.Resources.candado1
                btn_cerrar.Text = "Cerrar"
            End If

        End If





    End Sub

    Private Sub DataGV_RepCarSec_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGV_RepCarSec.CellContentClick

        Class_VariablesGlobales.ConseRepCarga = DataGV_RepCarSec.Item(0, DataGV_RepCarSec.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.CodArti = DataGV_RepCarSec.Item(1, DataGV_RepCarSec.CurrentRow.Index).Value.ToString()

        EditaRepCarga.Show()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmReporte.Show()

    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Anular.Click
        Dim result As Integer = MessageBox.Show("Si Anula el reporte no podra recuperarlo" & vbCrLf & "Esta Seguro que desea Anular el reporte?", "CONFIRMAR", MessageBoxButtons.OKCancel)
        If result = DialogResult.OK Then


            Class_VariablesGlobales.ConsecutivoRepFactura = txb_Numero.Text
            trd3 = New Thread(AddressOf FuncionEn_BackGroud2)
            trd3.IsBackground = Enabled
            'trd2.Priority = ThreadPriority.Highest
            CheckForIllegalCrossThreadCalls = False
            trd3.Start()
        ElseIf result = DialogResult.Cancel Then
        End If
    End Sub

    Public Function FuncionEn_BackGroud2()
        Try
            Me.Enabled = False
            Dim SECTORES As Integer = 10
            Dim CONT As Integer = 1
            Class_VariablesGlobales.Conse_Repcarga = Trim(Class_VariablesGlobales.ConsecutivoRepFactura)
            'Anula el reporte en la base de datos, no se borra para que quede registro de que se creo
            If Class_VariablesGlobales.Obj_Funciones_SQL.AnulaRepCarga(Class_VariablesGlobales.Conse_Repcarga, Class_VariablesGlobales.SQL_Comman2) = 0 Then



                'En caso de que algun bodeguero descargara el reporte de carga , el sistema al anular el reporte les enviara un correo indicando cual reporte deberan anular
                Dim mensaje As String = "EL REPORTE DE LA RUTA[" & txtb_Ruta.Text & "] FUE ANULADO" & vbCrLf & _
                                                     "Desarrollador: Luis Roberto Bastos C" & vbCrLf & vbCrLf & _
                                                    "Bach: Informatica Emplesarial and Lic: Desarrollo Paginas WEB" & vbCrLf & _
                                                    "E-mail: lurobaca@gmail.com" & vbCrLf & _
                                                    "Tel: 8880-1662" & vbCrLf

                Class_VariablesGlobales.Obj_MAIL.EnviarCorreo(mensaje, "REPORTE DE LA RUTA [" & txtb_Ruta.Text & "] FUE ANULADO Consecutivo [ " & CInt(Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivoRepCarga(Class_VariablesGlobales.SQL_Comman2, "Carga")) & " ]", "", "bodeguerosbourne@gmail.com", "", "", "")
                Me.Enabled = True
                MessageBox.Show("Reporte Anulado con exito")
                CargaDetRepCarga(Class_VariablesGlobales.SQL_Comman2, CInt(Class_VariablesGlobales.Conse_Repcarga), "")
                ' MessageBox.Show(SectoresNoEliminados)
            Else

            End If


        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN FuncionEn_BackGroud2 [ " & ex.Message & " ]")
        End Try
    End Function

    Private Sub txtb_Ruta_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_Ruta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub






    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub btn_Recargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CargaDetRepCarga(Class_VariablesGlobales.SQL_Comman2, CInt(txb_Numero.Text), txtb_BuscDescripcion.Text)

    End Sub




    Public Function CargaDetRepCarga(ByVal SQL_Comman As SqlCommand, ByVal Conse_Repcarga As String, ByVal Palabra As String)
        Try

            CBX_Sector.Text = "TODOS"
            CBX_Linea.Text = "TODOS"

            Dim tabla As New DataTable
            Dim cont As Integer
            Dim TotalFaltante As Double
            Dim TotalPeso As Double
            Dim Total As Double

            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            ' SQL_Comman.Connection = Obj_SQL_CONEXION_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")

            tabla = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepCarXSector("TODO", "0", Conse_Repcarga, SQL_Comman, Palabra)

            If tabla.Rows.Count > 0 Then


            End If

            For Each rowLocal As DataRow In tabla.Rows

                Total += CDbl(tabla.Rows(cont).Item("Total").ToString())

                If tabla.Rows(cont).Item("U_Gramaje").ToString() <> "" Then
                    'TotalPeso += CDbl(CInt(tabla.Rows(cont).Item("U_Gramaje").ToString()) * CInt(tabla.Rows(cont).Item("Cantidad").ToString()))
                    TotalPeso += CDbl(tabla.Rows(cont).Item("U_Gramaje").ToString())
                Else
                    TotalPeso += CDbl("0")
                End If

                If tabla.Rows(cont).Item("Faltante_Chequeador").ToString() <> "" Then
                    TotalFaltante += CDbl(CInt(tabla.Rows(cont).Item("Faltante_Chequeador").ToString()) * (CDbl(tabla.Rows(cont).Item("Total").ToString()) / CInt(tabla.Rows(cont).Item("Cantidad").ToString())))
                Else
                    TotalFaltante += CDbl("0")
                End If
                cont += 1
            Next

            'si no es llamado desde chequeo de reporte
            If Class_VariablesGlobales.ChequeadoBuscaRuta = False Then

                Class_VariablesGlobales.Obj_RepDCar.btn_cerrar.Visible = True
                If tabla.Rows(0).Item("Cerrado").ToString() = "1" Then

                    btn_cerrar.Image = My.Resources.Abrir1
                    btn_cerrar.Text = "Abrir"
                    'Class_VariablesGlobales.Obj_RepDCar.btn_cerrar.Visible = False
                    Class_VariablesGlobales.Obj_RepDCar.Lb_Cerrado.Visible = True
                Else
                    btn_cerrar.Image = My.Resources.candado1
                    btn_cerrar.Text = "Cerrar"
                    'Class_VariablesGlobales.Obj_RepDCar.btn_cerrar.Visible = True
                    Class_VariablesGlobales.Obj_RepDCar.Lb_Cerrado.Visible = False
                End If




                If tabla.Rows(0).Item("Anulado").ToString() = "1" Then
                    'Class_VariablesGlobales.Obj_RepDCar.btn_Anular.Visible = False
                    Class_VariablesGlobales.Obj_RepDCar.Lb_lAnulado.Visible = True
                    'Class_VariablesGlobales.Obj_RepDCar.btn_cerrar.Visible = False

                Else
                    ' Class_VariablesGlobales.Obj_RepDCar.btn_Anular.Visible = True
                    Class_VariablesGlobales.Obj_RepDCar.Lb_lAnulado.Visible = False
                    ' Class_VariablesGlobales.Obj_RepDCar.btn_Anular.Visible = True
                    'Class_VariablesGlobales.Obj_RepDCar.btn_Anular.BackColor = Color.White
                    Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.ReadOnly = True


                End If

                Dim peso As Double
                'tranforma los gramos a kg
                peso = TotalPeso / 1000
                If peso > 1000 Then
                    Class_VariablesGlobales.Obj_RepDCar.Lbl_Peso.Text = "T " & FormatNumber(peso / 1000)
                Else

                    Class_VariablesGlobales.Obj_RepDCar.Lbl_Peso.Text = "Kg " & FormatNumber(peso)
                End If

                Class_VariablesGlobales.Obj_RepDCar.lbl_TotalFaltante.Text = FormatCurrency(TotalFaltante)
                Class_VariablesGlobales.Obj_RepDCar.txb_Numero.Text = tabla.Rows(0).Item("Consecutivo").ToString()
                Class_VariablesGlobales.Obj_RepDCar.txtb_Ruta.Text = tabla.Rows(0).Item("Ruta").ToString()
                Class_VariablesGlobales.Obj_RepDCar.dtp_FechaReporte.Text = tabla.Rows(0).Item("Fecha").ToString()
                Class_VariablesGlobales.Obj_RepDCar.TXB_Hora.Text = tabla.Rows(0).Item("Hora").ToString()
                Class_VariablesGlobales.Obj_RepDCar.txtb_FACINI.Text = tabla.Rows(0).Item("FacINI").ToString()
                Class_VariablesGlobales.Obj_RepDCar.txtb_FACFIN.Text = tabla.Rows(0).Item("FacFIN").ToString()
                Dim ConB1 As String = tabla.Rows(0).Item("ConB1").ToString()
                Class_VariablesGlobales.Obj_RepDCar.lbl_TotalRuta.Text = Format(Val(Total), "currency")
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.DataSource = tabla
                Class_VariablesGlobales.Obj_RepDCar.txtb_FACINI.Enabled = False
                Class_VariablesGlobales.Obj_RepDCar.txtb_FACFIN.Enabled = False
                Class_VariablesGlobales.Obj_RepDCar.txtb_Ruta.Enabled = False
                Class_VariablesGlobales.Obj_RepDCar.Rb_ConBod1.Enabled = False
                Class_VariablesGlobales.Obj_RepDCar.Rb_SinBod1.Enabled = False
                Class_VariablesGlobales.Obj_RepDCar.btn_Generar.Enabled = False

                If ConB1 = "1" Then
                    Class_VariablesGlobales.Obj_RepDCar.Rb_SinBod1.Checked = False
                    Class_VariablesGlobales.Obj_RepDCar.Rb_ConBod1.Checked = True
                Else
                    Class_VariablesGlobales.Obj_RepDCar.Rb_SinBod1.Checked = True
                    Class_VariablesGlobales.Obj_RepDCar.Rb_ConBod1.Checked = False
                End If



                Class_VariablesGlobales.Obj_RepDCar.btn_Limpiar.Enabled = True

                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(28).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(0).Visible = False 'Consecutivo
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(1).Width = 75 'Codigo articulo
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(2).Width = 350 'Decripcion
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(3).Width = 45 'Sector
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(4).Width = 60 'Cantidad
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(4).DefaultCellStyle.BackColor = Color.Orange

                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(5).Width = 60 'Total
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(6).Width = 105 'Barras
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(7).Width = 40 'Bodega
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(8).Width = 140 'Bodeguero
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(8).DefaultCellStyle.BackColor = Color.LightGreen
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(9).Width = 45 'Faltante Bodeguero
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(9).DefaultCellStyle.BackColor = Color.LightGreen
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(10).Width = 140 'Motivo Bodeguero
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(10).DefaultCellStyle.BackColor = Color.LightGreen

                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(11).Width = 140 'Nombre Chequeador
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(11).DefaultCellStyle.BackColor = Color.LightBlue
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(12).Width = 45
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(12).DefaultCellStyle.BackColor = Color.LightBlue
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(13).Width = 140
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(13).DefaultCellStyle.BackColor = Color.LightBlue

                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(5).Visible = False

                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(13).Visible = True
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(14).Visible = False
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(15).Visible = False
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(16).Visible = False
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(17).Visible = False
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(18).Visible = False
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(19).Visible = False
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(20).Visible = False
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(21).Visible = False
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(22).Visible = False
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(23).Visible = False
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(24).Visible = False
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(25).Visible = False
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(26).Visible = False
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(27).Visible = False
                Class_VariablesGlobales.Obj_RepDCar.DataGV_RepCarSec.Columns(28).Visible = False 'SACADO si/no
            Else
                Class_VariablesGlobales.Obj_ChequearRepCarga = New ChequearRepCarga
                Class_VariablesGlobales.Obj_ChequearRepCarga.MdiParent = Principal
                Class_VariablesGlobales.Obj_ChequearRepCarga.Show()

                ' Class_VariablesGlobales.Obj_ChequearRepCarga.Dtg_Chequeado.DataSource = tabla

                Dim peso As Double
                peso = TotalPeso / 1000
                If peso > 1000 Then
                    Class_VariablesGlobales.Obj_ChequearRepCarga.Lbl_Peso.Text = "T " & FormatNumber(peso / 1000)
                Else

                    Class_VariablesGlobales.Obj_ChequearRepCarga.Lbl_Peso.Text = "Kg " & FormatNumber(peso)
                End If

                Class_VariablesGlobales.Obj_ChequearRepCarga.txtb_Numruta.Text = tabla.Rows(0).Item("Consecutivo").ToString()
                Class_VariablesGlobales.CheqRC_Consecutivo = tabla.Rows(0).Item("Consecutivo").ToString()
                Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_Ruta.Text = tabla.Rows(0).Item("Ruta").ToString()

                Class_VariablesGlobales.Obj_ChequearRepCarga.Dtg_Chequeado.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.LineaRepCachequeado(SQL_Comman, Class_VariablesGlobales.CheqRC_Consecutivo)

                Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_TotalRuta.Text = Format(Val(Total), "currency")
                Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_TotalChequeo.Text = Format(Val(Class_VariablesGlobales.Obj_Funciones_SQL.SumaChequeadoRepCarga(Class_VariablesGlobales.CheqRC_Consecutivo, SQL_Comman)), "currency")
                Dim TRuta As Double = CDbl(Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_TotalRuta.Text)
                Dim TChequeado As Double = CDbl(Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_TotalChequeo.Text)
                Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_Diferencia.Text = Format(Val(TRuta - TChequeado), "currency")
            End If
        Catch ex As Exception


            MessageBox.Show("Error al cargar Reporte " & ex.Message)
        End Try
    End Function

    Private Sub Btn_Atras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Atras.Click

        CargaDetRepCarga(Class_VariablesGlobales.SQL_Comman2, CInt(txb_Numero.Text) - 1, "")


    End Sub

    Private Sub Btn_Adelante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Adelante.Click
        CargaDetRepCarga(Class_VariablesGlobales.SQL_Comman2, CInt(txb_Numero.Text) + 1, "")

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBX_Linea.SelectedIndexChanged
        ' BuscaReporte()
    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        Dim Pregunta As Integer

        Pregunta = MsgBox("¿Desea imprimir el Reporte de carga?.", vbYesNo + vbExclamation + vbDefaultButton2, "IMPRIMIR REPORTE DE CARGA")

        If Pregunta = vbYes Then
            Class_VariablesGlobales.IMPRIMIENDO = "RepCarga"
            Imprimir()
        Else

        End If
    End Sub

    Public Function Imprimir()

        Class_VariablesGlobales.ReporteCarga_Consecutivo = Trim(txb_Numero.Text)

        frmReporte.Show()
    End Function



    Private Sub ToolTip1_Popup(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PopupEventArgs) Handles ToolTip1.Popup
        txtb_Ruta.Text = "Digite la ruta"
    End Sub

    Private Sub btn_Faltantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Faltantes.Click
        Dim Pregunta As Integer

        Pregunta = MsgBox("¿Desea imprimir Faltantes?.", vbYesNo + vbExclamation + vbDefaultButton2, "IMPRIMIR FALTANTES")

        If Pregunta = vbYes Then
            Class_VariablesGlobales.IMPRIMIENDO = "RepFaltante"
            Imprimir()
        Else

        End If
    End Sub


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Class_VariablesGlobales.Obj_Reporte_Facturas = New Reporte_Facturas

        Class_VariablesGlobales.Obj_Reporte_Facturas.MdiParent = Principal

        Class_VariablesGlobales.Obj_Reporte_Facturas.Show()

        Class_VariablesGlobales.Conse_RepFacturas = txb_Numero.Text


        Class_VariablesGlobales.Obj_Reporte_Facturas.CargaDetRepFacturas(Class_VariablesGlobales.SQL_Comman2, Class_VariablesGlobales.Conse_RepFacturas)

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_BuscDescripcion.KeyPress
        CargaDetRepCarga(Class_VariablesGlobales.SQL_Comman2, CInt(txb_Numero.Text), txtb_BuscDescripcion.Text)
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class