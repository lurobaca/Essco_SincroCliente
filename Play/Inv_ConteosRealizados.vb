Public Class Inv_ConteosRealizados
    Private Sub Inv_ConteosRealizados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtb_IdInventario.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneIdInventario()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Grupo As String = ""
        Dim Conteo As String = ""
        For Each c As Char In txt_Grupo.Text

            If Char.IsLetter(c) Then
                Grupo = Grupo & Char.ToUpper(c)
            Else
                Conteo = Conteo & Char.ToUpper(c)
            End If
        Next

        dGv_Control.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConteoRealizado(txtb_IdInventario.Text, Grupo, Conteo, Txb_Proveedor.Text.Trim, TXT_Codigo.Text, txtb_Descripcion.Text)

        ' [CodProveedor],[CodArticulo],[Descripcion],[Cuenta],[Apuntes]

        dGv_Control.Columns(0).Width = 50
        dGv_Control.Columns(1).Width = 100
        dGv_Control.Columns(2).Width = 250
        dGv_Control.Columns(3).Width = 50
        dGv_Control.Columns(4).Width = 350

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Class_VariablesGlobales.ListaGruposLlamadoDesde = "Inv_ConteosRealizados"
        Class_VariablesGlobales.frmLista_GruposConteo = New Inv_Lista_GruposConteo
        Class_VariablesGlobales.frmLista_GruposConteo.MdiParent = Principal
        Class_VariablesGlobales.frmLista_GruposConteo.Show()
    End Sub
End Class