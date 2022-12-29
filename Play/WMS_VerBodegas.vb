Public Class WMS_VerBodegas
#Region "Variables"
    Dim columnaIdBodega As Integer = 0
    Dim columnaNombre As Integer = 1
    Dim columnaUbicacion As Integer = 2
    Dim columnaRack As Integer = 3
    Dim columnaColumnas As Integer = 4
    Dim columnaPredeterminado As Integer = 5
#End Region
#Region "Funciones"
''' <summary>
    '''Carga los datos en el DataGridView de la ventana Mantenimiento de Bodega.
    ''' </summary>
    Private Sub CargarDGV()
        Dim idFila As Integer = 0
        dgvVerBodegas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneBodegas(Class_VariablesGlobales.SQL_Comman1)
        dgvVerBodegas.Columns("Predeterminado").Visible = False
        dgvVerBodegas.Columns("Racks").Visible = False
        dgvVerBodegas.Columns("Columnas").Visible = False
    End Sub
#End Region

    Private Sub WMS_VerBodegas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDGV()
    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click

        If dgvVerBodegas.SelectedRows.Count > 0 Then
            btnVer.Text = "Cargando..."
            pbVerCarga.Value = 0
            Class_VariablesGlobales.WMS_Top_Columnas = dgvVerBodegas.Item(columnaColumnas, dgvVerBodegas.CurrentRow.Index).Value.ToString() - 1
            Class_VariablesGlobales.WMS_Top_Filas = dgvVerBodegas.Item(columnaRack, dgvVerBodegas.CurrentRow.Index).Value.ToString() - 1
            Class_VariablesGlobales.WMS_Codigo_Bodega = dgvVerBodegas.Item(columnaIdBodega, dgvVerBodegas.CurrentRow.Index).Value.ToString()
            If Class_VariablesGlobales.Ubicaciones_Modo = "Visual" Then
                Me.Cursor = Cursors.WaitCursor
                Class_VariablesGlobales.Ubicaciones_Modo = "Visual"

                Class_VariablesGlobales.frmCroquisBodega = New WMS_CroquisBodega
                Class_VariablesGlobales.frmCroquisBodega.Text = "Modo Vista de la bodega"
                Class_VariablesGlobales.frmCroquisBodega.MdiParent = Principal
                Class_VariablesGlobales.frmCroquisBodega.Show()
            End If
            Principal.Cursor = Cursors.Default
            Me.Cursor = Cursors.Default
            btnVer.Text = "Ver"
            pbVerCarga.Value = 0
        Else
            MessageBox.Show("Selecciona una bodega")
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class