<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inv_Control
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inv_Control))
        Me.dGv_Control = New System.Windows.Forms.DataGridView()
        Me.Txtb_Salidas = New System.Windows.Forms.TextBox()
        Me.Txtb_Entradas = New System.Windows.Forms.TextBox()
        Me.Txtb_Desajuste = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_Filtrar = New System.Windows.Forms.Button()
        Me.Txb_Mayores = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txb_Proveedor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtb_Deescripcion = New System.Windows.Forms.TextBox()
        Me.btn_Recargar = New System.Windows.Forms.Button()
        Me.btn_Buscar = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtb_IdInvetario = New System.Windows.Forms.TextBox()
        Me.LBL_Cerrado = New System.Windows.Forms.Label()
        Me.btn_Exportar = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Lbl_Detaller = New System.Windows.Forms.Label()
        Me.Lbl_Fin = New System.Windows.Forms.Label()
        Me.Lbl_Inicio = New System.Windows.Forms.Label()
        Me.ProgBar = New System.Windows.Forms.ProgressBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtb_InvFinal = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtb_Inicial = New System.Windows.Forms.TextBox()
        Me.btn_ActualizaInventario = New System.Windows.Forms.Button()
        Me.btn_Cruzar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btn_Grupo = New System.Windows.Forms.Button()
        Me.btn_Plantilla = New System.Windows.Forms.Button()
        Me.btn_Corregir = New System.Windows.Forms.Button()
        Me.Gbox_Botones = New System.Windows.Forms.GroupBox()
        Me.btn_Limpiar = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_BuscaChofer = New System.Windows.Forms.Button()
        Me.CBox_Ver = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CBox_Colorear = New System.Windows.Forms.CheckBox()
        CType(Me.dGv_Control, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Gbox_Botones.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dGv_Control
        '
        Me.dGv_Control.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dGv_Control.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dGv_Control.Location = New System.Drawing.Point(198, 60)
        Me.dGv_Control.Name = "dGv_Control"
        Me.dGv_Control.Size = New System.Drawing.Size(943, 460)
        Me.dGv_Control.TabIndex = 0
        '
        'Txtb_Salidas
        '
        Me.Txtb_Salidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_Salidas.Location = New System.Drawing.Point(17, 103)
        Me.Txtb_Salidas.Name = "Txtb_Salidas"
        Me.Txtb_Salidas.ReadOnly = True
        Me.Txtb_Salidas.Size = New System.Drawing.Size(152, 26)
        Me.Txtb_Salidas.TabIndex = 1
        Me.Txtb_Salidas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txtb_Entradas
        '
        Me.Txtb_Entradas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_Entradas.Location = New System.Drawing.Point(17, 156)
        Me.Txtb_Entradas.Name = "Txtb_Entradas"
        Me.Txtb_Entradas.ReadOnly = True
        Me.Txtb_Entradas.Size = New System.Drawing.Size(152, 26)
        Me.Txtb_Entradas.TabIndex = 2
        Me.Txtb_Entradas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txtb_Desajuste
        '
        Me.Txtb_Desajuste.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtb_Desajuste.Location = New System.Drawing.Point(17, 209)
        Me.Txtb_Desajuste.Name = "Txtb_Desajuste"
        Me.Txtb_Desajuste.ReadOnly = True
        Me.Txtb_Desajuste.Size = New System.Drawing.Size(152, 26)
        Me.Txtb_Desajuste.TabIndex = 3
        Me.Txtb_Desajuste.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "SALIDAS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "ENTRADAS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 186)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "DESAJUSTE"
        '
        'btn_Filtrar
        '
        Me.btn_Filtrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Filtrar.Enabled = False
        Me.btn_Filtrar.Location = New System.Drawing.Point(983, 5)
        Me.btn_Filtrar.Name = "btn_Filtrar"
        Me.btn_Filtrar.Size = New System.Drawing.Size(79, 50)
        Me.btn_Filtrar.TabIndex = 17
        Me.btn_Filtrar.Text = "FILTRAR"
        Me.btn_Filtrar.UseVisualStyleBackColor = True
        '
        'Txb_Mayores
        '
        Me.Txb_Mayores.Enabled = False
        Me.Txb_Mayores.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Mayores.Location = New System.Drawing.Point(236, 24)
        Me.Txb_Mayores.Name = "Txb_Mayores"
        Me.Txb_Mayores.Size = New System.Drawing.Size(163, 26)
        Me.Txb_Mayores.TabIndex = 16
        Me.Txb_Mayores.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(233, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(152, 15)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "MAYORES Y MENOR A"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(92, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 15)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "PROVEEDOR"
        '
        'Txb_Proveedor
        '
        Me.Txb_Proveedor.Enabled = False
        Me.Txb_Proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Proveedor.Location = New System.Drawing.Point(92, 27)
        Me.Txb_Proveedor.Name = "Txb_Proveedor"
        Me.Txb_Proveedor.Size = New System.Drawing.Size(100, 26)
        Me.Txb_Proveedor.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(408, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 15)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "DESCRIPCION"
        '
        'txtb_Deescripcion
        '
        Me.txtb_Deescripcion.Enabled = False
        Me.txtb_Deescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Deescripcion.Location = New System.Drawing.Point(405, 24)
        Me.txtb_Deescripcion.Name = "txtb_Deescripcion"
        Me.txtb_Deescripcion.Size = New System.Drawing.Size(412, 26)
        Me.txtb_Deescripcion.TabIndex = 21
        '
        'btn_Recargar
        '
        Me.btn_Recargar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Recargar.Enabled = False
        Me.btn_Recargar.Location = New System.Drawing.Point(98, 7)
        Me.btn_Recargar.Name = "btn_Recargar"
        Me.btn_Recargar.Size = New System.Drawing.Size(94, 53)
        Me.btn_Recargar.TabIndex = 23
        Me.btn_Recargar.Text = "RECARGAR LISTA"
        Me.ToolTip1.SetToolTip(Me.btn_Recargar, "Recarga la lista con los conteos")
        Me.btn_Recargar.UseVisualStyleBackColor = True
        '
        'btn_Buscar
        '
        Me.btn_Buscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Buscar.Location = New System.Drawing.Point(1, 8)
        Me.btn_Buscar.Name = "btn_Buscar"
        Me.btn_Buscar.Size = New System.Drawing.Size(88, 53)
        Me.btn_Buscar.TabIndex = 24
        Me.btn_Buscar.Text = "BUSCA INVENTARIO"
        Me.btn_Buscar.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.BackColor = System.Drawing.Color.Red
        Me.btn_Cerrar.Enabled = False
        Me.btn_Cerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.ForeColor = System.Drawing.SystemColors.Control
        Me.btn_Cerrar.Location = New System.Drawing.Point(17, 412)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(152, 47)
        Me.btn_Cerrar.TabIndex = 25
        Me.btn_Cerrar.Text = "CERRAR"
        Me.btn_Cerrar.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 15)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "NUMERO"
        '
        'txtb_IdInvetario
        '
        Me.txtb_IdInvetario.Enabled = False
        Me.txtb_IdInvetario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_IdInvetario.Location = New System.Drawing.Point(4, 28)
        Me.txtb_IdInvetario.Name = "txtb_IdInvetario"
        Me.txtb_IdInvetario.Size = New System.Drawing.Size(82, 26)
        Me.txtb_IdInvetario.TabIndex = 26
        '
        'LBL_Cerrado
        '
        Me.LBL_Cerrado.AutoSize = True
        Me.LBL_Cerrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_Cerrado.ForeColor = System.Drawing.Color.Red
        Me.LBL_Cerrado.Location = New System.Drawing.Point(21, 372)
        Me.LBL_Cerrado.Name = "LBL_Cerrado"
        Me.LBL_Cerrado.Size = New System.Drawing.Size(130, 26)
        Me.LBL_Cerrado.TabIndex = 28
        Me.LBL_Cerrado.Text = "CERRADO"
        Me.LBL_Cerrado.Visible = False
        '
        'btn_Exportar
        '
        Me.btn_Exportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Exportar.Enabled = False
        Me.btn_Exportar.Location = New System.Drawing.Point(198, 8)
        Me.btn_Exportar.Name = "btn_Exportar"
        Me.btn_Exportar.Size = New System.Drawing.Size(80, 53)
        Me.btn_Exportar.TabIndex = 29
        Me.btn_Exportar.Text = "EXPORTA EXCELL"
        Me.ToolTip1.SetToolTip(Me.btn_Exportar, "Exporta a Excell el Inventario ")
        Me.btn_Exportar.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'Lbl_Detaller
        '
        Me.Lbl_Detaller.AutoSize = True
        Me.Lbl_Detaller.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Detaller.ForeColor = System.Drawing.Color.Green
        Me.Lbl_Detaller.Location = New System.Drawing.Point(39, 29)
        Me.Lbl_Detaller.Name = "Lbl_Detaller"
        Me.Lbl_Detaller.Size = New System.Drawing.Size(59, 17)
        Me.Lbl_Detaller.TabIndex = 33
        Me.Lbl_Detaller.Text = "Detalle"
        '
        'Lbl_Fin
        '
        Me.Lbl_Fin.AutoSize = True
        Me.Lbl_Fin.Location = New System.Drawing.Point(276, 2)
        Me.Lbl_Fin.Name = "Lbl_Fin"
        Me.Lbl_Fin.Size = New System.Drawing.Size(21, 13)
        Me.Lbl_Fin.TabIndex = 32
        Me.Lbl_Fin.Text = "Fin"
        '
        'Lbl_Inicio
        '
        Me.Lbl_Inicio.AutoSize = True
        Me.Lbl_Inicio.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_Inicio.Name = "Lbl_Inicio"
        Me.Lbl_Inicio.Size = New System.Drawing.Size(32, 13)
        Me.Lbl_Inicio.TabIndex = 31
        Me.Lbl_Inicio.Text = "Inicio"
        '
        'ProgBar
        '
        Me.ProgBar.Location = New System.Drawing.Point(41, 3)
        Me.ProgBar.Name = "ProgBar"
        Me.ProgBar.Size = New System.Drawing.Size(229, 23)
        Me.ProgBar.TabIndex = 30
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Lbl_Inicio)
        Me.Panel1.Controls.Add(Me.Lbl_Detaller)
        Me.Panel1.Controls.Add(Me.ProgBar)
        Me.Panel1.Controls.Add(Me.Lbl_Fin)
        Me.Panel1.Location = New System.Drawing.Point(837, 533)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(304, 53)
        Me.Panel1.TabIndex = 34
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 303)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 20)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "FINAL"
        '
        'txtb_InvFinal
        '
        Me.txtb_InvFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_InvFinal.Location = New System.Drawing.Point(17, 326)
        Me.txtb_InvFinal.Name = "txtb_InvFinal"
        Me.txtb_InvFinal.ReadOnly = True
        Me.txtb_InvFinal.Size = New System.Drawing.Size(152, 26)
        Me.txtb_InvFinal.TabIndex = 35
        Me.txtb_InvFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(13, 251)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 20)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "INICIAL"
        '
        'txtb_Inicial
        '
        Me.txtb_Inicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtb_Inicial.Location = New System.Drawing.Point(17, 274)
        Me.txtb_Inicial.Name = "txtb_Inicial"
        Me.txtb_Inicial.ReadOnly = True
        Me.txtb_Inicial.Size = New System.Drawing.Size(152, 26)
        Me.txtb_Inicial.TabIndex = 37
        Me.txtb_Inicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_ActualizaInventario
        '
        Me.btn_ActualizaInventario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_ActualizaInventario.Enabled = False
        Me.btn_ActualizaInventario.Location = New System.Drawing.Point(284, 10)
        Me.btn_ActualizaInventario.Name = "btn_ActualizaInventario"
        Me.btn_ActualizaInventario.Size = New System.Drawing.Size(91, 53)
        Me.btn_ActualizaInventario.TabIndex = 39
        Me.btn_ActualizaInventario.Text = "ACTUALIZA STOCK"
        Me.ToolTip1.SetToolTip(Me.btn_ActualizaInventario, "Actualiza el stock segun el sistema Principal")
        Me.btn_ActualizaInventario.UseVisualStyleBackColor = True
        '
        'btn_Cruzar
        '
        Me.btn_Cruzar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Cruzar.Enabled = False
        Me.btn_Cruzar.Location = New System.Drawing.Point(653, 9)
        Me.btn_Cruzar.Name = "btn_Cruzar"
        Me.btn_Cruzar.Size = New System.Drawing.Size(80, 53)
        Me.btn_Cruzar.TabIndex = 40
        Me.btn_Cruzar.Text = "CRUZAR"
        Me.ToolTip1.SetToolTip(Me.btn_Cruzar, "Abre la ventana para realizar cruces entre los grupos")
        Me.btn_Cruzar.UseVisualStyleBackColor = True
        '
        'btn_Grupo
        '
        Me.btn_Grupo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Grupo.Enabled = False
        Me.btn_Grupo.Location = New System.Drawing.Point(567, 9)
        Me.btn_Grupo.Name = "btn_Grupo"
        Me.btn_Grupo.Size = New System.Drawing.Size(80, 53)
        Me.btn_Grupo.TabIndex = 43
        Me.btn_Grupo.Text = "GRUPOS"
        Me.ToolTip1.SetToolTip(Me.btn_Grupo, "Abre la ventana para realizar cruces entre los grupos")
        Me.btn_Grupo.UseVisualStyleBackColor = True
        '
        'btn_Plantilla
        '
        Me.btn_Plantilla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Plantilla.Enabled = False
        Me.btn_Plantilla.Location = New System.Drawing.Point(748, 8)
        Me.btn_Plantilla.Name = "btn_Plantilla"
        Me.btn_Plantilla.Size = New System.Drawing.Size(80, 53)
        Me.btn_Plantilla.TabIndex = 44
        Me.btn_Plantilla.Text = "PLANTILLA SAP"
        Me.ToolTip1.SetToolTip(Me.btn_Plantilla, "Exporta a Excell el Inventario ")
        Me.btn_Plantilla.UseVisualStyleBackColor = True
        '
        'btn_Corregir
        '
        Me.btn_Corregir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Corregir.Enabled = False
        Me.btn_Corregir.Location = New System.Drawing.Point(467, 10)
        Me.btn_Corregir.Name = "btn_Corregir"
        Me.btn_Corregir.Size = New System.Drawing.Size(94, 53)
        Me.btn_Corregir.TabIndex = 42
        Me.btn_Corregir.Text = "CORREGIR DIFERENCIAS"
        Me.btn_Corregir.UseVisualStyleBackColor = True
        Me.btn_Corregir.Visible = False
        '
        'Gbox_Botones
        '
        Me.Gbox_Botones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Gbox_Botones.Controls.Add(Me.btn_Plantilla)
        Me.Gbox_Botones.Controls.Add(Me.btn_Grupo)
        Me.Gbox_Botones.Controls.Add(Me.btn_Buscar)
        Me.Gbox_Botones.Controls.Add(Me.btn_Corregir)
        Me.Gbox_Botones.Controls.Add(Me.btn_Recargar)
        Me.Gbox_Botones.Controls.Add(Me.btn_Exportar)
        Me.Gbox_Botones.Controls.Add(Me.btn_Cruzar)
        Me.Gbox_Botones.Controls.Add(Me.btn_ActualizaInventario)
        Me.Gbox_Botones.Location = New System.Drawing.Point(3, 526)
        Me.Gbox_Botones.Name = "Gbox_Botones"
        Me.Gbox_Botones.Size = New System.Drawing.Size(828, 62)
        Me.Gbox_Botones.TabIndex = 43
        Me.Gbox_Botones.TabStop = False
        '
        'btn_Limpiar
        '
        Me.btn_Limpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Limpiar.Enabled = False
        Me.btn_Limpiar.Location = New System.Drawing.Point(1068, 5)
        Me.btn_Limpiar.Name = "btn_Limpiar"
        Me.btn_Limpiar.Size = New System.Drawing.Size(74, 50)
        Me.btn_Limpiar.TabIndex = 44
        Me.btn_Limpiar.Text = "LIMPIAR"
        Me.btn_Limpiar.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(17, 17)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(123, 48)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(122, 22)
        Me.ToolStripMenuItem1.Text = "Ocultar"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(122, 22)
        Me.ToolStripMenuItem2.Text = "Monstrar"
        '
        'btn_BuscaChofer
        '
        Me.btn_BuscaChofer.Enabled = False
        Me.btn_BuscaChofer.Image = CType(resources.GetObject("btn_BuscaChofer.Image"), System.Drawing.Image)
        Me.btn_BuscaChofer.Location = New System.Drawing.Point(198, 26)
        Me.btn_BuscaChofer.Name = "btn_BuscaChofer"
        Me.btn_BuscaChofer.Size = New System.Drawing.Size(32, 24)
        Me.btn_BuscaChofer.TabIndex = 46
        Me.btn_BuscaChofer.UseVisualStyleBackColor = True
        '
        'CBox_Ver
        '
        Me.CBox_Ver.Enabled = False
        Me.CBox_Ver.FormattingEnabled = True
        Me.CBox_Ver.Items.AddRange(New Object() {"AJUSTADO", "DESAJUSTADO", "TODO"})
        Me.CBox_Ver.Location = New System.Drawing.Point(837, 29)
        Me.CBox_Ver.Name = "CBox_Ver"
        Me.CBox_Ver.Size = New System.Drawing.Size(121, 21)
        Me.CBox_Ver.TabIndex = 47
        Me.CBox_Ver.Text = "TODO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(840, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 15)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "SOLO VER"
        '
        'CBox_Colorear
        '
        Me.CBox_Colorear.AutoSize = True
        Me.CBox_Colorear.Location = New System.Drawing.Point(52, 484)
        Me.CBox_Colorear.Name = "CBox_Colorear"
        Me.CBox_Colorear.Size = New System.Drawing.Size(65, 17)
        Me.CBox_Colorear.TabIndex = 49
        Me.CBox_Colorear.Text = "Colorear"
        Me.CBox_Colorear.UseVisualStyleBackColor = True
        '
        'Inv_Control
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1146, 591)
        Me.Controls.Add(Me.CBox_Colorear)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CBox_Ver)
        Me.Controls.Add(Me.btn_BuscaChofer)
        Me.Controls.Add(Me.btn_Limpiar)
        Me.Controls.Add(Me.Gbox_Botones)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtb_Inicial)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtb_InvFinal)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LBL_Cerrado)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtb_IdInvetario)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtb_Deescripcion)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Txb_Proveedor)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btn_Filtrar)
        Me.Controls.Add(Me.Txb_Mayores)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txtb_Desajuste)
        Me.Controls.Add(Me.Txtb_Entradas)
        Me.Controls.Add(Me.Txtb_Salidas)
        Me.Controls.Add(Me.dGv_Control)
        Me.Name = "Inv_Control"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dGv_Control, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Gbox_Botones.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dGv_Control As System.Windows.Forms.DataGridView
    Friend WithEvents Txtb_Salidas As System.Windows.Forms.TextBox
    Friend WithEvents Txtb_Entradas As System.Windows.Forms.TextBox
    Friend WithEvents Txtb_Desajuste As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_Filtrar As System.Windows.Forms.Button
    Friend WithEvents Txb_Mayores As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txb_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtb_Deescripcion As System.Windows.Forms.TextBox
    Friend WithEvents btn_Recargar As System.Windows.Forms.Button
    Friend WithEvents btn_Buscar As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtb_IdInvetario As System.Windows.Forms.TextBox
    Friend WithEvents LBL_Cerrado As System.Windows.Forms.Label
    Friend WithEvents btn_Exportar As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Lbl_Detaller As System.Windows.Forms.Label
    Friend WithEvents Lbl_Fin As System.Windows.Forms.Label
    Friend WithEvents Lbl_Inicio As System.Windows.Forms.Label
    Friend WithEvents ProgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtb_InvFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtb_Inicial As System.Windows.Forms.TextBox
    Friend WithEvents btn_ActualizaInventario As System.Windows.Forms.Button
    Friend WithEvents btn_Cruzar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btn_Corregir As System.Windows.Forms.Button
    Friend WithEvents Gbox_Botones As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_Grupo As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents btn_BuscaChofer As Button
    Friend WithEvents CBox_Ver As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents CBox_Colorear As CheckBox
    Friend WithEvents btn_Plantilla As Button
End Class
