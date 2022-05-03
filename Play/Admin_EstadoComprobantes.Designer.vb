<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_EstadoComprobantes
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
        Me.DGV_Respuestas = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtb_Clave = New System.Windows.Forms.TextBox()
        Me.Cmb_Estado = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmb_Tipo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtb_Interno = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Chbx_Corregidos = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btn_Exportar = New System.Windows.Forms.Button()
        Me.txtb_NombreReceptor = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.DGV_Respuestas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_Respuestas
        '
        Me.DGV_Respuestas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_Respuestas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Respuestas.Location = New System.Drawing.Point(16, 121)
        Me.DGV_Respuestas.Margin = New System.Windows.Forms.Padding(4)
        Me.DGV_Respuestas.Name = "DGV_Respuestas"
        Me.DGV_Respuestas.Size = New System.Drawing.Size(1349, 478)
        Me.DGV_Respuestas.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Clave"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1189, 12)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(165, 65)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtb_Clave
        '
        Me.txtb_Clave.Location = New System.Drawing.Point(144, 16)
        Me.txtb_Clave.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Clave.Name = "txtb_Clave"
        Me.txtb_Clave.Size = New System.Drawing.Size(473, 22)
        Me.txtb_Clave.TabIndex = 3
        '
        'Cmb_Estado
        '
        Me.Cmb_Estado.FormattingEnabled = True
        Me.Cmb_Estado.Items.AddRange(New Object() {"rechazado", "aceptado", "Otros", "Todo"})
        Me.Cmb_Estado.Location = New System.Drawing.Point(92, 81)
        Me.Cmb_Estado.Margin = New System.Windows.Forms.Padding(4)
        Me.Cmb_Estado.Name = "Cmb_Estado"
        Me.Cmb_Estado.Size = New System.Drawing.Size(160, 24)
        Me.Cmb_Estado.TabIndex = 4
        Me.Cmb_Estado.Text = "rechazado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 81)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Estado"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(273, 81)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Tipo"
        '
        'Cmb_Tipo
        '
        Me.Cmb_Tipo.FormattingEnabled = True
        Me.Cmb_Tipo.Items.AddRange(New Object() {"TE", "NC", "ND", "FE", "FEE", "FEC", "MR", "Todo"})
        Me.Cmb_Tipo.Location = New System.Drawing.Point(322, 78)
        Me.Cmb_Tipo.Margin = New System.Windows.Forms.Padding(4)
        Me.Cmb_Tipo.Name = "Cmb_Tipo"
        Me.Cmb_Tipo.Size = New System.Drawing.Size(160, 24)
        Me.Cmb_Tipo.TabIndex = 6
        Me.Cmb_Tipo.Text = "Todo"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(31, 607)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "TOTAL"
        Me.Label4.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(112, 607)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(280, 26)
        Me.TextBox2.TabIndex = 9
        Me.TextBox2.Visible = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(915, 14)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(265, 22)
        Me.DateTimePicker1.TabIndex = 10
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(915, 53)
        Me.DateTimePicker2.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(265, 22)
        Me.DateTimePicker2.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(855, 16)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 17)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Desde"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(855, 57)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 17)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Hasta"
        '
        'txtb_Interno
        '
        Me.txtb_Interno.Location = New System.Drawing.Point(639, 45)
        Me.txtb_Interno.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Interno.Name = "txtb_Interno"
        Me.txtb_Interno.Size = New System.Drawing.Size(185, 22)
        Me.txtb_Interno.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(636, 16)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 17)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Interno"
        '
        'Chbx_Corregidos
        '
        Me.Chbx_Corregidos.AutoSize = True
        Me.Chbx_Corregidos.Location = New System.Drawing.Point(498, 78)
        Me.Chbx_Corregidos.Margin = New System.Windows.Forms.Padding(4)
        Me.Chbx_Corregidos.Name = "Chbx_Corregidos"
        Me.Chbx_Corregidos.Size = New System.Drawing.Size(125, 21)
        Me.Chbx_Corregidos.TabIndex = 34
        Me.Chbx_Corregidos.Text = "Ver Corregidos"
        Me.Chbx_Corregidos.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(639, 78)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 28)
        Me.Button2.TabIndex = 35
        Me.Button2.Text = "Listar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btn_Exportar
        '
        Me.btn_Exportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Exportar.Location = New System.Drawing.Point(1189, 607)
        Me.btn_Exportar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Exportar.Name = "btn_Exportar"
        Me.btn_Exportar.Size = New System.Drawing.Size(165, 38)
        Me.btn_Exportar.TabIndex = 36
        Me.btn_Exportar.Text = "Exportar a Excel"
        Me.btn_Exportar.UseVisualStyleBackColor = True
        '
        'txtb_NombreReceptor
        '
        Me.txtb_NombreReceptor.Location = New System.Drawing.Point(144, 46)
        Me.txtb_NombreReceptor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_NombreReceptor.Name = "txtb_NombreReceptor"
        Me.txtb_NombreReceptor.Size = New System.Drawing.Size(473, 22)
        Me.txtb_NombreReceptor.TabIndex = 38
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 48)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 17)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Nombre Receptor"
        '
        'Admin_EstadoComprobantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1371, 645)
        Me.Controls.Add(Me.txtb_NombreReceptor)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btn_Exportar)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Chbx_Corregidos)
        Me.Controls.Add(Me.txtb_Interno)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Cmb_Tipo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cmb_Estado)
        Me.Controls.Add(Me.txtb_Clave)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGV_Respuestas)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Admin_EstadoComprobantes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Admin_EstadoComprobantes"
        CType(Me.DGV_Respuestas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV_Respuestas As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtb_Clave As System.Windows.Forms.TextBox
    Friend WithEvents Cmb_Estado As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cmb_Tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtb_Interno As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Chbx_Corregidos As CheckBox
    Friend WithEvents Button2 As Button
    Friend WithEvents btn_Exportar As Button
    Friend WithEvents txtb_NombreReceptor As TextBox
    Friend WithEvents Label8 As Label
End Class
