'' FirmaElectronicaCR es un programa para la firma y envio de documentos XML para la Factura Electrónica de Costa Rica
''
'' Comunicacion es la clase para el envío del documento XML para la Factura Electrónica de Costa Rica
''
'' Esta clase de Firma fue realizado tomando como base el trabajo realizado por:
'' - Departamento de Nuevas Tecnologías - Dirección General de Urbanismo Ayuntamiento de Cartagena
'' - XAdES Starter Kit desarrollado por Microsoft Francia
'' - Cambios y funcionalidad para Costa Rica - Roy Rojas - royrojas@dotnetcr.com
''
'' La clase comunicación fue creada en conjunto con Cristhian Sancho
''
'' Este programa es software libre: puede redistribuirlo y / o modificarlo
'' bajo los + términos de la Licencia Pública General Reducida de GNU publicada por
'' la Free Software Foundation, ya sea la versión 3 de la licencia, o
'' (a su opción) cualquier versión posterior.

'' Este programa se distribuye con la esperanza de que sea útil,
'' pero SIN NINGUNA GARANTÍA; sin siquiera la garantía implícita de
'' COMERCIABILIDAD O IDONEIDAD PARA UN PROPÓSITO PARTICULAR.
'' Licencia pública general menor de GNU para más detalles.
''
'' Deberías haber recibido una copia de la Licencia Pública General Reducida de GNU
'' junto con este programa. Si no, vea http://www.gnu.org/licenses/.
''
'' This program Is distributed in the hope that it will be useful,
'' but WITHOUT ANY WARRANTY; without even the implied warranty of
'' MERCHANTABILITY Or FITNESS FOR A PARTICULAR PURPOSE.  See the
'' GNU Lesser General Public License for more details.
''
'' You should have received a copy of the GNU Lesser General Public License
'' along with this program.  If Not, see http://www.gnu.org/licenses/. 

Imports System.IO
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Header
Imports Newtonsoft.Json.Linq


