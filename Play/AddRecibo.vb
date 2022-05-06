Public Class AddRecibo
    'Public Obj_SAP As New SAP_BUSSINES_ONE

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_NumRecibo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
          


            txtb_NumRecibo.Focus()
        End If
    End Sub



    Private Sub btn_Agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Agregar.Click
        If Trim(txtb_NumRecibo.Text) <> "" Then
            'PRIMERO VERIFICAMOS QUE EL RECIBO NO ESTE LIGADO A NINGUNA LIQUIDACION
            ' SI ESTA LIGADO MANDA UN MENSAJE INDICANDO LA LIQUIDACION Y EL CHOFER AL CUAL ESTA LIGADO EL RECIBO
            ' SI NO ESTA LIGADO SOLO AGREGA EL RECIBO A LA LIQUIDACION ACTUAL

            Dim Respuesta As String
            Respuesta = Class_VariablesGlobales.Obj_Funciones_SQL.ReciboConLiquidacion(Trim(txtb_NumRecibo.Text), Class_VariablesGlobales.SQL_Comman1)

          


            If Respuesta <> "" Then
                If IsDate(Respuesta) Then

                    'verifica si esta dentro del rango de la liquidacion y de paso advertira si no esta dentro del rango ya que si no esta no aparesera en la liqudacion
                    If CDate(Respuesta) < Class_VariablesGlobales.frmLiqChof.dtp_FechaIni_Recibos.Value Or Class_VariablesGlobales.frmLiqChof.dtp_FechaFin_Recibos.Value > CDate(Respuesta) Then

                        Respuesta = "EL RECIBO TIENE FECHA [" & Respuesta & "] ESTA FUERA DEL RANGO [" & Class_VariablesGlobales.frmLiqChof.dtp_FechaIni_Recibos.Value & "] - [" & Class_VariablesGlobales.frmLiqChof.dtp_FechaFin_Recibos.Value & "] DE LA LIQUIDACION, ESTO IMPEDIRA VER EL RECIBO " & vbCr & " ESTA SEGURO QUE DESEA AGREGAR? " & vbCr
                    Else
                        Respuesta = ""
                    End If
                Else

                End If

                If Respuesta = "" Then
                    If Class_VariablesGlobales.frmLiqChof.btn_Guardar.Text = "GUARDAR" Then
                        'Obj_SAP.ActualizaPago(Trim(txtb_NumRecibo.Text), Trim(Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text), "")
                    Else
                        'Obj_SAP.ActualizaPago(Trim(txtb_NumRecibo.Text), Trim(Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text), CInt(Class_VariablesGlobales.frmLiqChof.txtb_Consecutivo.Text))
                    End If
                    Class_VariablesGlobales.frmLiqChof.Cargar()
                    txtb_NumRecibo.Text = ""
                Else
                    Dim result As Integer = MessageBox.Show(Respuesta, "caption", MessageBoxButtons.YesNo)

                    If result = DialogResult.No Then

                    ElseIf result = DialogResult.Yes Then
                        If Class_VariablesGlobales.frmLiqChof.btn_Guardar.Text = "GUARDAR" Then
                            'Obj_SAP.ActualizaPago(Trim(txtb_NumRecibo.Text), Trim(Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text), "")
                        Else
                            'Obj_SAP.ActualizaPago(Trim(txtb_NumRecibo.Text), Trim(Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text), CInt(Class_VariablesGlobales.frmLiqChof.txtb_Consecutivo.Text))
                        End If

                        Class_VariablesGlobales.frmLiqChof.Cargar()
                        txtb_NumRecibo.Text = ""
                    End If
                End If

               






            Else
                If Class_VariablesGlobales.frmLiqChof.btn_Guardar.Text = "GUARDAR" Then
                    'Obj_SAP.ActualizaPago(Trim(txtb_NumRecibo.Text), Trim(Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text), "")
                Else
                    'Obj_SAP.ActualizaPago(Trim(txtb_NumRecibo.Text), Trim(Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text), CInt(Class_VariablesGlobales.frmLiqChof.txtb_Consecutivo.Text))
                End If
                Class_VariablesGlobales.frmLiqChof.Cargar()
                txtb_NumRecibo.Text = ""
            End If


            Respuesta = Nothing


        Else
            MsgBox("Debe agregar un numero de recibo")

        End If
        txtb_NumRecibo.Focus()


    End Sub

    Private Sub btn_Quitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Quitar.Click
        If Trim(txtb_NumRecibo.Text) <> "" Then
            'Obj_SAP.ActualizaPago(Trim(txtb_NumRecibo.Text), "01", "0")
            Class_VariablesGlobales.frmLiqChof.Cargar()
            txtb_NumRecibo.Text = ""
        Else
            MsgBox("Debe agregar un numero de recibo")

        End If
        txtb_NumRecibo.Focus()
    End Sub
End Class