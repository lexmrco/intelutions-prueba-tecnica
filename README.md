# Intelutions Prueba Tecnica
Desarrollo de prueba técnica usando las siguientes tecnologías y librerías: 
* .Net Core
  * Entity Framework
* VueJS
  * Bootstrap-vue
* SQL Server
  
Para el desarrollo de esta prueba se entrega:
* Base de datos
* Solución backend
* Solución frontend

## Base de datos
La base de datos usada es SQL Sever, en la carpeta db se encuentran los archivos: 
* squema.sql: Script que crea la base de datos
* initial_data.sql: Script que carga los datos iniciales

## Backend
En la carpeta backend se encuentra la solución desarrollada en .Net Core 3.1.

Para iniciar la solución se debe configurar la conexión a base de datos en el archivo appsettings.json

La solucción cuenta con los siguientes proyectos:
* Intelutions.Api: Aplicación web en donde se encuentran los controladores que contienen los distintos endpoints de la aplicación.
* Intelutions.BLL: Proyecto de librería de clases con la lógica de negocios
* Intelutions.DAL: Proyecto de librería de clases con la lógica de acceso a datos. El ORM usado para el acceso a datos es Entity Framework
* Intelutions.Entities: Proyecto de librería de clases con la definición de las entidades de base de datos

Dentro del API .Net se exponen los siguientes endpoint:
* GET/permisos: Obtiene los registros guardados en la tabla permisos
* GET/permisos/permisoId: Obtiene el detalle de un permiso
* POST/permisos: Registra un nuevo permiso en base de datos
* PUT/permisos: Actualiza un registro de permiso en base de datos
* DELETE/permisos: Elimina un registro de permiso la base de datos
* GET/tipospermisos/selectlist: Optiene la lista de tipos de permisos

## Frontend
En la carpeta frontend se encuentra la solución desarrollada en VueJS y Bootstrap-vue

Al iniciar el proyecto se debe configurar el archivo .env; dar el valor a la variable VUE_APP_API_URL con la url en donde se encuentra la aplicación backend

Comandos para iniciar el proyecto:

Instalar dependencias
<pre>
  npm install
</pre>

Iniciar en ambiente de desarrollo
<pre>
  npm run serve
</pre>

Una vez funcionando la aplicación se puede ver el funcionamiento de las siguientes pantallas:
### Listar permisos
![ScreenShot](https://raw.github.com/lexmrco/intelutions-prueba-tecnica/main/docs/listar.png)
### Agregar permiso
![ScreenShot](https://raw.github.com/lexmrco/intelutions-prueba-tecnica/main/docs/crear.png)
### Ver detalle permiso
![ScreenShot](https://raw.github.com/lexmrco/intelutions-prueba-tecnica/main/docs/ver.png)
### Editar permiso
![ScreenShot](https://raw.github.com/lexmrco/intelutions-prueba-tecnica/main/docs/editar.png)
### Eliminar permiso
![ScreenShot](https://raw.github.com/lexmrco/intelutions-prueba-tecnica/main/docs/eliminar.png)

## Autor ✒️
**Alexander Moreno Ramos** _Desarrollo, documentación_
