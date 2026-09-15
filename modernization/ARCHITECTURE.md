# Arquitectura

## Decisión inicial

Se eligió ASP.NET Core Razor Pages porque el sistema original está compuesto principalmente por pantallas transaccionales, búsquedas, tablas y formularios. Permite migración incremental y renderizado en servidor con poco JavaScript. Esta decisión se revisará si el inventario funcional demuestra que un módulo necesita interacción tipo SPA.

## Límites

La aplicación web no referenciará SAP Business One DI API ni otras librerías COM. Esas dependencias estarán aisladas en `Essco.SapBridge.Worker`, ejecutado en Windows. La comunicación definitiva deberá usar una cola persistente o una API interna autenticada; la cola en memoria actual es solamente una prueba arquitectónica y no es apta para producción.

```text
Navegador -> Essco.Web -> Application -> Domain
                        -> Infrastructure -> SQL Server/MySQL/Hacienda
                        -> Cola persistente -> SapBridge.Worker -> SAP DI API/impresión
```

## Reglas de dependencia

- Domain no depende de ninguna otra capa.
- Application depende de Domain y contratos.
- Infrastructure implementa interfaces de Application.
- Web compone la aplicación y no contiene reglas empresariales.
- SapBridge.Worker es el único componente autorizado a depender de COM/DI API.
