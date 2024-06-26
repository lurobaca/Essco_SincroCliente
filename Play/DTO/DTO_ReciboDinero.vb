Public Class DTO_ReciboDinero

    Public Class ReciboDinero
        Public Property Encabezado As New DTO_ReciboDinero.EncabezadoRecibo()
        Public Property Detalle As New List(Of DTO_ReciboDinero.DetalleRecibo)()
    End Class

    Public Class EncabezadoRecibo
        Public Property DocNum As String
        Public Property CardCode As String
        Public Property Fecha As String
        Public Property SalesPersonCode As String
        Public Property CashSum As String
        Public Property CheckSum As String
        Public Property TransferSum As String
        Public Property Num_Tranferencia As String
        Public Property IdPlanilla As String
    End Class
    Public Class DetalleRecibo
        Public Property DocNum As String
        Public Property NumFac As String
        Public Property DocEntry As String
        Public Property SumApplied As String
        Public Property TransferSum As String
        Public Property CashSum As String
        Public Property CheckNumber As String
        Public Property CheckSum As String
        Public Property BankCodeCheque As String
        Public Property BankCodeTranferencia As String
        Public Property PostFechaCheque As String
    End Class

End Class
