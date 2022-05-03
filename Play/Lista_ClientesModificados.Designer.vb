<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Lista_ClientesModificados
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
        Me.CBX_Estado = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtb_buscar = New System.Windows.Forms.TextBox()
        Me.rb_Codigo = New System.Windows.Forms.RadioButton()
        Me.rb_nombre = New System.Windows.Forms.RadioButton()
        Me.DGV_ListaClientesModificados = New System.Windows.Forms.DataGridView()
        Me.btn_limpiar = New System.Windows.Forms.Button()
        Me.DTP_FIN = New System.Windows.Forms.DateTimePicker()
        Me.DTP_INI = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTB_AGENTE = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CheckBox_Aprovados = New System.Windows.Forms.CheckBox()
        Me.Cbx_BuscaXFecha = New System.Windows.Forms.CheckBox()
        CType(Me.DGV_ListaClientesModificados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "ESTADO"
        '
        'CBX_Estado
        '
        Me.CBX_Estado.FormattingEnabled = True
        Me.CBX_Estado.Items.AddRange(New Object() {"Nuevo", "Cerrar", "Modificado", "Interno"})
        Me.CBX_Estado.Location = New System.Drawing.Point(85, 10)
        Me.CBX_Estado.Name = "CBX_Estado"
        Me.CBX_Estado.Size = New System.Drawing.Size(200, 21)
        Me.CBX_Estado.TabIndex = 3
        Me.CBX_Estado.Text = "Modificado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(297, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "BUSCAR"
        '
        'txtb_buscar
        '
        Me.txtb_buscar.Location = New System.Drawing.Point(359, 11)
        Me.txtb_buscar.Name = "txtb_buscar"
        Me.txtb_buscar.Size = New System.Drawing.Size(323, 20)
        Me.txtb_buscar.TabIndex = 5
        '
        'rb_Codigo
        '
        Me.rb_Codigo.AutoSize = True
        Me.rb_Codigo.Checked = True
        Me.rb_Codigo.Location = New System.Drawing.Point(688, 11)
        Me.rb_Codigo.Name = "rb_Codigo"
        Me.rb_Codigo.Size = New System.Drawing.Size(64, 19)
        Me.rb_Codigo.TabIndex = 6
        Me.rb_Codigo.TabStop = True
        Me.rb_Codigo.Text = "Codigo"
        Me.rb_Codigo.UseVisualStyleBackColor = True
        '
        'rb_nombre
        '
        Me.rb_nombre.AutoSize = True
        Me.rb_nombre.Location = New System.Drawing.Point(758, 11)
        Me.rb_nombre.Name = "rb_nombre"
        Me.rb_nombre.Size = New System.Drawing.Size(70, 19)
        Me.rb_nombre.TabIndex = 7
        Me.rb_nombre.TabStop = True
        Me.rb_nombre.Text = "Nombre"
        Me.rb_nombre.UseVisualStyleBackColor = True
        '
        'DGV_ListaClientesModificados
        '
        Me.DGV_ListaClientesModificados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_ListaClientesModificados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ListaClientesModificados.Location = New System.Drawing.Point(3, 64)
        Me.DGV_ListaClientesModificados.Name = "DGV_ListaClientesModificados"
        Me.DGV_ListaClientesModificados.Size = New System.Drawing.Size(908, 433)
        Me.DGV_ListaClientesModificados.TabIndex = 0
        '
        'btn_limpiar
        '
        Me.btn_limpiar.Location = New System.Drawing.Point(834, 8)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(75, 23)
        Me.btn_limpiar.TabIndex = 8
        Me.btn_limpiar.Text = "Limpiar"
        Me.btn_limpiar.UseVisualStyleBackColor = True
        '
        'DTP_FIN
        '
        Me.DTP_FIN.Enabled = False
        Me.DTP_FIN.Location = New System.Drawing.Point(359, 37)
        Me.DTP_FIN.Name = "DTP_FIN"
        Me.DTP_FIN.Size = New System.Drawing.Size(200, 20)
        Me.DTP_FIN.TabIndex = 9
        '
        'DTP_INI
        '
        Me.DTP_INI.Enabled = False
        Me.DTP_INI.Location = New System.Drawing.Point(85, 38)
        Me.DTP_INI.Name = "DTP_INI"
        Me.DTP_INI.Size = New System.Drawing.Size(200, 20)
        Me.DTP_INI.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 15)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "DESDE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(297, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "HASTA"
        '
        'TXTB_AGENTE
        '
        Me.TXTB_AGENTE.Location = New System.Drawing.Point(758, 36)
        Me.TXTB_AGENTE.Name = "TXTB_AGENTE"
        Me.TXTB_AGENTE.Size = New System.Drawing.Size(56, 20)
        Me.TXTB_AGENTE.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(696, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 15)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "AGENTE"
        '
        'CheckBox_Aprovados
        '
        Me.CheckBox_Aprovados.AutoSize = True
        Me.CheckBox_Aprovados.Location = New System.Drawing.Point(824, 36)
        Me.CheckBox_Aprovados.Name = "CheckBox_Aprovados"
        Me.CheckBox_Aprovados.Size = New System.Drawing.Size(85, 19)
        Me.CheckBox_Aprovados.TabIndex = 15
        Me.CheckBox_Aprovados.Text = "Aprobados"
        Me.CheckBox_Aprovados.UseVisualStyleBackColor = True
        '
        'Cbx_BuscaXFecha
        '
        Me.Cbx_BuscaXFecha.AutoSize = True
        Me.Cbx_BuscaXFecha.Location = New System.Drawing.Point(577, 38)
        Me.Cbx_BuscaXFecha.Name = "Cbx_BuscaXFecha"
        Me.Cbx_BuscaXFecha.Size = New System.Drawing.Size(102, 19)
        Me.Cbx_BuscaXFecha.TabIndex = 16
        Me.Cbx_BuscaXFecha.Text = "BuscaXFecha"
        Me.Cbx_BuscaXFecha.UseVisualStyleBackColor = True
        '
        'Lista_ClientesModificados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 500)
        Me.Controls.Add(Me.Cbx_BuscaXFecha)
        Me.Controls.Add(Me.CheckBox_Aprovados)
        Me.Controls.Add(Me.TXTB_AGENTE)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DTP_INI)
        Me.Controls.Add(Me.DTP_FIN)
        Me.Controls.Add(Me.btn_limpiar)
        Me.Controls.Add(Me.rb_nombre)
        Me.Controls.Add(Me.rb_Codigo)
        Me.Controls.Add(Me.txtb_buscar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CBX_Estado)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGV_ListaClientesModificados)
        Me.Name = "Lista_ClientesModificados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista_ClientesModificados"
        CType(Me.DGV_ListaClientesModificados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBX_Estado As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtb_buscar As System.Windows.Forms.TextBox
    Friend WithEvents rb_Codigo As System.Windows.Forms.RadioButton
    Friend WithEvents rb_nombre As System.Windows.Forms.RadioButton
    Friend WithEvents DGV_ListaClientesModificados As System.Windows.Forms.DataGridView
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents DTP_FIN As DateTimePicker
    Friend WithEvents DTP_INI As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTB_AGENTE As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents CheckBox_Aprovados As CheckBox
    Friend WithEvents Cbx_BuscaXFecha As CheckBox
End Class
