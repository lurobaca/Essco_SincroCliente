<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Devoluciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Devoluciones))
        Me.btn_Guardar = New System.Windows.Forms.Button()
        Me.txtb_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtb_CodCliente = New System.Windows.Forms.TextBox()
        Me.txtb_Nombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtb_Referencia = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtb_CodChofer = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtb_NombreCofer = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtb_Ruta = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Dtg_Devoluciones = New System.Windows.Forms.DataGridView()
        Me.btn_CrearSap = New System.Windows.Forms.Button()
        Me.btn_Buscar = New System.Windows.Forms.Button()
        Me.btn_Anular = New System.Windows.Forms.Button()
        Me.txtb_DocNum = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txb_hora = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Btn_Atras = New System.Windows.Forms.Button()
        Me.Btn_Adelante = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtb_SubTotal = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtb_Desc = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtb_Impuesto = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TXTB_Comentario = New System.Windows.Forms.TextBox()
        Me.txtb_Total = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lbl_devoluciones = New System.Windows.Forms.Label()
        Me.txtb_DocEntry = New System.Windows.Forms.TextBox()
        Me.CBox_Motivo = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CBox_Rutas = New System.Windows.Forms.ComboBox()
        Me.txtb_IdRuta = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        CType(Me.Dtg_Devoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Guardar
        '
        Me.btn_Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Guardar.Location = New System.Drawing.Point(7, 677)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(75, 37)
        Me.btn_Guardar.TabIndex = 0
        Me.btn_Guardar.Text = "Guardar"
        Me.btn_Guardar.UseVisualStyleBackColor = True
        '
        'txtb_Fecha
        '
        Me.txtb_Fecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_Fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Fecha.Location = New System.Drawing.Point(642, 53)
        Me.txtb_Fecha.Name = "txtb_Fecha"
        Me.txtb_Fecha.Size = New System.Drawing.Size(200, 23)
        Me.txtb_Fecha.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Cod Cliente"
        '
        'txtb_CodCliente
        '
        Me.txtb_CodCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_CodCliente.Location = New System.Drawing.Point(102, 28)
        Me.txtb_CodCliente.Name = "txtb_CodCliente"
        Me.txtb_CodCliente.ReadOnly = True
        Me.txtb_CodCliente.Size = New System.Drawing.Size(100, 23)
        Me.txtb_CodCliente.TabIndex = 4
        '
        'txtb_Nombre
        '
        Me.txtb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Nombre.Location = New System.Drawing.Point(274, 28)
        Me.txtb_Nombre.Name = "txtb_Nombre"
        Me.txtb_Nombre.ReadOnly = True
        Me.txtb_Nombre.Size = New System.Drawing.Size(280, 23)
        Me.txtb_Nombre.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(202, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(572, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Fecha"
        '
        'txtb_Referencia
        '
        Me.txtb_Referencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Referencia.Location = New System.Drawing.Point(102, 84)
        Me.txtb_Referencia.Name = "txtb_Referencia"
        Me.txtb_Referencia.Size = New System.Drawing.Size(100, 23)
        Me.txtb_Referencia.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "#Factura"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(572, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "ID Ruta"
        Me.Label6.Visible = False
        '
        'txtb_CodChofer
        '
        Me.txtb_CodChofer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_CodChofer.Location = New System.Drawing.Point(102, 55)
        Me.txtb_CodChofer.Name = "txtb_CodChofer"
        Me.txtb_CodChofer.ReadOnly = True
        Me.txtb_CodChofer.Size = New System.Drawing.Size(100, 23)
        Me.txtb_CodChofer.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(4, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 17)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Cod Empleado"
        '
        'txtb_NombreCofer
        '
        Me.txtb_NombreCofer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_NombreCofer.Location = New System.Drawing.Point(274, 54)
        Me.txtb_NombreCofer.Name = "txtb_NombreCofer"
        Me.txtb_NombreCofer.ReadOnly = True
        Me.txtb_NombreCofer.Size = New System.Drawing.Size(280, 23)
        Me.txtb_NombreCofer.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(202, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 17)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Empleado"
        '
        'txtb_Ruta
        '
        Me.txtb_Ruta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_Ruta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Ruta.Location = New System.Drawing.Point(642, 130)
        Me.txtb_Ruta.Name = "txtb_Ruta"
        Me.txtb_Ruta.ReadOnly = True
        Me.txtb_Ruta.Size = New System.Drawing.Size(200, 23)
        Me.txtb_Ruta.TabIndex = 19
        Me.txtb_Ruta.Visible = False
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(572, 136)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 17)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Ruta"
        Me.Label9.Visible = False
        '
        'Dtg_Devoluciones
        '
        Me.Dtg_Devoluciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dtg_Devoluciones.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Dtg_Devoluciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dtg_Devoluciones.Location = New System.Drawing.Point(7, 168)
        Me.Dtg_Devoluciones.Name = "Dtg_Devoluciones"
        Me.Dtg_Devoluciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Dtg_Devoluciones.Size = New System.Drawing.Size(835, 444)
        Me.Dtg_Devoluciones.TabIndex = 20
        '
        'btn_CrearSap
        '
        Me.btn_CrearSap.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_CrearSap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_CrearSap.Location = New System.Drawing.Point(456, 677)
        Me.btn_CrearSap.Name = "btn_CrearSap"
        Me.btn_CrearSap.Size = New System.Drawing.Size(161, 37)
        Me.btn_CrearSap.TabIndex = 23
        Me.btn_CrearSap.Text = "Crear en SAP"
        Me.btn_CrearSap.UseVisualStyleBackColor = True
        '
        'btn_Buscar
        '
        Me.btn_Buscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Buscar.Location = New System.Drawing.Point(88, 677)
        Me.btn_Buscar.Name = "btn_Buscar"
        Me.btn_Buscar.Size = New System.Drawing.Size(75, 37)
        Me.btn_Buscar.TabIndex = 24
        Me.btn_Buscar.Text = "Buscar"
        Me.btn_Buscar.UseVisualStyleBackColor = True
        '
        'btn_Anular
        '
        Me.btn_Anular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Anular.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Anular.ForeColor = System.Drawing.Color.Red
        Me.btn_Anular.Location = New System.Drawing.Point(214, 677)
        Me.btn_Anular.Name = "btn_Anular"
        Me.btn_Anular.Size = New System.Drawing.Size(75, 37)
        Me.btn_Anular.TabIndex = 25
        Me.btn_Anular.Text = "Anular"
        Me.btn_Anular.UseVisualStyleBackColor = True
        '
        'txtb_DocNum
        '
        Me.txtb_DocNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_DocNum.Location = New System.Drawing.Point(102, 3)
        Me.txtb_DocNum.Name = "txtb_DocNum"
        Me.txtb_DocNum.ReadOnly = True
        Me.txtb_DocNum.Size = New System.Drawing.Size(100, 23)
        Me.txtb_DocNum.TabIndex = 27
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 6)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 17)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Boleta"
        '
        'txb_hora
        '
        Me.txb_hora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txb_hora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_hora.Location = New System.Drawing.Point(642, 80)
        Me.txb_hora.Name = "txb_hora"
        Me.txb_hora.ReadOnly = True
        Me.txb_hora.Size = New System.Drawing.Size(200, 23)
        Me.txb_hora.TabIndex = 29
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(572, 84)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 17)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Hora"
        '
        'Btn_Atras
        '
        Me.Btn_Atras.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Atras.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Atras.BackgroundImage = CType(resources.GetObject("Btn_Atras.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Atras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Atras.Location = New System.Drawing.Point(686, 4)
        Me.Btn_Atras.Name = "Btn_Atras"
        Me.Btn_Atras.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Atras.TabIndex = 85
        Me.Btn_Atras.UseVisualStyleBackColor = False
        '
        'Btn_Adelante
        '
        Me.Btn_Adelante.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Adelante.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Adelante.BackgroundImage = CType(resources.GetObject("Btn_Adelante.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Adelante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Adelante.Location = New System.Drawing.Point(767, 3)
        Me.Btn_Adelante.Name = "Btn_Adelante"
        Me.Btn_Adelante.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Adelante.TabIndex = 84
        Me.Btn_Adelante.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(601, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(75, 44)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 87
        Me.PictureBox1.TabStop = False
        '
        'txtb_SubTotal
        '
        Me.txtb_SubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_SubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_SubTotal.Location = New System.Drawing.Point(706, 618)
        Me.txtb_SubTotal.Name = "txtb_SubTotal"
        Me.txtb_SubTotal.ReadOnly = True
        Me.txtb_SubTotal.Size = New System.Drawing.Size(136, 23)
        Me.txtb_SubTotal.TabIndex = 95
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(629, 621)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 17)
        Me.Label14.TabIndex = 94
        Me.Label14.Text = "SubTotal"
        '
        'txtb_Desc
        '
        Me.txtb_Desc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_Desc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Desc.Location = New System.Drawing.Point(706, 643)
        Me.txtb_Desc.Name = "txtb_Desc"
        Me.txtb_Desc.ReadOnly = True
        Me.txtb_Desc.Size = New System.Drawing.Size(136, 23)
        Me.txtb_Desc.TabIndex = 93
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(629, 646)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 17)
        Me.Label15.TabIndex = 92
        Me.Label15.Text = "Descuento"
        '
        'txtb_Impuesto
        '
        Me.txtb_Impuesto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_Impuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Impuesto.Location = New System.Drawing.Point(706, 668)
        Me.txtb_Impuesto.Name = "txtb_Impuesto"
        Me.txtb_Impuesto.ReadOnly = True
        Me.txtb_Impuesto.Size = New System.Drawing.Size(136, 23)
        Me.txtb_Impuesto.TabIndex = 91
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(629, 671)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 17)
        Me.Label16.TabIndex = 90
        Me.Label16.Text = "Impuesto"
        '
        'TXTB_Comentario
        '
        Me.TXTB_Comentario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TXTB_Comentario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTB_Comentario.Location = New System.Drawing.Point(7, 618)
        Me.TXTB_Comentario.Multiline = True
        Me.TXTB_Comentario.Name = "TXTB_Comentario"
        Me.TXTB_Comentario.Size = New System.Drawing.Size(618, 54)
        Me.TXTB_Comentario.TabIndex = 97
        '
        'txtb_Total
        '
        Me.txtb_Total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Total.Location = New System.Drawing.Point(706, 694)
        Me.txtb_Total.Name = "txtb_Total"
        Me.txtb_Total.ReadOnly = True
        Me.txtb_Total.Size = New System.Drawing.Size(136, 23)
        Me.txtb_Total.TabIndex = 99
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(629, 697)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 17)
        Me.Label18.TabIndex = 98
        Me.Label18.Text = "Total"
        '
        'lbl_devoluciones
        '
        Me.lbl_devoluciones.AutoSize = True
        Me.lbl_devoluciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_devoluciones.Location = New System.Drawing.Point(202, 87)
        Me.lbl_devoluciones.Name = "lbl_devoluciones"
        Me.lbl_devoluciones.Size = New System.Drawing.Size(66, 17)
        Me.lbl_devoluciones.TabIndex = 8
        Me.lbl_devoluciones.Text = "DocEntry"
        '
        'txtb_DocEntry
        '
        Me.txtb_DocEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_DocEntry.Location = New System.Drawing.Point(274, 83)
        Me.txtb_DocEntry.Name = "txtb_DocEntry"
        Me.txtb_DocEntry.ReadOnly = True
        Me.txtb_DocEntry.Size = New System.Drawing.Size(121, 23)
        Me.txtb_DocEntry.TabIndex = 9
        '
        'CBox_Motivo
        '
        Me.CBox_Motivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBox_Motivo.FormattingEnabled = True
        Me.CBox_Motivo.Items.AddRange(New Object() {"Anula Documento de Referencia", "Corrige Monto", "Otros"})
        Me.CBox_Motivo.Location = New System.Drawing.Point(102, 111)
        Me.CBox_Motivo.Name = "CBox_Motivo"
        Me.CBox_Motivo.Size = New System.Drawing.Size(300, 25)
        Me.CBox_Motivo.TabIndex = 100
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(4, 114)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 17)
        Me.Label11.TabIndex = 101
        Me.Label11.Text = "Motivo"
        '
        'CBox_Rutas
        '
        Me.CBox_Rutas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBox_Rutas.FormattingEnabled = True
        Me.CBox_Rutas.Location = New System.Drawing.Point(102, 138)
        Me.CBox_Rutas.Name = "CBox_Rutas"
        Me.CBox_Rutas.Size = New System.Drawing.Size(300, 25)
        Me.CBox_Rutas.TabIndex = 102
        '
        'txtb_IdRuta
        '
        Me.txtb_IdRuta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_IdRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_IdRuta.Location = New System.Drawing.Point(642, 106)
        Me.txtb_IdRuta.Name = "txtb_IdRuta"
        Me.txtb_IdRuta.ReadOnly = True
        Me.txtb_IdRuta.Size = New System.Drawing.Size(200, 23)
        Me.txtb_IdRuta.TabIndex = 13
        Me.txtb_IdRuta.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(4, 144)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 17)
        Me.Label13.TabIndex = 103
        Me.Label13.Text = "Ruta"
        '
        'Devoluciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 718)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.CBox_Rutas)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.CBox_Motivo)
        Me.Controls.Add(Me.txtb_Total)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.TXTB_Comentario)
        Me.Controls.Add(Me.txtb_SubTotal)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtb_Desc)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtb_Impuesto)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Btn_Atras)
        Me.Controls.Add(Me.Btn_Adelante)
        Me.Controls.Add(Me.txb_hora)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtb_DocNum)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btn_Anular)
        Me.Controls.Add(Me.btn_Buscar)
        Me.Controls.Add(Me.btn_CrearSap)
        Me.Controls.Add(Me.Dtg_Devoluciones)
        Me.Controls.Add(Me.txtb_Ruta)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtb_NombreCofer)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtb_CodChofer)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtb_IdRuta)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtb_DocEntry)
        Me.Controls.Add(Me.lbl_devoluciones)
        Me.Controls.Add(Me.txtb_Referencia)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtb_Nombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtb_CodCliente)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtb_Fecha)
        Me.Controls.Add(Me.btn_Guardar)
        Me.MinimumSize = New System.Drawing.Size(860, 758)
        Me.Name = "Devoluciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Devoluciones"
        CType(Me.Dtg_Devoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents txtb_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtb_CodCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtb_Nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtb_Referencia As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtb_CodChofer As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtb_NombreCofer As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtb_Ruta As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Dtg_Devoluciones As System.Windows.Forms.DataGridView
    Friend WithEvents btn_CrearSap As System.Windows.Forms.Button
    Friend WithEvents btn_Buscar As System.Windows.Forms.Button
    Friend WithEvents btn_Anular As System.Windows.Forms.Button
    Friend WithEvents txtb_DocNum As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txb_hora As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Btn_Atras As System.Windows.Forms.Button
    Friend WithEvents Btn_Adelante As System.Windows.Forms.Button

    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtb_SubTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtb_Desc As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtb_Impuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TXTB_Comentario As System.Windows.Forms.TextBox
    Friend WithEvents txtb_Total As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lbl_devoluciones As Label
    Friend WithEvents txtb_DocEntry As TextBox
    Friend WithEvents CBox_Motivo As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents CBox_Rutas As ComboBox
    Friend WithEvents txtb_IdRuta As TextBox
    Friend WithEvents Label13 As Label
End Class
