<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Stock_Manager
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtb_ItemCode = New System.Windows.Forms.TextBox()
        Me.CBox_TipoProducto = New System.Windows.Forms.ComboBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.txtb_Descripcion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtb_CodBarras = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtb_CodProveedor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtb_CodAlterno = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtb_Ancho = New System.Windows.Forms.TextBox()
        Me.lbl_Ancho = New System.Windows.Forms.Label()
        Me.txtb_Largo = New System.Windows.Forms.TextBox()
        Me.Lbl_Largo = New System.Windows.Forms.Label()
        Me.txtb_Volumen = New System.Windows.Forms.TextBox()
        Me.Lbl_Volumen = New System.Windows.Forms.Label()
        Me.txtb_UnidMedida = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CkBox_SujetoAImpuesto = New System.Windows.Forms.CheckBox()
        Me.lbl_ListaPrecios = New System.Windows.Forms.Label()
        Me.CBox_ListPrecio = New System.Windows.Forms.ComboBox()
        Me.txtb_PrecioCosto = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.RBtn_Activo = New System.Windows.Forms.RadioButton()
        Me.RBtn_Inactivo = New System.Windows.Forms.RadioButton()
        Me.txtb_RazonInactivo = New System.Windows.Forms.TextBox()
        Me.lbl_Razon = New System.Windows.Forms.Label()
        Me.txtb_InactivoDesde = New System.Windows.Forms.TextBox()
        Me.lbl_Desde = New System.Windows.Forms.Label()
        Me.txtb_Comentarios = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btn_BuscaProveedores = New System.Windows.Forms.Button()
        Me.txtb_Empaque = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Txtb_Gramos = New System.Windows.Forms.TextBox()
        Me.txtb_PartidaArancelaria = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.ComBox_CodTarifa = New System.Windows.Forms.ComboBox()
        Me.txtb_imp = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.btn_Marca = New System.Windows.Forms.Button()
        Me.btn_Categoria = New System.Windows.Forms.Button()
        Me.btn_Familia = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.CBox_Marca = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.CBox_Categoria = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CBox_Familia = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.CBox_Transaccion = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.CBox_CodBodega = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.DTP_TransaccionHasta = New System.Windows.Forms.DateTimePicker()
        Me.DTP_TransaccionDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.btn_AgregarAlternativo = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.btn_EliminarFoto = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CBox_IDFotos = New System.Windows.Forms.ComboBox()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_AdjuntaFoto = New System.Windows.Forms.Button()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Txtb_Width = New System.Windows.Forms.TextBox()
        Me.Txtb_Height = New System.Windows.Forms.TextBox()
        Me.trackBar1 = New System.Windows.Forms.TrackBar()
        Me.txtb_zooFactor = New System.Windows.Forms.TextBox()
        Me.btn_Guardar = New System.Windows.Forms.Button()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.btn_CrearEnSAP = New System.Windows.Forms.Button()
        Me.lbl_LineaNueva = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CBox_GrupoArticulo = New System.Windows.Forms.ComboBox()
        Me.Txtb_NombreExtrangero = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Txtb_CodCabys = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Cbox_Ubicacion = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Txtb_IdArticuloNuevo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txtb_IdArticulo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txt_PorcUtilidad = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txtb_PrecioVenta = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.btn_CargarPlantilla = New System.Windows.Forms.Button()
        Me.btn_DescargarPlantilla = New System.Windows.Forms.Button()
        Me.CBox_Moneda = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        Me.panel2.SuspendLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo"
        '
        'txtb_ItemCode
        '
        Me.txtb_ItemCode.Location = New System.Drawing.Point(110, 15)
        Me.txtb_ItemCode.Name = "txtb_ItemCode"
        Me.txtb_ItemCode.Size = New System.Drawing.Size(113, 20)
        Me.txtb_ItemCode.TabIndex = 1
        '
        'CBox_TipoProducto
        '
        Me.CBox_TipoProducto.FormattingEnabled = True
        Me.CBox_TipoProducto.Items.AddRange(New Object() {"Articulo", "Servicio"})
        Me.CBox_TipoProducto.Location = New System.Drawing.Point(271, 13)
        Me.CBox_TipoProducto.Name = "CBox_TipoProducto"
        Me.CBox_TipoProducto.Size = New System.Drawing.Size(82, 21)
        Me.CBox_TipoProducto.TabIndex = 2
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Location = New System.Drawing.Point(234, 15)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(28, 13)
        Me.lblTipo.TabIndex = 3
        Me.lblTipo.Text = "Tipo"
        '
        'txtb_Descripcion
        '
        Me.txtb_Descripcion.Location = New System.Drawing.Point(111, 36)
        Me.txtb_Descripcion.Name = "txtb_Descripcion"
        Me.txtb_Descripcion.Size = New System.Drawing.Size(487, 20)
        Me.txtb_Descripcion.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Descripcion"
        '
        'txtb_CodBarras
        '
        Me.txtb_CodBarras.Location = New System.Drawing.Point(368, 80)
        Me.txtb_CodBarras.Name = "txtb_CodBarras"
        Me.txtb_CodBarras.Size = New System.Drawing.Size(230, 20)
        Me.txtb_CodBarras.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(272, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Codido de Barras"
        '
        'txtb_CodProveedor
        '
        Me.txtb_CodProveedor.Location = New System.Drawing.Point(85, 63)
        Me.txtb_CodProveedor.Name = "txtb_CodProveedor"
        Me.txtb_CodProveedor.Size = New System.Drawing.Size(100, 20)
        Me.txtb_CodProveedor.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Proveedor"
        '
        'txtb_CodAlterno
        '
        Me.txtb_CodAlterno.Location = New System.Drawing.Point(419, 132)
        Me.txtb_CodAlterno.Name = "txtb_CodAlterno"
        Me.txtb_CodAlterno.Size = New System.Drawing.Size(100, 20)
        Me.txtb_CodAlterno.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(239, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(172, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Numero del catalogo del fabricante"
        '
        'txtb_Ancho
        '
        Me.txtb_Ancho.Location = New System.Drawing.Point(85, 111)
        Me.txtb_Ancho.Name = "txtb_Ancho"
        Me.txtb_Ancho.Size = New System.Drawing.Size(100, 20)
        Me.txtb_Ancho.TabIndex = 14
        Me.txtb_Ancho.Text = "0"
        '
        'lbl_Ancho
        '
        Me.lbl_Ancho.AutoSize = True
        Me.lbl_Ancho.Location = New System.Drawing.Point(19, 114)
        Me.lbl_Ancho.Name = "lbl_Ancho"
        Me.lbl_Ancho.Size = New System.Drawing.Size(38, 13)
        Me.lbl_Ancho.TabIndex = 13
        Me.lbl_Ancho.Text = "Ancho"
        '
        'txtb_Largo
        '
        Me.txtb_Largo.Location = New System.Drawing.Point(85, 136)
        Me.txtb_Largo.Name = "txtb_Largo"
        Me.txtb_Largo.Size = New System.Drawing.Size(100, 20)
        Me.txtb_Largo.TabIndex = 16
        Me.txtb_Largo.Text = "0"
        '
        'Lbl_Largo
        '
        Me.Lbl_Largo.AutoSize = True
        Me.Lbl_Largo.Location = New System.Drawing.Point(19, 139)
        Me.Lbl_Largo.Name = "Lbl_Largo"
        Me.Lbl_Largo.Size = New System.Drawing.Size(34, 13)
        Me.Lbl_Largo.TabIndex = 15
        Me.Lbl_Largo.Text = "Largo"
        '
        'txtb_Volumen
        '
        Me.txtb_Volumen.Location = New System.Drawing.Point(85, 162)
        Me.txtb_Volumen.Name = "txtb_Volumen"
        Me.txtb_Volumen.Size = New System.Drawing.Size(100, 20)
        Me.txtb_Volumen.TabIndex = 18
        Me.txtb_Volumen.Text = "0"
        '
        'Lbl_Volumen
        '
        Me.Lbl_Volumen.AutoSize = True
        Me.Lbl_Volumen.Location = New System.Drawing.Point(17, 166)
        Me.Lbl_Volumen.Name = "Lbl_Volumen"
        Me.Lbl_Volumen.Size = New System.Drawing.Size(48, 13)
        Me.Lbl_Volumen.TabIndex = 17
        Me.Lbl_Volumen.Text = "Volumen"
        '
        'txtb_UnidMedida
        '
        Me.txtb_UnidMedida.Location = New System.Drawing.Point(419, 64)
        Me.txtb_UnidMedida.Name = "txtb_UnidMedida"
        Me.txtb_UnidMedida.Size = New System.Drawing.Size(100, 20)
        Me.txtb_UnidMedida.TabIndex = 20
        Me.txtb_UnidMedida.Text = "Unid"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(239, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Unidad de Medidad"
        '
        'CkBox_SujetoAImpuesto
        '
        Me.CkBox_SujetoAImpuesto.AutoSize = True
        Me.CkBox_SujetoAImpuesto.Location = New System.Drawing.Point(21, 20)
        Me.CkBox_SujetoAImpuesto.Name = "CkBox_SujetoAImpuesto"
        Me.CkBox_SujetoAImpuesto.Size = New System.Drawing.Size(111, 17)
        Me.CkBox_SujetoAImpuesto.TabIndex = 21
        Me.CkBox_SujetoAImpuesto.Text = "Sujeto a Impuesto"
        Me.CkBox_SujetoAImpuesto.UseVisualStyleBackColor = True
        '
        'lbl_ListaPrecios
        '
        Me.lbl_ListaPrecios.AutoSize = True
        Me.lbl_ListaPrecios.Enabled = False
        Me.lbl_ListaPrecios.Location = New System.Drawing.Point(12, 128)
        Me.lbl_ListaPrecios.Name = "lbl_ListaPrecios"
        Me.lbl_ListaPrecios.Size = New System.Drawing.Size(76, 13)
        Me.lbl_ListaPrecios.TabIndex = 22
        Me.lbl_ListaPrecios.Text = "Lista de precio"
        '
        'CBox_ListPrecio
        '
        Me.CBox_ListPrecio.FormattingEnabled = True
        Me.CBox_ListPrecio.Items.AddRange(New Object() {"Costo", "Detalle", "Mayorista"})
        Me.CBox_ListPrecio.Location = New System.Drawing.Point(110, 124)
        Me.CBox_ListPrecio.Name = "CBox_ListPrecio"
        Me.CBox_ListPrecio.Size = New System.Drawing.Size(156, 21)
        Me.CBox_ListPrecio.TabIndex = 23
        Me.CBox_ListPrecio.Text = "Detalle"
        '
        'txtb_PrecioCosto
        '
        Me.txtb_PrecioCosto.Location = New System.Drawing.Point(368, 105)
        Me.txtb_PrecioCosto.Name = "txtb_PrecioCosto"
        Me.txtb_PrecioCosto.Size = New System.Drawing.Size(88, 20)
        Me.txtb_PrecioCosto.TabIndex = 25
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(272, 105)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Precio Costo :"
        '
        'RBtn_Activo
        '
        Me.RBtn_Activo.AutoSize = True
        Me.RBtn_Activo.Checked = True
        Me.RBtn_Activo.Location = New System.Drawing.Point(21, 279)
        Me.RBtn_Activo.Name = "RBtn_Activo"
        Me.RBtn_Activo.Size = New System.Drawing.Size(55, 17)
        Me.RBtn_Activo.TabIndex = 26
        Me.RBtn_Activo.TabStop = True
        Me.RBtn_Activo.Text = "Activo"
        Me.RBtn_Activo.UseVisualStyleBackColor = True
        '
        'RBtn_Inactivo
        '
        Me.RBtn_Inactivo.AutoSize = True
        Me.RBtn_Inactivo.Location = New System.Drawing.Point(21, 302)
        Me.RBtn_Inactivo.Name = "RBtn_Inactivo"
        Me.RBtn_Inactivo.Size = New System.Drawing.Size(63, 17)
        Me.RBtn_Inactivo.TabIndex = 27
        Me.RBtn_Inactivo.Text = "Inactivo"
        Me.RBtn_Inactivo.UseVisualStyleBackColor = True
        '
        'txtb_RazonInactivo
        '
        Me.txtb_RazonInactivo.Location = New System.Drawing.Point(215, 332)
        Me.txtb_RazonInactivo.Name = "txtb_RazonInactivo"
        Me.txtb_RazonInactivo.Size = New System.Drawing.Size(271, 20)
        Me.txtb_RazonInactivo.TabIndex = 29
        Me.txtb_RazonInactivo.Visible = False
        '
        'lbl_Razon
        '
        Me.lbl_Razon.AutoSize = True
        Me.lbl_Razon.Location = New System.Drawing.Point(172, 336)
        Me.lbl_Razon.Name = "lbl_Razon"
        Me.lbl_Razon.Size = New System.Drawing.Size(38, 13)
        Me.lbl_Razon.TabIndex = 28
        Me.lbl_Razon.Text = "Razon"
        Me.lbl_Razon.Visible = False
        '
        'txtb_InactivoDesde
        '
        Me.txtb_InactivoDesde.Location = New System.Drawing.Point(68, 332)
        Me.txtb_InactivoDesde.Name = "txtb_InactivoDesde"
        Me.txtb_InactivoDesde.Size = New System.Drawing.Size(100, 20)
        Me.txtb_InactivoDesde.TabIndex = 31
        Me.txtb_InactivoDesde.Visible = False
        '
        'lbl_Desde
        '
        Me.lbl_Desde.AutoSize = True
        Me.lbl_Desde.Location = New System.Drawing.Point(20, 336)
        Me.lbl_Desde.Name = "lbl_Desde"
        Me.lbl_Desde.Size = New System.Drawing.Size(38, 13)
        Me.lbl_Desde.TabIndex = 30
        Me.lbl_Desde.Text = "Desde"
        Me.lbl_Desde.Visible = False
        '
        'txtb_Comentarios
        '
        Me.txtb_Comentarios.Location = New System.Drawing.Point(22, 206)
        Me.txtb_Comentarios.Multiline = True
        Me.txtb_Comentarios.Name = "txtb_Comentarios"
        Me.txtb_Comentarios.Size = New System.Drawing.Size(710, 62)
        Me.txtb_Comentarios.TabIndex = 33
        Me.txtb_Comentarios.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(19, 188)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 13)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "Comentarios"
        Me.Label15.Visible = False
        '
        'btn_BuscaProveedores
        '
        Me.btn_BuscaProveedores.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_BuscaProveedores.Location = New System.Drawing.Point(191, 59)
        Me.btn_BuscaProveedores.Name = "btn_BuscaProveedores"
        Me.btn_BuscaProveedores.Size = New System.Drawing.Size(32, 23)
        Me.btn_BuscaProveedores.TabIndex = 34
        Me.btn_BuscaProveedores.Text = "..."
        Me.btn_BuscaProveedores.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_BuscaProveedores.UseVisualStyleBackColor = True
        '
        'txtb_Empaque
        '
        Me.txtb_Empaque.Location = New System.Drawing.Point(419, 88)
        Me.txtb_Empaque.Name = "txtb_Empaque"
        Me.txtb_Empaque.Size = New System.Drawing.Size(100, 20)
        Me.txtb_Empaque.TabIndex = 36
        Me.txtb_Empaque.Text = "1"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(239, 87)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 35
        Me.Label16.Text = "Empaque"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(5, 146)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(864, 399)
        Me.TabControl1.TabIndex = 39
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label34)
        Me.TabPage1.Controls.Add(Me.Txtb_Gramos)
        Me.TabPage1.Controls.Add(Me.txtb_PartidaArancelaria)
        Me.TabPage1.Controls.Add(Me.Label30)
        Me.TabPage1.Controls.Add(Me.Label29)
        Me.TabPage1.Controls.Add(Me.ComBox_CodTarifa)
        Me.TabPage1.Controls.Add(Me.txtb_imp)
        Me.TabPage1.Controls.Add(Me.Label28)
        Me.TabPage1.Controls.Add(Me.btn_Marca)
        Me.TabPage1.Controls.Add(Me.btn_Categoria)
        Me.TabPage1.Controls.Add(Me.btn_Familia)
        Me.TabPage1.Controls.Add(Me.Label27)
        Me.TabPage1.Controls.Add(Me.CBox_Marca)
        Me.TabPage1.Controls.Add(Me.Label24)
        Me.TabPage1.Controls.Add(Me.CBox_Categoria)
        Me.TabPage1.Controls.Add(Me.Label23)
        Me.TabPage1.Controls.Add(Me.CBox_Familia)
        Me.TabPage1.Controls.Add(Me.CkBox_SujetoAImpuesto)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtb_Empaque)
        Me.TabPage1.Controls.Add(Me.txtb_CodProveedor)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.btn_BuscaProveedores)
        Me.TabPage1.Controls.Add(Me.txtb_CodAlterno)
        Me.TabPage1.Controls.Add(Me.txtb_Comentarios)
        Me.TabPage1.Controls.Add(Me.lbl_Ancho)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.txtb_Ancho)
        Me.TabPage1.Controls.Add(Me.txtb_InactivoDesde)
        Me.TabPage1.Controls.Add(Me.Lbl_Largo)
        Me.TabPage1.Controls.Add(Me.lbl_Desde)
        Me.TabPage1.Controls.Add(Me.txtb_Largo)
        Me.TabPage1.Controls.Add(Me.txtb_RazonInactivo)
        Me.TabPage1.Controls.Add(Me.Lbl_Volumen)
        Me.TabPage1.Controls.Add(Me.lbl_Razon)
        Me.TabPage1.Controls.Add(Me.txtb_Volumen)
        Me.TabPage1.Controls.Add(Me.RBtn_Inactivo)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.RBtn_Activo)
        Me.TabPage1.Controls.Add(Me.txtb_UnidMedida)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.TabPage1.Size = New System.Drawing.Size(856, 373)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(19, 92)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(43, 13)
        Me.Label34.TabIndex = 53
        Me.Label34.Text = "Gramos"
        '
        'Txtb_Gramos
        '
        Me.Txtb_Gramos.Location = New System.Drawing.Point(85, 88)
        Me.Txtb_Gramos.Name = "Txtb_Gramos"
        Me.Txtb_Gramos.Size = New System.Drawing.Size(100, 20)
        Me.Txtb_Gramos.TabIndex = 54
        Me.Txtb_Gramos.Text = "0"
        '
        'txtb_PartidaArancelaria
        '
        Me.txtb_PartidaArancelaria.Location = New System.Drawing.Point(419, 110)
        Me.txtb_PartidaArancelaria.Name = "txtb_PartidaArancelaria"
        Me.txtb_PartidaArancelaria.ReadOnly = True
        Me.txtb_PartidaArancelaria.Size = New System.Drawing.Size(100, 20)
        Me.txtb_PartidaArancelaria.TabIndex = 52
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(239, 110)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(113, 13)
        Me.Label30.TabIndex = 51
        Me.Label30.Text = "Lbl_PartidaArancelaria"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(154, 20)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(70, 13)
        Me.Label29.TabIndex = 50
        Me.Label29.Text = "Codigo Tarifa"
        '
        'ComBox_CodTarifa
        '
        Me.ComBox_CodTarifa.Enabled = False
        Me.ComBox_CodTarifa.FormattingEnabled = True
        Me.ComBox_CodTarifa.Items.AddRange(New Object() {"01-Tarifa 0%(EXENTO)", "02-Tarifa reducida 1%", "03-Tarifa reducida 2%", "04-Tarifa reducida 4%", "05-Transitorio 0%", "06-Transitorio 4%", "07-Transitorio 8%", "08-Tarifa general 13%"})
        Me.ComBox_CodTarifa.Location = New System.Drawing.Point(242, 18)
        Me.ComBox_CodTarifa.Name = "ComBox_CodTarifa"
        Me.ComBox_CodTarifa.Size = New System.Drawing.Size(126, 21)
        Me.ComBox_CodTarifa.TabIndex = 49
        '
        'txtb_imp
        '
        Me.txtb_imp.Enabled = False
        Me.txtb_imp.Location = New System.Drawing.Point(434, 18)
        Me.txtb_imp.Name = "txtb_imp"
        Me.txtb_imp.ReadOnly = True
        Me.txtb_imp.Size = New System.Drawing.Size(87, 20)
        Me.txtb_imp.TabIndex = 48
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(382, 20)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(45, 13)
        Me.Label28.TabIndex = 47
        Me.Label28.Text = "% Tarifa"
        '
        'btn_Marca
        '
        Me.btn_Marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Marca.Location = New System.Drawing.Point(748, 115)
        Me.btn_Marca.Name = "btn_Marca"
        Me.btn_Marca.Size = New System.Drawing.Size(32, 23)
        Me.btn_Marca.TabIndex = 46
        Me.btn_Marca.Text = "..."
        Me.btn_Marca.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Marca.UseVisualStyleBackColor = True
        '
        'btn_Categoria
        '
        Me.btn_Categoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Categoria.Location = New System.Drawing.Point(748, 87)
        Me.btn_Categoria.Name = "btn_Categoria"
        Me.btn_Categoria.Size = New System.Drawing.Size(32, 23)
        Me.btn_Categoria.TabIndex = 45
        Me.btn_Categoria.Text = "..."
        Me.btn_Categoria.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Categoria.UseVisualStyleBackColor = True
        '
        'btn_Familia
        '
        Me.btn_Familia.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Familia.Location = New System.Drawing.Point(748, 57)
        Me.btn_Familia.Name = "btn_Familia"
        Me.btn_Familia.Size = New System.Drawing.Size(32, 23)
        Me.btn_Familia.TabIndex = 44
        Me.btn_Familia.Text = "..."
        Me.btn_Familia.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Familia.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(530, 117)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(37, 13)
        Me.Label27.TabIndex = 43
        Me.Label27.Text = "Marca"
        '
        'CBox_Marca
        '
        Me.CBox_Marca.FormattingEnabled = True
        Me.CBox_Marca.Location = New System.Drawing.Point(586, 115)
        Me.CBox_Marca.Name = "CBox_Marca"
        Me.CBox_Marca.Size = New System.Drawing.Size(156, 21)
        Me.CBox_Marca.TabIndex = 42
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(529, 92)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(52, 13)
        Me.Label24.TabIndex = 41
        Me.Label24.Text = "Categoria"
        '
        'CBox_Categoria
        '
        Me.CBox_Categoria.FormattingEnabled = True
        Me.CBox_Categoria.Location = New System.Drawing.Point(586, 89)
        Me.CBox_Categoria.Name = "CBox_Categoria"
        Me.CBox_Categoria.Size = New System.Drawing.Size(156, 21)
        Me.CBox_Categoria.TabIndex = 40
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(530, 66)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(39, 13)
        Me.Label23.TabIndex = 39
        Me.Label23.Text = "Familia"
        '
        'CBox_Familia
        '
        Me.CBox_Familia.FormattingEnabled = True
        Me.CBox_Familia.Location = New System.Drawing.Point(586, 64)
        Me.CBox_Familia.Name = "CBox_Familia"
        Me.CBox_Familia.Size = New System.Drawing.Size(156, 21)
        Me.CBox_Familia.TabIndex = 38
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.TabPage2.Size = New System.Drawing.Size(856, 373)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Inventario"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(850, 367)
        Me.DataGridView1.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.CBox_Transaccion)
        Me.TabPage3.Controls.Add(Me.Label21)
        Me.TabPage3.Controls.Add(Me.CBox_CodBodega)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.DataGridView2)
        Me.TabPage3.Controls.Add(Me.Label20)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.DTP_TransaccionHasta)
        Me.TabPage3.Controls.Add(Me.DTP_TransaccionDesde)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(856, 373)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Analisis"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'CBox_Transaccion
        '
        Me.CBox_Transaccion.FormattingEnabled = True
        Me.CBox_Transaccion.Items.AddRange(New Object() {"Todas", "Ventas", "Compras", "Salidas", "Entradas", "Traslados"})
        Me.CBox_Transaccion.Location = New System.Drawing.Point(66, 142)
        Me.CBox_Transaccion.Name = "CBox_Transaccion"
        Me.CBox_Transaccion.Size = New System.Drawing.Size(200, 21)
        Me.CBox_Transaccion.TabIndex = 50
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(4, 142)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(28, 13)
        Me.Label21.TabIndex = 49
        Me.Label21.Text = "Tipo"
        '
        'CBox_CodBodega
        '
        Me.CBox_CodBodega.FormattingEnabled = True
        Me.CBox_CodBodega.Items.AddRange(New Object() {"Articulo", "Servicio"})
        Me.CBox_CodBodega.Location = New System.Drawing.Point(66, 106)
        Me.CBox_CodBodega.Name = "CBox_CodBodega"
        Me.CBox_CodBodega.Size = New System.Drawing.Size(200, 21)
        Me.CBox_CodBodega.TabIndex = 48
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(4, 106)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 13)
        Me.Label18.TabIndex = 47
        Me.Label18.Text = "Bodega"
        '
        'DataGridView2
        '
        Me.DataGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(288, 0)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(526, 375)
        Me.DataGridView2.TabIndex = 46
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(3, 69)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(35, 13)
        Me.Label20.TabIndex = 45
        Me.Label20.Text = "Hasta"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(3, 43)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(38, 13)
        Me.Label19.TabIndex = 44
        Me.Label19.Text = "Desde"
        '
        'DTP_TransaccionHasta
        '
        Me.DTP_TransaccionHasta.Location = New System.Drawing.Point(66, 69)
        Me.DTP_TransaccionHasta.Name = "DTP_TransaccionHasta"
        Me.DTP_TransaccionHasta.Size = New System.Drawing.Size(200, 20)
        Me.DTP_TransaccionHasta.TabIndex = 43
        '
        'DTP_TransaccionDesde
        '
        Me.DTP_TransaccionDesde.Location = New System.Drawing.Point(66, 43)
        Me.DTP_TransaccionDesde.Name = "DTP_TransaccionDesde"
        Me.DTP_TransaccionDesde.Size = New System.Drawing.Size(200, 20)
        Me.DTP_TransaccionDesde.TabIndex = 42
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(4, 13)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(77, 13)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "Transacciones"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.DateTimePicker1)
        Me.TabPage4.Controls.Add(Me.Button4)
        Me.TabPage4.Controls.Add(Me.Label25)
        Me.TabPage4.Controls.Add(Me.TextBox3)
        Me.TabPage4.Controls.Add(Me.Label26)
        Me.TabPage4.Controls.Add(Me.btn_AgregarAlternativo)
        Me.TabPage4.Controls.Add(Me.TextBox1)
        Me.TabPage4.Controls.Add(Me.Label22)
        Me.TabPage4.Controls.Add(Me.DataGridView3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(856, 373)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Alternativos"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(82, 112)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 62
        Me.DateTimePicker1.Visible = False
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(210, 59)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(72, 29)
        Me.Button4.TabIndex = 61
        Me.Button4.Text = "Inactivar"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(4, 118)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(38, 13)
        Me.Label25.TabIndex = 59
        Me.Label25.Text = "Desde"
        Me.Label25.Visible = False
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(80, 143)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(202, 20)
        Me.TextBox3.TabIndex = 58
        Me.TextBox3.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(4, 143)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(38, 13)
        Me.Label26.TabIndex = 57
        Me.Label26.Text = "Razon"
        Me.Label26.Visible = False
        '
        'btn_AgregarAlternativo
        '
        Me.btn_AgregarAlternativo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_AgregarAlternativo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AgregarAlternativo.Location = New System.Drawing.Point(7, 59)
        Me.btn_AgregarAlternativo.Name = "btn_AgregarAlternativo"
        Me.btn_AgregarAlternativo.Size = New System.Drawing.Size(72, 29)
        Me.btn_AgregarAlternativo.TabIndex = 50
        Me.btn_AgregarAlternativo.Text = "Agregar"
        Me.btn_AgregarAlternativo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_AgregarAlternativo.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(80, 14)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(202, 20)
        Me.TextBox1.TabIndex = 49
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(4, 19)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(40, 13)
        Me.Label22.TabIndex = 48
        Me.Label22.Text = "Codigo"
        '
        'DataGridView3
        '
        Me.DataGridView3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Location = New System.Drawing.Point(288, 2)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.Size = New System.Drawing.Size(526, 375)
        Me.DataGridView3.TabIndex = 47
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.btn_EliminarFoto)
        Me.TabPage5.Controls.Add(Me.Label2)
        Me.TabPage5.Controls.Add(Me.CBox_IDFotos)
        Me.TabPage5.Controls.Add(Me.panel2)
        Me.TabPage5.Controls.Add(Me.btn_AdjuntaFoto)
        Me.TabPage5.Controls.Add(Me.Label31)
        Me.TabPage5.Controls.Add(Me.Label32)
        Me.TabPage5.Controls.Add(Me.Label33)
        Me.TabPage5.Controls.Add(Me.Txtb_Width)
        Me.TabPage5.Controls.Add(Me.Txtb_Height)
        Me.TabPage5.Controls.Add(Me.trackBar1)
        Me.TabPage5.Controls.Add(Me.txtb_zooFactor)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.TabPage5.Size = New System.Drawing.Size(856, 373)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Fotos"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'btn_EliminarFoto
        '
        Me.btn_EliminarFoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_EliminarFoto.Location = New System.Drawing.Point(10, 11)
        Me.btn_EliminarFoto.Name = "btn_EliminarFoto"
        Me.btn_EliminarFoto.Size = New System.Drawing.Size(91, 43)
        Me.btn_EliminarFoto.TabIndex = 34
        Me.btn_EliminarFoto.Text = "Eliminar Foto"
        Me.btn_EliminarFoto.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(343, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "ID Foto"
        '
        'CBox_IDFotos
        '
        Me.CBox_IDFotos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CBox_IDFotos.FormattingEnabled = True
        Me.CBox_IDFotos.Items.AddRange(New Object() {"Articulo", "Servicio"})
        Me.CBox_IDFotos.Location = New System.Drawing.Point(322, 32)
        Me.CBox_IDFotos.Name = "CBox_IDFotos"
        Me.CBox_IDFotos.Size = New System.Drawing.Size(82, 21)
        Me.CBox_IDFotos.TabIndex = 32
        '
        'panel2
        '
        Me.panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel2.AutoScroll = True
        Me.panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panel2.Controls.Add(Me.pictureBox1)
        Me.panel2.Location = New System.Drawing.Point(3, 65)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(844, 304)
        Me.panel2.TabIndex = 31
        '
        'pictureBox1
        '
        Me.pictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureBox1.TabIndex = 0
        Me.pictureBox1.TabStop = False
        '
        'btn_AdjuntaFoto
        '
        Me.btn_AdjuntaFoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AdjuntaFoto.Location = New System.Drawing.Point(107, 11)
        Me.btn_AdjuntaFoto.Name = "btn_AdjuntaFoto"
        Me.btn_AdjuntaFoto.Size = New System.Drawing.Size(90, 43)
        Me.btn_AdjuntaFoto.TabIndex = 30
        Me.btn_AdjuntaFoto.Text = "Adjuntar Foto"
        Me.btn_AdjuntaFoto.UseVisualStyleBackColor = True
        Me.btn_AdjuntaFoto.Visible = False
        '
        'Label31
        '
        Me.Label31.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(626, 11)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(38, 13)
        Me.Label31.TabIndex = 28
        Me.Label31.Text = "Width:"
        '
        'Label32
        '
        Me.Label32.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(436, 11)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(48, 13)
        Me.Label32.TabIndex = 27
        Me.Label32.Text = "Zoom %:"
        '
        'Label33
        '
        Me.Label33.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(526, 11)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(41, 13)
        Me.Label33.TabIndex = 26
        Me.Label33.Text = "Height:"
        '
        'Txtb_Width
        '
        Me.Txtb_Width.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txtb_Width.Location = New System.Drawing.Point(597, 32)
        Me.Txtb_Width.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Txtb_Width.Name = "Txtb_Width"
        Me.Txtb_Width.ReadOnly = True
        Me.Txtb_Width.Size = New System.Drawing.Size(76, 20)
        Me.Txtb_Width.TabIndex = 25
        Me.Txtb_Width.Text = "0"
        Me.Txtb_Width.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txtb_Height
        '
        Me.Txtb_Height.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txtb_Height.Location = New System.Drawing.Point(508, 32)
        Me.Txtb_Height.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Txtb_Height.Name = "Txtb_Height"
        Me.Txtb_Height.ReadOnly = True
        Me.Txtb_Height.Size = New System.Drawing.Size(76, 20)
        Me.Txtb_Height.TabIndex = 24
        Me.Txtb_Height.Text = "0"
        Me.Txtb_Height.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'trackBar1
        '
        Me.trackBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trackBar1.Location = New System.Drawing.Point(683, 11)
        Me.trackBar1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.trackBar1.Maximum = 100
        Me.trackBar1.Minimum = 10
        Me.trackBar1.MinimumSize = New System.Drawing.Size(75, 0)
        Me.trackBar1.Name = "trackBar1"
        Me.trackBar1.Size = New System.Drawing.Size(164, 45)
        Me.trackBar1.SmallChange = 10
        Me.trackBar1.TabIndex = 23
        Me.trackBar1.TickFrequency = 10
        Me.trackBar1.Value = 100
        '
        'txtb_zooFactor
        '
        Me.txtb_zooFactor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_zooFactor.Location = New System.Drawing.Point(418, 32)
        Me.txtb_zooFactor.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtb_zooFactor.Name = "txtb_zooFactor"
        Me.txtb_zooFactor.ReadOnly = True
        Me.txtb_zooFactor.Size = New System.Drawing.Size(76, 20)
        Me.txtb_zooFactor.TabIndex = 22
        Me.txtb_zooFactor.Text = "100"
        Me.txtb_zooFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_Guardar
        '
        Me.btn_Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Guardar.Location = New System.Drawing.Point(8, 555)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(72, 29)
        Me.btn_Guardar.TabIndex = 61
        Me.btn_Guardar.Text = "Guardar"
        Me.btn_Guardar.UseVisualStyleBackColor = True
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancelar.Location = New System.Drawing.Point(86, 555)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(72, 29)
        Me.btn_Cancelar.TabIndex = 62
        Me.btn_Cancelar.Text = "Cancelar"
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'btn_buscar
        '
        Me.btn_buscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Location = New System.Drawing.Point(164, 555)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(72, 29)
        Me.btn_buscar.TabIndex = 63
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'btn_CrearEnSAP
        '
        Me.btn_CrearEnSAP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_CrearEnSAP.Enabled = False
        Me.btn_CrearEnSAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_CrearEnSAP.Location = New System.Drawing.Point(734, 555)
        Me.btn_CrearEnSAP.Name = "btn_CrearEnSAP"
        Me.btn_CrearEnSAP.Size = New System.Drawing.Size(124, 29)
        Me.btn_CrearEnSAP.TabIndex = 64
        Me.btn_CrearEnSAP.Text = "Crear en SAP"
        Me.btn_CrearEnSAP.UseVisualStyleBackColor = True
        '
        'lbl_LineaNueva
        '
        Me.lbl_LineaNueva.AutoSize = True
        Me.lbl_LineaNueva.Location = New System.Drawing.Point(633, 80)
        Me.lbl_LineaNueva.Name = "lbl_LineaNueva"
        Me.lbl_LineaNueva.Size = New System.Drawing.Size(186, 13)
        Me.lbl_LineaNueva.TabIndex = 65
        Me.lbl_LineaNueva.Text = "Controla si es interno o nuevo de SAP"
        Me.lbl_LineaNueva.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 82)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 13)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Groupo de Articulo"
        '
        'CBox_GrupoArticulo
        '
        Me.CBox_GrupoArticulo.FormattingEnabled = True
        Me.CBox_GrupoArticulo.Items.AddRange(New Object() {"AB"})
        Me.CBox_GrupoArticulo.Location = New System.Drawing.Point(110, 79)
        Me.CBox_GrupoArticulo.Name = "CBox_GrupoArticulo"
        Me.CBox_GrupoArticulo.Size = New System.Drawing.Size(156, 21)
        Me.CBox_GrupoArticulo.TabIndex = 55
        Me.CBox_GrupoArticulo.Text = "AB"
        '
        'Txtb_NombreExtrangero
        '
        Me.Txtb_NombreExtrangero.Location = New System.Drawing.Point(111, 57)
        Me.Txtb_NombreExtrangero.Name = "Txtb_NombreExtrangero"
        Me.Txtb_NombreExtrangero.Size = New System.Drawing.Size(487, 20)
        Me.Txtb_NombreExtrangero.TabIndex = 67
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 60)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 13)
        Me.Label13.TabIndex = 66
        Me.Label13.Text = "Nombre Extrangero"
        '
        'Txtb_CodCabys
        '
        Me.Txtb_CodCabys.Location = New System.Drawing.Point(442, 11)
        Me.Txtb_CodCabys.Name = "Txtb_CodCabys"
        Me.Txtb_CodCabys.Size = New System.Drawing.Size(156, 20)
        Me.Txtb_CodCabys.TabIndex = 69
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(365, 13)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 13)
        Me.Label14.TabIndex = 68
        Me.Label14.Text = "Codido Cabys"
        '
        'Cbox_Ubicacion
        '
        Me.Cbox_Ubicacion.Enabled = False
        Me.Cbox_Ubicacion.FormattingEnabled = True
        Me.Cbox_Ubicacion.Items.AddRange(New Object() {"Costo", "Detalle", "Mayorista"})
        Me.Cbox_Ubicacion.Location = New System.Drawing.Point(110, 102)
        Me.Cbox_Ubicacion.Name = "Cbox_Ubicacion"
        Me.Cbox_Ubicacion.Size = New System.Drawing.Size(156, 21)
        Me.Cbox_Ubicacion.TabIndex = 71
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(12, 106)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(55, 13)
        Me.Label35.TabIndex = 70
        Me.Label35.Text = "Ubicacion"
        '
        'Txtb_IdArticuloNuevo
        '
        Me.Txtb_IdArticuloNuevo.Location = New System.Drawing.Point(762, 124)
        Me.Txtb_IdArticuloNuevo.Name = "Txtb_IdArticuloNuevo"
        Me.Txtb_IdArticuloNuevo.Size = New System.Drawing.Size(58, 20)
        Me.Txtb_IdArticuloNuevo.TabIndex = 73
        Me.Txtb_IdArticuloNuevo.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(661, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 13)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "ID Articulo Nuevo"
        Me.Label7.Visible = False
        '
        'Txtb_IdArticulo
        '
        Me.Txtb_IdArticulo.Location = New System.Drawing.Point(762, 104)
        Me.Txtb_IdArticulo.Name = "Txtb_IdArticulo"
        Me.Txtb_IdArticulo.Size = New System.Drawing.Size(58, 20)
        Me.Txtb_IdArticulo.TabIndex = 75
        Me.Txtb_IdArticulo.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(702, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 74
        Me.Label8.Text = "ID Articulo"
        Me.Label8.Visible = False
        '
        'Txt_PorcUtilidad
        '
        Me.Txt_PorcUtilidad.Location = New System.Drawing.Point(522, 104)
        Me.Txt_PorcUtilidad.Name = "Txt_PorcUtilidad"
        Me.Txt_PorcUtilidad.Size = New System.Drawing.Size(76, 20)
        Me.Txt_PorcUtilidad.TabIndex = 56
        Me.Txt_PorcUtilidad.Text = "1"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(469, 107)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 55
        Me.Label9.Text = "% Utilidad"
        '
        'Txtb_PrecioVenta
        '
        Me.Txtb_PrecioVenta.Location = New System.Drawing.Point(368, 128)
        Me.Txtb_PrecioVenta.Name = "Txtb_PrecioVenta"
        Me.Txtb_PrecioVenta.Size = New System.Drawing.Size(88, 20)
        Me.Txtb_PrecioVenta.TabIndex = 77
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(272, 128)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(71, 13)
        Me.Label36.TabIndex = 76
        Me.Label36.Text = "Precio Venta "
        '
        'btn_CargarPlantilla
        '
        Me.btn_CargarPlantilla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_CargarPlantilla.Enabled = False
        Me.btn_CargarPlantilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_CargarPlantilla.Location = New System.Drawing.Point(595, 555)
        Me.btn_CargarPlantilla.Name = "btn_CargarPlantilla"
        Me.btn_CargarPlantilla.Size = New System.Drawing.Size(124, 29)
        Me.btn_CargarPlantilla.TabIndex = 78
        Me.btn_CargarPlantilla.Text = "Cargar Plantilla"
        Me.btn_CargarPlantilla.UseVisualStyleBackColor = True
        Me.btn_CargarPlantilla.Visible = False
        '
        'btn_DescargarPlantilla
        '
        Me.btn_DescargarPlantilla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_DescargarPlantilla.Enabled = False
        Me.btn_DescargarPlantilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_DescargarPlantilla.Location = New System.Drawing.Point(464, 555)
        Me.btn_DescargarPlantilla.Name = "btn_DescargarPlantilla"
        Me.btn_DescargarPlantilla.Size = New System.Drawing.Size(124, 29)
        Me.btn_DescargarPlantilla.TabIndex = 79
        Me.btn_DescargarPlantilla.Text = "Descargar Plantilla"
        Me.btn_DescargarPlantilla.UseVisualStyleBackColor = True
        Me.btn_DescargarPlantilla.Visible = False
        '
        'CBox_Moneda
        '
        Me.CBox_Moneda.FormattingEnabled = True
        Me.CBox_Moneda.Items.AddRange(New Object() {"CRC", "USD"})
        Me.CBox_Moneda.Location = New System.Drawing.Point(522, 128)
        Me.CBox_Moneda.Name = "CBox_Moneda"
        Me.CBox_Moneda.Size = New System.Drawing.Size(76, 21)
        Me.CBox_Moneda.TabIndex = 81
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Enabled = False
        Me.Label37.Location = New System.Drawing.Point(469, 132)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(46, 13)
        Me.Label37.TabIndex = 80
        Me.Label37.Text = "Moneda"
        '
        'Stock_Manager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 592)
        Me.Controls.Add(Me.CBox_Moneda)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.btn_DescargarPlantilla)
        Me.Controls.Add(Me.btn_CargarPlantilla)
        Me.Controls.Add(Me.Txtb_PrecioVenta)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Txt_PorcUtilidad)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Txtb_IdArticulo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Txtb_IdArticuloNuevo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Cbox_Ubicacion)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Txtb_CodCabys)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Txtb_NombreExtrangero)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lbl_LineaNueva)
        Me.Controls.Add(Me.CBox_GrupoArticulo)
        Me.Controls.Add(Me.btn_CrearEnSAP)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.btn_Cancelar)
        Me.Controls.Add(Me.btn_Guardar)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txtb_PrecioCosto)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.CBox_ListPrecio)
        Me.Controls.Add(Me.lbl_ListaPrecios)
        Me.Controls.Add(Me.txtb_CodBarras)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtb_Descripcion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.CBox_TipoProducto)
        Me.Controls.Add(Me.txtb_ItemCode)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Stock_Manager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manager Articulos"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.panel2.ResumeLayout(False)
        Me.panel2.PerformLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtb_ItemCode As TextBox
    Friend WithEvents CBox_TipoProducto As ComboBox
    Friend WithEvents lblTipo As Label
    Friend WithEvents txtb_Descripcion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtb_CodBarras As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtb_CodProveedor As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtb_CodAlterno As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtb_Ancho As TextBox
    Friend WithEvents lbl_Ancho As Label
    Friend WithEvents txtb_Largo As TextBox
    Friend WithEvents Lbl_Largo As Label
    Friend WithEvents txtb_Volumen As TextBox
    Friend WithEvents Lbl_Volumen As Label
    Friend WithEvents txtb_UnidMedida As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents CkBox_SujetoAImpuesto As CheckBox
    Friend WithEvents lbl_ListaPrecios As Label
    Friend WithEvents CBox_ListPrecio As ComboBox
    Friend WithEvents txtb_PrecioCosto As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents RBtn_Activo As RadioButton
    Friend WithEvents RBtn_Inactivo As RadioButton
    Friend WithEvents txtb_RazonInactivo As TextBox
    Friend WithEvents lbl_Razon As Label
    Friend WithEvents txtb_InactivoDesde As TextBox
    Friend WithEvents lbl_Desde As Label
    Friend WithEvents txtb_Comentarios As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents btn_BuscaProveedores As Button
    Friend WithEvents txtb_Empaque As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents CBox_CodBodega As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents DTP_TransaccionHasta As DateTimePicker
    Friend WithEvents DTP_TransaccionDesde As DateTimePicker
    Friend WithEvents Label17 As Label
    Friend WithEvents CBox_Transaccion As ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Button4 As Button
    Friend WithEvents Label25 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents btn_AgregarAlternativo As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents btn_Guardar As Button
    Friend WithEvents btn_Cancelar As Button
    Friend WithEvents Label27 As Label
    Friend WithEvents CBox_Marca As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents CBox_Categoria As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents CBox_Familia As ComboBox
    Friend WithEvents btn_Marca As Button
    Friend WithEvents btn_Categoria As Button
    Friend WithEvents btn_Familia As Button
    Friend WithEvents btn_buscar As Button
    Friend WithEvents txtb_imp As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents ComBox_CodTarifa As ComboBox
    Friend WithEvents txtb_PartidaArancelaria As TextBox
    Friend WithEvents Label30 As Label
    Private WithEvents Label31 As Label
    Private WithEvents Label32 As Label
    Private WithEvents Label33 As Label
    Private WithEvents Txtb_Width As TextBox
    Private WithEvents Txtb_Height As TextBox
    Private WithEvents trackBar1 As TrackBar
    Private WithEvents txtb_zooFactor As TextBox
    Friend WithEvents btn_CrearEnSAP As Button
    Friend WithEvents btn_AdjuntaFoto As Button
    Friend WithEvents Label34 As Label
    Friend WithEvents Txtb_Gramos As TextBox
    Friend WithEvents lbl_LineaNueva As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents CBox_GrupoArticulo As ComboBox
    Friend WithEvents Txtb_NombreExtrangero As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Txtb_CodCabys As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Cbox_Ubicacion As ComboBox
    Friend WithEvents Label35 As Label
    Private WithEvents panel2 As Panel
    Private WithEvents pictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CBox_IDFotos As ComboBox
    Friend WithEvents btn_EliminarFoto As Button
    Friend WithEvents Txtb_IdArticuloNuevo As TextBox
    Friend WithEvents Label7 As Label
    Private WithEvents TabPage5 As TabPage
    Friend WithEvents Txtb_IdArticulo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Txt_PorcUtilidad As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Txtb_PrecioVenta As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents btn_CargarPlantilla As Button
    Friend WithEvents btn_DescargarPlantilla As Button
    Friend WithEvents CBox_Moneda As ComboBox
    Friend WithEvents Label37 As Label
End Class
