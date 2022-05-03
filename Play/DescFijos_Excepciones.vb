Public Class DescFijos_Excepciones
    Public iddesc As String
    Public idExcepcion As String
    Private Sub btn_excepcion_add_Click(sender As Object, e As EventArgs) Handles btn_excepcion_add.Click

        Dim CodCliente As String = Class_VariablesGlobales.Obj_DescFijos.txb_CodCliente.Text
        Dim NombreCliente As String = Class_VariablesGlobales.Obj_DescFijos.txb_NombCliente.Text
        Dim CodProve As String = txb_Excepcion_CodProve.Text
        Dim NombreProveed As String = txb_Excepcion_NombreProveed.Text
        Dim Familia As String = cbx_Excepcion_Familia.Text
        Dim Categoria As String = cbx_Excepcion_Categoria.Text
        Dim Marca As String = cbx_Excepcion_Marca.Text
        Dim CodArti As String = txb_Excepcion_CodArti.Text
        Dim NombreArti As String = txb_Excepcion_NombreArti.Text


        Class_VariablesGlobales.Obj_Funciones_SQL.AgregaDescFijoExepciones(Class_VariablesGlobales.SQL_Comman2, iddesc, CodCliente, CodProve, NombreProveed, Familia, Categoria, Marca, CodArti, NombreArti)
        Class_VariablesGlobales.Obj_DescFijos.DGV_descFijosExepciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaExcepciones(Class_VariablesGlobales.SQL_Comman2, iddesc)
        txb_Excepcion_CodProve.Text = ""
        txb_Excepcion_NombreProveed.Text = ""
        cbx_Excepcion_Familia.Text = ""
        cbx_Excepcion_Categoria.Text = ""
        cbx_Excepcion_Marca.Text = ""
        txb_Excepcion_CodArti.Text = ""
        txb_Excepcion_NombreArti.Text = ""
    End Sub

    Private Sub btn_excepcion_Modifica_Click(sender As Object, e As EventArgs) Handles btn_excepcion_Modifica.Click

    End Sub
End Class