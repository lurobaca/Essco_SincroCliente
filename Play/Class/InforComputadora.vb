Imports System.Net
Imports System.Security.Principal

Public Class InforComputadora
    Public Function ObtnerIP()
        Dim direcciones As IPAddress() = Dns.GetHostAddresses(Dns.GetHostName())
        Dim IpPC = ""

        IpPC = direcciones(5).ToString()

        Return IpPC
    End Function



    Public Function ObtenerUsuarioWindows()

        Dim currentUser As WindowsIdentity = WindowsIdentity.GetCurrent()
        Dim UsuarioWindows As String = ""

        Console.WriteLine(currentUser.User.Value)
        UsuarioWindows = currentUser.Name

        Return UsuarioWindows
    End Function


End Class
