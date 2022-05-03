<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Stock_Categorizaciones
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
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_Eliminar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtb_Nombre = New System.Windows.Forms.TextBox()
        Me.CBox_Categorizaciones = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DGV_ListaCategorizaciones = New System.Windows.Forms.DataGridView()
        Me.txtb_id = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.DGV_ListaCategorizaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_guardar
        '
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Location = New System.Drawing.Point(12, 448)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(89, 32)
        Me.btn_guardar.TabIndex = 0
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'btn_Eliminar
        '
        Me.btn_Eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Eliminar.Location = New System.Drawing.Point(191, 448)
        Me.btn_Eliminar.Name = "btn_Eliminar"
        Me.btn_Eliminar.Size = New System.Drawing.Size(89, 32)
        Me.btn_Eliminar.TabIndex = 1
        Me.btn_Eliminar.Text = "Eliminar"
        Me.btn_Eliminar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nombre"
        '
        'txtb_Nombre
        '
        Me.txtb_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Nombre.Location = New System.Drawing.Point(12, 34)
        Me.txtb_Nombre.Name = "txtb_Nombre"
        Me.txtb_Nombre.Size = New System.Drawing.Size(268, 27)
        Me.txtb_Nombre.TabIndex = 3
        '
        'CBox_Categorizaciones
        '
        Me.CBox_Categorizaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBox_Categorizaciones.FormattingEnabled = True
        Me.CBox_Categorizaciones.Items.AddRange(New Object() {"Familia", "Categoria", "Marca"})
        Me.CBox_Categorizaciones.Location = New System.Drawing.Point(16, 141)
        Me.CBox_Categorizaciones.Name = "CBox_Categorizaciones"
        Me.CBox_Categorizaciones.Size = New System.Drawing.Size(215, 28)
        Me.CBox_Categorizaciones.TabIndex = 4
        Me.CBox_Categorizaciones.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Tipo"
        Me.Label2.Visible = False
        '
        'DGV_ListaCategorizaciones
        '
        Me.DGV_ListaCategorizaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_ListaCategorizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ListaCategorizaciones.Location = New System.Drawing.Point(0, 79)
        Me.DGV_ListaCategorizaciones.Name = "DGV_ListaCategorizaciones"
        Me.DGV_ListaCategorizaciones.Size = New System.Drawing.Size(290, 363)
        Me.DGV_ListaCategorizaciones.TabIndex = 6
        '
        'txtb_id
        '
        Me.txtb_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_id.Location = New System.Drawing.Point(214, 142)
        Me.txtb_id.Name = "txtb_id"
        Me.txtb_id.Size = New System.Drawing.Size(64, 27)
        Me.txtb_id.TabIndex = 8
        Me.txtb_id.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(256, 194)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Id"
        Me.Label3.Visible = False
        '
        'Stock_Categorizaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 492)
        Me.Controls.Add(Me.DGV_ListaCategorizaciones)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CBox_Categorizaciones)
        Me.Controls.Add(Me.txtb_Nombre)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Eliminar)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.txtb_id)
        Me.Controls.Add(Me.Label3)
        Me.Name = "Stock_Categorizaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock_Categorizaciones"
        CType(Me.DGV_ListaCategorizaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_guardar As Button
    Friend WithEvents btn_Eliminar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtb_Nombre As TextBox
    Friend WithEvents CBox_Categorizaciones As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DGV_ListaCategorizaciones As DataGridView
    Friend WithEvents txtb_id As TextBox
    Friend WithEvents Label3 As Label
End Class
