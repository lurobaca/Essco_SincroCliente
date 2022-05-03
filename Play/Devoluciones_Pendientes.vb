Public Class Devoluciones_Pendientes

    Private Sub NotasPendientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        Carga("")
    End Sub



    Private Sub txtb_Nota_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_Nota.KeyPress
        Carga(txtb_Nota.Text)
    End Sub

    Public Function Carga(ByVal Nota As String)
        Try


            DataGridView1.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDevolucionesPendientes(Nota, Trim(Cmb_Ver.Text), Trim(txtb_CodAgente.Text), Class_VariablesGlobales.SQL_Comman1)





            DataGridView1.Columns(0).Width = 80
            DataGridView1.Columns(1).Width = 80
            DataGridView1.Columns(2).Width = 80
            DataGridView1.Columns(3).Width = 250
            DataGridView1.Columns(4).Width = 80
        Catch ex As Exception

        End Try
    End Function

    Private Sub Cmb_Ver_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Ver.SelectedIndexChanged
        Carga("")
    End Sub

    Private Sub btn_BuscaAgente_Click(sender As Object, e As EventArgs) Handles btn_BuscaAgente.Click


        Class_VariablesGlobales.Obj_ListaAgentes = New ListaAgentes
        Class_VariablesGlobales.Obj_ListaAgentes.MdiParent = Principal
        Class_VariablesGlobales.Obj_ListaAgentes.Puesto = "TODOS"
        Class_VariablesGlobales.Lista_llamadaDesde = "NOTASPENDIENTES"
        Class_VariablesGlobales.Obj_ListaAgentes.Show()


    End Sub

    Private Sub txtb_CodAgente_TextChanged(sender As Object, e As EventArgs) Handles txtb_CodAgente.TextChanged
        Carga("")
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        Class_VariablesGlobales.frmDevoluciones = New Devoluciones
        Class_VariablesGlobales.frmDevoluciones.MdiParent = Principal
        Class_VariablesGlobales.frmDevoluciones.Show()
        'llama a la funcion buscar
        Class_VariablesGlobales.frmDevoluciones.Cargar(DataGridView1.CurrentRow.Cells(0).Value.ToString, Trim(Cmb_Ver.Text))
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class