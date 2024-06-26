Public Class Lista_Planillas

    Private Sub Lista_Planillas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV_ListaPlanillas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.obtienePlanillas(Class_VariablesGlobales.SQL_Comman2, "", "", "")
    End Sub

    Private Sub DGV_ListaPlanillas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_ListaPlanillas.CellContentClick
        Dim IdPlanilla As Integer = CInt(Trim(DGV_ListaPlanillas.CurrentRow.Cells.Item(0).Value()))
        Class_VariablesGlobales.frmPlanilla.PlanillaExistente(IdPlanilla)
        Me.Close()
    End Sub
End Class