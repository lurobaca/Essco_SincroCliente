<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlanillaNueva
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
        Me.components = New System.ComponentModel.Container()
        Me.Btn_NuevaPlanilla = New System.Windows.Forms.Button()
        Me.DTPFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.DTPFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txtb_DescripcionPlanilla = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_Descripcion = New System.Windows.Forms.Label()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.DGV_PasosGeneracionPlanilla = New System.Windows.Forms.DataGridView()
        Me.Timer_VerificaPasosCreacionPlanilla = New System.Windows.Forms.Timer(Me.components)
        Me.CBox_TipoPlanilla = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Lbl_RutaArchivo = New System.Windows.Forms.Label()
        Me.Btn_BuscarArchivo = New System.Windows.Forms.Button()
        Me.TxtBox_RutaArchivo = New System.Windows.Forms.TextBox()
        CType(Me.DGV_PasosGeneracionPlanilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_NuevaPlanilla
        '
        Me.Btn_NuevaPlanilla.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_NuevaPlanilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_NuevaPlanilla.Location = New System.Drawing.Point(553, 184)
        Me.Btn_NuevaPlanilla.Margin = New System.Windows.Forms.Padding(2)
        Me.Btn_NuevaPlanilla.Name = "Btn_NuevaPlanilla"
        Me.Btn_NuevaPlanilla.Size = New System.Drawing.Size(76, 37)
        Me.Btn_NuevaPlanilla.TabIndex = 0
        Me.Btn_NuevaPlanilla.Text = "Crear"
        Me.Btn_NuevaPlanilla.UseVisualStyleBackColor = True
        '
        'DTPFechaInicial
        '
        Me.DTPFechaInicial.Enabled = False
        Me.DTPFechaInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.DTPFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaInicial.Location = New System.Drawing.Point(237, 43)
        Me.DTPFechaInicial.Margin = New System.Windows.Forms.Padding(2)
        Me.DTPFechaInicial.Name = "DTPFechaInicial"
        Me.DTPFechaInicial.Size = New System.Drawing.Size(158, 26)
        Me.DTPFechaInicial.TabIndex = 1
        '
        'DTPFechaFinal
        '
        Me.DTPFechaFinal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTPFechaFinal.Enabled = False
        Me.DTPFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.DTPFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaFinal.Location = New System.Drawing.Point(470, 43)
        Me.DTPFechaFinal.Margin = New System.Windows.Forms.Padding(2)
        Me.DTPFechaFinal.Name = "DTPFechaFinal"
        Me.DTPFechaFinal.Size = New System.Drawing.Size(160, 26)
        Me.DTPFechaFinal.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(233, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Inicial"
        '
        'Txtb_DescripcionPlanilla
        '
        Me.Txtb_DescripcionPlanilla.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txtb_DescripcionPlanilla.BackColor = System.Drawing.Color.White
        Me.Txtb_DescripcionPlanilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Txtb_DescripcionPlanilla.Location = New System.Drawing.Point(237, 114)
        Me.Txtb_DescripcionPlanilla.Margin = New System.Windows.Forms.Padding(2)
        Me.Txtb_DescripcionPlanilla.Multiline = True
        Me.Txtb_DescripcionPlanilla.Name = "Txtb_DescripcionPlanilla"
        Me.Txtb_DescripcionPlanilla.ReadOnly = True
        Me.Txtb_DescripcionPlanilla.Size = New System.Drawing.Size(392, 67)
        Me.Txtb_DescripcionPlanilla.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(466, 11)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Final"
        '
        'txt_Descripcion
        '
        Me.txt_Descripcion.AutoSize = True
        Me.txt_Descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txt_Descripcion.Location = New System.Drawing.Point(233, 83)
        Me.txt_Descripcion.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.txt_Descripcion.Name = "txt_Descripcion"
        Me.txt_Descripcion.Size = New System.Drawing.Size(92, 20)
        Me.txt_Descripcion.TabIndex = 6
        Me.txt_Descripcion.Text = "Descripcion"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Location = New System.Drawing.Point(470, 184)
        Me.Btn_Cancelar.Margin = New System.Windows.Forms.Padding(2)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(76, 37)
        Me.Btn_Cancelar.TabIndex = 7
        Me.Btn_Cancelar.Text = "Cancelar"
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'DGV_PasosGeneracionPlanilla
        '
        Me.DGV_PasosGeneracionPlanilla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_PasosGeneracionPlanilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_PasosGeneracionPlanilla.Location = New System.Drawing.Point(8, 226)
        Me.DGV_PasosGeneracionPlanilla.Margin = New System.Windows.Forms.Padding(2)
        Me.DGV_PasosGeneracionPlanilla.Name = "DGV_PasosGeneracionPlanilla"
        Me.DGV_PasosGeneracionPlanilla.RowTemplate.Height = 24
        Me.DGV_PasosGeneracionPlanilla.Size = New System.Drawing.Size(624, 371)
        Me.DGV_PasosGeneracionPlanilla.TabIndex = 8
        '
        'Timer_VerificaPasosCreacionPlanilla
        '
        Me.Timer_VerificaPasosCreacionPlanilla.Interval = 1000
        '
        'CBox_TipoPlanilla
        '
        Me.CBox_TipoPlanilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.CBox_TipoPlanilla.FormattingEnabled = True
        Me.CBox_TipoPlanilla.Items.AddRange(New Object() {"Ordinaria", "Aguinaldo", "Comisiones"})
        Me.CBox_TipoPlanilla.Location = New System.Drawing.Point(13, 43)
        Me.CBox_TipoPlanilla.Margin = New System.Windows.Forms.Padding(2)
        Me.CBox_TipoPlanilla.Name = "CBox_TipoPlanilla"
        Me.CBox_TipoPlanilla.Size = New System.Drawing.Size(175, 28)
        Me.CBox_TipoPlanilla.TabIndex = 9
        Me.CBox_TipoPlanilla.Text = "Ordinaria"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(9, 11)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Tipo de Planilla"
        '
        'Lbl_RutaArchivo
        '
        Me.Lbl_RutaArchivo.AutoSize = True
        Me.Lbl_RutaArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Lbl_RutaArchivo.Location = New System.Drawing.Point(9, 83)
        Me.Lbl_RutaArchivo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lbl_RutaArchivo.Name = "Lbl_RutaArchivo"
        Me.Lbl_RutaArchivo.Size = New System.Drawing.Size(100, 20)
        Me.Lbl_RutaArchivo.TabIndex = 13
        Me.Lbl_RutaArchivo.Text = "Ruta Archivo"
        Me.Lbl_RutaArchivo.Visible = False
        '
        'Btn_BuscarArchivo
        '
        Me.Btn_BuscarArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_BuscarArchivo.Location = New System.Drawing.Point(13, 143)
        Me.Btn_BuscarArchivo.Margin = New System.Windows.Forms.Padding(2)
        Me.Btn_BuscarArchivo.Name = "Btn_BuscarArchivo"
        Me.Btn_BuscarArchivo.Size = New System.Drawing.Size(174, 37)
        Me.Btn_BuscarArchivo.TabIndex = 14
        Me.Btn_BuscarArchivo.Text = "Buscar"
        Me.Btn_BuscarArchivo.UseVisualStyleBackColor = True
        Me.Btn_BuscarArchivo.Visible = False
        '
        'TxtBox_RutaArchivo
        '
        Me.TxtBox_RutaArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtBox_RutaArchivo.Location = New System.Drawing.Point(13, 114)
        Me.TxtBox_RutaArchivo.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtBox_RutaArchivo.Name = "TxtBox_RutaArchivo"
        Me.TxtBox_RutaArchivo.Size = New System.Drawing.Size(175, 26)
        Me.TxtBox_RutaArchivo.TabIndex = 12
        Me.TxtBox_RutaArchivo.Visible = False
        '
        'PlanillaNueva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 606)
        Me.Controls.Add(Me.Btn_BuscarArchivo)
        Me.Controls.Add(Me.Lbl_RutaArchivo)
        Me.Controls.Add(Me.TxtBox_RutaArchivo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CBox_TipoPlanilla)
        Me.Controls.Add(Me.DGV_PasosGeneracionPlanilla)
        Me.Controls.Add(Me.Btn_NuevaPlanilla)
        Me.Controls.Add(Me.Btn_Cancelar)
        Me.Controls.Add(Me.txt_Descripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txtb_DescripcionPlanilla)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DTPFechaFinal)
        Me.Controls.Add(Me.DTPFechaInicial)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "PlanillaNueva"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PlanillaNueva"
        CType(Me.DGV_PasosGeneracionPlanilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_NuevaPlanilla As Button
    Friend WithEvents DTPFechaInicial As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Txtb_DescripcionPlanilla As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_Descripcion As Label
    Friend WithEvents Btn_Cancelar As Button
    Public WithEvents DTPFechaFinal As DateTimePicker
    Friend WithEvents DGV_PasosGeneracionPlanilla As DataGridView
    Friend WithEvents Timer_VerificaPasosCreacionPlanilla As Timer
    Friend WithEvents CBox_TipoPlanilla As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Lbl_RutaArchivo As Label
    Friend WithEvents Btn_BuscarArchivo As Button
    Friend WithEvents TxtBox_RutaArchivo As TextBox
End Class
