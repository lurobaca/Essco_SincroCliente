<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportesDeCarga
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportesDeCarga))
        Me.DataGV_RepCarSec = New System.Windows.Forms.DataGridView()
        Me.txtb_FACFIN = New System.Windows.Forms.TextBox()
        Me.txtb_FACINI = New System.Windows.Forms.TextBox()
        Me.lbl_TotalRuta = New System.Windows.Forms.Label()
        Me.TXB_Hora = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_cerrar = New System.Windows.Forms.Button()
        Me.CBX_Sector = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.dtp_FechaReporte = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Rb_ConBod1 = New System.Windows.Forms.RadioButton()
        Me.Rb_SinBod1 = New System.Windows.Forms.RadioButton()
        Me.btn_Anular = New System.Windows.Forms.Button()
        Me.btn_Generar = New System.Windows.Forms.Button()
        Me.btn_Buscar = New System.Windows.Forms.Button()
        Me.btn_Limpiar = New System.Windows.Forms.Button()
        Me.Cbx_Rutas = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txb_Numero = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbl_TotalFaltante = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Lbl_Peso = New System.Windows.Forms.Label()
        Me.txtb_Ruta = New System.Windows.Forms.TextBox()
        Me.Lb_lAnulado = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Btn_Atras = New System.Windows.Forms.Button()
        Me.Btn_Adelante = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_Faltantes = New System.Windows.Forms.Button()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.Lb_Cerrado = New System.Windows.Forms.Label()
        Me.CBX_Linea = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtb_BuscDescripcion = New System.Windows.Forms.TextBox()
        CType(Me.DataGV_RepCarSec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGV_RepCarSec
        '
        Me.DataGV_RepCarSec.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGV_RepCarSec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGV_RepCarSec.Location = New System.Drawing.Point(4, 181)
        Me.DataGV_RepCarSec.Name = "DataGV_RepCarSec"
        Me.DataGV_RepCarSec.Size = New System.Drawing.Size(946, 320)
        Me.DataGV_RepCarSec.TabIndex = 8
        '
        'txtb_FACFIN
        '
        Me.txtb_FACFIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_FACFIN.Location = New System.Drawing.Point(212, 36)
        Me.txtb_FACFIN.Name = "txtb_FACFIN"
        Me.txtb_FACFIN.Size = New System.Drawing.Size(101, 23)
        Me.txtb_FACFIN.TabIndex = 2
        '
        'txtb_FACINI
        '
        Me.txtb_FACINI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_FACINI.Location = New System.Drawing.Point(53, 36)
        Me.txtb_FACINI.Name = "txtb_FACINI"
        Me.txtb_FACINI.Size = New System.Drawing.Size(101, 23)
        Me.txtb_FACINI.TabIndex = 1
        '
        'lbl_TotalRuta
        '
        Me.lbl_TotalRuta.AutoSize = True
        Me.lbl_TotalRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotalRuta.ForeColor = System.Drawing.Color.Red
        Me.lbl_TotalRuta.Location = New System.Drawing.Point(344, 100)
        Me.lbl_TotalRuta.Name = "lbl_TotalRuta"
        Me.lbl_TotalRuta.Size = New System.Drawing.Size(137, 25)
        Me.lbl_TotalRuta.TabIndex = 13
        Me.lbl_TotalRuta.Text = "000,000,000.0"
        Me.lbl_TotalRuta.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TXB_Hora
        '
        Me.TXB_Hora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXB_Hora.Enabled = False
        Me.TXB_Hora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Hora.Location = New System.Drawing.Point(739, 112)
        Me.TXB_Hora.Name = "TXB_Hora"
        Me.TXB_Hora.ReadOnly = True
        Me.TXB_Hora.Size = New System.Drawing.Size(201, 23)
        Me.TXB_Hora.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(680, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 17)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Hora"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(680, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 17)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Fecha"
        '
        'btn_cerrar
        '
        Me.btn_cerrar.BackColor = System.Drawing.Color.White
        Me.btn_cerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_cerrar.Font = New System.Drawing.Font("Arial", 1.0!, System.Drawing.FontStyle.Bold)
        Me.btn_cerrar.ForeColor = System.Drawing.Color.White
        Me.btn_cerrar.Image = Global.SincroCliente.My.Resources.Resources.candado1
        Me.btn_cerrar.Location = New System.Drawing.Point(6, 88)
        Me.btn_cerrar.Name = "btn_cerrar"
        Me.btn_cerrar.Size = New System.Drawing.Size(52, 53)
        Me.btn_cerrar.TabIndex = 22
        Me.btn_cerrar.Tag = "Indica cuando se saco todo"
        Me.btn_cerrar.Text = "Cerrar"
        Me.btn_cerrar.UseVisualStyleBackColor = False
        Me.btn_cerrar.Visible = False
        '
        'CBX_Sector
        '
        Me.CBX_Sector.FormattingEnabled = True
        Me.CBX_Sector.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "TODOS"})
        Me.CBX_Sector.Location = New System.Drawing.Point(404, 152)
        Me.CBX_Sector.Name = "CBX_Sector"
        Me.CBX_Sector.Size = New System.Drawing.Size(109, 21)
        Me.CBX_Sector.TabIndex = 2
        Me.CBX_Sector.Text = "TODOS"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(356, 156)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(42, 15)
        Me.Label28.TabIndex = 3
        Me.Label28.Text = "Sector"
        '
        'dtp_FechaReporte
        '
        Me.dtp_FechaReporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtp_FechaReporte.Enabled = False
        Me.dtp_FechaReporte.Location = New System.Drawing.Point(739, 89)
        Me.dtp_FechaReporte.Name = "dtp_FechaReporte"
        Me.dtp_FechaReporte.Size = New System.Drawing.Size(204, 20)
        Me.dtp_FechaReporte.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 17)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "INICIA"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(177, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 17)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "FIN"
        '
        'Rb_ConBod1
        '
        Me.Rb_ConBod1.AutoSize = True
        Me.Rb_ConBod1.Location = New System.Drawing.Point(323, 36)
        Me.Rb_ConBod1.Name = "Rb_ConBod1"
        Me.Rb_ConBod1.Size = New System.Drawing.Size(82, 19)
        Me.Rb_ConBod1.TabIndex = 26
        Me.Rb_ConBod1.Text = "Con Bod 1"
        Me.Rb_ConBod1.UseVisualStyleBackColor = True
        '
        'Rb_SinBod1
        '
        Me.Rb_SinBod1.AutoSize = True
        Me.Rb_SinBod1.Checked = True
        Me.Rb_SinBod1.Location = New System.Drawing.Point(406, 36)
        Me.Rb_SinBod1.Name = "Rb_SinBod1"
        Me.Rb_SinBod1.Size = New System.Drawing.Size(78, 19)
        Me.Rb_SinBod1.TabIndex = 27
        Me.Rb_SinBod1.TabStop = True
        Me.Rb_SinBod1.Text = "Sin Bod 1"
        Me.Rb_SinBod1.UseVisualStyleBackColor = True
        '
        'btn_Anular
        '
        Me.btn_Anular.BackColor = System.Drawing.Color.White
        Me.btn_Anular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_Anular.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Anular.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_Anular.Image = CType(resources.GetObject("btn_Anular.Image"), System.Drawing.Image)
        Me.btn_Anular.Location = New System.Drawing.Point(634, 104)
        Me.btn_Anular.Name = "btn_Anular"
        Me.btn_Anular.Size = New System.Drawing.Size(40, 40)
        Me.btn_Anular.TabIndex = 19
        Me.btn_Anular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Anular.UseVisualStyleBackColor = False
        Me.btn_Anular.Visible = False
        '
        'btn_Generar
        '
        Me.btn_Generar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_Generar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Generar.Location = New System.Drawing.Point(491, 12)
        Me.btn_Generar.Name = "btn_Generar"
        Me.btn_Generar.Size = New System.Drawing.Size(84, 67)
        Me.btn_Generar.TabIndex = 4
        Me.btn_Generar.Text = "Generar"
        Me.btn_Generar.UseVisualStyleBackColor = False
        Me.btn_Generar.Visible = False
        '
        'btn_Buscar
        '
        Me.btn_Buscar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_Buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Buscar.Location = New System.Drawing.Point(6, 12)
        Me.btn_Buscar.Name = "btn_Buscar"
        Me.btn_Buscar.Size = New System.Drawing.Size(80, 35)
        Me.btn_Buscar.TabIndex = 5
        Me.btn_Buscar.Text = "Buscar"
        Me.btn_Buscar.UseVisualStyleBackColor = False
        '
        'btn_Limpiar
        '
        Me.btn_Limpiar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_Limpiar.Enabled = False
        Me.btn_Limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Limpiar.Location = New System.Drawing.Point(6, 51)
        Me.btn_Limpiar.Name = "btn_Limpiar"
        Me.btn_Limpiar.Size = New System.Drawing.Size(80, 35)
        Me.btn_Limpiar.TabIndex = 6
        Me.btn_Limpiar.Text = "Limpiar"
        Me.btn_Limpiar.UseVisualStyleBackColor = False
        '
        'Cbx_Rutas
        '
        Me.Cbx_Rutas.DropDownHeight = 500
        Me.Cbx_Rutas.FormattingEnabled = True
        Me.Cbx_Rutas.IntegralHeight = False
        Me.Cbx_Rutas.Items.AddRange(New Object() {"Seleccines una ruta"})
        Me.Cbx_Rutas.Location = New System.Drawing.Point(67, 8)
        Me.Cbx_Rutas.Name = "Cbx_Rutas"
        Me.Cbx_Rutas.Size = New System.Drawing.Size(38, 21)
        Me.Cbx_Rutas.TabIndex = 33
        Me.Cbx_Rutas.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(680, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 17)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Numero"
        '
        'txb_Numero
        '
        Me.txb_Numero.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txb_Numero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Numero.Location = New System.Drawing.Point(739, 58)
        Me.txb_Numero.Name = "txb_Numero"
        Me.txb_Numero.ReadOnly = True
        Me.txb_Numero.Size = New System.Drawing.Size(76, 23)
        Me.txb_Numero.TabIndex = 35
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(388, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 17)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Ruta"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(210, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 17)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Faltante"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_TotalFaltante
        '
        Me.lbl_TotalFaltante.AutoSize = True
        Me.lbl_TotalFaltante.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotalFaltante.ForeColor = System.Drawing.Color.Red
        Me.lbl_TotalFaltante.Location = New System.Drawing.Point(176, 100)
        Me.lbl_TotalFaltante.Name = "lbl_TotalFaltante"
        Me.lbl_TotalFaltante.Size = New System.Drawing.Size(137, 25)
        Me.lbl_TotalFaltante.TabIndex = 39
        Me.lbl_TotalFaltante.Text = "000,000,000.0"
        Me.lbl_TotalFaltante.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(56, 82)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 17)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Peso"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Lbl_Peso
        '
        Me.Lbl_Peso.AutoSize = True
        Me.Lbl_Peso.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Peso.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Peso.Location = New System.Drawing.Point(11, 100)
        Me.Lbl_Peso.Name = "Lbl_Peso"
        Me.Lbl_Peso.Size = New System.Drawing.Size(129, 25)
        Me.Lbl_Peso.TabIndex = 41
        Me.Lbl_Peso.Text = "Kg 000,000.0"
        Me.Lbl_Peso.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtb_Ruta
        '
        Me.txtb_Ruta.AccessibleDescription = ""
        Me.txtb_Ruta.AccessibleName = ""
        Me.txtb_Ruta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Ruta.Location = New System.Drawing.Point(11, 7)
        Me.txtb_Ruta.Name = "txtb_Ruta"
        Me.txtb_Ruta.Size = New System.Drawing.Size(470, 23)
        Me.txtb_Ruta.TabIndex = 0
        Me.txtb_Ruta.Tag = ""
        Me.ToolTip1.SetToolTip(Me.txtb_Ruta, "Digite la Ruta")
        '
        'Lb_lAnulado
        '
        Me.Lb_lAnulado.AutoSize = True
        Me.Lb_lAnulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Lb_lAnulado.ForeColor = System.Drawing.Color.Red
        Me.Lb_lAnulado.Location = New System.Drawing.Point(60, 114)
        Me.Lb_lAnulado.Name = "Lb_lAnulado"
        Me.Lb_lAnulado.Size = New System.Drawing.Size(116, 25)
        Me.Lb_lAnulado.TabIndex = 36
        Me.Lb_lAnulado.Text = "ANULADO"
        Me.Lb_lAnulado.Visible = False
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.Controls.Add(Me.Button1)
        Me.Panel6.Controls.Add(Me.Btn_Atras)
        Me.Panel6.Controls.Add(Me.Btn_Adelante)
        Me.Panel6.Controls.Add(Me.GroupBox1)
        Me.Panel6.Controls.Add(Me.txtb_Ruta)
        Me.Panel6.Controls.Add(Me.btn_Anular)
        Me.Panel6.Controls.Add(Me.Lbl_Peso)
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.lbl_TotalFaltante)
        Me.Panel6.Controls.Add(Me.btn_Generar)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.Controls.Add(Me.txb_Numero)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Controls.Add(Me.Cbx_Rutas)
        Me.Panel6.Controls.Add(Me.Rb_SinBod1)
        Me.Panel6.Controls.Add(Me.Rb_ConBod1)
        Me.Panel6.Controls.Add(Me.Label4)
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Controls.Add(Me.dtp_FechaReporte)
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Controls.Add(Me.TXB_Hora)
        Me.Panel6.Controls.Add(Me.lbl_TotalRuta)
        Me.Panel6.Controls.Add(Me.txtb_FACINI)
        Me.Panel6.Controls.Add(Me.txtb_FACFIN)
        Me.Panel6.Location = New System.Drawing.Point(1, 1)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(949, 145)
        Me.Panel6.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(821, 57)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(119, 25)
        Me.Button1.TabIndex = 272
        Me.Button1.Text = "Rep Facturas"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Btn_Atras
        '
        Me.Btn_Atras.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Atras.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Atras.BackgroundImage = CType(resources.GetObject("Btn_Atras.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Atras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Atras.Location = New System.Drawing.Point(739, 8)
        Me.Btn_Atras.Name = "Btn_Atras"
        Me.Btn_Atras.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Atras.TabIndex = 77
        Me.Btn_Atras.UseVisualStyleBackColor = False
        '
        'Btn_Adelante
        '
        Me.Btn_Adelante.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Adelante.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Adelante.BackgroundImage = CType(resources.GetObject("Btn_Adelante.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Adelante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Adelante.Location = New System.Drawing.Point(865, 8)
        Me.Btn_Adelante.Name = "Btn_Adelante"
        Me.Btn_Adelante.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Adelante.TabIndex = 76
        Me.Btn_Adelante.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_Faltantes)
        Me.GroupBox1.Controls.Add(Me.Btn_Imprimir)
        Me.GroupBox1.Controls.Add(Me.btn_Buscar)
        Me.GroupBox1.Controls.Add(Me.btn_cerrar)
        Me.GroupBox1.Controls.Add(Me.btn_Limpiar)
        Me.GroupBox1.Controls.Add(Me.Lb_Cerrado)
        Me.GroupBox1.Controls.Add(Me.Lb_lAnulado)
        Me.GroupBox1.Location = New System.Drawing.Point(487, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(187, 139)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        '
        'btn_Faltantes
        '
        Me.btn_Faltantes.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_Faltantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Faltantes.Location = New System.Drawing.Point(96, 14)
        Me.btn_Faltantes.Name = "btn_Faltantes"
        Me.btn_Faltantes.Size = New System.Drawing.Size(80, 35)
        Me.btn_Faltantes.TabIndex = 40
        Me.btn_Faltantes.Text = "Faltantes"
        Me.btn_Faltantes.UseVisualStyleBackColor = False
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Btn_Imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Imprimir.Location = New System.Drawing.Point(96, 52)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Size = New System.Drawing.Size(80, 35)
        Me.Btn_Imprimir.TabIndex = 39
        Me.Btn_Imprimir.Text = "Imprimir"
        Me.Btn_Imprimir.UseVisualStyleBackColor = False
        '
        'Lb_Cerrado
        '
        Me.Lb_Cerrado.AutoSize = True
        Me.Lb_Cerrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Lb_Cerrado.ForeColor = System.Drawing.Color.Green
        Me.Lb_Cerrado.Location = New System.Drawing.Point(59, 90)
        Me.Lb_Cerrado.Name = "Lb_Cerrado"
        Me.Lb_Cerrado.Size = New System.Drawing.Size(117, 25)
        Me.Lb_Cerrado.TabIndex = 43
        Me.Lb_Cerrado.Text = "CERRADO"
        Me.Lb_Cerrado.Visible = False
        '
        'CBX_Linea
        '
        Me.CBX_Linea.FormattingEnabled = True
        Me.CBX_Linea.Items.AddRange(New Object() {"Faltantes", "No Chequeado", "Chequeado", "No Sacado", "Sacado", "TODOS"})
        Me.CBX_Linea.Location = New System.Drawing.Point(582, 152)
        Me.CBX_Linea.Name = "CBX_Linea"
        Me.CBX_Linea.Size = New System.Drawing.Size(109, 21)
        Me.CBX_Linea.TabIndex = 8
        Me.CBX_Linea.Text = "TODOS"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(531, 156)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 15)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Estado"
        '
        'ToolTip1
        '
        '
        'txtb_BuscDescripcion
        '
        Me.txtb_BuscDescripcion.AccessibleDescription = ""
        Me.txtb_BuscDescripcion.AccessibleName = ""
        Me.txtb_BuscDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_BuscDescripcion.Location = New System.Drawing.Point(4, 152)
        Me.txtb_BuscDescripcion.Name = "txtb_BuscDescripcion"
        Me.txtb_BuscDescripcion.Size = New System.Drawing.Size(330, 23)
        Me.txtb_BuscDescripcion.TabIndex = 9
        Me.txtb_BuscDescripcion.Tag = ""
        Me.ToolTip1.SetToolTip(Me.txtb_BuscDescripcion, "Busca por descripcion")
        '
        'ReportesDeCarga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(953, 501)
        Me.Controls.Add(Me.txtb_BuscDescripcion)
        Me.Controls.Add(Me.CBX_Linea)
        Me.Controls.Add(Me.DataGV_RepCarSec)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.CBX_Sector)
        Me.MinimumSize = New System.Drawing.Size(969, 541)
        Me.Name = "ReportesDeCarga"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ReportesDeCarga"
        CType(Me.DataGV_RepCarSec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGV_RepCarSec As System.Windows.Forms.DataGridView
    Friend WithEvents txtb_FACFIN As System.Windows.Forms.TextBox
    Friend WithEvents txtb_FACINI As System.Windows.Forms.TextBox
    Friend WithEvents lbl_TotalRuta As System.Windows.Forms.Label
    Friend WithEvents TXB_Hora As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_cerrar As System.Windows.Forms.Button
    Friend WithEvents CBX_Sector As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents dtp_FechaReporte As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Rb_ConBod1 As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_SinBod1 As System.Windows.Forms.RadioButton
    Friend WithEvents btn_Anular As System.Windows.Forms.Button
    Friend WithEvents btn_Generar As System.Windows.Forms.Button
    Friend WithEvents btn_Buscar As System.Windows.Forms.Button
    Friend WithEvents btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents Cbx_Rutas As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txb_Numero As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbl_TotalFaltante As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Peso As System.Windows.Forms.Label
    Friend WithEvents txtb_Ruta As System.Windows.Forms.TextBox
    Friend WithEvents Lb_lAnulado As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Lb_Cerrado As System.Windows.Forms.Label
    Friend WithEvents Btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Btn_Atras As System.Windows.Forms.Button
    Friend WithEvents Btn_Adelante As System.Windows.Forms.Button
    Friend WithEvents CBX_Linea As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btn_Faltantes As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtb_BuscDescripcion As System.Windows.Forms.TextBox
End Class
