Public Class Lista_Gastos_Choferes

    Public Shared iniciando As Boolean = False
    Public Shared FINI As String = ""
    Public Shared FFIN As String = ""
    Private Sub Lista_Gastos_Choferes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Detalle_Gastos.TopMost = False



        FINI = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Desde.Value.Date.AddDays(-30))
        FFIN = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Hasta.Value.Date)
        DTP_Desde.Value = FINI


        If Class_VariablesGlobales.NumGastoBuscando <> "" Then
            Txb_NumGasto.Text = Class_VariablesGlobales.NumGastoBuscando
            dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, "", "CHOFERES", "", "", FINI, FFIN, Class_VariablesGlobales.NumGastoBuscando, "", False, CBox_IncluidoEnLiquidacion.Checked)


        ElseIf Class_VariablesGlobales.ConseGastoBuscando <> "" Then
            Txb_NumGasto.Text = Class_VariablesGlobales.ConseGastoBuscando
            dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, "", "CHOFERES", "", "", FINI, FFIN, "", Class_VariablesGlobales.ConseGastoBuscando, False, CBox_IncluidoEnLiquidacion.Checked)
        Else
            If Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION" Then
                dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, "", "CHOFERES", Class_VariablesGlobales.TituloDetalleGasto, Class_VariablesGlobales.Chofer, FINI, FFIN, "", "", False, CBox_IncluidoEnLiquidacion.Checked)
            Else
                dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, "", "CHOFERES", "", "", FINI, FFIN, "", "", True, CBox_IncluidoEnLiquidacion.Checked)
            End If
        End If

        txtb_CodAgente.Text = Class_VariablesGlobales.Chofer

        iniciando = True
    End Sub



    Private Sub dgv_Gastos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_Gastos.CellClick

    End Sub

    Private Sub btn_BuscaAgente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaAgente.Click

        Class_VariablesGlobales.Lista_llamadaDesde = "LISTAGASTOS_CHOFERES"
        ListaChoferes.Show()


    End Sub

    Private Sub DTP_Desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_Desde.ValueChanged
        If iniciando = True Then 'evita una carga doble de informacion


            FINI = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Desde.Value.Date)
            FFIN = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Hasta.Value.Date)

            dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, txtb_NumLiq.Text, "CHOFERES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, chbx_VerAnulado.Checked, CBox_IncluidoEnLiquidacion.Checked)
            'If Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION" Then
            '    dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastos(Class_VariablesGlobales.SQL_Comman1, "", "CHOFERES", "", txtb_CodAgente.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Desde.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Hasta.Value.Date), "", "", False)
            'Else
            '    dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastos(Class_VariablesGlobales.SQL_Comman1, "", "CHOFERES", "", txtb_CodAgente.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Desde.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Hasta.Value.Date), "", "", True)
            'End If
        End If
    End Sub

    Private Sub DTP_Hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_Hasta.ValueChanged
        If iniciando = True Then 'evita una carga doble de informacion


            FINI = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Desde.Value.Date)
            FFIN = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Hasta.Value.Date)
            dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, txtb_NumLiq.Text, "CHOFERES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, chbx_VerAnulado.Checked, CBox_IncluidoEnLiquidacion.Checked)
            'If Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION" Then
            '    dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastos(Class_VariablesGlobales.SQL_Comman1, "", "CHOFERES", "", txtb_CodAgente.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Desde.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Hasta.Value.Date), "", "", False)
            'Else
            '    dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastos(Class_VariablesGlobales.SQL_Comman1, "", "CHOFERES", "", txtb_CodAgente.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Desde.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Hasta.Value.Date), "", "", True)
            'End If

            ' , , "", "", Txb_Consecutivo.Text, "", "DPCONSECUTIVO"
        End If
    End Sub



    Private Sub Txb_NumGasto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_NumGasto.TextChanged
        If iniciando = True Then 'evita una carga doble de informacion
            dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, txtb_NumLiq.Text, "CHOFERES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, chbx_VerAnulado.Checked, CBox_IncluidoEnLiquidacion.Checked)

        End If
    End Sub

    Private Sub Txb_Consecutivo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_Consecutivo.TextChanged
        If iniciando = True Then 'evita una carga doble de informacion
            dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, txtb_NumLiq.Text, "CHOFERES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, chbx_VerAnulado.Checked, CBox_IncluidoEnLiquidacion.Checked)

        End If
    End Sub

    Private Sub txtb_CodAgente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtb_CodAgente.TextChanged
        If iniciando = True Then 'evita una carga doble de informacion
            dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, txtb_NumLiq.Text, "CHOFERES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, chbx_VerAnulado.Checked, CBox_IncluidoEnLiquidacion.Checked)

        End If
    End Sub

    Private Sub Lista_Gastos_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If iniciando = True Then 'evita una carga doble de informacion
            Class_VariablesGlobales.frmDetalle_Gastos_Choferes.TopMost = True
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If iniciando = True Then 'evita una carga doble de informacion
            dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, txtb_NumLiq.Text, "CHOFERES", Class_VariablesGlobales.TituloDetalleGasto, txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, chbx_VerAnulado.Checked, chbx_VerAnulado.Checked)

        End If


    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        DTP_Desde.Value = Now.Date
        DTP_Hasta.Value = Now.Date
        FINI = ""
        FFIN = ""
        txtb_NumLiq.Text = ""
        txtb_CodAgente.Text = ""
        Txb_NumGasto.Text = ""
        Txb_Consecutivo.Text = ""
        chbx_VerAnulado.Checked = True
        dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, txtb_NumLiq.Text, "CHOFERES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, chbx_VerAnulado.Checked, CBox_IncluidoEnLiquidacion.Checked)
    End Sub


    Private Sub Txb_NumGasto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txb_NumGasto.KeyPress
        If iniciando = True Then 'evita una carga doble de informacion
            dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, txtb_NumLiq.Text, "CHOFERES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, chbx_VerAnulado.Checked, CBox_IncluidoEnLiquidacion.Checked)

        End If
    End Sub

    Private Sub txtb_NumLiq_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_NumLiq.KeyPress
        If iniciando = True Then 'evita una carga doble de informacion
            dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, txtb_NumLiq.Text, "CHOFERES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, chbx_VerAnulado.Checked, CBox_IncluidoEnLiquidacion.Checked)
        End If
    End Sub

    Private Sub Txb_Consecutivo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txb_Consecutivo.KeyPress
        If iniciando = True Then 'evita una carga doble de informacion
            dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, txtb_NumLiq.Text, "CHOFERES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, chbx_VerAnulado.Checked, CBox_IncluidoEnLiquidacion.Checked)
        End If
    End Sub

    Private Sub txtb_CodAgente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_CodAgente.KeyPress
        If iniciando = True Then 'evita una carga doble de informacion
            dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, txtb_NumLiq.Text, "CHOFERES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, chbx_VerAnulado.Checked, CBox_IncluidoEnLiquidacion.Checked)
        End If
    End Sub

    Private Sub chbx_VerAnulado_CheckedChanged(sender As Object, e As EventArgs) Handles chbx_VerAnulado.CheckedChanged
        If iniciando = True Then 'evita una carga doble de informacion
            dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, txtb_NumLiq.Text, "CHOFERES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, chbx_VerAnulado.Checked, CBox_IncluidoEnLiquidacion.Checked)
        End If
    End Sub

    Private Sub CBox_IncluidoEnLiquidacion_CheckedChanged(sender As Object, e As EventArgs) Handles CBox_IncluidoEnLiquidacion.CheckedChanged
        If iniciando = True Then 'evita una carga doble de informacion
            dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, txtb_NumLiq.Text, "CHOFERES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, chbx_VerAnulado.Checked, CBox_IncluidoEnLiquidacion.Checked)
        End If
    End Sub

    Private Sub dgv_Gastos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Gastos.CellDoubleClick

        Class_VariablesGlobales.FechaIni = FINI
        Class_VariablesGlobales.FechaFin = FFIN

        Class_VariablesGlobales.frmDetGastos_Choferes.Txtb_DocNum.Text = dgv_Gastos.CurrentRow.Cells.Item(0).Value
        Class_VariablesGlobales.frmDetGastos_Choferes.txb_NumDoc.Text = dgv_Gastos.CurrentRow.Cells.Item(2).Value
        Class_VariablesGlobales.frmDetGastos_Choferes.txb_Monto.Text = dgv_Gastos.CurrentRow.Cells.Item(3).Value
        Class_VariablesGlobales.frmDetGastos_Choferes.txb_Descripcion.Text = dgv_Gastos.CurrentRow.Cells.Item(4).Value
        Class_VariablesGlobales.frmDetGastos_Choferes.dtp_FechaGasto.Value = dgv_Gastos.CurrentRow.Cells.Item(7).Value
        Class_VariablesGlobales.frmDetGastos_Choferes.Lbl_Anulado.Text = dgv_Gastos.CurrentRow.Cells.Item(1).Value
        Class_VariablesGlobales.frmDetGastos_Choferes.txb_CodAgente.Text = dgv_Gastos.CurrentRow.Cells.Item(8).Value
        Class_VariablesGlobales.frmDetGastos_Choferes.Cbx_Tipo.Text = dgv_Gastos.CurrentRow.Cells.Item(1).Value

        Class_VariablesGlobales.frmDetGastos_Choferes.CBox_IncluidoEnLiquidacion.Checked = CBox_IncluidoEnLiquidacion.Checked

        'Datos para FEC
        Class_VariablesGlobales.frmDetGastos_Choferes.CBox_IncluidoEnLiquidacion.Checked = CBox_IncluidoEnLiquidacion.Checked
        If dgv_Gastos.CurrentRow.Cells.Item(10).Value = "false" Then
            Class_VariablesGlobales.frmDetGastos_Choferes.RBt_NO.Checked = True
        End If
        Try
            'si no tiene informacion del proveedor lo omite
            Class_VariablesGlobales.frmDetGastos_Choferes.txb_Codigo.Text = dgv_Gastos.CurrentRow.Cells.Item(11).Value
            Class_VariablesGlobales.frmDetGastos_Choferes.txb_Nombre.Text = dgv_Gastos.CurrentRow.Cells.Item(12).Value
            Class_VariablesGlobales.frmDetGastos_Choferes.txb_Cedula.Text = dgv_Gastos.CurrentRow.Cells.Item(13).Value
            Class_VariablesGlobales.frmDetGastos_Choferes.txb_Correo.Text = dgv_Gastos.CurrentRow.Cells.Item(14).Value
            Class_VariablesGlobales.frmDetGastos_Choferes.txtb_EstadoMH.Text = dgv_Gastos.CurrentRow.Cells.Item(15).Value
        Catch ex As Exception

        End Try
        If Trim(dgv_Gastos.CurrentRow.Cells.Item(8).Value.ToString) <> "" Then
            Class_VariablesGlobales.frmDetGastos_Choferes.txb_NomAgente.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneNameAgente(Class_VariablesGlobales.SQL_Comman1, Trim(dgv_Gastos.CurrentRow.Cells.Item(8).Value.ToString))
        End If

        Class_VariablesGlobales.frmDetGastos_Choferes.txb_Liquidacion.Text = dgv_Gastos.CurrentRow.Cells.Item(5).Value
        Class_VariablesGlobales.frmDetGastos_Choferes.Txtb_DocNum.Enabled = True
        Class_VariablesGlobales.frmDetGastos_Choferes.txb_NumDoc.Enabled = True
        Class_VariablesGlobales.frmDetGastos_Choferes.txb_Monto.Enabled = True
        Class_VariablesGlobales.frmDetGastos_Choferes.txb_Descripcion.Enabled = True
        Class_VariablesGlobales.frmDetGastos_Choferes.dtp_FechaGasto.Enabled = True
        Class_VariablesGlobales.frmDetGastos_Choferes.btn_AgElimina.Enabled = True
        Class_VariablesGlobales.frmDetGastos_Choferes.btn_Agentes.Enabled = True
        Class_VariablesGlobales.frmDetGastos_Choferes.txb_Liquidacion.Enabled = True
        Class_VariablesGlobales.frmDetGastos_Choferes.btn_GoToLiq.Enabled = True
        Class_VariablesGlobales.frmDetGastos_Choferes.Cbx_Tipo.Enabled = True


        Class_VariablesGlobales.frmDetGastos_Choferes.btn_AgGuardar.Text = "MODIFICAR"



        If dgv_Gastos.CurrentRow.Cells.Item(5).Value = "0" Then
            Class_VariablesGlobales.frmDetGastos_Choferes.btn_GoToLiq.Enabled = False
        Else
            Class_VariablesGlobales.frmDetGastos_Choferes.btn_GoToLiq.Enabled = True
        End If





        If Class_VariablesGlobales.Obj_Funciones_SQL.VerificaGastoLiqAge_Anulado(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.frmDetGastos_Choferes.Txtb_DocNum.Text) = "1" Then
            Class_VariablesGlobales.frmDetGastos_Choferes.Lbl_Anulado.Visible = True
            Class_VariablesGlobales.frmDetGastos_Choferes.Lbl_Anulado.Text = "ANULADO"
            Class_VariablesGlobales.frmDetGastos_Choferes.Lbl_Anulado.ForeColor = Color.Red
            Class_VariablesGlobales.frmDetGastos_Choferes.btn_AgElimina.Enabled = False
            Class_VariablesGlobales.frmDetGastos_Choferes.btn_AgGuardar.Enabled = False
            Class_VariablesGlobales.frmDetGastos_Choferes.btn_AgGuardar.Text = "GUARDAR"
        Else
            Class_VariablesGlobales.frmDetGastos_Choferes.Lbl_Anulado.Visible = True
            Class_VariablesGlobales.frmDetGastos_Choferes.Lbl_Anulado.Text = "GASTOS"
            Class_VariablesGlobales.frmDetGastos_Choferes.Lbl_Anulado.ForeColor = Color.Black
            Class_VariablesGlobales.frmDetGastos_Choferes.btn_AgElimina.Enabled = True
            Class_VariablesGlobales.frmDetGastos_Choferes.btn_AgGuardar.Enabled = True
            Class_VariablesGlobales.frmDetGastos_Choferes.btn_AgGuardar.Text = "MODIFICAR"
        End If

        Detalle_Gastos_Choferes.TopMost = True

        Me.Close()

    End Sub
End Class