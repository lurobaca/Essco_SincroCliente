Public Class Admin_Depositos_Agentes

    Private Sub btn_AgGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgGuardar.Click
        If txb_CodAgente.Text = "" Then
            MessageBox.Show("Debe indicar el agente que hizo el deposito")
        Else

            If Class_VariablesGlobales.Obj_Funciones_SQL.ExisteDeposito(Class_VariablesGlobales.SQL_Comman1, Trim(txb_NumDepo.Text), Trim(cbbx_Banco.Text)) = 0 Then
                InsertarDeposito()
            Else
                MessageBox.Show("El Deposito número de deposito [" & Trim(txb_NumDepo.Text) & "] del banco [ " & Trim(cbbx_Banco.Text) & "] ya existe")
            End If
        End If


    End Sub
    Public Function InsertarDeposito()
        Dim res As String = ""
        res = Class_VariablesGlobales.Obj_Funciones_SQL.VerificaDeposito(Class_VariablesGlobales.SQL_Comman1, Trim(txb_NumDepo.Text))
        If res <> "" Then
            MsgBox("EL NUMERO DEL DEPOSITO YA EXISTE EN LA LIQ [" & res & "]")
            res = Nothing
        Else


            Class_VariablesGlobales.Obj_Funciones_SQL.InsertaDeposito(Class_VariablesGlobales.SQL_Comman1, txb_consecutivo.Text, txb_NumDepo.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_Fecha.Value.Date), cbbx_Banco.Text, txb_Monto.Text, txb_CodAgente.Text, txb_Comentario.Text, txb_Liquidacion.Text, Class_VariablesGlobales.TipoLiqui, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaContable.Value.Date))
            btn_AgElimina.Enabled = False
            btn_AgGuardar.Enabled = True
            btn_AgModif.Enabled = False
            btn_GoToLiq.Enabled = False
            btn_Agentes.Enabled = True
            'INCREMENTA EN 1 EL CONSECUTIVO

            Class_VariablesGlobales.Obj_Funciones_SQL.Aumenta_Consecutivos(Class_VariablesGlobales.SQL_Comman1, CInt(txb_consecutivo.Text) + 1, "OFICINA")

            limpiar()
            Class_VariablesGlobales.frmLiqAge.dgv_Depositos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqAge.dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqAge.dtp_FechaFin.Value.Date), Trim(Class_VariablesGlobales.frmLiqAge.txtb_CodAgente.Text), "", "", "", "DPCONSECUTIVO", Class_VariablesGlobales.LIQUIDANDO, False, "")
            Class_VariablesGlobales.frmLiqAge.txtb_TotalDepositos.Text = FormatCurrency(Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqAge.dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqAge.dtp_FechaFin.Value.Date), Trim(Class_VariablesGlobales.frmLiqAge.txtb_CodAgente.Text), Class_VariablesGlobales.frmLiqAge.txtb_Consecutivo.Text, Class_VariablesGlobales.LIQUIDANDO), 2)

        End If
    End Function
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
            Me.Close()
            Class_VariablesGlobales.frmLiqAge.dgv_Depositos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqAge.dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqAge.dtp_FechaFin.Value.Date), Trim(Class_VariablesGlobales.frmLiqAge.txtb_CodAgente.Text), "", "", "", "DPCONSECUTIVO", Class_VariablesGlobales.LIQUIDANDO, False, "")
            Class_VariablesGlobales.frmLiqAge.txtb_TotalDepositos.Text = FormatCurrency(Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqAge.dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqAge.dtp_FechaFin.Value.Date), Trim(Class_VariablesGlobales.frmLiqAge.txtb_CodAgente.Text), "", Class_VariablesGlobales.LIQUIDANDO), 2)
        Catch ex As Exception

        End Try
    End Sub

    Public Function limpiar()
        txb_NumDepo.Text = ""
        txb_consecutivo.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivo(Class_VariablesGlobales.SQL_Comman1, "OFICINA")
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
        cbbx_Subido.Text = ""
        cbbx_Subido.SelectedIndex = 0

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

        'dtp_Fecha.Value.Date
    End Function

    Private Sub cbbx_Banco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbx_Banco.SelectedIndexChanged
        Dim selectedIndex As Integer
        selectedIndex = cbbx_Banco.SelectedIndex
        Dim selectedItem As Object
        selectedItem = cbbx_Banco.SelectedItem
    End Sub

    Private Sub Admin_Depositos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Class_VariablesGlobales.CodAgenteLiq <> "" Then
            txb_CodAgente.Text = Class_VariablesGlobales.CodAgenteLiq
            txb_NomAgente.Text = Class_VariablesGlobales.NomAgenteLiq
            txb_Liquidacion.Text = Class_VariablesGlobales.NumLiqAgenteLiq
        End If

        Class_VariablesGlobales.frmDeposAgente = Me
        txb_consecutivo.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivo(Class_VariablesGlobales.SQL_Comman1, "OFICINA")

        If Class_VariablesGlobales.Obj_Funciones_SQL.VerificaAnulado(Class_VariablesGlobales.SQL_Comman1, txb_consecutivo.Text) = 0 Then
            Dim Tbl_Banco As New DataTable
            Tbl_Banco = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneBancos(Class_VariablesGlobales.SQL_Comman1)
            Dim contardor As Integer
            While contardor < Tbl_Banco.Rows.Count

                'T0.[BankCode], T0.[BankName]
                cbbx_Banco.Items.Add(Tbl_Banco.Rows(contardor).Item("BankName").ToString())
                contardor += 1
            End While

            btn_AgGuardar.Enabled = True
            btn_AgModif.Enabled = True
            btn_AgElimina.Enabled = True
            btn_Agentes.Enabled = True
            btn_GoToLiq.Enabled = True

        Else

            btn_AgGuardar.Enabled = False
            btn_AgModif.Enabled = False
            btn_AgElimina.Enabled = False
            btn_Agentes.Enabled = False
            btn_GoToLiq.Enabled = False

        End If
    End Sub

    Private Sub btn_Agentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Agentes.Click


        Class_VariablesGlobales.Lista_llamadaDesde = "DEPOSITOS"

        Class_VariablesGlobales.Obj_ListaAgentes = New ListaAgentes
        Class_VariablesGlobales.Obj_ListaAgentes.MdiParent = Principal
        Class_VariablesGlobales.Obj_ListaAgentes.Puesto = "AGENTE"
        Class_VariablesGlobales.Obj_ListaAgentes.Show()




    End Sub

    Private Sub btn_BuscaDepos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaDepos.Click


        Class_VariablesGlobales.frmListaDepos = New Lista_Depositos
        Class_VariablesGlobales.frmListaDepos.MdiParent = Principal
        Class_VariablesGlobales.frmListaDepos.Show()

    End Sub

    Private Sub btn_AgNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgNuevo.Click
        btn_AgElimina.Enabled = False
        btn_AgGuardar.Enabled = True
        btn_AgModif.Enabled = False
        btn_GoToLiq.Enabled = False

        limpiar()
    End Sub

    Private Sub btn_GoToLiq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GoToLiq.Click

        Class_VariablesGlobales.NumLiqui = txb_Liquidacion.Text


        Dim tabla As DataTable = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLiquidaciones(Class_VariablesGlobales.SQL_Comman1, "AGENTES", "", "", txb_Liquidacion.Text)
        Try
            '[Cosecutivo],[Fecha],[CodAgente],[CedulaAgente],[NombreAgente],[FechaINI],[FechaFIN],[Comentarios],[Tipo]
            Class_VariablesGlobales.NumLiqui = txb_Liquidacion.Text
            Class_VariablesGlobales.frmLiqAge.txtb_Consecutivo.Text = tabla.Rows(0).Item("Cosecutivo").ToString()
            Class_VariablesGlobales.frmLiqAge.txtb_CodAgente.Text = tabla.Rows(0).Item("CodAgente").ToString()
            Class_VariablesGlobales.frmLiqAge.txtb_Cedula.Text = tabla.Rows(0).Item("CedulaAgente").ToString()
            Class_VariablesGlobales.frmLiqAge.txtb_NombreAgente.Text = tabla.Rows(0).Item("NombreAgente").ToString()
            Class_VariablesGlobales.frmLiqAge.dtp_FechaIni.Value = tabla.Rows(0).Item("FechaINI").ToString()
            Class_VariablesGlobales.frmLiqAge.dtp_FechaFin.Value = tabla.Rows(0).Item("FechaFIN").ToString()
            Class_VariablesGlobales.frmLiqAge.txtb_Comentarios.Text = tabla.Rows(0).Item("Comentarios").ToString()
            Class_VariablesGlobales.frmLiqAge.btn_Cargar_Click(sender, e)
            Class_VariablesGlobales.frmLiqAge.TabControl1.Enabled = True
            Class_VariablesGlobales.Agente = Class_VariablesGlobales.frmLiqAge.txtb_CodAgente.Text
            Class_VariablesGlobales.frmLiqAge.btn_Cargar.Enabled = True
            Class_VariablesGlobales.frmLiqAge.dtp_FechaIni.Enabled = True
            Class_VariablesGlobales.frmLiqAge.dtp_FechaFin.Enabled = True

            Class_VariablesGlobales.frmLiqAge.btn_Guardar.Enabled = False
            Class_VariablesGlobales.frmLiqAge.btn_Imprimir.Enabled = True
            Class_VariablesGlobales.frmLiqAge.Show()

            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub


    Private Sub btn_AgElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgElimina.Click
        Dim result1 As DialogResult = MessageBox.Show("Si anula el Deposito no podra editarlo\n Realmente desea anular el Deposito?",
             "Important Question",
             MessageBoxButtons.YesNo)

        If result1 = DialogResult.Yes Then
            Class_VariablesGlobales.Obj_Funciones_SQL.AnulaDeposito(Class_VariablesGlobales.SQL_Comman1, txb_consecutivo.Text)

            btn_AgElimina.Enabled = False
            btn_AgGuardar.Enabled = True
            btn_AgModif.Enabled = False
            btn_GoToLiq.Enabled = False

            limpiar()


        End If
        If result1 = DialogResult.No Then


        End If

    End Sub

    Private Sub Admin_Depositos_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            Class_VariablesGlobales.frmLiqAge.dgv_Depositos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqAge.dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqAge.dtp_FechaFin.Value.Date), Trim(Class_VariablesGlobales.frmLiqAge.txtb_CodAgente.Text), "", "", "", "DPCONSECUTIVO", Class_VariablesGlobales.LIQUIDANDO, False, "")
            Class_VariablesGlobales.frmLiqAge.txtb_TotalDepositos.Text = FormatCurrency(Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqAge.dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmLiqAge.dtp_FechaFin.Value.Date), Trim(Class_VariablesGlobales.frmLiqAge.txtb_CodAgente.Text), "", Class_VariablesGlobales.LIQUIDANDO), 2)
            Class_VariablesGlobales.CodAgenteLiq = ""
            Class_VariablesGlobales.NomAgenteLiq = ""
            Class_VariablesGlobales.NumLiqAgenteLiq = ""
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txb_NumDepo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txb_NumDepo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then


            Class_VariablesGlobales.NumDepBuscando = txb_NumDepo.Text
            Dim tablas As New DataTable
            Dim cont As Integer
            tablas = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "", "", "", "", Class_VariablesGlobales.NumDepBuscando, "VENTANA_DEPOSITO", "", "", "DPCONSECUTIVO", Class_VariablesGlobales.LIQUIDANDO, True, "")

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

   

End Class