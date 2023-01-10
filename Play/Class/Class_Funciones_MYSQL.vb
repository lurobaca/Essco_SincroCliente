Imports MySql.Data.MySqlClient
Imports System.Data.Odbc
Imports System.Data.SqlClient


Public Class Class_Funciones_MYSQL
    Public CNX_1 As New SqlConnection




    Public Sub New()
        Try

        Catch ex As Exception

        End Try
    End Sub


    Public Function ObtieneDevolucionesDelDia(ItemCode As String, Fecha As String)
        Try


            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim ADATER As New OdbcDataAdapter
            Dim TABLA As New DataTable


            Dim Consulta As String = "SELECT SUBSTRING(DocNum,1,2) as Ruta,DocNum,ItemCode,ItemName,Cant_Uni as Cantidad,CodCliente,Nombre FROM `Seller_Devoluciones` where Fecha = '" & Fecha & "' and ItemCode='" & ItemCode & "' and Motivo <> 'M10:Producto Danado'  "
            ADATER = New OdbcDataAdapter(Consulta, Class_VariablesGlobales.MYSQ_Comman.Connection)

            ADATER.Fill(TABLA)
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing

            'Obj_VarGlobal.Obj_CX_MYSQL.Desconectar(Class_VariablesGlobales.MYSQ_Comman.Connection)

            Return TABLA
        Catch ex As Exception
            Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            ObtieneDevolucionesDelDia(ItemCode, Fecha)

            'MsgBox("Error al ObtieneDevolucionesDelDia " & ex.Message)

        End Try
    End Function


    Public Function ObtienePedidosDelDia(ItemCode As String, Fecha As String)
        'Obtiene los pedidos en la nube aun que estos puede que ya hayan sido transmisidos por lo que hay que desartar los que ya se transmitieron
        Try

            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim ADATER As New OdbcDataAdapter
            Dim TABLA As New DataTable


            Dim Consulta As String = "SELECT SUBSTRING(DocNum,1,2) as Ruta,DocNum,CodCliente,Nombre,ItemCode,ItemName,Cant_Uni as Cantidad FROM `Seller_Pedido` where Fecha = '" & Fecha & "' and ItemCode='" & ItemCode & "'  "
            ADATER = New OdbcDataAdapter(Consulta, Class_VariablesGlobales.MYSQ_Comman.Connection)

            ADATER.Fill(TABLA)
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            'Obj_VarGlobal.Obj_CX_MYSQL.Desconectar(Class_VariablesGlobales.MYSQ_Comman.Connection)


            Return TABLA
        Catch ex As Exception
            Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            ObtienePedidosDelDia(ItemCode, Fecha)

            'MsgBox("Error al ObtieneDevolucionesDelDia " & ex.Message)

        End Try
    End Function

    Public Sub GuardaGrupo(ByVal CodGrupo As String, ByVal IdInventario As String)
        Try
            Dim Consulta As String
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Consulta = "INSERT INTO `arquitect_bourne`.`Inv_ConActivo`(`Grupo`, `Conteo`,`IdInventario`) VALUES ('" & CodGrupo & "','1','" & IdInventario & "');"
            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()

            Consulta = "INSERT INTO `arquitect_bourne`.`Inv_ConActivo`(`Grupo`, `Conteo`,`IdInventario`) VALUES ('" & CodGrupo & "','2','" & IdInventario & "');"
            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()
        Catch ex As Exception
            GuardaGrupo(CodGrupo, IdInventario)
            MsgBox(ex.Message)

        End Try
    End Sub


    Public Sub EliminaGrupo(ByVal CodGrupo As String)
        Try
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim Consulta As String
            Consulta = "DELETE FROM `Inv_ConActivo` where Grupo='" & CodGrupo & "'"
            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()
        Catch ex As Exception

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
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim Consulta As String

            If Grupo = "" Then
                Consulta = "DELETE FROM `arquitect_bourne`.`Inv_Grupos` ;"
            Else
                Consulta = "DELETE FROM `arquitect_bourne`.`Inv_Grupos` WHERE Grupo='" & Grupo & "';"
            End If

            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Public Sub ConteoActivo()
        Try
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim Consulta As String
            Consulta = "DELETE FROM `arquitect_bourne`.`Inv_ConActivo` ;"
            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Public Sub BorraGrupoConteo(ByVal idGrupo As String)
        Try
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim Consulta As String
            Consulta = "DELETE FROM `arquitect_bourne`.`Inv_Grupos` where `idGrupo`= '" & idGrupo & "' ;"
            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Public Sub BorraConteo(ByVal idGrupo As String, ByVal IdInventario As String)
        Try
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim Consulta As String
            Consulta = "DELETE FROM `Inv_Conteos` WHERE `Grupo`='" & idGrupo & "' and `IdInventario`='" & IdInventario & "'"
            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()
        Catch ex As Exception

            BorraConteo(idGrupo, IdInventario)
            MsgBox(ex.Message)

        End Try
    End Sub

    Public Sub InsertConteo(ByVal CodGrupo As String, ByVal CodArticulo As String, ByVal IdInventario As String, ByVal Conte As Integer, ByVal CodProveedor As String)
        Try
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim Consulta As String
            Consulta = "INSERT INTO `arquitect_bourne`.`Inv_Conteos` (`IdInventario`, `Grupo`, `NumConteo`, `CodArticulo`, `Cuenta`, `Reconteo`, `CodProveedor`) VALUES ('" & IdInventario & "', '" & CodGrupo & "', '" & Conte & "','" & CodArticulo & "', '0', '0','" & CodProveedor & "');"

            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("ERROR en InsertConteo: " & ex.Message)
        End Try
    End Sub


    Public Sub GuardaGrupoConteo(ByVal idGrupo As String, ByVal Responsable As String, ByVal Acompañante As String, ByVal CodProveedor As String, ByVal NombreProveedor As String, ByVal CodInventario As String)
        Try

            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim Consulta As String
            Consulta = "INSERT INTO `arquitect_bourne`.`Inv_Grupos` (`idGrupo`, `Responsable`, `Acompanante`, `CodProveedor`, `NombreProveedor`, `CodInventario`) VALUES ('" & idGrupo & "', '" & Responsable & "', '" & Acompañante & "', '" & CodProveedor & "', '" & NombreProveedor & "', '" & CodInventario & "');"
            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("ERROR EN GuardaGrupoConteo" & ex.Message)

        End Try
    End Sub
    Public Function ConpruebaProveedor(ByVal CodGrupo As String, ByVal CodProveedor As String, ByVal IdInventario As String)
        Try


            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim ADATER As New OdbcDataAdapter
            Dim TABLA As New DataTable


            Dim Consulta As String = "SELECT COUNT(NumConteo) as Conto FROM `Inv_Conteos` where CodProveedor='" & CodProveedor & "' and Grupo ='" & CodGrupo & "'  and NumConteo=1 and IdInventario='" & IdInventario & "'"
            ADATER = New OdbcDataAdapter(Consulta, Class_VariablesGlobales.MYSQ_Comman.Connection)

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


            Return RET
        Catch ex As Exception

            Return ConpruebaProveedor(CodGrupo, CodProveedor, IdInventario)
            MsgBox(ex.Message)

        End Try
    End Function

    Public Function ObtieneIdInventario()
        Try
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim ADATER As New OdbcDataAdapter
            Dim TABLA As New DataTable

            Dim Consulta As String = "SELECT  id FROM `Inv_Registro`  ORDER BY id DESC LIMIT 1"

            ADATER = New OdbcDataAdapter(Consulta, Class_VariablesGlobales.MYSQ_Comman.Connection)

            ADATER.Fill(TABLA)
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            Return TABLA.Rows(0).Item("id").ToString()
        Catch ex As Exception
            Return ObtieneIdInventario()
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ObtieneIdInventario ( " & ex.Message & " )"
        End Try
    End Function


    Public Sub CreaRegConteos(ByVal Titulo As String, ByVal comentarioa As String)
        Try

            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim Consulta As String
            Consulta = "INSERT INTO `arquitect_bourne`.`Inv_Registro` (`id`, `Fecha`, `Titulo`, `Comentario`, `Cerrado`, `InvInicial`,`InvFinal`,`ENTRADAS`,`SALIDAS`,`DIFERENCIAS`) VALUES (NULL, '" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Now.Date) & "', '" & Titulo & "', '" & comentarioa & "','0',0,0,0,0,0);"
            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("ERROR EN CreaRegConteos : " & ex.Message)
        End Try

    End Sub
    Public Sub ActualizaRegConteos(ByVal id As String, ByVal InvInicial As Double)
        Try

            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim Consulta As String
            Consulta = "UPDATE `inv_registro` SET `InvInicial`=" & InvInicial & " WHERE `id`=" & id
            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("ERROR EN ActualizaRegConteos : " & ex.Message)
        End Try
    End Sub



    Public Function ActualizaStocks(ByVal IdInventario As String, ByVal Codigo As String, ByVal Stock_b1 As Integer, ByVal Monto_B1 As Double)
        Try

            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            'Dim Consulta As String = "UPDATE  `Conteo` SET `Stock_b1`= '" & Stock_b1 & "',`Stock_b2`= '" & Stock_b2 & "',`Stock_b3`= '" & Stock_b3 & "',`Stock_b4`= '" & Stock_b4 & "',`Stock_b5`= '" & Stock_b5 & "',`Stock_b6`= '" & Stock_b6 & "' ,`Monto_B1`= " & Monto_B1 & ",`Monto_B2`= " & Monto_B2 & ",`Monto_B3`= " & Monto_B3 & ",`Monto_B4`= " & Monto_B4 & ",`Monto_B5`= " & Monto_B5 & ",`Monto_B6`= " & Monto_B6 & "  WHERE `IdInventario`='" & IdInventario & "' AND `Codigo`='" & Codigo & "'"

            'actualiza el stock del conteo
            Dim Consulta As String = "UPDATE `Inv_Inventario` SET `Stock`='" & Stock_b1 & "',`Monto`='" & Monto_B1 & "' where `IdInventario`='" & IdInventario & "' and`Codigo`='" & Codigo & "'"

            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()
            Consulta = Nothing

        Catch ex As Exception
            ActualizaStocks(IdInventario, Codigo, Stock_b1, Monto_B1)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ActualizaStocks ( " & ex.Message & " )"
        End Try
    End Function
    Public Function NoRecuenta(ByVal idInventario As String, ByVal Codigo As String, ByVal idGrupo As String, ByVal NumConteo As Integer, ByVal Cuenta As Integer)
        Try
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim Consulta As String
            Consulta = "UPDATE `Inv_Conteos` SET `Reconteo`='1',`Cuenta`='" & Cuenta & "' where `IdInventario`='" & idInventario & "' and `CodArticulo`='" & Codigo & "' AND Grupo='" & idGrupo & "' AND NumConteo='" & NumConteo & "'"

            'Consulta = "UPDATE  `Conteo` SET `Reconteo`= '1' WHERE `IdInventario`='" & idInventario & "' AND `Codigo`='" & Codigo & "' "
            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()
            Consulta = Nothing

        Catch ex As Exception

            'CNX_1 = Obj_SQL_CONEXION_CONEXION.Conectar(Class_VariablesGlobales.XMLParamSQL_dababase, CNX_1)
            'Class_VariablesGlobales.SQL_Comman1.Connection = CNX_1

            'MsgBox("Error NoRecuenta Codigo : " & Codigo)
            NoRecuenta(idInventario, Codigo, idGrupo, NumConteo, Cuenta)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ReconteoAjustada ( " & ex.Message & " )"
        End Try
    End Function
    Public Function Recuenta(ByVal idInventario As String, ByVal Codigo As String, ByVal idGrupo As String, ByVal NumConteo As String, ByVal Cuenta As Integer)
        Try

            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim Consulta As String

            Consulta = "UPDATE `Inv_Conteos` SET `Reconteo`='0',`Cuenta`='' where `IdInventario`='" & idInventario & "' and `CodArticulo`='" & Codigo & "' AND Grupo='" & idGrupo & "' AND NumConteo='" & NumConteo & "'"
            '  Consulta = "UPDATE  `Conteo` SET `Reconteo`= '0' WHERE `IdInventario`='" & idInventario & "' AND `Codigo`='" & Codigo & "' "
            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()
            Consulta = Nothing

        Catch ex As Exception
            Recuenta(idInventario, Codigo, idGrupo, NumConteo, Cuenta)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ReconteoAjustada ( " & ex.Message & " )"
        End Try
    End Function

    Public Function ActualizaConteo(ByVal idInventario As String, ByVal Codigo As String, ByVal Grupo As String, ByVal Cuenta As String, ByVal NumConteo As String)
        Try

            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim Consulta As String
            Consulta = "UPDATE `Inv_Conteos` SET `Cuenta`='" & Cuenta & "' where `IdInventario`='" & idInventario & "' and `CodArticulo`='" & Codigo & "' and Grupo='" & Grupo & "' and NumConteo='" & NumConteo & "'"
            '  Consulta = "UPDATE  `Conteo` SET `Reconteo`= '0' WHERE `IdInventario`='" & idInventario & "' AND `Codigo`='" & Codigo & "' "
            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()
            Consulta = Nothing

        Catch ex As Exception
            ActualizaConteo(idInventario, Codigo, Grupo, Cuenta, NumConteo)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ReconteoAjustada ( " & ex.Message & " )"
        End Try
    End Function


    Public Function Stock(ByVal CodArticulo As String)
        Try
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim ADATER As New OdbcDataAdapter
            Dim TABLA As New DataTable

            'Dim Consulta As String = "SELECT `C1`,`C2`,`C3`,`C4`,`C5`,`C6`,`C7`,`C8` FROM `Grupos` WHERE `CodGrupo`='" & Grupo & "'"
            Dim Consulta As String = "SELECT Stock FROM `Inv_Inventario` where Codigo='" & CodArticulo & "'"
            ADATER = New OdbcDataAdapter(Consulta, Class_VariablesGlobales.MYSQ_Comman.Connection)

            ADATER.Fill(TABLA)

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
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim ADATER As New OdbcDataAdapter
            Dim TABLA As New DataTable

            'Dim Consulta As String = "SELECT `C1`,`C2`,`C3`,`C4`,`C5`,`C6`,`C7`,`C8` FROM `Grupos` WHERE `CodGrupo`='" & Grupo & "'"
            Dim Consulta As String = "SELECT Costo FROM `Inv_Inventario` where Codigo='" & CodArticulo & "'"
            ADATER = New OdbcDataAdapter(Consulta, Class_VariablesGlobales.MYSQ_Comman.Connection)

            ADATER.Fill(TABLA)

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

    Public Function ConteoActivoDelGrupo(ByVal Grupo As String)
        Try
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim ADATER As New OdbcDataAdapter
            Dim TABLA As New DataTable

            'Dim Consulta As String = "SELECT `C1`,`C2`,`C3`,`C4`,`C5`,`C6`,`C7`,`C8` FROM `Grupos` WHERE `CodGrupo`='" & Grupo & "'"
            Dim Consulta As String = "SELECT Conteo FROM `Inv_ConActivo` where Grupo='" & Grupo & "'"
            ADATER = New OdbcDataAdapter(Consulta, Class_VariablesGlobales.MYSQ_Comman.Connection)

            ADATER.Fill(TABLA)
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            Return TABLA

        Catch ex As Exception
            Return ConteoActivoDelGrupo(Grupo)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ConteoActivoDelGrupo ( " & ex.Message & " )"
        End Try
    End Function


    Public Function Unifica(ByVal Proveeodr As String)
        Try
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim ADATER As New OdbcDataAdapter
            Dim TABLA As New DataTable

            Dim Consulta As String = "SELECT CodArticulo,SUM(Cuenta) AS Conteo FROM `Inv_Conteos` WHERE CodProveedor='" & Proveeodr & "' AND NumConteo='3' GROUP BY CodArticulo ORDER BY CodArticulo DESC"
            ADATER = New OdbcDataAdapter(Consulta, Class_VariablesGlobales.MYSQ_Comman.Connection)

            ADATER.Fill(TABLA)

            Return (TABLA)
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
        Catch ex As Exception
            Return Unifica(Proveeodr)

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR Unifica ( " & ex.Message & " )"
        End Try
    End Function
    Public Function BloqueaAccesoGrupo(ByVal Grupo As String, ByVal HabilitaConteo As String, ByVal Valor As String, ByVal Accion As String)
        Try

            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim Consulta As String

            If Accion = "Borra" Then
                Consulta = "DELETE FROM `Inv_ConActivo` WHERE `Conteo`='" & Valor & "' AND `Grupo`='" & Grupo & "'"
            Else
                Consulta = "INSERT INTO `arquitect_bourne`.`Inv_ConActivo` (`Grupo`, `Conteo`) VALUES ('" & Grupo & "', '" & Valor & "');"
            End If

            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()
            Consulta = Nothing

        Catch ex As Exception
            BloqueaAccesoGrupo(Grupo, HabilitaConteo, Valor, Accion)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR BloqueaAccesoGrupo ( " & ex.Message & " )"
        End Try
    End Function

    Public Function SectorGrupo(ByVal Sector As String, ByVal Grupo As String, ByVal IdInventario As String)

        Try

            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim Consulta As String

            Consulta = "UPDATE `Conteo` SET `CodG1`='" & Grupo & "' WHERE `Sector`='" & Sector & "' and `IdInventario`='" & IdInventario & "'"
            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()
            Consulta = Nothing

        Catch ex As Exception

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ReconteoAjustada ( " & ex.Message & " )"
        End Try
    End Function


    Public Function ComparaConteos(ByVal Grupo As String, ByVal IdInventario As String)

        '
        Try
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If
            Dim MyDataSet As DataSet
            Dim ADATER As New OdbcDataAdapter
            Dim TABLA As New DataTable
            Dim ListaProveedores As New DataTable
            Dim Consulta As String
            Dim CodG1 As String
            Dim cuenta As Integer = 0
            'Obtiene los proveedores asinganados al grupo

            'Consulta = "SELECT T0.IdInventario,T0.Codigo,(SELECT Cuenta FROM `Inv_Conteos` where NumConteo=1 and CodArticulo=T0.Codigo and  Grupo='A' and IdInventario='32') as C1 ,(SELECT Cuenta FROM `Inv_Conteos` where NumConteo=2 and CodArticulo=T0.Codigo and  Grupo='A' and IdInventario='32') as C2,T0.CodProveedor FROM `Inv_Inventario` T0 WHERE T0.IdInventario='32' and (`CodProveedor`='P062') "

            ListaProveedores = ObtieneListaProveedores(Grupo)
            Consulta = "SELECT T0.IdInventario,T0.Codigo,(SELECT Cuenta FROM `Inv_Conteos` where NumConteo=1 and CodArticulo=T0.Codigo and  Grupo='" & Grupo & "' and IdInventario='" & IdInventario & "') as C1 ,(SELECT Cuenta FROM `Inv_Conteos` where NumConteo=2 and CodArticulo=T0.Codigo and  Grupo='" & Grupo & "' and IdInventario='" & IdInventario & "') as C2,T0.CodProveedor FROM `Inv_Inventario` T0 WHERE T0.IdInventario='" & IdInventario & "' and ("

            'recorre la lista de proveedores para generar la formula
            If ListaProveedores.Rows.Count > 0 Then
                For Each row As DataRow In ListaProveedores.Rows
                    Consulta = Consulta & "`CodProveedor`='" & ListaProveedores.Rows(cuenta).Item("CodProveedor").ToString() & "'"
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

            ADATER = New OdbcDataAdapter(Consulta, Class_VariablesGlobales.MYSQ_Comman.Connection)

            ADATER.Fill(MyDataSet)

            For Each row As DataRow In MyDataSet.Tables(0).Rows

                Dim id As String = row("ID_CLIENTE")
                Dim nombre As String = row("Nombre")

            Next



            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
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
    Public Function CompruebaCruce(ByVal Grupo As String)
        Try

            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim ADATER As New OdbcDataAdapter
            Dim TABLA As New DataTable
            Dim ListaProveedores As New DataTable
            Dim Consulta As String
            Dim CodG1 As String
            Dim cuenta As Integer = 0

            Dim retorna As Integer = 0
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Consulta = "SELECT MAX(Conteo) as Conto FROM `Inv_ConActivo` where Grupo ='" & Grupo & "'"

            ADATER = New OdbcDataAdapter(Consulta, Class_VariablesGlobales.MYSQ_Comman.Connection)

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
            Return retorna
        Catch ex As Exception
            MsgBox(ex.Message)

            CompruebaCruce(Grupo)


            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CompruebaCruce ( " & ex.Message & " )"
        End Try

    End Function

    Public Function Corrige(ByVal idInventario As String)
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
        tablas = ObtieneInvControl("", "0", "0", "", idInventario, False)
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

            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            ' Dim Consulta As String = "UPDATE  `Conteo` SET `D1`= '" & D1 & "',`D2`= '" & D2 & "',`D3`= '" & D3 & "',`D4`= '" & D4 & "',`D5`= '" & D5 & "',`D6`= '" & D6 & "' ,`D7`= " & D7 & ",`D8`= " & D8 & ",`DF`= " & DF & ",`MD1`= " & MD1 & ",`MD2`= " & MD2 & ",`MD3`= " & MD3 & ",`MD4`= " & MD4 & ",`MD5`= " & MD5 & ",`MD6`= " & MD6 & ",`MD7`= " & MD7 & ",`MD8`= " & MD8 & ",`DFM`= " & MDF & ",`costo`= " & costo & " ,`CF`= " & CF & " WHERE `IdInventario`='" & IdInventario & "' AND `Codigo`='" & Codigo & "'"


            Dim Consulta As String = "UPDATE `Inv_Inventario` SET `CF`='" & CF & "',`DF`='" & DF & "',`DFM`='" & MDF & "' WHERE `IdInventario`='" & IdInventario & "' AND`Codigo`='" & Codigo & "'"
            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()
            Consulta = Nothing

        Catch ex As Exception
            ActualizaDiferencias(IdInventario, Codigo, MDF, CF, DF)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ActualizaDiferencias ( " & ex.Message & " )"
        End Try
    End Function

    Public Function ObtieneInventarios()
        Try
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim ADATER As New OdbcDataAdapter
            Dim TABLA As New DataTable

            Dim Consulta As String = "SELECT  id,Fecha,Titulo,Comentario,Cerrado,InvInicial,InvFinal,ENTRADAS,SALIDAS,DIFERENCIAS FROM `Inv_Registro`   ORDER BY id desc "

            ADATER = New OdbcDataAdapter(Consulta, Class_VariablesGlobales.MYSQ_Comman.Connection)

            ADATER.Fill(TABLA)
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            Return TABLA
        Catch ex As Exception
            Return ObtieneInventarios()
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ObtieneIdInventario ( " & ex.Message & " )"
        End Try
    End Function
    Public Function ObtieneConteosActivosGrupos()
        Try

            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim ADATER As New OdbcDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String

            Consulta = "SELECT * FROM `Inv_ConActivo` "

            ADATER = New OdbcDataAdapter(Consulta, Class_VariablesGlobales.MYSQ_Comman.Connection)

            ADATER.Fill(TABLA)
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            Return TABLA
        Catch ex As Exception

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ObtieneIdInventario ( " & ex.Message & " )"
        End Try
    End Function
    Public Function GruposConteo()
        Try
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim ADATER As New OdbcDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String

            Consulta = "SELECT  `idGrupo`, `Responsable`, `Acompanante` , `CodInventario`FROM `Inv_Grupos` GROUP BY `idGrupo`"

            ADATER = New OdbcDataAdapter(Consulta, Class_VariablesGlobales.MYSQ_Comman.Connection)

            ADATER.Fill(TABLA)
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            Return TABLA
        Catch ex As Exception

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR GruposConteo ( " & ex.Message & " )"
        End Try
    End Function

    Public Function OptieneCasaXGRupo(ByVal idGrupo As String)
        Try
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim ADATER As New OdbcDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String

            Consulta = "SELECT  `CodProveedor`, `NombreProveedor` FROM `Inv_Grupos` WHERE `idGrupo`='" & idGrupo & "'"

            ADATER = New OdbcDataAdapter(Consulta, Class_VariablesGlobales.MYSQ_Comman.Connection)

            ADATER.Fill(TABLA)
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            Return TABLA
        Catch ex As Exception

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR GruposConteo ( " & ex.Message & " )"
        End Try
    End Function
    Public Function ObtieneInvControl(ByVal Proveedor As String, ByVal Df_Mayores As Integer, ByVal Df_Menores As Integer, ByVal Busqueda As String, ByVal IdInventario As String, ByVal detallado As Boolean)
        Try
            'Obtiene el inventario junto a todos los conteos hechos
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim ADATER As New OdbcDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String
            Consulta = "SELECT T0.IdInventario,T0.CodProveedor,T0.NameProveedor,T0.Fecha,T0.Codigo,T0.Descripcion,T0.CodBarras,T0.Sector,T0.Costo,T0.Stock,T0.CF,T0.DF,T0.DFM,T0.Monto"
            If detallado = True Then

                Consulta = Consulta & ","
                'Obtiene el conteo max realizado
                Dim ContMAx As Integer = ObtieneMaxConteoHecho(IdInventario)
                Dim recorre As Integer = 1
                Dim Prueba As Integer = 0

                While recorre <= ContMAx
                    Consulta = Consulta & "(CASE WHEN (SELECT   SUM(Cuenta) as Cuenta  FROM `Inv_Conteos` WHERE CodArticulo=T0.Codigo AND  `IdInventario`='" & IdInventario & "' and `NumConteo`='" & recorre & "' GROUP BY CodArticulo,NumConteo) IS NULL THEN 0 ELSE (SELECT   SUM(Cuenta) as Cuenta  FROM `Inv_Conteos` WHERE CodArticulo=T0.Codigo AND  `IdInventario`='" & IdInventario & "' and `NumConteo`='" & recorre & "' GROUP BY CodArticulo,NumConteo) END)as C" & recorre & "," &
                                "((CASE WHEN (SELECT   SUM(Cuenta) as Cuenta  FROM `Inv_Conteos` WHERE CodArticulo=T0.Codigo AND  `IdInventario`='" & IdInventario & "' and `NumConteo`='" & recorre & "' GROUP BY CodArticulo,NumConteo) IS NULL THEN 0 ELSE (SELECT   SUM(Cuenta) as Cuenta  FROM `Inv_Conteos` WHERE CodArticulo=T0.Codigo AND  `IdInventario`='" & IdInventario & "' and `NumConteo`='" & recorre & "' GROUP BY CodArticulo,NumConteo) END) - T0.Stock) AS DF" & recorre & "," &
                                "(((CASE WHEN (SELECT   SUM(Cuenta) as Cuenta  FROM `Inv_Conteos` WHERE CodArticulo=T0.Codigo AND  `IdInventario`='" & IdInventario & "' and `NumConteo`='" & recorre & "' GROUP BY CodArticulo,NumConteo) IS NULL THEN 0 ELSE (SELECT   SUM(Cuenta) as Cuenta  FROM `Inv_Conteos` WHERE CodArticulo=T0.Codigo AND  `IdInventario`='" & IdInventario & "' and `NumConteo`='" & recorre & "' GROUP BY CodArticulo,NumConteo) END) - T0.Stock) *T0.Costo) AS MD" & recorre

                    Prueba = recorre
                    If Prueba + 1 <= ContMAx Then
                        Consulta = Consulta & ","
                    End If

                    recorre += 1
                End While
            Else

            End If

            Consulta = Consulta & " FROM `Inv_Inventario` T0 "

            'SI ESTA BUSCANDO CON ALGUN FILTRO ENTRA A GENERAR EL WHERE
            If Proveedor <> "" Or Df_Mayores > 0 Or Df_Menores < 0 Or Busqueda <> "" Then
                Consulta = Consulta & " where IdInventario='" & IdInventario & "'"

                If Proveedor <> "" Then
                    Consulta = Consulta & "  and CodProveedor='" & Proveedor & "' "
                End If
                If Df_Mayores > 0 Or Df_Menores < 0 Then
                    Consulta = Consulta & " AND (DFM > '" & Df_Mayores & "' OR DFM < '" & Df_Menores & "') "
                End If
                If Busqueda <> "" Then
                    Consulta = Consulta & " and `Descripcion` like '%" & Busqueda & "%'"
                End If

            End If


            'If Proveedor <> "" Then

            '    If Df_Mayores > 0 Or Df_Menores < 0 Then
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


            Consulta = Consulta & " ORDER BY Codigo ASC"

            ADATER = New OdbcDataAdapter(Consulta, Class_VariablesGlobales.MYSQ_Comman.Connection)

            ADATER.Fill(TABLA)
            Return TABLA
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing

        Catch ex As Exception

            Return ObtieneInvControl(Proveedor, Df_Mayores, Df_Menores, Busqueda, IdInventario, detallado)
            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ObtieneIdInventario ( " & ex.Message & " )"
        End Try
    End Function



    Public Function DetConteo(ByVal IdInventario As String, ByVal CodArticulo As String)
        Try
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim ADATER As New OdbcDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String

            Consulta = "SELECT T0.Grupo,T0.NumConteo,T0.Cuenta,T0.CodArticulo,(SELECT `Descripcion` FROM `Inv_Inventario` WHERE `Codigo`=T0.CodArticulo AND IdInventario='" & IdInventario & "') as Nombre,(SELECT `Stock` FROM `Inv_Inventario` WHERE `Codigo`=T0.CodArticulo  AND IdInventario='" & IdInventario & "') as Stock FROM `Inv_Conteos` T0 where T0.CodArticulo='" & CodArticulo & "' and T0.IdInventario='" & IdInventario & "' order by T0.Grupo"

            ADATER = New OdbcDataAdapter(Consulta, Class_VariablesGlobales.MYSQ_Comman.Connection)

            ADATER.Fill(TABLA)
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
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim ADATER As New OdbcDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String

            Consulta = "SELECT  max(`NumConteo`) as NumConteos FROM `Inv_Conteos` WHERE `IdInventario`='" & IdInventario & "'"

            ADATER = New OdbcDataAdapter(Consulta, Class_VariablesGlobales.MYSQ_Comman.Connection)

            ADATER.Fill(TABLA)
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing


            Dim MAX As Integer
            If TABLA.Rows(0).Item("NumConteos").ToString() = "" Then
                MAX = 1
            Else
                MAX = TABLA.Rows(0).Item("NumConteos").ToString()
            End If




            Return MAX



        Catch ex As Exception

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR GruposConteo ( " & ex.Message & " )"
        End Try
    End Function
    Public Function ActualizaMontDifConte(ByVal IdInventario As String, ByVal Codigo As String, ByVal CF As String, ByVal DF As String, ByVal DFM As Double)

        Try

            Dim Consulta As String
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Consulta = "UPDATE `Inv_Inventario` SET `CF`='" & CF & "',`DF`='" & DF & "',`DFM`='" & DFM & "' WHERE `IdInventario`='" & IdInventario & "' and `Codigo`='" & Codigo & "'"


            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()
            Consulta = Nothing

        Catch ex As Exception

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ActualizaStocks ( " & ex.Message & " )"
        End Try
    End Function
    Public Function CierraInventario(ByVal IdInventario As String, ByVal Entradas As Double, ByVal Salidas As Double, ByVal Diferencias As Double, ByVal InvFinal As Double)
        Try
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim Consulta As String = ""
            Consulta = "UPDATE  `Inv_Inventario` SET `Cerrado`= '1'  WHERE `IdInventario`='" & IdInventario & "'"

            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()

            Consulta = "UPDATE  `Conteo` SET `Cerrado`= '1'  WHERE `IdInventario`='" & IdInventario & "'"

            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()

            Consulta = "UPDATE  `Inv_Registro` SET `Cerrado`= '1',`InvFinal`=" & InvFinal & ",`ENTRADAS`=" & Entradas & ",`SALIDAS`=" & Salidas & ",`DIFERENCIAS`=" & Diferencias & "  WHERE `Id`='" & IdInventario & "'"

            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()




            Consulta = Nothing

        Catch ex As Exception

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR CierraInventario ( " & ex.Message & " )"
        End Try
    End Function

    Public Function ObtieneInvConteo(ByVal ConteoActivo As String, ByVal CodInventario As String, ByVal Grupo As String)
        Try

            'Obtiene solo los conteos realizados en el conteo a cruzar y que esta activo del grupo indicado
            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If


            Dim ADATER As New OdbcDataAdapter
            Dim TABLA As New DataTable
            Dim ListaProveedores As New DataTable
            Dim Consulta As String
            Dim CodG1 As String
            Dim cuenta As Integer = 0
            'Obtiene los proveedores asinganados al grupo
            ListaProveedores = ObtieneListaProveedores(Grupo)

            Consulta = "SELECT T0.CF as Conteo,T0.Stock,T0.Codigo,T0.Costo,T0.CodProveedor FROM  `Inv_Inventario` T0 WHERE T0.IdInventario='" & CodInventario & "' AND ("

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




            ADATER = New OdbcDataAdapter(Consulta, Class_VariablesGlobales.MYSQ_Comman.Connection)

            ADATER.Fill(TABLA)
            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            Return TABLA
        Catch ex As Exception

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ObtieneIdInventario ( " & ex.Message & " )"
        End Try
    End Function

    Public Function ObtieneListaProveedores(ByVal Grupo As String)
        Try

            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim CodG As String
            Dim ADATER As New OdbcDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String
            Dim CodG1 As String
            Dim Proveedores(10) As String
            Dim contproveedor As Integer = 0
            'verifica o obtiene el codgrupo donde quedo guardado el grupo


            Consulta = "SELECT `CodProveedor` FROM `Inv_Grupos` where idGrupo='" & Grupo & "'"


            ADATER = New OdbcDataAdapter(Consulta, Class_VariablesGlobales.MYSQ_Comman.Connection)

            ADATER.Fill(TABLA)

            'liberando memoria
            ADATER.Dispose()
            ADATER = Nothing
            Consulta = Nothing
            Return TABLA
        Catch ex As Exception
            MsgBox("Error ObtieneListaProveedores " & ex.Message)

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ObtieneListaProveedores ( " & ex.Message & " )"
        End Try
    End Function


    Public Function VerificaInventarioAbiertos()

        Try

            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

            Dim CodG As String
            Dim ADATER As New OdbcDataAdapter
            Dim TABLA As New DataTable
            Dim Consulta As String
            Dim CodG1 As String
            Dim Proveedores(10) As String
            Dim contproveedor As Integer = 0
            'verifica o obtiene el codgrupo donde quedo guardado el grupo
            Consulta = "SELECT count(`IdInventario`) as Conto FROM `Inv_Inventario` where Cerrado='0' group by `IdInventario`"


            ADATER = New OdbcDataAdapter(Consulta, Class_VariablesGlobales.MYSQ_Comman.Connection)

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
            Return Conto
        Catch ex As Exception

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR ObtieneIdInventario ( " & ex.Message & " )"
        End Try

    End Function
    Public Function SubeInveConteo(ByVal Titulo As String, ByVal comentarioa As String)
        Try
            Dim retorna As Integer = 0
            Dim cont As Integer = 0
            Dim Consulta As String

            Dim TABLA As New DataTable

            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
            End If

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

                            If Class_VariablesGlobales.MYSQ_Comman.Connection.State = ConnectionState.Closed Then
                                Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()
                            End If
                            Dim Sector As String = ""


                            If TABLA.Rows(COTADOR).Item("Sector").ToString() = "" Then
                                Sector = "0"
                            Else
                                Sector = TABLA.Rows(COTADOR).Item("Sector").ToString()
                            End If

                            Consulta = "INSERT INTO `arquitect_bourne`.`Inv_Inventario` (" &
                                        "`Fecha`" &
                                        ",`IdInventario`" &
                                        ",`Codigo`" &
                                        ",`Descripcion`" &
                                        ",`CodBarras`" &
                                        ",`Sector`" &
                                        ",`Costo`" &
                                        ",`CodProveedor`" &
                                        ",`NameProveedor`" &
                                        ",`Stock`" &
                                        ",`Monto`" &
                                        ",`Reconteo`" &
                                        ",`CF`" &
                                        ",`DF`" &
                                        ",`DFM`) VALUES " &
                                       "('" & Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Now.Date) &
                                       "','" & Class_VariablesGlobales.idInventario &
                                       "','" & TABLA.Rows(COTADOR).Item("ItemCode").ToString() &
                                       "','" & TABLA.Rows(COTADOR).Item("ItemName").ToString() &
                                       "','" & TABLA.Rows(COTADOR).Item("CodeBars").ToString() &
                                       "','" & Sector &
                                       "','" & TABLA.Rows(COTADOR).Item("Price").ToString() &
                                       "','" & TABLA.Rows(COTADOR).Item("CodProveedor").ToString() &
                                       "','" & TABLA.Rows(COTADOR).Item("NameProveedor").ToString() &
                                       "','" & TABLA.Rows(COTADOR).Item("Stock_B1").ToString() &
                                       "','" & TABLA.Rows(COTADOR).Item("Monto_B1").ToString() &
                                       "','0" &
                                       "','0" &
                                       "','" & 0 - CInt(TABLA.Rows(COTADOR).Item("Stock_B1").ToString()) &
                                       "','" & -(CInt(TABLA.Rows(COTADOR).Item("Stock_B1").ToString()) * CDbl(TABLA.Rows(COTADOR).Item("Price").ToString())) & "');"


                            InventarioInicial += CDbl(TABLA.Rows(COTADOR).Item("Monto_B1").ToString())

                            Class_VariablesGlobales.DetalleCarga = "Subiendo : " & TABLA.Rows(COTADOR).Item("ItemName").ToString()
                            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
                            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()
                            Class_VariablesGlobales.Contador += 1

                            COTADOR += 1
                        Catch ex As Exception
                            MsgBox(ex.Message)

                            Class_VariablesGlobales.MYSQ_Comman = New OdbcCommand
                            Class_VariablesGlobales.MYSQ_Comman.Connection = Class_VariablesGlobales.Obj_CX_MySQL.Conectar()

                            Class_VariablesGlobales.MYSQ_Comman.CommandText = Consulta
                            Class_VariablesGlobales.MYSQ_Comman.ExecuteNonQuery()
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
            End If

            Return retorna
        Catch ex As Exception

            Class_VariablesGlobales.ERRORES = "[ " & Now & " ] ERROR Insertar_Articulos( " & ex.Message & " )"
        End Try
    End Function






End Class
