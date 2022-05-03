<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Planilla
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Planilla))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DTP_FechaSalida = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DTP_FechaIngreso = New System.Windows.Forms.DateTimePicker()
        Me.Txb_id_Planilla = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_CedJuridica = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_Nombre = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtb_TotalPlanilla = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtb_PorcCCSS = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtb_Aumento = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Btn_GuardaPlanilla = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btn_ImprimeRepEmpleado = New System.Windows.Forms.Button()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Txb_SalarioQuincenal = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txb_RutaImagen = New System.Windows.Forms.TextBox()
        Me.Txb_CedulaEmpleado = New System.Windows.Forms.TextBox()
        Me.Btn_GuardarDeduccion = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Txb_Salario = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Txb_CodigoEmpleado = New System.Windows.Forms.TextBox()
        Me.Txb_Puesto = New System.Windows.Forms.TextBox()
        Me.txtb_CodigoCobroXFaltante = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Txt_Id = New System.Windows.Forms.TextBox()
        Me.Txtb_CodRuta = New System.Windows.Forms.TextBox()
        Me.btn_GoEmpleado = New System.Windows.Forms.Button()
        Me.btn_EmplAtras = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Btn_EmplAdelante = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Lbl_Salario = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Txb_Dedu_Adicional = New System.Windows.Forms.TextBox()
        Me.Txb_Dedu_CCSS = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Txb_Dedu_Otro = New System.Windows.Forms.TextBox()
        Me.Txb_Dedu_Deb_Personal = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Txb_Dedu_Prestamo = New System.Windows.Forms.TextBox()
        Me.Txb_Dedu_Ducc_Cuota = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Txb_Dedu_Faltante = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Txb_Dedu_Celular = New System.Windows.Forms.TextBox()
        Me.Txb_Dedu_Facturas = New System.Windows.Forms.TextBox()
        Me.Txb_Dedu_Embargo = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Txb_Dedu_FaltaLiq = New System.Windows.Forms.TextBox()
        Me.txtb_NombreEmpleado = New System.Windows.Forms.TextBox()
        Me.DTGV_Planilla = New System.Windows.Forms.DataGridView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Btn_Atras = New System.Windows.Forms.Button()
        Me.Btn_Adelante = New System.Windows.Forms.Button()
        Me.btn_NuevaPlanilla = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DTGV_Planilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(495, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Hasta"
        '
        'DTP_FechaSalida
        '
        Me.DTP_FechaSalida.Location = New System.Drawing.Point(536, 40)
        Me.DTP_FechaSalida.Name = "DTP_FechaSalida"
        Me.DTP_FechaSalida.Size = New System.Drawing.Size(203, 20)
        Me.DTP_FechaSalida.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(212, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Desde"
        '
        'DTP_FechaIngreso
        '
        Me.DTP_FechaIngreso.Location = New System.Drawing.Point(280, 40)
        Me.DTP_FechaIngreso.Name = "DTP_FechaIngreso"
        Me.DTP_FechaIngreso.Size = New System.Drawing.Size(204, 20)
        Me.DTP_FechaIngreso.TabIndex = 17
        '
        'Txb_id_Planilla
        '
        Me.Txb_id_Planilla.Location = New System.Drawing.Point(76, 10)
        Me.Txb_id_Planilla.Name = "Txb_id_Planilla"
        Me.Txb_id_Planilla.Size = New System.Drawing.Size(89, 20)
        Me.Txb_id_Planilla.TabIndex = 79
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "Consecutivo"
        '
        'Txt_CedJuridica
        '
        Me.Txt_CedJuridica.Location = New System.Drawing.Point(280, 12)
        Me.Txt_CedJuridica.Name = "Txt_CedJuridica"
        Me.Txt_CedJuridica.Size = New System.Drawing.Size(204, 20)
        Me.Txt_CedJuridica.TabIndex = 82
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(212, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "Ced Juridica"
        '
        'Txt_Nombre
        '
        Me.Txt_Nombre.Location = New System.Drawing.Point(535, 10)
        Me.Txt_Nombre.Name = "Txt_Nombre"
        Me.Txt_Nombre.Size = New System.Drawing.Size(204, 20)
        Me.Txt_Nombre.TabIndex = 84
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(487, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "Empresa"
        '
        'txtb_TotalPlanilla
        '
        Me.txtb_TotalPlanilla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_TotalPlanilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalPlanilla.Location = New System.Drawing.Point(958, 569)
        Me.txtb_TotalPlanilla.Name = "txtb_TotalPlanilla"
        Me.txtb_TotalPlanilla.Size = New System.Drawing.Size(259, 32)
        Me.txtb_TotalPlanilla.TabIndex = 89
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(910, 581)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "TOTAL"
        '
        'txtb_PorcCCSS
        '
        Me.txtb_PorcCCSS.Location = New System.Drawing.Point(815, 44)
        Me.txtb_PorcCCSS.Name = "txtb_PorcCCSS"
        Me.txtb_PorcCCSS.Size = New System.Drawing.Size(45, 20)
        Me.txtb_PorcCCSS.TabIndex = 91
        Me.txtb_PorcCCSS.Text = "10.51"
        Me.txtb_PorcCCSS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(754, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 90
        Me.Label6.Text = "% CCSS"
        '
        'txtb_Aumento
        '
        Me.txtb_Aumento.Location = New System.Drawing.Point(815, 13)
        Me.txtb_Aumento.Name = "txtb_Aumento"
        Me.txtb_Aumento.Size = New System.Drawing.Size(45, 20)
        Me.txtb_Aumento.TabIndex = 93
        Me.txtb_Aumento.Text = "0"
        Me.txtb_Aumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(754, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "% Aumento"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Red
        Me.Button1.Location = New System.Drawing.Point(866, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 27)
        Me.Button1.TabIndex = 94
        Me.Button1.Text = "Aplicar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Btn_GuardaPlanilla
        '
        Me.Btn_GuardaPlanilla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_GuardaPlanilla.Location = New System.Drawing.Point(139, 567)
        Me.Btn_GuardaPlanilla.Name = "Btn_GuardaPlanilla"
        Me.Btn_GuardaPlanilla.Size = New System.Drawing.Size(94, 36)
        Me.Btn_GuardaPlanilla.TabIndex = 95
        Me.Btn_GuardaPlanilla.Text = "GUARDAR"
        Me.Btn_GuardaPlanilla.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(251, 567)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 36)
        Me.Button2.TabIndex = 96
        Me.Button2.Text = "IMPRIMIR"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button4.Location = New System.Drawing.Point(347, 569)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 36)
        Me.Button4.TabIndex = 97
        Me.Button4.Text = "ENVIAR"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(7, 70)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1219, 491)
        Me.TabControl1.TabIndex = 98
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.SplitContainer1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1211, 465)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Planilla"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_ImprimeRepEmpleado)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label41)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Txb_SalarioQuincenal)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label17)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Txb_RutaImagen)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Txb_CedulaEmpleado)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Btn_GuardarDeduccion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label30)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label13)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Txb_Salario)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label19)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Txb_CodigoEmpleado)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Txb_Puesto)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtb_CodigoCobroXFaltante)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label12)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label16)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Txt_Id)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Txtb_CodRuta)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_GoEmpleado)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_EmplAtras)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PictureBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Btn_EmplAdelante)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtb_NombreEmpleado)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DTGV_Planilla)
        Me.SplitContainer1.Size = New System.Drawing.Size(1205, 459)
        Me.SplitContainer1.SplitterDistance = 599
        Me.SplitContainer1.TabIndex = 92
        '
        'btn_ImprimeRepEmpleado
        '
        Me.btn_ImprimeRepEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.btn_ImprimeRepEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ImprimeRepEmpleado.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_ImprimeRepEmpleado.Location = New System.Drawing.Point(15, 361)
        Me.btn_ImprimeRepEmpleado.Name = "btn_ImprimeRepEmpleado"
        Me.btn_ImprimeRepEmpleado.Size = New System.Drawing.Size(114, 48)
        Me.btn_ImprimeRepEmpleado.TabIndex = 90
        Me.btn_ImprimeRepEmpleado.Text = "Imprimir"
        Me.btn_ImprimeRepEmpleado.UseVisualStyleBackColor = False
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(122, 21)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(16, 13)
        Me.Label41.TabIndex = 80
        Me.Label41.Text = "Id"
        Me.Label41.Visible = False
        '
        'Txb_SalarioQuincenal
        '
        Me.Txb_SalarioQuincenal.Location = New System.Drawing.Point(208, 286)
        Me.Txb_SalarioQuincenal.Name = "Txb_SalarioQuincenal"
        Me.Txb_SalarioQuincenal.ReadOnly = True
        Me.Txb_SalarioQuincenal.Size = New System.Drawing.Size(100, 20)
        Me.Txb_SalarioQuincenal.TabIndex = 89
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(234, 270)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 13)
        Me.Label17.TabIndex = 88
        Me.Label17.Text = "Quicenal"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 186)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 66
        Me.Label10.Text = "Cedula"
        '
        'Txb_RutaImagen
        '
        Me.Txb_RutaImagen.Location = New System.Drawing.Point(14, 327)
        Me.Txb_RutaImagen.Name = "Txb_RutaImagen"
        Me.Txb_RutaImagen.ReadOnly = True
        Me.Txb_RutaImagen.Size = New System.Drawing.Size(63, 20)
        Me.Txb_RutaImagen.TabIndex = 87
        Me.Txb_RutaImagen.Visible = False
        '
        'Txb_CedulaEmpleado
        '
        Me.Txb_CedulaEmpleado.Location = New System.Drawing.Point(15, 202)
        Me.Txb_CedulaEmpleado.Name = "Txb_CedulaEmpleado"
        Me.Txb_CedulaEmpleado.ReadOnly = True
        Me.Txb_CedulaEmpleado.Size = New System.Drawing.Size(100, 20)
        Me.Txb_CedulaEmpleado.TabIndex = 67
        '
        'Btn_GuardarDeduccion
        '
        Me.Btn_GuardarDeduccion.BackColor = System.Drawing.Color.RoyalBlue
        Me.Btn_GuardarDeduccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_GuardarDeduccion.ForeColor = System.Drawing.SystemColors.Control
        Me.Btn_GuardarDeduccion.Location = New System.Drawing.Point(189, 361)
        Me.Btn_GuardarDeduccion.Name = "Btn_GuardarDeduccion"
        Me.Btn_GuardarDeduccion.Size = New System.Drawing.Size(114, 48)
        Me.Btn_GuardarDeduccion.TabIndex = 45
        Me.Btn_GuardarDeduccion.Text = "Guardar"
        Me.Btn_GuardarDeduccion.UseVisualStyleBackColor = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(26, 309)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(30, 13)
        Me.Label30.TabIndex = 86
        Me.Label30.Text = "Ruta"
        Me.Label30.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(253, 309)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 13)
        Me.Label13.TabIndex = 66
        Me.Label13.Text = "Cod Cliente"
        Me.Label13.Visible = False
        '
        'Txb_Salario
        '
        Me.Txb_Salario.Location = New System.Drawing.Point(15, 285)
        Me.Txb_Salario.Name = "Txb_Salario"
        Me.Txb_Salario.ReadOnly = True
        Me.Txb_Salario.Size = New System.Drawing.Size(100, 20)
        Me.Txb_Salario.TabIndex = 85
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(83, 308)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(107, 13)
        Me.Label19.TabIndex = 66
        Me.Label19.Text = "Cod Clint CbrXFaltnte"
        Me.Label19.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(41, 270)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 13)
        Me.Label11.TabIndex = 84
        Me.Label11.Text = "Mensual"
        '
        'Txb_CodigoEmpleado
        '
        Me.Txb_CodigoEmpleado.Location = New System.Drawing.Point(266, 327)
        Me.Txb_CodigoEmpleado.Name = "Txb_CodigoEmpleado"
        Me.Txb_CodigoEmpleado.ReadOnly = True
        Me.Txb_CodigoEmpleado.Size = New System.Drawing.Size(24, 20)
        Me.Txb_CodigoEmpleado.TabIndex = 67
        Me.Txb_CodigoEmpleado.Visible = False
        '
        'Txb_Puesto
        '
        Me.Txb_Puesto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Puesto.Location = New System.Drawing.Point(203, 202)
        Me.Txb_Puesto.Name = "Txb_Puesto"
        Me.Txb_Puesto.ReadOnly = True
        Me.Txb_Puesto.Size = New System.Drawing.Size(100, 20)
        Me.Txb_Puesto.TabIndex = 83
        '
        'txtb_CodigoCobroXFaltante
        '
        Me.txtb_CodigoCobroXFaltante.Location = New System.Drawing.Point(134, 329)
        Me.txtb_CodigoCobroXFaltante.Name = "txtb_CodigoCobroXFaltante"
        Me.txtb_CodigoCobroXFaltante.ReadOnly = True
        Me.txtb_CodigoCobroXFaltante.Size = New System.Drawing.Size(17, 20)
        Me.txtb_CodigoCobroXFaltante.TabIndex = 67
        Me.txtb_CodigoCobroXFaltante.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(205, 186)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 82
        Me.Label12.Text = "Puesto"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(195, 309)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 66
        Me.Label16.Text = "Cod Ruta"
        Me.Label16.Visible = False
        '
        'Txt_Id
        '
        Me.Txt_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Id.Location = New System.Drawing.Point(144, 12)
        Me.Txt_Id.Name = "Txt_Id"
        Me.Txt_Id.ReadOnly = True
        Me.Txt_Id.Size = New System.Drawing.Size(38, 26)
        Me.Txt_Id.TabIndex = 81
        Me.Txt_Id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txtb_CodRuta
        '
        Me.Txtb_CodRuta.Location = New System.Drawing.Point(208, 327)
        Me.Txtb_CodRuta.Name = "Txtb_CodRuta"
        Me.Txtb_CodRuta.ReadOnly = True
        Me.Txtb_CodRuta.Size = New System.Drawing.Size(22, 20)
        Me.Txtb_CodRuta.TabIndex = 67
        Me.Txtb_CodRuta.Visible = False
        '
        'btn_GoEmpleado
        '
        Me.btn_GoEmpleado.Image = Global.SincroCliente.My.Resources.Resources.ir
        Me.btn_GoEmpleado.Location = New System.Drawing.Point(119, 198)
        Me.btn_GoEmpleado.Name = "btn_GoEmpleado"
        Me.btn_GoEmpleado.Size = New System.Drawing.Size(34, 26)
        Me.btn_GoEmpleado.TabIndex = 68
        Me.btn_GoEmpleado.UseVisualStyleBackColor = True
        '
        'btn_EmplAtras
        '
        Me.btn_EmplAtras.BackColor = System.Drawing.Color.Transparent
        Me.btn_EmplAtras.BackgroundImage = CType(resources.GetObject("btn_EmplAtras.BackgroundImage"), System.Drawing.Image)
        Me.btn_EmplAtras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_EmplAtras.Location = New System.Drawing.Point(11, 82)
        Me.btn_EmplAtras.Name = "btn_EmplAtras"
        Me.btn_EmplAtras.Size = New System.Drawing.Size(75, 40)
        Me.btn_EmplAtras.TabIndex = 79
        Me.btn_EmplAtras.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(87, 44)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 130)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 69
        Me.PictureBox1.TabStop = False
        '
        'Btn_EmplAdelante
        '
        Me.Btn_EmplAdelante.BackColor = System.Drawing.Color.Transparent
        Me.Btn_EmplAdelante.BackgroundImage = CType(resources.GetObject("Btn_EmplAdelante.BackgroundImage"), System.Drawing.Image)
        Me.Btn_EmplAdelante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_EmplAdelante.Location = New System.Drawing.Point(239, 82)
        Me.Btn_EmplAdelante.Name = "Btn_EmplAdelante"
        Me.Btn_EmplAdelante.Size = New System.Drawing.Size(75, 40)
        Me.Btn_EmplAdelante.TabIndex = 78
        Me.Btn_EmplAdelante.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 229)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "Nombre"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.Lbl_Salario)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label36)
        Me.GroupBox1.Controls.Add(Me.Txb_Dedu_Adicional)
        Me.GroupBox1.Controls.Add(Me.Txb_Dedu_CCSS)
        Me.GroupBox1.Controls.Add(Me.Label45)
        Me.GroupBox1.Controls.Add(Me.Label48)
        Me.GroupBox1.Controls.Add(Me.Txb_Dedu_Otro)
        Me.GroupBox1.Controls.Add(Me.Txb_Dedu_Deb_Personal)
        Me.GroupBox1.Controls.Add(Me.Label49)
        Me.GroupBox1.Controls.Add(Me.Txb_Dedu_Prestamo)
        Me.GroupBox1.Controls.Add(Me.Txb_Dedu_Ducc_Cuota)
        Me.GroupBox1.Controls.Add(Me.Label55)
        Me.GroupBox1.Controls.Add(Me.Label50)
        Me.GroupBox1.Controls.Add(Me.Txb_Dedu_Faltante)
        Me.GroupBox1.Controls.Add(Me.Label51)
        Me.GroupBox1.Controls.Add(Me.Label54)
        Me.GroupBox1.Controls.Add(Me.Txb_Dedu_Celular)
        Me.GroupBox1.Controls.Add(Me.Txb_Dedu_Facturas)
        Me.GroupBox1.Controls.Add(Me.Txb_Dedu_Embargo)
        Me.GroupBox1.Controls.Add(Me.Label53)
        Me.GroupBox1.Controls.Add(Me.Label52)
        Me.GroupBox1.Controls.Add(Me.Txb_Dedu_FaltaLiq)
        Me.GroupBox1.Location = New System.Drawing.Point(320, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(270, 419)
        Me.GroupBox1.TabIndex = 72
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Deducciones"
        '
        'Lbl_Salario
        '
        Me.Lbl_Salario.AutoSize = True
        Me.Lbl_Salario.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Salario.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Salario.Location = New System.Drawing.Point(7, 367)
        Me.Lbl_Salario.Name = "Lbl_Salario"
        Me.Lbl_Salario.Size = New System.Drawing.Size(138, 24)
        Me.Lbl_Salario.TabIndex = 68
        Me.Lbl_Salario.Text = "00,000,000.00"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 342)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 67
        Me.Label14.Text = "OTROS"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(10, 306)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 13)
        Me.Label15.TabIndex = 66
        Me.Label15.Text = "CCSS"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(10, 35)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(64, 13)
        Me.Label36.TabIndex = 41
        Me.Label36.Text = "ADICIONAL"
        '
        'Txb_Dedu_Adicional
        '
        Me.Txb_Dedu_Adicional.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_Adicional.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_Adicional.ForeColor = System.Drawing.Color.ForestGreen
        Me.Txb_Dedu_Adicional.Location = New System.Drawing.Point(148, 30)
        Me.Txb_Dedu_Adicional.Name = "Txb_Dedu_Adicional"
        Me.Txb_Dedu_Adicional.Size = New System.Drawing.Size(111, 23)
        Me.Txb_Dedu_Adicional.TabIndex = 42
        Me.Txb_Dedu_Adicional.Text = "0"
        '
        'Txb_Dedu_CCSS
        '
        Me.Txb_Dedu_CCSS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_CCSS.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_CCSS.ForeColor = System.Drawing.Color.Red
        Me.Txb_Dedu_CCSS.Location = New System.Drawing.Point(148, 305)
        Me.Txb_Dedu_CCSS.Name = "Txb_Dedu_CCSS"
        Me.Txb_Dedu_CCSS.Size = New System.Drawing.Size(111, 22)
        Me.Txb_Dedu_CCSS.TabIndex = 44
        Me.Txb_Dedu_CCSS.Text = "0"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(190, 14)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(37, 13)
        Me.Label45.TabIndex = 47
        Me.Label45.Text = "Monto"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(10, 71)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(90, 13)
        Me.Label48.TabIndex = 48
        Me.Label48.Text = "DEB PERSONAL"
        '
        'Txb_Dedu_Otro
        '
        Me.Txb_Dedu_Otro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_Otro.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_Otro.ForeColor = System.Drawing.Color.Red
        Me.Txb_Dedu_Otro.Location = New System.Drawing.Point(148, 337)
        Me.Txb_Dedu_Otro.Name = "Txb_Dedu_Otro"
        Me.Txb_Dedu_Otro.Size = New System.Drawing.Size(111, 22)
        Me.Txb_Dedu_Otro.TabIndex = 65
        Me.Txb_Dedu_Otro.Text = "0"
        '
        'Txb_Dedu_Deb_Personal
        '
        Me.Txb_Dedu_Deb_Personal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_Deb_Personal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_Deb_Personal.ForeColor = System.Drawing.Color.Red
        Me.Txb_Dedu_Deb_Personal.Location = New System.Drawing.Point(148, 64)
        Me.Txb_Dedu_Deb_Personal.Name = "Txb_Dedu_Deb_Personal"
        Me.Txb_Dedu_Deb_Personal.Size = New System.Drawing.Size(111, 22)
        Me.Txb_Dedu_Deb_Personal.TabIndex = 49
        Me.Txb_Dedu_Deb_Personal.Text = "0"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(9, 100)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(94, 13)
        Me.Label49.TabIndex = 50
        Me.Label49.Text = "DUCC CUOTA BP"
        '
        'Txb_Dedu_Prestamo
        '
        Me.Txb_Dedu_Prestamo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_Prestamo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_Prestamo.ForeColor = System.Drawing.Color.Red
        Me.Txb_Dedu_Prestamo.Location = New System.Drawing.Point(147, 187)
        Me.Txb_Dedu_Prestamo.Name = "Txb_Dedu_Prestamo"
        Me.Txb_Dedu_Prestamo.Size = New System.Drawing.Size(111, 22)
        Me.Txb_Dedu_Prestamo.TabIndex = 63
        Me.Txb_Dedu_Prestamo.Text = "0"
        '
        'Txb_Dedu_Ducc_Cuota
        '
        Me.Txb_Dedu_Ducc_Cuota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_Ducc_Cuota.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_Ducc_Cuota.ForeColor = System.Drawing.Color.Red
        Me.Txb_Dedu_Ducc_Cuota.Location = New System.Drawing.Point(148, 95)
        Me.Txb_Dedu_Ducc_Cuota.Name = "Txb_Dedu_Ducc_Cuota"
        Me.Txb_Dedu_Ducc_Cuota.Size = New System.Drawing.Size(111, 22)
        Me.Txb_Dedu_Ducc_Cuota.TabIndex = 51
        Me.Txb_Dedu_Ducc_Cuota.Text = "0"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(9, 192)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(115, 13)
        Me.Label55.TabIndex = 62
        Me.Label55.Text = "COBROS PRESTAMO"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(9, 132)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(134, 13)
        Me.Label50.TabIndex = 52
        Me.Label50.Text = "DEDUCION DE CELULAR"
        '
        'Txb_Dedu_Faltante
        '
        Me.Txb_Dedu_Faltante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_Faltante.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_Faltante.ForeColor = System.Drawing.Color.Red
        Me.Txb_Dedu_Faltante.Location = New System.Drawing.Point(148, 277)
        Me.Txb_Dedu_Faltante.Name = "Txb_Dedu_Faltante"
        Me.Txb_Dedu_Faltante.Size = New System.Drawing.Size(111, 22)
        Me.Txb_Dedu_Faltante.TabIndex = 61
        Me.Txb_Dedu_Faltante.Text = "0"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(9, 164)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(61, 13)
        Me.Label51.TabIndex = 53
        Me.Label51.Text = "EMBARGO"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(9, 281)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(137, 13)
        Me.Label54.TabIndex = 60
        Me.Label54.Text = "COBROS X FALTANTE"
        '
        'Txb_Dedu_Celular
        '
        Me.Txb_Dedu_Celular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_Celular.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_Celular.ForeColor = System.Drawing.Color.Red
        Me.Txb_Dedu_Celular.Location = New System.Drawing.Point(148, 127)
        Me.Txb_Dedu_Celular.Name = "Txb_Dedu_Celular"
        Me.Txb_Dedu_Celular.Size = New System.Drawing.Size(111, 22)
        Me.Txb_Dedu_Celular.TabIndex = 55
        Me.Txb_Dedu_Celular.Text = "0"
        '
        'Txb_Dedu_Facturas
        '
        Me.Txb_Dedu_Facturas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_Facturas.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_Facturas.ForeColor = System.Drawing.Color.Red
        Me.Txb_Dedu_Facturas.Location = New System.Drawing.Point(148, 246)
        Me.Txb_Dedu_Facturas.Name = "Txb_Dedu_Facturas"
        Me.Txb_Dedu_Facturas.Size = New System.Drawing.Size(111, 22)
        Me.Txb_Dedu_Facturas.TabIndex = 59
        Me.Txb_Dedu_Facturas.Text = "0"
        '
        'Txb_Dedu_Embargo
        '
        Me.Txb_Dedu_Embargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_Embargo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_Embargo.ForeColor = System.Drawing.Color.Red
        Me.Txb_Dedu_Embargo.Location = New System.Drawing.Point(148, 159)
        Me.Txb_Dedu_Embargo.Name = "Txb_Dedu_Embargo"
        Me.Txb_Dedu_Embargo.Size = New System.Drawing.Size(111, 22)
        Me.Txb_Dedu_Embargo.TabIndex = 54
        Me.Txb_Dedu_Embargo.Text = "0"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(9, 250)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(72, 13)
        Me.Label53.TabIndex = 58
        Me.Label53.Text = "FACTURAS"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(9, 220)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(102, 13)
        Me.Label52.TabIndex = 56
        Me.Label52.Text = "FALTANTES LIQ"
        '
        'Txb_Dedu_FaltaLiq
        '
        Me.Txb_Dedu_FaltaLiq.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txb_Dedu_FaltaLiq.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Dedu_FaltaLiq.ForeColor = System.Drawing.Color.Red
        Me.Txb_Dedu_FaltaLiq.Location = New System.Drawing.Point(148, 215)
        Me.Txb_Dedu_FaltaLiq.Name = "Txb_Dedu_FaltaLiq"
        Me.Txb_Dedu_FaltaLiq.Size = New System.Drawing.Size(111, 22)
        Me.Txb_Dedu_FaltaLiq.TabIndex = 57
        Me.Txb_Dedu_FaltaLiq.Text = "0"
        '
        'txtb_NombreEmpleado
        '
        Me.txtb_NombreEmpleado.Location = New System.Drawing.Point(15, 245)
        Me.txtb_NombreEmpleado.Name = "txtb_NombreEmpleado"
        Me.txtb_NombreEmpleado.ReadOnly = True
        Me.txtb_NombreEmpleado.Size = New System.Drawing.Size(293, 20)
        Me.txtb_NombreEmpleado.TabIndex = 71
        '
        'DTGV_Planilla
        '
        Me.DTGV_Planilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DTGV_Planilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DTGV_Planilla.Location = New System.Drawing.Point(0, 0)
        Me.DTGV_Planilla.Name = "DTGV_Planilla"
        Me.DTGV_Planilla.Size = New System.Drawing.Size(602, 459)
        Me.DTGV_Planilla.TabIndex = 91
        '
        'Button3
        '
        Me.Button3.Image = Global.SincroCliente.My.Resources.Resources.ir
        Me.Button3.Location = New System.Drawing.Point(170, 6)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(34, 26)
        Me.Button3.TabIndex = 80
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Btn_Atras
        '
        Me.Btn_Atras.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Atras.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Atras.BackgroundImage = CType(resources.GetObject("Btn_Atras.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Atras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Atras.Location = New System.Drawing.Point(1070, 5)
        Me.Btn_Atras.Name = "Btn_Atras"
        Me.Btn_Atras.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Atras.TabIndex = 77
        Me.Btn_Atras.UseVisualStyleBackColor = False
        '
        'Btn_Adelante
        '
        Me.Btn_Adelante.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Adelante.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Adelante.BackgroundImage = CType(resources.GetObject("Btn_Adelante.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Adelante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Adelante.Location = New System.Drawing.Point(1151, 4)
        Me.Btn_Adelante.Name = "Btn_Adelante"
        Me.Btn_Adelante.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Adelante.TabIndex = 76
        Me.Btn_Adelante.UseVisualStyleBackColor = False
        '
        'btn_NuevaPlanilla
        '
        Me.btn_NuevaPlanilla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_NuevaPlanilla.Location = New System.Drawing.Point(14, 567)
        Me.btn_NuevaPlanilla.Name = "btn_NuevaPlanilla"
        Me.btn_NuevaPlanilla.Size = New System.Drawing.Size(75, 36)
        Me.btn_NuevaPlanilla.TabIndex = 99
        Me.btn_NuevaPlanilla.Text = "NUEVA"
        Me.btn_NuevaPlanilla.UseVisualStyleBackColor = True
        '
        'Planilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1229, 610)
        Me.Controls.Add(Me.btn_NuevaPlanilla)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Btn_GuardaPlanilla)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtb_Aumento)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtb_PorcCCSS)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtb_TotalPlanilla)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Txt_Nombre)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txt_CedJuridica)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Txb_id_Planilla)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_Atras)
        Me.Controls.Add(Me.Btn_Adelante)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.DTP_FechaSalida)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DTP_FechaIngreso)
        Me.Name = "Planilla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planilla"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DTGV_Planilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DTP_FechaSalida As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DTP_FechaIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Btn_Atras As System.Windows.Forms.Button
    Friend WithEvents Btn_Adelante As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Txb_id_Planilla As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_CedJuridica As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_Nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtb_TotalPlanilla As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtb_PorcCCSS As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtb_Aumento As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Btn_GuardaPlanilla As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Txb_Dedu_Otro As System.Windows.Forms.TextBox
    Friend WithEvents Txb_Dedu_Prestamo As System.Windows.Forms.TextBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
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
    Friend WithEvents Btn_GuardarDeduccion As System.Windows.Forms.Button
    Friend WithEvents Txb_Dedu_CCSS As System.Windows.Forms.TextBox
    Friend WithEvents Txb_Dedu_Adicional As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtb_NombreEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_GoEmpleado As System.Windows.Forms.Button
    Friend WithEvents Txb_CedulaEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btn_EmplAtras As System.Windows.Forms.Button
    Friend WithEvents Btn_EmplAdelante As System.Windows.Forms.Button
    Friend WithEvents Txt_Id As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Txb_Salario As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txb_Puesto As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Txb_RutaImagen As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Txb_CodigoEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Salario As System.Windows.Forms.Label
    Friend WithEvents Txtb_CodRuta As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Txb_SalarioQuincenal As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtb_CodigoCobroXFaltante As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents DTGV_Planilla As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btn_ImprimeRepEmpleado As System.Windows.Forms.Button
    Friend WithEvents btn_NuevaPlanilla As System.Windows.Forms.Button
End Class
