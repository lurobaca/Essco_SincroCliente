<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_CuotasVendedores
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
        Me.DGV_ResultadoCuotas = New System.Windows.Forms.DataGridView()
        Me.Aceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DGV_ResultadoCuotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_ResultadoCuotas
        '
        Me.DGV_ResultadoCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ResultadoCuotas.Location = New System.Drawing.Point(12, 197)
        Me.DGV_ResultadoCuotas.Name = "DGV_ResultadoCuotas"
        Me.DGV_ResultadoCuotas.RowTemplate.Height = 24
        Me.DGV_ResultadoCuotas.Size = New System.Drawing.Size(776, 241)
        Me.DGV_ResultadoCuotas.TabIndex = 0
        '
        'Aceptar
        '
        Me.Aceptar.Location = New System.Drawing.Point(713, 168)
        Me.Aceptar.Name = "Aceptar"
        Me.Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Aceptar.TabIndex = 1
        Me.Aceptar.Text = "Button1"
        Me.Aceptar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(382, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Label1"
        '
        'Admin_CuotasVendedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Aceptar)
        Me.Controls.Add(Me.DGV_ResultadoCuotas)
        Me.Name = "Admin_CuotasVendedores"
        Me.Text = "Admin_CuotasVendedores"
        CType(Me.DGV_ResultadoCuotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGV_ResultadoCuotas As DataGridView
    Friend WithEvents Aceptar As Button
    Friend WithEvents Label1 As Label
End Class
