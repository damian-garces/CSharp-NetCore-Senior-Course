
# ReadOnlyCollection<T> and ReadOnlySpan<T>

## English

### 📌 ReadOnlyCollection<T>

A `ReadOnlyCollection<T>` is a wrapper around an existing collection (e.g., `List<T>`) that prevents direct modification of its items from outside. It is important to note that it is **not immutable** — if the internal list is modified, changes will be reflected in the `ReadOnlyCollection`.

**Advantages:**
- Exposes read-only operations.
- Useful for exposing collections to external components without allowing modification.

**Creation:**
```csharp
var list = new List<int> { 1, 2, 3 };
var readOnly = new ReadOnlyCollection<int>(list);
```

**Important:** If you do `list.Add(4)`, that change **will** be visible in `readOnly`.

---

### 📌 ReadOnlySpan<T>

`ReadOnlySpan<T>` is a structure that provides **efficient and safe** access to immutable data in memory. It helps avoid unnecessary allocations and enables working with memory without copying, making it ideal for text or array manipulation.

**Characteristics:**
- Read-only.
- No heap allocations.
- Commonly used with arrays, strings, or fixed memory blocks.
- Ideal for high-performance operations.

**Simple example:**
```csharp
ReadOnlySpan<char> span = "Hello world".AsSpan(0, 5); // "Hello"
```

---

### 🧠 Does it use memory? Yes, but on the stack

When you create a `ReadOnlySpan<T>` like this:

```csharp
ReadOnlySpan<char> word = sentence.Slice(...);
```

You are allocating a small structure on the **stack**. This includes:

- A reference to the memory block (like a string or array),
- A start position,
- A length.

This does **not copy** data, and it does **not allocate** anything on the heap. It is extremely fast and lightweight. This is a major advantage compared to using `Substring()`, which allocates a new string on the heap.

**Comparison:**

| Operation               | Copies data? | Heap allocation? | Stack usage? | GC pressure? |
|------------------------|--------------|------------------|--------------|--------------|
| `Substring()`          | ✅ Yes       | ✅ Yes           | ❌ No        | ✅ High      |
| `ReadOnlySpan<char>`   | ❌ No        | ❌ No            | ✅ Yes       | ❌ None      |

---

### 🔍 Key Differences

| Feature                 | ReadOnlyCollection<T>           | ReadOnlySpan<T>                          |
|------------------------|----------------------------------|------------------------------------------|
| True immutability      | ❌ (depends on source list)       | ✅                                        |
| Data type              | Any collection                   | Contiguous memory types                  |
| Heap allocations       | ✅                                | ❌ (stack or fixed memory)               |
| Ideal usage            | Exposing collections safely      | Fast memory-based operations             |
| Wrapper required       | ✅                                | ❌                                        |

---

## Español

### 📌 ReadOnlyCollection<T>

Una `ReadOnlyCollection<T>` es una envoltura alrededor de una colección existente, como una `List<T>`, que impide la modificación directa de sus elementos desde fuera. Es importante saber que **no es inmutable**, ya que si se modifica la lista interna, los cambios se verán reflejados en la `ReadOnlyCollection`.

**Ventajas:**
- Expone solo operaciones de lectura.
- Es útil para exponer listas a otros componentes sin permitir modificación.

**Cómo se crea:**
```csharp
var lista = new List<int> { 1, 2, 3 };
var soloLectura = new ReadOnlyCollection<int>(lista);
```

**Importante:** Si haces `lista.Add(4)`, ese cambio **sí se verá** reflejado en `soloLectura`.

---

### 📌 ReadOnlySpan<T>

`ReadOnlySpan<T>` es una estructura que permite acceder de manera **eficiente y segura** a datos inmutables en memoria. Sirve para evitar copias innecesarias y acceder a memoria sin asignaciones adicionales, ideal para manipulación de textos o arrays.

**Características:**
- Solo lectura.
- No genera asignaciones en el heap.
- Se usa comúnmente con arrays, strings o bloques de memoria fijos.
- Es útil en operaciones de alto rendimiento.

**Ejemplo simple:**
```csharp
ReadOnlySpan<char> span = "Hola mundo".AsSpan(0, 4); // "Hola"
```

---

### 🧠 ¿Ocupa memoria? Sí, pero en el stack

Cuando haces algo como:

```csharp
ReadOnlySpan<char> palabra = oracion.Slice(...);
```

Estás creando una estructura pequeña en el **stack**. Esta estructura contiene:

- Una referencia al bloque de memoria (por ejemplo, la cadena original),
- La posición inicial,
- La longitud.

Esto **no copia** los datos y **no asigna** nada en el heap. Es muy rápido y liviano. A diferencia de `Substring()`, que sí crea un nuevo string en el heap.

**Comparación:**

| Operación               | ¿Copia datos? | ¿Asignación en heap? | ¿Uso del stack? | ¿Presión al GC? |
|------------------------|----------------|----------------------|------------------|------------------|
| `Substring()`          | ✅ Sí          | ✅ Sí                | ❌ No            | ✅ Alta           |
| `ReadOnlySpan<char>`   | ❌ No          | ❌ No                | ✅ Sí            | ❌ Nula           |

---

### 🔍 Diferencias claves

| Característica         | ReadOnlyCollection<T>             | ReadOnlySpan<T>                          |
|------------------------|-----------------------------------|------------------------------------------|
| Inmutabilidad real     | ❌ (depende de la lista original) | ✅                                        |
| Tipo de datos          | Cualquier colección                | Tipos contiguos en memoria               |
| Asignaciones en heap   | ✅                                 | ❌ (stack o memoria fija)                |
| Ideal para             | Exponer colecciones sin editar    | Operaciones rápidas con datos en memoria |
| Requiere wrapper       | ✅                                 | ❌                                        |
