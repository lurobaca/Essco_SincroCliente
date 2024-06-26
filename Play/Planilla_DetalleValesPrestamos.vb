Public Class Planilla_DetalleValesPrestamos
    Private Sub Planilla_DetalleValesPrestamos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Aumentar el tamaño de la fuente en el DataGridView
        DGV_ListaValesPrestamos.DefaultCellStyle.Font = New Font("Arial", 12)
        DGV_ListaValesPrestamos.RowTemplate.Height = 30

        If DGV_ListaValesPrestamos.Columns.Contains("Seleccionado") = False Then
            Dim col1 As New DataGridViewCheckBoxColumn
            col1.HeaderText = "Seleccionado"
            col1.Name = "Seleccionado"
            DGV_ListaValesPrestamos.Columns.Add(col1)

        End If
        DGV_ListaValesPrestamos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneValesPrestamosPorEmpleadoPorPlanilla(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text.Trim(), Class_VariablesGlobales.frmPlanilla.Txb_CedulaEmpleado.Text.Trim(), Class_VariablesGlobales.SQL_Comman2)

    End Sub

    Private Sub DGV_ListaValesPrestamos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        ' Verificar que estamos formateando la columna deseada (por ejemplo, la columna de precios, con índice 2)
        If e.ColumnIndex = 3 Or e.ColumnIndex = 4 AndAlso e.Value IsNot Nothing AndAlso Not e.Value.Equals(DBNull.Value) AndAlso e.Value.ToString.Equals("") = False Then

            ' Aplicar formato personalizado al valor de la celda de la columna de precios
            Dim precio As Double = CDbl(e.Value)
            e.Value = precio.ToString("C7") ' Aplicar formato de moneda
            e.FormattingApplied = True ' Indicar que ya hemos aplicado el formato

        End If
    End Sub

    Public Function MarcaEstado()

        For Each row As DataGridViewRow In DGV_ListaValesPrestamos.Rows

            ' Obtenemos la celda de la columna "Seleccionado" en la fila actual
            Dim cell As DataGridViewCheckBoxCell = row.Cells("Seleccionado")

            If row.Cells("Estado").Value = 0 Then
                ' Establecemos el valor de la casilla de verificación en True
                cell.Value = True
            Else
                cell.Value = False
            End If

        Next
    End Function

    Private Sub DGV_ListaFacturas_DataBindingComplete(sender As Object, e As EventArgs) Handles DGV_ListaValesPrestamos.DataBindingComplete
        MarcaEstado()
    End Sub
    Private Sub DGV_ListaLiquidaciones_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGV_ListaValesPrestamos.DataBindingComplete

        DGV_ListaValesPrestamos.Columns(7).Visible = False
        ' Ejemplo: Ajustar el ancho de las columnas automáticamente para que se ajusten al contenido.
        DGV_ListaValesPrestamos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub

    Private Sub DGV_ListaValesPrestamos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_ListaValesPrestamos.CellContentClick
        Try
            If e.ColumnIndex = Me.DGV_ListaValesPrestamos.Columns(0).Index Then

                Dim Consecutivo As Object = DGV_ListaValesPrestamos.Rows(e.RowIndex).Cells("Consecutivo").Value

                Dim chkCelda As DataGridViewCheckBoxCell = CType(Me.DGV_ListaValesPrestamos.Rows(e.RowIndex).Cells(0), DataGridViewCheckBoxCell)
                DGV_ListaValesPrestamos.Rows(e.RowIndex).Selected = False
                Dim Estado As Integer
                If Convert.ToBoolean(chkCelda.Value) = True Then
                    'Sin Marcar
                    chkCelda.Value = False
                    Estado = 1
                Else
                    'Marcado
                    chkCelda.Value = True
                    Estado = 0
                End If

                CambiaEstadoValePrestamo(Consecutivo, Estado)
                Class_VariablesGlobales.frmPlanilla.CargaTotalRebajos(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text, Class_VariablesGlobales.frmPlanilla.Txb_CedulaEmpleado.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function CambiaEstadoValePrestamo(Consecutivo As String, Estado As String)
        Class_VariablesGlobales.Obj_Funciones_SQL.CambiaEstadoValePrestamo(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text, Class_VariablesGlobales.frmPlanilla.Txb_CedulaEmpleado.Text, Consecutivo, Estado, Class_VariablesGlobales.SQL_Comman2)
    End Function

    Private Sub DGV_ListaValesPrestamos_CellFormatting_1(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV_ListaValesPrestamos.CellFormatting
        ' Verificar que estamos formateando la columna deseada (por ejemplo, la columna de precios, con índice 2)
        If e.ColumnIndex = 3 AndAlso e.Value IsNot Nothing AndAlso Not e.Value.Equals(DBNull.Value) AndAlso e.Value.ToString.Equals("") = False Then

            ' Aplicar formato personalizado al valor de la celda de la columna de precios
            Dim precio As Double = CDbl(e.Value)
            e.Value = precio.ToString("C2") ' Aplicar formato de moneda
            e.FormattingApplied = True ' Indicar que ya hemos aplicado el formato

        End If
    End Sub
End Class