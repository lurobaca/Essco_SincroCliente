Public Class EstadoSubida
    Dim Obj_Creaarchivo As New CrearArchivo
    Public DocNumReinsertar As String
    Public Doc As String

    Private Sub EstadoSubida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        WindowState = FormWindowState.Maximized
        '--------------- ESTADO SUBIDA ------------------
        DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.Consulta_EstadoError_SubidaSAP(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
        RegulaTamanoColumnas(DGV_EstadoSubida)
        Timer_AGEjecucion.Start()

        Class_VariablesGlobales.Obj_Funciones_SQL.Bloquea_DESBloqueaPedidosHOY(Class_VariablesGlobales.SQL_Comman2, 0)
        Button5.Text = "HOY DESBLOQUEADO"
        Button5.BackColor = Color.Green


        If Class_VariablesGlobales.Puesto = "Manager" Then
            GroupBox3.Visible = True
            GroupBox2.Visible = True
            GroupBox1.Visible = True
        End If
        If Class_VariablesGlobales.Puesto = "Facturacion" Then
            GroupBox3.Visible = False
            GroupBox2.Visible = True
            GroupBox1.Visible = False
        End If
        If Class_VariablesGlobales.Puesto = "Administracion" Or Class_VariablesGlobales.Puesto = "Contabilidad" Or Class_VariablesGlobales.Puesto = "CuentasXCobrar" Then
            GroupBox3.Visible = False
            GroupBox2.Visible = False
            GroupBox1.Visible = True
        End If
    End Sub


#Region "Estado Subida"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RecargaTodos.Click
        Try

            Dim Tbl_Agentes As New DataTable
            Tbl_Agentes = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman2, "AGENTE", "")
            Dim cont1 As Integer
            Dim agente As String
            Dim agenteEje As String
            For Each row2 As DataRow In Tbl_Agentes.Rows


                agente = CStr(Tbl_Agentes.Rows(cont1).Item("CodAgente").ToString())
                agenteEje = CStr(Tbl_Agentes.Rows(cont1).Item("CodAgente").ToString())
                If agente <> "1" Then


                    'limpia errores
                    Class_VariablesGlobales.Obj_Funciones_SQL.EliminaListaEstadoErroSAP(agente, Class_VariablesGlobales.SQL_Comman2)
                    DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.Consulta_Estado_SubidaSAP(agente, Class_VariablesGlobales.SQL_Comman2)
                    'limpia Subidos
                    Class_VariablesGlobales.Obj_Funciones_SQL.EliminaListaEstadoSubidoSAP(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
                    DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.Consulta_Estado_SubidaSAP(agente, Class_VariablesGlobales.SQL_Comman2)
                    'intenta subir todo los archivos del agente
                    Class_VariablesGlobales.Obj_Funciones_SQL.RecargarTODO(agente, Class_VariablesGlobales.SQL_Comman2)
                    LbL_AgEjecucion.Text = "Sigt->" & agente


                    EnviaRevisame(agente)
                    txt_SoloAg.Text = ""
                    Class_VariablesGlobales.Obj_Funciones_SQL.EliminaidAgenteENEjecucion(Class_VariablesGlobales.SQL_Comman2)
                    Class_VariablesGlobales.Obj_Funciones_SQL.InsertaidAgenteAEjecutar(Trim(agenteEje), Class_VariablesGlobales.SQL_Comman2)
                End If
                cont1 += 1
            Next
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RecargSubir.Click
        Try

            'Tbl_Clientes, XMLParamFTP_dirLocal & txt_SoloAg.Text & "\"&txt_SoloAg.Text&".mbg", XMLParamFTP_dirLocal & txt_SoloAg.Text

            'recargar
            Dim agente As String
            agente = txt_SoloAg.Text
            'subir
            Dim agenteEje As String
            agenteEje = txt_SoloAg.Text
            If (txt_SoloAg.Text = "") Then
                MessageBox.Show("Debe Ingresar un numero de Agente en el campo Correspondiente")
                txt_SoloAg.Focus()
            Else

                'limpia errores
                Class_VariablesGlobales.Obj_Funciones_SQL.EliminaListaEstadoErroSAP(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
                DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.Consulta_Estado_SubidaSAP(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)

                'limpia Subidos
                Class_VariablesGlobales.Obj_Funciones_SQL.EliminaListaEstadoSubidoSAP(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
                DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.Consulta_Estado_SubidaSAP(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)

                'intenta subir todo los archivos del agente
                Class_VariablesGlobales.Obj_Funciones_SQL.RecargarTODO(agente, Class_VariablesGlobales.SQL_Comman2)
                LbL_AgEjecucion.Text = "Sigt->" & agente


                EnviaRevisame(txt_SoloAg.Text)
                txt_SoloAg.Text = ""
                Class_VariablesGlobales.Obj_Funciones_SQL.EliminaidAgenteENEjecucion(Class_VariablesGlobales.SQL_Comman2)
                Class_VariablesGlobales.Obj_Funciones_SQL.InsertaidAgenteAEjecutar(Trim(agenteEje), Class_VariablesGlobales.SQL_Comman2)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btn_subir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_subir.Click
        Try
            If (txt_SoloAg.Text = "") Then
                MessageBox.Show("Debe Ingresar un numero de Agente en el campo Correspondiente")
                txt_SoloAg.Focus()
            Else


                'limpia errores
                Class_VariablesGlobales.Obj_Funciones_SQL.EliminaListaEstadoErroSAP(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
                DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.Consulta_Estado_SubidaSAP(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)

                'limpia Subidos
                Class_VariablesGlobales.Obj_Funciones_SQL.EliminaListaEstadoSubidoSAP(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
                DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.Consulta_Estado_SubidaSAP(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)

                'indica cual agente quiere subir
                Class_VariablesGlobales.Obj_Funciones_SQL.EliminaidAgenteENEjecucion(Class_VariablesGlobales.SQL_Comman2)
                Class_VariablesGlobales.Obj_Funciones_SQL.InsertaidAgenteAEjecutar(Trim(txt_SoloAg.Text), Class_VariablesGlobales.SQL_Comman2)
                LbL_AgEjecucion.Text = "Sigt->" & txt_SoloAg.Text
                EnviaRevisame(txt_SoloAg.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Class_VariablesGlobales.Obj_Funciones_SQL.Bloquea_DESBloqueaPedidosHOY(Class_VariablesGlobales.SQL_Comman2, 0)
        Button5.Text = "HOY DESBLOQUEADO"
        Button5.BackColor = Color.Green

        Class_VariablesGlobales.Obj_Funciones_SQL.Bloquea_Desbloquea_DescargardeFTP(Class_VariablesGlobales.SQL_Comman2, 0)
        BTN_LocalFtp.Text = "FTP"
        BTN_LocalFtp.BackColor = Color.Green


    End Sub
    'indica de donde se bajaran los pedidos , si LOCALES O DE WEB
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_LocalFtp.Click
        If BTN_LocalFtp.Text = "LOCAL" Then
            Class_VariablesGlobales.Obj_Funciones_SQL.Bloquea_Desbloquea_DescargardeFTP(Class_VariablesGlobales.SQL_Comman2, 0)
            BTN_LocalFtp.Text = "FTP"
            BTN_LocalFtp.BackColor = Color.Green
        Else
            Class_VariablesGlobales.Obj_Funciones_SQL.Bloquea_Desbloquea_DescargardeFTP(Class_VariablesGlobales.SQL_Comman2, 1)
            BTN_LocalFtp.Text = "LOCAL"
            BTN_LocalFtp.BackColor = Color.Red
        End If
    End Sub

#Region "BOTONES ACCIONES GENERALES"
    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_MuestraTodo.Click
        DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.Consulta_Estado_SubidaSAP(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_MuestraTodoError.Click
        DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.Consulta_EstadoError_SubidaSAP(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_MuestraTodoSubido.Click
        DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.Consulta_EstadoSubidos_SubidaSAP(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_LimpiaTodoError.Click
        Class_VariablesGlobales.Obj_Funciones_SQL.EliminaListaEstadoErroSAP(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
        DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.Consulta_Estado_SubidaSAP(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
    End Sub
    Private Sub btn_LimpiaTodoSubido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_LimpiaTodoSubido.Click
        Class_VariablesGlobales.Obj_Funciones_SQL.EliminaListaEstadoSubidoSAP(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
        DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.Consulta_Estado_SubidaSAP(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
    End Sub
#End Region

#Region "BOTONES DE ACCIONES PARA PEDIDOS"
    Private Sub btn_TodosPedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_TodosPedidos.Click

        DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.PedidosTODOS(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
        RegulaTamanoColumnas(DGV_EstadoSubida)
    End Sub

    Private Sub btn_PedidError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PedidError.Click
        DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.PedidosConError(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
        RegulaTamanoColumnas(DGV_EstadoSubida)
    End Sub

    Private Sub btn_PedidSubido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PedidSubido.Click
        DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.PedidosSUBIDOS(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
        RegulaTamanoColumnas(DGV_EstadoSubida)
    End Sub

    Private Sub btn_PedidLimpError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PedidLimpError.Click
        Class_VariablesGlobales.Obj_Funciones_SQL.PedidosEliminaEstadoERROR(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
        DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.PedidosTODOS(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
        RegulaTamanoColumnas(DGV_EstadoSubida)
    End Sub

    Private Sub btn_PedidLimpSubidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PedidLimpSubidos.Click
        Class_VariablesGlobales.Obj_Funciones_SQL.PedidosEliminaEstadoSUBIDO(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
        DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.PedidosTODOS(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
        RegulaTamanoColumnas(DGV_EstadoSubida)
    End Sub
#End Region

#Region "BOTONES DE ACCIONES PARA PAGOS"
    Private Sub btn_PagosTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PagosTodos.Click
        DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.PagosTODOS(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
        RegulaTamanoColumnas(DGV_EstadoSubida)
    End Sub

    Private Sub btn_PagosError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PagosError.Click
        DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.PagosConError(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
        RegulaTamanoColumnas(DGV_EstadoSubida)
    End Sub

    Private Sub btn_PagosSubido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PagosSubido.Click
        DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.PagosSUBIDOS(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
        RegulaTamanoColumnas(DGV_EstadoSubida)
    End Sub

    Private Sub btn_PagosLimpError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PagosLimpError.Click
        Class_VariablesGlobales.Obj_Funciones_SQL.PagosEliminaEstadoERROR(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
        DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.PagosTODOS(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
        RegulaTamanoColumnas(DGV_EstadoSubida)
    End Sub

    Private Sub btn_PagosLimpSubido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PagosLimpSubido.Click
        Class_VariablesGlobales.Obj_Funciones_SQL.PagosEliminaEstadoSUBIDO(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
        DGV_EstadoSubida.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.PagosTODOS(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
        RegulaTamanoColumnas(DGV_EstadoSubida)
    End Sub
#End Region


    Public Function RegulaTamanoColumnas(ByVal dgv As DataGridView)
        dgv.Columns(0).Width = 30 'Agente
        dgv.Columns(1).Width = 70 'Archivo
        dgv.Columns(2).Width = 70 'Consecutivo
        dgv.Columns(3).Width = 70 'Estado
        dgv.Columns(4).Width = 400 'Detalle
        dgv.Columns(5).Width = 100 'fecha
        dgv.Columns(6).Width = 100 'reintento

    End Function
    Private Sub txt_SoloAg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_SoloAg.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub DataGridView1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV_EstadoSubida.MouseClick
        Try
            Dim row = DGV_EstadoSubida.CurrentRow.Index
            DocNumReinsertar = DGV_EstadoSubida(3, row).Value.ToString()
            Doc = DGV_EstadoSubida(1, row).Value.ToString()

            Class_VariablesGlobales.Obj_Funciones_SQL.CambiaEstadoReinsertar(DocNumReinsertar, Doc, Class_VariablesGlobales.SQL_Comman2)
            DGV_EstadoSubida.Item(0, row).Value = "1"

        Catch ex As Exception
        End Try
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim cont As Integer
        Dim dt As New DataTable
        dt.Columns.Clear() 'Con esto limpiamos las columnas de la tabla
        'dt.Columns.Add(New DataColumn("key", GetType(Long)))

        dt.Columns.Add(New DataColumn("Agente", GetType(String)))
        dt.Columns.Add(New DataColumn("Consecutivo", GetType(String)))
        dt.Columns.Add(New DataColumn("Estado", GetType(String)))
        dt.Columns.Add(New DataColumn("Detalle", GetType(String)))
        dt.Rows.Clear() 'Limpiamos las filas

        dt.PrimaryKey = New DataColumn() {dt.Columns.Item("key")} 'Creamos la clave primaria

        dt = Class_VariablesGlobales.Obj_Funciones_SQL.Consulta_Estado_SubidaSAP(txt_SoloAg.Text, Class_VariablesGlobales.SQL_Comman2)
        Dim dr As DataRow
        DGV_EstadoSubida.DataSource = Nothing

        For Each rowLocal As DataRow In dt.Rows
            dr = dt.NewRow
            'dr("key") = cont
            dr("Agente") = dt.Rows(cont).Item("Agente").ToString()
            dr("Consecutivo") = dt.Rows(cont).Item("Consecutivo").ToString()
            dr("Estado") = dt.Rows(cont).Item("Estado").ToString()
            dr("Detalle") = dt.Rows(cont).Item("Detalle").ToString()
            DGV_EstadoSubida.Rows.Add(dr)


            cont += 1
        Next

        DGV_EstadoSubida.Columns.Item(3).Width = CInt(400)
        DGV_EstadoSubida.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter

        Dim db As New BindingSource

        db.DataSource = dt

        DGV_EstadoSubida.DataSource = db



    End Sub
    Private Sub Timer_AGEjecucion_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_AGEjecucion.Tick

        Try
            Dim tabla As New DataTable
            tabla = Class_VariablesGlobales.Obj_Funciones_SQL.Consulta_InfoNOARCHIVO_FTP(tabla, Class_VariablesGlobales.SQL_Comman2)


            If CInt(tabla.Rows(0).Item("InfoTransmision").ToString()) = 1 Then
                Class_VariablesGlobales.Obj_Funciones_SQL.Actualiza_InfoNOARCHIVO_FTP(Class_VariablesGlobales.SQL_Comman2)
                'MessageBox.Show("NO EXISTE REGISTROS EN FTP DEL AGENTE [ " & tabla.Rows(0).Item("Agente").ToString() & " ]")

            End If

            If Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaHoySI(Class_VariablesGlobales.SQL_Comman2) = "0" Then
                Class_VariablesGlobales.Obj_Funciones_SQL.Bloquea_DESBloqueaPedidosHOY(Class_VariablesGlobales.SQL_Comman2, 0)
                Button5.Text = "HOY DESBLOQUEADO"
                Button5.BackColor = Color.Green
            Else

                Class_VariablesGlobales.Obj_Funciones_SQL.Bloquea_DESBloqueaPedidosHOY(Class_VariablesGlobales.SQL_Comman2, 1)
                Button5.Text = "HOY BLOQUEADO"
                Button5.BackColor = Color.Red
            End If

            Dim Tbl_AgAEjec As New DataTable
            Dim Tbl_ProcesAEjec As New DataTable

            Tbl_AgAEjec = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaidAgenteAEjecutar(Class_VariablesGlobales.SQL_Comman2)
            Tbl_ProcesAEjec = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaidProcesoEnEjecucion(Class_VariablesGlobales.SQL_Comman2)

            If Tbl_AgAEjec.Rows.Count > 0 Then
                LbL_AgEjecucion.Text = Trim(Tbl_AgAEjec.Rows(0).Item("AgenteEnSecuencia").ToString())
                If Class_VariablesGlobales.backuoAgeEje <> LbL_AgEjecucion.Text Then
                    'Actualiza los estados si el agente cambio
                    ' DataGridView1.DataSource = Obj_Funciones_SQL.Consulta_Estado_SubidaSAP()
                End If
                Class_VariablesGlobales.backuoAgeEje = LbL_AgEjecucion.Text
            Else
                LbL_AgEjecucion.Text = "-"
            End If
            Tbl_AgAEjec = Nothing


            If Tbl_ProcesAEjec.Rows.Count > 0 Then
                Lbl_Procesando.Text = Trim(Tbl_ProcesAEjec.Rows(0).Item("Procesando").ToString())
            End If



        Catch ex As Exception

        End Try
    End Sub
    Private Sub Txt_RecargarTodoAgente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Public Sub EnviaRevisame(ByVal agente As String)
        Obj_Creaarchivo.Crear_Revisame(Class_VariablesGlobales.XMLParamFTP_dirLocal & agente & "\" & agente & ".mbg", Class_VariablesGlobales.XMLParamFTP_dirLocal & agente)
        Dim obj_FTP As New Class_FTP
        obj_FTP.Subir(Class_VariablesGlobales.XMLParamFTP_dirLocal & agente & "\" & agente & ".mbg", Class_VariablesGlobales.XMLParamFTP_Server & "Revisame/" & agente & ".mbg", Class_VariablesGlobales.XMLParamFTP_user, Class_VariablesGlobales.XMLParamFTP_Password)

    End Sub
#End Region

    
End Class