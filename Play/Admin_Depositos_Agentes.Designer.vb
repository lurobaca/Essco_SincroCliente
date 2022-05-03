<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Depositos_Agentes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_Depositos_Agentes))
        Me.btn_AgNuevo = New System.Windows.Forms.Button()
        Me.btn_AgElimina = New System.Windows.Forms.Button()
        Me.btn_AgGuardar = New System.Windows.Forms.Button()
        Me.btn_AgModif = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txb_consecutivo = New System.Windows.Forms.TextBox()
        Me.txb_NumDepo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbbx_Banco = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txb_Comentario = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txb_Liquidacion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txb_Monto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txb_CodAgente = New System.Windows.Forms.TextBox()
        Me.txb_NomAgente = New System.Windows.Forms.TextBox()
        Me.btn_BuscaDepos = New System.Windows.Forms.Button()
        Me.btn_Agentes = New System.Windows.Forms.Button()
        Me.btn_GoToLiq = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtp_FechaContable = New System.Windows.Forms.DateTimePicker()
        Me.lbl_Anulado = New System.Windows.Forms.Label()
        Me.cbbx_Subido = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btn_AgNuevo
        '
        Me.btn_AgNuevo.Location = New System.Drawing.Point(125, 391)
        Me.btn_AgNuevo.Name = "btn_AgNuevo"
        Me.btn_AgNuevo.Size = New System.Drawing.Size(75, 38)
        Me.btn_AgNuevo.TabIndex = 15
        Me.btn_AgNuevo.Text = "Nuevo"
        Me.btn_AgNuevo.UseVisualStyleBackColor = True
        '
        'btn_AgElimina
        '
        Me.btn_AgElimina.Enabled = False
        Me.btn_AgElimina.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AgElimina.ForeColor = System.Drawing.Color.Red
        Me.btn_AgElimina.Location = New System.Drawing.Point(382, 391)
        Me.btn_AgElimina.Name = "btn_AgElimina"
        Me.btn_AgElimina.Size = New System.Drawing.Size(75, 38)
        Me.btn_AgElimina.TabIndex = 14
        Me.btn_AgElimina.Text = "ANULAR"
        Me.btn_AgElimina.UseVisualStyleBackColor = True
        '
        'btn_AgGuardar
        '
        Me.btn_AgGuardar.Location = New System.Drawing.Point(206, 391)
        Me.btn_AgGuardar.Name = "btn_AgGuardar"
        Me.btn_AgGuardar.Size = New System.Drawing.Size(75, 38)
        Me.btn_AgGuardar.TabIndex = 9
        Me.btn_AgGuardar.Text = "Guardar"
        Me.btn_AgGuardar.UseVisualStyleBackColor = True
        '
        'btn_AgModif
        '
        Me.btn_AgModif.Enabled = False
        Me.btn_AgModif.Location = New System.Drawing.Point(287, 391)
        Me.btn_AgModif.Name = "btn_AgModif"
        Me.btn_AgModif.Size = New System.Drawing.Size(75, 38)
        Me.btn_AgModif.TabIndex = 13
        Me.btn_AgModif.Text = "Modificar"
        Me.btn_AgModif.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 15)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Consecutivo"
        '
        'txb_consecutivo
        '
        Me.txb_consecutivo.BackColor = System.Drawing.SystemColors.Info
        Me.txb_consecutivo.Enabled = False
        Me.txb_consecutivo.Location = New System.Drawing.Point(124, 9)
        Me.txb_consecutivo.Name = "txb_consecutivo"
        Me.txb_consecutivo.Size = New System.Drawing.Size(121, 20)
        Me.txb_consecutivo.TabIndex = 0
        '
        'txb_NumDepo
        '
        Me.txb_NumDepo.BackColor = System.Drawing.SystemColors.Info
        Me.txb_NumDepo.Location = New System.Drawing.Point(124, 40)
        Me.txb_NumDepo.Name = "txb_NumDepo"
        Me.txb_NumDepo.Size = New System.Drawing.Size(327, 20)
        Me.txb_NumDepo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 15)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "# Depositos"
        '
        'cbbx_Banco
        '
        Me.cbbx_Banco.FormattingEnabled = True
        Me.cbbx_Banco.Location = New System.Drawing.Point(124, 104)
        Me.cbbx_Banco.Name = "cbbx_Banco"
        Me.cbbx_Banco.Size = New System.Drawing.Size(327, 21)
        Me.cbbx_Banco.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 15)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Banco"
        '
        'dtp_Fecha
        '
        Me.dtp_Fecha.Location = New System.Drawing.Point(126, 134)
        Me.dtp_Fecha.Name = "dtp_Fecha"
        Me.dtp_Fecha.Size = New System.Drawing.Size(327, 20)
        Me.dtp_Fecha.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 15)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Fecha Liquidacion"
        '
        'txb_Comentario
        '
        Me.txb_Comentario.Location = New System.Drawing.Point(130, 284)
        Me.txb_Comentario.Multiline = True
        Me.txb_Comentario.Name = "txb_Comentario"
        Me.txb_Comentario.Size = New System.Drawing.Size(325, 101)
        Me.txb_Comentario.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 284)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 15)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Descripcion"
        '
        'txb_Liquidacion
        '
        Me.txb_Liquidacion.Location = New System.Drawing.Point(130, 248)
        Me.txb_Liquidacion.Name = "txb_Liquidacion"
        Me.txb_Liquidacion.Size = New System.Drawing.Size(296, 20)
        Me.txb_Liquidacion.TabIndex = 27
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 248)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 15)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "# Liquidacion"
        '
        'txb_Monto
        '
        Me.txb_Monto.Location = New System.Drawing.Point(127, 189)
        Me.txb_Monto.Name = "txb_Monto"
        Me.txb_Monto.Size = New System.Drawing.Size(327, 20)
        Me.txb_Monto.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 196)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 15)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Monto"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 79)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 15)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Agente"
        '
        'txb_CodAgente
        '
        Me.txb_CodAgente.Enabled = False
        Me.txb_CodAgente.Location = New System.Drawing.Point(124, 72)
        Me.txb_CodAgente.Name = "txb_CodAgente"
        Me.txb_CodAgente.Size = New System.Drawing.Size(51, 20)
        Me.txb_CodAgente.TabIndex = 2
        '
        'txb_NomAgente
        '
        Me.txb_NomAgente.Enabled = False
        Me.txb_NomAgente.Location = New System.Drawing.Point(181, 72)
        Me.txb_NomAgente.Name = "txb_NomAgente"
        Me.txb_NomAgente.Size = New System.Drawing.Size(244, 20)
        Me.txb_NomAgente.TabIndex = 34
        '
        'btn_BuscaDepos
        '
        Me.btn_BuscaDepos.BackgroundImage = Global.SincroCliente.My.Resources.Resources.lupa3
        Me.btn_BuscaDepos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_BuscaDepos.Location = New System.Drawing.Point(251, 4)
        Me.btn_BuscaDepos.Name = "btn_BuscaDepos"
        Me.btn_BuscaDepos.Size = New System.Drawing.Size(37, 29)
        Me.btn_BuscaDepos.TabIndex = 36
        Me.btn_BuscaDepos.UseVisualStyleBackColor = True
        '
        'btn_Agentes
        '
        Me.btn_Agentes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_Agentes.Image = CType(resources.GetObject("btn_Agentes.Image"), System.Drawing.Image)
        Me.btn_Agentes.Location = New System.Drawing.Point(429, 72)
        Me.btn_Agentes.Name = "btn_Agentes"
        Me.btn_Agentes.Size = New System.Drawing.Size(27, 22)
        Me.btn_Agentes.TabIndex = 2
        Me.btn_Agentes.UseVisualStyleBackColor = True
        '
        'btn_GoToLiq
        '
        Me.btn_GoToLiq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_GoToLiq.Enabled = False
        Me.btn_GoToLiq.Image = CType(resources.GetObject("btn_GoToLiq.Image"), System.Drawing.Image)
        Me.btn_GoToLiq.Location = New System.Drawing.Point(430, 248)
        Me.btn_GoToLiq.Name = "btn_GoToLiq"
        Me.btn_GoToLiq.Size = New System.Drawing.Size(27, 22)
        Me.btn_GoToLiq.TabIndex = 7
        Me.btn_GoToLiq.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 228)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 15)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "Subido"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 167)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(113, 15)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "Fecha Contabilidad"
        '
        'dtp_FechaContable
        '
        Me.dtp_FechaContable.Location = New System.Drawing.Point(126, 161)
        Me.dtp_FechaContable.Name = "dtp_FechaContable"
        Me.dtp_FechaContable.Size = New System.Drawing.Size(327, 20)
        Me.dtp_FechaContable.TabIndex = 5
        '
        'lbl_Anulado
        '
        Me.lbl_Anulado.AutoSize = True
        Me.lbl_Anulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Anulado.ForeColor = System.Drawing.Color.Red
        Me.lbl_Anulado.Location = New System.Drawing.Point(339, 12)
        Me.lbl_Anulado.Name = "lbl_Anulado"
        Me.lbl_Anulado.Size = New System.Drawing.Size(98, 20)
        Me.lbl_Anulado.TabIndex = 41
        Me.lbl_Anulado.Text = "ANULADO"
        Me.lbl_Anulado.Visible = False
        '
        'cbbx_Subido
        '
        Me.cbbx_Subido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbx_Subido.FormattingEnabled = True
        Me.cbbx_Subido.Items.AddRange(New Object() {"", "SI", "NO"})
        Me.cbbx_Subido.Location = New System.Drawing.Point(130, 215)
        Me.cbbx_Subido.Name = "cbbx_Subido"
        Me.cbbx_Subido.Size = New System.Drawing.Size(327, 21)
        Me.cbbx_Subido.TabIndex = 42
        '
        'Admin_Depositos_Agentes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 435)
        Me.Controls.Add(Me.cbbx_Subido)
        Me.Controls.Add(Me.lbl_Anulado)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.dtp_FechaContable)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btn_BuscaDepos)
        Me.Controls.Add(Me.btn_Agentes)
        Me.Controls.Add(Me.txb_NomAgente)
        Me.Controls.Add(Me.txb_CodAgente)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txb_Monto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btn_GoToLiq)
        Me.Controls.Add(Me.txb_Liquidacion)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txb_Comentario)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtp_Fecha)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbbx_Banco)
        Me.Controls.Add(Me.txb_NumDepo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txb_consecutivo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_AgNuevo)
        Me.Controls.Add(Me.btn_AgElimina)
        Me.Controls.Add(Me.btn_AgGuardar)
        Me.Controls.Add(Me.btn_AgModif)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(443, 364)
        Me.Name = "Admin_Depositos_Agentes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administra Depositos de Agentes "
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_AgNuevo As System.Windows.Forms.Button
    Friend WithEvents btn_AgElimina As System.Windows.Forms.Button
    Friend WithEvents btn_AgGuardar As System.Windows.Forms.Button
    Friend WithEvents btn_AgModif As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txb_consecutivo As System.Windows.Forms.TextBox
    Friend WithEvents txb_NumDepo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbbx_Banco As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtp_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txb_Comentario As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txb_Liquidacion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_GoToLiq As System.Windows.Forms.Button
    Friend WithEvents txb_Monto As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txb_CodAgente As System.Windows.Forms.TextBox
    Friend WithEvents txb_NomAgente As System.Windows.Forms.TextBox
    Friend WithEvents btn_Agentes As System.Windows.Forms.Button
    Friend WithEvents btn_BuscaDepos As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtp_FechaContable As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Anulado As System.Windows.Forms.Label
    Friend WithEvents cbbx_Subido As System.Windows.Forms.ComboBox
End Class
