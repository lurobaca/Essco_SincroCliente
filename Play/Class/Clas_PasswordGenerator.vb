Public Class Clas_PasswordGenerator


    Public Function GenerateCode()
        Dim strInputString As String = "1234567890abcdefghijklmnopqrstuvwxyz" 'these are the characters which will be in the password

        Dim intLength As Integer = Len(strInputString)

        Dim intNameLength As Integer = 7 'edit this according to how long u want ur password to be

        Randomize() ' jus to make it random :D

        Dim strName As String = ""
        Dim intRnd As Integer
        For intStep = 1 To intNameLength
            intRnd = Int((intLength * Rnd()) + 1)

            strName = strName & Mid(strInputString, intRnd, 1)
        Next

        GenerateCode = strName
    End Function

   
End Class
