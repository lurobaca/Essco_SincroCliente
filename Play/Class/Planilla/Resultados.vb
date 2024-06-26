Public Class Resultados

    Public Property IdPlanilla As String
    Public Property Mensajes As MensajesPasos
    Public Property ListaMensajesPasos As List(Of MensajesPasos)
    Public Property ListaMensajesSap As List(Of MensajesSap)

    Public Class MensajesPasos
        Public Property NumPaso As String
        Public Property Estado As String
        Public Property Descripcion As String
    End Class

    Public Class MensajesSap
        Public Property Estado As String
        Public Property MensajeDeSap As String
    End Class


End Class

