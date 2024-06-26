<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Planilla_DetalleDeducciones
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
        Me.DGV_ListaDeducciones = New System.Windows.Forms.DataGridView()
        CType(Me.DGV_ListaDeducciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_ListaDeducciones
        '
        Me.DGV_ListaDeducciones.AllowUserToAddRows = False
        Me.DGV_ListaDeducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ListaDeducciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_ListaDeducciones.Location = New System.Drawing.Point(0, 0)
        Me.DGV_ListaDeducciones.Margin = New System.Windows.Forms.Padding(4)
        Me.DGV_ListaDeducciones.Name = "DGV_ListaDeducciones"
        Me.DGV_ListaDeducciones.Size = New System.Drawing.Size(800, 450)
        Me.DGV_ListaDeducciones.TabIndex = 14
        '
        'Planilla_DetalleDeducciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DGV_ListaDeducciones)
        Me.Name = "Planilla_DetalleDeducciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planilla_DetalleDeducciones"
        CType(Me.DGV_ListaDeducciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGV_ListaDeducciones As DataGridView
End Class
