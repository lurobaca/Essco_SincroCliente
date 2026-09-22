using System.Globalization;
using System.IO.Compression;
using System.Text;
using System.Xml;
using Essco.Domain.Inventory;
namespace Essco.Application.Inventory;

/// <summary>Libro de celdas de texto que conserva el orden de columnas heredado de Obtiene_DatosPlantilla.</summary>
public static class InventorySapTemplate
{
    private static readonly string[] Headers = ["Codigo","Descripcion","Almacen","Cantidad en almacén en fecha de recuento",
        "Cantidad de unidad de medida contada","CF","Desviación","% desviación","Costo","Total",
        "Cuenta de aumento","Cuenta de reducción","Código de unidad de medida","Artículos por unidad"];
    public static byte[] Create(IEnumerable<InventoryItem> items)
    {
        var lines = items.Where(x => x.Counted != x.SystemStock).OrderBy(x => x.Code, StringComparer.Ordinal).ToArray();
        if (lines.Any(x => string.IsNullOrWhiteSpace(x.Code) || x.Counted < 0 || x.UnitCost < 0)
            || lines.Select(x => x.Code).Distinct(StringComparer.OrdinalIgnoreCase).Count() != lines.Length)
            throw new ArgumentException("La plantilla contiene artículos inválidos o duplicados.", nameof(items));
        using var output = new MemoryStream();
        using (var zip = new ZipArchive(output, ZipArchiveMode.Create, true))
        {
            Add(zip, "[Content_Types].xml", """
                <?xml version="1.0" encoding="utf-8"?>
                <Types xmlns="http://schemas.openxmlformats.org/package/2006/content-types">
                <Default Extension="rels" ContentType="application/vnd.openxmlformats-package.relationships+xml"/>
                <Default Extension="xml" ContentType="application/xml"/>
                <Override PartName="/xl/workbook.xml" ContentType="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml"/>
                <Override PartName="/xl/worksheets/sheet1.xml" ContentType="application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml"/>
                </Types>
                """);
            Add(zip, "_rels/.rels", """
                <?xml version="1.0" encoding="utf-8"?>
                <Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
                <Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument" Target="xl/workbook.xml"/>
                </Relationships>
                """);
            Add(zip, "xl/workbook.xml", """
                <?xml version="1.0" encoding="utf-8"?>
                <workbook xmlns="http://schemas.openxmlformats.org/spreadsheetml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships">
                <sheets><sheet name="Inventario" sheetId="1" r:id="rId1"/></sheets>
                </workbook>
                """);
            Add(zip, "xl/_rels/workbook.xml.rels", """
                <?xml version="1.0" encoding="utf-8"?>
                <Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
                <Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet" Target="worksheets/sheet1.xml"/>
                </Relationships>
                """);
            using var stream = zip.CreateEntry("xl/worksheets/sheet1.xml").Open();
            using var writer = XmlWriter.Create(stream, new XmlWriterSettings { Encoding = new UTF8Encoding(false) });
            const string ns = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
            writer.WriteStartDocument(); writer.WriteStartElement("worksheet", ns); writer.WriteStartElement("sheetData", ns);
            void Row(IEnumerable<string> cells)
            {
                writer.WriteStartElement("row", ns);
                foreach (var value in cells)
                {
                    writer.WriteStartElement("c", ns); writer.WriteAttributeString("t", "inlineStr");
                    writer.WriteStartElement("is", ns); writer.WriteStartElement("t", ns);
                    writer.WriteAttributeString("xml", "space", null, "preserve"); writer.WriteString(value);
                    writer.WriteEndElement(); writer.WriteEndElement(); writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            Row(Headers);
            foreach (var item in lines)
                Row([item.Code,"","01","","",item.Counted.ToString(CultureInfo.InvariantCulture),"","",
                    item.UnitCost.ToString(CultureInfo.InvariantCulture),"","50100102001","50100102002","",""]);
            writer.WriteEndElement(); writer.WriteEndElement(); writer.WriteEndDocument();
        }
        return output.ToArray();
    }
    private static void Add(ZipArchive archive, string path, string text)
    {
        using var writer = new StreamWriter(archive.CreateEntry(path).Open(), new UTF8Encoding(false));
        writer.Write(text);
    }
}
