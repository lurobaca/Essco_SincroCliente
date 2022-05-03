Public Class Admin_Rutas

    Private Sub btn_AgGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgGuardar.Click
        Class_VariablesGlobales.Obj_Funciones_SQL.Guarda_Ruta(Class_VariablesGlobales.SQL_Comman1, txtb_Ruta.Text)
    End Sub
End Class