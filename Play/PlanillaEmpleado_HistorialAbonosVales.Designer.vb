<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlanillaEmpleado_HistorialAbonosVales
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
        Me.DGV_HistorialAbonos = New System.Windows.Forms.DataGridView()
        CType(Me.DGV_HistorialAbonos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_HistorialAbonos
        '
        Me.DGV_HistorialAbonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_HistorialAbonos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_HistorialAbonos.Location = New System.Drawing.Point(0, 0)
        Me.DGV_HistorialAbonos.Name = "DGV_HistorialAbonos"
        Me.DGV_HistorialAbonos.RowTemplate.Height = 24
        Me.DGV_HistorialAbonos.Size = New System.Drawing.Size(800, 450)
        Me.DGV_HistorialAbonos.TabIndex = 0
        '
        'PlanillaEmpleado_HistorialAbonosVales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DGV_HistorialAbonos)
        Me.Name = "PlanillaEmpleado_HistorialAbonosVales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PlanillaEmpleado_HistorialAbonosVales"
        CType(Me.DGV_HistorialAbonos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGV_HistorialAbonos As DataGridView
End Class
