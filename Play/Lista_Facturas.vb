Public Class Lista_Facturas
    Private Sub Lista_Facturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Class_VariablesGlobales.ComprobanteACrear = "Factura" Then
                DGV_Facturas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneComprobantes("FE")
            ElseIf Class_VariablesGlobales.ComprobanteACrear = "NotaDeCredito" Then
                DGV_Facturas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneComprobantes("NC")
            ElseIf Class_VariablesGlobales.ComprobanteACrear = "NotasDebito" Then
                DGV_Facturas.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneComprobantes("ND")
            End If



        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV_Facturas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Facturas.CellContentClick

        Try
            Class_VariablesGlobales.frmFacturacion.txtb_CodCliente.Text = DGV_Facturas.CurrentRow.Cells("CodCliente").Value.ToString
            Class_VariablesGlobales.frmFacturacion.txtb_Nombre.Text = DGV_Facturas.CurrentRow.Cells("Receptor_Nombre").Value.ToString
            Class_VariablesGlobales.frmFacturacion.txtb_NombreFantacia.Text = DGV_Facturas.CurrentRow.Cells("Receptor_NombreComercial").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.txtb_DocReferencia.Text = DGV_Facturas.CurrentRow.Cells("Referencia_Numero").Value.ToString
            Class_VariablesGlobales.frmFacturacion.txtb_DocReferencia.Text = DGV_Facturas.CurrentRow.Cells("NumeroPedido").Value.ToString

            ''--ESTOS DATOS SE OBTIENE AL SELECCIONAR EL CLIENTE
            Class_VariablesGlobales.frmFacturacion.Receptor_Nombre = DGV_Facturas.CurrentRow.Cells("Receptor_Nombre").Value.ToString
            Class_VariablesGlobales.frmFacturacion.Receptor_NombreComercial = DGV_Facturas.CurrentRow.Cells("Receptor_NombreComercial").Value.ToString
            Class_VariablesGlobales.frmFacturacion.Receptor_Tipo = DGV_Facturas.CurrentRow.Cells("Receptor_Tipo").Value.ToString
            Class_VariablesGlobales.frmFacturacion.Receptor_Numero = DGV_Facturas.CurrentRow.Cells("Receptor_Numero").Value.ToString
            Class_VariablesGlobales.frmFacturacion.Receptor_IdentificacionExtranjero = DGV_Facturas.CurrentRow.Cells("Receptor_IdentificacionExtranjero").Value.ToString
            Class_VariablesGlobales.frmFacturacion.Receptor_Provincia = DGV_Facturas.CurrentRow.Cells("Receptor_Provincia").Value.ToString
            Class_VariablesGlobales.frmFacturacion.Receptor_Canton = DGV_Facturas.CurrentRow.Cells("Receptor_Canton").Value.ToString
            Class_VariablesGlobales.frmFacturacion.Receptor_Distrito = DGV_Facturas.CurrentRow.Cells("Receptor_Distrito").Value.ToString
            Class_VariablesGlobales.frmFacturacion.Receptor_Barrio = DGV_Facturas.CurrentRow.Cells("Receptor_Barrio").Value.ToString
            Class_VariablesGlobales.frmFacturacion.Receptor_OtrasSenas = DGV_Facturas.CurrentRow.Cells("Receptor_OtrasSenas").Value.ToString
            Class_VariablesGlobales.frmFacturacion.Receptor_CorreoElectronico = DGV_Facturas.CurrentRow.Cells("Receptor_CorreoElectronico").Value.ToString

            If DGV_Facturas.CurrentRow.Cells("DocType").Value.ToString = "FES" Or DGV_Facturas.CurrentRow.Cells("DocType").Value.ToString = "NCS" Or DGV_Facturas.CurrentRow.Cells("DocType").Value.ToString = "NDS" Then
                Class_VariablesGlobales.frmFacturacion.CBox_TipoProducto.Text = "Servicio"
            Else
                Class_VariablesGlobales.frmFacturacion.CBox_TipoProducto.Text = "Articulo"
            End If

            Class_VariablesGlobales.frmFacturacion.CBox_TipoVenta.Text = DGV_Facturas.CurrentRow.Cells("CondicionVenta").Value.ToString
            Class_VariablesGlobales.frmFacturacion.Txtb_plazoCredito.Text = DGV_Facturas.CurrentRow.Cells("PlazoCredito").Value.ToString

            Class_VariablesGlobales.frmFacturacion.txtb_Impreso.Text = DGV_Facturas.CurrentRow.Cells("Printed").Value.ToString
            Class_VariablesGlobales.frmFacturacion.CBox_Estado.Text = DGV_Facturas.CurrentRow.Cells("Status").Value.ToString
            Class_VariablesGlobales.frmFacturacion.txtb_Consecutivo.Text = DGV_Facturas.CurrentRow.Cells("Consecutivo").Value.ToString
            Class_VariablesGlobales.frmFacturacion.Txtb_DocNum.Text = DGV_Facturas.CurrentRow.Cells("DocNum").Value.ToString
            Class_VariablesGlobales.frmFacturacion.txtb_clave.Text = DGV_Facturas.CurrentRow.Cells("Clave").Value.ToString

            'Class_VariablesGlobales.frmFacturacion.DTP_TransaccionDesde.Text = DGV_Facturas.CurrentRow.Cells("Emisor_Numero").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.DTP_TransaccionHasta.Text = DGV_Facturas.CurrentRow.Cells("Emisor_Provincia").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.CBox_Vendedor.Text = DGV_Facturas.CurrentRow.Cells("Emisor_Canton").Value.ToString
            Class_VariablesGlobales.frmFacturacion.txtb_Comentarios.Text = DGV_Facturas.CurrentRow.Cells("Comments").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.txtb_TotalGravado.Text = DGV_Facturas.CurrentRow.Cells("Emisor_Barrio").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.txtb_TotalExento.Text = DGV_Facturas.CurrentRow.Cells("Emisor_OtrasSenas").Value.ToString
            Class_VariablesGlobales.frmFacturacion.txtb_SubTotal.Text = DGV_Facturas.CurrentRow.Cells("DocSubTotal").Value.ToString
            Class_VariablesGlobales.frmFacturacion.txtb_TotalImpuesto.Text = DGV_Facturas.CurrentRow.Cells("DocTotalImpuesto").Value.ToString
            Class_VariablesGlobales.frmFacturacion.txtb_TotalDescuento.Text = DGV_Facturas.CurrentRow.Cells("DocTotalDescuento").Value.ToString
            Class_VariablesGlobales.frmFacturacion.txtb_TotalDocumento.Text = DGV_Facturas.CurrentRow.Cells("DocTotal").Value.ToString
            Class_VariablesGlobales.frmFacturacion.txtb_TotalSaldo.Text = DGV_Facturas.CurrentRow.Cells("DocSaldo").Value.ToString


            'llamar a una  funcio que obtengan la lista de lineas
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.DataSource = Class_VariablesGlobales.Obj_Funciones_SQL.ObtieneLineasFacturas(Class_VariablesGlobales.frmFacturacion.Txtb_DocNum.Text, DGV_Facturas.CurrentRow.Cells("DocType").Value.ToString)
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.ReadOnly = True

            Class_VariablesGlobales.frmFacturacion.CalculaTotal()
            ' Ordenamos ascendentemente el contenido de la columna.
            '
            'Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.SortedColumn.SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(8).SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(9).SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(11).SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(12).SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(13).SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(14).SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(15).SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(16).SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(17).SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(18).SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(19).SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(20).SortMode = DataGridViewColumnSortMode.NotSortable
            Class_VariablesGlobales.frmFacturacion.DGV_DetalleFactura.Columns(21).SortMode = DataGridViewColumnSortMode.NotSortable



            Class_VariablesGlobales.frmFacturacion.Guardada = True

            'Class_VariablesGlobales.frmFacturacion.txtb_clave.Text = DGV_Facturas.CurrentRow.Cells("Receptor_IdentificacionExtranjero").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.txtb_clave.Text = DGV_Facturas.CurrentRow.Cells("CondicionVenta").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.txtb_clave.Text = DGV_Facturas.CurrentRow.Cells("PlazoCredito").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.txtb_clave.Text = DGV_Facturas.CurrentRow.Cells("MedioPago").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.txtb_clave.Text = DGV_Facturas.CurrentRow.Cells("Referencia_Numero").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.txtb_clave.Text = DGV_Facturas.CurrentRow.Cells("Referencia_TipoDoc").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.txtb_clave.Text = DGV_Facturas.CurrentRow.Cells("Referencia_FechaEmision").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.txtb_clave.Text = DGV_Facturas.CurrentRow.Cells("Referencia_Codigo").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.txtb_clave.Text = DGV_Facturas.CurrentRow.Cells("Referencia_Razon").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.txtb_clave.Text = DGV_Facturas.CurrentRow.Cells("DocTotal").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.txtb_clave.Text = DGV_Facturas.CurrentRow.Cells("DocSubTotal").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.txtb_clave.Text = DGV_Facturas.CurrentRow.Cells("DocTotalImpuesto").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.txtb_clave.Text = DGV_Facturas.CurrentRow.Cells("DocTotalDescuento").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.txtb_clave.Text = DGV_Facturas.CurrentRow.Cells("DocSaldo").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.txtb_clave.Text = DGV_Facturas.CurrentRow.Cells("Comments").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.txtb_clave.Text = DGV_Facturas.CurrentRow.Cells("MH_Status").Value.ToString
            'Class_VariablesGlobales.frmFacturacion.txtb_clave.Text = DGV_Facturas.CurrentRow.Cells("MH_Message").Value.ToString
            Class_VariablesGlobales.frmFacturacion.Inabilitar()
            If DGV_Facturas.CurrentRow.Cells("Anulado").Value.ToString = "1" Then
                Class_VariablesGlobales.frmFacturacion.btn_Anular.Enabled = False
                Class_VariablesGlobales.frmFacturacion.lbl_Anulada.Visible = True
            Else
                Class_VariablesGlobales.frmFacturacion.btn_Anular.Enabled = True
                Class_VariablesGlobales.frmFacturacion.lbl_Anulada.Visible = False
            End If


            Me.Close()

        Catch ex As Exception

        End Try
    End Sub
End Class