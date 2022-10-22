Imports System.Net
Imports System.Security.Principal

Public Class InforComputadora
    Public Function ObtnerIP()
        Dim IpPC = ""

        Dim direcciones As IPAddress()
        Try


            direcciones = Dns.GetHostAddresses(Dns.GetHostName())


            IpPC = direcciones(1).ToString()
        Catch ex As Exception
            ' MsgBox("Error en ObtnerIP [" + ex.Message + " : " + direcciones.ToString() + "]")
        End Try
        Return IpPC
    End Function



    Public Function ObtenerUsuarioWindows()
        Dim UsuarioWindows As String = ""
        Try


            Dim currentUser As WindowsIdentity = WindowsIdentity.GetCurrent()


            Console.WriteLine(currentUser.User.Value)
            UsuarioWindows = currentUser.Name

        Catch ex As Exception
            MsgBox("Error en ObtenerUsuarioWindows [" + ex.Message + "]")
        End Try
        Return UsuarioWindows
    End Function


End Class
