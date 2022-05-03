Imports System.IO

Public Class Pedido_EditaLinea
    Public CantCajas As Integer
    Public Fila As Integer
    Dim Unidades As Integer
    Dim TotalOriginal As Double
    Dim TotalNuevo As Double
    Dim TotalGeneral As Double
    Public PUnid As String
    Public ModificadoDesdeCantidad As Boolean = False





    Public Function Guardar()
        Try
            Dim Dif As String = ""
            Dim Prmd_Compra As String = ""
            Dim PrmdVtaDs As String = ""
            Dim FIni_Cubrir As String = ""
            Dim FFin_Cubrir As String = ""
            Dim DiasSinMoverse As String = ""
            Dim Vmp As String = ""
            Dim Vmatp As String = ""
            Dim Vmatatp As String = ""
            Dim Mes_Vmp As String = ""
            Dim Mes_Vmatatp As String = ""
            Dim MEs_Vmatp As String = ""
            Dim Pd_CJs_Cheado As String = ""
            Dim Pd_Unid_Cheado As String = ""
            Dim Pd_Total_Cheado As String = ""
            Dim Motivo As String = ""
            Dim FCFIn_Venta As String = ""
            Dim FechaUltimaVenta As String = ""
            Dim CantidadUltimaVenta As String = ""
            Dim FechaUltimoPedido As String = ""
            Dim CantidadUltimoPedido As String = ""



            If txt_Cantidad.Text = "" Then
                txt_Cantidad.Text = "0"
            End If
            Unidades = CantCajas
            TotalOriginal = Unidades * CDbl(txt_Precio.Text)
            TotalGeneral = CDbl(Class_VariablesGlobales.frmCreaPedido.lbl_Total.Text)

            'resta al total general el total de pedido en la linea
            TotalGeneral = TotalGeneral - TotalOriginal



            If RdBtb_Cajas.Checked = True Then

                TotalNuevo = (CDbl(txt_Cantidad.Text) * CInt(txt_Emp.Text)) * CDbl(txt_Precio.Text)

                Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows(txtb_Index.Text).Cells(22).Value = txt_Cantidad.Text 'cajas
                Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows(txtb_Index.Text).Cells(21).Value = CInt(CDbl(txt_Cantidad.Text) * CInt(txt_Emp.Text)) 'unidaes
                Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows(txtb_Index.Text).Cells(23).Value = Math.Round(TotalNuevo, 2)   'total

            Else
                TotalNuevo = CInt(txt_Cantidad.Text) * CDbl(txt_Precio.Text)
                Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows(txtb_Index.Text).Cells(22).Value = Math.Round(CDbl(CInt(txt_Cantidad.Text) / CInt(txt_Emp.Text)), 2) 'cajas
                Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows(txtb_Index.Text).Cells(21).Value = txt_Cantidad.Text  'unidaes 
                Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows(txtb_Index.Text).Cells(23).Value = Math.Round(TotalNuevo, 2)   'total

            End If

            'suma la nueva cantidad digitada al total general
            TotalGeneral += TotalNuevo
            'asinga el nuevo total general
            ' Class_VariablesGlobales.frmCreaPedido.lbl_Total.Text = FormatCurrency(CDbl(TotalGeneral.ToString), 2)

            Class_VariablesGlobales.frmCreaPedido.TotalPedido(Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido)

            Class_VariablesGlobales.OrCom_Pd_CJs = txt_Cajas.Text
            Class_VariablesGlobales.OrCom_Pd_Unid = txt_Unidades.Text




            Class_VariablesGlobales.Obj_Funciones_SQL.GuardaOrdenDeCompra(
            txtb_ID.Text,
            Class_VariablesGlobales.frmCreaPedido.lbl_NumOrden.Text,
            Class_VariablesGlobales.frmCreaPedido.txtb_CodProveedor.Text,
            Class_VariablesGlobales.frmCreaPedido.txtb_NombreProveedor.Text,
            txt_CodArt.Text,
            txt_Descrip.Text,
            Class_VariablesGlobales.OrCom_Fecha,
            txtb_Alterno.Text,
            txt_Emp.Text,
            txt_Precio.Text,
            txt_Venta_Unid.Text,
            txt_Venta_Cjs.Text,
            txt_Venta_Mont.Text,
            txt_Stock_Unid.Text,
            txt_Stock_Cajas.Text,
            txt_Stock_Mont.Text,
            textb_Comprometido.Text,
            txtb_DiasInve.Text,
            txt_Cajas.Text,
            txt_Unidades.Text,
            txtb_MontoPedi.Text,
            Class_VariablesGlobales.frmCreaPedido.DTP_FechaInicio.Value.ToShortDateString,
            Class_VariablesGlobales.frmCreaPedido.DTP_FechaFin.Value.ToShortDateString,
            Class_VariablesGlobales.frmCreaPedido.DTP_ProyeccionIni.Value.ToShortDateString,
            Class_VariablesGlobales.frmCreaPedido.DTP_ProyeccionFin.Value.ToShortDateString,
            "",
            txtb_Barras.Text,
            Class_VariablesGlobales.OrCom_UGramaje,
            Textb_Compra.Text,
            txtb_PedidoXAgente.Text,
            txt_Faltante.Text,
            textb_ComprometidoCjs.Text,
            txtb_FechaUltimaCompra.Text,
            Dif,
            Prmd_Compra,
            PrmdVtaDs,
            FIni_Cubrir,
            FFin_Cubrir,
            DiasSinMoverse,
            Vmp,
            Vmatp,
            Vmatatp,
            Mes_Vmp,
            Mes_Vmatatp,
            MEs_Vmatp,
            Pd_CJs_Cheado,
            Pd_Unid_Cheado,
            Pd_Total_Cheado,
            Motivo,
            FCFIn_Venta, FechaUltimaVenta, CantidadUltimaVenta, "1",
            FechaUltimoPedido,
            CantidadUltimoPedido,
            Class_VariablesGlobales.SQL_Comman1, False)





            If CInt(txtb_Index.Text) + 1 > Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.RowCount - 1 Then
                MsgBox("Ha llegado a la ultima linea", MsgBoxStyle.Information, "ULTIMA LINEA")
                Me.Close()

            Else
                txtb_Index.Text = CInt(txtb_Index.Text) + 1
                txtb_ID.Text = CInt(txtb_ID.Text) + 1

                Navegar(CInt(txtb_ID.Text))
            End If

            Dif = Nothing
            Prmd_Compra = Nothing
            PrmdVtaDs = Nothing
            FIni_Cubrir = Nothing
            FFin_Cubrir = Nothing
            DiasSinMoverse = Nothing
            Vmp = Nothing
            Vmatp = Nothing
            Vmatatp = Nothing
            Mes_Vmp = Nothing
            Mes_Vmatatp = Nothing
            MEs_Vmatp = Nothing
            Pd_CJs_Cheado = Nothing
            Pd_Unid_Cheado = Nothing
            Pd_Total_Cheado = Nothing
            Motivo = Nothing
            FCFIn_Venta = Nothing
            FechaUltimaVenta = Nothing
            CantidadUltimaVenta = Nothing

            'Quita la marca de la linea roja por que ya fue revisado
            Dim Cont As Integer = 0
            For Each row As DataGridViewRow In Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows
                If (CInt(row.Cells(11).Value) < 0) Then
                    If (Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneRevisado(Class_VariablesGlobales.SQL_Comman1, lbl_NumOrden.Text, row.Cells(6).Value) = "0") Then
                        row.DefaultCellStyle.BackColor = Color.Red
                        row.DefaultCellStyle.ForeColor = Color.White

                    Else
                        row.DefaultCellStyle.BackColor = Color.White
                        row.DefaultCellStyle.ForeColor = Color.Black
                    End If
                    Cont += 1
                End If
            Next

        Catch ex As Exception
            MsgBox("ERROR Guardar " & ex.Message, MsgBoxStyle.Information, "ERROR")
        End Try
    End Function

    Private Sub txt_Cajas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Cajas.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True

            Unidades = CantCajas * CInt(txt_Emp.Text)
            TotalOriginal = Unidades * CDbl(txt_Precio.Text)
            TotalGeneral = CDbl(Class_VariablesGlobales.frmCreaPedido.lbl_Total.Text)

            'resta al total general el total de pedido en la linea
            TotalGeneral = TotalGeneral - TotalOriginal

            Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows(Fila).Cells(17).Value = txt_Cajas.Text
            Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows(Fila).Cells(18).Value = Format(TotalNuevo, "##,##00.00")   'total FormatCurrency(TotalNuevo, 2)

            TotalNuevo = (CInt(txt_Cajas.Text) * CInt(txt_Emp.Text)) * CDbl(txt_Precio.Text)
            'suma la nueva cantidad digitada al total general
            TotalGeneral += TotalNuevo
            'asinga el nuevo total general
            Class_VariablesGlobales.frmCreaPedido.lbl_Total.Text = FormatCurrency(TotalGeneral.ToString, 2)





            Class_VariablesGlobales.OrCom_Pd_CJs = txt_Cajas.Text
            Class_VariablesGlobales.OrCom_Pd_Unid = txt_Unidades.Text


            Dim Dif As String = ""
            Dim Prmd_Compra As String = ""
            Dim PrmdVtaDs As String = ""
            Dim FIni_Cubrir As String = ""
            Dim FFin_Cubrir As String = ""
            Dim DiasSinMoverse As String = ""
            Dim Vmp As String = ""
            Dim Vmatp As String = ""
            Dim Vmatatp As String = ""
            Dim Mes_Vmp As String = ""
            Dim Mes_Vmatatp As String = ""
            Dim MEs_Vmatp As String = ""
            Dim Pd_CJs_Cheado As String = ""
            Dim Pd_Unid_Cheado As String = ""
            Dim Pd_Total_Cheado As String = ""
            Dim Motivo As String = ""
            Dim FCFIn_Venta As String = ""
            Dim FechaUltimaVenta As String = ""
            Dim CantidadUltimaVenta As String = ""
            Dim FechaUltimoPedido As String = ""
            Dim CantidadUltimoPedido As String = ""


            Class_VariablesGlobales.Obj_Funciones_SQL.GuardaOrdenDeCompra(
            txtb_ID.Text,
            lbl_NumOrden.Text,
            Class_VariablesGlobales.OrCom_CardCode,
            Class_VariablesGlobales.OrCom_CardName,
            txt_CodArt.Text,
            txt_Descrip.Text,
            Class_VariablesGlobales.OrCom_Fecha,
            txtb_Alterno.Text,
            txt_Emp.Text,
            txt_Precio.Text,
            txt_Venta_Unid.Text,
            txt_Venta_Cjs.Text,
            txt_Venta_Mont.Text,
            txt_Stock_Unid.Text,
            txt_Stock_Cajas.Text,
            txt_Stock_Mont.Text,
            textb_Comprometido.Text,
            txtb_DiasInve.Text,
            txt_Cajas.Text,
            txt_Unidades.Text,
            txtb_MontoPedi.Text,
            Class_VariablesGlobales.frmCreaPedido.DTP_FechaInicio.Value.ToShortDateString,
            Class_VariablesGlobales.frmCreaPedido.DTP_FechaFin.Value.ToShortDateString,
            Class_VariablesGlobales.frmCreaPedido.DTP_ProyeccionIni.Value.ToShortDateString,
            Class_VariablesGlobales.frmCreaPedido.DTP_ProyeccionFin.Value.ToShortDateString,
            "",
            txtb_Barras.Text,
            Class_VariablesGlobales.OrCom_UGramaje,
            Textb_Compra.Text,
            txtb_PedidoXAgente.Text,
            txt_Faltante.Text,
            textb_ComprometidoCjs.Text,
            txtb_FechaUltimaCompra.Text,
            Dif,
            Prmd_Compra,
            PrmdVtaDs,
            FIni_Cubrir,
            FFin_Cubrir,
            DiasSinMoverse,
            Vmp,
            Vmatp,
            Vmatatp,
            Mes_Vmp,
            Mes_Vmatatp,
            MEs_Vmatp,
            Pd_CJs_Cheado,
            Pd_Unid_Cheado,
            Pd_Total_Cheado,
            Motivo,
            FCFIn_Venta, FechaUltimaVenta, CantidadUltimaVenta, "1",
            FechaUltimoPedido,
            CantidadUltimoPedido,
            Class_VariablesGlobales.SQL_Comman1, False)

            Dif = Nothing
            Prmd_Compra = Nothing
            PrmdVtaDs = Nothing
            FIni_Cubrir = Nothing
            FFin_Cubrir = Nothing
            DiasSinMoverse = Nothing
            Vmp = Nothing
            Vmatp = Nothing
            Vmatatp = Nothing
            Mes_Vmp = Nothing
            Mes_Vmatatp = Nothing
            MEs_Vmatp = Nothing
            Pd_CJs_Cheado = Nothing
            Pd_Unid_Cheado = Nothing
            Pd_Total_Cheado = Nothing
            Motivo = Nothing
            FCFIn_Venta = Nothing
            FechaUltimaVenta = Nothing
            CantidadUltimaVenta = Nothing
            FechaUltimoPedido = Nothing
            CantidadUltimoPedido = Nothing


            Me.Close()
        End If
    End Sub

    Private Sub EditaLineaPedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            Me.ToolTip1.SetToolTip(Me.txtb_minimo, "Muestra el stock minimo en unidades registrado en SAP")
            Me.ToolTip1.SetToolTip(Me.txtb_DiasInve, "Muestra a cuantos dias de inventario equivale el estock disponible, segun las ventas del rango de fechas seleccionado")
            Me.ToolTip1.SetToolTip(Me.txtb_Rotacion, "Muestra cuantas veces rota el inventario segun las ventas, estre mayor rotacion es mejor")
            Me.ToolTip1.SetToolTip(Me.txt_Stock_Unid, "Muestra el stock en unidades disponible de la bodega 01 en SAP al momento en que se genero la informacion para realizar el pedido")
            Me.ToolTip1.SetToolTip(Me.textb_Comprometido, "Muestra el stock en unidades comprometido de la bodega 01 en SAP, son pedidos no facturados")
            Me.ToolTip1.SetToolTip(Me.txtb_Devoluciones, "Muestra las unidades devueltas en curso osea no transmitidas, por parte de agentes y choferes, omite la categoria de mercaderia dañada")
            Me.ToolTip1.SetToolTip(Me.txtb_Pedido, "Muestra las unidades pedidas en curso osea no transmitidas, por parte de agentes y choferes, omite la categoria de mercaderia dañada")
            Me.ToolTip1.SetToolTip(Me.txt_Stock_Dispobles, "Muestra el stock resultado de la operacion: " & vbCrLf & "(Stock+Devoluciones)-(Comprometido+Pedidos)")
            Me.ToolTip1.SetToolTip(Me.txt_Venta_Unid, "Muestra las unidades vendidas en el rango de fechas elegido al generar la informacion")
            Me.ToolTip1.SetToolTip(Me.txtb_PedidoXAgente, "Muestra las unidades pedidas en el rango de fechas elegido al generar la informacion")
            Me.ToolTip1.SetToolTip(Me.txt_Faltante, "Muestra el resultado de los faltantes con la operacion : " & vbCrLf & " Pedido-Venta")



            If Class_VariablesGlobales.frmCreaPedido.RdBtb_Cajas.Checked Then
                RdBtb_Cajas.Checked = True
            End If
            If Class_VariablesGlobales.frmCreaPedido.RdBtb_Unidades.Checked Then
                RdBtb_Unidades.Checked = True
            End If

            Dim Conversion(2) As String

            'SE DEBE LLAMAR A LA FUNCION CONVERTIDORA
            If RdBtb_Cajas.Checked = True Then
                txt_Cajas.Text = CDbl(txt_Cantidad.Text)
                txt_Unidades.Text = CDbl(txt_Cantidad.Text) * CInt(txt_Emp.Text)
            Else
                txt_Cajas.Text = FormatNumber((CDbl(txt_Cantidad.Text) / CInt(txt_Emp.Text)), 2)
                'Conversion = Obj_Conversion.Unidad_A_Cjs(CInt(txt_Cantidad.Text), CInt(txt_Emp.Text))
                'txt_Cajas.Text = Conversion(0)
                txt_Unidades.Text = txt_Cantidad.Text
            End If

            GraficoVentasXDia(txt_CodArt.Text.Trim)
            txt_Cantidad.Focus()

            txtb_DiasACubrir.Text = Class_VariablesGlobales.frmCreaPedido.txtb_DiasACubrir.Text
        Catch ex As Exception
            MsgBox("ERROR EditaLineaPedido_Load " & ex.Message, MsgBoxStyle.Information, "ERROR")
        End Try

    End Sub

    Public Function GraficoVentasXDia(ItemCode As String)
        Try
            txtb_minimo.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneMinimo(Class_VariablesGlobales.SQL_Comman1, ItemCode)
            Class_VariablesGlobales.frmEditaLinePedido.Chart1.Series.Clear()
            Class_VariablesGlobales.frmEditaLinePedido.Chart1.Series.Add("Venta")


            Class_VariablesGlobales.frmEditaLinePedido.Chart1.Series("Venta").IsValueShownAsLabel = True
            Chart1.Series("Venta").LabelForeColor = Color.Blue
            Chart1.Series("Venta").LabelBackColor = Color.White



            Dim tabla As New DataTable
            Dim cont As Integer
            tabla = Class_VariablesGlobales.Obj_Funciones_SQL.VentasXDia(Class_VariablesGlobales.SQL_Comman1, ItemCode)
            For Each row As DataRow In tabla.Rows
                Class_VariablesGlobales.frmEditaLinePedido.Chart1.Series("Venta").Points.AddXY(tabla.Rows(cont).Item("Dia").ToString(), tabla.Rows(cont).Item("Cantidad").ToString())
                cont += 1
            Next

            Class_VariablesGlobales.frmEditaLinePedido.Chart2.Series.Clear()
            Class_VariablesGlobales.frmEditaLinePedido.Chart2.Series.Add("Pedido")

            Class_VariablesGlobales.frmEditaLinePedido.Chart2.Series("Pedido").IsValueShownAsLabel = True
            Chart2.Series("Pedido").LabelForeColor = Color.Blue
            Chart2.Series("Pedido").LabelBackColor = Color.White

            tabla = Nothing
            cont = 0
            tabla = Class_VariablesGlobales.Obj_Funciones_SQL.PedidoXDia(Class_VariablesGlobales.SQL_Comman1, ItemCode)
            For Each row As DataRow In tabla.Rows
                Class_VariablesGlobales.frmEditaLinePedido.Chart2.Series("Pedido").Points.AddXY(tabla.Rows(cont).Item("Dia").ToString(), tabla.Rows(cont).Item("Cantidad").ToString())
                cont += 1
            Next

            '[ID],[NumDoc],[Fecha],[CardCode],[NombreProveedor],[Alterno],[ItemCode],[ItemName],[Costo],[Pack],[Venta_Mont],[Venta_Uni],[Venta_Cjs],[PedAgts],[Faltante],[StockR],[StockRCjs],[StockR_Monto],[Dif],[Cpmtdo],[CpmtdoCjs],[Pd_Unid],[Pd_CJs],[Pd_Total],[Prmd_Compra],[PrmdVtaDs],[Dias_Iv],[FIni_Venta],[FFin_Venta],[FIni_Cubrir],[FFin_Cubrir],[UltimaCompra]

        Catch ex As Exception
        End Try
    End Function
    Private Sub txt_Cantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Cantidad.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Up Then
            If CInt(txtb_Index.Text) = 0 Then

                MsgBox("Ha llegado a la ultima linea", MsgBoxStyle.Information, "ULTIMA LINEA")
                Me.Close()
            Else
                txtb_ID.Text = CInt(txtb_ID.Text) - 1
                txtb_Index.Text = CInt(txtb_Index.Text) - 1

                Navegar(CInt(txtb_ID.Text))


            End If
        End If

        If e.KeyCode = Keys.Right Or e.KeyCode = Keys.Down Then
            If CInt(txtb_Index.Text) = Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.RowCount Then

                MsgBox("Ha llegado a la ultima linea", MsgBoxStyle.Information, "ULTIMA LINEA")
                Me.Close()
            Else

                txtb_Index.Text = CInt(txtb_Index.Text) + 1
                txtb_ID.Text = CInt(txtb_ID.Text) + 1

                Navegar(CInt(txtb_ID.Text))

            End If
        End If

    End Sub
    Private Sub txt_Cantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Cantidad.KeyPress

        Try
            Dim Guardo As Boolean = False
            'solo si le da enter guarda
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
                Guardar()
                Guardo = True
            End If


            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Left) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Up) Then
                If CInt(txtb_Index.Text) = 0 Then

                    MsgBox("Ha llegado a la ultima linea", MsgBoxStyle.Information, "ULTIMA LINEA")
                    Me.Close()
                Else
                    txtb_ID.Text = CInt(txtb_ID.Text) - 1
                    txtb_Index.Text = CInt(txtb_Index.Text) - 1
                    If Guardo = False Then
                        Navegar(CInt(txtb_ID.Text))
                    End If

                End If
            End If

            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Right) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Down) Then
                If CInt(txtb_Index.Text) = Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.RowCount Then

                    MsgBox("Ha llegado a la ultima linea", MsgBoxStyle.Information, "ULTIMA LINEA")
                    Me.Close()
                Else

                    txtb_Index.Text = CInt(txtb_Index.Text) + 1
                    txtb_ID.Text = CInt(txtb_ID.Text) + 1
                    If Guardo = False Then
                        Navegar(CInt(txtb_ID.Text))
                    End If
                End If
            End If


            Cursor = System.Windows.Forms.Cursors.WaitCursor

            If e.KeyChar = "" Then
                txt_Cantidad.Text = "0"
            End If

            If IsNumeric(e.KeyChar) Then

            ElseIf e.KeyChar = "C" Or e.KeyChar = "c" Then 'Si no es numero solo permite si es C o c para cambiar las unidades a Cajas

                RdBtb_Cajas.Checked = True
                RdBtb_Unidades.Checked = False
                e.KeyChar = ""

            ElseIf e.KeyChar = "U" Or e.KeyChar = "u" Then 'Para cambiar las unidades a Unidades

                RdBtb_Unidades.Checked = True
                RdBtb_Cajas.Checked = False
                e.KeyChar = ""

            End If


            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
                ' SendKeys.Send("{TAB}")
                e.Handled = True
                Dim Conversion(2) As String

                If (CInt(txt_Cantidad.Text) < 0) Then
                    txt_Cantidad.Text = CInt(txt_Cantidad.Text) * -1
                Else
                    'txt_Cantidad.Text = 0
                End If

                'SE DEBE LLAMAR A LA FUNCION CONVERTIDORA
                If RdBtb_Cajas.Checked = True Then
                    txt_Cajas.Text = CDbl(txt_Cantidad.Text)
                    txt_Unidades.Text = CDbl(txt_Cantidad.Text) * CInt(txt_Emp.Text)
                    txtb_MontoPedi.Text = Format((CDbl(txt_Cantidad.Text) * CInt(txt_Emp.Text)) * CDbl(txt_Precio.Text), "##,##00.00")
                Else
                    txt_Cajas.Text = FormatNumber(CDbl(txt_Cantidad.Text) / CInt(txt_Emp.Text), 2)
                    'Conversion = Obj_Conversion.Unidad_A_Cjs(CInt(txt_Cantidad.Text), CInt(txt_Emp.Text))
                    'txt_Cajas.Text = Conversion(0)
                    txt_Unidades.Text = txt_Cantidad.Text
                    txtb_MontoPedi.Text = Format(CDbl(txt_Cantidad.Text) * CDbl(txt_Precio.Text), "##,##00.00")
                End If

                ''Pd_Unid
                'Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Item(21, CInt(txtb_Index.Text)).Value = txt_Unidades.Text
                ''Pd_CJs
                'Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Item(22, CInt(txtb_Index.Text)).Value = txt_Cajas.Text
                ''Pd_Total '
                'Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Item(23, CInt(txtb_Index.Text)).Value = txtb_MontoPedi.Text




                txt_Cantidad.SelectAll()
            End If

            Cursor = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            'MsgBox("ERROR txt_Cantidad_KeyPress " & ex.Message, MsgBoxStyle.Information, "ERROR")
        End Try
    End Sub

    Private Sub RdBtb_Unidades_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdBtb_Unidades.CheckedChanged
        Try
            Dim Conversion(2) As String
            'SE DEBE LLAMAR A LA FUNCION CONVERTIDORA
            If RdBtb_Cajas.Checked = True Then
                txt_Cajas.Text = CDbl(txt_Cantidad.Text)
                txt_Unidades.Text = CDbl(txt_Cantidad.Text) * CInt(txt_Emp.Text)



                txtb_MontoPedi.Text = Format(CDbl(txt_Unidades.Text) * CDbl(txt_Precio.Text), "##,##00.00")


                txtb_Disponible.Text = CInt(txt_Unidades.Text) + CInt(txt_Stock_Dispobles.Text)
            Else
                txt_Cajas.Text = CDbl(txt_Cantidad.Text) / CInt(txt_Emp.Text)
                Conversion = Class_VariablesGlobales.Obj_Conversion.Unidad_A_Cjs(CInt(txt_Cantidad.Text), CInt(txt_Emp.Text))
                txt_Cajas.Text = Conversion(0)
                txt_Unidades.Text = CDbl(txt_Cantidad.Text)


                txtb_MontoPedi.Text = Format(CDbl(txt_Cantidad.Text) * CDbl(txt_Precio.Text), "##,##00.00")


                txtb_Disponible.Text = CInt(txt_Cantidad.Text) + CInt(txt_Stock_Dispobles.Text)
            End If


            txtb_DiasNewDisponible.Text = Math.Round(CDbl(CDbl(txtb_Disponible.Text) / CDbl(txtb_PromVDiaria.Text)), 2, MidpointRounding.ToEven)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RdBtb_Cajas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdBtb_Cajas.CheckedChanged
        Try


            Dim Conversion(2) As String
            'SE DEBE LLAMAR A LA FUNCION CONVERTIDORA
            If RdBtb_Cajas.Checked = True Then
                txt_Cajas.Text = CDbl(txt_Cantidad.Text)
                txt_Unidades.Text = CDbl(txt_Cantidad.Text) * CInt(txt_Emp.Text)

            Else
                txt_Cajas.Text = CDbl(txt_Cantidad.Text) / CInt(txt_Emp.Text)
                Conversion = Class_VariablesGlobales.Obj_Conversion.Unidad_A_Cjs(CInt(txt_Cantidad.Text), CInt(txt_Emp.Text))
                txt_Cajas.Text = Conversion(0)
                txt_Unidades.Text = Conversion(1)
            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub Btn_Adelante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Adelante.Click
        If CInt(txtb_Index.Text) + 1 > Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.RowCount - 1 Then
            MsgBox("Ha llegado a la ultima linea", MsgBoxStyle.Information, "ULTIMA LINEA")
            Me.Close()
        Else
            txtb_Index.Text = CInt(txtb_Index.Text) + 1
            txtb_ID.Text = CInt(txtb_ID.Text) + 1

            Navegar(CInt(txtb_ID.Text))
        End If



    End Sub

    Private Sub Btn_Atras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Atras.Click
        If CInt(txtb_Index.Text) - 1 < 0 Then
            MsgBox("Ha llegado a la ultima linea", MsgBoxStyle.Information, "ULTIMA LINEA")
            Me.Close()

        Else


            txtb_ID.Text = CInt(txtb_ID.Text) - 1
            txtb_Index.Text = CInt(txtb_Index.Text) - 1
            Navegar(CInt(txtb_ID.Text))
        End If

    End Sub


    Function Navegar(ByVal id As Integer)


        Try

            txtb_Disponible.Text = "0"
            txtb_DiasNewDisponible.Text = "0"
            Cursor = System.Windows.Forms.Cursors.WaitCursor



            Try
                Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.ClearSelection()
                Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows(txtb_Index.Text).Selected = True
            Catch ex As Exception

            End Try
            'obtener la informacion de la LInea
            'Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows(0).Cells(6).Value'Obtiene el codigo del articulo
            'Dim id As Integer
            'id = Class_VariablesGlobales.frmCreaPedido.DataGridView1.CurrentRow.Cells(0).Value() 'ID
            Dim tbl_Linea As New DataTable

            tbl_Linea = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneOrdenCompraTem(Class_VariablesGlobales.SQL_Comman1, Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows(txtb_Index.Text).Cells(6).Value, True, Class_VariablesGlobales.frmCreaPedido.btn_CrearEnSAP.Enabled, lbl_NumOrden.Text)

            'recorremos ta talba y cargamos campos


            For Each row As DataRow In tbl_Linea.Rows

                '[ID],[NumDoc],[Fecha],[CardCode],[NombreProveedor],[Alterno],[ItemCode],[ItemName],[Costo],[Pack],[Venta_Mont],[Venta_Uni],[Venta_Cjs],[PedAgts],[Faltante],[StockR],[StockRCjs],[StockR_Monto],[Dif],[Cpmtdo],[CpmtdoCjs],[Pd_Unid],[Pd_CJs],[Pd_Total],[Prmd_Compra],[PrmdVtaDs],[Dias_Iv],[FIni_Venta],[FFin_Venta],[FIni_Cubrir],[FFin_Cubrir],[UltimaCompra]


                txtb_ID.Text = tbl_Linea.Rows(0).Item(0).ToString()
                txt_Emp.Text = tbl_Linea.Rows(0).Item(9).ToString()
                txt_Precio.Text = Format(CDbl(tbl_Linea.Rows(0).Item(8).ToString()), "##,##00.00")
                txt_CodArt.Text = tbl_Linea.Rows(0).Item(6).ToString()
                'obtiene la imagen del articulo

                If File.Exists("\\SAP2\Users\Administrator\Pictures\Articulos\" & txt_CodArt.Text & ".jpg") Then
                    PictureBox1.ImageLocation = "\\SAP2\Users\Administrator\Pictures\Articulos\" & txt_CodArt.Text & ".jpg"

                Else
                    ' Me.PictureBox1.Image = Global.SincroCliente.My.Resources.Resources.ImagenNoDisponible
                    'PictureBox1.ImageLocation = Global.SincroCliente.My.Resources.Resources.ImagenNoDisponible.ToString

                    PictureBox1.ImageLocation = "\\SAP2\Users\Administrator\Pictures\Articulos\ImagenNoDisponible.jpg"
                End If




                txt_Descrip.Text = tbl_Linea.Rows(0).Item(7).ToString()
                txtb_Alterno.Text = tbl_Linea.Rows(0).Item(5).ToString()
                txt_Venta_Unid.Text = tbl_Linea.Rows(0).Item(11).ToString()

                txt_Stock_Unid.Text = tbl_Linea.Rows(0).Item(15).ToString()


                txtb_PedidoXAgente.Text = tbl_Linea.Rows(0).Item(13).ToString()
                txtb_PedidoXAgenteCJs.Text = Math.Round(CDbl(txtb_PedidoXAgente.Text) / CDbl(txt_Emp.Text), 2, MidpointRounding.ToEven)
                txtb_PedidoXAgenteMonto.Text = Format(CDbl(txtb_PedidoXAgente.Text) * CDbl(txt_Precio.Text), "##,##00.00")



                txt_Faltante.Text = tbl_Linea.Rows(0).Item(14).ToString()

                txt_FaltanteCjs.Text = Math.Round(CDbl(txt_Faltante.Text) / CDbl(txt_Emp.Text), 2, MidpointRounding.ToEven)
                txt_FaltanteMonto.Text = Format(CDbl(txt_Faltante.Text) * CDbl(txt_Precio.Text), "##,##00.00")

                '  frmEditaLinePedido.txt_Max.Text = DataGridView1.CurrentRow(20).Value


                txt_Venta_Unid.Text = tbl_Linea.Rows(0).Item(11).ToString()
                If (CInt(txt_Venta_Unid.Text) < 0) Then
                    txt_Venta_Unid.BackColor = Color.Red
                Else
                    txt_Venta_Unid.BackColor = Color.White
                End If
                txt_Venta_Cjs.Text = Math.Round(CDbl(tbl_Linea.Rows(0).Item(12).ToString()), 2, MidpointRounding.ToEven)
                txt_Venta_Mont.Text = Format(CDbl(tbl_Linea.Rows(0).Item(10).ToString()), "##,##00.00")

                txt_Stock_Unid.Text = tbl_Linea.Rows(0).Item(15).ToString()
                txt_Stock_Cajas.Text = Math.Round(CInt(txt_Stock_Unid.Text) / CInt(txt_Emp.Text), 2, MidpointRounding.ToEven)
                txt_Stock_Mont.Text = Format(CInt(txt_Stock_Unid.Text) * CDbl(txt_Precio.Text), "##,##00.00")

                'Fila = DataGridView1.CurrentRow.Index
                'frmEditaLinePedido.txt_Cajas.Text = DataGridView1.CurrentRow(21).Value
                If RdBtb_Cajas.Checked = True Then
                    txt_Cantidad.Text = tbl_Linea.Rows(0).Item(22).ToString()
                    'frmEditaLinePedido.CantCajas = DataGridView1.CurrentRow(21).Value
                Else
                    txt_Cantidad.Text = tbl_Linea.Rows(0).Item(21).ToString()

                End If

                txtb_Barras.Text = tbl_Linea.Rows(0).Item(32).ToString()
                txtb_FechaUltimaCompra.Text = tbl_Linea.Rows(0).Item(41).ToString()

                CantCajas = tbl_Linea.Rows(0).Item(22).ToString()
                txtb_PromVDiaria.Text = Math.Round(CDbl(tbl_Linea.Rows(0).Item(25).ToString()), 2, MidpointRounding.ToEven)
                'Class_VariablesGlobales.frmCreaPedido.Dias.Text = tbl_Linea.Rows(0).Item(26).ToString()
                txtb_DiasInve.Text = tbl_Linea.Rows(0).Item(26).ToString()

                textb_Comprometido.Text = tbl_Linea.Rows(0).Item(19).ToString()
                textb_ComprometidoCjs.Text = Math.Round(CDbl(textb_Comprometido.Text) / CDbl(txt_Emp.Text), 2, MidpointRounding.ToEven)
                textb_ComprometidoMonto.Text = Format(textb_Comprometido.Text * CDbl(txt_Precio.Text), "##,##00.00")
                Textb_Compra.Text = tbl_Linea.Rows(0).Item(31).ToString()
                Textb_CompraCjs.Text = Math.Round(CDbl(tbl_Linea.Rows(0).Item(31).ToString()) / CDbl(txt_Emp.Text), 2, MidpointRounding.ToEven)
                Textb_CompraMonto.Text = Format(tbl_Linea.Rows(0).Item(31).ToString() * CDbl(txt_Precio.Text), "##,##00.00")

                Textb_UltPedidoCajas.Text = Math.Round(CDbl(tbl_Linea.Rows(0).Item(46).ToString()) / CDbl(txt_Emp.Text), 2, MidpointRounding.ToEven)
                Textb_UltPedidoMonto.Text = Format(tbl_Linea.Rows(0).Item(46).ToString() * CDbl(txt_Precio.Text), "##,##00.00")



                If tbl_Linea.Rows(0).Item(43).ToString() = "" Then
                    Textb_Venta.Text = "0"
                Else
                    Textb_Venta.Text = tbl_Linea.Rows(0).Item(43).ToString()
                End If

                Textb_VentaCjs.Text = Math.Round(CDbl(Textb_Venta.Text) / CDbl(txt_Emp.Text), 2, MidpointRounding.ToEven)
                Textb_VentaMonto.Text = Format(CDbl(Textb_Venta.Text) * CDbl(txt_Precio.Text), "##,##00.00")
                If tbl_Linea.Rows(0).Item(42).ToString() = "" Then
                    txtb_FechaUltimaVenta.Text = ""
                Else
                    txtb_FechaUltimaVenta.Text = tbl_Linea.Rows(0).Item(42).ToString().Substring(0, 10)
                End If
                'indica si fue editado por la persona y lo indica con un color
                If tbl_Linea.Rows(0).Item(44).ToString() = "1" Then
                    txt_Cantidad.BackColor = Color.Green
                Else
                    txt_Cantidad.BackColor = Color.White

                End If
                If tbl_Linea.Rows(0).Item(45).ToString() = "" Then
                    txtb_FechaUltimoPedido.Text = ""
                Else
                    txtb_FechaUltimoPedido.Text = tbl_Linea.Rows(0).Item(45).ToString().Substring(0, 10)
                End If
                Textb_UltPedidoUnidades.Text = tbl_Linea.Rows(0).Item(46).ToString()

                txtb_DiasDesdeUltimoPedido.Text = "Hace " & Class_VariablesGlobales.Obj_Fecha.Dias(txtb_FechaUltimoPedido.Text, Now.Date) & " Dias"
                txtb_DiasDesdeUltimoCompra.Text = "Hace " & Class_VariablesGlobales.Obj_Fecha.Dias(txtb_FechaUltimaCompra.Text, Now.Date) & " Dias"
                txtb_DiasDesdeUltimoMov.Text = "Hace " & Class_VariablesGlobales.Obj_Fecha.Dias(txtb_FechaUltimaVenta.Text, Now.Date) & " Dias"

                'SE DEBE LLAMAR A LA FUNCION CONVERTIDORA
                If RdBtb_Cajas.Checked = True Then
                    txt_Cajas.Text = CDbl(txt_Cantidad.Text)
                    txt_Unidades.Text = CDbl(txt_Cantidad.Text) * CInt(txt_Emp.Text)
                Else
                    txt_Cajas.Text = Math.Round((CDbl(txt_Cantidad.Text) / CInt(txt_Emp.Text)), 2, MidpointRounding.ToEven)
                    'Conversion = Obj_Conversion.Unidad_A_Cjs(CInt(txt_Cantidad.Text), CInt(txt_Emp.Text))
                    'txt_Cajas.Text = Conversion(0)
                    txt_Unidades.Text = txt_Cantidad.Text
                End If



                'txt_Unidades.Text = txt_Cantidad.Text
                'txt_Cajas.Text = Math.Round(CDbl(txt_Unidades.Text) / CDbl(txt_Emp.Text), 2, MidpointRounding.ToEven)
                txtb_MontoPedi.Text = Format(CDbl(txt_Unidades.Text) * CDbl(txt_Precio.Text), "##,##00.00")

                '-----------------------------------------
                Dim Tbl_PedidoNube As New DataTable
                Dim Tbl_DevolucionesNube As New DataTable
                Dim contardor As Integer = 0
                Dim CantPedidoNube As Integer = 0
                Dim CantDevolucionesNube As Integer = 0

                'verifica si debe obtener lo datos de pedido y devoluciones en tiempo real
                If Class_VariablesGlobales.frmCreaPedido.CBx_ObtieneDatosTeimpoReal.Checked = True Then




                    Tbl_DevolucionesNube = Class_VariablesGlobales.Obj_Funciones_MYSQL.ObtieneDevolucionesDelDia(txt_CodArt.Text.Trim, Class_VariablesGlobales.Obj_Fecha.FormatFechaSqlite(Now.ToShortDateString))
                    Tbl_PedidoNube = Class_VariablesGlobales.Obj_Funciones_MYSQL.ObtienePedidosDelDia(txt_CodArt.Text.Trim, Class_VariablesGlobales.Obj_Fecha.FormatFechaSqlite(Now.ToShortDateString))
                    Try


                        'Recorre la tabla y verifica si el pedido ya existe en SAP,SI existe descarta la cantidad de la suma, SINO suma la cantidad
                        If Tbl_DevolucionesNube IsNot Nothing Then

                            If Tbl_PedidoNube.Rows.Count > 0 Then
                                While contardor < Tbl_PedidoNube.Rows.Count
                                    If Class_VariablesGlobales.Obj_Funciones_SQL.ExistePedidoEnSAP(Class_VariablesGlobales.SQL_Comman2, Tbl_PedidoNube.Rows(contardor).Item("DocNum").ToString().Trim) = True Then

                                    Else
                                        CantPedidoNube = CantPedidoNube + CInt(Tbl_PedidoNube.Rows(contardor).Item("Cantidad").ToString())
                                    End If

                                    contardor += 1
                                End While
                            Else
                                CantPedidoNube = 0
                            End If
                        Else
                            CantPedidoNube = 0
                        End If
                        txtb_Pedido.Text = CantPedidoNube
                        txtb_PedidoCjs.Text = Math.Round(CDbl(txtb_Pedido.Text) / CDbl(txt_Emp.Text), 2, MidpointRounding.ToEven)
                        txtb_PedidoMonto.Text = Format(CDbl(txtb_Pedido.Text) * CDbl(txt_Precio.Text), "##,##00.00")
                    Catch ex As Exception

                    End Try
                    Try



                        'Verifica que el numero de voleta no alla sido procesada
                        contardor = 0
                        If Tbl_DevolucionesNube IsNot Nothing Then


                            If Tbl_DevolucionesNube.Rows.Count > 0 Then
                                While contardor < Tbl_DevolucionesNube.Rows.Count
                                    If Class_VariablesGlobales.Obj_Funciones_SQL.ExisteDevolucionEnSAP(Class_VariablesGlobales.SQL_Comman2, Tbl_DevolucionesNube.Rows(contardor).Item("DocNum").ToString()) = True Then

                                    Else
                                        CantDevolucionesNube = CantDevolucionesNube + CInt(Tbl_DevolucionesNube.Rows(contardor).Item("Cantidad").ToString())
                                    End If

                                    contardor += 1
                                End While
                            Else
                                CantDevolucionesNube = 0
                            End If
                        Else
                            CantDevolucionesNube = 0
                        End If
                        txtb_Devoluciones.Text = CantDevolucionesNube
                        txtb_DevolucionesCjs.Text = Math.Round(CDbl(txtb_Devoluciones.Text) / CDbl(txt_Emp.Text), 2, MidpointRounding.ToEven)
                        txtb_DevolucionesMonto.Text = Format(CDbl(txtb_Devoluciones.Text) * CDbl(txt_Precio.Text), "##,##00.00")
                    Catch ex As Exception

                    End Try

                Else 'si no descargar los datos en tiempo real

                    txtb_Pedido.Text = 0
                    txtb_PedidoCjs.Text = Math.Round(CDbl(txtb_Pedido.Text) / CDbl(txt_Emp.Text), 2, MidpointRounding.ToEven)
                    txtb_PedidoMonto.Text = Format(CDbl(txtb_Pedido.Text) * CDbl(txt_Precio.Text), "##,##00.00")


                    txtb_Devoluciones.Text = 0
                    txtb_DevolucionesCjs.Text = Math.Round(CDbl(txtb_Devoluciones.Text) / CDbl(txt_Emp.Text), 2, MidpointRounding.ToEven)
                    txtb_DevolucionesMonto.Text = Format(CDbl(txtb_Devoluciones.Text) * CDbl(txt_Precio.Text), "##,##00.00")
                End If
            Next


            txtb_Rotacion.Text = Math.Round(CDbl(Textb_Compra.Text) / CDbl(txtb_PromVDiaria.Text), 2, MidpointRounding.ToEven)
            'Carga los graficos para saber el volumen de ventas por dia
            'GraficoVentasXDia(txt_CodArt.Text.Trim)



            'Calcula el sugerido
            'Stock + Devoluciones -(Venta ò Pedido)-comprometido-Pedido en curso
            'Nota:
            'Las Devoluciones en curso son solo de choferes ya que el de agentes puede que vaya para bodega 2
            'Se agarra el monto mayor entre la venta y pedido ya que puede ser que las ventas las hagan directo a oficina
            'Se agarra el monto mayor entre la venta y pedido ya que puede ser que las ventas las hagan directo a oficina
            'Comprometido en lo que ya esta en SAP procesado por lo que esta proximo a facturar
            'Pedido en curso es lo que los agentes ha pedido hasta el momento de entrar
            Dim MontoMayor As Integer
            If CInt(txt_Venta_Unid.Text) > CInt(txtb_PedidoXAgente.Text) Then
                MontoMayor = CInt(txt_Venta_Unid.Text)
            Else
                MontoMayor = CInt(txtb_PedidoXAgente.Text)
            End If

            txt_Stock_Dispobles.Text = CInt(txt_Stock_Unid.Text) - CInt(textb_Comprometido.Text) - CInt(txtb_Pedido.Text) + CInt(txtb_Devoluciones.Text)
            txt_Stock_Dispobles_Cjs.Text = Math.Round(CDbl(CInt(txt_Stock_Dispobles.Text)) / CDbl(txt_Emp.Text), 2, MidpointRounding.ToEven)
            txt_Stock_Monto.Text = Format(CDbl(txt_Stock_Dispobles.Text) * CDbl(txt_Precio.Text), "##,##00.00")


            'obtiene la venta x dia

            txtb_PromVDiaria.Text = Math.Round(MontoMayor / CDbl(Class_VariablesGlobales.frmCreaPedido.txtb_DiasACubrir.Text), 2, MidpointRounding.ToEven)
            If txtb_PromVDiaria.Text = "0" Then
                txtb_DiasInve.Text = "0"
            Else
                txtb_DiasInve.Text = Math.Round(CDbl(txt_Stock_Dispobles.Text) / CDbl(txtb_PromVDiaria.Text), 2, MidpointRounding.ToEven)
            End If

            If CDbl(txtb_DiasInve.Text) > 10 Or (CDbl(txtb_DiasInve.Text) = 0 And CDbl(txt_Stock_Unid.Text) > 0) Then
                txtb_DiasInve.BackColor = Color.Red
                txtb_DiasInve.ForeColor = Color.White
            Else
                txtb_DiasInve.BackColor = Color.White
                txtb_DiasInve.ForeColor = Color.Black
            End If
            'Si la cantidad a pedir es 0 Stock+Devoluciones
            If txt_Cantidad.Text = "" Or txt_Cantidad.Text = "0" And txt_Cantidad.BackColor = Color.White Then

                'Le restamos la venta de la semana pasada para saber cuanto queda disponible de colchon
                'txt_Cantidad.Text = CInt(txt_Stock_Dispobles.Text) - CInt(MontoMayor)

                'If (CInt(txt_Cantidad.Text) < 0) Then
                '    txt_Cantidad.Text = CInt(txt_Cantidad.Text) * -1
                '    txt_Cantidad.Text = Math.Ceiling(CInt(txt_Cantidad.Text) / CInt(txt_Emp.Text)) * CInt(txt_Emp.Text)
                'Else
                '    'txt_Cantidad.Text = 0
                'End If
                ''txt_Unidades.Text = txt_Cantidad.Text
                ''txt_Cajas.Text = Math.Round(CDbl(txt_Unidades.Text) / CDbl(txt_Emp.Text), 2, MidpointRounding.ToEven)
                ''txtb_MontoPedi.Text = Format(CDbl(txt_Unidades.Text) * CDbl(txt_Precio.Text), "##,##00.00")

                'txtb_Disponible.Text = CInt(txt_Cantidad.Text)
                If CDbl(txtb_PromVDiaria.Text) = 0 Then
                    txtb_StockCubrira.Text = 0
                Else
                    txtb_StockCubrira.Text = Math.Round(CDbl(txt_Stock_Dispobles.Text) / CDbl(txtb_PromVDiaria.Text), 2, MidpointRounding.ToEven)
                End If



                If txtb_StockCubrira.Text <> "" Then


                    'SI ASIGNAMOS LOS DIAS RESTANTES A CUBRIR YA CON ESO DAMOS UN SUGERIDO
                    If CDbl(txtb_DiasInve.Text) > 0 Then

                        'COLOREA LOS DIAS SI ESTOS EXCELENTE MAS DE 10 DIAS
                        If CDbl(txtb_DiasInve.Text) > 10 Then
                            txtb_DiasInve.BackColor = Color.Red
                            txtb_DiasInve.ForeColor = Color.White
                        Else
                            txtb_DiasInve.BackColor = Color.White
                            txtb_DiasInve.ForeColor = Color.Black
                        End If


                        'le restamos a los indias insicados en la semana de ventas - los dias que cubre el inventario disponible para saber cuantos dias hacen falta cubrir para evitar faltantes
                        txtb_StockCubrira.Text = CDbl(Class_VariablesGlobales.frmCreaPedido.txtb_DiasACubrir.Text) - CDbl(txtb_StockCubrira.Text)

                    Else
                        txtb_StockCubrira.Text = CDbl(Class_VariablesGlobales.frmCreaPedido.txtb_DiasACubrir.Text) + (CDbl(txtb_DiasInve.Text) * -1)
                    End If

                    If CDbl(txtb_StockCubrira.Text) < 0 Then
                        txtb_StockCubrira.Text = "0"
                    End If

                    Dim sugerido As Double


                    'calcula sugerido,si Ventas>pedido resta el stockdisponible - el valor mas alto entre pedido y venta

                    sugerido = CDbl(txt_Stock_Dispobles.Text) - MontoMayor
                    'pasa a un valor positivo ya que si da negativo es por que el inventario disponible no alcanzara para cubrir los priximos 7 dias por da run ejempli
                    If (sugerido < 0) Then
                        sugerido = sugerido * -1
                    Else
                        sugerido = 0
                    End If

                    txt_Cantidad.Text = sugerido




                    '  txt_Cantidad.Text = CDbl(txtb_StockCubrira.Text) * CDbl(txtb_PromVDiaria.Text)

                    'Redonde hacia arriba
                    txt_Cantidad.Text = Math.Ceiling(CInt(txt_Cantidad.Text) / CInt(txt_Emp.Text)) * CInt(txt_Emp.Text)
                    'redonde hacia abajo
                    'txt_Cantidad.Text = Math.Floor(Math.Abs(CInt(txt_Cantidad.Text) / CInt(txt_Emp.Text))) * CInt(txt_Emp.Text)
                    If txt_Cantidad.Text = "0" Then
                        'si el sugerido es 0 entonces los dias a cubri seria 0 ya que no pide nada
                        txtb_StockCubrira.Text = "0"
                    Else
                        'calcula segun vendia promedio por dia los dias a cubri
                        txtb_StockCubrira.Text = Math.Round(CDbl(txt_Cantidad.Text) / CDbl(txtb_PromVDiaria.Text), 2, MidpointRounding.ToEven)
                    End If

                    'If txt_Cantidad.Text = "0" Or txt_Cantidad.Text = "" Then
                    '    txt_Cantidad.Text = (CInt(txt_Stock_Unid.Text) + CInt(txtb_Devoluciones.Text)) - CInt(MontoMayor) - CInt(textb_Comprometido.Text) - CInt(txtb_Pedido.Text)
                    '    If (CInt(txt_Cantidad.Text) < 0) Then
                    '        txt_Cantidad.Text = CInt(txt_Cantidad.Text) * -1
                    '        txt_Cantidad.Text = Math.Ceiling(CInt(txt_Cantidad.Text) / CInt(txt_Emp.Text)) * CInt(txt_Emp.Text)
                    '        'SI EL SUGERIDO CUBRE LA CANTIDAD DE DIAS QUE AL INICIO SE INDICO PARA SACAR LA VENTA ENTONCES SE MANTIENE 
                    '        'DE LO CONTRARIO SE MULTIPLICA Y CALCULA SEGUN EL PROMEDIO DE VENTA Y LA CANTIDAD DE DIAS A CUBRIR

                    '        If (CInt(txt_Cantidad.Text) / CInt(txtb_PromVDiaria.Text)) >= CInt(Class_VariablesGlobales.frmCreaPedido.txtb_DiasACubrir.Text) Then
                    '        Else
                    '        txt_Cantidad.Text = Math.Ceiling((CInt(txtb_PromVDiaria.Text) * CInt(Class_VariablesGlobales.frmCreaPedido.txtb_DiasACubrir.Text)) / CInt(txt_Emp.Text)) * CInt(txt_Emp.Text)

                    '    End If
                    '    Else
                    '        txt_Cantidad.Text = 0
                    '    End If
                    'End If

                    ''txt_Unidades.Text = txt_Cantidad.Text
                    ''txt_Cajas.Text = Math.Round(CDbl(txt_Unidades.Text) / CDbl(txt_Emp.Text), 2, MidpointRounding.ToEven)
                    ''txtb_MontoPedi.Text = Format(CDbl(txt_Unidades.Text) * CDbl(txt_Precio.Text), "##,##00.00")

                    'txtb_Disponible.Text = CInt(txt_Cantidad.Text)
                    'txtb_StockCubrira.Text = Math.Round(CDbl(txtb_Disponible.Text) / CDbl(txtb_PromVDiaria.Text), 2, MidpointRounding.ToEven)

                    'txt_Stock_Dispobles.Text = CInt(txt_Stock_Unid.Text) - CInt(textb_Comprometido.Text) - CInt(txtb_Pedido.Text) + CInt(txtb_Devoluciones.Text)

                    ''SI ASIGNAMOS LOS DIAS RESTANTES A CUBRIR YA CON ESO DAMOS UN SUGERIDO
                    'txtb_StockCubrira.Text = CInt(Class_VariablesGlobales.frmCreaPedido.txtb_DiasACubrir.Text) - CInt(txtb_DiasInve.Text)
                End If

            End If
            txt_Cantidad.SelectAll()
            txt_Cantidad.Focus()
            Class_VariablesGlobales.frmCreaPedido_DetalleVenta.Close()
        Catch ex As Exception
            'MsgBox("Navegar  " & ex.Message, MsgBoxStyle.Information, "ERROR")
        End Try
        Cursor = System.Windows.Forms.Cursors.Default
    End Function




    Private Sub EditaLineaPedido_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Class_VariablesGlobales.frmEditaLinePedido = Nothing


    End Sub

    Private Sub txtb_StockCubrira_TextChanged(sender As Object, e As EventArgs) Handles txtb_StockCubrira.TextChanged
        Try

            If ModificadoDesdeCantidad = False Then


                'Multiplica el numero digitado por el promedio
                If txtb_StockCubrira.Text = "" Then
                    txtb_StockCubrira.Text = "0"

                End If
                If txtb_PromVDiaria.Text <> "0" Then
                    txt_Cantidad.Text = CInt(CDbl(txtb_PromVDiaria.Text) * CDbl(txtb_StockCubrira.Text))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_Cantidad_TextChanged(sender As Object, e As EventArgs) Handles txt_Cantidad.TextChanged

        Try
            Dim cantidad As String = ""
            ModificadoDesdeCantidad = True
            If txt_Cantidad.Text = "" Then

                cantidad = "0"
            Else
                cantidad = txt_Cantidad.Text
            End If

            txtb_Disponible.Text = CInt(cantidad) + CInt(txt_Stock_Dispobles.Text)
            txtb_DiasNewDisponible.Text = Math.Round(CDbl(CDbl(txtb_Disponible.Text) / CDbl(txtb_PromVDiaria.Text)), 2, MidpointRounding.ToEven)
            ''SE DEBE LLAMAR A LA FUNCION CONVERTIDORA
            If RdBtb_Cajas.Checked = True Then
                txt_Cajas.Text = CDbl(cantidad)
                txt_Unidades.Text = CDbl(cantidad) * CInt(txt_Emp.Text)
                txtb_MontoPedi.Text = Format((CDbl(cantidad) * CInt(txt_Emp.Text)) * CDbl(txt_Precio.Text), "##,##00.00")

            Else
                txt_Cajas.Text = FormatNumber(CDbl(cantidad) / CInt(txt_Emp.Text), 2)
                'Conversion = Obj_Conversion.Unidad_A_Cjs(CInt(cantidad), CInt(txt_Emp.Text))
                'txt_Cajas.Text = Conversion(0)
                txt_Unidades.Text = cantidad
                txtb_MontoPedi.Text = Format(CDbl(cantidad) * CDbl(txt_Precio.Text), "##,##00.00")

            End If

            If CInt(txt_Venta_Unid.Text) < 0 Then

                Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows(txtb_Index.Text).Cells("ItemCode").Style.BackColor = Color.White
                Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows(txtb_Index.Text).Cells("ItemCode").Style.ForeColor = Color.Black



            End If



        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtb_StockCubrira_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtb_StockCubrira.KeyPress
        ModificadoDesdeCantidad = False
    End Sub




    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles Chart1.Click
        Class_VariablesGlobales.frmCreaPedido_DetalleVenta = New Pedido_DetalleVenta
        Class_VariablesGlobales.frmCreaPedido_DetalleVenta.MdiParent = Principal

        Class_VariablesGlobales.frmCreaPedido_DetalleVenta.DataGridView1.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.VentaDetallada(Class_VariablesGlobales.SQL_Comman2, txt_CodArt.Text)
        'T00.[DocNum],T00.DocDate,T00.Cantidad,T00.DiscPrcnt,T00.CardCode,T00.CardName
        Class_VariablesGlobales.frmCreaPedido_DetalleVenta.DataGridView1.Columns(0).Width = 80 '[DocNum]
        Class_VariablesGlobales.frmCreaPedido_DetalleVenta.DataGridView1.Columns(1).Width = 80 '[DocDate]
        Class_VariablesGlobales.frmCreaPedido_DetalleVenta.DataGridView1.Columns(2).Width = 50 '[Cantidad]
        Class_VariablesGlobales.frmCreaPedido_DetalleVenta.DataGridView1.Columns(3).Width = 50 '[DiscPrcnt]
        Class_VariablesGlobales.frmCreaPedido_DetalleVenta.DataGridView1.Columns(4).Width = 80 '[CardCode]
        Class_VariablesGlobales.frmCreaPedido_DetalleVenta.DataGridView1.Columns(5).Width = 450 '[CardNam]

        Class_VariablesGlobales.frmCreaPedido_DetalleVenta.Show()
    End Sub

    Private Sub btn_VerDevoluciones_Click(sender As Object, e As EventArgs) Handles btn_VerDevoluciones.Click
        Class_VariablesGlobales.VerDatosNube = "DEVOLUCIONES"
        Class_VariablesGlobales.frmPedido_VerDatosNube = New Pedido_VerDatosNube
        Class_VariablesGlobales.frmPedido_VerDatosNube.MdiParent = Principal
        Class_VariablesGlobales.frmPedido_VerDatosNube.txt_CodArt.Text = txt_CodArt.Text
        Class_VariablesGlobales.frmPedido_VerDatosNube.Show()

    End Sub

    Private Sub btn_VerPedidos_Click(sender As Object, e As EventArgs) Handles btn_VerPedidos.Click
        Class_VariablesGlobales.VerDatosNube = "PEDIDOS"
        Class_VariablesGlobales.frmPedido_VerDatosNube = New Pedido_VerDatosNube
        Class_VariablesGlobales.frmPedido_VerDatosNube.MdiParent = Principal
        Class_VariablesGlobales.frmPedido_VerDatosNube.txt_CodArt.Text = txt_CodArt.Text
        Class_VariablesGlobales.frmPedido_VerDatosNube.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Class_VariablesGlobales.VerDatosNube = "PEDIDOS_DETALLE"
        Class_VariablesGlobales.frmPedido_VerDatosNube = New Pedido_VerDatosNube
        Class_VariablesGlobales.frmPedido_VerDatosNube.MdiParent = Principal
        Class_VariablesGlobales.frmPedido_VerDatosNube.txt_CodArt.Text = txt_CodArt.Text
        Class_VariablesGlobales.frmPedido_VerDatosNube.Show()
    End Sub

End Class