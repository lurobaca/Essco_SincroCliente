<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LiqChoferes_AddFactura
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
        Me.Dgv_FacCredito = New System.Windows.Forms.DataGridView
        Me.Dgv_FacContado = New System.Windows.Forms.DataGridView
        Me.BTN_CredToCont = New System.Windows.Forms.Button
        Me.BTN_ContToCred = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtb_Factura = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btn_Agregar = New System.Windows.Forms.Button
        Me.btn_Eliminar = New System.Windows.Forms.Button
        CType(Me.Dgv_FacCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv_FacContado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Dgv_FacCredito
        '
        Me.Dgv_FacCredito.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgv_FacCredito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_FacCredito.Location = New System.Drawing.Point(458, 42)
        Me.Dgv_FacCredito.Name = "Dgv_FacCredito"
        Me.Dgv_FacCredito.Size = New System.Drawing.Size(0, 282)
        Me.Dgv_FacCredito.TabIndex = 0
        Me.Dgv_FacCredito.Visible = False
        '
        'Dgv_FacContado
        '
        Me.Dgv_FacContado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgv_FacContado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_FacContado.Location = New System.Drawing.Point(1, 42)
        Me.Dgv_FacContado.Name = "Dgv_FacContado"
        Me.Dgv_FacContado.Size = New System.Drawing.Size(429, 282)
        Me.Dgv_FacContado.TabIndex = 1
        '
        'BTN_CredToCont
        '
        Me.BTN_CredToCont.Location = New System.Drawing.Point(410, 140)
        Me.BTN_CredToCont.Name = "BTN_CredToCont"
        Me.BTN_CredToCont.Size = New System.Drawing.Size(42, 27)
        Me.BTN_CredToCont.TabIndex = 2
        Me.BTN_CredToCont.Text = ">"
        Me.BTN_CredToCont.UseVisualStyleBackColor = True
        Me.BTN_CredToCont.Visible = False
        '
        'BTN_ContToCred
        '
        Me.BTN_ContToCred.Location = New System.Drawing.Point(410, 186)
        Me.BTN_ContToCred.Name = "BTN_ContToCred"
        Me.BTN_ContToCred.Size = New System.Drawing.Size(42, 27)
        Me.BTN_ContToCred.TabIndex = 3
        Me.BTN_ContToCred.Text = "<"
        Me.BTN_ContToCred.UseVisualStyleBackColor = True
        Me.BTN_ContToCred.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(601, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(188, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "FACTURAS CREDITO"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(130, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(194, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "FACTURAS CONTADO"
        '
        'txtb_Factura
        '
        Me.txtb_Factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Factura.Location = New System.Drawing.Point(84, 348)
        Me.txtb_Factura.Multiline = True
        Me.txtb_Factura.Name = "txtb_Factura"
        Me.txtb_Factura.Size = New System.Drawing.Size(171, 33)
        Me.txtb_Factura.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 354)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Factura"
        '
        'btn_Agregar
        '
        Me.btn_Agregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Agregar.Location = New System.Drawing.Point(261, 348)
        Me.btn_Agregar.Name = "btn_Agregar"
        Me.btn_Agregar.Size = New System.Drawing.Size(75, 33)
        Me.btn_Agregar.TabIndex = 9
        Me.btn_Agregar.Text = "Agregar"
        Me.btn_Agregar.UseVisualStyleBackColor = True
        '
        'btn_Eliminar
        '
        Me.btn_Eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Eliminar.Location = New System.Drawing.Point(344, 348)
        Me.btn_Eliminar.Name = "btn_Eliminar"
        Me.btn_Eliminar.Size = New System.Drawing.Size(75, 33)
        Me.btn_Eliminar.TabIndex = 12
        Me.btn_Eliminar.Text = "Quitar"
        Me.btn_Eliminar.UseVisualStyleBackColor = True
        '
        'LiqChoferes_AddFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 393)
        Me.Controls.Add(Me.Dgv_FacContado)
        Me.Controls.Add(Me.Dgv_FacCredito)
        Me.Controls.Add(Me.btn_Eliminar)
        Me.Controls.Add(Me.txtb_Factura)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_Agregar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTN_ContToCred)
        Me.Controls.Add(Me.BTN_CredToCont)
        Me.MaximizeBox = False
        Me.Name = "LiqChoferes_AddFactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LiqChoferes_AddFactura"
        CType(Me.Dgv_FacCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv_FacContado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Dgv_FacCredito As System.Windows.Forms.DataGridView
    Friend WithEvents Dgv_FacContado As System.Windows.Forms.DataGridView
    Friend WithEvents BTN_CredToCont As System.Windows.Forms.Button
    Friend WithEvents BTN_ContToCred As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtb_Factura As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_Agregar As System.Windows.Forms.Button
    Friend WithEvents btn_Eliminar As System.Windows.Forms.Button
End Class
