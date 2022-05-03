Public Class CambioInfoClientes

    Private Sub CambioInfoClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Sic_Local_WebDataSet10.ClientesModificados' Puede moverla o quitarla según sea necesario.
        Me.ClientesModificadosTableAdapter.Fill(Me.Sic_Local_WebDataSet10.ClientesModificados)

    End Sub
End Class