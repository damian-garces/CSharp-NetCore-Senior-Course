# List<T>, Dictionary<TKey, TValue>, HashSet<T>, Queue<T>, Stack<T>

## English

### Introduction

In .NET, generic collections like `List<T>`, `Dictionary<TKey, TValue>`, `HashSet<T>`, `Queue<T>`, and `Stack<T>` are optimized for different scenarios. Below is a breakdown of each one.

---

### 1. `List<T>`

- Ordered collection of elements of the same type.
- Allows indexed access.
- Ideal when you need a dynamically growing list.

**Example:**
```csharp
var numbers = new List<int> { 1, 2, 3 };
numbers.Add(4);
int first = numbers[0];
```

---

### 2. `Dictionary<TKey, TValue>`

- Key-value pair collection.
- Keys must be unique.
- Provides fast access via key.

**Example:**
```csharp
var ages = new Dictionary<string, int>();
ages["Alice"] = 30;
int age = ages["Alice"];
```

---

### 3. `HashSet<T>`

- Stores unique elements, no duplicates allowed.
- Useful for fast lookups and eliminating duplicates.

**Example:**
```csharp
var uniqueNumbers = new HashSet<int> { 1, 2, 2, 3 };
Console.WriteLine(uniqueNumbers.Count); // 3
```

---

### 4. `Queue<T>`

- FIFO (First In, First Out) collection.
- Used when processing elements in the order they are added.

**Example:**
```csharp
var queue = new Queue<string>();
queue.Enqueue("first");
queue.Enqueue("second");
Console.WriteLine(queue.Dequeue()); // "first"
```

---

### 5. `Stack<T>`

- LIFO (Last In, First Out) collection.
- Ideal when you need to access the last added element first.

**Example:**
```csharp
var stack = new Stack<string>();
stack.Push("last");
stack.Push("new");
Console.WriteLine(stack.Pop()); // "new"
```

---

### Comparison Table

| Collection     | Ordered | Duplicates | Fast Access | Typical Use                  |
|----------------|---------|------------|-------------|------------------------------|
| List<T>        | Yes     | Yes        | By index    | List of items                |
| Dictionary     | N/A     | No (key)   | By key      | Key-value mappings           |
| HashSet<T>     | No      | No         | Fast lookup | Unique sets                  |
| Queue<T>       | Yes     | Yes        | FIFO        | Order processing             |
| Stack<T>       | Yes     | Yes        | LIFO        | Undo, reverse navigation     |

---

### Big O Complexity

| Operation      | List<T>       | Dictionary       | HashSet         | Queue       | Stack       |
|----------------|---------------|------------------|------------------|-------------|-------------|
| Add            | O(1) amortized| O(1)              | O(1)             | O(1)        | O(1)        |
| Remove         | O(n)          | O(1)              | O(1)             | O(1)        | O(1)        |
| Contains       | O(n)          | O(1)              | O(1)             | O(n)        | O(n)        |
| Direct Access  | O(1) by index | O(1) by key       | N/A              | N/A         | N/A         |

---

### Real Use Cases

- **List<T>**: When order matters and size is dynamic.
- **Dictionary**: When you need fast lookups by a unique key.
- **HashSet**: When you want to avoid duplicates.
- **Queue**: Background jobs, printing queues, messaging systems.
- **Stack**: Undo functionality, parsers, backtracking algorithms.

---

### Limitations and Warnings

- `Dictionary` throws an exception when accessing a non-existent key unless using `TryGetValue`.
- `HashSet<T>` relies on proper implementation of `Equals` and `GetHashCode`.
- `List<T>.Remove()` can be costly on long lists.

---

## Español

### Introducción

En .NET, las colecciones genéricas como `List<T>`, `Dictionary<TKey, TValue>`, `HashSet<T>`, `Queue<T>` y `Stack<T>` están optimizadas para distintos escenarios. A continuación, se explican cada una.

---

### 1. `List<T>`

- Colección ordenada de elementos del mismo tipo.
- Permite acceso por índice.
- Ideal cuando necesitas una lista que crece dinámicamente.

**Ejemplo:**
```csharp
var numbers = new List<int> { 1, 2, 3 };
numbers.Add(4);
int first = numbers[0];
```

---

### 2. `Dictionary<TKey, TValue>`

- Colección de pares clave-valor.
- La clave debe ser única.
- Proporciona acceso rápido por clave.

**Ejemplo:**
```csharp
var ages = new Dictionary<string, int>();
ages["Alice"] = 30;
int age = ages["Alice"];
```

---

### 3. `HashSet<T>`

- Almacena elementos únicos, no permite duplicados.
- Útil para búsquedas rápidas y eliminar duplicados.

**Ejemplo:**
```csharp
var uniqueNumbers = new HashSet<int> { 1, 2, 2, 3 };
Console.WriteLine(uniqueNumbers.Count); // 3
```

---

### 4. `Queue<T>`

- Colección FIFO (Primero en entrar, primero en salir).
- Se usa cuando necesitas procesar elementos en orden de inserción.

**Ejemplo:**
```csharp
var queue = new Queue<string>();
queue.Enqueue("primero");
queue.Enqueue("segundo");
Console.WriteLine(queue.Dequeue()); // "primero"
```

---

### 5. `Stack<T>`

- Colección LIFO (Último en entrar, primero en salir).
- Ideal cuando necesitas acceder primero al último elemento agregado.

**Ejemplo:**
```csharp
var stack = new Stack<string>();
stack.Push("último");
stack.Push("nuevo");
Console.WriteLine(stack.Pop()); // "nuevo"
```

---

### Comparación rápida

| Colección      | Ordenada | Duplicados | Acceso rápido | Uso típico                    |
|----------------|----------|------------|----------------|-------------------------------|
| List<T>        | Sí       | Sí         | Por índice     | Lista de elementos            |
| Dictionary     | N/A      | No (clave) | Por clave      | Mapeo de claves y valores     |
| HashSet<T>     | No       | No         | Búsqueda rápida| Conjuntos únicos              |
| Queue<T>       | Sí       | Sí         | FIFO           | Procesamiento en orden        |
| Stack<T>       | Sí       | Sí         | LIFO           | Deshacer, navegación inversa  |

---

### Complejidad algorítmica (Big O)

| Operación       | List<T>        | Dictionary       | HashSet          | Queue        | Stack       |
|------------------|----------------|------------------|------------------|--------------|-------------|
| Agregar          | O(1) amortizado| O(1)              | O(1)              | O(1)         | O(1)        |
| Eliminar         | O(n)           | O(1)              | O(1)              | O(1)         | O(1)        |
| Contiene         | O(n)           | O(1)              | O(1)              | O(n)         | O(n)        |
| Acceso directo   | O(1) por índice| O(1) por clave    | No aplica         | No aplica    | No aplica   |

---

### Casos de uso reales

- **List<T>**: Cuando el orden importa y el tamaño no es fijo.
- **Dictionary**: Cuando necesitas búsquedas rápidas por clave.
- **HashSet**: Cuando quieres evitar duplicados.
- **Queue**: Procesos en background, colas de impresión, sistemas de mensajes.
- **Stack**: Funcionalidad de deshacer, parsers, algoritmos de backtracking.

---

### Limitaciones y advertencias

- `Dictionary` lanza excepción si accedes a una clave inexistente (salvo que uses `TryGetValue`).
- `HashSet<T>` depende de una buena implementación de `Equals` y `GetHashCode`.
- `List<T>.Remove()` puede ser costoso en listas largas.