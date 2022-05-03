Public Class Admin_Agentes
    Public Obj_SQL_CONEXIONSERVER As New Class_funcionesSQL


    Public Function lIMPIAR_AGENTES()
        txtb_Cod.Text = ""
        txtb_Nombre.Text = ""
        txtb_telf.Text = ""
        txtb_ConsPe.Text = ""
        txtb_ConsePag.Text = ""
        txtb_ConsDep.Text = ""
        txtb_Correo.Text = ""
        txtb_RutaFTP.Text = ""
        txtb_Grupo.Text = ""
        txtb_Cedula.Text = ""
        txtb_ConsGastos.Text = ""
        txtb_ConsSinVisitas.Text = ""
        txtb_ConsDevoluciones.Text = ""
        txtb_ConsClientesNuevos.Text = ""
        CBx_Puesto.Text = ""
    End Function

    Private Sub btn_AgGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgGuardar.Click
        'Verificar si ya existe el codgio
        If Obj_SQL_CONEXIONSERVER.ExisteCod(Class_VariablesGlobales.SQL_Comman2, txtb_Cod.Text) = 0 Then

            If CBx_Puesto.Text <> "" Then

                Obj_SQL_CONEXIONSERVER.INSERTA_Agente(Class_VariablesGlobales.SQL_Comman2, txtb_Cod.Text, txtb_Cedula.Text, txtb_Nombre.Text, txtb_telf.Text, txtb_ConsPe.Text, txtb_ConsePag.Text, txtb_ConsGastos.Text, txtb_ConsSinVisitas.Text, txtb_ConsDep.Text, txtb_Correo.Text, txtb_RutaFTP.Text, txtb_Grupo.Text, txtb_ConsDevoluciones.Text, txtb_ConsClientesNuevos.Text, CBx_Puesto.Text)
                lIMPIAR_AGENTES()
                txtb_Cod.Focus()

                DGV_Agentes.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman2, CBox_VERPuestos.Text, "")

            Else
                MsgBox("Debe indicar el puesto del empleado")
            End If
        Else
                MsgBox("El codigo " & txtb_Cod.Text & " ya existe")

            End If

    End Sub

    Private Sub txtb_Agente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_Cod.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True


        End If
    End Sub

    Private Sub txtb_Nombre_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_Nombre.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True


        End If
    End Sub

    Private Sub txtb_telf_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_telf.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True


        End If
    End Sub

    Private Sub txtb_ConsPe_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_ConsPe.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True


        End If
    End Sub

    Private Sub txtb_ConsePag_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_ConsePag.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True


        End If
    End Sub

    Private Sub txtb_ConsDep_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_ConsDep.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True


        End If
    End Sub

    Private Sub txtb_Correo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_Correo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True


        End If
    End Sub

    Private Sub txtb_RutaFTP_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_RutaFTP.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True


        End If
    End Sub

    Private Sub btn_AgNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgNuevo.Click
        lIMPIAR_AGENTES()
        txtb_Cod.Focus()
        btn_AgElimina.Enabled = False
        btn_AgModif.Enabled = False
        btn_AgGuardar.Enabled = True
    End Sub

    Private Sub Admin_Agentes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV_Agentes.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman2, CBox_VERPuestos.Text, "")


        DGV_Agentes.Columns(0).Width = 40
        DGV_Agentes.Columns(1).Width = 250
    End Sub



    Private Sub btn_AgModif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgModif.Click
        Obj_SQL_CONEXIONSERVER.Actualiza_Agente(Class_VariablesGlobales.SQL_Comman2, txtb_Cod.Text, txtb_Cedula.Text, txtb_Nombre.Text, txtb_telf.Text, txtb_ConsPe.Text, txtb_ConsePag.Text, txtb_ConsDep.Text, txtb_ConsGastos.Text, txtb_ConsSinVisitas.Text, txtb_Correo.Text, txtb_RutaFTP.Text, txtb_Grupo.Text, txtb_ConsDevoluciones.Text, txtb_ConsClientesNuevos.Text, CBx_Puesto.Text)
        lIMPIAR_AGENTES()
        txtb_Cod.Focus()
        DGV_Agentes.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman2, CBox_VERPuestos.Text, "")
        btn_AgElimina.Enabled = False
        btn_AgModif.Enabled = False

    End Sub

    Private Sub btn_AgElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgElimina.Click
        Obj_SQL_CONEXIONSERVER.Elimina_Agente(Class_VariablesGlobales.SQL_Comman2, txtb_Cod.Text)
        lIMPIAR_AGENTES()
        txtb_Cod.Focus()
        DGV_Agentes.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman2, CBox_VERPuestos.Text, "")
        btn_AgElimina.Enabled = False
        btn_AgModif.Enabled = False
    End Sub



    Private Sub DGV_Agentes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Agentes.CellContentClick
        Try


            txtb_Cod.Text = DGV_Agentes.Rows(e.RowIndex).Cells(0).Value
            txtb_Nombre.Text = DGV_Agentes.Rows(e.RowIndex).Cells(1).Value
            txtb_telf.Text = DGV_Agentes.Rows(e.RowIndex).Cells(2).Value
            txtb_ConsPe.Text = DGV_Agentes.Rows(e.RowIndex).Cells(3).Value
            txtb_ConsePag.Text = DGV_Agentes.Rows(e.RowIndex).Cells(4).Value
            txtb_ConsDep.Text = DGV_Agentes.Rows(e.RowIndex).Cells(5).Value
            txtb_ConsGastos.Text = DGV_Agentes.Rows(e.RowIndex).Cells(6).Value
            txtb_ConsSinVisitas.Text = DGV_Agentes.Rows(e.RowIndex).Cells(7).Value
            txtb_Correo.Text = DGV_Agentes.Rows(e.RowIndex).Cells(8).Value
            txtb_RutaFTP.Text = DGV_Agentes.Rows(e.RowIndex).Cells(9).Value
            txtb_Grupo.Text = DGV_Agentes.Rows(e.RowIndex).Cells(10).Value
            txtb_Cedula.Text = DGV_Agentes.Rows(e.RowIndex).Cells(11).Value
            txtb_ConsDevoluciones.Text = DGV_Agentes.Rows(e.RowIndex).Cells(12).Value
            txtb_ConsClientesNuevos.Text = DGV_Agentes.Rows(e.RowIndex).Cells(13).Value
            CBx_Puesto.Text = DGV_Agentes.Rows(e.RowIndex).Cells(14).Value.ToString
            btn_AgModif.Enabled = True
            btn_AgElimina.Enabled = True
            btn_AgGuardar.Enabled = False


        Catch ex As Exception

        End Try
    End Sub

    Private Sub CBox_VERPuestos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBox_VERPuestos.SelectedIndexChanged
        DGV_Agentes.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman2, CBox_VERPuestos.Text, "")
    End Sub

    Private Sub txtb_Cod_TextChanged(sender As Object, e As EventArgs) Handles txtb_Cod.TextChanged
        txtb_ConsPe.Text.PadRight(10, "0")
    End Sub
End Class