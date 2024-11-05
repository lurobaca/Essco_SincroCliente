Public Class DTO_ReciboDinero
    Public Class Encabezado
        Public Property CodCliente As String
        Public Property Fecha As String
        Public Property Impreso As Integer
        Public Property Estado As Integer
        Public Property Detalle As List(Of Detalle) ' Cambiado a una lista de Detalle
    End Class

    Public Class Detalle

        Public Property IdRecibosDeDineroDetalle As String
        Public Property Id_RecibosDeDinero As Integer
        Public Property NumeroDocumento As String
        Public Property TipoDocumento As String
        Public Property Abono As Decimal
        Public Property TotalDocumento As Decimal
        Public Property Saldo As Decimal
        Public Property MontoEfectivo As Decimal
        Public Property MontoCheque As Decimal
        Public Property MontoTranferencia As Decimal
        Public Property IdBancoCheque As Integer
        Public Property IdBancoTranferencia As Integer

    End Class
End Class
