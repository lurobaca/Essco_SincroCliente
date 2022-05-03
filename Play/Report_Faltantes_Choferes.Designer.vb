<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Report_Faltantes_Choferes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Report_Faltantes_Choferes))
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btn_Generar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtp_FechaIni = New System.Windows.Forms.DateTimePicker
        Me.dtp_FechaFin = New System.Windows.Forms.DateTimePicker
        Me.btn_BuscaAgente = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtb_NombreAgente = New System.Windows.Forms.TextBox
        Me.txtb_CodAgente = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Btn_Atras = New System.Windows.Forms.Button
        Me.Btn_Adelante = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 121)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(694, 381)
        Me.CrystalReportViewer1.TabIndex = 2
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'btn_Generar
        '
        Me.btn_Generar.Enabled = False
        Me.btn_Generar.Location = New System.Drawing.Point(9, 81)
        Me.btn_Generar.Name = "btn_Generar"
        Me.btn_Generar.Size = New System.Drawing.Size(685, 34)
        Me.btn_Generar.TabIndex = 3
        Me.btn_Generar.Text = "GENERAR"
        Me.btn_Generar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Hasta"
        '
        'dtp_FechaIni
        '
        Me.dtp_FechaIni.Location = New System.Drawing.Point(70, 23)
        Me.dtp_FechaIni.Name = "dtp_FechaIni"
        Me.dtp_FechaIni.Size = New System.Drawing.Size(200, 20)
        Me.dtp_FechaIni.TabIndex = 7
        '
        'dtp_FechaFin
        '
        Me.dtp_FechaFin.Location = New System.Drawing.Point(70, 52)
        Me.dtp_FechaFin.Name = "dtp_FechaFin"
        Me.dtp_FechaFin.Size = New System.Drawing.Size(200, 20)
        Me.dtp_FechaFin.TabIndex = 8
        '
        'btn_BuscaAgente
        '
        Me.btn_BuscaAgente.Image = CType(resources.GetObject("btn_BuscaAgente.Image"), System.Drawing.Image)
        Me.btn_BuscaAgente.Location = New System.Drawing.Point(502, 24)
        Me.btn_BuscaAgente.Name = "btn_BuscaAgente"
        Me.btn_BuscaAgente.Size = New System.Drawing.Size(32, 24)
        Me.btn_BuscaAgente.TabIndex = 58
        Me.btn_BuscaAgente.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(276, 53)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(91, 15)
        Me.Label19.TabIndex = 57
        Me.Label19.Text = "Nombre Chofer"
        '
        'txtb_NombreAgente
        '
        Me.txtb_NombreAgente.Enabled = False
        Me.txtb_NombreAgente.Location = New System.Drawing.Point(396, 53)
        Me.txtb_NombreAgente.Name = "txtb_NombreAgente"
        Me.txtb_NombreAgente.Size = New System.Drawing.Size(298, 20)
        Me.txtb_NombreAgente.TabIndex = 56
        '
        'txtb_CodAgente
        '
        Me.txtb_CodAgente.Enabled = False
        Me.txtb_CodAgente.Location = New System.Drawing.Point(396, 24)
        Me.txtb_CodAgente.Name = "txtb_CodAgente"
        Me.txtb_CodAgente.Size = New System.Drawing.Size(100, 20)
        Me.txtb_CodAgente.TabIndex = 55
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(276, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 15)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Cod Chofer"
        '
        'Btn_Atras
        '
        Me.Btn_Atras.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Atras.BackgroundImage = CType(resources.GetObject("Btn_Atras.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Atras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Atras.Location = New System.Drawing.Point(539, 9)
        Me.Btn_Atras.Name = "Btn_Atras"
        Me.Btn_Atras.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Atras.TabIndex = 84
        Me.Btn_Atras.UseVisualStyleBackColor = False
        '
        'Btn_Adelante
        '
        Me.Btn_Adelante.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Adelante.BackgroundImage = CType(resources.GetObject("Btn_Adelante.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Adelante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Adelante.Location = New System.Drawing.Point(620, 8)
        Me.Btn_Adelante.Name = "Btn_Adelante"
        Me.Btn_Adelante.Size = New System.Drawing.Size(75, 40)
        Me.Btn_Adelante.TabIndex = 83
        Me.Btn_Adelante.UseVisualStyleBackColor = False
        '
        'Report_Faltantes_Choferes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 502)
        Me.Controls.Add(Me.Btn_Atras)
        Me.Controls.Add(Me.Btn_Adelante)
        Me.Controls.Add(Me.btn_BuscaAgente)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtb_NombreAgente)
        Me.Controls.Add(Me.txtb_CodAgente)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtp_FechaFin)
        Me.Controls.Add(Me.dtp_FechaIni)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Generar)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "Report_Faltantes_Choferes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Faltantes Choferes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btn_Generar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_FechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_FechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_BuscaAgente As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtb_NombreAgente As System.Windows.Forms.TextBox
    Friend WithEvents txtb_CodAgente As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Btn_Atras As System.Windows.Forms.Button
    Friend WithEvents Btn_Adelante As System.Windows.Forms.Button
End Class
