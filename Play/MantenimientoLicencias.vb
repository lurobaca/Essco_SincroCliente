Imports System.Security.Cryptography

Public Class MantenimientoLicencias




    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Me.Close()

    End Sub

    Private Sub btn_aceptar_Click(sender As Object, e As EventArgs) Handles btn_aceptar.Click
        Dim Tipo As Integer
        If CBox_Mensual.Checked Then
            Tipo = 0
        Else
            Tipo = 1
        End If
        Class_VariablesGlobales.Obj_Funciones_SQL.GUARDA_Licencias(Txtb_Total.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Desde.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_Hasta.Value.Date), Tipo.ToString, Txtb_Dias.Text, Class_VariablesGlobales.SQL_Comman)



    End Sub


    Sub TestEncoding()
        Dim plainText As String = InputBox("Enter the plain text:")
        Dim password As String = InputBox("Enter the password:")

        Dim wrapper As New Simple3Des(password)
        Dim cipherText As String = wrapper.EncryptData(plainText)

        MsgBox("The cipher text is: " & cipherText)
        My.Computer.FileSystem.WriteAllText(
            My.Computer.FileSystem.SpecialDirectories.MyDocuments &
            "\cipherText.txt", cipherText, False)
    End Sub
    Sub TestDecoding()
        Dim cipherText As String = My.Computer.FileSystem.ReadAllText(
        My.Computer.FileSystem.SpecialDirectories.MyDocuments &
            "\cipherText.txt")
        Dim password As String = InputBox("Enter the password:")
        Dim wrapper As New Simple3Des(password)

        ' DecryptData throws if the wrong password is used.
        Try
            Dim plainText As String = wrapper.DecryptData(cipherText)
            MsgBox("The plain text is: " & plainText)
        Catch ex As System.Security.Cryptography.CryptographicException
            MsgBox("The data could not be decrypted with the password.")
        End Try
    End Sub
    Private Sub MantenimientoLicencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TestEncoding()
        TestDecoding()
    End Sub
End Class