Imports System.ComponentModel
Imports CrystalDecisions.Shared
Imports SAPbobsCOM
'Imports Outlook = Microsoft.Office.Interop.Outlook

Public Class Pedido_Principal
    'Public oCompany As New SAPbobsCOM.Company
    'Public obj_SAP As New SAP_BUSSINES_ONE
    Public obj_Exportar As New ExportarAExcell
    Public Obj_OutLook As New Class_CorreoMicrosoft
    Public FIniOrdCompra As String
    Public FFINOrdCompra As String
    Public FFIN_ProyeccionIni As String
    Public FFIN_ProyeccionFin As String

    'Public Edita_Pd_Unid As Integer
    'Public Edita_ItemCode As Integer
    'Public Edita_Pack As Integer
    'Public Edita_Costo As Integer
    'Public Edita_Pd_Cjs As Integer
    'Public Edita_Pd_Total As Integer


    Public BeginEdita_Pd_Unid As Integer = 0
    Public BeginEdita_ItemCode As String = 0
    Public BeginEdita_Pack As Integer = 0
    Public BeginEdita_Costo As Double = 0
    Public BeginEdita_Pd_Cjs As Double = 0
    Public BeginEdita_Pd_Total As Double = 0

    Public EndEdita_Pd_Unid As Integer = 0
    Public EndEdita_ItemCode As String = 0
    Public EndEdita_Pack As Integer = 0
    Public EndEdita_Costo As Double = 0
    Public EndEdita_Pd_Cjs As Double = 0
    Public EndEdita_Pd_Total As Double = 0
    Private Sub btn_BuscaAgente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaAgente.Click
        Class_VariablesGlobales.LlamadoDesde = "PedidorPrincipal"
        Lista_Proveedores.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Pregunta As Integer

        Pregunta = MsgBox("¿Realmente desea actualizar los maximos y minimos de este proveedor?.", vbYesNo + vbExclamation + vbDefaultButton2, "SUBIR DEPOSITOS")

        If Pregunta = vbYes Then
            'HACE UNA CONSULTA DE LO VENDIDO EN LOS ULTIMOS 6 MESES SEGUN EL RESPALDO DE LOS PEDIDOS ENVIADOS POR LOS AGENTES
            '
        Else

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CrearEnSAP.Click
        Try
            'oCompany = obj_SAP.ConectarSap()
            Dim Pregunta As Integer
            'verifica si existe el pedido
            If CInt(Class_VariablesGlobales.Obj_Funciones_SQL.ExisteOrdenCompra(lbl_NumOrden.Text, Class_VariablesGlobales.SQL_Comman1)) = 0 Then
                Pregunta = MsgBox("Debe Guardar antes de crear el pedido en SAP ¿Desea Guardar?.", vbYesNo + vbExclamation + vbDefaultButton2, "GUARDAR REPORTE")
                If Pregunta = vbYes Then
                    GuardaOrdenCompra()
                End If
            Else
                'If txtb_Email.Text <> "" Then
                Pregunta = MsgBox("¿Realmente desea Crear la orden de compra de este proveedor?.", vbYesNo + vbExclamation + vbDefaultButton2, "CREAR PEDIDO")
                If Pregunta = vbYes Then

                    DTG_DetPedido.Sort(DTG_DetPedido.Columns(6), ListSortDirection.Ascending)

                    'TABLA ENCABEZADO DE PEDIDO
                    Dim EncabezadoOrdenCompra As New DataTable
                    EncabezadoOrdenCompra.Columns.Add("DocNum")
                    EncabezadoOrdenCompra.Columns.Add("CardCode")
                    EncabezadoOrdenCompra.Columns.Add("Date")
                    EncabezadoOrdenCompra.Columns.Add("Hora")
                    EncabezadoOrdenCompra.Columns.Add("CondicionPago")
                    EncabezadoOrdenCompra.Columns.Add("SalesPersonCode")

                    'TABLA DETALLE PEDIDO
                    Dim DetalleOrdenCompra As New DataTable
                    'DetalleOrdenCompra.Columns.Add("DocNum")
                    DetalleOrdenCompra.Columns.Add("ItemCode")
                    DetalleOrdenCompra.Columns.Add("Quantity")
                    DetalleOrdenCompra.Columns.Add("Currency")
                    DetalleOrdenCompra.Columns.Add("DiscountPercent")

                    For Each row As DataGridViewRow In DTG_DetPedido.Rows
                        Try
                            'solo carga las lineas con cantidad solicitada
                            If CInt(row.Cells(21).Value) <> 0 And CInt(row.Cells(21).Value) > 0 Then

                                Dim Enc_dr As DataRow = EncabezadoOrdenCompra.NewRow
                                Enc_dr("DocNum") = lbl_NumOrden.Text
                                Enc_dr("CardCode") = txtb_CodProveedor.Text
                                Enc_dr("Date") = Now.Date
                                Enc_dr("Hora") = TimeOfDay
                                Enc_dr("CondicionPago") = txtb_CondiconPago.Text
                                Enc_dr("SalesPersonCode") = "01"
                                EncabezadoOrdenCompra.Rows.Add(Enc_dr)
                                EncabezadoOrdenCompra.AcceptChanges()


                                Dim Det_dr As DataRow = DetalleOrdenCompra.NewRow
                                'Det_dr("DocNum") = Val(row.Cells(17).Value)
                                Det_dr("ItemCode") = row.Cells(6).Value

                                Det_dr("Quantity") = row.Cells(21).Value



                                Det_dr("Currency") = "COL"
                                Det_dr("DiscountPercent") = ""
                                DetalleOrdenCompra.Rows.Add(Det_dr)
                                DetalleOrdenCompra.AcceptChanges()

                            End If
                        Catch ex As Exception

                        End Try


                    Next



                    ''*****!!!!!!! CODIGO TEMPORAL PARA PRUEBAS SE DEBE BORRAR
                    ''Verifica si el pedido es de reckitt hace la obtension de los datos de SAP del pedido creado 
                    'If Trim(txtb_CodProveedor.Text) = "P094" Or Trim(txtb_CodProveedor.Text) = "P096" Then
                    '    Dim TblPedidReckitt As New DataTable
                    '    TblPedidReckitt = Class_VariablesGlobales.Obj_Funciones_SQL.ObtienePedidoReckitt(Class_VariablesGlobales.SQL_Comman1, "70335")
                    '    Class_VariablesGlobales.Obj_Funciones_SQL.InsertaPedidoReckitt(Class_VariablesGlobales.SQL_Comman1, TblPedidReckitt)
                    'End If



                    'If obj_SAP.AddOrderClient("01", EncabezadoOrdenCompra, DetalleOrdenCompra, oCompany, Class_VariablesGlobales.SQL_Comman1) = 0 Then
                    'si se crea el pedido en SAP actualiza la bandera 
                    Class_VariablesGlobales.Obj_Funciones_SQL.PedidoCreadoEnSAP(Class_VariablesGlobales.SQL_Comman1, lbl_NumOrden.Text)

                        'Verifica si el pedido es de reckitt hace la obtension de los datos de SAP del pedido creado 
                        If Trim(txtb_CodProveedor.Text) = "P094" Or Trim(txtb_CodProveedor.Text) = "P096" Then
                            Dim TblPedidReckitt As New DataTable
                            TblPedidReckitt = Class_VariablesGlobales.Obj_Funciones_SQL.ObtienePedidoReckitt(Class_VariablesGlobales.SQL_Comman1, lbl_NumOrden.Text)
                            Class_VariablesGlobales.Obj_Funciones_SQL.InsertaPedidoReckitt(Class_VariablesGlobales.SQL_Comman1, TblPedidReckitt)
                        End If


                        Dim ruta As String = Class_VariablesGlobales.RutaExcellPedidos & txtb_NombreProveedor.Text.Trim.Replace(" ", "_") & "\" & lbl_NumOrden.Text & "_Fecha_" & Now.Day & "_" & Now.Month & "_" & Now.Year
                        Dim destinatario As String = txtb_NombreProveedor.Text.Trim.Replace(" ", "_")

                        obj_Exportar.ExportarDatosExcel2(obj_Exportar.LimpiaPedido(DTG_DetPedido), txtb_NombreProveedor.Text.Trim.Replace(" ", "_"))
                        CheckForIllegalCrossThreadCalls = False


                        ImprimirPedidoProveedor(ruta)

                        'obj_Exportar.ExportToPDF(Class_VariablesGlobales.ReportePedidoProveedor, lbl_NumOrden.Text, Class_VariablesGlobales.RutaExcellPedidos & txtb_NombreProveedor.Text)


                        Dim mensaje As String = "Muy buenas señor@s de " & destinatario & " , adjunto pedido <br><br>"

                        'Class_VariablesGlobales.Obj_MAIL.EnviarCorreo(mensaje, "PEDIDO BOURNE Y CIA", "M:\IMPORTACION\ORDENESDECOMPRA\Pedido_" & Now.Day & "_" & Now.Month & "_" & Now.Year & ".xls", txtb_Email.Text, txtb_Email2.Text, txtb_Email3.Text, txtb_Email4.Text)
                        ' Class_VariablesGlobales.Obj_MAIL.EnviarMail_Demo("PEDIDO", "PEDIDO BOURNE Y CIA", Class_VariablesGlobales.RutaExcellPedidos & txtb_NombreProveedor.Text & "\" & lbl_NumOrden.Text & "_Fecha_" & Now.Day & "_" & Now.Month & "_" & Now.Year & ".xls", Class_VariablesGlobales.RutaExcellPedidos & txtb_NombreProveedor.Text & "\" & lbl_NumOrden.Text & "_Fecha_" & Now.Day & "_" & Now.Month & "_" & Now.Year & ".pdf", txtb_Email.Text)
                        Class_VariablesGlobales.Obj_MAIL.AttachFilesbyEmailAutomatically(mensaje, "PEDIDO " & destinatario, ruta & ".xlsx", ruta & ".pdf", destinatario)



                        MsgBox("Pedido creado con exito")
                        Class_VariablesGlobales.IMPRIMIENDO = "OrdenDeCompra"
                        DTG_DetPedido.DataSource = New DataTable
                        txtb_CodProveedor.Text = ""
                        txtb_CondiconPago.Text = ""
                        txtb_DiasProxCamion.Text = "1"
                        txtb_NombreProveedor.Text = ""
                        txtb_PorcRespaldo.Text = "1.0"
                        lbl_Inventario.Text = "0"
                        lbl_Total.Text = "0"
                        txtb_Email.Text = ""




                        'Else
                        '    MsgBox("Por problemas de conexión con SAP el pedido no se ha podido crear, pruebe las siguientes soluciones: " & vbCrLf _
                        '           & "- Cierre y vuelva a abrir el sistema " & vbCrLf _
                        '           & "- Verifique que las conexiones a SAP no estén saturadas " & vbCrLf _
                        '           & "- Verifique que tenga conexión a la red" & vbCrLf _
                        '           & "- Verifique que el servidor de SAP este encendido y conectado a la red")
                        'End If
                    Else

                End If



                'Else
                '    MsgBox("Debe indicar almenos un destinatario")
                '    txtb_Email.Focus()
                'End If


            End If
        Catch ex As Exception
            MsgBox("Error al crear pedido btn_CrearEnSAP " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cargar.Click
        Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.InbGeneraPedido(Class_VariablesGlobales.SQL_Comman1, txtb_CodProveedor.Text, ComboBox1.Text, txtb_DiasProxCamion.Text, txtb_PorcRespaldo.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.FIniOrdCompra), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.FFINOrdCompra), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.FFIN_ProyeccionIni), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.FFIN_ProyeccionFin))
        ' creamos el control comboBox
        Dim CtlTextBox As New DataGridViewTextBoxCell

        ' rellenamos los items del combobox


        'For i As Integer = 10 To 20
        '    ' le asignamos el control combobox a la celda
        '    DataGridView1.Item(18, i) = CtlTextBox.Clone
        'Next

        RegulaTamanoColumnas(Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido)
        Class_VariablesGlobales.frmCreaPedido.lbl_Total.Text = TotalPedido(Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido)



    End Sub

    Private Function ValorIntermedio(ByVal a As Long, ByVal b As Long, ByVal c As Long) As Long
        Dim i As Integer, j As Integer
        Dim Ordenado(3) As Long 'le dos 1 más para que sirva como temporal
        'asiganamos los valores dador
        Ordenado(0) = a
        Ordenado(1) = b
        Ordenado(2) = c

        'Hacemos el Algoritmo de Ordenamiento Burbuja
        For i = 0 To 2
            For j = i + 1 To 2
                If Ordenado(i) > Ordenado(j) Then
                    Ordenado(3) = Ordenado(j)
                    Ordenado(j) = Ordenado(i)
                    Ordenado(i) = Ordenado(3)
                End If
            Next
        Next
        'Devolvemos el valor intermedio, en este caso el Index 1
        ValorIntermedio = Ordenado(1)
    End Function

    Private Sub Crear_Pedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load




        'Dim Obj_OutLook As New Class_CorreoMicrosoft
        'Obj_OutLook.AccessContacts("Ruta")

        'conecta  a SAP
        Dim Obj_VarGlobal As New Class_VariablesGlobales
            Class_VariablesGlobales.MYSQ_Comman.Connection = Obj_VarGlobal.Obj_CX_MYSQL.Conectar()

            nuevo()
            btn_anular.Enabled = False
            Btn_Adelante.Enabled = False
            Btn_Atras.Enabled = False
            btn_exportar.Enabled = False
            btn_Guardar.Enabled = False
            btn_Cargar.Enabled = False
            btn_Buscar.Enabled = True
        'Obj_OutLook.Lista()
        'Obj_OutLook.AccessContacts("Alimax")


        'obj_Exportar.LeerExcell("M:\IMPORTACION\ORDENESDECOMPRA\Pedido_16_4_2018.xls")

    End Sub

    'Private Sub ShowContactsFolderAsInitialAddressList()
    '    Dim addrLists As Outlook.AddressLists
    '    Dim contactsFolder As Outlook.Folder = _
    '        CType(Application.Session.GetDefaultFolder( _
    '        Outlook.OlDefaultFolders.olFolderContacts),  _
    '        Outlook.Folder)
    '    addrLists = Application.Session.AddressLists
    '    For Each addrList As Outlook.AddressList In addrLists
    '        Dim testFolder As Outlook.Folder = _
    '        CType(addrList.GetContactsFolder(), Outlook.Folder)
    '        If Not (testFolder Is Nothing) Then
    '            ' Test to determine if Folder returned
    '            ' by GetContactsFolder has same EntryID
    '            ' as default Contacts folder.
    '            If (Application.Session.CompareEntryIDs( _
    '                contactsFolder.EntryID, testFolder.EntryID)) Then
    '                Dim snd As Outlook.SelectNamesDialog = _
    '                    Application.Session.GetSelectNamesDialog()
    '                snd.InitialAddressList = addrList
    '                snd.Display()
    '            End If
    '        End If
    '    Next
    'End Sub

    'Private Sub ThisAddIn_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.txtb_Email
    '    AccessContacts("Na")
    'End Sub

    'Private Sub AccessContacts(ByVal findLastName As String)



    '    Dim folderContacts As Outlook.MAPIFolder = Me.Application.ActiveExplorer() _
    '        .Session.GetDefaultFolder(Outlook.OlDefaultFolders _
    '        .olFolderContacts)

    '    Dim searchFolder As Items = folderContacts.Items
    '    Dim counter As Integer = 0

    '    For Each foundContact As Outlook.ContactItem In searchFolder
    '        If foundContact.LastName.Contains(findLastName) Then
    '            foundContact.Display(False)
    '            counter = counter + 1
    '        End If
    '    Next
    '    MsgBox("You have " & counter & _
    '        " contacts with last names that contain " _
    '        & findLastName & ".")
    'End Sub


    Public Function Recalcula(ByVal Primerves As Boolean)

        Dim unidades As Integer
        Dim Emp As Integer
        Dim fil As Integer = 0
        For Each row As DataGridViewRow In DTG_DetPedido.Rows
            Try


                unidades = row.Cells(22).Value() 'unidades


                If row.Cells(2).Value() <> 0 Then
                    Emp = row.Cells(2).Value() 'empaque
                Else
                    Emp = 1
                End If



                If RdBtb_Cajas.Checked = True Then

                    ' TotalNuevo = (CInt(txt_Cantidad.Text) * CInt(txt_Emp.Text)) * CDbl(txt_Precio.Text)

                    DTG_DetPedido.Rows(fil).Cells(22).Value = unidades 'cajas
                    DTG_DetPedido.Rows(fil).Cells(21).Value = CInt(unidades) * CInt(Emp) 'unidaes
                    '  Class_VariablesGlobales.frmCreaPedido.DataGridView1.Rows(Fila).Cells(23).Value = FormatCurrency(TotalNuevo, 2)   'total

                Else
                    If Primerves = True Then
                        'TotalNuevo = CInt(txt_Cantidad.Text) * CDbl(txt_Precio.Text)
                        DTG_DetPedido.Rows(fil).Cells(22).Value = Math.Round((CDbl(CInt(unidades) / CInt(Emp)) / CInt(Emp)), 2) 'cajas
                        DTG_DetPedido.Rows(fil).Cells(21).Value = Math.Round(CDbl(CInt(unidades)), 2)  'unidaes 
                        'Class_VariablesGlobales.frmCreaPedido.DataGridView1.Rows(Fila).Cells(23).Value = FormatCurrency(TotalNuevo, 2)  'total

                    Else
                        'TotalNuevo = CInt(txt_Cantidad.Text) * CDbl(txt_Precio.Text)
                        DTG_DetPedido.Rows(fil).Cells(22).Value = Math.Round((CDbl(CInt(unidades) / CInt(Emp)) / CInt(Emp)), 2) 'cajas
                        DTG_DetPedido.Rows(fil).Cells(21).Value = Math.Round(CDbl(CInt(unidades) / CInt(Emp)), 2)  'unidaes 
                        'Class_VariablesGlobales.frmCreaPedido.DataGridView1.Rows(Fila).Cells(23).Value = FormatCurrency(TotalNuevo, 2)  'total

                    End If

                End If
                fil += 1

            Catch ex As Exception

            End Try
        Next
    End Function


    Public Function TotalPedido(ByVal dgv As DataGridView)
        Try
            Dim T_Venta As Double
            Dim Total As Double
            Dim InvetarioActual As Double
            '  Dim Col As Integer = dgv.CurrentCell.ColumnIndex
            For Each row As DataGridViewRow In dgv.Rows
                Try

                    '21 pedido

                    Total += CDbl(row.Cells(23).Value)

                    '7 venta
                    T_Venta += (CDbl(row.Cells(10).Value))
                    '14 stock
                    InvetarioActual += CDbl(row.Cells(17).Value)



                Catch ex As Exception

                End Try
            Next
            Class_VariablesGlobales.frmCreaPedido.lbl_Total.Text = FormatCurrency(Total.ToString, 2)
            Class_VariablesGlobales.frmCreaPedido.lbl_Inventario.Text = FormatCurrency(InvetarioActual.ToString, 2)
            Class_VariablesGlobales.frmCreaPedido.lbl_TVenta.Text = FormatCurrency(T_Venta, 2)


        Catch ex As Exception

        End Try
    End Function


    Public Function RegulaTamanoColumnas(ByVal dgv As DataGridView)
        Try
            'T0.[CardCode],
            'T0.[Alterno] ,
            'T0.[CodArticulo],
            'T0.[ItemName],
            'T0.[Costo], 
            'T0.[Pack],
            'T0.[Vta_Monto],
            'T0.[VtaUni],
            'T0.[VtaCjs],
            'T0.[PedAgts],
            'T0.[Faltante],
            'T0.[StockR],
            'T0.[StockRCjs],
            'T0.[StockR_Monto],
            'T0.[Dif],
            'T0.[Cpmtdo],
            'T0.[CpmtdoCjs],
            'isnull(T0.[Compra] ,0) as Compra,
            'T0.[PdUni],
            'T0.[PdCJs],
            'T0.[PdTotal],
            'isnull(T0.[Prmd_Compra],0) as Prmd_Compra,
            'isnull(T0.[PrmdVtaMs] ,0) as PrmdVtaMs ,
            'isnull(T0.[PrmdVtaDs] ,0) as PrmdVtaDs , 
            'T0.[Dias] 
            dgv.Columns(0).Visible = False  '[ID]
            dgv.Columns(1).Visible = False  '[NumDoc]
            dgv.Columns(2).Visible = False '[Fecha]
            dgv.Columns(3).Visible = False '[CardCode]
            dgv.Columns(4).Visible = False '[NombreProveedor]
            dgv.Columns(5).Visible = False '[Alterno]
            dgv.Columns(6).Width = 75 '[ItemCode] 
            dgv.Columns(6).ReadOnly = False
            dgv.Columns(7).Width = 350 '[ItemName]
            dgv.Columns(7).ReadOnly = True
            dgv.Columns(8).Visible = False '[Costo]
            dgv.Columns(8).ReadOnly = True
            dgv.Columns(9).Width = 40 '[Pack]
            dgv.Columns(9).ReadOnly = True

            dgv.Columns(10).Width = 90 '[Venta_Mont]
            Me.DTG_DetPedido.Columns(10).DefaultCellStyle.ForeColor = Color.Black
            Me.DTG_DetPedido.Columns(10).DefaultCellStyle.BackColor = Color.LemonChiffon
            dgv.Columns(10).DefaultCellStyle.Format = "c" 'Formato moneda
            dgv.Columns(10).ReadOnly = True

            dgv.Columns(11).Width = 70 '[Venta_Uni]
            Me.DTG_DetPedido.Columns(11).DefaultCellStyle.ForeColor = Color.Black
            Me.DTG_DetPedido.Columns(11).DefaultCellStyle.BackColor = Color.LemonChiffon
            dgv.Columns(11).ReadOnly = True

            dgv.Columns(12).Width = 70 '[Venta_Cjs]
            Me.DTG_DetPedido.Columns(12).DefaultCellStyle.ForeColor = Color.Black
            Me.DTG_DetPedido.Columns(12).DefaultCellStyle.BackColor = Color.LemonChiffon
            dgv.Columns(12).ReadOnly = True

            dgv.Columns(13).Width = 50 '[PedAgts] 
            Me.DTG_DetPedido.Columns(13).DefaultCellStyle.ForeColor = Color.Black
            Me.DTG_DetPedido.Columns(13).DefaultCellStyle.BackColor = Color.LemonChiffon
            dgv.Columns(13).ReadOnly = True



            dgv.Columns(14).Width = 60 '[Faltante] 
            Me.DTG_DetPedido.Columns(14).DefaultCellStyle.ForeColor = Color.Black
            Me.DTG_DetPedido.Columns(14).DefaultCellStyle.BackColor = Color.LightCoral
            dgv.Columns(14).ReadOnly = True

            dgv.Columns(15).Width = 50 '[StockR] 
            Me.DTG_DetPedido.Columns(15).DefaultCellStyle.ForeColor = Color.Black
            Me.DTG_DetPedido.Columns(15).DefaultCellStyle.BackColor = Color.Azure
            dgv.Columns(15).ReadOnly = True

            dgv.Columns(16).Width = 60 '[StockRCjs] 
            Me.DTG_DetPedido.Columns(16).DefaultCellStyle.ForeColor = Color.Black
            Me.DTG_DetPedido.Columns(16).DefaultCellStyle.BackColor = Color.Azure
            Me.DTG_DetPedido.Columns(16).DefaultCellStyle.Format = "N2" 'Formato numerico con 2 decimales
            dgv.Columns(16).ReadOnly = True

            dgv.Columns(17).Width = 95 '[StockR_Monto] 
            Me.DTG_DetPedido.Columns(17).DefaultCellStyle.ForeColor = Color.Black
            Me.DTG_DetPedido.Columns(17).DefaultCellStyle.BackColor = Color.Azure
            dgv.Columns(17).DefaultCellStyle.Format = "c" 'Formato moneda
            dgv.Columns(17).ReadOnly = True

            dgv.Columns(18).Visible = False '[Dif] 

            dgv.Columns(19).Width = 50 '[Cpmtdo] 
            Me.DTG_DetPedido.Columns(19).DefaultCellStyle.ForeColor = Color.Black
            Me.DTG_DetPedido.Columns(19).DefaultCellStyle.BackColor = Color.LemonChiffon
            dgv.Columns(19).ReadOnly = True

            dgv.Columns(20).Width = 60 '[CpmtdoCjs] 
            Me.DTG_DetPedido.Columns(20).DefaultCellStyle.ForeColor = Color.Black
            Me.DTG_DetPedido.Columns(20).DefaultCellStyle.BackColor = Color.LemonChiffon
            Me.DTG_DetPedido.Columns(20).DefaultCellStyle.Format = "N2" 'Formato numerico con 2 decimales
            dgv.Columns(20).ReadOnly = True

            dgv.Columns(21).Width = 60 '[Pd_Unid]
            Me.DTG_DetPedido.Columns(21).DefaultCellStyle.ForeColor = Color.Black
            Me.DTG_DetPedido.Columns(21).DefaultCellStyle.BackColor = Color.LightGreen
            Me.DTG_DetPedido.Columns(21).ReadOnly = False

            dgv.Columns(22).Width = 50 '[Pd_CJs]
            Me.DTG_DetPedido.Columns(22).DefaultCellStyle.ForeColor = Color.Black
            Me.DTG_DetPedido.Columns(22).DefaultCellStyle.BackColor = Color.LightGreen
            Me.DTG_DetPedido.Columns(22).DefaultCellStyle.Format = "N2" 'Formato numerico con 2 decimales
            Me.DTG_DetPedido.Columns(22).ReadOnly = False

            dgv.Columns(23).Width = 95 '[Pd_Total]
            Me.DTG_DetPedido.Columns(23).DefaultCellStyle.ForeColor = Color.Black
            Me.DTG_DetPedido.Columns(23).DefaultCellStyle.BackColor = Color.LightGreen
            dgv.Columns(23).DefaultCellStyle.Format = "c" 'Formato moneda
            dgv.Columns(23).ReadOnly = True

            dgv.Columns(24).Visible = False '[Prmd_Compra]
            dgv.Columns(25).Visible = False '[PrmdVtaDs]
            dgv.Columns(26).Visible = False '[Dias_Iv]
            dgv.Columns(27).Visible = False '[FIni_Venta]
            dgv.Columns(28).Visible = False '[FFin_Venta]
            dgv.Columns(29).Visible = False '[FIni_Cubrir]
            dgv.Columns(30).Visible = False '[FFin_Cubrir]
            dgv.Columns(31).Visible = False '[FFin_Cubrir]
            dgv.Columns(31).Width = 60 '[UltimaCompra]
            dgv.Columns(32).Visible = False '[CodeBars]
            dgv.Columns(33).Visible = False '[Gramaje]
            dgv.Columns(34).Visible = False '[DiasSinMoverse]

            dgv.Columns(35).Visible = False '[Vmp]
            dgv.Columns(36).Visible = False '[Vmatp]
            dgv.Columns(37).Visible = False '[Vmatatp]
            dgv.Columns(38).Visible = False '[MEs_Vmp]
            dgv.Columns(39).Visible = False '[MEs_Vmatp]
            dgv.Columns(40).Visible = False '[MEs_Vmatatp]
            dgv.Columns(41).Visible = False '[FechaUltimaCompra]
            dgv.Columns(42).Visible = False '[FechaUltimaVenta]
            dgv.Columns(43).Visible = False '[CantidadUltimaVenta]
            dgv.Columns(44).Visible = False '[Revizado]
            dgv.Columns(45).Visible = False '[FechaUltimoPedido]
            dgv.Columns(46).Visible = False '[CantidadUltimoPedido]
            'Class_VariablesGlobales.frmCreaPedido.Dias.Text = DateDiff(DateInterval.Day, CDate(dgv.Rows(0).Cells(28).Value()), CDate(dgv.Rows(0).Cells(28).Value()))

            'Busca ventas en negativo y pone la linea en rojo par alertar

            Dim VentasNegativoas As Boolean = False
            Dim Cont As Integer = 0
            For Each row As DataGridViewRow In Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows
                If (CInt(row.Cells(11).Value) < 0) Then


                    'Me.DTG_DetPedido.Columns(23).DefaultCellStyle.BackColor = Color.LightGreen
                    row.DefaultCellStyle.BackColor = Color.Red
                    row.DefaultCellStyle.ForeColor = Color.White
                    'Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows(Cont).DefaultCellStyle.BackColor = Color.Red
                    Cont += 1
                    VentasNegativoas = True
                End If

            Next
            If VentasNegativoas = True Then
                MsgBox("Se detectaron líneas  con venta negativa" & vbCrLf &
                       "revise las líneas  en rojo", MsgBoxStyle.Critical, "Ventas en negativo")

            End If

        Catch ex As Exception

        End Try



    End Function


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.InbGeneraPedido(Class_VariablesGlobales.SQL_Comman1, txtb_CodProveedor.Text, ComboBox1.Text, txtb_DiasProxCamion.Text, txtb_PorcRespaldo.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.FIniOrdCompra), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.FFINOrdCompra), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.FFIN_ProyeccionIni), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.FFIN_ProyeccionFin))
        RegulaTamanoColumnas(Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido)
        lbl_Total.Text = "0"
        lbl_Inventario.Text = "0"
        Class_VariablesGlobales.frmCreaPedido.lbl_Total.Text = TotalPedido(Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido)
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.InbGeneraPedido(Class_VariablesGlobales.SQL_Comman1, txtb_CodProveedor.Text, ComboBox1.Text, txtb_DiasProxCamion.Text, txtb_PorcRespaldo.Text, Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.FIniOrdCompra), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.FFINOrdCompra), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.FFIN_ProyeccionIni), Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Class_VariablesGlobales.frmCreaPedido.FFIN_ProyeccionFin))
        RegulaTamanoColumnas(Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido)
        lbl_Total.Text = "0"
        Class_VariablesGlobales.frmCreaPedido.lbl_Total.Text = TotalPedido(Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Guardar.Click
        GuardaOrdenCompra()
    End Sub

    Public Function GuardaOrdenCompra()

        Dim ID As String = ""
        Dim NumDoc As String = ""
        Dim CardCode As String = ""
        Dim CardName As String = ""
        Dim ItemCode As String = ""
        Dim ItemName As String = ""
        Dim Fecha As String = ""
        Dim Alterno As String = ""
        Dim Emp As String = ""
        Dim Precio_Costo As String = ""
        Dim Venta_Uni As String = ""
        Dim Venta_Cjs As String = ""
        Dim Venta_Mont As String = ""
        Dim Stock_Unid As String = ""
        Dim Stock_Cjs As String = ""
        Dim Stock_Mont As String = ""
        Dim Comprometido As String = ""
        Dim Dias_Iv As String = ""
        Dim Pd_CJs As String = ""
        Dim Pd_Unid As String = ""
        Dim Pd_Total As String = ""
        Dim FVIni As String = ""
        Dim FVFin As String = ""
        Dim FCIni As String = ""
        Dim FCFin As String = ""
        Dim UnidadDeMedidas As String = ""
        Dim CodBarras As String = ""
        Dim Gramaje As String = ""
        Dim UltimaCompra As String = ""
        Dim PedidoXAgente As String = ""
        Dim Faltante As String = ""
        Dim CpmtdoCjs As String = ""
        Dim FechaUltimaCompra As String = ""
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
        Dim Guardando As Boolean = False

        '[ID],[NumDoc],[Fecha],[CardCode],[NombreProveedor],[Alterno],[ItemCode],[ItemName],[Costo],[Pack],[Venta_Mont],
        '[Venta_Uni], [Venta_Cjs], [PedAgts], [Faltante], [StockR], [StockRCjs], [StockR_Monto], [Dif], [Cpmtdo], [CpmtdoCjs], 
        '[Pd_Unid], [Pd_CJs], [Pd_Total], [Prmd_Compra], [PrmdVtaDs], [Dias_Iv], [FIni_Venta], [FFin_Venta], [FIni_Cubrir], [FFin_Cubrir], 
        '[UltimaCompra], [CodeBars], [Gramaje], [DiasSinMoverse], Vmp, Vmatp, Vmatatp, Mes_Vmp, MEs_Vmatp, Mes_Vmatatp, FechaUltimaCompra
        'If btn_Guardar.Text = "ACTUALIZAR" Then
        Guardando = False
        'Else
        '    Guardando = True
        'End If


        'Dim Col As Integer = Class_VariablesGlobales.frmCreaPedido.DataGridView1.CurrentCell.ColumnIndex
        For Each row As DataGridViewRow In Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows
            Try

                If RdBtb_Cajas.Checked = True Then
                    UnidadDeMedidas = "CAJAS"
                Else
                    UnidadDeMedidas = "UNIDADES"
                End If
                ID = row.Cells(0).Value
                NumDoc = Class_VariablesGlobales.frmCreaPedido.lbl_NumOrden.Text
                CardCode = Class_VariablesGlobales.frmCreaPedido.txtb_CodProveedor.Text
                CardName = Class_VariablesGlobales.frmCreaPedido.txtb_NombreProveedor.Text
                ItemCode = row.Cells(6).Value
                ItemName = row.Cells(7).Value
                Fecha = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Now.Date)
                Alterno = row.Cells(5).Value
                Emp = row.Cells(9).Value
                Precio_Costo = row.Cells(8).Value
                Venta_Uni = row.Cells(11).Value
                Venta_Cjs = row.Cells(12).Value
                Venta_Mont = row.Cells(10).Value
                Stock_Unid = row.Cells(15).Value
                Stock_Cjs = row.Cells(16).Value
                Stock_Mont = row.Cells(17).Value
                Comprometido = row.Cells(15).Value
                Dias_Iv = row.Cells(26).Value
                Pd_CJs = row.Cells(22).Value
                Pd_Unid = row.Cells(21).Value
                Pd_Total = row.Cells(23).Value
                FVIni = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaInicio.Value.ToShortDateString)
                FVFin = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_FechaFin.Value.ToShortDateString)
                FCIni = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_ProyeccionIni.Value.ToShortDateString)
                FCFin = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_ProyeccionFin.Value.ToShortDateString)

                CodBarras = row.Cells(32).Value
                Gramaje = row.Cells(33).Value
                UltimaCompra = row.Cells(31).Value
                PedidoXAgente = row.Cells(13).Value
                Faltante = row.Cells(14).Value
                CpmtdoCjs = row.Cells(20).Value
                FechaUltimaCompra = row.Cells(41).Value

                Dif = row.Cells(18).Value
                Prmd_Compra = row.Cells(33).Value
                PrmdVtaDs = row.Cells(34).Value
                FIni_Cubrir = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_ProyeccionIni.Value.ToShortDateString)
                FFin_Cubrir = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(DTP_ProyeccionFin.Value.ToShortDateString)
                DiasSinMoverse = row.Cells(34).Value
                Vmp = row.Cells(35).Value
                Vmatp = row.Cells(36).Value
                Vmatatp = row.Cells(37).Value
                Mes_Vmp = row.Cells(38).Value
                MEs_Vmatp = row.Cells(39).Value
                Mes_Vmatatp = row.Cells(40).Value

                FechaUltimaVenta = row.Cells(42).Value
                If FechaUltimaVenta <> "" Then

                    FechaUltimaVenta = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(FechaUltimaVenta)
                End If
                CantidadUltimaVenta = row.Cells(43).Value
                FechaUltimoPedido = row.Cells(44).Value
                CantidadUltimoPedido = row.Cells(45).Value

                Pd_CJs_Cheado = ""
                Pd_Unid_Cheado = ""
                Pd_Total_Cheado = ""
                Motivo = ""
                FCFIn_Venta = ""

                Class_VariablesGlobales.Obj_Funciones_SQL.GuardaOrdenDeCompra(
                                 ID,
                                 NumDoc,
                                CardCode,
                                CardName,
                                ItemCode,
                                ItemName,
                                Fecha,
                                Alterno,
                                Emp,
                                Precio_Costo,
                                Venta_Uni,
                                Venta_Cjs,
                                Venta_Mont,
                                Stock_Unid,
                                Stock_Cjs,
                                Stock_Mont,
                                Comprometido,
                                Dias_Iv,
                                Pd_CJs,
                                Pd_Unid,
                                Pd_Total,
                                FVIni,
                                FVFin,
                                FCIni,
                                FCFin,
                                UnidadDeMedidas,
                                CodBarras,
                                Gramaje,
                                UltimaCompra,
                                PedidoXAgente,
                                Faltante,
                                CpmtdoCjs,
                                FechaUltimaCompra,
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
                                MEs_Vmatp,
                                Mes_Vmatatp,
                                Pd_CJs_Cheado,
                                Pd_Unid_Cheado,
                                Pd_Total_Cheado,
                                Motivo,
                                FCFIn_Venta,
                                FechaUltimaVenta,
                CantidadUltimaVenta,
                "0",
                 FechaUltimoPedido,
                CantidadUltimoPedido,
                Class_VariablesGlobales.SQL_Comman1, Guardando)

                ID = ""
                NumDoc = ""
                CardCode = ""
                CardName = ""
                ItemCode = ""
                ItemName = ""
                Fecha = ""
                Alterno = ""
                Emp = ""
                Precio_Costo = ""
                Venta_Uni = ""
                Venta_Cjs = ""
                Venta_Mont = ""
                Stock_Unid = ""
                Stock_Cjs = ""
                Stock_Mont = ""
                Comprometido = ""
                Dias_Iv = ""
                Pd_CJs = ""
                Pd_Unid = ""
                Pd_Total = ""
                FVIni = ""
                FVFin = ""
                FCIni = ""
                FCFin = ""
                UnidadDeMedidas = ""
                CodBarras = ""
                Gramaje = ""
                UltimaCompra = ""
                PedidoXAgente = ""
                Faltante = ""
                CpmtdoCjs = ""
                FechaUltimaCompra = ""
                Dif = ""
                Prmd_Compra = ""
                PrmdVtaDs = ""
                FIni_Cubrir = ""
                FFin_Cubrir = ""
                DiasSinMoverse = ""
                Vmp = ""
                Vmatp = ""
                Vmatatp = ""
                Mes_Vmp = ""
                Mes_Vmatatp = ""
                MEs_Vmatp = ""
                Pd_CJs_Cheado = ""
                Pd_Unid_Cheado = ""
                Pd_Total_Cheado = ""
                Motivo = ""
                FCFIn_Venta = ""
                FechaUltimaVenta = ""
                CantidadUltimaVenta = ""
                FechaUltimoPedido = ""
                CantidadUltimoPedido = ""

            Catch ex As Exception
                If Guardando = True Then
                    MsgBox("ERROR AL GUARDADA " & ex.Message)
                Else

                    MsgBox("ERROR AL ACTUALIZAR " & ex.Message)
                End If
            End Try

        Next
        'Tambien se debe actualiza la orden de compra en SAP
        'conecta  a SAP
        'oCompany = obj_SAP.ConectarSap()
        'If obj_SAP.ModificaPedidoAProveedor() = 0 Then

        'Else
        '    'error
        'End If
        If Guardando = True Then
            MsgBox("ORDEN DE COMPRA GUARDADA CORRECTAMENTE")
        Else

            MsgBox("ORDEN DE COMPRA ACTUALIZADA CORRECTAMENTE")
        End If


        ID = Nothing
        NumDoc = Nothing
        CardCode = Nothing
        CardName = Nothing
        ItemCode = Nothing
        ItemName = Nothing
        Fecha = Nothing
        Alterno = Nothing
        Emp = Nothing
        Precio_Costo = Nothing
        Venta_Uni = Nothing
        Venta_Cjs = Nothing
        Venta_Mont = Nothing
        Stock_Unid = Nothing
        Stock_Cjs = Nothing
        Stock_Mont = Nothing
        Comprometido = Nothing
        Dias_Iv = Nothing
        Pd_CJs = Nothing
        Pd_Unid = Nothing
        Pd_Total = Nothing
        FVIni = Nothing
        FVFin = Nothing
        FCIni = Nothing
        FCFin = Nothing
        UnidadDeMedidas = Nothing
        CodBarras = Nothing
        Gramaje = Nothing
        UltimaCompra = Nothing
        PedidoXAgente = Nothing
        Faltante = Nothing
        CpmtdoCjs = Nothing
        FechaUltimaCompra = Nothing
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
        btn_Guardar.Enabled = False

        FechaUltimoPedido = Nothing
        CantidadUltimoPedido = Nothing
        nuevo()
    End Function

    Private Sub btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Nuevo.Click
        nuevo()
    End Sub

    Public Function nuevo()
        DTG_DetPedido.DataSource = New DataTable
        txtb_CodProveedor.Text = ""
        txtb_CondiconPago.Text = ""
        lbl_Inventario.Text = "0"
        txtb_DiasProxCamion.Text = "1"
        txtb_NombreProveedor.Text = ""
        txtb_PorcRespaldo.Text = "1.0"
        txtb_Email.Text = ""
        btn_anular.Enabled = True
        Btn_Adelante.Enabled = True
        Btn_Atras.Enabled = True
        btn_exportar.Enabled = True
        btn_Guardar.Enabled = True
        btn_Cargar.Enabled = True


        lbl_Total.Text = "0"
        btn_Guardar.Text = "GUARDAR"
        lbl_TVenta.Text = "0"
        btn_anular.Visible = True
        lbl_Estado.Visible = False

        btn_CrearEnSAP.Visible = True
        lbl_PedidoEnSAP.Visible = False


        btn_BuscaAgente.Enabled = True
        btn_Guardar.Enabled = True
        lbl_NumOrden.Text = CInt(Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneConseOrdenCompra(Class_VariablesGlobales.SQL_Comman2)) + 1
    End Function


    Public Function Editar(ByVal index As Integer)
        Try
            Cursor = System.Windows.Forms.Cursors.WaitCursor

            '            If Class_VariablesGlobales.frmEditaLinePedido Is Nothing Then
            '                Class_VariablesGlobales.frmEditaLinePedido = New Pedido_EditaLinea
            '                Class_VariablesGlobales.frmEditaLinePedido.MdiParent = Principal

            '            End If

            '            If Class_VariablesGlobales.frmCreaPedido.txtb_sap.Text <> "" Then
            '                Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Enabled = False


            '            End If

            '            'frmEditaLinePedido.MdiParent = Principal
            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_Index.Text = index
            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_ID.Text = DTG_DetPedido.CurrentRow.Cells(0).Value
            '            Class_VariablesGlobales.frmEditaLinePedido.txt_Emp.Text = DTG_DetPedido.CurrentRow.Cells(9).Value
            '            Class_VariablesGlobales.frmEditaLinePedido.txt_Precio.Text = Format(DTG_DetPedido.CurrentRow.Cells(8).Value, "##,##00.00")
            '            Class_VariablesGlobales.frmEditaLinePedido.txt_CodArt.Text = DTG_DetPedido.CurrentRow.Cells(6).Value
            '            Class_VariablesGlobales.frmEditaLinePedido.txt_Descrip.Text = DTG_DetPedido.CurrentRow.Cells(7).Value

            '            Class_VariablesGlobales.frmEditaLinePedido.txt_Venta_Unid.Text = DTG_DetPedido.CurrentRow.Cells(11).Value




            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_PedidoXAgente.Text = DTG_DetPedido.CurrentRow.Cells(13).Value
            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_PedidoXAgenteCJs.Text = Math.Round(CDbl(Class_VariablesGlobales.frmEditaLinePedido.txtb_PedidoXAgente.Text) / CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Emp.Text), 2, MidpointRounding.ToEven)
            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_PedidoXAgenteMonto.Text = Format(CDbl(Class_VariablesGlobales.frmEditaLinePedido.txtb_PedidoXAgente.Text) * CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Precio.Text), "##,##00.00")



            '            Class_VariablesGlobales.frmEditaLinePedido.txt_Faltante.Text = DTG_DetPedido.CurrentRow.Cells(14).Value

            '            Class_VariablesGlobales.frmEditaLinePedido.txt_FaltanteCjs.Text = Math.Round(CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Faltante.Text) / CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Emp.Text), 2, MidpointRounding.ToEven)
            '            Class_VariablesGlobales.frmEditaLinePedido.txt_FaltanteMonto.Text = Format(CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Faltante.Text) * CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Precio.Text), "##,##00.00")

            '            '  frmEditaLinePedido.txt_Max.Text = DataGridView1.CurrentRow.Cells(20).Value


            '            Class_VariablesGlobales.frmEditaLinePedido.txt_Venta_Unid.Text = DTG_DetPedido.CurrentRow.Cells(11).Value
            '            Class_VariablesGlobales.frmEditaLinePedido.txt_Venta_Cjs.Text = Math.Round(CDbl(DTG_DetPedido.CurrentRow.Cells(12).Value), 2, MidpointRounding.ToEven)
            '            Class_VariablesGlobales.frmEditaLinePedido.txt_Venta_Mont.Text = Format(DTG_DetPedido.CurrentRow.Cells(10).Value, "##,##00.00")

            '            Class_VariablesGlobales.frmEditaLinePedido.txt_Stock_Unid.Text = DTG_DetPedido.CurrentRow.Cells(15).Value
            '            Class_VariablesGlobales.frmEditaLinePedido.txt_Stock_Cajas.Text = Math.Round(CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Stock_Unid.Text) / CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Emp.Text), 2, MidpointRounding.ToEven)
            '            Class_VariablesGlobales.frmEditaLinePedido.txt_Stock_Mont.Text = Format(CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Stock_Unid.Text) * CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Precio.Text), "##,##00.00")


            '            Class_VariablesGlobales.frmEditaLinePedido.Fila = DTG_DetPedido.CurrentRow.Index
            '            'frmEditaLinePedido.txt_Cajas.Text = DataGridView1.CurrentRow.Cells(21).Value
            '            If Class_VariablesGlobales.frmEditaLinePedido.RdBtb_Cajas.Checked = True Then
            '                Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Text = DTG_DetPedido.CurrentRow.Cells(22).Value
            '                'frmEditaLinePedido.CantCajas = DataGridView1.CurrentRow.Cells(21).Value
            '            Else
            '                Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Text = DTG_DetPedido.CurrentRow.Cells(21).Value

            '            End If
            '            Class_VariablesGlobales.frmEditaLinePedido.CantCajas = DTG_DetPedido.CurrentRow.Cells(22).Value


            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_CardCode.Text = txtb_CodProveedor.Text
            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_CardName.Text = txtb_NombreProveedor.Text

            '            Class_VariablesGlobales.OrCom_ID = lbl_NumOrden.Text
            '            Class_VariablesGlobales.OrCom_NumDoc = lbl_NumOrden.Text
            '            Class_VariablesGlobales.OrCom_CardCode = txtb_CodProveedor.Text
            '            Class_VariablesGlobales.OrCom_CardName = txtb_NombreProveedor.Text

            '            Class_VariablesGlobales.OrCom_FIniVenta = DateTimePicker1.Value.ToShortDateString()
            '            Class_VariablesGlobales.OrCom_FFinVenta = DateTimePicker2.Value.ToShortDateString()


            '            Class_VariablesGlobales.OrCom_Fecha = Class_VariablesGlobales.Obj_Fecha.FormatoFechaSql(Now.Date)
            '            Class_VariablesGlobales.OrCom_ItemCode = DTG_DetPedido.CurrentRow.Cells(6).Value
            '            Class_VariablesGlobales.OrCom_ItemName = DTG_DetPedido.CurrentRow.Cells(7).Value
            '            Class_VariablesGlobales.OrCom_Alterno = DTG_DetPedido.CurrentRow.Cells(5).Value
            '            Class_VariablesGlobales.OrCom_Emp = DTG_DetPedido.CurrentRow.Cells(9).Value
            '            Class_VariablesGlobales.OrCom_Precio_Costo = DTG_DetPedido.CurrentRow.Cells(8).Value
            '            Class_VariablesGlobales.OrCom_Venta_Unid = DTG_DetPedido.CurrentRow.Cells(11).Value
            '            Class_VariablesGlobales.OrCom_Venta_Cjs = DTG_DetPedido.CurrentRow.Cells(12).Value
            '            Class_VariablesGlobales.OrCom_Venta_Mont = DTG_DetPedido.CurrentRow.Cells(10).Value

            '            Class_VariablesGlobales.OrCom_FechaUltimaCompra = DTG_DetPedido.CurrentRow.Cells(41).Value
            '            Class_VariablesGlobales.OrCom_Stock_Unidad = DTG_DetPedido.CurrentRow.Cells(15).Value
            '            Class_VariablesGlobales.OrCom_Stock_Cjs = DTG_DetPedido.CurrentRow.Cells(16).Value
            '            Class_VariablesGlobales.OrCom_Stock_Monto = FormatCurrency(DTG_DetPedido.CurrentRow.Cells(17).Value, 2)

            '            Class_VariablesGlobales.OrCom_Comprometido = DTG_DetPedido.CurrentRow.Cells(19).Value

            '            Class_VariablesGlobales.frmEditaLinePedido.textb_Comprometido.Text = Class_VariablesGlobales.OrCom_Comprometido
            '            Class_VariablesGlobales.frmEditaLinePedido.textb_ComprometidoCjs.Text = Math.Round(CDbl(Class_VariablesGlobales.OrCom_Comprometido) / CDbl(Class_VariablesGlobales.OrCom_Emp), 2, MidpointRounding.ToEven)
            '            Class_VariablesGlobales.frmEditaLinePedido.textb_ComprometidoMonto.Text = Format(Class_VariablesGlobales.OrCom_Comprometido * Class_VariablesGlobales.OrCom_Precio_Costo, "##,##00.00")
            '            Class_VariablesGlobales.frmEditaLinePedido.Textb_Compra.Text = DTG_DetPedido.CurrentRow.Cells(31).Value
            '            Class_VariablesGlobales.frmEditaLinePedido.Textb_CompraCjs.Text = Math.Round(CDbl(DTG_DetPedido.CurrentRow.Cells(31).Value) / CDbl(Class_VariablesGlobales.OrCom_Emp), 2, MidpointRounding.ToEven)
            '            Class_VariablesGlobales.frmEditaLinePedido.Textb_CompraMonto.Text = Format(DTG_DetPedido.CurrentRow.Cells(31).Value * Class_VariablesGlobales.OrCom_Precio_Costo, "##,##00.00")
            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_DiasInve.Text = DTG_DetPedido.CurrentRow.Cells(26).Value
            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_PromVDiaria.Text = DTG_DetPedido.CurrentRow.Cells(25).Value
            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_FechaUltimaCompra.Text = DTG_DetPedido.CurrentRow.Cells(41).Value
            '            Class_VariablesGlobales.OrCom_Pd_CJs = DTG_DetPedido.CurrentRow.Cells(22).Value
            '            Class_VariablesGlobales.OrCom_Pd_Unid = DTG_DetPedido.CurrentRow.Cells(21).Value

            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_Rotacion.Text = Math.Round(CDbl(Class_VariablesGlobales.frmEditaLinePedido.Textb_Compra.Text) / CDbl(Class_VariablesGlobales.frmEditaLinePedido.txtb_PromVDiaria.Text), 2, MidpointRounding.ToEven)

            '            Class_VariablesGlobales.OrCom_Pd_Total = DTG_DetPedido.CurrentRow.Cells(23).Value
            '            Class_VariablesGlobales.OrCom_CodBarras = DTG_DetPedido.CurrentRow.Cells(32).Value
            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_Barras.Text = DTG_DetPedido.CurrentRow.Cells(32).Value
            '            If DTG_DetPedido.CurrentRow.Cells(33).Value = Nothing Then
            '                Class_VariablesGlobales.OrCom_UGramaje = 0
            '            Else
            '                Class_VariablesGlobales.OrCom_UGramaje = DTG_DetPedido.CurrentRow.Cells(33).Value
            '            End If



            '            ' Class_VariablesGlobales.OrCom_DiasSinMoverse = DataGridView1.CurrentRow.Cells(34).Value

            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_MontoPedi.Text = Format(DTG_DetPedido.CurrentRow.Cells(21).Value * Class_VariablesGlobales.OrCom_Precio_Costo, "##,##00.00")

            '            Class_VariablesGlobales.OrCom_Stock_Real = DTG_DetPedido.CurrentRow.Cells(15).Value
            '            Class_VariablesGlobales.OrCom_Cmp1 = DTG_DetPedido.CurrentRow.Cells(30).Value

            '            Class_VariablesGlobales.frmEditaLinePedido.lbl_NumOrden.Text = lbl_NumOrden.Text


            '            Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Focus()


            '            '--------------------------------------------------------------------
            '            Dim Tbl_PedidoNube As New DataTable
            '            Dim Tbl_DevolucionesNube As New DataTable
            '            Dim contardor As Integer = 0
            '            Dim CantPedidoNube As Integer
            '            Dim CantDevolucionesNube As Integer

            '            Tbl_DevolucionesNube = Class_VariablesGlobales.Obj_Funciones_MYSQL.ObtieneDevolucionesDelDia(Class_VariablesGlobales.OrCom_ItemCode, Class_VariablesGlobales.Obj_Fecha.FormatFechaSqlite(Now.ToShortDateString))
            '            Tbl_PedidoNube = Class_VariablesGlobales.Obj_Funciones_MYSQL.ObtienePedidosDelDia(Class_VariablesGlobales.OrCom_ItemCode, Class_VariablesGlobales.Obj_Fecha.FormatFechaSqlite(Now.ToShortDateString))

            '            'Recorre la tabla y verifica si el pedido ya existe en SAP,SI existe descarta la cantidad de la suma, SINO suma la cantidad
            '            If Tbl_PedidoNube.Rows.Count > 0 Then
            '                While contardor < Tbl_PedidoNube.Rows.Count
            '                    If Class_VariablesGlobales.Obj_Funciones_SQL.ExistePedidoEnSAP(Class_VariablesGlobales.SQL_Comman2, Tbl_PedidoNube.Rows(contardor).Item("DocNum").ToString().Trim) = True Then

            '                    Else
            '                        CantPedidoNube = CantPedidoNube + CInt(Tbl_PedidoNube.Rows(contardor).Item("Cantidad").ToString())
            '                    End If

            '                    contardor += 1
            '                End While
            '            End If
            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_Pedido.Text = CantPedidoNube
            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_PedidoCjs.Text = Math.Round(CDbl(Class_VariablesGlobales.frmEditaLinePedido.txtb_Pedido.Text) / CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Emp.Text), 2, MidpointRounding.ToEven)
            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_PedidoMonto.Text = Format(CDbl(Class_VariablesGlobales.frmEditaLinePedido.txtb_Pedido.Text) * CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Precio.Text), "##,##00.00")

            '            'Verifica que el numero de voleta no alla sido procesada
            '            contardor = 0
            '            If Tbl_DevolucionesNube.Rows.Count > 0 Then
            '                While contardor < Tbl_DevolucionesNube.Rows.Count
            '                    If Class_VariablesGlobales.Obj_Funciones_SQL.ExisteDevolucionEnSAP(Class_VariablesGlobales.SQL_Comman2, Tbl_DevolucionesNube.Rows(contardor).Item("DocNum").ToString()) = True Then

            '                    Else
            '                        CantDevolucionesNube = CantDevolucionesNube + CInt(Tbl_DevolucionesNube.Rows(contardor).Item("Cantidad").ToString())
            '                    End If

            '                    contardor += 1
            '                End While
            '            End If
            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_Devoluciones.Text = CantDevolucionesNube
            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_DevolucionesCjs.Text = Math.Round(CDbl(Class_VariablesGlobales.frmEditaLinePedido.txtb_Devoluciones.Text) / CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Emp.Text), 2, MidpointRounding.ToEven)
            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_DevolucionesMonto.Text = Format(CDbl(Class_VariablesGlobales.frmEditaLinePedido.txtb_Devoluciones.Text) * CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Precio.Text), "##,##00.00")

            '            '--------------------------------------------------------------------


            '            'Calcula el sugerido
            '            'Stock + Devoluciones -(Venta ò Pedido)-comprometido-Pedido en curso
            '            'Nota:
            '            'Las Devoluciones en curso son solo de choferes ya que el de agentes puede que vaya para bodega 2
            '            'Se agarra el monto mayor entre la venta y pedido ya que puede ser que las ventas las hagan directo a oficina
            '            'Comprometido en lo que ya esta en SAP procesado por lo que esta proximo a facturar
            '            'Pedido en curso es lo que los agentes ha pedido hasta el momento de entrar
            '            Dim MontoMayor As Integer
            '            If CInt(Class_VariablesGlobales.frmEditaLinePedido.txt_Venta_Unid.Text) > CInt(Class_VariablesGlobales.frmEditaLinePedido.txtb_PedidoXAgente.Text) Then
            '                MontoMayor = CInt(Class_VariablesGlobales.frmEditaLinePedido.txt_Venta_Unid.Text)
            '            Else
            '                MontoMayor = CInt(Class_VariablesGlobales.frmEditaLinePedido.txtb_PedidoXAgente.Text)
            '            End If
            '            'Obtiene el stock Disponible segun todos los parametros
            '            Class_VariablesGlobales.frmEditaLinePedido.txt_Stock_Dispobles.Text = CInt(Class_VariablesGlobales.frmEditaLinePedido.txt_Stock_Unid.Text) - CInt(Class_VariablesGlobales.frmEditaLinePedido.textb_Comprometido.Text) - CInt(Class_VariablesGlobales.frmEditaLinePedido.txtb_Pedido.Text) + CInt(Class_VariablesGlobales.frmEditaLinePedido.txtb_Devoluciones.Text)
            '            Class_VariablesGlobales.frmEditaLinePedido.txt_Stock_Dispobles_Cjs.Text = Math.Round(CDbl(CInt(Class_VariablesGlobales.frmEditaLinePedido.txt_Stock_Dispobles.Text)) / CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Emp.Text), 2, MidpointRounding.ToEven)
            '            Class_VariablesGlobales.frmEditaLinePedido.txt_Stock_Monto.Text = Format(CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Stock_Dispobles.Text) * CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Precio.Text), "##,##00.00")

            '            'Si la cantidad a pedir es 0 Stock+Devoluciones
            '            If Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Text = "" Or Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Text = "0"Then
            '                Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Text = CInt(Class_VariablesGlobales.frmEditaLinePedido.txt_Stock_Dispobles.Text) - CInt(MontoMayor)



            '                If (CInt(Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Text) < 0) Then
            '                Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Text = CInt(Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Text) * -1
            '                Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Text = Math.Ceiling(CInt(Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Text) / CInt(Class_VariablesGlobales.frmEditaLinePedido.txt_Emp.Text)) * CInt(Class_VariablesGlobales.frmEditaLinePedido.txt_Emp.Text)
            '            Else
            '                'Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Text = 0
            '            End If
            '            'Class_VariablesGlobales.frmEditaLinePedido.txt_Unidades.Text = Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Text
            '            'Class_VariablesGlobales.frmEditaLinePedido.txt_Cajas.Text = Math.Round(CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Unidades.Text) / CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Emp.Text), 2, MidpointRounding.ToEven)
            '            'Class_VariablesGlobales.frmEditaLinePedido.txtb_MontoPedi.Text = Format(CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Unidades.Text) * CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Precio.Text), "##,##00.00")

            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_Disponible.Text = CInt(Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Text)
            '            Class_VariablesGlobales.frmEditaLinePedido.txtb_StockCubrira.Text = Math.Round(CDbl(Class_VariablesGlobales.frmEditaLinePedido.txtb_Disponible.Text) / CDbl(Class_VariablesGlobales.frmEditaLinePedido.txtb_PromVDiaria.Text), 2, MidpointRounding.ToEven)


            '            'SI ASIGNAMOS LOS DIAS RESTANTES A CUBRIR YA CON ESO DAMOS UN SUGERIDO
            '            If CDbl(Class_VariablesGlobales.frmEditaLinePedido.txtb_DiasInve.Text) > 0 Then
            '                'le restamos a los indias insicados en la semana de ventas - los dias que cubre el inventario disponible para saber cuantos dias hacen falta cubrir para evitar faltantes
            '                Class_VariablesGlobales.frmEditaLinePedido.txtb_StockCubrira.Text = CDbl(Class_VariablesGlobales.frmCreaPedido.txtb_DiasACubrir.Text) - CDbl(Class_VariablesGlobales.frmEditaLinePedido.txtb_StockCubrira.Text)
            '                Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Text = CDbl(Class_VariablesGlobales.frmEditaLinePedido.txtb_StockCubrira.Text) * CDbl(Class_VariablesGlobales.frmEditaLinePedido.txtb_PromVDiaria.Text)
            '                    'Redonde hacia arriba
            '                    ' Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Text = Math.Ceiling(CInt(Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Text) / CInt(Class_VariablesGlobales.frmEditaLinePedido.txt_Emp.Text)) * CInt(Class_VariablesGlobales.frmEditaLinePedido.txt_Emp.Text)
            '                    'redonde hacia abajo
            '                    Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Text = Math.Floor(Math.Abs(CInt(Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Text) / CInt(Class_VariablesGlobales.frmEditaLinePedido.txt_Emp.Text))) * CInt(Class_VariablesGlobales.frmEditaLinePedido.txt_Emp.Text)
            '                    If Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Text = "0" Then
            '                        'si el sugerido es 0 entonces los dias a cubri seria 0 ya que no pide nada
            '                        Class_VariablesGlobales.frmEditaLinePedido.txtb_StockCubrira.Text = "0"
            '                    Else
            '                        'calcula segun vendia promedio por dia los dias a cubri
            '                        Class_VariablesGlobales.frmEditaLinePedido.txtb_StockCubrira.Text = Math.Round(CDbl(Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Text) / CDbl(Class_VariablesGlobales.frmEditaLinePedido.txtb_PromVDiaria.Text), 2, MidpointRounding.ToEven)

            '                    End If
            '                Else
            '                Class_VariablesGlobales.frmEditaLinePedido.txtb_StockCubrira.Text = CDbl(Class_VariablesGlobales.frmCreaPedido.txtb_DiasACubrir.Text) - (CDbl(Class_VariablesGlobales.frmEditaLinePedido.txtb_DiasInve.Text) * -1)
            '            End If
            'End If

            If Class_VariablesGlobales.frmEditaLinePedido Is Nothing Then
                Class_VariablesGlobales.frmEditaLinePedido = New Pedido_EditaLinea
                Class_VariablesGlobales.frmEditaLinePedido.MdiParent = Principal

            End If
            Class_VariablesGlobales.frmEditaLinePedido.MdiParent = Principal
            Class_VariablesGlobales.frmEditaLinePedido.lbl_NumOrden.Text = lbl_NumOrden.Text
            Class_VariablesGlobales.frmEditaLinePedido.txtb_Index.Text = index
            Class_VariablesGlobales.frmEditaLinePedido.txt_Emp.Text = DTG_DetPedido.CurrentRow.Cells(9).Value
            Class_VariablesGlobales.frmEditaLinePedido.txt_CodArt.Text = DTG_DetPedido.CurrentRow.Cells(6).Value
            Class_VariablesGlobales.frmEditaLinePedido.txtb_ID.Text = DTG_DetPedido.CurrentRow.Cells(0).Value
            Class_VariablesGlobales.frmEditaLinePedido.txtb_CardCode.Text = txtb_CodProveedor.Text
            Class_VariablesGlobales.frmEditaLinePedido.txtb_CardName.Text = txtb_NombreProveedor.Text
            Class_VariablesGlobales.frmEditaLinePedido.Show()

            Class_VariablesGlobales.frmEditaLinePedido.txt_Cantidad.Enabled = btn_CrearEnSAP.Enabled
            Class_VariablesGlobales.frmEditaLinePedido.txtb_StockCubrira.Enabled = btn_CrearEnSAP.Enabled

            Class_VariablesGlobales.frmEditaLinePedido.Navegar(CInt(Class_VariablesGlobales.frmEditaLinePedido.txtb_ID.Text))


            Cursor = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Function



    Private Sub btn_Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Buscar.Click

        Class_VariablesGlobales.ListaPedidoLlamadoDesde = "PEDIDOR"
        Class_VariablesGlobales.frmPedido_ListaPedidosGuardados = New Pedido_ListaPedidosGuardados
        Class_VariablesGlobales.frmPedido_ListaPedidosGuardados.MdiParent = Principal
        Class_VariablesGlobales.frmPedido_ListaPedidosGuardados.Show()

    End Sub





    Private Sub txtb_Email_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtb_Email.TextChanged
        ' Recalcula(False)
    End Sub



    Private Sub RdBtb_Unidades_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdBtb_Unidades.CheckedChanged
        '  Recalcula(False)
    End Sub




    Private Sub DTG_DetPedido_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DTG_DetPedido.CellContentClick

    End Sub

    Private Sub DTG_DetPedido_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DTG_DetPedido.RowEnter
        'Editar(e.RowIndex)
    End Sub

    Private Sub DTG_DetPedido_CellMouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DTG_DetPedido.CellMouseMove
        Try
            DTG_DetPedido.ClearSelection()
            DTG_DetPedido.Rows(e.RowIndex).Selected() = True
        Catch ex As Exception

        End Try
    End Sub



    Private Sub btn_anular_Click(sender As Object, e As EventArgs) Handles btn_anular.Click
        Class_VariablesGlobales.Obj_Funciones_SQL.AnularPedido(Class_VariablesGlobales.SQL_Comman2, lbl_NumOrden.Text.Trim)

        btn_anular.Visible = False
        lbl_Estado.Visible = True
        Class_VariablesGlobales.frmCreaPedido.btn_CrearEnSAP.Enabled = False
        Class_VariablesGlobales.frmCreaPedido.btn_Guardar.Enabled = False
        Class_VariablesGlobales.frmCreaPedido.btn_Cargar.Enabled = False
        Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.ReadOnly = False

        lbl_Estado.Text = "ANULADO"
    End Sub

    Private Sub btn_exportar_Click(sender As Object, e As EventArgs) Handles btn_exportar.Click

        obj_Exportar.ExportarDatosExcel2(obj_Exportar.LimpiaPedido(DTG_DetPedido), txtb_NombreProveedor.Text)
        '  obj_Exportar.Exportar(obj_Exportar.LimpiaPedido(DTG_DetPedido), txtb_NombreProveedor.Text)
    End Sub





    Public Function ImprimirPedidoProveedor(RutaFile As String)
        Try
            Dim obj_Exportar As New ExportarAExcell
            Dim parametros As Integer = 0
            Dim cryRpt As OrdenDeCompra
            Dim MiConexion As New CrystalDecisions.Shared.ConnectionInfo


            cryRpt = New OrdenDeCompra
            Dim myTables As CrystalDecisions.CrystalReports.Engine.Tables = cryRpt.Database.Tables

            cryRpt.SetDatabaseLogon(Class_VariablesGlobales.XMLParamSQL_user, Class_VariablesGlobales.XMLParamSQL_clave, Class_VariablesGlobales.XMLParamSQL_server, Class_VariablesGlobales.XMLParamSAP_CompanyDB, False)


            MiConexion.ServerName = Class_VariablesGlobales.XMLParamSQL_server
            MiConexion.DatabaseName = Class_VariablesGlobales.XMLParamSAP_CompanyDB
            'MiConexion.DatabaseName = "DB_BOURNE_PRUEBAS"
            MiConexion.UserID = Class_VariablesGlobales.XMLParamSQL_user
            MiConexion.Password = Class_VariablesGlobales.XMLParamSQL_clave

            For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
                Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
                myTableLogonInfo.ConnectionInfo = MiConexion
                myTable.ApplyLogOnInfo(myTableLogonInfo)
            Next
            '----- PARAMETROS REPORTE PADRE  --------------
            '0:          Consecutivo()



            cryRpt.SetParameterValue(0, Class_VariablesGlobales.frmCreaPedido.lbl_NumOrden.Text)
            ' Dim pd As New PrintDocument
            'Se define el print Document.
            'Dim impresora_predeterminada As String = pd.PrinterSettings.PrinterName

            ' cryRpt.PrintOptions.PrinterName = impresora_predeterminada
            'cryRpt.PrintToPrinter(1, False, 0, 0)

            obj_Exportar.ExportToPDF(cryRpt, lbl_NumOrden.Text, RutaFile)


            parametros = Nothing
            cryRpt = Nothing
            MiConexion = Nothing
            myTables = Nothing
            ' myTableLogonInfo = Nothing
            'pd = Nothing
            'impresora_predeterminada = Nothing

            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error al generar el PDF ImprimirPedidoProveedor: " & ex.Message)

            Me.Close()
        End Try
    End Function

    Private Sub DTG_DetPedido_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DTG_DetPedido.CellDoubleClick
        Try
            Editar(e.RowIndex)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DTG_DetPedido_MouseClick(sender As Object, e As MouseEventArgs) Handles DTG_DetPedido.MouseClick
        'Dim Cont As Integer = 0
        'For Each row As DataGridViewRow In Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows
        '    If (CInt(row.Cells(11).Value) < 0) Then


        '        'Me.DTG_DetPedido.Columns(23).DefaultCellStyle.BackColor = Color.LightGreen
        '        row.DefaultCellStyle.BackColor = Color.Red
        '        row.DefaultCellStyle.ForeColor = Color.White
        '        'Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows(Cont).DefaultCellStyle.BackColor = Color.Red
        '        Cont += 1

        '    End If

        'Next
    End Sub

    Private Sub DTG_DetPedido_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DTG_DetPedido.CellMouseClick
        Try
            'DTG_DetPedido.ClearSelection()
            'DTG_DetPedido.Rows(e.RowIndex).Selected() = True
            'Dim Cont As Integer = 0
            'For Each row As DataGridViewRow In Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows
            '    If (CInt(row.Cells(11).Value) < 0) Then
            '        If (Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneRevisado(Class_VariablesGlobales.SQL_Comman1, lbl_NumOrden.Text, row.Cells(6).Value) = "0") Then
            '            row.DefaultCellStyle.BackColor = Color.Red
            '            row.DefaultCellStyle.ForeColor = Color.White
            '            Cont += 1

            '        End If
            '    End If
            'Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DTG_DetPedido_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DTG_DetPedido.ColumnHeaderMouseClick
        Dim Cont As Integer = 0
        For Each row As DataGridViewRow In Class_VariablesGlobales.frmCreaPedido.DTG_DetPedido.Rows
            If (CInt(row.Cells(11).Value) < 0) Then
                If (Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneRevisado(Class_VariablesGlobales.SQL_Comman1, lbl_NumOrden.Text, row.Cells(6).Value) = "0") Then
                    row.DefaultCellStyle.BackColor = Color.Red
                    row.DefaultCellStyle.ForeColor = Color.White
                    Cont += 1

                End If
            End If
        Next
    End Sub



    Private Sub DTG_DetPedido_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DTG_DetPedido.CellBeginEdit
        'Obtiene los valores originales para comprar y saber cual fue editado si las unidades o las cajas
        BeginEdita_Pd_Unid = Me.DTG_DetPedido.Rows(e.RowIndex).Cells("Pd_Unid").Value
        BeginEdita_ItemCode = Me.DTG_DetPedido.Rows(e.RowIndex).Cells("ItemCode").Value
        BeginEdita_Pack = Me.DTG_DetPedido.Rows(e.RowIndex).Cells("Pack").Value
        BeginEdita_Costo = Me.DTG_DetPedido.Rows(e.RowIndex).Cells("Costo").Value
        BeginEdita_Pd_Cjs = Me.DTG_DetPedido.Rows(e.RowIndex).Cells("Pd_Cjs").Value
        BeginEdita_Pd_Total = Me.DTG_DetPedido.Rows(e.RowIndex).Cells("Pd_Total").Value
    End Sub

    Private Sub DTG_DetPedido_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DTG_DetPedido.CellEndEdit


        ActualizaLinea(e.RowIndex)
    End Sub


    Public Function ActualizaLinea(RowIndex As Integer)


        EndEdita_Pd_Unid = Me.DTG_DetPedido.Rows(RowIndex).Cells("Pd_Unid").Value
        EndEdita_ItemCode = Me.DTG_DetPedido.Rows(RowIndex).Cells("ItemCode").Value
        EndEdita_Pack = Me.DTG_DetPedido.Rows(RowIndex).Cells("Pack").Value
        EndEdita_Costo = Me.DTG_DetPedido.Rows(RowIndex).Cells("Costo").Value
        EndEdita_Pd_Cjs = Me.DTG_DetPedido.Rows(RowIndex).Cells("Pd_Cjs").Value
        EndEdita_Pd_Total = Me.DTG_DetPedido.Rows(RowIndex).Cells("Pd_Total").Value



        'se debe verificar si se editar la cantidad de cajas o unidades
        If BeginEdita_Pd_Unid <> EndEdita_Pd_Unid Then
            EndEdita_Pd_Cjs = EndEdita_Pd_Unid / EndEdita_Pack

        End If

        If BeginEdita_Pd_Cjs <> EndEdita_Pd_Cjs Then
            EndEdita_Pd_Unid = EndEdita_Pd_Cjs * EndEdita_Pack

        End If

        EndEdita_Pd_Total = EndEdita_Pd_Unid * EndEdita_Costo

        Dim Back_Total As Double = BeginEdita_Pd_Total

        Dim Ajuste As Double




        Me.DTG_DetPedido.Rows(RowIndex).Cells("Pd_Unid").Value = EndEdita_Pd_Unid
        Me.DTG_DetPedido.Rows(RowIndex).Cells("Pd_Cjs").Value = EndEdita_Pd_Cjs
        Me.DTG_DetPedido.Rows(RowIndex).Cells("Pd_Total").Value = EndEdita_Pd_Total

        Ajuste = EndEdita_Pd_Total - Back_Total

        Class_VariablesGlobales.Obj_Funciones_SQL.ActualizaLineaPedido(Class_VariablesGlobales.SQL_Comman1, lbl_NumOrden.Text, EndEdita_Pd_Total, EndEdita_Pd_Unid, EndEdita_Pd_Cjs, EndEdita_ItemCode)


        lbl_Total.Text = FormatCurrency((lbl_Total.Text + Ajuste), 2)

        EndEdita_Pd_Unid = Nothing
        EndEdita_ItemCode = Nothing
        EndEdita_Pack = Nothing
        EndEdita_Costo = Nothing
        EndEdita_Pd_Cjs = Nothing
        EndEdita_Pd_Total = Nothing
        Back_Total = Nothing

        Ajuste = Nothing

        BeginEdita_Pd_Unid = Nothing
        BeginEdita_ItemCode = Nothing
        BeginEdita_Pack = Nothing
        BeginEdita_Costo = Nothing
        BeginEdita_Pd_Cjs = Nothing
        BeginEdita_Pd_Total = Nothing
    End Function



    Private Sub lbl_PedidoEnSAP_Click(sender As Object, e As EventArgs) Handles lbl_PedidoEnSAP.Click

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Btn_VerChequeo.Click

        Dim NumPedidoSAP As Integer = 0
        NumPedidoSAP = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneNumPedidoCreado(Class_VariablesGlobales.SQL_Comman1, lbl_NumOrden.Text)


        Class_VariablesGlobales.frmWMS_PedidosChequeados = New WMS_PedidosChequeados
        Class_VariablesGlobales.frmWMS_PedidosChequeados.MdiParent = Principal
        Class_VariablesGlobales.frmWMS_PedidosChequeados.Show()

        Class_VariablesGlobales.frmWMS_PedidosChequeados.ObtienePedidoChequeado(lbl_NumOrden.Text)


    End Sub
End Class