Imports MySql.Data.MySqlClient
Imports System.Data.Odbc
Public Class CONEXION_TO_MYSQL
    Dim CN As New OdbcConnection
    Dim WithEvents t As New System.Timers.Timer(750)
  'Dim ipAdres As String = "69.162.154.57"
  'Dim MyDatabase As String = "arquitect_bourne"
  'Dim myprot As String = "3307"
  'Dim user As String = "arquitect_bourne"
  'Dim clave As String = "SoporteBourne2013"

  'Dim ipAdres As String = XMLParamMYSQL_Server
  'Dim MyDatabase As String = XMLParamMYSQL_MyDatabase
  'Dim myprot As String = XMLParamMYSQL_myport
  'Dim user As String = XMLParamMYSQL_userWEB
  'Dim clave As String = XMLParamMYSQL_claveWEB

  Public Function Conectar() As OdbcConnection
    Try
            CN = New OdbcConnection

            'CN.ConnectionString = "Dsn=BourneDB_WEB;server=69.162.154.57;uid=arquitect_bourne;pwd=SoporteBourne2013;database=arquitect_bourne;port=3307"
            CN.ConnectionString = "Dsn=" & Class_VariablesGlobales.XMLParamMYSQL_DsnWEB &
                                  ";server=" & Class_VariablesGlobales.XMLParamMYSQL_Server &
                                  ";uid=" & Class_VariablesGlobales.XMLParamMYSQL_userWEB &
                                  ";pwd=" & Class_VariablesGlobales.XMLParamMYSQL_claveWEB &
                                  ";database=" & Class_VariablesGlobales.XMLParamMYSQL_MyDatabase &
                                  ";port=" & Class_VariablesGlobales.XMLParamMYSQL_myport



            ' Dsn=BourneDB_WEB;server=69.162.154.57;uid=arquitect_bourne;pwd=SoporteBourne2013;database=arquitect_bourne;port=3307
            If CN.State = ConnectionState.Closed Then
        CN.Open()

      End If

        Catch ex As Exception
            'Desconectar()
            'Conectar()
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR Conectar mysql( No se pudo establecer conexion MYSQL" & ex.Message & " )"
        End Try

        Return CN
    End Function

    Public Sub Desconectar(ByVal CN As OdbcConnection)
        Try
            If Not CN.State = ConnectionState.Closed Then
                CN.Close()
                CN = Nothing
                Class_VariablesGlobales.MYSQ_Comman.Connection.Close()
                Class_VariablesGlobales.SQL_Comman = Nothing
            End If


        Catch ex As Exception
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR Desconectar mysql( No se pudo establecer conexion MYSQL" & ex.Message & " )"
        End Try
    End Sub



End Class
