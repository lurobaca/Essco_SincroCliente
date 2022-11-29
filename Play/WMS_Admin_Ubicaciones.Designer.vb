<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WMS_Admin_Ubicaciones
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
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.txtb_Columna = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtb_Pasillo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtb_Rack = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtb_NumNiveles = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_eliminar = New System.Windows.Forms.Button()
        Me.txtb_Comentarios = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtb_Planta = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtb_Nombre = New System.Windows.Forms.TextBox()
        Me.txtb_CodBarras = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtb_id = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DGV_Niveles = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Nivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codBarras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Inventario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DGV_Niveles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.Location = New System.Drawing.Point(22, 722)
        Me.btn_guardar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(109, 58)
        Me.btn_guardar.TabIndex = 0
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'txtb_Columna
        '
        Me.txtb_Columna.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Columna.Location = New System.Drawing.Point(288, 153)
        Me.txtb_Columna.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Columna.Name = "txtb_Columna"
        Me.txtb_Columna.Size = New System.Drawing.Size(225, 26)
        Me.txtb_Columna.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(284, 127)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "#Columna"
        '
        'txtb_Pasillo
        '
        Me.txtb_Pasillo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Pasillo.Location = New System.Drawing.Point(288, 95)
        Me.txtb_Pasillo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Pasillo.Name = "txtb_Pasillo"
        Me.txtb_Pasillo.Size = New System.Drawing.Size(225, 26)
        Me.txtb_Pasillo.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(284, 69)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "#Pasillo"
        '
        'txtb_Rack
        '
        Me.txtb_Rack.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Rack.Location = New System.Drawing.Point(21, 153)
        Me.txtb_Rack.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Rack.Name = "txtb_Rack"
        Me.txtb_Rack.Size = New System.Drawing.Size(225, 26)
        Me.txtb_Rack.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 127)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "#Rack"
        '
        'txtb_NumNiveles
        '
        Me.txtb_NumNiveles.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_NumNiveles.Location = New System.Drawing.Point(21, 210)
        Me.txtb_NumNiveles.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_NumNiveles.Name = "txtb_NumNiveles"
        Me.txtb_NumNiveles.Size = New System.Drawing.Size(225, 26)
        Me.txtb_NumNiveles.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(23, 185)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 20)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "#Niveles"
        '
        'btn_eliminar
        '
        Me.btn_eliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_eliminar.Location = New System.Drawing.Point(429, 722)
        Me.btn_eliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(109, 58)
        Me.btn_eliminar.TabIndex = 11
        Me.btn_eliminar.Text = "Eliminar"
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'txtb_Comentarios
        '
        Me.txtb_Comentarios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_Comentarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Comentarios.Location = New System.Drawing.Point(23, 598)
        Me.txtb_Comentarios.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Comentarios.Multiline = True
        Me.txtb_Comentarios.Name = "txtb_Comentarios"
        Me.txtb_Comentarios.Size = New System.Drawing.Size(495, 115)
        Me.txtb_Comentarios.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(23, 573)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Comentarios"
        '
        'txtb_Planta
        '
        Me.txtb_Planta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Planta.Location = New System.Drawing.Point(21, 95)
        Me.txtb_Planta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Planta.Name = "txtb_Planta"
        Me.txtb_Planta.Size = New System.Drawing.Size(225, 26)
        Me.txtb_Planta.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(23, 69)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 20)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "#Planta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(288, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nombre"
        '
        'txtb_Nombre
        '
        Me.txtb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Nombre.Location = New System.Drawing.Point(288, 37)
        Me.txtb_Nombre.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Nombre.Name = "txtb_Nombre"
        Me.txtb_Nombre.Size = New System.Drawing.Size(225, 26)
        Me.txtb_Nombre.TabIndex = 2
        '
        'txtb_CodBarras
        '
        Me.txtb_CodBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_CodBarras.Location = New System.Drawing.Point(288, 210)
        Me.txtb_CodBarras.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_CodBarras.Name = "txtb_CodBarras"
        Me.txtb_CodBarras.Size = New System.Drawing.Size(225, 26)
        Me.txtb_CodBarras.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(284, 185)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 20)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Codigo Barras"
        '
        'txtb_id
        '
        Me.txtb_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_id.Location = New System.Drawing.Point(23, 37)
        Me.txtb_id.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_id.Name = "txtb_id"
        Me.txtb_id.Size = New System.Drawing.Size(225, 26)
        Me.txtb_id.TabIndex = 19
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(21, 11)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 20)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "ID"
        '
        'DGV_Niveles
        '
        Me.DGV_Niveles.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.DGV_Niveles.AllowUserToAddRows = False
        Me.DGV_Niveles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Niveles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nivel, Me.codBarras, Me.Inventario})
        Me.DGV_Niveles.Location = New System.Drawing.Point(11, 243)
        Me.DGV_Niveles.Name = "DGV_Niveles"
        Me.DGV_Niveles.RowHeadersWidth = 51
        Me.DGV_Niveles.RowTemplate.Height = 24
        Me.DGV_Niveles.Size = New System.Drawing.Size(525, 327)
        Me.DGV_Niveles.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(209, 722)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 58)
        Me.Button1.TabIndex = 46
        Me.Button1.Text = "Imprimir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Nivel
        '
        Me.Nivel.HeaderText = "Nivel"
        Me.Nivel.MinimumWidth = 6
        Me.Nivel.Name = "Nivel"
        Me.Nivel.ReadOnly = True
        Me.Nivel.Width = 125
        '
        'codBarras
        '
        Me.codBarras.HeaderText = "Código de Barras"
        Me.codBarras.MinimumWidth = 6
        Me.codBarras.Name = "codBarras"
        Me.codBarras.ReadOnly = True
        Me.codBarras.Width = 125
        '
        'Inventario
        '
        Me.Inventario.HeaderText = "Inventario"
        Me.Inventario.MinimumWidth = 6
        Me.Inventario.Name = "Inventario"
        Me.Inventario.ReadOnly = True
        Me.Inventario.Width = 125
        '
        'WMS_Admin_Ubicaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 788)
        Me.Controls.Add(Me.DGV_Niveles)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtb_id)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtb_CodBarras)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtb_Planta)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtb_Comentarios)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btn_eliminar)
        Me.Controls.Add(Me.txtb_NumNiveles)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtb_Rack)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtb_Pasillo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtb_Columna)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtb_Nombre)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_guardar)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "WMS_Admin_Ubicaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Admin_Ubicaciones"
        CType(Me.DGV_Niveles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_guardar As Button
    Friend WithEvents txtb_Columna As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtb_Pasillo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtb_Rack As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtb_NumNiveles As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btn_eliminar As Button
    Friend WithEvents txtb_Comentarios As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtb_Planta As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtb_Nombre As TextBox
    Friend WithEvents txtb_CodBarras As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtb_id As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents DGV_Niveles As DataGridView
    Friend WithEvents Nivel As DataGridViewTextBoxColumn
    Friend WithEvents codBarras As DataGridViewTextBoxColumn
    Friend WithEvents Inventario As DataGridViewTextBoxColumn
End Class
