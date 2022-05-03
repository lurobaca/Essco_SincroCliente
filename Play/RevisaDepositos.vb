Public Class RevisaDepositos
    Dim Thast As New Hashtable
    Public obj_SAP As New SAP_BUSSINES_ONE
    Public oCompany As New SAPbobsCOM.Company
    Public LlamaDepos As Boolean = False
    Public Function CargaDatos()

        Try

            Dim Tabla As DataTable
            'obtiene los depositos que estan en el banco
            If ComboBox1.Text = "SUBIDOS" Then
                Tabla = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date), Trim(txtb_Agent.Text), "", "", "1", "DPCONSECUTIVO", Class_VariablesGlobales.LIQUIDANDO, True, "")
            ElseIf ComboBox1.Text = "NO SUBIDOS" Then
                Tabla = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date), Trim(txtb_Agent.Text), "", "", "0", "DPCONSECUTIVO", Class_VariablesGlobales.LIQUIDANDO, True, "")
            ElseIf ComboBox1.Text = "AMBOS" Then
                Tabla = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDepositos(Class_VariablesGlobales.SQL_Comman1, "VENTANA_DEPOSITO", "", Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date), Trim(txtb_Agent.Text), "", "", "", "DPCONSECUTIVO", Class_VariablesGlobales.LIQUIDANDO, True, "")
            End If

            Dim contardor As Integer = 0

            DataGridView1.ColumnCount = 9
            DataGridView1.Columns(0).Name = "DPCONSECUTIVO"
            DataGridView1.Columns(1).Name = "DPCODIGO"
            DataGridView1.Columns(2).Name = "DPFECHA"
            DataGridView1.Columns(3).Name = "DPBANCO"
            DataGridView1.Columns(4).Name = "Total"
            DataGridView1.Columns(5).Name = "#Liquidacion"
            DataGridView1.Columns(6).Name = "DPFECHA_CONTABLE"
            DataGridView1.Columns(7).Name = "DPAGENTE"
            DataGridView1.Columns(8).Name = "DPOBS"
            Dim chk As New DataGridViewCheckBoxColumn()
            DataGridView1.Columns.Add(chk)
            chk.HeaderText = "ES_DEPOSITO"
            chk.Name = "ES_DEPOSITO"

            While contardor < Tabla.Rows.Count
                'Dim NumLiq As String = Obj_Funciones_SQL.ObtieneLiqSegunDeposito(Class_VariablesGlobales.SQL_Comman1, Tabla.Rows(contardor).Item("DPCONSECUTIVO").ToString())


                Dim row As String() = New String() {Tabla.Rows(contardor).Item("DPCONSECUTIVO").ToString(), _
                                                     Tabla.Rows(contardor).Item("DPCODIGO").ToString(), _
                                                     Tabla.Rows(contardor).Item("DPFECHA").ToString(), _
                                                     Tabla.Rows(contardor).Item("DPBANCO").ToString(), _
                                                     Tabla.Rows(contardor).Item("Total").ToString(), _
                                                     Tabla.Rows(contardor).Item("DPLIQUIDACION").ToString(), _
                                                     Tabla.Rows(contardor).Item("DPFECHA_CONTABLE").ToString(), _
                                                      Tabla.Rows(contardor).Item("DPAGENTE").ToString(), _
                                                      Tabla.Rows(contardor).Item("DPOBS").ToString() _
                                                     }
                DataGridView1.Rows.Add(row)

                'INSICA SI ESTA EN BOLETA O EN EL BANCO
                If Tabla.Rows(contardor).Item("DP_BOLETA").ToString() = "0" Then
                    DataGridView1.Rows(contardor).Cells(9).Value = True
                Else
                    DataGridView1.Rows(contardor).Cells(9).Value = False
                End If

                contardor += 1
            End While

        Catch ex As Exception

        End Try
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        DataGridView1.Rows.Clear()

        CargaDatos()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            Dim Pregunta As Integer

            Pregunta = MsgBox("¿Esta Seguro que desean subir los depositos ?.", vbYesNo + vbExclamation + vbDefaultButton2, "SUBIR DEPOSITOS")

            If Pregunta = vbYes Then
                ' elimino al usuario



                Dim contardor As Integer = 0
                Dim CrearDeposito As Boolean = False

                Dim DPCONSECUTIVO, DPCODIGO, DPFECHA, DPBANCO, Total, NUMLIQ As String
                'Debe obtener los depositos que no se han subido 
                While contardor < DataGridView1.Rows.Count - 1
                    'DPCONSECUTIVO
                    DPCONSECUTIVO = DataGridView1.Rows(contardor).Cells(0).Value.ToString()
                    'DPCODIGO
                    DPCODIGO = DataGridView1.Rows(contardor).Cells(1).Value.ToString()
                    'DPFECHA
                    DPFECHA = DataGridView1.Rows(contardor).Cells(6).Value.ToString()
                    'DPBANCO
                    DPBANCO = DataGridView1.Rows(contardor).Cells(3).Value.ToString()
                    'Total
                    Total = DataGridView1.Rows(contardor).Cells(4).Value.ToString()
                    'Num Liq
                    NUMLIQ = DataGridView1.Rows(contardor).Cells(5).Value.ToString()
                    'DP_BOLETA
                    If DataGridView1.Rows(contardor).Cells(9).Value = True Then
                        'si esta marcado como boleta NO SE CREA EN SAP
                        CrearDeposito = True
                    Else
                        'si no esta maracado como boleta SE CREA EN SAP
                        CrearDeposito = False
                    End If



                    ' solo crea depositos que no sea boletas y que tenga el numero de liquidacion
                    If CrearDeposito = True Then


                        Dim Cuenta_Banco As String
                        'Crea el deposito en SAP
                        'If DPBANCO = "" Then
                        '    Cuenta_Banco = Class_VariablesGlobales.XMLParamCuentas_CashAccount
                        'End If
                        'If DPBANCO = "" Then
                        '    Cuenta_Banco = Class_VariablesGlobales.XMLParamCuentas_TransferAccountt
                        'End If

                        If DPBANCO = "Banco Popular de Costa Rica" Then
                            Cuenta_Banco = Class_VariablesGlobales.XMLParamCuentas_BancoPopular
                        End If
                        If DPBANCO = "Banco Nacional de Costa Rica" Then
                            Cuenta_Banco = Class_VariablesGlobales.XMLParamCuentas_BancoNacional
                        End If
                        If DPBANCO = "Banco de Costa Rica" Then
                            Cuenta_Banco = Class_VariablesGlobales.XMLParamCuentas_BancoCostaRica
                        End If
                        If DPBANCO = "Lafise" Then
                            Cuenta_Banco = Class_VariablesGlobales.XMLParamCuentas_BancoLaFise
                        End If
                        If DPBANCO = "Coocique" Then
                            Cuenta_Banco = Class_VariablesGlobales.XMLParamCuentas_BancoCoocique
                        End If
                        If DPBANCO = "Banco BCT" Then
                            Cuenta_Banco = Class_VariablesGlobales.XMLParamCuentas_BancoBCT
                        End If

                        If obj_SAP.CreaDeposito(DPCODIGO, DPFECHA, DPBANCO, CDbl(Total), Class_VariablesGlobales.SQL_Comman1, Cuenta_Banco, NUMLIQ) = 0 Then
                            Class_VariablesGlobales.Obj_Funciones_SQL.ModificaDeposito(Class_VariablesGlobales.SQL_Comman2, DPCONSECUTIVO, "", "", "", "", "", "", "", "", False, "1", "")
                        End If



                    End If

                    contardor += 1
                End While
                'se deben actualizar el estado del deposito a subido


            Else
                ' NO elimino al usuario
                ' Exit lo que sea
            End If

            MsgBox("Proceso Terminado")
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub RevisaDepositos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'conecta  a SAP
        oCompany = obj_SAP.ConectarSap()




    End Sub

    Private Sub DataGridView1_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.IsCurrentCellDirty Then
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged


        If e.RowIndex >= 0 Then
            'modifia el estado de boleta o deposito al chequear o des chequear el checbox
            'Me.DataGridView1.Rows(e.RowIndex).Cells("DP_BOLETA").Value
            'Me.DataGridView1.Rows(e.RowIndex).Cells("DPCONSECUTIVO").Value
            'Thast.Add(Me.DataGridView1.Rows(e.RowIndex).Cells("DPCONSECUTIVO").Value, Me.DataGridView1.Rows(e.RowIndex).Cells("ES_DEPOSITO").Value)

            'Class_VariablesGlobales.Obj_Funciones_SQL.ModificaDeposito(Class_VariablesGlobales.SQL_Comman2, Me.DataGridView1.Rows(e.RowIndex).Cells("DPCONSECUTIVO").Value, "", "", "", "", "", "", "", "", False, "")
        End If
    End Sub


    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If LlamaDepos = True Then



            Admin_Depositos_Choferes.Show()
            '[DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],[DPMONTO],[DPAGENTE],[DPOBS],[DPLIQUIDACION],[DP_TIPO_LIQ]

            Class_VariablesGlobales.frmDeposAgente.txb_consecutivo.Text = DataGridView1.CurrentRow.Cells.Item(0).Value
            Class_VariablesGlobales.frmDeposAgente.txb_NumDepo.Text = DataGridView1.CurrentRow.Cells.Item(1).Value
            Class_VariablesGlobales.frmDeposAgente.dtp_Fecha.Text = DataGridView1.CurrentRow.Cells.Item(2).Value

            Class_VariablesGlobales.frmDeposAgente.cbbx_Banco.Text = DataGridView1.CurrentRow.Cells.Item(3).Value
            Class_VariablesGlobales.frmDeposAgente.txb_Monto.Text = DataGridView1.CurrentRow.Cells.Item(4).Value
            Class_VariablesGlobales.frmDeposAgente.txb_CodAgente.Text = DataGridView1.CurrentRow.Cells.Item(7).Value
            Class_VariablesGlobales.frmDeposAgente.txb_NomAgente.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneNameAgente(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.frmDeposAgente.txb_CodAgente.Text)
            Class_VariablesGlobales.frmDeposAgente.txb_Comentario.Text = DataGridView1.CurrentRow.Cells.Item(8).Value
            Class_VariablesGlobales.frmDeposAgente.dtp_FechaContable.Text = DataGridView1.CurrentRow.Cells.Item(6).Value
            Class_VariablesGlobales.frmDeposAgente.txb_Liquidacion.Text = DataGridView1.CurrentRow.Cells.Item(5).Value
            If DataGridView1.CurrentRow.Cells.Item(9).Value = "1" Then
                Class_VariablesGlobales.frmDeposAgente.cbbx_Subido.Text = "SI"
            Else
                Class_VariablesGlobales.frmDeposAgente.cbbx_Subido.Text = "NO"
            End If


            Class_VariablesGlobales.frmDeposAgente.btn_AgGuardar.Enabled = False
            Class_VariablesGlobales.frmDeposAgente.btn_AgModif.Enabled = True
            Class_VariablesGlobales.frmDeposAgente.btn_AgElimina.Enabled = True
            Class_VariablesGlobales.frmDeposAgente.btn_GoToLiq.Enabled = True
        End If
    End Sub

 



    Private Sub selectedCellsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Click

        Dim selectedCellCount As Integer = DataGridView1.GetCellCount(DataGridViewElementStates.Selected)
        If selectedCellCount > 0 Then
            If DataGridView1.AreAllCellsSelected(True) Then
                MessageBox.Show("All cells are selected", "Selected Cells")
            Else
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedCellCount - 1
                    sb.Append(DataGridView1.SelectedCells(i).ColumnIndex.ToString())
                Next i

                If CInt(Trim(sb.ToString())) = 9 Then
                    LlamaDepos = False
                Else
                    LlamaDepos = True

                End If


            End If

        End If

    End Sub
End Class