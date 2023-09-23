
Imports SAPbobsCOM
Imports System.Data.SqlClient

Public Class SAP_BUSSINES_ONE

    Public Obj_SQL_CONEXIONSERVER As New Class_funcionesSQL
#Region "Crea Depositos"
    Public Function CreaDeposito(ByVal DPCODIGO As String, ByVal DPFECHA As String, ByVal DPBANCO As String, ByVal Total As Double, ByVal SQL_Comman2 As SqlCommand, ByVal Cuenta_Banco As String, ByVal NumLiq As String)
        Try

            Dim vCompany As SAPbobsCOM.Company
            vCompany = Class_VariablesGlobales.obj_SAP.ConectarSap()
            If vCompany.Connected = False Then
                'No se conecto
                vCompany = Nothing
            Else



                Dim ErrCode As Long
                Dim ErrMsg As String


                'Get company service   
                Dim companyService = vCompany.GetCompanyService
                'Get deposit service   
                Dim dpService As SAPbobsCOM.DepositsService = companyService.GetBusinessService(ServiceTypes.DepositsService)
                'Deposit with Cash  
                Dim dpsAddCash As SAPbobsCOM.Deposit = dpService.GetDataInterface(DepositsServiceDataInterfaces.dsDeposit)
                'Deposit with Cash   

                '--------------DEPOSITO MEDIANTE EFECTIVO------------------
                dpsAddCash.DepositType = BoDepositTypeEnum.dtCash
                'ENVIA EL TIPO DE MONEDA DEL DEPOSITO  
                dpsAddCash.DepositCurrency = "COL"
                'CUENTA DE ASIGNACION SERIA CAJA GENERAL EN BOURNE 
                dpsAddCash.AllocationAccount = "10100101001"
                dpsAddCash.DepositAccount = Cuenta_Banco
                dpsAddCash.TotalLC = Total
                dpsAddCash.JournalRemarks = "DEPOSITO EN LIQUIDACION DE AGENTE " & NumLiq
                dpsAddCash.DepositDate = CDate(DPFECHA)
                dpsAddCash.BankReference = DPCODIGO
                'Agrega el deposito
                Try
                    Dim dpsParamAddCash As SAPbobsCOM.DepositParams = dpService.AddDeposit(dpsAddCash)
                    Return 0
                Catch ex As Exception
                    MsgBox("Fallo la subido del deposito [ " & DPCODIGO & "] detalle error :" & ex.Message)
                    Return 1

                End Try

                If vCompany.Connected = False Then
                    DesconectarSap(vCompany)
                End If
            End If
        Catch ex As Exception
            Return 1
        End Try
    End Function

#End Region

#Region "Crear Orden de Comptra"
    Public Function AddOrderClient(ByVal Agente As String, ByVal Tbl_Enc_Pedido As DataTable, ByVal Tbl_Det_Pedido As DataTable, ByVal oCompany As SAPbobsCOM.Company, ByVal SQL_Comman2 As SqlCommand)
        Dim ERRO As Integer = 0
        Try

            Dim vCompany As SAPbobsCOM.Company
            vCompany = Class_VariablesGlobales.obj_SAP.ConectarSap()
            If vCompany.Connected = False Then
                'No se conecto
                vCompany = Nothing
            Else
                '------------------------------------------------------------------------
                '----------- FIN CONTROL DE BLOQUEO  DE PEDIDOS DE HOY --------
                '------------------------------------------------------------------------

                'Respalda los pedidos para poder sacar las perdidas por faltantes
                'Obj_Funciones_SQL.RespaldaEncPedido(Tbl_Enc_Pedido, Tbl_Det_Pedido, SQL_Comman2)
                Dim ContEnc As Integer
                Dim ContDet As Integer

                Dim RetVal As Long
                Dim ErrCode As Long
                Dim ErrMsg As String

                'Dim oCompany As SAPbobsCOM.Company
                Dim lRetCode, ErrorCode As Long
                Dim ErrorMessage As String

                'Create the Documents object  CREAREMOS UN DOCUMENTO DE VENTA
                'Crear un pedido de cliente:
                Dim oOrder As SAPbobsCOM.Documents
                oOrder = oCompany.GetBusinessObject(BoObjectTypes.oPurchaseOrders)

                ' '////////////////////////////////////// ENCABEZADO DE LA ORDEN DE VENTA ///////////////////////////////////////////// 

                oOrder.NumAtCard = CInt(Trim(Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString()))
                oOrder.Series = 0
                oOrder.DocType = BoDocumentTypes.dDocument_Items

                'codigo del cliente
                oOrder.CardCode = Tbl_Enc_Pedido.Rows(ContEnc).Item("CardCode").ToString()
                'Si es un pedido hecho por la web sera el consecutivo automatico si es por un agente es manual

                oOrder.HandWritten = BoYesNoEnum.tNO



                'codigo del grupo de pago (credito de 8 ,15 o los dias que tenga)
                ' oOrder.PaymentGroupCode = Tbl_Enc_Pedido.Rows(ContEnc).Item("CondicionPago").ToString()
                'Fecha del creacion del documento
                'oOrder.DocDate = Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString()
                oOrder.DocDueDate = Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString()
                'Monto total del documento
                oOrder.Comments = "Pedido creado desde sincro consecutivo : " & CInt(Trim(Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString()))
                oOrder.SalesPersonCode = Tbl_Enc_Pedido.Rows(ContEnc).Item("SalesPersonCode").ToString()
                ' oOrder.Comments = "Creado por el Agente " & Tbl_Enc_Pedido.Rows(ContEnc).Item("SalesPersonCode").ToString()
                'Se enviara una tabla con el detalle del pedido
                InsertaDetalleOrdenVenta(oOrder, Tbl_Det_Pedido)

                oOrder.Printed = 0

                'Add the Invoice  
                RetVal = oOrder.Add

                'Check the result  
                If RetVal <> 0 Then
                    ERRO = 1
                    oCompany.GetLastError(ErrCode, ErrMsg)
                    'MsgBox(ErrCode & " " & ErrMsg)
                    Dim CodError As String = Mid(ErrMsg, 1, 8)
                    Class_VariablesGlobales.ERRORES = "Error SAP" & ErrMsg



                    'si al agregar el pedido no da error se agrega el estado satisfactorio
                Else
                    'Obj_Funciones_SQL.InsertarEstadoSubidaSAP(ReintentaIngresoPedido, Agente, Archivo, Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString(), "SUBIDO", "SUBIDO CORRECTAMENTE A SAP", Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString(), SQL_Comman2)

                    ERRO = 0
                    'Obj_Funciones_SQL.GuardaOrdenDeCompra(Tbl_Enc_Pedido, Tbl_Det_Pedido, SQL_Comman2)
                    MsgBox("ORDER DE COMPRA CREADA CON EXITO")

                End If



                If vCompany.Connected = False Then
                    DesconectarSap(vCompany)
                End If
            End If
        Catch ex As Exception
            ERRO = 1
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR AddOrderClient [" & ex.Message & "]"
        End Try
        Return ERRO
    End Function

    Public Function InsertaDetalleOrdenVenta(ByVal oOrder As Object, ByVal DetalleOrden As DataTable)
        Try
            Dim vCompany As SAPbobsCOM.Company
            vCompany = Class_VariablesGlobales.obj_SAP.ConectarSap()
            If vCompany.Connected = False Then
                'No se conecto
                vCompany = Nothing
            Else

                Dim cont As Integer
            Dim AgregoDetalle As Boolean = False

            ' recorre toda la tabla que contiene los detalles de todos los pedidos y solo agregara las lineas que contengan el mismo consecutivo del encabezado
            For Each row As DataRow In DetalleOrden.Rows
                If cont > 0 Then
                    'Invoice Lines - Set values to the second line  
                    oOrder.Lines.Add()
                End If

                'Codigo del articulo
                oOrder.Lines.ItemCode = DetalleOrden.Rows(cont).Item("ItemCode").ToString()
                'cantidad 
                oOrder.Lines.Quantity = CInt(DetalleOrden.Rows(cont).Item("Quantity").ToString())
                'moneda
                oOrder.Lines.Currency = "COL"
                'precio luego de impuesto
                ' oOrder.Lines.PriceAfterVAT = 2.36

                'Redondea a 100% los mayores a 90% de descuento
                ' If (CInt(DetalleOrden.Rows(cont).Item("DiscountPercent").ToString()) > 90) Then
                'oOrder.Lines.DiscountPercent = CInt(100)
                'Else
                oOrder.Lines.DiscountPercent = Val(DetalleOrden.Rows(cont).Item("DiscountPercent").ToString())
                'End If


                cont += 1
            Next


                If vCompany.Connected = False Then
                    DesconectarSap(vCompany)
                End If
            End If
        Catch ex As Exception
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] " & "ERROR EN InsertaDetalleOrdenVenta (" & ex.Message & " )"
        End Try

        Return 0
    End Function




#End Region

