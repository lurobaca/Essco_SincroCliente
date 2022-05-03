Imports System.Data.SqlClient

Public Class Rutas_RepCarga
    Dim SQL_Comman As New SqlCommand
    Dim Obj_SQL_CONEXION_CONEXION As New CONEXION_TO_SQLSERVER

    Private Sub Rutas_RepCarga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtp_FechaReporte.Format = DateTimePickerFormat.Custom
            dtp_FechaReporte.CustomFormat = "dd/MM/yyyy"


            ' SQL_Comman.Connection = Obj_SQL_CONEXION_CONEXION.Conectar("Sic_Local_Web")
            Dim tabla As New DataTable
            Dim total As Double
            Dim CUENTA As Integer
            If Cbx_Subido.Text = "NO" Then
                Class_VariablesGlobales.Tbl_RepCarga = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRUTAS(Class_VariablesGlobales.SQL_Comman2, "", dtp_FechaReporte.Value.Date, "0")
            Else
                Class_VariablesGlobales.Tbl_RepCarga = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRUTAS(Class_VariablesGlobales.SQL_Comman2, "", dtp_FechaReporte.Value.Date, "1")
            End If


            DTG_RUTAS.DataSource = Class_VariablesGlobales.Tbl_RepCarga


            DTG_RUTAS.Columns(2).Width = 350

        Catch ex As Exception

        End Try

    End Sub





    Private Sub DTG_RUTAS_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DTG_RUTAS.CellClick
        Class_VariablesGlobales.Conse_Repcarga = DTG_RUTAS.Item(0, DTG_RUTAS.CurrentRow.Index).Value.ToString()
        Class_VariablesGlobales.Obj_RepDCar.CargaDetRepCarga(Class_VariablesGlobales.SQL_Comman2, Class_VariablesGlobales.Conse_Repcarga, "")
        Me.Close()
    End Sub


    Private Sub BTN_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_buscar.Click
        Me.Busca()
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbx_Subido.SelectedIndexChanged
        Me.Busca()
    End Sub


    Private Sub dtp_FechaReporte_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_FechaReporte.ValueChanged
        Me.Busca()
    End Sub

    Public Function Busca()
        If Cbx_Subido.Text = "Cerrado" Then
            Class_VariablesGlobales.Tbl_RepCarga = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRUTAS(Class_VariablesGlobales.SQL_Comman2, "", dtp_FechaReporte.Value.Date, "Cerrado")
        ElseIf Cbx_Subido.Text = "Activos" Then
            Class_VariablesGlobales.Tbl_RepCarga = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRUTAS(Class_VariablesGlobales.SQL_Comman2, "", dtp_FechaReporte.Value.Date, "Activos")

        ElseIf Cbx_Subido.Text = "Anulado" Then
            Class_VariablesGlobales.Tbl_RepCarga = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRUTAS(Class_VariablesGlobales.SQL_Comman2, "", dtp_FechaReporte.Value.Date, "Anulado")
        Else
            Class_VariablesGlobales.Tbl_RepCarga = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaRUTAS(Class_VariablesGlobales.SQL_Comman2, "", dtp_FechaReporte.Value.Date, "Todos")
        End If

        DTG_RUTAS.DataSource = Class_VariablesGlobales.Tbl_RepCarga
    End Function

 
  
 
   
  
End Class