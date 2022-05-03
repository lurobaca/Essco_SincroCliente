Public Class FaltaPorchequear

    Private Sub FaltaPorchequear_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                MsgBox("Has pulsado F1")
            Case Keys.F3
                MsgBox("Has pulsado F3")
        End Select
    End Sub

    Private Sub FaltaPorchequear_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dtg_Chequeado.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepCarXSector("NOCHEQUEADO", "TODOS", Class_VariablesGlobales.CheqRC_Consecutivo, Class_VariablesGlobales.SQL_Comman2, "")
    End Sub

    Private Sub Dtg_Chequeado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dtg_Chequeado.CellContentClick

        Try

        


            Class_VariablesGlobales.Obj_CantiChequeada = New CantiChequeada
            Class_VariablesGlobales.Obj_CantiChequeada.MdiParent = Principal
            Class_VariablesGlobales.Obj_CantiChequeada.Show()
            '[Consecutivo],[ItemCode],[Descripcion],[Cantidad],[CodeBars],[Bodega] 

            '[Consecutivo],[Chequeado],[ItemCode],[Descripcion],[sector],[Cantidad],[Total],[CodeBars],[Bodega],[Bodeguero],[Faltante],[Motivo],[Chequeador],[Faltante_Chequeador],[Motivo_Chequeador],[FacINI],[FacFIN],[Ruta],[Fecha],[Hora],[Cajas],[Cerrado],[ConB1],[Anulado],[U_Gramaje],[Subido],[Unidades_x_Caja],[Marca] 

            Class_VariablesGlobales.CheqRC_Consecutivo = Dtg_Chequeado.Item(0, Dtg_Chequeado.CurrentRow.Index).Value.ToString()
            Class_VariablesGlobales.CheqRC_ItemCode = Dtg_Chequeado.Item(2, Dtg_Chequeado.CurrentRow.Index).Value.ToString()
            Class_VariablesGlobales.CheqRC_Descripcion = Dtg_Chequeado.Item(3, Dtg_Chequeado.CurrentRow.Index).Value.ToString()
            Class_VariablesGlobales.CheqRC_Cantidad = Dtg_Chequeado.Item(5, Dtg_Chequeado.CurrentRow.Index).Value.ToString()
            Class_VariablesGlobales.CheqRC_CodeBars = Dtg_Chequeado.Item(7, Dtg_Chequeado.CurrentRow.Index).Value.ToString()
            Class_VariablesGlobales.CheqRC_Bodega = Dtg_Chequeado.Item(8, Dtg_Chequeado.CurrentRow.Index).Value.ToString()

            Class_VariablesGlobales.Obj_CantiChequeada.txtb_codigo.Text = Class_VariablesGlobales.CheqRC_ItemCode

            Class_VariablesGlobales.Obj_CantiChequeada.txtb_Descripcion.Text = Class_VariablesGlobales.CheqRC_Descripcion

            Class_VariablesGlobales.Obj_CantiChequeada.txtb_Bodega.Text = Class_VariablesGlobales.CheqRC_Bodega

            Me.Close()

        Catch ex As Exception

        End Try


    End Sub
End Class