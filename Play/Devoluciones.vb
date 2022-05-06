


Public Class Devoluciones

    ' Public oCompany As New SAPbobsCOM.Company
    'Public obj_SAP As New SAP_BUSSINES_ONE

    Public Obj_Mformat As New MonedaFormat
    Public indice As Integer
    Public menu As ContextMenuStrip
    Public tbhath As New Hashtable
    Public tbhath2 As New Hashtable
    Private Sub Devoluciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'VariablesGlobales.oCompany = obj_SAP.ConectarSap()
        Me.Dtg_Devoluciones.EditMode = DataGridViewEditMode.EditOnEnter

        Dim tabla As New DataTable

        tabla = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneRutas(Class_VariablesGlobales.SQL_Comman2)

        Dim cont As Integer

        For Each row As DataRow In tabla.Rows

            tbhath.Add(tabla.Rows(cont).Item("Code").ToString(), tabla.Rows(cont).Item("Name").ToString())
            tbhath2.Add(tabla.Rows(cont).Item("Name").ToString(), tabla.Rows(cont).Item("Code").ToString())

            CBox_Rutas.Items.Add(tabla.Rows(cont).Item("Name").ToString())
            cont += 1
        Next



        'txtb_Numero.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ConsultaConsecutivoDevoluciones(Class_VariablesGlobales.SQL_Comman2)
    End Sub


    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dtg_Devoluciones.CellContentClick
        'quita la seleccion de la fila
        Dtg_Devoluciones.Rows(e.RowIndex).Selected = False
        'selecciona la celda
        Dtg_Devoluciones.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
        'inicia la edicion
        Dtg_Devoluciones.BeginEdit(True)
    End Sub

    Public Function CalculaTotal()
        Dim total As Double
        Dim Subtotal As Double
        Dim Mont_Imp As Double
        Dim Mont_Desc As Double

        For Each row As DataGridViewRow In Dtg_Devoluciones.Rows


            Mont_Imp += CDbl(row.Cells("Mont_Imp").Value)
            Subtotal += CDbl(row.Cells("Sub_Total").Value)
            Mont_Desc += CDbl(row.Cells("Mont_Desc").Value)
            total += CDbl(row.Cells("total").Value)

        Next


        txtb_SubTotal.Text = Obj_Mformat.FormatoMoneda(Subtotal)
        txtb_Desc.Text = Obj_Mformat.FormatoMoneda(Mont_Desc)
        txtb_Impuesto.Text = Obj_Mformat.FormatoMoneda(Mont_Imp)
        txtb_Total.Text = Obj_Mformat.FormatoMoneda(total)
        total = Nothing
        Subtotal = Nothing
        Mont_Imp = Nothing
        Mont_Desc = Nothing

    End Function

    Public Function Cargar(ByVal DocNum As String, Ver As String)
        Try


            Me.Controls.Add(Dtg_Devoluciones)
            ' indica la cantidad de columnas a mostrar
            Dtg_Devoluciones.ColumnCount = 16

            With Dtg_Devoluciones
                .Name = "DetalleDevolucion"
                .RowHeadersVisible = False
                .Columns(0).Name = "#"
                .Columns(0).Width = 20
                .Columns(1).Name = "Codigo"
                .Columns(1).Width = 75
                .Columns(2).Name = "Descripcion"
                .Columns(2).Width = 300
                .Columns(3).Name = "Precio"
                .Columns(3).Width = 60
                .Columns(4).Name = "Cant"
                .Columns(4).Width = 45
                .Columns(5).Name = "%Desc"
                .Columns(5).Width = 45
                .Columns(6).Name = "%Fijo"
                .Columns(6).Width = 45
                .Columns(7).Name = "%Promo"
                .Columns(7).Width = 45
                .Columns(8).Name = "Total"
                .Columns(8).Width = 100
                .Columns(9).Name = "Bodega"
                .Columns(9).Width = 40
                .Columns(10).Name = "IV"
                .Columns(10).Width = 40
                .Columns(11).Name = "Porc_DescAnt"
                .Columns(11).Width = 40
                .Columns(11).Visible = False
                .Columns(12).Name = "Mont_Imp"
                .Columns(12).Width = 100
                .Columns(12).Visible = False
                .Columns(13).Name = "Sub_Total"
                .Columns(13).Width = 100
                .Columns(13).Visible = False

                .Columns(14).Name = "Mont_Desc"
                .Columns(14).Width = 100
                .Columns(14).Visible = False
                .Columns(15).Name = "Comentarios"
                .Columns(15).Width = 300
                '.Columns(4).DefaultCellStyle.Font = New Font(Me.DataGridView2.DefaultCellStyle.Font, FontStyle.Italic)
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .MultiSelect = False

                '.Dock = DockStyle.Fill
            End With

            Dim CombColum2 As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn
            CombColum2.HeaderText = "Motivo"
            CombColum2.Name = "Motivo"
            CombColum2.Width = 250

            Dim Row2 As ArrayList = New ArrayList()

            Row2.Add("M01:Cliente no lo pidio")
            Row2.Add("M02:Facturado de mas")
            Row2.Add("M03:Negocio Cerrado")
            Row2.Add("M04:Cliente no tiene dinero")
            Row2.Add("M05:No se localizo negocio")
            Row2.Add("M06:Falta Promocion en pedido")
            Row2.Add("M07:No esta el responsable")
            Row2.Add("M08:Ruta incompleta")
            Row2.Add("M09:Vencido")
            Row2.Add("M10:Producto Danado")
            Row2.Add("M11:Producto salio cambiado")
            Row2.Add("M12:Faltante en bodega")
            Row2.Add("M13:Producto sin rotacion")
            Row2.Add("M14:Facturado y no salio el producto")
            Row2.Add("M15:Condicion de pago no coincide")
            Row2.Add("M16:Retraso entrega")
            Row2.Add("M17:Otros")
            Row2.Add("M18:Cliente no recibio")
            Row2.Add("M19:No cancelo Factura")
            Row2.Add("M20:Fecha vencimiento proxima")

            CombColum2.Items.AddRange(Row2.ToArray)
            Dtg_Devoluciones.Columns.Add(CombColum2)


            With Dtg_Devoluciones
                .Name = "DetalleDevolucion"
                .RowHeadersVisible = False
                .Columns(0).Name = "#"
                .Columns(0).Width = 20
                .Columns(1).Name = "Codigo"
                .Columns(1).Width = 75
                .Columns(2).Name = "Descripcion"
                .Columns(2).Width = 300
                .Columns(3).Name = "Precio"
                .Columns(3).Width = 60
                .Columns(4).Name = "Cant"
                .Columns(4).Width = 45
                .Columns(5).Name = "%Desc"
                .Columns(5).Width = 45
                .Columns(6).Name = "%Fijo"
                .Columns(6).Width = 45
                .Columns(7).Name = "%Promo"
                .Columns(7).Width = 45
                .Columns(8).Name = "Total"
                .Columns(8).Width = 100
                .Columns(9).Name = "Bodega"
                .Columns(9).Width = 40
                .Columns(10).Name = "IV"
                .Columns(10).Width = 40
                .Columns(11).Name = "Porc_DescAnt"
                .Columns(11).Width = 40
                .Columns(12).Name = "Mont_Imp"
                .Columns(12).Width = 100
                .Columns(13).Name = "Sub_Total"
                .Columns(13).Width = 100
                .Columns(14).Name = "Mont_Desc"
                .Columns(14).Width = 100
                .Columns(15).Name = "Comentarios"
                .Columns(15).Width = 300
                '.Columns(4).DefaultCellStyle.Font = New Font(Me.DataGridView2.DefaultCellStyle.Font, FontStyle.Italic)
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .MultiSelect = False

                '.Dock = DockStyle.Fill
            End With



            Dim Tabla As New DataTable
            Dim cont As Integer
            Dim total As Double
            Dim Subtotal As Double
            Dim Imptotal As Double
            Dim Desctotal As Double

            Tabla = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDevolucione(DocNum, Ver, Class_VariablesGlobales.SQL_Comman1)
            If Tabla.Rows.Count > 0 Then


                'recorrer los datos
                For Each Fila As DataRow In Tabla.Rows


                    txtb_DocNum.Text = Tabla.Rows(cont).Item("DocNum").ToString()
                    txtb_Fecha.Text = Tabla.Rows(cont).Item("FechaNota").ToString()
                    txb_hora.Text = Tabla.Rows(cont).Item("HoraNota").ToString()
                    txtb_CodChofer.Text = Tabla.Rows(cont).Item("CodChofer").ToString().PadLeft(2, "0")
                    txtb_NombreCofer.Text = Tabla.Rows(cont).Item("NombreChofer").ToString()
                    txtb_CodCliente.Text = Tabla.Rows(cont).Item("CodCliente").ToString()
                    txtb_Nombre.Text = Tabla.Rows(cont).Item("NombreCliente").ToString()
                    'txtb_.Text = Tabla.Rows(cont).Item("Credito").ToString()
                    txtb_IdRuta.Text = Tabla.Rows(cont).Item("IdRuta").ToString()
                    txtb_Ruta.Text = Tabla.Rows(cont).Item("Ruta").ToString()
                    CBox_Rutas.Text = Tabla.Rows(cont).Item("Ruta").ToString()
                    txtb_Referencia.Text = Tabla.Rows(cont).Item("NumFactura").ToString()
                    txtb_DocEntry.Text = Tabla.Rows(cont).Item("DocEntry").ToString()

                    CBox_Motivo.Text = "Corrige Monto"
                    If Tabla.Rows(cont).Item("Comentario").ToString() = "" Then
                        TXTB_Comentario.Text = "#M: " & Tabla.Rows(cont).Item("NumMarchamo").ToString()
                    Else
                        TXTB_Comentario.Text = Tabla.Rows(cont).Item("Comentario").ToString()
                    End If




                Next
            End If
            Tabla = New DataTable

            Tabla = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDetalleDevolucione(DocNum, Class_VariablesGlobales.SQL_Comman1)
            If Tabla.Rows.Count > 0 Then
                'recorrer los datos
                For Each Fila As DataRow In Tabla.Rows

                    Dtg_Devoluciones.Rows.Add()
                    'detalle
                    Dtg_Devoluciones.Rows(cont).Cells(0).Value = Tabla.Rows(cont).Item("NumLinea").ToString()
                    Dtg_Devoluciones.Rows(cont).Cells(1).Value = Tabla.Rows(cont).Item("ItemCode").ToString()
                    Dtg_Devoluciones.Rows(cont).Cells(2).Value = Tabla.Rows(cont).Item("ItemName").ToString()
                    Dtg_Devoluciones.Rows(cont).Cells(3).Value = Tabla.Rows(cont).Item("Precio").ToString()
                    Dtg_Devoluciones.Rows(cont).Cells(4).Value = Tabla.Rows(cont).Item("Quantity").ToString()
                    Dtg_Devoluciones.Rows(cont).Cells(5).Value = Tabla.Rows(cont).Item("Porc_Desc").ToString()
                    Dtg_Devoluciones.Rows(cont).Cells(5).ReadOnly = True

                    Dtg_Devoluciones.Rows(cont).Cells(6).Value = Tabla.Rows(cont).Item("Porc_Desc_Fijo").ToString()
                    Dtg_Devoluciones.Rows(cont).Cells(7).Value = Tabla.Rows(cont).Item("Porc_Desc_Promo").ToString()
                    Dtg_Devoluciones.Rows(cont).Cells(8).Value = Obj_Mformat.FormatoMoneda(Tabla.Rows(cont).Item("Total").ToString())

                    'total += CDbl(Tabla.Rows(cont).Item("Total").ToString())
                    'Subtotal += CDbl(Tabla.Rows(cont).Item("Sub_Total").ToString())
                    'Desctotal += CDbl(Tabla.Rows(cont).Item("Mont_Desc").ToString())
                    'Imptotal += CDbl(Tabla.Rows(cont).Item("Mont_Imp").ToString())


                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M10:Producto Dañado" Then
                        Dtg_Devoluciones.Rows(cont).Cells(9).Value = "02"
                    Else
                        Dtg_Devoluciones.Rows(cont).Cells(9).Value = "01"
                    End If


                    Dtg_Devoluciones.Rows(cont).Cells(10).Value = Tabla.Rows(cont).Item("Porc_Imp").ToString()
                    Dtg_Devoluciones.Rows(cont).Cells(11).Value = Tabla.Rows(cont).Item("Porc_Desc").ToString()

                    Dtg_Devoluciones.Rows(cont).Cells(12).Value = Tabla.Rows(cont).Item("Mont_Imp").ToString()
                    Dtg_Devoluciones.Rows(cont).Cells(13).Value = Tabla.Rows(cont).Item("Sub_Total").ToString()
                    Dtg_Devoluciones.Rows(cont).Cells(14).Value = Tabla.Rows(cont).Item("Mont_Desc").ToString()
                    Dtg_Devoluciones.Rows(cont).Cells(15).Value = Tabla.Rows(cont).Item("Comentarios").ToString()

                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M01:Cliente no lo pidio" Then
                        Dtg_Devoluciones.Rows(cont).Cells(16).Value = "M01:Cliente no lo pidio"
                    End If
                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M02:Facturado de mas" Then
                        Dtg_Devoluciones.Rows(cont).Cells(16).Value = "M02:Facturado de mas"
                    End If
                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M03:Negocio Cerrado" Then
                        Dtg_Devoluciones.Rows(cont).Cells(16).Value = "M03:Negocio Cerrado"
                    End If
                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M04:Cliente no tiene dinero" Then
                        Dtg_Devoluciones.Rows(cont).Cells(16).Value = "M04:Cliente no tiene dinero"
                    End If
                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M05:No se localizo negocio" Then
                        Dtg_Devoluciones.Rows(cont).Cells(16).Value = "M05:No se localizo negocio"
                    End If
                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M06:Falta Promocion en pedido" Then
                        Dtg_Devoluciones.Rows(cont).Cells(16).Value = "M06:Falta Promocion en pedido"
                    End If
                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M07:No esta el responsable" Then
                        Dtg_Devoluciones.Rows(cont).Cells(16).Value = "M07:No esta el responsable"
                    End If
                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M08:Ruta incompleta" Then
                        Dtg_Devoluciones.Rows(cont).Cells(16).Value = "M08:Ruta incompleta"
                    End If
                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M09:Vencido" Then
                        Dtg_Devoluciones.Rows(cont).Cells(16).Value = "M09:Vencido"
                    End If
                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M10:Producto Danado" Then
                        Dtg_Devoluciones.Rows(cont).Cells(16).Value = "M10:Producto Danado"
                    End If
                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M11:Producto salio cambiado" Then
                        Dtg_Devoluciones.Rows(cont).Cells(16).Value = "M11:Producto salio cambiado"
                    End If
                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M12:Faltante en bodega" Then
                        Dtg_Devoluciones.Rows(cont).Cells(16).Value = "M12:Faltante en bodega"
                    End If
                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M13:Producto sin rotacion" Then
                        Dtg_Devoluciones.Rows(cont).Cells(16).Value = "M13:Producto sin rotacion"
                    End If
                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M14:Facturado y no salio el producto" Then
                        Dtg_Devoluciones.Rows(cont).Cells(16).Value = "M14:Facturado y no salio el producto"
                    End If
                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M15:Condicion de pago no coincide" Then
                        Dtg_Devoluciones.Rows(cont).Cells(16).Value = "M15:Condicion de pago no coincide"
                    End If
                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M16:Retraso entrega" Then
                        Dtg_Devoluciones.Rows(cont).Cells(16).Value = "M16:Retraso entrega"
                    End If
                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M17:Otros" Then
                        Dtg_Devoluciones.Rows(cont).Cells(16).Value = "M17:Otros"
                    End If
                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M18:Cliente no recibio" Then
                        Dtg_Devoluciones.Rows(cont).Cells(16).Value = "M18:Cliente no recibio"
                    End If
                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M19:No cancelo Factura" Then
                        Dtg_Devoluciones.Rows(cont).Cells(16).Value = "M19:No cancelo Factura"
                    End If
                    If Tabla.Rows(cont).Item("Motivo").ToString() = "M20:Fecha vencimiento proxima" Then
                        Dtg_Devoluciones.Rows(cont).Cells(16).Value = "M20:Fecha vencimiento proxima"
                    End If


                    If Tabla.Rows(cont).Item("Procesada").ToString() = "0" Then
                        btn_CrearSap.Enabled = True
                        btn_Guardar.Enabled = True
                        btn_Anular.Enabled = True
                    Else
                        btn_CrearSap.Enabled = False
                        btn_Guardar.Enabled = False
                        btn_Anular.Enabled = False
                    End If


                    CalculaTotalLinea(cont)


                    cont += 1
                Next



            End If

            CalculaTotal()

            'txtb_Total.Text = Obj_Mformat.FormatoMoneda(total)
            'txtb_SubTotal.Text = Obj_Mformat.FormatoMoneda(Subtotal)
            'txtb_Impuesto.Text = Obj_Mformat.FormatoMoneda(Imptotal)
            'txtb_Desc.Text = Obj_Mformat.FormatoMoneda(Desctotal)

            If txtb_DocEntry.Text = "" Then
                txtb_DocEntry.BackColor = Color.Red
                lbl_devoluciones.ForeColor = Color.Red
                btn_CrearSap.Enabled = False
            Else
                txtb_DocEntry.BackColor = Color.White
                lbl_devoluciones.ForeColor = Color.Black
                btn_CrearSap.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Function
    Private Sub btn_CrearSap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CrearSap.Click

        Try
            Dim problema As String = ""

            Dim CodChofer As String
            Dim NombreChofer As String
            Dim CodCliente As String
            Dim NombreCliente As String
            Dim Credito As String
            Dim NumFactura As String
            Dim DocEntry As String
            Dim Motivo As String
            Dim IdRuta As String
            Dim Ruta As String
            Dim Mont_Imp As String
            Dim Sub_Total As String
            Dim Mont_Desc As String
            Dim Total As String
            Dim Procesada As String
            Dim NumMarchamo As String
            Dim DocNum As String
            Dim Comentario As String

            Dim ItemCode As String
            Dim Porc_DescAnt As String
            Dim Precio As String
            Dim Quantity As String
            Dim Porc_Desc As String
            Dim MotivoLinea As String
            Dim Porc_Desc_Fijo As String
            Dim Porc_Desc_Promo As String
            Dim Mont_ImpLinea As String
            Dim Sub_TotalLinea As String
            Dim Mont_DescLinea As String
            Dim TotalLinea As String
            Dim ProcesadaLinea As String
            Dim Bodega As String
            Dim encabezado As Boolean
            Dim SinMoivo As Boolean = False


            If txtb_Referencia.Text = "" And txtb_DocEntry.Text = "" Then

                problema = " Debe ingresar un numero de factura"
                MsgBox(" Debe ingresar un numero de factura")

            End If
            If CBox_Rutas.Text = "" Or CBox_Rutas.Text = "0" Then

                problema = " Debe indicar una ruta"
                MsgBox(" Debe indicar una ruta")

            End If
            If CBox_Motivo.Text = "" Or CBox_Motivo.Text = "0" Then

                problema = " Debe indicar un motivo"
                MsgBox(" Debe indicar un motivo")

            End If

            If problema = "" Then





                Dim Pregunta As Integer
                Pregunta = MsgBox("¿Realmente desea Crear la Nota de credito?.", vbYesNo + vbExclamation + vbDefaultButton2, "SUBIR NOTA DE CREDITO")

                If Pregunta = vbYes Then
                    'TABLA ENCABEZADO DE PEDIDO
                    Dim EncabezadoOrdenCompra As New DataTable
                    'EncabezadoOrdenCompra.Columns.Add("DocNum")
                    EncabezadoOrdenCompra.Columns.Add("CardCode")
                    EncabezadoOrdenCompra.Columns.Add("Date")
                    EncabezadoOrdenCompra.Columns.Add("Hora")
                    EncabezadoOrdenCompra.Columns.Add("CondicionPago")
                    EncabezadoOrdenCompra.Columns.Add("SalesPersonCode")
                    EncabezadoOrdenCompra.Columns.Add("Motivo")
                    EncabezadoOrdenCompra.Columns.Add("IdRuta")
                    EncabezadoOrdenCompra.Columns.Add("Ruta")
                    EncabezadoOrdenCompra.Columns.Add("DocEntry")
                    EncabezadoOrdenCompra.Columns.Add("Comentario")
                    EncabezadoOrdenCompra.Columns.Add("NumFactura")

                    'TABLA DETALLE PEDIDO
                    Dim DetalleOrdenCompra As New DataTable
                    'DetalleOrdenCompra.Columns.Add("DocNum")
                    DetalleOrdenCompra.Columns.Add("ItemCode")
                    DetalleOrdenCompra.Columns.Add("Quantity")
                    DetalleOrdenCompra.Columns.Add("Currency")
                    DetalleOrdenCompra.Columns.Add("Bodega")
                    DetalleOrdenCompra.Columns.Add("DiscountPercent")
                    DetalleOrdenCompra.Columns.Add("U_DescFijo")
                    DetalleOrdenCompra.Columns.Add("U_DescProm")
                    DetalleOrdenCompra.Columns.Add("Motivo")
                    DetalleOrdenCompra.Columns.Add("Precio")



                    For Each row As DataGridViewRow In Dtg_Devoluciones.Rows
                        Try
                            If Not row Is Nothing Then


                                CodChofer = ""
                                NombreChofer = ""
                                CodCliente = ""
                                NombreCliente = ""
                                Credito = ""
                                NumFactura = ""
                                DocEntry = ""
                                Motivo = ""
                                IdRuta = ""
                                Ruta = ""
                                Mont_Imp = ""
                                Sub_Total = ""
                                Mont_Desc = ""
                                Total = ""
                                Procesada = ""
                                NumMarchamo = ""
                                DocNum = ""
                                Comentario = ""

                                DocNum = ""
                                ItemCode = ""
                                Porc_DescAnt = ""
                                Precio = ""
                                Quantity = ""
                                Porc_Desc = ""
                                MotivoLinea = ""
                                Porc_Desc_Fijo = ""
                                Porc_Desc_Promo = ""
                                Mont_ImpLinea = ""
                                Sub_TotalLinea = ""
                                Mont_DescLinea = ""
                                TotalLinea = ""
                                Procesada = ""
                                Bodega = ""
                                If CStr(row.Cells(0).Value) <> "" Then

                                    If encabezado = False Then
                                        Dim Enc_dr As DataRow = EncabezadoOrdenCompra.NewRow
                                        'Enc_dr("DocNum") = Val(row.Cells(17).Value)
                                        Enc_dr("CardCode") = txtb_CodCliente.Text
                                        Enc_dr("Date") = Now.Date
                                        Enc_dr("Hora") = TimeOfDay
                                        'Enc_dr("CondicionPago") = txtb_CondiconPago.Text
                                        Enc_dr("SalesPersonCode") = txtb_CodChofer.Text
                                        Enc_dr("DocEntry") = Trim(txtb_DocEntry.Text)
                                        Enc_dr("NumFactura") = Trim(txtb_Referencia.Text)

                                        If CBox_Motivo.Text = "Anula Documento de Referencia" Then
                                            Motivo = Trim("01")
                                        ElseIf CBox_Motivo.Text = "Corrige Monto" Then
                                            Motivo = Trim("03")
                                        ElseIf CBox_Motivo.Text = "Otros" Then
                                            Motivo = Trim("99")
                                        End If

                                        Enc_dr("Motivo") = Motivo
                                        IdRuta = tbhath2.Item(CBox_Rutas.Text).ToString
                                        Ruta = CBox_Rutas.Text
                                        Enc_dr("IdRuta") = IdRuta
                                        Enc_dr("Ruta") = Ruta
                                        Enc_dr("Comentario") = TXTB_Comentario.Text

                                        EncabezadoOrdenCompra.Rows.Add(Enc_dr)
                                        EncabezadoOrdenCompra.AcceptChanges()
                                        encabezado = True

                                        CodChofer = txtb_CodChofer.Text
                                        NombreChofer = txtb_NombreCofer.Text
                                        CodCliente = txtb_CodCliente.Text
                                        NombreCliente = txtb_Nombre.Text
                                        Credito = ""
                                        NumFactura = txtb_Referencia.Text
                                        DocEntry = txtb_DocEntry.Text
                                        Motivo = CBox_Motivo.Text
                                        IdRuta = txtb_IdRuta.Text
                                        Ruta = txtb_Ruta.Text
                                        Mont_Imp = txtb_Impuesto.Text
                                        Sub_Total = txtb_SubTotal.Text
                                        Mont_Desc = txtb_Desc.Text
                                        Total = txtb_Total.Text
                                        Procesada = "1"
                                        NumMarchamo = TXTB_Comentario.Text.Substring(4, TXTB_Comentario.Text.Length - 4)
                                        DocNum = txtb_DocNum.Text

                                        Comentario = TXTB_Comentario.Text
                                        Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaNota(Class_VariablesGlobales.SQL_Comman2, CodChofer, NombreChofer, CodCliente, NombreCliente, Credito, NumFactura, DocEntry, Motivo, IdRuta, Ruta, CDbl(Mont_Imp), CDbl(Sub_Total), CDbl(Mont_Desc), CDbl(Total), Procesada, NumMarchamo, DocNum, Comentario)
                                    End If


                                    Dim Det_dr As DataRow = DetalleOrdenCompra.NewRow

                                    DocNum = txtb_DocNum.Text
                                    ItemCode = row.Cells(1).Value
                                    Porc_DescAnt = row.Cells(11).Value
                                    Precio = row.Cells(3).Value
                                    Quantity = row.Cells(4).Value
                                    Porc_Desc = row.Cells(5).Value
                                    If row.Cells(16).Value Is Nothing Then
                                        MsgBox("Debe indicar el motivo de la linea " & ItemCode)

                                        MotivoLinea = ""
                                        Exit Sub
                                    Else
                                        MotivoLinea = row.Cells(16).Value.ToString.Substring(0, 3)
                                    End If

                                    Porc_Desc_Fijo = row.Cells(6).Value
                                    Porc_Desc_Promo = row.Cells(7).Value
                                    Bodega = row.Cells(9).Value
                                    Mont_Imp = CDbl(row.Cells(12).Value)
                                    Sub_Total = CDbl(row.Cells(13).Value)
                                    Mont_Desc = CDbl(row.Cells(14).Value)
                                    Total = CDbl(row.Cells(8).Value)

                                    'Det_dr("DocNum") = Val(row.Cells(17).Value)
                                    Det_dr("ItemCode") = ItemCode
                                    Det_dr("Quantity") = Quantity
                                    Det_dr("Bodega") = Bodega
                                    Det_dr("Currency") = "COL"
                                    Det_dr("DiscountPercent") = Porc_Desc
                                    Det_dr("U_DescFijo") = Porc_Desc_Fijo
                                    Det_dr("U_DescProm") = Porc_Desc_Promo
                                    Det_dr("Precio") = Precio
                                    'VERIFICAR QUE CARGUE EL MOTIVO
                                    Det_dr("Motivo") = MotivoLinea
                                    If MotivoLinea = "" Then
                                        SinMoivo = True
                                    End If
                                    DetalleOrdenCompra.Rows.Add(Det_dr)
                                    DetalleOrdenCompra.AcceptChanges()

                                    Procesada = "1"

                                    Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaDetalleNota(Class_VariablesGlobales.SQL_Comman2, txtb_DocNum.Text, ItemCode, Quantity, Porc_DescAnt, Porc_Desc, Porc_Desc_Fijo, Porc_Desc_Promo, CDbl(Total), Bodega, MotivoLinea, CDbl(Precio), CDbl(Mont_Imp), CDbl(Sub_Total), CDbl(Mont_Desc), Procesada)

                                End If



                            End If
                        Catch ex As Exception
                            MsgBox("ERROR al leer lineas " & ex.Message)
                        End Try


                    Next

                    'A


                    Dim err As String
                    'obj_SAP.CreaNotaCreditoLigada(txtb_DocNum.Text, txtb_CodChofer.Text, EncabezadoOrdenCompra, DetalleOrdenCompra, VariablesGlobales.oCompany, Class_VariablesGlobales.SQL_Comman1)
                    'Dim err As String = obj_SAP.CreaNotaCreditoDesLigada(txtb_DocNum.Text, txtb_CodChofer.Text, EncabezadoOrdenCompra, DetalleOrdenCompra, VariablesGlobales.oCompany, Class_VariablesGlobales.SQL_Comman1)
                    If Trim(err) = "" Then
                        'Imprimir()

                        Dtg_Devoluciones.DataSource = New DataTable
                        txtb_DocNum.Text = ""
                        txtb_CodCliente.Text = ""
                        txtb_Nombre.Text = "1"
                        txtb_CodChofer.Text = ""
                        txtb_NombreCofer.Text = "1.0"
                        txb_hora.Text = "0"
                        txtb_Referencia.Text = "0"

                        CBox_Motivo.Text = ""
                        txtb_IdRuta.Text = ""
                        txtb_Ruta.Text = ""
                        txtb_SubTotal.Text = ""
                        txtb_Desc.Text = ""
                        txtb_Impuesto.Text = ""
                        txtb_Total.Text = ""
                        TXTB_Comentario.Text = ""
                        MsgBox(" Nota de credito guardado con exito en SAP")
                    Else
                        MsgBox(err)

                    End If
                Else
                    'NO
                End If


                Class_VariablesGlobales.Obj_Funciones_SQL.ProcesaDevolucion(txtb_DocNum.Text, Class_VariablesGlobales.SQL_Comman1)




            End If
        Catch ex As Exception
            MsgBox(" ERROR EN btn_CrearSap_Click " & ex.Message)
        End Try
    End Sub

    Public Function Imprimir()
        Class_VariablesGlobales.Devolucion_DocNum = Trim(txtb_DocNum.Text)

        Class_VariablesGlobales.IMPRIMIENDO = "DEVOLUCION"
        frmReporte.Show()
    End Function

    Private Sub Dtg_Devoluciones_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Dtg_Devoluciones.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            Dim Mi_Test As DataGridView.HitTestInfo = Me.Dtg_Devoluciones.HitTest(e.X, e.Y)
            If Mi_Test.Type = DataGridViewHitTestType.Cell Then
                If Mi_Test.RowIndex >= 0 Then
                    indice = Mi_Test.RowIndex
                    Me.Dtg_Devoluciones.CurrentCell = Me.Dtg_Devoluciones.Rows(Mi_Test.RowIndex).Cells(Mi_Test.ColumnIndex)
                    Me.Dtg_Devoluciones.Rows(Mi_Test.RowIndex).Selected = True
                    menu = New ContextMenuStrip()

                    menu.Items.Add("Agregar", Nothing, New EventHandler(AddressOf AgregarFila))
                    menu.Items.Add("Eliminar", Nothing, New EventHandler(AddressOf EliminarFila))
                    Me.Dtg_Devoluciones.ContextMenuStrip = menu
                End If
            End If
        End If
    End Sub
    Private Sub EliminarFila()
        Try
            'Elimina la linea de la base de datos
            Class_VariablesGlobales.Obj_Funciones_SQL.DeleteLineaDevolucion(Class_VariablesGlobales.SQL_Comman2, Class_VariablesGlobales.frmDevoluciones.txtb_DocNum.Text.Trim, indice)

            Me.Dtg_Devoluciones.Rows.RemoveAt(indice)
            CalculaTotal()
        Catch ex As Exception

        End Try


    End Sub
    Private Sub AgregarFila()


        Class_VariablesGlobales.frmArticulos = New Articulos
        Class_VariablesGlobales.frmArticulos.Busca = "Interno"
        Class_VariablesGlobales.ArticulosLlamadoDesde = "Devoluciones"
        Class_VariablesGlobales.frmArticulos.MdiParent = Principal
        Class_VariablesGlobales.frmArticulos.Show()
    End Sub

    Private Sub TextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Then
            MessageBox.Show(Convert.ToString(Dtg_Devoluciones.SelectedRows(0).Cells(0).Value))    '''''DOES NOT WORK
            e.SuppressKeyPress = True
        End If
        If e.KeyCode = Keys.Space Then
            e.SuppressKeyPress = True
            MessageBox.Show(Convert.ToString(Dtg_Devoluciones.SelectedRows(0).Cells(0).Value))    '''''DOES NOT WORK
        End If

    End Sub

    Private Sub btn_Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Buscar.Click
        Class_VariablesGlobales.frmDevolucionesPendientes = New Devoluciones_Pendientes
        Class_VariablesGlobales.frmDevolucionesPendientes.MdiParent = Principal
        Class_VariablesGlobales.frmDevolucionesPendientes.Show()
        Me.Close()
    End Sub

    Private Sub Dtg_Devoluciones_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dtg_Devoluciones.CellEndEdit

        CalculaTotalLinea(Dtg_Devoluciones.CurrentRow.Index)

        CalculaTotal()

    End Sub
    Public Function CalculaTotalLinea(ByVal IdFinal As Integer)
        Dim Total As Double
        Dim DescTotal As Double
        Dim MontoDescTotal As Double
        Dim Subtotal As Double
        Dim Imptotal As Double
        Dim Mont_Imp As Double
        'DescFijo + DescPromo
        DescTotal = CDbl(Dtg_Devoluciones.Rows(IdFinal).Cells(6).Value) + CDbl(Dtg_Devoluciones.Rows(IdFinal).Cells(7).Value)

        Subtotal = CDbl(Me.Dtg_Devoluciones.Item("Cant", IdFinal).Value()) * CDbl(Me.Dtg_Devoluciones.Item("Precio", IdFinal).Value())

        'Si el descuento es 100 indica que se esta bonificando la linea por lo que solo se cobrara el impuesto segun hacienda
        'y para cuadra los calculo se debe dejar en 0 el descuento
        If DescTotal = 100 Then
            MontoDescTotal = 0
        Else
            MontoDescTotal = (Subtotal * DescTotal) / 100
        End If

        Subtotal = Subtotal - MontoDescTotal

        Dim PorcentajeImpuesto As Double = 0

        If Me.Dtg_Devoluciones.Item("IV", IdFinal).Value() <> "" Then
            PorcentajeImpuesto = CDbl(Me.Dtg_Devoluciones.Item("IV", IdFinal).Value())
            Mont_Imp = (Subtotal * PorcentajeImpuesto) / 100
        Else
            PorcentajeImpuesto = 0
            Mont_Imp = 0
        End If



        'Si el descuento es 100 indica que se esta bonificando la linea por lo que se debe cobrar solo el impuesto segun hacienda
        If DescTotal = 100 Then
            Total = Mont_Imp
        Else
            Total = Subtotal + Mont_Imp
        End If

        'Subtotal
        Dtg_Devoluciones.Rows(IdFinal).Cells(13).Value = Subtotal

        'Mont_Imp
        Dtg_Devoluciones.Rows(IdFinal).Cells(12).Value = Mont_Imp

        'MontoDescTotal
        Dtg_Devoluciones.Rows(IdFinal).Cells(14).Value = MontoDescTotal

        '%Descuento
        Dtg_Devoluciones.Rows(IdFinal).Cells(5).Value = DescTotal

        'Total
        Dtg_Devoluciones.Rows(IdFinal).Cells(8).Value = Total

    End Function

    Private Sub Btn_Atras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Atras.Click


        Try
            Navegar(CInt(txtb_DocNum.Text) - 1)
        Catch ex As Exception
            MsgBox("Se genero un error [ " & ex.Message & " ]")

        End Try


    End Sub

    Private Sub Btn_Adelante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Adelante.Click


        Try
            Navegar(CInt(txtb_DocNum.Text) + 1)
        Catch ex As Exception
            MsgBox("Se genero un error [ " & ex.Message & " ]")

        End Try

    End Sub

    Public Function Navegar(ByVal DocNum As Integer)
        Try
            Cargar(DocNum, "")
        Catch ex As Exception
            MsgBox("Se genero un error [ " & ex.Message & " ]")

        End Try

    End Function

    Private Sub btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Guardar.Click
        'Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaConsecutivoDevoluciones(Class_VariablesGlobales.SQL_Comman2, CInt(txtb_DocNum.Text) + 1)
        'debe actualizar la informacion de la nota y agregar las lineas que se deeen
        'DEBE SOLO MODIFICAR LAS LINEAS DE LA DEVOLUCION 
        Dim Pregunta As Integer
        Pregunta = MsgBox("Guardara preliminar de la nota pero no se aplicara a SAP \n ¿Realmente desea Anular la Nota de credito?.", vbYesNo + vbExclamation + vbDefaultButton2, "ANULAR NOTA DE CREDITO")

        If Pregunta = vbYes Then

            Dim Codigo As String
        Dim Quantity As String
        Dim Desc As String
        Dim Fijo As String
        Dim Promo As String
        Dim Total As String
        Dim Bodega As String
        Dim Motivo As String = CBox_Motivo.Text
        Dim IdRuta As String = tbhath2(CBox_Rutas.Text)
        Dim Ruta As String = CBox_Rutas.Text

        Dim Porc_DescAnt As String = ""
        Dim Precio As String = ""
        Dim Mont_Imp As String = ""
        Dim Subtotal As Double
        Dim Mont_Desc As String = ""
        Dim Procesada As String = ""

        For Row As Integer = 0 To Dtg_Devoluciones.RowCount - 1
            Codigo = Me.Dtg_Devoluciones.Item("Codigo", Row).Value
                Quantity = Me.Dtg_Devoluciones.Item("Cant", Row).Value
                Desc = Me.Dtg_Devoluciones.Item("%Desc", Row).Value
            Fijo = Me.Dtg_Devoluciones.Item("%Fijo", Row).Value
            Promo = Me.Dtg_Devoluciones.Item("%Promo", Row).Value
            Total = CDbl(Me.Dtg_Devoluciones.Item("Total", Row).Value)
            Bodega = Me.Dtg_Devoluciones.Item("Bodega", Row).Value
            Porc_DescAnt = Me.Dtg_Devoluciones.Item("Porc_DescAnt", Row).Value
            Precio = Me.Dtg_Devoluciones.Item("Porc_DescAnt", Row).Value
            Mont_Imp = CDbl(Me.Dtg_Devoluciones.Item("Mont_Imp", Row).Value)
            Subtotal = CDbl(Me.Dtg_Devoluciones.Item("Sub_Total", Row).Value)
            Mont_Desc = CDbl(Me.Dtg_Devoluciones.Item("Mont_Desc", Row).Value)

            Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaDetalleNota(Class_VariablesGlobales.SQL_Comman2, txtb_DocNum.Text, Codigo, Quantity, Porc_DescAnt, Desc, Fijo, Promo, Total, Bodega, Motivo, Precio, Mont_Imp, Subtotal, Mont_Desc, Procesada)
        Next

        Codigo = Nothing
        Quantity = Nothing
        Desc = Nothing
        Fijo = Nothing
        Promo = Nothing
        Total = Nothing
        Bodega = Nothing
        Motivo = Nothing
        IdRuta = Nothing
        Ruta = Nothing

        Porc_DescAnt = Nothing
        Precio = Nothing
        Mont_Imp = Nothing
        Subtotal = Nothing
        Mont_Desc = Nothing
            Procesada = Nothing

        Else
            'NO
        End If
    End Sub

    Private Sub btn_Anular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Anular.Click
        Dim Pregunta As Integer
        Pregunta = MsgBox("si anula la nota de credito no podra procesarla en el futuro \n ¿Realmente desea Anular la Nota de credito?.", vbYesNo + vbExclamation + vbDefaultButton2, "ANULAR NOTA DE CREDITO")

        If Pregunta = vbYes Then
            Class_VariablesGlobales.Obj_Funciones_SQL.ProcesaDevolucion(txtb_DocNum.Text.Trim(), Class_VariablesGlobales.SQL_Comman2)
        Else
            'NO
        End If
    End Sub

    Private Sub txtb_Referencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtb_Referencia.KeyPress


    End Sub

    Private Sub txtb_Referencia_TextChanged(sender As Object, e As EventArgs) Handles txtb_Referencia.TextChanged
        Try
            txtb_DocEntry.Text = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneDocEntry(Class_VariablesGlobales.SQL_Comman2, txtb_Referencia.Text, txtb_CodCliente.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CBox_Rutas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBox_Rutas.SelectedIndexChanged
        txtb_IdRuta.Text = tbhath2(CBox_Rutas.Text)
        txtb_Ruta.Text = CBox_Rutas.Text
    End Sub
End Class




