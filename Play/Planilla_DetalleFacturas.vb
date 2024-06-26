Public Class Planilla_DetalleFacturas
    Private Sub Planilla_DetalleFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Aumentar el tamaño de la fuente en el DataGridView
        DGV_ListaFacturas.DefaultCellStyle.Font = New Font("Arial", 12)
        DGV_ListaFacturas.RowTemplate.Height = 30

        If DGV_ListaFacturas.Columns.Contains("Seleccionado") = False Then
            Dim col1 As New DataGridViewCheckBoxColumn
            col1.HeaderText = "Seleccionado"
            col1.Name = "Seleccionado"
            DGV_ListaFacturas.Columns.Add(col1)

        End If
        DGV_ListaFacturas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneFacturasPorEmpleado(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text, Class_VariablesGlobales.frmPlanilla.Txb_CedulaEmpleado.Text, Class_VariablesGlobales.SQL_Comman2)

    End Sub
    Private Sub DGV_ListaFacturas_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV_ListaFacturas.CellFormatting
        ' Verificar que estamos formateando la columna deseada (por ejemplo, la columna de precios, con índice 2)
        If e.ColumnIndex = 3 Or e.ColumnIndex = 4 AndAlso e.Value IsNot Nothing AndAlso Not e.Value.Equals(DBNull.Value) AndAlso e.Value.ToString.Equals("") = False Then

            ' Aplicar formato personalizado al valor de la celda de la columna de precios
            Dim precio As Double = CDbl(e.Value)
            e.Value = precio.ToString("C2") ' Aplicar formato de moneda
            e.FormattingApplied = True ' Indicar que ya hemos aplicado el formato

        End If
    End Sub
    Public Function MarcaEstado()

        For Each row As DataGridViewRow In DGV_ListaFacturas.Rows

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

    Private Sub DGV_ListaFacturas_DataBindingComplete(sender As Object, e As EventArgs) Handles DGV_ListaFacturas.DataBindingComplete
        MarcaEstado()
    End Sub
    Private Sub DGV_ListaLiquidaciones_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGV_ListaFacturas.DataBindingComplete


        DGV_ListaFacturas.Columns(5).Visible = False
        ' Ejemplo: Ajustar el ancho de las columnas automáticamente para que se ajusten al contenido.
        DGV_ListaFacturas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub
    Private Sub DGV_ListaLiquidaciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_ListaFacturas.CellContentClick
        Try


            If e.ColumnIndex = Me.DGV_ListaFacturas.Columns(0).Index Then

                Dim DocNum As Object = DGV_ListaFacturas.Rows(e.RowIndex).Cells("DocNum").Value
                Dim TipoFactura As Object = DGV_ListaFacturas.Rows(e.RowIndex).Cells("TipoFactura").Value
                If TipoFactura = "CoResponsable" Then
                    MessageBox.Show($"La factura {DocNum} no se puede omitir, esta ligada a un cobro en conjunto a otro empleado")
                    Return
                End If
                Dim chkCelda As DataGridViewCheckBoxCell = CType(Me.DGV_ListaFacturas.Rows(e.RowIndex).Cells(0), DataGridViewCheckBoxCell)
                DGV_ListaFacturas.Rows(e.RowIndex).Selected = False
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

                CambiaEstadoFactura(DocNum, Estado)
                Class_VariablesGlobales.frmPlanilla.CargaTotalRebajos(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text, Class_VariablesGlobales.frmPlanilla.Txb_CedulaEmpleado.Text)
                ' Limpiar los datos actuales del DataGridView
                'Class_VariablesGlobales.frmPlanilla.DTGV_Planilla.DataSource = Nothing
                'Class_VariablesGlobales.frmPlanilla.DTGV_Planilla.Rows.Clear()
                'Class_VariablesGlobales.frmPlanilla.DTGV_Planilla.DataSource =
                'Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaPlanillaEmpleado(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text.Trim(), Class_VariablesGlobales.frmPlanilla.Txb_CedulaEmpleado.Text.Trim(), Class_VariablesGlobales.frmPlanilla.TxtBox_SalarioFinal.Text(), Class_VariablesGlobales.SQL_Comman2)

                Class_VariablesGlobales.Obj_Funciones_SQL.CalculaSalarioFinal(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text.Trim(), Class_VariablesGlobales.frmPlanilla.Txb_CedulaEmpleado.Text.Trim(), Class_VariablesGlobales.frmPlanilla.TxtBox_SalarioFinal.Text(), Class_VariablesGlobales.SQL_Comman2)



            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function CambiaEstadoFactura(DocNum As String, Estado As String)
        Class_VariablesGlobales.Obj_Funciones_SQL.CambiaEstadoFactura(Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text, Class_VariablesGlobales.frmPlanilla.Txb_CedulaEmpleado.Text, DocNum, Estado, Class_VariablesGlobales.SQL_Comman2)
    End Function


End Class