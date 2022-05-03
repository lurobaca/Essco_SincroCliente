Public Class ProveedoresShow

    Private Sub txt_Descripcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Descripcion.KeyPress
        dtg_Clientes.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.Obtieneclientes(Class_VariablesGlobales.SQL_Comman2, txt_Descripcion.Text, "S")

    End Sub

    Private Sub dtg_Clientes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_Clientes.CellContentClick
        Try
            Dim CodProveedor As String
            Dim Nombre As String


            Dim row = dtg_Clientes.CurrentRow.Index
            CodProveedor = dtg_Clientes(0, row).Value.ToString()
            Nombre = dtg_Clientes(1, row).Value.ToString()






            ' si esta buscando el proveedor para el descuento fijo la exepcion estara enfalso de los contrario estara buscando el proveedor para las excepciones
            If Class_VariablesGlobales.Excepcion = False Then

                Class_VariablesGlobales.frmDescuentosFijos.txb_CodProveedor.Text = CodProveedor
                Class_VariablesGlobales.frmDescuentosFijos.txb_NombProveedor.Text = Nombre

                With Class_VariablesGlobales.frmDescuentosFijos.cbx_familia
                    .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneFamilias(Class_VariablesGlobales.SQL_Comman2, CodProveedor)
                    .DisplayMember = "Familia"

                End With



                With Class_VariablesGlobales.frmDescuentosFijos.cbx_Categoria
                    .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneCategorias(Class_VariablesGlobales.SQL_Comman2, CodProveedor)
                    .DisplayMember = "Categoria"

                End With

                With Class_VariablesGlobales.frmDescuentosFijos.cbx_Marca
                    .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneMarcas(Class_VariablesGlobales.SQL_Comman2, CodProveedor)
                    .DisplayMember = "Marca"

                End With
            ElseIf Class_VariablesGlobales.Excepcion = True Then

                'Class_VariablesGlobales.frmDescuentosFijos.txb_Excepcion_CodProve.Text = CodProveedor
                'Class_VariablesGlobales.frmDescuentosFijos.txb_Excepcion_NombreProveed.Text = Nombre

                'With Class_VariablesGlobales.frmDescuentosFijos.cbx_Excepcion_Familia
                '    .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneFamilias(Class_VariablesGlobales.SQL_Comman2, CodProveedor)
                '    .DisplayMember = "Familia"
                'End With

                'With Class_VariablesGlobales.frmDescuentosFijos.cbx_Excepcion_Categoria
                '    .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneCategorias(Class_VariablesGlobales.SQL_Comman2, CodProveedor)
                '    .DisplayMember = "Categoria"
                'End With

                'With Class_VariablesGlobales.frmDescuentosFijos.cbx_Excepcion_Marca
                '    .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneMarcas(Class_VariablesGlobales.SQL_Comman2, CodProveedor)
                '    .DisplayMember = "Marca"
                'End With
            End If


            Me.Close()

            'Obj_Funciones_SQL.CambiaEstadoReinsertar(DocNumReinsertar, Doc)

        Catch ex As Exception

            'ERRORES = "[ " & Now & " ] ERROR EN DataGridView1_MouseClick [ " & ex.Message & " ]"

        End Try
    End Sub

    Private Sub ProveedoresShow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtg_Clientes.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.Obtieneclientes(Class_VariablesGlobales.SQL_Comman2, "", "S")


        Me.Show()
        Application.DoEvents()
        txt_Descripcion.Focus()

    End Sub
End Class