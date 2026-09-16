# Migración de inventario físico

Fuentes heredadas: formularios `Inv_*`, `Class_funcionesSQL.vb`, `dbo.Inv_Registro`, `dbo.Inv_Inventario` y `dbo.Inv_Conteos`.

La sección `/Inventory` presenta inventarios abiertos y cerrados, conteos por grupo y número, existencias del sistema, conteo final y diferencias físicas/monetarias. Los conteos solo se actualizan mientras el inventario esté abierto.

El cierre recalcula valores desde las líneas persistidas y actualiza `Inv_Inventario` e `Inv_Registro` en una única transacción. Antes del piloto deben validarse los procesos de creación de inventario, asignación de grupos/proveedores, comparación/reconteo y el ajuste final en SAP con datos reales.
