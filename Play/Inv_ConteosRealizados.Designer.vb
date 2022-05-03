<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Inv_ConteosRealizados
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
        Me.dGv_Control = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtb_Descripcion = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txb_Proveedor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXT_Codigo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtb_IdInventario = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_BuscaIDInventario = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_Grupo = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.dGv_Control, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dGv_Control
        '
        Me.dGv_Control.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dGv_Control.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dGv_Control.Location = New System.Drawing.Point(1, 57)
        Me.dGv_Control.Name = "dGv_Control"
        Me.dGv_Control.Size = New System.Drawing.Size(957, 540)
        Me.dGv_Control.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(511, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 16)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "DESCRIPCION"
        '
        'txtb_Descripcion
        '
        Me.txtb_Descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Descripcion.Location = New System.Drawing.Point(514, 24)
        Me.txtb_Descripcion.Name = "txtb_Descripcion"
        Me.txtb_Descripcion.Size = New System.Drawing.Size(334, 27)
        Me.txtb_Descripcion.TabIndex = 23
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(302, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 16)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "PROVEEDOR"
        '
        'Txb_Proveedor
        '
        Me.Txb_Proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Proveedor.Location = New System.Drawing.Point(305, 24)
        Me.Txb_Proveedor.Name = "Txb_Proveedor"
        Me.Txb_Proveedor.Size = New System.Drawing.Size(100, 27)
        Me.Txb_Proveedor.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(407, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 16)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "CODIGO"
        '
        'TXT_Codigo
        '
        Me.TXT_Codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_Codigo.Location = New System.Drawing.Point(408, 24)
        Me.TXT_Codigo.Name = "TXT_Codigo"
        Me.TXT_Codigo.Size = New System.Drawing.Size(100, 27)
        Me.TXT_Codigo.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 16)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "ID Inventario"
        '
        'txtb_IdInventario
        '
        Me.txtb_IdInventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_IdInventario.Location = New System.Drawing.Point(10, 24)
        Me.txtb_IdInventario.Name = "txtb_IdInventario"
        Me.txtb_IdInventario.Size = New System.Drawing.Size(100, 27)
        Me.txtb_IdInventario.TabIndex = 29
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(854, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 37)
        Me.Button1.TabIndex = 31
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_BuscaIDInventario
        '
        Me.btn_BuscaIDInventario.BackgroundImage = Global.SincroCliente.My.Resources.Resources.lupa3
        Me.btn_BuscaIDInventario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_BuscaIDInventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_BuscaIDInventario.Location = New System.Drawing.Point(116, 16)
        Me.btn_BuscaIDInventario.Name = "btn_BuscaIDInventario"
        Me.btn_BuscaIDInventario.Size = New System.Drawing.Size(39, 35)
        Me.btn_BuscaIDInventario.TabIndex = 32
        Me.btn_BuscaIDInventario.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(161, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 16)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "GRUPO"
        '
        'txt_Grupo
        '
        Me.txt_Grupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Grupo.Location = New System.Drawing.Point(164, 24)
        Me.txt_Grupo.Name = "txt_Grupo"
        Me.txt_Grupo.Size = New System.Drawing.Size(59, 27)
        Me.txt_Grupo.TabIndex = 33
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.SincroCliente.My.Resources.Resources.lupa3
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(229, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(39, 35)
        Me.Button2.TabIndex = 35
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Inv_ConteosRealizados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 602)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_Grupo)
        Me.Controls.Add(Me.btn_BuscaIDInventario)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtb_IdInventario)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TXT_Codigo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Txb_Proveedor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtb_Descripcion)
        Me.Controls.Add(Me.dGv_Control)
        Me.Name = "Inv_ConteosRealizados"
        Me.Text = "Inv_ConteosRealizados"
        CType(Me.dGv_Control, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dGv_Control As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents txtb_Descripcion As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Txb_Proveedor As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TXT_Codigo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtb_IdInventario As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btn_BuscaIDInventario As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_Grupo As TextBox
    Friend WithEvents Button2 As Button
End Class
