Public Class Admin_ClientesModificados
    Public Obj_SQL_CONEXIONSERVER As New Class_funcionesSQL
    Dim Id_Provincia, Id_Canton, Id_Distrito, Id_Barrio As Integer

    Dim EstadoInactivo As Integer = 0
    Dim EstadoActivo As Integer = 1

    'Public obj_SAP As New SAP_BUSSINES_ONE
    'Public oCompany As New SAPbobsCOM.Company
    Private Sub Btn_Atras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Atras.Click
        If CInt(txtb_id.Text) - 1 <= 0 Then
        Else
            Navegar(CInt(txtb_id.Text) - 1)
        End If


    End Sub

    Private Sub Btn_Adelante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Adelante.Click
        Navegar(CInt(txtb_id.Text) + 1)
    End Sub


    Private Sub Admin_ClientesModificados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            'txtb_Consecutivo.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneProvincias(Class_VariablesGlobales.SQL_Comman2, 0)

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
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'llama a la ventana donde estan todos los datos que se deben revisar


        ' indica que fue llamado desde la ventana administradora de clientes
        Class_VariablesGlobales.ClientesLlamadoDesde = "Admin_ClientesModificados"

        Class_VariablesGlobales.frmLista_ClientesModificados = New Lista_ClientesModificados
        Class_VariablesGlobales.frmLista_ClientesModificados.MdiParent = Principal

        Class_VariablesGlobales.frmLista_ClientesModificados.Show()

    End Sub



    Public Function Navegar(ByVal id As Integer)

        Dim Tbl As New DataTable
        Dim Id_Provincia, Id_Canton, Id_Distrito, Id_Barrio, Id_DiaVisita, Id_TipoID As Integer

        'Tbl = Obj_SQL_CONEXIONSERVER.ObtieneClientesModificados("Modifcado", Class_VariablesGlobales.SQL_Comman2, id, False, 1, "")

        For Each row As DataRow In Tbl.Rows




            txtb_Codigo.Text = Trim(Tbl.Rows(0).Item(0).ToString())
            txtb_Nombre.Text = Trim(Tbl.Rows(0).Item(1).ToString())
            txtb_Cedula.Text = Trim(Tbl.Rows(0).Item(2).ToString())
            txtb_ResponsableTributario.Text = Trim(Tbl.Rows(0).Item(3).ToString())

            Id_DiaVisita = Trim(Tbl.Rows(0).Item(4).ToString())
            Comb_DiaVisita.SelectedIndex = Id_DiaVisita

            txtb_CalveWeb.Text = Trim(Tbl.Rows(0).Item(5).ToString())
            txtb_Telfono1.Text = Trim(Tbl.Rows(0).Item(6).ToString())
            txtb_Telfono2.Text = Trim(Tbl.Rows(0).Item(7).ToString())
            txtb_OtrasResenas.Text = Trim(Tbl.Rows(0).Item(8).ToString())
            txtb_email.Text = Trim(Tbl.Rows(0).Item(9).ToString())
            txtb_NombreComercial.Text = Trim(Tbl.Rows(0).Item(10).ToString())
            txtb_Latitud.Text = Trim(Tbl.Rows(0).Item(11).ToString())
            txtb_Longitud.Text = Trim(Tbl.Rows(0).Item(12).ToString())
            txtb_Agente.Text = Trim(Tbl.Rows(0).Item(13).ToString())

            'Obtenemos las provincias
            '---------PROVINCIAS-------------
            With Combo_Provincia
                .DataSource = Obj_SQL_CONEXIONSERVER.ObtieneProvincias(Class_VariablesGlobales.SQL_Comman2, 0)
                .DisplayMember = "nombre_provincia"
                .ValueMember = "id_provincia"
            End With
            Id_Provincia = CInt(Trim(Tbl.Rows(0).Item(14).ToString()))
            'If Id_Provincia - 1 >= 0 Then
            '    Id_Provincia = Id_Provincia - 1
            'End If
            Combo_Provincia.SelectedIndex = Id_Provincia

            '---------CANTONES-------------

            With Combo_Canton
                .DataSource = Obj_SQL_CONEXIONSERVER.ObtieneCantones(Class_VariablesGlobales.SQL_Comman2, Id_Provincia, 0)
                .DisplayMember = "nombre_canton"
                .ValueMember = "id_canton"
            End With
            Id_Canton = CInt(Trim(Tbl.Rows(0).Item(15).ToString()))
            'If Id_Canton - 1 >= 0 Then
            '    Id_Canton = Id_Canton - 1
            'End If
            Combo_Canton.SelectedIndex = Id_Canton

            '---------DISTRITOS-------------

            With Combo_Distrito
                .DataSource = Obj_SQL_CONEXIONSERVER.ObtieneDistritos(Class_VariablesGlobales.SQL_Comman2, Id_Provincia, Id_Canton, 0)
                .DisplayMember = "nombre_distrito"
                .ValueMember = "id_distrito"
            End With
            Id_Distrito = CInt(Trim(Tbl.Rows(0).Item(16).ToString()))
            'If Id_Distrito - 1 >= 0 Then
            '    Id_Distrito = Id_Distrito - 1
            'End If
            Combo_Distrito.SelectedIndex = Id_Distrito


            '---------BARRIOS-------------

            With Combo_Barrio
                .DataSource = Obj_SQL_CONEXIONSERVER.ObtieneBarrios(Class_VariablesGlobales.SQL_Comman2, Id_Provincia, Id_Canton, Id_Distrito, 0)
                .DisplayMember = "nombre_barrio"
                .ValueMember = "id_barrio"
            End With
            Id_Barrio = CInt(Trim(Tbl.Rows(0).Item(17).ToString()))
            'If Id_Barrio - 1 >= 0 Then
            '    Id_Barrio = Id_Barrio - 1
            'End If
            Combo_Barrio.SelectedIndex = Id_Barrio

            Id_TipoID = CInt(Trim(Tbl.Rows(0).Item(19).ToString()))
            Comb_TipoId.SelectedIndex = Id_TipoID

            DTP_Fecha.Text = Trim(Tbl.Rows(0).Item(20).ToString())
            txtb_Hora.Text = Trim(Tbl.Rows(0).Item(21).ToString())
            txtb_id.Text = Trim(Tbl.Rows(0).Item(23).ToString())

            If Trim(Tbl.Rows(0).Item(18).ToString()) = "Nuevo" Then
                lbl_Estado.Visible = True

                btn_Actualizar.Enabled = False


                lbl_Estado.Text = Trim(Tbl.Rows(0).Item(18).ToString())

            Else
                lbl_Estado.Visible = False

                btn_Actualizar.Enabled = True


            End If



        Next
    End Function

    Dim idProvincia As Integer = 0
    Dim idCanton As Integer = 0
    Dim idDistrito As Integer = 0
    Dim idBarrio As Integer = 0
    Public Function Provincias()


    End Function

    Public Function Cantones()

    End Function
    Public Function Distritos()

    End Function
    Public Function Barrios()

    End Function

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
        End If
        'Obtiene los cantones segun la provincia elegida
        Id_Provincia = Combo_Provincia.SelectedIndex()
            'Carga los cantones
            With Class_VariablesGlobales.frmAdmin_ClientesModificados.Combo_Canton
                .DataSource = Obj_SQL_CONEXIONSERVER.ObtieneCantones(Class_VariablesGlobales.SQL_Comman2, Id_Provincia, 0)
                .DisplayMember = "nombre_canton"
                .ValueMember = "id_canton"
            End With



    End Sub

    Private Sub Combo_Canton_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_Canton.SelectedIndexChanged
        If Combo_Distrito.Items.Count > 0 Then

            Combo_Distrito.DataSource = Nothing
            Combo_Distrito.Items.Clear()

            Combo_Barrio.DataSource = Nothing
            Combo_Barrio.Items.Clear()

            Id_Canton = 0
            Id_Distrito = 0
            Id_Barrio = 0
        End If
        Id_Canton = Combo_Canton.SelectedIndex()
            With Class_VariablesGlobales.frmAdmin_ClientesModificados.Combo_Distrito
                .DataSource = Obj_SQL_CONEXIONSERVER.ObtieneDistritos(Class_VariablesGlobales.SQL_Comman2, Id_Provincia, Id_Canton, 0)
                .DisplayMember = "nombre_distrito"
                .ValueMember = "id_distrito"
            End With

    End Sub

    Private Sub Combo_Distrito_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_Distrito.SelectedIndexChanged
        If Combo_Barrio.Items.Count > 0 Then
            Combo_Barrio.DataSource = Nothing
            Combo_Barrio.Items.Clear()


            Id_Distrito = 0
            Id_Barrio = 0
        End If
        Id_Distrito = Combo_Distrito.SelectedIndex()

        With Class_VariablesGlobales.frmAdmin_ClientesModificados.Combo_Barrio
                .DataSource = Obj_SQL_CONEXIONSERVER.ObtieneBarrios(Class_VariablesGlobales.SQL_Comman2, Id_Provincia, Id_Canton, Id_Distrito, 0)
                .DisplayMember = "nombre_barrio"
                .ValueMember = "id_barrio"
            End With

    End Sub

    Private Sub Combo_Barrio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_Barrio.SelectedIndexChanged

        Id_Barrio = Combo_Distrito.SelectedIndex()
    End Sub


    ''---------PROVINCIAS-------------
    '    With Class_VariablesGlobales.frmAdmin_ClientesModificados.Combo_Provincia
    '        .DataSource = Obj_SQL_CONEXIONSERVER.ObtieneProvincias(Class_VariablesGlobales.SQL_Comman2, 0)
    '        .DisplayMember = "nombre_provincia"
    '        .ValueMember = "id_provincia"
    '    End With
    '    Id_Provincia = CInt(Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(14).Value))
    '    Class_VariablesGlobales.frmAdmin_ClientesModificados.Combo_Provincia.SelectedIndex = Id_Provincia

    ''---------CANTONES-------------
    '    With Class_VariablesGlobales.frmAdmin_ClientesModificados.Combo_Canton
    '        .DataSource = Obj_SQL_CONEXIONSERVER.ObtieneCantones(Class_VariablesGlobales.SQL_Comman2, Id_Provincia, 0)
    '        .DisplayMember = "nombre_canton"
    '        .ValueMember = "id_canton"
    '    End With
    '    Id_Canton = CInt(Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(15).Value))
    '    Class_VariablesGlobales.frmAdmin_ClientesModificados.Combo_Canton.SelectedIndex = Id_Canton

    ''---------DISTRITOS-------------
    '    With Class_VariablesGlobales.frmAdmin_ClientesModificados.Combo_Distrito
    '        .DataSource = Obj_SQL_CONEXIONSERVER.ObtieneDistritos(Class_VariablesGlobales.SQL_Comman2, Id_Provincia, Id_Canton, 0)
    '        .DisplayMember = "nombre_distrito"
    '        .ValueMember = "id_distrito"
    '    End With
    '    Id_Distrito = CInt(Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(16).Value))
    '    Class_VariablesGlobales.frmAdmin_ClientesModificados.Combo_Distrito.SelectedIndex = Id_Distrito


    ''---------BARRIOS-------------
    '    With Class_VariablesGlobales.frmAdmin_ClientesModificados.Combo_Barrio
    '        .DataSource = Obj_SQL_CONEXIONSERVER.ObtieneBarrios(Class_VariablesGlobales.SQL_Comman2, Id_Provincia, Id_Canton, Id_Distrito, 0)
    '        .DisplayMember = "nombre_barrio"
    '        .ValueMember = "id_barrio"
    '    End With
    '    Id_Barrio = CInt(Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(17).Value))
    '    Class_VariablesGlobales.frmAdmin_ClientesModificados.Combo_Barrio.SelectedIndex = Id_Barrio



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Actualizar.Click

        Dim result1 As DialogResult

        If btn_Actualizar.Text = "Cerrar Cliente en SAP" Then
            CerrarCliente()
        End If

        If btn_Actualizar.Text = "Modificar Cliente en SAP" Then
            ModificaCliente()
        End If

        If btn_Actualizar.Text = "Crear Cliente en SAP" Then

            CreaSocioNegocio()
        End If

        If btn_Actualizar.Text = "Guardar" Or btn_Actualizar.Text = "Interno" Then
            Dim DiaVisita As String = ""
            Select Case Comb_DiaVisita.SelectedIndex
                Case 1
                    DiaVisita = "01"
                Case 2
                    DiaVisita = "02"
                Case 3
                    DiaVisita = "03"
                Case 4
                    DiaVisita = "04"
                Case 5
                    DiaVisita = "05"
                Case 6
                    DiaVisita = "06"
            End Select

            Dim Err As String = ""
            If Comb_TipoId.SelectedIndex = "01" Then

                If txtb_Cedula.Text.Length = 9 Then
                Else
                    Err = "La Cédula física debe de contener 9 dígitos, sin cero al inicio y sin guiones"
                End If

            ElseIf Comb_TipoId.SelectedIndex = "02" Then

                If txtb_Cedula.Text.Length = 10 Then

                Else
                    Err = "La cédula de personas Jurídicas debe contener 10 dígitos y sin guiones "
                End If
            ElseIf Comb_TipoId.SelectedIndex = "03" Then

                If txtb_Cedula.Text.Length = 11 Or txtb_Cedula.Text.Length = 12 Then

                Else
                    Err = "Documento de Identificación Migratorio para Extranjeros( DIMEX) debe contener 11 o 12 dígitos, sin ceros al inicio y sin guiones"
                End If
            ElseIf Comb_TipoId.SelectedIndex = "04" Then

                If txtb_Cedula.Text.Length = 10 Then

                Else
                    Err = "Recepto_NumeroCedula El Documento de Identificación de la DGT( NITE) debe contener 10 dígitos y sin guiones"
                End If
            End If

            'Primero verificamos que el codigo del cliente no exista
            If Class_VariablesGlobales.Obj_Funciones_SQL.ExisteCliente(txtb_Codigo.Text) <> 0 And txtb_Consecutivo.Enabled = True Then

                Err = "El codigo " & txtb_Codigo.Text & "  ya existe en la base de datos"
            End If
            If Err = "" Then


                Dim CardCode As String = txtb_Codigo.Text
                Dim CardName As String = txtb_Nombre.Text
                Dim Cedula As String = txtb_Cedula.Text
                Dim Respolsabletributario As String = txtb_ResponsableTributario.Text
                Dim U_Visita As String = Comb_DiaVisita.SelectedIndex
                Dim U_ClaveWeb As String = txtb_CalveWeb.Text
                Dim Phone1 As String = txtb_Telfono1.Text
                Dim Phone2 As String = txtb_Telfono2.Text
                Dim Street As String = txtb_OtrasResenas.Text
                Dim E_Mail As String = txtb_email.Text
                Dim NameFicticio As String = txtb_NombreComercial.Text
                Dim Latitud As String = txtb_Latitud.Text
                Dim Longitud As String = txtb_Longitud.Text
                Dim Agente As String = txtb_Agente.Text
                Dim Id_Provincia As String = Combo_Provincia.SelectedIndex
                Dim Id_Canton As String = Combo_Canton.SelectedIndex
                Dim Id_Distrito As String = Combo_Distrito.SelectedIndex
                Dim Id_Barrio As String = Combo_Barrio.SelectedIndex
                Dim Estado As String = "Interno"
                Dim Tipo_Cedula As String = Comb_TipoId.SelectedIndex
                Dim Fecha As String = DTP_Fecha.Value.ToShortDateString
                Dim Hora As String = txtb_Hora.Text
                Dim Aprobado As String = 0
                Dim Consecutivo As String = txtb_Consecutivo.Text

                Dim EXO_TipoDocumento As String = CBox_ExoTipoDoc.Text
                Dim EXO_Numero As String = txtb_ExoNumero.Text
                Dim EXO_NombreInstitucion As String = txtb_ExoNombreInstitucion.Text
                Dim EXO_FechaEmision As String = DTP_ExoFechaEmision.Value.ToShortDateString
                Dim EXO_PorcentajeCompra As String
                Dim EnviarFE As Integer
                Dim TipoSocio As Integer
                If Comb_Tipo.Text = "CLIENTE" Then
                    TipoSocio = 1
                ElseIf Comb_Tipo.Text = "PROVEEDOR" Then
                    TipoSocio = 2
                End If


                If txtb_ExoPorcentajeCompra.Text = "" Then
                    EXO_PorcentajeCompra = "0"
                Else
                    EXO_PorcentajeCompra = txtb_ExoPorcentajeCompra.Text
                End If

                Dim Guardar As Boolean

                If txtb_Consecutivo.Enabled = True Then
                    Guardar = True
                Else
                    Guardar = False
                End If
                'Debemos Guardar un cliente en una tabla propia
                Dim fallo = Class_VariablesGlobales.Obj_Funciones_SQL.GuardaCliente(CardCode, CardName, Cedula, Respolsabletributario, U_Visita, U_ClaveWeb, Phone1, Phone2, Street, E_Mail, NameFicticio, Latitud, Longitud, Agente, Id_Provincia, Id_Canton, Id_Distrito, Id_Barrio, Estado, Tipo_Cedula, Fecha, Hora, Aprobado, Consecutivo, EXO_TipoDocumento, EXO_Numero, EXO_NombreInstitucion, EXO_FechaEmision, EXO_PorcentajeCompra, EnviarFE, TipoSocio, Guardar)

                If fallo <> 1 Then

                    If Guardar = True Then
                        'Aumenta consecutivo
                        Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaConsecutivoCliente(Class_VariablesGlobales.SQL_Comman2, CInt(txtb_Consecutivo.Text))
                    End If
                    CardCode = Nothing
                    CardName = Nothing
                    Cedula = Nothing
                    Respolsabletributario = Nothing
                    U_Visita = Nothing
                    U_ClaveWeb = Nothing
                    Phone1 = Nothing
                    Phone2 = Nothing
                    Street = Nothing
                    E_Mail = Nothing
                    NameFicticio = Nothing
                    Latitud = Nothing
                    Longitud = Nothing
                    Agente = Nothing
                    Id_Provincia = Nothing
                    Id_Canton = Nothing
                    Id_Distrito = Nothing
                    Id_Barrio = Nothing
                    Estado = Nothing
                    Tipo_Cedula = Nothing
                    Fecha = Nothing
                    Hora = Nothing
                    Aprobado = Nothing
                    Consecutivo = Nothing
                    EXO_TipoDocumento = Nothing
                    EXO_Numero = Nothing
                    EXO_NombreInstitucion = Nothing
                    EXO_FechaEmision = Nothing
                    EXO_PorcentajeCompra = Nothing
                    EnviarFE = Nothing

                    Limpiar()

                    MsgBox("Su socio del negocio se ha guardado con existo", MsgBoxStyle.Information, "Atención")

                End If
            Else
                MsgBox(Err, MsgBoxStyle.Critical, "Error!!!")

            End If
        End If
    End Sub

    Public Sub CreaSocioNegocio()
        If txtb_Codigo.Text = "" Then
            MsgBox("Debe indicar un codigo de cliente valido")
            txtb_Codigo.Focus()


        Else


            Dim result1 As DialogResult = MessageBox.Show(" Esta seguro que desea Crear un nuevo codigo de cliente en SAP? ?",
      "Important Question",
      MessageBoxButtons.YesNo)

            If result1 = DialogResult.Yes Then
                'conecta  a SAP
                'oCompany = obj_SAP.ConectarSap()
                Dim DiaVisita As String = ""
                Select Case Comb_DiaVisita.SelectedIndex
                    Case 1
                        DiaVisita = "01"
                    Case 2
                        DiaVisita = "02"
                    Case 3
                        DiaVisita = "03"
                    Case 4
                        DiaVisita = "04"
                    Case 5
                        DiaVisita = "05"
                    Case 6
                        DiaVisita = "06"
                End Select


                Dim Frecuencia As String = ""
                Select Case Comb_Frecuencia.SelectedIndex
                    Case 1
                        Frecuencia = "01"
                    Case 2
                        Frecuencia = "02"
                    Case 3
                        Frecuencia = "03"
                    Case 4
                        Frecuencia = "04"
                    Case 5
                        Frecuencia = "05"
                    Case 6
                        Frecuencia = "06"
                End Select


                If Class_VariablesGlobales.XMLParamSAP_CompanyDB <> "" Then
                    'obj_SAP.CreaSocioNegocio(txtb_Codigo.Text, txtb_Latitud.Text, txtb_Longitud.Text, txtb_email.Text, txtb_Telfono1.Text, txtb_Telfono2.Text, DiaVisita, txtb_CalveWeb.Text, txtb_Nombre.Text, txtb_Cedula.Text.PadLeft(12, "0"), txtb_ResponsableTributario.Text, txtb_OtrasResenas.Text, txtb_NombreComercial.Text, txtb_Hora.Text, txtb_id.Text, Comb_TipoId.SelectedIndex, Combo_Provincia.SelectedIndex, Combo_Canton.SelectedIndex, Combo_Distrito.SelectedIndex, Combo_Barrio.SelectedIndex, DTP_Fecha.Text, Frecuencia, txtb_Agente.Text, Class_VariablesGlobales.SQL_Comman2, Comb_Tipo.SelectedIndex) = 0 Then

                End If

                Obj_SQL_CONEXIONSERVER.ActualizoCliente(Class_VariablesGlobales.SQL_Comman2, txtb_Consecutivo.Text,
                                                        txtb_Codigo.Text, txtb_Nombre.Text, txtb_Cedula.Text.PadLeft(12, "0"),
                                                        txtb_ResponsableTributario.Text, DiaVisita, txtb_CalveWeb.Text,
                                                        txtb_Telfono1.Text, txtb_Telfono2.Text, txtb_OtrasResenas.Text, txtb_email.Text,
                                                         txtb_NombreComercial.Text, txtb_Latitud.Text, txtb_Longitud.Text, txtb_Agente.Text,
                                                         Combo_Provincia.SelectedIndex, Combo_Canton.SelectedIndex, Combo_Distrito.SelectedIndex, Combo_Barrio.SelectedIndex,
                                                          EstadoActivo, Comb_TipoId.SelectedIndex, DTP_Fecha.Value(), txtb_Hora.Text, 1,
                                                         Comb_Tipo.SelectedIndex, CBox_ExoTipoDoc.SelectedIndex, txtb_ExoNumero.Text(),
                                                         txtb_ExoNombreInstitucion.Text(), DTP_ExoFechaEmision.Value(), txtb_ExoPorcentajeCompra.Text())
                limpia()
                'Else
                'End If
            End If
            If result1 = DialogResult.No Then


            End If
        End If
    End Sub

    Public Sub ModificaCliente()

        Dim result1 As DialogResult
        result1 = MessageBox.Show("El Cliente se modificara en SAP \n Realmente desea Modificar este cliente en SAP?", _
        "Important Question", _
        MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then

            'conecta  a SAP
            'oCompany = obj_SAP.ConectarSap()
            Dim DiaVisita As String = ""
            Select Case Comb_DiaVisita.SelectedIndex
                Case 1
                    DiaVisita = "01"
                Case 2
                    DiaVisita = "02"
                Case 3
                    DiaVisita = "03"
                Case 4
                    DiaVisita = "04"
                Case 5
                    DiaVisita = "05"
                Case 6
                    DiaVisita = "06"
            End Select

            Dim Err As String = ""
            If Comb_TipoId.SelectedIndex = "01" Then

                If txtb_Cedula.Text.Length = 9 Then
                Else
                    Err = "La Cédula física debe de contener 9 dígitos, sin cero al inicio y sin guiones"
                End If

            ElseIf Comb_TipoId.SelectedIndex = "02" Then

                If txtb_Cedula.Text.Length = 10 Then

                Else
                    Err = "La cédula de personas Jurídicas debe contener 10 dígitos y sin guiones "
                End If
            ElseIf Comb_TipoId.SelectedIndex = "03" Then

                If txtb_Cedula.Text.Length = 11 Or txtb_Cedula.Text.Length = 12 Then

                Else
                    Err = "Documento de Identificación Migratorio para Extranjeros( DIMEX) debe contener 11 o 12 dígitos, sin ceros al inicio y sin guiones"
                End If
            ElseIf Comb_TipoId.SelectedIndex = "04" Then

                If txtb_Cedula.Text.Length = 10 Then

                Else
                    Err = "Recepto_NumeroCedula El Documento de Identificación de la DGT( NITE) debe contener 10 dígitos y sin guiones"
                End If
            End If

            Dim LineContacto As Integer

            LineContacto = Obj_SQL_CONEXIONSERVER.ObtieneLineaContacto(txtb_Codigo.Text, Class_VariablesGlobales.SQL_Comman2)

            'If obj_SAP.ModificaSocioNegocio(LineContacto, txtb_Codigo.Text, txtb_Latitud.Text, txtb_Longitud.Text, txtb_email.Text, txtb_Telfono1.Text, txtb_Telfono2.Text, DiaVisita, txtb_CalveWeb.Text, txtb_Nombre.Text, txtb_Cedula.Text, txtb_ResponsableTributario.Text, txtb_OtrasResenas.Text, txtb_NombreComercial.Text, txtb_Hora.Text, txtb_id.Text, Comb_TipoId.SelectedIndex, Combo_Provincia.SelectedIndex, Combo_Canton.SelectedIndex, Combo_Distrito.SelectedIndex, Combo_Barrio.SelectedIndex, DTP_Fecha.Text, Class_VariablesGlobales.SQL_Comman2) = 0 Then
            Obj_SQL_CONEXIONSERVER.ActualizoCliente(Class_VariablesGlobales.SQL_Comman2, txtb_Consecutivo.Text,
                                                        txtb_Codigo.Text, txtb_Nombre.Text, txtb_Cedula.Text.PadLeft(12, "0"),
                                                        txtb_ResponsableTributario.Text, DiaVisita, txtb_CalveWeb.Text,
                                                        txtb_Telfono1.Text, txtb_Telfono2.Text, txtb_OtrasResenas.Text, txtb_email.Text,
                                                         txtb_NombreComercial.Text, txtb_Latitud.Text, txtb_Longitud.Text, txtb_Agente.Text,
                                                         Combo_Provincia.SelectedIndex, Combo_Canton.SelectedIndex, Combo_Distrito.SelectedIndex, Combo_Barrio.SelectedIndex,
                                                         EstadoActivo, Comb_TipoId.SelectedIndex, DTP_Fecha.Value(), txtb_Hora.Text, 1,
                                                         Comb_Tipo.SelectedIndex, CBox_ExoTipoDoc.SelectedIndex, txtb_ExoNumero.Text(),
                                                         txtb_ExoNombreInstitucion.Text(), DTP_ExoFechaEmision.Value(), txtb_ExoPorcentajeCompra.Text())

            limpia()
                'Else
                '    'error
                'End If

            End If
        If result1 = DialogResult.No Then

        End If
    End Sub

    Private Sub txtb_Nombre_TextChanged(sender As Object, e As EventArgs) Handles txtb_Nombre.TextChanged
        Me.txtb_Nombre.Text = UCase(Me.txtb_Nombre.Text)
        Me.txtb_Nombre.SelectionStart = Me.txtb_Nombre.TextLength + 1
    End Sub

    Private Sub txtb_NombreComercial_TextChanged(sender As Object, e As EventArgs) Handles txtb_NombreComercial.TextChanged
        Me.txtb_NombreComercial.Text = UCase(Me.txtb_NombreComercial.Text)
        Me.txtb_NombreComercial.SelectionStart = Me.txtb_NombreComercial.TextLength + 1
    End Sub

    Private Sub txtb_ResponsableTributario_TextChanged(sender As Object, e As EventArgs) Handles txtb_ResponsableTributario.TextChanged
        Me.txtb_ResponsableTributario.Text = UCase(Me.txtb_ResponsableTributario.Text)
        Me.txtb_ResponsableTributario.SelectionStart = Me.txtb_ResponsableTributario.TextLength + 1
    End Sub

    Private Sub txtb_Codigo_TextChanged(sender As Object, e As EventArgs) Handles txtb_Codigo.TextChanged
        Me.txtb_Codigo.Text = UCase(Me.txtb_Codigo.Text)
        Me.txtb_Codigo.SelectionStart = Me.txtb_Codigo.TextLength + 1
    End Sub

    Private Sub btn_Nuevo_Click(sender As Object, e As EventArgs) Handles btn_Nuevo.Click
        Limpiar()

        txtb_Consecutivo.Text = Obj_SQL_CONEXIONSERVER.ObtieneConsecutivoCliente(Class_VariablesGlobales.SQL_Comman2)

    End Sub

    Public Function Limpiar()
        Try


            btn_Actualizar.Text = "Guardar"

            txtb_Codigo.Text = ""
            txtb_Nombre.Text = ""
            txtb_Cedula.Text = ""
            txtb_ResponsableTributario.Text = ""

            txtb_CalveWeb.Text = ""
            txtb_Telfono1.Text = ""
            txtb_Telfono2.Text = ""
            txtb_OtrasResenas.Text = ""
            txtb_email.Text = ""
            txtb_NombreComercial.Text = ""
            txtb_Latitud.Text = ""
            txtb_Longitud.Text = ""
            DTP_Fecha.Text = Now.Date
            txtb_Hora.Text = ""
            txtb_Consecutivo.Text = ""

            'Obtenemos las provincias
            '---------PROVINCIAS-------------
            With Combo_Provincia
                .DataSource = Obj_SQL_CONEXIONSERVER.ObtieneProvincias(Class_VariablesGlobales.SQL_Comman2, 0)
                .DisplayMember = "nombre_provincia"
                .ValueMember = "id_provincia"
            End With

            Combo_Provincia.SelectedIndex = 0
            Combo_Canton.SelectedIndex = 0
            Combo_Distrito.SelectedIndex = 0
            Combo_Barrio.SelectedIndex = 0
            Comb_TipoId.SelectedIndex = 0
            Comb_DiaVisita.SelectedIndex = 0
            Comb_Tipo.SelectedIndex = 0


        Catch ex As Exception

        End Try
    End Function

    Private Sub Label28_Click(sender As Object, e As EventArgs) Handles Label28.Click

    End Sub



    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        'ANULA EL MOVIMIENTO PARA QUE DEJE DE APARECER EN LA LISTA
        Dim DiaVisita As String = ""
        Select Case Comb_DiaVisita.SelectedIndex
            Case 1
                DiaVisita = "01"
            Case 2
                DiaVisita = "02"
            Case 3
                DiaVisita = "03"
            Case 4
                DiaVisita = "04"
            Case 5
                DiaVisita = "05"
            Case 6
                DiaVisita = "06"
        End Select

        Obj_SQL_CONEXIONSERVER.ActualizoCliente(Class_VariablesGlobales.SQL_Comman2, txtb_Consecutivo.Text,
                                                        txtb_Codigo.Text, txtb_Nombre.Text, txtb_Cedula.Text.PadLeft(12, "0"),
                                                        txtb_ResponsableTributario.Text, DiaVisita, txtb_CalveWeb.Text,
                                                        txtb_Telfono1.Text, txtb_Telfono2.Text, txtb_OtrasResenas.Text, txtb_email.Text,
                                                         txtb_NombreComercial.Text, txtb_Latitud.Text, txtb_Longitud.Text, txtb_Agente.Text,
                                                         Combo_Provincia.SelectedIndex, Combo_Canton.SelectedIndex, Combo_Distrito.SelectedIndex, Combo_Barrio.SelectedIndex,
                                                         EstadoInactivo, Comb_TipoId.SelectedIndex, DTP_Fecha.Value(), txtb_Hora.Text, 1,
                                                         Comb_Tipo.SelectedIndex, CBox_ExoTipoDoc.SelectedIndex, txtb_ExoNumero.Text(),
                                                         txtb_ExoNombreInstitucion.Text(), DTP_ExoFechaEmision.Value(), txtb_ExoPorcentajeCompra.Text())
        MsgBox("El cliente fue Anulado")
        Limpiar()

    End Sub

    Public Sub CerrarCliente()

        Dim DiaVisita As String = ""
        Select Case Comb_DiaVisita.SelectedIndex
            Case 1
                DiaVisita = "01"
            Case 2
                DiaVisita = "02"
            Case 3
                DiaVisita = "03"
            Case 4
                DiaVisita = "04"
            Case 5
                DiaVisita = "05"
            Case 6
                DiaVisita = "06"
        End Select

        Dim result1 As DialogResult
        result1 = MessageBox.Show("El Cliente se cerrara y no se lo podra vender mas\n Realmente desea Cerrar este cliente en SAP?",
        "Important Question",
        MessageBoxButtons.YesNo)


        If result1 = DialogResult.Yes Then
            'Cambia el agente a Cerrado
            'conecta  a SAP
            'oCompany = obj_SAP.ConectarSap()
            'If obj_SAP.CerrarSocioNegocio(txtb_Codigo.Text, Class_VariablesGlobales.SQL_Comman2) = 0 Then


            Obj_SQL_CONEXIONSERVER.ActualizoCliente(Class_VariablesGlobales.SQL_Comman2, txtb_Consecutivo.Text,
                                                        txtb_Codigo.Text, txtb_Nombre.Text, txtb_Cedula.Text.PadLeft(12, "0"),
                                                        txtb_ResponsableTributario.Text, DiaVisita, txtb_CalveWeb.Text,
                                                        txtb_Telfono1.Text, txtb_Telfono2.Text, txtb_OtrasResenas.Text, txtb_email.Text,
                                                         txtb_NombreComercial.Text, txtb_Latitud.Text, txtb_Longitud.Text, txtb_Agente.Text,
                                                         Combo_Provincia.SelectedIndex, Combo_Canton.SelectedIndex, Combo_Distrito.SelectedIndex, Combo_Barrio.SelectedIndex,
                                                         EstadoInactivo, Comb_TipoId.SelectedIndex, DTP_Fecha.Value(), txtb_Hora.Text, 1,
                                                         Comb_Tipo.SelectedIndex, CBox_ExoTipoDoc.SelectedIndex, txtb_ExoNumero.Text(),
                                                         txtb_ExoNombreInstitucion.Text(), DTP_ExoFechaEmision.Value(), txtb_ExoPorcentajeCompra.Text())

            limpia()
            'Else
            '    'error
            'End If

        End If
        If result1 = DialogResult.No Then


        End If

    End Sub

    Public Function limpia()
        Try

       
            txtb_Codigo.Text = ""
            txtb_Nombre.Text = ""
            txtb_Cedula.Text = ""
            txtb_ResponsableTributario.Text = ""
            txtb_CalveWeb.Text = ""
            txtb_Telfono1.Text = ""
            txtb_Telfono2.Text = ""
            txtb_OtrasResenas.Text = ""
            txtb_email.Text = ""
            txtb_NombreComercial.Text = ""
            txtb_Latitud.Text = ""
            txtb_Longitud.Text = ""
            txtb_Hora.Text = ""
            txtb_id.Text = ""


            Comb_TipoId.SelectedIndex = 0
            Comb_DiaVisita.SelectedIndex = 0
            Combo_Provincia.SelectedIndex = 0
            Combo_Canton.SelectedIndex = 0
            Combo_Distrito.SelectedIndex = 0
            Combo_Barrio.SelectedIndex = 0

            DTP_Fecha.Text = Now

        Catch ex As Exception

        End Try
    End Function


End Class