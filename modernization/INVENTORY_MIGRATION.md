# Migración de inventario físico

Fuentes heredadas: formularios `Inv_*`, `Class_funcionesSQL.vb`, `dbo.Inv_Registro`, `dbo.Inv_Inventario` y `dbo.Inv_Conteos`.

La sección `/Inventory` presenta inventarios abiertos y cerrados, conteos por grupo y número, existencias del sistema, conteo final y diferencias físicas/monetarias. También administra responsables, acompañantes y proveedores por grupo. Los conteos y grupos solo se actualizan mientras el inventario esté abierto.

La creación bloquea inventarios abiertos, crea la cabecera, copia el universo de `Inve_Conteo` y calcula el valor inicial dentro de una transacción serializable. El cierre recalcula valores desde las líneas persistidas y actualiza `Inv_Inventario` e `Inv_Registro` en una única transacción. Antes del piloto deben validarse la comparación/reconteo y el ajuste final en SAP con datos reales.

Se implementaron cruce 1/2, finalización, reconteos sucesivos elegidos por el usuario, unificación por proveedor y aceptación del último conteo. Consulte INVENTORY_CROSSING.md para condiciones y pruebas SQL pendientes.

## Plantilla para SAP

SapTemplate descarga un XLSX solo para inventarios cerrados. Conserva las 14 columnas de Obtiene_DatosPlantilla (Class_funcionesSQL.vb) y celdas de texto como ExportarPlantilla (ExportarAExcell.vb), sin automatizar Excel en el servidor. Solo exporta artículos con cantidad final diferente del stock, ordenados por código. Mantiene almacén 01 y cuentas 50100102001/50100102002 del original; se muestran explícitamente en la interfaz para revisión antes de importar. No transmite documentos a SAP.

Las pruebas inspeccionan el paquete XLSX, cantidad/orden de columnas, ceros iniciales, decimales invariantes y códigos que parezcan fórmulas (se escriben como texto, nunca como fórmulas). Falta abrir una muestra en Excel y validar la importación en una sociedad SAP de pruebas. No se declara validación funcional de SAP por compilar o superar estas pruebas.
