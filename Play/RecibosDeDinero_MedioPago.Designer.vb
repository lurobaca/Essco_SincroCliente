<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecibosDeDinero_MedioPago
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txtb_MontoEfectivo = New System.Windows.Forms.TextBox()
        Me.Btn_BuscarCuentaEfectivo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txtb_CuentaContableEfectivo = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Btn_BuscarCuentaCheque = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txtb_BancoCheque = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txtb_NumeroCheque = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txtb_MontoCheque = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txtb_CuentaContableCheque = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.CBox_BancoTranferencia = New System.Windows.Forms.ComboBox()
        Me.Btn_BuscarCuentaTranferencia = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.btn_AceptarMetodoPago = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(776, 387)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Txtb_MontoEfectivo)
        Me.TabPage1.Controls.Add(Me.Btn_BuscarCuentaEfectivo)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Txtb_CuentaContableEfectivo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(768, 358)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Efectivo"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Monto Efectivo"
        '
        'Txtb_MontoEfectivo
        '
        Me.Txtb_MontoEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_MontoEfectivo.Location = New System.Drawing.Point(156, 70)
        Me.Txtb_MontoEfectivo.Name = "Txtb_MontoEfectivo"
        Me.Txtb_MontoEfectivo.Size = New System.Drawing.Size(220, 27)
        Me.Txtb_MontoEfectivo.TabIndex = 3
        '
        'Btn_BuscarCuentaEfectivo
        '
        Me.Btn_BuscarCuentaEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_BuscarCuentaEfectivo.Location = New System.Drawing.Point(393, 17)
        Me.Btn_BuscarCuentaEfectivo.Name = "Btn_BuscarCuentaEfectivo"
        Me.Btn_BuscarCuentaEfectivo.Size = New System.Drawing.Size(75, 34)
        Me.Btn_BuscarCuentaEfectivo.TabIndex = 2
        Me.Btn_BuscarCuentaEfectivo.Text = "Buscar"
        Me.Btn_BuscarCuentaEfectivo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cuenta Contable"
        '
        'Txtb_CuentaContableEfectivo
        '
        Me.Txtb_CuentaContableEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_CuentaContableEfectivo.Location = New System.Drawing.Point(156, 21)
        Me.Txtb_CuentaContableEfectivo.Name = "Txtb_CuentaContableEfectivo"
        Me.Txtb_CuentaContableEfectivo.Size = New System.Drawing.Size(220, 27)
        Me.Txtb_CuentaContableEfectivo.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Btn_BuscarCuentaCheque)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Txtb_BancoCheque)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Txtb_NumeroCheque)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Txtb_MontoCheque)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Txtb_CuentaContableCheque)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(768, 358)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Cheque"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Btn_BuscarCuentaCheque
        '
        Me.Btn_BuscarCuentaCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_BuscarCuentaCheque.Location = New System.Drawing.Point(406, 19)
        Me.Btn_BuscarCuentaCheque.Name = "Btn_BuscarCuentaCheque"
        Me.Btn_BuscarCuentaCheque.Size = New System.Drawing.Size(75, 34)
        Me.Btn_BuscarCuentaCheque.TabIndex = 13
        Me.Btn_BuscarCuentaCheque.Text = "Buscar"
        Me.Btn_BuscarCuentaCheque.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(19, 184)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Banco Cheque"
        '
        'Txtb_BancoCheque
        '
        Me.Txtb_BancoCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_BancoCheque.Location = New System.Drawing.Point(169, 181)
        Me.Txtb_BancoCheque.Name = "Txtb_BancoCheque"
        Me.Txtb_BancoCheque.Size = New System.Drawing.Size(220, 27)
        Me.Txtb_BancoCheque.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(19, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Numero Cheque"
        '
        'Txtb_NumeroCheque
        '
        Me.Txtb_NumeroCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_NumeroCheque.Location = New System.Drawing.Point(169, 125)
        Me.Txtb_NumeroCheque.Name = "Txtb_NumeroCheque"
        Me.Txtb_NumeroCheque.Size = New System.Drawing.Size(220, 27)
        Me.Txtb_NumeroCheque.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Monto Cheque"
        '
        'Txtb_MontoCheque
        '
        Me.Txtb_MontoCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_MontoCheque.Location = New System.Drawing.Point(169, 68)
        Me.Txtb_MontoCheque.Name = "Txtb_MontoCheque"
        Me.Txtb_MontoCheque.Size = New System.Drawing.Size(220, 27)
        Me.Txtb_MontoCheque.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Cuenta Contable"
        '
        'Txtb_CuentaContableCheque
        '
        Me.Txtb_CuentaContableCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_CuentaContableCheque.Location = New System.Drawing.Point(169, 19)
        Me.Txtb_CuentaContableCheque.Name = "Txtb_CuentaContableCheque"
        Me.Txtb_CuentaContableCheque.Size = New System.Drawing.Size(220, 27)
        Me.Txtb_CuentaContableCheque.TabIndex = 5
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.CBox_BancoTranferencia)
        Me.TabPage3.Controls.Add(Me.Btn_BuscarCuentaTranferencia)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.TextBox2)
        Me.TabPage3.Controls.Add(Me.Label9)
        Me.TabPage3.Controls.Add(Me.TextBox3)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.TextBox4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(768, 358)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Tranferencia"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'CBox_BancoTranferencia
        '
        Me.CBox_BancoTranferencia.FormattingEnabled = True
        Me.CBox_BancoTranferencia.Location = New System.Drawing.Point(204, 184)
        Me.CBox_BancoTranferencia.Name = "CBox_BancoTranferencia"
        Me.CBox_BancoTranferencia.Size = New System.Drawing.Size(220, 24)
        Me.CBox_BancoTranferencia.TabIndex = 22
        '
        'Btn_BuscarCuentaTranferencia
        '
        Me.Btn_BuscarCuentaTranferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_BuscarCuentaTranferencia.Location = New System.Drawing.Point(442, 15)
        Me.Btn_BuscarCuentaTranferencia.Name = "Btn_BuscarCuentaTranferencia"
        Me.Btn_BuscarCuentaTranferencia.Size = New System.Drawing.Size(75, 34)
        Me.Btn_BuscarCuentaTranferencia.TabIndex = 21
        Me.Btn_BuscarCuentaTranferencia.Text = "Buscar"
        Me.Btn_BuscarCuentaTranferencia.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 184)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(156, 20)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Banco Tranferencia"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(17, 128)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(167, 20)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Numero Tranferencia"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(204, 125)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(220, 27)
        Me.TextBox2.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(17, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(154, 20)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Monto Tranferencia"
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(204, 68)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(220, 27)
        Me.TextBox3.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(17, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(133, 20)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Cuenta Contable"
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(204, 19)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(220, 27)
        Me.TextBox4.TabIndex = 13
        '
        'btn_AceptarMetodoPago
        '
        Me.btn_AceptarMetodoPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AceptarMetodoPago.Location = New System.Drawing.Point(661, 405)
        Me.btn_AceptarMetodoPago.Name = "btn_AceptarMetodoPago"
        Me.btn_AceptarMetodoPago.Size = New System.Drawing.Size(123, 33)
        Me.btn_AceptarMetodoPago.TabIndex = 5
        Me.btn_AceptarMetodoPago.Text = "Aceptar"
        Me.btn_AceptarMetodoPago.UseVisualStyleBackColor = True
        '
        'RecibosDeDinero_MedioPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btn_AceptarMetodoPago)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "RecibosDeDinero_MedioPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Metodo de pago"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label2 As Label
    Friend WithEvents Txtb_MontoEfectivo As TextBox
    Friend WithEvents Btn_BuscarCuentaEfectivo As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Txtb_CuentaContableEfectivo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Txtb_MontoCheque As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Txtb_CuentaContableCheque As TextBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Label6 As Label
    Friend WithEvents Txtb_BancoCheque As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Txtb_NumeroCheque As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents btn_AceptarMetodoPago As Button
    Friend WithEvents Btn_BuscarCuentaCheque As Button
    Friend WithEvents Btn_BuscarCuentaTranferencia As Button
    Friend WithEvents CBox_BancoTranferencia As ComboBox
End Class
