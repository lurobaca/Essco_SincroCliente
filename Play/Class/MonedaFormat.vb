Public Class MonedaFormat
    Public Function FormatoMoneda(ByVal Monto As String)
        Monto = String.Format("{0:#,##0.00}", Monto)

        'si emiesa con un parentesis quiere decir que es un valor negativo
        If Monto.StartsWith("(") Then

            'elimina el primer parentesis
            Monto = Monto.Substring(1)

            Monto = Monto.Substring(0, Monto.Length - 1)
            Monto = "-" & Monto


        End If
        Return FormatNumber(Monto, 2)
    End Function
End Class
