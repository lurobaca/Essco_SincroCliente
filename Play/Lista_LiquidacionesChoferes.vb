
Public Class Lista_LiquidacionesChoferes

    Private Sub Lista_LiquidacionesAgentes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLiquidaciones_Choferes(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.LIQUIDANDO, "", "", "")
    End Sub

    Private Sub DGV_Liquidaciones_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_Liquidaciones.CellClick
        Try
            Class_VariablesGlobales.CREANDO_LIQ_CHOFER = False

            Class_VariablesGlobales.frmLiqChof.btn_AddRecibos.Enabled = True






            Class_VariablesGlobales.NumLiqui = DGV_Liquidaciones.CurrentRow.Cells.Item(0).Value
            Class_VariablesGlobales.NumLiqui_Chofer = Class_VariablesGlobales.NumLiqui
            Class_VariablesGlobales.LiquidacionRecuperada = Class_VariablesGlobales.NumLiqui
            Class_VariablesGlobales.frmLiqChof.txtb_Consecutivo.Text = DGV_Liquidaciones.CurrentRow.Cells.Item(0).Value
            Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text = DGV_Liquidaciones.CurrentRow.Cells.Item(2).Value
            Class_VariablesGlobales.frmLiqChof.txtb_Cedula.Text = DGV_Liquidaciones.CurrentRow.Cells.Item(3).Value
            Class_VariablesGlobales.frmLiqChof.txt_NombreChofer.Text = DGV_Liquidaciones.CurrentRow.Cells.Item(4).Value

            Class_VariablesGlobales.frmLiqChof.txtb_Comentarios.Text = DGV_Liquidaciones.CurrentRow.Cells.Item(7).Value
            Class_VariablesGlobales.frmLiqChof.txtb_Ruta.Text = DGV_Liquidaciones.CurrentRow.Cells.Item(11).Value
            Class_VariablesGlobales.frmLiqChof.dtp_FechaIni_Recibos.Value = DGV_Liquidaciones.CurrentRow.Cells.Item(12).Value
            Class_VariablesGlobales.frmLiqChof.dtp_FechaFin_Recibos.Value = DGV_Liquidaciones.CurrentRow.Cells.Item(13).Value

            'Class_VariablesGlobales.frmLiqChof.Txtb_RepFactura.Text = DGV_Liquidaciones.CurrentRow.Cells.Item(14).Value


            Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Value = DGV_Liquidaciones.CurrentRow.Cells.Item(5).Value
            Class_VariablesGlobales.frmLiqChof.dtp_FechaFin.Value = DGV_Liquidaciones.CurrentRow.Cells.Item(6).Value



            Class_VariablesGlobales.frmLiqChof.btn_Cargar_Click(sender, e)
            'verifica si esta anulada
            If DGV_Liquidaciones.CurrentRow.Cells.Item(9).Value = "1" Then
                Class_VariablesGlobales.frmLiqChof.btn_Anular.Enabled = False
                Class_VariablesGlobales.frmLiqChof.TabControl1.Enabled = False
                Class_VariablesGlobales.Chofer = Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text
                Class_VariablesGlobales.frmLiqChof.btn_Cargar.Enabled = False
                Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Enabled = False
                Class_VariablesGlobales.frmLiqChof.dtp_FechaFin.Enabled = False

                Class_VariablesGlobales.frmLiqChof.btn_Guardar.Enabled = False
                Class_VariablesGlobales.frmLiqChof.btn_Imprimir.Enabled = True
                Class_VariablesGlobales.frmLiqChof.lbl_Anulado.Visible = True
                Class_VariablesGlobales.frmLiqChof.txtb_Diferencias.Enabled = False


            Else
                Class_VariablesGlobales.frmLiqChof.lbl_Anulado.Visible = False
                Class_VariablesGlobales.frmLiqChof.btn_Anular.Enabled = True
                Class_VariablesGlobales.frmLiqChof.lbl_Anulado.Visible = False
                Class_VariablesGlobales.frmLiqChof.TabControl1.Enabled = True
                Class_VariablesGlobales.Chofer = Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text
                Class_VariablesGlobales.frmLiqChof.btn_Cargar.Enabled = True
                Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Enabled = True
                Class_VariablesGlobales.frmLiqChof.dtp_FechaFin.Enabled = True

                Class_VariablesGlobales.frmLiqChof.btn_Imprimir.Enabled = True
            End If


            Class_VariablesGlobales.frmLiqChof.btn_Guardar.Text = "MODIFICAR"



            Dim cont As Integer = 0
            Do While Class_VariablesGlobales.frmLiqChof.ListView_Agentes.Items.Count <> 0
                Class_VariablesGlobales.frmLiqChof.ListView_Agentes.Items.Remove(Class_VariablesGlobales.frmLiqChof.ListView_Agentes.Items(0))

            Loop

            Dim Cadena As String = DGV_Liquidaciones.CurrentRow.Cells.Item(10).Value
            Dim Ag As String = ""
            For x = 0 To Cadena.Length - 1

                If Cadena.Chars(x) = "," Then
                    Class_VariablesGlobales.frmLiqChof.ListView_Agentes.Items.Add(Ag)
                    Ag = ""
                Else
                    Ag = Ag & (Cadena.Chars(x))

                End If
            Next

            cont = 0
            Do While Class_VariablesGlobales.frmLiqChof.ListV_Reportes.Items.Count <> 0
                Class_VariablesGlobales.frmLiqChof.ListV_Reportes.Items.Remove(Class_VariablesGlobales.frmLiqChof.ListV_Reportes.Items(0))

            Loop
            Cadena = ""

            Cadena = DGV_Liquidaciones.CurrentRow.Cells.Item(14).Value
            Dim Rep As String = ""
            For x = 0 To Cadena.Length - 1

                If Cadena.Chars(x) = "," Then
                    Class_VariablesGlobales.frmLiqChof.ListV_Reportes.Items.Add(Rep)
                    Rep = ""
                Else
                    Rep = Rep & (Cadena.Chars(x))

                End If
            Next
            'Class_VariablesGlobales.frmLiqChof.ListV_Reportes.Items.Add(Rep)

            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Close()
        End Try
    End Sub



    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DGV_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLiquidaciones_Choferes(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.LIQUIDANDO, dtp_Desde.Value, dtp_Hasta.Value, txtb_NumLiq.Text)
    End Sub


    Private Sub dtp_Desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_Desde.ValueChanged
        DGV_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLiquidaciones_Choferes(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.LIQUIDANDO, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_Desde.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_Hasta.Value.Date), "")
    End Sub
    Private Sub dtp_Hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_Hasta.ValueChanged
        DGV_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLiquidaciones_Choferes(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.LIQUIDANDO, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_Desde.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_Hasta.Value.Date), "")

    End Sub

    Private Sub txtb_NumLiq_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtb_NumLiq.TextChanged
        dtp_Desde.Value = Now.Date
        dtp_Hasta.Value = Now.Date
        DGV_Liquidaciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLiquidaciones_Choferes(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.LIQUIDANDO, "", "", txtb_NumLiq.Text)




    End Sub






    Private Sub Lista_LiquidacionesChoferes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub DGV_Liquidaciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Liquidaciones.CellContentClick

    End Sub
End Class