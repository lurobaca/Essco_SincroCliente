Imports System.Drawing.Imaging
Imports System.IO
Imports Gma.QrCodeNet.Encoding
Imports Gma.QrCodeNet.Encoding.Windows.Render



Public Class QR_CODE

    Public Function Generar(Patch As String, Clave As String, Tipo As String)
        Try


            'Crea una carpeta con el nombre de la clave del comprobante esta contendra el Documento FE y los mensajes de hacienda y cliente
            If File.Exists(Patch & "\" & Clave) = False Then
                My.Computer.FileSystem.CreateDirectory(Patch & "\" & Clave)
            End If


            Dim qrEncoder As QrEncoder = New QrEncoder(ErrorCorrectionLevel.H)
            Dim qrCode As QrCode = New QrCode()
            qrEncoder.TryEncode("http://essco.com/Comprobantes.php?Clave=" & Clave, qrCode)
            Dim renderer As GraphicsRenderer = New GraphicsRenderer(New FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White)
            Dim ms As MemoryStream = New MemoryStream()
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms)
            Dim imageTemporal = New Bitmap(ms)
            Dim imagen = New Bitmap(imageTemporal, New Size(New Point(200, 200)))
            ' panelResultado.BackgroundImage = imagen
            '  imagen.Save(Trim(txtClave.Text) & ".png", ImageFormat.Png)

            imagen.Save(Patch & "\" & Clave & "\" & Clave & ".png", ImageFormat.Png)
            'btnGuardar.Enabled = True

            '---- LIBERANDO MEMORIA ----
            qrEncoder = Nothing
            qrCode = Nothing
            renderer = Nothing
            ms = Nothing
            imageTemporal = Nothing
            imagen = Nothing

        Catch ex As Exception
            'VariablesGlobales.Obj_Log.Log("ERROR Generar QR_CODE Clave [" & ex.Message & " ] [" & VariablesGlobales.ReporteFE_CodSeguridad & "]", Tipo)
            MsgBox("ERROR Generar QR_CODE Clave [ " & Clave & " ] Patch [ " & Patch & " ]" & ex.Message)
        End Try
    End Function



End Class
