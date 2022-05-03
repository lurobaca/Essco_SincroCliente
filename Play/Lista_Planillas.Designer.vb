<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Lista_Planillas
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
        Me.DGV_ListaPlanillas = New System.Windows.Forms.DataGridView
        CType(Me.DGV_ListaPlanillas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_ListaPlanillas
        '
        Me.DGV_ListaPlanillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ListaPlanillas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_ListaPlanillas.Location = New System.Drawing.Point(0, 0)
        Me.DGV_ListaPlanillas.Name = "DGV_ListaPlanillas"
        Me.DGV_ListaPlanillas.Size = New System.Drawing.Size(514, 404)
        Me.DGV_ListaPlanillas.TabIndex = 0
        '
        'Lista_Planillas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 404)
        Me.Controls.Add(Me.DGV_ListaPlanillas)
        Me.Name = "Lista_Planillas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista_Planillas"
        CType(Me.DGV_ListaPlanillas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGV_ListaPlanillas As System.Windows.Forms.DataGridView
End Class
