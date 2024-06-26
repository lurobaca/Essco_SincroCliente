Public Class FechaManager


    Public Function FormatFechaSqlite(ByVal Fecha As String)
        Dim DiaActual As String = (Fecha).Substring(0, 2).ToString()
        Dim MesActual As String = (Fecha).Substring(3, 2).ToString()
        Dim AnoActual As String = (Fecha).Substring(6, 4).ToString()

        Fecha = AnoActual + "/" + MesActual + "/" + DiaActual

        Return Fecha
    End Function

    Public Function FormatFechaMostrar(ByVal Fecha As String)

        Dim AnoActual As String = (Fecha).Substring(0, 4).ToString()
        Dim MesActual As String = (Fecha).Substring(5, 2).ToString()
        Dim DiaActual As String = (Fecha).Substring(8, 2).ToString()

        Fecha = DiaActual + "/" + MesActual + "/" + AnoActual

        Return Fecha
    End Function



    Public Function FormatoFechaSql(ByVal Fecha As String)
        Dim DiaActual As String = (Fecha).Substring(0, 2).ToString()
        Dim MesActual As String = (Fecha).Substring(3, 2).ToString()
        Dim AnoActual As String = (Fecha).Substring(6, 4).ToString()

        Fecha = AnoActual + "-" + MesActual + "-" + DiaActual

        Return Fecha
    End Function

    Public Function Dias(ByVal inicio As String, ByVal llegada As String)

        Dim Diasv As Integer = 0
        Dim Meses As Integer = 0
        Dim anos As Integer = 0

        Dim DiaActual As Integer = (inicio).Substring(0, 2).ToString()
        Dim MesActual As Integer = (inicio).Substring(3, 2).ToString()
        Dim AnoActual As Integer = (inicio).Substring(6, 4).ToString()


        Dim DiaVenc As Integer = (llegada).Substring(0, 2).ToString()
        Dim MesVenc As Integer = (llegada).Substring(3, 2).ToString()
        Dim AnoVenc As Integer = (llegada).Substring(6, 4).ToString()


        Diasv += (AnoVenc - AnoActual) * 360
        Diasv += (MesVenc - MesActual) * 30
        Diasv += DiaVenc - DiaActual



        Return Diasv
    End Function

    Public Function ObtieneMes(Fecha As String)
        Dim Mes As Integer = (Fecha).Substring(3, 2).ToString()

        Return ObtieneDescripcionMes(Mes)
    End Function

    Public Function ObtieneDescripcionMes(IdMes As Integer)
        If IdMes = 1 Then
            Return "Enero"
        End If
        If IdMes = 2 Then
            Return "Febrero"
        End If
        If IdMes = 3 Then
            Return "Marzo"
        End If
        If IdMes = 4 Then
            Return "Abril"
        End If
        If IdMes = 5 Then
            Return "Mayo"
        End If
        If IdMes = 6 Then
            Return "Junio"
        End If
        If IdMes = 7 Then
            Return "Julio"
        End If
        If IdMes = 8 Then
            Return "Agosto"
        End If
        If IdMes = 9 Then
            Return "Setiembre"
        End If
        If IdMes = 10 Then
            Return "Octubre"
        End If
        If IdMes = 11 Then
            Return "Noviembre"
        End If
        If IdMes = 12 Then
            Return "Diciembre"
        End If
    End Function

End Class
