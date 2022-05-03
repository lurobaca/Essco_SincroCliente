<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfoMsjHacienda
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
        Me.txtb_Clave = New System.Windows.Forms.TextBox()
        Me.txtb_ind_estado = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtb_Mensaje = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtb_Fecha = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtb_TipoComprobante = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtb_NumeroConsecutivo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtb_Receptor_Nombre = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtb_ResumenFactura_TotalComprobante = New System.Windows.Forms.TextBox()
        Me.txtb_FechaEmision = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtb_CodInterno = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DGV_Historial = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btn_pdf = New System.Windows.Forms.Button()
        Me.btn_reenviarMail = New System.Windows.Forms.Button()
        Me.txtb_Email = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtb_tipoCedula = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtb_ReenviarEmail = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ChbX_Corregido = New System.Windows.Forms.CheckBox()
        Me.LBL_ESTADO = New System.Windows.Forms.Label()
        CType(Me.DGV_Historial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Clave"
        '
        'txtb_Clave
        '
        Me.txtb_Clave.Location = New System.Drawing.Point(15, 32)
        Me.txtb_Clave.Name = "txtb_Clave"
        Me.txtb_Clave.Size = New System.Drawing.Size(434, 20)
        Me.txtb_Clave.TabIndex = 2
        '
        'txtb_ind_estado
        '
        Me.txtb_ind_estado.Location = New System.Drawing.Point(12, 76)
        Me.txtb_ind_estado.Name = "txtb_ind_estado"
        Me.txtb_ind_estado.Size = New System.Drawing.Size(145, 20)
        Me.txtb_ind_estado.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Estado"
        '
        'txtb_Mensaje
        '
        Me.txtb_Mensaje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_Mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Mensaje.Location = New System.Drawing.Point(13, 165)
        Me.txtb_Mensaje.Multiline = True
        Me.txtb_Mensaje.Name = "txtb_Mensaje"
        Me.txtb_Mensaje.Size = New System.Drawing.Size(749, 118)
        Me.txtb_Mensaje.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Mesaje"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "FechaEmision"
        '
        'txtb_Fecha
        '
        Me.txtb_Fecha.Location = New System.Drawing.Point(15, 124)
        Me.txtb_Fecha.Name = "txtb_Fecha"
        Me.txtb_Fecha.Size = New System.Drawing.Size(145, 20)
        Me.txtb_Fecha.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(167, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 15)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "TipoComprobante"
        '
        'txtb_TipoComprobante
        '
        Me.txtb_TipoComprobante.Location = New System.Drawing.Point(169, 76)
        Me.txtb_TipoComprobante.Name = "txtb_TipoComprobante"
        Me.txtb_TipoComprobante.Size = New System.Drawing.Size(145, 20)
        Me.txtb_TipoComprobante.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(167, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "NumeroConsecutivo"
        '
        'txtb_NumeroConsecutivo
        '
        Me.txtb_NumeroConsecutivo.Location = New System.Drawing.Point(169, 124)
        Me.txtb_NumeroConsecutivo.Name = "txtb_NumeroConsecutivo"
        Me.txtb_NumeroConsecutivo.Size = New System.Drawing.Size(145, 20)
        Me.txtb_NumeroConsecutivo.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(320, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 15)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Receptor_Nombre"
        '
        'txtb_Receptor_Nombre
        '
        Me.txtb_Receptor_Nombre.Location = New System.Drawing.Point(320, 76)
        Me.txtb_Receptor_Nombre.Name = "txtb_Receptor_Nombre"
        Me.txtb_Receptor_Nombre.Size = New System.Drawing.Size(434, 20)
        Me.txtb_Receptor_Nombre.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(321, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 15)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Total Comprobante"
        '
        'txtb_ResumenFactura_TotalComprobante
        '
        Me.txtb_ResumenFactura_TotalComprobante.Location = New System.Drawing.Point(323, 124)
        Me.txtb_ResumenFactura_TotalComprobante.Name = "txtb_ResumenFactura_TotalComprobante"
        Me.txtb_ResumenFactura_TotalComprobante.Size = New System.Drawing.Size(145, 20)
        Me.txtb_ResumenFactura_TotalComprobante.TabIndex = 4
        '
        'txtb_FechaEmision
        '
        Me.txtb_FechaEmision.Location = New System.Drawing.Point(461, 32)
        Me.txtb_FechaEmision.Name = "txtb_FechaEmision"
        Me.txtb_FechaEmision.Size = New System.Drawing.Size(145, 20)
        Me.txtb_FechaEmision.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(458, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 15)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Fecha Estado"
        '
        'txtb_CodInterno
        '
        Me.txtb_CodInterno.Location = New System.Drawing.Point(484, 124)
        Me.txtb_CodInterno.Name = "txtb_CodInterno"
        Me.txtb_CodInterno.Size = New System.Drawing.Size(145, 20)
        Me.txtb_CodInterno.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(482, 105)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 15)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Cod Interno"
        '
        'DGV_Historial
        '
        Me.DGV_Historial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_Historial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Historial.Location = New System.Drawing.Point(16, 304)
        Me.DGV_Historial.Name = "DGV_Historial"
        Me.DGV_Historial.Size = New System.Drawing.Size(746, 205)
        Me.DGV_Historial.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 286)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 15)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Historico"
        '
        'btn_pdf
        '
        Me.btn_pdf.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_pdf.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_pdf.BackgroundImage = Global.SincroCliente.My.Resources.Resources.PDF3
        Me.btn_pdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_pdf.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_pdf.Location = New System.Drawing.Point(16, 515)
        Me.btn_pdf.Name = "btn_pdf"
        Me.btn_pdf.Size = New System.Drawing.Size(98, 84)
        Me.btn_pdf.TabIndex = 141
        Me.btn_pdf.UseVisualStyleBackColor = False
        '
        'btn_reenviarMail
        '
        Me.btn_reenviarMail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_reenviarMail.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_reenviarMail.BackgroundImage = Global.SincroCliente.My.Resources.Resources.Gmail_Icon
        Me.btn_reenviarMail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_reenviarMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_reenviarMail.Location = New System.Drawing.Point(664, 515)
        Me.btn_reenviarMail.Name = "btn_reenviarMail"
        Me.btn_reenviarMail.Size = New System.Drawing.Size(98, 84)
        Me.btn_reenviarMail.TabIndex = 142
        Me.btn_reenviarMail.UseVisualStyleBackColor = False
        '
        'txtb_Email
        '
        Me.txtb_Email.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_Email.Enabled = False
        Me.txtb_Email.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Email.Location = New System.Drawing.Point(364, 547)
        Me.txtb_Email.Name = "txtb_Email"
        Me.txtb_Email.Size = New System.Drawing.Size(294, 23)
        Me.txtb_Email.TabIndex = 144
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(148, 549)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(210, 18)
        Me.Label12.TabIndex = 143
        Me.Label12.Text = "Comprobante enviado al Email"
        '
        'txtb_tipoCedula
        '
        Me.txtb_tipoCedula.Location = New System.Drawing.Point(635, 124)
        Me.txtb_tipoCedula.Name = "txtb_tipoCedula"
        Me.txtb_tipoCedula.Size = New System.Drawing.Size(122, 20)
        Me.txtb_tipoCedula.TabIndex = 146
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(632, 105)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 15)
        Me.Label13.TabIndex = 145
        Me.Label13.Text = "Tipo Cedula"
        '
        'txtb_ReenviarEmail
        '
        Me.txtb_ReenviarEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtb_ReenviarEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_ReenviarEmail.Location = New System.Drawing.Point(364, 576)
        Me.txtb_ReenviarEmail.Name = "txtb_ReenviarEmail"
        Me.txtb_ReenviarEmail.Size = New System.Drawing.Size(294, 23)
        Me.txtb_ReenviarEmail.TabIndex = 147
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(148, 575)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(122, 18)
        Me.Label14.TabIndex = 148
        Me.Label14.Text = "Reenviar al Email"
        '
        'ChbX_Corregido
        '
        Me.ChbX_Corregido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChbX_Corregido.AutoSize = True
        Me.ChbX_Corregido.Location = New System.Drawing.Point(151, 515)
        Me.ChbX_Corregido.Name = "ChbX_Corregido"
        Me.ChbX_Corregido.Size = New System.Drawing.Size(156, 19)
        Me.ChbX_Corregido.TabIndex = 149
        Me.ChbX_Corregido.Text = "Marcar como Corregido"
        Me.ChbX_Corregido.UseVisualStyleBackColor = True
        '
        'LBL_ESTADO
        '
        Me.LBL_ESTADO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBL_ESTADO.AutoSize = True
        Me.LBL_ESTADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_ESTADO.Location = New System.Drawing.Point(361, 517)
        Me.LBL_ESTADO.Name = "LBL_ESTADO"
        Me.LBL_ESTADO.Size = New System.Drawing.Size(75, 18)
        Me.LBL_ESTADO.TabIndex = 150
        Me.LBL_ESTADO.Text = "ESTADO"
        '
        'InfoMsjHacienda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 604)
        Me.Controls.Add(Me.LBL_ESTADO)
        Me.Controls.Add(Me.ChbX_Corregido)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtb_ReenviarEmail)
        Me.Controls.Add(Me.txtb_tipoCedula)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtb_Email)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btn_reenviarMail)
        Me.Controls.Add(Me.btn_pdf)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.DGV_Historial)
        Me.Controls.Add(Me.txtb_CodInterno)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtb_FechaEmision)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtb_Mensaje)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtb_Fecha)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtb_ResumenFactura_TotalComprobante)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtb_NumeroConsecutivo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtb_TipoComprobante)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtb_ind_estado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtb_Receptor_Nombre)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtb_Clave)
        Me.Controls.Add(Me.Label1)
        Me.Name = "InfoMsjHacienda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "InfoMsjHacienda"
        CType(Me.DGV_Historial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtb_Clave As System.Windows.Forms.TextBox
    Friend WithEvents txtb_ind_estado As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtb_Mensaje As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtb_Fecha As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtb_TipoComprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtb_NumeroConsecutivo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtb_Receptor_Nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtb_ResumenFactura_TotalComprobante As System.Windows.Forms.TextBox
    Friend WithEvents txtb_FechaEmision As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtb_CodInterno As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents DGV_Historial As DataGridView
    Friend WithEvents Label11 As Label
    Friend WithEvents btn_pdf As Button
    Friend WithEvents btn_reenviarMail As Button
    Friend WithEvents txtb_Email As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtb_tipoCedula As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtb_ReenviarEmail As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents ChbX_Corregido As CheckBox
    Friend WithEvents LBL_ESTADO As Label
End Class
