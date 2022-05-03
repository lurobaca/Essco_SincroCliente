Public Class Admin_Choferes

    Public Obj_SQL_CONEXIONSERVER As New Class_funcionesSQL
    Private Sub btn_AgNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Public Function lIMPIAR()
        txtb_Cod.Text = ""
        txtb_Nombre.Text = ""
        txtb_telf.Text = ""
        txtb_ConsPe.Text = ""
        txtb_ConsePag.Text = ""
        txtb_ConsDep.Text = ""
        txtb_Correo.Text = ""
        txtb_RutaFTP.Text = ""

        txtb_Cedula.Text = ""
        txtb_ConsGastos.Text = ""
        txtb_ConsDevoluciones.Text = ""
        txtb_ConsSinVisitas.Text = ""
        CBx_Puesto.Text = ""

    End Function

   



    Private Sub btn_AgGuardar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgGuardar.Click
        If CBx_Puesto.Text = "" Then
            MsgBox("Debe indicar un puesto")
        Else
            Obj_SQL_CONEXIONSERVER.INSERTA_Chofer(Class_VariablesGlobales.SQL_Comman2, txtb_Cod.Text, txtb_Cedula.Text, txtb_Nombre.Text, txtb_telf.Text, txtb_ConsPe.Text, txtb_ConsePag.Text, txtb_ConsGastos.Text, txtb_ConsSinVisitas.Text, txtb_ConsDep.Text, txtb_Correo.Text, txtb_RutaFTP.Text, CBx_Puesto.Text, txtb_ConsDevoluciones.Text)
            lIMPIAR()
            txtb_Cod.Focus()
            DGV_Agentes.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneChoferes(Class_VariablesGlobales.SQL_Comman2, "", "")
        End If

    End Sub

    Private Sub btn_AgModif_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgModif.Click
        If CBx_Puesto.Text = "" Then
            MsgBox("Debe indicar un puesto")
        Else
            Obj_SQL_CONEXIONSERVER.Actualiza_Choferes(Class_VariablesGlobales.SQL_Comman2, txtb_Cod.Text, txtb_Cedula.Text, txtb_Nombre.Text, txtb_telf.Text, txtb_ConsPe.Text, txtb_ConsePag.Text, txtb_ConsDep.Text, txtb_ConsGastos.Text, txtb_ConsSinVisitas.Text, txtb_Correo.Text, txtb_RutaFTP.Text, CBx_Puesto.Text, txtb_ConsDevoluciones.Text)
            lIMPIAR()
            txtb_Cod.Focus()
            DGV_Agentes.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneChoferes(Class_VariablesGlobales.SQL_Comman2, "", "")
            btn_AgElimina.Enabled = False
            btn_AgModif.Enabled = False
        End If
    End Sub

    Private Sub btn_AgElimina_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgElimina.Click
        Obj_SQL_CONEXIONSERVER.Elimina_Chofer(Class_VariablesGlobales.SQL_Comman2, txtb_Cod.Text)
        lIMPIAR()
        txtb_Cod.Focus()
        DGV_Agentes.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneChoferes(Class_VariablesGlobales.SQL_Comman2, "", "")
        btn_AgElimina.Enabled = False
        btn_AgModif.Enabled = False
    End Sub

    Private Sub btn_AgNuevo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgNuevo.Click
        lIMPIAR()
        txtb_Cod.Focus()
        btn_AgElimina.Enabled = False
        btn_AgModif.Enabled = False
        btn_AgGuardar.Enabled = True
    End Sub

    Private Sub Admin_Choferes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV_Agentes.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneChoferes(Class_VariablesGlobales.SQL_Comman2, "", "")
    End Sub

    Private Sub DGV_Agentes_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_Agentes.CellClick
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
            CBx_Puesto.Text = DGV_Agentes.Rows(e.RowIndex).Cells(10).Value
            txtb_Cedula.Text = DGV_Agentes.Rows(e.RowIndex).Cells(11).Value
            txtb_ConsDevoluciones.Text = DGV_Agentes.Rows(e.RowIndex).Cells(12).Value

            btn_AgModif.Enabled = True
            btn_AgElimina.Enabled = True
            btn_AgGuardar.Enabled = False
        Catch ex As Exception

        End Try

    End Sub
End Class