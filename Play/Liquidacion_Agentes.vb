Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.OleDb


'Imports CrystalDecisions.Enterprise.Framework
Imports CrystalDecisions.Enterprise.InfoStore
Imports CrystalDecisions.ReportSource




Public Class Liquidacion_Agentes

    Public Obj_SQL_CONEXION As New Class_funcionesSQL
    Public Obj_Mformat As New MonedaFormat


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgregaViaticos.Click
        Class_VariablesGlobales.CodAgenteLiq = txtb_CodAgente.Text
        Class_VariablesGlobales.NomAgenteLiq = txtb_NombreAgente.Text
        Class_VariablesGlobales.NumLiqAgenteLiq = txtb_Consecutivo.Text

        Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION"
        Class_VariablesGlobales.TituloDetalleGasto = "Viaticos"

        Detalle_Gastos.Show()


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgregaCombustibles.Click
        Class_VariablesGlobales.CodAgenteLiq = txtb_CodAgente.Text
        Class_VariablesGlobales.NomAgenteLiq = txtb_NombreAgente.Text
        Class_VariablesGlobales.NumLiqAgenteLiq = txtb_Consecutivo.Text

        Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION"
        Class_VariablesGlobales.TituloDetalleGasto = "Combustible"

        Detalle_Gastos.Show()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgregaHospedaje.Click
        Class_VariablesGlobales.CodAgenteLiq = txtb_CodAgente.Text
        Class_VariablesGlobales.NomAgenteLiq = txtb_NombreAgente.Text
        Class_VariablesGlobales.NumLiqAgenteLiq = txtb_Consecutivo.Text

        Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION"
        Class_VariablesGlobales.TituloDetalleGasto = "Hospedaje"

        Detalle_Gastos.Show()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Agrega_Imprevistos.Click
        Class_VariablesGlobales.CodAgenteLiq = txtb_CodAgente.Text
        Class_VariablesGlobales.NomAgenteLiq = txtb_NombreAgente.Text
        Class_VariablesGlobales.NumLiqAgenteLiq = txtb_Consecutivo.Text

        Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION"
        Class_VariablesGlobales.TituloDetalleGasto = "Imprevistos"

        Detalle_Gastos.Show()

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgregaOtros.Click
        Class_VariablesGlobales.CodAgenteLiq = txtb_CodAgente.Text
        Class_VariablesGlobales.NomAgenteLiq = txtb_NombreAgente.Text
        Class_VariablesGlobales.NumLiqAgenteLiq = txtb_Consecutivo.Text

        Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION"
        Class_VariablesGlobales.TituloDetalleGasto = "Otros"

        Detalle_Gastos.Show()

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaAgente.Click
        'Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION"



        If Class_VariablesGlobales.LIQUIDANDO = "CHOFERES" Then
            'Class_VariablesGlobales.Lista_llamadaDesde = "LIQ_AGENTE"
            ListaChoferes.Show()
        Else
            'Class_VariablesGlobales.Lista_llamadaDesde = "LIQ_AGENTE"

            Class_VariablesGlobales.Obj_ListaAgentes = New ListaAgentes
            ' Class_VariablesGlobales.Obj_ListaAgentes.MdiParent = Principal
            Class_VariablesGlobales.Obj_ListaAgentes.Puesto = "AGENTE"
            Class_VariablesGlobales.Obj_ListaAgentes.TopMost = True
            Class_VariablesGlobales.Obj_ListaAgentes.Show()

        End If

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgregaDepositos.Click
        Class_VariablesGlobales.CodAgenteLiq = txtb_CodAgente.Text
        Class_VariablesGlobales.NomAgenteLiq = txtb_NombreAgente.Text
        Class_VariablesGlobales.NumLiqAgenteLiq = txtb_Consecutivo.Text
        If Class_VariablesGlobales.LIQUIDANDO = "CHOFERES" Then
            Admin_Depositos_Choferes.Show()
        Else
            Admin_Depositos_Agentes.Show()
        End If



    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION"
        Class_VariablesGlobales.TituloDetalleGasto = "PROMOCIONES"

        Detalle_Gastos.Show()

    End Sub
    'Public Function ObtieneRutas()
    '    Try
    '        cbx_Rutas.DataSource = Obj_Funciones_SQL.ObtieneRutas(Class_VariablesGlobales.SQL_Comman2, cbx_Rutas)
    '        cbx_Rutas.Text = "Seleccione una Ruta"
    '    Catch ex As Exception

    '    End Try
    'End Function

    Private Sub Liquidacion_Agentes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Class_VariablesGlobales.LIQUIDANDO = "CHOFERES" Then


            'ObtieneRutas()
            Class_VariablesGlobales.Lista_llamadaDesde = "LIQ_CHOFERES"
            lbl_titulo.Text = "LIQUIDACION DE CHOFERES"
            If Class_VariablesGlobales.NumLiqui <> "" Then
                ' obtiene la liquidacion del deposito
            Else
                txtb_Consecutivo.Text = Obj_SQL_CONEXION.ObtieneConsecutivo(Class_VariablesGlobales.SQL_Comman1, "CHOFERES")
                Class_VariablesGlobales.frmLiqAge = Me
                Class_VariablesGlobales.NumLiqui = txtb_Consecutivo.Text
                Class_VariablesGlobales.TipoLiqui = "CHOFERES"
                Class_VariablesGlobales.FechaIni = dtp_FechaIni.Value.Date
                Class_VariablesGlobales.FechaFin = dtp_FechaFin.Value.Date

                dtp_FechaIni.Enabled = False
                dtp_FechaFin.Enabled = False
                ListaChoferes.Show()
            End If

        ElseIf Class_VariablesGlobales.LIQUIDANDO = "AGENTES" Then
            cbx_Rutas.Visible = False
            Lbl_Ruta.Visible = False
            lbl_titulo.Text = "LIQUIDACION DE AGENTES"
            Class_VariablesGlobales.Lista_llamadaDesde = "LIQ_AGENTE"
            If Class_VariablesGlobales.NumLiqui <> "" Then
                ' obtiene la liquidacion del deposito
            Else
                txtb_Consecutivo.Text = Obj_SQL_CONEXION.ObtieneConsecutivo(Class_VariablesGlobales.SQL_Comman1, "AGENTES")
                Class_VariablesGlobales.NumLiqAgenteLiq = txtb_Consecutivo.Text
                Class_VariablesGlobales.frmLiqAge = Me
                Class_VariablesGlobales.NumLiqui = txtb_Consecutivo.Text
                Class_VariablesGlobales.TipoLiqui = "AGENTES"
                Class_VariablesGlobales.FechaIni = dtp_FechaIni.Value.Date
                Class_VariablesGlobales.FechaFin = dtp_FechaFin.Value.Date

                dtp_FechaIni.Enabled = False
                dtp_FechaFin.Enabled = False


                Class_VariablesGlobales.Obj_ListaAgentes = New ListaAgentes
                'Class_VariablesGlobales.Obj_ListaAgentes.MdiParent = 
                Class_VariablesGlobales.Obj_ListaAgentes.Puesto = "AGENTE"
                Class_VariablesGlobales.Obj_ListaAgentes.TopMost = True
                Class_VariablesGlobales.Obj_ListaAgentes.Show()

            End If
        End If



    End Sub
    Public Function Cargar()

        Try


            Dim TotalDepositos As String
            Dim TotalRecibos As String
            Dim TotalGastos As String
            Dim TotalViaticos As String
            Dim TotalHospedaje As String
            Dim TotalImprevistos As String
            Dim TotalOtros As String
            Dim TotalCombustibles As String
            'si esta creando un liquidacion nueva debe jalar los gastos con num liqui vacia
            ' si jala un liquidacion para editarla debe jalarla segun un numero de liquidacion
            If Class_VariablesGlobales.CREANDO_LIQ_AGENTE = False Then
                Class_VariablesGlobales.NumLiqui = txtb_Consecutivo.Text
            Else
                Class_VariablesGlobales.NumLiqui = ""
                'SE SOLICITAN LOS GASTOS SIN NUMERO DE LIQUIDACION CUANDO ES UNA LIQUDACION NUEVA, ESTO PARA PODE RVER LOS GASTOS TRANSMITIDOS POR LOS AGENTES
                'SE DEBEN JALAR LOS GASTOS 
            End If

            TotalViaticos = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalGastosAgentes(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.TipoLiqui, "Viaticos", txtb_CodAgente.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date), False, False)
            TotalHospedaje = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalGastosAgentes(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.TipoLiqui, "Hospedaje", txtb_CodAgente.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date), False, False)
            TotalImprevistos = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalGastosAgentes(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.TipoLiqui, "Imprevistos", txtb_CodAgente.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date), False, False)
            ' txtb_Promociones.Text = Obj_Funciones_SQL.ObtieneTotalGastos(SQL_Comman1, NumLiqui, TipoLiqui, "PROMOCIONES", txtb_CodAgente.Text, dtp_FechaFin.Value.Date, dtp_FechaFin.Value.Date)
            TotalOtros = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalGastosAgentes(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.TipoLiqui, "Otros", txtb_CodAgente.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date), False, False)
            TotalCombustibles = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalGastosAgentes(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.TipoLiqui, "Combustible", txtb_CodAgente.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date), False, False)

            txtb_Viaticos.Text = FormatCurrency(TotalViaticos, 2)
            txtb_Hospedaje.Text = FormatCurrency(TotalHospedaje, 2)
            txtb_Imprevistos.Text = FormatCurrency(TotalImprevistos, 2)
            ' txtb_Promociones.Text = FormatCurrency(TotalDepositos, 2)
            txtb_Otros.Text = FormatCurrency(TotalOtros, 2)
            txtb_Combustibles.Text = FormatCurrency(TotalCombustibles, 2)

            TotalGastos = Convert.ToDouble(TotalViaticos) + Convert.ToDouble(TotalHospedaje) + Convert.ToDouble(TotalImprevistos) + Convert.ToDouble(TotalOtros) + Convert.ToDouble(TotalCombustibles)
            txtb_TotalGastos.Text = FormatCurrency(CStr(TotalGastos), 2)

            dgv_Depositos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date), Trim(txtb_CodAgente.Text), "", "", "", "DPCONSECUTIVO", Class_VariablesGlobales.LIQUIDANDO, False, "")
            TotalDepositos = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date), Trim(txtb_CodAgente.Text), "", Class_VariablesGlobales.LIQUIDANDO)

            txtb_TotalDepositos.Text = FormatCurrency(TotalDepositos, 2)

            dgv_Recibos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneRecibos(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date), Trim(txtb_CodAgente.Text), Class_VariablesGlobales.frmLiqAge.txtb_Consecutivo.Text)
            TotalRecibos = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalRecibos(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date), Trim(txtb_CodAgente.Text), Class_VariablesGlobales.frmLiqAge.txtb_Consecutivo.Text)
            txtb_TotalRecibos.Text = FormatCurrency(TotalRecibos, 2)

            Dim Diferencia As Double = (Convert.ToDouble(TotalDepositos) + Convert.ToDouble(TotalGastos)) - Convert.ToDouble(TotalRecibos)
            txtb_Diferencias.Text = CStr(Obj_Mformat.FormatoMoneda(Diferencia))

        Catch ex As Exception
            MessageBox.Show(ex.Message)


        End Try
    End Function
    Public Sub btn_Cargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cargar.Click
        Cargar()
    End Sub


    Private Sub dtp_FechaIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_FechaIni.ValueChanged
        Class_VariablesGlobales.FechaIni = dtp_FechaIni.Value.Date
        Cargar()
    End Sub

    Private Sub dtp_FechaFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_FechaFin.ValueChanged
        Class_VariablesGlobales.FechaFin = dtp_FechaFin.Value.Date
        Cargar()
    End Sub



    Public Function Imprimir()
        Class_VariablesGlobales.LiquiAgente_ConseLiq = txtb_Consecutivo.Text
        Class_VariablesGlobales.LiquiAgente_FechaIni = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date)
        Class_VariablesGlobales.LiquiAgente_FechaFin = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date)
        Class_VariablesGlobales.LiquiAgente_CodAgente = txtb_CodAgente.Text
        frmReporte.Show()
    End Function

    Private Sub btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Guardar.Click
        If btn_Guardar.Text = "GUARDAR" Then
            Guardar()
        Else
            Modificar()

        End If

    End Sub


    Public Function Guardar()
        Class_VariablesGlobales.NumLiqui = ""
        '[Cosecutivo],[Fecha],[CodAgente],[CedulaAgente],[NombreAgente],[FechaINI],[FechaFIN],[Comentarios],[Tipo]

        If Class_VariablesGlobales.Obj_Funciones_SQL.GuardarLiquidacion(Class_VariablesGlobales.SQL_Comman1, txtb_Consecutivo.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaLiquidacion.Value.Date), txtb_CodAgente.Text, txtb_Cedula.Text, txtb_NombreAgente.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date), txtb_Comentarios.Text, Class_VariablesGlobales.LIQUIDANDO, txtb_Diferencias.Text, cbx_Rutas.Text) = 0 Then
            Dim contardor As Integer = 0
            'Obtiene la tabla de los depositos de la liquidacion para indicarle la liquidacion en la que quedaron
            While contardor < dgv_Depositos.Rows.Count - 1
                'guardarle el numero de liquidacion a los depositos
                Class_VariablesGlobales.Obj_Funciones_SQL.ModificaDeposito(Class_VariablesGlobales.SQL_Comman1, dgv_Depositos.Rows(contardor).Cells(0).Value.ToString(), "", "", "", "", "", "", txtb_Consecutivo.Text, Class_VariablesGlobales.TipoLiqui, True, "", "")
                contardor += 1
            End While
            'Obtiene la tabla de los GASTOS de la liquidacion para indicarle la liquidacion en la que quedaron
            Dim tbl As New DataTable
            Dim cont As Integer = 0
            tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneListaGastos(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.NumLiqui, Class_VariablesGlobales.TipoLiqui, txtb_CodAgente.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date))
            If tbl.Rows.Count > 0 Then
                For Each row As DataRow In tbl.Rows
                    Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaGasto(Class_VariablesGlobales.SQL_Comman1, "", "", "", "", txtb_Consecutivo.Text, Class_VariablesGlobales.TipoLiqui, "", "", Trim(tbl.Rows(cont).Item("DocNum").ToString()), True, True)
                    cont += 1
                Next
            End If
            cont = Nothing
            tbl = Nothing

            Class_VariablesGlobales.Obj_Funciones_SQL.Aumenta_Consecutivos(Class_VariablesGlobales.SQL_Comman1, CInt(txtb_Consecutivo.Text) + 1, Class_VariablesGlobales.TipoLiqui)
            Imprimir()
            limpia()
            txtb_Consecutivo.Text = Obj_SQL_CONEXION.ObtieneConsecutivo(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.TipoLiqui)
        End If

    End Function

    Public Function Modificar()
        Dim contardor As Integer = 0


        'Obtiene la tabla de los depositos de la liquidacion para indicarle la liquidacion en la que quedaron
        While contardor < dgv_Depositos.Rows.Count - 1
            'guardarle el numero de liquidacion a los depositos
            Class_VariablesGlobales.Obj_Funciones_SQL.ModificaDeposito(Class_VariablesGlobales.SQL_Comman1, dgv_Depositos.Rows(contardor).Cells(0).Value.ToString(), "", "", "", "", "", "", txtb_Consecutivo.Text, Class_VariablesGlobales.TipoLiqui, True, "", "")
            contardor += 1
        End While
        'Obtiene la tabla de los GASTOS de la liquidacion para indicarle la liquidacion en la que quedaron
        Dim tbl As New DataTable
        Dim cont As Integer = 0
        tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneListaGastos(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.NumLiqui, Class_VariablesGlobales.TipoLiqui, txtb_CodAgente.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date))
        If tbl.Rows.Count > 0 Then
            For Each row As DataRow In tbl.Rows
                Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaGasto(Class_VariablesGlobales.SQL_Comman1, "", "", "", "", txtb_Consecutivo.Text, Class_VariablesGlobales.TipoLiqui, "", "", Trim(tbl.Rows(cont).Item("DocNum").ToString()), True, True)
                cont += 1
            Next
        End If
        cont = Nothing
        tbl = Nothing


        Class_VariablesGlobales.CodAgenteLiq = ""
        Class_VariablesGlobales.NomAgenteLiq = ""
        Class_VariablesGlobales.NumLiqAgenteLiq = ""
        Class_VariablesGlobales.NumLiqui = ""
        Class_VariablesGlobales.Obj_Funciones_SQL.ModificaLiquidacion(Class_VariablesGlobales.SQL_Comman1, txtb_Consecutivo.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaLiquidacion.Value.Date), txtb_CodAgente.Text, txtb_Cedula.Text, txtb_NombreAgente.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date), txtb_Comentarios.Text, Class_VariablesGlobales.TipoLiqui, txtb_Diferencias.Text)
        Dim Pregunta As Integer

        Pregunta = MsgBox("¿Desea imprimir la liquidacion?.", vbYesNo + vbExclamation + vbDefaultButton2, "IMPRIMIR LIQUIDACIONES")

        If Pregunta = vbYes Then
            Imprimir()
        Else

        End If


        limpia()
        txtb_Consecutivo.Text = Obj_SQL_CONEXION.ObtieneConsecutivo(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.TipoLiqui)
    End Function


    Private Sub btn_Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Buscar.Click
        Lista_LiquidacionesAgentes.Show()
    End Sub

    Public Function limpia()

        btn_Guardar.Text = "GUARDAR"
        Me.Close()
        Class_VariablesGlobales.NumLiqui = Nothing
        Class_VariablesGlobales.frmLiqAge = New Liquidacion_Agentes
        Class_VariablesGlobales.frmLiqAge.MdiParent = Principal
        Class_VariablesGlobales.frmLiqAge.Show()

        Class_VariablesGlobales.CodAgenteLiq = ""
        Class_VariablesGlobales.NomAgenteLiq = ""
        Class_VariablesGlobales.NumLiqAgenteLiq = ""
        dtp_FechaLiquidacion.Value = Now.Date
        txtb_CodAgente.Text = ""
        txtb_Cedula.Text = ""
        txtb_NombreAgente.Text = ""
        dtp_FechaIni.Value = Now.Date
        dtp_FechaFin.Value = Now.Date
        txtb_Comentarios.Text = ""

        txtb_Viaticos.Text = FormatCurrency("0", 2)
        txtb_Combustibles.Text = FormatCurrency("0", 2)
        txtb_Hospedaje.Text = FormatCurrency("0", 2)
        txtb_Imprevistos.Text = FormatCurrency("0", 2)
        txtb_Otros.Text = FormatCurrency("0", 2)
        txtb_TotalGastos.Text = FormatCurrency("0", 2)
        txtb_TotalDepositos.Text = FormatCurrency("0", 2)
        txtb_TotalRecibos.Text = FormatCurrency("0", 2)
        txtb_Diferencias.Text = FormatCurrency("0", 2)

        dgv_Recibos.DataSource = New DataTable
        dgv_Depositos.DataSource = New DataTable
        TabControl1.Enabled = False
        btn_Cargar.Enabled = False
        dtp_FechaIni.Enabled = False
        dtp_FechaFin.Enabled = False
        txtb_NombreAgente.Enabled = False
        txtb_Cedula.Enabled = False
        dtp_FechaLiquidacion.Enabled = False
        txtb_Comentarios.Enabled = False
    End Function

    Private Sub btn_BuscaLiquidacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaLiquidacion.Click
        Lista_LiquidacionesAgentes.Show()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Imprimir.Click
        Imprimir()
    End Sub

    Private Sub btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Nuevo.Click

        NuevaLiquidacion()

    End Sub

    Public Function NuevaLiquidacion()

        Class_VariablesGlobales.CREANDO_LIQ_AGENTE = True

        Class_VariablesGlobales.Lista_llamadaDesde = "LIQ_AGENTE"
        dtp_FechaIni.Value = Now.Date
        dtp_FechaFin.Value = Now.Date

        txtb_Consecutivo.Text = Obj_SQL_CONEXION.ObtieneConsecutivo(Class_VariablesGlobales.SQL_Comman1, "AGENTES")
        Class_VariablesGlobales.frmLiqAge = Me
        Class_VariablesGlobales.NumLiqui = txtb_Consecutivo.Text
        Class_VariablesGlobales.TipoLiqui = "AGENTES"
        Class_VariablesGlobales.FechaIni = dtp_FechaIni.Value.Date
        Class_VariablesGlobales.FechaFin = dtp_FechaFin.Value.Date
        dtp_FechaIni.Enabled = False
        dtp_FechaFin.Enabled = False

        limpia()
        If Class_VariablesGlobales.LIQUIDANDO = "CHOFERES" Then
            ListaChoferes.Show()
        Else


            Class_VariablesGlobales.Obj_ListaAgentes = New ListaAgentes
            'Class_VariablesGlobales.Obj_ListaAgentes.MdiParent = Principal
            Class_VariablesGlobales.Obj_ListaAgentes.Puesto = "AGENTE"
            Class_VariablesGlobales.Obj_ListaAgentes.TopMost = True
            Class_VariablesGlobales.Obj_ListaAgentes.Show()

        End If
    End Function
    Private Sub btn_Modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub dgv_Depositos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_Depositos.CellClick
        'Admin_Depositos_Choferes.Show()
        '[DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],[DPMONTO],[DPAGENTE],[DPOBS],[DPLIQUIDACION],[DP_TIPO_LIQ]

        Try
            Class_VariablesGlobales.MisPropiedades.FrmDepAg.Show()
        Catch ex As Exception
            Class_VariablesGlobales.MisPropiedades.FrmDepAg = New Admin_Depositos_Agentes
            Class_VariablesGlobales.MisPropiedades.FrmDepAg.MdiParent = Principal
            Class_VariablesGlobales.MisPropiedades.FrmDepAg.Show()


        End Try


        Class_VariablesGlobales.frmDeposAgente.txb_consecutivo.Text = dgv_Depositos.CurrentRow.Cells.Item(0).Value
        Class_VariablesGlobales.frmDeposAgente.txb_NumDepo.Text = dgv_Depositos.CurrentRow.Cells.Item(1).Value
        Class_VariablesGlobales.frmDeposAgente.dtp_Fecha.Text = dgv_Depositos.CurrentRow.Cells.Item(2).Value
        Class_VariablesGlobales.frmDeposAgente.cbbx_Banco.Text = dgv_Depositos.CurrentRow.Cells.Item(3).Value
        Class_VariablesGlobales.frmDeposAgente.txb_Monto.Text = dgv_Depositos.CurrentRow.Cells.Item(4).Value
        Class_VariablesGlobales.frmDeposAgente.txb_CodAgente.Text = dgv_Depositos.CurrentRow.Cells.Item(6).Value
        Class_VariablesGlobales.frmDeposAgente.txb_NomAgente.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneNameAgente(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.frmDeposAgente.txb_CodAgente.Text)
        Class_VariablesGlobales.frmDeposAgente.txb_Comentario.Text = dgv_Depositos.CurrentRow.Cells.Item(5).Value

        Class_VariablesGlobales.frmDeposAgente.txb_Liquidacion.Text = dgv_Depositos.CurrentRow.Cells.Item(7).Value
        If dgv_Depositos.CurrentRow.Cells.Item(9).Value = "0" Then
            Class_VariablesGlobales.frmDeposAgente.cbbx_Subido.Text = "NO"
        Else
            Class_VariablesGlobales.frmDeposAgente.cbbx_Subido.Text = "SI"
        End If
        'Class_VariablesGlobales.frmDeposAgente.txtb_Subido.Text = dgv_Depositos.CurrentRow.Cells.Item(9).Value
        Class_VariablesGlobales.frmDeposAgente.dtp_FechaContable.Text = dgv_Depositos.CurrentRow.Cells.Item(10).Value

        Class_VariablesGlobales.frmDeposAgente.btn_AgGuardar.Enabled = False
        Class_VariablesGlobales.frmDeposAgente.btn_AgModif.Enabled = True
        Class_VariablesGlobales.frmDeposAgente.btn_AgElimina.Enabled = True
    End Sub

    Private Sub Liquidacion_Agentes_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Class_VariablesGlobales.NumLiqui = ""
        Class_VariablesGlobales.NumLiqui = Nothing
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Anular.Click

        Dim result1 As DialogResult = MessageBox.Show("Si anula la Liquidacion no podra editarlo\n Realmente desea anular el Liquidacion?", _
      "Important Question", _
      MessageBoxButtons.YesNo)

        If result1 = DialogResult.Yes Then
            Class_VariablesGlobales.Obj_Funciones_SQL.AnulaLiquidacion(Class_VariablesGlobales.SQL_Comman1, txtb_Consecutivo.Text, Class_VariablesGlobales.TipoLiqui)
            txtb_Consecutivo.Text = Obj_SQL_CONEXION.ObtieneConsecutivo(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.TipoLiqui)
            limpia()


        End If
        If result1 = DialogResult.No Then


        End If


    End Sub


    Private Sub Btn_Atras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Atras.Click
        Navegar(CInt(txtb_Consecutivo.Text) - 1)
    End Sub

    Private Sub Btn_Adelante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Adelante.Click
        Navegar(CInt(txtb_Consecutivo.Text) + 1)
    End Sub

    Public Function Navegar(ByVal NumLiquidacion As Integer)
        Try


            If Class_VariablesGlobales.CREANDO_LIQ_AGENTE = False Then
                Class_VariablesGlobales.NumLiqui = txtb_Consecutivo.Text
            Else
                Class_VariablesGlobales.NumLiqui = ""
            End If


            btn_Guardar.Text = "MODIFICAR"

            'consulta segun el numero de documento los campos 
            '[Cosecutivo],[Fecha],[CodAgente],[CedulaAgente],[NombreAgente],[FechaINI],[FechaFIN],[Comentarios],[Tipo],[Anulada]
            Dim tablasLiq As New DataTable
            tablasLiq = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLiquidaciones(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.TipoLiqui, "", "", NumLiquidacion)
            If tablasLiq.Rows.Count > 0 Then

                tablasLiq.Rows(0).Item("Fecha").ToString()
                tablasLiq.Rows(0).Item("Tipo").ToString()



                Class_VariablesGlobales.NumLiqui = tablasLiq.Rows(0).Item("Cosecutivo").ToString()
                Class_VariablesGlobales.frmLiqAge.txtb_Consecutivo.Text = tablasLiq.Rows(0).Item("Cosecutivo").ToString()
                Class_VariablesGlobales.frmLiqAge.txtb_CodAgente.Text = tablasLiq.Rows(0).Item("CodAgente").ToString()
                Class_VariablesGlobales.frmLiqAge.txtb_Cedula.Text = tablasLiq.Rows(0).Item("CedulaAgente").ToString()
                Class_VariablesGlobales.frmLiqAge.txtb_NombreAgente.Text = tablasLiq.Rows(0).Item("NombreAgente").ToString()
                Class_VariablesGlobales.frmLiqAge.dtp_FechaIni.Value = tablasLiq.Rows(0).Item("FechaINI").ToString()
                Class_VariablesGlobales.frmLiqAge.dtp_FechaFin.Value = tablasLiq.Rows(0).Item("FechaFIN").ToString()
                Class_VariablesGlobales.frmLiqAge.txtb_Comentarios.Text = tablasLiq.Rows(0).Item("Comentarios").ToString()
                Cargar()

                'verifica si esta anulada
                If tablasLiq.Rows(0).Item("Anulada").ToString() = "1" Then
                    Class_VariablesGlobales.frmLiqAge.btn_Anular.Enabled = False
                    Class_VariablesGlobales.frmLiqAge.TabControl1.Enabled = False
                    Class_VariablesGlobales.Agente = Class_VariablesGlobales.frmLiqAge.txtb_CodAgente.Text
                    Class_VariablesGlobales.frmLiqAge.btn_Cargar.Enabled = False
                    Class_VariablesGlobales.frmLiqAge.dtp_FechaIni.Enabled = False
                    Class_VariablesGlobales.frmLiqAge.dtp_FechaFin.Enabled = False

                    Class_VariablesGlobales.frmLiqAge.btn_Guardar.Enabled = False
                    Class_VariablesGlobales.frmLiqAge.btn_Imprimir.Enabled = True
                    Class_VariablesGlobales.frmLiqAge.lbl_Anulado.Visible = True
                    Class_VariablesGlobales.frmLiqAge.txtb_Diferencias.Enabled = False


                Else
                    Class_VariablesGlobales.frmLiqAge.lbl_Anulado.Visible = False
                    Class_VariablesGlobales.frmLiqAge.btn_Anular.Enabled = True
                    Class_VariablesGlobales.frmLiqAge.lbl_Anulado.Visible = False
                    Class_VariablesGlobales.frmLiqAge.TabControl1.Enabled = True
                    Class_VariablesGlobales.Agente = Class_VariablesGlobales.frmLiqAge.txtb_CodAgente.Text
                    Class_VariablesGlobales.frmLiqAge.btn_Cargar.Enabled = True
                    Class_VariablesGlobales.frmLiqAge.dtp_FechaIni.Enabled = True
                    Class_VariablesGlobales.frmLiqAge.dtp_FechaFin.Enabled = True

                    Class_VariablesGlobales.frmLiqAge.btn_Guardar.Enabled = True
                    Class_VariablesGlobales.frmLiqAge.btn_Imprimir.Enabled = True
                End If


            Else

                MsgBox("No existe la liquidacion [ " & NumLiquidacion & " ]")
                NuevaLiquidacion()


            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub dgv_Depositos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_Depositos.CellContentClick

    End Sub

    Private Sub txtb_Comentarios_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtb_Comentarios.TextChanged
        btn_Guardar.Enabled = True
    End Sub
End Class