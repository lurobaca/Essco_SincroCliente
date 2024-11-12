Public Class ListaDePrecios
    Private Sub Btn_Guardar_Click(sender As Object, e As EventArgs) Handles Btn_Guardar.Click
        If Btn_Guardar.Text = "Guardar" Then
            VariablesGlobales.Obj_SQL.GuardaListaPrecio(Class_VariablesGlobales.SQL_Comman2, Txtb_IdListaPrecio.Text, txtb_Nombre.Text, True)
        Else
            VariablesGlobales.Obj_SQL.GuardaListaPrecio(Class_VariablesGlobales.SQL_Comman2, Txtb_IdListaPrecio.Text, txtb_Nombre.Text, False)
        End If

        Limpiar()
        MessageBox.Show("El registro fue guardado con exito")
    End Sub

    Private Sub btn_Inactivar_Click(sender As Object, e As EventArgs) Handles btn_Inactivar.Click
        If Txtb_Estado.Text = "0" Then
            VariablesGlobales.Obj_SQL.InactivarListaPrecio(Class_VariablesGlobales.SQL_Comman2, Txtb_IdListaPrecio.Text, 1)
        Else
            VariablesGlobales.Obj_SQL.InactivarListaPrecio(Class_VariablesGlobales.SQL_Comman2, Txtb_IdListaPrecio.Text, 0)
        End If
        MessageBox.Show("Se cambio de estado correctamente")
        Limpiar()
    End Sub

    Private Sub ListaDePrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
    End Sub

    Public Function Limpiar()
        Txtb_IdListaPrecio.Text = ""
        Txtb_Nombre.Text = ""

        DGV_ListaDePrecios.DataSource = VariablesGlobales.Obj_SQL.ObtieneListaPrecios(Class_VariablesGlobales.SQL_Comman2, "")
        Lbl_Inactivar.Visible = False
    End Function

    Private Sub DGV_ListaDePrecios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_ListaDePrecios.CellContentClick
        Btn_Guardar.Text = "Modifiar"
        Txtb_IdListaPrecio.Text = DGV_ListaDePrecios.CurrentRow.Cells.Item(0).Value
        Txtb_Nombre.Text = DGV_ListaDePrecios.CurrentRow.Cells.Item(1).Value
        Txtb_Estado.Text = DGV_ListaDePrecios.CurrentRow.Cells.Item(2).Value
        If Txtb_Estado.Text = "1" Then
            btn_Inactivar.Text = "Activar"

            Lbl_Inactivar.Visible = True
        Else
            btn_Inactivar.Text = "Inactivar"
            Lbl_Inactivar.Visible = False
        End If


    End Sub
End Class