<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Rutas
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.txtb_Ruta = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.btn_AgNuevo = New System.Windows.Forms.Button
        Me.btn_AgElimina = New System.Windows.Forms.Button
        Me.btn_AgGuardar = New System.Windows.Forms.Button
        Me.btn_AgModif = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(15, 34)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 1
        '
        'txtb_Ruta
        '
        Me.txtb_Ruta.Location = New System.Drawing.Point(15, 91)
        Me.txtb_Ruta.Name = "txtb_Ruta"
        Me.txtb_Ruta.Size = New System.Drawing.Size(359, 20)
        Me.txtb_Ruta.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripcion"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 167)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(362, 302)
        Me.DataGridView1.TabIndex = 4
        '
        'btn_AgNuevo
        '
        Me.btn_AgNuevo.Location = New System.Drawing.Point(28, 123)
        Me.btn_AgNuevo.Name = "btn_AgNuevo"
        Me.btn_AgNuevo.Size = New System.Drawing.Size(75, 38)
        Me.btn_AgNuevo.TabIndex = 15
        Me.btn_AgNuevo.Text = "Nuevo"
        Me.btn_AgNuevo.UseVisualStyleBackColor = True
        '
        'btn_AgElimina
        '
        Me.btn_AgElimina.Enabled = False
        Me.btn_AgElimina.Location = New System.Drawing.Point(271, 123)
        Me.btn_AgElimina.Name = "btn_AgElimina"
        Me.btn_AgElimina.Size = New System.Drawing.Size(75, 38)
        Me.btn_AgElimina.TabIndex = 14
        Me.btn_AgElimina.Text = "Eliminar"
        Me.btn_AgElimina.UseVisualStyleBackColor = True
        '
        'btn_AgGuardar
        '
        Me.btn_AgGuardar.Location = New System.Drawing.Point(109, 123)
        Me.btn_AgGuardar.Name = "btn_AgGuardar"
        Me.btn_AgGuardar.Size = New System.Drawing.Size(75, 38)
        Me.btn_AgGuardar.TabIndex = 12
        Me.btn_AgGuardar.Text = "Guardar"
        Me.btn_AgGuardar.UseVisualStyleBackColor = True
        '
        'btn_AgModif
        '
        Me.btn_AgModif.Enabled = False
        Me.btn_AgModif.Location = New System.Drawing.Point(190, 123)
        Me.btn_AgModif.Name = "btn_AgModif"
        Me.btn_AgModif.Size = New System.Drawing.Size(75, 38)
        Me.btn_AgModif.TabIndex = 13
        Me.btn_AgModif.Text = "Modificar"
        Me.btn_AgModif.UseVisualStyleBackColor = True
        '
        'Admin_Rutas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 481)
        Me.Controls.Add(Me.btn_AgNuevo)
        Me.Controls.Add(Me.btn_AgElimina)
        Me.Controls.Add(Me.btn_AgGuardar)
        Me.Controls.Add(Me.btn_AgModif)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtb_Ruta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(404, 519)
        Me.MinimumSize = New System.Drawing.Size(404, 519)
        Me.Name = "Admin_Rutas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Admin_Rutas"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtb_Ruta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btn_AgNuevo As System.Windows.Forms.Button
    Friend WithEvents btn_AgElimina As System.Windows.Forms.Button
    Friend WithEvents btn_AgGuardar As System.Windows.Forms.Button
    Friend WithEvents btn_AgModif As System.Windows.Forms.Button
End Class
