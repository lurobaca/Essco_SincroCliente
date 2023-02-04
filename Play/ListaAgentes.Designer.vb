<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaAgentes
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
        Me.dgv_Agentes = New System.Windows.Forms.DataGridView()
        Me.btn_AgregarRep = New System.Windows.Forms.Button()
        CType(Me.dgv_Agentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_Agentes
        '
        Me.dgv_Agentes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Agentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Agentes.Location = New System.Drawing.Point(0, 0)
        Me.dgv_Agentes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgv_Agentes.Name = "dgv_Agentes"
        Me.dgv_Agentes.ReadOnly = True
        Me.dgv_Agentes.Size = New System.Drawing.Size(612, 383)
        Me.dgv_Agentes.TabIndex = 1
        Me.dgv_Agentes.VirtualMode = True
        '
        'btn_AgregarRep
        '
        Me.btn_AgregarRep.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_AgregarRep.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AgregarRep.Location = New System.Drawing.Point(200, 389)
        Me.btn_AgregarRep.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_AgregarRep.Name = "btn_AgregarRep"
        Me.btn_AgregarRep.Size = New System.Drawing.Size(205, 55)
        Me.btn_AgregarRep.TabIndex = 8
        Me.btn_AgregarRep.Text = "Agregar"
        Me.btn_AgregarRep.UseVisualStyleBackColor = True
        '
        'ListaAgentes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 459)
        Me.Controls.Add(Me.btn_AgregarRep)
        Me.Controls.Add(Me.dgv_Agentes)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "ListaAgentes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista Agentes"
        Me.TopMost = True
        CType(Me.dgv_Agentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv_Agentes As System.Windows.Forms.DataGridView
    Friend WithEvents btn_AgregarRep As Button
End Class
