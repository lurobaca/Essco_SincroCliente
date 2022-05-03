Public Class Detalle_Gastos_Choferes


    Dim Empleado As String
    Dim EsFE As String
    'Dim NuevoSistem As Boolean
    Private Sub Detalle_Gastos_Choferes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'Nuevo()


        txb_CodAgente.Text = Class_VariablesGlobales.CodChoferLiq
        txb_NomAgente.Text = Class_VariablesGlobales.NomChoferLiq
        txb_Liquidacion.Text = Class_VariablesGlobales.NumLiqChoferLiq
        Empleado = Class_VariablesGlobales.Chofer


        Class_VariablesGlobales.frmDetGastos_Choferes = Me
        Txtb_DocNum.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivoGasto(Class_VariablesGlobales.SQL_Comman1)


        If Class_VariablesGlobales.Obj_Funciones_SQL.VerificaGastoLiqAge_Anulado(Class_VariablesGlobales.SQL_Comman1, Txtb_DocNum.Text) = "1" Then
            Lbl_Anulado.Visible = True
            Lbl_Anulado.Text = "ANULADO"
            Lbl_Anulado.ForeColor = Color.Red
            btn_AgElimina.Enabled = False
            btn_AgGuardar.Enabled = False
        Else
            Lbl_Anulado.Visible = True
            Lbl_Anulado.Text = "GASTOS"
            Lbl_Anulado.ForeColor = Color.Black
            btn_AgElimina.Enabled = False
            btn_AgGuardar.Enabled = True

        End If


        If Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION" Then

            Lbl_Anulado.Text = Class_VariablesGlobales.TituloDetalleGasto

            dgv_DetGastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, "", "CHOFERES", Class_VariablesGlobales.TituloDetalleGasto, Class_VariablesGlobales.Chofer, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaIni), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaFin), "", "", False, CBox_IncluidoEnLiquidacion.Checked)
            txb_Total.Text = FormatCurrency(Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalGastosChoferes(Class_VariablesGlobales.SQL_Comman1, "", "CHOFERES", Class_VariablesGlobales.TituloDetalleGasto, Class_VariablesGlobales.Chofer, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaIni), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaFin), False, False, True), 2, True)





            If Class_VariablesGlobales.TituloDetalleGasto = "Viaticos" Then
                Cbx_Tipo.Text = "Viaticos"
            End If
            If Class_VariablesGlobales.TituloDetalleGasto = "Combustible" Then
                Cbx_Tipo.Text = "Combustible"
            End If
            If Class_VariablesGlobales.TituloDetalleGasto = "Hospedaje" Then
                Cbx_Tipo.Text = "Hospedaje"
            End If
            If Class_VariablesGlobales.TituloDetalleGasto = "Imprevistos" Then
                Cbx_Tipo.Text = "Imprevistos"
            End If
            If Class_VariablesGlobales.TituloDetalleGasto = "Otros" Then
                Cbx_Tipo.Text = "Otros"
            End If




            Panel1.Visible = True
        Else


            Panel1.Visible = False
            Me.Width = 446
            Me.StartPosition = FormStartPosition.CenterScreen




        End If




    End Sub

    Private Sub btn_AgGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgGuardar.Click
        'ByVal SQL_Comman As SqlCommand, ByVal txb_NumDoc As String, ByVal txb_Monto As String, ByVal txb_Descripcion As String, ByVal Tipo As String, ByVal ConseLiqui As String, ByVal TipoLiqui As String, ByVal CodAgente As String, ByVal Fecha As String

        Dim problema As Boolean = False

        Dim liqNum As String

        If txb_Liquidacion.Text = "" Then
            liqNum = "0"
        Else
            liqNum = txb_Liquidacion.Text
        End If



        If btn_AgGuardar.Text = "GUARDAR" Then
            If Cbx_Tipo.Text = "" Then
                MsgBox("Debe ingresar el tipo del Gasto")

            ElseIf txb_Monto.Text = "" Then
                MsgBox("Debe ingresar el Monto del Gasto")
            ElseIf txb_NumDoc.Text = "" Then
                MsgBox("Debe ingresar el Numero de Documento del Gasto")
            ElseIf txb_Codigo.Text = "" And RBt_NO.Checked = True Then
                MsgBox("Debe ingresar proveedor para generar la Factura Electronica de Compra")
            Else
                If Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION" Then


                    problema = Class_VariablesGlobales.Obj_Funciones_SQL.InsertaGasto(Class_VariablesGlobales.SQL_Comman1, Trim(txb_NumDoc.Text), Trim(txb_Monto.Text), Trim(txb_Descripcion.Text), Trim(Cbx_Tipo.Text), Trim(liqNum), Trim(Class_VariablesGlobales.TipoLiqui), Trim(Empleado), Trim(Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaGasto.Value.Date)), Txtb_DocNum.Text, Trim(Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaGasto.Value.Date)), EsFE, txb_Codigo.Text, CBox_IncluidoEnLiquidacion.Checked)
                    dgv_DetGastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, "", Class_VariablesGlobales.TipoLiqui, Class_VariablesGlobales.TituloDetalleGasto, Empleado, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaIni), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaFin), "", "", False, CBox_IncluidoEnLiquidacion.Checked)
                    txb_Total.Text = FormatCurrency(Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalGastosChoferes(Class_VariablesGlobales.SQL_Comman1, "", Class_VariablesGlobales.TipoLiqui, Class_VariablesGlobales.TituloDetalleGasto, Empleado, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaIni), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaFin), False, False, True), 2)


                Else
                    problema = Class_VariablesGlobales.Obj_Funciones_SQL.InsertaGasto(Class_VariablesGlobales.SQL_Comman1, Trim(txb_NumDoc.Text), Trim(txb_Monto.Text), Trim(txb_Descripcion.Text), Trim(Cbx_Tipo.Text), Trim(txb_Liquidacion.Text), Class_VariablesGlobales.LIQUIDANDO, Trim(txb_CodAgente.Text), Trim(Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaGasto.Value.Date)), Txtb_DocNum.Text, Trim(Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaGasto.Value.Date)), EsFE, txb_Codigo.Text, CBox_IncluidoEnLiquidacion.Checked)

                End If
                If problema = False Then

                    Class_VariablesGlobales.Obj_Funciones_SQL.ModificaConsecutivSistema(Class_VariablesGlobales.SQL_Comman1, CInt(Txtb_DocNum.Text) + 1)
                    'If NuevoSistem = True Then
                    '    NuevoSistem = False

                    'End If
                    'Impide limpiar los datos de la ventana para por reenvio de FEC
                    If Class_VariablesGlobales.LimpiarGastoChofer = True Then
                        limpiar()
                    End If
                End If



            End If

            'MODIFICAR
        Else

            If Cbx_Tipo.Text = "" Then
                MsgBox("Debe ingresar el TIPO del Gasto")

            ElseIf txb_Monto.Text = "" Then
                MsgBox("Debe ingresar el MONTO del Gasto")
            ElseIf txb_NumDoc.Text = "" Then
                MsgBox("Debe ingresar el NUMERO DE DOCUMENTO del Gasto")
            ElseIf txb_CodAgente.Text = "" Then
                MsgBox("Debe ingresar el AGENTE DE VENTAS  del Gasto")
            Else
                If Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION" Then
                    Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaGasto(Class_VariablesGlobales.SQL_Comman1, txb_NumDoc.Text, txb_Monto.Text, txb_Descripcion.Text, Trim(Cbx_Tipo.Text), liqNum, "CHOFERES", Trim(txb_CodAgente.Text), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaGasto.Value), Txtb_DocNum.Text, CBox_IncluidoEnLiquidacion.Checked, False)
                    dgv_DetGastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, "", "CHOFERES", Class_VariablesGlobales.TituloDetalleGasto, Empleado, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaIni), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaFin), "", "", False, True)
                    txb_Total.Text = FormatCurrency(Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalGastosChoferes(Class_VariablesGlobales.SQL_Comman1, "", "CHOFERES", Class_VariablesGlobales.TituloDetalleGasto, Empleado, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaIni), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaFin), False, False, True), 2)
                Else

                    Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaGasto(Class_VariablesGlobales.SQL_Comman1, txb_NumDoc.Text, txb_Monto.Text, txb_Descripcion.Text, Trim(Cbx_Tipo.Text), txb_Liquidacion.Text, "CHOFERES", Trim(txb_CodAgente.Text), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaGasto.Value), Txtb_DocNum.Text, CBox_IncluidoEnLiquidacion.Checked, False)
                End If




                limpiar()
            End If

            MsgBox("Gastos actualizado con exito")
        End If

        'Impide limpiar los datos de la ventana para por reenvio de FEC
        If Class_VariablesGlobales.LimpiarGastoChofer = True Then
            Nuevo()
        End If


    End Sub

    Public Function limpiar()
        Txtb_DocNum.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivoGasto(Class_VariablesGlobales.SQL_Comman1)
        txb_NumDoc.Text = ""
        txb_Monto.Text = ""
        txb_Descripcion.Text = ""
        txb_Liquidacion.Text = ""

        dtp_FechaGasto.Value = Today.Date
        txb_CodAgente.Text = ""
        txb_NomAgente.Text = ""


        RBt_SI.Checked = True


        txb_Codigo.Text = ""
        txb_Nombre.Text = ""
        txb_Cedula.Text = ""
        txb_Correo.Text = ""
        txtb_EstadoMH.Text = ""

        Cbx_Tipo.Enabled = False

        'txb_NumDoc.Enabled = False
        txb_Monto.Enabled = False
        txb_Descripcion.Enabled = False
        Txtb_DocNum.Enabled = False
        dtp_FechaGasto.Enabled = False
        CBox_IncluidoEnLiquidacion.Checked = True
    End Function

    Public Sub btn_AgNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgNuevo.Click
        Nuevo()
    End Sub


    Public Function Nuevo()
        limpiar()

        txb_NumDoc.Enabled = True
        txb_Monto.Enabled = True
        txb_Descripcion.Enabled = True
        dtp_FechaGasto.Enabled = True
        'NuevoSistem = True
        btn_Agentes.Enabled = True
        btn_AgGuardar.Text = "GUARDAR"

        btn_AgElimina.Enabled = False
        Cbx_Tipo.Enabled = True


        txb_Liquidacion.Enabled = False

        btn_GoToLiq.Enabled = False

        Txtb_DocNum.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivoGasto(Class_VariablesGlobales.SQL_Comman1)
        If Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION" Then

            dgv_DetGastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, "", Class_VariablesGlobales.TipoLiqui, Class_VariablesGlobales.TituloDetalleGasto, Class_VariablesGlobales.Chofer, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaIni), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaFin), "", "", False, True)


        End If


        txb_CodAgente.Text = Class_VariablesGlobales.CodChoferLiq
        txb_NomAgente.Text = Class_VariablesGlobales.NomChoferLiq
        txb_Liquidacion.Text = Class_VariablesGlobales.NumLiqChoferLiq


        If Class_VariablesGlobales.TituloDetalleGasto = "Viaticos" Then
            Cbx_Tipo.Text = "Viaticos"
        End If
        If Class_VariablesGlobales.TituloDetalleGasto = "Combustible" Then
            Cbx_Tipo.Text = "Combustible"
        End If
        If Class_VariablesGlobales.TituloDetalleGasto = "Hospedaje" Then
            Cbx_Tipo.Text = "Hospedaje"
        End If
        If Class_VariablesGlobales.TituloDetalleGasto = "Imprevistos" Then
            Cbx_Tipo.Text = "Imprevistos"
        End If
        If Class_VariablesGlobales.TituloDetalleGasto = "Otros" Then
            Cbx_Tipo.Text = "Otros"
        End If

        txb_NumDoc.Focus()

    End Function

    Private Sub btn_AgElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AgElimina.Click
        Dim result1 As DialogResult = MessageBox.Show("Si anula el gasto no podra editarlo\n Realmente desea anular el Gastos?", _
               "Important Question", _
               MessageBoxButtons.YesNo)

        If result1 = DialogResult.Yes Then
            Class_VariablesGlobales.Obj_Funciones_SQL.AnulaGastoLiqAge(Class_VariablesGlobales.SQL_Comman1, Trim(Txtb_DocNum.Text))
            If Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION" Then

                txb_Total.Text = FormatCurrency(Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalGastosChoferes(Class_VariablesGlobales.SQL_Comman1, "", Class_VariablesGlobales.TipoLiqui, Class_VariablesGlobales.TituloDetalleGasto, Empleado, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaIni), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaFin), False, False, True), 2)
                dgv_DetGastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, "", Class_VariablesGlobales.TipoLiqui, Class_VariablesGlobales.TituloDetalleGasto, Empleado, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaIni), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaFin), "", "", False, CBox_IncluidoEnLiquidacion.Checked)

            End If

            limpiar()
            btn_AgGuardar.Text = "GUARDAR"

            btn_AgElimina.Enabled = False
        End If
        If result1 = DialogResult.No Then


        End If
    End Sub

    Private Sub Detalle_Gastos_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing


        If Class_VariablesGlobales.Gastos_llamadaDesde = "LIQUIDACION" Then


            Class_VariablesGlobales.frmLiqChof.btn_Cargar_Click(sender, e)



        End If


    End Sub


    Private Sub btn_BuscaGasto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaGasto.Click
        Class_VariablesGlobales.frmListaDetGastos_Choferes = New Lista_Gastos_Choferes
        Class_VariablesGlobales.frmListaDetGastos_Choferes.MdiParent = Principal
        Class_VariablesGlobales.frmListaDetGastos_Choferes.Show()

        'Class_VariablesGlobales.frmListaDetGastos_Choferes.TopMost = True

    End Sub

    Private Sub dgv_DetGastos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_DetGastos.CellClick
        Try
            btn_AgGuardar.Text = "MODIFICAR"
            Txtb_DocNum.Text = dgv_DetGastos.CurrentRow.Cells.Item(0).Value
            Cbx_Tipo.Text = dgv_DetGastos.CurrentRow.Cells.Item(1).Value
            txb_NumDoc.Text = dgv_DetGastos.CurrentRow.Cells.Item(2).Value
            txb_Monto.Text = dgv_DetGastos.CurrentRow.Cells.Item(3).Value
            txb_Descripcion.Text = dgv_DetGastos.CurrentRow.Cells.Item(4).Value
            dtp_FechaGasto.Value = dgv_DetGastos.CurrentRow.Cells.Item(7).Value
            txb_Liquidacion.Text = dgv_DetGastos.CurrentRow.Cells.Item(5).Value

            'Dastos de FEC
            CBox_IncluidoEnLiquidacion.Checked = CBox_IncluidoEnLiquidacion.Checked
            If dgv_DetGastos.CurrentRow.Cells.Item(10).Value = "false" Then
                RBt_NO.Checked = True
            End If
            Try
                txb_Codigo.Text = dgv_DetGastos.CurrentRow.Cells.Item(11).Value
                txb_Nombre.Text = dgv_DetGastos.CurrentRow.Cells.Item(12).Value
                txb_Cedula.Text = dgv_DetGastos.CurrentRow.Cells.Item(13).Value
                txb_Correo.Text = dgv_DetGastos.CurrentRow.Cells.Item(14).Value
                txtb_EstadoMH.Text = dgv_DetGastos.CurrentRow.Cells.Item(15).Value
            Catch ex As Exception

            End Try





            txb_Liquidacion.Enabled = True
            btn_GoToLiq.Enabled = True




            txb_CodAgente.Text = dgv_DetGastos.CurrentRow.Cells.Item(8).Value
            If Trim(dgv_DetGastos.CurrentRow.Cells.Item(8).Value.ToString) <> "" Then
                txb_NomAgente.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneNameAgente(Class_VariablesGlobales.SQL_Comman1, Trim(dgv_DetGastos.CurrentRow.Cells.Item(8).Value.ToString))
            End If


            btn_AgGuardar.Text = "MODIFICAR"

            btn_AgElimina.Enabled = True


            txb_NumDoc.Enabled = True
            txb_Monto.Enabled = True
            txb_Descripcion.Enabled = True

            dtp_FechaGasto.Enabled = True

            If Class_VariablesGlobales.Obj_Funciones_SQL.VerificaGastoLiqAge_Anulado(Class_VariablesGlobales.SQL_Comman1, Txtb_DocNum.Text) = "1" Then
                Lbl_Anulado.Visible = True
                Lbl_Anulado.Text = "GASTO ANULADO"
                Lbl_Anulado.ForeColor = Color.Red
                btn_AgElimina.Enabled = False
            Else
                Lbl_Anulado.Visible = True
                If Lbl_Anulado.Text = "GASTO ANULADO" Then
                    Lbl_Anulado.Text = "GASTOS"
                End If

                Lbl_Anulado.ForeColor = Color.Black
                btn_AgElimina.Enabled = True

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_Agentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Agentes.Click

        ListaChoferes.Show()


        Class_VariablesGlobales.Lista_llamadaDesde = "GASTOS"
    End Sub

    Private Sub btn_GoToLiq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GoToLiq.Click

        Class_VariablesGlobales.NumLiqui = txb_Liquidacion.Text

        Class_VariablesGlobales.TipoLiqui = Class_VariablesGlobales.LIQUIDANDO
        Dim tabla As DataTable

        Try



            tabla = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLiquidaciones_Choferes(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.LIQUIDANDO, "", "", txb_Liquidacion.Text)
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
            Class_VariablesGlobales.frmLiqChof.btn_Anular.Enabled = True
            Class_VariablesGlobales.frmLiqChof.Show()

            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Liquidacion no existe [ " & ex.Message & "]")
        End Try

    End Sub

    Private Sub txb_NumDoc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txb_NumDoc.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then


            Class_VariablesGlobales.NumGastoBuscando = txb_NumDoc.Text
            Dim tablas As New DataTable
            Dim cont As Integer


            tablas = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, "", "AGENTES", "", "", "", "", Class_VariablesGlobales.NumGastoBuscando, "", True, True)
            '[DocNum],[Tipo] ,[NumDoc] ,[Monto] ,[Descripcion] ,[ConseLiqui],[TipoLiqui],[FechaGasto],[CodAgente],[Anulado]

            For Each row As DataRow In tablas.Rows

                Txtb_DocNum.Text = tablas.Rows(0).Item("DocNum").ToString
                txb_NumDoc.Text = tablas.Rows(0).Item("NumDoc").ToString
                txb_Monto.Text = tablas.Rows(0).Item("Monto").ToString
                txb_Descripcion.Text = tablas.Rows(0).Item("Descripcion").ToString
                dtp_FechaGasto.Value = tablas.Rows(0).Item("FechaGasto").ToString
                Lbl_Anulado.Text = tablas.Rows(0).Item("Anulado").ToString
                Cbx_Tipo.Text = tablas.Rows(0).Item("Tipo").ToString
                txb_CodAgente.Text = tablas.Rows(0).Item("CodAgente").ToString

                If Trim(tablas.Rows(0).Item("CodAgente").ToString) <> "" Then
                    txb_NomAgente.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneNameAgente(Class_VariablesGlobales.SQL_Comman1, Trim(tablas.Rows(0).Item("CodAgente").ToString))
                End If

                txb_Liquidacion.Text = tablas.Rows(0).Item("ConseLiqui").ToString
                Txtb_DocNum.Enabled = True
                txb_NumDoc.Enabled = True
                txb_Monto.Enabled = True
                txb_Descripcion.Enabled = True
                dtp_FechaGasto.Enabled = True
                btn_AgElimina.Enabled = True
                btn_Agentes.Enabled = True
                btn_GoToLiq.Enabled = True
                Cbx_Tipo.Enabled = True


                btn_AgGuardar.Text = "MODIFICAR"
                If tablas.Rows(0).Item("ConseLiqui").ToString = "0" Then
                    btn_GoToLiq.Enabled = False
                End If

                If Class_VariablesGlobales.Obj_Funciones_SQL.VerificaGastoLiqAge_Anulado(Class_VariablesGlobales.SQL_Comman1, Txtb_DocNum.Text) = "1" Then
                    Lbl_Anulado.Visible = True
                    Lbl_Anulado.Text = "GASTO ANULADO"
                    Lbl_Anulado.ForeColor = Color.Red
                    btn_AgElimina.Enabled = False
                    btn_AgGuardar.Text = "GUARDAR"

                Else
                    Lbl_Anulado.Visible = True
                    Lbl_Anulado.Text = "GASTOS"
                    Lbl_Anulado.ForeColor = Color.Black
                    btn_AgElimina.Enabled = True
                    btn_AgGuardar.Text = "MODIFICAR"
                End If







                cont += 1

            Next



            'Class_VariablesGlobales.frmListaDetGastos = New Lista_Gastos
            'Class_VariablesGlobales.frmListaDetGastos.MdiParent = Principal
            'Class_VariablesGlobales.frmListaDetGastos.Show()


        End If
    End Sub

    Private Sub Txtb_DocNum_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtb_DocNum.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then


            Class_VariablesGlobales.ConseGastoBuscando = Txtb_DocNum.Text

            Class_VariablesGlobales.frmListaDepos = New Lista_Depositos
            Class_VariablesGlobales.frmListaDepos.MdiParent = Principal
            Class_VariablesGlobales.frmListaDepos.Show()


        End If
    End Sub

    Private Sub Detalle_Gastos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Private Sub Cbx_Tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbx_Tipo.SelectedIndexChanged
        Class_VariablesGlobales.TituloDetalleGasto = Cbx_Tipo.Text
        Lbl_Anulado.Text = Cbx_Tipo.Text
        'dgv_DetGastos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneGastosChoferes(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.frmLiqChof.txtb_Consecutivo.Text, "CHOFERES", Class_VariablesGlobales.TituloDetalleGasto, Class_VariablesGlobales.Chofer, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaIni), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaFin), "", "", False, CBox_IncluidoEnLiquidacion.Checked)
        'txb_Total.Text = FormatCurrency(Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneTotalGastosChoferes(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.frmLiqChof.txtb_Consecutivo.Text, "CHOFERES", Class_VariablesGlobales.TituloDetalleGasto, Class_VariablesGlobales.Chofer, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaIni), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.FechaFin), False, False), 2, True)

    End Sub

    Private Sub RBt_NO_CheckedChanged(sender As Object, e As EventArgs) Handles RBt_NO.CheckedChanged
        If RBt_SI.Checked = True Then
            GBox_InfoProveedor.Enabled = False
            txb_Codigo.Text = ""
            txb_Nombre.Text = ""
            txb_Cedula.Text = ""
            txb_Correo.Text = ""
            EsFE = "true"
        Else
            GBox_InfoProveedor.Enabled = True
            EsFE = "false"
        End If
    End Sub

    Private Sub btn_IrProveedores_Click(sender As Object, e As EventArgs) Handles btn_IrProveedores.Click
        Class_VariablesGlobales.frmGastos_ListProveedores = New Gastos_ListProveedores
        Class_VariablesGlobales.frmGastos_ListProveedores.MdiParent = Principal
        Class_VariablesGlobales.frmGastos_ListProveedores.Show()
    End Sub

    Private Sub txtb_EstadoMH_TextChanged(sender As Object, e As EventArgs) Handles txtb_EstadoMH.TextChanged
        If txtb_EstadoMH.Text = "Aceptado" Then
            btn_ReenviarMH.Enabled = False
        Else
            btn_ReenviarMH.Enabled = True
        End If
    End Sub

    Private Sub btn_ReenviarMH_Click(sender As Object, e As EventArgs) Handles btn_ReenviarMH.Click
        Dim DocNumGastoAnterio As String = Txtb_DocNum.Text
        btn_AgGuardar.Text = "GUARDAR"
        txtb_EstadoMH.Text = "Nuevo"
        Class_VariablesGlobales.LimpiarGastoChofer = False

        Txtb_DocNum.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConsecutivoGasto(Class_VariablesGlobales.SQL_Comman1)
        btn_AgGuardar_Click(sender, e)
        'Anulamos el gasto actual
        Class_VariablesGlobales.Obj_Funciones_SQL.AnulaGastoLiqAge(Class_VariablesGlobales.SQL_Comman1, Trim(DocNumGastoAnterio))
        Lbl_Anulado.Visible = False
        btn_AgElimina.Enabled = True
        MessageBox.Show("El gasto con el consecutivo [" & DocNumGastoAnterio & "]  fue anuado y reegenerado con el consecutivo [" & Txtb_DocNum.Text & "],pronto sera enviado como Factura Electronca de compra", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Class_VariablesGlobales.LimpiarGastoChofer = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Consultara el estado del gasto en hacienda
        txtb_EstadoMH.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaEstadoDeFEC(Class_VariablesGlobales.SQL_Comman1, Trim(Txtb_DocNum.Text))
    End Sub
End Class