Public Class ClientesEstadoCuenta
    Private Sub ClientesEstadoCuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ' Calcular la fecha actual menos 30 días
        Dim fechaActualMenos30Dias As DateTime = DateTime.Now.AddDays(-30)

        ' Asignar la fecha calculada al DateTimePicker
        DTP_INI.Value = fechaActualMenos30Dias

        DGV_EstadoCuenta.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneEstadoCuenta(Class_VariablesGlobales.SQL_Comman2, DTP_INI.Value.ToString(),
                                                  DTP_FIN.Value.ToString(), CBox_Estado.Text)
    End Sub

    Private Sub Btn_Buscar_Click(sender As Object, e As EventArgs) Handles Btn_Buscar.Click
        DGV_EstadoCuenta.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneEstadoCuenta(Class_VariablesGlobales.SQL_Comman2, DTP_INI.Value.ToString(),
                                             DTP_FIN.Value.ToString(), CBox_Estado.Text)
    End Sub
End Class