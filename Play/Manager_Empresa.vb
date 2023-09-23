Public Class Manager_Empresa
    Public indexItemRazones As String
    Dim Id_Provincia, Id_Canton, Id_Distrito, Id_Barrio As Integer
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Nuevo.Click
        Limpia()
    End Sub

    Private Sub btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Guardar.Click

        Dim TipoGrupoDescuento As Integer
        Dim SocioDeNeogicioEspecifico As Integer = 2
        Dim GrupoDeClientes As Integer = 10

        If RBtn_SocioNegocioEspecifico.Checked Then
            TipoGrupoDescuento = SocioDeNeogicioEspecifico
        End If

        If RBtn_GrupoClientes.Checked Then
            TipoGrupoDescuento = GrupoDeClientes
        End If



        If Txtb_Cedula.Text <> "" And Txtb_Nombre.Text <> "" And Txtb_Telefono.Text <> "" And Txtb_Email.Text <> "" And Txtb_Web.Text <> "" And Txtb_Direccion.Text <> "" And txtb_Fantacia.Text <> "" And Combo_Provincia.Text <> "" And Combo_Canton.Text <> "" And Combo_Distrito.Text <> "" And Combo_Barrio.Text <> "" And Txtb_ClaveEmail.Text <> "" And Txtb_RutaPadreFtp.Text <> "" And txtb_ServidorSQL.Text <> "" And Txtb_IPServidorSQL.Text <> "" And txtb_UsuarioSQL.Text <> "" And txtb_ClaveSQL.Text <> "" Then
            If Class_VariablesGlobales.Obj_Funciones_SQL.INSERTA_Empresa(Class_VariablesGlobales.SQL_Comman2, Txtb_Cedula.Text, Txtb_Nombre.Text, Txtb_Telefono.Text, Txtb_Email.Text, Txtb_Web.Text, Txtb_Direccion.Text, Txtb_Servidor.Text, Txtb_Usuario.Text, Txtb_Clave.Text, Txtb_LinMax_Fac.Text, Txtb_DescMax.Text, Txtb_Conse_RepCarga.Text, Txtb_Conse_RepDevoluciones.Text, txtb_Fantacia.Text, Combo_Provincia.SelectedIndex, Combo_Canton.SelectedIndex, Combo_Distrito.SelectedIndex, Combo_Barrio.SelectedIndex, Cmb_TipoCedula.SelectedIndex, Txtb_Telefono.Text, Txtb_ClaveEmail.Text, txtb_CodActividadEconomica.Text, txtb_DescrActividadEconomica.Text, Txtb_RutaPadreFtp.Text, txtb_ServidorSQL.Text, Txtb_IPServidorSQL.Text, txtb_UsuarioSQL.Text, txtb_ClaveSQL.Text, Txtb_DiasExtencion.Text, TipoGrupoDescuento) = 0 Then
                Limpia()
                Me.Close()

            End If

        Else
            MsgBox("Verifique que todos los campos con * esten llenos")
        End If


    End Sub

    Private Sub btn_Modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Modificar.Click
        Dim TipoGrupoDescuento As Integer
        Dim SocioDeNeogicioEspecifico As Integer = 2
        Dim GrupoDeClientes As Integer = 10

        If RBtn_SocioNegocioEspecifico.Checked Then
            TipoGrupoDescuento = SocioDeNeogicioEspecifico
        End If

        If RBtn_GrupoClientes.Checked Then
            TipoGrupoDescuento = GrupoDeClientes
        End If

        If Txtb_Telefono.Text = "" Then
            Txtb_Telefono.Text = "0"
        End If

        If Txtb_Telefono2.Text = "" Then
            Txtb_Telefono2.Text = "0"
        End If

        Class_VariablesGlobales.Obj_Funciones_SQL.Actualiza_Empresa(Class_VariablesGlobales.SQL_Comman2, Txtb_Cedula.Text, Txtb_Nombre.Text, Txtb_Telefono.Text, Txtb_Email.Text, Txtb_Web.Text, Txtb_Direccion.Text, Txtb_Servidor.Text, Txtb_Usuario.Text, Txtb_Clave.Text, Txtb_LinMax_Fac.Text, Txtb_DescMax.Text, Txtb_Conse_RepCarga.Text, Txtb_Conse_RepDevoluciones.Text, txtb_Fantacia.Text, Combo_Provincia.SelectedIndex, Combo_Canton.SelectedIndex, Combo_Distrito.SelectedIndex, Combo_Barrio.SelectedIndex, Cmb_TipoCedula.SelectedIndex, Txtb_Telefono2.Text, Txtb_ClaveEmail.Text, txtb_CodActividadEconomica.Text, txtb_DescrActividadEconomica.Text, Txtb_RutaPadreFtp.Text, txtb_ServidorSQL.Text, Txtb_IPServidorSQL.Text, txtb_UsuarioSQL.Text, txtb_ClaveSQL.Text, Txtb_DiasExtencion.Text, TipoGrupoDescuento)
        Limpia()
        MsgBox("Datos actualizados con existo")
        Me.Close()

    End Sub

    Private Sub Manager_Empresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim SocioDeNeogicioEspecifico As Integer = 2
            Dim GrupoDeClientes As Integer = 10


            'Obtiene las provincias
            'Obtenemos las provincias
            '---------PROVINCIAS-------------
            With Combo_Provincia
                .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneProvincias(Class_VariablesGlobales.SQL_Comman2, 0)
                .DisplayMember = "nombre_provincia"
                .ValueMember = "id_provincia"
            End With
            Id_Provincia = CInt(Trim(0))
            'If Id_Provincia - 1 >= 0 Then
            '    Id_Provincia = Id_Provincia - 1
            'End If
            Combo_Provincia.SelectedIndex = Id_Provincia

            '---------CANTONES-------------

            With Combo_Canton
                .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneCantones(Class_VariablesGlobales.SQL_Comman2, Id_Provincia, 0)
                .DisplayMember = "nombre_canton"
                .ValueMember = "id_canton"
            End With
            Id_Canton = CInt(Trim(0))
            'If Id_Canton - 1 >= 0 Then
            '    Id_Canton = Id_Canton - 1
            'End If
            Combo_Canton.SelectedIndex = Id_Canton

            '---------DISTRITOS-------------

            With Combo_Distrito
                .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDistritos(Class_VariablesGlobales.SQL_Comman2, Id_Provincia, Id_Canton, 0)
                .DisplayMember = "nombre_distrito"
                .ValueMember = "id_distrito"
            End With
            Id_Distrito = CInt(Trim(0))
            'If Id_Distrito - 1 >= 0 Then
            '    Id_Distrito = Id_Distrito - 1
            'End If
            Combo_Distrito.SelectedIndex = Id_Distrito


            '---------BARRIOS-------------

            With Combo_Barrio
                .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneBarrios(Class_VariablesGlobales.SQL_Comman2, Id_Provincia, Id_Canton, Id_Distrito, 0)
                .DisplayMember = "nombre_barrio"
                .ValueMember = "id_barrio"
            End With
            Id_Barrio = CInt(Trim(0))
            'If Id_Barrio - 1 >= 0 Then
            '    Id_Barrio = Id_Barrio - 1
            'End If
            Combo_Barrio.SelectedIndex = Id_Barrio

            Dim tabla As New DataTable
            Dim contardor As Integer = 0

            tabla = Class_VariablesGlobales.Obj_Funciones_SQL.CONSULTA_Empresa(Class_VariablesGlobales.SQL_Comman2)

            While contardor < tabla.Rows.Count


                Txtb_Cedula.Text = tabla.Rows(contardor).Item("Cedula").ToString()
                Txtb_Nombre.Text = tabla.Rows(contardor).Item("Nombre").ToString()
                Txtb_Telefono.Text = tabla.Rows(contardor).Item("Telefono").ToString()
                Txtb_Telefono2.Text = tabla.Rows(contardor).Item("Telefono2").ToString()
                Txtb_Email.Text = tabla.Rows(contardor).Item("Correo").ToString()
                Txtb_ClaveEmail.Text = tabla.Rows(contardor).Item("ClaveEmail").ToString()
                Txtb_Web.Text = tabla.Rows(contardor).Item("Web").ToString()
                Txtb_Direccion.Text = tabla.Rows(contardor).Item("Direccion").ToString()
                Txtb_Servidor.Text = tabla.Rows(contardor).Item("Server_Ftp").ToString()
                Txtb_Usuario.Text = tabla.Rows(contardor).Item("User_Ftp").ToString()
                Txtb_Clave.Text = tabla.Rows(contardor).Item("Clave_Ftp").ToString()
                Txtb_LinMax_Fac.Text = tabla.Rows(contardor).Item("NumMaxFactura").ToString()

                Txtb_DescMax.Text = tabla.Rows(contardor).Item("DescMax").ToString()
                Txtb_Conse_RepCarga.Text = tabla.Rows(contardor).Item("Conse_RepCarga").ToString()
                   Txtb_Conse_RepDevoluciones .Text = tabla.Rows(contardor).Item("Conse_RepDevoluciones").ToString()
                txtb_Fantacia.Text = tabla.Rows(contardor).Item("Nombre_Fantacia").ToString()

                txtb_CodActividadEconomica.Text = tabla.Rows(contardor).Item("CodigoActividadEconomica").ToString()
                txtb_DescrActividadEconomica.Text = tabla.Rows(contardor).Item("DescrActividadEconomica").ToString()
                Cmb_TipoCedula.SelectedIndex = tabla.Rows(contardor).Item("Tipo_Cedula").ToString()

                Combo_Provincia.SelectedIndex = tabla.Rows(contardor).Item("id_Provincia").ToString()
                Combo_Canton.SelectedIndex = tabla.Rows(contardor).Item("id_canton").ToString()
                Combo_Distrito.SelectedIndex = tabla.Rows(contardor).Item("id_distrito").ToString()
                Combo_Barrio.SelectedIndex = tabla.Rows(contardor).Item("id_barrio").ToString()

                Txtb_RutaPadreFtp.Text = tabla.Rows(contardor).Item("RutaPadre_Ftp").ToString()

                txtb_ServidorSQL.Text = tabla.Rows(contardor).Item("ServidorSQL").ToString()
                Txtb_IPServidorSQL.Text = tabla.Rows(contardor).Item("IPServidor").ToString()
                txtb_UsuarioSQL.Text = tabla.Rows(contardor).Item("UserSQL").ToString()
                txtb_ClaveSQL.Text = tabla.Rows(contardor).Item("ClaveSQL").ToString()
                Txtb_DiasExtencion.Text = tabla.Rows(contardor).Item("DiasExtencion").ToString()

                If tabla.Rows(contardor).Item("TipoGrupoDescuento").ToString() = SocioDeNeogicioEspecifico Then
                    RBtn_SocioNegocioEspecifico.Checked = True
                End If

                If tabla.Rows(contardor).Item("TipoGrupoDescuento").ToString() = GrupoDeClientes Then
                    RBtn_GrupoClientes.Checked = True
                End If

                contardor += 1
            End While
            If Txtb_Cedula.Text <> "" Then
                btn_Guardar.Enabled = False
            End If


            CargaRazonesNoVisita()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al cargar la empresa")
        End Try
    End Sub

    Public Function CargaRazonesNoVisita()
        Dim contardor As Integer = 0
        Dim tabla As DataTable
        tabla = New DataTable
        tabla = Class_VariablesGlobales.Obj_Funciones_SQL.CONSULTA_RazonesNoVisita(Class_VariablesGlobales.SQL_Comman2)

        While contardor < tabla.Rows.Count

            CboBox_Razones.Items.Add(tabla.Rows(contardor).Item("Razon").ToString())
            contardor += 1
        End While
    End Function

    Public Function Limpia()
        Txtb_Cedula.Text = ""
        Txtb_Nombre.Text = ""
        Txtb_Telefono.Text = ""
        Txtb_Email.Text = ""
        Txtb_Web.Text = ""
        Txtb_Direccion.Text = ""
        Txtb_Servidor.Text = ""
        Txtb_Usuario.Text = ""
        Txtb_Clave.Text = ""
        Txtb_LinMax_Fac.Text = ""
        Txtb_DescMax.Text = ""
        Txtb_Conse_RepCarga.Text = ""
        Txtb_Conse_RepDevoluciones.Text = ""
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If btn_Razon.Text = "Nuevo" Then
            Txtb_Razon.Enabled = True
            btn_Razon.Text = "Guardar"
        ElseIf btn_Razon.Text = "Guardar" Then


            Class_VariablesGlobales.Obj_Funciones_SQL.Inserta_Razones_NoVisita(Class_VariablesGlobales.SQL_Comman2, Trim(Txtb_Razon.Text))
            Txtb_Razon.Enabled = False
            btn_Razon.Text = "Nuevo"
            Txtb_Razon.Text = ""
        ElseIf btn_Razon.Text = "Modificar" Then

            Class_VariablesGlobales.Obj_Funciones_SQL.Actualizar_Razones_NoVisita(Class_VariablesGlobales.SQL_Comman2, indexItemRazones, Trim(Txtb_Razon.Text))


        End If
        CboBox_Razones.Items.Clear()
        CargaRazonesNoVisita()
        CboBox_Razones.Text = ""

    End Sub

    Private Sub CboBox_Razones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim selectedIndex As Integer
        selectedIndex = CboBox_Razones.SelectedIndex
        Dim selectedItem As Object
        selectedItem = CboBox_Razones.SelectedItem
        Txtb_Razon.Text = selectedItem.ToString()
        indexItemRazones = selectedIndex.ToString()
        Txtb_Razon.Enabled = True
        btn_Razon.Text = "Modificar"
        btn_EliminaRazon.Visible = True
    End Sub

    Private Sub btn_EliminaRazon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Class_VariablesGlobales.Obj_Funciones_SQL.Elimina_Razon(Class_VariablesGlobales.SQL_Comman2, Trim(Txtb_Razon.Text))
        btn_EliminaRazon.Visible = False
        Txtb_Razon.Enabled = False
        btn_Razon.Text = "Nuevo"
        Txtb_Razon.Text = ""
        CboBox_Razones.Items.RemoveAt(indexItemRazones)
        CboBox_Razones.Items.Clear()
        CargaRazonesNoVisita()
        CboBox_Razones.Text = ""
    End Sub



    Private Sub Txtb_Telefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtb_Telefono.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Txtb_Cedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtb_Cedula.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True



        End If

        If Cmb_TipoCedula.Text = "Cédula Física" Then
            If Len(Txtb_Cedula.Text) >= 9 Then
                e.Handled = True

            End If
        End If
        If Cmb_TipoCedula.Text = "Cédula Jurídica" Then
            If Len(Txtb_Cedula.Text) >= 10 Then
                e.Handled = True

            End If
        End If
        If Cmb_TipoCedula.Text = "DIMEX" Then
            If Len(Txtb_Cedula.Text) >= 12 Then
                e.Handled = True

            End If
        End If
        If Cmb_TipoCedula.Text = "NITE" Then
            If Len(Txtb_Cedula.Text) >= 10 Then
                e.Handled = True

            End If
        End If

    End Sub

    Private Sub Txtb_Nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtb_Nombre.KeyPress
        If Len(Txtb_Nombre.Text) > 80 Then
            MsgBox("El nombre no puede contener mas de 80 caracteres")
        End If
    End Sub

    Private Sub txtb_Fantacia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtb_Fantacia.KeyPress
        If Len(Txtb_Nombre.Text) > 80 Then
            MsgBox("El nombre no puede contener mas de 80 caracteres")
        End If
    End Sub

    Private Sub Txtb_Cedula_TextChanged(sender As Object, e As EventArgs) Handles Txtb_Cedula.TextChanged
        'La “Cédula física” debe de contener 9 dígitos, sin cero al inicio y sin guiones
        'La “ cédula de personas Jurídicas” debe contener 10 dígitos y sin guiones 
        'El “Documento de Identificación Migratorio para Extranjeros( DIMEX)” debe contener 11 o 12 dígitos, sin ceros al inicio y sin guiones 
        'El “Documento de Identificación de la DGT( NITE)” debe contener 10 dígitos y sin guiones.

        If Cmb_TipoCedula.Text = "Cédula Física" Then
            If Len(Txtb_Cedula.Text) >= 9 Then
                MsgBox("La Cédula física debe de contener 9 dígitos, sin cero al inicio y sin guiones")

            End If
        End If
        If Cmb_TipoCedula.Text = "Cédula Jurídica" Then
            If Len(Txtb_Cedula.Text) >= 10 Then
                MsgBox("La cédula de personas Jurídicas debe contener 10 dígitos y sin guiones")

            End If
        End If
        If Cmb_TipoCedula.Text = "DIMEX" Then
            If Len(Txtb_Cedula.Text) >= 12 Then
                MsgBox("El Documento de Identificación Migratorio para Extranjeros( DIMEX) debe contener 11 o 12 dígitos, sin ceros al inicio y sin guiones")

            End If
        End If
        If Cmb_TipoCedula.Text = "NITE" Then
            If Len(Txtb_Cedula.Text) >= 10 Then
                MsgBox("El Documento de Identificación de la DGT( NITE) debe contener 10 dígitos y sin guiones")

            End If
        End If
    End Sub

    Private Sub Combo_Provincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_Provincia.SelectedIndexChanged
        If Combo_Canton.Items.Count > 0 Then
            'primero limpia las opciones de abajo 
            Combo_Canton.DataSource = Nothing
            Combo_Canton.Items.Clear()

            Combo_Distrito.DataSource = Nothing
            Combo_Distrito.Items.Clear()

            Combo_Barrio.DataSource = Nothing
            Combo_Barrio.Items.Clear()


            Id_Provincia = 0
            Id_Canton = 0
            Id_Distrito = 0
            Id_Barrio = 0

            'Obtiene los cantones segun la provincia elegida
            Id_Provincia = Combo_Provincia.SelectedIndex()
            'Carga los cantones
            With Combo_Canton
                .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneCantones(Class_VariablesGlobales.SQL_Comman2, Id_Provincia, 0)
                .DisplayMember = "nombre_canton"
                .ValueMember = "id_canton"
            End With
        End If


    End Sub

    Private Sub Manager_Empresa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Class_VariablesGlobales.Obj_Funciones_SQL.ExisteEmpresa(Class_VariablesGlobales.SQL_Comman1) = False Then


            MsgBox("Debe llenar la informacion de la empresa antes de iniciar", MsgBoxStyle.Information)





        End If
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs)

    End Sub



    Private Sub Combo_Canton_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_Canton.SelectedIndexChanged
        Try
            If Combo_Distrito.Items.Count >= 0 Then

                Combo_Distrito.DataSource = Nothing
                Combo_Distrito.Items.Clear()

                Combo_Barrio.DataSource = Nothing
                Combo_Barrio.Items.Clear()

                Id_Canton = 0
                Id_Distrito = 0
                Id_Barrio = 0

                Id_Canton = Combo_Canton.SelectedIndex()
                With Combo_Distrito
                    .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDistritos(Class_VariablesGlobales.SQL_Comman2, Id_Provincia, Id_Canton, 0)
                    .DisplayMember = "nombre_distrito"
                    .ValueMember = "id_distrito"
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub Combo_Distrito_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_Distrito.SelectedIndexChanged
        Try


            If Combo_Barrio.Items.Count >= 0 Then
                Combo_Barrio.DataSource = Nothing
                Combo_Barrio.Items.Clear()


                Id_Distrito = 0
                Id_Barrio = 0

                Id_Distrito = Combo_Distrito.SelectedIndex()

                With Combo_Barrio
                    .DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneBarrios(Class_VariablesGlobales.SQL_Comman2, Id_Provincia, Id_Canton, Id_Distrito, 0)
                    .DisplayMember = "nombre_barrio"
                    .ValueMember = "id_barrio"
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub Combo_Barrio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_Barrio.SelectedIndexChanged

        Id_Barrio = Combo_Distrito.SelectedIndex()
    End Sub

End Class