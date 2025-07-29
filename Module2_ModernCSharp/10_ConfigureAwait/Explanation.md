
# ConfigureAwait(false)

## English

### 🔍 What is `ConfigureAwait(false)`?

When you use `await` in C#, by default the execution flow attempts to resume on the **same synchronization context** where the asynchronous call was made. This can cause issues especially in UI apps (like WPF or WinForms) or ASP.NET, where that context matters.

The method `ConfigureAwait(false)` is used to **avoid capturing the current synchronization context** after an asynchronous task has completed. This has implications for performance and concurrency.

---

### ✅ Why use `ConfigureAwait(false)`?

1. **Better performance**: Avoiding context capture and restoration reduces overhead.
2. **Prevents deadlocks**: In classic ASP.NET and desktop apps, capturing the context can cause blocking if you use `.Result` or `.Wait()`.
3. **Recommended in libraries**: When writing reusable components, the caller’s context is irrelevant.

---

### ⚠️ When NOT to use it?

- When you **need to resume on the original thread** (e.g., to update UI).
- In ASP.NET Core this is **less critical** because it doesn’t use a SynchronizationContext, but it's still a good practice if you don’t need it.

---

### ✅ Best Practices

- Always use `ConfigureAwait(false)` if you don't need the original context.
- In library or reusable code, apply it consistently.
- Don't use it if you need to access UI elements or `HttpContext` after the `await`.

---

### 🧠 Conceptual Example

```csharp
public async Task<string> GetDataAsync()
{
    var httpClient = new HttpClient();
    var result = await httpClient.GetStringAsync("https://api.example.com/data")
                                 .ConfigureAwait(false);

    // Code continues here without caring which thread it's on.
    return result;
}
```

---

## 🔄 Common Use Cases for `ConfigureAwait(false)`

### 1. **Utility libraries or helper classes**

```csharp
public static class FileHelper
{
    public static async Task<string> ReadFileContentAsync(string path)
    {
        using var reader = new StreamReader(path);
        return await reader.ReadToEndAsync().ConfigureAwait(false);
    }
}
```

---

### 2. **HTTP services consuming APIs**

```csharp
public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetDataAsync(string url)
    {
        var response = await _httpClient.GetAsync(url).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
    }
}
```

---

### 3. **Background services or workers**

```csharp
protected override async Task ExecuteAsync(CancellationToken stoppingToken)
{
    while (!stoppingToken.IsCancellationRequested)
    {
        await DoWorkAsync().ConfigureAwait(false);
        await Task.Delay(1000, stoppingToken).ConfigureAwait(false);
    }
}
```

---

### 4. **File logging or I/O**

```csharp
public async Task SaveLogAsync(string message)
{
    using var writer = new StreamWriter("log.txt", append: true);
    await writer.WriteLineAsync(message).ConfigureAwait(false);
}
```

---

### 5. **Reusable libraries (agnostic of application type)**

When writing general-purpose libraries that may be used across various applications (console, web, UI), always use `ConfigureAwait(false)` unless you explicitly need context.

---

## Español

### 🔍 ¿Qué es `ConfigureAwait(false)`?

Cuando usas `await` en C#, por defecto el flujo de ejecución **intenta reanudarse en el mismo contexto de sincronización** donde se realizó la llamada asincrónica. Esto puede ser problemático especialmente en aplicaciones de UI (como WPF o WinForms) o ASP.NET, donde ese contexto es importante.

El método `ConfigureAwait(false)` se usa para **evitar capturar el contexto de sincronización actual** después de que una tarea asincrónica se haya completado, lo cual tiene implicaciones de rendimiento y concurrencia.

---

### ✅ ¿Por qué usar `ConfigureAwait(false)`?

1. **Mejor rendimiento**: Al evitar capturar y restaurar el contexto, se reduce la sobrecarga.
2. **Evita posibles *deadlocks***: En ASP.NET clásico y aplicaciones de escritorio, capturar el contexto puede provocar bloqueos si usas `.Result` o `.Wait()`.
3. **Recomendado en bibliotecas**: Cuando escribes librerías o componentes reutilizables, normalmente no necesitas el contexto del consumidor.

---

### ⚠️ ¿Cuándo NO usar `ConfigureAwait(false)`?

- En código que **necesita reanudarse en el hilo original** (como actualizaciones de UI).
- En ASP.NET Core **no es tan crítico**, ya que **no usa un SynchronizationContext**, pero sigue siendo buena práctica usarlo si no necesitas el contexto.

---

### ✅ Buenas prácticas

- Siempre que no necesites el contexto de sincronización original, **usa `ConfigureAwait(false)`**.
- En proyectos de librerías, es recomendable aplicarlo en todos los `await`.
- No lo uses si necesitas acceso a elementos de UI o al `HttpContext` después del `await`.

---

### 🧠 Ejemplo conceptual

```csharp
public async Task<string> GetDataAsync()
{
    var httpClient = new HttpClient();
    var result = await httpClient.GetStringAsync("https://api.example.com/data")
                                 .ConfigureAwait(false);

    // Aquí el código continúa sin importar en qué hilo esté.
    return result;
}
```

---

## 🔄 Casos comunes donde se debe usar `ConfigureAwait(false)`

### 1. **Librerías reutilizables o clases de utilidades**

```csharp
public static class FileHelper
{
    public static async Task<string> ReadFileContentAsync(string path)
    {
        using var reader = new StreamReader(path);
        return await reader.ReadToEndAsync().ConfigureAwait(false);
    }
}
```

---

### 2. **Servicios HTTP que consumen APIs**

```csharp
public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetDataAsync(string url)
    {
        var response = await _httpClient.GetAsync(url).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
    }
}
```

---

### 3. **Métodos que se ejecutan en background**

```csharp
protected override async Task ExecuteAsync(CancellationToken stoppingToken)
{
    while (!stoppingToken.IsCancellationRequested)
    {
        await DoWorkAsync().ConfigureAwait(false);
        await Task.Delay(1000, stoppingToken).ConfigureAwait(false);
    }
}
```

---

### 4. **Procesamiento de archivos, logs, o bases de datos**

```csharp
public async Task SaveLogAsync(string message)
{
    using var writer = new StreamWriter("log.txt", append: true);
    await writer.WriteLineAsync(message).ConfigureAwait(false);
}
```

---

### 5. **Código agnóstico al tipo de aplicación**

Si estás escribiendo una librería que será usada tanto en consola como en ASP.NET o UI, **nunca debes asumir que necesitas el contexto original**, así que usa `ConfigureAwait(false)`.

