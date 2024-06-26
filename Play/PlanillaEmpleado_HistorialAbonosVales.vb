Public Class PlanillaEmpleado_HistorialAbonosVales
    Private Sub PlanillaEmpleado_HistorialAbonosVales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGV_HistorialAbonos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneHistorialValesPrestamos(Class_VariablesGlobales.frmEmpleados.Txb_Cedula.Text, Class_VariablesGlobales.frmEmpleados.txtb_ConsecutivoValePrestamo.Text, Class_VariablesGlobales.SQL_Comman2)
    End Sub
End Class