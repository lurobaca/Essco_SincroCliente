<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pedido_RangoFechaOrdComp
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
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RdBtb_Unidades = New System.Windows.Forms.RadioButton()
        Me.RdBtb_Cajas = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DTP_ProyeccionFin = New System.Windows.Forms.DateTimePicker()
        Me.DTP_ProyeccionIni = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Progreso = New System.Windows.Forms.ProgressBar()
        Me.lbl_InicioProcesa = New System.Windows.Forms.Label()
        Me.lbl_FinProcesa = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(136, 49)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(265, 22)
        Me.DateTimePicker1.TabIndex = 0
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(136, 81)
        Me.DateTimePicker2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(265, 22)
        Me.DateTimePicker2.TabIndex = 1
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Aceptar.Location = New System.Drawing.Point(22, 125)
        Me.btn_Aceptar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(381, 58)
        Me.btn_Aceptar.TabIndex = 2
        Me.btn_Aceptar.Text = "Generar"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 49)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 25)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Inicio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 81)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 25)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fin"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(131, 11)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 25)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Fecha Venta"
        '
        'RdBtb_Unidades
        '
        Me.RdBtb_Unidades.AutoSize = True
        Me.RdBtb_Unidades.Checked = True
        Me.RdBtb_Unidades.Location = New System.Drawing.Point(444, 23)
        Me.RdBtb_Unidades.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RdBtb_Unidades.Name = "RdBtb_Unidades"
        Me.RdBtb_Unidades.Size = New System.Drawing.Size(89, 21)
        Me.RdBtb_Unidades.TabIndex = 107
        Me.RdBtb_Unidades.TabStop = True
        Me.RdBtb_Unidades.Text = "Unidades"
        Me.RdBtb_Unidades.UseVisualStyleBackColor = True
        '
        'RdBtb_Cajas
        '
        Me.RdBtb_Cajas.AutoSize = True
        Me.RdBtb_Cajas.Location = New System.Drawing.Point(265, 23)
        Me.RdBtb_Cajas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RdBtb_Cajas.Name = "RdBtb_Cajas"
        Me.RdBtb_Cajas.Size = New System.Drawing.Size(64, 21)
        Me.RdBtb_Cajas.TabIndex = 106
        Me.RdBtb_Cajas.Text = "Cajas"
        Me.RdBtb_Cajas.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RdBtb_Unidades)
        Me.GroupBox1.Controls.Add(Me.RdBtb_Cajas)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 267)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(711, 55)
        Me.GroupBox1.TabIndex = 108
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pedido en"
        Me.GroupBox1.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(704, 31)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(153, 25)
        Me.Label4.TabIndex = 112
        Me.Label4.Text = "Periodo a Cubrir"
        Me.Label4.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(590, 69)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 25)
        Me.Label5.TabIndex = 111
        Me.Label5.Text = "Inicio"
        Me.Label5.Visible = False
        '
        'DTP_ProyeccionFin
        '
        Me.DTP_ProyeccionFin.Location = New System.Drawing.Point(670, 101)
        Me.DTP_ProyeccionFin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DTP_ProyeccionFin.Name = "DTP_ProyeccionFin"
        Me.DTP_ProyeccionFin.Size = New System.Drawing.Size(265, 22)
        Me.DTP_ProyeccionFin.TabIndex = 110
        Me.DTP_ProyeccionFin.Visible = False
        '
        'DTP_ProyeccionIni
        '
        Me.DTP_ProyeccionIni.Location = New System.Drawing.Point(670, 69)
        Me.DTP_ProyeccionIni.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DTP_ProyeccionIni.Name = "DTP_ProyeccionIni"
        Me.DTP_ProyeccionIni.Size = New System.Drawing.Size(265, 22)
        Me.DTP_ProyeccionIni.TabIndex = 109
        Me.DTP_ProyeccionIni.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(590, 102)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 25)
        Me.Label6.TabIndex = 113
        Me.Label6.Text = "Fin"
        Me.Label6.Visible = False
        '
        'Progreso
        '
        Me.Progreso.Location = New System.Drawing.Point(21, 241)
        Me.Progreso.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Progreso.Name = "Progreso"
        Me.Progreso.Size = New System.Drawing.Size(382, 20)
        Me.Progreso.TabIndex = 114
        '
        'lbl_InicioProcesa
        '
        Me.lbl_InicioProcesa.AutoSize = True
        Me.lbl_InicioProcesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_InicioProcesa.Location = New System.Drawing.Point(17, 199)
        Me.lbl_InicioProcesa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_InicioProcesa.Name = "lbl_InicioProcesa"
        Me.lbl_InicioProcesa.Size = New System.Drawing.Size(57, 25)
        Me.lbl_InicioProcesa.TabIndex = 115
        Me.lbl_InicioProcesa.Text = "Inicio"
        '
        'lbl_FinProcesa
        '
        Me.lbl_FinProcesa.AutoSize = True
        Me.lbl_FinProcesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_FinProcesa.Location = New System.Drawing.Point(364, 199)
        Me.lbl_FinProcesa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_FinProcesa.Name = "lbl_FinProcesa"
        Me.lbl_FinProcesa.Size = New System.Drawing.Size(39, 25)
        Me.lbl_FinProcesa.TabIndex = 116
        Me.lbl_FinProcesa.Text = "Fin"
        '
        'Pedido_RangoFechaOrdComp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 267)
        Me.Controls.Add(Me.lbl_FinProcesa)
        Me.Controls.Add(Me.lbl_InicioProcesa)
        Me.Controls.Add(Me.Progreso)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DTP_ProyeccionFin)
        Me.Controls.Add(Me.DTP_ProyeccionIni)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Pedido_RangoFechaOrdComp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fecha de Venta"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RdBtb_Unidades As System.Windows.Forms.RadioButton
    Friend WithEvents RdBtb_Cajas As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DTP_ProyeccionFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_ProyeccionIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Progreso As ProgressBar
    Friend WithEvents lbl_InicioProcesa As Label
    Friend WithEvents lbl_FinProcesa As Label
End Class
