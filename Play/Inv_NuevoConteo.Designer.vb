<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inv_NuevoConteo
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
        Me.Txtb_Titulo = New System.Windows.Forms.TextBox
        Me.Txtb_Comentario = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Btn_Crear_Subir = New System.Windows.Forms.Button
        Me.ProgBar = New System.Windows.Forms.ProgressBar
        Me.Lbl_Inicio = New System.Windows.Forms.Label
        Me.Lbl_Fin = New System.Windows.Forms.Label
        Me.Lbl_Detaller = New System.Windows.Forms.Label
        Me.Timer_ProgresBar = New System.Windows.Forms.Timer(Me.components)
        Me.Btn_Sigt = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Titulo"
        '
        'Txtb_Titulo
        '
        Me.Txtb_Titulo.Location = New System.Drawing.Point(6, 29)
        Me.Txtb_Titulo.Name = "Txtb_Titulo"
        Me.Txtb_Titulo.Size = New System.Drawing.Size(260, 20)
        Me.Txtb_Titulo.TabIndex = 1
        '
        'Txtb_Comentario
        '
        Me.Txtb_Comentario.Location = New System.Drawing.Point(6, 68)
        Me.Txtb_Comentario.Multiline = True
        Me.Txtb_Comentario.Name = "Txtb_Comentario"
        Me.Txtb_Comentario.Size = New System.Drawing.Size(260, 72)
        Me.Txtb_Comentario.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Comentario"
        '
        'Btn_Crear_Subir
        '
        Me.Btn_Crear_Subir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Crear_Subir.Location = New System.Drawing.Point(6, 158)
        Me.Btn_Crear_Subir.Name = "Btn_Crear_Subir"
        Me.Btn_Crear_Subir.Size = New System.Drawing.Size(260, 26)
        Me.Btn_Crear_Subir.TabIndex = 6
        Me.Btn_Crear_Subir.Text = "Crear y Subir"
        Me.Btn_Crear_Subir.UseVisualStyleBackColor = True
        '
        'ProgBar
        '
        Me.ProgBar.Location = New System.Drawing.Point(6, 212)
        Me.ProgBar.Name = "ProgBar"
        Me.ProgBar.Size = New System.Drawing.Size(260, 23)
        Me.ProgBar.TabIndex = 7
        '
        'Lbl_Inicio
        '
        Me.Lbl_Inicio.AutoSize = True
        Me.Lbl_Inicio.Location = New System.Drawing.Point(9, 196)
        Me.Lbl_Inicio.Name = "Lbl_Inicio"
        Me.Lbl_Inicio.Size = New System.Drawing.Size(32, 13)
        Me.Lbl_Inicio.TabIndex = 8
        Me.Lbl_Inicio.Text = "Inicio"
        '
        'Lbl_Fin
        '
        Me.Lbl_Fin.AutoSize = True
        Me.Lbl_Fin.Location = New System.Drawing.Point(245, 196)
        Me.Lbl_Fin.Name = "Lbl_Fin"
        Me.Lbl_Fin.Size = New System.Drawing.Size(21, 13)
        Me.Lbl_Fin.TabIndex = 9
        Me.Lbl_Fin.Text = "Fin"
        '
        'Lbl_Detaller
        '
        Me.Lbl_Detaller.AutoSize = True
        Me.Lbl_Detaller.Location = New System.Drawing.Point(11, 238)
        Me.Lbl_Detaller.Name = "Lbl_Detaller"
        Me.Lbl_Detaller.Size = New System.Drawing.Size(40, 13)
        Me.Lbl_Detaller.TabIndex = 10
        Me.Lbl_Detaller.Text = "Detalle"
        '
        'Timer_ProgresBar
        '
        Me.Timer_ProgresBar.Enabled = True
        '
        'Btn_Sigt
        '
        Me.Btn_Sigt.Enabled = False
        Me.Btn_Sigt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Sigt.Location = New System.Drawing.Point(6, 259)
        Me.Btn_Sigt.Name = "Btn_Sigt"
        Me.Btn_Sigt.Size = New System.Drawing.Size(260, 26)
        Me.Btn_Sigt.TabIndex = 11
        Me.Btn_Sigt.Text = "Siguiente"
        Me.Btn_Sigt.UseVisualStyleBackColor = True
        '
        'NuevoConteo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(278, 289)
        Me.Controls.Add(Me.Btn_Sigt)
        Me.Controls.Add(Me.Lbl_Detaller)
        Me.Controls.Add(Me.Lbl_Fin)
        Me.Controls.Add(Me.Lbl_Inicio)
        Me.Controls.Add(Me.ProgBar)
        Me.Controls.Add(Me.Btn_Crear_Subir)
        Me.Controls.Add(Me.Txtb_Comentario)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txtb_Titulo)
        Me.Controls.Add(Me.Label1)
        Me.Name = "NuevoConteo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NuevoConteo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txtb_Titulo As System.Windows.Forms.TextBox
    Friend WithEvents Txtb_Comentario As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Btn_Crear_Subir As System.Windows.Forms.Button
    Friend WithEvents ProgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Lbl_Inicio As System.Windows.Forms.Label
    Friend WithEvents Lbl_Fin As System.Windows.Forms.Label
    Friend WithEvents Lbl_Detaller As System.Windows.Forms.Label
    Friend WithEvents Timer_ProgresBar As System.Windows.Forms.Timer
    Friend WithEvents Btn_Sigt As System.Windows.Forms.Button
End Class
