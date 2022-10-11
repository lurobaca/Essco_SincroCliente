Imports System.IO ' esta a al principio de todo nuestro codigo
Imports System.Data.SqlClient
Public Class CrearArchivo

    Dim Obj_SQL_CONEXIONSERVER As New Class_funcionesSQL
    Public ConsecutivoNuevo As String
    Public Obj_FechaM As New FechaManager
    Public Obj_VGlobal As New Class_VariablesGlobales
    Public Obj_VSegLic As New SeguridadLicencia

 

#Region "SELLER"
    Public Function Crear_in_ParamSeller(ByVal TABLA As DataTable, ByVal RutaOrigen As String, ByVal carpeta As String)
        Try
    
            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
            Dim PathArchivo As String
            Dim i As Integer

            Dim cont As Integer = 0
            Dim Linea As String = ""



            Const quote As String = """"



            If Directory.Exists(carpeta) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(carpeta)
            End If

            Cursor.Current = Cursors.WaitCursor
            PathArchivo = RutaOrigen ' Se determina el nombre del archivo 

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            Dim CodAgente As String
            Dim Nombre As String
            Dim Telefono As String
            Dim Conse_Pedido As String
            Dim Conse_Pagos As String
            Dim Conse_Deposito As String
            Dim Conse_Gastos As String
            Dim Conse_NoVisita As String
            Dim Conse_Devoluciones As String
            Dim Correo As String
            Dim Cedula As String
            Dim Nombre_Empresa As String
            Dim Telefono_Empresa As String
            Dim Correo_Empresa As String
            Dim Web_Empresa As String
            Dim Direccion_Empresa As String
            Dim Server_Ftp As String
            Dim User_Ftp As String
            Dim Clave_Ftp As String
            Dim NumMaxFactura As String
            Dim DescMax As String
            Dim CedulaAgente As String
            Dim Conse_ClientesNuevos As String
            Dim Puesto As String
            Dim RutaPadre_Ftp As String
            Dim Server_SQL As String
            Dim User_SQL As String
            Dim Clave_SQL As String

            For Each row As DataRow In TABLA.Rows

                CodAgente = (TABLA.Rows(cont).Item("CodAgente").ToString())
                Nombre = TABLA.Rows(cont).Item("Nombre").ToString()
                Telefono = TABLA.Rows(cont).Item("Telefono").ToString()
                Conse_Pedido = TABLA.Rows(cont).Item("Conse_Pedido").ToString()
                Conse_Pagos = TABLA.Rows(cont).Item("Conse_Pagos").ToString()
                Conse_Deposito = TABLA.Rows(cont).Item("Conse_Deposito").ToString()
                Conse_Gastos = TABLA.Rows(cont).Item("Conse_Gastos").ToString()
                Conse_NoVisita = TABLA.Rows(cont).Item("Conse_NoVisita").ToString()
                Conse_Devoluciones = TABLA.Rows(cont).Item("Conse_Devoluciones").ToString()
                Correo = TABLA.Rows(cont).Item("Correo").ToString()
                Cedula = TABLA.Rows(cont).Item("Cedula").ToString()
                Nombre_Empresa = TABLA.Rows(cont).Item("Nombre_Empresa").ToString()
                Telefono_Empresa = TABLA.Rows(cont).Item("Telefono_Empresa").ToString()
                Correo_Empresa = TABLA.Rows(cont).Item("Correo_Empresa").ToString()
                Web_Empresa = TABLA.Rows(cont).Item("Web_Empresa").ToString()
                Direccion_Empresa = TABLA.Rows(cont).Item("Direccion_Empresa").ToString()
                Server_Ftp = TABLA.Rows(cont).Item("Server_Ftp").ToString()
                User_Ftp = TABLA.Rows(cont).Item("User_Ftp").ToString()
                Clave_Ftp = TABLA.Rows(cont).Item("Clave_Ftp").ToString()
                NumMaxFactura = TABLA.Rows(cont).Item("NumMaxFactura").ToString()
                DescMax = TABLA.Rows(cont).Item("DescMax").ToString()
                CedulaAgente = TABLA.Rows(cont).Item("CedulaAgente").ToString()
                Conse_ClientesNuevos = TABLA.Rows(cont).Item("Conse_ClientesNuevos").ToString()
                Puesto = TABLA.Rows(cont).Item("Puesto").ToString()
                RutaPadre_Ftp = TABLA.Rows(cont).Item("RutaPadre_Ftp").ToString()

                Server_SQL = TABLA.Rows(cont).Item("IPServidor").ToString()
                User_SQL = TABLA.Rows(cont).Item("UserSQL").ToString()
                Clave_SQL = TABLA.Rows(cont).Item("ClaveSQL").ToString()


                '  Linea = "" + quote + CardCode + quote + "," & quote & CardName & quote & "," & quote & CntctPrsn & quote & "," & quote & GroupNum & quote & "," & quote & U_Visita & quote & "," & quote & U_Descuento & quote & "," & quote & U_ClaveWeb & quote & "," & quote & SlpCode & quote
                'Linea = TABLA.Rows(cont).Item("id_agente").ToString() & "," & CInt(TABLA.Rows(cont).Item("Ulti_Consec_Pedidos").ToString()) & "," & TABLA.Rows(cont).Item("Ulti_Consec_Pagos").ToString() & "," & TABLA.Rows(cont).Item("Ulti_Consec_Depositos").ToString() & ",bourneycia.net,arquitect,tbh573,3-101-200575,Bourne&Cia S.A,Costa Rica,Guanacaste,Cañas,Frente a la escuela de sandillal,2669-6094"
                Linea = CodAgente & "," & Nombre & "," & Telefono & "," & Conse_Pedido & "," & Conse_Pagos & "," & Conse_Deposito & "," & Correo & "," & Cedula & "," & Nombre_Empresa & "," & Telefono_Empresa & "," & Correo_Empresa & "," & Web_Empresa & "," & Direccion_Empresa & "," & Server_Ftp & "," & User_Ftp & "," & Clave_Ftp & "," & NumMaxFactura & "," & DescMax & "," & CedulaAgente & "," & Conse_Gastos & "," & Conse_NoVisita & "," & Conse_Devoluciones & "," & Obj_VSegLic.Encripta(Obj_VGlobal.MisPropiedades.Valida) & "," & DescMax & "," & Conse_ClientesNuevos & "," & Puesto & "," & RutaPadre_Ftp & "," & Server_SQL & "," & User_SQL & "," & Clave_SQL & ","

                'ESCRIBE LA LINEA EN EL ARCHIVO
                strStreamWriter.WriteLine(Linea)

                Linea = ""
                cont += 1
                'Contador += 1
                ' Contador_sub += 1

            Next


            strStreamWriter.Close() ' cerramos

            'INICIO DE LIBERIACION DE MEMORIA

            sRenglon = Nothing

            strStreamW.Dispose()
            strStreamW = Nothing

            strStreamWriter.Dispose()
            strStreamWriter = Nothing

            ContenidoArchivo = Nothing
            PathArchivo = Nothing
            i = Nothing

            Linea = Nothing


            Linea = Nothing



            'FIN DE LIBERIACION DE MEMORIA


            ' Contador = 0
        Catch ex As Exception
            MsgBox("ERROR Crear_in_ParamSeller [ " & ex.Message & " ]")
        End Try
        Return 0

    End Function
    Public Function Crear_in_RazonesNoVisita(ByVal Tbl_Razones As DataTable, ByVal RutaOrigen As String, ByVal carpeta As String)
        Try
            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            Dim PathArchivo As String
            Dim i As Integer

            Dim cont As Integer = 0
            Dim Linea As String = ""
            'SELECT T0.[CardCode], T0.[CardName], T0.[LicTradNum] as 'Cedula', T0.[CntctPrsn]as 'Responsable_Tributario', T0.[GroupNum] as 'CodCredito', T0.[U_Visita], T0.[U_Descuento] as 'DescuentoMAX', T0.[U_ClaveWeb],T0.[SlpCode],T0.[ListNum] as 'ListaPrecio' FROM  "&  Class_VariablesGlobales.XMLParamSAP_CompanyDB  &".[dbo].[OCRD] T0 WHERE T0.[U_AGENTE1] = @Agente
            Dim Codigo As String = ""
            Dim Razon As String = ""

            If Directory.Exists(carpeta) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(carpeta)
            End If

            Cursor.Current = Cursors.WaitCursor
            PathArchivo = RutaOrigen ' Se determina el nombre del archivo 

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            For Each row As DataRow In Tbl_Razones.Rows
                Codigo = Tbl_Razones.Rows(cont).Item("Codigo").ToString()
                Razon = Tbl_Razones.Rows(cont).Item("Razon").ToString()
                Linea = Codigo + "," & Razon
                strStreamWriter.WriteLine(Linea)
                Linea = ""
                Codigo = ""
                Razon = ""
                cont += 1
            Next
            strStreamWriter.Close() ' cerramos
            sRenglon = Nothing
            strStreamW.Dispose()
            strStreamW = Nothing
            strStreamWriter.Dispose()
            strStreamWriter = Nothing
            ContenidoArchivo = Nothing
            PathArchivo = Nothing
            i = Nothing
            Linea = Nothing
            Linea = Nothing
            Codigo = Nothing
            Razon = Nothing

        Catch ex As Exception
            MsgBox("ERROR Crear_in_ParamSeller [ " & ex.Message & " ]")
        End Try
        Return 0

    End Function
    Public Function Crear_InBancos(ByVal Tbl_Bancos As DataTable, ByVal RutaOrigen As String, ByVal carpeta As String)
        Try
            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            Dim PathArchivo As String
            Dim i As Integer

            Dim cont As Integer = 0
            Dim Linea As String = ""
            'SELECT T0.[CardCode], T0.[CardName], T0.[LicTradNum] as 'Cedula', T0.[CntctPrsn]as 'Responsable_Tributario', T0.[GroupNum] as 'CodCredito', T0.[U_Visita], T0.[U_Descuento] as 'DescuentoMAX', T0.[U_ClaveWeb],T0.[SlpCode],T0.[ListNum] as 'ListaPrecio' FROM  "&  Class_VariablesGlobales.XMLParamSAP_CompanyDB  &".[dbo].[OCRD] T0 WHERE T0.[U_AGENTE1] = @Agente
            Dim BankCode As String = ""
            Dim BankName As String = ""

            If Directory.Exists(carpeta) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(carpeta)
            End If

            Cursor.Current = Cursors.WaitCursor
            PathArchivo = RutaOrigen ' Se determina el nombre del archivo 

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            For Each row As DataRow In Tbl_Bancos.Rows
                BankCode = Tbl_Bancos.Rows(cont).Item("BankCode").ToString()
                BankName = Tbl_Bancos.Rows(cont).Item("BankName").ToString()
                Linea = BankCode + "," & BankName
                strStreamWriter.WriteLine(Linea)
                Linea = ""
                BankCode = ""
                BankName = ""
                cont += 1
            Next

            '  DetalleCarga = "FIN DE GENERANDO ARCHIVO "
            strStreamWriter.Close() ' cerramos
            'INICIO DE LIBERIACION DE MEMORIA
            sRenglon = Nothing
            strStreamW.Dispose()
            strStreamW = Nothing
            strStreamWriter.Dispose()
            strStreamWriter = Nothing
            ContenidoArchivo = Nothing
            PathArchivo = Nothing
            i = Nothing
            Linea = Nothing
            Linea = Nothing
            BankCode = Nothing
            BankName = Nothing

        Catch ex As Exception
            MsgBox("ERROR Crear_in_ParamSeller [ " & ex.Message & " ]")
        End Try
        Return 0

    End Function

    Public Function Crear_InUbicaciones(ByVal Tbl_Ubicaciones As DataTable, ByVal RutaOrigen As String, ByVal carpeta As String)
        Try
            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            Dim PathArchivo As String
            Dim i As Integer

            Dim cont As Integer = 0
            Dim Linea As String = ""
            '[id_provincia],[nombre_provincia],[id_canton],[nombre_canton],[id_distrito],[nombre_distrito],[id_barrio],[nombre_barrio]

            Dim id_provincia As String = ""
            Dim nombre_provincia As String = ""
            Dim id_canton As String = ""
            Dim nombre_canton As String = ""
            Dim id_distrito As String = ""
            Dim nombre_distrito As String = ""
            Dim id_barrio As String = ""
            Dim nombre_barrio As String = ""

            If Directory.Exists(carpeta) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(carpeta)
            End If

            Cursor.Current = Cursors.WaitCursor
            PathArchivo = RutaOrigen ' Se determina el nombre del archivo 

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            For Each row As DataRow In Tbl_Ubicaciones.Rows
                id_provincia = Tbl_Ubicaciones.Rows(cont).Item("id_provincia").ToString()
                nombre_provincia = Tbl_Ubicaciones.Rows(cont).Item("nombre_provincia").ToString()

                id_canton = Tbl_Ubicaciones.Rows(cont).Item("id_canton").ToString()
                nombre_canton = Tbl_Ubicaciones.Rows(cont).Item("nombre_canton").ToString()

                id_distrito = Tbl_Ubicaciones.Rows(cont).Item("id_distrito").ToString()
                nombre_distrito = Tbl_Ubicaciones.Rows(cont).Item("nombre_distrito").ToString()

                id_barrio = Tbl_Ubicaciones.Rows(cont).Item("id_barrio").ToString()
                nombre_barrio = Tbl_Ubicaciones.Rows(cont).Item("nombre_barrio").ToString()

                Linea = id_provincia & "^" & nombre_provincia & "^" & id_canton & "^" & nombre_canton & "^" & id_distrito & "^" & nombre_distrito & "^" & id_barrio & "^" & nombre_barrio
                strStreamWriter.WriteLine(Linea)
                Linea = ""

                id_provincia = ""
                nombre_provincia = ""
                id_canton = ""
                nombre_canton = ""
                id_distrito = ""
                nombre_distrito = ""
                id_barrio = ""
                nombre_barrio = ""

                cont += 1
            Next

            '  DetalleCarga = "FIN DE GENERANDO ARCHIVO "
            strStreamWriter.Close() ' cerramos
            'INICIO DE LIBERIACION DE MEMORIA
            sRenglon = Nothing
            strStreamW.Dispose()
            strStreamW = Nothing
            strStreamWriter.Dispose()
            strStreamWriter = Nothing
            ContenidoArchivo = Nothing
            PathArchivo = Nothing
            i = Nothing
            Linea = Nothing

            id_provincia = Nothing
            nombre_provincia = Nothing
            id_canton = Nothing
            nombre_canton = Nothing
            id_distrito = Nothing
            nombre_distrito = Nothing
            id_barrio = Nothing
            nombre_barrio = Nothing

        Catch ex As Exception

        End Try
        Return 0

    End Function

    Public Function Crear_InDescuentos(ByVal Tbl_Ubicaciones As DataTable, ByVal RutaOrigen As String, ByVal carpeta As String)
        Try
            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            Dim PathArchivo As String
            Dim i As Integer

            Dim cont As Integer = 0
            Dim Linea As String = ""

            Dim CardCode As String = ""
            Dim ItemCode As String = ""
            Dim Descuento As String = ""

            If Directory.Exists(carpeta) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(carpeta)
            End If

            Cursor.Current = Cursors.WaitCursor
            PathArchivo = RutaOrigen ' Se determina el nombre del archivo 

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            For Each row As DataRow In Tbl_Ubicaciones.Rows
                CardCode = Tbl_Ubicaciones.Rows(cont).Item("CardCode").ToString()
                ItemCode = Tbl_Ubicaciones.Rows(cont).Item("ItemCode").ToString()
                Descuento = Tbl_Ubicaciones.Rows(cont).Item("Descuento").ToString()

                If (CardCode <> "" And ItemCode <> "" And Descuento <> "") Then
                    Linea = CardCode & "^" & ItemCode & "^" & Descuento & "^"
                    strStreamWriter.WriteLine(Linea)
                End If

                Linea = ""

                CardCode = ""
                ItemCode = ""
                Descuento = ""

                cont += 1
            Next

            '  DetalleCarga = "FIN DE GENERANDO ARCHIVO "
            strStreamWriter.Close() ' cerramos
            'INICIO DE LIBERIACION DE MEMORIA
            sRenglon = Nothing
            strStreamW.Dispose()
            strStreamW = Nothing
            strStreamWriter.Dispose()
            strStreamWriter = Nothing
            ContenidoArchivo = Nothing
            PathArchivo = Nothing
            i = Nothing
            Linea = Nothing

            CardCode = Nothing
            ItemCode = Nothing
            Descuento = Nothing

        Catch ex As Exception
            MessageBox.Show("ERROR Crear_InDescuentos : " & ex.Message)


        End Try
        Return 0

    End Function

    Public Function Crear_Revisame(ByVal RutaOrigen As String, ByVal carpeta As String)
        Try
            ' DetalleCarga = "GENERANDO ARCHIVO"
            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
            Dim PathArchivo As String
            Dim i As Integer

            Dim cont As Integer = 0
            Dim Linea As String = ""
            'SELECT T0.[CardCode], T0.[CardName], T0.[LicTradNum] as 'Cedula', T0.[CntctPrsn]as 'Responsable_Tributario', T0.[GroupNum] as 'CodCredito', T0.[U_Visita], T0.[U_Descuento] as 'DescuentoMAX', T0.[U_ClaveWeb],T0.[SlpCode],T0.[ListNum] as 'ListaPrecio' FROM  "&  Class_VariablesGlobales.XMLParamSAP_CompanyDB  &".[dbo].[OCRD] T0 WHERE T0.[U_AGENTE1] = @Agente
            Const quote As String = """"



            If Directory.Exists(carpeta) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(carpeta)
            End If

            Cursor.Current = Cursors.WaitCursor
            PathArchivo = RutaOrigen ' Se determina el nombre del archivo 

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura
            Linea = ""
            'ESCRIBE LA LINEA EN EL ARCHIVO
            strStreamWriter.WriteLine(Linea)
            '  DetalleCarga = "FIN DE GENERANDO ARCHIVO "
            strStreamWriter.Close() ' cerramos
            'INICIO DE LIBERIACION DE MEMORIA
            sRenglon = Nothing
            strStreamW.Dispose()
            strStreamW = Nothing
            strStreamWriter.Dispose()
            strStreamWriter = Nothing
            ContenidoArchivo = Nothing
            PathArchivo = Nothing
            i = Nothing
            Linea = Nothing
            'FIN DE LIBERIACION DE MEMORIA


            ' Contador = 0
        Catch ex As Exception
            ' Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR en Crear ( " & ex.ToString & " )"
        End Try
        Return 0

    End Function
    Public Function Crear_InInventario(ByVal Tbl_Inventario As DataTable, ByVal RutaOrigen As String, ByVal carpeta As String)
        Try
            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            Dim PathArchivo As String
            Dim i As Integer

            Dim cont As Integer = 0
            Dim Linea As String = ""
            'SELECT T0.[CardCode], T0.[CardName], T0.[LicTradNum] as 'Cedula', T0.[CntctPrsn]as 'Responsable_Tributario', T0.[GroupNum] as 'CodCredito', T0.[U_Visita], T0.[U_Descuento] as 'DescuentoMAX', T0.[U_ClaveWeb],T0.[SlpCode],T0.[ListNum] as 'ListaPrecio' FROM  "&  Class_VariablesGlobales.XMLParamSAP_CompanyDB  &".[dbo].[OCRD] T0 WHERE T0.[U_AGENTE1] = @Agente
            Dim ItemCode As String = ""
            Dim ItemName As String = ""
            Dim CodeBars As String = ""


            If Directory.Exists(carpeta) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(carpeta)
            End If

            Cursor.Current = Cursors.WaitCursor
            PathArchivo = RutaOrigen ' Se determina el nombre del archivo 

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            For Each row As DataRow In Tbl_Inventario.Rows
                ItemCode = Tbl_Inventario.Rows(cont).Item("ItemCode").ToString()
                ItemName = Tbl_Inventario.Rows(cont).Item("ItemName").ToString()
                CodeBars = Tbl_Inventario.Rows(cont).Item("CodeBars").ToString()



                Linea = ItemCode + "," & ItemName + "," & CodeBars + ","
                strStreamWriter.WriteLine(Linea)
                Linea = ""
                ItemCode = ""
                ItemName = ""
                CodeBars = ""
                cont += 1
            Next

            '  DetalleCarga = "FIN DE GENERANDO ARCHIVO "
            strStreamWriter.Close() ' cerramos
            'INICIO DE LIBERIACION DE MEMORIA
            sRenglon = Nothing
            strStreamW.Dispose()
            strStreamW = Nothing
            strStreamWriter.Dispose()
            strStreamWriter = Nothing
            ContenidoArchivo = Nothing
            PathArchivo = Nothing
            i = Nothing
            Linea = Nothing
            Linea = Nothing
            ItemCode = Nothing
            ItemName = Nothing
            CodeBars = Nothing

        Catch ex As Exception
            MsgBox("ERROR Crear_in_ParamSeller [ " & ex.Message & " ]")
        End Try
        Return 0

    End Function
    'Public Function Crear(ByVal Tabla As DataTable, ByVal Tbl_Art_Restringidos As DataTable, ByVal Tbl_Art_PermitidosDeCasasRestringidas As DataTable, ByVal RutaOrigen As String, ByVal carpeta As String)
    '    Try

    '        Dim sRenglon As String = Nothing
    '        Dim strStreamW As Stream = Nothing
    '        Dim strStreamWriter As StreamWriter = Nothing
    '        Dim ContenidoArchivo As String = Nothing
    '        ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
    '        Dim PathArchivo As String
    '        Dim i As Integer

    '        Dim cont As Integer = 0
    '        Dim Linea As String = ""
    '        Dim Linea2 As String = ""
    '        'Variables para cada lista de presio
    '        Dim DETALLE_1 As String = ""
    '        Dim LISTA_A_DETALLE As String = ""
    '        Dim LISTA_A_SUPERMERCADO As String = ""
    '        Dim LISTA_A_MAYORISTA As String = ""
    '        Dim LISTA_A_2_MAYORISTA As String = ""
    '        Dim PAÑALERA As String = ""
    '        Dim SUPERMERCADOS As String = ""
    '        Dim MAYORISTAS As String = ""
    '        Dim HUELLAS_DORADAS As String = ""
    '        Dim ALSER As String = ""
    '        Dim COSTO As String = ""
    '        Dim SUGERIDO As String = ""
    '        Dim CodeBars As String = ""

    '        Dim Precio_Sug As String = ""

    '        Dim LineaRestringida As Boolean
    '        Dim Nueva_Linea = 0
    '        Const quote As String = """"



    '        If Directory.Exists(carpeta) = False Then ' si no existe la carpeta se crea
    '            Directory.CreateDirectory(carpeta)
    '        End If

    '        Cursor.Current = Cursors.WaitCursor
    '        PathArchivo = RutaOrigen ' Se determina el nombre del archivo 

    '        'verificamos si existe el archivo
    '        If File.Exists(PathArchivo) Then
    '            strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
    '        Else
    '            strStreamW = File.Create(PathArchivo) ' lo creamos
    '        End If

    '        strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura


    '        For Each row As DataRow In Tabla.Rows

    '            Dim conta As Integer = 0
    '            Dim conta2 As Integer = 0
    '            'recorre los articulos restringidos
    '            For Each row2 As DataRow In Tbl_Art_Restringidos.Rows

    '                'VERIFICA QUE LA CASA DE LA LINEA EN CURSO ESTA RESTRINGIDA
    '                If Mid(Tabla.Rows(cont).Item("ItemCode").ToString(), 1, 4) = Tbl_Art_Restringidos.Rows(conta).Item("Cod_Articulo").ToString() Then
    '                    LineaRestringida = True

    '                    ' SI LA CASA ESTA RESTRINGIDA VERIFICA SI LA LINEA EN CURSO ESTA EXENTA DE ESTA RESTRICCION
    '                    For Each row3 As DataRow In Tbl_Art_PermitidosDeCasasRestringidas.Rows
    '                        If Tabla.Rows(cont).Item("ItemCode").ToString() = Tbl_Art_PermitidosDeCasasRestringidas.Rows(conta2).Item("Cod_Articulo").ToString() Then
    '                            LineaRestringida = False
    '                            Exit For

    '                        End If
    '                        conta2 += 1
    '                    Next
    '                    Exit For
    '                End If
    '                conta += 1
    '            Next



    '            'si no esta restringida la mete en el archivo
    '            If LineaRestringida = False Then

    '                'Linea = "" + quote + Tabla.Rows(cont).Item("ItemCode").ToString() + quote + "," & quote & Tabla.Rows(cont).Item("ItemName").ToString() & quote & "," & quote & "UNID" & quote & "," & quote & "UNID" & quote & "," & quote & Tabla.Rows(cont).Item("Impuesto").ToString() & quote & "," & quote & "0" & quote & ","
    '                Linea2 = "" + Tabla.Rows(cont).Item("ItemCode").ToString() + "^" & Tabla.Rows(cont).Item("ItemName").ToString() & "^" & "0" & "^" & CInt(Tabla.Rows(cont).Item("Empaque").ToString()) & "^" & Tabla.Rows(cont).Item("Impuesto").ToString() & "^"
    '                ' DetalleCarga = "GENERANDO ARTICULO [" & Tabla.Rows(cont).Item("ItemCode").ToString() & "] [ " & Tabla.Rows(cont).Item("ItemName").ToString() & " ]"
    '                'si se crean eliminan o modifican las listas se debe de corregir aqui tambien, MEJOR BASARSE EN CODIGO
    '                If Tabla.Rows(cont).Item("ListName").ToString() = "DETALLE 1" Then
    '                    'DETALLE_1 = quote & Tabla.Rows(cont).Item("Price").ToString() & quote
    '                    DETALLE_1 = Tabla.Rows(cont).Item("Price").ToString()
    '                End If
    '                If Tabla.Rows(cont).Item("ListName").ToString() = "LISTA A DETALLE" Then
    '                    'LISTA_A_DETALLE = quote & Tabla.Rows(cont).Item("Price").ToString() & quote
    '                    LISTA_A_DETALLE = Tabla.Rows(cont).Item("Price").ToString()
    '                End If
    '                If Tabla.Rows(cont).Item("ListName").ToString() = "LISTA A SUPERMERCADO" Then
    '                    ' LISTA_A_SUPERMERCADO = quote & Tabla.Rows(cont).Item("Price").ToString() & quote
    '                    LISTA_A_SUPERMERCADO = Tabla.Rows(cont).Item("Price").ToString()
    '                End If
    '                If Tabla.Rows(cont).Item("ListName").ToString() = "LISTA A MAYORISTA" Then
    '                    '  LISTA_A_MAYORISTA = quote & Tabla.Rows(cont).Item("Price").ToString() & quote
    '                    LISTA_A_MAYORISTA = Tabla.Rows(cont).Item("Price").ToString()
    '                End If
    '                If Tabla.Rows(cont).Item("ListName").ToString() = "LISTA A + 2% MAYORISTA" Then
    '                    'LISTA_A_2_MAYORISTA = quote & Tabla.Rows(cont).Item("Price").ToString() & quote
    '                    LISTA_A_2_MAYORISTA = Tabla.Rows(cont).Item("Price").ToString()
    '                End If
    '                If Tabla.Rows(cont).Item("ListName").ToString() = "PAÑALERA" Then
    '                    'PAÑALERA = quote & Tabla.Rows(cont).Item("Price").ToString() & quote
    '                    PAÑALERA = Tabla.Rows(cont).Item("Price").ToString()
    '                End If
    '                If Tabla.Rows(cont).Item("ListName").ToString() = "SUPERMERCADOS" Then
    '                    'SUPERMERCADOS = quote & Tabla.Rows(cont).Item("Price").ToString() & quote
    '                    SUPERMERCADOS = Tabla.Rows(cont).Item("Price").ToString()
    '                End If
    '                If Tabla.Rows(cont).Item("ListName").ToString() = "MAYORISTAS" Then
    '                    ' MAYORISTAS = quote & Tabla.Rows(cont).Item("Price").ToString() & quote
    '                    MAYORISTAS = Tabla.Rows(cont).Item("Price").ToString()
    '                End If
    '                If Tabla.Rows(cont).Item("ListName").ToString() = "HUELLAS DORADAS" Then
    '                    ' HUELLAS_DORADAS = quote & Tabla.Rows(cont).Item("Price").ToString() & quote
    '                    HUELLAS_DORADAS = Tabla.Rows(cont).Item("Price").ToString()
    '                End If
    '                If Tabla.Rows(cont).Item("ListName").ToString() = "LISTA CANAL ORIENTAL" Then
    '                    'ALSER = quote & Tabla.Rows(cont).Item("Price").ToString() & quote
    '                    ALSER = Tabla.Rows(cont).Item("Price").ToString()
    '                End If
    '                If Tabla.Rows(cont).Item("ListName").ToString() = "COSTO" Then
    '                    'COSTO = quote & Tabla.Rows(cont).Item("Price").ToString() & quote
    '                    COSTO = Tabla.Rows(cont).Item("Price").ToString()

    '                End If
    '                If Tabla.Rows(cont).Item("ListName").ToString() = "PRECIO SUGERIDO" Then
    '                    'SUGERIDO = quote & Tabla.Rows(cont).Item("Price").ToString() & quote
    '                    SUGERIDO = Tabla.Rows(cont).Item("Price").ToString()
    '                    Nueva_Linea = 1
    '                End If
    '                Precio_Sug = Tabla.Rows(cont).Item("U_Precio_Sug").ToString()
    '                CodeBars = Tabla.Rows(cont).Item("CodeBars").ToString()
    '                If Nueva_Linea = 1 Then

    '                    'Linea += DETALLE_1 + "," + LISTA_A_DETALLE + "," + LISTA_A_SUPERMERCADO + "," + LISTA_A_MAYORISTA + "," + LISTA_A_2_MAYORISTA + "," + quote + "0.0000" + quote + "," + quote + "0.0000" + quote + "," + quote + "0.0000" + quote + "," + quote + "0.0000" + quote + "," + quote + "0.0000" + quote + "," + quote + "0.0000" + quote + "," + PAÑALERA + "," + SUPERMERCADOS + "," + MAYORISTAS + "," + HUELLAS_DORADAS + "," + ALSER + "," + quote + "0.0000" + quote + "," + quote + "0.0000" + quote + "," + quote + "0.0000" + quote + "," + quote + "0.0000" + quote + "," + quote + "0.0000" + quote + "," + quote + "" + quote + "," + quote + "0.0000" + quote + "," + COSTO + "," + SUGERIDO + "," + quote + "0.0000" + quote + "," + quote + "0.0000" + quote + "," + quote + "0.0000" + quote + ","
    '                    Linea2 += DETALLE_1 + "^" + LISTA_A_DETALLE + "^" + LISTA_A_SUPERMERCADO + "^" + LISTA_A_MAYORISTA + "^" + LISTA_A_2_MAYORISTA + "^" + PAÑALERA + "^" + SUPERMERCADOS + "^" + MAYORISTAS + "^" + HUELLAS_DORADAS + "^" + ALSER + "^" + COSTO + "^" + Precio_Sug + "^" + CodeBars + "^"

    '                    'ESCRIBE LA LINEA EN EL ARCHIVO
    '                    strStreamWriter.WriteLine(Linea2)


    '                    Linea = ""
    '                    Linea2 = ""
    '                    DETALLE_1 = ""
    '                    LISTA_A_DETALLE = ""
    '                    LISTA_A_SUPERMERCADO = ""
    '                    LISTA_A_MAYORISTA = ""
    '                    LISTA_A_2_MAYORISTA = ""
    '                    PAÑALERA = ""
    '                    SUPERMERCADOS = ""
    '                    MAYORISTAS = ""
    '                    HUELLAS_DORADAS = ""
    '                    ALSER = ""
    '                    ALSER = ""
    '                    COSTO = ""
    '                    Precio_Sug = ""
    '                    CodeBars = ""
    '                    Nueva_Linea = 0
    '                End If
    '                Linea = ""
    '                Linea2 = ""
    '                cont += 1
    '                'Contador += 1
    '                ' Contador_sub += 1

    '                'fin de Verificacion de linea restringida
    '            Else
    '                cont += 1
    '                LineaRestringida = False
    '            End If
    '        Next


    '        strStreamWriter.Close() ' cerramos

    '        'INICIO DE LIBERIACION DE MEMORIA

    '        sRenglon = Nothing

    '        strStreamW.Dispose()
    '        strStreamW = Nothing

    '        strStreamWriter.Dispose()
    '        strStreamWriter = Nothing

    '        ContenidoArchivo = Nothing
    '        PathArchivo = Nothing
    '        i = Nothing

    '        Linea = Nothing
    '        Linea2 = Nothing
    '        DETALLE_1 = Nothing
    '        LISTA_A_DETALLE = Nothing
    '        LISTA_A_SUPERMERCADO = Nothing
    '        LISTA_A_MAYORISTA = Nothing
    '        LISTA_A_2_MAYORISTA = Nothing
    '        PAÑALERA = Nothing
    '        SUPERMERCADOS = Nothing
    '        MAYORISTAS = Nothing
    '        HUELLAS_DORADAS = Nothing
    '        ALSER = Nothing
    '        ALSER = Nothing
    '        COSTO = Nothing
    '        CodeBars = Nothing

    '        Nueva_Linea = Nothing
    '        'FIN DE LIBERIACION DE MEMORIA


    '        ' Contador = 0
    '    Catch ex As Exception
    '        Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR en Crear ( " & ex.ToString & " )"
    '    End Try
    '    Return 0

    'End Function


    Public Function Crear(ByVal Tabla As DataTable,
                          ByVal Tbl_Art_Restringidos As DataTable,
                          ByVal Tbl_Art_PermitidosDeCasasRestringidas As DataTable,
                          ByVal RutaOrigen As String,
                          ByVal carpeta As String,
                          Ruta As String)
        Try

            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
            Dim PathArchivo As String
            Dim i As Integer

            Dim cont As Integer = 0
            Dim LineaListasPrecios As String = ""
            Dim Linea2 As String = ""
            'Variables para cada lista de presio
            'Dim DETALLE_1 As String = ""
            'Dim LISTA_A_DETALLE As String = ""
            'Dim LISTA_A_SUPERMERCADO As String = ""
            'Dim LISTA_A_MAYORISTA As String = ""
            'Dim LISTA_A_2_MAYORISTA As String = ""
            'Dim PAÑALERA As String = ""
            'Dim SUPERMERCADOS As String = ""
            'Dim MAYORISTAS As String = ""
            'Dim HUELLAS_DORADAS As String = ""
            'Dim ALSER As String = ""
            'Dim COSTO As String = ""
            'Dim SUGERIDO As String = ""


            Dim CodBarras As String = ""
            Dim Existencias As String = ""
            Dim ItemCode As String = ""

            Dim Precio_Sug As String = ""
            Dim LineaRestringida As Boolean
            Dim Nueva_Linea = 0
            Const quote As String = """"



            If Directory.Exists(carpeta) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(carpeta)
            End If

            'Windows.Forms.Cursor.Current = Cursors.WaitCursor
            PathArchivo = RutaOrigen ' Se determina el nombre del archivo 

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura


            For Each row As DataRow In Tabla.Rows

                Dim conta As Integer = 0
                Dim conta2 As Integer = 0
                'recorre los articulos restringidos
                For Each row2 As DataRow In Tbl_Art_Restringidos.Rows

                    'VERIFICA QUE LA CASA DE LA LINEA EN CURSO ESTA RESTRINGIDA
                    If Mid(Tabla.Rows(cont).Item("ItemCode").ToString(), 1, 4) = Tbl_Art_Restringidos.Rows(conta).Item("Cod_Articulo").ToString() Then
                        LineaRestringida = True

                        ' SI LA CASA ESTA RESTRINGIDA VERIFICA SI LA LINEA EN CURSO ESTA EXENTA DE ESTA RESTRICCION
                        For Each row3 As DataRow In Tbl_Art_PermitidosDeCasasRestringidas.Rows
                            If Tabla.Rows(cont).Item("ItemCode").ToString() = Tbl_Art_PermitidosDeCasasRestringidas.Rows(conta2).Item("Cod_Articulo").ToString() Then
                                LineaRestringida = False
                                Exit For

                            End If
                            conta2 += 1
                        Next
                        Exit For
                    End If
                    conta += 1
                Next





                'si no esta restringida la mete en el archivo
                If LineaRestringida = False Then
                    'LA LISTA VIENE ORDENADA POR CODIGO DE ARTICULO DESCENDENTEMENTE , esto quiere decir que el codigo del articulo se mantiene y el codigo de la lista de precio cambia
                    If ItemCode = "" Then
                        ItemCode = Tabla.Rows(cont).Item("ItemCode").ToString()
                    End If

                    'Si es diferente es por que empezara a obtener la informacion de una nueva linea, para agregar la ultima linea se usa Or cont = Tabla.Rows.Count - 1 
                    If ItemCode <> Tabla.Rows(cont).Item("ItemCode").ToString() Then
                        ItemCode = Tabla.Rows(cont).Item("ItemCode").ToString()
                        Linea2 = "" + Tabla.Rows(cont - 1).Item("ItemCode").ToString() + "^" & Tabla.Rows(cont - 1).Item("ItemName").ToString() & "^" & Tabla.Rows(cont - 1).Item("Existencias").ToString() & "^" & CInt(Tabla.Rows(cont - 1).Item("Empaque").ToString()) & "^" & Tabla.Rows(cont - 1).Item("Impuesto").ToString() & "^" & Tabla.Rows(cont - 1).Item("CodeBars").ToString() & "^" & LineaListasPrecios

                        'ESCRIBE LA LINEA EN EL ARCHIVO
                        strStreamWriter.WriteLine(Linea2)
                        'DetalleCarga = "RUTA [ " & Ruta & " ] GENERANDO ARCHIVO [ " & Linea2 & " ]"
                        Linea2 = ""
                        LineaListasPrecios = ""

                    End If
                    LineaListasPrecios = LineaListasPrecios & Tabla.Rows(cont).Item("PriceList").ToString() & "^" & Tabla.Rows(cont).Item("Price").ToString() + "^"

                    'indica que se llego a la ultima linea
                    If cont + 1 = Tabla.Rows.Count Then
                        ItemCode = Tabla.Rows(cont).Item("ItemCode").ToString()
                        Linea2 = "" + Tabla.Rows(cont - 1).Item("ItemCode").ToString() + "^" & Tabla.Rows(cont - 1).Item("ItemName").ToString() & "^" & Tabla.Rows(cont - 1).Item("Existencias").ToString() & "^" & CInt(Tabla.Rows(cont - 1).Item("Empaque").ToString()) & "^" & Tabla.Rows(cont - 1).Item("Impuesto").ToString() & "^" & Tabla.Rows(cont - 1).Item("CodeBars").ToString() & "^" & LineaListasPrecios

                        'ESCRIBE LA LINEA EN EL ARCHIVO
                        strStreamWriter.WriteLine(Linea2)
                        'DetalleCarga = "RUTA [ " & Ruta & " ] GENERANDO ARCHIVO [ " & Linea2 & " ]"
                        Linea2 = ""
                        LineaListasPrecios = ""
                    End If
                    cont += 1
                    'fin de Verificacion de linea restringida
                Else
                    cont += 1
                    LineaRestringida = False
                End If
            Next

            'DetalleCarga = "RUTA [ " & Ruta & " ] GENERACION FINALIZADA "
            strStreamWriter.Close() ' cerramos

            'INICIO DE LIBERIACION DE MEMORIA

            sRenglon = Nothing

            strStreamW.Dispose()
            strStreamW = Nothing

            strStreamWriter.Dispose()
            strStreamWriter = Nothing

            ContenidoArchivo = Nothing
            PathArchivo = Nothing
            i = Nothing

            Linea2 = Nothing

            Nueva_Linea = Nothing
            'FIN DE LIBERIACION DE MEMORIA

            ' Contador = 0
        Catch ex As Exception
            'ERRORES = "[ " & Now & " ] ERROR en Crear ( " & ex.ToString & " )"
        End Try
        Return 0

    End Function

    Public Function Crear_InFacturass(ByVal Tbl_Facturas As DataTable, ByVal RutaOrigen As String, ByVal carpeta As String, ByVal VerDias As Boolean)
        Try
            ' DetalleCarga = "GENERANDO ARCHIVO"
            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
            Dim PathArchivo As String
            Dim i As Integer

            Dim cont As Integer = 0
            Dim Linea As String = ""
            'SELECT T0.[CardCode], T0.[CardName], T0.[LicTradNum] as 'Cedula', T0.[CntctPrsn]as 'Responsable_Tributario', T0.[GroupNum] as 'CodCredito', T0.[U_Visita], T0.[U_Descuento] as 'DescuentoMAX', T0.[U_ClaveWeb],T0.[SlpCode],T0.[ListNum] as 'ListaPrecio' FROM  "&  Class_VariablesGlobales.XMLParamSAP_CompanyDB  &".[dbo].[OCRD] T0 WHERE T0.[U_AGENTE1] = @Agente

            Dim Consecutivo As String = ""
            Dim DocNum As String = ""
            Dim FechaReporte As String = ""
            Dim FechaFactura As String = ""
            Dim CodCliente As String = ""
            Dim Nombre As String = ""
            Dim ItemCode As String = ""
            Dim ItemName As String = ""
            Dim Cant As String = ""
            Dim Descuento As String = ""
            Dim Precio As String = ""
            Dim Imp As String = ""
            Dim MontoDesc As String = ""
            Dim MontoImp As String = ""
            Dim Total As String = ""
            Dim Fac_INI As String = ""
            Dim Fac_FIN As String = ""
            Dim Chofer As String = ""
            Dim Ayudante As String = ""
            Dim DescFijo As String = ""
            Dim DescPromo As String = ""
            Dim DocEntry As String = ""
            Dim CodeBars As String = ""
            Const quote As String = """"

            If Directory.Exists(carpeta) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(carpeta)
            End If
            Cursor.Current = Cursors.WaitCursor
            PathArchivo = RutaOrigen ' Se determina el nombre del archivo 

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura
            For Each row As DataRow In Tbl_Facturas.Rows

                Consecutivo = Tbl_Facturas.Rows(cont).Item("Consecutivo").ToString()
                DocNum = Tbl_Facturas.Rows(cont).Item("DocNum").ToString()
                FechaReporte = Tbl_Facturas.Rows(cont).Item("FechaReporte").ToString()
                FechaFactura = Tbl_Facturas.Rows(cont).Item("FechaFactura").ToString()

                CodCliente = Tbl_Facturas.Rows(cont).Item("CodCliente").ToString()
                Nombre = Tbl_Facturas.Rows(cont).Item("Nombre").ToString()
                ItemCode = Tbl_Facturas.Rows(cont).Item("ItemCode").ToString()
                ItemName = Tbl_Facturas.Rows(cont).Item("ItemName").ToString()
                Cant = Tbl_Facturas.Rows(cont).Item("Cant").ToString()
                Descuento = Tbl_Facturas.Rows(cont).Item("Descuento").ToString()
                Precio = Tbl_Facturas.Rows(cont).Item("Precio").ToString()
                Imp = Tbl_Facturas.Rows(cont).Item("Imp").ToString()
                MontoDesc = Tbl_Facturas.Rows(cont).Item("MontoDesc").ToString()
                MontoImp = Tbl_Facturas.Rows(cont).Item("MontoImp").ToString()
                Total = Tbl_Facturas.Rows(cont).Item("Total").ToString()
                Fac_INI = Tbl_Facturas.Rows(cont).Item("Fac_INI").ToString()
                Fac_FIN = Tbl_Facturas.Rows(cont).Item("Fac_FIN").ToString()
                Chofer = Tbl_Facturas.Rows(cont).Item("Chofer").ToString()
                Ayudante = Tbl_Facturas.Rows(cont).Item("Ayudante").ToString()
                DescFijo = Tbl_Facturas.Rows(cont).Item("DescFijo").ToString()
                DescPromo = Tbl_Facturas.Rows(cont).Item("DescPromo").ToString()
                DocEntry = Tbl_Facturas.Rows(cont).Item("DocEntry").ToString()
                CodeBars = Tbl_Facturas.Rows(cont).Item("CodeBars").ToString()
                If DescFijo = "" Then
                    DescFijo = "0"
                End If
                If DescPromo = "" Then
                    DescPromo = "0"
                End If

                Linea = Consecutivo & "^" & DocNum & "^" & FechaReporte & "^" & FechaFactura & "^" & CodCliente & "^" & Nombre & "^" & ItemCode & "^" & ItemName & "^" & Cant & "^" & Descuento & "^" & Precio & "^" & Imp & "^" & MontoDesc & "^" & MontoImp & "^" & Total & "^" & Fac_INI & "^" & Fac_FIN & "^" & Chofer & "^" & Ayudante & "^" & DescFijo & "^" & DescPromo & "^" & DocEntry & "^" & CodeBars & "^"

                'ESCRIBE LA LINEA EN EL ARCHIVO
                strStreamWriter.WriteLine(Linea)
                '  DetalleCarga = "GENERANDO ARCHIVO [ " & Linea & " ]"

                Linea = ""
                Consecutivo = ""
                DocNum = ""
                FechaReporte = ""
                FechaFactura = ""
                CodCliente = ""
                Nombre = ""
                ItemCode = ""
                ItemName = ""
                Cant = ""
                Descuento = ""
                Precio = ""
                Imp = ""
                MontoDesc = ""
                MontoImp = ""
                Total = ""
                Fac_INI = ""
                Fac_FIN = ""
                Chofer = ""
                Ayudante = ""
                DescFijo = ""
                DescPromo = ""
                DocEntry = ""
                CodeBars = ""
                Linea = ""
                cont += 1


            Next

            '  DetalleCarga = "FIN DE GENERANDO ARCHIVO "
            strStreamWriter.Close() ' cerramos

            'INICIO DE LIBERIACION DE MEMORIA

            sRenglon = Nothing

            strStreamW.Dispose()
            strStreamW = Nothing

            strStreamWriter.Dispose()
            strStreamWriter = Nothing

            ContenidoArchivo = Nothing
            PathArchivo = Nothing
            i = Nothing

            Linea = Nothing


            Linea = Nothing
            Consecutivo = Nothing
            DocNum = Nothing
            FechaReporte = Nothing
            CodCliente = Nothing
            Nombre = Nothing
            ItemCode = Nothing
            ItemName = Nothing
            Cant = Nothing
            Descuento = Nothing
            Precio = Nothing
            Imp = Nothing
            MontoDesc = Nothing
            MontoImp = Nothing
            DescFijo = Nothing
            DescPromo = Nothing

            'FIN DE LIBERIACION DE MEMORIA


            ' Contador = 0
        Catch ex As Exception
            ' ERRORES = "[ " & Now & " ] ERROR en Crear ( " & ex.ToString & " )"
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR en Crear_InFacturass ( " & ex.ToString & " )"
        End Try
        Return 0

    End Function
    Public Function Crear_InClientes(ByVal Tbl_Clientes As DataTable, ByVal RutaOrigen As String, ByVal carpeta As String, ByVal VerDias As Boolean)
        Try
            ' DetalleCarga = "GENERANDO ARCHIVO"
            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
            Dim PathArchivo As String
            Dim i As Integer

            Dim cont As Integer = 0
            Dim Linea As String = ""
            'SELECT T0.[CardCode], T0.[CardName], T0.[LicTradNum] as 'Cedula', T0.[CntctPrsn]as 'Responsable_Tributario', T0.[GroupNum] as 'CodCredito', T0.[U_Visita], T0.[U_Descuento] as 'DescuentoMAX', T0.[U_ClaveWeb],T0.[SlpCode],T0.[ListNum] as 'ListaPrecio' FROM  "&  Class_VariablesGlobales.XMLParamSAP_CompanyDB  &".[dbo].[OCRD] T0 WHERE T0.[U_AGENTE1] = @Agente
            Dim CardCode As String = ""
            Dim CardName As String = ""
            Dim Cedula As String = ""
            Dim Responsable_Tributario As String = ""
            Dim CodCredito As String = ""
            Dim U_Visita As String = ""
            Dim DescuentoMAX As String = ""
            Dim U_ClaveWeb As String = ""
            Dim SlpCode As String = ""
            Dim ListaPrecio As String = ""
            Dim Phone1 As String = ""
            Dim Phone2 As String = ""
            Dim Street As String = ""
            Dim E_Mail As String = ""
            Dim Dias_Credito As String = ""
            Dim NombreFicticio As String = ""
            Dim Latitud As String = ""
            Dim Longitud As String = ""

            Dim Id_Provincia As String = ""
            Dim Id_Canton As String = ""
            Dim Id_Distrito As String = ""
            Dim Id_Barrio As String = ""
            Dim Id_TipoCedula As String = ""
            Dim DescMax As String = ""
            Dim TipoSocio As String = ""
            Dim EnviarFE As String = ""



            Const quote As String = """"



            If Directory.Exists(carpeta) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(carpeta)
            End If

            Cursor.Current = Cursors.WaitCursor
            PathArchivo = RutaOrigen ' Se determina el nombre del archivo 

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura


            For Each row As DataRow In Tbl_Clientes.Rows

                CardCode = Tbl_Clientes.Rows(cont).Item("CardCode").ToString()
                CardName = Tbl_Clientes.Rows(cont).Item("CardName").ToString()
                Cedula = Tbl_Clientes.Rows(cont).Item("Cedula").ToString()
                Responsable_Tributario = Tbl_Clientes.Rows(cont).Item("Responsable_Tributario").ToString()
                CodCredito = Tbl_Clientes.Rows(cont).Item("CodCredito").ToString()
                U_Visita = Tbl_Clientes.Rows(cont).Item("U_Visita").ToString()
                DescuentoMAX = Tbl_Clientes.Rows(cont).Item("DescMax").ToString()
                U_ClaveWeb = Tbl_Clientes.Rows(cont).Item("U_ClaveWeb").ToString()
                SlpCode = Tbl_Clientes.Rows(cont).Item("SlpCode").ToString()
                ListaPrecio = Tbl_Clientes.Rows(cont).Item("ListaPrecio").ToString()
                Phone1 = Tbl_Clientes.Rows(cont).Item("Phone1").ToString()
                Phone2 = Tbl_Clientes.Rows(cont).Item("Phone2").ToString()
                Street = Tbl_Clientes.Rows(cont).Item("Street").ToString()
                E_Mail = Tbl_Clientes.Rows(cont).Item("E_Mail").ToString()
                Dias_Credito = Tbl_Clientes.Rows(cont).Item("Dias_Credito").ToString()
                NombreFicticio = Tbl_Clientes.Rows(cont).Item("CardFName").ToString()
                Latitud = Tbl_Clientes.Rows(cont).Item("U_Latitud").ToString()
                Longitud = Tbl_Clientes.Rows(cont).Item("U_Longitud").ToString()
                Longitud = Tbl_Clientes.Rows(cont).Item("U_Longitud").ToString()
                DescMax = Tbl_Clientes.Rows(cont).Item("DescMax").ToString()
                'aqui lo que se debe enviar son los IDs integer de los dropdownlist que se crearan en la ventana de direcciones de socios de negocio de SAP
                Id_Provincia = Tbl_Clientes.Rows(cont).Item("Provincia").ToString()
                Id_Canton = Tbl_Clientes.Rows(cont).Item("Canton").ToString()
                Id_Distrito = Tbl_Clientes.Rows(cont).Item("Distrito").ToString()
                Id_Barrio = Tbl_Clientes.Rows(cont).Item("Barrio").ToString()
                Id_TipoCedula = Tbl_Clientes.Rows(cont).Item("TipoCedula").ToString()
                TipoSocio = Tbl_Clientes.Rows(cont).Item("TipoSocio").ToString()
                EnviarFE = Tbl_Clientes.Rows(cont).Item("EnviarFE").ToString()
                'Id_Provincia = 0
                'Id_Canton = 0
                'Id_Distrito = 0
                'Id_Barrio = 0
                'Id_TipoCedula = 0

                Linea = CardCode + "^" & CardName & "^" & Cedula & "^" & Responsable_Tributario & "^" & CodCredito & "^" & U_Visita & "^" & DescuentoMAX & "^" & U_ClaveWeb & "^" & SlpCode & "^" & ListaPrecio & "^" & Phone1 & "^" & Phone2 & "^" & Street & "^" & E_Mail & "^" & Dias_Credito & "^" & NombreFicticio & "^" & Latitud & "^" & Longitud & "^" & VerDias & "^" & DescMax & "^" & Id_Provincia & "^" & Id_Canton & "^" & Id_Distrito & "^" & Id_Barrio & "^" & Id_TipoCedula & "^" & TipoSocio & "^" & EnviarFE & "^"

                'ESCRIBE LA LINEA EN EL ARCHIVO
                strStreamWriter.WriteLine(Linea)
                '  DetalleCarga = "GENERANDO ARCHIVO [ " & Linea & " ]"

                Linea = ""
                CardCode = ""
                CardName = ""
                Cedula = ""
                Responsable_Tributario = ""
                CodCredito = ""
                U_Visita = ""
                DescuentoMAX = ""
                U_ClaveWeb = ""
                SlpCode = ""
                ListaPrecio = ""
                Phone1 = ""
                Phone2 = ""
                Street = ""
                E_Mail = ""
                Dias_Credito = ""
                NombreFicticio = ""
                Latitud = ""
                Longitud = ""
                DescMax = ""
                Id_Provincia = ""
                Id_Canton = ""
                Id_Distrito = ""
                Id_Barrio = ""
                Id_TipoCedula = ""
                TipoSocio = ""
                EnviarFE = ""

                Linea = ""
                cont += 1


            Next

            '  DetalleCarga = "FIN DE GENERANDO ARCHIVO "
            strStreamWriter.Close() ' cerramos

            'INICIO DE LIBERIACION DE MEMORIA

            sRenglon = Nothing

            strStreamW.Dispose()
            strStreamW = Nothing

            strStreamWriter.Dispose()
            strStreamWriter = Nothing

            ContenidoArchivo = Nothing
            PathArchivo = Nothing
            i = Nothing

            Linea = Nothing


            Linea = Nothing
            CardCode = Nothing
            CardName = Nothing
            Cedula = Nothing
            Responsable_Tributario = Nothing
            CodCredito = Nothing
            U_Visita = Nothing
            DescuentoMAX = Nothing
            U_ClaveWeb = Nothing
            SlpCode = Nothing
            Phone1 = Nothing
            Phone2 = Nothing
            Street = Nothing
            DescMax = Nothing

            Id_Provincia = Nothing
            Id_Canton = Nothing
            Id_Distrito = Nothing
            Id_Barrio = Nothing
            TipoSocio = Nothing
            EnviarFE = Nothing

            NombreFicticio = Nothing

            'FIN DE LIBERIACION DE MEMORIA


            ' Contador = 0
        Catch ex As Exception
            ' ERRORES = "[ " & Now & " ] ERROR en Crear ( " & ex.ToString & " )"
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR en Crear_InClientes ( " & ex.ToString & " )"
        End Try
        Return 0

    End Function
    Public Function Crear_InCxc(ByVal Tbl_Clientes As DataTable, ByVal RutaOrigen As String, ByVal carpeta As String, ByVal Ruta As String, Rutas_Unidicar() As String)
        Try
            ' DetalleCarga = "GENERANDO ARCHIVO"
            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
            Dim PathArchivo As String
            Dim i As Integer

            Dim cont As Integer = 0
            Dim cont2 As Integer = 0
            Dim Linea As String = ""

            Dim DocEntry As String = ""
            Dim DocNum As String = ""
            Dim Tipo_Documento As String = ""
            Dim DocDate As String = ""
            Dim FechaVencimiento As String = ""
            Dim DocTotal As String = ""
            Dim SALDO As String = ""
            Dim CardCode As String = ""
            Dim CardName As String = ""
            Dim TipoCambio As String = ""
            Dim TipoCliente As String = ""
            Dim NameFicticio As String = ""
            Const quote As String = """"

            If Directory.Exists(carpeta) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(carpeta)
            End If

            Cursor.Current = Cursors.WaitCursor
            PathArchivo = RutaOrigen ' Se determina el nombre del archivo 


            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            'recorre los clientes para crear el archivo de CXC
            'For Each row As DataRow In Tbl_Clientes.Rows

            Dim TABLACXC As New DataTable
            TABLACXC = Obj_SQL_CONEXIONSERVER.Obtiene_cxc(Class_VariablesGlobales.SQL_Comman2, Ruta, Rutas_Unidicar)


            For Each row2 As DataRow In TABLACXC.Rows

                DocNum = TABLACXC.Rows(cont2).Item("DocNum").ToString()
                DocEntry = TABLACXC.Rows(cont2).Item("DocEntry").ToString()
                Tipo_Documento = TABLACXC.Rows(cont2).Item("Tipo_Documento").ToString()
                DocDate = TABLACXC.Rows(cont2).Item("DocDate").ToString().Substring(0, 10)
                FechaVencimiento = TABLACXC.Rows(cont2).Item("FechaVencimiento").ToString().Substring(0, 10)
                DocTotal = TABLACXC.Rows(cont2).Item("DocTotal").ToString()
                SALDO = TABLACXC.Rows(cont2).Item("SALDO").ToString()
                CardCode = TABLACXC.Rows(cont2).Item("CardCode").ToString()
                CardName = TABLACXC.Rows(cont2).Item("CardName").ToString()
                TipoCambio = TABLACXC.Rows(cont2).Item("TipoCambio").ToString()
                TipoCliente = TABLACXC.Rows(cont2).Item("TipoCliente").ToString()
                NameFicticio = TABLACXC.Rows(cont2).Item("NameFicticio").ToString()
                Dim fecha As Date = FechaVencimiento
                Dim hoy As Date = Now
                Dim dias As Integer

                dias = DateDiff(DateInterval.Day, fecha, hoy)
                'DocDate = Obj_FechaM.FormatFechaSqlite(DocDate)
                'FechaVencimiento = Obj_FechaM.FormatFechaSqlite(FechaVencimiento)
                Linea = DocNum + "^" & Tipo_Documento & "^" & DocDate & "^" & FechaVencimiento & "^" & SALDO & "^" & CardCode & "^" & CardName & "^" & DocTotal & "^" & DocEntry & "^" & Ruta & "^" & TipoCambio & "^" & TipoCliente & "^" & NameFicticio

                'ESCRIBE LA LINEA EN EL ARCHIVO
                strStreamWriter.WriteLine(Linea)
                '  DetalleCarga = "GENERANDO ARCHIVO [ " & Linea & " ]"

                Linea = ""
                DocNum = ""
                Tipo_Documento = ""
                DocDate = ""
                FechaVencimiento = ""
                DocTotal = ""
                SALDO = ""
                CardCode = ""
                CardName = ""
                TipoCambio = ""
                TipoCliente = ""
                NameFicticio = ""
                cont2 += 1
            Next
            cont += 1

            '    cont2 = 0
            'Next

            '  DetalleCarga = "FIN DE GENERANDO ARCHIVO "
            strStreamWriter.Close() ' cerramos

            'INICIO DE LIBERIACION DE MEMORIA

            sRenglon = Nothing

            strStreamW.Dispose()
            strStreamW = Nothing

            strStreamWriter.Dispose()
            strStreamWriter = Nothing

            ContenidoArchivo = Nothing
            PathArchivo = Nothing
            i = Nothing

            Linea = Nothing

            DocNum = Nothing
            DocDate = Nothing
            FechaVencimiento = Nothing
            DocTotal = Nothing
            SALDO = Nothing
            CardCode = Nothing
            CardName = Nothing
            NameFicticio = Nothing
            'FIN DE LIBERIACION DE MEMORIA
        Catch ex As Exception
            ' Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR en Crear ( " & ex.ToString & " )"
        End Try
        Return 0

    End Function
    Public Sub Subir_A_FTP(ByVal OrigenArchivo As String, ByVal NombreArchivo As String, ByVal Ruta As String, ByVal GRUPO As String, ByVal Servidor As Integer)
        Try



            '//  obj_FTP.Subir(OrigenArchivo, "ftp://bourneycia.net/bourneycia.net/Bodegueros/Parametros/" & NombreArchivo, XMLParamFTP_user, XMLParamFTP_Password)
            If Servidor = 1 Then
                Class_VariablesGlobales.obj_FTP.Subir(OrigenArchivo, Class_VariablesGlobales.XMLParamFTP_Server & Ruta & "/impo/" & NombreArchivo, Class_VariablesGlobales.XMLParamFTP_user, Class_VariablesGlobales.XMLParamFTP_Password)
            ElseIf Servidor = 2 Then
                Class_VariablesGlobales.obj_FTP.Subir(OrigenArchivo, Class_VariablesGlobales.XMLParamFTP_Server2 & Ruta & "/impo/" & NombreArchivo, Class_VariablesGlobales.XMLParamFTP_user2, Class_VariablesGlobales.XMLParamFTP_Password2)
            End If


            'mensaje = "Sistema de actualización automática BOURNE Y CIA te informa que ya están disponible la actualización de los artículos." & vbCrLf & _
            ' "NOTA: Luego de ver este mensaje espero 2 minutos para dar actualizar " & vbCrLf & _
            '                     "Cualquier problema llamar a oficina central" & vbCrLf & vbCrLf & _
            '                     "Desarrollador: Luis Roberto Bastos C" & vbCrLf & _
            '                     "Bach: Informatica Emplesarial" & vbCrLf & _
            '                     "E-mail: lurobaca@gmail.com" & vbCrLf & _
            '                     "Tel: 8880-1662" & vbCrLf

            'envia un correo avisando al agente 
            'Obj_EnviarEMAIL.EnviarCorreo(Ruta, mensaje, "CARGA")

        Catch ex As Exception

        End Try
    End Sub
    Public Sub Eliminar(ByVal Ruta As String)


        'La primera linea definimos la ruta y el nombre del fichero a borrar, la segunda linea envia al sistema de ficheros la orden de eliminarlo.
        'Podemos incluirle Try ... Catch para controlar los errores.

        Try
            ' Dim archivo As String = "M:\IMPORTACION\AUTO SUBIDO\in_articu.mbg"

            Dim archivo As String = Ruta
            ' pregunta si desea o no eliminar
            'My.Computer.FileSystem.DeleteFile(archivo, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)

            If File.Exists(archivo) Then
                My.Computer.FileSystem.DeleteFile(archivo)
            End If

            archivo = Nothing
        Catch ex As Exception


        End Try
    End Sub
