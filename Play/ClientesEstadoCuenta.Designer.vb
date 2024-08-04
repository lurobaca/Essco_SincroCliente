<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ClientesEstadoCuenta
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
        Me.DGV_EstadoCuenta = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTP_INI = New System.Windows.Forms.DateTimePicker()
        Me.DTP_FIN = New System.Windows.Forms.DateTimePicker()
        Me.Btn_Buscar = New System.Windows.Forms.Button()
        Me.CBox_Estado = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DGV_EstadoCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_EstadoCuenta
        '
        Me.DGV_EstadoCuenta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_EstadoCuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_EstadoCuenta.Location = New System.Drawing.Point(12, 91)
        Me.DGV_EstadoCuenta.Name = "DGV_EstadoCuenta"
        Me.DGV_EstadoCuenta.RowTemplate.Height = 24
        Me.DGV_EstadoCuenta.Size = New System.Drawing.Size(776, 347)
        Me.DGV_EstadoCuenta.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 48)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 17)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Hasta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 18)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 17)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Desde"
        '
        'DTP_INI
        '
        Me.DTP_INI.Location = New System.Drawing.Point(69, 13)
        Me.DTP_INI.Margin = New System.Windows.Forms.Padding(4)
        Me.DTP_INI.Name = "DTP_INI"
        Me.DTP_INI.Size = New System.Drawing.Size(265, 22)
        Me.DTP_INI.TabIndex = 14
        '
        'DTP_FIN
        '
        Me.DTP_FIN.Location = New System.Drawing.Point(69, 43)
        Me.DTP_FIN.Margin = New System.Windows.Forms.Padding(4)
        Me.DTP_FIN.Name = "DTP_FIN"
        Me.DTP_FIN.Size = New System.Drawing.Size(265, 22)
        Me.DTP_FIN.TabIndex = 13
        '
        'Btn_Buscar
        '
        Me.Btn_Buscar.Location = New System.Drawing.Point(691, 8)
        Me.Btn_Buscar.Name = "Btn_Buscar"
        Me.Btn_Buscar.Size = New System.Drawing.Size(97, 37)
        Me.Btn_Buscar.TabIndex = 17
        Me.Btn_Buscar.Text = "Buscar"
        Me.Btn_Buscar.UseVisualStyleBackColor = True
        '
        'CBox_Estado
        '
        Me.CBox_Estado.FormattingEnabled = True
        Me.CBox_Estado.Items.AddRange(New Object() {"Todos", "Cancelados", "Pendientes"})
        Me.CBox_Estado.Location = New System.Drawing.Point(427, 11)
        Me.CBox_Estado.Name = "CBox_Estado"
        Me.CBox_Estado.Size = New System.Drawing.Size(121, 24)
        Me.CBox_Estado.TabIndex = 18
        Me.CBox_Estado.Text = "Pendientes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(342, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Estado"
        '
        'ClientesEstadoCuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CBox_Estado)
        Me.Controls.Add(Me.Btn_Buscar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DTP_INI)
        Me.Controls.Add(Me.DTP_FIN)
        Me.Controls.Add(Me.DGV_EstadoCuenta)
        Me.Name = "ClientesEstadoCuenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ClientesEstadoCuenta"
        CType(Me.DGV_EstadoCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGV_EstadoCuenta As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DTP_INI As DateTimePicker
    Friend WithEvents DTP_FIN As DateTimePicker
    Friend WithEvents Btn_Buscar As Button
    Friend WithEvents CBox_Estado As ComboBox
    Friend WithEvents Label1 As Label
End Class
