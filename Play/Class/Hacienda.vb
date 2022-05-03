Imports System.Xml
Imports System

Public Class Hacienda

    'Verifica si existe un comprobante nuevo FE,NC,ND,TE, esto mediante un proceso constante que consulta
    'una vista la cual obtendra el comprobante nuevo comparando el consecutivo
    'Si existen manda a extraer los datos de la vista y a crear el xml segun el tipo de comprobante FE,NC,ND,TE
    'verificara si existen x campos y dependiendo de estos agrgara los tags correspondiente por ejemplo el de descuento
    'luego de generar el xml para 1 comprobante se guardara en el serviudor SAP\Hacienda\Comprobantes\FA\clave.xml
    'luego se subira y se llamara un archivo en php para hacer el firmado y el envio
    'el callback guardara la respuesta la cual tambien se estaran consultando constantemente para almacenarlas en el 
    'campo estado de SAP y asi saber si fue Aceptada,semi aceptada , rechazada, si es rechazada se agrega el motivo

    Private Sub GeneraXML_FE(ByVal Tbl_Datos As DataTable)

        Dim writer As New XmlTextWriter("c:\product.xml", System.Text.Encoding.UTF8)
        writer.WriteStartDocument(True)
        writer.Formatting = Formatting.Indented
        writer.Indentation = 2
        writer.WriteStartElement("Table")
        createNode(1, "Product 1", "1000", writer)
        createNode(2, "Product 2", "2000", writer)
        createNode(3, "Product 3", "3000", writer)
        createNode(4, "Product 4", "4000", writer)
        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Close()
    End Sub

    Private Sub createNode(ByVal pID As String, ByVal pName As String, ByVal pPrice As String, ByVal writer As XmlTextWriter)
        writer.WriteStartElement("Product")
        writer.WriteStartElement("Product_id")
        writer.WriteString(pID)
        writer.WriteEndElement()
        writer.WriteStartElement("Product_name")
        writer.WriteString(pName)
        writer.WriteEndElement()
        writer.WriteStartElement("Product_price")
        writer.WriteString(pPrice)
        writer.WriteEndElement()
        writer.WriteEndElement()
    End Sub

End Class
