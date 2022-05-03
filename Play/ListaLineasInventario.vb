Public Class ListaLineasInventario


    Private Sub ListaLineasInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dgv_Inventario.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneInentario(txtb_Descripcion.Text, Class_VariablesGlobales.SQL_Comman1)
        Dgv_Inventario.Columns(0).Width = 100
        Dgv_Inventario.Columns(1).Width = 600
    End Sub

    Private Sub Dgv_Inventario_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_Inventario.CellContentClick




        Class_VariablesGlobales.Obj_ReporteDeDevoluciones_Corregir.txtb_CodDestino.Text = Dgv_Inventario.Item(0, Dgv_Inventario.CurrentRow.Index).Value.ToString()

        Me.Close()

    End Sub

    Private Sub txtb_Descripcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_Descripcion.KeyPress
        Dgv_Inventario.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneInentario(txtb_Descripcion.Text, Class_VariablesGlobales.SQL_Comman1)
    End Sub
End Class