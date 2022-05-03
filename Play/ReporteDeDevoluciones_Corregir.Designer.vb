<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteDeDevoluciones_Corregir
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
        Me.cbx_Accion = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tctb_Codigo = New System.Windows.Forms.TextBox
        Me.txtb_Descripcion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtb_Origen = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbx_BodDestino = New System.Windows.Forms.ComboBox
        Me.txtb_cantidad = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtb_cantidadMover = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtb_CodDestino = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.btn_Aceptar = New System.Windows.Forms.Button
        Me.btn_Buscar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cbx_Accion
        '
        Me.cbx_Accion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbx_Accion.FormattingEnabled = True
        Me.cbx_Accion.Items.AddRange(New Object() {"CORRECTO", "CAMBIADO", "TRASLADO"})
        Me.cbx_Accion.Location = New System.Drawing.Point(433, 85)
        Me.cbx_Accion.Name = "cbx_Accion"
        Me.cbx_Accion.Size = New System.Drawing.Size(135, 28)
        Me.cbx_Accion.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 20)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Codigo"
        '
        'tctb_Codigo
        '
        Me.tctb_Codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tctb_Codigo.Location = New System.Drawing.Point(16, 85)
        Me.tctb_Codigo.Name = "tctb_Codigo"
        Me.tctb_Codigo.Size = New System.Drawing.Size(120, 27)
        Me.tctb_Codigo.TabIndex = 13
        '
        'txtb_Descripcion
        '
        Me.txtb_Descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Descripcion.Location = New System.Drawing.Point(16, 32)
        Me.txtb_Descripcion.Name = "txtb_Descripcion"
        Me.txtb_Descripcion.Size = New System.Drawing.Size(552, 27)
        Me.txtb_Descripcion.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 20)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Descripcion"
        '
        'txtb_Origen
        '
        Me.txtb_Origen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Origen.Location = New System.Drawing.Point(146, 85)
        Me.txtb_Origen.Name = "txtb_Origen"
        Me.txtb_Origen.Size = New System.Drawing.Size(152, 27)
        Me.txtb_Origen.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(142, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 20)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Bodega Origen"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(267, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 20)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Bod Destino"
        '
        'cbx_BodDestino
        '
        Me.cbx_BodDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbx_BodDestino.FormattingEnabled = True
        Me.cbx_BodDestino.Items.AddRange(New Object() {"Completo", "M02-Facturado de mas", "M99-Falta por chequear", "M10-Producto Danado", "M11-Producto Cambiado", "M12-Faltante en bodega", "M14-No salio de bodega", "M20-Pronto a vencer", "Otros"})
        Me.cbx_BodDestino.Location = New System.Drawing.Point(271, 140)
        Me.cbx_BodDestino.Name = "cbx_BodDestino"
        Me.cbx_BodDestino.Size = New System.Drawing.Size(152, 28)
        Me.cbx_BodDestino.TabIndex = 18
        '
        'txtb_cantidad
        '
        Me.txtb_cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_cantidad.Location = New System.Drawing.Point(307, 85)
        Me.txtb_cantidad.Name = "txtb_cantidad"
        Me.txtb_cantidad.Size = New System.Drawing.Size(120, 27)
        Me.txtb_cantidad.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(303, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 20)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Cantidad"
        '
        'txtb_cantidadMover
        '
        Me.txtb_cantidadMover.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_cantidadMover.Location = New System.Drawing.Point(433, 141)
        Me.txtb_cantidadMover.Name = "txtb_cantidadMover"
        Me.txtb_cantidadMover.Size = New System.Drawing.Size(120, 27)
        Me.txtb_cantidadMover.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(429, 118)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 20)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Cant a Mover"
        '
        'txtb_CodDestino
        '
        Me.txtb_CodDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_CodDestino.Location = New System.Drawing.Point(16, 142)
        Me.txtb_CodDestino.Name = "txtb_CodDestino"
        Me.txtb_CodDestino.Size = New System.Drawing.Size(120, 27)
        Me.txtb_CodDestino.TabIndex = 25
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(124, 20)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Codigo Destino"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.11881!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(444, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 20)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Accion"
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Aceptar.Location = New System.Drawing.Point(16, 179)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(553, 40)
        Me.btn_Aceptar.TabIndex = 27
        Me.btn_Aceptar.Text = "ACEPTAR"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'btn_Buscar
        '
        Me.btn_Buscar.Image = Global.SincroCliente.My.Resources.Resources.lupa3
        Me.btn_Buscar.Location = New System.Drawing.Point(146, 140)
        Me.btn_Buscar.Name = "btn_Buscar"
        Me.btn_Buscar.Size = New System.Drawing.Size(34, 29)
        Me.btn_Buscar.TabIndex = 28
        Me.btn_Buscar.UseVisualStyleBackColor = True
        '
        'ReporteDeDevoluciones_Corregir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 228)
        Me.Controls.Add(Me.btn_Buscar)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtb_CodDestino)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtb_cantidadMover)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtb_cantidad)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbx_BodDestino)
        Me.Controls.Add(Me.txtb_Origen)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtb_Descripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tctb_Codigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbx_Accion)
        Me.MaximizeBox = False
        Me.Name = "ReporteDeDevoluciones_Corregir"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ReporteDeDevoluciones_Corregir"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbx_Accion As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tctb_Codigo As System.Windows.Forms.TextBox
    Friend WithEvents txtb_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtb_Origen As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbx_BodDestino As System.Windows.Forms.ComboBox
    Friend WithEvents txtb_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtb_cantidadMover As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtb_CodDestino As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_Buscar As System.Windows.Forms.Button
End Class
