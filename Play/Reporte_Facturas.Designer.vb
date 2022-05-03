<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reporte_Facturas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reporte_Facturas))
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.btn_GoLiq = New System.Windows.Forms.Button()
        Me.btn_ActualizaLiq = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtb_NumLiq = New System.Windows.Forms.TextBox()
        Me.bar_ProgresSector = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cbx_Chofer = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Btn_Atras = New System.Windows.Forms.Button()
        Me.btn_Imprimir = New System.Windows.Forms.Button()
        Me.Btn_Adelante = New System.Windows.Forms.Button()
        Me.btn_eliminar = New System.Windows.Forms.Button()
        Me.btn_Limpiar = New System.Windows.Forms.Button()
        Me.btn_Buscar = New System.Windows.Forms.Button()
        Me.txb_Numero = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Lbl_Anulado = New System.Windows.Forms.Label()
        Me.btn_GenerarEnviar = New System.Windows.Forms.Button()
        Me.lbl_Total = New System.Windows.Forms.Label()
        Me.Rb_ConBod1 = New System.Windows.Forms.RadioButton()
        Me.Rb_SinBod1 = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp_FechaReporte = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXB_Hora = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtb_Ruta = New System.Windows.Forms.TextBox()
        Me.txtb_FACINI = New System.Windows.Forms.TextBox()
        Me.txtb_FACFIN = New System.Windows.Forms.TextBox()
        Me.Cbx_Rutas = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cbx_Ayuda = New System.Windows.Forms.ComboBox()
        Me.DataGV_RepFacContado = New System.Windows.Forms.DataGridView()
        Me.DataGV_RepFacCredito = New System.Windows.Forms.DataGridView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txb_TotalContado = New System.Windows.Forms.TextBox()
        Me.Txb_TotalCredito = New System.Windows.Forms.TextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Txb_ImpuestoContado = New System.Windows.Forms.TextBox()
        Me.Txb_SubTotalContado = New System.Windows.Forms.TextBox()
        Me.Txb_SubTotalCredito = New System.Windows.Forms.TextBox()
        Me.Txb_ImpuestoCredito = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGV_RepFacContado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGV_RepFacCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.Controls.Add(Me.RadioButton2)
        Me.Panel6.Controls.Add(Me.RadioButton1)
        Me.Panel6.Controls.Add(Me.btn_GoLiq)
        Me.Panel6.Controls.Add(Me.btn_ActualizaLiq)
        Me.Panel6.Controls.Add(Me.Label11)
        Me.Panel6.Controls.Add(Me.txtb_NumLiq)
        Me.Panel6.Controls.Add(Me.bar_ProgresSector)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Controls.Add(Me.Cbx_Chofer)
        Me.Panel6.Controls.Add(Me.Panel1)
        Me.Panel6.Controls.Add(Me.Label4)
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Controls.Add(Me.dtp_FechaReporte)
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Controls.Add(Me.TXB_Hora)
        Me.Panel6.Controls.Add(Me.Label29)
        Me.Panel6.Controls.Add(Me.txtb_Ruta)
        Me.Panel6.Controls.Add(Me.txtb_FACINI)
        Me.Panel6.Controls.Add(Me.txtb_FACFIN)
        Me.Panel6.Location = New System.Drawing.Point(1, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1620, 173)
        Me.Panel6.TabIndex = 8
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(738, 129)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(77, 19)
        Me.RadioButton2.TabIndex = 53
        Me.RadioButton2.Text = "Servidor2"
        Me.RadioButton2.UseVisualStyleBackColor = True
        Me.RadioButton2.Visible = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(645, 129)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(77, 19)
        Me.RadioButton1.TabIndex = 52
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Servidor1"
        Me.RadioButton1.UseVisualStyleBackColor = True
        Me.RadioButton1.Visible = False
        '
        'btn_GoLiq
        '
        Me.btn_GoLiq.Image = CType(resources.GetObject("btn_GoLiq.Image"), System.Drawing.Image)
        Me.btn_GoLiq.Location = New System.Drawing.Point(289, 105)
        Me.btn_GoLiq.Name = "btn_GoLiq"
        Me.btn_GoLiq.Size = New System.Drawing.Size(48, 34)
        Me.btn_GoLiq.TabIndex = 272
        Me.btn_GoLiq.UseVisualStyleBackColor = True
        '
        'btn_ActualizaLiq
        '
        Me.btn_ActualizaLiq.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ActualizaLiq.Image = CType(resources.GetObject("btn_ActualizaLiq.Image"), System.Drawing.Image)
        Me.btn_ActualizaLiq.Location = New System.Drawing.Point(228, 105)
        Me.btn_ActualizaLiq.Name = "btn_ActualizaLiq"
        Me.btn_ActualizaLiq.Size = New System.Drawing.Size(48, 34)
        Me.btn_ActualizaLiq.TabIndex = 271
        Me.btn_ActualizaLiq.Tag = "Actualizar El numero de Liquidacion"
        Me.btn_ActualizaLiq.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(11, 106)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 17)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "#Liq"
        '
        'txtb_NumLiq
        '
        Me.txtb_NumLiq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_NumLiq.Location = New System.Drawing.Point(75, 109)
        Me.txtb_NumLiq.Name = "txtb_NumLiq"
        Me.txtb_NumLiq.Size = New System.Drawing.Size(144, 23)
        Me.txtb_NumLiq.TabIndex = 42
        '
        'bar_ProgresSector
        '
        Me.bar_ProgresSector.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bar_ProgresSector.Location = New System.Drawing.Point(-3, 0)
        Me.bar_ProgresSector.Name = "bar_ProgresSector"
        Me.bar_ProgresSector.Size = New System.Drawing.Size(1136, 10)
        Me.bar_ProgresSector.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 17)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "CHOFER"
        '
        'Cbx_Chofer
        '
        Me.Cbx_Chofer.DropDownHeight = 500
        Me.Cbx_Chofer.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cbx_Chofer.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbx_Chofer.FormattingEnabled = True
        Me.Cbx_Chofer.IntegralHeight = False
        Me.Cbx_Chofer.Location = New System.Drawing.Point(75, 77)
        Me.Cbx_Chofer.Name = "Cbx_Chofer"
        Me.Cbx_Chofer.Size = New System.Drawing.Size(260, 25)
        Me.Cbx_Chofer.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Btn_Atras)
        Me.Panel1.Controls.Add(Me.btn_Imprimir)
        Me.Panel1.Controls.Add(Me.Btn_Adelante)
        Me.Panel1.Controls.Add(Me.btn_eliminar)
        Me.Panel1.Controls.Add(Me.btn_Limpiar)
        Me.Panel1.Controls.Add(Me.btn_Buscar)
        Me.Panel1.Controls.Add(Me.txb_Numero)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Lbl_Anulado)
        Me.Panel1.Controls.Add(Me.btn_GenerarEnviar)
        Me.Panel1.Controls.Add(Me.lbl_Total)
        Me.Panel1.Controls.Add(Me.Rb_ConBod1)
        Me.Panel1.Controls.Add(Me.Rb_SinBod1)
        Me.Panel1.Location = New System.Drawing.Point(646, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(487, 116)
        Me.Panel1.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(316, 78)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(156, 32)
        Me.Button1.TabIndex = 271
        Me.Button1.Text = "Reporte Carga"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Btn_Atras
        '
        Me.Btn_Atras.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Atras.BackgroundImage = CType(resources.GetObject("Btn_Atras.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Atras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Atras.Location = New System.Drawing.Point(316, 28)
        Me.Btn_Atras.Name = "Btn_Atras"
        Me.Btn_Atras.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Atras.TabIndex = 75
        Me.Btn_Atras.UseVisualStyleBackColor = False
        '
        'btn_Imprimir
        '
        Me.btn_Imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Imprimir.Location = New System.Drawing.Point(83, 75)
        Me.btn_Imprimir.Name = "btn_Imprimir"
        Me.btn_Imprimir.Size = New System.Drawing.Size(74, 32)
        Me.btn_Imprimir.TabIndex = 88
        Me.btn_Imprimir.Text = "Imprimir"
        Me.btn_Imprimir.UseVisualStyleBackColor = True
        '
        'Btn_Adelante
        '
        Me.Btn_Adelante.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Adelante.BackgroundImage = CType(resources.GetObject("Btn_Adelante.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Adelante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Adelante.Location = New System.Drawing.Point(397, 27)
        Me.Btn_Adelante.Name = "Btn_Adelante"
        Me.Btn_Adelante.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Adelante.TabIndex = 74
        Me.Btn_Adelante.UseVisualStyleBackColor = False
        '
        'btn_eliminar
        '
        Me.btn_eliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_eliminar.BackColor = System.Drawing.Color.White
        Me.btn_eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_eliminar.ForeColor = System.Drawing.Color.Black
        Me.btn_eliminar.Image = CType(resources.GetObject("btn_eliminar.Image"), System.Drawing.Image)
        Me.btn_eliminar.Location = New System.Drawing.Point(223, 70)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(42, 39)
        Me.btn_eliminar.TabIndex = 90
        Me.btn_eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_eliminar.UseVisualStyleBackColor = False
        '
        'btn_Limpiar
        '
        Me.btn_Limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Limpiar.Location = New System.Drawing.Point(83, 37)
        Me.btn_Limpiar.Name = "btn_Limpiar"
        Me.btn_Limpiar.Size = New System.Drawing.Size(74, 32)
        Me.btn_Limpiar.TabIndex = 27
        Me.btn_Limpiar.Text = "Nuevo"
        Me.btn_Limpiar.UseVisualStyleBackColor = True
        '
        'btn_Buscar
        '
        Me.btn_Buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Buscar.Location = New System.Drawing.Point(3, 75)
        Me.btn_Buscar.Name = "btn_Buscar"
        Me.btn_Buscar.Size = New System.Drawing.Size(74, 32)
        Me.btn_Buscar.TabIndex = 77
        Me.btn_Buscar.Text = "Buscar"
        Me.btn_Buscar.UseVisualStyleBackColor = True
        '
        'txb_Numero
        '
        Me.txb_Numero.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txb_Numero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Numero.Location = New System.Drawing.Point(377, 0)
        Me.txb_Numero.Name = "txb_Numero"
        Me.txb_Numero.ReadOnly = True
        Me.txb_Numero.Size = New System.Drawing.Size(96, 23)
        Me.txb_Numero.TabIndex = 37
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(313, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 17)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Numero"
        '
        'Lbl_Anulado
        '
        Me.Lbl_Anulado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Anulado.AutoSize = True
        Me.Lbl_Anulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Anulado.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Anulado.Location = New System.Drawing.Point(184, 75)
        Me.Lbl_Anulado.Name = "Lbl_Anulado"
        Me.Lbl_Anulado.Size = New System.Drawing.Size(116, 25)
        Me.Lbl_Anulado.TabIndex = 41
        Me.Lbl_Anulado.Text = "ANULADO"
        Me.Lbl_Anulado.Visible = False
        '
        'btn_GenerarEnviar
        '
        Me.btn_GenerarEnviar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_GenerarEnviar.Location = New System.Drawing.Point(3, 37)
        Me.btn_GenerarEnviar.Name = "btn_GenerarEnviar"
        Me.btn_GenerarEnviar.Size = New System.Drawing.Size(74, 32)
        Me.btn_GenerarEnviar.TabIndex = 66
        Me.btn_GenerarEnviar.Text = "Generar"
        Me.btn_GenerarEnviar.UseVisualStyleBackColor = True
        '
        'lbl_Total
        '
        Me.lbl_Total.AutoSize = True
        Me.lbl_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Total.ForeColor = System.Drawing.Color.Red
        Me.lbl_Total.Location = New System.Drawing.Point(3, 8)
        Me.lbl_Total.Name = "lbl_Total"
        Me.lbl_Total.Size = New System.Drawing.Size(148, 25)
        Me.lbl_Total.TabIndex = 13
        Me.lbl_Total.Text = "000,000,000.00"
        '
        'Rb_ConBod1
        '
        Me.Rb_ConBod1.AutoSize = True
        Me.Rb_ConBod1.Location = New System.Drawing.Point(197, 37)
        Me.Rb_ConBod1.Name = "Rb_ConBod1"
        Me.Rb_ConBod1.Size = New System.Drawing.Size(103, 19)
        Me.Rb_ConBod1.TabIndex = 26
        Me.Rb_ConBod1.Text = "Con Bodega 1"
        Me.Rb_ConBod1.UseVisualStyleBackColor = True
        '
        'Rb_SinBod1
        '
        Me.Rb_SinBod1.AutoSize = True
        Me.Rb_SinBod1.Checked = True
        Me.Rb_SinBod1.Location = New System.Drawing.Point(197, 8)
        Me.Rb_SinBod1.Name = "Rb_SinBod1"
        Me.Rb_SinBod1.Size = New System.Drawing.Size(99, 19)
        Me.Rb_SinBod1.TabIndex = 270
        Me.Rb_SinBod1.TabStop = True
        Me.Rb_SinBod1.Text = "Sin Bodega 1"
        Me.Rb_SinBod1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(339, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 17)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "FINALIZA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 17)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "INICIA"
        '
        'dtp_FechaReporte
        '
        Me.dtp_FechaReporte.Enabled = False
        Me.dtp_FechaReporte.Location = New System.Drawing.Point(412, 76)
        Me.dtp_FechaReporte.Name = "dtp_FechaReporte"
        Me.dtp_FechaReporte.Size = New System.Drawing.Size(223, 20)
        Me.dtp_FechaReporte.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(353, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 17)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "FECHA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(358, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 17)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "HORA"
        '
        'TXB_Hora
        '
        Me.TXB_Hora.Enabled = False
        Me.TXB_Hora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Hora.Location = New System.Drawing.Point(412, 109)
        Me.TXB_Hora.Name = "TXB_Hora"
        Me.TXB_Hora.Size = New System.Drawing.Size(223, 23)
        Me.TXB_Hora.TabIndex = 20
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(6, 22)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(38, 17)
        Me.Label29.TabIndex = 16
        Me.Label29.Text = "Ruta"
        '
        'txtb_Ruta
        '
        Me.txtb_Ruta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtb_Ruta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Ruta.Location = New System.Drawing.Point(75, 20)
        Me.txtb_Ruta.Name = "txtb_Ruta"
        Me.txtb_Ruta.Size = New System.Drawing.Size(560, 23)
        Me.txtb_Ruta.TabIndex = 2
        '
        'txtb_FACINI
        '
        Me.txtb_FACINI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_FACINI.Location = New System.Drawing.Point(75, 50)
        Me.txtb_FACINI.Name = "txtb_FACINI"
        Me.txtb_FACINI.Size = New System.Drawing.Size(258, 23)
        Me.txtb_FACINI.TabIndex = 2
        '
        'txtb_FACFIN
        '
        Me.txtb_FACFIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_FACFIN.Location = New System.Drawing.Point(412, 47)
        Me.txtb_FACFIN.Name = "txtb_FACFIN"
        Me.txtb_FACFIN.Size = New System.Drawing.Size(223, 23)
        Me.txtb_FACFIN.TabIndex = 3
        '
        'Cbx_Rutas
        '
        Me.Cbx_Rutas.DropDownHeight = 500
        Me.Cbx_Rutas.FormattingEnabled = True
        Me.Cbx_Rutas.IntegralHeight = False
        Me.Cbx_Rutas.Location = New System.Drawing.Point(218, 133)
        Me.Cbx_Rutas.Name = "Cbx_Rutas"
        Me.Cbx_Rutas.Size = New System.Drawing.Size(17, 21)
        Me.Cbx_Rutas.TabIndex = 32
        Me.Cbx_Rutas.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(429, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 17)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "AYUDANTE"
        Me.Label6.Visible = False
        '
        'Cbx_Ayuda
        '
        Me.Cbx_Ayuda.DropDownHeight = 500
        Me.Cbx_Ayuda.FormattingEnabled = True
        Me.Cbx_Ayuda.IntegralHeight = False
        Me.Cbx_Ayuda.Location = New System.Drawing.Point(514, 136)
        Me.Cbx_Ayuda.Name = "Cbx_Ayuda"
        Me.Cbx_Ayuda.Size = New System.Drawing.Size(96, 21)
        Me.Cbx_Ayuda.TabIndex = 30
        Me.Cbx_Ayuda.Visible = False
        '
        'DataGV_RepFacContado
        '
        Me.DataGV_RepFacContado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGV_RepFacContado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGV_RepFacContado.Location = New System.Drawing.Point(3, 4)
        Me.DataGV_RepFacContado.Name = "DataGV_RepFacContado"
        Me.DataGV_RepFacContado.Size = New System.Drawing.Size(506, 328)
        Me.DataGV_RepFacContado.TabIndex = 9
        '
        'DataGV_RepFacCredito
        '
        Me.DataGV_RepFacCredito.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGV_RepFacCredito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGV_RepFacCredito.Location = New System.Drawing.Point(3, 4)
        Me.DataGV_RepFacCredito.Name = "DataGV_RepFacCredito"
        Me.DataGV_RepFacCredito.Size = New System.Drawing.Size(606, 328)
        Me.DataGV_RepFacCredito.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1, 506)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 17)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "CONTADO"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(599, 506)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 17)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "CREDITO"
        '
        'Txb_TotalContado
        '
        Me.Txb_TotalContado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Txb_TotalContado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_TotalContado.Location = New System.Drawing.Point(393, 496)
        Me.Txb_TotalContado.Name = "Txb_TotalContado"
        Me.Txb_TotalContado.Size = New System.Drawing.Size(146, 30)
        Me.Txb_TotalContado.TabIndex = 38
        '
        'Txb_TotalCredito
        '
        Me.Txb_TotalCredito.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txb_TotalCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_TotalCredito.Location = New System.Drawing.Point(983, 496)
        Me.Txb_TotalCredito.Name = "Txb_TotalCredito"
        Me.Txb_TotalCredito.Size = New System.Drawing.Size(146, 30)
        Me.Txb_TotalCredito.TabIndex = 40
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(1, 145)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DataGV_RepFacContado)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGV_RepFacCredito)
        Me.SplitContainer1.Size = New System.Drawing.Size(1133, 332)
        Me.SplitContainer1.SplitterDistance = 515
        Me.SplitContainer1.TabIndex = 41
        '
        'Txb_ImpuestoContado
        '
        Me.Txb_ImpuestoContado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Txb_ImpuestoContado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_ImpuestoContado.Location = New System.Drawing.Point(241, 496)
        Me.Txb_ImpuestoContado.Name = "Txb_ImpuestoContado"
        Me.Txb_ImpuestoContado.Size = New System.Drawing.Size(146, 30)
        Me.Txb_ImpuestoContado.TabIndex = 42
        '
        'Txb_SubTotalContado
        '
        Me.Txb_SubTotalContado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Txb_SubTotalContado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_SubTotalContado.Location = New System.Drawing.Point(89, 496)
        Me.Txb_SubTotalContado.Name = "Txb_SubTotalContado"
        Me.Txb_SubTotalContado.Size = New System.Drawing.Size(146, 30)
        Me.Txb_SubTotalContado.TabIndex = 43
        '
        'Txb_SubTotalCredito
        '
        Me.Txb_SubTotalCredito.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txb_SubTotalCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_SubTotalCredito.Location = New System.Drawing.Point(681, 497)
        Me.Txb_SubTotalCredito.Name = "Txb_SubTotalCredito"
        Me.Txb_SubTotalCredito.Size = New System.Drawing.Size(146, 30)
        Me.Txb_SubTotalCredito.TabIndex = 45
        '
        'Txb_ImpuestoCredito
        '
        Me.Txb_ImpuestoCredito.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txb_ImpuestoCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_ImpuestoCredito.Location = New System.Drawing.Point(833, 497)
        Me.Txb_ImpuestoCredito.Name = "Txb_ImpuestoCredito"
        Me.Txb_ImpuestoCredito.Size = New System.Drawing.Size(146, 30)
        Me.Txb_ImpuestoCredito.TabIndex = 44
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(443, 478)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 15)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "Total"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(280, 478)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 15)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "Impuesto"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(135, 478)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 15)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "Sub Total"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(722, 478)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 15)
        Me.Label14.TabIndex = 51
        Me.Label14.Text = "Sub Total"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(867, 478)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 15)
        Me.Label15.TabIndex = 50
        Me.Label15.Text = "Impuesto"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(1030, 478)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(34, 15)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Total"
        '
        'Reporte_Facturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1131, 531)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Txb_SubTotalCredito)
        Me.Controls.Add(Me.Txb_ImpuestoCredito)
        Me.Controls.Add(Me.Txb_SubTotalContado)
        Me.Controls.Add(Me.Txb_ImpuestoContado)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Txb_TotalCredito)
        Me.Controls.Add(Me.Txb_TotalContado)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Cbx_Ayuda)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Cbx_Rutas)
        Me.Name = "Reporte_Facturas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte_Facturas"
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGV_RepFacContado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGV_RepFacCredito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_Buscar As System.Windows.Forms.Button
    Friend WithEvents bar_ProgresSector As System.Windows.Forms.ProgressBar
    Friend WithEvents btn_GenerarEnviar As System.Windows.Forms.Button
    Friend WithEvents Rb_SinBod1 As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_ConBod1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtp_FechaReporte As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXB_Hora As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents lbl_Total As System.Windows.Forms.Label
    Friend WithEvents txtb_FACINI As System.Windows.Forms.TextBox
    Friend WithEvents txtb_FACFIN As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cbx_Ayuda As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cbx_Chofer As System.Windows.Forms.ComboBox
    Friend WithEvents DataGV_RepFacContado As System.Windows.Forms.DataGridView
    Friend WithEvents Cbx_Rutas As System.Windows.Forms.ComboBox
    Friend WithEvents txtb_Ruta As System.Windows.Forms.TextBox
    Friend WithEvents txb_Numero As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DataGV_RepFacCredito As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txb_TotalContado As System.Windows.Forms.TextBox
    Friend WithEvents Txb_TotalCredito As System.Windows.Forms.TextBox
    Friend WithEvents btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Lbl_Anulado As System.Windows.Forms.Label
    Friend WithEvents btn_ActualizaLiq As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtb_NumLiq As System.Windows.Forms.TextBox
    Friend WithEvents btn_GoLiq As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Txb_ImpuestoContado As System.Windows.Forms.TextBox
    Friend WithEvents Txb_SubTotalContado As System.Windows.Forms.TextBox
    Friend WithEvents Txb_SubTotalCredito As System.Windows.Forms.TextBox
    Friend WithEvents Txb_ImpuestoCredito As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Btn_Atras As System.Windows.Forms.Button
    Friend WithEvents Btn_Adelante As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
End Class
