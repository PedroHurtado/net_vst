
# Entity Framework Interceptors

En **Entity Framework (EF)**, los **interceptores** te permiten ejecutar lógica personalizada antes o después de que EF interactúe con la base de datos. Puedes interceptar consultas, comandos de SQL, guardados de cambios, transacciones y más, para realizar acciones como logging, modificación de comandos o métricas de rendimiento.

## Tipos de interceptores en EF Core

EF Core proporciona diferentes tipos de interceptores que puedes implementar según el tipo de acción que deseas interceptar:

1. **Command interceptors (`IDbCommandInterceptor`)**:
   - Intercepta y modifica los comandos SQL antes de que se envíen a la base de datos.
   
2. **SaveChanges interceptors (`ISaveChangesInterceptor`)**:
   - Intercepta los eventos que ocurren durante el proceso de guardar los cambios (`SaveChanges` o `SaveChangesAsync`).
   
3. **Connection interceptors (`IDbConnectionInterceptor`)**:
   - Intercepta las aperturas y cierres de conexiones de la base de datos.

4. **Transaction interceptors (`IDbTransactionInterceptor`)**:
   - Intercepta las transacciones de la base de datos.

## Ejemplo de un `DbCommandInterceptor`

Un interceptor común es el `IDbCommandInterceptor`, que te permite interceptar y modificar los comandos SQL que se envían a la base de datos. Aquí hay un ejemplo:

### 1. Definir el Interceptor

```csharp
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

public class MyCommandInterceptor : DbCommandInterceptor
{
    // Intercepta la ejecución sincrónica del comando SQL
    public override DbCommand CommandCreated(CommandEndEventData eventData, DbCommand result)
    {
        // Aquí puedes modificar el comando SQL
        Console.WriteLine("Comando SQL creado: " + result.CommandText);

        return base.CommandCreated(eventData, result);
    }

    // Intercepta la ejecución asincrónica del comando SQL
    public override Task<DbCommand> CommandCreatedAsync(CommandEndEventData eventData, DbCommand result, CancellationToken cancellationToken = default)
    {
        // Aquí puedes modificar el comando SQL
        Console.WriteLine("Comando SQL asincrónico creado: " + result.CommandText);

        return base.CommandCreatedAsync(eventData, result, cancellationToken);
    }
}
```

### 2. Configurar el Interceptor en el `DbContext`

Ahora, necesitamos registrar el interceptor en la configuración de EF Core dentro de nuestro `DbContext`:

```csharp
using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("your_connection_string")
            .AddInterceptors(new MyCommandInterceptor()); // Registrar el interceptor
    }
}
```

### 3. Consumir el `DbContext`

El interceptor ahora interceptará todas las consultas y comandos SQL que EF Core ejecute mientras usas tu `DbContext`. Por ejemplo:

```csharp
using (var context = new MyDbContext())
{
    var users = context.Users.ToList(); // Aquí el interceptor capturará el comando SQL generado
}
```

## Otros interceptores útiles

- **`SaveChangesInterceptor`**: Este interceptor te permite interceptar el proceso de guardar los cambios en la base de datos, por ejemplo, para realizar validaciones o auditoría.

Ejemplo:

```csharp
public class MySaveChangesInterceptor : SaveChangesInterceptor
{
    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        Console.WriteLine("Cambios guardados en la base de datos");
        return base.SavedChanges(eventData, result);
    }
}
```

## Registro de múltiples interceptores

Puedes registrar múltiples interceptores en el `DbContext` de esta manera:

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder
        .UseSqlServer("your_connection_string")
        .AddInterceptors(new MyCommandInterceptor(), new MySaveChangesInterceptor());
}
```

## Casos de uso comunes para interceptores:

1. **Auditoría**: Puedes usar interceptores para registrar todas las consultas SQL o cambios en las entidades.
2. **Modificación de comandos SQL**: Puedes modificar los comandos SQL antes de que se ejecuten (por ejemplo, para agregar pistas `WITH (NOLOCK)`).
3. **Manejo de errores**: Interceptar y manejar errores o excepciones específicas que ocurren durante la ejecución de comandos SQL.
4. **Registro de transacciones**: Interceptar cuando se inician o completan transacciones para monitorear la coherencia de la base de datos.

## Conclusión

Los interceptores en **Entity Framework Core** son una poderosa herramienta para modificar el comportamiento de EF a nivel de base de datos. Puedes usarlos para personalizar, auditar y ajustar el rendimiento, entre otras funcionalidades.
