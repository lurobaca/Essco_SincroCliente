<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstadoSubida))
        Me.DGV_EstadoSubida = New System.Windows.Forms.DataGridView
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Archivo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Button5 = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btn_MuestraTodo = New System.Windows.Forms.Button
        Me.btn_LimpiaTodoSubido = New System.Windows.Forms.Button
        Me.btn_MuestraTodoSubido = New System.Windows.Forms.Button
        Me.btn_LimpiaTodoError = New System.Windows.Forms.Button
        Me.btn_MuestraTodoError = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_PagosLimpSubido = New System.Windows.Forms.Button
        Me.btn_PagosLimpError = New System.Windows.Forms.Button
        Me.btn_PagosTodos = New System.Windows.Forms.Button
        Me.btn_PagosError = New System.Windows.Forms.Button
        Me.btn_PagosSubido = New System.Windows.Forms.Button
        Me.BTN_LocalFtp = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_PedidLimpSubidos = New System.Windows.Forms.Button
        Me.btn_PedidLimpError = New System.Windows.Forms.Button
        Me.btn_TodosPedidos = New System.Windows.Forms.Button
        Me.btn_PedidError = New System.Windows.Forms.Button
        Me.btn_PedidSubido = New System.Windows.Forms.Button
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.btn_RecargaTodos = New System.Windows.Forms.Button
        Me.btn_RecargSubir = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.LbL_AgEjecucion = New System.Windows.Forms.Label
        Me.btn_subir = New System.Windows.Forms.Button
        Me.txt_SoloAg = New System.Windows.Forms.TextBox
        Me.Lbl_Procesando = New System.Windows.Forms.TextBox
        Me.Timer_AGEjecucion = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.DGV_EstadoSubida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.DGV_EstadoSubida.Location = New System.Drawing.Point(12, 5)
        Me.DGV_EstadoSubida.Name = "DGV_EstadoSubida"
        Me.DGV_EstadoSubida.Size = New System.Drawing.Size(1087, 633)
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
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.AutoScroll = True
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Controls.Add(Me.Button5)
        Me.Panel4.Controls.Add(Me.GroupBox3)
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Controls.Add(Me.BTN_LocalFtp)
        Me.Panel4.Controls.Add(Me.GroupBox2)
        Me.Panel4.Location = New System.Drawing.Point(1103, 5)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(155, 633)
        Me.Panel4.TabIndex = 10
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.BackColor = System.Drawing.Color.Red
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.SystemColors.Control
        Me.Button5.Location = New System.Drawing.Point(7, 576)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(145, 30)
        Me.Button5.TabIndex = 19
        Me.Button5.Text = "HOY BLOQUEADO"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btn_MuestraTodo)
        Me.GroupBox3.Controls.Add(Me.btn_LimpiaTodoSubido)
        Me.GroupBox3.Controls.Add(Me.btn_MuestraTodoSubido)
        Me.GroupBox3.Controls.Add(Me.btn_LimpiaTodoError)
        Me.GroupBox3.Controls.Add(Me.btn_MuestraTodoError)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(145, 158)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pedidos / Pagos"
        '
        'btn_MuestraTodo
        '
        Me.btn_MuestraTodo.Location = New System.Drawing.Point(0, 18)
        Me.btn_MuestraTodo.Name = "btn_MuestraTodo"
        Me.btn_MuestraTodo.Size = New System.Drawing.Size(144, 25)
        Me.btn_MuestraTodo.TabIndex = 0
        Me.btn_MuestraTodo.Text = "Mostrar Todo"
        Me.btn_MuestraTodo.UseVisualStyleBackColor = True
        '
        'btn_LimpiaTodoSubido
        '
        Me.btn_LimpiaTodoSubido.Location = New System.Drawing.Point(0, 129)
        Me.btn_LimpiaTodoSubido.Name = "btn_LimpiaTodoSubido"
        Me.btn_LimpiaTodoSubido.Size = New System.Drawing.Size(144, 25)
        Me.btn_LimpiaTodoSubido.TabIndex = 12
        Me.btn_LimpiaTodoSubido.Text = "Limpiar Todos los Subidos"
        Me.btn_LimpiaTodoSubido.UseVisualStyleBackColor = True
        '
        'btn_MuestraTodoSubido
        '
        Me.btn_MuestraTodoSubido.Location = New System.Drawing.Point(0, 72)
        Me.btn_MuestraTodoSubido.Name = "btn_MuestraTodoSubido"
        Me.btn_MuestraTodoSubido.Size = New System.Drawing.Size(144, 25)
        Me.btn_MuestraTodoSubido.TabIndex = 2
        Me.btn_MuestraTodoSubido.Text = "Mostrar Todos los  Subidos"
        Me.btn_MuestraTodoSubido.UseVisualStyleBackColor = True
        '
        'btn_LimpiaTodoError
        '
        Me.btn_LimpiaTodoError.Location = New System.Drawing.Point(0, 100)
        Me.btn_LimpiaTodoError.Name = "btn_LimpiaTodoError"
        Me.btn_LimpiaTodoError.Size = New System.Drawing.Size(144, 25)
        Me.btn_LimpiaTodoError.TabIndex = 11
        Me.btn_LimpiaTodoError.Text = "Limpiar Todos los Errores"
        Me.btn_LimpiaTodoError.UseVisualStyleBackColor = True
        '
        'btn_MuestraTodoError
        '
        Me.btn_MuestraTodoError.Location = New System.Drawing.Point(0, 44)
        Me.btn_MuestraTodoError.Name = "btn_MuestraTodoError"
        Me.btn_MuestraTodoError.Size = New System.Drawing.Size(144, 25)
        Me.btn_MuestraTodoError.TabIndex = 1
        Me.btn_MuestraTodoError.Text = "Mostrar Todos los  Errores"
        Me.btn_MuestraTodoError.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_PagosLimpSubido)
        Me.GroupBox1.Controls.Add(Me.btn_PagosLimpError)
        Me.GroupBox1.Controls.Add(Me.btn_PagosTodos)
        Me.GroupBox1.Controls.Add(Me.btn_PagosError)
        Me.GroupBox1.Controls.Add(Me.btn_PagosSubido)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 325)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(146, 157)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PAGOS"
        '
        'btn_PagosLimpSubido
        '
        Me.btn_PagosLimpSubido.Location = New System.Drawing.Point(2, 126)
        Me.btn_PagosLimpSubido.Name = "btn_PagosLimpSubido"
        Me.btn_PagosLimpSubido.Size = New System.Drawing.Size(144, 25)
        Me.btn_PagosLimpSubido.TabIndex = 10
        Me.btn_PagosLimpSubido.Text = "Limpiar Subidos"
        Me.btn_PagosLimpSubido.UseVisualStyleBackColor = True
        '
        'btn_PagosLimpError
        '
        Me.btn_PagosLimpError.Location = New System.Drawing.Point(1, 72)
        Me.btn_PagosLimpError.Name = "btn_PagosLimpError"
        Me.btn_PagosLimpError.Size = New System.Drawing.Size(144, 25)
        Me.btn_PagosLimpError.TabIndex = 9
        Me.btn_PagosLimpError.Text = "Limpiar Errores"
        Me.btn_PagosLimpError.UseVisualStyleBackColor = True
        '
        'btn_PagosTodos
        '
        Me.btn_PagosTodos.Location = New System.Drawing.Point(1, 19)
        Me.btn_PagosTodos.Name = "btn_PagosTodos"
        Me.btn_PagosTodos.Size = New System.Drawing.Size(144, 25)
        Me.btn_PagosTodos.TabIndex = 6
        Me.btn_PagosTodos.Text = "Mostrar Todos los  Pagos"
        Me.btn_PagosTodos.UseVisualStyleBackColor = True
        '
        'btn_PagosError
        '
        Me.btn_PagosError.Location = New System.Drawing.Point(1, 46)
        Me.btn_PagosError.Name = "btn_PagosError"
        Me.btn_PagosError.Size = New System.Drawing.Size(144, 25)
        Me.btn_PagosError.TabIndex = 7
        Me.btn_PagosError.Text = "Pagos con Errores"
        Me.btn_PagosError.UseVisualStyleBackColor = True
        '
        'btn_PagosSubido
        '
        Me.btn_PagosSubido.Location = New System.Drawing.Point(2, 99)
        Me.btn_PagosSubido.Name = "btn_PagosSubido"
        Me.btn_PagosSubido.Size = New System.Drawing.Size(144, 25)
        Me.btn_PagosSubido.TabIndex = 8
        Me.btn_PagosSubido.Text = "Pagos Subidos"
        Me.btn_PagosSubido.UseVisualStyleBackColor = True
        '
        'BTN_LocalFtp
        '
        Me.BTN_LocalFtp.BackColor = System.Drawing.Color.Green
        Me.BTN_LocalFtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_LocalFtp.ForeColor = System.Drawing.SystemColors.Control
        Me.BTN_LocalFtp.Location = New System.Drawing.Point(7, 540)
        Me.BTN_LocalFtp.Name = "BTN_LocalFtp"
        Me.BTN_LocalFtp.Size = New System.Drawing.Size(145, 30)
        Me.BTN_LocalFtp.TabIndex = 18
        Me.BTN_LocalFtp.Text = "FTP"
        Me.BTN_LocalFtp.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.btn_PedidLimpSubidos)
        Me.GroupBox2.Controls.Add(Me.btn_PedidLimpError)
        Me.GroupBox2.Controls.Add(Me.btn_TodosPedidos)
        Me.GroupBox2.Controls.Add(Me.btn_PedidError)
        Me.GroupBox2.Controls.Add(Me.btn_PedidSubido)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 163)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(145, 162)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PEDIDOS"
        '
        'btn_PedidLimpSubidos
        '
        Me.btn_PedidLimpSubidos.Location = New System.Drawing.Point(2, 131)
        Me.btn_PedidLimpSubidos.Name = "btn_PedidLimpSubidos"
        Me.btn_PedidLimpSubidos.Size = New System.Drawing.Size(144, 25)
        Me.btn_PedidLimpSubidos.TabIndex = 11
        Me.btn_PedidLimpSubidos.Text = "Limpiar Subidos"
        Me.btn_PedidLimpSubidos.UseVisualStyleBackColor = True
        '
        'btn_PedidLimpError
        '
        Me.btn_PedidLimpError.Location = New System.Drawing.Point(1, 74)
        Me.btn_PedidLimpError.Name = "btn_PedidLimpError"
        Me.btn_PedidLimpError.Size = New System.Drawing.Size(144, 25)
        Me.btn_PedidLimpError.TabIndex = 11
        Me.btn_PedidLimpError.Text = "Limpiar Errores"
        Me.btn_PedidLimpError.UseVisualStyleBackColor = True
        '
        'btn_TodosPedidos
        '
        Me.btn_TodosPedidos.Location = New System.Drawing.Point(1, 19)
        Me.btn_TodosPedidos.Name = "btn_TodosPedidos"
        Me.btn_TodosPedidos.Size = New System.Drawing.Size(144, 25)
        Me.btn_TodosPedidos.TabIndex = 3
        Me.btn_TodosPedidos.Text = "Mostrar Todos los  Pedidos"
        Me.btn_TodosPedidos.UseVisualStyleBackColor = True
        '
        'btn_PedidError
        '
        Me.btn_PedidError.Location = New System.Drawing.Point(1, 46)
        Me.btn_PedidError.Name = "btn_PedidError"
        Me.btn_PedidError.Size = New System.Drawing.Size(144, 25)
        Me.btn_PedidError.TabIndex = 4
        Me.btn_PedidError.Text = "Pedidos con Errores"
        Me.btn_PedidError.UseVisualStyleBackColor = True
        '
        'btn_PedidSubido
        '
        Me.btn_PedidSubido.Location = New System.Drawing.Point(1, 102)
        Me.btn_PedidSubido.Name = "btn_PedidSubido"
        Me.btn_PedidSubido.Size = New System.Drawing.Size(144, 25)
        Me.btn_PedidSubido.TabIndex = 5
        Me.btn_PedidSubido.Text = "Pedidos Subidos"
        Me.btn_PedidSubido.UseVisualStyleBackColor = True
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
        Me.Panel7.Location = New System.Drawing.Point(626, 644)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(632, 50)
        Me.Panel7.TabIndex = 18
        '
        'btn_RecargaTodos
        '
        Me.btn_RecargaTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_RecargaTodos.Location = New System.Drawing.Point(428, 9)
        Me.btn_RecargaTodos.Name = "btn_RecargaTodos"
        Me.btn_RecargaTodos.Size = New System.Drawing.Size(126, 32)
        Me.btn_RecargaTodos.TabIndex = 19
        Me.btn_RecargaTodos.Text = "Recargar Todos"
        Me.btn_RecargaTodos.UseVisualStyleBackColor = True
        '
        'btn_RecargSubir
        '
        Me.btn_RecargSubir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_RecargSubir.Location = New System.Drawing.Point(165, 9)
        Me.btn_RecargSubir.Name = "btn_RecargSubir"
        Me.btn_RecargSubir.Size = New System.Drawing.Size(126, 32)
        Me.btn_RecargSubir.TabIndex = 17
        Me.btn_RecargSubir.Text = "Recargar y Subir"
        Me.btn_RecargSubir.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 18)
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
        Me.LbL_AgEjecucion.Location = New System.Drawing.Point(560, 6)
        Me.LbL_AgEjecucion.Name = "LbL_AgEjecucion"
        Me.LbL_AgEjecucion.Size = New System.Drawing.Size(66, 33)
        Me.LbL_AgEjecucion.TabIndex = 10
        Me.LbL_AgEjecucion.Text = "#Ag"
        '
        'btn_subir
        '
        Me.btn_subir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_subir.Location = New System.Drawing.Point(297, 9)
        Me.btn_subir.Name = "btn_subir"
        Me.btn_subir.Size = New System.Drawing.Size(126, 32)
        Me.btn_subir.TabIndex = 11
        Me.btn_subir.Text = "Solo Subir"
        Me.btn_subir.UseVisualStyleBackColor = True
        '
        'txt_SoloAg
        '
        Me.txt_SoloAg.Location = New System.Drawing.Point(76, 19)
        Me.txt_SoloAg.Name = "txt_SoloAg"
        Me.txt_SoloAg.Size = New System.Drawing.Size(83, 20)
        Me.txt_SoloAg.TabIndex = 15
        '
        'Lbl_Procesando
        '
        Me.Lbl_Procesando.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Procesando.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Procesando.Location = New System.Drawing.Point(12, 665)
        Me.Lbl_Procesando.Name = "Lbl_Procesando"
        Me.Lbl_Procesando.Size = New System.Drawing.Size(608, 20)
        Me.Lbl_Procesando.TabIndex = 18
        '
        'Timer_AGEjecucion
        '
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(7, 504)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(145, 30)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Nube"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'EstadoSubida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1260, 694)
        Me.Controls.Add(Me.Lbl_Procesando)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.DGV_EstadoSubida)
        Me.Name = "EstadoSubida"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EstadoSubida"
        CType(Me.DGV_EstadoSubida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV_EstadoSubida As System.Windows.Forms.DataGridView
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Archivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_MuestraTodo As System.Windows.Forms.Button
    Friend WithEvents btn_LimpiaTodoSubido As System.Windows.Forms.Button
    Friend WithEvents btn_MuestraTodoSubido As System.Windows.Forms.Button
    Friend WithEvents btn_LimpiaTodoError As System.Windows.Forms.Button
    Friend WithEvents btn_MuestraTodoError As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_PagosLimpSubido As System.Windows.Forms.Button
    Friend WithEvents btn_PagosLimpError As System.Windows.Forms.Button
    Friend WithEvents btn_PagosTodos As System.Windows.Forms.Button
    Friend WithEvents btn_PagosError As System.Windows.Forms.Button
    Friend WithEvents btn_PagosSubido As System.Windows.Forms.Button
    Friend WithEvents BTN_LocalFtp As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_PedidLimpSubidos As System.Windows.Forms.Button
    Friend WithEvents btn_PedidLimpError As System.Windows.Forms.Button
    Friend WithEvents btn_TodosPedidos As System.Windows.Forms.Button
    Friend WithEvents btn_PedidError As System.Windows.Forms.Button
    Friend WithEvents btn_PedidSubido As System.Windows.Forms.Button
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
End Class
