<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reactivacion
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
        Me.TB_clave = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TB_clave
        '
        Me.TB_clave.Location = New System.Drawing.Point(12, 12)
        Me.TB_clave.Name = "TB_clave"
        Me.TB_clave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TB_clave.Size = New System.Drawing.Size(236, 20)
        Me.TB_clave.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(236, 36)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Reactivar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Reactivacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(260, 82)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TB_clave)
        Me.Name = "Reactivacion"
        Me.Text = "Reactivacion"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TB_clave As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
