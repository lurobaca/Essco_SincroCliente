# Configuración

La configuración funcional reside bajo la sección `Essco`. Los archivos versionados contienen únicamente nombres lógicos y adaptadores deshabilitados; nunca deben contener credenciales.

## Variables de entorno

ASP.NET Core traduce `__` a separadores de configuración. Ejemplos sin valores sensibles:

```text
Essco__DefaultCompany=CODIGO_EMPRESA
Essco__SqlServer__Enabled=true
Essco__SqlServer__ConnectionStringName=EsscoSqlServer
Essco__MySql__Enabled=true
Essco__MySql__ConnectionStringName=EsscoMySql
Essco__SapBridge__Enabled=true
Essco__SapBridge__Transport=PersistentQueue
Essco__SapBridge__Endpoint=nombre-interno-del-servicio
```

Las conexiones reales se obtendrán del proveedor de secretos del ambiente usando los nombres configurados. La aplicación valida la sección al iniciar y rechaza timeouts inválidos, bases habilitadas sin nombre de conexión y SAP habilitado con transporte en memoria.

## Diagnóstico

Cada respuesta incluye `X-Correlation-ID`. Si el cliente envía un identificador válido, se conserva; en caso contrario se genera uno. Los errores inesperados se entregan como Problem Details sin revelar stack traces ni credenciales.
