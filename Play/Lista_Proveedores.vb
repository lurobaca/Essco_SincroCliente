Public Class Lista_Proveedores

    Private Sub Lista_Proveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dgv_Proveedores.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneProveedores(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.LlamadoDesde)
            dgv_Proveedores.Columns(1).Width = 350
        Catch ex As Exception
            MsgBox("Lista_Proveedores_Load " & ex.Message)

        End Try

    End Sub


    Private Sub dgv_Proveedores_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_Proveedores.CellClick
        Try
            Class_VariablesGlobales.frmControl.inactiva()

            If Class_VariablesGlobales.LlamadoDesde = "PedidorBuscador" Then


                Class_VariablesGlobales.frmPedido_ListaPedidosGuardados.txtb_CodProveedor.Text = dgv_Proveedores.CurrentRow.Cells.Item(0).Value


                'conteo inventario
            ElseIf Class_VariablesGlobales.LlamadoDesde = "AdminGrupos" Then
                'verifica que no exista el proveedor
                Class_VariablesGlobales.frmGruposConteo.AgregaProveedor(dgv_Proveedores.CurrentRow.Cells.Item(0).Value.ToString, dgv_Proveedores.CurrentRow.Cells.Item(1).Value.ToString)

                Class_VariablesGlobales.LlamadoDesde = ""

            ElseIf Class_VariablesGlobales.LlamadoDesde = "Inv_Cruzar" Then
                Class_VariablesGlobales.frmCruzar.txb_CodProveedor.Text = dgv_Proveedores.CurrentRow.Cells.Item(0).Value
                Class_VariablesGlobales.frmCruzar.txtb_NomProveedor.Text = dgv_Proveedores.CurrentRow.Cells.Item(1).Value
                Class_VariablesGlobales.frmCruzar.txtb_Responsable.Text = dgv_Proveedores.CurrentRow.Cells.Item(1).Value
                Class_VariablesGlobales.frmCruzar.TXB_GrupoDif.Focus()
            ElseIf Class_VariablesGlobales.LlamadoDesde = "Inv_Control" Then
                Class_VariablesGlobales.frmControl.Txb_Proveedor.Text = dgv_Proveedores.CurrentRow.Cells.Item(0).Value

                Class_VariablesGlobales.frmControl.Filtrar()
            ElseIf Class_VariablesGlobales.LlamadoDesde = "PedidorPrincipal" Then

                Class_VariablesGlobales.frmRangoFechaOrdComp = New Pedido_RangoFechaOrdComp
                ' Class_VariablesGlobales.frmRangoFechaOrdComp.MdiParent = Principal
                Class_VariablesGlobales.frmRangoFechaOrdComp.Show()

                Class_VariablesGlobales.frmRangoFechaOrdComp.CodProveedor = dgv_Proveedores.CurrentRow.Cells.Item(0).Value
                Class_VariablesGlobales.frmRangoFechaOrdComp.CondiconPago = dgv_Proveedores.CurrentRow.Cells.Item(1).Value
                ' Class_VariablesGlobales.frmRangoFechaOrdComp.NombreProveedor = dgv_Proveedores.CurrentRow.Cells.Item(2).Value


            ElseIf Class_VariablesGlobales.LlamadoDesde = "StockManager" Then

                Class_VariablesGlobales.frmStock_Manager.txtb_CodProveedor.Text = dgv_Proveedores.CurrentRow.Cells.Item(0).Value

            End If


            Class_VariablesGlobales.frmControl.ProgBar.Maximum = 0
            Class_VariablesGlobales.frmControl.ProgBar.Value = 0
            Class_VariablesGlobales.frmControl.Lbl_Fin.Text = "0"


            Class_VariablesGlobales.frmControl.Cursor = Cursors.Default
            Class_VariablesGlobales.frmControl.activa()
            Me.Close()
        Catch ex As Exception
            MsgBox("dgv_Proveedores_CellClick " & ex.Message)
        End Try
    End Sub


End Class