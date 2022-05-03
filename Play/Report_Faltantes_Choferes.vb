Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Report_Faltantes_Choferes

    Public ag As Integer = 0
    Private Sub Report_Faltantes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub





    Private Sub btn_BuscaAgente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaAgente.Click
        Class_VariablesGlobales.Lista_llamadaDesde = "REPORTE"
        ListaChoferes.Show()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Generar.Click

        Imprimir()
    End Sub



    Public Function Imprimir()

        Try
            Dim cryRpt As ReportDocument
            cryRpt = New Reporte_ResumenLiqChoferes2

            cryRpt.SetDatabaseLogon(Class_VariablesGlobales.XMLParamSQL_user, Class_VariablesGlobales.XMLParamSQL_clave, Class_VariablesGlobales.XMLParamSQL_server, Class_VariablesGlobales.XMLParamSAP_CompanyDB)
            Dim MiConexion As New ConnectionInfo
            Dim myTables As Tables = cryRpt.Database.Tables
            MiConexion.ServerName = Class_VariablesGlobales.XMLParamSQL_server
            MiConexion.DatabaseName = Class_VariablesGlobales.XMLParamSAP_CompanyDB
            MiConexion.UserID = Class_VariablesGlobales.XMLParamSQL_user
            MiConexion.Password = Class_VariablesGlobales.XMLParamSQL_clave

            For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
                Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
                myTableLogonInfo.ConnectionInfo = MiConexion
                myTable.ApplyLogOnInfo(myTableLogonInfo)
            Next
            '----- PARAMETROS REPORTE PADRE  --------------
            cryRpt.SetParameterValue(0, txtb_CodAgente.Text)
            cryRpt.SetParameterValue(1, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date))
            cryRpt.SetParameterValue(2, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date))
            cryRpt.SetParameterValue(3, txtb_CodAgente.Text)
            cryRpt.SetParameterValue(4, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaFin.Value.Date))
            cryRpt.SetParameterValue(5, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(dtp_FechaIni.Value.Date))

            CrystalReportViewer1.ReportSource = cryRpt
            CrystalReportViewer1.Refresh()
            'cryRpt.PrintToPrinter(1, False, 0, 0)
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Function

    Private Sub txtb_CodAgente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtb_CodAgente.TextChanged
        btn_Generar.Enabled = True
    End Sub

    Private Sub Btn_Atras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Atras.Click

        If ag <= 0 Then
            ag = 1
        Else
            ag -= 1
        
        End If

        txtb_CodAgente.Text = ag
        Imprimir()
       
    End Sub

    Private Sub Btn_Adelante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Adelante.Click
     
        ag += 1



        txtb_CodAgente.Text = ag
        Imprimir()
    End Sub
End Class