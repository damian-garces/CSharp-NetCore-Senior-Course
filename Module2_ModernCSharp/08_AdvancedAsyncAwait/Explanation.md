
# Advanced async/await in C#

## English

### 1. What is async/await and how does the compiler transform it?

The `async` modifier enables the use of the `await` keyword, which the compiler transforms into a state machine that manages the asynchronous flow. The compiler generates a class that implements `IAsyncStateMachine` and breaks the code into discrete steps.

**Example:**
```csharp
public async Task<string> GetDataAsync()
{
    var response = await httpClient.GetStringAsync("https://example.com");
    return response;
}
```
This is internally translated into something similar to:
```csharp
var task = httpClient.GetStringAsync("https://example.com");
task.ContinueWith(t =>
{
    var response = t.Result;
    return response;
});
```

---

### 2. What can you actually `await`?

Anything that provides a `GetAwaiter()` method is awaitable. This includes `Task`, `ValueTask`, and custom types that implement the pattern.

---

### 3. Continuations and SynchronizationContext

The context determines where the continuation after `await` executes.

- UI apps: continue on the UI thread.
- ASP.NET (non-Core): continue on request thread.
- Console/ASP.NET Core: no context, resumes on thread pool.

Use `ConfigureAwait(false)` to avoid deadlocks in library code.

---

### 4. Fire and Forget

Avoid `async void` unless in event handlers. For fire-and-forget logic, wrap the task and catch exceptions.

```csharp
_ = Task.Run(async () =>
{
    try { await ProcessAsync(); }
    catch (Exception ex) { Log(ex); }
});
```

---

### 5. Exception Handling

Exceptions inside async methods are wrapped inside the Task and only thrown when awaited.

Avoid:
```csharp
DoSomethingAsync(); // unobserved exception
```

Use:
```csharp
await DoSomethingAsync();
```

---

### 6. Best Practices & Anti-patterns

Avoid:
- `.Result`, `.Wait()`
- `async void`
- Forgetting `ConfigureAwait(false)`
- Ignoring tasks without handling

Best practices:
- Use `CancellationToken`
- Handle multiple tasks with `Task.WhenAll`
- Use exception-safe patterns when fire-and-forget

---

### 7. Visual Comparison

**Synchronous (bad):**
```csharp
var result = httpClient.GetStringAsync(url).Result;
```

**Asynchronous (good):**
```csharp
var result = await httpClient.GetStringAsync(url);
```

---

## Español

### 1. ¿Qué es async/await y cómo lo transforma el compilador?

El modificador `async` permite usar `await`, que el compilador transforma en una máquina de estados. Se genera una clase que implementa `IAsyncStateMachine`.

**Ejemplo:**
```csharp
public async Task<string> GetDataAsync()
{
    var response = await httpClient.GetStringAsync("https://example.com");
    return response;
}
```

Internamente se traduce en algo como:
```csharp
var task = httpClient.GetStringAsync("https://example.com");
task.ContinueWith(t =>
{
    var response = t.Result;
    return response;
});
```

---

### 2. ¿Qué se puede `await`?

Todo tipo que implemente `GetAwaiter()` es `awaitable`: `Task`, `ValueTask`, o tipos personalizados.

---

### 3. Continuations y SynchronizationContext

Determina dónde se ejecuta el código después de `await`.

- UI: hilo de UI.
- ASP.NET: hilo de request.
- Consola/ASP.NET Core: thread pool.

Usa `ConfigureAwait(false)` para evitar deadlocks en librerías.

---

### 4. Fire and Forget

Evita `async void` salvo en eventos. Usa envoltura con `try/catch`:

```csharp
_ = Task.Run(async () =>
{
    try { await ProcessAsync(); }
    catch (Exception ex) { Log(ex); }
});
```

---

### 5. Manejo de Excepciones

Las excepciones se capturan en la `Task` y se lanzan solo cuando haces `await`.

Evita:
```csharp
DoSomethingAsync(); // excepción no observada
```

Mejor:
```csharp
await DoSomethingAsync();
```

---

### 6. Buenas prácticas y anti-patrones

Evita:
- `.Result`, `.Wait()`
- `async void`
- Ignorar tareas
- No usar `ConfigureAwait(false)`

Buenas prácticas:
- Usa `CancellationToken`
- Usa `Task.WhenAll` correctamente
- Maneja excepciones en fire-and-forget

---

### 7. Comparación Visual

**Sincrónico (malo):**
```csharp
var result = httpClient.GetStringAsync(url).Result;
```

**Asíncrono (bueno):**
```csharp
var result = await httpClient.GetStringAsync(url);
```
