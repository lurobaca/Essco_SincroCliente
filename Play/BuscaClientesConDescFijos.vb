Public Class BuscaClientesConDescFijos

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

      





    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress



        DataGridView1.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaClientesDescFijos(Class_VariablesGlobales.SQL_Comman2, TextBox1.Text)
    End Sub

    Private Sub BuscaClientesConDescFijos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        Application.DoEvents()
        TextBox1.Focus()

        DataGridView1.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaClientesDescFijos(Class_VariablesGlobales.SQL_Comman2, "")

    End Sub

    Private Sub DataGridView1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try

            Dim Codcliente As String

            Dim row = DataGridView1.CurrentRow.Index
            Codcliente = DataGridView1(0, row).Value.ToString()

            '[id], [CodCliente], [NombreCliente], [CodProveedor], [NombreProveedor], [Familia], [Categoria], [Marca], [CodArticulo], [NombreArticulo], [Descuento], 
            '[Grupo], [Usuario], [FechaCreacion], [FechaCerrado], [FechaIni], [FechaFin], [Indefinido], [Estado]
            Class_VariablesGlobales.frmDescuentosFijos.Limpiar()

            Class_VariablesGlobales.frmDescuentosFijos.txb_CodCliente.Text = DataGridView1(1, row).Value.ToString()
            Class_VariablesGlobales.frmDescuentosFijos.txb_NombCliente.Text = DataGridView1(2, row).Value.ToString()
            Class_VariablesGlobales.frmDescuentosFijos.txb_CodProveedor.Text = DataGridView1(3, row).Value.ToString()
            Class_VariablesGlobales.frmDescuentosFijos.txb_NombProveedor.Text = DataGridView1(4, row).Value.ToString()
            Class_VariablesGlobales.frmDescuentosFijos.cbx_familia.Text = DataGridView1(5, row).Value.ToString()
            Class_VariablesGlobales.frmDescuentosFijos.cbx_Categoria.Text = DataGridView1(6, row).Value.ToString()
            Class_VariablesGlobales.frmDescuentosFijos.cbx_Marca.Text = DataGridView1(7, row).Value.ToString()
            Class_VariablesGlobales.frmDescuentosFijos.txb_CodArt.Text = DataGridView1(8, row).Value.ToString()
            Class_VariablesGlobales.frmDescuentosFijos.txb_NombArticulo.Text = DataGridView1(9, row).Value.ToString()
            Class_VariablesGlobales.frmDescuentosFijos.txb_Desc.Text = DataGridView1(10, row).Value.ToString()

            Class_VariablesGlobales.frmDescuentosFijos.dtp_FechaIni.Text = DataGridView1(15, row).Value.ToString()
            Class_VariablesGlobales.frmDescuentosFijos.dtp_FechaFin.Text = DataGridView1(16, row).Value.ToString()
            Class_VariablesGlobales.frmDescuentosFijos.Cbx_Indefinido.Text = DataGridView1(17, row).Value.ToString()

            If Trim(DataGridView1(18, row).Value.ToString()) = "1" Then
                Class_VariablesGlobales.frmDescuentosFijos.Lbl_Estado.Visible = True
                Class_VariablesGlobales.frmDescuentosFijos.Lbl_Estado.Text = "ACTIVO"
            Else
                Class_VariablesGlobales.frmDescuentosFijos.Lbl_Estado.Visible = True
                Class_VariablesGlobales.frmDescuentosFijos.Lbl_Estado.Text = "INACTIVO"
            End If

            'Class_VariablesGlobales.frmDescuentosFijos.DGV_descFijos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaDescFijos(Class_VariablesGlobales.SQL_Comman2, Codcliente)




            Me.Close()

        Catch ex As Exception

            'ERRORES = "[ " & Now & " ] ERROR EN DataGridView1_MouseClick [ " & ex.Message & " ]"

        End Try

    End Sub
End Class