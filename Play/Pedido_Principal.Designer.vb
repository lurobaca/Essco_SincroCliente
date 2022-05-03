<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Pedido_Principal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pedido_Principal))
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtb_NombreProveedor = New System.Windows.Forms.TextBox()
        Me.txtb_CodProveedor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_Buscar = New System.Windows.Forms.Button()
        Me.lbl_Total = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_Guardar = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.txtb_DiasProxCamion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtb_PorcRespaldo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtb_CondiconPago = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtb_Email = New System.Windows.Forms.TextBox()
        Me.btn_Nuevo = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl_Inventario = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl_Id = New System.Windows.Forms.Label()
        Me.btn_BuscaAgente = New System.Windows.Forms.Button()
        Me.DTP_FechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.DTP_FechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.RdBtb_Unidades = New System.Windows.Forms.RadioButton()
        Me.RdBtb_Cajas = New System.Windows.Forms.RadioButton()
        Me.Dias = New System.Windows.Forms.Label()
        Me.lbl_TVenta = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DTP_ProyeccionFin = New System.Windows.Forms.DateTimePicker()
        Me.DTP_ProyeccionIni = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Btn_Atras = New System.Windows.Forms.Button()
        Me.Btn_Adelante = New System.Windows.Forms.Button()
        Me.lbl_NumOrden = New System.Windows.Forms.TextBox()
        Me.DTG_DetPedido = New System.Windows.Forms.DataGridView()
        Me.btn_Cargar = New System.Windows.Forms.Button()
        Me.btn_CrearEnSAP = New System.Windows.Forms.Button()
        Me.btn_anular = New System.Windows.Forms.Button()
        Me.lbl_Estado = New System.Windows.Forms.Label()
        Me.txtb_sap = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btn_exportar = New System.Windows.Forms.Button()
        Me.txtb_DiasACubrir = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbl_PedidoEnSAP = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.CBx_ObtieneDatosTeimpoReal = New System.Windows.Forms.CheckBox()
        Me.Btn_VerChequeo = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DTG_DetPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(11, 65)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(58, 17)
        Me.Label19.TabIndex = 57
        Me.Label19.Text = "Nombre"
        '
        'txtb_NombreProveedor
        '
        Me.txtb_NombreProveedor.BackColor = System.Drawing.Color.White
        Me.txtb_NombreProveedor.Location = New System.Drawing.Point(91, 62)
        Me.txtb_NombreProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_NombreProveedor.Name = "txtb_NombreProveedor"
        Me.txtb_NombreProveedor.ReadOnly = True
        Me.txtb_NombreProveedor.Size = New System.Drawing.Size(441, 22)
        Me.txtb_NombreProveedor.TabIndex = 56
        '
        'txtb_CodProveedor
        '
        Me.txtb_CodProveedor.BackColor = System.Drawing.Color.White
        Me.txtb_CodProveedor.Location = New System.Drawing.Point(91, 32)
        Me.txtb_CodProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_CodProveedor.Name = "txtb_CodProveedor"
        Me.txtb_CodProveedor.ReadOnly = True
        Me.txtb_CodProveedor.Size = New System.Drawing.Size(160, 22)
        Me.txtb_CodProveedor.TabIndex = 55
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 38)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Codigo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 123)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 17)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "Estado"
        Me.Label4.Visible = False
        '
        'btn_Buscar
        '
        Me.btn_Buscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Buscar.Enabled = False
        Me.btn_Buscar.Location = New System.Drawing.Point(833, 666)
        Me.btn_Buscar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Buscar.Name = "btn_Buscar"
        Me.btn_Buscar.Size = New System.Drawing.Size(89, 39)
        Me.btn_Buscar.TabIndex = 68
        Me.btn_Buscar.Text = "BUSCAR"
        Me.btn_Buscar.UseVisualStyleBackColor = True
        '
        'lbl_Total
        '
        Me.lbl_Total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_Total.AutoSize = True
        Me.lbl_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Total.ForeColor = System.Drawing.Color.Red
        Me.lbl_Total.Location = New System.Drawing.Point(563, 674)
        Me.lbl_Total.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Total.Name = "lbl_Total"
        Me.lbl_Total.Size = New System.Drawing.Size(42, 26)
        Me.lbl_Total.TabIndex = 69
        Me.lbl_Total.Text = "0.0"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(565, 646)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 17)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "PEDIDO"
        '
        'btn_Guardar
        '
        Me.btn_Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Guardar.Enabled = False
        Me.btn_Guardar.Location = New System.Drawing.Point(926, 666)
        Me.btn_Guardar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(89, 39)
        Me.btn_Guardar.TabIndex = 72
        Me.btn_Guardar.Text = "GUARDAR"
        Me.btn_Guardar.UseVisualStyleBackColor = True
        Me.btn_Guardar.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"CORRECTO", "FALTANTE", "SOBRANTE", "TODO"})
        Me.ComboBox1.Location = New System.Drawing.Point(84, 119)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(160, 24)
        Me.ComboBox1.TabIndex = 73
        Me.ComboBox1.Visible = False
        '
        'txtb_DiasProxCamion
        '
        Me.txtb_DiasProxCamion.BackColor = System.Drawing.Color.White
        Me.txtb_DiasProxCamion.Location = New System.Drawing.Point(445, 116)
        Me.txtb_DiasProxCamion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_DiasProxCamion.Name = "txtb_DiasProxCamion"
        Me.txtb_DiasProxCamion.Size = New System.Drawing.Size(87, 22)
        Me.txtb_DiasProxCamion.TabIndex = 76
        Me.txtb_DiasProxCamion.Text = "1"
        Me.txtb_DiasProxCamion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtb_DiasProxCamion.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(253, 121)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 17)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "Esperando Prox Camion"
        Me.Label3.Visible = False
        '
        'txtb_PorcRespaldo
        '
        Me.txtb_PorcRespaldo.BackColor = System.Drawing.Color.White
        Me.txtb_PorcRespaldo.Location = New System.Drawing.Point(938, 30)
        Me.txtb_PorcRespaldo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_PorcRespaldo.Name = "txtb_PorcRespaldo"
        Me.txtb_PorcRespaldo.Size = New System.Drawing.Size(75, 22)
        Me.txtb_PorcRespaldo.TabIndex = 79
        Me.txtb_PorcRespaldo.Text = "1.0"
        Me.txtb_PorcRespaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtb_PorcRespaldo.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(936, 6)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 17)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "% Colchon"
        Me.Label7.Visible = False
        '
        'txtb_CondiconPago
        '
        Me.txtb_CondiconPago.BackColor = System.Drawing.Color.White
        Me.txtb_CondiconPago.Location = New System.Drawing.Point(428, 32)
        Me.txtb_CondiconPago.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_CondiconPago.Name = "txtb_CondiconPago"
        Me.txtb_CondiconPago.ReadOnly = True
        Me.txtb_CondiconPago.Size = New System.Drawing.Size(104, 22)
        Me.txtb_CondiconPago.TabIndex = 81
        Me.txtb_CondiconPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtb_CondiconPago.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(314, 36)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 17)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Condicion Pago"
        Me.Label1.Visible = False
        '
        'txtb_Email
        '
        Me.txtb_Email.AccessibleDescription = ""
        Me.txtb_Email.AccessibleName = ""
        Me.txtb_Email.BackColor = System.Drawing.Color.White
        Me.txtb_Email.Location = New System.Drawing.Point(8, 21)
        Me.txtb_Email.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Email.Name = "txtb_Email"
        Me.txtb_Email.Size = New System.Drawing.Size(551, 22)
        Me.txtb_Email.TabIndex = 84
        Me.txtb_Email.Tag = ""
        '
        'btn_Nuevo
        '
        Me.btn_Nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Nuevo.Location = New System.Drawing.Point(740, 666)
        Me.btn_Nuevo.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Nuevo.Name = "btn_Nuevo"
        Me.btn_Nuevo.Size = New System.Drawing.Size(89, 39)
        Me.btn_Nuevo.TabIndex = 85
        Me.btn_Nuevo.Text = "NUEVO"
        Me.btn_Nuevo.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 646)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 17)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "INVENTARIO"
        '
        'lbl_Inventario
        '
        Me.lbl_Inventario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_Inventario.AutoSize = True
        Me.lbl_Inventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Inventario.ForeColor = System.Drawing.Color.Red
        Me.lbl_Inventario.Location = New System.Drawing.Point(21, 672)
        Me.lbl_Inventario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Inventario.Name = "lbl_Inventario"
        Me.lbl_Inventario.Size = New System.Drawing.Size(42, 26)
        Me.lbl_Inventario.TabIndex = 86
        Me.lbl_Inventario.Text = "0.0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtb_Email)
        Me.GroupBox1.Location = New System.Drawing.Point(538, 95)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(559, 58)
        Me.GroupBox1.TabIndex = 98
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Destinatarios Email"
        Me.GroupBox1.Visible = False
        '
        'lbl_Id
        '
        Me.lbl_Id.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Id.AutoSize = True
        Me.lbl_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Id.Location = New System.Drawing.Point(1079, 8)
        Me.lbl_Id.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Id.Name = "lbl_Id"
        Me.lbl_Id.Size = New System.Drawing.Size(75, 17)
        Me.lbl_Id.TabIndex = 99
        Me.lbl_Id.Text = "NUMERO"
        '
        'btn_BuscaAgente
        '
        Me.btn_BuscaAgente.Image = Global.SincroCliente.My.Resources.Resources.ir
        Me.btn_BuscaAgente.Location = New System.Drawing.Point(258, 27)
        Me.btn_BuscaAgente.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_BuscaAgente.Name = "btn_BuscaAgente"
        Me.btn_BuscaAgente.Size = New System.Drawing.Size(43, 30)
        Me.btn_BuscaAgente.TabIndex = 58
        Me.btn_BuscaAgente.UseVisualStyleBackColor = True
        '
        'DTP_FechaInicio
        '
        Me.DTP_FechaInicio.Enabled = False
        Me.DTP_FechaInicio.Location = New System.Drawing.Point(538, 28)
        Me.DTP_FechaInicio.Margin = New System.Windows.Forms.Padding(4)
        Me.DTP_FechaInicio.Name = "DTP_FechaInicio"
        Me.DTP_FechaInicio.Size = New System.Drawing.Size(192, 22)
        Me.DTP_FechaInicio.TabIndex = 100
        '
        'DTP_FechaFin
        '
        Me.DTP_FechaFin.Enabled = False
        Me.DTP_FechaFin.Location = New System.Drawing.Point(538, 64)
        Me.DTP_FechaFin.Margin = New System.Windows.Forms.Padding(4)
        Me.DTP_FechaFin.Name = "DTP_FechaFin"
        Me.DTP_FechaFin.Size = New System.Drawing.Size(192, 22)
        Me.DTP_FechaFin.TabIndex = 101
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(349, 91)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 17)
        Me.Label13.TabIndex = 103
        Me.Label13.Text = "Dias Venta:"
        Me.Label13.Visible = False
        '
        'RdBtb_Unidades
        '
        Me.RdBtb_Unidades.AutoSize = True
        Me.RdBtb_Unidades.Checked = True
        Me.RdBtb_Unidades.Enabled = False
        Me.RdBtb_Unidades.Location = New System.Drawing.Point(221, 89)
        Me.RdBtb_Unidades.Margin = New System.Windows.Forms.Padding(4)
        Me.RdBtb_Unidades.Name = "RdBtb_Unidades"
        Me.RdBtb_Unidades.Size = New System.Drawing.Size(89, 21)
        Me.RdBtb_Unidades.TabIndex = 105
        Me.RdBtb_Unidades.TabStop = True
        Me.RdBtb_Unidades.Text = "Unidades"
        Me.RdBtb_Unidades.UseVisualStyleBackColor = True
        '
        'RdBtb_Cajas
        '
        Me.RdBtb_Cajas.AutoSize = True
        Me.RdBtb_Cajas.Enabled = False
        Me.RdBtb_Cajas.Location = New System.Drawing.Point(133, 89)
        Me.RdBtb_Cajas.Margin = New System.Windows.Forms.Padding(4)
        Me.RdBtb_Cajas.Name = "RdBtb_Cajas"
        Me.RdBtb_Cajas.Size = New System.Drawing.Size(64, 21)
        Me.RdBtb_Cajas.TabIndex = 104
        Me.RdBtb_Cajas.Text = "Cajas"
        Me.RdBtb_Cajas.UseVisualStyleBackColor = True
        '
        'Dias
        '
        Me.Dias.AutoSize = True
        Me.Dias.Location = New System.Drawing.Point(462, 89)
        Me.Dias.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Dias.Name = "Dias"
        Me.Dias.Size = New System.Drawing.Size(36, 17)
        Me.Dias.TabIndex = 102
        Me.Dias.Text = "Dias"
        Me.Dias.Visible = False
        '
        'lbl_TVenta
        '
        Me.lbl_TVenta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_TVenta.AutoSize = True
        Me.lbl_TVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TVenta.ForeColor = System.Drawing.Color.Red
        Me.lbl_TVenta.Location = New System.Drawing.Point(308, 673)
        Me.lbl_TVenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_TVenta.Name = "lbl_TVenta"
        Me.lbl_TVenta.Size = New System.Drawing.Size(42, 26)
        Me.lbl_TVenta.TabIndex = 69
        Me.lbl_TVenta.Text = "0.0"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(310, 646)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 17)
        Me.Label15.TabIndex = 70
        Me.Label15.Text = "VENTA"
        '
        'DTP_ProyeccionFin
        '
        Me.DTP_ProyeccionFin.Enabled = False
        Me.DTP_ProyeccionFin.Location = New System.Drawing.Point(738, 65)
        Me.DTP_ProyeccionFin.Margin = New System.Windows.Forms.Padding(4)
        Me.DTP_ProyeccionFin.Name = "DTP_ProyeccionFin"
        Me.DTP_ProyeccionFin.Size = New System.Drawing.Size(192, 22)
        Me.DTP_ProyeccionFin.TabIndex = 107
        Me.DTP_ProyeccionFin.Visible = False
        '
        'DTP_ProyeccionIni
        '
        Me.DTP_ProyeccionIni.Enabled = False
        Me.DTP_ProyeccionIni.Location = New System.Drawing.Point(738, 30)
        Me.DTP_ProyeccionIni.Margin = New System.Windows.Forms.Padding(4)
        Me.DTP_ProyeccionIni.Name = "DTP_ProyeccionIni"
        Me.DTP_ProyeccionIni.Size = New System.Drawing.Size(192, 22)
        Me.DTP_ProyeccionIni.TabIndex = 106
        Me.DTP_ProyeccionIni.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(567, 1)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(124, 25)
        Me.Label14.TabIndex = 108
        Me.Label14.Text = "Fecha Venta"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(757, 1)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(153, 25)
        Me.Label16.TabIndex = 109
        Me.Label16.Text = "Periodo a Cubrir"
        Me.Label16.Visible = False
        '
        'Btn_Atras
        '
        Me.Btn_Atras.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Atras.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Atras.BackgroundImage = CType(resources.GetObject("Btn_Atras.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Atras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Atras.Enabled = False
        Me.Btn_Atras.Location = New System.Drawing.Point(1172, 41)
        Me.Btn_Atras.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Atras.Name = "Btn_Atras"
        Me.Btn_Atras.Size = New System.Drawing.Size(100, 49)
        Me.Btn_Atras.TabIndex = 111
        Me.Btn_Atras.UseVisualStyleBackColor = False
        Me.Btn_Atras.Visible = False
        '
        'Btn_Adelante
        '
        Me.Btn_Adelante.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Adelante.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Adelante.BackgroundImage = CType(resources.GetObject("Btn_Adelante.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Adelante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Adelante.Enabled = False
        Me.Btn_Adelante.Location = New System.Drawing.Point(1280, 38)
        Me.Btn_Adelante.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Adelante.Name = "Btn_Adelante"
        Me.Btn_Adelante.Size = New System.Drawing.Size(100, 49)
        Me.Btn_Adelante.TabIndex = 110
        Me.Btn_Adelante.UseVisualStyleBackColor = False
        Me.Btn_Adelante.Visible = False
        '
        'lbl_NumOrden
        '
        Me.lbl_NumOrden.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_NumOrden.BackColor = System.Drawing.Color.White
        Me.lbl_NumOrden.Enabled = False
        Me.lbl_NumOrden.Location = New System.Drawing.Point(1172, 6)
        Me.lbl_NumOrden.Margin = New System.Windows.Forms.Padding(4)
        Me.lbl_NumOrden.Name = "lbl_NumOrden"
        Me.lbl_NumOrden.ReadOnly = True
        Me.lbl_NumOrden.Size = New System.Drawing.Size(157, 22)
        Me.lbl_NumOrden.TabIndex = 112
        Me.lbl_NumOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DTG_DetPedido
        '
        Me.DTG_DetPedido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTG_DetPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DTG_DetPedido.Location = New System.Drawing.Point(15, 91)
        Me.DTG_DetPedido.Margin = New System.Windows.Forms.Padding(4)
        Me.DTG_DetPedido.Name = "DTG_DetPedido"
        Me.DTG_DetPedido.Size = New System.Drawing.Size(1368, 551)
        Me.DTG_DetPedido.TabIndex = 113
        '
        'btn_Cargar
        '
        Me.btn_Cargar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cargar.Enabled = False
        Me.btn_Cargar.Location = New System.Drawing.Point(1017, 666)
        Me.btn_Cargar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Cargar.Name = "btn_Cargar"
        Me.btn_Cargar.Size = New System.Drawing.Size(89, 39)
        Me.btn_Cargar.TabIndex = 65
        Me.btn_Cargar.Text = "CARGAR"
        Me.btn_Cargar.UseVisualStyleBackColor = True
        Me.btn_Cargar.Visible = False
        '
        'btn_CrearEnSAP
        '
        Me.btn_CrearEnSAP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_CrearEnSAP.Enabled = False
        Me.btn_CrearEnSAP.Location = New System.Drawing.Point(1220, 665)
        Me.btn_CrearEnSAP.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_CrearEnSAP.Name = "btn_CrearEnSAP"
        Me.btn_CrearEnSAP.Size = New System.Drawing.Size(141, 39)
        Me.btn_CrearEnSAP.TabIndex = 66
        Me.btn_CrearEnSAP.Text = "CREAR PEDIDO"
        Me.btn_CrearEnSAP.UseVisualStyleBackColor = True
        '
        'btn_anular
        '
        Me.btn_anular.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_anular.Enabled = False
        Me.btn_anular.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_anular.ForeColor = System.Drawing.Color.Red
        Me.btn_anular.Location = New System.Drawing.Point(1030, 50)
        Me.btn_anular.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_anular.Name = "btn_anular"
        Me.btn_anular.Size = New System.Drawing.Size(124, 39)
        Me.btn_anular.TabIndex = 65
        Me.btn_anular.Text = "ANULAR"
        Me.btn_anular.UseVisualStyleBackColor = True
        '
        'lbl_Estado
        '
        Me.lbl_Estado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Estado.AutoSize = True
        Me.lbl_Estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Estado.ForeColor = System.Drawing.Color.Red
        Me.lbl_Estado.Location = New System.Drawing.Point(1055, 59)
        Me.lbl_Estado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Estado.Name = "lbl_Estado"
        Me.lbl_Estado.Size = New System.Drawing.Size(73, 25)
        Me.lbl_Estado.TabIndex = 114
        Me.lbl_Estado.Text = "Estado"
        Me.lbl_Estado.Visible = False
        '
        'txtb_sap
        '
        Me.txtb_sap.BackColor = System.Drawing.Color.White
        Me.txtb_sap.Location = New System.Drawing.Point(91, 4)
        Me.txtb_sap.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_sap.Name = "txtb_sap"
        Me.txtb_sap.ReadOnly = True
        Me.txtb_sap.Size = New System.Drawing.Size(104, 22)
        Me.txtb_sap.TabIndex = 116
        Me.txtb_sap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtb_sap.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 6)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 17)
        Me.Label8.TabIndex = 115
        Me.Label8.Text = "NumSAP"
        Me.Label8.Visible = False
        '
        'btn_exportar
        '
        Me.btn_exportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_exportar.Enabled = False
        Me.btn_exportar.Location = New System.Drawing.Point(1111, 666)
        Me.btn_exportar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(100, 39)
        Me.btn_exportar.TabIndex = 117
        Me.btn_exportar.Text = "EXPORTAR"
        Me.btn_exportar.UseVisualStyleBackColor = True
        '
        'txtb_DiasACubrir
        '
        Me.txtb_DiasACubrir.BackColor = System.Drawing.Color.White
        Me.txtb_DiasACubrir.Location = New System.Drawing.Point(428, 31)
        Me.txtb_DiasACubrir.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_DiasACubrir.Name = "txtb_DiasACubrir"
        Me.txtb_DiasACubrir.ReadOnly = True
        Me.txtb_DiasACubrir.Size = New System.Drawing.Size(104, 22)
        Me.txtb_DiasACubrir.TabIndex = 119
        Me.txtb_DiasACubrir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(314, 35)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 17)
        Me.Label9.TabIndex = 118
        Me.Label9.Text = "Dias a Cubrir"
        '
        'lbl_PedidoEnSAP
        '
        Me.lbl_PedidoEnSAP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_PedidoEnSAP.AutoSize = True
        Me.lbl_PedidoEnSAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PedidoEnSAP.ForeColor = System.Drawing.Color.Green
        Me.lbl_PedidoEnSAP.Location = New System.Drawing.Point(1213, 672)
        Me.lbl_PedidoEnSAP.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_PedidoEnSAP.Name = "lbl_PedidoEnSAP"
        Me.lbl_PedidoEnSAP.Size = New System.Drawing.Size(151, 20)
        Me.lbl_PedidoEnSAP.TabIndex = 120
        Me.lbl_PedidoEnSAP.Text = "PEDIDO CREADO"
        Me.lbl_PedidoEnSAP.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'CBx_ObtieneDatosTeimpoReal
        '
        Me.CBx_ObtieneDatosTeimpoReal.AutoSize = True
        Me.CBx_ObtieneDatosTeimpoReal.Location = New System.Drawing.Point(317, 5)
        Me.CBx_ObtieneDatosTeimpoReal.Name = "CBx_ObtieneDatosTeimpoReal"
        Me.CBx_ObtieneDatosTeimpoReal.Size = New System.Drawing.Size(215, 21)
        Me.CBx_ObtieneDatosTeimpoReal.TabIndex = 121
        Me.CBx_ObtieneDatosTeimpoReal.Text = "Obtener datos en tiempo real"
        Me.CBx_ObtieneDatosTeimpoReal.UseVisualStyleBackColor = True
        '
        'Btn_VerChequeo
        '
        Me.Btn_VerChequeo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_VerChequeo.Image = Global.SincroCliente.My.Resources.Resources.ir
        Me.Btn_VerChequeo.Location = New System.Drawing.Point(1337, 0)
        Me.Btn_VerChequeo.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_VerChequeo.Name = "Btn_VerChequeo"
        Me.Btn_VerChequeo.Size = New System.Drawing.Size(43, 30)
        Me.Btn_VerChequeo.TabIndex = 122
        Me.Btn_VerChequeo.UseVisualStyleBackColor = True
        '
        'Pedido_Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1396, 719)
        Me.Controls.Add(Me.Btn_VerChequeo)
        Me.Controls.Add(Me.CBx_ObtieneDatosTeimpoReal)
        Me.Controls.Add(Me.lbl_PedidoEnSAP)
        Me.Controls.Add(Me.txtb_DiasACubrir)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btn_exportar)
        Me.Controls.Add(Me.txtb_sap)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lbl_Estado)
        Me.Controls.Add(Me.DTG_DetPedido)
        Me.Controls.Add(Me.lbl_NumOrden)
        Me.Controls.Add(Me.Btn_Atras)
        Me.Controls.Add(Me.Btn_Adelante)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.RdBtb_Unidades)
        Me.Controls.Add(Me.RdBtb_Cajas)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Dias)
        Me.Controls.Add(Me.DTP_FechaFin)
        Me.Controls.Add(Me.DTP_FechaInicio)
        Me.Controls.Add(Me.lbl_Id)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lbl_Inventario)
        Me.Controls.Add(Me.btn_Nuevo)
        Me.Controls.Add(Me.txtb_CondiconPago)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtb_PorcRespaldo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtb_DiasProxCamion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.btn_Guardar)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbl_TVenta)
        Me.Controls.Add(Me.lbl_Total)
        Me.Controls.Add(Me.btn_Buscar)
        Me.Controls.Add(Me.btn_CrearEnSAP)
        Me.Controls.Add(Me.btn_anular)
        Me.Controls.Add(Me.btn_Cargar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btn_BuscaAgente)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtb_NombreProveedor)
        Me.Controls.Add(Me.txtb_CodProveedor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.DTP_ProyeccionFin)
        Me.Controls.Add(Me.DTP_ProyeccionIni)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Pedido_Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crear_Pedido"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DTG_DetPedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_BuscaAgente As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtb_NombreProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtb_CodProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_Buscar As System.Windows.Forms.Button
    Friend WithEvents lbl_Total As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtb_DiasProxCamion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtb_PorcRespaldo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtb_CondiconPago As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtb_Email As System.Windows.Forms.TextBox
    Friend WithEvents btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl_Inventario As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Id As System.Windows.Forms.Label
    Friend WithEvents DTP_FechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_FechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents RdBtb_Unidades As System.Windows.Forms.RadioButton
    Friend WithEvents RdBtb_Cajas As System.Windows.Forms.RadioButton
    Friend WithEvents Dias As System.Windows.Forms.Label
    Friend WithEvents lbl_TVenta As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DTP_ProyeccionFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_ProyeccionIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Btn_Atras As System.Windows.Forms.Button
    Friend WithEvents Btn_Adelante As System.Windows.Forms.Button
    Friend WithEvents lbl_NumOrden As System.Windows.Forms.TextBox
    Friend WithEvents DTG_DetPedido As System.Windows.Forms.DataGridView
    Friend WithEvents btn_Cargar As Button
    Friend WithEvents btn_CrearEnSAP As Button
    Friend WithEvents btn_anular As Button
    Friend WithEvents lbl_Estado As Label
    Friend WithEvents txtb_sap As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btn_exportar As Button
    Friend WithEvents txtb_DiasACubrir As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents lbl_PedidoEnSAP As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents CBx_ObtieneDatosTeimpoReal As CheckBox
    Friend WithEvents Btn_VerChequeo As Button
End Class