#Region "Crear Devolucion [NotaCredito ]"
    Public Function AddDevolucion(ByVal Agente As String, ByVal Tbl_Enc_Pedido As DataTable, ByVal Tbl_Det_Pedido As DataTable, ByVal oCompany As SAPbobsCOM.Company, ByVal SQL_Comman2 As SqlCommand)
        Try

            Dim vCompany As SAPbobsCOM.Company
            vCompany = Class_VariablesGlobales.obj_SAP.ConectarSap()
            If vCompany.Connected = False Then
                'No se conecto
                vCompany = Nothing
            Else
                Dim ContEnc As Integer
            Dim ContDet As Integer

            Dim RetVal As Long
            Dim ErrCode As Long
            Dim ErrMsg As String

            'Dim oCompany As SAPbobsCOM.Company
            Dim lRetCode, ErrorCode As Long
            Dim ErrorMessage As String

            'Create the Documents object  CREAREMOS UN DOCUMENTO DE VENTA
            'Crear un pedido de cliente:
            Dim oOrder As SAPbobsCOM.Documents
            oOrder = oCompany.GetBusinessObject(BoObjectTypes.oPurchaseCreditNotes)

            ' '////////////////////////////////////// ENCABEZADO DE LA ORDEN DE VENTA ///////////////////////////////////////////// 

            'oOrder.DocNum = Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString()
            oOrder.Series = 0
            oOrder.DocType = BoDocumentTypes.dDocument_Items

            'codigo del cliente
            oOrder.CardCode = Tbl_Enc_Pedido.Rows(ContEnc).Item("CardCode").ToString()
            'Si es un pedido hecho por la web sera el consecutivo automatico si es por un agente es manual

            oOrder.HandWritten = BoYesNoEnum.tNO



            'codigo del grupo de pago (credito de 8 ,15 o los dias que tenga)
            ' oOrder.PaymentGroupCode = Tbl_Enc_Pedido.Rows(ContEnc).Item("CondicionPago").ToString()
            'Fecha del creacion del documento
            'oOrder.DocDate = Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString()
            oOrder.DocDueDate = Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString()
            'Monto total del documento
            'oOrder.DocTotal = DocTotal
            oOrder.SalesPersonCode = Tbl_Enc_Pedido.Rows(ContEnc).Item("SalesPersonCode").ToString()
            ' oOrder.Comments = "Creado por el Agente " & Tbl_Enc_Pedido.Rows(ContEnc).Item("SalesPersonCode").ToString()
            'Se enviara una tabla con el detalle del pedido
            InsertaDetalleDevolucion(oOrder, Tbl_Det_Pedido)

            oOrder.Printed = 0

            'Add the Invoice  
            RetVal = oOrder.Add

            'Check the result  
            If RetVal <> 0 Then
                oCompany.GetLastError(ErrCode, ErrMsg)
                'MsgBox(ErrCode & " " & ErrMsg)
                Dim CodError As String = Mid(ErrMsg, 1, 8)
                Class_VariablesGlobales.ERRORES = "Error SAP" & ErrMsg
                ''bodega bloqueada para un articulo
                'If CodError = " [OITW.L" Then
                '    LocalizoError = True
                '    ERRORES = "[ " & Now & " ] ERROR Bodega bloqueada [ articulo " & Mid(ErrMsg, 76, 9) & ", Ver Consecutivo = " & Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString() & " ]" & vbCrLf

                '    Obj_Funciones_SQL.InsertarEstadoSubidaSAP(ReintentaIngresoPedido, Agente, Archivo, Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString(), "ERROR", "Bodega bloqueada [ articulo " & Mid(ErrMsg, 76, 9) & ", Ver Consecutivo = " & Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString() & " ]", Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString(), SQL_Comman2)
                'End If
                ''Articulo inactivo
                'If CodError = " [ORDR.G" Then
                '    LocalizoError = True
                '    ERRORES = "[ " & Now & " ] ERROR AddOrderClient [ Condicion de pago de cliente no valida " & Mid(ErrMsg, 17, 9) & ", Ver Consecutivo = " & Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString() & " ]" & vbCrLf

                '    Obj_Funciones_SQL.InsertarEstadoSubidaSAP(ReintentaIngresoPedido, Agente, Archivo, Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString(), "ERROR", "Codigo del Articulo [" & Mid(ErrMsg, 17, 9) & " ] esta INACTIVO EN SAP", Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString(), SQL_Comman2)
                'End If

                ''Articulo inactivo
                'If CodError = "10001069" Then
                '    LocalizoError = True
                '    ERRORES = "[ " & Now & " ] ERROR AddOrderClient [ Codigo del Articulo " & Mid(ErrMsg, 17, 9) & " esta INACTIVO EN SAP, Ver Consecutivo = " & Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString() & " ]" & vbCrLf

                '    Obj_Funciones_SQL.InsertarEstadoSubidaSAP(ReintentaIngresoPedido, Agente, Archivo, Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString(), "ERROR", "Codigo del Articulo [" & Mid(ErrMsg, 17, 9) & " ] esta INACTIVO EN SAP", Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString(), SQL_Comman2)
                'End If

                ''Cliente inactivo
                'If CodError = "10001071" Then
                '    LocalizoError = True
                '    ERRORES = "[ " & Now & " ] ERROR AddOrderClient [ Codigo del Cliente " & Mid(ErrMsg, 21, 9) & " esta INACTIVO EN SAP, Ver Consecutivo = " & Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString() & " ]" & vbCrLf

                '    Obj_Funciones_SQL.InsertarEstadoSubidaSAP(ReintentaIngresoPedido, Agente, Archivo, Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString(), "ERROR", "Codigo del Cliente " & Mid(ErrMsg, 21, 9) & " esta INACTIVO EN SAP", Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString(), SQL_Comman2)

                'End If
                ''DOCUMENTO YA EXITE
                'If CodError = "10001385" Then
                '    LocalizoError = True
                '    ERRORES = "[ " & Now & " ] ERROR AddOrderClient [ Consecutivo de Pedido ya EXISTE EN SAP, Ver Consecutivo = " & Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString() & " ]" & vbCrLf

                '    Obj_Funciones_SQL.InsertarEstadoSubidaSAP(ReintentaIngresoPedido, Agente, Archivo, Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString(), "ERROR", "Consecutivo de Pedido ya EXISTE EN SAP", Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString(), SQL_Comman2)

                'End If

                ''Linea no existe
                'CodError = Mid(ErrMsg, 1, 25)

                'If CodError = "No matching records found" Then
                '    LocalizoError = True
                '    ERRORES = "[ " & Now & " ] ERROR AddOrderClient  Codigo de Articulo [" & Tbl_Det_Pedido.Rows(ContEnc).Item("ItemCode").ToString() & " ] NO EXISTE EN SAP, Ver Consecutivo = " & Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString() & " ]" & vbCrLf

                '    Obj_Funciones_SQL.InsertarEstadoSubidaSAP(ReintentaIngresoPedido, Agente, Archivo, Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString(), "ERROR", "Codigo de Articulo       [ " & Tbl_Det_Pedido.Rows(ContEnc).Item("ItemCode").ToString() & " ] NO EXISTE EN SAP", Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString(), SQL_Comman2)
                'End If


                ''PERIODO BLOQUADO
                'CodError = Mid(ErrMsg, 1, 8)

                'If CodError = "10000156" Then
                '    LocalizoError = True
                '    Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR AddOrderClient [ PERIODO BLOQUEADO DE LA FECHA " & Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString() & " EN SAP, Ver Consecutivo = " & Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString() & " ]" & vbCrLf

                '    Obj_Funciones_SQL.InsertarEstadoSubidaSAP(ReintentaIngresoPedido, Agente, Archivo, Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString(), "ERROR", "PERIODO BLOQUEADO EN SAP , VER LA FECHA " & Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString() & " ", Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString(), SQL_Comman2)
                'End If

                ''PERIODO BLOQUADO
                'CodError = Mid(ErrMsg, 1, 8)

                'If CodError = "Update t" Then
                '    LocalizoError = True
                '    Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR AddOrderClient [ ACTUALIZAR TIPO DE CAMBIO ]" & vbCrLf

                '    Obj_Funciones_SQL.InsertarEstadoSubidaSAP(ReintentaIngresoPedido, Agente, Archivo, Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString(), "ERROR", "ACTUALIZAR TIPO DE CAMBIO DE LA FECHA " & Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString(), Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString(), SQL_Comman2)
                'End If

                ''PERIODO BLOQUADO
                'CodError = Mid(ErrMsg, 1, 8)

                'If CodError = "Period i" Then
                '    LocalizoError = True
                '    Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR AddOrderClient [ PERIODO BLOQUEADO DE LA FECHA " & Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString() & " EN SAP, Ver Consecutivo = " & Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString() & " ]" & vbCrLf

                '    Obj_Funciones_SQL.InsertarEstadoSubidaSAP(ReintentaIngresoPedido, Agente, Archivo, Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString(), "ERROR", "PERIODO BLOQUEADO EN SAP , VER LA FECHA " & Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString() & " ", Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString(), SQL_Comman2)
                'End If



                'If LocalizoError = True Then
                '    'INSERTA PEDIDOS CON ERROR PARA LUEGO PODER INTENTAR SUBIRLOS DENUEVO
                '    'SI SE ESTA REINTENTANDO SE DEBERA SOLO ACTUALIZAR EL TIPO DE ERROR YA QUE SI NO , AGREGARA EL MISMO PEDIDO VARIAS VECES
                '    Obj_Funciones_SQL.InsertarPedidoErroneos(Tbl_Enc_Pedido, Tbl_Det_Pedido, ReintentaIngresoPedido, SQL_Comman2)
                '    LocalizoError = False
                '    'este ELSE agarra cualquier error no controlado por la aplicacion 
                'ElseIf LocalizoError = False Then

                '    Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR AddOrderClient [ ERROR NO CONTROLADO, Ver Consecutivo = " & Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString() & " ] Detalle del error [" & ErrMsg & "]"

                '    Obj_Funciones_SQL.InsertarEstadoSubidaSAP(ReintentaIngresoPedido, Agente, Archivo, Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString(), "ERROR", "NO CONTROLADO [" & ErrMsg & "]", Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString(), SQL_Comman2)

                '    'INSERTA PEDIDOS CON ERROR PARA LUEGO PODER INTENTAR SUBIRLOS DENUEVO
                '    'SI SE ESTA REINTENTANDO SE DEBERA SOLO ACTUALIZAR EL TIPO DE ERROR YA QUE SI NO , AGREGARA EL MISMO PEDIDO VARIAS VECES
                '    Obj_Funciones_SQL.InsertarPedidoErroneos(Tbl_Enc_Pedido, Tbl_Det_Pedido, ReintentaIngresoPedido, SQL_Comman2)
                'End If


                'si al agregar el pedido no da error se agrega el estado satisfactorio
            Else
                'Obj_Funciones_SQL.InsertarEstadoSubidaSAP(ReintentaIngresoPedido, Agente, Archivo, Tbl_Enc_Pedido.Rows(ContEnc).Item("DocNum").ToString(), "SUBIDO", "SUBIDO CORRECTAMENTE A SAP", Tbl_Enc_Pedido.Rows(ContEnc).Item("Date").ToString(), SQL_Comman2)


                'Obj_Funciones_SQL.GuardaOrdenDeCompra(Tbl_Enc_Pedido, Tbl_Det_Pedido, SQL_Comman2)
                MsgBox("ORDER DE COMPRA CREADA CON EXITO")

            End If



                If vCompany.Connected = False Then
                    DesconectarSap(vCompany)
                End If
            End If
        Catch ex As Exception
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR AddOrderClient [" & ex.Message & "]"
        End Try

    End Function

    Public Function InsertaDetalleDevolucion(ByVal oNotaCredito As Object, ByVal DetalleOrden As DataTable)
        Try
            Dim vCompany As SAPbobsCOM.Company
            vCompany = Class_VariablesGlobales.obj_SAP.ConectarSap()
            If vCompany.Connected = False Then
                'No se conecto
                vCompany = Nothing
            Else

                Dim cont As Integer
                Dim AgregoDetalle As Boolean = False

                ' recorre toda la tabla que contiene los detalles de todos los pedidos y solo agregara las lineas que contengan el mismo consecutivo del encabezado
                For Each row As DataRow In DetalleOrden.Rows
                    If cont > 0 Then
                        'Invoice Lines - Set values to the second line  
                        oNotaCredito.Lines.Add()
                    End If

                    oNotaCredito.Lines.ItemCode = DetalleOrden.Rows(cont).Item("ItemCode").ToString()
                    oNotaCredito.Lines.Quantity = CInt(DetalleOrden.Rows(cont).Item("Quantity").ToString())
                    oNotaCredito.Lines.Currency = "COL"
                    oNotaCredito.Lines.Price = Val(DetalleOrden.Rows(cont).Item("Precio").ToString())
                    oNotaCredito.Lines.WarehouseCode = DetalleOrden.Rows(cont).Item("Bodega").ToString()
                    'oNotaCredito.Lines.DiscountPercent = Val(DetalleOrden.Rows(cont).Item("DiscountPercent").ToString())
                    oNotaCredito.Lines.UserFields.Fields.Item("U_DescFijo").Value = Val(DetalleOrden.Rows(cont).Item("U_DescFijo").ToString())

                    'VERIFICAR QUE SE LE ASIGNE EL TEXTO LIBRE
                    oNotaCredito.Lines.FreeText = DetalleOrden.Rows(cont).Item("Motivo").ToString()
                    ''Codigo del articulo
                    'oOrder.Lines.ItemCode = DetalleOrden.Rows(cont).Item("ItemCode").ToString()
                    ''cantidad 
                    'oOrder.Lines.Quantity = CInt(DetalleOrden.Rows(cont).Item("Quantity").ToString())
                    ''moneda
                    'oOrder.Lines.Currency = "COL"
                    ''precio luego de impuesto
                    '' oOrder.Lines.PriceAfterVAT = 2.36

                    ''Redondea a 100% los mayores a 90% de descuento
                    If (CInt(DetalleOrden.Rows(cont).Item("DiscountPercent").ToString()) = 100) Then
                        oNotaCredito.Lines.UserFields.Fields.Item("U_DescProm").Value = CInt(0)
                        oNotaCredito.Lines.DiscountPercent = CInt(0)
                        oNotaCredito.Lines.TaxOnly = BoYesNoEnum.tYES

                    Else
                        oNotaCredito.Lines.UserFields.Fields.Item("U_DescProm").Value = Val(DetalleOrden.Rows(cont).Item("U_DescProm").ToString())
                        oNotaCredito.Lines.DiscountPercent = Val(DetalleOrden.Rows(cont).Item("DiscountPercent").ToString())

                        oNotaCredito.Lines.TaxOnly = BoYesNoEnum.tNO

                    End If


                    cont += 1
                Next

                If vCompany.Connected = False Then
                    DesconectarSap(vCompany)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR EN InsertaDetalleOrdenVenta (" & ex.Message & " )")
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] " & "ERROR EN InsertaDetalleOrdenVenta (" & ex.Message & " )"
        End Try

        Return 0
    End Function
