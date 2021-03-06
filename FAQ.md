# Frequently Asked Questions
Aquí encontrará algunos de los problemas - curiosidades o adversidades que hallamos encontrado durante la creación de este proyecto.

Versión de Visual Studio

```
El proyecto está configurado para correr en la versión .NET 3.1, sin embargo, esto puede causar un error de "MAX_PATH"
Cambiando la configuración de Visual Studio a usar la versión .NET 5.0 parece arreglar este problema.
```

Bibliotecas faltantes

```
Es muy probable que la compilación falle debido a bibliotecas faltantes
siempre es bueno verificar si el código logra detectarlas y descargarlas automáticamente
(ClosedXML y MySqlConnector fueron populares en estos inconvenientes)
```

Actualización de datos en el repositorio

```
Para evitar problemas de configuración, debido a que Visual Studio realiza muchos cambios en archivos
binarios y demás, aconsejamos mantener la versión actual de configuración en Visual Studio y actualizar
solo los archivos fuentes que vayan siendo agregados o modificados.
Una vez realizado el commit de los cambios en el archivo fuente, se puede descartar el resto de cambios
para evitar conflictos entre versiones del Visual Studio (usualmente, se omite la carpeta bin, obj, Debug).
```

Errores comúnes en la ejecución del programa

```
1. Debido a una numerosa cantidad de ejeciones del programa, se observó que hay errores si no hay ningún
tipo de información referente en la base de datos, ya sea de extintores, centros de trabajo o usuarios claramente, 
por lo que inicialmente se deben de ingresar manualmente al menos uno de cada tipo.

2. No se recomienda el uso del navegador de Mozilla Firefox ya que tiende a cambiar algunas vistas del programa, 
mas no afecta la funcionalidad del mismo.
```
