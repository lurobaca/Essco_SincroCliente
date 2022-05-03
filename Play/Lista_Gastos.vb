Public Class Lista_Gastos
    Public iniciando As Boolean = False

    Dim FINI As String
    Dim FFIN As String

    Private Sub Lista_Gastos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Detalle_Gastos.TopMost = False

        FINI = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Desde.Value.Date.AddDays(-30))
        FFIN = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Hasta.Value.Date)
        DTP_Desde.Value = FINI

        If Class_VariablesGlobales.NumGastoBuscando <> "" Then
            Txb_NumGasto.Text = Class_VariablesGlobales.NumGastoBuscando
            dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.LIQUIDANDO, "", txtb_CodAgente.Text, FINI, FFIN, Class_VariablesGlobales.NumGastoBuscando, Class_VariablesGlobales.ConseGastoBuscando, False, CBox_IncluidoEnLiquidacion.Checked)
        ElseIf Class_VariablesGlobales.ConseGastoBuscando <> "" Then
            Txb_NumGasto.Text = Class_VariablesGlobales.ConseGastoBuscando
            dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.LIQUIDANDO, "", txtb_CodAgente.Text, FINI, FFIN, Class_VariablesGlobales.NumGastoBuscando, Class_VariablesGlobales.ConseGastoBuscando, False, CBox_IncluidoEnLiquidacion.Checked)
        Else
            If Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION" Then
                dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.TipoLiqui, Class_VariablesGlobales.TituloDetalleGasto, Class_VariablesGlobales.Agente, FINI, FFIN, Class_VariablesGlobales.NumGastoBuscando, Class_VariablesGlobales.ConseGastoBuscando, False, CBox_IncluidoEnLiquidacion.Checked)
            Else
                dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.LIQUIDANDO, "", txtb_CodAgente.Text, FINI, FFIN, Class_VariablesGlobales.NumGastoBuscando, Class_VariablesGlobales.ConseGastoBuscando, True, CBox_IncluidoEnLiquidacion.Checked)
            End If
        End If


        iniciando = True
    End Sub



    Private Sub dgv_Gastos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_Gastos.CellClick

    End Sub

    Private Sub btn_BuscaAgente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaAgente.Click
        If Class_VariablesGlobales.LIQUIDANDO = "AGENTES" Then
            Class_VariablesGlobales.Lista_llamadaDesde = "LISTAGASTOS"


            Class_VariablesGlobales.Obj_ListaAgentes = New ListaAgentes
            Class_VariablesGlobales.Obj_ListaAgentes.MdiParent = Principal
            Class_VariablesGlobales.Obj_ListaAgentes.Puesto = "AGENTE"
            Class_VariablesGlobales.Obj_ListaAgentes.Show()

        Else
            Class_VariablesGlobales.Lista_llamadaDesde = "LISTAGASTOS"
            ListaChoferes.Show()
        End If

    End Sub

    Private Sub DTP_Desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_Desde.ValueChanged
        If iniciando = True Then 'evita una carga doble de informacion
            FINI = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Desde.Value.Date)
            FFIN = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Hasta.Value.Date)
            If Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION" Then
                dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, False, CBox_IncluidoEnLiquidacion.Checked)
            Else
                dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, True, CBox_IncluidoEnLiquidacion.Checked)
            End If
        End If
    End Sub

    Private Sub DTP_Hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_Hasta.ValueChanged
        If iniciando = True Then 'evita una carga doble de informacion
            FINI = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Desde.Value.Date)
            FFIN = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Hasta.Value.Date)



            If Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION" Then
                dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, False, CBox_IncluidoEnLiquidacion.Checked)
            Else
                dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, True, CBox_IncluidoEnLiquidacion.Checked)
            End If


            'If Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION" Then
            '    dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastos(Class_VariablesGlobales.SQL_Comman1, "", "AGENTES", "", txtb_CodAgente.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Desde.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Hasta.Value.Date), "", "", False)
            'Else
            '    dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastos(Class_VariablesGlobales.SQL_Comman1, "", "AGENTES", "", txtb_CodAgente.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Desde.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Hasta.Value.Date), "", "", True)
            'End If
        End If
        ' , , "", "", Txb_Consecutivo.Text, "", "DPCONSECUTIVO"
    End Sub



    Private Sub Txb_NumGasto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_NumGasto.TextChanged
        If iniciando = True Then 'evita una carga doble de informacion
            'txtb_CodAgente.Text = ""
            'Txb_Consecutivo.Text = ""
            If Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION" Then
                dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, False, CBox_IncluidoEnLiquidacion.Checked)
            Else
                dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, True, CBox_IncluidoEnLiquidacion.Checked)
            End If
        End If
    End Sub

    Private Sub Txb_Consecutivo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_Consecutivo.TextChanged
        'Txb_NumGasto.Text = ""
        If iniciando = True Then 'evita una carga doble de informacion
            If Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION" Then
                dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, False, CBox_IncluidoEnLiquidacion.Checked)
            Else
                dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, True, CBox_IncluidoEnLiquidacion.Checked)
            End If
        End If
    End Sub

    Private Sub txtb_CodAgente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtb_CodAgente.TextChanged
        If iniciando = True Then 'evita una carga doble de informacion
            If Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION" Then
                dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, False, CBox_IncluidoEnLiquidacion.Checked)
            Else
                dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, True, CBox_IncluidoEnLiquidacion.Checked)
            End If
        End If
    End Sub

    Private Sub Lista_Gastos_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Detalle_Gastos.TopMost = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Txb_NumGasto.Text = ""
        Txb_Consecutivo.Text = ""
        txtb_CodAgente.Text = ""
        DTP_Desde.Value = Now.Date
        DTP_Hasta.Value = Now.Date
        FINI = ""
        FFIN = ""

        If Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION" Then
            dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, False, CBox_IncluidoEnLiquidacion.Checked)
        Else
            dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, True, CBox_IncluidoEnLiquidacion.Checked)
        End If
    End Sub

    Private Sub Txb_Consecutivo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txb_Consecutivo.KeyPress
        If iniciando = True Then 'evita una carga doble de informacion


            If Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION" Then
                dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, False, CBox_IncluidoEnLiquidacion.Checked)
            Else
                dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, True, CBox_IncluidoEnLiquidacion.Checked)
            End If

        End If
    End Sub
    Private Sub Txb_NumGasto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txb_NumGasto.KeyPress
        If iniciando = True Then 'evita una carga doble de informacion
            If Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION" Then
                dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, False, CBox_IncluidoEnLiquidacion.Checked)
            Else
                dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, True, CBox_IncluidoEnLiquidacion.Checked)
            End If
        End If
    End Sub

    Private Sub txtb_CodAgente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_CodAgente.KeyPress
        If iniciando = True Then 'evita una carga doble de informacion
            If Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION" Then
                dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, False, CBox_IncluidoEnLiquidacion.Checked)
            Else
                dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, True, CBox_IncluidoEnLiquidacion.Checked)
            End If
        End If
    End Sub



    'Private Sub chbx_VerAnulado_CheckedChanged(sender As Object, e As EventArgs) Handles chbx_VerAnulado.CheckedChanged

    '    If iniciando = True Then 'evita una carga doble de informacion
    '        dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, chbx_VerAnulado.Checked, CBox_IncluidoEnLiquidacion.Checked)

    '    End If
    'End Sub

    Private Sub CBox_IncluidoEnLiquidacion_CheckedChanged(sender As Object, e As EventArgs) Handles CBox_IncluidoEnLiquidacion.CheckedChanged
        If iniciando = True Then 'evita una carga doble de informacion
            dgv_Gastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosAgentes(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", txtb_CodAgente.Text, FINI, FFIN, Txb_NumGasto.Text, Txb_Consecutivo.Text, chbx_VerAnulado.Checked, CBox_IncluidoEnLiquidacion.Checked)

        End If
    End Sub

    Private Sub dgv_Gastos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Gastos.CellDoubleClick

        Class_VariablesGlobales.frmDetGastos.Txtb_DocNum.Text = dgv_Gastos.CurrentRow.Cells.Item(0).Value
        Class_VariablesGlobales.frmDetGastos.txb_NumDoc.Text = dgv_Gastos.CurrentRow.Cells.Item(2).Value
        Class_VariablesGlobales.frmDetGastos.txb_Monto.Text = dgv_Gastos.CurrentRow.Cells.Item(3).Value
        Class_VariablesGlobales.frmDetGastos.txb_Descripcion.Text = dgv_Gastos.CurrentRow.Cells.Item(4).Value
        Class_VariablesGlobales.frmDetGastos.dtp_FechaGasto.Value = dgv_Gastos.CurrentRow.Cells.Item(7).Value
        Class_VariablesGlobales.frmDetGastos.Lbl_Anulado.Text = dgv_Gastos.CurrentRow.Cells.Item(1).Value
        Class_VariablesGlobales.frmDetGastos.Cbx_Tipo.Text = dgv_Gastos.CurrentRow.Cells.Item(1).Value
        Class_VariablesGlobales.frmDetGastos.txb_CodAgente.Text = dgv_Gastos.CurrentRow.Cells.Item(8).Value
        Class_VariablesGlobales.frmDetGastos.CBox_IncluidoEnLiquidacion.Checked = CBox_IncluidoEnLiquidacion.Checked
        If dgv_Gastos.CurrentRow.Cells.Item(10).Value = "false" Then
            Class_VariablesGlobales.frmDetGastos.RBt_NO.Checked = True
        End If

        Try
            'si no tiene informacion del proveedor lo omite

            Class_VariablesGlobales.frmDetGastos.txb_Codigo.Text = dgv_Gastos.CurrentRow.Cells.Item(11).Value
            Class_VariablesGlobales.frmDetGastos.txb_Nombre.Text = dgv_Gastos.CurrentRow.Cells.Item(12).Value
            Class_VariablesGlobales.frmDetGastos.txb_Cedula.Text = dgv_Gastos.CurrentRow.Cells.Item(13).Value
            Class_VariablesGlobales.frmDetGastos.txb_Correo.Text = dgv_Gastos.CurrentRow.Cells.Item(14).Value
            Class_VariablesGlobales.frmDetGastos.txtb_EstadoMH.Text = dgv_Gastos.CurrentRow.Cells.Item(15).Value
        Catch ex As Exception

        End Try
        If Trim(dgv_Gastos.CurrentRow.Cells.Item(8).Value.ToString) <> "" Then
            Class_VariablesGlobales.frmDetGastos.txb_NomAgente.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneNameAgente(Class_VariablesGlobales.SQL_Comman1, Trim(dgv_Gastos.CurrentRow.Cells.Item(8).Value.ToString))
        End If

        Class_VariablesGlobales.frmDetGastos.txb_Liquidacion.Text = dgv_Gastos.CurrentRow.Cells.Item(5).Value
        Class_VariablesGlobales.frmDetGastos.Txtb_DocNum.Enabled = True
        Class_VariablesGlobales.frmDetGastos.txb_NumDoc.Enabled = True
        Class_VariablesGlobales.frmDetGastos.txb_Monto.Enabled = True
        Class_VariablesGlobales.frmDetGastos.txb_Descripcion.Enabled = True
        Class_VariablesGlobales.frmDetGastos.dtp_FechaGasto.Enabled = True
        Class_VariablesGlobales.frmDetGastos.btn_AgElimina.Enabled = True
        Class_VariablesGlobales.frmDetGastos.btn_Agentes.Enabled = True
        Class_VariablesGlobales.frmDetGastos.txb_Liquidacion.Enabled = True
        Class_VariablesGlobales.frmDetGastos.btn_GoToLiq.Enabled = True
        Class_VariablesGlobales.frmDetGastos.Cbx_Tipo.Enabled = True

        Class_VariablesGlobales.frmDetGastos.btn_AgGuardar.Text = "MODIFICAR"

        If dgv_Gastos.CurrentRow.Cells.Item(5).Value = "0" Then
            Class_VariablesGlobales.frmDetGastos.btn_GoToLiq.Enabled = False
        Else
            Class_VariablesGlobales.frmDetGastos.btn_GoToLiq.Enabled = True
        End If

        If Class_VariablesGlobales.Obj_Funciones_SQL.VerificaGastoLiqAge_Anulado(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.frmDetGastos.Txtb_DocNum.Text) = "1" Then
            Class_VariablesGlobales.frmDetGastos.Lbl_Anulado.Visible = True
            Class_VariablesGlobales.frmDetGastos.Lbl_Anulado.Text = "ANULADO"
            Class_VariablesGlobales.frmDetGastos.Lbl_Anulado.ForeColor = Color.Red
            Class_VariablesGlobales.frmDetGastos.btn_AgElimina.Enabled = False
            Class_VariablesGlobales.frmDetGastos.btn_AgGuardar.Enabled = False
            Class_VariablesGlobales.frmDetGastos.btn_AgGuardar.Text = "GUARDAR"
        Else
            Class_VariablesGlobales.frmDetGastos.Lbl_Anulado.Visible = True
            Class_VariablesGlobales.frmDetGastos.Lbl_Anulado.Text = "GASTOS"
            Class_VariablesGlobales.frmDetGastos.Lbl_Anulado.ForeColor = Color.Black
            Class_VariablesGlobales.frmDetGastos.btn_AgElimina.Enabled = True
            Class_VariablesGlobales.frmDetGastos.btn_AgGuardar.Enabled = True
            Class_VariablesGlobales.frmDetGastos.btn_AgGuardar.Text = "MODIFICAR"
        End If

        Me.Close()

    End Sub
End Class