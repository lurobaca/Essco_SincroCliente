<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddRecibo
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
        Me.txtb_NumRecibo = New System.Windows.Forms.TextBox
        Me.btn_Agregar = New System.Windows.Forms.Button
        Me.btn_Quitar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(123, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "# Recibo"
        '
        'txtb_NumRecibo
        '
        Me.txtb_NumRecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_NumRecibo.Location = New System.Drawing.Point(12, 27)
        Me.txtb_NumRecibo.Name = "txtb_NumRecibo"
        Me.txtb_NumRecibo.Size = New System.Drawing.Size(292, 27)
        Me.txtb_NumRecibo.TabIndex = 1
        '
        'btn_Agregar
        '
        Me.btn_Agregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Agregar.Location = New System.Drawing.Point(12, 60)
        Me.btn_Agregar.Name = "btn_Agregar"
        Me.btn_Agregar.Size = New System.Drawing.Size(140, 41)
        Me.btn_Agregar.TabIndex = 2
        Me.btn_Agregar.Text = "AGREGAR"
        Me.btn_Agregar.UseVisualStyleBackColor = True
        '
        'btn_Quitar
        '
        Me.btn_Quitar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Quitar.Location = New System.Drawing.Point(164, 60)
        Me.btn_Quitar.Name = "btn_Quitar"
        Me.btn_Quitar.Size = New System.Drawing.Size(140, 41)
        Me.btn_Quitar.TabIndex = 3
        Me.btn_Quitar.Text = "QUITAR"
        Me.btn_Quitar.UseVisualStyleBackColor = True
        '
        'AddRecibo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(316, 111)
        Me.Controls.Add(Me.btn_Quitar)
        Me.Controls.Add(Me.btn_Agregar)
        Me.Controls.Add(Me.txtb_NumRecibo)
        Me.Controls.Add(Me.Label1)
        Me.Name = "AddRecibo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AddRecibo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtb_NumRecibo As System.Windows.Forms.TextBox
    Friend WithEvents btn_Agregar As System.Windows.Forms.Button
    Friend WithEvents btn_Quitar As System.Windows.Forms.Button
End Class
