# Puente SAP

El worker modela trabajos con estados explícitos, número de intentos, identificador externo y error sanitizado. La clave de idempotencia evita solicitudes duplicadas dentro del prototipo.

Antes de integrar DI API se debe confirmar:

- Versión y arquitectura x86/x64 de SAP Business One y DI API.
- Empresas y ambientes sandbox disponibles.
- Operaciones utilizadas por cada módulo original.
- Política de reintentos y tratamiento de transacciones inciertas.
- Tecnología persistente para la cola y almacenamiento de resultados.

La implementación en memoria actual se reemplazará antes de cualquier piloto. No sobrevive reinicios y la web y el worker aún no comparten un transporte entre procesos.

El proyecto apunta a `net10.0-windows` y registra el host con el nombre `Essco SAP Bridge`, por lo que puede publicarse e instalarse como servicio de Windows. La instalación definitiva se habilitará cuando exista transporte persistente y configuración SAP validada.
