# Inventario de acceso a datos

Generado por `tools/Generate-DatabaseInventory.ps1`. Por seguridad no reproduce cadenas de conexión ni consultas completas.

- Archivos con acceso directo o SQL detectable: 34
- Referencias de tabla detectadas: 188
- Tablas/objetos únicos detectados: 43
- Líneas con indicios de SQL dinámico/concatenado: 909
- Líneas con parámetros detectables: 481
- Operaciones transaccionales detectables: 0

| Archivo | Motor detectable | Operaciones | Tablas/objetos | SQL dinámico | Parámetros | Transacciones |
|---|---|---|---|---:|---:|---:|
| Play/Acepta_Rechaza_Lista_Comprobantes.vb | Indirecto/desconocido | SELECT | — | 0 | 0 | 0 |
| Play/Admin_Clientes.vb | SAP/Recordset | SELECT | — | 0 | 0 | 0 |
| Play/BuscaFactura.vb | SQL Server | — | — | 0 | 0 | 0 |
| Play/CantiChequeada.vb | Indirecto/desconocido | SELECT | — | 0 | 0 | 0 |
| Play/ChequearRepCarga.vb | Indirecto/desconocido | SELECT | — | 0 | 0 | 0 |
| Play/Class/Class_Funciones_MYSQL.vb | ODBC, SQL Server | DELETE, INSERT, SELECT, UPDATE | arquitect_bourne, Conteo, Grupos, Inv_ConActivo, Inv_Conteos, Inv_Grupos, Inv_Inventario, Inv_Registro, Seller_Devoluciones, Seller_Pedido | 52 | 0 | 0 |
| Play/Class/Class_funcionesSQL.vb | ODBC, SQL Server | DELETE, EXECUTE, INSERT, SELECT, UPDATE | Armonia_EDIFACT, Armonia_EDIFACT., arquitect_bourne, Bancos, BD_Bourne, Bodegueros, Consulta_FE, Conteo, dbo, dbo.Consecutivo_Comprobantes, dbo.Depositos, Deliver_CxCRepFac, Deliver_FacturasInventario, Deliver_UniversoXRepFac, Empresa, essco, FacturasPendientesXCliente, Grupos, Info_ConfiguracionPicking, Inv_Conteos, Inv_Inventario, Inv_Registro, Inventario, MotivoDevolucion, PedidoXDia, Planilla_Deducciones, Planilla_DeduccionesCCSS, Planilla_DeduccionRenta, Planilla_ValesPrestamos, Rep_Carg_Sector, Rep_Devoluciones, Ubicaciones_CostaRica, UniversoXFacturas, VentaDetallada, VentasXDia | 798 | 464 | 0 |
| Play/Class/Class_VariablesGlobales.vb | ODBC, SAP/Recordset, SQL Server | — | — | 0 | 0 | 0 |
| Play/Class/CONEXION_TO_MYSQL.vb | ODBC | — | — | 0 | 0 | 0 |
| Play/Class/CONEXION_TO_SQLSERVER.vb | SQL Server | — | — | 0 | 0 | 0 |
| Play/Class/CrearArchivo.vb | Indirecto/desconocido | SELECT | — | 10 | 8 | 0 |
| Play/Class/ExportarAExcell.vb | Indirecto/desconocido | SELECT | — | 1 | 0 | 0 |
| Play/Class/SAP_BUSSINES_ONE.vb | SAP/Recordset, SQL Server | SELECT, UPDATE | failed, t, the | 23 | 1 | 0 |
| Play/ClientesDocumentosExoneracion.vb | Indirecto/desconocido | SELECT | — | 0 | 0 | 0 |
| Play/Detalle_Gastos_Choferes.vb | SQL Server | — | — | 0 | 0 | 0 |
| Play/Detalle_Gastos.vb | SQL Server | — | — | 0 | 0 | 0 |
| Play/Enviar_Info_Deliver.vb | SQL Server | — | — | 8 | 0 | 0 |
| Play/Enviar_Info_Picking.vb | SQL Server | — | — | 1 | 0 | 0 |
| Play/Enviar_Info_Seller.vb | SQL Server | — | — | 15 | 0 | 0 |
| Play/FaltaPorchequear.vb | Indirecto/desconocido | SELECT | — | 0 | 0 | 0 |
| Play/Inv_Control.vb | ODBC | SELECT | Conteo | 0 | 0 | 0 |
| Play/Liquidacion_Choferes.vb | SQL Server | — | — | 0 | 0 | 0 |
| Play/List_RepFacturas_LiqChofer.vb | SQL Server | — | — | 0 | 0 | 0 |
| Play/LoginForm1.vb | SQL Server | — | — | 0 | 0 | 0 |
| Play/Planilla_Empleados.vb | Indirecto/desconocido | SELECT | — | 1 | 0 | 0 |
| Play/PlanillaNueva.vb | SQL Server | SELECT | TuTabla | 0 | 0 | 0 |
| Play/Principal.vb | SAP/Recordset, SQL Server | — | — | 0 | 0 | 0 |
| Play/RecibosDeDinero.vb | Indirecto/desconocido | SELECT | — | 0 | 0 | 0 |
| Play/Reporte_Facturas.vb | SQL Server | — | — | 0 | 2 | 0 |
| Play/ReporteDeDevoluciones.vb | SAP/Recordset, SQL Server | — | — | 0 | 2 | 0 |
| Play/ReportesDeCarga.vb | SQL Server | — | — | 0 | 4 | 0 |
| Play/Rutas_RepCarga.vb | SQL Server | — | — | 0 | 0 | 0 |
| Play/Usuarios.vb | SQL Server | — | — | 0 | 0 | 0 |
| Play/Variables.vb | SAP/Recordset, SQL Server | — | — | 0 | 0 | 0 |

## Criterio de migración

Cada consulta se moverá a un adaptador de infraestructura, será parametrizada y tendrá timeout, cancelación y transacción explícitos cuando corresponda. Las consultas concatenadas se consideran riesgo hasta demostrar que no incorporan entrada externa.
