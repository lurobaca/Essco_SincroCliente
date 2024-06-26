Public Class ClassPlanilla
    Dim ObjFecha As New FechaManager
    Public Function ObtenerDescripcion(FechaIni As String, FechaFin As String)

        Try

            Dim Mes1 As String
            Dim Mes2 As String


            Mes1 = ObjFecha.ObtieneMes(FechaIni)
            Mes2 = ObjFecha.ObtieneMes(FechaFin)

            Dim DiaFinalQuincena As Integer = (FechaFin).Substring(0, 2).ToString()


            If (Mes1.Equals(Mes2)) Then
                If DiaFinalQuincena <= 15 Then
                    Return "Primer quincena del mes de  " & Mes1
                Else
                    Return "Segunda quincena del mes de  " & Mes1
                End If

            End If

        Catch ex As Exception
            MsgBox("Error al obtener una descripción [" & ex.Message & "] ", MsgBoxStyle.Critical)
        End Try

    End Function
End Class
