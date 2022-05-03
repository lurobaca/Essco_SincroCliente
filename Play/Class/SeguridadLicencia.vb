Public Class SeguridadLicencia
    Public Function Encripta(ByVal fecha As String)

        Dim contador As Integer = 0
        Dim fechasCodificada As String = ""


      
        For x = 0 To Len(fecha) - 1


            If fecha.Chars(x).ToString = "0" Then
                fechasCodificada = fechasCodificada + "0"
            End If




            If fecha.Chars(x) = "/" Then
                fechasCodificada = fechasCodificada + "9"
            End If
            If fecha.Chars(x) = "1" Then
                fechasCodificada = fechasCodificada + "A"
            End If
            If fecha.Chars(x) = "2" Then
                fechasCodificada = fechasCodificada + "B"
            End If
            If fecha.Chars(x) = "3" Then
                fechasCodificada = fechasCodificada + "C"
            End If
            If fecha.Chars(x) = "4" Then
                fechasCodificada = fechasCodificada + "D"
            End If
            If fecha.Chars(x) = "5" Then
                fechasCodificada = fechasCodificada + "E"
            End If
            If fecha.Chars(x) = "6" Then
                fechasCodificada = fechasCodificada + "F"
            End If
            If fecha.Chars(x) = "7" Then
                fechasCodificada = fechasCodificada + "G"
            End If
            If fecha.Chars(x) = "8" Then
                fechasCodificada = fechasCodificada + "H"
            End If
            If fecha.Chars(x) = "9" Then
                fechasCodificada = fechasCodificada + "I"
            End If
            If x = 4 Then
                fechasCodificada = fechasCodificada + "-"
            End If
            If x = 5 Then
                fechasCodificada = fechasCodificada + "M"
            End If



         Next
        Return fechasCodificada
    End Function

    Public Function DesEncripta(ByVal Datos As String)

        Dim cadena As String
        Dim n As Integer
        Dim Caracter As String
        Dim FechaVencimiento As String

        For n = 0 To Len(Datos) - 1
            Caracter = Datos.Chars(n)

            If Caracter = "0" Then
                FechaVencimiento = FechaVencimiento & "0"
            End If
            If Caracter = "9" Then
                FechaVencimiento = FechaVencimiento & "/"
            End If
            If Caracter = "A" Then
                FechaVencimiento = FechaVencimiento & "1"
            End If
            If Caracter = "B" Then
                FechaVencimiento = FechaVencimiento & "2"
            End If
            If Caracter = "C" Then
                FechaVencimiento = FechaVencimiento & "3"
            End If
            If Caracter = "D" Then
                FechaVencimiento = FechaVencimiento & "4"
            End If
            If Caracter = "E" Then
                FechaVencimiento = FechaVencimiento & "5"
            End If
            If Caracter = "F" Then
                FechaVencimiento = FechaVencimiento & "6"
            End If
            If Caracter = "G" Then
                FechaVencimiento = FechaVencimiento & "7"
            End If
            If Caracter = "H" Then
                FechaVencimiento = FechaVencimiento & "8"
            End If
            If Caracter = "I" Then
                FechaVencimiento = FechaVencimiento & "9"
            End If

            If Caracter = "-" Then

            End If
            If Caracter = "M" Then

            End If


        Next n

        Return FechaVencimiento
    End Function
End Class
