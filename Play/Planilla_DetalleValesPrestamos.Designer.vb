<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Planilla_DetalleValesPrestamos
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
        Me.DGV_ListaValesPrestamos = New System.Windows.Forms.DataGridView()
        CType(Me.DGV_ListaValesPrestamos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_ListaValesPrestamos
        '
        Me.DGV_ListaValesPrestamos.AllowUserToAddRows = False
        Me.DGV_ListaValesPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ListaValesPrestamos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_ListaValesPrestamos.Location = New System.Drawing.Point(0, 0)
        Me.DGV_ListaValesPrestamos.Margin = New System.Windows.Forms.Padding(4)
        Me.DGV_ListaValesPrestamos.Name = "DGV_ListaValesPrestamos"
        Me.DGV_ListaValesPrestamos.Size = New System.Drawing.Size(800, 450)
        Me.DGV_ListaValesPrestamos.TabIndex = 13
        '
        'Planilla_DetalleValesPrestamos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DGV_ListaValesPrestamos)
        Me.Name = "Planilla_DetalleValesPrestamos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planilla_DetalleValesPrestamos"
        CType(Me.DGV_ListaValesPrestamos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGV_ListaValesPrestamos As DataGridView
End Class
