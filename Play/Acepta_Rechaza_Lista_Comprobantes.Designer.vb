<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Acepta_Rechaza_Lista_Comprobantes
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DGV_ListaFE = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Dtp_Fin = New System.Windows.Forms.DateTimePicker()
        Me.Dtp_Ini = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmb_Tipo = New System.Windows.Forms.ComboBox()
        Me.txtb_clave = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cmb_Estado = New System.Windows.Forms.ComboBox()
        Me.Cmb_EstadoDefinido = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Cxb_BFecha = New System.Windows.Forms.CheckBox()
        Me.txtb_proveedor = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cxb_VerProcesadas = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.DGV_ListaFE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_ListaFE
        '
        Me.DGV_ListaFE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_ListaFE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ListaFE.Location = New System.Drawing.Point(4, 132)
        Me.DGV_ListaFE.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DGV_ListaFE.Name = "DGV_ListaFE"
        Me.DGV_ListaFE.Size = New System.Drawing.Size(1313, 444)
        Me.DGV_ListaFE.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(817, 59)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 17)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Hasta"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(817, 18)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 17)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Desde"
        '
        'Dtp_Fin
        '
        Me.Dtp_Fin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dtp_Fin.Enabled = False
        Me.Dtp_Fin.Location = New System.Drawing.Point(877, 55)
        Me.Dtp_Fin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Dtp_Fin.Name = "Dtp_Fin"
        Me.Dtp_Fin.Size = New System.Drawing.Size(265, 22)
        Me.Dtp_Fin.TabIndex = 22
        '
        'Dtp_Ini
        '
        Me.Dtp_Ini.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dtp_Ini.Enabled = False
        Me.Dtp_Ini.Location = New System.Drawing.Point(877, 16)
        Me.Dtp_Ini.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Dtp_Ini.Name = "Dtp_Ini"
        Me.Dtp_Ini.Size = New System.Drawing.Size(265, 22)
        Me.Dtp_Ini.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 58)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 17)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Tipo"
        '
        'Cmb_Tipo
        '
        Me.Cmb_Tipo.FormattingEnabled = True
        Me.Cmb_Tipo.Items.AddRange(New Object() {"FE", "NC", "ND", "MR", "TE"})
        Me.Cmb_Tipo.Location = New System.Drawing.Point(96, 54)
        Me.Cmb_Tipo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Cmb_Tipo.Name = "Cmb_Tipo"
        Me.Cmb_Tipo.Size = New System.Drawing.Size(51, 24)
        Me.Cmb_Tipo.TabIndex = 19
        '
        'txtb_clave
        '
        Me.txtb_clave.Location = New System.Drawing.Point(96, 15)
        Me.txtb_clave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtb_clave.Name = "txtb_clave"
        Me.txtb_clave.Size = New System.Drawing.Size(565, 22)
        Me.txtb_clave.TabIndex = 16
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(1152, 15)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(165, 36)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Limpiar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 17)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Clave"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(156, 58)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 17)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Hacienda"
        '
        'Cmb_Estado
        '
        Me.Cmb_Estado.FormattingEnabled = True
        Me.Cmb_Estado.Items.AddRange(New Object() {"rechazado", "aceptado", "Otros", "SIN ESTADO"})
        Me.Cmb_Estado.Location = New System.Drawing.Point(244, 53)
        Me.Cmb_Estado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Cmb_Estado.Name = "Cmb_Estado"
        Me.Cmb_Estado.Size = New System.Drawing.Size(160, 24)
        Me.Cmb_Estado.TabIndex = 27
        '
        'Cmb_EstadoDefinido
        '
        Me.Cmb_EstadoDefinido.FormattingEnabled = True
        Me.Cmb_EstadoDefinido.Items.AddRange(New Object() {"Comprobante Aceptado", "Comprobante Parcialmente Aceptado", "Rechazado", "SIN ESTADO"})
        Me.Cmb_EstadoDefinido.Location = New System.Drawing.Point(501, 53)
        Me.Cmb_EstadoDefinido.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Cmb_EstadoDefinido.Name = "Cmb_EstadoDefinido"
        Me.Cmb_EstadoDefinido.Size = New System.Drawing.Size(160, 24)
        Me.Cmb_EstadoDefinido.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(413, 58)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 17)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Definido"
        '
        'Cxb_BFecha
        '
        Me.Cxb_BFecha.AutoSize = True
        Me.Cxb_BFecha.Location = New System.Drawing.Point(671, 16)
        Me.Cxb_BFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Cxb_BFecha.Name = "Cxb_BFecha"
        Me.Cxb_BFecha.Size = New System.Drawing.Size(109, 21)
        Me.Cxb_BFecha.TabIndex = 30
        Me.Cxb_BFecha.Text = "Cxb_BFecha"
        Me.Cxb_BFecha.UseVisualStyleBackColor = True
        '
        'txtb_proveedor
        '
        Me.txtb_proveedor.Location = New System.Drawing.Point(96, 87)
        Me.txtb_proveedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtb_proveedor.Name = "txtb_proveedor"
        Me.txtb_proveedor.Size = New System.Drawing.Size(565, 22)
        Me.txtb_proveedor.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 91)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 17)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Proveedor"
        '
        'Cxb_VerProcesadas
        '
        Me.Cxb_VerProcesadas.AutoSize = True
        Me.Cxb_VerProcesadas.Location = New System.Drawing.Point(671, 89)
        Me.Cxb_VerProcesadas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Cxb_VerProcesadas.Name = "Cxb_VerProcesadas"
        Me.Cxb_VerProcesadas.Size = New System.Drawing.Size(146, 21)
        Me.Cxb_VerProcesadas.TabIndex = 33
        Me.Cxb_VerProcesadas.Text = "Incluir Procesadas"
        Me.Cxb_VerProcesadas.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(1152, 53)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(165, 36)
        Me.Button2.TabIndex = 34
        Me.Button2.Text = "Buscar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Acepta_Rechaza_Lista_Comprobantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1323, 580)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Cxb_VerProcesadas)
        Me.Controls.Add(Me.txtb_proveedor)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Cxb_BFecha)
        Me.Controls.Add(Me.Cmb_EstadoDefinido)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Cmb_Estado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Dtp_Fin)
        Me.Controls.Add(Me.Dtp_Ini)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Cmb_Tipo)
        Me.Controls.Add(Me.txtb_clave)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGV_ListaFE)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Acepta_Rechaza_Lista_Comprobantes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista_FE_Proveedores"
        CType(Me.DGV_ListaFE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV_ListaFE As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Dtp_Fin As DateTimePicker
    Friend WithEvents Dtp_Ini As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Cmb_Tipo As ComboBox
    Friend WithEvents txtb_clave As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Cmb_Estado As ComboBox
    Friend WithEvents Cmb_EstadoDefinido As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Cxb_BFecha As CheckBox
    Friend WithEvents txtb_proveedor As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Cxb_VerProcesadas As CheckBox
    Friend WithEvents Button2 As Button
End Class
