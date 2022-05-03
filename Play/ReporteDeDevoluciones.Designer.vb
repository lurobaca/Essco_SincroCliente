<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteDeDevoluciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteDeDevoluciones))
        Me.DataDV_RepDev = New System.Windows.Forms.DataGridView()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.BTN_Limpia = New System.Windows.Forms.Button()
        Me.Lbl_Detalle = New System.Windows.Forms.Label()
        Me.Progress_RepDevo = New System.Windows.Forms.ProgressBar()
        Me.BTN_Generar = New System.Windows.Forms.Button()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.BTN_Busca = New System.Windows.Forms.Button()
        Me.TXTB_INI = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.TXTB_FIN = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_Corregido = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Btn_Atras = New System.Windows.Forms.Button()
        Me.Btn_Adelante = New System.Windows.Forms.Button()
        Me.btn_eliminar = New System.Windows.Forms.Button()
        Me.Lbl_Anulado = New System.Windows.Forms.Label()
        Me.txb_Numero = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txtb_Hasta = New System.Windows.Forms.TextBox()
        Me.Txtb_Desde = New System.Windows.Forms.TextBox()
        Me.Brn_Genera = New System.Windows.Forms.Button()
        Me.btn_Corregir = New System.Windows.Forms.Button()
        Me.btn_Nuevo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Dgt_RepDevoluciones = New System.Windows.Forms.DataGridView()
        CType(Me.DataDV_RepDev, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Dgt_RepDevoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataDV_RepDev
        '
        Me.DataDV_RepDev.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataDV_RepDev.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDV_RepDev.Location = New System.Drawing.Point(3, 74)
        Me.DataDV_RepDev.Name = "DataDV_RepDev"
        Me.DataDV_RepDev.Size = New System.Drawing.Size(1246, 366)
        Me.DataDV_RepDev.TabIndex = 8
        '
        'Panel8
        '
        Me.Panel8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel8.Controls.Add(Me.BTN_Limpia)
        Me.Panel8.Controls.Add(Me.Lbl_Detalle)
        Me.Panel8.Controls.Add(Me.Progress_RepDevo)
        Me.Panel8.Controls.Add(Me.BTN_Generar)
        Me.Panel8.Controls.Add(Me.Label32)
        Me.Panel8.Controls.Add(Me.BTN_Busca)
        Me.Panel8.Controls.Add(Me.TXTB_INI)
        Me.Panel8.Controls.Add(Me.Label33)
        Me.Panel8.Controls.Add(Me.TXTB_FIN)
        Me.Panel8.Location = New System.Drawing.Point(2, 6)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1249, 68)
        Me.Panel8.TabIndex = 7
        '
        'BTN_Limpia
        '
        Me.BTN_Limpia.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Limpia.Location = New System.Drawing.Point(697, 6)
        Me.BTN_Limpia.Name = "BTN_Limpia"
        Me.BTN_Limpia.Size = New System.Drawing.Size(107, 33)
        Me.BTN_Limpia.TabIndex = 19
        Me.BTN_Limpia.Text = "Limpiar"
        Me.BTN_Limpia.UseVisualStyleBackColor = True
        '
        'Lbl_Detalle
        '
        Me.Lbl_Detalle.AutoSize = True
        Me.Lbl_Detalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Detalle.Location = New System.Drawing.Point(475, 45)
        Me.Lbl_Detalle.Name = "Lbl_Detalle"
        Me.Lbl_Detalle.Size = New System.Drawing.Size(191, 18)
        Me.Lbl_Detalle.TabIndex = 18
        Me.Lbl_Detalle.Text = "Detalle del avance Sectores"
        '
        'Progress_RepDevo
        '
        Me.Progress_RepDevo.Location = New System.Drawing.Point(10, 39)
        Me.Progress_RepDevo.Name = "Progress_RepDevo"
        Me.Progress_RepDevo.Size = New System.Drawing.Size(453, 23)
        Me.Progress_RepDevo.TabIndex = 17
        '
        'BTN_Generar
        '
        Me.BTN_Generar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Generar.Location = New System.Drawing.Point(10, 10)
        Me.BTN_Generar.Name = "BTN_Generar"
        Me.BTN_Generar.Size = New System.Drawing.Size(10, 10)
        Me.BTN_Generar.TabIndex = 6
        Me.BTN_Generar.Text = "Generar"
        Me.BTN_Generar.UseVisualStyleBackColor = True
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(7, 14)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(55, 17)
        Me.Label32.TabIndex = 3
        Me.Label32.Text = "DESDE"
        '
        'BTN_Busca
        '
        Me.BTN_Busca.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Busca.Location = New System.Drawing.Point(584, 6)
        Me.BTN_Busca.Name = "BTN_Busca"
        Me.BTN_Busca.Size = New System.Drawing.Size(107, 33)
        Me.BTN_Busca.TabIndex = 5
        Me.BTN_Busca.Text = "Buscar"
        Me.BTN_Busca.UseVisualStyleBackColor = True
        '
        'TXTB_INI
        '
        Me.TXTB_INI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTB_INI.Location = New System.Drawing.Point(68, 9)
        Me.TXTB_INI.Name = "TXTB_INI"
        Me.TXTB_INI.Size = New System.Drawing.Size(164, 23)
        Me.TXTB_INI.TabIndex = 1
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(238, 14)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(54, 17)
        Me.Label33.TabIndex = 4
        Me.Label33.Text = "HASTA"
        '
        'TXTB_FIN
        '
        Me.TXTB_FIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTB_FIN.Location = New System.Drawing.Point(298, 11)
        Me.TXTB_FIN.Name = "TXTB_FIN"
        Me.TXTB_FIN.Size = New System.Drawing.Size(164, 23)
        Me.TXTB_FIN.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.lbl_Corregido)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.Btn_Atras)
        Me.Panel1.Controls.Add(Me.Btn_Adelante)
        Me.Panel1.Controls.Add(Me.btn_eliminar)
        Me.Panel1.Controls.Add(Me.Lbl_Anulado)
        Me.Panel1.Controls.Add(Me.txb_Numero)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Txtb_Hasta)
        Me.Panel1.Controls.Add(Me.Txtb_Desde)
        Me.Panel1.Controls.Add(Me.Brn_Genera)
        Me.Panel1.Controls.Add(Me.btn_Corregir)
        Me.Panel1.Controls.Add(Me.btn_Nuevo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(4, -5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1107, 105)
        Me.Panel1.TabIndex = 8
        '
        'lbl_Corregido
        '
        Me.lbl_Corregido.AutoSize = True
        Me.lbl_Corregido.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Corregido.ForeColor = System.Drawing.Color.ForestGreen
        Me.lbl_Corregido.Location = New System.Drawing.Point(554, 68)
        Me.lbl_Corregido.Name = "lbl_Corregido"
        Me.lbl_Corregido.Size = New System.Drawing.Size(141, 25)
        Me.lbl_Corregido.TabIndex = 97
        Me.lbl_Corregido.Text = "CORREGIDO"
        Me.lbl_Corregido.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(402, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 17)
        Me.Label5.TabIndex = 96
        Me.Label5.Text = "Estado"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"TODO", "CORRECTO", "CAMBIADO", "TRASLADO"})
        Me.ComboBox1.Location = New System.Drawing.Point(373, 71)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 95
        '
        'Btn_Atras
        '
        Me.Btn_Atras.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Atras.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Atras.BackgroundImage = CType(resources.GetObject("Btn_Atras.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Atras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Atras.Location = New System.Drawing.Point(934, 21)
        Me.Btn_Atras.Name = "Btn_Atras"
        Me.Btn_Atras.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Atras.TabIndex = 93
        Me.Btn_Atras.UseVisualStyleBackColor = False
        '
        'Btn_Adelante
        '
        Me.Btn_Adelante.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Adelante.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Adelante.BackgroundImage = CType(resources.GetObject("Btn_Adelante.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Adelante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Adelante.Location = New System.Drawing.Point(1015, 20)
        Me.Btn_Adelante.Name = "Btn_Adelante"
        Me.Btn_Adelante.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Adelante.TabIndex = 92
        Me.Btn_Adelante.UseVisualStyleBackColor = False
        '
        'btn_eliminar
        '
        Me.btn_eliminar.BackColor = System.Drawing.Color.White
        Me.btn_eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_eliminar.ForeColor = System.Drawing.Color.Black
        Me.btn_eliminar.Image = CType(resources.GetObject("btn_eliminar.Image"), System.Drawing.Image)
        Me.btn_eliminar.Location = New System.Drawing.Point(591, 17)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(42, 39)
        Me.btn_eliminar.TabIndex = 94
        Me.btn_eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_eliminar.UseVisualStyleBackColor = False
        '
        'Lbl_Anulado
        '
        Me.Lbl_Anulado.AutoSize = True
        Me.Lbl_Anulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Anulado.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Anulado.Location = New System.Drawing.Point(554, 25)
        Me.Lbl_Anulado.Name = "Lbl_Anulado"
        Me.Lbl_Anulado.Size = New System.Drawing.Size(116, 25)
        Me.Lbl_Anulado.TabIndex = 91
        Me.Lbl_Anulado.Text = "ANULADO"
        Me.Lbl_Anulado.Visible = False
        '
        'txb_Numero
        '
        Me.txb_Numero.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txb_Numero.Location = New System.Drawing.Point(1008, 66)
        Me.txb_Numero.Name = "txb_Numero"
        Me.txb_Numero.Size = New System.Drawing.Size(82, 20)
        Me.txb_Numero.TabIndex = 24
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(931, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 17)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Numero"
        '
        'Txtb_Hasta
        '
        Me.Txtb_Hasta.Location = New System.Drawing.Point(69, 68)
        Me.Txtb_Hasta.Name = "Txtb_Hasta"
        Me.Txtb_Hasta.Size = New System.Drawing.Size(100, 20)
        Me.Txtb_Hasta.TabIndex = 1
        '
        'Txtb_Desde
        '
        Me.Txtb_Desde.Location = New System.Drawing.Point(69, 26)
        Me.Txtb_Desde.Name = "Txtb_Desde"
        Me.Txtb_Desde.Size = New System.Drawing.Size(100, 20)
        Me.Txtb_Desde.TabIndex = 0
        '
        'Brn_Genera
        '
        Me.Brn_Genera.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Brn_Genera.Location = New System.Drawing.Point(188, 18)
        Me.Brn_Genera.Name = "Brn_Genera"
        Me.Brn_Genera.Size = New System.Drawing.Size(80, 37)
        Me.Brn_Genera.TabIndex = 2
        Me.Brn_Genera.Text = "Generar"
        Me.Brn_Genera.UseVisualStyleBackColor = True
        '
        'btn_Corregir
        '
        Me.btn_Corregir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Corregir.Location = New System.Drawing.Point(287, 61)
        Me.btn_Corregir.Name = "btn_Corregir"
        Me.btn_Corregir.Size = New System.Drawing.Size(80, 37)
        Me.btn_Corregir.TabIndex = 19
        Me.btn_Corregir.Text = "Corregir"
        Me.btn_Corregir.UseVisualStyleBackColor = True
        '
        'btn_Nuevo
        '
        Me.btn_Nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Nuevo.Location = New System.Drawing.Point(287, 18)
        Me.btn_Nuevo.Name = "btn_Nuevo"
        Me.btn_Nuevo.Size = New System.Drawing.Size(80, 37)
        Me.btn_Nuevo.TabIndex = 19
        Me.btn_Nuevo.Text = "Nuevo"
        Me.btn_Nuevo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(236, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 18)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "0"
        Me.Label1.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 5)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(1104, 11)
        Me.ProgressBar1.TabIndex = 17
        Me.ProgressBar1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "DESDE"
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(189, 61)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 37)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Buscar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "HASTA"
        '
        'Dgt_RepDevoluciones
        '
        Me.Dgt_RepDevoluciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgt_RepDevoluciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgt_RepDevoluciones.Location = New System.Drawing.Point(4, 96)
        Me.Dgt_RepDevoluciones.Name = "Dgt_RepDevoluciones"
        Me.Dgt_RepDevoluciones.Size = New System.Drawing.Size(1107, 506)
        Me.Dgt_RepDevoluciones.TabIndex = 9
        '
        'ReporteDeDevoluciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1106, 600)
        Me.Controls.Add(Me.Dgt_RepDevoluciones)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ReporteDeDevoluciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ReporteDeDevoluciones"
        CType(Me.DataDV_RepDev, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Dgt_RepDevoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataDV_RepDev As System.Windows.Forms.DataGridView
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents BTN_Limpia As System.Windows.Forms.Button
    Friend WithEvents Lbl_Detalle As System.Windows.Forms.Label
    Friend WithEvents Progress_RepDevo As System.Windows.Forms.ProgressBar
    Friend WithEvents BTN_Generar As System.Windows.Forms.Button
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents BTN_Busca As System.Windows.Forms.Button
    Friend WithEvents TXTB_INI As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents TXTB_FIN As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Brn_Genera As System.Windows.Forms.Button
    Friend WithEvents Txtb_Hasta As System.Windows.Forms.TextBox
    Friend WithEvents Txtb_Desde As System.Windows.Forms.TextBox
    Friend WithEvents Dgt_RepDevoluciones As System.Windows.Forms.DataGridView
    Friend WithEvents txb_Numero As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Btn_Atras As System.Windows.Forms.Button
    Friend WithEvents Btn_Adelante As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents Lbl_Anulado As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Corregir As System.Windows.Forms.Button
    Friend WithEvents lbl_Corregido As System.Windows.Forms.Label
End Class
