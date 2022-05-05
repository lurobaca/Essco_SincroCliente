Public Class ListaAgentes
    Public Puesto As String
    Private Sub ListaAgentes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        dgv_Agentes.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman1, Puesto, "")
        dgv_Agentes.Columns(0).Width = 40
        dgv_Agentes.Columns(1).Width = 250
    End Sub






    Private Sub dgv_Agentes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_Agentes.CellContentClick
        If Class_VariablesGlobales.Lista_llamadaDesde = "EXPORTAR" Then
            dgv_Agentes.Rows(dgv_Agentes.CurrentRow.Index).Selected = True
        End If

    End Sub

    Private Sub btn_AgregarRep_Click(sender As Object, e As EventArgs) Handles btn_AgregarRep.Click

        Try


            Dim existe As Boolean = False
            If Class_VariablesGlobales.Lista_llamadaDesde = "EXPORTAR" Then
                For x = 0 To Class_VariablesGlobales.frmEnviar_Info_Seller.ListV_Reportes.Items.Count - 1

                    Class_VariablesGlobales.frmEnviar_Info_Seller.ListV_Reportes.Items.RemoveByKey(x)
                Next
                For Contador = 0 To dgv_Agentes.RowCount - 1

                    If dgv_Agentes(0, Contador).Selected Then
                        Class_VariablesGlobales.frmEnviar_Info_Seller.ListV_Reportes.Items.Add(dgv_Agentes(0, Contador).Value)
                    End If
                Next
            ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "REPORTE" Then
                Class_VariablesGlobales.frmREPORTE.txtb_CodAgente.Text = dgv_Agentes.CurrentRow.Cells.Item(0).Value
                Class_VariablesGlobales.frmREPORTE.txtb_NombreAgente.Text = dgv_Agentes.CurrentRow.Cells.Item(1).Value
            ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "GASTOS" Then
                Class_VariablesGlobales.frmDetGastos.txb_CodAgente.Text = dgv_Agentes.CurrentRow.Cells.Item(0).Value
                Class_VariablesGlobales.frmDetGastos.txb_NomAgente.Text = dgv_Agentes.CurrentRow.Cells.Item(1).Value
            ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "DEPOSITOS" Then
                Class_VariablesGlobales.frmDeposAgente.txb_CodAgente.Text = dgv_Agentes.CurrentRow.Cells.Item(0).Value
                Class_VariablesGlobales.frmDeposAgente.txb_NomAgente.Text = dgv_Agentes.CurrentRow.Cells.Item(1).Value
            ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "LIQ_AGENTE" Then

                Class_VariablesGlobales.CodAgenteLiq = dgv_Agentes.CurrentRow.Cells.Item(0).Value
                Class_VariablesGlobales.NomAgenteLiq = dgv_Agentes.CurrentRow.Cells.Item(1).Value


                Class_VariablesGlobales.frmLiqAge.txtb_CodAgente.Text = dgv_Agentes.CurrentRow.Cells.Item(0).Value
                Class_VariablesGlobales.frmLiqAge.txtb_NombreAgente.Text = dgv_Agentes.CurrentRow.Cells.Item(1).Value
                Class_VariablesGlobales.frmLiqAge.txtb_NombreAgente.Text = dgv_Agentes.CurrentRow.Cells.Item(1).Value
                Class_VariablesGlobales.frmLiqAge.txtb_Cedula.Text = dgv_Agentes.CurrentRow.Cells.Item(11).Value
                Class_VariablesGlobales.frmLiqAge.TabControl1.Enabled = True
                Class_VariablesGlobales.Agente = Class_VariablesGlobales.frmLiqAge.txtb_CodAgente.Text
                Class_VariablesGlobales.frmLiqAge.btn_Cargar.Enabled = True
                Class_VariablesGlobales.frmLiqAge.dtp_FechaIni.Enabled = True
                Class_VariablesGlobales.frmLiqAge.dtp_FechaFin.Enabled = True

                Class_VariablesGlobales.frmLiqAge.btn_Guardar.Enabled = True
                Class_VariablesGlobales.frmLiqAge.btn_Anular.Enabled = False
                Class_VariablesGlobales.frmLiqAge.txtb_Comentarios.Enabled = True
                Class_VariablesGlobales.frmLiqAge.dtp_FechaIni.Focus()
                Class_VariablesGlobales.frmLiqAge.Cargar()
            ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "LISTADEPOSITOS" Then
                Class_VariablesGlobales.frmListaDepos.txtb_CodAgente.Text = dgv_Agentes.CurrentRow.Cells.Item(0).Value
                'Class_VariablesGlobales.frmListaDepos.Txb_NumDepo.Text = ""
                'Class_VariablesGlobales.frmListaDepos.Txb_Consecutivo.Text = ""

            ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "LISTAGASTOS" Then
                Class_VariablesGlobales.frmListaDetGastos.txtb_CodAgente.Text = dgv_Agentes.CurrentRow.Cells.Item(0).Value
                'Class_VariablesGlobales.frmListaDetGastos.Txb_NumGasto.Text = ""
                'Class_VariablesGlobales.frmListaDetGastos.Txb_Consecutivo.Text = ""

            ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "LIQ_CHOFERES" Then

                If Class_VariablesGlobales.frmLiqChof.ListView_Agentes.Items.Count > 0 Then
                    'debe reccorrer el list view para ver si el dato no existe
                    For Each i In Class_VariablesGlobales.frmLiqChof.ListView_Agentes.Items

                        If i.Text = dgv_Agentes.CurrentRow.Cells.Item(0).Value Then
                            MsgBox("El agente ya existe en la lista " & vbLf & " seleccione otro agente")
                            existe = True
                            Exit For


                        End If


                    Next
                    If existe = False Then
                        Class_VariablesGlobales.frmLiqChof.ListView_Agentes.Items.Add(dgv_Agentes.CurrentRow.Cells.Item(0).Value)
                    End If

                Else
                    Class_VariablesGlobales.frmLiqChof.ListView_Agentes.Items.Add(dgv_Agentes.CurrentRow.Cells.Item(0).Value)
                End If




                'Class_VariablesGlobales.frmLiqChof.txtb_CodAgente.Text = dgv_Agentes.CurrentRow.Cells.Item(0).Value
                'Class_VariablesGlobales.frmLiqChof.txtb_NombreAgente.Text = dgv_Agentes.CurrentRow.Cells.Item(1).Value
                'Class_VariablesGlobales.frmLiqChof.txtb_NombreAgente.Text = dgv_Agentes.CurrentRow.Cells.Item(1).Value
                'Class_VariablesGlobales.frmLiqChof.txtb_Cedula.Text = dgv_Agentes.CurrentRow.Cells.Item(11).Value
                'Class_VariablesGlobales.frmLiqChof.TabControl1.Enabled = True
                ''Class_VariablesGlobales.Chofer  = Class_VariablesGlobales.frmLiqAge.txtb_CodAgente.Text

                'Class_VariablesGlobales.frmLiqAge.btn_Cargar.Enabled = True
                'Class_VariablesGlobales.frmLiqAge.dtp_FechaIni.Enabled = True
                'Class_VariablesGlobales.frmLiqAge.dtp_FechaFin.Enabled = True
                'Class_VariablesGlobales.frmLiqAge.btn_Modificar.Enabled = False
                'Class_VariablesGlobales.frmLiqAge.btn_Guardar.Enabled = True
                'Class_VariablesGlobales.frmLiqAge.btn_Anular.Enabled = False
                'Class_VariablesGlobales.frmLiqAge.txtb_Comentarios.Enabled = True


                'Class_VariablesGlobales.frmLiqAge.dtp_FechaIni.Focus()
                'Class_VariablesGlobales.frmLiqAge.Cargar()
            ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "NOTASPENDIENTES" Then
                Class_VariablesGlobales.frmDevolucionesPendientes.txtb_CodAgente.Text = dgv_Agentes.CurrentRow.Cells.Item(0).Value

            End If

            If existe = False Then
                Me.Close()
            End If

            Me.Close()


        Catch ex As Exception

            MsgBox(ex.Message)

            Me.Close()
        End Try

    End Sub

    Private Sub dgv_Agentes_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Agentes.CellContentDoubleClick

    End Sub
End Class