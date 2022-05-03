Imports Newtonsoft.Json
Imports System

Public Class ClasesJson
End Class

Public Class RespuestaHacienda2
    <JsonProperty("Clave")>
    Public Property Clave As String

    <JsonProperty("X-Http-Status")>
    Public Property X_Http_Status As String

    <JsonProperty("X-Error-Cause")>
    Public Property X_Error_Cause As String
End Class

Public Class RespuestaHacienda
    <JsonProperty("clave")>
    Public Property clave As String

    <JsonProperty("fecha")>
    Public Property fecha As String

    <JsonProperty("ind-estado")>
    Public Property ind_estado As String

    <JsonProperty("respuesta-xml")>
    Public Property respuesta_xml As String
End Class

Public Class Token
    <JsonProperty("access_token")>
    Public Property access_token As String

    <JsonProperty("refresh_token")>
    Public Property refresh_token As String
End Class

Public Class Recepcion
    <JsonProperty("clave")>
    Public Property clave As String

    <JsonProperty("fecha")>
    Public Property fecha As String

    <JsonProperty("emisor")>
    Public Property emisor As Emisor

    <JsonProperty("receptor")>
    Public Property receptor As Receptor

    <JsonProperty("consecutivoReceptor")>
    Public Property consecutivoReceptor As String

    <JsonProperty("comprobanteXml")>
    Public Property comprobanteXml As String
End Class

Public Class RecepcionMR
    <JsonProperty("clave")>
    Public Property clave As String

    <JsonProperty("fecha")>
    Public Property fecha As String

    <JsonProperty("emisor")>
    Public Property emisor As Emisor

    <JsonProperty("receptor")>
    Public Property receptor As Receptor

    <JsonProperty("consecutivoReceptor")>
    Public Property consecutivoReceptor As String

    <JsonProperty("comprobanteXml")>
    Public Property comprobanteXml As String

End Class

Public Class Emisor
    <JsonProperty("TipoIdentificacion")>
    Public Property TipoIdentificacion As String
    <JsonProperty("numeroIdentificacion")>
    Public Property numeroIdentificacion As String
End Class
Public Class Receptor
    <JsonProperty("TipoIdentificacion")>
    Public Property TipoIdentificacion As String
    <JsonProperty("numeroIdentificacion")>
    Public Property numeroIdentificacion As String
    Public Property sinReceptor As Boolean = False
End Class
Public Class Emisor2
    <JsonProperty("TipoIdentificacion")>
    Public Property TipoIdentificacion As String
    <JsonProperty("numeroIdentificacion")>
    Public Property numeroIdentificacion As String
    <JsonProperty("nombre")>
    Public Property nombre As String
End Class
Public Class Receptor2
    <JsonProperty("TipoIdentificacion")>
    Public Property TipoIdentificacion As String
    <JsonProperty("numeroIdentificacion")>
    Public Property numeroIdentificacion As String
    Public Property sinReceptor As Boolean = False
    <JsonProperty("nombre")>
    Public Property nombre As String
End Class

Public Class notasCredito
    Public Property sinnotasCredito As Boolean = False
    <JsonProperty("clave")>
    Public Property clave As String
    <JsonProperty("fecha")>
    Public Property fecha As String

End Class

Public Class notasDebito
    Public Property sinnotasDebito As Boolean = False
    <JsonProperty("clave")>
    Public Property clave As String
    <JsonProperty("fecha")>
    Public Property fecha As String

End Class
Public Class ListaComprobantes
    <JsonProperty("clave")>
    Public Property clave As String

    <JsonProperty("fecha")>
    Public Property fecha As String

    <JsonProperty("emisor")>
    Public Property emisor As Emisor2

    <JsonProperty("receptor")>
    Public Property receptor As Receptor2

    <JsonProperty("notasCredito")>
    Public Property notasCredito As notasCredito

    <JsonProperty("notasDebito")>
    Public Property notasDebito As notasDebito
End Class