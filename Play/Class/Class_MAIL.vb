Imports System.Net.Mail
Imports System.Net
Imports Microsoft.Office.Interop

Public Class Class_MAIL


    Public Sub Envia_Cliente(Clave As String, Tipo As String, Asunto As String, ByVal Mensaje As String, Patch_XMLFE As String, Patch_PDFFE As String, Patch_RH As String)

        Try

            ' Capturo cada uno de los campos del formulario
            Dim TABLA As New DataTable
            TABLA = VariablesGlobales.Obj_SQL.ObtieneInfoEmmail(Class_VariablesGlobales.SQL_Comman2)
            ' Capturo cada uno de los campos del formulario
            Dim Usuario As String = Trim(TABLA.Rows(0).Item("correo").ToString())
            Dim Contraseña As String = Trim(TABLA.Rows(0).Item("ClaveEmail").ToString())
            Dim Tel1 As String = ""
            Dim Tel2 As String = ""
            If TABLA.Rows(0).Item("Telefono").ToString() <> "" Then
                Tel1 = Trim(TABLA.Rows(0).Item("Telefono").ToString())
            End If
            If TABLA.Rows(0).Item("Telefono2").ToString() <> "" Then
                Tel2 = Trim(TABLA.Rows(0).Item("Telefono2").ToString())
            End If

            TABLA = Nothing
            Dim SMTP As String = "smtp.gmail.com"

            Dim Puerto As Integer = 587

            'Declaro la variable para enviar el correo
            Dim correo As New System.Net.Mail.MailMessage()
            correo.From = New System.Net.Mail.MailAddress(Usuario)
            correo.Subject = "Su Factura electronica"
            correo.Subject = Asunto

            'Agrega la cuenta de corre del cliente
            If VariablesGlobales.EmisorEmail <> "" Then
                correo.To.Add(VariablesGlobales.EmisorEmail)

            End If

            If Patch_XMLFE <> "" Then
                Dim File_XMLFE As New System.Net.Mail.Attachment(Patch_XMLFE) 'XML del Comprobante
                correo.Attachments.Add(File_XMLFE) ''adjuntar archivo
            End If

            If Patch_RH <> "" Then
                Dim File_RH As New System.Net.Mail.Attachment(Patch_RH) 'Respuesta Hacienda del Comprobante Enviadp
                correo.Attachments.Add(File_RH) ''adjuntar archivo
            End If

            If Patch_PDFFE <> "" Then
                Dim File_PDFFE As New System.Net.Mail.Attachment(Patch_PDFFE) '
                correo.Attachments.Add(File_PDFFE) ''adjuntar archivo
            End If





            correo.Body = "Estimado cliente le adjuntamos su Factura electronica y el mensaje de aprobacion por parte de hacienda " & vbCrLf &
                            "Clave=" & Clave & vbCrLf &
                            "Para mas informacion comunicarse a la oficina a los numeros " & Tel1 & " / " & Tel2 & vbCrLf &
                            "Para mas informacion sobre el software de factura electronica al correo lurobaca@gmail.com con Luis Roberto Bastos Castillo " & vbCrLf

            'Configuracion del servidor
            Dim Servidor As New System.Net.Mail.SmtpClient
            Servidor.Host = SMTP
            Servidor.Port = Puerto
            Servidor.EnableSsl = True
            Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)

            If Now.DayOfWeek <> DayOfWeek.Sunday Then
                Servidor.Send(correo)
                'MsgBox("Correo enviado con exito")

                'ENVIADO
            Else
                'NO SE ENVIO
            End If


            Servidor = Nothing

            correo = Nothing
            Puerto = Nothing
            SMTP = Nothing
            Usuario = Nothing
            Contraseña = Nothing


        Catch ex As Exception

            MsgBox("ERROR AL ENVIA CORREO" & ex.Message)

        End Try



    End Sub
    Public Sub Envia_Alerta(Clave As String, Tipo As String, Asunto As String, ByVal Mensaje As String, Patch_XMLFE As String, Patch_PDFFE As String, Patch_RH As String)

        Try

            ' Capturo cada uno de los campos del formulario
            Dim TABLA As New DataTable
            TABLA = VariablesGlobales.Obj_SQL.ObtieneInfoEmmail(Class_VariablesGlobales.SQL_Comman2)
            ' Capturo cada uno de los campos del formulario
            Dim Usuario As String = Trim(TABLA.Rows(0).Item("correo").ToString())
            Dim Contraseña As String = Trim(TABLA.Rows(0).Item("ClaveEmail").ToString())
            TABLA = Nothing
            Dim SMTP As String = "smtp.gmail.com"

            Dim Destinatario1 As String
            Dim Destinatario2 As String
            Dim Destinatario3 As String



            Destinatario1 = ""
            Destinatario2 = ""
            Destinatario3 = ""
            'If Tipo = "FE" Then
            '    Asunto = "FACTURA NO SE ENVIO [ " & Clave & " ]"
            'End If
            'If Tipo = "NC" Then
            '    Asunto = "NOTA DE CREDITO NO SE ENVIO [ " & Clave & " ]"
            'End If
            'If Tipo = "ND" Then
            '    Asunto = "NOTA DE DEBITO NO SE ENVIO [ " & Clave & " ]"
            'End If

            Dim Puerto As Integer = 587

            'Declaro la variable para enviar el correo
            Dim correo As New System.Net.Mail.MailMessage()
            correo.From = New System.Net.Mail.MailAddress(Usuario)
            correo.Subject = "Su Factura electronica"
            correo.Subject = Asunto

            ' correo.To.Add(Destinatario1)
            correo.To.Add(Destinatario2)
            ' correo.To.Add(Destinatario3)
            'Agrega la cuenta de corre del cliente
            If VariablesGlobales.ReceptorEmail <> "" Then
                correo.To.Add(VariablesGlobales.ReceptorEmail)
            End If

            If Patch_XMLFE <> "" Then
                Dim File_XMLFE As New System.Net.Mail.Attachment(Patch_XMLFE) 'XML del Comprobante
                correo.Attachments.Add(File_XMLFE) ''adjuntar archivo
            End If

            If Patch_RH <> "" Then
                Dim File_RH As New System.Net.Mail.Attachment(Patch_RH) 'Respuesta Hacienda del Comprobante Enviadp
                correo.Attachments.Add(File_RH) ''adjuntar archivo
            End If

            If Patch_PDFFE <> "" Then
                Dim File_PDFFE As New System.Net.Mail.Attachment(Patch_PDFFE) '
                correo.Attachments.Add(File_PDFFE) ''adjuntar archivo
            End If
            correo.Body = Mensaje

            'Configuracion del servidor
            Dim Servidor As New System.Net.Mail.SmtpClient
            Servidor.Host = SMTP
            Servidor.Port = Puerto
            Servidor.EnableSsl = True
            Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)

            If Now.DayOfWeek <> DayOfWeek.Sunday Then
                Servidor.Send(correo)
                'ENVIADO
            Else
                'NO SE ENVIO
            End If


            Servidor = Nothing

            correo = Nothing
            Puerto = Nothing
            SMTP = Nothing
            Usuario = Nothing
            Contraseña = Nothing
            Destinatario1 = Nothing
            Destinatario2 = Nothing
            Destinatario3 = Nothing

        Catch ex As Exception

            MsgBox("ERROR AL ENVIA CORREO" & ex.Message)

        End Try



    End Sub

    Public Sub NotificaAProveedor(Asunto As String, ByVal Mensaje As String, CorreoProveedor As String, Path_XML_MR As String, XML_RH As String)

        Try

            ' Capturo cada uno de los campos del formulario
            Dim TABLA As New DataTable
            TABLA = VariablesGlobales.Obj_SQL.ObtieneInfoEmmail(Class_VariablesGlobales.SQL_Comman2)
            ' Capturo cada uno de los campos del formulario
            Dim Usuario As String = Trim(TABLA.Rows(0).Item("correo").ToString())
            Dim Contraseña As String = Trim(TABLA.Rows(0).Item("ClaveEmail").ToString())
            TABLA = Nothing
            Dim SMTP As String = "smtp.gmail.com"
            Dim Puerto As Integer = 587

            'Declaro la variable para enviar el correo
            Dim correo As New System.Net.Mail.MailMessage()
            correo.From = New System.Net.Mail.MailAddress(Usuario)
            correo.Subject = "Su Factura electronica"
            correo.Subject = Asunto


            ' correo.To.Add(Destinatario3)
            'Agrega la cuenta de corre del cliente
            If CorreoProveedor <> "" Then
                correo.To.Add(CorreoProveedor)
            End If

            If Path_XML_MR <> "" Then
                Dim File_XML_MR As New System.Net.Mail.Attachment(Path_XML_MR) 'XML del Comprobante
                correo.Attachments.Add(File_XML_MR) ''adjuntar archivo
            End If

            If XML_RH <> "" Then
                Dim File_RH As New System.Net.Mail.Attachment(XML_RH) 'Respuesta Hacienda del Comprobante Enviadp
                correo.Attachments.Add(File_RH) ''adjuntar archivo
            End If

            'If Patch_PDFFE <> "" Then
            '    Dim File_PDFFE As New System.Net.Mail.Attachment(Patch_PDFFE) '
            '    correo.Attachments.Add(File_PDFFE) ''adjuntar archivo
            'End If
            correo.Body = Mensaje

            'Configuracion del servidor
            Dim Servidor As New System.Net.Mail.SmtpClient
            Servidor.Host = SMTP
            Servidor.Port = Puerto
            Servidor.EnableSsl = True
            Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)

            If Now.DayOfWeek <> DayOfWeek.Sunday Then
                Servidor.Send(correo)
                'ENVIADO
            Else
                'NO SE ENVIO
            End If


            Servidor = Nothing

            correo = Nothing
            Puerto = Nothing
            SMTP = Nothing
            Usuario = Nothing
            Contraseña = Nothing



        Catch ex As Exception

            'MsgBox("ERROR AL ENVIA CORREO" & ex.Message)

        End Try



    End Sub

    Public Sub Envia_Alerta2(CodCliente As String, Agente As String, Clave As String, Tipo As String, Asunto As String, ByVal Mensaje As String)

        Try

            ' Capturo cada uno de los campos del formulario
            Dim TABLA As New DataTable
            TABLA = VariablesGlobales.Obj_SQL.ObtieneInfoEmmail(Class_VariablesGlobales.SQL_Comman2)
            ' Capturo cada uno de los campos del formulario
            Dim Usuario As String = Trim(TABLA.Rows(0).Item("correo").ToString())
            Dim Contraseña As String = Trim(TABLA.Rows(0).Item("ClaveEmail").ToString())
            TABLA = Nothing
            Dim SMTP As String = "smtp.gmail.com"

            Dim Destinatario1 As String
            Dim Destinatario2 As String
            Dim Destinatario3 As String
            Dim Destinatario4 As String

            Destinatario1 = ""
            Destinatario2 = ""
            Destinatario3 = ""
            Destinatario4 = ""

            'If Tipo = "FE" Then
            '    Asunto = "FACTURA NO SE ENVIO [ " & Clave & " ]"
            'End If
            'If Tipo = "NC" Then
            '    Asunto = "NOTA DE CREDITO NO SE ENVIO [ " & Clave & " ]"
            'End If
            'If Tipo = "ND" Then
            '    Asunto = "NOTA DE DEBITO NO SE ENVIO [ " & Clave & " ]"
            'End If

            Dim Puerto As Integer = 587

            'Declaro la variable para enviar el correo
            Dim correo As New System.Net.Mail.MailMessage()
            correo.From = New System.Net.Mail.MailAddress(Usuario)
            correo.Subject = "Correo de prueba"
            correo.Subject = Asunto

            ' correo.To.Add(Destinatario1)
            correo.To.Add(Destinatario2)
            ' correo.To.Add(Destinatario3)
            correo.To.Add(Destinatario4)

            correo.Body = Mensaje

            'Configuracion del servidor
            Dim Servidor As New System.Net.Mail.SmtpClient
            Servidor.Host = SMTP
            Servidor.Port = Puerto
            Servidor.EnableSsl = True
            Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)

            If Now.DayOfWeek <> DayOfWeek.Sunday Then
                Servidor.Send(correo)
                'ENVIADO
            Else
                'NO SE ENVIO
            End If


            Servidor = Nothing

            correo = Nothing
            Puerto = Nothing
            SMTP = Nothing
            Usuario = Nothing
            Contraseña = Nothing
            Destinatario1 = Nothing
            Destinatario2 = Nothing
            Destinatario3 = Nothing

        Catch ex As Exception

            MsgBox("ERROR AL ENVIA CORREO" & ex.Message)

        End Try



    End Sub

    'PARA ENVIAR CORREOS DESDE GMAIL
    Public Sub EnviarCorreo(ByVal Mensaje As String, ByVal Asunto As String, ByVal file As String, ByVal Destinatario1 As String, ByVal Destinatario2 As String, ByVal Destinatario3 As String, ByVal Destinatario4 As String)

        Try

            If Destinatario1.Equals("") And Destinatario2.Equals("") And Destinatario3.Equals("") And Destinatario4.Equals("") Then
                Exit Sub
                'no existe destinatario
            End If
            ' Capturo cada uno de los campos del formulario
            Dim TABLA As New DataTable
            TABLA = VariablesGlobales.Obj_SQL.ObtieneInfoEmmail(Class_VariablesGlobales.SQL_Comman2)
            ' Capturo cada uno de los campos del formulario
            Dim Usuario As String = Trim(TABLA.Rows(0).Item("correo").ToString())
            Dim Contraseña As String = Trim(TABLA.Rows(0).Item("ClaveEmail").ToString())
            TABLA = Nothing
            Dim SMTP As String = "smtp.gmail.com"
            'Dim archivo As New System.Net.Mail.Attachment(file) ''  ruta del achivo adjunto
            Dim Puerto As Integer = 587

            'Declaro la variable para enviar el correo
            Dim correo As New System.Net.Mail.MailMessage()
            correo.From = New System.Net.Mail.MailAddress(Usuario)
            correo.Subject = "Correo de prueba"
            correo.Subject = Asunto

            If Destinatario1 <> "" Then
                correo.To.Add(Destinatario1)
            End If
            If Destinatario2 <> "" Then
                correo.To.Add(Destinatario2)
            End If
            If Destinatario3 <> "" Then
                correo.To.Add(Destinatario3)
            End If
            If Destinatario4 <> "" Then
                correo.To.Add(Destinatario4)
            End If

            correo.Body = Mensaje
            'If file <> "" Then
            '    correo.Attachments.Add(archivo) ''adjuntar archivos 
            'End If

            'Configuracion del servidor
            Dim Servidor As New System.Net.Mail.SmtpClient
            Servidor.Host = SMTP
            Servidor.Port = Puerto
            Servidor.EnableSsl = True
            Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
            Servidor.Send(correo)



        Catch ex As Exception
            MsgBox("Error al enviar el correo, " & ex.Message)

        End Try




    End Sub


    'PARA ENVIAR CORREOS CON CUENTAS EMPRESARIARLES 
    Sub EnviarMail_Demo(ByVal Mensaje As String, ByVal Asunto As String, ByVal file As String, ByVal filePdf As String, ByVal Destinatario1 As String)
        Try
            Dim Correo As New MailMessage
            Correo.From = New MailAddress("")

            For Each mail As String In Destinatario1.Split(New Char() {","c})
                Correo.To.Add(New System.Net.Mail.MailAddress(mail))
            Next

            'If Destinatario1 <> "" Then
            '    Correo.To.Add(New MailAddress(Destinatario1))
            'End If
            'If Destinatario2 <> "" Then
            '    Correo.To.Add(New MailAddress(Destinatario2))
            'End If
            'If Destinatario3 <> "" Then
            '    Correo.To.Add(New MailAddress(Destinatario3))
            'End If
            'If Destinatario3 <> "" Then
            '    Correo.To.Add(New MailAddress(Destinatario4))
            'End If

            Correo.Attachments.Add(New Attachment(file)) 'adjuntar archivo
            Correo.Attachments.Add(New Attachment(filePdf)) 'adjuntar archivo
            Correo.Subject = Asunto

            Correo.Body = Mensaje

            ' Dim Cartero As New SmtpClient("mail.supremecluster.com")
            Dim SMTP As String = "smtp.gmail.com"
            'Dim archivo As New System.Net.Mail.Attachment(file) ''  ruta del achivo adjunto
            Dim Puerto As Integer = 587
            Dim Servidor As New System.Net.Mail.SmtpClient
            Servidor.Host = SMTP
            Servidor.Port = Puerto
            Servidor.EnableSsl = True
            Servidor.Credentials = New NetworkCredential("", "")

            Servidor.Send(Correo)
        Catch ex As Exception
            MsgBox("Error al enviar el correo, " & ex.Message)
        End Try
    End Sub


    Function AttachFilesbyEmailAutomatically(ByVal Mensaje As String, ByVal Asunto As String, ByVal file As String, ByVal filePdf As String, ByVal Destinatario1 As String)
        'Function AttachFilesbyEmailAutomatically()
        Dim log As String
        Try


            Dim fldName As String
            Dim fName As String
            Dim sAttName As String
            Dim strName As String

            Dim olApp As Outlook._Application
            Dim olMsg As Outlook.MailItem
            Dim olAtt As Outlook.Attachments

            log = log & "Crea variables " & vbCrLf

            olApp = New Outlook.Application
            log = log & "Crea olApp " & vbCrLf
            olMsg = olApp.CreateItem(0)
            log = log & "Crea olMsg " & vbCrLf
            olAtt = olMsg.Attachments
            log = log & "Crea olAtt " & vbCrLf

            'filePdf
            'file
            'Ruta donde se guardan los archivos
            'Dim file As String = "C:\Users\Luis Roberto Bastos\Documents\pedidos\CAFE BRITT COSTA RICA S.A\11855_Fecha_27_3_2020.pdf"
            'Dim filePdf As String = "C:\Users\Luis Roberto Bastos\Documents\pedidos\CAFE BRITT COSTA RICA S.A\11855_Fecha_27_3_2020.xls"

            '  fName = Dir(fldName)

            ' strName = InputBox("Digito contenido")

            ' Do While Len(fName) > 0

            'If InStr(fName, strName) > 0 Then
            Try

                olAtt.Add(file)
                log = log & "Agrega  " & file & vbCrLf
            Catch ex As Exception
                log = log & "erro al agregar  " & file & vbCrLf
            End Try

            '  fName = Dir()
            Try
                olAtt.Add(filePdf)
                log = log & "Agrega  " & filePdf & vbCrLf
            Catch ex As Exception
                log = log & "Error al agregar  " & filePdf & vbCrLf
            End Try

            'sAttName = filePdf ' & "-" & sAttName
            ' End If
            ' fName = Dir()
            ' Loop

            log = log & "empieza a crear olMsg  " & vbCrLf
            ' send message
            With olMsg
                .Subject = Asunto
                .To = Destinatario1
                .HTMLBody = Mensaje
                .Display() ' Marcar como comentario para envio automatico
                '.Send ' Desmarcar para envio automatico
            End With
        Catch ex As Exception
            MsgBox("Error al enviar el correo: AttachFilesbyEmailAutomatically , " & log & " : " & ex.Message)

        End Try
        Return 0
    End Function
    Public Sub NotificalicenciaVencida(ByVal Mensaje As String, ByVal Asunto As String)


        Try

            ' Capturo cada uno de los campos del formulario
            Dim SMTP As String = "smtp.gmail.com"
            Dim Usuario As String = "lurobaca@gmail.com"
            Dim Contraseña As String = "Bast1662"
            'Dim archivo As New System.Net.Mail.Attachment(file) ''  ruta del achivo adjunto
            Dim Puerto As Integer = 587

            'Declaro la variable para enviar el correo
            Dim correo As New System.Net.Mail.MailMessage()
            correo.From = New System.Net.Mail.MailAddress(Usuario)

            correo.Subject = Asunto


            correo.To.Add("lurobaca@gmail.com")



            correo.Body = Mensaje
            'If file <> "" Then
            '    correo.Attachments.Add(archivo) ''adjuntar archivos 
            'End If

            'Configuracion del servidor
            Dim Servidor As New System.Net.Mail.SmtpClient
            Servidor.Host = SMTP
            Servidor.Port = Puerto
            Servidor.EnableSsl = True
            Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
            Servidor.Send(correo)



        Catch ex As Exception
            MsgBox("Error al enviar el correo, " & ex.Message)

        End Try




    End Sub

End Class
