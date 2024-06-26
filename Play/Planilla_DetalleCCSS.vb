Public Class Planilla_DetalleCCSS
    Private Sub Planilla_DetalleCCSS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Aumentar el tamaño de la fuente en el DataGridView
        DGV_DesgloseCCSS.DefaultCellStyle.Font = New Font("Arial", 12)
        DGV_DesgloseCCSS.RowTemplate.Height = 30

        DGV_DesgloseCCSS.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDegloseDeduccionCCSSPorEmpleado(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text, Class_VariablesGlobales.frmPlanilla.Txb_CedulaEmpleado.Text, Class_VariablesGlobales.SQL_Comman2)

        DGV_DesgloseCCSS.Columns(0).Width = 200
        DGV_DesgloseCCSS.Columns(1).Width = 200

    End Sub


    Private Sub DGV_DesgloseCCSS_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGV_DesgloseCCSS.DataBindingComplete
        ' Ejemplo: Ajustar el ancho de las columnas automáticamente para que se ajusten al contenido.
        DGV_DesgloseCCSS.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub
    Private Sub DGV_DesgloseCCSS_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV_DesgloseCCSS.CellFormatting
        Try
            ' Verificar que estamos formateando la columna deseada (por ejemplo, la columna de precios, con índice 2)
            If e.ColumnIndex = 3 Or e.ColumnIndex = 5 AndAlso e.Value IsNot Nothing AndAlso Not e.Value.Equals(DBNull.Value) AndAlso e.Value.ToString().Trim().Equals("") = False Then
                ' Aplicar formato personalizado al valor de la celda de la columna de precios
                Dim precio As Double = CDbl(e.Value)
                e.Value = precio.ToString("C2") ' Aplicar formato de moneda
                e.FormattingApplied = True ' Indicar que ya hemos aplicado el formato
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class