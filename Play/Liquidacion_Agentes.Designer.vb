<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Liquidacion_Agentes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Liquidacion_Agentes))
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtb_NombreAgente = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.btn_AgregaDepositos = New System.Windows.Forms.Button
        Me.txtb_TotalDepositos = New System.Windows.Forms.TextBox
        Me.dgv_Depositos = New System.Windows.Forms.DataGridView
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtb_TotalRecibos = New System.Windows.Forms.TextBox
        Me.dgv_Recibos = New System.Windows.Forms.DataGridView
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_AgregaOtros = New System.Windows.Forms.Button
        Me.btn_Agrega_Imprevistos = New System.Windows.Forms.Button
        Me.btn_AgregaHospedaje = New System.Windows.Forms.Button
        Me.btn_AgregaCombustibles = New System.Windows.Forms.Button
        Me.btn_AgregaViaticos = New System.Windows.Forms.Button
        Me.txtb_TotalGastos = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtb_Viaticos = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtb_Combustibles = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtb_Hospedaje = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtb_Imprevistos = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtb_Otros = New System.Windows.Forms.TextBox
        Me.dtp_FechaFin = New System.Windows.Forms.DateTimePicker
        Me.dtp_FechaIni = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.lbl_titulo = New System.Windows.Forms.Label
        Me.txtb_Comentarios = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtp_FechaLiquidacion = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtb_CodAgente = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtb_Consecutivo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label

        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtb_Diferencias = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.btn_Cargar = New System.Windows.Forms.Button
        Me.btn_Nuevo = New System.Windows.Forms.Button
        Me.btn_Guardar = New System.Windows.Forms.Button
        Me.btn_Anular = New System.Windows.Forms.Button
        Me.btn_Buscar = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtb_Cedula = New System.Windows.Forms.TextBox
        Me.btn_Imprimir = New System.Windows.Forms.Button
        Me.lbl_Anulado = New System.Windows.Forms.Label
        Me.btn_BuscaLiquidacion = New System.Windows.Forms.Button
        Me.btn_BuscaAgente = New System.Windows.Forms.Button
        Me.Lbl_Ruta = New System.Windows.Forms.Label
        Me.cbx_Rutas = New System.Windows.Forms.ComboBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Btn_Adelante = New System.Windows.Forms.Button
        Me.Btn_Atras = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgv_Depositos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgv_Recibos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(14, 104)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 15)
        Me.Label19.TabIndex = 50
        Me.Label19.Text = "Empleado"
        '
        'txtb_NombreAgente
        '
        Me.txtb_NombreAgente.BackColor = System.Drawing.Color.White
        Me.txtb_NombreAgente.Location = New System.Drawing.Point(113, 101)
        Me.txtb_NombreAgente.Name = "txtb_NombreAgente"
        Me.txtb_NombreAgente.ReadOnly = True
        Me.txtb_NombreAgente.Size = New System.Drawing.Size(276, 20)
        Me.txtb_NombreAgente.TabIndex = 49
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btn_AgregaDepositos)
        Me.GroupBox5.Controls.Add(Me.txtb_TotalDepositos)
        Me.GroupBox5.Controls.Add(Me.dgv_Depositos)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Location = New System.Drawing.Point(720, 1)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(350, 386)
        Me.GroupBox5.TabIndex = 33
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "DEPOSITOS"
        '
        'btn_AgregaDepositos
        '
        Me.btn_AgregaDepositos.Image = CType(resources.GetObject("btn_AgregaDepositos.Image"), System.Drawing.Image)
        Me.btn_AgregaDepositos.Location = New System.Drawing.Point(315, 350)
        Me.btn_AgregaDepositos.Name = "btn_AgregaDepositos"
        Me.btn_AgregaDepositos.Size = New System.Drawing.Size(32, 35)
        Me.btn_AgregaDepositos.TabIndex = 38
        Me.btn_AgregaDepositos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_AgregaDepositos.UseVisualStyleBackColor = True
        '
        'txtb_TotalDepositos
        '
        Me.txtb_TotalDepositos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtb_TotalDepositos.BackColor = System.Drawing.Color.White
        Me.txtb_TotalDepositos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalDepositos.Location = New System.Drawing.Point(76, 348)
        Me.txtb_TotalDepositos.Multiline = True
        Me.txtb_TotalDepositos.Name = "txtb_TotalDepositos"
        Me.txtb_TotalDepositos.ReadOnly = True
        Me.txtb_TotalDepositos.Size = New System.Drawing.Size(225, 32)
        Me.txtb_TotalDepositos.TabIndex = 38
        Me.txtb_TotalDepositos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgv_Depositos
        '
        Me.dgv_Depositos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Depositos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Depositos.Location = New System.Drawing.Point(6, 16)
        Me.dgv_Depositos.Name = "dgv_Depositos"
        Me.dgv_Depositos.ReadOnly = True
        Me.dgv_Depositos.Size = New System.Drawing.Size(338, 330)
        Me.dgv_Depositos.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 356)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 20)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "TOTAL"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtb_TotalRecibos)
        Me.GroupBox4.Controls.Add(Me.dgv_Recibos)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Location = New System.Drawing.Point(343, 2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(350, 384)
        Me.GroupBox4.TabIndex = 32
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "RECIBOS"
        '
        'txtb_TotalRecibos
        '
        Me.txtb_TotalRecibos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtb_TotalRecibos.BackColor = System.Drawing.Color.White
        Me.txtb_TotalRecibos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalRecibos.Location = New System.Drawing.Point(83, 349)
        Me.txtb_TotalRecibos.Multiline = True
        Me.txtb_TotalRecibos.Name = "txtb_TotalRecibos"
        Me.txtb_TotalRecibos.ReadOnly = True
        Me.txtb_TotalRecibos.Size = New System.Drawing.Size(225, 32)
        Me.txtb_TotalRecibos.TabIndex = 40
        Me.txtb_TotalRecibos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgv_Recibos
        '
        Me.dgv_Recibos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Recibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Recibos.Location = New System.Drawing.Point(6, 17)
        Me.dgv_Recibos.Name = "dgv_Recibos"
        Me.dgv_Recibos.ReadOnly = True
        Me.dgv_Recibos.Size = New System.Drawing.Size(338, 330)
        Me.dgv_Recibos.TabIndex = 15
        Me.dgv_Recibos.VirtualMode = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 355)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 20)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "TOTAL"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btn_AgregaOtros)
        Me.GroupBox2.Controls.Add(Me.btn_Agrega_Imprevistos)
        Me.GroupBox2.Controls.Add(Me.btn_AgregaHospedaje)
        Me.GroupBox2.Controls.Add(Me.btn_AgregaCombustibles)
        Me.GroupBox2.Controls.Add(Me.btn_AgregaViaticos)
        Me.GroupBox2.Controls.Add(Me.txtb_TotalGastos)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtb_Viaticos)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtb_Combustibles)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtb_Hospedaje)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtb_Imprevistos)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtb_Otros)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 11)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(318, 373)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GASTOS"
        '
        'btn_AgregaOtros
        '
        Me.btn_AgregaOtros.Image = CType(resources.GetObject("btn_AgregaOtros.Image"), System.Drawing.Image)
        Me.btn_AgregaOtros.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_AgregaOtros.Location = New System.Drawing.Point(6, 200)
        Me.btn_AgregaOtros.Name = "btn_AgregaOtros"
        Me.btn_AgregaOtros.Size = New System.Drawing.Size(75, 35)
        Me.btn_AgregaOtros.TabIndex = 37
        Me.btn_AgregaOtros.Text = "Agregar"
        Me.btn_AgregaOtros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_AgregaOtros.UseVisualStyleBackColor = True
        '
        'btn_Agrega_Imprevistos
        '
        Me.btn_Agrega_Imprevistos.Image = CType(resources.GetObject("btn_Agrega_Imprevistos.Image"), System.Drawing.Image)
        Me.btn_Agrega_Imprevistos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Agrega_Imprevistos.Location = New System.Drawing.Point(6, 159)
        Me.btn_Agrega_Imprevistos.Name = "btn_Agrega_Imprevistos"
        Me.btn_Agrega_Imprevistos.Size = New System.Drawing.Size(75, 35)
        Me.btn_Agrega_Imprevistos.TabIndex = 36
        Me.btn_Agrega_Imprevistos.Text = "Agregar"
        Me.btn_Agrega_Imprevistos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Agrega_Imprevistos.UseVisualStyleBackColor = True
        '
        'btn_AgregaHospedaje
        '
        Me.btn_AgregaHospedaje.Image = CType(resources.GetObject("btn_AgregaHospedaje.Image"), System.Drawing.Image)
        Me.btn_AgregaHospedaje.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_AgregaHospedaje.Location = New System.Drawing.Point(7, 118)
        Me.btn_AgregaHospedaje.Name = "btn_AgregaHospedaje"
        Me.btn_AgregaHospedaje.Size = New System.Drawing.Size(75, 35)
        Me.btn_AgregaHospedaje.TabIndex = 35
        Me.btn_AgregaHospedaje.Text = "Agregar"
        Me.btn_AgregaHospedaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_AgregaHospedaje.UseVisualStyleBackColor = True
        '
        'btn_AgregaCombustibles
        '
        Me.btn_AgregaCombustibles.Image = CType(resources.GetObject("btn_AgregaCombustibles.Image"), System.Drawing.Image)
        Me.btn_AgregaCombustibles.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_AgregaCombustibles.Location = New System.Drawing.Point(7, 76)
        Me.btn_AgregaCombustibles.Name = "btn_AgregaCombustibles"
        Me.btn_AgregaCombustibles.Size = New System.Drawing.Size(75, 35)
        Me.btn_AgregaCombustibles.TabIndex = 34
        Me.btn_AgregaCombustibles.Text = "Agregar"
        Me.btn_AgregaCombustibles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_AgregaCombustibles.UseVisualStyleBackColor = True
        '
        'btn_AgregaViaticos
        '
        Me.btn_AgregaViaticos.Image = CType(resources.GetObject("btn_AgregaViaticos.Image"), System.Drawing.Image)
        Me.btn_AgregaViaticos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_AgregaViaticos.Location = New System.Drawing.Point(7, 35)
        Me.btn_AgregaViaticos.Name = "btn_AgregaViaticos"
        Me.btn_AgregaViaticos.Size = New System.Drawing.Size(75, 35)
        Me.btn_AgregaViaticos.TabIndex = 33
        Me.btn_AgregaViaticos.Text = "Agregar"
        Me.btn_AgregaViaticos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_AgregaViaticos.UseVisualStyleBackColor = True
        '
        'txtb_TotalGastos
        '
        Me.txtb_TotalGastos.BackColor = System.Drawing.Color.White
        Me.txtb_TotalGastos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalGastos.Location = New System.Drawing.Point(154, 338)
        Me.txtb_TotalGastos.Multiline = True
        Me.txtb_TotalGastos.Name = "txtb_TotalGastos"
        Me.txtb_TotalGastos.ReadOnly = True
        Me.txtb_TotalGastos.Size = New System.Drawing.Size(153, 32)
        Me.txtb_TotalGastos.TabIndex = 32
        Me.txtb_TotalGastos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(6, 344)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(68, 20)
        Me.Label21.TabIndex = 31
        Me.Label21.Text = "TOTAL"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(88, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 15)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Viaticos"
        '
        'txtb_Viaticos
        '
        Me.txtb_Viaticos.BackColor = System.Drawing.Color.White
        Me.txtb_Viaticos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Viaticos.Location = New System.Drawing.Point(160, 37)
        Me.txtb_Viaticos.Multiline = True
        Me.txtb_Viaticos.Name = "txtb_Viaticos"
        Me.txtb_Viaticos.ReadOnly = True
        Me.txtb_Viaticos.Size = New System.Drawing.Size(153, 32)
        Me.txtb_Viaticos.TabIndex = 16
        Me.txtb_Viaticos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(83, 87)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 15)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Combustible"
        '
        'txtb_Combustibles
        '
        Me.txtb_Combustibles.BackColor = System.Drawing.Color.White
        Me.txtb_Combustibles.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Combustibles.Location = New System.Drawing.Point(160, 78)
        Me.txtb_Combustibles.Multiline = True
        Me.txtb_Combustibles.Name = "txtb_Combustibles"
        Me.txtb_Combustibles.ReadOnly = True
        Me.txtb_Combustibles.Size = New System.Drawing.Size(153, 32)
        Me.txtb_Combustibles.TabIndex = 18
        Me.txtb_Combustibles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(87, 129)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 15)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Hospedaje"
        '
        'txtb_Hospedaje
        '
        Me.txtb_Hospedaje.BackColor = System.Drawing.Color.White
        Me.txtb_Hospedaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Hospedaje.Location = New System.Drawing.Point(160, 121)
        Me.txtb_Hospedaje.Multiline = True
        Me.txtb_Hospedaje.Name = "txtb_Hospedaje"
        Me.txtb_Hospedaje.ReadOnly = True
        Me.txtb_Hospedaje.Size = New System.Drawing.Size(153, 32)
        Me.txtb_Hospedaje.TabIndex = 20
        Me.txtb_Hospedaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(87, 170)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 15)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Imprevistos"
        '
        'txtb_Imprevistos
        '
        Me.txtb_Imprevistos.BackColor = System.Drawing.Color.White
        Me.txtb_Imprevistos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Imprevistos.Location = New System.Drawing.Point(158, 162)
        Me.txtb_Imprevistos.Multiline = True
        Me.txtb_Imprevistos.Name = "txtb_Imprevistos"
        Me.txtb_Imprevistos.ReadOnly = True
        Me.txtb_Imprevistos.Size = New System.Drawing.Size(153, 32)
        Me.txtb_Imprevistos.TabIndex = 22
        Me.txtb_Imprevistos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(86, 211)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 15)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "Otros"
        '
        'txtb_Otros
        '
        Me.txtb_Otros.BackColor = System.Drawing.Color.White
        Me.txtb_Otros.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Otros.Location = New System.Drawing.Point(158, 199)
        Me.txtb_Otros.Multiline = True
        Me.txtb_Otros.Name = "txtb_Otros"
        Me.txtb_Otros.ReadOnly = True
        Me.txtb_Otros.Size = New System.Drawing.Size(153, 32)
        Me.txtb_Otros.TabIndex = 24
        Me.txtb_Otros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtp_FechaFin
        '
        Me.dtp_FechaFin.Enabled = False
        Me.dtp_FechaFin.Location = New System.Drawing.Point(500, 104)
        Me.dtp_FechaFin.Name = "dtp_FechaFin"
        Me.dtp_FechaFin.Size = New System.Drawing.Size(200, 20)
        Me.dtp_FechaFin.TabIndex = 13
        '
        'dtp_FechaIni
        '
        Me.dtp_FechaIni.Enabled = False
        Me.dtp_FechaIni.Location = New System.Drawing.Point(500, 70)
        Me.dtp_FechaIni.Name = "dtp_FechaIni"
        Me.dtp_FechaIni.Size = New System.Drawing.Size(200, 20)
        Me.dtp_FechaIni.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(459, 110)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 15)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Hasta"
        '
        'lbl_titulo
        '
        Me.lbl_titulo.AutoSize = True
        Me.lbl_titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_titulo.Location = New System.Drawing.Point(361, 9)
        Me.lbl_titulo.Name = "lbl_titulo"
        Me.lbl_titulo.Size = New System.Drawing.Size(398, 33)
        Me.lbl_titulo.TabIndex = 47
        Me.lbl_titulo.Text = "LIQUIDACION DE AGENTES"
        '
        'txtb_Comentarios
        '
        Me.txtb_Comentarios.Location = New System.Drawing.Point(727, 67)
        Me.txtb_Comentarios.Multiline = True
        Me.txtb_Comentarios.Name = "txtb_Comentarios"
        Me.txtb_Comentarios.Size = New System.Drawing.Size(347, 57)
        Me.txtb_Comentarios.TabIndex = 46
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(724, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 15)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Notas"
        '
        'dtp_FechaLiquidacion
        '
        Me.dtp_FechaLiquidacion.Enabled = False
        Me.dtp_FechaLiquidacion.Location = New System.Drawing.Point(112, 146)
        Me.dtp_FechaLiquidacion.Name = "dtp_FechaLiquidacion"
        Me.dtp_FechaLiquidacion.Size = New System.Drawing.Size(276, 20)
        Me.dtp_FechaLiquidacion.TabIndex = 44
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 15)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Fecha"
        '
        'txtb_CodAgente
        '
        Me.txtb_CodAgente.BackColor = System.Drawing.Color.White
        Me.txtb_CodAgente.Location = New System.Drawing.Point(112, 75)
        Me.txtb_CodAgente.Name = "txtb_CodAgente"
        Me.txtb_CodAgente.ReadOnly = True
        Me.txtb_CodAgente.Size = New System.Drawing.Size(100, 20)
        Me.txtb_CodAgente.TabIndex = 42
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 15)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Codigo"
        '
        'txtb_Consecutivo
        '
        Me.txtb_Consecutivo.Location = New System.Drawing.Point(113, 49)
        Me.txtb_Consecutivo.Name = "txtb_Consecutivo"
        Me.txtb_Consecutivo.ReadOnly = True
        Me.txtb_Consecutivo.Size = New System.Drawing.Size(100, 20)
        Me.txtb_Consecutivo.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 15)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Consecutivo"

        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Enabled = False
        Me.TabControl1.Location = New System.Drawing.Point(3, 166)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1084, 416)
        Me.TabControl1.TabIndex = 55
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1076, 390)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "DATOS"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1076, 390)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(456, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Desde"
        '
        'txtb_Diferencias
        '
        Me.txtb_Diferencias.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtb_Diferencias.BackColor = System.Drawing.Color.White
        Me.txtb_Diferencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Diferencias.Location = New System.Drawing.Point(850, 599)
        Me.txtb_Diferencias.Name = "txtb_Diferencias"
        Me.txtb_Diferencias.ReadOnly = True
        Me.txtb_Diferencias.Size = New System.Drawing.Size(221, 28)
        Me.txtb_Diferencias.TabIndex = 57
        Me.txtb_Diferencias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(712, 600)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(137, 24)
        Me.Label17.TabIndex = 56
        Me.Label17.Text = "DIFERENCIA ₵"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(497, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(149, 15)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "RANGO DE LIQUIDACION"
        '
        'btn_Cargar
        '
        Me.btn_Cargar.Enabled = False
        Me.btn_Cargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cargar.Location = New System.Drawing.Point(462, 130)
        Me.btn_Cargar.Name = "btn_Cargar"
        Me.btn_Cargar.Size = New System.Drawing.Size(238, 45)
        Me.btn_Cargar.TabIndex = 59
        Me.btn_Cargar.Text = "Cargar"
        Me.btn_Cargar.UseVisualStyleBackColor = True
        '
        'btn_Nuevo
        '
        Me.btn_Nuevo.Location = New System.Drawing.Point(20, 588)
        Me.btn_Nuevo.Name = "btn_Nuevo"
        Me.btn_Nuevo.Size = New System.Drawing.Size(91, 47)
        Me.btn_Nuevo.TabIndex = 60
        Me.btn_Nuevo.Text = "NUEVO"
        Me.btn_Nuevo.UseVisualStyleBackColor = True
        '
        'btn_Guardar
        '
        Me.btn_Guardar.Location = New System.Drawing.Point(121, 588)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(91, 47)
        Me.btn_Guardar.TabIndex = 61
        Me.btn_Guardar.Text = "GUARDAR"
        Me.btn_Guardar.UseVisualStyleBackColor = True
        '
        'btn_Anular
        '
        Me.btn_Anular.Enabled = False
        Me.btn_Anular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Anular.ForeColor = System.Drawing.Color.Red
        Me.btn_Anular.Location = New System.Drawing.Point(619, 588)
        Me.btn_Anular.Name = "btn_Anular"
        Me.btn_Anular.Size = New System.Drawing.Size(91, 47)
        Me.btn_Anular.TabIndex = 63
        Me.btn_Anular.Text = "ANULAR"
        Me.btn_Anular.UseVisualStyleBackColor = True
        '
        'btn_Buscar
        '
        Me.btn_Buscar.Location = New System.Drawing.Point(221, 588)
        Me.btn_Buscar.Name = "btn_Buscar"
        Me.btn_Buscar.Size = New System.Drawing.Size(91, 47)
        Me.btn_Buscar.TabIndex = 64
        Me.btn_Buscar.Text = "BUSCAR"
        Me.btn_Buscar.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(14, 126)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 15)
        Me.Label15.TabIndex = 67
        Me.Label15.Text = "Cedula"
        '
        'txtb_Cedula
        '
        Me.txtb_Cedula.BackColor = System.Drawing.Color.White
        Me.txtb_Cedula.Location = New System.Drawing.Point(113, 123)
        Me.txtb_Cedula.Name = "txtb_Cedula"
        Me.txtb_Cedula.ReadOnly = True
        Me.txtb_Cedula.Size = New System.Drawing.Size(276, 20)
        Me.txtb_Cedula.TabIndex = 66
        '
        'btn_Imprimir
        '
        Me.btn_Imprimir.Enabled = False
        Me.btn_Imprimir.Location = New System.Drawing.Point(326, 588)
        Me.btn_Imprimir.Name = "btn_Imprimir"
        Me.btn_Imprimir.Size = New System.Drawing.Size(91, 47)
        Me.btn_Imprimir.TabIndex = 68
        Me.btn_Imprimir.Text = "IMPRIMIR"
        Me.btn_Imprimir.UseVisualStyleBackColor = True
        '
        'lbl_Anulado
        '
        Me.lbl_Anulado.AutoSize = True
        Me.lbl_Anulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Anulado.ForeColor = System.Drawing.Color.Red
        Me.lbl_Anulado.Location = New System.Drawing.Point(259, 56)
        Me.lbl_Anulado.Name = "lbl_Anulado"
        Me.lbl_Anulado.Size = New System.Drawing.Size(158, 33)
        Me.lbl_Anulado.TabIndex = 69
        Me.lbl_Anulado.Text = "ANULADA"
        Me.lbl_Anulado.Visible = False
        '
        'btn_BuscaLiquidacion
        '
        Me.btn_BuscaLiquidacion.Image = CType(resources.GetObject("btn_BuscaLiquidacion.Image"), System.Drawing.Image)
        Me.btn_BuscaLiquidacion.Location = New System.Drawing.Point(221, 46)
        Me.btn_BuscaLiquidacion.Name = "btn_BuscaLiquidacion"
        Me.btn_BuscaLiquidacion.Size = New System.Drawing.Size(32, 24)
        Me.btn_BuscaLiquidacion.TabIndex = 65
        Me.btn_BuscaLiquidacion.UseVisualStyleBackColor = True
        '
        'btn_BuscaAgente
        '
        Me.btn_BuscaAgente.Image = CType(resources.GetObject("btn_BuscaAgente.Image"), System.Drawing.Image)
        Me.btn_BuscaAgente.Location = New System.Drawing.Point(221, 75)
        Me.btn_BuscaAgente.Name = "btn_BuscaAgente"
        Me.btn_BuscaAgente.Size = New System.Drawing.Size(32, 24)
        Me.btn_BuscaAgente.TabIndex = 53
        Me.btn_BuscaAgente.UseVisualStyleBackColor = True
        '
        'Lbl_Ruta
        '
        Me.Lbl_Ruta.AutoSize = True
        Me.Lbl_Ruta.Location = New System.Drawing.Point(729, 130)
        Me.Lbl_Ruta.Name = "Lbl_Ruta"
        Me.Lbl_Ruta.Size = New System.Drawing.Size(33, 15)
        Me.Lbl_Ruta.TabIndex = 71
        Me.Lbl_Ruta.Text = "Ruta"
        '
        'cbx_Rutas
        '
        Me.cbx_Rutas.FormattingEnabled = True
        Me.cbx_Rutas.Location = New System.Drawing.Point(732, 149)
        Me.cbx_Rutas.Name = "cbx_Rutas"
        Me.cbx_Rutas.Size = New System.Drawing.Size(338, 21)
        Me.cbx_Rutas.TabIndex = 70
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Location = New System.Drawing.Point(112, 146)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(276, 20)
        Me.DateTimePicker1.TabIndex = 44
        '
        'Btn_Adelante
        '
        Me.Btn_Adelante.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Adelante.BackgroundImage = CType(resources.GetObject("Btn_Adelante.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Adelante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Adelante.Location = New System.Drawing.Point(1002, 1)
        Me.Btn_Adelante.Name = "Btn_Adelante"
        Me.Btn_Adelante.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Adelante.TabIndex = 72
        Me.Btn_Adelante.UseVisualStyleBackColor = False
        '
        'Btn_Atras
        '
        Me.Btn_Atras.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Atras.BackgroundImage = CType(resources.GetObject("Btn_Atras.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Atras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Atras.Location = New System.Drawing.Point(921, 2)
        Me.Btn_Atras.Name = "Btn_Atras"
        Me.Btn_Atras.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Atras.TabIndex = 73
        Me.Btn_Atras.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(126, 43)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 74
        Me.PictureBox1.TabStop = False
        '
        'Liquidacion_Agentes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1086, 640)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Btn_Atras)
        Me.Controls.Add(Me.Btn_Adelante)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Lbl_Ruta)
        Me.Controls.Add(Me.cbx_Rutas)
        Me.Controls.Add(Me.lbl_Anulado)
        Me.Controls.Add(Me.btn_Imprimir)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtb_Cedula)
        Me.Controls.Add(Me.btn_BuscaLiquidacion)
        Me.Controls.Add(Me.btn_Buscar)
        Me.Controls.Add(Me.btn_Anular)
        Me.Controls.Add(Me.btn_Guardar)
        Me.Controls.Add(Me.btn_Nuevo)
        Me.Controls.Add(Me.btn_Cargar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtb_Diferencias)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.dtp_FechaFin)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dtp_FechaIni)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btn_BuscaAgente)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtb_NombreAgente)
        Me.Controls.Add(Me.lbl_titulo)
        Me.Controls.Add(Me.txtb_Comentarios)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtp_FechaLiquidacion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtb_CodAgente)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtb_Consecutivo)
        Me.Controls.Add(Me.Label1)

        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1102, 680)
        Me.MinimumSize = New System.Drawing.Size(1102, 680)
        Me.Name = "Liquidacion_Agentes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liquidacion_Agentes"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dgv_Depositos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgv_Recibos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_BuscaAgente As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtb_NombreAgente As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtb_TotalDepositos As System.Windows.Forms.TextBox
    Friend WithEvents dgv_Depositos As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtb_TotalRecibos As System.Windows.Forms.TextBox
    Friend WithEvents dgv_Recibos As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtb_TotalGastos As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtb_Viaticos As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtb_Combustibles As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtb_Hospedaje As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtb_Imprevistos As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtb_Otros As System.Windows.Forms.TextBox
    Friend WithEvents dtp_FechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_FechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbl_titulo As System.Windows.Forms.Label
    Friend WithEvents txtb_Comentarios As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtp_FechaLiquidacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtb_CodAgente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtb_Consecutivo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_AgregaViaticos As System.Windows.Forms.Button
    Friend WithEvents btn_AgregaOtros As System.Windows.Forms.Button
    Friend WithEvents btn_Agrega_Imprevistos As System.Windows.Forms.Button
    Friend WithEvents btn_AgregaHospedaje As System.Windows.Forms.Button
    Friend WithEvents btn_AgregaCombustibles As System.Windows.Forms.Button
    Friend WithEvents txtb_Diferencias As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btn_AgregaDepositos As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btn_Cargar As System.Windows.Forms.Button
    Friend WithEvents btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents btn_Anular As System.Windows.Forms.Button
    Friend WithEvents btn_Buscar As System.Windows.Forms.Button
    Friend WithEvents btn_BuscaLiquidacion As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtb_Cedula As System.Windows.Forms.TextBox
    Friend WithEvents btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lbl_Anulado As System.Windows.Forms.Label
    Friend WithEvents Lbl_Ruta As System.Windows.Forms.Label
    Friend WithEvents cbx_Rutas As System.Windows.Forms.ComboBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Btn_Adelante As System.Windows.Forms.Button
    Friend WithEvents Btn_Atras As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
