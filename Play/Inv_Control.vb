Imports System.Data.Odbc
Imports System.Threading

Public Class Inv_Control
    Public Obj_Mformat As New MonedaFormat
    Public Obj_ExpExcell As ExportarAExcell = New ExportarAExcell
    Private trd1 As Thread

    Public idInventario1 As String
    Public busca As String
    Public Obj_VarGlobal As New Class_VariablesGlobales
    Public indice As Integer
    Public menu As ContextMenuStrip
    Private Sub Control_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        WindowState = FormWindowState.Maximized
        Me.dGv_Control.ContextMenuStrip = Me.ContextMenuStrip1


    End Sub
    Public Function lista()
        Try


            Cursor = Cursors.WaitCursor
            '--------------------------------------------------------------------------
            '--------------------------- CONECTAR A MYSQL WEB  ------------------------------
            'Try
            '    If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
            '        Class_VariablesGlobales.MYSQ_Comman.Connection = Obj_VarGlobal.Obj_CX_MYSQL.Conectar()
            '    End If
            'Catch ex As Exception
            '    Class_VariablesGlobales.MYSQ_Comman = New OdbcCommand
            '    Class_VariablesGlobales.MYSQ_Comman.Connection = Obj_VarGlobal.Obj_CX_MYSQL.Conectar()
            'End Try

            Dim TABLA As New DataTable
            'If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Open Then

            ''actualiza los conteos vrs diferencias y stock
            'Obj_Funciones_MYSQL.Corrige(idInventario1)
            Class_VariablesGlobales.Contador = 0
            TABLA = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneInvControl("", 0, 0, busca, idInventario1, True, CBox_Ver.Text)
            Class_VariablesGlobales.frmControl.Lbl_Detaller.Text = "ORGANIZANDO DATOS ESPERE...."
            OrganizarColumnas(TABLA)
            btn_Recargar.Text = "RECARGAR"

            Lbl_Inicio.Text = 0
            ProgBar.Value = 0
            ProgBar.Maximum = 0
            Lbl_Fin.Text = 0
            Class_VariablesGlobales.Contador = 0
            Lbl_Detaller.Text = ""
            Timer1.Stop()

            'Else
            '    MsgBox("Problemas con la conexion intente nuevaente")
            'End If
            Cursor = Cursors.Default
            activa()

        Catch ex As Exception
            MessageBox.Show("ERROR en Listar " & ex.Message)
            Cursor = Cursors.Default

        End Try
    End Function
    Public Function Listar(ByVal Busqueda As String, ByVal idInventario As String)
        busca = Busqueda
        idInventario1 = idInventario

        '__________PROCESO 1_______________
        Timer1.Start()
        trd1 = Nothing
        trd1 = New Thread(AddressOf lista)
        trd1.IsBackground = Enabled
        trd1.Priority = ThreadPriority.AboveNormal
        trd1.Start()
        CheckForIllegalCrossThreadCalls = False

    End Function


    Public Function OrganizarColumnas(ByVal TABLA As DataTable)
        Try
            Dim COTADOR As Integer = 0
            Dim ENTRADAS As Double
            Dim SALIDAS As Double
            Dim VALOR As Double
            Dim Diferencia As Double
            Dim InvFinal As Double
            Dim InvInicial As Double

            Lbl_Inicio.Text = 0
            ProgBar.Value = 0
            ProgBar.Maximum = TABLA.Rows.Count

            Lbl_Fin.Text = TABLA.Rows.Count
            Class_VariablesGlobales.Contador = 0
            Lbl_Detaller.Text = ""
            'If TABLA.Rows.Count > 0 Then
            '    For Each row As DataRow In TABLA.Rows

            '        VALOR = 0
            '        'If CInt(TABLA.Rows(COTADOR).Item("CF").ToString()) <> 0 Then
            '        'Obtiene monto de diferencia
            '        Diferencia = CInt(TABLA.Rows(COTADOR).Item("CF").ToString()) - CInt(TABLA.Rows(COTADOR).Item("Stock").ToString())
            '        VALOR = Diferencia * CDbl(TABLA.Rows(COTADOR).Item("Costo").ToString())
            '        If VALOR > 0 Then
            '            ENTRADAS = ENTRADAS + VALOR
            '        Else
            '            SALIDAS = SALIDAS + VALOR
            '        End If

            '        'End If

            '        InvInicial += CDbl(TABLA.Rows(COTADOR).Item("Monto").ToString())
            '        '`Codigo`,`Descripcion`,`CodBarras`,`Sector`,`Costo`,`Stock_b1`,`C1`,`D1`,`C2`,`D2`,`C3`,`D3`,`C4`,`D4`,`C5`,`D5`,`C6`,`D6`,`C7`,`D7`,`C8`,`D8`

            '        Class_VariablesGlobales.DetalleCarga = TABLA.Rows(COTADOR).Item("Descripcion").ToString()
            '        Class_VariablesGlobales.Contador += 1
            '        COTADOR += 1
            '        ProgBar.Value = COTADOR
            '        Lbl_Fin.Text = COTADOR
            '    Next

            '    Txtb_Entradas.Text = FormatCurrency(ENTRADAS, 2)
            '    Txtb_Salidas.Text = FormatCurrency(SALIDAS, 2)
            '    Txtb_Desajuste.Text = FormatCurrency(ENTRADAS + SALIDAS, 2)
            '    txtb_InvFinal.Text = FormatCurrency((InvInicial + (ENTRADAS + SALIDAS)), 2)
            '    txtb_Inicial.Text = FormatCurrency((InvInicial), 2)

            'End If

            'SELECT `Codigo`,`Descripcion`,`CodBarras`,`Sector`,`Costo`,`Stock_b1`,`C1`,`D1`,`MD1`,`C2`,`D2`,`MD2`,`C3`,`D3`,`MD3`,`C4`,`D4`,`MD4`,`C5`,`D5`,`MD5`,`C6`,`D6`,`MD6`,`C7`,`D7`,`MD7`,`C8`,`D8`,`MD8` FROM `Conteo` 
            'T0.IdInventario,T0.CodProveedor,T0.NameProveedor,T0.Fecha,T0.Codigo,T0.Descripcion,T0.CodBarras,T0.Sector,T0.Costo,T0.Stock,T0.CF,T0.DF,T0.DFM,T0.Monto,

            dGv_Control.DataSource = TABLA
            Dim cuenta As Integer
            For Each dgvRenglon As DataGridViewRow In dGv_Control.Rows
                'CALCULA TOTALES
                VALOR = 0
                If COTADOR < (TABLA.Rows.Count - 1) Then


                    'If CInt(TABLA.Rows(COTADOR).Item("CF").ToString()) <> 0 Then
                    'Obtiene monto de diferencia
                    If dGv_Control.Item("CF", COTADOR).Value.ToString() <> "" Then

                        Diferencia = CInt(dGv_Control.Item("CF", COTADOR).Value.ToString()) - CInt(dGv_Control.Item("Stock", COTADOR).Value.ToString())
                        VALOR = Diferencia * CDbl(dGv_Control.Item("Costo", COTADOR).Value.ToString())
                        If VALOR > 0 Then
                            ENTRADAS = ENTRADAS + VALOR
                        Else
                            SALIDAS = SALIDAS + VALOR
                        End If

                        'End If

                        InvInicial += CDbl(dGv_Control.Item("Monto", COTADOR).Value.ToString())
                        '`Codigo`,`Descripcion`,`CodBarras`,`Sector`,`Costo`,`Stock_b1`,`C1`,`D1`,`C2`,`D2`,`C3`,`D3`,`C4`,`D4`,`C5`,`D5`,`C6`,`D6`,`C7`,`D7`,`C8`,`D8`

                        Class_VariablesGlobales.DetalleCarga = dGv_Control.Item("Descripcion", COTADOR).Value.ToString()
                        Class_VariablesGlobales.Contador += 1
                        COTADOR += 1
                        ProgBar.Value = COTADOR

                    End If

                    If CBox_Colorear.Checked = True Then


                        '---------------- SI HABILITAMOS ESTO SE TRABA----------------------------------------------
                        Dim row As DataGridViewCell = dGv_Control(12, cuenta)
                        Select Case row.Value
                            Case < 0
                                row.Style.BackColor = Color.Red

                                    'CUANDO ES AJUSTADO LO PONE EN VERDE
                                    'dGv_Control.Columns(11).DefaultCellStyle.BackColor = Color.Red
                                    'dGv_Control.Columns(11).DefaultCellStyle.BackColor = Color.Red
                                    'dGv_Control.Columns(12).DefaultCellStyle.BackColor = Color.Red
                            Case > 0
                                row.Style.BackColor = Color.LightBlue
                                    'CUANDO ES MAYOR A CERO ES DECIR CUANDO SOBRA LO PONE EN AZUL
                                    'dGv_Control.Columns(10).DefaultCellStyle.BackColor = Color.LightBlue
                                    'dGv_Control.Columns(11).DefaultCellStyle.BackColor = Color.LightBlue
                                    'dGv_Control.Columns(12).DefaultCellStyle.BackColor = Color.LightBlue
                            Case = 0
                                'row.Style.BackColor = Color.LightGreen
                                'CUANDO ES AJUSTADO LO PONE EN VERDE
                                'dGv_Control.Columns(10).DefaultCellStyle.BackColor = Color.LightGreen
                                'dGv_Control.Columns(11).DefaultCellStyle.BackColor = Color.LightGreen
                                'dGv_Control.Columns(12).DefaultCellStyle.BackColor = Color.LightGreen


                        End Select
                        row = Nothing
                    End If

                End If
                cuenta += 1
            Next


            Txtb_Entradas.Text = FormatCurrency(ENTRADAS, 2)
            Txtb_Salidas.Text = FormatCurrency(SALIDAS, 2)
            Txtb_Desajuste.Text = FormatCurrency(ENTRADAS + SALIDAS, 2)
            txtb_InvFinal.Text = FormatCurrency((InvInicial + (ENTRADAS + SALIDAS)), 2)
            txtb_Inicial.Text = FormatCurrency((InvInicial), 2)

            dGv_Control.RowHeadersVisible = False
            dGv_Control.Columns(0).Width = 40 ' NumLinea
            dGv_Control.Columns(1).Visible = False ' id inventaro

            'dGv_Control.Columns(2).Visible = False 'Cod proveedor
            'dGv_Control.Columns(3).Visible = False 'Nombre proveedor
            dGv_Control.Columns(4).Visible = False 'Fecha
            dGv_Control.Columns(8).Visible = False 'Sector
            dGv_Control.Columns(9).Visible = False 'Costo

            dGv_Control.Columns(2).Width = 40
            dGv_Control.Columns(3).Width = 160

            dGv_Control.Columns(5).Width = 75
            dGv_Control.Columns(6).Width = 390
            dGv_Control.Columns(7).Width = 95
            dGv_Control.Columns(8).Width = 20
            dGv_Control.Columns(9).Width = 80
            dGv_Control.Columns(10).Width = 60
            dGv_Control.Columns(11).Width = 50
            dGv_Control.Columns(12).Width = 50 'MF

            Me.dGv_Control.Columns(13).DefaultCellStyle.Format = "c2"
            dGv_Control.Columns(14).Visible = False 'MF

            If dGv_Control.Columns.GetColumnCount(DataGridViewElementStates.None) > 12 Then
                Dim vueltas As Integer
                Dim Cont As Integer
                Dim Vul As Integer = 0
                vueltas = (dGv_Control.Columns.GetColumnCount(DataGridViewElementStates.None) - 15) / 3
                Cont = 15
                While Vul < vueltas
                    dGv_Control.Columns(Cont).Width = 50
                    dGv_Control.Columns(Cont).DefaultCellStyle.BackColor = Color.Coral

                    Cont += 1

                    dGv_Control.Columns(Cont).Width = 50
                    Cont += 1

                    dGv_Control.Columns(Cont).Width = 100
                    'Formateo la columna Balance
                    Me.dGv_Control.Columns(Cont).DefaultCellStyle.Format = "c2"
                    Cont += 1
                    Vul += 1
                End While

            End If

            Cursor = Cursors.Default

            'dGv_Control.Columns(14).Width = 200

        Catch ex As Exception
            'MsgBox("Error OrganizarColumnas " & ex.Message)

        End Try
    End Function


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Filtrar.Click
        inactiva()
        Filtrar()
        activa()

    End Sub
    Public Function Filtrar()
        Try


            If Txb_Mayores.Text = "" Then
                Dim TAB As DataTable = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneInvControl(Trim(Txb_Proveedor.Text), 0, 0, txtb_Deescripcion.Text, Trim(txtb_IdInvetario.Text), True, CBox_Ver.Text)
                OrganizarColumnas(TAB)
            Else
                Dim TAB As DataTable = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneInvControl(Trim(Txb_Proveedor.Text), CDbl(Txb_Mayores.Text), -CDbl(Txb_Mayores.Text), txtb_Deescripcion.Text, Trim(txtb_IdInvetario.Text), True, CBox_Ver.Text)
                OrganizarColumnas(TAB)
            End If
        Catch ex As Exception

        End Try
    End Function


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtb_Deescripcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            Listar(txtb_Deescripcion.Text, Trim(txtb_IdInvetario.Text))
        Catch ex As Exception
            MsgBox("Error:" & ex.Message)

        End Try


    End Sub

    Private Sub btn_Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Recargar.Click
        inactiva()
        '__________PROCESO 1_______________
        Timer1.Start()
        trd1 = Nothing
        trd1 = New Thread(AddressOf Recargar)
        trd1.IsBackground = Enabled
        trd1.Priority = ThreadPriority.AboveNormal
        trd1.Start()
        CheckForIllegalCrossThreadCalls = False

        btn_Recargar.Text = "Espere..."


    End Sub

    Public Function Recargar()


        Txb_Proveedor.Text = ""
        Txb_Mayores.Text = "0"
        txtb_Deescripcion.Text = ""
        Listar("", Trim(txtb_IdInvetario.Text))
        activa()

    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cerrar.Click
        'CARGA EL INVENTARIO FINAL Y TOTAL EN ENTRADAS SALIDAS Y DIFERENCIAS
        Dim result As Integer = MessageBox.Show("Si Cierra el inventario no podra realizar modificaciones futuras,Realmente desea Cerrar el inventario?", "caption", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.No Then

        ElseIf result = DialogResult.Yes Then
            Class_VariablesGlobales.Obj_Funciones_SQL.CierraInventario(Trim(txtb_IdInvetario.Text), CDbl(Txtb_Entradas.Text), CDbl(Txtb_Salidas.Text), CDbl(Txtb_Desajuste.Text), CDbl(txtb_InvFinal.Text))
            MsgBox("Inventario Cerrado")
            LBL_Cerrado.Visible = True
            btn_Cerrar.Visible = False

        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Buscar.Click


        Class_VariablesGlobales.frmListaInventarios = New Inv_ListaInventarios
        Class_VariablesGlobales.frmListaInventarios.MdiParent = Principal
        Class_VariablesGlobales.frmListaInventarios.Show()
        Class_VariablesGlobales.LlamadoDesdeControl = True

    End Sub

    Private Sub bt_nExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Exportar.Click
        Dim result As Integer = MessageBox.Show("Este proceso puede tardarios unos minutos, esta seguro que desea exportar la lista?", "Alerta", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.No Then

        ElseIf result = DialogResult.Yes Then

            inactiva()

            '__________PROCESO 1_______________
            Timer1.Start()
            trd1 = Nothing
            trd1 = New Thread(AddressOf Exporta)
            trd1.IsBackground = Enabled
            trd1.Priority = ThreadPriority.AboveNormal
            trd1.Start()
            CheckForIllegalCrossThreadCalls = False

            Panel1.Visible = True
            btn_Exportar.Text = "Espere ..."
        End If
    End Sub

    Public Function Exporta()


        Gbox_Botones.Enabled = False

        Me.dGv_Control.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneInvControl("", 0, 0, busca, idInventario1, True, CBox_Ver.Text)


        Obj_ExpExcell.Exportar(Me.dGv_Control, "Inventario Trimestral")
        btn_Exportar.Text = "EXPORTAR"
        Timer1.Stop()
        Gbox_Botones.Enabled = True
    End Function
    Public Function ExportaPlantillaSAP()
        Try



            Gbox_Botones.Enabled = False
            Me.dGv_Control.DataSource = Nothing
            Me.dGv_Control.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.Obtiene_DatosPlantilla("", 0, 0, busca, idInventario1, True, CBox_Ver.Text)


            Obj_ExpExcell.ExportarPlantilla(Me.dGv_Control, "Inventario Trimestral")
            btn_Exportar.Text = "EXPORTAR"
            Timer1.Stop()
            Gbox_Botones.Enabled = True
        Catch ex As Exception

        End Try
    End Function



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try

            'si es mayor o igual que el valor actual 
            If ProgBar.Value <= Class_VariablesGlobales.Contador Then

                Lbl_Inicio.Text = Class_VariablesGlobales.Contador
                Me.ProgBar.Value = Class_VariablesGlobales.Contador
                Lbl_Detaller.Text = CInt(((CInt(Class_VariablesGlobales.Contador) / CInt(ProgBar.Maximum)) * 100)) & "% " & Class_VariablesGlobales.DetalleCarga

            End If

            If Class_VariablesGlobales.TotalLineas <> 0 And Class_VariablesGlobales.Entrar = True Then
                Class_VariablesGlobales.Entrar = False
                Lbl_Fin.Text = Class_VariablesGlobales.TotalLineas
                ProgBar.Maximum = Class_VariablesGlobales.TotalLineas
                ProgBar.Value = 0
                Lbl_Inicio.Text = "0"
            End If

            If Class_VariablesGlobales.ERRORES <> "" Then
                'ListBox_Errores.Items.Add(ERRORES)
                'istBox_Errores.Items.Insert(0, ERRORES)
                Class_VariablesGlobales.ERRORES = ""
            End If

        Catch ex As Exception

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR en Timer_ProgresBar_Tick [" & ex.Message & "]"
        End Try
    End Sub

    Private Sub btn_ActualizaInventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ActualizaInventario.Click
        inactiva()
        '__________PROCESO 1_______________
        Timer1.Start()
        trd1 = Nothing
        trd1 = New Thread(AddressOf ActualizaStock)
        trd1.IsBackground = Enabled
        trd1.Priority = ThreadPriority.Highest
        trd1.Start()
        CheckForIllegalCrossThreadCalls = False
    End Sub
    Public Function inactiva()
        btn_ActualizaInventario.Enabled = False
        btn_Plantilla.Enabled = False
        btn_Filtrar.Enabled = False
        btn_Exportar.Enabled = False
        btn_Recargar.Enabled = False

        btn_Cruzar.Enabled = False
        btn_Limpiar.Enabled = False
        btn_Corregir.Enabled = False
        btn_Grupo.Enabled = False
        btn_BuscaChofer.Enabled = False
        Txb_Mayores.Enabled = False
        Txb_Proveedor.Enabled = False
        txtb_Deescripcion.Enabled = False
        btn_Plantilla.Enabled = False
        btn_Exportar.Enabled = False

    End Function

    Public Function activa()
        ProgBar.Maximum = 0
        ProgBar.Value = 0
        btn_Exportar.Enabled = True
        btn_Plantilla.Enabled = True
        btn_ActualizaInventario.Enabled = True
        btn_Filtrar.Enabled = True
        btn_Exportar.Enabled = True
        btn_Recargar.Enabled = True
        btn_Buscar.Enabled = True
        btn_Cruzar.Enabled = True

        btn_Corregir.Enabled = True
        btn_Grupo.Enabled = True
        Txb_Mayores.Enabled = True
        Txb_Proveedor.Enabled = True
        txtb_Deescripcion.Enabled = True
        btn_Plantilla.Enabled = True
        btn_Limpiar.Enabled = True

        btn_Cerrar.Enabled = True
        btn_BuscaChofer.Enabled = True
        Cursor = Cursors.Default

    End Function
    Public Function ActualizaStock()
        Dim InventarioSAP As New DataTable
        Dim InventarioWEB As New DataTable
        '--------------------------------------------------------------------------
        ''--------------------------- CONECTAR A MYSQL WEB  ------------------------------
        'Try
        '    If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
        '        Class_VariablesGlobales.MYSQ_Comman.Connection = Obj_VarGlobal.Obj_CX_MYSQL.Conectar()
        '    End If
        'Catch ex As Exception
        '    Class_VariablesGlobales.MYSQ_Comman = New OdbcCommand
        '    Class_VariablesGlobales.MYSQ_Comman.Connection = Obj_VarGlobal.Obj_CX_MYSQL.Conectar()
        'End Try

        'If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Open Then


        'jala el inventario de SAP y lo compara con el stock de bodega 1 de la web 
        InventarioSAP = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaInvConteo(Class_VariablesGlobales.SQL_Comman2)

        Class_VariablesGlobales.TotalLineas = InventarioSAP.Rows.Count
        Lbl_Fin.Text = InventarioSAP.Rows.Count
        ProgBar.Maximum = InventarioSAP.Rows.Count
        ProgBar.Value = 0
        Lbl_Inicio.Text = "0"
        Class_VariablesGlobales.Contador = 0

        'OBtiene inventario de MYSQL


        Dim COTADOR As Integer
        If InventarioSAP.Rows.Count > 0 Then
            For Each row As DataRow In InventarioSAP.Rows
                Class_VariablesGlobales.DetalleCarga = InventarioSAP.Rows(COTADOR).Item("ItemName").ToString()

                Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaStocks(txtb_IdInvetario.Text,
                                                        InventarioSAP.Rows(COTADOR).Item("ItemCode").ToString(),
                                                        CInt(InventarioSAP.Rows(COTADOR).Item("Stock_B1").ToString()),
                                                       CDbl(InventarioSAP.Rows(COTADOR).Item("Monto_B1").ToString()))

                COTADOR += 1
                Class_VariablesGlobales.Contador += 1

            Next
        End If
        'obtiene la lista deCF por linea la recorre y actualiza segun el nueco inventario


        ' si estan diferentes deja el inventario de sap

        Listar("", Trim(txtb_IdInvetario.Text))

        Lbl_Inicio.Text = "0"
        Lbl_Fin.Text = "0"
        ProgBar.Value = 0
        Class_VariablesGlobales.DetalleCarga = ""

        btn_ActualizaInventario.Enabled = True
        btn_Filtrar.Enabled = True
        btn_Exportar.Enabled = True
        btn_Recargar.Enabled = True
        btn_Buscar.Enabled = True
        btn_Cruzar.Enabled = True
        Timer1.Stop()
        'Else
        '    MsgBox("Problemas con la conexion intente nuevaente")
        'End If
    End Function

    Private Sub btn_Cruzar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cruzar.Click
        Class_VariablesGlobales.frmCruzar = New Inv_Cruzar
        Class_VariablesGlobales.frmCruzar.MdiParent = Principal
        Class_VariablesGlobales.frmCruzar.Show()


        Class_VariablesGlobales.frmCruzar.Txb_CodInventario.Text = txtb_IdInvetario.Text
    End Sub





    Private Sub btn_Corregir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Corregir.Click
        inactiva()
        '__________PROCESO 1_______________
        Timer1.Start()
        trd1 = Nothing
        trd1 = New Thread(AddressOf Corregir)
        trd1.IsBackground = Enabled
        trd1.Priority = ThreadPriority.AboveNormal
        trd1.Start()
        CheckForIllegalCrossThreadCalls = False

        Panel1.Visible = True
        btn_Corregir.Text = "Espere ..."
    End Sub

    Public Function Corregir()
        '--------------------------------------------------------------------------
        '--------------------------- CONECTAR A MYSQL WEB  ------------------------------
        'Try
        '    If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
        '        Class_VariablesGlobales.MYSQ_Comman.Connection = Obj_VarGlobal.Obj_CX_MYSQL.Conectar()
        '    End If
        'Catch ex As Exception
        '    Class_VariablesGlobales.MYSQ_Comman = New OdbcCommand
        '    Class_VariablesGlobales.MYSQ_Comman.Connection = Obj_VarGlobal.Obj_CX_MYSQL.Conectar()
        'End Try

        Dim TABLA As New DataTable
        'If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Open Then

        '    'actualiza los conteos vrs diferencias y stock
        Class_VariablesGlobales.Obj_Funciones_SQL.Corrige(idInventario1, CBox_Ver.Text)
        'End If
        btn_Corregir.Text = "CORREGIR"
        MsgBox("CORRECCION REALIZADA")
        Timer1.Stop()

    End Function


    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gbox_Botones.Enter

    End Sub

    Private Sub dGv_Control_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGv_Control.CellContentDoubleClick
        Try
            Class_VariablesGlobales.frmDetConteXLinea = New Inv_DetConteXLinea
            Class_VariablesGlobales.frmDetConteXLinea.MdiParent = Principal
            Class_VariablesGlobales.frmDetConteXLinea.Show()
            Class_VariablesGlobales.LlamadoDesdeControl = True

            Dim CodInventario As Integer = Class_VariablesGlobales.frmControl.txtb_IdInvetario.Text
            Class_VariablesGlobales.frmDetConteXLinea.DataGridView1.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.DetConteo(txtb_IdInvetario.Text, dGv_Control.CurrentRow.Cells.Item(5).Value.ToString())
            Class_VariablesGlobales.frmDetConteXLinea.txtb_Codigo.Text = Class_VariablesGlobales.frmDetConteXLinea.DataGridView1.CurrentRow.Cells.Item(3).Value.ToString()
            Class_VariablesGlobales.frmDetConteXLinea.txtb_Descripcion.Text = Class_VariablesGlobales.frmDetConteXLinea.DataGridView1.CurrentRow.Cells.Item(4).Value.ToString()
            Class_VariablesGlobales.frmDetConteXLinea.txtb_Stock.Text = Class_VariablesGlobales.frmDetConteXLinea.DataGridView1.CurrentRow.Cells.Item(5).Value.ToString()

            Class_VariablesGlobales.frmDetConteXLinea.txtb_CF.Text = dGv_Control.CurrentRow.Cells.Item(11).Value.ToString()
            Class_VariablesGlobales.frmDetConteXLinea.txtb_Dif.Text = dGv_Control.CurrentRow.Cells.Item(13).Value.ToString()
            Class_VariablesGlobales.frmDetConteXLinea.txtb_MontoDif.Text = dGv_Control.CurrentRow.Cells.Item(13).Value.ToString()

            Class_VariablesGlobales.frmDetConteXLinea.DataGridView1.Columns(3).Visible = False
            Class_VariablesGlobales.frmDetConteXLinea.DataGridView1.Columns(4).Visible = False
            Class_VariablesGlobales.frmDetConteXLinea.DataGridView1.Columns(5).Visible = False


        Catch ex As Exception
            'MsgBox("Error dGv_Control_CellContentDoubleClick " & ex.Message)

        End Try

    End Sub

    Private Sub btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Limpiar.Click
        Txb_Proveedor.Text = ""
        Txb_Mayores.Text = "0"

        txtb_Deescripcion.Text = "0"
        CBox_Ver.Text = "TODO"


        Filtrar()
        ProgBar.Maximum = 0
        ProgBar.Value = 0
    End Sub

    Private Sub btn_Grupo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Grupo.Click
        Class_VariablesGlobales.frmGruposConteo = New GruposConteo
        Class_VariablesGlobales.frmGruposConteo.MdiParent = Principal

        Class_VariablesGlobales.frmGruposConteo.Show()
    End Sub

    Private Sub Txb_Proveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txb_Proveedor.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True


        End If
    End Sub

    Private Sub CBox_SoloDesajustado_CheckedChanged(sender As Object, e As EventArgs)
        btn_ActualizaInventario.Enabled = False
        btn_Filtrar.Enabled = False
        btn_Exportar.Enabled = False
        btn_Recargar.Enabled = False
        btn_Buscar.Enabled = False
        btn_Cruzar.Enabled = False

        btn_Corregir.Enabled = False
        btn_Grupo.Enabled = False
        CBox_Ver.Enabled = False
        '__________PROCESO 1_______________
        Timer1.Start()
        trd1 = Nothing
        trd1 = New Thread(AddressOf Recargar)
        trd1.IsBackground = Enabled
        trd1.Priority = ThreadPriority.AboveNormal
        trd1.Start()
        CheckForIllegalCrossThreadCalls = False


    End Sub

    Private Sub dGv_Control_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dGv_Control.CellEndEdit
        Try

            Dim IdInventario As Integer = Me.dGv_Control.Rows(e.RowIndex).Cells("IdInventario").Value
            Dim Codigo As String = Me.dGv_Control.Rows(e.RowIndex).Cells("Codigo").Value
            Dim Costo As Double = Me.dGv_Control.Rows(e.RowIndex).Cells("Costo").Value
            Dim Stock As Integer = Me.dGv_Control.Rows(e.RowIndex).Cells("Stock").Value
            Dim CF As Integer = Me.dGv_Control.Rows(e.RowIndex).Cells("CF").Value
            Dim DF As Integer = Me.dGv_Control.Rows(e.RowIndex).Cells("DF").Value
            Dim DFM As Double = Me.dGv_Control.Rows(e.RowIndex).Cells("DFM").Value
            Dim Back_DFM As Double = DFM
            DF = CF - Stock
            DFM = DF * Costo
            Me.dGv_Control.Rows(e.RowIndex).Cells("DF").Value = DF
            Me.dGv_Control.Rows(e.RowIndex).Cells("DFM").Value = DFM

            Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaMontDifConte(IdInventario, Codigo, CF, DF, DFM)

            If Back_DFM < 0 Then
                'indica que era parte del monto de salida,por lo que le quitamos el monto original al total de SALIDAS
                Txtb_Salidas.Text = CDbl(Txtb_Salidas.Text) - CDbl(Back_DFM)
            ElseIf Back_DFM > 0 Then
                'indica que era parte del monto de entrada, por lo que le quitamos el monto original al total de ENTRADAS
                Txtb_Entradas.Text = CDbl(Txtb_Entradas.Text) - CDbl(Back_DFM)
            End If

            If DFM < 0 Then
                'Si el nuevo calculo es menor a cero entonces le agrego el nuevo monto a SALIDAS
                Txtb_Salidas.Text = CDbl(Txtb_Salidas.Text) + CDbl(DFM)
            ElseIf DFM > 0 Then
                'si el nuevo calculo es mayor a cero entonces le le agregamos el nuevo monto a ENTRADAS
                Txtb_Entradas.Text = CDbl(Txtb_Entradas.Text) + CDbl(DFM)
            End If


            Txtb_Entradas.Text = CStr(Obj_Mformat.FormatoMoneda(Txtb_Entradas.Text))
            Txtb_Salidas.Text = CStr(Obj_Mformat.FormatoMoneda(Txtb_Salidas.Text))
            Txtb_Desajuste.Text = CStr(Obj_Mformat.FormatoMoneda(CDbl(Txtb_Entradas.Text) + CDbl(Txtb_Salidas.Text)))
            txtb_InvFinal.Text = CStr(Obj_Mformat.FormatoMoneda(( CDbl(txtb_Inicial.Text) + ( CDbl(Txtb_Entradas.Text) +  CDbl(Txtb_Salidas.Text)))))
            txtb_Inicial.Text = CStr(Obj_Mformat.FormatoMoneda((txtb_Inicial.Text)))

            'Cbx_Rutas = Class_VariablesGlobales.Obj_Funciones_SQL.FacturaComentario(False, txb_Numero.Text, Factura, Comentario)
            'Comentario = Nothing
            'Factura = Nothing
        Catch ex As Exception

        End Try
    End Sub


    Private Sub dGv_Control_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dGv_Control.CellMouseDown
        'If e.Button = System.Windows.Forms.MouseButtons.Right Then
        '    Dim Mi_Test As DataGridView.HitTestInfo = Me.dGv_Control.HitTest(e.X, e.Y)
        '    indice = Me.dGv_Control.CurrentCell.ColumnIndex

        '    If Mi_Test.Type = DataGridViewHitTestType.TopLeftHeader Then
        '        '        If Mi_Test.RowIndex >= 0 Then
        '        '            indice = Mi_Test.RowIndex
        '        '            Me.dGv_Control.CurrentCell = Me.dGv_Control.Rows(Mi_Test.RowIndex).Cells(Mi_Test.ColumnIndex)
        '        '            Me.dGv_Control.Rows(Mi_Test.RowIndex).Selected = True
        '        '            menu = New ContextMenuStrip()

        '        '            menu.Items.Add("Mostrar", Nothing, New EventHandler(AddressOf Mostrar))
        '        '            menu.Items.Add("Ocultar", Nothing, New EventHandler(AddressOf Ocultar))
        '        '            Me.dGv_Control.ContextMenuStrip = menu
        '        '        End If
        '    End If
        'End If
    End Sub


    Private Sub Mostrar()


        Try


            'Abrira una pequela ventana donde saldran las columnas que se ocultaron para poder marcar un checbox y mostrarlas nuevamente
            Inv_ColumnasOcultas.Show()



        Catch ex As Exception

        End Try
    End Sub
    Private Sub Ocultar()
        Try


            'Oculta la columna seleccionada
            dGv_Control.Columns(Me.dGv_Control.CurrentCell.ColumnIndex).Visible = False
            'Debe almanercar en la base de datos para saber que columnas no mostrar

        Catch ex As Exception

        End Try


    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try


            'Oculta la columna seleccionada
            dGv_Control.Columns(Me.dGv_Control.CurrentCell.ColumnIndex).Visible = False
            'Debe almanercar en la base de datos para saber que columnas no mostrar

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Try


            'Abrira una pequela ventana donde saldran las columnas que se ocultaron para poder marcar un checbox y mostrarlas nuevamente
            Inv_ColumnasOcultas.Show()



        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_BuscaChofer_Click(sender As Object, e As EventArgs) Handles btn_BuscaChofer.Click
        Class_VariablesGlobales.LlamadoDesde = "Inv_Control"
        Lista_Proveedores.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBox_Ver.SelectedIndexChanged
        'btn_ActualizaInventario.Enabled = False
        'btn_Filtrar.Enabled = False
        'btn_Exportar.Enabled = False
        'btn_Recargar.Enabled = False
        'btn_Buscar.Enabled = False
        'btn_Cruzar.Enabled = False

        'btn_Corregir.Enabled = False
        'btn_Grupo.Enabled = False
        inactiva()
        '__________PROCESO 1_______________
        Timer1.Start()
        trd1 = Nothing
        trd1 = New Thread(AddressOf Recargar)
        trd1.IsBackground = Enabled
        trd1.Priority = ThreadPriority.AboveNormal
        trd1.Start()
        CheckForIllegalCrossThreadCalls = False


    End Sub

    Private Sub CBox_Colorear_CheckedChanged(sender As Object, e As EventArgs) Handles CBox_Colorear.CheckedChanged

    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles btn_Plantilla.Click

        Dim result As Integer = MessageBox.Show("Este proceso puede tardarios unos minutos, esta seguro que desea exportar la lista?", "Alerta", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.No Then

        ElseIf result = DialogResult.Yes Then
            inactiva()

            '__________PROCESO 1_______________
            Timer1.Start()
            trd1 = Nothing
            trd1 = New Thread(AddressOf ExportaPlantillaSAP)
            trd1.IsBackground = Enabled
            trd1.Priority = ThreadPriority.AboveNormal
            trd1.Start()
            CheckForIllegalCrossThreadCalls = False

            Panel1.Visible = True
            btn_Exportar.Text = "Espere ..."
        End If


    End Sub
End Class