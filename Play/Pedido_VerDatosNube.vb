Public Class Pedido_VerDatosNube
    Private Sub Pedido_VerDatosNube_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '-----------------------------------------
        Dim Tbl_PedidoNube As New DataTable


        Dim Tbl_DevolucionesNube As New DataTable



        Dim Tbl_FiltradaPedidoNube As New DataTable
        Tbl_FiltradaPedidoNube.Columns.Add("Ruta")
        Tbl_FiltradaPedidoNube.Columns.Add("CodCliente")
        Tbl_FiltradaPedidoNube.Columns.Add("Nombre")
        Tbl_FiltradaPedidoNube.Columns.Add("DocNum")
        Tbl_FiltradaPedidoNube.Columns.Add("ItemCode")
        Tbl_FiltradaPedidoNube.Columns.Add("ItemName")
        Tbl_FiltradaPedidoNube.Columns.Add("Cant_Uni")

        Dim Tbl_FiltradaDevolucionesNube As New DataTable
        Tbl_FiltradaDevolucionesNube.Columns.Add("Ruta")
        Tbl_FiltradaDevolucionesNube.Columns.Add("CodCliente")
        Tbl_FiltradaDevolucionesNube.Columns.Add("Nombre")
        Tbl_FiltradaDevolucionesNube.Columns.Add("DocNum")
        Tbl_FiltradaDevolucionesNube.Columns.Add("ItemCode")
        Tbl_FiltradaDevolucionesNube.Columns.Add("ItemName")
        Tbl_FiltradaDevolucionesNube.Columns.Add("Cant_Uni")

        Dim contardor As Integer = 0



        If Class_VariablesGlobales.VerDatosNube = "DEVOLUCIONES" Then
            Try
                Tbl_DevolucionesNube = Class_VariablesGlobales.Obj_Funciones_MYSQL.ObtieneDevolucionesDelDia(txt_CodArt.Text.Trim, Class_VariablesGlobales.Obj_Fecha.FormatFechaSqlite(Now.ToShortDateString))

                'Recorre la tabla y verifica si el pedido ya existe en SAP,SI existe descarta la cantidad de la suma, SINO suma la cantidad
                If Tbl_DevolucionesNube.Rows.Count > 0 Then
                    While contardor < Tbl_DevolucionesNube.Rows.Count
                        If Class_VariablesGlobales.Obj_Funciones_SQL.ExisteDevolucionEnSAP(Class_VariablesGlobales.SQL_Comman2, Tbl_DevolucionesNube.Rows(contardor).Item("DocNum").ToString().Trim) = True Then

                        Else
                            Dim Tbl_DevolucionesNube_Row As DataRow = Tbl_FiltradaDevolucionesNube.NewRow
                            Tbl_DevolucionesNube_Row("CodCliente") = Tbl_DevolucionesNube.Rows(contardor).Item("CodCliente").ToString()
                            Tbl_DevolucionesNube_Row("Nombre") = Tbl_DevolucionesNube.Rows(contardor).Item("Nombre").ToString()
                            Tbl_DevolucionesNube_Row("DocNum") = Tbl_DevolucionesNube.Rows(contardor).Item("DocNum").ToString()
                            Tbl_DevolucionesNube_Row("ItemCode") = Tbl_DevolucionesNube.Rows(contardor).Item("ItemCode").ToString()
                            Tbl_DevolucionesNube_Row("ItemName") = Tbl_DevolucionesNube.Rows(contardor).Item("ItemName").ToString()
                            Tbl_DevolucionesNube_Row("Cant_Uni") = Tbl_DevolucionesNube.Rows(contardor).Item("Cantidad").ToString()
                            Tbl_FiltradaDevolucionesNube.Rows.Add(Tbl_DevolucionesNube_Row)
                            Tbl_FiltradaDevolucionesNube.AcceptChanges()
                        End If
                        contardor += 1
                    End While
                End If
                DataGridView1.DataSource = Tbl_FiltradaDevolucionesNube
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf Class_VariablesGlobales.VerDatosNube = "PEDIDOS" Then
            Tbl_PedidoNube = Class_VariablesGlobales.Obj_Funciones_MYSQL.ObtienePedidosDelDia(txt_CodArt.Text.Trim, Class_VariablesGlobales.Obj_Fecha.FormatFechaSqlite(Now.ToShortDateString))
            Try
                'Recorre la tabla y verifica si el pedido ya existe en SAP,SI existe descarta la cantidad de la suma, SINO suma la cantidad
                If Tbl_PedidoNube.Rows.Count > 0 Then
                    While contardor < Tbl_PedidoNube.Rows.Count
                        If Class_VariablesGlobales.Obj_Funciones_SQL.ExistePedidoEnSAP(Class_VariablesGlobales.SQL_Comman2, Tbl_PedidoNube.Rows(contardor).Item("DocNum").ToString().Trim) = True Then
                        Else
                            Dim Tbl_FiltradaPedidoNube_Row As DataRow = Tbl_FiltradaPedidoNube.NewRow
                            Tbl_FiltradaPedidoNube_Row("Ruta") = Tbl_PedidoNube.Rows(contardor).Item("Ruta").ToString()
                            Tbl_FiltradaPedidoNube_Row("CodCliente") = Tbl_PedidoNube.Rows(contardor).Item("CodCliente").ToString()
                            Tbl_FiltradaPedidoNube_Row("Nombre") = Tbl_PedidoNube.Rows(contardor).Item("Nombre").ToString()
                            Tbl_FiltradaPedidoNube_Row("DocNum") = Tbl_PedidoNube.Rows(contardor).Item("DocNum").ToString()
                            Tbl_FiltradaPedidoNube_Row("ItemCode") = Tbl_PedidoNube.Rows(contardor).Item("ItemCode").ToString()
                            Tbl_FiltradaPedidoNube_Row("ItemName") = Tbl_PedidoNube.Rows(contardor).Item("ItemName").ToString()
                            Tbl_FiltradaPedidoNube_Row("Cant_Uni") = Tbl_PedidoNube.Rows(contardor).Item("Cantidad").ToString()
                            Tbl_FiltradaPedidoNube.Rows.Add(Tbl_FiltradaPedidoNube_Row)
                            Tbl_FiltradaPedidoNube.AcceptChanges()
                        End If
                        contardor += 1
                    End While
                End If
                DataGridView1.DataSource = Tbl_FiltradaPedidoNube
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Obtiene la informacion de los pedidos en la nube de forma desglosada
        ElseIf Class_VariablesGlobales.VerDatosNube = "PEDIDOS_DETALLE" Then
            Tbl_PedidoNube = Class_VariablesGlobales.Obj_Funciones_SQL.ObtienePedidoRespaldados(Class_VariablesGlobales.SQL_Comman2, txt_CodArt.Text.Trim, Class_VariablesGlobales.Obj_Fecha.FormatFechaSqlite(Class_VariablesGlobales.frmCreaPedido.DTP_FechaInicio.Value.ToShortDateString), Class_VariablesGlobales.Obj_Fecha.FormatFechaSqlite(Class_VariablesGlobales.frmCreaPedido.DTP_FechaFin.Value.ToShortDateString))
            DataGridView1.DataSource = Tbl_PedidoNube
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class