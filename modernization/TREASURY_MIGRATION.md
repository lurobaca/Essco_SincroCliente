# Migración de tesorería

## Depósitos

Fuente heredada: `Admin_Depositos_Agentes.vb`, `Admin_Depositos_Choferes.vb` y `dbo.Depositos`.

El núcleo `DepositService` unifica ambos formularios sin perder el campo `DP_TIPO_LIQ`. La creación reserva `ConseDepositos`, valida duplicados e inserta dentro de una transacción serializable. La edición rechaza registros anulados y la anulación continúa siendo lógica mediante `DP_ANULADO`.

Los contratos incluyen operaciones separadas para asociar una liquidación y marcar un depósito como subido/conciliado. Estas operaciones serán consumidas por los módulos web de liquidaciones y revisión bancaria, evitando el modo especial basado en parámetros vacíos que utilizaba `ModificaDeposito`.

La página `/Treasury/Deposits`, protegida por `cash.access`, unifica el mantenimiento de agentes y choferes. Permite filtrar, crear, editar y anular; los anulados son de solo lectura. Los bancos sugeridos provienen de `dbo.Bancos`, como en los formularios originales.
