<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Planilla_DetalleFaltantesLiquidacion
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
        Me.DGV_ListaLiquidaciones = New System.Windows.Forms.DataGridView()
        CType(Me.DGV_ListaLiquidaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_ListaLiquidaciones
        '
        Me.DGV_ListaLiquidaciones.AllowUserToAddRows = False
        Me.DGV_ListaLiquidaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ListaLiquidaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_ListaLiquidaciones.Location = New System.Drawing.Point(0, 0)
        Me.DGV_ListaLiquidaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.DGV_ListaLiquidaciones.Name = "DGV_ListaLiquidaciones"
        Me.DGV_ListaLiquidaciones.Size = New System.Drawing.Size(800, 450)
        Me.DGV_ListaLiquidaciones.TabIndex = 11
        '
        'Planilla_DetalleFaltantesLiquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DGV_ListaLiquidaciones)
        Me.Name = "Planilla_DetalleFaltantesLiquidacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planilla_DetalleFaltantesLiquidacion"
        CType(Me.DGV_ListaLiquidaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGV_ListaLiquidaciones As DataGridView
End Class