#End Region


#Region "DELIVER"
    Public Function Crear_in_ParamDeliver(ByVal TABLA As DataTable, ByVal RutaOrigen As String, ByVal carpeta As String)
        Try

            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
            Dim PathArchivo As String
            Dim i As Integer

            Dim cont As Integer = 0
            Dim Linea As String = ""



            Const quote As String = """"



            If Directory.Exists(carpeta) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(carpeta)
            End If

            Cursor.Current = Cursors.WaitCursor
            PathArchivo = RutaOrigen ' Se determina el nombre del archivo 

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            Dim CodChofer As String
            Dim Nombre As String
            Dim Telefono As String
            Dim Conse_Pedido As String
            Dim Conse_Pagos As String
            Dim Conse_Deposito As String
            Dim Conse_Gastos As String
            Dim Conse_NoVisita As String
            Dim Conse_Devoluciones As String
            Dim Correo As String
            Dim Cedula As String
            Dim Nombre_Empresa As String
            Dim Telefono_Empresa As String
            Dim Correo_Empresa As String
            Dim Web_Empresa As String
            Dim Direccion_Empresa As String
            Dim Server_Ftp As String
            Dim User_Ftp As String
            Dim Clave_Ftp As String
            Dim NumMaxFactura As String
            Dim DescMax As String
            Dim CedulaAgente As String
            Dim Conse_ClientesNuevos As String

            For Each row As DataRow In TABLA.Rows

                CodChofer = (TABLA.Rows(cont).Item("CodChofer").ToString())
                Nombre = TABLA.Rows(cont).Item("Nombre").ToString()
                Telefono = TABLA.Rows(cont).Item("Telefono").ToString()
                Conse_Pedido = TABLA.Rows(cont).Item("Conse_Pedido").ToString()
                Conse_Pagos = TABLA.Rows(cont).Item("Conse_Pagos").ToString()
                Conse_Deposito = TABLA.Rows(cont).Item("Conse_Deposito").ToString()
                Conse_Gastos = TABLA.Rows(cont).Item("Conse_Gastos").ToString()
                Conse_NoVisita = TABLA.Rows(cont).Item("Conse_NoVisita").ToString()
                Conse_Devoluciones = TABLA.Rows(cont).Item("Conse_Devoluciones").ToString()
                Correo = TABLA.Rows(cont).Item("Correo").ToString()
                Cedula = TABLA.Rows(cont).Item("Cedula").ToString()
                Nombre_Empresa = TABLA.Rows(cont).Item("Nombre_Empresa").ToString()
                Telefono_Empresa = TABLA.Rows(cont).Item("Telefono_Empresa").ToString()
                Correo_Empresa = TABLA.Rows(cont).Item("Correo_Empresa").ToString()
                Web_Empresa = TABLA.Rows(cont).Item("Web_Empresa").ToString()
                Direccion_Empresa = TABLA.Rows(cont).Item("Direccion_Empresa").ToString()
                Server_Ftp = TABLA.Rows(cont).Item("Server_Ftp").ToString()
                User_Ftp = TABLA.Rows(cont).Item("User_Ftp").ToString()
                Clave_Ftp = TABLA.Rows(cont).Item("Clave_Ftp").ToString()
                NumMaxFactura = TABLA.Rows(cont).Item("NumMaxFactura").ToString()
                DescMax = TABLA.Rows(cont).Item("DescMax").ToString()
                CedulaAgente = TABLA.Rows(cont).Item("CedulaAgente").ToString()
                Conse_ClientesNuevos = TABLA.Rows(cont).Item("Conse_ClientesNuevos").ToString()


                '  Linea = "" + quote + CardCode + quote + "," & quote & CardName & quote & "," & quote & CntctPrsn & quote & "," & quote & GroupNum & quote & "," & quote & U_Visita & quote & "," & quote & U_Descuento & quote & "," & quote & U_ClaveWeb & quote & "," & quote & SlpCode & quote
                'Linea = TABLA.Rows(cont).Item("id_agente").ToString() & "," & CInt(TABLA.Rows(cont).Item("Ulti_Consec_Pedidos").ToString()) & "," & TABLA.Rows(cont).Item("Ulti_Consec_Pagos").ToString() & "," & TABLA.Rows(cont).Item("Ulti_Consec_Depositos").ToString() & ",bourneycia.net,arquitect,tbh573,3-101-200575,Bourne&Cia S.A,Costa Rica,Guanacaste,Cañas,Frente a la escuela de sandillal,2669-6094"
                Linea = CodChofer & "," & Nombre & "," & Telefono & "," & Conse_Pedido & "," & Conse_Pagos & "," & Conse_Deposito & "," & Correo & "," & Cedula & "," & Nombre_Empresa & "," & Telefono_Empresa & "," & Correo_Empresa & "," & Web_Empresa & "," & Direccion_Empresa & "," & Server_Ftp & "," & User_Ftp & "," & Clave_Ftp & "," & NumMaxFactura & "," & DescMax & "," & CedulaAgente & "," & Conse_Gastos & "," & Conse_NoVisita & "," & Conse_Devoluciones & "," & Obj_VSegLic.Encripta(Obj_VGlobal.MisPropiedades.Valida) & "," & DescMax & "," & Conse_ClientesNuevos

                'ESCRIBE LA LINEA EN EL ARCHIVO
                strStreamWriter.WriteLine(Linea)

                Linea = ""
                cont += 1
                'Contador += 1
                ' Contador_sub += 1

            Next


            strStreamWriter.Close() ' cerramos

            'INICIO DE LIBERIACION DE MEMORIA

            sRenglon = Nothing

            strStreamW.Dispose()
            strStreamW = Nothing

            strStreamWriter.Dispose()
            strStreamWriter = Nothing

            ContenidoArchivo = Nothing
            PathArchivo = Nothing
            i = Nothing

            Linea = Nothing


            Linea = Nothing



            'FIN DE LIBERIACION DE MEMORIA


            ' Contador = 0
        Catch ex As Exception

        End Try
        Return 0

    End Function
    Public Function Crear_Cxc_Choferes(ByVal TABLACXC As DataTable, ByVal RutaOrigen As String, ByVal carpeta As String, ByVal Ruta As String)
        Try
            ' DetalleCarga = "GENERANDO ARCHIVO"
            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
            Dim PathArchivo As String
            Dim i As Integer

            Dim cont As Integer = 0
            Dim cont2 As Integer = 0
            Dim Linea As String = ""

            Dim DocEntry As String = ""
            Dim DocNum As String = ""
            Dim Tipo_Documento As String = ""
            Dim DocDate As String = ""
            Dim FechaVencimiento As String = ""
            Dim DocTotal As String = ""
            Dim SALDO As String = ""
            Dim CardCode As String = ""
            Dim CardName As String = ""
            Dim SlpCode As String = ""
            Dim TipoCambio As String = ""
            Dim TipoCliente As String = ""
            Dim NameFicticio As String = ""

            Const quote As String = """"

            If Directory.Exists(carpeta) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(carpeta)
            End If

            Cursor.Current = Cursors.WaitCursor
            PathArchivo = RutaOrigen ' Se determina el nombre del archivo 


            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            'recorre los clientes para crear el archivo de CXC
            'For Each row As DataRow In Tbl_Clientes.Rows

            'Dim TABLACXC As New DataTable
            'TABLACXC = Obj_SQL_CONEXIONSERVER.Obtiene_cxc_Choferes(Class_VariablesGlobales.SQL_Comman2, FacIni, FacFin)


            For Each row2 As DataRow In TABLACXC.Rows

                DocNum = TABLACXC.Rows(cont2).Item("DocNum").ToString()
                DocEntry = TABLACXC.Rows(cont2).Item("DocEntry").ToString()
                Tipo_Documento = TABLACXC.Rows(cont2).Item("Tipo_Documento").ToString()
                DocDate = TABLACXC.Rows(cont2).Item("DocDate").ToString().Substring(0, 10)
                FechaVencimiento = TABLACXC.Rows(cont2).Item("FechaVencimiento").ToString().Substring(0, 10)
                DocTotal = TABLACXC.Rows(cont2).Item("DocTotal").ToString()
                SALDO = TABLACXC.Rows(cont2).Item("SALDO").ToString()
                CardCode = TABLACXC.Rows(cont2).Item("CardCode").ToString()
                CardName = TABLACXC.Rows(cont2).Item("CardName").ToString()

                SlpCode = TABLACXC.Rows(cont2).Item("SlpCode").ToString()
                TipoCambio = TABLACXC.Rows(cont2).Item("TipoCambio").ToString()
                TipoCliente = TABLACXC.Rows(cont2).Item("TipoCliente").ToString()
                NameFicticio = TABLACXC.Rows(cont2).Item("NameFicticio").ToString()


                Dim fecha As Date = FechaVencimiento
                Dim hoy As Date = Now
                Dim dias As Integer

                dias = DateDiff(DateInterval.Day, fecha, hoy)
                'DocDate = Obj_FechaM.FormatFechaSqlite(DocDate)
                'FechaVencimiento = Obj_FechaM.FormatFechaSqlite(FechaVencimiento)
                Linea = DocNum + "^" & Tipo_Documento & "^" & DocDate & "^" & FechaVencimiento & "^" & SALDO & "^" & CardCode & "^" & CardName & "^" & DocTotal & "^" & DocEntry & "^" & SlpCode & "^" & TipoCambio & "^" & TipoCliente & "^" & NameFicticio

                'ESCRIBE LA LINEA EN EL ARCHIVO
                strStreamWriter.WriteLine(Linea)
                '  DetalleCarga = "GENERANDO ARCHIVO [ " & Linea & " ]"

                Linea = ""
                DocNum = ""
                Tipo_Documento = ""
                DocDate = ""
                FechaVencimiento = ""
                DocTotal = ""
                SALDO = ""
                CardCode = ""
                CardName = ""
                SlpCode = ""
                TipoCambio = ""
                TipoCliente = ""
                NameFicticio = ""

                cont2 += 1
            Next
            cont += 1

            '    cont2 = 0
            'Next

            '  DetalleCarga = "FIN DE GENERANDO ARCHIVO "
            strStreamWriter.Close() ' cerramos

            'INICIO DE LIBERIACION DE MEMORIA

            sRenglon = Nothing

            strStreamW.Dispose()
            strStreamW = Nothing

            strStreamWriter.Dispose()
            strStreamWriter = Nothing

            ContenidoArchivo = Nothing
            PathArchivo = Nothing
            i = Nothing

            Linea = Nothing

            DocNum = Nothing
            DocDate = Nothing
            FechaVencimiento = Nothing
            DocTotal = Nothing
            SALDO = Nothing
            CardCode = Nothing
            CardName = Nothing
            SlpCode = Nothing
            TipoCambio = Nothing
            TipoCliente = Nothing
            NameFicticio = Nothing
            'FIN DE LIBERIACION DE MEMORIA
        Catch ex As Exception
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR en Crear ( " & ex.ToString & " )"
        End Try
        Return 0

    End Function

    Public Function Crear_InCxc_Choferes(ByVal Tbl_Clientes As DataTable, ByVal RutaOrigen As String, ByVal carpeta As String, ByVal Ruta As String, ByVal FacIni As String, ByVal FacFin As String)
        Try
            ' DetalleCarga = "GENERANDO ARCHIVO"
            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
            Dim PathArchivo As String
            Dim i As Integer

            Dim cont As Integer = 0
            Dim cont2 As Integer = 0
            Dim Linea As String = ""

            Dim DocEntry As String = ""
            Dim DocNum As String = ""
            Dim Tipo_Documento As String = ""
            Dim DocDate As String = ""
            Dim FechaVencimiento As String = ""
            Dim DocTotal As String = ""
            Dim SALDO As String = ""
            Dim CardCode As String = ""
            Dim CardName As String = ""


            Const quote As String = """"

            If Directory.Exists(carpeta) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(carpeta)
            End If

            Cursor.Current = Cursors.WaitCursor
            PathArchivo = RutaOrigen ' Se determina el nombre del archivo 


            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            'recorre los clientes para crear el archivo de CXC
            'For Each row As DataRow In Tbl_Clientes.Rows

            Dim TABLACXC As New DataTable
            TABLACXC = Obj_SQL_CONEXIONSERVER.Obtiene_cxc_Choferes(Class_VariablesGlobales.SQL_Comman2, FacIni, FacFin)


            For Each row2 As DataRow In TABLACXC.Rows

                DocNum = TABLACXC.Rows(cont2).Item("DocNum").ToString()
                DocEntry = TABLACXC.Rows(cont2).Item("DocEntry").ToString()
                Tipo_Documento = TABLACXC.Rows(cont2).Item("Tipo_Documento").ToString()
                DocDate = TABLACXC.Rows(cont2).Item("DocDate").ToString().Substring(0, 10)
                FechaVencimiento = TABLACXC.Rows(cont2).Item("FechaVencimiento").ToString().Substring(0, 10)
                DocTotal = TABLACXC.Rows(cont2).Item("DocTotal").ToString()
                SALDO = TABLACXC.Rows(cont2).Item("SALDO").ToString()
                CardCode = TABLACXC.Rows(cont2).Item("CardCode").ToString()
                CardName = TABLACXC.Rows(cont2).Item("CardName").ToString()



                Dim fecha As Date = FechaVencimiento
                Dim hoy As Date = Now
                Dim dias As Integer

                dias = DateDiff(DateInterval.Day, fecha, hoy)
                'DocDate = Obj_FechaM.FormatFechaSqlite(DocDate)
                'FechaVencimiento = Obj_FechaM.FormatFechaSqlite(FechaVencimiento)
                Linea = DocNum + "^" & Tipo_Documento & "^" & DocDate & "^" & FechaVencimiento & "^" & SALDO & "^" & CardCode & "^" & CardName & "^" & DocTotal & "^" & DocEntry

                'ESCRIBE LA LINEA EN EL ARCHIVO
                strStreamWriter.WriteLine(Linea)
                '  DetalleCarga = "GENERANDO ARCHIVO [ " & Linea & " ]"

                Linea = ""
                DocNum = ""
                Tipo_Documento = ""
                DocDate = ""
                FechaVencimiento = ""
                DocTotal = ""
                SALDO = ""
                CardCode = ""
                CardName = ""

                cont2 += 1
            Next
            cont += 1

            '    cont2 = 0
            'Next

            '  DetalleCarga = "FIN DE GENERANDO ARCHIVO "
            strStreamWriter.Close() ' cerramos

            'INICIO DE LIBERIACION DE MEMORIA

            sRenglon = Nothing

            strStreamW.Dispose()
            strStreamW = Nothing

            strStreamWriter.Dispose()
            strStreamWriter = Nothing

            ContenidoArchivo = Nothing
            PathArchivo = Nothing
            i = Nothing

            Linea = Nothing

            DocNum = Nothing
            DocDate = Nothing
            FechaVencimiento = Nothing
            DocTotal = Nothing
            SALDO = Nothing
            CardCode = Nothing
            CardName = Nothing
            'FIN DE LIBERIACION DE MEMORIA
        Catch ex As Exception
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR en Crear ( " & ex.ToString & " )"
        End Try
        Return 0

    End Function

    'Crear archivo de Facturas desde la generacion de Reporte de facturas
    Public Function CreaArchivo_Facturas(ByVal tbl_reporte As DataTable, ByVal Id_ruta As String, ByVal ruta As String, ByVal Fac_INI As String, ByVal Fac_FIN As String, ByVal Chofer As String, ByVal Ayudante As String)

        Try


            Dim ftp_Admin As New Class_FTP

            Dim TotalRuta As Double
            Dim CONT As Integer
            Dim DocNum As String
            'Dim FechaReporte As String
            'Dim Hora As String
            Dim FechaFactura As String
            Dim CodCliente As String
            Dim Nombre As String
            Dim ItemCode As String
            Dim ItemName As String
            Dim Cant As String
            Dim Descuento As String
            Dim Precio As String
            Dim Imp As String
            Dim MontoDesc As String
            Dim MontoImp As String
            Dim Total As String

            Dim NombreRuta As String


            'Variables para crear archivos
            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
            Dim PathArchivo As String
            Dim Linea As String

            Dim Dia As String = Now.Date.Day
            Dim Mes As String = Now.Date.Month
            Dim Ano As String = Now.Date.Year

            Dim Fecha As String = Dia & "-" & Mes & "-" & Ano
            Dim RutaBase As String = "M:\IMPORTACION\Reporte_De_Facturas"


            'CREA LA CARPETA DEL DIA
            If Directory.Exists(RutaBase & "\" & Fecha) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(RutaBase & "\" & Fecha)
            End If

            'CREA LA DEL SECTOR

            If Directory.Exists(RutaBase & "\" & Fecha) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(RutaBase & "\" & Fecha)
            End If

            Cursor.Current = Cursors.WaitCursor
            'Crea el archivo
            PathArchivo = RutaBase & "\" & Fecha & "\Facturas.mbg" ' Se determina el nombre del archivo 

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura
            CONT = 0
            For Each row As DataRow In tbl_reporte.Rows

                DocNum = tbl_reporte.Rows(CONT).Item("DocNum").ToString()
                'FechaReporte = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(tbl_reporte.Rows(CONT).Item("DocDate").ToString())
                'Hora = tbl_reporte.Rows(CONT).Item("Hora").ToString()
                FechaFactura = tbl_reporte.Rows(CONT).Item("DocDate").ToString()
                CodCliente = tbl_reporte.Rows(CONT).Item("CardCode").ToString()
                Nombre = tbl_reporte.Rows(CONT).Item("CardName").ToString()
                ItemCode = tbl_reporte.Rows(CONT).Item("ItemCode").ToString()
                ItemName = tbl_reporte.Rows(CONT).Item("Dscription").ToString()
                Cant = tbl_reporte.Rows(CONT).Item("Quantity").ToString()
                Descuento = tbl_reporte.Rows(CONT).Item("DiscPrcnt").ToString()
                Precio = tbl_reporte.Rows(CONT).Item("Price").ToString()
                Imp = tbl_reporte.Rows(CONT).Item("Imp").ToString()
                MontoDesc = tbl_reporte.Rows(CONT).Item("DiscSum").ToString()
                MontoImp = tbl_reporte.Rows(CONT).Item("VatSum").ToString()
                Total = CDbl(tbl_reporte.Rows(CONT).Item("LineTotal").ToString())


                TotalRuta += Total

                If DocNum = "" Then
                    DocNum = "0"
                End If
                'If FechaReporte = "" Then
                '    FechaReporte = "0"
                'End If
                'If Hora = "" Then
                '    Hora = "0"
                'End If
                If FechaFactura = "" Then
                    FechaFactura = "0"
                End If
                If CodCliente = "" Then
                    CodCliente = "0"
                End If
                If Nombre = "" Then
                    Nombre = "0"
                End If
                If ItemCode = "" Then
                    ItemCode = "0"
                End If
                If ItemName = "" Then
                    ItemName = "0"
                End If
                If Cant = "" Then
                    Cant = "0"
                End If
                If Descuento = "" Then
                    Descuento = "0"
                End If
                If Precio = "" Then
                    Precio = "0"
                End If
                If Imp = "" Then
                    Imp = "0"
                End If
                If MontoDesc = "" Then
                    MontoDesc = "0"
                End If
                If MontoImp = "" Then
                    MontoImp = "0"
                End If
                If Total = "" Then
                    Total = "0"
                End If
                If Fac_INI = "" Then
                    Fac_INI = "0"
                End If
                If Fac_FIN = "" Then
                    Fac_FIN = "0"
                End If
                If NombreRuta = "" Then
                    NombreRuta = "0"
                End If
                If Chofer = "" Then
                    Chofer = "0"
                End If
                If Ayudante = "" Then
                    Ayudante = "0"
                End If

                Linea = Now.Date + "^" + ruta + "^" + DocNum + "^" + FechaFactura + "^" + CodCliente + "^" + ItemCode + "^" + ItemName + "^" + Cant + "^" + Descuento + "^" + Precio + "^" + Imp + "^" + MontoDesc + "^" + MontoImp + "^" + Total + "^" + Fac_INI + "^" + Fac_FIN + "^" + Chofer + "^" + Ayudante + "^" + Id_ruta

                'ESCRIBE LA LINEA EN EL ARCHIVO
                strStreamWriter.WriteLine(Linea)
                Linea = ""

                DocNum = ""
                'FechaReporte = ""
                'Hora = ""
                FechaFactura = ""
                CodCliente = ""
                Nombre = ""
                ItemCode = ""
                ItemName = ""
                Cant = ""
                Descuento = ""
                Precio = ""
                Imp = ""
                MontoDesc = ""
                MontoImp = ""
                Total = ""
                'Fac_INI = ""
                'Fac_FIN = ""
                NombreRuta = ""
                'Chofer = ""
                'Ayudante = ""

                CONT += 1
            Next

            ' LIMPIA MEMORIA
            DocNum = Nothing

            FechaFactura = Nothing
            CodCliente = Nothing
            Nombre = Nothing
            ItemCode = Nothing
            ItemName = Nothing
            Cant = Nothing
            Descuento = Nothing
            Precio = Nothing
            Imp = Nothing
            MontoDesc = Nothing
            MontoImp = Nothing
            Total = Nothing
            Fac_INI = Nothing
            Fac_FIN = Nothing
            NombreRuta = Nothing
            'Chofer = Nothing
            Ayudante = Nothing

            strStreamWriter.Close() ' cerramos
            'INICIO DE LIBERIACION DE MEMORIA
            sRenglon = Nothing
            strStreamW.Dispose()
            strStreamW = Nothing
            strStreamWriter.Dispose()
            strStreamWriter = Nothing



            'ftp_Admin.eliminarFichero("ftp://bourneycia.net/bourneycia.net/Bodegueros/Sector_" & SectorNum & "/impo/" & Consecutivo & ".mbg", "arquitect", "tbh573")

            'Sube el archivo Bodeguero

            '& Ruta & "\clientes.mbg"

            'Dim CodChofer As String = Obj_Funciones_SQL.ObtieneCodChofer(SQL_Comman, "CHOFER", Cbx_Chofer.Text)

            Try
                My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_Server & Chofer & "/impo/Facturas.mbg")
            Catch ex As Exception
            End Try
            ftp_Admin.Subir(PathArchivo, Class_VariablesGlobales.XMLParamFTP_Server & Chofer & "/impo/Facturas.mbg", Class_VariablesGlobales.XMLParamFTP_user, Class_VariablesGlobales.XMLParamFTP_Password)

        Catch ex As Exception
            MessageBox.Show("ERROR EN CreaArchivo Facturas.mbg " & ex.Message)
            VariablesGlobales.Obj_Log.Log("ERROR CreaArchivo Facturas.mbg [ " & ex.Message & " ]", "")

        End Try

    End Function
#End Region


    Public Function ObtieneTamanoFile(ByVal path As String) As String
        Dim fi As New FileInfo(path)
        If fi.Exists Then
            If (fi.Length / 1024) > 1024 Then
                Return Math.Round(((fi.Length / 1024) / 1024), 2).ToString() & " Mb"
            Else
                Return Math.Round((fi.Length / 1024), 2).ToString() & " Kb"
            End If
        Else
            Return String.Empty
        End If
    End Function


#Region "PICKING"

    Public Function Crear_ParamPicking(ByVal TABLA As DataTable, ByVal RutaOrigen As String, ByVal carpeta As String)
        Try

            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
            Dim PathArchivo As String
            Dim i As Integer

            Dim cont As Integer = 0
            Dim Linea As String = ""
            Const quote As String = """"

            If Directory.Exists(carpeta) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(carpeta)
            End If

            Cursor.Current = Cursors.WaitCursor
            PathArchivo = RutaOrigen ' Se determina el nombre del archivo 

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                Eliminar(PathArchivo)
                strStreamW = File.Create(PathArchivo) ' lo creamos
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo

            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            Dim CodBodeguero As String
            Dim Nombre As String
            Dim Cedula As String
            Dim Telefono As String
            Dim Conse_RepCarga As String
            Dim Conse_RepDevoluciones As String
            Dim Correo As String
            Dim FTP As String
            Dim Puesto As String
            Dim Sector1 As String
            Dim Sector2 As String
            Dim Sector3 As String
            Dim Sector4 As String
            Dim Sector5 As String
            Dim Sector6 As String
            Dim Sector7 As String
            Dim Sector8 As String
            Dim Sector9 As String
            Dim Sector10 As String
            Dim Server_Ftp As String
            Dim User_Ftp As String
            Dim Clave_Ftp As String
            Dim Empresa_Conse_RepCarga As String
            Dim Empresa_Conse_RepDevoluciones As String


            For Each row As DataRow In TABLA.Rows
                CodBodeguero = (TABLA.Rows(cont).Item("CodBodeguero").ToString())
                Cedula = (TABLA.Rows(cont).Item("Cedula").ToString())
                Nombre = (TABLA.Rows(cont).Item("Nombre").ToString())
                Telefono = TABLA.Rows(cont).Item("Telefono").ToString()
                Conse_RepCarga = TABLA.Rows(cont).Item("Conse_RepCarga").ToString()
                Conse_RepDevoluciones = TABLA.Rows(cont).Item("Conse_RepDevoluciones").ToString()
                Correo = TABLA.Rows(cont).Item("Correo").ToString()
                FTP = TABLA.Rows(cont).Item("FTP").ToString()
                Puesto = TABLA.Rows(cont).Item("Puesto").ToString()
                Sector1 = TABLA.Rows(cont).Item("Sector1").ToString()
                Sector2 = TABLA.Rows(cont).Item("Sector2").ToString()
                Sector3 = TABLA.Rows(cont).Item("Sector3").ToString()
                Sector4 = TABLA.Rows(cont).Item("Sector4").ToString()
                Sector5 = TABLA.Rows(cont).Item("Sector5").ToString()
                Sector6 = TABLA.Rows(cont).Item("Sector6").ToString()
                Sector7 = TABLA.Rows(cont).Item("Sector7").ToString()
                Sector8 = TABLA.Rows(cont).Item("Sector8").ToString()
                Sector9 = TABLA.Rows(cont).Item("Sector9").ToString()
                Sector10 = TABLA.Rows(cont).Item("Sector10").ToString()

                Server_Ftp = TABLA.Rows(cont).Item("Server_Ftp").ToString()
                User_Ftp = TABLA.Rows(cont).Item("User_Ftp").ToString()
                Clave_Ftp = TABLA.Rows(cont).Item("Clave_Ftp").ToString()
                Empresa_Conse_RepCarga = TABLA.Rows(cont).Item("Empresa_Conse_RepCarga").ToString()
                Empresa_Conse_RepDevoluciones = TABLA.Rows(cont).Item("Empresa_Conse_RepDevoluciones").ToString()

                Linea = CodBodeguero & "," & Nombre & "," & Conse_RepCarga & "," & Conse_RepDevoluciones & "," & Puesto & "," & Sector1 & "," & Sector2 & "," & Sector3 & "," & Sector4 & "," & Sector5 & "," & Sector6 & "," & Sector7 & "," & Sector8 & "," & Sector9 & "," & Sector10 & "," & Server_Ftp & "," & User_Ftp & "," & Clave_Ftp & "," & Empresa_Conse_RepCarga & "," & Empresa_Conse_RepDevoluciones & ","

                'ESCRIBE LA LINEA EN EL ARCHIVO
                strStreamWriter.WriteLine(Linea)
                Linea = ""
                cont += 1
            Next

            strStreamWriter.Close() ' cerramos
            'INICIO DE LIBERIACION DE MEMORIA
            sRenglon = Nothing
            strStreamW.Dispose()
            strStreamW = Nothing
            strStreamWriter.Dispose()
            strStreamWriter = Nothing
            ContenidoArchivo = Nothing
            PathArchivo = Nothing
            i = Nothing
            Linea = Nothing
            'FIN DE LIBERIACION DE MEMORIA
        Catch ex As Exception
        End Try
        Return 0
    End Function



    Public Function CreaArchivoBodegueros(ByVal tbl_Bodeguero As DataTable, ByVal Name As String)

        Try
            Dim ftp_Admin As New Class_FTP
            Dim CONT As Integer
            Dim Nombre As String
            Dim Usuarios As String
            Dim Clave As String
            Dim Puesto As String
            Dim Sector As String
            Dim Sin_chequear As String
            Dim Chequeado As String

            'Variables para crear archivos
            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
            Dim PathArchivo As String
            Dim Linea As String

            Dim Dia As String = Now.Date.Day
            Dim Mes As String = Now.Date.Month
            Dim Ano As String = Now.Date.Year

            Dim Fecha As String = Dia & "-" & Mes & "-" & Ano
            Dim RutaBase As String = Class_VariablesGlobales.XMLParamFTP_dirLocal & "Reportes_De_Carga_X_Sector"

            'CREA LA CARPETA DEL DIA
            If Directory.Exists(RutaBase & "\" & Fecha) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(RutaBase & "\" & Fecha)
            End If

            'CREA LA DEL SECTOR
            If Directory.Exists(RutaBase & "\Parametros") = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(RutaBase & "\Parametros")
            End If

            Cursor.Current = Cursors.WaitCursor
            'Crea el archivo
            If (Name.Equals("")) Then
                PathArchivo = RutaBase & "\Parametros\Parametros.mbg" ' Se determina el nombre del archivo 
            Else
                PathArchivo = RutaBase & "\Parametros\" & Name & ".mbg" ' Se determina el nombre del archivo 
            End If


            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                'strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
                If (Name.Equals("")) Then
                    My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & "Reportes_De_Carga_X_Sector\Parametros\Parametros.mbg")
                Else
                    My.Computer.FileSystem.DeleteFile(Class_VariablesGlobales.XMLParamFTP_dirLocal & "Reportes_De_Carga_X_Sector\Parametros\" & Name & ".mbg")
                End If
                strStreamW = File.Create(PathArchivo) ' lo creamos
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            For Each row As DataRow In tbl_Bodeguero.Rows
                'obtiene los datos de una linea
                Nombre = Trim(tbl_Bodeguero.Rows(CONT).Item("Nombre").ToString())
                If Nombre <> "" Then
                    Usuarios = Trim(tbl_Bodeguero.Rows(CONT).Item("Usuario").ToString())
                    Clave = Trim(tbl_Bodeguero.Rows(CONT).Item("Clave").ToString())
                    Puesto = Trim(tbl_Bodeguero.Rows(CONT).Item("Puesto").ToString())
                    Sector = Trim(tbl_Bodeguero.Rows(CONT).Item("Sector").ToString())
                    Sin_chequear = Trim(tbl_Bodeguero.Rows(CONT).Item("SinChequear").ToString())
                    Chequeado = Trim(tbl_Bodeguero.Rows(CONT).Item("Chequeado").ToString())
                    'crea el archivo lo abre he inserta los datos
                    If Nombre = "" Then
                        Nombre = "0"
                    End If
                    If Usuarios = "" Then
                        Usuarios = "0"
                    End If
                    If Clave = "" Then
                        Clave = "0"
                    End If
                    If Puesto = "" Then
                        Puesto = "0"
                    End If
                    If Sector = "" Then
                        Sector = "0"
                    End If
                    If Sin_chequear = "" Then
                        Sin_chequear = "0"
                    End If
                    If Chequeado = "" Then
                        Chequeado = "0"
                    End If
                    Linea = Now.Date + "," + Nombre + "," + Usuarios + "," + Clave + "," + Puesto + "," + Sector + "," + Sin_chequear + "," + Chequeado
                    'ESCRIBE LA LINEA EN EL ARCHIVO
                    strStreamWriter.WriteLine(Linea)
                End If
                Linea = ""
                CONT += 1
            Next
            ' LIMPIA MEMORIA
            CONT = Nothing
            strStreamWriter.Close() ' cerramos
            'INICIO DE LIBERIACION DE MEMORIA
            sRenglon = Nothing
            strStreamW.Dispose()
            strStreamW = Nothing
            strStreamWriter.Dispose()
            strStreamWriter = Nothing

            If (Name.Equals("")) Then
                ftp_Admin.eliminarFichero(Class_VariablesGlobales.XMLParamFTP_Server & "Bodegueros/Sector_0/Parametros.mbg", Class_VariablesGlobales.XMLParamFTP_user, Class_VariablesGlobales.XMLParamFTP_Password)
                ftp_Admin.Subir(PathArchivo, Class_VariablesGlobales.XMLParamFTP_Server & "Bodegueros/Sector_0/Parametros.mbg", Class_VariablesGlobales.XMLParamFTP_user, Class_VariablesGlobales.XMLParamFTP_Password)
            Else
                ftp_Admin.eliminarFichero(Class_VariablesGlobales.XMLParamFTP_Server & "Bodegueros/Sector_0/" & Name & ".mbg", Class_VariablesGlobales.XMLParamFTP_user, Class_VariablesGlobales.XMLParamFTP_Password)
                ftp_Admin.Subir(PathArchivo, Class_VariablesGlobales.XMLParamFTP_Server & "Bodegueros/Sector_0/" & Name & ".mbg", Class_VariablesGlobales.XMLParamFTP_user, Class_VariablesGlobales.XMLParamFTP_Password)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR EN CreaArchivo  " & ex.Message)
        End Try
    End Function
#End Region


End Class
