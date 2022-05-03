<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Enviar_Info_Picking
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
        Me.btn_ExpoInfo = New System.Windows.Forms.Button
        Me.TextB_CodBodeguero = New System.Windows.Forms.TextBox
        Me.Label47 = New System.Windows.Forms.Label
        Me.CBX_Param = New System.Windows.Forms.CheckBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.btn_Cambiar = New System.Windows.Forms.Button
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.TextB_Bod1 = New System.Windows.Forms.TextBox
        Me.Label50 = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.TextB_Bod2 = New System.Windows.Forms.TextBox
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_ExpoInfo
        '
        Me.btn_ExpoInfo.Location = New System.Drawing.Point(22, 71)
        Me.btn_ExpoInfo.Name = "btn_ExpoInfo"
        Me.btn_ExpoInfo.Size = New System.Drawing.Size(182, 48)
        Me.btn_ExpoInfo.TabIndex = 4
        Me.btn_ExpoInfo.Text = "Exportar Informacion "
        Me.btn_ExpoInfo.UseVisualStyleBackColor = True
        '
        'TextB_CodBodeguero
        '
        Me.TextB_CodBodeguero.Location = New System.Drawing.Point(22, 42)
        Me.TextB_CodBodeguero.Name = "TextB_CodBodeguero"
        Me.TextB_CodBodeguero.Size = New System.Drawing.Size(182, 20)
        Me.TextB_CodBodeguero.TabIndex = 5
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(19, 24)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(66, 13)
        Me.Label47.TabIndex = 6
        Me.Label47.Text = "#Bodeguero"
        '
        'CBX_Param
        '
        Me.CBX_Param.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CBX_Param.AutoSize = True
        Me.CBX_Param.Location = New System.Drawing.Point(0, -1)
        Me.CBX_Param.Name = "CBX_Param"
        Me.CBX_Param.Size = New System.Drawing.Size(79, 17)
        Me.CBX_Param.TabIndex = 18
        Me.CBX_Param.Text = "Parametros"
        Me.CBX_Param.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btn_Cambiar)
        Me.GroupBox6.Controls.Add(Me.Label48)
        Me.GroupBox6.Controls.Add(Me.Label51)
        Me.GroupBox6.Controls.Add(Me.TextB_Bod1)
        Me.GroupBox6.Controls.Add(Me.Label50)
        Me.GroupBox6.Controls.Add(Me.Label49)
        Me.GroupBox6.Controls.Add(Me.TextB_Bod2)
        Me.GroupBox6.Location = New System.Drawing.Point(230, 24)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(386, 106)
        Me.GroupBox6.TabIndex = 22
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Inter cambiar Bodeguero"
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
        Me.Label48.Size = New System.Drawing.Size(117, 13)
        Me.Label48.TabIndex = 8
        Me.Label48.Text = "Generar informacion de"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(173, 58)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(66, 13)
        Me.Label51.TabIndex = 12
        Me.Label51.Text = "#Bodeguero"
        '
        'TextB_Bod1
        '
        Me.TextB_Bod1.Location = New System.Drawing.Point(146, 37)
        Me.TextB_Bod1.Name = "TextB_Bod1"
        Me.TextB_Bod1.Size = New System.Drawing.Size(100, 20)
        Me.TextB_Bod1.TabIndex = 7
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(173, 21)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(66, 13)
        Me.Label50.TabIndex = 11
        Me.Label50.Text = "#Bodeguero"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(6, 75)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(110, 13)
        Me.Label49.TabIndex = 9
        Me.Label49.Text = "Cargar informacion en"
        '
        'TextB_Bod2
        '
        Me.TextB_Bod2.Location = New System.Drawing.Point(146, 75)
        Me.TextB_Bod2.Name = "TextB_Bod2"
        Me.TextB_Bod2.Size = New System.Drawing.Size(100, 20)
        Me.TextB_Bod2.TabIndex = 10
        '
        'Enviar_Info_Picking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 151)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.CBX_Param)
        Me.Controls.Add(Me.btn_ExpoInfo)
        Me.Controls.Add(Me.TextB_CodBodeguero)
        Me.Controls.Add(Me.Label47)
        Me.MaximumSize = New System.Drawing.Size(644, 189)
        Me.MinimumSize = New System.Drawing.Size(644, 189)
        Me.Name = "Enviar_Info_Picking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enviar_Info_Picking"
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_ExpoInfo As System.Windows.Forms.Button
    Friend WithEvents TextB_CodBodeguero As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents CBX_Param As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Cambiar As System.Windows.Forms.Button
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents TextB_Bod1 As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents TextB_Bod2 As System.Windows.Forms.TextBox
End Class
