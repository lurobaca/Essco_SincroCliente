Public Class Facturacion
    Public menu As ContextMenuStrip
    Public indice As Integer
    Public Guardada As Boolean = False
    Public DocNum As String = ""
    Public Clave As String = ""
    Public Consecutivo As String = ""
    Public DocDate As String = ""
    Public DocDueDate As String = ""
    Public DocTime As String = ""
    Public DocType As String = ""
    Public DocSubType As String = ""
    Public Status As String = ""
    Public Printed As String = "0"
    Public CodMoneda As String = ""
    Public TipoCambio As String = ""

    Public ID_User As String = ""
    Public Nombre_User As String = ""
    Public Emisor_Nombre As String = ""
    Public Emisor_NombreComercial As String = ""
    Public Emisor_Tipo As String = ""
    Public Emisor_Numero As String = ""
    Public Emisor_Provincia As String = ""
    Public Emisor_Canton As String = ""
    Public Emisor_Distrito As String = ""
    Public Emisor_Barrio As String = ""
    Public Emisor_OtrasSenas As String = ""
    Public Emisor_CorreoElectronico As String = ""
    Public Receptor_Nombre As String = ""
    Public Receptor_NombreComercial As String = ""
    Public Receptor_Tipo As String = ""
    Public Receptor_Numero As String = ""
    Public Receptor_IdentificacionExtranjero As String = ""
    Public Receptor_Provincia As String = ""
    Public Receptor_Canton As String = ""
    Public Receptor_Distrito As String = ""
    Public Receptor_Barrio As String = ""
    Public Receptor_OtrasSenas As String = ""
    Public Receptor_CorreoElectronico As String = ""
    Public CondicionVenta As String = ""
    Public PlazoCredito As String = ""
    Public MedioPago As String = ""
    Public Referencia_Numero As String = ""
    Public Referencia_TipoDoc As String = ""
    Public Referencia_FechaEmision As String = ""
    Public Referencia_Codigo As String = ""
    Public Referencia_Razon As String = ""
    Public DocTotal As String = ""
    Public DocSubTotal As String = ""
    Public DocTotalImpuesto As String = ""
    Public DocTotalDescuento As String = ""
    Public DocSaldo As String = ""

    Public TotalGravado As Double
    Public TotalExento As Double


    Public Comments As String = ""
    Public MH_Status As String = ""
    Public MH_Message As String = ""
    Public NumLinea = ""
    Public ItemCode = ""
    Public ItemName = ""
    Public Pack = ""
    Public UnidadMedida = ""
    Public Costo = ""
    Public PrecioUnitario = ""
    Public Utilidad_Porciento = ""
    Public Utilidad_Monto = ""
    Public Cantidad = ""
    Public Descuento_Porciento = ""
    Public Descuento_Monto = ""
    Public Impuesto_Porciento = ""
    Public Impuesto_Monto = ""
    Public SubTotal = ""
    Public Total = ""
    Public CodCliente = ""
    Public Vendedor = ""
    Public Descuento_Promo_Porciento = ""
    Public Descuento_Promo_Monto = ""
    Public Descuento_Interno_Porciento = ""
    Public Descuento_Interno_Monto = ""

    Public Function ObtieneInfoEmpresa()
        Try
            Dim tabla As New DataTable
            Dim contardor As Integer = 0
            tabla = Class_VariablesGlobales.Obj_Funciones_SQL.CONSULTA_Empresa(Class_VariablesGlobales.SQL_Comman2)

            While contardor < tabla.Rows.Count
                Emisor_Tipo = tabla.Rows(contardor).Item("Tipo_Cedula").ToString().ToString().PadLeft(2, "0")
                Emisor_Numero = tabla.Rows(contardor).Item("Cedula").ToString()
                Emisor_Nombre = tabla.Rows(contardor).Item("Nombre").ToString()
                Emisor_CorreoElectronico = tabla.Rows(contardor).Item("Correo").ToString()
                Emisor_OtrasSenas = tabla.Rows(contardor).Item("Direccion").ToString()
                Emisor_NombreComercial = tabla.Rows(contardor).Item("Nombre_Fantacia").ToString()
                Emisor_Provincia = tabla.Rows(contardor).Item("id_Provincia").ToString()
                Emisor_Canton = tabla.Rows(contardor).Item("id_canton").ToString().ToString().PadLeft(2, "0")
                Emisor_Distrito = tabla.Rows(contardor).Item("id_distrito").ToString().ToString().PadLeft(2, "0")
                Emisor_Barrio = tabla.Rows(contardor).Item("id_barrio").ToString().ToString().PadLeft(2, "0")
                contardor += 1
            End While
        Catch ex As Exception

        End Try
    End Function
    Private Function btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click


        'Obj_Funciones.GuardaComprobante(TipoComprobante, Clave, Consecutivo, Fecha, Emisor_Nombre, Emisor_TipoCedula, Emisor_NumeroCedula, Emisor_NombreComercial, Emisor_Ubicacion_Provincia, Emisor_Ubicacion_Canton, Emisor_Ubicacion_Distrito, Emisor_Ubicacion_Barrio, Emisor_Ubicacion_OtrasSenas, Emisor_CodigoPais, Emisor_NumTelefono, Emisor_NumFax, Emisor_CorreoElectronico, Recepto_Nombre, Recepto_TipoCedula, Recepto_NumeroCedula, Recepto_IdentificacionExtranjero, Recepto_NombreComercial, Recepto_Ubicacion_Provincia, Recepto_Ubicacion_Canton, Recepto_Ubicacion_Distrito, Recepto_Ubicacion_Barrio, Recepto_OtraSenas, Recepto_CodigoPais, Recepto_NumTelefono, Recepto_NumFax, Recepto_CorreoElectronico, Recepto_CondicionVenta, Recepto_PlazoCredito, Recepto_MedioPago, DetalleServicio_NumeroLinea, DetalleServicio_TipoCodigo, DetalleServicio_Codigo, DetalleServicio_Cantidad, DetalleServicio_UnidadMedida, DetalleServicio_UnidadMedidaComercial, DetalleServicio_Detalle, DetalleServicio_PrecioUnitario, DetalleServicio_MontoTotal, DetalleServicio_MontoDescuento, DetalleServicio_NaturalezaDescuento, DetalleServicio_SubTotal, DetalleServicio_CodigoImpuesto, DetalleServicio_TarifaImpuesto, DetalleServicio_MontoImpuesto, Exoneracion_TipoDocumento, Exoneracion_NumeroDocumento, Exoneracion_MontoImpuesto, Exoneracion_NombreInstirucion, Exoneracion_FechaEmision, Exoneracion_PorcentajeCompra, ResumenFactura_CodigoMoneda, ResumenFactura_TipoCambio, ResumenFactura_TotalServGravados, ResumenFactura_TotalServExentos, ResumenFactura_TotalMercanciasGravadas, ResumenFactura_TotalMercanciasExentas, ResumenFactura_TotalGravado, ResumenFactura_TotalExento, ResumenFactura_TotalVenta, ResumenFactura_TotalDescuentos, ResumenFactura_TotalVentaNeta, ResumenFactura_TotalImpuesto, ResumenFactura_TotalComprobante, Referencia_Numero, Referencia_TipoDoc, Referencia_FechaEmision, Referencia_Codigo, Referencia_Razon, CodSeguridad, CodCliente, Agente, DetalleServicio_MontoTotalLinea, DocType, DocSubType, obj_Fecha.FormatoFechaSql(FechaComprobante), HoraComprobante)



        CodMoneda = Cmb_Moneda.Text
        TipoCambio = txtb_TipoCambio.Text

        If CodMoneda = "USD" And TipoCambio = "" Or TipoCambio = "0" Then
            MessageBox.Show("Debe indicar el tipo de cambio del dia de hoy")
            Return True

        End If


        CodCliente = txtb_CodCliente.Text
        DocNum = Txtb_DocNum.Text
        Clave = txtb_clave.Text
        Consecutivo = txtb_Consecutivo.Text
        DocDate = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_TransaccionDesde.Value.Date)
        DocDueDate = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_TransaccionDesde.Value.Date)
        '  DocTime = DTP_TransaccionDesde.Value.ToString("hh:mm:ss")
        DocTime = Replace(Now.ToString("HH:mm:ss"), ":", "") 'formato 24 horas
        Vendedor = CBox_Vendedor.Text


        If CBox_TipoProducto.Text = "Servicio" Then

            If CBox_TipoDocumento.Text = "FE" Then
                DocType = "FES"
            ElseIf CBox_TipoDocumento.Text = "NC" Then
                DocType = "NCS"
            ElseIf CBox_TipoDocumento.Text = "ND" Then
                DocType = "NDS"
            End If

        Else
            DocType = CBox_TipoDocumento.Text
        End If

        DocSubType = ""
        Status = ""
        Printed = "0"
        ID_User = "0"
        Nombre_User = ""

        ObtieneInfoEmpresa()

        CondicionVenta = CBox_TipoVenta.Text
        PlazoCredito = Txtb_plazoCredito.Text
        MedioPago = ""

        If CBox_TipoDocumento.Text = "NC" Or CBox_TipoDocumento.Text = "NCS" Then
            Referencia_Numero = txtb_DocReferencia.Text
            Referencia_TipoDoc = "01"
            Referencia_FechaEmision = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneFechaEmisionComprobantes(txtb_DocReferencia.Text.Trim(), "FE")
            Referencia_Codigo = "01"
            Referencia_Razon = "Anula Documento de Referencia"
        End If


        DocTotal = CDbl(txtb_TotalDocumento.Text)
        DocSubTotal = CDbl(txtb_SubTotal.Text)
        DocTotalImpuesto = CDbl(txtb_TotalImpuesto.Text)
        DocTotalDescuento = CDbl(txtb_TotalDescuento.Text)
        DocSaldo = CDbl(txtb_TotalSaldo.Text)
        Comments = txtb_Comentarios.Text
        MH_Status = ""
        MH_Message = ""
        TotalGravado = CDbl(txtb_TotalGravado.Text)
        TotalExento = CDbl(txtb_TotalExento.Text)

        Status = ""
        Printed = "0"
        ID_User = "0"
        Nombre_User = ""



        'cuando sea anulada la factura entrara aqui



        'guarda el encabezado
        If Me.Text = "Nota de credito" Then
            DocNum = Class_VariablesGlobales.Obj_Funciones_SQL.GuardarCE_NC(Class_VariablesGlobales.SQL_Comman2, CodCliente, DocNum, Clave, Consecutivo, DocDate, DocDueDate, DocTime, DocType, DocSubType, Status, Printed, ID_User, Nombre_User, Emisor_Nombre, Emisor_NombreComercial, Emisor_Tipo, Emisor_Numero, Emisor_Provincia, Emisor_Canton, Emisor_Distrito, Emisor_Barrio, Emisor_OtrasSenas, Emisor_CorreoElectronico, Receptor_Nombre, Receptor_NombreComercial, Receptor_Tipo, Receptor_Numero, Receptor_IdentificacionExtranjero, Receptor_Provincia, Receptor_Canton, Receptor_Distrito, Receptor_Barrio, Receptor_OtrasSenas, Receptor_CorreoElectronico, CondicionVenta, PlazoCredito, MedioPago, Referencia_Numero, Referencia_TipoDoc, Referencia_FechaEmision, Referencia_Codigo, Referencia_Razon, DocTotal, DocSubTotal, DocTotalImpuesto, DocTotalDescuento, DocSaldo, Comments, MH_Status, MH_Message, TotalGravado, TotalExento, Vendedor, CodMoneda, TipoCambio)

        ElseIf Me.Text = "Proforma" Then
            DocNum = Class_VariablesGlobales.Obj_Funciones_SQL.GuardarCE_FP(Class_VariablesGlobales.SQL_Comman2, CodCliente, DocNum, Clave, Consecutivo, DocDate, DocDueDate, DocTime, DocType, DocSubType, Status, Printed, ID_User, Nombre_User, Emisor_Nombre, Emisor_NombreComercial, Emisor_Tipo, Emisor_Numero, Emisor_Provincia, Emisor_Canton, Emisor_Distrito, Emisor_Barrio, Emisor_OtrasSenas, Emisor_CorreoElectronico, Receptor_Nombre, Receptor_NombreComercial, Receptor_Tipo, Receptor_Numero, Receptor_IdentificacionExtranjero, Receptor_Provincia, Receptor_Canton, Receptor_Distrito, Receptor_Barrio, Receptor_OtrasSenas, Receptor_CorreoElectronico, CondicionVenta, PlazoCredito, MedioPago, Referencia_Numero, Referencia_TipoDoc, Referencia_FechaEmision, Referencia_Codigo, Referencia_Razon, DocTotal, DocSubTotal, DocTotalImpuesto, DocTotalDescuento, DocSaldo, Comments, MH_Status, MH_Message, TotalGravado, TotalExento, Vendedor, CodMoneda, TipoCambio)
        Else


            DocNum = Class_VariablesGlobales.Obj_Funciones_SQL.GuardarCE_FE(Class_VariablesGlobales.SQL_Comman2, CodCliente, DocNum, Clave, Consecutivo, DocDate, DocDueDate, DocTime, DocType, DocSubType, Status, Printed, ID_User, Nombre_User, Emisor_Nombre, Emisor_NombreComercial, Emisor_Tipo, Emisor_Numero, Emisor_Provincia, Emisor_Canton, Emisor_Distrito, Emisor_Barrio, Emisor_OtrasSenas, Emisor_CorreoElectronico, Receptor_Nombre, Receptor_NombreComercial, Receptor_Tipo, Receptor_Numero, Receptor_IdentificacionExtranjero, Receptor_Provincia, Receptor_Canton, Receptor_Distrito, Receptor_Barrio, Receptor_OtrasSenas, Receptor_CorreoElectronico, CondicionVenta, PlazoCredito, MedioPago, Referencia_Numero, Referencia_TipoDoc, Referencia_FechaEmision, Referencia_Codigo, Referencia_Razon, DocTotal, DocSubTotal, DocTotalImpuesto, DocTotalDescuento, DocSaldo, Comments, MH_Status, MH_Message, TotalGravado, TotalExento, Vendedor, CodMoneda, TipoCambio)

        End If

        '-100 es codigo de error de esso para impedir agregar el detalle ya que el numero de pedido ya existe
        If DocNum <> -100 Then
            'Al ser una insercion exitosa debe actualizar el consecutivo para la proxima factura
            Class_VariablesGlobales.Obj_Funciones_SQL.AumentaConsecutivoProximoDocumento(DocType, DocNum)

            'guarda las lineas

            Dim NumLinea = ""
            Dim ItemCode = ""
            Dim ItemName = ""
            Dim Pack = ""
            Dim UnidadMedida = ""
            Dim Costo = ""
            Dim PrecioUnitario = ""
            Dim Utilidad_Porciento = ""
            Dim Utilidad_Monto = ""
            Dim Cantidad = ""
            Dim Descuento_Porciento = ""
            Dim Descuento_Monto = ""
            Dim CodigoTarifa = ""
            Dim Impuesto_Porciento = ""
            Dim Impuesto_Monto = ""
            Dim SubTotal = ""
            Dim Total = ""
            Dim Descuento_Promo_Porciento = ""
            Dim Descuento_Promo_Monto = ""
            Dim Descuento_Interno_Porciento = ""
            Dim Descuento_Interno_Monto = ""

            For i As Integer = 0 To DGV_DetalleFactura.RowCount - 2


                NumLinea = DGV_DetalleFactura("NumLinea", i).Value.ToString()
                ItemCode = DGV_DetalleFactura("ItemCode", i).Value.ToString()
                ItemName = DGV_DetalleFactura("ItemName", i).Value.ToString()
                Pack = DGV_DetalleFactura("Pack", i).Value.ToString()
                UnidadMedida = DGV_DetalleFactura("UnidadMedida", i).Value.ToString()
                Costo = DGV_DetalleFactura("Costo", i).Value.ToString()
                PrecioUnitario = DGV_DetalleFactura("PrecioUnitario", i).Value.ToString()
                Utilidad_Porciento = DGV_DetalleFactura("Utilidad_Porciento", i).Value.ToString()
                Utilidad_Monto = DGV_DetalleFactura("Utilidad_Monto", i).Value.ToString()
                Cantidad = DGV_DetalleFactura("Cantidad", i).Value.ToString()
                Descuento_Porciento = DGV_DetalleFactura("Descuento_Porciento", i).Value.ToString()
                Descuento_Monto = DGV_DetalleFactura("Descuento_Monto", i).Value.ToString()
                CodigoTarifa = DGV_DetalleFactura("CodigoTarifa", i).Value.ToString()
                Impuesto_Porciento = DGV_DetalleFactura("Impuesto_Porciento", i).Value.ToString()
                Impuesto_Monto = DGV_DetalleFactura("Impuesto_Monto", i).Value.ToString()
                SubTotal = DGV_DetalleFactura("SubTotal", i).Value.ToString()
                Total = DGV_DetalleFactura("Total", i).Value.ToString()
                Descuento_Promo_Porciento = DGV_DetalleFactura("Descuento_Promo_Porciento", i).Value.ToString()
                Descuento_Promo_Monto = DGV_DetalleFactura("Descuento_Promo_Monto", i).Value.ToString()
                Descuento_Interno_Porciento = DGV_DetalleFactura("Descuento_Interno_Porciento", i).Value.ToString()
                Descuento_Interno_Monto = DGV_DetalleFactura("Descuento_Interno_Monto", i).Value.ToString()

                If Me.Text = "Nota de credito" Then
                    Class_VariablesGlobales.Obj_Funciones_SQL.GuardarCE_NC1(DocNum, DocType, NumLinea, ItemCode, ItemName, Pack, UnidadMedida, Costo, PrecioUnitario, Utilidad_Porciento, Utilidad_Monto, Cantidad, Descuento_Porciento, Descuento_Monto, Impuesto_Porciento, Impuesto_Monto, SubTotal, Total, Descuento_Promo_Porciento, Descuento_Promo_Monto, Descuento_Interno_Porciento, Descuento_Interno_Monto, CodigoTarifa)

                Else
                    Class_VariablesGlobales.Obj_Funciones_SQL.GuardarCE_FE1(DocNum, DocType, NumLinea, ItemCode, ItemName, Pack, UnidadMedida, Costo, PrecioUnitario, Utilidad_Porciento, Utilidad_Monto, Cantidad, Descuento_Porciento, Descuento_Monto, Impuesto_Porciento, Impuesto_Monto, SubTotal, Total, Descuento_Promo_Porciento, Descuento_Promo_Monto, Descuento_Interno_Porciento, Descuento_Interno_Monto, CodigoTarifa)

                End If

                NumLinea = ""
                ItemCode = ""
                ItemName = ""
                Pack = ""
                UnidadMedida = ""
                Costo = ""
                PrecioUnitario = ""
                Utilidad_Porciento = ""
                Utilidad_Monto = ""
                Cantidad = ""
                Descuento_Porciento = ""
                Descuento_Monto = ""
                Impuesto_Porciento = ""
                Impuesto_Monto = ""
                SubTotal = ""
                Total = ""
                Descuento_Promo_Porciento = ""
                Descuento_Promo_Monto = ""
                Descuento_Interno_Porciento = ""
                Descuento_Interno_Monto = ""
                CodigoTarifa = ""
            Next
            'Aumenta consecutivo
            If Me.Text = "Nota de credito" Then
                MsgBox("Nota de credito creada con exito")
            Else
                MsgBox("Factura creada con exito")
            End If

            DocNum = Nothing
            Clave = Nothing
            Consecutivo = Nothing
            DocDate = Nothing
            DocDueDate = Nothing
            DocTime = Nothing
            DocType = Nothing
            DocSubType = Nothing
            Status = Nothing
            Printed = Nothing
            ID_User = Nothing
            Nombre_User = Nothing
            Emisor_Nombre = Nothing
            Emisor_NombreComercial = Nothing
            Emisor_Tipo = Nothing
            Emisor_Numero = Nothing
            Emisor_Provincia = Nothing
            Emisor_Canton = Nothing
            Emisor_Distrito = Nothing
            Emisor_Barrio = Nothing
            Emisor_OtrasSenas = Nothing
            Emisor_CorreoElectronico = Nothing
            Receptor_Nombre = Nothing
            Receptor_NombreComercial = Nothing
            Receptor_Tipo = Nothing
            Receptor_Numero = Nothing
            Receptor_IdentificacionExtranjero = Nothing
            Receptor_Provincia = Nothing
            Receptor_Canton = Nothing
            Receptor_Distrito = Nothing
            Receptor_Barrio = Nothing
            Receptor_OtrasSenas = Nothing
            Receptor_CorreoElectronico = Nothing
            CondicionVenta = Nothing
            PlazoCredito = Nothing
            MedioPago = Nothing
            Referencia_Numero = Nothing
            Referencia_TipoDoc = Nothing
            Referencia_FechaEmision = Nothing
            Referencia_Codigo = Nothing
            Referencia_Razon = Nothing
            DocTotal = Nothing
            DocSubTotal = Nothing
            DocTotalImpuesto = Nothing
            DocTotalDescuento = Nothing
            DocSaldo = Nothing
            Comments = Nothing
            MH_Status = Nothing
            MH_Message = Nothing
            CodMoneda = Nothing
            TipoCambio = Nothing

            'Lineas detalladsa
            NumLinea = Nothing
            ItemCode = Nothing
            ItemName = Nothing
            Pack = Nothing
            UnidadMedida = Nothing
            Costo = Nothing
            PrecioUnitario = Nothing
            Utilidad_Porciento = Nothing
            Utilidad_Monto = Nothing
            Cantidad = Nothing
            Descuento_Porciento = Nothing
            Descuento_Monto = Nothing
            Impuesto_Porciento = Nothing
            Impuesto_Monto = Nothing
            SubTotal = Nothing
            Total = Nothing
            Descuento_Promo_Porciento = Nothing
            Descuento_Promo_Monto = Nothing
            Descuento_Interno_Porciento = Nothing
            Descuento_Interno_Monto = Nothing
            CodigoTarifa = Nothing



            'inicio
            Limpiar()
            Inicio()
        End If

        Return True
    End Function
    Public Function Limpiar()
        Try
            'Limpia campos
            Me.txtb_clave.Text = ""
            Me.Txtb_DocNum.Text = ""
            Me.txtb_Impreso.Text = ""
            Me.CBox_Estado.Text = ""
            Me.txtb_Consecutivo.Text = ""
            Me.txtb_DiasRestantes.Text = ""
            Me.txtb_Nombre.Text = ""
            Me.txtb_NombreFantacia.Text = ""
            Me.txtb_DocReferencia.Text = ""
            Me.CBox_TipoProducto.Text = "Servicio"
            Me.CBox_TipoVenta.Text = "Contado"
            Me.Txtb_plazoCredito.Text = ""
            Me.CBox_Vendedor.Text = ""
            Me.txtb_Comentarios.Text = ""
            Me.txtb_EstadoHacienda.Text = ""
            Me.txtb_RespuestaHacienda.Text = ""

            Me.txtb_TotalGravado.Text = "0.00"
            Me.txtb_TotalExento.Text = "0.00"
            Me.txtb_SubTotal.Text = "0.00"
            Me.txtb_TotalImpuesto.Text = "0.00"
            Me.txtb_TotalDescuento.Text = "0.00"
            Me.txtb_TotalDocumento.Text = "0.00"
            Me.txtb_TotalSaldo.Text = "0.00"
            'Limpia las tablas temporales
            VariablesGlobales.Obj_SQL.Elimina_TblTemporadoresFacturacion(Class_VariablesGlobales.SQL_Comman1)
            'Limpia finalas
            EliminaTodaLasFila()

            DocNum = Nothing
            Clave = Nothing
            Consecutivo = Nothing
            DocDate = Nothing
            DocDueDate = Nothing
            DocTime = Nothing
            DocType = Nothing
            DocSubType = Nothing
            Status = Nothing
            Printed = Nothing
            ID_User = Nothing
            Nombre_User = Nothing
            Emisor_Nombre = Nothing
            Emisor_NombreComercial = Nothing
            Emisor_Tipo = Nothing
            Emisor_Numero = Nothing
            Emisor_Provincia = Nothing
            Emisor_Canton = Nothing
            Emisor_Distrito = Nothing
            Emisor_Barrio = Nothing
            Emisor_OtrasSenas = Nothing
            Emisor_CorreoElectronico = Nothing
            Receptor_Nombre = Nothing
            Receptor_NombreComercial = Nothing
            Receptor_Tipo = Nothing
            Receptor_Numero = Nothing
            Receptor_IdentificacionExtranjero = Nothing
            Receptor_Provincia = Nothing
            Receptor_Canton = Nothing
            Receptor_Distrito = Nothing
            Receptor_Barrio = Nothing
            Receptor_OtrasSenas = Nothing
            Receptor_CorreoElectronico = Nothing
            CondicionVenta = Nothing
            PlazoCredito = Nothing
            MedioPago = Nothing
            Referencia_Numero = Nothing
            Referencia_TipoDoc = Nothing
            Referencia_FechaEmision = Nothing
            Referencia_Codigo = Nothing
            Referencia_Razon = Nothing
            DocTotal = Nothing
            DocSubTotal = Nothing
            DocTotalImpuesto = Nothing
            DocTotalDescuento = Nothing
            DocSaldo = Nothing
            Comments = Nothing
            MH_Status = Nothing
            MH_Message = Nothing


            'Lineas detalladsa
            NumLinea = Nothing
            ItemCode = Nothing
            ItemName = Nothing
            Pack = Nothing
            UnidadMedida = Nothing
            Costo = Nothing
            PrecioUnitario = Nothing
            Utilidad_Porciento = Nothing
            Utilidad_Monto = Nothing
            Cantidad = Nothing
            Descuento_Porciento = Nothing
            Descuento_Monto = Nothing
            Impuesto_Porciento = Nothing
            Impuesto_Monto = Nothing
            SubTotal = Nothing
            Total = Nothing
            Descuento_Promo_Porciento = Nothing
            Descuento_Promo_Monto = Nothing
            Descuento_Interno_Porciento = Nothing
            Descuento_Interno_Monto = Nothing
            'CodigoTarifa = Nothing
        Catch ex As Exception

        End Try
    End Function
    Public Function Inicio()
        Try
            'txtb_Consecutivo.Text = VariablesGlobales.Obj_SQL.ObtieneConsecutivoFacturas(Class_VariablesGlobales.SQL_Comman1, "FE")
            Dim Conectado As String
            Dim DNum As String
            If Class_VariablesGlobales.obj_Validaconexion.IsConnectionAvailable() = True Then Conectado = "1" Else Conectado = "3"


            'Define cual comprobante es el que se creara
            If Class_VariablesGlobales.ComprobanteACrear = "Factura" Then

                Txtb_DocNum.Text = CInt(VariablesGlobales.Obj_SQL.ObtieneConsecutivoACrear("FE"))
                DNum = CInt(Txtb_DocNum.Text)
                'Le resto 8 debido a que se hicieron 8 factuas electronicas con un consecutivo equivocado se debia empezar en 0000001 y al final empezamos en 001000001 por lo que debia modificarse el consecutivo y colocarlo en 1
                'como el consecutivo de la tabla donde se almacenan las facturas sera el que genere la clave debe pegar igual al consecutivo que usara el sistema de hacieda para que cuando se le de anular a las facturas la clave de referencia
                'sea igual a la de la factura que se mando a hacienda,en fin NO BORRE LA RESTA DE 8
                txtb_Consecutivo.Text = "0010000101" & CStr(CInt(DNum) - 7).PadLeft(10, "0")
                Me.Text = "Facturas"
                CBox_TipoDocumento.Text = "FE"

            ElseIf Class_VariablesGlobales.ComprobanteACrear = "NotaDeCredito" Then
                Txtb_DocNum.Text = CInt(VariablesGlobales.Obj_SQL.ObtieneConsecutivoACrear("NC"))
                DNum = CInt(Txtb_DocNum.Text)
                txtb_Consecutivo.Text = "0010000103" & CStr(CInt(DNum)).PadLeft(10, "0") '"0000000033"
                Me.Text = "Nota de credito"
                CBox_TipoDocumento.Text = "NC"
            ElseIf Class_VariablesGlobales.ComprobanteACrear = "NotasDebito" Then
                Txtb_DocNum.Text = CInt(VariablesGlobales.Obj_SQL.ObtieneConsecutivoACrear("ND"))
                DNum = CInt(Txtb_DocNum.Text)
                txtb_Consecutivo.Text = "0010000102" & CStr(CInt(DNum)).PadLeft(10, "0") '"0000000033"
                Me.Text = "Notas de debito"
                CBox_TipoDocumento.Text = "ND"


            ElseIf Class_VariablesGlobales.ComprobanteACrear = "Proforma" Then
                Txtb_DocNum.Text = CInt(VariablesGlobales.Obj_SQL.ObtieneConsecutivoACrear("Proforma"))
                DNum = CInt(Txtb_DocNum.Text)
                txtb_Consecutivo.Text = CStr(CInt(DNum)).PadLeft(10, "0")
                Me.Text = "Proforma"
                CBox_TipoDocumento.Text = "Proforma"
            End If





            ' txtb_Consecutivo.Text = CInt(VariablesGlobales.Obj_SQL.ObtieneConsecutivoFacturas(Class_VariablesGlobales.SQL_Comman2, "FE"))
            txtb_clave.Text = "506" & String.Format("{0:00}", Now.Day) & String.Format("{0:00}", Now.Month) & Now.Year.ToString.Substring(0, 2) & VariablesGlobales.Obj_SQL.ObtieneCedulaEmpresa(Class_VariablesGlobales.SQL_Comman1).PadLeft(12, "0") & txtb_Consecutivo.Text & Conectado & (DNum).PadLeft(8, "0")
            TablaTemporal()

           ' ObtieneEmisor()

            Dim TblAgentes As DataTable = New DataTable
            TblAgentes = VariablesGlobales.Obj_SQL.ObtieneVendedores(Class_VariablesGlobales.SQL_Comman2)

            With CBox_Vendedor
                .DataSource = TblAgentes
                .DisplayMember = "Nombre_Vendedor"
                .ValueMember = "id_Vendedor"
            End With



        Catch ex As Exception

        End Try
    End Function
    Public Function ObtieneEmisor()
        Try
            Dim tabla As New DataTable
            Dim contardor As Integer = 0
            tabla = Class_VariablesGlobales.Obj_Funciones_SQL.CONSULTA_Empresa(Class_VariablesGlobales.SQL_Comman2)

            While contardor < tabla.Rows.Count
                Emisor_Nombre = tabla.Rows(contardor).Item("Nombre").ToString()
                Emisor_NombreComercial = tabla.Rows(contardor).Item("NombreComercial").ToString()
                Emisor_Tipo = tabla.Rows(contardor).Item("Tipo_Cedula").ToString()
                Emisor_Numero = tabla.Rows(contardor).Item("Cedula").ToString()
                Emisor_Provincia = tabla.Rows(contardor).Item("id_Provincia").ToString()
                Emisor_Canton = tabla.Rows(contardor).Item("id_canton").ToString()
                Emisor_Distrito = tabla.Rows(contardor).Item("id_distrito").ToString()
                Emisor_Barrio = tabla.Rows(contardor).Item("id_barrio").ToString()
                Emisor_OtrasSenas = tabla.Rows(contardor).Item("Direccion").ToString()
                Emisor_CorreoElectronico = tabla.Rows(contardor).Item("ClaveEmail").ToString()

                contardor += 1
            End While
        Catch ex As Exception

        End Try
    End Function

    Private Sub Facturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Obtiene informacion del emisor

        Limpiar()
        Inicio()




    End Sub


    Public Function CalculaTotal()
        Dim total As Double
        Dim Subtotal As Double
        Dim Mont_Imp As Double
        Dim Mont_Desc As Double
        Dim Obj_Mformat As New MonedaFormat

        Dim TotalGravado As Double
        Dim TotalExento As Double

        For Each row As DataGridViewRow In DGV_DetalleFactura.Rows


            Mont_Imp += CDbl(row.Cells("Impuesto_Monto").Value)
            Subtotal += CDbl(row.Cells("SubTotal").Value)
            Mont_Desc += CDbl(row.Cells("Descuento_Monto").Value)
            total += CDbl(row.Cells("Total").Value)
            If CDbl(row.Cells("Impuesto_Monto").Value) <> 0 Then
                TotalGravado += CDbl(row.Cells("Subtotal").Value)
            Else
                TotalExento += CDbl(row.Cells("Subtotal").Value)
            End If


        Next


        txtb_SubTotal.Text = Obj_Mformat.FormatoMoneda(Subtotal)
        txtb_TotalDescuento.Text = Obj_Mformat.FormatoMoneda(Mont_Desc)
        txtb_TotalImpuesto.Text = Obj_Mformat.FormatoMoneda(Mont_Imp)
        txtb_TotalDocumento.Text = Obj_Mformat.FormatoMoneda(total)
        txtb_TotalSaldo.Text = Obj_Mformat.FormatoMoneda(total)

        txtb_TotalGravado.Text = Obj_Mformat.FormatoMoneda(TotalGravado)
        txtb_TotalExento.Text = Obj_Mformat.FormatoMoneda(TotalExento)
        total = Nothing
        Subtotal = Nothing
        Mont_Imp = Nothing
        Mont_Desc = Nothing

    End Function
    Public Function ObtieneLineas(Docnum As String)
        Try
            DGV_DetalleFactura.DataSource = VariablesGlobales.Obj_SQL.ObtieneLineasTemp(Class_VariablesGlobales.SQL_Comman2, txtb_Consecutivo.Text)
            DGV_DetalleFactura.Columns(20).Visible = False
        Catch ex As Exception

        End Try

    End Function
    Public Function TablaTemporal()
        Try



            Dim Tabla As New DataTable
            '---------- Creamos las columnas ---------------
            With Tabla
                .Columns.Add("NumLinea")
                .Columns.Add("ItemCode")
                .Columns.Add("ItemName")
                .Columns.Add("Pack")
                .Columns.Add("UnidadMedida")
                .Columns.Add("Costo")
                .Columns.Add("PrecioUnitario")
                .Columns.Add("Utilidad_Porciento")
                .Columns.Add("Utilidad_Monto")
                .Columns.Add("Cantidad")
                .Columns.Add("Descuento_Porciento")
                .Columns.Add("Descuento_Monto")
                .Columns.Add("Impuesto_Porciento")
                .Columns.Add("Impuesto_Monto")
                .Columns.Add("SubTotal")
                .Columns.Add("Total")
                .Columns.Add("Descuento_Promo_Porciento")
                .Columns.Add("Descuento_Promo_Monto")
                .Columns.Add("Descuento_Interno_Porciento")
                .Columns.Add("Descuento_Interno_Monto")
            End With

            Dim ciclos As Integer = 1
            Dim datoFila As DataRow
            While ciclos < 20
                datoFila = Tabla.NewRow()
                If ciclos = 1 Then

                    datoFila("NumLinea") = ciclos
                Else
                    datoFila("NumLinea") = ""
                End If
                datoFila("ItemCode") = ""
                datoFila("ItemName") = ""
                datoFila("Pack") = ""
                datoFila("UnidadMedida") = ""
                datoFila("Costo") = ""
                datoFila("PrecioUnitario") = ""
                datoFila("Utilidad_Porciento") = ""
                datoFila("Utilidad_Monto") = ""
                datoFila("Cantidad") = ""
                datoFila("Descuento_Porciento") = ""
                datoFila("Descuento_Monto") = ""
                datoFila("Impuesto_Porciento") = ""
                datoFila("Impuesto_Monto") = ""
                datoFila("SubTotal") = ""
                datoFila("Total") = ""
                datoFila("Descuento_Promo_Porciento") = ""
                datoFila("Descuento_Promo_Monto") = ""
                datoFila("Descuento_Interno_Porciento") = ""
                datoFila("Descuento_Interno_Monto") = ""


                ciclos += 1
                Tabla.NewRow()

                Tabla.Rows.Add(datoFila)


            End While

            DGV_DetalleFactura.DataSource = Tabla
            ciclos = 1

            While ciclos < 20
                If ciclos Mod 2 = 0 Then
                    DGV_DetalleFactura.Rows(ciclos).DefaultCellStyle.BackColor = Color.LightGray


                    DGV_DetalleFactura.Rows(ciclos).ReadOnly = False
                Else
                    DGV_DetalleFactura.Rows(ciclos).DefaultCellStyle.BackColor = Color.White

                    DGV_DetalleFactura.Rows(ciclos).ReadOnly = True
                End If


                ciclos += 1
            End While
            DGV_DetalleFactura.RowHeadersVisible = False
            DGV_DetalleFactura.AutoResizeColumnHeadersHeight()

            With DGV_DetalleFactura
                .Columns(0).Width = 20 ' NumLinea
                .Columns(0).ReadOnly = True ' NumLinea
                .Columns(0).DefaultCellStyle.BackColor = Color.LightGray  ' NumLinea
                .Columns(0).HeaderText = "#" ' NumLinea
                .Columns(1).Width = 100 ' ItemCode
                .Columns(1).HeaderText = "Codigo" ' ItemCode
                .Columns(2).Width = 450 ' ItemName
                .Columns(2).HeaderText = "Descripcion"
                .Columns(3).Width = 30 ' Pack
                .Columns(4).Width = 40 ' UnidadMedida
                .Columns(4).HeaderText = "UnidMedida"
                .Columns(5).Width = 100 ' Costo
                .Columns(6).Width = 100 ' PrecioUnitario
                .Columns(6).HeaderText = "Precio"
                .Columns(7).Width = 20 ' Utilidad_Porciento
                .Columns(7).HeaderText = "% Utilidad"
                .Columns(7).Visible = False
                .Columns(8).Width = 100 ' Utilidad_Monto
                .Columns(8).HeaderText = "Total Utilidad"
                .Columns(8).Visible = False
                .Columns(9).Width = 100 ' Cantidad
                .Columns(10).Width = 50 ' Descuento_Porciento
                .Columns(10).HeaderText = "% Desc"
                .Columns(11).Width = 100 ' Descuento_Monto
                .Columns(11).HeaderText = "Total Descuento"
                .Columns(12).Width = 50 ' Impuesto_Porciento
                .Columns(12).HeaderText = "IV"
                .Columns(13).Width = 100 ' Impuesto_Monto
                .Columns(13).HeaderText = "Total Impuesto"
                .Columns(14).Width = 100 ' SubTotal
                .Columns(15).Width = 100 ' Total
                .Columns(16).Width = 50 ' Descuento_Promo_Porciento
                .Columns(16).HeaderText = "% DescPromo"
                .Columns(16).Visible = False
                .Columns(17).Width = 100 ' Descuento_Promo_Monto
                .Columns(17).HeaderText = "Total DescPromo"
                .Columns(17).Visible = False
                .Columns(18).Width = 50 ' Descuento_Interno_Porciento
                .Columns(18).HeaderText = "% DescInterno"
                .Columns(18).Visible = False
                .Columns(19).Width = 100 ' Descuento_Interno_Monto
                .Columns(19).HeaderText = "Total DescInterno"
                .Columns(19).Visible = False
            End With




        Catch ex As Exception

        End Try
    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btn_BuscarClientes.Click
        Class_VariablesGlobales.ClientesLlamadoDesde = "Facturacion"
        Class_VariablesGlobales.frmLista_ClientesModificados = New Lista_ClientesModificados
        Class_VariablesGlobales.frmLista_ClientesModificados.MdiParent = Principal
        Class_VariablesGlobales.frmLista_ClientesModificados.CBX_Estado.Text = "Interno"
        Class_VariablesGlobales.frmLista_ClientesModificados.Show()



    End Sub

    Private Sub DGV_DetalleFactura_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_DetalleFactura.CellEndEdit

        Try


            '.Columns.Add("NumLinea")
            '.Columns.Add("ItemCode")
            '.Columns.Add("ItemName")
            '.Columns.Add("Pack")
            '.Columns.Add("UnidadMedida")
            '.Columns.Add("Costo")
            '.Columns.Add("PrecioUnitario")
            '.Columns.Add("Utilidad_Porciento")
            '.Columns.Add("Utilidad_Monto")
            '.Columns.Add("Cantidad")
            '.Columns.Add("Descuento_Porciento")
            '.Columns.Add("Descuento_Monto")
            '.Columns.Add("Impuesto_Porciento")
            '.Columns.Add("Impuesto_Monto")
            '.Columns.Add("SubTotal")
            '.Columns.Add("Total")
            '.Columns.Add("Descuento_Promo_Porciento")
            '.Columns.Add("Descuento_Promo_Monto")
            '.Columns.Add("Descuento_Interno_Porciento")
            '.Columns.Add("Descuento_Interno_Monto")
            Dim xy As New Point
            Dim ItemCode As String
            Dim ItemName As String
            xy = DGV_DetalleFactura.CurrentCellAddress
            If xy.X = 1 Then
                'Indica que esta buscando por codigo de articulos
                ItemCode = DGV_DetalleFactura.Rows(xy.Y).Cells(xy.X).Value
            ElseIf xy.X = 2 Then
                'Indica que esta buscando por descripcion del artuculo
                ItemName = DGV_DetalleFactura.Rows(xy.Y).Cells(xy.X).Value

            End If



            PrecioUnitario = DGV_DetalleFactura.Rows(xy.Y).Cells("PrecioUnitario").Value
            Cantidad = DGV_DetalleFactura.Rows(xy.Y).Cells("Cantidad").Value
            Descuento_Porciento = DGV_DetalleFactura.Rows(xy.Y).Cells("Descuento_Porciento").Value
            Descuento_Monto = DGV_DetalleFactura.Rows(xy.Y).Cells("Descuento_Monto").Value
            Impuesto_Porciento = DGV_DetalleFactura.Rows(xy.Y).Cells("Impuesto_Porciento").Value
            Impuesto_Monto = DGV_DetalleFactura.Rows(xy.Y).Cells("Impuesto_Monto").Value
            SubTotal = DGV_DetalleFactura.Rows(xy.Y).Cells("SubTotal").Value
            Total = DGV_DetalleFactura.Rows(xy.Y).Cells("Total").Value

            'Calcula totales de linea y de factura
            If Trim(Impuesto_Porciento) = "13" Then
                txtb_SubTotal.Text = (Cantidad * PrecioUnitario) + ((Cantidad * PrecioUnitario) * 13) / 100
                DGV_DetalleFactura.Rows(xy.Y).Cells("Impuesto_Monto").Value = ((Cantidad * PrecioUnitario) * 13) / 100
            ElseIf Trim(Impuesto_Porciento) = "2" Then
                txtb_SubTotal.Text = (Cantidad * PrecioUnitario) + ((Cantidad * PrecioUnitario) * 2) / 100
                DGV_DetalleFactura.Rows(xy.Y).Cells("Impuesto_Monto").Value = ((Cantidad * PrecioUnitario) * 2) / 100
            ElseIf Trim(Impuesto_Porciento) = "4" Then
                txtb_SubTotal.Text = (Cantidad * PrecioUnitario) + ((Cantidad * PrecioUnitario) * 4) / 100
                DGV_DetalleFactura.Rows(xy.Y).Cells("Impuesto_Monto").Value = ((Cantidad * PrecioUnitario) * 4) / 100
            ElseIf Trim(Impuesto_Porciento) = "8" Then
                txtb_SubTotal.Text = (Cantidad * PrecioUnitario) + ((Cantidad * PrecioUnitario) * 8) / 100
                DGV_DetalleFactura.Rows(xy.Y).Cells("Impuesto_Monto").Value = ((Cantidad * PrecioUnitario) * 8) / 100
            Else
                txtb_SubTotal.Text = (Cantidad * PrecioUnitario)

            End If



            DGV_DetalleFactura.Rows(xy.Y).Cells("SubTotal").Value = txtb_SubTotal.Text

            If Descuento_Porciento <> "0" Then
                DGV_DetalleFactura.Rows(xy.Y).Cells("Descuento_Monto").Value = (txtb_SubTotal.Text * Descuento_Porciento) / 100
                txtb_SubTotal.Text = txtb_SubTotal.Text - (txtb_SubTotal.Text * Descuento_Porciento) / 100
            End If

            DGV_DetalleFactura.Rows(xy.Y).Cells("Total").Value = txtb_SubTotal.Text

            'Hat que restarle o sumarle el nuevo monto segun sea mayor o menor al original de la linea

            txtb_TotalImpuesto.Text = ""
            txtb_TotalDescuento.Text = ""
            txtb_TotalDocumento.Text = ""
            txtb_TotalSaldo.Text = ""

            'Limpia
            PrecioUnitario = "0"
            Cantidad = "0"
            Descuento_Porciento = "0"
            Descuento_Monto = "0"

            If ItemCode <> "" Or ItemName <> "" Then
                Class_VariablesGlobales.ArticulosLlamadoDesde = "Facturacion"


                Class_VariablesGlobales.frmArticulos = New Articulos
                Class_VariablesGlobales.frmArticulos.MdiParent = Principal
                Class_VariablesGlobales.frmArticulos.Busca = ""
                Class_VariablesGlobales.frmArticulos.Show()
            End If

            CalculaTotal()
        Catch ex As Exception

        End Try

        'Buscar por codigo
    End Sub

    Private Sub DGV_DetalleFactura_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_DetalleFactura.CellContentClick
        Try

            If Guardada = False Then
                DGV_DetalleFactura.Rows(e.RowIndex).Selected = True
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub DGV_DetalleFactura_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV_DetalleFactura.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            If Guardada = False Then


                Dim Mi_Test As DataGridView.HitTestInfo = Me.DGV_DetalleFactura.HitTest(e.X, e.Y)
                If Mi_Test.Type = DataGridViewHitTestType.Cell Then
                    If Mi_Test.RowIndex >= 0 Then
                        indice = Mi_Test.RowIndex
                        Me.DGV_DetalleFactura.CurrentCell = Me.DGV_DetalleFactura.Rows(Mi_Test.RowIndex).Cells(Mi_Test.ColumnIndex)
                        Me.DGV_DetalleFactura.Rows(Mi_Test.RowIndex).Selected = True
                        menu = New ContextMenuStrip()

                        menu.Items.Add("Agregar", Nothing, New EventHandler(AddressOf AgregarFila))
                        menu.Items.Add("Eliminar", Nothing, New EventHandler(AddressOf EliminarFila))
                        Me.DGV_DetalleFactura.ContextMenuStrip = menu
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub EliminarFila()
        Try



            Me.DGV_DetalleFactura.Rows.RemoveAt(indice)
            'Eliminar la linea de la tabla temporal
            Class_VariablesGlobales.Obj_Funciones_SQL.EliminaLineCE_FE1_temp(Class_VariablesGlobales.frmFacturacion.txtb_Consecutivo.Text, Me.DGV_DetalleFactura.Rows(indice).Cells("NumLinea").Value, Me.DGV_DetalleFactura.Rows(indice).Cells("ItemCode").Value)
            'CalculaTotal()
            CalculaTotal()
        Catch ex As Exception

        End Try


    End Sub
    Private Sub EliminaTodaLasFila()
        Try



            Me.DGV_DetalleFactura.Rows.RemoveAt(indice)
            'Eliminar la linea de la tabla temporal
            Class_VariablesGlobales.Obj_Funciones_SQL.EliminaTodoCE_FE1_temp(Class_VariablesGlobales.frmFacturacion.txtb_Consecutivo.Text)
            'CalculaTotal()
            CalculaTotal()
        Catch ex As Exception

        End Try


    End Sub
    Private Sub AgregarFila()
        Class_VariablesGlobales.ClientesLlamadoDesde = "Facturacion"
        Class_VariablesGlobales.ArticulosLlamadoDesde = "Facturacion"


        Class_VariablesGlobales.frmArticulos = New Articulos
        Class_VariablesGlobales.frmArticulos.MdiParent = Principal
        Class_VariablesGlobales.frmArticulos.Busca = ""
        Class_VariablesGlobales.frmArticulos.Show()

    End Sub
    Public Function Inabilitar()
        'Limpia campos
        Me.txtb_clave.Enabled = False
        Me.Txtb_DocNum.Enabled = False
        Me.txtb_Impreso.Enabled = False
        Me.CBox_Estado.Enabled = False
        Me.txtb_Consecutivo.Enabled = False
        Me.txtb_DiasRestantes.Enabled = False
        Me.txtb_Nombre.Enabled = False
        Me.txtb_NombreFantacia.Enabled = False
        Me.txtb_DocReferencia.Enabled = False
        Me.CBox_TipoProducto.Enabled = False
        Me.CBox_TipoVenta.Enabled = False
        Me.Txtb_plazoCredito.Enabled = False
        Me.CBox_Vendedor.Enabled = False
        Me.txtb_Comentarios.Enabled = False
        Me.txtb_EstadoHacienda.Enabled = False
        Me.txtb_RespuestaHacienda.Enabled = False

        Me.txtb_TotalGravado.Enabled = False
        Me.txtb_TotalExento.Enabled = False
        Me.txtb_SubTotal.Enabled = False
        Me.txtb_TotalImpuesto.Enabled = False
        Me.txtb_TotalDescuento.Enabled = False
        Me.txtb_TotalDocumento.Enabled = False
        Me.txtb_TotalSaldo.Enabled = False

        Me.DTP_TransaccionHasta.Enabled = False
        Me.DTP_TransaccionDesde.Enabled = False
        Me.txtb_CodCliente.Enabled = False
        Me.btn_BuscarClientes.Enabled = False
        Me.btn_guardar.Enabled = False


    End Function
    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        Lista_Facturas.Show()

    End Sub

    Public Sub additems()
        'aqui lo que hariamos seria obtener la informacion segun el keyprss de la celda
    End Sub

    Private Sub DGV_DetalleFactura_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DGV_DetalleFactura.EditingControlShowing

    End Sub






    Private Sub DGV_DetalleFactura_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_DetalleFactura.CellValueChanged
        Dim xy As New Point
        Dim ItemCode As String
        Dim ItemName As String
        xy = DGV_DetalleFactura.CurrentCellAddress
        If xy.X = 1 Then
            'Indica que esta buscando por codigo de articulos
            ItemCode = DGV_DetalleFactura.Rows(xy.Y).Cells(xy.X).Value
        ElseIf xy.X = 2 Then
            'Indica que esta buscando por descripcion del artuculo
            ItemName = DGV_DetalleFactura.Rows(xy.Y).Cells(xy.X).Value

        End If
    End Sub

    Private Sub Facturacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        EliminaTodaLasFila()
        Class_VariablesGlobales.VentanaComprobantesAbierta = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btn_Anular_Click(sender As Object, e As EventArgs) Handles btn_Anular.Click
        'Este boton generara una NC, basicamente almacenara la misma informacion de la factura con la unica diferencia de que en el sutipo del documento almacenara NC

        Dim TipoRef As String = CBox_TipoDocumento.Text

        'Define el documento que se usara para anular
        If CBox_TipoProducto.Text = "Servicio" Then

            If CBox_TipoDocumento.Text = "FE" Then
                DocType = "NCS"
            ElseIf CBox_TipoDocumento.Text = "NC" Then
                DocType = "NDS"
            ElseIf CBox_TipoDocumento.Text = "ND" Then
                DocType = "NCS"
            End If
        Else
            If CBox_TipoDocumento.Text = "FE" Then
                DocType = "NC"
            ElseIf CBox_TipoDocumento.Text = "NC" Then
                DocType = "ND"
            ElseIf CBox_TipoDocumento.Text = "ND" Then
                DocType = "NC"
            End If

            ' DocType = CBox_TipoDocumento.Text
        End If

        'cambia el tipo de documento
        CBox_TipoDocumento.Text = DocType
        ' txtb_Consecutivo.Text = VariablesGlobales.Obj_SQL.ObtieneConsecutivoFacturas(Class_VariablesGlobales.SQL_Comman1, DocType)

        Dim Conectado As String
        If Class_VariablesGlobales.obj_Validaconexion.IsConnectionAvailable() = True Then Conectado = "1" Else Conectado = "3"

        'cambia el estado a anulada
        VariablesGlobales.Obj_SQL.CambiaEstadoAnuado(txtb_clave.Text, TipoRef)
        lbl_Anulada.Visible = True

        'Obtiene la informacion del documento de referencia
        txtb_DocReferencia.Text = txtb_clave.Text

        'Define cual documento crear segun el tipo de documento de refencia
        If Class_VariablesGlobales.ComprobanteACrear = "Factura" Or Class_VariablesGlobales.ComprobanteACrear = "NotasDebito" Then
            'NC
            Txtb_DocNum.Text = CInt(VariablesGlobales.Obj_SQL.ObtieneConsecutivoACrear("NC"))
            txtb_Consecutivo.Text = "0010000103" & Txtb_DocNum.Text.PadLeft(10, "0") '"0000000033"

        ElseIf Class_VariablesGlobales.ComprobanteACrear = "NotaDeCredito" Then
            'ND
            Txtb_DocNum.Text = CInt(VariablesGlobales.Obj_SQL.ObtieneConsecutivoACrear("ND"))
            txtb_Consecutivo.Text = "0010000102" & Txtb_DocNum.Text.PadLeft(10, "0") '"0000000033"

        End If



        txtb_clave.Text = "506" & String.Format("{0:00}", Now.Day) & String.Format("{0:00}", Now.Month) & Now.Year.ToString.Substring(0, 2) & VariablesGlobales.Obj_SQL.ObtieneCedulaEmpresa(Class_VariablesGlobales.SQL_Comman1).PadLeft(12, "0") & txtb_Consecutivo.Text & Conectado & (Txtb_DocNum.Text).PadLeft(8, "0")

        Me.Text = "Nota de credito"
        btn_guardar_Click(sender, e)

    End Sub

    Private Sub Cmb_Moneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Moneda.SelectedIndexChanged

        If Cmb_Moneda.Text = "USD" Then
            txtb_TipoCambio.Enabled = True
            txtb_TipoCambio.BackColor = Color.LightGreen
            txtb_TipoCambio.Focus()
        End If

    End Sub
End Class