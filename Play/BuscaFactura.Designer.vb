<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BuscaFactura
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
        Me.txtb_NumFactura = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtb_NumLiq = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_BuscaAgente = New System.Windows.Forms.Button()
        Me.btn_GoToLiq = New System.Windows.Forms.Button()
        Me.btn_GoReporte = New System.Windows.Forms.Button()
        Me.txtb_IdReporte = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtb_NumFactura
        '
        Me.txtb_NumFactura.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_NumFactura.Location = New System.Drawing.Point(107, 7)
        Me.txtb_NumFactura.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtb_NumFactura.Name = "txtb_NumFactura"
        Me.txtb_NumFactura.Size = New System.Drawing.Size(136, 22)
        Me.txtb_NumFactura.TabIndex = 60
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 11)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 17)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Factura"
        '
        'txtb_NumLiq
        '
        Me.txtb_NumLiq.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_NumLiq.Enabled = False
        Me.txtb_NumLiq.Location = New System.Drawing.Point(107, 55)
        Me.txtb_NumLiq.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtb_NumLiq.Name = "txtb_NumLiq"
        Me.txtb_NumLiq.Size = New System.Drawing.Size(136, 22)
        Me.txtb_NumLiq.TabIndex = 63
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 59)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 17)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Liquidacion"
        '
        'btn_BuscaAgente
        '
        Me.btn_BuscaAgente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_BuscaAgente.Image = Global.SincroCliente.My.Resources.Resources.lupa3
        Me.btn_BuscaAgente.Location = New System.Drawing.Point(264, 7)
        Me.btn_BuscaAgente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_BuscaAgente.Name = "btn_BuscaAgente"
        Me.btn_BuscaAgente.Size = New System.Drawing.Size(43, 30)
        Me.btn_BuscaAgente.TabIndex = 61
        Me.btn_BuscaAgente.UseVisualStyleBackColor = True
        '
        'btn_GoToLiq
        '
        Me.btn_GoToLiq.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_GoToLiq.Enabled = False
        Me.btn_GoToLiq.Image = Global.SincroCliente.My.Resources.Resources.ir
        Me.btn_GoToLiq.Location = New System.Drawing.Point(264, 53)
        Me.btn_GoToLiq.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_GoToLiq.Name = "btn_GoToLiq"
        Me.btn_GoToLiq.Size = New System.Drawing.Size(43, 30)
        Me.btn_GoToLiq.TabIndex = 64
        Me.btn_GoToLiq.UseVisualStyleBackColor = True
        '
        'btn_GoReporte
        '
        Me.btn_GoReporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_GoReporte.Enabled = False
        Me.btn_GoReporte.Image = Global.SincroCliente.My.Resources.Resources.ir
        Me.btn_GoReporte.Location = New System.Drawing.Point(264, 85)
        Me.btn_GoReporte.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_GoReporte.Name = "btn_GoReporte"
        Me.btn_GoReporte.Size = New System.Drawing.Size(43, 30)
        Me.btn_GoReporte.TabIndex = 67
        Me.btn_GoReporte.UseVisualStyleBackColor = True
        '
        'txtb_IdReporte
        '
        Me.txtb_IdReporte.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_IdReporte.Enabled = False
        Me.txtb_IdReporte.Location = New System.Drawing.Point(107, 87)
        Me.txtb_IdReporte.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtb_IdReporte.Name = "txtb_IdReporte"
        Me.txtb_IdReporte.Size = New System.Drawing.Size(136, 22)
        Me.txtb_IdReporte.TabIndex = 66
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 91)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 17)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Reporte"
        '
        'BuscaFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 116)
        Me.Controls.Add(Me.btn_GoReporte)
        Me.Controls.Add(Me.txtb_IdReporte)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_GoToLiq)
        Me.Controls.Add(Me.txtb_NumLiq)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_BuscaAgente)
        Me.Controls.Add(Me.txtb_NumFactura)
        Me.Controls.Add(Me.Label4)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(338, 163)
        Me.MinimumSize = New System.Drawing.Size(338, 163)
        Me.Name = "BuscaFactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BuscaFactura"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_BuscaAgente As System.Windows.Forms.Button
    Friend WithEvents txtb_NumFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtb_NumLiq As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_GoToLiq As System.Windows.Forms.Button
    Friend WithEvents btn_GoReporte As System.Windows.Forms.Button
    Friend WithEvents txtb_IdReporte As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