#End Region

#Region "Crea Pago"
    Public vCompany As SAPbobsCOM.Company
    Public Sub ActualizaPago(ByVal NumRecibo As Integer, ByVal CodChofer As String, ByVal NumLiquidacion As String)
        'Le guarda el numero de liquidacion al recibo para vincularlos y evitar que salga nuevamente en futuras liquidaciones
        'On Error GoTo ErrorHandler
        Try
            'create company object
            Dim vCompany As SAPbobsCOM.Company
            vCompany = Class_VariablesGlobales.obj_SAP.ConectarSap()
            If vCompany.Connected = False Then
                'No se conecto
                vCompany = Nothing
            Else

                ''set paras for connection
                'vCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2008
                'vCompany.CompanyDB = Class_VariablesGlobales.XMLParamSAP_CompanyDB
                'vCompany.Password = Class_VariablesGlobales.XMLParamSAP_Password
                'vCompany.UserName = Class_VariablesGlobales.XMLParamSAP_UserName
                'vCompany.Server = Class_VariablesGlobales.XMLParamSAP_Server
                'vCompany.DbUserName = Class_VariablesGlobales.XMLParamSQL_user
                'vCompany.DbPassword = "Bourn3"
                'vCompany.LicenseServer = "SAP:30000"

                ''connect to database server
                'If (0 <> vCompany.Connect()) Then
                '    Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ActualizaPago (No puede conectar a SAP) "
                '    Exit Sub
                'End If

                If vCompany Is Nothing Then

                    MsgBox("ERROR, NO SE PUDO CONTECTA A SAP, ESTA LIQUIDACION PUEDE PRESENTAR FALTA DE INFORMACION POR ESTE ERROR")
                Else


                    Dim nErr As Long
                    Dim errMsg As String
                    'Set the object's properties
                    Dim vPay As SAPbobsCOM.Payments

                    vPay = vCompany.GetBusinessObject(BoObjectTypes.oIncomingPayments)
                    If (vPay.GetByKey(NumRecibo) = True) Then
                        vPay.UserFields.Fields(3).value = CodChofer
                        If NumLiquidacion = "" Then
                            'vPay.UserFields.Fields(5).value = ""
                        Else
                            vPay.UserFields.Fields(5).value = NumLiquidacion
                        End If

                        If (vPay.Update <> 0) Then
                            Dim ErrCode As Long
                            vCompany.GetLastError(ErrCode, errMsg)
                            Dim CodError As String = Mid(errMsg, 1, 8)
                            MsgBox(errMsg)
                            ErrCode = Nothing
                            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR InsertarPago (No puede insertar Pago) "
                        End If
                        If vCompany.Connected = False Then
                            DesconectarSap(vCompany)
                        End If

                        'vCompany = Nothing
                        vPay = Nothing
                        nErr = Nothing
                        errMsg = Nothing
                    End If
                    '        vPay.DocNum = 340

                    '        'vPay.ApplyVAT = 1
                    '        vPay.CardCode = "C502-3142"
                    '        vPay.UserFields.Fields(5).value = 70256
                    '        'vPay.DocCurrency = "COL"
                    '        vPay.DocDate = Now
                    '        'vPay.DocRate = 0
                    '        'vPay.DocTypte = 0
                    '        'vPay.HandWritten = BoYesNoEnum.tYES
                    '        'vPay.JournalRemarks = "Generado El Agente " & vPay.ContactPersonCode
                    '        'vPay.LocalCurrency = BoYesNoEnum.tYES
                    '        'vPay.Reference1 = 3
                    '        vPay.TaxDate = Now
                    '        'vPay.ContactPersonCode = 3
                    '        'vPay.UserFields.Fields(3).value = "3"
                    '        'vPay.Printed = 0
                    '        'vPay.Series = 0
                    '        'vPay.SplitTransaction = 0
                    '        ' '' ------------------ MONTO DE PAGO POR TRANSFERENCIA -----------------

                    '        '' ------------------ MONTO DE PAGO POR EFECTIVO -----------------
                    '        'vPay.CashAccount = "10100101001"
                    '        'vPay.CashSum = 1000.0

                    '        ' '' ------------------ FACTURAS A CANCELAR -----------------
                    '        'vPay.Invoices.AppliedFC = 0
                    '        ''vPay.Invoices.AppliedSys = 2031.2
                    '        'vPay.Invoices.DocEntry = 331996
                    '        'vPay.Invoices.DocLine = 0
                    '        ''vPay.Invoices.DocRate = 0
                    '        'vPay.Invoices.InvoiceType = BoRcptInvTypes.it_Invoice
                    '        ''vPay.Invoices.LineNum = 0
                    '        'vPay.Invoices.SumApplied = 1000.0
                    '        'Call vPay.Invoices.Add()

                    '        ' ------------------ MONTO DE PAGO POR TARJETA DE CREDITO (bourne no usa tarjetas de credito para recibir pagos) -----------------
                    '        'vPay.CreditCards.AdditionalPaymentSum = 0
                    '        'vPay.CreditCards.CardValidUntil = Now
                    '        'vPay.CreditCards.CreditAcct = "10100101001"
                    '        'vPay.CreditCards.CreditCard = 3
                    '        'vPay.CreditCards.CreditCardNumber = "884848448"
                    '        ''vPay.CreditCards.CreditCur = "COL"
                    '        ''vPay.CreditCards.CreditRate = 0
                    '        'vPay.CreditCards.CreditSum = 500.2
                    '        'vPay.CreditCards.CreditType = 1
                    '        'vPay.CreditCards.FirstPaymentDue = Now
                    '        'vPay.CreditCards.FirstPaymentSum = 50.2
                    '        ''vPay.CreditCards.LineNum = 0
                    '        'vPay.CreditCards.NumOfCreditPayments = 1
                    '        'vPay.CreditCards.NumOfPayments = 1
                    '        'vPay.CreditCards.OwnerIdNum = "3993939"
                    '        'vPay.CreditCards.OwnerPhone = "383838888"
                    '        'vPay.CreditCards.PaymentMethodCode = 1
                    '        'Call vPay.CreditCards.Add()
                    '        'INSERTA EL DETALLE DEL PAGO
                    '        'InsertaDetallePagos(vPay, TablaDetPagos, TablaEncPagos.Rows(0).Item("DATE").ToString())


                    '        'check for errors
                    '        Call vCompany.GetLastError(nErr, errMsg)
                    '        If (0 <> nErr) Then

                    '            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR InsertarPago (Found error:" & Str(nErr) & ") "
                    '        Else
                    '            'MsgBox("Succeed in payment.add")
                    '        End If

                    '        'disconnect the company object, and release resource
                    '        Call vCompany.Disconnect()
                    '        vCompany = Nothing
                    '        Exit Sub
                    'ErrorHandler:

                    '        Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR InsertarPago (Exception:" + Err.Description & ") "
                End If

                If vCompany.Connected = False Then
                    DesconectarSap(vCompany)
                End If
            End If
        Catch ex As Exception
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] " & "ERROR EN ActualizaPago (" & ex.Message & " )"
        End Try

    End Sub
