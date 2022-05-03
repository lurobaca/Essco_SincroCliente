<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UltimosConsecutivos
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
        Me.DGV_UltimosConsecutivos = New System.Windows.Forms.DataGridView
        Me.IdagenteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UltiConsecPedidosDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UltiConsecPagosDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UltiConsecDepositosDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UltimosConsecutivosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Sic_Local_WebDataSet1 = New SincroCliente.Sic_Local_WebDataSet1
        Me.UltimosConsecutivosTableAdapter = New SincroCliente.Sic_Local_WebDataSet1TableAdapters.UltimosConsecutivosTableAdapter
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.DGV_UltimosConsecutivos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltimosConsecutivosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Sic_Local_WebDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_UltimosConsecutivos
        '
        Me.DGV_UltimosConsecutivos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_UltimosConsecutivos.AutoGenerateColumns = False
        Me.DGV_UltimosConsecutivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_UltimosConsecutivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdagenteDataGridViewTextBoxColumn, Me.UltiConsecPedidosDataGridViewTextBoxColumn, Me.UltiConsecPagosDataGridViewTextBoxColumn, Me.UltiConsecDepositosDataGridViewTextBoxColumn})
        Me.DGV_UltimosConsecutivos.DataSource = Me.UltimosConsecutivosBindingSource
        Me.DGV_UltimosConsecutivos.Location = New System.Drawing.Point(2, 3)
        Me.DGV_UltimosConsecutivos.Name = "DGV_UltimosConsecutivos"
        Me.DGV_UltimosConsecutivos.ReadOnly = True
        Me.DGV_UltimosConsecutivos.Size = New System.Drawing.Size(598, 450)
        Me.DGV_UltimosConsecutivos.TabIndex = 1
        '
        'IdagenteDataGridViewTextBoxColumn
        '
        Me.IdagenteDataGridViewTextBoxColumn.DataPropertyName = "id_agente"
        Me.IdagenteDataGridViewTextBoxColumn.HeaderText = "id_agente"
        Me.IdagenteDataGridViewTextBoxColumn.Name = "IdagenteDataGridViewTextBoxColumn"
        Me.IdagenteDataGridViewTextBoxColumn.ReadOnly = True
        '
        'UltiConsecPedidosDataGridViewTextBoxColumn
        '
        Me.UltiConsecPedidosDataGridViewTextBoxColumn.DataPropertyName = "Ulti_Consec_Pedidos"
        Me.UltiConsecPedidosDataGridViewTextBoxColumn.HeaderText = "Ulti_Consec_Pedidos"
        Me.UltiConsecPedidosDataGridViewTextBoxColumn.Name = "UltiConsecPedidosDataGridViewTextBoxColumn"
        Me.UltiConsecPedidosDataGridViewTextBoxColumn.ReadOnly = True
        Me.UltiConsecPedidosDataGridViewTextBoxColumn.Width = 150
        '
        'UltiConsecPagosDataGridViewTextBoxColumn
        '
        Me.UltiConsecPagosDataGridViewTextBoxColumn.DataPropertyName = "Ulti_Consec_Pagos"
        Me.UltiConsecPagosDataGridViewTextBoxColumn.HeaderText = "Ulti_Consec_Pagos"
        Me.UltiConsecPagosDataGridViewTextBoxColumn.Name = "UltiConsecPagosDataGridViewTextBoxColumn"
        Me.UltiConsecPagosDataGridViewTextBoxColumn.ReadOnly = True
        Me.UltiConsecPagosDataGridViewTextBoxColumn.Width = 150
        '
        'UltiConsecDepositosDataGridViewTextBoxColumn
        '
        Me.UltiConsecDepositosDataGridViewTextBoxColumn.DataPropertyName = "Ulti_Consec_Depositos"
        Me.UltiConsecDepositosDataGridViewTextBoxColumn.HeaderText = "Ulti_Consec_Depositos"
        Me.UltiConsecDepositosDataGridViewTextBoxColumn.Name = "UltiConsecDepositosDataGridViewTextBoxColumn"
        Me.UltiConsecDepositosDataGridViewTextBoxColumn.ReadOnly = True
        Me.UltiConsecDepositosDataGridViewTextBoxColumn.Width = 150
        '
        'UltimosConsecutivosBindingSource
        '
        Me.UltimosConsecutivosBindingSource.DataMember = "UltimosConsecutivos"
        Me.UltimosConsecutivosBindingSource.DataSource = Me.Sic_Local_WebDataSet1
        '
        'Sic_Local_WebDataSet1
        '
        Me.Sic_Local_WebDataSet1.DataSetName = "Sic_Local_WebDataSet1"
        Me.Sic_Local_WebDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UltimosConsecutivosTableAdapter
        '
        Me.UltimosConsecutivosTableAdapter.ClearBeforeFill = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 456)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 28)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Actualizar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'UltimosConsecutivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 486)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DGV_UltimosConsecutivos)
        Me.MaximumSize = New System.Drawing.Size(616, 524)
        Me.MinimumSize = New System.Drawing.Size(616, 524)
        Me.Name = "UltimosConsecutivos"
        Me.Text = "UltimosConsecutivos"
        CType(Me.DGV_UltimosConsecutivos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltimosConsecutivosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Sic_Local_WebDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGV_UltimosConsecutivos As System.Windows.Forms.DataGridView
    Friend WithEvents Sic_Local_WebDataSet1 As SincroCliente.Sic_Local_WebDataSet1
    Friend WithEvents UltimosConsecutivosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UltimosConsecutivosTableAdapter As SincroCliente.Sic_Local_WebDataSet1TableAdapters.UltimosConsecutivosTableAdapter
    Friend WithEvents IdagenteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UltiConsecPedidosDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UltiConsecPagosDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UltiConsecDepositosDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
