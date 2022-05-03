Public Class Notificacion_Cargando
    Private Sub Notificacion_Cargando_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Class_VariablesGlobales.frmCroquisBodega = New WMS_CroquisBodega
        Class_VariablesGlobales.frmCroquisBodega.MdiParent = Principal
        Class_VariablesGlobales.frmCroquisBodega.Show()
    End Sub
End Class