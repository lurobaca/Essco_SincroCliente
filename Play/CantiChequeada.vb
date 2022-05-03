Public Class CantiChequeada
    Dim hacertap As Boolean = False
    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_Cantidad.KeyPress

        If hacertap = False Then



            If e.KeyChar = ChrW(Keys.Enter) Then
                If txtb_Faltante.Text = "" Then
                    txtb_Faltante.Text = "0"
                End If
                If txtb_Cantidad.Text = "" Then
                    txtb_Cantidad.Text = "0"
                End If

                Dim valor1 As String = ""
                Dim valor2 As String = ""
                Dim Operacion As String = ""

                For n = 0 To Len(txtb_Cantidad.Text) - 1
                    If txtb_Cantidad.Text.Chars(n) <> "+" And txtb_Cantidad.Text.Chars(n) <> "*" And Operacion = "" Then
                        valor1 &= txtb_Cantidad.Text.Chars(n)
                    Else

                        If Operacion = "" Then
                            Operacion = txtb_Cantidad.Text.Chars(n)
                        Else
                            valor2 &= txtb_Cantidad.Text.Chars(n)
                        End If

                    End If

                Next n

                If Operacion <> "" Then


                    If Operacion = "+" Then
                        txtb_Cantidad.Text = CInt(valor1) + CInt(valor2)
                    ElseIf Operacion = "*" Then
                        txtb_Cantidad.Text = CInt(valor1) * CInt(valor2)
                    End If


                End If

                If CInt(txtb_Cantidad.Text) + CInt(txtb_Faltante.Text) = CInt(Class_VariablesGlobales.CheqRC_Cantidad) Then
                    Button1.Focus()
                Else




                    If CInt(txtb_Cantidad.Text) + CInt(txtb_Faltante.Text) > CInt(Class_VariablesGlobales.CheqRC_Cantidad) Then
                        MessageBox.Show("Sobran [ " & Int(txtb_Cantidad.Text) + CInt(txtb_Faltante.Text) - CInt(Class_VariablesGlobales.CheqRC_Cantidad) & " ]")
                    Else
                        hacertap = True
                        'e.Handled = True
                        'SendKeys.Send("{TAB}")


                    End If


                End If



            End If
        Else
            hacertap = False
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If
    End Sub

    Private Sub txtb_Faltante_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtb_Faltante.TextChanged
        If txtb_Faltante.Text <> "" Then
            Cmb_Motivo.Enabled = True
        Else
            Cmb_Motivo.Enabled = False
        End If

    End Sub

    Private Sub CantiChequeada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        If txtb_Faltante.Text = "" Then
            txtb_Faltante.Text = "0"
        End If

        'VERIFICA QUE DIGITE LA CANTIDAD CORRECTA
        If CInt(txtb_Cantidad.Text) = CInt(Class_VariablesGlobales.CheqRC_Cantidad) Or CInt(Class_VariablesGlobales.CheqRC_Cantidad) = CInt(txtb_Cantidad.Text) + CInt(txtb_Faltante.Text) Then

            Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaRepCarga(Class_VariablesGlobales.SQL_Comman2, Class_VariablesGlobales.CheqRC_Consecutivo, Class_VariablesGlobales.CheqRC_ItemCode, txtb_Cantidad.Text, txtb_Faltante.Text, Cmb_Motivo.Text, Class_VariablesGlobales.Log_Usuario)
            Class_VariablesGlobales.Obj_ChequearRepCarga.Txb_CodBar.Text = ""
            Class_VariablesGlobales.Obj_ChequearRepCarga.Txb_CodBar.Focus()


            Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_Diferencia.Text = "0"
            Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_TotalChequeo.Text = "0"

            Class_VariablesGlobales.Obj_ChequearRepCarga.Dtg_Chequeado.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.LineaRepCachequeado(Class_VariablesGlobales.SQL_Comman2, Class_VariablesGlobales.CheqRC_Consecutivo)
            Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_TotalChequeo.Text = Format(Val(Class_VariablesGlobales.Obj_Funciones_SQL.SumaChequeadoRepCarga(Class_VariablesGlobales.CheqRC_Consecutivo, Class_VariablesGlobales.SQL_Comman2)), "currency")


            Dim TChequeado As Double = CDbl(Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_TotalChequeo.Text)


            Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_Diferencia.Text = Format(Val(CDbl(Class_VariablesGlobales.Obj_ChequearRepCarga.lbl_TotalRuta.Text) - TChequeado), "currency")

           

            Me.Close()
        Else
            'la cantidad o la suma de cantidad mas faltante no es correcta muestr amensaje
            If CInt(txtb_Cantidad.Text) + CInt(txtb_Faltante.Text) < CInt(Class_VariablesGlobales.CheqRC_Cantidad) Then

                MessageBox.Show("Faltan [ " & CInt(Class_VariablesGlobales.CheqRC_Cantidad) - Int(txtb_Cantidad.Text) + CInt(txtb_Faltante.Text) & " ]")
                txtb_Cantidad.Focus()
                txtb_Cantidad.Text = ""
                txtb_Faltante.Text = ""
            Else
                MessageBox.Show("Sobran [ " & Int(txtb_Cantidad.Text) + CInt(txtb_Faltante.Text) - CInt(Class_VariablesGlobales.CheqRC_Cantidad) & " ]")
                txtb_Cantidad.Focus()
                txtb_Cantidad.Text = ""
                txtb_Faltante.Text = ""

            End If


        End If





    End Sub

    Private Sub txtb_Faltante_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_Faltante.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")


        End If
    End Sub

    

    Private Sub txtb_Faltante_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtb_Faltante.MouseClick
        txtb_Faltante.Text = ""

    End Sub

    Private Sub txtb_Cantidad_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtb_Cantidad.MouseClick
        txtb_Cantidad.Text = ""
    End Sub

    Private Sub Cmb_Motivo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cmb_Motivo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")


        End If
    End Sub

    Private Sub CantiChequeada_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim Proceso As New Process()
                Proceso.StartInfo.FileName = "calc.exe"
                Proceso.StartInfo.Arguments = ""
                Proceso.Start()


        End Select
    End Sub
End Class