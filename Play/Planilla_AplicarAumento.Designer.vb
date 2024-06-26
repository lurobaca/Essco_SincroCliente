<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Planilla_AplicarAumento
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Lbl_Inicio = New System.Windows.Forms.Label()
        Me.Lbl_Fin = New System.Windows.Forms.Label()
        Me.Lbl_Empleado = New System.Windows.Forms.Label()
        Me.txtb_Aumento = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtBox_MotivoAumento = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 17)
        Me.Label1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(337, 262)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 57)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "ACEPTAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 20)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 24)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Usuario"
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameTextBox.Location = New System.Drawing.Point(21, 49)
        Me.UsernameTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(272, 28)
        Me.UsernameTextBox.TabIndex = 0
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordTextBox.Location = New System.Drawing.Point(301, 49)
        Me.PasswordTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(320, 28)
        Me.PasswordTextBox.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(297, 20)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 24)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Clave"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(481, 262)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(136, 57)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "CANCELAR"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(21, 221)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(596, 28)
        Me.ProgressBar1.TabIndex = 9
        '
        'Lbl_Inicio
        '
        Me.Lbl_Inicio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Inicio.AutoSize = True
        Me.Lbl_Inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Inicio.Location = New System.Drawing.Point(17, 193)
        Me.Lbl_Inicio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Inicio.Name = "Lbl_Inicio"
        Me.Lbl_Inicio.Size = New System.Drawing.Size(54, 24)
        Me.Lbl_Inicio.TabIndex = 10
        Me.Lbl_Inicio.Text = "Inicio"
        '
        'Lbl_Fin
        '
        Me.Lbl_Fin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Fin.AutoSize = True
        Me.Lbl_Fin.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Fin.Location = New System.Drawing.Point(566, 193)
        Me.Lbl_Fin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Fin.Name = "Lbl_Fin"
        Me.Lbl_Fin.Size = New System.Drawing.Size(51, 24)
        Me.Lbl_Fin.TabIndex = 11
        Me.Lbl_Fin.Text = "Total"
        '
        'Lbl_Empleado
        '
        Me.Lbl_Empleado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Empleado.AutoSize = True
        Me.Lbl_Empleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Empleado.Location = New System.Drawing.Point(93, 193)
        Me.Lbl_Empleado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Empleado.Name = "Lbl_Empleado"
        Me.Lbl_Empleado.Size = New System.Drawing.Size(465, 24)
        Me.Lbl_Empleado.TabIndex = 12
        Me.Lbl_Empleado.Text = ".......................Nombre del empleado.............................."
        '
        'txtb_Aumento
        '
        Me.txtb_Aumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Aumento.Location = New System.Drawing.Point(21, 144)
        Me.txtb_Aumento.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Aumento.Name = "txtb_Aumento"
        Me.txtb_Aumento.Size = New System.Drawing.Size(272, 28)
        Me.txtb_Aumento.TabIndex = 13
        Me.txtb_Aumento.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 116)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 24)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "%Aumento"
        '
        'TxtBox_MotivoAumento
        '
        Me.TxtBox_MotivoAumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBox_MotivoAumento.Location = New System.Drawing.Point(301, 144)
        Me.TxtBox_MotivoAumento.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtBox_MotivoAumento.Name = "TxtBox_MotivoAumento"
        Me.TxtBox_MotivoAumento.Size = New System.Drawing.Size(320, 28)
        Me.TxtBox_MotivoAumento.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(297, 106)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(175, 24)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Motivo del aumento"
        '
        'Planilla_AplicarAumento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 328)
        Me.Controls.Add(Me.TxtBox_MotivoAumento)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtb_Aumento)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Lbl_Empleado)
        Me.Controls.Add(Me.Lbl_Fin)
        Me.Controls.Add(Me.Lbl_Inicio)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.UsernameTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Planilla_AplicarAumento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AplicarAumento"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Lbl_Inicio As System.Windows.Forms.Label
    Friend WithEvents Lbl_Fin As System.Windows.Forms.Label
    Friend WithEvents Lbl_Empleado As System.Windows.Forms.Label
    Friend WithEvents txtb_Aumento As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtBox_MotivoAumento As TextBox
    Friend WithEvents Label5 As Label
End Class
