Public Class AplicarAumento

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click



      
        Dim TABLA As DataTable = Class_VariablesGlobales.Obj_Funciones_SQL.Login(Class_VariablesGlobales.SQL_Comman2, UsernameTextBox.Text, PasswordTextBox.Text)
        '' si no es visible de iniciar sesion
        'Consulta usuario y password y tipo de usuario

        If TABLA.Rows.Count > 0 Then
            If UsernameTextBox.Text = Trim(TABLA.Rows(0).Item("Usuario").ToString()) Then
                If PasswordTextBox.Text = Trim(TABLA.Rows(0).Item("Password").ToString()) Then
                    Class_VariablesGlobales.Puesto = TABLA.Rows(0).Item("Puesto").ToString()
                    Class_VariablesGlobales.Log_Usuario = Trim(TABLA.Rows(0).Item("Usuario").ToString())

                    'OBTIENE A TODOS LOS EMPLEADOS , LOS RECORRE Y APLICA EL AUMENTO A CADA UNO EN EL SALARIO


                    Dim contardor As Integer
                    Dim Emplead As DataTable
                    Dim SALARIO As Double = 0
                    Dim AUMENTO As Double = 0


                    ProgressBar1.Value = 0



                    Emplead = Class_VariablesGlobales.Obj_Funciones_SQL.BuscaEmpleado("", "", Class_VariablesGlobales.SQL_Comman2)


                    If Emplead.Rows.Count > 0 Then
                        ProgressBar1.Maximum = Emplead.Rows.Count
                        Lbl_Fin.Text = Emplead.Rows.Count
                        While contardor < Emplead.Rows.Count
                            ProgressBar1.Value = contardor

                            Lbl_Inicio.Text = contardor
                            Lbl_Empleado.Text = Emplead.Rows(contardor).Item("Nombre").ToString()

                            SALARIO = 0
                            SALARIO = CDbl(Emplead.Rows(contardor).Item("Salario").ToString())


                            SALARIO = SALARIO + ((SALARIO * CDbl(Class_VariablesGlobales.frmPlanilla.txtb_Aumento.Text)) / 100)


                            Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaSalarioEmpleado(Trim(Emplead.Rows(contardor).Item("Cedula").ToString()), SALARIO, Class_VariablesGlobales.SQL_Comman2)
                            contardor += 1
                        End While
                    End If




                    MsgBox("El aumento fue aplicado con exito")
                    Class_VariablesGlobales.frmPlanilla.txtb_Aumento.Text = 0
                    Me.Close()
                Else
                    MsgBox("Verifique su Contraseña P#BS")
                End If
            Else
                MsgBox("Verifique su nombre de usuario BS#")
            End If
        Else
            MsgBox("Error en su usuarios o password ,Intente nuevamente")
        End If





    End Sub

   
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

 
    Private Sub AplicarAumento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class