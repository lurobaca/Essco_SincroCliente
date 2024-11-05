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
        '    ' Crear un objeto de la clase DTO_ReciboDinero
        '    Dim reciboDinero As New DTO_ReciboDinero()

        '    ' Crear un objeto de la clase Encabezado
        '    Dim encabezado As New DTO_ReciboDinero.Encabezado() With {
        '    .CodCliente = "C001",
        '    .Fecha = DateTime.Now.ToString("yyyy-MM-dd"), ' Convertir a formato de cadena si es necesario
        '    .Impreso = 1,
        '    .Estado = 0,
        '    .Detalle = New List(Of DTO_ReciboDinero.Detalle)() ' Inicializar la lista de detalles
        '}

        '    '        For Each row As DataGridViewRow In DGV_DetalleFactura.Rows
        '    '            Dim isSelected As Boolean = Convert.ToBoolean(row.Cells("Select").Value)
        '    '            If isSelected Then
        '    '                saldo += Convert.ToDecimal(row.Cells("DocSaldo").Value)
        '    '                ' Crear un objeto de la clase Detalle
        '    '                Dim detalle1 As New DTO_ReciboDinero.Detalle() With {
        '    '    .IdRecibosDeDineroDetalle = "D001",
        '    '    .Id_RecibosDeDinero = 1,
        '    '    .NumeroDocumento = "123456",
        '    '    .TipoDocumento = "Factura",
        '    '    .Abono = 1000D,
        '    '    .TotalDocumento = 1200D,
        '    '    .Saldo = 200D,
        '    '    .MontoEfectivo = 500D,
        '    '    .MontoCheque = 300D,
        '    '    .MontoTranferencia = 200D,
        '    '    .IdBancoCheque = 1,
        '    '    .IdBancoTranferencia = 2
        '    '}

        '    ' Agregar el detalle a la lista de detalles del encabezado
        '    'encabezado.Detalle.Add(detalle1)
        '    '    End If
        '    'Next



        '    ' Asignar el encabezado al reciboDinero
        '    reciboDinero.Encabezado = encabezado

        '    ' Llamar al método para crear el recibo en la base de datos
        '    VariablesGlobales.Obj_SQL.CrearReciboDinero(reciboDinero)
    End Sub

End Class