Public Class Pedido_ListaPedidosGuardados
    Public Shared FINI As String = ""
    Public Shared FFIN As String = ""


    Dim sugUnidades As Integer
    Dim V_ID As String = ""
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
    Dim Revizado As String = ""
    Private Sub dgv_Proveedores_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_OrdenesCompra.CellClick
        Try
            If Class_VariablesGlobales.ListaPedidoLlamadoDesde = "PEDIDOCHEQUEADOS" Then






                Class_VariablesGlobales.frmWMS_PedidosChequeados.ObtienePedidoChequeado(dgv_OrdenesCompra.CurrentRow.Cells.Item(0).Value.ToString())


            Else
                'LLAMADO DESDE PEDIDOR
                Class_VariablesGlobales.frmCreaPedido.lbl_NumOrden.Text = dgv_OrdenesCompra.CurrentRow.Cells.Item(0).Value.ToString
                Class_VariablesGlobales.frmCreaPedido.txtb_CodProveedor.Text = dgv_OrdenesCompra.CurrentRow.Cells.Item(2).Value.ToString
                Class_VariablesGlobales.frmCreaPedido.txtb_NombreProveedor.Text = dgv_OrdenesCompra.CurrentRow.Cells.Item(3).Value.ToString

                Class_VariablesGlobales.OrCom_Fecha = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dgv_OrdenesCompra.CurrentRow.Cells.Item(1).Value.ToString())
                Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneOrdenCompra(Class_VariablesGlobales.SQL_Comman1, dgv_OrdenesCompra.CurrentRow.Cells.Item(0).Value.ToString, False, "")


                Class_VariablesGlobales.frmCreaPedido.DTP_FechaInicio.Value = Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.CurrentRow.Cells(27).Value
                Class_VariablesGlobales.frmCreaPedido.DTP_FechaFin.Value = Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.CurrentRow.Cells(28).Value
                Class_VariablesGlobales.frmCreaPedido.txtb_DiasACubrir.Text = CInt(DateDiff("d", Class_VariablesGlobales.frmCreaPedido.DTP_FechaInicio.Value, Class_VariablesGlobales.frmCreaPedido.DTP_FechaFin.Value))

                'Verifica si existe en SAP

                Class_VariablesGlobales.frmCreaPedido.txtb_sap.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ExistePedidoAProveedorEnSAP(Class_VariablesGlobales.SQL_Comman1, Trim(Class_VariablesGlobales.frmCreaPedido.lbl_NumOrden.Text))
                If Trim(Class_VariablesGlobales.frmCreaPedido.txtb_sap.Text) <> "" Then
                    Class_VariablesGlobales.frmCreaPedido.btn_CrearEnSAP.Enabled = False
                    Class_VariablesGlobales.frmCreaPedido.btn_Guardar.Enabled = False
                    Class_VariablesGlobales.frmCreaPedido.btn_Cargar.Enabled = False
                    Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.ReadOnly = False
                Else

                End If
                'VERIFICA SI ESTA ANULADO
                If Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.CurrentRow.Cells(42).Value = "1" Then
                    Class_VariablesGlobales.frmCreaPedido.btn_anular.Visible = False
                    Class_VariablesGlobales.frmCreaPedido.lbl_Estado.Visible = True
                    Class_VariablesGlobales.frmCreaPedido.btn_CrearEnSAP.Enabled = False
                    Class_VariablesGlobales.frmCreaPedido.btn_Guardar.Enabled = False
                    Class_VariablesGlobales.frmCreaPedido.btn_Cargar.Enabled = False
                    Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.ReadOnly = False
                Else
                    Class_VariablesGlobales.frmCreaPedido.btn_anular.Visible = True
                    Class_VariablesGlobales.frmCreaPedido.lbl_Estado.Visible = False
                    Class_VariablesGlobales.frmCreaPedido.btn_CrearEnSAP.Enabled = True
                    Class_VariablesGlobales.frmCreaPedido.btn_Guardar.Enabled = True
                    Class_VariablesGlobales.frmCreaPedido.btn_Cargar.Enabled = True
                    ' Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.ReadOnly = True
                End If

                'VERIFICA SI ESTA CREADO EN SAP
                If Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.CurrentRow.Cells(46).Value = "1" Then
                    Class_VariablesGlobales.frmCreaPedido.btn_CrearEnSAP.Visible = False
                    Class_VariablesGlobales.frmCreaPedido.lbl_PedidoEnSAP.Visible = True

                Else
                    Class_VariablesGlobales.frmCreaPedido.btn_CrearEnSAP.Visible = True
                    Class_VariablesGlobales.frmCreaPedido.lbl_PedidoEnSAP.Visible = False

                End If

                Class_VariablesGlobales.frmCreaPedido.RegulaTamanoColumnas(Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido)
                Class_VariablesGlobales.frmCreaPedido.TotalPedido(Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido)
                Class_VariablesGlobales.frmCreaPedido.btn_Guardar.Text = "ACTUALIZAR"



            End If

            Me.Close()
        Catch ex As Exception

        End Try


        sugUnidades = Nothing
        V_CardCode = Nothing
        V_Alterno = Nothing
        V_CodArticulo = Nothing
        V_ItemName = Nothing
        V_Costo = Nothing
        V_Pack = Nothing
        V_Vta_Monto = Nothing
        V_VtaUni = Nothing
        V_VtaCjs = Nothing
        V_PedAgts = Nothing
        V_Faltante = Nothing
        V_StockR = Nothing
        V_StockRCjs = Nothing
        V_StockR_Monto = Nothing
        V_Dif = Nothing
        V_Cpmtdo = Nothing
        V_CpmtdoCjs = Nothing
        V_Compra = Nothing
        V_PdUni = Nothing
        V_PdCJs = Nothing
        V_PdTotal = Nothing
        V_Prmd_Compra = Nothing
        V_PrmdVtaMs = Nothing
        V_Dias = Nothing
        V_Gramaje = Nothing
        V_CodigoBarras = Nothing
        V_DiasSinMoverse = Nothing
        V_FechaUltimaCompra = Nothing
        V_Vmp = Nothing
        V_Vmatp = Nothing
        V_Vmatatp = Nothing
        V_MEs_Vmp = Nothing
        V_MEs_Vmatp = Nothing
        V_MEs_Vmatatp = Nothing
        V_UnidadDeMedidas = Nothing
        V_UltimaCompra = Nothing
        Pd_CJs_Cheado = Nothing
        Pd_Unid_Cheado = Nothing
        Pd_Total_Cheado = Nothing
        Motivo = Nothing
        FCFIn_Venta = Nothing

        FechaUltimaVenta = Nothing
        CantidadUltimaVenta = Nothing

    End Sub


    'Public Function ObtienePedidoChequeado(DocNum As String)


    '    'Obtiene las lineas del pedido ademas indicara quien chequeo que
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneOrdenCompra(Class_VariablesGlobales.SQL_Comman1, DocNum, True)

    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.txb_NumeroPedido.Text = Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.CurrentRow.Cells.Item(0).Value.ToString
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.dtp_FechaReporte.Text = Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.CurrentRow.Cells.Item(1).Value.ToString
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.Txtb_NumeroFactura.Text = Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.CurrentRow.Cells.Item(2).Value.ToString
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.Txtb_CodigoProveedor.Text = Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.CurrentRow.Cells.Item(10).Value.ToString
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.Txtb_NombreProveedor.Text = Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.CurrentRow.Cells.Item(11).Value.ToString

    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Columns("DocNum").Visible = False
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Columns("NumFactura").Visible = False
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Columns("FechaPedido").Visible = False
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Columns("Estado").Visible = False
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Columns("Autorizada").Visible = False
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Columns("TotalPedido").Visible = False
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Columns("TotalChequeado").Visible = False
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Columns("TotalFaltante").Visible = False
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Columns("TotalSobrante").Visible = False

    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Columns("CardCode").Visible = False
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Columns("CardName").Visible = False

    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Columns(1).Width = 70 '[FechaPedido]
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Columns(6).Width = 70 '[Vencimiento]
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Columns(12).Width = 70 '[ItemCode]
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Columns(13).Width = 350 '[ItemName]
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Columns(15).Width = 50 '[Pack]
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Columns(16).Width = 80 '[Unid Pedido]
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Columns(17).Width = 80 '[Unid Chequeado]
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Columns(18).Width = 80 '[Unid Faltante]
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Columns(19).Width = 80 '[Unid Sobrante]

    '    'Obtiene el total pedido,total faltante y total sobrante


    '    Dim TotalPedido As Double = 0
    '    Dim TotalChequeado As Double = 0
    '    Dim TotalFaltante As Double = 0
    '    Dim TotalSobrante As Double = 0


    '    For Each rowns As DataGridViewRow In Class_VariablesGlobales.frmWMS_PedidosChequeados.DGV_PedidosChequeados.Rows
    '        TotalPedido += TotalPedido + CDbl(rowns.Cells(5).Value)
    '        TotalChequeado += TotalChequeado + CDbl(rowns.Cells(7).Value)
    '        TotalFaltante += TotalFaltante + CDbl(rowns.Cells(8).Value)
    '        TotalSobrante += TotalSobrante + CDbl(rowns.Cells(9).Value)
    '    Next


    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.lbl_TPedido.Text = FormatCurrency(TotalPedido.ToString, 2)
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.lbl_TChequeado.Text = FormatCurrency(TotalChequeado.ToString, 2)
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.lbl_TFaltante.Text = FormatCurrency(TotalFaltante.ToString, 2)
    '    Class_VariablesGlobales.frmWMS_PedidosChequeados.lbl_TSobrante.Text = FormatCurrency(TotalSobrante.ToString, 2)

    '    TotalPedido = Nothing
    '    TotalChequeado = Nothing
    '    TotalFaltante = Nothing
    '    TotalSobrante = Nothing
    'End Function


    Private Sub ListaOrdenesDeCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FINI = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaInicio.Value.Date.AddDays(-30))
            FFIN = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaFin.Value.Date)

            DTP_FechaInicio.Value = FINI
            DTP_FechaFin.Value = FFIN

            If Class_VariablesGlobales.ListaPedidoLlamadoDesde = "PEDIDOCHEQUEADOS" Then
                'Solo obtiene los pedidos que han sido chequeados
                dgv_OrdenesCompra.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneOrdenes(Class_VariablesGlobales.SQL_Comman1, FINI, FFIN, txtb_CodProveedor.Text, lbl_NumOrden.Text, True)


            Else
                dgv_OrdenesCompra.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneOrdenes(Class_VariablesGlobales.SQL_Comman1, FINI, FFIN, txtb_CodProveedor.Text, lbl_NumOrden.Text, False)


            End If

            dgv_OrdenesCompra.Columns(0).Width = 80 'T0.[NumDoc]
            dgv_OrdenesCompra.Columns(1).Width = 80 'T0.[Fecha]
            dgv_OrdenesCompra.Columns(2).Width = 80 'T0.CardCode
            dgv_OrdenesCompra.Columns(3).Width = 350 'T0.NombreProveedor
        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        FINI = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaInicio.Value.Date)
        FFIN = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaFin.Value.Date)

        dgv_OrdenesCompra.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneOrdenes(Class_VariablesGlobales.SQL_Comman1, FINI, FFIN, txtb_CodProveedor.Text, lbl_NumOrden.Text, False)


        dgv_OrdenesCompra.Columns(0).Width = 80 'T0.[NumDoc]
        dgv_OrdenesCompra.Columns(1).Width = 80 'T0.[Fecha]
        dgv_OrdenesCompra.Columns(2).Width = 80 'T0.CardCode
        dgv_OrdenesCompra.Columns(3).Width = 350 'T0.NombreProveedor
    End Sub

    Private Sub btn_BuscaAgente_Click(sender As Object, e As EventArgs) Handles btn_BuscaAgente.Click
        Class_VariablesGlobales.LlamadoDesde = "PedidorBuscador"
        Lista_Proveedores.Show()


    End Sub
End Class