Public Class buscaBodeguero

    Private Sub buscaBodeguero_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgv_bodegueros.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaBodegueros(Class_VariablesGlobales.SQL_Comman2)
    End Sub



    Private Sub buscaBodeguero_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed



        Dim MDIForm As New Admin_Bodegueros
        MDIForm.MdiParent = Principal
        MDIForm.Show()
    End Sub

    Private Sub dgv_bodegueros_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_bodegueros.CellClick
        Class_VariablesGlobales.UserBod = dgv_bodegueros.Item(1, dgv_bodegueros.CurrentRow.Index).Value.ToString()


        Me.Close()
        Class_VariablesGlobales.Obj_Admin_Bodegueros.Show()
    End Sub
End Class