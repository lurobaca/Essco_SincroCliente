# Essco.SapBridge.Contracts

Define mensajes compartidos para solicitar y consultar trabajos SAP sin referenciar COM.

- **Debe contener:** contratos serializables y estados de trabajos.
- **No debe contener:** implementación DI API ni lógica de interfaz.
- **Dependencias:** biblioteca base de .NET.
- **Ejemplo:** una solicitud creada por la Web puede ser consumida por `Essco.SapBridge.Worker` usando el mismo contrato.

