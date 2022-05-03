Imports System.Threading

Public Class Admin_EstadoComprobantes

    Public Obj_SQL_CONEXIONSERVER As New Class_funcionesSQL
    Public Obj_ExpExcell As ExportarAExcell = New ExportarAExcell
    Private Sub Admin_EstadoComprobantes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try





            DGV_Respuestas.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneEstados(False, Cmb_Tipo.Text, "rechazado", Class_VariablesGlobales.SQL_Comman2, 0, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTimePicker1.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTimePicker2.Value.Date), txtb_Interno.Text, Chbx_Corregidos.Checked, txtb_NombreReceptor.Text)
            '[TipoComprobante],[Clave],[NumeroConsecutivo],[FechaEmision],[Receptor_Nombre],[ResumenFactura_TotalComprobante],[ind_estado],[fecha] ,[Mensaje]
            DGV_Respuestas.Columns(0).Width = 40
            DGV_Respuestas.Columns(1).Width = 80
            DGV_Respuestas.Columns(2).Width = 100
            DGV_Respuestas.Columns(3).Width = 370
            DGV_Respuestas.Columns(4).Width = 150
            DGV_Respuestas.Columns(5).Width = 180
            DGV_Respuestas.Columns(6).Width = 300
            DGV_Respuestas.Columns(7).Width = 100
            DGV_Respuestas.Columns(8).Width = 200
            DGV_Respuestas.Columns(9).Width = 800
            If DGV_Respuestas.Item(12, DGV_Respuestas.CurrentRow.Index).Value.ToString() = "1" Then

                DGV_Respuestas.Item(12, DGV_Respuestas.CurrentRow.Index).Style.BackColor = Color.Green

            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Estado.SelectedIndexChanged
        Try
            DGV_Respuestas.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneEstados(False, Cmb_Tipo.Text, Cmb_Estado.Text, Class_VariablesGlobales.SQL_Comman2, 0, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTimePicker1.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTimePicker2.Value.Date), txtb_Interno.Text, Chbx_Corregidos.Checked, txtb_NombreReceptor.Text)
            DGV_Respuestas.Columns(0).Width = 40
            DGV_Respuestas.Columns(1).Width = 80
            DGV_Respuestas.Columns(2).Width = 100
            DGV_Respuestas.Columns(3).Width = 370
            DGV_Respuestas.Columns(4).Width = 150
            DGV_Respuestas.Columns(5).Width = 180
            DGV_Respuestas.Columns(6).Width = 300
            DGV_Respuestas.Columns(7).Width = 100
            DGV_Respuestas.Columns(8).Width = 200
            DGV_Respuestas.Columns(9).Width = 800

            If DGV_Respuestas.Item(12, DGV_Respuestas.CurrentRow.Index).Value.ToString() = "1" Then

                DGV_Respuestas.Item(12, DGV_Respuestas.CurrentRow.Index).Style.BackColor = Color.Green

            Else

            End If

        Catch ex As Exception

        End Try
    End Sub



    Private Sub Cmb_Tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Tipo.SelectedIndexChanged
        Try
            DGV_Respuestas.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneEstados(False, Cmb_Tipo.Text, Cmb_Estado.Text, Class_VariablesGlobales.SQL_Comman2, 0, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTimePicker1.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTimePicker2.Value.Date), txtb_Interno.Text, Chbx_Corregidos.Checked, txtb_NombreReceptor.Text)
            DGV_Respuestas.Columns(0).Width = 40
            DGV_Respuestas.Columns(1).Width = 80
            DGV_Respuestas.Columns(2).Width = 100
            DGV_Respuestas.Columns(3).Width = 370
            DGV_Respuestas.Columns(4).Width = 150
            DGV_Respuestas.Columns(5).Width = 180
            DGV_Respuestas.Columns(6).Width = 300
            DGV_Respuestas.Columns(7).Width = 100
            DGV_Respuestas.Columns(8).Width = 200
            DGV_Respuestas.Columns(9).Width = 800
            If DGV_Respuestas.Item(12, DGV_Respuestas.CurrentRow.Index).Value.ToString() = "1" Then

                DGV_Respuestas.Item(12, DGV_Respuestas.CurrentRow.Index).Style.BackColor = Color.Green

            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            DGV_Respuestas.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneEstados(False, Cmb_Tipo.Text, Cmb_Estado.Text, Class_VariablesGlobales.SQL_Comman2, 0, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTimePicker1.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTimePicker2.Value.Date), txtb_Interno.Text, Chbx_Corregidos.Checked, txtb_NombreReceptor.Text)
            DGV_Respuestas.Columns(0).Width = 40
            DGV_Respuestas.Columns(1).Width = 80
            DGV_Respuestas.Columns(2).Width = 100
            DGV_Respuestas.Columns(3).Width = 370
            DGV_Respuestas.Columns(4).Width = 150
            DGV_Respuestas.Columns(5).Width = 180
            DGV_Respuestas.Columns(6).Width = 300
            DGV_Respuestas.Columns(7).Width = 100
            DGV_Respuestas.Columns(8).Width = 200
            DGV_Respuestas.Columns(9).Width = 800
            If DGV_Respuestas.Item(12, DGV_Respuestas.CurrentRow.Index).Value.ToString() = "1" Then

                DGV_Respuestas.Item(12, DGV_Respuestas.CurrentRow.Index).Style.BackColor = Color.Green

            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Try
            DGV_Respuestas.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneEstados(False, Cmb_Tipo.Text, Cmb_Estado.Text, Class_VariablesGlobales.SQL_Comman2, 0, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTimePicker1.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTimePicker2.Value.Date), txtb_Interno.Text, Chbx_Corregidos.Checked, txtb_NombreReceptor.Text)
            DGV_Respuestas.Columns(0).Width = 40
            DGV_Respuestas.Columns(1).Width = 80
            DGV_Respuestas.Columns(2).Width = 100
            DGV_Respuestas.Columns(3).Width = 370
            DGV_Respuestas.Columns(4).Width = 150
            DGV_Respuestas.Columns(5).Width = 180
            DGV_Respuestas.Columns(6).Width = 300
            DGV_Respuestas.Columns(7).Width = 100
            DGV_Respuestas.Columns(8).Width = 200
            DGV_Respuestas.Columns(9).Width = 800
            If DGV_Respuestas.Item(12, DGV_Respuestas.CurrentRow.Index).Value.ToString() = "1" Then

                DGV_Respuestas.Item(12, DGV_Respuestas.CurrentRow.Index).Style.BackColor = Color.Green

            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        Try
            DGV_Respuestas.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneEstados(False, Cmb_Tipo.Text, Cmb_Estado.Text, Class_VariablesGlobales.SQL_Comman2, 0, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTimePicker1.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTimePicker2.Value.Date), txtb_Interno.Text, Chbx_Corregidos.Checked, txtb_NombreReceptor.Text)
            DGV_Respuestas.Columns(0).Width = 40
            DGV_Respuestas.Columns(1).Width = 80
            DGV_Respuestas.Columns(2).Width = 100
            DGV_Respuestas.Columns(3).Width = 370
            DGV_Respuestas.Columns(4).Width = 150
            DGV_Respuestas.Columns(5).Width = 180
            DGV_Respuestas.Columns(6).Width = 300
            DGV_Respuestas.Columns(7).Width = 100
            DGV_Respuestas.Columns(8).Width = 200
            DGV_Respuestas.Columns(9).Width = 800
            If DGV_Respuestas.Item(12, DGV_Respuestas.CurrentRow.Index).Value.ToString() = "1" Then

                DGV_Respuestas.Item(12, DGV_Respuestas.CurrentRow.Index).Style.BackColor = Color.Green

            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtb_Interno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtb_Interno.KeyPress


        Try
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
                SendKeys.Send("{TAB}")
                e.Handled = True


                'If Not IsNumeric(e.KeyChar) Then
                '    e.Handled = True
                txtb_Clave.Text = ""

                DGV_Respuestas.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneEstados(True, "Todo", "Todo", Class_VariablesGlobales.SQL_Comman2, 0, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTimePicker1.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTimePicker2.Value.Date), txtb_Interno.Text, Chbx_Corregidos.Checked, txtb_NombreReceptor.Text)
                DGV_Respuestas.Columns(0).Width = 40
                DGV_Respuestas.Columns(1).Width = 80
                DGV_Respuestas.Columns(2).Width = 100
                DGV_Respuestas.Columns(3).Width = 370
                DGV_Respuestas.Columns(4).Width = 150
                DGV_Respuestas.Columns(5).Width = 180
                DGV_Respuestas.Columns(6).Width = 300
                DGV_Respuestas.Columns(7).Width = 100
                DGV_Respuestas.Columns(8).Width = 200
                DGV_Respuestas.Columns(9).Width = 800
                If DGV_Respuestas.Item(12, DGV_Respuestas.CurrentRow.Index).Value.ToString() = "1" Then

                    DGV_Respuestas.Item(12, DGV_Respuestas.CurrentRow.Index).Style.BackColor = Color.Green

                Else

                End If
                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtb_Clave.KeyPress
        Try

            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
                SendKeys.Send("{TAB}")
                e.Handled = True
                'If Not IsNumeric(e.KeyChar) Then
                '    e.Handled = True
                txtb_Interno.Text = ""
                DGV_Respuestas.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneEstados(False, Cmb_Tipo.Text, Cmb_Estado.Text, Class_VariablesGlobales.SQL_Comman2, txtb_Clave.Text & e.KeyChar.ToString, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTimePicker1.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTimePicker2.Value.Date), "", Chbx_Corregidos.Checked, txtb_NombreReceptor.Text)
                DGV_Respuestas.Columns(0).Width = 40
                DGV_Respuestas.Columns(1).Width = 80
                DGV_Respuestas.Columns(2).Width = 100
                DGV_Respuestas.Columns(3).Width = 370
                DGV_Respuestas.Columns(4).Width = 150
                DGV_Respuestas.Columns(5).Width = 180
                DGV_Respuestas.Columns(6).Width = 300
                DGV_Respuestas.Columns(7).Width = 100
                DGV_Respuestas.Columns(8).Width = 200
                DGV_Respuestas.Columns(9).Width = 800
                If DGV_Respuestas.Item(12, DGV_Respuestas.CurrentRow.Index).Value.ToString() = "1" Then

                    DGV_Respuestas.Item(12, DGV_Respuestas.CurrentRow.Index).Style.BackColor = Color.Green

                Else

                End If
                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Chbx_Corregidos_CheckedChanged(sender As Object, e As EventArgs) Handles Chbx_Corregidos.CheckedChanged
        Try
            DGV_Respuestas.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneEstados(False, Cmb_Tipo.Text, Cmb_Estado.Text, Class_VariablesGlobales.SQL_Comman2, 0, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTimePicker1.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTimePicker2.Value.Date), txtb_Interno.Text, Chbx_Corregidos.Checked, txtb_NombreReceptor.Text)
            DGV_Respuestas.Columns(0).Width = 40
            DGV_Respuestas.Columns(1).Width = 80
            DGV_Respuestas.Columns(2).Width = 100
            DGV_Respuestas.Columns(3).Width = 370
            DGV_Respuestas.Columns(4).Width = 150
            DGV_Respuestas.Columns(5).Width = 180
            DGV_Respuestas.Columns(6).Width = 300
            DGV_Respuestas.Columns(7).Width = 100
            DGV_Respuestas.Columns(8).Width = 200
            DGV_Respuestas.Columns(9).Width = 800
            If DGV_Respuestas.Item(12, DGV_Respuestas.CurrentRow.Index).Value.ToString() = "1" Then

                DGV_Respuestas.Item(12, DGV_Respuestas.CurrentRow.Index).Style.BackColor = Color.Green

            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV_Respuestas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Respuestas.CellDoubleClick
        Class_VariablesGlobales.frmLista_InfoMsjHacienda = New InfoMsjHacienda
        Class_VariablesGlobales.frmLista_InfoMsjHacienda.MdiParent = Principal
        Class_VariablesGlobales.frmLista_InfoMsjHacienda.Show()
        '[TipoComprobante],[ind_estado],[Clave],[NumeroConsecutivo],[FechaEmision],[Receptor_Nombre],[ResumenFactura_TotalComprobante],[fecha] ,[Mensaje]

        Class_VariablesGlobales.frmLista_InfoMsjHacienda.txtb_TipoComprobante.Text = DGV_Respuestas.Item(0, DGV_Respuestas.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.frmLista_InfoMsjHacienda.txtb_ind_estado.Text = DGV_Respuestas.Item(1, DGV_Respuestas.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.frmLista_InfoMsjHacienda.txtb_Clave.Text = DGV_Respuestas.Item(3, DGV_Respuestas.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.frmLista_InfoMsjHacienda.txtb_NumeroConsecutivo.Text = DGV_Respuestas.Item(4, DGV_Respuestas.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.frmLista_InfoMsjHacienda.txtb_FechaEmision.Text = DGV_Respuestas.Item(5, DGV_Respuestas.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.frmLista_InfoMsjHacienda.txtb_Receptor_Nombre.Text = DGV_Respuestas.Item(6, DGV_Respuestas.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.frmLista_InfoMsjHacienda.txtb_ResumenFactura_TotalComprobante.Text = DGV_Respuestas.Item(7, DGV_Respuestas.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.frmLista_InfoMsjHacienda.txtb_Fecha.Text = DGV_Respuestas.Item(8, DGV_Respuestas.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.frmLista_InfoMsjHacienda.txtb_Mensaje.Text = DGV_Respuestas.Item(9, DGV_Respuestas.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.frmLista_InfoMsjHacienda.txtb_CodInterno.Text = DGV_Respuestas.Item(2, DGV_Respuestas.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.frmLista_InfoMsjHacienda.txtb_Email.Text = DGV_Respuestas.Item(10, DGV_Respuestas.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.frmLista_InfoMsjHacienda.txtb_tipoCedula.Text = DGV_Respuestas.Item(11, DGV_Respuestas.CurrentRow.Index).Value.ToString()
        If DGV_Respuestas.Item(12, DGV_Respuestas.CurrentRow.Index).Value.ToString() = "1" Then
            Class_VariablesGlobales.frmLista_InfoMsjHacienda.LBL_ESTADO.Text = "CORREGIDO"
            Class_VariablesGlobales.frmLista_InfoMsjHacienda.LBL_ESTADO.ForeColor = Color.DarkGreen
            Class_VariablesGlobales.frmLista_InfoMsjHacienda.ChbX_Corregido.Checked = True
        Else
            Class_VariablesGlobales.frmLista_InfoMsjHacienda.LBL_ESTADO.Text = "NO ESTA CORREGIDO"
            Class_VariablesGlobales.frmLista_InfoMsjHacienda.LBL_ESTADO.ForeColor = Color.DarkRed
            Class_VariablesGlobales.frmLista_InfoMsjHacienda.ChbX_Corregido.Checked = False
        End If

        Class_VariablesGlobales.frmLista_InfoMsjHacienda.DGV_Historial.DataSource = Obj_SQL_CONEXIONSERVER.ObtieneHistorial(DGV_Respuestas.Item(3, DGV_Respuestas.CurrentRow.Index).Value.ToString(), Class_VariablesGlobales.SQL_Comman2)
        Class_VariablesGlobales.frmLista_InfoMsjHacienda.DGV_Historial.Columns(0).Width = 40
        Class_VariablesGlobales.frmLista_InfoMsjHacienda.DGV_Historial.Columns(1).Width = 350
        Class_VariablesGlobales.frmLista_InfoMsjHacienda.DGV_Historial.Columns(3).Width = 80
        Class_VariablesGlobales.frmLista_InfoMsjHacienda.DGV_Historial.Columns(2).Width = 80
        Class_VariablesGlobales.frmLista_InfoMsjHacienda.DGV_Historial.Columns(4).Width = 600


        Class_VariablesGlobales.frmLista_InfoMsjHacienda.txtb_ReenviarEmail.Text = Obj_SQL_CONEXIONSERVER.ObtieneCorreo(Class_VariablesGlobales.frmLista_InfoMsjHacienda.txtb_CodInterno.Text, Class_VariablesGlobales.frmLista_InfoMsjHacienda.txtb_TipoComprobante.Text, Class_VariablesGlobales.SQL_Comman2)

        If Class_VariablesGlobales.frmLista_InfoMsjHacienda.txtb_tipoCedula.Text = "" Then
            MsgBox("El comprobante no tiene el encabezado con la informacion del receptor, por lo que no podra ser aceptado este comprobante como un gasto ")
        End If

        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim Obj_Comunicacion As New Comunicacion
        'Obj_Comunicacion.ListaComprobantesEnHacienda("", Trim(txtb_Clave.Text).Substring(42, 8), "FE", Trim(txtb_Clave.Text))
        'Obj_Comunicacion = Nothing
    End Sub

    Private Sub DGV_Respuestas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Respuestas.CellContentClick

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btn_Exportar.Click
        Dim trd1 As Thread
        '__________PROCESO 1_______________

        trd1 = Nothing
        trd1 = New Thread(AddressOf ExportaAExcelComprobantesElectronicos)
        trd1.IsBackground = Enabled
        trd1.Priority = ThreadPriority.AboveNormal
        trd1.Start()
        CheckForIllegalCrossThreadCalls = False


        btn_Exportar.Text = "Espere ..."
    End Sub

    Public Function ExportaAExcelComprobantesElectronicos()
        Try

            Dim Dgv As New DataGridView
            Dim tbl As New DataTable

            tbl = Obj_SQL_CONEXIONSERVER.ObtieneComprobantes(False, Cmb_Tipo.Text, Cmb_Estado.Text, Class_VariablesGlobales.SQL_Comman2, 0, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTimePicker1.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DateTimePicker2.Value.Date), txtb_Interno.Text, Chbx_Corregidos.Checked)


            Dgv.DataSource = tbl

            Obj_ExpExcell.ExportarComprobantesElectronicos(tbl, "Inventario Trimestral")
            btn_Exportar.Text = "EXPORTAR"

        Catch ex As Exception

        End Try
    End Function
End Class