<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Planilla_DetalleFacturas
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
        Me.DGV_ListaFacturas = New System.Windows.Forms.DataGridView()
        CType(Me.DGV_ListaFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_ListaFacturas
        '
        Me.DGV_ListaFacturas.AllowUserToAddRows = False
        Me.DGV_ListaFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ListaFacturas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_ListaFacturas.Location = New System.Drawing.Point(0, 0)
        Me.DGV_ListaFacturas.Margin = New System.Windows.Forms.Padding(4)
        Me.DGV_ListaFacturas.Name = "DGV_ListaFacturas"
        Me.DGV_ListaFacturas.Size = New System.Drawing.Size(800, 450)
        Me.DGV_ListaFacturas.TabIndex = 12
        '
        'Planilla_DetalleFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DGV_ListaFacturas)
        Me.Name = "Planilla_DetalleFacturas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planilla_DetalleFacturas"
        CType(Me.DGV_ListaFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGV_ListaFacturas As DataGridView
End Class
