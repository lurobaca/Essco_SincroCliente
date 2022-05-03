Imports System.IO

Public Class InfoMsjHacienda
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub DGV_Historial_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Historial.CellContentClick

    End Sub

    Private Sub btn_pdf_Click(sender As Object, e As EventArgs) Handles btn_pdf.Click
        Try
            Dim Obj_ReporteDeDevoluciones As New frmReportes
            Dim loPSI As New ProcessStartInfo
            Dim loProceso As New Process
            If txtb_TipoComprobante.Text = "FE" Or txtb_TipoComprobante.Text = "FES" Then
                loPSI.FileName = VariablesGlobales.Patch_FE & "\" & Trim(txtb_CodInterno.Text) & "\" & Trim(txtb_CodInterno.Text) & ".pdf"

                VariablesGlobales.ReporteFE_Clave = Trim(txtb_CodInterno.Text)
                VariablesGlobales.ReporteFES_Clave = Trim(txtb_CodInterno.Text)
                'Verifica si existe el pdf, si no existe lo genera
                If File.Exists(loPSI.FileName) = False Then


                    If VariablesGlobales.Obj_SQL.EsServicio(txtb_CodInterno.Text.Trim, "FE") Then
                        Obj_ReporteDeDevoluciones.Imprimir_FES(txtb_CodInterno.Text.Trim)
                    Else
                        MessageBox.Show(" ¨( " & loPSI.FileName & " )", "Imprimir_FE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Obj_ReporteDeDevoluciones.Imprimir_FE(txtb_CodInterno.Text.Trim)
                        End If



                End If
            End If
            If txtb_TipoComprobante.Text = "NC" Or txtb_TipoComprobante.Text = "NCS" Then
                loPSI.FileName = VariablesGlobales.Patch_NC & "\" & Trim(txtb_CodInterno.Text) & "\" & Trim(txtb_CodInterno.Text) & ".pdf"
                VariablesGlobales.ReporteNC_Clave = Trim(txtb_CodInterno.Text)
                VariablesGlobales.ReporteNCS_Clave = Trim(txtb_CodInterno.Text)
                'Verifica si existe el pdf, si no existe lo genera
                If File.Exists(loPSI.FileName) = False Then
                    If VariablesGlobales.Obj_SQL.EsServicio(txtb_CodInterno.Text.Trim, "NC") Then

                        Obj_ReporteDeDevoluciones.Imprimir_NCS(txtb_CodInterno.Text.Trim)

                    Else
                        Obj_ReporteDeDevoluciones.Imprimir_NC(txtb_CodInterno.Text.Trim)
                    End If

                End If
            End If
            If txtb_TipoComprobante.Text = "ND" Or txtb_TipoComprobante.Text = "NDS" Then
                loPSI.FileName = VariablesGlobales.Patch_ND & "\" & Trim(txtb_CodInterno.Text) & "\" & Trim(txtb_CodInterno.Text) & ".pdf"
                VariablesGlobales.ReporteND_Clave = Trim(txtb_CodInterno.Text)
                VariablesGlobales.ReporteNDS_Clave = Trim(txtb_CodInterno.Text)
                'Verifica si existe el pdf, si no existe lo genera
                If File.Exists(loPSI.FileName) = False Then
                    If VariablesGlobales.Obj_SQL.EsServicio(txtb_CodInterno.Text.Trim, "ND") Then
                        Obj_ReporteDeDevoluciones.Imprimir_NDS(txtb_CodInterno.Text.Trim)
                    Else

                        Obj_ReporteDeDevoluciones.Imprimir_ND(txtb_CodInterno.Text.Trim)
                    End If

                End If
            End If
            If txtb_TipoComprobante.Text = "TE" Or txtb_TipoComprobante.Text = "TES" Then
                loPSI.FileName = VariablesGlobales.Patch_TE & "\" & Trim(txtb_CodInterno.Text) & "\" & Trim(txtb_CodInterno.Text) & ".pdf"
                VariablesGlobales.ReporteTE_Clave = Trim(txtb_CodInterno.Text)
                'VariablesGlobales.ReporteTES_Clave = Trim(txtb_CodInterno.Text)
                If File.Exists(loPSI.FileName) = False Then
                    If VariablesGlobales.Obj_SQL.EsServicio(txtb_CodInterno.Text.Trim, "TE") Then
                        'Obj_ReporteDeDevoluciones.Imprimir_TES(txtb_CodInterno.Text.Trim)

                    Else
                        Obj_ReporteDeDevoluciones.Imprimir_TE(txtb_CodInterno.Text.Trim)

                    End If

                End If
            End If


            'Dim loPSI As New ProcessStartInfo
            'Dim loProceso As New Process
            'If txtb_TipoComprobante.Text = "FE" Or txtb_TipoComprobante.Text = "FES" Then
            '    loPSI.FileName = VariablesGlobales.Patch_FE & "\" & Trim(txtb_CodInterno.Text) & "\" & Trim(txtb_CodInterno.Text) & ".pdf"
            'End If
            'If txtb_TipoComprobante.Text = "NC" Or txtb_TipoComprobante.Text = "NCS" Then
            '    loPSI.FileName = VariablesGlobales.Patch_NC & "\" & Trim(txtb_CodInterno.Text) & "\" & Trim(txtb_CodInterno.Text) & ".pdf"
            'End If
            'If txtb_TipoComprobante.Text = "NDS" Or txtb_TipoComprobante.Text = "NDS" Then
            '    loPSI.FileName = VariablesGlobales.Patch_ND & "\" & Trim(txtb_CodInterno.Text) & "\" & Trim(txtb_CodInterno.Text) & ".pdf"
            'End If
            'If txtb_TipoComprobante.Text = "TE" Or txtb_TipoComprobante.Text = "TES" Then
            '    loPSI.FileName = VariablesGlobales.Patch_TE & "\" & Trim(txtb_CodInterno.Text) & "\" & Trim(txtb_CodInterno.Text) & ".pdf"
            'End If
            Try
                loProceso = Process.Start(loPSI)
            Catch Exp As Exception
                MessageBox.Show(Exp.Message & " ¨( " & loPSI.FileName & " )", "NO DISPONIBLE", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try



        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR btn_pdf", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btn_reenviarMail.Click
        Try
            If txtb_ReenviarEmail.Text = "" Then

                MessageBox.Show("Debe indicar un correo al cual desea reenviar el comprobante electronico", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else

                Dim Obj_Mail As New Class_MAIL
                Dim GPatch_PDF As String = ""
                Dim MensajeRespuestaH As String = ""
                Dim GPatch_XML As String = ""
                Dim GPatch_RH As String = ""

                If txtb_TipoComprobante.Text = "FE" Or txtb_TipoComprobante.Text = "FES" Then
                    GPatch_PDF = VariablesGlobales.Patch_FE & "\" & Trim(txtb_CodInterno.Text) & "\" & Trim(txtb_CodInterno.Text) & ".pdf"
                    MensajeRespuestaH = ""
                    GPatch_XML = VariablesGlobales.Patch_FE & "\" & Trim(txtb_CodInterno.Text) & "\" & Trim(txtb_CodInterno.Text) & "_Firmado.xml"
                    GPatch_RH = VariablesGlobales.Patch_FE & "\" & Trim(txtb_CodInterno.Text) & "\" & Trim(txtb_CodInterno.Text) & "_RH.xml"
                End If

                If txtb_TipoComprobante.Text = "NC" Or txtb_TipoComprobante.Text = "NCS" Then
                    GPatch_PDF = VariablesGlobales.Patch_NC & "\" & Trim(txtb_CodInterno.Text) & "\" & Trim(txtb_CodInterno.Text) & ".pdf"
                    MensajeRespuestaH = ""
                    GPatch_XML = VariablesGlobales.Patch_NC & "\" & Trim(txtb_CodInterno.Text) & "\" & Trim(txtb_CodInterno.Text) & "_Firmado.xml"
                    GPatch_RH = VariablesGlobales.Patch_NC & "\" & Trim(txtb_CodInterno.Text) & "\" & Trim(txtb_CodInterno.Text) & "_RH.xml"
                End If

                If txtb_TipoComprobante.Text = "ND" Or txtb_TipoComprobante.Text = "NDS" Then
                    GPatch_PDF = VariablesGlobales.Patch_ND & "\" & Trim(txtb_CodInterno.Text) & "\" & Trim(txtb_CodInterno.Text) & ".pdf"
                    MensajeRespuestaH = ""
                    GPatch_XML = VariablesGlobales.Patch_ND & "\" & Trim(txtb_CodInterno.Text) & "\" & Trim(txtb_CodInterno.Text) & "_Firmado.xml"
                    GPatch_RH = VariablesGlobales.Patch_ND & "\" & Trim(txtb_CodInterno.Text) & "\" & Trim(txtb_CodInterno.Text) & "_RH.xml"
                End If
                If txtb_TipoComprobante.Text = "TE" Or txtb_TipoComprobante.Text = "TES" Then
                    GPatch_PDF = VariablesGlobales.Patch_TE & "\" & Trim(txtb_CodInterno.Text) & "\" & Trim(txtb_CodInterno.Text) & ".pdf"
                    MensajeRespuestaH = ""
                    GPatch_XML = VariablesGlobales.Patch_TE & "\" & Trim(txtb_CodInterno.Text) & "\" & Trim(txtb_CodInterno.Text) & "_Firmado.xml"
                    GPatch_RH = VariablesGlobales.Patch_TE & "\" & Trim(txtb_CodInterno.Text) & "\" & Trim(txtb_CodInterno.Text) & "_RH.xml"
                End If

                VariablesGlobales.EmisorEmail = txtb_ReenviarEmail.Text
                Obj_Mail.Envia_Cliente(txtb_Clave.Text, txtb_TipoComprobante.Text, "Factura Electronica ACEPTADA [" & txtb_Clave.Text & "]", MensajeRespuestaH, GPatch_XML, GPatch_PDF, GPatch_RH)
                MessageBox.Show("Comprobante enviado correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Obj_Mail = Nothing
                GPatch_PDF = Nothing
                MensajeRespuestaH = Nothing
                GPatch_XML = Nothing
                GPatch_RH = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR btn_reenviarMail", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub InfoMsjHacienda_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ChbX_Corregido_CheckedChanged(sender As Object, e As EventArgs) Handles ChbX_Corregido.CheckedChanged
        If ChbX_Corregido.Checked Then
            VariablesGlobales.Obj_SQL.MarcaComoCorregido(Trim(txtb_Clave.Text), 1)
            LBL_ESTADO.Text = "CORREGIDO"
            LBL_ESTADO.ForeColor = Color.DarkGreen
        Else
            VariablesGlobales.Obj_SQL.MarcaComoCorregido(Trim(txtb_Clave.Text), 0)
            LBL_ESTADO.Text = "NO ESTA CORREGIDO"
            LBL_ESTADO.ForeColor = Color.DarkRed
        End If

    End Sub

    Private Sub InfoMsjHacienda_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed


        Class_VariablesGlobales.frmLista_Admin_EstadoComprobantes = New Admin_EstadoComprobantes
        Class_VariablesGlobales.frmLista_Admin_EstadoComprobantes.MdiParent = Principal
        Class_VariablesGlobales.frmLista_Admin_EstadoComprobantes.Show()

    End Sub
End Class