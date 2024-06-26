<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Planilla_Finalizar
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
        Me.ProgBar_EnvioPlanilla = New System.Windows.Forms.ProgressBar()
        Me.Lbl_Empleado = New System.Windows.Forms.Label()
        Me.Lbl_Fin = New System.Windows.Forms.Label()
        Me.Lbl_Inicio = New System.Windows.Forms.Label()
        Me.DGV_Resultado = New System.Windows.Forms.DataGridView()
        Me.btn_Ejecutar = New System.Windows.Forms.Button()
        Me.Lbl_Proceso = New System.Windows.Forms.Label()
        CType(Me.DGV_Resultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProgBar_EnvioPlanilla
        '
        Me.ProgBar_EnvioPlanilla.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgBar_EnvioPlanilla.Location = New System.Drawing.Point(23, 458)
        Me.ProgBar_EnvioPlanilla.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgBar_EnvioPlanilla.Name = "ProgBar_EnvioPlanilla"
        Me.ProgBar_EnvioPlanilla.Size = New System.Drawing.Size(858, 28)
        Me.ProgBar_EnvioPlanilla.TabIndex = 10
        '
        'Lbl_Empleado
        '
        Me.Lbl_Empleado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Empleado.AutoSize = True
        Me.Lbl_Empleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Lbl_Empleado.Location = New System.Drawing.Point(236, 429)
        Me.Lbl_Empleado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Empleado.Name = "Lbl_Empleado"
        Me.Lbl_Empleado.Size = New System.Drawing.Size(0, 25)
        Me.Lbl_Empleado.TabIndex = 15
        '
        'Lbl_Fin
        '
        Me.Lbl_Fin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Fin.AutoSize = True
        Me.Lbl_Fin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Lbl_Fin.Location = New System.Drawing.Point(824, 429)
        Me.Lbl_Fin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Fin.Name = "Lbl_Fin"
        Me.Lbl_Fin.Size = New System.Drawing.Size(56, 25)
        Me.Lbl_Fin.TabIndex = 14
        Me.Lbl_Fin.Text = "Total"
        '
        'Lbl_Inicio
        '
        Me.Lbl_Inicio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Inicio.AutoSize = True
        Me.Lbl_Inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Lbl_Inicio.Location = New System.Drawing.Point(17, 429)
        Me.Lbl_Inicio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Inicio.Name = "Lbl_Inicio"
        Me.Lbl_Inicio.Size = New System.Drawing.Size(57, 25)
        Me.Lbl_Inicio.TabIndex = 13
        Me.Lbl_Inicio.Text = "Inicio"
        '
        'DGV_Resultado
        '
        Me.DGV_Resultado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_Resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Resultado.Location = New System.Drawing.Point(22, 12)
        Me.DGV_Resultado.Name = "DGV_Resultado"
        Me.DGV_Resultado.RowTemplate.Height = 24
        Me.DGV_Resultado.Size = New System.Drawing.Size(858, 341)
        Me.DGV_Resultado.TabIndex = 33
        '
        'btn_Ejecutar
        '
        Me.btn_Ejecutar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Ejecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_Ejecutar.Location = New System.Drawing.Point(262, 504)
        Me.btn_Ejecutar.Name = "btn_Ejecutar"
        Me.btn_Ejecutar.Size = New System.Drawing.Size(326, 35)
        Me.btn_Ejecutar.TabIndex = 34
        Me.btn_Ejecutar.Text = "Ejecutar"
        Me.btn_Ejecutar.UseVisualStyleBackColor = True
        '
        'Lbl_Proceso
        '
        Me.Lbl_Proceso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Proceso.AutoSize = True
        Me.Lbl_Proceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Lbl_Proceso.Location = New System.Drawing.Point(18, 372)
        Me.Lbl_Proceso.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Proceso.Name = "Lbl_Proceso"
        Me.Lbl_Proceso.Size = New System.Drawing.Size(187, 25)
        Me.Lbl_Proceso.TabIndex = 35
        Me.Lbl_Proceso.Text = "Nombre del proceso"
        '
        'Planilla_Finalizar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(893, 551)
        Me.Controls.Add(Me.Lbl_Proceso)
        Me.Controls.Add(Me.btn_Ejecutar)
        Me.Controls.Add(Me.DGV_Resultado)
        Me.Controls.Add(Me.Lbl_Empleado)
        Me.Controls.Add(Me.Lbl_Fin)
        Me.Controls.Add(Me.Lbl_Inicio)
        Me.Controls.Add(Me.ProgBar_EnvioPlanilla)
        Me.Name = "Planilla_Finalizar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EnviandoPlanilla"
        Me.TopMost = True
        CType(Me.DGV_Resultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProgBar_EnvioPlanilla As ProgressBar
    Friend WithEvents Lbl_Empleado As Label
    Friend WithEvents Lbl_Fin As Label
    Friend WithEvents Lbl_Inicio As Label
    Friend WithEvents DGV_Resultado As DataGridView
    Friend WithEvents btn_Ejecutar As Button
    Friend WithEvents Lbl_Proceso As Label
End Class
