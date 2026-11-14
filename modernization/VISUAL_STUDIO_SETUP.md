# Abrir y ejecutar la solución web

La conexión específica del equipo se guarda en appsettings.Local.json, excluido de Git y cargado únicamente en Development. Visual Studio debe ejecutarse con una cuenta Windows autorizada en la instancia configurada. SAP permanece deshabilitado en esta configuración local. TrustServerCertificate=True es exclusivo de pruebas y no debe copiarse a producción. El acceso requiere las tablas auxiliares de los scripts 001/002; la cola usa el script 003. No confundir conexión configurada con esquema preparado.

Para restaurar, compilar TODOS los proyectos y ejecutar las pruebas desde la raíz del repositorio: `powershell -File modernization/scripts/Verify.ps1`. El script usa una caché NuGet temporal de ruta corta y restaura antes de compilar: se detectaron activos de restauración antiguos que permitían compilar, pero no cargar SqlClient en ejecución. También se observaron errores de copia de dependencias con la caché anidada dentro de esta ruta larga del repositorio. La caché temporal no modifica la configuración global de NuGet.

Actualización del 13 de noviembre de 2026: la solución apunta a `net9.0` y el Worker a `net9.0-windows`. `global.json` selecciona el SDK 9.0.300 con avance a la última banda de características instalada (9.0.302 en el equipo verificado). Esta versión es compatible con Visual Studio 2022 17.14.10. Se restauraron y compilaron los nueve proyectos, y pasaron 240 pruebas unitarias y 22 de integración. Esto no equivale a una validación manual del inicio en el IDE ni de las integraciones externas.

**Uso temporal para desarrollo:** .NET 9 dejó de recibir soporte el 10 de noviembre de 2026. No publicar esta variante para clientes ni producción. Antes del despliegue se requiere volver a una versión de .NET con soporte vigente y usar un IDE compatible. Referencia: https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core

Use Visual Studio 2022 actualizado con la carga «ASP.NET y desarrollo web» y el SDK .NET 9. Abra `modernization/Essco.Modern.sln`, recargue los proyectos si el IDE conserva el estado descargado de una sesión anterior y establezca `Essco.Web` como proyecto de inicio. No abra la solución VB antigua para ejecutar la migración. No es necesario iniciar el Worker para mostrar la web.

Referencia: https://learn.microsoft.com/en-us/dotnet/core/porting/versioning-sdk-msbuild-vs

Alternativa por consola, desde la raíz del repositorio:

```powershell
dotnet run --project modernization/src/Essco.Web/Essco.Web.csproj --launch-profile https
```

Seleccione el perfil https y abra https://localhost:7152. La cookie de sesión requiere HTTPS; el perfil http solo sirve para inspeccionar la portada, no para iniciar sesión. Si Visual Studio solicita confiar en el certificado de desarrollo, revise y acepte esa solicitud local para probar HTTPS. Iniciar el servidor no certifica que SQL, credenciales, SAP o Hacienda estén configurados. No use datos productivos para validar la migración.

## Portal y Syncro Cliente al mismo tiempo

Para probar el recorrido completo desde el portal, seleccione en la barra de inicio de Visual Studio el perfil de solución **Portal + Syncro Cliente**. Este perfil inicia `Essco.Portal` en `https://localhost:7252` y `Essco.Web` en `https://localhost:7152`. Si el perfil no aparece después de actualizar la rama, cierre y vuelva a abrir `Essco.Modern.sln`.

La portada presenta los módulos sin consultar datos del negocio y muestra en Development si falta configurar SQL. No crea usuarios de demostración ni evita la autenticación. Con sesión iniciada, las tarjetas se filtran por permisos. La configuración base no permite operar los módulos hasta habilitar la copia SQL y sus usuarios.

Si sigue apareciendo «sin cargar» con el IDE compatible, recopile el mensaje exacto de «Volver a cargar proyecto» y la salida del cargador de proyectos. La compilación por consola no descarta problemas de configuración específicos del IDE.
