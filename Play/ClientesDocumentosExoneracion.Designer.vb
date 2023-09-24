<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClientesDocumentosExoneracion
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
        Me.TxtB_IdExentoCabys = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.BtnEliminaCabysExento = New System.Windows.Forms.Button()
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.DGV_ListaCabysExentos = New System.Windows.Forms.DataGridView()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.DTP_ExoFechaVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.txtb_ExoPorcentajeCompra = New System.Windows.Forms.TextBox()
        Me.lbl_PorcentajeCompra = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.DTP_ExoFechaEmision = New System.Windows.Forms.DateTimePicker()
        Me.txtb_ExoNombreInstitucion = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TxtB_CabysExento = New System.Windows.Forms.TextBox()
        Me.txtb_ExoNumero = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.CBox_ExoTipoDoc = New System.Windows.Forms.ComboBox()
        Me.btn_Guardar = New System.Windows.Forms.Button()
        Me.Btn_Eliminar = New System.Windows.Forms.Button()
        Me.btn_Desagregar = New System.Windows.Forms.Button()
        Me.btn_Agregar = New System.Windows.Forms.Button()
        Me.txtb_Codigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtb_idDocExoneracion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DGV_ListaCabysExentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtB_IdExentoCabys
        '
        Me.TxtB_IdExentoCabys.Location = New System.Drawing.Point(141, 257)
        Me.TxtB_IdExentoCabys.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtB_IdExentoCabys.Name = "TxtB_IdExentoCabys"
        Me.TxtB_IdExentoCabys.Size = New System.Drawing.Size(160, 22)
        Me.TxtB_IdExentoCabys.TabIndex = 128
        Me.TxtB_IdExentoCabys.Visible = False
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(23, 260)
        Me.Label34.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(19, 17)
        Me.Label34.TabIndex = 127
        Me.Label34.Text = "Id"
        Me.Label34.Visible = False
        '
        'BtnEliminaCabysExento
        '
        Me.BtnEliminaCabysExento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminaCabysExento.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminaCabysExento.Location = New System.Drawing.Point(751, 169)
        Me.BtnEliminaCabysExento.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnEliminaCabysExento.Name = "BtnEliminaCabysExento"
        Me.BtnEliminaCabysExento.Size = New System.Drawing.Size(125, 35)
        Me.BtnEliminaCabysExento.TabIndex = 126
        Me.BtnEliminaCabysExento.Text = "Eliminar"
        Me.BtnEliminaCabysExento.UseVisualStyleBackColor = True
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregar.Location = New System.Drawing.Point(618, 169)
        Me.BtnAgregar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(125, 35)
        Me.BtnAgregar.TabIndex = 113
        Me.BtnAgregar.Text = "Agregar"
        Me.BtnAgregar.UseVisualStyleBackColor = True
        '
        'DGV_ListaCabysExentos
        '
        Me.DGV_ListaCabysExentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ListaCabysExentos.Location = New System.Drawing.Point(26, 319)
        Me.DGV_ListaCabysExentos.Name = "DGV_ListaCabysExentos"
        Me.DGV_ListaCabysExentos.RowTemplate.Height = 24
        Me.DGV_ListaCabysExentos.Size = New System.Drawing.Size(560, 194)
        Me.DGV_ListaCabysExentos.TabIndex = 125
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(24, 160)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(128, 17)
        Me.Label32.TabIndex = 124
        Me.Label32.Text = "Fecha Vencimiento"
        '
        'DTP_ExoFechaVencimiento
        '
        Me.DTP_ExoFechaVencimiento.Location = New System.Drawing.Point(329, 160)
        Me.DTP_ExoFechaVencimiento.Margin = New System.Windows.Forms.Padding(4)
        Me.DTP_ExoFechaVencimiento.Name = "DTP_ExoFechaVencimiento"
        Me.DTP_ExoFechaVencimiento.Size = New System.Drawing.Size(258, 22)
        Me.DTP_ExoFechaVencimiento.TabIndex = 123
        '
        'txtb_ExoPorcentajeCompra
        '
        Me.txtb_ExoPorcentajeCompra.Location = New System.Drawing.Point(329, 189)
        Me.txtb_ExoPorcentajeCompra.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_ExoPorcentajeCompra.Name = "txtb_ExoPorcentajeCompra"
        Me.txtb_ExoPorcentajeCompra.Size = New System.Drawing.Size(258, 22)
        Me.txtb_ExoPorcentajeCompra.TabIndex = 122
        '
        'lbl_PorcentajeCompra
        '
        Me.lbl_PorcentajeCompra.AutoSize = True
        Me.lbl_PorcentajeCompra.Location = New System.Drawing.Point(24, 192)
        Me.lbl_PorcentajeCompra.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_PorcentajeCompra.Name = "lbl_PorcentajeCompra"
        Me.lbl_PorcentajeCompra.Size = New System.Drawing.Size(129, 17)
        Me.lbl_PorcentajeCompra.TabIndex = 121
        Me.lbl_PorcentajeCompra.Text = "Porcentaje Compra"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(24, 130)
        Me.Label31.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(100, 17)
        Me.Label31.TabIndex = 120
        Me.Label31.Text = "Fecha Emision"
        '
        'DTP_ExoFechaEmision
        '
        Me.DTP_ExoFechaEmision.Location = New System.Drawing.Point(329, 130)
        Me.DTP_ExoFechaEmision.Margin = New System.Windows.Forms.Padding(4)
        Me.DTP_ExoFechaEmision.Name = "DTP_ExoFechaEmision"
        Me.DTP_ExoFechaEmision.Size = New System.Drawing.Size(258, 22)
        Me.DTP_ExoFechaEmision.TabIndex = 119
        '
        'txtb_ExoNombreInstitucion
        '
        Me.txtb_ExoNombreInstitucion.Location = New System.Drawing.Point(329, 99)
        Me.txtb_ExoNombreInstitucion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_ExoNombreInstitucion.Name = "txtb_ExoNombreInstitucion"
        Me.txtb_ExoNombreInstitucion.Size = New System.Drawing.Size(258, 22)
        Me.txtb_ExoNombreInstitucion.TabIndex = 118
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(24, 99)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(125, 17)
        Me.Label30.TabIndex = 117
        Me.Label30.Text = "Nombre Institucion"
        '
        'TxtB_CabysExento
        '
        Me.TxtB_CabysExento.Location = New System.Drawing.Point(141, 287)
        Me.TxtB_CabysExento.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtB_CabysExento.Name = "TxtB_CabysExento"
        Me.TxtB_CabysExento.Size = New System.Drawing.Size(160, 22)
        Me.TxtB_CabysExento.TabIndex = 116
        '
        'txtb_ExoNumero
        '
        Me.txtb_ExoNumero.Location = New System.Drawing.Point(329, 72)
        Me.txtb_ExoNumero.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_ExoNumero.Name = "txtb_ExoNumero"
        Me.txtb_ExoNumero.Size = New System.Drawing.Size(258, 22)
        Me.txtb_ExoNumero.TabIndex = 115
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(23, 290)
        Me.Label33.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(101, 17)
        Me.Label33.TabIndex = 112
        Me.Label33.Text = "Cabys Excento"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(24, 44)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(110, 17)
        Me.Label28.TabIndex = 111
        Me.Label28.Text = "Tipo documento"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(24, 75)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(58, 17)
        Me.Label29.TabIndex = 114
        Me.Label29.Text = "Numero"
        '
        'CBox_ExoTipoDoc
        '
        Me.CBox_ExoTipoDoc.FormattingEnabled = True
        Me.CBox_ExoTipoDoc.Items.AddRange(New Object() {"", "Compras autorizadas", "Ventas exentas a diplomáticos", "Autorizado por Ley especial", "Exenciones Dirección General de Hacienda", "Transitorio V ", "Transitorio IX ", "Transitorio XVII ", "Otros "})
        Me.CBox_ExoTipoDoc.Location = New System.Drawing.Point(329, 44)
        Me.CBox_ExoTipoDoc.Margin = New System.Windows.Forms.Padding(4)
        Me.CBox_ExoTipoDoc.Name = "CBox_ExoTipoDoc"
        Me.CBox_ExoTipoDoc.Size = New System.Drawing.Size(258, 24)
        Me.CBox_ExoTipoDoc.TabIndex = 110
        '
        'btn_Guardar
        '
        Me.btn_Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Guardar.Location = New System.Drawing.Point(461, 519)
        Me.btn_Guardar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(125, 52)
        Me.btn_Guardar.TabIndex = 129
        Me.btn_Guardar.Text = "Guardar"
        Me.btn_Guardar.UseVisualStyleBackColor = True
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Eliminar.Location = New System.Drawing.Point(27, 519)
        Me.Btn_Eliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Size = New System.Drawing.Size(125, 52)
        Me.Btn_Eliminar.TabIndex = 130
        Me.Btn_Eliminar.Text = "Eliminar"
        Me.Btn_Eliminar.UseVisualStyleBackColor = True
        '
        'btn_Desagregar
        '
        Me.btn_Desagregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Desagregar.Enabled = False
        Me.btn_Desagregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Desagregar.Location = New System.Drawing.Point(461, 261)
        Me.btn_Desagregar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Desagregar.Name = "btn_Desagregar"
        Me.btn_Desagregar.Size = New System.Drawing.Size(125, 52)
        Me.btn_Desagregar.TabIndex = 132
        Me.btn_Desagregar.Text = "Eliminar"
        Me.btn_Desagregar.UseVisualStyleBackColor = True
        '
        'btn_Agregar
        '
        Me.btn_Agregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Agregar.Enabled = False
        Me.btn_Agregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Agregar.Location = New System.Drawing.Point(328, 261)
        Me.btn_Agregar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Agregar.Name = "btn_Agregar"
        Me.btn_Agregar.Size = New System.Drawing.Size(125, 52)
        Me.btn_Agregar.TabIndex = 131
        Me.btn_Agregar.Text = "Agregar"
        Me.btn_Agregar.UseVisualStyleBackColor = True
        '
        'txtb_Codigo
        '
        Me.txtb_Codigo.Location = New System.Drawing.Point(329, 13)
        Me.txtb_Codigo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_Codigo.Name = "txtb_Codigo"
        Me.txtb_Codigo.Size = New System.Drawing.Size(258, 22)
        Me.txtb_Codigo.TabIndex = 134
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 17)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "Codigo Cliente"
        '
        'txtb_idDocExoneracion
        '
        Me.txtb_idDocExoneracion.Location = New System.Drawing.Point(330, 219)
        Me.txtb_idDocExoneracion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_idDocExoneracion.Name = "txtb_idDocExoneracion"
        Me.txtb_idDocExoneracion.Size = New System.Drawing.Size(258, 22)
        Me.txtb_idDocExoneracion.TabIndex = 136
        Me.txtb_idDocExoneracion.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 224)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 17)
        Me.Label2.TabIndex = 135
        Me.Label2.Text = "Id"
        Me.Label2.Visible = False
        '
        'ClientesDocumentosExoneracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 584)
        Me.Controls.Add(Me.txtb_idDocExoneracion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtb_Codigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Desagregar)
        Me.Controls.Add(Me.btn_Agregar)
        Me.Controls.Add(Me.Btn_Eliminar)
        Me.Controls.Add(Me.btn_Guardar)
        Me.Controls.Add(Me.TxtB_IdExentoCabys)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.BtnEliminaCabysExento)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.DGV_ListaCabysExentos)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.DTP_ExoFechaVencimiento)
        Me.Controls.Add(Me.txtb_ExoPorcentajeCompra)
        Me.Controls.Add(Me.lbl_PorcentajeCompra)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.DTP_ExoFechaEmision)
        Me.Controls.Add(Me.txtb_ExoNombreInstitucion)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.TxtB_CabysExento)
        Me.Controls.Add(Me.txtb_ExoNumero)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.CBox_ExoTipoDoc)
        Me.Name = "ClientesDocumentosExoneracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ClientesDocumentosExoneracion"
        CType(Me.DGV_ListaCabysExentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtB_IdExentoCabys As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents BtnEliminaCabysExento As Button
    Friend WithEvents BtnAgregar As Button
    Friend WithEvents DGV_ListaCabysExentos As DataGridView
    Friend WithEvents Label32 As Label
    Friend WithEvents DTP_ExoFechaVencimiento As DateTimePicker
    Friend WithEvents txtb_ExoPorcentajeCompra As TextBox
    Friend WithEvents lbl_PorcentajeCompra As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents DTP_ExoFechaEmision As DateTimePicker
    Friend WithEvents txtb_ExoNombreInstitucion As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents TxtB_CabysExento As TextBox
    Friend WithEvents txtb_ExoNumero As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents CBox_ExoTipoDoc As ComboBox
    Friend WithEvents btn_Guardar As Button
    Friend WithEvents Btn_Eliminar As Button
    Friend WithEvents btn_Desagregar As Button
    Friend WithEvents btn_Agregar As Button
    Friend WithEvents txtb_Codigo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtb_idDocExoneracion As TextBox
    Friend WithEvents Label2 As Label
End Class
