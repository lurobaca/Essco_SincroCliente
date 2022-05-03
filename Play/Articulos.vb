Imports System.Runtime.InteropServices
Public Class Articulos
    Public Busca As String = "SAP"

    'Agregar la linea a una tabla temporal la cual eria jala desde la ventana de facturas como factura borrador esto mediante un 
    Public DocNum As String = ""
    Public DocType As String = ""
    Public NumLinea As String = ""
    Public ItemCode As String = ""
    Public ItemName As String = ""
    Public Pack As String = ""
    Public UnidadMedida As String = ""
    Public Costo As String = ""
    Public PrecioUnitario As String = ""
    Public Utilidad_Porciento As String = ""
    Public Utilidad_Monto As String = ""
    Public Cantidad As String = "1"
    Public Descuento_Porciento As String = ""
    Public Descuento_Monto As String = ""

    Public CodigoTarifa As String = ""
    Public Impuesto_Porciento As String = ""
    Public Impuesto_Monto As String = ""
    Public SubTotal As String = ""
    Public Total As String = ""
    Public Descuento_Promo_Porciento As String = ""
    Public Descuento_Promo_Monto As String = ""
    Public Descuento_Interno_Porciento As String = ""
    Public Descuento_Interno_Monto As String = ""
    Public ColumnaBusqueda As Integer = 0
    Private Sub Articulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        SendMessage(Me.txtb_Buscar.Handle, &H1501, 0, "Busca por codigo de articulo")
        If Busca = "SAP" Then
            Dgv_Articulos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneArticulos(Class_VariablesGlobales.frmDevoluciones.txtb_CodCliente.Text, "", Cbox_VerDesc.Checked, ColumnaBusqueda, Class_VariablesGlobales.SQL_Comman2)
        ElseIf Class_VariablesGlobales.ArticulosLlamadoDesde = "Facturacion" Then
            Dgv_Articulos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneArticulosInternos(Class_VariablesGlobales.frmFacturacion.CBox_TipoProducto.Text, Class_VariablesGlobales.frmFacturacion.txtb_CodCliente.Text, "", Cbox_VerDesc.Checked, ColumnaBusqueda, Class_VariablesGlobales.SQL_Comman2)
        ElseIf Class_VariablesGlobales.ArticulosLlamadoDesde = "Stock_Manager" Then
            Dgv_Articulos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneArticulosInternos("*", "", "", Cbox_VerDesc.Checked, ColumnaBusqueda, Class_VariablesGlobales.SQL_Comman2)
        ElseIf Class_VariablesGlobales.ArticulosLlamadoDesde = "Devoluciones" Then
            Dgv_Articulos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneArticulos(Class_VariablesGlobales.frmDevoluciones.txtb_CodCliente.Text, "", Cbox_VerDesc.Checked, ColumnaBusqueda, Class_VariablesGlobales.SQL_Comman2)
        Else
            Dgv_Articulos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneArticulosInternos("Servicios", Class_VariablesGlobales.frmDevoluciones.txtb_CodCliente.Text, "", Cbox_VerDesc.Checked, ColumnaBusqueda, Class_VariablesGlobales.SQL_Comman2)
        End If




        organizar()
    End Sub
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As Int32
    End Function

    Public Sub organizar()
        Try


            Dgv_Articulos.Columns(0).Width = 80 'nombre aritucl
            Dgv_Articulos.Columns(1).Width = 350 'nombre aritucl
            Dgv_Articulos.Columns(2).Width = 30 'nombre aritucl
            Dgv_Articulos.Columns(3).Width = 100 'nombre aritucl
        Catch ex As Exception

        End Try
    End Sub



    Private Sub Dgv_Articulos_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dgv_Articulos.Enter
        'Public row = Dgv_Articulos.CurrentRow.Index
        'Class_VariablesGlobales.frmDevoluciones.Dtg_Devoluciones.Rows.Insert(0, Dgv_Articulos(0, row).Value.ToString(), Dgv_Articulos(1, row).Value.ToString(), Dgv_Articulos(4, row).Value.ToString(), "1", "0", 1 * CDbl(Dgv_Articulos(4, row).Value.ToString()), "01")

    End Sub

    Private Sub txtb_Buscar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtb_Buscar.KeyPress


    End Sub

    Private Sub Dgv_Articulos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Articulos.CellDoubleClick
        Try


            Dim row = Dgv_Articulos.CurrentRow.Index
            If Class_VariablesGlobales.ArticulosLlamadoDesde = "Facturacion" Then

                PrecioUnitario = Dgv_Articulos("Precio", row).Value.ToString()
                Cantidad = 1

                ItemCode = Dgv_Articulos("ItemCode", row).Value.ToString()
                ItemName = Dgv_Articulos("Descripcion", row).Value.ToString()



                If Dgv_Articulos("Tarifa", row).Value.ToString().Trim = "" Then
                    Impuesto_Porciento = "0"
                    SubTotal = CDbl(Dgv_Articulos("Precio", row).Value.ToString())
                    Impuesto_Monto = 0
                    CodigoTarifa = Dgv_Articulos("Cod_tarifa", row).Value.ToString()
                Else
                    If Trim(Dgv_Articulos("Tarifa", row).Value.ToString()) <> "0" Then
                        Impuesto_Porciento = Dgv_Articulos("Tarifa", row).Value.ToString()
                        SubTotal = CDbl(Dgv_Articulos("Precio", row).Value.ToString())
                        Impuesto_Monto = (SubTotal * CInt(Impuesto_Porciento)) / 100
                        CodigoTarifa = Dgv_Articulos("Cod_tarifa", row).Value.ToString()
                    Else
                        Impuesto_Porciento = "0"
                        SubTotal = CDbl(Dgv_Articulos("Precio", row).Value.ToString())
                        Impuesto_Monto = 0
                        CodigoTarifa = Dgv_Articulos("Cod_tarifa", row).Value.ToString()
                    End If
                End If


                'If Dgv_Articulos("SujetoAImpuesto", row).Value.ToString() = "True" Then
                '    Impuesto_Porciento = "13"
                '    SubTotal = CDbl(Cantidad) * CDbl(PrecioUnitario)
                '    Impuesto_Monto = (CDbl(SubTotal) * 13) / 100
                'Else
                '    Impuesto_Porciento = "0"
                '    SubTotal = CDbl(Cantidad) * CDbl(PrecioUnitario)
                '    Impuesto_Monto = 0
                'End If
                Total = CDbl(SubTotal) + CDbl(Impuesto_Monto)

                Class_VariablesGlobales.Obj_Funciones_SQL.GuardarCE_FE1_temp(Class_VariablesGlobales.frmFacturacion.txtb_Consecutivo.Text, DocType, NumLinea, ItemCode, ItemName, Pack, UnidadMedida, Costo, PrecioUnitario, Utilidad_Porciento, Utilidad_Monto, Cantidad, Descuento_Porciento, Descuento_Monto, Impuesto_Porciento, Impuesto_Monto, SubTotal, Total, Descuento_Promo_Porciento, Descuento_Promo_Monto, Descuento_Interno_Porciento, Descuento_Interno_Monto, CodigoTarifa)
                'llama a funcion cargar lineas de la factura temporal
                Class_VariablesGlobales.frmFacturacion.ObtieneLineas(Class_VariablesGlobales.frmFacturacion.txtb_Consecutivo.Text)
                Class_VariablesGlobales.frmFacturacion.CalculaTotal()
            ElseIf Class_VariablesGlobales.ArticulosLlamadoDesde = "Devoluciones" Then




                Dim UltimaFila As Integer = CInt(Class_VariablesGlobales.frmDevoluciones.Dtg_Devoluciones(0, Class_VariablesGlobales.frmDevoluciones.Dtg_Devoluciones.RowCount - 2).Value.ToString())
                Dim IV As String
                Dim Mont_Imp As String
                Dim Sub_Total As String
                Dim Mont_Desc As String = 0

                Dim Imp As String
                'Obtiene el impuesto a aplicar
                'Dgv_Articulos(6, row).Value.ToString().Substring(3,Dgv_Articulos(6, row).Value.ToString().Length-3)

                If Dgv_Articulos("Tarifa", row).Value.ToString().Trim = "" Then
                    Imp = "0"
                    Sub_Total = CDbl(Dgv_Articulos("Precio", row).Value.ToString())
                    Mont_Imp = 0
                Else
                    If Dgv_Articulos("Tarifa", row).Value.ToString() <> "0" Then
                        IV = Dgv_Articulos("Tarifa", row).Value.ToString()
                        Sub_Total = CDbl(Dgv_Articulos("Precio", row).Value.ToString())
                        Mont_Imp = (Sub_Total * CInt(IV)) / 100
                    Else
                        Imp = "0"
                        Sub_Total = CDbl(Dgv_Articulos("Precio", row).Value.ToString())
                        Mont_Imp = 0
                    End If
                End If


                'If Dgv_Articulos(6, row).Value.ToString() = "Y" Then
                '    IV = "13"
                '    Sub_Total = CDbl(Dgv_Articulos(4, row).Value.ToString())
                '    Mont_Imp = (Sub_Total * 13) / 100
                'Else
                '    IV = "0"
                '    Sub_Total = CDbl(Dgv_Articulos(4, row).Value.ToString())
                '    Mont_Imp = 0
                'End If


                'If Dgv_Articulos(6, row).Value.ToString() = "N" Then
                '    Imp = "13"
                'Else
                '    Imp = "0"
                'End If
                'Agrega la linea a la devolucion en la Base de datos
                Class_VariablesGlobales.Obj_Funciones_SQL.AgregaLineaDevolucion(Class_VariablesGlobales.SQL_Comman2, Class_VariablesGlobales.frmDevoluciones.txtb_DocNum.Text.Trim, Dgv_Articulos("ItemCode", row).Value.ToString(), Dgv_Articulos("Descripcion", row).Value.ToString(), Dgv_Articulos("Precio", row).Value.ToString(), IV, Mont_Imp)
                Imp = Nothing
                'Agrega la linea a DataGridView
                Class_VariablesGlobales.frmDevoluciones.Dtg_Devoluciones.Rows.Insert(Class_VariablesGlobales.frmDevoluciones.Dtg_Devoluciones.RowCount - 1, UltimaFila + 1, Dgv_Articulos("ItemCode", row).Value.ToString(), Dgv_Articulos("Descripcion", row).Value.ToString(), Dgv_Articulos("Precio", row).Value.ToString(), "1", "0", "0", "0", 1 * CDbl(Dgv_Articulos("Precio", row).Value.ToString()), "01", IV, "0", Mont_Imp, Sub_Total, "0")

                Class_VariablesGlobales.frmDevoluciones.CalculaTotal()
            ElseIf Class_VariablesGlobales.ArticulosLlamadoDesde = "Stock_Manager" Then
                'carga los campos de la ventana Stock_Manager
                ',[InactivoDesde]
                ',[RazonInactivo]

                Class_VariablesGlobales.frmStock_Manager.txtb_ItemCode.Text = Dgv_Articulos("ItemCode", row).Value.ToString()
                Class_VariablesGlobales.frmStock_Manager.txtb_ItemCode.Enabled = False


                Class_VariablesGlobales.frmStock_Manager.txtb_Descripcion.Text = Dgv_Articulos("Descripcion", row).Value.ToString()
                Class_VariablesGlobales.frmStock_Manager.Txtb_NombreExtrangero.Text = Dgv_Articulos("NombreExtrangero", row).Value.ToString()
                Class_VariablesGlobales.frmStock_Manager.txtb_CodBarras.Text = Dgv_Articulos("CodBarras", row).Value.ToString()

                Class_VariablesGlobales.frmStock_Manager.BackupCodBarras = Class_VariablesGlobales.frmStock_Manager.txtb_CodBarras.Text

                Class_VariablesGlobales.frmStock_Manager.CBox_GrupoArticulo.Text = Dgv_Articulos("GrupoArticulo", row).Value.ToString()
                Class_VariablesGlobales.frmStock_Manager.Cbox_Ubicacion.Text = Dgv_Articulos("Ubicacion", row).Value.ToString()
                Class_VariablesGlobales.frmStock_Manager.Txtb_CodCabys.Text = Dgv_Articulos("CodCabys", row).Value.ToString()
                Class_VariablesGlobales.frmStock_Manager.txtb_CodProveedor.Text = Dgv_Articulos("CodProveedor", row).Value.ToString()

                Class_VariablesGlobales.frmStock_Manager.txtb_CodAlterno.Text = Dgv_Articulos("CodAlterno", row).Value.ToString()
                Class_VariablesGlobales.frmStock_Manager.CBox_Familia.Text = Dgv_Articulos("Familia", row).Value.ToString()
                Class_VariablesGlobales.frmStock_Manager.CBox_Categoria.Text = Dgv_Articulos("Categoria", row).Value.ToString()
                Class_VariablesGlobales.frmStock_Manager.CBox_Marca.Text = Dgv_Articulos("Marca", row).Value.ToString()

                Class_VariablesGlobales.frmStock_Manager.txtb_Largo.Text = Dgv_Articulos("Largo", row).Value.ToString()
                Class_VariablesGlobales.frmStock_Manager.txtb_Ancho.Text = Dgv_Articulos("Anchos", row).Value.ToString()
                Class_VariablesGlobales.frmStock_Manager.txtb_Volumen.Text = Dgv_Articulos("Volumen", row).Value.ToString()
                Class_VariablesGlobales.frmStock_Manager.txtb_UnidMedida.Text = Dgv_Articulos("UnidMedida", row).Value.ToString()

                Class_VariablesGlobales.frmStock_Manager.txtb_Comentarios.Text = Dgv_Articulos("Comentarios", row).Value.ToString()
                Class_VariablesGlobales.frmStock_Manager.txtb_Empaque.Text = Dgv_Articulos("Empaque", row).Value.ToString()
                Class_VariablesGlobales.frmStock_Manager.txtb_PrecioCosto.Text = Dgv_Articulos("Precio", row).Value.ToString()
                Class_VariablesGlobales.frmStock_Manager.CBox_ListPrecio.Text = Dgv_Articulos("ListPreci", row).Value.ToString()
                Class_VariablesGlobales.frmStock_Manager.CBox_TipoProducto.Text = Dgv_Articulos("TipoProducto", row).Value.ToString()
                Class_VariablesGlobales.frmStock_Manager.txtb_imp.Text = Dgv_Articulos("Tarifa", row).Value.ToString()
                Class_VariablesGlobales.frmStock_Manager.Txtb_IdArticulo.Text = Dgv_Articulos("Id", row).Value.ToString()

                Dim tablaFotos As DataTable = Class_VariablesGlobales.frmStock_Manager.ObtieneFotos("")

                'Carga combobox con el id de todas las fotos del articulos

                Class_VariablesGlobales.frmStock_Manager.CBox_IDFotos.DataSource = Nothing
                If tablaFotos.Rows.Count > 0 Then
                    Class_VariablesGlobales.frmStock_Manager.CBox_IDFotos.DataSource = tablaFotos
                    Class_VariablesGlobales.frmStock_Manager.CBox_IDFotos.ValueMember = "Id"
                    Class_VariablesGlobales.frmStock_Manager.CBox_IDFotos.DisplayMember = "Id"

                Else
                    'Class_VariablesGlobales.frmStock_Manager.pictureBox1.Image = Nothing
                End If

                If Dgv_Articulos("CreadoEnSap", row).Value.ToString() = 1 Then
                    Class_VariablesGlobales.frmStock_Manager.btn_CrearEnSAP.Visible = False
                End If



                If Dgv_Articulos("Cod_Tarifa", row).Value.ToString() = "01" Then
                    Class_VariablesGlobales.frmStock_Manager.ComBox_CodTarifa.SelectedIndex = 0
                ElseIf Dgv_Articulos("Cod_Tarifa", row).Value.ToString() = "02" Then
                    Class_VariablesGlobales.frmStock_Manager.ComBox_CodTarifa.SelectedIndex = 1
                ElseIf Dgv_Articulos("Cod_Tarifa", row).Value.ToString() = "03" Then
                    Class_VariablesGlobales.frmStock_Manager.ComBox_CodTarifa.SelectedIndex = 2
                ElseIf Dgv_Articulos("Cod_Tarifa", row).Value.ToString() = "04" Then
                    Class_VariablesGlobales.frmStock_Manager.ComBox_CodTarifa.SelectedIndex = 3
                ElseIf Dgv_Articulos("Cod_Tarifa", row).Value.ToString() = "05" Then
                    Class_VariablesGlobales.frmStock_Manager.ComBox_CodTarifa.SelectedIndex = 4
                ElseIf Dgv_Articulos("Cod_Tarifa", row).Value.ToString() = "06" Then
                    Class_VariablesGlobales.frmStock_Manager.ComBox_CodTarifa.SelectedIndex = 5
                ElseIf Dgv_Articulos("Cod_Tarifa", row).Value.ToString() = "07" Then
                    Class_VariablesGlobales.frmStock_Manager.ComBox_CodTarifa.SelectedIndex = 6
                ElseIf Dgv_Articulos("Cod_Tarifa", row).Value.ToString() = "08" Then
                    Class_VariablesGlobales.frmStock_Manager.ComBox_CodTarifa.SelectedIndex = 7
                End If


                Class_VariablesGlobales.frmStock_Manager.btn_Guardar.Text = "Modificar"
                If Dgv_Articulos("SujetoAImpuesto", row).Value.ToString() = "True" Then
                    Class_VariablesGlobales.frmStock_Manager.CkBox_SujetoAImpuesto.Checked = True

                Else
                    Class_VariablesGlobales.frmStock_Manager.CkBox_SujetoAImpuesto.Checked = False
                End If
            End If
            Me.Close()
        Catch ex As Exception
            MsgBox("Error al elegir la linea" & ex.Message, MsgBoxStyle.Critical,"ERRO")

        End Try
    End Sub

    Private Sub Dgv_Articulos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Articulos.CellClick

        'Try


        '    'detecta a cual columa se le dio click
        '    Dgv_Articulos.Columns(e.ColumnIndex).Selected = True
        '    ColumnaBusqueda = e.ColumnIndex
        '    txtb_Buscar.Text = ""
        '    If ColumnaBusqueda = 0 Then
        '        SendMessage(Me.txtb_Buscar.Handle, &H1501, 0, "Busca por codigo de articulo")
        '    End If
        '    If ColumnaBusqueda = 1 Then
        '        SendMessage(Me.txtb_Buscar.Handle, &H1501, 0, "Busca por descripcion de articulo")
        '    End If
        '    Me.txtb_Buscar.Focus()

        'Catch ex As Exception

        'End Try
    End Sub



    Private Sub txtb_Buscar_TextChanged(sender As Object, e As EventArgs) Handles txtb_Buscar.TextChanged
        If Class_VariablesGlobales.ArticulosLlamadoDesde = "Facturacion" Then
            Dgv_Articulos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneArticulosInternos(Class_VariablesGlobales.frmFacturacion.CBox_TipoProducto.Text, Class_VariablesGlobales.frmFacturacion.txtb_CodCliente.Text, Trim(txtb_Buscar.Text), Cbox_VerDesc.Checked, ColumnaBusqueda, Class_VariablesGlobales.SQL_Comman2)
        ElseIf Class_VariablesGlobales.ArticulosLlamadoDesde = "Stock_Manager" Then
            Dgv_Articulos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneArticulos("", txtb_Buscar.Text, Cbox_VerDesc.Checked, ColumnaBusqueda, Class_VariablesGlobales.SQL_Comman2)

        Else

            Dgv_Articulos.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneArticulos(Class_VariablesGlobales.frmDevoluciones.txtb_CodCliente.Text, txtb_Buscar.Text, Cbox_VerDesc.Checked, ColumnaBusqueda, Class_VariablesGlobales.SQL_Comman2)
        End If




        organizar()
    End Sub
End Class