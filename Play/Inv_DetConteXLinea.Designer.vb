<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inv_DetConteXLinea
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtb_Codigo = New System.Windows.Forms.TextBox()
        Me.txtb_Descripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtb_Stock = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtb_CF = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtb_Dif = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtb_MontoDif = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(2, 55)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(788, 205)
        Me.DataGridView1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Codigo"
        '
        'txtb_Codigo
        '
        Me.txtb_Codigo.Location = New System.Drawing.Point(15, 29)
        Me.txtb_Codigo.Name = "txtb_Codigo"
        Me.txtb_Codigo.Size = New System.Drawing.Size(100, 20)
        Me.txtb_Codigo.TabIndex = 2
        '
        'txtb_Descripcion
        '
        Me.txtb_Descripcion.Location = New System.Drawing.Point(121, 29)
        Me.txtb_Descripcion.Name = "txtb_Descripcion"
        Me.txtb_Descripcion.Size = New System.Drawing.Size(283, 20)
        Me.txtb_Descripcion.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(118, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Descripcion"
        '
        'txtb_Stock
        '
        Me.txtb_Stock.Location = New System.Drawing.Point(410, 29)
        Me.txtb_Stock.Name = "txtb_Stock"
        Me.txtb_Stock.Size = New System.Drawing.Size(75, 20)
        Me.txtb_Stock.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(429, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Stock"
        '
        'txtb_CF
        '
        Me.txtb_CF.Location = New System.Drawing.Point(515, 29)
        Me.txtb_CF.Name = "txtb_CF"
        Me.txtb_CF.Size = New System.Drawing.Size(75, 20)
        Me.txtb_CF.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(534, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "CF"
        '
        'txtb_Dif
        '
        Me.txtb_Dif.Location = New System.Drawing.Point(596, 29)
        Me.txtb_Dif.Name = "txtb_Dif"
        Me.txtb_Dif.Size = New System.Drawing.Size(75, 20)
        Me.txtb_Dif.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(615, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "DIF"
        '
        'txtb_MontoDif
        '
        Me.txtb_MontoDif.Location = New System.Drawing.Point(677, 29)
        Me.txtb_MontoDif.Name = "txtb_MontoDif"
        Me.txtb_MontoDif.Size = New System.Drawing.Size(113, 20)
        Me.txtb_MontoDif.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(696, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "MONTO DIF"
        '
        'Inv_DetConteXLinea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 261)
        Me.Controls.Add(Me.txtb_MontoDif)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtb_Dif)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtb_CF)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtb_Stock)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtb_Descripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtb_Codigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Inv_DetConteXLinea"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DetConteXLinea"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtb_Codigo As System.Windows.Forms.TextBox
    Friend WithEvents txtb_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtb_Stock As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtb_CF As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtb_Dif As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtb_MontoDif As TextBox
    Friend WithEvents Label6 As Label
End Class
