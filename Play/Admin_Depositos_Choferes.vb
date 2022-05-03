Public Class Admin_Depositos_Choferes
    Public Empleado As String
    Private Sub Admin_Depositos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Nuevo()
        If Class_VariablesGlobales.LIQUIDANDO = "CHOFERES" Then
            txb_CodAgente.Text = Class_VariablesGlobales.CodChoferLiq
            txb_NomAgente.Text = Class_VariablesGlobales.NomChoferLiq
            txb_Liquidacion.Text = Class_VariablesGlobales.NumLiqChoferLiq
            Empleado = Class_VariablesGlobales.Chofer

            'Class_VariablesGlobales.frmDeposChofer.btn_GoToLiq.Enabled = False
            'Class_VariablesGlobales.frmDeposChofer.txb_Liquidacion.Enabled = False
        Else
            txb_CodAgente.Text = Class_VariablesGlobales.CodAgenteLiq
            txb_NomAgente.Text = Class_VariablesGlobales.NomAgenteLiq
            ' txb_Liquidacion.Text = NumLiqAgenteLiq
            Empleado = Class_VariablesGlobales.Agente
        End If



        Class_VariablesGlobales.frmDeposChofer = Me


        If Class_VariablesGlobales.Obj_Funciones_SQL.VerificaAnulado(Class_VariablesGlobales.SQL_Comman1, txb_consecutivo.Text) = 0 Then
            Dim Tbl_Banco As New DataTable
            Tbl_Banco = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneBancos(Class_VariablesGlobales.SQL_Comman1)
            Dim contardor As Integer
            While contardor < Tbl_Banco.Rows.Count

                'T0.[BankCode], T0.[BankName]
                cbbx_Banco.Items.Add(Tbl_Banco.Rows(contardor).Item("BankName").ToString())
                contardor += 1
            End While
        Else

            btn_AgGuardar.Enabled = False
            btn_AgModif.Enabled = False

        End If


    End Sub
    Private Sub btn_AgGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgGuardar.Click
        If txb_CodAgente.Text = "" Then
            MessageBox.Show("Debe indicar el agente que hizo el deposito")
        Else

            Dim Liq As String = Class_VariablesGlobales.Obj_Funciones_SQL.VerificaDeposito(Class_VariablesGlobales.SQL_Comman1, Trim(txb_NumDepo.Text))
            If Liq <> "" Then
                MsgBox("EL NUMERO DEL DEPOSITO [ " & Trim(txb_NumDepo.Text) & " ] YA EXISTE EN LA LIQUIDACION [ " & Liq & " ]")

            Else
                Class_VariablesGlobales.Obj_Funciones_SQL.InsertaDeposito(Class_VariablesGlobales.SQL_Comman1, txb_consecutivo.Text, txb_NumDepo.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_Fecha.Value.Date), cbbx_Banco.Text, txb_Monto.Text, txb_CodAgente.Text, txb_Comentario.Text, txb_Liquidacion.Text, Class_VariablesGlobales.LIQUIDANDO, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaContable.Value.Date))
                btn_AgElimina.Enabled = False
                btn_AgGuardar.Enabled = True
                btn_AgModif.Enabled = False
                btn_GoToLiq.Enabled = False
                btn_Agentes.Enabled = True
                'INCREMENTA EN 1 EL CONSECUTIVO

                Class_VariablesGlobales.Obj_Funciones_SQL.Aumenta_Consecutivos(Class_VariablesGlobales.SQL_Comman1, CInt(txb_consecutivo.Text) + 1, "OFICINA")

                limpiar()



                Class_VariablesGlobales.frmLiqChof.dgv_Depositos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaFin.Value.Date), Trim(Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text), "", Class_VariablesGlobales.frmLiqChof.txtb_Consecutivo.Text, "", "DPCONSECUTIVO", Class_VariablesGlobales.LIQUIDANDO, False, "")
                Class_VariablesGlobales.frmLiqChof.txtb_TotalDepositos.Text = FormatCurrency(Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaFin.Value.Date), Trim(Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text), Class_VariablesGlobales.frmLiqChof.txtb_Consecutivo.Text, Class_VariablesGlobales.LIQUIDANDO), 2)
                txb_consecutivo.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivo(Class_VariablesGlobales.SQL_Comman1, "OFICINA")
                txb_NumDepo.Focus()


            End If
        End If

    End Sub

    Private Sub btn_AgModif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgModif.Click
        Try
            Dim Sube As String
            If cbbx_Subido.Text = "NO" Then
                Sube = "0"
            Else
                Sube = "1"
            End If
            Dim liq As String
            If txb_Liquidacion.Text = "0" Then
                liq = "0"
            Else
                liq = txb_Liquidacion.Text
            End If

            Class_VariablesGlobales.Obj_Funciones_SQL.ModificaDeposito(Class_VariablesGlobales.SQL_Comman1, txb_consecutivo.Text, txb_NumDepo.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_Fecha.Value.Date), cbbx_Banco.Text, txb_Monto.Text, txb_CodAgente.Text, txb_Comentario.Text, liq, Class_VariablesGlobales.LIQUIDANDO, False, Sube, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaContable.Value.Date))
            btn_AgElimina.Enabled = False
            btn_AgGuardar.Enabled = True
            btn_AgModif.Enabled = False
            btn_GoToLiq.Enabled = False
            limpiar()

            Class_VariablesGlobales.frmLiqChof.dgv_Depositos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaFin.Value.Date), Trim(Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text), "", Class_VariablesGlobales.frmLiqChof.txtb_Consecutivo.Text, "", "DPCONSECUTIVO", Class_VariablesGlobales.LIQUIDANDO, False, "")
            Class_VariablesGlobales.frmLiqChof.txtb_TotalDepositos.Text = FormatCurrency(Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaFin.Value.Date), Trim(Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text), Class_VariablesGlobales.frmLiqChof.txtb_Consecutivo.Text, Class_VariablesGlobales.LIQUIDANDO), 2)
            txb_consecutivo.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivo(Class_VariablesGlobales.SQL_Comman1, "OFICINA")
            txb_NumDepo.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Public Function limpiar()
        txb_NumDepo.Text = ""
        txb_Liquidacion.Text = ""
        cbbx_Banco.Text = ""
        txb_CodAgente.Text = ""
        txb_NomAgente.Text = ""
        txb_Monto.Text = ""
        txb_Comentario.Text = ""
        dtp_Fecha.Value = Now.Date
        dtp_FechaContable.Value = Now.Date
        Class_VariablesGlobales.CodAgenteLiq = ""
        Class_VariablesGlobales.NomAgenteLiq = ""
        Class_VariablesGlobales.NumLiqAgenteLiq = ""
        'dtp_Fecha.Value.Date


        lbl_Anulado.Visible = False
        txb_NumDepo.Enabled = True
        btn_Agentes.Enabled = True
        cbbx_Banco.Enabled = True
        dtp_Fecha.Enabled = True
        dtp_FechaContable.Enabled = True
        txb_Monto.Enabled = True
        cbbx_Subido.Enabled = True
        txb_Liquidacion.Enabled = True
        btn_GoToLiq.Enabled = True
        txb_Comentario.Enabled = True
        btn_AgGuardar.Enabled = True
        btn_AgModif.Enabled = False
        btn_AgElimina.Enabled = False

        txb_CodAgente.Text = Class_VariablesGlobales.CodChoferLiq
        txb_NomAgente.Text = Class_VariablesGlobales.NomChoferLiq
        txb_Liquidacion.Text = Class_VariablesGlobales.NumLiqChoferLiq
        Empleado = Class_VariablesGlobales.Chofer
    End Function

    Private Sub cbbx_Banco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbx_Banco.SelectedIndexChanged
        Dim selectedIndex As Integer
        selectedIndex = cbbx_Banco.SelectedIndex
        Dim selectedItem As Object
        selectedItem = cbbx_Banco.SelectedItem
    End Sub



    Private Sub btn_Agentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Agentes.Click
        ListaChoferes.Show()

        Class_VariablesGlobales.Lista_llamadaDesde = "DEPOSITOS"





    End Sub

    Private Sub btn_BuscaDepos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaDepos.Click
        Class_VariablesGlobales.frmListaDeposChoferes = New Lista_Depositos_Choferes
        Class_VariablesGlobales.frmListaDeposChoferes.MdiParent = Principal
        Class_VariablesGlobales.frmListaDeposChoferes.Show()
    End Sub

    Private Sub btn_AgNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgNuevo.Click
        Nuevo()
    End Sub


    Public Function Nuevo()
        btn_AgElimina.Enabled = False
        btn_AgGuardar.Enabled = True
        btn_AgModif.Enabled = False
        btn_GoToLiq.Enabled = False

        limpiar()
        txb_consecutivo.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivo(Class_VariablesGlobales.SQL_Comman1, "OFICINA")
        txb_NumDepo.Focus()
    End Function
    Private Sub btn_GoToLiq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GoToLiq.Click
        Class_VariablesGlobales.CREANDO_LIQ_CHOFER = False

        Class_VariablesGlobales.NumLiqui = txb_Liquidacion.Text
        Dim tabla As DataTable = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLiquidaciones_Choferes(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.LIQUIDANDO, "", "", txb_Liquidacion.Text)
        Try
            '[Cosecutivo],[Fecha],[CodAgente],[CedulaAgente],[NombreAgente],[FechaINI],[FechaFIN],[Comentarios],[Tipo]
            Class_VariablesGlobales.NumLiqui = txb_Liquidacion.Text
            Class_VariablesGlobales.frmLiqChof.txtb_Consecutivo.Text = tabla.Rows(0).Item("Cosecutivo").ToString()
            Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text = tabla.Rows(0).Item("CodAgente").ToString()
            Class_VariablesGlobales.frmLiqChof.txtb_Cedula.Text = tabla.Rows(0).Item("CedulaAgente").ToString()
            Class_VariablesGlobales.frmLiqChof.txt_NombreChofer.Text = tabla.Rows(0).Item("NombreAgente").ToString()
            Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Value = tabla.Rows(0).Item("FechaINI").ToString()
            Class_VariablesGlobales.frmLiqChof.dtp_FechaFin.Value = tabla.Rows(0).Item("FechaFIN").ToString()
            Class_VariablesGlobales.frmLiqChof.txtb_Comentarios.Text = tabla.Rows(0).Item("Comentarios").ToString()
            Class_VariablesGlobales.frmLiqChof.btn_Cargar_Click(sender, e)
            Class_VariablesGlobales.frmLiqChof.TabControl1.Enabled = True
            Class_VariablesGlobales.Chofer = Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text
            Class_VariablesGlobales.frmLiqChof.btn_Cargar.Enabled = True
            Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Enabled = True
            Class_VariablesGlobales.frmLiqChof.dtp_FechaFin.Enabled = True

            Class_VariablesGlobales.frmLiqChof.btn_Guardar.Enabled = False
            Class_VariablesGlobales.frmLiqChof.btn_Imprimir.Enabled = True
            Class_VariablesGlobales.frmLiqChof.Show()

            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub


    Private Sub btn_AgElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgElimina.Click
        Class_VariablesGlobales.Obj_Funciones_SQL.AnulaDeposito(Class_VariablesGlobales.SQL_Comman1, txb_consecutivo.Text)

        btn_AgElimina.Enabled = False
        btn_AgGuardar.Enabled = True
        btn_AgModif.Enabled = False
        btn_GoToLiq.Enabled = False

        limpiar()

    End Sub



    Private Sub txb_NumDepo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txb_NumDepo.KeyPress
        'If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then


        '    NumDepBuscando = txb_NumDepo.Text

        '    Class_VariablesGlobales.frmListaDepos = New Lista_Depositos
        '    Class_VariablesGlobales.frmListaDepos.MdiParent = Principal
        '    Class_VariablesGlobales.frmListaDepos.Show()


        'End If

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then


            Class_VariablesGlobales.NumDepBuscando = txb_NumDepo.Text
            Dim tablas As New DataTable
            Dim cont As Integer
            tablas = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", "", "", "", "", Class_VariablesGlobales.NumDepBuscando, Class_VariablesGlobales.frmLiqChof.txtb_Consecutivo.Text, "", "DPCONSECUTIVO", Class_VariablesGlobales.LIQUIDANDO, True, "")

            For Each row As DataRow In tablas.Rows
                '[DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],CONVERT(varchar, CAST([DPMONTO] AS money), 1) as Total,[DPOBS],[DPAGENTE],[DPLIQUIDACION],[DP_BOLETA] ,[DP_SUBIDO],[DPFECHA_CONTABLE],[DP_ANULADO]

                txb_consecutivo.Text = tablas.Rows(0).Item("DPCONSECUTIVO").ToString
                txb_NumDepo.Text = tablas.Rows(0).Item("DPCODIGO").ToString
                dtp_Fecha.Text = tablas.Rows(0).Item("DPFECHA").ToString
                cbbx_Banco.Text = tablas.Rows(0).Item("DPBANCO").ToString
                txb_Monto.Text = tablas.Rows(0).Item("Total").ToString
                dtp_FechaContable.Text = tablas.Rows(0).Item("DPFECHA_CONTABLE").ToString
                txb_CodAgente.Text = tablas.Rows(0).Item("DPAGENTE").ToString

                If Trim(tablas.Rows(0).Item("DPAGENTE").ToString) <> "" Then
                    txb_NomAgente.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneNameAgente(Class_VariablesGlobales.SQL_Comman1, Trim(tablas.Rows(0).Item("DPAGENTE").ToString))
                End If



                txb_Liquidacion.Text = tablas.Rows(0).Item("DPLIQUIDACION").ToString

                txb_Comentario.Text = tablas.Rows(0).Item("DPOBS").ToString

                If tablas.Rows(0).Item("DP_BOLETA").ToString = "1" Then
                    cbbx_Subido.Text = "SI"
                Else
                    cbbx_Subido.Text = "NO"
                End If
                If tablas.Rows(0).Item("DP_ANULADO").ToString = "1" Then
                    lbl_Anulado.Visible = True


                    txb_consecutivo.Enabled = False
                    txb_NumDepo.Enabled = False
                    dtp_Fecha.Enabled = False
                    cbbx_Banco.Enabled = False
                    txb_Monto.Enabled = False
                    txb_CodAgente.Enabled = False
                    txb_NomAgente.Enabled = False
                    txb_Liquidacion.Enabled = False
                    txb_Comentario.Enabled = False
                    cbbx_Subido.Enabled = False
                    dtp_FechaContable.Enabled = False
                    btn_AgModif.Enabled = False
                    btn_AgElimina.Enabled = False
                End If


                btn_AgElimina.Enabled = True
                btn_AgGuardar.Enabled = False
                btn_AgModif.Enabled = True
                btn_GoToLiq.Enabled = True


                cont += 1
            Next
            'Class_VariablesGlobales.frmListaDepos = New Lista_Depositos
            'Class_VariablesGlobales.frmListaDepos.MdiParent = Principal
            'Class_VariablesGlobales.frmListaDepos.Show()


        End If
    End Sub

    Private Sub txb_consecutivo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txb_consecutivo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then


            Class_VariablesGlobales.ConseDepBuscando = txb_consecutivo.Text
            Class_VariablesGlobales.frmListaDepos = New Lista_Depositos
            Class_VariablesGlobales.frmListaDepos.MdiParent = Principal
            Class_VariablesGlobales.frmListaDepos.Show()
        End If
    End Sub

    Private Sub Admin_Depositos_Choferes_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing


        Try

            Class_VariablesGlobales.frmLiqChof.btn_Cargar_Click(sender, e)


            'Class_VariablesGlobales.MisPropiedades.FrmDepChofer.Hide()


            Class_VariablesGlobales.frmDeposChofer.Hide()

            'Class_VariablesGlobales.frmLiqChof.dgv_Depositos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaIni_Recibos.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaFin_Recibos.Value.Date), Trim(Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text), "", "", "", "DPCONSECUTIVO", "CHOFERES")
            'Class_VariablesGlobales.frmLiqChof.txtb_TotalDepositos.Text = FormatCurrency(Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalDepositos(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaIni_Recibos.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqChof.dtp_FechaFin_Recibos.Value.Date), Trim(Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text)), 2)
            Class_VariablesGlobales.CodChoferLiq = ""
            Class_VariablesGlobales.NomChoferLiq = ""
            Class_VariablesGlobales.NumLiqChoferLiq = ""


        Catch ex As Exception

        End Try

    End Sub

    Private Sub Admin_Depositos_Choferes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub dtp_Fecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_Fecha.ValueChanged
        dtp_FechaContable.Value = dtp_Fecha.Value

    End Sub
End Class