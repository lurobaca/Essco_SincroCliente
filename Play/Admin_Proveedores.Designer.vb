<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Proveedores
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
        Me.btn_BuscaAgente = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtb_NombreProveedor = New System.Windows.Forms.TextBox
        Me.txtb_CodProveedor = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtb_DiasEspera = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btn_BuscaAgente
        '
        ' Me.btn_BuscaAgente.Image = Global.SincroCliente.My.Resources.Resources.lupa3
        Me.btn_BuscaAgente.Location = New System.Drawing.Point(223, 6)
        Me.btn_BuscaAgente.Name = "btn_BuscaAgente"
        Me.btn_BuscaAgente.Size = New System.Drawing.Size(32, 24)
        Me.btn_BuscaAgente.TabIndex = 63
        Me.btn_BuscaAgente.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(263, 9)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(96, 13)
        Me.Label19.TabIndex = 62
        Me.Label19.Text = "Nombre Proveedor"
        '
        'txtb_NombreProveedor
        '
        Me.txtb_NombreProveedor.BackColor = System.Drawing.Color.White
        Me.txtb_NombreProveedor.Location = New System.Drawing.Point(365, 6)
        Me.txtb_NombreProveedor.Name = "txtb_NombreProveedor"
        Me.txtb_NombreProveedor.ReadOnly = True
        Me.txtb_NombreProveedor.Size = New System.Drawing.Size(276, 20)
        Me.txtb_NombreProveedor.TabIndex = 61
        '
        'txtb_CodProveedor
        '
        Me.txtb_CodProveedor.BackColor = System.Drawing.Color.White
        Me.txtb_CodProveedor.Location = New System.Drawing.Point(114, 6)
        Me.txtb_CodProveedor.Name = "txtb_CodProveedor"
        Me.txtb_CodProveedor.ReadOnly = True
        Me.txtb_CodProveedor.Size = New System.Drawing.Size(100, 20)
        Me.txtb_CodProveedor.TabIndex = 60
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Cod Proveedor"
        '
        'txtb_DiasEspera
        '
        Me.txtb_DiasEspera.BackColor = System.Drawing.Color.White
        Me.txtb_DiasEspera.Location = New System.Drawing.Point(114, 41)
        Me.txtb_DiasEspera.Name = "txtb_DiasEspera"
        Me.txtb_DiasEspera.ReadOnly = True
        Me.txtb_DiasEspera.Size = New System.Drawing.Size(100, 20)
        Me.txtb_DiasEspera.TabIndex = 65
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "Dias de espera"
        '
        'Admin_Proveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 289)
        Me.Controls.Add(Me.txtb_DiasEspera)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_BuscaAgente)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtb_NombreProveedor)
        Me.Controls.Add(Me.txtb_CodProveedor)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Admin_Proveedores"
        Me.Text = "Admin_Proveedores"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_BuscaAgente As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtb_NombreProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtb_CodProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtb_DiasEspera As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
