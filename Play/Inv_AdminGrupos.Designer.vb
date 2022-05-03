<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GruposConteo
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
        Me.Btn_Guardar = New System.Windows.Forms.Button()
        Me.Txtb_CodGrupo = New System.Windows.Forms.TextBox()
        Me.Txtb_Responsable = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txtb_Acompanante = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Dgv_Proveedores = New System.Windows.Forms.DataGridView()
        Me.Btn_Agregar = New System.Windows.Forms.Button()
        Me.Txb_CodInventario = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btn_Borrar = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btn_borrarGrupo = New System.Windows.Forms.Button()
        CType(Me.Dgv_Proveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cod Grupo"
        '
        'Btn_Guardar
        '
        Me.Btn_Guardar.Location = New System.Drawing.Point(87, 377)
        Me.Btn_Guardar.Name = "Btn_Guardar"
        Me.Btn_Guardar.Size = New System.Drawing.Size(75, 36)
        Me.Btn_Guardar.TabIndex = 8
        Me.Btn_Guardar.Text = "Guardar"
        Me.Btn_Guardar.UseVisualStyleBackColor = True
        '
        'Txtb_CodGrupo
        '
        Me.Txtb_CodGrupo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txtb_CodGrupo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Txtb_CodGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtb_CodGrupo.Location = New System.Drawing.Point(94, 13)
        Me.Txtb_CodGrupo.Name = "Txtb_CodGrupo"
        Me.Txtb_CodGrupo.Size = New System.Drawing.Size(279, 20)
        Me.Txtb_CodGrupo.TabIndex = 0
        '
        'Txtb_Responsable
        '
        Me.Txtb_Responsable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txtb_Responsable.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Txtb_Responsable.Location = New System.Drawing.Point(94, 39)
        Me.Txtb_Responsable.Name = "Txtb_Responsable"
        Me.Txtb_Responsable.Size = New System.Drawing.Size(357, 20)
        Me.Txtb_Responsable.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Responsable"
        '
        'Txtb_Acompanante
        '
        Me.Txtb_Acompanante.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txtb_Acompanante.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Txtb_Acompanante.Location = New System.Drawing.Point(94, 67)
        Me.Txtb_Acompanante.Name = "Txtb_Acompanante"
        Me.Txtb_Acompanante.Size = New System.Drawing.Size(357, 20)
        Me.Txtb_Acompanante.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Acompañante"
        '
        'Dgv_Proveedores
        '
        Me.Dgv_Proveedores.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgv_Proveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Proveedores.Location = New System.Drawing.Point(8, 167)
        Me.Dgv_Proveedores.Name = "Dgv_Proveedores"
        Me.Dgv_Proveedores.Size = New System.Drawing.Size(441, 169)
        Me.Dgv_Proveedores.TabIndex = 8
        '
        'Btn_Agregar
        '
        Me.Btn_Agregar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Agregar.Location = New System.Drawing.Point(57, 138)
        Me.Btn_Agregar.Name = "Btn_Agregar"
        Me.Btn_Agregar.Size = New System.Drawing.Size(392, 23)
        Me.Btn_Agregar.TabIndex = 7
        Me.Btn_Agregar.Text = "Agregar Proveedor"
        Me.Btn_Agregar.UseVisualStyleBackColor = True
        '
        'Txb_CodInventario
        '
        Me.Txb_CodInventario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txb_CodInventario.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Txb_CodInventario.Location = New System.Drawing.Point(94, 99)
        Me.Txb_CodInventario.Name = "Txb_CodInventario"
        Me.Txb_CodInventario.Size = New System.Drawing.Size(275, 20)
        Me.Txb_CodInventario.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 15)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Cod Inventario"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(372, 97)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(77, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 15)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Casas"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(168, 377)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 36)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "Buscar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btn_Borrar
        '
        Me.btn_Borrar.Location = New System.Drawing.Point(282, 378)
        Me.btn_Borrar.Name = "btn_Borrar"
        Me.btn_Borrar.Size = New System.Drawing.Size(91, 36)
        Me.btn_Borrar.TabIndex = 19
        Me.btn_Borrar.Text = "Borra Todos"
        Me.btn_Borrar.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(6, 377)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 36)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Nuevo"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(8, 348)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(443, 23)
        Me.ProgressBar1.TabIndex = 21
        '
        'btn_borrarGrupo
        '
        Me.btn_borrarGrupo.Location = New System.Drawing.Point(376, 378)
        Me.btn_borrarGrupo.Name = "btn_borrarGrupo"
        Me.btn_borrarGrupo.Size = New System.Drawing.Size(75, 36)
        Me.btn_borrarGrupo.TabIndex = 22
        Me.btn_borrarGrupo.Text = "Borra"
        Me.btn_borrarGrupo.UseVisualStyleBackColor = True
        '
        'GruposConteo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 425)
        Me.Controls.Add(Me.btn_borrarGrupo)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btn_Borrar)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Txb_CodInventario)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Btn_Agregar)
        Me.Controls.Add(Me.Dgv_Proveedores)
        Me.Controls.Add(Me.Txtb_Acompanante)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txtb_Responsable)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txtb_CodGrupo)
        Me.Controls.Add(Me.Btn_Guardar)
        Me.Controls.Add(Me.Label1)
        Me.Name = "GruposConteo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GrupoConteo"
        CType(Me.Dgv_Proveedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents Txtb_CodGrupo As System.Windows.Forms.TextBox
    Friend WithEvents Txtb_Responsable As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txtb_Acompanante As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Dgv_Proveedores As System.Windows.Forms.DataGridView
    Friend WithEvents Btn_Agregar As System.Windows.Forms.Button
    Friend WithEvents Txb_CodInventario As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btn_Borrar As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btn_borrarGrupo As System.Windows.Forms.Button
End Class
