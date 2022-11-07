<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MantenimientoLicencias
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
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CBox_Mensual = New System.Windows.Forms.CheckBox()
        Me.CBox_Anual = New System.Windows.Forms.CheckBox()
        Me.Txtb_Agentes = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTP_Desde = New System.Windows.Forms.DateTimePicker()
        Me.DTP_Hasta = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txtb_Choferes = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txtb_Oficina = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txtb_Total = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txtb_Dias = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.Location = New System.Drawing.Point(590, 214)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(106, 41)
        Me.btn_Cancelar.TabIndex = 0
        Me.btn_Cancelar.Text = "Cancelar"
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(553, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cantidad"
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Location = New System.Drawing.Point(478, 214)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(106, 41)
        Me.btn_aceptar.TabIndex = 2
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Recurrencia"
        '
        'CBox_Mensual
        '
        Me.CBox_Mensual.AutoSize = True
        Me.CBox_Mensual.Location = New System.Drawing.Point(138, 45)
        Me.CBox_Mensual.Name = "CBox_Mensual"
        Me.CBox_Mensual.Size = New System.Drawing.Size(83, 21)
        Me.CBox_Mensual.TabIndex = 4
        Me.CBox_Mensual.Text = "Mensual"
        Me.CBox_Mensual.UseVisualStyleBackColor = True
        '
        'CBox_Anual
        '
        Me.CBox_Anual.AutoSize = True
        Me.CBox_Anual.Location = New System.Drawing.Point(245, 45)
        Me.CBox_Anual.Name = "CBox_Anual"
        Me.CBox_Anual.Size = New System.Drawing.Size(66, 21)
        Me.CBox_Anual.TabIndex = 5
        Me.CBox_Anual.Text = "Anual"
        Me.CBox_Anual.UseVisualStyleBackColor = True
        '
        'Txtb_Agentes
        '
        Me.Txtb_Agentes.Location = New System.Drawing.Point(496, 40)
        Me.Txtb_Agentes.Name = "Txtb_Agentes"
        Me.Txtb_Agentes.Size = New System.Drawing.Size(200, 22)
        Me.Txtb_Agentes.TabIndex = 6
        Me.Txtb_Agentes.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Fecha Desde"
        '
        'DTP_Desde
        '
        Me.DTP_Desde.Location = New System.Drawing.Point(138, 86)
        Me.DTP_Desde.Name = "DTP_Desde"
        Me.DTP_Desde.Size = New System.Drawing.Size(200, 22)
        Me.DTP_Desde.TabIndex = 9
        '
        'DTP_Hasta
        '
        Me.DTP_Hasta.Location = New System.Drawing.Point(138, 128)
        Me.DTP_Hasta.Name = "DTP_Hasta"
        Me.DTP_Hasta.Size = New System.Drawing.Size(200, 22)
        Me.DTP_Hasta.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Fecha Hasta"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(389, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 17)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Agentes"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(389, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 17)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Choferes"
        '
        'Txtb_Choferes
        '
        Me.Txtb_Choferes.Location = New System.Drawing.Point(496, 84)
        Me.Txtb_Choferes.Name = "Txtb_Choferes"
        Me.Txtb_Choferes.Size = New System.Drawing.Size(200, 22)
        Me.Txtb_Choferes.TabIndex = 13
        Me.Txtb_Choferes.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(394, 126)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 17)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Oficina"
        '
        'Txtb_Oficina
        '
        Me.Txtb_Oficina.Location = New System.Drawing.Point(496, 126)
        Me.Txtb_Oficina.Name = "Txtb_Oficina"
        Me.Txtb_Oficina.Size = New System.Drawing.Size(200, 22)
        Me.Txtb_Oficina.TabIndex = 15
        Me.Txtb_Oficina.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(394, 167)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 17)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Total"
        '
        'Txtb_Total
        '
        Me.Txtb_Total.Location = New System.Drawing.Point(496, 164)
        Me.Txtb_Total.Name = "Txtb_Total"
        Me.Txtb_Total.Size = New System.Drawing.Size(200, 22)
        Me.Txtb_Total.TabIndex = 17
        Me.Txtb_Total.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 169)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 17)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Alerta Dias"
        '
        'Txtb_Dias
        '
        Me.Txtb_Dias.Location = New System.Drawing.Point(138, 164)
        Me.Txtb_Dias.Name = "Txtb_Dias"
        Me.Txtb_Dias.Size = New System.Drawing.Size(200, 22)
        Me.Txtb_Dias.TabIndex = 19
        Me.Txtb_Dias.Text = "0"
        '
        'MantenimientoLicencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 270)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Txtb_Dias)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Txtb_Total)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Txtb_Oficina)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Txtb_Choferes)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DTP_Hasta)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DTP_Desde)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txtb_Agentes)
        Me.Controls.Add(Me.CBox_Anual)
        Me.Controls.Add(Me.CBox_Mensual)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Cancelar)
        Me.Name = "MantenimientoLicencias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento Licencias"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_Cancelar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_aceptar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents CBox_Mensual As CheckBox
    Friend WithEvents CBox_Anual As CheckBox
    Friend WithEvents Txtb_Agentes As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents DTP_Desde As DateTimePicker
    Friend WithEvents DTP_Hasta As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Txtb_Choferes As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Txtb_Oficina As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Txtb_Total As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Txtb_Dias As TextBox
End Class
