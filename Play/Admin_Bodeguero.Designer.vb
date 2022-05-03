<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Bodeguero
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.cbx_puesto = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtb_Cedula = New System.Windows.Forms.TextBox()
        Me.txtb_Clave = New System.Windows.Forms.TextBox()
        Me.txtb_Usuario = New System.Windows.Forms.TextBox()
        Me.DGV_Bodegueros = New System.Windows.Forms.DataGridView()
        Me.txtb_Correo = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtb_RutaFTP = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtb_Cod = New System.Windows.Forms.TextBox()
        Me.txtb_Nombre = New System.Windows.Forms.TextBox()
        Me.txtb_telf = New System.Windows.Forms.TextBox()
        Me.btn_AgNuevo = New System.Windows.Forms.Button()
        Me.btn_AgElimina = New System.Windows.Forms.Button()
        Me.btn_AgGuardar = New System.Windows.Forms.Button()
        Me.btn_AgModif = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtb_ConsDevoluciones = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtb_ConsPe = New System.Windows.Forms.TextBox()
        Me.Panel2.SuspendLayout()
        CType(Me.DGV_Bodegueros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.CheckedListBox1)
        Me.Panel2.Controls.Add(Me.cbx_puesto)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtb_Cedula)
        Me.Panel2.Controls.Add(Me.txtb_Clave)
        Me.Panel2.Controls.Add(Me.txtb_Usuario)
        Me.Panel2.Controls.Add(Me.DGV_Bodegueros)
        Me.Panel2.Controls.Add(Me.txtb_Correo)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txtb_RutaFTP)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txtb_Cod)
        Me.Panel2.Controls.Add(Me.txtb_Nombre)
        Me.Panel2.Controls.Add(Me.txtb_telf)
        Me.Panel2.Controls.Add(Me.btn_AgNuevo)
        Me.Panel2.Controls.Add(Me.btn_AgElimina)
        Me.Panel2.Controls.Add(Me.btn_AgGuardar)
        Me.Panel2.Controls.Add(Me.btn_AgModif)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1273, 471)
        Me.Panel2.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(323, 113)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 17)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Asigne Sectores"
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.Enabled = False
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Items.AddRange(New Object() {"Sector 1", "Sector 2", "Sector 3", "Sector 4", "Sector 5", "Sector 6", "Sector 7", "Sector 8", "Sector 9", "Sector 10", "Sector 11", "Sector 12", "Sector 13", "Sector 14", "Sector 15", "Sector 16", "Sector 17", "Sector 18", "Sector 19", "Sector 20"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(327, 135)
        Me.CheckedListBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckedListBox1.MultiColumn = True
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.ScrollAlwaysVisible = True
        Me.CheckedListBox1.Size = New System.Drawing.Size(273, 225)
        Me.CheckedListBox1.TabIndex = 21
        '
        'cbx_puesto
        '
        Me.cbx_puesto.Enabled = False
        Me.cbx_puesto.FormattingEnabled = True
        Me.cbx_puesto.Items.AddRange(New Object() {"Bodeguero", "Chequeador", "Jefe"})
        Me.cbx_puesto.Location = New System.Drawing.Point(23, 182)
        Me.cbx_puesto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbx_puesto.Name = "cbx_puesto"
        Me.cbx_puesto.Size = New System.Drawing.Size(253, 24)
        Me.cbx_puesto.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 160)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Puesto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(168, 11)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 17)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Cedula"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(464, 14)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 17)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Clave"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(323, 14)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Usuario"
        '
        'txtb_Cedula
        '
        Me.txtb_Cedula.Location = New System.Drawing.Point(172, 33)
        Me.txtb_Cedula.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtb_Cedula.Name = "txtb_Cedula"
        Me.txtb_Cedula.Size = New System.Drawing.Size(132, 22)
        Me.txtb_Cedula.TabIndex = 1
        '
        'txtb_Clave
        '
        Me.txtb_Clave.Enabled = False
        Me.txtb_Clave.Location = New System.Drawing.Point(468, 33)
        Me.txtb_Clave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtb_Clave.Name = "txtb_Clave"
        Me.txtb_Clave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.txtb_Clave.Size = New System.Drawing.Size(132, 22)
        Me.txtb_Clave.TabIndex = 1
        '
        'txtb_Usuario
        '
        Me.txtb_Usuario.Enabled = False
        Me.txtb_Usuario.Location = New System.Drawing.Point(327, 33)
        Me.txtb_Usuario.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtb_Usuario.Name = "txtb_Usuario"
        Me.txtb_Usuario.Size = New System.Drawing.Size(132, 22)
        Me.txtb_Usuario.TabIndex = 1
        '
        'DGV_Bodegueros
        '
        Me.DGV_Bodegueros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_Bodegueros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Bodegueros.Location = New System.Drawing.Point(636, 4)
        Me.DGV_Bodegueros.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DGV_Bodegueros.Name = "DGV_Bodegueros"
        Me.DGV_Bodegueros.ReadOnly = True
        Me.DGV_Bodegueros.Size = New System.Drawing.Size(633, 464)
        Me.DGV_Bodegueros.TabIndex = 21
        '
        'txtb_Correo
        '
        Me.txtb_Correo.Enabled = False
        Me.txtb_Correo.Location = New System.Drawing.Point(23, 238)
        Me.txtb_Correo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtb_Correo.Name = "txtb_Correo"
        Me.txtb_Correo.Size = New System.Drawing.Size(253, 22)
        Me.txtb_Correo.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(23, 218)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 17)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Correo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 14)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Codigo"
        '
        'txtb_RutaFTP
        '
        Me.txtb_RutaFTP.Enabled = False
        Me.txtb_RutaFTP.Location = New System.Drawing.Point(23, 299)
        Me.txtb_RutaFTP.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtb_RutaFTP.Name = "txtb_RutaFTP"
        Me.txtb_RutaFTP.Size = New System.Drawing.Size(253, 22)
        Me.txtb_RutaFTP.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 65)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 17)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Nombre"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(23, 277)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 17)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "Ruta FTP"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 113)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 17)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Telefono"
        '
        'txtb_Cod
        '
        Me.txtb_Cod.Enabled = False
        Me.txtb_Cod.Location = New System.Drawing.Point(24, 33)
        Me.txtb_Cod.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtb_Cod.Name = "txtb_Cod"
        Me.txtb_Cod.Size = New System.Drawing.Size(132, 22)
        Me.txtb_Cod.TabIndex = 0
        '
        'txtb_Nombre
        '
        Me.txtb_Nombre.Enabled = False
        Me.txtb_Nombre.Location = New System.Drawing.Point(24, 85)
        Me.txtb_Nombre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtb_Nombre.Name = "txtb_Nombre"
        Me.txtb_Nombre.Size = New System.Drawing.Size(576, 22)
        Me.txtb_Nombre.TabIndex = 2
        '
        'txtb_telf
        '
        Me.txtb_telf.Enabled = False
        Me.txtb_telf.Location = New System.Drawing.Point(23, 133)
        Me.txtb_telf.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtb_telf.Name = "txtb_telf"
        Me.txtb_telf.Size = New System.Drawing.Size(253, 22)
        Me.txtb_telf.TabIndex = 3
        '
        'btn_AgNuevo
        '
        Me.btn_AgNuevo.Location = New System.Drawing.Point(108, 384)
        Me.btn_AgNuevo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_AgNuevo.Name = "btn_AgNuevo"
        Me.btn_AgNuevo.Size = New System.Drawing.Size(100, 47)
        Me.btn_AgNuevo.TabIndex = 11
        Me.btn_AgNuevo.Text = "Nuevo"
        Me.btn_AgNuevo.UseVisualStyleBackColor = True
        '
        'btn_AgElimina
        '
        Me.btn_AgElimina.Enabled = False
        Me.btn_AgElimina.Location = New System.Drawing.Point(432, 384)
        Me.btn_AgElimina.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_AgElimina.Name = "btn_AgElimina"
        Me.btn_AgElimina.Size = New System.Drawing.Size(100, 47)
        Me.btn_AgElimina.TabIndex = 10
        Me.btn_AgElimina.Text = "Eliminar"
        Me.btn_AgElimina.UseVisualStyleBackColor = True
        '
        'btn_AgGuardar
        '
        Me.btn_AgGuardar.Location = New System.Drawing.Point(216, 384)
        Me.btn_AgGuardar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_AgGuardar.Name = "btn_AgGuardar"
        Me.btn_AgGuardar.Size = New System.Drawing.Size(100, 47)
        Me.btn_AgGuardar.TabIndex = 8
        Me.btn_AgGuardar.Text = "Guardar"
        Me.btn_AgGuardar.UseVisualStyleBackColor = True
        '
        'btn_AgModif
        '
        Me.btn_AgModif.Enabled = False
        Me.btn_AgModif.Location = New System.Drawing.Point(324, 384)
        Me.btn_AgModif.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_AgModif.Name = "btn_AgModif"
        Me.btn_AgModif.Size = New System.Drawing.Size(100, 47)
        Me.btn_AgModif.TabIndex = 9
        Me.btn_AgModif.Text = "Modificar"
        Me.btn_AgModif.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtb_ConsDevoluciones)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtb_ConsPe)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 545)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(276, 137)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consecutivos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 68)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 17)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Devoluciones"
        '
        'txtb_ConsDevoluciones
        '
        Me.txtb_ConsDevoluciones.Enabled = False
        Me.txtb_ConsDevoluciones.Location = New System.Drawing.Point(12, 87)
        Me.txtb_ConsDevoluciones.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtb_ConsDevoluciones.Name = "txtb_ConsDevoluciones"
        Me.txtb_ConsDevoluciones.Size = New System.Drawing.Size(237, 22)
        Me.txtb_ConsDevoluciones.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 20)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 17)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Reporte Carga"
        '
        'txtb_ConsPe
        '
        Me.txtb_ConsPe.Enabled = False
        Me.txtb_ConsPe.Location = New System.Drawing.Point(15, 39)
        Me.txtb_ConsPe.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtb_ConsPe.Name = "txtb_ConsPe"
        Me.txtb_ConsPe.Size = New System.Drawing.Size(235, 22)
        Me.txtb_ConsPe.TabIndex = 4
        '
        'Admin_Bodeguero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 470)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MinimumSize = New System.Drawing.Size(1211, 509)
        Me.Name = "Admin_Bodeguero"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Admin_Bodeguero"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DGV_Bodegueros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents cbx_puesto As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtb_Usuario As System.Windows.Forms.TextBox
    Friend WithEvents DGV_Bodegueros As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtb_ConsDevoluciones As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtb_ConsPe As System.Windows.Forms.TextBox
    Friend WithEvents txtb_Correo As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtb_RutaFTP As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtb_Cod As System.Windows.Forms.TextBox
    Friend WithEvents txtb_Nombre As System.Windows.Forms.TextBox
    Friend WithEvents txtb_telf As System.Windows.Forms.TextBox
    Friend WithEvents btn_AgNuevo As System.Windows.Forms.Button
    Friend WithEvents btn_AgElimina As System.Windows.Forms.Button
    Friend WithEvents btn_AgGuardar As System.Windows.Forms.Button
    Friend WithEvents btn_AgModif As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtb_Cedula As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtb_Clave As System.Windows.Forms.TextBox
End Class
