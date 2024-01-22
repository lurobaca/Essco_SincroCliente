Public Class Lista_ClientesModificados
    Public Obj_SQL_CONEXIONSERVER As New Class_funcionesSQL
    Private Sub Lista_ClientesModificados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            DGV_ListaClientesModificados.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneClientesModificados(CBX_Estado.Text, Class_VariablesGlobales.SQL_Comman2, 0, False, 1, "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_INI.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FIN.Value.Date), TXTB_AGENTE.Text, CheckBox_Aprovados.Checked, Cbx_BuscaXFecha.Checked)

            '[CardCode],[CardName],[Cedula],[Respolsabletributario],[U_Visita],[U_ClaveWeb],[Phone1],[Phone2],[Street],[E_Mail],[NameFicticio],[Latitud],[Longitud],[Agente],[Id_Provincia],[Id_Canton],[Id_Distrito],[Id_Barrio],[Estado],[Tipo_Cedula],[Fecha],[Hora],[Aprobado],[id]
            DGV_ListaClientesModificados.Columns(0).Width = 100
            DGV_ListaClientesModificados.Columns(1).Width = 100
            DGV_ListaClientesModificados.Columns(2).Width = 300
            DGV_ListaClientesModificados.Columns(3).Width = 100
            DGV_ListaClientesModificados.Columns(4).Width = 300
            DGV_ListaClientesModificados.Columns(5).Width = 20
            DGV_ListaClientesModificados.Columns(6).Width = 100
            DGV_ListaClientesModificados.Columns(7).Width = 80
            DGV_ListaClientesModificados.Columns(8).Width = 80
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV_ListaClientesModificados_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_ListaClientesModificados.CellContentClick
        Try
            If CBX_Estado.Text = "Interno" And Class_VariablesGlobales.ClientesLlamadoDesde = "Facturacion" Then
                'Manda los datos a la ventana de facturacion
                Class_VariablesGlobales.frmFacturacion.txtb_CodCliente.Text = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(1).Value)
                Class_VariablesGlobales.frmFacturacion.txtb_Nombre.Text = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(4).Value)
                Class_VariablesGlobales.frmFacturacion.txtb_NombreFantacia.Text = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(2).Value)
                Class_VariablesGlobales.frmFacturacion.btn_guardar.Text = "Guardar"

                Class_VariablesGlobales.frmFacturacion.Receptor_Nombre = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(2).Value)
                Class_VariablesGlobales.frmFacturacion.Receptor_NombreComercial = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(11).Value)
                Class_VariablesGlobales.frmFacturacion.Receptor_Tipo = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(20).Value).ToString().PadLeft(2, "0")
                Class_VariablesGlobales.frmFacturacion.Receptor_Numero = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(3).Value)
                Class_VariablesGlobales.frmFacturacion.Receptor_IdentificacionExtranjero = ""
                Class_VariablesGlobales.frmFacturacion.Receptor_Provincia = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(15).Value)
                Class_VariablesGlobales.frmFacturacion.Receptor_Canton = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(16).Value).ToString().PadLeft(2, "0")
                Class_VariablesGlobales.frmFacturacion.Receptor_Distrito = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(17).Value).ToString().PadLeft(2, "0")
                Class_VariablesGlobales.frmFacturacion.Receptor_Barrio = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(18).Value).ToString().PadLeft(2, "0")
                Class_VariablesGlobales.frmFacturacion.Receptor_OtrasSenas = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(9).Value)
                Class_VariablesGlobales.frmFacturacion.Receptor_CorreoElectronico = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(10).Value)



            Else






                '[CardCode],[CardName],[Cedula],[Respolsabletributario],[U_Visita],[U_ClaveWeb],[Phone1],[Phone2],[Street],
                '[E_Mail], [NameFicticio], [Latitud], [Longitud], [Agente], [Id_Provincia], [Id_Canton], [Id_Distrito], [Id_Barrio], [Estado], [Tipo_Cedula],
                '[Fecha], [Hora], [Aprobado], [id]

                Dim Id_Provincia, Id_Canton, Id_Distrito, Id_Barrio, Id_DiaVisita, Id_TipoID, Id_TipoSocio, Id_TipoDocumentoExoneracion As Integer

                Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_Consecutivo.Text = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(0).Value)
                Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_Codigo.Text = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(1).Value)
                Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_Nombre.Text = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(2).Value)
                Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_Cedula.Text = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(3).Value)
                Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_ResponsableTributario.Text = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(4).Value)

                Id_DiaVisita = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(5).Value)
                Class_VariablesGlobales.frmAdmin_ClientesModificados.Comb_DiaVisita.SelectedIndex = Id_DiaVisita

                Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_CalveWeb.Text = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(6).Value)
                Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_Telfono1.Text = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(7).Value)
                Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_Telfono2.Text = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(8).Value)
                Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_OtrasResenas.Text = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(9).Value)
                Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_email.Text = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(10).Value)
                Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_NombreComercial.Text = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(11).Value)
                Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_Latitud.Text = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(12).Value)
                Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_Longitud.Text = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(13).Value)
                Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_Agente.Text = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(14).Value)
                Class_VariablesGlobales.frmAdmin_ClientesModificados.lbl_Estado.Text = CBX_Estado.Text
                Class_VariablesGlobales.frmAdmin_ClientesModificados.btn_Actualizar.Text = CBX_Estado.Text

                Class_VariablesGlobales.frmAdmin_ClientesModificados.lbl_Estado.Visible = True

                Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_Saldo.Text = Obj_SQL_CONEXIONSERVER.ObtieneSaldoCuenta(Class_VariablesGlobales.SQL_Comman2, Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_Codigo.Text, CBX_Estado.Text)

                If Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_Saldo.Text <> "" And Class_VariablesGlobales.frmAdmin_ClientesModificados.lbl_Estado.Text = "Cerrar" Then
                    Class_VariablesGlobales.frmAdmin_ClientesModificados.btn_Actualizar.Enabled = False
                Else

                End If
                If Class_VariablesGlobales.frmAdmin_ClientesModificados.lbl_Estado.Text = "Cerrar" Then
                    Class_VariablesGlobales.frmAdmin_ClientesModificados.btn_Actualizar.Text = "Cerrar Cliente en SAP"
                End If
                If Class_VariablesGlobales.frmAdmin_ClientesModificados.lbl_Estado.Text = "Modificado" Then
                    Class_VariablesGlobales.frmAdmin_ClientesModificados.btn_Actualizar.Text = "Modificar Cliente en SAP"
                End If
                If Class_VariablesGlobales.frmAdmin_ClientesModificados.lbl_Estado.Text = "Nuevo" Then
                    Class_VariablesGlobales.frmAdmin_ClientesModificados.btn_Actualizar.Text = "Crear Cliente en SAP"
                    Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_Codigo.Text = ""

                End If
                If Class_VariablesGlobales.frmAdmin_ClientesModificados.lbl_Estado.Text = "Interno" Then
                    Class_VariablesGlobales.frmAdmin_ClientesModificados.btn_Actualizar.Text = "Guardar"
                End If

                'Obtenemos las provincias
                '---------PROVINCIAS-------------
                Try
                    With Class_VariablesGlobales.frmAdmin_ClientesModificados.Combo_Provincia
                        .DataSource = Obj_SQL_CONEXIONSERVER.ObtieneProvincias(Class_VariablesGlobales.SQL_Comman2, 0)
                        .DisplayMember = "nombre_provincia"
                        .ValueMember = "id_provincia"
                    End With
                    Id_Provincia = CInt(Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(15).Value))
                    'If Id_Provincia - 1 >= 0 Then
                    '    Id_Provincia = Id_Provincia - 1
                    'End If
                    Class_VariablesGlobales.frmAdmin_ClientesModificados.Combo_Provincia.SelectedIndex = Id_Provincia
                Catch ex As Exception

                End Try
                '---------CANTONES-------------
                Try
                    With Class_VariablesGlobales.frmAdmin_ClientesModificados.Combo_Canton
                        .DataSource = Obj_SQL_CONEXIONSERVER.ObtieneCantones(Class_VariablesGlobales.SQL_Comman2, Id_Provincia, 0)
                        .DisplayMember = "nombre_canton"
                        .ValueMember = "id_canton"
                    End With
                    Id_Canton = CInt(Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(16).Value))
                    'If Id_Canton - 1 >= 0 Then
                    '    Id_Canton = Id_Canton - 1
                    'End If
                    Class_VariablesGlobales.frmAdmin_ClientesModificados.Combo_Canton.SelectedIndex = Id_Canton
                Catch ex As Exception

                End Try
                '---------DISTRITOS-------------
                Try
                    With Class_VariablesGlobales.frmAdmin_ClientesModificados.Combo_Distrito
                        .DataSource = Obj_SQL_CONEXIONSERVER.ObtieneDistritos(Class_VariablesGlobales.SQL_Comman2, Id_Provincia, Id_Canton, 0)
                        .DisplayMember = "nombre_distrito"
                        .ValueMember = "id_distrito"
                    End With
                    Id_Distrito = CInt(Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(17).Value))
                    'If Id_Distrito - 1 >= 0 Then
                    '    Id_Distrito = Id_Distrito - 1
                    'End If
                    Class_VariablesGlobales.frmAdmin_ClientesModificados.Combo_Distrito.SelectedIndex = Id_Distrito
                Catch ex As Exception

                End Try

                '---------BARRIOS-------------
                Try


                    With Class_VariablesGlobales.frmAdmin_ClientesModificados.Combo_Barrio
                        .DataSource = Obj_SQL_CONEXIONSERVER.ObtieneBarrios(Class_VariablesGlobales.SQL_Comman2, Id_Provincia, Id_Canton, Id_Distrito, 0)
                        .DisplayMember = "nombre_barrio"
                        .ValueMember = "id_barrio"
                    End With
                    Id_Barrio = CInt(Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(18).Value))
                    'If Id_Barrio - 1 >= 0 Then
                    '    Id_Barrio = Id_Barrio - 1
                    'End If
                    Class_VariablesGlobales.frmAdmin_ClientesModificados.Combo_Barrio.SelectedIndex = Id_Barrio
                Catch ex As Exception

                End Try


                Id_TipoID = CInt(Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(20).Value))
                Class_VariablesGlobales.frmAdmin_ClientesModificados.Comb_TipoId.SelectedIndex = Id_TipoID

                Id_TipoSocio = CInt(Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(25).Value))
                Class_VariablesGlobales.frmAdmin_ClientesModificados.Comb_Tipo.SelectedIndex = CInt(Id_TipoSocio)



                Class_VariablesGlobales.frmAdmin_ClientesModificados.DTP_Fecha.Text = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(21).Value)
                Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_Hora.Text = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(22).Value)
                Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_id.Text = Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(24).Value)

                If DGV_ListaClientesModificados.CurrentRow.Cells.Item(26).Value.ToString() <> "" Then

                    Id_TipoDocumentoExoneracion = If(Integer.TryParse(Trim(DGV_ListaClientesModificados.CurrentRow.Cells.Item(26).Value.ToString()), Id_TipoDocumentoExoneracion), Id_TipoDocumentoExoneracion, 0)

                Else
                    Id_TipoDocumentoExoneracion = -1
                End If


                Class_VariablesGlobales.frmAdmin_ClientesModificados.DGV_DocumentosExoneracion.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneDocumentosExoneracionDeClientes(Class_VariablesGlobales.frmAdmin_ClientesModificados.txtb_Codigo.Text)

            End If
            Me.Close()

        Catch ex As Exception
            MsgBox("ERROR DGV_ListaClientesModificados_CellContentClick ( " & ex.Message & " )")

        End Try
    End Sub

    Private Sub CBX_Estado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBX_Estado.SelectedIndexChanged
        Try


            DGV_ListaClientesModificados.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneClientesModificados(Trim(CBX_Estado.Text), Class_VariablesGlobales.SQL_Comman2, 0, False, 1, "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_INI.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FIN.Value.Date), TXTB_AGENTE.Text, CheckBox_Aprovados.Checked, Cbx_BuscaXFecha.Checked)

            '[CardCode],[CardName],[Cedula],[Respolsabletributario],[U_Visita],[U_ClaveWeb],[Phone1],[Phone2],[Street],[E_Mail],[NameFicticio],[Latitud],[Longitud],[Agente],[Id_Provincia],[Id_Canton],[Id_Distrito],[Id_Barrio],[Estado],[Tipo_Cedula],[Fecha],[Hora],[Aprobado],[id]
            DGV_ListaClientesModificados.Columns(0).Width = 100
            DGV_ListaClientesModificados.Columns(1).Width = 100
            DGV_ListaClientesModificados.Columns(2).Width = 300
            DGV_ListaClientesModificados.Columns(3).Width = 100
            DGV_ListaClientesModificados.Columns(4).Width = 300
            DGV_ListaClientesModificados.Columns(5).Width = 20
            DGV_ListaClientesModificados.Columns(6).Width = 100
            DGV_ListaClientesModificados.Columns(7).Width = 80
            DGV_ListaClientesModificados.Columns(8).Width = 80
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtb_buscar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_buscar.KeyPress
        Try


            If rb_Codigo.Checked Then
                DGV_ListaClientesModificados.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneClientesModificados("Modificado", Class_VariablesGlobales.SQL_Comman2, 0, True, 1, txtb_buscar.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_INI.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FIN.Value.Date), TXTB_AGENTE.Text, CheckBox_Aprovados.Checked, Cbx_BuscaXFecha.Checked)
            Else
                DGV_ListaClientesModificados.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneClientesModificados("Modificado", Class_VariablesGlobales.SQL_Comman2, 0, True, 0, txtb_buscar.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_INI.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FIN.Value.Date), TXTB_AGENTE.Text, CheckBox_Aprovados.Checked, Cbx_BuscaXFecha.Checked)
            End If

            DGV_ListaClientesModificados.Columns(0).Width = 100
            DGV_ListaClientesModificados.Columns(1).Width = 100
            DGV_ListaClientesModificados.Columns(2).Width = 300
            DGV_ListaClientesModificados.Columns(3).Width = 100
            DGV_ListaClientesModificados.Columns(4).Width = 300
            DGV_ListaClientesModificados.Columns(5).Width = 20
            DGV_ListaClientesModificados.Columns(6).Width = 100
            DGV_ListaClientesModificados.Columns(7).Width = 80
            DGV_ListaClientesModificados.Columns(8).Width = 80
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Try
            DGV_ListaClientesModificados.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneClientesModificados("Modificado", Class_VariablesGlobales.SQL_Comman2, 0, False, 1, "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_INI.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FIN.Value.Date), TXTB_AGENTE.Text, CheckBox_Aprovados.Checked, Cbx_BuscaXFecha.Checked)
            txtb_buscar.Text = ""
            '[CardCode],[CardName],[Cedula],[Respolsabletributario],[U_Visita],[U_ClaveWeb],[Phone1],[Phone2],[Street],[E_Mail],[NameFicticio],[Latitud],[Longitud],[Agente],[Id_Provincia],[Id_Canton],[Id_Distrito],[Id_Barrio],[Estado],[Tipo_Cedula],[Fecha],[Hora],[Aprobado],[id]
            DGV_ListaClientesModificados.Columns(0).Width = 100
            DGV_ListaClientesModificados.Columns(1).Width = 100
            DGV_ListaClientesModificados.Columns(2).Width = 300
            DGV_ListaClientesModificados.Columns(3).Width = 100
            DGV_ListaClientesModificados.Columns(4).Width = 300
            DGV_ListaClientesModificados.Columns(5).Width = 20
            DGV_ListaClientesModificados.Columns(6).Width = 100
            DGV_ListaClientesModificados.Columns(7).Width = 80
            DGV_ListaClientesModificados.Columns(8).Width = 80
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rb_Codigo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_Codigo.CheckedChanged
        Try


            DGV_ListaClientesModificados.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneClientesModificados("Modificado", Class_VariablesGlobales.SQL_Comman2, 0, False, 1, "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_INI.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FIN.Value.Date), TXTB_AGENTE.Text, CheckBox_Aprovados.Checked, Cbx_BuscaXFecha.Checked)

            '[CardCode],[CardName],[Cedula],[Respolsabletributario],[U_Visita],[U_ClaveWeb],[Phone1],[Phone2],[Street],[E_Mail],[NameFicticio],[Latitud],[Longitud],[Agente],[Id_Provincia],[Id_Canton],[Id_Distrito],[Id_Barrio],[Estado],[Tipo_Cedula],[Fecha],[Hora],[Aprobado],[id]
            DGV_ListaClientesModificados.Columns(0).Width = 100
            DGV_ListaClientesModificados.Columns(1).Width = 100
            DGV_ListaClientesModificados.Columns(2).Width = 300
            DGV_ListaClientesModificados.Columns(3).Width = 100
            DGV_ListaClientesModificados.Columns(4).Width = 300
            DGV_ListaClientesModificados.Columns(5).Width = 20
            DGV_ListaClientesModificados.Columns(6).Width = 100
            DGV_ListaClientesModificados.Columns(7).Width = 80
            DGV_ListaClientesModificados.Columns(8).Width = 80
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rb_nombre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_nombre.CheckedChanged
        Try


            DGV_ListaClientesModificados.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneClientesModificados("Modificado", Class_VariablesGlobales.SQL_Comman2, 0, False, 1, "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_INI.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FIN.Value.Date), TXTB_AGENTE.Text, CheckBox_Aprovados.Checked, Cbx_BuscaXFecha.Checked)

            '[CardCode],[CardName],[Cedula],[Respolsabletributario],[U_Visita],[U_ClaveWeb],[Phone1],[Phone2],[Street],[E_Mail],[NameFicticio],[Latitud],[Longitud],[Agente],[Id_Provincia],[Id_Canton],[Id_Distrito],[Id_Barrio],[Estado],[Tipo_Cedula],[Fecha],[Hora],[Aprobado],[id]
            DGV_ListaClientesModificados.Columns(0).Width = 100
            DGV_ListaClientesModificados.Columns(1).Width = 100
            DGV_ListaClientesModificados.Columns(2).Width = 300
            DGV_ListaClientesModificados.Columns(3).Width = 100
            DGV_ListaClientesModificados.Columns(4).Width = 300
            DGV_ListaClientesModificados.Columns(5).Width = 20
            DGV_ListaClientesModificados.Columns(6).Width = 100
            DGV_ListaClientesModificados.Columns(7).Width = 80
            DGV_ListaClientesModificados.Columns(8).Width = 80
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DTP_FIN_ValueChanged(sender As Object, e As EventArgs) Handles DTP_FIN.ValueChanged
        Try


            DGV_ListaClientesModificados.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneClientesModificados(Trim(CBX_Estado.Text), Class_VariablesGlobales.SQL_Comman2, 0, False, 1, "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_INI.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FIN.Value.Date), TXTB_AGENTE.Text, CheckBox_Aprovados.Checked, Cbx_BuscaXFecha.Checked)

            '[CardCode],[CardName],[Cedula],[Respolsabletributario],[U_Visita],[U_ClaveWeb],[Phone1],[Phone2],[Street],[E_Mail],[NameFicticio],[Latitud],[Longitud],[Agente],[Id_Provincia],[Id_Canton],[Id_Distrito],[Id_Barrio],[Estado],[Tipo_Cedula],[Fecha],[Hora],[Aprobado],[id]
            DGV_ListaClientesModificados.Columns(0).Width = 100
            DGV_ListaClientesModificados.Columns(1).Width = 100
            DGV_ListaClientesModificados.Columns(2).Width = 300
            DGV_ListaClientesModificados.Columns(3).Width = 100
            DGV_ListaClientesModificados.Columns(4).Width = 300
            DGV_ListaClientesModificados.Columns(5).Width = 20
            DGV_ListaClientesModificados.Columns(6).Width = 100
            DGV_ListaClientesModificados.Columns(7).Width = 80
            DGV_ListaClientesModificados.Columns(8).Width = 80
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DTP_INI_ValueChanged(sender As Object, e As EventArgs) Handles DTP_INI.ValueChanged
        Try


            DGV_ListaClientesModificados.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneClientesModificados(Trim(CBX_Estado.Text), Class_VariablesGlobales.SQL_Comman2, 0, False, 1, "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_INI.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FIN.Value.Date), TXTB_AGENTE.Text, CheckBox_Aprovados.Checked, Cbx_BuscaXFecha.Checked)

            '[CardCode],[CardName],[Cedula],[Respolsabletributario],[U_Visita],[U_ClaveWeb],[Phone1],[Phone2],[Street],[E_Mail],[NameFicticio],[Latitud],[Longitud],[Agente],[Id_Provincia],[Id_Canton],[Id_Distrito],[Id_Barrio],[Estado],[Tipo_Cedula],[Fecha],[Hora],[Aprobado],[id]
            DGV_ListaClientesModificados.Columns(0).Width = 100
            DGV_ListaClientesModificados.Columns(1).Width = 100
            DGV_ListaClientesModificados.Columns(2).Width = 300
            DGV_ListaClientesModificados.Columns(3).Width = 100
            DGV_ListaClientesModificados.Columns(4).Width = 300
            DGV_ListaClientesModificados.Columns(5).Width = 20
            DGV_ListaClientesModificados.Columns(6).Width = 100
            DGV_ListaClientesModificados.Columns(7).Width = 80
            DGV_ListaClientesModificados.Columns(8).Width = 80
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TXTB_AGENTE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTB_AGENTE.KeyPress
        Try
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
                SendKeys.Send("{TAB}")
                e.Handled = True

                DGV_ListaClientesModificados.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneClientesModificados(Trim(CBX_Estado.Text), Class_VariablesGlobales.SQL_Comman2, 0, False, 1, "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_INI.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FIN.Value.Date), TXTB_AGENTE.Text, CheckBox_Aprovados.Checked, Cbx_BuscaXFecha.Checked)

                '[CardCode],[CardName],[Cedula],[Respolsabletributario],[U_Visita],[U_ClaveWeb],[Phone1],[Phone2],[Street],[E_Mail],[NameFicticio],[Latitud],[Longitud],[Agente],[Id_Provincia],[Id_Canton],[Id_Distrito],[Id_Barrio],[Estado],[Tipo_Cedula],[Fecha],[Hora],[Aprobado],[id]
                DGV_ListaClientesModificados.Columns(0).Width = 100
                DGV_ListaClientesModificados.Columns(1).Width = 100
                DGV_ListaClientesModificados.Columns(2).Width = 300
                DGV_ListaClientesModificados.Columns(3).Width = 100
                DGV_ListaClientesModificados.Columns(4).Width = 300
                DGV_ListaClientesModificados.Columns(5).Width = 20
                DGV_ListaClientesModificados.Columns(6).Width = 100
                DGV_ListaClientesModificados.Columns(7).Width = 80
                DGV_ListaClientesModificados.Columns(8).Width = 80


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox_Aprovados_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Aprovados.CheckedChanged
        Try


            DGV_ListaClientesModificados.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneClientesModificados(Trim(CBX_Estado.Text), Class_VariablesGlobales.SQL_Comman2, 0, False, 1, "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_INI.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FIN.Value.Date), TXTB_AGENTE.Text, CheckBox_Aprovados.Checked, Cbx_BuscaXFecha.Checked)

            '[CardCode],[CardName],[Cedula],[Respolsabletributario],[U_Visita],[U_ClaveWeb],[Phone1],[Phone2],[Street],[E_Mail],[NameFicticio],[Latitud],[Longitud],[Agente],[Id_Provincia],[Id_Canton],[Id_Distrito],[Id_Barrio],[Estado],[Tipo_Cedula],[Fecha],[Hora],[Aprobado],[id]
            DGV_ListaClientesModificados.Columns(0).Width = 100
            DGV_ListaClientesModificados.Columns(1).Width = 100
            DGV_ListaClientesModificados.Columns(2).Width = 300
            DGV_ListaClientesModificados.Columns(3).Width = 100
            DGV_ListaClientesModificados.Columns(4).Width = 300
            DGV_ListaClientesModificados.Columns(5).Width = 20
            DGV_ListaClientesModificados.Columns(6).Width = 100
            DGV_ListaClientesModificados.Columns(7).Width = 80
            DGV_ListaClientesModificados.Columns(8).Width = 80
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cbx_BuscaXFecha_CheckedChanged(sender As Object, e As EventArgs) Handles Cbx_BuscaXFecha.CheckedChanged
        Try
            If Cbx_BuscaXFecha.Checked = True Then
                DTP_FIN.Enabled = True
                DTP_INI.Enabled = True
            Else
                DTP_FIN.Enabled = False
                DTP_INI.Enabled = False
            End If


            DGV_ListaClientesModificados.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneClientesModificados(Trim(CBX_Estado.Text), Class_VariablesGlobales.SQL_Comman2, 0, False, 1, "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_INI.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FIN.Value.Date), TXTB_AGENTE.Text, CheckBox_Aprovados.Checked, Cbx_BuscaXFecha.Checked)

            '[CardCode],[CardName],[Cedula],[Respolsabletributario],[U_Visita],[U_ClaveWeb],[Phone1],[Phone2],[Street],[E_Mail],[NameFicticio],[Latitud],[Longitud],[Agente],[Id_Provincia],[Id_Canton],[Id_Distrito],[Id_Barrio],[Estado],[Tipo_Cedula],[Fecha],[Hora],[Aprobado],[id]
            DGV_ListaClientesModificados.Columns(0).Width = 100
            DGV_ListaClientesModificados.Columns(1).Width = 100
            DGV_ListaClientesModificados.Columns(2).Width = 300
            DGV_ListaClientesModificados.Columns(3).Width = 100
            DGV_ListaClientesModificados.Columns(4).Width = 300
            DGV_ListaClientesModificados.Columns(5).Width = 20
            DGV_ListaClientesModificados.Columns(6).Width = 100
            DGV_ListaClientesModificados.Columns(7).Width = 80
            DGV_ListaClientesModificados.Columns(8).Width = 80
        Catch ex As Exception

        End Try
    End Sub
End Class