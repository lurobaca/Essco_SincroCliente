Public Class ClaveParametros
    Dim claveCorrecta As Boolean = False
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txb_ClaveParametro.Text = "Admin" Then

            claveCorrecta = True

            Class_VariablesGlobales.frmEnviar_Info_Seller.RadioButton2.Enabled = True
            Class_VariablesGlobales.frmEnviar_Info_Seller.RadioButton1.Enabled = True
            Class_VariablesGlobales.frmEnviar_Info_Seller.CBX_Param.Enabled = True
            Class_VariablesGlobales.frmEnviar_Info_Seller.ChBox_ClientexDia.Enabled = True

        Else
            Class_VariablesGlobales.frmEnviar_Info_Seller.RadioButton2.Enabled = False
            Class_VariablesGlobales.frmEnviar_Info_Seller.RadioButton1.Enabled = False
            Class_VariablesGlobales.frmEnviar_Info_Seller.CBX_Param.Enabled = False
            Class_VariablesGlobales.frmEnviar_Info_Seller.ChBox_ClientexDia.Enabled = False

            Class_VariablesGlobales.frmEnviar_Info_Seller.RadioButton1.Checked = True
            Class_VariablesGlobales.frmEnviar_Info_Seller.RadioButton2.Checked = False
            Class_VariablesGlobales.frmEnviar_Info_Seller.CBX_Param.Checked = False
            MsgBox("Clave incorrecta vuelve a intertarlo")


        End If
        Me.Close()
    End Sub

    Private Sub ClaveParametros_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If claveCorrecta = False Then
            Class_VariablesGlobales.frmEnviar_Info_Seller.CBX_Param.Checked = False
        End If

    End Sub

    Private Sub ClaveParametros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
     
    End Sub
End Class