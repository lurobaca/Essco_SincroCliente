Imports System.Data.SqlClient

Public Class LoginForm1

    Dim id As String = ""
    'Dim Usuario As String = "BestSoft1989"
    'Dim Password As String = "PasT1989BestSoft"
    Dim Obj_SQL_CONEXION_CONEXION As New CONEXION_TO_SQLSERVER
    Public Objt_GlobalVar As Class_VariablesGlobales


    ' TODO: inserte el código para realizar autenticación personalizada usando el nombre de usuario y la contraseña proporcionada 
    ' (Consulte http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' El objeto principal personalizado se puede adjuntar al objeto principal del subproceso actual como se indica a continuación: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' donde CustomPrincipal es la implementación de IPrincipal utilizada para realizar la autenticación. 
    ' Posteriormente, My.User devolverá la información de identidad encapsulada en el objeto CustomPrincipal
    ' como el nombre de usuario, nombre para mostrar, etc.
    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Objt_GlobalVar = New Class_VariablesGlobales()
            ' Dim objVClas As Class_VarGlobales
            ' objVClas = New Class_VarGlobales
            'obtiene datos de coneczion del archivo XML
#Disable Warning BC42025 ' Acceso del miembro compartido, el miembro de constante, el miembro de enumeración o el tipo anidado a través de una instancia
            If (Objt_GlobalVar.Obj_Clas_XML.ConexionSAP() = 1) Then
#Enable Warning BC42025 ' Acceso del miembro compartido, el miembro de constante, el miembro de enumeración o el tipo anidado a través de una instancia
                Me.Close()
            Else

            End If

            Dim CNX_2 As New SqlConnection
            Try

                If Objt_GlobalVar.SQL_Comman2.Connection.State = ConnectionState.Closed Then
                    CNX_2 = Obj_SQL_CONEXION_CONEXION.Conectar(Objt_GlobalVar.XMLParamSQL_dababase, CNX_2)
                    Objt_GlobalVar.SQL_Comman2.Connection = CNX_2
                End If
            Catch ex As Exception
                CNX_2 = Obj_SQL_CONEXION_CONEXION.Conectar(Objt_GlobalVar.XMLParamSQL_dababase, CNX_2)
                Objt_GlobalVar.SQL_Comman2.Connection = CNX_2
            End Try

        Catch ex As Exception
            MsgBox("ERROR LoginForm1_Load : " & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        Try
            Dim ip = Objt_GlobalVar.Obj_InforComputadora.ObtnerIP()
            Dim UsuarioWindows = Objt_GlobalVar.Obj_InforComputadora.ObtenerUsuarioWindows()

            'si la confirmacion de password es visible debe verificar que sean iguales y modificar la contraseña
            If Txtb_NuevoPass.Visible = True Then

                If Txtb_NuevoPass.Text = Txtb_ConfirmaPass.Text Then

                    Objt_GlobalVar.Obj_Funciones_SQL.ModificaUsuario(Objt_GlobalVar.SQL_Comman2, UsernameTextBox.Text, Txtb_NuevoPass.Text, "", "", "", id, "")

                    PasswordTextBox.Text = Txtb_NuevoPass.Text
                    lbl_NuevoPass.Visible = False
                    Txtb_NuevoPass.Visible = False

                    lbl_ConfirmaPass.Visible = False
                    Txtb_ConfirmaPass.Visible = False
                    OK_Click(sender, e)

                Else
                    MsgBox("Contraseñas no son iguales , intente nuevamente")
                End If
            Else


                Dim TABLA As DataTable = Objt_GlobalVar.Obj_Funciones_SQL.Login(Objt_GlobalVar.SQL_Comman2, UsernameTextBox.Text, PasswordTextBox.Text)
                '' si no es visible de iniciar sesion
                'Consulta usuario y password y tipo de usuario

                If TABLA.Rows.Count > 0 Then

                    If UsernameTextBox.Text = Trim(TABLA.Rows(0).Item("Usuario").ToString()) Then
                        If PasswordTextBox.Text = Trim(TABLA.Rows(0).Item("Password").ToString()) Then
                            Objt_GlobalVar.Puesto = TABLA.Rows(0).Item("Puesto").ToString()
                            Objt_GlobalVar.Log_Usuario = Trim(TABLA.Rows(0).Item("Usuario").ToString())
                            Objt_GlobalVar.Id_Usuario = Trim(TABLA.Rows(0).Item("id").ToString())

                            Objt_GlobalVar.IP = ip
                            Objt_GlobalVar.UsuarioWindows = UsuarioWindows
                            id = Trim(TABLA.Rows(0).Item("id").ToString())

                            If (Trim(TABLA.Rows(0).Item("SesionIniciada").ToString()).Equals("1") And Trim(TABLA.Rows(0).Item("Usuario").ToString()) <> "Manager") Then
                                'El usuario ya se encuentra logueado
                                MsgBox("El usuario ya se encuentra con una sesión activa, cierre todas las sesiones he inténtelo de nuevo")
                                Exit Sub

                            End If

                            If Trim(TABLA.Rows(0).Item("Cambiar").ToString()) = "1" Then
                                    lbl_NuevoPass.Visible = True
                                    Txtb_NuevoPass.Visible = True

                                    lbl_ConfirmaPass.Visible = True
                                    Txtb_ConfirmaPass.Visible = True
                                Else
                                    'Registrar inicio de sesion
                                    Objt_GlobalVar.Obj_Funciones_SQL.RegistrarInicioSesion(Objt_GlobalVar.SQL_Comman2, Objt_GlobalVar.Log_Usuario, Objt_GlobalVar.IP, Objt_GlobalVar.UsuarioWindows, "Inicio Sesión")
                                    Objt_GlobalVar.Obj_Funciones_SQL.IndicaSesionActiva(Objt_GlobalVar.SQL_Comman2, TABLA.Rows(0).Item("id").ToString(), 1)


                                    Me.Hide()
                                    Principal.Show()
                                    If VariablesGlobales.CerroSesion = False Then
                                        Class_VariablesGlobales.frmPrincipal = Principal

                                    Else
                                        VariablesGlobales.CerroSesion = False
                                        Class_VariablesGlobales.frmPrincipal.Inicializar()
                                    End If

                                    Class_VariablesGlobales.frmPrincipal.Text = Class_VariablesGlobales.frmPrincipal.Text & " Ususario: " & Objt_GlobalVar.Log_Usuario & "Usuario SAP:" & Class_VariablesGlobales.XMLParamSAP_UserName


                                End If

                            Else
                                MsgBox("Verifique su Contraseña P#BS")
                        End If
                    Else
                        MsgBox("Verifique su nombre de usuario BS#")
                    End If
                Else
                    MsgBox("Error en su usuarios o password ,Intente nuevamente")
                End If


            End If

        Catch ex As Exception
            MsgBox("Error al iniciar sesion " & ex.Message)
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub


End Class
