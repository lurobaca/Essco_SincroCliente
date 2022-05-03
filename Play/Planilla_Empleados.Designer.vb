<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Planilla_Empleados
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Planilla_Empleados))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Btn_ExGuardar = New System.Windows.Forms.Button
        Me.Btn_ExNuevo = New System.Windows.Forms.Button
        Me.Btn_ExEliminar = New System.Windows.Forms.Button
        Me.Txb_ExPuesto = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Txb_Comentario = New System.Windows.Forms.TextBox
        Me.Txb_Telefono = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Txb_Persona = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Txb_Empresa = New System.Windows.Forms.TextBox
        Me.DTP_ExFechaSalida = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.DTGV_Experiencia = New System.Windows.Forms.DataGridView
        Me.DTP_ExFechaIngreso = New System.Windows.Forms.DateTimePicker
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Btn_EdEliminar = New System.Windows.Forms.Button
        Me.Btn_EdNuevo = New System.Windows.Forms.Button
        Me.Btn_EdGuarda = New System.Windows.Forms.Button
        Me.Label28 = New System.Windows.Forms.Label
        Me.CBox_Grado = New System.Windows.Forms.ComboBox
        Me.Txb_Titulo = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.CkBx_Encurso = New System.Windows.Forms.CheckBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.DTP_EFechaSalida = New System.Windows.Forms.DateTimePicker
        Me.Label26 = New System.Windows.Forms.Label
        Me.DTP_EFechaIngreso = New System.Windows.Forms.DateTimePicker
        Me.Txb_Institucion = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.DTGV_Educacion = New System.Windows.Forms.DataGridView
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Label47 = New System.Windows.Forms.Label
        Me.txtb_Pendientes = New System.Windows.Forms.TextBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_DCEliminar = New System.Windows.Forms.Button
        Me.txtb_comentario = New System.Windows.Forms.TextBox
        Me.Label46 = New System.Windows.Forms.Label
        Me.txtb_VCTotal = New System.Windows.Forms.TextBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.Txb_VCDias = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.DTP_VCFechaFin = New System.Windows.Forms.DateTimePicker
        Me.DTP_VCFechaIni = New System.Windows.Forms.DateTimePicker
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.DGV_VacacionesConsumidas = New System.Windows.Forms.DataGridView
        Me.btn_GuardaVacaciones = New System.Windows.Forms.Button
        Me.Label34 = New System.Windows.Forms.Label
        Me.txtb_Vacaciones = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.txtb_Dias = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.txtb_Meses = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.txtb_Anos = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.DGV_Facturas = New System.Windows.Forms.DataGridView
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.Label57 = New System.Windows.Forms.Label
        Me.Txb_Dedu_Otro = New System.Windows.Forms.TextBox
        Me.Label56 = New System.Windows.Forms.Label
        Me.Txb_Dedu_Prestamo = New System.Windows.Forms.TextBox
        Me.Label55 = New System.Windows.Forms.Label
        Me.Txb_Dedu_Faltante = New System.Windows.Forms.TextBox
        Me.Label54 = New System.Windows.Forms.Label
        Me.Txb_Dedu_Facturas = New System.Windows.Forms.TextBox
        Me.Label53 = New System.Windows.Forms.Label
        Me.Txb_Dedu_FaltaLiq = New System.Windows.Forms.TextBox
        Me.Label52 = New System.Windows.Forms.Label
        Me.Txb_Dedu_Embargo = New System.Windows.Forms.TextBox
        Me.Txb_Dedu_Celular = New System.Windows.Forms.TextBox
        Me.Label51 = New System.Windows.Forms.Label
        Me.Label50 = New System.Windows.Forms.Label
        Me.Txb_Dedu_Ducc_Cuota = New System.Windows.Forms.TextBox
        Me.Label49 = New System.Windows.Forms.Label
        Me.Txb_Dedu_Deb_Personal = New System.Windows.Forms.TextBox
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.txb_MontoDeducciones = New System.Windows.Forms.TextBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.btn_EliminarDeduccion = New System.Windows.Forms.Button
        Me.Btn_GuardarDeduccion = New System.Windows.Forms.Button
        Me.DGV_Deducciones = New System.Windows.Forms.DataGridView
        Me.Txb_Dedu_CCSS = New System.Windows.Forms.TextBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.Txb_Dedu_Adicional = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txb_Cedula = New System.Windows.Forms.TextBox
        Me.Txb_Nombre = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txb_Telefono1 = New System.Windows.Forms.TextBox
        Me.Txb_Telefono2 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Txb_Salario = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.DTP_FechaIngreso = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.DTP_FechaSalida = New System.Windows.Forms.DateTimePicker
        Me.Btn_Guardar = New System.Windows.Forms.Button
        Me.Btn_Nuevo = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.TextBox12 = New System.Windows.Forms.TextBox
        Me.TextBox13 = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.TextBox14 = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.TextBox15 = New System.Windows.Forms.TextBox
        Me.DateTimePicker5 = New System.Windows.Forms.DateTimePicker
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.TextBox16 = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.DateTimePicker6 = New System.Windows.Forms.DateTimePicker
        Me.Btn_Informe = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Txb_RutaImagen = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.ChkB_Activo = New System.Windows.Forms.CheckBox
        Me.Txb_Codigo = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.Txt_Id = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.Btn_Atras = New System.Windows.Forms.Button
        Me.Btn_Adelante = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Txtb_CodRuta = New System.Windows.Forms.TextBox
        Me.lbl_ruta = New System.Windows.Forms.Label
        Me.btn_NuevoPuesto = New System.Windows.Forms.Button
        Me.CBox_Puesto = New System.Windows.Forms.ComboBox
        Me.Label65 = New System.Windows.Forms.Label
        Me.txtb_Correo = New System.Windows.Forms.TextBox
        Me.Txb_CodigoCobroXFaltante = New System.Windows.Forms.TextBox
        Me.Label58 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DTGV_Experiencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DTGV_Educacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV_VacacionesConsumidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.DGV_Facturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.DGV_Deducciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(0, 182)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(825, 401)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Btn_ExGuardar)
        Me.TabPage1.Controls.Add(Me.Btn_ExNuevo)
        Me.TabPage1.Controls.Add(Me.Btn_ExEliminar)
        Me.TabPage1.Controls.Add(Me.Txb_ExPuesto)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Txb_Comentario)
        Me.TabPage1.Controls.Add(Me.Txb_Telefono)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Txb_Persona)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Txb_Empresa)
        Me.TabPage1.Controls.Add(Me.DTP_ExFechaSalida)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.DTGV_Experiencia)
        Me.TabPage1.Controls.Add(Me.DTP_ExFechaIngreso)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(817, 375)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Experiencia"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Btn_ExGuardar
        '
        Me.Btn_ExGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_ExGuardar.Location = New System.Drawing.Point(431, 214)
        Me.Btn_ExGuardar.Name = "Btn_ExGuardar"
        Me.Btn_ExGuardar.Size = New System.Drawing.Size(75, 29)
        Me.Btn_ExGuardar.TabIndex = 30
        Me.Btn_ExGuardar.Text = "Guardar"
        Me.Btn_ExGuardar.UseVisualStyleBackColor = True
        '
        'Btn_ExNuevo
        '
        Me.Btn_ExNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_ExNuevo.Location = New System.Drawing.Point(430, 179)
        Me.Btn_ExNuevo.Name = "Btn_ExNuevo"
        Me.Btn_ExNuevo.Size = New System.Drawing.Size(75, 29)
        Me.Btn_ExNuevo.TabIndex = 29
        Me.Btn_ExNuevo.Text = "Nuevo"
        Me.Btn_ExNuevo.UseVisualStyleBackColor = True
        '
        'Btn_ExEliminar
        '
        Me.Btn_ExEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_ExEliminar.Location = New System.Drawing.Point(430, 249)
        Me.Btn_ExEliminar.Name = "Btn_ExEliminar"
        Me.Btn_ExEliminar.Size = New System.Drawing.Size(75, 29)
        Me.Btn_ExEliminar.TabIndex = 31
        Me.Btn_ExEliminar.Text = "Eliminar"
        Me.Btn_ExEliminar.UseVisualStyleBackColor = True
        '
        'Txb_ExPuesto
        '
        Me.Txb_ExPuesto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txb_ExPuesto.Location = New System.Drawing.Point(666, 127)
        Me.Txb_ExPuesto.Name = "Txb_ExPuesto"
        Me.Txb_ExPuesto.Size = New System.Drawing.Size(143, 20)
        Me.Txb_ExPuesto.TabIndex = 27
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(620, 133)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 13)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "Puesto"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(427, 158)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(152, 13)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Razon de salida / Comentarios"
        '
        'Txb_Comentario
        '
        Me.Txb_Comentario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txb_Comentario.Location = New System.Drawing.Point(534, 174)
        Me.Txb_Comentario.Multiline = True
        Me.Txb_Comentario.Name = "Txb_Comentario"
        Me.Txb_Comentario.Size = New System.Drawing.Size(272, 113)
        Me.Txb_Comentario.TabIndex = 28
        '
        'Txb_Telefono
        '
        Me.Txb_Telefono.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txb_Telefono.Location = New System.Drawing.Point(534, 127)
        Me.Txb_Telefono.Name = "Txb_Telefono"
        Me.Txb_Telefono.Size = New System.Drawing.Size(76, 20)
        Me.Txb_Telefono.TabIndex = 26
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(427, 130)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Telefono 1"
        '
        'Txb_Persona
        '
        Me.Txb_Persona.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txb_Persona.Location = New System.Drawing.Point(534, 94)
        Me.Txb_Persona.Name = "Txb_Persona"
        Me.Txb_Persona.Size = New System.Drawing.Size(275, 20)
        Me.Txb_Persona.TabIndex = 24
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(427, 101)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 13)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "Persona Referencia"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(427, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Fecha Salida"
        '
        'Txb_Empresa
        '
        Me.Txb_Empresa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txb_Empresa.Location = New System.Drawing.Point(534, 11)
        Me.Txb_Empresa.Name = "Txb_Empresa"
        Me.Txb_Empresa.Size = New System.Drawing.Size(275, 20)
        Me.Txb_Empresa.TabIndex = 2
        '
        'DTP_ExFechaSalida
        '
        Me.DTP_ExFechaSalida.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_ExFechaSalida.Location = New System.Drawing.Point(534, 68)
        Me.DTP_ExFechaSalida.Name = "DTP_ExFechaSalida"
        Me.DTP_ExFechaSalida.Size = New System.Drawing.Size(275, 20)
        Me.DTP_ExFechaSalida.TabIndex = 21
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(427, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Empresa"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(427, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Fecha Ingreso"
        '
        'DTGV_Experiencia
        '
        Me.DTGV_Experiencia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTGV_Experiencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DTGV_Experiencia.Location = New System.Drawing.Point(6, 6)
        Me.DTGV_Experiencia.Name = "DTGV_Experiencia"
        Me.DTGV_Experiencia.Size = New System.Drawing.Size(411, 281)
        Me.DTGV_Experiencia.TabIndex = 0
        '
        'DTP_ExFechaIngreso
        '
        Me.DTP_ExFechaIngreso.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_ExFechaIngreso.Location = New System.Drawing.Point(534, 37)
        Me.DTP_ExFechaIngreso.Name = "DTP_ExFechaIngreso"
        Me.DTP_ExFechaIngreso.Size = New System.Drawing.Size(275, 20)
        Me.DTP_ExFechaIngreso.TabIndex = 19
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Btn_EdEliminar)
        Me.TabPage2.Controls.Add(Me.Btn_EdNuevo)
        Me.TabPage2.Controls.Add(Me.Btn_EdGuarda)
        Me.TabPage2.Controls.Add(Me.Label28)
        Me.TabPage2.Controls.Add(Me.CBox_Grado)
        Me.TabPage2.Controls.Add(Me.Txb_Titulo)
        Me.TabPage2.Controls.Add(Me.Label27)
        Me.TabPage2.Controls.Add(Me.CkBx_Encurso)
        Me.TabPage2.Controls.Add(Me.Label25)
        Me.TabPage2.Controls.Add(Me.DTP_EFechaSalida)
        Me.TabPage2.Controls.Add(Me.Label26)
        Me.TabPage2.Controls.Add(Me.DTP_EFechaIngreso)
        Me.TabPage2.Controls.Add(Me.Txb_Institucion)
        Me.TabPage2.Controls.Add(Me.Label24)
        Me.TabPage2.Controls.Add(Me.DTGV_Educacion)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(817, 375)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Educacion"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Btn_EdEliminar
        '
        Me.Btn_EdEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_EdEliminar.Location = New System.Drawing.Point(709, 245)
        Me.Btn_EdEliminar.Name = "Btn_EdEliminar"
        Me.Btn_EdEliminar.Size = New System.Drawing.Size(75, 29)
        Me.Btn_EdEliminar.TabIndex = 39
        Me.Btn_EdEliminar.Text = "Eliminar"
        Me.Btn_EdEliminar.UseVisualStyleBackColor = True
        '
        'Btn_EdNuevo
        '
        Me.Btn_EdNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_EdNuevo.Location = New System.Drawing.Point(539, 245)
        Me.Btn_EdNuevo.Name = "Btn_EdNuevo"
        Me.Btn_EdNuevo.Size = New System.Drawing.Size(75, 29)
        Me.Btn_EdNuevo.TabIndex = 38
        Me.Btn_EdNuevo.Text = "Nuevo"
        Me.Btn_EdNuevo.UseVisualStyleBackColor = True
        '
        'Btn_EdGuarda
        '
        Me.Btn_EdGuarda.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_EdGuarda.Location = New System.Drawing.Point(623, 245)
        Me.Btn_EdGuarda.Name = "Btn_EdGuarda"
        Me.Btn_EdGuarda.Size = New System.Drawing.Size(75, 29)
        Me.Btn_EdGuarda.TabIndex = 37
        Me.Btn_EdGuarda.Text = "Guardar"
        Me.Btn_EdGuarda.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(428, 141)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(36, 13)
        Me.Label28.TabIndex = 36
        Me.Label28.Text = "Grado"
        '
        'CBox_Grado
        '
        Me.CBox_Grado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CBox_Grado.FormattingEnabled = True
        Me.CBox_Grado.Items.AddRange(New Object() {"Primaria", "Secundaria", "Universitaria", "Otro"})
        Me.CBox_Grado.Location = New System.Drawing.Point(535, 133)
        Me.CBox_Grado.Name = "CBox_Grado"
        Me.CBox_Grado.Size = New System.Drawing.Size(121, 21)
        Me.CBox_Grado.TabIndex = 35
        '
        'Txb_Titulo
        '
        Me.Txb_Titulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txb_Titulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Titulo.Location = New System.Drawing.Point(535, 171)
        Me.Txb_Titulo.Name = "Txb_Titulo"
        Me.Txb_Titulo.Size = New System.Drawing.Size(275, 20)
        Me.Txb_Titulo.TabIndex = 34
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(428, 174)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(33, 13)
        Me.Label27.TabIndex = 33
        Me.Label27.Text = "Titulo"
        '
        'CkBx_Encurso
        '
        Me.CkBx_Encurso.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CkBx_Encurso.AutoSize = True
        Me.CkBx_Encurso.Location = New System.Drawing.Point(431, 110)
        Me.CkBx_Encurso.Name = "CkBx_Encurso"
        Me.CkBx_Encurso.Size = New System.Drawing.Size(65, 17)
        Me.CkBx_Encurso.TabIndex = 32
        Me.CkBx_Encurso.Text = "Encurso"
        Me.CkBx_Encurso.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(427, 83)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(69, 13)
        Me.Label25.TabIndex = 26
        Me.Label25.Text = "Fecha Salida"
        '
        'DTP_EFechaSalida
        '
        Me.DTP_EFechaSalida.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_EFechaSalida.Location = New System.Drawing.Point(534, 77)
        Me.DTP_EFechaSalida.Name = "DTP_EFechaSalida"
        Me.DTP_EFechaSalida.Size = New System.Drawing.Size(275, 20)
        Me.DTP_EFechaSalida.TabIndex = 25
        '
        'Label26
        '
        Me.Label26.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(427, 53)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(75, 13)
        Me.Label26.TabIndex = 24
        Me.Label26.Text = "Fecha Ingreso"
        '
        'DTP_EFechaIngreso
        '
        Me.DTP_EFechaIngreso.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_EFechaIngreso.Location = New System.Drawing.Point(534, 46)
        Me.DTP_EFechaIngreso.Name = "DTP_EFechaIngreso"
        Me.DTP_EFechaIngreso.Size = New System.Drawing.Size(275, 20)
        Me.DTP_EFechaIngreso.TabIndex = 23
        '
        'Txb_Institucion
        '
        Me.Txb_Institucion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txb_Institucion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Institucion.Location = New System.Drawing.Point(534, 20)
        Me.Txb_Institucion.Name = "Txb_Institucion"
        Me.Txb_Institucion.Size = New System.Drawing.Size(275, 20)
        Me.Txb_Institucion.TabIndex = 4
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(427, 23)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(55, 13)
        Me.Label24.TabIndex = 3
        Me.Label24.Text = "Institucion"
        '
        'DTGV_Educacion
        '
        Me.DTGV_Educacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTGV_Educacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DTGV_Educacion.Location = New System.Drawing.Point(3, 3)
        Me.DTGV_Educacion.Name = "DTGV_Educacion"
        Me.DTGV_Educacion.Size = New System.Drawing.Size(411, 281)
        Me.DTGV_Educacion.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label47)
        Me.TabPage3.Controls.Add(Me.txtb_Pendientes)
        Me.TabPage3.Controls.Add(Me.Label44)
        Me.TabPage3.Controls.Add(Me.TextBox2)
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Controls.Add(Me.Label34)
        Me.TabPage3.Controls.Add(Me.txtb_Vacaciones)
        Me.TabPage3.Controls.Add(Me.Label32)
        Me.TabPage3.Controls.Add(Me.txtb_Dias)
        Me.TabPage3.Controls.Add(Me.Label31)
        Me.TabPage3.Controls.Add(Me.txtb_Meses)
        Me.TabPage3.Controls.Add(Me.Label33)
        Me.TabPage3.Controls.Add(Me.Label29)
        Me.TabPage3.Controls.Add(Me.txtb_Anos)
        Me.TabPage3.Controls.Add(Me.Label9)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(817, 375)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Vacaciones"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label47
        '
        Me.Label47.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(717, 9)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(84, 13)
        Me.Label47.TabIndex = 44
        Me.Label47.Text = "Dias Pendientes"
        '
        'txtb_Pendientes
        '
        Me.txtb_Pendientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_Pendientes.Location = New System.Drawing.Point(731, 25)
        Me.txtb_Pendientes.Name = "txtb_Pendientes"
        Me.txtb_Pendientes.Size = New System.Drawing.Size(69, 20)
        Me.txtb_Pendientes.TabIndex = 43
        '
        'Label44
        '
        Me.Label44.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(504, 7)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(37, 13)
        Me.Label44.TabIndex = 41
        Me.Label44.Text = "Monto"
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.Location = New System.Drawing.Point(491, 26)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(69, 20)
        Me.TextBox2.TabIndex = 40
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_DCEliminar)
        Me.GroupBox1.Controls.Add(Me.txtb_comentario)
        Me.GroupBox1.Controls.Add(Me.Label46)
        Me.GroupBox1.Controls.Add(Me.txtb_VCTotal)
        Me.GroupBox1.Controls.Add(Me.Label43)
        Me.GroupBox1.Controls.Add(Me.Txb_VCDias)
        Me.GroupBox1.Controls.Add(Me.Label39)
        Me.GroupBox1.Controls.Add(Me.DTP_VCFechaFin)
        Me.GroupBox1.Controls.Add(Me.DTP_VCFechaIni)
        Me.GroupBox1.Controls.Add(Me.Label38)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.DGV_VacacionesConsumidas)
        Me.GroupBox1.Controls.Add(Me.btn_GuardaVacaciones)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(798, 273)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consumo de Vacaciones"
        '
        'btn_DCEliminar
        '
        Me.btn_DCEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_DCEliminar.Location = New System.Drawing.Point(248, 175)
        Me.btn_DCEliminar.Name = "btn_DCEliminar"
        Me.btn_DCEliminar.Size = New System.Drawing.Size(75, 35)
        Me.btn_DCEliminar.TabIndex = 49
        Me.btn_DCEliminar.Text = "Eliminar"
        Me.btn_DCEliminar.UseVisualStyleBackColor = True
        '
        'txtb_comentario
        '
        Me.txtb_comentario.Location = New System.Drawing.Point(15, 153)
        Me.txtb_comentario.Multiline = True
        Me.txtb_comentario.Name = "txtb_comentario"
        Me.txtb_comentario.Size = New System.Drawing.Size(227, 114)
        Me.txtb_comentario.TabIndex = 48
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(12, 137)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(60, 13)
        Me.Label46.TabIndex = 47
        Me.Label46.Text = "Comentario"
        '
        'txtb_VCTotal
        '
        Me.txtb_VCTotal.Location = New System.Drawing.Point(683, 247)
        Me.txtb_VCTotal.Name = "txtb_VCTotal"
        Me.txtb_VCTotal.Size = New System.Drawing.Size(109, 20)
        Me.txtb_VCTotal.TabIndex = 46
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(339, 247)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(88, 13)
        Me.Label43.TabIndex = 45
        Me.Label43.Text = "Dias Consumidos"
        '
        'Txb_VCDias
        '
        Me.Txb_VCDias.Location = New System.Drawing.Point(111, 101)
        Me.Txb_VCDias.Name = "Txb_VCDias"
        Me.Txb_VCDias.Size = New System.Drawing.Size(100, 20)
        Me.Txb_VCDias.TabIndex = 44
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(17, 104)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(28, 13)
        Me.Label39.TabIndex = 43
        Me.Label39.Text = "Dias"
        '
        'DTP_VCFechaFin
        '
        Me.DTP_VCFechaFin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_VCFechaFin.Location = New System.Drawing.Point(113, 68)
        Me.DTP_VCFechaFin.Name = "DTP_VCFechaFin"
        Me.DTP_VCFechaFin.Size = New System.Drawing.Size(203, 20)
        Me.DTP_VCFechaFin.TabIndex = 42
        '
        'DTP_VCFechaIni
        '
        Me.DTP_VCFechaIni.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_VCFechaIni.Location = New System.Drawing.Point(113, 37)
        Me.DTP_VCFechaIni.Name = "DTP_VCFechaIni"
        Me.DTP_VCFechaIni.Size = New System.Drawing.Size(203, 20)
        Me.DTP_VCFechaIni.TabIndex = 41
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(17, 72)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(35, 13)
        Me.Label38.TabIndex = 40
        Me.Label38.Text = "Hasta"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(17, 37)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(38, 13)
        Me.Label37.TabIndex = 38
        Me.Label37.Text = "Desde"
        '
        'DGV_VacacionesConsumidas
        '
        Me.DGV_VacacionesConsumidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_VacacionesConsumidas.Location = New System.Drawing.Point(329, 19)
        Me.DGV_VacacionesConsumidas.Name = "DGV_VacacionesConsumidas"
        Me.DGV_VacacionesConsumidas.Size = New System.Drawing.Size(463, 222)
        Me.DGV_VacacionesConsumidas.TabIndex = 37
        '
        'btn_GuardaVacaciones
        '
        Me.btn_GuardaVacaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_GuardaVacaciones.Location = New System.Drawing.Point(248, 134)
        Me.btn_GuardaVacaciones.Name = "btn_GuardaVacaciones"
        Me.btn_GuardaVacaciones.Size = New System.Drawing.Size(75, 35)
        Me.btn_GuardaVacaciones.TabIndex = 34
        Me.btn_GuardaVacaciones.Text = "Guardar"
        Me.btn_GuardaVacaciones.UseVisualStyleBackColor = True
        '
        'Label34
        '
        Me.Label34.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(429, 7)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(28, 13)
        Me.Label34.TabIndex = 35
        Me.Label34.Text = "Dias"
        '
        'txtb_Vacaciones
        '
        Me.txtb_Vacaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_Vacaciones.Location = New System.Drawing.Point(416, 26)
        Me.txtb_Vacaciones.Name = "txtb_Vacaciones"
        Me.txtb_Vacaciones.Size = New System.Drawing.Size(69, 20)
        Me.txtb_Vacaciones.TabIndex = 34
        '
        'Label32
        '
        Me.Label32.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(296, 5)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(28, 13)
        Me.Label32.TabIndex = 29
        Me.Label32.Text = "Dias"
        '
        'txtb_Dias
        '
        Me.txtb_Dias.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_Dias.Location = New System.Drawing.Point(276, 21)
        Me.txtb_Dias.Name = "txtb_Dias"
        Me.txtb_Dias.Size = New System.Drawing.Size(69, 20)
        Me.txtb_Dias.TabIndex = 28
        '
        'Label31
        '
        Me.Label31.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(214, 5)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(38, 13)
        Me.Label31.TabIndex = 27
        Me.Label31.Text = "Meses"
        '
        'txtb_Meses
        '
        Me.txtb_Meses.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_Meses.Location = New System.Drawing.Point(196, 21)
        Me.txtb_Meses.Name = "txtb_Meses"
        Me.txtb_Meses.Size = New System.Drawing.Size(69, 20)
        Me.txtb_Meses.TabIndex = 26
        '
        'Label33
        '
        Me.Label33.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(347, 28)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(63, 13)
        Me.Label33.TabIndex = 24
        Me.Label33.Text = "Vacaciones"
        '
        'Label29
        '
        Me.Label29.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(139, 5)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(31, 13)
        Me.Label29.TabIndex = 21
        Me.Label29.Text = "Años"
        '
        'txtb_Anos
        '
        Me.txtb_Anos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_Anos.Location = New System.Drawing.Point(119, 21)
        Me.txtb_Anos.Name = "txtb_Anos"
        Me.txtb_Anos.Size = New System.Drawing.Size(69, 20)
        Me.txtb_Anos.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Tiempo Laborado"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.DGV_Facturas)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(817, 375)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Facturas"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'DGV_Facturas
        '
        Me.DGV_Facturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Facturas.Location = New System.Drawing.Point(8, 32)
        Me.DGV_Facturas.Name = "DGV_Facturas"
        Me.DGV_Facturas.Size = New System.Drawing.Size(801, 299)
        Me.DGV_Facturas.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Label57)
        Me.TabPage5.Controls.Add(Me.Txb_Dedu_Otro)
        Me.TabPage5.Controls.Add(Me.Label56)
        Me.TabPage5.Controls.Add(Me.Txb_Dedu_Prestamo)
        Me.TabPage5.Controls.Add(Me.Label55)
        Me.TabPage5.Controls.Add(Me.Txb_Dedu_Faltante)
        Me.TabPage5.Controls.Add(Me.Label54)
        Me.TabPage5.Controls.Add(Me.Txb_Dedu_Facturas)
        Me.TabPage5.Controls.Add(Me.Label53)
        Me.TabPage5.Controls.Add(Me.Txb_Dedu_FaltaLiq)
        Me.TabPage5.Controls.Add(Me.Label52)
        Me.TabPage5.Controls.Add(Me.Txb_Dedu_Embargo)
        Me.TabPage5.Controls.Add(Me.Txb_Dedu_Celular)
        Me.TabPage5.Controls.Add(Me.Label51)
        Me.TabPage5.Controls.Add(Me.Label50)
        Me.TabPage5.Controls.Add(Me.Txb_Dedu_Ducc_Cuota)
        Me.TabPage5.Controls.Add(Me.Label49)
        Me.TabPage5.Controls.Add(Me.Txb_Dedu_Deb_Personal)
        Me.TabPage5.Controls.Add(Me.Label48)
        Me.TabPage5.Controls.Add(Me.Label45)
        Me.TabPage5.Controls.Add(Me.txb_MontoDeducciones)
        Me.TabPage5.Controls.Add(Me.Label42)
        Me.TabPage5.Controls.Add(Me.btn_EliminarDeduccion)
        Me.TabPage5.Controls.Add(Me.Btn_GuardarDeduccion)
        Me.TabPage5.Controls.Add(Me.DGV_Deducciones)
        Me.TabPage5.Controls.Add(Me.Txb_Dedu_CCSS)
        Me.TabPage5.Controls.Add(Me.Label40)
        Me.TabPage5.Controls.Add(Me.Txb_Dedu_Adicional)
        Me.TabPage5.Controls.Add(Me.Label36)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(817, 375)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Deducciones"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(593, 5)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(45, 13)
        Me.Label57.TabIndex = 41
        Me.Label57.Text = "Planillas"
        '
        'Txb_Dedu_Otro
        '
        Me.Txb_Dedu_Otro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_Otro.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_Otro.ForeColor = System.Drawing.Color.Red
        Me.Txb_Dedu_Otro.Location = New System.Drawing.Point(196, 328)
        Me.Txb_Dedu_Otro.Name = "Txb_Dedu_Otro"
        Me.Txb_Dedu_Otro.Size = New System.Drawing.Size(196, 22)
        Me.Txb_Dedu_Otro.TabIndex = 40
        Me.Txb_Dedu_Otro.Text = "0"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(30, 333)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(45, 13)
        Me.Label56.TabIndex = 39
        Me.Label56.Text = "OTROS"
        '
        'Txb_Dedu_Prestamo
        '
        Me.Txb_Dedu_Prestamo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_Prestamo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_Prestamo.ForeColor = System.Drawing.Color.Red
        Me.Txb_Dedu_Prestamo.Location = New System.Drawing.Point(196, 271)
        Me.Txb_Dedu_Prestamo.Name = "Txb_Dedu_Prestamo"
        Me.Txb_Dedu_Prestamo.Size = New System.Drawing.Size(196, 22)
        Me.Txb_Dedu_Prestamo.TabIndex = 38
        Me.Txb_Dedu_Prestamo.Text = "0"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(31, 276)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(115, 13)
        Me.Label55.TabIndex = 37
        Me.Label55.Text = "COBROS PRESTAMO"
        '
        'Txb_Dedu_Faltante
        '
        Me.Txb_Dedu_Faltante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_Faltante.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_Faltante.ForeColor = System.Drawing.Color.Red
        Me.Txb_Dedu_Faltante.Location = New System.Drawing.Point(196, 240)
        Me.Txb_Dedu_Faltante.Name = "Txb_Dedu_Faltante"
        Me.Txb_Dedu_Faltante.Size = New System.Drawing.Size(196, 22)
        Me.Txb_Dedu_Faltante.TabIndex = 36
        Me.Txb_Dedu_Faltante.Text = "0"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(30, 244)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(120, 13)
        Me.Label54.TabIndex = 35
        Me.Label54.Text = "COBROS X FALTANTE"
        '
        'Txb_Dedu_Facturas
        '
        Me.Txb_Dedu_Facturas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_Facturas.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_Facturas.ForeColor = System.Drawing.Color.Red
        Me.Txb_Dedu_Facturas.Location = New System.Drawing.Point(196, 209)
        Me.Txb_Dedu_Facturas.Name = "Txb_Dedu_Facturas"
        Me.Txb_Dedu_Facturas.Size = New System.Drawing.Size(196, 22)
        Me.Txb_Dedu_Facturas.TabIndex = 34
        Me.Txb_Dedu_Facturas.Text = "0"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(30, 213)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(64, 13)
        Me.Label53.TabIndex = 33
        Me.Label53.Text = "FACTURAS"
        '
        'Txb_Dedu_FaltaLiq
        '
        Me.Txb_Dedu_FaltaLiq.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_FaltaLiq.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_FaltaLiq.ForeColor = System.Drawing.Color.Red
        Me.Txb_Dedu_FaltaLiq.Location = New System.Drawing.Point(196, 178)
        Me.Txb_Dedu_FaltaLiq.Name = "Txb_Dedu_FaltaLiq"
        Me.Txb_Dedu_FaltaLiq.Size = New System.Drawing.Size(196, 22)
        Me.Txb_Dedu_FaltaLiq.TabIndex = 32
        Me.Txb_Dedu_FaltaLiq.Text = "0"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(30, 183)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(89, 13)
        Me.Label52.TabIndex = 31
        Me.Label52.Text = "FALTANTES LIQ"
        '
        'Txb_Dedu_Embargo
        '
        Me.Txb_Dedu_Embargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_Embargo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_Embargo.ForeColor = System.Drawing.Color.Red
        Me.Txb_Dedu_Embargo.Location = New System.Drawing.Point(196, 147)
        Me.Txb_Dedu_Embargo.Name = "Txb_Dedu_Embargo"
        Me.Txb_Dedu_Embargo.Size = New System.Drawing.Size(196, 22)
        Me.Txb_Dedu_Embargo.TabIndex = 30
        Me.Txb_Dedu_Embargo.Text = "0"
        '
        'Txb_Dedu_Celular
        '
        Me.Txb_Dedu_Celular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_Celular.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_Celular.ForeColor = System.Drawing.Color.Red
        Me.Txb_Dedu_Celular.Location = New System.Drawing.Point(196, 115)
        Me.Txb_Dedu_Celular.Name = "Txb_Dedu_Celular"
        Me.Txb_Dedu_Celular.Size = New System.Drawing.Size(196, 22)
        Me.Txb_Dedu_Celular.TabIndex = 30
        Me.Txb_Dedu_Celular.Text = "0"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(30, 152)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(61, 13)
        Me.Label51.TabIndex = 29
        Me.Label51.Text = "EMBARGO"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(30, 120)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(134, 13)
        Me.Label50.TabIndex = 29
        Me.Label50.Text = "DEDUCION DE CELULAR"
        '
        'Txb_Dedu_Ducc_Cuota
        '
        Me.Txb_Dedu_Ducc_Cuota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_Ducc_Cuota.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_Ducc_Cuota.ForeColor = System.Drawing.Color.Red
        Me.Txb_Dedu_Ducc_Cuota.Location = New System.Drawing.Point(196, 83)
        Me.Txb_Dedu_Ducc_Cuota.Name = "Txb_Dedu_Ducc_Cuota"
        Me.Txb_Dedu_Ducc_Cuota.Size = New System.Drawing.Size(196, 22)
        Me.Txb_Dedu_Ducc_Cuota.TabIndex = 28
        Me.Txb_Dedu_Ducc_Cuota.Text = "0"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(30, 88)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(94, 13)
        Me.Label49.TabIndex = 27
        Me.Label49.Text = "DUCC CUOTA BP"
        '
        'Txb_Dedu_Deb_Personal
        '
        Me.Txb_Dedu_Deb_Personal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_Deb_Personal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_Deb_Personal.ForeColor = System.Drawing.Color.Red
        Me.Txb_Dedu_Deb_Personal.Location = New System.Drawing.Point(196, 52)
        Me.Txb_Dedu_Deb_Personal.Name = "Txb_Dedu_Deb_Personal"
        Me.Txb_Dedu_Deb_Personal.Size = New System.Drawing.Size(196, 22)
        Me.Txb_Dedu_Deb_Personal.TabIndex = 26
        Me.Txb_Dedu_Deb_Personal.Text = "0"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(31, 59)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(90, 13)
        Me.Label48.TabIndex = 25
        Me.Label48.Text = "DEB PERSONAL"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(277, 5)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(37, 13)
        Me.Label45.TabIndex = 24
        Me.Label45.Text = "Monto"
        '
        'txb_MontoDeducciones
        '
        Me.txb_MontoDeducciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txb_MontoDeducciones.Location = New System.Drawing.Point(438, 386)
        Me.txb_MontoDeducciones.Name = "txb_MontoDeducciones"
        Me.txb_MontoDeducciones.Size = New System.Drawing.Size(369, 20)
        Me.txb_MontoDeducciones.TabIndex = 23
        Me.txb_MontoDeducciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(401, 389)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(31, 13)
        Me.Label42.TabIndex = 22
        Me.Label42.Text = "Total"
        '
        'btn_EliminarDeduccion
        '
        Me.btn_EliminarDeduccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_EliminarDeduccion.Location = New System.Drawing.Point(410, 333)
        Me.btn_EliminarDeduccion.Name = "btn_EliminarDeduccion"
        Me.btn_EliminarDeduccion.Size = New System.Drawing.Size(75, 35)
        Me.btn_EliminarDeduccion.TabIndex = 21
        Me.btn_EliminarDeduccion.Text = "Eliminar"
        Me.btn_EliminarDeduccion.UseVisualStyleBackColor = True
        '
        'Btn_GuardarDeduccion
        '
        Me.Btn_GuardarDeduccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_GuardarDeduccion.Location = New System.Drawing.Point(488, 333)
        Me.Btn_GuardarDeduccion.Name = "Btn_GuardarDeduccion"
        Me.Btn_GuardarDeduccion.Size = New System.Drawing.Size(75, 35)
        Me.Btn_GuardarDeduccion.TabIndex = 20
        Me.Btn_GuardarDeduccion.Text = "Guardar"
        Me.Btn_GuardarDeduccion.UseVisualStyleBackColor = True
        '
        'DGV_Deducciones
        '
        Me.DGV_Deducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Deducciones.Location = New System.Drawing.Point(406, 21)
        Me.DGV_Deducciones.Name = "DGV_Deducciones"
        Me.DGV_Deducciones.Size = New System.Drawing.Size(403, 306)
        Me.DGV_Deducciones.TabIndex = 17
        '
        'Txb_Dedu_CCSS
        '
        Me.Txb_Dedu_CCSS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_CCSS.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_CCSS.ForeColor = System.Drawing.Color.Red
        Me.Txb_Dedu_CCSS.Location = New System.Drawing.Point(196, 302)
        Me.Txb_Dedu_CCSS.Name = "Txb_Dedu_CCSS"
        Me.Txb_Dedu_CCSS.Size = New System.Drawing.Size(196, 22)
        Me.Txb_Dedu_CCSS.TabIndex = 14
        Me.Txb_Dedu_CCSS.Text = "0"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(31, 303)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(35, 13)
        Me.Label40.TabIndex = 13
        Me.Label40.Text = "CCSS"
        '
        'Txb_Dedu_Adicional
        '
        Me.Txb_Dedu_Adicional.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_Adicional.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_Adicional.ForeColor = System.Drawing.Color.ForestGreen
        Me.Txb_Dedu_Adicional.Location = New System.Drawing.Point(196, 21)
        Me.Txb_Dedu_Adicional.Name = "Txb_Dedu_Adicional"
        Me.Txb_Dedu_Adicional.Size = New System.Drawing.Size(196, 23)
        Me.Txb_Dedu_Adicional.TabIndex = 12
        Me.Txb_Dedu_Adicional.Text = "0"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(31, 26)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(64, 13)
        Me.Label36.TabIndex = 11
        Me.Label36.Text = "ADICIONAL"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(160, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cedula"
        '
        'Txb_Cedula
        '
        Me.Txb_Cedula.Location = New System.Drawing.Point(224, 9)
        Me.Txb_Cedula.Name = "Txb_Cedula"
        Me.Txb_Cedula.Size = New System.Drawing.Size(100, 20)
        Me.Txb_Cedula.TabIndex = 2
        '
        'Txb_Nombre
        '
        Me.Txb_Nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Nombre.Location = New System.Drawing.Point(224, 35)
        Me.Txb_Nombre.Name = "Txb_Nombre"
        Me.Txb_Nombre.Size = New System.Drawing.Size(304, 20)
        Me.Txb_Nombre.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(160, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(160, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Telefono 1"
        '
        'Txb_Telefono1
        '
        Me.Txb_Telefono1.Location = New System.Drawing.Point(224, 63)
        Me.Txb_Telefono1.Name = "Txb_Telefono1"
        Me.Txb_Telefono1.Size = New System.Drawing.Size(100, 20)
        Me.Txb_Telefono1.TabIndex = 6
        '
        'Txb_Telefono2
        '
        Me.Txb_Telefono2.Location = New System.Drawing.Point(428, 64)
        Me.Txb_Telefono2.Name = "Txb_Telefono2"
        Me.Txb_Telefono2.Size = New System.Drawing.Size(100, 20)
        Me.Txb_Telefono2.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(359, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Telefono 2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(160, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Puesto"
        '
        'Txb_Salario
        '
        Me.Txb_Salario.Location = New System.Drawing.Point(428, 90)
        Me.Txb_Salario.Name = "Txb_Salario"
        Me.Txb_Salario.Size = New System.Drawing.Size(100, 20)
        Me.Txb_Salario.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(378, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Salario"
        '
        'DTP_FechaIngreso
        '
        Me.DTP_FechaIngreso.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_FechaIngreso.Location = New System.Drawing.Point(610, 72)
        Me.DTP_FechaIngreso.Name = "DTP_FechaIngreso"
        Me.DTP_FechaIngreso.Size = New System.Drawing.Size(203, 20)
        Me.DTP_FechaIngreso.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(534, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Fecha Ingreso"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(534, 98)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Fecha Salida"
        '
        'DTP_FechaSalida
        '
        Me.DTP_FechaSalida.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_FechaSalida.Location = New System.Drawing.Point(610, 97)
        Me.DTP_FechaSalida.Name = "DTP_FechaSalida"
        Me.DTP_FechaSalida.Size = New System.Drawing.Size(203, 20)
        Me.DTP_FechaSalida.TabIndex = 15
        '
        'Btn_Guardar
        '
        Me.Btn_Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_Guardar.Location = New System.Drawing.Point(93, 585)
        Me.Btn_Guardar.Name = "Btn_Guardar"
        Me.Btn_Guardar.Size = New System.Drawing.Size(75, 35)
        Me.Btn_Guardar.TabIndex = 19
        Me.Btn_Guardar.Text = "Guardar"
        Me.Btn_Guardar.UseVisualStyleBackColor = True
        '
        'Btn_Nuevo
        '
        Me.Btn_Nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_Nuevo.Location = New System.Drawing.Point(12, 585)
        Me.Btn_Nuevo.Name = "Btn_Nuevo"
        Me.Btn_Nuevo.Size = New System.Drawing.Size(75, 35)
        Me.Btn_Nuevo.TabIndex = 20
        Me.Btn_Nuevo.Text = "Nuevo"
        Me.Btn_Nuevo.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(427, 171)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(152, 13)
        Me.Label17.TabIndex = 28
        Me.Label17.Text = "Razon de salida / Comentarios"
        '
        'TextBox12
        '
        Me.TextBox12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox12.Location = New System.Drawing.Point(534, 198)
        Me.TextBox12.Multiline = True
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(275, 84)
        Me.TextBox12.TabIndex = 27
        '
        'TextBox13
        '
        Me.TextBox13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox13.Location = New System.Drawing.Point(534, 140)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(76, 20)
        Me.TextBox13.TabIndex = 26
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(427, 143)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(58, 13)
        Me.Label18.TabIndex = 25
        Me.Label18.Text = "Telefono 1"
        '
        'TextBox14
        '
        Me.TextBox14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox14.Location = New System.Drawing.Point(534, 107)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(275, 20)
        Me.TextBox14.TabIndex = 24
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(427, 114)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(101, 13)
        Me.Label19.TabIndex = 23
        Me.Label19.Text = "Persona Referencia"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(427, 74)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(69, 13)
        Me.Label20.TabIndex = 22
        Me.Label20.Text = "Fecha Salida"
        '
        'TextBox15
        '
        Me.TextBox15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox15.Location = New System.Drawing.Point(534, 11)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(275, 20)
        Me.TextBox15.TabIndex = 2
        '
        'DateTimePicker5
        '
        Me.DateTimePicker5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker5.Location = New System.Drawing.Point(534, 68)
        Me.DateTimePicker5.Name = "DateTimePicker5"
        Me.DateTimePicker5.Size = New System.Drawing.Size(275, 20)
        Me.DateTimePicker5.TabIndex = 21
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(427, 14)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 13)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "Empresa"
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(427, 44)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(75, 13)
        Me.Label22.TabIndex = 20
        Me.Label22.Text = "Fecha Ingreso"
        '
        'DataGridView2
        '
        Me.DataGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(6, 6)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(411, 276)
        Me.DataGridView2.TabIndex = 0
        '
        'TextBox16
        '
        Me.TextBox16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox16.Location = New System.Drawing.Point(666, 140)
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New System.Drawing.Size(143, 20)
        Me.TextBox16.TabIndex = 30
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(620, 146)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(40, 13)
        Me.Label23.TabIndex = 29
        Me.Label23.Text = "Puesto"
        '
        'DateTimePicker6
        '
        Me.DateTimePicker6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker6.Location = New System.Drawing.Point(534, 37)
        Me.DateTimePicker6.Name = "DateTimePicker6"
        Me.DateTimePicker6.Size = New System.Drawing.Size(275, 20)
        Me.DateTimePicker6.TabIndex = 19
        '
        'Btn_Informe
        '
        Me.Btn_Informe.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Informe.Location = New System.Drawing.Point(735, 589)
        Me.Btn_Informe.Name = "Btn_Informe"
        Me.Btn_Informe.Size = New System.Drawing.Size(75, 35)
        Me.Btn_Informe.TabIndex = 23
        Me.Btn_Informe.Text = "Informe"
        Me.Btn_Informe.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Txb_RutaImagen
        '
        Me.Txb_RutaImagen.Location = New System.Drawing.Point(48, 142)
        Me.Txb_RutaImagen.Name = "Txb_RutaImagen"
        Me.Txb_RutaImagen.Size = New System.Drawing.Size(106, 20)
        Me.Txb_RutaImagen.TabIndex = 26
        Me.Txb_RutaImagen.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(12, 145)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(30, 13)
        Me.Label30.TabIndex = 25
        Me.Label30.Text = "Ruta"
        Me.Label30.Visible = False
        '
        'ChkB_Activo
        '
        Me.ChkB_Activo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkB_Activo.AutoSize = True
        Me.ChkB_Activo.Location = New System.Drawing.Point(610, 123)
        Me.ChkB_Activo.Name = "ChkB_Activo"
        Me.ChkB_Activo.Size = New System.Drawing.Size(56, 17)
        Me.ChkB_Activo.TabIndex = 33
        Me.ChkB_Activo.Text = "Activo"
        Me.ChkB_Activo.UseVisualStyleBackColor = True
        '
        'Txb_Codigo
        '
        Me.Txb_Codigo.Location = New System.Drawing.Point(224, 142)
        Me.Txb_Codigo.Name = "Txb_Codigo"
        Me.Txb_Codigo.Size = New System.Drawing.Size(120, 20)
        Me.Txb_Codigo.TabIndex = 35
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(160, 145)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(61, 13)
        Me.Label35.TabIndex = 34
        Me.Label35.Text = "Cod Cliente"
        '
        'Txt_Id
        '
        Me.Txt_Id.Location = New System.Drawing.Point(583, 9)
        Me.Txt_Id.Name = "Txt_Id"
        Me.Txt_Id.Size = New System.Drawing.Size(39, 20)
        Me.Txt_Id.TabIndex = 77
        Me.Txt_Id.Visible = False
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(551, 12)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(16, 13)
        Me.Label41.TabIndex = 76
        Me.Label41.Text = "Id"
        Me.Label41.Visible = False
        '
        'Btn_Atras
        '
        Me.Btn_Atras.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Atras.BackgroundImage = CType(resources.GetObject("Btn_Atras.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Atras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Atras.Location = New System.Drawing.Point(654, 4)
        Me.Btn_Atras.Name = "Btn_Atras"
        Me.Btn_Atras.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Atras.TabIndex = 75
        Me.Btn_Atras.UseVisualStyleBackColor = False
        '
        'Btn_Adelante
        '
        Me.Btn_Adelante.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Adelante.BackgroundImage = CType(resources.GetObject("Btn_Adelante.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Adelante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Adelante.Location = New System.Drawing.Point(735, 3)
        Me.Btn_Adelante.Name = "Btn_Adelante"
        Me.Btn_Adelante.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Adelante.TabIndex = 74
        Me.Btn_Adelante.UseVisualStyleBackColor = False
        '
        'Button9
        '
        'Me.Button9.Image = Global.SincroCliente.My.Resources.Resources.clip2
        Me.Button9.Location = New System.Drawing.Point(123, 109)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(31, 26)
        Me.Button9.TabIndex = 24
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button3
        '
        'Me.Button3.Image = Global.SincroCliente.My.Resources.Resources.lupa3
        Me.Button3.Location = New System.Drawing.Point(328, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(34, 26)
        Me.Button3.TabIndex = 22
        Me.Button3.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        'Me.PictureBox1.Image = Global.SincroCliente.My.Resources.Resources.SinFoto2
        Me.PictureBox1.Location = New System.Drawing.Point(4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 130)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'Txtb_CodRuta
        '
        Me.Txtb_CodRuta.Enabled = False
        Me.Txtb_CodRuta.Location = New System.Drawing.Point(426, 9)
        Me.Txtb_CodRuta.Name = "Txtb_CodRuta"
        Me.Txtb_CodRuta.Size = New System.Drawing.Size(100, 20)
        Me.Txtb_CodRuta.TabIndex = 79
        Me.Txtb_CodRuta.Text = "0"
        '
        'lbl_ruta
        '
        Me.lbl_ruta.AutoSize = True
        Me.lbl_ruta.Location = New System.Drawing.Point(368, 13)
        Me.lbl_ruta.Name = "lbl_ruta"
        Me.lbl_ruta.Size = New System.Drawing.Size(52, 13)
        Me.lbl_ruta.TabIndex = 78
        Me.lbl_ruta.Text = "Cod Ruta"
        '
        'btn_NuevoPuesto
        '
        Me.btn_NuevoPuesto.BackColor = System.Drawing.Color.Transparent
        ' Me.btn_NuevoPuesto.Image = Global.SincroCliente.My.Resources.Resources.mas1
        Me.btn_NuevoPuesto.Location = New System.Drawing.Point(326, 89)
        Me.btn_NuevoPuesto.Name = "btn_NuevoPuesto"
        Me.btn_NuevoPuesto.Size = New System.Drawing.Size(28, 24)
        Me.btn_NuevoPuesto.TabIndex = 80
        Me.btn_NuevoPuesto.UseVisualStyleBackColor = False
        Me.btn_NuevoPuesto.Visible = False
        '
        'CBox_Puesto
        '
        Me.CBox_Puesto.FormattingEnabled = True
        Me.CBox_Puesto.Items.AddRange(New Object() {"AGENTE", "CHOFER", "AYUDANTE", "CONTADORA", "PROVEEDURIA", "SISTEMAS", "FACTURADOR", "RECEPCIONISTA", "BODEGUERO", "JEFE BODEGA", "GERENTE", "JEFE VENTAS", "ASISTENTE", "TELEMERCADEO", "MERCADERISTA", "ADMINISTRADOR", "", ""})
        Me.CBox_Puesto.Location = New System.Drawing.Point(224, 89)
        Me.CBox_Puesto.Name = "CBox_Puesto"
        Me.CBox_Puesto.Size = New System.Drawing.Size(100, 21)
        Me.CBox_Puesto.TabIndex = 32
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(160, 119)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(38, 13)
        Me.Label65.TabIndex = 20
        Me.Label65.Text = "Correo"
        '
        'txtb_Correo
        '
        Me.txtb_Correo.Location = New System.Drawing.Point(224, 116)
        Me.txtb_Correo.Name = "txtb_Correo"
        Me.txtb_Correo.Size = New System.Drawing.Size(302, 20)
        Me.txtb_Correo.TabIndex = 24
        '
        'Txb_CodigoCobroXFaltante
        '
        Me.Txb_CodigoCobroXFaltante.Location = New System.Drawing.Point(497, 142)
        Me.Txb_CodigoCobroXFaltante.Name = "Txb_CodigoCobroXFaltante"
        Me.Txb_CodigoCobroXFaltante.Size = New System.Drawing.Size(203, 20)
        Me.Txb_CodigoCobroXFaltante.TabIndex = 82
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(350, 145)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(141, 13)
        Me.Label58.TabIndex = 81
        Me.Label58.Text = "Cod Cliente CobroXFantante"
        '
        'Empleados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 628)
        Me.Controls.Add(Me.Txb_CodigoCobroXFaltante)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.CBox_Puesto)
        Me.Controls.Add(Me.btn_NuevoPuesto)
        Me.Controls.Add(Me.Txtb_CodRuta)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.lbl_ruta)
        Me.Controls.Add(Me.txtb_Correo)
        Me.Controls.Add(Me.Txt_Id)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Btn_Atras)
        Me.Controls.Add(Me.Btn_Adelante)
        Me.Controls.Add(Me.Txb_Codigo)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.ChkB_Activo)
        Me.Controls.Add(Me.Txb_RutaImagen)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Btn_Informe)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Btn_Nuevo)
        Me.Controls.Add(Me.Btn_Guardar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.DTP_FechaSalida)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DTP_FechaIngreso)
        Me.Controls.Add(Me.Txb_Salario)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Txb_Telefono2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Txb_Telefono1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txb_Nombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txb_Cedula)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Empleados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Empleados"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DTGV_Experiencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DTGV_Educacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV_VacacionesConsumidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.DGV_Facturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.DGV_Deducciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txb_Cedula As System.Windows.Forms.TextBox
    Friend WithEvents Txb_Nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txb_Telefono1 As System.Windows.Forms.TextBox
    Friend WithEvents Txb_Telefono2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txb_Salario As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DTP_FechaIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTGV_Experiencia As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DTP_FechaSalida As System.Windows.Forms.DateTimePicker
    Friend WithEvents Txb_Telefono As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Txb_Persona As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txb_Empresa As System.Windows.Forms.TextBox
    Friend WithEvents DTP_ExFechaSalida As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents DTP_ExFechaIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Txb_ExPuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Txb_Comentario As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents Btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents DTP_EFechaSalida As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents DTP_EFechaIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Txb_Institucion As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents DTGV_Educacion As System.Windows.Forms.DataGridView
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker5 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox16 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker6 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CkBx_Encurso As System.Windows.Forms.CheckBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents CBox_Grado As System.Windows.Forms.ComboBox
    Friend WithEvents Txb_Titulo As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Btn_EdNuevo As System.Windows.Forms.Button
    Friend WithEvents Btn_EdGuarda As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Btn_ExNuevo As System.Windows.Forms.Button
    Friend WithEvents Btn_ExEliminar As System.Windows.Forms.Button
    Friend WithEvents Btn_Informe As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents txtb_Anos As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Txb_RutaImagen As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Btn_ExGuardar As System.Windows.Forms.Button
    Friend WithEvents ChkB_Activo As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_EdEliminar As System.Windows.Forms.Button
    Friend WithEvents DGV_VacacionesConsumidas As System.Windows.Forms.DataGridView
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtb_Vacaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtb_Dias As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtb_Meses As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_GuardaVacaciones As System.Windows.Forms.Button
    Friend WithEvents Txb_VCDias As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents DTP_VCFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_VCFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents DGV_Facturas As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents Txb_Codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Txb_Dedu_CCSS As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Txb_Dedu_Adicional As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents btn_EliminarDeduccion As System.Windows.Forms.Button
    Friend WithEvents Btn_GuardarDeduccion As System.Windows.Forms.Button
    Friend WithEvents DGV_Deducciones As System.Windows.Forms.DataGridView
    Friend WithEvents txb_MontoDeducciones As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtb_VCTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents txtb_comentario As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txtb_Pendientes As System.Windows.Forms.TextBox
    Friend WithEvents btn_DCEliminar As System.Windows.Forms.Button
    Friend WithEvents Txb_Dedu_Faltante As System.Windows.Forms.TextBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Txb_Dedu_Facturas As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Txb_Dedu_FaltaLiq As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Txb_Dedu_Embargo As System.Windows.Forms.TextBox
    Friend WithEvents Txb_Dedu_Celular As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Txb_Dedu_Ducc_Cuota As System.Windows.Forms.TextBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Txb_Dedu_Deb_Personal As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Txb_Dedu_Otro As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Txb_Dedu_Prestamo As System.Windows.Forms.TextBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Btn_Atras As System.Windows.Forms.Button
    Friend WithEvents Btn_Adelante As System.Windows.Forms.Button
    Friend WithEvents Txt_Id As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Txtb_CodRuta As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ruta As System.Windows.Forms.Label
    Friend WithEvents btn_NuevoPuesto As System.Windows.Forms.Button
    Friend WithEvents CBox_Puesto As System.Windows.Forms.ComboBox
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents txtb_Correo As System.Windows.Forms.TextBox
    Friend WithEvents Txb_CodigoCobroXFaltante As System.Windows.Forms.TextBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
End Class
