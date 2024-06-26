Public Class DTO_Asientos
    Public Class Asiento
        Public Property Reference As String
        'Public Property Detalle As New List(Of DTO_Asientos.DetalleAsiento)()
        Public Property Detalle As New DataTable
    End Class

    Public Class DetalleAsiento
        Public Property AccountCode As String
        Public Property Credit As Decimal
        Public Property Debit As Decimal
    End Class
End Class
