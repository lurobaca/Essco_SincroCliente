Imports System.Xml
Imports System.IO

Public Class Class_XML_Conexion

    Public Obj_LicSeguridad As New SeguridadLicencia
    Public Obj_HoraFecha As New FechaManager
    Public Function ConexionSAP()
        'MUY IMPORTANTE SE DEBEN CONFIGURAR LAS CONEXIONES ODBC TANTO EN 32 COMO EN 64 BITS
        'VER EXPLICACIONES http://www.overflowexception.es/2012/01/driver-odbc-32-y-64-bits.html
        'Administrador ODBC de 32 bits en C:\Windows\SysWOW64\odbcad32.exe
        'Administrador ODBC de 64 bits está en C:\Windows\System32\odbcad32.exe

        Try

            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode

            'Dim conectar As String = "C:\ConexionINFO__Pronutre_PRODUCCION.xml"

            'If File.Exists(conectar) <> True Then
            '    conectar = "C:\ConexionINFO__Pronutre_SANDBOX.xml"
            'End If

            'Dim conectar As String = "C:\ConexionINFO_PRODUCCION_esscocr.xml"

            'If File.Exists(conectar) <> True Then
            '    conectar = "C:\ConexionINFO_SANDBOX_esscocr.xml"
            'End If

            Dim conectar As String = "C:\ConexionINFO_BourneProduccion.xml"

            If File.Exists(conectar) <> True Then
                conectar = "C:\ConexionINFO_BourneSANDBOX.xml"
            End If

            If Principal IsNot Nothing Then
                Principal.Text = "SINCRO CLIENTE [20.09.2022] v1 " & "  " & conectar
            End If

            'Creamos el "Document"
            m_xmld = New XmlDocument()

            'Cargamos el archivo
            m_xmld.Load(conectar)
            ' m_xmld.Load("C:\ConexionINFO.xml")

            'Obtenemos la lista de los nodos "name"
            m_nodelist = m_xmld.SelectNodes("/Conexiones/name")

            'Iniciamos el ciclo de lectura
            For Each m_node In m_nodelist
                'Obtenemos el atributo del codigo
                Dim mCodigo = m_node.Attributes.GetNamedItem("codigo").Value

                If mCodigo = "SAP" Then
                    'CONEXION A SAP
                    Class_VariablesGlobales.XMLParamSAP_CompanyDB = m_node.ChildNodes.Item(0).InnerText
                    Class_VariablesGlobales.XMLParamSAP_Password = m_node.ChildNodes.Item(1).InnerText
                    Class_VariablesGlobales.XMLParamSAP_UserName = m_node.ChildNodes.Item(2).InnerText
                    Class_VariablesGlobales.XMLParamSAP_Server = m_node.ChildNodes.Item(3).InnerText
                    Class_VariablesGlobales.XMLParamSAP_DbUserName = m_node.ChildNodes.Item(4).InnerText
                    Class_VariablesGlobales.XMLParamSAP_DbPassword = m_node.ChildNodes.Item(5).InnerText
                    Class_VariablesGlobales.XMLParamSAP_LicenseServer = m_node.ChildNodes.Item(6).InnerText

                End If
                If mCodigo = "SQL_Sic_Local_Web" Then
                    'CONEXION A SQL
                    Class_VariablesGlobales.XMLParamSQL_user = m_node.ChildNodes.Item(0).InnerText
                    Class_VariablesGlobales.XMLParamSQL_clave = m_node.ChildNodes.Item(1).InnerText
                    Class_VariablesGlobales.XMLParamSQL_dababase = m_node.ChildNodes.Item(2).InnerText
                    Class_VariablesGlobales.XMLParamSQL_server = m_node.ChildNodes.Item(3).InnerText


                End If

                If mCodigo = "SQL_FIREBIRD" Then
                    'CONEXION A FIREBIRD"
                    Class_VariablesGlobales.XMLParamFIREBIRD_Dsn = m_node.ChildNodes.Item(0).InnerText
                End If

                If mCodigo = "MYSQL" Then
                    'CONEXION A FIREBIRD"

                    Class_VariablesGlobales.XMLParamMYSQL_Server = m_node.ChildNodes.Item(0).InnerText
                    Class_VariablesGlobales.XMLParamMYSQL_MyDatabase = m_node.ChildNodes.Item(1).InnerText
                    Class_VariablesGlobales.XMLParamMYSQL_myport = m_node.ChildNodes.Item(2).InnerText
                    Class_VariablesGlobales.XMLParamMYSQL_userWEB = m_node.ChildNodes.Item(3).InnerText
                    Class_VariablesGlobales.XMLParamMYSQL_claveWEB = m_node.ChildNodes.Item(4).InnerText
                    Class_VariablesGlobales.XMLParamMYSQL_DsnWEB = m_node.ChildNodes.Item(5).InnerText
                End If
                If mCodigo = "MYSQL_LOCAL" Then
                    'CONEXION A FIREBIRD"


                    Class_VariablesGlobales.XMLParamMYSQL_Server_LOCAL = m_node.ChildNodes.Item(0).InnerText
                    Class_VariablesGlobales.XMLParamMYSQL_MyDatabase_LOCAL = m_node.ChildNodes.Item(1).InnerText
                    Class_VariablesGlobales.XMLParamMYSQL_myport_LOCAL = m_node.ChildNodes.Item(2).InnerText
                    Class_VariablesGlobales.XMLParamMYSQL_userWEB_LOCAL = m_node.ChildNodes.Item(3).InnerText
                    Class_VariablesGlobales.XMLParamMYSQL_claveWEB_LOCAL = m_node.ChildNodes.Item(4).InnerText
                    Class_VariablesGlobales.XMLParamMYSQL_DsnWEB_LOCAL = m_node.ChildNodes.Item(5).InnerText
                End If
                If mCodigo = "FTP" Then
                    'CONEXION A FTP"
                    Class_VariablesGlobales.XMLParamFTP_Server = m_node.ChildNodes.Item(0).InnerText
                    Class_VariablesGlobales.XMLParamFTP_user = m_node.ChildNodes.Item(1).InnerText
                    Class_VariablesGlobales.XMLParamFTP_Password = m_node.ChildNodes.Item(2).InnerText
                    Class_VariablesGlobales.XMLParamFTP_dirLocal = m_node.ChildNodes.Item(3).InnerText
                End If

                If mCodigo = "FTP2" Then
                    'CONEXION A FTP"
                    Class_VariablesGlobales.XMLParamFTP_Server2 = m_node.ChildNodes.Item(0).InnerText
                    Class_VariablesGlobales.XMLParamFTP_user2 = m_node.ChildNodes.Item(1).InnerText
                    Class_VariablesGlobales.XMLParamFTP_Password2 = m_node.ChildNodes.Item(2).InnerText
                    Class_VariablesGlobales.XMLParamFTP_dirLocal2 = m_node.ChildNodes.Item(3).InnerText
                End If

                If mCodigo = "CUENTAS" Then
                    'CUENTAS BANCARIAS"

                    Class_VariablesGlobales.XMLParamCuentas_CashAccount = m_node.ChildNodes.Item(0).InnerText
                    Class_VariablesGlobales.XMLParamCuentas_TransferAccountt = m_node.ChildNodes.Item(1).InnerText
                    Class_VariablesGlobales.XMLParamCuentas_BancoPopular = m_node.ChildNodes.Item(2).InnerText
                    Class_VariablesGlobales.XMLParamCuentas_BancoNacional = m_node.ChildNodes.Item(3).InnerText
                    Class_VariablesGlobales.XMLParamCuentas_BancoCostaRica = m_node.ChildNodes.Item(4).InnerText
                    Class_VariablesGlobales.XMLParamCuentas_BancoLaFise = m_node.ChildNodes.Item(5).InnerText
                    Class_VariablesGlobales.XMLParamCuentas_BancoCoocique = m_node.ChildNodes.Item(6).InnerText
                    Class_VariablesGlobales.XMLParamCuentas_BancoBCT = m_node.ChildNodes.Item(7).InnerText

                End If
                If mCodigo = "HACIENDA" Then
                    VariablesGlobales.Patch_FEC = Trim(m_node.ChildNodes.Item(0).InnerText) 'FEC
                    VariablesGlobales.Patch_FE = Trim(m_node.ChildNodes.Item(1).InnerText) ''FE
                    VariablesGlobales.Patch_NC = Trim(m_node.ChildNodes.Item(2).InnerText) ''NC
                    VariablesGlobales.Patch_ND = Trim(m_node.ChildNodes.Item(3).InnerText) ''ND
                    VariablesGlobales.Patch_TE = Trim(m_node.ChildNodes.Item(4).InnerText) ''TE
                    VariablesGlobales.Patch_MR = Trim(m_node.ChildNodes.Item(5).InnerText) ''MR
                    VariablesGlobales.Patch_Certificado = Trim(m_node.ChildNodes.Item(6).InnerText)
                    VariablesGlobales.ATV_Usuario = Trim(m_node.ChildNodes.Item(7).InnerText)
                    VariablesGlobales.ATV_Password = Trim(m_node.ChildNodes.Item(8).InnerText)
                    VariablesGlobales.Certificado_PIN = Trim(m_node.ChildNodes.Item(9).InnerText)

                    'Info para pruebas o produccion
                    VariablesGlobales.URL_RECEPCION = Trim(m_node.ChildNodes.Item(10).InnerText)
                    'Sirve para obtener Token
                    VariablesGlobales.IDP_CLIENT_ID = Trim(m_node.ChildNodes.Item(11).InnerText)
                    VariablesGlobales.IDP_URI = Trim(m_node.ChildNodes.Item(12).InnerText)

                    VariablesGlobales.PRINT_FE = Trim(m_node.ChildNodes.Item(13).InnerText)
                    VariablesGlobales.PRINT_NC = Trim(m_node.ChildNodes.Item(14).InnerText)
                    VariablesGlobales.PRINT_ND = Trim(m_node.ChildNodes.Item(15).InnerText)

                    VariablesGlobales.PRINT_FES = Trim(m_node.ChildNodes.Item(16).InnerText)
                    VariablesGlobales.PRINT_NCS = Trim(m_node.ChildNodes.Item(17).InnerText)
                    VariablesGlobales.PRINT_NDS = Trim(m_node.ChildNodes.Item(18).InnerText)

                    VariablesGlobales.Patch_PDFMR = Trim(m_node.ChildNodes.Item(19).InnerText)

                    Class_VariablesGlobales.Patch_MR_SinPrcesar = Trim(m_node.ChildNodes.Item(20).InnerText)
                    Class_VariablesGlobales.Patch_MR_Procesadas = Trim(m_node.ChildNodes.Item(21).InnerText)

                    Class_VariablesGlobales.RutaExcellPedidos = Trim(m_node.ChildNodes.Item(22).InnerText)
                    Class_VariablesGlobales.RutaFotosPlanilla = Trim(m_node.ChildNodes.Item(23).InnerText)
                End If

            Next
        Catch ex As Exception
            'Error trapping
            MessageBox.Show("NO SE ENCUENTRA EL ARCHIVO DE PARAMETROS DE CONEXION ,CONTACTESE CON LUIS ROBERTO BASTOS C AL TEL: 88801662 Ó AL CORREO : lurobaca@gmail.com")
            VariablesGlobales.Obj_Log.Log("NO SE ENCUENTRA EL ARCHIVO DE PARAMETROS DE CONEXION ,CONTACTESE CON LUIS ROBERTO BASTOS C AL TEL: 88801662 Ó AL CORREO : lurobaca@gmail.com", "MR")
            Return 1
        End Try
    End Function

    'obtiene la licencia y la guarda para saber hasta que dia tiene habilitado el sotware
    Public Function LectorLicencias()
        'MUY IMPORTANTE SE DEBEN CONFIGURAR LAS CONEXIONES ODBC TANTO EN 32 COMO EN 64 BITS
        'VER EXPLICACIONES http://www.overflowexception.es/2012/01/driver-odbc-32-y-64-bits.html
        'Administrador ODBC de 32 bits en C:\Windows\SysWOW64\odbcad32.exe
        'Administrador ODBC de 64 bits está en C:\Windows\System32\odbcad32.exe

        Try
            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode

            'Creamos el "Document"
            m_xmld = New XmlDocument()

            'Cargamos el archivo
            m_xmld.Load("C:\Licencia.xml")

            'Obtenemos la lista de los nodos "name"
            m_nodelist = m_xmld.SelectNodes("/Licencia/name")

            'Iniciamos el ciclo de lectura
            For Each m_node In m_nodelist
                'Obtenemos el atributo del codigo
                Dim mCodigo = m_node.Attributes.GetNamedItem("codigo").Value

                If mCodigo = "SincroServer" Then
                    'Obtiene la licencia 
                    Class_VariablesGlobales.XML_LicenciaSincroServer = m_node.ChildNodes.Item(0).InnerText
                    'Obtiene el usuario 
                    Class_VariablesGlobales.XML_LicenciaUserServer = m_node.ChildNodes.Item(1).InnerText
                    'Obtiene la contraseña 
                    Class_VariablesGlobales.XML_LicenciaPastwordServer = m_node.ChildNodes.Item(2).InnerText

                End If
                If mCodigo = "SincroCliente" Then
                    'Obtiene la licencia 
                    Class_VariablesGlobales.XML_LicenciaSincroCliente = m_node.ChildNodes.Item(0).InnerText
                    'Obtiene el usuario 
                    Class_VariablesGlobales.XML_LicenciaUserCliente = m_node.ChildNodes.Item(1).InnerText
                    'Obtiene la contraseña 
                    Class_VariablesGlobales.XML_LicenciaPastwordCliente = m_node.ChildNodes.Item(2).InnerText

                End If



            Next



            Dim FechaVencimiento As String


            FechaVencimiento = Obj_LicSeguridad.DesEncripta(Class_VariablesGlobales.XML_LicenciaSincroServer)

            'inicializa la propiedad de fecha de vencimiento
            Class_VariablesGlobales.MisPropiedades.Valida = FechaVencimiento
            Dim diasrestantes As Integer = Obj_HoraFecha.Dias(Now.Date, FechaVencimiento)
            If diasrestantes <= 0 Then
                MessageBox.Show("LO SENTIMOS  LA LICENCIA HA CADUCADO " & vbCrLf & "CONTACTESE CON LUIS ROBERTO BASTOS CASTILLO " & vbCrLf & "TEL: 88801662 Ó AL CORREO : lurobaca@gmail.com/ilepilep@hotmail.com", "Sincro Server", MessageBoxButtons.OK)



                Dim TABLA As New DataTable
                TABLA = VariablesGlobales.Obj_SQL.CONSULTA_InfoContactoEmpresa(Class_VariablesGlobales.SQL_Comman2)

                Dim MSJ As String = "Licencia vencida del cliente: " & vbCrLf &
                                        " Cedula: " & Trim(TABLA.Rows(0).Item("Cedula").ToString()) & vbCrLf &
                                        " Nombre: " & Trim(TABLA.Rows(0).Item("Nombre").ToString()) & vbCrLf &
                                        " Telefono: " & Trim(TABLA.Rows(0).Item("Telefono").ToString()) & vbCrLf &
                                        " Correo: " & Trim(TABLA.Rows(0).Item("Correo").ToString()) & vbCrLf &
                                        "La licencia Vencio " & FechaVencimiento





                VariablesGlobales.Obj_Mail.NotificalicenciaVencida(MSJ, "LICENCIA VENCIDA DEL CLIENTE " & Trim(TABLA.Rows(0).Item("Nombre").ToString()))
                MSJ = Nothing
                Return 1
            End If
            If diasrestantes < 15 Then
                MessageBox.Show("ALERTA !! Su Licencia Expirara en " & diasrestantes & " Dias  " & vbCrLf & " comuniquese con su proveedor de softwate " & vbCrLf & " evite que su sistema se bloquee " & vbCrLf & "CONTACTESE CON LUIS ROBERTO BASTOS CASTILLO " & vbCrLf & "TEL: 88801662 Ó AL CORREO : lurobaca@gmail.com/ilepilep@hotmail.com", "Sincro Server", MessageBoxButtons.OK)
                VariablesGlobales.Obj_Log.Log("ALERTA !! Su Licencia Expirara en " & diasrestantes & " Dias  " & vbCrLf & " comuniquese con su proveedor de softwate " & vbCrLf & " evite que su sistema se bloquee " & vbCrLf & "CONTACTESE CON LUIS ROBERTO BASTOS CASTILLO " & vbCrLf & "TEL: 88801662 Ó AL CORREO : lurobaca@gmail.com/ilepilep@hotmail.com", "MR")
                Dim TABLA As New DataTable
                TABLA = VariablesGlobales.Obj_SQL.CONSULTA_InfoContactoEmpresa(Class_VariablesGlobales.SQL_Comman2)

                Dim MSJ As String = "Licencia pronta a vencerse, se vencera en [ " & diasrestantes & " ] dias del cliente: " & vbCrLf &
                                        " Cedula: " & Trim(TABLA.Rows(0).Item("Cedula").ToString()) & vbCrLf &
                                        " Nombre: " & Trim(TABLA.Rows(0).Item("Nombre").ToString()) & vbCrLf &
                                        " Telefono: " & Trim(TABLA.Rows(0).Item("Telefono").ToString()) & vbCrLf &
                                        " Correo: " & Trim(TABLA.Rows(0).Item("Correo").ToString()) & vbCrLf &
                                        "La licencia Vencimiento " & FechaVencimiento





                VariablesGlobales.Obj_Mail.NotificalicenciaVencida(MSJ, "LICENCIA PROXIMA A VENCERSE DEL CLIENTE " & Trim(TABLA.Rows(0).Item("Nombre").ToString()))

                Return 0
            End If



            Return 0
        Catch ex As Exception
            'Error trapping
            MessageBox.Show("NO SE ENCUENTRA EL ARCHIVO DE LICENCIA [Verifique que el formato de fecha sea dd/mm/yyyy ] " & vbCrLf & "CONTACTESE CON LUIS ROBERTO BASTOS CASTILLO" & vbCrLf & " TEL: 88801662 Ó AL CORREO : lurobaca@gmail.com/ilepilep@hotmail.com", "Sincro Server", MessageBoxButtons.OK)

            VariablesGlobales.Obj_Log.Log("NO SE ENCUENTRA EL ARCHIVO DE LICENCIA [Verifique que el formato de fecha sea dd/mm/yyyy ] " & vbCrLf & "CONTACTESE CON LUIS ROBERTO BASTOS CASTILLO" & vbCrLf & " TEL: 88801662 Ó AL CORREO : lurobaca@gmail.com/ilepilep@hotmail.com", "MR")

            Return 1
        End Try
    End Function

End Class

