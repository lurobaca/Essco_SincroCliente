<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Math_Hacienda
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Dtp_Fin = New System.Windows.Forms.DateTimePicker()
        Me.Dtp_Ini = New System.Windows.Forms.DateTimePicker()
        Me.btn_ConsultaRegHacienda = New System.Windows.Forms.Button()
        Me.DataGV_Comprobantes = New System.Windows.Forms.DataGridView()
        Me.txbt_Total = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtb_offset = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtb_limit = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtb_CedEmisor = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CBox_Ver = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.DataGV_Comprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(739, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 15)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Hasta"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(735, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 15)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Desde"
        '
        'Dtp_Fin
        '
        Me.Dtp_Fin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dtp_Fin.Location = New System.Drawing.Point(784, 31)
        Me.Dtp_Fin.Name = "Dtp_Fin"
        Me.Dtp_Fin.Size = New System.Drawing.Size(200, 20)
        Me.Dtp_Fin.TabIndex = 26
        '
        'Dtp_Ini
        '
        Me.Dtp_Ini.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dtp_Ini.Location = New System.Drawing.Point(784, 9)
        Me.Dtp_Ini.Name = "Dtp_Ini"
        Me.Dtp_Ini.Size = New System.Drawing.Size(200, 20)
        Me.Dtp_Ini.TabIndex = 25
        '
        'btn_ConsultaRegHacienda
        '
        Me.btn_ConsultaRegHacienda.Location = New System.Drawing.Point(392, 11)
        Me.btn_ConsultaRegHacienda.Name = "btn_ConsultaRegHacienda"
        Me.btn_ConsultaRegHacienda.Size = New System.Drawing.Size(126, 43)
        Me.btn_ConsultaRegHacienda.TabIndex = 29
        Me.btn_ConsultaRegHacienda.Text = "Consultar Registros en Hacienda"
        Me.btn_ConsultaRegHacienda.UseVisualStyleBackColor = True
        '
        'DataGV_Comprobantes
        '
        Me.DataGV_Comprobantes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGV_Comprobantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGV_Comprobantes.Location = New System.Drawing.Point(4, 63)
        Me.DataGV_Comprobantes.Name = "DataGV_Comprobantes"
        Me.DataGV_Comprobantes.Size = New System.Drawing.Size(980, 355)
        Me.DataGV_Comprobantes.TabIndex = 30
        '
        'txbt_Total
        '
        Me.txbt_Total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbt_Total.Location = New System.Drawing.Point(757, 425)
        Me.txbt_Total.Name = "txbt_Total"
        Me.txbt_Total.Size = New System.Drawing.Size(227, 20)
        Me.txbt_Total.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(696, 428)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 15)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "TOTAL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 15)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Desde el Registro"
        '
        'txtb_offset
        '
        Me.txtb_offset.Location = New System.Drawing.Point(123, 11)
        Me.txtb_offset.Name = "txtb_offset"
        Me.txtb_offset.Size = New System.Drawing.Size(66, 20)
        Me.txtb_offset.TabIndex = 33
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(195, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 15)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Cantidad a consultar"
        '
        'txtb_limit
        '
        Me.txtb_limit.Location = New System.Drawing.Point(320, 12)
        Me.txtb_limit.Name = "txtb_limit"
        Me.txtb_limit.Size = New System.Drawing.Size(66, 20)
        Me.txtb_limit.TabIndex = 35
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 15)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Cedula Emisor"
        '
        'txtb_CedEmisor
        '
        Me.txtb_CedEmisor.Enabled = False
        Me.txtb_CedEmisor.Location = New System.Drawing.Point(123, 34)
        Me.txtb_CedEmisor.Name = "txtb_CedEmisor"
        Me.txtb_CedEmisor.Size = New System.Drawing.Size(263, 20)
        Me.txtb_CedEmisor.TabIndex = 37
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(638, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(91, 43)
        Me.Button2.TabIndex = 39
        Me.Button2.Text = "MATCH"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CBox_Ver
        '
        Me.CBox_Ver.FormattingEnabled = True
        Me.CBox_Ver.Items.AddRange(New Object() {"Todos", "No estan en hacienda"})
        Me.CBox_Ver.Location = New System.Drawing.Point(524, 30)
        Me.CBox_Ver.Name = "CBox_Ver"
        Me.CBox_Ver.Size = New System.Drawing.Size(108, 21)
        Me.CBox_Ver.TabIndex = 40
        Me.CBox_Ver.Text = "Todos"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(521, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 15)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Ver Comprobantes"
        '
        'Math_Hacienda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 450)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CBox_Ver)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtb_CedEmisor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtb_limit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtb_offset)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txbt_Total)
        Me.Controls.Add(Me.DataGV_Comprobantes)
        Me.Controls.Add(Me.btn_ConsultaRegHacienda)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Dtp_Fin)
        Me.Controls.Add(Me.Dtp_Ini)
        Me.Name = "Math_Hacienda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Math_Hacienda"
        CType(Me.DataGV_Comprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Dtp_Fin As DateTimePicker
    Friend WithEvents Dtp_Ini As DateTimePicker
    Friend WithEvents btn_ConsultaRegHacienda As Button
    Friend WithEvents DataGV_Comprobantes As DataGridView
    Friend WithEvents txbt_Total As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtb_offset As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtb_limit As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtb_CedEmisor As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents CBox_Ver As ComboBox
    Friend WithEvents Label7 As Label
End Class
