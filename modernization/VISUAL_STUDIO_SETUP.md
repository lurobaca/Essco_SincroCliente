# Abrir y ejecutar la solución web

Para restaurar, compilar TODOS los proyectos y ejecutar las pruebas desde la raíz del repositorio: `powershell -File modernization/scripts/Verify.ps1`. El script usa una caché NuGet temporal de ruta corta y restaura antes de compilar: se detectaron activos de restauración antiguos que permitían compilar, pero no cargar SqlClient en ejecución. También se observaron errores de copia de dependencias con la caché anidada dentro de esta ruta larga del repositorio. La caché temporal no modifica la configuración global de NuGet.

Diagnóstico del 17 de septiembre de 2026: en el equipo están registrados Visual Studio 2017 y Visual Studio 2022 17.14.10. La solución apunta a net10.0 y el Worker a net10.0-windows. global.json selecciona el SDK 10.0.400, que está instalado. Los IDE registrados no admiten ese destino; instalar el SDK por sí solo no actualiza Visual Studio.

Use Visual Studio 2026 actualizado con la carga «ASP.NET y desarrollo web» y soporte para el SDK seleccionado. Abra modernization/Essco.Modern.sln y establezca Essco.Web como proyecto de inicio. No abra la solución VB antigua para ejecutar la migración. No es necesario iniciar el Worker para mostrar la web.

Referencia: https://learn.microsoft.com/en-us/dotnet/core/porting/versioning-sdk-msbuild-vs

Alternativa por consola, desde la raíz del repositorio:

```powershell
dotnet run --project modernization/src/Essco.Web/Essco.Web.csproj --launch-profile http
```

El perfil http usa http://localhost:5029. Iniciar el servidor no certifica que SQL, credenciales, SAP o Hacienda estén configurados. No use datos productivos para validar la migración.

Si sigue apareciendo «sin cargar» con el IDE compatible, recopile el mensaje exacto de «Volver a cargar proyecto» y la salida del cargador de proyectos. No se ha observado directamente el diálogo del usuario: la incompatibilidad de versiones sí está comprobada, pero puede coexistir con otros errores.
