<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WMS_CroquisBodega
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
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtBuscarArticulo = New System.Windows.Forms.TextBox()
        Me.Button108 = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.btn_NuevaBodega = New System.Windows.Forms.Button()
        Me.miniToolStrip = New System.Windows.Forms.ToolStrip()
        Me.Tap_Planta1 = New System.Windows.Forms.TabPage()
        Me.pbCargaTxtBuscar = New System.Windows.Forms.ProgressBar()
        Me.tcPlantas = New System.Windows.Forms.TabControl()
        Me.btnCambiarBodega = New System.Windows.Forms.Button()
        Me.Tap_Planta1.SuspendLayout()
        Me.tcPlantas.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 11)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(63, 16)
        Me.Label20.TabIndex = 37
        Me.Label20.Text = "BUSCAR"
        '
        'txtBuscarArticulo
        '
        Me.txtBuscarArticulo.Location = New System.Drawing.Point(95, 7)
        Me.txtBuscarArticulo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBuscarArticulo.Name = "txtBuscarArticulo"
        Me.txtBuscarArticulo.Size = New System.Drawing.Size(570, 22)
        Me.txtBuscarArticulo.TabIndex = 37
        '
        'Button108
        '
        Me.Button108.BackColor = System.Drawing.SystemColors.Control
        Me.Button108.Location = New System.Drawing.Point(673, 4)
        Me.Button108.Margin = New System.Windows.Forms.Padding(4)
        Me.Button108.Name = "Button108"
        Me.Button108.Size = New System.Drawing.Size(145, 28)
        Me.Button108.TabIndex = 44
        Me.Button108.Text = "Ubicar"
        Me.Button108.UseVisualStyleBackColor = False
        '
        'BackgroundWorker1
        '
        '
        'btn_NuevaBodega
        '
        Me.btn_NuevaBodega.BackColor = System.Drawing.SystemColors.Control
        Me.btn_NuevaBodega.Location = New System.Drawing.Point(983, 4)
        Me.btn_NuevaBodega.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_NuevaBodega.Name = "btn_NuevaBodega"
        Me.btn_NuevaBodega.Size = New System.Drawing.Size(145, 28)
        Me.btn_NuevaBodega.TabIndex = 48
        Me.btn_NuevaBodega.Text = "Abrir otra Bodega"
        Me.btn_NuevaBodega.UseVisualStyleBackColor = False
        '
        'miniToolStrip
        '
        Me.miniToolStrip.AccessibleName = "Selección de nuevo elemento"
        Me.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown
        Me.miniToolStrip.AutoSize = False
        Me.miniToolStrip.CanOverflow = False
        Me.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.miniToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.miniToolStrip.Location = New System.Drawing.Point(126, 1)
        Me.miniToolStrip.Name = "miniToolStrip"
        Me.miniToolStrip.Size = New System.Drawing.Size(1342, 27)
        Me.miniToolStrip.TabIndex = 0
        '
        'Tap_Planta1
        '
        Me.Tap_Planta1.Controls.Add(Me.pbCargaTxtBuscar)
        Me.Tap_Planta1.Location = New System.Drawing.Point(4, 25)
        Me.Tap_Planta1.Margin = New System.Windows.Forms.Padding(4)
        Me.Tap_Planta1.Name = "Tap_Planta1"
        Me.Tap_Planta1.Padding = New System.Windows.Forms.Padding(13, 12, 13, 12)
        Me.Tap_Planta1.Size = New System.Drawing.Size(1368, 743)
        Me.Tap_Planta1.TabIndex = 1
        Me.Tap_Planta1.Text = "Planta 1"
        Me.Tap_Planta1.UseVisualStyleBackColor = True
        '
        'pbCargaTxtBuscar
        '
        Me.pbCargaTxtBuscar.Location = New System.Drawing.Point(-2, 730)
        Me.pbCargaTxtBuscar.Name = "pbCargaTxtBuscar"
        Me.pbCargaTxtBuscar.Size = New System.Drawing.Size(1208, 23)
        Me.pbCargaTxtBuscar.TabIndex = 0
        '
        'tcPlantas
        '
        Me.tcPlantas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcPlantas.Controls.Add(Me.Tap_Planta1)
        Me.tcPlantas.Location = New System.Drawing.Point(-3, 43)
        Me.tcPlantas.Margin = New System.Windows.Forms.Padding(4)
        Me.tcPlantas.Name = "tcPlantas"
        Me.tcPlantas.SelectedIndex = 0
        Me.tcPlantas.Size = New System.Drawing.Size(1376, 772)
        Me.tcPlantas.TabIndex = 45
        '
        'btnCambiarBodega
        '
        Me.btnCambiarBodega.Location = New System.Drawing.Point(1220, 4)
        Me.btnCambiarBodega.Name = "btnCambiarBodega"
        Me.btnCambiarBodega.Size = New System.Drawing.Size(137, 28)
        Me.btnCambiarBodega.TabIndex = 49
        Me.btnCambiarBodega.Text = "Cerrar Diseñador"
        Me.btnCambiarBodega.UseVisualStyleBackColor = True
        '
        'WMS_CroquisBodega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1369, 810)
        Me.Controls.Add(Me.btnCambiarBodega)
        Me.Controls.Add(Me.btn_NuevaBodega)
        Me.Controls.Add(Me.tcPlantas)
        Me.Controls.Add(Me.Button108)
        Me.Controls.Add(Me.txtBuscarArticulo)
        Me.Controls.Add(Me.Label20)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "WMS_CroquisBodega"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CroquisBodega"
        Me.Tap_Planta1.ResumeLayout(False)
        Me.tcPlantas.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtBuscarArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Button108 As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btn_NuevaBodega As Button
    Friend WithEvents miniToolStrip As ToolStrip
    Friend WithEvents Tap_Planta1 As TabPage
    Friend WithEvents tcPlantas As TabControl
    Friend WithEvents btnCambiarBodega As Button
    Friend WithEvents pbCargaTxtBuscar As ProgressBar
End Class
