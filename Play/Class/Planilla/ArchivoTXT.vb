
Imports System.IO
Imports SincroCliente.EstructuraTxTBanco

Public Class ArchivoTXT
    Public Shared Sub GenerarArchivo(transaccion As Transaccion, rutaArchivo As String)
        Using writer As New StreamWriter(rutaArchivo, False)

            ' Generar primera línea (encabezado)
            Dim encabezado As String = GenerarEncabezado(transaccion.Empresa, transaccion.Convenio)
            writer.WriteLine(encabezado)

            ' Generar segunda línea (detalle de la empresa)
            Dim detalleEmpresa As String = GenerarDetalleEmpresa(transaccion.Empresa, transaccion.Convenio)
            writer.WriteLine(detalleEmpresa)

            ' Generar movimientos
            For Each movimiento As Movimiento In transaccion.Movimientos
                Dim detalleMovimiento As String = GenerarDetalleMovimiento(movimiento, transaccion.Convenio)
                writer.WriteLine(detalleMovimiento)
            Next
        End Using
    End Sub

    Private Shared Function GenerarEncabezado(empresa As Empresa, convenio As Integer) As String
        Return String.Format("HD|{0}.{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}",
                             empresa.Cedula, convenio, empresa.FechaAplicacion, empresa.CuentaCliente,
                             empresa.Moneda, empresa.MontoDebito.ToString("F2"), empresa.TotalMovimientos,
                             empresa.TotalCreditos, empresa.TotalDebito)
    End Function

    Private Shared Function GenerarDetalleEmpresa(empresa As Empresa, convenio As Integer) As String
        Return String.Format("DA|{0}||||{1:F2}||||544||{2}|||||||||||{2}|||{3}|{4}.{5}.{6}||",
                             empresa.CuentaCliente, empresa.MontoDebito, empresa.Nombre,
                             empresa.Cedula, empresa.Cedula, convenio, empresa.Cedula)
    End Function

    Private Shared Function GenerarDetalleMovimiento(movimiento As Movimiento, convenio As Integer) As String
        Return String.Format("DA|{0}||||{1:F2}||||{2}||{3}|||||||{4}||||{3}|||{5}|{6}.{7}.{8}||",
                             movimiento.CuentaCliente, movimiento.Monto, movimiento.CodigoInvariable,
                             movimiento.Nombre, movimiento.Descripcion, movimiento.Cedula,
                             movimiento.Cedula, convenio, movimiento.CRRBillingCustomer)
    End Function

    Public Shared Function ObtenerMovimientosDesdeDataGridView(dgv As DataGridView) As List(Of Movimiento)
        Dim movimientos As New List(Of Movimiento)

        For Each row As DataGridViewRow In dgv.Rows
            If Not row.IsNewRow Then
                Dim movimiento As New Movimiento With {
                    .CuentaCliente = row.Cells("CuentaBancaria").Value.ToString(),
                    .Monto = Convert.ToDecimal(row.Cells("Salario_Final").Value),
                    .CodigoInvariable = "545",
                    .Nombre = row.Cells.Item("Nombre").Value().ToString(),
                    .Descripcion = Class_VariablesGlobales.frmPlanilla.TxtBox_DescripcionPlanilla.Text,
                    .Cedula = row.Cells.Item("Cedula").Value().ToString(),
                    .CRRBillingCustomer = Class_VariablesGlobales.frmPlanilla.Txt_CedJuridica.Text & "1" & row.Cells.Item("IdColaborador").Value().ToString()
                }
                movimientos.Add(movimiento)
            End If
        Next

        Return movimientos
    End Function
End Class
