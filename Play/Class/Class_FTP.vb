'Option Strict On
'Option Infer On

Imports System.Net.FtpWebRequest
Imports System.Data.SqlClient
Imports System
Imports System.Net
Imports System.IO
Imports System.Text

Public Class Class_FTP


    Public Function ConectarFTP(ByVal user As String, ByVal clave As String)

    End Function

    Public Function Subir(ByVal RutaOrigen As String, ByVal RutaFTP As String, ByVal user As String, ByVal clave As String)
        Try
            Dim clsRequest As System.Net.FtpWebRequest
            'Dim conexion As Net.Sockets.TcpClient
            'ConectaFTP()
            clsRequest = DirectCast(System.Net.WebRequest.Create(RutaFTP), System.Net.FtpWebRequest)
            clsRequest.Proxy = Nothing ' Esta asignación es importantisimo con los que trabajen en windows XP ya que por defecto esta propiedad esta para ser asignado a un servidor http lo cual ocacionaria un error si deseamos conectarnos con un FTP, en windows Vista y el Seven no tube este problema.

            clsRequest.Credentials = New System.Net.NetworkCredential(user, clave) ' Usuario y password de acceso al server FTP, si no tubiese, dejar entre comillas, osea ""
            'tiempo de espera de una peticion
            clsRequest.Timeout = 15000

            'el metodo es para SUBIR A FTP
            clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

            Try
                Dim bFile() As Byte = System.IO.File.ReadAllBytes(RutaOrigen)
                Dim clsStream As System.IO.Stream = clsRequest.GetRequestStream()
                clsStream.Write(bFile, 0, bFile.Length)
                clsStream.Close()
            Catch ex As Exception

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK)

                ' ERRORES = "[ " & Now & " ] ERROR Subir  [ " & ex.Message & " ] RUTA [ " & RutaFTP & " ])"
            End Try


            clsRequest.Abort()
            clsRequest = Nothing

            Return 0
        Catch ex As Exception
            ' ERRORES = "[ " & Now & " ] ERROR Subir ( " & ex.Message & " )"
        End Try

        Return 0
    End Function

    Public Function eliminarFichero(ByVal fichero As String, ByVal user As String, ByVal pass As String) As String
        Try


            Dim peticionFTP As FtpWebRequest

            ' Creamos una petición FTP con la dirección del fichero a eliminar
            peticionFTP = CType(WebRequest.Create(New Uri(fichero)), FtpWebRequest)
            peticionFTP.Timeout = 60000
            ' Fijamos el usuario y la contraseña de la petición
            peticionFTP.Credentials = New NetworkCredential(user, pass)

            ' Seleccionamos el comando que vamos a utilizar: Eliminar un fichero
            peticionFTP.Method = WebRequestMethods.Ftp.DeleteFile
            peticionFTP.UsePassive = False

            Try
                Dim respuestaFTP As FtpWebResponse
                respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
                respuestaFTP.Close()
                peticionFTP = Nothing
                respuestaFTP = Nothing
                ' Si todo ha ido bien, devolvemos String.Empty
                Return 0
            Catch ex As Exception
                ' Si se produce algún fallo, se devolverá el mensaje del error
                Return 1
            End Try

            peticionFTP = Nothing
        Catch ex As Exception
            Return 1
            ' ERRORES = "[ " & Now & " ] ERROR eliminarFichero( " & ex.Message & " )"
        End Try
    End Function

  Public Function existeObjeto(ByVal dir As String, ByVal user As String, ByVal pass As String) As Boolean
    Try


      Dim peticionFTP As FtpWebRequest

      ' Creamos una peticion FTP con la dirección del objeto que queremos saber si existe
      peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)
      peticionFTP.Timeout = 60000
      ' Fijamos el usuario y la contraseña de la petición
      peticionFTP.Credentials = New NetworkCredential(user, pass)

      ' Para saber si el objeto existe, solicitamos la fecha de creación del mismo
      peticionFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp
      'peticionFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails


      peticionFTP.UsePassive = False

      Try
        ' Dim RespuestaFTP2 As New StreamReader(peticionFTP.GetResponse().GetResponseStream())
        ' Si el objeto existe, se devolverá True
        Dim respuestaFTP As FtpWebResponse


                ' If Reiniciando = True Then
                'peticionFTP.Abort()
                'peticionFTP = Nothing
                'Else
                respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
                ' End If

                Return True
                respuestaFTP = Nothing
            Catch ex As Exception
                ' Si el objeto no existe, se producirá un error y al entrar por el Catch
                ' se devolverá falso
                Return False
            End Try




            peticionFTP = Nothing


    Catch ex As Exception

            ' ERRORES = "[ " & Now & " ] ERROR existeObjeto( " & ex.Message & " )"
    End Try
  End Function




    ' no esta en uso
    Public Function creaDirectorio(ByVal dir As String, ByVal user As String, ByVal pass As String) As String
        Try
            Dim peticionFTP As FtpWebRequest

            ' Creamos una peticion FTP con la dirección del directorio que queremos crear
            peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

            ' Fijamos el usuario y la contraseña de la petición
            peticionFTP.Credentials = New NetworkCredential(user, pass)

            ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
            peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory


            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            ' ERRORES = "[ " & Now & " ] ERROR EN creaDirectorio [ " & ex.Message & " ]"
            Return ex.Message
        End Try


  End Function


 

End Class
