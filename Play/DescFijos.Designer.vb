<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DescFijos
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
        Me.btn_Nuevo = New System.Windows.Forms.Button
        Me.btn_Guardar = New System.Windows.Forms.Button
        Me.btn_Anular = New System.Windows.Forms.Button
        Me.btn_Buscar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txb_Consecutivo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Cbx_Indefinido = New System.Windows.Forms.CheckBox
        Me.Lbl_Estado = New System.Windows.Forms.Label
        Me.cbx_Marca = New System.Windows.Forms.ComboBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.cbx_Categoria = New System.Windows.Forms.ComboBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.txb_Desc = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txb_NombCliente = New System.Windows.Forms.TextBox
        Me.cbx_familia = New System.Windows.Forms.ComboBox
        Me.txb_CodCliente = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txb_CodArt = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txb_NombArticulo = New System.Windows.Forms.TextBox
        Me.txb_NombProveedor = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txb_CodProveedor = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.DGV_descFijosExepciones = New System.Windows.Forms.DataGridView
        Me.Familia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Categoria = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btn_NuevaExepcion = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.dtp_FechaFin = New System.Windows.Forms.DateTimePicker
        Me.dtp_FechaIni = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV_descFijosExepciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Nuevo
        '
        Me.btn_Nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.69307!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Nuevo.Location = New System.Drawing.Point(15, 557)
        Me.btn_Nuevo.Name = "btn_Nuevo"
        Me.btn_Nuevo.Size = New System.Drawing.Size(90, 43)
        Me.btn_Nuevo.TabIndex = 0
        Me.btn_Nuevo.Text = "Nuevo"
        Me.btn_Nuevo.UseVisualStyleBackColor = True
        '
        'btn_Guardar
        '
        Me.btn_Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.69307!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Guardar.Location = New System.Drawing.Point(112, 557)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(90, 43)
        Me.btn_Guardar.TabIndex = 1
        Me.btn_Guardar.Text = "Guardar"
        Me.btn_Guardar.UseVisualStyleBackColor = True
        '
        'btn_Anular
        '
        Me.btn_Anular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Anular.BackColor = System.Drawing.Color.Red
        Me.btn_Anular.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.69307!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Anular.ForeColor = System.Drawing.SystemColors.Control
        Me.btn_Anular.Location = New System.Drawing.Point(411, 557)
        Me.btn_Anular.Name = "btn_Anular"
        Me.btn_Anular.Size = New System.Drawing.Size(90, 43)
        Me.btn_Anular.TabIndex = 2
        Me.btn_Anular.Text = "Anular"
        Me.btn_Anular.UseVisualStyleBackColor = False
        '
        'btn_Buscar
        '
        Me.btn_Buscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.69307!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Buscar.Location = New System.Drawing.Point(205, 557)
        Me.btn_Buscar.Name = "btn_Buscar"
        Me.btn_Buscar.Size = New System.Drawing.Size(90, 43)
        Me.btn_Buscar.TabIndex = 3
        Me.btn_Buscar.Text = "Buscar"
        Me.btn_Buscar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(703, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Numero"
        '
        'txb_Consecutivo
        '
        Me.txb_Consecutivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txb_Consecutivo.Location = New System.Drawing.Point(761, 12)
        Me.txb_Consecutivo.Name = "txb_Consecutivo"
        Me.txb_Consecutivo.ReadOnly = True
        Me.txb_Consecutivo.Size = New System.Drawing.Size(100, 20)
        Me.txb_Consecutivo.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Inicial"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Final"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dtp_FechaFin)
        Me.GroupBox1.Controls.Add(Me.Cbx_Indefinido)
        Me.GroupBox1.Controls.Add(Me.dtp_FechaIni)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(591, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 116)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Periodo"
        '
        'Cbx_Indefinido
        '
        Me.Cbx_Indefinido.AutoSize = True
        Me.Cbx_Indefinido.Location = New System.Drawing.Point(68, 89)
        Me.Cbx_Indefinido.Name = "Cbx_Indefinido"
        Me.Cbx_Indefinido.Size = New System.Drawing.Size(80, 19)
        Me.Cbx_Indefinido.TabIndex = 10
        Me.Cbx_Indefinido.Text = "Indefinido"
        Me.Cbx_Indefinido.UseVisualStyleBackColor = True
        '
        'Lbl_Estado
        '
        Me.Lbl_Estado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Estado.AutoSize = True
        Me.Lbl_Estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Estado.ForeColor = System.Drawing.Color.Green
        Me.Lbl_Estado.Location = New System.Drawing.Point(662, 167)
        Me.Lbl_Estado.Name = "Lbl_Estado"
        Me.Lbl_Estado.Size = New System.Drawing.Size(119, 30)
        Me.Lbl_Estado.TabIndex = 11
        Me.Lbl_Estado.Text = "ESTADO"
        Me.Lbl_Estado.Visible = False
        '
        'cbx_Marca
        '
        Me.cbx_Marca.FormattingEnabled = True
        Me.cbx_Marca.Location = New System.Drawing.Point(282, 142)
        Me.cbx_Marca.Name = "cbx_Marca"
        Me.cbx_Marca.Size = New System.Drawing.Size(120, 21)
        Me.cbx_Marca.TabIndex = 71
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(282, 121)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(56, 20)
        Me.Label39.TabIndex = 70
        Me.Label39.Text = "Marca"
        '
        'cbx_Categoria
        '
        Me.cbx_Categoria.FormattingEnabled = True
        Me.cbx_Categoria.Location = New System.Drawing.Point(156, 142)
        Me.cbx_Categoria.Name = "cbx_Categoria"
        Me.cbx_Categoria.Size = New System.Drawing.Size(120, 21)
        Me.cbx_Categoria.TabIndex = 69
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(152, 121)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(81, 20)
        Me.Label38.TabIndex = 68
        Me.Label38.Text = "Categoria"
        '
        'txb_Desc
        '
        Me.txb_Desc.Location = New System.Drawing.Point(156, 233)
        Me.txb_Desc.Name = "txb_Desc"
        Me.txb_Desc.Size = New System.Drawing.Size(100, 20)
        Me.txb_Desc.TabIndex = 66
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(16, 233)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(110, 20)
        Me.Label18.TabIndex = 67
        Me.Label18.Text = "% Descuento"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(152, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 20)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Nombre Cliente"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 20)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Cod Cliente"
        '
        'txb_NombCliente
        '
        Me.txb_NombCliente.Location = New System.Drawing.Point(156, 41)
        Me.txb_NombCliente.Name = "txb_NombCliente"
        Me.txb_NombCliente.Size = New System.Drawing.Size(380, 20)
        Me.txb_NombCliente.TabIndex = 53
        '
        'cbx_familia
        '
        Me.cbx_familia.FormattingEnabled = True
        Me.cbx_familia.Location = New System.Drawing.Point(20, 145)
        Me.cbx_familia.Name = "cbx_familia"
        Me.cbx_familia.Size = New System.Drawing.Size(116, 21)
        Me.cbx_familia.TabIndex = 65
        '
        'txb_CodCliente
        '
        Me.txb_CodCliente.Location = New System.Drawing.Point(20, 41)
        Me.txb_CodCliente.Name = "txb_CodCliente"
        Me.txb_CodCliente.Size = New System.Drawing.Size(116, 20)
        Me.txb_CodCliente.TabIndex = 52
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(16, 124)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(63, 20)
        Me.Label17.TabIndex = 64
        Me.Label17.Text = "Familia"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(152, 73)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(149, 20)
        Me.Label14.TabIndex = 58
        Me.Label14.Text = "Nombre Proveedor"
        '
        'txb_CodArt
        '
        Me.txb_CodArt.Location = New System.Drawing.Point(20, 198)
        Me.txb_CodArt.Name = "txb_CodArt"
        Me.txb_CodArt.Size = New System.Drawing.Size(116, 20)
        Me.txb_CodArt.TabIndex = 60
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 20)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "Cod Proveedor"
        '
        'txb_NombArticulo
        '
        Me.txb_NombArticulo.Location = New System.Drawing.Point(156, 198)
        Me.txb_NombArticulo.Name = "txb_NombArticulo"
        Me.txb_NombArticulo.Size = New System.Drawing.Size(380, 20)
        Me.txb_NombArticulo.TabIndex = 61
        '
        'txb_NombProveedor
        '
        Me.txb_NombProveedor.Location = New System.Drawing.Point(156, 95)
        Me.txb_NombProveedor.Name = "txb_NombProveedor"
        Me.txb_NombProveedor.Size = New System.Drawing.Size(380, 20)
        Me.txb_NombProveedor.TabIndex = 57
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(16, 175)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 20)
        Me.Label15.TabIndex = 63
        Me.Label15.Text = "Cod Articulo"
        '
        'txb_CodProveedor
        '
        Me.txb_CodProveedor.Location = New System.Drawing.Point(20, 96)
        Me.txb_CodProveedor.Name = "txb_CodProveedor"
        Me.txb_CodProveedor.Size = New System.Drawing.Size(116, 20)
        Me.txb_CodProveedor.TabIndex = 56
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(152, 175)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(130, 20)
        Me.Label16.TabIndex = 62
        Me.Label16.Text = "Nombre Articulo"
        '
        'DGV_descFijosExepciones
        '
        Me.DGV_descFijosExepciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_descFijosExepciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_descFijosExepciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Familia, Me.Categoria})
        Me.DGV_descFijosExepciones.Location = New System.Drawing.Point(4, 19)
        Me.DGV_descFijosExepciones.Name = "DGV_descFijosExepciones"
        Me.DGV_descFijosExepciones.Size = New System.Drawing.Size(841, 203)
        Me.DGV_descFijosExepciones.TabIndex = 72
        '
        'Familia
        '
        Me.Familia.DataPropertyName = "Familia"
        Me.Familia.HeaderText = "Familia"
        Me.Familia.Name = "Familia"
        '
        'Categoria
        '
        Me.Categoria.DataPropertyName = "Categoria"
        Me.Categoria.HeaderText = "Categoria"
        Me.Categoria.Name = "Categoria"
        '
        'btn_NuevaExepcion
        '
        Me.btn_NuevaExepcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_NuevaExepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.69307!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_NuevaExepcion.Location = New System.Drawing.Point(702, 228)
        Me.btn_NuevaExepcion.Name = "btn_NuevaExepcion"
        Me.btn_NuevaExepcion.Size = New System.Drawing.Size(90, 43)
        Me.btn_NuevaExepcion.TabIndex = 73
        Me.btn_NuevaExepcion.Text = "Nueva"
        Me.btn_NuevaExepcion.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GroupBox2.Controls.Add(Me.DGV_descFijosExepciones)
        Me.GroupBox2.Controls.Add(Me.btn_NuevaExepcion)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 271)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(857, 280)
        Me.GroupBox2.TabIndex = 74
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lista de Excepciones"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        'Me.Button1.Image = Global.SincroCliente.My.Resources.Resources.lupa3
        Me.Button1.Location = New System.Drawing.Point(542, 94)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 20)
        Me.Button1.TabIndex = 75
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        'Me.Button2.Image = Global.SincroCliente.My.Resources.Resources.lupa3
        Me.Button2.Location = New System.Drawing.Point(542, 38)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 20)
        Me.Button2.TabIndex = 76
        Me.Button2.UseVisualStyleBackColor = False
        '
        'dtp_FechaFin
        '
        Me.dtp_FechaFin.Location = New System.Drawing.Point(68, 55)
        Me.dtp_FechaFin.Name = "dtp_FechaFin"
        Me.dtp_FechaFin.Size = New System.Drawing.Size(200, 20)
        Me.dtp_FechaFin.TabIndex = 78
        '
        'dtp_FechaIni
        '
        Me.dtp_FechaIni.Location = New System.Drawing.Point(68, 26)
        Me.dtp_FechaIni.Name = "dtp_FechaIni"
        Me.dtp_FechaIni.Size = New System.Drawing.Size(200, 20)
        Me.dtp_FechaIni.TabIndex = 77
        '
        'DescFijos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(883, 610)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cbx_Marca)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.cbx_Categoria)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.txb_Desc)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txb_NombCliente)
        Me.Controls.Add(Me.cbx_familia)
        Me.Controls.Add(Me.txb_CodCliente)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txb_CodArt)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txb_NombArticulo)
        Me.Controls.Add(Me.txb_NombProveedor)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txb_CodProveedor)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Lbl_Estado)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txb_Consecutivo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Buscar)
        Me.Controls.Add(Me.btn_Anular)
        Me.Controls.Add(Me.btn_Guardar)
        Me.Controls.Add(Me.btn_Nuevo)
        Me.Name = "DescFijos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DESCUENTOS FIJOS POR CLIENTE"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV_descFijosExepciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents btn_Anular As System.Windows.Forms.Button
    Friend WithEvents btn_Buscar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txb_Consecutivo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Cbx_Indefinido As System.Windows.Forms.CheckBox
    Friend WithEvents Lbl_Estado As System.Windows.Forms.Label
    Friend WithEvents cbx_Marca As System.Windows.Forms.ComboBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents cbx_Categoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txb_Desc As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txb_NombCliente As System.Windows.Forms.TextBox
    Friend WithEvents cbx_familia As System.Windows.Forms.ComboBox
    Friend WithEvents txb_CodCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txb_CodArt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txb_NombArticulo As System.Windows.Forms.TextBox
    Friend WithEvents txb_NombProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txb_CodProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DGV_descFijosExepciones As System.Windows.Forms.DataGridView
    Friend WithEvents Familia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Categoria As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_NuevaExepcion As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents dtp_FechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_FechaIni As System.Windows.Forms.DateTimePicker
End Class
