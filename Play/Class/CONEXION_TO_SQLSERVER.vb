Imports System.Data
Imports System.Data.SqlClient

Public Class CONEXION_TO_SQLSERVER
    Dim CNX As SqlConnection = Nothing
    Dim user As String = "sa"
    Dim clave As String = "Bourn3"
    Dim dababase As String
    Dim server As String = "SAP"
    Dim StrimConexion As String
    Dim Ejecutar As SqlCommand

    Public Function Conectar(ByVal dababase As String, ByVal CNX As SqlConnection) As SqlConnection
        Try
            StrimConexion = "Data Source=" & Class_VariablesGlobales.XMLParamSQL_server & ";Initial Catalog=" & Class_VariablesGlobales.XMLParamSQL_dababase & ";Persist Security Info=True;User ID=" & Class_VariablesGlobales.XMLParamSQL_user & ";Password=" & Class_VariablesGlobales.XMLParamSQL_clave & ";MultipleActiveResultSets=True"
            CNX = New SqlConnection(StrimConexion)
            If CNX.State = ConnectionState.Closed Then
                CNX.Open()
                Return CNX
            End If
        Catch ex As Exception
            'Desconectar()
            'Conectar(dababase)
            ' ERRORES = "[ " & Now & " ] ERROR Conectar SQL(No se pudo establecer conexion SQL " & ex.Message & " )"

        End Try
        Return CNX
    End Function

    Public Sub Desconectar(ByRef SQL_Comman As SqlCommand)
        Try
            If SQL_Comman IsNot Nothing Then

                If SQL_Comman.Connection.State = ConnectionState.Open Then
                    SQL_Comman.Connection.Close()
                    SQL_Comman.Connection.Dispose()
                    SQL_Comman.Connection = Nothing
                    SQL_Comman.Dispose()
                    SQL_Comman = Nothing
                End If

            End If
        Catch ex As Exception
            'ERRORES = "[ " & Now & " ] ERROR Desconectar SQL (" & ex.Message & " )"
        End Try
    End Sub


End Class
