Public Class List_RepDevoluciones
    Public Class_VariablesGlobales As New Class_VariablesGlobales
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fecha.ValueChanged
        DataGridView1.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepDevoluciones("", "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Fecha.Value.Date), Class_VariablesGlobales.SQL_Comman2)

    End Sub

    Private Sub List_RepDevoluciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepDevoluciones("", "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Fecha.Value.Date), Class_VariablesGlobales.SQL_Comman2)
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Class_VariablesGlobales.ConseRepDevoluciones = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value.ToString()


        Class_VariablesGlobales.Obj_RepDevoluciones.CargaDetRepdevolucion(Class_VariablesGlobales.ConseRepDevoluciones, "")


        Me.Close()
    End Sub
End Class