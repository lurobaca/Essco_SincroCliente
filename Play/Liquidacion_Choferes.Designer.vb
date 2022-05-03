<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Liquidacion_Choferes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Liquidacion_Choferes))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtb_Consecutivo = New System.Windows.Forms.TextBox()
        Me.txt_CodChofer = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp_FechaLiquidacion = New System.Windows.Forms.DateTimePicker()
        Me.lbl_titulo = New System.Windows.Forms.Label()
        Me.txt_NombreChofer = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Txtb_TotalSaldo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtb_TotalFacturas = New System.Windows.Forms.TextBox()
        Me.dgv_Facturas = New System.Windows.Forms.DataGridView()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btn_AddDeposito = New System.Windows.Forms.Button()
        Me.txtb_TotalDepositos = New System.Windows.Forms.TextBox()
        Me.dgv_Depositos = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btn_AddRecibos = New System.Windows.Forms.Button()
        Me.txtb_TotalRecibos = New System.Windows.Forms.TextBox()
        Me.dgv_Recibos = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_AgregaOtros = New System.Windows.Forms.Button()
        Me.btn_Agrega_Imprevistos = New System.Windows.Forms.Button()
        Me.btn_AgregaHospedaje = New System.Windows.Forms.Button()
        Me.btn_AgregaCombustibles = New System.Windows.Forms.Button()
        Me.btn_AgregaViaticos = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtb_Viaticos = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtb_Combustibles = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtb_Hospedaje = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtb_Imprevistos = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtb_Otros = New System.Windows.Forms.TextBox()
        Me.txtb_TotalGastos = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dtp_FechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtp_FechaIni = New System.Windows.Forms.DateTimePicker()
        Me.cbx_Rutas = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtb_Comentarios = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.dtp_FechaIni_Recibos = New System.Windows.Forms.DateTimePicker()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.dtp_FechaFin_Recibos = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ListView_Agentes = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtb_Cedula = New System.Windows.Forms.TextBox()
        Me.lbl_Anulado = New System.Windows.Forms.Label()
        Me.btn_Imprimir = New System.Windows.Forms.Button()
        Me.btn_Buscar = New System.Windows.Forms.Button()
        Me.btn_Anular = New System.Windows.Forms.Button()
        Me.btn_Guardar = New System.Windows.Forms.Button()
        Me.btn_Nuevo = New System.Windows.Forms.Button()
        Me.txtb_Diferencias = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtb_Ruta = New System.Windows.Forms.TextBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_Cargar = New System.Windows.Forms.Button()
        Me.btn_BuscaLiquidacion = New System.Windows.Forms.Button()
        Me.Btn_Atras = New System.Windows.Forms.Button()
        Me.Btn_Adelante = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_BuscaChofer = New System.Windows.Forms.Button()
        Me.ListV_Reportes = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn_GoReporte = New System.Windows.Forms.Button()
        Me.btn_AddRepFac = New System.Windows.Forms.Button()
        Me.btn_QuitaRepFActuras = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_Facturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgv_Depositos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgv_Recibos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Consecutivo"
        '
        'txtb_Consecutivo
        '
        Me.txtb_Consecutivo.Location = New System.Drawing.Point(105, 56)
        Me.txtb_Consecutivo.Name = "txtb_Consecutivo"
        Me.txtb_Consecutivo.ReadOnly = True
        Me.txtb_Consecutivo.Size = New System.Drawing.Size(100, 20)
        Me.txtb_Consecutivo.TabIndex = 0
        '
        'txt_CodChofer
        '
        Me.txt_CodChofer.Location = New System.Drawing.Point(106, 81)
        Me.txt_CodChofer.Name = "txt_CodChofer"
        Me.txt_CodChofer.ReadOnly = True
        Me.txt_CodChofer.Size = New System.Drawing.Size(100, 20)
        Me.txt_CodChofer.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cod Chofer"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 157)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Fecha"
        '
        'dtp_FechaLiquidacion
        '
        Me.dtp_FechaLiquidacion.Location = New System.Drawing.Point(106, 154)
        Me.dtp_FechaLiquidacion.Name = "dtp_FechaLiquidacion"
        Me.dtp_FechaLiquidacion.Size = New System.Drawing.Size(282, 20)
        Me.dtp_FechaLiquidacion.TabIndex = 6
        '
        'lbl_titulo
        '
        Me.lbl_titulo.AutoSize = True
        Me.lbl_titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_titulo.Location = New System.Drawing.Point(359, 9)
        Me.lbl_titulo.Name = "lbl_titulo"
        Me.lbl_titulo.Size = New System.Drawing.Size(421, 33)
        Me.lbl_titulo.TabIndex = 9
        Me.lbl_titulo.Text = "LIQUIDACION DE CHOFERES"
        '
        'txt_NombreChofer
        '
        Me.txt_NombreChofer.Location = New System.Drawing.Point(106, 107)
        Me.txt_NombreChofer.Name = "txt_NombreChofer"
        Me.txt_NombreChofer.ReadOnly = True
        Me.txt_NombreChofer.Size = New System.Drawing.Size(282, 20)
        Me.txt_NombreChofer.TabIndex = 4
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 110)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(91, 15)
        Me.Label19.TabIndex = 35
        Me.Label19.Text = "Nombre Chofer"
        '
        'Label15
        '
        Me.Label15.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(435, 120)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 15)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Ruta"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(4, 180)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1031, 371)
        Me.TabControl1.TabIndex = 12
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1023, 345)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "DATOS"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Txtb_TotalSaldo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.txtb_TotalFacturas)
        Me.GroupBox1.Controls.Add(Me.dgv_Facturas)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Location = New System.Drawing.Point(730, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(293, 333)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FACTURAS EN REPORTE"
        '
        'Txtb_TotalSaldo
        '
        Me.Txtb_TotalSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Txtb_TotalSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_TotalSaldo.Location = New System.Drawing.Point(135, 305)
        Me.Txtb_TotalSaldo.Name = "Txtb_TotalSaldo"
        Me.Txtb_TotalSaldo.ReadOnly = True
        Me.Txtb_TotalSaldo.Size = New System.Drawing.Size(126, 27)
        Me.Txtb_TotalSaldo.TabIndex = 44
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 282)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 20)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "TOTAL FAC"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(263, 303)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(30, 29)
        Me.Button3.TabIndex = 42
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtb_TotalFacturas
        '
        Me.txtb_TotalFacturas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtb_TotalFacturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalFacturas.Location = New System.Drawing.Point(4, 305)
        Me.txtb_TotalFacturas.Name = "txtb_TotalFacturas"
        Me.txtb_TotalFacturas.ReadOnly = True
        Me.txtb_TotalFacturas.Size = New System.Drawing.Size(128, 27)
        Me.txtb_TotalFacturas.TabIndex = 40
        '
        'dgv_Facturas
        '
        Me.dgv_Facturas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Facturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Facturas.Location = New System.Drawing.Point(4, 17)
        Me.dgv_Facturas.Name = "dgv_Facturas"
        Me.dgv_Facturas.Size = New System.Drawing.Size(281, 262)
        Me.dgv_Facturas.TabIndex = 15
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(130, 282)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(137, 20)
        Me.Label20.TabIndex = 39
        Me.Label20.Text = "TOTAL SALDO"
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.btn_AddDeposito)
        Me.GroupBox5.Controls.Add(Me.txtb_TotalDepositos)
        Me.GroupBox5.Controls.Add(Me.dgv_Depositos)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Location = New System.Drawing.Point(192, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(264, 333)
        Me.GroupBox5.TabIndex = 33
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "DEPOSITOS"
        '
        'btn_AddDeposito
        '
        Me.btn_AddDeposito.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_AddDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AddDeposito.Image = CType(resources.GetObject("btn_AddDeposito.Image"), System.Drawing.Image)
        Me.btn_AddDeposito.Location = New System.Drawing.Point(227, 304)
        Me.btn_AddDeposito.Name = "btn_AddDeposito"
        Me.btn_AddDeposito.Size = New System.Drawing.Size(30, 29)
        Me.btn_AddDeposito.TabIndex = 43
        Me.btn_AddDeposito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_AddDeposito.UseVisualStyleBackColor = True
        '
        'txtb_TotalDepositos
        '
        Me.txtb_TotalDepositos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtb_TotalDepositos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalDepositos.Location = New System.Drawing.Point(82, 305)
        Me.txtb_TotalDepositos.Name = "txtb_TotalDepositos"
        Me.txtb_TotalDepositos.ReadOnly = True
        Me.txtb_TotalDepositos.Size = New System.Drawing.Size(128, 27)
        Me.txtb_TotalDepositos.TabIndex = 38
        '
        'dgv_Depositos
        '
        Me.dgv_Depositos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Depositos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Depositos.Location = New System.Drawing.Point(6, 17)
        Me.dgv_Depositos.Name = "dgv_Depositos"
        Me.dgv_Depositos.Size = New System.Drawing.Size(252, 285)
        Me.dgv_Depositos.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 307)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 20)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "TOTAL"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.btn_AddRecibos)
        Me.GroupBox4.Controls.Add(Me.txtb_TotalRecibos)
        Me.GroupBox4.Controls.Add(Me.dgv_Recibos)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Location = New System.Drawing.Point(456, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(272, 333)
        Me.GroupBox4.TabIndex = 32
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "RECIBOS"
        '
        'btn_AddRecibos
        '
        Me.btn_AddRecibos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_AddRecibos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AddRecibos.Image = CType(resources.GetObject("btn_AddRecibos.Image"), System.Drawing.Image)
        Me.btn_AddRecibos.Location = New System.Drawing.Point(233, 303)
        Me.btn_AddRecibos.Name = "btn_AddRecibos"
        Me.btn_AddRecibos.Size = New System.Drawing.Size(30, 29)
        Me.btn_AddRecibos.TabIndex = 44
        Me.btn_AddRecibos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_AddRecibos.UseVisualStyleBackColor = True
        '
        'txtb_TotalRecibos
        '
        Me.txtb_TotalRecibos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtb_TotalRecibos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalRecibos.Location = New System.Drawing.Point(88, 305)
        Me.txtb_TotalRecibos.Name = "txtb_TotalRecibos"
        Me.txtb_TotalRecibos.ReadOnly = True
        Me.txtb_TotalRecibos.Size = New System.Drawing.Size(128, 27)
        Me.txtb_TotalRecibos.TabIndex = 40
        '
        'dgv_Recibos
        '
        Me.dgv_Recibos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Recibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Recibos.Location = New System.Drawing.Point(6, 17)
        Me.dgv_Recibos.Name = "dgv_Recibos"
        Me.dgv_Recibos.Size = New System.Drawing.Size(260, 285)
        Me.dgv_Recibos.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(4, 309)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 20)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "TOTAL"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btn_AgregaOtros)
        Me.GroupBox2.Controls.Add(Me.btn_Agrega_Imprevistos)
        Me.GroupBox2.Controls.Add(Me.btn_AgregaHospedaje)
        Me.GroupBox2.Controls.Add(Me.btn_AgregaCombustibles)
        Me.GroupBox2.Controls.Add(Me.btn_AgregaViaticos)
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
        Me.GroupBox2.Controls.Add(Me.txtb_TotalGastos)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(181, 333)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GASTOS"
        '
        'btn_AgregaOtros
        '
        Me.btn_AgregaOtros.Image = CType(resources.GetObject("btn_AgregaOtros.Image"), System.Drawing.Image)
        Me.btn_AgregaOtros.Location = New System.Drawing.Point(6, 246)
        Me.btn_AgregaOtros.Name = "btn_AgregaOtros"
        Me.btn_AgregaOtros.Size = New System.Drawing.Size(30, 30)
        Me.btn_AgregaOtros.TabIndex = 18
        Me.btn_AgregaOtros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_AgregaOtros.UseVisualStyleBackColor = True
        '
        'btn_Agrega_Imprevistos
        '
        Me.btn_Agrega_Imprevistos.Image = CType(resources.GetObject("btn_Agrega_Imprevistos.Image"), System.Drawing.Image)
        Me.btn_Agrega_Imprevistos.Location = New System.Drawing.Point(6, 194)
        Me.btn_Agrega_Imprevistos.Name = "btn_Agrega_Imprevistos"
        Me.btn_Agrega_Imprevistos.Size = New System.Drawing.Size(30, 30)
        Me.btn_Agrega_Imprevistos.TabIndex = 17
        Me.btn_Agrega_Imprevistos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Agrega_Imprevistos.UseVisualStyleBackColor = True
        '
        'btn_AgregaHospedaje
        '
        Me.btn_AgregaHospedaje.Image = CType(resources.GetObject("btn_AgregaHospedaje.Image"), System.Drawing.Image)
        Me.btn_AgregaHospedaje.Location = New System.Drawing.Point(6, 139)
        Me.btn_AgregaHospedaje.Name = "btn_AgregaHospedaje"
        Me.btn_AgregaHospedaje.Size = New System.Drawing.Size(30, 30)
        Me.btn_AgregaHospedaje.TabIndex = 16
        Me.btn_AgregaHospedaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_AgregaHospedaje.UseVisualStyleBackColor = True
        '
        'btn_AgregaCombustibles
        '
        Me.btn_AgregaCombustibles.Image = CType(resources.GetObject("btn_AgregaCombustibles.Image"), System.Drawing.Image)
        Me.btn_AgregaCombustibles.Location = New System.Drawing.Point(6, 88)
        Me.btn_AgregaCombustibles.Name = "btn_AgregaCombustibles"
        Me.btn_AgregaCombustibles.Size = New System.Drawing.Size(30, 30)
        Me.btn_AgregaCombustibles.TabIndex = 15
        Me.btn_AgregaCombustibles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_AgregaCombustibles.UseVisualStyleBackColor = True
        '
        'btn_AgregaViaticos
        '
        Me.btn_AgregaViaticos.Image = CType(resources.GetObject("btn_AgregaViaticos.Image"), System.Drawing.Image)
        Me.btn_AgregaViaticos.Location = New System.Drawing.Point(6, 36)
        Me.btn_AgregaViaticos.Name = "btn_AgregaViaticos"
        Me.btn_AgregaViaticos.Size = New System.Drawing.Size(30, 30)
        Me.btn_AgregaViaticos.TabIndex = 14
        Me.btn_AgregaViaticos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_AgregaViaticos.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(81, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 15)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Viaticos"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtb_Viaticos
        '
        Me.txtb_Viaticos.BackColor = System.Drawing.Color.White
        Me.txtb_Viaticos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Viaticos.Location = New System.Drawing.Point(43, 32)
        Me.txtb_Viaticos.Multiline = True
        Me.txtb_Viaticos.Name = "txtb_Viaticos"
        Me.txtb_Viaticos.ReadOnly = True
        Me.txtb_Viaticos.Size = New System.Drawing.Size(131, 32)
        Me.txtb_Viaticos.TabIndex = 39
        Me.txtb_Viaticos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(75, 69)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 15)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "Combustible"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtb_Combustibles
        '
        Me.txtb_Combustibles.BackColor = System.Drawing.Color.White
        Me.txtb_Combustibles.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Combustibles.Location = New System.Drawing.Point(43, 86)
        Me.txtb_Combustibles.Multiline = True
        Me.txtb_Combustibles.Name = "txtb_Combustibles"
        Me.txtb_Combustibles.ReadOnly = True
        Me.txtb_Combustibles.Size = New System.Drawing.Size(131, 32)
        Me.txtb_Combustibles.TabIndex = 41
        Me.txtb_Combustibles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(75, 124)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 15)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "Hospedaje"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtb_Hospedaje
        '
        Me.txtb_Hospedaje.BackColor = System.Drawing.Color.White
        Me.txtb_Hospedaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Hospedaje.Location = New System.Drawing.Point(43, 140)
        Me.txtb_Hospedaje.Multiline = True
        Me.txtb_Hospedaje.Name = "txtb_Hospedaje"
        Me.txtb_Hospedaje.ReadOnly = True
        Me.txtb_Hospedaje.Size = New System.Drawing.Size(131, 32)
        Me.txtb_Hospedaje.TabIndex = 43
        Me.txtb_Hospedaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(73, 178)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 15)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "Imprevistos"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtb_Imprevistos
        '
        Me.txtb_Imprevistos.BackColor = System.Drawing.Color.White
        Me.txtb_Imprevistos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Imprevistos.Location = New System.Drawing.Point(43, 196)
        Me.txtb_Imprevistos.Multiline = True
        Me.txtb_Imprevistos.Name = "txtb_Imprevistos"
        Me.txtb_Imprevistos.ReadOnly = True
        Me.txtb_Imprevistos.Size = New System.Drawing.Size(131, 32)
        Me.txtb_Imprevistos.TabIndex = 45
        Me.txtb_Imprevistos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(87, 230)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 15)
        Me.Label14.TabIndex = 46
        Me.Label14.Text = "Otros"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtb_Otros
        '
        Me.txtb_Otros.BackColor = System.Drawing.Color.White
        Me.txtb_Otros.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Otros.Location = New System.Drawing.Point(43, 246)
        Me.txtb_Otros.Multiline = True
        Me.txtb_Otros.Name = "txtb_Otros"
        Me.txtb_Otros.ReadOnly = True
        Me.txtb_Otros.Size = New System.Drawing.Size(131, 32)
        Me.txtb_Otros.TabIndex = 47
        Me.txtb_Otros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtb_TotalGastos
        '
        Me.txtb_TotalGastos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalGastos.Location = New System.Drawing.Point(28, 305)
        Me.txtb_TotalGastos.Name = "txtb_TotalGastos"
        Me.txtb_TotalGastos.ReadOnly = True
        Me.txtb_TotalGastos.Size = New System.Drawing.Size(128, 27)
        Me.txtb_TotalGastos.TabIndex = 32
        Me.txtb_TotalGastos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(55, 282)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(68, 20)
        Me.Label21.TabIndex = 31
        Me.Label21.Text = "TOTAL"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dtp_FechaFin)
        Me.TabPage2.Controls.Add(Me.dtp_FechaIni)
        Me.TabPage2.Controls.Add(Me.cbx_Rutas)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.txtb_Comentarios)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1023, 345)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "COMENTARIOS"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dtp_FechaFin
        '
        Me.dtp_FechaFin.Location = New System.Drawing.Point(576, 168)
        Me.dtp_FechaFin.Name = "dtp_FechaFin"
        Me.dtp_FechaFin.Size = New System.Drawing.Size(30, 20)
        Me.dtp_FechaFin.TabIndex = 67
        Me.dtp_FechaFin.Visible = False
        '
        'dtp_FechaIni
        '
        Me.dtp_FechaIni.Location = New System.Drawing.Point(533, 170)
        Me.dtp_FechaIni.Name = "dtp_FechaIni"
        Me.dtp_FechaIni.Size = New System.Drawing.Size(29, 20)
        Me.dtp_FechaIni.TabIndex = 66
        Me.dtp_FechaIni.Visible = False
        '
        'cbx_Rutas
        '
        Me.cbx_Rutas.FormattingEnabled = True
        Me.cbx_Rutas.Location = New System.Drawing.Point(471, 167)
        Me.cbx_Rutas.Name = "cbx_Rutas"
        Me.cbx_Rutas.Size = New System.Drawing.Size(41, 21)
        Me.cbx_Rutas.TabIndex = 68
        Me.cbx_Rutas.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(30, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 15)
        Me.Label9.TabIndex = 64
        Me.Label9.Text = "Notas"
        '
        'txtb_Comentarios
        '
        Me.txtb_Comentarios.Location = New System.Drawing.Point(33, 55)
        Me.txtb_Comentarios.Multiline = True
        Me.txtb_Comentarios.Name = "txtb_Comentarios"
        Me.txtb_Comentarios.Size = New System.Drawing.Size(1018, 74)
        Me.txtb_Comentarios.TabIndex = 65
        '
        'Label22
        '
        Me.Label22.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(782, 49)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(94, 15)
        Me.Label22.TabIndex = 90
        Me.Label22.Text = "RCs/GTs/DEP"
        '
        'dtp_FechaIni_Recibos
        '
        Me.dtp_FechaIni_Recibos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtp_FechaIni_Recibos.Location = New System.Drawing.Point(738, 69)
        Me.dtp_FechaIni_Recibos.Name = "dtp_FechaIni_Recibos"
        Me.dtp_FechaIni_Recibos.Size = New System.Drawing.Size(200, 20)
        Me.dtp_FechaIni_Recibos.TabIndex = 86
        '
        'Label23
        '
        Me.Label23.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(684, 93)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(39, 15)
        Me.Label23.TabIndex = 89
        Me.Label23.Text = "Hasta"
        '
        'Label24
        '
        Me.Label24.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(684, 69)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(43, 15)
        Me.Label24.TabIndex = 88
        Me.Label24.Text = "Desde"
        '
        'dtp_FechaFin_Recibos
        '
        Me.dtp_FechaFin_Recibos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtp_FechaFin_Recibos.Location = New System.Drawing.Point(738, 93)
        Me.dtp_FechaFin_Recibos.Name = "dtp_FechaFin_Recibos"
        Me.dtp_FechaFin_Recibos.Size = New System.Drawing.Size(200, 20)
        Me.dtp_FechaFin_Recibos.TabIndex = 87
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(548, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 15)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "Rep Facturas"
        '
        'Label18
        '
        Me.Label18.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(435, 151)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 16)
        Me.Label18.TabIndex = 85
        Me.Label18.Text = "Agentes"
        '
        'ListView_Agentes
        '
        Me.ListView_Agentes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView_Agentes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.ListView_Agentes.Location = New System.Drawing.Point(610, 145)
        Me.ListView_Agentes.Name = "ListView_Agentes"
        Me.ListView_Agentes.Size = New System.Drawing.Size(418, 28)
        Me.ListView_Agentes.TabIndex = 34
        Me.ListView_Agentes.UseCompatibleStateImageBehavior = False
        Me.ListView_Agentes.View = System.Windows.Forms.View.List
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "1"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "2"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "3"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "4"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(14, 134)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 15)
        Me.Label16.TabIndex = 69
        Me.Label16.Text = "Cedula"
        '
        'txtb_Cedula
        '
        Me.txtb_Cedula.BackColor = System.Drawing.SystemColors.Control
        Me.txtb_Cedula.Location = New System.Drawing.Point(105, 131)
        Me.txtb_Cedula.Name = "txtb_Cedula"
        Me.txtb_Cedula.ReadOnly = True
        Me.txtb_Cedula.Size = New System.Drawing.Size(282, 20)
        Me.txtb_Cedula.TabIndex = 5
        '
        'lbl_Anulado
        '
        Me.lbl_Anulado.AutoSize = True
        Me.lbl_Anulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Anulado.ForeColor = System.Drawing.Color.Red
        Me.lbl_Anulado.Location = New System.Drawing.Point(245, 60)
        Me.lbl_Anulado.Name = "lbl_Anulado"
        Me.lbl_Anulado.Size = New System.Drawing.Size(158, 33)
        Me.lbl_Anulado.TabIndex = 71
        Me.lbl_Anulado.Text = "ANULADA"
        Me.lbl_Anulado.Visible = False
        '
        'btn_Imprimir
        '
        Me.btn_Imprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Imprimir.Enabled = False
        Me.btn_Imprimir.Location = New System.Drawing.Point(282, 552)
        Me.btn_Imprimir.Name = "btn_Imprimir"
        Me.btn_Imprimir.Size = New System.Drawing.Size(89, 47)
        Me.btn_Imprimir.TabIndex = 22
        Me.btn_Imprimir.Text = "IMPRIMIR"
        Me.btn_Imprimir.UseVisualStyleBackColor = True
        '
        'btn_Buscar
        '
        Me.btn_Buscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Buscar.Location = New System.Drawing.Point(189, 552)
        Me.btn_Buscar.Name = "btn_Buscar"
        Me.btn_Buscar.Size = New System.Drawing.Size(89, 47)
        Me.btn_Buscar.TabIndex = 21
        Me.btn_Buscar.Text = "BUSCAR"
        Me.btn_Buscar.UseVisualStyleBackColor = True
        '
        'btn_Anular
        '
        Me.btn_Anular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Anular.Enabled = False
        Me.btn_Anular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Anular.ForeColor = System.Drawing.Color.Red
        Me.btn_Anular.Location = New System.Drawing.Point(552, 550)
        Me.btn_Anular.Name = "btn_Anular"
        Me.btn_Anular.Size = New System.Drawing.Size(89, 47)
        Me.btn_Anular.TabIndex = 23
        Me.btn_Anular.Text = "ANULAR"
        Me.btn_Anular.UseVisualStyleBackColor = True
        Me.btn_Anular.Visible = False
        '
        'btn_Guardar
        '
        Me.btn_Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Guardar.Location = New System.Drawing.Point(98, 552)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(89, 47)
        Me.btn_Guardar.TabIndex = 19
        Me.btn_Guardar.Text = "GUARDAR"
        Me.btn_Guardar.UseVisualStyleBackColor = True
        '
        'btn_Nuevo
        '
        Me.btn_Nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Nuevo.Location = New System.Drawing.Point(8, 552)
        Me.btn_Nuevo.Name = "btn_Nuevo"
        Me.btn_Nuevo.Size = New System.Drawing.Size(89, 47)
        Me.btn_Nuevo.TabIndex = 74
        Me.btn_Nuevo.Text = "NUEVO"
        Me.btn_Nuevo.UseVisualStyleBackColor = True
        '
        'txtb_Diferencias
        '
        Me.txtb_Diferencias.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_Diferencias.BackColor = System.Drawing.Color.White
        Me.txtb_Diferencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Diferencias.Location = New System.Drawing.Point(798, 558)
        Me.txtb_Diferencias.Name = "txtb_Diferencias"
        Me.txtb_Diferencias.ReadOnly = True
        Me.txtb_Diferencias.Size = New System.Drawing.Size(221, 28)
        Me.txtb_Diferencias.TabIndex = 73
        Me.txtb_Diferencias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(660, 561)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(137, 24)
        Me.Label17.TabIndex = 72
        Me.Label17.Text = "DIFERENCIA ₵"
        '
        'txtb_Ruta
        '
        Me.txtb_Ruta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_Ruta.BackColor = System.Drawing.Color.White
        Me.txtb_Ruta.Location = New System.Drawing.Point(533, 119)
        Me.txtb_Ruta.Name = "txtb_Ruta"
        Me.txtb_Ruta.ReadOnly = True
        Me.txtb_Ruta.Size = New System.Drawing.Size(497, 20)
        Me.txtb_Ruta.TabIndex = 9
        '
        'Button9
        '
        Me.Button9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.Location = New System.Drawing.Point(533, 145)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(30, 29)
        Me.Button9.TabIndex = 11
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(573, 144)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(31, 29)
        Me.Button1.TabIndex = 84
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_Cargar
        '
        Me.btn_Cargar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cargar.Location = New System.Drawing.Point(945, 61)
        Me.btn_Cargar.Name = "btn_Cargar"
        Me.btn_Cargar.Size = New System.Drawing.Size(85, 52)
        Me.btn_Cargar.TabIndex = 10
        Me.btn_Cargar.Text = "CARGAR"
        Me.btn_Cargar.UseVisualStyleBackColor = True
        '
        'btn_BuscaLiquidacion
        '
        Me.btn_BuscaLiquidacion.Image = CType(resources.GetObject("btn_BuscaLiquidacion.Image"), System.Drawing.Image)
        Me.btn_BuscaLiquidacion.Location = New System.Drawing.Point(212, 52)
        Me.btn_BuscaLiquidacion.Name = "btn_BuscaLiquidacion"
        Me.btn_BuscaLiquidacion.Size = New System.Drawing.Size(32, 24)
        Me.btn_BuscaLiquidacion.TabIndex = 1
        Me.btn_BuscaLiquidacion.UseVisualStyleBackColor = True
        '
        'Btn_Atras
        '
        Me.Btn_Atras.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Atras.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Atras.BackgroundImage = CType(resources.GetObject("Btn_Atras.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Atras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Atras.Location = New System.Drawing.Point(863, 4)
        Me.Btn_Atras.Name = "Btn_Atras"
        Me.Btn_Atras.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Atras.TabIndex = 82
        Me.Btn_Atras.UseVisualStyleBackColor = False
        '
        'Btn_Adelante
        '
        Me.Btn_Adelante.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Adelante.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Adelante.BackgroundImage = CType(resources.GetObject("Btn_Adelante.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Adelante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Adelante.Location = New System.Drawing.Point(944, 3)
        Me.Btn_Adelante.Name = "Btn_Adelante"
        Me.Btn_Adelante.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Adelante.TabIndex = 81
        Me.Btn_Adelante.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(4, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(126, 43)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 80
        Me.PictureBox1.TabStop = False
        '
        'btn_BuscaChofer
        '
        Me.btn_BuscaChofer.Image = CType(resources.GetObject("btn_BuscaChofer.Image"), System.Drawing.Image)
        Me.btn_BuscaChofer.Location = New System.Drawing.Point(212, 81)
        Me.btn_BuscaChofer.Name = "btn_BuscaChofer"
        Me.btn_BuscaChofer.Size = New System.Drawing.Size(32, 24)
        Me.btn_BuscaChofer.TabIndex = 3
        Me.btn_BuscaChofer.UseVisualStyleBackColor = True
        '
        'ListV_Reportes
        '
        Me.ListV_Reportes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListV_Reportes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.ListV_Reportes.Location = New System.Drawing.Point(476, 77)
        Me.ListV_Reportes.Name = "ListV_Reportes"
        Me.ListV_Reportes.Size = New System.Drawing.Size(204, 36)
        Me.ListV_Reportes.TabIndex = 93
        Me.ListV_Reportes.UseCompatibleStateImageBehavior = False
        Me.ListV_Reportes.View = System.Windows.Forms.View.List
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "1"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "2"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "3"
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "4"
        '
        'btn_GoReporte
        '
        Me.btn_GoReporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_GoReporte.Image = CType(resources.GetObject("btn_GoReporte.Image"), System.Drawing.Image)
        Me.btn_GoReporte.Location = New System.Drawing.Point(646, 49)
        Me.btn_GoReporte.Name = "btn_GoReporte"
        Me.btn_GoReporte.Size = New System.Drawing.Size(32, 24)
        Me.btn_GoReporte.TabIndex = 94
        Me.btn_GoReporte.UseVisualStyleBackColor = True
        '
        'btn_AddRepFac
        '
        Me.btn_AddRepFac.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_AddRepFac.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AddRepFac.Image = CType(resources.GetObject("btn_AddRepFac.Image"), System.Drawing.Image)
        Me.btn_AddRepFac.Location = New System.Drawing.Point(476, 48)
        Me.btn_AddRepFac.Name = "btn_AddRepFac"
        Me.btn_AddRepFac.Size = New System.Drawing.Size(30, 29)
        Me.btn_AddRepFac.TabIndex = 95
        Me.btn_AddRepFac.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_AddRepFac.UseVisualStyleBackColor = True
        '
        'btn_QuitaRepFActuras
        '
        Me.btn_QuitaRepFActuras.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_QuitaRepFActuras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_QuitaRepFActuras.Image = CType(resources.GetObject("btn_QuitaRepFActuras.Image"), System.Drawing.Image)
        Me.btn_QuitaRepFActuras.Location = New System.Drawing.Point(505, 47)
        Me.btn_QuitaRepFActuras.Name = "btn_QuitaRepFActuras"
        Me.btn_QuitaRepFActuras.Size = New System.Drawing.Size(31, 29)
        Me.btn_QuitaRepFActuras.TabIndex = 96
        Me.btn_QuitaRepFActuras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_QuitaRepFActuras.UseVisualStyleBackColor = True
        '
        'Liquidacion_Choferes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1038, 604)
        Me.Controls.Add(Me.btn_AddRepFac)
        Me.Controls.Add(Me.btn_QuitaRepFActuras)
        Me.Controls.Add(Me.btn_GoReporte)
        Me.Controls.Add(Me.ListV_Reportes)
        Me.Controls.Add(Me.ListView_Agentes)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtb_Ruta)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.dtp_FechaFin_Recibos)
        Me.Controls.Add(Me.dtp_FechaIni_Recibos)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.btn_Cargar)
        Me.Controls.Add(Me.btn_BuscaLiquidacion)
        Me.Controls.Add(Me.Btn_Atras)
        Me.Controls.Add(Me.Btn_Adelante)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btn_Imprimir)
        Me.Controls.Add(Me.btn_Buscar)
        Me.Controls.Add(Me.btn_Anular)
        Me.Controls.Add(Me.btn_Guardar)
        Me.Controls.Add(Me.btn_Nuevo)
        Me.Controls.Add(Me.txtb_Diferencias)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.lbl_Anulado)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtb_Cedula)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btn_BuscaChofer)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txt_NombreChofer)
        Me.Controls.Add(Me.lbl_titulo)
        Me.Controls.Add(Me.dtp_FechaLiquidacion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_CodChofer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtb_Consecutivo)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1054, 644)
        Me.Name = "Liquidacion_Choferes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liquidacion"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_Facturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dgv_Depositos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgv_Recibos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtb_Consecutivo As System.Windows.Forms.TextBox
    Friend WithEvents txt_CodChofer As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtp_FechaLiquidacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_titulo As System.Windows.Forms.Label
    Friend WithEvents txt_NombreChofer As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btn_BuscaChofer As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtb_TotalDepositos As System.Windows.Forms.TextBox
    Friend WithEvents dgv_Depositos As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtb_TotalRecibos As System.Windows.Forms.TextBox
    Friend WithEvents dgv_Recibos As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtb_TotalGastos As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtb_Comentarios As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents btn_AgregaOtros As System.Windows.Forms.Button
    Friend WithEvents btn_Agrega_Imprevistos As System.Windows.Forms.Button
    Friend WithEvents btn_AgregaHospedaje As System.Windows.Forms.Button
    Friend WithEvents btn_AgregaCombustibles As System.Windows.Forms.Button
    Friend WithEvents btn_AgregaViaticos As System.Windows.Forms.Button
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
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtb_Cedula As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Anulado As System.Windows.Forms.Label
    Friend WithEvents btn_Cargar As System.Windows.Forms.Button
    Friend WithEvents btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents btn_Buscar As System.Windows.Forms.Button
    Friend WithEvents btn_Anular As System.Windows.Forms.Button
    Friend WithEvents btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents txtb_Diferencias As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Btn_Atras As System.Windows.Forms.Button
    Friend WithEvents Btn_Adelante As System.Windows.Forms.Button
    Friend WithEvents btn_BuscaLiquidacion As System.Windows.Forms.Button
    Friend WithEvents ListView_Agentes As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtb_Ruta As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtb_TotalFacturas As System.Windows.Forms.TextBox
    Friend WithEvents dgv_Facturas As System.Windows.Forms.DataGridView
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents dtp_FechaIni_Recibos As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents dtp_FechaFin_Recibos As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_AddDeposito As System.Windows.Forms.Button
    Friend WithEvents dtp_FechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_FechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbx_Rutas As System.Windows.Forms.ComboBox
    Friend WithEvents Txtb_TotalSaldo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_AddRecibos As System.Windows.Forms.Button
    Friend WithEvents ListV_Reportes As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn_GoReporte As System.Windows.Forms.Button
    Friend WithEvents btn_AddRepFac As System.Windows.Forms.Button
    Friend WithEvents btn_QuitaRepFActuras As System.Windows.Forms.Button

End Class
