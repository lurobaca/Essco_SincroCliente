<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WMS_VerBodegas
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
        Me.dgvVerBodegas = New System.Windows.Forms.DataGridView()
        Me.lblInfoVer = New System.Windows.Forms.Label()
        Me.btnVer = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.pbVerCarga = New System.Windows.Forms.ProgressBar()
        CType(Me.dgvVerBodegas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvVerBodegas
        '
        Me.dgvVerBodegas.AllowUserToAddRows = False
        Me.dgvVerBodegas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVerBodegas.Location = New System.Drawing.Point(21, 42)
        Me.dgvVerBodegas.Name = "dgvVerBodegas"
        Me.dgvVerBodegas.RowHeadersWidth = 51
        Me.dgvVerBodegas.RowTemplate.Height = 24
        Me.dgvVerBodegas.Size = New System.Drawing.Size(756, 247)
        Me.dgvVerBodegas.TabIndex = 9
        '
        'lblInfoVer
        '
        Me.lblInfoVer.AutoSize = True
        Me.lblInfoVer.Location = New System.Drawing.Point(18, 23)
        Me.lblInfoVer.Name = "lblInfoVer"
        Me.lblInfoVer.Size = New System.Drawing.Size(374, 16)
        Me.lblInfoVer.TabIndex = 19
        Me.lblInfoVer.Text = "Seleccione una bodega en la siguiente tabla y de click en Ver"
        '
        'btnVer
        '
        Me.btnVer.Location = New System.Drawing.Point(21, 295)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(126, 68)
        Me.btnVer.TabIndex = 20
        Me.btnVer.Text = "Ver"
        Me.btnVer.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(650, 295)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(126, 68)
        Me.btnCancelar.TabIndex = 21
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'pbVerCarga
        '
        Me.pbVerCarga.Location = New System.Drawing.Point(-3, 388)
        Me.pbVerCarga.Name = "pbVerCarga"
        Me.pbVerCarga.Size = New System.Drawing.Size(804, 23)
        Me.pbVerCarga.TabIndex = 22
        '
        'WMS_VerBodegas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 406)
        Me.Controls.Add(Me.pbVerCarga)
        Me.Controls.Add(Me.btnVer)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.lblInfoVer)
        Me.Controls.Add(Me.dgvVerBodegas)
        Me.Name = "WMS_VerBodegas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WMS_VerBodegas"
        CType(Me.dgvVerBodegas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvVerBodegas As DataGridView
    Friend WithEvents lblInfoVer As Label
    Friend WithEvents btnVer As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents pbVerCarga As ProgressBar
End Class
