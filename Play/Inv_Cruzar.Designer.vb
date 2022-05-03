<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inv_Cruzar
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtb_DifMayor = New System.Windows.Forms.TextBox()
        Me.txtb_Grupo2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GBX3 = New System.Windows.Forms.GroupBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.GBX1 = New System.Windows.Forms.GroupBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Lbl_Cruzar = New System.Windows.Forms.Label()
        Me.txtb_G1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_Ejecutar = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Txtb_Grupo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txtb_Sector = New System.Windows.Forms.TextBox()
        Me.btn_CruzaUnidicaGrupos = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Txb_CodInventario = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GBX2 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtb_NomProveedor = New System.Windows.Forms.TextBox()
        Me.txtb_Responsable2 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtb_Responsable = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btn_Proveedores = New System.Windows.Forms.Button()
        Me.TXB_GrupoDif = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txb_CodProveedor = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lbl_Inicio = New System.Windows.Forms.Label()
        Me.Lbl_Detaller = New System.Windows.Forms.Label()
        Me.ProgBar = New System.Windows.Forms.ProgressBar()
        Me.Lbl_Fin = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GBX3.SuspendLayout()
        Me.GBX1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GBX2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtb_DifMayor)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 368)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(828, 43)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Diferencias a cargar"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(205, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 15)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "MAYORES Y MENOR A"
        '
        'txtb_DifMayor
        '
        Me.txtb_DifMayor.Location = New System.Drawing.Point(382, 15)
        Me.txtb_DifMayor.Name = "txtb_DifMayor"
        Me.txtb_DifMayor.Size = New System.Drawing.Size(193, 23)
        Me.txtb_DifMayor.TabIndex = 8
        Me.txtb_DifMayor.Text = "0"
        '
        'txtb_Grupo2
        '
        Me.txtb_Grupo2.BackColor = System.Drawing.Color.White
        Me.txtb_Grupo2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtb_Grupo2.Enabled = False
        Me.txtb_Grupo2.Location = New System.Drawing.Point(9, 46)
        Me.txtb_Grupo2.Name = "txtb_Grupo2"
        Me.txtb_Grupo2.ReadOnly = True
        Me.txtb_Grupo2.Size = New System.Drawing.Size(96, 23)
        Me.txtb_Grupo2.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.txtb_Grupo2, "Indicar el grupo para cruzar sus conteos contra el stock")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 17)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Grupo"
        '
        'GBX3
        '
        Me.GBX3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GBX3.Controls.Add(Me.Button7)
        Me.GBX3.Controls.Add(Me.txtb_Grupo2)
        Me.GBX3.Controls.Add(Me.Label5)
        Me.GBX3.Enabled = False
        Me.GBX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBX3.Location = New System.Drawing.Point(202, 300)
        Me.GBX3.Name = "GBX3"
        Me.GBX3.Size = New System.Drawing.Size(629, 75)
        Me.GBX3.TabIndex = 15
        Me.GBX3.TabStop = False
        Me.GBX3.Text = "Cruza Contra Sistema"
        Me.ToolTip2.SetToolTip(Me.GBX3, "Compara lo contado del grupo indicado contra el inventario del sistema , lo que s" &
        "ea igual se quita de  la lista asi como las lineas que no cumplan las condicione" &
        "s de los montos ")
        '
        'Button7
        '
        Me.Button7.BackgroundImage = Global.SincroCliente.My.Resources.Resources.lupa3
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button7.Location = New System.Drawing.Point(111, 43)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(42, 26)
        Me.Button7.TabIndex = 41
        Me.Button7.UseVisualStyleBackColor = True
        '
        'GBX1
        '
        Me.GBX1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GBX1.Controls.Add(Me.Button6)
        Me.GBX1.Controls.Add(Me.Lbl_Cruzar)
        Me.GBX1.Controls.Add(Me.txtb_G1)
        Me.GBX1.Controls.Add(Me.Label1)
        Me.GBX1.Enabled = False
        Me.GBX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBX1.Location = New System.Drawing.Point(206, 44)
        Me.GBX1.Name = "GBX1"
        Me.GBX1.Size = New System.Drawing.Size(629, 79)
        Me.GBX1.TabIndex = 16
        Me.GBX1.TabStop = False
        Me.GBX1.Text = "Cruzar entre Grupos"
        Me.ToolTip1.SetToolTip(Me.GBX1, "Compara el conteo 1 y 2 de el grupo indicado, si son iguales los quita de la list" &
        "a")
        '
        'Button6
        '
        Me.Button6.BackgroundImage = Global.SincroCliente.My.Resources.Resources.lupa3
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button6.Location = New System.Drawing.Point(111, 47)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(42, 26)
        Me.Button6.TabIndex = 40
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Lbl_Cruzar
        '
        Me.Lbl_Cruzar.AutoSize = True
        Me.Lbl_Cruzar.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Cruzar.Location = New System.Drawing.Point(205, 24)
        Me.Lbl_Cruzar.Name = "Lbl_Cruzar"
        Me.Lbl_Cruzar.Size = New System.Drawing.Size(0, 26)
        Me.Lbl_Cruzar.TabIndex = 10
        '
        'txtb_G1
        '
        Me.txtb_G1.BackColor = System.Drawing.Color.White
        Me.txtb_G1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtb_G1.Location = New System.Drawing.Point(9, 50)
        Me.txtb_G1.Name = "txtb_G1"
        Me.txtb_G1.ReadOnly = True
        Me.txtb_G1.Size = New System.Drawing.Size(96, 23)
        Me.txtb_G1.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.txtb_G1, "Indicar el Grupo el cual se cruzara su conteo 1 y 2")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Grupo"
        '
        'btn_Ejecutar
        '
        Me.btn_Ejecutar.Enabled = False
        Me.btn_Ejecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Ejecutar.Location = New System.Drawing.Point(243, 494)
        Me.btn_Ejecutar.Name = "btn_Ejecutar"
        Me.btn_Ejecutar.Size = New System.Drawing.Size(290, 35)
        Me.btn_Ejecutar.TabIndex = 7
        Me.btn_Ejecutar.Text = "Ejecutar"
        Me.btn_Ejecutar.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Txtb_Grupo)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Txtb_Sector)
        Me.GroupBox4.Controls.Add(Me.btn_CruzaUnidicaGrupos)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 612)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(424, 91)
        Me.GroupBox4.TabIndex = 16
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Cruza Contra Sistema-Unifica Lineas"
        Me.ToolTip3.SetToolTip(Me.GroupBox4, "Asigna las lineas de diversos grupos en uno solo ")
        Me.GroupBox4.Visible = False
        '
        'Txtb_Grupo
        '
        Me.Txtb_Grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtb_Grupo.Location = New System.Drawing.Point(51, 49)
        Me.Txtb_Grupo.Name = "Txtb_Grupo"
        Me.Txtb_Grupo.Size = New System.Drawing.Size(138, 20)
        Me.Txtb_Grupo.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Grupo"
        '
        'Txtb_Sector
        '
        Me.Txtb_Sector.Location = New System.Drawing.Point(51, 23)
        Me.Txtb_Sector.Name = "Txtb_Sector"
        Me.Txtb_Sector.Size = New System.Drawing.Size(138, 20)
        Me.Txtb_Sector.TabIndex = 14
        '
        'btn_CruzaUnidicaGrupos
        '
        Me.btn_CruzaUnidicaGrupos.Location = New System.Drawing.Point(330, 26)
        Me.btn_CruzaUnidicaGrupos.Name = "btn_CruzaUnidicaGrupos"
        Me.btn_CruzaUnidicaGrupos.Size = New System.Drawing.Size(80, 35)
        Me.btn_CruzaUnidicaGrupos.TabIndex = 12
        Me.btn_CruzaUnidicaGrupos.Text = "Cruzar "
        Me.btn_CruzaUnidicaGrupos.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Sector"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackgroundImage = Global.SincroCliente.My.Resources.Resources.lupa3
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(193, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 30)
        Me.Button1.TabIndex = 18
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Txb_CodInventario
        '
        Me.Txb_CodInventario.Enabled = False
        Me.Txb_CodInventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_CodInventario.Location = New System.Drawing.Point(91, 15)
        Me.Txb_CodInventario.Name = "Txb_CodInventario"
        Me.Txb_CodInventario.Size = New System.Drawing.Size(96, 23)
        Me.Txb_CodInventario.TabIndex = 17
        Me.ToolTip1.SetToolTip(Me.Txb_CodInventario, "Indicar el codigo del inventario")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 17)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Inventario"
        '
        'ToolTip1
        '
        Me.ToolTip1.Tag = ""
        '
        'GBX2
        '
        Me.GBX2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GBX2.Controls.Add(Me.Label14)
        Me.GBX2.Controls.Add(Me.txtb_NomProveedor)
        Me.GBX2.Controls.Add(Me.txtb_Responsable2)
        Me.GBX2.Controls.Add(Me.Label13)
        Me.GBX2.Controls.Add(Me.txtb_Responsable)
        Me.GBX2.Controls.Add(Me.Label12)
        Me.GBX2.Controls.Add(Me.btn_Proveedores)
        Me.GBX2.Controls.Add(Me.TXB_GrupoDif)
        Me.GBX2.Controls.Add(Me.Label9)
        Me.GBX2.Controls.Add(Me.txb_CodProveedor)
        Me.GBX2.Controls.Add(Me.Label8)
        Me.GBX2.Enabled = False
        Me.GBX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBX2.Location = New System.Drawing.Point(206, 144)
        Me.GBX2.Name = "GBX2"
        Me.GBX2.Size = New System.Drawing.Size(629, 125)
        Me.GBX2.TabIndex = 17
        Me.GBX2.TabStop = False
        Me.GBX2.Text = "Unifica Conteos y Cruza contra Sistema"
        Me.ToolTip1.SetToolTip(Me.GBX2, "Compara el conteo 1 y 2 de el grupo indicado, si son iguales los quita de la list" &
        "a")
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(111, 28)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(128, 17)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "Nombre Proveedor"
        '
        'txtb_NomProveedor
        '
        Me.txtb_NomProveedor.BackColor = System.Drawing.Color.White
        Me.txtb_NomProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtb_NomProveedor.Enabled = False
        Me.txtb_NomProveedor.Location = New System.Drawing.Point(111, 48)
        Me.txtb_NomProveedor.Name = "txtb_NomProveedor"
        Me.txtb_NomProveedor.ReadOnly = True
        Me.txtb_NomProveedor.Size = New System.Drawing.Size(256, 23)
        Me.txtb_NomProveedor.TabIndex = 44
        '
        'txtb_Responsable2
        '
        Me.txtb_Responsable2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtb_Responsable2.Location = New System.Drawing.Point(243, 98)
        Me.txtb_Responsable2.Name = "txtb_Responsable2"
        Me.txtb_Responsable2.Size = New System.Drawing.Size(127, 23)
        Me.txtb_Responsable2.TabIndex = 43
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(240, 77)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(103, 17)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "Responsable 2"
        '
        'txtb_Responsable
        '
        Me.txtb_Responsable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtb_Responsable.Location = New System.Drawing.Point(111, 98)
        Me.txtb_Responsable.Name = "txtb_Responsable"
        Me.txtb_Responsable.Size = New System.Drawing.Size(127, 23)
        Me.txtb_Responsable.TabIndex = 41
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(111, 77)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 17)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Responsable 1"
        '
        'btn_Proveedores
        '
        Me.btn_Proveedores.BackgroundImage = Global.SincroCliente.My.Resources.Resources.lupa3
        Me.btn_Proveedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_Proveedores.Location = New System.Drawing.Point(378, 43)
        Me.btn_Proveedores.Name = "btn_Proveedores"
        Me.btn_Proveedores.Size = New System.Drawing.Size(42, 26)
        Me.btn_Proveedores.TabIndex = 38
        Me.btn_Proveedores.UseVisualStyleBackColor = True
        '
        'TXB_GrupoDif
        '
        Me.TXB_GrupoDif.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXB_GrupoDif.Location = New System.Drawing.Point(10, 98)
        Me.TXB_GrupoDif.Name = "TXB_GrupoDif"
        Me.TXB_GrupoDif.Size = New System.Drawing.Size(95, 23)
        Me.TXB_GrupoDif.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 77)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 17)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Nuevo Grupo"
        '
        'txb_CodProveedor
        '
        Me.txb_CodProveedor.BackColor = System.Drawing.Color.White
        Me.txb_CodProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txb_CodProveedor.Enabled = False
        Me.txb_CodProveedor.Location = New System.Drawing.Point(9, 48)
        Me.txb_CodProveedor.Name = "txb_CodProveedor"
        Me.txb_CodProveedor.ReadOnly = True
        Me.txb_CodProveedor.Size = New System.Drawing.Size(96, 23)
        Me.txb_CodProveedor.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.txb_CodProveedor, "Indicar el codigo del proveedor")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 17)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Codigo"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Lbl_Inicio)
        Me.Panel1.Controls.Add(Me.Lbl_Detaller)
        Me.Panel1.Controls.Add(Me.ProgBar)
        Me.Panel1.Controls.Add(Me.Lbl_Fin)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 426)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(828, 62)
        Me.Panel1.TabIndex = 35
        '
        'Lbl_Inicio
        '
        Me.Lbl_Inicio.AutoSize = True
        Me.Lbl_Inicio.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_Inicio.Name = "Lbl_Inicio"
        Me.Lbl_Inicio.Size = New System.Drawing.Size(40, 17)
        Me.Lbl_Inicio.TabIndex = 31
        Me.Lbl_Inicio.Text = "Inicio"
        '
        'Lbl_Detaller
        '
        Me.Lbl_Detaller.AutoSize = True
        Me.Lbl_Detaller.Location = New System.Drawing.Point(48, 29)
        Me.Lbl_Detaller.Name = "Lbl_Detaller"
        Me.Lbl_Detaller.Size = New System.Drawing.Size(52, 17)
        Me.Lbl_Detaller.TabIndex = 33
        Me.Lbl_Detaller.Text = "Detalle"
        '
        'ProgBar
        '
        Me.ProgBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgBar.Location = New System.Drawing.Point(51, 3)
        Me.ProgBar.Name = "ProgBar"
        Me.ProgBar.Size = New System.Drawing.Size(740, 23)
        Me.ProgBar.TabIndex = 30
        '
        'Lbl_Fin
        '
        Me.Lbl_Fin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Fin.AutoSize = True
        Me.Lbl_Fin.Location = New System.Drawing.Point(797, 8)
        Me.Lbl_Fin.Name = "Lbl_Fin"
        Me.Lbl_Fin.Size = New System.Drawing.Size(27, 17)
        Me.Lbl_Fin.TabIndex = 32
        Me.Lbl_Fin.Text = "Fin"
        '
        'Timer1
        '
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(12, 86)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(190, 35)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Cruzar Entre Grupos"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(12, 172)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(190, 35)
        Me.Button4.TabIndex = 36
        Me.Button4.Text = " Unificar x Proveedor"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(7, 321)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(190, 35)
        Me.Button5.TabIndex = 37
        Me.Button5.Text = "Diferencia Contra Sistema"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 17)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "PASO 1"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(18, 151)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 17)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "PASO 2"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 300)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 17)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "PASO 3"
        '
        'Inv_Cruzar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(847, 535)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.btn_Ejecutar)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.GBX2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Txb_CodInventario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GBX1)
        Me.Controls.Add(Me.GBX3)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "Inv_Cruzar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cruzar"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GBX3.ResumeLayout(False)
        Me.GBX3.PerformLayout()
        Me.GBX1.ResumeLayout(False)
        Me.GBX1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GBX2.ResumeLayout(False)
        Me.GBX2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtb_Grupo2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GBX3 As System.Windows.Forms.GroupBox
    Friend WithEvents GBX1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtb_G1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_Ejecutar As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Txtb_Grupo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Txtb_Sector As System.Windows.Forms.TextBox
    Friend WithEvents btn_CruzaUnidicaGrupos As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Txb_CodInventario As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip3 As System.Windows.Forms.ToolTip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Lbl_Inicio As System.Windows.Forms.Label
    Friend WithEvents Lbl_Detaller As System.Windows.Forms.Label
    Friend WithEvents ProgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Lbl_Fin As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GBX2 As System.Windows.Forms.GroupBox
    Friend WithEvents txb_CodProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXB_GrupoDif As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Cruzar As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents txtb_DifMayor As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_Proveedores As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents txtb_Responsable2 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtb_Responsable As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtb_NomProveedor As TextBox
End Class
