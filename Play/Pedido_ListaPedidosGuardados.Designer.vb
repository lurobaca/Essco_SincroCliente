<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pedido_ListaPedidosGuardados
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
        Me.dgv_OrdenesCompra = New System.Windows.Forms.DataGridView()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.DTP_FechaFin = New System.Windows.Forms.DateTimePicker()
        Me.DTP_FechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lbl_NumOrden = New System.Windows.Forms.TextBox()
        Me.lbl_Id = New System.Windows.Forms.Label()
        Me.btn_BuscaAgente = New System.Windows.Forms.Button()
        Me.txtb_CodProveedor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        CType(Me.dgv_OrdenesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_OrdenesCompra
        '
        Me.dgv_OrdenesCompra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_OrdenesCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_OrdenesCompra.Location = New System.Drawing.Point(3, 63)
        Me.dgv_OrdenesCompra.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_OrdenesCompra.Name = "dgv_OrdenesCompra"
        Me.dgv_OrdenesCompra.ReadOnly = True
        Me.dgv_OrdenesCompra.Size = New System.Drawing.Size(1399, 729)
        Me.dgv_OrdenesCompra.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(555, 12)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(124, 25)
        Me.Label14.TabIndex = 111
        Me.Label14.Text = "Fecha Venta"
        '
        'DTP_FechaFin
        '
        Me.DTP_FechaFin.Location = New System.Drawing.Point(887, 16)
        Me.DTP_FechaFin.Margin = New System.Windows.Forms.Padding(4)
        Me.DTP_FechaFin.Name = "DTP_FechaFin"
        Me.DTP_FechaFin.Size = New System.Drawing.Size(192, 22)
        Me.DTP_FechaFin.TabIndex = 110
        '
        'DTP_FechaInicio
        '
        Me.DTP_FechaInicio.Location = New System.Drawing.Point(687, 16)
        Me.DTP_FechaInicio.Margin = New System.Windows.Forms.Padding(4)
        Me.DTP_FechaInicio.Name = "DTP_FechaInicio"
        Me.DTP_FechaInicio.Size = New System.Drawing.Size(192, 22)
        Me.DTP_FechaInicio.TabIndex = 109
        '
        'lbl_NumOrden
        '
        Me.lbl_NumOrden.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_NumOrden.BackColor = System.Drawing.Color.White
        Me.lbl_NumOrden.Location = New System.Drawing.Point(445, 13)
        Me.lbl_NumOrden.Margin = New System.Windows.Forms.Padding(4)
        Me.lbl_NumOrden.Name = "lbl_NumOrden"
        Me.lbl_NumOrden.Size = New System.Drawing.Size(104, 22)
        Me.lbl_NumOrden.TabIndex = 114
        '
        'lbl_Id
        '
        Me.lbl_Id.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Id.AutoSize = True
        Me.lbl_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lbl_Id.Location = New System.Drawing.Point(338, 12)
        Me.lbl_Id.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Id.Name = "lbl_Id"
        Me.lbl_Id.Size = New System.Drawing.Size(99, 25)
        Me.lbl_Id.TabIndex = 113
        Me.lbl_Id.Text = "NUMERO"
        '
        'btn_BuscaAgente
        '
        Me.btn_BuscaAgente.Image = Global.SincroCliente.My.Resources.Resources.ir
        Me.btn_BuscaAgente.Location = New System.Drawing.Point(287, 9)
        Me.btn_BuscaAgente.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_BuscaAgente.Name = "btn_BuscaAgente"
        Me.btn_BuscaAgente.Size = New System.Drawing.Size(43, 30)
        Me.btn_BuscaAgente.TabIndex = 117
        Me.btn_BuscaAgente.UseVisualStyleBackColor = True
        '
        'txtb_CodProveedor
        '
        Me.txtb_CodProveedor.BackColor = System.Drawing.Color.White
        Me.txtb_CodProveedor.Location = New System.Drawing.Point(123, 13)
        Me.txtb_CodProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtb_CodProveedor.Name = "txtb_CodProveedor"
        Me.txtb_CodProveedor.ReadOnly = True
        Me.txtb_CodProveedor.Size = New System.Drawing.Size(160, 22)
        Me.txtb_CodProveedor.TabIndex = 116
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(13, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 25)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "Proveedor"
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(1110, 9)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 32)
        Me.btnBuscar.TabIndex = 118
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Pedido_ListaPedidosGuardados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1407, 798)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btn_BuscaAgente)
        Me.Controls.Add(Me.txtb_CodProveedor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_NumOrden)
        Me.Controls.Add(Me.lbl_Id)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.DTP_FechaFin)
        Me.Controls.Add(Me.DTP_FechaInicio)
        Me.Controls.Add(Me.dgv_OrdenesCompra)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Pedido_ListaPedidosGuardados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ListaOrdenesDeCompra"
        CType(Me.dgv_OrdenesCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_OrdenesCompra As System.Windows.Forms.DataGridView
    Friend WithEvents Label14 As Label
    Friend WithEvents DTP_FechaFin As DateTimePicker
    Friend WithEvents DTP_FechaInicio As DateTimePicker
    Friend WithEvents lbl_NumOrden As TextBox
    Friend WithEvents lbl_Id As Label
    Friend WithEvents btn_BuscaAgente As Button
    Friend WithEvents txtb_CodProveedor As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnBuscar As Button
End Class
