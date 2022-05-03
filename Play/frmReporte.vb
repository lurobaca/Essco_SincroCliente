Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.OleDb
Imports System.Threading
Imports System.Drawing.Printing
Imports CrystalReportsDataDefModelLib

Public Class frmReporte

    Private tr_Print As Thread
    Private tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
    Private tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
    'Private rptDoc As New ReportDocument

    Private Sub frmReporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            CheckForIllegalCrossThreadCalls = False
            tr_Print = Nothing


            If Class_VariablesGlobales.IMPRIMIENDO = "RepFacturas" Then
                tr_Print = New Thread(AddressOf ImprimirRepFacturas)
            ElseIf Class_VariablesGlobales.IMPRIMIENDO = "DEVOLUCION" Then
                tr_Print = New Thread(AddressOf ImprimeNotaCreditoPContinuo)

            ElseIf Class_VariablesGlobales.IMPRIMIENDO = "RepCarga" Then

                tr_Print = New Thread(AddressOf ImprimirRepCargaSect)

            ElseIf Class_VariablesGlobales.IMPRIMIENDO = "RepFaltante" Then

                tr_Print = New Thread(AddressOf ImprimirRepFaltante)
            ElseIf Class_VariablesGlobales.IMPRIMIENDO = "Ubicaciones" Then

                tr_Print = New Thread(AddressOf ImprimirUbicaciones)


            Else
                If Class_VariablesGlobales.LIQUIDANDO = "CHOFERES" Then
                    tr_Print = New Thread(AddressOf ImprimirLqChoferes)
                Else
                    tr_Print = New Thread(AddressOf Imprimir)
                End If

            End If

            tr_Print.IsBackground = Enabled
            tr_Print.Priority = ThreadPriority.AboveNormal
            tr_Print.Start()
            Me.Close()
            CheckForIllegalCrossThreadCalls = False
        Catch ex As Exception
            MsgBox("ERROR en load frmReporte [ " & ex.Message & " ]")

        End Try
    End Sub

    Public Function ImprimeNotaCreditoPContinuo()
        Try
            CheckForIllegalCrossThreadCalls = False
            Dim cryRpt As NotasCredito_PContinuo
            cryRpt = New NotasCredito_PContinuo

            Dim MiConexion As New CrystalDecisions.Shared.ConnectionInfo
            Dim myTables As CrystalDecisions.CrystalReports.Engine.Tables = cryRpt.Database.Tables
            Dim parametros As Integer = 0



            cryRpt.SetDatabaseLogon(Class_VariablesGlobales.XMLParamSQL_user, Class_VariablesGlobales.XMLParamSQL_clave, Class_VariablesGlobales.XMLParamSQL_server, Class_VariablesGlobales.XMLParamSAP_CompanyDB, False)
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
            '0:          Factura FIN
            cryRpt.SetParameterValue(0, Class_VariablesGlobales.Devolucion_DocNum)
            parametros += 1


            Dim pd As New PrintDocument
            'Se define el print Document.
            Dim impresora_predeterminada As String = pd.PrinterSettings.PrinterName
            'CrystalReportViewer1.Refresh()
            'CrystalReportViewer1.ReportSource = cryRpt
            'CrystalReportViewer1.Refresh()

            cryRpt.PrintOptions.PrinterName = impresora_predeterminada
            cryRpt.PrintToPrinter(Class_VariablesGlobales.Copias, False, 0, 0)
            Class_VariablesGlobales.Obj_Reporte_Facturas.btn_Imprimir.Enabled = True
            cryRpt = Nothing
            MiConexion = Nothing
            myTables = Nothing
            parametros = Nothing
            pd = Nothing
            impresora_predeterminada = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            tr_Print.Abort()
        End Try
    End Function
    Public Function Imprimir()
        Try
            CheckForIllegalCrossThreadCalls = False
            Dim cryRpt As LiquidacionAgentes

            cryRpt = New LiquidacionAgentes



            cryRpt.SetDatabaseLogon(Class_VariablesGlobales.XMLParamSQL_user, Class_VariablesGlobales.XMLParamSQL_clave, Class_VariablesGlobales.XMLParamSQL_server, Class_VariablesGlobales.XMLParamSAP_CompanyDB, False)

            Dim MiConexion As New CrystalDecisions.Shared.ConnectionInfo
            Dim myTables As CrystalDecisions.CrystalReports.Engine.Tables = cryRpt.Database.Tables
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
            cryRpt.SetParameterValue(0, Class_VariablesGlobales.LiquiAgente_ConseLiq)
            parametros += 1


            '1:          Agente()
            cryRpt.SetParameterValue(1, Class_VariablesGlobales.LiquiAgente_FechaFin)
            parametros += 1
            '2 "FechaINI"
            cryRpt.SetParameterValue(2, Class_VariablesGlobales.LiquiAgente_FechaIni)
            parametros += 1
            '3 "FechaFIN"
            cryRpt.SetParameterValue(3, Class_VariablesGlobales.LiquiAgente_CodAgente)
            parametros += 1



            ' '' ''----- PARAMETROS REPORTE GASTOS  --------------
            '7 "Agente"
            cryRpt.SetParameterValue(4, Class_VariablesGlobales.LiquiAgente_CodAgente)
            parametros += 1
            '8 "FechaINI"
            cryRpt.SetParameterValue(5, Class_VariablesGlobales.LiquiAgente_FechaFin)
            parametros += 1
            '10 "FechaFIN "
            cryRpt.SetParameterValue(6, Class_VariablesGlobales.LiquiAgente_FechaIni)
            parametros += 1



            '----- PARAMETROS REPORTE DEPOSITOS  --------------
            '11 "Agente"
            cryRpt.SetParameterValue(7, Class_VariablesGlobales.LiquiAgente_CodAgente)
            parametros += 1
            '12 "FechaFIN"
            cryRpt.SetParameterValue(8, Class_VariablesGlobales.LiquiAgente_FechaFin)
            parametros += 1
            '13 "FechaINI"
            cryRpt.SetParameterValue(9, Class_VariablesGlobales.LiquiAgente_FechaIni)
            parametros += 1



            ''----- PARAMETROS REPORTE RECIBOS  --------------
            ''3 "CodAgente"
            cryRpt.SetParameterValue(10, Class_VariablesGlobales.LiquiAgente_CodAgente)
            parametros += 1
            ' ''3 "CodAgente"
            cryRpt.SetParameterValue(11, Class_VariablesGlobales.LiquiAgente_FechaFin)
            parametros += 1
            ''3 "CodAgente"
            cryRpt.SetParameterValue(12, Class_VariablesGlobales.LiquiAgente_FechaIni)
            parametros += 1





            Dim pd As New PrintDocument
            'Se define el print Document.
            Dim impresora_predeterminada As String = pd.PrinterSettings.PrinterName
            'CrystalReportViewer1.Refresh()
            'CrystalReportViewer1.ReportSource = cryRpt
            'CrystalReportViewer1.Refresh()

            cryRpt.PrintOptions.PrinterName = impresora_predeterminada
            cryRpt.PrintToPrinter(1, False, 0, 0)



        Catch ex As Exception
            MessageBox.Show(ex.Message)
            tr_Print.Abort()
        End Try
    End Function

    Public Function ImprimirLqChoferes()
        Try

            Dim parametros As Integer = 0
            Dim cryRpt As LiquidacionChoferes02
            Dim MiConexion As New CrystalDecisions.Shared.ConnectionInfo


            cryRpt = New LiquidacionChoferes02
            Dim myTables As CrystalDecisions.CrystalReports.Engine.Tables = cryRpt.Database.Tables

            cryRpt.SetDatabaseLogon(Class_VariablesGlobales.XMLParamSQL_user, Class_VariablesGlobales.XMLParamSQL_clave, Class_VariablesGlobales.XMLParamSQL_server, Class_VariablesGlobales.XMLParamSAP_CompanyDB, False)


            MiConexion.ServerName = Class_VariablesGlobales.XMLParamSQL_server
            MiConexion.DatabaseName = Class_VariablesGlobales.XMLParamSAP_CompanyDB
            'MiConexion.DatabaseName = "DB_BOURNE_PRUEBAS"
            MiConexion.UserID = Class_VariablesGlobales.XMLParamSQL_user
            MiConexion.Password = Class_VariablesGlobales.XMLParamSQL_clave

            For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
                Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
                myTableLogonInfo.ConnectionInfo = MiConexion
                myTable.ApplyLogOnInfo(myTableLogonInfo)
            Next




            '----- PARAMETROS REPORTE PADRE  --------------
            '0:          Consecutivo()





            cryRpt.SetParameterValue(0, Class_VariablesGlobales.LiquiChoferes_ConseLiq)
            parametros += 1
            cryRpt.SetParameterValue(1, Class_VariablesGlobales.LiquiChoferes_CodAgente)
            parametros += 1
            '1:Agente()

            '2:FechaINI"
            cryRpt.SetParameterValue(2, Class_VariablesGlobales.LiquiChoferes_FechaIni_Recibos)
            parametros += 1
            '3:FechaFIN"
            cryRpt.SetParameterValue(3, Class_VariablesGlobales.LiquiChoferes_FechaFin_Recibos)
            parametros += 1


            ' ''----- PARAMETROS REPORTE GASTOS  --------------.
            cryRpt.SetParameterValue(4, Class_VariablesGlobales.LiquiChoferes_FechaIni_Recibos)
            parametros += 1
            '8 "FechaINI"
            cryRpt.SetParameterValue(5, Class_VariablesGlobales.LiquiChoferes_FechaFin_Recibos)
            parametros += 1
            '10 "FechaFIN "
            cryRpt.SetParameterValue(6, Class_VariablesGlobales.LiquiChoferes_CodAgente)
            parametros += 1

            '7 "Agente"


            '----- PARAMETROS REPORTE DEPOSITOS  --------------
            '11 "Agente"
            cryRpt.SetParameterValue(7, Class_VariablesGlobales.LiquiChoferes_FechaFin_Recibos)
            parametros += 1
            cryRpt.SetParameterValue(8, Class_VariablesGlobales.LiquiChoferes_FechaIni_Recibos)
            parametros += 1
            '12 "FechaFIN"
            cryRpt.SetParameterValue(9, Class_VariablesGlobales.LiquiChoferes_ConseLiq)
            parametros += 1
            cryRpt.SetParameterValue(10, Class_VariablesGlobales.LiquiChoferes_CodAgente)
            parametros += 1
            '13 "FechaINI"


            ''----- PARAMETROS REPORTE RECIBOS  --------------
            '3 "CodAgente"
            cryRpt.SetParameterValue(11, Class_VariablesGlobales.LiquiChoferes_ConseLiq)
            parametros += 1
            cryRpt.SetParameterValue(12, Class_VariablesGlobales.LiquiChoferes_FechaFin_Recibos)
            parametros += 1
            cryRpt.SetParameterValue(13, Class_VariablesGlobales.LiquiChoferes_FechaIni_Recibos)
            parametros += 1
            cryRpt.SetParameterValue(14, Class_VariablesGlobales.LiquiChoferes_CodAgente)
            parametros += 1

            ''3 "CodAgente"

            ''3 "CodAgente"
            'cryRpt.SetParameterValue(13, Class_VariablesGlobales.LiquiChoferes_FechaFin_Recibos)
            'parametros += 1

            ' ''----- PARAMETROS REPORTE FACTURAS  --------------
            ' ''3 "CodAgente"
            'cryRpt.SetParameterValue(14, Class_VariablesGlobales.LiquiChoferes_FechaIni_Recibos)
            'parametros += 1
            '' ''3 "CodAgente"

            cryRpt.SetParameterValue(15, Class_VariablesGlobales.LiquiChoferes_ConseLiq)
            parametros += 1



            '3 "CodAgente"
            cryRpt.SetParameterValue(16, Class_VariablesGlobales.LiquiChoferes_FechaFin_Recibos)
            parametros += 1

            ''----- PARAMETROS REPORTE FACTURAS  --------------
            ''3 "CodAgente"
            'cryRpt.SetParameterValue(17, Class_VariablesGlobales.LiquiChoferes_ConseRepFacturas)
            'parametros += 1
            ' ''3 "CodAgente"

            cryRpt.SetParameterValue(17, Class_VariablesGlobales.LiquiChoferes_FechaIni_Recibos)
            parametros += 1

            ''3 "CodAgente"
            cryRpt.SetParameterValue(18, Class_VariablesGlobales.LiquiChoferes_CodAgente)
            parametros += 1


            cryRpt.SetParameterValue(19, Class_VariablesGlobales.LiquiChoferes_ConseLiq)
            parametros += 1

            Dim pd As New PrintDocument
            'Se define el print Document.
            Dim impresora_predeterminada As String = pd.PrinterSettings.PrinterName
            'CrystalReportViewer1.Refresh()
            'CrystalReportViewer1.ReportSource = cryRpt
            'CrystalReportViewer1.Refresh()

            cryRpt.PrintOptions.PrinterName = impresora_predeterminada
            cryRpt.PrintToPrinter(1, False, 0, 0)



            parametros = Nothing
            cryRpt = Nothing
            MiConexion = Nothing
            myTables = Nothing
            ' myTableLogonInfo = Nothing
            pd = Nothing
            impresora_predeterminada = Nothing


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            tr_Print.Abort()
        End Try
    End Function

    Public Function ImprimirRepCargaSect(ByVal Consecutivo As String)

        Dim cryRpte As Reporte_Carga_XSector

        Dim MiConexion As New CrystalDecisions.Shared.ConnectionInfo
        Dim myTables As CrystalDecisions.CrystalReports.Engine.Tables
        Dim impresora_predeterminada As String
        Dim pd As New PrintDocument
        Try
            CheckForIllegalCrossThreadCalls = False
            cryRpte = New Reporte_Carga_XSector
            myTables = cryRpte.Database.Tables

            cryRpte.SetDatabaseLogon(Class_VariablesGlobales.XMLParamSQL_user, Class_VariablesGlobales.XMLParamSQL_clave, Class_VariablesGlobales.XMLParamSQL_server, Class_VariablesGlobales.XMLParamSAP_CompanyDB, False)

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
            '0:          Consecutivo()
            cryRpte.SetParameterValue(0, Trim(Class_VariablesGlobales.ReporteCarga_Consecutivo))

            'Se define el print Document.
            'impresora_predeterminada = pd.PrinterSettings.PrinterName
            'CrystalReportViewer1.Refresh()
            'CrystalReportViewer1.ReportSource = cryRpte
            'CrystalReportViewer1.Refresh()

            cryRpte.PrintOptions.PrinterName = impresora_predeterminada
            cryRpte.PrintToPrinter(1, False, 0, 0)

            cryRpte = Nothing
            MiConexion = Nothing
            myTables = Nothing
            pd = Nothing


            impresora_predeterminada = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)


            cryRpte = Nothing
            MiConexion = Nothing
            myTables = Nothing
            pd = Nothing

            impresora_predeterminada = Nothing
            tr_Print.Abort()
            Me.Close()

        End Try
    End Function
    Public Function ImprimirUbicaciones()

        Dim cryRpte As EtiquetasUbicacionesVertica

        Dim MiConexion As New CrystalDecisions.Shared.ConnectionInfo
        Dim myTables As CrystalDecisions.CrystalReports.Engine.Tables
        Dim impresora_predeterminada As String
        Dim pd As New PrintDocument
        Try
            CheckForIllegalCrossThreadCalls = False
            cryRpte = New EtiquetasUbicacionesVertica
            myTables = cryRpte.Database.Tables

            cryRpte.SetDatabaseLogon(Class_VariablesGlobales.XMLParamSQL_user, Class_VariablesGlobales.XMLParamSQL_clave, Class_VariablesGlobales.XMLParamSQL_server, Class_VariablesGlobales.XMLParamSAP_CompanyDB, False)

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
            '0:          Consecutivo()
            cryRpte.SetParameterValue(0, Trim(Class_VariablesGlobales.ReporteCarga_Consecutivo))

            'Se define el print Document.
            impresora_predeterminada = "SATO CG408"
            'CrystalReportViewer1.Refresh()
            'CrystalReportViewer1.ReportSource = cryRpte
            'CrystalReportViewer1.Refresh()

            'Class_VariablesGlobales.WMS_AdminUbicaciones_Codigo

            cryRpte.PrintOptions.PrinterName = impresora_predeterminada
            cryRpte.PrintToPrinter(1, False, 0, 0)

            cryRpte = Nothing
            MiConexion = Nothing
            myTables = Nothing
            pd = Nothing


            impresora_predeterminada = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)


            cryRpte = Nothing
            MiConexion = Nothing
            myTables = Nothing
            pd = Nothing

            impresora_predeterminada = Nothing
            tr_Print.Abort()
            Me.Close()

        End Try
    End Function
    Public Function ImprimirRepFaltante(ByVal Consecutivo As String)
        Try
            CheckForIllegalCrossThreadCalls = False
            Dim cryRpt As Reporte_de_Carga_Faltantes


            cryRpt = New Reporte_de_Carga_Faltantes



            cryRpt.SetDatabaseLogon(Class_VariablesGlobales.XMLParamSQL_user, Class_VariablesGlobales.XMLParamSQL_clave, Class_VariablesGlobales.XMLParamSQL_server, Class_VariablesGlobales.XMLParamSAP_CompanyDB, False)

            Dim MiConexion As New CrystalDecisions.Shared.ConnectionInfo
            Dim myTables As CrystalDecisions.CrystalReports.Engine.Tables = cryRpt.Database.Tables
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
            cryRpt.SetParameterValue(0, Class_VariablesGlobales.ReporteCarga_Consecutivo)


            Dim pd As New PrintDocument
            'Se define el print Document.
            Dim impresora_predeterminada As String = pd.PrinterSettings.PrinterName
            'CrystalReportViewer1.Refresh()
            'CrystalReportViewer1.ReportSource = cryRpt
            'CrystalReportViewer1.Refresh()

            cryRpt.PrintOptions.PrinterName = impresora_predeterminada
            cryRpt.PrintToPrinter(1, False, 0, 0)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            tr_Print.Abort()
        End Try
    End Function

    Public Function ImprimirRepFacturas(ByVal Consecutivo As String)
        Try
            VariablesGlobales.Obj_Log.Log("ImprimirRepFacturas Copias [" & Class_VariablesGlobales.Copias & "] [ " & Class_VariablesGlobales.Obj_Reporte_Facturas.txb_Numero.Text & " ]", "Otros")
            CheckForIllegalCrossThreadCalls = False
            Dim cryRpt As Facturas_sin_bodega_1v2
            cryRpt = New Facturas_sin_bodega_1v2


            Dim MiConexion As New CrystalDecisions.Shared.ConnectionInfo
            Dim myTables As CrystalDecisions.CrystalReports.Engine.Tables = cryRpt.Database.Tables
            Dim parametros As Integer = 0

            cryRpt.SetDatabaseLogon(Class_VariablesGlobales.XMLParamSQL_user, Class_VariablesGlobales.XMLParamSQL_clave, Class_VariablesGlobales.XMLParamSQL_server, Class_VariablesGlobales.XMLParamSAP_CompanyDB, False)

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
            '0:          Factura FIN
            cryRpt.SetParameterValue(2, Class_VariablesGlobales.ReporteFacturas_Consecutivo)
            parametros += 1
            ''0:          Factura INI
            'cryRpt.SetParameterValue(1, Class_VariablesGlobales.ReporteFacturas_FacFIN)
            'parametros += 1
            'cryRpt.SetParameterValue(2, Class_VariablesGlobales.ReporteFacturas_FacFIN)
            'parametros += 1
            'cryRpt.SetParameterValue(3, Class_VariablesGlobales.ReporteFacturas_FacINI)
            'parametros += 1

            Dim pd As New PrintDocument
            'Se define el print Document.
            Dim impresora_predeterminada As String = pd.PrinterSettings.PrinterName
            'CrystalReportViewer1.Refresh()
            'CrystalReportViewer1.ReportSource = cryRpt
            'CrystalReportViewer1.Refresh()

            cryRpt.PrintOptions.PrinterName = impresora_predeterminada
            cryRpt.PrintToPrinter(Class_VariablesGlobales.Copias, False, 0, 0)



            Class_VariablesGlobales.Obj_Reporte_Facturas.btn_Imprimir.Enabled = True


            cryRpt = Nothing
            MiConexion = Nothing
            'myTables = Nothing
            parametros = Nothing
            pd = Nothing
            impresora_predeterminada = Nothing

        Catch ex As Exception
            VariablesGlobales.Obj_Log.Log("ERROR EN frmReporte ImprimirRepFacturas [" & Class_VariablesGlobales.Obj_Reporte_Facturas.txb_Numero.Text & " ] [" & ex.Message & " ]", "Otros")
            MessageBox.Show("ERROR EN frmReporte ImprimirRepFacturas [" & ex.Message & " ]")
            tr_Print.Abort()
        End Try
    End Function

    'OPCION  1
    'Mostrar una vista previa con un control CrystalReportViewer
    Public Sub Accion_Imprimir()
        CrystalReportViewer1.Visible = True
        'Dim miInforme As New Facturas_sin_bodega_1

        'miInforme.SetDataSource(ConjuntoDeDatos)
        'CrystalReportViewer1.ReportSource = miInforme

        ' Creas un parametro en el reporte y despues lo pasas desde el form, asi:

        Dim MyReport As New Facturas_sin_bodega_1v2
        Dim RpDatos As New CrystalDecisions.Shared.ParameterValues()
        Dim FacturaInicio As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim FacturaFin As New CrystalDecisions.Shared.ParameterDiscreteValue()

        'FacturaInicio.Value = txb_FacIni.Text
        'FacturaFin.Value = txb_FacFin.Text

        RpDatos.Add(FacturaInicio)
        MyReport.DataDefinition.ParameterFields("DocIni").ApplyCurrentValues(RpDatos)
        RpDatos.Clear()

        RpDatos.Add(FacturaFin)
        MyReport.DataDefinition.ParameterFields("DonFin").ApplyCurrentValues(RpDatos)
        RpDatos.Clear()


        Dim MiConexion As New CrystalDecisions.Shared.ConnectionInfo
        Dim myTables As CrystalDecisions.CrystalReports.Engine.Tables = MyReport.Database.Tables
        MiConexion.ServerName = "SAP"
        MiConexion.DatabaseName = "BD_Bourne"
        MiConexion.UserID = "sa"
        MiConexion.Password = "Bourn3"
        For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
            Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
            myTableLogonInfo.ConnectionInfo = MiConexion
            myTable.ApplyLogOnInfo(myTableLogonInfo)
        Next



        CrystalReportViewer1.ReportSource = MyReport
        MyReport.PrintToPrinter(1, False, 0, 0)

        ''El nombre del parametro (en azul) debe ser EXACTAMENTE igual al nombre que tiene en el reporte.
    End Sub

    ''Imprimir directamente en la impresora predeterminada
    'Protected Sub Accion_ImprimirDirectoEnImpresora()
    '    Dim oDataSet As New DataSet
    '    oDataSet.Merge(Me.AuthorData)
    '    Dim MiInforme As New Facturas_sin_bodega_1
    '    ' enganchar los datos a imprimir
    '    MiInforme.SetDataSource(oDataSet)
    '    ' Imprimir el informe. Establecer los parámetros
    '    ' startPageN y endPageN en 0 para imprimir todas las páginas.
    '    MiInforme.PrintToPrinter(1, False, 0, 0)
    'End Sub

    ''OPCION 2
    ''Mostrar una vista previa según la ayuda MSDN (mejor no emplear)
    '' Ayuda MSDN, entrada
    '' Opciones de enlace de informes de Windows Forms Viewers
    '' Imports CrystalDecisions.CrystalReports.Engine
    'Public WithEvents oRpt As ReportDocument
    'Public Sub Accion_imprimirDatos(ByRef ConjuntoDeDatos As DataSet)
    '    CrystalReportViewer1.Visible = True
    '    oRpt = New ReportDocument
    '    oRpt.Load("C:\Program Files (x86)\ESSCO\SinCroCliente")
    '    'Utilizar el modelo de objetos Report Engine
    '    'para pasar conjuntos de datos llenos al informe
    '    oRpt.SetDataSource(ConjuntoDeDatos)

    '    ' enlazar el objeto de informe con datos a
    '    ' Web Forms Viewer
    '    CrystalReportViewer1.ReportSource = oRpt







    'End Sub






    'Imprimir en un fichero PDF
    ''/** ******************************************************
    '' Función : InformeCrystal_Forms_ImprimirDatosFormatoPDF
    ''----------------------------------------------------------
    '' Propósito .............:
    '' Genera un fichero FDF a partir de un informe Cristal
    '' Parámetros .............:
    '' Necesita recibir a través de los parámetros
    '' * El conjunto de datos a imprimir (DataSet)
    '' * El informe que utiliza para imprimir(Crystal Report)
    '' * El nombre del fichero para el documento PDF
    '' Observación ............:
    '' Solo funciona con Formularios Windows
    '' Necesita una referencia al espacio de nombres
    '' * CrystalDecisions.Shared
    '' * CrystalDecisions.CrystalReports.Engine
    ''----------------------------------------------------------
    ''*/
    'Public Sub InformeCrystal_Forms_ImprimirDatosFormatoPDF( _
    'ByVal pConjuntoDeDatos As System.Data.DataSet, _
    'ByVal pInformeCrystal As  _
    'CrystalDecisions.CrystalReports.Engine.ReportDocument, _
    'ByVal pNombreFichero As System.String)
    '    Try
    '        ' informacion para el control "SaveFileDialog"
    '        ' enganchar los datos a imprimir
    '        pInformeCrystal.SetDataSource(pConjuntoDeDatos)
    '        ' indicamos que el destino será un archivo del disco
    '        Dim diskOpts As New CrystalDecisions.Shared. _
    '        DiskFileDestinationOptions
    '        ' establecer el nombre del archivo de disco
    '        diskOpts.DiskFileName = pNombreFichero
    '        'establecer el formato de exportación
    '        With pInformeCrystal.ExportOptions
    '            'opciones de archivo de disco
    '            .DestinationOptions = diskOpts
    '            ' documento PDF
    '            .ExportFormatType = CrystalDecisions.Shared. _
    '            ExportFormatType.PortableDocFormat
    '            ' documento rtf
    '            '.ExportFormatType = ExportFormatType.RichText
    '            ' documento Doc
    '            '.ExportFormatType = ExportFormatType.WordForWindows
    '            ' en disco
    '            .ExportDestinationType = CrystalDecisions.Shared. _
    '            ExportDestinationType.DiskFile
    '        End With
    '        ' exportamos el informe
    '        pInformeCrystal.Export()
    '        ' informar de que se ha hecho sin problemas
    '        MessageBox.Show( _
    '        "Terminada la grabación en disco del fichero" & _
    '        ControlChars.CrLf & "[" & pNombreFichero & "]", _
    '        "Proceso de Grabacion", _
    '        MessageBoxButtons.OK, _
    '        MessageBoxIcon.Information, _
    '        MessageBoxDefaultButton.Button1, _
    '        MessageBoxOptions.DefaultDesktopOnly)
    '        ' continua en el Finally
    '        '-----------------------------------------------------------
    '        ' ayuda MSDN
    '        ' Entrada [ExportToDisk]
    '        'El siguiente ejemplo exporta el informe a disco
    '        'como documento RTF.
    '        '[Visual Basic]
    '        ' Report.ExportToDisk(ExportFormatType.RichText, "report.rtf")
    '        '-----------------------------------------------------------
    '    Catch ex As Exception
    '        ' informar de la excepcion antes de enviarla hacia arriba
    '        MessageBox.Show( _
    '        "ERROR" & ControlChars.CrLf & _
    '        "Durante el proceso de generación del documento PDF" & _
    '        " ha aparecido el siguiente error:" & _
    '        ControlChars.CrLf & ex.Message, _
    '        "Proceso de Grabacion", _
    '        MessageBoxButtons.OK, _
    '        MessageBoxIcon.Error, _
    '        MessageBoxDefaultButton.Button1, _
    '        MessageBoxOptions.DefaultDesktopOnly)
    '        ' lanzar el error hacia arriba
    '        Throw
    '    Finally
    '        ' cargarme las variables empleadas
    '        ' cerrar el informe
    '        If Not pInformeCrystal Is Nothing Then
    '            pInformeCrystal.Close()
    '            pInformeCrystal = Nothing
    '        End If
    '        If Not pConjuntoDeDatos Is Nothing Then
    '            pConjuntoDeDatos = Nothing
    '        End If
    '        If Not pNombreFichero Is Nothing Then
    '            pNombreFichero = Nothing
    '        End If
    '    End Try
    'End Sub


    '' Mostrar una vista previa con un control CrystalReportViewer
    'Public Sub Accion_ImprimirDatosVistaPrevia( _
    'ByRef ConjuntoDeDatos As DataSet)
    '    CrystalReportViewer1.Visible = True
    '    Dim miInforme As New Facturas_sin_bodega_1
    '    miInforme.SetDataSource(ConjuntoDeDatos)
    '    CrystalReportViewer1.ReportSource = miInforme
    'End Sub


    ''Funcion preparatoria
    'Public Sub Accion_imprimirDatos_FormatoPDF()
    '    ' instancia de un nuevo informe
    '    Dim MiInforme As New Facturas_sin_bodega_1
    '    ' enganchar los datos a imprimir
    '    MiInforme.SetDataSource(oDataSet)
    '    ' llamar a la funcion que hace el trabajo
    '    ExportToPDF(MiInforme)
    'End Sub
    'Exportar en formato PDF

    'Private Sub ExportToPDF(ByVal oRpt As ReportDocument)
    '    '------------------------------------------------------------------
    '    ' origen de este código (18/02/2005)
    '    ' http://www.devx.com/tips/Tip/18010
    '    ' Export Crystal Reports to PDF
    '    ' Use this code when you're developing Web pages and you need to
    '    ' export Crystal Reports to PDF without creating their own files.
    '    ' The undocument FormatEngine property of ReportDocument class
    '    ' (you can see it using ObjectBrowser or ILDASM) gets the job done:
    '    '-------------------------------------------------------------------
    '    Dim crExportOptions As ExportOptions
    '    crExportOptions = oRpt.ExportOptions
    '    With crExportOptions
    '        .FormatOptions = New PdfRtfWordFormatOptions
    '        .ExportFormatType = ExportFormatType.PortableDocFormat
    '    End With
    '    Dim req As ExportRequestContext = New ExportRequestContext
    '    req.ExportInfo = crExportOptions
    '    Dim st As System.IO.Stream
    '    st = oRpt.FormatEngine.ExportToStream(req)
    '    Response.ClearContent()
    '    Response.ClearHeaders()
    '    Response.ContentType = "application/pdf"
    '    Dim ln As Integer = 0
    '    ln = CInt(st.Length)
    '    Dim b(ln) As Byte
    '    st.Read(b, 0, ln)
    '    Response.BinaryWrite(b)
    '    Response.End()
    'End Sub


End Class