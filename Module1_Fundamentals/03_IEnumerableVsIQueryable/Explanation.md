# Differences between IEnumerable, IQueryable, ICollection, IList, and List

## English

### ⏳ What is deferred execution?

**Deferred execution** means that an operation is **not executed immediately** when it is declared, but rather **when the collection is iterated**, such as with a `foreach`, `ToList()`, etc.

This allows you to build a query step by step, but the actual evaluation occurs **only when the final result is needed**.

**Example:**

```csharp
var query = users.Where(u => u.IsActive); // Not executed yet
var list = query.ToList();                // Executed here
```

---

### 🔹 IEnumerable

- Basic interface for a collection that can be iterated.
- **Immutable**: does not allow adding or removing items.
- Uses **deferred execution**: filters or projections are applied only when data is accessed.
- Great for **sequential reading**.
- Does not expose methods to modify the collection.

**Example:** using `.Where(...)` on a list.

---

### 🔹 IQueryable

- Inherits from `IEnumerable<T>`.
- Enables building expressions that can be translated (e.g., into SQL).
- Also supports **deferred execution**, optimized for remote data sources.
- Commonly used with **Entity Framework** or LINQ to SQL.
- Allows server-side execution of `Where`, `Select`, `Join`, etc.

**Example:** `dbContext.Users.Where(u => u.IsActive)`

---

### 🔹 ICollection

- Inherits from `IEnumerable<T>`.
- Provides methods to **add**, **remove**, **count**, and check if an item exists.
- Represents a **modifiable** collection.
- Serves as the base for most .NET collections.

---

### 🔹 IList

- Inherits from `ICollection<T>`.
- Adds **index-based access** and modification.
- Supports adding, removing, and updating elements by index.

---

### 🔹 List

- Concrete implementation of `IList<T>`.
- Fully supports all modification and access operations.
- Optimized for performance in memory.
- A common choice for flexible lists.

---

### 🧠 When to use each one?

| Interface/Class | Main Use Case                                 |
| --------------- | --------------------------------------------- |
| `IEnumerable`   | Simple sequential read, LINQ in memory        |
| `IQueryable`    | Remote data queries (e.g., databases)         |
| `ICollection`   | Need to add/remove items without index access |
| `IList`         | Need index-based access and modification      |
| `List<T>`       | In-memory flexible list with full features    |

---

# Diferencias entre IEnumerable, IQueryable, ICollection, IList y List

## Español

### ⏳ ¿Qué es la ejecución diferida?

La **ejecución diferida** significa que una operación **no se ejecuta inmediatamente** al declararse, sino **cuando se itera sobre la colección**, por ejemplo con `foreach`, `ToList()`, etc.

Esto permite construir una consulta paso a paso sin que se evalúe en cada línea, sino solo **cuando realmente se necesita el resultado final**.

**Ejemplo:**

```csharp
var query = users.Where(u => u.IsActive); // No se ejecuta aún
var list = query.ToList();                // Aquí se ejecuta realmente
```

---

### 🔹 IEnumerable

- Es la interfaz más básica para una colección que puede recorrerse (`foreach`).
- Es **inmutable**: no permite agregar ni eliminar elementos.
- Su ejecución es **diferida**.
- Ideal para **lectura secuencial**.
- No expone métodos para modificar la colección.

**Ejemplo común:** cuando haces una consulta LINQ como `.Where(...)` sobre una lista.

---

### 🔹 IQueryable

- Hereda de `IEnumerable<T>`.
- Permite construir expresiones que luego se traducen (por ejemplo, a SQL).
- Su ejecución también es **diferida**.
- Utilizada con **Entity Framework** o **LINQ to SQL**.
- Permite que filtros como `Where` se ejecuten en el servidor.

**Ejemplo:** `dbContext.Users.Where(u => u.IsActive)`

---

### 🔹 ICollection

- Hereda de `IEnumerable<T>`.
- Proporciona métodos para **agregar**, **eliminar**, **contar** y verificar existencia.
- Representa una colección **modificable**.
- Base de muchas colecciones en .NET.

---

### 🔹 IList

- Hereda de `ICollection<T>`.
- Permite acceso **por índice**.
- Puedes agregar, quitar y modificar elementos por índice.

---

### 🔹 List

- Implementación concreta de `IList<T>`.
- Soporta completamente todas las operaciones de modificación y acceso.
- Optimizada para rendimiento en memoria.
- Comúnmente usada por su flexibilidad.

---

### 🧠 ¿Cuándo usar cada una?

| Interfaz/Clase | Uso principal                                         |
| -------------- | ----------------------------------------------------- |
| `IEnumerable`  | Lectura secuencial simple y LINQ en memoria           |
| `IQueryable`   | Consultas a fuentes de datos remotas (bases de datos) |
| `ICollection`  | Agregar/quitar elementos sin acceso por índice        |
| `IList`        | Acceso por índice y modificación                      |
| `List<T>`      | Lista flexible en memoria con todas las funciones     |

