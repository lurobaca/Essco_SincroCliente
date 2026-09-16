namespace Essco.Domain.Inventory;
public sealed record PhysicalInventory(int Id,DateOnly Date,string Title,string Comments,bool Closed,decimal InitialValue,decimal FinalValue,decimal Entries,decimal Exits,decimal Differences);
public sealed record InventoryItem(string Code,string Description,string SupplierCode,decimal SystemStock,decimal Counted,decimal UnitCost,decimal Difference,decimal DifferenceAmount);
public sealed record InventoryCount(int InventoryId,string Group,int Number,string ItemCode,string Description,decimal Quantity,bool Recount,string SupplierCode)
{public IReadOnlyCollection<string>Validate(){var e=new List<string>();if(InventoryId<=0)e.Add("El inventario es obligatorio.");if(string.IsNullOrWhiteSpace(Group))e.Add("El grupo es obligatorio.");if(Number<=0)e.Add("El número de conteo es obligatorio.");if(string.IsNullOrWhiteSpace(ItemCode))e.Add("El artículo es obligatorio.");if(Quantity<0)e.Add("La cantidad no puede ser negativa.");return e;}}
