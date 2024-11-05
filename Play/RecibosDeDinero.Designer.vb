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
        Me.txtb_TotalDocumento = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txtb_MontoEfectivo = New System.Windows.Forms.TextBox()
        Me.Btn_BuscarCuentaEfectivo = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txtb_CuentaContableEfectivo = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.CBox_BancoCheque = New System.Windows.Forms.ComboBox()
        Me.Btn_BuscarCuentaCheque = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txtb_NumeroCheque = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Txtb_MontoCheque = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Txtb_CuentaContableCheque = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.CBox_BancoTranferencia = New System.Windows.Forms.ComboBox()
        Me.Btn_BuscarCuentaTranferencia = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        CType(Me.DGV_DetalleFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
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
        Me.DGV_DetalleFactura.Location = New System.Drawing.Point(4, 4)
        Me.DGV_DetalleFactura.Margin = New System.Windows.Forms.Padding(4)
        Me.DGV_DetalleFactura.Name = "DGV_DetalleFactura"
        Me.DGV_DetalleFactura.Size = New System.Drawing.Size(1261, 224)
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
        'txtb_TotalDocumento
        '
        Me.txtb_TotalDocumento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_TotalDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalDocumento.Location = New System.Drawing.Point(1098, 545)
        Me.txtb_TotalDocumento.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_TotalDocumento.Name = "txtb_TotalDocumento"
        Me.txtb_TotalDocumento.Size = New System.Drawing.Size(198, 26)
        Me.txtb_TotalDocumento.TabIndex = 165
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(902, 548)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 20)
        Me.Label14.TabIndex = 164
        Me.Label14.Text = "Total"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(27, 166)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1277, 261)
        Me.TabControl1.TabIndex = 169
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.DGV_DetalleFactura)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1269, 232)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Documentos"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Txtb_MontoEfectivo)
        Me.TabPage1.Controls.Add(Me.Btn_BuscarCuentaEfectivo)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Txtb_CuentaContableEfectivo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1269, 232)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Efectivo"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Monto Efectivo"
        '
        'Txtb_MontoEfectivo
        '
        Me.Txtb_MontoEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_MontoEfectivo.Location = New System.Drawing.Point(156, 70)
        Me.Txtb_MontoEfectivo.Name = "Txtb_MontoEfectivo"
        Me.Txtb_MontoEfectivo.Size = New System.Drawing.Size(220, 27)
        Me.Txtb_MontoEfectivo.TabIndex = 3
        '
        'Btn_BuscarCuentaEfectivo
        '
        Me.Btn_BuscarCuentaEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_BuscarCuentaEfectivo.Location = New System.Drawing.Point(393, 17)
        Me.Btn_BuscarCuentaEfectivo.Name = "Btn_BuscarCuentaEfectivo"
        Me.Btn_BuscarCuentaEfectivo.Size = New System.Drawing.Size(75, 34)
        Me.Btn_BuscarCuentaEfectivo.TabIndex = 2
        Me.Btn_BuscarCuentaEfectivo.Text = "Buscar"
        Me.Btn_BuscarCuentaEfectivo.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(133, 20)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Cuenta Contable"
        '
        'Txtb_CuentaContableEfectivo
        '
        Me.Txtb_CuentaContableEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_CuentaContableEfectivo.Location = New System.Drawing.Point(156, 21)
        Me.Txtb_CuentaContableEfectivo.Name = "Txtb_CuentaContableEfectivo"
        Me.Txtb_CuentaContableEfectivo.Size = New System.Drawing.Size(220, 27)
        Me.Txtb_CuentaContableEfectivo.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.CBox_BancoCheque)
        Me.TabPage2.Controls.Add(Me.Btn_BuscarCuentaCheque)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Txtb_NumeroCheque)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.Txtb_MontoCheque)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.Txtb_CuentaContableCheque)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1269, 243)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Cheque"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'CBox_BancoCheque
        '
        Me.CBox_BancoCheque.FormattingEnabled = True
        Me.CBox_BancoCheque.Location = New System.Drawing.Point(169, 180)
        Me.CBox_BancoCheque.Name = "CBox_BancoCheque"
        Me.CBox_BancoCheque.Size = New System.Drawing.Size(220, 24)
        Me.CBox_BancoCheque.TabIndex = 23
        '
        'Btn_BuscarCuentaCheque
        '
        Me.Btn_BuscarCuentaCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_BuscarCuentaCheque.Location = New System.Drawing.Point(406, 19)
        Me.Btn_BuscarCuentaCheque.Name = "Btn_BuscarCuentaCheque"
        Me.Btn_BuscarCuentaCheque.Size = New System.Drawing.Size(75, 34)
        Me.Btn_BuscarCuentaCheque.TabIndex = 13
        Me.Btn_BuscarCuentaCheque.Text = "Buscar"
        Me.Btn_BuscarCuentaCheque.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(19, 184)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(119, 20)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Banco Cheque"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(19, 128)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 20)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Numero Cheque"
        '
        'Txtb_NumeroCheque
        '
        Me.Txtb_NumeroCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_NumeroCheque.Location = New System.Drawing.Point(169, 125)
        Me.Txtb_NumeroCheque.Name = "Txtb_NumeroCheque"
        Me.Txtb_NumeroCheque.Size = New System.Drawing.Size(220, 27)
        Me.Txtb_NumeroCheque.TabIndex = 9
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(19, 71)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(117, 20)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Monto Cheque"
        '
        'Txtb_MontoCheque
        '
        Me.Txtb_MontoCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_MontoCheque.Location = New System.Drawing.Point(169, 68)
        Me.Txtb_MontoCheque.Name = "Txtb_MontoCheque"
        Me.Txtb_MontoCheque.Size = New System.Drawing.Size(220, 27)
        Me.Txtb_MontoCheque.TabIndex = 7
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(19, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(133, 20)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Cuenta Contable"
        '
        'Txtb_CuentaContableCheque
        '
        Me.Txtb_CuentaContableCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_CuentaContableCheque.Location = New System.Drawing.Point(169, 19)
        Me.Txtb_CuentaContableCheque.Name = "Txtb_CuentaContableCheque"
        Me.Txtb_CuentaContableCheque.Size = New System.Drawing.Size(220, 27)
        Me.Txtb_CuentaContableCheque.TabIndex = 5
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.CBox_BancoTranferencia)
        Me.TabPage3.Controls.Add(Me.Btn_BuscarCuentaTranferencia)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.Label20)
        Me.TabPage3.Controls.Add(Me.TextBox2)
        Me.TabPage3.Controls.Add(Me.Label21)
        Me.TabPage3.Controls.Add(Me.TextBox3)
        Me.TabPage3.Controls.Add(Me.Label22)
        Me.TabPage3.Controls.Add(Me.TextBox4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1269, 243)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Tranferencia"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'CBox_BancoTranferencia
        '
        Me.CBox_BancoTranferencia.FormattingEnabled = True
        Me.CBox_BancoTranferencia.Location = New System.Drawing.Point(204, 184)
        Me.CBox_BancoTranferencia.Name = "CBox_BancoTranferencia"
        Me.CBox_BancoTranferencia.Size = New System.Drawing.Size(220, 24)
        Me.CBox_BancoTranferencia.TabIndex = 22
        '
        'Btn_BuscarCuentaTranferencia
        '
        Me.Btn_BuscarCuentaTranferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_BuscarCuentaTranferencia.Location = New System.Drawing.Point(442, 15)
        Me.Btn_BuscarCuentaTranferencia.Name = "Btn_BuscarCuentaTranferencia"
        Me.Btn_BuscarCuentaTranferencia.Size = New System.Drawing.Size(75, 34)
        Me.Btn_BuscarCuentaTranferencia.TabIndex = 21
        Me.Btn_BuscarCuentaTranferencia.Text = "Buscar"
        Me.Btn_BuscarCuentaTranferencia.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(17, 184)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(156, 20)
        Me.Label18.TabIndex = 20
        Me.Label18.Text = "Banco Tranferencia"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(17, 128)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(167, 20)
        Me.Label20.TabIndex = 18
        Me.Label20.Text = "Numero Tranferencia"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(204, 125)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(220, 27)
        Me.TextBox2.TabIndex = 17
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(17, 71)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(154, 20)
        Me.Label21.TabIndex = 16
        Me.Label21.Text = "Monto Tranferencia"
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(204, 68)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(220, 27)
        Me.TextBox3.TabIndex = 15
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(17, 22)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(133, 20)
        Me.Label22.TabIndex = 14
        Me.Label22.Text = "Cuenta Contable"
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(204, 19)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(220, 27)
        Me.TextBox4.TabIndex = 13
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(902, 93)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(78, 20)
        Me.Label23.TabIndex = 24
        Me.Label23.Text = "Cobrador"
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"", "Cedula Fisica", "Cedula Juridica", "DIMEX", "NITE"})
        Me.ComboBox1.Location = New System.Drawing.Point(1098, 93)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(207, 28)
        Me.ComboBox1.TabIndex = 170
        '
        'RecibosDeDinero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1316, 646)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txtb_TotalDocumento)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.btn_Anular)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.txtb_Comentarios)
        Me.Controls.Add(Me.Label15)
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
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
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
    Friend WithEvents txtb_TotalDocumento As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label2 As Label
    Friend WithEvents Txtb_MontoEfectivo As TextBox
    Friend WithEvents Btn_BuscarCuentaEfectivo As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Txtb_CuentaContableEfectivo As TextBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents CBox_BancoCheque As ComboBox
    Friend WithEvents Btn_BuscarCuentaCheque As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Txtb_NumeroCheque As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Txtb_MontoCheque As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Txtb_CuentaContableCheque As TextBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents CBox_BancoTranferencia As ComboBox
    Friend WithEvents Btn_BuscarCuentaTranferencia As Button
    Friend WithEvents Label18 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents ComboBox1 As ComboBox
End Class
