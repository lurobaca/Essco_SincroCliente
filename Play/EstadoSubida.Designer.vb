﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstadoSubida
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstadoSubida))
        Me.DGV_EstadoSubida = New System.Windows.Forms.DataGridView()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Archivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.BTN_LocalFtp = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btn_RecargaTodos = New System.Windows.Forms.Button()
        Me.btn_RecargSubir = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LbL_AgEjecucion = New System.Windows.Forms.Label()
        Me.btn_subir = New System.Windows.Forms.Button()
        Me.txt_SoloAg = New System.Windows.Forms.TextBox()
        Me.Lbl_Procesando = New System.Windows.Forms.TextBox()
        Me.Timer_AGEjecucion = New System.Windows.Forms.Timer(Me.components)
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBox_Archivo = New System.Windows.Forms.ComboBox()
        Me.btn_LimpSubidos = New System.Windows.Forms.Button()
        Me.btn_LimpError = New System.Windows.Forms.Button()
        Me.btn_Todos = New System.Windows.Forms.Button()
        Me.btn_Errores = New System.Windows.Forms.Button()
        Me.btn_Subido = New System.Windows.Forms.Button()
        CType(Me.DGV_EstadoSubida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGV_EstadoSubida
        '
        Me.DGV_EstadoSubida.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_EstadoSubida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_EstadoSubida.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.Archivo})
        Me.DGV_EstadoSubida.Location = New System.Drawing.Point(16, 58)
        Me.DGV_EstadoSubida.Margin = New System.Windows.Forms.Padding(4)
        Me.DGV_EstadoSubida.Name = "DGV_EstadoSubida"
        Me.DGV_EstadoSubida.Size = New System.Drawing.Size(1544, 727)
        Me.DGV_EstadoSubida.TabIndex = 1
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        '
        'Archivo
        '
        Me.Archivo.DataPropertyName = "Archivo"
        Me.Archivo.HeaderText = "Archivo"
        Me.Archivo.Name = "Archivo"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(1086, 13)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 37)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Nube"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Red
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.SystemColors.Control
        Me.Button5.Location = New System.Drawing.Point(1315, 13)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(208, 37)
        Me.Button5.TabIndex = 19
        Me.Button5.Text = "HOY BLOQUEADO"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'BTN_LocalFtp
        '
        Me.BTN_LocalFtp.BackColor = System.Drawing.Color.Green
        Me.BTN_LocalFtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_LocalFtp.ForeColor = System.Drawing.SystemColors.Control
        Me.BTN_LocalFtp.Location = New System.Drawing.Point(1194, 13)
        Me.BTN_LocalFtp.Margin = New System.Windows.Forms.Padding(4)
        Me.BTN_LocalFtp.Name = "BTN_LocalFtp"
        Me.BTN_LocalFtp.Size = New System.Drawing.Size(100, 37)
        Me.BTN_LocalFtp.TabIndex = 18
        Me.BTN_LocalFtp.Text = "FTP"
        Me.BTN_LocalFtp.UseVisualStyleBackColor = False
        '
        'Panel7
        '
        Me.Panel7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel7.Controls.Add(Me.btn_RecargaTodos)
        Me.Panel7.Controls.Add(Me.btn_RecargSubir)
        Me.Panel7.Controls.Add(Me.Label4)
        Me.Panel7.Controls.Add(Me.LbL_AgEjecucion)
        Me.Panel7.Controls.Add(Me.btn_subir)
        Me.Panel7.Controls.Add(Me.txt_SoloAg)
        Me.Panel7.Location = New System.Drawing.Point(728, 793)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(843, 62)
        Me.Panel7.TabIndex = 18
        '
        'btn_RecargaTodos
        '
        Me.btn_RecargaTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_RecargaTodos.Location = New System.Drawing.Point(571, 11)
        Me.btn_RecargaTodos.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_RecargaTodos.Name = "btn_RecargaTodos"
        Me.btn_RecargaTodos.Size = New System.Drawing.Size(168, 39)
        Me.btn_RecargaTodos.TabIndex = 19
        Me.btn_RecargaTodos.Text = "Recargar Todos"
        Me.btn_RecargaTodos.UseVisualStyleBackColor = True
        '
        'btn_RecargSubir
        '
        Me.btn_RecargSubir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_RecargSubir.Location = New System.Drawing.Point(220, 11)
        Me.btn_RecargSubir.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_RecargSubir.Name = "btn_RecargSubir"
        Me.btn_RecargSubir.Size = New System.Drawing.Size(168, 39)
        Me.btn_RecargSubir.TabIndex = 17
        Me.btn_RecargSubir.Text = "Recargar y Subir"
        Me.btn_RecargSubir.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 23)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 20)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "#Agente"
        '
        'LbL_AgEjecucion
        '
        Me.LbL_AgEjecucion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LbL_AgEjecucion.AutoSize = True
        Me.LbL_AgEjecucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbL_AgEjecucion.Location = New System.Drawing.Point(747, 7)
        Me.LbL_AgEjecucion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LbL_AgEjecucion.Name = "LbL_AgEjecucion"
        Me.LbL_AgEjecucion.Size = New System.Drawing.Size(78, 39)
        Me.LbL_AgEjecucion.TabIndex = 10
        Me.LbL_AgEjecucion.Text = "#Ag"
        '
        'btn_subir
        '
        Me.btn_subir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_subir.Location = New System.Drawing.Point(396, 11)
        Me.btn_subir.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_subir.Name = "btn_subir"
        Me.btn_subir.Size = New System.Drawing.Size(168, 39)
        Me.btn_subir.TabIndex = 11
        Me.btn_subir.Text = "Solo Subir"
        Me.btn_subir.UseVisualStyleBackColor = True
        '
        'txt_SoloAg
        '
        Me.txt_SoloAg.Location = New System.Drawing.Point(101, 23)
        Me.txt_SoloAg.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_SoloAg.Name = "txt_SoloAg"
        Me.txt_SoloAg.Size = New System.Drawing.Size(109, 22)
        Me.txt_SoloAg.TabIndex = 15
        '
        'Lbl_Procesando
        '
        Me.Lbl_Procesando.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Procesando.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Procesando.Location = New System.Drawing.Point(16, 818)
        Me.Lbl_Procesando.Margin = New System.Windows.Forms.Padding(4)
        Me.Lbl_Procesando.Name = "Lbl_Procesando"
        Me.Lbl_Procesando.Size = New System.Drawing.Size(702, 23)
        Me.Lbl_Procesando.TabIndex = 18
        '
        'Timer_AGEjecucion
        '
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(-60, -83)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(120, 89)
        Me.CheckedListBox1.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 17)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Archivo"
        '
        'CBox_Archivo
        '
        Me.CBox_Archivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.980198!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBox_Archivo.FormattingEnabled = True
        Me.CBox_Archivo.Items.AddRange(New Object() {"Todos", "Pedidos", "Devoluciones", "Pagos"})
        Me.CBox_Archivo.Location = New System.Drawing.Point(95, 13)
        Me.CBox_Archivo.Margin = New System.Windows.Forms.Padding(4)
        Me.CBox_Archivo.Name = "CBox_Archivo"
        Me.CBox_Archivo.Size = New System.Drawing.Size(209, 28)
        Me.CBox_Archivo.TabIndex = 110
        Me.CBox_Archivo.Text = "Todos"
        '
        'btn_LimpSubidos
        '
        Me.btn_LimpSubidos.Location = New System.Drawing.Point(932, 12)
        Me.btn_LimpSubidos.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_LimpSubidos.Name = "btn_LimpSubidos"
        Me.btn_LimpSubidos.Size = New System.Drawing.Size(143, 31)
        Me.btn_LimpSubidos.TabIndex = 108
        Me.btn_LimpSubidos.Text = "Limpiar Subidos"
        Me.btn_LimpSubidos.UseVisualStyleBackColor = True
        '
        'btn_LimpError
        '
        Me.btn_LimpError.Location = New System.Drawing.Point(630, 12)
        Me.btn_LimpError.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_LimpError.Name = "btn_LimpError"
        Me.btn_LimpError.Size = New System.Drawing.Size(143, 31)
        Me.btn_LimpError.TabIndex = 109
        Me.btn_LimpError.Text = "Limpiar Errores"
        Me.btn_LimpError.UseVisualStyleBackColor = True
        '
        'btn_Todos
        '
        Me.btn_Todos.Location = New System.Drawing.Point(319, 12)
        Me.btn_Todos.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Todos.Name = "btn_Todos"
        Me.btn_Todos.Size = New System.Drawing.Size(143, 31)
        Me.btn_Todos.TabIndex = 105
        Me.btn_Todos.Text = "Todos "
        Me.btn_Todos.UseVisualStyleBackColor = True
        '
        'btn_Errores
        '
        Me.btn_Errores.Location = New System.Drawing.Point(479, 12)
        Me.btn_Errores.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Errores.Name = "btn_Errores"
        Me.btn_Errores.Size = New System.Drawing.Size(143, 31)
        Me.btn_Errores.TabIndex = 106
        Me.btn_Errores.Text = "Errores"
        Me.btn_Errores.UseVisualStyleBackColor = True
        '
        'btn_Subido
        '
        Me.btn_Subido.Location = New System.Drawing.Point(781, 12)
        Me.btn_Subido.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Subido.Name = "btn_Subido"
        Me.btn_Subido.Size = New System.Drawing.Size(143, 31)
        Me.btn_Subido.TabIndex = 107
        Me.btn_Subido.Text = "Subidos"
        Me.btn_Subido.UseVisualStyleBackColor = True
        '
        'EstadoSubida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1573, 854)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CBox_Archivo)
        Me.Controls.Add(Me.btn_LimpSubidos)
        Me.Controls.Add(Me.btn_LimpError)
        Me.Controls.Add(Me.btn_Todos)
        Me.Controls.Add(Me.btn_Errores)
        Me.Controls.Add(Me.btn_Subido)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.BTN_LocalFtp)
        Me.Controls.Add(Me.Lbl_Procesando)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.DGV_EstadoSubida)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "EstadoSubida"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EstadoSubida"
        CType(Me.DGV_EstadoSubida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV_EstadoSubida As System.Windows.Forms.DataGridView
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Archivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTN_LocalFtp As System.Windows.Forms.Button
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btn_RecargSubir As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LbL_AgEjecucion As System.Windows.Forms.Label
    Friend WithEvents btn_subir As System.Windows.Forms.Button
    Friend WithEvents txt_SoloAg As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Procesando As System.Windows.Forms.TextBox
    Friend WithEvents Timer_AGEjecucion As System.Windows.Forms.Timer
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents btn_RecargaTodos As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CBox_Archivo As ComboBox
    Friend WithEvents btn_LimpSubidos As Button
    Friend WithEvents btn_LimpError As Button
    Friend WithEvents btn_Todos As Button
    Friend WithEvents btn_Errores As Button
    Friend WithEvents btn_Subido As Button
End Class
