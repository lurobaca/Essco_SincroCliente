<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeduccionesAcreditaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DeduccionesAcreditaciones))
        Me.Txb_Cedula = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.txtb_Nombre = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DGV_Deducciones = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txtb_Monto = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Cbx_Tipo = New System.Windows.Forms.ComboBox
        Me.DTP_FechaLimite = New System.Windows.Forms.DateTimePicker
        Me.ChkB_Hasta = New System.Windows.Forms.CheckBox
        Me.btn_EmplAtras = New System.Windows.Forms.Button
        Me.Btn_EmplAdelante = New System.Windows.Forms.Button
        Me.Txt_Id = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.Txb_RutaImagen = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_Deducciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Txb_Cedula
        '
        Me.Txb_Cedula.Location = New System.Drawing.Point(75, 175)
        Me.Txb_Cedula.Name = "Txb_Cedula"
        Me.Txb_Cedula.Size = New System.Drawing.Size(100, 20)
        Me.Txb_Cedula.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 178)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Cedula"
        '
        'Button3
        '
        'Me.Button3.Image = Global.SincroCliente.My.Resources.Resources.lupa3
        Me.Button3.Location = New System.Drawing.Point(179, 171)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(34, 26)
        Me.Button3.TabIndex = 25
        Me.Button3.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        'Me.PictureBox1.Image = Global.SincroCliente.My.Resources.Resources.SinFoto2
        Me.PictureBox1.Location = New System.Drawing.Point(119, 35)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 130)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 26
        Me.PictureBox1.TabStop = False
        '
        'txtb_Nombre
        '
        Me.txtb_Nombre.Location = New System.Drawing.Point(75, 203)
        Me.txtb_Nombre.Name = "txtb_Nombre"
        Me.txtb_Nombre.ReadOnly = True
        Me.txtb_Nombre.Size = New System.Drawing.Size(283, 20)
        Me.txtb_Nombre.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 206)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Nombre"
        '
        'DGV_Deducciones
        '
        Me.DGV_Deducciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_Deducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Deducciones.Location = New System.Drawing.Point(378, 1)
        Me.DGV_Deducciones.Name = "DGV_Deducciones"
        Me.DGV_Deducciones.Size = New System.Drawing.Size(343, 370)
        Me.DGV_Deducciones.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 232)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Tipo"
        '
        'Txtb_Monto
        '
        Me.Txtb_Monto.Location = New System.Drawing.Point(75, 255)
        Me.Txtb_Monto.Name = "Txtb_Monto"
        Me.Txtb_Monto.Size = New System.Drawing.Size(283, 20)
        Me.Txtb_Monto.TabIndex = 35
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 258)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Monto"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(75, 327)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 35)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "Nuevo"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(179, 328)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 35)
        Me.Button2.TabIndex = 37
        Me.Button2.Text = "Guardar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(283, 327)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 35)
        Me.Button4.TabIndex = 38
        Me.Button4.Text = "Eliminar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Cbx_Tipo
        '
        Me.Cbx_Tipo.FormattingEnabled = True
        Me.Cbx_Tipo.Items.AddRange(New Object() {"ADICIONAL", "DEB PERSONAL", "DUCC CUOTA BP", "DEDUCION DE CELULAR", "EMBARGO", "COBROS PRESTAMO", "FALTANTES LIQ", "FACTURAS", "COBROS X FALTANTE", "OTROS"})
        Me.Cbx_Tipo.Location = New System.Drawing.Point(75, 228)
        Me.Cbx_Tipo.Name = "Cbx_Tipo"
        Me.Cbx_Tipo.Size = New System.Drawing.Size(283, 21)
        Me.Cbx_Tipo.TabIndex = 39
        '
        'DTP_FechaLimite
        '
        Me.DTP_FechaLimite.Enabled = False
        Me.DTP_FechaLimite.Location = New System.Drawing.Point(158, 282)
        Me.DTP_FechaLimite.Name = "DTP_FechaLimite"
        Me.DTP_FechaLimite.Size = New System.Drawing.Size(200, 20)
        Me.DTP_FechaLimite.TabIndex = 40
        '
        'ChkB_Hasta
        '
        Me.ChkB_Hasta.AutoSize = True
        Me.ChkB_Hasta.Location = New System.Drawing.Point(75, 286)
        Me.ChkB_Hasta.Name = "ChkB_Hasta"
        Me.ChkB_Hasta.Size = New System.Drawing.Size(54, 17)
        Me.ChkB_Hasta.TabIndex = 41
        Me.ChkB_Hasta.Text = "Hasta"
        Me.ChkB_Hasta.UseVisualStyleBackColor = True
        '
        'btn_EmplAtras
        '
        Me.btn_EmplAtras.BackColor = System.Drawing.Color.Transparent
        Me.btn_EmplAtras.BackgroundImage = CType(resources.GetObject("btn_EmplAtras.BackgroundImage"), System.Drawing.Image)
        Me.btn_EmplAtras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_EmplAtras.Location = New System.Drawing.Point(38, 82)
        Me.btn_EmplAtras.Name = "btn_EmplAtras"
        Me.btn_EmplAtras.Size = New System.Drawing.Size(75, 40)
        Me.btn_EmplAtras.TabIndex = 81
        Me.btn_EmplAtras.UseVisualStyleBackColor = False
        '
        'Btn_EmplAdelante
        '
        Me.Btn_EmplAdelante.BackColor = System.Drawing.Color.Transparent
        Me.Btn_EmplAdelante.BackgroundImage = CType(resources.GetObject("Btn_EmplAdelante.BackgroundImage"), System.Drawing.Image)
        Me.Btn_EmplAdelante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_EmplAdelante.Location = New System.Drawing.Point(277, 82)
        Me.Btn_EmplAdelante.Name = "Btn_EmplAdelante"
        Me.Btn_EmplAdelante.Size = New System.Drawing.Size(75, 40)
        Me.Btn_EmplAdelante.TabIndex = 80
        Me.Btn_EmplAdelante.UseVisualStyleBackColor = False
        '
        'Txt_Id
        '
        Me.Txt_Id.Location = New System.Drawing.Point(179, 9)
        Me.Txt_Id.Name = "Txt_Id"
        Me.Txt_Id.ReadOnly = True
        Me.Txt_Id.Size = New System.Drawing.Size(38, 20)
        Me.Txt_Id.TabIndex = 83
        Me.Txt_Id.Text = "0"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(148, 12)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(16, 13)
        Me.Label41.TabIndex = 82
        Me.Label41.Text = "Id"
        Me.Label41.Visible = False
        '
        'Txb_RutaImagen
        '
        Me.Txb_RutaImagen.Location = New System.Drawing.Point(297, 177)
        Me.Txb_RutaImagen.Name = "Txb_RutaImagen"
        Me.Txb_RutaImagen.ReadOnly = True
        Me.Txb_RutaImagen.Size = New System.Drawing.Size(61, 20)
        Me.Txb_RutaImagen.TabIndex = 89
        Me.Txb_RutaImagen.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(261, 178)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(30, 13)
        Me.Label30.TabIndex = 88
        Me.Label30.Text = "Ruta"
        Me.Label30.Visible = False
        '
        'DeduccionesAcreditaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 374)
        Me.Controls.Add(Me.Txb_RutaImagen)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Txt_Id)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.btn_EmplAtras)
        Me.Controls.Add(Me.Btn_EmplAdelante)
        Me.Controls.Add(Me.ChkB_Hasta)
        Me.Controls.Add(Me.DTP_FechaLimite)
        Me.Controls.Add(Me.Cbx_Tipo)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Txtb_Monto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DGV_Deducciones)
        Me.Controls.Add(Me.txtb_Nombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Txb_Cedula)
        Me.Controls.Add(Me.Label1)
        Me.Name = "DeduccionesAcreditaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DeduccionesAcreditaciones"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_Deducciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Txb_Cedula As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtb_Nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DGV_Deducciones As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txtb_Monto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Cbx_Tipo As System.Windows.Forms.ComboBox
    Friend WithEvents DTP_FechaLimite As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkB_Hasta As System.Windows.Forms.CheckBox
    Friend WithEvents btn_EmplAtras As System.Windows.Forms.Button
    Friend WithEvents Btn_EmplAdelante As System.Windows.Forms.Button
    Friend WithEvents Txt_Id As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Txb_RutaImagen As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
End Class
