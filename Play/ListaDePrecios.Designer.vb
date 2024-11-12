<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaDePrecios
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
        Me.Btn_Guardar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txtb_Nombre = New System.Windows.Forms.TextBox()
        Me.Txtb_IdListaPrecio = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DGV_ListaDePrecios = New System.Windows.Forms.DataGridView()
        Me.btn_Inactivar = New System.Windows.Forms.Button()
        Me.Txtb_Estado = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Lbl_Inactivar = New System.Windows.Forms.Label()
        CType(Me.DGV_ListaDePrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_Guardar
        '
        Me.Btn_Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Guardar.Location = New System.Drawing.Point(734, 549)
        Me.Btn_Guardar.Name = "Btn_Guardar"
        Me.Btn_Guardar.Size = New System.Drawing.Size(95, 33)
        Me.Btn_Guardar.TabIndex = 0
        Me.Btn_Guardar.Text = "Guardar"
        Me.Btn_Guardar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nombre"
        '
        'Txtb_Nombre
        '
        Me.Txtb_Nombre.Location = New System.Drawing.Point(90, 12)
        Me.Txtb_Nombre.Name = "Txtb_Nombre"
        Me.Txtb_Nombre.Size = New System.Drawing.Size(268, 22)
        Me.Txtb_Nombre.TabIndex = 2
        '
        'Txtb_IdListaPrecio
        '
        Me.Txtb_IdListaPrecio.Location = New System.Drawing.Point(545, 16)
        Me.Txtb_IdListaPrecio.Name = "Txtb_IdListaPrecio"
        Me.Txtb_IdListaPrecio.Size = New System.Drawing.Size(72, 22)
        Me.Txtb_IdListaPrecio.TabIndex = 4
        Me.Txtb_IdListaPrecio.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(518, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "ID"
        Me.Label2.Visible = False
        '
        'DGV_ListaDePrecios
        '
        Me.DGV_ListaDePrecios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_ListaDePrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ListaDePrecios.Location = New System.Drawing.Point(15, 60)
        Me.DGV_ListaDePrecios.Name = "DGV_ListaDePrecios"
        Me.DGV_ListaDePrecios.RowTemplate.Height = 24
        Me.DGV_ListaDePrecios.Size = New System.Drawing.Size(915, 483)
        Me.DGV_ListaDePrecios.TabIndex = 5
        '
        'btn_Inactivar
        '
        Me.btn_Inactivar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Inactivar.Location = New System.Drawing.Point(835, 549)
        Me.btn_Inactivar.Name = "btn_Inactivar"
        Me.btn_Inactivar.Size = New System.Drawing.Size(95, 33)
        Me.btn_Inactivar.TabIndex = 6
        Me.btn_Inactivar.Text = "Inactivar"
        Me.btn_Inactivar.UseVisualStyleBackColor = True
        '
        'Txtb_Estado
        '
        Me.Txtb_Estado.Location = New System.Drawing.Point(681, 16)
        Me.Txtb_Estado.Name = "Txtb_Estado"
        Me.Txtb_Estado.Size = New System.Drawing.Size(61, 22)
        Me.Txtb_Estado.TabIndex = 8
        Me.Txtb_Estado.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(623, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Estado"
        Me.Label3.Visible = False
        '
        'Lbl_Inactivar
        '
        Me.Lbl_Inactivar.AutoSize = True
        Me.Lbl_Inactivar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Inactivar.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Inactivar.Location = New System.Drawing.Point(379, 12)
        Me.Lbl_Inactivar.Name = "Lbl_Inactivar"
        Me.Lbl_Inactivar.Size = New System.Drawing.Size(116, 25)
        Me.Lbl_Inactivar.TabIndex = 9
        Me.Lbl_Inactivar.Text = "INACTIVO"
        Me.Lbl_Inactivar.Visible = False
        '
        'ListaDePrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 594)
        Me.Controls.Add(Me.Lbl_Inactivar)
        Me.Controls.Add(Me.Txtb_Estado)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_Inactivar)
        Me.Controls.Add(Me.DGV_ListaDePrecios)
        Me.Controls.Add(Me.Txtb_IdListaPrecio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txtb_Nombre)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_Guardar)
        Me.Name = "ListaDePrecios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ListaDePrecios"
        CType(Me.DGV_ListaDePrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_Guardar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Txtb_Nombre As TextBox
    Friend WithEvents Txtb_IdListaPrecio As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DGV_ListaDePrecios As DataGridView
    Friend WithEvents btn_Inactivar As Button
    Friend WithEvents Txtb_Estado As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Lbl_Inactivar As Label
End Class
