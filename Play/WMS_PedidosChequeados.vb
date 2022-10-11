Public Class WMS_PedidosChequeados
    Private Sub WMS_PedidosChequeados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_Buscar_Click(sender As Object, e As EventArgs) Handles btn_Buscar.Click
        Try

            Class_VariablesGlobales.ListaPedidoLlamadoDesde = "PEDIDOCHEQUEADOS"
            Class_VariablesGlobales.frmPedido_ListaPedidosGuardados = New Pedido_ListaPedidosGuardados
            Class_VariablesGlobales.frmPedido_ListaPedidosGuardados.MdiParent = Principal
            Class_VariablesGlobales.frmPedido_ListaPedidosGuardados.Show()



        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btn_Atras_Click(sender As Object, e As EventArgs) Handles Btn_Atras.Click

        If txb_NumeroPedido.Text <> "" Then
            If (CInt(txb_NumeroPedido.Text) - 1) < 0 Then
                MsgBox("Ah llegado al ultimo pedido")

            Else
                txb_NumeroPedido.Text = CInt(txb_NumeroPedido.Text) - 1
                ObtienePedidoChequeado(txb_NumeroPedido.Text)
            End If
        End If







    End Sub

    Private Sub Btn_Adelante_Click(sender As Object, e As EventArgs) Handles Btn_Adelante.Click
        If txb_NumeroPedido.Text <> "" Then

            txb_NumeroPedido.Text = CInt(txb_NumeroPedido.Text) + 1
            ObtienePedidoChequeado(txb_NumeroPedido.Text)
        End If

    End Sub


    Public Sub ObtienePedidoChequeado(DocNum As String)

        Try


            'Obtiene las lineas del pedido ademas indicara quien chequeo que
            Me.DGV_PedidosChequeados.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneOrdenCompra(Class_VariablesGlobales.SQL_Comman1, DocNum, True, "")

            Me.txb_NumeroPedido.Text = Me.DGV_PedidosChequeados.CurrentRow.Cells.Item(0).Value.ToString
            Me.dtp_FechaReporte.Text = Me.DGV_PedidosChequeados.CurrentRow.Cells.Item(1).Value.ToString
            Me.Txtb_NumeroFactura.Text = Me.DGV_PedidosChequeados.CurrentRow.Cells.Item(2).Value.ToString
            Me.Txtb_CodigoProveedor.Text = Me.DGV_PedidosChequeados.CurrentRow.Cells.Item(10).Value.ToString
            Me.Txtb_NombreProveedor.Text = Me.DGV_PedidosChequeados.CurrentRow.Cells.Item(11).Value.ToString

            With Me.CBox_Tarimas
                .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTarimas(Class_VariablesGlobales.SQL_Comman1, DocNum)
                .DisplayMember = "idTarima"
                .ValueMember = "idTarima"
            End With

            Me.DGV_PedidosChequeados.Columns("DocNum").Visible = False
            Me.DGV_PedidosChequeados.Columns("NumFactura").Visible = False
            Me.DGV_PedidosChequeados.Columns("FechaPedido").Visible = False
            Me.DGV_PedidosChequeados.Columns("Estado").Visible = False
            Me.DGV_PedidosChequeados.Columns("Autorizada").Visible = False
            Me.DGV_PedidosChequeados.Columns("TotalPedido").Visible = False
            Me.DGV_PedidosChequeados.Columns("TotalChequeado").Visible = False
            Me.DGV_PedidosChequeados.Columns("TotalFaltante").Visible = False
            Me.DGV_PedidosChequeados.Columns("TotalSobrante").Visible = False

            Me.DGV_PedidosChequeados.Columns("CardCode").Visible = False
            Me.DGV_PedidosChequeados.Columns("CardName").Visible = False

            Me.DGV_PedidosChequeados.Columns(1).Width = 70 '[FechaPedido]
            Me.DGV_PedidosChequeados.Columns(6).Width = 70 '[Vencimiento]
            Me.DGV_PedidosChequeados.Columns(12).Width = 70 '[ItemCode]
            Me.DGV_PedidosChequeados.Columns(13).Width = 350 '[ItemName]
            Me.DGV_PedidosChequeados.Columns(15).Width = 50 '[Pack]
            Me.DGV_PedidosChequeados.Columns(16).Width = 80 '[Unid Pedido]
            Me.DGV_PedidosChequeados.Columns(17).Width = 80 '[Unid Chequeado]
            Me.DGV_PedidosChequeados.Columns(18).Width = 80 '[Unid Faltante]
            Me.DGV_PedidosChequeados.Columns(19).Width = 80 '[Unid Sobrante]

            'Obtiene el total pedido,total faltante y total sobrante


            Dim TotalPedido As Double = 0
            Dim TotalChequeado As Double = 0
            Dim TotalFaltante As Double = 0
            Dim TotalSobrante As Double = 0


            For Each rowns As DataGridViewRow In Me.DGV_PedidosChequeados.Rows
                TotalPedido += TotalPedido + CDbl(rowns.Cells(5).Value)
                TotalChequeado += TotalChequeado + CDbl(rowns.Cells(7).Value)
                TotalFaltante += TotalFaltante + CDbl(rowns.Cells(8).Value)
                TotalSobrante += TotalSobrante + CDbl(rowns.Cells(9).Value)
            Next


            Me.lbl_TPedido.Text = FormatCurrency(TotalPedido.ToString, 2)
            Me.lbl_TChequeado.Text = FormatCurrency(TotalChequeado.ToString, 2)
            Me.lbl_TFaltante.Text = FormatCurrency(TotalFaltante.ToString, 2)
            Me.lbl_TSobrante.Text = FormatCurrency(TotalSobrante.ToString, 2)

            TotalPedido = Nothing
            TotalChequeado = Nothing
            TotalFaltante = Nothing
            TotalSobrante = Nothing


        Catch ex As Exception
            MessageBox.Show(ex.Message)


            Me.dtp_FechaReporte.Text = ""
            Me.Txtb_NumeroFactura.Text = ""
            Me.Txtb_CodigoProveedor.Text = ""
            Me.Txtb_NombreProveedor.Text = ""
            Me.lbl_TPedido.Text = FormatCurrency("0", 2)
            Me.lbl_TChequeado.Text = FormatCurrency("0", 2)
            Me.lbl_TFaltante.Text = FormatCurrency("0", 2)
            Me.lbl_TSobrante.Text = FormatCurrency("0", 2)
            Me.DGV_PedidosChequeados.DataSource = Nothing

        End Try

    End Sub

    Private Sub CBox_Tarimas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBox_Tarimas.SelectedIndexChanged
        'Obtener la lista de articulos segun la tarima seleccionada
        Me.DGV_PedidosChequeados.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneOrdenCompra(Class_VariablesGlobales.SQL_Comman1, txb_NumeroPedido.Text, True, CBox_Tarimas.Text)
    End Sub

    Private Sub DGV_PedidosChequeados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_PedidosChequeados.CellContentClick
        'Obtiene el detalle del chequeo
        Class_VariablesGlobales.frmWMS_PedidosChequeados_Detalle = New WMS_PedidosChequeados_Detalle

        Class_VariablesGlobales.frmWMS_PedidosChequeados_Detalle.MdiParent = Principal
        Class_VariablesGlobales.frmWMS_PedidosChequeados_Detalle.Show()




        Class_VariablesGlobales.frmWMS_PedidosChequeados_Detalle.DGV_DetalleChequeo.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDetalleCheque(Class_VariablesGlobales.SQL_Comman1, txb_NumeroPedido.Text, Me.DGV_PedidosChequeados.CurrentRow.Cells.Item(12).Value.ToString())



        Class_VariablesGlobales.frmWMS_PedidosChequeados_Detalle.DGV_DetalleChequeo.Columns(1).Width = 350 '[FechaPedido]


    End Sub
End Class