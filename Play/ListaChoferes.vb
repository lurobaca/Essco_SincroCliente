Public Class ListaChoferes

    Private Sub ListaAgentes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'dgv_Choferes.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneChoferes(Class_VariablesGlobales.SQL_Comman1, "", "")




        dgv_Choferes.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneAgentes(Class_VariablesGlobales.SQL_Comman1, "CHOFER", "")


        dgv_Choferes.Columns(0).Width = 40
        dgv_Choferes.Columns(1).Width = 250







    End Sub







    Private Sub ListaChoferes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Private Sub dgv_Choferes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgv_Choferes.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True

            Try


                If Class_VariablesGlobales.Lista_llamadaDesde = "REPORTE" Then
                    Class_VariablesGlobales.frmREPORTE_Choferes.txtb_CodAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(0).Value
                    Class_VariablesGlobales.frmREPORTE_Choferes.txtb_NombreAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(1).Value
                ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "REPORTE_FACTURAS" Then

                    Class_VariablesGlobales.Obj_Reporte_Facturas.Cbx_Chofer.Text = dgv_Choferes.Rows(dgv_Choferes.CurrentRow.Index - 1).Cells(1).Value.ToString()
                    Class_VariablesGlobales.Obj_Reporte_Facturas.btn_Limpiar.Focus()

                ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "GASTOS" Then
                    Class_VariablesGlobales.frmDetGastos.txb_CodAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(0).Value
                    Class_VariablesGlobales.frmDetGastos.txb_NomAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(1).Value
                ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "DEPOSITOS" Then


                    If Class_VariablesGlobales.LIQUIDANDO = "CHOFERES" Then
                        Class_VariablesGlobales.frmDeposChofer.txb_CodAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(0).Value
                        Class_VariablesGlobales.frmDeposChofer.txb_NomAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(1).Value
                    Else
                        Class_VariablesGlobales.frmDeposAgente.txb_CodAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(0).Value
                        Class_VariablesGlobales.frmDeposAgente.txb_NomAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(1).Value
                    End If



                ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "LIQ_CHOFERES" Then
                    Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text = dgv_Choferes.CurrentRow.Cells.Item(0).Value
                    Class_VariablesGlobales.frmLiqChof.txt_NombreChofer.Text = dgv_Choferes.CurrentRow.Cells.Item(1).Value
                    Class_VariablesGlobales.frmLiqChof.txtb_Cedula.Text = dgv_Choferes.CurrentRow.Cells.Item(11).Value
                    Class_VariablesGlobales.frmLiqChof.TabControl1.Enabled = True
                    Class_VariablesGlobales.Chofer = Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text
                    Class_VariablesGlobales.frmLiqChof.btn_Cargar.Enabled = True
                    Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Enabled = True
                    Class_VariablesGlobales.frmLiqChof.dtp_FechaFin.Enabled = True

                    Class_VariablesGlobales.frmLiqChof.btn_Guardar.Enabled = True
                    Class_VariablesGlobales.frmLiqChof.btn_Anular.Enabled = False
                    Class_VariablesGlobales.frmLiqChof.txtb_Comentarios.Enabled = True
                    Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Focus()
                    Class_VariablesGlobales.frmLiqChof.btn_Cargar.Enabled = True


                    Try

                        Class_VariablesGlobales.Fac_Llamadas_Desde = "LIQ_CHOFERES"
                        Dim MDIForm As New List_RepFacturas
                        MDIForm.MdiParent = Principal
                        MDIForm.Show()
                    Catch ex As Exception

                    End Try


                ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "LISTADEPOSITOS" Then
                    Class_VariablesGlobales.frmListaDepos.txtb_CodAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(0).Value
                    Class_VariablesGlobales.frmListaDepos.Txb_NumDepo.Text = ""
                    Class_VariablesGlobales.frmListaDepos.Txb_Consecutivo.Text = ""
                ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "LISTAGASTOS" Then
                    Class_VariablesGlobales.frmListaDetGastos.txtb_CodAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(0).Value
                    Class_VariablesGlobales.frmListaDetGastos.Txb_NumGasto.Text = ""
                    Class_VariablesGlobales.frmListaDetGastos.Txb_Consecutivo.Text = ""
                ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "LISTAGASTOS_CHOFERES" Then
                    Class_VariablesGlobales.frmListaDetGastos_Choferes.txtb_CodAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(0).Value
                    Class_VariablesGlobales.frmListaDetGastos_Choferes.Txb_NumGasto.Text = ""
                    Class_VariablesGlobales.frmListaDetGastos_Choferes.Txb_Consecutivo.Text = ""
                End If


                Me.Close()
            Catch ex As Exception

            End Try




        End If
    End Sub

    Private Sub dgv_Choferes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Choferes.CellDoubleClick

    End Sub

    Private Sub dgv_Choferes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Choferes.CellContentClick
        If Class_VariablesGlobales.Lista_llamadaDesde = "EXPORTAR" Then
            dgv_Choferes.Rows(dgv_Choferes.CurrentRow.Index).Selected = True
        End If



    End Sub

    Private Sub btn_AgregarRep_Click(sender As Object, e As EventArgs) Handles btn_AgregarRep.Click



        Try

            If Class_VariablesGlobales.Lista_llamadaDesde = "EXPORTAR" Then
                For x = 0 To Class_VariablesGlobales.frmEnviar_Info_Seller.ListV_Reportes.Items.Count - 1

                    Class_VariablesGlobales.frmEnviar_Info_Seller.ListV_Reportes.Items.RemoveByKey(x)
                Next
                For Contador = 0 To dgv_Choferes.RowCount - 1

                    If dgv_Choferes(0, Contador).Selected Then
                        Class_VariablesGlobales.frmEnviar_Info_Seller.ListV_Reportes.Items.Add(dgv_Choferes(0, Contador).Value)
                    End If
                Next

            ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "REPORTE" Then
                Class_VariablesGlobales.frmREPORTE_Choferes.txtb_CodAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(0).Value
                Class_VariablesGlobales.frmREPORTE_Choferes.ag = CInt(dgv_Choferes.CurrentRow.Cells.Item(0).Value)
                Class_VariablesGlobales.frmREPORTE_Choferes.txtb_NombreAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(1).Value

                'Class_VariablesGlobales.frmREPORTE_Choferes.Imprimir()


            ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "REPORTE_FACTURAS" Then

                Class_VariablesGlobales.Obj_Reporte_Facturas.Cbx_Chofer.Text = dgv_Choferes.CurrentRow.Cells.Item(1).Value
                Class_VariablesGlobales.Obj_Reporte_Facturas.btn_GenerarEnviar.Focus()
            ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "GASTOS" Then
                Class_VariablesGlobales.frmDetGastos.txb_CodAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(0).Value
                Class_VariablesGlobales.frmDetGastos.txb_NomAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(1).Value
            ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "DEPOSITOS" Then


                If Class_VariablesGlobales.LIQUIDANDO = "CHOFERES" Then
                    Class_VariablesGlobales.frmDeposChofer.txb_CodAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(0).Value
                    Class_VariablesGlobales.frmDeposChofer.txb_NomAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(1).Value
                Else
                    Class_VariablesGlobales.frmDeposAgente.txb_CodAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(0).Value
                    Class_VariablesGlobales.frmDeposAgente.txb_NomAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(1).Value
                End If



            ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "LIQ_CHOFERES" Then
                Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text = dgv_Choferes.CurrentRow.Cells.Item(0).Value
                Class_VariablesGlobales.frmLiqChof.txt_NombreChofer.Text = dgv_Choferes.CurrentRow.Cells.Item(1).Value
                Class_VariablesGlobales.frmLiqChof.txtb_Cedula.Text = dgv_Choferes.CurrentRow.Cells.Item(11).Value
                Class_VariablesGlobales.frmLiqChof.TabControl1.Enabled = True
                Class_VariablesGlobales.Chofer = Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text
                Class_VariablesGlobales.frmLiqChof.btn_Cargar.Enabled = True
                Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Enabled = True
                Class_VariablesGlobales.frmLiqChof.dtp_FechaFin.Enabled = True

                Class_VariablesGlobales.frmLiqChof.btn_Guardar.Enabled = True
                Class_VariablesGlobales.frmLiqChof.btn_Anular.Enabled = False
                Class_VariablesGlobales.frmLiqChof.txtb_Comentarios.Enabled = True
                Class_VariablesGlobales.frmLiqChof.dtp_FechaIni.Focus()
                Class_VariablesGlobales.frmLiqChof.btn_Cargar.Enabled = True


                Try

                    Class_VariablesGlobales.Fac_Llamadas_Desde = "LIQ_CHOFERES"
                    Dim MDIForm As New List_RepFacturas_LiqChofer
                    MDIForm.MdiParent = Principal
                    MDIForm.Show()
                Catch ex As Exception

                End Try


            ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "LISTADEPOSITOS" Then
                Class_VariablesGlobales.frmListaDeposChoferes.txtb_CodAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(0).Value
                'Class_VariablesGlobales.frmListaDepos.Txb_NumDepo.Text = ""
                'Class_VariablesGlobales.frmListaDepos.Txb_Consecutivo.Text = ""
            ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "LISTAGASTOS" Then
                Class_VariablesGlobales.frmListaDetGastos.txtb_CodAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(0).Value
                'Class_VariablesGlobales.frmListaDetGastos.Txb_NumGasto.Text = ""
                'Class_VariablesGlobales.frmListaDetGastos.Txb_Consecutivo.Text = ""
            ElseIf Class_VariablesGlobales.Lista_llamadaDesde = "LISTAGASTOS_CHOFERES" Then
                Class_VariablesGlobales.frmListaDetGastos_Choferes.txtb_CodAgente.Text = dgv_Choferes.CurrentRow.Cells.Item(0).Value
                Class_VariablesGlobales.frmListaDetGastos_Choferes.Txb_NumGasto.Text = ""
                Class_VariablesGlobales.frmListaDetGastos_Choferes.Txb_Consecutivo.Text = ""
            End If


            Me.Close()
        Catch ex As Exception

        End Try

        Me.Close()
    End Sub
End Class