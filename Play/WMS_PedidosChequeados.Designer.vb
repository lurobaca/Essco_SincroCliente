<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WMS_PedidosChequeados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WMS_PedidosChequeados))
        Me.DGV_PedidosChequeados = New System.Windows.Forms.DataGridView()
        Me.Btn_Atras = New System.Windows.Forms.Button()
        Me.Btn_Adelante = New System.Windows.Forms.Button()
        Me.txb_NumeroPedido = New System.Windows.Forms.TextBox()
        Me.dtp_FechaReporte = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txtb_CodigoProveedor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txtb_NombreProveedor = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txtb_NumeroFactura = New System.Windows.Forms.TextBox()
        Me.btn_Buscar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_TPedido = New System.Windows.Forms.Label()
        Me.lbl_TChequeado = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbl_TFaltante = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbl_TSobrante = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CBox_Tarimas = New System.Windows.Forms.ComboBox()
        CType(Me.DGV_PedidosChequeados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_PedidosChequeados
        '
        Me.DGV_PedidosChequeados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_PedidosChequeados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_PedidosChequeados.Location = New System.Drawing.Point(15, 85)
        Me.DGV_PedidosChequeados.Name = "DGV_PedidosChequeados"
        Me.DGV_PedidosChequeados.RowTemplate.Height = 24
        Me.DGV_PedidosChequeados.Size = New System.Drawing.Size(1348, 683)
        Me.DGV_PedidosChequeados.TabIndex = 0
        '
        'Btn_Atras
        '
        Me.Btn_Atras.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Atras.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Atras.BackgroundImage = CType(resources.GetObject("Btn_Atras.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Atras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Atras.Location = New System.Drawing.Point(1155, 13)
        Me.Btn_Atras.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Atras.Name = "Btn_Atras"
        Me.Btn_Atras.Size = New System.Drawing.Size(100, 60)
        Me.Btn_Atras.TabIndex = 279
        Me.Btn_Atras.UseVisualStyleBackColor = False
        '
        'Btn_Adelante
        '
        Me.Btn_Adelante.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Adelante.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Adelante.BackgroundImage = CType(resources.GetObject("Btn_Adelante.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Adelante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Adelante.Location = New System.Drawing.Point(1263, 13)
        Me.Btn_Adelante.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Adelante.Name = "Btn_Adelante"
        Me.Btn_Adelante.Size = New System.Drawing.Size(100, 60)
        Me.Btn_Adelante.TabIndex = 278
        Me.Btn_Adelante.UseVisualStyleBackColor = False
        '
        'txb_NumeroPedido
        '
        Me.txb_NumeroPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_NumeroPedido.Location = New System.Drawing.Point(661, 11)
        Me.txb_NumeroPedido.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_NumeroPedido.Name = "txb_NumeroPedido"
        Me.txb_NumeroPedido.ReadOnly = True
        Me.txb_NumeroPedido.Size = New System.Drawing.Size(100, 26)
        Me.txb_NumeroPedido.TabIndex = 277
        '
        'dtp_FechaReporte
        '
        Me.dtp_FechaReporte.Enabled = False
        Me.dtp_FechaReporte.Location = New System.Drawing.Point(878, 13)
        Me.dtp_FechaReporte.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_FechaReporte.Name = "dtp_FechaReporte"
        Me.dtp_FechaReporte.Size = New System.Drawing.Size(269, 22)
        Me.dtp_FechaReporte.TabIndex = 273
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(800, 14)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 20)
        Me.Label1.TabIndex = 275
        Me.Label1.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(572, 14)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 20)
        Me.Label3.TabIndex = 281
        Me.Label3.Text = "# Pedido"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(27, 16)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(142, 20)
        Me.Label4.TabIndex = 283
        Me.Label4.Text = "Codigo Proveedor"
        '
        'Txtb_CodigoProveedor
        '
        Me.Txtb_CodigoProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_CodigoProveedor.Location = New System.Drawing.Point(200, 13)
        Me.Txtb_CodigoProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_CodigoProveedor.Name = "Txtb_CodigoProveedor"
        Me.Txtb_CodigoProveedor.ReadOnly = True
        Me.Txtb_CodigoProveedor.Size = New System.Drawing.Size(121, 26)
        Me.Txtb_CodigoProveedor.TabIndex = 282
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(27, 55)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(149, 20)
        Me.Label5.TabIndex = 285
        Me.Label5.Text = "Nombre Proveedor"
        '
        'Txtb_NombreProveedor
        '
        Me.Txtb_NombreProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_NombreProveedor.Location = New System.Drawing.Point(200, 52)
        Me.Txtb_NombreProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_NombreProveedor.Name = "Txtb_NombreProveedor"
        Me.Txtb_NombreProveedor.ReadOnly = True
        Me.Txtb_NombreProveedor.Size = New System.Drawing.Size(561, 26)
        Me.Txtb_NombreProveedor.TabIndex = 284
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(361, 10)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 20)
        Me.Label6.TabIndex = 287
        Me.Label6.Text = "# Factura"
        '
        'Txtb_NumeroFactura
        '
        Me.Txtb_NumeroFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_NumeroFactura.Location = New System.Drawing.Point(464, 10)
        Me.Txtb_NumeroFactura.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtb_NumeroFactura.Name = "Txtb_NumeroFactura"
        Me.Txtb_NumeroFactura.ReadOnly = True
        Me.Txtb_NumeroFactura.Size = New System.Drawing.Size(100, 26)
        Me.Txtb_NumeroFactura.TabIndex = 286
        '
        'btn_Buscar
        '
        Me.btn_Buscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Buscar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btn_Buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Buscar.Location = New System.Drawing.Point(15, 785)
        Me.btn_Buscar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Buscar.Name = "btn_Buscar"
        Me.btn_Buscar.Size = New System.Drawing.Size(107, 43)
        Me.btn_Buscar.TabIndex = 288
        Me.btn_Buscar.Text = "Buscar"
        Me.btn_Buscar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(196, 785)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 20)
        Me.Label2.TabIndex = 290
        Me.Label2.Text = "Total Pedido"
        '
        'lbl_TPedido
        '
        Me.lbl_TPedido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_TPedido.AutoSize = True
        Me.lbl_TPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TPedido.ForeColor = System.Drawing.Color.Red
        Me.lbl_TPedido.Location = New System.Drawing.Point(339, 785)
        Me.lbl_TPedido.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_TPedido.Name = "lbl_TPedido"
        Me.lbl_TPedido.Size = New System.Drawing.Size(42, 26)
        Me.lbl_TPedido.TabIndex = 291
        Me.lbl_TPedido.Text = "0.0"
        '
        'lbl_TChequeado
        '
        Me.lbl_TChequeado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_TChequeado.AutoSize = True
        Me.lbl_TChequeado.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TChequeado.ForeColor = System.Drawing.Color.Red
        Me.lbl_TChequeado.Location = New System.Drawing.Point(339, 816)
        Me.lbl_TChequeado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_TChequeado.Name = "lbl_TChequeado"
        Me.lbl_TChequeado.Size = New System.Drawing.Size(42, 26)
        Me.lbl_TChequeado.TabIndex = 293
        Me.lbl_TChequeado.Text = "0.0"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(196, 816)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(135, 20)
        Me.Label8.TabIndex = 292
        Me.Label8.Text = "Total Chequeado"
        '
        'lbl_TFaltante
        '
        Me.lbl_TFaltante.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_TFaltante.AutoSize = True
        Me.lbl_TFaltante.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TFaltante.ForeColor = System.Drawing.Color.Red
        Me.lbl_TFaltante.Location = New System.Drawing.Point(846, 779)
        Me.lbl_TFaltante.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_TFaltante.Name = "lbl_TFaltante"
        Me.lbl_TFaltante.Size = New System.Drawing.Size(42, 26)
        Me.lbl_TFaltante.TabIndex = 295
        Me.lbl_TFaltante.Text = "0.0"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(699, 785)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 20)
        Me.Label10.TabIndex = 294
        Me.Label10.Text = "Total Faltante"
        '
        'lbl_TSobrante
        '
        Me.lbl_TSobrante.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_TSobrante.AutoSize = True
        Me.lbl_TSobrante.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TSobrante.ForeColor = System.Drawing.Color.Red
        Me.lbl_TSobrante.Location = New System.Drawing.Point(846, 816)
        Me.lbl_TSobrante.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_TSobrante.Name = "lbl_TSobrante"
        Me.lbl_TSobrante.Size = New System.Drawing.Size(42, 26)
        Me.lbl_TSobrante.TabIndex = 297
        Me.lbl_TSobrante.Text = "0.0"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(699, 816)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(118, 20)
        Me.Label12.TabIndex = 296
        Me.Label12.Text = "Total Sobrante"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(800, 52)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 20)
        Me.Label7.TabIndex = 298
        Me.Label7.Text = "Tarimas"
        '
        'CBox_Tarimas
        '
        Me.CBox_Tarimas.FormattingEnabled = True
        Me.CBox_Tarimas.Location = New System.Drawing.Point(878, 52)
        Me.CBox_Tarimas.Name = "CBox_Tarimas"
        Me.CBox_Tarimas.Size = New System.Drawing.Size(269, 24)
        Me.CBox_Tarimas.TabIndex = 299
        '
        'WMS_PedidosChequeados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1381, 861)
        Me.Controls.Add(Me.CBox_Tarimas)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbl_TSobrante)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lbl_TFaltante)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lbl_TChequeado)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lbl_TPedido)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_Buscar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Txtb_NumeroFactura)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Txtb_NombreProveedor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Txtb_CodigoProveedor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Btn_Atras)
        Me.Controls.Add(Me.Btn_Adelante)
        Me.Controls.Add(Me.txb_NumeroPedido)
        Me.Controls.Add(Me.dtp_FechaReporte)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGV_PedidosChequeados)
        Me.Name = "WMS_PedidosChequeados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WMS_PedidosChequeados"
        CType(Me.DGV_PedidosChequeados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGV_PedidosChequeados As DataGridView
    Friend WithEvents Btn_Atras As Button
    Friend WithEvents Btn_Adelante As Button
    Friend WithEvents txb_NumeroPedido As TextBox
    Friend WithEvents dtp_FechaReporte As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Txtb_CodigoProveedor As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Txtb_NombreProveedor As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Txtb_NumeroFactura As TextBox
    Friend WithEvents btn_Buscar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents lbl_TPedido As Label
    Friend WithEvents lbl_TChequeado As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lbl_TFaltante As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lbl_TSobrante As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CBox_Tarimas As ComboBox
End Class
