# Despliegue

Diseño previsto:

- `Essco.Web`: IIS o servicio/contenedor compatible con ASP.NET Core.
- `Essco.SapBridge.Worker`: servidor Windows con SAP Business One DI API instalado.
- Transporte: cola persistente o API interna con autenticación mutua.
- Configuración: variables de entorno y almacén de secretos.

El procedimiento definitivo se escribirá después de confirmar infraestructura, dominio, certificados TLS, base de datos y versión de SAP.
