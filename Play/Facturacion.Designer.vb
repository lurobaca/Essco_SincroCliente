<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Facturacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.DTP_TransaccionHasta = New System.Windows.Forms.DateTimePicker()
        Me.DTP_TransaccionDesde = New System.Windows.Forms.DateTimePicker()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CBox_TipoProducto = New System.Windows.Forms.ComboBox()
        Me.txtb_Consecutivo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtb_CodCliente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtb_Nombre = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtb_NombreFantacia = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtb_DocReferencia = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtb_Impreso = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CBox_Estado = New System.Windows.Forms.ComboBox()
        Me.txtb_Comentarios = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtb_TotalExento = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtb_TotalGravado = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtb_TotalDescuento = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtb_TotalImpuestoNeto = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtb_SubTotal = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtb_TotalDocumento = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtb_TotalSaldo = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtb_DiasRestantes = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DGV_DetalleFactura = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtb_EstadoHacienda = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtb_RespuestaHacienda = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtb_clave = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CBox_Vendedor = New System.Windows.Forms.ComboBox()
        Me.CBox_TipoDocumento = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.btn_Anular = New System.Windows.Forms.Button()
        Me.btn_BuscarClientes = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.CBox_TipoVenta = New System.Windows.Forms.ComboBox()
        Me.Txtb_plazoCredito = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.Txtb_DocNum = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtb_Cedula = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.CBox_TipoCed = New System.Windows.Forms.ComboBox()
        Me.lbl_Anulada = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Cmb_Moneda = New System.Windows.Forms.ComboBox()
        Me.txtb_TipoCambio = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtb_TotalImpuestoExonerado = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        CType(Me.DGV_DetalleFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(941, 117)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(172, 20)
        Me.Label20.TabIndex = 49
        Me.Label20.Text = "Fecha de vencimiento"
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(943, 80)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(169, 20)
        Me.Label19.TabIndex = 48
        Me.Label19.Text = "Fecha del documento"
        '
        'DTP_TransaccionHasta
        '
        Me.DTP_TransaccionHasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_TransaccionHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_TransaccionHasta.Location = New System.Drawing.Point(1141, 117)
        Me.DTP_TransaccionHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.DTP_TransaccionHasta.Name = "DTP_TransaccionHasta"
        Me.DTP_TransaccionHasta.Size = New System.Drawing.Size(265, 26)
        Me.DTP_TransaccionHasta.TabIndex = 47
        '
        'DTP_TransaccionDesde
        '
        Me.DTP_TransaccionDesde.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_TransaccionDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_TransaccionDesde.Location = New System.Drawing.Point(1141, 80)
        Me.DTP_TransaccionDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.DTP_TransaccionDesde.Name = "DTP_TransaccionDesde"
        Me.DTP_TransaccionDesde.Size = New System.Drawing.Size(265, 26)
        Me.DTP_TransaccionDesde.TabIndex = 46
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Location = New System.Drawing.Point(16, 633)
        Me.btn_guardar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(152, 50)
        Me.btn_guardar.TabIndex = 63
        Me.btn_guardar.Text = "Crear"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 162)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 20)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Clase"
        '
        'CBox_TipoProducto
        '
        Me.CBox_TipoProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBox_TipoProducto.FormattingEnabled = True
        Me.CBox_TipoProducto.Items.AddRange(New Object() {"Articulo", "Servicio"})
        Me.CBox_TipoProducto.Location = New System.Drawing.Point(199, 154)
        Me.CBox_TipoProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.CBox_TipoProducto.Name = "CBox_TipoProducto"
        Me.CBox_TipoProducto.Size = New System.Drawing.Size(173, 28)
        Me.CBox_TipoProducto.TabIndex = 67
        Me.CBox_TipoProducto.Text = "Servicio"
        '
        'txtb_Consecutivo
        '
        Me.txtb_Consecutivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_Consecutivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Consecutivo.Location = New System.Drawing.Point(1141, 47)
        Me.txtb_Consecutivo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Consecutivo.Name = "txtb_Consecutivo"
        Me.txtb_Consecutivo.Size = New System.Drawing.Size(265, 26)
        Me.txtb_Consecutivo.TabIndex = 66
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(943, 47)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 20)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "#Documento"
        '
        'txtb_CodCliente
        '
        Me.txtb_CodCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_CodCliente.Location = New System.Drawing.Point(199, 12)
        Me.txtb_CodCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_CodCliente.Name = "txtb_CodCliente"
        Me.txtb_CodCliente.Size = New System.Drawing.Size(173, 26)
        Me.txtb_CodCliente.TabIndex = 70
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 16)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 20)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Cliente"
        '
        'txtb_Nombre
        '
        Me.txtb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Nombre.Location = New System.Drawing.Point(199, 50)
        Me.txtb_Nombre.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Nombre.Name = "txtb_Nombre"
        Me.txtb_Nombre.Size = New System.Drawing.Size(476, 26)
        Me.txtb_Nombre.TabIndex = 72
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 54)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 20)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "Nombre"
        '
        'txtb_NombreFantacia
        '
        Me.txtb_NombreFantacia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_NombreFantacia.Location = New System.Drawing.Point(199, 82)
        Me.txtb_NombreFantacia.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_NombreFantacia.Name = "txtb_NombreFantacia"
        Me.txtb_NombreFantacia.Size = New System.Drawing.Size(476, 26)
        Me.txtb_NombreFantacia.TabIndex = 74
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 86)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 20)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Nombre de Fantacia"
        '
        'txtb_DocReferencia
        '
        Me.txtb_DocReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_DocReferencia.Location = New System.Drawing.Point(199, 117)
        Me.txtb_DocReferencia.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_DocReferencia.Name = "txtb_DocReferencia"
        Me.txtb_DocReferencia.Size = New System.Drawing.Size(173, 26)
        Me.txtb_DocReferencia.TabIndex = 76
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 119)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(158, 20)
        Me.Label6.TabIndex = 75
        Me.Label6.Text = "#Doc de Referencia"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(723, 80)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 20)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "Impreso"
        Me.Label7.Visible = False
        '
        'txtb_Impreso
        '
        Me.txtb_Impreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Impreso.Location = New System.Drawing.Point(821, 78)
        Me.txtb_Impreso.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Impreso.Name = "txtb_Impreso"
        Me.txtb_Impreso.Size = New System.Drawing.Size(108, 26)
        Me.txtb_Impreso.TabIndex = 79
        Me.txtb_Impreso.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(723, 121)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 20)
        Me.Label8.TabIndex = 80
        Me.Label8.Text = "Estado"
        Me.Label8.Visible = False
        '
        'CBox_Estado
        '
        Me.CBox_Estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBox_Estado.FormattingEnabled = True
        Me.CBox_Estado.Items.AddRange(New Object() {"Cancelada", "Vencida", "Al Dia"})
        Me.CBox_Estado.Location = New System.Drawing.Point(821, 111)
        Me.CBox_Estado.Margin = New System.Windows.Forms.Padding(4)
        Me.CBox_Estado.Name = "CBox_Estado"
        Me.CBox_Estado.Size = New System.Drawing.Size(108, 28)
        Me.CBox_Estado.TabIndex = 81
        Me.CBox_Estado.Visible = False
        '
        'txtb_Comentarios
        '
        Me.txtb_Comentarios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_Comentarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Comentarios.Location = New System.Drawing.Point(16, 557)
        Me.txtb_Comentarios.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Comentarios.Multiline = True
        Me.txtb_Comentarios.Name = "txtb_Comentarios"
        Me.txtb_Comentarios.Size = New System.Drawing.Size(646, 75)
        Me.txtb_Comentarios.TabIndex = 84
        '
        'Label15
        '
        Me.Label15.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 750)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 20)
        Me.Label15.TabIndex = 83
        Me.Label15.Text = "Comentarios"
        '
        'txtb_TotalExento
        '
        Me.txtb_TotalExento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_TotalExento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalExento.Location = New System.Drawing.Point(1215, 544)
        Me.txtb_TotalExento.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_TotalExento.Name = "txtb_TotalExento"
        Me.txtb_TotalExento.Size = New System.Drawing.Size(193, 26)
        Me.txtb_TotalExento.TabIndex = 92
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1030, 550)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(133, 20)
        Me.Label9.TabIndex = 91
        Me.Label9.Text = "Total IVA Exento"
        '
        'txtb_TotalGravado
        '
        Me.txtb_TotalGravado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_TotalGravado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalGravado.Location = New System.Drawing.Point(1215, 515)
        Me.txtb_TotalGravado.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_TotalGravado.Name = "txtb_TotalGravado"
        Me.txtb_TotalGravado.Size = New System.Drawing.Size(193, 26)
        Me.txtb_TotalGravado.TabIndex = 90
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(1030, 518)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(114, 20)
        Me.Label10.TabIndex = 89
        Me.Label10.Text = "Total Gravado"
        '
        'txtb_TotalDescuento
        '
        Me.txtb_TotalDescuento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_TotalDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalDescuento.Location = New System.Drawing.Point(1215, 486)
        Me.txtb_TotalDescuento.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_TotalDescuento.Name = "txtb_TotalDescuento"
        Me.txtb_TotalDescuento.Size = New System.Drawing.Size(193, 26)
        Me.txtb_TotalDescuento.TabIndex = 88
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(1032, 489)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(141, 20)
        Me.Label11.TabIndex = 87
        Me.Label11.Text = "Monto Descuento"
        '
        'txtb_TotalImpuestoNeto
        '
        Me.txtb_TotalImpuestoNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_TotalImpuestoNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalImpuestoNeto.Location = New System.Drawing.Point(1216, 602)
        Me.txtb_TotalImpuestoNeto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_TotalImpuestoNeto.Name = "txtb_TotalImpuestoNeto"
        Me.txtb_TotalImpuestoNeto.Size = New System.Drawing.Size(193, 26)
        Me.txtb_TotalImpuestoNeto.TabIndex = 86
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(1033, 608)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(168, 20)
        Me.Label12.TabIndex = 85
        Me.Label12.Text = "Monto Impuesto Neto"
        '
        'txtb_SubTotal
        '
        Me.txtb_SubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_SubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_SubTotal.Location = New System.Drawing.Point(1215, 458)
        Me.txtb_SubTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_SubTotal.Name = "txtb_SubTotal"
        Me.txtb_SubTotal.Size = New System.Drawing.Size(193, 26)
        Me.txtb_SubTotal.TabIndex = 94
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(1030, 460)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 20)
        Me.Label13.TabIndex = 93
        Me.Label13.Text = "SubTotal"
        '
        'txtb_TotalDocumento
        '
        Me.txtb_TotalDocumento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_TotalDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalDocumento.Location = New System.Drawing.Point(1218, 630)
        Me.txtb_TotalDocumento.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_TotalDocumento.Name = "txtb_TotalDocumento"
        Me.txtb_TotalDocumento.Size = New System.Drawing.Size(193, 26)
        Me.txtb_TotalDocumento.TabIndex = 96
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(1035, 636)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 20)
        Me.Label14.TabIndex = 95
        Me.Label14.Text = "Total"
        '
        'txtb_TotalSaldo
        '
        Me.txtb_TotalSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_TotalSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalSaldo.Location = New System.Drawing.Point(1218, 659)
        Me.txtb_TotalSaldo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_TotalSaldo.Name = "txtb_TotalSaldo"
        Me.txtb_TotalSaldo.Size = New System.Drawing.Size(193, 26)
        Me.txtb_TotalSaldo.TabIndex = 98
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(1035, 662)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 20)
        Me.Label16.TabIndex = 97
        Me.Label16.Text = "Saldos"
        '
        'txtb_DiasRestantes
        '
        Me.txtb_DiasRestantes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_DiasRestantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_DiasRestantes.Location = New System.Drawing.Point(1323, 154)
        Me.txtb_DiasRestantes.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_DiasRestantes.Name = "txtb_DiasRestantes"
        Me.txtb_DiasRestantes.Size = New System.Drawing.Size(83, 26)
        Me.txtb_DiasRestantes.TabIndex = 100
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(1196, 158)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(119, 20)
        Me.Label17.TabIndex = 99
        Me.Label17.Text = "Dias restantes"
        '
        'DGV_DetalleFactura
        '
        Me.DGV_DetalleFactura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_DetalleFactura.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DGV_DetalleFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_DetalleFactura.Location = New System.Drawing.Point(4, 0)
        Me.DGV_DetalleFactura.Margin = New System.Windows.Forms.Padding(4)
        Me.DGV_DetalleFactura.Name = "DGV_DetalleFactura"
        Me.DGV_DetalleFactura.Size = New System.Drawing.Size(1384, 227)
        Me.DGV_DetalleFactura.TabIndex = 101
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(16, 192)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1399, 264)
        Me.TabControl1.TabIndex = 102
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DGV_DetalleFactura)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(1391, 231)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Contenido"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtb_EstadoHacienda)
        Me.TabPage2.Controls.Add(Me.Label22)
        Me.TabPage2.Controls.Add(Me.txtb_RespuestaHacienda)
        Me.TabPage2.Controls.Add(Me.Label21)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Size = New System.Drawing.Size(1391, 231)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Estado en Hacienda"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtb_EstadoHacienda
        '
        Me.txtb_EstadoHacienda.Location = New System.Drawing.Point(13, 46)
        Me.txtb_EstadoHacienda.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_EstadoHacienda.Name = "txtb_EstadoHacienda"
        Me.txtb_EstadoHacienda.Size = New System.Drawing.Size(193, 26)
        Me.txtb_EstadoHacienda.TabIndex = 88
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(8, 23)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(61, 20)
        Me.Label22.TabIndex = 87
        Me.Label22.Text = "Estado"
        '
        'txtb_RespuestaHacienda
        '
        Me.txtb_RespuestaHacienda.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_RespuestaHacienda.Location = New System.Drawing.Point(8, 111)
        Me.txtb_RespuestaHacienda.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_RespuestaHacienda.Multiline = True
        Me.txtb_RespuestaHacienda.Name = "txtb_RespuestaHacienda"
        Me.txtb_RespuestaHacienda.Size = New System.Drawing.Size(1375, 176)
        Me.txtb_RespuestaHacienda.TabIndex = 86
        '
        'Label21
        '
        Me.Label21.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(9, 74)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(89, 20)
        Me.Label21.TabIndex = 85
        Me.Label21.Text = "Respuesta"
        '
        'txtb_clave
        '
        Me.txtb_clave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_clave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_clave.Location = New System.Drawing.Point(821, 12)
        Me.txtb_clave.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_clave.Name = "txtb_clave"
        Me.txtb_clave.Size = New System.Drawing.Size(583, 26)
        Me.txtb_clave.TabIndex = 104
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(723, 12)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(51, 20)
        Me.Label18.TabIndex = 103
        Me.Label18.Text = "Clave"
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(26, 525)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(80, 20)
        Me.Label23.TabIndex = 106
        Me.Label23.Text = "Vendedor"
        '
        'CBox_Vendedor
        '
        Me.CBox_Vendedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CBox_Vendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBox_Vendedor.FormattingEnabled = True
        Me.CBox_Vendedor.Items.AddRange(New Object() {"Oficina"})
        Me.CBox_Vendedor.Location = New System.Drawing.Point(123, 522)
        Me.CBox_Vendedor.Margin = New System.Windows.Forms.Padding(4)
        Me.CBox_Vendedor.Name = "CBox_Vendedor"
        Me.CBox_Vendedor.Size = New System.Drawing.Size(539, 28)
        Me.CBox_Vendedor.TabIndex = 105
        '
        'CBox_TipoDocumento
        '
        Me.CBox_TipoDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBox_TipoDocumento.FormattingEnabled = True
        Me.CBox_TipoDocumento.Items.AddRange(New Object() {"FE", "TE", "NC", "ND"})
        Me.CBox_TipoDocumento.Location = New System.Drawing.Point(536, 12)
        Me.CBox_TipoDocumento.Margin = New System.Windows.Forms.Padding(4)
        Me.CBox_TipoDocumento.Name = "CBox_TipoDocumento"
        Me.CBox_TipoDocumento.Size = New System.Drawing.Size(73, 28)
        Me.CBox_TipoDocumento.TabIndex = 110
        Me.CBox_TipoDocumento.Text = "FE"
        Me.CBox_TipoDocumento.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(451, 15)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(77, 20)
        Me.Label24.TabIndex = 109
        Me.Label24.Text = "Tipo Doc"
        Me.Label24.Visible = False
        '
        'btn_Anular
        '
        Me.btn_Anular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Anular.Enabled = False
        Me.btn_Anular.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Anular.Location = New System.Drawing.Point(336, 635)
        Me.btn_Anular.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Anular.Name = "btn_Anular"
        Me.btn_Anular.Size = New System.Drawing.Size(152, 50)
        Me.btn_Anular.TabIndex = 111
        Me.btn_Anular.Text = "Anular"
        Me.btn_Anular.UseVisualStyleBackColor = True
        '
        'btn_BuscarClientes
        '
        Me.btn_BuscarClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_BuscarClientes.Location = New System.Drawing.Point(380, 12)
        Me.btn_BuscarClientes.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_BuscarClientes.Name = "btn_BuscarClientes"
        Me.btn_BuscarClientes.Size = New System.Drawing.Size(51, 27)
        Me.btn_BuscarClientes.TabIndex = 112
        Me.btn_BuscarClientes.Text = "IR"
        Me.btn_BuscarClientes.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_BuscarClientes.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(391, 121)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(89, 20)
        Me.Label25.TabIndex = 114
        Me.Label25.Text = "Tipo Venta"
        '
        'CBox_TipoVenta
        '
        Me.CBox_TipoVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBox_TipoVenta.FormattingEnabled = True
        Me.CBox_TipoVenta.Items.AddRange(New Object() {"Contado", "Credito", "Consignacion"})
        Me.CBox_TipoVenta.Location = New System.Drawing.Point(501, 116)
        Me.CBox_TipoVenta.Margin = New System.Windows.Forms.Padding(4)
        Me.CBox_TipoVenta.Name = "CBox_TipoVenta"
        Me.CBox_TipoVenta.Size = New System.Drawing.Size(173, 28)
        Me.CBox_TipoVenta.TabIndex = 113
        Me.CBox_TipoVenta.Text = "Contado"
        '
        'Txtb_plazoCredito
        '
        Me.Txtb_plazoCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_plazoCredito.Location = New System.Drawing.Point(501, 154)
        Me.Txtb_plazoCredito.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_plazoCredito.Name = "Txtb_plazoCredito"
        Me.Txtb_plazoCredito.Size = New System.Drawing.Size(173, 26)
        Me.Txtb_plazoCredito.TabIndex = 116
        Me.Txtb_plazoCredito.Text = "0"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(391, 158)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(103, 20)
        Me.Label26.TabIndex = 115
        Me.Label26.Text = "Dias Credito"
        '
        'btn_buscar
        '
        Me.btn_buscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Location = New System.Drawing.Point(176, 635)
        Me.btn_buscar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(152, 50)
        Me.btn_buscar.TabIndex = 117
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'Txtb_DocNum
        '
        Me.Txtb_DocNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txtb_DocNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_DocNum.Location = New System.Drawing.Point(821, 44)
        Me.Txtb_DocNum.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_DocNum.Name = "Txtb_DocNum"
        Me.Txtb_DocNum.Size = New System.Drawing.Size(108, 26)
        Me.Txtb_DocNum.TabIndex = 119
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(723, 47)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(75, 20)
        Me.Label27.TabIndex = 118
        Me.Label27.Text = "DocNum"
        Me.Label27.Visible = False
        '
        'txtb_Cedula
        '
        Me.txtb_Cedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Cedula.Location = New System.Drawing.Point(1081, 190)
        Me.txtb_Cedula.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Cedula.Name = "txtb_Cedula"
        Me.txtb_Cedula.Size = New System.Drawing.Size(323, 26)
        Me.txtb_Cedula.TabIndex = 123
        Me.txtb_Cedula.Visible = False
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(949, 191)
        Me.Label28.Margin = New System.Windows.Forms.Padding(0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(61, 20)
        Me.Label28.TabIndex = 122
        Me.Label28.Text = "Cedula"
        Me.Label28.Visible = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(717, 191)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(95, 20)
        Me.Label29.TabIndex = 121
        Me.Label29.Text = "Tipo cedula"
        Me.Label29.Visible = False
        '
        'CBox_TipoCed
        '
        Me.CBox_TipoCed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBox_TipoCed.FormattingEnabled = True
        Me.CBox_TipoCed.Items.AddRange(New Object() {"Cedula Fisica", "Cedula Juridica", "DIMEX", "NITE"})
        Me.CBox_TipoCed.Location = New System.Drawing.Point(821, 187)
        Me.CBox_TipoCed.Margin = New System.Windows.Forms.Padding(4)
        Me.CBox_TipoCed.Name = "CBox_TipoCed"
        Me.CBox_TipoCed.Size = New System.Drawing.Size(113, 28)
        Me.CBox_TipoCed.TabIndex = 120
        Me.CBox_TipoCed.Visible = False
        '
        'lbl_Anulada
        '
        Me.lbl_Anulada.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_Anulada.AutoSize = True
        Me.lbl_Anulada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Anulada.ForeColor = System.Drawing.Color.Red
        Me.lbl_Anulada.Location = New System.Drawing.Point(541, 650)
        Me.lbl_Anulada.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Anulada.Name = "lbl_Anulada"
        Me.lbl_Anulada.Size = New System.Drawing.Size(96, 20)
        Me.lbl_Anulada.TabIndex = 124
        Me.lbl_Anulada.Text = "ANULADA"
        Me.lbl_Anulada.Visible = False
        '
        'Label30
        '
        Me.Label30.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(717, 156)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(68, 20)
        Me.Label30.TabIndex = 126
        Me.Label30.Text = "Moneda"
        '
        'Cmb_Moneda
        '
        Me.Cmb_Moneda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmb_Moneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Moneda.FormattingEnabled = True
        Me.Cmb_Moneda.Items.AddRange(New Object() {"COL", "USD"})
        Me.Cmb_Moneda.Location = New System.Drawing.Point(821, 153)
        Me.Cmb_Moneda.Margin = New System.Windows.Forms.Padding(4)
        Me.Cmb_Moneda.Name = "Cmb_Moneda"
        Me.Cmb_Moneda.Size = New System.Drawing.Size(108, 28)
        Me.Cmb_Moneda.TabIndex = 125
        '
        'txtb_TipoCambio
        '
        Me.txtb_TipoCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_TipoCambio.Enabled = False
        Me.txtb_TipoCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TipoCambio.Location = New System.Drawing.Point(1077, 153)
        Me.txtb_TipoCambio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_TipoCambio.MaxLength = 5
        Me.txtb_TipoCambio.Name = "txtb_TipoCambio"
        Me.txtb_TipoCambio.Size = New System.Drawing.Size(108, 26)
        Me.txtb_TipoCambio.TabIndex = 128
        '
        'Label31
        '
        Me.Label31.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(939, 156)
        Me.Label31.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(126, 20)
        Me.Label31.TabIndex = 127
        Me.Label31.Text = "Tipo de Cambio"
        '
        'txtb_TotalImpuestoExonerado
        '
        Me.txtb_TotalImpuestoExonerado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_TotalImpuestoExonerado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_TotalImpuestoExonerado.Location = New System.Drawing.Point(1216, 573)
        Me.txtb_TotalImpuestoExonerado.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_TotalImpuestoExonerado.Name = "txtb_TotalImpuestoExonerado"
        Me.txtb_TotalImpuestoExonerado.Size = New System.Drawing.Size(193, 26)
        Me.txtb_TotalImpuestoExonerado.TabIndex = 130
        '
        'Label32
        '
        Me.Label32.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(1033, 579)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(161, 20)
        Me.Label32.TabIndex = 129
        Me.Label32.Text = "Total IVA Exonerado"
        '
        'Facturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1421, 689)
        Me.Controls.Add(Me.txtb_TotalImpuestoExonerado)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.txtb_TipoCambio)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Cmb_Moneda)
        Me.Controls.Add(Me.lbl_Anulada)
        Me.Controls.Add(Me.txtb_Cedula)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.CBox_TipoCed)
        Me.Controls.Add(Me.Txtb_DocNum)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.Txtb_plazoCredito)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.CBox_TipoVenta)
        Me.Controls.Add(Me.btn_BuscarClientes)
        Me.Controls.Add(Me.btn_Anular)
        Me.Controls.Add(Me.CBox_TipoDocumento)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.CBox_Vendedor)
        Me.Controls.Add(Me.txtb_clave)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txtb_DiasRestantes)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtb_TotalSaldo)
        Me.Controls.Add(Me.Label16)
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
        Me.Controls.Add(Me.txtb_Comentarios)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.CBox_Estado)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtb_Impreso)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtb_DocReferencia)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtb_NombreFantacia)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtb_Nombre)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtb_CodCliente)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CBox_TipoProducto)
        Me.Controls.Add(Me.txtb_Consecutivo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.DTP_TransaccionHasta)
        Me.Controls.Add(Me.DTP_TransaccionDesde)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Facturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturacion"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DGV_DetalleFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents DTP_TransaccionHasta As DateTimePicker
    Friend WithEvents DTP_TransaccionDesde As DateTimePicker
    Friend WithEvents btn_guardar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents CBox_TipoProducto As ComboBox
    Friend WithEvents txtb_Consecutivo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtb_CodCliente As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtb_Nombre As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtb_NombreFantacia As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtb_DocReferencia As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtb_Impreso As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents CBox_Estado As ComboBox
    Friend WithEvents txtb_Comentarios As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtb_TotalExento As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtb_TotalGravado As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtb_TotalDescuento As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtb_TotalImpuestoNeto As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtb_SubTotal As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtb_TotalDocumento As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtb_TotalSaldo As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtb_DiasRestantes As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents DGV_DetalleFactura As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txtb_EstadoHacienda As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtb_RespuestaHacienda As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtb_clave As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents CBox_Vendedor As ComboBox
    Friend WithEvents CBox_TipoDocumento As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents btn_Anular As Button
    Friend WithEvents btn_BuscarClientes As Button
    Friend WithEvents Label25 As Label
    Friend WithEvents CBox_TipoVenta As ComboBox
    Friend WithEvents Txtb_plazoCredito As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents btn_buscar As Button
    Friend WithEvents Txtb_DocNum As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents txtb_Cedula As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents CBox_TipoCed As ComboBox
    Friend WithEvents lbl_Anulada As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Cmb_Moneda As ComboBox
    Friend WithEvents txtb_TipoCambio As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents txtb_TotalImpuestoExonerado As TextBox
    Friend WithEvents Label32 As Label
End Class
