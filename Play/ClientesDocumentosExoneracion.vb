Public Class ClientesDocumentosExoneracion

    Public Obj_SQL_CONEXIONSERVER As New Class_funcionesSQL

    Private Sub btn_Agregar_Click(sender As Object, e As EventArgs) Handles btn_Agregar.Click
        Obj_SQL_CONEXIONSERVER.GuardaCodigosCabysExentos(txtb_Codigo.Text, TxtB_CabysExento.Text, txtb_idDocExoneracion.Text, True)
        DGV_ListaCabysExentos.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneCabysExcento(txtb_idDocExoneracion.Text)
        TxtB_CabysExento.Text = ""
    End Sub

    Private Sub btn_Desagregar_Click(sender As Object, e As EventArgs) Handles btn_Desagregar.Click

        Dim result1 As DialogResult = MessageBox.Show("Si eliminar el codigo cabys de exoneracion a la hora de facturar no se le aplicara la exoneracion correspondiente " & vbCrLf & " Esta seguro que desea eliminar el codigo cabys de exoneracion?",
      "Important Question",
      MessageBoxButtons.YesNo)

        If result1 = DialogResult.Yes Then

            Obj_SQL_CONEXIONSERVER.EliminaCabysExcento(txtb_idDocExoneracion.Text, TxtB_CabysExento.Text)
            DGV_ListaCabysExentos.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneCabysExcento(txtb_idDocExoneracion.Text)
            TxtB_CabysExento.Text = ""

            MsgBox("Codigo Cabys eliminado con exito")

        End If
        If result1 = DialogResult.No Then
        End If


    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click


        Dim Guardar As Boolean = True
        Dim ExisteDocumentoDeExoneracion As Boolean = False
        ExisteDocumentoDeExoneracion = Obj_SQL_CONEXIONSERVER.ValidaSiExistenExoNumeroPorCliente(txtb_Codigo.Text, txtb_ExoNumero.Text)
        If ExisteDocumentoDeExoneracion Then
            Guardar = False
        Else
            Guardar = True
        End If

        Dim ComprasAutorizadas As Int32 = 1
        Dim VentasExentasADiplomáticos As Int32 = 2
        Dim AutorizadoPorLeyEspecial As Int32 = 3
        Dim ExencionesDireccionGeneralDeHacienda As Int32 = 4
        Dim TransitorioV As Int32 = 5
        Dim TransitorioIX As Int32 = 6
        Dim TransitorioXVII As Int32 = 7
        Dim Otros As Int32 = 99
        Dim EXO_TipoDocumento As String = ""
        Select Case CBox_ExoTipoDoc.SelectedIndex
            Case ComprasAutorizadas
                EXO_TipoDocumento = "01"
            Case VentasExentasADiplomáticos
                EXO_TipoDocumento = "02"
            Case AutorizadoPorLeyEspecial
                EXO_TipoDocumento = "03"
            Case ExencionesDireccionGeneralDeHacienda
                EXO_TipoDocumento = "04"
            Case TransitorioV
                EXO_TipoDocumento = "05"
            Case TransitorioIX
                EXO_TipoDocumento = "06"
            Case TransitorioXVII
                EXO_TipoDocumento = "07"
            Case Otros
                EXO_TipoDocumento = "99"
        End Select

        Obj_SQL_CONEXIONSERVER.GuardaDocumentosExoneracionDeClientes(txtb_idDocExoneracion.Text,
                                                                     txtb_Codigo.Text,
                                                                     EXO_TipoDocumento,
                                                                     txtb_ExoNumero.Text,
                                                                     txtb_ExoNombreInstitucion.Text,
                                                                     DTP_ExoFechaEmision.Value.ToString(),
                                                                     DTP_ExoFechaVencimiento.Value.ToString(),
                                                                     txtb_ExoPorcentajeCompra.Text,
                                                                     Guardar)
        MsgBox("Documento de exoneracion guardado con exito")
        MsgBox("Agrega los codigos cabys vinculados al documento")
        Limpiar()
        DGV_ListaCabysExentos.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneCabysExcento(txtb_idDocExoneracion.Text)
    End Sub
    Public Function Limpiar()


        Class_VariablesGlobales.frmAdmin_ClientesModificados.DGV_DocumentosExoneracion.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneDocumentosExoneracionDeClientes(txtb_Codigo.Text)

        DGV_ListaCabysExentos.DataSource = New DataTable
        btn_Agregar.Enabled = True
        btn_Desagregar.Enabled = True
    End Function

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click
        Dim result1 As DialogResult = MessageBox.Show("Si eliminar el documento de exoneracion a la hora de facturar no se le aplicara la exoneracion correspondiente " & vbCrLf & " Esta seguro que desea eliminar el documento de exoneracion?",
      "Important Question",
      MessageBoxButtons.YesNo)

        If result1 = DialogResult.Yes Then

            Obj_SQL_CONEXIONSERVER.EliminaDocumentosExoneracionDeClientes(txtb_idDocExoneracion.Text)
            Obj_SQL_CONEXIONSERVER.EliminaCabysExcento(txtb_idDocExoneracion.Text, Nothing)
            Limpiar()

            txtb_idDocExoneracion.Text = ""

            CBox_ExoTipoDoc.Text = ""
            txtb_ExoNumero.Text = ""
            txtb_ExoNombreInstitucion.Text = ""
            DTP_ExoFechaEmision.Value = Now.Date
            DTP_ExoFechaVencimiento.Value = Now.Date
            txtb_ExoPorcentajeCompra.Text = ""
            btn_Agregar.Enabled = False
            btn_Desagregar.Enabled = False
            MsgBox("Documento de exoneracion eliminado con exito")

        End If
        If result1 = DialogResult.No Then
        End If





    End Sub

    Private Sub DGV_ListaCabysExentos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_ListaCabysExentos.CellContentClick
        TxtB_IdExentoCabys.Text = DGV_ListaCabysExentos.CurrentRow.Cells.Item(0).Value
        TxtB_CabysExento.Text = DGV_ListaCabysExentos.CurrentRow.Cells.Item(1).Value

    End Sub

End Class