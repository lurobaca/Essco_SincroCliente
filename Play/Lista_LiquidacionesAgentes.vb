
Public Class Lista_LiquidacionesAgentes

    Private Sub Lista_LiquidacionesAgentes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLiquidaciones(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.TipoLiqui, "", "", "")
    End Sub

    Private Sub DGV_Liquidaciones_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_Liquidaciones.CellClick
        Try

            Class_VariablesGlobales.CREANDO_LIQ_AGENTE = False
            '[Cosecutivo],[Fecha],[CodAgente],[CedulaAgente],[NombreAgente],[FechaINI],[FechaFIN],[Comentarios],[Tipo]
            Class_VariablesGlobales.frmLiqAge.btn_Guardar.Text = "MODIFICAR"
            Class_VariablesGlobales.NumLiqui = DGV_Liquidaciones.CurrentRow.Cells.Item(0).Value
            Class_VariablesGlobales.frmLiqAge.txtb_Consecutivo.Text = DGV_Liquidaciones.CurrentRow.Cells.Item(0).Value
            Class_VariablesGlobales.frmLiqAge.txtb_CodAgente.Text = DGV_Liquidaciones.CurrentRow.Cells.Item(2).Value
            Class_VariablesGlobales.frmLiqAge.txtb_Cedula.Text = DGV_Liquidaciones.CurrentRow.Cells.Item(3).Value
            Class_VariablesGlobales.frmLiqAge.txtb_NombreAgente.Text = DGV_Liquidaciones.CurrentRow.Cells.Item(4).Value
            Class_VariablesGlobales.frmLiqAge.dtp_FechaIni.Value = DGV_Liquidaciones.CurrentRow.Cells.Item(5).Value
            Class_VariablesGlobales.frmLiqAge.dtp_FechaFin.Value = DGV_Liquidaciones.CurrentRow.Cells.Item(6).Value
            Class_VariablesGlobales.frmLiqAge.txtb_Comentarios.Text = DGV_Liquidaciones.CurrentRow.Cells.Item(7).Value

            Class_VariablesGlobales.frmLiqAge.btn_Cargar_Click(sender, e)
            'verifica si esta anulada
            If DGV_Liquidaciones.CurrentRow.Cells.Item(9).Value = "1" Then
                Class_VariablesGlobales.frmLiqAge.btn_Anular.Enabled = False
                Class_VariablesGlobales.frmLiqAge.TabControl1.Enabled = False
                Class_VariablesGlobales.Agente = Class_VariablesGlobales.frmLiqAge.txtb_CodAgente.Text
                Class_VariablesGlobales.frmLiqAge.btn_Cargar.Enabled = False
                Class_VariablesGlobales.frmLiqAge.dtp_FechaIni.Enabled = False
                Class_VariablesGlobales.frmLiqAge.dtp_FechaFin.Enabled = False

                'Class_VariablesGlobales.frmLiqAge.btn_Guardar.Enabled = False
                Class_VariablesGlobales.frmLiqAge.btn_Imprimir.Enabled = True
                Class_VariablesGlobales.frmLiqAge.lbl_Anulado.Visible = True
                Class_VariablesGlobales.frmLiqAge.txtb_Diferencias.Enabled = False
                Class_VariablesGlobales.frmLiqAge.txtb_Comentarios.Enabled = False

            Else
                Class_VariablesGlobales.frmLiqAge.lbl_Anulado.Visible = False
                Class_VariablesGlobales.frmLiqAge.btn_Anular.Enabled = True
                Class_VariablesGlobales.frmLiqAge.lbl_Anulado.Visible = False
                Class_VariablesGlobales.frmLiqAge.TabControl1.Enabled = True
                Class_VariablesGlobales.Agente = Class_VariablesGlobales.frmLiqAge.txtb_CodAgente.Text
                Class_VariablesGlobales.frmLiqAge.btn_Cargar.Enabled = True
                Class_VariablesGlobales.frmLiqAge.dtp_FechaIni.Enabled = True
                Class_VariablesGlobales.frmLiqAge.dtp_FechaFin.Enabled = True

                'Class_VariablesGlobales.frmLiqAge.btn_Guardar.Enabled = False
                Class_VariablesGlobales.frmLiqAge.btn_Imprimir.Enabled = True
                Class_VariablesGlobales.frmLiqAge.txtb_Comentarios.Enabled = True
            End If

            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DGV_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLiquidaciones(Class_VariablesGlobales.SQL_Comman1, "AGENTES", dtp_Desde.Value, dtp_Hasta.Value, txtb_NumLiq.Text)
    End Sub


    Private Sub dtp_Desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_Desde.ValueChanged
        DGV_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLiquidaciones(Class_VariablesGlobales.SQL_Comman1, "AGENTE", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_Desde.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_Hasta.Value.Date), "")
    End Sub
    Private Sub dtp_Hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_Hasta.ValueChanged
        DGV_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLiquidaciones(Class_VariablesGlobales.SQL_Comman1, "AGENTE", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_Desde.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_Hasta.Value.Date), "")

    End Sub

    Private Sub txtb_NumLiq_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtb_NumLiq.TextChanged
        dtp_Desde.Value = Now.Date
        dtp_Hasta.Value = Now.Date
        DGV_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLiquidaciones(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", "", txtb_NumLiq.Text)




    End Sub

  

   
  
   
End Class