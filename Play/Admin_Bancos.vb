Public Class Admin_Bancos

    Public Obj_SQL_CONEXIONSERVER As New Class_funcionesSQL

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Obj_SQL_CONEXIONSERVER.Inserta_Banco(Class_VariablesGlobales.SQL_Comman2, txtb_Codigo.Text, txtb_Nombre.Text, txtb_Cuenta.Text)

        DGV_Bancos.DataSource = (Obj_SQL_CONEXIONSERVER.ObtieneBancosEssco(Class_VariablesGlobales.SQL_Comman2))

    End Sub

    Private Sub btn_Eliminar_Click(sender As Object, e As EventArgs) Handles btn_Eliminar.Click
        Obj_SQL_CONEXIONSERVER.EliminaBancosEssco(Class_VariablesGlobales.SQL_Comman2, txtb_Codigo.Text)
    End Sub

    Private Sub Admin_Bancos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGV_Bancos.DataSource = (Obj_SQL_CONEXIONSERVER.ObtieneBancosEssco(Class_VariablesGlobales.SQL_Comman2))
    End Sub

    Public Function limpiar()
        txtb_Codigo.Text = ""
        txtb_Nombre.Text = ""
        txtb_Cuenta.Text = ""

    End Function
End Class