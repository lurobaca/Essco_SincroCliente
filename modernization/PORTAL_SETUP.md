# Portal ESSCO: estructura inicial

## Qué se agregó

- Proyecto ASP.NET Core Razor Pages independiente: **Essco.Portal** (net10.0), en Essco.Modern.sln.
- Sitio público ESSCO, acceso por correo/contraseña y panel por organización.
- Base independiente **Essco_Portal**, sin copiar datos de Sic_Local_Web_Pruebas.
- Cookie, claves de protección e identidad independientes de Essco.Web.
- Membresías consultadas en cada petición del panel; no se confía en un identificador de empresa enviado por el navegador.
- Contraseñas con hash, bloqueo de 15 minutos tras cinco intentos incorrectos y límite de solicitudes al login.
- Portada adaptable, enlaces para saltar al contenido, foco visible, etiquetas de campos y navegación sin dependencia de JavaScript.
- No hay acceso SSO ni conexión a bases de ERP por organización todavía. No se convierte al administrador del portal en administrador del ERP.

## Ejecutar desde Visual Studio 2026

1. Reabrir Essco.Modern.sln para cargar el noveno proyecto.
2. Establecer **Essco.Portal** como proyecto de inicio y elegir **https**.
3. F5 abre https://localhost:7252.
4. Para continuar con el ERP, iniciar **Essco.Web** como antes. Puede configurarse inicio múltiple, conservando los puertos de cada proyecto.

## Configuración local

El archivo src/Essco.Portal/appsettings.Local.json contiene la conexión PortalSqlServer en Development. Está ignorado por Git y excluido de publicación. No usar la base del ERP como conexión del portal.

Para otro equipo o despliegue, configurar ConnectionStrings:PortalSqlServer mediante un proveedor de secretos. En producción no confiar en certificados SQL autofirmados; configurar HTTPS y permisos SQL mínimos. Restringir acceso al directorio .keys y definir protección/persistencia de claves acorde al alojamiento. No exponer todavía el portal a clientes reales.

## Base de datos

Scripts:
- database/portal/000_create_database.sql: crea Essco_Portal y falla si ya existe; nunca reemplaza una base.
- database/portal/001_initial_schema.sql: aplica la versión inicial en transacción; repetirla con versión 1 aplicada no crea duplicados.

Esquemas:
- Portal: organizaciones, aplicaciones, habilitación por organización, accesos y versiones.
- Identidad: usuarios y membresías.
- Suscripciones: planes y contratos. Sin tarjetas, cobros ni proveedor de pagos.
- Auditoria: eventos sin contraseñas ni payloads personales.

La aplicación inicial del catálogo es Syncro Cliente. No se crean usuarios, empresas ni suscripciones de prueba automáticamente.

## Crear el primer administrador

Desde una terminal interactiva, situado en modernization:

```powershell
dotnet run --project src/Essco.Portal --launch-profile https -- --provision true
```

Solicita correo, nombre, organización y contraseña dos veces, sin mostrar la contraseña. Requiere 12 caracteres, mayúscula, minúscula y número. No introducir contraseñas en argumentos, scripts ni chat.

Este comando solo funciona si no hay usuarios y crea una organización y su administrador. Syncro Cliente queda pendiente de activación: no abre el ERP compartido. La inicialización no se ofrece como endpoint web. Para otros clientes falta implementar invitaciones/altas administrativas; no reutilizar esta inicialización.

## Verificación y límites

Verify.ps1 compila los nueve proyectos y ejecuta la suite existente. Test-PortalIsolation.ps1 comprueba seis escenarios sobre los literales SQL con tablas temporales: pertenencia, rechazo de otra organización, acceso explícito, usuario desactivado y membresía desactivada. No modifica datos reales.

Se comprobó la carga de portada/login y se inspeccionó su vista estrecha con la habilidad de navegador. No equivale a una auditoría completa de accesibilidad ni a pruebas completas de autenticación.

Pendiente:
- Primer administrador real (creación interactiva por el usuario).
- Invitaciones, recuperación de contraseña, MFA y administración de usuarios/accesos.
- Conectar cada organización a su entorno ERP mediante autorización del lado servidor.
- Proveedor de identidad/SSO entre aplicaciones; no compartir cookies del ERP directamente.
- Planes comerciales, suscripciones operativas y proveedor de pagos.
- Contenido corporativo definitivo, contacto y política de privacidad aprobada.
- Pruebas completas de autenticación, cierre/revocación de sesiones, concurrencia y accesibilidad antes de producción.
