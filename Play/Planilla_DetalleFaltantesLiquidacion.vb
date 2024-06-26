Public Class Planilla_DetalleFaltantesLiquidacion

    Dim isDataGridViewClicked As Boolean = False

    Private Sub Planilla_DetalleFaltantesLiquidacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGV_ListaLiquidaciones.DefaultCellStyle.Font = New Font("Arial", 12)
        DGV_ListaLiquidaciones.RowTemplate.Height = 30


        If DGV_ListaLiquidaciones.Columns.Contains("Seleccionado") = False Then
            Dim col1 As New DataGridViewCheckBoxColumn
            col1.HeaderText = "Seleccionado"
            col1.Name = "Seleccionado"
            DGV_ListaLiquidaciones.Columns.Add(col1)

        End If
        DGV_ListaLiquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLiquidacionesPorEmpleado(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text, Class_VariablesGlobales.frmPlanilla.Txb_CedulaEmpleado.Text, Class_VariablesGlobales.SQL_Comman2)

    End Sub
    Private Sub DGV_ListaLiquidaciones_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGV_ListaLiquidaciones.DataBindingComplete


        DGV_ListaLiquidaciones.Columns(1).Visible = False
        DGV_ListaLiquidaciones.Columns(2).Visible = False
        ' Ejemplo: Ajustar el ancho de las columnas automáticamente para que se ajusten al contenido.
        DGV_ListaLiquidaciones.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub
    Public Function MarcaEstado()

        For Each row As DataGridViewRow In DGV_ListaLiquidaciones.Rows

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
    Private Sub DGV_ListaLiquidaciones_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        ' Verificar que estamos formateando la columna deseada (por ejemplo, la columna de precios, con índice 2)
        If e.ColumnIndex = 4 AndAlso e.Value IsNot Nothing AndAlso Not e.Value.Equals(DBNull.Value) AndAlso e.Value.ToString.Equals("") = False Then

            ' Aplicar formato personalizado al valor de la celda de la columna de precios
            Dim precio As Double = CDbl(e.Value)
            e.Value = precio.ToString("C2") ' Aplicar formato de moneda
            e.FormattingApplied = True ' Indicar que ya hemos aplicado el formato

        End If
    End Sub

    Private Sub DGV_ListaLiquidaciones_DataBindingComplete(sender As Object, e As EventArgs) Handles DGV_ListaLiquidaciones.DataBindingComplete
        MarcaEstado()
    End Sub

    Public Function CambiaEstadoLiquidacion(Cedula_Empleado As String, NumeroLiquidacion As String, Estado As String)
        Class_VariablesGlobales.Obj_Funciones_SQL.CambiaEstadoLiquidacionPorEmpleado(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text, Class_VariablesGlobales.frmPlanilla.Txb_CedulaEmpleado.Text, NumeroLiquidacion, Estado, Class_VariablesGlobales.SQL_Comman2)
    End Function




    Private Sub DGV_ListaLiquidaciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_ListaLiquidaciones.CellContentClick
        Try


            If e.ColumnIndex = Me.DGV_ListaLiquidaciones.Columns(0).Index Then

                Dim NumeroLiquidacion As Object = DGV_ListaLiquidaciones.Rows(e.RowIndex).Cells("NumeroLiquidacion").Value
                Dim Cedula_Empleado As Object = DGV_ListaLiquidaciones.Rows(e.RowIndex).Cells("Cedula_Empleado").Value
                Dim TotalLiquidacion As Object = DGV_ListaLiquidaciones.Rows(e.RowIndex).Cells("Total").Value

                Dim chkCelda As DataGridViewCheckBoxCell = CType(Me.DGV_ListaLiquidaciones.Rows(e.RowIndex).Cells(0), DataGridViewCheckBoxCell)
                DGV_ListaLiquidaciones.Rows(e.RowIndex).Selected = False
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



                CambiaEstadoLiquidacion(Cedula_Empleado, NumeroLiquidacion, Estado)
                Class_VariablesGlobales.frmPlanilla.CargaTotalRebajos(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text, Class_VariablesGlobales.frmPlanilla.Txb_CedulaEmpleado.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub DGV_ListaLiquidaciones_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)

        ' Verificar si el cambio de valor ocurrió en la columna del CheckBox
        If isDataGridViewClicked = True And e.ColumnIndex = 0 And DGV_ListaLiquidaciones.Columns(e.ColumnIndex).Name = "Seleccionado" Then

            Dim NumeroLiquidacion As Object = DGV_ListaLiquidaciones.Rows(e.RowIndex).Cells("NumeroLiquidacion").Value
            Dim Cedula_Empleado As Object = DGV_ListaLiquidaciones.Rows(e.RowIndex).Cells("Cedula_Empleado").Value
            Dim TotalLiquidacion As Object = DGV_ListaLiquidaciones.Rows(e.RowIndex).Cells("Total").Value
            ' Obtener el nuevo valor del CheckBox
            Dim checkBoxCell As DataGridViewCheckBoxCell = DGV_ListaLiquidaciones.Rows(e.RowIndex).Cells("Seleccionado")
            Dim estadoActual As Boolean = CBool(checkBoxCell.Value)
            Dim Estado As Integer

            If Convert.ToBoolean(checkBoxCell.Value) = True Then
                'Marcado
                checkBoxCell.Value = True
                Estado = 0
            Else
                'Sin Marcar
                checkBoxCell.Value = False
                Estado = 1

            End If

            MsgBox("La liquidacion " & NumeroLiquidacion & " Fue descartada del rebajo a la planilla " & estadoActual)

            CambiaEstadoLiquidacion(NumeroLiquidacion, Cedula_Empleado, Estado)
        End If
    End Sub

    Private Sub DGV_ListaLiquidaciones_CellFormatting_1(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV_ListaLiquidaciones.CellFormatting
        ' Verificar que estamos formateando la columna deseada (por ejemplo, la columna de precios, con índice 2)
        If e.ColumnIndex = 5 AndAlso e.Value IsNot Nothing AndAlso Not e.Value.Equals(DBNull.Value) AndAlso e.Value.ToString.Equals("") = False Then

            ' Aplicar formato personalizado al valor de la celda de la columna de precios
            Dim precio As Double = CDbl(e.Value)
            e.Value = precio.ToString("C2") ' Aplicar formato de moneda
            e.FormattingApplied = True ' Indicar que ya hemos aplicado el formato

        End If
    End Sub
End Class