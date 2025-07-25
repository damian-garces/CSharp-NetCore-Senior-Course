# LINQ Materialization: ToList(), ToArray(), First()

## 🟦 English

### What is materialization?

Materialization in LINQ refers to the process of evaluating a deferred query and converting its results into a concrete in-memory collection. This ends deferred execution and stores the results for further use.

### Common Materialization Methods

| Method             | Return Type     | When to Use |
|--------------------|------------------|--------------|
| `ToList()`         | `List<T>`        | When you need a mutable list to iterate, modify, or reuse multiple times. |
| `ToArray()`        | `T[]`            | When you prefer an array for performance or interoperability. |
| `First()`          | `T`              | When you need only the first element of the sequence. Throws if the sequence is empty. |
| `FirstOrDefault()` | `T`              | Returns the first element or default value if the sequence is empty. |

### ToList() vs ToArray(): Performance and Interoperability

| Criterion           | `ToList()`                             | `ToArray()`                            |
|---------------------|-----------------------------------------|-----------------------------------------|
| **Mutability**      | Mutable list (`Add`, `Remove`, etc.)    | Fixed-size array                        |
| **Performance**     | Slightly slower (dynamic allocations)   | Generally faster, especially for index access |
| **Memory**          | May incur overhead due to dynamic growth | More efficient: fixed-size allocation   |
| **Interoperability**| Less ideal for low-level or legacy APIs | Great for APIs expecting `T[]`          |
| **Typical Use**     | When future modification is needed       | For high performance, no modification   |

### Practical Example

```csharp
var numbers = Enumerable.Range(1, 1000000);

var list = numbers.ToList();     // Mutable
var array = numbers.ToArray();   // Better performance if no modifications

var first = list.First();        
var second = array[1];           // Faster direct access
```

### Best Practices

- Use `ToArray()` when you need performance and will not modify the collection.
- Use `ToList()` when you need to modify the collection or pass it to a method expecting a `List<T>`.
- Avoid materializing large collections unnecessarily if you only need a subset.

---

## 🟧 Español

### ¿Qué es la materialización?

La materialización en LINQ se refiere al proceso de ejecutar una consulta diferida y convertir sus resultados en una estructura concreta de datos en memoria, como una lista o un arreglo. Esto detiene la ejecución diferida y almacena el resultado para su reutilización.

### Métodos comunes de materialización

| Método               | Tipo de retorno | Características |
|----------------------|------------------|------------------|
| `ToList()`           | `List<T>`        | Crea una lista mutable que puede ser modificada. Ideal para escenarios donde se necesite agregar o eliminar elementos. |
| `ToArray()`          | `T[]`            | Crea un arreglo de tamaño fijo, más eficiente en memoria y velocidad para acceso por índice o interoperabilidad. |
| `First()`            | `T`              | Devuelve el primer elemento. Lanza excepción si la colección está vacía. |
| `FirstOrDefault()`   | `T`              | Devuelve el primer elemento o valor por defecto (`default(T)`) si la colección está vacía. |

### Comparación: `ToList()` vs `ToArray()`

| Criterio              | `ToList()`                            | `ToArray()`                           |
|-----------------------|----------------------------------------|----------------------------------------|
| **Mutabilidad**       | Lista mutable (`Add`, `Remove`, etc.) | Arreglo inmutable en tamaño            |
| **Rendimiento**       | Ligeramente más lento (asignaciones dinámicas) | Más rápido en muchos casos, especialmente en acceso directo |
| **Memoria**           | Puede tener overhead al crecer dinámicamente | Más eficiente: tamaño fijo desde el inicio |
| **Interoperabilidad** | No tan compatible con APIs antiguas o de bajo nivel | Ideal para interoperar con APIs que esperan arreglos (`T[]`) |
| **Uso común**         | Uso general, modificaciones posteriores | Escenarios donde no se modificará y se necesita performance |

### Ejemplo práctico

```csharp
var numeros = Enumerable.Range(1, 1000000);

// Materialización
var lista = numeros.ToList();  // Uso común, se puede modificar
var arreglo = numeros.ToArray(); // Mejor rendimiento si no necesitas modificar

// Acceso a datos
var primero = lista.First(); 
var segundo = arreglo[1]; // Acceso directo más rápido
```

### Buenas prácticas

- Usa `ToArray()` cuando necesites rendimiento y no planees modificar la colección.
- Usa `ToList()` cuando necesites modificar la colección o pasarla a un método que espera una `List<T>`.
- Evita materializar grandes colecciones si solo necesitas una parte (`Take`, `First`, etc.).