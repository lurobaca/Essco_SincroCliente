﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Choferes
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label11 = New System.Windows.Forms.Label
        Me.CBx_Puesto = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtb_Cedula = New System.Windows.Forms.TextBox
        Me.DGV_Agentes = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtb_ConsDevoluciones = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtb_ConsGastos = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtb_ConsSinVisitas = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtb_ConsPe = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtb_ConsePag = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtb_ConsDep = New System.Windows.Forms.TextBox
        Me.txtb_Correo = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtb_RutaFTP = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtb_Cod = New System.Windows.Forms.TextBox
        Me.txtb_Nombre = New System.Windows.Forms.TextBox
        Me.txtb_telf = New System.Windows.Forms.TextBox
        Me.btn_AgNuevo = New System.Windows.Forms.Button
        Me.btn_AgElimina = New System.Windows.Forms.Button
        Me.btn_AgGuardar = New System.Windows.Forms.Button
        Me.btn_AgModif = New System.Windows.Forms.Button
        Me.Panel2.SuspendLayout()
        CType(Me.DGV_Agentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.CBx_Puesto)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtb_Cedula)
        Me.Panel2.Controls.Add(Me.DGV_Agentes)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.txtb_Correo)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txtb_RutaFTP)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txtb_Cod)
        Me.Panel2.Controls.Add(Me.txtb_Nombre)
        Me.Panel2.Controls.Add(Me.txtb_telf)
        Me.Panel2.Controls.Add(Me.btn_AgNuevo)
        Me.Panel2.Controls.Add(Me.btn_AgElimina)
        Me.Panel2.Controls.Add(Me.btn_AgGuardar)
        Me.Panel2.Controls.Add(Me.btn_AgModif)
        Me.Panel2.Location = New System.Drawing.Point(1, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(993, 387)
        Me.Panel2.TabIndex = 20
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(236, 245)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Puesto"
        '
        'CBx_Puesto
        '
        Me.CBx_Puesto.FormattingEnabled = True
        Me.CBx_Puesto.Items.AddRange(New Object() {"CHOFER", "AYUDANTE"})
        Me.CBx_Puesto.Location = New System.Drawing.Point(239, 260)
        Me.CBx_Puesto.Name = "CBx_Puesto"
        Me.CBx_Puesto.Size = New System.Drawing.Size(141, 21)
        Me.CBx_Puesto.TabIndex = 26
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(291, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Cedula"
        '
        'txtb_Cedula
        '
        Me.txtb_Cedula.Location = New System.Drawing.Point(292, 27)
        Me.txtb_Cedula.Name = "txtb_Cedula"
        Me.txtb_Cedula.Size = New System.Drawing.Size(113, 20)
        Me.txtb_Cedula.TabIndex = 1
        '
        'DGV_Agentes
        '
        Me.DGV_Agentes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_Agentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Agentes.Location = New System.Drawing.Point(474, 11)
        Me.DGV_Agentes.Name = "DGV_Agentes"
        Me.DGV_Agentes.ReadOnly = True
        Me.DGV_Agentes.Size = New System.Drawing.Size(505, 360)
        Me.DGV_Agentes.TabIndex = 21
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtb_ConsDevoluciones)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtb_ConsGastos)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtb_ConsSinVisitas)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtb_ConsPe)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtb_ConsePag)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtb_ConsDep)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 137)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(392, 104)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consecutivos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(265, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Devoluciones"
        '
        'txtb_ConsDevoluciones
        '
        Me.txtb_ConsDevoluciones.Location = New System.Drawing.Point(268, 78)
        Me.txtb_ConsDevoluciones.Name = "txtb_ConsDevoluciones"
        Me.txtb_ConsDevoluciones.Size = New System.Drawing.Size(100, 20)
        Me.txtb_ConsDevoluciones.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Gastos"
        '
        'txtb_ConsGastos
        '
        Me.txtb_ConsGastos.Location = New System.Drawing.Point(9, 78)
        Me.txtb_ConsGastos.Name = "txtb_ConsGastos"
        Me.txtb_ConsGastos.Size = New System.Drawing.Size(100, 20)
        Me.txtb_ConsGastos.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(138, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Sin Visitas"
        '
        'txtb_ConsSinVisitas
        '
        Me.txtb_ConsSinVisitas.Location = New System.Drawing.Point(141, 78)
        Me.txtb_ConsSinVisitas.Name = "txtb_ConsSinVisitas"
        Me.txtb_ConsSinVisitas.Size = New System.Drawing.Size(100, 20)
        Me.txtb_ConsSinVisitas.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Pedidos"
        '
        'txtb_ConsPe
        '
        Me.txtb_ConsPe.Location = New System.Drawing.Point(11, 32)
        Me.txtb_ConsPe.Name = "txtb_ConsPe"
        Me.txtb_ConsPe.Size = New System.Drawing.Size(100, 20)
        Me.txtb_ConsPe.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(138, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Cobros"
        '
        'txtb_ConsePag
        '
        Me.txtb_ConsePag.Location = New System.Drawing.Point(141, 32)
        Me.txtb_ConsePag.Name = "txtb_ConsePag"
        Me.txtb_ConsePag.Size = New System.Drawing.Size(100, 20)
        Me.txtb_ConsePag.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(265, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Depositos"
        '
        'txtb_ConsDep
        '
        Me.txtb_ConsDep.Location = New System.Drawing.Point(268, 32)
        Me.txtb_ConsDep.Name = "txtb_ConsDep"
        Me.txtb_ConsDep.Size = New System.Drawing.Size(100, 20)
        Me.txtb_ConsDep.TabIndex = 6
        '
        'txtb_Correo
        '
        Me.txtb_Correo.Location = New System.Drawing.Point(13, 260)
        Me.txtb_Correo.Name = "txtb_Correo"
        Me.txtb_Correo.Size = New System.Drawing.Size(191, 20)
        Me.txtb_Correo.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(13, 244)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(38, 13)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Correo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Codigo "
        '
        'txtb_RutaFTP
        '
        Me.txtb_RutaFTP.Location = New System.Drawing.Point(13, 299)
        Me.txtb_RutaFTP.Name = "txtb_RutaFTP"
        Me.txtb_RutaFTP.Size = New System.Drawing.Size(367, 20)
        Me.txtb_RutaFTP.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Nombre"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(14, 283)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 13)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "Ruta FTP"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 95)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Telefono"
        '
        'txtb_Cod
        '
        Me.txtb_Cod.Location = New System.Drawing.Point(18, 27)
        Me.txtb_Cod.Name = "txtb_Cod"
        Me.txtb_Cod.Size = New System.Drawing.Size(100, 20)
        Me.txtb_Cod.TabIndex = 0
        '
        'txtb_Nombre
        '
        Me.txtb_Nombre.Location = New System.Drawing.Point(18, 69)
        Me.txtb_Nombre.Name = "txtb_Nombre"
        Me.txtb_Nombre.Size = New System.Drawing.Size(387, 20)
        Me.txtb_Nombre.TabIndex = 2
        '
        'txtb_telf
        '
        Me.txtb_telf.Location = New System.Drawing.Point(22, 111)
        Me.txtb_telf.Name = "txtb_telf"
        Me.txtb_telf.Size = New System.Drawing.Size(100, 20)
        Me.txtb_telf.TabIndex = 3
        '
        'btn_AgNuevo
        '
        Me.btn_AgNuevo.Location = New System.Drawing.Point(16, 333)
        Me.btn_AgNuevo.Name = "btn_AgNuevo"
        Me.btn_AgNuevo.Size = New System.Drawing.Size(75, 38)
        Me.btn_AgNuevo.TabIndex = 11
        Me.btn_AgNuevo.Text = "Nuevo"
        Me.btn_AgNuevo.UseVisualStyleBackColor = True
        '
        'btn_AgElimina
        '
        Me.btn_AgElimina.Enabled = False
        Me.btn_AgElimina.Location = New System.Drawing.Point(259, 333)
        Me.btn_AgElimina.Name = "btn_AgElimina"
        Me.btn_AgElimina.Size = New System.Drawing.Size(75, 38)
        Me.btn_AgElimina.TabIndex = 10
        Me.btn_AgElimina.Text = "Eliminar"
        Me.btn_AgElimina.UseVisualStyleBackColor = True
        '
        'btn_AgGuardar
        '
        Me.btn_AgGuardar.Location = New System.Drawing.Point(97, 333)
        Me.btn_AgGuardar.Name = "btn_AgGuardar"
        Me.btn_AgGuardar.Size = New System.Drawing.Size(75, 38)
        Me.btn_AgGuardar.TabIndex = 8
        Me.btn_AgGuardar.Text = "Guardar"
        Me.btn_AgGuardar.UseVisualStyleBackColor = True
        '
        'btn_AgModif
        '
        Me.btn_AgModif.Enabled = False
        Me.btn_AgModif.Location = New System.Drawing.Point(178, 333)
        Me.btn_AgModif.Name = "btn_AgModif"
        Me.btn_AgModif.Size = New System.Drawing.Size(75, 38)
        Me.btn_AgModif.TabIndex = 9
        Me.btn_AgModif.Text = "Modificar"
        Me.btn_AgModif.UseVisualStyleBackColor = True
        '
        'Admin_Choferes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 380)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.Name = "Admin_Choferes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administra Chofer y Ayudantes"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DGV_Agentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtb_Cedula As System.Windows.Forms.TextBox
    Friend WithEvents DGV_Agentes As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtb_ConsDevoluciones As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtb_ConsGastos As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtb_ConsSinVisitas As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtb_ConsPe As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtb_ConsePag As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtb_ConsDep As System.Windows.Forms.TextBox
    Friend WithEvents txtb_Correo As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtb_RutaFTP As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtb_Cod As System.Windows.Forms.TextBox
    Friend WithEvents txtb_Nombre As System.Windows.Forms.TextBox
    Friend WithEvents txtb_telf As System.Windows.Forms.TextBox
    Friend WithEvents btn_AgNuevo As System.Windows.Forms.Button
    Friend WithEvents btn_AgElimina As System.Windows.Forms.Button
    Friend WithEvents btn_AgGuardar As System.Windows.Forms.Button
    Friend WithEvents btn_AgModif As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CBx_Puesto As System.Windows.Forms.ComboBox
End Class
