# Migración del módulo Empresa

## Código original

- `Play/Manager_Empresa.vb`
- Región Empresa de `Play/Class/Class_funcionesSQL.vb`
- Tabla `dbo.Empresa`

El formulario original trata la tabla como un registro único y actualiza sin cláusula `WHERE`. El repositorio nuevo conserva la semántica de registro único, pero rechaza la lectura si encuentra más de una fila y realiza el guardado dentro de una transacción serializable.

## Datos migrados

- Identificación y tipo.
- Razón social y nombre comercial.
- Teléfonos, correo, web y dirección.
- Provincia, cantón, distrito y barrio.
- Actividad económica.
- Máximo de líneas y descuento.
- Consecutivos de carga y devolución.
- Días de extensión y agrupación de descuentos.

## Datos excluidos deliberadamente del formulario web

- Contraseña de correo.
- Servidor, usuario y contraseña FTP.
- Servidor, IP, usuario y contraseña SQL.

Esos valores son configuración operativa y secretos, no datos editables del perfil empresarial. El repositorio web no los selecciona ni los actualiza, evitando exponerlos o borrarlos. Su migración se realizará mediante opciones tipadas y un almacén de secretos.

## Validación pendiente

- Confirmar el orden real de `Tipo_Cedula` en la base.
- Confirmar que los identificadores geográficos almacenan índices y no llaves reales.
- Confirmar tipos y longitudes reales de todas las columnas en una copia SQL.
- Comparar un registro real anonimizado con el mapeo nuevo.
