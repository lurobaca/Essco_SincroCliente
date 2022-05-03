Public Class Admin_Bodeguero
    Dim CodBodeguero As String
    Dim Nombre As String
    Dim Telefono As String
    Dim Conse_RepCarga As String
    Dim Conse_RepDevoluciones As String
    Dim Correo As String
    Dim FTP As String
    Dim Puesto As String
    Dim Cedula As String
    Dim Clave As String
    Dim Usuario As String
    Dim Sector1 As String = "0"
    Dim Sector2 As String = "0"
    Dim Sector3 As String = "0"
    Dim Sector4 As String = "0"
    Dim Sector5 As String = "0"
    Dim Sector6 As String = "0"
    Dim Sector7 As String = "0"
    Dim Sector8 As String = "0"
    Dim Sector9 As String = "0"
    Dim Sector10 As String = "0"
    Dim Sector11 As String = "0"
    Dim Sector12 As String = "0"
    Dim Sector13 As String = "0"
    Dim Sector14 As String = "0"
    Dim Sector15 As String = "0"
    Dim Sector16 As String = "0"
    Dim Sector17 As String = "0"
    Dim Sector18 As String = "0"
    Dim Sector19 As String = "0"
    Dim Sector20 As String = "0"

    Public Class_VariablesGlobales As New Class_VariablesGlobales


    Private Sub btn_AgGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgGuardar.Click
        AsignaValores()
        Class_VariablesGlobales.Obj_Funciones_SQL.AgregarBodeguero(Class_VariablesGlobales.SQL_Comman2, CodBodeguero, Nombre, Telefono, Conse_RepCarga, Conse_RepDevoluciones, Correo, FTP, Puesto, _
                                      Cedula, Sector1, Sector2, Sector3, Sector4, Sector5, Sector6, Sector7, Sector8, Sector9, Sector10, Sector11, Sector12, Sector13, Sector14, Sector15, Sector16, Sector17, Sector18, Sector19, Sector20, Clave, Usuario)
        Limpiar()
    End Sub
    Public Function AsignaValores()

        CodBodeguero = txtb_Cod.Text
        Nombre = txtb_Nombre.Text
        Telefono = txtb_telf.Text
        Conse_RepCarga = txtb_ConsPe.Text
        Conse_RepDevoluciones = txtb_ConsDevoluciones.Text
        Correo = txtb_Correo.Text
        FTP = txtb_RutaFTP.Text
        Puesto = cbx_puesto.Text
        Cedula = txtb_Cedula.Text
        Usuario = txtb_Usuario.Text
        Clave = txtb_Clave.Text
        For x = 0 To CheckedListBox1.CheckedItems.Count - 1
            If CheckedListBox1.CheckedItems.Item(x) = "Sector 1" Then Sector1 = "1"
            If CheckedListBox1.CheckedItems.Item(x) = "Sector 2" Then Sector2 = "1"
            If CheckedListBox1.CheckedItems.Item(x) = "Sector 3" Then Sector3 = "1"
            If CheckedListBox1.CheckedItems.Item(x) = "Sector 4" Then Sector4 = "1"
            If CheckedListBox1.CheckedItems.Item(x) = "Sector 5" Then Sector5 = "1"
            If CheckedListBox1.CheckedItems.Item(x) = "Sector 6" Then Sector6 = "1"
            If CheckedListBox1.CheckedItems.Item(x) = "Sector 7" Then Sector7 = "1"
            If CheckedListBox1.CheckedItems.Item(x) = "Sector 8" Then Sector8 = "1"
            If CheckedListBox1.CheckedItems.Item(x) = "Sector 9" Then Sector9 = "1"
            If CheckedListBox1.CheckedItems.Item(x) = "Sector 10" Then Sector10 = "1"
            If CheckedListBox1.CheckedItems.Item(x) = "Sector 11" Then Sector11 = "1"
            If CheckedListBox1.CheckedItems.Item(x) = "Sector 12" Then Sector12 = "1"
            If CheckedListBox1.CheckedItems.Item(x) = "Sector 13" Then Sector13 = "1"
            If CheckedListBox1.CheckedItems.Item(x) = "Sector 14" Then Sector14 = "1"
            If CheckedListBox1.CheckedItems.Item(x) = "Sector 15" Then Sector15 = "1"
            If CheckedListBox1.CheckedItems.Item(x) = "Sector 16" Then Sector16 = "1"
            If CheckedListBox1.CheckedItems.Item(x) = "Sector 17" Then Sector17 = "1"
            If CheckedListBox1.CheckedItems.Item(x) = "Sector 18" Then Sector18 = "1"
            If CheckedListBox1.CheckedItems.Item(x) = "Sector 19" Then Sector19 = "1"
            If CheckedListBox1.CheckedItems.Item(x) = "Sector 20" Then Sector20 = "1"

        Next x
    End Function
    Public Function Limpiar()


        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(i, False)
        Next

        txtb_Cod.Text = ""
        txtb_Nombre.Text = ""
        txtb_telf.Text = ""
        txtb_ConsPe.Text = ""
        txtb_ConsDevoluciones.Text = ""
        txtb_Correo.Text = ""
        txtb_RutaFTP.Text = ""
        cbx_puesto.Text = ""
        txtb_Usuario.Text = ""
        txtb_Clave.Text = ""

        Sector1 = "0"
        Sector2 = "0"
        Sector3 = "0"
        Sector4 = "0"
        Sector5 = "0"
        Sector6 = "0"
        Sector7 = "0"
        Sector8 = "0"
        Sector9 = "0"
        Sector10 = "0"
        Sector11 = "0"
        Sector12 = "0"
        Sector13 = "0"
        Sector14 = "0"
        Sector15 = "0"
        Sector16 = "0"
        Sector17 = "0"
        Sector18 = "0"
        Sector19 = "0"
        Sector20 = "0"

        txtb_Cedula.Enabled = False
        CheckedListBox1.Enabled = False
        txtb_Cod.Enabled = False
        txtb_Nombre.Enabled = False
        txtb_telf.Enabled = False
        txtb_ConsPe.Enabled = False
        txtb_ConsDevoluciones.Enabled = False
        txtb_Correo.Enabled = False
        txtb_RutaFTP.Enabled = False
        cbx_puesto.Enabled = False
        txtb_Usuario.Enabled = False
        txtb_Clave.Enabled = False

        DGV_Bodegueros.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaBodegueros(Class_VariablesGlobales.SQL_Comman2)


        DGV_Bodegueros.Columns(0).Width = 50
        DGV_Bodegueros.Columns(1).Width = 150
        DGV_Bodegueros.Columns(2).Width = 80
        DGV_Bodegueros.Columns(3).Width = 100
        DGV_Bodegueros.Columns(4).Width = 100
        DGV_Bodegueros.Columns(5).Width = 150
    End Function

    Public Function Nuevo()
        Sector1 = "0"
        Sector2 = "0"
        Sector3 = "0"
        Sector4 = "0"
        Sector5 = "0"
        Sector6 = "0"
        Sector7 = "0"
        Sector8 = "0"
        Sector9 = "0"
        Sector10 = "0"
        Sector11 = "0"
        Sector12 = "0"
        Sector13 = "0"
        Sector14 = "0"
        Sector15 = "0"
        Sector16 = "0"
        Sector17 = "0"
        Sector18 = "0"
        Sector19 = "0"
        Sector20 = "0"




        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(i, False)
        Next


        CheckedListBox1.Enabled = True

        txtb_Cedula.Enabled = True
        txtb_Cod.Enabled = True
        txtb_Nombre.Enabled = True
        txtb_telf.Enabled = True
        txtb_ConsPe.Enabled = True
        txtb_ConsDevoluciones.Enabled = True
        txtb_Correo.Enabled = True
        txtb_Clave.Enabled = True
        txtb_Usuario.Enabled = True
        txtb_RutaFTP.Enabled = True
        cbx_puesto.Enabled = True
        txtb_Usuario.Enabled = True
        btn_AgElimina.Enabled = False
        btn_AgModif.Enabled = False
        btn_AgGuardar.Enabled = True


    End Function

    Private Sub btn_AgNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgNuevo.Click
        Limpiar()
        Nuevo()
        txtb_Cod.Focus()

    End Sub

    Private Sub Admin_Bodeguero_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Limpiar()





    End Sub

    Private Sub DGV_Bodegueros_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_Bodegueros.CellClick
        'Limpiar()
        Nuevo()


        txtb_Cod.Text = DGV_Bodegueros.Item(0, DGV_Bodegueros.CurrentRow.Index).Value.ToString()
        txtb_Nombre.Text = DGV_Bodegueros.Item(1, DGV_Bodegueros.CurrentRow.Index).Value.ToString()
        txtb_telf.Text = DGV_Bodegueros.Item(2, DGV_Bodegueros.CurrentRow.Index).Value.ToString()
        txtb_ConsPe.Text = DGV_Bodegueros.Item(3, DGV_Bodegueros.CurrentRow.Index).Value.ToString()
        txtb_ConsDevoluciones.Text = DGV_Bodegueros.Item(4, DGV_Bodegueros.CurrentRow.Index).Value.ToString()
        txtb_Correo.Text = DGV_Bodegueros.Item(5, DGV_Bodegueros.CurrentRow.Index).Value.ToString()
        txtb_RutaFTP.Text = DGV_Bodegueros.Item(6, DGV_Bodegueros.CurrentRow.Index).Value.ToString()
        cbx_puesto.Text = DGV_Bodegueros.Item(7, DGV_Bodegueros.CurrentRow.Index).Value.ToString()
        txtb_Cedula.Text = DGV_Bodegueros.Item(8, DGV_Bodegueros.CurrentRow.Index).Value.ToString()

        txtb_Clave.Text = DGV_Bodegueros.Item(29, DGV_Bodegueros.CurrentRow.Index).Value.ToString()
        txtb_Usuario.Text = DGV_Bodegueros.Item(30, DGV_Bodegueros.CurrentRow.Index).Value.ToString()

        If DGV_Bodegueros.Item(9, DGV_Bodegueros.CurrentRow.Index).Value.ToString() = "1" Then CheckedListBox1.SetItemChecked(0, True) Else CheckedListBox1.SetItemChecked(0, False)
        If DGV_Bodegueros.Item(10, DGV_Bodegueros.CurrentRow.Index).Value.ToString() = "1" Then CheckedListBox1.SetItemChecked(1, True) Else CheckedListBox1.SetItemChecked(1, False)
        If DGV_Bodegueros.Item(11, DGV_Bodegueros.CurrentRow.Index).Value.ToString() = "1" Then CheckedListBox1.SetItemChecked(2, True) Else CheckedListBox1.SetItemChecked(2, False)
        If DGV_Bodegueros.Item(12, DGV_Bodegueros.CurrentRow.Index).Value.ToString() = "1" Then CheckedListBox1.SetItemChecked(3, True) Else CheckedListBox1.SetItemChecked(3, False)
        If DGV_Bodegueros.Item(13, DGV_Bodegueros.CurrentRow.Index).Value.ToString() = "1" Then CheckedListBox1.SetItemChecked(4, True) Else CheckedListBox1.SetItemChecked(4, False)
        If DGV_Bodegueros.Item(14, DGV_Bodegueros.CurrentRow.Index).Value.ToString() = "1" Then CheckedListBox1.SetItemChecked(5, True) Else CheckedListBox1.SetItemChecked(5, False)
        If DGV_Bodegueros.Item(15, DGV_Bodegueros.CurrentRow.Index).Value.ToString() = "1" Then CheckedListBox1.SetItemChecked(6, True) Else CheckedListBox1.SetItemChecked(6, False)
        If DGV_Bodegueros.Item(16, DGV_Bodegueros.CurrentRow.Index).Value.ToString() = "1" Then CheckedListBox1.SetItemChecked(7, True) Else CheckedListBox1.SetItemChecked(7, False)
        If DGV_Bodegueros.Item(17, DGV_Bodegueros.CurrentRow.Index).Value.ToString() = "1" Then CheckedListBox1.SetItemChecked(8, True) Else CheckedListBox1.SetItemChecked(8, False)
        If DGV_Bodegueros.Item(18, DGV_Bodegueros.CurrentRow.Index).Value.ToString() = "1" Then CheckedListBox1.SetItemChecked(9, True) Else CheckedListBox1.SetItemChecked(9, False)

        If DGV_Bodegueros.Item(19, DGV_Bodegueros.CurrentRow.Index).Value.ToString() = "1" Then CheckedListBox1.SetItemChecked(10, True) Else CheckedListBox1.SetItemChecked(10, False)
        If DGV_Bodegueros.Item(20, DGV_Bodegueros.CurrentRow.Index).Value.ToString() = "1" Then CheckedListBox1.SetItemChecked(11, True) Else CheckedListBox1.SetItemChecked(11, False)
        If DGV_Bodegueros.Item(21, DGV_Bodegueros.CurrentRow.Index).Value.ToString() = "1" Then CheckedListBox1.SetItemChecked(12, True) Else CheckedListBox1.SetItemChecked(12, False)
        If DGV_Bodegueros.Item(22, DGV_Bodegueros.CurrentRow.Index).Value.ToString() = "1" Then CheckedListBox1.SetItemChecked(13, True) Else CheckedListBox1.SetItemChecked(13, False)
        If DGV_Bodegueros.Item(23, DGV_Bodegueros.CurrentRow.Index).Value.ToString() = "1" Then CheckedListBox1.SetItemChecked(14, True) Else CheckedListBox1.SetItemChecked(14, False)
        If DGV_Bodegueros.Item(24, DGV_Bodegueros.CurrentRow.Index).Value.ToString() = "1" Then CheckedListBox1.SetItemChecked(15, True) Else CheckedListBox1.SetItemChecked(15, False)
        If DGV_Bodegueros.Item(25, DGV_Bodegueros.CurrentRow.Index).Value.ToString() = "1" Then CheckedListBox1.SetItemChecked(16, True) Else CheckedListBox1.SetItemChecked(16, False)
        If DGV_Bodegueros.Item(26, DGV_Bodegueros.CurrentRow.Index).Value.ToString() = "1" Then CheckedListBox1.SetItemChecked(17, True) Else CheckedListBox1.SetItemChecked(17, False)
        If DGV_Bodegueros.Item(27, DGV_Bodegueros.CurrentRow.Index).Value.ToString() = "1" Then CheckedListBox1.SetItemChecked(18, True) Else CheckedListBox1.SetItemChecked(18, False)
        If DGV_Bodegueros.Item(28, DGV_Bodegueros.CurrentRow.Index).Value.ToString() = "1" Then CheckedListBox1.SetItemChecked(19, True) Else CheckedListBox1.SetItemChecked(19, False)





        btn_AgGuardar.Enabled = False
        btn_AgElimina.Enabled = True
        btn_AgModif.Enabled = True
    End Sub

    Private Sub btn_AgModif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgModif.Click

        AsignaValores()
        Class_VariablesGlobales.Obj_Funciones_SQL.ModificaBodeguero(Class_VariablesGlobales.SQL_Comman2, CodBodeguero, Nombre, Telefono, Conse_RepCarga, Conse_RepDevoluciones, Correo, FTP, Puesto, _
                                      Cedula, Sector1, Sector2, Sector3, Sector4, Sector5, Sector6, Sector7, Sector8, Sector9, Sector10, Sector11, Sector12, Sector13, Sector14, Sector15, Sector16, Sector17, Sector18, Sector19, Sector20, Clave, Usuario)
        Limpiar()


    End Sub

    Private Sub btn_AgElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgElimina.Click
        Class_VariablesGlobales.Obj_Funciones_SQL.EliminaBodeguero(Class_VariablesGlobales.SQL_Comman2, Trim(txtb_Cod.Text))
        Limpiar()

    End Sub

End Class