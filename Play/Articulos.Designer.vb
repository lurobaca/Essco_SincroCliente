<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Articulos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Dgv_Articulos = New System.Windows.Forms.DataGridView()
        Me.txtb_Buscar = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cbox_VerDesc = New System.Windows.Forms.CheckBox()
        CType(Me.Dgv_Articulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Dgv_Articulos
        '
        Me.Dgv_Articulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgv_Articulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Articulos.Location = New System.Drawing.Point(3, 65)
        Me.Dgv_Articulos.Margin = New System.Windows.Forms.Padding(4)
        Me.Dgv_Articulos.Name = "Dgv_Articulos"
        Me.Dgv_Articulos.Size = New System.Drawing.Size(955, 473)
        Me.Dgv_Articulos.TabIndex = 0
        '
        'txtb_Buscar
        '
        Me.txtb_Buscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_Buscar.Location = New System.Drawing.Point(95, 12)
        Me.txtb_Buscar.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Buscar.Name = "txtb_Buscar"
        Me.txtb_Buscar.Size = New System.Drawing.Size(456, 22)
        Me.txtb_Buscar.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Buscar"
        '
        'Cbox_VerDesc
        '
        Me.Cbox_VerDesc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cbox_VerDesc.AutoSize = True
        Me.Cbox_VerDesc.Location = New System.Drawing.Point(799, 11)
        Me.Cbox_VerDesc.Margin = New System.Windows.Forms.Padding(4)
        Me.Cbox_VerDesc.Name = "Cbox_VerDesc"
        Me.Cbox_VerDesc.Size = New System.Drawing.Size(158, 21)
        Me.Cbox_VerDesc.TabIndex = 3
        Me.Cbox_VerDesc.Text = "Ver Descontinuados"
        Me.Cbox_VerDesc.UseVisualStyleBackColor = True
        '
        'Articulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 540)
        Me.Controls.Add(Me.Cbox_VerDesc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtb_Buscar)
        Me.Controls.Add(Me.Dgv_Articulos)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Articulos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Articulos"
        CType(Me.Dgv_Articulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Dgv_Articulos As System.Windows.Forms.DataGridView
    Friend WithEvents txtb_Buscar As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cbox_VerDesc As System.Windows.Forms.CheckBox
End Class
