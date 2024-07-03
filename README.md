# Proyecto Obras

## Autores 
- Alvarez Luciano Ezequiel

## Tabla de Contenidos
1. [Introducción](#introducción)
2. [Desarrollo](#desarrollo)
    - [Objetivo del Proyecto](#objetivo-del-proyecto)
    - [Metodología](#metodología)
3. [Informe del Funcionamiento del Código](#informe-del-funcionamiento-del-código)
4. [Conclusiones](#conclusiones)
5. [Bibliografía Consultada](#bibliografía-consultada)

## Introducción
El presente proyecto tiene como objetivo diseñar e implementar un sistema de gestión para una empresa constructora, que permite administrar eficientemente las obras en ejecución, así como la asignación y control de los grupos de obreros involucrados en cada proyecto. Se utilizará el paradigma de programación orientada a objetos, haciendo uso de diagramas de clases UML para modelar la estructura del sistema.

En este sistema, cada obra se caracteriza por su nombre, datos del propietario, tipo de obra, estado de avance, jefe de obra asignado y costo estimado. Por otro lado, los obreros se registran con su información personal, número de legajo, sueldo y cargo específico dentro de la empresa. La jerarquía incluye la figura del jefe de obra, quien además de supervisar una obra, lidera un grupo de obreros especializados.

La aplicación desarrollada permitirá realizar operaciones fundamentales como la contratación y eliminación de obreros, la asignación de jefes de obra a proyectos específicos con sus respectivos grupos de trabajo, y la gestión del estado de avance de las obras. Además, se incluirá un submenú de impresión para generar listados detallados de obreros, obras en ejecución, obras finalizadas, jefes de obra, y el porcentaje de obras de remodelación pendientes de finalización.

El sistema incorporará manejo de excepciones para garantizar la integridad y consistencia de los datos, asegurando así una experiencia robusta y confiable para los usuarios.

## Desarrollo
### Objetivo del Proyecto
El objetivo principal de este proyecto es desarrollar un sistema de gestión integral que permita a una empresa constructora optimizar la administración de sus obras en ejecución y la asignación de recursos humanos. A través de la implementación de clases y estructuras orientadas a objetos, el sistema facilitará la contratación, gestión y supervisión de obreros y jefes de obra, asegurando un control efectivo del estado de avance de cada proyecto. El sistema también buscará proporcionar herramientas para generar informes detallados y precisos que apoyen la toma de decisiones estratégicas dentro de la empresa.

### Metodología
#### Análisis de Requerimientos:
- **Definición Detallada de Funcionalidades:** Comprender y documentar exhaustivamente las necesidades del sistema, incluyendo la gestión de obras, obreros y jefes de obra. Esto incluye los requerimientos específicos para la contratación, eliminación y gestión del estado de las obras.
- **Identificación de Clases, Relaciones y Excepciones:** Analizar la estructura de datos necesaria, identificar las clases principales como Empresa, Excepciones, Obra, Obrero, JefeDeObra, GrupoDeObreros, y definir las relaciones entre ellas utilizando diagramas de clases UML.

#### Diseño del Sistema:
- **Arquitectura y Diseño de Clases:** Establecer la arquitectura del sistema basada en la jerarquía de clases y la implementación de herencia donde sea apropiado (por ejemplo, JefeDeObra hereda de Obrero).
- **Diagramas UML:** Crear diagramas UML para visualizar las entidades, atributos y métodos de cada clase, así como las relaciones entre ellas.

#### Implementación:
- **Codificación:** Desarrollar las clases y métodos según lo definido en el diseño, asegurando una implementación coherente y eficiente de las funcionalidades requeridas.
- **Manejo de Excepciones:** Implementar manejo de excepciones para situaciones críticas como la falta de grupos de obreros libres al asignar un jefe de obra.

#### Pruebas y Validación:
- **Pruebas Unitarias y de Integración:** Verificar la funcionalidad y la interacción entre los componentes del sistema a través de pruebas unitarias y de integración.
- **Validación de Requisitos:** Asegurar que el sistema cumpla con todos los requisitos funcionales y no funcionales especificados en la etapa de análisis.

## Informe del Funcionamiento del Código
![Diagrama de Clases](https://github.com/LUXI4NO/Proyecto-Integrador/assets/140111840/b832501c-7797-4986-86d1-a87897b0b494)

## Conclusiones
En este proyecto de gestión para una empresa constructora, se ha desarrollado una aplicación completa que permite manejar eficazmente todas las actividades relacionadas con las obras, los obreros y los jefes de obra. Utilizando programación orientada a objetos, se aprovechó la herencia y las estructuras de datos para garantizar un sistema capaz de manejar múltiples obras simultáneamente, con detalle y precisión.

La aplicación ofrece funcionalidades clave como la contratación y eliminación de obreros, la asignación de jefes de obra a proyectos con sus respectivos equipos, y el monitoreo del avance de cada obra. Además, incluye opciones para generar informes detallados sobre obreros, obras en curso y finalizadas, así como estadísticas como el porcentaje de obras de remodelación pendientes.

Con este proyecto, se ha optimizado la gestión de la empresa constructora, asegurando que todas las operaciones estén organizadas y sean productivas. La aplicación es flexible y puede adaptarse fácilmente a futuras necesidades, manteniendo siempre altos estándares de calidad y compromiso.
