<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CantiChequeada
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtb_Cantidad = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtb_codigo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtb_Descripcion = New System.Windows.Forms.TextBox
        Me.txtb_Faltante = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Cmb_Motivo = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtb_Bodega = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 221)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cantidad"
        '
        'txtb_Cantidad
        '
        Me.txtb_Cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Cantidad.Location = New System.Drawing.Point(152, 221)
        Me.txtb_Cantidad.Name = "txtb_Cantidad"
        Me.txtb_Cantidad.Size = New System.Drawing.Size(149, 41)
        Me.txtb_Cantidad.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Codigo"
        '
        'txtb_codigo
        '
        Me.txtb_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_codigo.Location = New System.Drawing.Point(77, 6)
        Me.txtb_codigo.Name = "txtb_codigo"
        Me.txtb_codigo.ReadOnly = True
        Me.txtb_codigo.Size = New System.Drawing.Size(149, 26)
        Me.txtb_codigo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(172, 36)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Descripcion"
        '
        'txtb_Descripcion
        '
        Me.txtb_Descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Descripcion.Location = New System.Drawing.Point(16, 83)
        Me.txtb_Descripcion.Multiline = True
        Me.txtb_Descripcion.Name = "txtb_Descripcion"
        Me.txtb_Descripcion.ReadOnly = True
        Me.txtb_Descripcion.Size = New System.Drawing.Size(580, 116)
        Me.txtb_Descripcion.TabIndex = 5
        '
        'txtb_Faltante
        '
        Me.txtb_Faltante.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Faltante.Location = New System.Drawing.Point(447, 221)
        Me.txtb_Faltante.Name = "txtb_Faltante"
        Me.txtb_Faltante.Size = New System.Drawing.Size(149, 41)
        Me.txtb_Faltante.TabIndex = 1
        Me.txtb_Faltante.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(307, 221)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 36)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Faltante"
        '
        'Cmb_Motivo
        '
        Me.Cmb_Motivo.Enabled = False
        Me.Cmb_Motivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Motivo.FormattingEnabled = True
        Me.Cmb_Motivo.Items.AddRange(New Object() {"Completo", "M02-Facturado de mas", "M10-Producto Dañado", "M03-Producto Cambiado", "M03-Faltante en Bodega", "M03-No salio de bodega", "M03-Pronto a vencer", "Otros"})
        Me.Cmb_Motivo.Location = New System.Drawing.Point(154, 271)
        Me.Cmb_Motivo.Name = "Cmb_Motivo"
        Me.Cmb_Motivo.Size = New System.Drawing.Size(442, 41)
        Me.Cmb_Motivo.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 271)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 36)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Motivo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(284, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 20)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Bodega"
        '
        'txtb_Bodega
        '
        Me.txtb_Bodega.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Bodega.Location = New System.Drawing.Point(355, 3)
        Me.txtb_Bodega.Name = "txtb_Bodega"
        Me.txtb_Bodega.ReadOnly = True
        Me.txtb_Bodega.Size = New System.Drawing.Size(149, 26)
        Me.txtb_Bodega.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(18, 324)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(128, 40)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(307, 328)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(289, 36)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "F3 Abre Calculadora"
        '
        'CantiChequeada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 376)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Cmb_Motivo)
        Me.Controls.Add(Me.txtb_Faltante)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtb_Descripcion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtb_Bodega)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtb_codigo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtb_Cantidad)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CantiChequeada"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CantiChequeada"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtb_Cantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtb_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtb_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtb_Faltante As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cmb_Motivo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtb_Bodega As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
