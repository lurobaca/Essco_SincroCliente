Imports System.IO

Public Class Stock_Manager

    Public Org As PictureBox
    Public BackupCodBarras As String 'Reslpada el codigo de barras para que en caso de que sea modificado se haga la actualizacion en la tabla de fotos y asi mantener la relacion de codigo foto

    Private Sub Stock_Manager_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        lbl_LineaNueva.Text = "SI"
        'ESTO CONTROLA SI EL MODULO SE ESTA USANDO PARA CREAR UNA LINEA NUEVA DEL WMS 
        If lbl_LineaNueva.Text = "SI" Then



            'se repite ya que al eliminar 1 se cambia los indez de los taps
            TabControl1.Controls.Remove(TabControl1.TabPages(1))
            TabControl1.Controls.Remove(TabControl1.TabPages(1))
            TabControl1.Controls.Remove(TabControl1.TabPages(1))

            'this.DoubleBuffered = True 'minimizes the strutter
            Org = New PictureBox()
            Org.Image = pictureBox1.Image




            Dim tablaFotos As DataTable = ObtieneFotos("")

            If tablaFotos.Rows.Count > 0 Then

                'Carga combobox con el id de todas las fotos del articulos
                CBox_IDFotos.DataSource = tablaFotos
                CBox_IDFotos.ValueMember = "Id"
                CBox_IDFotos.DisplayMember = "Id"
            End If




            'btn_Familia.Visible = False
            'btn_Categoria.Visible = False
            'btn_Marca.Visible = False
            'RBtn_Activo.Visible = False
            'RBtn_Inactivo.Visible = False
            'lbl_Desde.Visible = False
            'txtb_InactivoDesde.Visible = False
            'lbl_Razon.Visible = False
            'txtb_RazonInactivo.Visible = False
            'lbl_ListaPrecios.Visible = False
            'CBox_ListPrecio.Visible = False
            'CBox_TipoProducto.Visible = False
            'lblTipo.Visible = False

            'btn_Familia.Visible = False
            'btn_Categoria.Visible = False
            'btn_Marca.Visible = False
            'txtb_Ancho.Visible = False
            'txtb_Largo.Visible = False
            'txtb_Volumen.Visible = False

            'lbl_Ancho.Visible = False
            'Lbl_Largo.Visible = False
            'Lbl_Volumen.Visible = False


            trackBar1.Value = 100
            trackBar1.Minimum = 10
            trackBar1.Maximum = 200
            trackBar1.SmallChange = 10
            trackBar1.LargeChange = 10
            trackBar1.UseWaitCursor = False




            'valida que tenga un servidor de SAP 
            If Class_VariablesGlobales.XMLParamSAP_CompanyDB <> "" Then
                ObtieneDatosItemGroups()
                ObtieneDatosSectores()
                ObtieneDatosClasificacionSAP()
                btn_CrearEnSAP.Enabled = True
            End If

        Else
            'INDICA QUE CREARA UNA LINEA NUEVA PERO DEL SISTEMA INTERNO PARA EL MODULO DE FACTURACION DE SINCRO CLIENTE
            ObtieneDatosClasificacionINTERNA()


            CBox_GrupoArticulo.Enabled = False
            Cbox_Ubicacion.Enabled = False
        End If



        'With CBox_Familia
        '    .ValueMember = "Id"
        '    .DataSource = VariablesGlobales.Obj_SQL.ObtieneCategorizaciones(Class_VariablesGlobales.SQL_Comman2, "Familia", True)
        '    .DisplayMember = "Familia"
        'End With

        'With CBox_Categoria
        '    CBox_Categoria.ValueMember = "Id"
        '    .DataSource = VariablesGlobales.Obj_SQL.ObtieneCategorizaciones(Class_VariablesGlobales.SQL_Comman2, "Categoria", True)
        '    .DisplayMember = "Categoria"
        'End With

        'With CBox_Marca
        '    CBox_Marca.ValueMember = "Id"
        '    .DataSource = VariablesGlobales.Obj_SQL.ObtieneCategorizaciones(Class_VariablesGlobales.SQL_Comman2, "Marca", True)
        '    .DisplayMember = "Marca"
        'End With


    End Sub
    Public Function ObtieneFotos(Id As String)


        Dim tabla As New DataTable

        Try


            tabla = VariablesGlobales.Obj_SQL.ObtieneItemFotos(Class_VariablesGlobales.SQL_Comman2, txtb_CodBarras.Text, Id)

            Dim cont As Integer = 0
            Dim newImage As Image = Nothing

            If tabla.Rows.Count > 0 Then
                For Each row As DataRow In tabla.Rows




                    Dim imgData As Byte() = CType(tabla.Rows(cont).Item("Imagen"), Byte())
                    Using ms As MemoryStream = New MemoryStream(imgData, 0, imgData.Length)
                        ms.Write(imgData, 0, imgData.Length)
                        newImage = Image.FromStream(ms, True)
                    End Using
                    pictureBox1.Image = newImage
                    Org.Image = newImage
                    newImage = Nothing




                Next
            End If
            newImage = Nothing


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

        Return tabla
    End Function
    Private Function ObtieneDatosItemGroups()

        Try


            Dim tabla As New DataTable
            tabla = VariablesGlobales.Obj_SQL.ObtieneItemGroupSAP(Class_VariablesGlobales.SQL_Comman2)
            CBox_GrupoArticulo.DataSource = tabla
            CBox_GrupoArticulo.ValueMember = "ItmsGrpCod"
            CBox_GrupoArticulo.DisplayMember = "ItmsGrpNam"


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function ObtieneDatosSectores()

        Try



            Dim tabla As New DataTable
            tabla = VariablesGlobales.Obj_SQL.ObtieneSectoresSAP(Class_VariablesGlobales.SQL_Comman2)
            Cbox_Ubicacion.DataSource = tabla
            Cbox_Ubicacion.ValueMember = "Code"
            Cbox_Ubicacion.DisplayMember = "Name"

        Catch ex As Exception

        End Try
    End Function
    Private Function ObtieneDatosClasificacionSAP()

        Dim cont As Integer
        Dim tabla As New DataTable
        tabla = VariablesGlobales.Obj_SQL.ObtieneCategorizacionesSAP(Class_VariablesGlobales.SQL_Comman2, "Familia")
        If tabla.Rows.Count > 0 Then
            CBox_Familia.DataSource = tabla
            CBox_Familia.ValueMember = "Code"
            CBox_Familia.DisplayMember = "Name"
        End If
        cont = Nothing
        tabla = Nothing

        cont = 0
        tabla = VariablesGlobales.Obj_SQL.ObtieneCategorizacionesSAP(Class_VariablesGlobales.SQL_Comman2, "Categoria")

        If tabla.Rows.Count > 0 Then
            CBox_Categoria.DataSource = tabla
            CBox_Categoria.ValueMember = "Code"
            CBox_Categoria.DisplayMember = "Name"
        End If

        cont = 0
        tabla = Nothing

        tabla = VariablesGlobales.Obj_SQL.ObtieneCategorizacionesSAP(Class_VariablesGlobales.SQL_Comman2, "Marca")
        If tabla.Rows.Count > 0 Then
            CBox_Marca.DataSource = tabla
            CBox_Marca.ValueMember = "Code"
            CBox_Marca.DisplayMember = "Name"
        End If

        cont = Nothing
        tabla = Nothing
    End Function
    Private Function ObtieneDatosClasificacionINTERNA()
        Dim cont As Integer
        Dim tabla As New DataTable
        tabla = VariablesGlobales.Obj_SQL.ObtieneCategorizaciones(Class_VariablesGlobales.SQL_Comman2, "Familia", True)
        For Each row As DataRow In tabla.Rows
            CBox_Familia.Items.Add(tabla.Rows(cont).Item("Nombre").ToString())
            cont += 1
        Next
        cont = Nothing
        tabla = Nothing

        cont = 0
        tabla = VariablesGlobales.Obj_SQL.ObtieneCategorizaciones(Class_VariablesGlobales.SQL_Comman2, "Categoria", True)
        For Each row As DataRow In tabla.Rows
            CBox_Categoria.Items.Add(tabla.Rows(cont).Item("Nombre").ToString())
            cont += 1
        Next
        cont = 0
        tabla = Nothing

        tabla = VariablesGlobales.Obj_SQL.ObtieneCategorizaciones(Class_VariablesGlobales.SQL_Comman2, "Marca", True)
        For Each row As DataRow In tabla.Rows
            CBox_Marca.Items.Add(tabla.Rows(cont).Item("Nombre").ToString())
            cont += 1
        Next
        cont = Nothing
        tabla = Nothing
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        If btn_Guardar.Text = "Guardar" Then
            Guardar()
        ElseIf btn_Guardar.Text = "Modificar" Then
            Modificar()
        End If
    End Sub

    Public Function Guardar()



        VariablesGlobales.Obj_SQL.GuardarArticulo(Class_VariablesGlobales.SQL_Comman2, txtb_ItemCode.Text _
        , txtb_Descripcion.Text _
        , Txtb_NombreExtrangero.Text _
        , CBox_GrupoArticulo.Text _
        , Cbox_Ubicacion.Text _
        , Txtb_CodCabys.Text _
        , txtb_CodBarras.Text _
        , txtb_CodAlterno.Text _
        , txtb_CodProveedor.Text _
        , txtb_Comentarios.Text _
        , txtb_Empaque.Text _
        , txtb_InactivoDesde.Text _
        , txtb_PrecioCosto.Text _
        , txtb_RazonInactivo.Text _
        , txtb_UnidMedida.Text _
        , txtb_Largo.Text _
        , txtb_Ancho.Text _
        , txtb_Volumen.Text _
        , CkBox_SujetoAImpuesto.Checked _
        , CBox_TipoProducto.Text _
        , CBox_ListPrecio.Text _
        , CBox_Familia.Text _
        , CBox_Categoria.Text _
        , CBox_Marca.Text _
        , txtb_imp.Text _
        , ComBox_CodTarifa.Text.Substring(0, 2) _
        , txtb_PartidaArancelaria.Text _
        , Txtb_IdArticuloNuevo.Text _
        , Txtb_IdArticulo.Text _
        , Txt_PorcUtilidad.Text _
        , Txtb_PrecioVenta.Text _
          , CBox_Moneda.Text _
        , True)


        CambiaEstadoLineaNueva()
        Limpiar()
        MessageBox.Show("Articulo fue guardado con exito ")
    End Function


    Public Function Modificar()
        Try



            VariablesGlobales.Obj_SQL.GuardarArticulo(Class_VariablesGlobales.SQL_Comman2, txtb_ItemCode.Text _
        , txtb_Descripcion.Text _
        , Txtb_NombreExtrangero.Text _
        , CBox_GrupoArticulo.Text _
        , Cbox_Ubicacion.Text _
        , Txtb_CodCabys.Text _
        , txtb_CodBarras.Text _
        , txtb_CodAlterno.Text _
        , txtb_CodProveedor.Text _
        , txtb_Comentarios.Text _
        , txtb_Empaque.Text _
        , txtb_InactivoDesde.Text _
        , txtb_PrecioCosto.Text _
        , txtb_RazonInactivo.Text _
        , txtb_UnidMedida.Text _
        , txtb_Largo.Text _
        , txtb_Ancho.Text _
        , txtb_Volumen.Text _
        , CkBox_SujetoAImpuesto.Checked _
        , CBox_TipoProducto.Text _
        , CBox_ListPrecio.Text _
        , CBox_Familia.Text _
        , CBox_Categoria.Text _
        , CBox_Marca.Text, txtb_imp.Text _
        , ComBox_CodTarifa.Text.Substring(0, 2) _
        , txtb_PartidaArancelaria.Text _
        , Txtb_IdArticuloNuevo.Text _
        , Txtb_IdArticulo.Text _
        , Txt_PorcUtilidad.Text _
        , Txtb_PrecioVenta.Text _
        , CBox_Moneda.Text _
        , False)


            'Verifica si el codigo de barras fue modificado
            If BackupCodBarras <> txtb_CodBarras.Text Then
                'Actualiza el codigo de barras en la tabla que almacena las fotos para mantener la relacion de codigobarras fotos
                VariablesGlobales.Obj_SQL.ActualizaCodBarrasFotos(Class_VariablesGlobales.SQL_Comman2, BackupCodBarras, txtb_CodBarras.Text)
            End If
            Limpiar()

            MessageBox.Show("Articulo fue guardado con exito ")
        Catch ex As Exception
            MessageBox.Show("Error en Modificar" & ex.Message)
        End Try
    End Function

    Public Function Limpiar()
        txtb_ItemCode.Text = ""
        txtb_Descripcion.Text = ""
        Txtb_NombreExtrangero.Text = ""
        Txtb_CodCabys.Text = ""
        txtb_CodBarras.Text = ""
        txtb_Empaque.Text = ""
        txtb_Ancho.Text = "0"
        txtb_CodAlterno.Text = ""
        txtb_CodProveedor.Text = ""
        txtb_Comentarios.Text = ""
        txtb_Empaque.Text = "1"
        txtb_InactivoDesde.Text = ""
        txtb_Largo.Text = "0"
        txtb_PrecioCosto.Text = ""
        txtb_RazonInactivo.Text = ""
        txtb_UnidMedida.Text = ""
        txtb_Volumen.Text = "0"
        txtb_imp.Text = "0"
        Txtb_Gramos.Text = "0"
        ComBox_CodTarifa.Text = ""
        CkBox_SujetoAImpuesto.Checked = False
        CBox_TipoProducto.Text = ""
        CBox_ListPrecio.Text = ""
        CBox_Familia.Text = ""
        CBox_Categoria.Text = ""
        CBox_Marca.Text = ""
        CBox_CodBodega.Text = ""
        CBox_ListPrecio.Text = ""
        CBox_TipoProducto.Text = ""
        CBox_Transaccion.Text = ""
        CBox_GrupoArticulo.Text = ""
        Cbox_Ubicacion.Text = ""
        btn_Guardar.Text = "Guardar"
        txtb_PartidaArancelaria.Text = ""
        Txtb_IdArticuloNuevo.Text = ""

        CBox_IDFotos.DataSource = Nothing
        pictureBox1.Image = Nothing

    End Function

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btn_Familia.Click
        Class_VariablesGlobales.frmStock_Categorizaciones = New Stock_Categorizaciones
        Class_VariablesGlobales.frmStock_Categorizaciones.MdiParent = Principal
        Class_VariablesGlobales.frmStock_Categorizaciones.Text = "Administra Familias"
        Class_VariablesGlobales.frmStock_Categorizaciones.CBox_Categorizaciones.Text = "Familia"
        Class_VariablesGlobales.frmStock_Categorizaciones.DGV_ListaCategorizaciones.DataSource = VariablesGlobales.Obj_SQL.ObtieneCategorizaciones(Class_VariablesGlobales.SQL_Comman2, "Familia", False)
        Class_VariablesGlobales.frmStock_Categorizaciones.Show()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_Categoria.Click
        Class_VariablesGlobales.frmStock_Categorizaciones = New Stock_Categorizaciones
        Class_VariablesGlobales.frmStock_Categorizaciones.MdiParent = Principal
        Class_VariablesGlobales.frmStock_Categorizaciones.Text = "Administra Categorias"
        Class_VariablesGlobales.frmStock_Categorizaciones.CBox_Categorizaciones.Text = "Categoria"
        Class_VariablesGlobales.frmStock_Categorizaciones.DGV_ListaCategorizaciones.DataSource = VariablesGlobales.Obj_SQL.ObtieneCategorizaciones(Class_VariablesGlobales.SQL_Comman2, "Categoria", False)
        Class_VariablesGlobales.frmStock_Categorizaciones.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btn_Marca.Click
        Class_VariablesGlobales.frmStock_Categorizaciones = New Stock_Categorizaciones
        Class_VariablesGlobales.frmStock_Categorizaciones.MdiParent = Principal
        Class_VariablesGlobales.frmStock_Categorizaciones.Text = "Administra Marcas"
        Class_VariablesGlobales.frmStock_Categorizaciones.CBox_Categorizaciones.Text = "Marca"
        Class_VariablesGlobales.frmStock_Categorizaciones.DGV_ListaCategorizaciones.DataSource = VariablesGlobales.Obj_SQL.ObtieneCategorizaciones(Class_VariablesGlobales.SQL_Comman2, "Marca", False)
        Class_VariablesGlobales.frmStock_Categorizaciones.Show()
    End Sub

    Private Sub btn_BuscaProveedores_Click(sender As Object, e As EventArgs) Handles btn_BuscaProveedores.Click
        Class_VariablesGlobales.LlamadoDesde = "StockManager"
        Lista_Proveedores.Show()
    End Sub



    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        Class_VariablesGlobales.frmArticulos = New Articulos
        Class_VariablesGlobales.frmArticulos.Busca = "Interno"
        Class_VariablesGlobales.ArticulosLlamadoDesde = "Stock_Manager"
        Class_VariablesGlobales.frmArticulos.MdiParent = Principal
        Class_VariablesGlobales.frmArticulos.Show()
    End Sub

    Private Sub CkBox_SujetoAImpuesto_CheckedChanged(sender As Object, e As EventArgs) Handles CkBox_SujetoAImpuesto.CheckedChanged
        If CkBox_SujetoAImpuesto.Checked = True Then
            txtb_imp.Enabled = True
            ComBox_CodTarifa.Enabled = True
        Else
            txtb_imp.Text = ""
            txtb_imp.Enabled = False
            ComBox_CodTarifa.Text = ""

            ComBox_CodTarifa.Enabled = False
        End If
    End Sub

    Private Sub ComBox_CodTarifa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComBox_CodTarifa.SelectedIndexChanged
        If ComBox_CodTarifa.Text.Substring(0, 2) = "01" Then
            txtb_imp.Text = 0


        ElseIf ComBox_CodTarifa.Text.Substring(0, 2) = "02" Then
            txtb_imp.Text = 1
        ElseIf ComBox_CodTarifa.Text.Substring(0, 2) = "03" Then
            txtb_imp.Text = 2
        ElseIf ComBox_CodTarifa.Text.Substring(0, 2) = "04" Then
            txtb_imp.Text = 4
        ElseIf ComBox_CodTarifa.Text.Substring(0, 2) = "05" Then
            txtb_imp.Text = 0
        ElseIf ComBox_CodTarifa.Text.Substring(0, 2) = "06" Then
            txtb_imp.Text = 4
        ElseIf ComBox_CodTarifa.Text.Substring(0, 2) = "07" Then
            txtb_imp.Text = 8
        ElseIf ComBox_CodTarifa.Text.Substring(0, 2) = "08" Then
            txtb_imp.Text = 13
        End If
    End Sub

    Private Sub btn_CrearEnSAP_Click(sender As Object, e As EventArgs) Handles btn_CrearEnSAP.Click
        Dim SujetoAImpuesto As Integer

        If CkBox_SujetoAImpuesto.Checked = True Then
            SujetoAImpuesto = 1
        Else
            SujetoAImpuesto = 0
        End If

        Dim Impuesto As String
        If txtb_imp.Text = 0 Then
            Impuesto = "IVAT0"
        ElseIf txtb_imp.Text = 1 Then
            Impuesto = "IVA1"
        ElseIf txtb_imp.Text = 2 Then
            Impuesto = "IVA2"
        ElseIf txtb_imp.Text = 4 Then
            Impuesto = "IVA4"
        ElseIf txtb_imp.Text = 8 Then
            Impuesto = "IVA8"
        ElseIf txtb_imp.Text = 13 Then
            Impuesto = "IVA13"
        End If

        Dim obj_SAP As New SAP_BUSSINES_ONE
        obj_SAP.CreaArticulo(txtb_ItemCode.Text, txtb_Descripcion.Text, txtb_CodProveedor.Text, txtb_Empaque.Text, txtb_CodBarras.Text, CBox_Familia.Text, CBox_Categoria.Text, CBox_Marca.Text, Txtb_NombreExtrangero.Text, CBox_GrupoArticulo.SelectedValue, Cbox_Ubicacion.Text, txtb_CodAlterno.Text, txtb_UnidMedida.Text, Impuesto, SujetoAImpuesto)


        VariablesGlobales.Obj_SQL.CambiaEstadoArticulo(Class_VariablesGlobales.SQL_Comman2, Txtb_IdArticuloNuevo.Text)
    End Sub



    Private Sub trackBar1_Scroll(sender As Object, e As EventArgs) Handles trackBar1.Scroll
        If trackBar1.Value <> 0 Then

            pictureBox1.Image = Nothing

            pictureBox1.Image = ZoomPicture(Org.Image, New Size(trackBar1.Value, trackBar1.Value))
        End If


    End Sub

    Private Function ZoomPicture(ByVal img As Image, ByVal size As Size) As Image
        txtb_zooFactor.Text = Convert.ToString(size.Height)
        Txtb_Height.Text = Convert.ToString((img.Height * size.Height) / 100)
        Txtb_Width.Text = Convert.ToString((img.Width * size.Width) / 100)
        Dim bm As Bitmap = New Bitmap(img, Convert.ToInt32((img.Width * size.Width) / 100), Convert.ToInt32((img.Height * size.Height) / 100))
        Dim gpu As Graphics = Graphics.FromImage(bm)
        gpu.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        Return bm
    End Function


    Private Function CambiaEstadoLineaNueva()
        VariablesGlobales.Obj_SQL.CambiaEstadoLineaNueva(Class_VariablesGlobales.SQL_Comman2, Txtb_IdArticuloNuevo.Text)
    End Function

    Private Sub CBox_IDFotos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBox_IDFotos.SelectedIndexChanged


        trackBar1.Value = 100
        trackBar1.Minimum = 10
        trackBar1.Maximum = 200
        trackBar1.SmallChange = 10
        trackBar1.LargeChange = 10
        trackBar1.UseWaitCursor = False
        ObtieneFotos(CBox_IDFotos.Text)
    End Sub

    Private Sub btn_EliminarFoto_Click(sender As Object, e As EventArgs) Handles btn_EliminarFoto.Click
        Dim result As DialogResult = MessageBox.Show("Si elimina esta foto no podra ser recuperada, Esta seguro que desea eliminar esta foto?",
                              "Alerta",
                              MessageBoxButtons.YesNo)

        If (result = DialogResult.Yes) Then
            VariablesGlobales.Obj_SQL.EliminaFoto(Class_VariablesGlobales.SQL_Comman2, CBox_IDFotos.Text)

            Dim tablaFotos As DataTable = ObtieneFotos("")
            'Carga combobox con el id de todas las fotos del articulos

            CBox_IDFotos.DataSource = Nothing
            If tablaFotos.Rows.Count > 0 Then
                CBox_IDFotos.DataSource = tablaFotos
                CBox_IDFotos.ValueMember = "Id"
                CBox_IDFotos.DisplayMember = "Id"

            Else
                pictureBox1.Image = Nothing
            End If

        Else
        End If
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Limpiar()

    End Sub

    Private Sub Txt_PorcUtilidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_PorcUtilidad.KeyPress

        If txtb_PrecioCosto.Text <> "" And Txt_PorcUtilidad.Text <> "" Then
            Txtb_PrecioVenta.Text = CDbl(txtb_PrecioCosto.Text) + (CDbl(Txt_PorcUtilidad.Text) * CDbl(txtb_PrecioCosto.Text)) / 100

        End If


    End Sub
End Class