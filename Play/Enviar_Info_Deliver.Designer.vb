<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Enviar_Info_Deliver
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBX_Param = New System.Windows.Forms.CheckBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.lbl_TotalAgentes = New System.Windows.Forms.Label()
        Me.lbl_AgentesProcesados = New System.Windows.Forms.Label()
        Me.lbl_DetalleCarga = New System.Windows.Forms.Label()
        Me.Prgs_CargaAgentes = New System.Windows.Forms.ProgressBar()
        Me.btn_EnviarTodos = New System.Windows.Forms.Button()
        Me.btn_ExpoInfo = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btn_Cambiar = New System.Windows.Forms.Button()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.TextB_Agente1 = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.TextB_Agente2 = New System.Windows.Forms.TextBox()
        Me.TextB_Agente = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.DTP_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(101, 294)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(553, 26)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "CARGANDO INFORMACION POR FAVOR ESPERE..."
        Me.Label1.Visible = False
        '
        'CBX_Param
        '
        Me.CBX_Param.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CBX_Param.AutoSize = True
        Me.CBX_Param.Location = New System.Drawing.Point(593, 12)
        Me.CBX_Param.Name = "CBX_Param"
        Me.CBX_Param.Size = New System.Drawing.Size(90, 19)
        Me.CBX_Param.TabIndex = 24
        Me.CBX_Param.Text = "Parametros"
        Me.CBX_Param.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.DTP_Fecha)
        Me.GroupBox7.Controls.Add(Me.lbl_TotalAgentes)
        Me.GroupBox7.Controls.Add(Me.lbl_AgentesProcesados)
        Me.GroupBox7.Controls.Add(Me.lbl_DetalleCarga)
        Me.GroupBox7.Controls.Add(Me.Prgs_CargaAgentes)
        Me.GroupBox7.Controls.Add(Me.btn_EnviarTodos)
        Me.GroupBox7.Controls.Add(Me.btn_ExpoInfo)
        Me.GroupBox7.Controls.Add(Me.GroupBox6)
        Me.GroupBox7.Controls.Add(Me.TextB_Agente)
        Me.GroupBox7.Controls.Add(Me.Label47)
        Me.GroupBox7.Location = New System.Drawing.Point(62, 37)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(620, 245)
        Me.GroupBox7.TabIndex = 23
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Envio de informacion a Deliver"
        '
        'lbl_TotalAgentes
        '
        Me.lbl_TotalAgentes.AutoSize = True
        Me.lbl_TotalAgentes.Location = New System.Drawing.Point(521, 26)
        Me.lbl_TotalAgentes.Name = "lbl_TotalAgentes"
        Me.lbl_TotalAgentes.Size = New System.Drawing.Size(83, 15)
        Me.lbl_TotalAgentes.TabIndex = 18
        Me.lbl_TotalAgentes.Text = "TotalChoferes"
        '
        'lbl_AgentesProcesados
        '
        Me.lbl_AgentesProcesados.AutoSize = True
        Me.lbl_AgentesProcesados.Location = New System.Drawing.Point(212, 26)
        Me.lbl_AgentesProcesados.Name = "lbl_AgentesProcesados"
        Me.lbl_AgentesProcesados.Size = New System.Drawing.Size(124, 15)
        Me.lbl_AgentesProcesados.TabIndex = 17
        Me.lbl_AgentesProcesados.Text = "Choferes Procesados"
        '
        'lbl_DetalleCarga
        '
        Me.lbl_DetalleCarga.AutoSize = True
        Me.lbl_DetalleCarga.Location = New System.Drawing.Point(379, 26)
        Me.lbl_DetalleCarga.Name = "lbl_DetalleCarga"
        Me.lbl_DetalleCarga.Size = New System.Drawing.Size(82, 15)
        Me.lbl_DetalleCarga.TabIndex = 16
        Me.lbl_DetalleCarga.Text = "Detalle Carga"
        '
        'Prgs_CargaAgentes
        '
        Me.Prgs_CargaAgentes.Location = New System.Drawing.Point(206, 42)
        Me.Prgs_CargaAgentes.Name = "Prgs_CargaAgentes"
        Me.Prgs_CargaAgentes.Size = New System.Drawing.Size(386, 23)
        Me.Prgs_CargaAgentes.TabIndex = 15
        '
        'btn_EnviarTodos
        '
        Me.btn_EnviarTodos.Location = New System.Drawing.Point(6, 30)
        Me.btn_EnviarTodos.Name = "btn_EnviarTodos"
        Me.btn_EnviarTodos.Size = New System.Drawing.Size(182, 48)
        Me.btn_EnviarTodos.TabIndex = 0
        Me.btn_EnviarTodos.Text = "Exportar a todos"
        Me.btn_EnviarTodos.UseVisualStyleBackColor = True
        '
        'btn_ExpoInfo
        '
        Me.btn_ExpoInfo.Location = New System.Drawing.Point(6, 158)
        Me.btn_ExpoInfo.Name = "btn_ExpoInfo"
        Me.btn_ExpoInfo.Size = New System.Drawing.Size(182, 48)
        Me.btn_ExpoInfo.TabIndex = 1
        Me.btn_ExpoInfo.Text = "Exportar Informacion "
        Me.btn_ExpoInfo.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btn_Cambiar)
        Me.GroupBox6.Controls.Add(Me.Label48)
        Me.GroupBox6.Controls.Add(Me.Label51)
        Me.GroupBox6.Controls.Add(Me.TextB_Agente1)
        Me.GroupBox6.Controls.Add(Me.Label50)
        Me.GroupBox6.Controls.Add(Me.Label49)
        Me.GroupBox6.Controls.Add(Me.TextB_Agente2)
        Me.GroupBox6.Location = New System.Drawing.Point(206, 71)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(386, 135)
        Me.GroupBox6.TabIndex = 13
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Inter cambiar Rutas"
        '
        'btn_Cambiar
        '
        Me.btn_Cambiar.Location = New System.Drawing.Point(284, 28)
        Me.btn_Cambiar.Name = "btn_Cambiar"
        Me.btn_Cambiar.Size = New System.Drawing.Size(87, 67)
        Me.btn_Cambiar.TabIndex = 13
        Me.btn_Cambiar.Text = "CAMBIAR"
        Me.btn_Cambiar.UseVisualStyleBackColor = True
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(6, 40)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(137, 15)
        Me.Label48.TabIndex = 8
        Me.Label48.Text = "Generar informacion de"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(173, 58)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(50, 15)
        Me.Label51.TabIndex = 12
        Me.Label51.Text = "#Chofer"
        '
        'TextB_Agente1
        '
        Me.TextB_Agente1.Location = New System.Drawing.Point(146, 37)
        Me.TextB_Agente1.Name = "TextB_Agente1"
        Me.TextB_Agente1.Size = New System.Drawing.Size(100, 20)
        Me.TextB_Agente1.TabIndex = 7
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(173, 21)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(50, 15)
        Me.Label50.TabIndex = 11
        Me.Label50.Text = "#Chofer"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(6, 75)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(129, 15)
        Me.Label49.TabIndex = 9
        Me.Label49.Text = "Cargar informacion en"
        '
        'TextB_Agente2
        '
        Me.TextB_Agente2.Location = New System.Drawing.Point(146, 75)
        Me.TextB_Agente2.Name = "TextB_Agente2"
        Me.TextB_Agente2.Size = New System.Drawing.Size(100, 20)
        Me.TextB_Agente2.TabIndex = 10
        '
        'TextB_Agente
        '
        Me.TextB_Agente.Location = New System.Drawing.Point(6, 129)
        Me.TextB_Agente.Name = "TextB_Agente"
        Me.TextB_Agente.Size = New System.Drawing.Size(182, 20)
        Me.TextB_Agente.TabIndex = 2
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(70, 111)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(50, 15)
        Me.Label47.TabIndex = 3
        Me.Label47.Text = "#Chofer"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(510, 11)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(77, 19)
        Me.RadioButton2.TabIndex = 27
        Me.RadioButton2.Text = "Servidor2"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(414, 12)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(77, 19)
        Me.RadioButton1.TabIndex = 26
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Servidor1"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'DTP_Fecha
        '
        Me.DTP_Fecha.Location = New System.Drawing.Point(6, 84)
        Me.DTP_Fecha.Name = "DTP_Fecha"
        Me.DTP_Fecha.Size = New System.Drawing.Size(182, 20)
        Me.DTP_Fecha.TabIndex = 28
        '
        'Enviar_Info_Deliver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 339)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CBX_Param)
        Me.Controls.Add(Me.GroupBox7)
        Me.Name = "Enviar_Info_Deliver"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enviar_Info_Deliver"
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBX_Param As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_TotalAgentes As System.Windows.Forms.Label
    Friend WithEvents lbl_AgentesProcesados As System.Windows.Forms.Label
    Friend WithEvents lbl_DetalleCarga As System.Windows.Forms.Label
    Friend WithEvents Prgs_CargaAgentes As System.Windows.Forms.ProgressBar
    Friend WithEvents btn_EnviarTodos As System.Windows.Forms.Button
    Friend WithEvents btn_ExpoInfo As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Cambiar As System.Windows.Forms.Button
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents TextB_Agente1 As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents TextB_Agente2 As System.Windows.Forms.TextBox
    Friend WithEvents TextB_Agente As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents DTP_Fecha As DateTimePicker
End Class
