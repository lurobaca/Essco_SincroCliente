Imports System.Data.OleDb

Public Class WMS_MantenimientoBodegas
#Region "Variables"
    Dim bodegaPred As String
    Dim columnaIdBodega As Integer = 0
    Dim columnaNombre As Integer = 1
    Dim columnaUbicacion As Integer = 2
    Dim columnaRack As Integer = 3
    Dim columnaColumnas As Integer = 4
    Dim columnaPredeterminado As Integer = 5
    Dim columnaRevision As String
    Dim rackRevision As String
    Dim cambioValido As Boolean
#End Region
#Region "Funciones"
    ''' <summary>
    '''Limpia los campos de texto de la ventana Mantenimiento de Bodega.
    ''' </summary>
    Private Sub Limpiar()
        txtIdBodega.Text = Class_VariablesGlobales.Obj_Funciones_SQL.Obtiene_Max_Bodega(Class_VariablesGlobales.SQL_Comman1) + 1
        txtNombreBodega.Text = ""
        txtUbicacion.Text = ""
        txtRacks.Text = ""
        txtColumnas.Text = ""
        cbPredeterminado.Checked = False
        btnGuardar.Text = "Crear"
    End Sub
    ''' <summary>
    '''Verifica si existe inventario activo en algún rack de la bodega
    ''' </summary>
    Private Function VerificarInventarioActivo(ByVal Count_Columnas As Integer, ByVal Count_Filas As Integer, ByVal idBodega As Integer)
        cambioValido = True
        Do
            rackRevision = "Rk#" & Count_Filas
            columnaRevision = Count_Columnas
            Do
                Dim Obj_sql As New Class_funcionesSQL
                Dim Existe As Boolean = CInt(Obj_sql.ExisteUbicacion(Class_VariablesGlobales.SQL_Comman2, "B" & Count_Columnas & "-" & Count_Filas & idBodega))
                If Existe = True Then
                    cambioValido = False
                End If
                Count_Columnas += 1
            Loop Until Count_Columnas > Class_VariablesGlobales.WMS_Top_Columnas
            Count_Columnas = columnaRevision
            Count_Filas += 1
        Loop Until Count_Filas > Class_VariablesGlobales.WMS_Top_Filas
        Return cambioValido
    End Function
    ''' <summary>
    '''Verifica que los campos de la ventana Mantenimiento de Bodega no se encuentren vacíos.
    ''' </summary>
    Private Function ValidarCamposLlenos()
        Dim valido As Boolean
        If txtIdBodega.Text <> "" And txtNombreBodega.Text <> "" And txtUbicacion.Text <> "" And txtRacks.Text <> "" And txtColumnas.Text <> "" Then
            valido = True
        Else
            valido = False
            MsgBox("No pueden haber campos en blanco", MsgBoxStyle.OkOnly, "Campos Vacios")
        End If
        Return valido
    End Function
    ''' <summary>
    '''Carga los datos de la fila seleccionada en el DataGridView de la ventana Mantenimiento de Bodega a los campos de texto para su edición.
    ''' </summary>
    Private Sub CargarTxt()
        Class_VariablesGlobales.WMS_Top_Columnas = dgvBodegas.Item(columnaColumnas, dgvBodegas.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.WMS_Top_Filas = dgvBodegas.Item(columnaRack, dgvBodegas.CurrentRow.Index).Value.ToString()
        btnGuardar.Text = "Actualizar"
        txtIdBodega.Text = dgvBodegas.Item(columnaIdBodega, dgvBodegas.CurrentRow.Index).Value.ToString()
        txtNombreBodega.Text = dgvBodegas.Item(columnaNombre, dgvBodegas.CurrentRow.Index).Value.ToString()
        txtUbicacion.Text = dgvBodegas.Item(columnaUbicacion, dgvBodegas.CurrentRow.Index).Value.ToString()
        txtRacks.Text = dgvBodegas.Item(columnaRack, dgvBodegas.CurrentRow.Index).Value.ToString()
        txtColumnas.Text = dgvBodegas.Item(columnaColumnas, dgvBodegas.CurrentRow.Index).Value.ToString()
        If dgvBodegas.Item(columnaPredeterminado, dgvBodegas.CurrentRow.Index).Value.ToString() = 1 Then
            cbPredeterminado.Checked = True
        Else
            cbPredeterminado.Checked = False
        End If
    End Sub
    ''' <summary>
    '''Carga los datos en el DataGridView de la ventana Mantenimiento de Bodega.
    ''' </summary>
    Private Sub CargarDGV()
        Dim idFila As Integer = 0
        txtIdBodega.Text = Class_VariablesGlobales.Obj_Funciones_SQL.Obtiene_Max_Bodega(Class_VariablesGlobales.SQL_Comman1) + 1
        dgvBodegas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneBodegas(Class_VariablesGlobales.SQL_Comman1)
        dgvBodegas.Columns("Predeterminado").Visible = False
        While idFila < dgvBodegas.Rows.Count - 1
            If dgvBodegas.Item(columnaPredeterminado, idFila).Value.ToString() <> 0 Then
                bodegaPred = dgvBodegas.Item(columnaIdBodega, idFila).Value.ToString()
            End If
            idFila = idFila + 1
        End While
    End Sub
#End Region
    Private Sub WMS_MantenimientoBodegas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDGV()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim predeterminadoBodega As Integer
        If btnGuardar.Text = "Crear" Then
            If ValidarCamposLlenos() = True Then
                If cbPredeterminado.Checked = True Then
                    If bodegaPred <> txtIdBodega.Text Then
                        If MsgBox("¿Desea predeterminar la bodega " & txtNombreBodega.Text & "?", MsgBoxStyle.YesNo, "Cambiar bodega predeterminada") = MsgBoxResult.Yes Then
                            Class_VariablesGlobales.Obj_Funciones_SQL.ELIMINAR_Bodega_Pred(Class_VariablesGlobales.SQL_Comman1, bodegaPred)
                            predeterminadoBodega = 1
                        Else
                            predeterminadoBodega = 0
                        End If
                    Else
                        predeterminadoBodega = 1
                    End If
                Else
                    predeterminadoBodega = 0
                End If
                Class_VariablesGlobales.Obj_Funciones_SQL.INSERTA_Bodega(Class_VariablesGlobales.SQL_Comman1, txtIdBodega.Text, txtNombreBodega.Text, txtUbicacion.Text, txtRacks.Text, txtColumnas.Text, predeterminadoBodega)
                Limpiar()
                CargarDGV()
            End If
        Else
            cambioValido = True
            If ValidarCamposLlenos() = True Then
                If cbPredeterminado.Checked = True Then
                    If bodegaPred <> txtIdBodega.Text Then
                        If MsgBox("¿Desea predeterminar la bodega " & txtNombreBodega.Text & "?", MsgBoxStyle.YesNo, "Cambiar bodega predeterminada") = MsgBoxResult.Yes Then
                            Class_VariablesGlobales.Obj_Funciones_SQL.ELIMINAR_Bodega_Pred(Class_VariablesGlobales.SQL_Comman1, bodegaPred)
                            predeterminadoBodega = 1
                        Else
                            predeterminadoBodega = 0
                        End If
                    Else
                        predeterminadoBodega = 1
                    End If
                Else
                    predeterminadoBodega = 0
                End If
                If Class_VariablesGlobales.WMS_Top_Filas > txtRacks.Text Or Class_VariablesGlobales.WMS_Top_Columnas > txtColumnas.Text Then
                    If Class_VariablesGlobales.WMS_Top_Filas > txtRacks.Text Then
                        rackRevision = txtRacks.Text
                        columnaRevision = 0
                    Else
                        rackRevision = 0
                        columnaRevision = txtColumnas.Text
                    End If
                    If VerificarInventarioActivo(columnaRevision, rackRevision, txtIdBodega.Text) = True Then
                        Class_VariablesGlobales.Obj_Funciones_SQL.ACTUALIZA_Bodega(Class_VariablesGlobales.SQL_Comman1, txtIdBodega.Text, txtNombreBodega.Text, txtUbicacion.Text, txtRacks.Text, txtColumnas.Text, predeterminadoBodega)
                        Limpiar()
                        CargarDGV()
                    Else
                        MsgBox("Lo sentimos, pero no se pueden reducir el número de racks o columna cuando estas tienen inventario activo.")
                        txtRacks.Text = Class_VariablesGlobales.WMS_Top_Filas
                        txtColumnas.Text = Class_VariablesGlobales.WMS_Top_Columnas
                    End If
                Else
                    Class_VariablesGlobales.Obj_Funciones_SQL.ACTUALIZA_Bodega(Class_VariablesGlobales.SQL_Comman1, txtIdBodega.Text, txtNombreBodega.Text, txtUbicacion.Text, txtRacks.Text, txtColumnas.Text, predeterminadoBodega)
                    Limpiar()
                    CargarDGV()
                End If
            End If
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        If dgvBodegas.SelectedRows.Count > 0 Then
            btnCargar.Text = "Cargando..."
            pbCarga.Value = 0
            Class_VariablesGlobales.WMS_Top_Columnas = dgvBodegas.Item(columnaColumnas, dgvBodegas.CurrentRow.Index).Value.ToString() - 1
            Class_VariablesGlobales.WMS_Top_Filas = dgvBodegas.Item(columnaRack, dgvBodegas.CurrentRow.Index).Value.ToString() - 1
            Class_VariablesGlobales.WMS_Codigo_Bodega = dgvBodegas.Item(columnaIdBodega, dgvBodegas.CurrentRow.Index).Value.ToString()
            If Class_VariablesGlobales.Ubicaciones_Modo = "" Then
                Me.Cursor = Cursors.WaitCursor
                Class_VariablesGlobales.Ubicaciones_Modo = "Diseño"

                Class_VariablesGlobales.frmCroquisBodega = New WMS_CroquisBodega
                Class_VariablesGlobales.frmCroquisBodega.Text = "Modo Diseño de la bodega"
                Class_VariablesGlobales.frmCroquisBodega.MdiParent = Principal
                Class_VariablesGlobales.frmCroquisBodega.Show()
                Me.Close()
            Else
                MsgBox("No se pueden ver las ubicaciones hasta que cierre el Modo Diseño")
            End If
            Principal.Cursor = Cursors.Default
        Else
            MessageBox.Show("Selecciona una bodega")
        End If
        Principal.Cursor = Cursors.Default
    End Sub

    Private Sub dgvBodegas_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBodegas.CellContentDoubleClick
        CargarTxt()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvBodegas.SelectedRows.Count > 0 Then
            If VerificarInventarioActivo(0, 0, dgvBodegas.Item(columnaIdBodega, dgvBodegas.CurrentRow.Index).Value.ToString() - 1) = True Then
                Class_VariablesGlobales.Obj_Funciones_SQL.ELIMINAR_Bodega(Class_VariablesGlobales.SQL_Comman1, dgvBodegas.Item(columnaIdBodega, dgvBodegas.CurrentRow.Index).Value.ToString())
                CargarDGV()
            Else
                MsgBox("Lo sentimos, pero no se puede eliminar la bodega cuando esta tiene inventario activo.")
            End If
        Else
            MessageBox.Show("Selecciona una bodega")
        End If
    End Sub

End Class