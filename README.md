# Proyecto final - Escalabilidad de sistemas

## Features

- Aplicación de E-commerce
- Aplicación hecha desde cero que solo cuenta con backend
- Se tiene dos repositorios:
  - **v1**: Simboliza la primera version de la aplicación la cual no esta optimizada
  - **v2**: Simboliza la version mejorada de la aplicación usando escalabilidad
- La aplicación cuenta con la habilidad de auto escalado
- Carga

## Casos de uso

1. Historial de todos los items de ordenes de venta por código del producto siguiendo las 3 primeras letras como input
2. Todos los item de ordenes de venta en un rango de fechas
3. Todos los items de ordenes de venta filtrados por cantidad

## Diagrama de Arquitectura

![]()

## Tablas comparativas
Tabla de comparacion de tiempo de ejecuciones, las implementaciones compardas son la implementacion inicial en monolito y la nueva implementacion en microservicios
| Query Type             |  Implementacion Actual Monolito (ms) | Nueva Implementacion Micro Servicios (ms) |
|------------------------|-----------------------------|-------------------------|
| MySQL by CodeNumber    | 44.165                       | 22.110                  |
| MySQL by Date Range    | 105.583                       | 61.234                  |
| API by CodeNumber      | 95.123                  | 76.891                  |
| API by Date Range      | 88.546                   | 68.938                  |
| API by Quantity        | 72.457                   | 45.166                  |
             |

### Observaciones:

- **Consultas MySQL**: La nueva implementación muestra tiempos de respuesta mejorados.


La nueva implementación parece mejorar significativamente los tiempos de consulta de MySQL, y proporciona tiempos de respuesta para las solicitudes API mejoradas 
### Lenguaje de programación

C# vs Python

### Base de datos

Relacional vs No Relacional

MySQL vs PostgreSQL

### Servicios

API Gateway vs Load Balancer

## Diagrama topológico de los servidores

![Diagrama topologico](images/Topography.png)

1.  **Aplicación Cliente**: El usuario interactúa con la aplicación cliente, que podría ser un navegador web, una aplicación móvil u otro tipo de interfaz de usuario.
    
2.  **Tráfico**: La solicitud del usuario es enviada desde la aplicación cliente al API Gateway a través de la red.
    
3.  **API Gateway**: Este componente actúa como el punto de entrada central para todas las solicitudes de los clientes. El API Gateway maneja las solicitudes, las autentica, y las enruta a los servicios apropiados en la capa de replicación del e-commerce.
    
4.  **Balanceador de Carga**: Distribuye las solicitudes entrantes de manera equitativa entre los diferentes servicios del e-commerce para asegurar que ninguno de ellos se sobrecargue y para mejorar la disponibilidad y la escalabilidad del sistema.
    
5.  **E-commerce**:
    
    -   **Ecommerce-V2 Sales Order Item**: Servicio responsable de manejar los ítems de las órdenes de venta.
    -   **Ecommerce-V2 Products**: Servicio responsable de manejar la información de los productos.
    -   **Ecommerce-V2 Sales Order**: Servicio responsable de manejar las órdenes de venta.
    
6.  **Replicación de Base de Datos**:
    
    -   **Ecommerce-V2 Data Base Replication 1**: Primera réplica de la base de datos del sistema de e-commerce.
    -   **Ecommerce-V2 Data Base Replication 2**: Segunda réplica de la base de datos del sistema de e-commerce.
    
    Estas réplicas aseguran la alta disponibilidad y la redundancia de los datos, permitiendo que las operaciones de lectura y escritura sean distribuidas para mejorar el rendimiento y la resiliencia del sistema.

## Diagrama de la base de datos

![Base de datos](images/basededatos.png)

### Tablas

- **Product:** Guarda información básica de un producto
- **SalesOrderItem:** Guarda información de un producto con la diferencia de que se especifica la cantidad de producto que se quiere
- **SalesOrder:** Guarda `SalesOrderItems`, puede tener varios `SalesOrderItems` y el conjunto de estos harían una orden.

## Tiempos - Mediciones

- 

## Optimizaciones

### Base de datos

**Primera version**

Base de datos la cual cargaba los siguientes datos:

- 1000 productos
- 50000 items de ordenes
- 10000 ordenes

**Segunda version**

Para la segunda version se aplico *Replication* con el tipo de *Master-Slave* la cual nos indica que hay un servidor que es el master y otras que son los slave (replicas).

Las razones por las que aplicamos replicación son:

- Scaling out: Cuando la mayoría de las operaciones en la base de datos son de lectura, se  puede distribuir las lecturas entre las bases de datos (slave) mientras la principal (master) se mantiene disponible para manejar las escrituras.
- Analíticas: Se tiene una replica de la base de datos que se encarga de queries lentos lo que permite que no se interrumpa la disponibilidad de la base de datos principal para escribir.
- Seguridad: Se puede pausar una replica y realizar una copia de seguridad sin temor a que se dañen los datos en la base de datos principal.

### Código

## Asignación de tareas

Se utilizo GitHub Projects para asignar las tareas

![GitHub Tasks](images/githubprojects.png)

Cada task tiene:

- Acceptance Criteria
- A quien se asigno la tarea
- Estado de la tarea
- Prioridad
- Tiempo estimado en terminar la tarea
- Tiempo actual que le tomo en completar la tarea
- Fecha de inicio de la tarea
- Fecha de finalización de la tarea

![GitHub card](images/githubcard.png)
