

Imports System.IO
Imports System.Threading

Public Class Acepta_Rechaza

    Public CondicionImpuesto As String
    Public Obj_Funciones As New Class_funcionesSQL

    Private Sub Acepta_Rechaza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Limpiar()
        Class_VariablesGlobales.frmLista_FE_Proveedores = New Acepta_Rechaza_Lista_Comprobantes
        Class_VariablesGlobales.frmLista_FE_Proveedores.MdiParent = Principal
        Class_VariablesGlobales.frmLista_FE_Proveedores.Show()
    End Sub




    Public Function ProcesaMensajeReceptor(Xml As String, Tipo As String, TipoCedulaEmisor As String, TipoCedulaReceptor As String)
        Try
            Dim Err As Boolean = False
            If CargaDatosXML_MensajeReceptor(Xml) = True Then
                ProcesaMR(Xml, TipoCedulaEmisor, TipoCedulaReceptor)
            Else
                Err = True
            End If
            Return Err
        Catch ex As Exception
            MsgBox("ERROR ProcesaMensajeReceptor : " & ex.Message)
            Return Err()
        End Try
    End Function


    Public Sub ProcesaMR(xml_Comprobante As String, TipoCedulaEmisor As String, TipoCedulaReceptor As String)
        Try
            Dim Path As String
            Path = VariablesGlobales.Patch_MR & "\"
            Dim directorio As String = Path
            Dim nombreArchivo As String = Me.Txt_NumeroConsecutivoReceptor.Text
            Dim enviaFactura As New Comunicacion
            '******** SE PROCEDE A GENERAR EL XML DEL COMPROBANTE SIN FIRMAR *******************
            'Crea una carpeta con el nombre de la clave del comprobante esta contendra el Documento FE y los mensajes de hacienda y cliente
            If File.Exists(directorio & nombreArchivo) = False Then
                My.Computer.FileSystem.CreateDirectory(directorio & nombreArchivo)
            End If

            Dim xmlElectronica As New Xml.XmlDocument
            'manda la carpeta con la clave como nombre y le manda la clave para que genere los arhivos
            xmlElectronica = enviaFactura.GeneraArchivosEnvio(directorio & nombreArchivo & "\" & nombreArchivo, xml_Comprobante)
            Me.Txt_MLFirmado.Text = xmlElectronica.OuterXml 'contenido del xml del MR

            '******************* SE GENERA EL JSON PARA ENVIAR INFOR A HACIENDA *********************************

            Dim myEmisor As New Emisor With {
                .numeroIdentificacion = Txt_CedulaEmisor.Text,
                .TipoIdentificacion = TipoCedulaEmisor
            }

            Dim myReceptor As New Receptor With {
                .numeroIdentificacion = Me.Txt_CedulaReceptor.Text,
                .TipoIdentificacion = TipoCedulaReceptor
            }

            Dim myRecepcion As New Recepcion With {
             .emisor = myEmisor,
            .receptor = myReceptor,
            .clave = Me.Txt_Clave.Text,
            .fecha = Me.Txt_FechaEmisionDoc.Text,'*************** FECHA LLEGA NULL **************
            .consecutivoReceptor = Me.Txt_NumeroConsecutivoReceptor.Text,
            .comprobanteXml = Funciones.EncodeStrToBase64(xmlElectronica.OuterXml)
            }

            xmlElectronica = Nothing

            Dim Token As String = ""
            Token = getToken("MR")
            Me.Txt_TokenHacienda.Text = Token

            'crea objeto de la clase comunicacion para enviar datos
            'Dim enviaFactura As New Comunicacion
            'enviaFactura.GeneraArchivosEnvio(directorio & nombreArchivo, xml_Comprobante)

            Dim obj_Fecha As New FechaManager
            'Se guarda el encabezado del comprobante con la fecha y hora del estado
            Obj_Funciones.GuardaComprobanteEnBitacora("MR", Me.Txt_Clave.Text, "Enviando", obj_Fecha.FormatoFechaSql(Date.Now), "El comprobante [MR] se enviara a hacienda", DateTime.Now.ToString("hh:mm"))
            obj_Fecha = Nothing

            enviaFactura.EnvioDatos(Token, myRecepcion, directorio & nombreArchivo & "\" & nombreArchivo, "MR")


        Catch ex As Exception
            VariablesGlobales.Obj_Log.Log("ERROR en ProcesaMR [ " & ex.Message & " ]", "MR")
            MessageBox.Show("ERROR en ProcesaMR [ " & ex.Message & " ]")
        End Try
    End Sub


    Public Function getToken(Tipo As String) As String
        Try
            '********** OJO REVISAR EL TEMAN DEL TOKEN YAQUE SE ESTA MANENAJDO MAL PARA LA 4.3 EN ACEPTACION ******************
            '********** OJO REVISAR EL TEMAN DEL TOKEN YAQUE SE ESTA MANENAJDO MAL PARA LA 4.3 EN ACEPTACION ******************
            '********** OJO REVISAR EL TEMAN DEL TOKEN YAQUE SE ESTA MANENAJDO MAL PARA LA 4.3 EN ACEPTACION ******************
            '********** OJO REVISAR EL TEMAN DEL TOKEN YAQUE SE ESTA MANENAJDO MAL PARA LA 4.3 EN ACEPTACION ******************

            Dim iTokenHacienda As New TokenHacienda
            iTokenHacienda.GetTokenHacienda(VariablesGlobales.ATV_Usuario, VariablesGlobales.ATV_Password, Tipo, Me.Txt_Clave.Text, False)
            Return iTokenHacienda.accessToken
        Catch ex As Exception
            VariablesGlobales.Obj_Log.Log("ERROR getToken [ " & ex.Message & " ]", Tipo)
            Dim obj_Fecha As New FechaManager
            'Se guarda el encabezado del comprobante con la fecha y hora del estado
            Obj_Funciones.GuardaComprobanteEnBitacora(Tipo, Me.Txt_Clave.Text, "Error", obj_Fecha.FormatoFechaSql(Date.Now), "No se pudo obtener el toquen para el comprobante [" & Me.Txt_Clave.Text & " ] ", DateTime.Now.ToString("hh:mm"))
            obj_Fecha = Nothing
            Throw
        End Try
    End Function


    Public Function CargaDatosXML_MensajeHacienda(XML As String)
        Try
            Dim Mensaje As String
            Dim xmlEnvia As New Xml.XmlDocument
            xmlEnvia.LoadXml(XML)

            Mensaje = xmlEnvia.GetElementsByTagName("DetalleMensaje")(0).InnerText
            Return Mensaje.ToString.Trim


        Catch ex As Exception
            Throw
        End Try

    End Function

    Private Function CargaDatosXML_MensajeReceptor(XML As String)
        Try
            Dim Completo As Boolean = False

            Dim xmlEnvia As New Xml.XmlDocument
            xmlEnvia.LoadXml(XML)
            Me.Txt_Clave.Text = xmlEnvia.GetElementsByTagName("Clave")(0).InnerText
            Me.Txt_CedulaEmisor.Text = xmlEnvia.GetElementsByTagName("NumeroCedulaEmisor")(0).InnerText
            Me.Txt_FechaEmisionDoc.Text = xmlEnvia.GetElementsByTagName("FechaEmisionDoc")(0).InnerText
            ' Me.Txt_Mensaje.Text = xmlEnvia.GetElementsByTagName("Mensaje")(0).InnerText

            Me.Txt_DetalleMensaje.Text = xmlEnvia.GetElementsByTagName("DetalleMensaje")(0).InnerText
            Try
                Me.Txt_MontoTotalImpuesto.Text = xmlEnvia.GetElementsByTagName("MontoTotalImpuesto")(0).InnerText
            Catch ex As Exception
                Me.Txt_MontoTotalImpuesto.Text = "0.00"
            End Try

            Me.Txt_TotalFactura.Text = xmlEnvia.GetElementsByTagName("TotalFactura")(0).InnerText
            Me.Txt_CedulaReceptor.Text = xmlEnvia.GetElementsByTagName("NumeroCedulaReceptor")(0).InnerText
            Me.Txt_NumeroConsecutivoReceptor.Text = xmlEnvia.GetElementsByTagName("NumeroConsecutivoReceptor")(0).InnerText
            Completo = True
            Return Completo
        Catch ex As Exception
            MsgBox("ERROR. CargaDatosXML_MensajeReceptor " & ex.Message)
            Return False
        End Try
    End Function

    Public Function Aceptar()
        Try


            Cursor = Cursors.WaitCursor
            Dim Obj_xml As New XML_Generator
            lbl_Estado.Text = "Comprobante Aceptado"
            Lbl_Procesando.Visible = True
            Lbl_Procesando.Text = "Procesando solicitud, porfavor espere.... "
            btn_ConsultarEstadoMH.Visible = False
            Panel_Acciones.Visible = False
            VariablesGlobales.Obj_Log.Log("Aceptar Comprobante Clave ( " & Txt_Clave.Text & " )", "MR")


            If Trim(CBox_CondicionImpuesto.Text) = "General Credito IVA" Then
                CondicionImpuesto = "01"
            End If
            If Trim(CBox_CondicionImpuesto.Text) = "General Crédito parcial del IVA" Then
                CondicionImpuesto = "02"
            End If
            If Trim(CBox_CondicionImpuesto.Text) = "Bienes de Capital" Then
                CondicionImpuesto = "03"
            End If
            If Trim(CBox_CondicionImpuesto.Text) = "Gasto corriente no genera crédito" Then
                CondicionImpuesto = "04"
            End If
            If Trim(CBox_CondicionImpuesto.Text) = "Proporcionalidad" Then
                CondicionImpuesto = "05"
            End If



            'CDbl(TotalFactura).ToString(“##,##0.00”)
            'Format(Convert.ToDouble(Txt_TotalFactura.Text), "##,##00.00")
            Obj_Funciones.Guarda_Comprobantes_MR(Txt_Clave.Text, Txtb_ConsecutivoComprobante.Text, Txt_NumeroConsecutivoReceptor.Text, Txt_FechaEmisionDoc.Text, Txtb_TipoComprobante.Text, Txt_TipoCedEmisor.Text, Txt_CedulaEmisor.Text, Txt_NombreEmisor.Text, txtb_CorreoEmirosr.Text, Txtb_TipoComprobante.Text, lbl_Estado.Text, Txt_TipoCedReceptor.Text, Txt_NombreRecetor.Text, txtb_CorreoReceptor.Text, Txt_MontoTotalImpuesto.Text, Txt_TotalFactura.Text, txtb_MHEstado.Text, txtb_MHFecha.Text, txtb_MHMensaje.Text, Txt_CedulaReceptor.Text, Txt_CodigoActividadEmisor.Text, CondicionImpuesto, Txt_MontoTotalImpuestoAcreditarReceptor.Text, Txt_MontoTotalDeGastoAplicableReceptor.Text)
            Obj_xml.GeneraMR(Txt_Clave.Text, Txt_TipoCedEmisor.Text, Txt_CedulaEmisor.Text, Txt_FechaEmisionDoc.Text, txtb_CorreoEmirosr.Text, Txt_TipoCedReceptor.Text, Txt_CedulaReceptor.Text, Txt_MontoTotalImpuesto.Text, Txt_TotalFactura.Text, "1", Txt_DetalleMensaje.Text, "MR_Aceptado", Txt_CodigoActividadEmisor.Text, CondicionImpuesto, Txt_MontoTotalImpuestoAcreditarReceptor.Text, Txt_MontoTotalDeGastoAplicableReceptor.Text)


            Obj_xml = Nothing
            btn_ConsultarEstadoMH.Visible = True
            Panel_Acciones.Visible = True
            Lbl_Procesando.Visible = False
            Cursor = Cursors.Default
            Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.btn_aceptar.Visible = False
            Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.btn_aceptarparcial.Visible = False
            Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.btn_rechaza.Visible = False

            MessageBox.Show("Proceso finalizado")

        Catch ex As Exception
            MessageBox.Show("ERRRO EN Aceptar, " & ex.Message)
        End Try
    End Function
    Public Function AceptarParcial()
        Try
            Cursor = Cursors.WaitCursor
            Dim Obj_xml As New XML_Generator
            Lbl_Procesando.Visible = True
            Lbl_Procesando.Text = "Procesando solicitud, porfavor espere.... "
            btn_ConsultarEstadoMH.Visible = False
            Panel_Acciones.Visible = False

            lbl_Estado.Text = "Comprobante Parcialmente Aceptado"

            Obj_xml.GeneraMR(Txt_Clave.Text, Txt_TipoCedEmisor.Text, Txt_CedulaEmisor.Text, Txt_FechaEmisionDoc.Text, txtb_CorreoEmirosr.Text, Txt_TipoCedReceptor.Text, Txt_CedulaReceptor.Text, Txt_MontoTotalImpuesto.Text, Txt_TotalFactura.Text, "2", Txt_DetalleMensaje.Text, "MR_Aceptado_Parcial", Txt_CodigoActividadEmisor.Text, CondicionImpuesto, Txt_MontoTotalImpuesto.Text, Txt_MontoTotalImpuesto.Text)
            Obj_Funciones.Guarda_Comprobantes_MR(Txt_Clave.Text, Txtb_ConsecutivoComprobante.Text, Txt_NumeroConsecutivoReceptor.Text, Txt_FechaEmisionDoc.Text, Txtb_TipoComprobante.Text, Txt_TipoCedEmisor.Text, Txt_CedulaEmisor.Text, Txt_NombreEmisor.Text, txtb_CorreoEmirosr.Text, Txtb_TipoComprobante.Text, lbl_Estado.Text, Txt_TipoCedReceptor.Text, Txt_NombreRecetor.Text, txtb_CorreoReceptor.Text, Txt_MontoTotalImpuesto.Text, Txt_TotalFactura.Text, txtb_MHEstado.Text, txtb_MHFecha.Text, txtb_MHMensaje.Text, Txt_CedulaReceptor.Text, Txt_CodigoActividadEmisor.Text, CondicionImpuesto, Txt_MontoTotalImpuesto.Text, Txt_MontoTotalImpuesto.Text)
            Obj_xml = Nothing
            Cursor = Cursors.Default
            Panel_Acciones.Visible = True
            Lbl_Procesando.Visible = False
            btn_ConsultarEstadoMH.Visible = True
            MessageBox.Show("Proceso finalizado")
        Catch ex As Exception
            MessageBox.Show("ERRRO EN AceptarParcial, " & ex.Message)
        End Try
    End Function
    Public Function Rechazar()
        Try
            Cursor = Cursors.WaitCursor
            Dim Obj_xml As New XML_Generator
            Lbl_Procesando.Visible = True
            Lbl_Procesando.Text = "Procesando solicitud, porfavor espere.... "
            btn_ConsultarEstadoMH.Visible = False
            Panel_Acciones.Visible = False

            lbl_Estado.Text = "Rechazado"
            Obj_xml.GeneraMR(Txt_Clave.Text, Txt_TipoCedEmisor.Text, Txt_CedulaEmisor.Text, Txt_FechaEmisionDoc.Text, txtb_CorreoEmirosr.Text, Txt_TipoCedReceptor.Text, Txt_CedulaReceptor.Text, Txt_MontoTotalImpuesto.Text, Txt_TotalFactura.Text, "3", Txt_DetalleMensaje.Text, "MR_Rechazado", Txt_CodigoActividadEmisor.Text, CondicionImpuesto, Txt_MontoTotalImpuestoAcreditarReceptor.Text,Txt_MontoTotalDeGastoAplicableReceptor.text)
            Obj_Funciones.Guarda_Comprobantes_MR(Txt_Clave.Text, Txtb_ConsecutivoComprobante.Text, Txt_NumeroConsecutivoReceptor.Text, Txt_FechaEmisionDoc.Text, Txtb_TipoComprobante.Text, Txt_TipoCedEmisor.Text, Txt_CedulaEmisor.Text, Txt_NombreEmisor.Text, txtb_CorreoEmirosr.Text, Txtb_TipoComprobante.Text, lbl_Estado.Text, Txt_TipoCedReceptor.Text, Txt_NombreRecetor.Text, txtb_CorreoReceptor.Text, Txt_MontoTotalImpuesto.Text, Txt_TotalFactura.Text, txtb_MHEstado.Text, txtb_MHFecha.Text, txtb_MHMensaje.Text, Txt_CedulaReceptor.Text, Txt_CodigoActividadEmisor.Text, CondicionImpuesto, Txt_MontoTotalImpuestoAcreditarReceptor.Text, Txt_MontoTotalDeGastoAplicableReceptor.Text)
            Obj_xml = Nothing
            Cursor = Cursors.Default
            Panel_Acciones.Visible = True
            Lbl_Procesando.Visible = False
            btn_ConsultarEstadoMH.Visible = True
            MessageBox.Show("Proceso finalizado")
        Catch ex As Exception
            MessageBox.Show("ERRRO EN Rechazar, " & ex.Message)
        End Try
    End Function

    Public Function Consultar()


        If Txt_Clave.Text <> "" Then

            Lbl_Procesando.Visible = True
            Lbl_Procesando.Text = "Procesando solicitud, porfavor espere.... "
            btn_ConsultarEstadoMH.Visible = False
            Panel_Acciones.Visible = False
            Cursor = Cursors.WaitCursor
            Dim enviaFactura As New Comunicacion
            Dim Token As String = ""
            Token = getToken("MR")
            Me.Txt_TokenHacienda.Text = Token


            enviaFactura.ConsultaEstatus(Token, Txt_Clave.Text, VariablesGlobales.Patch_MR & "\" & Me.Txt_NumeroConsecutivoReceptor.Text & "\" & Me.Txt_NumeroConsecutivoReceptor.Text, "MR", Txt_NumeroConsecutivoReceptor.Text)

            Cursor = Cursors.Default
            btn_ConsultarEstadoMH.Visible = True
            Panel_Acciones.Visible = True
            Lbl_Procesando.Visible = False

        End If
    End Function
    Private Sub btn_aceptar_Click(sender As Object, e As EventArgs) Handles btn_aceptar.Click

        Try
            If CBox_CondicionImpuesto.Text = "" Then
                MessageBox.Show("Debe indicar la Condicion del impuesto", "DATOS INCOMPLETOS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim Pregunta As Integer
                Pregunta = MsgBox("Esta apunto de ACEPTAR este comprobante, acción no se puede revestir " & vbCrLf & " ¿Esta Seguro que desea ACEPTAR este comprobante?.", vbYesNo + vbExclamation + vbDefaultButton2, "ACEPTAR COMPROBANTE")
                If Pregunta = vbYes Then
                    Dim Thread_aceptar As Thread
                    'hilo de ejecucion constante
                    Thread_aceptar = New Thread(AddressOf Aceptar)
                    Thread_aceptar.IsBackground = Enabled
                    'trd2.Priority = ThreadPriority.Highest
                    CheckForIllegalCrossThreadCalls = False
                    Thread_aceptar.Start()
                Else

                End If

                Pregunta = Nothing

            End If
        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN btn_aceptar_Click [ " & ex.Message & " ]")
        End Try



    End Sub
    Private Sub btn_aceptarparcial_Click(sender As Object, e As EventArgs) Handles btn_aceptarparcial.Click
        Try
            If CBox_CondicionImpuesto.Text = "" Then
                MessageBox.Show("Debe indicar la Condicion del impuesto", "DATOS INCOMPLETOS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else

                Dim Pregunta As Integer
                Pregunta = MsgBox("Esta apunto de ACEPTAR PARCIALMENTE este comprobante, acción no se puede revestir " & vbCrLf & " ¿Esta Seguro que desea ACEPTAR PARCIALMENTE este comprobante?.", vbYesNo + vbExclamation + vbDefaultButton2, "ACEPTAR PARCIALMENTE COMPROBANTE")

                If Pregunta = vbYes Then
                    Dim Thread_aceptarparcial As Thread


                    'hilo de ejecucion constante
                    Thread_aceptarparcial = New Thread(AddressOf AceptarParcial)
                    Thread_aceptarparcial.IsBackground = Enabled
                    'trd2.Priority = ThreadPriority.Highest
                    CheckForIllegalCrossThreadCalls = False
                    Thread_aceptarparcial.Start()
                Else

                End If

                Pregunta = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN btn_aceptarparcial_Click [ " & ex.Message & " ]")
        End Try


    End Sub
    Private Sub btn_rechaza_Click(sender As Object, e As EventArgs) Handles btn_rechaza.Click
        Try
            If CBox_CondicionImpuesto.Text = "" Then
                MessageBox.Show("Debe indicar la Condicion del impuesto", "DATOS INCOMPLETOS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Txt_DetalleMensaje.Text = "" Then
                MessageBox.Show("Debe indicar la razon del rechazo", "DATOS INCOMPLETOS", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else

                Dim Pregunta As Integer
                Pregunta = MsgBox("Esta apunto de RECHAZAR este comprobante, acción no se puede revestir " & vbCrLf & " ¿Esta Seguro que desea RECHAZAR este comprobante?.", vbYesNo + vbExclamation + vbDefaultButton2, "RECHAZAR COMPROBANTE")
                If Pregunta = vbYes Then
                    Dim Thread_rechaz As Thread
                    'hilo de ejecucion constante
                    Thread_rechaz = New Thread(AddressOf Rechazar)
                    Thread_rechaz.IsBackground = Enabled
                    'trd2.Priority = ThreadPriority.Highest
                    CheckForIllegalCrossThreadCalls = False
                    Thread_rechaz.Start()
                Else
                End If
                Pregunta = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN btn_rechaza_Click [ " & ex.Message & " ]")
        End Try
    End Sub
    Private Sub btn_ConsultarEstadoMH_Click(sender As Object, e As EventArgs) Handles btn_ConsultarEstadoMH.Click
        Try
            Dim Thread_Consultar As Thread
            'hilo de ejecucion constante
            Thread_Consultar = New Thread(AddressOf Consultar)
            Thread_Consultar.IsBackground = Enabled
            'trd2.Priority = ThreadPriority.Highest
            CheckForIllegalCrossThreadCalls = False
            Thread_Consultar.Start()

        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN btn_ConsultarEstadoMH_Click [ " & ex.Message & " ]")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        Limpiar()
    End Sub

    Public Function Limpiar()
        Me.Txt_Clave.Text = ""
        Me.Txtb_ConsecutivoComprobante.Text = ""
        Me.Txtb_TipoComprobante.Text = ""
        Me.Txt_NumeroConsecutivoReceptor.Text = ""
        Me.Txt_FechaEmisionDoc.Text = ""
        Me.Txt_TipoCedEmisor.Text = ""
        Me.Txt_TipoCedReceptor.Text = ""
        Me.Txt_CedulaEmisor.Text = ""
        Me.Txt_CedulaReceptor.Text = ""
        Me.Txt_NombreEmisor.Text = ""
        Me.Txt_NombreRecetor.Text = ""

        Me.txtb_CorreoEmirosr.Text = ""

        ' Me.Txt_Mensaje.Text = xmlEnvia.GetElementsByTagName("Mensaje")(0).InnerText

        Me.txtb_CorreoReceptor.Text = ""
        Me.Txt_MontoTotalImpuesto.Text = ""
        Me.Txt_TotalFactura.Text = ""
        Me.Txt_CedulaReceptor.Text = ""
        Me.Txt_DetalleMensaje.Text = ""

        Me.txtb_MHEstado.Text = ""
        Me.txtb_MHFecha.Text = ""
        Me.txtb_MHMensaje.Text = ""

        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.btn_aceptar.Visible = False
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.btn_aceptarparcial.Visible = False
        Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.btn_rechaza.Visible = False


    End Function

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btn_pdf.Click
        Try

            Dim loPSI As New ProcessStartInfo
            Dim loProceso As New Process
            loPSI.FileName = VariablesGlobales.Patch_PDFMR & "\" & Trim(Txt_Clave.Text) & ".pdf"
            Try
                loProceso = Process.Start(loPSI)
            Catch Exp As Exception
                MessageBox.Show(Exp.Message, "NO DISPONIBLE", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try



        Catch ex As Exception

        End Try
    End Sub

    Private Sub CBox_CondicionImpuesto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBox_CondicionImpuesto.SelectedIndexChanged
        Dim codigo As String

    End Sub
End Class