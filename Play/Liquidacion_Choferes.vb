Imports System.Data.SqlClient
Imports System.Threading

Public Class Liquidacion_Choferes
    Public Obj_SQL_CONEXION As New Class_funcionesSQL
    'Public Obj_SAP As New SAP_BUSSINES_ONE
    Public ConsecutivoRepFac As String

    Public valProgres As Integer = 1
    Public trd1 As Thread

    Public TotalSaldo As String
    Public TotalFacturas As String
    Public TotalDepositos As String
    Public TotalRecibos As String
    Public TotalGastos As String
    Public TotalViaticos As String
    Public TotalHospedaje As String
    Public TotalImprevistos As String
    Public TotalOtros As String
    Public TotalCombustibles As String
    Public NumLiqui_Chofer As String

    Private Sub Liquidacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load





        ObtieneRutas()
        Class_VariablesGlobales.Lista_llamadaDesde = "LIQ_CHOFERES"
        If Class_VariablesGlobales.NumLiqui <> "" Then
            ' obtiene la liquidacion del deposito
        Else
            txtb_Consecutivo.Text = Obj_SQL_CONEXION.ObtieneConsecutivo(Class_VariablesGlobales.SQL_Comman1, "CHOFERES")
            Class_VariablesGlobales.NumLiqui_Chofer = txtb_Consecutivo.Text
            Class_VariablesGlobales.NumLiqui_Chofer = ""
            Class_VariablesGlobales.LiquidacionRecuperada = ""
            Class_VariablesGlobales.frmLiqChof = Me
            Class_VariablesGlobales.NumLiqui = txtb_Consecutivo.Text
            Class_VariablesGlobales.TipoLiqui = "CHOFERES"
            Class_VariablesGlobales.FechaIni = dtp_FechaIni.Value.Date
            Class_VariablesGlobales.FechaFin = dtp_FechaFin.Value.Date

            dtp_FechaIni.Enabled = False
            dtp_FechaFin.Enabled = False
            ListaChoferes.Show()
        End If


        'Try
        '    Class_VariablesGlobales.Lista_llamadaDesde = "LIQ_CHOFERES"
        '    If Class_VariablesGlobales.NumLiqui <> "" Then
        '        ' obtiene la liquidacion del deposito
        '    Else
        '        cbx_Rutas = Obj_Funciones_SQL.ObtieneRutas(Class_VariablesGlobales.SQL_Comman1, cbx_Rutas)
        '        txtb_Consecutivo.Text = Obj_SQL_CONEXION.ObtieneConsecutivo(Class_VariablesGlobales.SQL_Comman1, "AGENTES")
        '        Class_VariablesGlobales.frmLiqChof = Me
        '        Class_VariablesGlobales.NumLiqui = txtb_Consecutivo.Text
        '        Class_VariablesGlobales.TipoLiqui = "AGENTES"
        '        Class_VariablesGlobales.FechaIni = dtp_FechaIni.Value.Date
        '        Class_VariablesGlobales.FechaFin = dtp_FechaFin.Value.Date
        '        dtp_FechaIni.Enabled = False
        '        dtp_FechaFin.Enabled = False
        '        ListaChoferes.Show()
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub
    Public Function ObtieneRutas()
        Try
            cbx_Rutas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneRutas(Class_VariablesGlobales.SQL_Comman2, cbx_Rutas)
            cbx_Rutas.Text = "Seleccione una Ruta"
        Catch ex As Exception

        End Try
    End Function
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaChofer.Click
        ListaChoferes.Show()
    End Sub


    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Admin_Depositos_Choferes.Show()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click



        Class_VariablesGlobales.Lista_llamadaDesde = "LIQ_CHOFERES"

        Class_VariablesGlobales.Obj_ListaAgentes = New ListaAgentes
        Class_VariablesGlobales.Obj_ListaAgentes.MdiParent = Principal
        Class_VariablesGlobales.Obj_ListaAgentes.Puesto = "CHOFER"
        Class_VariablesGlobales.Obj_ListaAgentes.Show()


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Class_VariablesGlobales.TituloDetalleGasto = "VIATICOS"
        Detalle_Gastos.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Class_VariablesGlobales.TituloDetalleGasto = "COMBUSTIBLE"
        Detalle_Gastos.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Class_VariablesGlobales.TituloDetalleGasto = "HOSPEDAJE"
        Detalle_Gastos.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Class_VariablesGlobales.TituloDetalleGasto = "IMPREVISTOS"
        Detalle_Gastos.Show()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Class_VariablesGlobales.TituloDetalleGasto = "PROMOCIONES"
        Detalle_Gastos.Show()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Class_VariablesGlobales.TituloDetalleGasto = "OTROS"
        Detalle_Gastos.Show()
    End Sub

    Public Sub btn_Cargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cargar.Click

        Cargar()



    End Sub


    Public Function Cargar()

        If Class_VariablesGlobales.CREANDO_LIQ_CHOFER = False Then
            NumLiqui_Chofer = Class_VariablesGlobales.NumLiqui_Chofer
        Else
            NumLiqui_Chofer = txtb_Consecutivo.Text
        End If

        TotalViaticos = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalGastosChoferes(Class_VariablesGlobales.SQL_Comman1, NumLiqui_Chofer, Class_VariablesGlobales.TipoLiqui, "Viaticos", txt_CodChofer.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni_Recibos.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin_Recibos.Value.Date), False, False, True)
        TotalHospedaje = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalGastosChoferes(Class_VariablesGlobales.SQL_Comman1, NumLiqui_Chofer, Class_VariablesGlobales.TipoLiqui, "Hospedaje", txt_CodChofer.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni_Recibos.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin_Recibos.Value.Date), False, False, True)
        TotalImprevistos = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalGastosChoferes(Class_VariablesGlobales.SQL_Comman1, NumLiqui_Chofer, Class_VariablesGlobales.TipoLiqui, "Imprevistos", txt_CodChofer.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni_Recibos.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin_Recibos.Value.Date), False, False, True)
        ' txtb_Promociones.Text = Obj_Funciones_SQL.ObtieneTotalGastos(SQL_Comman1, NumLiqui, TipoLiqui, "PROMOCIONES", txtb_CodAgente.Text, dtp_FechaFin.Value.Date, dtp_FechaFin.Value.Date)
        TotalOtros = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalGastosChoferes(Class_VariablesGlobales.SQL_Comman1, NumLiqui_Chofer, Class_VariablesGlobales.TipoLiqui, "Otros", txt_CodChofer.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni_Recibos.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin_Recibos.Value.Date), False, False, True)
        TotalCombustibles = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalGastosChoferes(Class_VariablesGlobales.SQL_Comman1, NumLiqui_Chofer, Class_VariablesGlobales.TipoLiqui, "Combustible", txt_CodChofer.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni_Recibos.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin_Recibos.Value.Date), False, False, True)

        txtb_Viaticos.Text = FormatCurrency(TotalViaticos, 2)
        txtb_Hospedaje.Text = FormatCurrency(TotalHospedaje, 2)
        txtb_Imprevistos.Text = FormatCurrency(TotalImprevistos, 2)
        ' txtb_Promociones.Text = FormatCurrency(TotalDepositos, 2)
        txtb_Otros.Text = FormatCurrency(TotalOtros, 2)
        txtb_Combustibles.Text = FormatCurrency(TotalCombustibles, 2)
        TotalGastos = Convert.ToDouble(TotalViaticos) + Convert.ToDouble(TotalHospedaje) + Convert.ToDouble(TotalImprevistos) + Convert.ToDouble(TotalOtros) + Convert.ToDouble(TotalCombustibles)
        txtb_TotalGastos.Text = FormatCurrency(CStr(TotalGastos), 2)

        '///////////// DEPOSITOS /////////////////////

        dgv_Depositos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "LIQUIDACION", txtb_Consecutivo.Text.Trim, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni_Recibos.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin_Recibos.Value.Date), Trim(txt_CodChofer.Text), "", "", "", "DPCONSECUTIVO", Class_VariablesGlobales.LIQUIDANDO, False, "")
        TotalDepositos = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalDepositos(Class_VariablesGlobales.SQL_Comman1, "LIQUIDACION", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni_Recibos.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin_Recibos.Value.Date), Trim(txt_CodChofer.Text), txtb_Consecutivo.Text.Trim, Class_VariablesGlobales.LIQUIDANDO)
        txtb_TotalDepositos.Text = FormatCurrency(TotalDepositos, 2)


        '///////////// RECIBOS //////////////////////

        '******************* MODIFICAR ESTE SECMENTO DE CODIGO *************************
        'SE JALARAN LOS RECIBOS DESDE LA BASE DE SAP SI ES UNA LIQUIDACION COMPLETAMENTE NUEVA, AHORA BIEN LUEGO DE JALAR ESTOS RECIBOS
        '   SE DEBERA HACER UN CRUCE CON LOS RECIBOS GUARDADOS EN LA BASE DE DATOS DE SINCRO PARA QUITAR AQUELLOS RECIBOS QUE YA ESTAN EN OTRA LIQUIDACION
        '   DE ESTA MANERA NO SE VOLVERAN A CARGAN EN PROXIMAS LIQUIDACIONES

        If Class_VariablesGlobales.CREANDO_LIQ_CHOFER = False Then
            NumLiqui_Chofer = Class_VariablesGlobales.NumLiqui_Chofer
        Else
            NumLiqui_Chofer = ""
        End If


        'SI ES UNA LIQUIDACION EXISTENTE JALARA LOS RECIBOS DE LA BASE DE DATOS DE SINCRO
        dgv_Recibos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneRecibos(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni_Recibos.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin_Recibos.Value.Date), Trim(txt_CodChofer.Text), NumLiqui_Chofer)


        TotalRecibos = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalRecibos(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni_Recibos.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin_Recibos.Value.Date), Trim(txt_CodChofer.Text), NumLiqui_Chofer)
        txtb_TotalRecibos.Text = FormatCurrency(TotalRecibos, 2)


        Try
            dgv_Recibos.Columns(0).Width = 50
            dgv_Recibos.Columns(1).Width = 70
            dgv_Recibos.Columns(2).Width = 70
            dgv_Recibos.Columns(3).Width = 70

        Catch ex As Exception

        End Try

        '/////////////// ****** opcion 2 ****** ////
        'se genera el reporte de facturas antes de darselas a los choferes 
        'este reporte a la hora de generar la liquidacion se jalara con base a la fecha y codigo del chofer
        Dim TnlRepFac As New DataTable

        'If Class_VariablesGlobales.RepFActurasUnidicado = True Then

        'End If

        NumLiqui_Chofer = txtb_Consecutivo.Text



        ' se debe recorrer el listview de reportes para generar la consulta con los unions necesarios para jalar las facturas de contado de los reportes seleccionados

        TnlRepFac = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneFacturas(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date), Trim(txt_CodChofer.Text), "CONTADO", NumLiqui_Chofer, ListV_Reportes)

        For x = 0 To ListView_Agentes.Items.Count
            ListView_Agentes.Items.RemoveByKey(x)
        Next

        Do While ListView_Agentes.Items.Count <> 0
            ListView_Agentes.Items.Remove(ListView_Agentes.Items(0))
        Loop


        'For x = 0 To ListV_Reportes.Items.Count
        '    ListV_Reportes.Items.RemoveByKey(x)
        'Next

        'Do While ListV_Reportes.Items.Count <> 0
        '    ListV_Reportes.Items.Remove(ListV_Reportes.Items(0))
        'Loop


        If TnlRepFac.Rows.Count > 0 Then
            ConsecutivoRepFac = TnlRepFac.Rows(0).Item("Consecutivo").ToString()
            txtb_Ruta.Text = TnlRepFac.Rows(0).Item("NombreRuta").ToString()
            'agrega los agentes que tienen asinnadas las facturas
            ListView_Agentes.Items.Add(TnlRepFac.Rows(0).Item("SlpCode").ToString())

        End If

        dgv_Facturas.DataSource = TnlRepFac



        dgv_Facturas.Columns(0).Width = 60
        dgv_Facturas.Columns(1).Width = 60
        dgv_Facturas.Columns(2).Visible = False
        dgv_Facturas.Columns(3).Width = 60
        dgv_Facturas.Columns(4).Visible = False
        dgv_Facturas.Columns(5).Visible = False
        Dim cont As Integer = 0
        For Each rowLocal As DataRow In TnlRepFac.Rows

            TotalFacturas += CDbl(TnlRepFac.Rows(cont).Item("Total").ToString())
            TotalSaldo += CDbl(TnlRepFac.Rows(cont).Item("Saldo").ToString())
            cont += 1
        Next
        cont = Nothing

        'TotalFacturas = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalFacturas(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date), Trim(txt_CodChofer.Text))
        txtb_TotalFacturas.Text = FormatCurrency(TotalFacturas, 2)
        Txtb_TotalSaldo.Text = FormatCurrency(TotalSaldo, 2)
        Try
            dgv_Facturas.Columns(2).Visible = False
        Catch ex As Exception

        End Try

        TnlRepFac = Nothing


        Dim Diferencia As Double = ((Convert.ToDouble(TotalDepositos) + Convert.ToDouble(TotalGastos)) - Convert.ToDouble(TotalRecibos))
        txtb_Diferencias.Text = CStr(FormatoMoneda(Diferencia))

        TotalSaldo = Nothing
        TotalFacturas = Nothing
        TotalDepositos = Nothing
        TotalRecibos = Nothing
        TotalGastos = Nothing
        TotalViaticos = Nothing
        TotalHospedaje = Nothing
        TotalImprevistos = Nothing
        TotalOtros = Nothing
        TotalCombustibles = Nothing
        NumLiqui_Chofer = Nothing
    End Function

    Public Function FormatoMoneda(ByVal Monto As String)
        Monto = String.Format("{0:#,##0.00}", Monto)
        'si emiesa con un parentesis quiere decir que es un valor negativo
        If Monto.StartsWith("(") Then
            'elimina el primer parentesis
            Monto = Monto.Substring(1)
            Monto = Monto.Substring(0, Monto.Length - 1)
            Monto = "-" & Monto
        End If
        Return FormatNumber(Monto, 2)
    End Function

    Private Sub btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Nuevo.Click
        NuevaLiqChofer()
    End Sub

    Public Function NuevaLiqChofer()
        Class_VariablesGlobales.LiquidacionRecuperada = ""
        Class_VariablesGlobales.CREANDO_LIQ_CHOFER = True
        Class_VariablesGlobales.Lista_llamadaDesde = "LIQ_CHOFERES"
        lbl_titulo.Text = "LIQUIDACION DE CHOFERES"

        dtp_FechaIni.Value = Now.Date
        dtp_FechaFin.Value = Now.Date

        txtb_Consecutivo.Text = Obj_SQL_CONEXION.ObtieneConsecutivo(Class_VariablesGlobales.SQL_Comman1, "CHOFERES")
        Class_VariablesGlobales.NumLiqui_Chofer = txtb_Consecutivo.Text
        Class_VariablesGlobales.frmLiqChof = Me

        Class_VariablesGlobales.NumLiqui = txtb_Consecutivo.Text
        Class_VariablesGlobales.TipoLiqui = "CHOFERES"
        Class_VariablesGlobales.FechaIni = dtp_FechaIni.Value.Date
        Class_VariablesGlobales.FechaFin = dtp_FechaFin.Value.Date
        dtp_FechaIni.Enabled = False
        dtp_FechaFin.Enabled = False

        limpia()

        ListaChoferes.Show()

    End Function

    Public Function limpia()

        For x = 0 To ListView_Agentes.Items.Count
            ListView_Agentes.Items.RemoveByKey(x)
        Next

        Do While ListView_Agentes.Items.Count <> 0
            ListView_Agentes.Items.Remove(ListView_Agentes.Items(0))
        Loop

        For x = 0 To ListV_Reportes.Items.Count
            ListV_Reportes.Items.RemoveByKey(x)
        Next

        Do While ListV_Reportes.Items.Count <> 0
            ListV_Reportes.Items.Remove(ListV_Reportes.Items(0))
        Loop



        Class_VariablesGlobales.NumLiqui_Chofer = ""
        Class_VariablesGlobales.LiquidacionRecuperada = ""

        Class_VariablesGlobales.CREANDO_LIQ_CHOFER = True

        Class_VariablesGlobales.CodAgenteLiq = ""
        Class_VariablesGlobales.NomAgenteLiq = ""
        Class_VariablesGlobales.NumLiqChoferLiq = ""
        dtp_FechaLiquidacion.Value = Now.Date
        txt_CodChofer.Text = ""
        txtb_Cedula.Text = ""
        txt_NombreChofer.Text = ""
        dtp_FechaIni.Value = Now.Date
        dtp_FechaFin.Value = Now.Date
        txtb_Comentarios.Text = ""


        Txtb_TotalSaldo.Text = FormatCurrency("0", 2)
        txtb_Viaticos.Text = FormatCurrency("0", 2)
        txtb_Combustibles.Text = FormatCurrency("0", 2)
        txtb_Hospedaje.Text = FormatCurrency("0", 2)
        txtb_Imprevistos.Text = FormatCurrency("0", 2)
        txtb_Otros.Text = FormatCurrency("0", 2)

        txtb_TotalGastos.Text = FormatCurrency("0", 2)
        txtb_TotalDepositos.Text = FormatCurrency("0", 2)
        txtb_TotalRecibos.Text = FormatCurrency("0", 2)
        txtb_Diferencias.Text = FormatCurrency("0", 2)


        'dgv_Recibos.DataSource = New DataTable
        'dgv_Depositos.DataSource = New DataTable
        'dgv_Facturas.DataSource = New DataTable

        TabControl1.Enabled = False
        btn_Cargar.Enabled = True
        dtp_FechaIni.Enabled = False
        dtp_FechaFin.Enabled = False


        txt_NombreChofer.Enabled = False
        txtb_Cedula.Enabled = False
        dtp_FechaLiquidacion.Enabled = False
        txtb_Comentarios.Enabled = False

        '**** probar que esta linea ***


        Me.Close()
        Class_VariablesGlobales.NumLiqui = Nothing
        Class_VariablesGlobales.frmLiqChof = New Liquidacion_Choferes
        Class_VariablesGlobales.frmLiqChof.MdiParent = Principal
        Class_VariablesGlobales.frmLiqChof.Show()

    End Function

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaLiquidacion.Click
        Lista_LiquidacionesChoferes.Show()
    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim tudato As String

        If ListView_Agentes.SelectedIndices.Count <> 0 Then
            ' step through each selected item
            Dim i As Int16
            For Each i In ListView_Agentes.SelectedIndices
                Dim s As String

                ListView_Agentes.Items.Remove(ListView_Agentes.Items(ListView_Agentes.Items(i).Index))
            Next i
        End If


    End Sub

    Private Sub btn_AgregaViaticos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgregaViaticos.Click
        Class_VariablesGlobales.CodChoferLiq = txt_CodChofer.Text
        Class_VariablesGlobales.NomChoferLiq = txt_NombreChofer.Text
        Class_VariablesGlobales.NumLiqChoferLiq = txtb_Consecutivo.Text
        Class_VariablesGlobales.Chofer = Class_VariablesGlobales.CodChoferLiq

        Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION"
        Class_VariablesGlobales.TituloDetalleGasto = "Viaticos"
        Class_VariablesGlobales.FechaIni = dtp_FechaIni_Recibos.Value.Date
        Class_VariablesGlobales.FechaFin = dtp_FechaFin_Recibos.Value.Date

        Class_VariablesGlobales.frmDetalle_Gastos_Choferes = New Detalle_Gastos_Choferes
        Class_VariablesGlobales.frmDetalle_Gastos_Choferes.MdiParent = Principal
        Class_VariablesGlobales.frmDetalle_Gastos_Choferes.Show()


    End Sub

    Private Sub btn_AgregaCombustibles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgregaCombustibles.Click
        Class_VariablesGlobales.CodChoferLiq = txt_CodChofer.Text
        Class_VariablesGlobales.NomChoferLiq = txt_NombreChofer.Text
        Class_VariablesGlobales.NumLiqChoferLiq = txtb_Consecutivo.Text
        Class_VariablesGlobales.Chofer = Class_VariablesGlobales.CodChoferLiq
        Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION"
        Class_VariablesGlobales.TituloDetalleGasto = "Combustible"
        Class_VariablesGlobales.FechaIni = dtp_FechaIni_Recibos.Value.Date
        Class_VariablesGlobales.FechaFin = dtp_FechaFin_Recibos.Value.Date

        Class_VariablesGlobales.frmDetalle_Gastos_Choferes = New Detalle_Gastos_Choferes
        Class_VariablesGlobales.frmDetalle_Gastos_Choferes.MdiParent = Principal
        Class_VariablesGlobales.frmDetalle_Gastos_Choferes.Show()


    End Sub

    Private Sub btn_AgregaHospedaje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgregaHospedaje.Click
        Class_VariablesGlobales.CodChoferLiq = txt_CodChofer.Text
        Class_VariablesGlobales.NomChoferLiq = txt_NombreChofer.Text
        Class_VariablesGlobales.NumLiqChoferLiq = txtb_Consecutivo.Text
        Class_VariablesGlobales.Chofer = Class_VariablesGlobales.CodChoferLiq
        Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION"
        Class_VariablesGlobales.TituloDetalleGasto = "Hospedaje"
        Class_VariablesGlobales.FechaIni = dtp_FechaIni_Recibos.Value.Date
        Class_VariablesGlobales.FechaFin = dtp_FechaFin_Recibos.Value.Date

        Class_VariablesGlobales.frmDetalle_Gastos_Choferes = New Detalle_Gastos_Choferes
        Class_VariablesGlobales.frmDetalle_Gastos_Choferes.MdiParent = Principal
        Class_VariablesGlobales.frmDetalle_Gastos_Choferes.Show()
    End Sub

    Private Sub btn_Agrega_Imprevistos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Agrega_Imprevistos.Click
        Class_VariablesGlobales.CodChoferLiq = txt_CodChofer.Text
        Class_VariablesGlobales.NomChoferLiq = txt_NombreChofer.Text
        Class_VariablesGlobales.NumLiqChoferLiq = txtb_Consecutivo.Text
        Class_VariablesGlobales.Chofer = Class_VariablesGlobales.CodChoferLiq
        Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION"
        Class_VariablesGlobales.TituloDetalleGasto = "Imprevistos"
        Class_VariablesGlobales.FechaIni = dtp_FechaIni_Recibos.Value.Date
        Class_VariablesGlobales.FechaFin = dtp_FechaFin_Recibos.Value.Date

        Class_VariablesGlobales.frmDetalle_Gastos_Choferes = New Detalle_Gastos_Choferes
        Class_VariablesGlobales.frmDetalle_Gastos_Choferes.MdiParent = Principal
        Class_VariablesGlobales.frmDetalle_Gastos_Choferes.Show()
    End Sub

    Private Sub btn_AgregaOtros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgregaOtros.Click
        Class_VariablesGlobales.CodChoferLiq = txt_CodChofer.Text
        Class_VariablesGlobales.NomChoferLiq = txt_NombreChofer.Text
        Class_VariablesGlobales.NumLiqChoferLiq = txtb_Consecutivo.Text
        Class_VariablesGlobales.Chofer = Class_VariablesGlobales.CodChoferLiq
        Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION"
        Class_VariablesGlobales.TituloDetalleGasto = "Otros"
        Class_VariablesGlobales.FechaIni = dtp_FechaIni_Recibos.Value.Date
        Class_VariablesGlobales.FechaFin = dtp_FechaFin_Recibos.Value.Date


        Class_VariablesGlobales.frmDetalle_Gastos_Choferes = New Detalle_Gastos_Choferes
        Class_VariablesGlobales.frmDetalle_Gastos_Choferes.MdiParent = Principal
        Class_VariablesGlobales.frmDetalle_Gastos_Choferes.Show()
    End Sub

    Private Sub btn_AgregaDepositos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        Class_VariablesGlobales.CodChoferLiq = txt_CodChofer.Text
        Class_VariablesGlobales.NomChoferLiq = txt_NombreChofer.Text
        'NumLiqChoferLiq = txtb_Consecutivo.Text
        Class_VariablesGlobales.Chofer = Class_VariablesGlobales.CodChoferLiq


        Admin_Depositos_Choferes.Show()


        'If Class_VariablesGlobales.LIQUIDANDO = "CHOFERES" Then
        '    Try
        '        Class_VariablesGlobales.MisPropiedades.FrmDepChofer.Show()
        '    Catch ex As Exception
        '        Class_VariablesGlobales.MisPropiedades.FrmDepChofer = New Admin_Depositos_Choferes
        '        Class_VariablesGlobales.MisPropiedades.FrmDepChofer.MdiParent = Principal
        '        Class_VariablesGlobales.MisPropiedades.FrmDepChofer.Show()

        '    End Try
        'Else
        '    Class_VariablesGlobales.MisPropiedades.FrmDepAg.Show()
        'End If

    End Sub

    Private Sub dgv_Depositos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_Depositos.CellContentClick
        'Admin_Depositos_Choferes.Show()
        '[DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],[DPMONTO],[DPAGENTE],[DPOBS],[DPLIQUIDACION],[DP_TIPO_LIQ]

        Try
            Class_VariablesGlobales.MisPropiedades.FrmDepChofer.Show()
        Catch ex As Exception
            Class_VariablesGlobales.MisPropiedades.FrmDepChofer = New Admin_Depositos_Choferes
            Class_VariablesGlobales.MisPropiedades.FrmDepChofer.MdiParent = Principal
            Class_VariablesGlobales.MisPropiedades.FrmDepChofer.Show()
        End Try

        Class_VariablesGlobales.frmDeposChofer.txb_consecutivo.Text = dgv_Depositos.CurrentRow.Cells.Item(0).Value
        Class_VariablesGlobales.frmDeposChofer.txb_NumDepo.Text = dgv_Depositos.CurrentRow.Cells.Item(1).Value
        Class_VariablesGlobales.frmDeposChofer.dtp_Fecha.Text = dgv_Depositos.CurrentRow.Cells.Item(2).Value
        Class_VariablesGlobales.frmDeposChofer.cbbx_Banco.Text = dgv_Depositos.CurrentRow.Cells.Item(3).Value
        Class_VariablesGlobales.frmDeposChofer.txb_Monto.Text = dgv_Depositos.CurrentRow.Cells.Item(4).Value
        Class_VariablesGlobales.frmDeposChofer.txb_CodAgente.Text = dgv_Depositos.CurrentRow.Cells.Item(6).Value
        Class_VariablesGlobales.frmDeposChofer.txb_NomAgente.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneNameAgente(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.frmDeposChofer.txb_CodAgente.Text)
        Class_VariablesGlobales.frmDeposChofer.txb_Comentario.Text = dgv_Depositos.CurrentRow.Cells.Item(5).Value

        Class_VariablesGlobales.frmDeposChofer.txb_Liquidacion.Text = dgv_Depositos.CurrentRow.Cells.Item(7).Value
        If dgv_Depositos.CurrentRow.Cells.Item(9).Value = "0" Then
            Class_VariablesGlobales.frmDeposChofer.cbbx_Subido.Text = "NO"
        Else
            Class_VariablesGlobales.frmDeposChofer.cbbx_Subido.Text = "SI"
        End If
        'Class_VariablesGlobales.frmDeposAgente.txtb_Subido.Text = dgv_Depositos.CurrentRow.Cells.Item(9).Value
        Class_VariablesGlobales.frmDeposChofer.dtp_FechaContable.Text = dgv_Depositos.CurrentRow.Cells.Item(10).Value

        Class_VariablesGlobales.frmDeposChofer.btn_AgGuardar.Enabled = False
        Class_VariablesGlobales.frmDeposChofer.btn_AgModif.Enabled = True
        Class_VariablesGlobales.frmDeposChofer.btn_AgElimina.Enabled = True
    End Sub

    Private Sub Liquidacion_Choferes_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Class_VariablesGlobales.NumLiqui = ""
        Class_VariablesGlobales.NumLiqui_Chofer = ""
        Class_VariablesGlobales.NumLiqui_Chofer = Nothing
        Class_VariablesGlobales.NumLiqui = Nothing
        Class_VariablesGlobales.Fac_Llamadas_Desde = ""
        Class_VariablesGlobales.IMPRIMIENDO = ""
    End Sub

    Private Sub btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Guardar.Click

        'Try

        '    'hilo de ejecucion constante
        '    trd1 = New Thread(AddressOf FuncionEn_BackGroud_GuardModif)
        '    trd1.IsBackground = Enabled
        '    'trd2.Priority = ThreadPriority.Highest
        '    CheckForIllegalCrossThreadCalls = False
        '    trd1.Start()

        'Catch ex As Exception
        '    MessageBox.Show("[ " & Now & " ] ERROR EN btn_Guardar_Click [ " & ex.Message & " ]")
        'End Try
        FuncionEn_BackGroud_GuardModif()
    End Sub

    Public Function FuncionEn_BackGroud_GuardModif()
        Me.Enabled = False
        ' ProgressBar1.Maximum = 6


        If btn_Guardar.Text = "GUARDAR" Then
            Guardar()
        Else
            Modificar()
        End If

        Me.Enabled = True
        valProgres = 0


    End Function


    Public Function Imprimir()
        Class_VariablesGlobales.LiquiChoferes_ConseLiq = txtb_Consecutivo.Text
        Class_VariablesGlobales.LiquiChoferes_FechaIni = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date)
        Class_VariablesGlobales.LiquiChoferes_FechaFin = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date)
        Class_VariablesGlobales.LiquiChoferes_FechaIni_Recibos = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni_Recibos.Value.Date)
        Class_VariablesGlobales.LiquiChoferes_FechaFin_Recibos = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin_Recibos.Value.Date)

        'Class_VariablesGlobales.LiquiChoferes_ConseRepFacturas = Txtb_RepFactura.Text
        Class_VariablesGlobales.LiquiChoferes_CodAgente = txt_CodChofer.Text


        frmReporte.Show()
    End Function

    Private Sub btn_Modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Imprimir.Click
        Imprimir()
    End Sub

    Private Sub btn_Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Buscar.Click
        Lista_LiquidacionesChoferes.Show()
    End Sub

    Private Sub Btn_Atras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Atras.Click
        Navegar(CInt(txtb_Consecutivo.Text) - 1)
    End Sub

    Private Sub Btn_Adelante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Adelante.Click
        Navegar(CInt(txtb_Consecutivo.Text) + 1)
    End Sub



    Public Function Navegar(ByVal NumLiquidacion As Integer)
        Try

            Dim tablasLiq As New DataTable
            Dim Reporte As String
            Dim Cadena As String
            Class_VariablesGlobales.CREANDO_LIQ_CHOFER = False
            btn_Guardar.Text = "MODIFICAR"
            'consulta segun el numero de documento los campos 
            '[Cosecutivo],[Fecha],[CodAgente],[CedulaAgente],[NombreAgente],[FechaINI],[FechaFIN],[Comentarios],[Tipo],[Anulada]

            For x = 0 To ListView_Agentes.Items.Count
                ListView_Agentes.Items.RemoveByKey(x)
            Next


            For x = 0 To ListV_Reportes.Items.Count
                ListV_Reportes.Items.RemoveByKey(x)
            Next

            Do While ListV_Reportes.Items.Count <> 0
                ListV_Reportes.Items.Remove(ListV_Reportes.Items(0))
            Loop

            ListView_Agentes.Clear()
            ListView_Agentes.Refresh()

            tablasLiq = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLiquidaciones_Choferes(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.TipoLiqui, "", "", NumLiquidacion)
            If tablasLiq.Rows.Count > 0 Then

                tablasLiq.Rows(0).Item("Fecha").ToString()
                tablasLiq.Rows(0).Item("Tipo").ToString()

                Class_VariablesGlobales.NumLiqui = tablasLiq.Rows(0).Item("Cosecutivo").ToString()
                Class_VariablesGlobales.NumLiqui_Chofer = Class_VariablesGlobales.NumLiqui
                Class_VariablesGlobales.LiquidacionRecuperada = Class_VariablesGlobales.NumLiqui
                Class_VariablesGlobales.frmLiqChof.txtb_Consecutivo.Text = tablasLiq.Rows(0).Item("Cosecutivo").ToString()
                Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text = tablasLiq.Rows(0).Item("CodAgente").ToString()
                Class_VariablesGlobales.frmLiqChof.txtb_Cedula.Text = tablasLiq.Rows(0).Item("CedulaAgente").ToString()
                Class_VariablesGlobales.frmLiqChof.txt_NombreChofer.Text = tablasLiq.Rows(0).Item("NombreAgente").ToString()
                Class_VariablesGlobales.frmLiqChof.dtp_FechaIni_Recibos.Text = tablasLiq.Rows(0).Item("FechaINI_Recibos").ToString()
                Class_VariablesGlobales.frmLiqChof.dtp_FechaFin_Recibos.Text = tablasLiq.Rows(0).Item("FechaFIN_Recibos").ToString()
                Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Value = tablasLiq.Rows(0).Item("FechaINI").ToString()
                Class_VariablesGlobales.frmLiqChof.dtp_FechaFin.Value = tablasLiq.Rows(0).Item("FechaFIN").ToString()
                Class_VariablesGlobales.frmLiqChof.txtb_Comentarios.Text = tablasLiq.Rows(0).Item("Comentarios").ToString()
                Class_VariablesGlobales.frmLiqChof.txtb_Ruta.Text = tablasLiq.Rows(0).Item("Ruta").ToString()

                'Class_VariablesGlobales.frmLiqChof.Txtb_RepFactura.Text = tablasLiq.Rows(0).Item("CodRepFacturas").ToString()



                Cadena = tablasLiq.Rows(0).Item("CodRepFacturas").ToString()


                For x = 0 To Cadena.Length - 1
                    If Cadena.Chars(x) = "," Then
                        ListV_Reportes.Items.Add(Reporte)
                        Reporte = ""
                    Else
                        Reporte = Reporte & Cadena.Chars(x)
                    End If
                Next
                If Reporte <> "" Then
                    ListV_Reportes.Items.Add(Reporte)
                End If

                Reporte = Nothing

                'Dim Ag As String = ""
                'For x = 0 To Cadena.Length - 1

                '    If Cadena.Chars(x) = "," Then
                '        Class_VariablesGlobales.frmLiqChof.ListView_Agentes.Items.Add(Ag)
                '        Ag = ""
                '    Else
                '        Ag = Ag & (Cadena.Chars(x))

                '    End If
                'Next


                Cargar()

                'verifica si esta anulada
                If tablasLiq.Rows(0).Item("Anulada").ToString() = "1" Then
                    Class_VariablesGlobales.frmLiqChof.btn_Anular.Enabled = False
                    Class_VariablesGlobales.frmLiqChof.TabControl1.Enabled = False
                    Class_VariablesGlobales.Chofer = Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text
                    Class_VariablesGlobales.frmLiqChof.btn_Cargar.Enabled = False
                    Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Enabled = False
                    Class_VariablesGlobales.frmLiqChof.dtp_FechaFin.Enabled = False
                    'Class_VariablesGlobales.frmLiqChof.btn_Guardar.Enabled = False
                    Class_VariablesGlobales.frmLiqChof.btn_Imprimir.Enabled = True
                    Class_VariablesGlobales.frmLiqChof.lbl_Anulado.Visible = True
                    Class_VariablesGlobales.frmLiqChof.txtb_Diferencias.Enabled = False


                Else
                    Class_VariablesGlobales.frmLiqChof.lbl_Anulado.Visible = False
                    Class_VariablesGlobales.frmLiqChof.btn_Anular.Enabled = True
                    Class_VariablesGlobales.frmLiqChof.lbl_Anulado.Visible = False
                    Class_VariablesGlobales.frmLiqChof.TabControl1.Enabled = True
                    Class_VariablesGlobales.Chofer = Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text
                    Class_VariablesGlobales.frmLiqChof.btn_Cargar.Enabled = True
                    Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Enabled = True
                    Class_VariablesGlobales.frmLiqChof.dtp_FechaFin.Enabled = True
                    'Class_VariablesGlobales.frmLiqChof.btn_Guardar.Enabled = False
                    Class_VariablesGlobales.frmLiqChof.btn_Imprimir.Enabled = True
                End If


            Else

                MsgBox("No existe la liquidacion [ " & NumLiquidacion & " ]")
                NuevaLiqChofer()


            End If


            tablasLiq = Nothing
            Reporte = Nothing
            Cadena = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub dtp_FechaIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Class_VariablesGlobales.FechaIni = dtp_FechaIni.Value.Date
        dtp_FechaFin.Value = dtp_FechaIni.Value.Date

    End Sub

    Private Sub dtp_FechaFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Class_VariablesGlobales.FechaFin = dtp_FechaFin.Value.Date




    End Sub

    Private Sub btn_Anular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Anular.Click
        'EL ANULAR DEBERIA PERMITIR USAR LOS DATOS EN OTRA LIQUIDACION PARA PODER VOLVERLA A CREAR
        Dim result1 As DialogResult = MessageBox.Show("Si anula la Liquidacion no podra editarlo\n Realmente desea anular el Liquidacion?", _
   "Important Question", _
   MessageBoxButtons.YesNo)

        If result1 = DialogResult.Yes Then
            Class_VariablesGlobales.Obj_Funciones_SQL.AnulaLiquidacion_Choferes(Class_VariablesGlobales.SQL_Comman1, txtb_Consecutivo.Text, Class_VariablesGlobales.TipoLiqui)
            txtb_Consecutivo.Text = Obj_SQL_CONEXION.ObtieneConsecutivo(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.TipoLiqui)
            limpia()


        End If
        If result1 = DialogResult.No Then


        End If
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'llama a un formulara para poder agregar la factura
        LiqChoferes_AddFactura.Show()


    End Sub


    Private Sub btn_AddDeposito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AddDeposito.Click

        'Class_VariablesGlobales.frmLiqChof = New Liquidacion_Choferes
        'Class_VariablesGlobales.frmLiqChof.MdiParent = Me
        ''Class_VariablesGlobales.frmLiqAge.Show()
        Class_VariablesGlobales.LIQUIDANDO = "CHOFERES"
        'Class_VariablesGlobales.frmLiqChof.Hide()
        'ListaChoferes.Close()

        'CodAgenteLiq = txt_CodChofer.Text
        'NomAgenteLiq = txt_NombreChofer.Text
        'NumLiqAgenteLiq = txtb_Consecutivo.Text


        Class_VariablesGlobales.CodChoferLiq = txt_CodChofer.Text
        Class_VariablesGlobales.NomChoferLiq = txt_NombreChofer.Text
        Class_VariablesGlobales.NumLiqChoferLiq = txtb_Consecutivo.Text
        Class_VariablesGlobales.Chofer = txt_NombreChofer.Text

        Class_VariablesGlobales.frmDeposChofer = New Admin_Depositos_Choferes
        Class_VariablesGlobales.frmDeposChofer.MdiParent = Principal
        Class_VariablesGlobales.frmDeposChofer.Show()
    End Sub



    Public Function Modificar()

        Try


            Dim contardor As Integer = 0
            Dim ListaAgenteas As String
            Dim ListaReportes As String
            Dim tbl As New DataTable
            Dim cont As Integer = 0


            If txtb_Ruta.Text = "" Then
                MsgBox("Debe indicar la Ruta")
                Exit Function
            End If

            If ListView_Agentes.Items.Count = 0 Then
                MsgBox("Debe indicar almenos 1 Chofer")
                Exit Function
            End If


            For Each item As ListViewItem In ListView_Agentes.Items
                ListaAgenteas &= item.Text & ","
            Next


            Try


                For Each item As ListViewItem In ListV_Reportes.Items
                    ListaReportes &= item.Text & ","
                    'AQUI DEBERA ACTUALIZAR EL NUMERO DE LIQUIDACION AL REPORTE O REPORTES DE FACTURAS SELECICOADOS POR LO QUE DEBERA RECORRER EL LISTVIEW
                    'QUE ALMANCENA LOS CONSECUTIVOS DE LOS REPORTES
                    If item.Text <> "" Then
                        Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaRepFacturas(Class_VariablesGlobales.SQL_Comman1, txtb_Consecutivo.Text, txt_CodChofer.Text, item.Text)
                    End If
                Next
            Catch ex As Exception
                MsgBox(" ERROR AL ACTUALIZAR LAS FACTURAS [ " & ex.Message & " ]")
            End Try


            Try



                contardor = 0
                'Obtiene la tabla de los depositos de la liquidacion para indicarle la liquidacion en la que quedaron
                While contardor < dgv_Depositos.Rows.Count - 1
                    'guardarle el numero de liquidacion a los depositos
                    Class_VariablesGlobales.Obj_Funciones_SQL.ModificaDeposito(Class_VariablesGlobales.SQL_Comman1, dgv_Depositos.Rows(contardor).Cells(0).Value.ToString(), "", "", "", "", "", "", txtb_Consecutivo.Text, Class_VariablesGlobales.TipoLiqui, True, "", "")
                    contardor += 1
                End While
            Catch ex As Exception
                MsgBox(" ERROR AL ACTUALIZAR LOS DEPOSITOS [ " & ex.Message & " ]")
            End Try



            Try


                'Obtiene la tabla de los GASTOS de la liquidacion para indicarle la liquidacion en la que quedaron



                tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneListaGastos(Class_VariablesGlobales.SQL_Comman1, txtb_Consecutivo.Text, Class_VariablesGlobales.TipoLiqui, txt_CodChofer.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date))
                If tbl.Rows.Count > 0 Then
                    For Each row As DataRow In tbl.Rows
                        Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaGasto(Class_VariablesGlobales.SQL_Comman1, "", "", "", "", txtb_Consecutivo.Text, Class_VariablesGlobales.TipoLiqui, "", "", Trim(tbl.Rows(cont).Item("DocNum").ToString()), True, True)
                        cont += 1
                    Next
                End If

                cont = Nothing
                tbl = Nothing
            Catch ex As Exception
                MsgBox(" ERROR AL ACTUALIZAR LOS GASTOS [ " & ex.Message & " ]")
            End Try

            Class_VariablesGlobales.CodAgenteLiq = ""
            Class_VariablesGlobales.NomAgenteLiq = ""
            Class_VariablesGlobales.NumLiqAgenteLiq = ""
            Class_VariablesGlobales.NumLiqui = ""
            Class_VariablesGlobales.Obj_Funciones_SQL.ModificaLiquidacion_Choferes(Class_VariablesGlobales.SQL_Comman1, txtb_Consecutivo.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaLiquidacion.Value.Date), txt_CodChofer.Text, txtb_Cedula.Text, txt_NombreChofer.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date), txtb_Comentarios.Text, Class_VariablesGlobales.TipoLiqui, txtb_Diferencias.Text, ListaAgenteas, txtb_Ruta.Text, ListaReportes, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni_Recibos.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin_Recibos.Value.Date))

            contardor = 0


            Try

                'Carga el numero de liquidacion al recibo de SAP
                While contardor < dgv_Recibos.Rows.Count - 1
                    'Obj_SAP.ActualizaPago(dgv_Recibos.Rows(contardor).Cells(0).Value.ToString(), Trim(txt_CodChofer.Text), txtb_Consecutivo.Text)

                    contardor += 1
                End While

            Catch ex As Exception
                MsgBox(" ERROR AL ACTUALIZAR LAS RECIBOS [ " & ex.Message & " ]")

            End Try

            contardor = Nothing


            Dim Pregunta As Integer

            Pregunta = MsgBox("¿Desea imprimir la liquidacion?.", vbYesNo + vbExclamation + vbDefaultButton2, "IMPRIMIR LIQUIDACIONES")

            If Pregunta = vbYes Then
                Imprimir()
            Else

            End If


            limpia()
            txtb_Consecutivo.Text = Obj_SQL_CONEXION.ObtieneConsecutivo(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.TipoLiqui)


            contardor = Nothing
            ListaAgenteas = Nothing
            ListaReportes = Nothing
            tbl = Nothing
            cont = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR [ " & ex.Message & " ]")

        End Try
    End Function

    Public Function Guardar()
        Try



            Dim contardor As Integer = 0
            Dim ListaAgenteas As String
            Dim ListaReportes As String


            Class_VariablesGlobales.NumLiqui = ""
            '[Cosecutivo],[Fecha],[CodAgente],[CedulaAgente],[NombreAgente],[FechaINI],[FechaFIN],[Comentarios],[Tipo]
            If txtb_Ruta.Text = "" Then
                MsgBox("Debe indicar la Ruta")
                Exit Function
            End If
            If ListView_Agentes.Items.Count = 0 Then
                MsgBox("Debe indicar almenos 1 agente")
                Exit Function
            End If

            For Each item As ListViewItem In ListView_Agentes.Items
                ListaAgenteas &= item.Text & ","
            Next

            For Each item As ListViewItem In ListV_Reportes.Items
                ListaReportes &= item.Text & ","
            Next

            Class_VariablesGlobales.NumLiqui_Chofer = txtb_Consecutivo.Text

            If Class_VariablesGlobales.Obj_Funciones_SQL.GuardarLiquidacion_Choferes(Class_VariablesGlobales.SQL_Comman1, txtb_Consecutivo.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaLiquidacion.Value.Date), txt_CodChofer.Text, txtb_Cedula.Text, txt_NombreChofer.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date), txtb_Comentarios.Text, Class_VariablesGlobales.LIQUIDANDO, txtb_Diferencias.Text, txtb_Ruta.Text, ListaAgenteas, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni_Recibos.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin_Recibos.Value.Date), ListaReportes) = 0 Then
                contardor = 0

                ''Obtiene la tabla de los depositos de la liquidacion para indicarle la liquidacion en la que quedaron
                While contardor < dgv_Depositos.Rows.Count - 1
                    'guardarle el numero de liquidacion a los depositos
                    Class_VariablesGlobales.Obj_Funciones_SQL.ModificaDeposito(Class_VariablesGlobales.SQL_Comman1, dgv_Depositos.Rows(contardor).Cells(0).Value.ToString(), "", "", "", "", "", "", txtb_Consecutivo.Text, Class_VariablesGlobales.TipoLiqui, True, "", "")
                    contardor += 1
                End While



                'Obtiene la tabla de los GASTOS de la liquidacion para indicarle la liquidacion en la que quedaron
                Dim tbl As New DataTable
                Dim cont As Integer = 0
                tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneListaGastos(Class_VariablesGlobales.SQL_Comman1, txtb_Consecutivo.Text, Class_VariablesGlobales.TipoLiqui, txt_CodChofer.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni_Recibos.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin_Recibos.Value.Date))
                If tbl.Rows.Count > 0 Then
                    For Each row As DataRow In tbl.Rows
                        Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaGasto(Class_VariablesGlobales.SQL_Comman1, "", "", "", "", txtb_Consecutivo.Text, Class_VariablesGlobales.TipoLiqui, "", "", Trim(tbl.Rows(cont).Item("DocNum").ToString()), True, True)
                        cont += 1
                    Next
                End If

                contardor = 0
                Try


                    'Carga el numero de liquidacion al recibo de SAP
                    While contardor < dgv_Recibos.Rows.Count - 1
                        'Obj_SAP.ActualizaPago(dgv_Recibos.Rows(contardor).Cells(0).Value.ToString(), Trim(txt_CodChofer.Text), txtb_Consecutivo.Text)

                        contardor += 1
                    End While
                Catch ex As Exception
                    MsgBox(" ERROR AL ACTUALIZAR LOS RECIBOS [ " & ex.Message & " ]")

                End Try

                Try



                    'AQUI DEBERA ACTUALIZAR EL NUMERO DE LIQUIDACION AL REPORTE O REPORTES DE FACTURAS SELECICOADOS POR LO QUE DEBERA RECORRER EL LISTVIEW
                    'QUE ALMANCENA LOS CONSECUTIVOS DE LOS REPORTES
                    For Each item As ListViewItem In ListV_Reportes.Items
                        Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaRepFacturas(Class_VariablesGlobales.SQL_Comman1, txtb_Consecutivo.Text, txt_CodChofer.Text, item.Text)
                    Next

                Catch ex As Exception
                    MsgBox(" ERROR AL ACTUALIZAR LAS FACTURAS [ " & ex.Message & " ]")

                End Try
                'cont = Nothing
                'tbl = Nothing



                Class_VariablesGlobales.Obj_Funciones_SQL.Aumenta_Consecutivos(Class_VariablesGlobales.SQL_Comman1, CInt(txtb_Consecutivo.Text) + 1, Class_VariablesGlobales.LIQUIDANDO)
                Imprimir()
                limpia()
                txtb_Consecutivo.Text = Obj_SQL_CONEXION.ObtieneConsecutivo(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.LIQUIDANDO)





                contardor = Nothing
                ListaAgenteas = Nothing
                ListaReportes = Nothing
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR [" & ex.Message & "]")

        End Try

    End Function






    Private Sub dtp_FechaIni_Recibos_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_FechaIni_Recibos.VisibleChanged

    End Sub

    Private Sub dtp_FechaIni_Recibos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_FechaIni_Recibos.ValueChanged
        dtp_FechaFin_Recibos.Value = dtp_FechaIni_Recibos.Value
    End Sub

    Private Sub dtp_FechaFin_Recibos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_FechaFin_Recibos.ValueChanged

    End Sub




    Private Sub btn_AddRecibos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AddRecibos.Click
        'esta opcion sera usada luego de que una liquidacion es guardada, cuando se guarda una liquidacion el sistema pone el numero de liquidacion al recibo
        ' para que la liquidacion jale un recibo pendiente creamos esta opcion paa poder asignarle el numero de liquidacion al recibo que pongamos en el formulario que aparesera

        Dim MDIForm As New AddRecibo
        MDIForm.MdiParent = Principal
        MDIForm.Show()

    End Sub

    Private Sub btn_GoReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GoReporte.Click
        Dim tudato As String

        If ListV_Reportes.SelectedIndices.Count <> 0 Then
            ' step through each selected item
            Dim i As Int16
            For Each i In ListV_Reportes.SelectedIndices
                Dim s As String
                'NUMERO DE REPORTE DE FACTURA SELECCIONADO

                'Class_VariablesGlobales.Conse_Repcarga = ListV_Reportes.Items(ListV_Reportes.Items(i).Index).ToString


                Class_VariablesGlobales.Conse_Repcarga = ListV_Reportes.SelectedItems(0).SubItems(0).Text()



            Next i


            Class_VariablesGlobales.Obj_Reporte_Facturas = New Reporte_Facturas
            Class_VariablesGlobales.Obj_Reporte_Facturas.MdiParent = Principal
            Class_VariablesGlobales.Obj_Reporte_Facturas.Show()


            CargaDetRepFacturas(Class_VariablesGlobales.SQL_Comman2, CSng(Class_VariablesGlobales.Conse_Repcarga))

        End If
    End Sub



    Public Function CargaDetRepFacturas(ByVal SQL_Comman As SqlCommand, ByVal Conse_RepFacturas As String)
        Dim tabla As New DataTable
        Dim cont As Integer
        Dim TotalFaltante As Double
        Dim TotalPeso As Double
        Dim Total As Double
        Dim TotalGeneral As Double
        Dim Anulado As Boolean = False
        Dim Tipo As String = "CONTADO"

        tabla = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaDetRepFacturas(SQL_Comman, Conse_RepFacturas, Tipo)

        If tabla.Rows.Count > 0 Then
            For Each rowLocal As DataRow In tabla.Rows

                Total += CDbl(tabla.Rows(cont).Item("DocTotal").ToString())
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

            Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_TotalContado.Text = Format(Val(Total), "currency")

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
            Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman1, "AYUDANTE", Ayudante)
            ' Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneChoferes(Class_VariablesGlobales.SQL_Comman2, "AYUDANTE", Ayudante)
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

            '[Consecutivo],[DocNum],[FechaReporte],[Hora],[FechaFactura],[CodCliente],[Nombre],[ItemCode],[ItemName],[Cant],[Descuento],[Precio],[Imp],[MontoDesc],[MontoImp],[Total],[Fac_INI],[Fac_FIN],[NombreRuta],[Chofer],[Ayudante]  

            If Tipo = "CONTADO" Then
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.DataSource = tabla
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(1).Width = 50
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(2).Width = 70
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(3).Width = 65
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(4).Width = 75
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(5).Width = 65
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(6).Width = 300
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(0).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(7).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(8).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(9).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(10).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(11).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(12).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(13).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacContado.Columns(14).Visible = False
            End If

            If tabla.Rows(0).Item("Anulado").ToString() = "1" Then
                Anulado = True
            Else
                Anulado = False
            End If
        End If

        '***************************************************************************************************************

        Tipo = "CREDITO"
        tabla = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaDetRepFacturas(SQL_Comman, Conse_RepFacturas, Tipo)

        If tabla.Rows.Count > 0 Then
            Total = 0
            For Each rowLocal As DataRow In tabla.Rows

                Total += CDbl(tabla.Rows(cont).Item("DocTotal").ToString())
                cont += 1
            Next

            TotalGeneral += Total


            Class_VariablesGlobales.Obj_Reporte_Facturas.txb_Numero.Text = tabla.Rows(0).Item("Consecutivo").ToString()
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_Ruta.Text = tabla.Rows(0).Item("NombreRuta").ToString()
            Class_VariablesGlobales.Obj_Reporte_Facturas.dtp_FechaReporte.Text = tabla.Rows(0).Item("FechaReporte").ToString()
            Class_VariablesGlobales.Obj_Reporte_Facturas.TXB_Hora.Text = tabla.Rows(0).Item("Hora").ToString()
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACINI.Text = tabla.Rows(0).Item("Fac_INI").ToString()
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_FACFIN.Text = tabla.Rows(0).Item("Fac_FIN").ToString()
            'Class_VariablesGlobales.Obj_Reporte_Facturas.lbl_Total.Text = Format(Val(Total), "currency")

            Class_VariablesGlobales.Obj_Reporte_Facturas.Txb_TotalCredito.Text = Format(Val(Total), "currency")

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

            ' Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneChoferes(Class_VariablesGlobales.SQL_Comman2, "CHOFER", Chofer)
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
            Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman1, "AYUDANTE", Chofer)
            ' Tbl = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneChoferes(Class_VariablesGlobales.SQL_Comman2, "AYUDANTE", Ayudante)
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









            If Tipo = "CREDITO" Then
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.DataSource = tabla
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(1).Width = 50
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(2).Width = 70
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(3).Width = 65
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(4).Width = 75
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(5).Width = 65
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(6).Width = 300
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(0).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(7).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(8).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(9).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(10).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(11).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(12).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(13).Visible = False
                Class_VariablesGlobales.Obj_Reporte_Facturas.DataGV_RepFacCredito.Columns(14).Visible = False
            End If


            If tabla.Rows(0).Item("Anulado").ToString() = "1" Then
                Anulado = True
            Else
                Anulado = False
            End If
        End If


        If Anulado = True Then
            Class_VariablesGlobales.Obj_Reporte_Facturas.btn_Limpiar.Enabled = False

            Class_VariablesGlobales.Obj_Reporte_Facturas.btn_eliminar.Visible = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.Lbl_Anulado.Visible = True

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




        Else

            Class_VariablesGlobales.Obj_Reporte_Facturas.btn_Limpiar.Enabled = True

            Class_VariablesGlobales.Obj_Reporte_Facturas.btn_eliminar.Visible = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.Lbl_Anulado.Visible = False

            Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_ConBod1.Enabled = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.Rb_SinBod1.Enabled = True


            Class_VariablesGlobales.Obj_Reporte_Facturas.txb_Numero.Enabled = True
            Class_VariablesGlobales.Obj_Reporte_Facturas.txtb_Ruta.Enabled = True
            'Class_VariablesGlobales.Obj_Reporte_Facturas.dtp_FechaReporte.Enabled = True
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




        Class_VariablesGlobales.Obj_Reporte_Facturas.lbl_Total.Text = Format(Val(TotalGeneral), "currency")
        TotalGeneral = 0

        ' Me.Close()




    End Function





    Private Sub btn_QuitaRepFActuras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_QuitaRepFActuras.Click
        Dim tudato As String

        If ListV_Reportes.SelectedIndices.Count <> 0 Then
            ' step through each selected item
            Dim i As Int16
            For Each i In ListV_Reportes.SelectedIndices
                Dim s As String
                'debe mandar se modificar el reporte eliminando el numero de la liquidacion
                Class_VariablesGlobales.Obj_Funciones_SQL.UnificaRepFacturas("", ListV_Reportes.SelectedItems(0).SubItems(0).Text(), "", Class_VariablesGlobales.SQL_Comman1)
                ListV_Reportes.Items.Remove(ListV_Reportes.Items(ListV_Reportes.Items(i).Index))
            Next i
        End If
        Cargar()

    End Sub



    Private Sub btn_AddRepFac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AddRepFac.Click
        Try

            Class_VariablesGlobales.Fac_Llamadas_Desde = "LIQ_CHOFERES"
            Dim MDIForm As New List_RepFacturas_LiqChofer
            MDIForm.MdiParent = Principal
            MDIForm.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


End Class