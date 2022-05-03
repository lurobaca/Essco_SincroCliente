Public Class ClientesShow
    Public ObjVarGlob As New Class_VariablesGlobales
    Private Sub txt_Descripcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Descripcion.KeyPress
        dtg_Clientes.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.Obtieneclientes(Class_VariablesGlobales.SQL_Comman2, txt_Descripcion.Text, "C")
    End Sub

    Private Sub ClientesShow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Show()
        Application.DoEvents()
        txt_Descripcion.Focus()
        dtg_Clientes.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.Obtieneclientes(Class_VariablesGlobales.SQL_Comman2, "", "C")


    End Sub

    Private Sub dtg_Clientes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_Clientes.CellContentClick
        Try
            Dim Codcliente As String
            Dim Nombre As String


            Dim row = dtg_Clientes.CurrentRow.Index
            Codcliente = dtg_Clientes(0, row).Value.ToString()
            Nombre = dtg_Clientes(1, row).Value.ToString()


            Class_VariablesGlobales.frmDescuentosFijos.txb_CodCliente.Text = Codcliente
            Class_VariablesGlobales.frmDescuentosFijos.txb_NombCliente.Text = Nombre
            ProveedoresShow.Show()
            Me.Close()

            'Obj_Funciones_SQL.CambiaEstadoReinsertar(DocNumReinsertar, Doc)
           
        Catch ex As Exception

            'ERRORES = "[ " & Now & " ] ERROR EN DataGridView1_MouseClick [ " & ex.Message & " ]"

        End Try
    End Sub
End Class