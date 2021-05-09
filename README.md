# Prueba de desarrollo de Intelutions - WebForm

Consta de una solución, **Intelutions.Interview** que define una aplicación en .NET Framework 4.8 separada por capas que consta de una WebApp, una librería Bussiness y una librería Data.

## Intelutions.Permissions.Bussiness

Define los modelos **permission** y **permissiontype**.

## Intelutions.Permissions.Data

Define el **Context** de la base de datos en EF 6. Consta de un **Repository** con los métodos requeridos para las operaciones CRUD.

+ La configuración en la aplicación Web esta diseñada para crear la base con nombre **PermissionIntelutions** sobre **(LocalDb)\MSSQLLocalDB**.

### Intelutions.Interview.WebForm

Define la aplicación **WebForm** para las vistas de creación/actualización de permisos y el listado de los mismos.

### Configuración 

+ **ConnectionStrings:ApplicationConnection**: Cadena de conexión de la aplicación. Por defecto usa MSSQLLocalDB.
```
<connectionStrings>
	<add name="PermissionDbContext" connectionString="Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PermissionIntelutions;Integrated Security=SSPI;" providerName="System.Data.SqlClient"/>
</connectionStrings>
```

### Dependencias

+ EntityFramework 6
+ bootstrap 3.4.1
+ bootstrap-datepicker 1.6.4
+ jquery 3.4.1
+ modernizr 2.8.3