#End Region

    Public Function CreaNotaCreditoLigada(ByVal Boleta As String, ByVal Agente As String, ByVal Tbl_Ecabezado As DataTable, ByVal Tbl_Detalle As DataTable, ByVal oCompany As SAPbobsCOM.Company, ByVal SQL_Comman2 As SqlCommand)
        Try
            Class_VariablesGlobales.ERRORES = ""

            Dim vCompany As SAPbobsCOM.Company
            vCompany = Class_VariablesGlobales.obj_SAP.ConectarSap()
            If vCompany.Connected = False Then
                'No se conecto
                vCompany = Nothing
            Else

                Dim RetVal As Long
                Dim ErrCode As Long
                Dim ErrMsg As String
                Dim nErr As Long

                Dim oNotaCredito As SAPbobsCOM.Documents
                oNotaCredito = oCompany.GetBusinessObject(BoObjectTypes.oCreditNotes)

                oNotaCredito.DocType = BoDocumentTypes.dDocument_Items
                oNotaCredito.HandWritten = BoYesNoEnum.tNO


                oNotaCredito.CardCode = Tbl_Ecabezado.Rows(0).Item("CardCode").ToString()
                'cod agente o chofer

                oNotaCredito.Comments = Tbl_Ecabezado.Rows(0).Item("Comentario").ToString()
                oNotaCredito.UserFields.Fields(0).value() = Trim(Tbl_Ecabezado.Rows(0).Item("Ruta").ToString())

                'cod agente o chofer
                oNotaCredito.UserFields.Fields(1).value() = Trim(Agente)
                'cod boleta
                oNotaCredito.UserFields.Fields(2).value() = Trim(Boleta)
                'Motivo
                oNotaCredito.UserFields.Fields(6).value() = Trim(Tbl_Ecabezado.Rows(0).Item("Motivo").ToString())
                'MUY IMPORTANTE PARA FACTURA ELECTRONICA
                oNotaCredito.NumAtCard = Trim(CInt(Tbl_Ecabezado.Rows(0).Item("NumFactura").ToString()))


                '--------------- codigo vincula documento ---------------------
                'oNotaCredito.Lines.BaseEntry = CInt(Tbl_Ecabezado.Rows(0).Item("DocEntry").ToString())
                'oNotaCredito.Lines.BaseType = SAPbobsCOM.BoObjectTypes.oInvoices
                'oNotaCredito.Lines.BaseLine = 0

                '--------------- FIN codigo vincula documento ---------------------

                InsertaDetalleDevolucion(oNotaCredito, Tbl_Detalle)


                RetVal = oNotaCredito.Add()
                'Check the result  
                If RetVal <> 0 Then
                    oCompany.GetLastError(ErrCode, ErrMsg)
                    'MsgBox(ErrCode & " " & ErrMsg)
                    Dim CodError As String = Mid(ErrMsg, 1, 8)
                    Class_VariablesGlobales.ERRORES = "Error SAP" & ErrMsg
                End If

                If vCompany.Connected = False Then
                    DesconectarSap(vCompany)
                End If
            End If

            Return Class_VariablesGlobales.ERRORES
        Catch ex As Exception
            MsgBox("ERROR CreaNotaCreditoLigada, " & ex.Message)
            Return "ERROR CreaNotaCreditoLigada, " & ex.Message
        End Try
    End Function

    Public Function CreaNotaCreditoDesLigada(ByVal DocNum As String, ByVal Agente As String, ByVal Tbl_Ecabezado As DataTable, ByVal Tbl_Detalle As DataTable, ByVal oCompany As SAPbobsCOM.Company, ByVal SQL_Comman2 As SqlCommand)
        Try

            Dim vCompany As SAPbobsCOM.Company
            vCompany = Class_VariablesGlobales.obj_SAP.ConectarSap()
            If vCompany.Connected = False Then
                'No se conecto
                vCompany = Nothing
            Else

                Dim RetVal As Long
                Dim ErrCode As Long
                Dim ErrMsg As String
                Dim nErr As Long

                Dim oNotaCredito As SAPbobsCOM.Documents
                oNotaCredito = oCompany.GetBusinessObject(BoObjectTypes.oCreditNotes)
                oNotaCredito.HandWritten = BoYesNoEnum.tNO
                oNotaCredito.DocType = BoDocumentTypes.dDocument_Items

                oNotaCredito.CardCode = Tbl_Ecabezado.Rows(0).Item("CardCode").ToString()
                'cod agente o chofer
                oNotaCredito.UserFields.Fields(1).value() = Trim(Agente)
                'cod boleta
                oNotaCredito.UserFields.Fields(2).value() = Trim(DocNum)


                InsertaDetalleDevolucion(oNotaCredito, Tbl_Detalle)


                'oNotaCredito.Lines.ItemCode = "038002004"
                'oNotaCredito.Lines.Quantity = CInt(3)
                'oNotaCredito.Lines.Currency = "COL"
                'oNotaCredito.Lines.DiscountPercent = Val(0)

                ' indica codigo de la ruta
                'oNotaCredito.UserFields.Fields(0).value =502

                'Dim osales As SAPbobsCOM.SalesOpportunities
                'osales = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oSalesOpportunities)
                'If osales.GetByKey("70") = True Then 'OpprId
                '    osales.UserFields.Fields.Item("U_postby").Value = "sss"
                '    lretcode = osales.Update()
                '    If lretcode <> 0 Then
                '        oCompany.GetLastError(lerrcode, serrmsg)
                '        MessageBox.Show(serrmsg)
                '    End If
                'End If

                RetVal = oNotaCredito.Add()
                'For Each row As DataRow In DetalleOrden.Rows
                '    If cont > 0 Then
                '        'Invoice Lines - Set values to the second line  
                '        oOrder.Lines.Add()
                '    End If

                '    oOrder.Lines.ItemCode = DetalleOrden.Rows(cont).Item("ItemCode").ToString()
                '    oOrder.Lines.Quantity = CInt(DetalleOrden.Rows(cont).Item("Quantity").ToString())
                '    oOrder.Lines.Currency = "COL"

                '    oOrder.Lines.DiscountPercent = Val(DetalleOrden.Rows(cont).Item("DiscountPercent").ToString())

                '    cont += 1
                'Next



                Class_VariablesGlobales.ERRORES = ""

                'Check the result  
                If RetVal <> 0 Then
                    oCompany.GetLastError(ErrCode, ErrMsg)
                    'MsgBox(ErrCode & " " & ErrMsg)
                    Dim CodError As String = Mid(ErrMsg, 1, 8)
                    Class_VariablesGlobales.ERRORES = "Error SAP" & ErrMsg


                Else
                    Class_VariablesGlobales.Obj_Funciones_SQL.ProcesaDevolucion(DocNum, Class_VariablesGlobales.SQL_Comman1)
                End If



                If vCompany.Connected = False Then
                    DesconectarSap(vCompany)
                End If
            End If
            Return Class_VariablesGlobales.ERRORES

        Catch ex As Exception

        End Try
    End Function


    Public Function CreaNotaCreditoDesLigadaPreliminar(ByVal DocNum As String, ByVal Agente As String, ByVal Tbl_Ecabezado As DataTable, ByVal Tbl_Detalle As DataTable, ByVal SQL_Comman2 As SqlCommand)
        Try

            Dim vCompany As SAPbobsCOM.Company
            vCompany = Class_VariablesGlobales.obj_SAP.ConectarSap()
            If vCompany.Connected = False Then
                'No se conecto
                vCompany = Nothing
            Else

                Dim RetVal As Long
                Dim ErrCode As Long
                Dim ErrMsg As String
                Dim nErr As Long

                Dim oNotaCredito As SAPbobsCOM.Documents
                oNotaCredito = vCompany.GetBusinessObject(BoObjectTypes.oCreditNotes)

                oNotaCredito.DocType = BoDocumentTypes.dDocument_Items

                oNotaCredito.CardCode = Tbl_Ecabezado.Rows(0).Item("CardCode").ToString()
                'cod agente o chofer
                oNotaCredito.UserFields.Fields(1).value() = Trim(Agente)
                'cod boleta
                oNotaCredito.UserFields.Fields(2).value() = Trim(DocNum)


                InsertaDetalleDevolucion(oNotaCredito, Tbl_Detalle)


                'oNotaCredito.Lines.ItemCode = "038002004"
                'oNotaCredito.Lines.Quantity = CInt(3)
                'oNotaCredito.Lines.Currency = "COL"
                'oNotaCredito.Lines.DiscountPercent = Val(0)

                ' indica codigo de la ruta
                'oNotaCredito.UserFields.Fields(0).value =502

                'Dim osales As SAPbobsCOM.SalesOpportunities
                'osales = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oSalesOpportunities)
                'If osales.GetByKey("70") = True Then 'OpprId
                '    osales.UserFields.Fields.Item("U_postby").Value = "sss"
                '    lretcode = osales.Update()
                '    If lretcode <> 0 Then
                '        oCompany.GetLastError(lerrcode, serrmsg)
                '        MessageBox.Show(serrmsg)
                '    End If
                'End If

                RetVal = oNotaCredito.Add()
                'For Each row As DataRow In DetalleOrden.Rows
                '    If cont > 0 Then
                '        'Invoice Lines - Set values to the second line  
                '        oOrder.Lines.Add()
                '    End If

                '    oOrder.Lines.ItemCode = DetalleOrden.Rows(cont).Item("ItemCode").ToString()
                '    oOrder.Lines.Quantity = CInt(DetalleOrden.Rows(cont).Item("Quantity").ToString())
                '    oOrder.Lines.Currency = "COL"

                '    oOrder.Lines.DiscountPercent = Val(DetalleOrden.Rows(cont).Item("DiscountPercent").ToString())

                '    cont += 1
                'Next



                Class_VariablesGlobales.ERRORES = ""

                'Check the result  
                If RetVal <> 0 Then
                    vCompany.GetLastError(ErrCode, ErrMsg)
                    'MsgBox(ErrCode & " " & ErrMsg)
                    Dim CodError As String = Mid(ErrMsg, 1, 8)
                    Class_VariablesGlobales.ERRORES = "Error SAP" & ErrMsg


                Else
                    Class_VariablesGlobales.Obj_Funciones_SQL.ProcesaDevolucion(DocNum, Class_VariablesGlobales.SQL_Comman1)
                End If

                If vCompany.Connected = False Then
                    DesconectarSap(vCompany)
                End If

            End If
            Return Class_VariablesGlobales.ERRORES

        Catch ex As Exception

        End Try
    End Function


