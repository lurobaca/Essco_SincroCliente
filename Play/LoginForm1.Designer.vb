<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class LoginForm1
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
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm1))
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.OK = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.Txtb_NuevoPass = New System.Windows.Forms.TextBox()
        Me.lbl_NuevoPass = New System.Windows.Forms.Label()
        Me.Txtb_ConfirmaPass = New System.Windows.Forms.TextBox()
        Me.lbl_ConfirmaPass = New System.Windows.Forms.Label()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Location = New System.Drawing.Point(229, 18)
        Me.UsernameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(293, 28)
        Me.UsernameLabel.TabIndex = 0
        Me.UsernameLabel.Text = "&Nombre de usuario"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Location = New System.Drawing.Point(227, 78)
        Me.PasswordLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(293, 28)
        Me.PasswordLabel.TabIndex = 2
        Me.PasswordLabel.Text = "&Contraseña"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.Location = New System.Drawing.Point(232, 43)
        Me.UsernameTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(292, 22)
        Me.UsernameTextBox.TabIndex = 1
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Location = New System.Drawing.Point(229, 102)
        Me.PasswordTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(292, 22)
        Me.PasswordTextBox.TabIndex = 3
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(257, 240)
        Me.OK.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(125, 28)
        Me.OK.TabIndex = 4
        Me.OK.Text = "&Aceptar"
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(395, 240)
        Me.Cancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(125, 28)
        Me.Cancel.TabIndex = 5
        Me.Cancel.Text = "&Cancelar"
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
        Me.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.LogoPictureBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(220, 274)
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'Txtb_NuevoPass
        '
        Me.Txtb_NuevoPass.Location = New System.Drawing.Point(228, 155)
        Me.Txtb_NuevoPass.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Txtb_NuevoPass.Name = "Txtb_NuevoPass"
        Me.Txtb_NuevoPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txtb_NuevoPass.Size = New System.Drawing.Size(292, 22)
        Me.Txtb_NuevoPass.TabIndex = 10
        Me.Txtb_NuevoPass.Visible = False
        '
        'lbl_NuevoPass
        '
        Me.lbl_NuevoPass.ForeColor = System.Drawing.Color.Red
        Me.lbl_NuevoPass.Location = New System.Drawing.Point(225, 130)
        Me.lbl_NuevoPass.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_NuevoPass.Name = "lbl_NuevoPass"
        Me.lbl_NuevoPass.Size = New System.Drawing.Size(293, 28)
        Me.lbl_NuevoPass.TabIndex = 9
        Me.lbl_NuevoPass.Text = "&Nueva"
        Me.lbl_NuevoPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_NuevoPass.Visible = False
        '
        'Txtb_ConfirmaPass
        '
        Me.Txtb_ConfirmaPass.Location = New System.Drawing.Point(229, 208)
        Me.Txtb_ConfirmaPass.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Txtb_ConfirmaPass.Name = "Txtb_ConfirmaPass"
        Me.Txtb_ConfirmaPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txtb_ConfirmaPass.Size = New System.Drawing.Size(292, 22)
        Me.Txtb_ConfirmaPass.TabIndex = 12
        Me.Txtb_ConfirmaPass.Visible = False
        '
        'lbl_ConfirmaPass
        '
        Me.lbl_ConfirmaPass.ForeColor = System.Drawing.Color.Red
        Me.lbl_ConfirmaPass.Location = New System.Drawing.Point(227, 183)
        Me.lbl_ConfirmaPass.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_ConfirmaPass.Name = "lbl_ConfirmaPass"
        Me.lbl_ConfirmaPass.Size = New System.Drawing.Size(293, 28)
        Me.lbl_ConfirmaPass.TabIndex = 11
        Me.lbl_ConfirmaPass.Text = "&Confirmacion"
        Me.lbl_ConfirmaPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_ConfirmaPass.Visible = False
        '
        'LoginForm1
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(535, 272)
        Me.Controls.Add(Me.Txtb_ConfirmaPass)
        Me.Controls.Add(Me.lbl_ConfirmaPass)
        Me.Controls.Add(Me.Txtb_NuevoPass)
        Me.Controls.Add(Me.lbl_NuevoPass)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(Me.UsernameTextBox)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoginForm1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seguridad"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Txtb_NuevoPass As System.Windows.Forms.TextBox
    Friend WithEvents lbl_NuevoPass As System.Windows.Forms.Label
    Friend WithEvents Txtb_ConfirmaPass As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ConfirmaPass As System.Windows.Forms.Label

End Class
