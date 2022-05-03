Public Class Class_Sonar
    Dim Obj_Mail As New Class_MAIL

    Public Function Sonar(ByVal RutaAudio As String, ByVal Ag As String)
        Try


            My.Computer.Audio.Play(RutaAudio, AudioPlayMode.Background)
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Asterisk)

            System.Threading.Thread.Sleep(15000)
            'luego de indicar que hay pedidos nuevos cambia el estado
            Class_VariablesGlobales.Obj_Funciones_SQL.Actualiza_Estado_Alerta(Ag, Class_VariablesGlobales.SQL_Comman)
            'Obj_Mail.EnviarCorreo("lurobaca@gmail.com", "Clave de activacion [   ]")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return 0
    End Function
End Class