#Region "CONECION SAP"
    Public Function ConectarSap()

        Dim oCompany As SAPbobsCOM.Company
        Dim respaldo As Boolean = False

        If VariablesGlobales.oCompany Is Nothing Then
            VariablesGlobales.oCompany = oCompany
            respaldo = False
        Else
            oCompany = VariablesGlobales.oCompany
            respaldo = True
        End If

        Dim lRetCode, ErrorCode As Long
        Dim nResult As Long
        Dim strErrString As String = ""
        Dim Obj_Clas_XML As New Class_XML_Conexion

        Try
            If respaldo = True Then

            Else


                'PARAMETROS DE CONEXION A SAP
                oCompany = New SAPbobsCOM.Company
                oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2019

                If Class_VariablesGlobales.XMLParamSAP_CompanyDB.Trim <> "" Then
                    oCompany.CompanyDB = Class_VariablesGlobales.XMLParamSAP_CompanyDB.Trim
                Else

                End If

                oCompany.Password = Class_VariablesGlobales.XMLParamSAP_Password.Trim
                oCompany.UserName = Class_VariablesGlobales.XMLParamSAP_UserName.Trim
                oCompany.Server = Class_VariablesGlobales.XMLParamSAP_Server.Trim
                oCompany.DbUserName = Class_VariablesGlobales.XMLParamSAP_DbUserName.Trim
                oCompany.DbPassword = Class_VariablesGlobales.XMLParamSAP_DbPassword.Trim
                oCompany.LicenseServer = Class_VariablesGlobales.XMLParamSAP_LicenseServer.Trim
                oCompany.UseTrusted = False

                'CONECTA

                'connect to database server
                If oCompany.Connected = False Then

                    nResult = oCompany.Connect()


                    If nResult <> 0 Then
                        'Display the result
                        ' MsgBox("result is " + Str(nResult))
                        Call oCompany.GetLastError(nResult, strErrString)
                        'MsgBox("GetLastError(" + Str(nResult) + ", " + strErrString + ")")

                        Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ConectarSap Codigo (" & nResult & ")  (" & strErrString & ") "
                        Class_VariablesGlobales.frmPrincipal.DetErrores.Text = "Desconectado de SAP " & Now

                        Dim result1 As DialogResult = MessageBox.Show("ERROR ConectarSap Codigo (" & nResult & ") (" & vbLf &
                        " CompanyDB: " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & vbLf &
                        " SAP_Password: " & Class_VariablesGlobales.XMLParamSAP_Password & vbLf &
                        " SAP_UserName: " & Class_VariablesGlobales.XMLParamSAP_UserName & vbLf &
                        " SAP_Server: " & Class_VariablesGlobales.XMLParamSAP_Server & vbLf &
                        " SAP_DbUserName: " & Class_VariablesGlobales.XMLParamSAP_DbUserName & vbLf &
                        " SAP_DbPassword: " & Class_VariablesGlobales.XMLParamSAP_DbPassword & vbLf &
                        " SAP_LicenseServer: " & Class_VariablesGlobales.XMLParamSAP_LicenseServer & ") " & vbLf & vbLf &
                        "(" & strErrString & ") " & vbLf & vbLf &
                        "Si no se conecta los cambios no se aplicaran en SAP\n Desea volver a intentar conectar con SAP?",
                       "Important Question",
                       MessageBoxButtons.YesNo)

                        If result1 = DialogResult.Yes Then

                            Class_VariablesGlobales.XMLParamSAP_CompanyDB = Nothing
                            Class_VariablesGlobales.XMLParamSAP_Password = Nothing
                            Class_VariablesGlobales.XMLParamSAP_UserName = Nothing
                            Class_VariablesGlobales.XMLParamSAP_Server = Nothing
                            Class_VariablesGlobales.XMLParamSAP_DbUserName = Nothing
                            Class_VariablesGlobales.XMLParamSAP_DbPassword = Nothing
                            Class_VariablesGlobales.XMLParamSAP_LicenseServer = Nothing


                            lRetCode = Nothing
                            ErrorCode = Nothing
                            nResult = Nothing
                            strErrString = Nothing
                            oCompany.Disconnect()
                            oCompany = Nothing
                            Obj_Clas_XML.ConexionSAP()
                            Obj_Clas_XML = Nothing
                            ConectarSap()
                        End If
                        If result1 = DialogResult.No Then
                            oCompany = Nothing
                        End If
                        'Exit Function
                    Else

                        Class_VariablesGlobales.frmPrincipal.DetErrores.Text = "Conectado a SAP " & Class_VariablesGlobales.XMLParamSAP_UserName.Trim & "  " & Now

                        'CONECTO CON EXITO

                    End If

                End If

                VariablesGlobales.oCompany = oCompany
            End If

            Obj_Clas_XML = Nothing
            Return oCompany

        Catch ex As Exception
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ConectarSap (" & ex.Message & ")"
            Class_VariablesGlobales.frmPrincipal.DetErrores.Text = "[ " & Now & " ] ERROR ConectarSap (" & ex.Message & ")" & Class_VariablesGlobales.XMLParamSAP_UserName.Trim & "  " & Now
        End Try
    End Function

    Public Function DesconectarSap(ByVal oCompany As SAPbobsCOM.Company)
        Try
            'disconnect the company object, and release resource

            Call oCompany.Disconnect()
            oCompany = Nothing
            Return 0
        Catch ex As Exception
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR DesconectarSap (" & ex.Message & ")"
        End Try
    End Function
#End Region


#Region "MOVIEMIENTOS DE INVENTARIO"
    'CREAR UNA SOLICITUD DE TRASLADO
    Public Function CreaSolicitudDeTraslado(ByVal TablaEncTranfer As DataTable, ByVal TablaDetTranfer As DataTable, ByVal SQL_Comman2 As SqlCommand)
        Try
            Dim vCompany As SAPbobsCOM.Company
            vCompany = Class_VariablesGlobales.obj_SAP.ConectarSap()
            If vCompany.Connected = False Then
                'No se conecto
                vCompany = Nothing
            Else

                Dim RetVal As Long
                Dim ErrCode As Long
                Dim ErrMsg As String
                Dim cont As Integer = 0

                Dim v_InvTransferRequestEntry As SAPbobsCOM.StockTransfer
                v_InvTransferRequestEntry = vCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryTransferRequest)
                v_InvTransferRequestEntry.Comments = "Creado por: " & TablaEncTranfer.Rows(0).Item("Usuario").ToString() &
                                                  " [ " & TablaEncTranfer.Rows(0).Item("Comentario").ToString() & " ] "

                v_InvTransferRequestEntry.CardCode = "C999-9999"



                For Each row As DataRow In TablaDetTranfer.Rows
                    If cont > 0 Then
                        'Invoice Lines - Set values to the second line  
                        v_InvTransferRequestEntry.Lines.Add()
                    End If
                    v_InvTransferRequestEntry.Lines.ItemCode = TablaDetTranfer.Rows(cont).Item("ItemCode").ToString()
                    v_InvTransferRequestEntry.Lines.WarehouseCode = TablaDetTranfer.Rows(cont).Item("BodDestino").ToString()
                    v_InvTransferRequestEntry.Lines.Quantity = CInt(TablaDetTranfer.Rows(cont).Item("Cantidad").ToString())
                    cont += 1
                Next

                v_InvTransferRequestEntry.FromWarehouse = TablaEncTranfer.Rows(0).Item("BodOrigen").ToString()

                'Add the Invoice  
                RetVal = v_InvTransferRequestEntry.Add

                'Check the result  
                If RetVal <> 0 Then

                    vCompany.GetLastError(ErrCode, ErrMsg)
                    'MsgBox(ErrCode & " " & ErrMsg)
                    Dim CodError As String = Mid(ErrMsg, 1, 8)
                Else
                    'error al insertar
                End If

                If vCompany.Connected = False Then
                    DesconectarSap(vCompany)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Function

    Public Function CreaSalidaDeMercaderia(ByVal TablaLineasSalida As DataTable)
        Try
            Dim vCompany As SAPbobsCOM.Company
            vCompany = Class_VariablesGlobales.obj_SAP.ConectarSap()
            If vCompany.Connected = False Then
                'No se conecto
                vCompany = Nothing
            Else
                Dim RetVal As Long
                Dim ErrCode As Long
                Dim ErrMsg As String
                Dim cont As Integer = 0
                Dim consecutivo As String

                Dim oRceipt As SAPbobsCOM.Documents
                ' oRceipt = vCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenExit)
                oRceipt = vCompany.GetBusinessObject(BoObjectTypes.oDrafts)

                For Each row As DataRow In TablaLineasSalida.Rows
                    If cont > 0 Then
                        'Invoice Lines - Set values to the second line  
                        oRceipt.Lines.Add()
                    End If
                    'AJUSTE POR SALIDA
                    oRceipt.Lines.AccountCode = "50100102002"
                    oRceipt.Lines.ItemCode = TablaLineasSalida.Rows(cont).Item("ItemCode").ToString()
                    oRceipt.Lines.Quantity = CInt(TablaLineasSalida.Rows(cont).Item("Cant_Mover").ToString())
                    oRceipt.Lines.WarehouseCode = TablaLineasSalida.Rows(cont).Item("Bodega").ToString()
                    consecutivo = TablaLineasSalida.Rows(cont).Item("Consecutivo").ToString()
                    'oRceipt.Lines.UnitPrice = 0
                    cont += 1
                Next
                oRceipt.Comments = "Salida creado por ajuste de inventario del reporte de devoluciones [ " & consecutivo & " ] "
                RetVal = oRceipt.Add

                'Check the result  
                If RetVal <> 0 Then
                    oRceipt.GetLastError(ErrCode, ErrMsg)
                    Dim CodError As String = Mid(ErrMsg, 1, 8)



                    MsgBox("ERROR DEVUELTO POR SAP [ " & ErrMsg & " ]", MsgBoxStyle.Critical, "ERROR")

                Else
                    'SALIDA CREADA CON EXITO
                    MsgBox("SALIDA CREADA CON EXITO", MsgBoxStyle.Information, "CREADO CON EXITO")
                End If
                If vCompany.Connected = False Then
                    DesconectarSap(vCompany)
                End If
            End If
        Catch ex As Exception
            MsgBox("OCURRIO UN ERROR AL CREAR LA SALIDA [ " & ex.Message & " ]", MsgBoxStyle.Critical, "ERROR")
        End Try
    End Function

    Public Function CreaEntradaDeMercaderia(ByVal TablaLineasEntrada As DataTable)
        Try
            Dim vCompany As SAPbobsCOM.Company
            vCompany = Class_VariablesGlobales.obj_SAP.ConectarSap()
            If vCompany.Connected = False Then
                'No se conecto
                vCompany = Nothing
            Else
                Dim RetVal As Long
                Dim ErrCode As Long
                Dim ErrMsg As String
                Dim cont As Integer = 0
                Dim consecutivo As String

                Dim oRceipt As SAPbobsCOM.Documents
                oRceipt = vCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenEntry)

                For Each row As DataRow In TablaLineasEntrada.Rows
                    If cont > 0 Then
                        'Invoice Lines - Set values to the second line  
                        oRceipt.Lines.Add()
                    End If
                    ' - AJUSTE POR INGRESOS
                    oRceipt.Lines.AccountCode = "50100102001"
                    oRceipt.Lines.ItemCode = TablaLineasEntrada.Rows(cont).Item("ItemCode").ToString()
                    oRceipt.Lines.Quantity = CInt(TablaLineasEntrada.Rows(cont).Item("Cant_Mover").ToString())
                    oRceipt.Lines.WarehouseCode = TablaLineasEntrada.Rows(cont).Item("Bod_Destino").ToString()
                    consecutivo = TablaLineasEntrada.Rows(cont).Item("Consecutivo").ToString()
                    'oRceipt.Lines.UnitPrice = 0
                    cont += 1
                Next
                oRceipt.Comments = "Entrada creado por ajuste de inventario del reporte de devoluciones [ " & consecutivo & " ] "
                RetVal = oRceipt.Add

                'Check the result  
                If RetVal <> 0 Then

                    vCompany.GetLastError(ErrCode, ErrMsg)
                    'MsgBox(ErrCode & " " & ErrMsg)
                    Dim CodError As String = Mid(ErrMsg, 1, 8)

                    MsgBox("ERROR DEVUELTO POR SAP [ " & ErrMsg & " ]", MsgBoxStyle.Critical, "ERROR")
                Else
                    MsgBox("ENTRADA CREADA CON EXITO", MsgBoxStyle.Information, "CREADO CON EXITO")
                End If

                If vCompany.Connected = False Then
                    DesconectarSap(vCompany)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)

            MsgBox("ERROR", MsgBoxStyle.Information, "OCURRIO UN ERROR AL CREAR LA ENTRADA [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function CreaTrasladoDeMercaderia(ByVal TablaLineasTraslado As DataTable)
        Try
            Dim vCompany As SAPbobsCOM.Company
            vCompany = Class_VariablesGlobales.obj_SAP.ConectarSap()
            If vCompany.Connected = False Then
                'No se conecto
                vCompany = Nothing
            Else
                Dim RetVal As Long
                Dim ErrCode As Long
                Dim ErrMsg As String
                Dim cont As Integer = 0
                Dim consecutivo As String
                Dim v_InvTransferRequestEntry As SAPbobsCOM.StockTransfer
                v_InvTransferRequestEntry = vCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryTransferRequest)
                v_InvTransferRequestEntry.CardCode = "C999-9999"

                For Each row As DataRow In TablaLineasTraslado.Rows
                    If cont > 0 Then
                        'Invoice Lines - Set values to the second line  
                        v_InvTransferRequestEntry.Lines.Add()
                    End If
                    v_InvTransferRequestEntry.Lines.ItemCode = TablaLineasTraslado.Rows(cont).Item("ItemCode").ToString()
                    v_InvTransferRequestEntry.Lines.WarehouseCode = TablaLineasTraslado.Rows(cont).Item("Bod_Destino").ToString().Remove(2)
                    v_InvTransferRequestEntry.Lines.Quantity = CInt(TablaLineasTraslado.Rows(cont).Item("Cant_Mover").ToString())
                    consecutivo = TablaLineasTraslado.Rows(0).Item("Consecutivo").ToString()
                    cont += 1
                Next
                v_InvTransferRequestEntry.Comments = "Traslado creado por ajuste de inventario del reporte de devoluciones [ " & consecutivo & " ]"
                v_InvTransferRequestEntry.FromWarehouse = TablaLineasTraslado.Rows(0).Item("Bodega").ToString()

                'Add the Invoice  
                RetVal = v_InvTransferRequestEntry.Add

                'Check the result  
                If RetVal <> 0 Then
                    vCompany.GetLastError(ErrCode, ErrMsg)
                    'MsgBox(ErrCode & " " & ErrMsg)
                    Dim CodError As String = Mid(ErrMsg, 1, 8)
                    MsgBox("ERROR", MsgBoxStyle.Critical, "ERRO DEVUELTO POR SAP [ " & ErrMsg & " ]")
                Else
                    'error al insertar
                    MsgBox("SOLICITUD DE TRASLADO CREADO CON EXITO", MsgBoxStyle.Information, "CREADO CON EXITO")
                End If

                If vCompany.Connected = False Then
                    DesconectarSap(vCompany)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Function
