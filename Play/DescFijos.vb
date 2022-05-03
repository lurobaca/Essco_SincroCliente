Public Class DescFijos
    Dim PeriodoIndefinido As Integer
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_NuevaExepcion.Click
        DescFijos_Excepciones.Show()

    End Sub

    Public Function Limpiar()

        txb_Consecutivo.Text = CInt(Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneIDDescFijo(Class_VariablesGlobales.SQL_Comman2))
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

    Private Sub DescFijos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargadatos()
    End Sub

    Public Function cargadatos()
        Try

            'Jalara el ultimo consecutivo ingresado

            txb_Consecutivo.Text = CInt(Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneIDDescFijo(Class_VariablesGlobales.SQL_Comman2))


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

            'With cbx_Grupo
            '    .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTodaslasGrupos(Class_VariablesGlobales.SQL_Comman2)
            '    .DisplayMember = "Grupo"
            'End With


            'Debe Carga los descuentos fijos ya agregardos

        Catch ex As Exception

        End Try
    End Function

    Private Sub btn_Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Buscar.Click
        BuscaClientesConDescFijos.Show()
    End Sub

    Private Sub btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Nuevo.Click
        cargadatos()
        txb_CodCliente.Focus()
        ClientesShow.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ClientesShow.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ProveedoresShow.Show()
    End Sub

    Private Sub Cbx_Indefinido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbx_Indefinido.CheckedChanged
        If dtp_FechaIni.Enabled = True Then
            dtp_FechaIni.Enabled = True
            dtp_FechaFin.Enabled = True
            PeriodoIndefinido = 1
        Else


            dtp_FechaIni.Enabled = False
            dtp_FechaFin.Enabled = False
            PeriodoIndefinido = 0
        End If

    End Sub

    Private Sub btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Guardar.Click
        Dim Estado As Integer

        Dim DTP_FIni As Date
        Dim DTP_FFIN As Date
        Dim FechaCreado As Date
        Dim FechaCerrado As Date

        If btn_Guardar.Text = "Guardar" Then
            Class_VariablesGlobales.Obj_Funciones_SQL.AgregaDescFijo(Class_VariablesGlobales.SQL_Comman2, CInt(txb_Consecutivo.Text), txb_CodCliente.Text, txb_NombCliente.Text, _
            txb_CodProveedor.Text, txb_NombProveedor.Text, Trim(cbx_familia.Text), Trim(cbx_Categoria.Text), Trim(cbx_Marca.Text), Trim(txb_CodArt.Text), _
            Trim(txb_NombArticulo.Text), txb_Desc.Text, Estado, PeriodoIndefinido, dtp_FechaIni.Value.Date, _
            dtp_FechaFin.Value.Date, Now.Date, Now.Date, Class_VariablesGlobales.Log_Usuario, "GUARDAR")



        Else
            Class_VariablesGlobales.Obj_Funciones_SQL.AgregaDescFijo(Class_VariablesGlobales.SQL_Comman2, CInt(txb_Consecutivo.Text), txb_CodCliente.Text, txb_NombCliente.Text, _
        txb_CodProveedor.Text, txb_NombProveedor.Text, cbx_familia.Text, cbx_Categoria.Text, cbx_Marca.Text, txb_CodArt.Text, _
        txb_NombArticulo.Text, txb_Desc.Text, Estado, PeriodoIndefinido, dtp_FechaIni.Value.Date, _
        dtp_FechaFin.Value.Date, FechaCreado, FechaCerrado, Class_VariablesGlobales.Log_Usuario, "MODIFICAR")



        End If
        Limpiar()

    End Sub

    Private Sub btn_Anular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Anular.Click
        Class_VariablesGlobales.Obj_Funciones_SQL.CierraDesc(Class_VariablesGlobales.SQL_Comman2, CInt(txb_Consecutivo.Text), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Now.Date), "MODIFICAR")
    End Sub
End Class