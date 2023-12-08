<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Enviar_Info_Seller
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
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Cbox_MotivoDevolucion = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btn_ExpoInfo = New System.Windows.Forms.Button()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.cbx_CatalogoDivido = New System.Windows.Forms.CheckBox()
        Me.TextB_Agente = New System.Windows.Forms.TextBox()
        Me.txb_Grupo = New System.Windows.Forms.TextBox()
        Me.Cbox_Razones = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_EnviarTodos = New System.Windows.Forms.Button()
        Me.Prgs_CargaAgentes = New System.Windows.Forms.ProgressBar()
        Me.lbl_TotalAgentes = New System.Windows.Forms.Label()
        Me.lbl_DetalleCarga = New System.Windows.Forms.Label()
        Me.lbl_AgentesProcesados = New System.Windows.Forms.Label()
        Me.Cbox_Bancos = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.ListV_Reportes = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_Cambiar = New System.Windows.Forms.Button()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.TextB_Agente1 = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.TextB_Agente2 = New System.Windows.Forms.TextBox()
        Me.Cbox_Ubicaciones = New System.Windows.Forms.CheckBox()
        Me.Cbox_Cxc = New System.Windows.Forms.CheckBox()
        Me.Cbox_Facturas = New System.Windows.Forms.CheckBox()
        Me.Cbox_Clientes = New System.Windows.Forms.CheckBox()
        Me.lbl_FechaReporte = New System.Windows.Forms.Label()
        Me.DTP_FechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.CBX_Param = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChBox_ClientexDia = New System.Windows.Forms.CheckBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.btn_HabilitarServidores = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CBox_VERPuestos = New System.Windows.Forms.ComboBox()
        Me.DTP_FechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Controls.Add(Me.Cbox_MotivoDevolucion)
        Me.GroupBox7.Controls.Add(Me.CheckBox1)
        Me.GroupBox7.Controls.Add(Me.GroupBox3)
        Me.GroupBox7.Controls.Add(Me.Cbox_Razones)
        Me.GroupBox7.Controls.Add(Me.GroupBox2)
        Me.GroupBox7.Controls.Add(Me.Cbox_Bancos)
        Me.GroupBox7.Controls.Add(Me.GroupBox6)
        Me.GroupBox7.Controls.Add(Me.Cbox_Ubicaciones)
        Me.GroupBox7.Controls.Add(Me.Cbox_Cxc)
        Me.GroupBox7.Controls.Add(Me.Cbox_Facturas)
        Me.GroupBox7.Controls.Add(Me.Cbox_Clientes)
        Me.GroupBox7.Enabled = False
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(13, 123)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox7.Size = New System.Drawing.Size(1180, 420)
        Me.GroupBox7.TabIndex = 16
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Tipo de envio"
        '
        'Cbox_MotivoDevolucion
        '
        Me.Cbox_MotivoDevolucion.AutoSize = True
        Me.Cbox_MotivoDevolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbox_MotivoDevolucion.Location = New System.Drawing.Point(8, 383)
        Me.Cbox_MotivoDevolucion.Margin = New System.Windows.Forms.Padding(4)
        Me.Cbox_MotivoDevolucion.Name = "Cbox_MotivoDevolucion"
        Me.Cbox_MotivoDevolucion.Size = New System.Drawing.Size(211, 29)
        Me.Cbox_MotivoDevolucion.TabIndex = 45
        Me.Cbox_MotivoDevolucion.Text = "Motivo Devolucion"
        Me.Cbox_MotivoDevolucion.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(8, 47)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(148, 29)
        Me.CheckBox1.TabIndex = 44
        Me.CheckBox1.Text = "Descuentos"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.btn_ExpoInfo)
        Me.GroupBox3.Controls.Add(Me.Label47)
        Me.GroupBox3.Controls.Add(Me.cbx_CatalogoDivido)
        Me.GroupBox3.Controls.Add(Me.TextB_Agente)
        Me.GroupBox3.Controls.Add(Me.txb_Grupo)
        Me.GroupBox3.Location = New System.Drawing.Point(248, 289)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(916, 123)
        Me.GroupBox3.TabIndex = 43
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Enviar a un solo empleado"
        '
        'btn_ExpoInfo
        '
        Me.btn_ExpoInfo.Location = New System.Drawing.Point(8, 32)
        Me.btn_ExpoInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_ExpoInfo.Name = "btn_ExpoInfo"
        Me.btn_ExpoInfo.Size = New System.Drawing.Size(280, 59)
        Me.btn_ExpoInfo.TabIndex = 1
        Me.btn_ExpoInfo.Text = "Exportar a uno"
        Me.btn_ExpoInfo.UseVisualStyleBackColor = True
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(385, 28)
        Me.Label47.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(120, 25)
        Me.Label47.TabIndex = 3
        Me.Label47.Text = "#Empleado"
        '
        'cbx_CatalogoDivido
        '
        Me.cbx_CatalogoDivido.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbx_CatalogoDivido.AutoSize = True
        Me.cbx_CatalogoDivido.Location = New System.Drawing.Point(778, 21)
        Me.cbx_CatalogoDivido.Margin = New System.Windows.Forms.Padding(4)
        Me.cbx_CatalogoDivido.Name = "cbx_CatalogoDivido"
        Me.cbx_CatalogoDivido.Size = New System.Drawing.Size(93, 29)
        Me.cbx_CatalogoDivido.TabIndex = 19
        Me.cbx_CatalogoDivido.Text = "Grupo"
        Me.cbx_CatalogoDivido.UseVisualStyleBackColor = True
        Me.cbx_CatalogoDivido.Visible = False
        '
        'TextB_Agente
        '
        Me.TextB_Agente.Location = New System.Drawing.Point(390, 61)
        Me.TextB_Agente.Margin = New System.Windows.Forms.Padding(4)
        Me.TextB_Agente.Name = "TextB_Agente"
        Me.TextB_Agente.Size = New System.Drawing.Size(132, 30)
        Me.TextB_Agente.TabIndex = 2
        '
        'txb_Grupo
        '
        Me.txb_Grupo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txb_Grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txb_Grupo.Enabled = False
        Me.txb_Grupo.Location = New System.Drawing.Point(749, 61)
        Me.txb_Grupo.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_Grupo.Name = "txb_Grupo"
        Me.txb_Grupo.Size = New System.Drawing.Size(159, 30)
        Me.txb_Grupo.TabIndex = 20
        Me.txb_Grupo.Visible = False
        '
        'Cbox_Razones
        '
        Me.Cbox_Razones.AutoSize = True
        Me.Cbox_Razones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbox_Razones.Location = New System.Drawing.Point(8, 337)
        Me.Cbox_Razones.Margin = New System.Windows.Forms.Padding(4)
        Me.Cbox_Razones.Name = "Cbox_Razones"
        Me.Cbox_Razones.Size = New System.Drawing.Size(119, 29)
        Me.Cbox_Razones.TabIndex = 42
        Me.Cbox_Razones.Text = "Razones"
        Me.Cbox_Razones.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.btn_EnviarTodos)
        Me.GroupBox2.Controls.Add(Me.Prgs_CargaAgentes)
        Me.GroupBox2.Controls.Add(Me.lbl_TotalAgentes)
        Me.GroupBox2.Controls.Add(Me.lbl_DetalleCarga)
        Me.GroupBox2.Controls.Add(Me.lbl_AgentesProcesados)
        Me.GroupBox2.Location = New System.Drawing.Point(247, 31)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(917, 121)
        Me.GroupBox2.TabIndex = 35
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Enviar a todos los empleados"
        '
        'btn_EnviarTodos
        '
        Me.btn_EnviarTodos.Location = New System.Drawing.Point(5, 37)
        Me.btn_EnviarTodos.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_EnviarTodos.Name = "btn_EnviarTodos"
        Me.btn_EnviarTodos.Size = New System.Drawing.Size(280, 59)
        Me.btn_EnviarTodos.TabIndex = 0
        Me.btn_EnviarTodos.Text = "Exportar a todos"
        Me.btn_EnviarTodos.UseVisualStyleBackColor = True
        '
        'Prgs_CargaAgentes
        '
        Me.Prgs_CargaAgentes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Prgs_CargaAgentes.Location = New System.Drawing.Point(305, 68)
        Me.Prgs_CargaAgentes.Margin = New System.Windows.Forms.Padding(4)
        Me.Prgs_CargaAgentes.Name = "Prgs_CargaAgentes"
        Me.Prgs_CargaAgentes.Size = New System.Drawing.Size(599, 28)
        Me.Prgs_CargaAgentes.TabIndex = 15
        '
        'lbl_TotalAgentes
        '
        Me.lbl_TotalAgentes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_TotalAgentes.AutoSize = True
        Me.lbl_TotalAgentes.Location = New System.Drawing.Point(835, 39)
        Me.lbl_TotalAgentes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_TotalAgentes.Name = "lbl_TotalAgentes"
        Me.lbl_TotalAgentes.Size = New System.Drawing.Size(60, 25)
        Me.lbl_TotalAgentes.TabIndex = 18
        Me.lbl_TotalAgentes.Text = "Total"
        '
        'lbl_DetalleCarga
        '
        Me.lbl_DetalleCarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_DetalleCarga.AutoSize = True
        Me.lbl_DetalleCarga.Location = New System.Drawing.Point(557, 41)
        Me.lbl_DetalleCarga.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_DetalleCarga.Name = "lbl_DetalleCarga"
        Me.lbl_DetalleCarga.Size = New System.Drawing.Size(79, 25)
        Me.lbl_DetalleCarga.TabIndex = 16
        Me.lbl_DetalleCarga.Text = "Detalle"
        '
        'lbl_AgentesProcesados
        '
        Me.lbl_AgentesProcesados.AutoSize = True
        Me.lbl_AgentesProcesados.Location = New System.Drawing.Point(305, 39)
        Me.lbl_AgentesProcesados.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_AgentesProcesados.Name = "lbl_AgentesProcesados"
        Me.lbl_AgentesProcesados.Size = New System.Drawing.Size(126, 25)
        Me.lbl_AgentesProcesados.TabIndex = 17
        Me.lbl_AgentesProcesados.Text = "Procesados"
        '
        'Cbox_Bancos
        '
        Me.Cbox_Bancos.AutoSize = True
        Me.Cbox_Bancos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbox_Bancos.Location = New System.Drawing.Point(9, 291)
        Me.Cbox_Bancos.Margin = New System.Windows.Forms.Padding(4)
        Me.Cbox_Bancos.Name = "Cbox_Bancos"
        Me.Cbox_Bancos.Size = New System.Drawing.Size(106, 29)
        Me.Cbox_Bancos.TabIndex = 41
        Me.Cbox_Bancos.Text = "Bancos"
        Me.Cbox_Bancos.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox6.Controls.Add(Me.ListV_Reportes)
        Me.GroupBox6.Controls.Add(Me.Button1)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.btn_Cambiar)
        Me.GroupBox6.Controls.Add(Me.Label48)
        Me.GroupBox6.Controls.Add(Me.TextB_Agente1)
        Me.GroupBox6.Controls.Add(Me.Label50)
        Me.GroupBox6.Controls.Add(Me.Label49)
        Me.GroupBox6.Controls.Add(Me.TextB_Agente2)
        Me.GroupBox6.Location = New System.Drawing.Point(247, 154)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox6.Size = New System.Drawing.Size(916, 121)
        Me.GroupBox6.TabIndex = 13
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Intercambiar Rutas"
        '
        'ListV_Reportes
        '
        Me.ListV_Reportes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListV_Reportes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.ListV_Reportes.Enabled = False
        Me.ListV_Reportes.HideSelection = False
        Me.ListV_Reportes.Location = New System.Drawing.Point(389, 54)
        Me.ListV_Reportes.Margin = New System.Windows.Forms.Padding(4)
        Me.ListV_Reportes.Name = "ListV_Reportes"
        Me.ListV_Reportes.Size = New System.Drawing.Size(200, 43)
        Me.ListV_Reportes.TabIndex = 94
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
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(598, 54)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(77, 37)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = "Rutas"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(757, 28)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 25)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "#Empleado"
        '
        'btn_Cambiar
        '
        Me.btn_Cambiar.Location = New System.Drawing.Point(8, 39)
        Me.btn_Cambiar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Cambiar.Name = "btn_Cambiar"
        Me.btn_Cambiar.Size = New System.Drawing.Size(280, 59)
        Me.btn_Cambiar.TabIndex = 13
        Me.btn_Cambiar.Text = "Cambiar"
        Me.btn_Cambiar.UseVisualStyleBackColor = True
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(305, 57)
        Me.Label48.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(74, 25)
        Me.Label48.TabIndex = 8
        Me.Label48.Text = "Desde"
        '
        'TextB_Agente1
        '
        Me.TextB_Agente1.Location = New System.Drawing.Point(389, 54)
        Me.TextB_Agente1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextB_Agente1.Name = "TextB_Agente1"
        Me.TextB_Agente1.Size = New System.Drawing.Size(132, 30)
        Me.TextB_Agente1.TabIndex = 7
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(384, 23)
        Me.Label50.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(120, 25)
        Me.Label50.TabIndex = 11
        Me.Label50.Text = "#Empleado"
        '
        'Label49
        '
        Me.Label49.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(682, 60)
        Me.Label49.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(67, 25)
        Me.Label49.TabIndex = 9
        Me.Label49.Text = "Hacia"
        '
        'TextB_Agente2
        '
        Me.TextB_Agente2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextB_Agente2.Location = New System.Drawing.Point(761, 57)
        Me.TextB_Agente2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextB_Agente2.Name = "TextB_Agente2"
        Me.TextB_Agente2.Size = New System.Drawing.Size(144, 30)
        Me.TextB_Agente2.TabIndex = 10
        '
        'Cbox_Ubicaciones
        '
        Me.Cbox_Ubicaciones.AutoSize = True
        Me.Cbox_Ubicaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbox_Ubicaciones.Location = New System.Drawing.Point(9, 243)
        Me.Cbox_Ubicaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.Cbox_Ubicaciones.Name = "Cbox_Ubicaciones"
        Me.Cbox_Ubicaciones.Size = New System.Drawing.Size(152, 29)
        Me.Cbox_Ubicaciones.TabIndex = 40
        Me.Cbox_Ubicaciones.Text = "Ubicaciones"
        Me.Cbox_Ubicaciones.UseVisualStyleBackColor = True
        '
        'Cbox_Cxc
        '
        Me.Cbox_Cxc.AutoSize = True
        Me.Cbox_Cxc.Checked = True
        Me.Cbox_Cxc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cbox_Cxc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbox_Cxc.Location = New System.Drawing.Point(9, 95)
        Me.Cbox_Cxc.Margin = New System.Windows.Forms.Padding(4)
        Me.Cbox_Cxc.Name = "Cbox_Cxc"
        Me.Cbox_Cxc.Size = New System.Drawing.Size(71, 29)
        Me.Cbox_Cxc.TabIndex = 37
        Me.Cbox_Cxc.Text = "Cxc"
        Me.Cbox_Cxc.UseVisualStyleBackColor = True
        '
        'Cbox_Facturas
        '
        Me.Cbox_Facturas.AutoSize = True
        Me.Cbox_Facturas.Checked = True
        Me.Cbox_Facturas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cbox_Facturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbox_Facturas.Location = New System.Drawing.Point(9, 193)
        Me.Cbox_Facturas.Margin = New System.Windows.Forms.Padding(4)
        Me.Cbox_Facturas.Name = "Cbox_Facturas"
        Me.Cbox_Facturas.Size = New System.Drawing.Size(118, 29)
        Me.Cbox_Facturas.TabIndex = 39
        Me.Cbox_Facturas.Text = "Facturas"
        Me.Cbox_Facturas.UseVisualStyleBackColor = True
        '
        'Cbox_Clientes
        '
        Me.Cbox_Clientes.AutoSize = True
        Me.Cbox_Clientes.Checked = True
        Me.Cbox_Clientes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cbox_Clientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbox_Clientes.Location = New System.Drawing.Point(9, 145)
        Me.Cbox_Clientes.Margin = New System.Windows.Forms.Padding(4)
        Me.Cbox_Clientes.Name = "Cbox_Clientes"
        Me.Cbox_Clientes.Size = New System.Drawing.Size(112, 29)
        Me.Cbox_Clientes.TabIndex = 38
        Me.Cbox_Clientes.Text = "Clientes"
        Me.Cbox_Clientes.UseVisualStyleBackColor = True
        '
        'lbl_FechaReporte
        '
        Me.lbl_FechaReporte.AutoSize = True
        Me.lbl_FechaReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_FechaReporte.ForeColor = System.Drawing.Color.Black
        Me.lbl_FechaReporte.Location = New System.Drawing.Point(43, 9)
        Me.lbl_FechaReporte.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_FechaReporte.Name = "lbl_FechaReporte"
        Me.lbl_FechaReporte.Size = New System.Drawing.Size(189, 25)
        Me.lbl_FechaReporte.TabIndex = 33
        Me.lbl_FechaReporte.Text = "Reportes Facturas"
        '
        'DTP_FechaDesde
        '
        Me.DTP_FechaDesde.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_FechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_FechaDesde.Location = New System.Drawing.Point(109, 47)
        Me.DTP_FechaDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.DTP_FechaDesde.Name = "DTP_FechaDesde"
        Me.DTP_FechaDesde.Size = New System.Drawing.Size(155, 22)
        Me.DTP_FechaDesde.TabIndex = 32
        '
        'CBX_Param
        '
        Me.CBX_Param.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CBX_Param.AutoSize = True
        Me.CBX_Param.Enabled = False
        Me.CBX_Param.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBX_Param.Location = New System.Drawing.Point(1012, 47)
        Me.CBX_Param.Margin = New System.Windows.Forms.Padding(4)
        Me.CBX_Param.Name = "CBX_Param"
        Me.CBX_Param.Size = New System.Drawing.Size(144, 29)
        Me.CBX_Param.TabIndex = 17
        Me.CBX_Param.Text = "Parametros"
        Me.CBX_Param.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(17, 565)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(624, 29)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "CARGANDO INFORMACION POR FAVOR ESPERE..."
        Me.Label1.Visible = False
        '
        'ChBox_ClientexDia
        '
        Me.ChBox_ClientexDia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChBox_ClientexDia.Enabled = False
        Me.ChBox_ClientexDia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChBox_ClientexDia.Location = New System.Drawing.Point(1012, 82)
        Me.ChBox_ClientexDia.Margin = New System.Windows.Forms.Padding(4)
        Me.ChBox_ClientexDia.Name = "ChBox_ClientexDia"
        Me.ChBox_ClientexDia.Size = New System.Drawing.Size(181, 30)
        Me.ChBox_ClientexDia.TabIndex = 23
        Me.ChBox_ClientexDia.Text = "Clientes X Dia"
        Me.ChBox_ClientexDia.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Enabled = False
        Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(832, 47)
        Me.RadioButton1.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(125, 29)
        Me.RadioButton1.TabIndex = 24
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Servidor1"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Enabled = False
        Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(832, 82)
        Me.RadioButton2.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(125, 29)
        Me.RadioButton2.TabIndex = 25
        Me.RadioButton2.Text = "Servidor2"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'btn_HabilitarServidores
        '
        Me.btn_HabilitarServidores.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_HabilitarServidores.Enabled = False
        Me.btn_HabilitarServidores.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_HabilitarServidores.Location = New System.Drawing.Point(1015, 5)
        Me.btn_HabilitarServidores.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_HabilitarServidores.Name = "btn_HabilitarServidores"
        Me.btn_HabilitarServidores.Size = New System.Drawing.Size(178, 37)
        Me.btn_HabilitarServidores.TabIndex = 26
        Me.btn_HabilitarServidores.Text = "Habilitar"
        Me.btn_HabilitarServidores.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(916, 570)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 25)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Enviar a"
        Me.Label2.Visible = False
        '
        'CBox_VERPuestos
        '
        Me.CBox_VERPuestos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CBox_VERPuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBox_VERPuestos.FormattingEnabled = True
        Me.CBox_VERPuestos.Items.AddRange(New Object() {"AGENTE", "CHOFER"})
        Me.CBox_VERPuestos.Location = New System.Drawing.Point(1020, 562)
        Me.CBox_VERPuestos.Margin = New System.Windows.Forms.Padding(4)
        Me.CBox_VERPuestos.Name = "CBox_VERPuestos"
        Me.CBox_VERPuestos.Size = New System.Drawing.Size(178, 33)
        Me.CBox_VERPuestos.TabIndex = 31
        Me.CBox_VERPuestos.Visible = False
        '
        'DTP_FechaHasta
        '
        Me.DTP_FechaHasta.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_FechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_FechaHasta.Location = New System.Drawing.Point(109, 86)
        Me.DTP_FechaHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.DTP_FechaHasta.Name = "DTP_FechaHasta"
        Me.DTP_FechaHasta.Size = New System.Drawing.Size(155, 22)
        Me.DTP_FechaHasta.TabIndex = 34
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(22, 47)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 25)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Desde"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(22, 86)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 25)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Hasta"
        '
        'Enviar_Info_Seller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1210, 606)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DTP_FechaHasta)
        Me.Controls.Add(Me.CBox_VERPuestos)
        Me.Controls.Add(Me.lbl_FechaReporte)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DTP_FechaDesde)
        Me.Controls.Add(Me.btn_HabilitarServidores)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.ChBox_ClientexDia)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CBX_Param)
        Me.Controls.Add(Me.GroupBox7)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Enviar_Info_Seller"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ExportarInformacion"
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txb_Grupo As System.Windows.Forms.TextBox
    Friend WithEvents cbx_CatalogoDivido As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_TotalAgentes As System.Windows.Forms.Label
    Friend WithEvents lbl_AgentesProcesados As System.Windows.Forms.Label
    Friend WithEvents lbl_DetalleCarga As System.Windows.Forms.Label
    Friend WithEvents Prgs_CargaAgentes As System.Windows.Forms.ProgressBar
    Friend WithEvents btn_EnviarTodos As System.Windows.Forms.Button
    Friend WithEvents btn_ExpoInfo As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Cambiar As System.Windows.Forms.Button
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents TextB_Agente1 As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents TextB_Agente2 As System.Windows.Forms.TextBox
    Friend WithEvents TextB_Agente As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents CBX_Param As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChBox_ClientexDia As System.Windows.Forms.CheckBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents btn_HabilitarServidores As System.Windows.Forms.Button
    Friend WithEvents Label2 As Label
    Friend WithEvents CBox_VERPuestos As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lbl_FechaReporte As Label
    Friend WithEvents DTP_FechaDesde As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents DTP_FechaHasta As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Cbox_Cxc As CheckBox
    Friend WithEvents Cbox_Clientes As CheckBox
    Friend WithEvents Cbox_Facturas As CheckBox
    Friend WithEvents Cbox_Ubicaciones As CheckBox
    Friend WithEvents Cbox_Bancos As CheckBox
    Friend WithEvents Cbox_Razones As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents ListV_Reportes As ListView
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Cbox_MotivoDevolucion As CheckBox
End Class
