Imports System.Data.SqlClient
Imports System.Data.Odbc

Public Module Variables

    'Public MisPropiedades As New Propiedades("", Admin_Depositos_Agentes)




    'Public Obj_SQL_CONEXION_CONEXION As New CONEXION_TO_SQLSERVER
    'Public Obj_Funciones_SQL As New Class_funcionesSQL


    'Public SQL_Comman1 As New SqlCommand

    'Public SQL_Comman, SQL_Comman2 As New SqlCommand




    




    ''Public Obj_Funciones_SQL As New Class_funcionesSQL
    ''Public Obj_SQL_CONEXION As New CONEXION_TO_SQLSERVER
    ''Public Obj_LiqAgentes As New Liquidacion_Agentes
    ''Public Obj_LiqAgentes As New Liquidacion_Agentes
    ''Public Obj_Creaarchivo As New CrearArchivo
    ''Public obj_FTP As New Class_FTP
    ''Public Obj_RepDCar As New ReportesDeCarga
    ''Public Obj_MAIL As New Class_MAIL
    ''Public Obj_Sonar As New Class_Sonar
    ''Public Obj_SQL_CONEXION As New CONEXION_TO_SQLSERVER
    ''Public Obj_Funciones_SQL As New Class_funcionesSQL
    ''Public Obj_Funciones_SQL As New Class_funcionesSQL


    ''Public CodAgente As Integer = 2
    ''Public backuoAgeEje As String
    ''Public UserBod As String
    ''Public CodArti As String
    ''Public ConseRepCarga As String
    ''Public IDRepDev As String
    ''Public Puesto As String
    ''Public Usuario As String
    ''Public TituloDetalleGasto As String
    ''Public Tbl_RepCarga As New DataTable
    ''Public Conse_Repcarga As String

    ''Public Excepcion As Boolean = False
    ''Public SQL_Comman, SQL_Comman2 As New SqlCommand

    ''Public oCompany As New SAPbobsCOM.Company


    ''Public LiquiAgente_ConseLiq As String
    ''Public LiquiAgente_FechaIni As String
    ''Public LiquiAgente_FechaFin As String
    ''Public LiquiAgente_CodAgente As String

    ''PARAMATROS DE CONEXION PROVENIENTES DE XML

    ' ''PARAMETROS LICENCIA SINCRO SERVER
    ''Public XML_LicenciaSincroServer
    ''Public XML_LicenciaUserServer
    ''Public XML_LicenciaPastwordServer

    ' ''PARAMETROS LICENCIA SINCRO CLIENTE
    ''Public XML_LicenciaSincroCliente
    ''Public XML_LicenciaUserCliente
    ''Public XML_LicenciaPastwordCliente


    ' ''PARAMETROS SAP
    ''Public XMLParamSAP_CompanyDB
    ''Public XMLParamSAP_Password
    ''Public XMLParamSAP_UserName
    ''Public XMLParamSAP_Server
    ''Public XMLParamSAP_DbUserName
    ''Public XMLParamSAP_DbPassword
    ''Public XMLParamSAP_LicenseServer
    ' ''PARAMETROS SQL_Sic_Local_Web
    ''Public XMLParamSQL_user
    ''Public XMLParamSQL_clave
    ''Public XMLParamSQL_dababase
    ''Public XMLParamSQL_server
    ' ''PARAMETROS FIREBIRD
    ''Public XMLParamFIREBIRD_Dsn
    ' ''PARAMETROS MYSQL
    ''Public XMLParamMYSQL_Server
    ''Public XMLParamMYSQL_MyDatabase
    ''Public XMLParamMYSQL_myport
    ''Public XMLParamMYSQL_userWEB
    ''Public XMLParamMYSQL_claveWEB
    ''Public XMLParamMYSQL_DsnWEB
    ' ''PARAMETROS FTP
    ''Public XMLParamFTP_Server
    ''Public XMLParamFTP_user
    ''Public XMLParamFTP_Password
    ''Public XMLParamFTP_dirLocal



    ''Public SQL_Comman1 As New SqlCommand


    ''Public Obj_SQL_CONEXION_CONEXION As New CONEXION_TO_SQLSERVER

    ''Public frmLiqAge As Liquidacion_Agentes
    ''Public frmDetGastos As Detalle_Gastos
    ''Public frmDeposAs As Admin_Depositos
    ''Public NumLiqui As String
    ''Public TipoLiqui As String
    ''Public Agente As String


    ''Public FechaIni As String
    ''Public FechaFin As String





    ''Public Lista_llamadaDesde As String

    ''Public Obj_Admin_Bodegueros As New Admin_Bodegueros

    'Public Obj_Clas_XML As New Class_XML_Conexion
    'Public Obj_Fecha As New FechaManager
    ''PARAMATROS DE CONEXION PROVENIENTES DE XML

    ''PARAMETROS LICENCIA SINCRO SERVER
    'Public XML_LicenciaSincroServer
    'Public XML_LicenciaUserServer
    'Public XML_LicenciaPastwordServer

    ''PARAMETROS LICENCIA SINCRO CLIENTE
    'Public XML_LicenciaSincroCliente
    'Public XML_LicenciaUserCliente
    'Public XML_LicenciaPastwordCliente


    ''PARAMETROS SAP
    'Public XMLParamSAP_CompanyDB
    'Public XMLParamSAP_Password
    'Public XMLParamSAP_UserName
    'Public XMLParamSAP_Server
    'Public XMLParamSAP_DbUserName
    'Public XMLParamSAP_DbPassword
    'Public XMLParamSAP_LicenseServer
    ''PARAMETROS SQL_Sic_Local_Web
    'Public XMLParamSQL_user
    'Public XMLParamSQL_clave
    'Public XMLParamSQL_dababase
    'Public XMLParamSQL_server
    ''PARAMETROS FIREBIRD
    'Public XMLParamFIREBIRD_Dsn
    ''PARAMETROS MYSQL
    'Public XMLParamMYSQL_Server
    'Public XMLParamMYSQL_MyDatabase
    'Public XMLParamMYSQL_myport
    'Public XMLParamMYSQL_userWEB
    'Public XMLParamMYSQL_claveWEB
    'Public XMLParamMYSQL_DsnWEB
    ''PARAMETROS FTP
    'Public XMLParamFTP_Server
    'Public XMLParamFTP_user
    'Public XMLParamFTP_Password
    'Public XMLParamFTP_dirLocal
    ' ''parametros de cuentas
    ''Public XMLParam_CuentaTranferencia
    ''Public XMLParam_CuentaEfectivo
    ''Public XMLParam_CuentaCheque

    ' ''PARAMETROS CUENTAS
    'Public XMLParamCuentas_CashAccount As String
    'Public XMLParamCuentas_TransferAccountt As String
    'Public XMLParamCuentas_BancoPopular As String
    'Public XMLParamCuentas_BancoNacional As String
    'Public XMLParamCuentas_BancoCostaRica As String
    'Public XMLParamCuentas_BancoLaFise As String
    'Public XMLParamCuentas_BancoCoocique As String
    'Public XMLParamCuentas_BancoBCT As String

    'Public XMLParam_CuentaBPCOLONES
    'Public XMLParam_CuentaBNCOLONES
    'Public XMLParam_CuentaBCRCOLONES
    'Public XMLParam_CuentaBFISECOLONES
    'Public XMLParam_CuentaBCTCOLONES
    'Public XMLParam_CuentaBCTDOLAR
    'Public XMLParam_CuentaBINVEDOLAR
    'Public XMLParam_CuentaBPDOLAR



End Module
