# Essco.SapBridge.Worker

Procesa trabajos SAP fuera del proceso Web y está preparado para ejecutarse como servicio de Windows.

- **Debe contener:** consumo de trabajos, gateways DI API, reintentos y diagnóstico SAP.
- **No debe contener:** Razor, navegación Web ni reglas visuales.
- **Dependencias:** Essco.SapBridge.Contracts y componentes SAP disponibles en Windows.
- **Ejemplo:** `ComSapEmployeeGateway` valida o procesa información de empleados contra SAP sin cargar COM dentro de Essco.Web.

