Public Class DevolucionesPendientes

    Private Sub DevolucionesPendientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With DataGridView1
            .Name = "DetalleDevolucion"

            .RowHeadersVisible = False

            .Columns(0).Name = "Id"
            .Columns(0).Width = 50
            .Columns(1).Name = "Cod Cliente"
            .Columns(1).Width = 70
            .Columns(2).Name = "Nombre"
            .Columns(2).Width = 300
            .Columns(3).Name = "Ruta"
            '.Columns(4).DefaultCellStyle.Font = New Font(Me.DataGridView2.DefaultCellStyle.Font, FontStyle.Italic)
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            '.Dock = DockStyle.Fill
        End With
    End Sub
End Class