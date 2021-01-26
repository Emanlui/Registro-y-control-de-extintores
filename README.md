# Proyecto de Registro y control de extintores
Sistema de manejo de inventario de extintores, usuarios y centros de trabajo

## Primeros pasos

Aquí encontrará las instrucciones que le permitirán tener una copia del proyecto y correrla en su máquiana local para el futuro desarrollo e implementación. Le recomendamos tener a mano los distintos manuales que brindarán información a profundidad del sistema.

### Prerequisitos

Empecemos verificando los programas que necesitaremos y luego abarcaremos la instalación de ellos

```
Visual Studio 2019
```

### Instalación

Aquí encontrará los pasos para configurar el ambiente de desarrollo y ponerlo a funcionar

Instalar Visual Studio

```
Primero, deberá descargar Visual Studio: https://visualstudio.microsoft.com/es/downloads/
Recomendamos la versión "Community" que es de uso gratuito
```

Seguidamente, deberá clonar este repositorio a una carpeta local

```
Se puede utilizar herramientas que faciliten el manejo de repositorios como GitKraken: https://www.gitkraken.com/

o bien, puede clonar el repositorio por medio de la línea de comando:
git clone https://github.com/Emanlui/Registro-y-control-de-extintores.git
```

Una vez instalado, deberá abrir el archivo de solución dentro del Visual Studio

```
Este archivo, suele tener extensión .sln y debería llamarse "Registro_y_Control_de_Extintores.sln"
Una vez abierto, Visual Studio empezará a cargar las configuraciones
```

Para ejecutar el proyecto, necesitará instalar varias bibliotecas, tales como:
```
ClosedXML
MySqlData
MySqlConnector

Varias de ellas se podrán instalar fácilmente por medio del administrador de herramientas del Visual Studio
```

Una vez instaladas estas dependencias, debería ser posible correr el proyecto en su localhost
```
El proyecto está planificado para funcionar en servidor web, para efectos de desarrollo al ejecutarse se abrirá en el localhost como hosteo web de prueba
```


## Creado con

* [ASP .NET](https://dotnet.microsoft.com/apps/aspnet) - El framework utilizado
* [Visual Studio 2019](https://visualstudio.microsoft.com/es/downloads/) - Manejo de dependencias

## FAQ
* Podrá encontrar más detalles sobre las preguntas frecuentes encontradas en el [FAQ.md](FAQ.md)

## Autores

* **Emanuelle Jiménez Sancho** - *Desarrollador de Software* - [Emanlui](https://github.com/Emanlui)

* **Kevin Ledezma Jiménez** - *Desarrollador de Software* - [Elesvan20](https://github.com/Elesvan20)

* **Fabrizio Alvarado Barquero** - *Desarrollador de Software* - [faoalvarado5](https://github.com/faoalvarado5)

## Agradecimientos

* A los empleados Mónica Quesada Bermúdez, Ana María Morera Castro y Yourks Arroyo Guzmán del departamento de Salud Ocupacional del Ministerio de Seguridad Pública de Costa Rica, por permitirnos colaborar con la elaboración de este proyecto y su atento seguimiento durante cada reunión.
* Al empleado Joaquín Soto Rojas de la Dirección de Tecnologías de Información, Departamento de Sistemas por el cercano seguimiento técnico durante el desarrollo del proyecto.
* A la profesora María Estrada Sánchez y Aurelio Sanabria Rodríguez de la facultad de Ingeniería en Computación del Instituto Tecnológico de Costa Rica por brindarnos la oportunidad de trabajar en un proyecto con los estándares que nos brindaron.
