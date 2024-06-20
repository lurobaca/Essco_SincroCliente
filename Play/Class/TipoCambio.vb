Imports System
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Xml

Public Class TipoCambio

    Private Const UrlApi As String = "https://gee.bccr.fi.cr/Indicadores/Suscripciones/WS/wsindicadoreseconomicos.asmx"

    Public Async Function ObtenerTipoCambioAsync(ByVal codigoIndicador As String, ByVal fecha As DateTime) As Task(Of Decimal)
        Using cliente As New HttpClient()
            ' Construir la URL de la solicitud
            Dim url As String = $"{UrlApi}/ObtenerIndicadoresEconomicosXML"
            url += $"?Indicador={codigoIndicador}"
            url += $"&FechaInicio={fecha.ToString("dd/MM/yyyy")}"
            url += $"&FechaFinal={fecha.ToString("dd/MM/yyyy")}"
            url += $"&Nombre=S"
            url += $"&SubNiveles=N"
            url += $"&CorreoElectronico=lurobaca@gmail.com" ' Reemplaza con tu correo registrado
            url += $"&Token=10GIB2OESA" ' Reemplaza con tu token

            ' Realizar la solicitud HTTP GET
            Dim respuesta As HttpResponseMessage = Await cliente.GetAsync(url)

            ' Verificar si la solicitud fue exitosa
            If respuesta.IsSuccessStatusCode Then
                ' Leer la respuesta como una cadena de texto
                Dim xmlRespuesta As String = Await respuesta.Content.ReadAsStringAsync()

                ' Decodificar entidades HTML para obtener el XML real
                Dim decodedXml As String = System.Web.HttpUtility.HtmlDecode(xmlRespuesta)

                ' Analizar la respuesta XML y extraer el tipo de cambio
                Dim doc As New XmlDocument()
                doc.LoadXml(decodedXml)
                Dim nsmgr As New XmlNamespaceManager(doc.NameTable)
                nsmgr.AddNamespace("ns", "http://ws.sdde.bccr.fi.cr")

                Dim nodoValor As XmlNode = doc.SelectSingleNode("//ns:NUM_VALOR", nsmgr)

                If nodoValor IsNot Nothing Then
                    Dim valorTipoCambio As String = nodoValor.InnerText
                    ' Convertir el tipo de cambio a decimal
                    Dim tipoCambio As Decimal = Decimal.Parse(valorTipoCambio)

                    Return tipoCambio
                Else
                    Throw New Exception("No se encontró el valor del tipo de cambio en la respuesta XML.")
                End If
            Else
                ' Manejar el error de la solicitud HTTP
                Throw New Exception($"Error al obtener el tipo de cambio. Código de estado: {respuesta.StatusCode}")
            End If
        End Using
    End Function



    Public Async Function ObtenerTipoCambioAsync() As Task(Of String)
        Dim apiKey As String = "e4483facd18e4de87306e037"
        Dim url As String = $"https://v6.exchangerate-api.com/v6/{apiKey}/latest/USD"

        Using client As New HttpClient()
            Try
                Dim response As HttpResponseMessage = Await client.GetAsync(url)
                response.EnsureSuccessStatusCode()

                Dim responseBody As String = Await response.Content.ReadAsStringAsync()
                Dim tipoCambio As String = ParseTipoCambio(responseBody, "CRC") ' Cambia "EUR" por la moneda que necesites

                Return tipoCambio
            Catch ex As HttpRequestException
                MessageBox.Show($"Error al obtener el tipo de cambio: {ex.Message}")
                Return String.Empty
            End Try
        End Using
    End Function

    Private Function ParseTipoCambio(responseBody As String, currencyCode As String) As String
        ' Aquí puedes usar una librería de JSON como Newtonsoft.Json para parsear la respuesta.
        ' Por simplicidad, vamos a buscar en el texto el tipo de cambio.
        Dim searchString As String = $"""{currencyCode}"":"
        Dim startIndex As Integer = responseBody.IndexOf(searchString) + searchString.Length
        Dim endIndex As Integer = responseBody.IndexOf(",", startIndex)
        Dim tipoCambio As String = responseBody.Substring(startIndex, endIndex - startIndex).Trim()

        Return tipoCambio
    End Function
End Class

