Imports System.Data.SqlClient

Public Class List_RepFacturas
    Dim Seleciono As Boolean = False
    Private Sub List_RepFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Class_VariablesGlobales.Obj_Reporte_Facturas.btn_GenerarEnviar.Enabled = False
            Class_VariablesGlobales.Obj_Reporte_Facturas.btn_Limpiar.Enabled = True


            If Class_VariablesGlobales.Fac_Llamadas_Desde = "LIQ_CHOFERES" Then
                ComboBox1.Text = "Activos"
                DGV_RepFacturas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepFacturas(Class_VariablesGlobales.SQL_Comman2, "", dtp_FechaReporte.Value.Date, "0", Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text, "")
            Else

                ComboBox1.Text = "Todos"
                DGV_RepFacturas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepFacturas(Class_VariablesGlobales.SQL_Comman2, "", dtp_FechaReporte.Value.Date, "0", "", "")
            End If

            DGV_RepFacturas.Columns(0).Width = 50
            DGV_RepFacturas.Columns(1).Width = 100
            DGV_RepFacturas.Columns(2).Width = 150
            DGV_RepFacturas.Columns(3).Width = 150





            DGV_RepFacturas.Columns(0).Width = 50
            DGV_RepFacturas.Columns(1).Width = 100
            DGV_RepFacturas.Columns(2).Width = 150
            DGV_RepFacturas.Columns(3).Width = 150
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DGV_RepFacturas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_RepFacturas.CellContentClick
        DGV_RepFacturas.Rows(DGV_RepFacturas.CurrentRow.Index).Selected = True
        'aqui deberiamos ponerle el mismo numero de liquidacion a los reportes que se seleccionen con el fin de que puedan ser jalados todos al mismo tiempo
        If Class_VariablesGlobales.Fac_Llamadas_Desde = "LIQ_CHOFERES" Then
            'Class_VariablesGlobales.frmLiqChof.Txtb_RepFactura.Text = DGV_RepFacturas.Item(0, DGV_RepFacturas.CurrentRow.Index).Value.ToString()
            'Class_VariablesGlobales.frmLiqChof.dtp_FechaIni_Recibos.Focus()
            'Me.Close()
        Else
            Class_VariablesGlobales.Conse_Repcarga = DGV_RepFacturas.Item(0, DGV_RepFacturas.CurrentRow.Index).Value.ToString()

            Class_VariablesGlobales.Obj_Reporte_Facturas.CargaDetRepFacturas(Class_VariablesGlobales.SQL_Comman2, Class_VariablesGlobales.Conse_Repcarga)
            Seleciono = True
            Me.Close()
        End If
        Class_VariablesGlobales.Obj_Reporte_Facturas.btn_Limpiar.Enabled = True

        Class_VariablesGlobales.Obj_Reporte_Facturas.btn_GenerarEnviar.Enabled = False
        Seleciono = True
        Me.Close()


    End Sub






    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Buscar()


    End Sub

    Private Sub DGV_RepFacturas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGV_RepFacturas.KeyPress

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim NumReportes As String


        Dim NumReps As String
        Dim Contador As Integer
        Dim cont As Integer = 0

        For x = 0 To Class_VariablesGlobales.frmLiqChof.ListView_Agentes.Items.Count
            Class_VariablesGlobales.frmLiqChof.ListV_Reportes.Items.RemoveByKey(x)
        Next

        For Contador = 0 To DGV_RepFacturas.SelectedRows.Count - 1

            'If DGV_RepFacturas.Rows(Contador).Selected Then
            If NumReps = "" Then
                NumReps = DGV_RepFacturas(0, Contador).Value
                NumReportes = DGV_RepFacturas(0, Contador).Value

            Else

                NumReps = NumReps & " , " & DGV_RepFacturas(0, Contador).Value
                NumReportes = DGV_RepFacturas(0, Contador).Value
            End If


            Class_VariablesGlobales.frmLiqChof.ListV_Reportes.Items.Add(DGV_RepFacturas(0, Contador).Value)


            Class_VariablesGlobales.Obj_Funciones_SQL.UnificaRepFacturas("", NumReportes, Class_VariablesGlobales.frmLiqChof.txtb_Consecutivo.Text, Class_VariablesGlobales.SQL_Comman1)

            cont += 1
            'End If
        Next Contador
        If cont > 1 Then
            Class_VariablesGlobales.RepFActurasUnidicado = True
        Else
            Class_VariablesGlobales.RepFActurasUnidicado = False

        End If

        'lo que se hara es generar una consulta con un union si hay mas de 2 reportes seleccionados



        If Class_VariablesGlobales.Fac_Llamadas_Desde = "LIQ_CHOFERES" Then
            'Class_VariablesGlobales.frmLiqChof.Txtb_RepFactura.Text = NumReps
            'Class_VariablesGlobales.frmLiqChof.dtp_FechaIni_Recibos.Focus()
            'Me.Close()
        Else
            Class_VariablesGlobales.Conse_Repcarga = DGV_RepFacturas.Item(0, DGV_RepFacturas.CurrentRow.Index).Value.ToString()

            Class_VariablesGlobales.Obj_Reporte_Facturas.CargaDetRepFacturas(Class_VariablesGlobales.SQL_Comman2, Class_VariablesGlobales.Conse_Repcarga)

            Me.Close()

        End If


    End Sub



    Private Sub List_RepFacturas_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If Seleciono = False Then
            Class_VariablesGlobales.Obj_Reporte_Facturas.Nuevo()
        End If


    End Sub

    Private Sub dtp_FechaReporte_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_FechaReporte.ValueChanged
        Buscar()
    End Sub

    Public Function Buscar()
        Try
            Dim Anu As String = "0"
            If ComboBox1.Text = "Todos" Then
                Anu = ""
            End If
            If ComboBox1.Text = "Activos" Then
                Anu = "0"
            End If
            If ComboBox1.Text = "Inactivos" Then
                Anu = "1"
            End If
            If ComboBox1.Text = "Sin Liquidar" Then
                Anu = "2"
            End If

            If Class_VariablesGlobales.Fac_Llamadas_Desde = "LIQ_CHOFERES" Then
                DGV_RepFacturas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepFacturas(Class_VariablesGlobales.SQL_Comman2, "", dtp_FechaReporte.Value.Date, "0", Class_VariablesGlobales.frmLiqChof.txt_CodChofer.Text, Anu)
            Else
                DGV_RepFacturas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRepFacturas(Class_VariablesGlobales.SQL_Comman2, "", dtp_FechaReporte.Value.Date, "0", "", Anu)
            End If

            DGV_RepFacturas.Columns(0).Width = 50
            DGV_RepFacturas.Columns(1).Width = 100
            DGV_RepFacturas.Columns(2).Width = 150
            DGV_RepFacturas.Columns(3).Width = 150
        Catch ex As Exception

        End Try
    End Function

End Class