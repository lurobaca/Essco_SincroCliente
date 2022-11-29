<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WMS_MantenimientoBodegas
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
        Me.lblIdBodega = New System.Windows.Forms.Label()
        Me.txtIdBodega = New System.Windows.Forms.TextBox()
        Me.cbPredeterminado = New System.Windows.Forms.CheckBox()
        Me.lblInfoEncabezado = New System.Windows.Forms.Label()
        Me.txtUbicacion = New System.Windows.Forms.TextBox()
        Me.txtNombreBodega = New System.Windows.Forms.TextBox()
        Me.lblUbicacion = New System.Windows.Forms.Label()
        Me.lblNombreBodega = New System.Windows.Forms.Label()
        Me.lblInfoDetalle2 = New System.Windows.Forms.Label()
        Me.lblY = New System.Windows.Forms.Label()
        Me.lblColumnas = New System.Windows.Forms.Label()
        Me.lblRack = New System.Windows.Forms.Label()
        Me.txtColumnas = New System.Windows.Forms.TextBox()
        Me.txtRacks = New System.Windows.Forms.TextBox()
        Me.lblInfoDetalle = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.dgvBodegas = New System.Windows.Forms.DataGridView()
        Me.lblInfoDGV = New System.Windows.Forms.Label()
        Me.lblInfoDGV2 = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblInfoDGV3 = New System.Windows.Forms.Label()
        Me.lblInfoDGV4 = New System.Windows.Forms.Label()
        Me.pbCarga = New System.Windows.Forms.ProgressBar()
        Me.gbInfoBodega = New System.Windows.Forms.GroupBox()
        Me.gbInfoRack = New System.Windows.Forms.GroupBox()
        CType(Me.dgvBodegas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbInfoBodega.SuspendLayout()
        Me.gbInfoRack.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblIdBodega
        '
        Me.lblIdBodega.AutoSize = True
        Me.lblIdBodega.Location = New System.Drawing.Point(20, 56)
        Me.lblIdBodega.Name = "lblIdBodega"
        Me.lblIdBodega.Size = New System.Drawing.Size(72, 16)
        Me.lblIdBodega.TabIndex = 0
        Me.lblIdBodega.Text = "ID Bodega"
        '
        'txtIdBodega
        '
        Me.txtIdBodega.Enabled = False
        Me.txtIdBodega.Location = New System.Drawing.Point(102, 53)
        Me.txtIdBodega.Name = "txtIdBodega"
        Me.txtIdBodega.Size = New System.Drawing.Size(48, 22)
        Me.txtIdBodega.TabIndex = 1
        '
        'cbPredeterminado
        '
        Me.cbPredeterminado.AutoSize = True
        Me.cbPredeterminado.Location = New System.Drawing.Point(576, 78)
        Me.cbPredeterminado.Name = "cbPredeterminado"
        Me.cbPredeterminado.Size = New System.Drawing.Size(126, 20)
        Me.cbPredeterminado.TabIndex = 6
        Me.cbPredeterminado.Text = "Predeterminada"
        Me.cbPredeterminado.UseVisualStyleBackColor = True
        '
        'lblInfoEncabezado
        '
        Me.lblInfoEncabezado.AutoSize = True
        Me.lblInfoEncabezado.Location = New System.Drawing.Point(20, 29)
        Me.lblInfoEncabezado.Name = "lblInfoEncabezado"
        Me.lblInfoEncabezado.Size = New System.Drawing.Size(275, 16)
        Me.lblInfoEncabezado.TabIndex = 5
        Me.lblInfoEncabezado.Text = "Indique el Nombre y Ubicacion de la bodega"
        '
        'txtUbicacion
        '
        Me.txtUbicacion.Location = New System.Drawing.Point(102, 106)
        Me.txtUbicacion.Name = "txtUbicacion"
        Me.txtUbicacion.Size = New System.Drawing.Size(600, 22)
        Me.txtUbicacion.TabIndex = 3
        '
        'txtNombreBodega
        '
        Me.txtNombreBodega.Location = New System.Drawing.Point(102, 78)
        Me.txtNombreBodega.Name = "txtNombreBodega"
        Me.txtNombreBodega.Size = New System.Drawing.Size(128, 22)
        Me.txtNombreBodega.TabIndex = 2
        '
        'lblUbicacion
        '
        Me.lblUbicacion.AutoSize = True
        Me.lblUbicacion.Location = New System.Drawing.Point(20, 112)
        Me.lblUbicacion.Name = "lblUbicacion"
        Me.lblUbicacion.Size = New System.Drawing.Size(68, 16)
        Me.lblUbicacion.TabIndex = 2
        Me.lblUbicacion.Text = "Ubicacion"
        '
        'lblNombreBodega
        '
        Me.lblNombreBodega.AutoSize = True
        Me.lblNombreBodega.Location = New System.Drawing.Point(20, 84)
        Me.lblNombreBodega.Name = "lblNombreBodega"
        Me.lblNombreBodega.Size = New System.Drawing.Size(56, 16)
        Me.lblNombreBodega.TabIndex = 0
        Me.lblNombreBodega.Text = "Bodega"
        '
        'lblInfoDetalle2
        '
        Me.lblInfoDetalle2.AutoSize = True
        Me.lblInfoDetalle2.Location = New System.Drawing.Point(18, 48)
        Me.lblInfoDetalle2.Name = "lblInfoDetalle2"
        Me.lblInfoDetalle2.Size = New System.Drawing.Size(490, 16)
        Me.lblInfoDetalle2.TabIndex = 10
        Me.lblInfoDetalle2.Text = "Tomando en cuenta la cantidad máxima de racks y columnas, por ejemplo 20x20."
        '
        'lblY
        '
        Me.lblY.AutoSize = True
        Me.lblY.Location = New System.Drawing.Point(198, 94)
        Me.lblY.Name = "lblY"
        Me.lblY.Size = New System.Drawing.Size(16, 16)
        Me.lblY.TabIndex = 9
        Me.lblY.Text = "Y"
        '
        'lblColumnas
        '
        Me.lblColumnas.AutoSize = True
        Me.lblColumnas.Location = New System.Drawing.Point(255, 72)
        Me.lblColumnas.Name = "lblColumnas"
        Me.lblColumnas.Size = New System.Drawing.Size(130, 16)
        Me.lblColumnas.TabIndex = 8
        Me.lblColumnas.Text = "Cuadros x Columnas"
        '
        'lblRack
        '
        Me.lblRack.AutoSize = True
        Me.lblRack.Location = New System.Drawing.Point(32, 72)
        Me.lblRack.Name = "lblRack"
        Me.lblRack.Size = New System.Drawing.Size(109, 16)
        Me.lblRack.TabIndex = 6
        Me.lblRack.Text = "Cuadros x Racks"
        '
        'txtColumnas
        '
        Me.txtColumnas.Location = New System.Drawing.Point(258, 91)
        Me.txtColumnas.Name = "txtColumnas"
        Me.txtColumnas.Size = New System.Drawing.Size(113, 22)
        Me.txtColumnas.TabIndex = 5
        '
        'txtRacks
        '
        Me.txtRacks.Location = New System.Drawing.Point(35, 91)
        Me.txtRacks.Name = "txtRacks"
        Me.txtRacks.Size = New System.Drawing.Size(113, 22)
        Me.txtRacks.TabIndex = 4
        '
        'lblInfoDetalle
        '
        Me.lblInfoDetalle.AutoSize = True
        Me.lblInfoDetalle.Location = New System.Drawing.Point(18, 30)
        Me.lblInfoDetalle.Name = "lblInfoDetalle"
        Me.lblInfoDetalle.Size = New System.Drawing.Size(546, 16)
        Me.lblInfoDetalle.TabIndex = 6
        Me.lblInfoDetalle.Text = "Indique la cantidad de Racks y Columnas que va a necesitar en esta cuadricula de " &
    "trabajo."
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(45, 296)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(126, 68)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.Text = "Crear"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(639, 296)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(126, 68)
        Me.btnLimpiar.TabIndex = 7
        Me.btnLimpiar.Text = "Limpiar "
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(653, 700)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(126, 68)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnCargar
        '
        Me.btnCargar.Location = New System.Drawing.Point(24, 700)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(126, 68)
        Me.btnCargar.TabIndex = 8
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'dgvBodegas
        '
        Me.dgvBodegas.AllowUserToAddRows = False
        Me.dgvBodegas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBodegas.Location = New System.Drawing.Point(24, 370)
        Me.dgvBodegas.Name = "dgvBodegas"
        Me.dgvBodegas.RowHeadersWidth = 51
        Me.dgvBodegas.RowTemplate.Height = 24
        Me.dgvBodegas.Size = New System.Drawing.Size(756, 247)
        Me.dgvBodegas.TabIndex = 8
        '
        'lblInfoDGV
        '
        Me.lblInfoDGV.AutoSize = True
        Me.lblInfoDGV.Location = New System.Drawing.Point(28, 620)
        Me.lblInfoDGV.Name = "lblInfoDGV"
        Me.lblInfoDGV.Size = New System.Drawing.Size(640, 16)
        Me.lblInfoDGV.TabIndex = 10
        Me.lblInfoDGV.Text = "Si desea editar la información de una bodega, de doble click sobre la bodega a ed" &
    "itar en la tabla superior."
        '
        'lblInfoDGV2
        '
        Me.lblInfoDGV2.AutoSize = True
        Me.lblInfoDGV2.Location = New System.Drawing.Point(28, 636)
        Me.lblInfoDGV2.Name = "lblInfoDGV2"
        Me.lblInfoDGV2.Size = New System.Drawing.Size(664, 16)
        Me.lblInfoDGV2.TabIndex = 11
        Me.lblInfoDGV2.Text = "En caso de diseñar la bodega, seleccione la bodega en la tabla superior y luego d" &
    "e click en el botón ""Cargar""."
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(165, 700)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(126, 68)
        Me.btnEliminar.TabIndex = 12
        Me.btnEliminar.Text = "Eliminar Bodega"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'lblInfoDGV3
        '
        Me.lblInfoDGV3.AutoSize = True
        Me.lblInfoDGV3.Location = New System.Drawing.Point(28, 662)
        Me.lblInfoDGV3.Name = "lblInfoDGV3"
        Me.lblInfoDGV3.Size = New System.Drawing.Size(724, 16)
        Me.lblInfoDGV3.TabIndex = 13
        Me.lblInfoDGV3.Text = "En caso de que necesite eliminar una bodega, verifique que esta no tenga inventar" &
    "io activo, seleccionar la bodega en la "
        '
        'lblInfoDGV4
        '
        Me.lblInfoDGV4.AutoSize = True
        Me.lblInfoDGV4.Location = New System.Drawing.Point(28, 678)
        Me.lblInfoDGV4.Name = "lblInfoDGV4"
        Me.lblInfoDGV4.Size = New System.Drawing.Size(367, 16)
        Me.lblInfoDGV4.TabIndex = 14
        Me.lblInfoDGV4.Text = "tabla superior y luego de click en el botón ""Eliminar Bodega"""
        '
        'pbCarga
        '
        Me.pbCarga.Location = New System.Drawing.Point(0, 785)
        Me.pbCarga.Name = "pbCarga"
        Me.pbCarga.Size = New System.Drawing.Size(804, 23)
        Me.pbCarga.TabIndex = 15
        '
        'gbInfoBodega
        '
        Me.gbInfoBodega.Controls.Add(Me.txtUbicacion)
        Me.gbInfoBodega.Controls.Add(Me.cbPredeterminado)
        Me.gbInfoBodega.Controls.Add(Me.lblIdBodega)
        Me.gbInfoBodega.Controls.Add(Me.txtIdBodega)
        Me.gbInfoBodega.Controls.Add(Me.lblInfoEncabezado)
        Me.gbInfoBodega.Controls.Add(Me.lblNombreBodega)
        Me.gbInfoBodega.Controls.Add(Me.lblUbicacion)
        Me.gbInfoBodega.Controls.Add(Me.txtNombreBodega)
        Me.gbInfoBodega.Location = New System.Drawing.Point(24, 15)
        Me.gbInfoBodega.Name = "gbInfoBodega"
        Me.gbInfoBodega.Size = New System.Drawing.Size(756, 134)
        Me.gbInfoBodega.TabIndex = 16
        Me.gbInfoBodega.TabStop = False
        Me.gbInfoBodega.Text = "Información de bodega"
        '
        'gbInfoRack
        '
        Me.gbInfoRack.Controls.Add(Me.txtColumnas)
        Me.gbInfoRack.Controls.Add(Me.lblInfoDetalle2)
        Me.gbInfoRack.Controls.Add(Me.lblInfoDetalle)
        Me.gbInfoRack.Controls.Add(Me.txtRacks)
        Me.gbInfoRack.Controls.Add(Me.lblY)
        Me.gbInfoRack.Controls.Add(Me.lblRack)
        Me.gbInfoRack.Controls.Add(Me.lblColumnas)
        Me.gbInfoRack.Location = New System.Drawing.Point(24, 155)
        Me.gbInfoRack.Name = "gbInfoRack"
        Me.gbInfoRack.Size = New System.Drawing.Size(755, 130)
        Me.gbInfoRack.TabIndex = 17
        Me.gbInfoRack.TabStop = False
        Me.gbInfoRack.Text = "Racks y Columnas"
        '
        'WMS_MantenimientoBodegas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 801)
        Me.Controls.Add(Me.gbInfoRack)
        Me.Controls.Add(Me.gbInfoBodega)
        Me.Controls.Add(Me.pbCarga)
        Me.Controls.Add(Me.lblInfoDGV4)
        Me.Controls.Add(Me.lblInfoDGV3)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.lblInfoDGV2)
        Me.Controls.Add(Me.lblInfoDGV)
        Me.Controls.Add(Me.dgvBodegas)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Name = "WMS_MantenimientoBodegas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WMS_MantenimientoBodegas"
        CType(Me.dgvBodegas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbInfoBodega.ResumeLayout(False)
        Me.gbInfoBodega.PerformLayout()
        Me.gbInfoRack.ResumeLayout(False)
        Me.gbInfoRack.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblIdBodega As Label
    Friend WithEvents txtIdBodega As TextBox
    Friend WithEvents lblNombreBodega As Label
    Friend WithEvents lblUbicacion As Label
    Friend WithEvents txtUbicacion As TextBox
    Friend WithEvents txtNombreBodega As TextBox
    Friend WithEvents lblInfoEncabezado As Label
    Friend WithEvents lblRack As Label
    Friend WithEvents txtColumnas As TextBox
    Friend WithEvents txtRacks As TextBox
    Friend WithEvents lblInfoDetalle As Label
    Friend WithEvents lblY As Label
    Friend WithEvents lblColumnas As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnCargar As Button
    Friend WithEvents dgvBodegas As DataGridView
    Friend WithEvents lblInfoDetalle2 As Label
    Friend WithEvents cbPredeterminado As CheckBox
    Friend WithEvents lblInfoDGV As Label
    Friend WithEvents lblInfoDGV2 As Label
    Friend WithEvents btnEliminar As Button
    Friend WithEvents lblInfoDGV3 As Label
    Friend WithEvents lblInfoDGV4 As Label
    Friend WithEvents pbCarga As ProgressBar
    Friend WithEvents gbInfoBodega As GroupBox
    Friend WithEvents gbInfoRack As GroupBox
End Class
