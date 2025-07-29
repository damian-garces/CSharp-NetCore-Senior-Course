
# IAsyncEnumerable<T> and await foreach

## English

### What is IAsyncEnumerable<T>?

`IAsyncEnumerable<T>` is an interface introduced in C# 8.0 that allows asynchronous enumeration of collections. It addresses a common problem in applications that need to process streams of data retrieved asynchronously, such as from databases, APIs, or file systems.

### Why use IAsyncEnumerable<T>?

When using `Task<List<T>>`, you must wait until the entire list is fully available before iterating over it. With `IAsyncEnumerable<T>`, you can start processing elements as they arrive, without blocking the main thread.

### Key Concepts

- **IAsyncEnumerable<T>**: Represents an asynchronous sequence of data.
- **await foreach**: A new syntax that allows iterating over `IAsyncEnumerable<T>` using `await`.

### Advantages

- Enables **streaming processing** of large data sets.
- More **efficient use of resources** (memory and CPU).
- Ideal for **I/O-bound operations** like reading files or paginated queries.

### Simple Example

```csharp
public async IAsyncEnumerable<int> GetNumbersAsync()
{
    for (int i = 0; i < 5; i++)
    {
        await Task.Delay(500); // Simulate async operation
        yield return i;
    }
}
```

Consumption:

```csharp
await foreach (var number in GetNumbersAsync())
{
    Console.WriteLine(number);
}
```

### Common Use Cases

1. **Reading from databases (EF Core)** with `AsAsyncEnumerable()` for streaming large result sets.
2. **Reading large files line by line** using `StreamReader.ReadLineAsync()` with `yield return`.
3. **Calling paginated APIs** and returning results as they arrive.
4. **Data pipelines or ETLs** for processing in stages (read → transform → store).
5. **Listening to message queues** like RabbitMQ or Azure Service Bus.
6. **Heavy I/O network operations** like web scraping or socket streams.
7. **Generating dynamic data** (e.g., producing file content in real-time).

### Practical Tips

- ✅ Use when the data size is large or unknown.
- ✅ Combine with `await foreach` for cleaner and efficient async iteration.
- ✅ Implement `CancellationToken` for graceful cancellation.
- ❌ Avoid using it for small collections where `List<T>` or `IEnumerable<T>` would be simpler.
- ✅ Ideal when the producer is async and data arrives in stages.

### Comparison Table

| Feature                      | IEnumerable<T>         | List<T>                  | IAsyncEnumerable<T>      |
|-----------------------------|------------------------|--------------------------|---------------------------|
| Deferred evaluation         | ✅                      | ❌                        | ✅ (asynchronous)         |
| Requires full collection    | ❌                      | ✅                        | ❌                         |
| Async iteration             | ❌                      | ❌                        | ✅                         |
| Supports `await foreach`    | ❌                      | ❌                        | ✅                         |

---

## Español

### ¿Qué es IAsyncEnumerable<T>?

`IAsyncEnumerable<T>` es una interfaz introducida en C# 8.0 que permite la enumeración asincrónica de colecciones. Resuelve un problema común en aplicaciones que necesitan trabajar con flujos de datos que se obtienen de manera asincrónica, como bases de datos, archivos o APIs.

### ¿Por qué usar IAsyncEnumerable<T>?

Cuando usas `Task<List<T>>`, debes esperar a que toda la lista esté disponible antes de poder recorrerla. Con `IAsyncEnumerable<T>`, puedes comenzar a procesar los elementos a medida que llegan, sin bloquear el hilo principal.

### Conceptos clave

- **IAsyncEnumerable<T>**: Representa una secuencia de datos que se puede recorrer de forma asincrónica.
- **await foreach**: Sintaxis que permite recorrer `IAsyncEnumerable<T>` usando `await`.

### Ventajas

- Permite el **procesamiento en streaming** de grandes cantidades de datos.
- Uso más **eficiente de recursos** (memoria y CPU).
- Ideal para operaciones de **entrada/salida intensiva** como lectura de archivos o consultas paginadas.

### Ejemplo simple

```csharp
public async IAsyncEnumerable<int> GetNumbersAsync()
{
    for (int i = 0; i < 5; i++)
    {
        await Task.Delay(500); // Simula una operación asincrónica
        yield return i;
    }
}
```

Consumo:

```csharp
await foreach (var number in GetNumbersAsync())
{
    Console.WriteLine(number);
}
```

### Casos de uso comunes

1. **Lectura desde bases de datos (EF Core)** con `AsAsyncEnumerable()` para recorrer grandes volúmenes de datos.
2. **Lectura de archivos grandes línea por línea** usando `StreamReader.ReadLineAsync()` y `yield return`.
3. **Consumo de APIs paginadas** devolviendo resultados a medida que llegan.
4. **ETLs o pipelines de datos** para procesamiento por etapas.
5. **Recepción de mensajes en colas** como RabbitMQ o Azure Service Bus.
6. **Operaciones de red intensivas en I/O** como scrapers o sockets.
7. **Generación de datos dinámicos**, por ejemplo, archivos generados en tiempo real.

### Consejos prácticos

- ✅ Úsalo cuando el número de elementos es grande o indefinido.
- ✅ Combínalo con `await foreach` para mejor legibilidad y eficiencia.
- ✅ Implementa `CancellationToken` para cancelación controlada.
- ❌ Evita usarlo para colecciones pequeñas donde un `List<T>` o `IEnumerable<T>` sería suficiente.
- ✅ Ideal cuando el productor es asincrónico y los datos llegan por partes.

### Tabla comparativa

| Característica              | IEnumerable<T>         | List<T>                  | IAsyncEnumerable<T>      |
|----------------------------|------------------------|--------------------------|---------------------------|
| Evaluación diferida        | ✅                      | ❌                        | ✅ (asincrónica)           |
| Requiere toda la colección | ❌                      | ✅                        | ❌                         |
| Iteración asíncrona        | ❌                      | ❌                        | ✅                         |
| Soporta `await foreach`    | ❌                      | ❌                        | ✅                         |
