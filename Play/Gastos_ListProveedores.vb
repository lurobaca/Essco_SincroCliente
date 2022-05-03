Public Class Gastos_ListProveedores
    Private Sub Gastos_ListProveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv_Proveedores.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosProveedores(Class_VariablesGlobales.SQL_Comman1)
    End Sub

    Private Sub dgv_Proveedores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Proveedores.CellContentClick

        'T0.[CardCode],T0.[CardName], T0.[LicTradNum], T0.[E_Mail]
        Try
            Class_VariablesGlobales.frmDetGastos.txb_Codigo.Text = dgv_Proveedores.CurrentRow.Cells.Item(0).Value
            Class_VariablesGlobales.frmDetGastos.txb_Nombre.Text = dgv_Proveedores.CurrentRow.Cells.Item(1).Value
            Class_VariablesGlobales.frmDetGastos.txb_Cedula.Text = dgv_Proveedores.CurrentRow.Cells.Item(2).Value
            Class_VariablesGlobales.frmDetGastos.txb_Correo.Text = dgv_Proveedores.CurrentRow.Cells.Item(3).Value
        Catch ex As Exception

        End Try

        Try
            Class_VariablesGlobales.frmDetalle_Gastos_Choferes.txb_Codigo.Text = dgv_Proveedores.CurrentRow.Cells.Item(0).Value
            Class_VariablesGlobales.frmDetalle_Gastos_Choferes.txb_Nombre.Text = dgv_Proveedores.CurrentRow.Cells.Item(1).Value
            Class_VariablesGlobales.frmDetalle_Gastos_Choferes.txb_Cedula.Text = dgv_Proveedores.CurrentRow.Cells.Item(2).Value
            Class_VariablesGlobales.frmDetalle_Gastos_Choferes.txb_Correo.Text = dgv_Proveedores.CurrentRow.Cells.Item(3).Value
        Catch ex As Exception

        End Try

        Me.Close()

    End Sub
End Class