#End Region

#Region " SOCIO DE NEGOCIO"

    Public Function CreaSocioNegocio(ByVal CardCode As String, ByVal Latitud As String, ByVal Longitud As String, ByVal E_Mail As String, ByVal Phone1 As String, ByVal Phone2 As String, ByVal U_Visita As String, ByVal U_ClaveWeb As String, ByVal Nombre As String, ByVal Cedula As String, ByVal ResponsableTributario As String, ByVal OtrasResenas As String, ByVal NombreComercial As String, ByVal Hora As String, ByVal id As String, ByVal Comb_TipoId As String, ByVal Combo_Provincia As String, ByVal Combo_Canton As String, ByVal Combo_Distrito As String, ByVal Combo_Barrio As String, ByVal DTP_Fecha As String, Frecuencia As String, Agente As String, ByVal SQL_Comman2 As SqlCommand, TipoSocio As Integer)
        Dim retorno As Integer = 0
        Try
            Dim vCompany As SAPbobsCOM.Company
            vCompany = Class_VariablesGlobales.obj_SAP.ConectarSap()
            If vCompany.Connected = False Then
                'No se conecto
                vCompany = Nothing
            Else

                Dim nErr As Long
                Dim errMsg As String

                'Create the BusinessPartners object
                Dim vPay As SAPbobsCOM.BusinessPartners
                vPay = vCompany.GetBusinessObject(BoObjectTypes.oBusinessPartners) 'Calls BusinessPartners object

                'Set values of the BusinessPartners object's mandatory and optional properties
                vPay.CardCode = CardCode 'Mandatory property in the BusinessPartners object
                vPay.CardName = Nombre
                'Segun la opcion de CLIENTE/PROVEEDOR del combobox elegimo el ID en SAP para crear un cliente(0)o un proveedor(1)
                If TipoSocio = 2 Then
                    vPay.CardType = 1 ' 1=PROVEEDOR
                ElseIf TipoSocio = 1 Then
                    vPay.CardType = 0 '0=CIENTE 
                End If

                'Frecuencia
                'vPay.UserFields.Fields(0).value() = Frecuencia

                'Cedula
                vPay.FederalTaxID = Cedula.PadLeft(12, "0")
                'Comb_TipoId
                vPay.UserFields.Fields.Item("U_Tipo_Cedula").Value() = "0" & Comb_TipoId

                'GlblLocNum CAMPO EXLUSIVO DE PRONUTRE 
                '01=CED FISICA
                '02='CDU JURIDICA
                '00=CLIENTE EXTRANGERO
                '03=DIMEX
                '04=NITE
                vPay.GlobalLocationNumber = "0" & Comb_TipoId



                'Dia Visita
                vPay.UserFields.Fields.Item("U_Visita").Value() = U_Visita
                'STATUS
                vPay.UserFields.Fields.Item("U_AGENTE4").Value() = "CL1"
                'DESCUENTO
                vPay.UserFields.Fields.Item("U_Descuento").Value() = "15"
                'Bodega
                vPay.UserFields.Fields.Item("U_bodega").Value() = "1"
                'clave Web
                vPay.UserFields.Fields.Item("U_ClaveWeb").Value() = CardCode.Replace("-", "").Replace("C", "B").Replace("c", "B")


                'Latitud
                vPay.UserFields.Fields.Item("U_Latitud").Value() = Latitud
                'Longitud
                vPay.UserFields.Fields.Item("U_Longitud").Value() = Longitud
                'Se establece el medio de pago 01 = Efectivo por defecto campo exclusivo para pronutre
                vPay.UserFields.Fields.Item("U_NVT_Medio_Pago").Value() = "01"
                'Se establece el Cargar CxC 01 =SI por defecto 
                vPay.UserFields.Fields.Item("U_CargarCxC").Value() = "01"
                vPay.Phone1 = Phone1
                vPay.Phone2 = Phone2
                vPay.SalesPersonCode = Agente
                vPay.Notes = "Cliente Creado " & DateAndTime.Now


                vPay.EmailAddress = E_Mail
                'ResponsableTributario
                vPay.ContactPerson = ResponsableTributario
                'Call vPay.ContactPerson.Add()
                'NombreComercial
                vPay.CardForeignName = NombreComercial


                vPay.Currency = "COL"

                vPay.Addresses.SetCurrentLine(0) 'Establese la linea a la cual se le cargara la informacion
                'indica que la direccion se creara en destinarario de factura
                vPay.Addresses.TypeOfAddress = SAPbobsCOM.BoAddressType.bo_BillTo
                vPay.Addresses.AddressType = BoAddressType.bo_BillTo


                '------------ LOS SIGUIENTES CAMPOS SON SEGUN SAP-----------------
                'Call vPay.Addresses.Add()
                'vPay.Addresses.SetCurentLine(0) 'agrega la linea 0
                ' CAMPOS SAP      ' CAMPOS SELLER
                '1 SANJOSE  ----- '1 SANJOSE
                '2 ALAJUELA ----- '2 ALAJUELA
                '3 HEREDIA  ----- '3 CARTAGO
                '4 CARTAGO  ----- '4 HEREDIA
                '5 PUNTARENAS --- '5 GUANACASTE
                '6 LIMON  ------- '6 PUNTARENAS
                '7 GUANACASTE --- '7 LIMON
                Dim IndexSAPProvincia As Integer
                'esto se hace ya que los codigos de provincia no pegan entre seller y sap
                Select Case Combo_Provincia
                    Case 1
                        IndexSAPProvincia = 1
                    Case 2
                        IndexSAPProvincia = 2
                    Case 3
                        IndexSAPProvincia = 4
                    Case 4
                        IndexSAPProvincia = 3
                    Case 5
                        IndexSAPProvincia = 7
                    Case 6
                        IndexSAPProvincia = 5
                    Case 7
                        IndexSAPProvincia = 6
                End Select
                ' vPay.Address = "1prueba"
                'OtrasResenas
                If OtrasResenas.Length > 50 Then
                    vPay.Addresses.AddressName = OtrasResenas.Substring(0, 50)
                Else
                    vPay.Addresses.AddressName = OtrasResenas
                End If

                vPay.Addresses.Street = OtrasResenas
                'Provincia segun sap
                vPay.Addresses.State = IndexSAPProvincia
                ''canton segun sap
                vPay.Addresses.City = Obj_SQL_CONEXIONSERVER.ObtieneNombreCanton(Combo_Provincia, Combo_Canton).ToString()
                ''Distrito segun sap
                vPay.Addresses.County = Obj_SQL_CONEXIONSERVER.ObtieneNombreDistrito(Combo_Provincia, Combo_Canton, Combo_Distrito).ToString()
                ''Barrio segun sap
                vPay.Addresses.Block = Obj_SQL_CONEXIONSERVER.ObtieneNombreBarrio(Combo_Provincia, Combo_Canton, Combo_Distrito, Combo_Barrio).ToString()


                ''OtrasResenas
                'vPay.Addresses.Street = OtrasResenas
                ''Provincia segun sap
                'vPay.Addresses.State = IndexSAPProvincia
                '''canton segun sap
                'vPay.Addresses.City = Combo_Canton
                '''Distrito segun sap
                'vPay.Addresses.County = Combo_Distrito
                '''Barrio segun sap
                'vPay.Addresses.Block = Combo_Barrio
                vPay.PayTermsGrpCode = (-1)
                'ResponsableTributario
                vPay.ContactPerson = ResponsableTributario




                '----------- INFORMACION DE CONTACTO--------------

                ' vPay.ContactEmployees.SetCurentLine(0) 'agrega la linea 0
                vPay.ContactEmployees.Name = ResponsableTributario
                vPay.ContactEmployees.Address = OtrasResenas
                vPay.ContactEmployees.E_Mail = E_Mail
                vPay.ContactEmployees.Fax = ""
                vPay.ContactEmployees.MobilePhone = Phone1
                vPay.ContactEmployees.Phone1 = Phone2
                Call vPay.ContactEmployees.Add()

                'Call vPay.ContactEmployees.SetCurentLine(1) 'agrega la linea 1
                'vPay.ContactEmployees.Name = "C2"
                'vPay.ContactEmployees.Address = "BJ"
                'vPay.ContactEmployees.E_Mail = "c2@abcd.com"
                'vPay.ContactEmployees.Fax = "84338"
                'vPay.ContactEmployees.MobilePhone = "877388888"
                'vPay.ContactEmployees.Phone1 = "8888300"


                If (0 <> vPay.Add()) Then
                    retorno = 1
                    MsgBox("Failed to add an business partner")
                Else
                    Dim objCode As String
                    MsgBox("Clientes creado correctamente codigo = " + vPay.CardCode)
                    retorno = 0
                    'vPay.SaveXML("c:\temp\BP" + vPay.CardCode + ".xml")
                End If

                'Check Error
                Call vCompany.GetLastError(nErr, errMsg)
                If (0 <> nErr) Then
                    retorno = 1
                    MsgBox("Found error:" + Str(nErr) + "," + errMsg)
                End If
                If vCompany.Connected = False Then
                    DesconectarSap(vCompany)
                End If
            End If
            Return retorno

        Catch ex As Exception
            retorno = 1
            MsgBox("Failed to add an business partne " & ex.Message)
        End Try

    End Function
    Public Function ModificaSocioNegocio(ByVal LineContacto As Integer, ByVal CardCode As String, ByVal Latitud As String, ByVal Longitud As String, ByVal E_Mail As String, ByVal Phone1 As String, ByVal Phone2 As String, ByVal U_Visita As String, ByVal U_ClaveWeb As String, ByVal Nombre As String, ByVal Cedula As String, ByVal ResponsableTributario As String, ByVal OtrasResenas As String, ByVal NombreComercial As String, ByVal Hora As String, ByVal id As String, ByVal Comb_TipoId As String, ByVal Combo_Provincia As String, ByVal Combo_Canton As String, ByVal Combo_Distrito As String, ByVal Combo_Barrio As String, ByVal DTP_Fecha As String, ByVal SQL_Comman2 As SqlCommand)
        Dim retorno As Integer = 0
        Try
            Dim vCompany As SAPbobsCOM.Company
            vCompany = Class_VariablesGlobales.obj_SAP.ConectarSap()
            If vCompany.Connected = False Then
                'No se conecto
                vCompany = Nothing
            Else


                Dim vPay As SAPbobsCOM.BusinessPartners
                Dim RetVal As Long
                Dim ErrCode As Long
                Dim ErrMsg As String
                Dim nErr As Long

                vPay = vCompany.GetBusinessObject(BoObjectTypes.oBusinessPartners)


                If vPay.GetByKey(CardCode) Then
                    'Assign only the properties you want to change  

                    'Hora
                    'id
                    'DTP_Fecha

                    'Frecuencia
                    'vPay.UserFields.Fields(0).value() = "01"
                    'Dia Visita
                    vPay.UserFields.Fields.Item("U_Visita").Value() = U_Visita

                    'clave Web
                    vPay.UserFields.Fields.Item("U_ClaveWeb").Value() = U_ClaveWeb
                    'Latitud
                    vPay.UserFields.Fields.Item("U_Latitud").Value() = Latitud
                    'Longitud
                    vPay.UserFields.Fields.Item("U_Longitud").Value() = Longitud
                    vPay.Phone1 = Phone1
                    vPay.Phone2 = Phone2
                    vPay.EmailAddress = E_Mail


                    'Nombre
                    vPay.CardName = Nombre

                    vPay.ContactEmployees.SetCurrentLine(LineContacto)
                    vPay.ContactEmployees.Name = ResponsableTributario
                    'ResponsableTributario

                    'vPay.ContactPerson = ResponsableTributario

                    'NombreComercial
                    vPay.CardForeignName = NombreComercial
                    ''Combo_Provincia
                    'vPay.UserFields.Fields(14).value() = Combo_Provincia
                    ''Combo_Canton
                    'vPay.UserFields.Fields(15).value() = Combo_Canton
                    ''Combo_Distrito
                    'vPay.UserFields.Fields(16).value() = Combo_Distrito
                    ''Combo_Barrio
                    'vPay.UserFields.Fields(17).value() = Combo_Barrio
                    'Comb_TipoId
                    vPay.UserFields.Fields.Item("U_Tipo_Cedula").Value() = "0" & Comb_TipoId
                    'GlblLocNum CAMPO EXLUSIVO DE PRONUTRE 
                    '01=CED FISICA
                    '02='CDU JURIDICA
                    '00=CLIENTE EXTRANGERO
                    '03=DIMEX
                    '04=NITE
                    vPay.GlobalLocationNumber = "0" & Comb_TipoId


                    '------------ LOS SIGUIENTES CAMPOS SON SEGUN SAP-----------------
                    vPay.Addresses.SetCurrentLine(0) 'Establese la linea a la cual se le cargara la informacion
                    vPay.Addresses.TypeOfAddress = SAPbobsCOM.BoAddressType.bo_BillTo
                    vPay.Addresses.AddressType = BoAddressType.bo_BillTo

                    ' CAMPOS SAP      ' CAMPOS SELLER
                    '1 SANJOSE  ----- '1 SANJOSE
                    '2 ALAJUELA ----- '2 ALAJUELA
                    '3 HEREDIA  ----- '3 CARTAGO
                    '4 CARTAGO  ----- '4 HEREDIA
                    '5 PUNTARENAS --- '5 GUANACASTE
                    '6 LIMON  ------- '6 PUNTARENAS
                    '7 GUANACASTE --- '7 LIMON
                    Dim IndexSAPProvincia As Integer


                    'esto se hace ya que los codigos de provincia no pegan entre seller y sap
                    Select Case Combo_Provincia
                        Case 1
                            IndexSAPProvincia = 1
                        Case 2
                            IndexSAPProvincia = 2
                        Case 3
                            IndexSAPProvincia = 4
                        Case 4
                            IndexSAPProvincia = 3
                        Case 5
                            IndexSAPProvincia = 7
                        Case 6
                            IndexSAPProvincia = 5
                        Case 7
                            IndexSAPProvincia = 6
                    End Select

                    'OtrasResenas
                    vPay.Addresses.Street = OtrasResenas
                    'Provincia segun sap
                    vPay.Addresses.State = IndexSAPProvincia

                    vPay.Addresses.City = Obj_SQL_CONEXIONSERVER.ObtieneNombreCanton(Combo_Provincia, Combo_Canton).ToString()
                    ''Distrito segun sap
                    vPay.Addresses.County = Obj_SQL_CONEXIONSERVER.ObtieneNombreDistrito(Combo_Provincia, Combo_Canton, Combo_Distrito).ToString()
                    ''Barrio segun sap
                    vPay.Addresses.Block = Obj_SQL_CONEXIONSERVER.ObtieneNombreBarrio(Combo_Provincia, Combo_Canton, Combo_Distrito, Combo_Barrio).ToString()

                    '''canton segun sap
                    'vPay.Addresses.City = Combo_Canton
                    '''Distrito segun sap
                    'vPay.Addresses.County = Combo_Distrito
                    '''Barrio segun sap
                    'vPay.Addresses.Block = Combo_Barrio

                    'Cedula
                    vPay.FederalTaxID = Cedula.PadLeft(12, "0")
                    'Attempt to update the business partner  
                    RetVal = vPay.Update
                    If RetVal <> 0 Then
                        'The update failed  
                        Dim errI As Integer = 0
                        Dim errS As String = String.Empty
                        'Check why the update failed  
                        vCompany.GetLastError(errI, errS)
                        retorno = 1
                        MsgBox("Update failed because: " & errI.ToString & " " & errS)
                    Else
                        'Success, perform any follow-up tasks here
                        MsgBox("Datos actualizados con exito")
                    End If
                Else
                    retorno = 1
                    MsgBox("Update failed because: ")
                End If
                If vCompany.Connected = False Then
                    DesconectarSap(vCompany)
                End If
            End If
            Return retorno
        Catch ex As Exception
            MsgBox("Update failed because: " & ex.Message)
            Return 1
        End Try


    End Function
    Public Function CerrarSocioNegocio(ByVal CardCode As String, ByVal SQL_Comman2 As SqlCommand)
        Dim retorno As Integer = 0
        Try
            Dim vCompany As SAPbobsCOM.Company
            vCompany = Class_VariablesGlobales.obj_SAP.ConectarSap()
            If vCompany.Connected = False Then
                'No se conecto
                vCompany = Nothing
            Else

                Dim vPay As SAPbobsCOM.BusinessPartners
                Dim RetVal As Long
                Dim ErrCode As Long
                Dim ErrMsg As String
                Dim nErr As Long

                vPay = vCompany.GetBusinessObject(BoObjectTypes.oBusinessPartners)


                If vPay.GetByKey(CardCode) Then
                    'Assign only the properties you want to change  

                    'Hora
                    'id
                    'DTP_Fecha

                    'Frecuencia
                    'vPay.UserFields.Fields(0).value() = "01"
                    'Dia Visita
                    vPay.UserFields.Fields.Item("U_AGENTE1").Value() = "0"
                    vPay.UserFields.Fields.Item("U_AGENTE2").Value() = "0"
                    vPay.UserFields.Fields.Item("U_AGENTE3").Value() = "0"
                    vPay.UserFields.Fields.Item("U_AGENTE4").Value() = "CL2"

                    vPay.SalesPersonCode = 9

                    vPay.FrozenFrom = Date.Now
                    vPay.FrozenTo = Date.Now

                    vPay.Valid = SAPbobsCOM.BoYesNoEnum.tNO
                    vPay.Frozen = SAPbobsCOM.BoYesNoEnum.tYES  ' This line must be put (It's the opposite value  a obp.valid)


                    vPay.ValidFrom = Date.Now
                    vPay.ValidTo = Date.Now

                    vPay.Notes = "Cliente Cerrado [" & Date.Now & "]"
                    'Attempt to update the business partner  
                    RetVal = vPay.Update
                    If RetVal <> 0 Then
                        'The update failed  
                        Dim errI As Integer = 0
                        Dim errS As String = String.Empty
                        'Check why the update failed  
                        vCompany.GetLastError(errI, errS)
                        retorno = 1

                        MsgBox("Update failed because: " & errI.ToString & " " & errS)
                    Else
                        'Success, perform any follow-up tasks here
                        MsgBox("Cliente cerrado con exito")
                    End If
                Else
                    retorno = 1
                    MsgBox("Update failed because ")
                End If
                If vCompany.Connected = False Then
                    DesconectarSap(vCompany)
                End If
            End If
            Return retorno
        Catch ex As Exception

            MsgBox("Update failed because: " & ex.Message)
            Return 1
        End Try


    End Function
    Public Function NuevoSocioNegocio(ByVal LineContacto As Integer, ByVal CardCode As String, ByVal Latitud As String, ByVal Longitud As String, ByVal E_Mail As String, ByVal Phone1 As String, ByVal Phone2 As String, ByVal U_Visita As String, ByVal U_ClaveWeb As String, ByVal Nombre As String, ByVal Cedula As String, ByVal ResponsableTributario As String, ByVal OtrasResenas As String, ByVal NombreComercial As String, ByVal Hora As String, ByVal id As String, ByVal Comb_TipoId As String, ByVal Combo_Provincia As String, ByVal Combo_Canton As String, ByVal Combo_Distrito As String, ByVal Combo_Barrio As String, ByVal DTP_Fecha As String, ByVal SQL_Comman2 As SqlCommand)
        Dim retorno As Integer = 0
        Try

            Dim vCompany As SAPbobsCOM.Company
            vCompany = Class_VariablesGlobales.obj_SAP.ConectarSap()
            If vCompany.Connected = False Then
                'No se conecto
                vCompany = Nothing
            Else

                Dim vPay As SAPbobsCOM.BusinessPartners
                Dim RetVal As Long
                Dim ErrCode As Long
                Dim ErrMsg As String
                Dim nErr As Long

                vPay = vCompany.GetBusinessObject(BoObjectTypes.oBusinessPartners)

                vPay.CardCode = CardCode
                vPay.CardName = CardCode
                vPay.CardForeignName = CardCode
                vPay.CardType = "C"



                'U Vista
                vPay.UserFields.Fields.Item("U_Visita").Value() = U_Visita
                'Agente 1
                vPay.UserFields.Fields.Item("U_AGENTE1").Value() = "0"
                'Agente 2
                vPay.UserFields.Fields.Item("U_AGENTE2").Value() = "0"
                'Agente 3
                vPay.UserFields.Fields.Item("U_AGENTE3").Value() = "0"
                'Estado
                vPay.UserFields.Fields.Item("U_AGENTE4").Value() = "CL2"
                'clave Web
                vPay.UserFields.Fields.Item("U_ClaveWeb").Value() = U_ClaveWeb
                'Latitud
                vPay.UserFields.Fields.Item("U_Latitud").Value() = Latitud
                'Longitud
                vPay.UserFields.Fields.Item("U_Longitud").Value() = Longitud


                vPay.Phone1 = Phone1
                vPay.Phone2 = Phone2
                vPay.EmailAddress = E_Mail

                'Informacion de persona de contacto - rsponsable tributario
                vPay.ContactEmployees.Name = ResponsableTributario
                'ResponsableTributario

                'vPay.ContactPerson = ResponsableTributario

                'NombreComercial
                vPay.CardForeignName = NombreComercial
                ''Combo_Provincia
                'vPay.UserFields.Fields(14).value() = Combo_Provincia
                ''Combo_Canton
                'vPay.UserFields.Fields(15).value() = Combo_Canton
                ''Combo_Distrito
                'vPay.UserFields.Fields(16).value() = Combo_Distrito
                ''Combo_Barrio
                'vPay.UserFields.Fields(17).value() = Combo_Barrio
                'Comb_TipoId
                vPay.UserFields.Fields.Item("U_Tipo_Cedula").Value() = "0" & Comb_TipoId
                'Se establece el medio de pago 01 = Efectivo por defecto campo exclusivo para pronutre
                vPay.UserFields.Fields.Item("U_NVT_Medio_Pago").Value() = "01"
                'GlblLocNum CAMPO EXLUSIVO DE PRONUTRE 
                '01=CED FISICA
                '02='CDU JURIDICA
                '00=CLIENTE EXTRANGERO
                '03=DIMEX
                '04=NITE
                vPay.GlobalLocationNumber = "0" & Comb_TipoId
                '------------ LOS SIGUIENTES CAMPOS SON SEGUN SAP-----------------
                vPay.Addresses.SetCurrentLine(0) 'Establese la linea a la cual se le cargara la informacion
                vPay.Addresses.TypeOfAddress = SAPbobsCOM.BoAddressType.bo_BillTo
                vPay.Addresses.AddressType = BoAddressType.bo_BillTo
                ' CAMPOS SAP      ' CAMPOS SELLER
                '1 SANJOSE  ----- '1 SANJOSE
                '2 ALAJUELA ----- '2 ALAJUELA
                '3 HEREDIA  ----- '3 CARTAGO
                '4 CARTAGO  ----- '4 HEREDIA
                '5 PUNTARENAS --- '5 GUANACASTE
                '6 LIMON  ------- '6 PUNTARENAS
                '7 GUANACASTE --- '7 LIMON
                Dim IndexSAPProvincia As Integer


                'esto se hace ya que los codigos de provincia no pegan entre seller y sap
                Select Case Combo_Provincia
                    Case 1
                        IndexSAPProvincia = 1
                    Case 2
                        IndexSAPProvincia = 2
                    Case 3
                        IndexSAPProvincia = 4
                    Case 4
                        IndexSAPProvincia = 3
                    Case 5
                        IndexSAPProvincia = 7
                    Case 6
                        IndexSAPProvincia = 5
                    Case 7
                        IndexSAPProvincia = 6
                End Select
                'OtrasResenas
                vPay.Addresses.Street = OtrasResenas
                'Provincia segun sap
                vPay.Addresses.State = IndexSAPProvincia

                vPay.Addresses.City = Obj_SQL_CONEXIONSERVER.ObtieneNombreCanton(Combo_Provincia, Combo_Canton).ToString()
                ''Distrito segun sap
                vPay.Addresses.County = Obj_SQL_CONEXIONSERVER.ObtieneNombreDistrito(Combo_Provincia, Combo_Canton, Combo_Distrito).ToString()
                ''Barrio segun sap
                vPay.Addresses.Block = Obj_SQL_CONEXIONSERVER.ObtieneNombreBarrio(Combo_Provincia, Combo_Canton, Combo_Distrito, Combo_Barrio).ToString()

                ''canton segun sap
                'vPay.Addresses.City = Combo_Canton
                '''Distrito segun sap
                'vPay.Addresses.County = Combo_Distrito
                '''Barrio segun sap
                'vPay.Addresses.Block = Combo_Barrio

                'Cedula
                vPay.FederalTaxID = Cedula.PadLeft(12, "0")
                'Attempt to update the business partner  
                RetVal = vPay.Add
                If RetVal <> 0 Then
                    'The update failed  
                    Dim errI As Integer = 0
                    Dim errS As String = String.Empty
                    'Check why the update failed  
                    vCompany.GetLastError(errI, errS)
                    retorno = 1
                    MsgBox("Creacion failed because: " & errI.ToString & " " & errS)
                Else
                    'Success, perform any follow-up tasks here
                    MsgBox("Datos Creados con exito")
                End If

                If vCompany.Connected = False Then
                    DesconectarSap(vCompany)
                End If
            End If
            Return retorno
        Catch ex As Exception

            MsgBox("Creacion failed because: " & ex.Message)
            Return 1
        End Try


    End Function


