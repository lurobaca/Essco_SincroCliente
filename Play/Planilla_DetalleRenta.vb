Public Class Planilla_DetalleRenta
    Private Sub Planilla_DetalleRenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Aumentar el tamaño de la fuente en el DataGridView
        DGV_DesgloseRenta.DefaultCellStyle.Font = New Font("Arial", 12)
        DGV_DesgloseRenta.RowTemplate.Height = 30


        DGV_DesgloseRenta.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDegloseDeduccionRentaPorEmpleado(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text, Class_VariablesGlobales.frmPlanilla.Txb_CedulaEmpleado.Text, Class_VariablesGlobales.SQL_Comman2)


        'DGV_DesgloseRenta.Columns(0).Width = 200
        'DGV_DesgloseRenta.Columns(1).Width = 200
    End Sub

    Private Sub DGV_DesgloseRenta_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGV_DesgloseRenta.DataBindingComplete
        ' Ejemplo: Ajustar el ancho de las columnas automáticamente para que se ajusten al contenido.
        DGV_DesgloseRenta.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub

    Private Sub DGV_DesgloseRenta_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV_DesgloseRenta.CellFormatting

    End Sub
End Class