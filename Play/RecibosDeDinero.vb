Public Class RecibosDeDinero
    Private Sub btn_BuscarClientes_Click(sender As Object, e As EventArgs) Handles btn_BuscarClientes.Click
        Class_VariablesGlobales.ClientesLlamadoDesde = "RecibosDinero"
        Class_VariablesGlobales.frmLista_ClientesModificados = New Lista_ClientesModificados
        Class_VariablesGlobales.frmLista_ClientesModificados.MdiParent = Principal
        Class_VariablesGlobales.frmLista_ClientesModificados.CBX_Estado.Text = "Interno"
        Class_VariablesGlobales.frmLista_ClientesModificados.Show()
    End Sub

    Private Sub RecibosDeDinero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtb_Consecutivo.Text = CInt(VariablesGlobales.Obj_SQL.ObtieneConsecutivoACrear("ReciboDeDinero"))
    End Sub

    Public Function CargaDocumentosPendientes(Cedula As String)
        ' Añadir la columna de CheckBox al DataGridView
        Dim chkColumn As New DataGridViewCheckBoxColumn()
        chkColumn.Name = "Select"
        chkColumn.HeaderText = "Select"
        DGV_DetalleFactura.Columns.Add(chkColumn)
        DGV_DetalleFactura.DataSource = VariablesGlobales.Obj_SQL.ObtieneDocumentosPendiente(Cedula.Trim())



    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_Pagar.Click
        Class_VariablesGlobales.frmRecibosDeDinero_MedioPago = New RecibosDeDinero_MedioPago
        Class_VariablesGlobales.frmRecibosDeDinero_MedioPago.MdiParent = Principal

        Class_VariablesGlobales.frmRecibosDeDinero_MedioPago.Txtb_MontoEfectivo.Text = txtb_TotalDocumento.Text
        Class_VariablesGlobales.frmRecibosDeDinero_MedioPago.Show()

    End Sub

    Public Sub DGV_DetalleFactura_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_DetalleFactura.CellContentClick
        ' Verifica si la celda clickeada es la columna de CheckBox
        If e.ColumnIndex = DGV_DetalleFactura.Columns("Select").Index AndAlso e.RowIndex >= 0 Then
            ' Forzar la confirmación del cambio para que se dispare CellValueChanged
            DGV_DetalleFactura.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Public Sub DGV_DetalleFactura_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_DetalleFactura.CellValueChanged

        Dim saldo As Decimal = 0
        ' Verifica si la celda modificada es la columna de CheckBox
        If e.ColumnIndex = DGV_DetalleFactura.Columns("Select").Index AndAlso e.RowIndex >= 0 Then

            For Each row As DataGridViewRow In DGV_DetalleFactura.Rows
                Dim isSelected As Boolean = Convert.ToBoolean(row.Cells("Select").Value)
                If isSelected Then
                    saldo += Convert.ToDecimal(row.Cells("DocSaldo").Value)
                    Console.WriteLine("Fila seleccionada con saldo: " & saldo)
                End If
            Next

            txtb_TotalDocumento.Text = Class_VariablesGlobales.Obj_Mformat.FormatoMoneda(saldo)

        End If
    End Sub

    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click

    End Sub
End Class