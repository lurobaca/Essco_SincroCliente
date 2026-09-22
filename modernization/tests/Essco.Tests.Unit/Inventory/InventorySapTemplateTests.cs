using System.IO.Compression;
using System.Xml.Linq;
using Essco.Application.Inventory;
using Essco.Domain.Inventory;
namespace Essco.Tests.Unit.Inventory;

public sealed class InventorySapTemplateTests
{
    private static InventoryItem Item(string code, decimal counted) => new(code, "Desc", "P", 10, counted, 2.5m, 0, 0);
    [Fact]
    public void Preserves_legacy_columns_text_codes_and_filters_unchanged_lines()
    {
        using var stream = new MemoryStream(InventorySapTemplate.Create([Item("001", 12), Item("same", 10)]));
        using var zip = new ZipArchive(stream);
        Assert.Equal(5, zip.Entries.Count);
        using var sheet = zip.GetEntry("xl/worksheets/sheet1.xml")!.Open();
        var doc = XDocument.Load(sheet); XNamespace ns = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
        var rows = doc.Descendants(ns + "row").ToArray();
        Assert.Equal(2, rows.Length);
        var cells = rows[1].Elements(ns + "c").ToArray();
        Assert.Equal(14, cells.Length);
        Assert.All(cells, c => Assert.Equal("inlineStr", (string?)c.Attribute("t")));
        var values = cells.Select(c => c.Descendants(ns + "t").Single().Value).ToArray();
        Assert.Equal("001", values[0]); Assert.Equal("01", values[2]); Assert.Equal("12", values[5]);
        Assert.Equal("2.5", values[8]); Assert.Equal("50100102001", values[10]); Assert.Equal("50100102002", values[11]);
    }
    [Fact]
    public void Formula_like_code_is_text_not_formula()
    {
        using var stream = new MemoryStream(InventorySapTemplate.Create([Item("=1+1", 12)]));
        using var zip = new ZipArchive(stream); using var sheet = zip.GetEntry("xl/worksheets/sheet1.xml")!.Open();
        var doc = XDocument.Load(sheet); XNamespace ns = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
        Assert.Empty(doc.Descendants(ns + "f"));
        Assert.Contains(doc.Descendants(ns + "t"), t => t.Value == "=1+1");
    }
    [Fact]
    public void Rejects_duplicate_codes() =>
        Assert.Throws<ArgumentException>(() => InventorySapTemplate.Create([Item("X", 12), Item("X", 13)]));
    [Fact]
    public void Rejects_negative_quantities() =>
        Assert.Throws<ArgumentException>(() => InventorySapTemplate.Create([Item("X", -1)]));
}
