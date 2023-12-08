<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_MotivosDevolucion
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
        Me.Btn_GuardarMotivoDevolucion = New System.Windows.Forms.Button()
        Me.TxtBox_Codigo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtBox_Descripcion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Btn_NuevoMotivoDevolucion = New System.Windows.Forms.Button()
        Me.Btn_EliminarMotivoDevolucion = New System.Windows.Forms.Button()
        Me.DGV_ListaMotivosDevolucion = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBox_Bodegas = New System.Windows.Forms.ComboBox()
        CType(Me.DGV_ListaMotivosDevolucion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_GuardarMotivoDevolucion
        '
        Me.Btn_GuardarMotivoDevolucion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_GuardarMotivoDevolucion.Location = New System.Drawing.Point(210, 437)
        Me.Btn_GuardarMotivoDevolucion.Name = "Btn_GuardarMotivoDevolucion"
        Me.Btn_GuardarMotivoDevolucion.Size = New System.Drawing.Size(95, 41)
        Me.Btn_GuardarMotivoDevolucion.TabIndex = 0
        Me.Btn_GuardarMotivoDevolucion.Text = "Guardar"
        Me.Btn_GuardarMotivoDevolucion.UseVisualStyleBackColor = True
        '
        'TxtBox_Codigo
        '
        Me.TxtBox_Codigo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBox_Codigo.Location = New System.Drawing.Point(117, 92)
        Me.TxtBox_Codigo.Name = "TxtBox_Codigo"
        Me.TxtBox_Codigo.Size = New System.Drawing.Size(430, 22)
        Me.TxtBox_Codigo.TabIndex = 2
        Me.TxtBox_Codigo.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Codigo"
        Me.Label2.Visible = False
        '
        'TxtBox_Descripcion
        '
        Me.TxtBox_Descripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBox_Descripcion.Location = New System.Drawing.Point(116, 16)
        Me.TxtBox_Descripcion.Name = "TxtBox_Descripcion"
        Me.TxtBox_Descripcion.Size = New System.Drawing.Size(430, 22)
        Me.TxtBox_Descripcion.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Descripcion"
        '
        'Btn_NuevoMotivoDevolucion
        '
        Me.Btn_NuevoMotivoDevolucion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_NuevoMotivoDevolucion.Location = New System.Drawing.Point(12, 437)
        Me.Btn_NuevoMotivoDevolucion.Name = "Btn_NuevoMotivoDevolucion"
        Me.Btn_NuevoMotivoDevolucion.Size = New System.Drawing.Size(95, 41)
        Me.Btn_NuevoMotivoDevolucion.TabIndex = 6
        Me.Btn_NuevoMotivoDevolucion.Text = "Nuevo"
        Me.Btn_NuevoMotivoDevolucion.UseVisualStyleBackColor = True
        '
        'Btn_EliminarMotivoDevolucion
        '
        Me.Btn_EliminarMotivoDevolucion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_EliminarMotivoDevolucion.Location = New System.Drawing.Point(111, 437)
        Me.Btn_EliminarMotivoDevolucion.Name = "Btn_EliminarMotivoDevolucion"
        Me.Btn_EliminarMotivoDevolucion.Size = New System.Drawing.Size(95, 41)
        Me.Btn_EliminarMotivoDevolucion.TabIndex = 7
        Me.Btn_EliminarMotivoDevolucion.Text = "Eliminar"
        Me.Btn_EliminarMotivoDevolucion.UseVisualStyleBackColor = True
        '
        'DGV_ListaMotivosDevolucion
        '
        Me.DGV_ListaMotivosDevolucion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_ListaMotivosDevolucion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ListaMotivosDevolucion.Location = New System.Drawing.Point(12, 92)
        Me.DGV_ListaMotivosDevolucion.Name = "DGV_ListaMotivosDevolucion"
        Me.DGV_ListaMotivosDevolucion.RowTemplate.Height = 24
        Me.DGV_ListaMotivosDevolucion.Size = New System.Drawing.Size(533, 339)
        Me.DGV_ListaMotivosDevolucion.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Bodega"
        '
        'CBox_Bodegas
        '
        Me.CBox_Bodegas.FormattingEnabled = True
        Me.CBox_Bodegas.Location = New System.Drawing.Point(116, 56)
        Me.CBox_Bodegas.Name = "CBox_Bodegas"
        Me.CBox_Bodegas.Size = New System.Drawing.Size(430, 24)
        Me.CBox_Bodegas.TabIndex = 10
        '
        'Admin_MotivosDevolucion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 490)
        Me.Controls.Add(Me.CBox_Bodegas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGV_ListaMotivosDevolucion)
        Me.Controls.Add(Me.Btn_EliminarMotivoDevolucion)
        Me.Controls.Add(Me.Btn_NuevoMotivoDevolucion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtBox_Descripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtBox_Codigo)
        Me.Controls.Add(Me.Btn_GuardarMotivoDevolucion)
        Me.Name = "Admin_MotivosDevolucion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Admin_MotivosDevolucion"
        CType(Me.DGV_ListaMotivosDevolucion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_GuardarMotivoDevolucion As Button
    Friend WithEvents TxtBox_Codigo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtBox_Descripcion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Btn_NuevoMotivoDevolucion As Button
    Friend WithEvents Btn_EliminarMotivoDevolucion As Button
    Friend WithEvents DGV_ListaMotivosDevolucion As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents CBox_Bodegas As ComboBox
End Class
