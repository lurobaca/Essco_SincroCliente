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
        Class_VariablesGlobales.frmRecibosDeDinero_MedioPago.Show()

    End Sub
End Class