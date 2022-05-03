Public Class Log_Manager
    Public Sub Log(Msj As String, Tipo As String)
        Try
            Dim Dir As String = ""
            Dir = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Log_SincroCliente.txt"


            My.Computer.FileSystem.WriteAllText(Dir, Now.Date & " " & Now.ToLongTimeString & ":" & Msj & vbNewLine, True)
            Dir = Nothing
        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Error Generado.txt", ex.Message & vbNewLine & ex.StackTrace, True)
        End Try
    End Sub
End Class
