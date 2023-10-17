<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Manager_Empresa
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
        Me.btn_Nuevo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txtb_Cedula = New System.Windows.Forms.TextBox()
        Me.Txtb_Nombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txtb_Telefono = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txtb_Email = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txtb_Web = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txtb_Direccion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_Eliminar = New System.Windows.Forms.Button()
        Me.btn_Modificar = New System.Windows.Forms.Button()
        Me.btn_Guardar = New System.Windows.Forms.Button()
        Me.txtb_Fantacia = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Combo_Barrio = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Combo_Provincia = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Combo_Canton = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Combo_Distrito = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Cmb_TipoCedula = New System.Windows.Forms.ComboBox()
        Me.Txtb_Telefono2 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Txtb_ClaveEmail = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtb_CodActividadEconomica = New System.Windows.Forms.TextBox()
        Me.txtb_DescrActividadEconomica = New System.Windows.Forms.TextBox()
        Me.CBox_UtilozoSAP = New System.Windows.Forms.CheckBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.RBtn_SocioNegocioEspecifico = New System.Windows.Forms.RadioButton()
        Me.RBtn_GrupoClientes = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Txtb_IPServidorSQL = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtb_ServidorSQL = New System.Windows.Forms.TextBox()
        Me.txtb_UsuarioSQL = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtb_ClaveSQL = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Txtb_DiasExtencion = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txtb_LinMax_Fac = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Txtb_DescMax = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Txtb_Conse_RepCarga = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Txtb_Conse_RepDevoluciones = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btn_EliminaRazon = New System.Windows.Forms.Button()
        Me.CboBox_Razones = New System.Windows.Forms.ComboBox()
        Me.Txtb_Razon = New System.Windows.Forms.TextBox()
        Me.btn_Razon = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Txtb_RutaPadreFtp = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txtb_Servidor = New System.Windows.Forms.TextBox()
        Me.Txtb_Usuario = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txtb_Clave = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Nuevo
        '
        Me.btn_Nuevo.Location = New System.Drawing.Point(16, 4)
        Me.btn_Nuevo.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Nuevo.Name = "btn_Nuevo"
        Me.btn_Nuevo.Size = New System.Drawing.Size(169, 57)
        Me.btn_Nuevo.TabIndex = 0
        Me.btn_Nuevo.Text = "NUEVO"
        Me.btn_Nuevo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(277, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cedula *"
        '
        'Txtb_Cedula
        '
        Me.Txtb_Cedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_Cedula.Location = New System.Drawing.Point(281, 45)
        Me.Txtb_Cedula.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_Cedula.Name = "Txtb_Cedula"
        Me.Txtb_Cedula.Size = New System.Drawing.Size(254, 27)
        Me.Txtb_Cedula.TabIndex = 2
        '
        'Txtb_Nombre
        '
        Me.Txtb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_Nombre.Location = New System.Drawing.Point(20, 98)
        Me.Txtb_Nombre.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_Nombre.Name = "Txtb_Nombre"
        Me.Txtb_Nombre.Size = New System.Drawing.Size(1039, 27)
        Me.Txtb_Nombre.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 72)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nombre *"
        '
        'Txtb_Telefono
        '
        Me.Txtb_Telefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_Telefono.Location = New System.Drawing.Point(543, 43)
        Me.Txtb_Telefono.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_Telefono.Name = "Txtb_Telefono"
        Me.Txtb_Telefono.Size = New System.Drawing.Size(254, 27)
        Me.Txtb_Telefono.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(539, 19)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Telefono *"
        '
        'Txtb_Email
        '
        Me.Txtb_Email.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_Email.Location = New System.Drawing.Point(543, 223)
        Me.Txtb_Email.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_Email.Name = "Txtb_Email"
        Me.Txtb_Email.Size = New System.Drawing.Size(254, 27)
        Me.Txtb_Email.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(539, 194)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Email *"
        '
        'Txtb_Web
        '
        Me.Txtb_Web.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_Web.Location = New System.Drawing.Point(19, 218)
        Me.Txtb_Web.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_Web.Name = "Txtb_Web"
        Me.Txtb_Web.Size = New System.Drawing.Size(443, 27)
        Me.Txtb_Web.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 194)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 20)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Pagina Web*"
        '
        'Txtb_Direccion
        '
        Me.Txtb_Direccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_Direccion.Location = New System.Drawing.Point(20, 406)
        Me.Txtb_Direccion.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_Direccion.Multiline = True
        Me.Txtb_Direccion.Name = "Txtb_Direccion"
        Me.Txtb_Direccion.Size = New System.Drawing.Size(1030, 83)
        Me.Txtb_Direccion.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 382)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(247, 20)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Otras Reseñas de la direccion *"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_Eliminar)
        Me.Panel1.Controls.Add(Me.btn_Modificar)
        Me.Panel1.Controls.Add(Me.btn_Guardar)
        Me.Panel1.Controls.Add(Me.btn_Nuevo)
        Me.Panel1.Location = New System.Drawing.Point(6, 634)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1072, 64)
        Me.Panel1.TabIndex = 13
        '
        'btn_Eliminar
        '
        Me.btn_Eliminar.Location = New System.Drawing.Point(881, 4)
        Me.btn_Eliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Eliminar.Name = "btn_Eliminar"
        Me.btn_Eliminar.Size = New System.Drawing.Size(169, 57)
        Me.btn_Eliminar.TabIndex = 3
        Me.btn_Eliminar.Text = "ELIMINAR"
        Me.btn_Eliminar.UseVisualStyleBackColor = True
        '
        'btn_Modificar
        '
        Me.btn_Modificar.Location = New System.Drawing.Point(371, 4)
        Me.btn_Modificar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Modificar.Name = "btn_Modificar"
        Me.btn_Modificar.Size = New System.Drawing.Size(169, 57)
        Me.btn_Modificar.TabIndex = 2
        Me.btn_Modificar.Text = "MODIFICAR"
        Me.btn_Modificar.UseVisualStyleBackColor = True
        '
        'btn_Guardar
        '
        Me.btn_Guardar.Location = New System.Drawing.Point(193, 4)
        Me.btn_Guardar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(169, 57)
        Me.btn_Guardar.TabIndex = 1
        Me.btn_Guardar.Text = "GUARDAR"
        Me.btn_Guardar.UseVisualStyleBackColor = True
        '
        'txtb_Fantacia
        '
        Me.txtb_Fantacia.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Fantacia.Location = New System.Drawing.Point(20, 152)
        Me.txtb_Fantacia.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Fantacia.Name = "txtb_Fantacia"
        Me.txtb_Fantacia.Size = New System.Drawing.Size(1039, 27)
        Me.txtb_Fantacia.TabIndex = 35
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(16, 127)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(171, 20)
        Me.Label17.TabIndex = 34
        Me.Label17.Text = "Nombre de Fantacia *"
        '
        'Combo_Barrio
        '
        Me.Combo_Barrio.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_Barrio.FormattingEnabled = True
        Me.Combo_Barrio.Location = New System.Drawing.Point(805, 273)
        Me.Combo_Barrio.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_Barrio.Name = "Combo_Barrio"
        Me.Combo_Barrio.Size = New System.Drawing.Size(254, 28)
        Me.Combo_Barrio.TabIndex = 44
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(15, 249)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 20)
        Me.Label18.TabIndex = 37
        Me.Label18.Text = "Provincias *"
        '
        'Combo_Provincia
        '
        Me.Combo_Provincia.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_Provincia.FormattingEnabled = True
        Me.Combo_Provincia.Location = New System.Drawing.Point(19, 273)
        Me.Combo_Provincia.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_Provincia.Name = "Combo_Provincia"
        Me.Combo_Provincia.Size = New System.Drawing.Size(254, 28)
        Me.Combo_Provincia.TabIndex = 38
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(277, 249)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(91, 20)
        Me.Label19.TabIndex = 39
        Me.Label19.Text = "Cantones *"
        '
        'Combo_Canton
        '
        Me.Combo_Canton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_Canton.FormattingEnabled = True
        Me.Combo_Canton.Location = New System.Drawing.Point(281, 273)
        Me.Combo_Canton.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_Canton.Name = "Combo_Canton"
        Me.Combo_Canton.Size = New System.Drawing.Size(254, 28)
        Me.Combo_Canton.TabIndex = 40
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(539, 246)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(84, 20)
        Me.Label20.TabIndex = 41
        Me.Label20.Text = "Distritos *"
        '
        'Combo_Distrito
        '
        Me.Combo_Distrito.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_Distrito.FormattingEnabled = True
        Me.Combo_Distrito.Location = New System.Drawing.Point(543, 273)
        Me.Combo_Distrito.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_Distrito.Name = "Combo_Distrito"
        Me.Combo_Distrito.Size = New System.Drawing.Size(254, 28)
        Me.Combo_Distrito.TabIndex = 42
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(801, 249)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(75, 20)
        Me.Label21.TabIndex = 43
        Me.Label21.Text = "Barrios *"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(16, 19)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(129, 20)
        Me.Label22.TabIndex = 45
        Me.Label22.Text = "Tipo de cedula *"
        '
        'Cmb_TipoCedula
        '
        Me.Cmb_TipoCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_TipoCedula.FormattingEnabled = True
        Me.Cmb_TipoCedula.Items.AddRange(New Object() {"", "Cédula Física", "Cédula Jurídica", "DIMEX", "NITE"})
        Me.Cmb_TipoCedula.Location = New System.Drawing.Point(19, 43)
        Me.Cmb_TipoCedula.Margin = New System.Windows.Forms.Padding(4)
        Me.Cmb_TipoCedula.Name = "Cmb_TipoCedula"
        Me.Cmb_TipoCedula.Size = New System.Drawing.Size(254, 28)
        Me.Cmb_TipoCedula.TabIndex = 46
        '
        'Txtb_Telefono2
        '
        Me.Txtb_Telefono2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_Telefono2.Location = New System.Drawing.Point(805, 43)
        Me.Txtb_Telefono2.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_Telefono2.Name = "Txtb_Telefono2"
        Me.Txtb_Telefono2.Size = New System.Drawing.Size(254, 27)
        Me.Txtb_Telefono2.TabIndex = 49
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(801, 17)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(105, 20)
        Me.Label16.TabIndex = 48
        Me.Label16.Text = "Telefono Fax"
        '
        'Txtb_ClaveEmail
        '
        Me.Txtb_ClaveEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_ClaveEmail.Location = New System.Drawing.Point(805, 223)
        Me.Txtb_ClaveEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_ClaveEmail.Name = "Txtb_ClaveEmail"
        Me.Txtb_ClaveEmail.Size = New System.Drawing.Size(254, 27)
        Me.Txtb_ClaveEmail.TabIndex = 83
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(801, 194)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(62, 20)
        Me.Label23.TabIndex = 82
        Me.Label23.Text = "Clave *"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(15, 314)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(176, 20)
        Me.Label24.TabIndex = 82
        Me.Label24.Text = "Actividad Economica *"
        '
        'txtb_CodActividadEconomica
        '
        Me.txtb_CodActividadEconomica.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_CodActividadEconomica.Location = New System.Drawing.Point(20, 338)
        Me.txtb_CodActividadEconomica.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_CodActividadEconomica.Name = "txtb_CodActividadEconomica"
        Me.txtb_CodActividadEconomica.Size = New System.Drawing.Size(253, 27)
        Me.txtb_CodActividadEconomica.TabIndex = 83
        '
        'txtb_DescrActividadEconomica
        '
        Me.txtb_DescrActividadEconomica.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_DescrActividadEconomica.Location = New System.Drawing.Point(281, 338)
        Me.txtb_DescrActividadEconomica.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_DescrActividadEconomica.Name = "txtb_DescrActividadEconomica"
        Me.txtb_DescrActividadEconomica.Size = New System.Drawing.Size(778, 27)
        Me.txtb_DescrActividadEconomica.TabIndex = 84
        '
        'CBox_UtilozoSAP
        '
        Me.CBox_UtilozoSAP.AutoSize = True
        Me.CBox_UtilozoSAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBox_UtilozoSAP.Location = New System.Drawing.Point(392, 283)
        Me.CBox_UtilozoSAP.Name = "CBox_UtilozoSAP"
        Me.CBox_UtilozoSAP.Size = New System.Drawing.Size(116, 24)
        Me.CBox_UtilozoSAP.TabIndex = 85
        Me.CBox_UtilozoSAP.Text = "Utilizo SAP"
        Me.CBox_UtilozoSAP.UseVisualStyleBackColor = True
        Me.CBox_UtilozoSAP.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(2, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1080, 628)
        Me.TabControl1.TabIndex = 86
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label22)
        Me.TabPage1.Controls.Add(Me.txtb_DescrActividadEconomica)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtb_CodActividadEconomica)
        Me.TabPage1.Controls.Add(Me.Txtb_Cedula)
        Me.TabPage1.Controls.Add(Me.Label24)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Txtb_ClaveEmail)
        Me.TabPage1.Controls.Add(Me.Txtb_Nombre)
        Me.TabPage1.Controls.Add(Me.Label23)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Txtb_Telefono2)
        Me.TabPage1.Controls.Add(Me.Txtb_Telefono)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Txtb_Email)
        Me.TabPage1.Controls.Add(Me.Cmb_TipoCedula)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Combo_Barrio)
        Me.TabPage1.Controls.Add(Me.Txtb_Web)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Combo_Provincia)
        Me.TabPage1.Controls.Add(Me.Txtb_Direccion)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.Combo_Canton)
        Me.TabPage1.Controls.Add(Me.txtb_Fantacia)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.Label21)
        Me.TabPage1.Controls.Add(Me.Combo_Distrito)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1072, 599)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Empresa"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.CBox_UtilozoSAP)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1072, 599)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Configuraciones"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.RBtn_SocioNegocioEspecifico)
        Me.GroupBox5.Controls.Add(Me.RBtn_GrupoClientes)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(516, 302)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(534, 165)
        Me.GroupBox5.TabIndex = 86
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Descuentos"
        Me.GroupBox5.Visible = False
        '
        'RBtn_SocioNegocioEspecifico
        '
        Me.RBtn_SocioNegocioEspecifico.AutoSize = True
        Me.RBtn_SocioNegocioEspecifico.Location = New System.Drawing.Point(17, 26)
        Me.RBtn_SocioNegocioEspecifico.Name = "RBtn_SocioNegocioEspecifico"
        Me.RBtn_SocioNegocioEspecifico.Size = New System.Drawing.Size(244, 24)
        Me.RBtn_SocioNegocioEspecifico.TabIndex = 1
        Me.RBtn_SocioNegocioEspecifico.Text = "Socio de Negocio Especifico"
        Me.RBtn_SocioNegocioEspecifico.UseVisualStyleBackColor = True
        '
        'RBtn_GrupoClientes
        '
        Me.RBtn_GrupoClientes.AutoSize = True
        Me.RBtn_GrupoClientes.Checked = True
        Me.RBtn_GrupoClientes.Location = New System.Drawing.Point(17, 58)
        Me.RBtn_GrupoClientes.Name = "RBtn_GrupoClientes"
        Me.RBtn_GrupoClientes.Size = New System.Drawing.Size(174, 24)
        Me.RBtn_GrupoClientes.TabIndex = 0
        Me.RBtn_GrupoClientes.TabStop = True
        Me.RBtn_GrupoClientes.Text = "Grupos de Clientes"
        Me.RBtn_GrupoClientes.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Txtb_IPServidorSQL)
        Me.GroupBox4.Controls.Add(Me.Label29)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Controls.Add(Me.txtb_ServidorSQL)
        Me.GroupBox4.Controls.Add(Me.txtb_UsuarioSQL)
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Controls.Add(Me.Label27)
        Me.GroupBox4.Controls.Add(Me.txtb_ClaveSQL)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(19, 302)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(489, 165)
        Me.GroupBox4.TabIndex = 49
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "SAP Bussines one"
        '
        'Txtb_IPServidorSQL
        '
        Me.Txtb_IPServidorSQL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_IPServidorSQL.Location = New System.Drawing.Point(307, 89)
        Me.Txtb_IPServidorSQL.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_IPServidorSQL.Name = "Txtb_IPServidorSQL"
        Me.Txtb_IPServidorSQL.Size = New System.Drawing.Size(139, 27)
        Me.Txtb_IPServidorSQL.TabIndex = 21
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(275, 92)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(24, 20)
        Me.Label29.TabIndex = 20
        Me.Label29.Text = "IP"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(12, 23)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(72, 20)
        Me.Label25.TabIndex = 14
        Me.Label25.Text = "Usuario "
        '
        'txtb_ServidorSQL
        '
        Me.txtb_ServidorSQL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_ServidorSQL.Location = New System.Drawing.Point(139, 89)
        Me.txtb_ServidorSQL.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_ServidorSQL.Name = "txtb_ServidorSQL"
        Me.txtb_ServidorSQL.Size = New System.Drawing.Size(128, 27)
        Me.txtb_ServidorSQL.TabIndex = 19
        '
        'txtb_UsuarioSQL
        '
        Me.txtb_UsuarioSQL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_UsuarioSQL.Location = New System.Drawing.Point(141, 23)
        Me.txtb_UsuarioSQL.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_UsuarioSQL.Name = "txtb_UsuarioSQL"
        Me.txtb_UsuarioSQL.Size = New System.Drawing.Size(305, 27)
        Me.txtb_UsuarioSQL.TabIndex = 15
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(8, 92)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(76, 20)
        Me.Label26.TabIndex = 18
        Me.Label26.Text = "Servidor "
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(12, 56)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(51, 20)
        Me.Label27.TabIndex = 16
        Me.Label27.Text = "Clave"
        '
        'txtb_ClaveSQL
        '
        Me.txtb_ClaveSQL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_ClaveSQL.Location = New System.Drawing.Point(139, 56)
        Me.txtb_ClaveSQL.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_ClaveSQL.Name = "txtb_ClaveSQL"
        Me.txtb_ClaveSQL.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.txtb_ClaveSQL.Size = New System.Drawing.Size(307, 27)
        Me.txtb_ClaveSQL.TabIndex = 17
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label30)
        Me.GroupBox3.Controls.Add(Me.Txtb_DiasExtencion)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Txtb_LinMax_Fac)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Txtb_DescMax)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Txtb_Conse_RepCarga)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Txtb_Conse_RepDevoluciones)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(19, 7)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(1031, 91)
        Me.GroupBox3.TabIndex = 51
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Consecutivos de:"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(406, 27)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(122, 20)
        Me.Label30.TabIndex = 33
        Me.Label30.Text = "Dias Extencion"
        '
        'Txtb_DiasExtencion
        '
        Me.Txtb_DiasExtencion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_DiasExtencion.Location = New System.Drawing.Point(406, 53)
        Me.Txtb_DiasExtencion.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_DiasExtencion.Name = "Txtb_DiasExtencion"
        Me.Txtb_DiasExtencion.Size = New System.Drawing.Size(186, 27)
        Me.Txtb_DiasExtencion.TabIndex = 34
        Me.Txtb_DiasExtencion.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 27)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 20)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Maximo de lineas"
        '
        'Txtb_LinMax_Fac
        '
        Me.Txtb_LinMax_Fac.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_LinMax_Fac.Location = New System.Drawing.Point(18, 52)
        Me.Txtb_LinMax_Fac.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_LinMax_Fac.Name = "Txtb_LinMax_Fac"
        Me.Txtb_LinMax_Fac.Size = New System.Drawing.Size(186, 27)
        Me.Txtb_LinMax_Fac.TabIndex = 22
        Me.Txtb_LinMax_Fac.Text = "1"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(208, 28)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(190, 20)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Descuento Max General"
        '
        'Txtb_DescMax
        '
        Me.Txtb_DescMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_DescMax.Location = New System.Drawing.Point(212, 53)
        Me.Txtb_DescMax.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_DescMax.Name = "Txtb_DescMax"
        Me.Txtb_DescMax.Size = New System.Drawing.Size(186, 27)
        Me.Txtb_DescMax.TabIndex = 24
        Me.Txtb_DescMax.Text = "0"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(596, 27)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(141, 20)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Reporte de Carga"
        '
        'Txtb_Conse_RepCarga
        '
        Me.Txtb_Conse_RepCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_Conse_RepCarga.Location = New System.Drawing.Point(600, 53)
        Me.Txtb_Conse_RepCarga.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_Conse_RepCarga.Name = "Txtb_Conse_RepCarga"
        Me.Txtb_Conse_RepCarga.Size = New System.Drawing.Size(186, 27)
        Me.Txtb_Conse_RepCarga.TabIndex = 30
        Me.Txtb_Conse_RepCarga.Text = "1"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(790, 27)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(197, 20)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "Reporte de Devoluciones"
        '
        'Txtb_Conse_RepDevoluciones
        '
        Me.Txtb_Conse_RepDevoluciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_Conse_RepDevoluciones.Location = New System.Drawing.Point(794, 53)
        Me.Txtb_Conse_RepDevoluciones.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_Conse_RepDevoluciones.Name = "Txtb_Conse_RepDevoluciones"
        Me.Txtb_Conse_RepDevoluciones.Size = New System.Drawing.Size(186, 27)
        Me.Txtb_Conse_RepDevoluciones.TabIndex = 32
        Me.Txtb_Conse_RepDevoluciones.Text = "1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.btn_EliminaRazon)
        Me.GroupBox2.Controls.Add(Me.CboBox_Razones)
        Me.GroupBox2.Controls.Add(Me.Txtb_Razon)
        Me.GroupBox2.Controls.Add(Me.btn_Razon)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(516, 106)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(534, 165)
        Me.GroupBox2.TabIndex = 50
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Administra razones de no visita"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(13, 30)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 20)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Nueva Razon "
        '
        'btn_EliminaRazon
        '
        Me.btn_EliminaRazon.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_EliminaRazon.Location = New System.Drawing.Point(305, 99)
        Me.btn_EliminaRazon.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_EliminaRazon.Name = "btn_EliminaRazon"
        Me.btn_EliminaRazon.Size = New System.Drawing.Size(146, 44)
        Me.btn_EliminaRazon.TabIndex = 28
        Me.btn_EliminaRazon.Text = "Eliminar"
        Me.btn_EliminaRazon.UseVisualStyleBackColor = True
        Me.btn_EliminaRazon.Visible = False
        '
        'CboBox_Razones
        '
        Me.CboBox_Razones.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboBox_Razones.FormattingEnabled = True
        Me.CboBox_Razones.Location = New System.Drawing.Point(141, 59)
        Me.CboBox_Razones.Margin = New System.Windows.Forms.Padding(4)
        Me.CboBox_Razones.Name = "CboBox_Razones"
        Me.CboBox_Razones.Size = New System.Drawing.Size(310, 28)
        Me.CboBox_Razones.TabIndex = 26
        '
        'Txtb_Razon
        '
        Me.Txtb_Razon.Enabled = False
        Me.Txtb_Razon.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_Razon.Location = New System.Drawing.Point(141, 27)
        Me.Txtb_Razon.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_Razon.Name = "Txtb_Razon"
        Me.Txtb_Razon.Size = New System.Drawing.Size(310, 27)
        Me.Txtb_Razon.TabIndex = 27
        '
        'btn_Razon
        '
        Me.btn_Razon.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Razon.Location = New System.Drawing.Point(141, 99)
        Me.btn_Razon.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Razon.Name = "btn_Razon"
        Me.btn_Razon.Size = New System.Drawing.Size(146, 44)
        Me.btn_Razon.TabIndex = 25
        Me.btn_Razon.Text = "Nuevo"
        Me.btn_Razon.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(13, 62)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 20)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Razones"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Txtb_RutaPadreFtp)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Txtb_Servidor)
        Me.GroupBox1.Controls.Add(Me.Txtb_Usuario)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Txtb_Clave)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(19, 106)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(489, 165)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Info Servidor FTP"
        '
        'Txtb_RutaPadreFtp
        '
        Me.Txtb_RutaPadreFtp.AccessibleDescription = ""
        Me.Txtb_RutaPadreFtp.Enabled = False
        Me.Txtb_RutaPadreFtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_RutaPadreFtp.Location = New System.Drawing.Point(140, 125)
        Me.Txtb_RutaPadreFtp.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_RutaPadreFtp.Name = "Txtb_RutaPadreFtp"
        Me.Txtb_RutaPadreFtp.Size = New System.Drawing.Size(304, 27)
        Me.Txtb_RutaPadreFtp.TabIndex = 21
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(12, 128)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(93, 20)
        Me.Label28.TabIndex = 20
        Me.Label28.Text = "Ruta Padre"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 23)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 20)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Usuario "
        '
        'Txtb_Servidor
        '
        Me.Txtb_Servidor.Enabled = False
        Me.Txtb_Servidor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_Servidor.Location = New System.Drawing.Point(140, 91)
        Me.Txtb_Servidor.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_Servidor.Name = "Txtb_Servidor"
        Me.Txtb_Servidor.Size = New System.Drawing.Size(304, 27)
        Me.Txtb_Servidor.TabIndex = 19
        '
        'Txtb_Usuario
        '
        Me.Txtb_Usuario.Enabled = False
        Me.Txtb_Usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_Usuario.Location = New System.Drawing.Point(141, 17)
        Me.Txtb_Usuario.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_Usuario.Name = "Txtb_Usuario"
        Me.Txtb_Usuario.Size = New System.Drawing.Size(305, 27)
        Me.Txtb_Usuario.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 94)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 20)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Servidor "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 53)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 20)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Clave"
        '
        'Txtb_Clave
        '
        Me.Txtb_Clave.Enabled = False
        Me.Txtb_Clave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_Clave.Location = New System.Drawing.Point(139, 53)
        Me.Txtb_Clave.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_Clave.Name = "Txtb_Clave"
        Me.Txtb_Clave.Size = New System.Drawing.Size(305, 27)
        Me.Txtb_Clave.TabIndex = 17
        '
        'Manager_Empresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1085, 703)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Manager_Empresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manager_Empresa"
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txtb_Cedula As System.Windows.Forms.TextBox
    Friend WithEvents Txtb_Nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txtb_Telefono As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txtb_Email As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txtb_Web As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txtb_Direccion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_Eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_Modificar As System.Windows.Forms.Button
    Friend WithEvents btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents txtb_Fantacia As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Combo_Barrio As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Combo_Provincia As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Combo_Canton As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Combo_Distrito As ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Cmb_TipoCedula As ComboBox
    Friend WithEvents Txtb_Telefono2 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Txtb_ClaveEmail As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents txtb_CodActividadEconomica As TextBox
    Friend WithEvents txtb_DescrActividadEconomica As TextBox
    Friend WithEvents CBox_UtilozoSAP As CheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Txtb_IPServidorSQL As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents txtb_ServidorSQL As TextBox
    Friend WithEvents txtb_UsuarioSQL As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents txtb_ClaveSQL As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Txtb_DiasExtencion As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Txtb_LinMax_Fac As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Txtb_DescMax As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Txtb_Conse_RepCarga As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Txtb_Conse_RepDevoluciones As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents btn_EliminaRazon As Button
    Friend WithEvents CboBox_Razones As ComboBox
    Friend WithEvents Txtb_Razon As TextBox
    Friend WithEvents btn_Razon As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Txtb_RutaPadreFtp As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Txtb_Servidor As TextBox
    Friend WithEvents Txtb_Usuario As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Txtb_Clave As TextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents RBtn_SocioNegocioEspecifico As RadioButton
    Friend WithEvents RBtn_GrupoClientes As RadioButton
End Class
