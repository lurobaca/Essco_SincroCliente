<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClientesShow
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_Descripcion = New System.Windows.Forms.TextBox
        Me.dtg_Clientes = New System.Windows.Forms.DataGridView
        Me.CodClienteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NombreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OptieneClientesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Sic_Local_WebDataSet7 = New SincroCliente.Sic_Local_WebDataSet7
        Me.OptieneClientesTableAdapter = New SincroCliente.Sic_Local_WebDataSet7TableAdapters.OptieneClientesTableAdapter
        CType(Me.dtg_Clientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OptieneClientesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Sic_Local_WebDataSet7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Descripcion"
        '
        'txt_Descripcion
        '
        Me.txt_Descripcion.AcceptsReturn = True
        Me.txt_Descripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Descripcion.Location = New System.Drawing.Point(119, 12)
        Me.txt_Descripcion.Name = "txt_Descripcion"
        Me.txt_Descripcion.Size = New System.Drawing.Size(685, 26)
        Me.txt_Descripcion.TabIndex = 0
        '
        'dtg_Clientes
        '
        Me.dtg_Clientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_Clientes.AutoGenerateColumns = False
        Me.dtg_Clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_Clientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodClienteDataGridViewTextBoxColumn, Me.NombreDataGridViewTextBoxColumn})
        Me.dtg_Clientes.DataSource = Me.OptieneClientesBindingSource
        Me.dtg_Clientes.Location = New System.Drawing.Point(12, 47)
        Me.dtg_Clientes.Name = "dtg_Clientes"
        Me.dtg_Clientes.Size = New System.Drawing.Size(792, 415)
        Me.dtg_Clientes.TabIndex = 4
        '
        'CodClienteDataGridViewTextBoxColumn
        '
        Me.CodClienteDataGridViewTextBoxColumn.DataPropertyName = "CodCliente"
        Me.CodClienteDataGridViewTextBoxColumn.HeaderText = "CodCliente"
        Me.CodClienteDataGridViewTextBoxColumn.Name = "CodClienteDataGridViewTextBoxColumn"
        '
        'NombreDataGridViewTextBoxColumn
        '
        Me.NombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre"
        Me.NombreDataGridViewTextBoxColumn.HeaderText = "Nombre"
        Me.NombreDataGridViewTextBoxColumn.Name = "NombreDataGridViewTextBoxColumn"
        Me.NombreDataGridViewTextBoxColumn.Width = 600
        '
        'OptieneClientesBindingSource
        '
        Me.OptieneClientesBindingSource.DataMember = "OptieneClientes"
        Me.OptieneClientesBindingSource.DataSource = Me.Sic_Local_WebDataSet7
        '
        'Sic_Local_WebDataSet7
        '
        Me.Sic_Local_WebDataSet7.DataSetName = "Sic_Local_WebDataSet7"
        Me.Sic_Local_WebDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'OptieneClientesTableAdapter
        '
        Me.OptieneClientesTableAdapter.ClearBeforeFill = True
        '
        'ClientesShow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 474)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_Descripcion)
        Me.Controls.Add(Me.dtg_Clientes)
        Me.Name = "ClientesShow"
        Me.Text = "ClientesShow"
        CType(Me.dtg_Clientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OptieneClientesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Sic_Local_WebDataSet7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents dtg_Clientes As System.Windows.Forms.DataGridView
    Friend WithEvents OptieneClientesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Sic_Local_WebDataSet7 As SincroCliente.Sic_Local_WebDataSet7
    Friend WithEvents OptieneClientesTableAdapter As SincroCliente.Sic_Local_WebDataSet7TableAdapters.OptieneClientesTableAdapter
    Friend WithEvents CodClienteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
