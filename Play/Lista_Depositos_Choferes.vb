Public Class Lista_Depositos_Choferes

    Dim FINI As String
    Dim FFIN As String

    Private Sub Lista_Depositos_Choferes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FINI = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Desde.Value.Date.AddDays(-30))
        FFIN = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Hasta.Value.Date)

        Admin_Depositos_Agentes.TopMost = False

        If Class_VariablesGlobales.NumDepBuscando <> "" Then
            Txb_NumDepo.Text = Class_VariablesGlobales.NumDepBuscando
        ElseIf Class_VariablesGlobales.ConseDepBuscando <> "" Then
            Txb_Consecutivo.Text = Class_VariablesGlobales.NumDepBuscando
        Else
            dgv_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", "", FINI, FFIN, txtb_CodAgente.Text, "", "", "", "DPCONSECUTIVO", "CHOFERES", chbx_VerAnulado.Checked, Trim(txtb_Monto.Text))
        End If



    End Sub




    Private Sub DTP_Hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_Hasta.ValueChanged
        'dgv_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Desde.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Hasta.Value.Date), txtb_CodAgente.Text, "", Txb_Consecutivo.Text, "", "DPCONSECUTIVO", Class_VariablesGlobales.LIQUIDANDO)

        FINI = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Desde.Value.Date)
        FFIN = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Hasta.Value.Date)

        dgv_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", "", FINI, FFIN, txtb_CodAgente.Text, "", Txb_Consecutivo.Text, "", "DPCONSECUTIVO", Class_VariablesGlobales.LIQUIDANDO, chbx_VerAnulado.Checked, Trim(txtb_Monto.Text))

    End Sub




    Private Sub dgv_Liquidaciones_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_Liquidaciones.CellClick

    End Sub


    Private Sub btn_BuscaAgente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaAgente.Click
        If Class_VariablesGlobales.LIQUIDANDO = "AGENTES" Then
            Class_VariablesGlobales.Lista_llamadaDesde = "LISTADEPOSITOS"

            Class_VariablesGlobales.Obj_ListaAgentes = New ListaAgentes
            Class_VariablesGlobales.Obj_ListaAgentes.MdiParent = Principal
            Class_VariablesGlobales.Obj_ListaAgentes.Puesto = "AGENTE"
            Class_VariablesGlobales.Obj_ListaAgentes.Show()


        Else
            Class_VariablesGlobales.Lista_llamadaDesde = "LISTADEPOSITOS"
            ListaChoferes.Show()
        End If


    End Sub

    Private Sub DTP_Desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_Desde.ValueChanged
        FINI = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Desde.Value.Date)
        FFIN = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Hasta.Value.Date)

        dgv_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", "", FINI, FFIN, txtb_CodAgente.Text, "", Txb_Consecutivo.Text, "", "DPCONSECUTIVO", Class_VariablesGlobales.LIQUIDANDO, chbx_VerAnulado.Checked, Trim(txtb_Monto.Text))

    End Sub



    Private Sub Lista_Depositos_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Admin_Depositos_Choferes.TopMost = True
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Txb_NumDepo.Text = ""
        Txb_Consecutivo.Text = ""
        txtb_CodAgente.Text = ""
        txtb_NumLiq.Text = ""
        txtb_Monto.Text = ""
        FINI = ""
        FFIN = ""
        DTP_Desde.Value = Now.Date
        DTP_Hasta.Value = Now.Date



        dgv_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", "", "", "", txtb_CodAgente.Text, "", "", "", "DPCONSECUTIVO", "CHOFERES", chbx_VerAnulado.Checked, Trim(txtb_Monto.Text))
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txb_NumDepo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txb_NumDepo.KeyPress
        dgv_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", txtb_NumLiq.Text, FINI, FFIN, txtb_CodAgente.Text, Txb_NumDepo.Text, Txb_Consecutivo.Text, "", "DPCODIGO", "CHOFERES", chbx_VerAnulado.Checked, Trim(txtb_Monto.Text))
    End Sub

    Private Sub txtb_NumLiq_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_NumLiq.KeyPress
        dgv_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", txtb_NumLiq.Text, FINI, FFIN, txtb_CodAgente.Text, Txb_NumDepo.Text, Txb_Consecutivo.Text, "", "DPCODIGO", "CHOFERES", chbx_VerAnulado.Checked, Trim(txtb_Monto.Text))
    End Sub

    Private Sub Txb_Consecutivo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txb_Consecutivo.KeyPress
        dgv_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", txtb_NumLiq.Text, FINI, FFIN, txtb_CodAgente.Text, Txb_NumDepo.Text, Txb_Consecutivo.Text, "", "DPCODIGO", "CHOFERES", chbx_VerAnulado.Checked, Trim(txtb_Monto.Text))
    End Sub

    Private Sub txtb_CodAgente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtb_CodAgente.TextChanged

        dgv_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", txtb_NumLiq.Text, FINI, FFIN, txtb_CodAgente.Text, Txb_NumDepo.Text, Txb_Consecutivo.Text, "", "DPCODIGO", "CHOFERES", chbx_VerAnulado.Checked, Trim(txtb_Monto.Text))
    End Sub


    Private Sub Txb_NumDepo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_NumDepo.TextChanged
        dgv_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", txtb_NumLiq.Text, FINI, FFIN, txtb_CodAgente.Text, Txb_NumDepo.Text, Txb_Consecutivo.Text, "", "DPCODIGO", "CHOFERES", chbx_VerAnulado.Checked, Trim(txtb_Monto.Text))
    End Sub

    Private Sub Txb_Consecutivo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_Consecutivo.TextChanged
        dgv_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", txtb_NumLiq.Text, FINI, FFIN, txtb_CodAgente.Text, Txb_NumDepo.Text, Txb_Consecutivo.Text, "", "DPCODIGO", "CHOFERES", chbx_VerAnulado.Checked, Trim(txtb_Monto.Text))
    End Sub

    Private Sub txtb_NumLiq_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtb_NumLiq.TextChanged
        dgv_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", txtb_NumLiq.Text, FINI, FFIN, txtb_CodAgente.Text, Txb_NumDepo.Text, Txb_Consecutivo.Text, "", "DPCODIGO", "CHOFERES", chbx_VerAnulado.Checked, Trim(txtb_Monto.Text))
    End Sub

    Private Sub txtb_Monto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtb_Monto.KeyPress

        dgv_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", txtb_NumLiq.Text, FINI, FFIN, txtb_CodAgente.Text, Txb_NumDepo.Text, Txb_Consecutivo.Text, "", "DPCODIGO", "CHOFERES", chbx_VerAnulado.Checked, Trim(txtb_Monto.Text))
        dgv_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", "", FINI, FFIN, txtb_CodAgente.Text, Txb_NumDepo.Text, Txb_Consecutivo.Text, "", "DPCONSECUTIVO", Class_VariablesGlobales.LIQUIDANDO, chbx_VerAnulado.Checked, Trim(txtb_Monto.Text))
    End Sub

    Private Sub dgv_Liquidaciones_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_Liquidaciones.CellMouseDoubleClick
        Try

            If Class_VariablesGlobales.LIQUIDANDO = "AGENTES" Then
                Class_VariablesGlobales.frmDeposAgente.txb_consecutivo.Text = dgv_Liquidaciones.CurrentRow.Cells.Item(0).Value.ToString
                Class_VariablesGlobales.frmDeposAgente.txb_NumDepo.Text = dgv_Liquidaciones.CurrentRow.Cells.Item(1).Value.ToString
                Class_VariablesGlobales.frmDeposAgente.dtp_Fecha.Text = dgv_Liquidaciones.CurrentRow.Cells.Item(2).Value.ToString
                Class_VariablesGlobales.frmDeposAgente.cbbx_Banco.Text = dgv_Liquidaciones.CurrentRow.Cells.Item(3).Value.ToString
                Class_VariablesGlobales.frmDeposAgente.txb_Monto.Text = dgv_Liquidaciones.CurrentRow.Cells.Item(4).Value.ToString
                Class_VariablesGlobales.frmDeposAgente.dtp_FechaContable.Text = dgv_Liquidaciones.CurrentRow.Cells.Item(10).Value.ToString
                Class_VariablesGlobales.frmDeposAgente.txb_CodAgente.Text = dgv_Liquidaciones.CurrentRow.Cells.Item(6).Value.ToString

                If Trim(dgv_Liquidaciones.CurrentRow.Cells.Item(6).Value.ToString) <> "" Then
                    Class_VariablesGlobales.frmDeposAgente.txb_NomAgente.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneNameAgente(Class_VariablesGlobales.SQL_Comman1, Trim(dgv_Liquidaciones.CurrentRow.Cells.Item(6).Value.ToString))
                End If

                Class_VariablesGlobales.frmDeposAgente.txb_Liquidacion.Text = dgv_Liquidaciones.CurrentRow.Cells.Item(7).Value.ToString
                Class_VariablesGlobales.frmDeposAgente.txb_Comentario.Text = dgv_Liquidaciones.CurrentRow.Cells.Item(5).Value.ToString

                If dgv_Liquidaciones.CurrentRow.Cells.Item(8).Value.ToString = "1" Then
                    Class_VariablesGlobales.frmDeposAgente.cbbx_Subido.Text = "SI"
                Else
                    Class_VariablesGlobales.frmDeposAgente.cbbx_Subido.Text = "NO"
                End If

                If dgv_Liquidaciones.CurrentRow.Cells.Item(11).Value.ToString = "1" Then
                    Class_VariablesGlobales.frmDeposAgente.lbl_Anulado.Visible = True
                    Class_VariablesGlobales.frmDeposAgente.txb_consecutivo.Enabled = False
                    Class_VariablesGlobales.frmDeposAgente.txb_NumDepo.Enabled = False
                    Class_VariablesGlobales.frmDeposAgente.dtp_Fecha.Enabled = False
                    Class_VariablesGlobales.frmDeposAgente.cbbx_Banco.Enabled = False
                    Class_VariablesGlobales.frmDeposAgente.txb_Monto.Enabled = False
                    Class_VariablesGlobales.frmDeposAgente.txb_CodAgente.Enabled = False
                    Class_VariablesGlobales.frmDeposAgente.txb_NomAgente.Enabled = False
                    Class_VariablesGlobales.frmDeposAgente.txb_Liquidacion.Enabled = False
                    Class_VariablesGlobales.frmDeposAgente.txb_Comentario.Enabled = False
                    Class_VariablesGlobales.frmDeposAgente.cbbx_Subido.Enabled = False
                    Class_VariablesGlobales.frmDeposAgente.dtp_FechaContable.Enabled = False
                    Class_VariablesGlobales.frmDeposAgente.btn_AgModif.Enabled = False
                    Class_VariablesGlobales.frmDeposAgente.btn_AgElimina.Enabled = False
                Else
                    Class_VariablesGlobales.frmDeposAgente.lbl_Anulado.Visible = False
                    Class_VariablesGlobales.frmDeposAgente.txb_consecutivo.Enabled = True
                    Class_VariablesGlobales.frmDeposAgente.txb_NumDepo.Enabled = True
                    Class_VariablesGlobales.frmDeposAgente.dtp_Fecha.Enabled = True
                    Class_VariablesGlobales.frmDeposAgente.cbbx_Banco.Enabled = True
                    Class_VariablesGlobales.frmDeposAgente.txb_Monto.Enabled = True
                    Class_VariablesGlobales.frmDeposAgente.txb_CodAgente.Enabled = True
                    Class_VariablesGlobales.frmDeposAgente.txb_NomAgente.Enabled = True
                    Class_VariablesGlobales.frmDeposAgente.txb_Liquidacion.Enabled = True
                    Class_VariablesGlobales.frmDeposAgente.txb_Comentario.Enabled = True
                    Class_VariablesGlobales.frmDeposAgente.cbbx_Subido.Enabled = True
                    Class_VariablesGlobales.frmDeposAgente.dtp_FechaContable.Enabled = True
                    Class_VariablesGlobales.frmDeposAgente.btn_AgModif.Enabled = True
                    Class_VariablesGlobales.frmDeposAgente.btn_AgElimina.Enabled = True
                End If






            Else '------------------------ CHOFERES ---------------------------


                Class_VariablesGlobales.frmDeposChofer.txb_consecutivo.Text = dgv_Liquidaciones.CurrentRow.Cells.Item(0).Value.ToString
                Class_VariablesGlobales.frmDeposChofer.txb_NumDepo.Text = dgv_Liquidaciones.CurrentRow.Cells.Item(1).Value.ToString
                Class_VariablesGlobales.frmDeposChofer.dtp_Fecha.Text = dgv_Liquidaciones.CurrentRow.Cells.Item(2).Value.ToString
                Class_VariablesGlobales.frmDeposChofer.cbbx_Banco.Text = dgv_Liquidaciones.CurrentRow.Cells.Item(3).Value.ToString
                Class_VariablesGlobales.frmDeposChofer.txb_Monto.Text = dgv_Liquidaciones.CurrentRow.Cells.Item(4).Value.ToString
                Class_VariablesGlobales.frmDeposChofer.dtp_FechaContable.Text = dgv_Liquidaciones.CurrentRow.Cells.Item(10).Value.ToString
                Class_VariablesGlobales.frmDeposChofer.txb_CodAgente.Text = dgv_Liquidaciones.CurrentRow.Cells.Item(6).Value.ToString

                If Trim(dgv_Liquidaciones.CurrentRow.Cells.Item(6).Value.ToString) <> "" Then
                    Class_VariablesGlobales.frmDeposChofer.txb_NomAgente.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneNameAgente(Class_VariablesGlobales.SQL_Comman1, Trim(dgv_Liquidaciones.CurrentRow.Cells.Item(6).Value.ToString))
                End If

                Class_VariablesGlobales.frmDeposChofer.txb_Liquidacion.Text = dgv_Liquidaciones.CurrentRow.Cells.Item(7).Value.ToString

                If Class_VariablesGlobales.frmDeposChofer.txb_Liquidacion.Text <> "0" And Class_VariablesGlobales.frmDeposChofer.txb_Liquidacion.Text <> "" Then
                    Class_VariablesGlobales.frmDeposChofer.btn_GoToLiq.Enabled = True
                End If

                Class_VariablesGlobales.frmDeposChofer.txb_Comentario.Text = dgv_Liquidaciones.CurrentRow.Cells.Item(5).Value.ToString

                If dgv_Liquidaciones.CurrentRow.Cells.Item(8).Value.ToString = "1" Then
                    Class_VariablesGlobales.frmDeposChofer.cbbx_Subido.Text = "SI"
                Else
                    Class_VariablesGlobales.frmDeposChofer.cbbx_Subido.Text = "NO"
                End If

                If dgv_Liquidaciones.CurrentRow.Cells.Item(11).Value.ToString = "1" Then
                    Class_VariablesGlobales.frmDeposChofer.lbl_Anulado.Visible = True
                    Class_VariablesGlobales.frmDeposChofer.txb_consecutivo.Enabled = False
                    Class_VariablesGlobales.frmDeposChofer.txb_NumDepo.Enabled = False
                    Class_VariablesGlobales.frmDeposChofer.dtp_Fecha.Enabled = False
                    Class_VariablesGlobales.frmDeposChofer.cbbx_Banco.Enabled = False
                    Class_VariablesGlobales.frmDeposChofer.txb_Monto.Enabled = False
                    Class_VariablesGlobales.frmDeposChofer.txb_CodAgente.Enabled = False
                    Class_VariablesGlobales.frmDeposChofer.txb_NomAgente.Enabled = False
                    Class_VariablesGlobales.frmDeposChofer.txb_Liquidacion.Enabled = False
                    Class_VariablesGlobales.frmDeposChofer.txb_Comentario.Enabled = False
                    Class_VariablesGlobales.frmDeposChofer.cbbx_Subido.Enabled = False
                    Class_VariablesGlobales.frmDeposChofer.dtp_FechaContable.Enabled = False
                    Class_VariablesGlobales.frmDeposChofer.btn_AgModif.Enabled = False
                    Class_VariablesGlobales.frmDeposChofer.btn_AgGuardar.Enabled = False
                    Class_VariablesGlobales.frmDeposChofer.btn_AgElimina.Enabled = False

                Else
                    Class_VariablesGlobales.frmDeposChofer.lbl_Anulado.Visible = False
                    Class_VariablesGlobales.frmDeposChofer.txb_consecutivo.Enabled = True
                    Class_VariablesGlobales.frmDeposChofer.txb_NumDepo.Enabled = True
                    Class_VariablesGlobales.frmDeposChofer.dtp_Fecha.Enabled = True
                    Class_VariablesGlobales.frmDeposChofer.cbbx_Banco.Enabled = True
                    Class_VariablesGlobales.frmDeposChofer.txb_Monto.Enabled = True
                    Class_VariablesGlobales.frmDeposChofer.txb_CodAgente.Enabled = True
                    Class_VariablesGlobales.frmDeposChofer.txb_NomAgente.Enabled = True
                    Class_VariablesGlobales.frmDeposChofer.txb_Liquidacion.Enabled = True
                    Class_VariablesGlobales.frmDeposChofer.txb_Comentario.Enabled = True
                    Class_VariablesGlobales.frmDeposChofer.cbbx_Subido.Enabled = True
                    Class_VariablesGlobales.frmDeposChofer.dtp_FechaContable.Enabled = True
                    Class_VariablesGlobales.frmDeposChofer.btn_AgModif.Enabled = True
                    Class_VariablesGlobales.frmDeposChofer.btn_AgGuardar.Enabled = False
                    Class_VariablesGlobales.frmDeposChofer.btn_AgElimina.Enabled = True
                End If


                'Class_VariablesGlobales.frmDeposChofer.btn_AgElimina.Enabled = True
                'Class_VariablesGlobales.frmDeposChofer.btn_AgGuardar.Enabled = False
                'Class_VariablesGlobales.frmDeposChofer.btn_AgModif.Enabled = True
                'Class_VariablesGlobales.frmDeposChofer.btn_GoToLiq.Enabled = True




            End If





            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)


        End Try
    End Sub
End Class