<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Bodegueros
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txb_Nombre = New System.Windows.Forms.TextBox
        Me.txb_User = New System.Windows.Forms.TextBox
        Me.txb_clave = New System.Windows.Forms.TextBox
        Me.txb_sector = New System.Windows.Forms.TextBox
        Me.txb_sinchequear = New System.Windows.Forms.TextBox
        Me.txb_chequeado = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dgv_sectores = New System.Windows.Forms.DataGridView
        Me.btn_actualizarBod = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_eliminar = New System.Windows.Forms.Button
        Me.btn_sector = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_actualizar = New System.Windows.Forms.Button
        Me.btn_agregarBod = New System.Windows.Forms.Button
        Me.btn_buscarBod = New System.Windows.Forms.Button
        Me.cbx_puesto = New System.Windows.Forms.ComboBox
        Me.btn_ftpBod = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.dgv_sectores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Usuarios"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(279, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Clave"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(71, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Sector"
        '
        'txb_Nombre
        '
        Me.txb_Nombre.Location = New System.Drawing.Point(82, 13)
        Me.txb_Nombre.Name = "txb_Nombre"
        Me.txb_Nombre.Size = New System.Drawing.Size(100, 20)
        Me.txb_Nombre.TabIndex = 4
        '
        'txb_User
        '
        Me.txb_User.Location = New System.Drawing.Point(82, 43)
        Me.txb_User.Name = "txb_User"
        Me.txb_User.Size = New System.Drawing.Size(100, 20)
        Me.txb_User.TabIndex = 5
        '
        'txb_clave
        '
        Me.txb_clave.Location = New System.Drawing.Point(344, 43)
        Me.txb_clave.Name = "txb_clave"
        Me.txb_clave.Size = New System.Drawing.Size(121, 20)
        Me.txb_clave.TabIndex = 6
        '
        'txb_sector
        '
        Me.txb_sector.Location = New System.Drawing.Point(46, 41)
        Me.txb_sector.Name = "txb_sector"
        Me.txb_sector.Size = New System.Drawing.Size(100, 20)
        Me.txb_sector.TabIndex = 7
        '
        'txb_sinchequear
        '
        Me.txb_sinchequear.Location = New System.Drawing.Point(178, 41)
        Me.txb_sinchequear.Name = "txb_sinchequear"
        Me.txb_sinchequear.Size = New System.Drawing.Size(100, 20)
        Me.txb_sinchequear.TabIndex = 8
        '
        'txb_chequeado
        '
        Me.txb_chequeado.Location = New System.Drawing.Point(303, 41)
        Me.txb_chequeado.Name = "txb_chequeado"
        Me.txb_chequeado.Size = New System.Drawing.Size(100, 20)
        Me.txb_chequeado.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(195, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Sin Chequear"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(317, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Chequedo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(273, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Puesto"
        '
        'dgv_sectores
        '
        Me.dgv_sectores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_sectores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_sectores.Location = New System.Drawing.Point(13, 78)
        Me.dgv_sectores.Name = "dgv_sectores"
        Me.dgv_sectores.ReadOnly = True
        Me.dgv_sectores.Size = New System.Drawing.Size(538, 185)
        Me.dgv_sectores.TabIndex = 14
        '
        'btn_actualizarBod
        '
        Me.btn_actualizarBod.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_actualizarBod.Location = New System.Drawing.Point(113, 351)
        Me.btn_actualizarBod.Name = "btn_actualizarBod"
        Me.btn_actualizarBod.Size = New System.Drawing.Size(77, 46)
        Me.btn_actualizarBod.TabIndex = 15
        Me.btn_actualizarBod.Text = "Actualizar"
        Me.btn_actualizarBod.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_salir.Location = New System.Drawing.Point(456, 351)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(80, 46)
        Me.btn_salir.TabIndex = 16
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_eliminar
        '
        Me.btn_eliminar.Location = New System.Drawing.Point(409, 44)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(69, 27)
        Me.btn_eliminar.TabIndex = 17
        Me.btn_eliminar.Text = "Eliminar"
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'btn_sector
        '
        Me.btn_sector.Location = New System.Drawing.Point(409, 11)
        Me.btn_sector.Name = "btn_sector"
        Me.btn_sector.Size = New System.Drawing.Size(69, 27)
        Me.btn_sector.TabIndex = 18
        Me.btn_sector.Text = "Agregar"
        Me.btn_sector.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btn_actualizar)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btn_sector)
        Me.GroupBox1.Controls.Add(Me.txb_sector)
        Me.GroupBox1.Controls.Add(Me.dgv_sectores)
        Me.GroupBox1.Controls.Add(Me.btn_eliminar)
        Me.GroupBox1.Controls.Add(Me.txb_sinchequear)
        Me.GroupBox1.Controls.Add(Me.txb_chequeado)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(559, 276)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sectores Asignados"
        '
        'btn_actualizar
        '
        Me.btn_actualizar.Location = New System.Drawing.Point(484, 11)
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(69, 27)
        Me.btn_actualizar.TabIndex = 19
        Me.btn_actualizar.Text = "Actualizar"
        Me.btn_actualizar.UseVisualStyleBackColor = True
        Me.btn_actualizar.Visible = False
        '
        'btn_agregarBod
        '
        Me.btn_agregarBod.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_agregarBod.Location = New System.Drawing.Point(29, 351)
        Me.btn_agregarBod.Name = "btn_agregarBod"
        Me.btn_agregarBod.Size = New System.Drawing.Size(77, 46)
        Me.btn_agregarBod.TabIndex = 20
        Me.btn_agregarBod.Text = "Agregar"
        Me.btn_agregarBod.UseVisualStyleBackColor = True
        '
        'btn_buscarBod
        '
        Me.btn_buscarBod.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_buscarBod.Location = New System.Drawing.Point(197, 351)
        Me.btn_buscarBod.Name = "btn_buscarBod"
        Me.btn_buscarBod.Size = New System.Drawing.Size(77, 46)
        Me.btn_buscarBod.TabIndex = 21
        Me.btn_buscarBod.Text = "Buscar"
        Me.btn_buscarBod.UseVisualStyleBackColor = True
        '
        'cbx_puesto
        '
        Me.cbx_puesto.FormattingEnabled = True
        Me.cbx_puesto.Items.AddRange(New Object() {"Bodeguero", "Chequeador"})
        Me.cbx_puesto.Location = New System.Drawing.Point(344, 10)
        Me.cbx_puesto.Name = "cbx_puesto"
        Me.cbx_puesto.Size = New System.Drawing.Size(121, 21)
        Me.cbx_puesto.TabIndex = 22
        '
        'btn_ftpBod
        '
        Me.btn_ftpBod.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_ftpBod.Location = New System.Drawing.Point(365, 351)
        Me.btn_ftpBod.Name = "btn_ftpBod"
        Me.btn_ftpBod.Size = New System.Drawing.Size(77, 46)
        Me.btn_ftpBod.TabIndex = 23
        Me.btn_ftpBod.Text = "FTP"
        Me.btn_ftpBod.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(281, 351)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(77, 46)
        Me.Button1.TabIndex = 24
        Me.Button1.Text = "Eliminar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Admin_Bodegueros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 403)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_ftpBod)
        Me.Controls.Add(Me.cbx_puesto)
        Me.Controls.Add(Me.btn_buscarBod)
        Me.Controls.Add(Me.btn_agregarBod)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.btn_actualizarBod)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txb_clave)
        Me.Controls.Add(Me.txb_User)
        Me.Controls.Add(Me.txb_Nombre)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MinimumSize = New System.Drawing.Size(596, 441)
        Me.Name = "Admin_Bodegueros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Admin_Bodegueros"
        CType(Me.dgv_sectores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txb_Nombre As System.Windows.Forms.TextBox
    Friend WithEvents txb_User As System.Windows.Forms.TextBox
    Friend WithEvents txb_clave As System.Windows.Forms.TextBox
    Friend WithEvents txb_sector As System.Windows.Forms.TextBox
    Friend WithEvents txb_sinchequear As System.Windows.Forms.TextBox
    Friend WithEvents txb_chequeado As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgv_sectores As System.Windows.Forms.DataGridView
    Friend WithEvents btn_actualizarBod As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_sector As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_agregarBod As System.Windows.Forms.Button
    Friend WithEvents btn_buscarBod As System.Windows.Forms.Button
    Friend WithEvents cbx_puesto As System.Windows.Forms.ComboBox
    Friend WithEvents btn_ftpBod As System.Windows.Forms.Button
    Friend WithEvents btn_actualizar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