Public Class Comunicacion
    Public xmlRH

    Public Obj_Mail As New Class_MAIL
    Public Obj_Funciones As New Class_funcionesSQL
    Public Property xmlRespuesta As Xml.XmlDocument
    Public Property jsonEnvio As String = ""
    Public Property jsonRespuesta As String = ""
    Public Property mensajeRespuesta As String = ""
    Public Property estadoFactura As String = ""
    Public Property MensajeDetalle As String = ""
    Public Property fecha As String = ""
    Public Property statusCode As String = ""

    ''' <summary>
    ''' Envia los datos a los servidores de Hacienda y obtiene las respuestas necesarias
    ''' </summary>
    ''' <param name="TK">Token que generó Hacienda</param>
    ''' <param name="objRecepcion">Objeto que contiene todos las variables de comunicación</param>
    Public Sub EnvioDatos(TK As String, ByVal objRecepcion As Recepcion, RutaComprobante As String, Tipo As String)
        Try
            Dim URL_RECEPCION As String = VariablesGlobales.URL_RECEPCION

            Dim http As HttpClient = New HttpClient

            Dim JsonObject As Newtonsoft.Json.Linq.JObject = New Newtonsoft.Json.Linq.JObject()
            JsonObject.Add(New JProperty("clave", objRecepcion.clave))
            JsonObject.Add(New JProperty("fecha", objRecepcion.fecha))
            JsonObject.Add(New JProperty("emisor", New JObject(New JProperty("tipoIdentificacion", objRecepcion.emisor.TipoIdentificacion),
                                                               New JProperty("numeroIdentificacion", objRecepcion.emisor.numeroIdentificacion))))
            If objRecepcion.receptor.sinReceptor = False Then
                JsonObject.Add(New JProperty("receptor", New JObject(New JProperty("tipoIdentificacion", objRecepcion.receptor.TipoIdentificacion),
                                                                     New JProperty("numeroIdentificacion", objRecepcion.receptor.numeroIdentificacion))))
            End If
            If Tipo = "MR" Then
                JsonObject.Add(New JProperty("consecutivoReceptor", objRecepcion.consecutivoReceptor))
            End If
            JsonObject.Add(New JProperty("comprobanteXml", objRecepcion.comprobanteXml))

            'Carga la variable global con el string del json a enviar a hacienda
            jsonEnvio = JsonObject.ToString


            Dim oString As StringContent = New StringContent(JsonObject.ToString)

            http.DefaultRequestHeaders.Add("authorization", "Bearer " + TK)
            '-----------------------------------------------------------
            'ENVIA LOS DATOS A TRIBUTACION POR MEDIO DE POST Asycronamente
            '-----------------------------------------------------------
            Dim response As HttpResponseMessage = http.PostAsync(URL_RECEPCION + "recepcion", oString).Result
            Dim res As String = response.Content.ReadAsStringAsync.Result
            mensajeRespuesta = "Recibido: " & response.StatusCode & vbCrLf & vbCrLf

            '------------------------------------------------------------------------------------
            '--------------------------- CONSULTA ESTADO DE COMPROBANTE RECIEN ENVIADO-------------------------
            '------------------------------------------------------------------------------------
            'TestFacturaXMLCR.Label_Estado.Text = VariablesGlobales.estado & " Consultando Estado"
            ConsultaEstatus(TK, objRecepcion.clave, RutaComprobante, Tipo, objRecepcion.consecutivoReceptor)

            'http = New HttpClient
            'http.DefaultRequestHeaders.Add("authorization", "Bearer " + TK)
            'response = http.GetAsync(URL_RECEPCION + "recepcion/" + objRecepcion.clave).Result
            'res = response.Content.ReadAsStringAsync.Result

            'jsonRespuesta = res.ToString


            'Dim Msj As String
            'If res = "" Then
            '    Dim headers As HttpHeaders = response.Headers
            '    Dim values As IEnumerable(Of String)

            '    If headers.TryGetValues("X-Error-Cause", values) Then
            '        Msj = values.First()
            '    End If
            '    If headers.TryGetValues("X-Http-Status", values) Then
            '        statusCode = values.First()
            '    End If

            '    'Dim RH2 As RespuestaHacienda2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of RespuestaHacienda2)(response.Headers.ToString)
            '    'If RH2.X_Error_Cause <> "" Then
            '    '    xmlRespuesta = Funciones.DecodeBase64ToXML(RH2.X_Error_Cause)
            '    'End If

            '    'estadoFactura = RH2.X_Http_Status
            '    'statusCode = response.StatusCode
            '    estadoFactura = "No Existe"
            '    mensajeRespuesta = "Confirmación: " & statusCode & vbCrLf
            '    mensajeRespuesta += "Estado: " & estadoFactura & vbCrLf
            '    mensajeRespuesta += "Mensaje: " & Msj & vbCrLf
            '    Obj_Funciones.Guarda_MensajeHacienda(TestFacturaXMLCR.txtClave.Text, estadoFactura, "", Msj)
            'Else
            '    Dim RH As RespuestaHacienda = Newtonsoft.Json.JsonConvert.DeserializeObject(Of RespuestaHacienda)(res)
            '    If RH.respuesta_xml <> "" Then
            '        xmlRespuesta = Funciones.DecodeBase64ToXML(RH.respuesta_xml)
            '    End If

            '    fecha = RH.fecha
            '    estadoFactura = RH.ind_estado
            '    statusCode = response.StatusCode

            '    mensajeRespuesta = "Confirmación: " & statusCode & vbCrLf
            '    mensajeRespuesta += "Estado: " & estadoFactura & vbCrLf
            '    'si estadoFactura =procesando no abra mensaje por lo que se caera
            '    If estadoFactura = "procesando" Then
            '        MensajeDetalle = "Hacienda esta procesando el comprobante"
            '        'Aqui podriamos Guardamos la clave para saber que se debe consultar el estado ya que apenas se esta procesando por hacienda
            '    Else
            '        MensajeDetalle = TestFacturaXMLCR.CargaDatosXML_MensajeHacienda(xmlRespuesta.InnerXml)
            '    End If

            '    mensajeRespuesta += "Mensaje: " & MensajeDetalle
            '    Obj_Funciones.Guarda_MensajeHacienda(TestFacturaXMLCR.txtClave.Text, estadoFactura, fecha, MensajeDetalle)
            '    'Aqui deberia actualizar los estados
            '    Obj_Funciones.ActualizaEstado(TestFacturaXMLCR.txtClave.Text, estadoFactura, fecha, MensajeDetalle)
            'End If

            ''Aqui deberiamos insertar el estado del error
            'If estadoFactura = "procesando" Then
            '    Obj_Mail.Envia_Alerta(objRecepcion.clave, "FE", "FACTURA PROCENSANDOSE CONSULTE MAS TARDE [" & claveConsultar & "]", mensajeRespuesta)
            'End If
            'If estadoFactura = "aceptado" Then
            '    Obj_Mail.Envia_Alerta(objRecepcion.clave, "FE", "FACTURA ACEPTADA [" & objRecepcion.clave & "]", mensajeRespuesta)
            'End If
            'If estadoFactura = "rechazado" Then
            '    Obj_Mail.Envia_Alerta(objRecepcion.clave, "FE", "FACTURA RECHAZADA [" & objRecepcion.clave & "]", mensajeRespuesta)
            'End If
            'If estadoFactura = "No Existe" Then
            '    Obj_Mail.Envia_Alerta(objRecepcion.clave, "FE", "FACTURA NO EXISTE [" & objRecepcion.clave & "]", mensajeRespuesta)
            'End If


        Catch ex As Exception
            VariablesGlobales.Obj_Log.Log("ERROR en EnvioDatos [ " & ex.Message & " ]", "MR")
            MessageBox.Show("ERROR en EnvioDatos [ " & ex.Message & " ]")
            Throw
        End Try
    End Sub

    Public Sub ConsultaEstatus(TK As String, claveConsultar As String, RutaComprobante As String, Tipo As String, ConsecutivoMR As String)
        Try
            Dim obj_FTP As New Class_FTP
            'Dim obj_SAP As New SAP_BUSSINES_ONE
            Dim URL_RECEPCION As String = VariablesGlobales.URL_RECEPCION
            Dim http As HttpClient = New HttpClient
            Dim Msj As String
            Dim Patch_XML As String
            Dim Patch_PDF As String
            Dim Patch_RH As String
            Dim res As String
            Dim Obj_Ventana As New Acepta_Rechaza
            Dim RH As RespuestaHacienda


            http.DefaultRequestHeaders.Add("authorization", "Bearer " + TK)
            'CONSULTA LOS DATOS DE UN COMPROBANTE X SU CLAVE
            Dim response As HttpResponseMessage
            If Tipo = "MR" Then
                response = http.GetAsync(URL_RECEPCION & "recepcion/" & claveConsultar & "-" & ConsecutivoMR).Result
            Else
                response = http.GetAsync(URL_RECEPCION & "recepcion/" & claveConsultar).Result
            End If

            res = response.Content.ReadAsStringAsync.Result


            Dim Localizacion = response.StatusCode
            Dim ReasonPhrase = response.ReasonPhrase
            jsonRespuesta = res.ToString

            If res = "" Or response.ReasonPhrase = "Bad Gateway" Or response.ReasonPhrase = "Bad Request" Then

                If response.ReasonPhrase = "Bad Request" Or response.ReasonPhrase = "Bad Gateway" Then
                    'Si entra es por que hacienda se callo y no da respuesta
                    Msj = "Hacienda no responde :" & response.ReasonPhrase
                    statusCode = "400 or 502"
                    estadoFactura = "Desconocido"

                Else
                    Dim headers As HttpHeaders = response.Headers
                    Dim values As IEnumerable(Of String)

                    If headers.TryGetValues("X-Error-Cause", values) Then
                        Msj = values.First()
                    End If
                    If headers.TryGetValues("X-Http-Status", values) Then
                        statusCode = values.First()
                    End If

                    'Dim RH2 As RespuestaHacienda2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of RespuestaHacienda2)(response.Headers.ToString)
                    'If RH2.X_Error_Cause <> "" Then
                    '    xmlRespuesta = Funciones.DecodeBase64ToXML(RH2.X_Error_Cause)
                    'End If

                    'estadoFactura = RH2.X_Http_Status
                    'statusCode = response.StatusCode
                    estadoFactura = "No Existe"
                End If


                mensajeRespuesta = "Confirmación: " & statusCode & vbCrLf
                mensajeRespuesta += "Estado: " & estadoFactura & vbCrLf
                mensajeRespuesta += "Mensaje: " & Msj & vbCrLf
                MensajeDetalle = Msj & vbCrLf


            Else
                RH = Newtonsoft.Json.JsonConvert.DeserializeObject(Of RespuestaHacienda)(res)
                If RH.respuesta_xml <> "" Then
                    xmlRespuesta = Funciones.DecodeBase64ToXML(RH.respuesta_xml)
                End If
                fecha = RH.fecha
                estadoFactura = RH.ind_estado
                statusCode = response.StatusCode

                mensajeRespuesta = "Confirmación: " & statusCode & vbCrLf
                mensajeRespuesta += "Estado: " & estadoFactura & vbCrLf
                'si estadoFactura =procesando no abra mensaje por lo que se caera
                If estadoFactura = "procesando" Then
                    MensajeDetalle = "Hacienda esta procesando el comprobante"
                    'Aqui podriamos Guardamos la clave para saber que se debe consultar el estado ya que apenas se esta procesando por hacienda
                ElseIf estadoFactura = "recibido" Then
                    MensajeDetalle = "Hacienda recibido el comprobante"
                Else
                    MensajeDetalle = Obj_Ventana.CargaDatosXML_MensajeHacienda(xmlRespuesta.InnerXml)
                End If

                mensajeRespuesta += "Mensaje: " & MensajeDetalle

            End If
            Dim obj_Fecha As New FechaManager
            '             Guarda_MensajeHacienda(clave,          ind_estado   , FechaComprobante ,                   Mensaje ,     HoraComprobante, CodSeguridad ,CodigoEstado,FechaEstado, HoraEstado , Tipo)


            Obj_Funciones.Guarda_MensajeHacienda(claveConsultar, estadoFactura, obj_Fecha.FormatoFechaSql(Obj_Funciones.ObtieneFechaComprobante(claveConsultar).ToString.Substring(0, 10)), MensajeDetalle, Obj_Funciones.ObtieneHoraComprobante(claveConsultar), "", Localizacion, obj_Fecha.FormatoFechaSql(Date.Now), Now.ToString("HH:mm:ss"), Tipo)

            'Aqui deberia actualizar los estados
            Obj_Funciones.ActualizaEstado(claveConsultar, estadoFactura, fecha, MensajeDetalle, "MR")

            Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.txtb_MHEstado.Text = estadoFactura
            Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.txtb_MHFecha.Text = fecha
            Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.txtb_MHMensaje.Text = MensajeDetalle
            'NO SE AH
            Class_VariablesGlobales.frmLista_FE_Proveedores.DGV_ListaFE.Item(7, CInt(Class_VariablesGlobales.RoxIndexDGV(claveConsultar).ToString())).Value = estadoFactura
            Class_VariablesGlobales.frmLista_FE_Proveedores.DGV_ListaFE.Item(8, CInt(Class_VariablesGlobales.RoxIndexDGV(claveConsultar).ToString())).Value = fecha
            Class_VariablesGlobales.frmLista_FE_Proveedores.DGV_ListaFE.Item(9, CInt(Class_VariablesGlobales.RoxIndexDGV(claveConsultar).ToString())).Value = MensajeDetalle

            'Se guarda el encabezado del comprobante con la fecha y hora del estado
            Obj_Funciones.GuardaComprobanteEnBitacora(Tipo, claveConsultar, estadoFactura, obj_Fecha.FormatoFechaSql(Date.Now), MensajeDetalle, DateTime.Now.ToString("hh:mm"))
            obj_Fecha = Nothing

            '***************************************************************************************
            '************** Aqui es donde se debe crear los documentos de respuesta ****************
            '***************************************************************************************
            ' TestFacturaXMLCR.Label_Estado.Text = VariablesGlobales.estado & " Generando Archivos de Respuesta Hacienda"
            GeneraArchivosRespuesta(RutaComprobante, xmlRH, jsonEnvio, jsonRespuesta, Tipo)


            Patch_XML = RutaComprobante & "_Firmado.xml"
            Patch_PDF = RutaComprobante & ".pdf"
            Patch_RH = RutaComprobante & "_RH.xml"

            If File.Exists(Patch_XML) = False Then
                Patch_XML = ""
            End If
            If File.Exists(Patch_PDF) = False Then
                Patch_PDF = ""
            End If
            If File.Exists(Patch_RH) = False Then
                Patch_RH = ""
            End If

            '  TestFacturaXMLCR.Label_Estado.Text = VariablesGlobales.estado & " Estado Comprobante [ " & estadoFactura & " ]"
            'Aqui deberiamos insertar el estado del error
            If estadoFactura = "procesando" Then
                'Obj_Mail.Envia_Alerta2(claveConsultar, Tipo, Tipo & " PROCENSANDOSE CONSULTE MAS TARDE [" & claveConsultar & "]", mensajeRespuesta)
            End If
            If estadoFactura = "aceptado" Then
                If VariablesGlobales.ComprobantesSubidos = False Then

                    VariablesGlobales.ComprobantesSubidos = True
                    If Tipo = "MR" Then
                        obj_FTP.Subir(VariablesGlobales.Patch_MR & "\" & claveConsultar & "\" & claveConsultar & "_RH.xml", VariablesGlobales.XMLParamFTP_Server & "XMLs/RH/" & claveConsultar & "/" & claveConsultar & "_RH.xml", VariablesGlobales.XMLParamFTP_user, VariablesGlobales.XMLParamFTP_Password)
                    Else
                        '    'Sube al servidor web los archivos para ser consultados
                        '    'Representacion Grafica /bourneycia.net/XMLs/FE
                        '    ' TestFacturaXMLCR.Label_Estado.Text = VariablesGlobales.estado & " Subiendo archivos [ " & claveConsultar & ".pdf" & " ] al FTP"
                        '    obj_FTP.Subir(VariablesGlobales.Patch_FE & "\" & claveConsultar & "\" & claveConsultar & ".pdf", VariablesGlobales.XMLParamFTP_Server & "XMLs/FE/" & claveConsultar & "/" & claveConsultar & ".pdf", VariablesGlobales.XMLParamFTP_user, VariablesGlobales.XMLParamFTP_Password)
                        ''XML del Comprobante
                        ''TestFacturaXMLCR.Label_Estado.Text = VariablesGlobales.estado & " Subiendo archivos [ " & claveConsultar & "_Firmado.xml" & " ] al FTP"
                        'obj_FTP.Subir(VariablesGlobales.Patch_FE & "\" & claveConsultar & "\" & claveConsultar & "_Firmado.xml", VariablesGlobales.XMLParamFTP_Server & "XMLs/FE/" & claveConsultar & "/" & claveConsultar & "_Firmado.xml", VariablesGlobales.XMLParamFTP_user, VariablesGlobales.XMLParamFTP_Password)
                        ''XML de MensajeHacienda
                        ''TestFacturaXMLCR.Label_Estado.Text = VariablesGlobales.estado & " Subiendo archivos [ " & claveConsultar & "_RH.xml" & " ] al FTP"
                        'obj_FTP.Subir(VariablesGlobales.Patch_FE & "\" & claveConsultar & "\" & claveConsultar & "_RH.xml", VariablesGlobales.XMLParamFTP_Server & "XMLs/RH/" & claveConsultar & "/" & claveConsultar & "_RH.xml", VariablesGlobales.XMLParamFTP_user, VariablesGlobales.XMLParamFTP_Password)


                    End If


                Else

                End If



                If VariablesGlobales.EmisorEmail <> "" Then
                    ' TestFacturaXMLCR.Label_Estado.Text = VariablesGlobales.estado & " Enviando archivos al cliente"
                    'Obj_Mail.Envia_Cliente(claveConsultar, Tipo, "Factura Electronica ACEPTADA [" & claveConsultar & "]", VariablesGlobales.MensajeRespuestaH, VariablesGlobales.GPatch_XML, VariablesGlobales.GPatch_PDF, VariablesGlobales.GPatch_RH)
                Else
                    'TestFacturaXMLCR.Label_Estado.Text = VariablesGlobales.estado & " Cliente no tiene correo"
                End If

                'Actualiza el stado en SAP del documento
                If File.Exists(Patch_PDF) Then

                    'Envia correo al cliente solo cuando esta haciendo el proceso de verificacion de estados no cuando 
                    If VariablesGlobales.EmisorEmail <> "" Then
                        Obj_Mail.Envia_Cliente(claveConsultar, Tipo, "Factura Electronica ACEPTADA [" & claveConsultar & "]", mensajeRespuesta, Patch_XML, Patch_PDF, Patch_RH)
                    End If
                End If


            End If
            If estadoFactura = "rechazado" Then

                Obj_Mail.Envia_Alerta(claveConsultar, Tipo, Tipo & " RECHAZADA [" & claveConsultar & "]", mensajeRespuesta, Patch_XML, Patch_PDF, Patch_RH)
            End If
            If estadoFactura = "Desconocido" Then

                Obj_Mail.Envia_Alerta(claveConsultar, Tipo, Tipo & " HACIENDA NO RESPONDE [" & claveConsultar & "]", mensajeRespuesta, Patch_XML, Patch_PDF, Patch_RH)
            End If
            If estadoFactura = "No Existe" Then
                'Obj_Mail.Envia_Alerta2(claveConsultar, Tipo, Tipo & " NO EXISTE [" & claveConsultar & "]", mensajeRespuesta)
            End If

            '************** AQUI DEBEMOS ACTUALIZAR EL ESTADO EN SAP ****************


            ' obj_SAP.ActualizaFESAP(CInt(claveConsultar.Substring(42, 8).Trim), estadoFactura)

            'Se cargan los datos para luego mandar el correo al cliente
            VariablesGlobales.EstadoComprobante = ""
            VariablesGlobales.MensajeRespuestaH = ""
            VariablesGlobales.GPatch_XML = ""
            VariablesGlobales.GPatch_PDF = ""
            VariablesGlobales.GPatch_RH = ""

            VariablesGlobales.EstadoComprobante = estadoFactura
            VariablesGlobales.MensajeRespuestaH = mensajeRespuesta
            VariablesGlobales.GPatch_XML = Patch_XML
            VariablesGlobales.GPatch_PDF = Patch_PDF
            VariablesGlobales.GPatch_RH = Patch_RH

            '----------------------- LIBERAMOS MEMORIA **********
            obj_FTP = Nothing
            URL_RECEPCION = Nothing
            http = Nothing
            Msj = Nothing
            Patch_XML = Nothing
            Patch_PDF = Nothing
            Patch_RH = Nothing
            res = Nothing
            response = Nothing
            Localizacion = Nothing
            ReasonPhrase = Nothing


            'obj_SAP = Nothing



        Catch ex As Exception


            'MessageBox.Show("ERROR en ConsultaEstatus [ " & ex.Message & " : " & RutaComprobante & "] ")
        End Try
    End Sub

    'Public Function GeneraArchivosRespuesta(RutaComprobante As String)
    '    Try


    '        'Variables a generar en archivos
    '        'jsonEnvio
    '        'jsonRespuesta
    '        'estadoFactura
    '        'mensajeRespuesta

    '        'Carga los textbox para visualizar x interfaz la respuesta de hacienda
    '        'txtJSONEnvio.Text = jsonEnvio
    '        'txtJSONRespuesta.Text = jsonRespuesta

    '        'Crear el txt con el json enviado a tributacion
    '        'Dim outputFile As New IO.StreamWriter(directorio & nombreArchivo & "_03_jsonEnvio.txt")
    '        Dim outputFile As New IO.StreamWriter(RutaComprobante & "_jsonEnvio.txt")
    '        outputFile.Write(jsonEnvio)
    '        outputFile.Close()

    '        'Crear el txt con el mensaje de respuesta
    '        'outputFile = New IO.StreamWriter(directorio & nombreArchivo & "_04_jsonRespuesta.txt")
    '        outputFile = New IO.StreamWriter(RutaComprobante & "_jsonRespuesta.txt")
    '        outputFile.Write(jsonRespuesta)
    '        outputFile.Close()

    '        'si hay respuesta entra y crea el xml con la respuesta de hacienda, el cual debe mandarse al cliente si es aceptada
    '        If Not IsNothing(xmlRespuesta) Then
    '            'TestFacturaXMLCR.txtRespuestaHacienda.Text = xmlRespuesta.OuterXml
    '            ' enviaFactura.xmlRespuesta.Save(directorio & nombreArchivo & "_05_RESP.xml")
    '            xmlRespuesta.Save(RutaComprobante & "_RH.xml")
    '        Else
    '            'Si no hay respuesta crea un txt indicando que no hubo respuesta
    '            ' outputFile = New IO.StreamWriter(directorio & nombreArchivo & "_05_RESP_SinRespuesta.txt")
    '            outputFile = New IO.StreamWriter(RutaComprobante & "_SRH.txt")
    '            outputFile.Write("")
    '            outputFile.Close()

    '            'TestFacturaXMLCR.txtRespuestaHacienda.Text = "Consulte en unos minutos, factura se está procesando."
    '            'TestFacturaXMLCR.txtRespuestaHacienda.Text += vbCrLf & vbCrLf & mensajeRespuesta
    '            'TestFacturaXMLCR.txtRespuestaHacienda.Text += vbCrLf & vbCrLf & "Consulte por Clave"
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show("ERROR en GeneraArchivosRespuesta [ " & ex.Message & " : " & RutaComprobante & "] ")
    '    End Try
    'End Function


    Public Function GeneraArchivosRespuesta(ByVal RutaComprobante As String, ByVal PxmlRH As Xml.XmlDocument, ByVal PjsonEnvio As String, ByVal PjsonRespuesta As String, Tipo As String)
        Try
            'Variables a generar en archivos
            'jsonEnvio
            'jsonRespuesta
            'estadoFactura
            'mensajeRespuesta

            'Carga los textbox para visualizar x interfaz la respuesta de hacienda
            'txtJSONEnvio.Text = jsonEnvio
            'txtJSONRespuesta.Text = jsonRespuesta

            'Crear el txt con el json enviado a tributacion
            'Dim outputFile As New IO.StreamWriter(directorio & nombreArchivo & "_03_jsonEnvio.txt")
            Dim outputFile As New IO.StreamWriter(RutaComprobante & "_jsonEnvio.txt")
            outputFile.Write(PjsonEnvio)
            outputFile.Close()

            'Crear el txt con el mensaje de respuesta
            'outputFile = New IO.StreamWriter(directorio & nombreArchivo & "_04_jsonRespuesta.txt")
            outputFile = New IO.StreamWriter(RutaComprobante & "_jsonRespuesta.txt")
            outputFile.Write(PjsonRespuesta)
            outputFile.Close()

            'si hay respuesta entra y crea el xml con la respuesta de hacienda, el cual debe mandarse al cliente si es aceptada

            If xmlRH.OuterXml <> "" Then
                'VariablesGlobales.Obj_TestFactura.txtRespuestaHacienda.Text = xmlRespuesta.OuterXml
                ' VariablesGlobales.Obj_TestFactura.txtRespuestaHacienda.Text = PxmlRH.OuterXml
                ' enviaFactura.xmlRespuesta.Save(directorio & nombreArchivo & "_05_RESP.xml")

                'SAVE es solo para documentos Xml.XmlDocument

                'xmlRespuesta.Save(RutaComprobante & "_RH.xml")
                PxmlRH.Save(RutaComprobante & "_RH.xml")

            Else
                'Si no hay respuesta crea un txt indicando que no hubo respuesta
                ' outputFile = New IO.StreamWriter(directorio & nombreArchivo & "_05_RESP_SinRespuesta.txt")
                outputFile = New IO.StreamWriter(RutaComprobante & "_SRH.txt")
                outputFile.Write("")
                outputFile.Close()

                '  VariablesGlobales.Obj_TestFactura.txtRespuestaHacienda.Text = "Consulte en unos minutos, factura se está procesando."
                '  VariablesGlobales.Obj_TestFactura.txtRespuestaHacienda.Text += vbCrLf & vbCrLf & mensajeRespuesta
                '  VariablesGlobales.Obj_TestFactura.txtRespuestaHacienda.Text += vbCrLf & vbCrLf & "Consulte por Clave"
            End If

            '----------- LIMPIA MEMORIA --------------
            outputFile = Nothing

        Catch ex As Exception
            VariablesGlobales.Obj_Log.Log("ERROR en GeneraArchivosRespuesta [ " & ex.Message & " : " & RutaComprobante & "] [ " & Now.Date & "]", Tipo)
            If Tipo = "FE" Then
                '  VariablesGlobales.Obj_TestFactura.List_FE.Items.Insert(0, "ERROR en GeneraArchivosRespuesta [ " & ex.Message & " : " & RutaComprobante & "] [ " & Now.Date & "]")
            ElseIf Tipo = "FES" Then
                ' VariablesGlobales.Obj_TestFactura.List_FES.Items.Insert(0, "ERROR en GeneraArchivosRespuesta [ " & ex.Message & " : " & RutaComprobante & "] [ " & Now.Date & "]")
            ElseIf Tipo = "NC" Then
                ' VariablesGlobales.Obj_TestFactura.List_NC.Items.Insert(0, "ERROR en GeneraArchivosRespuesta [ " & ex.Message & " : " & RutaComprobante & "] [ " & Now.Date & "]")
            ElseIf Tipo = "NCS" Then
                ' VariablesGlobales.Obj_TestFactura.List_NCS.Items.Insert(0, "ERROR en GeneraArchivosRespuesta [ " & ex.Message & " : " & RutaComprobante & "] [ " & Now.Date & "]")
            ElseIf Tipo = "ND" Then
                ' VariablesGlobales.Obj_TestFactura.List_ND.Items.Insert(0, "ERROR en GeneraArchivosRespuesta [ " & ex.Message & " : " & RutaComprobante & "] [ " & Now.Date & "]")
            ElseIf Tipo = "NDS" Then
                '  VariablesGlobales.Obj_TestFactura.List_NDS.Items.Insert(0, "ERROR en GeneraArchivosRespuesta [ " & ex.Message & " : " & RutaComprobante & "] [ " & Now.Date & "]")
            ElseIf Tipo = "TE" Then
                'VariablesGlobales.Obj_TestFactura.List_TE.Items.Insert(0, "ERROR EN Procesa  [ " & ex.Message & " ] [ " & Now.Date & "]")
            Else
                ' MsgBox("ERROR en GeneraArchivosRespuesta [ " & ex.Message & " : " & RutaComprobante & "] [ " & Now.Date & "]")
            End If

            'MessageBox.Show("ERROR en GeneraArchivosRespuesta [ " & ex.Message & " : " & RutaComprobante & "] [ " & Now & " ] ")

            ' Obj_Funciones.GuardaComprobantes_Log("Comunicacion", "GeneraArchivosRespuesta", "", ex.Message, obj_Fecha.FormatoFechaSql(Date.Now), DateTime.Now.ToString("hh:mm"))

        End Try

    End Function

    Public Function GeneraArchivosEnvio(RutaComprobante As String, xml_Comprobante As String)
        Dim x As String
        Try
            'Dim Obj_Config As New ATV_Class

            '******** SE GUARDA EL XML SIN FIRMAR **************

            Dim xmlDocSF As New Xml.XmlDocument
            xmlDocSF.LoadXml(xml_Comprobante)

            'Guarda el xml Sin Firmar (SF)
            'xmlDocSF.Save(directorio & nombreArchivo & "_01_SF.xml")

            xmlDocSF.Save(RutaComprobante & "_SF.xml")

            ' Dim xmlTextWriter As New Xml.XmlTextWriter(directorio & nombreArchivo & "_01_SF.xml", New System.Text.UTF8Encoding(False))

            Dim xmlTextWriter As New Xml.XmlTextWriter(RutaComprobante & "_SF.xml", New System.Text.UTF8Encoding(False))
            x = "xmlTextWriter"
            xmlDocSF.WriteTo(xmlTextWriter)
            xmlTextWriter.Close()
            xmlDocSF = Nothing

            '******** SE PROCEDE A GENERAR EL XML DEL COMPROBANTE FIRMADO *******************

            Dim _firma As New Firma
            _firma.FirmaXML_Xades(RutaComprobante, VariablesGlobales.Patch_Certificado, False, VariablesGlobales.Certificado_PIN)

            Dim xmlElectronica As New Xml.XmlDocument
            ' xmlElectronica.Load(directorio & nombreArchivo & "_02_Firmado.xml")
            x = RutaComprobante & "_Firmado.xml"
            xmlElectronica.Load(RutaComprobante & "_Firmado.xml")

            Return xmlElectronica
        Catch ex As Exception
            MessageBox.Show("ERROR en GeneraArchivosEnvio [ " & ex.Message & " : " & RutaComprobante & "] " & x)
        End Try
    End Function

    Public Function getToken(clave As String, Tipo As String, CodSeguridad As String, refresh As Boolean) As String
        Try
            VariablesGlobales.Obj_Log.Log("[" & CodSeguridad & " ] getToken", "FE")

            Dim iTokenHacienda As New TokenHacienda
            iTokenHacienda.GetTokenHacienda(VariablesGlobales.ATV_Usuario, VariablesGlobales.ATV_Password, Tipo, CodSeguridad, refresh)

            Return iTokenHacienda.accessToken 'devuelve el AccesToken pero solo dura 5min
            'Return iTokenHacienda.refreshToken 'Devuelve el Refresh token ya que dura 10 horas

        Catch ex As Exception
            VariablesGlobales.Obj_Log.Log("ERROR getToken [" & ex.Message & " ]", Tipo)

            Dim obj_Fecha As New FechaManager
            'Se guarda el encabezado del comprobante con la fecha y hora del estado
            Obj_Funciones.GuardaComprobanteEnBitacora(Tipo, clave, "Error", obj_Fecha.FormatoFechaSql(Date.Now), "No se pudo obtener el toquen para el comprobante [" & clave & " ] ", DateTime.Now.ToString("hh:mm"))
            obj_Fecha = Nothing

            If Tipo = "FE" Then
                'VariablesGlobales.Obj_TestFactura.List_FE.Items.Insert(0, "ERROR en getToken  [ " & ex.Message & "] Factura [" & CodSeguridad & "] [ " & Now & " ]")
            ElseIf Tipo = "FES" Then
                'VariablesGlobales.Obj_TestFactura.List_FES.Items.Insert(0, "ERROR en getToken  [ " & ex.Message & " ] Factura de servicio [" & CodSeguridad & "][ " & Now & " ]")
            ElseIf Tipo = "NC" Then
                'VariablesGlobales.Obj_TestFactura.List_NC.Items.Insert(0, "ERROR en getToken  [ " & ex.Message & " ] Nota Credito [" & CodSeguridad & "][ " & Now & " ]")
            ElseIf Tipo = "NCS" Then
                'VariablesGlobales.Obj_TestFactura.List_NCS.Items.Insert(0, "ERROR en getToken  [ " & ex.Message & " ] Nota Credito de servicio [" & CodSeguridad & "][ " & Now & " ]")
            ElseIf Tipo = "ND" Then
                ' VariablesGlobales.Obj_TestFactura.List_ND.Items.Insert(0, "ERROR en getToken  [ " & ex.Message & " ] Nota debito [" & CodSeguridad & "][ " & Now & " ]")
            ElseIf Tipo = "NDS" Then
                ' VariablesGlobales.Obj_TestFactura.List_NDS.Items.Insert(0, "ERROR en getToken  [ " & ex.Message & " ] Nota Credito de servicio [" & CodSeguridad & "][ " & Now & " ]")
            ElseIf Tipo = "TE" Then
                'VariablesGlobales.Obj_TestFactura.List_TE.Items.Insert(0, "ERROR EN getToken  [ " & ex.Message & " ]")
            Else
                'MsgBox("ERROR en getToken [ " & ex.Message & " ]")
            End If

            'Throw
        End Try
    End Function


    'OBTIENE UN RESUMEN DE TODOS LOS COMPROBANTES ENVIADOS
    Public Function ListaComprobantesEnHacienda(offset As String, ByVal limit As String, CedEmisor As String, clave As String)
        Try
            ' Dim URL_RECEPCION As String = "https://api.comprobanteselectronicos.go.cr/recepcion-sandbox/v1/comprobantes"
            ' Dim URL_RECEPCION As String = "https://api.comprobanteselectronicos.go.cr/recepcion/v1/comprobantes"


            Dim Obj_Fecha As New FechaManager
            Dim URL_RECEPCION As String = VariablesGlobales.URL_RECEPCION & "comprobantes"
            Dim Continuar As Boolean = False ' indica si se consitnua o no basado en si encontro o no registros
            Dim http As HttpClient = New HttpClient
            Dim Msj As String
            Dim res As String
            Dim Localizacion As Integer
            Dim ReasonPhrase As String
            Dim response As HttpResponseMessage
            xmlRH = New Xml.XmlDocument

            If VariablesGlobales.TOKEN = "" Then 'Si el token es vacio es por que no se ha pedido ninguna vez
                VariablesGlobales.TOKEN = getToken("", "", "", False)
            End If
            Do
                http = New HttpClient
                xmlRH = New Xml.XmlDocument
                http.DefaultRequestHeaders.Add("authorization", "Bearer " + VariablesGlobales.TOKEN)
                'CONSULTA LOS DATOS DE UN COMPROBANTE X SU CLAVE

                If clave <> "" Then
                    response = http.GetAsync(URL_RECEPCION & "/"&clave).Result
                Else
                    response = http.GetAsync(URL_RECEPCION & "?offset=" & offset & "&limit=" & limit & "&emisor=" & CedEmisor).Result
                End If



                res = response.Content.ReadAsStringAsync.Result



                Localizacion = CInt(response.StatusCode)
                ReasonPhrase = response.ReasonPhrase
                jsonRespuesta = res.ToString
                If Localizacion = 401 And ReasonPhrase = "Unauthorized" Then '"error": "Key not authorized: Token is expired" el error 401 indica que el token expito

                    VariablesGlobales.TOKEN = getToken("", "", "", True)

                    xmlRH = Nothing
                    http = Nothing
                    Localizacion = Nothing
                    ReasonPhrase = Nothing
                    jsonRespuesta = Nothing
                    res = Nothing
                Else
                    Exit Do
                End If

            Loop While Localizacion <> 401
            If Localizacion <> 206 Then
                'res = "" Or response.ReasonPhrase = "Bad Gateway" Or response.ReasonPhrase = "Bad Request" Or response.ReasonPhrase = "Origin Connection Time-out" 
                If response.ReasonPhrase = "Bad Request" Or response.ReasonPhrase = "Bad Gateway" Or response.ReasonPhrase = "Origin Connection Time-out" Or response.ReasonPhrase = "Internal Server Error" Then
                    'Si entra es por que hacienda se callo y no da respuesta
                    Msj = "Hacienda no responde :" & response.ReasonPhrase
                    statusCode = Localizacion
                    'Lo siguiente sirve , el comprobante agarra estado procesand o recibido y a la hora de reconsultar el estado da un Bad Request por alguna razon
                    'Evita poner estado Desconocido ya que este regeneraria el comprobante y borraria de sql el comprobante
                    'If EstaoAnterior = "recibido" Or EstaoAnterior = "procesando" Then
                    '    estadoFactura = EstaoAnterior 'El estado recibido ò procesando solo probocara que el sistema este consultando el estado del comprobante hasta que diga aceptado,rechazado ò error
                    'Else
                    '    estadoFactura = "Desconocido" 'Este estao probocara que el sistema Regenere el comprobante
                    'End If


                Else
                    Dim headers As HttpHeaders = response.Headers
                    Dim values As IEnumerable(Of String)

                    If headers.TryGetValues("X-Error-Cause", values) Then
                        Msj = values.First()
                    Else
                        Msj = jsonRespuesta
                    End If
                    If headers.TryGetValues("X-Http-Status", values) Then
                        statusCode = values.First()

                    Else
                        statusCode = Localizacion
                    End If

                    estadoFactura = ReasonPhrase
                    'Dim RH2 As RespuestaHacienda2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of RespuestaHacienda2)(response.Headers.ToString)
                    'If RH2.X_Error_Cause <> "" Then
                    '    xmlRespuesta = Funciones.DecodeBase64ToXML(RH2.X_Error_Cause)
                    'End If

                    'estadoFactura = RH2.X_Http_Status
                    'statusCode = response.StatusCode

                End If

                mensajeRespuesta = "Confirmación: " & statusCode & vbCrLf
                mensajeRespuesta += "Estado: " & estadoFactura & vbCrLf
                mensajeRespuesta += "Mensaje: " & Msj & vbCrLf
                MensajeDetalle = Msj & vbCrLf


            Else

                Dim result2 = Newtonsoft.Json.JsonConvert.DeserializeObject(res)

                Dim cont As Integer = 0
                Dim Var_clave As String
                Dim Var_fecha As String
                Dim Var_emisor_tipoIdentificacion As String
                Dim Var_emisor_numeroIdentificacion As String
                Dim Var_emisor_nombre As String
                Dim Var_receptor_tipoIdentificacion As String
                Dim Var_receptor_numeroIdentificacion As String
                Dim Var_receptor_nombre As String
                Dim Var_notasCredito_clave As String
                Dim Var_notasCredito_fecha As String
                Dim Var_notasDebito_clave As String
                Dim Var_notasDebito_fecha As String

                Dim Fecha_Creacion As String
                Dim CodSeguridad As String
                Dim Tipo As String
                While cont <= result2.Count - 1
                    Continuar = True

                    Var_clave = result2(cont)("clave")
                    CodSeguridad = Var_clave.Substring(42, 8)
                    Tipo = Var_clave.Substring(29, 2)
                    Var_fecha = result2(cont)("fecha")
                    Fecha_Creacion = Obj_Fecha.FormatoFechaSql(Var_fecha.Substring(0, 10))
                    Var_emisor_tipoIdentificacion = result2(cont)("emisor")("tipoIdentificacion")
                    Var_emisor_numeroIdentificacion = result2(cont)("emisor")("numeroIdentificacion")
                    Var_emisor_nombre = result2(cont)("emisor")("nombre")
                    Try

                        Var_receptor_tipoIdentificacion = result2(cont)("receptor")("tipoIdentificacion")
                        Var_receptor_numeroIdentificacion = result2(cont)("receptor")("numeroIdentificacion")
                        Var_receptor_nombre = result2(cont)("receptor")("nombre")
                    Catch ex As Exception

                    End Try
                    Try
                        'Recorre todas las NC aplicadas a la factura
                        For Each Site In result2(cont)("notasCredito")

                            Var_notasCredito_clave = Site("clave").ToString()
                            Var_notasCredito_fecha = Site("fecha").ToString()

                            'CodSeguridad = Site("clave").ToString().Substring(42, 8)
                            'Tipo = Site("clave").ToString().Substring(29, 2)
                            'Var_fecha = Obj_Fecha.FormatoFechaSql(Site("fecha").ToString().Substring(0, 10))
                            'INSERTAREMOS LA NC para poder luego hacer el marth
                            'Class_VariablesGlobales.Obj_Funciones_SQL.InsertaComprobanteENHACIENDA(Class_VariablesGlobales.SQL_Comman1, Var_notasCredito_clave, Var_notasCredito_fecha, Var_emisor_tipoIdentificacion, Var_emisor_numeroIdentificacion, Var_emisor_nombre, Var_receptor_tipoIdentificacion, Var_receptor_numeroIdentificacion, Var_receptor_nombre, "", "", "", "", Obj_Fecha.FormatoFechaSql(Site("fecha").ToString().Substring(0, 10)), Site("clave").ToString().Substring(42, 8), Site("clave").ToString().Substring(29, 2))
                        Next

                    Catch ex As Exception

                    End Try

                    Try
                        'recorre todas las ND aplicadas a la factura
                        For Each Site2 In result2(cont)("notasDebito")
                            ' use `Site` in this loop body
                            Var_notasDebito_clave = Site2("clave").ToString()
                            Var_notasDebito_fecha = Site2("fecha").ToString()
                            'CodSeguridad = Site("clave").ToString().Substring(42, 8)
                            'Tipo = Site("clave").ToString().Substring(29, 2)
                            'Var_fecha = Obj_Fecha.FormatoFechaSql(Site("fecha").ToString().Substring(0, 10))
                            'INSERTAREMOS LA NC para poder luego hacer el marth
                            'Class_VariablesGlobales.Obj_Funciones_SQL.InsertaComprobanteENHACIENDA(Class_VariablesGlobales.SQL_Comman1, Var_notasDebito_clave, Var_notasDebito_fecha, Var_emisor_tipoIdentificacion, Var_emisor_numeroIdentificacion, Var_emisor_nombre, Var_receptor_tipoIdentificacion, Var_receptor_numeroIdentificacion, Var_receptor_nombre, "", "", "", "", Obj_Fecha.FormatoFechaSql(Site2("fecha").ToString().Substring(0, 10)), Site2("clave").ToString().Substring(42, 8), Site2("clave").ToString().Substring(29, 2))

                        Next

                    Catch ex As Exception

                    End Try


                    'Class_VariablesGlobales.Obj_Funciones_SQL.InsertaComprobanteENHACIENDA(Class_VariablesGlobales.SQL_Comman1, Var_clave, Var_fecha, Var_emisor_tipoIdentificacion, Var_emisor_numeroIdentificacion, Var_emisor_nombre, Var_receptor_tipoIdentificacion, Var_receptor_numeroIdentificacion, Var_receptor_nombre, Var_notasCredito_clave, Var_notasCredito_fecha, Var_notasDebito_clave, Var_notasDebito_fecha, Fecha_Creacion, CodSeguridad, Tipo)

                    Var_clave = ""
                    Var_fecha = ""
                    Var_emisor_tipoIdentificacion = ""
                    Var_emisor_numeroIdentificacion = ""
                    Var_emisor_nombre = ""
                    Var_receptor_tipoIdentificacion = ""
                    Var_receptor_numeroIdentificacion = ""
                    Var_receptor_nombre = ""
                    Var_notasCredito_clave = ""
                    Var_notasCredito_fecha = ""
                    Var_notasDebito_clave = ""
                    Var_notasDebito_fecha = ""
                    Fecha_Creacion = ""
                    CodSeguridad = ""
                    Tipo = ""
                    cont += 1
                End While


                Class_VariablesGlobales.frmInv_Math_Hacienda.DataGV_Comprobantes.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ComprobanteENHACIENDA(Class_VariablesGlobales.SQL_Comman1)



                Var_clave = Nothing
                Var_fecha = Nothing
                Var_emisor_tipoIdentificacion = Nothing
                Var_emisor_numeroIdentificacion = Nothing
                Var_emisor_nombre = Nothing
                Var_receptor_tipoIdentificacion = Nothing
                Var_receptor_numeroIdentificacion = Nothing
                Var_receptor_nombre = Nothing
                Var_notasCredito_clave = Nothing
                Var_notasCredito_fecha = Nothing
                Var_notasDebito_clave = Nothing
                Var_notasDebito_fecha = Nothing
                Fecha_Creacion = Nothing
                CodSeguridad = Nothing
                result2 = Nothing
            End If
            Return Continuar

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function CargaDatosXML_MensajeHacienda(XML As String, Tipo As String, Consecutivo As String)
            Try
                Dim Mensaje As String
                Dim xmlEnvia As New Xml.XmlDocument
                xmlEnvia.LoadXml(XML)

                Mensaje = xmlEnvia.GetElementsByTagName("DetalleMensaje")(0).InnerText
                Return Mensaje.ToString.Trim


            Catch ex As Exception


                If Tipo = "FE" Then
                    'VariablesGlobales.Obj_TestFactura.List_FE.Items.Insert(0, "ERROR En CargaDatosXML_MensajeHacienda [ " & Consecutivo & " ] [ " & ex.Message & "]  Hora [" & DateTime.Now & "]")
                ElseIf Tipo = "FES" Then
                    'VariablesGlobales.Obj_TestFactura.List_FES.Items.Insert(0, "ERROR En CargaDatosXML_MensajeHacienda [ " & Consecutivo & " ] [ " & ex.Message & "] Hora [" & DateTime.Now & "]")
                ElseIf Tipo = "NC" Then
                    'VariablesGlobales.Obj_TestFactura.List_NC.Items.Insert(0, "ERROR En CargaDatosXML_MensajeHacienda [ " & Consecutivo & " ] [ " & ex.Message & "] Hora [" & DateTime.Now & "]")
                ElseIf Tipo = "NCS" Then
                    'VariablesGlobales.Obj_TestFactura.List_NCS.Items.Insert(0, "ERROR En CargaDatosXML_MensajeHacienda [ " & Consecutivo & " ] [ " & ex.Message & "] Hora [" & DateTime.Now & "]")
                ElseIf Tipo = "ND" Then
                    'VariablesGlobales.Obj_TestFactura.List_ND.Items.Insert(0, "ERROR En CargaDatosXML_MensajeHacienda [ " & Consecutivo & " ] [ " & ex.Message & "]  Hora [" & DateTime.Now & "]")
                ElseIf Tipo = "NDS" Then
                    'VariablesGlobales.Obj_TestFactura.List_NDS.Items.Insert(0, "ERROR En CargaDatosXML_MensajeHacienda [ " & Consecutivo & " ] [ " & ex.Message & "] Hora [" & DateTime.Now & "]")
                ElseIf Tipo = "TE" Then
                    'TestFacturaXMLCR.List_TE.Items.Insert(0, "ERROR En Procesa  [ " & Consecutivo & " ] [ " & ex.Message & " ]  Hora [" & DateTime.Now & "]")
                Else
                    MsgBox("ERROR en CargaDatosXML_MensajeHacienda [ " & ex.Message & "]  Hora [" & DateTime.Now & "]")
                End If

                Return "Error en CargaDatosXML_MensajeHacienda , al leer el XML [ " & Consecutivo & " ] [ " & ex.Message & "]  Hora [" & DateTime.Now & "]"
            End Try

        End Function

    End Class
