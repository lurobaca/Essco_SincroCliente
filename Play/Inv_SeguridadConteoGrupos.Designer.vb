<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inv_SeguridadConteoGrupos
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
        Me.Dgv_Gconteo = New System.Windows.Forms.DataGridView()
        Me.Txb_CodInventario = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.Dgv_Gconteo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Dgv_Gconteo
        '
        Me.Dgv_Gconteo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgv_Gconteo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Gconteo.Location = New System.Drawing.Point(1, 37)
        Me.Dgv_Gconteo.Name = "Dgv_Gconteo"
        Me.Dgv_Gconteo.Size = New System.Drawing.Size(529, 209)
        Me.Dgv_Gconteo.TabIndex = 0
        '
        'Txb_CodInventario
        '
        Me.Txb_CodInventario.Enabled = False
        Me.Txb_CodInventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_CodInventario.Location = New System.Drawing.Point(87, 6)
        Me.Txb_CodInventario.Name = "Txb_CodInventario"
        Me.Txb_CodInventario.Size = New System.Drawing.Size(96, 23)
        Me.Txb_CodInventario.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 17)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Inventario"
        '
        'Inv_SeguridadConteoGrupos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 248)
        Me.Controls.Add(Me.Txb_CodInventario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Dgv_Gconteo)
        Me.Name = "Inv_SeguridadConteoGrupos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SeguridadConteoGrupos"
        CType(Me.Dgv_Gconteo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Dgv_Gconteo As System.Windows.Forms.DataGridView
    Friend WithEvents Txb_CodInventario As TextBox
    Friend WithEvents Label2 As Label
End Class
