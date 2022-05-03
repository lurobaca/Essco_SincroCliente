<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class buscaBodeguero
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
        Me.dgv_bodegueros = New System.Windows.Forms.DataGridView
        CType(Me.dgv_bodegueros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_bodegueros
        '
        Me.dgv_bodegueros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_bodegueros.Location = New System.Drawing.Point(12, 12)
        Me.dgv_bodegueros.Name = "dgv_bodegueros"
        Me.dgv_bodegueros.ReadOnly = True
        Me.dgv_bodegueros.Size = New System.Drawing.Size(438, 262)
        Me.dgv_bodegueros.TabIndex = 0
        '
        'buscaBodeguero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 286)
        Me.Controls.Add(Me.dgv_bodegueros)
        Me.Name = "buscaBodeguero"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "buscaBodeguero"
        CType(Me.dgv_bodegueros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv_bodegueros As System.Windows.Forms.DataGridView
End Class
