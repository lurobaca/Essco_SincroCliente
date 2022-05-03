Public Class BuscaReportDevoluciones


    Private Sub BuscaReportDevoluciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV_ReportesDevoluciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneReportes(Class_VariablesGlobales.SQL_Comman)
    End Sub

    Private Sub DGV_ReportesDevoluciones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_ReportesDevoluciones.CellContentClick
        Class_VariablesGlobales.IDRepDev = DGV_ReportesDevoluciones.Item(1, DGV_ReportesDevoluciones.CurrentRow.Index).Value.ToString()

        'Form1.CargaDetDevoluciones(Class_VariablesGlobales.SQL_Comman, Class_VariablesGlobales.IDRepDev)
        Me.Close()
    End Sub
End Class