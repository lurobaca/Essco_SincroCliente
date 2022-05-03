Imports System.Threading

Public Class Pedido_RangoFechaOrdComp

    Public CodProveedor As String
    Public NombreProveedor As String
    Public CondiconPago As String

    Private trd1 As Thread
    Private Sub btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Aceptar.Click
        'hilo de ejecucion constante
        Class_VariablesGlobales.OrCom_Fecha = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Now.Date)

        trd1 = New Thread(AddressOf Generar)
        trd1.IsBackground = Enabled
        trd1.Priority = ThreadPriority.Highest
        trd1.Start()

        CheckForIllegalCrossThreadCalls = False

        btn_Aceptar.Enabled = False

        btn_Aceptar.Text = "Espera Por favor..."
    End Sub

    Function Generar()
        Try

            Cursor = System.Windows.Forms.Cursors.WaitCursor

            Class_VariablesGlobales.frmCreaPedido.FIniOrdCompra = DateTimePicker1.Value.ToShortDateString
            Class_VariablesGlobales.frmCreaPedido.FFINOrdCompra = DateTimePicker2.Value.ToShortDateString

            Class_VariablesGlobales.frmCreaPedido.FFIN_ProyeccionIni = DTP_ProyeccionIni.Value.ToShortDateString()
            Class_VariablesGlobales.frmCreaPedido.FFIN_ProyeccionFin = DTP_ProyeccionFin.Value.ToShortDateString()

            Class_VariablesGlobales.frmCreaPedido.DTP_FechaInicio.Value = DateTimePicker1.Value.ToShortDateString
            Class_VariablesGlobales.frmCreaPedido.DTP_FechaFin.Value = DateTimePicker2.Value.ToShortDateString

            Class_VariablesGlobales.frmCreaPedido.DTP_ProyeccionIni.Value = DateTimePicker1.Value.ToShortDateString
            Class_VariablesGlobales.frmCreaPedido.DTP_ProyeccionFin.Value = DateTimePicker2.Value.ToShortDateString

            Class_VariablesGlobales.frmCreaPedido.Dias.Text = DateDiff(DateInterval.Day, CDate(DateTimePicker1.Value.ToShortDateString), CDate(DateTimePicker2.Value.ToShortDateString))

            Class_VariablesGlobales.frmCreaPedido.txtb_CodProveedor.Text = Class_VariablesGlobales.frmRangoFechaOrdComp.CodProveedor
            Class_VariablesGlobales.frmCreaPedido.txtb_NombreProveedor.Text = Class_VariablesGlobales.frmRangoFechaOrdComp.CondiconPago
            Class_VariablesGlobales.frmCreaPedido.txtb_CondiconPago.Text = Class_VariablesGlobales.frmRangoFechaOrdComp.NombreProveedor

            Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.InbGeneraPedido(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.frmRangoFechaOrdComp.CodProveedor, "", Class_VariablesGlobales.frmCreaPedido.txtb_DiasProxCamion.Text, Class_VariablesGlobales.frmCreaPedido.txtb_PorcRespaldo.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.FIniOrdCompra), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.FFINOrdCompra), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.FFIN_ProyeccionIni), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.FFIN_ProyeccionFin))

            lbl_InicioProcesa.Text = 0
            Progreso.Maximum = Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.RowCount
            lbl_FinProcesa.Text = Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.RowCount
            If Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.RowCount = 0 Then
                btn_Aceptar.Enabled = True

                btn_Aceptar.Text = "Generar"
                Cursor = System.Windows.Forms.Cursors.Default
                MessageBox.Show("Hubo un error por favor vuelva a intentar generar el pedido")

                Exit Function
            End If
            Class_VariablesGlobales.frmCreaPedido.RegulaTamanoColumnas(Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido)
            Class_VariablesGlobales.frmCreaPedido.TotalPedido(Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido)

            If RdBtb_Cajas.Checked = True Then
                Class_VariablesGlobales.frmCreaPedido.RdBtb_Cajas.Checked = True
            Else
                Class_VariablesGlobales.frmCreaPedido.RdBtb_Unidades.Checked = True
            End If



            Dim sugUnidades As Integer
            Dim V_CardCode As String = ""
            Dim V_Alterno As String = ""
            Dim V_CodArticulo As String = ""
            Dim V_ItemName As String = ""
            Dim V_Costo As String = ""
            Dim V_Pack As String = ""
            Dim V_Vta_Monto As String = ""
            Dim V_VtaUni As String = ""
            Dim V_VtaCjs As String = ""
            Dim V_PedAgts As String = ""
            Dim V_Faltante As String = ""
            Dim V_StockR As String = ""
            Dim V_StockRCjs As String = ""
            Dim V_StockR_Monto As String = ""
            Dim V_Dif As String = ""
            Dim V_Cpmtdo As String = ""
            Dim V_CpmtdoCjs As String = ""
            Dim V_Compra As String = ""
            Dim V_PdUni As String = ""
            Dim V_PdCJs As String = ""
            Dim V_PdTotal As String = ""
            Dim V_Prmd_Compra As String = ""
            Dim V_PrmdVtaMs As String = ""
            Dim V_PrmdVtaDs As String = ""
            Dim V_Dias As String = ""
            Dim V_Gramaje As String = ""
            Dim V_CodigoBarras As String = ""
            Dim V_DiasSinMoverse As String = ""
            Dim V_FechaUltimaCompra As String = ""
            Dim V_Vmp As String = ""
            Dim V_Vmatp As String = ""
            Dim V_Vmatatp As String = ""
            Dim V_MEs_Vmp As String = ""
            Dim V_MEs_Vmatp As String = ""
            Dim V_MEs_Vmatatp As String = ""
            Dim V_UnidadDeMedidas As String = ""
            Dim V_UltimaCompra As String = ""
            Dim Pd_CJs_Cheado As String = ""
            Dim Pd_Unid_Cheado As String = ""
            Dim Pd_Total_Cheado As String = ""
            Dim Motivo As String = ""
            Dim FCFIn_Venta As String = ""
            Dim FechaUltimaVenta As String = ""
            Dim CantidadUltimaVenta As String = ""
            Dim FechaUltimoPedido As String = ""
            Dim CantidadUltimoPedido As String = ""

            Dim Fecha As String = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Now.Date)
            'Crea el id del encabezado y lo retorna
            Dim id_Pedido As Integer = Class_VariablesGlobales.Obj_Funciones_SQL.CreaEncabezadoPedidor(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.frmCreaPedido.txtb_NombreProveedor.Text, Fecha)

            Class_VariablesGlobales.frmCreaPedido.lbl_NumOrden.Text = id_Pedido
            Dim Cont As Integer = 0
            For Each row As DataGridViewRow In Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows
                Try
                    lbl_InicioProcesa.Text = Cont
                    Progreso.Value = Cont

                    If RdBtb_Cajas.Checked = True Then
                        V_UnidadDeMedidas = "CAJAS"
                    Else
                        V_UnidadDeMedidas = "UNIDADES"
                    End If
                    '  If row.Cells(16).Value <> Nothing Then
                    ' FormatNumber(CDbl(row.Cells(6).Value), 2)
                    V_CardCode = row.Cells(0).Value
                    V_Alterno = row.Cells(1).Value
                    V_CodArticulo = row.Cells(2).Value
                    V_ItemName = row.Cells(3).Value
                    V_Costo = row.Cells(4).Value
                    V_Pack = row.Cells(5).Value
                    V_Vta_Monto = row.Cells(6).Value
                    V_VtaUni = row.Cells(7).Value
                    V_VtaCjs = row.Cells(8).Value()
                    V_PedAgts = row.Cells(9).Value
                    V_Faltante = row.Cells(10).Value
                    V_StockR = row.Cells(11).Value
                    V_StockRCjs = row.Cells(12).Value()
                    V_StockR_Monto = row.Cells(13).Value
                    V_Dif = row.Cells(14).Value
                    V_Cpmtdo = row.Cells(15).Value
                    V_CpmtdoCjs = row.Cells(16).Value()
                    V_Compra = row.Cells(17).Value
                    V_PdUni = row.Cells(18).Value
                    V_PdCJs = row.Cells(19).Value()
                    V_PdTotal = row.Cells(20).Value
                    V_CodigoBarras = row.Cells(21).Value
                    V_Gramaje = row.Cells(22).Value
                    V_DiasSinMoverse = row.Cells(23).Value
                    V_Dias = row.Cells(24).Value
                    V_PrmdVtaDs = row.Cells(25).Value
                    V_FechaUltimaCompra = row.Cells(26).Value
                    V_Vmp = row.Cells(27).Value
                    V_Vmatp = row.Cells(28).Value
                    V_Vmatatp = row.Cells(29).Value
                    V_MEs_Vmp = ""
                    V_MEs_Vmatp = ""
                    V_MEs_Vmatatp = ""
                    V_UltimaCompra = row.Cells(30).Value
                    FechaUltimaVenta = row.Cells(32).Value
                    If row.Cells(33).Value.ToString = "" Then
                        CantidadUltimaVenta = "0"
                    Else
                        CantidadUltimaVenta = CInt(row.Cells(33).Value)
                    End If
                    FechaUltimoPedido = row.Cells(34).Value

                    If row.Cells(35).Value.ToString = "" Then
                        CantidadUltimoPedido = "0"
                    Else
                        CantidadUltimoPedido = CInt(row.Cells(35).Value)
                    End If

                    ''----------------------En esta parte deberia generar el sugerido-------------------------------
                    Class_VariablesGlobales.Obj_Funciones_SQL.GuardaOrdenDeCompra(
                                  Cont,
                                 Class_VariablesGlobales.frmCreaPedido.lbl_NumOrden.Text,
                                Class_VariablesGlobales.frmCreaPedido.txtb_CodProveedor.Text,
                                 Class_VariablesGlobales.frmCreaPedido.txtb_NombreProveedor.Text,
                                V_CodArticulo,
                                V_ItemName,
                                Fecha,
                                V_Alterno,
                                V_Pack,
                                V_Costo,
                                V_VtaUni,
                                V_VtaCjs,
                                V_Vta_Monto,
                                V_StockR,
                                V_StockRCjs,
                                V_StockR_Monto,
                                V_Cpmtdo,
                                V_Dias,
                                V_PdCJs,
                                V_PdUni,
                                V_PdTotal,
                                Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.DTP_FechaInicio.Value.ToShortDateString),
                                Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.DTP_FechaFin.Value.ToShortDateString),
                                Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.DTP_ProyeccionIni.Value.ToShortDateString),
                                Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.DTP_ProyeccionFin.Value.ToShortDateString),
                                V_UnidadDeMedidas,
                                V_CodigoBarras,
                                V_Gramaje,
                                V_UltimaCompra,
                                V_PedAgts,
                                V_Faltante,
                                V_CpmtdoCjs,
                                V_FechaUltimaCompra,
                                V_Dif,
                                V_Prmd_Compra,
                                V_PrmdVtaDs,
                                Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.DTP_ProyeccionIni.Value.ToShortDateString),
                                Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.DTP_ProyeccionFin.Value.ToShortDateString),
                                V_DiasSinMoverse,
                                V_Vmp,
                                V_Vmatp,
                                V_Vmatatp,
                                V_MEs_Vmp,
                                V_MEs_Vmatp,
                                V_MEs_Vmatatp,
                                Pd_CJs_Cheado,
                                Pd_Unid_Cheado,
                                Pd_Total_Cheado,
                                Motivo,
                                FCFIn_Venta, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(FechaUltimaVenta),
                                CantidadUltimaVenta, "0",
                                Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(FechaUltimoPedido),
                                CantidadUltimoPedido,
                                Class_VariablesGlobales.SQL_Comman1, True)



                    sugUnidades = 0

                    'End If
                Catch ex As Exception
                    'MsgBox(ex.Message, MsgBoxStyle.Information, "ERROR ")
                End Try

                Cont += 1
            Next

            Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.DataSource = New DataTable

            Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneOrdenCompraTem(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.frmCreaPedido.lbl_NumOrden.Text, False, Class_VariablesGlobales.frmCreaPedido.btn_CrearEnSAP.Enabled, Class_VariablesGlobales.frmCreaPedido.lbl_NumOrden.Text)
            Class_VariablesGlobales.frmCreaPedido.RegulaTamanoColumnas(Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido)
            Class_VariablesGlobales.frmCreaPedido.TotalPedido(Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido)
            Cursor = System.Windows.Forms.Cursors.Default
            '  Class_VariablesGlobales.frmCreaPedido.Recalcula(True)

            Class_VariablesGlobales.frmCreaPedido.txtb_DiasACubrir.Text = CInt(DateDiff("d", Class_VariablesGlobales.frmCreaPedido.DTP_FechaInicio.Value, Class_VariablesGlobales.frmCreaPedido.DTP_FechaFin.Value))

            Class_VariablesGlobales.frmCreaPedido.btn_anular.Enabled = True
            Class_VariablesGlobales.frmCreaPedido.Btn_Adelante.Enabled = True
            Class_VariablesGlobales.frmCreaPedido.Btn_Atras.Enabled = True
            Class_VariablesGlobales.frmCreaPedido.btn_exportar.Enabled = True
            Class_VariablesGlobales.frmCreaPedido.btn_Guardar.Enabled = True
            Class_VariablesGlobales.frmCreaPedido.btn_Cargar.Enabled = True
            Class_VariablesGlobales.frmCreaPedido.btn_Buscar.Enabled = True
            Class_VariablesGlobales.frmCreaPedido.btn_CrearEnSAP.Enabled = True
            Me.Close()

        Catch ex As Exception
            MsgBox("Generar " & ex.Message, MsgBoxStyle.Information, "ERROR ")
        End Try
    End Function

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub DTP_ProyeccionIni_ValueChanged(sender As Object, e As EventArgs) Handles DTP_ProyeccionIni.ValueChanged

    End Sub

    Private Sub DTP_ProyeccionFin_ValueChanged(sender As Object, e As EventArgs) Handles DTP_ProyeccionFin.ValueChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Pedido_RangoFechaOrdComp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class