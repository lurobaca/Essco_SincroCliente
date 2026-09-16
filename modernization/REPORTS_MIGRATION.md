# Sustitución de reportes Crystal Reports

El inventario heredado contiene 49 archivos `.rpt`. La estrategia de reemplazo usa vistas web para consulta, CSV UTF-8 para análisis/conciliación y PDF para documentos con formato legal o imprimible.

La sección `/Reports` entrega las primeras exportaciones parametrizadas de facturación, inventarios y planillas. Los valores se escapan conforme a CSV y los números se serializan con cultura invariante. El acceso exige el permiso `reports.access`.

La sustitución no se considera completa hasta comparar filtros, columnas, totales, agrupaciones y paginación de cada reporte listado en `docs/inventory/REPORTS.md`. Los formatos fiscales, comprobantes, órdenes, colillas y reportes de liquidación requieren plantillas PDF específicas.
