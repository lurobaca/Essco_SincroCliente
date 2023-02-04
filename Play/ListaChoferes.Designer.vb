<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaChoferes
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
        Me.dgv_Choferes = New System.Windows.Forms.DataGridView()
        Me.btn_AgregarRep = New System.Windows.Forms.Button()
        CType(Me.dgv_Choferes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_Choferes
        '
        Me.dgv_Choferes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Choferes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Choferes.Location = New System.Drawing.Point(3, 2)
        Me.dgv_Choferes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgv_Choferes.Name = "dgv_Choferes"
        Me.dgv_Choferes.ReadOnly = True
        Me.dgv_Choferes.Size = New System.Drawing.Size(597, 470)
        Me.dgv_Choferes.TabIndex = 1
        Me.dgv_Choferes.VirtualMode = True
        '
        'btn_AgregarRep
        '
        Me.btn_AgregarRep.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_AgregarRep.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AgregarRep.Location = New System.Drawing.Point(188, 478)
        Me.btn_AgregarRep.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_AgregarRep.Name = "btn_AgregarRep"
        Me.btn_AgregarRep.Size = New System.Drawing.Size(195, 55)
        Me.btn_AgregarRep.TabIndex = 7
        Me.btn_AgregarRep.Text = "Agregar"
        Me.btn_AgregarRep.UseVisualStyleBackColor = True
        '
        'ListaChoferes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 535)
        Me.Controls.Add(Me.btn_AgregarRep)
        Me.Controls.Add(Me.dgv_Choferes)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "ListaChoferes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista Choferes"
        Me.TopMost = True
        CType(Me.dgv_Choferes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv_Choferes As System.Windows.Forms.DataGridView
    Friend WithEvents btn_AgregarRep As Button
End Class
