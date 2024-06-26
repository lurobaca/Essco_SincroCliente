<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Planilla_DetalleRenta
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
        Me.DGV_DesgloseRenta = New System.Windows.Forms.DataGridView()
        CType(Me.DGV_DesgloseRenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_DesgloseRenta
        '
        Me.DGV_DesgloseRenta.AllowUserToAddRows = False
        Me.DGV_DesgloseRenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_DesgloseRenta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_DesgloseRenta.Location = New System.Drawing.Point(0, 0)
        Me.DGV_DesgloseRenta.Name = "DGV_DesgloseRenta"
        Me.DGV_DesgloseRenta.RowTemplate.Height = 24
        Me.DGV_DesgloseRenta.Size = New System.Drawing.Size(800, 450)
        Me.DGV_DesgloseRenta.TabIndex = 0
        '
        'Planilla_DetalleRenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DGV_DesgloseRenta)
        Me.Name = "Planilla_DetalleRenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planilla_DetalleRenta"
        CType(Me.DGV_DesgloseRenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGV_DesgloseRenta As DataGridView
End Class
