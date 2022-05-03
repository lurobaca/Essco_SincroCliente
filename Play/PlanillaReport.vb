Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.OleDb
Imports System.Threading
Imports System.Drawing.Printing

Public Class PlanillaReport

    Private tr_Print As Thread
    Private tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
    Private tliCurrent As CrystalDecisions.Shared.TableLogOnInfo

    Private Sub PlanillaReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        tr_Print = Nothing

        tr_Print = New Thread(AddressOf Imprimir)


        tr_Print.IsBackground = Enabled
        tr_Print.Priority = ThreadPriority.AboveNormal
        tr_Print.Start()
        Me.Close()
        CheckForIllegalCrossThreadCalls = False
    End Sub


    Public Function Imprimir()
        Try
            CheckForIllegalCrossThreadCalls = False
            Dim cryRpt As ConstanciaSalarial2

            cryRpt = New ConstanciaSalarial2

            cryRpt.SetDatabaseLogon(Class_VariablesGlobales.XMLParamSQL_user, Class_VariablesGlobales.XMLParamSQL_clave, Class_VariablesGlobales.XMLParamSQL_server, Class_VariablesGlobales.XMLParamSAP_CompanyDB, False)

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
            Dim parametros As Integer = 0


            '----- PARAMETROS REPORTE PADRE  --------------
            '0:          Consecutivo()

            Dim path As String = "C:\Program Files (x86)\ESSCO\SINCRO\Planilla_Imagenes\206470957.jpg"
            'cryRpt.SetParameterValue("picturePath", path)
            cryRpt.SetParameterValue(0, Class_VariablesGlobales.frmPlanilla.Txb_id_Planilla.Text)
            cryRpt.SetParameterValue("picturePath", path)
            cryRpt.SetParameterValue(1, path)
            parametros += 1
          


            Dim pd As New PrintDocument
            'Se define el print Document.
            Dim impresora_predeterminada As String = pd.PrinterSettings.PrinterName
            CrystalReportViewer1.Refresh()
            CrystalReportViewer1.ReportSource = cryRpt
            CrystalReportViewer1.Refresh()
            cryRpt.PrintOptions.PrinterName = impresora_predeterminada
            cryRpt.PrintToPrinter(1, False, 0, 0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            tr_Print.Abort()
        End Try
    End Function
End Class