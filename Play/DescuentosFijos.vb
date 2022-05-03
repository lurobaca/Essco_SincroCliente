Public Class DescuentosFijos

#Region "Acciones Descuento Fijo Clientes"

    Public iddesc As String
    Public idExcepcion As String

    Private Sub DescuentosFijos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargadatos()
    End Sub

    Public Function cargadatos()
        Try

     
            '---------------  Descuentos fijos carga combobozx de 
            cbx_familia.DataSource = New DataTable
            cbx_Categoria.DataSource = New DataTable
            cbx_Marca.DataSource = New DataTable

            With cbx_familia
                .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTodaslasFamilias(Class_VariablesGlobales.SQL_Comman2)
                .DisplayMember = "Familia"
            End With

            With cbx_Categoria
                .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTodaslasCategorias(Class_VariablesGlobales.SQL_Comman2)
                .DisplayMember = "Categoria"
            End With

            With cbx_Marca
                .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTodaslasMarcas(Class_VariablesGlobales.SQL_Comman2)
                .DisplayMember = "Marca"
            End With

            With cbx_Grupo
                .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTodaslasGrupos(Class_VariablesGlobales.SQL_Comman2)
                .DisplayMember = "Grupo"
            End With


            'Debe Carga los descuentos fijos ya agregardos

        Catch ex As Exception

        End Try
    End Function

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscClienDesc.Click
        BuscaClientesConDescFijos.Show()

    End Sub

    'Private Sub btn_agrega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agrega.Click
    '    Class_VariablesGlobales.Obj_Funciones_SQL.AgregaDescFijo(Class_VariablesGlobales.SQL_Comman2, Trim(txb_CodCliente.Text), Trim(txb_NombCliente.Text), Trim(txb_CodProveedor.Text), Trim(txb_NombProveedor.Text), Trim(cbx_familia.Text), Trim(cbx_Categoria.Text), Trim(cbx_Marca.Text), Trim(txb_CodArt.Text), Trim(txb_NombArticulo.Text), Trim(txb_Desc.Text))
    '    DGV_descFijos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaDescFijos(Class_VariablesGlobales.SQL_Comman2, Trim(txb_CodCliente.Text))
    '    Limpiar()
    '    Panel12.Enabled = False
    '    Panel1.Enabled = False
    'End Sub

    Public Function Limpiar()
        txb_CodCliente.Text = ""
        txb_NombCliente.Text = ""
        txb_CodProveedor.Text = ""
        txb_NombProveedor.Text = ""
        cbx_familia.Text = ""
        cbx_Categoria.Text = ""
        cbx_Marca.Text = ""
        txb_CodArt.Text = ""
        txb_NombArticulo.Text = ""
        txb_Desc.Text = ""
    End Function

    Private Sub DGV_descFijos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_descFijos.CellContentClick
        Try

            btn_Addexcepcion.Enabled = True

            Dim Codcliente As String

            Panel1.Enabled = True
            Dim row = DGV_descFijos.CurrentRow.Index
            iddesc = DGV_descFijos(0, row).Value.ToString()
            txb_CodCliente.Text = DGV_descFijos(1, row).Value.ToString()
            txb_NombCliente.Text = DGV_descFijos(2, row).Value.ToString()
            txb_CodProveedor.Text = DGV_descFijos(3, row).Value.ToString()

            cbx_familia.DataSource = New DataTable
            With cbx_familia
                .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneFamilias(Class_VariablesGlobales.SQL_Comman2, txb_CodProveedor.Text)
                .DisplayMember = "Familia"
            End With



            cbx_Categoria.DataSource = New DataTable
            With cbx_Categoria
                .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneCategorias(Class_VariablesGlobales.SQL_Comman2, txb_CodProveedor.Text)
                .DisplayMember = "Categoria"

            End With


            cbx_Marca.DataSource = New DataTable
            With cbx_Marca
                .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneMarcas(Class_VariablesGlobales.SQL_Comman2, txb_CodProveedor.Text)
                .DisplayMember = "Marca"
            End With

            cbx_Grupo.DataSource = New DataTable
            With cbx_Grupo
                .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGrupo(Class_VariablesGlobales.SQL_Comman2, txb_CodProveedor.Text)
                .DisplayMember = "Grupo"
            End With

            txb_NombProveedor.Text = DGV_descFijos(4, row).Value.ToString()
            cbx_familia.Text = DGV_descFijos(5, row).Value.ToString()
            cbx_Categoria.Text = DGV_descFijos(6, row).Value.ToString()
            cbx_Marca.Text = DGV_descFijos(7, row).Value.ToString()
            txb_CodArt.Text = DGV_descFijos(8, row).Value.ToString()
            txb_NombArticulo.Text = DGV_descFijos(9, row).Value.ToString()
            txb_Desc.Text = DGV_descFijos(10, row).Value.ToString()

            DGV_descFijosExepciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaExcepciones(Class_VariablesGlobales.SQL_Comman2, iddesc)

        Catch ex As Exception

            'ERRORES = "[ " & Now & " ] ERROR EN DataGridView1_MouseClick [ " & ex.Message & " ]"

        End Try

    End Sub

    Public Function Limpia()
        txb_CodCliente.Text = ""
        txb_NombCliente.Text = ""
        txb_CodProveedor.Text = ""
        txb_NombProveedor.Text = ""
        cbx_familia.Text = ""
        cbx_Categoria.Text = ""
        cbx_Marca.Text = ""
        txb_CodArt.Text = ""
        txb_NombArticulo.Text = ""
        txb_Desc.Text = ""

        txb_Excepcion_CodProve.Text = ""
        txb_Excepcion_NombreProveed.Text = ""
        cbx_Excepcion_Familia.Text = ""
        cbx_Excepcion_Categoria.Text = ""
        cbx_Excepcion_Marca.Text = ""
        txb_Excepcion_CodArti.Text = ""
        txb_Excepcion_NombreArti.Text = ""
        DGV_descFijosExepciones.DataSource = New DataTable
        DGV_descFijos.DataSource = New DataTable


        Panel12.Enabled = False
    End Function
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Me.Show()
        Application.DoEvents()

        Limpia()
        cargadatos()
        Panel1.Enabled = True
        txb_CodCliente.Focus()
        ClientesShow.Show()
    End Sub

    Private Sub DataGridView5_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_descFijosExepciones.CellContentClick
        Try

            Dim Codcliente As String


            Dim row = DGV_descFijosExepciones.CurrentRow.Index
            idExcepcion = DGV_descFijosExepciones(0, row).Value.ToString()
            txb_Excepcion_CodProve.Text = DGV_descFijosExepciones(2, row).Value.ToString()

            With cbx_Excepcion_Familia
                .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneFamilias(Class_VariablesGlobales.SQL_Comman2, txb_Excepcion_CodProve.Text)
                .DisplayMember = "Familia"
            End With




            With cbx_Excepcion_Categoria
                .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneCategorias(Class_VariablesGlobales.SQL_Comman2, txb_Excepcion_CodProve.Text)
                .DisplayMember = "Categoria"

            End With



            With cbx_Excepcion_Marca
                .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneMarcas(Class_VariablesGlobales.SQL_Comman2, txb_Excepcion_CodProve.Text)
                .DisplayMember = "Marca"
            End With


            'txb_Excepcion_NombreProveed.Text = DataGridView5(2, row).Value.ToString()
            cbx_Excepcion_Familia.Text = DGV_descFijosExepciones(3, row).Value.ToString()
            cbx_Excepcion_Categoria.Text = DGV_descFijosExepciones(4, row).Value.ToString()
            cbx_Excepcion_Marca.Text = DGV_descFijosExepciones(5, row).Value.ToString()
            txb_Excepcion_CodArti.Text = DGV_descFijosExepciones(6, row).Value.ToString()
            'txb_Excepcion_NombreArti.Text = DataGridView5(7, row).Value.ToString()


            Panel12.Enabled = True


        Catch ex As Exception

            'ERRORES = "[ " & Now & " ] ERROR EN DataGridView1_MouseClick [ " & ex.Message & " ]"

        End Try
    End Sub

    Private Sub btn_Addexcepcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Addexcepcion.Click

        Panel12.Enabled = True

        If txb_CodProveedor.Text <> "" Then

            txb_Excepcion_CodProve.Enabled = False
            txb_Excepcion_NombreProveed.Enabled = False

            If cbx_familia.Text = "" Then
                With cbx_Excepcion_Familia
                    .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneFamilias(Class_VariablesGlobales.SQL_Comman2, txb_CodProveedor.Text)
                    .DisplayMember = "Familia"
                End With
            Else
                cbx_Excepcion_Familia.Enabled = False
            End If


            If cbx_Categoria.Text = "" Then
                With cbx_Excepcion_Categoria
                    .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneCategorias(Class_VariablesGlobales.SQL_Comman2, txb_CodProveedor.Text)
                    .DisplayMember = "Categoria"

                End With
            Else
                cbx_Excepcion_Categoria.Enabled = False
            End If

            If cbx_Marca.Text = "" Then
                With cbx_Excepcion_Marca
                    .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneMarcas(Class_VariablesGlobales.SQL_Comman2, txb_CodProveedor.Text)
                    .DisplayMember = "Marca"
                End With
            Else
                cbx_Excepcion_Marca.Enabled = False
            End If


        Else

            With cbx_Excepcion_Familia
                .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTodaslasFamilias(Class_VariablesGlobales.SQL_Comman2)
                .DisplayMember = "Familia"
            End With

            With cbx_Excepcion_Categoria
                .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTodaslasCategorias(Class_VariablesGlobales.SQL_Comman2)
                .DisplayMember = "Categoria"
            End With

            With cbx_Excepcion_Marca
                .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTodaslasMarcas(Class_VariablesGlobales.SQL_Comman2)
                .DisplayMember = "Marca"
            End With



        End If

    End Sub

    Private Sub btn_excepcion_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excepcion_add.Click

        Dim CodCliente As String = txb_CodCliente.Text
        Dim NombreCliente As String = txb_NombCliente.Text
        Dim CodProve As String = txb_Excepcion_CodProve.Text
        Dim NombreProveed As String = txb_Excepcion_NombreProveed.Text
        Dim Familia As String = cbx_Excepcion_Familia.Text
        Dim Categoria As String = cbx_Excepcion_Categoria.Text
        Dim Marca As String = cbx_Excepcion_Marca.Text
        Dim CodArti As String = txb_Excepcion_CodArti.Text
        Dim NombreArti As String = txb_Excepcion_NombreArti.Text


        Class_VariablesGlobales.Obj_Funciones_SQL.AgregaDescFijoExepciones(Class_VariablesGlobales.SQL_Comman2, iddesc, CodCliente, CodProve, NombreProveed, Familia, Categoria, Marca, CodArti, NombreArti)

        DGV_descFijosExepciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaExcepciones(Class_VariablesGlobales.SQL_Comman2, iddesc)
        txb_Excepcion_CodProve.Text = ""
        txb_Excepcion_NombreProveed.Text = ""
        cbx_Excepcion_Familia.Text = ""
        cbx_Excepcion_Categoria.Text = ""
        cbx_Excepcion_Marca.Text = ""
        txb_Excepcion_CodArti.Text = ""
        txb_Excepcion_NombreArti.Text = ""
    End Sub

    Private Sub btn_Elimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Elimina.Click
        Class_VariablesGlobales.Obj_Funciones_SQL.EliminaDescFijo(Class_VariablesGlobales.SQL_Comman2, iddesc)
        Limpia()
        Panel1.Enabled = False

        DGV_descFijos.DataSource = New DataTable

    End Sub

    Private Sub btn_excepcion_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excepcion_Delete.Click
        Class_VariablesGlobales.Obj_Funciones_SQL.EliminaDescFijoExepciones(Class_VariablesGlobales.SQL_Comman2, idExcepcion)
        Limpia()
        Panel1.Enabled = False
        DGV_descFijos.DataSource = New DataTable
        DGV_descFijosExepciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaExcepciones(Class_VariablesGlobales.SQL_Comman2, iddesc)
    End Sub

    Private Sub txb_Excepcion_CodProve_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txb_Excepcion_CodProve.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
            ProveedoresShow.Show()
            Class_VariablesGlobales.Excepcion = True
        Else
            'buscara y le cargara la familia categoria y marca segun el codigo
        End If
    End Sub

    Private Sub btn_Modifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Modifica.Click
        Panel1.Enabled = False
        '  Class_VariablesGlobales.Obj_Funciones_SQL.ModificaDescFijo(Class_VariablesGlobales.SQL_Comman2, iddesc, txb_CodCliente.Text, txb_NombCliente.Text, txb_CodProveedor.Text, txb_NombProveedor.Text, cbx_familia.Text, cbx_Categoria.Text, cbx_Marca.Text, txb_CodArt.Text, txb_NombArticulo.Text, txb_Desc.Text)
        Limpia()
    End Sub

    Private Sub txb_CodCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txb_CodCliente.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
            ClientesShow.Show()
            Class_VariablesGlobales.Excepcion = False
        Else

        End If
    End Sub

    Private Sub txb_CodProveedor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txb_CodProveedor.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
            ProveedoresShow.Show()
        Else
            'buscara y le cargara la familia categoria y marca segun el codigo
        End If
    End Sub
#End Region


   
    Private Sub btn_agrega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agrega.Click

    End Sub
End Class