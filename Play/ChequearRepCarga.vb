Public Class ChequearRepCarga

  

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        FaltaPorchequear.Show()
    End Sub

    Private Sub ChequearRepCarga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Txb_CodBar.Focus()

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub


    Private Sub Txb_CodBar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txb_CodBar.TextChanged
        Try

           


            'verifica si existe un codigo de barras identido al digitado
            Dim tablas As New DataTable
            tablas = Class_VariablesGlobales.Obj_Funciones_SQL.DetLineRepCarga(Class_VariablesGlobales.SQL_Comman2, txtb_Numruta.Text, Txb_CodBar.Text)

            If tablas.Rows.Count > 0 Then
                'llama a detalle articulo

                Class_VariablesGlobales.Obj_CantiChequeada = New CantiChequeada
                Class_VariablesGlobales.Obj_CantiChequeada.MdiParent = Principal
                Class_VariablesGlobales.Obj_CantiChequeada.Show()
                '[Consecutivo],[ItemCode],[Descripcion],[Cantidad],[CodeBars],[Bodega] 



                Class_VariablesGlobales.CheqRC_Consecutivo = tablas.Rows(0).Item("Consecutivo").ToString()
                Class_VariablesGlobales.CheqRC_ItemCode = tablas.Rows(0).Item("ItemCode").ToString()
                Class_VariablesGlobales.CheqRC_Descripcion = tablas.Rows(0).Item("Descripcion").ToString()
                Class_VariablesGlobales.CheqRC_Cantidad = tablas.Rows(0).Item("Cantidad").ToString()
                Class_VariablesGlobales.CheqRC_CodeBars = tablas.Rows(0).Item("CodeBars").ToString()
                Class_VariablesGlobales.CheqRC_Bodega = tablas.Rows(0).Item("Bodega").ToString()

                Class_VariablesGlobales.Obj_CantiChequeada.txtb_codigo.Text = Class_VariablesGlobales.CheqRC_ItemCode

                Class_VariablesGlobales.Obj_CantiChequeada.txtb_Descripcion.Text = Class_VariablesGlobales.CheqRC_Descripcion

                Class_VariablesGlobales.Obj_CantiChequeada.txtb_Bodega.Text = Class_VariablesGlobales.CheqRC_Bodega
            Else
                MessageBox.Show("Codigo de barras no existe")


                Txb_CodBar.Text = ""

            End If

        Catch ex As Exception

            MessageBox.Show("Error Txb_CodBar_TextChanged")

        End Try
    End Sub


    Private Sub Dtg_Chequeado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dtg_Chequeado.CellContentClick
        Class_VariablesGlobales.ConseRepCarga = txtb_Numruta.Text
        Class_VariablesGlobales.CodArti = Dtg_Chequeado.Item(0, Dtg_Chequeado.CurrentRow.Index).Value.ToString()

        EditaRepCarga.Show()
    End Sub

    Private Sub ChequearRepCarga_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                FaltaPorchequear.Show()


        End Select
    End Sub
End Class