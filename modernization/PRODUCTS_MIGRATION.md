# Migración de artículos, precios y descuentos

Fuentes heredadas: `Articulos.vb`, `ListaPrecios.vb`, `DescuentosAutomaticos.vb`, `dbo.Articulos`, `dbo.ListasDePrecio` y `dbo.DescuentosAutomaticos`.

La sección `/Products` ofrece búsqueda parametrizada del catálogo por código, descripción y tipo. Desde ella se administran las listas de precios y su estado activo/inactivo, además de los descuentos automáticos por artículo, vigencia, porcentaje y cantidades mínima/disponible.

La escritura permanece en las tablas operativas existentes para mantener compatibilidad durante la convivencia con WinForms. Todas las consultas usan parámetros y los descuentos validan porcentajes, cantidades y rangos de fechas antes de persistirse.

Antes del piloto se deben contrastar nombres, tipos y nulabilidad de columnas con una copia de la base real y confirmar si la creación/edición completa del maestro de artículos seguirá siendo responsabilidad de SAP Business One. La web actualmente trata el maestro como catálogo de consulta y administra únicamente las reglas locales que el legado almacenaba en SQL.
