# Migración de autenticación

## Comportamiento heredado confirmado

El cliente WinForms consulta la tabla `Users` mediante usuario y contraseña concatenados en SQL, compara la contraseña en texto claro, usa `Puesto` para controlar menús y registra una marca global de sesión. Ese diseño no se reproducirá en la aplicación web.

## Estrategia

1. El repositorio nuevo consultará solamente por nombre normalizado mediante parámetros SQL.
2. Durante la transición podrá leer la credencial heredada únicamente para verificar un primer acceso.
3. Una coincidencia válida reemplazará inmediatamente el valor por PBKDF2-SHA512 con sal aleatoria.
4. El usuario deberá cambiar su contraseña después de la actualización automática.
5. Los intentos fallidos se persistirán y producirán un bloqueo temporal configurable.
6. Las cookies web no contendrán contraseñas ni credenciales SAP.
7. `Puesto` se traducirá a roles y políticas explícitas después de inventariar todas las ramas de visibilidad de `Principal.vb`.

La lectura y actualización de la credencial deben ocurrir dentro de una operación atómica para evitar carreras. Ninguna credencial, incluso heredada, puede registrarse en logs, auditoría o mensajes de error.

## Estado actual

El agregado `UserAccount`, el servicio de autenticación, el algoritmo de hashing y el repositorio SQL parametrizado están implementados. La migración `database/sqlserver/001_web_user_security.sql` crea una tabla complementaria y reversible; no modifica `Users` ni borra su contraseña heredada. Debe probarse primero sobre una copia representativa y ejecutarse únicamente con autorización. Faltan las páginas web de login/logout antes de habilitar autenticación en un ambiente compartido.
