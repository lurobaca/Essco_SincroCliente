Public Class EstructuraTxTBanco
    Public Structure Empresa
        Public Cedula As String
        Public FechaAplicacion As String
        Public CuentaCliente As String
        Public Moneda As String
        Public MontoDebito As Decimal
        Public TotalMovimientos As Integer
        Public TotalCreditos As Integer
        Public TotalDebito As Integer
        Public Nombre As String
    End Structure

    Public Structure Movimiento
        Public CuentaCliente As String
        Public Monto As Decimal
        Public CodigoInvariable As String
        Public Nombre As String
        Public Descripcion As String
        Public Cedula As String
        Public CRRBillingCustomer As String
    End Structure

    Public Structure Transaccion
        Public Empresa As Empresa
        Public Movimientos As List(Of Movimiento)
        Public Convenio As Integer
    End Structure

End Class
