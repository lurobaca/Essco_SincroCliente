Imports System.Threading

Public Class Planilla_AplicarAumento

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If UsernameTextBox.Text = "" Then
            MsgBox("Debe indicar un usuario valido antes de aplicar el aumento")
            Exit Sub
        End If
        If PasswordTextBox.Text = "" Then
            MsgBox("Debe indicar una contrasea valida antes de aplicar el aumento")
            Exit Sub
        End If
        If txtb_Aumento.Text = "" Or txtb_Aumento.Text = "0" Then
            MsgBox("Debe indicar el porcentaje de aumento antes de aplicar el aumento")
            Exit Sub
        End If

        If TxtBox_MotivoAumento.Text = "" Then
            MsgBox("Debe indicar el motivo antes de aplicar el aumento")
            Exit Sub
        End If
        Dim TABLA As DataTable = Class_VariablesGlobales.Obj_Funciones_SQL.Login(Class_VariablesGlobales.SQL_Comman2, UsernameTextBox.Text, PasswordTextBox.Text)
        If TABLA.Rows.Count > 0 Then
            If UsernameTextBox.Text <> Trim(TABLA.Rows(0).Item("Usuario").ToString()) Then
                MsgBox("Verifique su nombre de usuario ")
                Exit Sub
            End If

            If PasswordTextBox.Text <> Trim(TABLA.Rows(0).Item("Password").ToString()) Then
                MsgBox("Verifique su Contraseña ")
                Exit Sub
            End If

        Else
            MsgBox("Error en su usuarios o password ,Intente nuevamente")
            Exit Sub
        End If

        Class_VariablesGlobales.Puesto = TABLA.Rows(0).Item("Puesto").ToString()
        Class_VariablesGlobales.Log_Usuario = Trim(TABLA.Rows(0).Item("Usuario").ToString())



        Dim result As DialogResult = MessageBox.Show("ESTA A PUNTO DE GENERAR UN AUMENTO EN LA PLANILLA, ESTE CAMBIO NO SE PODRA REVERSAR\n ¿DESEA APLICAR EL INCREMENTO?",
                          "Alerta",
                          MessageBoxButtons.YesNo)

        If (result = DialogResult.Yes) Then
            ' Crear un nuevo hilo y pasarle el método que deseas ejecutar
            Dim tr As New Thread(AddressOf AplicarAumento)
            ' Iniciar el hilo
            tr.Start()
        Else
        End If

    End Sub

    Public Function AplicarAumento()
        Try


            'OBTIENE A TODOS LOS EMPLEADOS , LOS RECORRE Y APLICA EL AUMENTO A CADA UNO EN EL SALARIO
            Dim contardor As Integer
            Dim Emplead As DataTable

            Dim UsuarioCrea As String
            Dim Cedula_Empleado As String
            Dim SalarioAnterior As Double
            Dim SalarioPosterior As Double
            Dim Fecha As String
            Dim PorcentajeAumento As Double
            Dim MontoAumento As Double
            Dim MotivoAumento As String = TxtBox_MotivoAumento.Text

            ProgressBar1.Value = 0

            Emplead = Class_VariablesGlobales.Obj_Funciones_SQL.BuscaEmpleado("", "", Class_VariablesGlobales.SQL_Comman2)


            If Emplead.Rows.Count > 0 Then
                ProgressBar1.Maximum = Emplead.Rows.Count
                Lbl_Fin.Text = Emplead.Rows.Count
                While contardor < Emplead.Rows.Count
                    ProgressBar1.Value = contardor

                    Lbl_Inicio.Text = contardor
                    Lbl_Empleado.Text = Emplead.Rows(contardor).Item("Nombre").ToString()

                    PorcentajeAumento = 0
                    Cedula_Empleado = ""
                    UsuarioCrea = Class_VariablesGlobales.Log_Usuario
                    SalarioAnterior = 0
                    SalarioPosterior = 0
                    Fecha = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Now.Date.ToShortDateString())

                    MontoAumento = 0

                    PorcentajeAumento = CDbl(txtb_Aumento.Text)
                    Cedula_Empleado = Emplead.Rows(contardor).Item("Cedula").ToString()
                    SalarioAnterior = CDbl(Emplead.Rows(contardor).Item("Salario").ToString())
                    MontoAumento = ((SalarioAnterior * PorcentajeAumento) / 100)
                    SalarioPosterior = SalarioAnterior + MontoAumento

                    Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaSalarioEmpleado(Cedula_Empleado, SalarioPosterior, Class_VariablesGlobales.SQL_Comman2)

                    'Se registra el aumento del empleado

                    Class_VariablesGlobales.Obj_Funciones_SQL.RegistraActualizaSalarioEmpleado(Cedula_Empleado,
                                                                                               SalarioAnterior,
                                                                                               SalarioPosterior,
                                                                                               Fecha,
                                                                                               PorcentajeAumento,
                                                                                               MontoAumento,
                                                                                               MotivoAumento,
                                                                                               UsuarioCrea,
                                                                                               Class_VariablesGlobales.SQL_Comman2)
                    contardor += 1
                End While
            End If

            MsgBox("El aumento fue aplicado con exito")

            Me.Close()

        Catch ex As Exception

        End Try
    End Function
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub


    Private Sub AplicarAumento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class