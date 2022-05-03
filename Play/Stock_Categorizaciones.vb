Public Class Stock_Categorizaciones
    Private Sub Stock_Categorizaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGV_ListaCategorizaciones.DataSource = VariablesGlobales.Obj_SQL.ObtieneCategorizaciones(Class_VariablesGlobales.SQL_Comman2, CBox_Categorizaciones.Text, False)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click

        If btn_guardar.Text = "Guardar" Then
            VariablesGlobales.Obj_SQL.GuardaCategorizaciones(Class_VariablesGlobales.SQL_Comman2, txtb_id.Text, CBox_Categorizaciones.Text, txtb_Nombre.Text, True)
        Else
            VariablesGlobales.Obj_SQL.GuardaCategorizaciones(Class_VariablesGlobales.SQL_Comman2, txtb_id.Text, CBox_Categorizaciones.Text, txtb_Nombre.Text, False)
        End If
        DGV_ListaCategorizaciones.DataSource = VariablesGlobales.Obj_SQL.ObtieneCategorizaciones(Class_VariablesGlobales.SQL_Comman2, CBox_Categorizaciones.Text, False)
        txtb_Nombre.Text = ""
        DGV_ListaCategorizaciones.DataSource = VariablesGlobales.Obj_SQL.ObtieneCategorizaciones(Class_VariablesGlobales.SQL_Comman2, CBox_Categorizaciones.Text, False)
    End Sub

    Private Sub DGV_ListaCategorizaciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_ListaCategorizaciones.CellContentClick
        txtb_id.Text = DGV_ListaCategorizaciones.CurrentRow.Cells.Item(0).Value
        txtb_Nombre.Text = DGV_ListaCategorizaciones.CurrentRow.Cells.Item(1).Value
        CBox_Categorizaciones.Text = DGV_ListaCategorizaciones.CurrentRow.Cells.Item(2).Value
    End Sub
End Class