#End Region

#Region "Crea Articulo en Datos Maestros de articulos"
    Public Function CreaArticulo(ByVal ItemCode As String, ByVal ItemName As String, ByVal CardCode As String, ByVal PurPackUn As String, ByVal CodeBars As String, ByVal Familia As String, ByVal Categoria As String, ByVal Marca As String, ByVal NombreExtrangero As String, ByVal IDGroupArticulo As String, ByVal Sector As String, ByVal CodigoDelFabricante As String, ByVal UnidadMedida As String, Impuesto As String, SujetoAImpuesto As String)
        Dim retorno As Integer = 0
        Try
            Dim vCompany As SAPbobsCOM.Company
            vCompany = Class_VariablesGlobales.obj_SAP.ConectarSap()
            If vCompany.Connected = False Then
                'No se conecto
                vCompany = Nothing
            Else

                Dim nErr As Long
                Dim errMsg As String

                'Create the BusinessPartners object
                Dim Item As SAPbobsCOM.Items

                Item = vCompany.GetBusinessObject(BoObjectTypes.oItems) 'Calls BusinessPartners object

                'Set values of the BusinessPartners object's mandatory and optional properties
                'Item.Series =41'Manual

                Item.ItemCode = ItemCode 'Mandatory property in the BusinessPartners object
                Item.ItemName = ItemName
                Item.ForeignName = NombreExtrangero
                Item.InventoryItem = BoYesNoEnum.tYES 'Indica que es un articulo de inventario
                Item.SalesItem = BoYesNoEnum.tYES 'Indica que es un articulo de venta
                Item.PurchaseItem = BoYesNoEnum.tYES 'Indica que tambien es un articulo de compra

                Item.Mainsupplier = CardCode



                Item.PurchaseItemsPerUnit = PurPackUn
                Item.PurchaseQtyPerPackUnit = PurPackUn
                Item.PurchaseUnit = UnidadMedida

                Item.SupplierCatalogNo = CodigoDelFabricante 'Alterno
                Item.BarCode = CodeBars
                Item.VatLiable = SujetoAImpuesto
                'Item.PriceList.SetCurrentLine(13) ' "COSTO"
                Item.ItemsGroupCode = IDGroupArticulo ' Codigo de grupo de articulo


                'Frecuencia puede usarse con texto U_NombreCampo     Item.UserFields.Fields('U_NombreCampo').value() = Frecuencia
                Item.UserFields.Fields.Item("U_Ubicacion").Value = Trim(Sector)
                Item.UserFields.Fields.Item("U_Impuesto").Value = Trim(Impuesto) ' IVA0,IVA1,IVAT0,IVAT4
                Item.UserFields.Fields.Item("U_Familia").Value = Trim(Familia)
                Item.UserFields.Fields.Item("U_Categoria").Value = Trim(Categoria)
                Item.UserFields.Fields.Item("U_Marca").Value = Trim(Marca)




                If (0 <> Item.Add()) Then
                    retorno = 1
                    MsgBox("Error al agregar el articulo")
                Else
                    Dim objCode As String
                    MsgBox("Articulo creado correctamente codigo = " + Item.ItemCode)
                    retorno = 0
                    'vPay.SaveXML("c:\temp\BP" + vPay.CardCode + ".xml")
                End If

                'Check Error
                Call vCompany.GetLastError(nErr, errMsg)
                If (0 <> nErr) Then
                    retorno = 1
                    MsgBox("Found error:" + Str(nErr) + "," + errMsg)
                End If
                If vCompany.Connected = False Then
                    DesconectarSap(vCompany)
                End If
            End If
            Return retorno

        Catch ex As Exception
            retorno = 1
            MsgBox("Failed to add an business partne " & ex.Message)
        End Try

    End Function

#End Region

End Class
