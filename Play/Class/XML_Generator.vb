Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Xml
Imports Org.BouncyCastle.Math

Public Class XML_Generator

    Public Obj_Mail As New Class_MAIL
    Public obj_FTP As New Class_FTP
    Public Obj_Funciones As New Class_funcionesSQL
    Public Obj_Fecha As New FechaManager

    'procesamos los datos y agregamos al xml lo que ocupemos
    Public XML As String = ""
    Public XML_TagInicial As String = ""
    Public XML_TagFinal As String = ""
    Public URL_Xml_SinFirma As String = ""
    Public URL_Xml_Firmado As String = ""
    Public XML_TagDocReferencia As String = ""

    Public Receptor As Boolean
    Public GenerarTE As Boolean
    Public Tbl As New DataTable

    Public TipoComprobante As String = ""
    Public Clave As String = ""
    Public Consecutivo As String = ""
    Public Fecha As String = ""
    Public Emisor_Nombre As String = ""
    Public Emisor_TipoCedula As String = ""
    Public Emisor_NumeroCedula As String = ""
    Public Emisor_NombreComercial As String = ""
    Public Emisor_Ubicacion_Provincia As String = ""
    Public Emisor_Ubicacion_Canton As String = ""
    Public Emisor_Ubicacion_Distrito As String = ""
    Public Emisor_Ubicacion_Barrio As String = ""
    Public Emisor_Ubicacion_OtrasSenas As String = ""
    Public Emisor_CodigoPais As String = ""
    Public Emisor_NumTelefono As String = ""
    Public Emisor_NumFax As String = ""
    Public Emisor_CorreoElectronico As String = ""
    Public Recepto_Nombre As String = ""
    Public Recepto_TipoCedula As String = ""
    Public Recepto_NumeroCedula As String = ""
    Public Recepto_IdentificacionExtranjero As String = ""
    Public Recepto_NombreComercial As String = ""
    Public Recepto_Ubicacion_Provincia As String = ""
    Public Recepto_Ubicacion_Canton As String = ""
    Public Recepto_Ubicacion_Distrito As String = ""
    Public Recepto_Ubicacion_Barrio As String = ""
    Public Recepto_OtraSenas As String = ""
    Public Recepto_CodigoPais As String = ""
    Public Recepto_NumTelefono As String = ""
    Public Recepto_NumFax As String = ""
    Public Recepto_CorreoElectronico As String = ""
    Public Recepto_CondicionVenta As String = ""
    Public Recepto_PlazoCredito As String = ""
    Public Recepto_MedioPago As String = ""
    Public DetalleServicio_NumeroLinea As String = ""
    Public DetalleServicio_TipoCodigo As String = ""
    Public DetalleServicio_Codigo As String = ""
    Public DetalleServicio_Cantidad As String = ""
    Public DetalleServicio_UnidadMedida As String = ""
    Public DetalleServicio_UnidadMedidaComercial As String = ""
    Public DetalleServicio_Detalle As String = ""
    Public DetalleServicio_PrecioUnitario As String = ""
    Public DetalleServicio_MontoTotal As String = ""
    Public DetalleServicio_MontoDescuento As String = ""
    Public DetalleServicio_NaturalezaDescuento As String = ""
    Public DetalleServicio_SubTotal As String = ""
    Public DetalleServicio_CodigoImpuesto As String = ""
    Public DetalleServicio_TarifaImpuesto As String = ""
    Public DetalleServicio_MontoImpuesto As String = ""
    Public DetalleServicio_MontoTotalLinea As String = ""

    Public Exoneracion_TipoDocumento As String = ""
    Public Exoneracion_NumeroDocumento As String = ""
    Public Exoneracion_MontoImpuesto As String = ""
    Public Exoneracion_NombreInstirucion As String = ""
    Public Exoneracion_FechaEmision As String = ""
    Public Exoneracion_PorcentajeCompra As String = ""

    Public ResumenFactura_CodigoMoneda As String = ""
    Public ResumenFactura_TipoCambio As String = ""

    Public ResumenFactura_TotalServGravados_X_Linea As Double = 0
    Public ResumenFactura_TotalServExentos_X_Linea As Double = 0
    Public ResumenFactura_TotalMercanciasGravadas_X_Linea As Double = 0
    Public ResumenFactura_TotalMercanciasExentas_X_Linea As Double = 0

    Public ResumenFactura_TotalServGravados As Double = 0
    Public ResumenFactura_TotalServExentos As Double = 0
    Public ResumenFactura_TotalMercanciasGravadas As Double = 0
    Public ResumenFactura_TotalMercanciasExentas As Double = 0
    Public ResumenFactura_TotalGravado As Double = 0
    Public ResumenFactura_TotalExento As Double = 0
    Public ResumenFactura_TotalVenta As Double = 0
    Public ResumenFactura_TotalDescuentos As Double = 0
    Public ResumenFactura_TotalVentaNeta As Double = 0
    Public ResumenFactura_TotalImpuesto As Double = 0
    Public ResumenFactura_TotalComprobante As Double = 0

    'las siguientes variables Se usan para obtener el TOTAL de los comprobantes que se reprocesan por error NULL
    Public ResumenFactura_TotalServGravados_2 As Double = 0
    Public ResumenFactura_TotalServExentos_2 As Double = 0
    Public ResumenFactura_TotalMercanciasGravadas_2 As Double = 0
    Public ResumenFactura_TotalMercanciasExentas_2 As Double = 0
    Public ResumenFactura_TotalGravado_2 As Double = 0
    Public ResumenFactura_TotalExento_2 As Double = 0
    Public ResumenFactura_TotalVenta_2 As Double = 0
    Public ResumenFactura_TotalDescuentos_2 As Double = 0
    Public ResumenFactura_TotalVentaNeta_2 As Double = 0
    Public ResumenFactura_TotalImpuesto_2 As Double = 0
    Public ResumenFactura_TotalComprobante_2 As Double = 0


    Public Referencia_TipoDoc As String = ""
    Public Referencia_Numero As String = ""
    Public Referencia_FechaEmision As String = ""
    Public Referencia_Codigo As String = ""
    Public Referencia_Razon As String = ""
    Public CodSeguridad As String = "" 'Consecutivo que lleva SAP
    Public CodCliente As String = "" 'NO SE USA EN EL XML
    Public Agente As String = "" 'NO SE USA ENEL XML




    Public cont As Integer = 0
    Public Encabezado As Boolean = False
    Public Backup_Consecutivo As String = ""
    Public ConsNuevo As String




    Public Function GeneraMR(Clave As String, TipoCedulaEmisor As String, NumeroCedulaEmisor As String, FechaEmisionDoc As String, CorreoEmisor As String, TipoCedulaReceptor As String, NumeroCedulaReceptor As String, MontoTotalImpuesto As String, TotalFactura As String, Mensaje As String, DetalleMensaje As String, Tipo As String, CodigoActividad As String, CondicionImpuesto As String, MontoTotalImpuestoAcreditar As String, MontoTotalDeGastoAplicable As String)


        Try


            'Clave: Este atributo obligatorio de 50 posiciones corresponde a la clave del documento (sea una factura, tiquete, nota de débito o de crédito) al cual le estamos dando una respuesta.
            'NumeroCedulaEmisor: Es un atributo obligatorio que corresponde al número de identificación del emisor del documento original que estamos respondiendo. No es la identificación del receptor.
            'FechaEmisionDoc: Es un atributo obligatorio que corresponde a la fecha y hora en la cual se esta haciendo la emisión de esta respuesta. No es la fecha de emisión del documento que se responde.
            'Mensaje: Es un atributo obligatorio de una posición que puede tener los siguientes valores: 1 (aceptado), 2 (aceptado parcialmente) y 3 (rechazado)
            'DetalleMensaje: Es un atributo opcional de hasta 80 posiciones para consignar cualquier texto de relevancia que el receptor desee constar.
            'MontoTotalImpuesto: Es un atributo condicional que se debe usar si y solo si, el documento que respondemos contaba con un detalle de impuesto. Si el documento que vamos a responder no tenía impuestos, no se debe colocar este atributo en el XML de respuesta. En caso de que lo coloquemos; el monto que se consigne debe ser el mismo que esta establecido en el documento. Caso contrario, se recibiría una advertencia por parte de la plataforma indicando que los montos no coinciden.
            'TotalFactura: Es un atributo obligatorio que corresponde al monto total del documento al que estamos dando respuesta. Si el valor no coincide se recibiría una advertencia por parte de la plataforma indicando esa situación.
            'NumeroCedulaReceptor: Es un atributo obligatorio en donde se coloca el número de identificación del receptor del documento. Evidentemente, debe ser la misma identificación del receptor que se colocó en el documento al que vamos a responder.
            'NumConsecutivoReceptor: Este atributo obligatorio de 20 posiciones que corresponde al número consecutivo del receptor y cuya definición abarca de la página 5 a la 7 de la Resolución de Comprobantes Electrónicos DGT-R-48-2016. Y que seguidamente resumimos:
            'De la posición 1 a 3, se identifica el local o establecimiento desde se emitió el mensaje de receptor. El número 001 corresponde a la oficina central y del 002 en adelante a las sucursales.
            'De la posición 4 a la 8, identifica la terminal o punto de venta, inicia en 00001.
            'De la posición 9 al 10, corresponde al tipo de documento que estamos trabajando. En este caso, al ser un mensaje de receptor, debemos elegir entre 05 (aceptación), 06 (aceptación parcial) o 07 (rechazo). Es importante que haya una consistencia entre esos valores y el dato que coloquemos en el atributo Mensaje. Es decir, si en Mensaje colocamos el valor 1 de aceptación, entonces debemos colocar el valor 05 en este espacio. Caso contrario, se daría un rechazo por parte del Ministerio de Hacienda.
            'De la posición 11 a la 20, corresponde al consecutivo del receptor iniciando en 1 para cada terminal o sucursal.
            Dim Xml_MR As String
            Dim err As Boolean
            Dim NumeroConsecutivoReceptor As String = Obj_Funciones.ObtieneConsecutivoMR(Mensaje)


            Class_VariablesGlobales.frmLista_FE_Proveedores.DGV_ListaFE.Item(24, CInt(Class_VariablesGlobales.RoxIndexDGV(Clave).ToString())).Value = NumeroConsecutivoReceptor

            If DetalleMensaje <> "" Then 'Actualiza el motivo de la accion 
                Obj_Funciones.ActualizaMotivoMR(Clave, DetalleMensaje)

            End If
            'Aceptado
            If Mensaje = "1" Then
                NumeroConsecutivoReceptor = "0010000105" & NumeroConsecutivoReceptor.PadLeft(10, "0")
                'Actualizamos el estado por parte del receptor , para saber si fue aceptado o rechazado aun quedaria pendiente el estado de hacienda
                Obj_Funciones.ActualizaComprobanteProveedor(Clave, NumeroConsecutivoReceptor, Mensaje, "Comprobante Aceptado", Obj_Fecha.FormatoFechaSql(Date.Now), DateTime.Now.ToString("hh:mm"))
                'Aceptado Parcial
            ElseIf Mensaje = "2" Then
                NumeroConsecutivoReceptor = "0010000106" & NumeroConsecutivoReceptor.PadLeft(10, "0")
                Obj_Funciones.ActualizaComprobanteProveedor(Clave, NumeroConsecutivoReceptor, Mensaje, "Comprobante Parcialmente Aceptado", Obj_Fecha.FormatoFechaSql(Date.Now), DateTime.Now.ToString("hh:mm"))
                'Rechazado
            ElseIf Mensaje = "3" Then
                NumeroConsecutivoReceptor = "0010000107" & NumeroConsecutivoReceptor.PadLeft(10, "0")
                Obj_Funciones.ActualizaComprobanteProveedor(Clave, NumeroConsecutivoReceptor, Mensaje, "Rechazado", Obj_Fecha.FormatoFechaSql(Date.Now), DateTime.Now.ToString("hh:mm"))
            End If
            Class_VariablesGlobales.frmLista_Admin_Acepta_Rechaza.Txt_NumeroConsecutivoReceptor.Text = NumeroConsecutivoReceptor
            'Class_VariablesGlobales.frmLista_FE_Proveedores.DGV_ListaFE.Item(19, Class_VariablesGlobales.frmLista_FE_Proveedores.DGV_ListaFE.CurrentRow.Index).Value = NumeroConsecutivoReceptor


            'Version 4.2 <MensajeReceptor xmlns=""https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/mensajeReceptor"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/mensajeReceptor https://tribunet.hacienda.go.cr/docs/esquemas/2016/v4.2/MensajeReceptor_4.2.xsd"">
            Xml_MR = "<?xml version=""1.0"" encoding=""utf-8""?>
        <MensajeReceptor xmlns=""https://cdn.comprobanteselectronicos.go.cr/xml-schemas/v4.3/mensajeReceptor"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""https://cdn.comprobanteselectronicos.go.cr/xml-schemas/v4.3/mensajeReceptor https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.3/mensajeReceptor.xsd"">
        <Clave>" & Clave & "</Clave>
        <NumeroCedulaEmisor>" & NumeroCedulaEmisor & "</NumeroCedulaEmisor>
        <FechaEmisionDoc>" & FechaEmisionDoc & "</FechaEmisionDoc>
        <Mensaje>" & Mensaje & "</Mensaje>
        <DetalleMensaje>" & DetalleMensaje & "</DetalleMensaje>" & vbCrLf

            If MontoTotalImpuesto <> "" And MontoTotalImpuesto <> "0" And MontoTotalImpuesto <> "0.00" Then
                Xml_MR = Xml_MR & "<MontoTotalImpuesto>" & MontoTotalImpuesto & "</MontoTotalImpuesto>" & vbCrLf
            Else
                'Xml_MR = Xml_MR & "<MontoTotalImpuesto>0.00</MontoTotalImpuesto>" & vbCrLf
            End If
            'CDbl(TotalFactura).ToString(“##,##0.00”)
            '        <CodigoActividad>" & CodigoActividad & "</CodigoActividad> 'ESTO ES OPCIONAL
            Xml_MR = Xml_MR & "
        <CondicionImpuesto>" & CondicionImpuesto & "</CondicionImpuesto>
        <MontoTotalImpuestoAcreditar>" & MontoTotalImpuestoAcreditar & "</MontoTotalImpuestoAcreditar>
        <MontoTotalDeGastoAplicable>" & MontoTotalDeGastoAplicable & "</MontoTotalDeGastoAplicable>
        <TotalFactura>" & TotalFactura & "</TotalFactura>
        <NumeroCedulaReceptor>" & NumeroCedulaReceptor & "</NumeroCedulaReceptor>
        <NumeroConsecutivoReceptor>" & NumeroConsecutivoReceptor & "</NumeroConsecutivoReceptor>
        </MensajeReceptor>"



            Dim RutaComprobante As String = VariablesGlobales.Patch_MR & "\" & NumeroConsecutivoReceptor & "\" & NumeroConsecutivoReceptor & ".xml"
            If File.Exists(VariablesGlobales.Patch_MR & "\" & NumeroConsecutivoReceptor) = False Then
                My.Computer.FileSystem.CreateDirectory(VariablesGlobales.Patch_MR & "\" & NumeroConsecutivoReceptor)
            End If
            Dim xmlDocSF As New Xml.XmlDocument
            xmlDocSF.LoadXml(Xml_MR)
            xmlDocSF.Save(RutaComprobante)

            ' Dim xmlTextWriter As New Xml.XmlTextWriter(directorio & nombreArchivo & "_01_SF.xml", New System.Text.UTF8Encoding(False))
            Dim xmlTextWriter As New Xml.XmlTextWriter(RutaComprobante, New System.Text.UTF8Encoding(False))
            xmlDocSF.WriteTo(xmlTextWriter)
            xmlTextWriter.Close()
            xmlDocSF = Nothing



            'Procedemos a firmar y enviar
            err = Acepta_Rechaza.ProcesaMensajeReceptor(Xml_MR, "MR", TipoCedulaEmisor, TipoCedulaReceptor)
            If err = False Then
                'Aqui aumenta el consecutivo
                Obj_Funciones.ActualizaConsecutivoMR(Mensaje.Trim())
                'Notifica la aceptacion o rechazo de facturas
                If Mensaje = "1" Then
                    Obj_Mail.NotificaAProveedor("Comprobante [" & Clave & "] ACEPTADO por " & Obj_Funciones.ObtieneNameEmpresa(Class_VariablesGlobales.SQL_Comman2), "Su comprobante con clave [" & Clave & "] a sido aceptado por parte de " & Obj_Funciones.ObtieneNameEmpresa(Class_VariablesGlobales.SQL_Comman2), CorreoEmisor, VariablesGlobales.Patch_MR & "\" & NumeroConsecutivoReceptor & "\" & NumeroConsecutivoReceptor & ".xml", VariablesGlobales.Patch_MR & "\" & NumeroConsecutivoReceptor & "\" & NumeroConsecutivoReceptor & "_RH.xml")
                ElseIf Mensaje = "2" Then
                    Obj_Mail.NotificaAProveedor("Comprobante [" & Clave & "] PARCIALMENTE ACEPTADO por " & Obj_Funciones.ObtieneNameEmpresa(Class_VariablesGlobales.SQL_Comman2), "Su comprobante con clave [" & Clave & "] a sido Parcialmente Aceptado por parte de " & Obj_Funciones.ObtieneNameEmpresa(Class_VariablesGlobales.SQL_Comman2), CorreoEmisor, VariablesGlobales.Patch_MR & "\" & NumeroConsecutivoReceptor & "\" & NumeroConsecutivoReceptor & ".xml", VariablesGlobales.Patch_MR & "\" & NumeroConsecutivoReceptor & "\" & NumeroConsecutivoReceptor & "_RH.xml")
                ElseIf Mensaje = "3" Then
                    Obj_Mail.NotificaAProveedor("Comprobante [" & Clave & "] RECHAZADO por " & Obj_Funciones.ObtieneNameEmpresa(Class_VariablesGlobales.SQL_Comman2), "Su comprobante con clave [" & Clave & "] a sido aceptado por parte de " & Obj_Funciones.ObtieneNameEmpresa(Class_VariablesGlobales.SQL_Comman2), CorreoEmisor, VariablesGlobales.Patch_MR & "\" & NumeroConsecutivoReceptor & "\" & NumeroConsecutivoReceptor & ".xml", VariablesGlobales.Patch_MR & "\" & NumeroConsecutivoReceptor & "\" & NumeroConsecutivoReceptor & "_RH.xml")
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR en GeneraMR  [" & ex.Message & "]  [" & Clave & "]")

        End Try

    End Function

    Private Shared Function EmailValido(strEmail As String) As Boolean
        ' Retorna verdadero si strEmail es un formato de E-mail valido.
        Return System.Text.RegularExpressions.Regex.IsMatch(strEmail, "^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" & "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$")
    End Function

    Public Function Limpiar()
        XML = ""
        XML_TagInicial = ""
        XML_TagFinal = ""
        URL_Xml_SinFirma = ""
        URL_Xml_Firmado = ""
        XML_TagDocReferencia = ""

        TipoComprobante = ""
        Clave = ""
        Consecutivo = ""
        Backup_Consecutivo = ""
        Fecha = ""
        Emisor_Nombre = ""
        Emisor_TipoCedula = ""
        Emisor_NumeroCedula = ""
        Emisor_NombreComercial = ""
        Emisor_Ubicacion_Provincia = ""
        Emisor_Ubicacion_Canton = ""
        Emisor_Ubicacion_Distrito = ""
        Emisor_Ubicacion_Barrio = ""
        Emisor_Ubicacion_OtrasSenas = ""
        Emisor_CodigoPais = ""
        Emisor_NumTelefono = ""
        Emisor_NumFax = ""
        Emisor_CorreoElectronico = ""
        Recepto_Nombre = ""
        Recepto_TipoCedula = ""
        Recepto_NumeroCedula = ""
        Recepto_IdentificacionExtranjero = ""
        Recepto_NombreComercial = ""
        Recepto_Ubicacion_Provincia = ""
        Recepto_Ubicacion_Canton = ""
        Recepto_Ubicacion_Distrito = ""
        Recepto_Ubicacion_Barrio = ""
        Recepto_OtraSenas = ""
        Recepto_CodigoPais = ""
        Recepto_NumTelefono = ""
        Recepto_NumFax = ""
        Recepto_CorreoElectronico = ""
        Recepto_CondicionVenta = ""
        Recepto_PlazoCredito = ""
        Recepto_MedioPago = ""
        DetalleServicio_NumeroLinea = ""
        DetalleServicio_TipoCodigo = ""
        DetalleServicio_Codigo = ""
        DetalleServicio_Cantidad = ""
        DetalleServicio_UnidadMedida = ""
        DetalleServicio_UnidadMedidaComercial = ""
        DetalleServicio_Detalle = ""
        DetalleServicio_PrecioUnitario = ""
        DetalleServicio_MontoTotal = ""
        DetalleServicio_MontoDescuento = ""
        DetalleServicio_NaturalezaDescuento = ""
        DetalleServicio_SubTotal = ""
        DetalleServicio_CodigoImpuesto = ""
        DetalleServicio_TarifaImpuesto = ""
        DetalleServicio_MontoImpuesto = ""
        Exoneracion_TipoDocumento = ""
        Exoneracion_NumeroDocumento = ""
        Exoneracion_MontoImpuesto = ""
        Exoneracion_NombreInstirucion = ""
        Exoneracion_FechaEmision = ""
        Exoneracion_PorcentajeCompra = ""
        DetalleServicio_MontoTotalLinea = ""
        ResumenFactura_CodigoMoneda = 0
        ResumenFactura_TipoCambio = 0
        ResumenFactura_TotalServGravados = 0
        ResumenFactura_TotalServExentos = 0
        ResumenFactura_TotalMercanciasGravadas = 0
        ResumenFactura_TotalMercanciasExentas = 0
        ResumenFactura_TotalGravado = 0
        ResumenFactura_TotalExento = 0
        ResumenFactura_TotalVenta = 0
        ResumenFactura_TotalDescuentos = 0
        ResumenFactura_TotalVentaNeta = 0
        ResumenFactura_TotalImpuesto = 0
        ResumenFactura_TotalComprobante = 0
        Encabezado = False
        cont = 0

    End Function

End Class

