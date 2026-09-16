# Migración de inventario físico

Fuentes heredadas: formularios `Inv_*`, `Class_funcionesSQL.vb`, `dbo.Inv_Registro`, `dbo.Inv_Inventario` y `dbo.Inv_Conteos`.

La sección `/Inventory` presenta inventarios abiertos y cerrados, conteos por grupo y número, existencias del sistema, conteo final y diferencias físicas/monetarias. También administra responsables, acompañantes y proveedores por grupo. Los conteos y grupos solo se actualizan mientras el inventario esté abierto.

La creación bloquea inventarios abiertos, crea la cabecera, copia el universo de `Inve_Conteo` y calcula el valor inicial dentro de una transacción serializable. El cierre recalcula valores desde las líneas persistidas y actualiza `Inv_Inventario` e `Inv_Registro` en una única transacción. Antes del piloto deben validarse la comparación/reconteo y el ajuste final en SAP con datos reales.
