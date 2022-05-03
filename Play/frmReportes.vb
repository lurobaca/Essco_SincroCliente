Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.OleDb
Imports System.Threading
Imports System.Drawing.Printing
Imports System.IO

Public Class frmReportes
    Private tr_Print As Thread
    Private tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
    Private tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
    Private Obj_QR As QR_CODE
    Public ImprecionesFE As Integer = 1
    Public ImprecionesFES As Integer = 1
    Public ImprecionesNC As Integer = 1
    Public ImprecionesNCS As Integer = 1
    Public ImprecionesND As Integer = 1
    Public ImprecionesNDS As Integer = 1

    Private Sub frmReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Obj_QR = New QR_CODE
            CheckForIllegalCrossThreadCalls = False
            tr_Print = Nothing

            If VariablesGlobales.IMPRIMIENDO = "FE" Then
                'tr_Print = New Thread(AddressOf Imprimir_FE)
                'Imprimir_FE()

            ElseIf VariablesGlobales.IMPRIMIENDO = "TE" Then
                ' tr_Print = New Thread(AddressOf Imprimir_FES)
                'Imprimir_TE()
            ElseIf VariablesGlobales.IMPRIMIENDO = "FES" Then
                ' tr_Print = New Thread(AddressOf Imprimir_FES)
                'Imprimir_FES()

            ElseIf VariablesGlobales.IMPRIMIENDO = "NC" Then
                'tr_Print = New Thread(AddressOf Imprimir_NC)
                'Imprimir_NC()
            ElseIf VariablesGlobales.IMPRIMIENDO = "NCS" Then
                'Imprimir_NCS()

                'tr_Print = New Thread(AddressOf Imprimir_NCS)
            ElseIf VariablesGlobales.IMPRIMIENDO = "ND" Then
                'Imprimir_ND()
            ElseIf VariablesGlobales.IMPRIMIENDO = "NDS" Then
                'Imprimir_NDS()
            End If

            'tr_Print.IsBackground = Enabled
            'tr_Print.Priority = ThreadPriority.AboveNormal
            'tr_Print.Start()
            'Me.Close()
            'CheckForIllegalCrossThreadCalls = False
        Catch ex As Exception
            'VariablesGlobales.Obj_Log.Log("ERROR Load frmReportes [" & ex.Message & " ]", VariablesGlobales.IMPRIMIENDO)
            'MsgBox("ERROR en load frmReportes_Load [ " & ex.Message & " ]")
        End Try
    End Sub

    Public Function Imprimir_TE(CodSeguridad As String)
        Dim Obj_Funciones As New Class_funcionesSQL
        Try
            'Genera la imagen con el codigo QR
            Obj_QR = New QR_CODE
            Obj_QR.Generar(VariablesGlobales.Patch_TE, CodSeguridad, "TE")

            ' CheckForIllegalCrossThreadCalls = False
            Dim cryRpt As HojaCarta_TE
            cryRpt = New HojaCarta_TE

            Dim MiConexion As New CrystalDecisions.Shared.ConnectionInfo
            Dim myTables As CrystalDecisions.CrystalReports.Engine.Tables = cryRpt.Database.Tables
            Dim parametros As Integer = 0
            cryRpt.SetDatabaseLogon(VariablesGlobales.XMLParamSQL_user, Class_VariablesGlobales.XMLParamSQL_clave, Class_VariablesGlobales.XMLParamSQL_server, Class_VariablesGlobales.XMLParamSAP_CompanyDB, False)

            MiConexion.ServerName = Class_VariablesGlobales.XMLParamSQL_server
            MiConexion.DatabaseName = Class_VariablesGlobales.XMLParamSAP_CompanyDB
            MiConexion.UserID = Class_VariablesGlobales.XMLParamSQL_user
            MiConexion.Password = Class_VariablesGlobales.XMLParamSQL_clave

            For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
                Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
                myTableLogonInfo.ConnectionInfo = MiConexion
                myTable.ApplyLogOnInfo(myTableLogonInfo)
            Next
            'configureCrystalReports()
            '----- PARAMETROS REPORTE PADRE  --------------

            '0:          Factura FIN

            cryRpt.SetParameterValue(0, VariablesGlobales.Patch_TE & "\" & CodSeguridad & "\" & CodSeguridad & ".png")
            cryRpt.SetParameterValue(1, CodSeguridad)
            parametros += 1

            Dim pd As New PrintDocument
            'Se define el print Document.
            Dim impresora_predeterminada As String = pd.PrinterSettings.PrinterName
            'CRV_FE.Refresh()
            'CRV_FE.ReportSource = cryRpt
            'CRV_FE.Refresh()

            cryRpt.PrintOptions.PrinterName = impresora_predeterminada
            'If VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_TE.Checked = True Then
            '    cryRpt.PrintToPrinter(1, False, 0, 0) 'imprime 1 copia
            'End If


            ExportToPDF_TE(cryRpt, CodSeguridad, "TE")
            cryRpt.Dispose()
            cryRpt = Nothing
            MiConexion = Nothing
            'myTables = Nothing
            parametros = Nothing
            pd = Nothing
            impresora_predeterminada = Nothing
            Me.Close()
        Catch ex As Exception
            VariablesGlobales.Obj_Log.Log("ERROR frmReporte Imprimir_TE [" & ex.Message & " ]", "TE")
            ' MessageBox.Show("ERROR EN frmReporte Imprimir_TE [" & ex.Message & " ]")
            ' Dim Obj_Funciones As New Class_funcionesSQL
            Dim obj_Fecha As New FechaManager
            'Se guarda el encabezado del comprobante con la fecha y hora del estado
            Obj_Funciones.GuardaComprobanteEnBitacora("TE", VariablesGlobales.ReporteTE_Clave, "ERROR", obj_Fecha.FormatoFechaSql(Date.Now), "El en Imprimir_TE [" & ex.Message & " ] No se genero ni imprimio la representacion grafica", DateTime.Now.ToString("hh:mm"))
            obj_Fecha = Nothing
            Obj_Funciones = Nothing
            'tr_Print.Abort()
            ' Imprimir_TE()
            Me.Close()
        End Try
    End Function

    Public Function Imprimir_FE(CodSeguridad As String)
        Dim Obj_Funciones As New Class_funcionesSQL
        ' Dim obj_SAP As New SAP
        Dim impresora_predeterminada As String
        Try
            'Genera la imagen con el codigo QR
            Obj_QR = New QR_CODE
            Obj_QR.Generar(VariablesGlobales.Patch_FE, CodSeguridad, "FE")

            ' CheckForIllegalCrossThreadCalls = False
            Dim cryRpt As HojaCarta_FE
            cryRpt = New HojaCarta_FE

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

            cryRpt.SetParameterValue(0, VariablesGlobales.Patch_FE & "\" & CodSeguridad & "\" & CodSeguridad & ".png")
            cryRpt.SetParameterValue(1, CodSeguridad)

            parametros += 1

            'Dim pd As New PrintDocument
            ''Se define el print Document.
            'If VariablesGlobales.PRINT_FE <> "" Then
            '    impresora_predeterminada = Trim(VariablesGlobales.PRINT_FE)
            'Else
            '    impresora_predeterminada = pd.PrinterSettings.PrinterName
            'End If
            'cryRpt.PrintOptions.PrinterName = impresora_predeterminada

            ''******** Verificamos que la impresora esta activa si no lo esta no imprime para evitar caidas del sistema**********
            'Dim ObjPrinter As New Printer
            'If ObjPrinter.Estado(impresora_predeterminada) = False Then
            '    VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_FE.Checked = False
            '    VariablesGlobales.Obj_TestFactura.List_FE.Items.Insert(0, "VERIFIQUE LA IMPRESORA Clave [ " & VariablesGlobales.ReporteFE_Clave & " ]" & " [ " & Now.Date & "]")
            '    VariablesGlobales.Obj_Log.Log("ERROR Imprimir_FE VERIFIQUE LA IMPRESORA INTERNO [ " & VariablesGlobales.ReporteFE_Clave & " ]", "FE")
            'Else
            '    ' VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_FE.Checked = True
            '    VariablesGlobales.Obj_Log.Log("IMPRESORA DISPONIBLE INTERNO [ " & VariablesGlobales.ReporteFE_CodSeguridad & " ]", "FE")
            'End If
            'ObjPrinter = Nothing
            ''******** Verificamos que la impresora esta activa si no lo esta no imprime para evitar caidas del sistema**********

            ''Si esta autorizado el imprimir y si no se ha impreso se manda a imprimir
            'If VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_FE.Checked = True And Obj_Funciones.ObtieneEstadoImpresion(Trim(VariablesGlobales.ReporteFE_CodSeguridad), "FE") = False Then

            '    VariablesGlobales.Obj_Log.Log("Envio A Imprimir_FE [" & VariablesGlobales.ReporteFE_CodSeguridad & "]  Copias( " & Trim(VariablesGlobales.Obj_TestFactura.txtb_FECopias.Text) & " ) ", "FE")
            '    cryRpt.PrintToPrinter(1, False, 0, 0) 'imprime ORIGINAL
            '    ExportToPDF_FE(cryRpt, VariablesGlobales.ReporteFE_CodSeguridad, "FE") 'Lo exportamos a PDF aqui para que aparesca como original
            '    cryRpt.Refresh()
            '    '******************************RECARGAR LA INFOR DEL REPORTE ******************************************
            '    MiConexion = New CrystalDecisions.Shared.ConnectionInfo
            '    myTables = cryRpt.Database.Tables
            '    cryRpt.SetDatabaseLogon(VariablesGlobales.XMLParamSQL_user, VariablesGlobales.XMLParamSQL_clave, VariablesGlobales.XMLParamSQL_server, VariablesGlobales.XMLParamSAP_CompanyDB, False)
            '    MiConexion.ServerName = VariablesGlobales.XMLParamSQL_server
            '    MiConexion.DatabaseName = VariablesGlobales.XMLParamSAP_CompanyDB
            '    MiConexion.UserID = VariablesGlobales.XMLParamSQL_user
            '    MiConexion.Password = VariablesGlobales.XMLParamSQL_clave

            '    For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
            '        Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
            '        myTableLogonInfo.ConnectionInfo = MiConexion
            '        myTable.ApplyLogOnInfo(myTableLogonInfo)
            '    Next
            '    cryRpt.SetParameterValue(0, VariablesGlobales.Patch_FE & "\" & VariablesGlobales.ReporteFE_Clave & "\" & VariablesGlobales.ReporteFE_Clave & ".png")
            '    cryRpt.SetParameterValue(1, VariablesGlobales.ReporteFE_Consecutivo)

            '    '************************************************************************
            '    'Dim Actualizo As Integer = 0
            '    ' Do

            '    'Actualizo = obj_SAP.ActualizaEstadoPrintFESAP(Obj_Funciones.ObtieneDocEntryComprobante(CInt(Trim(VariablesGlobales.ReporteFE_CodSeguridad)), "FE"), "FE")
            '    'If Actualizo = 0 Then
            '    'IMPRIME COPIAS, Resta las copias menos 1(ORIGINAL) y esto sacara la cantidad de copias faltantes 
            '    If (CInt(Trim(VariablesGlobales.Obj_TestFactura.txtb_FECopias.Text)) - 1) > 0 Then
            '        VariablesGlobales.Obj_Log.Log("Manda imprimir Copias [" & VariablesGlobales.ReporteFE_CodSeguridad & "] Copias " & CInt(Trim(VariablesGlobales.Obj_TestFactura.txtb_FECopias.Text)) - 1, "FE")
            '        VariablesGlobales.Obj_Log.Log("Cambio estado a impreso [" & VariablesGlobales.ReporteFE_CodSeguridad & "]", "FE")
            '        'Cambiamos el estado a impreso, para saber si ya fue mandado a imprimir
            '        Obj_Funciones.ActualizaEstadoImpresion(Trim(VariablesGlobales.ReporteFE_CodSeguridad), "FE")



            '        cryRpt.PrintToPrinter((CInt(Trim(VariablesGlobales.Obj_TestFactura.txtb_FECopias.Text)) - 1), False, 0, 0) 'imprime Copias 
            '    End If

            '    'End If

            '    'Loop While Actualizo <> 0

            '    'Actualizo = Nothing


            'ElseIf VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_FE.Checked = False Then
            ExportToPDF_FE(cryRpt, CodSeguridad, "FE") 'Lo exportamos a PDF aqui para que aparesca como original
            'End If

            cryRpt.Close()
            cryRpt.Dispose()
            cryRpt = Nothing

            ''--------------- LIBERAMOS MEMORIA------------------
            'MiConexion = Nothing
            'myTables = Nothing
            parametros = Nothing
            'pd = Nothing
            impresora_predeterminada = Nothing
            'myTableLogonInfo = Nothing
            parametros = Nothing

            Me.Close()
        Catch ex As Exception
            ' VariablesGlobales.Obj_Log.Log("ERROR Imprimir_FE [" & ex.Message & " ] [" & VariablesGlobales.ReporteFE_CodSeguridad & "]", "FE")
            'MessageBox.Show("ERROR EN frmReporte Imprimir_FE [" & ex.Message & " ] Clave [ " & VariablesGlobales.ReporteFE_Clave & " ]" & VariablesGlobales.XMLParamSQL_user & " -- " & VariablesGlobales.XMLParamSQL_clave)

            Dim obj_Fecha As New FechaManager
            'Se guarda el encabezado del comprobante con la fecha y hora del estado
            'Obj_Funciones.GuardaComprobanteEnBitacora("FE", VariablesGlobales.ReporteFE_Clave, "ERROR", obj_Fecha.FormatoFechaSql(Date.Now), "El en Imprimir_FE [" & ex.Message & " ] No se genero ni imprimio la representacion grafica", DateTime.Now.ToString("hh:mm"))
            obj_Fecha = Nothing
            Obj_Funciones = Nothing

            'If File.Exists(VariablesGlobales.Patch_FE & " \" & VariablesGlobales.ReporteFE_CodSeguridad & "\" & VariablesGlobales.ReporteFE_CodSeguridad & ".pdf") = False Then
            '    VariablesGlobales.Obj_TestFactura.List_FE.Items.Insert(0, "ERROR EN frmReporte Imprimir_FE [" & ex.Message & " ] Clave [ " & VariablesGlobales.ReporteFE_Clave & " ]" & " [ " & Now.Date & "]")
            '    Imprimir_FE()
            'Else

            '    Me.Close()
            'End If
            'tr_Print.Abort()
            ' Imprimir_FE()
            MessageBox.Show(ex.Message & " - " & VariablesGlobales.Patch_FE & "  ,  " & CodSeguridad, "Imprimir_FE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Function

    Public Function Imprimir_FES(CodSeguridad As String)

        Dim Obj_Funciones As New Class_funcionesSQL
        Dim impresora_predeterminada As String
        Try
            Obj_QR = New QR_CODE
            'Genera la imagen con el codigo QR
            Obj_QR.Generar(VariablesGlobales.Patch_FE, CodSeguridad, "FES")

            ' CheckForIllegalCrossThreadCalls = False
            Dim cryRpt As HojaCarta_FES
            cryRpt = New HojaCarta_FES
            'Dim obj_SAP As New SAP

            Dim MiConexion As New CrystalDecisions.Shared.ConnectionInfo
            Dim myTables As CrystalDecisions.CrystalReports.Engine.Tables = cryRpt.Database.Tables
            Dim parametros As Integer = 0
            cryRpt.Refresh()

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

            cryRpt.SetParameterValue(0, VariablesGlobales.Patch_FE & "\" & CodSeguridad & "\" & CodSeguridad & ".png")
            cryRpt.SetParameterValue(1, CodSeguridad)

            parametros += 1

            'Dim pd As New PrintDocument
            ''Se define el print Document.
            'If VariablesGlobales.PRINT_FES <> "" Then
            '    impresora_predeterminada = Trim(VariablesGlobales.PRINT_FES)
            'Else

            '    impresora_predeterminada = pd.PrinterSettings.PrinterName
            'End If

            'cryRpt.PrintOptions.PrinterName = impresora_predeterminada

            ''*********** Verificamos que la impresora esta activa si no lo esta no imprime para evitar caidas del sistema ********
            'Dim ObjPrinter As New Printer
            'If ObjPrinter.Estado(impresora_predeterminada) Then
            '    'VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_FES.Checked = False
            '    'VariablesGlobales.Obj_TestFactura.List_FES.Items.Insert(0, "VERIFIQUE LA IMPRESORA Clave [ " & VariablesGlobales.ReporteFES_Clave & " ]" & " [ " & Now.Date & "]")
            '    'VariablesGlobales.Obj_Log.Log("ERROR Imprimir_FES VERIFIQUE LA IMPRESORA Clave [ " & VariablesGlobales.ReporteFES_Clave & " ]", "FES")
            'Else
            '    'VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_FES.Checked = True
            '    'VariablesGlobales.Obj_Log.Log("IMPRESORA DISPONIBLE [" & impresora_predeterminada & "], FES [" & VariablesGlobales.ReporteFES_CodSeguridad & "]  ", "FES")
            'End If
            'ObjPrinter = Nothing
            ''*********** Verificamos que la impresora esta activa si no lo esta no imprime para evitar caidas del sistema ********

            'If VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_FES.Checked = True And Obj_Funciones.ObtieneEstadoImpresion(Trim(VariablesGlobales.ReporteFES_CodSeguridad), "FES") = False Then

            '    VariablesGlobales.Obj_Log.Log("Envio A Imprimir_FE [" & VariablesGlobales.ReporteFES_CodSeguridad & "]  Copias( " & Trim(VariablesGlobales.Obj_TestFactura.txtb_FESCopias.Text) & " ) ", "FES")
            '    cryRpt.PrintToPrinter(1, False, 0, 0) 'imprime ORIGINAL
            '    ExportToPDF_FES(cryRpt, VariablesGlobales.ReporteFES_CodSeguridad, "FES")
            '    obj_SAP.ActualizaEstadoPrintFESAP(Obj_Funciones.ObtieneDocEntryComprobante(CInt(Trim(VariablesGlobales.ReporteFE_CodSeguridad)), "FES"), "FES")

            '    'IMPRIME COPIAS, Resta las copias menos 1(ORIGINAL) y esto sacara la cantidad de copias faltantes 
            '    If (CInt(Trim(VariablesGlobales.Obj_TestFactura.txtb_FESCopias.Text)) - ImprecionesFES) > 0 Then

            '        '*************************** RECARGAR REPORTE PARA QUE SALGA COMO COPIA *************************
            '        cryRpt.Refresh()
            '        MiConexion = New CrystalDecisions.Shared.ConnectionInfo
            '        myTables = cryRpt.Database.Tables
            '        cryRpt.SetDatabaseLogon(VariablesGlobales.XMLParamSQL_user, VariablesGlobales.XMLParamSQL_clave, VariablesGlobales.XMLParamSQL_server, VariablesGlobales.XMLParamSAP_DB, False)
            '        MiConexion.ServerName = VariablesGlobales.XMLParamSQL_server
            '        MiConexion.DatabaseName = VariablesGlobales.XMLParamSAP_CompanyDB
            '        MiConexion.UserID = VariablesGlobales.XMLParamSQL_user
            '        MiConexion.Password = VariablesGlobales.XMLParamSQL_clave
            '        For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
            '            Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
            '            myTableLogonInfo.ConnectionInfo = MiConexion
            '            myTable.ApplyLogOnInfo(myTableLogonInfo)
            '        Next
            '        cryRpt.SetParameterValue(0, VariablesGlobales.Patch_FE & "\" & VariablesGlobales.ReporteFES_Clave & "\" & VariablesGlobales.ReporteFES_Clave & ".png")
            '        cryRpt.SetParameterValue(1, VariablesGlobales.ReporteFES_Consecutivo)
            '        '************************************************************************************************
            '        VariablesGlobales.Obj_Log.Log("Manda imprimir Copias [" & VariablesGlobales.ReporteFE_CodSeguridad & "] Copias " & CInt(Trim(VariablesGlobales.Obj_TestFactura.txtb_FECopias.Text)) - 1, "FES")
            '        cryRpt.PrintToPrinter((CInt(Trim(VariablesGlobales.Obj_TestFactura.txtb_FESCopias.Text)) - 1), False, 0, 0) 'imprime Copias 
            '    End If

            '    VariablesGlobales.Obj_Log.Log("Cambio estado a impreso [" & VariablesGlobales.ReporteFES_CodSeguridad & "]", "FES")
            '    Obj_Funciones.ActualizaEstadoImpresion(Trim(VariablesGlobales.ReporteFES_CodSeguridad), "FES")
            'ElseIf VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_FES.Checked = False Then
            ExportToPDF_FES(cryRpt, CodSeguridad, "FES") 'Lo exportamos a PDF aqui para que aparesca como original
            'End If
            cryRpt.Close()
            cryRpt.Dispose()
            cryRpt = Nothing

            ''--------------- LIBERAMOS MEMORIA------------------
            'MiConexion = Nothing
            'myTables = Nothing
            parametros = Nothing
            'pd = Nothing
            impresora_predeterminada = Nothing
            'myTableLogonInfo = Nothing
            parametros = Nothing
            Me.Close()
        Catch ex As Exception
            'VariablesGlobales.Obj_Log.Log("ERROR Imprimir_FES [" & ex.Message & " ] [" & VariablesGlobales.ReporteFES_CodSeguridad & "]", "FES")
            'MessageBox.Show("ERROR EN frmReporte Imprimir_FE [" & ex.Message & " ] Clave [ " & VariablesGlobales.ReporteFE_Clave & " ]" & VariablesGlobales.XMLParamSQL_user & " -- " & VariablesGlobales.XMLParamSQL_clave)

            Dim obj_Fecha As New FechaManager
            'Se guarda el encabezado del comprobante con la fecha y hora del estado
            Obj_Funciones.GuardaComprobanteEnBitacora("FES", CodSeguridad, "ERROR", obj_Fecha.FormatoFechaSql(Date.Now), "El en Imprimir_FES [" & ex.Message & " ] No se genero ni imprimio la representacion grafica", DateTime.Now.ToString("hh:mm"))
            obj_Fecha = Nothing
            Obj_Funciones = Nothing

            'If File.Exists(VariablesGlobales.Patch_FE & " \" & VariablesGlobales.ReporteFES_CodSeguridad & "\" & VariablesGlobales.ReporteFES_CodSeguridad & ".pdf") = False Then
            '    VariablesGlobales.Obj_TestFactura.List_FES.Items.Insert(0, "ERROR EN frmReporte Imprimir_FES [" & ex.Message & " ] Clave [ " & VariablesGlobales.ReporteFES_Clave & " ]" & " [ " & Now.Date & "]")
            '    Imprimir_FES()
            'Else
            '    Me.Close()
            'End If

            MessageBox.Show("Catch Imprimir_FES " & ex.Message, "Catch", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Function

    Public Function Imprimir_NC(CodSeguridad As String)
        Dim Obj_Funciones As New Class_funcionesSQL
        'Dim obj_SAP As New SAP
        Dim impresora_predeterminada As String
        Try
            'Genera la imagen con el codigo QR
            Obj_QR = New QR_CODE
            Obj_QR.Generar(VariablesGlobales.Patch_NC, CodSeguridad, "NC")

            CheckForIllegalCrossThreadCalls = False
            Dim cryRpt As NotasCredito_NC
            cryRpt = New NotasCredito_NC
            Dim MiConexion As New CrystalDecisions.Shared.ConnectionInfo
            Dim myTables As CrystalDecisions.CrystalReports.Engine.Tables = cryRpt.Database.Tables
            Dim parametros As Integer = 0

            'cryRpt.Refresh()

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

            cryRpt.SetParameterValue(0, VariablesGlobales.Patch_NC & "\" & CodSeguridad & "\" & CodSeguridad & ".png")
            cryRpt.SetParameterValue(1, CodSeguridad)
            parametros += 1

            'Dim pd As New PrintDocument
            ''Se define el print Document.
            'If VariablesGlobales.PRINT_NC <> "" Then
            '    impresora_predeterminada = Trim(VariablesGlobales.PRINT_NC)
            'Else
            '    impresora_predeterminada = pd.PrinterSettings.PrinterName
            'End If

            'cryRpt.PrintOptions.PrinterName = impresora_predeterminada

            '''******** Verificamos que la impresora esta activa si no lo esta no imprime para evitar caidas del sistema**********
            'Dim ObjPrinter As New Printer
            'If ObjPrinter.Estado(impresora_predeterminada) = False Then
            '    VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_NC.Checked = False
            '    VariablesGlobales.Obj_TestFactura.List_NC.Items.Insert(0, "VERIFIQUE LA IMPRESORA Clave [ " & VariablesGlobales.ReporteNC_Clave & " ]" & " [ " & Now.Date & "]")
            '    VariablesGlobales.Obj_Log.Log("ERROR Imprimir_NC VERIFIQUE LA IMPRESORA Clave [ " & VariablesGlobales.ReporteNC_Clave & " ]", "NC")
            'Else
            '    'VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_NC.Checked = True
            '    VariablesGlobales.Obj_Log.Log("IMPRESORA DISPONIBLE [" & impresora_predeterminada & "], NC [" & VariablesGlobales.ReporteNC_CodSeguridad & "]  ", "NC")
            'End If
            'ObjPrinter = Nothing
            '''******** Verificamos que la impresora esta activa si no lo esta no imprime para evitar caidas del sistema**********
            'If VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_NC.Checked = True And Obj_Funciones.ObtieneEstadoImpresion(Trim(VariablesGlobales.ReporteNC_CodSeguridad), "NC") = False Then


            '    VariablesGlobales.Obj_Log.Log("Envio A Imprimir_NC [" & VariablesGlobales.ReporteNC_CodSeguridad & "]  Copias( " & Trim(VariablesGlobales.Obj_TestFactura.txtb_NCCopias.Text) & " ) ", "NC")

            '    cryRpt.PrintToPrinter(1, False, 0, 0) 'imprime 1 copia


            '    ExportToPDF_NC(cryRpt, VariablesGlobales.ReporteNC_CodSeguridad, "NC")
            '    obj_SAP.ActualizaEstadoPrintNCSAP(Obj_Funciones.ObtieneDocEntryComprobante(CInt(Trim(VariablesGlobales.ReporteNC_CodSeguridad)), "NC"), "NC")

            '    'IMPRIME COPIAS, Resta las copias menos 1(ORIGINAL) y esto sacara la cantidad de copias faltantes 
            '    If (CInt(Trim(VariablesGlobales.Obj_TestFactura.txtb_NCCopias.Text)) - 1) > 0 Then

            '        '****************************************** RECARGA REPORTE PARA PODER IMPRIMIR COPIA ********************
            '        cryRpt.Refresh()
            '        MiConexion = New CrystalDecisions.Shared.ConnectionInfo
            '        myTables = cryRpt.Database.Tables
            '        cryRpt.SetDatabaseLogon(VariablesGlobales.XMLParamSQL_user, VariablesGlobales.XMLParamSQL_clave, VariablesGlobales.XMLParamSQL_server, VariablesGlobales.XMLParamSAP_DB, False)
            '        MiConexion.ServerName = VariablesGlobales.XMLParamSQL_server
            '        MiConexion.DatabaseName = VariablesGlobales.XMLParamSAP_CompanyDB
            '        MiConexion.UserID = VariablesGlobales.XMLParamSQL_user
            '        MiConexion.Password = VariablesGlobales.XMLParamSQL_clave
            '        For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
            '            Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
            '            myTableLogonInfo.ConnectionInfo = MiConexion
            '            myTable.ApplyLogOnInfo(myTableLogonInfo)
            '        Next
            '        cryRpt.SetParameterValue(0, VariablesGlobales.Patch_NC & "\" & VariablesGlobales.ReporteNC_CodSeguridad & "\" & VariablesGlobales.ReporteNC_CodSeguridad & ".png")
            '        cryRpt.SetParameterValue(1, VariablesGlobales.ReporteNC_Consecutivo)
            '        '*********************************************************************************************************
            '        VariablesGlobales.Obj_Log.Log("Manda imprimir Copias [" & VariablesGlobales.ReporteFE_CodSeguridad & "] Copias " & CInt(Trim(VariablesGlobales.Obj_TestFactura.txtb_FECopias.Text)) - 1, "NC")

            '        cryRpt.PrintToPrinter((CInt(Trim(VariablesGlobales.Obj_TestFactura.txtb_NCCopias.Text)) - 1), False, 0, 0) 'imprime Copias 


            '    End If
            '    VariablesGlobales.Obj_Log.Log("Cambio estado a impreso [" & VariablesGlobales.ReporteNC_CodSeguridad & "]", "NC")
            '    'Cambiamos el estado a impreso, para saber si ya fue mandado a imprimir
            '    Obj_Funciones.ActualizaEstadoImpresion(Trim(VariablesGlobales.ReporteNC_CodSeguridad), "NC")
            'ElseIf VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_NC.Checked = False Then
            ExportToPDF_NC(cryRpt, CodSeguridad, "NC") 'Lo exportamos a PDF aqui para que aparesca como original
            'End If

            cryRpt.Close()

            cryRpt = Nothing
            'MiConexion = Nothing
            'myTables = Nothing
            parametros = Nothing
            'pd = Nothing
            impresora_predeterminada = Nothing
            Me.Close()
        Catch ex As Exception
            ' VariablesGlobales.Obj_Log.Log("ERROR Imprimir_NC [" & ex.Message & " ]", "NC")
            ' VariablesGlobales.Obj_TestFactura.Lb_Info_NC.Text = "ERROR EN frmReporte Imprimir_NC [" & ex.Message & " ] Clave [ " & VariablesGlobales.ReporteNC_Clave & " ]"
            ' MessageBox.Show("ERROR EN frmReporte Imprimir_NC [" & ex.Message & " ] Clave [ " & VariablesGlobales.ReporteNC_Clave & " ]")

            Dim obj_Fecha As New FechaManager
            'Se guarda el encabezado del comprobante con la fecha y hora del estado
            Obj_Funciones.GuardaComprobanteEnBitacora("NC", CodSeguridad, "ERROR", obj_Fecha.FormatoFechaSql(Date.Now), "El en Imprimir_NC [" & ex.Message & " ] No se genero ni imprimio la representacion grafica", DateTime.Now.ToString("hh:mm"))
            obj_Fecha = Nothing
            Obj_Funciones = Nothing
            'tr_Print.Abort()

            'If File.Exists(VariablesGlobales.Patch_NC & " \" & VariablesGlobales.ReporteNC_CodSeguridad & "\" & VariablesGlobales.ReporteNC_CodSeguridad & ".pdf") = False Then
            '    VariablesGlobales.Obj_TestFactura.List_NC.Items.Insert(0, "ERROR EN frmReporte Imprimir_NC [" & ex.Message & " ] Clave [ " & VariablesGlobales.ReporteNC_Clave & " ]" & " [ " & Now.Date & "]")
            '    Imprimir_NC()
            'Else
            '    'Imprimir_NC()
            '    Me.Close()
            'End If

        End Try
    End Function

    Public Function Imprimir_NCS(CodSeguridad As String)
        Dim Obj_Funciones As New Class_funcionesSQL
        'Dim obj_SAP As New SAP
        Dim impresora_predeterminada As String
        Try
            'Genera la imagen con el codigo QR
            Obj_QR = New QR_CODE
            Obj_QR.Generar(VariablesGlobales.Patch_NC, CodSeguridad, "NCS")

            CheckForIllegalCrossThreadCalls = False
            Dim cryRpt As NotasCredito_NCS
            cryRpt = New NotasCredito_NCS
            Dim MiConexion As New CrystalDecisions.Shared.ConnectionInfo
            Dim myTables As CrystalDecisions.CrystalReports.Engine.Tables = cryRpt.Database.Tables
            Dim parametros As Integer = 0

            'cryRpt.Refresh()

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

            cryRpt.SetParameterValue(0, VariablesGlobales.Patch_NC & "\" & CodSeguridad & "\" & CodSeguridad & ".png")
            cryRpt.SetParameterValue(1, CodSeguridad)
            parametros += 1


            Dim pd As New PrintDocument
            'Se define el print Document.
            If VariablesGlobales.PRINT_NCS <> "" Then
                impresora_predeterminada = Trim(VariablesGlobales.PRINT_NCS)
            Else
                impresora_predeterminada = pd.PrinterSettings.PrinterName
            End If

            cryRpt.PrintOptions.PrinterName = impresora_predeterminada

            '''******** Verificamos que la impresora esta activa si no lo esta no imprime para evitar caidas del sistema**********
            'Dim ObjPrinter As New Printer
            'If ObjPrinter.Estado(impresora_predeterminada) = False Then
            '    VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_NCS.Checked = False
            '    VariablesGlobales.Obj_TestFactura.List_NCS.Items.Insert(0, "VERIFIQUE LA IMPRESORA Clave [ " & VariablesGlobales.ReporteNCS_CodSeguridad & " ]" & " [ " & Now.Date & "]")
            '    VariablesGlobales.Obj_Log.Log("ERROR Imprimir_NCS VERIFIQUE LA IMPRESORA Clave [ " & VariablesGlobales.ReporteNCS_CodSeguridad & " ]", "NCS")
            'Else
            '    VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_NCS.Checked = True
            '    VariablesGlobales.Obj_Log.Log("IMPRESORA DISPONIBLE INTERNO [ " & VariablesGlobales.ReporteNCS_CodSeguridad & " ]", "NCS")
            'End If
            'ObjPrinter = Nothing
            '''******** Verificamos que la impresora esta activa si no lo esta no imprime para evitar caidas del sistema**********

            ''Si esta autorizado el imprimir y si no se ha impreso se manda a imprimir
            'If VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_NCS.Checked = True And Obj_Funciones.ObtieneEstadoImpresion(Trim(VariablesGlobales.ReporteNCS_CodSeguridad), "NCS") = False Then

            '    VariablesGlobales.Obj_Log.Log("Envio A Imprimir_NCS [" & VariablesGlobales.ReporteNCS_CodSeguridad & "]  Copias( " & Trim(VariablesGlobales.Obj_TestFactura.txtb_NCSCopias.Text) & " ) ", "NCS")
            '    cryRpt.PrintToPrinter(1, False, 0, 0) 'imprime ORIGINAL
            '    ExportToPDF_NCS(cryRpt, VariablesGlobales.ReporteNCS_CodSeguridad, "NCS")
            '    obj_SAP.ActualizaEstadoPrintNCSAP(Obj_Funciones.ObtieneDocEntryComprobante(CInt(Trim(VariablesGlobales.ReporteNCS_CodSeguridad)), "NC"), "NC")

            '    'IMPRIME COPIAS, Resta las copias menos 1(ORIGINAL) y esto sacara la cantidad de copias faltantes 
            '    If (CInt(Trim(VariablesGlobales.Obj_TestFactura.txtb_NCSCopias.Text)) - 1) > 0 Then

            '        '************************************** RECARGAR REPORTE PARA IMPRIMIR COPIAS ******************
            '        cryRpt.Refresh()
            '        MiConexion = New CrystalDecisions.Shared.ConnectionInfo
            '        myTables = cryRpt.Database.Tables
            '        cryRpt.SetDatabaseLogon(VariablesGlobales.XMLParamSQL_user, VariablesGlobales.XMLParamSQL_clave, VariablesGlobales.XMLParamSQL_server, VariablesGlobales.XMLParamSAP_DB, False)
            '        MiConexion.ServerName = VariablesGlobales.XMLParamSQL_server
            '        MiConexion.DatabaseName = VariablesGlobales.XMLParamSAP_CompanyDB
            '        MiConexion.UserID = VariablesGlobales.XMLParamSQL_user
            '        MiConexion.Password = VariablesGlobales.XMLParamSQL_clave
            '        For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
            '            Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
            '            myTableLogonInfo.ConnectionInfo = MiConexion
            '            myTable.ApplyLogOnInfo(myTableLogonInfo)
            '        Next
            '        cryRpt.SetParameterValue(0, VariablesGlobales.Patch_NC & "\" & CodSeguridad & "\" & CodSeguridad & ".png")
            '        cryRpt.SetParameterValue(1, VariablesGlobales.ReporteNCS_Consecutivo)
            '        '***********************************************************************************************
            '        VariablesGlobales.Obj_Log.Log("Manda imprimir Copias [" & CodSeguridad & "] Copias " & CInt(Trim(VariablesGlobales.Obj_TestFactura.txtb_NCSCopias.Text)) - 1, "NCS")
            '        cryRpt.PrintToPrinter((CInt(Trim(VariablesGlobales.Obj_TestFactura.txtb_NCSCopias.Text)) - 1), False, 0, 0) 'imprime Copias 
            '    End If

            '    VariablesGlobales.Obj_Log.Log("Cambio estado a impreso [" & VariablesGlobales.ReporteNCS_CodSeguridad & "]", "NCS")
            '    'Cambiamos el estado a impreso, para saber si ya fue mandado a imprimir
            '    Obj_Funciones.ActualizaEstadoImpresion(Trim(VariablesGlobales.ReporteNCS_CodSeguridad), "NCS")

            'ElseIf VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_NCS.Checked = False Then
            ExportToPDF_NCS(cryRpt, CodSeguridad, "NCS") 'Lo exportamos a PDF aqui para que aparesca como original
            'End If


            cryRpt.Close()

            cryRpt = Nothing
            'MiConexion = Nothing
            'myTables = Nothing
            parametros = Nothing
            pd = Nothing
            impresora_predeterminada = Nothing
            Me.Close()
        Catch ex As Exception
            'VariablesGlobales.Obj_Log.Log("ERROR Imprimir_NCS [" & ex.Message & " ]", "NCS")
            ' VariablesGlobales.Obj_TestFactura.Lb_Info_NC.Text = "ERROR EN frmReporte Imprimir_NC [" & ex.Message & " ] Clave [ " & VariablesGlobales.ReporteNC_Clave & " ]"

            ' MessageBox.Show("ERROR EN frmReporte Imprimir_NC [" & ex.Message & " ] Clave [ " & VariablesGlobales.ReporteNC_Clave & " ]")

            Dim obj_Fecha As New FechaManager
            'Se guarda el encabezado del comprobante con la fecha y hora del estado
            Obj_Funciones.GuardaComprobanteEnBitacora("NCS", CodSeguridad, "ERROR", obj_Fecha.FormatoFechaSql(Date.Now), "El en Imprimir_NCS [" & ex.Message & " ] No se genero ni imprimio la representacion grafica", DateTime.Now.ToString("hh:mm"))
            obj_Fecha = Nothing
            Obj_Funciones = Nothing
            'tr_Print.Abort()

            'If File.Exists(VariablesGlobales.Patch_NC & " \" & VariablesGlobales.ReporteNCS_CodSeguridad & "\" & VariablesGlobales.ReporteNC_CodSeguridad & ".pdf") = False Then
            '    VariablesGlobales.Obj_TestFactura.List_NCS.Items.Insert(0, "ERROR EN frmReporte Imprimir_NCS [" & ex.Message & " ] Clave [ " & VariablesGlobales.ReporteNCS_Clave & " ]" & " [ " & Now.Date & "]")
            '    Imprimir_NCS()
            'Else
            '    Me.Close()
            'End If
        End Try
    End Function

    Public Function Imprimir_ND(CodSeguridad As String)
        Dim Obj_Funciones As New Class_funcionesSQL
        ' Dim obj_SAP As New SAP
        Dim impresora_predeterminada As String
        Try
            'Genera la imagen con el codigo QR
            Obj_QR = New QR_CODE
            Obj_QR.Generar(VariablesGlobales.Patch_ND, CodSeguridad, "ND")

            CheckForIllegalCrossThreadCalls = False
            Dim cryRpt As HojaCarta_ND
            cryRpt = New HojaCarta_ND
            Dim MiConexion As New CrystalDecisions.Shared.ConnectionInfo
            Dim myTables As CrystalDecisions.CrystalReports.Engine.Tables = cryRpt.Database.Tables
            Dim parametros As Integer = 0
            'cryRpt.Refresh()

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

            cryRpt.SetParameterValue(0, VariablesGlobales.Patch_ND & "\" & CodSeguridad & "\" & CodSeguridad & ".png")
            cryRpt.SetParameterValue(1, CodSeguridad)



            parametros += 1


            'Dim pd As New PrintDocument
            ''Se define el print Document.
            'If VariablesGlobales.PRINT_ND <> "" Then
            '    impresora_predeterminada = Trim(VariablesGlobales.PRINT_ND)
            'Else
            '    impresora_predeterminada = pd.PrinterSettings.PrinterName
            'End If
            'cryRpt.PrintOptions.PrinterName = impresora_predeterminada


            '''******** Verificamos que la impresora esta activa si no lo esta no imprime para evitar caidas del sistema**********
            'Dim ObjPrinter As New Printer
            'If ObjPrinter.Estado(impresora_predeterminada) = False Then
            '    VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_ND.Checked = False
            '    VariablesGlobales.Obj_TestFactura.List_ND.Items.Insert(0, "VERIFIQUE LA IMPRESORA Clave [ " & VariablesGlobales.ReporteND_Clave & " ]" & " [ " & Now.Date & "]")
            '    VariablesGlobales.Obj_Log.Log("ERROR Imprimir_ND VERIFIQUE LA IMPRESORA Clave [ " & VariablesGlobales.ReporteND_Clave & " ]", "ND")
            'Else
            '    VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_ND.Checked = True
            '    VariablesGlobales.Obj_Log.Log("IMPRESORA DISPONIBLE INTERNO [ " & VariablesGlobales.ReporteND_CodSeguridad & " ]", "ND")
            'End If
            'ObjPrinter = Nothing
            '''******** Verificamos que la impresora esta activa si no lo esta no imprime para evitar caidas del sistema**********

            ''Si esta autorizado el imprimir y si no se ha impreso se manda a imprimir
            'If VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_ND.Checked = True And Obj_Funciones.ObtieneEstadoImpresion(Trim(VariablesGlobales.ReporteND_CodSeguridad), "ND") = False Then

            '    VariablesGlobales.Obj_Log.Log("Envio A Imprimir_ND [" & VariablesGlobales.ReporteND_CodSeguridad & "]  Copias( " & Trim(VariablesGlobales.Obj_TestFactura.txtb_NDCopias.Text) & " ) ", "ND")
            '    cryRpt.PrintToPrinter(1, False, 0, 0) 'imprime 1 copia   
            '    ExportToPDF_ND(cryRpt, VariablesGlobales.ReporteND_CodSeguridad, "ND")
            '    obj_SAP.ActualizaEstadoPrintFESAP(Obj_Funciones.ObtieneDocEntryComprobante(CInt(Trim(VariablesGlobales.ReporteND_CodSeguridad)), "ND"), "ND")


            '    'IMPRIME COPIAS, Resta las copias menos 1(ORIGINAL) y esto sacara la cantidad de copias faltantes 
            '    If (CInt(Trim(VariablesGlobales.Obj_TestFactura.txtb_NDCopias.Text)) - 1) > 0 Then

            '        '********************************************** RECARGAR REPORTE PARA IMPRIMIR COPIAS***************************
            '        cryRpt.Refresh()
            '        MiConexion = New CrystalDecisions.Shared.ConnectionInfo
            '        myTables = cryRpt.Database.Tables
            '        cryRpt.SetDatabaseLogon(VariablesGlobales.XMLParamSQL_user, VariablesGlobales.XMLParamSQL_clave, VariablesGlobales.XMLParamSQL_server, VariablesGlobales.XMLParamSAP_DB, False)
            '        MiConexion.ServerName = VariablesGlobales.XMLParamSQL_server
            '        MiConexion.DatabaseName = VariablesGlobales.XMLParamSAP_CompanyDB
            '        MiConexion.UserID = VariablesGlobales.XMLParamSQL_user
            '        MiConexion.Password = VariablesGlobales.XMLParamSQL_clave
            '        For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
            '            Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
            '            myTableLogonInfo.ConnectionInfo = MiConexion
            '            myTable.ApplyLogOnInfo(myTableLogonInfo)
            '        Next
            '        cryRpt.SetParameterValue(0, VariablesGlobales.Patch_ND & "\" & VariablesGlobales.ReporteND_CodSeguridad & "\" & VariablesGlobales.ReporteND_CodSeguridad & ".png")
            '        cryRpt.SetParameterValue(1, VariablesGlobales.ReporteND_Consecutivo)
            '        '***************************************************************************************************************
            '        VariablesGlobales.Obj_Log.Log("Manda imprimir Copias [" & VariablesGlobales.ReporteND_CodSeguridad & "] Copias " & CInt(Trim(VariablesGlobales.Obj_TestFactura.txtb_NDCopias.Text)) - 1, "ND")
            '        cryRpt.PrintToPrinter((CInt(Trim(VariablesGlobales.Obj_TestFactura.txtb_NDCopias.Text)) - 1), False, 0, 0) 'imprime Copias 
            '    End If

            '    VariablesGlobales.Obj_Log.Log("Cambio estado a impreso [" & VariablesGlobales.ReporteND_CodSeguridad & "]", "ND")
            '    'Cambiamos el estado a impreso, para saber si ya fue mandado a imprimir
            '    Obj_Funciones.ActualizaEstadoImpresion(Trim(VariablesGlobales.ReporteND_CodSeguridad), "ND")


            'ElseIf VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_ND.Checked = False Then
            ExportToPDF_ND(cryRpt, CodSeguridad, "ND") 'Lo exportamos a PDF aqui para que aparesca como original
            'End If

            cryRpt.Close()

            cryRpt = Nothing
            'MiConexion = Nothing
            'myTables = Nothing
            parametros = Nothing
            'pd = Nothing
            impresora_predeterminada = Nothing
            Me.Close()
        Catch ex As Exception
            'VariablesGlobales.Obj_Log.Log("ERROR Imprimir_ND [" & ex.Message & " ]", "ND")
            ' VariablesGlobales.Obj_TestFactura.Lb_Info_NC.Text = "ERROR EN frmReporte Imprimir_NC [" & ex.Message & " ] Clave [ " & VariablesGlobales.ReporteNC_Clave & " ]"

            ' MessageBox.Show("ERROR EN frmReporte Imprimir_NC [" & ex.Message & " ] Clave [ " & VariablesGlobales.ReporteNC_Clave & " ]")

            Dim obj_Fecha As New FechaManager
            'Se guarda el encabezado del comprobante con la fecha y hora del estado
            Obj_Funciones.GuardaComprobanteEnBitacora("ND", CodSeguridad, "ERROR", obj_Fecha.FormatoFechaSql(Date.Now), "El en Imprimir_ND [" & ex.Message & " ] No se genero ni imprimio la representacion grafica", DateTime.Now.ToString("hh:mm"))
            obj_Fecha = Nothing
            Obj_Funciones = Nothing
            'tr_Print.Abort()

            'If File.Exists(VariablesGlobales.Patch_ND & " \" & VariablesGlobales.ReporteND_CodSeguridad & "\" & VariablesGlobales.ReporteND_CodSeguridad & ".pdf") = False Then
            '    VariablesGlobales.Obj_TestFactura.List_ND.Items.Insert(0, "ERROR EN frmReporte Imprimir_ND [" & ex.Message & " ] Clave [ " & VariablesGlobales.ReporteND_Clave & " ]" & " [ " & Now.Date & "]")
            '    Imprimir_ND()
            'Else
            '    Me.Close()
            'End If
        End Try
    End Function

    Public Function Imprimir_NDS(CodSeguridad As String)
        Dim Obj_Funciones As New Class_funcionesSQL
        Dim impresora_predeterminada As String
        ' Dim obj_SAP As New SAP
        Try
            'Genera la imagen con el codigo QR
            Obj_QR = New QR_CODE
            Obj_QR.Generar(VariablesGlobales.Patch_ND, CodSeguridad, "NDS")

            CheckForIllegalCrossThreadCalls = False
            Dim cryRpt As HojaCarta_NDS
            cryRpt = New HojaCarta_NDS
            Dim MiConexion As New CrystalDecisions.Shared.ConnectionInfo
            Dim myTables As CrystalDecisions.CrystalReports.Engine.Tables = cryRpt.Database.Tables
            Dim parametros As Integer = 0

            'cryRpt.Refresh()

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

            cryRpt.SetParameterValue(0, VariablesGlobales.Patch_ND & "\" & CodSeguridad & "\" & CodSeguridad & ".png")
            cryRpt.SetParameterValue(1, CodSeguridad)
            parametros += 1


            'Dim pd As New PrintDocument
            ''Se define el print Document.
            'If VariablesGlobales.PRINT_NDS <> "" Then
            '    impresora_predeterminada = Trim(VariablesGlobales.PRINT_NDS)
            'Else
            '    impresora_predeterminada = pd.PrinterSettings.PrinterName
            'End If

            'cryRpt.PrintOptions.PrinterName = impresora_predeterminada

            '''******** Verificamos que la impresora esta activa si no lo esta no imprime para evitar caidas del sistema**********
            ''Dim ObjPrinter As New Printer
            ''If ObjPrinter.Estado(impresora_predeterminada) = False Then
            ''    VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_NDS.Checked = False
            ''    VariablesGlobales.Obj_TestFactura.List_NDS.Items.Insert(0, "VERIFIQUE LA IMPRESORA Clave [ " & VariablesGlobales.ReporteNDS_Clave & " ]" & " [ " & Now.Date & "]")
            ''    VariablesGlobales.Obj_Log.Log("ERROR Imprimir_NDS VERIFIQUE LA IMPRESORA Clave [ " & VariablesGlobales.ReporteNDS_Clave & " ]", "NDS")
            ''Else
            ''    VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_NDS.Checked = True
            ''End If
            ''ObjPrinter = Nothing
            '''******** Verificamos que la impresora esta activa si no lo esta no imprime para evitar caidas del sistema**********

            'If VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_NDS.Checked = True And Obj_Funciones.ObtieneEstadoImpresion(Trim(VariablesGlobales.ReporteNDS_CodSeguridad), "NDS") = False Then

            '    VariablesGlobales.Obj_Log.Log("Envio A Imprimir_NDS [" & VariablesGlobales.ReporteNDS_CodSeguridad & "]  Copias( " & Trim(VariablesGlobales.Obj_TestFactura.txtb_NDSCopias.Text) & " ) ", "NDS")
            '    cryRpt.PrintToPrinter(1, False, 0, 0) 'imprime 1 copia 
            '    ExportToPDF_ND(cryRpt, VariablesGlobales.ReporteNDS_CodSeguridad, "NDS")
            '    obj_SAP.ActualizaEstadoPrintFESAP(Obj_Funciones.ObtieneDocEntryComprobante(CInt(Trim(VariablesGlobales.ReporteNDS_CodSeguridad)), "NDS"), "NDS")


            '    'IMPRIME COPIAS, Resta las copias menos 1(ORIGINAL) y esto sacara la cantidad de copias faltantes 
            '    If (CInt(Trim(VariablesGlobales.Obj_TestFactura.txtb_NDSCopias.Text)) - 1) > 0 Then

            '        '*********************************** RECARGAR INFORME PARA IMPRIMIR COPIAS **********************
            '        cryRpt.Refresh()
            '        MiConexion = New CrystalDecisions.Shared.ConnectionInfo
            '        myTables = cryRpt.Database.Tables
            '        cryRpt.SetDatabaseLogon(VariablesGlobales.XMLParamSQL_user, VariablesGlobales.XMLParamSQL_clave, VariablesGlobales.XMLParamSQL_server, VariablesGlobales.XMLParamSAP_DB, False)
            '        MiConexion.ServerName = VariablesGlobales.XMLParamSQL_server
            '        MiConexion.DatabaseName = VariablesGlobales.XMLParamSAP_CompanyDB
            '        MiConexion.UserID = VariablesGlobales.XMLParamSQL_user
            '        MiConexion.Password = VariablesGlobales.XMLParamSQL_clave
            '        For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
            '            Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
            '            myTableLogonInfo.ConnectionInfo = MiConexion
            '            myTable.ApplyLogOnInfo(myTableLogonInfo)
            '        Next
            '        cryRpt.SetParameterValue(0, VariablesGlobales.Patch_ND & "\" & VariablesGlobales.ReporteNDS_CodSeguridad & "\" & VariablesGlobales.ReporteNDS_CodSeguridad & ".png")
            '        cryRpt.SetParameterValue(1, VariablesGlobales.ReporteNDS_Consecutivo)
            '        '************************************************************************************************
            '        VariablesGlobales.Obj_Log.Log("Manda imprimir Copias [" & VariablesGlobales.ReporteNDS_CodSeguridad & "] Copias " & CInt(Trim(VariablesGlobales.Obj_TestFactura.txtb_NDSCopias.Text)) - 1, "NDS")
            '        cryRpt.PrintToPrinter((CInt(Trim(VariablesGlobales.Obj_TestFactura.txtb_NDSCopias.Text)) - 1), False, 0, 0) 'imprime Copias 
            '    End If

            '    VariablesGlobales.Obj_Log.Log("Cambio estado a impreso [" & VariablesGlobales.ReporteNDS_CodSeguridad & "]", "NDS")
            '    'Cambiamos el estado a impreso, para saber si ya fue mandado a imprimir
            '    Obj_Funciones.ActualizaEstadoImpresion(Trim(VariablesGlobales.ReporteNDS_CodSeguridad), "NDS")
            'ElseIf VariablesGlobales.Obj_TestFactura.Chebx_Imprimir_NDS.Checked = False Then
            ExportToPDF_ND(cryRpt, CodSeguridad, "NDS") 'Lo exportamos a PDF aqui para que aparesca como original
            'End If


            cryRpt.Close()

            cryRpt = Nothing
            'MiConexion = Nothing
            'myTables = Nothing
            parametros = Nothing
            'pd = Nothing
            impresora_predeterminada = Nothing
            Me.Close()
        Catch ex As Exception
            'VariablesGlobales.Obj_Log.Log("ERROR Imprimir_NDS [" & ex.Message & " ]", "NDS")
            ' VariablesGlobales.Obj_TestFactura.Lb_Info_NC.Text = "ERROR EN frmReporte Imprimir_NC [" & ex.Message & " ] Clave [ " & VariablesGlobales.ReporteNC_Clave & " ]"

            ' MessageBox.Show("ERROR EN frmReporte Imprimir_NC [" & ex.Message & " ] Clave [ " & VariablesGlobales.ReporteNC_Clave & " ]")

            Dim obj_Fecha As New FechaManager
            'Se guarda el encabezado del comprobante con la fecha y hora del estado
            Obj_Funciones.GuardaComprobanteEnBitacora("NDS", CodSeguridad, "ERROR", obj_Fecha.FormatoFechaSql(Date.Now), "El en Imprimir_NDS [" & ex.Message & " ] No se genero ni imprimio la representacion grafica", DateTime.Now.ToString("hh:mm"))
            obj_Fecha = Nothing
            Obj_Funciones = Nothing
            'tr_Print.Abort()

            'If File.Exists(VariablesGlobales.Patch_ND & " \" & VariablesGlobales.ReporteNDS_CodSeguridad & "\" & VariablesGlobales.ReporteNDS_CodSeguridad & ".pdf") = False Then
            '    'VariablesGlobales.Obj_TestFactura.List_NDS.Items.Insert(0, "ERROR EN frmReporte Imprimir_NDS [" & ex.Message & " ] Clave [ " & VariablesGlobales.ReporteNDS_Clave & " ]" & " [ " & Now.Date & "]")
            '    Imprimir_NDS()
            'Else
            '    Me.Close()
            'End If
        End Try
    End Function


#Region "EXPORTAR A PDF"
    Public Shared Function ExportToPDF_FE(ByVal rpt As ReportDocument, ByVal Clave As String, ByVal Tipo As String) As String
        Dim vFileName As String = Nothing
        Dim diskOpts As New DiskFileDestinationOptions()
        Dim Path As String
        Try


            If Tipo = "FE" Or Tipo = "FES" Then
                Path = VariablesGlobales.Patch_FE
            End If

            If Tipo = "NC" Or Tipo = "NCS" Then
                Path = VariablesGlobales.Patch_NC
            End If

            If Tipo = "ND" Or Tipo = "NDS" Then
                Path = VariablesGlobales.Patch_ND
            End If

            If Tipo = "TE" Then
                Path = VariablesGlobales.Patch_TE
            End If

            If Not Path.EndsWith("\") Then
                Path += "\"
            End If


            MessageBox.Show("ExportToPDF_FE - " & Path & "  ,  " & Clave, "ExportToPDF_FE", MessageBoxButtons.OK, MessageBoxIcon.Information)

            rpt.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
            rpt.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

            'Este es la ruta donde se guardara tu archivo.
            If File.Exists(Path & Clave) = False Then
                My.Computer.FileSystem.CreateDirectory(Path & Clave)
            End If

            vFileName = Path & Clave & "\" & Clave & ".pdf"

            If File.Exists(vFileName) Then
                File.Delete(vFileName)
            End If

            diskOpts.DiskFileName = vFileName
            rpt.ExportOptions.DestinationOptions = diskOpts
            rpt.Export()

            '--------------- LIBERAMOS MEMORIAS-----------------
            vFileName = Nothing
            diskOpts = Nothing
            Path = Nothing

            'VariablesGlobales.Obj_Log.Log("ExportToPDF_FE [" & Clave & " ]", "FE")
        Catch ex As Exception
            'VariablesGlobales.Obj_Log.Log("ERROR ExportToPDF_FE [" & ex.Message & " ]", "FE")

            If File.Exists(vFileName) = False Then
                'VariablesGlobales.Obj_TestFactura.List_FE.Items.Insert(0, "ERROR EN ExportToPDF_FE [" & ex.Message & " ] Clave [ " & Clave & " ] [ " & Now.Date & "]")
                vFileName = Nothing
                diskOpts = Nothing
                Path = Nothing
                ExportToPDF_FE(rpt, Clave, Tipo)
            End If
            vFileName = Nothing
            diskOpts = Nothing
            Path = Nothing
            MessageBox.Show("ERROR EN ExportToPDF_FE [" & ex.Message & " ] Clave [ " & Clave & " ]")

        End Try

        Return vFileName
    End Function
    Public Shared Function ExportToPDF_FES(ByVal rpt As ReportDocument, ByVal Clave As String, ByVal Tipo As String) As String
        Dim vFileName As String = Nothing
        Dim diskOpts As New DiskFileDestinationOptions()
        Dim Path As String
        Try
            MessageBox.Show("ExportToPDF_FES ", "RUTA", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If Tipo = "FE" Or Tipo = "FES" Then
                Path = VariablesGlobales.Patch_FE
            End If

            If Tipo = "NC" Or Tipo = "NCS" Then
                Path = VariablesGlobales.Patch_NC
            End If

            If Tipo = "ND" Or Tipo = "NDS" Then
                Path = VariablesGlobales.Patch_ND
            End If

            If Tipo = "TE" Then
                Path = VariablesGlobales.Patch_TE
            End If

            If Not Path.EndsWith("\") Then
                Path += "\"
            End If



            rpt.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
            rpt.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

            'Este es la ruta donde se guardara tu archivo.
            If File.Exists(Path & Clave) = False Then
                My.Computer.FileSystem.CreateDirectory(Path & Clave)
            End If

            vFileName = Path & Clave & "\" & Clave & ".pdf"

            If File.Exists(vFileName) Then
                File.Delete(vFileName)
            End If

            diskOpts.DiskFileName = vFileName
            rpt.ExportOptions.DestinationOptions = diskOpts
            rpt.Export()

            '--------------- LIBERAMOS MEMORIAS-----------------
            vFileName = Nothing
            diskOpts = Nothing
            Path = Nothing

            ' VariablesGlobales.Obj_Log.Log("ExportToPDF_FES [" & Clave & " ]", "FES")
        Catch ex As Exception
            ' VariablesGlobales.Obj_Log.Log("ERROR ExportToPDF_FES [" & ex.Message & " ]", "FES")

            If File.Exists(vFileName) = False Then
                'VariablesGlobales.Obj_TestFactura.List_FES.Items.Insert(0, "ERROR EN ExportToPDF_FES [" & ex.Message & " ] Clave [ " & Clave & " ] [ " & Now.Date & "]")
                vFileName = Nothing
                diskOpts = Nothing
                Path = Nothing
                ExportToPDF_FES(rpt, Clave, Tipo)
            End If
            vFileName = Nothing
            diskOpts = Nothing
            Path = Nothing
            'MessageBox.Show("ERROR EN ExportToPDF_FE [" & ex.Message & " ] Clave [ " & Clave & " ]")

        End Try

        Return vFileName
    End Function
    Public Shared Function ExportToPDF_NC(rpt As ReportDocument, Clave As String, Tipo As String) As String
        Dim vFileName As String = Nothing
        Dim diskOpts As New DiskFileDestinationOptions()
        Dim Path As String
        Try


            If Tipo = "FE" Or Tipo = "FES" Then
                Path = VariablesGlobales.Patch_FE
            End If

            If Tipo = "NC" Or Tipo = "NCS" Then
                Path = VariablesGlobales.Patch_NC
            End If

            If Tipo = "ND" Or Tipo = "NDS" Then
                Path = VariablesGlobales.Patch_ND
            End If

            If Tipo = "TE" Then
                Path = VariablesGlobales.Patch_TE
            End If

            If Not Path.EndsWith("\") Then
                Path += "\"
            End If



            rpt.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
            rpt.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

            'Este es la ruta donde se guardara tu archivo.
            If File.Exists(Path & Clave) = False Then
                My.Computer.FileSystem.CreateDirectory(Path & Clave)
            End If

            vFileName = Path & Clave & "\" & Clave & ".pdf"

            If File.Exists(vFileName) Then
                File.Delete(vFileName)
            End If

            diskOpts.DiskFileName = vFileName
            rpt.ExportOptions.DestinationOptions = diskOpts
            rpt.Export()

            '--------------- LIBERAMOS MEMORIAS-----------------
            vFileName = Nothing
            diskOpts = Nothing
            Path = Nothing


        Catch ex As Exception
            'VariablesGlobales.Obj_Log.Log("ERROR ExportToPDF_NC [" & ex.Message & " ]", "NC")
            ' MessageBox.Show("ERROR EN ExportToPDF_NC [" & ex.Message & " ] Clave [ " & Clave & " ]")

            If File.Exists(vFileName) = False Then

                'VariablesGlobales.Obj_TestFactura.List_NC.Items.Insert(0, "ERROR EN ExportToPDF_NC [" & ex.Message & " ] Clave [ " & Clave & " ] [ " & Now.Date & "]")
                ExportToPDF_NC(rpt, Clave, Tipo)
            End If

            vFileName = Nothing
            diskOpts = Nothing
            Path = Nothing

        End Try

        Return vFileName
    End Function
    Public Shared Function ExportToPDF_NCS(rpt As ReportDocument, Clave As String, Tipo As String) As String
        Dim vFileName As String = Nothing
        Dim diskOpts As New DiskFileDestinationOptions()
        Dim Path As String
        Try


            If Tipo = "FE" Or Tipo = "FES" Then
                Path = VariablesGlobales.Patch_FE
            End If

            If Tipo = "NC" Or Tipo = "NCS" Then
                Path = VariablesGlobales.Patch_NC
            End If

            If Tipo = "ND" Or Tipo = "NDS" Then
                Path = VariablesGlobales.Patch_ND
            End If

            If Tipo = "TE" Then
                Path = VariablesGlobales.Patch_TE
            End If

            If Not Path.EndsWith("\") Then
                Path += "\"
            End If



            rpt.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
            rpt.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

            'Este es la ruta donde se guardara tu archivo.
            If File.Exists(Path & Clave) = False Then
                My.Computer.FileSystem.CreateDirectory(Path & Clave)
            End If

            vFileName = Path & Clave & "\" & Clave & ".pdf"

            If File.Exists(vFileName) Then
                File.Delete(vFileName)
            End If

            diskOpts.DiskFileName = vFileName
            rpt.ExportOptions.DestinationOptions = diskOpts
            rpt.Export()

            '--------------- LIBERAMOS MEMORIAS-----------------
            vFileName = Nothing
            diskOpts = Nothing
            Path = Nothing


        Catch ex As Exception
            'VariablesGlobales.Obj_Log.Log("ERROR ExportToPDF_NCS [" & ex.Message & " ]", "NCS")
            ' MessageBox.Show("ERROR EN ExportToPDF_NC [" & ex.Message & " ] Clave [ " & Clave & " ]")

            If File.Exists(vFileName) = False Then

                'VariablesGlobales.Obj_TestFactura.List_NC.Items.Insert(0, "ERROR EN ExportToPDF_NCS [" & ex.Message & " ] Clave [ " & Clave & " ] [ " & Now.Date & "]")
                ExportToPDF_NCS(rpt, Clave, Tipo)
            End If

            vFileName = Nothing
            diskOpts = Nothing
            Path = Nothing

        End Try

        Return vFileName
    End Function
    Public Shared Function ExportToPDF_ND(rpt As ReportDocument, Clave As String, Tipo As String) As String
        Dim vFileName As String = Nothing
        Dim diskOpts As New DiskFileDestinationOptions()
        Dim Path As String
        Try

            If Tipo = "FE" Or Tipo = "FES" Then
                Path = VariablesGlobales.Patch_FE
            End If

            If Tipo = "NC" Or Tipo = "NCS" Then
                Path = VariablesGlobales.Patch_NC
            End If

            If Tipo = "ND" Or Tipo = "NDS" Then
                Path = VariablesGlobales.Patch_ND
            End If

            If Tipo = "TE" Then
                Path = VariablesGlobales.Patch_TE
            End If

            If Not Path.EndsWith("\") Then
                Path += "\"
            End If



            rpt.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
            rpt.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

            'Este es la ruta donde se guardara tu archivo.
            If File.Exists(Path & Clave) = False Then
                My.Computer.FileSystem.CreateDirectory(Path & Clave)
            End If

            vFileName = Path & Clave & "\" & Clave & ".pdf"

            If File.Exists(vFileName) Then
                File.Delete(vFileName)
            End If

            diskOpts.DiskFileName = vFileName
            rpt.ExportOptions.DestinationOptions = diskOpts
            rpt.Export()

            '--------------- LIBERAMOS MEMORIAS-----------------
            vFileName = Nothing
            diskOpts = Nothing
            Path = Nothing


        Catch ex As Exception
            'VariablesGlobales.Obj_Log.Log("ERROR ExportToPDF_ND [" & ex.Message & " ]", "ND")
            If File.Exists(vFileName) = False Then

                'VariablesGlobales.Obj_TestFactura.List_ND.Items.Insert(0, "ERROR EN ExportToPDF_ND [" & ex.Message & " ] Clave [ " & Clave & " ] [ " & Now.Date & "]")
                ExportToPDF_ND(rpt, Clave, Tipo)
            End If
            vFileName = Nothing
            diskOpts = Nothing
            Path = Nothing

        End Try

        Return vFileName
    End Function

    Public Shared Function ExportToPDF_NDS(rpt As ReportDocument, Clave As String, Tipo As String) As String
        Dim vFileName As String = Nothing
        Dim diskOpts As New DiskFileDestinationOptions()
        Dim Path As String
        Try


            If Tipo = "FE" Or Tipo = "FES" Then
                Path = VariablesGlobales.Patch_FE
            End If

            If Tipo = "NC" Or Tipo = "NCS" Then
                Path = VariablesGlobales.Patch_NC
            End If

            If Tipo = "ND" Or Tipo = "NDS" Then
                Path = VariablesGlobales.Patch_ND
            End If

            If Tipo = "TE" Then
                Path = VariablesGlobales.Patch_TE
            End If

            If Not Path.EndsWith("\") Then
                Path += "\"
            End If



            rpt.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
            rpt.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

            'Este es la ruta donde se guardara tu archivo.
            If File.Exists(Path & Clave) = False Then
                My.Computer.FileSystem.CreateDirectory(Path & Clave)
            End If

            vFileName = Path & Clave & "\" & Clave & ".pdf"

            If File.Exists(vFileName) Then
                File.Delete(vFileName)
            End If

            diskOpts.DiskFileName = vFileName
            rpt.ExportOptions.DestinationOptions = diskOpts
            rpt.Export()

            '--------------- LIBERAMOS MEMORIAS-----------------
            vFileName = Nothing
            diskOpts = Nothing
            Path = Nothing


        Catch ex As Exception
            ' VariablesGlobales.Obj_Log.Log("ERROR ExportToPDF_NDS [" & ex.Message & " ]", "NDS")
            If File.Exists(vFileName) = False Then

                'VariablesGlobales.Obj_TestFactura.List_ND.Items.Insert(0, "ERROR EN ExportToPDF_NDS [" & ex.Message & " ] Clave [ " & Clave & " ] [ " & Now.Date & "]")
                ExportToPDF_NDS(rpt, Clave, Tipo)
            End If
            vFileName = Nothing
            diskOpts = Nothing
            Path = Nothing

        End Try

        Return vFileName
    End Function

    Public Shared Function ExportToPDF_TE(rpt As ReportDocument, Clave As String, Tipo As String) As String
        Dim vFileName As String = Nothing
        Dim diskOpts As New DiskFileDestinationOptions()
        Dim Path As String
        Try

            If Tipo = "FE" Or Tipo = "FES" Then
                Path = VariablesGlobales.Patch_FE
            End If

            If Tipo = "NC" Or Tipo = "NCS" Then
                Path = VariablesGlobales.Patch_NC
            End If

            If Tipo = "ND" Or Tipo = "NDS" Then
                Path = VariablesGlobales.Patch_ND
            End If

            If Tipo = "TE" Then
                Path = VariablesGlobales.Patch_TE
            End If

            If Not Path.EndsWith("\") Then
                Path += "\"
            End If

            rpt.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
            rpt.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

            'Este es la ruta donde se guardara tu archivo.
            If File.Exists(Path & Clave) = False Then
                My.Computer.FileSystem.CreateDirectory(Path & Clave)
            End If

            vFileName = Path & Clave & "\" & Clave & ".pdf"

            If File.Exists(vFileName) Then
                File.Delete(vFileName)
            End If

            diskOpts.DiskFileName = vFileName
            rpt.ExportOptions.DestinationOptions = diskOpts
            rpt.Export()

            '--------------- LIBERAMOS MEMORIAS-----------------
            vFileName = Nothing
            diskOpts = Nothing
            Path = Nothing


        Catch ex As Exception
            'VariablesGlobales.Obj_Log.Log("ERROR ExportToPDF_TE [" & ex.Message & " ]", "TE")

            If File.Exists(vFileName) = False Then
                'VariablesGlobales.Obj_TestFactura.List_TE.Items.Insert(0, "ERROR EN ExportToPDF_TE [" & ex.Message & " ] Clave [ " & Clave & " ] [ " & Now.Date & "]")
                ExportToPDF_TE(rpt, Clave, Tipo)
            End If
            vFileName = Nothing
            diskOpts = Nothing
            Path = Nothing
        End Try

        Return vFileName
    End Function

#End Region





End Class