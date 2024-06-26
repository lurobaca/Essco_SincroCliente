<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlanillaAsignaEmpleadoARuta
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
        Me.Btn_Asginar = New System.Windows.Forms.Button()
        Me.CboBox_Empleados = New System.Windows.Forms.ComboBox()
        Me.CboBox_Rutas = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGV_Asignaciones = New System.Windows.Forms.DataGridView()
        Me.DateTP_Inicial = New System.Windows.Forms.DateTimePicker()
        Me.DateTP_Final = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Btn_Buscar = New System.Windows.Forms.Button()
        Me.Btn_EliminaAsignacion = New System.Windows.Forms.Button()
        Me.DateTP_FechaAsignacion = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_Nuevo = New System.Windows.Forms.Button()
        CType(Me.DataGV_Asignaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_Asginar
        '
        Me.Btn_Asginar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Asginar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Asginar.Location = New System.Drawing.Point(855, 9)
        Me.Btn_Asginar.Name = "Btn_Asginar"
        Me.Btn_Asginar.Size = New System.Drawing.Size(121, 74)
        Me.Btn_Asginar.TabIndex = 0
        Me.Btn_Asginar.Text = "Aignar"
        Me.Btn_Asginar.UseVisualStyleBackColor = True
        '
        'CboBox_Empleados
        '
        Me.CboBox_Empleados.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboBox_Empleados.FormattingEnabled = True
        Me.CboBox_Empleados.Location = New System.Drawing.Point(131, 9)
        Me.CboBox_Empleados.Name = "CboBox_Empleados"
        Me.CboBox_Empleados.Size = New System.Drawing.Size(453, 33)
        Me.CboBox_Empleados.TabIndex = 1
        '
        'CboBox_Rutas
        '
        Me.CboBox_Rutas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboBox_Rutas.FormattingEnabled = True
        Me.CboBox_Rutas.Location = New System.Drawing.Point(131, 53)
        Me.CboBox_Rutas.Name = "CboBox_Rutas"
        Me.CboBox_Rutas.Size = New System.Drawing.Size(453, 33)
        Me.CboBox_Rutas.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 25)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Empleado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 25)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Ruta"
        '
        'DataGV_Asignaciones
        '
        Me.DataGV_Asignaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGV_Asignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGV_Asignaciones.Location = New System.Drawing.Point(2, 92)
        Me.DataGV_Asignaciones.Name = "DataGV_Asignaciones"
        Me.DataGV_Asignaciones.RowTemplate.Height = 24
        Me.DataGV_Asignaciones.Size = New System.Drawing.Size(1397, 529)
        Me.DataGV_Asignaciones.TabIndex = 5
        '
        'DateTP_Inicial
        '
        Me.DateTP_Inicial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTP_Inicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTP_Inicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTP_Inicial.Location = New System.Drawing.Point(1250, 7)
        Me.DateTP_Inicial.Name = "DateTP_Inicial"
        Me.DateTP_Inicial.Size = New System.Drawing.Size(137, 30)
        Me.DateTP_Inicial.TabIndex = 6
        '
        'DateTP_Final
        '
        Me.DateTP_Final.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTP_Final.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTP_Final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTP_Final.Location = New System.Drawing.Point(1250, 51)
        Me.DateTP_Final.Name = "DateTP_Final"
        Me.DateTP_Final.Size = New System.Drawing.Size(139, 30)
        Me.DateTP_Final.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1109, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 25)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Fecha Inicial"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1109, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 25)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Fecha Final"
        '
        'Btn_Buscar
        '
        Me.Btn_Buscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Buscar.Location = New System.Drawing.Point(728, 9)
        Me.Btn_Buscar.Name = "Btn_Buscar"
        Me.Btn_Buscar.Size = New System.Drawing.Size(121, 74)
        Me.Btn_Buscar.TabIndex = 10
        Me.Btn_Buscar.Text = "Buscar"
        Me.Btn_Buscar.UseVisualStyleBackColor = True
        '
        'Btn_EliminaAsignacion
        '
        Me.Btn_EliminaAsignacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_EliminaAsignacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_EliminaAsignacion.Location = New System.Drawing.Point(982, 7)
        Me.Btn_EliminaAsignacion.Name = "Btn_EliminaAsignacion"
        Me.Btn_EliminaAsignacion.Size = New System.Drawing.Size(121, 74)
        Me.Btn_EliminaAsignacion.TabIndex = 11
        Me.Btn_EliminaAsignacion.Text = "Eliminar"
        Me.Btn_EliminaAsignacion.UseVisualStyleBackColor = True
        '
        'DateTP_FechaAsignacion
        '
        Me.DateTP_FechaAsignacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTP_FechaAsignacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTP_FechaAsignacion.Location = New System.Drawing.Point(131, 92)
        Me.DateTP_FechaAsignacion.Name = "DateTP_FechaAsignacion"
        Me.DateTP_FechaAsignacion.Size = New System.Drawing.Size(453, 30)
        Me.DateTP_FechaAsignacion.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 25)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Fecha"
        '
        'btn_Nuevo
        '
        Me.btn_Nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Nuevo.Location = New System.Drawing.Point(601, 9)
        Me.btn_Nuevo.Name = "btn_Nuevo"
        Me.btn_Nuevo.Size = New System.Drawing.Size(121, 74)
        Me.btn_Nuevo.TabIndex = 12
        Me.btn_Nuevo.Text = "Nuevo"
        Me.btn_Nuevo.UseVisualStyleBackColor = True
        '
        'PlanillaAsignaEmpleadoARuta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1401, 625)
        Me.Controls.Add(Me.btn_Nuevo)
        Me.Controls.Add(Me.Btn_EliminaAsignacion)
        Me.Controls.Add(Me.Btn_Buscar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTP_Final)
        Me.Controls.Add(Me.DateTP_Inicial)
        Me.Controls.Add(Me.DataGV_Asignaciones)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CboBox_Rutas)
        Me.Controls.Add(Me.CboBox_Empleados)
        Me.Controls.Add(Me.Btn_Asginar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DateTP_FechaAsignacion)
        Me.Name = "PlanillaAsignaEmpleadoARuta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PlanillaAsignaEmpleadoARuta"
        CType(Me.DataGV_Asignaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_Asginar As Button
    Friend WithEvents CboBox_Empleados As ComboBox
    Friend WithEvents CboBox_Rutas As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DataGV_Asignaciones As DataGridView
    Friend WithEvents DateTP_Inicial As DateTimePicker
    Friend WithEvents DateTP_Final As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Btn_Buscar As Button
    Friend WithEvents Btn_EliminaAsignacion As Button
    Friend WithEvents DateTP_FechaAsignacion As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents btn_Nuevo As Button
End Class
