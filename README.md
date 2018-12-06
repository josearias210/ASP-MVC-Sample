
# Proceso para configurar y ejecutar App
1. Instale el Servidor Mysql y el conector de mysql para .NET (Ultima versión)
2. Clone el repositorio
3. Abra el proyecto en visual studio y espere que restaure los nuget
4. Renombre el archivo  Web-sample.config a Web.config del proyecto "WonderMoon.Web"
5. Edite connectionStrings llamado "WonderMoonContext" y coloque los datos del servidor Mysql
6  Ejecute el aplicativo asegurandose de tener como proyecto de inicio "WonderMoon.Web"


# Pruebas Unitarias
En caso que desee ejecutar las pruebas unitarias realice el siguiente proceso:

1. Renombre el archivo  App-sample.config a App.config del proyecto "WonderMoon.Test"
2. Edite connectionStrings llamado "WonderMoonContext" y coloque los datos del servidor Mysql. Se recomienda no usar la misma base datos que usa el eplicativo.
3. Ejecute las pruebas desde panel de pruebas de  Visual Studio

# Información General

1. La aplicacion cada vez que se ejecute va borrar la base datos y correr seeder para ingresar los roles y 100 usuario aletorios que facilitara ver las funcionalodad de la aplicación

2. La estrategia usada es Code First


