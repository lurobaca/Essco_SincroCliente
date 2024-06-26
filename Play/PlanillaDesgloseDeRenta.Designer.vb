<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlanillaDesgloseDeRenta
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
        Me.Panel_AdjuntoVacaciones = New System.Windows.Forms.Panel()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Btn_AdjuntarVacacionesFirmado = New System.Windows.Forms.Button()
        Me.PBox_Vacaciones = New System.Windows.Forms.PictureBox()
        Me.Btn_VerVacacionesFirmado = New System.Windows.Forms.Button()
        Me.Txtb_RutaFotoDocumentoFirmadoVacaciones = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTP_FechaFinVacaciones = New System.Windows.Forms.DateTimePicker()
        Me.DTP_FechaIniVacaciones = New System.Windows.Forms.DateTimePicker()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtBox_NumDecretoEjecutivo = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Btn_Guardar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Btn_Buscar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Btn_Inactivar = New System.Windows.Forms.Button()
        Me.Panel_AdjuntoVacaciones.SuspendLayout()
        CType(Me.PBox_Vacaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel_AdjuntoVacaciones
        '
        Me.Panel_AdjuntoVacaciones.Controls.Add(Me.Label73)
        Me.Panel_AdjuntoVacaciones.Controls.Add(Me.Btn_AdjuntarVacacionesFirmado)
        Me.Panel_AdjuntoVacaciones.Controls.Add(Me.PBox_Vacaciones)
        Me.Panel_AdjuntoVacaciones.Controls.Add(Me.Btn_VerVacacionesFirmado)
        Me.Panel_AdjuntoVacaciones.Controls.Add(Me.Txtb_RutaFotoDocumentoFirmadoVacaciones)
        Me.Panel_AdjuntoVacaciones.Location = New System.Drawing.Point(16, 108)
        Me.Panel_AdjuntoVacaciones.Name = "Panel_AdjuntoVacaciones"
        Me.Panel_AdjuntoVacaciones.Size = New System.Drawing.Size(469, 85)
        Me.Panel_AdjuntoVacaciones.TabIndex = 88
        Me.Panel_AdjuntoVacaciones.Visible = False
        '
        'Label73
        '
        Me.Label73.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label73.AutoSize = True
        Me.Label73.Location = New System.Drawing.Point(4, 10)
        Me.Label73.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(38, 17)
        Me.Label73.TabIndex = 85
        Me.Label73.Text = "Ruta"
        '
        'Btn_AdjuntarVacacionesFirmado
        '
        Me.Btn_AdjuntarVacacionesFirmado.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Btn_AdjuntarVacacionesFirmado.Location = New System.Drawing.Point(247, 35)
        Me.Btn_AdjuntarVacacionesFirmado.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_AdjuntarVacacionesFirmado.Name = "Btn_AdjuntarVacacionesFirmado"
        Me.Btn_AdjuntarVacacionesFirmado.Size = New System.Drawing.Size(100, 36)
        Me.Btn_AdjuntarVacacionesFirmado.TabIndex = 80
        Me.Btn_AdjuntarVacacionesFirmado.Text = "Adjuntar"
        Me.Btn_AdjuntarVacacionesFirmado.UseVisualStyleBackColor = True
        '
        'PBox_Vacaciones
        '
        Me.PBox_Vacaciones.BackgroundImage = Global.SincroCliente.My.Resources.Resources.clip2
        Me.PBox_Vacaciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PBox_Vacaciones.Location = New System.Drawing.Point(186, 35)
        Me.PBox_Vacaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.PBox_Vacaciones.Name = "PBox_Vacaciones"
        Me.PBox_Vacaciones.Size = New System.Drawing.Size(53, 33)
        Me.PBox_Vacaciones.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox_Vacaciones.TabIndex = 83
        Me.PBox_Vacaciones.TabStop = False
        Me.PBox_Vacaciones.Visible = False
        '
        'Btn_VerVacacionesFirmado
        '
        Me.Btn_VerVacacionesFirmado.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Btn_VerVacacionesFirmado.Location = New System.Drawing.Point(363, 35)
        Me.Btn_VerVacacionesFirmado.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_VerVacacionesFirmado.Name = "Btn_VerVacacionesFirmado"
        Me.Btn_VerVacacionesFirmado.Size = New System.Drawing.Size(100, 36)
        Me.Btn_VerVacacionesFirmado.TabIndex = 81
        Me.Btn_VerVacacionesFirmado.Text = "Ver"
        Me.Btn_VerVacacionesFirmado.UseVisualStyleBackColor = True
        '
        'Txtb_RutaFotoDocumentoFirmadoVacaciones
        '
        Me.Txtb_RutaFotoDocumentoFirmadoVacaciones.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Txtb_RutaFotoDocumentoFirmadoVacaciones.Enabled = False
        Me.Txtb_RutaFotoDocumentoFirmadoVacaciones.Location = New System.Drawing.Point(149, 5)
        Me.Txtb_RutaFotoDocumentoFirmadoVacaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_RutaFotoDocumentoFirmadoVacaciones.Name = "Txtb_RutaFotoDocumentoFirmadoVacaciones"
        Me.Txtb_RutaFotoDocumentoFirmadoVacaciones.Size = New System.Drawing.Size(314, 22)
        Me.Txtb_RutaFotoDocumentoFirmadoVacaciones.TabIndex = 84
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(293, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 17)
        Me.Label1.TabIndex = 87
        Me.Label1.Text = "Publicado"
        '
        'DTP_FechaFinVacaciones
        '
        Me.DTP_FechaFinVacaciones.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_FechaFinVacaciones.Location = New System.Drawing.Point(377, 68)
        Me.DTP_FechaFinVacaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.DTP_FechaFinVacaciones.Name = "DTP_FechaFinVacaciones"
        Me.DTP_FechaFinVacaciones.Size = New System.Drawing.Size(108, 22)
        Me.DTP_FechaFinVacaciones.TabIndex = 92
        '
        'DTP_FechaIniVacaciones
        '
        Me.DTP_FechaIniVacaciones.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_FechaIniVacaciones.Location = New System.Drawing.Point(165, 68)
        Me.DTP_FechaIniVacaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.DTP_FechaIniVacaciones.Name = "DTP_FechaIniVacaciones"
        Me.DTP_FechaIniVacaciones.Size = New System.Drawing.Size(108, 22)
        Me.DTP_FechaIniVacaciones.TabIndex = 91
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(293, 68)
        Me.Label38.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(45, 17)
        Me.Label38.TabIndex = 90
        Me.Label38.Text = "Hasta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 68)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 17)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "Rige Desde"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(377, 22)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(108, 22)
        Me.DateTimePicker1.TabIndex = 94
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 22)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 17)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "Decreto Ejecutivo No"
        '
        'TxtBox_NumDecretoEjecutivo
        '
        Me.TxtBox_NumDecretoEjecutivo.Enabled = False
        Me.TxtBox_NumDecretoEjecutivo.Location = New System.Drawing.Point(165, 22)
        Me.TxtBox_NumDecretoEjecutivo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtBox_NumDecretoEjecutivo.Name = "TxtBox_NumDecretoEjecutivo"
        Me.TxtBox_NumDecretoEjecutivo.Size = New System.Drawing.Size(108, 22)
        Me.TxtBox_NumDecretoEjecutivo.TabIndex = 86
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(18, 270)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(108, 22)
        Me.TextBox2.TabIndex = 95
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 207)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 17)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "Tramos de Renta"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 244)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 17)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = " Desde"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(189, 244)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 17)
        Me.Label6.TabIndex = 98
        Me.Label6.Text = "Hasta"
        '
        'TextBox3
        '
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(156, 270)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(108, 22)
        Me.TextBox3.TabIndex = 99
        '
        'TextBox4
        '
        Me.TextBox4.Enabled = False
        Me.TextBox4.Location = New System.Drawing.Point(353, 270)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(108, 22)
        Me.TextBox4.TabIndex = 100
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(306, 249)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(181, 17)
        Me.Label7.TabIndex = 101
        Me.Label7.Text = "Tasa de impuesto aplicable"
        '
        'Btn_Guardar
        '
        Me.Btn_Guardar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Btn_Guardar.Location = New System.Drawing.Point(375, 574)
        Me.Btn_Guardar.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Guardar.Name = "Btn_Guardar"
        Me.Btn_Guardar.Size = New System.Drawing.Size(100, 36)
        Me.Btn_Guardar.TabIndex = 86
        Me.Btn_Guardar.Text = "Guardar"
        Me.Btn_Guardar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 314)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(469, 232)
        Me.DataGridView1.TabIndex = 102
        '
        'Btn_Buscar
        '
        Me.Btn_Buscar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Btn_Buscar.Location = New System.Drawing.Point(267, 574)
        Me.Btn_Buscar.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Buscar.Name = "Btn_Buscar"
        Me.Btn_Buscar.Size = New System.Drawing.Size(100, 36)
        Me.Btn_Buscar.TabIndex = 103
        Me.Btn_Buscar.Text = "Buscar"
        Me.Btn_Buscar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(408, 207)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 17)
        Me.Label8.TabIndex = 104
        Me.Label8.Text = "INACTIVO"
        Me.Label8.Visible = False
        '
        'Btn_Inactivar
        '
        Me.Btn_Inactivar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Btn_Inactivar.Location = New System.Drawing.Point(159, 574)
        Me.Btn_Inactivar.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Inactivar.Name = "Btn_Inactivar"
        Me.Btn_Inactivar.Size = New System.Drawing.Size(100, 36)
        Me.Btn_Inactivar.TabIndex = 105
        Me.Btn_Inactivar.Text = "Inactivar"
        Me.Btn_Inactivar.UseVisualStyleBackColor = True
        '
        'PlanillaDesgloseDeRenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 623)
        Me.Controls.Add(Me.Btn_Inactivar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Btn_Buscar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Btn_Guardar)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.TxtBox_NumDecretoEjecutivo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DTP_FechaFinVacaciones)
        Me.Controls.Add(Me.DTP_FechaIniVacaciones)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel_AdjuntoVacaciones)
        Me.MaximumSize = New System.Drawing.Size(518, 670)
        Me.MinimumSize = New System.Drawing.Size(518, 670)
        Me.Name = "PlanillaDesgloseDeRenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PlanillaDesgloseDeRenta"
        Me.Panel_AdjuntoVacaciones.ResumeLayout(False)
        Me.Panel_AdjuntoVacaciones.PerformLayout()
        CType(Me.PBox_Vacaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel_AdjuntoVacaciones As Panel
    Friend WithEvents Label73 As Label
    Friend WithEvents Btn_AdjuntarVacacionesFirmado As Button
    Friend WithEvents PBox_Vacaciones As PictureBox
    Friend WithEvents Btn_VerVacacionesFirmado As Button
    Friend WithEvents Txtb_RutaFotoDocumentoFirmadoVacaciones As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DTP_FechaFinVacaciones As DateTimePicker
    Friend WithEvents DTP_FechaIniVacaciones As DateTimePicker
    Friend WithEvents Label38 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtBox_NumDecretoEjecutivo As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Btn_Guardar As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Btn_Buscar As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Btn_Inactivar As Button
End Class
