Public Class Reactivacion

    Dim Obj_SQL_CONEXION As New Class_funcionesSQL

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click



        'encripta la clave digitada , luego la guarda en la Base de datos 
        Obj_SQL_CONEXION.ActualizaClaveReactivacion(Crypto.Encrypt(Now.Date, "A"), Class_VariablesGlobales.SQL_Comman2)
        MsgBox("Reactivacion exitosa")


        Me.Close()

    End Sub

    Private Sub Reactivacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class