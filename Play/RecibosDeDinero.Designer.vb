<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecibosDeDinero
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
        Me.CBox_TipoCed = New System.Windows.Forms.ComboBox()
        Me.txtb_Cedula = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.btn_BuscarClientes = New System.Windows.Forms.Button()
        Me.txtb_NombreFantacia = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtb_Nombre = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtb_CodCliente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.DTP_TransaccionDesde = New System.Windows.Forms.DateTimePicker()
        Me.txtb_Consecutivo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DGV_DetalleFactura = New System.Windows.Forms.DataGridView()
        Me.txtb_Comentarios = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.btn_Anular = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.txtb_TotalImpuestoExonerado = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtb_TotalDocumento = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtb_SubTotal = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtb_TotalExento = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtb_TotalGravado = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtb_TotalDescuento = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtb_TotalImpuestoNeto = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btn_Pagar = New System.Windows.Forms.Button()
        CType(Me.DGV_DetalleFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CBox_TipoCed
        '
        Me.CBox_TipoCed.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBox_TipoCed.FormattingEnabled = True
        Me.CBox_TipoCed.Items.AddRange(New Object() {"", "Cedula Fisica", "Cedula Juridica", "DIMEX", "NITE"})
        Me.CBox_TipoCed.Location = New System.Drawing.Point(522, 56)
        Me.CBox_TipoCed.Margin = New System.Windows.Forms.Padding(4)
        Me.CBox_TipoCed.Name = "CBox_TipoCed"
        Me.CBox_TipoCed.Size = New System.Drawing.Size(160, 28)
        Me.CBox_TipoCed.TabIndex = 143
        '
        'txtb_Cedula
        '
        Me.txtb_Cedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Cedula.Location = New System.Drawing.Point(206, 58)
        Me.txtb_Cedula.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Cedula.Name = "txtb_Cedula"
        Me.txtb_Cedula.Size = New System.Drawing.Size(173, 26)
        Me.txtb_Cedula.TabIndex = 142
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(23, 58)
        Me.Label41.Margin = New System.Windows.Forms.Padding(0)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(84, 22)
        Me.Label41.TabIndex = 141
        Me.Label41.Text = "Cedula"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(402, 60)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(95, 20)
        Me.Label29.TabIndex = 140
        Me.Label29.Text = "Tipo cedula"
        '
        'btn_BuscarClientes
        '
        Me.btn_BuscarClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_BuscarClientes.Location = New System.Drawing.Point(402, 16)
        Me.btn_BuscarClientes.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_BuscarClientes.Name = "btn_BuscarClientes"
        Me.btn_BuscarClientes.Size = New System.Drawing.Size(51, 27)
        Me.btn_BuscarClientes.TabIndex = 139
        Me.btn_BuscarClientes.Text = "IR"
        Me.btn_BuscarClientes.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_BuscarClientes.UseVisualStyleBackColor = True
        '
        'txtb_NombreFantacia
        '
        Me.txtb_NombreFantacia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_NombreFantacia.Location = New System.Drawing.Point(206, 122)
        Me.txtb_NombreFantacia.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_NombreFantacia.Name = "txtb_NombreFantacia"
        Me.txtb_NombreFantacia.Size = New System.Drawing.Size(476, 26)
        Me.txtb_NombreFantacia.TabIndex = 138
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(23, 126)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 20)
        Me.Label5.TabIndex = 137
        Me.Label5.Text = "Nombre de Fantacia"
        '
        'txtb_Nombre
        '
        Me.txtb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Nombre.Location = New System.Drawing.Point(206, 90)
        Me.txtb_Nombre.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Nombre.Name = "txtb_Nombre"
        Me.txtb_Nombre.Size = New System.Drawing.Size(476, 26)
        Me.txtb_Nombre.TabIndex = 136
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(23, 93)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 20)
        Me.Label4.TabIndex = 135
        Me.Label4.Text = "Nombre"
        '
        'txtb_CodCliente
        '
        Me.txtb_CodCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_CodCliente.Location = New System.Drawing.Point(206, 16)
        Me.txtb_CodCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_CodCliente.Name = "txtb_CodCliente"
        Me.txtb_CodCliente.Size = New System.Drawing.Size(173, 26)
        Me.txtb_CodCliente.TabIndex = 134
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(23, 20)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 20)
        Me.Label3.TabIndex = 133
        Me.Label3.Text = "Cliente"
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(902, 58)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(169, 20)
        Me.Label19.TabIndex = 145
        Me.Label19.Text = "Fecha del documento"
        '
        'DTP_TransaccionDesde
        '
        Me.DTP_TransaccionDesde.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_TransaccionDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_TransaccionDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_TransaccionDesde.Location = New System.Drawing.Point(1098, 58)
        Me.DTP_TransaccionDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.DTP_TransaccionDesde.Name = "DTP_TransaccionDesde"
        Me.DTP_TransaccionDesde.Size = New System.Drawing.Size(206, 26)
        Me.DTP_TransaccionDesde.TabIndex = 144
        '
        'txtb_Consecutivo
        '
        Me.txtb_Consecutivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_Consecutivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Consecutivo.Location = New System.Drawing.Point(1098, 18)
        Me.txtb_Consecutivo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Consecutivo.Name = "txtb_Consecutivo"
        Me.txtb_Consecutivo.Size = New System.Drawing.Size(207, 26)
        Me.txtb_Consecutivo.TabIndex = 147
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(902, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 20)
        Me.Label1.TabIndex = 146
        Me.Label1.Text = "#Documento"
        '
        'DGV_DetalleFactura
        '
        Me.DGV_DetalleFactura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_DetalleFactura.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DGV_DetalleFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_DetalleFactura.Location = New System.Drawing.Point(27, 171)
        Me.DGV_DetalleFactura.Margin = New System.Windows.Forms.Padding(4)
        Me.DGV_DetalleFactura.Name = "DGV_DetalleFactura"
        Me.DGV_DetalleFactura.Size = New System.Drawing.Size(1276, 255)
        Me.DGV_DetalleFactura.TabIndex = 148
        '
        'txtb_Comentarios
        '
        Me.txtb_Comentarios.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtb_Comentarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Comentarios.Location = New System.Drawing.Point(27, 499)
        Me.txtb_Comentarios.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Comentarios.Multiline = True
        Me.txtb_Comentarios.Name = "txtb_Comentarios"
        Me.txtb_Comentarios.Size = New System.Drawing.Size(632, 75)
        Me.txtb_Comentarios.TabIndex = 150
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(25, 466)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 20)
        Me.Label15.TabIndex = 149
        Me.Label15.Text = "Comentarios"
        '
        'btn_buscar
        '
        Me.btn_buscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Location = New System.Drawing.Point(187, 584)
        Me.btn_buscar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(152, 50)
        Me.btn_buscar.TabIndex = 153
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'btn_Anular
        '
        Me.btn_Anular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Anular.Enabled = False
        Me.btn_Anular.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Anular.Location = New System.Drawing.Point(347, 584)
        Me.btn_Anular.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Anular.Name = "btn_Anular"
        Me.btn_Anular.Size = New System.Drawing.Size(152, 50)
        Me.btn_Anular.TabIndex = 152
        Me.btn_Anular.Text = "Anular"
        Me.btn_Anular.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Location = New System.Drawing.Point(27, 582)
        Me.btn_guardar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(152, 50)
        Me.btn_guardar.TabIndex = 151
        Me.btn_guardar.Text = "Crear"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'txtb_TotalImpuestoExonerado
        '
        Me.txtb_TotalImpuestoExonerado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_TotalImpuestoExonerado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalImpuestoExonerado.Location = New System.Drawing.Point(1113, 549)
        Me.txtb_TotalImpuestoExonerado.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_TotalImpuestoExonerado.Name = "txtb_TotalImpuestoExonerado"
        Me.txtb_TotalImpuestoExonerado.Size = New System.Drawing.Size(193, 26)
        Me.txtb_TotalImpuestoExonerado.TabIndex = 167
        '
        'Label32
        '
        Me.Label32.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(930, 555)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(161, 20)
        Me.Label32.TabIndex = 166
        Me.Label32.Text = "Total IVA Exonerado"
        '
        'txtb_TotalDocumento
        '
        Me.txtb_TotalDocumento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_TotalDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalDocumento.Location = New System.Drawing.Point(1113, 609)
        Me.txtb_TotalDocumento.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_TotalDocumento.Name = "txtb_TotalDocumento"
        Me.txtb_TotalDocumento.Size = New System.Drawing.Size(193, 26)
        Me.txtb_TotalDocumento.TabIndex = 165
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(932, 612)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 20)
        Me.Label14.TabIndex = 164
        Me.Label14.Text = "Total"
        '
        'txtb_SubTotal
        '
        Me.txtb_SubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_SubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_SubTotal.Location = New System.Drawing.Point(1112, 434)
        Me.txtb_SubTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_SubTotal.Name = "txtb_SubTotal"
        Me.txtb_SubTotal.Size = New System.Drawing.Size(193, 26)
        Me.txtb_SubTotal.TabIndex = 163
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(927, 436)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 20)
        Me.Label13.TabIndex = 162
        Me.Label13.Text = "SubTotal"
        '
        'txtb_TotalExento
        '
        Me.txtb_TotalExento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_TotalExento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalExento.Location = New System.Drawing.Point(1112, 520)
        Me.txtb_TotalExento.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_TotalExento.Name = "txtb_TotalExento"
        Me.txtb_TotalExento.Size = New System.Drawing.Size(193, 26)
        Me.txtb_TotalExento.TabIndex = 161
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(927, 526)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(133, 20)
        Me.Label9.TabIndex = 160
        Me.Label9.Text = "Total IVA Exento"
        '
        'txtb_TotalGravado
        '
        Me.txtb_TotalGravado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_TotalGravado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalGravado.Location = New System.Drawing.Point(1112, 491)
        Me.txtb_TotalGravado.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_TotalGravado.Name = "txtb_TotalGravado"
        Me.txtb_TotalGravado.Size = New System.Drawing.Size(193, 26)
        Me.txtb_TotalGravado.TabIndex = 159
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(927, 494)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(114, 20)
        Me.Label10.TabIndex = 158
        Me.Label10.Text = "Total Gravado"
        '
        'txtb_TotalDescuento
        '
        Me.txtb_TotalDescuento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_TotalDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalDescuento.Location = New System.Drawing.Point(1112, 462)
        Me.txtb_TotalDescuento.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_TotalDescuento.Name = "txtb_TotalDescuento"
        Me.txtb_TotalDescuento.Size = New System.Drawing.Size(193, 26)
        Me.txtb_TotalDescuento.TabIndex = 157
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(929, 465)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(141, 20)
        Me.Label11.TabIndex = 156
        Me.Label11.Text = "Monto Descuento"
        '
        'txtb_TotalImpuestoNeto
        '
        Me.txtb_TotalImpuestoNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_TotalImpuestoNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalImpuestoNeto.Location = New System.Drawing.Point(1113, 578)
        Me.txtb_TotalImpuestoNeto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_TotalImpuestoNeto.Name = "txtb_TotalImpuestoNeto"
        Me.txtb_TotalImpuestoNeto.Size = New System.Drawing.Size(193, 26)
        Me.txtb_TotalImpuestoNeto.TabIndex = 155
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(930, 584)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(168, 20)
        Me.Label12.TabIndex = 154
        Me.Label12.Text = "Monto Impuesto Neto"
        '
        'btn_Pagar
        '
        Me.btn_Pagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Pagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Pagar.Location = New System.Drawing.Point(507, 582)
        Me.btn_Pagar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Pagar.Name = "btn_Pagar"
        Me.btn_Pagar.Size = New System.Drawing.Size(152, 50)
        Me.btn_Pagar.TabIndex = 168
        Me.btn_Pagar.Text = "Metodo de Pagar"
        Me.btn_Pagar.UseVisualStyleBackColor = True
        '
        'RecibosDeDinero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1316, 646)
        Me.Controls.Add(Me.btn_Pagar)
        Me.Controls.Add(Me.txtb_TotalImpuestoExonerado)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.txtb_TotalDocumento)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtb_SubTotal)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtb_TotalExento)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtb_TotalGravado)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtb_TotalDescuento)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtb_TotalImpuestoNeto)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.btn_Anular)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.txtb_Comentarios)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.DGV_DetalleFactura)
        Me.Controls.Add(Me.txtb_Consecutivo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.DTP_TransaccionDesde)
        Me.Controls.Add(Me.CBox_TipoCed)
        Me.Controls.Add(Me.txtb_Cedula)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.btn_BuscarClientes)
        Me.Controls.Add(Me.txtb_NombreFantacia)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtb_Nombre)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtb_CodCliente)
        Me.Controls.Add(Me.Label3)
        Me.Name = "RecibosDeDinero"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RecibosDeDinero"
        CType(Me.DGV_DetalleFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CBox_TipoCed As ComboBox
    Friend WithEvents txtb_Cedula As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents btn_BuscarClientes As Button
    Friend WithEvents txtb_NombreFantacia As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtb_Nombre As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtb_CodCliente As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents DTP_TransaccionDesde As DateTimePicker
    Friend WithEvents txtb_Consecutivo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DGV_DetalleFactura As DataGridView
    Friend WithEvents txtb_Comentarios As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents btn_buscar As Button
    Friend WithEvents btn_Anular As Button
    Friend WithEvents btn_guardar As Button
    Friend WithEvents txtb_TotalImpuestoExonerado As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents txtb_TotalDocumento As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtb_SubTotal As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtb_TotalExento As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtb_TotalGravado As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtb_TotalDescuento As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtb_TotalImpuestoNeto As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btn_Pagar As Button
End Class
