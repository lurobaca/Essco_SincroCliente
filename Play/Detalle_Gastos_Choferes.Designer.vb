<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Detalle_Gastos_Choferes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Detalle_Gastos_Choferes))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txb_NumDoc = New System.Windows.Forms.TextBox()
        Me.txb_Monto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txb_Descripcion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgv_DetGastos = New System.Windows.Forms.DataGridView()
        Me.btn_AgNuevo = New System.Windows.Forms.Button()
        Me.btn_AgElimina = New System.Windows.Forms.Button()
        Me.btn_AgGuardar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txb_Total = New System.Windows.Forms.TextBox()
        Me.dtp_FechaGasto = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txtb_DocNum = New System.Windows.Forms.TextBox()
        Me.btn_BuscaGasto = New System.Windows.Forms.Button()
        Me.Cbx_Tipo = New System.Windows.Forms.ComboBox()
        Me.btn_Agentes = New System.Windows.Forms.Button()
        Me.txb_NomAgente = New System.Windows.Forms.TextBox()
        Me.txb_CodAgente = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btn_GoToLiq = New System.Windows.Forms.Button()
        Me.txb_Liquidacion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lbl_Anulado = New System.Windows.Forms.Label()
        Me.GBox_InfoProveedor = New System.Windows.Forms.GroupBox()
        Me.btn_IrProveedores = New System.Windows.Forms.Button()
        Me.txb_Correo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txb_Cedula = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txb_Nombre = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txb_Codigo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.RBt_SI = New System.Windows.Forms.RadioButton()
        Me.RBt_NO = New System.Windows.Forms.RadioButton()
        Me.CBox_IncluidoEnLiquidacion = New System.Windows.Forms.CheckBox()
        Me.txtb_EstadoMH = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btn_ReenviarMH = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgv_DetGastos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GBox_InfoProveedor.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 74)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "# Factura"
        '
        'txb_NumDoc
        '
        Me.txb_NumDoc.BackColor = System.Drawing.SystemColors.Info
        Me.txb_NumDoc.Location = New System.Drawing.Point(121, 74)
        Me.txb_NumDoc.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_NumDoc.Name = "txb_NumDoc"
        Me.txb_NumDoc.Size = New System.Drawing.Size(203, 22)
        Me.txb_NumDoc.TabIndex = 2
        '
        'txb_Monto
        '
        Me.txb_Monto.Location = New System.Drawing.Point(119, 386)
        Me.txb_Monto.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_Monto.Name = "txb_Monto"
        Me.txb_Monto.Size = New System.Drawing.Size(444, 22)
        Me.txb_Monto.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 390)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Monto"
        '
        'txb_Descripcion
        '
        Me.txb_Descripcion.Location = New System.Drawing.Point(18, 500)
        Me.txb_Descripcion.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_Descripcion.Multiline = True
        Me.txb_Descripcion.Name = "txb_Descripcion"
        Me.txb_Descripcion.Size = New System.Drawing.Size(545, 100)
        Me.txb_Descripcion.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 432)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Tipo"
        '
        'dgv_DetGastos
        '
        Me.dgv_DetGastos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_DetGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_DetGastos.Location = New System.Drawing.Point(21, 11)
        Me.dgv_DetGastos.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_DetGastos.Name = "dgv_DetGastos"
        Me.dgv_DetGastos.Size = New System.Drawing.Size(504, 585)
        Me.dgv_DetGastos.TabIndex = 47
        '
        'btn_AgNuevo
        '
        Me.btn_AgNuevo.Location = New System.Drawing.Point(14, 617)
        Me.btn_AgNuevo.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_AgNuevo.Name = "btn_AgNuevo"
        Me.btn_AgNuevo.Size = New System.Drawing.Size(111, 47)
        Me.btn_AgNuevo.TabIndex = 51
        Me.btn_AgNuevo.Text = "NUEVO"
        Me.btn_AgNuevo.UseVisualStyleBackColor = True
        '
        'btn_AgElimina
        '
        Me.btn_AgElimina.Enabled = False
        Me.btn_AgElimina.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AgElimina.ForeColor = System.Drawing.Color.Red
        Me.btn_AgElimina.Location = New System.Drawing.Point(459, 617)
        Me.btn_AgElimina.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_AgElimina.Name = "btn_AgElimina"
        Me.btn_AgElimina.Size = New System.Drawing.Size(111, 47)
        Me.btn_AgElimina.TabIndex = 50
        Me.btn_AgElimina.Text = "ANULAR"
        Me.btn_AgElimina.UseVisualStyleBackColor = True
        '
        'btn_AgGuardar
        '
        Me.btn_AgGuardar.Location = New System.Drawing.Point(133, 617)
        Me.btn_AgGuardar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_AgGuardar.Name = "btn_AgGuardar"
        Me.btn_AgGuardar.Size = New System.Drawing.Size(111, 47)
        Me.btn_AgGuardar.TabIndex = 48
        Me.btn_AgGuardar.Text = "GUARDAR"
        Me.btn_AgGuardar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 599)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 26)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "TOTAL"
        '
        'txb_Total
        '
        Me.txb_Total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txb_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Total.Location = New System.Drawing.Point(100, 599)
        Me.txb_Total.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_Total.Name = "txb_Total"
        Me.txb_Total.ReadOnly = True
        Me.txb_Total.Size = New System.Drawing.Size(424, 30)
        Me.txb_Total.TabIndex = 54
        '
        'dtp_FechaGasto
        '
        Me.dtp_FechaGasto.Location = New System.Drawing.Point(119, 341)
        Me.dtp_FechaGasto.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_FechaGasto.Name = "dtp_FechaGasto"
        Me.dtp_FechaGasto.Size = New System.Drawing.Size(444, 22)
        Me.dtp_FechaGasto.TabIndex = 55
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 344)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 17)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Fecha"
        '
        'Txtb_DocNum
        '
        Me.Txtb_DocNum.BackColor = System.Drawing.SystemColors.Info
        Me.Txtb_DocNum.Enabled = False
        Me.Txtb_DocNum.Location = New System.Drawing.Point(120, 18)
        Me.Txtb_DocNum.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_DocNum.Name = "Txtb_DocNum"
        Me.Txtb_DocNum.ReadOnly = True
        Me.Txtb_DocNum.Size = New System.Drawing.Size(156, 22)
        Me.Txtb_DocNum.TabIndex = 57
        '
        'btn_BuscaGasto
        '
        Me.btn_BuscaGasto.Image = CType(resources.GetObject("btn_BuscaGasto.Image"), System.Drawing.Image)
        Me.btn_BuscaGasto.Location = New System.Drawing.Point(283, 18)
        Me.btn_BuscaGasto.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_BuscaGasto.Name = "btn_BuscaGasto"
        Me.btn_BuscaGasto.Size = New System.Drawing.Size(43, 30)
        Me.btn_BuscaGasto.TabIndex = 58
        Me.btn_BuscaGasto.UseVisualStyleBackColor = True
        '
        'Cbx_Tipo
        '
        Me.Cbx_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbx_Tipo.FormattingEnabled = True
        Me.Cbx_Tipo.Items.AddRange(New Object() {"", "Viaticos", "Combustible", "Hospedaje", "Imprevistos", "Otros"})
        Me.Cbx_Tipo.Location = New System.Drawing.Point(119, 428)
        Me.Cbx_Tipo.Margin = New System.Windows.Forms.Padding(4)
        Me.Cbx_Tipo.Name = "Cbx_Tipo"
        Me.Cbx_Tipo.Size = New System.Drawing.Size(444, 24)
        Me.Cbx_Tipo.TabIndex = 59
        '
        'btn_Agentes
        '
        Me.btn_Agentes.Enabled = False
        Me.btn_Agentes.Image = CType(resources.GetObject("btn_Agentes.Image"), System.Drawing.Image)
        Me.btn_Agentes.Location = New System.Drawing.Point(511, 297)
        Me.btn_Agentes.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Agentes.Name = "btn_Agentes"
        Me.btn_Agentes.Size = New System.Drawing.Size(53, 27)
        Me.btn_Agentes.TabIndex = 61
        Me.btn_Agentes.UseVisualStyleBackColor = True
        '
        'txb_NomAgente
        '
        Me.txb_NomAgente.Location = New System.Drawing.Point(195, 302)
        Me.txb_NomAgente.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_NomAgente.Name = "txb_NomAgente"
        Me.txb_NomAgente.ReadOnly = True
        Me.txb_NomAgente.Size = New System.Drawing.Size(307, 22)
        Me.txb_NomAgente.TabIndex = 63
        '
        'txb_CodAgente
        '
        Me.txb_CodAgente.Location = New System.Drawing.Point(119, 302)
        Me.txb_CodAgente.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_CodAgente.Name = "txb_CodAgente"
        Me.txb_CodAgente.ReadOnly = True
        Me.txb_CodAgente.Size = New System.Drawing.Size(67, 22)
        Me.txb_CodAgente.TabIndex = 60
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 306)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 17)
        Me.Label8.TabIndex = 62
        Me.Label8.Text = "Empleado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 22)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 17)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "#Consecutivo"
        '
        'btn_GoToLiq
        '
        Me.btn_GoToLiq.Enabled = False
        Me.btn_GoToLiq.Image = CType(resources.GetObject("btn_GoToLiq.Image"), System.Drawing.Image)
        Me.btn_GoToLiq.Location = New System.Drawing.Point(511, 465)
        Me.btn_GoToLiq.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_GoToLiq.Name = "btn_GoToLiq"
        Me.btn_GoToLiq.Size = New System.Drawing.Size(53, 27)
        Me.btn_GoToLiq.TabIndex = 65
        Me.btn_GoToLiq.UseVisualStyleBackColor = True
        '
        'txb_Liquidacion
        '
        Me.txb_Liquidacion.Enabled = False
        Me.txb_Liquidacion.Location = New System.Drawing.Point(119, 465)
        Me.txb_Liquidacion.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_Liquidacion.Name = "txb_Liquidacion"
        Me.txb_Liquidacion.Size = New System.Drawing.Size(383, 22)
        Me.txb_Liquidacion.TabIndex = 67
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 469)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 17)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "# Liquidacion"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.dgv_DetGastos)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txb_Total)
        Me.Panel1.Location = New System.Drawing.Point(597, 44)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(536, 633)
        Me.Panel1.TabIndex = 68
        '
        'Lbl_Anulado
        '
        Me.Lbl_Anulado.AutoSize = True
        Me.Lbl_Anulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Anulado.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Anulado.Location = New System.Drawing.Point(333, 16)
        Me.Lbl_Anulado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Anulado.Name = "Lbl_Anulado"
        Me.Lbl_Anulado.Size = New System.Drawing.Size(126, 26)
        Me.Lbl_Anulado.TabIndex = 69
        Me.Lbl_Anulado.Text = "ANULADO"
        Me.Lbl_Anulado.Visible = False
        '
        'GBox_InfoProveedor
        '
        Me.GBox_InfoProveedor.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBox_InfoProveedor.Controls.Add(Me.Button1)
        Me.GBox_InfoProveedor.Controls.Add(Me.btn_ReenviarMH)
        Me.GBox_InfoProveedor.Controls.Add(Me.btn_IrProveedores)
        Me.GBox_InfoProveedor.Controls.Add(Me.txtb_EstadoMH)
        Me.GBox_InfoProveedor.Controls.Add(Me.txb_Correo)
        Me.GBox_InfoProveedor.Controls.Add(Me.Label14)
        Me.GBox_InfoProveedor.Controls.Add(Me.Label13)
        Me.GBox_InfoProveedor.Controls.Add(Me.txb_Cedula)
        Me.GBox_InfoProveedor.Controls.Add(Me.Label12)
        Me.GBox_InfoProveedor.Controls.Add(Me.txb_Nombre)
        Me.GBox_InfoProveedor.Controls.Add(Me.Label11)
        Me.GBox_InfoProveedor.Controls.Add(Me.txb_Codigo)
        Me.GBox_InfoProveedor.Controls.Add(Me.Label10)
        Me.GBox_InfoProveedor.Enabled = False
        Me.GBox_InfoProveedor.Location = New System.Drawing.Point(23, 110)
        Me.GBox_InfoProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.GBox_InfoProveedor.Name = "GBox_InfoProveedor"
        Me.GBox_InfoProveedor.Padding = New System.Windows.Forms.Padding(4)
        Me.GBox_InfoProveedor.Size = New System.Drawing.Size(557, 151)
        Me.GBox_InfoProveedor.TabIndex = 77
        Me.GBox_InfoProveedor.TabStop = False
        Me.GBox_InfoProveedor.Text = "Info Proveedor"
        '
        'btn_IrProveedores
        '
        Me.btn_IrProveedores.Image = CType(resources.GetObject("btn_IrProveedores.Image"), System.Drawing.Image)
        Me.btn_IrProveedores.Location = New System.Drawing.Point(493, 23)
        Me.btn_IrProveedores.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_IrProveedores.Name = "btn_IrProveedores"
        Me.btn_IrProveedores.Size = New System.Drawing.Size(53, 27)
        Me.btn_IrProveedores.TabIndex = 74
        Me.btn_IrProveedores.UseVisualStyleBackColor = True
        '
        'txb_Correo
        '
        Me.txb_Correo.BackColor = System.Drawing.SystemColors.Info
        Me.txb_Correo.Location = New System.Drawing.Point(105, 55)
        Me.txb_Correo.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_Correo.Name = "txb_Correo"
        Me.txb_Correo.ReadOnly = True
        Me.txb_Correo.Size = New System.Drawing.Size(416, 22)
        Me.txb_Correo.TabIndex = 81
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 55)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 17)
        Me.Label13.TabIndex = 80
        Me.Label13.Text = "Correo"
        '
        'txb_Cedula
        '
        Me.txb_Cedula.BackColor = System.Drawing.SystemColors.Info
        Me.txb_Cedula.Location = New System.Drawing.Point(331, 26)
        Me.txb_Cedula.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_Cedula.Name = "txb_Cedula"
        Me.txb_Cedula.ReadOnly = True
        Me.txb_Cedula.Size = New System.Drawing.Size(156, 22)
        Me.txb_Cedula.TabIndex = 79
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(267, 26)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 17)
        Me.Label12.TabIndex = 78
        Me.Label12.Text = "Cedula"
        '
        'txb_Nombre
        '
        Me.txb_Nombre.BackColor = System.Drawing.SystemColors.Info
        Me.txb_Nombre.Location = New System.Drawing.Point(105, 85)
        Me.txb_Nombre.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_Nombre.Name = "txb_Nombre"
        Me.txb_Nombre.ReadOnly = True
        Me.txb_Nombre.Size = New System.Drawing.Size(416, 22)
        Me.txb_Nombre.TabIndex = 77
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 85)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 17)
        Me.Label11.TabIndex = 76
        Me.Label11.Text = "Nombre"
        '
        'txb_Codigo
        '
        Me.txb_Codigo.BackColor = System.Drawing.SystemColors.Info
        Me.txb_Codigo.Location = New System.Drawing.Point(107, 23)
        Me.txb_Codigo.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_Codigo.Name = "txb_Codigo"
        Me.txb_Codigo.ReadOnly = True
        Me.txb_Codigo.Size = New System.Drawing.Size(156, 22)
        Me.txb_Codigo.TabIndex = 75
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 23)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 17)
        Me.Label10.TabIndex = 74
        Me.Label10.Text = "Codigo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(333, 78)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 17)
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "Es Electronica?"
        '
        'RBt_SI
        '
        Me.RBt_SI.AutoSize = True
        Me.RBt_SI.Checked = True
        Me.RBt_SI.Location = New System.Drawing.Point(464, 78)
        Me.RBt_SI.Margin = New System.Windows.Forms.Padding(4)
        Me.RBt_SI.Name = "RBt_SI"
        Me.RBt_SI.Size = New System.Drawing.Size(41, 21)
        Me.RBt_SI.TabIndex = 75
        Me.RBt_SI.TabStop = True
        Me.RBt_SI.Text = "SI"
        Me.RBt_SI.UseVisualStyleBackColor = True
        '
        'RBt_NO
        '
        Me.RBt_NO.AutoSize = True
        Me.RBt_NO.Location = New System.Drawing.Point(516, 78)
        Me.RBt_NO.Margin = New System.Windows.Forms.Padding(4)
        Me.RBt_NO.Name = "RBt_NO"
        Me.RBt_NO.Size = New System.Drawing.Size(50, 21)
        Me.RBt_NO.TabIndex = 74
        Me.RBt_NO.Text = "NO"
        Me.RBt_NO.UseVisualStyleBackColor = True
        '
        'CBox_IncluidoEnLiquidacion
        '
        Me.CBox_IncluidoEnLiquidacion.AutoSize = True
        Me.CBox_IncluidoEnLiquidacion.Checked = True
        Me.CBox_IncluidoEnLiquidacion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBox_IncluidoEnLiquidacion.Location = New System.Drawing.Point(119, 268)
        Me.CBox_IncluidoEnLiquidacion.Name = "CBox_IncluidoEnLiquidacion"
        Me.CBox_IncluidoEnLiquidacion.Size = New System.Drawing.Size(174, 21)
        Me.CBox_IncluidoEnLiquidacion.TabIndex = 80
        Me.CBox_IncluidoEnLiquidacion.Text = "Incluido en Liquidacion"
        Me.CBox_IncluidoEnLiquidacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CBox_IncluidoEnLiquidacion.UseVisualStyleBackColor = True
        '
        'txtb_EstadoMH
        '
        Me.txtb_EstadoMH.Location = New System.Drawing.Point(105, 117)
        Me.txtb_EstadoMH.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_EstadoMH.Name = "txtb_EstadoMH"
        Me.txtb_EstadoMH.ReadOnly = True
        Me.txtb_EstadoMH.Size = New System.Drawing.Size(131, 22)
        Me.txtb_EstadoMH.TabIndex = 78
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 120)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 17)
        Me.Label14.TabIndex = 79
        Me.Label14.Text = "Estado MH"
        '
        'btn_ReenviarMH
        '
        Me.btn_ReenviarMH.Location = New System.Drawing.Point(331, 112)
        Me.btn_ReenviarMH.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_ReenviarMH.Name = "btn_ReenviarMH"
        Me.btn_ReenviarMH.Size = New System.Drawing.Size(125, 31)
        Me.btn_ReenviarMH.TabIndex = 81
        Me.btn_ReenviarMH.Text = "Reenviar a MH"
        Me.btn_ReenviarMH.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = Global.SincroCliente.My.Resources.Resources.ico_sync
        Me.Button1.Location = New System.Drawing.Point(250, 112)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(53, 32)
        Me.Button1.TabIndex = 82
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Detalle_Gastos_Choferes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1144, 674)
        Me.Controls.Add(Me.CBox_IncluidoEnLiquidacion)
        Me.Controls.Add(Me.GBox_InfoProveedor)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.RBt_SI)
        Me.Controls.Add(Me.RBt_NO)
        Me.Controls.Add(Me.Lbl_Anulado)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btn_GoToLiq)
        Me.Controls.Add(Me.txb_Liquidacion)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btn_Agentes)
        Me.Controls.Add(Me.txb_NomAgente)
        Me.Controls.Add(Me.txb_CodAgente)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Cbx_Tipo)
        Me.Controls.Add(Me.btn_BuscaGasto)
        Me.Controls.Add(Me.Txtb_DocNum)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtp_FechaGasto)
        Me.Controls.Add(Me.btn_AgNuevo)
        Me.Controls.Add(Me.btn_AgElimina)
        Me.Controls.Add(Me.btn_AgGuardar)
        Me.Controls.Add(Me.txb_Descripcion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txb_Monto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txb_NumDoc)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(590, 538)
        Me.Name = "Detalle_Gastos_Choferes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle_Gastos_Choferes"
        CType(Me.dgv_DetGastos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GBox_InfoProveedor.ResumeLayout(False)
        Me.GBox_InfoProveedor.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txb_NumDoc As System.Windows.Forms.TextBox
    Friend WithEvents txb_Monto As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txb_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgv_DetGastos As System.Windows.Forms.DataGridView
    Friend WithEvents btn_AgNuevo As System.Windows.Forms.Button
    Friend WithEvents btn_AgElimina As System.Windows.Forms.Button
    Friend WithEvents btn_AgGuardar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txb_Total As System.Windows.Forms.TextBox
    Friend WithEvents dtp_FechaGasto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txtb_DocNum As System.Windows.Forms.TextBox
    Friend WithEvents btn_BuscaGasto As System.Windows.Forms.Button
    Friend WithEvents btn_Agentes As System.Windows.Forms.Button
    Friend WithEvents txb_NomAgente As System.Windows.Forms.TextBox
    Friend WithEvents txb_CodAgente As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_GoToLiq As System.Windows.Forms.Button
    Friend WithEvents txb_Liquidacion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Lbl_Anulado As System.Windows.Forms.Label
    Friend WithEvents Cbx_Tipo As System.Windows.Forms.ComboBox
    Friend WithEvents GBox_InfoProveedor As GroupBox
    Friend WithEvents btn_IrProveedores As Button
    Friend WithEvents txb_Correo As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txb_Cedula As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txb_Nombre As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txb_Codigo As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents RBt_SI As RadioButton
    Friend WithEvents RBt_NO As RadioButton
    Friend WithEvents CBox_IncluidoEnLiquidacion As CheckBox
    Friend WithEvents txtb_EstadoMH As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents btn_ReenviarMH As Button
    Friend WithEvents Button1 As Button
End Class
