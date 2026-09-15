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

El agregado `UserAccount`, el servicio de autenticación y el algoritmo de hashing están implementados y probados. Falta implementar el repositorio SQL parametrizado, la migración de esquema necesaria y las páginas web de login/logout antes de habilitar autenticación en un ambiente compartido.
