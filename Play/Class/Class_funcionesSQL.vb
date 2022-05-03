Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class Class_funcionesSQL
    Public Obj_SQL_CONEXION_CONEXION As New CONEXION_TO_SQLSERVER
    Public CNX_1 As New SqlConnection
    Public SQL_Comman1 As New SqlCommand
    Public Function Conectar()
        Try
            If SQL_Comman1.Connection.State = ConnectionState.Closed Then
                CNX_1 = Obj_SQL_CONEXION_CONEXION.Conectar("", CNX_1)
                SQL_Comman1.Connection = CNX_1
            End If
        Catch ex As Exception
            CNX_1 = Obj_SQL_CONEXION_CONEXION.Conectar("", CNX_1)
            SQL_Comman1.Connection = CNX_1
        End Try
        Return SQL_Comman1
    End Function
    Public Function Desconectar(SqlCommand0 As SqlCommand, CNX As SqlConnection)
        Obj_SQL_CONEXION_CONEXION.Desconectar(SqlCommand0, CNX_1)
    End Function


#Region "Factura Electronica"
    'Public Function Guarda_MensajeHacienda(clave As String, ind_estado As String, fecha As String, Mensaje As String)
    Public Function Guarda_MensajeHacienda(clave As String, ind_estado As String, FechaComprobante As String, Mensaje As String, HoraComprobante As String, CodSeguridad As String, CodigoEstado As String, FechaEstado As String, HoraEstado As String, Tipo As String)
        Try
            Dim SQL_Comman As SqlCommand
            SQL_Comman = Conectar()
            Dim msj As String = Mensaje.Replace("'", "")
            Dim Consulta As String
            '       Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Comprobantes_Estado]
            '      ([clave]
            '      ,[ind_estado]
            '      ,[fecha]
            '      ,[Mensaje])
            'VALUES
            '      ('" & clave & "'
            '      ,'" & ind_estado & "'
            '      ,'" & fecha & "'
            '      ,'" & msj.Replace("""", "-") & "')"

            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Comprobantes_Estado]
           ([clave]
            ,[FechaComprobante]
            ,[HoraComprobante] 
            ,[CodSeguridad]
            ,[CodigoEstado]
           ,[ind_estado]
           ,[FechaEstado]
           ,[HoraEstado]
           ,[Mensaje]   
            ,[Tipo]
           )
     VALUES
           ('" & clave & "'
            ,'" & FechaComprobante & "'
            ,'" & HoraComprobante & "'   
            ,'" & CodSeguridad & "'  
            ,'" & CodigoEstado & "'
            ,'" & ind_estado & "'
            ,'" & FechaEstado & "'
            ,'" & HoraEstado & "'
            ,'" & msj.Replace("""", "-") & "'
            ,'" & Tipo & "')"


            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR en Guarda_MensajeHacienda [ " & ex.Message & " ]")
        End Try


    End Function

    Public Function Guarda_Comprobantes_MR(Clave As String, Consecutivo As String, ConsecutivoMR As String, Fecha_Emisor_Comprobante As String, Tipo_Comprobante As String, TipoCed_Emisor As String, Ced_Emisor As String, Nombre_Emisor As String, Correo_Emisor As String, TipoComprobante As String, Estado_Interno As String, TipoCed_Receptor As String, Nombre_Receptor As String, Correo_Receptor As String, Monto_Impuesto As String, Total_Impuesto As String, Estado_Hacienda As String, Fecha_Estado As String, Mensaje_Hacienda As String, Ced_Receptor As String, CodigoActividadEmisor As String, CondicionImpuestoEmisor As String, MontoTotalImpuestoAcreditarEmisor As String, MontoTotalDeGastoAplicableEmisor As String)
        Try
            Dim SQL_Comman As SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String






            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Comprobantes_MR]
           ([Clave]
           ,[Consecutivo]
           ,[ConsecutivoMR]
           ,[Fecha_Emisor_Comprobante]
           ,[Tipo_Comprobante]
           ,[TipoCed_Emisor]
           ,[Ced_Emisor]
           ,[Nombre_Emisor]
           ,[Correo_Emisor]
           ,[TipoComprobante]
           ,[Estado_Interno]
           ,[TipoCed_Receptor]
           ,[Nombre_Receptor]
           ,[Correo_Receptor]
           ,[Monto_Impuesto]
           ,[Total_Impuesto]
           ,[Estado_Hacienda]
           ,[Fecha_Estado]
           ,[Mensaje_Hacienda]  
           ,[Ced_Receptor]
           ,[CodigoActividadEmisor]
           ,[CondicionImpuestoEmisor]
           ,[MontoTotalImpuestoAcreditarEmisor]
           ,[MontoTotalDeGastoAplicableEmisor]
)
     VALUES
           ('" & Clave & "'
          ,'" & Consecutivo & "'
          ,'" & ConsecutivoMR & "'
          ,'" & Fecha_Emisor_Comprobante & "'
          ,'" & Tipo_Comprobante & "'
          ,'" & TipoCed_Emisor & "'
          ,'" & Ced_Emisor & "'
          ,'" & Nombre_Emisor & "'
          ,'" & Correo_Emisor & "'
          ,'" & TipoComprobante & "'
          ,'" & Estado_Interno & "'
          ,'" & TipoCed_Receptor & "'
          ,'" & Nombre_Receptor & "'
          ,'" & Correo_Receptor & "'
          ,'" & Monto_Impuesto & "'
          ,'" & Total_Impuesto & "'
          ,'" & Estado_Hacienda & "'
          ,'" & Fecha_Estado & "'
          ,'" & Mensaje_Hacienda.Replace("""", "-").Replace(",", ".").Replace("'", "*") & "'
          ,'" & Ced_Receptor & "'
          ,'" & CodigoActividadEmisor & "'
          ,'" & CondicionImpuestoEmisor & "'
          ,'" & MontoTotalImpuestoAcreditarEmisor & "'
          ,'" & MontoTotalDeGastoAplicableEmisor & "')"


            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception
            VariablesGlobales.Obj_Log.Log("ERROR en Guarda_Comprobantes_MR ( " & ex.Message & " )", "MR")
            MessageBox.Show("ERROR en Guarda_Comprobantes_MR [ " & ex.Message & " ]")
        End Try


    End Function


    Public Function ObtieneFechaComprobante(Clave As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Consulta = "Select TOP 1 [FechaComprobanteRecibido] From [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobanteProveedor] WHERE Clave='" & Clave & "'"




            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            'Desconectar(SQL_Comman, SQL_Comman.Connection)

            Return Trim(TABLA.Rows(0).Item("FechaComprobanteRecibido").ToString())
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneFechaComprobante [ " & ex.Message & " ]")
            Return False
        End Try
    End Function
    Public Function ObtieneHoraComprobante(Clave As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Consulta = "Select TOP 1 [HoraComprobanteRecibido] From [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobanteProveedor] WHERE Clave='" & Clave & "'"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            'Desconectar(SQL_Comman, SQL_Comman.Connection)

            Return Trim(TABLA.Rows(0).Item("HoraComprobanteRecibido").ToString())
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneHoraComprobante [ " & ex.Message & " ]")
            Return False
        End Try
    End Function
    Public Function EsServicio(DocNum As String, Tipo As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Retorna As Boolean = False

            If Tipo = "FE" Or Tipo = "TE" Then
                Consulta = "SELECT CASE WHEN T0.[DocNum] IS NULL THEN 0 ELSE T0.[DocNum] END  AS Existe FROM [BD_Bourne].[dbo].[OINV] T0 WHERE T0.[DocType] = 'S' and T0.[DocNum]='" & DocNum & "'"
            End If
            If Tipo = "ND" Then
                Consulta = "SELECT CASE WHEN T0.[DocNum] IS NULL THEN 0 ELSE T0.[DocNum] END AS Existe FROM [BD_Bourne].[dbo].[OINV] T0 WHERE T0.[DocType] = 'S' AND T0.[DocSubType]='DN' and T0.[DocNum]='" & DocNum & "'"
            End If
            If Tipo = "NC" Then
                Consulta = "SELECT CASE WHEN T0.[DocNum] IS NULL THEN 0 ELSE T0.[DocNum] END AS Existe FROM [BD_Bourne].[dbo].[ORIN] T0 WHERE T0.[DocType] = 'S' and T0.[DocNum]='" & DocNum & "'"
            End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
                ADATER.Fill(TABLA)
            If Trim(TABLA.Rows(0).Item("Existe").ToString()) <> "" Then
                Retorna = True
            Else

                Retorna = False
            End If

            Return Retorna
        Catch ex As Exception
            'MessageBox.Show("ERROR en ObtieneHoraComprobante [ " & ex.Message & " ]")
            Return False
        End Try
    End Function
    Public Function ObtieneConsecutivoMR(Mensaje As String)

        Try
            Dim SQL_Comman As SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim MR As String = ""

            If Mensaje = "1" Then
                Consulta = "Select [MR_Aceptado] From [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos_Consecutivos]"
                MR = "MR_Aceptado"
            ElseIf Mensaje = "2" Then
                Consulta = "Select [MR_Aceptado_Parcial] From [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos_Consecutivos]"
                MR = "MR_Aceptado_Parcial"
            ElseIf Mensaje = "3" Then
                Consulta = "Select [MR_Rechazado] From [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos_Consecutivos]"
                MR = "MR_Rechazado"

            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            MR = Trim(TABLA.Rows(0).Item(MR).ToString())
            TABLA = Nothing

            Return MR
        Catch ex As Exception
            Return "0"
            MessageBox.Show("ERROR en ObtieneConsecutivoMR [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ActualizaConsecutivoMR(Mensaje As String)
        Try
            Dim SQL_Comman As SqlCommand
            SQL_Comman = Conectar()
            Dim Consulta As String
            If Mensaje = "1" Then
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos_Consecutivos]  SET [MR_Aceptado] = (Select [MR_Aceptado] From [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos_Consecutivos])+1"
            ElseIf Mensaje = "2" Then
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos_Consecutivos]  SET [MR_Aceptado_Parcial] = (Select [MR_Aceptado_Parcial] From [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos_Consecutivos])+1"
            ElseIf Mensaje = "3" Then
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos_Consecutivos]  SET [MR_Rechazado] = (Select [MR_Rechazado] From [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos_Consecutivos])+1"
            End If

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing

        Catch ex As Exception
            VariablesGlobales.Obj_Log.Log("ERROR en ActualizaObtieneConsecutivoMR [ " & ex.Message & " ]", "MR")
            MessageBox.Show("ERROR en ActualizaObtieneConsecutivoMR [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function MarcaComoCorregido(Clave As String, Corregido As Integer)
        Try
            Dim SQL_Comman As SqlCommand
            SQL_Comman = Conectar()
            Dim Consulta As String

            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos]  SET [Corregido] = '" & Corregido & "' WHERE Clave='" & Clave & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing

        Catch ex As Exception
            VariablesGlobales.Obj_Log.Log("ERROR en MarcaComoCorregido [ " & ex.Message & " ]", "MR")
            MessageBox.Show("ERROR en MarcaComoCorregido [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function FacturaComentario(Chequeado As Boolean, Consecutivo As Integer, DocNum As Integer, Comentario As String)
        Try
            Dim SQL_Comman As SqlCommand
            SQL_Comman = Conectar()
            Dim Consulta As String

            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] SET [Comentario] = '" & Comentario & "' WHERE [Consecutivo] = '" & Consecutivo & "' and [DocNum] = '" & DocNum & "'"


            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing

        Catch ex As Exception
            VariablesGlobales.Obj_Log.Log("ERROR en FacturaComentario [ " & ex.Message & " ]", "MR")
            MessageBox.Show("ERROR en FacturaComentario [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function FacturaChequeada(Chequeado As Boolean, Consecutivo As Integer, DocNum As Integer)
        Try
            Dim SQL_Comman As SqlCommand
            SQL_Comman = Conectar()
            Dim Consulta As String
            If Chequeado = True Then
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] SET [Chequeado] = 1 WHERE [Consecutivo] = '" & Consecutivo & "' and [DocNum] = '" & DocNum & "'"
            Else
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] SET [Chequeado] = 0 WHERE [Consecutivo] = '" & Consecutivo & "' and [DocNum] = '" & DocNum & "'"
            End If


            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing

        Catch ex As Exception
            VariablesGlobales.Obj_Log.Log("ERROR en MarcaComoCorregido [ " & ex.Message & " ]", "MR")
            MessageBox.Show("ERROR en MarcaComoCorregido [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ActualizaComprobanteProveedor(Clave As String, NumeroConsecutivoReceptor As String, Mensaje As String, DetalleMensaje As String, Fecha As String, Hora As String)
        Try
            Dim SQL_Comman As SqlCommand
            SQL_Comman = Conectar()
            Dim Consulta As String
            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobanteProveedor]  SET 
                [NumeroConsecutivoReceptor] = '" & NumeroConsecutivoReceptor & "',
                [Mensaje] = '" & Mensaje & "',
                [DetalleMensaje] = '" & DetalleMensaje & "'
                Where Clave='" & Clave & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()

            SQL_Comman = Nothing


        Catch ex As Exception
            MessageBox.Show("ERROR en Guarda_MensajeHacienda [ " & ex.Message & " ]")
        End Try

    End Function






    Public Function GuardaComprobanteProveedor(Clave As String, TipoCedulaEmisor As String, NumeroCedulaEmisor As String, FechaEmisionDoc As String,
                                               MontoTotalImpuesto As String, TotalFactura As String, TipoCedulaReceptor As String, NumeroCedulaReceptor As String,
                                               Fecha As String, Hora As String, Tipo As String)
        Try

            Dim SQL_Comman As SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String
            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobanteProveedor]
           ([Clave]
           ,[TipoCedulaEmisor]
           ,[NumeroCedulaEmisor]
           ,[FechaEmisionDoc]
           ,[MontoTotalImpuesto]
           ,[TotalFactura]
           ,[TipoCedulaReceptor]
           ,[NumeroCedulaReceptor]
           ,[Fecha]
           ,[Hora]
           ,[Tipo])
     VALUES
           ('" & Clave & "'
           ,'" & TipoCedulaEmisor & "'
           ,'" & NumeroCedulaEmisor & "'
           ,'" & FechaEmisionDoc & "'
           ,'" & MontoTotalImpuesto & "'
           ,'" & TotalFactura & "'
           ,'" & TipoCedulaReceptor & "'
           ,'" & NumeroCedulaReceptor & "'
           ,'" & Fecha & "'
           ,'" & Hora & "'
           ,'" & Tipo & "')"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR en Guarda_MensajeHacienda [ " & ex.Message & " ]")
        End Try


    End Function



    Public Function GuardaComprobanteEnBitacora(TipoComprobante As String, clave As String, ind_estado As String, fecha As String, Mensaje As String, Hora As String)

        Dim Consulta As String
        Try
            Dim SQL_Comman As SqlCommand
            SQL_Comman = Conectar()



            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos_Bitacora]
           ([TipoComprobante]
           ,[Clave]
           ,[ind_estado]
           ,[fecha]
           ,[Mensaje]
           ,[Hora])
     VALUES
           ('" & TipoComprobante &
           "','" & clave &
           "','" & ind_estado &
           "','" & fecha &
           "','" & Mensaje.Replace("""", "-").Replace("'", "-").Replace(",", ".").Replace("" & vbLf & vbLf & "", "/") &
           "','" & Hora & "')"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR en GuardaComprobanteEnBitacora [ " & ex.Message & " ]")
        End Try


    End Function
    Public Function Obtiene_Comprobante(Motivo As String, Tipo As String, ReGeneraClave As String, Situacion_de_Comprobante As String)
        Try
            Dim SQL_Comman As SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "SELECT [TipoComprobante]
                              ,[Clave]
                              ,[Consecutivo]
                              ,[Fecha]
                              ,[Emisor_Nombre]
                              ,[Emisor_Tipo]
                              ,[Emisor_Numero]
                              ,[Emisor_NombreComercial]
                              ,[Emisor_Provincia]
                              ,[Emisor_Canton]
                              ,[Emisor_Distrito]
                              ,[Emisor_Barrio]
                              ,[Emisor_OtrasSenas]
                              ,[Emisor_CodigoPais]
                              ,[Emisor_NumTelefono]
                              ,[Emisor_Fax]
                              ,[Emisor_CorreoElectronico]
                              ,[Receptor_Nombre]
                              ,[Receptor_Tipo]
                              ,[Receptor_Numero]
                              ,[Receptor_IdentificacionExtranjero]
                              ,[Receptor_NombreComercial]
                              ,[Receptor_Provincia]
                              ,[Receptor_Canton]
                              ,[Receptor_Distrito]
                              ,[Receptor_Barrio]
                              ,[Receptor_OtrasSenas]
                              ,[Receptor_CodigoPais]
                              ,[Receptor_NumTelefono]
                              ,[Receptor_Fax]
                              ,[Receptor_CorreoElectronico]
                              ,[CondicionVenta]
                              ,[PlazoCredito]
                              ,[MedioPago]
                              ,[DetalleServicio_NumeroLinea]
                              ,[DetalleServicio_TipoCodigo]
                              ,[DetalleServicio_Codigo]
                              ,[DetalleServicio_Cantidad]
                              ,[DetalleServicio_UnidadMedida]
                              ,[DetalleServicio_UnidadMedidaComercial]
                              ,[DetalleServicio_Detalle]
                              ,[DetalleServicio_PrecioUnitario]
                              ,[DetalleServicio_MontoTotal]
                              ,[DetalleServicio_MontoDescuento]
                              ,[DetalleServicio_NaturalezaDescuento]
                              ,[DetalleServicio_SubTotal]
                              ,[DetalleServicio_CodigoImpuesto]
                              ,[DetalleServicio_TarifaImpuesto]
                              ,[DetalleServicio_MontoImpuesto]
                              ,[Exoneracion_TipoDocumento]
                              ,[Exoneracion_NumeroDocumento]
                              ,[Exoneracion_MontoImpuesto]
                              ,[Exoneracion_NombreInstirucion]
                              ,[Exoneracion_FechaEmision]
                              ,[Exoneracion_PorcentajeCompra]
                              ,[MontoTotalLinea]
                              ,[ResumenFactura_CodigoMoneda]
                              ,[ResumenFactura_TipoCambio]
                              ,[ResumenFactura_TotalServGravados]
                              ,[ResumenFactura_TotalServExentos]
                              ,[ResumenFactura_TotalMercanciasGravadas]
                              ,[ResumenFactura_TotalMercanciasExentas]
                              ,[ResumenFactura_TotalGravado]
                              ,[ResumenFactura_TotalExento]
                              ,[ResumenFactura_TotalVenta]
                              ,[ResumenFactura_TotalDescuentos]
                              ,[ResumenFactura_TotalVentaNeta]
                              ,[ResumenFactura_TotalImpuesto]
                              ,[ResumenFactura_TotalComprobante]
                              ,[Referencia_Numero]
                              ,[Referencia_TipoDoc] 
                              ,[Referencia_FechaEmision]
                              ,[Referencia_Codigo]
                              ,[Referencia_Razon]
                              ,[CodSeguridad]
					          ,[CodCliente]
				              ,[Agente]"

            If Motivo = "Null" Or Motivo = "Desconocido" Or Motivo = "Sin Internet" Then
                'Si el motivo es Null , Desconocido o Sin Internet es por que son comprobantes que tuvieron errores al enviarse a haciena y se desean reeintentar enviar
                Consulta = Consulta & "FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos] WHERE Clave='" & ReGeneraClave & "'"
            Else


                If Tipo = "TE" Then
                    If ReGeneraClave = "" Then
                        Consulta = Consulta & " From " & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & ".dbo.Consulta_TE((Select FE From " & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & ".dbo.Consecutivo_Comprobantes AS T9))"
                    Else
                        'se consulta el dato del comprobante segun la clave y no segun el consecutivo 
                        Consulta = Consulta & " From " & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & ".dbo.Consulta_TE(" & ReGeneraClave & ",'" & Situacion_de_Comprobante & "')"
                    End If
                End If

                If Tipo = "FE" Then
                    If ReGeneraClave = "" Then
                        Consulta = Consulta & " From " & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & ".dbo.Consulta_FE((Select FE From " & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & ".dbo.Consecutivo_Comprobantes AS T9))"
                    Else
                        'se consulta el dato del comprobante segun la clave y no segun el consecutivo 
                        Consulta = Consulta & " From " & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & ".dbo.Consulta_FE(" & ReGeneraClave & ",'" & Situacion_de_Comprobante & "')"
                    End If
                End If

                If Tipo = "NC" Then
                    If ReGeneraClave = "" Then
                        Consulta = Consulta & " From " & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & ".dbo.Consulta_NC((Select NC From " & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & ".dbo.Consecutivo_Comprobantes AS T9))"
                    Else
                        'se consulta el dato del comprobante segun la clave y no segun el consecutivo 
                        Consulta = Consulta & " From " & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & ".dbo.Consulta_NC(" & ReGeneraClave & ",'" & Situacion_de_Comprobante & "')"
                    End If

                End If

                If Tipo = "ND" Then
                    If ReGeneraClave = "" Then
                        Consulta = Consulta & " From " & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & ".dbo.Consulta_ND((Select FE From " & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & ".dbo.Consecutivo_Comprobantes AS T9))"
                    Else
                        'se consulta el dato del comprobante segun la clave y no segun el consecutivo 
                        Consulta = Consulta & " From " & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & ".dbo.Consulta_ND(" & ReGeneraClave & ",'" & Situacion_de_Comprobante & "')"
                    End If
                End If

            End If

            '**************** OJO CONSULTAR CONSECUTIVO DE FES,NCS Y NDS **********************
            'Select Case* From Consulta_FE((Select FES From dbo.Consecutivo_Comprobantes AS T9))
            '**************** OJO CONSULTAR CONSECUTIVO DE FES,NCS Y NDS **********************

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en Obtiene_Comprobante [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ActualizaEstado(ByVal Clave As String, ind_estado As String, fecha As String, Mensaje As String, Tipo As String)
        Try

            Dim SQL_Comman As SqlCommand
            SQL_Comman = Conectar()
            Dim cont As Integer = 0
            Dim Consulta As String

            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL
            If Tipo = "MR" Then
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobanteProveedor]  SET  
            [ind_estado] ='" & ind_estado & "'
           ,[Fecha_estado] ='" & fecha & "'
           ,[MensajeHacienda] ='" & Mensaje.Replace("""", "-").Replace("'", "-").Replace(",", ".").Replace("" & vbLf & vbLf & "", "/") & "'" &
        " WHERE [Clave]='" & Clave & "'"

            Else
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos]  SET  
            [ind_estado] ='" & ind_estado & "'
           ,[Fecha_estado] ='" & fecha & "'
           ,[Mensaje] ='" & Mensaje.Replace("""", "-").Replace("'", "-").Replace(",", ".").Replace("" & vbLf & vbLf & "", "/") & "'" &
                        " WHERE [Clave]='" & Clave & "'"
            End If



            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()

            SQL_Comman = Nothing
            'Obj_CX_SQL.Desconectar()

        Catch ex As Exception
            MessageBox.Show("ERROR en ActualizaEstado [ " & ex.Message & " ]")
        End Try
        Return 0

    End Function
    Public Function ActualizaMotivoMR(ByVal Clave As String, Mensaje As String)
        Try

            Dim SQL_Comman As SqlCommand
            SQL_Comman = Conectar()
            Dim cont As Integer = 0
            Dim Consulta As String

            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobanteProveedor] SET [Motivo] ='" & Mensaje & "' WHERE [Clave]='" & Clave & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            'Obj_CX_SQL.Desconectar()

        Catch ex As Exception
            MessageBox.Show("ERROR en ActualizaMotivoMR [ " & ex.Message & " ]")
        End Try
        Return 0

    End Function


    Public Function ObtieneComprobantesProveedores(Proveedor As String, Motivo As String, Tipo As String, Clave As String, Situacion_de_Comprobante As String, EstadoEnHacienda As String, FechaINI As String, FechaFIN As String, EstadoDefinido As String, BuscaXFechas As Boolean, VerProcesadas As Boolean)
        Try
            Dim SQL_Comman As SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim FiltraEstado As Boolean = False 'controla si se ha seleccionado algun filtro de estado


            Consulta = "SELECT 
                             [ind_estado]
                            ,[Fecha_estado]
                            ,[MensajeHacienda]
                            ,(SELECT case when 30-(DATEDIFF(DAY, [Fecha],GETDATE())) < 0 then 0 else 30-(DATEDIFF(DAY, [Fecha],GETDATE())) end) as Dias
                             ,[Nombre_Emisor]                            
                               ,[TotalFactura]
                            ,[Clave]
                            ,[ConsecutivoComprobante]
                            ,[TipoCedulaEmisor]
                            ,[NumeroCedulaEmisor]
                           
                            ,[FechaEmisionDoc]
                            ,[MontoTotalImpuesto]
                         
                            ,[TipoCedulaReceptor]
                            ,[NumeroCedulaReceptor]
                            ,[Fecha]
                            ,[Hora]
                            ,[Tipo]
                            ,[NumeroConsecutivoReceptor]
                            ,[Mensaje]
                            ,[DetalleMensaje]
                            ,[CorreoElectronicoEmisor]
                            ,[Nombre_Receptor]
                            ,[CorreoElectronicoReceptor] 
                                                       ,[Motivo]
                            ,[CodigoActividad]
                            ,[CondicionImpuestoEmisor]
                            ,[MontoTotalImpuestoAcreditarEmisor]
                            ,[MontoTotalDeGastoAplicableEmisor]
                         From [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobanteProveedor]
                        Where "

            Dim entro As Boolean = False

            If Clave <> "" Then

                Consulta = Consulta & " [Clave] like '%" & Clave & "%' "
                entro = True



            Else



                If Tipo <> "" Then
                    Consulta = Consulta & "[Tipo] ='" & Tipo & "' "
                    entro = True
                End If

                If EstadoEnHacienda <> "" Then
                    FiltraEstado = True
                    If entro = True Then
                        Consulta = Consulta & " and "
                        entro = False
                    End If
                    If EstadoEnHacienda = "Otros" Then
                        Consulta = Consulta & " [ind_estado] <> 'aceptado' and [ind_estado] <> 'rechazado'  "
                    Else
                        Consulta = Consulta & " [ind_estado] = '" & EstadoEnHacienda & "' "
                    End If


                    entro = True
                Else
                    'If entro = True Then
                    '    Consulta = Consulta & " and "
                    '    entro = False
                    'End If
                    'Consulta = Consulta & "[ind_estado] IS NULL "
                    'entro = True
                End If


                If Proveedor <> "" Then
                    If entro = True Then
                        Consulta = Consulta & " and "
                        entro = False
                    End If
                    Consulta = Consulta & " [Nombre_Emisor] like '%" & Proveedor & "%' "
                    entro = True
                End If




                If BuscaXFechas = True Then
                    If entro = True Then
                        Consulta = Consulta & " and "
                        entro = False
                    End If
                    Consulta = Consulta & " FechaComprobanteRecibido between '" & FechaINI & "' and '" & FechaFIN & "' "
                    entro = True
                End If

                If EstadoDefinido <> "" Then
                    FiltraEstado = True
                    If entro = True Then
                        Consulta = Consulta & " and "
                        entro = False
                    End If

                    If EstadoDefinido = "Comprobante Aceptado" Then
                        Consulta = Consulta & " [Mensaje]='1'"
                    End If
                    If EstadoDefinido = "Comprobante Parcialmente Aceptado" Then
                        Consulta = Consulta & " [Mensaje]='2'"
                    End If
                    If EstadoDefinido = "Rechazado" Then
                        Consulta = Consulta & " [Mensaje]='3'"
                    End If
                    entro = True
                End If


            End If

            If VerProcesadas = True Then
                'If entro = True Then
                '    Consulta = Consulta & " and "
                '    entro = False
                'End If
                '' muestra TODOS los comprobantes PROCESADOS Y NO PROCESADOS
                'Consulta = Consulta & " [ind_estado] is null or [ind_estado] ='' or [ind_estado] is not null "
            Else
                'solo muestra comprobantes NO PROCESADOS
                If FiltraEstado = False Then
                    If entro = True Then
                        Consulta = Consulta & " and "
                        entro = False
                    End If
                    Consulta = Consulta & " [ind_estado] is null or [ind_estado] =''"
                End If

            End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            MessageBox.Show("Error en ObtieneComprobantesProveedores [ " & ex.Message & " ]")
        End Try
    End Function

#End Region

#Region "Planilla"


    Public Function ELIMINA_Deducciones(ByVal Cedula As String, ByVal Cbx_Tipo As String, ByVal SQL_Comman As SqlCommand)

        Dim Consulta As String
        Consulta = "DELETE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Planilla_DeduccionesFijas] where [Cedula_Empleado]='" & Trim(Cedula) & "' and Tipo='" & Trim(Cbx_Tipo) & "'"
        SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()

    End Function
    Public Function ELIMINA_Planilla_TEMP(ByVal id As String, ByVal SQL_Comman As SqlCommand)
        Dim Consulta As String
        Consulta = "DELETE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Planilla_Temp] where id='" & id & "'"
        SQL_Comman.CommandText = Consulta
        SQL_Comman.ExecuteNonQuery()
    End Function


    Public Function obtienePlanillas(ByVal SQL_Comman As SqlCommand)
        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Consulta = "SELECT  [id] ,[FechaINI] ,[FechaFIN] ,SUM([Dedu_CCSS]) AS CCSS ,SUM([SalarioFinal]) AS TOTAL FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Planilla] group by id,[FechaINI],[FechaFIN]"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
        End Try
    End Function


    Public Function CONSULTA_Planilla_Temp(ByVal id As Integer, ByVal SQL_Comman As SqlCommand)

        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Consulta = "Select [Ced_Empleado]" &
                          ",[NombreEmpleado]" &
                          ",[Puesto]" &
                          ",[Salario]" &
                          ",[SalarioQuincenal]" &
                          ",[ADICIONAL]" &
                          ",[DEB_PERSONAL]" &
                          ",[DUCC_CUOTA_BP]" &
                          ",[DEDUCION_DE_CELULAR]" &
                          ",[EMBARGO]" &
                          ",[FALTANTES_LIQ]" &
                          ",[FACTURAS]" &
                          ",[COBROS_X_FALTANTE]" &
                          ",[COBROS_PRESTAMO]" &
                          ",[Dedu_CCSS]" &
                          ",[id],[Ced_Juridica],[Nombre],[FechaINI],[FechaFIN],[Comentario],[PorcCCSS],[Foto],[id_Empleado],[SalarioFinal]" &
                          "FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Planilla_Temp] where [id]='" & id & "' order by [NombreEmpleado] asc"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Dim contador As Integer = 0
            Dim totalplanilla As Double = 0
            If TABLA.Rows.Count > 0 Then
                While contador <TABLA.Rows.Count
                                   totalplanilla += CDbl(TABLA.Rows(contador).Item("SalarioFinal").ToString())

                    contador += 1
                End While
            End If

            Class_VariablesGlobales.frmPlanilla.txtb_TotalPlanilla.Text = FormatCurrency(totalplanilla, 2)

            Return TABLA
        Catch ex As Exception
        End Try

    End Function


    Public Function CONSULTA_Planilla(ByVal id As Integer, ByVal SQL_Comman As SqlCommand)

        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Consulta = "Select [Ced_Empleado]" &
                          ",[NombreEmpleado]" &
                          ",[Puesto]" &
                          ",[Salario]" &
                          ",[SalarioQuincenal]" &
                          ",[ADICIONAL]" &
                          ",[DEB_PERSONAL]" &
                          ",[DUCC_CUOTA_BP]" &
                          ",[DEDUCION_DE_CELULAR]" &
                          ",[EMBARGO]" &
                          ",[FALTANTES_LIQ]" &
                          ",[FACTURAS]" &
                          ",[COBROS_X_FALTANTE]" &
                          ",[COBROS_PRESTAMO]" &
                          ",[Dedu_CCSS]" &
                          ",[id],[Ced_Juridica],[Nombre],[FechaINI],[FechaFIN],[Comentario],[PorcCCSS],[Foto],[id_Empleado],[SalarioFinal]" &
                          "FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Planilla] where [id]='" & id & "' order by [NombreEmpleado] asc"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Dim contador As Integer = 0
            Dim totalplanilla As Double = 0
            If TABLA.Rows.Count > 0 Then
                While contador < TABLA.Rows.Count
                    totalplanilla += CDbl(TABLA.Rows(contador).Item("SalarioFinal").ToString())

                    contador += 1
                End While
            End If

            Class_VariablesGlobales.frmPlanilla.txtb_TotalPlanilla.Text = FormatCurrency(totalplanilla, 2)

            Return TABLA
        Catch ex As Exception
        End Try

    End Function
    Public Function CONSULTA_ID_Planilla(ByVal SQL_Comman As SqlCommand)
        Dim id As Integer = 1
        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Consulta = "SELECT [ID_Planilla]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Planilla_Consecutivos]"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Dim contardor As Integer = 0
            If TABLA.Rows.Count > 0 Then
                While contardor < TABLA.Rows.Count
                    id = TABLA.Rows(contardor).Item("ID_Planilla").ToString()

                    contardor += 1
                End While
            End If
        Catch ex As Exception
        End Try
        Return id
    End Function

    Public Function ExistePedidoAProveedorEnSAP(ByVal SQL_Comman As SqlCommand, DocNum As String)
        Dim NumPedido As String = ""
        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""

            Dim Existe As Boolean = False

            Consulta = "SELECT top 1 T0.[DocNum] FROM [BD_Bourne].[dbo].OPOR T0 WHERE T0.[NumAtCard] ='" & DocNum & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Dim contardor As Integer = 0
            If TABLA.Rows.Count > 0 Then
                NumPedido = TABLA.Rows(0).Item("DocNum").ToString()



            End If
            Return NumPedido
        Catch ex As Exception
            NumPedido = ""
        End Try

    End Function
    Public Function ExistePedidoEnSAP(ByVal SQL_Comman As SqlCommand, DocNum As String)

        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Dim Existe As Boolean = False

            Consulta = "SELECT top 1 [DocNum]  FROM [BD_Bourne].[dbo].[ORDR] where DocNum='" & DocNum & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Dim contardor As Integer = 0
            If TABLA.Rows.Count > 0 Then

                If TABLA.Rows(0).Item("DocNum").ToString() <> "" Then
                    Existe = True
                Else
                    Existe = False
                End If


            End If
            Return Existe
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function ExisteDevolucionEnSAP(ByVal SQL_Comman As SqlCommand, Boleta As String)

        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Dim Existe As Boolean = False

            Consulta = "SELECT top 1 [U_Boleta]  FROM [BD_Bourne].[dbo].[ORIN] where U_Boleta='" & Boleta & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Dim contardor As Integer = 0
            If TABLA.Rows.Count > 0 Then

                If TABLA.Rows(0).Item("U_Boleta").ToString() <> "" Then
                    Existe = True
                Else
                    Existe = False
                End If


            End If
            Return Existe
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function ObtieneInentario(ByVal Descripcion As String, ByVal SQL_Comman As SqlCommand)
        Dim id As Integer = 1
        Dim TABLA As New DataTable
        Try

            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            If Descripcion <> "" Then
                Consulta = "SELECT T0.[ItemCode], T0.[ItemName] FROM [BD_Bourne].[dbo].[OITM] T0 where [ItemName] like '%" & Descripcion & "%'"
            Else
                Consulta = "SELECT T0.[ItemCode], T0.[ItemName] FROM [BD_Bourne].[dbo].[OITM] T0"
            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
           
        Catch ex As Exception
        End Try

        Return TABLA
    End Function
    Public Function ObtieneLineasNuevas(ByVal SQL_Comman As SqlCommand)
        Dim id As Integer = 1
        Dim TABLA As New DataTable
        Try

            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""

            Consulta = "SELECT [Id],[ItemCode],[ItemName],[Pack],[Alterno],[UnitPrice],[FechaVence],[CodBarras],[Gramage] FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Picking_LineasNuevas] where Estado=0"


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

        Catch ex As Exception
        End Try

        Return TABLA
    End Function


    Public Function ActualizaSalarioEmpleado(ByVal Cedula As String, ByVal Salario As Double, ByVal SQL_Comman As SqlCommand)

        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Planilla_Empleado] SET [Salario] ='" & Salario & "' where  Cedula='" & Cedula & "' "

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            Return True

        Catch ex As Exception
        End Try
    End Function



    Public Function ModifRepDev(ByVal Consecutivo As String, ByVal Codigo As String, ByVal Descripcion As String, ByVal Origen As String, ByVal cantidad As String, ByVal Accion As String, ByVal cantidadMover As String, ByVal codDestino As String, ByVal BodDestino As String, ByVal Bodega As String, ByVal SQL_Comman As SqlCommand)
        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Devo] SET [Bodega]='" & Bodega & "',[Cantidad]='" & cantidad & "',[Cant_Mover]='" & cantidadMover & "',[Accion]='" & Accion & "',[CodArtCambiado]='" & codDestino & "',[Bod_Destino]='" & BodDestino & "' where  [Consecutivo] ='" & Consecutivo & "' and [ItemCode] ='" & Codigo & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            Return True

        Catch ex As Exception
        End Try
    End Function
    Public Function AUMENTA_ID_Planilla(ByVal ID As Integer, ByVal SQL_Comman As SqlCommand)

        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Planilla_Consecutivos] SET [ID_Planilla] ='" & ID & "'  "


            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            Return True

        Catch ex As Exception
        End Try



    End Function
    Public Function ACTUALIZA_ID_Planilla(ByVal ID As Integer, ByVal SQL_Comman As SqlCommand)

        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""

            Consulta = "UPDATE  [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Planilla_Consecutivos] SET [ID_Planilla]='" & ID & "'"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

        Catch ex As Exception
        End Try
    End Function

    Public Function VerificaDuplicadoPlanilla(ByVal Cedula As String, ByVal id As String, ByVal SQL_Comman As SqlCommand)
        Dim Existe As Boolean = False
        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Consulta = "SELECT [Ced_Empleado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Planilla_Temp] where [Ced_Empleado]='" & Trim(Cedula) & "' and [id]='" & Trim(id) & "'"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Dim contardor As Integer = 0
            If TABLA.Rows.Count > 0 Then
                Existe = True

            End If
        Catch ex As Exception
        End Try
        Return Existe
    End Function

    Public Function VerificaDuplicadoDeduccionFija(ByVal Cedula As String, ByVal Tipo As String, ByVal SQL_Comman As SqlCommand)
        Dim Existe As Boolean = False
        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Consulta = "SELECT [Cedula_Empleado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Planilla_DeduccionesFijas] where [Cedula_Empleado]='" & Cedula & "' and [Tipo]='" & Tipo & "'"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Dim contardor As Integer = 0
            If TABLA.Rows.Count > 0 Then
                Existe = True

            End If
        Catch ex As Exception
        End Try
        Return Existe
    End Function
    Public Function OtieneCedula(ByVal SQL_Comman As SqlCommand)
        Dim Cedula As String = ""
        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""

            Consulta = "SELECT CONCAT (0,[Tipo_Cedula],RIGHT('000000000000' + [Cedula],12)) as Cedula  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Empresa]"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Dim contardor As Integer = 0
            If TABLA.Rows.Count > 0 Then
                Cedula = TABLA.Rows(0).Item("Cedula").ToString()

            End If
        Catch ex As Exception
        End Try
        Return Cedula
    End Function
    Public Function GuardaDeduccionFija(ByVal Cedula As String, ByVal Nombre As String, ByVal Cbx_Tipo As String, ByVal Monto As Double, ByVal FechaLimite As String, ByVal Hasta As String, ByVal GUARDANDO As Boolean, ByVal SQL_Comman As SqlCommand)
        Dim Consulta As String = ""
        If GUARDANDO = True Then

            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Planilla_DeduccionesFijas]" &
                       " ([Cedula_Empleado]" &
                       " ,[Nombre]" &
                       " ,[Tipo]" &
                       " ,[Monto]" &
                       " ,[FechaLimteActiva]" &
                       " ,[FechaLimite]" & ")" &
                       " VALUES('" & Cedula & "','" & Nombre & "','" & Cbx_Tipo & "','" & Monto & "','" & Hasta & "','" & FechaLimite & "')"


        Else
            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Planilla_DeduccionesFijas] " &
               "SET [Nombre] = '" & Nombre & "'" &
                  ",[Tipo] = '" & Cbx_Tipo & "'" &
                  ",[Monto] = '" & Monto & "'" &
                  ",[FechaLimteActiva] ='" & FechaLimite & "'" &
                  ",[FechaLimite] = '" & Hasta & "'" &
                  "  WHERE [Cedula_Empleado] = '" & Cedula & "'"
        End If
        SQL_Comman.CommandText = Consulta
        SQL_Comman.ExecuteNonQuery()
        SQL_Comman = Nothing
        Return True
    End Function

    Public Function CONSULTA_Deducciones(ByVal Cedula As String, ByVal SQL_Comman As SqlCommand)

        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Consulta = "Select [Cedula_Empleado]" &
                          ",[Nombre]" &
                          ",[Monto]" &
                          ",[FechaLimteActiva]" &
                          ",[FechaLimite]" &
                          ",[Tipo]" &
                          "FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Planilla_DeduccionesFijas] where [Cedula_Empleado]='" & Trim(Cedula) & "' "

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
        End Try

    End Function

    Public Function GuardaPlanilla(ByVal id As Integer, ByVal CedJuridica As String, ByVal Nombre As String, ByVal PorcCCSS As String, _
         ByVal FechaIngreso As String, ByVal FechaSalida As String, ByVal CedulaEmpleado As String, ByVal Puesto As String, _
         ByVal NombreEmpleado As String, ByVal Salario As Double, ByVal SalarioQuincenal As Double, ByVal Dedu_Adicional As Double, _
         ByVal Dedu_Deb_Personal As Double, ByVal Dedu_Ducc_Cuota As Double, ByVal Dedu_Celular As Double, _
         ByVal Dedu_Embargo As Double, ByVal Dedu_Prestamo As Double, ByVal Dedu_FaltaLiq As Double, ByVal Dedu_Facturas As Double, ByVal Dedu_Faltante As Double, ByVal Dedu_CCSS As Double, _
         ByVal Dedu_Otro As Double, ByVal Lbl_Salario As Double, ByVal Foto As String, ByVal GUARDANDO As Boolean, ByVal SQL_Comman As SqlCommand)
        Try
            Dim Consulta As String = ""
            If GUARDANDO = True Then

                Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Planilla]" &
          " ([id]" &
          " ,[Ced_Juridica]" &
          " ,[Nombre]" &
          " ,[FechaINI]" &
          " ,[FechaFIN]" &
          " ,[PorcCCSS]" &
          " ,[Ced_Empleado]" &
          " ,[NombreEmpleado]" &
          " ,[Puesto]" &
          " ,[Salario]" &
          " ,[SalarioQuincenal]" &
          " ,[ADICIONAL]" &
          " ,[DEB_PERSONAL]" &
          " ,[DUCC_CUOTA_BP]" &
          " ,[DEDUCION_DE_CELULAR]" &
          " ,[EMBARGO]" &
          " ,[FALTANTES_LIQ]" &
          " ,[FACTURAS]" &
          " ,[COBROS_X_FALTANTE]" &
          ",[COBROS_PRESTAMO]" &
          ",[Foto]" &
          ",[Dedu_CCSS]" &
          ",[SalarioFinal])" &
              "VALUES('" & id & "','" & CedJuridica & "','" & Nombre & "','" & FechaIngreso & "','" & FechaSalida & "','" & PorcCCSS &
              "','" & CedulaEmpleado & "','" & NombreEmpleado & "','" & Puesto & "','" & Salario & "','" & SalarioQuincenal &
              "','" & Dedu_Adicional & "','" & Dedu_Deb_Personal & "','" & Dedu_Ducc_Cuota & "','" & Dedu_Celular &
              "','" & Dedu_Embargo & "','" & Dedu_FaltaLiq & "','" & Dedu_Facturas & "','" & Dedu_Faltante & "','" & Dedu_Prestamo & "','" & Foto & "','" & Dedu_CCSS & "','" & Lbl_Salario & "')"


            Else
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Planilla] " &
                   "SET [Ced_Juridica] = '" & CedJuridica & "'" &
                      ",[Nombre] = '" & Nombre & "'" &
                      ",[FechaINI] = '" & FechaIngreso & "'" &
                      ",[FechaFIN] ='" & FechaSalida & "'" &
                      ",[PorcCCSS] = '" & PorcCCSS & "'" &
                      ",[Ced_Empleado] = '" & CedulaEmpleado & "'" &
                      ",[NombreEmpleado] = '" & NombreEmpleado & "'" &
                      ",[Puesto] = '" & Puesto & "'" &
                      ",[Salario] = '" & Salario & "'" &
                      ",[SalarioQuincenal] = '" & SalarioQuincenal & "' " &
                      ",[ADICIONAL] = '" & Dedu_Adicional & "' " &
                      ",[DEB_PERSONAL] = '" & Dedu_Deb_Personal & "' " &
                      ",[DUCC_CUOTA_BP] = '" & Dedu_Ducc_Cuota & "' " &
                      ",[DEDUCION_DE_CELULAR] = '" & Dedu_Celular & "' " &
                      ",[EMBARGO] = '" & Dedu_Prestamo & "' " &
                      ",[FALTANTES_LIQ] = '" & Dedu_FaltaLiq & "' " &
                      ",[FACTURAS] = '" & Dedu_Facturas & "' " &
                      ",[COBROS_X_FALTANTE] = '" & Dedu_Faltante & "' " &
                      ",[COBROS_PRESTAMO] = '" & Dedu_Prestamo & "' " &
                      ",[Dedu_CCSS] = '" & Dedu_CCSS & "' " &
                      ",[SalarioFinal] = '" & Lbl_Salario & "' " &
                      "WHERE [id] = '" & id & "'"
            End If
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            Return True

        Catch ex As Exception
            MessageBox.Show("ERROR en GuardaPlanilla [ " & ex.Message & " ]")
            Return False

        End Try
    End Function

    Public Function GuardaPlanilla_TEM(ByVal id As Integer, ByVal CedJuridica As String, ByVal Nombre As String, ByVal PorcCCSS As String, _
        ByVal FechaIngreso As String, ByVal FechaSalida As String, ByVal CedulaEmpleado As String, ByVal Puesto As String, _
        ByVal NombreEmpleado As String, ByVal Salario As Double, ByVal SalarioQuincenal As Double, ByVal Dedu_Adicional As Double, _
        ByVal Dedu_Deb_Personal As Double, ByVal Dedu_Ducc_Cuota As Double, ByVal Dedu_Celular As Double, _
        ByVal Dedu_Embargo As Double, ByVal Dedu_Prestamo As Double, ByVal Dedu_FaltaLiq As Double, ByVal Dedu_Facturas As Double, ByVal Dedu_Faltante As Double, ByVal Dedu_CCSS As Double, _
        ByVal Dedu_Otro As Double, ByVal Lbl_Salario As Double, ByVal Foto As String, ByVal id_Empleado As String, ByVal GUARDANDO As Boolean, ByVal SQL_Comman As SqlCommand)
        Try
            Dim Consulta As String = ""
            If GUARDANDO = True Then

                Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Planilla_Temp]" &
          " ([id]" &
          ", [Ced_Juridica]" &
          " ,[Nombre]" &
          " ,[FechaINI]" &
          " ,[FechaFIN]" &
          " ,[PorcCCSS]" &
          " ,[Ced_Empleado]" &
          " ,[NombreEmpleado]" &
          " ,[Puesto]" &
          " ,[Salario]" &
          " ,[SalarioQuincenal]" &
          " ,[ADICIONAL]" &
          " ,[DEB_PERSONAL]" &
          " ,[DUCC_CUOTA_BP]" &
          " ,[DEDUCION_DE_CELULAR]" &
          " ,[EMBARGO]" &
          " ,[FALTANTES_LIQ]" &
          " ,[FACTURAS]" &
          " ,[COBROS_X_FALTANTE]" &
           ",[COBROS_PRESTAMO]" &
           ",[Dedu_CCSS]" &
           ",[Foto]" &
           ",[id_Empleado]" &
           ",[SalarioFinal])" &
              "VALUES('" & id & "','" & CedJuridica & "','" & Nombre & "','" & FechaIngreso & "','" & FechaSalida & "','" & PorcCCSS &
              "','" & CedulaEmpleado & "','" & NombreEmpleado & "','" & Puesto & "','" & Salario & "','" & SalarioQuincenal &
              "','" & Dedu_Adicional & "','" & Dedu_Deb_Personal & "','" & Dedu_Ducc_Cuota & "','" & Dedu_Celular &
              "','" & Dedu_Embargo & "','" & Dedu_FaltaLiq & "','" & Dedu_Facturas & "','" & Dedu_Faltante & "','" & Dedu_Prestamo & "','" & Dedu_CCSS & "','" & Foto & "','" & id_Empleado & "','" & Lbl_Salario & "')"


            Else
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Planilla_Temp] " &
                   "SET [Ced_Juridica] = '" & CedJuridica & "'" &
                      ",[Nombre] = '" & Nombre & "'" &
                      ",[FechaINI] = '" & FechaIngreso & "'" &
                      ",[FechaFIN] ='" & FechaSalida & "'" &
                      ",[PorcCCSS] = '" & PorcCCSS & "'" &
                      ",[Ced_Empleado] = '" & CedulaEmpleado & "'" &
                      ",[NombreEmpleado] = '" & NombreEmpleado & "'" &
                      ",[Puesto] = '" & Puesto & "'" &
                      ",[Salario] = '" & Salario & "'" &
                      ",[SalarioQuincenal] = '" & SalarioQuincenal & "' " &
                      ",[ADICIONAL] = '" & Dedu_Adicional & "' " &
                      ",[DEB_PERSONAL] = '" & Dedu_Deb_Personal & "' " &
                      ",[DUCC_CUOTA_BP] = '" & Dedu_Ducc_Cuota & "' " &
                      ",[DEDUCION_DE_CELULAR] = '" & Dedu_Celular & "' " &
                      ",[EMBARGO] = '" & Dedu_Prestamo & "' " &
                      ",[FALTANTES_LIQ] = '" & Dedu_FaltaLiq & "' " &
                      ",[FACTURAS] = '" & Dedu_Facturas & "' " &
                      ",[COBROS_X_FALTANTE] = '" & Dedu_Faltante & "' " &
                      ",[COBROS_PRESTAMO] = '" & Dedu_Prestamo & "' " &
                      ",[Dedu_CCSS] = '" & Dedu_CCSS & "' " &
                      ",[Foto] = '" & Foto & "' " &
                      ",[id_Empleado] = '" & id_Empleado & "' " &
                      ",[SalarioFinal] = '" & Lbl_Salario & "' " &
                      "WHERE [Ced_Empleado] = '" & CedulaEmpleado & "'"
            End If
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            Return True

        Catch ex As Exception
            MessageBox.Show("ERROR en GuardaPlanilla [ " & ex.Message & " ]")
            Return False

        End Try
    End Function


    Public Function GuardaEmpleado(ByVal id As Integer, ByVal Cedula As String, ByVal Nombre As String, ByVal Puesto As String, ByVal Telefono1 As String, ByVal Telefono2 As String, ByVal RutaImagen As String, ByVal Salario As String, ByVal FechaIngreso As String, ByVal FechaSalida As String, ByVal DTGV_Experiencia As DataTable, ByVal DTGV_Educacion As DataTable, ByVal Activo As Boolean, ByVal Codigo As String, ByVal CodRuta As String, ByVal Correo As String, ByVal CodigoCobroXFaltante As String, ByVal GUARDANDO As Boolean, ByVal SQL_Comman As SqlCommand)

        Try
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL
            Consulta = ""
            If GUARDANDO = True Then
                Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Planilla_Empleado]" &
                           "([Cedula]" &
                           ",[Nombre]" &
                           ",[Telefono1]" &
                           ",[Telefono2]" &
                           ",[Puesto]" &
                           ",[Salario]" &
                           ",[FechaIngreso]" &
                           ",[FechaFin]" &
                           ",[Foto],[Activo],[Codigo],[CodRuta],[Correo],[CodigoCobroXFaltante])" &
                           "VALUES( '" & Trim(Cedula) & "','" & Nombre & "','" & Telefono1 & "','" & Telefono2 & "','" & Puesto & "','" & Salario & "','" & FechaIngreso & "','" & FechaSalida & "','" & RutaImagen & "','" & Activo & "','" & Codigo & "','" & CodRuta & "','" & Correo & "','" & CodigoCobroXFaltante & "')"

            Else
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Planilla_Empleado] " &
                   "SET [Nombre] = '" & Nombre & "'" &
                      ",[Telefono1] = '" & Telefono1 & "'" &
                      ",[Telefono2] = '" & Telefono2 & "'" &
                      ",[Puesto] ='" & Puesto & "'" &
                      ",[Salario] = '" & Salario & "'" &
                      ",[FechaIngreso] = '" & FechaIngreso & "'" &
                      ",[FechaFin] = '" & FechaSalida & "'" &
                      ",[Foto] = '" & RutaImagen & "'" &
                      ",[Activo] = '" & Activo & "' " &
                      ",[Codigo] = '" & Codigo & "' " &
                      ",[CodRuta] = '" & CodRuta & "' " &
                      ",[Correo] = '" & Correo & "' " &
                        ",[Cedula] = '" & Trim(Cedula) & "' " &
                      ",[CodigoCobroXFaltante] = '" & CodigoCobroXFaltante & "' " &
                      "WHERE [id] = '" & id & "'"
            End If
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            Return True

        Catch ex As Exception
            MessageBox.Show("ERROR en GuardaEmpleado [ " & ex.Message & " ]")
            Return False

        End Try
    End Function

    Public Function NavegaEmpleados(ByVal id As String, ByVal SQL_Comman As SqlCommand)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "Select Cedula,Nombre,Telefono1,Telefono2,Puesto,Salario,FechaIngreso,FechaFin,Foto,Activo,Codigo,id,CodRuta,Correo,CodigoCobroXFaltante from " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].Planilla_Empleado where id  = '" & id & "'"



            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en NavegaEmpleados [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function BuscaEmpleado(ByVal Pista As String, ByVal Busqueda As String, ByVal SQL_Comman As SqlCommand)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            If Busqueda = "Nombre" Then
                Consulta = "Select Cedula,Nombre,Telefono1,Telefono2,Puesto,Salario,FechaIngreso,FechaFin,Foto,Activo,Codigo,id,Correo,CodigoCobroXFaltante from " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].Planilla_Empleado where Nombre  like '%" & Pista & "%'"
            ElseIf Busqueda = "Cedula" Then
                Consulta = "Select Cedula,Nombre,Telefono1,Telefono2,Puesto,Salario,FechaIngreso,FechaFin,Foto,Activo,Codigo,id,Correo,CodigoCobroXFaltante from " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].Planilla_Empleado where Cedula  like '%" & Trim(Pista) & "%'"
            Else
                Consulta = "Select Cedula,Nombre,Telefono1,Telefono2,Puesto,Salario,FechaIngreso,FechaFin,Foto,Activo,Codigo,id,Correo,CodigoCobroXFaltante from " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].Planilla_Empleado "
            End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en BuscaEmpleado [ " & ex.Message & " ]")
        End Try

    End Function

#Region "EXPERIENCIA"

    Public Function GuardaExperiencia(ByVal Cedula As String, ByVal Empresa As String, ByVal ExPuesto As String, ByVal Persona As String, ByVal Telefono As String, ByVal FechaIngreso As String, ByVal FechaSalida As String, ByVal Comentario As String, ByVal DTGV_Experiencia As DataTable, ByVal GUARDANDO As Boolean, ByVal SQL_Comman As SqlCommand)
        Try
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL
            Consulta = ""
            If GUARDANDO = True Then

                Consulta = "INSERT INTO " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Planilla_Experiencia]" & _
           "([Cedula_Empleado]" & _
           ",[Empresa]" & _
           ",[Puesto]" & _
           ",[Fecha_Ingreso]" & _
           ",[Fecha_Salida]" & _
           ",[Person_Referencia]" & _
           ",[Telefono]" & _
           ",[Comentarios])" & _
                "VALUES('" & Cedula & "','" & Empresa & "','" & ExPuesto & "','" & FechaIngreso & "','" & FechaSalida & "','" & Persona & "','" & Telefono & "','" & Comentario & "')"


            Else
                Consulta = "UPDATE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Planilla_Experiencia] " & _
                      " SET [Empresa] = '" & Empresa & "'" & _
                      ",[Puesto] = '" & ExPuesto & "'" & _
                      ",[Fecha_Ingreso] = '" & FechaIngreso & "'" & _
                      ",[Fecha_Salida] ='" & FechaSalida & "'" & _
                      ",[Person_Referencia] = '" & Persona & "'" & _
                      ",[Telefono] = '" & Telefono & "'" & _
                      ",[Comentarios] = '" & Comentario & "' " & _
                      "WHERE [Cedula_Empleado] = '" & Cedula & "' AND Empresa LIKE ='%" & Empresa & "%'"
            End If
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            Return True

        Catch ex As Exception
            MessageBox.Show("ERROR en GuardaExperiencia [ " & ex.Message & " ]")
            Return False

        End Try
    End Function

    Public Function ObtieneExperiencia(ByVal Cedula As String, ByVal SQL_Comman As SqlCommand)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "Select Empresa,Puesto,Fecha_Ingreso,Fecha_Salida,Person_Referencia,Telefono,Comentarios from " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].Planilla_Experiencia where Cedula_Empleado='" & Cedula & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneExperiencia [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function EliminaExperiencia(ByVal Cedula As String, ByVal Empresa As String, ByVal SQL_Comman As SqlCommand)
        Dim Consulta As String
        Consulta = "DELETE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Planilla_Experiencia] where Cedula_Empleado='" & Cedula & "' AND Empresa LIKE '%" & Empresa & "%'"
        SQL_Comman.CommandText = Consulta
        SQL_Comman.ExecuteNonQuery()
    End Function

#End Region
#Region "DEDUCCIONES"


    Public Function EliminarDeducciones(ByVal Cedula As String, ByVal Categoria As String, ByVal SQL_Comman As SqlCommand)
        Dim Consulta As String
        Consulta = "DELETE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Planilla_Deducciones] where Cedula_Empleado='" & Cedula & "' and [Categoria]='" & Categoria & "'"
        SQL_Comman.CommandText = Consulta
        SQL_Comman.ExecuteNonQuery()
    End Function


    Public Function ObtieneDeducciones(ByVal Codigo As String, ByVal SQL_Comman As SqlCommand)

        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "SELECT [Categoria] ,[Monto] ,[Detalle] FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Planilla_Deducciones] where [Cedula_Empleado]='" & Codigo & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            If TABLA.Rows.Count > 0 Then
                Dim MontoDeducciones As Double
                Dim cont As Integer
                For Each row As DataRow In TABLA.Rows

                    MontoDeducciones += Convert.ToDouble(Trim(TABLA.Rows(cont).Item("Monto").ToString()))

                    cont += 1
                Next




                Class_VariablesGlobales.frmEmpleados.txb_MontoDeducciones.Text = MontoDeducciones
            End If



            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtineDeducciones [ " & ex.Message & " ]")
        End Try

    End Function



    Public Function GuardaDeducciones(ByVal Cedula As String, ByVal Categoria As String, ByVal Monto As String, ByVal Detalle As String, ByVal GUARDANDO As Boolean, ByVal SQL_Comman As SqlCommand)
        Try
            Dim Consulta As String

            Consulta = ""
            If GUARDANDO = True Then
                Consulta = "INSERT INTO " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Planilla_Deducciones]" & _
           "([Cedula_Empleado]" & _
           ",[Categoria]" & _
           ",[Monto]" & _
           ",[Detalle])" & _
                "VALUES('" & Cedula & "','" & Categoria & "','" & Monto & "','" & Detalle & "')"
            Else
                Consulta = "UPDATE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Planilla_Deducciones] " & _
                      " SET [Cedula_Empleado] = '" & Cedula & "'" & _
                      ",[Categoria] = '" & Categoria & "'" & _
                      ",[Monto] = '" & Monto & "'" & _
                      ",[Detalle] ='" & Detalle & "'" & _
                      "WHERE [Cedula_Empleado] = '" & Cedula & "'"
            End If
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            Return True

        Catch ex As Exception
            MessageBox.Show("ERROR en GuardaDeducciones [ " & ex.Message & " ]")
            Return False
        End Try
    End Function
#End Region
#Region "EDUCACION"

    Public Function GuardaEducacion(ByVal Cedula As String, ByVal Institucion As String, ByVal Fecha_Ingreso As String, ByVal Fecha_Salida As String, ByVal EnCurso As String, ByVal Grado As String, ByVal Titulo As String, ByVal GUARDANDO As Boolean, ByVal SQL_Comman As SqlCommand)
        Try
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL
            Consulta = ""
            If GUARDANDO = True Then
                Consulta = "INSERT INTO " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Planilla_Educacion]" & _
           "([Cedula_Empleado]" & _
           ",[Institucion]" & _
           ",[Fecha_Ingreso]" & _
           ",[Fecha_Salida]" & _
           ",[EnCurso]" & _
           ",[Grado]" & _
           ",[Titulo])" & _
                "VALUES('" & Cedula & "','" & Institucion & "','" & Fecha_Ingreso & "','" & Fecha_Salida & "','" & EnCurso & "','" & Grado & "','" & Titulo & "')"
            Else
                Consulta = "UPDATE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Planilla_Educacion] " & _
                      " SET [Cedula_Empleado] = '" & Cedula & "'" & _
                      ",[Institucion] = '" & Institucion & "'" & _
                      ",[Fecha_Ingreso] = '" & Fecha_Ingreso & "'" & _
                      ",[Fecha_Salida] ='" & Fecha_Salida & "'" & _
                      ",[EnCurso] = '" & EnCurso & "'" & _
                      ",[Grado] = '" & Grado & "'" & _
                      ",[Titulo] = '" & Titulo & "'" & _
                      "WHERE [Cedula_Empleado] = '" & Cedula & "' and [Institucion] like '%" & Institucion & "%'"
            End If
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            Return True

        Catch ex As Exception
            MessageBox.Show("ERROR en GuardaEducacion [ " & ex.Message & " ]")
            Return False
        End Try
    End Function

    Public Function ObtieneEducacion(ByVal Cedula As String, ByVal SQL_Comman As SqlCommand)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Consulta = "Select Institucion,Titulo,Fecha_Ingreso,Fecha_Salida,EnCurso,Grado from " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].Planilla_Educacion where Cedula_Empleado='" & Cedula & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneEducacion [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function EliminaEducacion(ByVal Cedula As String, ByVal Institucion As String, ByVal SQL_Comman As SqlCommand)
        Dim Consulta As String
        Consulta = "DELETE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Planilla_Educacion] where Cedula_Empleado='" & Cedula & "' AND Institucion LIKE '%" & Institucion & "%'"
        SQL_Comman.CommandText = Consulta
        SQL_Comman.ExecuteNonQuery()
    End Function

#End Region

#Region "VACACIONES"

    Public Function EliminaConsumoVacaciones(ByVal Cedula As String, ByVal FINI As String, ByVal FFIN As String, ByVal SQL_Comman As SqlCommand)
        Dim Consulta As String
        Consulta = "DELETE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Planilla_ConsumoVacaciones] where Cedula_Empleado='" & Cedula & "' AND [FechaIni] = '" & FINI & "' AND [FechaFin] = '" & FFIN & "'"
        SQL_Comman.CommandText = Consulta
        SQL_Comman.ExecuteNonQuery()
    End Function

    Public Function VacacionesConsumidas(ByVal Cedula As String, ByVal FechaINI As String, ByVal FechaFin As String, ByVal Dias As String, ByVal Comentario As String, ByVal GUARDANDO As Boolean, ByVal SQL_Comman As SqlCommand)
        Try
            Dim Consulta As String

            Consulta = ""
            If GUARDANDO = True Then
                Consulta = "INSERT INTO " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Planilla_ConsumoVacaciones]" & _
           "([Cedula_Empleado]" & _
           ",[FechaIni]" & _
           ",[FechaFin]" & _
           ",[Dias]" & _
           ",[Comentario])" & _
                "VALUES('" & Cedula & "','" & FechaINI & "','" & FechaFin & "','" & Dias & "','" & Comentario & "')"
            Else
                Consulta = "UPDATE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Planilla_ConsumoVacaciones] " & _
                      " SET [Cedula_Empleado] = '" & Cedula & "'" & _
                      ",[FechaIni] = '" & FechaINI & "'" & _
                      ",[FechaFin] = '" & FechaFin & "'" & _
                      ",[Dias]='" & Dias & "'" & _
                      ",[Comentario]='" & Comentario & "'" & _
                      "WHERE [Cedula_Empleado] = '" & Cedula & "'"
            End If
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            Return True

        Catch ex As Exception
            MessageBox.Show("ERROR en GuardaDeducciones [ " & ex.Message & " ]")
            Return False
        End Try
    End Function



    Public Function ObtieneVacacionesConsumidas(ByVal Codigo As String, ByVal SQL_Comman As SqlCommand)

        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "SELECT [FechaIni] ,[FechaFin] ,[Dias],[Comentario] FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Planilla_ConsumoVacaciones] where [Cedula_Empleado]='" & Codigo & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Dim MontoDeducciones As Double = 0
            If TABLA.Rows.Count > 0 Then
                Dim cont As Integer
                For Each row As DataRow In TABLA.Rows

                    MontoDeducciones += Convert.ToDouble(Trim(TABLA.Rows(cont).Item("Dias").ToString()))

                    cont += 1
                Next

            End If
            Class_VariablesGlobales.frmEmpleados.txtb_VCTotal.Text = CInt(MontoDeducciones)


            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneVacacionesConsumidas [ " & ex.Message & " ]")
        End Try

    End Function
#End Region


    Public Function ObtineFacturas(ByVal Codigo As String, ByVal SQL_Comman As SqlCommand)

        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "select * from [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "] .[dbo].FacturaPendiente('" & Codigo & "')"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneExperiencia [ " & ex.Message & " ]")
        End Try

    End Function

    Public Function ObtineFacturasSaldo(ByVal Codigo As String, ByVal SQL_Comman As SqlCommand)
        Dim SALDO As Double = 0
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable


            Dim Consulta As String = ""

            Consulta = "select sum(SALDO) as SALDO from [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "] .[dbo].FacturaPendiente('" & Trim(Codigo) & "')"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            For Each row As DataRow In TABLA.Rows
                SALDO = CDbl(Trim(TABLA.Rows(0).Item("SALDO").ToString()))
            Next


        Catch ex As Exception
            'MessageBox.Show("ERROR en ObtineFacturasSaldo [ " & ex.Message & " ]")

        End Try
        Return SALDO
    End Function
    Public Function ObtineCobroXFaltante(ByVal Codigo As String, ByVal FechaINI As String, ByVal FechaFIN As String, ByVal SQL_Comman As SqlCommand)
        Dim SALDO As Double = 0
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable


            Dim Consulta As String = ""

            Consulta = "select SUM(SALDO) AS SALDO from [FacturasPendientesXCliente] ('" & Codigo & "')'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            For Each row As DataRow In TABLA.Rows
                SALDO = CDbl(Trim(TABLA.Rows(0).Item("SALDO").ToString()))
            Next



        Catch ex As Exception
            ' MessageBox.Show("ERROR en ObtineCobroXFaltante [ " & ex.Message & " ]")
        End Try

        Return SALDO
    End Function
    Public Function ObtineLiqSaldo(ByVal Codigo As String, ByVal FechaINI As String, ByVal FechaFIN As String, ByVal SQL_Comman As SqlCommand)
        Dim SALDO As Double = 0
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable


            Dim Consulta As String = ""

            Consulta = "SELECT sum([Resultado]) as Saldo  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Liquidaciones] where Anulada ='0' and CodAgente ='" & Codigo & "' and [Fecha] between '" & FechaINI & "' and '" & FechaFIN & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            For Each row As DataRow In TABLA.Rows
                SALDO = CDbl(Trim(TABLA.Rows(0).Item("SALDO").ToString()))
            Next

            If SALDO > 0 Then
                SALDO = 0
            Else
                SALDO = SALDO * -1
            End If


        Catch ex As Exception
            'MessageBox.Show("ERROR en ObtineFacturasSaldo [ " & ex.Message & " ]")
        End Try
        Return SALDO
    End Function
#End Region

#Region "Conteo fisico"
    Public Function ConsultaInvConteo(ByVal SQL_Comman As SqlCommand)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "Select * from [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].Inve_Conteo T0 ORDER BY T0.[CodProveedor],T0.[ItemCode] ASC"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ConsultaInvConteo [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function ObtieneArticulos(ByVal CardCode As String, ByVal Palabra As String, ByVal VerDesc As Boolean, ColumnaBusqueda As Integer, ByVal SQL_Comman As SqlCommand)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim restriccion As String = ""
            Dim restriccion_Essco As String = ""

            If VerDesc = True Then
                restriccion = " and T0.[ItemName] not like '%Desc%'"
                restriccion_Essco = " and T0.[Descripcion] not like '%Desc%'"
            End If

            'Indica que es llamado desde Manager_Stock para buscar codigos internos de essco
            If CardCode = "" Then
                Consulta = "SELECT [ItemCode],[Descripcion],[NombreExtrangero],[GrupoArticulo],[Ubicacion],[CodCabys],[InactivoDesde],[CodBarras],[Precio],[CodAlterno],[Tarifa] ,[CodProveedor],[Comentarios],[Empaque] ,[RazonInactivo],[UnidMedida],[Largo] ,[Anchos] ,[Volumen] ,[TipoProducto],[ListPreci],[Familia],[Categoria],[Marca] ,[SujetoAImpuesto],[Cod_tarifa] ,[CreadoEnSap],[IdLineaNuevaWms],[Id]"
                If ColumnaBusqueda = 0 Then 'busca por codigo
                    Consulta &= " FROM [" & Class_VariablesGlobales.XMLParamSQL_dababase & "].[dbo].[Articulos] T0 where T0.Descripcion like '%" & Palabra & "%' " & restriccion_Essco
                ElseIf ColumnaBusqueda = 1 Then 'busca por nombre
                    Consulta &= " FROM [" & Class_VariablesGlobales.XMLParamSQL_dababase & "].[dbo].[Articulos] T0 where T0.ItemCode like '%" & Palabra & "%' " & restriccion_Essco
                Else
                    Consulta &= " FROM [" & Class_VariablesGlobales.XMLParamSQL_dababase & "].[dbo].[Articulos] T0 "

                End If
            Else






                If Palabra = "" Then
                    Consulta = "SELECT T0.[ItemCode] as 'Cod Arti',	T0.[ItemName], T0.[frozenFor] as 'Bloqueado',T0.[CodeBars] as 'Cod Bar', T1.[Price] ,T0.[SuppcatNum] as Alterno, SUBSTRING( T0.[U_Impuesto], 4, LEN(T0.[U_Impuesto])-3)  AS IV FROM  " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & ".[dbo].OITM T0  INNER JOIN  " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & ".[dbo].ITM1 T1 ON T0.ItemCode = T1.ItemCode INNER JOIN  " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & ".[dbo].OITB  T2 ON T0.ItmsGrpCod = T2.ItmsGrpCod WHERE T1.[PriceList] = (SELECT  T0.[ListNum] FROM  " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & ".[dbo].OCRD T0  INNER JOIN  " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & ".[dbo].OPLN T1 ON T0.ListNum = T1.ListNum WHERE T0.[CardCode] ='" & CardCode & "') " & restriccion & " ORDER BY T0.[ItemCode] asc"
                Else

                    If ColumnaBusqueda = 0 Then 'busca por codigo
                        Consulta = "SELECT T0.[ItemCode] as 'Cod Arti',	T0.[ItemName], T0.[frozenFor] as 'Bloqueado',T0.[CodeBars] as 'Cod Bar', T1.[Price] ,T0.[SuppcatNum] as Alterno,SUBSTRING( T0.[U_Impuesto], 4, LEN(T0.[U_Impuesto])-3)  AS IV FROM  " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & ".[dbo].OITM T0  INNER JOIN  " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & ".[dbo].ITM1 T1 ON T0.ItemCode = T1.ItemCode INNER JOIN  " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & ".[dbo].OITB  T2 ON T0.ItmsGrpCod = T2.ItmsGrpCod WHERE T1.[PriceList] = (SELECT  T0.[ListNum] FROM  " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & ".[dbo].OCRD T0  INNER JOIN  " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & ".[dbo].OPLN T1 ON T0.ListNum = T1.ListNum WHERE T0.[CardCode] ='" & CardCode & "') and 	T0.[ItemCode] like '%" & Palabra & "%' " & restriccion & " ORDER BY T0.[ItemCode] asc"
                    ElseIf ColumnaBusqueda = 1 Then 'busca por nombre
                        Consulta = "SELECT T0.[ItemCode] as 'Cod Arti',	T0.[ItemName], T0.[frozenFor] as 'Bloqueado',T0.[CodeBars] as 'Cod Bar', T1.[Price] ,T0.[SuppcatNum] as Alterno,SUBSTRING( T0.[U_Impuesto], 4, LEN(T0.[U_Impuesto])-3)  AS IV FROM  " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & ".[dbo].OITM T0  INNER JOIN  " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & ".[dbo].ITM1 T1 ON T0.ItemCode = T1.ItemCode INNER JOIN  " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & ".[dbo].OITB  T2 ON T0.ItmsGrpCod = T2.ItmsGrpCod WHERE T1.[PriceList] = (SELECT  T0.[ListNum] FROM  " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & ".[dbo].OCRD T0  INNER JOIN  " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & ".[dbo].OPLN T1 ON T0.ListNum = T1.ListNum WHERE T0.[CardCode] ='" & CardCode & "') and 	T0.[ItemName] like '%" & Palabra & "%' " & restriccion & " ORDER BY T0.[ItemCode] asc"
                    End If


                End If
            End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneArticulos [ " & ex.Message & " ]")
        End Try
    End Function


    Public Function DeleteLineaDevolucion(ByVal SQL_Comman As SqlCommand, DocNum As String, NumLinea As String)
        Try


            Dim Consulta As String
            Consulta = "DELETE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[DevolucionesDetalle] where [DocNum]='" & DocNum & "' and [NumLinea]='" & NumLinea & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR en DeleteLineaDevolucion [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function AgregaLineaDevolucion(ByVal SQL_Comman As SqlCommand, DocNum As String, ItemCode As String, ItemName As String, Precio As Double, Porc_Imp As Double, Mont_Imp As Double)
        Try

            Dim Consulta As String = ""
            Consulta = "INSERT INTO [dbo].[DevolucionesDetalle]
           ([DocNum]
           ,[ItemCode]
           ,[ItemName]
           ,[Precio]
           ,[Quantity]
           ,[Porc_Desc]
           ,[Motivo]
           ,[Porc_Desc_Fijo]
           ,[Porc_Desc_Promo]
           ,[Porc_Imp]
           ,[Mont_Imp]
           ,[Sub_Total]
           ,[Mont_Desc]
           ,[Total]
           ,[Procesada]
           ,[Comentarios]
           ,[NumLinea])
     VALUES
           ('" & DocNum & "'
           ,'" & ItemCode & "'
           ,'" & ItemName & "'
           ,'" & Precio & "'
           ,'1'
           ,'1'
           ,''
           ,'0'
           ,'0'
           ,'" & Porc_Imp & "'
           ,'" & Mont_Imp & "'  
           ,'0'
           ,'0'
           ,'0'
           ,'0'
           ,''
           ,(SELECT MAX([NumLinea])+1 FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[DevolucionesDetalle] WHERE [DocNum]='" & DocNum & "'))"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            Return 0
        Catch ex As Exception

            MessageBox.Show("ERROR en GuardarLquidacion [ " & ex.Message & " ]")
            Return 1
        End Try
    End Function

#End Region

#Region "LIQUIDACIONES"

    Public Function Aumenta_Consecutivos(ByVal SQL_Comman As SqlCommand, ByVal Consecutivo As Integer, ByVal Tipo As String)
        Try


            Dim cont As Integer = 0
            ' para la conexion al comman 
            'Dim SQL_Comman As New SqlCommand
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""

            'Actualiza el estado dependiendo del numero de aplicacion que sea
            If Tipo = "AGENTES" Then
                Consulta = "UPDATE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Consecutivos_Liquidaciones] SET [ConseLiqAgentes] = '" & Consecutivo & "'"
            ElseIf Tipo = "CHOFERES" Then
                Consulta = "UPDATE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Consecutivos_Liquidaciones] SET [ConseLiqChoferes] = '" & Consecutivo & "'"
            ElseIf Tipo = "OFICINA" Then
                Consulta = "UPDATE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Consecutivos_Liquidaciones] SET [ConseDepositos] = '" & Consecutivo & "'"
            End If

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

        Catch ex As Exception
            MessageBox.Show("ERROR en Actualiza_InfoNOARCHIVO_FTP [ " & ex.Message & " ]")
        End Try
        Return 0
    End Function
    Public Function ObtieneSaldoCuenta(ByVal SQL_Comman As SqlCommand, ByVal CardCode As String, ByVal Tipo As String)
        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Balance As Integer
            If Tipo = "Interno" Then
                Consulta = "Select T0.Saldo as Balance FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[ClientesModificados] T0 WHERE T0.[CardCode] ='" & CardCode & "'"
            Else
                Consulta = "Select T0.Balance FROM " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & ".[dbo].OCRD T0 WHERE T0.[CardCode] ='" & CardCode & "'"
            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Balance = CInt(TABLA.Rows(0).Item("Balance").ToString())

            Return Balance

        Catch ex As Exception
            Return 0
            'MessageBox.Show("ERROR en ObtieneSaldoCuenta [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function ObtieneConsecutivo(ByVal SQL_Comman As SqlCommand, ByVal Liquidacion As String)
        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim CONSECUTIVO As Integer
            If Liquidacion = "AGENTES" Then
                Consulta = "SELECT [ConseLiqAgentes] FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Consecutivos_Liquidaciones] T0 "
                ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
                ADATER.Fill(TABLA)
                CONSECUTIVO = CInt(TABLA.Rows(0).Item("ConseLiqAgentes").ToString())

            ElseIf Liquidacion = "CHOFERES" Then
                Consulta = "SELECT [ConseLiqChoferes] FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Consecutivos_Liquidaciones] T0 "
                ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
                ADATER.Fill(TABLA)
                CONSECUTIVO = CInt(TABLA.Rows(0).Item("ConseLiqChoferes").ToString())
            ElseIf Liquidacion = "OFICINA" Then
                Consulta = "SELECT [ConseDepositos] FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Consecutivos_Liquidaciones] T0 "
                ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
                ADATER.Fill(TABLA)
                CONSECUTIVO = CInt(TABLA.Rows(0).Item("ConseDepositos").ToString())

            End If


            Return CONSECUTIVO
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneConsecutivo [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ObtieneLiqSegunDeposito(ByVal SQL_Comman As SqlCommand, ByVal DPCONSECUTIVO As String)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""

            Consulta = "SELECT [DPLIQUIDACION]  FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Depositos] WHERE  [DPCONSECUTIVO] = '" & DPCONSECUTIVO & "'"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            Return 2
            'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function



#Region "LIQ AGENTES"
    Public Function ObtieneLiquidaciones(ByVal SQL_Comman As SqlCommand, ByVal Tipo As String, ByVal Desde As String, ByVal Hasta As String, ByVal NumLiq As String)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""
            If NumLiq <> "" Then
                Consulta = "SELECT [Cosecutivo],[Fecha],[CodAgente],[CedulaAgente],[NombreAgente],[FechaINI],[FechaFIN],[Comentarios],[Tipo],[Anulada] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Liquidaciones] where [Tipo]='" & Tipo & "' and  [Cosecutivo] like '%" & NumLiq & "%' ORDER BY [Cosecutivo] DESC "
            ElseIf Desde <> "" Or Hasta <> "" And NumLiq = "" Then
                Consulta = "SELECT [Cosecutivo],[Fecha],[CodAgente],[CedulaAgente],[NombreAgente],[FechaINI],[FechaFIN],[Comentarios],[Tipo],[Anulada] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Liquidaciones] where [Tipo]='" & Tipo & "' and [Fecha] between CONVERT(DATETIME, '" & Desde & " 00:00:00', 102) and  CONVERT(DATETIME, '" & Hasta & " 00:00:00', 102)   ORDER BY [Cosecutivo] DESC "
            Else

                Consulta = "SELECT [Cosecutivo],[Fecha],[CodAgente],[CedulaAgente],[NombreAgente],[FechaINI],[FechaFIN],[Comentarios],[Tipo],[Anulada] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Liquidaciones] where [Tipo]='" & Tipo & "' ORDER BY [Cosecutivo] DESC "
            End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            Return 2
            'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function
    Public Function GuardarLiquidacion(ByVal SQL_Comman As SqlCommand, ByVal Cosecutivo As String, ByVal Fecha As String, ByVal CodAgente As String, ByVal CedulaAgente As String, ByVal NombreAgente As String, ByVal FechaINI As String, ByVal FechaFIN As String, ByVal Comentarios As String, ByVal Tipo As String, ByVal Resultado As String, ByVal Ruta As String)
        Try

            Dim Consulta As String = ""
            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Liquidaciones]([Cosecutivo],[Fecha],[CodAgente],[CedulaAgente],[NombreAgente],[FechaINI],[FechaFIN],[Comentarios],[Tipo],[Resultado],[Anulada],[Ruta])VALUES('" & Cosecutivo & "','" & Fecha & "','" & CodAgente & "','" & CedulaAgente & "','" & NombreAgente & "','" & FechaINI & "','" & FechaFIN & "','" & Comentarios & "','" & Tipo & "'," & CDbl(Resultado) & ",'0','" & Ruta & "')"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            Return 0
        Catch ex As Exception

            MessageBox.Show("ERROR en GuardarLquidacion [ " & ex.Message & " ]")
            Return 1
        End Try

    End Function
    Public Function ModificaLiquidacion(ByVal SQL_Comman As SqlCommand, ByVal Cosecutivo As String, ByVal Fecha As String, ByVal CodAgente As String, ByVal CedulaAgente As String, ByVal NombreAgente As String, ByVal FechaINI As String, ByVal FechaFIN As String, ByVal Comentarios As String, ByVal Tipo As String, ByVal Resultado As String)
        Try


            Dim cont As Integer = 0
            Dim Consulta As String
            Consulta = ""

            'Actualiza el estado dependiendo del numero de aplicacion que sea


            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Liquidaciones] SET [FechaActualizacion] = '" & Fecha & "' ,[CodAgente] = '" & CodAgente & "' ,[CedulaAgente] = '" & CedulaAgente & "',[NombreAgente] = '" & NombreAgente & "' ,[FechaINI] = '" & FechaINI & "' ,[FechaFIN] = '" & FechaFIN & "' ,[Comentarios] = '" & Comentarios & "'  ,[Tipo] = '" & Tipo & "',[Resultado] = '" & CDbl(Resultado) & "' WHERE [Cosecutivo] = '" & Cosecutivo & "'"


            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

        Catch ex As Exception
            MessageBox.Show("ERROR en ModificaLiquidacion [ " & ex.Message & " ]")
        End Try
        Return 0
    End Function
    Public Function AnulaLiquidacion(ByVal SQL_Comman As SqlCommand, ByVal Cosecutivo As String, ByVal Tipo As String)
        Try

            Dim Consulta As String
            Consulta = ""

            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Liquidaciones] SET [Anulada] = '1' WHERE [Cosecutivo] = '" & Cosecutivo & "' and [Tipo] = '" & Tipo & "'"


            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

        Catch ex As Exception
            MessageBox.Show("ERROR en AnulaLiquidacion [ " & ex.Message & " ]")
        End Try
        Return 0
    End Function
#End Region

#Region "LIQ CHOFERES"
    Public Function ObtieneLiquidaciones_Choferes(ByVal SQL_Comman As SqlCommand, ByVal Tipo As String, ByVal Desde As String, ByVal Hasta As String, ByVal NumLiq As String)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""
            If NumLiq <> "" Then
                Consulta = "SELECT [Cosecutivo],[Fecha],[CodAgente],[CedulaAgente],[NombreAgente],[FechaINI],[FechaFIN],[Comentarios],[Tipo],[Anulada],[Agentes],[Ruta],[FechaINI_Recibos],[FechaFIN_Recibos],[CodRepFacturas]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Liquidaciones_Choferes] where [Tipo]='" & Tipo & "' and  [Cosecutivo] like '%" & NumLiq & "%' ORDER BY [Cosecutivo] DESC "
            ElseIf Desde <> "" Or Hasta <> "" And NumLiq = "" Then
                Consulta = "SELECT [Cosecutivo],[Fecha],[CodAgente],[CedulaAgente],[NombreAgente],[FechaINI],[FechaFIN],[Comentarios],[Tipo],[Anulada],[Agentes],[Ruta],[FechaINI_Recibos],[FechaFIN_Recibos],[CodRepFacturas] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Liquidaciones_Choferes] where [Tipo]='" & Tipo & "' and [Fecha] between CONVERT(DATETIME, '" & Desde & " 00:00:00', 102) and  CONVERT(DATETIME, '" & Hasta & " 00:00:00', 102)   ORDER BY [Cosecutivo] DESC "
            Else

                Consulta = "SELECT [Cosecutivo],[Fecha],[CodAgente],[CedulaAgente],[NombreAgente],[FechaINI],[FechaFIN],[Comentarios],[Tipo],[Anulada],[Agentes],[Ruta],[FechaINI_Recibos],[FechaFIN_Recibos],[CodRepFacturas] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Liquidaciones_Choferes] where [Tipo]='" & Tipo & "' ORDER BY [Cosecutivo] DESC "
            End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            Return 2
            'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function
    Public Function GuardarLiquidacion_Choferes(ByVal SQL_Comman As SqlCommand, ByVal Cosecutivo As String, ByVal Fecha As String, ByVal CodAgente As String, ByVal CedulaAgente As String, ByVal NombreAgente As String, ByVal FechaINI As String, ByVal FechaFIN As String, ByVal Comentarios As String, ByVal Tipo As String, ByVal Resultado As String, ByVal Ruta As String, ByVal ListaAgenteas As String, ByVal FechaINI_Recibos As String, ByVal FechaFIN_Recibos As String, ByVal CodRepFacturas As String)
        Try

            Dim Consulta As String = ""
            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Liquidaciones_Choferes]([Cosecutivo],[Fecha],[CodAgente],[CedulaAgente],[NombreAgente],[FechaINI],[FechaFIN],[Comentarios],[Tipo],[Resultado],[Anulada],[Ruta],[Agentes],[FechaINI_Recibos],[FechaFIN_Recibos],[CodRepFacturas])VALUES('" & Cosecutivo & "','" & Fecha & "','" & CodAgente & "','" & CedulaAgente & "','" & NombreAgente & "','" & FechaINI & "','" & FechaFIN & "','" & Comentarios & "','" & Tipo & "'," & CDbl(Resultado) & ",'0','" & Ruta & "','" & ListaAgenteas & "','" & FechaINI_Recibos & "','" & FechaFIN_Recibos & "','" & CodRepFacturas & "')"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            Return 0
        Catch ex As Exception

            MessageBox.Show("ERROR en GuardarLquidacion_Choferes [ " & ex.Message & " ]")
            Return 1
        End Try

    End Function
    Public Function ModificaLiquidacion_Choferes(ByVal SQL_Comman As SqlCommand, ByVal Cosecutivo As String, ByVal Fecha As String, ByVal CodAgente As String, ByVal CedulaAgente As String, ByVal NombreAgente As String, ByVal FechaINI As String, ByVal FechaFIN As String, ByVal Comentarios As String, ByVal Tipo As String, ByVal Resultado As String, ByVal ListaAgenteas As String, ByVal Ruta As String, ByVal CodRepFacturas As String, ByVal FechaINI_Recibos As String, ByVal FechaFIN_Recibos As String)
        Try


            Dim cont As Integer = 0
            Dim Consulta As String
            Consulta = ""

            'Actualiza el estado dependiendo del numero de aplicacion que sea


            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Liquidaciones_Choferes] SET [FechaActualizacion] = '" & Fecha & "' ,[CodAgente] = '" & CodAgente & "' ,[CedulaAgente] = '" & CedulaAgente & "',[NombreAgente] = '" & NombreAgente & "' ,[FechaINI] = '" & FechaINI & "' ,[FechaFIN] = '" & FechaFIN & "' ,[Comentarios] = '" & Comentarios & "'  ,[Tipo] = '" & Tipo & "',[Resultado] = '" & CDbl(Resultado) & "' ,[Agentes] = '" & ListaAgenteas & "',[Ruta] = '" & Ruta & "',[CodRepFacturas]='" & CodRepFacturas & "',[FechaINI_Recibos]='" & FechaINI_Recibos & "',[FechaFIN_Recibos]='" & FechaFIN_Recibos & "' WHERE [Cosecutivo] = '" & Cosecutivo & "'"


            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

        Catch ex As Exception
            MessageBox.Show("ERROR en ModificaLiquidacion_Choferes [ " & ex.Message & " ]")
        End Try
        Return 0
    End Function
    Public Function AnulaLiquidacion_Choferes(ByVal SQL_Comman As SqlCommand, ByVal Cosecutivo As String, ByVal Tipo As String)
        Try


            Dim Consulta As String
            Consulta = ""

            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Liquidaciones_Choferes] SET [Anulada] = '1' WHERE [Cosecutivo] = '" & Cosecutivo & "' and [Tipo] = '" & Tipo & "'"


            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

        Catch ex As Exception
            MessageBox.Show("ERROR en AnulaLiquidacion_Choferes [ " & ex.Message & " ]")
        End Try
        Return 0
    End Function


    Public Function ReciboConLiquidacion(ByVal NumRecibo As String, ByVal SQL_Comman As SqlCommand)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""
            Dim NumLiq As String = ""
            Dim Cobrador As String = ""
            Dim Fecha As String = ""
            Dim Mensaje As String = ""
            Consulta = "SELECT T0.[U_NumLiquidacion] ,T0.[U_BP_COBRADOR],T0.[DocDate] FROM [BD_Bourne].[dbo].ORCT T0 WHERE T0.[DocNum] ='" & NumRecibo & "'"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            If TABLA.Rows.Count > 0 Then

                For Each row As DataRow In TABLA.Rows
                    NumLiq = TABLA.Rows(0).Item("U_NumLiquidacion").ToString()
                    Cobrador = TABLA.Rows(0).Item("U_BP_COBRADOR").ToString()
                    Fecha = TABLA.Rows(0).Item("DocDate").ToString()
                Next
                If Cobrador <> "01" Then
                    Mensaje = "EL RECIBO ESTA VINCULADO A LA LIQUIDACION [ " & NumLiq & " ] CON EL COBRADOR [ " & Cobrador & " ] " & vbLf & _
                         " REALMENTE DESEA AGREGAR EL RECIBO A LA LIQUIDACION ?"
                Else
                    Mensaje = Fecha
                End If
               
            End If
            Return Mensaje
        Catch ex As Exception
            Return 2
            'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function


#End Region



#Region "GASTOS LIQUIDACIONES"

    Public Function ObtieneConsecutivoGasto(ByVal SQL_Comman As SqlCommand)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Consecutivo As String

            Consulta = "SELECT [Conse_Gastos] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Agentes]  where [CodAgente]='1'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            If TABLA.Rows(0).Item("Conse_Gastos").ToString = "" Then
                Consecutivo = "0"
            Else
                Consecutivo = Trim(TABLA.Rows(0).Item("Conse_Gastos"))
            End If
            Return Consecutivo

        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneConsecutivoGasto [ " & ex.Message & " ]")
        End Try
    End Function




    Public Function ObtieneGastosChoferes(ByVal SQL_Comman As SqlCommand, ByVal NumLiquidacion As String, ByVal TipoLiquidacion As String, ByVal TituloGasto As String, ByVal AgenteGasto As String, ByVal FIni As String, ByVal FFin As String, ByVal NumGastos As String, ByVal ConseGastos As String, ByVal VerAnulados As Boolean, ByVal VerIncluidosEnLiquidacion As Boolean)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim IncluirAnd As Boolean = False 'controla la incrustacion del AND para los filtros


            Consulta = Consulta & "Select [DocNum],[Tipo] ,[NumDoc] ,[Monto] ,[Descripcion] ,[ConseLiqui],[TipoLiqui],[FechaGasto],[CodAgente],[Anulado],[EsFE],[Codigo],(Select T0.[CardName] FROM [BD_BOURNE].[dbo].OCRD T0 WHERE T0.[CardCode] =[Codigo] COLLATE Modern_Spanish_CI_AS ) as Nombre,( Select T0.[LicTradNum] FROM [BD_BOURNE].[dbo].OCRD T0 WHERE T0.[CardCode] =[Codigo] COLLATE Modern_Spanish_CI_AS ) as Cedula,(Select T0.[E_Mail] FROM [BD_BOURNE].[dbo].OCRD T0 WHERE T0.[CardCode] =[Codigo] COLLATE Modern_Spanish_CI_AS ) as Correo,EstadoMH FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[GastosLiquidaciones] where  "

            If NumLiquidacion <> "" Then
                IncluirAnd = True
                Consulta = Consulta & "[ConseLiqui]='" & NumLiquidacion & "' "
            End If

            If AgenteGasto <> "" Then
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                     Consulta =  Consulta & " and "
                End If

                Consulta = Consulta & "[CodAgente]='" & AgenteGasto & "'  "
            End If

            If FIni <> "" And FFin <> "" Then
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If
                Consulta = Consulta & "Fecha BETWEEN CONVERT(DATETIME, '" & FIni & " 00:00:00', 102)  AND CONVERT(DATETIME, '" & FFin & " 00:00:00', 102)   "
            End If

            If NumGastos <> "" Then
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If
                Consulta = Consulta & "[NumDoc] like '%" + NumGastos + "%'   "
            End If

            If VerAnulados = True Then

            Else
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If
                Consulta = Consulta & "Anulado ='0'  "
            End If
            If VerIncluidosEnLiquidacion = True Then
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If
                Consulta = Consulta & "IncluirEnLiquidacion ='true'  "
            Else
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If
                Consulta = Consulta & "IncluirEnLiquidacion ='false'  "
            End If

            If TituloGasto <> "" Then
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If
                Consulta = Consulta & "[Tipo]='" & TituloGasto & "'  "
            End If

            If ConseGastos <> "" Then
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If
                Consulta = Consulta & "[DocNum] like '%" + ConseGastos + "%'  "
            End If

            If IncluirAnd = False Then
                IncluirAnd = True
            Else
                Consulta = Consulta & " and "
            End If
            Consulta = Consulta & "[TipoLiqui]='" & TipoLiquidacion & "' order by [DocNum] asc"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneGastos [ " & ex.Message & " ]")
        End Try
    End Function

    'ByVal SQL_Comman As SqlCommand, ByVal NumLiquidacion As String, ByVal TipoLiquidacion As String, ByVal TituloGasto As String, ByVal AgenteGasto As String, ByVal FIni As String, ByVal FFin As String, ByVal NumGastos As String, ByVal ConseGastos As String, ByVal VerAnulados As Boolean)
    Public Function ObtieneGastosAgentes(ByVal SQL_Comman As SqlCommand, ByVal TipoLiquidacion As String, ByVal TituloGasto As String, ByVal AgenteGasto As String, ByVal FIni As String, ByVal FFin As String, ByVal NumGastos As String, ByVal ConseGastos As String, ByVal VerAnulados As Boolean, ByVal VerIncluidosEnLiquidacion As Boolean)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim IncluirAnd As Boolean = False 'controla la incrustacion del AND para los filtros


            Consulta = Consulta & "Select [DocNum],[Tipo] ,[NumDoc] ,[Monto] ,[Descripcion] ,[ConseLiqui],[TipoLiqui],[FechaGasto],[CodAgente],[Anulado],[EsFE],[Codigo],(Select T0.[CardName] FROM [BD_BOURNE].[dbo].OCRD T0 WHERE T0.[CardCode] =[Codigo] COLLATE Modern_Spanish_CI_AS ) as Nombre,( Select T0.[LicTradNum] FROM [BD_BOURNE].[dbo].OCRD T0 WHERE T0.[CardCode] =[Codigo] COLLATE Modern_Spanish_CI_AS ) as Cedula,(Select T0.[E_Mail] FROM [BD_BOURNE].[dbo].OCRD T0 WHERE T0.[CardCode] =[Codigo] COLLATE Modern_Spanish_CI_AS ) as Correo,EstadoMH FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[GastosLiquidaciones] where  "

            If AgenteGasto <> "" Then
                IncluirAnd = True
                Consulta = Consulta & "[CodAgente]='" & AgenteGasto & "' "
            End If

            If FIni <> "" And FFin <> "" Then
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If
                Consulta = Consulta & "Fecha BETWEEN CONVERT(DATETIME, '" & FIni & " 00:00:00', 102)  AND CONVERT(DATETIME, '" & FFin & " 00:00:00', 102)   "
            End If

            If NumGastos <> "" Then
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If
                Consulta = Consulta & "[NumDoc] like '%" + NumGastos + "%'   "
            End If

            If VerAnulados = True Then
                'If IncluirAnd = False Then
                '    IncluirAnd = True
                'Else
                '    Consulta = Consulta & " and "
                'End If
                'Consulta = Consulta & "Anulado ='1'  "
            Else
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If
                Consulta = Consulta & "Anulado ='0'  "
            End If
            If VerIncluidosEnLiquidacion = True Then
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If
                Consulta = Consulta & "IncluirEnLiquidacion ='true'  "
            Else
                If IncluirAnd = False Then
                IncluirAnd = True
            Else
                Consulta = Consulta & " and "
            End If
            Consulta = Consulta & "IncluirEnLiquidacion ='false'  "
            End If
            If TituloGasto <> "" Then
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If
                Consulta = Consulta & "[Tipo]='" & TituloGasto & "'  "
            End If

            If ConseGastos <> "" Then
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If
                Consulta = Consulta & "[DocNum] like '%" + ConseGastos + "%'  "
            End If

            If IncluirAnd = False Then
                IncluirAnd = True
            Else
                Consulta = Consulta & " and "
            End If
            Consulta = Consulta & "[TipoLiqui]='" & TipoLiquidacion & "' order by [DocNum] asc"





            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneGastos [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function ObtieneTotalGastosAgentes(ByVal SQL_Comman As SqlCommand, ByVal TipoLiquidacion As String, ByVal TituloGasto As String, ByVal AgenteGasto As String, ByVal FechaIni As String, ByVal FechaFin As String, ByVal VerAnulados As Boolean, ByVal TotalGastos As Boolean)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Monto As String

            If VerAnulados = True Then
                If TotalGastos = True Then
                    Consulta = "Select SUM([Monto])AS Monto FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[GastosLiquidaciones] WHERE [TipoLiqui]='" & TipoLiquidacion & "'  AND   [CodAgente]='" & AgenteGasto & "' and Fecha BETWEEN CONVERT(DATETIME, '" & FechaIni & " 00:00:00', 102)  AND CONVERT(DATETIME, '" & FechaFin & " 00:00:00', 102) and IncluirEnLiquidacion='true'"
                Else
                    Consulta = "Select SUM([Monto])AS Monto FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[GastosLiquidaciones] WHERE [TipoLiqui]='" & TipoLiquidacion & "'  AND [Tipo]='" & TituloGasto & "' AND [CodAgente]='" & AgenteGasto & "' and Fecha BETWEEN CONVERT(DATETIME, '" & FechaIni & " 00:00:00', 102)  AND CONVERT(DATETIME, '" & FechaFin & " 00:00:00', 102) and IncluirEnLiquidacion='true'"
                End If

            Else
                If TotalGastos = True Then
                    Consulta = "Select SUM([Monto])AS Monto FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[GastosLiquidaciones] WHERE [TipoLiqui]='" & TipoLiquidacion & "'  AND [CodAgente]='" & AgenteGasto & "' and Fecha BETWEEN CONVERT(DATETIME, '" & FechaIni & " 00:00:00', 102)  AND CONVERT(DATETIME, '" & FechaFin & " 00:00:00', 102) and Anulado ='0' and IncluirEnLiquidacion='true'"
                Else
                    Consulta = "Select SUM([Monto])AS Monto FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[GastosLiquidaciones] WHERE [TipoLiqui]='" & TipoLiquidacion & "'  AND [Tipo]='" & TituloGasto & "' AND [CodAgente]='" & AgenteGasto & "' and Fecha BETWEEN CONVERT(DATETIME, '" & FechaIni & " 00:00:00', 102)  AND CONVERT(DATETIME, '" & FechaFin & " 00:00:00', 102) and Anulado ='0' and IncluirEnLiquidacion='true'"
                End If

            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            If TABLA.Rows(0).Item("Monto").ToString = "" Then
                Monto = "0"
            Else
                Monto = TABLA.Rows(0).Item("Monto")
            End If
            Return Monto
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneTotalGastosAgentes [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function ObtieneTotalGastosChoferes(ByVal SQL_Comman As SqlCommand, ByVal NumLiquidacion As String, ByVal TipoLiquidacion As String, ByVal TituloGasto As String, ByVal AgenteGasto As String, ByVal FechaIni As String, ByVal FechaFin As String, ByVal VerAnulados As Boolean, ByVal TotalGastos As Boolean, ByVal VerIncluidosEnLiquidacion As Boolean)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Monto As String

            If VerAnulados = True Then
                If TotalGastos = True Then
                    Consulta = "Select SUM([Monto])AS Monto FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[GastosLiquidaciones] WHERE [TipoLiqui]='" & TipoLiquidacion & "'  AND [CodAgente]='" & AgenteGasto & "' and Fecha BETWEEN CONVERT(DATETIME, '" & FechaIni & " 00:00:00', 102)  AND CONVERT(DATETIME, '" & FechaFin & " 00:00:00', 102) and IncluirEnLiquidacion='" & VerIncluidosEnLiquidacion & "' "
                Else
                    Consulta = "Select SUM([Monto])AS Monto FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[GastosLiquidaciones] WHERE [TipoLiqui]='" & TipoLiquidacion & "'  AND [Tipo]='" & TituloGasto & "' AND [CodAgente]='" & AgenteGasto & "' and Fecha BETWEEN CONVERT(DATETIME, '" & FechaIni & " 00:00:00', 102)  AND CONVERT(DATETIME, '" & FechaFin & " 00:00:00', 102) and IncluirEnLiquidacion='" & VerIncluidosEnLiquidacion & "'"
                End If

            Else
                If TotalGastos = True Then
                    Consulta = "Select SUM([Monto])AS Monto FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[GastosLiquidaciones] WHERE [TipoLiqui]='" & TipoLiquidacion & "'  AND [CodAgente]='" & AgenteGasto & "' and Fecha BETWEEN CONVERT(DATETIME, '" & FechaIni & " 00:00:00', 102)  AND CONVERT(DATETIME, '" & FechaFin & " 00:00:00', 102) and Anulado ='0' and IncluirEnLiquidacion=''" & VerIncluidosEnLiquidacion & "'"
                Else
                    Consulta = "Select SUM([Monto])AS Monto FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[GastosLiquidaciones] WHERE [TipoLiqui]='" & TipoLiquidacion & "'  AND [Tipo]='" & TituloGasto & "' AND [CodAgente]='" & AgenteGasto & "' and Fecha BETWEEN CONVERT(DATETIME, '" & FechaIni & " 00:00:00', 102)  AND CONVERT(DATETIME, '" & FechaFin & " 00:00:00', 102) and Anulado ='0' and IncluirEnLiquidacion='" & VerIncluidosEnLiquidacion & "'"
                End If

            End If





            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            If TABLA.Rows(0).Item("Monto").ToString = "" Then
                Monto = "0"
            Else
                Monto = TABLA.Rows(0).Item("Monto")
            End If
            Return Monto
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneInventario [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ObtieneListaGastos(ByVal SQL_Comman As SqlCommand, ByVal NumLiquidacion As String, ByVal TipoLiquidacion As String, ByVal AgenteGasto As String, ByVal FechaIni As String, ByVal FechaFin As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Monto As String
            'Trae EsFE para saber si el gasto es respaldado por una FE y si no lo es obiene el Codigo del proveedor para generar la FEC
            Consulta = "Select [DocNum],[EsFE],[Codigo],[FEC_Creada] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[GastosLiquidaciones] WHERE [TipoLiqui]='" & TipoLiquidacion & "'  AND [CodAgente]='" & AgenteGasto & "' and Fecha BETWEEN CONVERT(DATETIME, '" & FechaIni & " 00:00:00', 102)  AND CONVERT(DATETIME, '" & FechaFin & " 00:00:00', 102)"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneListaGastos [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function InsertaGasto(ByVal SQL_Comman As SqlCommand, ByVal txb_NumDoc As String, ByVal txb_Monto As String, ByVal txb_Descripcion As String, ByVal Tipo As String, ByVal ConseLiqui As String, ByVal TipoLiqui As String, ByVal CodAgente As String, ByVal Fecha As String, ByVal DocNum As String, ByVal FechaGasto As String, ByVal EsFE As String, ByVal Codigo As String, IncluirEnLiquidacion As String)
        Try

            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[GastosLiquidaciones] ([Tipo],[NumDoc],[Monto],[Descripcion],[ConseLiqui],[TipoLiqui],[CodAgente],[Fecha],[DocNum],[FechaGasto],[EsFE],[Codigo],[FEC_Creada],[CreateTS],[IncluirEnLiquidacion] ) VALUES('" & Tipo & "','" & txb_NumDoc & "','" & txb_Monto & "','" & txb_Descripcion & "','" & ConseLiqui & "','" & TipoLiqui & "','" & CodAgente & "','" & Fecha & "','" & DocNum & "','" & FechaGasto & "','" & EsFE & "','" & Codigo & "','0','" & Now.TimeOfDay.ToString().Replace(":", "").Replace(".", "").Substring(0, 6) & "','" & IncluirEnLiquidacion & "')"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing

            Return False
        Catch ex As Exception
            MessageBox.Show("ERROR en InsertaGasto [ " & ex.Message & " ]")
            Return True
        End Try

    End Function

    Public Function ReeEnviaGastosMH(ByVal SQL_Comman As SqlCommand, ByVal txb_NumDoc As String, ByVal txb_Monto As String, ByVal txb_Descripcion As String, ByVal Tipo As String, ByVal ConseLiqui As String, ByVal TipoLiqui As String, ByVal CodAgente As String, ByVal Fecha As String, ByVal DocNum As String, ByVal FechaGasto As String, ByVal EsFE As String, ByVal Codigo As String, IncluirEnLiquidacion As String)

        Try




            InsertaGasto(SQL_Comman, txb_NumDoc, txb_Monto, txb_Descripcion, Tipo, ConseLiqui, TipoLiqui, CodAgente, Fecha, DocNum, FechaGasto, EsFE, Codigo, IncluirEnLiquidacion)


        Catch ex As Exception

        End Try
    End Function

    Public Function Inserta_Banco(ByVal SQL_Comman As SqlCommand, Codigo As String, Nombre As String, Cuenta As String)
        Try

            Dim Consulta As String

            Consulta = ""
            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[BancosEssco] ([Codigo],[Nombre],[Cuenta] ) VALUES('" & Codigo & "','" & Nombre & "','" & Cuenta & "')"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing

            Return False
        Catch ex As Exception
            MessageBox.Show("ERROR en Inserta_Banco [ " & ex.Message & " ]")
            Return True
        End Try

    End Function
    Public Function ObtieneBancosEssco(ByVal SQL_Comman As SqlCommand)

        Try
            Dim Consulta As String
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim nulo As String
            Consulta = "select Codigo as BankCode,Nombre as BankName  from [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[BancosEssco] ORDER BY ID DESC"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            SQL_Comman = Nothing



            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en VerificaGastoLiqAge_Anulado [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function EliminaBancosEssco(ByVal SQL_Comman As SqlCommand, Codigo As String)

        Try

            Dim Consulta As String
            Consulta = ""
            Consulta = "DELETE FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[BancosEssco] where Codigo='" & Codigo & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing

        Catch ex As Exception

        End Try
    End Function
    Public Function ObtieneUltimoRegistroComprobanteENHACIENDA(ByVal SQL_Comman As SqlCommand)

        Try
            Dim Consulta As String
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim nulo As String
            Dim ID As String
            Consulta = "select MAX(ID) as ID from [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos_ENHACIENDA] ORDER BY ID DESC"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            If TABLA.Rows(0).Item("ID").ToString = "" Then
                ID = "0"
            Else
                ID = TABLA.Rows(0).Item("ID")
            End If

            SQL_Comman = Nothing



            Return ID
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneUltimoRegistroComprobanteENHACIENDA [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ComprobanteENHACIENDA(ByVal SQL_Comman As SqlCommand)

        Try
            Dim Consulta As String
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim nulo As String
            Consulta = "select * from [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos_ENHACIENDA] ORDER BY ID DESC"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            SQL_Comman = Nothing



            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en VerificaGastoLiqAge_Anulado [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function Math_ENHACIENDA(ByVal SQL_Comman As SqlCommand, FechaINI As String, FechaFIN As String, Ver As String)

        Try
            Dim Consulta As String
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim nulo As String

            If Ver = "Todos" Then
                Consulta = "select T0.[#Documento],T0.[Fecha],T0.[Tipo_Documento],SUM(T0.Total) as total from [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].Match_SAP_HACIENDA('" & FechaINI & "','" & FechaFIN & "') T0  group by T0.[#Documento],T0.[Fecha],T0.[Tipo_Documento] order by T0.fecha desc"
            Else
                Consulta = "select T0.[#Documento],T0.[Fecha],T0.[Tipo_Documento],SUM(T0.Total) as total from [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].Match_SAP_HACIENDA('" & FechaINI & "','" & FechaFIN & "') T0 where T0.EN_HACIENDA IS NULL group by T0.[#Documento],T0.[Fecha],T0.[Tipo_Documento] order by T0.fecha desc"
            End If



            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            SQL_Comman = Nothing



            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en Math_ENHACIENDA [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ActualizaGasto(ByVal SQL_Comman As SqlCommand, ByVal txb_NumDoc As String, ByVal txb_Monto As String, ByVal txb_Descripcion As String, ByVal Tipo As String, ByVal ConseLiqui As String, ByVal TipoLiqui As String, ByVal CodAgente As String, ByVal Fecha As String, ByVal DocNum As String, IncluirEnLiquidacion As String, ByVal GuardandoLiq As Boolean)
        Try



            Dim cont As Integer = 0
            Dim Consulta As String
            Consulta = ""

            If GuardandoLiq = False Then
                'Cuando el gasto es transmitido por el agente el [FEC_Creada] es 0,cuando se guardada la liquidacion se coloca 1 para autorizar crear la FEC cuando se cree en FEC el estado cambia a 2 para indicar que fue creada la FEC
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[GastosLiquidaciones] SET  [ConseLiqui] = '" & ConseLiqui & "', [CodAgente]='" & CodAgente & "',[NumDoc] = '" & txb_NumDoc & "', [Fecha] = '" & Fecha & "' ,[Monto] = '" & txb_Monto & "',[Descripcion] = '" & txb_Descripcion & "',[Tipo]='" & Tipo & "',[TipoLiqui]='" & TipoLiqui & "',[FEC_Creada]='1' ,[CreateTS]='" & Now.TimeOfDay.ToString().Replace(":", "").Replace(".", "").Substring(0, 6) & "'  ,[IncluirEnLiquidacion]='" & IncluirEnLiquidacion & "' WHERE    DocNum='" & DocNum & "'"
            Else
                'Modificando la liquidacion
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[GastosLiquidaciones] SET [ConseLiqui] = '" & ConseLiqui & "',[TipoLiqui]='" & TipoLiqui & "' ,[FEC_Creada]='1' WHERE    DocNum='" & DocNum & "'"
            End If

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            Return 0
        Catch ex As Exception
            MessageBox.Show("ERROR en ActualizaGasto [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function AnulaGastoLiqAge(ByVal SQL_Comman As SqlCommand, ByVal DocNum As String)

        Try
            Dim Consulta As String
            Consulta = ""
            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[GastosLiquidaciones]   SET Anulado ='1',ConseLiqui ='0' WHERE DocNum='" & DocNum & "' "
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en EliminaGastoLiqAge [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function VerificaGastoLiqAge_Anulado(ByVal SQL_Comman As SqlCommand, ByVal DocNum As String)

        Try
            Dim Consulta As String
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim nulo As String
            Consulta = "select Anulado from [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[GastosLiquidaciones] WHERE DocNum='" & DocNum & "' "
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            SQL_Comman = Nothing
            If TABLA.Rows.Count > 0 Then
                nulo = TABLA.Rows(0).Item("Anulado")
            Else
                nulo = "0"
            End If


            Return nulo
        Catch ex As Exception
            MessageBox.Show("ERROR en VerificaGastoLiqAge_Anulado [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ConsultaEstadoDeFEC(ByVal SQL_Comman As SqlCommand, ByVal DocNum As String)

        Try
            Dim Consulta As String
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Estado As String
            Consulta = "select EstadoMH from [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[GastosLiquidaciones] WHERE DocNum='" & DocNum & "' "
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            SQL_Comman = Nothing
            If TABLA.Rows.Count > 0 Then
                Estado = TABLA.Rows(0).Item("EstadoMH")

            End If


            Return Estado
        Catch ex As Exception
            MessageBox.Show("ERROR en ConsultaEstadoDeFEC [ " & ex.Message & " ]")
        End Try
    End Function
#End Region

#Region "Depositos"




    Public Function VerificaAnulado(ByVal SQL_Comman As SqlCommand, ByVal NumDepo As String)
        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim CONSECUTIVO As Integer = 0

            Consulta = "SELECT [DP_ANULADO] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] T0 where [DPCONSECUTIVO]= '" & NumDepo & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            If TABLA.Rows.Count > 0 Then


                If TABLA.Rows(0).Item("DP_ANULADO").ToString() <> "" Then
                    Return CInt(TABLA.Rows(0).Item("DP_ANULADO").ToString())

                Else
                    Return 0

                End If
            Else
                Return 0

            End If


        Catch ex As Exception
            MessageBox.Show("ERROR en VerificaAnulado [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function VerificaDeposito(ByVal SQL_Comman As SqlCommand, ByVal NumDepo As String)
        Try
            Dim RETORNO As String
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Monto As String

            Consulta = "SELECT  [DPLIQUIDACION] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] WHERE [DPCODIGO]='" & NumDepo & "'"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            If TABLA.Rows(0).Item("DPLIQUIDACION").ToString <> "" Then
                RETORNO = TABLA.Rows(0).Item("DPLIQUIDACION").ToString
            Else
                RETORNO = "0"
            End If


            Return RETORNO
        Catch ex As Exception
            'MessageBox.Show("ERROR en ObtieneDepositos [ " & ex.Message & " ]")
            Principal.LbL_Errorres.Text = "ERROR en VerificaDeposito [ " & ex.Message & " ]"
            Principal.Time_BorraError.Start()

        End Try
    End Function
    Public Function InsertaDeposito(ByVal SQL_Comman As SqlCommand, ByVal txb_consecutivo As String, ByVal txb_NumDepo As String, ByVal Fecha As String, ByVal BANCO As String, ByVal Monto As String, ByVal CodAgente As String, ByVal Notas As String, ByVal NumLiqui As String, ByVal TipoLiqui As String, ByVal FechaContable As String)
        Try

            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            Consulta = " INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] ([DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],[DPMONTO],[DPAGENTE],[DPOBS],[DPLIQUIDACION],[DP_TIPO_LIQ],[DPFECHA_CONTABLE],[DP_ANULADO],[DP_SUBIDO]) VALUES('" & txb_consecutivo & "','" & txb_NumDepo & "','" & Fecha & "','" & BANCO & "','" & Monto & "'," & CodAgente & ",'" & Notas & "','" & NumLiqui & "','" & TipoLiqui & "','" & FechaContable & "','0','0')"


            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing


        Catch ex As Exception
            MessageBox.Show("ERROR en InsertaDeposito [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function AnulaDeposito(ByVal SQL_Comman As SqlCommand, ByVal DPCONSECUTIVO As String)

        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""

            ' Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] WHERE [DPCONSECUTIVO] = '" & DPCONSECUTIVO & "' "

            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] SET [DP_ANULADO] = '1' WHERE [DPCONSECUTIVO] = '" & DPCONSECUTIVO & "' "

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()


            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en EliminaDeposito [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ModificaDeposito(ByVal SQL_Comman As SqlCommand, ByVal DPCONSECUTIVO As String, ByVal DPCODIGO As String, ByVal DPFECHA As String, ByVal DPBANCO As String, ByVal DPMONTO As String, ByVal DPAGENTE As String, ByVal DPOBS As String, ByVal DPLIQUIDACION As String, ByVal DP_TIPO_LIQ As String, ByVal GuardandoLiq As Boolean, ByVal DP_SUBIDO As String, ByVal FechaContable As String)
        Try



            Dim cont As Integer = 0
            Dim Consulta As String
            Consulta = ""


            If GuardandoLiq = True Then
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] SET  [DPLIQUIDACION] = '" & DPLIQUIDACION & "' , [DP_TIPO_LIQ] = '" & DP_TIPO_LIQ & "'  WHERE [DPCONSECUTIVO] = '" & DPCONSECUTIVO & "' "
            Else
                If DPCODIGO = "" And DPFECHA = "" And DPBANCO = "" And DPMONTO = "" And DPAGENTE = "" And DPOBS = "" And DPLIQUIDACION = "" And DP_TIPO_LIQ = "" Then
                    'DP_SUBIDO='0'
                    Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] SET [DP_BOLETA] = '0' ,[DP_SUBIDO] = '1' , [DP_TIPO_LIQ] = '" & DP_TIPO_LIQ & "' WHERE [DPCONSECUTIVO] = '" & DPCONSECUTIVO & "' "
                Else
                    Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] SET [DPCODIGO] = '" & DPCODIGO & "',[DPFECHA] = '" & DPFECHA & "',[DPBANCO] = '" & DPBANCO & "',[DPMONTO] = '" & CleanInput(DPMONTO) & "' ,[DPAGENTE] = '" & DPAGENTE & "',[DPOBS] = '" & DPOBS & "' ,[DPLIQUIDACION] = '" & DPLIQUIDACION & "' ,[DP_TIPO_LIQ] = '" & DP_TIPO_LIQ & "' ,[DPFECHA_CONTABLE] = '" & FechaContable & "',[DP_SUBIDO] = '" & DP_SUBIDO & "'   WHERE [DPCONSECUTIVO] = '" & DPCONSECUTIVO & "' "
                End If


            End If

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            Return 0
        Catch ex As Exception
            MessageBox.Show("ERROR en ModificaDeposito [ " & ex.Message & " ]")
        End Try

    End Function

    Public Function ObtieneDevoluciones(ByVal SQL_Comman As SqlCommand)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Monto As String

            Consulta = "Select [DocNum],[FechaNota],[HoraNota],[CodChofer] as CodEmpleado,[NombreChofer] as Nombre,[CodCliente],[NombreCliente],[Credito],[NumFactura] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Devoluciones] GROUP BY [DocNum],[FechaNota],[HoraNota] ,[CodChofer],[NombreChofer] ,[CodCliente] ,[NombreCliente] ,[Credito] ,[NumFactura]"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return TABLA
        Catch ex As Exception
            'MessageBox.Show("ERROR en ObtieneDepositos [ " & ex.Message & " ]")
            Principal.LbL_Errorres.Text = "ERROR en ObtieneDevoluciones [ " & ex.Message & " ]"
            Principal.Time_BorraError.Start()

        End Try
    End Function


    Public Function ObtieneDetalleDevoluciones(ByVal SQL_Comman As SqlCommand, ByVal DocNum As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Monto As String

            Consulta = "SELECT [DocNum],[FechaNota],[HoraNota],[CodChofer],[NombreChofer],[CodCliente],[NombreCliente],[Credito],[ItemCode],[ItemName],[Precio] ,[Quantity],[Porc_Desc],[Total],[NumFactura],[Motivo],[IdRuta],[Ruta],[Procesada] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Devoluciones]"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return TABLA
        Catch ex As Exception
            'MessageBox.Show("ERROR en ObtieneDepositos [ " & ex.Message & " ]")
            Principal.LbL_Errorres.Text = "ERROR en ObtieneDetalleDevoluciones [ " & ex.Message & " ]"
            Principal.Time_BorraError.Start()

        End Try
    End Function

    Public Function ObtieneDepositos(ByVal SQL_Comman As SqlCommand, llamadoDesde As String, ByVal NumLiq As String, ByVal FechaIni As String, ByVal FechaFin As String, ByVal Agente As String, ByVal NumDepo As String, ByVal Consecutivo As String, ByVal DP_SUBIDO As String, ByVal OrdenarX As String, ByVal Tipo As String, VerAnulados As Boolean, Monto As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""


            ' Consulta = "SELECT [DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],CONVERT(varchar, CAST([DPMONTO] AS money), 1) as Total,[DPOBS],[DPAGENTE],[DPLIQUIDACION],[DP_BOLETA] ,[DP_SUBIDO],[DPFECHA_CONTABLE],[DP_ANULADO]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] WHERE [DP_TIPO_LIQ] ='" & Tipo & "' AND "

            Consulta = "SELECT [DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],CONVERT(varchar, CAST([DPMONTO] AS money), 1) as Total,[DPOBS],[DPAGENTE],[DPLIQUIDACION],[DP_BOLETA] ,[DP_SUBIDO],[DPFECHA_CONTABLE],[DP_ANULADO]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] WHERE "

            'SUBIDO CON TODAS LAS COMBINACIONES DE BUSQUEDAS


            If FechaIni <> "" And FechaFin <> "" Then
                Consulta = Consulta & "[DPFECHA] BETWEEN '" & FechaIni & "' AND '" & FechaFin & "' AND "
            End If
            If Agente <> "" Then
                Consulta = Consulta & "[DPAGENTE]='" & Agente & "' AND "
            End If
            If NumDepo <> "" Then
                Consulta = Consulta & "[DPCODIGO] like '%" & NumDepo & "%' AND "
            End If
            If Consecutivo <> "" Then
                Consulta = Consulta & "[DPCONSECUTIVO] like '%" & Consecutivo & "%' AND "
            End If

            If llamadoDesde = "LIQUIDACION" Then
                If NumLiq <> "" Then
                    Consulta = Consulta & "[DPLIQUIDACION] = '" & NumLiq & "' AND "
                Else
                    Consulta = Consulta & "[DPLIQUIDACION] = NULL AND "
                End If
            Else
                If NumLiq <> "" Then
                    Consulta = Consulta & "[DPLIQUIDACION] like '%" & NumLiq & "%' AND "

                End If
            End If


            If DP_SUBIDO = "0" Then
                Consulta = Consulta & "[DP_SUBIDO]='0' AND "
            ElseIf DP_SUBIDO = "1" Then
                Consulta = Consulta & "[DP_SUBIDO]='1' AND "
            End If

            If Monto <> "" Then
                Consulta = Consulta & "[DPMONTO] like '%" & Monto & "%' AND "
            End If

            If VerAnulados = True Then
                'Muestra anulados 
                Consulta = Consulta.Substring(0, Consulta.Length - 5)

            Else
                Consulta = Consulta & "[DP_ANULADO] <> '1'"
            End If



            Consulta = Consulta & " ORDER BY " & OrdenarX & " asc"


            'NO SUBIDOS  CON TODAS LAS COMBINACIONES DE BUSQUEDAS



            'If DP_SUBIDO = "0" Then
            '    If FechaIni <> "" And FechaFin <> "" And Agente <> "" Then
            '        Consulta = "SELECT [DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],CONVERT(varchar, CAST([DPMONTO] AS money), 1) as Total,[DPOBS],[DPAGENTE],[DPLIQUIDACION],[DP_BOLETA] ,[DP_SUBIDO],[DPFECHA_CONTABLE],[DP_ANULADO]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] WHERE [DP_TIPO_LIQ] ='" & Tipo & "' AND [DPFECHA] BETWEEN '" & FechaIni & "' AND '" & FechaFin & "' and [DPAGENTE]='" & Agente & "' and [DP_ANULADO] <> '1' and DP_SUBIDO='0' ORDER BY " & OrdenarX & " asc"

            '    ElseIf FechaIni <> "" And FechaFin <> "" Then
            '        Consulta = "SELECT [DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],CONVERT(varchar, CAST([DPMONTO] AS money), 1) as Total,[DPOBS],[DPAGENTE],[DPLIQUIDACION],[DP_BOLETA],[DP_SUBIDO],[DPFECHA_CONTABLE],[DP_ANULADO]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] WHERE  [DP_TIPO_LIQ] ='" & Tipo & "' AND [DPFECHA] BETWEEN '" & FechaIni & "' AND '" & FechaFin & "' and [DP_ANULADO] <> '1'  and DP_SUBIDO='0' ORDER BY " & OrdenarX & " asc"
            '    End If

            'ElseIf DP_SUBIDO = "1" Then
            '    If FechaIni <> "" And FechaFin <> "" And Agente <> "" Then
            '        Consulta = "SELECT [DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],CONVERT(varchar, CAST([DPMONTO] AS money), 1) as Total,[DPOBS],[DPAGENTE],[DPLIQUIDACION],[DP_BOLETA],[DP_SUBIDO],[DPFECHA_CONTABLE],[DP_ANULADO]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] WHERE  [DP_TIPO_LIQ] ='" & Tipo & "' AND [DPFECHA] BETWEEN '" & FechaIni & "' AND '" & FechaFin & "' and [DPAGENTE]='" & Agente & "' and [DP_ANULADO] <> '1' and DP_SUBIDO='1' ORDER BY " & OrdenarX & " asc"
            '    ElseIf FechaIni <> "" And FechaFin <> "" Then
            '        Consulta = "SELECT [DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],CONVERT(varchar, CAST([DPMONTO] AS money), 1) as Total,[DPOBS],[DPAGENTE],[DPLIQUIDACION],[DP_BOLETA],[DP_SUBIDO],[DPFECHA_CONTABLE],[DP_ANULADO]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] WHERE  [DP_TIPO_LIQ] ='" & Tipo & "' AND [DPFECHA] BETWEEN '" & FechaIni & "' AND '" & FechaFin & "' and [DP_ANULADO] <> '1'  and DP_SUBIDO='1' ORDER BY " & OrdenarX & " asc"
            '    End If

            'Else
            '    If FechaIni <> "" And FechaFin <> "" And Agente <> "" Then
            '        Consulta = "SELECT [DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],CONVERT(varchar, CAST([DPMONTO] AS money), 1) as Total,[DPOBS],[DPAGENTE],[DPLIQUIDACION],[DP_BOLETA],[DP_SUBIDO] ,[DPFECHA_CONTABLE],[DP_ANULADO] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] WHERE [DP_TIPO_LIQ] ='" & Tipo & "' AND  [DPFECHA] BETWEEN '" & FechaIni & "' AND '" & FechaFin & "' and [DPAGENTE]='" & Agente & "' and [DP_ANULADO] <> '1' ORDER BY " & OrdenarX & " asc"
            '    ElseIf FechaIni <> "" And FechaFin <> "" And Agente <> "" And NumLiq <> "" Then
            '        Consulta = "SELECT [DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],CONVERT(varchar, CAST([DPMONTO] AS money), 1) as Total,[DPOBS],[DPAGENTE],[DPLIQUIDACION],[DP_BOLETA],[DP_SUBIDO] ,[DPFECHA_CONTABLE],[DP_ANULADO] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] WHERE [DP_TIPO_LIQ] ='" & Tipo & "' AND  [DPFECHA] BETWEEN '" & FechaIni & "' AND '" & FechaFin & "' and [DPAGENTE]='" & Agente & "' and [DP_ANULADO] <> '1' and [DPLIQUIDACION]='" & NumLiq & "' ORDER BY " & OrdenarX & " asc"


            '    ElseIf FechaIni <> "" And FechaFin <> "" Then
            '        Consulta = "SELECT [DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],CONVERT(varchar, CAST([DPMONTO] AS money), 1) as Total,[DPOBS],[DPAGENTE],[DPLIQUIDACION],[DP_BOLETA],[DP_SUBIDO],[DPFECHA_CONTABLE],[DP_ANULADO]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] WHERE  [DP_TIPO_LIQ] ='" & Tipo & "' AND [DPFECHA] BETWEEN '" & FechaIni & "' AND '" & FechaFin & "' and [DP_ANULADO] <> '1' ORDER BY " & OrdenarX & " asc"

            '    ElseIf NumDepo <> "" Then
            '        Consulta = "SELECT [DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],CONVERT(varchar, CAST([DPMONTO] AS money), 1) as Total,[DPOBS],[DPAGENTE],[DPLIQUIDACION],[DP_BOLETA],[DP_SUBIDO],[DPFECHA_CONTABLE],[DP_ANULADO]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] WHERE [DP_TIPO_LIQ] ='" & Tipo & "' AND  [DPCODIGO] like '%" & NumDepo & "%' and [DP_ANULADO] <> '1' ORDER BY " & OrdenarX & " asc"
            '    ElseIf Agente <> "" Then
            '        Consulta = "SELECT [DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],CONVERT(varchar, CAST([DPMONTO] AS money), 1) as Total,[DPOBS],[DPAGENTE],[DPLIQUIDACION],[DP_BOLETA],[DP_SUBIDO],[DPFECHA_CONTABLE],[DP_ANULADO]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] WHERE [DP_TIPO_LIQ] ='" & Tipo & "' AND  [DPAGENTE] = '" & Agente & "' and [DP_ANULADO] <> '1' ORDER BY " & OrdenarX & " asc"
            '    ElseIf Consecutivo <> "" Then
            '        Consulta = "SELECT [DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],CONVERT(varchar, CAST([DPMONTO] AS money), 1) as Total,[DPOBS],[DPAGENTE],[DPLIQUIDACION],[DP_BOLETA],[DP_SUBIDO],[DPFECHA_CONTABLE],[DP_ANULADO]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] WHERE [DP_TIPO_LIQ] ='" & Tipo & "' AND  [DPCONSECUTIVO] like '%" & Consecutivo & "%' and [DP_ANULADO] <> '1' ORDER BY " & OrdenarX & " asc"

            '    ElseIf Consecutivo <> "" And NumDepo = "" Then
            '        Consulta = "SELECT [DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],CONVERT(varchar, CAST([DPMONTO] AS money), 1) as Total,[DPOBS],[DPAGENTE],[DPLIQUIDACION],[DP_BOLETA],[DP_SUBIDO],[DPFECHA_CONTABLE],[DP_ANULADO]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] WHERE [DP_TIPO_LIQ] ='" & Tipo & "' AND  [DPCONSECUTIVO] like '%" & NumLiq & "%' and [DP_ANULADO] <> '1' ORDER BY " & OrdenarX & " asc"
            '    Else
            '        Consulta = "SELECT [DPCONSECUTIVO],[DPCODIGO],[DPFECHA],[DPBANCO],CONVERT(varchar, CAST([DPMONTO] AS money), 1) as Total,[DPOBS],[DPAGENTE],[DPLIQUIDACION],[DP_BOLETA],[DP_SUBIDO] ,[DPFECHA_CONTABLE],[DP_ANULADO] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] WHERE [DP_TIPO_LIQ] ='" & Tipo & "'   ORDER BY " & OrdenarX & " asc"
            '    End If
            'End If



            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return TABLA
        Catch ex As Exception
            'MessageBox.Show("ERROR en ObtieneDepositos [ " & ex.Message & " ]")
            Principal.LbL_Errorres.Text = "ERROR en ObtieneDepositos [ " & ex.Message & " ]"
            Principal.Time_BorraError.Start()

        End Try
    End Function
    Public Function ObtieneTotalDepositos(ByVal SQL_Comman As SqlCommand, LlamadoDesde As String, ByVal FechaIni As String, ByVal FechaFin As String, ByVal Agente As String, ByVal Consecutivo As String, ByVal Tipo As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Monto As String

            ' Consulta = "SELECT  SUM([DPMONTO])as Monto FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] WHERE  [DPFECHA] BETWEEN CONVERT(DATETIME, '" & FechaIni & " 00:00:00', 102)  AND CONVERT(DATETIME, '" & FechaFin & " 00:00:00', 102)  and [DP_ANULADO] <> '1'  and DPAGENTE = '" & Agente & "'  and [DP_TIPO_LIQ] ='" & Tipo & "'  AND [DPLIQUIDACION] like '%" & Consecutivo & "%' GROUP BY DPAGENTE    "
            If LlamadoDesde = "LIQUIDACION" Then
                Consulta = "SELECT  SUM([DPMONTO])as Monto FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] WHERE  [DPFECHA] BETWEEN CONVERT(DATETIME, '" & FechaIni & " 00:00:00', 102)  AND CONVERT(DATETIME, '" & FechaFin & " 00:00:00', 102)  and [DP_ANULADO] <> '1'  and DPAGENTE = '" & Agente & "'  AND [DPLIQUIDACION] = '" & Consecutivo & "' GROUP BY DPAGENTE    "
            Else
                Consulta = "SELECT  SUM([DPMONTO])as Monto FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Depositos] WHERE  [DPFECHA] BETWEEN CONVERT(DATETIME, '" & FechaIni & " 00:00:00', 102)  AND CONVERT(DATETIME, '" & FechaFin & " 00:00:00', 102)  and [DP_ANULADO] <> '1'  and DPAGENTE = '" & Agente & "'  AND [DPLIQUIDACION] like '%" & Consecutivo & "%' GROUP BY DPAGENTE    "
            End If




            'SELECT SUM(DPMONTO) AS Monto  FROM dbo.Depositos WHERE DPFECHA BETWEEN CONVERT(DATETIME, '2015-06-11 00:00:00', 102) AND CONVERT(DATETIME, '2015-06-25 00:00:00', 102)) GROUP BY DPAGENTE HAVING(DPAGENTE = 3)
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            If TABLA.Rows.Count > 0 Then
                If TABLA.Rows(0).Item("Monto").ToString = "" Then
                    Monto = "0"
                Else
                    Monto = TABLA.Rows(0).Item("Monto")
                End If
            Else
                Monto = "0"
            End If
            Return Monto
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneTotalDepositos [ " & ex.Message & " ]")
        End Try
    End Function

    Function CleanInput(ByVal strIn As String) As String
        ' Replace invalid characters with empty strings.
        Try
            Return Regex.Replace(strIn, ",", "")
            ' If we timeout when replacing invalid characters, 
            ' we should return String.Empty.
        Catch e As System.TimeoutException
            Return String.Empty
        End Try
    End Function


#End Region

#Region "Recibos"

    'SOLAMENTE SI ES UNA LIQUIDACION QUE ESTA EN PROCESO DE CREACION JALARA LOS RECIBOS DESDE LA BASE DE DATOS DE SAP
    'CASO CONTRARIO SE JALARAN DE LA TABLA DE PAGOS DE LA BASE DE DATOS DE SINCRO SISTEM
    Public Function ObtieneRecibos(ByVal SQL_Comman As SqlCommand, ByVal FechaIni As String, ByVal FechaFin As String, ByVal Agente As String, ByVal NumLiq As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Monto As String

            'aqui deberia verificar si se esta recuperando una liquidacion o si se esta creando
            'si se esta recuperando jalara los recibos que contiene el numero de liquidacion que se recupero
            'si se esta creando jalara los recibos entre el rango de fechas y asignados al chofer indicado ademas de tenes el numero liquidacion en blanco
            If Class_VariablesGlobales.LiquidacionRecuperada <> "" Then

                If FechaIni <> "" And FechaFin <> "" And Agente <> "" Then
                    'Consulta = "SELECT T0.[DocNum], T0.[DocDate],CONVERT(varchar, CAST(T0.[DocTotal] AS money), 1) AS Total , T0.[CardCode], T0.[CardName]  FROM [BD_BOURNE].[dbo].[ORCT] T0 WHERE  T0.[U_NumLiquidacion]  is null  and T0.[U_BP_COBRADOR] ='" & Agente & "' AND  T0.[DocDate] BETWEEN   '" & FechaIni & "' AND '" & FechaFin & "' and T0.[JrnlMemo] not like '%Cancelado'and T0.Canceled not like 'Y'  ORDER BY T0.[DocNum] ASC"
                    If Class_VariablesGlobales.LIQUIDANDO = "CHOFERES" Then
                        Consulta = "SELECT T0.[DocNum], T0.[DocDate],CONVERT(varchar, CAST(T0.[DocTotal] AS money), 1) AS Total , T0.[CardCode], T0.[CardName]  FROM [BD_BOURNE].[dbo].[ORCT] T0 WHERE  T0.[U_NumLiquidacion]  ='" & NumLiq & "'  and T0.[U_BP_COBRADOR] ='" & Agente & "' AND  T0.[DocDate] BETWEEN   '" & FechaIni & "' AND '" & FechaFin & "' and T0.Canceled not like 'Y' UNION SELECT T0.[DocNum], T0.[DocDate],CONVERT(varchar, CAST(T0.[DocTotal] AS money), 1) AS Total , T0.[CardCode], T0.[CardName]  FROM [Historial_BD_Bourne].[dbo].[ORCT] T0 WHERE  T0.[U_NumLiquidacion]  ='" & NumLiq & "'  and T0.[U_BP_COBRADOR] ='" & Agente & "' AND  T0.[DocDate] BETWEEN   '" & FechaIni & "' AND '" & FechaFin & "' and T0.Canceled not like 'Y' ORDER BY T0.[DocNum] ASC"
                    Else
                        Consulta = "SELECT T0.[DocNum], T0.[DocDate],CONVERT(varchar, CAST(T0.[DocTotal] AS money), 1) AS Total , T0.[CardCode], T0.[CardName]  FROM [BD_BOURNE].[dbo].[ORCT] T0 WHERE    T0.[U_BP_COBRADOR] ='" & Agente & "' AND  T0.[DocDate] BETWEEN   '" & FechaIni & "' AND '" & FechaFin & "' and T0.Canceled not like 'Y' UNION SELECT T0.[DocNum], T0.[DocDate],CONVERT(varchar, CAST(T0.[DocTotal] AS money), 1) AS Total , T0.[CardCode], T0.[CardName]  FROM [Historial_BD_Bourne].[dbo].[ORCT] T0 WHERE    T0.[U_BP_COBRADOR] ='" & Agente & "' AND  T0.[DocDate] BETWEEN   '" & FechaIni & "' AND '" & FechaFin & "' and T0.Canceled not like 'Y'  ORDER BY T0.[DocNum] ASC"
                    End If

                End If

            Else
                If FechaIni <> "" And FechaFin <> "" And Agente <> "" Then
                    If Class_VariablesGlobales.LIQUIDANDO = "CHOFERES" Then
                        Consulta = "SELECT T0.[DocNum], T0.[DocDate],CONVERT(varchar, CAST(T0.[DocTotal] AS money), 1) AS Total , T0.[CardCode], T0.[CardName]  FROM [BD_BOURNE].[dbo].[ORCT] T0 WHERE  T0.[U_NumLiquidacion]  is null  and T0.[U_BP_COBRADOR] ='" & Agente & "' AND  T0.[DocDate] BETWEEN   '" & FechaIni & "' AND '" & FechaFin & "' and T0.Canceled not like 'Y' UNION SELECT T0.[DocNum], T0.[DocDate],CONVERT(varchar, CAST(T0.[DocTotal] AS money), 1) AS Total , T0.[CardCode], T0.[CardName]  FROM [Historial_BD_Bourne].[dbo].[ORCT] T0 WHERE  T0.[U_NumLiquidacion]  is null  and T0.[U_BP_COBRADOR] ='" & Agente & "' AND  T0.[DocDate] BETWEEN   '" & FechaIni & "' AND '" & FechaFin & "' and T0.Canceled not like 'Y'  ORDER BY T0.[DocNum] ASC"
                    Else
                        Consulta = "SELECT T0.[DocNum], T0.[DocDate],CONVERT(varchar, CAST(T0.[DocTotal] AS money), 1) AS Total , T0.[CardCode], T0.[CardName]  FROM [BD_BOURNE].[dbo].[ORCT] T0 WHERE  T0.[U_BP_COBRADOR] ='" & Agente & "' AND  T0.[DocDate] BETWEEN   '" & FechaIni & "' AND '" & FechaFin & "' and T0.Canceled not like 'Y' UNION SELECT T0.[DocNum], T0.[DocDate],CONVERT(varchar, CAST(T0.[DocTotal] AS money), 1) AS Total , T0.[CardCode], T0.[CardName]  FROM [Historial_BD_Bourne].[dbo].[ORCT] T0 WHERE  T0.[U_BP_COBRADOR] ='" & Agente & "' AND  T0.[DocDate] BETWEEN   '" & FechaIni & "' AND '" & FechaFin & "' and T0.Canceled not like 'Y'  ORDER BY T0.[DocNum] ASC"
                    End If

                End If
            End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)


            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            ' MessageBox.Show("ERROR en ObtieneRecibos [ " & ex.Message & " ]")
            Principal.LbL_Errorres.Text = "ERROR en ObtieneRecibos [ " & ex.Message & " ]"
            Principal.Time_BorraError.Start()
        End Try
    End Function
    Public Function ObtieneTotalRecibos(ByVal SQL_Comman As SqlCommand, ByVal FechaIni As String, ByVal FechaFin As String, ByVal Agente As String, ByVal NumLiq As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Monto As String
            If Class_VariablesGlobales.LiquidacionRecuperada <> "" Then
                If Class_VariablesGlobales.LIQUIDANDO = "CHOFERES" Then
                    Consulta = "SELECT SUM(T10.[Monto]) AS Monto  FROM (SELECT SUM(T0.[DocTotal]) AS Monto  FROM [BD_BOURNE].[dbo].[ORCT] T0 WHERE  T0.[U_NumLiquidacion]  ='" & NumLiq & "'  and T0.[U_BP_COBRADOR] ='" & Agente & "' AND  T0.[DocDate] BETWEEN '" & FechaIni & "' AND '" & FechaFin & "' and T0.Canceled not like 'Y' 
                                UNION
                               SELECT SUM(T0.[DocTotal]) AS Monto  FROM [Historial_BD_Bourne].[dbo].[ORCT] T0 WHERE  T0.[U_NumLiquidacion]  ='" & NumLiq & "'  and T0.[U_BP_COBRADOR] ='" & Agente & "' AND  T0.[DocDate] BETWEEN '" & FechaIni & "' AND '" & FechaFin & "' and T0.Canceled not like 'Y') T10 "
                Else
                    Consulta = "Select SUM(T10.[Monto]) As Monto  FROM (Select SUM(T0.[DocTotal]) As Monto  FROM [BD_BOURNE].[dbo].[ORCT] T0 WHERE  T0.[U_BP_COBRADOR] ='" & Agente & "' AND  T0.[DocDate] BETWEEN '" & FechaIni & "' AND '" & FechaFin & "' and T0.Canceled not like 'Y' 
                                UNION
                                SELECT SUM(T0.[DocTotal]) AS Monto  FROM [Historial_BD_Bourne].[dbo].[ORCT] T0 WHERE  T0.[U_BP_COBRADOR] ='" & Agente & "' AND  T0.[DocDate] BETWEEN '" & FechaIni & "' AND '" & FechaFin & "' and T0.Canceled not like 'Y') T10 "
                End If

                'Consulta = "SELECT SUM(T0.[DocTotal]) AS Monto  FROM [BD_BOURNE].[dbo].[ORCT] T0 WHERE T0.[U_NumLiquidacion]  is null  and T0.[U_BP_COBRADOR] ='" & Agente & "' AND  T0.[DocDate] BETWEEN '" & FechaIni & "' AND '" & FechaFin & "' and T0.[JrnlMemo] not like '%Cancelado'and T0.Canceled not like 'Y' "
            Else
                If Class_VariablesGlobales.LIQUIDANDO = "CHOFERES" Then
                    Consulta = "Select SUM(T10.[Monto]) As Monto  FROM (SELECT SUM(T0.[DocTotal]) AS Monto  FROM [BD_BOURNE].[dbo].[ORCT] T0 WHERE T0.[U_NumLiquidacion]  is null  and T0.[U_BP_COBRADOR] ='" & Agente & "' AND  T0.[DocDate] BETWEEN '" & FechaIni & "' AND '" & FechaFin & "' and T0.Canceled not like 'Y'
                                UNION
                                SELECT SUM(T0.[DocTotal]) AS Monto  FROM [Historial_BD_Bourne].[dbo].[ORCT] T0 WHERE T0.[U_NumLiquidacion]  is null  and T0.[U_BP_COBRADOR] ='" & Agente & "' AND  T0.[DocDate] BETWEEN '" & FechaIni & "' AND '" & FechaFin & "' and T0.Canceled not like 'Y') T10"
                Else
                    Consulta = "Select SUM(T10.[Monto]) As Monto  FROM (SELECT SUM(T0.[DocTotal]) AS Monto  FROM [BD_BOURNE].[dbo].[ORCT] T0 WHERE  T0.[U_BP_COBRADOR] ='" & Agente & "' AND  T0.[DocDate] BETWEEN '" & FechaIni & "' AND '" & FechaFin & "' and T0.Canceled not like 'Y' 
                                UNION
                                SELECT SUM(T0.[DocTotal]) AS Monto  FROM [Historial_BD_Bourne].[dbo].[ORCT] T0 WHERE  T0.[U_BP_COBRADOR] ='" & Agente & "' AND  T0.[DocDate] BETWEEN '" & FechaIni & "' AND '" & FechaFin & "' and T0.Canceled not like 'Y') T10 "
                End If

            End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            If TABLA.Rows.Count > 0 Then

                If TABLA.Rows(0).Item("Monto").ToString = "" Then
                    Monto = "0"
                Else
                    Monto = TABLA.Rows(0).Item("Monto")
                End If
            Else
                Monto = "0"
            End If
            Return Monto
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneTotalRecibos [ " & ex.Message & " ]")
        End Try
    End Function
#End Region

#Region "Facturas "


    'OBTENDRA EL NUMERO DE LIQUIDACION DE UNA FACTURA
    Public Function ObtieneNumLiq(ByVal NumFactura As String, ByVal SQL_Comman As SqlCommand)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim CONSECUTIVO As Integer = 0

            Consulta = "SELECT [NumLiq],[Consecutivo]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] where DocNum='" & NumFactura & "' and Anulado='0'  GROUP BY [NumLiq],[Consecutivo]"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return TABLA




        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneNumLiq [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function CompruebaRangoFActuras(ByVal FacINI As String, ByVal FacFIN As String, ByVal SQL_Comman As SqlCommand)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim CONSECUTIVO As Integer = 0

            Consulta = "SELECT [Consecutivo]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] where DocNum BETWEEN '" & FacINI & "' AND  '" & FacFIN & "' AND  Anulado='0' GROUP BY [Consecutivo]"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA

        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneNumLiq [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function MostraFacturaEnLiq(ByVal DocNum As String, ByVal Mostrar As String, ByVal FechaReporte As String, ByVal NumLiq As String, ByVal Chofer As String, ByVal SQL_Comman As SqlCommand)
        'cambia el valor de MostrarFacLiq a 1

        Try
            Dim cont As Integer = 0
            Dim Consulta As String
            Consulta = ""

            If Chofer <> "" Then

                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] SET  [MostrarEnLiq] = '" & Trim(Mostrar) & "',[NumLiq]='" & NumLiq & "',[Chofer]='" & Chofer & "'  WHERE    DocNum='" & DocNum & "'"
            Else
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] SET  [MostrarEnLiq] = '" & Trim(Mostrar) & "',[NumLiq]='" & NumLiq & "'  WHERE    DocNum='" & DocNum & "'"
            End If

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            Return 0
        Catch ex As Exception
            MessageBox.Show("ERROR en MostraFacturaEnLiq [ " & ex.Message & " ]")
        End Try

    End Function

    Public Function UnificaRepFacturas(ByVal CodChofer As String, ByVal Consecutivo As String, ByVal NumLiq As String, ByVal SQL_Comman As SqlCommand)
        'cambia el valor de MostrarFacLiq a 1

        Try
            Dim cont As Integer = 0
            Dim Consulta As String
            Consulta = ""
            If CodChofer = "" Then
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] SET [NumLiq]='" & NumLiq & "' WHERE    [Consecutivo]='" & Consecutivo & "'"
            Else
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] SET [NumLiq]='" & NumLiq & "',[Chofer]='" & CodChofer & "' WHERE    [Consecutivo]='" & Consecutivo & "'"
            End If


            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            Return 0
        Catch ex As Exception
            MessageBox.Show("ERROR en UnificaRepFacturas [ " & ex.Message & " ]")
        End Try

    End Function

    'Public Function UnificaRepFacturas_MuestraFacContado(ByVal Consecutivo As String, ByVal NumLiq As String, ByVal Mostrar As String, ByVal SQL_Comman As SqlCommand)
    '    'cambia el valor de MostrarFacLiq a 1

    '    Try
    '        Dim cont As Integer = 0
    '        Dim Consulta As String
    '        Consulta = ""

    '        Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] SET [MostrarEnLiq] = '" & Trim(Mostrar) & "' WHERE    [Consecutivo]='" & Consecutivo & "' and [Condicion]='-1'"

    '        SQL_Comman.CommandText = Consulta
    '        SQL_Comman.ExecuteNonQuery()
    '        ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)
    '        Return 0
    '    Catch ex As Exception
    '        MessageBox.Show("ERROR en UnificaRepFacturas [ " & ex.Message & " ]")
    '    End Try

    'End Function

    Public Function ObtieneFacturas(ByVal SQL_Comman As SqlCommand, ByVal FechaINI As String, ByVal FechaFIN As String, ByVal CodChofer As String, ByVal Tipo As String, ByVal NumLiq As String, ByVal ListView_Agentes As ListView)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String

            'recorre la lista de reportes de facturas y hacer un union en cada iteracion
            'For x = 0 To ListView_Agentes.Items.Count
            '    If x <> ListView_Agentes.Items.Count Then
            '        Consulta = Consulta & " UNION "
            '    End If

            '    ListView_Agentes.Items.RemoveByKey(x)

            'Next



            'si dice contado obtendra todas las facturas que tienen el MostrarEnLiq en valor 1 ya que al generar el reporte de facturas se cargan las de contado con este dato y en caso de agregar facturas de credito a la liquidacion solo se le pone 1 a este campo ya que las de credito se cran con valor 0
            If Tipo = "CONTADO" Then
                Consulta = "SELECT 
                                T0.[DocNum],
                                T0.[DocTotal] as Total,
                                T0.[Consecutivo],
                                CASE WHEN (SELECT T10.[DocTotal]-T10.[PaidToDate] AS 'Saldo' FROM [BD_BOURNE].[dbo].OINV T10 WHERE T10.[DocNum] =T0.[DocNum]) IS NULL THEN 
		                                (SELECT T10.[DocTotal]-T10.[PaidToDate] AS 'Saldo' FROM [Historial_BD_Bourne].[dbo].OINV T10 WHERE T10.[DocNum] =T0.[DocNum])
                                ELSE 
    	                                (SELECT T10.[DocTotal]-T10.[PaidToDate] AS 'Saldo' FROM [BD_BOURNE].[dbo].OINV T10 WHERE T10.[DocNum] =T0.[DocNum])
	                            END AS 'Saldo',
                                T0.[NombreRuta],
                                T0.[SlpCode]   
                            FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] T0 
                            WHERE  MostrarEnLiq=1 and T0.[Chofer] ='" & CodChofer & "'  and Anulado='0' and [NumLiq]='" & NumLiq & "' GROUP BY  T0.[DocNum],T0.[DocTotal],T0.[Consecutivo],T0.[NombreRuta],T0.[SlpCode]  ORDER BY Saldo DESC "
            Else
                'si el Tipo no es contado es por que obtendra todas las facturas del reporte de carga especifico 
                Consulta = "SELECT T0.[DocNum],T0.[DocTotal] as Total,T0.[Consecutivo],
                            CASE WHEN (SELECT T10.[DocTotal]-T10.[PaidToDate] AS 'Saldo' FROM [BD_BOURNE].[dbo].OINV T10 WHERE T10.[DocNum] =T0.[DocNum]) IS NULL THEN 
		                         (SELECT T10.[DocTotal]-T10.[PaidToDate] AS 'Saldo' FROM [Historial_BD_Bourne].[dbo].OINV T10 WHERE T10.[DocNum] =T0.[DocNum])
                            ELSE 
    	                         (SELECT T10.[DocTotal]-T10.[PaidToDate] AS 'Saldo' FROM [BD_BOURNE].[dbo].OINV T10 WHERE T10.[DocNum] =T0.[DocNum])
	                        END AS 'Saldo',
                            T0.[NombreRuta],
                            T0.[SlpCode]   
                            FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] T0 
                            WHERE  T0.[Condicion]<>-1 and MostrarEnLiq=0 and T0.[Chofer] ='" & CodChofer & "'  and Anulado='0' and [NumLiq]='" & NumLiq & "' 
                            GROUP BY  T0.[DocNum],T0.[DocTotal],T0.[Consecutivo],T0.[NombreRuta],T0.[SlpCode]  ORDER BY Saldo DESC"
            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            Principal.LbL_Errorres.Text = "ERROR en ObtieneFacturas [ " & ex.Message & " ]"
            Principal.Time_BorraError.Start()
        End Try
    End Function


    Public Function ObtieneTotalFacturas(ByVal SQL_Comman As SqlCommand, ByVal FechaINI As String, ByVal FechaFIN As String, ByVal CodChofer As String)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable

            Dim Monto As String
            Dim Consulta As String

            'Consulta = "SELECT SUM([DocTotal]) AS Monto FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] T0 WHERE T0.[Condicion]=-1 and T0.[Chofer] ='" & CodChofer & "' and (T0.FechaReporte >= '" & FechaINI & "' or T0.FechaReporte <= '" & FechaFIN & "' )"

            Consulta = "select sum(T100.Monto)  AS Monto from (SELECT DocNum,[DocTotal] AS Monto FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] T0 WHERE MostrarEnLiq=1 and T0.[Chofer] ='" & CodChofer & "' and (T0.FechaReporte >= '" & FechaINI & "' and T0.FechaReporte <= '" & FechaFIN & "' ) and Anulado='0'  group by DocNum,[DocTotal] ) T100"


            'If Tipo = "CONTADO" Then
            '    Consulta = "select sum(T100.Monto)  AS Monto from (SELECT DocNum,[DocTotal] AS Monto FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] T0 WHERE MostrarEnLiq=1 and T0.[Chofer] ='" & CodChofer & "' and (T0.FechaReporte >= '" & FechaINI & "' and T0.FechaReporte <= '" & FechaFIN & "' ) and Anulado='0'  group by DocNum,[DocTotal] ) T100"
            'Else
            '    Consulta = "SELECT [DocNum],[DocTotal] as Total,[Consecutivo]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] T0 WHERE  MostrarEnLiq=1 and T0.[Chofer] ='" & CodChofer & "' and (T0.FechaReporte >= '" & FechaINI & "' and T0.FechaReporte <=  '" & FechaFIN & "') and Anulado='0' GROUP BY  [DocNum],[DocTotal],[Consecutivo] "
            'End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            If TABLA.Rows.Count > 0 Then

                If TABLA.Rows(0).Item("Monto").ToString = "" Then
                    Monto = "0"
                Else
                    Monto = TABLA.Rows(0).Item("Monto")
                End If
            Else
                Monto = "0"
            End If
            Return Monto
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneTotalFacturas [ " & ex.Message & " ]")
        End Try
    End Function




    Public Function ActualizaRepFacturas(ByVal SQL_Comman As SqlCommand, ByVal NumLiq As String, ByVal CodChofer As String, ByVal Consecutivo As String)
        Try
            Dim cont As Integer = 0
            Dim Consulta As String
            Consulta = ""

            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] SET  [NumLiq] = '" & NumLiq & "' WHERE   Consecutivo='" & Consecutivo & "'"


            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            Return 0
        Catch ex As Exception
            MessageBox.Show("ERROR en ActualizaGasto [ " & ex.Message & " ]")
        End Try

    End Function


    Public Function AnulaRepFacturas(ByVal Consecutivo As String, ByVal SQL_Comman As SqlCommand)

        Try



            Dim Consulta As String = ""

            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] SET  [Anulado] = '1', [NumLiq] = '' WHERE   Consecutivo='" & Consecutivo & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()

            SQL_Comman = Nothing
            Return 0

        Catch ex As Exception
            Return 1
            MessageBox.Show("ERROR en EliminaRepCarga [ " & ex.Message & " ]")
        End Try
    End Function

#End Region
#End Region

    Public Function ObtieneNameEmpresa(ByVal SQL_Comman As SqlCommand)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Nombre As String



            Consulta = "SELECT [Nombre] FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Empresa]"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            If TABLA.Rows(0).Item("Nombre").ToString = "" Then
                Nombre = "0"
            Else
                Nombre = TABLA.Rows(0).Item("Nombre")
            End If

            Return Nombre
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneNameEmpresa [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ObtieneNameChofer(ByVal SQL_Comman As SqlCommand, ByVal CodChofer As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Nombre As String



            Consulta = "SELECT [Nombre] FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Agentes] WHERE [CodChofer]='" & CodChofer & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            If TABLA.Rows(0).Item("Nombre").ToString = "" Then
                Nombre = "0"
            Else
                Nombre = TABLA.Rows(0).Item("Nombre")
            End If

            Return Nombre
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneNameChofer [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ObtieneNameAgente(ByVal SQL_Comman As SqlCommand, ByVal CodAgente As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Nombre As String



            Consulta = "SELECT [Nombre] FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Agentes] WHERE [CodAgente]='" & CodAgente & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            If TABLA.Rows(0).Item("Nombre").ToString = "" Then
                Nombre = "0"
            Else
                Nombre = TABLA.Rows(0).Item("Nombre")
            End If

            Return Nombre
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneNameAgente [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ObtieneDevolucionesPendientes(ByVal Notas As String, Ver As String, Agente As String, ByVal SQL_Comman As SqlCommand)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim IncluirAnd As Boolean = False 'controla la incrustacion del AND para los filtros
            Dim Monto As String
            Dim Procesadas As String = ""

            Consulta = "SELECT [DocNum]" &
                                   ",[FechaNota]" &
                                   ",[CodCliente]" &
                                   ",[NombreCliente]" &
                                   ",SUM([Total]) AS TOTAL " &
                                   ",[DocEntry] " &
                                    "FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Devoluciones] where"

            If Ver = "Procesadas" Then
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If
                Consulta = Consulta & " Procesada=1 "

            ElseIf Ver = "No Procesadas" Then
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If
                Consulta = Consulta & " Procesada<>1 "
            Else
                Procesadas = "Procesada<>1 or Procesada=1"
            End If



            If Agente = "" Then
            Else
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If
                Consulta = Consulta & " [CodChofer]='" & Agente & "'"
            End If



            If Notas = "" Then
            Else
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If

                Consulta = Consulta & " DocNum like '%" & Notas & "%'"

            End If

            Consulta = Consulta & " GROUP BY [DocNum],[FechaNota],[CodCliente],[NombreCliente],[DocEntry] ORDER BY [DocNum] DESC"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneDevolucionesPendientes [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ObtieneDevolucione(ByVal DocNum As String, Ver As String, ByVal SQL_Comman As SqlCommand)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Monto As String
            Dim Procesadas As String
            If Ver = "Procesadas" Then
                Procesadas = "Procesada=1 and "
            ElseIf Ver = "No Procesadas" Then
                Procesadas = "Procesada<>1 and "
            Else
                Procesadas = ""
            End If
            Consulta = "SELECT [DocNum]" &
                                ",[FechaNota]" &
                                ",[HoraNota]" &
                                ",[CodChofer]" &
                                ",[NombreChofer]" &
                                ",[CodCliente]" &
                                ",[NombreCliente]" &
                                ",[Credito]" &
                                ",[Total]" &
                                ",[NumFactura]" &
                                ",[Motivo]" &
                                ",[Procesada]" &
                                ",[DocEntry]" &
                                ",[IdRuta]" &
                                ",[Ruta]" &
                                ",[NumFactura]" &
                                ",[DocEntry]" &
                                ",[NumMarchamo]" &
                                  ",[Comentario]" &
                                "FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Devoluciones] where " & Procesadas & " DocNum='" & DocNum & "' ORDER BY DocNum asc "

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneDevolucione [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function ObtieneDetalleDevolucione(ByVal DocNum As String, ByVal SQL_Comman As SqlCommand)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Monto As String

            Consulta = "Select [DocNum]
                                  ,[ItemCode]
                                  ,[ItemName]
                                  ,[Precio]
                                  ,[Quantity]
                                  ,[Porc_Desc]
                                  ,[Motivo]
                                  ,[Porc_Desc_Fijo]
                                  ,[Porc_Desc_Promo]
                                  ,[Porc_Imp]
                                  ,[Mont_Imp]
                                  ,[Sub_Total]
                                  ,[Mont_Desc]
                                  ,[Total]
                                  ,[Procesada]
                                  ,[Comentarios]
                                  ,[NumLinea]
                              From  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[DevolucionesDetalle] Where [DocNum] ='" & DocNum & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
                ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneDetalleDevolucione [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ProcesaDevolucion(ByVal DocNum As String, ByVal SQL_Comman As SqlCommand)

        Try
            Dim Consulta As String = ""
            Consulta = "UPDATE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Devoluciones] SET Procesada='1' WHERE [DocNum] = '" & DocNum & "' "
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            Return 0
        Catch ex As Exception
            Return 1
            MessageBox.Show("ERROR en ProcesaDevolucion [ " & ex.Message & " ]")
        End Try
    End Function


    Public Function ObtieneDocEntry(ByVal SQL_Comman As SqlCommand, DocNum As String, CardCode As String)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim DocEntry As String
            Consulta = "SELECT T0.[DocEntry] FROM  " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & ".[dbo].[OINV] T0 WHERE T0.[DocNum] ='" & DocNum & "' and T0.[CardCode]='" & CardCode & "'  "
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            If TABLA.Rows.Count > 0 Then
                DocEntry = TABLA.Rows(0)("DocEntry").ToString()
            Else
                DocEntry = ""
            End If
            Return DocEntry
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneDocEntry [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function ObtieneGastosProveedores(ByVal SQL_Comman As SqlCommand)
        Try
            'Obtiene los proveedores para FEC
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "SELECT T0.[CardCode],T0.[CardName], T0.[LicTradNum], T0.[E_Mail] FROM " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & ".[dbo].OCRD T0 WHERE T0.[CardCode] like 'P2%'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneGastosProveedores [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ObtieneProveedores(ByVal SQL_Comman As SqlCommand, LlamadoDesde As String)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Monto As String
            If LlamadoDesde = "Inv_Control" Then
                Consulta = "SELECT [CodProveedor],[NameProveedor] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[inv_inventario] WHERE [IdInventario]='" & ObtieneIdInventario() & "' GROUP BY  [CodProveedor] ,[NameProveedor]"
            ElseIf LlamadoDesde = "Inv_Cruzar" Then
                Consulta = "SELECT [CodProveedor],[NameProveedor] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[inv_inventario] WHERE [IdInventario]='" & ObtieneIdInventario() & "' and [Unificado]='0' GROUP BY  [CodProveedor] ,[NameProveedor]"
            ElseIf Class_VariablesGlobales.LlamadoDesde = "PedidorPrincipal" Then
                'Obtiene los proveedores activos de SAP
                Consulta = "SELECT T0.[CardCode], T0.[CardName] FROM BD_BOURNE.dbo.OCRD T0 WHERE T0.[CardType]='S' AND T0.[frozenFor]='N' and (CardCode like 'P0%' )"
            ElseIf LlamadoDesde = "StockManager" Then
                Consulta = "Select [CardCode] AS [CodProveedor],[CardName] AS [NameProveedor] From [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ClientesModificados] Where [TipoSocio] = 2"
            Else
                Consulta = "SELECT [CodProveedor],[NameProveedor] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[inv_inventario] WHERE [IdInventario]='" & ObtieneIdInventario() & "'  GROUP BY  [CodProveedor] ,[NameProveedor]"

            End If





            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneProveedores [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function DetLineRepCarga(ByVal SQL_Comman As SqlCommand, ByVal NumRuta As String, ByVal CodBar As String)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Monto As String
            Consulta = "SELECT [Consecutivo],[ItemCode],[Descripcion],SUM([Cantidad]) as [Cantidad],[CodeBars],[Bodega] FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Rep_Carg_Sector] WHERE [Consecutivo] = '" & NumRuta & "' AND [CodeBars] ='" & CodBar & "' and [Chequeado]='NO'  group by [Consecutivo],[ItemCode],[Descripcion],[CodeBars],[Bodega]"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en DetLineRepCarga [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ObtieneInventario(ByVal SQL_Comman As SqlCommand)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Consulta = "SELECT T0.[ItemCode], T0.[ItemName], T0.[CodeBars] FROM  " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & ".[dbo].[OITM] T0 WHERE T0.[ItemName] NOT LIKE 'Desc%' and T0.[ItemName] NOT LIKE 'DESC%' "
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneInventario [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function InbGeneraPedido(ByVal SQL_Comman As SqlCommand, ByVal CodProveedor As String, ByVal Estado As String, ByVal Dias As String, ByVal PorcRespaldo As String, ByVal F_Ini As String, ByVal F_Fin As String, ByVal FP_Ini As String, ByVal FP_Fin As String)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            ' Consulta = "select  T0.[CardCode],T0.[Alterno] ,T0.[CodArticulo],T0.[ItemName],T0.[Costo], T0.[Pack],T0.[Vta_Monto],T0.[VtaUni],T0.[VtaCjs],T0.[PedAgts],T0.[Faltante],T0.[StockR],T0.[StockRCjs],T0.[StockR_Monto],T0.[Dif],T0.[Cpmtdo],T0.[CpmtdoCjs],isnull(T0.[Compra] ,0) as Compra,T0.[PdUni],T0.[PdCJs],T0.[PdTotal],T0.CodeBars ,isnull(T0.[Gramaje] ,0) as Gramaje,T0.DiasSinMoverse,CASE WHEN isnull((((T0.Vmp+T0.Vmatp+ T0.Vmatatp)/22)),0)=0 THEN 0 ELSE CONVERT(decimal(6,1),  (T0.[StockR]/isnull((CONVERT(decimal(6,1),((T0.Vmp+T0.Vmatp+ T0.Vmatatp)/22))),0)))  END  AS DiaInventario,ROUND (Convert(Decimal(15,2), isnull(t0.PromedioVentXdia,0), 2),0)   as PromVentXDia ,t0.FechaUltimaCompra,t0.Vmp,t0.Vmatp,T0.Vmatatp,t0.Compra ,t0.Dif,t0.FechaUltimaVenta,t0.CantidadUltimaVenta,t0.FechaUltimoPedido,t0.CantidadUltimoPedido from " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].ObtieneInvProveedor('" & CodProveedor & "','" & Dias & "','" & PorcRespaldo & "','" & F_Ini & "','" & F_Fin & "','" & FP_Ini & "','" & FP_Fin & "') t0 order by t0.CodArticulo asc "
            'SQL_Comman.CommandTimeout = 1000
            'ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            'ADATER.Fill(TABLA)


            'Consulta = "EXEC	[dbo].[sp_GeneraPedido]
            '      @CodProveedor = '" & CodProveedor & "',
            '      @Dias = " & Dias & ",
            '      @PorcRespaldo = " & PorcRespaldo & ",
            '      @F_Ini = '" & F_Ini & "',
            '      @F_Fin = '" & F_Fin & "',
            '      @FP_Ini = '" & FP_Ini & "',
            '      @FP_Fin = '" & FP_Fin & "'"

            Dim StrimConexion As String = "Data Source=" & Class_VariablesGlobales.XMLParamSQL_server & ";Initial Catalog=" & Class_VariablesGlobales.XMLParamSQL_dababase & ";Persist Security Info=True;User ID=" & Class_VariablesGlobales.XMLParamSQL_user & ";Password=" & Class_VariablesGlobales.XMLParamSQL_clave & ";MultipleActiveResultSets=True"

            Using cnn As SqlConnection = New SqlConnection(StrimConexion)

                Dim cmd As SqlCommand = New SqlCommand("sp_GeneraPedido ", cnn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandTimeout = 300
                cmd.Parameters.AddWithValue("@CodProveedor", CodProveedor)
                cmd.Parameters.AddWithValue("@Dias", Dias)
                cmd.Parameters.AddWithValue("@PorcRespaldo", PorcRespaldo)
                cmd.Parameters.AddWithValue("@F_Ini", F_Ini)
                cmd.Parameters.AddWithValue("@F_Fin", F_Fin)
                cmd.Parameters.AddWithValue("@FP_Ini", FP_Ini)
                cmd.Parameters.AddWithValue("@FP_Fin", FP_Fin)

                ''cmd.ExecuteNonQuery()
                ' Dim TABLA As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(TABLA)
            End Using



            Return TABLA
        Catch ex As Exception
            'InbGeneraPedido(SQL_Comman, CodProveedor, Estado, Dias, PorcRespaldo, F_Ini, F_Fin, FP_Ini, FP_Fin)
            MessageBox.Show("ERROR InbGeneraPedido [ " & ex.Message & " ] ")
            Return 1
        End Try

    End Function
    Public Function ObtieneOrdenCompraTem(ByVal SQL_Comman As SqlCommand, ByVal id As String, ByVal Navegando As Boolean, CrearPedidoHabilitado As Boolean, NumDoc As String)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            'If CrearPedidoHabilitado = False Then
            If Navegando = True Then
                Consulta = "SELECT [ID],[NumDoc],[Fecha],[CardCode],[NombreProveedor],[Alterno],[ItemCode],[ItemName],[Costo],[Pack],[Venta_Mont],[Venta_Uni],[Venta_Cjs],[PedAgts],[Faltante],[StockR],[StockRCjs],[StockR_Monto],[Dif],[Cpmtdo],[CpmtdoCjs],[Pd_Unid],[Pd_CJs],[Pd_Total],[Prmd_Compra],[PrmdVtaDs],[Dias_Iv],[FIni_Venta],[FFin_Venta],[FIni_Cubrir],[FFin_Cubrir],[UltimaCompra],[CodeBars],[Gramaje],[DiasSinMoverse],Vmp,Vmatp,Vmatatp,MEs_Vmp,MEs_Vmatp,MEs_Vmatatp,FechaUltimaCompra,FechaUltimaVenta,CantidadUltimaVenta,[Revizado] ,[FechaUltimoPedido] ,[CantidadUltimoPedido] FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Pedidor] where [ItemCode]='" & id & "' and  [NumDoc]='" & NumDoc & "' order by [Pd_Unid]   DESC"
            Else
                Consulta = "SELECT [ID],[NumDoc],[Fecha],[CardCode],[NombreProveedor],[Alterno],[ItemCode],[ItemName],[Costo],[Pack],[Venta_Mont],[Venta_Uni],[Venta_Cjs],[PedAgts],[Faltante],[StockR],[StockRCjs],[StockR_Monto],[Dif],[Cpmtdo],[CpmtdoCjs],[Pd_Unid],[Pd_CJs],[Pd_Total],[Prmd_Compra],[PrmdVtaDs],[Dias_Iv],[FIni_Venta],[FFin_Venta],[FIni_Cubrir],[FFin_Cubrir],[UltimaCompra],[CodeBars],[Gramaje],[DiasSinMoverse],Vmp,Vmatp,Vmatatp,MEs_Vmp,MEs_Vmatp,MEs_Vmatatp,FechaUltimaCompra,FechaUltimaVenta,CantidadUltimaVenta,[Revizado]  ,[FechaUltimoPedido] ,[CantidadUltimoPedido] FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Pedidor] where [NumDoc]='" & id & "' order by [Pd_Unid]   DESC"
            End If
            'Else
            '    If Navegando = True Then
            '        Consulta = "SELECT [ID],[NumDoc],[Fecha],[CardCode],[NombreProveedor],[Alterno],[ItemCode],[ItemName],[Costo],[Pack],[Venta_Mont],[Venta_Uni],[Venta_Cjs],[PedAgts],[Faltante],[StockR],[StockRCjs],[StockR_Monto],[Dif],[Cpmtdo],[CpmtdoCjs],[Pd_Unid],[Pd_CJs],[Pd_Total],[Prmd_Compra],[PrmdVtaDs],[Dias_Iv],[FIni_Venta],[FFin_Venta],[FIni_Cubrir],[FFin_Cubrir],[UltimaCompra],[CodeBars],[Gramaje],[DiasSinMoverse],Vmp,Vmatp,Vmatatp,MEs_Vmp,MEs_Vmatp,MEs_Vmatatp,FechaUltimaCompra,FechaUltimaVenta,CantidadUltimaVenta,[Revizado]  FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Pedidor_Temp] where [ID]='" & id & "' order by [ID]   asc"
            '    Else
            '        Consulta = "SELECT [ID],[NumDoc],[Fecha],[CardCode],[NombreProveedor],[Alterno],[ItemCode],[ItemName],[Costo],[Pack],[Venta_Mont],[Venta_Uni],[Venta_Cjs],[PedAgts],[Faltante],[StockR],[StockRCjs],[StockR_Monto],[Dif],[Cpmtdo],[CpmtdoCjs],[Pd_Unid],[Pd_CJs],[Pd_Total],[Prmd_Compra],[PrmdVtaDs],[Dias_Iv],[FIni_Venta],[FFin_Venta],[FIni_Cubrir],[FFin_Cubrir],[UltimaCompra],[CodeBars],[Gramaje],[DiasSinMoverse],Vmp,Vmatp,Vmatatp,MEs_Vmp,MEs_Vmatp,MEs_Vmatatp,FechaUltimaCompra,FechaUltimaVenta,CantidadUltimaVenta,[Revizado]  FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Pedidor_Temp] where [NumDoc]='" & id & "' order by [ID]   asc"
            '    End If
            'End If

            'Consulta = "SELECT [CardCode],[Alterno],[Emp],[Precio_Costo],([Stock_Unid]-[Comprometido]) as Dif,space(0) as ESTADO,[Frecu] ,[Dias_Iv],[CodBarras],[ItemCode] ,[ItemName] ,[Venta3_Uni] as V3_Unid ,[Venta2_Uni] as V2_Unid ,[Venta_Uni] as V_Unid ,[Venta_Cjs] as V_Cjs,CONVERT(varchar, CAST([Venta_Mont] AS money), 1) as V_Mont ,[FCmp1],[Cmp1],[FCmp2],[Cmp2],[FCmp3],[Cmp3],[Stock_Unid] as Stc_Unid,[Stock_Cjs]  as Stc_Cjs,CONVERT(varchar, CAST([Stock_Mont] AS money), 1) as Stc_Mont ,[Comprometido],[StockReal],[Min] ,[Max],[Pd_Unid] ,[Pd_CJs],CONVERT(varchar, CAST([Pd_Total] AS money), 1) as Pd_Total ,[Stock_Unidad] ,[U_Gramaje]        FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Pedidor_Temp] where [ID]='" & id & "' order by [ItemCode]   asc"


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneOrdenCompraTem [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function ObtieneRevisado(ByVal SQL_Comman As SqlCommand, ByVal DocNum As String, ByVal ItemCode As String)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "SELECT [Revizado] FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Pedidor] where [NumDoc]='" & DocNum & "' and ItemCode='" & ItemCode & "'   "


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            If TABLA.Rows.Count <> 0 Then
                Return TABLA.Rows(0).Item("Revizado")
            Else
                Return 0
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneRevisado [ " & ex.Message & " ]")
        End Try

    End Function

    Public Function ObtieneNumPedidoCreado(ByVal SQL_Comman As SqlCommand, ByVal NumFerencia As String)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""



            Consulta = "Select T0.[DocNum] FROM [BD_BOURNE].[dbo].OPOR T0 WHERE T0.[NumAtCard]='" + NumFerencia + "'"


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            If TABLA.Rows.Count <> 0 Then
                Return TABLA.Rows(0).Item("DocNum")
            Else
                Return 0
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneNumPedidoCreado [ " & ex.Message & " ]")
        End Try

    End Function

    Public Function ObtieneMinimo(ByVal SQL_Comman As SqlCommand, ByVal ItemCode As String)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Consulta = "SELECT CONVERT(int,T1.[MinStock] ) as MinStock FROM [BD_Bourne].[dbo].OITM T0  INNER JOIN [BD_Bourne].[dbo].OITW T1 ON T0.[ItemCode] = T1.[ItemCode] WHERE T0.[ItemCode] ='" & ItemCode & "' and   T1.[WhsCode] ='01'"


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            If TABLA.Rows.Count = 0 Then
                Return "0"
            Else
                Return TABLA.Rows(0).Item("MinStock")
            End If


            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneMinimo [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function VentaDetallada(ByVal SQL_Comman As SqlCommand, ByVal ItemCode As String)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "select T00.[DocNum],T00.DocDate,T00.Cantidad,T00.DiscPrcnt,T00.CardCode,T00.CardName from VentaDetallada('" & ItemCode & "') T00 ORDER BY T00.[DocNum] asc"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en VentasXDia [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function VentasXDia(ByVal SQL_Comman As SqlCommand, ByVal ItemCode As String)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "select ItemCode,Cantidad,Dia from VentasXDia('" & ItemCode & "') ORDER BY Dia asc"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en VentasXDia [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function PedidoXDia(ByVal SQL_Comman As SqlCommand, ByVal ItemCode As String)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "select ItemCode,Cantidad,Dia from PedidoXDia('" & ItemCode & "') ORDER BY Dia asc"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en PedidoXDia [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function ObtieneTarimas(ByVal SQL_Comman As SqlCommand, ByVal DocNum As String)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "SELECT [idTarima] FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Picking_OrdenDeCompraProveedor] WHERE [DocNum]='" + DocNum + "' GROUP BY [DocNum],[idTarima]"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en PedidoXDia [ " & ex.Message & " ]")
        End Try
    End Function


    Public Function ObtieneDetalleCheque(ByVal SQL_Comman As SqlCommand, ByVal DocNum As String, ByVal ItemCode As String)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "SELECT  T0.ItemCode ,T0.ItemName,T0.CodigoBarras,T1.IdUbicacion AS '#Tarima',[Stock] ,(select t10.Nombre from Bodegueros t10 where t10.CodBodeguero= [UsuarioCrea]) as Bodeguero
                        FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Picking_OrdenDeCompraProveedor] T0
                        INNER JOIN " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Picking_StockEnUbicaciones] T1 ON T0.ItemCode=T1.ItemCode
                        WHERE T0.DocNum='" + DocNum + "' AND T0.ItemCode='" + ItemCode + "'"




            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneDetalleCheque [ " & ex.Message & " ]")
        End Try
    End Function


    Public Function ObtieneOrdenCompra(ByVal SQL_Comman As SqlCommand, ByVal id As String, Chequeado As Boolean, IdTarimas As String)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            '[CardCode],[Alterno],[Emp],[Precio_Costo],([Stock_Unid]-[Comprometido]) as Dif,space(0) as ESTADO,[Frecu] ,[Dias_Iv],space(0) as CodeBars,[ItemCode] ,[ItemName] ,[Venta_Uni] as V_Unid ,[Venta_Cjs] as V_Cjs,CONVERT(varchar, CAST([Venta_Mont] AS money), 1) as V_Mont ,[Stock_Unid] as Stc_Unid,[Stock_Cjs]  as Stc_Cjs,CONVERT(varchar, CAST([Stock_Mont] AS money), 1) as Stc_Mont ,[Comprometido],[StockReal],[Min] ,[Max],[Pd_CJs] ,[Pd_Unid],CONVERT(varchar, CAST([Pd_Total] AS money), 1)  ,[Stock_Unidad]
            'Consulta = "SELECT [CardCode],[Alterno],[Emp],[Precio_Costo],([Stock_Unid]-[Comprometido]) as Dif,space(0) as ESTADO,[Dias_Iv],CodBarras,[ItemCode] ,[ItemName] ,[Venta_Uni] as V_Unid ,[Venta_Cjs] as V_Cjs,CONVERT(varchar, CAST([Venta_Mont] AS money), 1) as V_Mont ,[Stock_Unid] as Stc_Unid,[Stock_Cjs]  as Stc_Cjs,CONVERT(varchar, CAST([Stock_Mont] AS money), 1) as Stc_Mont ,[Comprometido],([Stock_Unid]-[Comprometido]) as StockReal,[Pd_CJs] ,[Pd_Unid],CONVERT(varchar, CAST([Pd_Total] AS money), 1) as Total    ,FIni_Venta,FFin_Venta    FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Pedidor] where [NumDoc]='" & id & "' order by [Pd_Total]   desc"
            'Consulta = "SELECT [ID],[NumDoc],[Fecha],[CardCode],CardName,[Alterno],[ItemCode],[ItemName],Precio_Costo,Emp,[Venta_Mont],[Venta_Uni],[Venta_Cjs],[PedAgts],[Faltante],[StockR],[StockRCjs],[StockR_Monto],[Dif],[Cpmtdo],[CpmtdoCjs],[Pd_Unid],[Pd_CJs],[Pd_Total],[Prmd_Compra],[PrmdVtaDs],[Dias_Iv],[FIni_Venta],[FFin_Venta],[FIni_Cubrir],[FFin_Cubrir],[UltimaCompra],[CodeBars],[Gramaje],[FechaUltimaCompra],[Cerrado] FROM " & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & ".[dbo].[Pedidor] where [NumDoc]='" & id & "' order by [NumDoc]   asc"

            If Chequeado = False Then
                Consulta = ""
                Consulta = "SP_ObtienePedido"
            Else
                'Obtiene las lineas y quien las chequeo

                Consulta = "SP_ObtienePedidoChequeado"

            End If


            Dim StrimConexion As String = "Data Source=" & Class_VariablesGlobales.XMLParamSQL_server & ";Initial Catalog=" & Class_VariablesGlobales.XMLParamSQL_dababase & ";Persist Security Info=True;User ID=" & Class_VariablesGlobales.XMLParamSQL_user & ";Password=" & Class_VariablesGlobales.XMLParamSQL_clave & ";MultipleActiveResultSets=True"
            Using cnn As SqlConnection = New SqlConnection(StrimConexion)
                Dim cmd As SqlCommand = New SqlCommand(Consulta, cnn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandTimeout = 300
                cmd.Parameters.AddWithValue("@DocNum", id)
                If Consulta = "SP_ObtienePedidoChequeado" Then
                    If IdTarimas <> "" Then
                        cmd.Parameters.AddWithValue("@IdTarimas", IdTarimas)
                    Else
                        cmd.Parameters.AddWithValue("@IdTarimas", "0")
                    End If

                End If

                ''cmd.ExecuteNonQuery()
                ' Dim TABLA As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(TABLA)
            End Using

            'ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            'ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception
            'MessageBox.Show("ERROR en ObtieneOrdenCompra [ " & ex.Message & " ]")
        End Try


    End Function
    Public Function ObtienePedidoRespaldados(ByVal SQL_Comman As SqlCommand, ByVal ItemCode As String, ByVal FechaInicio As String, ByVal FechaFin As String)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "SELECT * FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Backup_Det_Pedido]  T90 WHERE T90.[Date] BETWEEN    '" + FechaInicio + "'  AND  '" + FechaFin + "' and T90.[ItemCode]='" + ItemCode + "' order by DocNum asc"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneOPedidoRespaldados [ " & ex.Message & " ]")
        End Try


    End Function


    Public Function GuardaOrdenDeCompra(ByVal ID As String,
                                             ByVal NumDoc As String,
                                      ByVal CardCode As String,
                                      ByVal CardName As String,
                                      ByVal ItemCode As String,
                                      ByVal ItemName As String,
                                      ByVal Fecha As String,
                                      ByVal Alterno As String,
                                      ByVal Emp As String,
                                      ByVal Precio_Costo As String,
                                      ByVal Venta_Uni As String,
                                      ByVal Venta_Cjs As String,
                                      ByVal Venta_Mont As String,
                                      ByVal Stock_Unid As String,
                                      ByVal Stock_Cjs As String,
                                      ByVal Stock_Mont As String,
                                      ByVal Comprometido As String,
                                      ByVal Dias_Iv As String,
                                      ByVal Pd_CJs As String,
                                      ByVal Pd_Unid As String,
                                      ByVal Pd_Total As String,
                                      ByVal FVIni As String,
                                      ByVal FVFin As String,
                                      ByVal FCIni As String,
                                      ByVal FCFin As String,
                                      ByVal UnidadDeMedidas As String,
                                      ByVal CodBarras As String,
                                      ByVal Gramaje As String,
                                      ByVal UltimaCompra As String,
                                      ByVal PedidoXAgente As String,
                                      ByVal Faltante As String,
                                      ByVal CpmtdoCjs As String,
                                      ByVal FechaUltimaCompra As String,
                                      ByVal Dif As String,
                                      ByVal Prmd_Compra As String,
                                      ByVal PrmdVtaDs As String,
                                      ByVal FIni_Cubrir As String,
                                      ByVal FFin_Cubrir As String,
                                      ByVal DiasSinMoverse As String,
                                      ByVal Vmp As String,
                                      ByVal Vmatp As String,
                                      ByVal Vmatatp As String,
                                      ByVal Mes_Vmp As String,
                                      ByVal Mes_Vmatatp As String,
                                      ByVal MEs_Vmatp As String,
                                      ByVal Pd_CJs_Cheado As String,
                                      ByVal Pd_Unid_Cheado As String,
                                      ByVal Pd_Total_Cheado As String,
                                      ByVal Motivo As String,
                                      ByVal FCFIn_Venta As String,
                                      ByVal FechaUltimaVenta As String,
                                      ByVal CantidadUltimaVenta As String,
                                      ByVal Revizado As String,
                                      ByVal FechaUltimoPedido As String,
                                      ByVal CantidadUltimoPedido As String,
                                      ByVal SQL_Comman As SqlCommand,
                                      ByVal GUARDANDO As Boolean)
        Try

            Dim Consulta As String

            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            If GUARDANDO = True Then





                Consulta = "INSERT INTO " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Pedidor]" &
           "([NumDoc]" &
           ",[CardCode]" &
           ",[NombreProveedor]" &
           ",[ItemCode]" &
           ",[ItemName]" &
           ",[Fecha]" &
           ",[Alterno]" &
           ",[Pack]" &
           ",[Costo]" &
           ",[Venta_Uni]" &
           ",[Venta_Cjs]" &
           ",[Venta_Mont]" &
           ",[StockR]" &
           ",[StockRCjs]" &
           ",[StockR_Monto]" &
           ",[Cpmtdo]" &
           ",[Dias_Iv]" &
           ",[Pd_CJs]" &
           ",[Pd_Unid]" &
           ",[Pd_Total]" &
           ",[FIni_Venta]" &
           ",[FFIn_Venta]" &
           ",[FCIni_Venta]" &
           ",[FCFIn_Venta]" &
           ",[Unidad_Medida]" &
           ",[UltimaCompra]" &
           ",[Sacado]" &
           ",[Cerrado]" &
           ",[Faltante]" &
           ",[PedAgts]" &
           ",[CpmtdoCjs]" &
           ",[CodeBars]" &
           ",[FechaUltimaCompra]" &
           ",[Dif]" &
           ",[Prmd_Compra]" &
           ",[PrmdVtaDs]" &
           ",[FIni_Cubrir]" &
           ",[FFin_Cubrir]" &
           ",[Gramaje]" &
           ",[DiasSinMoverse]" &
           ",[Vmp]" &
           ",[Vmatp]" &
           ",[Vmatatp]" &
           ",[Mes_Vmp]" &
           ",[Mes_Vmatatp]" &
           ",[MEs_Vmatp]" &
           ",[Pd_CJs_Cheado]" &
           ",[Pd_Unid_Cheado]" &
           ",[Pd_Total_Cheado]" &
           ",[FechaUltimaVenta]" &
           ",[CantidadUltimaVenta]" &
           ",[Motivo]" &
           ",[Revizado]" &
           ",[FechaUltimoPedido]" &
           ",[CantidadUltimoPedido]" &
           ",[CreadoSAP])" &
          "VALUES('" & NumDoc & "'
           ,'" & CardCode & "'
           ,'" & CardName & "'
           ,'" & ItemCode & "'
           ,'" & ItemName & "'
           ,'" & Fecha & "'
           ,'" & Alterno & "'
           ,'" & Emp & "'
           ,'" & Precio_Costo & "'
           ,'" & Venta_Uni & "'
           ,'" & Venta_Cjs & "'
           ," & CSng(CDbl(Venta_Mont)) & "
           ,'" & Stock_Unid & "'
           ,'" & Stock_Cjs & "'
           ," & CDbl(Stock_Mont) & "
           ,'" & Comprometido & "'
           ,'" & Dias_Iv & "'
           ,'" & Pd_CJs & "'
           ,'" & Pd_Unid & "'," &
           CSng(CDbl(Pd_Total)) & "
           ,'" & FVIni & "'
           ,'" & FVFin & "'
           ,'" & FCIni & "'
           ,'" & FCFin & "'
           ,'" & UnidadDeMedidas & "'
           ,'" & UltimaCompra & "'
           ,'NO'
           ,'0'
           ,'" & Faltante & "'
           ,'" & PedidoXAgente & "'
           ,'" & CpmtdoCjs & "'
           ,'" & CodBarras & "'
           ,'" & FechaUltimaCompra & "'
           ,'" & Dif & "'
           ,'" & Prmd_Compra & "'
           ,'" & PrmdVtaDs & "'
           ,'" & FIni_Cubrir & "'
           ,'" & FFin_Cubrir & "'
           ,'" & Gramaje & "'
           ,'" & DiasSinMoverse & "'
           ,'" & Vmp & "'
           ,'" & Vmatp & "'
           ,'" & Vmatatp & "'
           ,'" & Mes_Vmp & "'
           ,'" & Mes_Vmatatp & "'
           ,'" & MEs_Vmatp & "'
           ,'" & Pd_CJs_Cheado & "'
           ,'" & Pd_Unid_Cheado & "'
           ,'" & Pd_Total_Cheado & "'
           ,'" & FechaUltimaVenta & "'
           ,'" & CantidadUltimaVenta & "'
           ,'" & Motivo & "','" & Revizado & "','" & FechaUltimoPedido & "','" & CantidadUltimoPedido & "','0')"




            Else
                Consulta = "UPDATE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Pedidor] SET" &
                           "[Pd_Total] ='" & CDbl(Precio_Costo * Pd_Unid) & "'" &
                           ",[Pd_CJs] ='" & Pd_CJs & "'" &
                           ",[Pd_Unid] ='" & Pd_Unid & "'" &
                           ",[Revizado] ='1' WHERE [ItemCode] ='" & ItemCode & "' AND [NumDoc] ='" & NumDoc & "'"

            End If

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en GuardaOrdenDeCompra [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function CreaEncabezadoPedidor(ByVal SQL_Comman As SqlCommand, CardName As String, Fecha As String)
        Try


            Dim Consulta As String = ""
            Consulta = "INSERT INTO " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[PedidorEncabezado]([Proveedor],[fechaCrea]) VALUES('" + CardName + "' ,'" + Fecha + "')"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()


            Consulta = "SELECT id_Pedido FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[PedidorEncabezado] where [Proveedor]='" + CardName + "'  and [fechaCrea]='" + Fecha + "' order by [id_Pedido] desc"
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Dim id_Pedido As Integer
            If TABLA.Rows.Count = 0 Then
                Return "0"
            Else
                id_Pedido = TABLA.Rows(0).Item("id_Pedido")
            End If

            Return id_Pedido
        Catch ex As Exception

        End Try
    End Function


    Public Function ActualizaLineaPedido(ByVal SQL_Comman As SqlCommand, NumDoc As String, Total As String, Pd_Unid As String, Pd_CJs As String, ItemCode As String)
        Try
            Dim Consulta As String
            Consulta = "UPDATE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Pedidor] SET" &
                           "[Pd_Total] ='" & Total & "'" &
                           ",[Pd_CJs] ='" & Pd_CJs & "'" &
                           ",[Pd_Unid] ='" & Pd_Unid & "'" &
                           ",[Revizado] ='1' WHERE [ItemCode] ='" & ItemCode & "' AND [NumDoc] ='" & NumDoc & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en ActualizaLineaPedido [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function ExisteOrdenCompra(ByVal NumDoc As String, ByVal SQL_Comman As SqlCommand)
        Dim ADATER As New SqlDataAdapter
        Dim TABLA As New DataTable
        Dim Consulta As String
        Consulta = "SELECT COUNT([NumDoc]) AS Conto FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Pedidor] WHERE [NumDoc]='" & NumDoc & "' GROUP BY [NumDoc]"

        ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
        ADATER.Fill(TABLA)

        If TABLA.Rows.Count = 0 Then
            Return "0"
        Else
            Return TABLA.Rows(0).Item("Conto")
        End If

    End Function

    Public Function InsertaPedidoReckitt(ByVal SQL_Comman As SqlCommand,
                                         tblPedido As DataTable
                                         )
        Try

            Dim Consulta As String

            'Dim TIPO_DOC As String
            Dim NUM_DOC As String
            Dim GLN_CLIENTE As String
            Dim GLN_PROVEEDOR As String
            Dim COD_INTER_PROVEE As String
            Dim FECHA_DOC As String
            Dim FECHA_ENTREGA As String
            Dim GLN_DESPACHO As String
            Dim SUBTOTAL As String
            Dim DESCUENTOS As String
            Dim IMPUESTOS As String
            Dim TOTAL As String
            Dim CANT_LINEAS As String
            Dim DEPARTAMENTO As String
            'Dim RUTA_EDIFACT As String
            'Dim FECHA_RECIBO As String
            'Dim FECHA_ENVIO As String
            'Dim FECHA_APERAK As String
            'Dim TOTAL_CANTIDAD As String
            Dim PORCENTAJE_DESC As String
            Dim COMENTARIO As String
            Dim NOMBRE_CLIENTE As String

            'Dim FECHA_RECEP_APERAK As String
            'Dim CARGA_ACCESS As String
            'Dim ENVIADO_AS2 As String
            'Dim EN_PROCESO As String
            'Dim FECHA_AVISO_XLS As String
            'Dim ARCHIVO_ENVIADO As String
            'Dim ENVIAR_A_FACTURA As String
            'Dim BGM011 As String
            'Dim RFFZZZ As String
            'Dim FECHA_ENVIO2 As String
            'Dim INT_ENVIOS As String
            'Dim ERROR_ENVIO As String
            'Dim VERIFICAR_COD As String
            'Dim EVENTO As String
            'Dim TIENE_ERROR_LINEAS As String

            Dim LINEA As String
            Dim COD_INT_ARTIC As String
            Dim COD_ART_PRO As String
            Dim CANTIDAD As String
            Dim PRECIO As String
            Dim IMPUESTO As String
            Dim DESCUENTO As String
            Dim TOTAL_LINEA As String
            Dim COD_BARRA As String
            Dim TOTAL_GENERAL As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            NUM_DOC = tblPedido.Rows(0).Item("NumeroOrden")
            GLN_PROVEEDOR = tblPedido.Rows(0).Item("GLN_proveedor")
            COD_INTER_PROVEE = tblPedido.Rows(0).Item("CodigoInternoProv")
            FECHA_DOC = tblPedido.Rows(0).Item("FechaOrden")
            FECHA_ENTREGA = tblPedido.Rows(0).Item("FECHA_ENTREGA")
            GLN_DESPACHO = tblPedido.Rows(0).Item("GLNDespacho")
            GLN_CLIENTE = tblPedido.Rows(0).Item("GLNCliente")
            SUBTOTAL = tblPedido.Rows(0).Item("Subtotal")
            DESCUENTOS = tblPedido.Rows(0).Item("Descuento")
            IMPUESTOS = tblPedido.Rows(0).Item("Impuesto")
            TOTAL = tblPedido.Rows(0).Item("Total")
            CANT_LINEAS = tblPedido.Rows.Count 'tblPedido.Rows(0).Item("CantidadLine")
            DEPARTAMENTO = tblPedido.Rows(0).Item("Departamento")
            PORCENTAJE_DESC = tblPedido.Rows(0).Item("PorcentajeDescuento")
            COMENTARIO = tblPedido.Rows(0).Item("Observaciones")
            NOMBRE_CLIENTE = tblPedido.Rows(0).Item("NombreCliente")


            Consulta = ""

            Consulta = "INSERT INTO [Armonia_EDIFACT].[dbo].[HISTORICO_ORDENES]
           ([TIPO_DOC]
           ,[NUM_DOC]
           ,[GLN_CLIENTE]
           ,[GLN_PROVEEDOR]
           ,[COD_INTER_PROVEE]
           ,[FECHA_DOC]
           ,[FECHA_ENTREGA]
           ,[GLN_DESPACHO]
           ,[SUBTOTAL]
           ,[DESCUENTOS]
           ,[IMPUESTOS]
           ,[TOTAL]
           ,[CANT_LINEAS]
           ,[DEPARTAMENTO]      
           ,[PORCENTAJE_DESC]
           ,[COMENTARIOS]
           ,[NOMBRE_CLIENTE]
           ,[INT_ENVIOS]
          )
     VALUES
           ('ORDERS'
           ,'" & NUM_DOC & "'
           ,'" & GLN_CLIENTE & "'
           ,'" & GLN_PROVEEDOR & "'
           ,'" & COD_INTER_PROVEE & "'
           ,'" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(FECHA_DOC) & "'
           ,'" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(FECHA_ENTREGA) & "'
           ,'" & GLN_DESPACHO & "'
           ,'" & SUBTOTAL & "'
           ,'" & DESCUENTOS & "'
           ,'" & IMPUESTOS & "'
           ,'" & TOTAL & "'
           ,'" & CANT_LINEAS & "'
           ,'" & DEPARTAMENTO & "'          
           ,'" & PORCENTAJE_DESC & "'
           ,'" & COMENTARIO & "'
           ,'" & NOMBRE_CLIENTE & "'
           ,'0')"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            'SQL_Comman = Nothing

            '+++ DEBE RECORRER LA TABLA INSERTANDO CADA REGISTRO 
            Dim contardor As Integer = 0

            While contardor < tblPedido.Rows.Count
                LINEA = tblPedido.Rows(contardor).Item("Detalle_Linea")
                COD_INT_ARTIC = tblPedido.Rows(contardor).Item("Detalle_Cod_INT_ARTIC")
                COD_ART_PRO = tblPedido.Rows(contardor).Item("Detalle_COD_ART_PRO")
                CANTIDAD = tblPedido.Rows(contardor).Item("Detalle_Cantidad")
                PRECIO = tblPedido.Rows(contardor).Item("Detalle_Precio")
                IMPUESTO = tblPedido.Rows(contardor).Item("Detalle_Impuesto")
                DESCUENTO = tblPedido.Rows(contardor).Item("Detalle_Descuento")
                TOTAL_LINEA = tblPedido.Rows(contardor).Item("Detalle_Total")
                COD_BARRA = tblPedido.Rows(0).Item("Detalle_COD_BARRA")
                TOTAL_GENERAL = tblPedido.Rows(contardor).Item("Detalle_TOTAL_GENERAL")


                Consulta = ""
                Consulta = "INSERT INTO [Armonia_EDIFACT].[dbo].[DETALLES]
                   ([NUM_DOC]
                   ,[LINEA]
                   ,[GLN_PROVEEDOR]
                   ,[GLN_CLIENTE]
                   ,[TIPO_DOC]
                   ,[COD_INT_ARTIC]
                   ,[COD_ART_PRO]
                   ,[COD_ARTIC]
                   ,[COD_BARRA]
                   ,[CANTIDAD]
                   ,[PRECIO]
                   ,[TOTAL_LINEA]
                   ,[IMPUESTO]
                   ,[DESCUENTO]
                   ,[TOTAL_GENERAL]
                   ,[CANTIDAD_CAJA_EDI ]
                  )
             VALUES
                   (" & NUM_DOC & "      
                   ," & LINEA & "  
                   ,'" & GLN_PROVEEDOR & "'
                   ,'" & GLN_CLIENTE & "'
                   ,'ORDERS'
                   ," & COD_INT_ARTIC & "      
                   ," & COD_ART_PRO & "  
                   ," & COD_ART_PRO & " 
                   ," & COD_BARRA & "  
                   ," & CANTIDAD & "      
                   ," & PRECIO & "      
                   ," & TOTAL_LINEA & "      
                   ," & IMPUESTO & "      
                   ," & DESCUENTO & "        
                   ," & TOTAL_GENERAL & "  
                   ,'0'
                    )"

                SQL_Comman.CommandText = Consulta
                SQL_Comman.ExecuteNonQuery()


                LINEA = ""

                COD_INT_ARTIC = ""
                COD_ART_PRO = ""
                COD_BARRA = ""
                CANTIDAD = ""
                PRECIO = ""
                TOTAL_LINEA = ""
                IMPUESTO = ""
                DESCUENTO = ""

                contardor += 1
            End While

            SQL_Comman = Nothing

            Return False
        Catch ex As Exception
            MessageBox.Show("ERROR en InsertaPedidoReckitt [ " & ex.Message & " ]")
            Return True
        End Try
    End Function
    'Public Function GuardaPedidoReckitt(ByVal SQL_Comman As SqlCommand, ByVal tblPedido As DataTable)
    '    Try

    '        Dim Consulta As String

    '        'Dim GLN_CLIENTE As String
    '        'Dim TIPO_DOC As String
    '        'Dim NUM_DOC As String
    '        'Dim LINEA As String
    '        'Dim COD_INT_ARTIC As String
    '        'Dim COD_ARTIC As String
    '        'Dim GLN_PROVEEDOR As String
    '        'Dim COD_ART_PRO As String
    '        'Dim CANTIDAD As String
    '        'Dim CANTIDAD_ENTREGA As String
    '        'Dim PRECIO As String
    '        'Dim TOTAL_LINEA As String
    '        'Dim IMPUESTO As String
    '        'Dim DESCUENTO As String
    '        'Dim TOTAL_GENERAL As String
    '        'Dim GLN_LOCALIZA As String
    '        'Dim CANTIDAD_RECIBO As String
    '        'Dim COD_ARTIC_ORI As String
    '        'Dim CANTIDAD_CAJA As String
    '        'Dim MOTIVO_NO_DESPACHO As String
    '        'Dim DESCRIPCION As String
    '        'Dim COD_INTERNO As String
    '        'Dim COD_BARRA As String
    '        'Dim PAGA_IV As String
    '        'Dim EMPAQUE As String
    '        'Dim CANTIDAD_CAJA_EDI As String



    '        Dim GLN_CLIENTE As String
    '        Dim TIPO_DOC As String
    '        Dim NUM_DOC As String
    '        Dim LINEA As String
    '        Dim COD_INT_ARTIC As String
    '        Dim COD_ARTIC As String
    '        Dim GLN_PROVEEDOR As String
    '        Dim COD_ART_PRO As String
    '        Dim CANTIDAD As String
    '        Dim CANTIDAD_ENTREGA As String
    '        Dim PRECIO As String
    '        Dim TOTAL_LINEA As String
    '        Dim IMPUESTO As String
    '        Dim DESCUENTO As String
    '        Dim TOTAL_GENERAL As String
    '        Dim GLN_LOCALIZA As String
    '        Dim CANTIDAD_RECIBO As String
    '        Dim COD_ARTIC_ORI As String
    '        Dim CANTIDAD_CAJA As String
    '        Dim MOTIVO_NO_DESPACHO As String
    '        Dim DESCRIPCION As String
    '        Dim COD_INTERNO As String
    '        Dim COD_BARRA As String
    '        Dim PAGA_IV As String
    '        Dim EMPAQUE As String
    '        Dim CANTIDAD_CAJA_EDI As String


    '        NUM_DOC = tblPedido.Rows(0).Item("NumeroOrden")
    '        GLN_PROVEEDOR = tblPedido.Rows(0).Item("GLN_proveedor")
    '        tblPedido.Rows(0).Item("CodigoInternoProv")
    '        tblPedido.Rows(0).Item("FechaOrden")
    '        tblPedido.Rows(0).Item("FECHA_ENTREGA")
    '        tblPedido.Rows(0).Item("GLNDespacho")
    '        tblPedido.Rows(0).Item("GLNCliente")
    '        tblPedido.Rows(0).Item("Subtotal")
    '        tblPedido.Rows(0).Item("Descuento")
    '        tblPedido.Rows(0).Item("Impuesto")
    '        tblPedido.Rows(0).Item("Total")
    '        tblPedido.Rows(0).Item("CantidadLine")
    '        tblPedido.Rows(0).Item("Departamento")
    '        tblPedido.Rows(0).Item("PorcentajeDescuento")
    '        tblPedido.Rows(0).Item("Observaciones")
    '        tblPedido.Rows(0).Item("NombreCliente")
    '        tblPedido.Rows(0).Item("Detalle_Linea")
    '        tblPedido.Rows(0).Item("Detalle_Cod_INT_ARTIC")
    '        tblPedido.Rows(0).Item("Detalle_COD_ART_PRO")
    '        tblPedido.Rows(0).Item("Detalle_Cantidad")
    '        tblPedido.Rows(0).Item("Detalle_Precio")
    '        tblPedido.Rows(0).Item("Detalle_Impuesto")
    '        tblPedido.Rows(0).Item("Detalle_Descuento")
    '        tblPedido.Rows(0).Item("Detalle_Total")

    '        'GLN_CLIENTE = tblPedido..Rows(0).Item("GLN_CLIENTE")
    '        'TIPO_DOC = tblPedido..Rows(0).Item("TIPO_DOC")
    '        'NUM_DOC = tblPedido..Rows(0).Item("NUM_DOC")
    '        'LINEA = tblPedido..Rows(0).Item("LINEA")
    '        'COD_INT_ARTIC = tblPedido..Rows(0).Item("COD_INT_ARTIC")
    '        'COD_ARTIC = tblPedido..Rows(0).Item("COD_ARTIC")
    '        'GLN_PROVEEDOR = tblPedido..Rows(0).Item("GLN_PROVEEDOR")
    '        'COD_ART_PRO = tblPedido..Rows(0).Item("COD_ART_PRO")
    '        'CANTIDAD = tblPedido..Rows(0).Item("CANTIDAD")
    '        'CANTIDAD_ENTREGA = tblPedido..Rows(0).Item("CANTIDAD_ENTREGA")
    '        'PRECIO = tblPedido..Rows(0).Item("PRECIO")
    '        'TOTAL_LINEA = tblPedido..Rows(0).Item("TOTAL_LINEA")
    '        'IMPUESTO = tblPedido..Rows(0).Item("IMPUESTO")
    '        'DESCUENTO = tblPedido..Rows(0).Item("DESCUENTO")
    '        'TOTAL_GENERAL = tblPedido..Rows(0).Item("TOTAL_GENERAL")
    '        'GLN_LOCALIZA = tblPedido..Rows(0).Item("GLN_LOCALIZA")
    '        'CANTIDAD_RECIBO = tblPedido..Rows(0).Item("CANTIDAD_RECIBO")
    '        'COD_ARTIC_ORI = tblPedido..Rows(0).Item("COD_ARTIC_ORI")
    '        'CANTIDAD_CAJA = tblPedido..Rows(0).Item("CANTIDAD_CAJA")
    '        'MOTIVO_NO_DESPACHO = tblPedido..Rows(0).Item("MOTIVO_NO_DESPACHO")
    '        'DESCRIPCION = tblPedido..Rows(0).Item("DESCRIPCION")
    '        'COD_INTERNO = tblPedido..Rows(0).Item("COD_INTERNO")
    '        'COD_BARRA = tblPedido..Rows(0).Item("COD_BARRA")
    '        'PAGA_IV = tblPedido..Rows(0).Item("PAGA_IV")
    '        'EMPAQUE = tblPedido..Rows(0).Item("EMPAQUE")
    '        'CANTIDAD_CAJA_EDI = tblPedido..Rows(0).Item("CANTIDAD_CAJA_EDI")

    '        'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

    '        Consulta = ""
    '        Consulta = "INSERT INTO [dbo].[DETALLES]
    '       ([GLN_CLIENTE]
    '       ,[TIPO_DOC]
    '       ,[NUM_DOC]
    '       ,[LINEA]
    '       ,[COD_INT_ARTIC]
    '       ,[COD_ARTIC]
    '       ,[GLN_PROVEEDOR]
    '       ,[COD_ART_PRO]
    '       ,[CANTIDAD]
    '       ,[CANTIDAD_ENTREGA]
    '       ,[PRECIO]
    '       ,[TOTAL_LINEA]
    '       ,[IMPUESTO]
    '       ,[DESCUENTO]
    '       ,[TOTAL_GENERAL]
    '       ,[GLN_LOCALIZA]
    '       ,[CANTIDAD_RECIBO]
    '       ,[COD_ARTIC_ORI]
    '       ,[CANTIDAD_CAJA]
    '       ,[MOTIVO_NO_DESPACHO]
    '       ,[DESCRIPCION]
    '       ,[COD_INTERNO]
    '       ,[COD_BARRA]
    '       ,[PAGA_IV]
    '       ,[EMPAQUE]
    '       ,[CANTIDAD_CAJA_EDI])
    ' VALUES
    '       (" & GLN_CLIENTE & "      
    '       ," & TIPO_DOC & "      
    '       ," & NUM_DOC & "      
    '       ," & LINEA & "      
    '       ," & COD_INT_ARTIC & "      
    '       ," & COD_ARTIC & "      
    '       ," & GLN_PROVEEDOR & "      
    '       ," & COD_ART_PRO & "      
    '       ," & CANTIDAD & "      
    '       ," & CANTIDAD_ENTREGA & "      
    '       ," & PRECIO & "      
    '       ," & TOTAL_LINEA & "      
    '       ," & IMPUESTO & "      
    '       ," & DESCUENTO & "      
    '       ," & TOTAL_GENERAL & "      
    '       ," & GLN_LOCALIZA & "      
    '       ," & CANTIDAD_RECIBO & "      
    '       ," & COD_ARTIC_ORI & "      
    '       ," & CANTIDAD_CAJA & "      
    '       ," & MOTIVO_NO_DESPACHO & "      
    '       ," & DESCRIPCION & "      
    '       ," & COD_INTERNO & "      
    '       ," & COD_BARRA & "      
    '       ," & PAGA_IV & "      
    '       ," & EMPAQUE & "      
    '       ," & CANTIDAD_CAJA_EDI & " )"

    '        SQL_Comman.CommandText = Consulta
    '        SQL_Comman.ExecuteNonQuery()
    '        SQL_Comman = Nothing

    '        Consulta = "INSERT INTO [dbo].[HISTORICO_ORDENES]
    '              ([TIPO_DOC]
    '              ,[NUM_DOC]
    '              ,[GLN_CLIENTE]
    '              ,[GLN_PROVEEDOR]
    '              ,[COD_INTER_PROVEE]
    '              ,[FECHA_DOC]
    '              ,[FECHA_ENTREGA]
    '              ,[GLN_DESPACHO]
    '              ,[SUBTOTAL]
    '              ,[DESCUENTOS]
    '              ,[IMPUESTOS]
    '              ,[TOTAL]
    '              ,[CANT_LINEAS]
    '              ,[DEPARTAMENTO]
    '              ,[RUTA_EDIFACT]
    '              ,[FECHA_RECIBO]
    '              ,[FECHA_ENVIO]
    '              ,[FECHA_APERAK]
    '              ,[TOTAL_CANTIDAD]
    '              ,[PORCENTAJE_DESC]
    '              ,[FECHA_RECEP_APERAK]
    '              ,[CARGA_ACCESS]
    '              ,[ENVIADO_AS2]
    '              ,[EN_PROCESO]
    '              ,[FECHA_AVISO_XLS]
    '              ,[ARCHIVO_ENVIADO]
    '              ,[ENVIAR_A_FACTURA]
    '              ,[BGM011]
    '              ,[RFFZZZ]
    '              ,[FECHA_ENVIO2]
    '              ,[INT_ENVIOS]
    '              ,[ERROR_ENVIO]
    '              ,[VERIFICAR_COD]
    '              ,[EVENTO]
    '              ,[TIENE_ERROR_LINEAS])
    '        VALUES
    '              (" & TIPO_DOC & "                      
    '              ," & NUM_DOC & "                      
    '              ," & GLN_CLIENTE & "                      
    '              ," & GLN_PROVEEDOR & "                      
    '              ," & COD_INTER_PROVEE & "                      
    '              ," & FECHA_DOC & "                      
    '              ," & FECHA_ENTREGA & "                      
    '              ," & GLN_DESPACHO & "                      
    '              ," & SUBTOTAL & "                      
    '              ," & DESCUENTOS & "                      
    '              ," & IMPUESTOS & "                      
    '              ," & TOTAL & "                      
    '              ," & CANT_LINEAS & "           
    '              ," & DEPARTAMENTO & "                      
    '              ," & RUTA_EDIFACT & "                     
    '              ," & FECHA_RECIBO & "                      
    '              ," & FECHA_ENVIO & "                      
    '              ," & FECHA_APERAK & "                      
    '              ," & TOTAL_CANTIDAD & "                      
    '              ," & PORCENTAJE_DESC & "                      
    '              ," & FECHA_RECEP_APERAK & "                      
    '              ," & CARGA_ACCESS & "                      
    '              ," & ENVIADO_AS2 & "                      
    '              ," & EN_PROCESO & "           
    '              ," & FECHA_AVISO_XLS & "                      
    '              ," & ARCHIVO_ENVIADO & "                     
    '              ," & ENVIAR_A_FACTURA & "                      
    '              ," & BGM011 & "                      
    '              ," & RFFZZZ & "                      
    '              ," & FECHA_ENVIO2 & "                      
    '              ," & INT_ENVIOS & "           
    '              ," & ERROR_ENVIO & "                     
    '              ," & VERIFICAR_COD & "           
    '              ," & EVENTO & "                     
    '              ," & TIENE_ERROR_LINEAS & " )"

    '        SQL_Comman.CommandText = Consulta
    '        SQL_Comman.ExecuteNonQuery()
    '        SQL_Comman = Nothing


    '    Catch ex As Exception
    '        MessageBox.Show("ERROR en GUARDA_ReporteCargaXSector [ " & ex.Message & " ]")
    '    End Try

    'End Function
    Public Function ObtienePedidoReckitt(ByVal SQL_Comman As SqlCommand, ByVal NumAtCard As String)

        'Consulta el pedido segun el consecutivo de sincro el cual caen en el campo de NumAtCard de SAP
        'como numero de referencia
        Dim ADATER As New SqlDataAdapter
        Dim TABLA As New DataTable
        Dim Consulta As String
        Consulta = "SELECT NumeroOrden
                            ,GLN_proveedor
                            ,CodigoInternoProv
                            ,FechaOrden
                            ,FECHA_ENTREGA
                            ,GLNDespacho
                            ,GLNCliente
                            ,Subtotal
                            ,Descuento
                            ,Impuesto
                            ,Total
                            ,CantidadLine
                            ,Departamento
                            ,PorcentajeDescuento
                            ,Observaciones
                            ,NombreCliente
                            ,Detalle_Linea
                            ,Detalle_Cod_INT_ARTIC
                            ,Detalle_COD_ART_PRO
                            ,Detalle_Cantidad
                            ,Detalle_Precio
                            ,Detalle_Impuesto
		                    ,Detalle_Descuento
		                    ,Detalle_Total
                            ,Detalle_COD_BARRA
                            ,Detalle_TOTAL_GENERAL
                    FROM Armonia_EDIFACT.[dbo].fn_ObtienePedidoReckitt('" & NumAtCard & "')
                              ORDER BY Detalle_Cod_INT_ARTIC ASC"

        ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
        ADATER.Fill(TABLA)

        If TABLA.Rows.Count = 0 Then
            Return "0"
        Else
            Return TABLA
        End If

    End Function
    Public Function PedidoCreadoEnSAP(ByVal SQL_Comman As SqlCommand, NumDoc As String)
        Try
            Dim Consulta As String
            Consulta = "UPDATE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Pedidor] SET " &
                       "[CreadoSAP] ='1' " &
                       "WHERE [NumDoc] ='" & NumDoc & "' "

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en PedidoCreadoEnSAP [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function AnularPedido(ByVal SQL_Comman As SqlCommand, NumDoc As String)
        Try
            Dim Consulta As String
            Consulta = "UPDATE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Pedidor] SET " &
                       "[Cerrado] ='1' " &
                       "WHERE [NumDoc] ='" & NumDoc & "' "

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en AnularPedido [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ObtieneOrdenes(ByVal SQL_Comman As SqlCommand, FechaIni As String, FechaFin As String, CodProveedor As String, DocNum As String, Chequeados As Boolean)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim IncluirAnd As Boolean = False 'controla la incrustacion del AND para los filtros


            Consulta = "SELECT T0.[NumDoc],T0.[Fecha],T0.CardCode ,T0.NombreProveedor  FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Pedidor] T0 WHERE  "


            If FechaIni <> "" Or FechaFin <> "" Then
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If
                Consulta = Consulta & " Fecha between '" & FechaIni & "' and '" & FechaFin & "'"
            End If

            If CodProveedor <> "" Then
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If
                Consulta = Consulta & " CardCode ='" & CodProveedor & "'"
            End If
            If DocNum <> "" Then
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If
                Consulta = Consulta & " T0.[NumDoc] ='" & DocNum & "'"
            End If

            'busca los pedido chequeados
            'If Chequeados = True Then
            '    If IncluirAnd = False Then
            '        IncluirAnd = True
            '    Else
            '        Consulta = Consulta & " and "
            '    End If
            '    Consulta = Consulta & " T0.[Chequeado] ='1'"
            'Else

            'End If

            If IncluirAnd = False Then
                IncluirAnd = True
            Else
                Consulta = Consulta & " and "
            End If
            Consulta = Consulta & " Cerrado='0'  GROUP BY T0.CardCode ,T0.[Fecha],T0.NombreProveedor,T0.[NumDoc] order by T0.[NumDoc]  desc"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneOrdenes [ " & ex.Message & " ]")
        End Try
    End Function

#Region "Carga inventario"
    Public Function Articulos_Mobile(ByVal TABLA As DataTable, ByVal SQL_Comman1 As SqlCommand)
        Try


            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = "SELECT * FROM Inventario"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman1.Connection)
            ADATER.Fill(TABLA)

            'Obj_SQLSERVER.Desconectar()

            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing

            Return TABLA
        Catch ex As Exception
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR Articulos_Mobile ( " & ex.Message & ")"
        End Try
    End Function

    'CONSULTA LA LISTA DE ARTICULOS RESTRINGIDOS EN UN RUTA
    Public Function ArticulosRestringidos_Mobile(ByVal Ruta As String, ByVal TABLA As DataTable, ByVal SQL_Comman1 As SqlCommand)
        Try
            Dim ADATER As New SqlDataAdapter


            Dim Consulta As String = "SELECT [Cod_Articulo] " &
                                     "FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Casas_Restringidas_X_RUTA] " &
                                     " WHERE [RUTA] = " & Ruta

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman1.Connection)
            ADATER.Fill(TABLA)
            'Obj_SQLSERVER.Desconectar()

            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing

            Return TABLA

        Catch ex As Exception
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ArticulosRestringidos_Mobile ( " & ex.Message & ")"
        End Try

    End Function
    'CONSULTA LA LISTA DE ARTICULOS RESTRINGIDOS EN UN RUTA
    Public Function ArticulosPermitidosDeCasaRestringida(ByVal Ruta As String, ByVal TABLA As DataTable, ByVal SQL_Comman1 As SqlCommand)
        Try
            Dim ADATER As New SqlDataAdapter


            Dim Consulta As String = "SELECT [Cod_Articulo] " &
                                     "FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[LineasPermitidasEnCasaRestringida] " &
                                     " WHERE [RUTA] = " & Ruta

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman1.Connection)
            ADATER.Fill(TABLA)

            'Obj_SQLSERVER.Desconectar()

            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            Return TABLA

        Catch ex As Exception
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ArticulosPermitidosDeCasaRestringida ( " & ex.Message & ")"
        End Try

    End Function
#End Region

    Public Function ObtieneConseOrdenCompra(ByVal SQL_Comman As SqlCommand)
        Try

            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            'Consulta = "SELECT top 1 T0.[DocNum]+1 as DocNum FROM  "&  Class_VariablesGlobales.XMLParamSAP_CompanyDB  &".[dbo].OPOR T0 WHERE T0.[Series]='12' ORDER BY T0.[DocNum] desc"

            Consulta = "SELECT top 1 T0.ID FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Pedidor] T0 order by T0.ID desc"


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            '  Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            If TABLA.Rows.Count = 0 Then
                Return "1"
            Else
                Return TABLA.Rows(0).Item("ID")
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneConseOrdenCompra [ " & ex.Message & " ]")
        End Try
    End Function
    'Public Function AumentaConseOrdenCompra(ByVal SQL_Comman As SqlCommand, ByVal Consecutivo As String)
    '    Try

    '        ' Dim SQL_Comman As New SqlCommand
    '        ' para la conexion al comman
    '        ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
    '        Dim ADATER As New SqlDataAdapter
    '        Dim TABLA As New DataTable
    '        Dim Consulta As String = ""

    '        'Consulta = "SELECT top 1 T0.[DocNum]+1 as DocNum FROM  "&  Class_VariablesGlobales.XMLParamSAP_CompanyDB  &".[dbo].OPOR T0 WHERE T0.[Series]='12' ORDER BY T0.[DocNum] desc"
    '        Consulta = "UPDATE "&  Class_VariablesGlobales.XMLParamSQL_dababase  &".[dbo].[OrdenCompraProveedor] SET ID='" & Consecutivo & "'"
    '        ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
    '        ADATER.Fill(TABLA)

    '        '  Obj_SQL_CONEXION.Desconectar(SQL_Comman)

    '        If TABLA.Rows.Count = 0 Then
    '            Return "1"
    '        Else
    '            Return TABLA.Rows(0).Item("ID")
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show("ERROR en AumentaConseOrdenCompra [ " & ex.Message & " ]")
    '    End Try
    'End Function

    Public Function ObtieneReportes(ByVal SQL_Comman As SqlCommand)
        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "SELECT  [Fecha],[Consecutivo],[FacINI],[FacFIN] FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Rep_Devo] group by [Fecha],[Consecutivo],[FacINI],[FacFIN]"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            '  Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en Consulta_Estado [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function ConsultaRepDevo(ByVal Consecutivo As String, ByVal SQL_Comman As SqlCommand, ByVal Accion As String)
        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            '  SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            If Accion <> "" Then
                Consulta = "SELECT  * FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Rep_Devo] where [Consecutivo]='" & Consecutivo & "' and [Accion]='" & Accion & "'"
            Else
                Consulta = "SELECT  * FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Rep_Devo] where [Consecutivo]='" & Consecutivo & "'"
            End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en Consulta_Estado [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function Consulta_Estado(ByVal Agente As String, ByVal SQL_Comman As SqlCommand)
        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            '   SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "Select [Nuevo2] FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Tbl_Alertar] WHERE [Agente] = " & Agente

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en Consulta_Estado [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function Consulta_EstadoError_SubidaSAP(ByVal AGENTE As String, ByVal SQL_Comman As SqlCommand)
        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            '  SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            If AGENTE <> "" Then
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Estado] = 'ERROR' AND [Agente] = '" & AGENTE & "' order by [Agente] asc "
            Else
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Estado] = 'ERROR'  order by [Agente] asc "
            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA

        Catch ex As Exception
            MessageBox.Show("ERROR en Consulta_EstadoError_SubidaSAP [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function Consulta_EstadoSubidos_SubidaSAP(ByVal AGENTE As String, ByVal SQL_Comman As SqlCommand)
        Try
            '  Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            If AGENTE <> "" Then
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Estado] = 'SUBIDO' AND [Agente] = '" & AGENTE & "' order by [Agente] asc  "
            Else
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Estado] = 'SUBIDO' order by [Agente] asc  "
            End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en Consulta_EstadoSubidos_SubidaSAP [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function Consulta_Estado_SubidaSAP(ByVal AGENTE As String, ByVal SQL_Comman As SqlCommand)
        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            If AGENTE <> "" Then
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Agente] = '" & AGENTE & "' order by [Agente] asc"
            Else
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] order by [Agente] asc"
            End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en Consulta_Estado_SubidaSAP [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function ObtieneElultimoConRepCarga(ByVal SQL_Comman As SqlCommand)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim max As Integer = 0
            Consulta = "SELECT MAX(Consecutivo)as Consecutivo FROM Rep_Carg_Sector"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            For Each row As DataRow In TABLA.Rows
                max = CInt(TABLA.Rows(0).Item("Consecutivo").ToString())
            Next


            Return max
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneElultimoConRepCarga [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function CambiaStadoACorregido(ByVal Consecutivo As String, ByVal SQL_Comman As SqlCommand)

        Try
            Dim Consulta As String = ""
            Consulta = "UPDATE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Rep_Devo] SET Corregido='1' WHERE [Consecutivo] = '" & Consecutivo & "' "
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing

            Return 0

        Catch ex As Exception
            Return 1
            MessageBox.Show("ERROR en AnulaRepDevoluciones [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function AnulaRepDevoluciones(ByVal SQL_Comman As SqlCommand, ByVal Consecutivo As String)

        Try
            Dim Consulta As String = ""
            Consulta = "UPDATE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Rep_Devo] SET Anulado='1' WHERE [Consecutivo] = '" & Consecutivo & "' "
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing

            Return 0

        Catch ex As Exception
            Return 1
            MessageBox.Show("ERROR en AnulaRepDevoluciones [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function AnulaRepCarga(ByVal Consecutivo As String, ByVal SQL_Comman As SqlCommand)

        Try
            Dim Consulta As String = ""

            Consulta = "UPDATE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Rep_Carg_Sector] SET Anulado='1' WHERE [Consecutivo] = '" & Consecutivo & "' "

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()

            SQL_Comman = Nothing
            Return 0

        Catch ex As Exception
            Return 1
            MessageBox.Show("ERROR en EliminaRepCarga [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function EliminaListaEstadoErroSAP(ByVal AGENTE As String, ByVal SQL_Comman As SqlCommand)

        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            If AGENTE <> "" Then
                Consulta = "DELETE FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Estado] = 'ERROR' AND [Agente] = '" & AGENTE & "' "
            Else
                Consulta = "DELETE FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Estado] = 'ERROR'"
            End If

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()


            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en EliminaListaEstadoErroSAP [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function EliminaListaEstadoSubidoSAP(ByVal AGENTE As String, ByVal SQL_Comman As SqlCommand)

        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            If AGENTE <> "" Then
                Consulta = "DELETE FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Estado] = 'SUBIDO' AND [Agente] = '" & AGENTE & "'"
            Else
                Consulta = "DELETE FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Estado] = 'SUBIDO'"
            End If

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()


            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en EliminaListaEstadoSubidoSAP [ " & ex.Message & " ]")
        End Try
    End Function



    'ESTADOS DE PEDIDOS
    Public Function PedidosTODOS(ByVal AGENTE As String, ByVal SQL_Comman As SqlCommand)
        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            If AGENTE <> "" Then
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Archivo] = 'pedidos.mbg' AND [Agente] = '" & AGENTE & "' order by [Agente] asc"
            Else
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Archivo] = 'pedidos.mbg'  order by [Agente] asc"
            End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en PedidosTODOS [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function PedidosConError(ByVal AGENTE As String, ByVal SQL_Comman As SqlCommand)
        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            If AGENTE <> "" Then
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Archivo] = 'pedidos.mbg' AND [Estado] = 'ERROR' AND [Agente] = '" & AGENTE & "' order by [Consecutivo] asc "
            Else
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Archivo] = 'pedidos.mbg' AND [Estado] = 'ERROR' order by [Agente] asc "
            End If



            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en PedidosConError [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function PedidosSUBIDOS(ByVal AGENTE As String, ByVal SQL_Comman As SqlCommand)
        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            '  SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            If AGENTE <> "" Then
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP]  WHERE [Archivo] = 'pedidos.mbg' AND [Estado] = 'SUBIDO' AND [Agente] = '" & AGENTE & "' order by [Agente] asc"
            Else
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP]  WHERE [Archivo] = 'pedidos.mbg' AND [Estado] = 'SUBIDO' order by [Agente] asc"
            End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en PedidosSUBIDOS [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function PedidosEliminaEstadoSUBIDO(ByVal AGENTE As String, ByVal SQL_Comman As SqlCommand)

        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            If AGENTE <> "" Then
                Consulta = "DELETE FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Archivo] = 'pedidos.mbg' AND [Estado] = 'SUBIDO' AND [Agente] = '" & AGENTE & "'"
            Else
                Consulta = "DELETE FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Archivo] = 'pedidos.mbg' AND [Estado] = 'SUBIDO'"
            End If

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()


            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en PedidosEliminaEstadoSUBIDO [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function PedidosEliminaEstadoERROR(ByVal AGENTE As String, ByVal SQL_Comman As SqlCommand)

        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            If AGENTE <> "" Then
                Consulta = "DELETE FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Archivo] = 'pedidos.mbg' AND [Estado] = 'ERROR' AND [Agente] = '" & AGENTE & "'"
            Else
                Consulta = "DELETE FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Archivo] = 'pedidos.mbg' AND [Estado] = 'ERROR'"
            End If


            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()


            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en Consulta_Estado_SubidaSAP [ " & ex.Message & " ]")
        End Try

    End Function

    'ESTADOS DE PAGOS
    Public Function PagosTODOS(ByVal AGENTE As String, ByVal SQL_Comman As SqlCommand)
        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            If AGENTE <> "" Then
                Consulta = "SELECT  *FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Archivo] = 'pagos.mbg' AND [Agente] = '" & AGENTE & "' order by [Agente] asc "
            Else
                Consulta = "SELECT  *FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Archivo] = 'pagos.mbg' order by [Agente] asc "
            End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en PagosTODOS [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function PagosConError(ByVal AGENTE As String, ByVal SQL_Comman As SqlCommand)
        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            If AGENTE <> "" Then
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP]  WHERE [Archivo] = 'pagos.mbg' AND [Estado] = 'ERROR' AND [Agente] = '" & AGENTE & "' order by [Agente] asc"
            Else
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP]  WHERE [Archivo] = 'pagos.mbg' AND [Estado] = 'ERROR' order by [Agente] asc"
            End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en PagosConError [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function PagosSUBIDOS(ByVal AGENTE As String, ByVal SQL_Comman As SqlCommand)
        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            If AGENTE <> "" Then
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP]  WHERE [Archivo] = 'pagos.mbg' AND [Estado] = 'SUBIDO' AND [Agente] = '" & AGENTE & "' order by [Agente] asc"
            Else
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP]  WHERE [Archivo] = 'pagos.mbg' AND [Estado] = 'SUBIDO' order by [Agente] asc"
            End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en PagosSUBIDOS [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function PagosEliminaEstadoSUBIDO(ByVal AGENTE As String, ByVal SQL_Comman As SqlCommand)

        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            If AGENTE <> "" Then
                Consulta = "DELETE FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Archivo] = 'pagos.mbg' AND [Estado] = 'SUBIDO' AND [Agente] = '" & AGENTE & "'"
            Else
                Consulta = "DELETE FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Archivo] = 'pagos.mbg' AND [Estado] = 'SUBIDO'"
            End If

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()


            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en PagosEliminaEstadoSUBIDO [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function PagosEliminaEstadoERROR(ByVal AGENTE As String, ByVal SQL_Comman As SqlCommand)

        Try
            '  Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            If AGENTE <> "" Then
                Consulta = "DELETE FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Archivo] = 'pagos.mbg' AND [Estado] = 'ERROR' AND [Agente] = '" & AGENTE & "'"
            Else
                Consulta = "DELETE FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP] WHERE [Archivo] = 'pagos.mbg' AND [Estado] = 'ERROR'"
            End If

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()


            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en PagosEliminaEstadoERROR [ " & ex.Message & " ]")
        End Try

    End Function

    Public Function CambiaEstadoReinsertar(ByVal Consecutivo As String, ByVal Archivo As String, ByVal SQL_Comman As SqlCommand)
        Try
            Dim Obj_SQL_CONEXION As New CONEXION_TO_SQLSERVER
            ' Dim SQL_Comman As New SqlCommand
            '  SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")

            Dim cont As Integer = 0
            ' para la conexion al comman

            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""

            'Actualiza el estado dependiendo del numero de aplicacion que sea
            Consulta = "UPDATE  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Estado_Subida_SAP]" & _
                       "SET  [Reintento] = 1" & _
                       "WHERE [Consecutivo] = '" & Consecutivo & "'"




            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

        Catch ex As Exception
            MessageBox.Show("ERROR en CambiaEstadoReinsertarPedido [ " & ex.Message & " ]")
        End Try
        Return 0
    End Function

    Public Function Consulta_Articulos(ByVal Codigo As String, ByVal Descripcion As String, ByVal SQL_Comman As SqlCommand)
        Try
            'Dim SQL_Comman As New SqlCommand
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            If Codigo <> "" Then
                Consulta = "SELECT [ItemCode],[ItemName],[existencia] FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[View_Articulos] WHERE [ItemCode] LIKE '%" & Codigo & "%'"
            ElseIf Descripcion <> "" Then
                Consulta = "SELECT [ItemCode],[ItemName],[existencia] FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[View_Articulos] WHERE [ItemName] LIKE '%" & Descripcion & "%'"
            Else
                Consulta = "SELECT [ItemCode],[ItemName],[existencia] FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[View_Articulos]"
            End If
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA

        Catch ex As Exception
            MessageBox.Show("ERROR en Consulta_UltimosConsecutivos_SAP [ " & ex.Message & " ]")
        End Try

    End Function

    Public Function Actualiza_InfoNOARCHIVO_FTP(ByVal SQL_Comman As SqlCommand)
        Try

            Dim Obj_SQL_CONEXION As New CONEXION_TO_SQLSERVER
            Dim cont As Integer = 0
            ' para la conexion al comman 
            'Dim SQL_Comman As New SqlCommand
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""

            'Actualiza el estado dependiendo del numero de aplicacion que sea
            Consulta = "UPDATE  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[AlertaFTPAgSolicitado] SET [InfoTransmision] = 0"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

        Catch ex As Exception
            MessageBox.Show("ERROR en Actualiza_InfoNOARCHIVO_FTP [ " & ex.Message & " ]")
        End Try
        Return 0
    End Function

    Public Function Consulta_InfoNOARCHIVO_FTP(ByVal TABLA As DataTable, ByVal SQL_Comman As SqlCommand)
        Try
            'Dim SQL_Comman As New SqlCommand
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""


            Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[AlertaFTPAgSolicitado]"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA


        Catch ex As Exception
            MessageBox.Show("ERROR en Consulta_UltimosConsecutivos_SAP [ " & ex.Message & " ]")
        End Try

    End Function


    Public Function Consulta_UltimosConsecutivos_SAP(ByVal SQL_Comman As SqlCommand)
        Try
            'Dim SQL_Comman As New SqlCommand
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""


            Consulta = "SELECT [id_agente],[Ulti_Consec_Pedidos],[Ulti_Consec_Pagos] ,[Ulti_Consec_Depositos]FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[UltimosConsecutivos]"



            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA

        Catch ex As Exception
            MessageBox.Show("ERROR en Consulta_UltimosConsecutivos_SAP [ " & ex.Message & " ]")
        End Try

    End Function
    'Carga un campo en la DB para indicarle a la aplicacion que genera alertas de pedidos nuevos que suene la alerta de que existe un nuevo pedido
    Public Function Actualiza_Estado_Alerta(ByVal Agente As String, ByVal SQL_Comman As SqlCommand)
        Try


            Dim Obj_SQL_CONEXION As New CONEXION_TO_SQLSERVER
            Dim cont As Integer = 0
            ' para la conexion al comman
            ' Dim SQL_Comman As New SqlCommand
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            'Actualiza el estado dependiendo del numero de aplicacion que sea
            Consulta = "UPDATE  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Tbl_Alertar] SET " & _
                       "[Nuevo2] = '0' " & _
                        "WHERE [Agente] = '" & Agente & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            Return 0
        Catch ex As Exception
            MessageBox.Show("ERROR en Actualiza_Estado_Alerta [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function ModificaConsecutivSistema(ByVal SQL_Comman As SqlCommand, ByVal Consecutivo As Integer)
        Try


            Dim Obj_SQL_CONEXION As New CONEXION_TO_SQLSERVER
            Dim cont As Integer = 0

            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            Consulta = "UPDATE  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Agentes] SET [Conse_Gastos] = '" & Consecutivo & "' WHERE [CodAgente] ='1'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()

            Return 0
        Catch ex As Exception
            MessageBox.Show("ERROR en ModificaConsecutivSistema [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function RecargarTODO(ByVal Agente As String, ByVal SQL_Comman As SqlCommand)
        Try

            If Agente <> "1" Then


                Dim Obj_SQL_CONEXION As New CONEXION_TO_SQLSERVER
                Dim cont As Integer = 0
                ' para la conexion al comman
                'Dim SQL_Comman As New SqlCommand
                'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
                Dim Consulta As String
                'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

                Consulta = ""
                ' Consulta = "UPDATE  "&  Class_VariablesGlobales.XMLParamSQL_dababase  &".[dbo].[UltimosConsecutivos] SET [Ulti_Consec_Pedidos] = '0',[Ulti_Consec_Pagos] = '0',[Ulti_Consec_Depositos] = '0' WHERE [id_agente] ='" & Agente & "'"



                Consulta = "UPDATE  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Agentes] SET [Conse_Pedido] = '0',[Conse_Pagos] = '0',[Conse_Deposito] = '0',[Conse_Gastos] = '0',[Conse_NoVisita] = '0' WHERE [CodAgente] ='" & Agente & "'"


                SQL_Comman.CommandText = Consulta
                SQL_Comman.ExecuteNonQuery()
                ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            End If
            Return 0
        Catch ex As Exception
            MessageBox.Show("ERROR en RecargarTODO [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function ActualizaClaveReactivacion(ByVal codigo As String, ByVal SQL_Comman As SqlCommand)
        Try

            '  Dim SQL_Comman As New SqlCommand
            Dim Obj_SQL_CONEXION As New CONEXION_TO_SQLSERVER
            Dim cont As Integer = 0
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            Consulta = "UPDATE  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[SBS] SET [CBS] = '" & codigo & "'  WHERE ID = 0"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            Return 0
        Catch ex As Exception
            MessageBox.Show("ERROR en ActualizaClaveReactivacion [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function ActualizaUserClave(ByVal user As String, ByVal clave As String, ByVal codigo As String, ByVal SQL_Comman As SqlCommand)
        Try



            Dim cont As Integer = 0
            ' para la conexion al comman
            'Dim SQL_Comman As New SqlCommand
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            Consulta = "UPDATE  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[SBS] SET [UBS] = '" & user & "' ,[PBS] = '" & clave & "' ,[CBS] = '" & codigo & "'  WHERE ID = 0"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            Return 0
        Catch ex As Exception
            MessageBox.Show("ERROR en ActualizaUserClave [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function Consulta_CLAVE(ByVal SQL_Comman As SqlCommand)
        Try
            'Dim SQL_Comman As New SqlCommand
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""


            Consulta = "SELECT [CBS] FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[SBS] where [ID] = 0"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA

        Catch ex As Exception
            MessageBox.Show("ERROR en Consulta_CLAVE [ " & ex.Message & " ]")
        End Try

    End Function



    'Public Function ObtieneTotalesRepFac(ByVal ConBo1 As Boolean, ByVal FacturaINI As String, ByVal FacturaFin As String, ByVal SQL_Comman As SqlCommand)
    '    Try
    '        Dim ADATER As New SqlDataAdapter
    '        Dim TABLA As New DataTable
    '        Dim Consulta As String = ""
    '        Dim Total As Double

    '        If ConBo1 = False Then
    '            Consulta = "SELECT SUM(T0.Contado) AS CONTADO ,SUM(T0.Credito) AS CREDITO , (SUM(T0.Contado)+SUM(T0.Credito)) AS TOTAL FROM (SELECT CASE WHEN Condicion ='-1' then SUM(DocTotal) end 'Contado',CASE WHEN Condicion <> '-1' then SUM(DocTotal) end 'Credito' FROM  " & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & ".[dbo].[Rep_FacturasSinBod1]('" & FacturaINI & "' , '" & FacturaFin & "' )  group by Condicion ) T0"
    '        Else
    '            'Consulta = "SELECT * FROM  "&  Class_VariablesGlobales.XMLParamSQL_dababase  &".[dbo].[Rep_FacturasConBod1]('" & FacturaINI & "' , '" & FacturaFin & "' )  ORDER BY [DocNum] ASC"
    '        End If
    '        ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
    '        ADATER.Fill(TABLA)

    '        For Each row As DataRow In TABLA.Rows
    '            CONTADO = TABLA.Rows(0).Item("CONTADO").ToString()
    '            CREDITO = TABLA.Rows(0).Item("CREDITO").ToString()
    '            Total = TABLA.Rows(0).Item("TOTAL").ToString()
    '        Next



    '        Return TABLA
    '    Catch ex As Exception
    '        MessageBox.Show("ERROR en ObtieneTotalesRepFac [ " & ex.Message & " ]")
    '    End Try
    'End Function


    Public Function ObtieneReporteFacturas(ByVal ConBo1 As Boolean, ByVal FacturaINI As String, ByVal FacturaFin As String, ByVal SQL_Comman As SqlCommand)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Total As Double

            If ConBo1 = False Then
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Rep_FacturasSinBod1]('" & FacturaINI & "' , '" & FacturaFin & "' )  ORDER BY [DocNum] ASC"
            Else
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Rep_FacturasConBod1]('" & FacturaINI & "' , '" & FacturaFin & "' )  ORDER BY [DocNum] ASC"
            End If
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneReporteFacturas [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function ObtieneAgentesReporteFacturas(ByVal ConBo1 As Boolean, ByVal FacturaINI As String, ByVal FacturaFin As String, ByVal SQL_Comman As SqlCommand)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Total As Double

            If ConBo1 = False Then
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Rep_AgentesRepFacturasSinBo1]('" & FacturaINI & "' , '" & FacturaFin & "' )  ORDER BY [SlpCode] ASC"
            Else
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Rep_AgentesRepFacturasConBo1]('" & FacturaINI & "' , '" & FacturaFin & "' )  ORDER BY [SlpCode] ASC"
            End If
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneAgentesReporteFacturas [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function GeneraReporteCarga(ByVal ConBo1 As Boolean, ByVal FacturaINI As String, ByVal FacturaFin As String, ByVal SQL_Comman As SqlCommand)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""



            If ConBo1 = False Then

                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[ReporteDeCargaXSector]('" & FacturaINI & "' , '" & FacturaFin & "' )  ORDER BY [ItemCode] ASC"
            Else
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[ReporteDeCargaXSector_CONBod1]('" & FacturaINI & "' , '" & FacturaFin & "' )  ORDER BY [ItemCode] ASC"
            End If
            'ESTA CONSULTA ES SOLO PARA BARRIDO DE CODIGOS DE BARRA
            'Consulta = "SELECT T0.[ItemCode], T0.[ItemName] as [Descripcion] ,(select U_Ubicacion from  "&  Class_VariablesGlobales.XMLParamSAP_CompanyDB  &".[dbo].[OITM] where ItemCode=T0.ItemCode ) as [sector], '1' [Cantidad],'1' [Total],T0.[U_Gramaje], T0.[PurPackUn] as 'Unidades_x_Caja' ,T0.[CodeBars], '1' [Cajas], '1' [Bodega], '1' [Marca] FROM  "&  Class_VariablesGlobales.XMLParamSAP_CompanyDB  &".[dbo].[OITM] T0 WHERE T0.[ItemName] not like 'DESC%'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return TABLA

        Catch ex As Exception
            MessageBox.Show("ERROR en GeneraReporteCargaXSector [ " & ex.Message & " ]")

            VariablesGlobales.Obj_Log.Log("ERROR en GeneraReporteCargaXSector ('" & FacturaINI & "' , '" & FacturaFin & "' ) [ " & ex.Message & " ]", "MR")
        End Try

    End Function
    Public Function GeneraReporteCargaXSector(ByVal ConBo1 As Boolean, ByVal FacturaINI As String, ByVal FacturaFin As String, ByVal Sector As Integer, ByVal SQL_Comman As SqlCommand)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""


            If (Sector = 0) Then
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Rep_Carg_Sector] WHERE [FacINI] =" & FacturaINI & " AND [FacFIN] =" & FacturaFin & "  ORDER BY [sector] ASC"
            Else
                If ConBo1 = False Then

                    Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[ReporteDeCargaXSector]('" & FacturaINI & "' , '" & FacturaFin & "' ) WHERE [sector] = '" & Sector & "' ORDER BY [sector] ASC"
                Else
                    Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[ReporteDeCargaXSector_CONBod1]('" & FacturaINI & "' , '" & FacturaFin & "' ) WHERE [sector] = '" & Sector & "' ORDER BY [sector] ASC"
                End If
            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return TABLA

        Catch ex As Exception
            MessageBox.Show("ERROR en GeneraReporteCargaXSector [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function GeneraReporteDevoluciones(ByVal FacturaINI As String, ByVal FacturaFin As String, ByVal SQL_Comman As SqlCommand)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""




            Consulta = "SELECT * from [Rep_Devoluciones](" & FacturaINI & "," & FacturaFin & ") order by  [U_Chofer] ASC"


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return TABLA

        Catch ex As Exception
            MessageBox.Show("ERROR en GeneraReporteCargaXSector [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ExisteFactura(ByVal Factura As String, ByVal SQL_Comman As SqlCommand)
        Dim Consulta As String = ""
        Dim cuentas As Integer
        Dim ADATER As New SqlDataAdapter
        Dim TABLA As New DataTable

        Consulta = "SELECT count(T0.[DocNum]) as existe FROM  " & Class_VariablesGlobales.XMLParamSAP_CompanyDB & ".[dbo].OINV T0 WHERE T0.[DocNum]='" & Factura & "'"
        ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
        ADATER.Fill(TABLA)



        For Each row As DataRow In TABLA.Rows
            cuentas = TABLA.Rows(0).Item("existe").ToString()
        Next



        If (cuentas > 0) Then
            Return True

        Else
            Return False
        End If



    End Function
    Public Function VerificaSiExiste(ByVal FacINI As String, ByVal FacFIN As String, ByVal SQL_Comman As SqlCommand, ByVal TipoRep As String)

        Try


            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim cuentas As Integer


            If TipoRep = "Carga" Then
                Consulta = "SELECT count([ItemCode]) as existe FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Rep_Carg_Sector] where  [FacINI] = '" & FacINI & "'  and [FacFIN] ='" & FacFIN & "'"
            ElseIf TipoRep = "Devoluciones" Then
                Consulta = "SELECT count([ItemCode]) as existe FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Rep_Devo] where  [FacINI] = '" & FacINI & "'  and [FacFIN] ='" & FacFIN & "'"
            End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)



            For Each row As DataRow In TABLA.Rows
                cuentas = TABLA.Rows(0).Item("existe").ToString()
            Next

            If (cuentas > 0) Then
                Return True

            Else
                Return False
            End If


        Catch ex As Exception
            MessageBox.Show("ERROR en VerificaSiExiste [ " & ex.Message & " ]")
        End Try


    End Function

    Public Function GUARDA_ReporteCargaXSector(ByVal Consecutivo As String, ByVal Fecha As String, ByVal Hora As String, ByVal Chequeado As String, ByVal Ruta As String, ByVal Bodeguero As String, ByVal ItemCode As String, ByVal Descripcion As String, ByVal sector As String, ByVal Cantidad As String, ByVal Total As String, ByVal U_Gramaje As String, ByVal Unidades_x_Caja As String, ByVal CodeBars As String, ByVal Cajas As String, ByVal Faltante As String, ByVal Motivo As String, ByVal Bodega As String, ByVal Marca As String, ByVal Precio As String, ByVal FacINI As String, ByVal FacFIN As String, ByVal Bo1 As String, ByVal Usuario As String, ByVal SQL_Comman As SqlCommand, ByVal Sacado As String)
        Try

            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            Consulta = "INSERT INTO  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Rep_Carg_Sector]([Consecutivo],[Fecha],[Hora],[Chequeado],[Ruta],[Bodeguero],[ItemCode],[Descripcion],[sector],[Cantidad],[Total],[U_Gramaje],[Unidades_x_Caja],[CodeBars],[Cajas],[Faltante],[Motivo],[FacINI],[FacFIN],[Bodega],[Marca],[ConB1],[Anulado],[Subido],[Cerrado],[Sacado],[Precio],[Secuencia],[Usuario],[Habilitada]) VALUES(" & Consecutivo & ",'" & Fecha & "','" & Hora & "','" & Chequeado & "','" & Ruta & "','" & Bodeguero & "','" & ItemCode & "','" & Descripcion & "','" & sector & "','" & CInt(Cantidad) & "','" & Total & "','" & U_Gramaje & "','" & Unidades_x_Caja & "','" & CodeBars & "','" & Cajas & "','" & Faltante & "','" & Motivo & "','" & FacINI & "','" & FacFIN & "','" & Bodega & "','" & Marca & "','" & Bo1 & "','0','0','0','" & Sacado & "','" & Precio & "','0','" & Usuario & "','0')"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing


        Catch ex As Exception
            MessageBox.Show("ERROR en GUARDA_ReporteCargaXSector [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function GUARDA_Licencias(ByVal Cantidad As String, ByVal FechaInicio As String, ByVal FechaFin As String, ByVal TipoPasgo As String, ByVal Dias As String, SQL_Comman As SqlCommand)
        Try

            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""

            Consulta = "INSERT INTO " & Class_VariablesGlobales.XMLParamSQL_dababase & "[dbo].[Licencias]
           ([Cantidad]
           ,[FechaInicio]
           ,[FechaFin]
           ,[TipoPasgo]
           ,[Dias])
     VALUES
           ('" & Cantidad & "'
           ,'" & FechaInicio & "'
           ,'" & FechaFin & "'
           ,'" & TipoPasgo & "'
           ,'" & Dias & "')"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing


        Catch ex As Exception
            MessageBox.Show("ERROR en GUARDA_Licencias [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function GUARDA_ReporteFacturas(ByVal Consecutivo As String, ByVal DocNum As String, ByVal DocDate As String, ByVal Hora As String, ByVal Ruta As String, ByVal CardCode As String, ByVal CardName As String, ByVal DocTotal As String, ByVal DiscSum As String, ByVal VatSum As String, ByVal ItemCode As String, ByVal Dscription As String, ByVal Quantity As String, ByVal DiscPrcnt As String, ByVal Price As String, ByVal LineTotal As String, ByVal txt_FacturaINI As String, ByVal txt_FacturaFIN As String, ByVal Chofer As String, ByVal Ayudante As String, ByVal Saldo As String, ByVal Condicion As String, ByVal MostrarEnLiq As String, ByVal SlpCode As String, ByVal ConB1 As Integer, ByVal Usuario As String, Imp As String, DescFijo As String, DescPromo As String, ByVal SQL_Comman As SqlCommand)
        Try



            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            Consulta = "INSERT INTO  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Rep_Facturas](" &
                       "[Consecutivo] " &
                       ",[DocNum] " &
                       ",[FechaReporte] " &
                       ",[Hora] " &
                       ",[NombreRuta]" &
                       ",[FechaFactura] " &
                       ",[CodCliente] " &
                       ",[Nombre] " &
                       ",[ItemCode] " &
                       ",[ItemName] " &
                       ",[Cant]" &
                       ",[Descuento]" &
                       ",[Precio]" &
                       ",[MontoDesc]" &
                       ",[MontoImp]" &
                       ",[Total]" &
                       ",[Fac_INI]" &
                       ",[Fac_FIN]" &
                       ",[Chofer]" &
                       ",[Ayudante]" &
                       ",[Condicion]" &
                       ",[Anulado]" &
                       ",[DocTotal]" &
                       ",[Saldo]" &
                       ",[MostrarEnLiq]" &
                       ",[VatSum]" &
                       ",[DiscSum]" &
                       ",[SlpCode]" &
                       ",[NumLiq]" &
                       ",[ConB1]" &
                       ",[Usuario]" &
                       ",[Imp]" &
                       ",[DescFijo]" &
                       ",[DescPromo]" &
                       ") VALUES(" & Consecutivo & "," & DocNum & ",'" & DocDate & "','" & Hora & "','" & Ruta & "','" & DocDate & "','" & CardCode & "','" & CardName &
                                "','" & ItemCode & "','" & Dscription & "'," & Quantity & "," & DiscPrcnt & "," & Price & "," & DiscSum & "," & VatSum & "," & LineTotal & "," & txt_FacturaINI & "," & txt_FacturaFIN & ",'" & Chofer & "','" & Ayudante & "','" & Condicion & "','0','" & DocTotal & "','" & Saldo & "','" & MostrarEnLiq & "','" & VatSum & "','" & DiscSum & "','" & SlpCode & "','','" & ConB1 & "','" & Usuario & "'," & Imp & "," & DescFijo & "," & DescPromo & ")"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing


        Catch ex As Exception
            MessageBox.Show("ERROR en GUARDA_ReporteFacturas [ " & ex.Message & " ]")

            VariablesGlobales.Obj_Log.Log("ERROR en GUARDA_ReporteFacturas [" & Consecutivo & "] [ " & ex.Message & " ]", "MR")
        End Try

    End Function

    'cambia el estado de filtro para permitir los pedidos creados con fecha de  hoy
    'Public Function Permite_Datos_de_HOY(ByVal Agente As String)
    '  Try

    '    Dim SQL_Comman As New SqlCommand
    '    
    '    Dim cont As Integer = 0
    '    ' para la conexion al comman
    '    SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
    '    Dim Consulta As String
    '    'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

    '    Consulta = ""
    '    'Actualiza el estado dependiendo del numero de aplicacion que sea
    '    Consulta = "UPDATE  "&  Class_VariablesGlobales.XMLParamSQL_dababase  &".[dbo].[FiltraHOY] SET " & _
    '               "[HoySi] = 1, [NumPedidos] = 0 " & _
    '                "WHERE [CodAgente] = " & Agente & ""

    '    SQL_Comman.CommandText = Consulta
    '    SQL_Comman.ExecuteNonQuery()
    '    Obj_SQL_CONEXION.Desconectar()
    '    Return 0
    '  Catch ex As Exception
    '    MessageBox.Show("ERROR en Permite_Datos_de_HOY [ " & ex.Message & " ]")
    '  End Try

    'End Function

    'esta funcion verificara cuando se alla cambiado el estado en la base de datos de permitir el dia de hoy an los archivos a descargar y subir a SAP
    'Public Function Consulta_Estado_Filtro_Y_NumPedidos_HOY()
    '  Try
    '    Dim ADATER As New SqlDataAdapter
    '    Dim TABLA As New DataTable
    '    Dim Consulta As String = ""


    '    Consulta = "SELECT [CodAgente] ,[HoySi],[NumPedidos] FROM  "&  Class_VariablesGlobales.XMLParamSQL_dababase  &".[dbo].[FiltraHOY]"

    '    ADATER = New SqlDataAdapter(Consulta, Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & ""))
    '    ADATER.Fill(TABLA)
    '    Obj_SQL_CONEXION.Desconectar()

    '    Return TABLA

    '  Catch ex As Exception
    '    MessageBox.Show("ERROR en Consulta_Estado_Filtro_Y_NumPedidos_HOY [ " & ex.Message & " ]")
    '  End Try

    'End Function


    'ELIMINA EL AGENTE EN EJECUCION
    Public Function EliminaidAgenteENEjecucion(ByVal SQL_Comman As SqlCommand)

        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            '  SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            Consulta = "DELETE FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[AgenteAEjecutar]"


            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

        Catch ex As Exception

        End Try
    End Function
    'aqui guarda en la db el agente que deseamos como prioridad en el recorrido de descarga de agentes
    Public Function InsertaidAgenteAEjecutar(ByVal idAgente As String, ByVal SQL_Comman As SqlCommand)

        Try


            If idAgente <> "" Then
                'Dim SQL_Comman As New SqlCommand
                ' para la conexion al comman
                ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
                Dim Consulta As String
                'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL
                Consulta = ""
                Consulta = "INSERT INTO  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[AgenteAEjecutar]" & _
                          "([EjecAgente]) VALUES(" & idAgente & ")"
                SQL_Comman.CommandText = Consulta
                SQL_Comman.ExecuteNonQuery()
                SQL_Comman = Nothing
                'Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function ConsultaidAgenteAEjecutar(ByVal SQL_Comman As SqlCommand)
        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""


            Consulta = "SELECT [AgenteEnSecuencia],[Procesando] FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[AgenteAEjecutar] "

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA

        Catch ex As Exception
            MessageBox.Show("ERROR en ConsultaidAgenteAEjecutar [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function ConsultaHoySI(ByVal SQL_Comman As SqlCommand)
        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim HoySi As String

            Consulta = "SELECT [HoySi] FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[FiltraHOY] "

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            HoySi = TABLA.Rows(0).Item("HoySi")
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return HoySi
        Catch ex As Exception
            'MessageBox.Show("ERROR en ConsultaHoySI [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function ConsultaidProcesoEnEjecucion(ByVal SQL_Comman As SqlCommand)
        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "SELECT [Procesando] FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[ProcesoEnEjecucion]"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA

        Catch ex As Exception
            MessageBox.Show("ERROR en ConsultaidProcesoEnEjecucion [ " & ex.Message & " ]")
        End Try

    End Function



    Public Function InsertaidOferta(ByVal SQL_Comman As SqlCommand, ByVal CodArt1 As String, ByVal DescripcionArt1 As String, ByVal CantidarArti1 As String, ByVal CodArt2 As String, ByVal DescripcionArt2 As String, ByVal CantidarArti2 As String, ByVal CodArt3 As String, ByVal DescripcionArt3 As String, ByVal DescuentoArti3 As String)

        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            Consulta = "INSERT INTO  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Ofertas] ([CodArt1],[DescripcionArt1] ,[CantidarArti1] ,[CodArt2] ,[DescripcionArt2],[CantidarArti2],[CodArt3],[DescripcionArt3],[DescuentoArti3])VALUES('" & CodArt1 & "','" & DescripcionArt1 & "','" & CantidarArti1 & "','" & CodArt2 & "','" & DescripcionArt2 & "','" & CantidarArti2 & "','" & CodArt3 & "','" & DescripcionArt3 & "','" & DescuentoArti3 & "')"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

        Catch ex As Exception

        End Try
    End Function

    Public Function ConsultaOfertas(ByVal SQL_Comman As SqlCommand)
        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""


            Consulta = "SELECT *  FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Ofertas]"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en PagosSUBIDOS [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function ConsultaOfertas(ByVal SQL_Comman As SqlCommand, ByVal ItemCode As String)
        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            '  SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim ItemName As String
            Consulta = "SELECT top 1[ItemName]  FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[ArticulosActivos] where [ItemCode] = '" & ItemCode & "'"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ItemName = TABLA.Rows(0).Item("ItemName").ToString()
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return ItemName
        Catch ex As Exception
            MessageBox.Show("ERROR en PagosSUBIDOS [ " & ex.Message & " ]")
        End Try
    End Function


    'Public Function Codigos(ByVal SQL_Comman As SqlCommand)

    '    Dim cmd As New SqlCommand("Select [ItemCode] FROM  "&  Class_VariablesGlobales.XMLParamSQL_dababase  &".[dbo].[ArticulosActivos]", SQL_Comman.Connection)
    '    'If con.State = ConnectionState.Closed Then con.Open()

    '    Dim ds As New DataSet
    '    Dim da As New SqlDataAdapter(cmd)
    '    da.Fill(ds, "Autofill")

    '    Dim col As New AutoCompleteStringCollection
    '    Dim i As Integer
    '    For i = 0 To ds.Tables(0).Rows.Count - 1
    '        col.Add(ds.Tables(0).Rows(i)("ItemCode").ToString())
    '    Next
    '    Form1.txt_CodiOf.AutoCompleteSource = AutoCompleteSource.CustomSource
    '    Form1.txt_CodiOf.AutoCompleteCustomSource = col
    '    Form1.txt_CodiOf.AutoCompleteMode = AutoCompleteMode.Suggest

    '    Form1.TxtbonifCod.AutoCompleteSource = AutoCompleteSource.CustomSource
    '    Form1.TxtbonifCod.AutoCompleteCustomSource = col
    '    Form1.TxtbonifCod.AutoCompleteMode = AutoCompleteMode.Suggest

    '    Form1.TxtDescCod.AutoCompleteSource = AutoCompleteSource.CustomSource
    '    Form1.TxtDescCod.AutoCompleteCustomSource = col
    '    Form1.TxtDescCod.AutoCompleteMode = AutoCompleteMode.Suggest

    'End Function




    Public Function Bloquea_DESBloqueaPedidosHOY(ByVal SQL_Comman As SqlCommand, ByVal valor As Integer)

        Try
            '  Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            If valor = 1 Then
                Consulta = "UPDATE  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[FiltraHOY] SET [HoySi] = '" & valor & "' WHERE [HoySi] = '0' "
            Else
                Consulta = "UPDATE  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[FiltraHOY] SET [HoySi] = '" & valor & "' WHERE [HoySi] = '1' "
            End If
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            'SQL_Comman = Nothing
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

        Catch ex As Exception

        End Try
    End Function




    Public Function Bloquea_Desbloquea_DescargardeFTP(ByVal SQL_Comman As SqlCommand, ByVal valor As Integer) As Boolean
        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            'si el valor es 1 es por que NO DESCARGARA DE FTP
            If valor = 1 Then
                Consulta = "UPDATE  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[BajarDeFTP]  SET [BajarDeFTP] = 1 "
            Else
                Consulta = "UPDATE  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[BajarDeFTP]  SET [BajarDeFTP] = 0 "
            End If
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

        Catch ex As Exception

        End Try

    End Function


#Region "Descuentos Fijos"

    Public Function ExisteDescuentoFijo(ByVal SQL_Comman As SqlCommand, ByVal CodArticulo As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman
            'Dim SQL_Comman As New SqlCommand
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            Consulta = "SELECT [CodArticulo] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[DescuentosAutomaticos] WHERE [CodArticulo]='" & CodArticulo & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Try
                If (TABLA.Rows(0).Item("CodArticulo").ToString() <> "") Then
                    Return 0
                End If
            Catch ex As Exception
                Return 1

            End Try


            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()

            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            SQL_Comman = Nothing
        Catch ex As Exception

        End Try

        Return 0
    End Function

    Public Function ObtieneDescripcion(ByVal SQL_Comman As SqlCommand, ByVal CodArticulo As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman
            ' Dim SQL_Comman As New SqlCommand
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            Consulta = "SELECT [ItemName] FROM [BD_Bourne].[dbo].[OITM] where [ItemCode] = '" & CodArticulo & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA.Rows(0).Item("ItemName").ToString()



            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

        Catch ex As Exception

        End Try

        Return 0
    End Function

    Public Function InsertaDescuentoFijo(ByVal SQL_Comman As SqlCommand, ByVal CodArt1 As String, ByVal Descuento As String, ByVal Desde As String, ByVal Hasta As String, ByVal Cantidad As String, ByVal Cantidad_Disponible As String, ByVal Comentario As String)

        Try

            Dim Descripcion As String
            Descripcion = ObtieneDescripcion(SQL_Comman, CodArt1)
            ' para la conexion al comman
            ' Dim SQL_Comman As New SqlCommand
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            Dim HabilitaCantidadDisponible As String
            If (Cantidad_Disponible > 0) Then
                HabilitaCantidadDisponible = 1
            Else
                HabilitaCantidadDisponible = 0
            End If
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[DescuentosAutomaticos]([CodArticulo],[Descripcion],[Descuento],[Desde],[hasta],[Cantidad],[Disponible],[Comentario],[HabilitaDisponible])VALUES('" & CodArt1 & "','" & Descripcion & "','" & Descuento & "','" & Desde & "','" & Hasta & "','" & Cantidad & "','" & Cantidad_Disponible & "','" & Comentario & "','" & HabilitaCantidadDisponible & "')"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

        Catch ex As Exception

        End Try
    End Function

    Public Function ConsultaDescuentosAuto(ByVal SQL_Comman As SqlCommand)
        Try
            'Dim SQL_Comman As New SqlCommand
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""


            Consulta = "SELECT [CodArticulo],[Descripcion],[Descuento],[Desde],[hasta],[Cantidad],[Disponible],[Comentario] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[DescuentosAutomaticos]"



            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ConsultaDescuentosAuto [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function EliminaDescuentosAuto(ByVal SQL_Comman As SqlCommand, ByVal CodArticulo As String)

        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[DescuentosAutomaticos] WHERE [CodArticulo]='" & CodArticulo & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()

            SQL_Comman = Nothing
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

        Catch ex As Exception
            MessageBox.Show("ERROR en Consulta_Estado_SubidaSAP [ " & ex.Message & " ]")
        End Try

    End Function

    Public Function ActualizaEstadoReporte(ByVal Consecutivo As String, ByVal SQL_Comman As SqlCommand, Estado As String)
        Try


            Dim Obj_SQL_CONEXION As New CONEXION_TO_SQLSERVER
            Dim cont As Integer = 0
            Dim Consulta As String

            Consulta = ""

            'Cierra el reporte para que nadie pueda editarlo
            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] SET [Cerrado] = '" & Estado & "' where [Consecutivo]='" & Consecutivo & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            Return 0
        Catch ex As Exception
            MessageBox.Show("ERROR en Actualiza_Estado_Alerta [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function ActualizaDescuentosAuto(ByVal SQL_Comman As SqlCommand, ByVal CodArt1 As String, ByVal Descuento As String, ByVal Desde As String, ByVal Hasta As String, ByVal Cantidad As String, ByVal Cantidad_Disponible As String, ByVal Comentario As String)
        Try


            Dim Obj_SQL_CONEXION As New CONEXION_TO_SQLSERVER
            Dim cont As Integer = 0
            ' para la conexion al comman
            ' Dim SQL_Comman As New SqlCommand
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL
            Dim HabilitaCantidadDisponible As String
            If (Cantidad_Disponible > 0) Then
                HabilitaCantidadDisponible = 1
            Else
                HabilitaCantidadDisponible = 0
            End If
            Consulta = ""

            'Actualiza el estado dependiendo del numero de aplicacion que sea
            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[DescuentosAutomaticos] SET [Descuento] = '" & Descuento & "'  ,[Desde] = '" & Desde & "',[hasta] = '" & Hasta & "' ,[Cantidad] = '" & Cantidad & "',[Disponible] = '" & Cantidad_Disponible & "',[Comentario] = '" & Comentario & "',[HabilitaDisponible] = '" & HabilitaCantidadDisponible & "' WHERE [CodArticulo] = '" & CodArt1 & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            Return 0
        Catch ex As Exception
            MessageBox.Show("ERROR en Actualiza_Estado_Alerta [ " & ex.Message & " ]")
        End Try

    End Function

    Public Function ConsultaTodo(ByVal SQL_Comman As SqlCommand)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman
            ' Dim SQL_Comman As New SqlCommand
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            Consulta = "SELECT [CodArticulo],[Descripcion],[Descuento],[Desde],[hasta],[Cantidad],[Disponible],[Comentario] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[DescuentosAutomaticos]"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)



            '  Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            SQL_Comman = Nothing
            Return TABLA
        Catch ex As Exception

        End Try


    End Function


    Public Function ConsultaConsecutivo(ByVal Sector As String, ByVal SQL_Comman As SqlCommand, ByVal TipoReporte As String)

    End Function

    Public Function ConsultaRepFacturasXid(ByVal SQL_Comman As SqlCommand, ByVal id As String)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String
            Consulta = ""
            Consulta = "SELECT T0.[Consecutivo] ,T0.[FechaReporte] ,(SELECT  T1.[Nombre] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Agentes] T1  where   T1.[CodChofer]=T0.[Chofer]) as Nombre,T0.[NombreRuta] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] where T0.[Consecutivo]='" & id & "'T0 group by T0.[Consecutivo],T0.[FechaReporte],T0.[Chofer],T0.[NombreRuta] ORDER BY T0.[Consecutivo] DESC "
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA

        Catch ex As Exception
        End Try
        Return 0
    End Function


    Public Function ConsultaRepFacturas(ByVal SQL_Comman As SqlCommand, ByVal Ruta As String, ByVal Fecha As String, ByVal Subido As String, ByVal Chofer As String, ByVal Anulado As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman

            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL
            Consulta = ""
            If Chofer = "" Then
                If Anulado = "" Then
                    Consulta = "SELECT T0.[Consecutivo] ,T0.[FechaReporte] ,(SELECT  T1.[Nombre] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Agentes] T1  where   T1.[CodAgente]=T0.[Chofer]) as Nombre,T0.[NombreRuta],[NumLiq] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] T0 WHERE [FechaReporte]='" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Fecha) & "' group by T0.[Consecutivo],T0.[FechaReporte],T0.[Chofer],T0.[NombreRuta],[NumLiq] ORDER BY T0.[Consecutivo] DESC "
                ElseIf Anulado = "1" Then
                    Consulta = "SELECT T0.[Consecutivo] ,T0.[FechaReporte] ,(SELECT  T1.[Nombre] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Agentes] T1  where   T1.[CodAgente]=T0.[Chofer]) as Nombre,T0.[NombreRuta],[NumLiq] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] T0 WHERE  [FechaReporte]='" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Fecha) & "' and [Anulado]='1' group by T0.[Consecutivo],T0.[FechaReporte],T0.[Chofer],T0.[NombreRuta],[NumLiq] ORDER BY T0.[Consecutivo] DESC "
                ElseIf Anulado = "0" Then
                    Consulta = "SELECT T0.[Consecutivo] ,T0.[FechaReporte] ,(SELECT  T1.[Nombre] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Agentes] T1  where   T1.[CodAgente]=T0.[Chofer]) as Nombre,T0.[NombreRuta],[NumLiq] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] T0 WHERE  [FechaReporte]='" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Fecha) & "' and [Anulado]='0' group by T0.[Consecutivo],T0.[FechaReporte],T0.[Chofer],T0.[NombreRuta],[NumLiq] ORDER BY T0.[Consecutivo] DESC "

                ElseIf Anulado = "2" Then
                    Consulta = "SELECT T0.[Consecutivo] ,T0.[FechaReporte] ,(SELECT  T1.[Nombre] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Agentes] T1  where   T1.[CodAgente]=T0.[Chofer]) as Nombre,T0.[NombreRuta],[NumLiq] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] T0 WHERE  [FechaReporte]='" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Fecha) & "' and NumLiq='' group by T0.[Consecutivo],T0.[FechaReporte],T0.[Chofer],T0.[NombreRuta],[NumLiq] ORDER BY T0.[Consecutivo] DESC "
                End If

            Else

                If Anulado = "" Then
                    Consulta = "SELECT T0.[Consecutivo] ,T0.[FechaReporte] ,(SELECT  T1.[Nombre] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Agentes] T1  where   T1.[CodAgente]=T0.[Chofer]) as Nombre,T0.[NombreRuta],[NumLiq] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] T0 WHERE [FechaReporte]='" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Fecha) & "' and [Chofer]='" & Chofer & "'  group by T0.[Consecutivo],T0.[FechaReporte],T0.[Chofer],T0.[NombreRuta],[NumLiq] ORDER BY T0.[Consecutivo] DESC "
                ElseIf Anulado = "1" Then
                    Consulta = "SELECT T0.[Consecutivo] ,T0.[FechaReporte] ,(SELECT  T1.[Nombre] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Choferes] T1  where   T1.[CodAgente]=T0.[Chofer]) as Nombre,T0.[NombreRuta],[NumLiq] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] T0 WHERE  [FechaReporte]='" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Fecha) & "'  and [Chofer]='" & Chofer & "' AND [Anulado]='1' group by T0.[Consecutivo],T0.[FechaReporte],T0.[Chofer],T0.[NombreRuta],[NumLiq] ORDER BY T0.[Consecutivo] DESC "
                ElseIf Anulado = "0" Then
                    Consulta = "SELECT T0.[Consecutivo] ,T0.[FechaReporte] ,(SELECT  T1.[Nombre] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Choferes] T1  where   T1.[CodAgente]=T0.[Chofer]) as Nombre,T0.[NombreRuta],[NumLiq] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] T0 WHERE  [FechaReporte]='" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Fecha) & "'  and [Chofer]='" & Chofer & "' AND [Anulado]='0' group by T0.[Consecutivo],T0.[FechaReporte],T0.[Chofer],T0.[NombreRuta],[NumLiq] ORDER BY T0.[Consecutivo] DESC "

                ElseIf Anulado = "2" Then
                    Consulta = "SELECT T0.[Consecutivo] ,T0.[FechaReporte] ,(SELECT  T1.[Nombre] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Choferes] T1  where   T1.[CodAgente]=T0.[Chofer]) as Nombre,T0.[NombreRuta],[NumLiq] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] T0 WHERE   [FechaReporte]='" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Fecha) & "'  and [Chofer]='" & Chofer & "' AND NumLiq='' group by T0.[Consecutivo],T0.[FechaReporte],T0.[Chofer],T0.[NombreRuta],[NumLiq] ORDER BY T0.[Consecutivo] DESC "
                End If


                'Consulta = "SELECT T0.[Consecutivo] ,T0.[FechaReporte] ,(SELECT  T1.[Nombre] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Choferes] T1  where   T1.[CodAgente]=T0.[Chofer]) as Nombre,T0.[NombreRuta] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] T0 where [Chofer]='" & Chofer & "' and  [Anulado]='" & Anulado & "'  group by T0.[Consecutivo],T0.[FechaReporte],T0.[Chofer],T0.[NombreRuta]  ORDER BY T0.[Consecutivo] DESC"
            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception

        End Try

        Return 0
    End Function

    Public Function ConsultaDetRepFacturas(ByVal SQL_Comman As SqlCommand, ByVal Consecutivo As String, ByVal Tipo As String)
        Try


            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman

            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL
            'Consulta = "SELECT  [Consecutivo],[DocNum],[FechaReporte],[Hora],[FechaFactura],[CodCliente],[Nombre],[ItemCode],[ItemName],[Cant],[Descuento],[Precio],[Imp],[MontoDesc],[MontoImp],[Total],[Fac_INI],[Fac_FIN],[NombreRuta],[Chofer],[Ayudante],[ConB1] ,[Anulado]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] where Consecutivo='" & Consecutivo & "' AND Condicion = -1"
            Consulta = ""

            If Tipo = "CONTADO" Then
                'Consulta = "SELECT   [Consecutivo],[DocNum],[FechaReporte],[Hora],[FechaFactura],[CodCliente],[Nombre],[ItemCode],[ItemName],[Cant],[Descuento],[Precio],[Imp],[MontoDesc],[MontoImp],[Total],[Fac_INI],[Fac_FIN],[NombreRuta],[Chofer],[Ayudante],[ConB1] ,[Anulado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] where Consecutivo='" & Consecutivo & "' AND Condicion = -1 order by [DocNum] asc "
                'Consulta = "SELECT   [Consecutivo],[DocNum],[FechaReporte],[Hora],[FechaFactura],[CodCliente],[Nombre],[Fac_INI],[Fac_FIN],[Chofer],[Ayudante],[ConB1],NombreRuta,SUM([Total]) AS Total,[Anulado],[DocTotal],[NumLiq],'CONTADO' AS Tipo ,[SlpCode],[VatSum]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] where Consecutivo='" & Consecutivo & "' AND Condicion = -1 GROUP BY  [Consecutivo],[DocNum],[FechaReporte],[Hora],[FechaFactura],[CodCliente],[Nombre],[Fac_INI],[Fac_FIN],[Chofer],[Ayudante],[ConB1],[NombreRuta],[Anulado],[DocTotal],[NumLiq],[SlpCode],[VatSum]   order by [DocNum] asc "
                Consulta = "SELECT  [Comentario],[DocNum],[SlpCode],'CONTADO' AS Tipo ,[CodCliente],[Nombre],SUM([Total]) AS SubTotal,[VatSum] as Impuesto,[DocTotal] as Total,[Consecutivo],[FechaReporte],[Hora],[FechaFactura],[Fac_INI],[Fac_FIN],[Chofer],[Ayudante],[ConB1],[NombreRuta],[Anulado],[NumLiq],[Chequeado]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] where Consecutivo='" & Consecutivo & "' AND Condicion = -1 GROUP BY  [DocNum],[SlpCode],[CodCliente],[Nombre],[VatSum] ,[DocTotal] ,[Consecutivo],[FechaReporte],[Hora],[FechaFactura],[Fac_INI],[Fac_FIN],[Chofer],[Ayudante],[ConB1],[NombreRuta],[Anulado],[NumLiq],[Chequeado], [Comentario]   order by [DocNum] asc "
            ElseIf Tipo = "CREDITO" Then
                'Consulta = "SELECT  [Consecutivo],[DocNum],[FechaReporte],[Hora],[FechaFactura],[CodCliente],[Nombre],[ItemCode],[ItemName],[Cant],[Descuento],[Precio],[Imp],[MontoDesc],[MontoImp],[Total],[Fac_INI],[Fac_FIN],[NombreRuta],[Chofer],[Ayudante],[ConB1] ,[Anulado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] where Consecutivo='" & Consecutivo & "'  AND Condicion <> -1  order by [DocNum] asc "
                'Consulta = "SELECT   [Consecutivo],[DocNum],[FechaReporte],[Hora],[FechaFactura],[CodCliente],[Nombre],[Fac_INI],[Fac_FIN],[Chofer],[Ayudante],[ConB1],NombreRuta,SUM([Total]) AS Total,[Anulado],[DocTotal],[NumLiq],'CONTADO' AS Tipo ,[SlpCode],[VatSum]   FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] where Consecutivo='" & Consecutivo & "' AND Condicion <> -1 GROUP BY  [Consecutivo],[DocNum],[FechaReporte],[Hora],[FechaFactura],[CodCliente],[Nombre],[Fac_INI],[Fac_FIN],[Chofer],[Ayudante],[ConB1],[NombreRuta],[Anulado],[DocTotal],[NumLiq],[SlpCode],[VatSum]   order by [DocNum] asc "
                Consulta = "SELECT  [Comentario],[DocNum],[SlpCode],'CREDITO' AS Tipo ,[CodCliente],[Nombre],SUM([Total]) AS SubTotal,[VatSum] as Impuesto,[DocTotal] as Total,[Consecutivo],[FechaReporte],[Hora],[FechaFactura],[Fac_INI],[Fac_FIN],[Chofer],[Ayudante],[ConB1],[NombreRuta],[Anulado],[NumLiq],[Chequeado]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] where Consecutivo='" & Consecutivo & "' AND Condicion <> -1 GROUP BY  [DocNum],[SlpCode],[CodCliente],[Nombre],[VatSum] ,[DocTotal] ,[Consecutivo],[FechaReporte],[Hora],[FechaFactura],[Fac_INI],[Fac_FIN],[Chofer],[Ayudante],[ConB1],[NombreRuta],[Anulado],[NumLiq],[Chequeado], [Comentario]   order by [DocNum] asc "
            Else
                ' Consulta = "SELECT [Consecutivo],[DocNum],[FechaReporte],[Hora],[FechaFactura],[CodCliente],[Nombre],[ItemCode],[ItemName],[Cant],[Descuento],[Precio],[Imp],[MontoDesc],[MontoImp],[Total],[Fac_INI],[Fac_FIN],[NombreRuta],[Chofer],[Ayudante],[ConB1] ,[Anulado],[NumLiq],[SlpCode]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] where Consecutivo='" & Consecutivo & "'  "
                Consulta = "SELECT [Comentario],[Consecutivo],[DocNum],[FechaReporte],[Hora],[FechaFactura],[CodCliente],[Nombre],[ItemCode],[ItemName],[Cant],[Descuento],[Precio],[Imp],[MontoDesc],[MontoImp],[Total],[Fac_INI],[Fac_FIN],[NombreRuta],[Chofer],[Ayudante],[ConB1] ,[Anulado],[NumLiq],[SlpCode]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] where Consecutivo='" & Consecutivo & "'  "


            End If






            'If Tipo = "CONTADO" Then
            '    'Consulta = "SELECT   [Consecutivo],[DocNum],[FechaReporte],[Hora],[FechaFactura],[CodCliente],[Nombre],[ItemCode],[ItemName],[Cant],[Descuento],[Precio],[Imp],[MontoDesc],[MontoImp],[Total],[Fac_INI],[Fac_FIN],[NombreRuta],[Chofer],[Ayudante],[ConB1] ,[Anulado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] where Consecutivo='" & Consecutivo & "' AND Condicion = -1 order by [DocNum] asc "
            '    Consulta = "SELECT   [DocNum],'CONTADO' AS Tipo ,[SlpCode],[CodCliente],[Nombre],SUM([Total]) AS Total,[VatSum] AS Impuesto,[DocTotal] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] where Consecutivo='" & Consecutivo & "' AND Condicion = -1 GROUP BY  [DocNum],[CodCliente],[Nombre],[DocTotal],[SlpCode],[VatSum]   order by [DocNum] asc "
            'ElseIf Tipo = "CREDITO" Then
            '    'Consulta = "SELECT  [Consecutivo],[DocNum],[FechaReporte],[Hora],[FechaFactura],[CodCliente],[Nombre],[ItemCode],[ItemName],[Cant],[Descuento],[Precio],[Imp],[MontoDesc],[MontoImp],[Total],[Fac_INI],[Fac_FIN],[NombreRuta],[Chofer],[Ayudante],[ConB1] ,[Anulado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] where Consecutivo='" & Consecutivo & "'  AND Condicion <> -1  order by [DocNum] asc "
            '    Consulta = "SELECT   [DocNum],'CREDITO' AS Tipo ,[SlpCode],[CodCliente],[Nombre],SUM([Total]) AS Total,[VatSum] AS Impuesto,[DocTotal] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] where Consecutivo='" & Consecutivo & "' AND Condicion <> -1 GROUP BY  [DocNum],[CodCliente],[Nombre],[DocTotal],[SlpCode],[VatSum]  order by [DocNum] asc "
            'Else
            '    Consulta = "SELECT  [Consecutivo],[DocNum],[FechaReporte],[Hora],[FechaFactura],[CodCliente],[Nombre],[ItemCode],[ItemName],[Cant],[Descuento],[Precio],[Imp],[MontoDesc],[MontoImp],[Total],[Fac_INI],[Fac_FIN],[NombreRuta],[Chofer],[Ayudante],[ConB1] ,[Anulado],[NumLiq],[SlpCode]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] where Consecutivo='" & Consecutivo & "'  "
            'End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception

        End Try

        Return 0
    End Function

    Public Function ConsultaRUTAS(ByVal SQL_Comman As SqlCommand, ByVal Ruta As String, ByVal Fecha As String, ByVal Estado As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman

            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""

            If Estado = "Cerrado" Then
                If Fecha <> "" Or Ruta <> "" Then
                    If Ruta <> "" And Fecha <> "" Then
                        Consulta = "SELECT [Consecutivo],[Fecha],[Ruta],CASE WHEN [Anulado]=0 then 'NO' ELSE 'SI' END AS Anulado,CASE WHEN [Cerrado]=0 then 'NO' ELSE 'SI' END AS Cerrado FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE [Ruta] like '%" & Ruta & "%' and  [Fecha]='" & Fecha & "' and [Cerrado]='1' GROUP BY [Consecutivo],[Fecha],[Ruta],[Anulado],[Cerrado] ORDER BY [Consecutivo] desc"
                    ElseIf Fecha <> "" Then
                        Consulta = "SELECT [Consecutivo],[Fecha],[Ruta],CASE WHEN [Anulado]=0 then 'NO' ELSE 'SI' END AS Anulado,CASE WHEN [Cerrado]=0 then 'NO' ELSE 'SI' END AS Cerrado FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE   [Fecha]='" & Fecha & "' and [Cerrado]='1' GROUP BY [Consecutivo],[Fecha],[Ruta],[Anulado],[Cerrado] ORDER BY [Consecutivo] desc"
                    ElseIf Ruta <> "" Then
                        Consulta = "SELECT [Consecutivo],[Fecha],[Ruta],CASE WHEN [Anulado]=0 then 'NO' ELSE 'SI' END AS Anulado,CASE WHEN [Cerrado]=0 then 'NO' ELSE 'SI' END AS Cerrado FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE   [Ruta] like '%" & Ruta & "%' and [Cerrado]='1' GROUP BY [Consecutivo],[Fecha],[Ruta],[Anulado],[Cerrado] ORDER BY [Consecutivo] desc"
                    End If
                Else
                    Consulta = "SELECT [Consecutivo],[Fecha],[Ruta],CASE WHEN [Anulado]=0 then 'NO' ELSE 'SI' END AS Anulado,CASE WHEN [Cerrado]=0 then 'NO' ELSE 'SI' END AS Cerrado FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] where  [Cerrado]='1' and  [Fecha]='" & Fecha & "' GROUP BY [Consecutivo],[Fecha],[Ruta],[Anulado],[Cerrado] ORDER BY [Consecutivo] desc"
                End If
            ElseIf Estado = "Activos" Then

                If Fecha <> "" Or Ruta <> "" Then
                    If Ruta <> "" And Fecha <> "" Then
                        Consulta = "SELECT [Consecutivo],[Fecha],[Ruta],CASE WHEN [Anulado]=0 then 'NO' ELSE 'SI' END AS Anulado,CASE WHEN [Cerrado]=0 then 'NO' ELSE 'SI' END AS Cerrado FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE [Ruta] like '%" & Ruta & "%' and  [Fecha]='" & Fecha & "' and [Anulado]='0' and [Cerrado]='0' GROUP BY [Consecutivo],[Fecha],[Ruta],[Anulado],[Cerrado] ORDER BY [Consecutivo] desc"
                    ElseIf Fecha <> "" Then
                        Consulta = "SELECT [Consecutivo],[Fecha],[Ruta],CASE WHEN [Anulado]=0 then 'NO' ELSE 'SI' END AS Anulado,CASE WHEN [Cerrado]=0 then 'NO' ELSE 'SI' END AS Cerrado FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE   [Fecha]='" & Fecha & "' and [Anulado]='0' and [Cerrado]='0' GROUP BY [Consecutivo],[Fecha],[Ruta],[Anulado],[Cerrado] ORDER BY [Consecutivo] desc"
                    ElseIf Ruta <> "" Then
                        Consulta = "SELECT [Consecutivo],[Fecha],[Ruta],CASE WHEN [Anulado]=0 then 'NO' ELSE 'SI' END AS Anulado,CASE WHEN [Cerrado]=0 then 'NO' ELSE 'SI' END AS Cerrado FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE   [Ruta] like '%" & Ruta & "%' and [Anulado]='0' and [Cerrado]='0' GROUP BY [Consecutivo],[Fecha],[Ruta],[Anulado],[Cerrado] ORDER BY [Consecutivo] desc"
                    End If
                Else
                    Consulta = "SELECT [Consecutivo],[Fecha],[Ruta],CASE WHEN [Anulado]=0 then 'NO' ELSE 'SI' END AS Anulado,CASE WHEN [Cerrado]=0 then 'NO' ELSE 'SI' END AS Cerrado FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] where  [Anulado]='0' and [Cerrado]='0' and  [Fecha]='" & Fecha & "' GROUP BY [Consecutivo],[Fecha],[Ruta],[Anulado],[Cerrado] ORDER BY [Consecutivo] desc"
                End If

            ElseIf Estado = "Anulado" Then

                If Fecha <> "" Or Ruta <> "" Then
                    If Ruta <> "" And Fecha <> "" Then
                        Consulta = "SELECT [Consecutivo],[Fecha],[Ruta],CASE WHEN [Anulado]=0 then 'NO' ELSE 'SI' END AS Anulado,CASE WHEN [Cerrado]=0 then 'NO' ELSE 'SI' END AS Cerrado FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE [Ruta] like '%" & Ruta & "%' and  [Fecha]='" & Fecha & "' and [Anulado]='1' GROUP BY [Consecutivo],[Fecha],[Ruta],[Anulado],[Cerrado] ORDER BY [Consecutivo] desc"
                    ElseIf Fecha <> "" Then
                        Consulta = "SELECT [Consecutivo],[Fecha],[Ruta],CASE WHEN [Anulado]=0 then 'NO' ELSE 'SI' END AS Anulado,CASE WHEN [Cerrado]=0 then 'NO' ELSE 'SI' END AS Cerrado FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE   [Fecha]='" & Fecha & "' and [Anulado]='1' GROUP BY [Consecutivo],[Fecha],[Ruta],[Anulado],[Cerrado] ORDER BY [Consecutivo] desc"
                    ElseIf Ruta <> "" Then
                        Consulta = "SELECT [Consecutivo],[Fecha],[Ruta],CASE WHEN [Anulado]=0 then 'NO' ELSE 'SI' END AS Anulado,CASE WHEN [Cerrado]=0 then 'NO' ELSE 'SI' END AS Cerrado FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE   [Ruta] like '%" & Ruta & "%' and [Anulado]='1' GROUP BY [Consecutivo],[Fecha],[Ruta],[Anulado],[Cerrado] ORDER BY [Consecutivo] desc"
                    End If
                Else
                    Consulta = "SELECT [Consecutivo],[Fecha],[Ruta],CASE WHEN [Anulado]=0 then 'NO' ELSE 'SI' END AS Anulado,CASE WHEN [Cerrado]=0 then 'NO' ELSE 'SI' END AS Cerrado FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] where  [Anulado]='1' and  [Fecha]='" & Fecha & "' GROUP BY [Consecutivo],[Fecha],[Ruta],[Anulado],[Cerrado] ORDER BY [Consecutivo] desc"
                End If

            Else

                If Fecha <> "" Or Ruta <> "" Then
                    If Ruta <> "" And Fecha <> "" Then
                        Consulta = "SELECT [Consecutivo],[Fecha],[Ruta],CASE WHEN [Anulado]=0 then 'NO' ELSE 'SI' END AS Anulado,CASE WHEN [Cerrado]=0 then 'NO' ELSE 'SI' END AS Cerrado FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE [Ruta] like '%" & Ruta & "%' and  [Fecha]='" & Fecha & "' GROUP BY [Consecutivo],[Fecha],[Ruta],[Anulado],[Cerrado] ORDER BY [Consecutivo] desc"
                    ElseIf Fecha <> "" Then
                        Consulta = "SELECT [Consecutivo],[Fecha],[Ruta],CASE WHEN [Anulado]=0 then 'NO' ELSE 'SI' END AS Anulado,CASE WHEN [Cerrado]=0 then 'NO' ELSE 'SI' END AS Cerrado FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE   [Fecha]='" & Fecha & "'  GROUP BY [Consecutivo],[Fecha],[Ruta],[Anulado],[Cerrado] ORDER BY [Consecutivo] desc"
                    ElseIf Ruta <> "" Then
                        Consulta = "SELECT [Consecutivo],[Fecha],[Ruta],CASE WHEN [Anulado]=0 then 'NO' ELSE 'SI' END AS Anulado,CASE WHEN [Cerrado]=0 then 'NO' ELSE 'SI' END AS Cerrado FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE   [Ruta] like '%" & Ruta & "%'  GROUP BY [Consecutivo],[Fecha],[Ruta],[Anulado],[Cerrado] ORDER BY [Consecutivo] desc"
                    End If
                Else
                    Consulta = "SELECT [Consecutivo],[Fecha],[Ruta],CASE WHEN [Anulado]=0 then 'NO' ELSE 'SI' END AS Anulado,CASE WHEN [Cerrado]=0 then 'NO' ELSE 'SI' END AS Cerrado FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] where [Fecha]='" & Fecha & "' GROUP BY [Consecutivo],[Fecha],[Ruta],[Anulado],[Cerrado]ORDER BY [Consecutivo] desc"
                End If


            End If








            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception

        End Try

        Return 0
    End Function

    Public Function BuscaArticulo(ByVal CodArticulo As String, ByVal Conse_Repcarga As String, ByVal SQL_Comman As SqlCommand)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman

            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""

            Consulta = "SELECT [Consecutivo],[Chequeado],[ItemCode],[Descripcion],[sector],[Cantidad],[Total],[CodeBars],[Bodega],[Bodeguero],[Faltante],[Motivo],[Chequeador],[Faltante_Chequeador],[Motivo_Chequeador],[FacINI],[FacFIN],[Ruta],[Fecha],[Hora],[Cajas],[Cerrado],[Unidades_x_Caja],[Sacado_Chequeador],[Sacado_Bodeguero]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE [Consecutivo] = '" & Conse_Repcarga & "' and [ItemCode]='" & CodArticulo & "'"


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception

        End Try

        Return 0
    End Function

    Public Function SumaChequeadoRepCarga(ByVal Conse_Repcarga As String, ByVal SQL_Comman As SqlCommand)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String


            Consulta = ""

            Consulta = " SELECT SUM(CAST([Total] as numeric(9,2) )) as Total FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector]WHERE [Consecutivo] = '" & Conse_Repcarga & "'  AND [Chequeado] = 'SI' Group By [Consecutivo]"


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA.Rows(0).Item("Total").ToString()
        Catch ex As Exception

        End Try

    End Function
    Public Function ConsultaRepCarXSector(ByVal Filtro As String, ByVal SECTOR As String, ByVal Conse_Repcarga As String, ByVal SQL_Comman As SqlCommand, ByVal Palabra As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman

            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            If Palabra <> "" Then
                Consulta = "SELECT [Consecutivo],[ItemCode],[Descripcion],[sector],[Cantidad],[Total],[CodeBars],[Bodega],[Bodeguero],[Faltante],[Motivo],[Chequeador],[Faltante_Chequeador],[Motivo_Chequeador],[FacINI],[FacFIN],[Ruta],[Fecha],[Hora],[Cajas],[Cerrado],[ConB1],[Anulado],[U_Gramaje],[Subido],[Unidades_x_Caja],[Marca],[Chequeado],[Sacado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE [Consecutivo] = '" & Conse_Repcarga & "' and [Descripcion] like '%" & Palabra & "%' ORDER BY [sector] ASC"
            Else

                If Filtro = "TODO" Then

                    Consulta = "SELECT [Consecutivo],[ItemCode],[Descripcion],[sector],[Cantidad],[Total],[CodeBars],[Bodega],[Bodeguero],[Faltante],[Motivo],[Chequeador],[Faltante_Chequeador],[Motivo_Chequeador],[FacINI],[FacFIN],[Ruta],[Fecha],[Hora],[Cajas],[Cerrado],[ConB1],[Anulado],[U_Gramaje],[Subido],[Unidades_x_Caja],[Marca],[Chequeado],[Sacado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE [Consecutivo] = '" & Conse_Repcarga & "' ORDER BY [sector] ASC"


                End If
                If Filtro = "TODO" And SECTOR <> "" And SECTOR <> "0" And SECTOR <> "TODOS" Then
                    Consulta = "SELECT [Consecutivo],[ItemCode],[Descripcion],[sector],[Cantidad],[Total],[CodeBars],[Bodega],[Bodeguero],[Faltante],[Motivo],[Chequeador],[Faltante_Chequeador],[Motivo_Chequeador],[FacINI],[FacFIN],[Ruta],[Fecha],[Hora],[Cajas],[Cerrado],[ConB1],[Anulado],[U_Gramaje],[Subido],[Unidades_x_Caja],[Marca],[Chequeado],[Sacado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE [Consecutivo] = '" & Conse_Repcarga & "' and [sector] = '" & SECTOR & "' ORDER BY [ItemCode] ASC"
                End If
                If Filtro = "CHEQUEADO" And SECTOR <> "TODOS" Then
                    Consulta = "SELECT [Consecutivo],[ItemCode],[Descripcion],[sector],[Cantidad],[Total],[CodeBars],[Bodega],[Bodeguero],[Faltante],[Motivo],[Chequeador],[Faltante_Chequeador],[Motivo_Chequeador],[FacINI],[FacFIN],[Ruta],[Fecha],[Hora],[Cajas],[Cerrado],[ConB1],[Anulado],[U_Gramaje],[Subido],[Unidades_x_Caja],[Marca],[Chequeado],[Sacado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE [Consecutivo] = '" & Conse_Repcarga & "' AND [Chequeado] = 'SI' and [sector] = '" & SECTOR & "' ORDER BY [ItemCode] ASC"
                End If
                If Filtro = "CHEQUEADO" Then
                    Consulta = "SELECT [Consecutivo],[ItemCode],[Descripcion],[sector],[Cantidad],[Total],[CodeBars],[Bodega],[Bodeguero],[Faltante],[Motivo],[Chequeador],[Faltante_Chequeador],[Motivo_Chequeador],[FacINI],[FacFIN],[Ruta],[Fecha],[Hora],[Cajas],[Cerrado],[ConB1],[Anulado],[U_Gramaje],[Subido],[Unidades_x_Caja],[Marca],[Chequeado],[Sacado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE [Consecutivo] = '" & Conse_Repcarga & "' AND [Chequeado] = 'SI' ORDER BY [ItemCode] ASC"
                End If
                If Filtro = "NOCHEQUEADO" And SECTOR <> "TODOS" Then
                    Consulta = "SELECT [Consecutivo],[ItemCode],[Descripcion],[sector],[Cantidad],[Total],[CodeBars],[Bodega],[Bodeguero],[Faltante],[Motivo],[Chequeador],[Faltante_Chequeador],[Motivo_Chequeador],[FacINI],[FacFIN],[Ruta],[Fecha],[Hora],[Cajas],[Cerrado],[ConB1],[Anulado],[U_Gramaje],[Subido],[Unidades_x_Caja],[Marca],[Chequeado],[Sacado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE [Consecutivo] = '" & Conse_Repcarga & "'  AND [Chequeado] = 'NO' and [sector] = '" & SECTOR & "' ORDER BY [ItemCode] ASC"
                End If
                If Filtro = "NOCHEQUEADO" Then
                    Consulta = "SELECT [Consecutivo],[ItemCode],[Descripcion],[sector],[Cantidad],[Total],[CodeBars],[Bodega],[Bodeguero],[Faltante],[Motivo],[Chequeador],[Faltante_Chequeador],[Motivo_Chequeador],[FacINI],[FacFIN],[Ruta],[Fecha],[Hora],[Cajas],[Cerrado],[ConB1],[Anulado],[U_Gramaje],[Subido],[Unidades_x_Caja],[Marca],[Chequeado],[Sacado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE [Consecutivo] = '" & Conse_Repcarga & "'  AND [Chequeado] = 'NO' ORDER BY [sector] ASC"
                End If
                If Filtro = "SACADO" And SECTOR <> "TODOS" Then
                    Consulta = "SELECT [Consecutivo],[ItemCode],[Descripcion],[sector],[Cantidad],[Total],[CodeBars],[Bodega],[Bodeguero],[Faltante],[Motivo],[Chequeador],[Faltante_Chequeador],[Motivo_Chequeador],[FacINI],[FacFIN],[Ruta],[Fecha],[Hora],[Cajas],[Cerrado],[ConB1],[Anulado],[U_Gramaje],[Subido],[Unidades_x_Caja],[Marca],[Chequeado],[Sacado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE [Consecutivo] = '" & Conse_Repcarga & "' AND [Sacado] = 'SI' and [sector] = '" & SECTOR & "' ORDER BY [ItemCode] ASC"
                End If
                If Filtro = "SACADO" Then
                    Consulta = "SELECT [Consecutivo],[ItemCode],[Descripcion],[sector],[Cantidad],[Total],[CodeBars],[Bodega],[Bodeguero],[Faltante],[Motivo],[Chequeador],[Faltante_Chequeador],[Motivo_Chequeador],[FacINI],[FacFIN],[Ruta],[Fecha],[Hora],[Cajas],[Cerrado],[ConB1],[Anulado],[U_Gramaje],[Subido],[Unidades_x_Caja],[Marca],[Chequeado],[Sacado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE [Consecutivo] = '" & Conse_Repcarga & "' AND [Sacado] = 'SI' ORDER BY [ItemCode] ASC"
                End If
                If Filtro = "NOSACADO" And SECTOR <> "TODOS" Then
                    Consulta = "SELECT [Consecutivo],[ItemCode],[Descripcion],[sector],[Cantidad],[Total],[CodeBars],[Bodega],[Bodeguero],[Faltante],[Motivo],[Chequeador],[Faltante_Chequeador],[Motivo_Chequeador],[FacINI],[FacFIN],[Ruta],[Fecha],[Hora],[Cajas],[Cerrado],[ConB1],[Anulado],[U_Gramaje],[Subido],[Unidades_x_Caja],[Marca],[Chequeado],[Sacado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE [Consecutivo] = '" & Conse_Repcarga & "'  AND [Sacado] = 'NO' and [sector] = '" & SECTOR & "' ORDER BY [ItemCode] ASC"
                End If
                If Filtro = "NOSACADO" Then
                    Consulta = "SELECT [Consecutivo],[ItemCode],[Descripcion],[sector],[Cantidad],[Total],[CodeBars],[Bodega],[Bodeguero],[Faltante],[Motivo],[Chequeador],[Faltante_Chequeador],[Motivo_Chequeador],[FacINI],[FacFIN],[Ruta],[Fecha],[Hora],[Cajas],[Cerrado],[ConB1],[Anulado],[U_Gramaje],[Subido],[Unidades_x_Caja],[Marca],[Chequeado],[Sacado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE [Consecutivo] = '" & Conse_Repcarga & "'  AND [Sacado] = 'NO' ORDER BY [sector] ASC"
                End If
                If Filtro = "FALTANTES" Then
                    Consulta = "SELECT [Consecutivo],[ItemCode],[Descripcion],[sector],[Cantidad],[Total],[CodeBars],[Bodega],[Bodeguero],[Faltante],[Motivo],[Chequeador],[Faltante_Chequeador],[Motivo_Chequeador],[FacINI],[FacFIN],[Ruta],[Fecha],[Hora],[Cajas],[Cerrado],[ConB1],[Anulado],[U_Gramaje],[Subido],[Unidades_x_Caja],[Marca],[Chequeado],[Sacado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] WHERE [Consecutivo] = '" & Conse_Repcarga & "' and [Faltante_Chequeador] >0 ORDER BY [ItemCode] ASC"
                End If

            End If
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception

        End Try

        Return 0
    End Function
    Public Function ActualizaEstadoSubidRepCarga(ByVal Consecutivo As Integer, ByVal SQL_Comman As SqlCommand)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String
            Consulta = ""
            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] SET [Subido] = 1 WHERE Consecutivo='" & Consecutivo & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            SQL_Comman = Nothing
        Catch ex As Exception
        End Try
    End Function



    Public Function ActualizaConsecutivo(ByVal Conse As Integer, ByVal SQL_Comman As SqlCommand, ByVal TipoRep As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman

            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            If TipoRep = "Carga" Then
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Empresa] SET [Conse_RepCarga] = " & Conse
            ElseIf TipoRep = "Devoluciones" Then
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Empresa] SET [Conse_RepDevoluciones] = " & Conse
            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)




            SQL_Comman = Nothing
            Return TABLA
        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN ObtieneConsecutivo [ " & ex.Message & " ]")
            VariablesGlobales.Obj_Log.Log("ERROR EN ObtieneConsecutivo [ " & ex.Message & " ]", "MR")
        End Try

        Return 0
    End Function
#End Region

    Public Function ModificaConsEmpresa(ByVal SQL_Comman As SqlCommand, ByVal Sector As String, ByVal Consecutivo As String)

        Try
            Dim Consulta As String
            Consulta = ""
            Consulta = "UPDATE  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Empresa] SET Conse_RepCarga='" & Consecutivo & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
        End Try
    End Function
    Public Function ModificaConsSector(ByVal SQL_Comman As SqlCommand, ByVal Sector As String, ByVal Consecutivo As String)

        Try
            Dim Consulta As String
            Consulta = ""
            Consulta = "UPDATE  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Bodegueros]  SET [SinChequear] = " & Consecutivo & " Where Sector ='" & Sector & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertaUltimFactura(ByVal SQL_Comman As SqlCommand, ByVal Ultima_Factura As String, ByVal TipoReporte As String)

        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            Consulta = ""

            If TipoReporte = "Carga" Then
                Consulta = "UPDATE  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Consecutivos]  SET [UltimaFactura] = " & Ultima_Factura
            ElseIf TipoReporte = "Devoluciones" Then
                Consulta = "UPDATE  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Consecutivos]  SET [UltimaFacRevDev] = " & Ultima_Factura
            End If

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            SQL_Comman = Nothing
        Catch ex As Exception

        End Try
    End Function

    Public Function ObtieneInfoEmmail(ByVal SQL_Comman As SqlCommand)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""


            Consulta = "SELECT [Correo],[ClaveEmail],[Telefono],[Telefono2] FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Empresa]"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA


        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneInfoEmmail [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ExisteEmpresa(ByVal SQL_Comman As SqlCommand)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""


            Consulta = "SELECT count([Cedula]) as NumEmpresas FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Empresa]"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)



            If TABLA.Rows.Count > 0 And TABLA.Rows(0).Item("NumEmpresas").ToString() <> "0" Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR en ExisteEmpresa [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ObtieneCedulaEmpresa(ByVal SQL_Comman As SqlCommand)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""


            Consulta = "SELECT [Cedula] FROM " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Empresa]"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA.Rows(0).Item("Cedula").ToString()


        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneCedulaEmpresa [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ConsultaConsecutivoDevoluciones(ByVal SQL_Comman As SqlCommand)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "SELECT  [Devoluciones] from  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Consecutivo_Reportes] "
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA.Rows(0).Item("Devoluciones").ToString()


        Catch ex As Exception
            MessageBox.Show("ERROR en ConsultaConsecutivoDevoluciones [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ObtieneRutas(ByVal SQL_Comman As SqlCommand)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "SELECT T1.Code, T1.Name FROM [BD_Bourne].[dbo].[@RUTAS]  T1"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA


        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneRutas [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function ActualizaNota(ByVal SQL_Comman As SqlCommand, CodChofer As String, NombreChofer As String, CodCliente As String, NombreCliente As String, Credito As String, NumFactura As String, DocEntry As String, Motivo As String, IdRuta As String, Ruta As String, Mont_Imp As Double, Sub_Total As Double, Mont_Desc As Double, Total As Double, Procesada As String, NumMarchamo As String, DocNum As String, Comentario As String)
        Try

            Dim Consulta As String
            Consulta = ""

            Consulta = "UPDATE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Devoluciones]
               SET [CodChofer] = '" & CodChofer & "'
                  ,[NombreChofer] ='" & NombreChofer & "'
                  ,[CodCliente] = '" & CodCliente & "'
                  ,[NombreCliente] = '" & NombreCliente & "'
                  ,[NumFactura] = '" & NumFactura & "'
                  ,[DocEntry] ='" & DocEntry & "'
                  ,[Motivo] ='" & Motivo & "'
                  ,[IdRuta] = '" & IdRuta & "'
                  ,[Ruta] = '" & Ruta & "'
                  ,[Mont_Imp] = " & Mont_Imp & "
                  ,[Sub_Total] =" & Sub_Total & "
                  ,[Mont_Desc] =" & Mont_Desc & "
                  ,[Total] = " & Total & "
                  ,[Procesada] = '" & Procesada & "'
                  ,[NumMarchamo] = '" & NumMarchamo & "'    
                  ,[Comentario] = '" & Comentario & "'
             WHERE [DocNum] = '" & DocNum & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en ActualizaNota [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ActualizaDetalleNota(ByVal SQL_Comman As SqlCommand, ByVal DocNum As String, ByVal ItemCode As String, ByVal Quantity As String, ByVal Porc_DescAnt As String,
                                          ByVal Porc_Desc As String, ByVal Porc_Desc_Fijo As String, Porc_Desc_Promo As String, Total As String, ByVal Bodega As String, ByVal MotivoLinea As String, ByVal Precio As String,
                                         Mont_Imp As String, Sub_Total As String, Mont_Desc As String, Procesada As String)
        Try

            Dim Consulta As String
            Consulta = ""
            Consulta = "UPDATE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[DevolucionesDetalle]
                       SET [Precio] = " & Precio & "
                          ,[Quantity] = '" & Quantity & "'
                          ,[Porc_Desc] = " & Porc_Desc & "
                          ,[Motivo] = '" & MotivoLinea & "'
                          ,[Porc_Desc_Fijo] = '" & Porc_Desc_Fijo & "'
                          ,[Porc_Desc_Promo] = '" & Porc_Desc_Promo & "'
                          ,[Mont_Imp] = " & Mont_Imp & "
                          ,[Sub_Total] = " & Sub_Total & "
                          ,[Mont_Desc] = " & Mont_Desc & "
                          ,[Total] = " & Total & "
                          ,[Procesada] = '" & Procesada & "'
                     WHERE [DocNum] = '" & DocNum & "' and [ItemCode] = '" & ItemCode & "' and  [Porc_Desc] = '" & Porc_DescAnt & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en ActualizaDetalleNota [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ActualizaConsecutivoDevoluciones(ByVal SQL_Comman As SqlCommand, ByVal Consecutivo As String)

        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            Consulta = ""
            Consulta = "UPDATE  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Consecutivo_Reportes]  SET [Devoluciones] = " & Consecutivo
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            SQL_Comman = Nothing
        Catch ex As Exception

        End Try
    End Function

    Public Function ActualizaConsecutivoRepRepFacturas(ByVal SQL_Comman As SqlCommand, ByVal Consecutivo As String)

        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            Consulta = ""
            Consulta = "UPDATE  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Consecutivo_Reportes]  SET [RepFacturas] = " & Consecutivo
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            SQL_Comman = Nothing
        Catch ex As Exception
            VariablesGlobales.Obj_Log.Log("ERROR en ActualizaConsecutivoRepRepFacturas [" & Consecutivo & "] [ " & ex.Message & " ]", "MR")
        End Try
    End Function
    Public Function ConsultaConsecutivoRepRepFacturas(ByVal SQL_Comman As SqlCommand)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "SELECT  [RepFacturas] from  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Consecutivo_Reportes] "
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA.Rows(0).Item("RepFacturas").ToString()


        Catch ex As Exception
            MessageBox.Show("ERROR en ConsultaConsecutivRepFacturas [ " & ex.Message & " ]")
            VariablesGlobales.Obj_Log.Log("ERROR en ConsultaConsecutivRepFacturas [ " & ex.Message & " ]", "MR")
        End Try
    End Function
    Public Function ConsultaUltimaFactura(ByVal SQL_Comman As SqlCommand, ByVal TipoRep As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            If TipoRep = "Carga" Then
                Consulta = "SELECT  [UltimaFactura] from  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Consecutivos] "
                ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
                ADATER.Fill(TABLA)
                Return TABLA.Rows(0).Item("UltimaFactura").ToString()
            ElseIf TipoRep = "Devolucion" Then
                Consulta = "SELECT  [UltimaFacRevDev] from  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Consecutivos] "
                ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
                ADATER.Fill(TABLA)
                Return TABLA.Rows(0).Item("UltimaFacRevDev").ToString()
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR en ConsultaUltimaFactura [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function GUARDA_ReporteDevoluciones(ByVal Consecutivo As String, ByVal Fecha As String, ByVal ItemCode As String, ByVal Descripcion As String, ByVal Bodega As String, ByVal Cantidad As String, ByVal NumBoleta As String, ByVal Sistema As String, ByVal Motivo As String, ByVal Chofer As String, ByVal txt_FacturaINI As String, ByVal txt_FacturaFIN As String, ByVal Bodega_Nombre As String, ByVal Nombre_Chofer As String, ByVal SQL_Comman2 As SqlCommand)
        Try
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL
            Consulta = ""
            Consulta = "INSERT INTO  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Rep_Devo] ([Fecha],[Consecutivo],[ItemCode],[Descripcion],[Bodega],[Cantidad],[NumBoleta],[NumSistema],[Motivo],[Chofer],[FacINI],[FacFIN],[Chequeado],[Cant_Mover],[Accion],[CodArtCambiado],[Bodega_Nombre],[Chofer_Nombre],[Bod_Destino]) VALUES('" & Fecha & "','" & Consecutivo & "','" & ItemCode & "','" & Descripcion & "','" & Bodega & "','" & Cantidad & "','" & NumBoleta & "','" & Sistema & "','" & Motivo & "','" & Chofer & "','" & txt_FacturaINI & "','" & txt_FacturaFIN & "','NO','0','0','0','" & Bodega_Nombre & "','" & Nombre_Chofer & "','')"
            SQL_Comman2.CommandText = Consulta
            SQL_Comman2.ExecuteNonQuery()
            SQL_Comman2 = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en GUARDA_ReporteDevoluciones [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function ConsultaRepDevoluciones(ByVal TXTB_INI As String, ByVal TXTB_FIN As String, ByVal Fecha As String, ByVal SQL_Comman As SqlCommand)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL
            Consulta = ""
            If Fecha = "" Then
                Consulta = "SELECT * FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Rep_Devo] where [FacINI]= '" & TXTB_INI & "' and  [FacFIN] = '" & TXTB_FIN & "'"
            Else
                Consulta = "SELECT Consecutivo,Fecha,FacINI,FacFIN FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Rep_Devo] where [Fecha]= '" & Fecha & "' GROUP BY Consecutivo,Fecha,FacINI,FacFIN"
            End If





            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN ConsultaRepDevoluciones [ " & ex.Message & " ]")
        End Try

        Return 0
    End Function
    Public Function ObtieneConsecutivoRepCarga(ByVal SQL_Comman As SqlCommand, ByVal TipoReporte As String)

        Dim table As New DataTable

        Try
            Dim Consecutivo As String
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            If TipoReporte = "Carga" Then
                Consulta = "SELECT [Conse_RepCarga] FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Empresa] "
            ElseIf TipoReporte = "Devoluciones" Then
                Consulta = "SELECT [Conse_RepDevoluciones] FROM  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Empresa] "
            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Dim cont As Integer

            For Each row As DataRow In TABLA.Rows
                'obtiene los datos de una linea
                If TipoReporte = "Carga" Then
                    Consecutivo = TABLA.Rows(cont).Item("Conse_RepCarga").ToString()
                ElseIf TipoReporte = "Devoluciones" Then
                    Consecutivo = TABLA.Rows(cont).Item("Conse_RepDevoluciones").ToString()
                End If

                cont += 1
            Next
            Return Consecutivo
        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN ObtieneConsecutivo [ " & ex.Message & " ]")
        End Try

        Return 0
    End Function

#Region "Funciones Parametros para Android Nodegueros"
    Public Function AgregarBodeguero(ByVal SQL_Comman As SqlCommand, ByVal CodBodeguero As String, ByVal Nombre As String, ByVal Telefono As String, _
                                     ByVal Conse_RepCarga As String, ByVal Conse_RepDevoluciones As String, ByVal Correo As String, ByVal FTP As String, _
                                      ByVal Puesto As String, ByVal Cedula As String, ByVal Sector1 As String, _
                                      ByVal Sector2 As String, ByVal Sector3 As String, ByVal Sector4 As String, ByVal Sector5 As String, ByVal Sector6 As String, _
                                      ByVal Sector7 As String, ByVal Sector8 As String, ByVal Sector9 As String, ByVal Sector10 As String, ByVal Sector11 As String, ByVal Sector12 As String, ByVal Sector13 As String, ByVal Sector14 As String, ByVal Sector15 As String, ByVal Sector16 As String, ByVal Sector17 As String, ByVal Sector18 As String, ByVal Sector19 As String, ByVal Sector20 As String, ByVal Clave As String, ByVal Usuario As String)

        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            Consulta = ""
            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Bodegueros]" &
                               "([CodBodeguero]" &
                               ",[Nombre]" &
                               ",[Telefono]" &
                               ",[Conse_RepCarga]" &
                               ",[Conse_RepDevoluciones]" &
                               ",[Correo]" &
                               ",[FTP]" &
                               ",[Puesto]" &
                               ",[Cedula]" &
                               ",[Sector1]" &
                               ",[Sector2]" &
                               ",[Sector3]" &
                               ",[Sector4]" &
                               ",[Sector5]" &
                               ",[Sector6]" &
                               ",[Sector7]" &
                               ",[Sector8]" &
                               ",[Sector9]" &
                               ",[Sector10]" &
                               ",[Sector11]" &
                               ",[Sector12]" &
                               ",[Sector13]" &
                               ",[Sector14]" &
                               ",[Sector15]" &
                               ",[Sector16]" &
                               ",[Sector17]" &
                               ",[Sector18]" &
                               ",[Sector19]" &
                               ",[Sector20]" &
                               ",[Usuario]" &
                               ",[Clave])" &
                       "VALUES" &
                               "('" & CodBodeguero & "'" &
                               ",'" & Nombre & "'" &
                               ",'" & Telefono & "'" &
                               ",'" & Conse_RepCarga & "'" &
                               ",'" & Conse_RepDevoluciones & "'" &
                               ",'" & Correo & "'" &
                               ",'" & FTP & "'" &
                               ",'" & Puesto & "'" &
                               ",'" & Cedula & "'" &
                               ",'" & Sector1 & "'" &
                               ",'" & Sector2 & "'" &
                               ",'" & Sector3 & "'" &
                               ",'" & Sector4 & "'" &
                               ",'" & Sector5 & "'" &
                               ",'" & Sector6 & "'" &
                               ",'" & Sector7 & "'" &
                               ",'" & Sector8 & "'" &
                               ",'" & Sector9 & "'" &
                               ",'" & Sector10 & "'" &
                               ",'" & Sector11 & "'" &
                               ",'" & Sector12 & "'" &
                               ",'" & Sector13 & "'" &
                               ",'" & Sector14 & "'" &
                               ",'" & Sector15 & "'" &
                               ",'" & Sector16 & "'" &
                               ",'" & Sector17 & "'" &
                               ",'" & Sector18 & "'" &
                               ",'" & Sector19 & "'" &
                               ",'" & Sector20 & "'" &
                               ",'" & Usuario & "'" &
                               ",'" & Clave & "')"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()



            Sectores_Autorizados(SQL_Comman, CodBodeguero, Sector1, Sector2, Sector3, Sector4, Sector5, Sector6, Sector7, Sector8, Sector9, Sector10, Sector11, Sector12, Sector13, Sector14, Sector15, Sector16, Sector17, Sector18, Sector19, Sector20)


            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            SQL_Comman = Nothing
        Catch ex As Exception

        End Try
    End Function


    Public Function Sectores_Autorizados(ByVal SQL_Comman As SqlCommand, ByVal CodBodeguero As String, ByVal Sector1 As String, ByVal Sector2 As String, ByVal Sector3 As String, ByVal Sector4 As String, ByVal Sector5 As String, ByVal Sector6 As String, ByVal Sector7 As String, ByVal Sector8 As String, ByVal Sector9 As String, ByVal Sector10 As String, ByVal Sector11 As String, ByVal Sector12 As String, ByVal Sector13 As String, ByVal Sector14 As String, ByVal Sector15 As String, ByVal Sector16 As String, ByVal Sector17 As String, ByVal Sector18 As String, ByVal Sector19 As String, ByVal Sector20 As String)

        SQL_Comman.CommandText = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]  WHERE [id_bodeguero]='" & CodBodeguero & "'"
        SQL_Comman.ExecuteNonQuery()

        If Sector1 = 1 Then
            SQL_Comman.CommandText = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES('" & CodBodeguero & "','1')"
            SQL_Comman.ExecuteNonQuery()
        End If

        If Sector2 = 1 Then
            SQL_Comman.CommandText = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES('" & CodBodeguero & "','2')"
            SQL_Comman.ExecuteNonQuery()
        End If

        If Sector3 = 1 Then
            SQL_Comman.CommandText = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES('" & CodBodeguero & "','3')"
            SQL_Comman.ExecuteNonQuery()
        End If

        If Sector4 = 1 Then
            SQL_Comman.CommandText = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES('" & CodBodeguero & "','4')"
            SQL_Comman.ExecuteNonQuery()
        End If

        If Sector5 = 1 Then
            SQL_Comman.CommandText = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES('" & CodBodeguero & "','5')"
            SQL_Comman.ExecuteNonQuery()
        End If

        If Sector6 = 1 Then
            SQL_Comman.CommandText = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES('" & CodBodeguero & "','6')"
            SQL_Comman.ExecuteNonQuery()
        End If

        If Sector7 = 1 Then
            SQL_Comman.CommandText = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES('" & CodBodeguero & "','7')"
            SQL_Comman.ExecuteNonQuery()
        End If

        If Sector8 = 1 Then
            SQL_Comman.CommandText = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES('" & CodBodeguero & "','8')"
            SQL_Comman.ExecuteNonQuery()
        End If

        If Sector9 = 1 Then
            SQL_Comman.CommandText = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES('" & CodBodeguero & "','9')"
            SQL_Comman.ExecuteNonQuery()
        End If

        If Sector10 = 1 Then

            SQL_Comman.CommandText = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES('" & CodBodeguero & "','10')"
            SQL_Comman.ExecuteNonQuery()
        End If

        If Sector11 = 1 Then

            SQL_Comman.CommandText = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES('" & CodBodeguero & "','11')"
            SQL_Comman.ExecuteNonQuery()
        End If

        If Sector12 = 1 Then

            SQL_Comman.CommandText = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES('" & CodBodeguero & "','12')"
            SQL_Comman.ExecuteNonQuery()
        End If

        If Sector13 = 1 Then

            SQL_Comman.CommandText = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES('" & CodBodeguero & "','13')"
            SQL_Comman.ExecuteNonQuery()
        End If

        If Sector14 = 1 Then

            SQL_Comman.CommandText = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES('" & CodBodeguero & "','14')"
            SQL_Comman.ExecuteNonQuery()
        End If

        If Sector15 = 1 Then

            SQL_Comman.CommandText = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES('" & CodBodeguero & "','15')"
            SQL_Comman.ExecuteNonQuery()
        End If

        If Sector16 = 1 Then

            SQL_Comman.CommandText = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES('" & CodBodeguero & "','16')"
            SQL_Comman.ExecuteNonQuery()
        End If

        If Sector17 = 1 Then

            SQL_Comman.CommandText = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES('" & CodBodeguero & "','17')"
            SQL_Comman.ExecuteNonQuery()
        End If

        If Sector18 = 1 Then

            SQL_Comman.CommandText = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES('" & CodBodeguero & "','18')"
            SQL_Comman.ExecuteNonQuery()
        End If

        If Sector19 = 1 Then

            SQL_Comman.CommandText = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES('" & CodBodeguero & "','19')"
            SQL_Comman.ExecuteNonQuery()
        End If

        If Sector20 = 1 Then

            SQL_Comman.CommandText = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Sectores_autorizados]([id_bodeguero],[Sector]) VALUES('" & CodBodeguero & "','20')"
            SQL_Comman.ExecuteNonQuery()
        End If
    End Function

    Public Function ModificaBodeguero(ByVal SQL_Comman As SqlCommand, ByVal CodBodeguero As String, ByVal Nombre As String, ByVal Telefono As String, _
                                     ByVal Conse_RepCarga As String, ByVal Conse_RepDevoluciones As String, ByVal Correo As String, ByVal FTP As String, _
                                      ByVal Puesto As String, ByVal Cedula As String, ByVal Sector1 As String, _
                                      ByVal Sector2 As String, ByVal Sector3 As String, ByVal Sector4 As String, ByVal Sector5 As String, ByVal Sector6 As String, _
                                      ByVal Sector7 As String, ByVal Sector8 As String, ByVal Sector9 As String, ByVal Sector10 As String, _
                                      ByVal Sector11 As String, ByVal Sector12 As String, ByVal Sector13 As String, ByVal Sector14 As String, ByVal Sector15 As String, ByVal Sector16 As String, ByVal Sector17 As String, ByVal Sector18 As String, ByVal Sector19 As String, ByVal Sector20 As String, ByVal Clave As String, ByVal Usuario As String)

        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            Consulta = ""
            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Bodegueros] SET" &
                               "[Nombre]='" & Nombre & "'" &
                               ",[Telefono]='" & Telefono & "'" &
                               ",[Conse_RepCarga]='" & Conse_RepCarga & "'" &
                               ",[Conse_RepDevoluciones]='" & Conse_RepDevoluciones & "'" &
                               ",[Correo] ='" & Correo & "'" &
                               ",[FTP]='" & FTP & "'" &
                               ",[Puesto]='" & Puesto & "'" &
                               ",[Cedula]='" & Cedula & "'" &
                               ",[Sector1]='" & Sector1 & "'" &
                               ",[Sector2]='" & Sector2 & "'" &
                               ",[Sector3]='" & Sector3 & "'" &
                               ",[Sector4]='" & Sector4 & "'" &
                               ",[Sector5]='" & Sector5 & "'" &
                               ",[Sector6]='" & Sector6 & "'" &
                               ",[Sector7]='" & Sector7 & "'" &
                               ",[Sector8]='" & Sector8 & "'" &
                               ",[Sector9]='" & Sector9 & "'" &
                               ",[Sector10]='" & Sector10 & "'" &
                               ",[Sector11]='" & Sector11 & "'" &
                               ",[Sector12]='" & Sector12 & "'" &
                               ",[Sector13]='" & Sector13 & "'" &
                               ",[Sector14]='" & Sector14 & "'" &
                               ",[Sector15]='" & Sector15 & "'" &
                               ",[Sector16]='" & Sector16 & "'" &
                               ",[Sector17]='" & Sector17 & "'" &
                               ",[Sector18]='" & Sector18 & "'" &
                               ",[Sector19]='" & Sector19 & "'" &
                               ",[Sector20]='" & Sector20 & "'" &
                               ",[Usuario]='" & Usuario & "'" &
                               ",[Clave]='" & Clave & "'" &
                               "WHERE [CodBodeguero] ='" & CodBodeguero & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()

            Sectores_Autorizados(SQL_Comman, CodBodeguero, Sector1, Sector2, Sector3, Sector4, Sector5, Sector6, Sector7, Sector8, Sector9, Sector10, Sector11, Sector12, Sector13, Sector14, Sector15, Sector16, Sector17, Sector18, Sector19, Sector20)

            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            SQL_Comman = Nothing
        Catch ex As Exception

        End Try
    End Function

    Public Function ConsultaBodegueros(ByVal SQL_Comman As SqlCommand)
        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""

            Consulta = "SELECT [CodBodeguero]" &
                          ",[Nombre]" &
                          ",[Telefono]" &
                          ",[Conse_RepCarga]" &
                          ",[Conse_RepDevoluciones]" &
                          ",[Correo]" &
                          ",[FTP]" &
                          ",[Puesto]" &
                          ",[Cedula]" &
                          ",[Sector1]" &
                          ",[Sector2]" &
                          ",[Sector3]" &
                          ",[Sector4]" &
                          ",[Sector5]" &
                          ",[Sector6]" &
                          ",[Sector7]" &
                          ",[Sector8]" &
                          ",[Sector9]" &
                          ",[Sector10]" &
                          ",[Sector11]" &
                          ",[Sector12]" &
                          ",[Sector13]" &
                          ",[Sector14]" &
                          ",[Sector15]" &
                          ",[Sector16]" &
                          ",[Sector17]" &
                          ",[Sector18]" &
                          ",[Sector19]" &
                          ",[Sector20]" &
                          ",[Clave]" &
                          ",[Usuario] " &
                    "FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Bodegueros]"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            SQL_Comman = Nothing

            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception

        End Try

        Return 0
    End Function

    Public Function Consulta_UN_Bodeguero(ByVal SQL_Comman As SqlCommand, ByVal Usuario As String)
        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""

            Consulta = "SELECT [Nombre],[Usuario],[Clave],[Puesto],[Sector],[SinChequear],[Chequeado]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Bodegueros] where [Usuario] = '" & Usuario & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception

        End Try


    End Function

    Public Function Consulta_Usuarios_Bodeguero(ByVal SQL_Comman As SqlCommand)
        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""

            Consulta = "SELECT [Usuario],[Nombre] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Bodegueros] group by [Usuario],[Nombre]  "
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception

        End Try


    End Function


    Public Function ActualizaRepCarga(ByVal SQL_Comman As SqlCommand, ByVal Consecutivo As String, ByVal ItemCode As String, ByVal Cantidad As String, ByVal Faltante As String, ByVal Motivo As String, ByVal Usuario As String)
        Try
            Dim Obj_SQL_CONEXION As New CONEXION_TO_SQLSERVER
            Dim cont As Integer = 0
            Dim Consulta As String
            Consulta = ""

            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] SET  [Chequeado]='SI', [Faltante_Chequeador] = '" & Faltante & "' ,[Motivo_Chequeador] = '" & Motivo & "' ,Chequeador='" & Usuario & "', [Sacado_Chequeador]='" & Cantidad & "' WHERE [ItemCode] = '" & ItemCode & "' AND [Consecutivo] = '" & Consecutivo & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR en ActualizaRepCarga [ " & ex.Message & " ]")
        End Try
        Return 0
    End Function


    'consulta las lineas de un reporte de carga chequeado
    Public Function LineaRepCachequeado(ByVal SQL_Comman As SqlCommand, ByVal Consecutivo As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman

            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""



            Consulta = "SELECT  [ItemCode],[Descripcion],[sector],[Cantidad],[Total],[Faltante],[Motivo] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] where  [Consecutivo]='" & Consecutivo & "' and  [Chequeado]='SI' ORDER BY [ItemCode] desc"


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception

        End Try

        Return 0
    End Function


    Public Function ActualizarLineRepCarga(ByVal Consecutivo As String, ByVal Txb_CodArti As String, ByVal Txb_Descripcion As String, ByVal Txb_Solicitado As String, ByVal Txb_FaltanteBodeguero As String, ByVal cbx_MotivoBodeguero As String, ByVal Txb_FaltanteChequeador As String, ByVal cbx_MotivoChequeador As String, ByVal Sacado_Chequeador As String, ByVal Sacado_Bodeguero As String, ByVal SQL_Comman As SqlCommand)
        Try


            Dim Obj_SQL_CONEXION As New CONEXION_TO_SQLSERVER
            Dim cont As Integer = 0

            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""

            'Actualiza el estado dependiendo del numero de aplicacion que sea

            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Carg_Sector] SET [Faltante] = '" & Txb_FaltanteBodeguero & "' ,[Motivo] = '" & cbx_MotivoBodeguero & "', [Faltante_Chequeador] = '" & Txb_FaltanteChequeador & "' ,[Motivo_Chequeador] = '" & cbx_MotivoChequeador & "',[Sacado_Chequeador]='" & Sacado_Chequeador & "',[Sacado_Bodeguero]='" & Sacado_Bodeguero & "'  WHERE [ItemCode] = '" & Txb_CodArti & "' AND [Consecutivo] = '" & Consecutivo & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

        Catch ex As Exception
            MessageBox.Show("ERROR en Actualiza_InfoNOARCHIVO_FTP [ " & ex.Message & " ]")
        End Try
        Return 0
    End Function

    Public Function Actualiza_Consecutivos(ByVal SQL_Comman As SqlCommand, ByVal Nombre As String, ByVal Usuario As String, ByVal Clave As String, ByVal Puesto As String, ByVal Sector As String, ByVal SinChequear As String, ByVal Chequeado As String)
        Try

            Dim Obj_SQL_CONEXION As New CONEXION_TO_SQLSERVER
            Dim cont As Integer = 0
            ' para la conexion al comman 
            'Dim SQL_Comman As New SqlCommand
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""

            'Actualiza el estado dependiendo del numero de aplicacion que sea

            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Bodegueros] SET [Nombre] = '" & Nombre & "',[Clave] = '" & Clave & "' ,[Puesto] = '" & Puesto & "', [SinChequear] = '" & SinChequear & "' ,[Chequeado] = '" & Chequeado & "'  WHERE [Usuario]='" & Usuario & "' AND [Sector] = '" & Sector & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

        Catch ex As Exception
            MessageBox.Show("ERROR en Actualiza_InfoNOARCHIVO_FTP [ " & ex.Message & " ]")
        End Try
        Return 0
    End Function

    Public Function EliminaBodeguero(ByVal SQL_Comman As SqlCommand, ByVal CodBodeguero As String)
        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Bodegueros] WHERE [CodBodeguero]='" & CodBodeguero & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()

            SQL_Comman = Nothing
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

        Catch ex As Exception
            MessageBox.Show("ERROR en Consulta_Estado_SubidaSAP [ " & ex.Message & " ]")
        End Try

    End Function
#End Region

#Region "Administrar Usuarios"

    Public Function Login(ByVal SQL_Comman As SqlCommand, ByVal Usuario As String, ByVal Clave As String)
        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""

            Consulta = "SELECT [Usuario],[Password],[Puesto] ,[Cambiar] ,[id]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Users] where [Usuario] = '" & Usuario & "' and [Password] = '" & Clave & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            SQL_Comman = Nothing

            Return TABLA

        Catch ex As Exception

        End Try


    End Function




    Public Function ObtieneUsuarios(ByVal SQL_Comman As SqlCommand)
        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "SELECT T0.[id], T0.[Cedula], T0.[Nombre], T0.[Puesto] , T0.[Usuario]  , T0.[Password]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Users] T0 "

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneUsuarios [ " & ex.Message & " ]")
        End Try
    End Function


    Public Function INSERTA_Usuario(ByVal SQL_Comman As SqlCommand, ByVal Usuario As String, ByVal Password As String, ByVal Puesto As String, ByVal Cedula As String, ByVal Nombre As String, ByVal Cambiar As String)
        Try

            'Dim SQL_Comman As New SqlCommand
            'para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXIONSERVER.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")

            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL
            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Users] ([Usuario],[Password],[Puesto],[Cedula] ,[Nombre],[Cambiar]) VALUES('" & Usuario & "','" & Password & "','" & Puesto & "','" & Cedula & "','" & Nombre & "','" & Cambiar & "')"



            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()

        Catch ex As Exception
            'ERRORES = "[ " & Now & " ] ERROR INSERTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try

    End Function



    Public Function ModificaUsuario(ByVal SQL_Comman As SqlCommand, ByVal Usuario As String, ByVal Password As String, ByVal Puesto As String, ByVal Cedula As String, ByVal Nombre As String, ByVal Codigo As String, ByVal Cambiar As String)
        Try
            Dim cont As Integer = 0
            Dim Consulta As String

            Consulta = ""
            If Puesto = "" Then
                'indica que esta modificando solo la clave desde la ventana login

                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Users] SET [Usuario] = '" & Usuario & "' ,[Password] ='" & Password & "' ,[Cambiar] = '0' WHERE id='" & Codigo & "'"
            Else
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Users] SET [Usuario] = '" & Usuario & "' ,[Password] ='" & Password & "' ,[Puesto] = '" & Puesto & "' ,[Cedula] = '" & Cedula & "',[Nombre] = '" & Nombre & "',[Cambiar] = '" & Cambiar & "' WHERE id='" & Codigo & "'"
            End If

            'Actualiza el estado dependiendo del numero de aplicacion que sea

            SQL_Comman.CommandText = Consulta

            SQL_Comman.ExecuteNonQuery()

            Return 0
        Catch ex As Exception
            MessageBox.Show("ERROR en ModificaUsuario [ " & ex.Message & " ]")
        End Try

    End Function

#End Region

#Region "Acciones Descuentos Fijos de cliente"



    Public Function AgregaDescFijo(ByVal SQL_Comman As SqlCommand, ByVal ID As Integer, ByVal CodCliente As String, ByVal NombCliente As String, _
                                   ByVal CodProveedor As String, ByVal NombProveedor As String, ByVal familia As String, ByVal Categoria As String, _
                                   ByVal Marca As String, ByVal CodArt As String, ByVal NombArticulo As String, ByVal Desc As String, ByVal Estado As Integer, _
                                    ByVal PeriodoIndefinido As Integer, ByVal Fecha_INI As Date, ByVal Fecha_FIN As Date, ByVal FechaCreado As Date, ByVal FechaCerrado As Date, ByVal Usuario As String, ByVal Accion As String)
        Try
            Dim Consulta As String
            Consulta = ""
            If Accion = "GUARDAR" Then
                Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Desc_Fijos] ([CodCliente],[NombreCliente],[CodProveedor],[NombreProveedor],[Familia],[Categoria],[Marca],[CodArticulo],[NombreArticulo],[Descuento],[Estado],[Indefinido],[FechaIni],[FechaFin],[FechaCreacion],[FechaCerrado],[Usuario]) VALUES('" & CodCliente & "','" & NombCliente & "','" & CodProveedor & "','" & NombProveedor & "','" & familia & "','" & Categoria & "','" & Marca & "','" & CodArt & "','" & NombArticulo & "','" & Desc & "','" & Estado & "','" & PeriodoIndefinido & "','" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Fecha_INI) & "','" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Fecha_FIN) & "','" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(FechaCreado) & "','" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(FechaCerrado) & "','" & Usuario & "')"
            Else
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Desc_Fijos] SET [CodCliente] = '" & CodCliente & "' ,[NombreCliente] ='" & NombCliente & "' ,[CodProveedor] = '" & CodProveedor & "' ,[NombreProveedor] = '" & NombProveedor & "',[Familia] = '" & familia & "',[Categoria] = '" & Categoria & "' ,[Marca] = '" & Marca & "' ,[CodArticulo] = '" & CodArt & "' ,[NombreArticulo] = '" & NombArticulo & "' ,[Descuento] = '" & Desc & "',[Estado]='" & Estado & "',[Indefinido]='" & PeriodoIndefinido & "' WHERE id='" & ID & "'"
            End If

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en AgregaDescFijo [ " & ex.Message & " ]")
        End Try

    End Function


    Public Function CierraDesc(ByVal SQL_Comman As SqlCommand, ByVal ID As Integer, ByVal FechaCierre As Date, ByVal Estado As Integer)
        Try
            Dim Consulta As String
            Consulta = ""

            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Desc_Fijos] SET [FechaCerrado] = '" & FechaCierre & "',[Estado]='" & Estado & "' WHERE id='" & ID & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en AgregaDescFijo [ " & ex.Message & " ]")
        End Try

    End Function

    Public Function EliminaDescFijo(ByVal SQL_Comman As SqlCommand, ByVal id As String)
        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Desc_Fijos] WHERE [id]='" & id & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing


        Catch ex As Exception
            MessageBox.Show("ERROR en EliminaDescFijoExepciones [ " & ex.Message & " ]")
        End Try

    End Function

    Public Function AgregaDescFijoExepciones(ByVal SQL_Comman As SqlCommand, ByVal id As String, ByVal CodCliente As String, ByVal CodProve As String, ByVal NombreProveed As String, ByVal Familia As String, ByVal Categoria As String, ByVal Marca As String, ByVal CodArti As String, ByVal NombreArti As String)
        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Desc_Fijo_Excepciones]([idDescFijo],[CodCliente],[CodProveedor],[Familia],[Categoria],[Marca],[CodArticulo]) VALUES('" & id & "','" & CodCliente & "','" & CodProve & "','" & Familia & "','" & Categoria & "','" & Marca & "','" & CodArti & "')"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing


        Catch ex As Exception
            MessageBox.Show("ERROR en AgregaDescFijo [ " & ex.Message & " ]")
        End Try

    End Function

    Public Function EliminaDescFijoExepciones(ByVal SQL_Comman As SqlCommand, ByVal id As String)
        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Desc_Fijo_Excepciones] WHERE [id]='" & id & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing


        Catch ex As Exception
            MessageBox.Show("ERROR en EliminaDescFijoExepciones [ " & ex.Message & " ]")
        End Try

    End Function

    Public Function ConsultaClientesDescFijos(ByVal SQL_Comman As SqlCommand, ByVal nombre As String)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta1 As String

            Consulta1 = ""
            If nombre <> "" Then
                Consulta1 = "SELECT [id], [CodCliente], [NombreCliente], [CodProveedor], [NombreProveedor], [Familia], [Categoria], [Marca], [CodArticulo], [NombreArticulo], [Descuento], [Grupo], [Usuario], [FechaCreacion], [FechaCerrado], [FechaIni], [FechaFin], [Indefinido], [Estado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Desc_Fijos] where [NombreCliente] like '%" & nombre & "%'"
            Else
                Consulta1 = "SELECT [id], [CodCliente], [NombreCliente], [CodProveedor], [NombreProveedor], [Familia], [Categoria], [Marca], [CodArticulo], [NombreArticulo], [Descuento], [Grupo], [Usuario], [FechaCreacion], [FechaCerrado], [FechaIni], [FechaFin], [Indefinido], [Estado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Desc_Fijos] "
            End If

            ADATER = New SqlDataAdapter(Consulta1, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            ' SQL_Comman = Nothing

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN ObtieneConsecutivo [ " & ex.Message & " ]")
        End Try

        Return 0
    End Function

    'Public Function ConsultaDescFijos(ByVal SQL_Comman As SqlCommand, ByVal CodCliente As String)
    '    Try
    '        'Dim SQL_Comman As New SqlCommand
    '        ' para la conexion al comman
    '        ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
    '        Dim ADATER As New SqlDataAdapter
    '        Dim TABLA As New DataTable
    '        ' para la conexion al comman
    '        Dim Consulta As String
    '        'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL
    '        Consulta = ""
    '        Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Desc_Fijos] WHERE [CodCliente] = '" & CodCliente & "'"
    '        ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
    '        ADATER.Fill(TABLA)
    '        'consulta las excepciones
    '        Form1.DGV_descFijosExepciones.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaExcepciones(SQL_Comman, TABLA.Rows(0)("id").ToString())
    '        ' SQL_Comman = Nothing
    '        Return TABLA
    '    Catch ex As Exception
    '        MessageBox.Show("[ " & Now & " ] ERROR EN ObtieneConsecutivo [ " & ex.Message & " ]")
    '    End Try

    '    Return 0
    'End Function

    Public Function ConsultaExcepciones(ByVal SQL_Comman As SqlCommand, ByVal id As String)
        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL
            Consulta = ""
            Consulta = "SELECT [id],[CodCliente],[CodProveedor],[Familia],[Categoria],[Marca],[CodArticulo] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Desc_Fijo_Excepciones] where [idDescFijo] = '" & id & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            'SQL_Comman = Nothing
            Return TABLA
        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN ObtieneConsecutivo [ " & ex.Message & " ]")
        End Try

        Return 0
    End Function

    Public Function ObtieneFamilias(ByVal SQL_Comman As SqlCommand, ByVal CodProveedor As String)
        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL
            Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ObtieneFamilias] ('" & CodProveedor & "')"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            'SQL_Comman = Nothing

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN ObtieneConsecutivo [ " & ex.Message & " ]")
        End Try

        Return 0
    End Function

    Public Function ObtieneCategorias(ByVal SQL_Comman As SqlCommand, ByVal CodProveedor As String)
        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ObtieneCategoria] ('" & CodProveedor & "')"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            'SQL_Comman = Nothing
            Return TABLA
        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN ObtieneConsecutivo [ " & ex.Message & " ]")
        End Try

        Return 0
    End Function

    Public Function ObtieneMarcas(ByVal SQL_Comman As SqlCommand, ByVal CodProveedor As String)
        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL




            Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ObtieneMarca] ('" & CodProveedor & "')"


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            ' SQL_Comman = Nothing

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN ObtieneConsecutivo [ " & ex.Message & " ]")
        End Try

        Return 0
    End Function

    Public Function ObtieneIDDescFijo(ByVal SQL_Comman As SqlCommand)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String
            Dim ID As Integer
            Consulta = "SELECT (MAX(id)+1) as id FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Desc_Fijos] "

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            If TABLA.Rows.Count > 0 Then
                If TABLA.Rows(0).Item("id").ToString <> "" Then
                    ID = CInt(TABLA.Rows(0).Item("id").ToString)

                Else
                    ID = 0
                End If


            End If
            Return ID


        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN ObtieneConsecutivo [ " & ex.Message & " ]")
        End Try

        Return 0
    End Function

    Public Function ObtieneTodaslasFamilias(ByVal SQL_Comman As SqlCommand)
        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL




            Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ObtieneTODASFamilia] ()"


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            ' SQL_Comman = Nothing

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN ObtieneConsecutivo [ " & ex.Message & " ]")
        End Try

        Return 0
    End Function

    Public Function ObtieneGrupo(ByVal SQL_Comman As SqlCommand, ByVal CodProveedor As String)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String
            Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ObtieneGrupo] ('" & CodProveedor & "')"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN ObtieneGrupo [ " & ex.Message & " ]")
        End Try
        Return 0
    End Function

    Public Function ObtieneTodaslasCategorias(ByVal SQL_Comman As SqlCommand)
        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL




            Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ObtieneTODASCategoria] ()"


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            'SQL_Comman = Nothing

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN ObtieneConsecutivo [ " & ex.Message & " ]")
        End Try

        Return 0
    End Function

    Public Function ObtieneTodaslasMarcas(ByVal SQL_Comman As SqlCommand)
        Try
            'Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL




            Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ObtieneTODASMarca] ()"


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            'SQL_Comman = Nothing

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN ObtieneConsecutivo [ " & ex.Message & " ]")
        End Try

        Return 0
    End Function

    Public Function ObtieneTodaslasGrupos(ByVal SQL_Comman As SqlCommand)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable

            Dim Consulta As String
            Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ObtieneTODOSGrupos] ()"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN ObtieneTodaslasGrupos [ " & ex.Message & " ]")
        End Try

        Return 0
    End Function

    Public Function Obtieneclientes(ByVal SQL_Comman As SqlCommand, ByVal Palabra As String, ByVal Tipo As String)
        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            ' para la conexion al comman
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL



            If Tipo = "S" Then
                Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[OptieneClientes]('" & Palabra & "','" & Tipo & "') UNION " &
                        "SELECT '01' as Codigo, 'BOURNE Y CIA S.A' as Nombre"

            Else
                Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[OptieneClientes]('" & Palabra & "','" & Tipo & "')"


            End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            'SQL_Comman = Nothing

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("[ " & Now & " ] ERROR EN ObtieneConsecutivo [ " & ex.Message & " ]")
        End Try

        Return 0
    End Function

#End Region

#Region "Exportar informacion SELLER"
    Public Function ObtieneRazonesNoVisita(ByVal SQL_Comman As SqlCommand)
        Try
            Dim Tbl_Banco As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""
            Consulta = "SELECT [Codigo],[Razon] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Razones_NoVisita]"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(Tbl_Banco)
            SQL_Comman = Nothing

            Return Tbl_Banco
        Catch ex As Exception
            ' MessageBox.Show("ERROR en ObtieneRazonesNoVisita [ " & ex.Message & " ]")
            Principal.LbL_Errorres.Text = "ERROR en ObtieneRazonesNoVisita [ " & ex.Message & " ]"
            Principal.Time_BorraError.Start()
        End Try
    End Function
    Public Function ObtieneBancos(ByVal SQL_Comman As SqlCommand)
        Try
            Dim Tbl_Banco As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""
            Consulta = "SELECT T0.[BankCode] , T0.[BankName] FROM Bancos T0"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(Tbl_Banco)
            SQL_Comman = Nothing

            Return Tbl_Banco
        Catch ex As Exception
            MessageBox.Show("ERROR en Obtieneclientes_X_Agente [ " & ex.Message & " ]")
        End Try
    End Function 'obtiene los clientes segun un agente para cargarlos en el celular

    Public Function Obtiene_UbicacionesCR(ByVal SQL_Comman As SqlCommand)
        Try
            Dim Tbl_Ubicacion As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""
            Consulta = "SELECT [id_provincia],[nombre_provincia],[id_canton],[nombre_canton],[id_distrito],[nombre_distrito],[id_barrio],[nombre_barrio] FROM Ubicaciones_CostaRica T0"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(Tbl_Ubicacion)
            SQL_Comman = Nothing

            Return Tbl_Ubicacion
        Catch ex As Exception
            MessageBox.Show("ERROR en Obtiene_UbicacionesCR [ " & ex.Message & " ]")
        End Try
    End Function 'obtiene los clientes segun un agente para cargarlos en el celular
    Public Function Obtiene_Descuentos(ByVal SQL_Comman As SqlCommand, Ruta As String)
        Try
            Dim Tbl_Descuentos As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""
            Consulta = "SELECT  T0.CardCode,  T0.ItemCode, T0.Descuento  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].ObtieneDescuentosPorAgente(" & Ruta & ") T0"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(Tbl_Descuentos)
            SQL_Comman = Nothing

            Return Tbl_Descuentos
        Catch ex As Exception
            MessageBox.Show("ERROR en Obtiene_Descuentos [ " & ex.Message & " ]")
        End Try
    End Function



    Public Function Obtieneclientes_X_Agente(ByVal Grupo As String, ByVal Agente As String, ByVal Tbl_Clientes As DataTable, Rutas_Unidicar() As String, ByVal SQL_Comman As SqlCommand)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim cont As Integer = 0
            Dim Consulta As String = ""

            If Rutas_Unidicar Is Nothing Then


                If Grupo = "A" Then
                    Consulta = Consulta & " SELECT * FROM UniversoXAgenteDividido('" & Agente & "')  "
                ElseIf Grupo = "B" Then
                    Consulta = Consulta & " SELECT * FROM UniversoXAgenteDividido_B('" & Agente & "') "
                ElseIf Grupo = "GPS" Then
                    Consulta = Consulta & " SELECT * FROM UniversoXAgente('" & Agente & "') WHERE  U_Latitud IS NOT NULL  "
                Else

                    If Class_VariablesGlobales.XMLParamSAP_CompanyDB = "" Then
                        'Obtiene los datos de la DB de essco
                        Consulta = "SELECT * FROM [essco].UniversoXAgente('" & Agente & "')  "
                    Else
                        Consulta = "SELECT * FROM UniversoXAgente('" & Agente & "')  "
                    End If


                End If


                Else
                    For i As Integer = 0 To Rutas_Unidicar.Count - 1
                        If cont > 0 Then
                            Consulta = Consulta & " UNION "
                        End If

                        If Grupo = "A" Then
                            Consulta = Consulta & " SELECT * FROM UniversoXAgenteDividido('" & Rutas_Unidicar(i).ToString & "')  "
                        ElseIf Grupo = "B" Then
                            Consulta = Consulta & " SELECT * FROM UniversoXAgenteDividido_B('" & Rutas_Unidicar(i).ToString & "') "
                        ElseIf Grupo = "GPS" Then
                            Consulta = Consulta & " SELECT * FROM UniversoXAgente('" & Rutas_Unidicar(i).ToString & "') WHERE  U_Latitud IS NOT NULL  "
                        Else


                        If Class_VariablesGlobales.XMLParamSAP_CompanyDB = "" Then
                            'Obtiene los datos de la DB de essco
                            Consulta = "SELECT * FROM [essco].UniversoXAgente('" & Agente & "')  "
                        Else
                            Consulta = Consulta & "SELECT * FROM UniversoXAgente('" & Rutas_Unidicar(i).ToString & "')  "
                        End If

                    End If

                        cont += 1
                    Next i
                End If






            Consulta = Consulta & " order by CardCode asc "




            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(Tbl_Clientes)
            SQL_Comman = Nothing

            Return Tbl_Clientes
        Catch ex As Exception
            MessageBox.Show("ERROR en Obtieneclientes_X_Agente [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function Obtieneclientes(ByVal Grupo As String, ByVal Agente As String, ByVal Tbl_Clientes As DataTable, ByVal SQL_Comman As SqlCommand)
        Try
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""

            Consulta = "SELECT * FROM Universo('" & Agente & "') order by CardCode asc "

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(Tbl_Clientes)
            SQL_Comman = Nothing

            Return Tbl_Clientes
        Catch ex As Exception
            MessageBox.Show("ERROR en Obtieneclientes [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function Obtiene_InfoConfiguracion(ByVal SQL_Comman As SqlCommand, ByVal Agente As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Info_Configuracion] ('" & Agente & "')"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en Obtiene_InfoConfiguracion [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function Obtiene_InfoConfiguracionChoferes(ByVal SQL_Comman As SqlCommand, ByVal Chofer As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Info_Configuracion_Choferes] ('" & Chofer & "')"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en Obtiene_InfoConfiguracion [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function Obtiene_cxc(ByVal SQL_Comman As SqlCommand, ByVal Agente As String, Rutas_Unidicar() As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim cont As Integer = 0


            If Rutas_Unidicar Is Nothing Then
                Consulta = " SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[FacturasPendientes] ('" & Agente & "') "
            Else
                For i As Integer = 0 To Rutas_Unidicar.Count - 1

                    If cont > 0 Then
                        Consulta = Consulta & " UNION "
                    End If


                    '  Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[FacturasPendientes] ('" & CodCliente & "','" & Agente & "') ORDER BY 2 ASC"
                    Consulta = Consulta & " SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[FacturasPendientes] ('" & Rutas_Unidicar(i).ToString() & "') "

                    cont += 1
                Next
            End If


            Consulta = Consulta & " ORDER BY 2 ASC "

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en Obtiene_cxc [ " & ex.Message & " ]")
        End Try
    End Function


    Public Function Obtiene_cxc_ExportaChoferes(ByVal SQL_Comman As SqlCommand, ByVal Agente As String, ByVal FechaIni As String, ByVal FechaFin As String, Rutas_Unidicar() As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Dim cont As Integer = 0

            If Rutas_Unidicar Is Nothing Then
                Consulta = " Select * From Deliver_CxCRepFac('" & Agente & "','" & FechaIni & "','" & FechaFin & "')"

            Else
                For i As Integer = 0 To Rutas_Unidicar.Count - 1
                    If cont > 0 Then
                        Consulta = Consulta & " UNION "
                    End If

                    Consulta = Consulta & " Select * From Deliver_CxCRepFac('" & Rutas_Unidicar(i).ToString() & "','" & FechaIni & "','" & FechaFin & "')"
                    cont += 1
                Next
            End If



            '  Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[FacturasPendientes] ('" & CodCliente & "','" & Agente & "') ORDER BY 2 ASC"


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en Obtiene_cxc_ExportaChoferes [ " & ex.Message & " ]")
        End Try
    End Function


    Public Function Obtiene_Universo_Chofer_X_RepFactura(ByVal SQL_Comman As SqlCommand, ByVal Agente As String, ByVal FechaIni As String, ByVal FechaFin As String, Rutas_Unidicar() As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim cont As Integer = 0
            If Rutas_Unidicar Is Nothing Then
                Consulta = "Select * From Deliver_UniversoXRepFac('" & Agente & "','" & FechaIni & "','" & FechaFin & "')"
            Else


                For i As Integer = 0 To Rutas_Unidicar.Count - 1
                    If cont > 0 Then
                        Consulta = Consulta & " UNION "
                    End If
                    Consulta = Consulta & "Select * From Deliver_UniversoXRepFac('" & Rutas_Unidicar(i).ToString() & "','" & FechaIni & "','" & FechaFin & "')"

                    cont += 1
                Next
            End If
            '  Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[FacturasPendientes] ('" & CodCliente & "','" & Agente & "') ORDER BY 2 ASC"


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en Obtiene_Universo_Chofer_X_RepFactura [ " & ex.Message & " ]")
        End Try
    End Function
    Public Function ObtieneFacturas(ByVal SQL_Comman As SqlCommand, ByVal Agente As String, ByVal FechaIni As String, ByVal FechaFin As String, Rutas_Unidicar() As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim cont As Integer = 0
            If Rutas_Unidicar Is Nothing Then

                Consulta = " Select * From [Deliver_FacturasInventario]('" & Agente & "','" & FechaIni & "','" & FechaFin & "')"
            Else
                For i As Integer = 0 To Rutas_Unidicar.Count - 1
                    If cont > 0 Then
                        Consulta = Consulta & " UNION "
                    End If

                    '  Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[FacturasPendientes] ('" & CodCliente & "','" & Agente & "') ORDER BY 2 ASC"
                    Consulta = Consulta & " Select * From [Deliver_FacturasInventario]('" & Rutas_Unidicar(i).ToString() & "','" & FechaIni & "','" & FechaFin & "')"
                    cont += 1
                Next
            End If




            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneFacturas [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function Obtiene_cxc_Choferes(ByVal SQL_Comman As SqlCommand, ByVal FacIni As String, ByVal FacFin As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            '  Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[FacturasPendientes] ('" & CodCliente & "','" & Agente & "') ORDER BY 2 ASC"
            Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[FacturasPendiente_RepFacturas] ('" & FacIni & "','" & FacFin & "') ORDER BY 2 ASC"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en Obtiene_cxc_Choferes [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function Obtieneclientes_X_Factura(ByVal Tbl_Clientes As DataTable, ByVal FacIni As String, ByVal FacFin As String, ByVal SQL_Comman As SqlCommand)
        Try

            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""


            Consulta = "SELECT * FROM UniversoXFacturas('" & FacIni & "','" & FacFin & "') order by CardCode asc "



            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(Tbl_Clientes)
            SQL_Comman = Nothing

            Return Tbl_Clientes
        Catch ex As Exception
            MessageBox.Show("ERROR en Obtieneclientes_X_Agente [ " & ex.Message & " ]")
        End Try
    End Function
#End Region

#Region "Exportar informacion PICKING"



    Public Function Obtiene_InfoConfiguracionPicking(ByVal SQL_Comman As SqlCommand, ByVal Chofer As String)
        Try

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""

            Consulta = "select * from Info_ConfiguracionPicking(" & Chofer & ")"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en Obtiene_InfoConfiguracionPicking [ " & ex.Message & " ]")
        End Try
    End Function
#End Region

#Region "Info Empresa"

    Public Function Elimina_Razon(ByVal SQL_Comman As SqlCommand, ByVal Razon As String)

        Try
            Dim Consulta As String
            Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Razones_NoVisita] WHERE [Razon]='" & Razon & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en Elimina_Razon [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function Actualizar_Razones_NoVisita(ByVal SQL_Comman As SqlCommand, ByVal IDRazon As String, ByVal Razon As String)
        Try
            Dim Obj_SQL_CONEXION As New CONEXION_TO_SQLSERVER
            Dim cont As Integer = 0
            Dim Consulta As String
            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Razones_NoVisita]  SET [Razon] = '" & Razon & "' WHERE [Codigo] = '" & IDRazon & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            Return 0
        Catch ex As Exception
            MessageBox.Show("ERROR en Actualizar_Razones_NoVisita [ " & ex.Message & " ]")
        End Try

    End Function

    Public Function CONSULTA_RazonesNoVisita(ByVal SQL_Comman As SqlCommand)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""

            Consulta = "SELECT [Razon] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Razones_NoVisita]  "

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            Return 2
            'ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function

    Public Function Inserta_Razones_NoVisita(ByVal SQL_Comman As SqlCommand, ByVal Razon As String)
        Try
            Dim Consulta As String
            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Razones_NoVisita] ([Razon]) VALUES('" & Razon & "')"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception
            'ERRORES = "[ " & Now & " ] ERROR INSERTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try

    End Function
    Public Function INSERTA_Empresa(ByVal SQL_Comman As SqlCommand, ByVal Cedula As String, ByVal Nombre As String, ByVal Telefono As String, ByVal Correo As String, ByVal Web As String, ByVal Direccion As String, ByVal Server_Ftp As String, ByVal User_Ftp As String, ByVal Clave_Ftp As String, ByVal NumMaxFactura As String, ByVal DescMax As String, ByVal ConseRepCarga As String, ByVal ConseRepDevoluciones As String, Nombre_Fantacia As String, id_Provincia As Integer, id_canton As Integer, id_distrito As Integer, id_barrio As Integer, Tipo_Cedula As Integer, Telefono2 As Integer, ClaveEmail As String, CodigoActividadEconomica As String, DescrActividadEconomica As String, Txtb_RutaPadreFtp As String)
        Try
            Dim Consulta As String
            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Empresa] ([Cedula],[Nombre] ,[Telefono] ,[Correo] ,[Web] ,[Direccion],[Server_Ftp],[User_Ftp],[Clave_Ftp],[NumMaxFactura],[DescMax],[Conse_RepCarga],[Conse_RepDevoluciones],Nombre_Fantacia,id_Provincia,id_canton,id_distrito,id_barrio,Tipo_Cedula,ClaveEmail,CodigoActividadEconomica, DescrActividadEconomica ) VALUES('" & Cedula & "','" & Nombre & "','" & Telefono & "','" & Correo & "','" & Web & "','" & Direccion & "','" & Server_Ftp & "','" & User_Ftp & "','" & Clave_Ftp & "','" & NumMaxFactura & "','" & DescMax & "','" & ConseRepCarga & "','" & ConseRepDevoluciones & "','" & Nombre_Fantacia & "','" & id_Provincia & "','" & id_canton & "','" & id_distrito & "','" & id_barrio & "','" & Tipo_Cedula & "','" & ClaveEmail & "','" & CodigoActividadEconomica & "','" & DescrActividadEconomica & "','" & Txtb_RutaPadreFtp & "')"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            Return 0
        Catch ex As Exception
            MsgBox("Error al INSERTA_Empresa", ex.Message)
            Return 1

            'ERRORES = "[ " & Now & " ] Error INSERTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try

    End Function

    Public Function Actualiza_Empresa(ByVal SQL_Comman As SqlCommand, ByVal Cedula As String, ByVal Nombre As String, ByVal Telefono As String, ByVal Correo As String, ByVal Web As String, ByVal Direccion As String, ByVal Server_Ftp As String, ByVal User_Ftp As String, ByVal Clave_Ftp As String, ByVal NumMaxFactura As String, ByVal DescMax As String, ByVal ConseRepCarga As String, ByVal ConseRepDevoluciones As String, Nombre_Fantacia As String, id_Provincia As Integer, id_canton As Integer, id_distrito As Integer, id_barrio As Integer, Tipo_Cedula As Integer, Telefono2 As Integer, ClaveEmail As String, CodigoActividadEconomica As String, DescrActividadEconomica As String, RutaPadreFtp As String)
        Try
            Dim Obj_SQL_CONEXION As New CONEXION_TO_SQLSERVER
            Dim cont As Integer = 0

            Dim Consulta As String = ""
            'Actualiza el estado dependiendo del numero de aplicacion que sea
            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Empresa]  Set [Cedula] = '" & Cedula & "' ,[Nombre] = '" & Nombre & "',[Telefono] = '" & Telefono & "' ,[Correo] = '" & Correo & "' ,[Web] = '" & Web & "',[Direccion] = '" & Direccion & "',[Server_Ftp]='" & Server_Ftp & "',[User_Ftp]='" & User_Ftp & "',[Clave_Ftp]='" & Clave_Ftp & "',[NumMaxFactura]='" & NumMaxFactura & "',DescMax='" & DescMax & "',Conse_RepCarga='" & ConseRepCarga & "',Conse_RepDevoluciones='" & ConseRepDevoluciones & "',Nombre_Fantacia='" & Nombre_Fantacia & "',id_Provincia='" & id_Provincia & "',id_canton='" & id_canton & "',id_distrito='" & id_distrito & "',id_barrio='" & id_barrio & "',Tipo_Cedula='" & Tipo_Cedula & "',Telefono2='" & Telefono2 & "',ClaveEmail='" & ClaveEmail & "',CodigoActividadEconomica='" & CodigoActividadEconomica & "', DescrActividadEconomica='" & DescrActividadEconomica & "', RutaPadre_Ftp='" & RutaPadreFtp & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()

            Return 0
        Catch ex As Exception
            MessageBox.Show("ERROR en Actualiza_Empresa [ " & ex.Message & " ]")
        End Try

    End Function

    Public Function CONSULTA_Empresa(ByVal SQL_Comman As SqlCommand)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""

            Consulta = "SELECT [Cedula],[Nombre] ,[Telefono] ,[Correo] ,[Web] ,[Direccion],[Server_Ftp],[User_Ftp],[Clave_Ftp],[NumMaxFactura],[DescMax],[Conse_RepCarga],[Conse_RepDevoluciones],Nombre_Fantacia,id_Provincia,id_canton,id_distrito,id_barrio,Tipo_Cedula,Telefono2,ClaveEmail,CodigoActividadEconomica, DescrActividadEconomica, RutaPadre_Ftp FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Empresa]  "

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Dim contardor As Integer = 0
            Dim itemas As Integer = TABLA.Rows.Count
            Dim Agentes(itemas) As String

            Return TABLA
        Catch ex As Exception
            Return 2
            'ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function


    Public Function CONSULTA_InfoContactoEmpresa(ByVal SQL_Comman As SqlCommand)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""

            Consulta = "SELECT [Cedula],[Nombre] ,[Telefono] ,[Correo]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Empresa]  "

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Dim contardor As Integer = 0
            Dim itemas As Integer = TABLA.Rows.Count
            Dim Agentes(itemas) As String

            Return TABLA
        Catch ex As Exception
            Return 2
            'ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function
#End Region

#Region "Agentes"
    Public Function INSERTA_Agente(ByVal SQL_Comman As SqlCommand, ByVal txtb_Agente As String, ByVal txtb_Cedula As String, ByVal txtb_Nombre As String, ByVal txtb_telf As String, ByVal txtb_ConsPe As String, ByVal txtb_ConsePag As String, ByVal txtb_ConsDep As String, ByVal txtb_ConsGastos As String, ByVal txtb_ConsSinVisitas As String, ByVal txtb_Correo As String, ByVal txtb_RutaFTP As String, ByVal txtb_Grupo As String, ByVal txtb_ConsDevoluciones As String, txtb_ConsClientesNuevos As String, ByVal Puesto As String)
        Try

            'Dim SQL_Comman As New SqlCommand
            'para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXIONSERVER.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Agentes] ([Cedula],[CodAgente],[Nombre],[Telefono],[Conse_Pedido],[Conse_Pagos],[Conse_Deposito],[Conse_Gastos],[Conse_NoVisita],[Correo],[FTP],[Grupo],[Conse_Devoluciones],[Conse_ClientesNuevos],[Puesto])VALUES('" & txtb_Cedula & "','" & txtb_Agente & "','" & txtb_Nombre & "','" & txtb_telf & "','" & txtb_ConsPe & "','" & txtb_ConsePag & "','" & txtb_ConsDep & "','" & txtb_ConsGastos & "','" & txtb_ConsSinVisitas & "','" & txtb_Correo & "','" & txtb_RutaFTP & "','" & txtb_Grupo & "','" & txtb_ConsDevoluciones & "','" & txtb_ConsClientesNuevos & "','" & Puesto & "')"
            SQL_Comman.CommandText = Consulta

            SQL_Comman.ExecuteNonQuery()


        Catch ex As Exception
            'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR INSERTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try

    End Function
    Public Function ExisteCod(ByVal SQL_Comman As SqlCommand, CodEmpleado As String)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""

            Consulta = "SELECT [CodAgente] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Agentes] where CodAgente='" & CodEmpleado & "' "

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            'Obj_SQL_CONEXIONSERVER.Desconectar()
            Dim RutasBourne() As String

            Dim contardor As Integer = 0
            Dim itemas As Integer = TABLA.Rows.Count
            Dim Agentes(itemas) As String


            While contardor < TABLA.Rows.Count
                Agentes(contardor) = TABLA.Rows(contardor).Item("CodAgente").ToString()
                contardor += 1
            End While

            TABLA = Nothing

            Return contardor
        Catch ex As Exception
            Return 2
            'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function
    Public Function CONSULTA_Agente(ByVal SQL_Comman As SqlCommand)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""

            Consulta = "SELECT [CodAgente] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Agentes]  "

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            'Obj_SQL_CONEXIONSERVER.Desconectar()
            Dim RutasBourne() As String

            Dim contardor As Integer = 0
            Dim itemas As Integer = TABLA.Rows.Count
            Dim Agentes(itemas) As String

            While contardor < TABLA.Rows.Count
                Agentes(contardor) = TABLA.Rows(contardor).Item("CodAgente").ToString()
                contardor += 1
            End While

            TABLA = Nothing

            Return contardor
        Catch ex As Exception
            Return 2
            'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function

    Public Function ObtieneAgentes(ByVal SQL_Comman As SqlCommand, VerPuesto As String, CodAgente As String)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""

            If Class_VariablesGlobales.Lista_llamadaDesde = "EXPORTAR" Then
                Consulta = "SELECT [CodAgente],[Nombre],[Telefono],[Conse_Pedido],[Conse_Pagos],[Conse_Deposito],[Conse_Gastos],[Conse_NoVisita],[Correo],[FTP],[Grupo],[Cedula] ,[Conse_Devoluciones] ,[Conse_ClientesNuevos],[Puesto] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Agentes] where Puesto='" & VerPuesto & "' ORDER BY [CodAgente] ASC "
            Else


                If VerPuesto = "TODOS" Then
                    Consulta = "SELECT [CodAgente],[Nombre],[Telefono],[Conse_Pedido],[Conse_Pagos],[Conse_Deposito],[Conse_Gastos],[Conse_NoVisita],[Correo],[FTP],[Grupo],[Cedula] ,[Conse_Devoluciones] ,[Conse_ClientesNuevos],[Puesto] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Agentes] where [CodAgente]<>'1'  ORDER BY [CodAgente] ASC "
                ElseIf VerPuesto = "CHOFER" Then
                    If CodAgente <> "" Then
                        Consulta = "SELECT [CodAgente] as CodChofer,[Nombre],[Telefono],[Conse_Pedido],[Conse_Pagos],[Conse_Deposito],[Conse_Gastos],[Conse_NoVisita],[Correo],[FTP],[Grupo],[Cedula] ,[Conse_Devoluciones] ,[Conse_ClientesNuevos],[Puesto] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Agentes] where [CodAgente]<>'1' AND Puesto='" & VerPuesto & "' AND CodAgente='" & CodAgente & "' ORDER BY [CodAgente] ASC "
                    Else
                        Consulta = "SELECT [CodAgente] as CodChofer,[Nombre],[Telefono],[Conse_Pedido],[Conse_Pagos],[Conse_Deposito],[Conse_Gastos],[Conse_NoVisita],[Correo],[FTP],[Grupo],[Cedula] ,[Conse_Devoluciones] ,[Conse_ClientesNuevos],[Puesto] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Agentes] where [CodAgente]<>'1' AND Puesto='" & VerPuesto & "' ORDER BY [CodAgente] ASC "
                    End If
                Else
                    If CodAgente <> "" Then
                        Consulta = "SELECT [CodAgente],[Nombre],[Telefono],[Conse_Pedido],[Conse_Pagos],[Conse_Deposito],[Conse_Gastos],[Conse_NoVisita],[Correo],[FTP],[Grupo],[Cedula] ,[Conse_Devoluciones] ,[Conse_ClientesNuevos],[Puesto] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Agentes] where [CodAgente]<>'1' AND Puesto='" & VerPuesto & "' AND CodAgente='" & CodAgente & "' ORDER BY [CodAgente] ASC "
                    Else
                        Consulta = "SELECT [CodAgente],[Nombre],[Telefono],[Conse_Pedido],[Conse_Pagos],[Conse_Deposito],[Conse_Gastos],[Conse_NoVisita],[Correo],[FTP],[Grupo],[Cedula] ,[Conse_Devoluciones] ,[Conse_ClientesNuevos],[Puesto] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Agentes] where [CodAgente]<>'1' AND Puesto='" & VerPuesto & "' ORDER BY [CodAgente] ASC "
                    End If


                End If
            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            Return 2
            'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function

    'Public Function ObtieneChoferes(ByVal SQL_Comman As SqlCommand)
    '    Try

    '        Dim TABLA As New DataTable
    '        Dim ADATER As New SqlDataAdapter

    '        Dim Consulta As String = ""

    '        Consulta = "SELECT [CodChofer],[Nombre],[Telefono],[Conse_Pedido],[Conse_Pagos],[Conse_Deposito],[Conse_Gastos],[Conse_NoVisita],[Correo],[FTP],[Cedula] ,[Conse_Devoluciones] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Choferes]  ORDER BY [CodChofer] ASC "

    '        ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
    '        ADATER.Fill(TABLA)
    '        Return TABLA
    '    Catch ex As Exception
    '        Return 2
    '        'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
    '    End Try
    'End Function

    Public Function Guarda_Ruta(ByVal SQL_Comman As SqlCommand, ByVal RUTA As String)
        Try
            Dim Consulta As String
            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rutas] ([Descripcion])VALUES('" & RUTA & "')"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Function
    Public Function ObtieneRutas(ByVal SQL_Comman As SqlCommand, ByVal ComboBox1 As ComboBox)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Consulta = "SELECT  [U_Rutas] as id ,[Name] as Descripcion  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rutas_Choferes] UNION " &
                        "SELECT '0','selecciones una ruta'  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rutas_Choferes]"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            With ComboBox1
                .DataSource = TABLA
                .DisplayMember = "Descripcion"

                .ValueMember = "id"
            End With

            Return TABLA
        Catch ex As Exception
            'Return 2

        End Try
    End Function

    Public Function Actualiza_Ruta(ByVal SQL_Comman As SqlCommand, ByVal Ruta As String, ByVal id As String)
        Try
            Dim Obj_SQL_CONEXION As New CONEXION_TO_SQLSERVER
            Dim cont As Integer = 0
            Dim Consulta As String
            Consulta = ""
            'Actualiza el estado dependiendo del numero de aplicacion que sea
            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rutas]  SET [Descripcion] = '" & Ruta & " WHERE [id] = '" & id & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            Return 0
        Catch ex As Exception
            MessageBox.Show("ERROR en Actualiza_Ruta [ " & ex.Message & " ]")
        End Try

    End Function

    Public Function Elimina_TblTemporadoresFacturacion(ByVal SQL_Comman As SqlCommand)

        Try
            Dim Consulta As String
            Consulta = ""
            Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_FE_Temp];DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_FE1_Temp]; "
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()

            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en Elimina_TblTemporadoresFacturacion [ " & ex.Message & " ]")
        End Try

    End Function

    Public Function Elimina_Ruta(ByVal SQL_Comman As SqlCommand, ByVal idRuta As String)

        Try
            Dim Consulta As String
            Consulta = ""
            Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rutas] WHERE [id]='" & idRuta & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()

            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en Elimina_Ruta [ " & ex.Message & " ]")
        End Try

    End Function
    Public Function Actualiza_Agente(ByVal SQL_Comman As SqlCommand, ByVal txtb_Agente As String, ByVal txtb_cedula As String, ByVal txtb_Nombre As String, ByVal txtb_telf As String, ByVal txtb_ConsPe As String, ByVal txtb_ConsePag As String, ByVal txtb_ConsDep As String, ByVal txtb_ConsGastos As String, ByVal txtb_ConsSinVisita As String, ByVal txtb_Correo As String, ByVal txtb_RutaFTP As String, ByVal txtb_Grupo As String, ByVal txtb_ConsDevolucion As String, ByVal Conse_ClientesNuevos As String, ByVal Puesto As String)
        Try
            Dim Obj_SQL_CONEXION As New CONEXION_TO_SQLSERVER
            Dim cont As Integer = 0
            Dim Consulta As String
            Consulta = ""
            'Actualiza el estado dependiendo del numero de aplicacion que sea
            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Agentes]  SET [Cedula] = '" & txtb_cedula & "',[Nombre] = '" & txtb_Nombre & "' ,[Telefono] = '" & txtb_telf & "' ,[Conse_Pedido] = '" & txtb_ConsPe & "' ,[Conse_Pagos] = '" & txtb_ConsePag & "' ,[Conse_Deposito] = '" & txtb_ConsDep & "',[Conse_Gastos] = '" & txtb_ConsGastos & "',[Conse_NoVisita] = '" & txtb_ConsSinVisita & "',[Correo] = '" & txtb_Correo & "',[FTP] = '" & txtb_RutaFTP & "',[Grupo] = '" & txtb_Grupo & "',[Conse_Devoluciones] = '" & txtb_ConsDevolucion & "',[Conse_ClientesNuevos] = '" & Conse_ClientesNuevos & "',[Puesto] = '" & Puesto & "' WHERE [CodAgente] = '" & txtb_Agente & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            ' Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            Return 0
        Catch ex As Exception
            MessageBox.Show("ERROR en Actualiza_Agente [ " & ex.Message & " ]")
        End Try

    End Function

    Public Function Elimina_Agente(ByVal SQL_Comman As SqlCommand, ByVal Agente As String)

        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            'SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            'Recorre los datos extraido de la base de datos SQL para proceder insertarlos en la tabla articulos de MYSQL

            Consulta = ""
            Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Agentes] WHERE [CodAgente]='" & Agente & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()

            SQL_Comman = Nothing
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)

        Catch ex As Exception
            MessageBox.Show("ERROR en Elimina_Agente [ " & ex.Message & " ]")
        End Try

    End Function


#End Region

#Region "Chofer"
    Public Function INSERTA_Chofer(ByVal SQL_Comman As SqlCommand, ByVal txtb_Agente As String, ByVal txtb_Cedula As String, ByVal txtb_Nombre As String, ByVal txtb_telf As String, ByVal txtb_ConsPe As String, ByVal txtb_ConsePag As String, ByVal txtb_ConsDep As String, ByVal txtb_ConsGastos As String, ByVal txtb_ConsSinVisitas As String, ByVal txtb_Correo As String, ByVal txtb_RutaFTP As String, ByVal Tipo As String, ByVal txtb_ConsDevoluciones As String)
        Try
            Dim Consulta As String
            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Choferes] ([Cedula],[CodChofer],[Nombre],[Telefono],[Conse_Pedido],[Conse_Pagos],[Conse_Deposito],[Conse_Gastos],[Conse_NoVisita],[Correo],[FTP],[Tipo],[Conse_Devoluciones])VALUES('" & txtb_Cedula & "','" & txtb_Agente & "','" & txtb_Nombre & "','" & txtb_telf & "','" & txtb_ConsPe & "','" & txtb_ConsePag & "','" & txtb_ConsDep & "','" & txtb_ConsGastos & "','" & txtb_ConsSinVisitas & "','" & txtb_Correo & "','" & txtb_RutaFTP & "','" & Tipo & "','" & txtb_ConsDevoluciones & "')"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception
            'ERRORES = "[ " & Now & " ] ERROR INSERTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function

    Public Function ObtieneChoferes(ByVal SQL_Comman As SqlCommand, ByVal Tipo As String, ByVal Chofer As String)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""
            If Tipo <> "" Then
                If Chofer <> "" Then
                    Consulta = "SELECT [CodChofer],[Nombre],[Telefono],[Conse_Pedido],[Conse_Pagos],[Conse_Deposito],[Conse_Gastos],[Conse_NoVisita],[Correo],[FTP],[Tipo],[Cedula] ,[Conse_Devoluciones] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Choferes] WHERE [Tipo]='" & Tipo & "' and [CodChofer]='" & Trim(Chofer) & "' ORDER BY [CodChofer] ASC "
                Else
                    Consulta = "SELECT [CodChofer],[Nombre],[Telefono],[Conse_Pedido],[Conse_Pagos],[Conse_Deposito],[Conse_Gastos],[Conse_NoVisita],[Correo],[FTP],[Tipo],[Cedula] ,[Conse_Devoluciones] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Choferes] WHERE [Tipo]='" & Tipo & "' ORDER BY [CodChofer] ASC "
                End If


            Else

                Consulta = "SELECT [CodChofer],[Nombre],[Telefono],[Conse_Pedido],[Conse_Pagos],[Conse_Deposito],[Conse_Gastos],[Conse_NoVisita],[Correo],[FTP],[Tipo],[Cedula] ,[Conse_Devoluciones] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Choferes] ORDER BY [CodChofer] ASC "
            End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            Return 2
            'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function


    Public Function VerificaExistRepFAc(ByVal NumRepFac As String, ByVal SQL_Comman As SqlCommand)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""

            Dim conse As Boolean
            Consulta = "SELECT [Consecutivo] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Rep_Facturas] where  [Consecutivo]='" & NumRepFac & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            If TABLA.Rows.Count > 0 Then
                If TABLA.Rows(0).Item("Consecutivo").ToString <> "" Then
                    conse = True
                Else
                    conse = False
                End If


            End If
            Return conse
        Catch ex As Exception
            Return 2
            'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try

    End Function


    Public Function ObtieneCodChofer(ByVal SQL_Comman As SqlCommand, ByVal Tipo As String, ByVal Nombre As String)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Consulta = "SELECT [CodAgente] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Agentes] WHERE [Puesto]='CHOFER' and [Nombre] = '" & Nombre & "' ORDER BY [CodAgente] ASC "
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA.Rows(0).Item("CodAgente")
        Catch ex As Exception
            Return 2
            'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function
    Public Function Actualiza_Choferes(ByVal SQL_Comman As SqlCommand, ByVal CodChofer As String, ByVal txtb_cedula As String, ByVal txtb_Nombre As String, ByVal txtb_telf As String, ByVal txtb_ConsPe As String, ByVal txtb_ConsePag As String, ByVal txtb_ConsDep As String, ByVal txtb_ConsGastos As String, ByVal txtb_ConsSinVisita As String, ByVal txtb_Correo As String, ByVal txtb_RutaFTP As String, ByVal txtb_Grupo As String, ByVal txtb_ConsDevolucion As String)
        Try
            Dim Obj_SQL_CONEXION As New CONEXION_TO_SQLSERVER
            Dim cont As Integer = 0
            Dim Consulta As String
            Consulta = ""
            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Choferes]  SET [Cedula] = '" & txtb_cedula & "',[Nombre] = '" & txtb_Nombre & "' ,[Telefono] = '" & txtb_telf & "' ,[Conse_Pedido] = '" & txtb_ConsPe & "' ,[Conse_Pagos] = '" & txtb_ConsePag & "' ,[Conse_Deposito] = '" & txtb_ConsDep & "',[Conse_Gastos] = '" & txtb_ConsGastos & "',[Conse_NoVisita] = '" & txtb_ConsSinVisita & "',[Correo] = '" & txtb_Correo & "',[FTP] = '" & txtb_RutaFTP & "',[Tipo] = '" & txtb_Grupo & "',[Conse_Devoluciones] = '" & txtb_ConsDevolucion & "' WHERE [CodChofer] = '" & CodChofer & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            Return 0
        Catch ex As Exception
            MessageBox.Show("ERROR en Actualiza_Choferes [ " & ex.Message & " ]")
        End Try

    End Function

    Public Function Elimina_Chofer(ByVal SQL_Comman As SqlCommand, ByVal CodChofer As String)

        Try
            Dim Consulta As String
            Consulta = ""
            Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Choferes] WHERE [CodChofer]='" & CodChofer & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en Elimina_Agente [ " & ex.Message & " ]")
        End Try

    End Function
#End Region

#Region "Datos Maestros de Clientes"

    Public Function ObtieneConsecutivoCliente(ByVal SQL_Comman As SqlCommand)
        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consecutivo As Integer = 0
            Dim Consulta As String = "SELECT Conse_Clientes FROM Empresa"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Try
                Consecutivo = CInt(Trim(TABLA.Rows(0).Item("Conse_Clientes").ToString())) + 1
            Catch ex As Exception
                Consecutivo = ""
            End Try

            Return Consecutivo
        Catch ex As Exception

        End Try
    End Function
    Public Function ActualizaConsecutivoCliente(ByVal SQL_Comman As SqlCommand, Consecutivo As Integer)
        Try
            Dim Consulta As String = "UPDATE [dbo].[Empresa] SET Conse_Clientes='" & Consecutivo & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Function

    Public Function ObtieneClientesModificados(ByVal Estado As String, ByVal SQL_Comman As SqlCommand, ByVal id As Integer, ByVal Buscando As Boolean, ByVal BuscarX As Integer, ByVal Palabra As String, FechaINI As String, FechaFIN As String, Agente As String, Aprobados As Boolean, BuscaXFecha As Boolean)
        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Dim yawhere As Boolean = False
            Dim entro As Boolean = False

           Consulta = "SELECT [Consecutivo],[CardCode],[CardName],[Cedula],[Respolsabletributario],[U_Visita],[U_ClaveWeb],[Phone1],[Phone2],[Street],[E_Mail],[NameFicticio],[Latitud],[Longitud],[Agente],[Id_Provincia],[Id_Canton],[Id_Distrito],[Id_Barrio],[Estado],[Tipo_Cedula],[Fecha],[Hora],[Aprobado],[id],[TipoSocio] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ClientesModificados] "

            'Si busca por agente
            If Aprobados = True Then
                If yawhere = False Then
                    Consulta = Consulta & " Where "
                    yawhere = True
                Else
                    Consulta = Consulta & " and "
                End If

                Consulta = Consulta & " Aprobado='1' "
            Else
                If yawhere = False Then
                    Consulta = Consulta & " Where "
                    yawhere = True
                Else
                    Consulta = Consulta & " and "
                End If
                Consulta = Consulta & " Aprobado='0' "
            End If
            'Si busca por agente
            If Agente <> "" Then
                If yawhere = False Then
                    Consulta = Consulta & " Where "
                    yawhere = True
                Else
                    Consulta = Consulta & " and "
                End If

                Consulta = Consulta & " Agente='" & Agente & "' "
            End If

            If Buscando = True Then
                If BuscarX = 1 Then 'busca por codigo
                    If yawhere = False Then
                        Consulta = Consulta & " Where "
                        yawhere = True
                    Else
                        Consulta = Consulta & " and "
                    End If

                    If id <> 0 Then
                        Consulta = Consulta & " id='" & id & "' and [CardCode] like '%" & Palabra & "%' "

                    Else
                        Consulta = Consulta & " Estado='" & Estado & "'  and [CardCode] like '%" & Palabra & "%' "
                    End If

                Else 'busca por nombre

                    If yawhere = False Then
                        Consulta = Consulta & " Where "
                        yawhere = True
                    Else
                        Consulta = Consulta & " and "
                    End If

                    If id <> 0 Then
                        Consulta = Consulta & " id='" & id & "' and [CardCode] like '%" & Palabra & "%' "

                    Else
                        Consulta = Consulta & " Estado='" & Estado & "'  and [CardCode] like '%" & Palabra & "%' "
                    End If
                End If


            Else
                If yawhere = False Then
                    Consulta = Consulta & " Where "
                    yawhere = True
                Else
                    Consulta = Consulta & " and "
                End If

                If id <> 0 Then
                    Consulta = Consulta & "   id='" & id & "'"
                Else
                    Consulta = Consulta & "   Estado='" & Estado & "'  "
                End If
            End If

            'Si busca por fecha
            If FechaINI <> "" And FechaFIN <> "" And BuscaXFecha = True Then
                If yawhere = False Then
                    Consulta = Consulta & " Where "
                    yawhere = True
                Else
                    Consulta = Consulta & " and "
                End If

                Consulta = Consulta & " Fecha between '" & FechaINI & "' and '" & FechaFIN & "' "
            End If

            Consulta = Consulta & " ORDER BY id DESC"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            Return 2
            'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function


    Public Function ObtieneLineaContacto(ByVal CardCode As String, ByVal SQL_Comman As SqlCommand)
        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Dim id As Integer

            Consulta = "SELECT T11.id FROM(SELECT (ROW_NUMBER() OVER(ORDER BY T1.[CntctPrsn] DESC))-1 as id,T1.[CardCode],T1.[CntctPrsn],T2.[Name] FROM [BD_Bourne].[dbo].[OCRD]  T1 INNER JOIN [BD_Bourne].[dbo].OCPR T2 ON T1.CardCode = T2.CardCode WHERE T1.[CardCode] ='" & CardCode & "' ) T11 WHERE T11.[Name]=T11.[CntctPrsn] "

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            If TABLA.Rows.Count > 0 Then
                If TABLA.Rows(0).Item("id").ToString <> "" Then
                    id = CInt(TABLA.Rows(0).Item("id").ToString)
                Else
                    id = CInt(TABLA.Rows(0).Item("id").ToString)
                End If
            End If


            Return id
        Catch ex As Exception
            Return 0
            'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function
    Public Function ObtieneProvincias(ByVal SQL_Comman As SqlCommand, ByVal id_provincia As Integer)
        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            If id_provincia <> 0 Then
                Consulta = "SELECT  [id_provincia],[nombre_provincia] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Ubicaciones_CostaRica] WHERE id_provincia='" & id_provincia & "'group by [id_provincia],[nombre_provincia]  order by [id_provincia] asc"
            Else
                Consulta = "SELECT  '0' as [id_provincia] ,''as [nombre_provincia] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Ubicaciones_CostaRica] UNION " &
                           "SELECT  [id_provincia],[nombre_provincia] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Ubicaciones_CostaRica] group by [id_provincia],[nombre_provincia]  order by [id_provincia] asc"
            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return TABLA

        Catch ex As Exception
            Return 2
            'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function

    Public Function ObtieneCantones(ByVal SQL_Comman As SqlCommand, ByVal id_provincia As Integer, ByVal id_canton As Integer)
        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            If id_canton <> 0 Then
                Consulta = "SELECT [id_canton],[nombre_canton] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Ubicaciones_CostaRica] where [id_provincia]='" & id_provincia & "' AND id_canton='" & id_canton & "'group by [id_canton],[nombre_canton] order by [id_canton] asc"
            Else
                Consulta = "SELECT  '0' as [id_canton] ,''as [nombre_canton] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Ubicaciones_CostaRica] UNION " &
                           "SELECT [id_canton],[nombre_canton] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Ubicaciones_CostaRica] where [id_provincia]='" & id_provincia & "'group by [id_canton],[nombre_canton]  order by [id_canton] asc"
            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            Return 2
            'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function

    Public Function ObtieneDistritos(ByVal SQL_Comman As SqlCommand, ByVal id_provincia As Integer, ByVal id_canton As Integer, ByVal id_distrito As Integer)
        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""

            If id_distrito <> 0 Then
                Consulta = "SELECT [id_distrito],[nombre_distrito] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Ubicaciones_CostaRica] where [id_provincia]='" & id_provincia & "' and [id_canton] ='" & id_canton & "' AND [id_distrito]='" & id_distrito & "'   group by [id_distrito],[nombre_distrito] order by [id_distrito] asc"
            Else
                Consulta = "SELECT  '0' as [id_distrito] ,''as [nombre_distrito] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Ubicaciones_CostaRica] UNION " &
                           "SELECT [id_distrito],[nombre_distrito] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Ubicaciones_CostaRica] where [id_provincia]='" & id_provincia & "' and [id_canton] ='" & id_canton & "' group by [id_distrito],[nombre_distrito] order by [id_distrito] asc"
            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            Return 2
            'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function

    Public Function ObtieneBarrios(ByVal SQL_Comman As SqlCommand, ByVal id_provincia As Integer, ByVal id_canton As Integer, ByVal id_distrito As Integer, ByVal id_barrio As Integer)
        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            If id_barrio <> 0 Then
                Consulta = "SELECT  [id_barrio],[nombre_barrio] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Ubicaciones_CostaRica] where [id_provincia]='" & id_provincia & "' and [id_canton] ='" & id_canton & "' AND [id_distrito]='" & id_distrito & "' AND [id_barrio]='" & id_barrio & "'   group by [id_barrio],[nombre_barrio]  order by [id_barrio] asc"
            Else
                Consulta = "SELECT  '0' as [id_barrio] ,''as [nombre_barrio] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Ubicaciones_CostaRica] UNION " &
                           "SELECT  [id_barrio],[nombre_barrio] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Ubicaciones_CostaRica] where [id_provincia]='" & id_provincia & "' and [id_canton] ='" & id_canton & "' AND [id_distrito]='" & id_distrito & "' group by [id_barrio],[nombre_barrio]  order by [id_barrio] asc"
            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            Return 2
            'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function
    Public Function ExisteCliente(ByVal CardCode As String)
        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Dim existe As Integer

            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Consulta = "SELECT  count([CardCode]) as existe FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ClientesModificados] where [CardCode]='" & CardCode & "'"


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            If TABLA.Rows.Count > 0 Then
                If TABLA.Rows(0).Item("existe").ToString <> "" Then
                    existe = CInt(TABLA.Rows(0).Item("existe").ToString)
                Else
                    existe = 0
                End If
            End If

            Return existe
        Catch ex As Exception
            Return 2
            'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function
    Public Function ActualizoCliente(ByVal SQL_Comman As SqlCommand, ByVal Consecutivo As String)

        Try
            ' Dim SQL_Comman As New SqlCommand
            ' para la conexion al comman
            ' SQL_Comman.Connection = Obj_SQL_CONEXION.Conectar("" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "")
            Dim Consulta As String
            Consulta = ""
            Consulta = "UPDATE  " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[ClientesModificados]  SET [Aprobado]='1' WHERE [Consecutivo] = '" & Consecutivo & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            'Obj_SQL_CONEXION.Desconectar(SQL_Comman)
            SQL_Comman = Nothing
        Catch ex As Exception

        End Try
    End Function

    Public Function GuardaCliente(ByVal CardCode As String, ByVal CardName As String, ByVal Cedula As String, ByVal Respolsabletributario As String, ByVal U_Visita As String, ByVal U_ClaveWeb As String, ByVal Phone1 As String, ByVal Phone2 As String, ByVal Street As String, ByVal E_Mail As String, ByVal NameFicticio As String, ByVal Latitud As String, ByVal Longitud As String, ByVal Agente As String, ByVal Id_Provincia As String, ByVal Id_Canton As String, ByVal Id_Distrito As String, ByVal Id_Barrio As String, ByVal Estado As String, ByVal Tipo_Cedula As String, ByVal Fecha As String, ByVal Hora As String, ByVal Aprobado As String, ByVal Consecutivo As String, EXO_TipoDocumento As String, EXO_Numero As String, EXO_NombreInstitucion As String, EXO_FechaEmision As String, EXO_PorcentajeCompra As String, Guardar As Boolean)
        Try



            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()
            'almance el cliente para poder usar el facturardor de Play
            Dim Consulta As String = ""

            If Guardar = True Then
                Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ClientesModificados]
           ([CardCode]
           ,[CardName]
           ,[Cedula]
           ,[Respolsabletributario]
           ,[U_Visita]
           ,[U_ClaveWeb]
           ,[Phone1]
           ,[Phone2]
           ,[Street]
           ,[E_Mail]
           ,[NameFicticio]
           ,[Latitud]
           ,[Longitud]
           ,[Agente]
           ,[Id_Provincia]
           ,[Id_Canton]
           ,[Id_Distrito]
           ,[Id_Barrio]
           ,[Estado]
           ,[Tipo_Cedula]
           ,[Fecha]
           ,[Hora]
           ,[Aprobado]
           ,[Consecutivo]
           ,[EXO_TipoDocumento]
           ,[EXO_Numero]
           ,[EXO_NombreInstitucion]
           ,[EXO_FechaEmision]
           ,[EXO_PorcentajeCompra])
     VALUES
           ('" & CardCode &
         "','" & CardName &
         "','" & Cedula &
         "','" & Respolsabletributario &
         "','" & U_Visita &
         "','" & U_ClaveWeb &
         "','" & Phone1 &
         "','" & Phone2 &
         "','" & Street &
         "','" & E_Mail &
         "','" & NameFicticio &
         "','" & Latitud &
         "','" & Longitud &
         "','" & Agente &
         "','" & Id_Provincia &
         "','" & Id_Canton &
         "','" & Id_Distrito &
         "','" & Id_Barrio &
         "','" & Estado &
         "','" & Tipo_Cedula &
         "','" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Fecha) &
         "','" & Hora &
         "','" & Aprobado &
         "','" & Consecutivo &
         "','" & EXO_TipoDocumento &
         "','" & EXO_Numero &
         "','" & EXO_NombreInstitucion &
         "','" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(EXO_FechaEmision) &
         "'," & EXO_PorcentajeCompra & ")"


            Else
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ClientesModificados] SET            
                                    [CardName] = '" & CardName & "'
                                   ,[Cedula] = '" & Cedula & "'
                                   ,[Respolsabletributario] = '" & Respolsabletributario & "'
                                   ,[U_Visita] = '" & U_Visita & "'
                                   ,[U_ClaveWeb] = '" & U_ClaveWeb & "'
                                   ,[Phone1] = '" & Phone1 & "'
                                   ,[Phone2] = '" & Phone2 & "'
                                   ,[Street] = '" & Street & "'
                                   ,[E_Mail] = '" & E_Mail & "'
                                   ,[NameFicticio] = '" & NameFicticio & "'
                                   ,[Latitud] = '" & Latitud & "'
                                   ,[Longitud] = '" & Longitud & "'
                                   ,[Agente] = '" & Agente & "'
                                   ,[Id_Provincia] = '" & Id_Provincia & "'
                                   ,[Id_Canton] = '" & Id_Canton & "'
                                   ,[Id_Distrito] = '" & Id_Distrito & "'
                                   ,[Id_Barrio] = '" & Id_Barrio & "'
                                   ,[Estado] = '" & Estado & "'
                                   ,[Tipo_Cedula] = '" & Tipo_Cedula & "'
                                   ,[Fecha] = '" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Fecha) & "'
                                   ,[Hora] = '" & Hora & "'
                                   ,[Aprobado] = '" & Aprobado & "'
                                   ,[Consecutivo] = '" & Consecutivo & "'
                                   ,[EXO_TipoDocumento] = '" & EXO_TipoDocumento & "'
                                   ,[EXO_Numero] = '" & EXO_Numero & "'
                                   ,[EXO_NombreInstitucion] = '" & EXO_NombreInstitucion & "'
                                   ,[EXO_FechaEmision] = '" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(EXO_FechaEmision) & "'
                                   ,[EXO_PorcentajeCompra] = '" & EXO_PorcentajeCompra & "' 
                              WHERE [CardCode] = '" & CardCode & "'"
            End If





            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            Return 0
        Catch ex As Exception

            MessageBox.Show("ERROR en GuardarCliente [ " & ex.Message & " ]")
            Return 1
        End Try

    End Function
#End Region

#Region "Respuestas Tributacion"
    Public Function ObtieneCorreo(CodSeguridad As String, Tipo As String, ByVal SQL_Comman As SqlCommand)
        Try
            'Dim SQL_Comman As New SqlCommand
            'SQL_Comman = Conectar(SQL_Comman)

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim Correo As String = ""
            If Tipo = "FE" Or Tipo = "FES" Or Tipo = "TE" Or Tipo = "TES" Then
                Consulta = "SELECT top 1 CASE WHEN T0.[E_Mail] IS NULL THEN '' ELSE T0.[E_Mail] END AS Correo FROM BD_BOURNE.dbo.OCRD T0 WHERE T0.[CardCode]  =(SELECT top 1 T0.[CardCode] FROM BD_BOURNE.dbo.OINV T0 WHERE T0.[DocNum] like '%" & CInt(CodSeguridad) & "%')"
            ElseIf Tipo = "NC" Or Tipo = "NCS" Then
                Consulta = "SELECT top 1 CASE WHEN T0.[E_Mail] IS NULL THEN '' ELSE T0.[E_Mail] END AS Correo FROM BD_BOURNE.dbo.OCRD T0 WHERE T0.[CardCode]  =(SELECT top 1 T0.[CardCode] FROM BD_BOURNE.dbo.ORIN T0 WHERE T0.[DocNum] like '%" & CInt(CodSeguridad) & "%')"
            ElseIf Tipo = "ND" Or Tipo = "NDS" Then
                Consulta = "SELECT top 1 CASE WHEN T0.[E_Mail] IS NULL THEN '' ELSE T0.[E_Mail] END AS Correo FROM BD_BOURNE.dbo.OCRD T0 WHERE T0.[CardCode]  =(SELECT top 1 T0.[CardCode] FROM BD_BOURNE.dbo.OINV T0 WHERE T0.[DocNum] like '%" & CInt(CodSeguridad) & "%' and T0.[DocSubType]='DN')  "
            End If
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Try
                Correo = Trim(TABLA.Rows(0).Item("Correo").ToString())
            Catch ex As Exception
                Correo = ""
            End Try

            'Desconectar(SQL_Comman, SQL_Comman.Connection)
            Return Correo

        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneCorreo [ " & ex.Message & " ]")
            Return ""
        End Try
    End Function
    Public Function ObtieneHistorial(Clave As String, ByVal SQL_Comman As SqlCommand)
        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Consulta = "SELECT [TipoComprobante] as Tipo
                              ,[Clave]
                              ,[ind_estado] as Estado
                              ,[fecha]
                              ,[Mensaje]
                              ,[Hora]
                          FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos_Bitacora]
                          WHERE [Clave]='" & Clave & "' order by [id] desc"



            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            Return 2
            'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try

    End Function
    Public Function ObtieneEstados(SinFecha As Boolean, Tipo As String, ByVal Estado As String, ByVal SQL_Comman As SqlCommand, ByVal Calve As Integer, FIni As String, FFin As String, Interno As String, Corregido As Boolean, NombreReceptor As String)
        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Dim yawhere As Boolean = False
            Dim IncluirAnd As Boolean = False

            Consulta = "SELECT [TipoComprobante],[ind_estado],[CodSeguridad],[Clave],[Consecutivo],[Fecha],[Receptor_Nombre],[ResumenFactura_TotalComprobante],[fecha] ,[Mensaje],[Receptor_CorreoElectronico],[Receptor_Tipo],[Corregido] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos]  "

            If Estado <> "" And Estado <> "Todo" Then
                'controla si ya agrego where
                If yawhere = False Then
                    Consulta = Consulta & " Where "
                    yawhere = True
                End If
                'controlar si debe agregar and
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If


                If Estado = "null" Then
                    Consulta = Consulta & " ind_estado Is null  AND TipoComprobante like '%" & Tipo & "%' "
                ElseIf Estado = "Otros" Then
                    If Tipo <> "Todo" And Tipo <> "" Then
                        Consulta = Consulta & " ind_estado <> 'rechazado' and ind_estado <> 'aceptado' and TipoComprobante like '%" & Tipo & "%' "
                    Else
                        Consulta = Consulta & " ind_estado <> 'rechazado' and ind_estado <> 'aceptado' "
                    End If

                Else
                    If Tipo <> "Todo" And Tipo <> "" Then
                        Consulta = Consulta & " ind_estado='" & Estado & "' and TipoComprobante like '%" & Tipo & "%' "
                    Else
                        Consulta = Consulta & " ind_estado='" & Estado & "'  "

                    End If

                End If

            Else

                If Tipo <> "Todo" And Tipo <> "" Then
                    'controla si ya agrego where
                    If yawhere = False Then
                        Consulta = Consulta & " Where "
                        yawhere = True
                    End If
                    'controlar si debe agregar and
                    If IncluirAnd = False Then
                        IncluirAnd = True
                    Else
                        Consulta = Consulta & " and "
                    End If


                    Consulta = Consulta & " TipoComprobante like '%" & Tipo & "%' "

                End If

            End If

            If Interno <> "" Then
                'controla si ya agrego where
                If yawhere = False Then
                    Consulta = Consulta & " Where "
                    yawhere = True
                End If
                'controlar si debe agregar and
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If

                Consulta = Consulta & "CodSeguridad like '%" & Interno & "%'"


            End If

            If Calve <> 0 Then
                'controla si ya agrego where
                If yawhere = False Then
                    Consulta = Consulta & " Where "
                    yawhere = True
                End If
                'controlar si debe agregar and
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If

                Consulta = Consulta & " Calve like '%" & Calve & "%' "

            End If
            If NombreReceptor <> "" Then
                'controla si ya agrego where
                If yawhere = False Then
                    Consulta = Consulta & " Where "
                    yawhere = True
                End If
                'controlar si debe agregar and
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If

                Consulta = Consulta & " [Receptor_Nombre] like '%" & NombreReceptor & "%' "

            End If
            If Corregido = True Then
                'If ConCondicion = True Then
                '    Consulta = Consulta & " and "
                '    ConCondicion = False
                'End If
                'Consulta = Consulta & " [Corregido]='1'"
            Else
                'controla si ya agrego where
                If yawhere = False Then
                    Consulta = Consulta & " Where "
                    yawhere = True
                End If
                'controlar si debe agregar and
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If

                Consulta = Consulta & " [Corregido]<>'1' "

            End If

            If SinFecha = False Then
                'controla si ya agrego where
                If yawhere = False Then
                    Consulta = Consulta & " Where "
                    yawhere = True
                End If
                'controlar si debe agregar and
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If

                Consulta = Consulta & " [FechaComprobante] between '" & FIni & "' and '" & FFin & "'"

            End If

            Consulta = Consulta & " group by [TipoComprobante],[ind_estado],[Clave],[Consecutivo],[Fecha],[Receptor_Nombre],[ResumenFactura_TotalComprobante],[fecha] ,[CodSeguridad],[Mensaje],[Receptor_CorreoElectronico],[Receptor_Tipo],[Corregido]"


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            If TABLA.Rows.Count = 0 And Interno <> "" Or Calve <> 0 Then
                MsgBox("No se ha registrado el comprobante")

            End If
            Return TABLA
        Catch ex As Exception
            Return 2
            'Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function

    Public Function ObtieneComprobantes(SinFecha As Boolean, Tipo As String, ByVal Estado As String, ByVal SQL_Comman As SqlCommand, ByVal Calve As Integer, FIni As String, FFin As String, Interno As String, Corregido As Boolean)
        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Dim yawhere As Boolean = False
            Dim IncluirAnd As Boolean = False

            Consulta = "SELECT [TipoComprobante],[ind_estado],[CodSeguridad],[Clave],[Consecutivo],[Fecha],[Receptor_Nombre],[ResumenFactura_TotalComprobante],[ResumenFactura_TotalImpuesto]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos]  "

            If Estado <> "" And Estado <> "Todo" Then
                'controla si ya agrego where
                If yawhere = False Then
                    Consulta = Consulta & " Where "
                    yawhere = True
                End If
                'controlar si debe agregar and
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If


                If Estado = "null" Then
                    Consulta = Consulta & " ind_estado Is null  AND TipoComprobante like '%" & Tipo & "%' "
                ElseIf Estado = "Otros" Then
                    If Tipo <> "Todo" And Tipo <> "" Then
                        Consulta = Consulta & " ind_estado <> 'rechazado' and ind_estado <> 'aceptado' and TipoComprobante like '%" & Tipo & "%' "
                    Else
                        Consulta = Consulta & " ind_estado <> 'rechazado' and ind_estado <> 'aceptado' "
                    End If

                Else
                    If Tipo <> "Todo" And Tipo <> "" Then
                        Consulta = Consulta & " ind_estado='" & Estado & "' and TipoComprobante like '%" & Tipo & "%' "
                    Else
                        Consulta = Consulta & " ind_estado='" & Estado & "'  "

                    End If

                End If

            Else

                If Tipo <> "Todo" And Tipo <> "" Then
                    'controla si ya agrego where
                    If yawhere = False Then
                        Consulta = Consulta & " Where "
                        yawhere = True
                    End If
                    'controlar si debe agregar and
                    If IncluirAnd = False Then
                        IncluirAnd = True
                    Else
                        Consulta = Consulta & " and "
                    End If

                    Consulta = Consulta & " TipoComprobante like '%" & Tipo & "%' "

                End If

            End If

            If Interno <> "" Then
                'controla si ya agrego where
                If yawhere = False Then
                    Consulta = Consulta & " Where "
                    yawhere = True
                End If
                'controlar si debe agregar and
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If

                Consulta = Consulta & "CodSeguridad like '%" & Interno & "%'"


            End If

            If Calve <> 0 Then
                'controla si ya agrego where
                If yawhere = False Then
                    Consulta = Consulta & " Where "
                    yawhere = True
                End If
                'controlar si debe agregar and
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If

                Consulta = Consulta & " Calve like '%" & Calve & "%' "

            End If

            If Corregido = True Then
                'If ConCondicion = True Then
                '    Consulta = Consulta & " and "
                '    ConCondicion = False
                'End If
                'Consulta = Consulta & " [Corregido]='1'"
            Else
                'controla si ya agrego where
                If yawhere = False Then
                    Consulta = Consulta & " Where "
                    yawhere = True
                End If
                'controlar si debe agregar and
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If

                Consulta = Consulta & " [Corregido]<>'1' "

            End If

            If SinFecha = False Then
                'controla si ya agrego where
                If yawhere = False Then
                    Consulta = Consulta & " Where "
                    yawhere = True
                End If
                'controlar si debe agregar and
                If IncluirAnd = False Then
                    IncluirAnd = True
                Else
                    Consulta = Consulta & " and "
                End If

                Consulta = Consulta & " [FechaComprobante] between '" & FIni & "' and '" & FFin & "'"

            End If

            Consulta = Consulta & " group by [TipoComprobante],[ind_estado],[Clave],[Consecutivo],[Fecha],[Receptor_Nombre],[ResumenFactura_TotalComprobante],[ResumenFactura_TotalImpuesto],[fecha] ,[CodSeguridad],[Mensaje],[Receptor_CorreoElectronico],[Receptor_Tipo],[Corregido]"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            If TABLA.Rows.Count = 0 And Interno <> "" Or Calve <> 0 Then
                MsgBox("No se ha registrado el comprobante")

            End If
            Return TABLA
        Catch ex As Exception
            Return 2
        End Try
    End Function

#End Region


#Region "Funciones para WMS"


    Public Function Obtiene_Nivel(ByVal SQL_Comman As SqlCommand, Nombre As String)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""

            Consulta = "SELECT                           
                            MAX([Nivel]) AS Nivel
                        FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Picking_Ubicaciones] WHERE Nombre='" & Nombre & "' GROUP BY Nombre"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return CInt(TABLA.Rows(0).Item("Nivel").ToString())



        Catch ex As Exception
            Return 0
            'ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function

    Public Function Obtiene_Croquis(ByVal SQL_Comman As SqlCommand)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""

            Consulta = "SELECT 
                            [Rack],
                            [Columna],
                            (SELECT MAX([Rack]) AS [Rack] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Picking_Ubicaciones])  AS [Max_Rack],
	                        (SELECT MAX([Columna]) AS [Columna]  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Picking_Ubicaciones]) AS [Max_Columna],
                            [Nivel]
                        FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Picking_Ubicaciones] group by   [Rack]      ,[Columna],[Nivel]"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA



        Catch ex As Exception
            Return 2
            'ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function

    Public Function ExisteUbicacion(ByVal SQL_Comman As SqlCommand, Nombre As String)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""

            Consulta = "SELECT count(Nombre) as conto FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Picking_Ubicaciones] where Nombre='" & Nombre & "' "

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            If CInt(TABLA.Rows(0).Item("conto").ToString()) > 0 Then
                Return True
            Else
                Return False
            End If





        Catch ex As Exception
            Return False
            'ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function




    Public Function Obtiene_MaxColumnasXRack(ByVal SQL_Comman As SqlCommand, Rack As String)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""

            Consulta = "SELECT (CASE WHEN MAX([Columna]) IS NULL THEN 0 ELSE MAX([Columna]) END) AS Columna FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Picking_Ubicaciones] WHERE [Rack]='" & Rack & "'"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return TABLA.Rows(0).Item("Columna").ToString()

        Catch ex As Exception
            Return 2
            'ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function

    Public Function obtieneTopIdUbicacion(ByVal SQL_Comman As SqlCommand)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""

            Consulta = "SELECT (CASE WHEN MAX([id]) IS NULL THEN 0 ELSE MAX([id]) END) AS Columna FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Picking_Ubicaciones] "

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return TABLA.Rows(0).Item("Columna").ToString()

        Catch ex As Exception
            Return 2
            'ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function

    Public Function obtieneIdUbicacion(ByVal SQL_Comman As SqlCommand, Nombre As String)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""

            Consulta = "SELECT [id] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Picking_Ubicaciones] where Nombre='" & Nombre & "' "

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return TABLA.Rows(0).Item("id").ToString()

        Catch ex As Exception
            Return 0
            'ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function


    Public Function obtieneNumNiveles(ByVal SQL_Comman As SqlCommand, Nombre As String)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""

            Consulta = "SELECT case when MAX(Nivel) is null then '0' else MAX(Nivel) end as Nivel FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Picking_Ubicaciones] where Nombre='" & Nombre & "' GROUP BY Nombre"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return TABLA.Rows(0).Item("Nivel").ToString()

        Catch ex As Exception
            Return 0
            'ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function
    Public Function GuardaUbicaciones(ByVal SQL_Comman As SqlCommand, ByVal Nombre As String, ByVal Planta As String, ByVal Rack As String, ByVal Columna As String, ByVal Nivel As String, ByVal CodigoUbicacion As String, ByVal Notas As String, ByVal Sector As String, ByVal Pasillo As String, Categoria As String)

        Try
            Dim Consulta As String

            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Picking_Ubicaciones] ([Nombre],[Rack],[Columna],[Nivel],[CodigoUbicacion],[Notas],[Sector],[Pasillo],[Planta],[Categoria]) VALUES('" &
                            Nombre & "','" & Rack & "','" & Columna & "','" & Nivel & "','" & CodigoUbicacion & "','" & Notas & "','" & Sector & "','" & Pasillo & "','" & Planta & "','" & Categoria & "')"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception
            'ERRORES = "[ " & Now & " ] Error INSERTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try

    End Function
    Public Function ActualizarUbicaciones(ByVal SQL_Comman As SqlCommand, ByVal Nombre As String, ByVal Planta As String, ByVal Rack As String, ByVal Columna As String, ByVal Nivel As String, ByVal CodigoUbicacion As String, ByVal Notas As String, ByVal Sector As String, ByVal Pasillo As String, ByVal Categoria As String)

        Try
            Dim Consulta As String

            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Picking_Ubicaciones] SET 
                         [Nivel]= '" & Nivel & "'
                        ,[CodigoUbicacion]= '" & CodigoUbicacion & "'
                        ,[Notas]= '" & Notas & "'
                        ,[Sector]= '" & Sector & "'
                        ,[Pasillo]= '" & Pasillo & "' 
                        ,[Categoria]= '" & Categoria & "'
                         WHERE Nombre='" & Nombre & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception
            'ERRORES = "[ " & Now & " ] Error INSERTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try

    End Function
    Public Function EliminaUbicaciones(ByVal SQL_Comman As SqlCommand, ByVal Nombre As String)

        Try
            Dim Consulta As String

            Consulta = "DELETE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Picking_Ubicaciones] WHERE [Nombre]='" & Nombre & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception
            'ERRORES = "[ " & Now & " ] Error INSERTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try

    End Function

#End Region

#Region "Funciones para facturacion"




    Public Function ObtieneLineasTemp(ByVal SQL_Comman As SqlCommand, DocNum As String)
        Try
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""
            Consulta = "SELECT 
       [NumLinea]
      ,[ItemCode]
      ,[ItemName]
      ,[Pack]
      ,[UnidadMedida]
      ,[Costo]
      ,[PrecioUnitario]
      ,[Utilidad_Porciento]
      ,[Utilidad_Monto]
      ,[Cantidad]
      ,[Descuento_Porciento]
      ,[Descuento_Monto]
      ,[Impuesto_Porciento]
      ,[Impuesto_Monto]
      ,[SubTotal]
      ,[Total]
      ,[Descuento_Promo_Porciento]
      ,[Descuento_Promo_Monto]
      ,[Descuento_Interno_Porciento]
      ,[Descuento_Interno_Monto]
      ,[CodigoTarifa]
  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_FE1_Temp]
where DocNum='" & DocNum & "'"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception

        End Try
    End Function
    Public Function ObtieneConsecutivoFacturas(ByVal SQL_Comman As SqlCommand, Tipo As String)

        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""
            If Tipo = "FE" Or Tipo = "FES" Then
                Consulta = "SELECT [FE] as Consecutivo  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos_Consecutivos]"
            End If
            If Tipo = "NC" Or Tipo = "NCS" Then
                Consulta = "SELECT [NC] as Consecutivo FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos_Consecutivos]"
            End If
            If Tipo = "ND" Or Tipo = "NDS" Then
                Consulta = "SELECT [ND] as Consecutivo  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos_Consecutivos]"
            End If
            If Tipo = "TE" Then
                Consulta = "SELECT [TE] as Consecutivo  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos_Consecutivos]"
            End If
            If Tipo = "Aceptacion" Then
                Consulta = "SELECT [Aceptacion] as Consecutivo  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos_Consecutivos]"
            End If
            If Tipo = "Parcial" Then
                Consulta = "SELECT [Parcial] as Consecutivo FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos_Consecutivos]"
            End If
            If Tipo = "Rechazo" Then
                Consulta = "SELECT [Rechazo] as Consecutivo  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos_Consecutivos]"
            End If
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return TABLA.Rows(0).Item("Consecutivo").ToString()

        Catch ex As Exception
            Return 0
            'ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try

    End Function
    Public Function GuardarCE_NC(ByVal SQL_Comman As SqlCommand, ByVal CodCliente As String, ByVal DocNum As String, ByVal Clave As String, ByVal Consecutivo As String, ByVal DocDate As String, ByVal DocDueDate As String, ByVal DocTime As String, ByVal DocType As String, ByVal DocSubType As String, ByVal Status As String, ByVal Printed As String, ByVal ID_User As String, ByVal Nombre_User As String, ByVal Emisor_Nombre As String, ByVal Emisor_NombreComercial As String, ByVal Emisor_Tipo As String, ByVal Emisor_Numero As String, ByVal Emisor_Provincia As String, ByVal Emisor_Canton As String, ByVal Emisor_Distrito As String, ByVal Emisor_Barrio As String, ByVal Emisor_OtrasSenas As String, ByVal Emisor_CorreoElectronico As String, ByVal Receptor_Nombre As String, ByVal Receptor_NombreComercial As String, ByVal Receptor_Tipo As String, ByVal Receptor_Numero As String, ByVal Receptor_IdentificacionExtranjero As String, ByVal Receptor_Provincia As String, ByVal Receptor_Canton As String, ByVal Receptor_Distrito As String, ByVal Receptor_Barrio As String, ByVal Receptor_OtrasSenas As String, ByVal Receptor_CorreoElectronico As String, ByVal CondicionVenta As String, ByVal PlazoCredito As String, ByVal MedioPago As String, ByVal Referencia_Numero As String, ByVal Referencia_TipoDoc As String, ByVal Referencia_FechaEmision As String, ByVal Referencia_Codigo As String, ByVal Referencia_Razon As String, ByVal DocTotal As String, ByVal DocSubTotal As String, ByVal DocTotalImpuesto As String, ByVal DocTotalDescuento As String, ByVal DocSaldo As String, ByVal Comments As String, ByVal MH_Status As String, ByVal MH_Message As String, TotalGravado As String, TotalExento As String, Vendedor As String)
        Try


            Dim Consulta As String = ""

            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_NC]
           (
            [Clave]
           ,[CodCliente]
           ,[Consecutivo]
           ,[DocDate]
           ,[DocDueDate]
           ,[DocTime]
           ,[DocType]
           ,[DocSubType]
           ,[Status]
           ,[Printed]
           ,[ID_User]
           ,[Nombre_User]
           ,[Emisor_Nombre]
           ,[Emisor_NombreComercial]
           ,[Emisor_Tipo]
           ,[Emisor_Numero]
           ,[Emisor_Provincia]
           ,[Emisor_Canton]
           ,[Emisor_Distrito]
           ,[Emisor_Barrio]
           ,[Emisor_OtrasSenas]
           ,[Emisor_CorreoElectronico]
           ,[Receptor_Nombre]
           ,[Receptor_NombreComercial]
           ,[Receptor_Tipo]
           ,[Receptor_Numero]
           ,[Receptor_IdentificacionExtranjero]
           ,[Receptor_Provincia]
           ,[Receptor_Canton]
           ,[Receptor_Distrito]
           ,[Receptor_Barrio]
           ,[Receptor_OtrasSenas]
           ,[Receptor_CorreoElectronico]
           ,[CondicionVenta]
           ,[PlazoCredito]
           ,[MedioPago]
           ,[Referencia_Numero]
           ,[Referencia_TipoDoc]
           ,[Referencia_FechaEmision]
           ,[Referencia_Codigo]
           ,[Referencia_Razon]
           ,[DocTotal]
           ,[DocSubTotal]
           ,[DocTotalImpuesto]
           ,[DocTotalDescuento]
           ,[DocSaldo]
           ,[Comments]
           ,[MH_Status]
           ,[MH_Message]
           ,[TotalGravado]
           ,[TotalExento]   
           ,[Vendedor])
     VALUES
           (   '" & Clave &
               "','" & CodCliente &
               "','" & Consecutivo &
               "','" & DocDate &
               "','" & DocDueDate &
               "','" & DocTime &
               "','" & DocType &
               "','" & DocSubType &
               "','" & Status &
               "','" & Printed &
               "','" & ID_User &
               "','" & Nombre_User &
               "','" & Emisor_Nombre &
               "','" & Emisor_NombreComercial &
               "','" & Emisor_Tipo &
               "','" & Emisor_Numero &
               "','" & Emisor_Provincia &
               "','" & Emisor_Canton &
               "','" & Emisor_Distrito &
               "','" & Emisor_Barrio &
               "','" & Emisor_OtrasSenas &
               "','" & Emisor_CorreoElectronico &
               "','" & Receptor_Nombre &
               "','" & Receptor_NombreComercial &
               "','" & Receptor_Tipo &
               "','" & Receptor_Numero &
               "','" & Receptor_IdentificacionExtranjero &
               "','" & Receptor_Provincia &
               "','" & Receptor_Canton &
               "','" & Receptor_Distrito &
               "','" & Receptor_Barrio &
               "','" & Receptor_OtrasSenas &
               "','" & Receptor_CorreoElectronico &
               "','" & CondicionVenta &
               "','" & PlazoCredito &
               "','" & MedioPago &
               "','" & Referencia_Numero &
               "','" & Referencia_TipoDoc &
               "','" & Referencia_FechaEmision &
               "','" & Referencia_Codigo &
               "','" & Referencia_Razon &
               "','" & DocTotal &
               "','" & DocSubTotal &
               "','" & DocTotalImpuesto &
               "','" & DocTotalDescuento &
               "','" & DocSaldo &
               "','" & Comments &
               "','" & MH_Status &
               "','" & MH_Message &
               "','" & TotalGravado &
               "','" & TotalExento &
               "','" & Vendedor & "')"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            Return ObtieneConsecutivoACrear("NC")
        Catch ex As Exception
            MessageBox.Show("ERROR en GuardarCE_NC " & ex.Message)


        End Try
    End Function

    Public Function GuardarCE_FE(ByVal SQL_Comman As SqlCommand, ByVal CodCliente As String, ByVal DocNum As String, ByVal Clave As String, ByVal Consecutivo As String, ByVal DocDate As String, ByVal DocDueDate As String, ByVal DocTime As String, ByVal DocType As String, ByVal DocSubType As String, ByVal Status As String, ByVal Printed As String, ByVal ID_User As String, ByVal Nombre_User As String, ByVal Emisor_Nombre As String, ByVal Emisor_NombreComercial As String, ByVal Emisor_Tipo As String, ByVal Emisor_Numero As String, ByVal Emisor_Provincia As String, ByVal Emisor_Canton As String, ByVal Emisor_Distrito As String, ByVal Emisor_Barrio As String, ByVal Emisor_OtrasSenas As String, ByVal Emisor_CorreoElectronico As String, ByVal Receptor_Nombre As String, ByVal Receptor_NombreComercial As String, ByVal Receptor_Tipo As String, ByVal Receptor_Numero As String, ByVal Receptor_IdentificacionExtranjero As String, ByVal Receptor_Provincia As String, ByVal Receptor_Canton As String, ByVal Receptor_Distrito As String, ByVal Receptor_Barrio As String, ByVal Receptor_OtrasSenas As String, ByVal Receptor_CorreoElectronico As String, ByVal CondicionVenta As String, ByVal PlazoCredito As String, ByVal MedioPago As String, ByVal Referencia_Numero As String, ByVal Referencia_TipoDoc As String, ByVal Referencia_FechaEmision As String, ByVal Referencia_Codigo As String, ByVal Referencia_Razon As String, ByVal DocTotal As String, ByVal DocSubTotal As String, ByVal DocTotalImpuesto As String, ByVal DocTotalDescuento As String, ByVal DocSaldo As String, ByVal Comments As String, ByVal MH_Status As String, ByVal MH_Message As String, TotalGravado As String, TotalExento As String, Vendedor As String)
        Try


            Dim Consulta As String = ""

            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_FE]
           (
            [Clave]
           ,[CodCliente]
           ,[Consecutivo]
           ,[DocDate]
           ,[DocDueDate]
           ,[DocTime]
           ,[DocType]
           ,[DocSubType]
           ,[Status]
           ,[Printed]
           ,[ID_User]
           ,[Nombre_User]
           ,[Emisor_Nombre]
           ,[Emisor_NombreComercial]
           ,[Emisor_Tipo]
           ,[Emisor_Numero]
           ,[Emisor_Provincia]
           ,[Emisor_Canton]
           ,[Emisor_Distrito]
           ,[Emisor_Barrio]
           ,[Emisor_OtrasSenas]
           ,[Emisor_CorreoElectronico]
           ,[Receptor_Nombre]
           ,[Receptor_NombreComercial]
           ,[Receptor_Tipo]
           ,[Receptor_Numero]
           ,[Receptor_IdentificacionExtranjero]
           ,[Receptor_Provincia]
           ,[Receptor_Canton]
           ,[Receptor_Distrito]
           ,[Receptor_Barrio]
           ,[Receptor_OtrasSenas]
           ,[Receptor_CorreoElectronico]
           ,[CondicionVenta]
           ,[PlazoCredito]
           ,[MedioPago]
           ,[Referencia_Numero]
           ,[Referencia_TipoDoc]
           ,[Referencia_FechaEmision]
           ,[Referencia_Codigo]
           ,[Referencia_Razon]
           ,[DocTotal]
           ,[DocSubTotal]
           ,[DocTotalImpuesto]
           ,[DocTotalDescuento]
           ,[DocSaldo]
           ,[Comments]
           ,[MH_Status]
           ,[MH_Message]
           ,[TotalGravado]
           ,[TotalExento] 
           ,[Vendedor])
     VALUES
           (   '" & Clave &
               "','" & CodCliente &
               "','" & Consecutivo &
               "','" & DocDate &
               "','" & DocDueDate &
               "','" & DocTime &
               "','" & DocType &
               "','" & DocSubType &
               "','" & Status &
               "','" & Printed &
               "','" & ID_User &
               "','" & Nombre_User &
               "','" & Emisor_Nombre &
               "','" & Emisor_NombreComercial &
               "','" & Emisor_Tipo &
               "','" & Emisor_Numero &
               "','" & Emisor_Provincia &
               "','" & Emisor_Canton &
               "','" & Emisor_Distrito &
               "','" & Emisor_Barrio &
               "','" & Emisor_OtrasSenas &
               "','" & Emisor_CorreoElectronico &
               "','" & Receptor_Nombre &
               "','" & Receptor_NombreComercial &
               "','" & Receptor_Tipo &
               "','" & Receptor_Numero &
               "','" & Receptor_IdentificacionExtranjero &
               "','" & Receptor_Provincia &
               "','" & Receptor_Canton &
               "','" & Receptor_Distrito &
               "','" & Receptor_Barrio &
               "','" & Receptor_OtrasSenas &
               "','" & Receptor_CorreoElectronico &
               "','" & CondicionVenta &
               "','" & PlazoCredito &
               "','" & MedioPago &
               "','" & Referencia_Numero &
               "','" & Referencia_TipoDoc &
               "','" & Referencia_FechaEmision &
               "','" & Referencia_Codigo &
               "','" & Referencia_Razon &
               "','" & DocTotal &
               "','" & DocSubTotal &
               "','" & DocTotalImpuesto &
               "','" & DocTotalDescuento &
               "','" & DocSaldo &
               "','" & Comments &
               "','" & MH_Status &
               "','" & MH_Message &
               "','" & TotalGravado &
               "','" & TotalExento &
               "','" & Vendedor & "')"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            Return ObtieneConsecutivoACrear("FE")
        Catch ex As Exception
            MessageBox.Show("ERROR en GuardarCE_FE " & ex.Message)


        End Try
    End Function

    Public Function GuardarCE_FP(ByVal SQL_Comman As SqlCommand, ByVal CodCliente As String, ByVal DocNum As String, ByVal Clave As String, ByVal Consecutivo As String, ByVal DocDate As String, ByVal DocDueDate As String, ByVal DocTime As String, ByVal DocType As String, ByVal DocSubType As String, ByVal Status As String, ByVal Printed As String, ByVal ID_User As String, ByVal Nombre_User As String, ByVal Emisor_Nombre As String, ByVal Emisor_NombreComercial As String, ByVal Emisor_Tipo As String, ByVal Emisor_Numero As String, ByVal Emisor_Provincia As String, ByVal Emisor_Canton As String, ByVal Emisor_Distrito As String, ByVal Emisor_Barrio As String, ByVal Emisor_OtrasSenas As String, ByVal Emisor_CorreoElectronico As String, ByVal Receptor_Nombre As String, ByVal Receptor_NombreComercial As String, ByVal Receptor_Tipo As String, ByVal Receptor_Numero As String, ByVal Receptor_IdentificacionExtranjero As String, ByVal Receptor_Provincia As String, ByVal Receptor_Canton As String, ByVal Receptor_Distrito As String, ByVal Receptor_Barrio As String, ByVal Receptor_OtrasSenas As String, ByVal Receptor_CorreoElectronico As String, ByVal CondicionVenta As String, ByVal PlazoCredito As String, ByVal MedioPago As String, ByVal Referencia_Numero As String, ByVal Referencia_TipoDoc As String, ByVal Referencia_FechaEmision As String, ByVal Referencia_Codigo As String, ByVal Referencia_Razon As String, ByVal DocTotal As String, ByVal DocSubTotal As String, ByVal DocTotalImpuesto As String, ByVal DocTotalDescuento As String, ByVal DocSaldo As String, ByVal Comments As String, ByVal MH_Status As String, ByVal MH_Message As String, TotalGravado As String, TotalExento As String, Vendedor As String)
        Try


            Dim Consulta As String = ""

            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_FP]
           (
            [Clave]
           ,[CodCliente]
           ,[Consecutivo]
           ,[DocDate]
           ,[DocDueDate]
           ,[DocTime]
           ,[DocType]
           ,[DocSubType]
           ,[Status]
           ,[Printed]
           ,[ID_User]
           ,[Nombre_User]
           ,[Emisor_Nombre]
           ,[Emisor_NombreComercial]
           ,[Emisor_Tipo]
           ,[Emisor_Numero]
           ,[Emisor_Provincia]
           ,[Emisor_Canton]
           ,[Emisor_Distrito]
           ,[Emisor_Barrio]
           ,[Emisor_OtrasSenas]
           ,[Emisor_CorreoElectronico]
           ,[Receptor_Nombre]
           ,[Receptor_NombreComercial]
           ,[Receptor_Tipo]
           ,[Receptor_Numero]
           ,[Receptor_IdentificacionExtranjero]
           ,[Receptor_Provincia]
           ,[Receptor_Canton]
           ,[Receptor_Distrito]
           ,[Receptor_Barrio]
           ,[Receptor_OtrasSenas]
           ,[Receptor_CorreoElectronico]
           ,[CondicionVenta]
           ,[PlazoCredito]
           ,[MedioPago]
           ,[Referencia_Numero]
           ,[Referencia_TipoDoc]
           ,[Referencia_FechaEmision]
           ,[Referencia_Codigo]
           ,[Referencia_Razon]
           ,[DocTotal]
           ,[DocSubTotal]
           ,[DocTotalImpuesto]
           ,[DocTotalDescuento]
           ,[DocSaldo]
           ,[Comments]
           ,[MH_Status]
           ,[MH_Message]
           ,[TotalGravado]
           ,[TotalExento]  
           ,[Vendedor])
     VALUES
           (   '" & Clave &
               "','" & CodCliente &
               "','" & Consecutivo &
               "','" & DocDate &
               "','" & DocDueDate &
               "','" & DocTime &
               "','" & DocType &
               "','" & DocSubType &
               "','" & Status &
               "','" & Printed &
               "','" & ID_User &
               "','" & Nombre_User &
               "','" & Emisor_Nombre &
               "','" & Emisor_NombreComercial &
               "','" & Emisor_Tipo &
               "','" & Emisor_Numero &
               "','" & Emisor_Provincia &
               "','" & Emisor_Canton &
               "','" & Emisor_Distrito &
               "','" & Emisor_Barrio &
               "','" & Emisor_OtrasSenas &
               "','" & Emisor_CorreoElectronico &
               "','" & Receptor_Nombre &
               "','" & Receptor_NombreComercial &
               "','" & Receptor_Tipo &
               "','" & Receptor_Numero &
               "','" & Receptor_IdentificacionExtranjero &
               "','" & Receptor_Provincia &
               "','" & Receptor_Canton &
               "','" & Receptor_Distrito &
               "','" & Receptor_Barrio &
               "','" & Receptor_OtrasSenas &
               "','" & Receptor_CorreoElectronico &
               "','" & CondicionVenta &
               "','" & PlazoCredito &
               "','" & MedioPago &
               "','" & Referencia_Numero &
               "','" & Referencia_TipoDoc &
               "','" & Referencia_FechaEmision &
               "','" & Referencia_Codigo &
               "','" & Referencia_Razon &
               "','" & DocTotal &
               "','" & DocSubTotal &
               "','" & DocTotalImpuesto &
               "','" & DocTotalDescuento &
               "','" & DocSaldo &
               "','" & Comments &
               "','" & MH_Status &
               "','" & MH_Message &
               "','" & TotalGravado &
               "','" & TotalExento &
               "','" & Vendedor & "')"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            Return ObtieneConsecutivoACrear("FE")
        Catch ex As Exception
            MessageBox.Show("ERROR en Guardar CE_FP " & ex.Message)


        End Try
    End Function


    Public Function ObtieneFechaEmisionComprobantes(NumeroDocumento As String, TipoComprobante As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""
            'If TipoComprobante = "FE" Or TipoComprobante = "FES" Then
            Consulta = "SELECT Fecha FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos] where Clave='" & NumeroDocumento & "'"
            'ElseIf TipoComprobante = "NC" Or TipoComprobante = "NCS" Then
            '    Consulta = "SELECT DocDate as Fecha FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos] where Clave='" & NumeroDocumento & "' "
            'ElseIf TipoComprobante = "ND" Or TipoComprobante = "NDS" Then
            '    Consulta = "SELECT DocDate as Fecha FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[ComprobantesElectronicos] where Clave='" & NumeroDocumento & "' "
            'End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            If TABLA.Rows.Count > 0 Then
                If TABLA.Rows(0).Item("Fecha").ToString <> "" Then
                    Return TABLA.Rows(0).Item("Fecha").ToString
                Else
                    Return ""
                End If
            End If


        Catch ex As Exception
            Return New DataTable
            'ERRORES = "[ " & Now & " ] ERROR ObtieneMaxLineaFactura ( " & ex.Message & " )"
        End Try
    End Function

    Public Function ObtieneComprobantes(TipoComprobante As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""
            If TipoComprobante = "FE" Or TipoComprobante = "FES" Then
                Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_FE_View] "
            ElseIf TipoComprobante = "NC" Or TipoComprobante = "NCS" Then
                Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_NC_View] "
            ElseIf TipoComprobante = "ND" Or TipoComprobante = "NDS" Then
                Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_ND_View] "
            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA

        Catch ex As Exception
            Return New DataTable
            'ERRORES = "[ " & Now & " ] ERROR ObtieneMaxLineaFactura ( " & ex.Message & " )"
        End Try
    End Function
    Public Function ObtieneLineasFacturas(DocNum As String, Tipo As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""



            If Tipo = "FE" Or Tipo = "FES" Then
                Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_FE1] where DocNum='" & DocNum & "' "
            ElseIf Tipo = "NC" Or Tipo = "NCS" Then
                Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_NC1] where DocNum='" & DocNum & "' "
            ElseIf Tipo = "ND" Or Tipo = "NDS" Then
                Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_ND1] where DocNum='" & DocNum & "' "
            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return TABLA


        Catch ex As Exception
            Return New DataTable
            'ERRORES = "[ " & Now & " ] ERROR ObtieneMaxLineaFactura ( " & ex.Message & " )"
        End Try
    End Function

    Public Function ObtieneEstado(Clave As String, Tipo As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""

            If Tipo = "FE" Or Tipo = "FES" Then
                Consulta = "SELECT Anulado FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_FE] where Clave='" & Clave & "' "
            End If

            If Tipo = "NC" Or Tipo = "NCS" Then
                Consulta = "SELECT Anulado FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_NC] where Clave='" & Clave & "' "
            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            If TABLA.Rows(0).Item("Anulado").ToString() = "" Then
                Return 0
            Else
                Return CInt(TABLA.Rows(0).Item("Anulado").ToString())
            End If



        Catch ex As Exception
            Return New DataTable
            'ERRORES = "[ " & Now & " ] ERROR ObtieneMaxLineaFactura ( " & ex.Message & " )"
        End Try
    End Function
    Public Function CambiaEstadoAnuado(Clave As String, Tipo As String)

        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String
            If Tipo = "FE" Or Tipo = "FES" Then
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_FE] SET [Anulado]='1'
                           where  [Clave]='" & Clave & "'"
            End If
            If Tipo = "NC" Or Tipo = "NCS" Then
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_NC] SET [Anulado]='1'
                           where  [Clave]='" & Clave & "'"
            End If

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception
            'ERRORES = "[ " & Now & " ] Error GuardaCategorizaciones ( " & ex.Message & " )"
        End Try
    End Function

    Public Function ObtieneConsecutivoACrear(Tipo As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""
            'If Tipo = "FE" Or Tipo = "FES" Then
            '    Consulta = "SELECT case when MAX(DocNum) is null then -1 else  MAX(DocNum)  end  as DocNum FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_FE] "
            'End If
            'If Tipo = "NC" Or Tipo = "NCS" Then
            '    Consulta = "SELECT case when MAX(DocNum) is null then -1 else  MAX(DocNum)  end  as DocNum FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_NC] "
            'End If
            'If Tipo = "ND" Or Tipo = "NDS" Then
            '    Consulta = "SELECT case when MAX(DocNum) is null then -1 else  MAX(DocNum)  end  as DocNum FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_ND] "
            'End If

            If Tipo = "FE" Or Tipo = "FES" Then
                Consulta = "SELECT case when FE is null then -1 else  [FE]  end  as DocNum FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Consecutivos] "
            End If
            If Tipo = "NC" Or Tipo = "NCS" Then
                Consulta = "SELECT case when NC is null then -1 else  [NC]  end  as DocNum FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Consecutivos] "
            End If
            If Tipo = "ND" Or Tipo = "NDS" Then
                Consulta = "SELECT case when ND is null then -1 else  [ND]  end  as DocNum FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Consecutivos] "
            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return CInt(TABLA.Rows(0).Item("DocNum").ToString())


        Catch ex As Exception
            Return New DataTable
            'ERRORES = "[ " & Now & " ] ERROR ObtieneMaxLineaFactura ( " & ex.Message & " )"
        End Try
    End Function

    Public Function ObtieneVendedores()
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = "SELECT [CodAgente] as [id_Vendedor],[Nombre] as [Nombre_Vendedor] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Agentes] where [Puesto]='AGENTE'"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA

        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Public Function ObtieneMaxLineaFactura(DocNum As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()
            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""

            Consulta = "SELECT case when MAX(NumLinea) is null then 1 else  MAX(NumLinea) +1 end  as NumLinea FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_FE1_Temp] where DocNum='" & DocNum & "'"



            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return CInt(TABLA.Rows(0).Item("NumLinea").ToString())


        Catch ex As Exception
            Return New DataTable
            'ERRORES = "[ " & Now & " ] ERROR ObtieneMaxLineaFactura ( " & ex.Message & " )"
        End Try
    End Function
    Public Function GuardarCE_FE1_temp(DocNum As String, DocType As String, NumLinea As String, ItemCode As String, ItemName As String, Pack As String, UnidadMedida As String, Costo As String, PrecioUnitario As String, Utilidad_Porciento As String, Utilidad_Monto As String, Cantidad As String, Descuento_Porciento As String, Descuento_Monto As String, Impuesto_Porciento As String, Impuesto_Monto As String, SubTotal As String, Total As String, Descuento_Promo_Porciento As String, Descuento_Promo_Monto As String, Descuento_Interno_Porciento As String, Descuento_Interno_Monto As String, CodigoTarifa As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String = ""
            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_FE1_Temp]
           ([DocNum]
           ,[DocType]
           ,[NumLinea]
           ,[ItemCode]
           ,[ItemName]
           ,[Pack]
           ,[UnidadMedida]
           ,[Costo]
           ,[PrecioUnitario]
           ,[Utilidad_Porciento]
           ,[Utilidad_Monto]
           ,[Cantidad]
           ,[Descuento_Porciento]
           ,[Descuento_Monto]
           ,[Impuesto_Porciento]
           ,[Impuesto_Monto]
           ,[SubTotal]
           ,[Total]
           ,[Descuento_Promo_Porciento]
           ,[Descuento_Promo_Monto]
           ,[Descuento_Interno_Porciento]
           ,[Descuento_Interno_Monto]
           ,[CodigoTarifa])
     VALUES
           ('" & DocNum &
           "','" & DocType &
           "','" & ObtieneMaxLineaFactura(DocNum) &
           "','" & ItemCode &
           "','" & ItemName &
           "','" & Pack &
           "','" & UnidadMedida &
           "','" & Costo &
           "','" & PrecioUnitario &
           "','" & Utilidad_Porciento &
           "','" & Utilidad_Monto &
           "','" & Cantidad &
           "','" & Descuento_Porciento &
           "','" & Descuento_Monto &
           "','" & Impuesto_Porciento &
           "','" & Impuesto_Monto &
           "','" & SubTotal &
           "','" & Total &
           "','" & Descuento_Promo_Porciento &
           "','" & Descuento_Promo_Monto &
           "','" & Descuento_Interno_Porciento &
           "','" & Descuento_Interno_Monto &
           "','" & CodigoTarifa & "')"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR en GuardarCE_FE1_temp " & ex.Message)
        End Try
    End Function

    Public Function GuardarCE_FE1(DocNum As String, DocType As String, NumLinea As String, ItemCode As String, ItemName As String, Pack As String, UnidadMedida As String, Costo As String, PrecioUnitario As String, Utilidad_Porciento As String, Utilidad_Monto As String, Cantidad As String, Descuento_Porciento As String, Descuento_Monto As String, Impuesto_Porciento As String, Impuesto_Monto As String, SubTotal As String, Total As String, Descuento_Promo_Porciento As String, Descuento_Promo_Monto As String, Descuento_Interno_Porciento As String, Descuento_Interno_Monto As String, CodigoTarifa As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String = ""
            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_FE1]
           ([DocNum]
           ,[DocType]
           ,[NumLinea]
           ,[ItemCode]
           ,[ItemName]
           ,[Pack]
           ,[UnidadMedida]
           ,[Costo]
           ,[PrecioUnitario]
           ,[Utilidad_Porciento]
           ,[Utilidad_Monto]
           ,[Cantidad]
           ,[Descuento_Porciento]
           ,[Descuento_Monto]
           ,[Impuesto_Porciento]
           ,[Impuesto_Monto]
           ,[SubTotal]
           ,[Total]
           ,[Descuento_Promo_Porciento]
           ,[Descuento_Promo_Monto]
           ,[Descuento_Interno_Porciento]
           ,[Descuento_Interno_Monto]
           ,[CodigoTarifa])
     VALUES
           ('" & DocNum &
           "','" & DocType &
           "','" & ObtieneMaxLineaFactura(DocNum) &
           "','" & ItemCode &
           "','" & ItemName &
           "','" & Pack &
           "','" & UnidadMedida &
           "','" & Costo &
           "','" & PrecioUnitario &
           "','" & Utilidad_Porciento &
           "','" & Utilidad_Monto &
           "','" & Cantidad &
           "','" & Descuento_Porciento &
           "','" & Descuento_Monto &
           "','" & Impuesto_Porciento &
           "','" & Impuesto_Monto &
           "','" & SubTotal &
           "','" & Total &
           "','" & Descuento_Promo_Porciento &
           "','" & Descuento_Promo_Monto &
           "','" & Descuento_Interno_Porciento &
           "','" & Descuento_Interno_Monto &
           "','" & CodigoTarifa & "')"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR en GuardarCE_FE1 " & ex.Message)
        End Try
    End Function

    Public Function GuardarCE_NC1(DocNum As String, DocType As String, NumLinea As String, ItemCode As String, ItemName As String, Pack As String, UnidadMedida As String, Costo As String, PrecioUnitario As String, Utilidad_Porciento As String, Utilidad_Monto As String, Cantidad As String, Descuento_Porciento As String, Descuento_Monto As String, Impuesto_Porciento As String, Impuesto_Monto As String, SubTotal As String, Total As String, Descuento_Promo_Porciento As String, Descuento_Promo_Monto As String, Descuento_Interno_Porciento As String, Descuento_Interno_Monto As String, CodigoTarifa As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String = ""
            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_NC1]
           ([DocNum]
           ,[DocType]
           ,[NumLinea]
           ,[ItemCode]
           ,[ItemName]
           ,[Pack]
           ,[UnidadMedida]
           ,[Costo]
           ,[PrecioUnitario]
           ,[Utilidad_Porciento]
           ,[Utilidad_Monto]
           ,[Cantidad]
           ,[Descuento_Porciento]
           ,[Descuento_Monto]
           ,[Impuesto_Porciento]
           ,[Impuesto_Monto]
           ,[SubTotal]
           ,[Total]
           ,[Descuento_Promo_Porciento]
           ,[Descuento_Promo_Monto]
           ,[Descuento_Interno_Porciento]
           ,[Descuento_Interno_Monto]
           ,[CodigoTarifa])
     VALUES
           ('" & DocNum &
           "','" & DocType &
           "','" & ObtieneMaxLineaFactura(DocNum) &
           "','" & ItemCode &
           "','" & ItemName &
           "','" & Pack &
           "','" & UnidadMedida &
           "','" & Costo &
           "','" & PrecioUnitario &
           "','" & Utilidad_Porciento &
           "','" & Utilidad_Monto &
           "','" & Cantidad &
           "','" & Descuento_Porciento &
           "','" & Descuento_Monto &
           "','" & Impuesto_Porciento &
           "','" & Impuesto_Monto &
           "','" & SubTotal &
           "','" & Total &
           "','" & Descuento_Promo_Porciento &
           "','" & Descuento_Promo_Monto &
           "','" & Descuento_Interno_Porciento &
           "','" & Descuento_Interno_Monto &
           "','" & CodigoTarifa & "')"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR en GuardarCE_NC1 " & ex.Message)
        End Try
    End Function

    Public Function EliminaLineCE_FE1_temp(DocNum As String, NumLinea As String, Itemcode As String)
        Try

            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String
            Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_FE1_Temp] where DocNum='" & DocNum & "' AND NumLinea='" & NumLinea & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en EliminaLineCE_FE1_temp " & ex.Message)
        End Try
    End Function
    Public Function EliminaTodoCE_FE1_temp(DocNum As String)
        Try

            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String
            Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[CE_FE1_Temp] where DocNum='" & DocNum & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MessageBox.Show("ERROR en EliminaTodoCE_FE1_temp " & ex.Message)
        End Try
    End Function

#End Region

#Region "Funciones del Manager de Articulos ha vender"
    Public Function GuardarArticulo(ByVal SQL_Comman As SqlCommand, ItemCode As String _
        , Descripcion As String _
        , NombreExtrangero As String _
        , GrupoArticulo As String _
        , Ubicacion As String _
        , CodCabys As String _
        , CodBarras As String _
        , CodAlterno As String _
        , CodProveedor As String _
        , Comentarios As String _
        , Empaque As String _
        , InactivoDesde As String _
        , Precio As String _
        , RazonInactivo As String _
        , UnidMedida As String _
        , Largo As String _
        , Anchos As String _
        , Volumen As String _
        , SujetoAImpuesto As String _
        , TipoProducto As String _
        , ListPreci As String _
        , Familia As String _
        , Categoria As String _
        , Marca As String _
        , Tarifa As String _
        , CodTarifa As String _
        , PartidaArancelaria As String _
        , IdArticuloNuevo As String _
        , IdArticulo As String _
        , PorcUtilidad As String _
        , PrecioVenta As String _
        , Guardando As Boolean)

        Try





            Dim Consulta As String
            If Guardando = True Then
                Consulta = "INSERT INTO [dbo].[Articulos]
           ([ItemCode]
           ,[Descripcion]
           ,[NombreExtrangero]
           ,[GrupoArticulo]
           ,[Ubicacion]
           ,[CodCabys]
           ,[CodBarras]
           ,[CodAlterno]
           ,[CodProveedor]
           ,[Comentarios]
           ,[Empaque]
           ,[InactivoDesde]
           ,[Precio]
           ,[RazonInactivo]
           ,[UnidMedida]
           ,[Largo]
           ,[Anchos]
           ,[Volumen]
           ,[SujetoAImpuesto]
           ,[TipoProducto]
           ,[ListPreci]
           ,[Familia]
           ,[Categoria]
           ,[Marca] 
           ,[Tarifa]
           ,[Cod_Tarifa]
           ,[IdLineaNuevaWms]
           ,[PorcUtilidad]
           ,[PrecioVenta])
     VALUES
           ('" & ItemCode & "'
           ,'" & Descripcion & "'
           ,'" & NombreExtrangero & "'
           ,'" & GrupoArticulo & "'
           ,'" & Ubicacion & "'
           ,'" & CodCabys & "'
           ,'" & CodBarras & "'
           ,'" & CodAlterno & "'
           ,'" & CodProveedor & "'
           ,'" & Comentarios & "'
           ," & Empaque & "
           ,'" & InactivoDesde & "'
           ," & Precio & "
           ,'" & RazonInactivo & "'
           ,'" & UnidMedida & "'
           ,'" & Largo & "'
           ," & Anchos & "
           ," & Volumen & "
           ,'" & SujetoAImpuesto & "'
           ,'" & TipoProducto & "'
           ,'" & ListPreci & "'
           ,'" & Familia & "'
           ,'" & Categoria & "'
           ,'" & Marca & "'
           ,'" & Tarifa & "'     
           ,'" & CodTarifa & "'
           ,'" & IdArticuloNuevo & "'   
           ,'" & PorcUtilidad & "'  
           ,'" & PrecioVenta & "'  
           )"
            Else

                Consulta = "UPDATE [dbo].[Articulos] SET 
                            [ItemCode]='" & ItemCode & "'
                           ,[Descripcion]='" & Descripcion & "'
                           ,[NombreExtrangero]='" & NombreExtrangero & "'
                           ,[GrupoArticulo]='" & GrupoArticulo & "'
                           ,[Ubicacion]='" & Ubicacion & "'
                           ,[CodCabys]='" & CodCabys & "'
                           ,[CodBarras]='" & CodBarras & "'
                           ,[CodAlterno]='" & CodAlterno & "'
                           ,[CodProveedor]='" & CodProveedor & "'
                           ,[Comentarios]='" & Comentarios & "'
                           ,[Empaque]=" & Empaque & "
                           ,[InactivoDesde]='" & InactivoDesde & "'
                           ,[Precio]=" & Precio & "
                           ,[RazonInactivo]='" & RazonInactivo & "'
                           ,[UnidMedida]='" & UnidMedida & "'
                           ,[Largo]='" & Largo & "'
                           ,[Anchos]='" & Anchos & "'
                           ,[Volumen]='" & Volumen & "'
                           ,[SujetoAImpuesto]='" & SujetoAImpuesto & "'
                           ,[TipoProducto]='" & TipoProducto & "'
                           ,[ListPreci]='" & ListPreci & "'
                           ,[Familia]='" & Familia & "'
                           ,[Categoria]='" & Categoria & "'
                           ,[Marca]='" & Marca & "'
                           ,[Tarifa]='" & Tarifa & "'
                           ,[Cod_Tarifa]='" & CodTarifa & "'
                           ,[IdLineaNuevaWms]='" & IdArticuloNuevo & "' 
                           ,[Utilidad_Porciento]='" & PorcUtilidad & "' 
                           ,[PrecioVenta]='" & PrecioVenta & "' 
                         where  [Id]='" & IdArticulo & "'"
            End If

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception

            MessageBox.Show("[ " & Now & " ] Error INSERTAPedidosHoyPendientes ( " & ex.Message & " )")
        End Try


    End Function

    Public Function ActualizaCodBarrasFotos(ByVal SQL_Comman As SqlCommand, CodBarrasViejo As String, CodBarrasNuevo As String)

        Try
            Dim Consulta As String
            Consulta = "UPDATE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Picking_LineasNuevasFotos] SET [CodBarras]='" & CodBarrasNuevo & "' WHERE  [CodBarras]='" & CodBarrasViejo & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception
            'ERRORES = "[ " & Now & " ] Error GuardaCategorizaciones ( " & ex.Message & " )"
        End Try
    End Function
    Public Function CambiaEstadoLineaNueva(ByVal SQL_Comman As SqlCommand, Id As String)

        Try
            Dim Consulta As String


            Consulta = "UPDATE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Picking_LineasNuevas] SET [Estado]='1'
                        where  [Id]='" & Id & "'"



            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception
            'ERRORES = "[ " & Now & " ] Error GuardaCategorizaciones ( " & ex.Message & " )"
        End Try


    End Function
    Public Function CambiaEstadoArticulo(ByVal SQL_Comman As SqlCommand, Id As String)

        Try
            Dim Consulta As String


            Consulta = "UPDATE " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Articulos] SET [CreadoEnSap]='1'  where  [Id]='" & Id & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception
            'ERRORES = "[ " & Now & " ] Error GuardaCategorizaciones ( " & ex.Message & " )"
        End Try


    End Function

    Public Function ObtieneFoto(ByVal SQL_Comman As SqlCommand)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""

            Consulta = "SELECT Imagen from [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Picking_LineasNuevasFotos] where CodBarras='100'"



            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)


            ADATER.Fill(TABLA)


            Return TABLA

        Catch ex As Exception
            Return New DataTable
            'ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function

    Public Sub EliminaFoto(ByVal SQL_Comman As SqlCommand, ByVal ID As String)
        Try


            Dim Consulta As String
            Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Picking_LineasNuevasFotos] where Id='" & ID & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing

            MsgBox("Foto Eliminada con exito")
        Catch ex As Exception
            MsgBox("ERROR en Eliminar foto: " & ex.Message)
        End Try
    End Sub

    Public Function ObtieneCategorizaciones(ByVal SQL_Comman As SqlCommand, Tipo As String, SoloNombre As Boolean)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""
            If SoloNombre = False Then
                Consulta = "SELECT [id],[Tipo],[Nombre] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Categorizaciones_Inventario] where Tipo='" & Tipo & "'"
            Else
                Consulta = "SELECT [Nombre] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Categorizaciones_Inventario] where Tipo='" & Tipo & "'"
            End If


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return TABLA

        Catch ex As Exception
            Return New DataTable
            'ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function
    Public Function ObtieneSectoresSAP(ByVal SQL_Comman As SqlCommand)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Consulta = " SELECT T0.[Code],T0.[Name] FROM [BD_Bourne].[dbo].[@UBICACION] T0"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function
    Public Function ObtieneItemGroupSAP(ByVal SQL_Comman As SqlCommand)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""
            Consulta = " SELECT T0.[ItmsGrpCod],T0.[ItmsGrpNam] FROM [BD_Bourne].[dbo].[OITB] T0"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function
    Public Function ObtieneCategorizacionesSAP(ByVal SQL_Comman As SqlCommand, Tipo As String)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String = ""

            If Tipo = "Familia" Then
                Consulta = "SELECT T0.[Code],T0.[Name] FROM [BD_Bourne].[dbo].[@FAMILIA] T0"
            End If
            If Tipo = "Categoria" Then
                Consulta = "SELECT T0.[Code],T0.[Name] FROM [BD_Bourne].[dbo].[@CATEGORIA] T0"
            End If
            If Tipo = "Marca" Then
                Consulta = "SELECT T0.[Code],T0.[Name] FROM [BD_Bourne].[dbo].[@MARCA] T0"
            End If




            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)


            Return TABLA

        Catch ex As Exception
            Return New DataTable
            'ERRORES = "[ " & Now & " ] ERROR CONSULTAPedidosHoyPendientes ( " & ex.Message & " )"
        End Try
    End Function

    Public Function ObtieneItemFotos(ByVal SQL_Comman As SqlCommand, CodBarras As String, Id As String)
        Try

            Dim TABLA As New DataTable
            Dim ADATER As New SqlDataAdapter
            Dim Consulta As String = ""

            If Id <> "" Then
                Consulta = "select CodBarras, Imagen,Id from " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Picking_LineasNuevasFotos] where CodBarras = '" + CodBarras + "' and Id='" + Id + "'"

            Else
                Consulta = "select CodBarras, Imagen,Id from " & Class_VariablesGlobales.XMLParamSQL_dababase & ".[dbo].[Picking_LineasNuevasFotos] where CodBarras = '" + CodBarras + "'"

            End If
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)

            Return TABLA
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function
    Public Function GuardaCategorizaciones(ByVal SQL_Comman As SqlCommand, id As String, Tipo As String, Nombre As String, Guardando As Boolean)

        Try
            Dim Consulta As String
            If Guardando = True Then
                Consulta = "INSERT INTO [dbo].[Categorizaciones_Inventario]
                           ([Tipo]
                           ,[Nombre]
                           )
                     VALUES
                           ('" & Tipo & "'
                           ,'" & Nombre & "')"

            Else

                Consulta = "UPDATE [dbo].[Categorizaciones_Inventario] SET 
                            [Tipo]='" & Tipo & "'
                           ,[Nombre]='" & Nombre & "'
                           where  [id]='" & id & "'"

            End If

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
        Catch ex As Exception
            'ERRORES = "[ " & Now & " ] Error GuardaCategorizaciones ( " & ex.Message & " )"
        End Try


    End Function

#End Region


#Region "FUNCIONES PARA CONTEOS DE TOMA FISICA (INVENTARIO TRIMESTRAL)"


    Public Obj_VarGlobal As New Class_VariablesGlobales
    Public Sub GuardaGrupo(ByVal CodGrupo As String, ByVal IdInventario As String, Unificando0 As Boolean)
        Try
            Dim Consulta As String
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()
            If Unificando0 = True Then
                Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_ConActivo]([Grupo], [Conteo],[IdInventario]) VALUES ('" & CodGrupo & "','4','" & IdInventario & "')"
                SQL_Comman.CommandText = Consulta
                SQL_Comman.ExecuteNonQuery()
            Else



                Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_ConActivo]([Grupo], [Conteo],[IdInventario]) VALUES ('" & CodGrupo & "','1','" & IdInventario & "')"
                SQL_Comman.CommandText = Consulta
                SQL_Comman.ExecuteNonQuery()

                Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_ConActivo]([Grupo], [Conteo],[IdInventario]) VALUES ('" & CodGrupo & "','2','" & IdInventario & "')"
                SQL_Comman.CommandText = Consulta
                SQL_Comman.ExecuteNonQuery()
                SQL_Comman = Nothing

            End If
        Catch ex As Exception
            GuardaGrupo(CodGrupo, IdInventario, Unificando0)
            MsgBox("ERROR en GuardaGrupo: " & ex.Message)

        End Try
    End Sub
    Public Sub EliminaGrupo(ByVal CodGrupo As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String
            Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_ConActivo] where Grupo='" & CodGrupo & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MsgBox("ERROR en EliminaGrupo: " & ex.Message)
        End Try
    End Sub

    'Public Sub BorrarGrupoConteo()
    '    Try
    '        Dim Consulta As String
    '        Consulta = "DELETE FROM `arquitect_bourne`.`Inv_Grupos` ;"
    '        MYSQ_Comman.CommandText = Consulta
    '        MYSQ_Comman.ExecuteNonQuery()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)

    '    End Try
    'End Sub
    Public Sub BorrarGrupos(ByVal Grupo As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String

            If Grupo = "" Then
                Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos]"
            Else
                Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] WHERE Grupo='" & Grupo & "'"
            End If

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MsgBox("ERROR en BorrarGrupos: " & ex.Message)

        End Try
    End Sub
    Public Sub ConteoActivo()
            Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String
            Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_ConActivo]"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MsgBox("ERROR en SQL_Comman: " & ex.Message)

        End Try
        End Sub
    Public Sub BorraGrupoConteo(ByVal idGrupo As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String
            Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] where [idGrupo]= '" & idGrupo & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MsgBox("ERROR en BorraGrupoConteo: " & ex.Message)

        End Try
    End Sub
    Public Sub BorraConteo(ByVal idGrupo As String, ByVal IdInventario As String)
            Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String
            Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Conteos] WHERE [Grupo]='" & idGrupo & "' and [IdInventario]='" & IdInventario & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception

                BorraConteo(idGrupo, IdInventario)
            MsgBox("ERROR en BorraConteo: " & ex.Message)

        End Try
        End Sub
    Public Sub InsertConteo(ByVal CodGrupo As String, ByVal CodArticulo As String, ByVal Descripcion As String, ByVal IdInventario As String, ByVal Conte As Integer, ByVal CodProveedor As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String
            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Conteos] ([IdInventario], [Grupo], [NumConteo], [CodArticulo], [Descripcion], [Cuenta], [Reconteo], [CodProveedor]) VALUES ('" & IdInventario & "', '" & CodGrupo & "', '" & Conte & "','" & CodArticulo & "','" & Descripcion & "', '0', '0','" & CodProveedor & "')"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MsgBox("ERROR en InsertConteo: " & ex.Message)
        End Try
    End Sub
    Public Sub EliminaConteo(ByVal CodGrupo As String, ByVal IdInventario As String, ByVal CodProveedor As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String
            Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Conteos] WHERE [IdInventario]='" & IdInventario & "' AND [Grupo]='" & CodGrupo & "' AND [CodProveedor]='" & CodProveedor & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MsgBox("ERROR en EliminaConteo: " & ex.Message)
        End Try
    End Sub
    Public Sub GuardaGrupoConteo(ByVal idGrupo As String, ByVal Responsable As String, ByVal Acompañante As String, ByVal CodProveedor As String, ByVal NombreProveedor As String, ByVal CodInventario As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String
            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] ([idGrupo], [Responsable], [Acompanante], [CodProveedor], [NombreProveedor], [CodInventario]) VALUES ('" & idGrupo & "', '" & Responsable & "', '" & Acompañante & "', '" & CodProveedor & "', '" & NombreProveedor & "', '" & CodInventario & "')"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MsgBox("ERROR EN GuardaGrupoConteo" & ex.Message)

        End Try
    End Sub
    Public Sub EliminaGrupoConteo(ByVal idGrupo As String, ByVal CodProveedor As String, ByVal CodInventario As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String
            Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] WHERE [idGrupo]='" & idGrupo & "' AND [CodProveedor] ='" & CodProveedor & "' AND [CodInventario] = '" & CodInventario & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MsgBox("ERROR EN EliminaGrupoConteo" & ex.Message)

        End Try
    End Sub

    Public Function ConpruebaProveedor(ByVal CodGrupo As String, ByVal CodProveedor As String, ByVal IdInventario As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable


            Dim Consulta As String = "SELECT COUNT(NumConteo) as Conto FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Conteos] where CodProveedor='" & CodProveedor & "' and Grupo ='" & CodGrupo & "'  and NumConteo=1 and IdInventario='" & IdInventario & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            Dim RET As Boolean = False
            If CInt(TABLA.Rows(0).Item("Conto").ToString()) > 1 Then
                RET = True
            Else
                RET = False
            End If

            SQL_Comman = Nothing
            Return RET
        Catch ex As Exception

            Return ConpruebaProveedor(CodGrupo, CodProveedor, IdInventario)
            MsgBox(ex.Message)

        End Try
    End Function
    Public Function ObtieneIdInventario()

        Dim SQL_Comman As New SqlCommand
        Try
            SQL_Comman = Conectar()
            Dim Retorno As String

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable

            ' Dim Consulta As String = "SELECT  id FROM `Inv_Registro`  ORDER BY id DESC LIMIT 1"
            Dim Consulta As String = "SELECT TOP 1  id FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Registro]  ORDER BY id DESC"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            SQL_Comman = Nothing
            Try
                Retorno = TABLA.Rows(0).Item("id").ToString()
            Catch ex As Exception
                Retorno = "0"
            End Try
            Return Retorno
        Catch ex As Exception
            SQL_Comman = Nothing
            Return ObtieneIdInventario()
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ObtieneIdInventario ( " & ex.Message & " )"
        End Try
    End Function
    Public Function TieneGrupo(CodProveedor As String, CodInventario As String)

        Dim SQL_Comman As New SqlCommand
        Try
            SQL_Comman = Conectar()


            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Devuelve As Boolean = False
            ' Dim Consulta As String = "SELECT  id FROM `Inv_Registro`  ORDER BY id DESC LIMIT 1"

            Dim Consulta As String = "Select COUNT([idGrupo]) As Grupos  From [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[inv_grupos]  Where [CodInventario] ='" & CodInventario & "' AND [CodProveedor]='" & CodProveedor & "'"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)



            If TABLA.Rows.Count > 0 Then

                If TABLA.Rows(0).Item("Grupos").ToString() = "0" Then
                    'El proveedor no tienen ningun grupo asignado
                    Devuelve = False
                Else
                    'Si tiene almenos un grupo asignado
                    Devuelve = True
                End If

            Else
                'El proveedor no tienen ningun grupo asignado
                Devuelve = False
            End If
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            SQL_Comman = Nothing
            Return Devuelve
        Catch ex As Exception
            SQL_Comman = Nothing
            Return False
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR TieneGrupo ( " & ex.Message & " )"
        End Try
    End Function
    Public Function ExisteGrupo(Grupo As String, CodInventario As String)

        Dim SQL_Comman As New SqlCommand
        Try
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Devuelve As Boolean = False
            ' Dim Consulta As String = "SELECT  id FROM `Inv_Registro`  ORDER BY id DESC LIMIT 1"
            Dim Consulta As String = "SELECT  [idGrupo] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[inv_grupos] WHERE [idGrupo] LIKE '%" & Grupo & "%' and [CodInventario] = '" & CodInventario & "'"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)

            If TABLA.Rows.Count > 0 Then
                Devuelve = True
            Else
                Devuelve = False
            End If
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            SQL_Comman = Nothing
            Return Devuelve
        Catch ex As Exception
            SQL_Comman = Nothing
            Return ObtieneIdInventario()
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ObtieneIdInventario ( " & ex.Message & " )"
        End Try
    End Function

    Public Sub CreaRegConteos(ByVal Titulo As String, ByVal comentarioa As String)
            Try
            Dim TABLA As New DataTable
            Dim SQL_Comman As SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String
            'Consulta = "INSERT INTO `arquitect_bourne`.`Inv_Registro` (`id`, `Fecha`, `Titulo`, `Comentario`, `Cerrado`, `InvInicial`,`InvFinal`,`ENTRADAS`,`SALIDAS`,`DIFERENCIAS`) VALUES (NULL, '" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Now.Date) & "', '" & Titulo & "', '" & comentarioa & "','0',0,0,0,0,0);"
            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[inv_registro] ([Fecha],[Titulo],[Comentario],[Cerrado],[InvInicial],[InvFinal],[ENTRADAS],[SALIDAS],[DIFERENCIAS]) VALUES ( '" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Now.Date) & "', '" & Titulo & "', '" & comentarioa & "','0',0,0,0,0,0)"


            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
                MsgBox("ERROR EN CreaRegConteos : " & ex.Message)
            End Try

        End Sub
        Public Sub ActualizaRegConteos(ByVal id As String, ByVal InvInicial As Double)
            Try

            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim TABLA As New DataTable
            Dim Consulta As String
            'Consulta = "UPDATE `inv_registro` SET `InvInicial`=" & InvInicial & " WHERE `id`=" & id
            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[inv_registro] SET [InvInicial] =" & InvInicial & " WHERE [id]=" & id


            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
        Catch ex As Exception
            MsgBox("ERROR EN ActualizaRegConteos : " & ex.Message)
        End Try
        End Sub
    Public Function ActualizaStocks(ByVal IdInventario As String, ByVal Codigo As String, ByVal Stock_b1 As Integer, ByVal Monto_B1 As Double)
        Try

            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            'Dim Consulta As String = "UPDATE  `Conteo` SET `Stock_b1`= '" & Stock_b1 & "',`Stock_b2`= '" & Stock_b2 & "',`Stock_b3`= '" & Stock_b3 & "',`Stock_b4`= '" & Stock_b4 & "',`Stock_b5`= '" & Stock_b5 & "',`Stock_b6`= '" & Stock_b6 & "' ,`Monto_B1`= " & Monto_B1 & ",`Monto_B2`= " & Monto_B2 & ",`Monto_B3`= " & Monto_B3 & ",`Monto_B4`= " & Monto_B4 & ",`Monto_B5`= " & Monto_B5 & ",`Monto_B6`= " & Monto_B6 & "  WHERE `IdInventario`='" & IdInventario & "' AND `Codigo`='" & Codigo & "'"

            'actualiza el stock del conteo y DF Y MDF
            Dim Consulta As String = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Inventario] SET [Stock]='" & Stock_b1 & "',[Monto]='" & Monto_B1 & "',[DF]=CONVERT(int,(SELECT [CF] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[inv_inventario] WHERE  [IdInventario]='" & IdInventario & "' AND Codigo='" & Codigo & "'))-" & Stock_b1 & ",[DFM]=(CONVERT(int,(SELECT [CF] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[inv_inventario] WHERE  [IdInventario]='" & IdInventario & "' AND Codigo='" & Codigo & "'))-" & Stock_b1 & ")*(SELECT [Costo] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[inv_inventario] WHERE  [IdInventario]='" & IdInventario & "' AND Codigo='" & Codigo & "') where [IdInventario]='" & IdInventario & "' and [Codigo]='" & Codigo & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            Consulta = Nothing
            SQL_Comman = Nothing
        Catch ex As Exception
            ActualizaStocks(IdInventario, Codigo, Stock_b1, Monto_B1)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ActualizaStocks ( " & ex.Message & " )"
        End Try
    End Function
    Public Function NoRecuenta(ByVal idInventario As String, ByVal Codigo As String, ByVal idGrupo As String, ByVal NumConteo As Integer, ByVal Cuenta As Integer)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String
            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Conteos] SET [Reconteo]='1',[Cuenta]='" & Cuenta & "' where [IdInventario]='" & idInventario & "' and [CodArticulo]='" & Codigo & "' AND Grupo='" & idGrupo & "' AND NumConteo='" & NumConteo & "'"

            'Consulta = "UPDATE  `Conteo` SET `Reconteo`= '1' WHERE `IdInventario`='" & idInventario & "' AND `Codigo`='" & Codigo & "' "
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            Consulta = Nothing
            SQL_Comman = Nothing
        Catch ex As Exception

            'CNX_1 = Obj_SQL_CONEXION_CONEXION.Conectar(Class_VariablesGlobales.XMLParamSQL_dababase, CNX_1)
            'Class_VariablesGlobales.SQL_Comman1.Connection = CNX_1

            'MsgBox("Error NoRecuenta Codigo : " & Codigo)
            NoRecuenta(idInventario, Codigo, idGrupo, NumConteo, Cuenta)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR NoRecuenta ( " & ex.Message & " )"
        End Try
    End Function
    Public Function Recuenta(ByVal idInventario As String, ByVal Codigo As String, ByVal idGrupo As String, ByVal NumConteo As String, ByVal Cuenta As Integer)
            Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String

            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Conteos] SET [Reconteo]='0',[Cuenta]='' where [IdInventario]='" & idInventario & "' and [CodArticulo]='" & Codigo & "' AND Grupo='" & idGrupo & "' AND NumConteo='" & NumConteo & "'"
            '  Consulta = "UPDATE  `Conteo` SET `Reconteo`= '0' WHERE `IdInventario`='" & idInventario & "' AND `Codigo`='" & Codigo & "' "
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            Consulta = Nothing
            SQL_Comman = Nothing
        Catch ex As Exception
                Recuenta(idInventario, Codigo, idGrupo, NumConteo, Cuenta)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR Recuenta ( " & ex.Message & " )"
        End Try
        End Function
        Public Function ActualizaConteo(ByVal idInventario As String, ByVal Codigo As String, ByVal Grupo As String, ByVal Cuenta As String, ByVal NumConteo As String)
            Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String
            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Conteos] SET [Cuenta]='" & Cuenta & "' where [IdInventario]='" & idInventario & "' and [CodArticulo]='" & Codigo & "' and Grupo='" & Grupo & "' and NumConteo='" & NumConteo & "'"
            '  Consulta = "UPDATE  `Conteo` SET `Reconteo`= '0' WHERE `IdInventario`='" & idInventario & "' AND `Codigo`='" & Codigo & "' "
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            Consulta = Nothing
            SQL_Comman = Nothing
        Catch ex As Exception
                ActualizaConteo(idInventario, Codigo, Grupo, Cuenta, NumConteo)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ActualizaConteo ( " & ex.Message & " )"
        End Try
        End Function
        Public Function Stock(ByVal CodArticulo As String)
            Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable

            'Dim Consulta As String = "SELECT `C1`,`C2`,`C3`,`C4`,`C5`,`C6`,`C7`,`C8` FROM `Grupos` WHERE `CodGrupo`='" & Grupo & "'"
            Dim Consulta As String = "SELECT Stock FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Inventario] where Codigo='" & CodArticulo & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)
            SQL_Comman = Nothing
            Return TABLA.Rows(0).Item("Stock").ToString()


                'liberando memoria
                ADATER.Dispose()
                ADATER = Nothing
                Consulta = Nothing
                Return TABLA

            Catch ex As Exception
                Return Stock(CodArticulo)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR Stock ( " & ex.Message & " )"
        End Try
        End Function
    Public Function Costo(ByVal CodArticulo As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable

            'Dim Consulta As String = "SELECT `C1`,`C2`,`C3`,`C4`,`C5`,`C6`,`C7`,`C8` FROM `Grupos` WHERE `CodGrupo`='" & Grupo & "'"
            Dim Consulta As String = "SELECT Costo FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Inventario] where Codigo='" & CodArticulo & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)
            SQL_Comman = Nothing
            Return TABLA.Rows(0).Item("Costo").ToString()


            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            Return TABLA

        Catch ex As Exception
            Return Stock(CodArticulo)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR Costo ( " & ex.Message & " )"
        End Try
    End Function
    Public Function ActivaConteo(ByVal Grupo As String, ByVal Conteo As String, ByVal IdInventario As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()
            Dim Consulta As String = ""


            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[inv_conactivo] SET [Finalizado] = '0' WHERE [IdInventario] = '" & IdInventario & "' AND  [Grupo] = '" & Grupo & "' AND  [Conteo] = '" & Conteo & "' "
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing

            Return 0
        Catch ex As Exception

        End Try
    End Function
    Public Function ConteoActivoDelGrupo(ByVal Grupo As String, ByVal IdInventario As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim ConteoActivo As String = ""

            'Dim Consulta As String = "SELECT `C1`,`C2`,`C3`,`C4`,`C5`,`C6`,`C7`,`C8` FROM `Grupos` WHERE `CodGrupo`='" & Grupo & "'"
            Dim Consulta As String = "SELECT max(Conteo) as Conteo  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_ConActivo] where Grupo='" & Grupo & "' and IdInventario='" & IdInventario & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            If TABLA.Rows.Count > 0 Then
                For Each row As DataRow In TABLA.Rows
                    If TABLA.Rows(0).Item("Conteo").ToString() <> "" Then
                        ConteoActivo = CInt(TABLA.Rows(0).Item("Conteo").ToString())
                    End If
                Next
            End If

            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            SQL_Comman = Nothing
            Return ConteoActivo

        Catch ex As Exception
            Return ConteoActivoDelGrupo(Grupo, IdInventario)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ConteoActivoDelGrupo ( " & ex.Message & " )"
        End Try
    End Function


    Public Function GrupoFinalizado(Grupo As String, Conteo As String, IdInventario As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Finalizado As String = ""

            Dim Consulta As String = "SELECT Finalizado FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[inv_conactivo] where Grupo='" & Grupo & "' and Conteo='" & Conteo & "' and IdInventario='" & IdInventario & "'"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)
            If TABLA.Rows.Count > 0 Then
                For Each row As DataRow In TABLA.Rows

                    If TABLA.Rows(0).Item("Finalizado").ToString() <> "" Then
                        Finalizado = CInt(TABLA.Rows(0).Item("Finalizado").ToString())
                    End If
                Next
            End If

            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            SQL_Comman = Nothing
            Return Finalizado

        Catch ex As Exception
            'Return ConteoActivoDelGrupo(Grupo, IdInventario)
            Return GrupoFinalizado(Grupo, Conteo, IdInventario)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR GrupoFinalizado ( " & ex.Message & " )"
        End Try
    End Function
    Public Function PuedeUnifica(ByVal Proveeodr As String)
        Dim Autorizado As String
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            'Agrupa y suma todos los conteos segun el codigo del proveedor y la linea uniendo lo diferents grupos que tienen la misma casa comercial
            Dim Consulta As String = "
SELECT (case when Count(T0.idGrupo) =SUM(Finalizado) then 'True' else 'False' end) as Autorizado FROM(
SELECT  
 idGrupo,
(SELECT [Finalizado] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[inv_conactivo] WHERE [Conteo]='3' AND  [IdInventario]=(SELECT TOP 1  id FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Registro] ORDER BY id DESC) AND [Grupo]=[idGrupo]) AS Finalizado 
FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] 
WHERE [CodInventario]=(SELECT TOP 1  id FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Registro] ORDER BY id DESC) and [CodProveedor]='" & Proveeodr & "' AND LEN(idGrupo)=1
GROUP By [idGrupo]) T0 "
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)

            If TABLA.Rows.Count > 0 Then


                If TABLA.Rows(0).Item("Autorizado").ToString() <> "" Then

                    Autorizado = TABLA.Rows(0).Item("Autorizado").ToString()
                Else
                    Autorizado = "False"
                End If

            End If

            SQL_Comman = Nothing
            Return Autorizado



            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing

        Catch ex As Exception
            Autorizado = "False"
            Return Autorizado

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR PuedeUnifica ( " & ex.Message & " )"
        End Try
    End Function
    Public Function Unifica(ByVal Proveeodr As String, ByVal IdInventario As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            'Agrupa y suma todos los conteos segun el codigo del proveedor y la linea uniendo lo diferents grupos que tienen la misma casa comercial
            Dim Consulta As String = "SELECT CodArticulo,SUM(Cuenta) AS Conteo,Descripcion FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Conteos] WHERE CodProveedor='" & Proveeodr & "' AND NumConteo='3' AND IdInventario='" & IdInventario & "' GROUP BY CodArticulo,Descripcion ORDER BY CodArticulo DESC"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)
            SQL_Comman = Nothing
            Return (TABLA)
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing

        Catch ex As Exception
            Return Unifica(Proveeodr, IdInventario)

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR Unifica ( " & ex.Message & " )"
        End Try
    End Function

    Public Function CambiaAUnificado(ByVal IdInventario As String, ByVal Proveedor As String)

        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()
            Dim Consulta As String = ""
            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[inv_inventario] SET [Unificado] = '1' WHERE [IdInventario] = '" & IdInventario & "' AND  [CodProveedor] = '" & Proveedor & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing

            Return 0

        Catch ex As Exception
            Return 1
            MessageBox.Show("ERROR en CambiaAUnificado [ " & ex.Message & " ]")
        End Try
    End Function

    Public Function BloqueaAccesoGrupo(ByVal Grupo As String, ByVal HabilitaConteo As String, ByVal Valor As String, ByVal Accion As String, ByVal [IdInventario] As String)
        Try

            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String

            If Accion = "Borra" Then
                'Consulta = "DELETE FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_ConActivo] WHERE [Conteo]='" & Valor & "' AND [Grupo]='" & Grupo & "'"
                Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_ConActivo] SET [Finalizado] = '1' WHERE [IdInventario] = '" & IdInventario & "' and [Conteo]='" & Valor & "' AND [Grupo]='" & Grupo & "' "
            Else
                Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_ConActivo] ([Grupo], [Conteo],[IdInventario]) VALUES ('" & Grupo & "', '" & Valor & "', '" & IdInventario & "')"
            End If

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            Consulta = Nothing
            SQL_Comman = Nothing
        Catch ex As Exception
            BloqueaAccesoGrupo(Grupo, HabilitaConteo, Valor, Accion, IdInventario)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR BloqueaAccesoGrupo ( " & ex.Message & " )"
        End Try
    End Function
    Public Function SectorGrupo(ByVal Sector As String, ByVal Grupo As String, ByVal IdInventario As String)

            Try

            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String

            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Conteo] SET [CodG1]='" & Grupo & "' WHERE [Sector]='" & Sector & "' and [IdInventario]='" & IdInventario & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            Consulta = Nothing
            SQL_Comman = Nothing
        Catch ex As Exception

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR SectorGrupo ( " & ex.Message & " )"
        End Try
        End Function
        Public Function ComparaConteos(ByVal Grupo As String, ByVal IdInventario As String)

            '
            Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()
            Dim MyDataSet As DataSet
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
                Dim ListaProveedores As New DataTable
                Dim Consulta As String
                Dim CodG1 As String
                Dim cuenta As Integer = 0
            'Obtiene los proveedores asinganados al grupo

            'Consulta = "SELECT T0.IdInventario,T0.Codigo,(SELECT Cuenta FROM `Inv_Conteos` where NumConteo=1 and CodArticulo=T0.Codigo and  Grupo='A' and IdInventario='32') as C1 ,(SELECT Cuenta FROM `Inv_Conteos` where NumConteo=2 and CodArticulo=T0.Codigo and  Grupo='A' and IdInventario='32') as C2,T0.CodProveedor FROM `Inv_Inventario` T0 WHERE T0.IdInventario='32' and (`CodProveedor`='P062') "

            ListaProveedores = ObtieneListaProveedores(Grupo, IdInventario)
            Consulta = "SELECT T0.IdInventario,T0.Codigo,(SELECT Cuenta FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Conteos] where NumConteo=1 and CodArticulo=T0.Codigo and  Grupo='" & Grupo & "' and IdInventario='" & IdInventario & "') as C1 ,(SELECT Cuenta FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Conteos] where NumConteo=2 and CodArticulo=T0.Codigo and  Grupo='" & Grupo & "' and IdInventario='" & IdInventario & "') as C2,T0.CodProveedor,T0.[Descripcion] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Inventario] T0 WHERE T0.IdInventario='" & IdInventario & "' and ("

            'recorre la lista de proveedores para generar la formula
            If ListaProveedores.Rows.Count > 0 Then
                    For Each row As DataRow In ListaProveedores.Rows
                    Consulta = Consulta & "[CodProveedor]='" & ListaProveedores.Rows(cuenta).Item("CodProveedor").ToString() & "'"
                    Try
                            If ListaProveedores.Rows(cuenta + 1).Item("CodProveedor").ToString() <> "" Then
                                Consulta = Consulta & " or "
                            End If
                        Catch ex As Exception

                        End Try

                        cuenta += 1
                    Next
                Consulta = Consulta & ") ORDER BY T0.CodProveedor,T0.Codigo ASC "
            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)

            'For Each row As DataRow In TABLA.Rows


            '    Dim id As String = TABLA.Rows(0).Item("ID_CLIENTE").ToString()
            '    Dim nombre As String = TABLA.Rows(0).Item("Nombre").ToString()

            'Next




            'liberando memoria
            ADATER.Dispose()
                ADATER = Nothing
            Consulta = Nothing
            SQL_Comman = Nothing
            Return TABLA
            Catch ex As Exception
                'Return ComparaConteos(Grupo, IdInventario)
                MsgBox(ex.Message)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ComparaConteos ( " & ex.Message & " )"
        End Try

            'Try

            '    Dim ADATER As New OdbcDataAdapter
            '    Dim TABLA As New DataTable

            '    Dim Consulta As String = "SELECT `IdInventario`,`Codigo`,`C1`,`C2` FROM `Conteo` WHERE `CodG1`='" & Grupo & "' AND `IdInventario`='" & idInventario & "'"

            '    ADATER = New OdbcDataAdapter(Consulta, MYSQ_Comman.Connection)

            '    ADATER.Fill(TABLA)

            '    'liberando memoria
            '    ADATER.Dispose()
            '    ADATER = Nothing
            '    Consulta = Nothing
            '    Return TABLA
            'Catch ex As Exception

            '    ERRORES = "[ " & Now & " ] ERROR ObtieneIdInventario ( " & ex.Message & " )"
            'End Try
        End Function
    'Comprueba que no se le alla hecho cruce al grupo idicado
    Public Function CompruebaCruce(ByVal Grupo As String, ByVal IdInventario As String)
        Try


            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim ListaProveedores As New DataTable
            Dim Consulta As String
            Dim CodG1 As String
            Dim cuenta As Integer = 0

            Dim retorna As Integer = 0


            Consulta = "SELECT MAX(Conteo) as Conto FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_ConActivo] where Grupo ='" & Grupo & "' and IdInventario ='" & IdInventario & "'"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)

            If TABLA.Rows(0).Item("Conto").ToString() = "" Then

                retorna = 0
            Else
                retorna = CInt(TABLA.Rows(0).Item("Conto").ToString())
            End If


            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            SQL_Comman = Nothing
            Return retorna
        Catch ex As Exception
            MsgBox(ex.Message)

            CompruebaCruce(Grupo, IdInventario)


            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CompruebaCruce ( " & ex.Message & " )"
        End Try

    End Function
    Public Function Corrige(ByVal idInventario As String, SoloDesajustados As Boolean)
        Dim tablas As New DataTable
        Dim Codigo As String = 0
        Dim costo As Double = 0
        Dim Cont As Integer = 0
        Dim D1 As Integer = 0
        Dim D2 As Integer = 0
        Dim D3 As Integer = 0
        Dim D4 As Integer = 0
        Dim D5 As Integer = 0
        Dim D6 As Integer = 0
        Dim D7 As Integer = 0
        Dim D8 As Integer = 0
        Dim Df As Integer = 0

        Dim MD1 As Double = 0
        Dim MD2 As Double = 0
        Dim MD3 As Double = 0
        Dim MD4 As Double = 0
        Dim MD5 As Double = 0
        Dim MD6 As Double = 0
        Dim MD7 As Double = 0
        Dim MD8 As Double = 0
        Dim MDf As Double = 0
        Dim CF As Integer = 0
        tablas = ObtieneInvControl("", "0", "0", "", idInventario, False, SoloDesajustados)
        Class_VariablesGlobales.frmControl.Lbl_Inicio.Text = "0"
        Class_VariablesGlobales.frmControl.Lbl_Fin.Text = tablas.Rows.Count
        Class_VariablesGlobales.frmControl.ProgBar.Value = 0
        Class_VariablesGlobales.frmControl.ProgBar.Maximum = tablas.Rows.Count

        Class_VariablesGlobales.Contador = 0
        For Each row As DataRow In tablas.Rows

            Codigo = tablas.Rows(Cont).Item("Codigo").ToString()
            costo = CDbl(tablas.Rows(Cont).Item("costo").ToString())

            D1 = CInt(tablas.Rows(Cont).Item("CF").ToString()) - CInt(tablas.Rows(Cont).Item("Stock").ToString())
            MD1 = costo * D1


            If D1 <> 0 Then
                Df = D1
                MDf = MD1
                CF = CInt(tablas.Rows(Cont).Item("CF").ToString())
            End If

            ActualizaDiferencias(idInventario, Codigo, MDf, CF, Df)
            '`Codigo`,`Descripcion`,`CodBarras`,`Sector`,`Costo`,`Stock_b1`,`C1`,`D1`,`MD1`,`C2`,`D2`,`MD2`,`C3`,`D3`,`MD3`,`C4`,`D4`,`MD4`,`C5`,`D5`,`MD5`,`C6`,`D6`,`MD6`,`C7`,`D7`,`MD7`,`C8`,`D8`,`MD8`,`CF`,`DF`,`DFM`,`CodProveedor`,`NameProveedor`,`Familia`,`Marca`,`Categoria`,`Stock_b3`,`Stock_b4`,`Stock_b5`,`Stock_b6`,`CodG1`,`Monto_B1` 
            Class_VariablesGlobales.DetalleCarga = tablas.Rows(Cont).Item("Codigo").ToString()
            Class_VariablesGlobales.Contador += 1
            Cont += 1
        Next

    End Function
    Public Function ActualizaDiferencias(ByVal IdInventario As String, ByVal Codigo As String, ByVal MDF As Double, ByVal CF As Integer, ByVal DF As Integer)
            Try

            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            ' Dim Consulta As String = "UPDATE  `Conteo` SET `D1`= '" & D1 & "',`D2`= '" & D2 & "',`D3`= '" & D3 & "',`D4`= '" & D4 & "',`D5`= '" & D5 & "',`D6`= '" & D6 & "' ,`D7`= " & D7 & ",`D8`= " & D8 & ",`DF`= " & DF & ",`MD1`= " & MD1 & ",`MD2`= " & MD2 & ",`MD3`= " & MD3 & ",`MD4`= " & MD4 & ",`MD5`= " & MD5 & ",`MD6`= " & MD6 & ",`MD7`= " & MD7 & ",`MD8`= " & MD8 & ",`DFM`= " & MDF & ",`costo`= " & costo & " ,`CF`= " & CF & " WHERE `IdInventario`='" & IdInventario & "' AND `Codigo`='" & Codigo & "'"


            Dim Consulta As String = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Inventario] SET [CF]='" & CF & "',[DF]='" & DF & "',[DFM]='" & MDF & "' WHERE [IdInventario]='" & IdInventario & "' AND [Codigo]='" & Codigo & "'"
            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            Consulta = Nothing
            SQL_Comman = Nothing
        Catch ex As Exception
                ActualizaDiferencias(IdInventario, Codigo, MDF, CF, DF)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ActualizaDiferencias ( " & ex.Message & " )"
        End Try
        End Function
        Public Function ObtieneInventarios()
            Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable

            Dim Consulta As String = "SELECT  id,Fecha,Titulo,Comentario,Cerrado,InvInicial,InvFinal,ENTRADAS,SALIDAS,DIFERENCIAS FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Registro] ORDER BY id desc "

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)
                'liberando memoria
                ADATER.Dispose()
                ADATER = Nothing
            Consulta = Nothing
            SQL_Comman = Nothing
            Return TABLA
            Catch ex As Exception
                Return ObtieneInventarios()
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ObtieneInventarios ( " & ex.Message & " )"
        End Try
        End Function
    Public Function ObtieneConteosActivosGrupos(IdInventario As String)
        Try

            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String

            Consulta = "SELECT * FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_ConActivo] WHERE IdInventario='" & IdInventario & "' order by 1,2 ASC "

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            SQL_Comman = Nothing
            Return TABLA
        Catch ex As Exception

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ObtieneConteosActivosGrupos ( " & ex.Message & " )"
        End Try
    End Function
    Public Function GruposConteo(CodInventario As String, OrdenaXGrupo As Boolean)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String

            'Muestra todos los grupos
            If Class_VariablesGlobales.ListaGruposLlamadoDesde = "AdminGrupos" Or Class_VariablesGlobales.ListaGruposLlamadoDesde = "Inv_ConteosRealizados" Then
                If OrdenaXGrupo = True Then
                    Consulta = "SELECT  [idGrupo], [Responsable], [Acompanante] , [CodInventario],[CodProveedor],[NombreProveedor] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] WHERE [CodInventario]='" & CodInventario & "' GROUP BY [idGrupo], [Responsable], [Acompanante] , [CodInventario],[CodProveedor],[NombreProveedor]"
                Else
                    Consulta = "SELECT  [CodProveedor],[NombreProveedor],[idGrupo], [Responsable], [Acompanante] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] WHERE [CodInventario]='" & CodInventario & "' GROUP BY [CodProveedor],[NombreProveedor],[idGrupo], [Responsable], [Acompanante] , [CodInventario]"
                End If
            End If

            'Muestra solo los grupos que no han sido cruzados
            If Class_VariablesGlobales.ListaGruposLlamadoDesde = "Inv_Cruzar1" Then
                Consulta = " select  [idGrupo]
                            , (select TOP 1 T00.[Responsable] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] T00 WHERE T00.[idGrupo] = T0.[idGrupo]) AS [Responsable]
                            , (select TOP 1 T00.[Acompanante] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] T00 WHERE T00.[idGrupo] = T0.[idGrupo] ) AS [Acompanante]   
                            , (select TOP 1 T00.[CodInventario] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] T00 WHERE T00.[idGrupo] = T0.[idGrupo]) AS [CodInventario]
                            , (select TOP 1 T00.[CodProveedor] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] T00 WHERE T00.[idGrupo] = T0.[idGrupo])  AS [CodProveedor]
                            , (select TOP 1 T00.[NombreProveedor] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] T00 WHERE T00.[idGrupo] = T0.[idGrupo]) AS [NombreProveedor] 
                             FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] T0 
                            LEFT JOIN [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[inv_conactivo]  T1
                            ON T0.[idGrupo] = T1.[Grupo]
                            WHERE T1.Conteo <3 AND [CodInventario] ='" & CodInventario & "' GROUP BY  [idGrupo]
                            "
            End If
            'Muestra los grupos que ya han sido cruzados y estan en espera de cruce contra sistema
            If Class_VariablesGlobales.ListaGruposLlamadoDesde = "Inv_Cruzar2" Then
                Consulta = " select  [idGrupo]
                            , (select TOP 1 T00.[Responsable] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] T00 WHERE T00.[idGrupo] = T0.[idGrupo]) AS [Responsable]
                            , (select TOP 1 T00.[Acompanante] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] T00 WHERE T00.[idGrupo] = T0.[idGrupo] ) AS [Acompanante]   
                            , (select TOP 1 T00.[CodInventario] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] T00 WHERE T00.[idGrupo] = T0.[idGrupo]) AS [CodInventario]
                            , (select TOP 1 T00.[CodProveedor] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] T00 WHERE T00.[idGrupo] = T0.[idGrupo])  AS [CodProveedor]
                            , (select TOP 1 T00.[NombreProveedor] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] T00 WHERE T00.[idGrupo] = T0.[idGrupo]) AS [NombreProveedor] 
                            FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] T0 
                            LEFT JOIN [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[inv_conactivo]  T1
                            ON T0.[idGrupo] = T1.[Grupo]
                            WHERE T1.Conteo >3 and [CodInventario] ='" & CodInventario & "' GROUP BY  [idGrupo]
                            "
            End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            SQL_Comman = Nothing
            Return TABLA
        Catch ex As Exception

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR GruposConteo ( " & ex.Message & " )"
        End Try
    End Function
    Public Function OptieneCasaXGRupo(ByVal idGrupo As String, ByVal CodInventario As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String

            Consulta = "SELECT  [CodProveedor], [NombreProveedor] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] WHERE [idGrupo]='" & idGrupo & "' and [CodInventario]='" & CodInventario & "'"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            SQL_Comman = Nothing
            Return TABLA
        Catch ex As Exception

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR OptieneCasaXGRupo ( " & ex.Message & " )"
        End Try
    End Function
    Public Function TieneConteos(ByVal idGrupo As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()
            Dim CONTO As String
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String
            'Consulta la cuenta mas alta de todas las lineas si solo sale en 0 es por que no han contado nada
            Consulta = "SELECT MAX([Cuenta]) AS conto FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[inv_conteos] WHERE [Grupo]='" & idGrupo & "' GROUP BY [Grupo]"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)


            If TABLA.Rows.Count > 0 Then
                CONTO = TABLA.Rows(0).Item("conto").ToString()
            Else
                CONTO = "0"

            End If
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            SQL_Comman = Nothing
            Return CONTO
        Catch ex As Exception

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR TieneConteos ( " & ex.Message & " )"
        End Try
    End Function

    Public Function ObtieneConteoRealizado(IdInventario As String, Grupo As String, Conteo As String, Proveedor As String, Codigo As String, Descripcion As String)
        Try
            'Obtiene el inventario junto a todos los conteos hechos
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter

            Dim TABLA As New DataTable
            Dim Consulta As String
            Consulta = "SELECT [CodProveedor],[CodArticulo],[Descripcion],[Cuenta],[Apuntes] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[inv_conteos] WHERE "
            If IdInventario <> "" Then
                Consulta = Consulta & " [IdInventario]='" & IdInventario & "' "
            End If
            If Grupo <> "" Then
                Consulta = Consulta & " AND [Grupo]='" & Grupo & "' "
            End If
            If Conteo <> "" Then
                Consulta = Consulta & " AND [NumConteo]='" & Conteo & "' "
            End If
            If Proveedor <> "" Then
                Consulta = Consulta & " AND Descripcion like '%" & Descripcion & "%'"
            End If

            If Proveedor <> "" Then
                Consulta = Consulta & " AND CodProveedor='" & Proveedor & "' and Descripcion like '%" & IdInventario & "%'"
            End If
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)
            SQL_Comman = Nothing
            Return TABLA
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing

        Catch ex As Exception


            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ObtieneConteoRealizado ( " & ex.Message & " )"
        End Try
    End Function

    Public Function Obtiene_DatosPlantilla(ByVal Proveedor As String, ByVal Df_Mayores As Integer, ByVal Df_Menores As Integer, ByVal Busqueda As String, ByVal IdInventario As String, ByVal detallado As Boolean, Ver As String)
        Try
            'Obtiene el inventario junto a todos los conteos hechos
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter

            Dim TABLA As New DataTable
            Dim Consulta As String
            'Número de artículo,Descripción del artículo,Almacén,	Cantidad en almacén en fecha de recuento,	Cantidad de unidad de medida contada,	Cantidad contada,	Desviación	% desviación,	Precio,	Total	Compensación de stocks - Cuenta de aumento	Compensación de stocks - Cuenta de reducción	Código de unidad de medida	Artículos por unidad

            Consulta = "SELECT T0.Codigo,'' as Descripcion,'01' as Almacen,'' as [Cantidad en almacén en fecha de recuento],'' as [Cantidad de unidad de medida contada], T0.CF,'' as [Desviación],'' as [% desviación], T0.Costo,'' as [Total], '50100102001' as [Cuenta de aumento],'50100102002' as [Cuenta de reducción],'' as [Código de unidad de medida],'' as [Artículos por unidad]"

            Consulta = Consulta & " FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Inventario] T0 "
            Consulta = Consulta & " where IdInventario='" & IdInventario & "'and T0.DF <> 0"
            Consulta = Consulta & " ORDER BY T0.NumLinea ASC"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)
            SQL_Comman = Nothing
            Return TABLA
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing

        Catch ex As Exception

            Return ObtieneInvControl(Proveedor, Df_Mayores, Df_Menores, Busqueda, IdInventario, detallado, Ver)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR Obtiene_DatosPlantilla ( " & ex.Message & " )"
        End Try
    End Function
    Public Function ObtieneInvControl(ByVal Proveedor As String, ByVal Df_Mayores As Integer, ByVal Df_Menores As Integer, ByVal Busqueda As String, ByVal IdInventario As String, ByVal detallado As Boolean, Ver As String)
        Try
            'Obtiene el inventario junto a todos los conteos hechos
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter

            Dim TABLA As New DataTable
            Dim Consulta As String
            Consulta = "SELECT T0.NumLinea '#'  ,T0.IdInventario,T0.CodProveedor,T0.NameProveedor,T0.Fecha,T0.Codigo,T0.Descripcion,T0.CodBarras,T0.Sector,T0.Costo,T0.Stock,T0.CF,T0.DF,T0.DFM,T0.Monto"
            If detallado = True Then


                'Obtiene el conteo max realizado
                Dim ContMAx As Integer = ObtieneMaxConteoHecho(IdInventario)
                Dim recorre As Integer = 1
                Dim Prueba As Integer = 0
                If ContMAx > 0 Then
                    Consulta = Consulta & ","
                End If
                While recorre <= ContMAx
                    Consulta = Consulta & "(CASE WHEN (SELECT   SUM(Cuenta) as Cuenta  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Conteos] WHERE CodArticulo=T0.Codigo AND  [IdInventario]='" & IdInventario & "' and [NumConteo]='" & recorre & "' GROUP BY CodArticulo,NumConteo) IS NULL THEN 0 ELSE (SELECT   SUM(Cuenta) as Cuenta  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Conteos] WHERE CodArticulo=T0.Codigo AND  [IdInventario]='" & IdInventario & "' and [NumConteo]='" & recorre & "' GROUP BY CodArticulo,NumConteo) END)as C" & recorre & "," &
                                "((CASE WHEN (SELECT   SUM(Cuenta) as Cuenta  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Conteos] WHERE CodArticulo=T0.Codigo AND  [IdInventario]='" & IdInventario & "' and [NumConteo]='" & recorre & "' GROUP BY CodArticulo,NumConteo) IS NULL THEN 0 ELSE (SELECT   SUM(Cuenta) as Cuenta  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Conteos] WHERE CodArticulo=T0.Codigo AND  [IdInventario]='" & IdInventario & "' and [NumConteo]='" & recorre & "' GROUP BY CodArticulo,NumConteo) END) - T0.Stock) AS DF" & recorre & "," &
                                "(((CASE WHEN (SELECT   SUM(Cuenta) as Cuenta  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Conteos] WHERE CodArticulo=T0.Codigo AND  [IdInventario]='" & IdInventario & "' and [NumConteo]='" & recorre & "' GROUP BY CodArticulo,NumConteo) IS NULL THEN 0 ELSE (SELECT   SUM(Cuenta) as Cuenta  FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Conteos] WHERE CodArticulo=T0.Codigo AND  [IdInventario]='" & IdInventario & "' and [NumConteo]='" & recorre & "' GROUP BY CodArticulo,NumConteo) END) - T0.Stock) *T0.Costo) AS MD" & recorre

                    Prueba = recorre
                    If Prueba + 1 <= ContMAx Then
                        Consulta = Consulta & ","
                    End If

                    recorre += 1
                End While
            Else

            End If

            Consulta = Consulta & " FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Inventario] T0 "

            'SI ESTA BUSCANDO CON ALGUN FILTRO ENTRA A GENERAR EL WHERE
            If Proveedor <> "" Or Df_Mayores > 0 Or Df_Menores < 0 Or Busqueda <> "" Or Ver <> "" Then
                Consulta = Consulta & " where IdInventario='" & IdInventario & "'"

                If Proveedor <> "" Then
                    Consulta = Consulta & "  and CodProveedor='" & Proveedor & "' "
                End If
                If Df_Mayores > 0 Or Df_Menores < 0 Then
                    Consulta = Consulta & " AND (DFM > '" & Df_Mayores & "' OR DFM < '" & Df_Menores & "') "
                End If
                If Busqueda <> "" Then
                    Consulta = Consulta & " and [Descripcion] like '%" & Busqueda & "%'"
                End If





                If Ver = "TODO" Then

                ElseIf Ver = "AJUSTADO" Then
                    Consulta = Consulta & " and T0.DF = 0"
                ElseIf Ver = "DESAJUSTADO" Then
                    Consulta = Consulta & " and T0.DF <> 0"
                End If

            End If


            'If Proveedor <> "" Then

            '    If Df_Mayores > 0 Or Df_Menores <0 Then
            '        Consulta = Consulta & " where IdInventario='" & IdInventario & "' and CodProveedor='" & Proveedor & "' AND (DFM > '" & Df_Mayores & "' OR DFM < '" & Df_Menores & "')  "
                       '    Else
                       '        Consulta = Consulta & " where IdInventario='" & IdInventario & "' and CodProveedor='" & Proveedor & "' "
                       '    End If

                       'ElseIf Df_Mayores > 0 Then
                       '    Consulta = Consulta & " where IdInventario='" & IdInventario & "' and  DFM >= '" & Df_Mayores & "' OR DFM <= '" & Df_Menores & "'  "
                       'ElseIf Busqueda <> "" Then
                       '    Consulta = Consulta & " where IdInventario='" & IdInventario & "' and `Descripcion` like '%" & Busqueda & "%'"
                       'Else
                       '    Consulta = Consulta & " where IdInventario='" & IdInventario & "'"
                       'End If


                       Consulta = Consulta & " ORDER BY T0.NumLinea ASC"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)
            SQL_Comman = Nothing
            Return TABLA
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing

        Catch ex As Exception

            Return ObtieneInvControl(Proveedor, Df_Mayores, Df_Menores, Busqueda, IdInventario, detallado, Ver)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ObtieneInvControl ( " & ex.Message & " )"
        End Try
    End Function
    Public Function DetConteo(ByVal IdInventario As String, ByVal CodArticulo As String)
            Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter

            Dim TABLA As New DataTable
                Dim Consulta As String

            Consulta = "SELECT T0.Grupo,T0.NumConteo,T0.Cuenta,T0.CodArticulo,(SELECT [Descripcion] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Inventario] WHERE [Codigo]=T0.CodArticulo AND IdInventario='" & IdInventario & "') as Nombre,(SELECT [Stock] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Inventario] WHERE [Codigo]=T0.CodArticulo  AND IdInventario='" & IdInventario & "') as Stock FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Conteos] T0 where T0.CodArticulo='" & CodArticulo & "' and T0.IdInventario='" & IdInventario & "' order by T0.Grupo"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)
            SQL_Comman = Nothing
            Return TABLA
                'liberando memoria
                ADATER.Dispose()
                ADATER = Nothing
                Consulta = Nothing
            Catch ex As Exception
                Return DetConteo(IdInventario, CodArticulo)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR DetConteo ( " & ex.Message & " )"
        End Try
        End Function
        Public Function ObtieneMaxConteoHecho(ByVal IdInventario As String)
        Try
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String

            Consulta = "SELECT  max([NumConteo]) as NumConteos FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Conteos] WHERE [IdInventario]='" & IdInventario & "'"

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing


            Dim MAX As Integer
            If TABLA.Rows(0).Item("NumConteos").ToString() = "" Then
                MAX = 0
            Else
                MAX = TABLA.Rows(0).Item("NumConteos").ToString()
            End If
            SQL_Comman = Nothing
            Return MAX
        Catch ex As Exception

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ObtieneMaxConteoHecho ( " & ex.Message & " )"
        End Try
        End Function
        Public Function ActualizaMontDifConte(ByVal IdInventario As String, ByVal Codigo As String, ByVal CF As String, ByVal DF As String, ByVal DFM As Double)

            Try

                Dim Consulta As String
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Consulta = "UPDATE [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Inventario] SET [CF]='" & CF & "',[DF]='" & DF & "',[DFM]='" & DFM & "' WHERE [IdInventario]='" & IdInventario & "' and [Codigo]='" & Codigo & "'"


            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()
            Desconectar(SQL_Comman, SQL_Comman.Connection)
            Consulta = Nothing
            SQL_Comman = Nothing




        Catch ex As Exception

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ActualizaMontDifConte ( " & ex.Message & " )"
        End Try
        End Function
        Public Function CierraInventario(ByVal IdInventario As String, ByVal Entradas As Double, ByVal Salidas As Double, ByVal Diferencias As Double, ByVal InvFinal As Double)
        Try

            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim Consulta As String = ""
            Consulta = "UPDATE  [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Inventario] SET [Cerrado]= '1'  WHERE [IdInventario]='" & IdInventario & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()

            Consulta = "UPDATE  [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Registro] SET [Cerrado]= '1',[InvFinal]=" & InvFinal & ",[ENTRADAS]=" & Entradas & ",[SALIDAS]=" & Salidas & ",[DIFERENCIAS]=" & Diferencias & "  WHERE [Id]='" & IdInventario & "'"

            SQL_Comman.CommandText = Consulta
            SQL_Comman.ExecuteNonQuery()

            'Consulta = "UPDATE  [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Conteo] SET [Cerrado]= '1'  WHERE [IdInventario]='" & IdInventario & "'"
            'SQL_Comman.CommandText = Consulta
            'SQL_Comman.ExecuteNonQuery()
            SQL_Comman = Nothing
            Consulta = Nothing
        Catch ex As Exception
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CierraInventario ( " & ex.Message & " )"
        End Try
        End Function
        Public Function ObtieneInvConteo(ByVal ConteoActivo As String, ByVal CodInventario As String, ByVal Grupo As String)
            Try

            'Obtiene solo los conteos realizados en el conteo a cruzar y que esta activo del grupo indicado
            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim ListaProveedores As New DataTable
            Dim Consulta As String
            Dim CodG1 As String
            Dim cuenta As Integer = 0
            'Obtiene los proveedores asinganados al grupo
            ListaProveedores = ObtieneListaProveedores(Grupo, CodInventario)

            Consulta = "SELECT T0.CF as Conteo,T0.Stock,T0.Codigo,T0.Costo,T0.CodProveedor,T0.Descripcion FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Inventario] T0 WHERE T0.IdInventario='" & CodInventario & "' AND ("

            'Consulta = "SELECT `" & ConteoActivo & "`, `Stock_b1`, `Codigo`, `Costo`  FROM `Conteo` WHERE `IdInventario`=" & CodInventario & " and ("
            'recorre la lista de proveedores para generar la formula
            If ListaProveedores.Rows.Count > 0 Then
                    For Each row As DataRow In ListaProveedores.Rows
                        Consulta = Consulta & "T0.CodProveedor='" & ListaProveedores.Rows(cuenta).Item("CodProveedor").ToString() & "'"
                        Try
                            If ListaProveedores.Rows(cuenta + 1).Item("CodProveedor").ToString() <> "" Then
                                Consulta = Consulta & " or "
                            End If
                        Catch ex As Exception

                        End Try

                        cuenta += 1
                    Next
                    Consulta = Consulta & ")"
                End If

            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            SQL_Comman = Nothing
            Return TABLA
            Catch ex As Exception

                Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ObtieneIdInventario ( " & ex.Message & " )"
            End Try
        End Function
    Public Function ObtieneListaProveedores(ByVal Grupo As String, ByVal CodInventario As String)
        Try

            Dim SQL_Comman As New SqlCommand
            SQL_Comman = Conectar()

            Dim CodG As String
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String
            Dim CodG1 As String
            Dim Proveedores(10) As String
            Dim contproveedor As Integer = 0
            'verifica o obtiene el codgrupo donde quedo guardado el grupo


            Consulta = "SELECT [CodProveedor] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Grupos] where [idGrupo]='" & Grupo & "' and [CodInventario]='" & CodInventario & "'"


            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)

            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            SQL_Comman = Nothing
            Return TABLA
        Catch ex As Exception
            MsgBox("Error ObtieneListaProveedores " & ex.Message)

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ObtieneListaProveedores ( " & ex.Message & " )"
        End Try
    End Function
    Public Function VerificaInventarioAbiertos()

            Try
            Dim TABLA As New DataTable
            Dim SQL_Comman As SqlCommand


            SQL_Comman = Conectar()

            Dim CodG As String
            Dim ADATER As New SqlDataAdapter

            Dim Consulta As String
                Dim CodG1 As String
                Dim Proveedores(10) As String
                Dim contproveedor As Integer = 0
            'verifica o obtiene el codgrupo donde quedo guardado el grupo
            Consulta = "SELECT count([IdInventario]) as Conto FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Inv_Inventario] where Cerrado='0' group by [IdInventario]"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)

            ADATER.Fill(TABLA)
                Dim cuenta As Integer = 0
                Dim Conto As Integer = 0

                For Each row As DataRow In TABLA.Rows
                    If CInt(TABLA.Rows(cuenta).Item("Conto").ToString()) > 1 Then
                        Conto = 1
                    Else
                        Conto = 0
                    End If

                    cuenta += 1
                Next
                'liberando memoria
                ADATER.Dispose()
                ADATER = Nothing
            Consulta = Nothing
            SQL_Comman = Nothing
            Return Conto
            Catch ex As Exception

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR VerificaInventarioAbiertos ( " & ex.Message & " )"
        End Try

        End Function
        Public Function SubeInveConteo(ByVal Titulo As String, ByVal comentarioa As String)
            Try
                Dim retorna As Integer = 0
                Dim cont As Integer = 0
                Dim Consulta As String
            Dim SQL_Comman As New SqlCommand
            Dim TABLA As New DataTable

            SQL_Comman = Conectar()


            If VerificaInventarioAbiertos() = 1 Then

                    MsgBox("Verifique que todos los inventarios viejos esten cerrados antes de generar uno nuevo")
                    retorna = 1
                Else


                    'Guarda el registro del inventario lo cual crea un ID unico del inventario que se esta realizando , el cual se le asignara a cada linea
                    CreaRegConteos(Titulo, comentarioa)
                    'obtien el id del inventario hecho
                    Class_VariablesGlobales.idInventario = ObtieneIdInventario()


                    'obtiene las lineas del inventario a contar
                    TABLA = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaInvConteo(Class_VariablesGlobales.SQL_Comman2)

                    Class_VariablesGlobales.TotalLineas = TABLA.Rows.Count
                Inv_NuevoConteo.Lbl_Fin.Text = TABLA.Rows.Count
                Inv_NuevoConteo.ProgBar.Maximum = TABLA.Rows.Count
                Inv_NuevoConteo.ProgBar.Value = 0
                Inv_NuevoConteo.Lbl_Inicio.Text = "0"

                Dim COTADOR As Integer
                    Dim InventarioInicial As Double
                    If TABLA.Rows.Count > 0 Then

                        For Each row As DataRow In TABLA.Rows
                            Consulta = ""

                            'solo verifica que este conectado
                            Try

                            If SQL_Comman.Connection.State = ConnectionState.Closed Then
                                SQL_Comman = Conectar()
                            End If


                            Dim Sector As String = ""


                                If TABLA.Rows(COTADOR).Item("Sector").ToString() = "" Then
                                    Sector = "0"
                                Else
                                    Sector = TABLA.Rows(COTADOR).Item("Sector").ToString()
                                End If
                            Dim Pack As String = ""
                            If TABLA.Rows(COTADOR).Item("Empaque").ToString() = "" Then
                                Pack = "0"
                            Else
                                Pack = TABLA.Rows(COTADOR).Item("Empaque").ToString()
                            End If
                            Consulta = "INSERT INTO [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[inv_inventario]
                                       ([Fecha]
                                       ,[IdInventario]
                                       ,[Codigo]
                                       ,[Descripcion]
                                       ,[CodBarras]
                                       ,[Sector]
                                       ,[Costo]
                                       ,[CodProveedor]     
                                       ,[NameProveedor]
                                       ,[Stock]
                                       ,[Monto]
                                       ,[Reconteo]
                                       ,[CF]
                                       ,[DF]
                                       ,[DFM]
                                       ,[Pack]
                                       ,[NumLinea]
                                       ) VALUES " &
                                       "('" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Now.Date) &
                                       "','" & Class_VariablesGlobales.idInventario &
                                       "','" & TABLA.Rows(COTADOR).Item("ItemCode").ToString() &
                                       "','" & TABLA.Rows(COTADOR).Item("ItemName").ToString() &
                                       "','" & TABLA.Rows(COTADOR).Item("CodeBars").ToString() &
                                       "','" & CInt(Sector) &
                                       "','" & TABLA.Rows(COTADOR).Item("Price").ToString() &
                                       "','" & TABLA.Rows(COTADOR).Item("CodProveedor").ToString() &
                                       "','" & TABLA.Rows(COTADOR).Item("NameProveedor").ToString() &
                                       "','" & CInt(TABLA.Rows(COTADOR).Item("Stock_B1").ToString()) &
                                       "','" & TABLA.Rows(COTADOR).Item("Monto_B1").ToString() &
                                       "','0" &
                                       "','0" &
                                       "','" & 0 - CInt(TABLA.Rows(COTADOR).Item("Stock_B1").ToString()) &
                                       "','" & -(CInt(TABLA.Rows(COTADOR).Item("Stock_B1").ToString()) * CDbl(TABLA.Rows(COTADOR).Item("Price").ToString())) &
                                       "','" & CInt(Pack) &
                                       "','" & CInt(COTADOR) & "')"


                            InventarioInicial += CDbl(TABLA.Rows(COTADOR).Item("Monto_B1").ToString())

                                Class_VariablesGlobales.DetalleCarga = "Subiendo : " & TABLA.Rows(COTADOR).Item("ItemName").ToString()
                            SQL_Comman.CommandText = Consulta
                            SQL_Comman.ExecuteNonQuery()
                            Class_VariablesGlobales.Contador += 1

                                COTADOR += 1
                            Catch ex As Exception
                            MsgBox("ERROR en SubeInveConteo: " & ex.Message)
                            SQL_Comman.CommandText = Consulta
                            SQL_Comman.ExecuteNonQuery()
                            Class_VariablesGlobales.Contador += 1

                            COTADOR += 1
                            End Try

                        Next
                    End If

                    'Obj_MYSQL.Desconectar()
                    ActualizaRegConteos(Class_VariablesGlobales.idInventario, InventarioInicial)
                    'inicio libera memoria
                    'MYSQ_Comman = Nothing
                    cont = Nothing
                    TABLA = Nothing
                'MYSQ_Comman.Connection = Nothing
                Consulta = Nothing
                SQL_Comman = Nothing
            End If

                Return retorna
            Catch ex As Exception

                Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR Insertar_Articulos( " & ex.Message & " )"
            End Try
        End Function


    Public Function ObtieneArticulosInternos(ByVal TipoProducto As String, ByVal CardCode As String, ByVal Palabra As String, ByVal VerDesc As Boolean, ByVal ColumnaBusqueda As Integer, ByVal SQL_Comman As SqlCommand)
        Try
            Dim ADATER As New SqlDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String = ""
            Dim entro As Boolean = False
            Dim restriccion As String = ""
            ' T0.[ItemCode] as 'Cod Arti',	T0.[ItemName], T0.[frozenFor] as 'Bloqueado',T0.[CodeBars] as 'Cod Bar', T1.[Price] ,T0.[SuppcatNum] as Alterno, T0.[U_Impuesto] 
            Consulta = "SELECT 
            [ItemCode]
           ,[Descripcion]
           ,[NombreExtrangero]
           ,[GrupoArticulo]
           ,[Ubicacion]
           ,[CodCabys]
           ,[InactivoDesde]
           ,[CodBarras]
           ,[Precio]           
           ,[CodAlterno]
           ,[Tarifa]
           ,[CodProveedor]
           ,[Comentarios]
           ,[Empaque]         
           ,[RazonInactivo]
           ,[UnidMedida]
           ,[Largo]
           ,[Anchos]
           ,[Volumen]
           ,[TipoProducto]
           ,[ListPreci]
           ,[Familia]
           ,[Categoria]
           ,[Marca] 
           ,[SujetoAImpuesto]
           ,[Cod_tarifa] 
           ,[CreadoEnSap]
           ,[IdLineaNuevaWms]
           ,[Id] FROM [" & Trim(Class_VariablesGlobales.XMLParamSQL_dababase) & "].[dbo].[Articulos] "
            If TipoProducto = "*" Then


            Else
                entro = True
                Consulta = Consulta & "WHERE TipoProducto ='" & TipoProducto & "'"
            End If

            If Palabra <> "" Then


                If ColumnaBusqueda = 0 Then 'busca por codigo

                    If entro = True Then
                        Consulta = Consulta & " and"
                    Else
                        Consulta = Consulta & "WHERE "
                    End If

                    Consulta = Consulta & " [ItemCode] like'%" & Palabra & "%'"
                    entro = True
                ElseIf ColumnaBusqueda = 1 Then 'busca por nombre

                    If entro = True Then
                        Consulta = Consulta & " and"
                    Else
                        Consulta = Consulta & "WHERE "
                    End If
                    Consulta = Consulta & " [Descripcion] like'%" & Palabra & "%'"
                    entro = True
                End If
            End If

            Consulta = Consulta & "ORDER BY [Id] DESC"
            ADATER = New SqlDataAdapter(Consulta, SQL_Comman.Connection)
            ADATER.Fill(TABLA)
            Return TABLA
        Catch ex As Exception
            MessageBox.Show("ERROR en ObtieneArticulosInternos [ " & ex.Message & " ]")
        End Try
    End Function
#End Region


End Class
