<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Usuarios
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtb_Codigo = New System.Windows.Forms.TextBox()
        Me.txtb_Cedula = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtb_Nombre = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Cbx_Puestos = New System.Windows.Forms.ComboBox()
        Me.btn_Guardar = New System.Windows.Forms.Button()
        Me.btn_Modificar = New System.Windows.Forms.Button()
        Me.Btn_Eliminar = New System.Windows.Forms.Button()
        Me.DGV_Usuarios = New System.Windows.Forms.DataGridView()
        Me.txtb_Clave = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtb_Usuario = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbx_Cambiar = New System.Windows.Forms.CheckBox()
        CType(Me.DGV_Usuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 287)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 52)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Nuevo"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(281, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Codigo"
        Me.Label1.Visible = False
        '
        'txtb_Codigo
        '
        Me.txtb_Codigo.Enabled = False
        Me.txtb_Codigo.Location = New System.Drawing.Point(285, 31)
        Me.txtb_Codigo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Codigo.Name = "txtb_Codigo"
        Me.txtb_Codigo.Size = New System.Drawing.Size(132, 22)
        Me.txtb_Codigo.TabIndex = 2
        Me.txtb_Codigo.Visible = False
        '
        'txtb_Cedula
        '
        Me.txtb_Cedula.Enabled = False
        Me.txtb_Cedula.Location = New System.Drawing.Point(13, 31)
        Me.txtb_Cedula.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Cedula.Name = "txtb_Cedula"
        Me.txtb_Cedula.Size = New System.Drawing.Size(132, 22)
        Me.txtb_Cedula.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 11)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cedula"
        '
        'txtb_Nombre
        '
        Me.txtb_Nombre.Enabled = False
        Me.txtb_Nombre.Location = New System.Drawing.Point(20, 95)
        Me.txtb_Nombre.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Nombre.Name = "txtb_Nombre"
        Me.txtb_Nombre.Size = New System.Drawing.Size(397, 22)
        Me.txtb_Nombre.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 75)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Nombre"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 190)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Puesto"
        '
        'Cbx_Puestos
        '
        Me.Cbx_Puestos.Enabled = False
        Me.Cbx_Puestos.FormattingEnabled = True
        Me.Cbx_Puestos.Items.AddRange(New Object() {"Administracion", "Contabilidad", "CuentasXCobrar", "CuentasXPagar", "Facturacion", "Recepcion", "Bodega", "Manager"})
        Me.Cbx_Puestos.Location = New System.Drawing.Point(20, 209)
        Me.Cbx_Puestos.Margin = New System.Windows.Forms.Padding(4)
        Me.Cbx_Puestos.Name = "Cbx_Puestos"
        Me.Cbx_Puestos.Size = New System.Drawing.Size(397, 24)
        Me.Cbx_Puestos.TabIndex = 4
        '
        'btn_Guardar
        '
        Me.btn_Guardar.Enabled = False
        Me.btn_Guardar.Location = New System.Drawing.Point(121, 287)
        Me.btn_Guardar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(100, 52)
        Me.btn_Guardar.TabIndex = 6
        Me.btn_Guardar.Text = "Guardar"
        Me.btn_Guardar.UseVisualStyleBackColor = True
        '
        'btn_Modificar
        '
        Me.btn_Modificar.Enabled = False
        Me.btn_Modificar.Location = New System.Drawing.Point(229, 287)
        Me.btn_Modificar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Modificar.Name = "btn_Modificar"
        Me.btn_Modificar.Size = New System.Drawing.Size(100, 52)
        Me.btn_Modificar.TabIndex = 7
        Me.btn_Modificar.Text = "Modificar"
        Me.btn_Modificar.UseVisualStyleBackColor = True
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.Enabled = False
        Me.Btn_Eliminar.Location = New System.Drawing.Point(337, 287)
        Me.Btn_Eliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Size = New System.Drawing.Size(100, 52)
        Me.Btn_Eliminar.TabIndex = 8
        Me.Btn_Eliminar.Text = "Eliminar"
        Me.Btn_Eliminar.UseVisualStyleBackColor = True
        '
        'DGV_Usuarios
        '
        Me.DGV_Usuarios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_Usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Usuarios.Location = New System.Drawing.Point(445, 15)
        Me.DGV_Usuarios.Margin = New System.Windows.Forms.Padding(4)
        Me.DGV_Usuarios.Name = "DGV_Usuarios"
        Me.DGV_Usuarios.ReadOnly = True
        Me.DGV_Usuarios.Size = New System.Drawing.Size(642, 324)
        Me.DGV_Usuarios.TabIndex = 13
        '
        'txtb_Clave
        '
        Me.txtb_Clave.Enabled = False
        Me.txtb_Clave.Location = New System.Drawing.Point(248, 162)
        Me.txtb_Clave.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Clave.Name = "txtb_Clave"
        Me.txtb_Clave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtb_Clave.Size = New System.Drawing.Size(132, 22)
        Me.txtb_Clave.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(244, 143)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 17)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Password"
        '
        'txtb_Usuario
        '
        Me.txtb_Usuario.Enabled = False
        Me.txtb_Usuario.Location = New System.Drawing.Point(20, 162)
        Me.txtb_Usuario.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Usuario.Name = "txtb_Usuario"
        Me.txtb_Usuario.Size = New System.Drawing.Size(132, 22)
        Me.txtb_Usuario.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 140)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 17)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Usuario"
        '
        'cbx_Cambiar
        '
        Me.cbx_Cambiar.AutoSize = True
        Me.cbx_Cambiar.Location = New System.Drawing.Point(21, 242)
        Me.cbx_Cambiar.Margin = New System.Windows.Forms.Padding(4)
        Me.cbx_Cambiar.Name = "cbx_Cambiar"
        Me.cbx_Cambiar.Size = New System.Drawing.Size(310, 21)
        Me.cbx_Cambiar.TabIndex = 17
        Me.cbx_Cambiar.Text = "Cambiar Clave en el proximo Inicio de sesion"
        Me.cbx_Cambiar.UseVisualStyleBackColor = True
        '
        'Usuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1093, 348)
        Me.Controls.Add(Me.cbx_Cambiar)
        Me.Controls.Add(Me.txtb_Clave)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtb_Usuario)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DGV_Usuarios)
        Me.Controls.Add(Me.Btn_Eliminar)
        Me.Controls.Add(Me.btn_Modificar)
        Me.Controls.Add(Me.btn_Guardar)
        Me.Controls.Add(Me.Cbx_Puestos)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtb_Nombre)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtb_Cedula)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtb_Codigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Usuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios"
        CType(Me.DGV_Usuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtb_Codigo As System.Windows.Forms.TextBox
    Friend WithEvents txtb_Cedula As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtb_Nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cbx_Puestos As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents btn_Modificar As System.Windows.Forms.Button
    Friend WithEvents Btn_Eliminar As System.Windows.Forms.Button
    Friend WithEvents DGV_Usuarios As System.Windows.Forms.DataGridView
    Friend WithEvents txtb_Clave As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtb_Usuario As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbx_Cambiar As System.Windows.Forms.CheckBox
End Class
