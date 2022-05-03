<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WMS_LineaNueva
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
        Me.DGV_LineasNuevas = New System.Windows.Forms.DataGridView()
        CType(Me.DGV_LineasNuevas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_LineasNuevas
        '
        Me.DGV_LineasNuevas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_LineasNuevas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_LineasNuevas.Location = New System.Drawing.Point(0, 0)
        Me.DGV_LineasNuevas.Name = "DGV_LineasNuevas"
        Me.DGV_LineasNuevas.RowTemplate.Height = 24
        Me.DGV_LineasNuevas.Size = New System.Drawing.Size(1216, 651)
        Me.DGV_LineasNuevas.TabIndex = 0
        '
        'WMS_LineaNueva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1216, 651)
        Me.Controls.Add(Me.DGV_LineasNuevas)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "WMS_LineaNueva"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WMS_LineaNueva"
        CType(Me.DGV_LineasNuevas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGV_LineasNuevas As DataGridView
End Class
