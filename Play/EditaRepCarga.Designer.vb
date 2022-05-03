<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditaRepCarga
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_Modificar = New System.Windows.Forms.Button
        Me.Txb_Descripcion = New System.Windows.Forms.TextBox
        Me.Txb_Solicitado = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txb_Cj = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Txb_Unidades = New System.Windows.Forms.TextBox
        Me.cbx_MotivoBodeguero = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Txb_FaltanteBodeguero = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtb_SacadoX = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtb_Sacado = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtb_CheadoX = New System.Windows.Forms.TextBox
        Me.txtb_ChSacado = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Txb_FaltanteChequeador = New System.Windows.Forms.TextBox
        Me.cbx_MotivoChequeador = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.btn_Salir = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Txb_CodArti = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Descripcion"
        '
        'btn_Modificar
        '
        Me.btn_Modificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Modificar.Location = New System.Drawing.Point(16, 368)
        Me.btn_Modificar.Name = "btn_Modificar"
        Me.btn_Modificar.Size = New System.Drawing.Size(95, 32)
        Me.btn_Modificar.TabIndex = 1
        Me.btn_Modificar.Text = "Modificar"
        Me.btn_Modificar.UseVisualStyleBackColor = True
        '
        'Txb_Descripcion
        '
        Me.Txb_Descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Descripcion.Location = New System.Drawing.Point(117, 52)
        Me.Txb_Descripcion.Name = "Txb_Descripcion"
        Me.Txb_Descripcion.ReadOnly = True
        Me.Txb_Descripcion.Size = New System.Drawing.Size(669, 27)
        Me.Txb_Descripcion.TabIndex = 2
        '
        'Txb_Solicitado
        '
        Me.Txb_Solicitado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Solicitado.Location = New System.Drawing.Point(129, 122)
        Me.Txb_Solicitado.Name = "Txb_Solicitado"
        Me.Txb_Solicitado.ReadOnly = True
        Me.Txb_Solicitado.Size = New System.Drawing.Size(130, 27)
        Me.Txb_Solicitado.TabIndex = 4
        Me.Txb_Solicitado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Solicitado"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(277, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Unidades"
        '
        'Txb_Cj
        '
        Me.Txb_Cj.Location = New System.Drawing.Point(64, 26)
        Me.Txb_Cj.Name = "Txb_Cj"
        Me.Txb_Cj.ReadOnly = True
        Me.Txb_Cj.Size = New System.Drawing.Size(78, 27)
        Me.Txb_Cj.TabIndex = 7
        Me.Txb_Cj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Cajas"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(148, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 20)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Con"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(297, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 20)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Unidades"
        '
        'Txb_Unidades
        '
        Me.Txb_Unidades.Location = New System.Drawing.Point(193, 26)
        Me.Txb_Unidades.Name = "Txb_Unidades"
        Me.Txb_Unidades.ReadOnly = True
        Me.Txb_Unidades.Size = New System.Drawing.Size(78, 27)
        Me.Txb_Unidades.TabIndex = 7
        Me.Txb_Unidades.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbx_MotivoBodeguero
        '
        Me.cbx_MotivoBodeguero.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbx_MotivoBodeguero.FormattingEnabled = True
        Me.cbx_MotivoBodeguero.Items.AddRange(New Object() {"Completo", "M02-Facturado de mas", "M99-Falta por chequear", "M10-Producto Danado", "M11-Producto Cambiado", "M12-Faltante en bodega", "M14-No salio de bodega", "M20-Pronto a vencer", "Otros"})
        Me.cbx_MotivoBodeguero.Location = New System.Drawing.Point(108, 145)
        Me.cbx_MotivoBodeguero.Name = "cbx_MotivoBodeguero"
        Me.cbx_MotivoBodeguero.Size = New System.Drawing.Size(197, 28)
        Me.cbx_MotivoBodeguero.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 153)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 20)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Motivo"
        '
        'Txb_FaltanteBodeguero
        '
        Me.Txb_FaltanteBodeguero.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_FaltanteBodeguero.Location = New System.Drawing.Point(108, 112)
        Me.Txb_FaltanteBodeguero.Name = "Txb_FaltanteBodeguero"
        Me.Txb_FaltanteBodeguero.Size = New System.Drawing.Size(78, 27)
        Me.Txb_FaltanteBodeguero.TabIndex = 11
        Me.Txb_FaltanteBodeguero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 116)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 20)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Faltante"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Txb_Cj)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Txb_Unidades)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(386, 96)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 62)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Conversion segun empaque"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtb_SacadoX)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtb_Sacado)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Txb_FaltanteBodeguero)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cbx_MotivoBodeguero)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(16, 174)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(364, 188)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Bodeguero"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 47)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 20)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Empleado"
        '
        'txtb_SacadoX
        '
        Me.txtb_SacadoX.Enabled = False
        Me.txtb_SacadoX.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_SacadoX.Location = New System.Drawing.Point(108, 40)
        Me.txtb_SacadoX.Name = "txtb_SacadoX"
        Me.txtb_SacadoX.Size = New System.Drawing.Size(197, 27)
        Me.txtb_SacadoX.TabIndex = 13
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 81)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 20)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Sacado"
        '
        'txtb_Sacado
        '
        Me.txtb_Sacado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Sacado.Location = New System.Drawing.Point(108, 77)
        Me.txtb_Sacado.Name = "txtb_Sacado"
        Me.txtb_Sacado.ReadOnly = True
        Me.txtb_Sacado.Size = New System.Drawing.Size(78, 27)
        Me.txtb_Sacado.TabIndex = 11
        Me.txtb_Sacado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txtb_CheadoX)
        Me.GroupBox3.Controls.Add(Me.txtb_ChSacado)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Txb_FaltanteChequeador)
        Me.GroupBox3.Controls.Add(Me.cbx_MotivoChequeador)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(386, 174)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(400, 188)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Chequeador"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(16, 43)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(83, 20)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Empleado"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(16, 77)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 20)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Sacado"
        '
        'txtb_CheadoX
        '
        Me.txtb_CheadoX.Enabled = False
        Me.txtb_CheadoX.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_CheadoX.Location = New System.Drawing.Point(128, 43)
        Me.txtb_CheadoX.Name = "txtb_CheadoX"
        Me.txtb_CheadoX.Size = New System.Drawing.Size(197, 27)
        Me.txtb_CheadoX.TabIndex = 15
        '
        'txtb_ChSacado
        '
        Me.txtb_ChSacado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_ChSacado.Location = New System.Drawing.Point(128, 76)
        Me.txtb_ChSacado.Name = "txtb_ChSacado"
        Me.txtb_ChSacado.ReadOnly = True
        Me.txtb_ChSacado.Size = New System.Drawing.Size(78, 27)
        Me.txtb_ChSacado.TabIndex = 17
        Me.txtb_ChSacado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 116)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 20)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Faltante"
        '
        'Txb_FaltanteChequeador
        '
        Me.Txb_FaltanteChequeador.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_FaltanteChequeador.Location = New System.Drawing.Point(128, 109)
        Me.Txb_FaltanteChequeador.Name = "Txb_FaltanteChequeador"
        Me.Txb_FaltanteChequeador.Size = New System.Drawing.Size(78, 27)
        Me.Txb_FaltanteChequeador.TabIndex = 15
        Me.Txb_FaltanteChequeador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbx_MotivoChequeador
        '
        Me.cbx_MotivoChequeador.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbx_MotivoChequeador.FormattingEnabled = True
        Me.cbx_MotivoChequeador.Items.AddRange(New Object() {"Completo", "M02-Facturado de mas", "M99-Falta por chequear", "M10-Producto Danado", "M11-Producto Cambiado", "M12-Faltante en bodega", "M14-No salio de bodega", "M20-Pronto a vencer", "Otros"})
        Me.cbx_MotivoChequeador.Location = New System.Drawing.Point(128, 145)
        Me.cbx_MotivoChequeador.Name = "cbx_MotivoChequeador"
        Me.cbx_MotivoChequeador.Size = New System.Drawing.Size(197, 28)
        Me.cbx_MotivoChequeador.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 153)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 20)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Motivo"
        '
        'btn_Salir
        '
        Me.btn_Salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Salir.Location = New System.Drawing.Point(691, 368)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(95, 32)
        Me.btn_Salir.TabIndex = 15
        Me.btn_Salir.Text = "Salir"
        Me.btn_Salir.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 20)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Codigo"
        '
        'Txb_CodArti
        '
        Me.Txb_CodArti.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_CodArti.Location = New System.Drawing.Point(117, 12)
        Me.Txb_CodArti.Name = "Txb_CodArti"
        Me.Txb_CodArti.ReadOnly = True
        Me.Txb_CodArti.Size = New System.Drawing.Size(87, 27)
        Me.Txb_CodArti.TabIndex = 2
        '
        'EditaRepCarga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 414)
        Me.Controls.Add(Me.btn_Salir)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txb_Solicitado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txb_CodArti)
        Me.Controls.Add(Me.Txb_Descripcion)
        Me.Controls.Add(Me.btn_Modificar)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "EditaRepCarga"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EditaRepCarga"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_Modificar As System.Windows.Forms.Button
    Friend WithEvents Txb_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Txb_Solicitado As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txb_Cj As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txb_Unidades As System.Windows.Forms.TextBox
    Friend WithEvents cbx_MotivoBodeguero As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Txb_FaltanteBodeguero As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txb_FaltanteChequeador As System.Windows.Forms.TextBox
    Friend WithEvents cbx_MotivoChequeador As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txb_CodArti As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtb_Sacado As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtb_ChSacado As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtb_SacadoX As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtb_CheadoX As System.Windows.Forms.TextBox
End Class
