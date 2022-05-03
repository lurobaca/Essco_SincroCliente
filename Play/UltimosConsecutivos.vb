Public Class UltimosConsecutivos

    Private Sub UltimosConsecutivos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Sic_Local_WebDataSet1.UltimosConsecutivos' Puede moverla o quitarla según sea necesario.
        Me.UltimosConsecutivosTableAdapter.Fill(Me.Sic_Local_WebDataSet1.UltimosConsecutivos)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DGV_UltimosConsecutivos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.Consulta_UltimosConsecutivos_SAP(Class_VariablesGlobales.SQL_Comman2)
    End Sub

End Class