
# System.Collections.Immutable: ImmutableList<T>, ImmutableArray<T>

## English

### What are immutable collections?
Immutable collections cannot be modified after creation. Any operation that seems to modify the collection actually returns a **new instance**, leaving the original untouched. This is especially useful in multithreaded environments and in functional programming styles where predictability is key.

### Main Advantages:
- **Thread safety**: No need for locks when reading or sharing the collection.
- **Predictability**: Immutable structures help avoid side effects.
- **Functional programming friendly**: Ideal for pure functions and immutability paradigms.

### Key Types:
- `ImmutableList<T>`: An ordered list. Methods like `Add`, `Remove`, and `Replace` return a new list instance.
- `ImmutableArray<T>`: Fixed-size, value-like structure. More memory-efficient than ImmutableList for large data and high performance.

### Comparison with mutable types:

| Feature                   | List<T> / Array       | ImmutableList<T> / ImmutableArray<T> |
|---------------------------|-----------------------|--------------------------------------|
| Mutability                | Yes                   | No                                   |
| Thread safety             | No (needs sync)       | Yes                                  |
| In-place changes          | Yes                   | No (creates a new instance)          |
| Functional friendly       | Limited               | Ideal                                |

### Basic Example:

```csharp
using System.Collections.Immutable;

var list = ImmutableList.Create<string>("apple", "banana");
var newList = list.Add("cherry");

Console.WriteLine(string.Join(", ", list));     // Output: apple, banana
Console.WriteLine(string.Join(", ", newList));  // Output: apple, banana, cherry
```

### Performance Note – Why Builder is Better

If you do this:

```csharp
var list = ImmutableList<int>.Empty;
for (int i = 0; i < 1000; i++)
{
    list = list.Add(i); // Creates a new list every time
}
```

You're creating **1000 new lists**, which impacts performance.

Instead, use a builder:

```csharp
var builder = ImmutableList.CreateBuilder<int>();
for (int i = 0; i < 1000; i++)
{
    builder.Add(i); // No new instance created
}
ImmutableList<int> finalList = builder.ToImmutable(); // Only one immutable instance created
```

| Approach                         | What Happens Internally            | Performance |
|----------------------------------|------------------------------------|-------------|
| `list = list.Add(i)`             | New list created each iteration    | Low         |
| `builder.Add(i)` + `.ToImmutable()` | Efficient, mutable until the end | High        |

---

## Español

### ¿Qué son las colecciones inmutables?
Las colecciones inmutables no pueden ser modificadas después de su creación. Cualquier operación que “modifique” una colección en realidad devuelve una **nueva instancia** con los cambios aplicados, dejando intacta la colección original. Esto es útil para garantizar seguridad en entornos concurrentes, y para mantener un diseño funcional y predecible.

### Ventajas principales:
- **Seguridad en concurrencia:** No se necesita sincronización para leer/usar la colección.
- **Previsibilidad:** Las estructuras inmutables reducen errores por efectos colaterales.
- **Facilidad en programación funcional:** Se alinea con paradigmas como el uso de expresiones puras y sin efectos secundarios.

### Tipos principales:
- `ImmutableList<T>`: Lista ordenada, con métodos como `Add`, `Remove`, `Insert`, `Replace`, etc. Todos estos devuelven una nueva lista.
- `ImmutableArray<T>`: Similar a un arreglo fijo pero inmutable, ideal para alto rendimiento y menor uso de memoria en estructuras inmutables.

### Comparación con estructuras mutables:

| Característica             | List<T> / Array       | ImmutableList<T> / ImmutableArray<T> |
|---------------------------|-----------------------|--------------------------------------|
| Mutabilidad               | Sí                    | No                                   |
| Hilos seguros             | No sin sincronización | Sí                                   |
| Cambio directo            | Sí                    | No (requiere nueva instancia)        |
| Uso en programación funcional | Limitado           | Ideal                                |

### Ejemplo básico:

```csharp
using System.Collections.Immutable;

var list = ImmutableList.Create<string>("apple", "banana");
var newList = list.Add("cherry");

Console.WriteLine(string.Join(", ", list));     // Output: apple, banana
Console.WriteLine(string.Join(", ", newList));  // Output: apple, banana, cherry
```

### Rendimiento – ¿Por qué Builder es mejor?

Si haces esto:

```csharp
var list = ImmutableList<int>.Empty;
for (int i = 0; i < 1000; i++)
{
    list = list.Add(i); // Se crea una nueva lista en cada iteración
}
```

Estás creando **1000 nuevas listas**, lo que impacta negativamente en el rendimiento.

En su lugar, usa un builder:

```csharp
var builder = ImmutableList.CreateBuilder<int>();
for (int i = 0; i < 1000; i++)
{
    builder.Add(i); // No se crean nuevas instancias
}
ImmutableList<int> finalList = builder.ToImmutable(); // Solo se genera una instancia inmutable al final
```

| Enfoque                        | ¿Qué pasa internamente?                           | Rendimiento |
|-------------------------------|---------------------------------------------------|-------------|
| `list = list.Add(i)`          | Se crea una nueva lista en cada iteración         | Bajo        |
| `builder.Add(i)` + `.ToImmutable()` | Se usa estructura mutable y se inmutabiliza una vez | Alto        |
