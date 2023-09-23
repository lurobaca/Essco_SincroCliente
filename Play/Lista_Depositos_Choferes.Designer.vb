<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Lista_Depositos_Choferes
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
        Me.dgv_Liquidaciones = New System.Windows.Forms.DataGridView()
        Me.DTP_Desde = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTP_Hasta = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txb_NumDepo = New System.Windows.Forms.TextBox()
        Me.Txb_Consecutivo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_BuscaAgente = New System.Windows.Forms.Button()
        Me.txtb_CodAgente = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.chbx_VerAnulado = New System.Windows.Forms.CheckBox()
        Me.txtb_NumLiq = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtb_Monto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.dgv_Liquidaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_Liquidaciones
        '
        Me.dgv_Liquidaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_Liquidaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Liquidaciones.Location = New System.Drawing.Point(4, 116)
        Me.dgv_Liquidaciones.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgv_Liquidaciones.Name = "dgv_Liquidaciones"
        Me.dgv_Liquidaciones.ReadOnly = True
        Me.dgv_Liquidaciones.Size = New System.Drawing.Size(1425, 427)
        Me.dgv_Liquidaciones.TabIndex = 1
        '
        'DTP_Desde
        '
        Me.DTP_Desde.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_Desde.Location = New System.Drawing.Point(8, 36)
        Me.DTP_Desde.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DTP_Desde.Name = "DTP_Desde"
        Me.DTP_Desde.Size = New System.Drawing.Size(332, 22)
        Me.DTP_Desde.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(359, 11)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Hasta"
        '
        'DTP_Hasta
        '
        Me.DTP_Hasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_Hasta.Location = New System.Drawing.Point(363, 36)
        Me.DTP_Hasta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DTP_Hasta.Name = "DTP_Hasta"
        Me.DTP_Hasta.Size = New System.Drawing.Size(332, 22)
        Me.DTP_Hasta.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(159, 62)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "#Deposito"
        '
        'Txb_NumDepo
        '
        Me.Txb_NumDepo.Location = New System.Drawing.Point(163, 86)
        Me.Txb_NumDepo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Txb_NumDepo.Name = "Txb_NumDepo"
        Me.Txb_NumDepo.Size = New System.Drawing.Size(132, 22)
        Me.Txb_NumDepo.TabIndex = 0
        '
        'Txb_Consecutivo
        '
        Me.Txb_Consecutivo.Location = New System.Drawing.Point(8, 86)
        Me.Txb_Consecutivo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Txb_Consecutivo.Name = "Txb_Consecutivo"
        Me.Txb_Consecutivo.Size = New System.Drawing.Size(132, 22)
        Me.Txb_Consecutivo.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 64)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "#Consecutivo"
        '
        'btn_BuscaAgente
        '
        Me.btn_BuscaAgente.BackgroundImage = Global.SincroCliente.My.Resources.Resources.lupa3
        Me.btn_BuscaAgente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_BuscaAgente.Location = New System.Drawing.Point(615, 82)
        Me.btn_BuscaAgente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_BuscaAgente.Name = "btn_BuscaAgente"
        Me.btn_BuscaAgente.Size = New System.Drawing.Size(43, 30)
        Me.btn_BuscaAgente.TabIndex = 56
        Me.btn_BuscaAgente.UseVisualStyleBackColor = True
        '
        'txtb_CodAgente
        '
        Me.txtb_CodAgente.BackColor = System.Drawing.Color.White
        Me.txtb_CodAgente.Location = New System.Drawing.Point(473, 86)
        Me.txtb_CodAgente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtb_CodAgente.Name = "txtb_CodAgente"
        Me.txtb_CodAgente.Size = New System.Drawing.Size(132, 22)
        Me.txtb_CodAgente.TabIndex = 55
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(469, 64)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 17)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Cod Empleado"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(1281, 30)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(135, 70)
        Me.Button2.TabIndex = 71
        Me.Button2.Text = "LIMPIAR"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'chbx_VerAnulado
        '
        Me.chbx_VerAnulado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbx_VerAnulado.AutoSize = True
        Me.chbx_VerAnulado.Checked = True
        Me.chbx_VerAnulado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbx_VerAnulado.Location = New System.Drawing.Point(723, 37)
        Me.chbx_VerAnulado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chbx_VerAnulado.Name = "chbx_VerAnulado"
        Me.chbx_VerAnulado.Size = New System.Drawing.Size(115, 21)
        Me.chbx_VerAnulado.TabIndex = 70
        Me.chbx_VerAnulado.Text = "Ver Anulados"
        Me.chbx_VerAnulado.UseVisualStyleBackColor = True
        '
        'txtb_NumLiq
        '
        Me.txtb_NumLiq.BackColor = System.Drawing.Color.White
        Me.txtb_NumLiq.Location = New System.Drawing.Point(707, 86)
        Me.txtb_NumLiq.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtb_NumLiq.Name = "txtb_NumLiq"
        Me.txtb_NumLiq.Size = New System.Drawing.Size(132, 22)
        Me.txtb_NumLiq.TabIndex = 73
        Me.txtb_NumLiq.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(705, 64)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 17)
        Me.Label6.TabIndex = 72
        Me.Label6.Text = "Num Liquidacion"
        Me.Label6.Visible = False
        '
        'txtb_Monto
        '
        Me.txtb_Monto.Location = New System.Drawing.Point(304, 86)
        Me.txtb_Monto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtb_Monto.Name = "txtb_Monto"
        Me.txtb_Monto.Size = New System.Drawing.Size(160, 22)
        Me.txtb_Monto.TabIndex = 75
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(300, 64)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 17)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "Monto"
        '
        'Lista_Depositos_Choferes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1432, 545)
        Me.Controls.Add(Me.txtb_Monto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtb_NumLiq)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.chbx_VerAnulado)
        Me.Controls.Add(Me.btn_BuscaAgente)
        Me.Controls.Add(Me.txtb_CodAgente)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Txb_Consecutivo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Txb_NumDepo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DTP_Hasta)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DTP_Desde)
        Me.Controls.Add(Me.dgv_Liquidaciones)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Lista_Depositos_Choferes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista_Depositos"
        Me.TopMost = True
        CType(Me.dgv_Liquidaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_Liquidaciones As System.Windows.Forms.DataGridView
    Friend WithEvents DTP_Desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTP_Hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txb_NumDepo As System.Windows.Forms.TextBox
    Friend WithEvents Txb_Consecutivo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_BuscaAgente As System.Windows.Forms.Button
    Friend WithEvents txtb_CodAgente As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents chbx_VerAnulado As System.Windows.Forms.CheckBox
    Friend WithEvents txtb_NumLiq As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtb_Monto As TextBox
    Friend WithEvents Label7 As Label
End Class
