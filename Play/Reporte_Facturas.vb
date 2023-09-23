Imports System.Threading
Imports System.IO
Imports System.Data.SqlClient

Public Class Reporte_Facturas
    Dim Servidor As Integer = 1
    Public trd2, trd3 As Thread
    Public Obj_ClearM As New ClearMemory
    Private Sub btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Limpiar.Click
        Navegar(CInt(txb_Numero.Text) + 1)
        'Me.Close()


        'Class_VariablesGlobales.Obj_Reporte_Facturas = New Reporte_Facturas

        'Class_VariablesGlobales.Obj_Reporte_Facturas.MdiParent = Me
        'Class_VariablesGlobales.Obj_Reporte_Facturas.Show()
    End Sub


    Public Function FuncionEn_BackGroud()
        Try
            VariablesGlobales.Obj_Log.Log("FuncionEn_BackGroud Inicia Generacion de Reporte de facturas " & txb_Numero.Text, "Otros")
            btn_GenerarEnviar.Enabled = False
            btn_Buscar.Enabled = False
            btn_Limpiar.Enabled = False

            ' para la conexion al comman
            '    SQL_Comman.Connection = Obj_SQL_CONEXION_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")

            'SE DEBE VERIFICAR QUE EL CONSECUTIVO NO ESTE EN USO
            If Class_VariablesGlobales.Obj_Funciones_SQL.VerificaExistRepFAc(txb_Numero.Text, Class_VariablesGlobales.SQL_Comman2) Then

                txb_Numero.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaConsecutivoRepRepFacturas(Class_VariablesGlobales.SQL_Comman2)
                txb_Numero.Text = CInt(txb_Numero.Text) + 1 'Aqui aumenta el consecutivo ya que el que busco ya esta en uso
                FuncionEn_BackGroud()
            Else
                'el consecutivo no se ha usado, caso normal
            End If

            Dim Totales(6) As Double
            Dim TotalReporte As Double
            Dim TotalContado As Double
            Dim TotalCredito As Double

            Dim SubTotalContado As Double
            Dim SubTotalCredito As Double

            Dim ImpuestoContado As Double
            Dim ImpuestoCredito As Double

            Dim agente As String
            Dim tbl_reporte As New DataTable
            Dim tbl_Agentes As New DataTable
            Dim Tbl_Clientes As New DataTable
            '9 SECTORES Y BLANCO ES BONIDICACION
            Dim SECTORES As Integer = 10
            Dim CONT As Integer = 1
            Dim conse As Integer = 0
            bar_ProgresSector.Minimum = 0
            bar_ProgresSector.Maximum = 100
            bar_ProgresSector.Value = 0
            Dim Consecutivo As String
            Dim FacGenerada As Boolean

            Dim CodChofer As String = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneCodChofer(Class_VariablesGlobales.SQL_Comman2, "TODOS", Cbx_Chofer.Text)

            If Rb_SinBod1.Checked = True Then
                'sin crea un reporte de carga con bodega 1
                FacGenerada = False

            Else
                'si genera el reporte SIN bodega 1
                'If Trim(txtb_FACINI.Text) > Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaUltimaFactura(Class_VariablesGlobales.SQL_Comman2, "Carga") Then
                '    FacGenerada = False
                'Else
                FacGenerada = False
                'End If

            End If

            If FacGenerada = False Then
                'obtiene el reporte de facturas
                tbl_reporte = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneReporteFacturas(Rb_ConBod1.Checked, Trim(txtb_FACINI.Text), Trim(txtb_FACFIN.Text), Class_VariablesGlobales.SQL_Comman2)

                'SE COMPRUEBA QUE LAS FACTURAS SELECCIONADAS NO ESTEN EN NINGUN OTRO REPORTE
                Dim Mensaje As String = ""
                Dim Datos As New DataTable

                'Datos = Obj_Funciones_SQL.CompruebaRangoFActuras(Trim(txtb_FACINI.Text), Trim(txtb_FACFIN.Text), Class_VariablesGlobales.SQL_Comman2)

                'Dim contador As Integer = 0
                'If Datos.Rows.Count > 0 Then
                '    For Each rowLocal As DataRow In Datos.Rows
                '        If Datos.Rows(0).Item("Consecutivo").ToString() <> "" Then
                '            Mensaje &= "Almenos 1 factura entre el rango [" & Trim(txtb_FACINI.Text) & " - " & Trim(txtb_FACFIN.Text) & "] Existe en el reporte [" & Datos.Rows(0).Item("Consecutivo").ToString() & "] " & vbLf & "COMPRUEBE EL RANGO Y VUELVA A INTERNARLO"
                '        End If
                '    Next
                'End If

                Datos = Nothing
                If Mensaje <> "" Then
                    'MessageBox.Show(Mensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    btn_GenerarEnviar.Enabled = True
                    btn_Buscar.Enabled = True
                    btn_Limpiar.Enabled = True
                    btn_eliminar.Enabled = True
                    Exit Function
                Else
                End If

                'obtiene los agentes del reporte de facturas
                'para luego cargar las cxc
                'tbl_reporte = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneReporteFacturas(Rb_ConBod1.Checked, Trim(txtb_FACINI.Text), Trim(txtb_FACFIN.Text), Class_VariablesGlobales.SQL_Comman2)

                'tbl_Agentes = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAgentesReporteFacturas(Rb_ConBod1.Checked, Trim(txtb_FACINI.Text), Trim(txtb_FACFIN.Text), Class_VariablesGlobales.SQL_Comman2)

                Consecutivo = txb_Numero.Text

                'NO DEBE GUARDARSE HASTA QUE LE DEN OK

                Totales = ObtieneTotalesRepFac(tbl_reporte, Class_VariablesGlobales.SQL_Comman2)
                TotalReporte = Totales(0)
                TotalContado = Totales(1)
                TotalCredito = Totales(2)
                SubTotalContado = Totales(3)
                SubTotalCredito = Totales(4)
                ImpuestoContado = Totales(5)
                ImpuestoCredito = Totales(6)

                Dim result As Integer = MessageBox.Show(" Ruta [ " & txtb_Ruta.Text & " ] " & vbCrLf & " Desde [   " & txtb_FACINI.Text & "   ] Hasta [   " & txtb_FACFIN.Text & "   ] " & vbCrLf & " TOTAL CONTADO [ " & FormatCurrency(TotalContado) & " ]" & vbCrLf & " TOTAL CREDITO [ " & FormatCurrency(TotalCredito) & " ]" & vbCrLf & vbCrLf & " TOTAL GENERAL [ " & FormatCurrency(TotalReporte) & " ]", "REVICION DE DATOS ", MessageBoxButtons.OKCancel)

                If result = DialogResult.OK Then


                    'luego recorremos el reporte extrallendo cada sector y eliminandolo de la tabla 
                    GUARDA_Reporte(Rb_ConBod1.Checked, tbl_reporte, Consecutivo, Trim(txtb_FACINI.Text), Trim(txtb_FACFIN.Text), Trim(dtp_FechaReporte.Text), Trim(TXB_Hora.Text), CodChofer, Cbx_Ayuda.Text, Class_VariablesGlobales.SQL_Comman2)

                    'TotalReporte = Totales(0)
                    'TotalContado = Totales(1)
                    'TotalCredito = Totales(2)

                    Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaConsecutivoRepRepFacturas(Class_VariablesGlobales.SQL_Comman2, CInt(Consecutivo) + 1)
                    'Dim TotalRepFacturas As Double = Obj_Funciones_SQL.ObtieneTotalReporteFacturas(False, Trim(txtb_FACINI.Text), Trim(txtb_FACFIN.Text), SQL_Comman2)
                    'If (Math.Round(TotalReporte, 2) = Math.Round(TotalRepFacturas, 2)) Then
                    lbl_Total.Text = FormatCurrency(TotalReporte)
                    'muestra el total y preguntara si desea enviar el reporte a los bodegueros


                    'envia reporte
                    Dim Dia As String = Now.Date.Day
                    Dim Mes As String = Now.Date.Month
                    Dim Ano As String = Now.Date.Year
                    Dim Fecha As String = Dia & "-" & Mes & "-" & Ano

                    bar_ProgresSector.Value = CONT


                    Class_VariablesGlobales.Obj_Reporte_Facturas.CargaDetRepFacturas(Class_VariablesGlobales.SQL_Comman2, Trim(txb_Numero.Text))

                    'If Class_VariablesGlobales.Puesto = "Facturacion" Then
                    '    Imprimir()
                    'End If


                    'no guarda la ultima factura del reporte que se genere con bodega 1
                    If Rb_ConBod1.Checked = False Then
                        Class_VariablesGlobales.Obj_Funciones_SQL.InsertaUltimFactura(Class_VariablesGlobales.SQL_Comman2, Trim(txtb_FACFIN.Text), "Carga")
                    End If

                    btn_Imprimir.Focus()

                    ' Obj_SQL_CONEXION_CONEXION.Desconectar(SQL_Comman2)

                    'SOLO PARA EL FACTURADOR  'AQUI DEBERA LLAMAR A LA FUNCION QUE CREARA EL REPORTE DE CARGA

                    If Class_VariablesGlobales.Puesto = "Facturacion" Then
                        'GuardaRepCarga(txb_Numero.Text)

                        'Class_VariablesGlobales.IMPRIMIENDO = "RepCarga"
                        'Class_VariablesGlobales.ReporteCarga_Consecutivo = Trim(txb_Numero.Text)
                        'frmReporte.Show()
                    Else
                        'Generado por otro usuario que no es el facturador por loq
                        Dim Pregunta As Integer

                        Pregunta = MsgBox("Reporte de Facturas Generado con Existo", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "REPORTE GENERADO")
                        If Pregunta = vbYes Then
                            Navegar(CInt(txb_Numero.Text) + 1)

                            'Me.Close()
                            'Class_VariablesGlobales.Obj_Reporte_Facturas = New Reporte_Facturas

                            'Class_VariablesGlobales.Obj_Reporte_Facturas.MdiParent = Me
                            'Class_VariablesGlobales.Obj_Reporte_Facturas.Show()

                        Else

                        End If

                    End If




                    '----------------SI CANCELA EL MSJ POR QUE NOTO ALGUN ERROR ENTRA AQUIN-------------
                ElseIf result = DialogResult.Cancel Then

                    btn_GenerarEnviar.Focus()
                End If

                'Else
                '    'los montos de facturas y reporte de carga no pegan
                '    MessageBox.Show("El Reporte de Carga [ " & FormatCurrency(TotalReporte) & " ] " & vbCrLf & "Reporte de facturas [ " & FormatCurrency(TotalRepFacturas) & " ] " & vbCrLf & "Diferencia [ " & FormatCurrency(TotalReporte - TotalRepFacturas) & " ]" & vbCrLf & "Rebice y vuelva a intentar generar el reporte", "REPORTES NO COINCIDEN")
                'End If

                'End If

            Else
                'lbl_Sectores.Text = "Factura de inicio ya fue Generada"


            End If




            Obj_ClearM.ClearMemory()
            trd2.Abort()
            Obj_ClearM = Nothing
            trd2 = Nothing
        Catch ex As Exception

            If ex.Message <> "Subproceso anulado." Then
                MessageBox.Show("ALERTA", "Hubo un problema al generar los reportes [ " & ex.Message & " ]", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


        End Try

        btn_GenerarEnviar.Enabled = True
        btn_Buscar.Enabled = True
        btn_Limpiar.Enabled = True
        btn_eliminar.Enabled = True


    End Function

    Public Function GuardaRepCarga(ByVal Consecutivo As String)
        Try


            Dim Obj_RepCarga As ReportesDeCarga
            Obj_RepCarga = New ReportesDeCarga
            Dim tbl_reporte As New DataTable
            'obtiene la lista de articulos en el sector definido
            tbl_reporte = Class_VariablesGlobales.Obj_Funciones_SQL.GeneraReporteCarga(Rb_ConBod1.Checked, Trim(txtb_FACINI.Text), Trim(txtb_FACFIN.Text), Class_VariablesGlobales.SQL_Comman2)

            'luego recorremos el reporte extrallendo cada sector y eliminandolo de la tabla 
            Dim TotalReporte As Double
            Dim TotalPeso As Double
            Dim TotalFaltante As Double
            Dim Valores(3) As Double
            Valores = Obj_RepCarga.GUARDA_Reporte(txtb_Ruta.Text, Rb_ConBod1.Checked, tbl_reporte, Consecutivo, Trim(txtb_FACINI.Text), Trim(txtb_FACFIN.Text), Trim(dtp_FechaReporte.Text), Trim(TXB_Hora.Text), Class_VariablesGlobales.SQL_Comman2)


            Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaConsecutivo(CInt(Consecutivo) + 1, Class_VariablesGlobales.SQL_Comman2, "Carga")




            Dim mensaje As String = "Nuevo Reporte de Carga por Sector De la ruta [" & txtb_Ruta.Text & "]" & vbCrLf & vbCrLf & _
                                    "Desarrollador: Luis Roberto Bastos C" & vbCrLf & _
                                    "Bach: Informatica Emplesarial and Lic: Desarrollo Paginas WEB" & vbCrLf & _
                                    "E-mail: lurobaca@gmail.com" & vbCrLf & _
                                    "Tel: 8880-1662" & vbCrLf

            Class_VariablesGlobales.Obj_MAIL.EnviarCorreo(mensaje, "Nuevo Reporte Ruta [" & txtb_Ruta.Text & "]", "", "", "", "", "")


            Dim Pregunta As Integer

            Pregunta = MsgBox("Reporte de Facturas y de Carga Generados con Existo", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "REPORTES GENERADOS")

            If Pregunta = vbYes Then
                Navegar(CInt(txb_Numero.Text) + 1)
                'Me.Close()
                'Class_VariablesGlobales.Obj_Reporte_Facturas = New Reporte_Facturas

                'Class_VariablesGlobales.Obj_Reporte_Facturas.MdiParent = Me
                'Class_VariablesGlobales.Obj_Reporte_Facturas.Show()

            Else

            End If
        Catch ex As Exception
            MsgBox("ERROR EN GuardaRepCarga  [ " & ex.Message & " ]", MsgBoxStyle.Critical)
            VariablesGlobales.Obj_Log.Log("ERROR EN GuardaRepCarga [ " & txb_Numero.Text & " ][ " & ex.Message & " ]", "Otros")
        End Try

    End Function
    'AUBE EL REPORT,CXC Y CLIENTES DEL REPORTE DE FACTURAS GENERADO
    Public Function SubeInfoAChofer()

    End Function


    Public Function ObtieneTotalesRepFac(ByVal tbl_reporte As DataTable, ByVal SQL_Comman As SqlCommand)
        Try


            Dim TotalReporte As Double
            Dim TotalContado As Double
            Dim SubTotalContado As Double
            Dim ImpuestoContado As Double

            Dim TotalCredito As Double
            Dim SubTotalCredito As Double
            Dim ImpuestoCredito As Double

            Dim Totales(6) As Double
            Dim DocTotal As Double
            Dim DocImpuesto As Double
            Dim DocSubTotal As Double
            Dim DocNum As String
            Dim FacAnterior As String


            Dim CONT As Integer
            Dim Condicion As String
            For Each row As DataRow In tbl_reporte.Rows
                DocTotal = 0
                DocImpuesto = 0
                DocImpuesto = 0

                DocNum = tbl_reporte.Rows(CONT).Item("DocNum").ToString()
                Condicion = tbl_reporte.Rows(CONT).Item("Condicion").ToString()


                If FacAnterior = "" Or FacAnterior <> DocNum Then
                    FacAnterior = DocNum


                    'If Condicion = "-1" Then
                    '    TotalContado += CDbl(DocTotal)
                    'Else
                    '    TotalCredito += CDbl(DocTotal)
                    'End If

                    'TotalReporte += CDbl(DocTotal)


                    If tbl_reporte.Rows(CONT).Item("DocTotal").ToString() <> "" Then
                        DocTotal = CDbl(tbl_reporte.Rows(CONT).Item("DocTotal").ToString())
                    Else
                        DocTotal = 0
                    End If

                    If tbl_reporte.Rows(CONT).Item("VatSum").ToString() <> "" Then
                        DocImpuesto = CDbl(tbl_reporte.Rows(CONT).Item("VatSum").ToString())
                    Else
                        DocImpuesto = 0
                    End If

                    If tbl_reporte.Rows(CONT).Item("LineTotal").ToString() <> "" Then
                        DocSubTotal = CDbl(tbl_reporte.Rows(CONT).Item("LineTotal").ToString())
                    Else
                        DocSubTotal = 0
                    End If

                    If Condicion = "-1" Then
                        TotalContado += DocTotal
                        SubTotalContado += DocSubTotal
                        ImpuestoContado += DocImpuesto
                    Else
                        TotalCredito += DocTotal
                        SubTotalCredito += DocSubTotal
                        ImpuestoCredito += DocImpuesto
                    End If

                    TotalReporte += DocTotal


                Else

                End If







                CONT += 1
            Next

            Totales(0) = TotalReporte
            Totales(1) = TotalContado
            Totales(2) = TotalCredito

            Totales(3) = SubTotalContado
            Totales(4) = SubTotalCredito

            Totales(5) = ImpuestoContado
            Totales(6) = ImpuestoCredito

            Return Totales
        Catch ex As Exception
            MsgBox("ERROR EN ObtieneTotalesRepFac  [ " & ex.Message & " ]", MsgBoxStyle.Critical)
            VariablesGlobales.Obj_Log.Log("ERROR EN ObtieneTotalesRepFac [ " & txb_Numero.Text & " ][ " & ex.Message & " ]", "Otros")

        End Try
    End Function

    Public Function GUARDA_Reporte(ByVal Conb1 As Boolean, ByVal tbl_reporte As DataTable, ByVal Consecutivo As Integer, ByVal txt_FacturaINI As String, ByVal txt_FacturaFIN As String, ByVal Fecha As String, ByVal Hora As String, ByVal Chofer As String, ByVal Ayudante As String, ByVal SQL_Comman As SqlCommand)
        Dim TotalReporte As Double
        Dim TotalContado As Double
        Dim TotalCredito As Double
        Dim Totales(2) As Double
        Dim FacAnterior As String = ""
        Dim MismaFAc As Boolean = False
        Try

            Dim DocNum As String
            Dim DocDate As String
            Dim CardCode As String
            Dim CardName As String
            Dim DocTotal As String
            Dim DiscSum As String
            Dim VatSum As String
            Dim ItemCode As String
            Dim Dscription As String
            Dim Quantity As String
            Dim DiscPrcnt As String
            Dim Price As String
            Dim LineTotal As String
            Dim CONT As Integer
            Dim Ruta As String
            Dim Condicion As String
            Dim Imp As String
            Dim Saldo As String
            Dim SlpCode As String
            Dim MostrarEnLiq As String

            Dim DiscFijo As String
            Dim DiscPromo As String


            bar_ProgresSector.Maximum = tbl_reporte.Rows.Count



            For Each row As DataRow In tbl_reporte.Rows
                Ruta = txtb_Ruta.Text

                DocNum = tbl_reporte.Rows(CONT).Item("DocNum").ToString()

                DocDate = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Fecha)
                CardCode = tbl_reporte.Rows(CONT).Item("CardCode").ToString()
                CardName = tbl_reporte.Rows(CONT).Item("CardName").ToString()
                DocTotal = tbl_reporte.Rows(CONT).Item("DocTotal").ToString()
                DiscSum = tbl_reporte.Rows(CONT).Item("DiscSum").ToString()
                VatSum = tbl_reporte.Rows(CONT).Item("VatSum").ToString()
                ItemCode = tbl_reporte.Rows(CONT).Item("ItemCode").ToString()
                Dscription = tbl_reporte.Rows(CONT).Item("Dscription").ToString()
                Quantity = tbl_reporte.Rows(CONT).Item("Quantity").ToString()
                DiscPrcnt = tbl_reporte.Rows(CONT).Item("DiscPrcnt").ToString()
                Price = tbl_reporte.Rows(CONT).Item("Price").ToString()
                LineTotal = tbl_reporte.Rows(CONT).Item("LineTotal").ToString()
                Condicion = tbl_reporte.Rows(CONT).Item("Condicion").ToString()
                SlpCode = tbl_reporte.Rows(CONT).Item("SlpCode").ToString()
                Imp = tbl_reporte.Rows(CONT).Item("Imp").ToString()
                Saldo = tbl_reporte.Rows(CONT).Item("Saldo").ToString()

                DiscFijo = tbl_reporte.Rows(CONT).Item("DiscFijo").ToString()
                DiscPromo = tbl_reporte.Rows(CONT).Item("DiscPromo").ToString()

                '------CON IMPUESO
                'If Imp = "Y" Then
                '    If DiscPrcnt > 0 Then
                '        LineTotal += ((Price * Quantity) - (((Price * Quantity) * DiscPrcnt) / 100)) * 1.13
                '    Else
                '        LineTotal += (Price * Quantity) * 1.13
                '    End If

                '    '-------SIN IMPUESO
                'Else
                '    If DiscPrcnt > 0 Then
                '        LineTotal += ((Price * Quantity) - (((Price * Quantity) * DiscPrcnt)) / 100)
                '    Else
                '        LineTotal += (Price * Quantity)
                '    End If
                'End If

                If FacAnterior = "" Or FacAnterior <> DocNum Then
                    FacAnterior = DocNum

                    If Condicion = "-1" Then
                        TotalContado += CDbl(DocTotal)
                    Else
                        TotalCredito += CDbl(DocTotal)
                    End If

                    TotalReporte += CDbl(DocTotal)
                Else

                End If


                If Condicion = "-1" Then
                    MostrarEnLiq = "1"
                Else
                    MostrarEnLiq = "0"
                End If

                If DocNum = "" Then
                    DocNum = "0"
                End If
                If DocDate = "" Then
                    DocDate = "0"
                End If
                If CardCode = "" Then
                    CardCode = "0"
                End If
                If CardName = "" Then
                    CardName = "0"
                End If
                If DocTotal = "" Then
                    DocTotal = "0"
                End If
                If DiscSum = "" Then
                    DiscSum = "0"
                End If
                If VatSum = "" Then
                    VatSum = "0"
                End If
                If ItemCode = "" Then
                    ItemCode = "0"
                End If
                If Dscription = "" Then
                    Dscription = "0"
                End If
                If DiscPrcnt = "" Then
                    DiscPrcnt = "0"
                End If
                If Price = "" Then
                    Price = "0"
                End If
                If LineTotal = "" Then
                    LineTotal = "0"
                End If
                If Saldo = "" Then
                    Saldo = "0"
                End If


                If Imp = "" Then

                    Imp = "0"
                End If

                If DiscFijo = "" Then
                    DiscFijo = "0"
                End If
                If DiscPromo = "" Then
                    DiscPromo = "0"
                End If








                If DocNum <> "" And DocDate <> "" And CardCode <> "" And CardName <> "" And DocTotal <> "" And DiscSum <> "" And VatSum <> "" And ItemCode <> "" And Dscription <> "" And DiscPrcnt <> "" And Price <> "" And LineTotal <> "" Then


                    If Rb_ConBod1.Checked = True Then
                        ' es un reporte con bodega 1
                        Class_VariablesGlobales.Obj_Funciones_SQL.GUARDA_ReporteFacturas(Consecutivo, DocNum, DocDate, Hora, Ruta, CardCode, CardName, DocTotal, DiscSum, VatSum, ItemCode, Dscription, Quantity, DiscPrcnt, Price, LineTotal, txt_FacturaINI, txt_FacturaFIN, Chofer, Ayudante, Saldo, Condicion, MostrarEnLiq, SlpCode, 1, Class_VariablesGlobales.Log_Usuario, Imp, DiscFijo, DiscPromo, SQL_Comman)

                    Else
                        ' es un reporte sin bodega 1
                        Class_VariablesGlobales.Obj_Funciones_SQL.GUARDA_ReporteFacturas(Consecutivo, DocNum, DocDate, Hora, Ruta, CardCode, CardName, DocTotal, DiscSum, VatSum, ItemCode, Dscription, Quantity, DiscPrcnt, Price, LineTotal, txt_FacturaINI, txt_FacturaFIN, Chofer, Ayudante, Saldo, Condicion, MostrarEnLiq, SlpCode, 0, Class_VariablesGlobales.Log_Usuario, Imp, DiscFijo, DiscPromo, SQL_Comman)
                    End If

                End If

                DocNum = ""
                DocDate = ""
                CardCode = ""
                CardName = ""
                DocTotal = ""
                DiscSum = ""
                VatSum = ""
                SlpCode = ""
                ItemCode = ""
                Dscription = ""
                Quantity = ""
                DiscPrcnt = ""
                Price = ""
                LineTotal = ""
                Ruta = ""
                Condicion = ""
                Saldo = ""
                MostrarEnLiq = ""
                Imp = ""
                DiscFijo = ""
                DiscPromo = ""

                'AQUI DEBERIA DE INCREMENTAR EL PROGRES BAR 

                CONT += 1
                bar_ProgresSector.Value = CONT
            Next
        Catch ex As Exception
            MessageBox.Show("ERROR EN GUARDA_Reporte " & ex.Message)
            VariablesGlobales.Obj_Log.Log("ERROR EN GUARDA_Reporte (" & Consecutivo & ") (" & ex.Message & ")", "Otros")

        End Try
        Totales(0) = TotalReporte
        Totales(1) = TotalContado
        Totales(2) = TotalCredito


        Return Totales
    End Function




    Private Sub Reporte_Facturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Nuevo()

    End Sub

    Public Function Nuevo()
        Try


            bar_ProgresSector.Value = 0
            Class_VariablesGlobales.Fac_Llamadas_Desde = ""
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
            dtp_FechaReporte.Text = Fecha

            Class_VariablesGlobales.Lista_llamadaDesde = "REPFACTURAS"
            ObtieneEmpleado("CHOFER")
            ObtieneEmpleado("AYUDANTE")
            ObtieneRutas()

            txb_Numero.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaConsecutivoRepRepFacturas(Class_VariablesGlobales.SQL_Comman2)

            DataGV_RepFacContado.DataSource = Nothing

            DataGV_RepFacCredito.DataSource = Nothing

            Txb_TotalContado.Text = FormatCurrency("0")
            Txb_SubTotalContado.Text = FormatCurrency("0")
            Txb_ImpuestoContado.Text = FormatCurrency("0")

            Txb_TotalCredito.Text = FormatCurrency("0")
            Txb_SubTotalCredito.Text = FormatCurrency("0")
            Txb_ImpuestoCredito.Text = FormatCurrency("0")




            txtb_FACINI.Text = ""
            txtb_FACFIN.Text = ""
            txtb_Ruta.Text = ""
            txtb_NumLiq.Text = ""
            lbl_Total.Text = ""

            Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_SinBod1.Checked = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_ConBod1.Checked = False

            Class_VariablesGlobales.Obj_Reporte_Facturas.Panel1.Enabled = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.txb_Numero.Enabled = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_Ruta.Enabled = True
            'Class_VariablesGlobales.Obj_Reporte_Facturas.dtp_FechaReporte.Enabled = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.TXB_Hora.Enabled = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACINI.Enabled = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACFIN.Enabled = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_TotalContado.Enabled = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_TotalCredito.Enabled = True

            Class_VariablesGlobales.Obj_Reporte_Facturas.btn_GenerarEnviar.Enabled = True


            txtb_Ruta.Focus()
        Catch ex As Exception

            MsgBox("ERROR EN Nuevo  [ " & ex.Message & " ]", MsgBoxStyle.Critical)
            VariablesGlobales.Obj_Log.Log("ERROR EN Nuevo [ " & ex.Message & " ]", "Otros")

        End Try
    End Function

    Private Sub btn_GenerarEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GenerarEnviar.Click
        Try
            If Class_VariablesGlobales.Puesto = "Facturacion" Or Class_VariablesGlobales.Puesto = "SuperUsuario" Then


                VariablesGlobales.Obj_Log.Log("Click en btn_GenerarEnviar Copias 2 [" & Class_VariablesGlobales.Obj_Reporte_Facturas.txb_Numero.Text & " ]", "Otros")
                Class_VariablesGlobales.Copias = 2

                If txtb_Ruta.Text <> "" And txtb_FACINI.Text <> "" And txtb_FACFIN.Text <> "" And Cbx_Chofer.Text <> "" Then
                    'Dim result As Integer = MessageBox.Show("Realmente desea Generar el reporte de carga :" & vbCrLf & "Ruta [ " & txtb_Ruta.Text & " ] " & vbCrLf & "Desde [   " & txtb_FACINI.Text & "   ] Hasta [   " & txtb_FACFIN.Text & "   ] ", "CONFIRMAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                    'If result = DialogResult.OK Then
                    lbl_Total.Text = FormatCurrency("0")
                    'hilo de ejecucion constante
                    trd2 = New Thread(AddressOf FuncionEn_BackGroud)
                    trd2.IsBackground = Enabled
                    'trd2.Priority = ThreadPriority.Highest
                    CheckForIllegalCrossThreadCalls = False
                    trd2.Start()
                    'ElseIf result = DialogResult.Cancel Then
                    'End If

                Else
                    MsgBox("Debe indicar el nombre de la ruta, Nombre del Chofer y el rango de facturas", MsgBoxStyle.Critical, "FALTA DE INFORMACION")
                End If
            Else
                MsgBox("Solo el facturador puede generar reportes de facturas", MsgBoxStyle.Critical, "IMPORTANTE")

            End If






        Catch ex As Exception

            VariablesGlobales.Obj_Log.Log("ERROR EN btn_generar_Click [" & Class_VariablesGlobales.Obj_Reporte_Facturas.txb_Numero.Text & " ] [" & ex.Message & " ]", "Otros")
            MessageBox.Show("[ " & Now & " ] ERROR EN btn_generar_Click [ " & ex.Message & " ]")
        End Try









    End Sub

    Public Function ObtieneRutas()
        Try


            Cbx_Rutas = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneRutas(Class_VariablesGlobales.SQL_Comman2, Cbx_Rutas)



            Cbx_Rutas.Text = "Seleccione una Ruta"
        Catch ex As Exception

        End Try
    End Function

    Public Function ObtieneEmpleado(ByVal Tipo As String)
        Try

            Dim Tbl As New DataTable

            'Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneChoferes(Class_VariablesGlobales.SQL_Comman2, Tipo, "")
            Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman1, "TODOS", "")
            If Tipo = "CHOFER" Then
                Cbx_Chofer.DataSource = Tbl
                Cbx_Chofer.DisplayMember = "Nombre"
                'Cbx_Chofer.ValueMember = "ID"
                Cbx_Chofer.Text = "Seleccione un Chofer"
            Else
                Cbx_Ayuda.DataSource = Tbl
                Cbx_Ayuda.DisplayMember = "Nombre"
                'Cbx_Ayuda.ValueMember = "ID"
                Cbx_Ayuda.Text = "Seleccione un Ayudante"
            End If




        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function


    Private Sub btn_Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Buscar.Click
        Try


            Dim MDIForm As New List_RepFacturas
            MDIForm.MdiParent = Principal
            MDIForm.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Try

            Dim Obj_RepCarga As ReportesDeCarga
        Obj_RepCarga = New ReportesDeCarga
        Dim Pregunta As Integer


        If Class_VariablesGlobales.Puesto = "Facturacion" Then
            Pregunta = MsgBox("Si Anula el reporte no podra recuperarlo y los bodegueros dejaran de verlo " & vbCrLf & "Esta Seguro que desea Anular el reporte?", vbYesNo + MsgBoxStyle.Critical + vbDefaultButton2, "ANULAR REPORTE")
        Else
            Pregunta = MsgBox("Si Anula el reporte no podra recuperarlo " & vbCrLf & "Esta Seguro que desea Anular el reporte?", vbYesNo + MsgBoxStyle.Critical + vbDefaultButton2, "ANULAR REPORTE")
        End If





        If Pregunta = vbYes Then
            Class_VariablesGlobales.Obj_Funciones_SQL.AnulaRepFacturas(txb_Numero.Text, Class_VariablesGlobales.SQL_Comman2)

                btn_GenerarEnviar.Enabled = False
                btn_Limpiar.Enabled = False
                btn_Buscar.Enabled = False
                btn_Imprimir.Enabled = False
                Btn_Atras.Enabled = False
                Btn_Adelante.Enabled = False

                Class_VariablesGlobales.ConsecutivoRepFactura = txb_Numero.Text
            If Class_VariablesGlobales.Puesto = "Facturacion" Then
                trd3 = New Thread(AddressOf Obj_RepCarga.FuncionEn_BackGroud2)
                trd3.IsBackground = Enabled
                'trd2.Priority = ThreadPriority.Highest
                CheckForIllegalCrossThreadCalls = False
                trd3.Start()
            End If

                btn_GenerarEnviar.Enabled = True
                btn_Limpiar.Enabled = True
                btn_Buscar.Enabled = True
                btn_Imprimir.Enabled = True
                Btn_Atras.Enabled = True
                Btn_Adelante.Enabled = True
                MessageBox.Show("REPORTE ANULADO")
            Nuevo()
        Else

        End If







        Catch ex As Exception
            MessageBox.Show("ERRROR AL ANULAR EL REPORTE " & ex.Message)
        End Try



    End Sub


    Private Sub btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Imprimir.Click

        Class_VariablesGlobales.Copias = 1
        Dim tr_Print As Thread
        tr_Print = New Thread(AddressOf Imprimir)
        tr_Print.IsBackground = Enabled
        tr_Print.Priority = ThreadPriority.AboveNormal
        tr_Print.Start()

        CheckForIllegalCrossThreadCalls = False


        'Imprimir()
    End Sub

    Public Function Imprimir()
        Try

            VariablesGlobales.Obj_Log.Log("Manda a Imprimir RepFacturas", "Otros")


            If Rb_SinBod1.Checked Then
            Else

            End If
            Class_VariablesGlobales.IMPRIMIENDO = "RepFacturas"

            'Class_VariablesGlobales.ReporteFacturas_FacINI = Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACINI.Text
            'Class_VariablesGlobales.ReporteFacturas_FacFIN = Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACFIN.Text
            Class_VariablesGlobales.ReporteFacturas_Consecutivo = Class_VariablesGlobales.Obj_Reporte_Facturas.txb_Numero.Text

            frmReporte.Show()

         

        Catch ex As Exception
            'MsgBox("ERROR, funcion Imprimir [ " & ex.Message & " ]")
            VariablesGlobales.Obj_Log.Log("ERROR, funcion Imprimir [ " & Class_VariablesGlobales.Obj_Reporte_Facturas.txb_Numero.Text & " ][ " & ex.Message & " ]", "Otros")
        End Try
    End Function



    Private Sub Reporte_Facturas_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Class_VariablesGlobales.IMPRIMIENDO = ""
        Class_VariablesGlobales.FrmReporteFacturas = ""
    End Sub
    ' This method handles the LostFocus event for TextBox1 by setting the 
    ' dialog's InitialDirectory property to the text in TextBox1.
    Private Sub txtb_FACFIN_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtb_FACFIN.LostFocus


        'Class_VariablesGlobales.Lista_llamadaDesde = "REPORTE_FACTURAS"
        'ListaChoferes.Show()
    End Sub



    Private Sub Cbx_Chofer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbx_Chofer.SelectedIndexChanged
        'If Cbx_Chofer.Text <> "Seleccione un Chofer" Then
        '    Class_VariablesGlobales.Obj_Reporte_Facturas.btn_GenerarEnviar.Focus()
        'Else
        '    Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_Ruta.Focus()
        'End If

    End Sub



    Private Sub btn_ActualizaLiq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ActualizaLiq.Click
        Dim CodChofer As String = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneCodChofer(Class_VariablesGlobales.SQL_Comman2, "CHOFER", Cbx_Chofer.Text)
        Dim Pregunta As Integer

        Pregunta = MsgBox("Si el reporte esta ligado a una liquidacion y cambia este numero, las facturas desapareseran en la liquidacion donde estaban registradas " & vbLf & "¿Realmente Desea Modificar el numero de liquidacion y nombre del chofer?.", vbYesNo + MsgBoxStyle.Critical + vbDefaultButton2, "MODIFICAR VINCULO A LIQUIDACION")

        If Pregunta = vbYes Then
            Class_VariablesGlobales.Obj_Funciones_SQL.UnificaRepFacturas(CodChofer, Trim(txb_Numero.Text), Trim(txtb_NumLiq.Text), Class_VariablesGlobales.SQL_Comman1)
        Else

        End If
    End Sub

    Private Sub btn_GoLiq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GoLiq.Click

        Class_VariablesGlobales.LIQUIDANDO = "CHOFERES"
        Class_VariablesGlobales.frmLiqChof = New Liquidacion_Choferes
        Class_VariablesGlobales.frmLiqChof.MdiParent = Principal
        Class_VariablesGlobales.frmLiqChof.Show()
        Class_VariablesGlobales.frmLiqChof.Navegar(Trim(txtb_NumLiq.Text))

        ListaChoferes.Close()
    End Sub

    Private Sub SplitContainer1_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub

    Private Sub txtb_Ruta_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_Ruta.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub txtb_FACINI_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_FACINI.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub


    Private Sub txtb_FACFIN_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_FACFIN.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
            btn_GenerarEnviar.Focus()
        End If
    End Sub

    Public Function CargaDetRepFacturas(ByVal SQL_Comman As SqlCommand, ByVal Conse_RepFacturas As String)

        Try


            Dim tabla As New DataTable
            Dim cont As Integer
            Dim TotalFaltante As Double
            Dim SubTotal As Double
            Dim Impuesto As Double
            Dim TotalPeso As Double
            Dim Total As Double
            Dim TotalGeneral As Double

            Dim Anulado As Boolean = False
            Dim Tipo As String = "CONTADO"

            tabla = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaDetRepFacturas(SQL_Comman, Conse_RepFacturas, Tipo)
            Total = 0
            SubTotal = 0
            Impuesto = 0

            If tabla.Rows.Count > 0 Then
                For Each rowLocal As DataRow In tabla.Rows
                    Total += CDbl(tabla.Rows(cont).Item("Total").ToString())
                    SubTotal += CDbl(tabla.Rows(cont).Item("SubTotal").ToString())
                    Impuesto += CDbl(tabla.Rows(cont).Item("Impuesto").ToString())
                    'TotalGeneral += CDbl(tabla.Rows(cont).Item("DocTotal").ToString())
                    cont += 1
                Next

                TotalGeneral += Total



                Class_VariablesGlobales.Obj_Reporte_Facturas.txb_Numero.Text = tabla.Rows(0).Item("Consecutivo").ToString()
                Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_Ruta.Text = tabla.Rows(0).Item("NombreRuta").ToString()
                Class_VariablesGlobales.Obj_Reporte_Facturas.dtp_FechaReporte.Text = tabla.Rows(0).Item("FechaReporte").ToString()
                Class_VariablesGlobales.Obj_Reporte_Facturas.TXB_Hora.Text = tabla.Rows(0).Item("Hora").ToString()
                Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACINI.Text = tabla.Rows(0).Item("Fac_INI").ToString()
                Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACFIN.Text = tabla.Rows(0).Item("Fac_FIN").ToString()
                Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_NumLiq.Text = tabla.Rows(0).Item("NumLiq").ToString()




                'Class_VariablesGlobales.Obj_Reporte_Facturas.lbl_Total.Text = Format(Val(Total), "currency")

                Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_TotalContado.Text = Format(Total, "C2")
                Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_SubTotalContado.Text = Format(SubTotal, "C2")
                Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_ImpuestoContado.Text = Format(Impuesto, "C2")



                Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACINI.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACFIN.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_Ruta.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_ConBod1.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_SinBod1.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.btn_Limpiar.Enabled = False

                Dim Tbl As New DataTable
                Dim Chofer As String = ""
                If tabla.Rows(0).Item("Chofer").ToString() <> "" Then
                    Chofer = tabla.Rows(0).Item("Chofer").ToString()
                End If

                'Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneChoferes(Class_VariablesGlobales.SQL_Comman2, "CHOFER", Chofer)
                Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman1, "CHOFER", Chofer)

                cont = 0
                For Each rowLocal As DataRow In Tbl.Rows
                    If tabla.Rows(0).Item("Chofer").ToString() = Tbl.Rows(cont).Item("CodChofer").ToString() Then
                        Class_VariablesGlobales.Obj_Reporte_Facturas.Cbx_Chofer.Text = Tbl.Rows(cont).Item("Nombre").ToString()
                    End If
                    cont += 1
                Next
                Chofer = Nothing

                Dim Ayudante As String = ""
                If tabla.Rows(0).Item("Ayudante").ToString() <> "Seleccione un Ayudante" Then
                    Ayudante = tabla.Rows(0).Item("Ayudante").ToString()
                End If

                Tbl = New DataTable
                'Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneChoferes(Class_VariablesGlobales.SQL_Comman2, "AYUDANTE", Ayudante)
                Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman1, "AYUDANTE", Ayudante)
                cont = 0

                For Each rowLocal As DataRow In Tbl.Rows
                    If tabla.Rows(0).Item("Chofer").ToString() = Tbl.Rows(cont).Item("CodChofer").ToString() Then
                        Class_VariablesGlobales.Obj_Reporte_Facturas.Cbx_Ayuda.Text = tabla.Rows(0).Item("Ayudante").ToString() = Tbl.Rows(cont).Item("Nombre").ToString()
                    End If
                    cont += 1
                Next
                Ayudante = Nothing

                Dim ConB1 As String = tabla.Rows(0).Item("ConB1").ToString()
                If ConB1 = "1" Then
                    Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_SinBod1.Checked = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_ConBod1.Checked = True
                Else
                    Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_SinBod1.Checked = True
                    Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_ConBod1.Checked = False
                End If


                ' [Consecutivo],[DocNum],[FechaReporte],[Hora],[FechaFactura],[CodCliente],[Nombre],[Fac_INI],[Fac_FIN],[Chofer],[Ayudante],[ConB1],
                'NombreRuta,SUM([Total]) AS Total,[Anulado],[DocTotal],[NumLiq],'CONTADO' AS Tipo ,[SlpCode],[VatSum]



                ' [DocNum],[SlpCode],'CONTADO' AS Tipo ,[CodCliente],[Nombre],SUM([Total]) AS SubTotal,[VatSum] as Impuesto,[DocTotal] as Total,[Consecutivo],[FechaReporte],[Hora],[FechaFactura],[Fac_INI],[Fac_FIN],[Chofer],[Ayudante],[ConB1],
                'NombreRuta,[Anulado],[NumLiq]


                If Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns.Contains("Estado") = False Then
                    Dim col1 As New DataGridViewCheckBoxColumn
                    col1.HeaderText = "Estado"
                    col1.Name = "Estado"
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns.Add(col1)


                End If

                If Tipo = "CONTADO" Then
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.DataSource = tabla
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(0).Width = 40
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(1).Width = 120
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(2).Width = 60
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(3).Width = 30
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(4).Width = 70
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(5).Width = 70
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(6).Width = 290
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(7).Width = 85
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(7).DefaultCellStyle.Format = "C2"
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(8).Width = 85
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(8).DefaultCellStyle.Format = "C2"
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(9).Width = 85
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(9).DefaultCellStyle.Format = "C2"
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(10).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(11).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(12).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(13).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(14).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(15).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(16).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(17).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(18).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(19).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(20).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(21).Visible = False

                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(2).ReadOnly = True
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(3).ReadOnly = True
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(4).ReadOnly = True
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(5).ReadOnly = True
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(6).ReadOnly = True
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(7).ReadOnly = True
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(8).ReadOnly = True
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(9).ReadOnly = True
                End If

                If tabla.Rows(0).Item("Anulado").ToString() = "1" Then
                    Anulado = True

                    Class_VariablesGlobales.Obj_Reporte_Facturas.btn_eliminar.Visible = True
                    Class_VariablesGlobales.Obj_Reporte_Facturas.Lbl_Anulado.Visible = False
                Else
                    Anulado = False

                    Class_VariablesGlobales.Obj_Reporte_Facturas.btn_eliminar.Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.Lbl_Anulado.Visible = True

                End If
                Dim conto As Integer = 0

                'Seria Recorrer la tabla y verificar si Chequeado esta en 1 o 0
                For Each rowLocal As DataRow In tabla.Rows
                    DataGV_RepFacContado.Rows(conto).Selected = False
                    If tabla.Rows(conto).Item("Chequeado").ToString() = "1" Then


                        Dim chkCelda As DataGridViewCheckBoxCell = CType(Me.DataGV_RepFacContado.Rows(conto).Cells(0), DataGridViewCheckBoxCell)
                        chkCelda.Value = True
                        DataGV_RepFacContado.Rows(conto).DefaultCellStyle.BackColor = Color.DarkGreen
                        DataGV_RepFacContado.Rows(conto).DefaultCellStyle.ForeColor = Color.White
                    End If
                    conto += 1
                Next
                'Dim chkCelda As DataGridViewCheckBoxCell = CType(Me.DataGV_RepFacContado.Rows(e.RowIndex).Cells(0), DataGridViewCheckBoxCell)

                'If tabla.Rows(0).Item("Chequeado").ToString() = "1" Then
                '    'Sin Marcar
                '    chkCelda.Value = False
                '    DataGV_RepFacContado.Rows(e.RowIndex).Selected = False

                '    Cbx_Rutas = Class_VariablesGlobales.Obj_Funciones_SQL.FacturaChequeada(False, txb_Numero.Text, Me.DataGV_RepFacContado.Rows(e.RowIndex).Cells("DocNum").Value)
                'Else
                '    'Marcado
                '    chkCelda.Value = True
                '    DataGV_RepFacContado.Rows(e.RowIndex).Selected = True
                '    Cbx_Rutas = Class_VariablesGlobales.Obj_Funciones_SQL.FacturaChequeada(True, txb_Numero.Text, Me.DataGV_RepFacContado.Rows(e.RowIndex).Cells("DocNum").Value)
                'End If

            End If

            '***************************************************************************************************************
            If Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns.Contains("Estado") = False Then
                Dim col1 As New DataGridViewCheckBoxColumn
                col1.HeaderText = "Estado"
                col1.Name = "Estado"
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns.Add(col1)




            End If
            Tipo = "CREDITO"
            tabla = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaDetRepFacturas(SQL_Comman, Conse_RepFacturas, Tipo)

            If tabla.Rows.Count > 0 Then
                Total = 0
                SubTotal = 0
                Impuesto = 0
                For Each rowLocal As DataRow In tabla.Rows
                    Total += CDbl(tabla.Rows(cont).Item("Total").ToString())
                    SubTotal += CDbl(tabla.Rows(cont).Item("SubTotal").ToString())
                    Impuesto += CDbl(tabla.Rows(cont).Item("Impuesto").ToString())
                    cont += 1
                Next

                TotalGeneral += Total


                Class_VariablesGlobales.Obj_Reporte_Facturas.txb_Numero.Text = tabla.Rows(0).Item("Consecutivo").ToString()
                Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_Ruta.Text = tabla.Rows(0).Item("NombreRuta").ToString()
                Class_VariablesGlobales.Obj_Reporte_Facturas.dtp_FechaReporte.Text = tabla.Rows(0).Item("FechaReporte").ToString()
                Class_VariablesGlobales.Obj_Reporte_Facturas.TXB_Hora.Text = tabla.Rows(0).Item("Hora").ToString()
                Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACINI.Text = tabla.Rows(0).Item("Fac_INI").ToString()
                Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACFIN.Text = tabla.Rows(0).Item("Fac_FIN").ToString()
                Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_NumLiq.Text = tabla.Rows(0).Item("NumLiq").ToString()


                'Class_VariablesGlobales.Obj_Reporte_Facturas.lbl_Total.Text = Format(Val(Total), "currency")

                Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_TotalCredito.Text = Format(CDec(Total), "C2")
                Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_SubTotalCredito.Text = Format(CDec(SubTotal), "C2")
                Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_ImpuestoCredito.Text = Format(CDec(Impuesto), "C2")


                Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACINI.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACFIN.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_Ruta.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_ConBod1.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_SinBod1.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.btn_Limpiar.Enabled = False

                Dim Tbl As New DataTable
                Dim Chofer As String = ""
                If tabla.Rows(0).Item("Chofer").ToString() <> "" Then
                    Chofer = tabla.Rows(0).Item("Chofer").ToString()
                End If

                'Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneChoferes(Class_VariablesGlobales.SQL_Comman2, "CHOFER", Chofer)
                Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman1, "TODOS", Chofer)
                cont = 0
                For Each rowLocal As DataRow In Tbl.Rows
                    If tabla.Rows(0).Item("Chofer").ToString() = Tbl.Rows(cont).Item("CodAgente").ToString() Then
                        Class_VariablesGlobales.Obj_Reporte_Facturas.Cbx_Chofer.Text = Tbl.Rows(cont).Item("Nombre").ToString()
                    End If
                    cont += 1
                Next
                Chofer = Nothing

                Dim Ayudante As String = ""
                If tabla.Rows(0).Item("Ayudante").ToString() <> "Seleccione un Ayudante" Then
                    Ayudante = tabla.Rows(0).Item("Ayudante").ToString()
                End If

                Tbl = New DataTable
                'Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneChoferes(Class_VariablesGlobales.SQL_Comman2, "AYUDANTE", Ayudante)
                Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman1, "AYUDANTE", Ayudante)
                cont = 0

                For Each rowLocal As DataRow In Tbl.Rows
                    If tabla.Rows(0).Item("Chofer").ToString() = Tbl.Rows(cont).Item("CodChofer").ToString() Then
                        Class_VariablesGlobales.Obj_Reporte_Facturas.Cbx_Ayuda.Text = tabla.Rows(0).Item("Ayudante").ToString() = Tbl.Rows(cont).Item("Nombre").ToString()
                    End If
                    cont += 1
                Next
                Ayudante = Nothing

                Dim ConB1 As String = tabla.Rows(0).Item("ConB1").ToString()
                If ConB1 = "1" Then
                    Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_SinBod1.Checked = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_ConBod1.Checked = True
                Else
                    Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_SinBod1.Checked = True
                    Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_ConBod1.Checked = False
                End If







                If Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns.Contains("Estado") = False Then
                    Dim col1 As New DataGridViewCheckBoxColumn
                    col1.HeaderText = "Estado"
                    col1.Name = "Estado"
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns.Add(col1)


                End If

                If Tipo = "CREDITO" Then
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.DataSource = tabla
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(0).Width = 40
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(1).Width = 120
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(2).Width = 60
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(3).Width = 30
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(4).Width = 70
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(5).Width = 70
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(6).Width = 290
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(7).Width = 85
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(7).DefaultCellStyle.Format = "C2"
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(8).Width = 85
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(8).DefaultCellStyle.Format = "C2"
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(9).Width = 85
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(9).DefaultCellStyle.Format = "C2"
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(10).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(11).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(12).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(13).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(14).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(15).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(16).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(17).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(18).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(19).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(20).Visible = False
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(21).Visible = False

                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(2).ReadOnly = True
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(3).ReadOnly = True
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(4).ReadOnly = True
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(5).ReadOnly = True
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(6).ReadOnly = True
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(7).ReadOnly = True
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(8).ReadOnly = True
                    Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(9).ReadOnly = True
                End If


                If tabla.Rows(0).Item("Anulado").ToString() = "1" Then
                    Anulado = True
                Else
                    Anulado = False
                End If

                Dim conto As Integer = 0

                'Seria Recorrer la tabla y verificar si Chequeado esta en 1 o 0
                For Each rowLocal As DataRow In tabla.Rows
                    DataGV_RepFacCredito.Rows(conto).Selected = False
                    If tabla.Rows(conto).Item("Chequeado").ToString() = "1" Then


                        Dim chkCelda As DataGridViewCheckBoxCell = CType(Me.DataGV_RepFacCredito.Rows(conto).Cells(0), DataGridViewCheckBoxCell)
                        chkCelda.Value = True
                        DataGV_RepFacCredito.Rows(conto).DefaultCellStyle.BackColor = Color.DarkGreen
                        DataGV_RepFacCredito.Rows(conto).DefaultCellStyle.ForeColor = Color.White
                    End If
                    conto += 1
                Next
            End If


            If Anulado = True Then
                Class_VariablesGlobales.Obj_Reporte_Facturas.btn_Limpiar.Enabled = False

                Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_ConBod1.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_SinBod1.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.txb_Numero.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_Ruta.Enabled = False
                'Class_VariablesGlobales.Obj_Reporte_Facturas.dtp_FechaReporte.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.TXB_Hora.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACINI.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACFIN.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_TotalContado.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_TotalCredito.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_TotalCredito.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.Cbx_Chofer.Enabled = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.Cbx_Ayuda.Enabled = False
                ' Class_VariablesGlobales.Obj_Reporte_Facturas.dtp_FechaReporte.Enabled = False

                Class_VariablesGlobales.Obj_Reporte_Facturas.btn_eliminar.Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.Lbl_Anulado.Visible = True

            Else


                Class_VariablesGlobales.Obj_Reporte_Facturas.btn_eliminar.Visible = True
                Class_VariablesGlobales.Obj_Reporte_Facturas.Lbl_Anulado.Visible = False

                Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_ConBod1.Enabled = True
                Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_SinBod1.Enabled = True

                Class_VariablesGlobales.Obj_Reporte_Facturas.btn_Limpiar.Enabled = True

                Class_VariablesGlobales.Obj_Reporte_Facturas.txb_Numero.Enabled = True
                Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_Ruta.Enabled = True
                ' Class_VariablesGlobales.Obj_Reporte_Facturas.dtp_FechaReporte.Enabled = True
                Class_VariablesGlobales.Obj_Reporte_Facturas.TXB_Hora.Enabled = True
                Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACINI.Enabled = True
                Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACFIN.Enabled = True
                Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_TotalContado.Enabled = True
                Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_TotalCredito.Enabled = True
                Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_TotalCredito.Enabled = True
                Class_VariablesGlobales.Obj_Reporte_Facturas.Cbx_Chofer.Enabled = True
                Class_VariablesGlobales.Obj_Reporte_Facturas.Cbx_Ayuda.Enabled = True
                'Class_VariablesGlobales.Obj_Reporte_Facturas.dtp_FechaReporte.Enabled = True

            End If




            Class_VariablesGlobales.Obj_Reporte_Facturas.lbl_Total.Text = Format(TotalGeneral, "C2")
            TotalGeneral = 0


        Catch ex As Exception
            VariablesGlobales.Obj_Log.Log("ERROR AL CargaDetRepFacturas [ " & Conse_RepFacturas & " ] [ " & ex.Message & " ]", "Otros")
            MsgBox("ERROR AL CargaDetRepFacturas [ " & Conse_RepFacturas & " ] [ " & ex.Message & " ]")

        End Try



    End Function

    Private Sub Btn_Atras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Atras.Click
        Navegar(CInt(txb_Numero.Text) - 1)
    End Sub

    Private Sub Btn_Adelante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Adelante.Click
        Navegar(CInt(txb_Numero.Text) + 1)
    End Sub

    Public Function Navegar(ByVal id As Integer)
        Nuevo()
        CargaDetRepFacturas(Class_VariablesGlobales.SQL_Comman2, id)

    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Class_VariablesGlobales.Obj_RepDCar = New ReportesDeCarga
        Class_VariablesGlobales.Obj_RepDCar.MdiParent = Principal
        Class_VariablesGlobales.Obj_RepDCar.Show()

        Class_VariablesGlobales.Conse_Repcarga = Trim(txb_Numero.Text)
        Class_VariablesGlobales.Obj_RepDCar.CargaDetRepCarga(Class_VariablesGlobales.SQL_Comman2, Class_VariablesGlobales.Conse_Repcarga, "")
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
   
        Servidor = 1
    End Sub

    'Private Sub DataGV_RepFacContado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGV_RepFacContado.CellContentClick
    '    MsgBox("Estado: " & Me.DataGV_RepFacContado.Rows(e.RowIndex).Cells(0).Value)

    '    If e.ColumnIndex = Me.DataGV_RepFacContado.Columns.Item("Estado").Index Then
    '        Dim chkCell As DataGridViewCheckBoxCell = Me.DataGV_RepFacContado.Rows(e.RowIndex).Cells("Estado")
    '        chkCell.Value = Not chkCell.Value
    '    End If

    '    ' MsgBox("Estado: " & EstadoCheck(e.RowIndex))


    'End Sub

    Private Sub DataGV_RepFacContado_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGV_RepFacContado.CurrentCellDirtyStateChanged
        If DataGV_RepFacContado.IsCurrentCellDirty Then
            DataGV_RepFacContado.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If



    End Sub


    Private Sub DataGV_RepFacCredito_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGV_RepFacCredito.CellContentClick
        If e.ColumnIndex = Me.DataGV_RepFacCredito.Columns(0).Index Then
            Dim chkCelda As DataGridViewCheckBoxCell = CType(Me.DataGV_RepFacCredito.Rows(e.RowIndex).Cells(0), DataGridViewCheckBoxCell)
            DataGV_RepFacCredito.Rows(e.RowIndex).Selected = False
            If Convert.ToBoolean(chkCelda.Value) = True Then
                'Sin Marcar
                chkCelda.Value = False
                Cbx_Rutas = Class_VariablesGlobales.Obj_Funciones_SQL.FacturaChequeada(False, txb_Numero.Text, Me.DataGV_RepFacCredito.Rows(e.RowIndex).Cells("DocNum").Value)
                DataGV_RepFacCredito.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                DataGV_RepFacCredito.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
            Else
                'Marcado
                chkCelda.Value = True
                Cbx_Rutas = Class_VariablesGlobales.Obj_Funciones_SQL.FacturaChequeada(True, txb_Numero.Text, Me.DataGV_RepFacCredito.Rows(e.RowIndex).Cells("DocNum").Value)
                DataGV_RepFacCredito.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.DarkGreen
                DataGV_RepFacCredito.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
            End If
        End If
    End Sub
    Private Sub DataGV_RepFacContado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGV_RepFacContado.CellContentClick
        Try


            If e.ColumnIndex = Me.DataGV_RepFacContado.Columns(0).Index Then
                Dim chkCelda As DataGridViewCheckBoxCell = CType(Me.DataGV_RepFacContado.Rows(e.RowIndex).Cells(0), DataGridViewCheckBoxCell)
                DataGV_RepFacContado.Rows(e.RowIndex).Selected = False
                If Convert.ToBoolean(chkCelda.Value) = True Then
                    'Marcado
                    chkCelda.Value = True
                    Cbx_Rutas = Class_VariablesGlobales.Obj_Funciones_SQL.FacturaChequeada(True, txb_Numero.Text, Me.DataGV_RepFacContado.Rows(e.RowIndex).Cells("DocNum").Value)
                    DataGV_RepFacContado.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.DarkGreen
                    DataGV_RepFacContado.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White

                Else


                    'Sin Marcar
                    chkCelda.Value = False
                    Cbx_Rutas = Class_VariablesGlobales.Obj_Funciones_SQL.FacturaChequeada(False, txb_Numero.Text, Me.DataGV_RepFacContado.Rows(e.RowIndex).Cells("DocNum").Value)
                    DataGV_RepFacContado.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                    DataGV_RepFacContado.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub






    Private Sub DataGV_RepFacCredito_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGV_RepFacCredito.CellEndEdit
        Try

            Dim Comentario As String = Me.DataGV_RepFacCredito.Rows(e.RowIndex).Cells("Comentario").Value
            Dim Factura As String = Me.DataGV_RepFacCredito.Rows(e.RowIndex).Cells("DocNum").Value

            Cbx_Rutas = Class_VariablesGlobales.Obj_Funciones_SQL.FacturaComentario(False, txb_Numero.Text, Factura, Comentario)
            Comentario = Nothing
            Factura = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGV_RepFacContado_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGV_RepFacContado.CellEndEdit
        Try

            Dim Comentario As String = Me.DataGV_RepFacContado.Rows(e.RowIndex).Cells("Comentario").Value
            Dim Factura As String = Me.DataGV_RepFacContado.Rows(e.RowIndex).Cells("DocNum").Value

            Cbx_Rutas = Class_VariablesGlobales.Obj_Funciones_SQL.FacturaComentario(False, txb_Numero.Text, Factura, Comentario)
            Comentario = Nothing
            Factura = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bar_ProgresSector_Click(sender As Object, e As EventArgs) Handles bar_ProgresSector.Click

    End Sub

    Private Sub txtb_FACFIN_TextChanged(sender As Object, e As EventArgs) Handles txtb_FACFIN.TextChanged

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged

        Servidor = 2
    End Sub
End Class