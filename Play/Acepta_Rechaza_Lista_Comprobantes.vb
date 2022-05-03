Imports System.Threading

Public Class Acepta_Rechaza_Lista_Comprobantes
    Dim Obj_Sql As New Class_funcionesSQL
    Public Obj_Funciones As New Class_funcionesSQL

    Private Sub Lista_FE_Proveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Jalara todos las FE recibidas y no aceptadas almacenadas en la DB

        Try


            Dim Motivo As String = Cmb_Estado.Text
            Dim Tipo As String = Cmb_Tipo.Text
            Dim Clave As String = txtb_clave.Text
            Dim Situacion_de_Comprobante As String = Cmb_EstadoDefinido.Text
            Dim colBotones As DataGridViewButtonColumn = New DataGridViewButtonColumn()
            colBotones.Name = "Aceptar"
            colBotones.HeaderText = "Aceptar"
            colBotones.Text = "Aceptar"
            colBotones.UseColumnTextForButtonValue = True
            colBotones.FlatStyle = FlatStyle.Popup
            colBotones.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colBotones.DefaultCellStyle.ForeColor = Color.White
            colBotones.DefaultCellStyle.BackColor = Color.Green
            colBotones.Width = 60
            Me.DGV_ListaFE.Columns.Add(colBotones)

            Dim colBotones2 As DataGridViewButtonColumn = New DataGridViewButtonColumn()
            colBotones2.Name = "Rechazar"
            colBotones2.HeaderText = "Rechazar"
            colBotones2.Text = "Rechazar"
            colBotones2.UseColumnTextForButtonValue = True
            colBotones2.FlatStyle = FlatStyle.Popup
            colBotones2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colBotones2.DefaultCellStyle.ForeColor = Color.White
            colBotones2.DefaultCellStyle.BackColor = Color.Red
            colBotones2.Width = 60
            Me.DGV_ListaFE.Columns.Add(colBotones2)

            Dim colBotones3 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
            colBotones3.Name = "txtb_Motivo"
            colBotones3.HeaderText = "Motivo"
            colBotones3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            colBotones3.Width = 100
            Me.DGV_ListaFE.Columns.Add(colBotones3)

            Dim colBotones4 As DataGridViewButtonColumn = New DataGridViewButtonColumn()
            colBotones4.Name = "Aceptar_Parcial"
            colBotones4.HeaderText = "Aceptar_Parcial"
            colBotones4.Text = "Aceptar_Parcial"
            colBotones4.FlatStyle = FlatStyle.Popup
            colBotones4.UseColumnTextForButtonValue = True
            colBotones4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colBotones4.DefaultCellStyle.ForeColor = Color.White
            colBotones4.DefaultCellStyle.BackColor = Color.Orange
            colBotones4.Width = 100
            Me.DGV_ListaFE.Columns.Add(colBotones4)

            Dim colBotones5 As DataGridViewButtonColumn = New DataGridViewButtonColumn()
            colBotones5.Name = "PDF"
            colBotones5.HeaderText = "PDF"
            colBotones5.Text = "PDF"
            colBotones5.FlatStyle = FlatStyle.Popup
            colBotones5.UseColumnTextForButtonValue = True
            colBotones5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colBotones5.DefaultCellStyle.ForeColor = Color.Red
            colBotones5.Width = 60
            Me.DGV_ListaFE.Columns.Add(colBotones5)

            Dim colBotones6 As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
            colBotones6.Items.Add("General Credito IVA")
            colBotones6.Items.Add("General Crédito parcial del IVA")
            colBotones6.Items.Add("Bienes de Capital")
            colBotones6.Items.Add("Gasto corriente no genera crédito")
            colBotones6.Items.Add("Proporcionalidad")
            colBotones6.Items.Add("Seleccione uno")
            colBotones6.DisplayMember = "Condicion Impuesto"
            colBotones6.HeaderText = "Condicion Impuesto"
            colBotones6.ValueMember = "Seleccione uno"
            colBotones6.DropDownWidth = 160
            colBotones6.MaxDropDownItems = 5

            Me.DGV_ListaFE.Columns.Add(colBotones6)

            Dim colBotones7 As DataGridViewButtonColumn = New DataGridViewButtonColumn()
            colBotones7.Name = "Sinc"
            colBotones7.HeaderText = "Sinc"
            colBotones7.Text = "Sinc"
            colBotones7.FlatStyle = FlatStyle.Popup
            colBotones7.UseColumnTextForButtonValue = True
            colBotones7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colBotones7.DefaultCellStyle.ForeColor = Color.Black
            colBotones7.Width = 60
            Me.DGV_ListaFE.Columns.Add(colBotones7)

            DGV_ListaFE.DataSource = Obj_Sql.ObtieneComprobantesProveedores(txtb_proveedor.Text, Motivo, Tipo, Clave, Situacion_de_Comprobante, Cmb_Estado.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Ini.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Fin.Value.Date), Cmb_EstadoDefinido.Text, Cxb_BFecha.Checked, Cxb_VerProcesadas.Checked)
            Ordenar()




        Catch ex As Exception

        End Try
    End Sub
    'Private Sub DGV_ListaFE_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DGV_ListaFE.CellPainting
    '    If e.ColumnIndex >= 0 AndAlso Me.DGV_ListaFE.Columns(e.ColumnIndex).Name = "PDF" AndAlso e.RowIndex >= 0 Then
    '        e.Paint(e.CellBounds, DataGridViewPaintParts.All)
    '        Dim celBoton As DataGridViewButtonCell = TryCast(Me.DGV_ListaFE.Rows(e.RowIndex).Cells("PDF"), DataGridViewButtonCell)
    '        Dim icoAtomico As Icon = New Icon(Environment.CurrentDirectory & "PDF ICO.ico")
    '        e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3)
    '        Me.DGV_ListaFE.Rows(e.RowIndex).Height = icoAtomico.Height + 10
    '        Me.DGV_ListaFE.Columns(e.ColumnIndex).Width = icoAtomico.Width + 10
    '        e.Handled = True
    '    End If
    'End Sub


    Private Sub Cmb_Tipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Tipo.SelectedIndexChanged
        Try

            Dim Motivo As String = Cmb_Estado.Text
            Dim Tipo As String = Cmb_Tipo.Text
            Dim Clave As String = txtb_clave.Text
            Dim Situacion_de_Comprobante As String = Cmb_EstadoDefinido.Text

            DGV_ListaFE.DataSource = Obj_Sql.ObtieneComprobantesProveedores(txtb_proveedor.Text, Motivo, Cmb_Tipo.Text, Clave, Situacion_de_Comprobante, Cmb_Estado.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Ini.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Fin.Value.Date), Cmb_EstadoDefinido.Text, Cxb_BFecha.Checked, Cxb_VerProcesadas.Checked)
            Ordenar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmb_Estado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Estado.SelectedIndexChanged
        Dim Motivo As String = Cmb_Estado.Text
        Dim Tipo As String = Cmb_Tipo.Text
        Dim Clave As String = txtb_clave.Text
        Dim Situacion_de_Comprobante As String = Cmb_EstadoDefinido.Text
        Cxb_VerProcesadas.Checked = False

        DGV_ListaFE.DataSource = Obj_Sql.ObtieneComprobantesProveedores(txtb_proveedor.Text, Motivo, Tipo, Clave, Situacion_de_Comprobante, Cmb_Estado.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Ini.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Fin.Value.Date), Cmb_EstadoDefinido.Text, Cxb_BFecha.Checked, Cxb_VerProcesadas.Checked)
        Ordenar()

    End Sub

    Private Sub Dtp_Fin_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_Fin.ValueChanged
        Dim Motivo As String = Cmb_Estado.Text
        Dim Tipo As String = Cmb_Tipo.Text
        Dim Clave As String = txtb_clave.Text
        Dim Situacion_de_Comprobante As String = Cmb_EstadoDefinido.Text

        DGV_ListaFE.DataSource = Obj_Sql.ObtieneComprobantesProveedores(txtb_proveedor.Text, Motivo, Tipo, Clave, Situacion_de_Comprobante, Cmb_Estado.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Ini.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Fin.Value.Date), Cmb_EstadoDefinido.Text, Cxb_BFecha.Checked, Cxb_VerProcesadas.Checked)
        Ordenar()
    End Sub

    Private Sub Cmb_EstadoDefinido_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_EstadoDefinido.SelectedIndexChanged
        Dim Motivo As String = Cmb_Estado.Text
        Dim Tipo As String = Cmb_Tipo.Text
        Dim Clave As String = txtb_clave.Text
        Dim Situacion_de_Comprobante As String = Cmb_EstadoDefinido.Text
        Cxb_VerProcesadas.Checked = False
        DGV_ListaFE.DataSource = Obj_Sql.ObtieneComprobantesProveedores(txtb_proveedor.Text, Motivo, Tipo, Clave, Situacion_de_Comprobante, Cmb_Estado.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Ini.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Fin.Value.Date), Trim(Cmb_EstadoDefinido.Text), Cxb_BFecha.Checked, Cxb_VerProcesadas.Checked)
        Ordenar()
    End Sub

    Private Sub Dtp_Ini_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_Ini.ValueChanged
        Dim Motivo As String = Cmb_Estado.Text
        Dim Tipo As String = Cmb_Tipo.Text
        Dim Clave As String = txtb_clave.Text
        Dim Situacion_de_Comprobante As String = Cmb_EstadoDefinido.Text

        DGV_ListaFE.DataSource = Obj_Sql.ObtieneComprobantesProveedores(txtb_proveedor.Text, Motivo, Tipo, Clave, Situacion_de_Comprobante, Cmb_Estado.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Ini.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Fin.Value.Date), Cmb_EstadoDefinido.Text, Cxb_BFecha.Checked, Cxb_VerProcesadas.Checked)
        Ordenar()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtb_clave.KeyPress
        Dim Motivo As String = Cmb_Estado.Text
        Dim Tipo As String = Cmb_Tipo.Text
        Dim Clave As String = txtb_clave.Text
        Dim Situacion_de_Comprobante As String = Cmb_EstadoDefinido.Text

        DGV_ListaFE.DataSource = Obj_Sql.ObtieneComprobantesProveedores(txtb_proveedor.Text, Motivo, Tipo, Clave, Situacion_de_Comprobante, Cmb_Estado.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Ini.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Fin.Value.Date), Cmb_EstadoDefinido.Text, Cxb_BFecha.Checked, Cxb_VerProcesadas.Checked)
        Ordenar()
    End Sub

    Private Sub Cxb_BFecha_CheckedChanged(sender As Object, e As EventArgs) Handles Cxb_BFecha.CheckedChanged

        If Cxb_BFecha.Checked Then
            Dtp_Ini.Enabled = True
            Dtp_Fin.Enabled = True
        Else
            Dtp_Ini.Enabled = False
            Dtp_Fin.Enabled = False
        End If


    End Sub

    Private Sub txtb_proveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtb_proveedor.KeyPress
        Try


            Dim Motivo As String = Cmb_Estado.Text
            Dim Tipo As String = Cmb_Tipo.Text
            Dim Clave As String = txtb_clave.Text
            Dim Situacion_de_Comprobante As String = Cmb_EstadoDefinido.Text

            DGV_ListaFE.DataSource = Obj_Sql.ObtieneComprobantesProveedores(txtb_proveedor.Text, Motivo, Tipo, Clave, Situacion_de_Comprobante, Cmb_Estado.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Ini.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Fin.Value.Date), Cmb_EstadoDefinido.Text, Cxb_BFecha.Checked, Cxb_VerProcesadas.Checked)
            Ordenar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cmb_Estado.Text = ""
        Cmb_Tipo.Text = ""
        txtb_clave.Text = ""
        txtb_proveedor.Text = ""
        Cmb_EstadoDefinido.Text = ""
        Cxb_BFecha.Checked = False

    End Sub

    Private Sub txtb_clave_TextChanged(sender As Object, e As EventArgs) Handles txtb_clave.TextChanged
        Try


            Dim Motivo As String = Cmb_Estado.Text
            Dim Tipo As String = Cmb_Tipo.Text
            Dim Clave As String = txtb_clave.Text
            Dim Situacion_de_Comprobante As String = Cmb_EstadoDefinido.Text

            DGV_ListaFE.DataSource = Obj_Sql.ObtieneComprobantesProveedores(txtb_proveedor.Text, Motivo, Tipo, Clave, Situacion_de_Comprobante, Cmb_Estado.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Ini.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Fin.Value.Date), Cmb_EstadoDefinido.Text, Cxb_BFecha.Checked, Cxb_VerProcesadas.Checked)
            Ordenar()
        Catch ex As Exception

        End Try
    End Sub


    Public Function Ordenar()

        Try


            DGV_ListaFE.Columns(10).Width = 20
            DGV_ListaFE.Columns(11).Width = 365
            DGV_ListaFE.Columns(12).Width = 165
            DGV_ListaFE.Columns(13).Width = 40
            DGV_ListaFE.Columns(14).Width = 110
            DGV_ListaFE.Columns(15).Width = 300
            DGV_ListaFE.Columns(16).Width = 100
            DGV_ListaFE.Columns(17).Width = 100
            DGV_ListaFE.Columns(18).Width = 100
            DGV_ListaFE.Columns(19).Width = 100
            DGV_ListaFE.Columns(20).Width = 100
            DGV_ListaFE.Columns(21).Width = 100
            DGV_ListaFE.Columns(22).Width = 40
            DGV_ListaFE.Columns(23).Width = 100
            DGV_ListaFE.Columns(24).Width = 300
            DGV_ListaFE.Columns(25).Width = 300
            DGV_ListaFE.Columns(26).Width = 150
            DGV_ListaFE.Columns(27).Width = 150
            DGV_ListaFE.Columns(28).Width = 150
            DGV_ListaFE.Columns(29).Width = 150
            DGV_ListaFE.Columns(30).Width = 150
        Catch ex As Exception

        End Try
    End Function

    Private Sub Cxb_VerProcesadas_CheckedChanged(sender As Object, e As EventArgs) Handles Cxb_VerProcesadas.CheckedChanged
        Dim Motivo As String = Cmb_Estado.Text
        Dim Tipo As String = Cmb_Tipo.Text
        Dim Clave As String = txtb_clave.Text
        Dim Situacion_de_Comprobante As String = Cmb_EstadoDefinido.Text

        DGV_ListaFE.DataSource = Obj_Sql.ObtieneComprobantesProveedores(txtb_proveedor.Text, Motivo, Tipo, Clave, Situacion_de_Comprobante, Cmb_Estado.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Ini.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Fin.Value.Date), Cmb_EstadoDefinido.Text, Cxb_BFecha.Checked, Cxb_VerProcesadas.Checked)
        Ordenar()
    End Sub

    Private Sub DGV_ListaFE_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_ListaFE.CellContentDoubleClick
        'existen 6 columnas antes que son la de los botones y campospar aceptar en la lista
        '5  [ind_estado]
        '6  [Fecha_estado]
        '7  [MensajeHacienda]
        '8  (SELECT case when 8-(DATEDIFF(DAY, [Fecha],GETDATE())) < 0 then 0 else 8-(DATEDIFF(DAY, [Fecha],GETDATE())) end) as Dias
        '9  [Clave]
        '10 [ConsecutivoComprobante]
        '11 [TipoCedulaEmisor]
        '12 [NumeroCedulaEmisor]
        '13 [Nombre_Emisor]
        '14 [FechaEmisionDoc]
        '15 [MontoTotalImpuesto]
        '16 [TotalFactura]
        '17 [TipoCedulaReceptor]
        '18 [NumeroCedulaReceptor]
        '19 [Fecha]
        '20 [Hora]
        '21 [Tipo]
        '22 [NumeroConsecutivoReceptor]
        '23 [Mensaje]
        '24 [DetalleMensaje]
        '25 [CorreoElectronicoEmisor]
        '26 [Nombre_Receptor]
        '27 [CorreoElectronicoReceptor] 
        '28 [Motivo]
        '29 [CodigoActividad]
        '30 [CondicionImpuestoEmisor]
        '31 [MontoTotalImpuestoAcreditarEmisor]
        '32 [MontoTotalDeGastoAplicableEmisor]


        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txt_NombreEmisor.Text = DGV_ListaFE.Item(11, DGV_ListaFE.CurrentRow.Index).Value.ToString()
        ',[TotalFactura]
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txt_TotalFactura.Text = DGV_ListaFE.Item(12, DGV_ListaFE.CurrentRow.Index).Value.ToString()

        '[Clave]
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txt_Clave.Text = DGV_ListaFE.Item(13, DGV_ListaFE.CurrentRow.Index).Value.ToString()
        '[ConsecutivoComprobante]
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txtb_ConsecutivoComprobante.Text = DGV_ListaFE.Item(14, DGV_ListaFE.CurrentRow.Index).Value.ToString()

        ',[TipoCedulaEmisor]
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txt_TipoCedEmisor.Text = DGV_ListaFE.Item(15, DGV_ListaFE.CurrentRow.Index).Value.ToString()
        ',[NumeroCedulaEmisor]
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txt_CedulaEmisor.Text = DGV_ListaFE.Item(16, DGV_ListaFE.CurrentRow.Index).Value.ToString()

        ',[FechaEmisionDoc]
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txt_FechaEmisionDoc.Text = DGV_ListaFE.Item(17, DGV_ListaFE.CurrentRow.Index).Value.ToString()
        ',[MontoTotalImpuesto]
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txt_MontoTotalImpuesto.Text = DGV_ListaFE.Item(18, DGV_ListaFE.CurrentRow.Index).Value.ToString()
        'MontoTotalImpuestoAcreditar
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txt_MontoTotalImpuestoAcreditarReceptor.Text = DGV_ListaFE.Item(18, DGV_ListaFE.CurrentRow.Index).Value.ToString()
        'MontoTotalDeGastoAplicable
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txt_MontoTotalDeGastoAplicableReceptor.Text = DGV_ListaFE.Item(18, DGV_ListaFE.CurrentRow.Index).Value.ToString()

        ',[TipoCedulaReceptor]
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txt_TipoCedReceptor.Text = DGV_ListaFE.Item(19, DGV_ListaFE.CurrentRow.Index).Value.ToString()
        ',[NumeroCedulaReceptor]
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txt_CedulaReceptor.Text = DGV_ListaFE.Item(20, DGV_ListaFE.CurrentRow.Index).Value.ToString()
        ',[CodigoActividad]
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txt_CodigoActividadEmisor.Text = DGV_ListaFE.Item(31, DGV_ListaFE.CurrentRow.Index).Value.ToString()



        'Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.CBox_CondicionImpuesto.Text = Trim(DGV_ListaFE.Item(5, DGV_ListaFE.CurrentRow.Index).Value.ToString())



        ',[Fecha]
        'Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txt_MontoTotalImpuesto.Text = DGV_ListaFE.Item(8, DGV_ListaFE.CurrentRow.Index).Value.ToString() 'fecha
        ',[Hora]
        'Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txt_NumeroCedulaReceptor.Text = DGV_ListaFE.Item(9, DGV_ListaFE.CurrentRow.Index).Value.ToString() 'hora
        ',[Tipo]
        'Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txt_TotalFactura.Text = DGV_ListaFE.Item(10, DGV_ListaFE.CurrentRow.Index).Value.ToString() 'Tipo
        ',[NumeroConsecutivoReceptor]
        ',[Mensaje]
        ',[DetalleMensaje]
        'CorreoElectronicoEmisor
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.txtb_CorreoEmirosr.Text = DGV_ListaFE.Item(27, DGV_ListaFE.CurrentRow.Index).Value.ToString()

        VariablesGlobales.EmisorEmail = Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.txtb_CorreoEmirosr.Text

        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txt_NombreRecetor.Text = DGV_ListaFE.Item(28, DGV_ListaFE.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.txtb_CorreoReceptor.Text = DGV_ListaFE.Item(29, DGV_ListaFE.CurrentRow.Index).Value.ToString()

        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txtb_TipoComprobante.Text = DGV_ListaFE.Item(23, DGV_ListaFE.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txt_NumeroConsecutivoReceptor.Text = DGV_ListaFE.Item(24, DGV_ListaFE.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.txtb_MHEstado.Text = DGV_ListaFE.Item(7, DGV_ListaFE.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.txtb_MHFecha.Text = DGV_ListaFE.Item(8, DGV_ListaFE.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.txtb_MHMensaje.Text = DGV_ListaFE.Item(9, DGV_ListaFE.CurrentRow.Index).Value.ToString()

        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.lbl_Estado.Text = DGV_ListaFE.Item(7, DGV_ListaFE.CurrentRow.Index).Value.ToString()

        If Trim(DGV_ListaFE.Item(26, DGV_ListaFE.CurrentRow.Index).Value.ToString()) = "Comprobante Aceptado" Then
            Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.lbl_Estado.ForeColor = Color.Green
        ElseIf Trim(DGV_ListaFE.Item(26, DGV_ListaFE.CurrentRow.Index).Value.ToString()) = "Comprobante Parcialmente Aceptado" Then
            Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.lbl_Estado.ForeColor = Color.OrangeRed
        ElseIf Trim(DGV_ListaFE.Item(26, DGV_ListaFE.CurrentRow.Index).Value.ToString()) = "Rechazado" Then
            Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.lbl_Estado.ForeColor = Color.Red

        End If

        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txt_DetalleMensaje.Text = DGV_ListaFE.Item(26, DGV_ListaFE.CurrentRow.Index).Value.ToString()

        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.btn_aceptar.Visible = True
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.btn_aceptarparcial.Visible = True
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.btn_rechaza.Visible = True
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.btn_pdf.Visible = True
        Me.Close()
    End Sub

    Private Sub DGV_ListaFE_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_ListaFE.CellContentClick

        If DGV_ListaFE.Columns(e.ColumnIndex).Name.ToString = "Aceptar" Then
            Try
                If DGV_ListaFE.Item(5, DGV_ListaFE.CurrentRow.Index).Value.ToString() = "" Then
                    MessageBox.Show("Debe indicar la Condicion del impuesto", "DATOS INCOMPLETOS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Try
                        Class_VariablesGlobales.RoxIndexDGV.Add(DGV_ListaFE.Item(13, DGV_ListaFE.CurrentRow.Index).Value.ToString(), DGV_ListaFE.CurrentRow.Index)
                    Catch ex As Exception

                    End Try


                    Dim Pregunta As Integer
                    Pregunta = MsgBox("Esta apunto de ACEPTAR este comprobante, acción no se puede revestir " & vbCrLf & " ¿Esta Seguro que desea ACEPTAR este comprobante?.", vbYesNo + vbExclamation + vbDefaultButton2, "ACEPTAR COMPROBANTE")
                    If Pregunta = vbYes Then
                        Dim Thread_aceptar As Thread
                        'hilo de ejecucion constante
                        Thread_aceptar = New Thread(AddressOf Aceptar)
                        Thread_aceptar.IsBackground = Enabled
                        'trd2.Priority = ThreadPriority.Highest
                        CheckForIllegalCrossThreadCalls = False
                        Thread_aceptar.Start()
                    Else
                    End If

                    Pregunta = Nothing
                End If
            Catch ex As Exception
                MessageBox.Show("Selecciones una condicion de impuesto " & ex.Message)
            End Try
        End If
        If DGV_ListaFE.Columns(e.ColumnIndex).Name.ToString = "Rechazar" Then

            Try
                If DGV_ListaFE.Item(5, DGV_ListaFE.CurrentRow.Index).Value.ToString() = "" Then
                    MessageBox.Show("Debe indicar la Condicion del impuesto", "DATOS INCOMPLETOS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf DGV_ListaFE.Item(2, DGV_ListaFE.CurrentRow.Index).Value Is Nothing Then
                    MessageBox.Show("Debe indicar la razon del rechazo", "DATOS INCOMPLETOS", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    Try
                        Class_VariablesGlobales.RoxIndexDGV.Add(DGV_ListaFE.Item(13, DGV_ListaFE.CurrentRow.Index).Value.ToString(), DGV_ListaFE.CurrentRow.Index)
                    Catch ex As Exception

                    End Try

                    Dim Pregunta As Integer
                    Pregunta = MsgBox("Esta apunto de RECHAZAR este comprobante, acción no se puede revestir " & vbCrLf & " ¿Esta Seguro que desea RECHAZAR este comprobante?.", vbYesNo + vbExclamation + vbDefaultButton2, "RECHAZAR COMPROBANTE")
                    If Pregunta = vbYes Then
                        Dim Thread_rechaz As Thread
                        'hilo de ejecucion constante
                        Thread_rechaz = New Thread(AddressOf Rechazar)
                        Thread_rechaz.IsBackground = Enabled
                        'trd2.Priority = ThreadPriority.Highest
                        CheckForIllegalCrossThreadCalls = False
                        Thread_rechaz.Start()
                    Else
                    End If
                    Pregunta = Nothing
                End If
            Catch ex As Exception
                MessageBox.Show("Selecciones una condicion de impuesto " & ex.Message)
            End Try
        End If
        If DGV_ListaFE.Columns(e.ColumnIndex).Name.ToString = "Aceptar_Parcial" Then
            Try
                Try
                    Class_VariablesGlobales.RoxIndexDGV.Add(DGV_ListaFE.Item(13, DGV_ListaFE.CurrentRow.Index).Value.ToString(), DGV_ListaFE.CurrentRow.Index)
                Catch ex As Exception

                End Try

                If DGV_ListaFE.Item(5, DGV_ListaFE.CurrentRow.Index).Value.ToString() = "" Then
                    MessageBox.Show("Debe indicar la Condicion del impuesto", "DATOS INCOMPLETOS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else

                    Dim Pregunta As Integer
                    Pregunta = MsgBox("Esta apunto de ACEPTAR PARCIALMENTE este comprobante, acción no se puede revestir " & vbCrLf & " ¿Esta Seguro que desea ACEPTAR PARCIALMENTE este comprobante?.", vbYesNo + vbExclamation + vbDefaultButton2, "ACEPTAR PARCIALMENTE COMPROBANTE")

                    If Pregunta = vbYes Then
                        Dim Thread_aceptarparcial As Thread
                        'hilo de ejecucion constante
                        Thread_aceptarparcial = New Thread(AddressOf AceptarParcial)
                        Thread_aceptarparcial.IsBackground = Enabled
                        'trd2.Priority = ThreadPriority.Highest
                        CheckForIllegalCrossThreadCalls = False
                        Thread_aceptarparcial.Start()
                    Else

                    End If

                    Pregunta = Nothing
                End If
            Catch ex As Exception
                MessageBox.Show("Selecciones una condicion de impuesto " & ex.Message)
            End Try
        End If
        If DGV_ListaFE.Columns(e.ColumnIndex).Name.ToString = "PDF" Then
            Try

                Dim loPSI As New ProcessStartInfo
                Dim loProceso As New Process
                'busca pdf con la clave del comprobante
                loPSI.FileName = VariablesGlobales.Patch_PDFMR & "\" & Trim(DGV_ListaFE.Item(13, DGV_ListaFE.CurrentRow.Index).Value.ToString()) & ".pdf"
                Try
                    loProceso = Process.Start(loPSI)
                Catch Exp As Exception
                    MessageBox.Show(Exp.Message, "NO DISPONIBLE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try



            Catch ex As Exception

            End Try
        End If
        If DGV_ListaFE.Columns(e.ColumnIndex).Name.ToString = "Sinc" Then
            Try
                DGV_ListaFE.Item(7, CInt(e.RowIndex)).Value = "..."
                'DGV_ListaFE.Item(8, CInt(e.RowIndex)).Value = "..."
                DGV_ListaFE.Item(9, CInt(e.RowIndex)).Value = "..."
                Try
                    Class_VariablesGlobales.RoxIndexDGV.Add(DGV_ListaFE.Item(13, DGV_ListaFE.CurrentRow.Index).Value.ToString(), DGV_ListaFE.CurrentRow.Index)
                Catch ex As Exception

                End Try



                Dim Thread_Consultar As Thread
                'hilo de ejecucion constante
                Thread_Consultar = New Thread(AddressOf Consultar)
                Thread_Consultar.IsBackground = Enabled
                'trd2.Priority = ThreadPriority.Highest
                CheckForIllegalCrossThreadCalls = False
                Thread_Consultar.Start()

            Catch ex As Exception
                '  MessageBox.Show("[ " & Now & " ] ERROR EN btn_ConsultarEstadoMH_Click [ " & ex.Message & " ]")
            End Try
        End If
    End Sub


    Public Function Aceptar()
        Try

            'existen 5 columnas antes que son la de los botones y campospar aceptar en la lista
            '  07    [ind_estado]
            '  08   ,[Fecha_estado]
            '  09   ,[MensajeHacienda]
            '  10   ,(SELECT case when 30-(DATEDIFF(DAY, [Fecha],GETDATE())) < 0 then 0 else 30-(DATEDIFF(DAY, [Fecha],GETDATE())) end) as Dias
            '  11   ,[Nombre_Emisor]                            
            '  12   ,[TotalFactura]
            '  13   ,[Clave]
            '  14   ,[ConsecutivoComprobante]
            '  15   ,[TipoCedulaEmisor]
            '  16   ,[NumeroCedulaEmisor]
            '  17   ,[FechaEmisionDoc]
            '  18   ,[MontoTotalImpuesto]
            '  19   ,[TipoCedulaReceptor]
            '  20   ,[NumeroCedulaReceptor]
            '  21   ,[Fecha]
            '  22   ,[Hora]
            '  23   ,[Tipo]
            '  24   ,[NumeroConsecutivoReceptor]
            '  25   ,[Mensaje]
            '  26   ,[DetalleMensaje]
            '  27   ,[CorreoElectronicoEmisor]
            '  28   ,[Nombre_Receptor]
            '  29   ,[CorreoElectronicoReceptor] 
            '  30   ,[Motivo]
            '  31   ,[CodigoActividad]
            '  32   ,[CondicionImpuestoEmisor]
            '  33   ,[MontoTotalImpuestoAcreditarEmisor]
            '  34   ,[MontoTotalDeGastoAplicableEmisor]

            Dim Clave As String = DGV_ListaFE.Item(13, DGV_ListaFE.CurrentRow.Index).Value.ToString()

            Dim ConsecutivoComprobante As String = DGV_ListaFE.Item(14, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim NumeroConsecutivoReceptor As String = DGV_ListaFE.Item(24, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim FechaEmisionDoc As String = DGV_ListaFE.Item(17, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim TipoComprobante As String = DGV_ListaFE.Item(23, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim TipoCedEmisor As String = DGV_ListaFE.Item(15, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim CedulaEmisor As String = DGV_ListaFE.Item(16, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim NombreEmisor As String = DGV_ListaFE.Item(11, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim CorreoEmirosr As String = DGV_ListaFE.Item(27, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim Estado As String = DGV_ListaFE.Item(7, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim TipoCedReceptor As String = DGV_ListaFE.Item(19, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim NombreRecetor As String = DGV_ListaFE.Item(28, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim CorreoReceptor As String = DGV_ListaFE.Item(29, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim MontoTotalImpuesto As String = DGV_ListaFE.Item(18, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim TotalFactura As String = DGV_ListaFE.Item(12, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim MHEstado As String = DGV_ListaFE.Item(7, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim MHFecha As String = DGV_ListaFE.Item(8, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim MHMensaje As String = DGV_ListaFE.Item(9, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim CedulaReceptor As String = DGV_ListaFE.Item(20, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim CodigoActividadEmisor As String = DGV_ListaFE.Item(31, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim CondicionImpuesto As String = DGV_ListaFE.Item(5, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim MontoTotalImpuestoAcreditarReceptor As String = DGV_ListaFE.Item(33, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim MontoTotalDeGastoAplicableReceptor As String = DGV_ListaFE.Item(34, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim DetalleMensaje As String = DGV_ListaFE.Item(9, DGV_ListaFE.CurrentRow.Index).Value.ToString()

            'Cursor = Cursors.WaitCursor
            Dim Obj_xml As New XML_Generator
            'lbl_Estado.Text = "Comprobante Aceptado"
            'Lbl_Procesando.Visible = True
            'Lbl_Procesando.Text = "Procesando solicitud, porfavor espere.... "
            'btn_ConsultarEstadoMH.Visible = False
            'Panel_Acciones.Visible = False

            VariablesGlobales.Obj_Log.Log("Aceptar Comprobante Clave ( " & clave & " )", "MR")


            If Trim(DGV_ListaFE.Item(5, DGV_ListaFE.CurrentRow.Index).Value.ToString()) = "General Credito IVA" Then
                CondicionImpuesto = "01"
            End If
            If Trim(DGV_ListaFE.Item(5, DGV_ListaFE.CurrentRow.Index).Value.ToString()) = "General Crédito parcial del IVA" Then
                CondicionImpuesto = "02"
            End If
            If Trim(DGV_ListaFE.Item(5, DGV_ListaFE.CurrentRow.Index).Value.ToString()) = "Bienes de Capital" Then
                CondicionImpuesto = "03"
            End If
            If Trim(DGV_ListaFE.Item(5, DGV_ListaFE.CurrentRow.Index).Value.ToString()) = "Gasto corriente no genera crédito" Then
                CondicionImpuesto = "04"
            End If
            If Trim(DGV_ListaFE.Item(5, DGV_ListaFE.CurrentRow.Index).Value.ToString()) = "Proporcionalidad" Then
                CondicionImpuesto = "05"
            End If

            'NO SE AH
            Try
                DGV_ListaFE.Item(7, CInt(Class_VariablesGlobales.RoxIndexDGV(Clave).ToString())).Value = "espere..."
                'DGV_ListaFE.Item(8, CInt(Class_VariablesGlobales.RoxIndexDGV(Clave).ToString())).Value = "espere..."
                DGV_ListaFE.Item(9, CInt(Class_VariablesGlobales.RoxIndexDGV(Clave).ToString())).Value = "espere..."

            Catch ex As Exception

            End Try

            'CDbl(TotalFactura).ToString(“##,##0.00”)
            'Format(Convert.ToDouble(Txt_TotalFactura.Text), "##,##00.00")
            Obj_Funciones.Guarda_Comprobantes_MR(Clave, ConsecutivoComprobante, NumeroConsecutivoReceptor, FechaEmisionDoc, TipoComprobante, TipoCedEmisor, CedulaEmisor, NombreEmisor, CorreoEmirosr, TipoComprobante, Estado, TipoCedReceptor, NombreRecetor, CorreoReceptor, MontoTotalImpuesto, TotalFactura, MHEstado, MHFecha, MHMensaje, CedulaReceptor, CodigoActividadEmisor, CondicionImpuesto, MontoTotalImpuestoAcreditarReceptor, MontoTotalDeGastoAplicableReceptor)
            Obj_xml.GeneraMR(Clave, TipoCedEmisor, CedulaEmisor, FechaEmisionDoc, CorreoEmirosr, TipoCedReceptor, CedulaReceptor, MontoTotalImpuesto, TotalFactura, "1", DetalleMensaje, "MR_Aceptado", CodigoActividadEmisor, CondicionImpuesto, MontoTotalImpuesto, MontoTotalImpuesto)




            Obj_xml = Nothing
            'btn_ConsultarEstadoMH.Visible = True
            'Panel_Acciones.Visible = True
            'Lbl_Procesando.Visible = False
            Cursor = Cursors.Default
            Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.btn_aceptar.Visible = False
            Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.btn_aceptarparcial.Visible = False
            Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.btn_rechaza.Visible = False

            Clave = Nothing
            ConsecutivoComprobante = Nothing
            NumeroConsecutivoReceptor = Nothing
            FechaEmisionDoc = Nothing
            TipoComprobante = Nothing
            TipoCedEmisor = Nothing
            CedulaEmisor = Nothing
            NombreEmisor = Nothing
            CorreoEmirosr = Nothing
            Estado = Nothing
            TipoCedReceptor = Nothing
            NombreRecetor = Nothing
            CorreoReceptor = Nothing
            MontoTotalImpuesto = Nothing
            TotalFactura = Nothing
            MHEstado = Nothing
            MHFecha = Nothing
            MHMensaje = Nothing
            CedulaReceptor = Nothing
            CodigoActividadEmisor = Nothing
            CondicionImpuesto = Nothing
            MontoTotalImpuestoAcreditarReceptor = Nothing
            MontoTotalDeGastoAplicableReceptor = Nothing
            DetalleMensaje = Nothing
            ' MessageBox.Show("Proceso finalizado")

        Catch ex As Exception
            MessageBox.Show("ERRRO EN Aceptar, " & ex.Message)
        End Try
    End Function
    Public Function AceptarParcial()
        Try
            'existen 5 columnas antes que son la de los botones y campospar aceptar en la lista
            '5  [ind_estado]
            '6  [Fecha_estado]
            '7  [MensajeHacienda]
            '8  (SELECT case when 8-(DATEDIFF(DAY, [Fecha],GETDATE())) < 0 then 0 else 8-(DATEDIFF(DAY, [Fecha],GETDATE())) end) as Dias
            '9  [Clave]
            '10 [ConsecutivoComprobante]
            '11 [TipoCedulaEmisor]
            '12 [NumeroCedulaEmisor]
            '13 [Nombre_Emisor]
            '14 [FechaEmisionDoc]
            '15 [MontoTotalImpuesto]
            '16 [TotalFactura]
            '17 [TipoCedulaReceptor]
            '18 [NumeroCedulaReceptor]
            '19 [Fecha]
            '20 [Hora]
            '21 [Tipo]
            '22 [NumeroConsecutivoReceptor]
            '23 [Mensaje]
            '24 [DetalleMensaje]
            '25 [CorreoElectronicoEmisor]
            '26 [Nombre_Receptor]
            '27 [CorreoElectronicoReceptor] 
            '28 [Motivo]
            '29 [CodigoActividad]
            '30 [CondicionImpuestoEmisor]
            '31 [MontoTotalImpuestoAcreditarEmisor]
            '32 [MontoTotalDeGastoAplicableEmisor]

            Dim Clave As String = DGV_ListaFE.Item(11, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim ConsecutivoComprobante As String = DGV_ListaFE.Item(12, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim NumeroConsecutivoReceptor As String = DGV_ListaFE.Item(24, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim FechaEmisionDoc As String = DGV_ListaFE.Item(16, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim TipoComprobante As String = DGV_ListaFE.Item(23, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim TipoCedEmisor As String = DGV_ListaFE.Item(13, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim CedulaEmisor As String = DGV_ListaFE.Item(14, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim NombreEmisor As String = DGV_ListaFE.Item(15, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim CorreoEmirosr As String = DGV_ListaFE.Item(27, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim Estado As String = DGV_ListaFE.Item(7, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim TipoCedReceptor As String = DGV_ListaFE.Item(19, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim NombreRecetor As String = DGV_ListaFE.Item(28, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim CorreoReceptor As String = DGV_ListaFE.Item(29, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim MontoTotalImpuesto As String = DGV_ListaFE.Item(17, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim TotalFactura As String = DGV_ListaFE.Item(18, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim MHEstado As String = DGV_ListaFE.Item(7, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim MHFecha As String = DGV_ListaFE.Item(8, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim MHMensaje As String = DGV_ListaFE.Item(9, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim CedulaReceptor As String = DGV_ListaFE.Item(20, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim CodigoActividadEmisor As String = DGV_ListaFE.Item(31, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim CondicionImpuesto As String = DGV_ListaFE.Item(32, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim MontoTotalImpuestoAcreditarReceptor As String = DGV_ListaFE.Item(32, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim MontoTotalDeGastoAplicableReceptor As String = DGV_ListaFE.Item(34, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim DetalleMensaje As String = DGV_ListaFE.Item(26, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            ' Cursor = Cursors.WaitCursor
            Dim Obj_xml As New XML_Generator
            'Lbl_Procesando.Visible = True
            'Lbl_Procesando.Text = "Procesando solicitud, porfavor espere.... "
            'btn_ConsultarEstadoMH.Visible = False
            'Panel_Acciones.Visible = False

            ' lbl_Estado.Text = "Comprobante Parcialmente Aceptado"



            Obj_Funciones.Guarda_Comprobantes_MR(Clave, ConsecutivoComprobante, NumeroConsecutivoReceptor, FechaEmisionDoc, TipoComprobante, TipoCedEmisor, CedulaEmisor, NombreEmisor, CorreoEmirosr, TipoComprobante, Estado, TipoCedReceptor, NombreRecetor, CorreoReceptor, MontoTotalImpuesto, TotalFactura, MHEstado, MHFecha, MHMensaje, CedulaReceptor, CodigoActividadEmisor, CondicionImpuesto, MontoTotalImpuestoAcreditarReceptor, MontoTotalDeGastoAplicableReceptor)
            Obj_xml.GeneraMR(Clave, TipoCedEmisor, CedulaEmisor, FechaEmisionDoc, CorreoEmirosr, TipoCedReceptor, CedulaReceptor, MontoTotalImpuesto, TotalFactura, "2", DetalleMensaje, "MR_Aceptado_Parcial", CodigoActividadEmisor, CondicionImpuesto, MontoTotalImpuesto, MontoTotalImpuesto)

            Obj_xml = Nothing
            Clave = Nothing
            ConsecutivoComprobante = Nothing
            NumeroConsecutivoReceptor = Nothing
            FechaEmisionDoc = Nothing
            TipoComprobante = Nothing
            TipoCedEmisor = Nothing
            CedulaEmisor = Nothing
            NombreEmisor = Nothing
            CorreoEmirosr = Nothing
            Estado = Nothing
            TipoCedReceptor = Nothing
            NombreRecetor = Nothing
            CorreoReceptor = Nothing
            MontoTotalImpuesto = Nothing
            TotalFactura = Nothing
            MHEstado = Nothing
            MHFecha = Nothing
            MHMensaje = Nothing
            CedulaReceptor = Nothing
            CodigoActividadEmisor = Nothing
            CondicionImpuesto = Nothing
            MontoTotalImpuestoAcreditarReceptor = Nothing
            MontoTotalDeGastoAplicableReceptor = Nothing
            DetalleMensaje = Nothing
            Cursor = Cursors.Default
            'Panel_Acciones.Visible = True
            'Lbl_Procesando.Visible = False
            'btn_ConsultarEstadoMH.Visible = True
            'MessageBox.Show("Proceso finalizado")
        Catch ex As Exception
            MessageBox.Show("ERRRO EN AceptarParcial, " & ex.Message)
        End Try
    End Function
    Public Function Rechazar()
        Try
            'Cursor = Cursors.WaitCursor
            Dim Obj_xml As New XML_Generator
            Dim Clave As String = DGV_ListaFE.Item(11, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim ConsecutivoComprobante As String = DGV_ListaFE.Item(12, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim NumeroConsecutivoReceptor As String = DGV_ListaFE.Item(24, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim FechaEmisionDoc As String = DGV_ListaFE.Item(16, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim TipoComprobante As String = DGV_ListaFE.Item(23, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim TipoCedEmisor As String = DGV_ListaFE.Item(13, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim CedulaEmisor As String = DGV_ListaFE.Item(14, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim NombreEmisor As String = DGV_ListaFE.Item(15, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim CorreoEmirosr As String = DGV_ListaFE.Item(27, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim Estado As String = DGV_ListaFE.Item(7, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim TipoCedReceptor As String = DGV_ListaFE.Item(19, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim NombreRecetor As String = DGV_ListaFE.Item(28, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim CorreoReceptor As String = DGV_ListaFE.Item(29, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim MontoTotalImpuesto As String = DGV_ListaFE.Item(17, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim TotalFactura As String = DGV_ListaFE.Item(18, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim MHEstado As String = DGV_ListaFE.Item(7, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim MHFecha As String = DGV_ListaFE.Item(8, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim MHMensaje As String = DGV_ListaFE.Item(9, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim CedulaReceptor As String = DGV_ListaFE.Item(20, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim CodigoActividadEmisor As String = DGV_ListaFE.Item(31, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim CondicionImpuesto As String = DGV_ListaFE.Item(32, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim MontoTotalImpuestoAcreditarReceptor As String = DGV_ListaFE.Item(32, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim MontoTotalDeGastoAplicableReceptor As String = DGV_ListaFE.Item(34, DGV_ListaFE.CurrentRow.Index).Value.ToString()
            Dim DetalleMensaje As String = DGV_ListaFE.Item(26, DGV_ListaFE.CurrentRow.Index).Value.ToString()

            'Lbl_Procesando.Visible = True
            'Lbl_Procesando.Text = "Procesando solicitud, porfavor espere.... "
            'btn_ConsultarEstadoMH.Visible = False
            'Panel_Acciones.Visible = False

            'lbl_Estado.Text = "Rechazado"
            Obj_Funciones.Guarda_Comprobantes_MR(Clave, ConsecutivoComprobante, NumeroConsecutivoReceptor, FechaEmisionDoc, TipoComprobante, TipoCedEmisor, CedulaEmisor, NombreEmisor, CorreoEmirosr, TipoComprobante, Estado, TipoCedReceptor, NombreRecetor, CorreoReceptor, MontoTotalImpuesto, TotalFactura, MHEstado, MHFecha, MHMensaje, CedulaReceptor, CodigoActividadEmisor, CondicionImpuesto, MontoTotalImpuestoAcreditarReceptor, MontoTotalDeGastoAplicableReceptor)
            Obj_xml.GeneraMR(Clave, TipoCedEmisor, CedulaEmisor, FechaEmisionDoc, CorreoEmirosr, TipoCedReceptor, CedulaReceptor, MontoTotalImpuesto, TotalFactura, "3", DetalleMensaje, "MR_Rechazado", CodigoActividadEmisor, CondicionImpuesto, MontoTotalImpuesto, MontoTotalImpuesto)


            Obj_xml = Nothing
            Clave = Nothing
            ConsecutivoComprobante = Nothing
            NumeroConsecutivoReceptor = Nothing
            FechaEmisionDoc = Nothing
            TipoComprobante = Nothing
            TipoCedEmisor = Nothing
            CedulaEmisor = Nothing
            NombreEmisor = Nothing
            CorreoEmirosr = Nothing
            Estado = Nothing
            TipoCedReceptor = Nothing
            NombreRecetor = Nothing
            CorreoReceptor = Nothing
            MontoTotalImpuesto = Nothing
            TotalFactura = Nothing
            MHEstado = Nothing
            MHFecha = Nothing
            MHMensaje = Nothing
            CedulaReceptor = Nothing
            CodigoActividadEmisor = Nothing
            CondicionImpuesto = Nothing
            MontoTotalImpuestoAcreditarReceptor = Nothing
            MontoTotalDeGastoAplicableReceptor = Nothing
            DetalleMensaje = Nothing
            Cursor = Cursors.Default


            'Panel_Acciones.Visible = True
            'Lbl_Procesando.Visible = False
            'btn_ConsultarEstadoMH.Visible = True
            'MessageBox.Show("Proceso finalizado")
        Catch ex As Exception
            MessageBox.Show("ERRRO EN Rechazar, " & ex.Message)
        End Try
    End Function
    Public Function Consultar()
        Dim Clave As String = DGV_ListaFE.Item(13, DGV_ListaFE.CurrentRow.Index).Value.ToString()
        Dim NumeroConsecutivoReceptor As String = DGV_ListaFE.Item(24, DGV_ListaFE.CurrentRow.Index).Value.ToString()

        If Clave <> "" Then

            'Lbl_Procesando.Visible = True
            'Lbl_Procesando.Text = "Procesando solicitud, porfavor espere.... "
            'btn_ConsultarEstadoMH.Visible = False
            'Panel_Acciones.Visible = False
            'Cursor = Cursors.WaitCursor
            Dim enviaFactura As New Comunicacion
            Dim Token As String = ""


            Token = Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.getToken("MR")
            'Me.Txt_TokenHacienda.Text = Token

            enviaFactura.ConsultaEstatus(Token, Clave, VariablesGlobales.Patch_MR & "\" & NumeroConsecutivoReceptor & "\" & NumeroConsecutivoReceptor, "MR", NumeroConsecutivoReceptor)

            Cursor = Cursors.Default
            'btn_ConsultarEstadoMH.Visible = True
            'Panel_Acciones.Visible = True
            'Lbl_Procesando.Visible = False

        End If
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            Dim Motivo As String = Cmb_Estado.Text
            Dim Tipo As String = Cmb_Tipo.Text
            Dim Clave As String = txtb_clave.Text
            Dim Situacion_de_Comprobante As String = Cmb_EstadoDefinido.Text

            DGV_ListaFE.DataSource = Obj_Sql.ObtieneComprobantesProveedores(txtb_proveedor.Text, Motivo, Cmb_Tipo.Text, Clave, Situacion_de_Comprobante, Cmb_Estado.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Ini.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Dtp_Fin.Value.Date), Cmb_EstadoDefinido.Text, Cxb_BFecha.Checked, Cxb_VerProcesadas.Checked)
            Ordenar()
        Catch ex As Exception

        End Try
    End Sub
End Class
