Imports System.Xml
Imports System.IO

Public Class Class_XML_Conexion

  Public Function ConexionSAP()
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
      m_xmld.Load("C:\ConexionINFO.xml")

      'Obtenemos la lista de los nodos "name"
      m_nodelist = m_xmld.SelectNodes("/Conexiones/name")

      'Iniciamos el ciclo de lectura
      For Each m_node In m_nodelist
        'Obtenemos el atributo del codigo
        Dim mCodigo = m_node.Attributes.GetNamedItem("codigo").Value

        If mCodigo = "SAP" Then
          'CONEXION A SAP
          XMLParamSAP_CompanyDB = m_node.ChildNodes.Item(0).InnerText
          XMLParamSAP_Password = m_node.ChildNodes.Item(1).InnerText
          XMLParamSAP_UserName = m_node.ChildNodes.Item(2).InnerText
          XMLParamSAP_Server = m_node.ChildNodes.Item(3).InnerText
          XMLParamSAP_DbUserName = m_node.ChildNodes.Item(4).InnerText
          XMLParamSAP_DbPassword = m_node.ChildNodes.Item(5).InnerText
          XMLParamSAP_LicenseServer = m_node.ChildNodes.Item(6).InnerText

        End If
        If mCodigo = "SQL_Sic_Local_Web" Then
          'CONEXION A SQL
          XMLParamSQL_user = m_node.ChildNodes.Item(0).InnerText
          XMLParamSQL_clave = m_node.ChildNodes.Item(1).InnerText
          XMLParamSQL_dababase = m_node.ChildNodes.Item(2).InnerText
          XMLParamSQL_server = m_node.ChildNodes.Item(3).InnerText
        End If

        If mCodigo = "SQL_FIREBIRD" Then
          'CONEXION A FIREBIRD"
          XMLParamFIREBIRD_Dsn = m_node.ChildNodes.Item(0).InnerText
        End If

        If mCodigo = "MYSQL" Then
          'CONEXION A FIREBIRD"
          XMLParamMYSQL_Server = m_node.ChildNodes.Item(0).InnerText
          XMLParamMYSQL_MyDatabase = m_node.ChildNodes.Item(1).InnerText
          XMLParamMYSQL_myport = m_node.ChildNodes.Item(2).InnerText
          XMLParamMYSQL_userWEB = m_node.ChildNodes.Item(3).InnerText
          XMLParamMYSQL_claveWEB = m_node.ChildNodes.Item(4).InnerText
          XMLParamMYSQL_DsnWEB = m_node.ChildNodes.Item(5).InnerText
        End If

        If mCodigo = "FTP" Then
          'CONEXION A FTP"
          XMLParamFTP_Server = m_node.ChildNodes.Item(0).InnerText
          XMLParamFTP_user = m_node.ChildNodes.Item(1).InnerText
          XMLParamFTP_Password = m_node.ChildNodes.Item(2).InnerText
          XMLParamFTP_dirLocal = m_node.ChildNodes.Item(3).InnerText
        End If

                If mCodigo = "CUENTAS" Then
                    'CONEXION A FTP"

                    XMLParam_CuentaEfectivo = m_node.ChildNodes.Item(0).InnerText
                    XMLParam_CuentaTranferencia = m_node.ChildNodes.Item(1).InnerText
                    'XMLParam_CuentaCheque = m_node.ChildNodes.Item(2).InnerText

                    'XMLParam_CuentaBPCOLONES = m_node.ChildNodes.Item(3).InnerText
                    'XMLParam_CuentaBNCOLONES = m_node.ChildNodes.Item(4).InnerText
                    'XMLParam_CuentaBCRCOLONES = m_node.ChildNodes.Item(5).InnerText
                    'XMLParam_CuentaBFISECOLONES = m_node.ChildNodes.Item(6).InnerText
                    'XMLParam_CuentaBCTCOLONES = m_node.ChildNodes.Item(7).InnerText
                    'XMLParam_CuentaBCTDOLAR = m_node.ChildNodes.Item(8).InnerText
                    'XMLParam_CuentaBINVEDOLAR = m_node.ChildNodes.Item(9).InnerText
                    'XMLParam_CuentaBPDOLAR = m_node.ChildNodes.Item(10).InnerText



                End If
      Next
    Catch ex As Exception
      'Error trapping
            MessageBox.Show("NO SE ENCUENTRA EL ARCHIVO DE PARAMETROS DE CONEXION ,CONTACTESE CON LUIS ROBERTO BASTOS C AL TEL: 88801662 Ó AL CORREO : lurobaca@gmail.com")
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
                    XML_LicenciaSincroServer = m_node.ChildNodes.Item(0).InnerText
                    'Obtiene el usuario 
                    XML_LicenciaUserServer = m_node.ChildNodes.Item(1).InnerText
                    'Obtiene la contraseña 
                    XML_LicenciaPastwordServer = m_node.ChildNodes.Item(2).InnerText

                End If
                If mCodigo = "SincroCliente" Then
                    'Obtiene la licencia 
                    XML_LicenciaSincroCliente = m_node.ChildNodes.Item(0).InnerText
                    'Obtiene el usuario 
                    XML_LicenciaUserCliente = m_node.ChildNodes.Item(1).InnerText
                    'Obtiene la contraseña 
                    XML_LicenciaPastwordCliente = m_node.ChildNodes.Item(2).InnerText

                End If

               

            Next


            Dim cadena As String
            Dim n As Integer
            Dim FechaVencimiento As String
            Dim Caracter As String
            For n = 0 To Len(XML_LicenciaSincroServer) - 1
                Caracter = XML_LicenciaSincroServer.Chars(n)

                If Caracter = "0" Then
                    FechaVencimiento = FechaVencimiento & "0"
                End If
                If Caracter = "9" Then
                    FechaVencimiento = FechaVencimiento & "/"
                End If
                If Caracter = "A" Then
                    FechaVencimiento = FechaVencimiento & "1"
                End If
                If Caracter = "B" Then
                    FechaVencimiento = FechaVencimiento & "2"
                End If
                If Caracter = "C" Then
                    FechaVencimiento = FechaVencimiento & "3"
                End If
                If Caracter = "D" Then
                    FechaVencimiento = FechaVencimiento & "4"
                End If
                If Caracter = "E" Then
                    FechaVencimiento = FechaVencimiento & "5"
                End If
                If Caracter = "F" Then
                    FechaVencimiento = FechaVencimiento & "6"
                End If
                If Caracter = "G" Then
                    FechaVencimiento = FechaVencimiento & "7"
                End If
                If Caracter = "H" Then
                    FechaVencimiento = FechaVencimiento & "8"
                End If
                If Caracter = "I" Then
                    FechaVencimiento = FechaVencimiento & "9"
                End If

                If Caracter = "-" Then

                End If
                If Caracter = "M" Then

                End If

                
            Next n
            If Now.Date > FechaVencimiento Then
                MessageBox.Show("LO SENTIMOS  LA LICENCIA DE SINCROSERVER HA CADUCADO " & vbCrLf & "CONTACTESE CON LUIS ROBERTO BASTOS CASTILLO " & vbCrLf & "TEL: 88801662 Ó AL CORREO : lurobaca@gmail.com/ilepilep@hotmail.com", "Sincro Server", MessageBoxButtons.OK)
                Return 1

            End If
            Return 0
        Catch ex As Exception
            'Error trapping
            MessageBox.Show("NO SE ENCUENTRA EL ARCHIVO DE LICENCIA " & vbCrLf & "CONTACTESE CON LUIS ROBERTO BASTOS CASTILLO" & vbCrLf & " TEL: 88801662 Ó AL CORREO : lurobaca@gmail.com/ilepilep@hotmail.com", "Sincro Server", MessageBoxButtons.OK)
            Return 1
        End Try
    End Function

End Class

