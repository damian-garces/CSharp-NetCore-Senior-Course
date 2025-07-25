
# Efficient Strings with Span<T> and StringBuilder

## English

### 🧠 Explanation

When working with strings in C#, it's crucial to consider performance since strings are **immutable**. Each time a string is modified (like through concatenation), a new object is created in memory. This can lead to **heap pressure and unnecessary garbage collection**.

To optimize string handling, you should use tools like `StringBuilder` or `Span<T>`.

---

### 🔧 StringBuilder

`StringBuilder` is perfect when you need to build a dynamic string or concatenate many values, especially within loops.

**Advantages:**

- Uses a mutable buffer.
- Avoids multiple intermediate string allocations.
- Very efficient in large loops.

**Example:**

```csharp
var sb = new StringBuilder();
for (int i = 0; i < 1000; i++)
{
    sb.Append("Line ").Append(i).AppendLine();
}
string result = sb.ToString();
```

---

### 🧵 Span<T>

`Span<T>` provides a type-safe view over contiguous memory, avoiding allocations and preventing unnecessary data copying. It's ideal for slicing, parsing, and efficient transformation.

**Advantages:**

- Operates on existing memory (arrays, strings, etc.).
- High performance.
- Avoids heap allocations by working on the stack.

**Example:**

```csharp
ReadOnlySpan<char> span = "Hello, World!".AsSpan();
ReadOnlySpan<char> hello = span.Slice(0, 5); // "Hello"
ReadOnlySpan<char> world = span.Slice(7, 5); // "World"
```

> `Span<T>` can only be used in synchronous methods, since it cannot be captured or stored in heap-allocated objects.

---

### 🔄 When to use each?

| Scenario                          | Use `StringBuilder` | Use `Span<T>` |
|----------------------------------|----------------------|---------------|
| Concatenation in loops           | ✅                   | 🚫            |
| High-performance text parsing    | 🚫                   | ✅            |
| Partial string reading           | 🚫                   | ✅            |
| Log/report generation            | ✅                   | 🚫            |

---

## Español

### 🧠 Explicación

Cuando trabajamos con manipulación de strings en C#, es importante tener en cuenta el rendimiento y la eficiencia, ya que los strings son **inmutables**. Esto significa que cada vez que modificas un string (por ejemplo, con concatenaciones), se crea un nuevo objeto en memoria, lo cual puede generar **sobreuso del heap y presión en el garbage collector**.

Por eso, se recomienda usar estructuras como `StringBuilder` o `Span<T>` para manejar operaciones complejas o repetitivas con strings.

---

### 🔧 StringBuilder

`StringBuilder` es ideal cuando necesitas concatenar muchas cadenas de texto en ciclos o construir cadenas dinámicas sin crear múltiples objetos intermedios.

**Ventajas:**

- Usa una buffer mutable en memoria.
- No genera objetos temporales como `string + string`.
- Muy eficiente en loops grandes.

**Ejemplo típico:**

```csharp
var sb = new StringBuilder();
for (int i = 0; i < 1000; i++)
{
    sb.Append("Line ").Append(i).AppendLine();
}
string result = sb.ToString();
```

---

### 🧵 Span<T>

`Span<T>` representa una vista contigua de memoria (en stack o heap) que **no implica asignaciones adicionales** y **no crea copias innecesarias de datos**. Es ideal para operaciones de slicing, parsing, y transformación **sin crear objetos nuevos**.

**Ventajas:**

- Trabaja sobre la memoria existente (por ejemplo, arreglos o strings).
- Ideal para procesamiento de alto rendimiento.
- Evita asignaciones en el heap (usa stack).

**Ejemplo con slicing de un string:**

```csharp
ReadOnlySpan<char> span = "Hello, World!".AsSpan();
ReadOnlySpan<char> hello = span.Slice(0, 5); // "Hello"
ReadOnlySpan<char> world = span.Slice(7, 5); // "World"
```

**Importante:** `Span<T>` solo puede usarse dentro de métodos síncronos, ya que no se puede capturar en el heap.

---

### 🔄 ¿Cuándo usar cada uno?

| Escenario                         | Usa `StringBuilder` | Usa `Span<T>` |
|----------------------------------|----------------------|---------------|
| Concatenación en bucles          | ✅                   | 🚫            |
| Parsers de texto de alto rendimiento | 🚫               | ✅            |
| Lectura parcial de strings       | 🚫                   | ✅            |
| Generación de logs o reportes    | ✅                   | 🚫            |
