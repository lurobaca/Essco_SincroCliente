<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BuscaClientesConDescFijos
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
        Me.DescFijosBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Sic_Local_WebDataSet5 = New SincroCliente.Sic_Local_WebDataSet5
        Me.DescFijosBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DescFijosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Desc_FijosTableAdapter = New SincroCliente.Sic_Local_WebDataSet5TableAdapters.Desc_FijosTableAdapter
        Me.Sic_Local_WebDataSet6 = New SincroCliente.Sic_Local_WebDataSet6
        Me.SicLocalWebDataSet6BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        CType(Me.DescFijosBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Sic_Local_WebDataSet5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DescFijosBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DescFijosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Sic_Local_WebDataSet6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SicLocalWebDataSet6BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DescFijosBindingSource2
        '
        Me.DescFijosBindingSource2.DataMember = "Desc_Fijos"
        Me.DescFijosBindingSource2.DataSource = Me.Sic_Local_WebDataSet5
        '
        'Sic_Local_WebDataSet5
        '
        Me.Sic_Local_WebDataSet5.DataSetName = "Sic_Local_WebDataSet5"
        Me.Sic_Local_WebDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DescFijosBindingSource1
        '
        Me.DescFijosBindingSource1.DataMember = "Desc_Fijos"
        Me.DescFijosBindingSource1.DataSource = Me.Sic_Local_WebDataSet5
        '
        'DescFijosBindingSource
        '
        Me.DescFijosBindingSource.DataMember = "Desc_Fijos"
        Me.DescFijosBindingSource.DataSource = Me.Sic_Local_WebDataSet5
        '
        'Desc_FijosTableAdapter
        '
        Me.Desc_FijosTableAdapter.ClearBeforeFill = True
        '
        'Sic_Local_WebDataSet6
        '
        Me.Sic_Local_WebDataSet6.DataSetName = "Sic_Local_WebDataSet6"
        Me.Sic_Local_WebDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SicLocalWebDataSet6BindingSource
        '
        Me.SicLocalWebDataSet6BindingSource.DataSource = Me.Sic_Local_WebDataSet6
        Me.SicLocalWebDataSet6BindingSource.Position = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nombe del cliente"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(123, 9)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(608, 20)
        Me.TextBox1.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 35)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(719, 412)
        Me.DataGridView1.TabIndex = 3
        '
        'BuscaClientesConDescFijos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 459)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "BuscaClientesConDescFijos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BuscaClientesConDescFijos"
        CType(Me.DescFijosBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Sic_Local_WebDataSet5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DescFijosBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DescFijosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Sic_Local_WebDataSet6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SicLocalWebDataSet6BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Sic_Local_WebDataSet5 As SincroCliente.Sic_Local_WebDataSet5
    Friend WithEvents DescFijosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Desc_FijosTableAdapter As SincroCliente.Sic_Local_WebDataSet5TableAdapters.Desc_FijosTableAdapter
    Friend WithEvents DescFijosBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DescFijosBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents Sic_Local_WebDataSet6 As SincroCliente.Sic_Local_WebDataSet6
    Friend WithEvents SicLocalWebDataSet6BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
