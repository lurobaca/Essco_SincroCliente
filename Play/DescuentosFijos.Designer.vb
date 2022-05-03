<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DescuentosFijos
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
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btn_Addexcepcion = New System.Windows.Forms.Button
        Me.cbx_Grupo = New System.Windows.Forms.ComboBox
        Me.cbx_Marca = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.cbx_Categoria = New System.Windows.Forms.ComboBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.txb_Desc = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.btn_agrega = New System.Windows.Forms.Button
        Me.btn_Modifica = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_Elimina = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txb_NombCliente = New System.Windows.Forms.TextBox
        Me.cbx_familia = New System.Windows.Forms.ComboBox
        Me.txb_CodCliente = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txb_CodArt = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txb_NombArticulo = New System.Windows.Forms.TextBox
        Me.txb_NombProveedor = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txb_CodProveedor = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.DGV_descFijos = New System.Windows.Forms.DataGridView
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btn_BuscClienDesc = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Panel12 = New System.Windows.Forms.Panel
        Me.cbx_Excepcion_Marca = New System.Windows.Forms.ComboBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.cbx_Excepcion_Categoria = New System.Windows.Forms.ComboBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.cbx_Excepcion_Familia = New System.Windows.Forms.ComboBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.btn_excepcion_add = New System.Windows.Forms.Button
        Me.btn_excepcion_Modifica = New System.Windows.Forms.Button
        Me.btn_excepcion_Delete = New System.Windows.Forms.Button
        Me.Label43 = New System.Windows.Forms.Label
        Me.txb_Excepcion_CodArti = New System.Windows.Forms.TextBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.txb_Excepcion_NombreArti = New System.Windows.Forms.TextBox
        Me.txb_Excepcion_NombreProveed = New System.Windows.Forms.TextBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.txb_Excepcion_CodProve = New System.Windows.Forms.TextBox
        Me.Label46 = New System.Windows.Forms.Label
        Me.DGV_descFijosExepciones = New System.Windows.Forms.DataGridView
        Me.Familia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Categoria = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DGV_descFijos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.DGV_descFijosExepciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.Panel1)
        Me.GroupBox4.Controls.Add(Me.btn_nuevo)
        Me.GroupBox4.Controls.Add(Me.DGV_descFijos)
        Me.GroupBox4.Controls.Add(Me.btn_BuscClienDesc)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(968, 326)
        Me.GroupBox4.TabIndex = 49
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Lista de descuentos Fijos"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.Controls.Add(Me.btn_Addexcepcion)
        Me.Panel1.Controls.Add(Me.cbx_Grupo)
        Me.Panel1.Controls.Add(Me.cbx_Marca)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label39)
        Me.Panel1.Controls.Add(Me.cbx_Categoria)
        Me.Panel1.Controls.Add(Me.Label38)
        Me.Panel1.Controls.Add(Me.txb_Desc)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.btn_agrega)
        Me.Panel1.Controls.Add(Me.btn_Modifica)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btn_Elimina)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txb_NombCliente)
        Me.Panel1.Controls.Add(Me.cbx_familia)
        Me.Panel1.Controls.Add(Me.txb_CodCliente)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txb_CodArt)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txb_NombArticulo)
        Me.Panel1.Controls.Add(Me.txb_NombProveedor)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txb_CodProveedor)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(6, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(543, 288)
        Me.Panel1.TabIndex = 45
        '
        'btn_Addexcepcion
        '
        Me.btn_Addexcepcion.Enabled = False
        Me.btn_Addexcepcion.Location = New System.Drawing.Point(299, 229)
        Me.btn_Addexcepcion.Name = "btn_Addexcepcion"
        Me.btn_Addexcepcion.Size = New System.Drawing.Size(91, 52)
        Me.btn_Addexcepcion.TabIndex = 53
        Me.btn_Addexcepcion.Text = "Nueva Excepcion"
        Me.btn_Addexcepcion.UseVisualStyleBackColor = True
        '
        'cbx_Grupo
        '
        Me.cbx_Grupo.FormattingEnabled = True
        Me.cbx_Grupo.Location = New System.Drawing.Point(404, 120)
        Me.cbx_Grupo.Name = "cbx_Grupo"
        Me.cbx_Grupo.Size = New System.Drawing.Size(120, 21)
        Me.cbx_Grupo.TabIndex = 51
        '
        'cbx_Marca
        '
        Me.cbx_Marca.FormattingEnabled = True
        Me.cbx_Marca.Location = New System.Drawing.Point(268, 120)
        Me.cbx_Marca.Name = "cbx_Marca"
        Me.cbx_Marca.Size = New System.Drawing.Size(120, 21)
        Me.cbx_Marca.TabIndex = 51
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(405, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 20)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "Grupo"
        '
        'Label39
        '
        Me.Label39.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(269, 100)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(56, 20)
        Me.Label39.TabIndex = 50
        Me.Label39.Text = "Marca"
        '
        'cbx_Categoria
        '
        Me.cbx_Categoria.FormattingEnabled = True
        Me.cbx_Categoria.Location = New System.Drawing.Point(139, 123)
        Me.cbx_Categoria.Name = "cbx_Categoria"
        Me.cbx_Categoria.Size = New System.Drawing.Size(120, 21)
        Me.cbx_Categoria.TabIndex = 49
        '
        'Label38
        '
        Me.Label38.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(140, 103)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(81, 20)
        Me.Label38.TabIndex = 48
        Me.Label38.Text = "Categoria"
        '
        'txb_Desc
        '
        Me.txb_Desc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txb_Desc.Location = New System.Drawing.Point(144, 203)
        Me.txb_Desc.Name = "txb_Desc"
        Me.txb_Desc.Size = New System.Drawing.Size(100, 20)
        Me.txb_Desc.TabIndex = 45
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(12, 203)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(110, 20)
        Me.Label18.TabIndex = 46
        Me.Label18.Text = "% Descuento"
        '
        'btn_agrega
        '
        Me.btn_agrega.Location = New System.Drawing.Point(16, 229)
        Me.btn_agrega.Name = "btn_agrega"
        Me.btn_agrega.Size = New System.Drawing.Size(91, 52)
        Me.btn_agrega.TabIndex = 42
        Me.btn_agrega.Text = "AGREGAR"
        Me.btn_agrega.UseVisualStyleBackColor = True
        '
        'btn_Modifica
        '
        Me.btn_Modifica.Location = New System.Drawing.Point(204, 229)
        Me.btn_Modifica.Name = "btn_Modifica"
        Me.btn_Modifica.Size = New System.Drawing.Size(91, 52)
        Me.btn_Modifica.TabIndex = 44
        Me.btn_Modifica.Text = "MODIFICAR"
        Me.btn_Modifica.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(140, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 20)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Nombre Cliente"
        '
        'btn_Elimina
        '
        Me.btn_Elimina.Location = New System.Drawing.Point(109, 229)
        Me.btn_Elimina.Name = "btn_Elimina"
        Me.btn_Elimina.Size = New System.Drawing.Size(91, 52)
        Me.btn_Elimina.TabIndex = 43
        Me.btn_Elimina.Text = "ELIMINAR"
        Me.btn_Elimina.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 20)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Cod Cliente"
        '
        'txb_NombCliente
        '
        Me.txb_NombCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txb_NombCliente.Location = New System.Drawing.Point(144, 32)
        Me.txb_NombCliente.Name = "txb_NombCliente"
        Me.txb_NombCliente.Size = New System.Drawing.Size(380, 20)
        Me.txb_NombCliente.TabIndex = 17
        '
        'cbx_familia
        '
        Me.cbx_familia.FormattingEnabled = True
        Me.cbx_familia.Location = New System.Drawing.Point(16, 123)
        Me.cbx_familia.Name = "cbx_familia"
        Me.cbx_familia.Size = New System.Drawing.Size(120, 21)
        Me.cbx_familia.TabIndex = 41
        '
        'txb_CodCliente
        '
        Me.txb_CodCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txb_CodCliente.Location = New System.Drawing.Point(16, 32)
        Me.txb_CodCliente.Name = "txb_CodCliente"
        Me.txb_CodCliente.Size = New System.Drawing.Size(100, 20)
        Me.txb_CodCliente.TabIndex = 16
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(12, 103)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(63, 20)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "Familia"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(140, 55)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(149, 20)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Nombre Proveedor"
        '
        'txb_CodArt
        '
        Me.txb_CodArt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txb_CodArt.Location = New System.Drawing.Point(16, 172)
        Me.txb_CodArt.Name = "txb_CodArt"
        Me.txb_CodArt.Size = New System.Drawing.Size(100, 20)
        Me.txb_CodArt.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 20)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Cod Proveedor"
        '
        'txb_NombArticulo
        '
        Me.txb_NombArticulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txb_NombArticulo.Location = New System.Drawing.Point(144, 172)
        Me.txb_NombArticulo.Name = "txb_NombArticulo"
        Me.txb_NombArticulo.Size = New System.Drawing.Size(380, 20)
        Me.txb_NombArticulo.TabIndex = 37
        '
        'txb_NombProveedor
        '
        Me.txb_NombProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txb_NombProveedor.Location = New System.Drawing.Point(144, 78)
        Me.txb_NombProveedor.Name = "txb_NombProveedor"
        Me.txb_NombProveedor.Size = New System.Drawing.Size(380, 20)
        Me.txb_NombProveedor.TabIndex = 33
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 149)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 20)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Cod Articulo"
        '
        'txb_CodProveedor
        '
        Me.txb_CodProveedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txb_CodProveedor.Location = New System.Drawing.Point(16, 78)
        Me.txb_CodProveedor.Name = "txb_CodProveedor"
        Me.txb_CodProveedor.Size = New System.Drawing.Size(100, 20)
        Me.txb_CodProveedor.TabIndex = 32
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(140, 149)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(130, 20)
        Me.Label16.TabIndex = 38
        Me.Label16.Text = "Nombre Articulo"
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Location = New System.Drawing.Point(576, 72)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(91, 52)
        Me.btn_nuevo.TabIndex = 52
        Me.btn_nuevo.Text = "NUEVO"
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'DGV_descFijos
        '
        Me.DGV_descFijos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_descFijos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_descFijos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id})
        Me.DGV_descFijos.Location = New System.Drawing.Point(681, 26)
        Me.DGV_descFijos.Name = "DGV_descFijos"
        Me.DGV_descFijos.Size = New System.Drawing.Size(281, 294)
        Me.DGV_descFijos.TabIndex = 1
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        '
        'btn_BuscClienDesc
        '
        Me.btn_BuscClienDesc.Location = New System.Drawing.Point(576, 125)
        Me.btn_BuscClienDesc.Name = "btn_BuscClienDesc"
        Me.btn_BuscClienDesc.Size = New System.Drawing.Size(91, 52)
        Me.btn_BuscClienDesc.TabIndex = 47
        Me.btn_BuscClienDesc.Text = "BUSCAR"
        Me.btn_BuscClienDesc.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.Panel12)
        Me.GroupBox5.Controls.Add(Me.DGV_descFijosExepciones)
        Me.GroupBox5.Location = New System.Drawing.Point(10, 344)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(970, 275)
        Me.GroupBox5.TabIndex = 50
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Excepciones"
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel12.Controls.Add(Me.cbx_Excepcion_Marca)
        Me.Panel12.Controls.Add(Me.Label40)
        Me.Panel12.Controls.Add(Me.cbx_Excepcion_Categoria)
        Me.Panel12.Controls.Add(Me.Label41)
        Me.Panel12.Controls.Add(Me.cbx_Excepcion_Familia)
        Me.Panel12.Controls.Add(Me.Label42)
        Me.Panel12.Controls.Add(Me.btn_excepcion_add)
        Me.Panel12.Controls.Add(Me.btn_excepcion_Modifica)
        Me.Panel12.Controls.Add(Me.btn_excepcion_Delete)
        Me.Panel12.Controls.Add(Me.Label43)
        Me.Panel12.Controls.Add(Me.txb_Excepcion_CodArti)
        Me.Panel12.Controls.Add(Me.Label44)
        Me.Panel12.Controls.Add(Me.txb_Excepcion_NombreArti)
        Me.Panel12.Controls.Add(Me.txb_Excepcion_NombreProveed)
        Me.Panel12.Controls.Add(Me.Label45)
        Me.Panel12.Controls.Add(Me.txb_Excepcion_CodProve)
        Me.Panel12.Controls.Add(Me.Label46)
        Me.Panel12.Enabled = False
        Me.Panel12.Location = New System.Drawing.Point(6, 19)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(543, 240)
        Me.Panel12.TabIndex = 47
        '
        'cbx_Excepcion_Marca
        '
        Me.cbx_Excepcion_Marca.FormattingEnabled = True
        Me.cbx_Excepcion_Marca.Location = New System.Drawing.Point(397, 80)
        Me.cbx_Excepcion_Marca.Name = "cbx_Excepcion_Marca"
        Me.cbx_Excepcion_Marca.Size = New System.Drawing.Size(120, 21)
        Me.cbx_Excepcion_Marca.TabIndex = 57
        '
        'Label40
        '
        Me.Label40.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(398, 60)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(56, 20)
        Me.Label40.TabIndex = 56
        Me.Label40.Text = "Marca"
        '
        'cbx_Excepcion_Categoria
        '
        Me.cbx_Excepcion_Categoria.FormattingEnabled = True
        Me.cbx_Excepcion_Categoria.Location = New System.Drawing.Point(204, 80)
        Me.cbx_Excepcion_Categoria.Name = "cbx_Excepcion_Categoria"
        Me.cbx_Excepcion_Categoria.Size = New System.Drawing.Size(120, 21)
        Me.cbx_Excepcion_Categoria.TabIndex = 55
        '
        'Label41
        '
        Me.Label41.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(205, 60)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(81, 20)
        Me.Label41.TabIndex = 54
        Me.Label41.Text = "Categoria"
        '
        'cbx_Excepcion_Familia
        '
        Me.cbx_Excepcion_Familia.FormattingEnabled = True
        Me.cbx_Excepcion_Familia.Location = New System.Drawing.Point(16, 80)
        Me.cbx_Excepcion_Familia.Name = "cbx_Excepcion_Familia"
        Me.cbx_Excepcion_Familia.Size = New System.Drawing.Size(120, 21)
        Me.cbx_Excepcion_Familia.TabIndex = 53
        '
        'Label42
        '
        Me.Label42.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(12, 60)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(63, 20)
        Me.Label42.TabIndex = 52
        Me.Label42.Text = "Familia"
        '
        'btn_excepcion_add
        '
        Me.btn_excepcion_add.Location = New System.Drawing.Point(7, 178)
        Me.btn_excepcion_add.Name = "btn_excepcion_add"
        Me.btn_excepcion_add.Size = New System.Drawing.Size(91, 52)
        Me.btn_excepcion_add.TabIndex = 42
        Me.btn_excepcion_add.Text = "AGREGAR"
        Me.btn_excepcion_add.UseVisualStyleBackColor = True
        '
        'btn_excepcion_Modifica
        '
        Me.btn_excepcion_Modifica.Location = New System.Drawing.Point(192, 178)
        Me.btn_excepcion_Modifica.Name = "btn_excepcion_Modifica"
        Me.btn_excepcion_Modifica.Size = New System.Drawing.Size(91, 52)
        Me.btn_excepcion_Modifica.TabIndex = 44
        Me.btn_excepcion_Modifica.Text = "MODIFICAR"
        Me.btn_excepcion_Modifica.UseVisualStyleBackColor = True
        '
        'btn_excepcion_Delete
        '
        Me.btn_excepcion_Delete.Location = New System.Drawing.Point(99, 178)
        Me.btn_excepcion_Delete.Name = "btn_excepcion_Delete"
        Me.btn_excepcion_Delete.Size = New System.Drawing.Size(91, 52)
        Me.btn_excepcion_Delete.TabIndex = 43
        Me.btn_excepcion_Delete.Text = "ELIMINAR"
        Me.btn_excepcion_Delete.UseVisualStyleBackColor = True
        '
        'Label43
        '
        Me.Label43.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(140, 14)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(149, 20)
        Me.Label43.TabIndex = 34
        Me.Label43.Text = "Nombre Proveedor"
        '
        'txb_Excepcion_CodArti
        '
        Me.txb_Excepcion_CodArti.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txb_Excepcion_CodArti.Location = New System.Drawing.Point(16, 152)
        Me.txb_Excepcion_CodArti.Name = "txb_Excepcion_CodArti"
        Me.txb_Excepcion_CodArti.Size = New System.Drawing.Size(100, 20)
        Me.txb_Excepcion_CodArti.TabIndex = 36
        '
        'Label44
        '
        Me.Label44.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(12, 14)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(120, 20)
        Me.Label44.TabIndex = 35
        Me.Label44.Text = "Cod Proveedor"
        '
        'txb_Excepcion_NombreArti
        '
        Me.txb_Excepcion_NombreArti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txb_Excepcion_NombreArti.Location = New System.Drawing.Point(144, 152)
        Me.txb_Excepcion_NombreArti.Name = "txb_Excepcion_NombreArti"
        Me.txb_Excepcion_NombreArti.Size = New System.Drawing.Size(380, 20)
        Me.txb_Excepcion_NombreArti.TabIndex = 37
        '
        'txb_Excepcion_NombreProveed
        '
        Me.txb_Excepcion_NombreProveed.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txb_Excepcion_NombreProveed.Location = New System.Drawing.Point(144, 37)
        Me.txb_Excepcion_NombreProveed.Name = "txb_Excepcion_NombreProveed"
        Me.txb_Excepcion_NombreProveed.Size = New System.Drawing.Size(380, 20)
        Me.txb_Excepcion_NombreProveed.TabIndex = 33
        '
        'Label45
        '
        Me.Label45.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(12, 117)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(101, 20)
        Me.Label45.TabIndex = 39
        Me.Label45.Text = "Cod Articulo"
        '
        'txb_Excepcion_CodProve
        '
        Me.txb_Excepcion_CodProve.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txb_Excepcion_CodProve.Location = New System.Drawing.Point(16, 37)
        Me.txb_Excepcion_CodProve.Name = "txb_Excepcion_CodProve"
        Me.txb_Excepcion_CodProve.Size = New System.Drawing.Size(100, 20)
        Me.txb_Excepcion_CodProve.TabIndex = 32
        '
        'Label46
        '
        Me.Label46.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(140, 117)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(130, 20)
        Me.Label46.TabIndex = 38
        Me.Label46.Text = "Nombre Articulo"
        '
        'DGV_descFijosExepciones
        '
        Me.DGV_descFijosExepciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_descFijosExepciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_descFijosExepciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Familia, Me.Categoria})
        Me.DGV_descFijosExepciones.Location = New System.Drawing.Point(681, 19)
        Me.DGV_descFijosExepciones.Name = "DGV_descFijosExepciones"
        Me.DGV_descFijosExepciones.Size = New System.Drawing.Size(280, 247)
        Me.DGV_descFijosExepciones.TabIndex = 29
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
        'DescuentosFijos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 623)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "DescuentosFijos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DescuentosFijos"
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGV_descFijos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        CType(Me.DGV_descFijosExepciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_Addexcepcion As System.Windows.Forms.Button
    Friend WithEvents cbx_Marca As System.Windows.Forms.ComboBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents cbx_Categoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txb_Desc As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btn_agrega As System.Windows.Forms.Button
    Friend WithEvents btn_Modifica As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_Elimina As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txb_NombCliente As System.Windows.Forms.TextBox
    Friend WithEvents cbx_familia As System.Windows.Forms.ComboBox
    Friend WithEvents txb_CodCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txb_CodArt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txb_NombArticulo As System.Windows.Forms.TextBox
    Friend WithEvents txb_NombProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txb_CodProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents DGV_descFijos As System.Windows.Forms.DataGridView
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_BuscClienDesc As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents cbx_Excepcion_Marca As System.Windows.Forms.ComboBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents cbx_Excepcion_Categoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents cbx_Excepcion_Familia As System.Windows.Forms.ComboBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents btn_excepcion_add As System.Windows.Forms.Button
    Friend WithEvents btn_excepcion_Modifica As System.Windows.Forms.Button
    Friend WithEvents btn_excepcion_Delete As System.Windows.Forms.Button
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txb_Excepcion_CodArti As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents txb_Excepcion_NombreArti As System.Windows.Forms.TextBox
    Friend WithEvents txb_Excepcion_NombreProveed As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents txb_Excepcion_CodProve As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents DGV_descFijosExepciones As System.Windows.Forms.DataGridView
    Friend WithEvents Familia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Categoria As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbx_Grupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
