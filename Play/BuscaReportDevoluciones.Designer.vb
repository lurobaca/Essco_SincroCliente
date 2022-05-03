<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BuscaReportDevoluciones
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
        Me.DGV_ReportesDevoluciones = New System.Windows.Forms.DataGridView
        CType(Me.DGV_ReportesDevoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_ReportesDevoluciones
        '
        Me.DGV_ReportesDevoluciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ReportesDevoluciones.Location = New System.Drawing.Point(2, 12)
        Me.DGV_ReportesDevoluciones.Name = "DGV_ReportesDevoluciones"
        Me.DGV_ReportesDevoluciones.Size = New System.Drawing.Size(584, 322)
        Me.DGV_ReportesDevoluciones.TabIndex = 0
        '
        'BuscaReportDevoluciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 337)
        Me.Controls.Add(Me.DGV_ReportesDevoluciones)
        Me.Name = "BuscaReportDevoluciones"
        Me.Text = "BuscaReportDevoluciones"
        CType(Me.DGV_ReportesDevoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGV_ReportesDevoluciones As System.Windows.Forms.DataGridView
End Class
