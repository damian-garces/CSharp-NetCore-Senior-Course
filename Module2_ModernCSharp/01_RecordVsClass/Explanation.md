# record vs class vs record struct

## English

### 📘 `record` vs `class` vs `record struct` in C#

In C#, `record`, `class`, and `record struct` are different ways to define custom types, each with distinct characteristics suitable for specific scenarios.

---

#### 🔹 `class`
- The traditional reference type.
- Stored on the **heap** and passed by **reference**.
- Supports inheritance and polymorphism.
- Ideal for mutable identity entities (e.g., objects that change over time).

```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
```

---

#### 🔹 `record`
- Introduced in C# 9.
- Also a **reference type**, but designed for **immutability** and **value-based comparison**.
- Automatically implements `Equals`, `GetHashCode`, and `ToString()` based on property values.
- Ideal for immutable data models like DTOs, results, or DDD patterns.

```csharp
public record Person(string Name, int Age);
```

- Properties are `init` by default, meaning they can only be set during initialization.
- Can be copied and modified using `with` expressions:

```csharp
var original = new Person("Alice", 30);
var updated = original with { Age = 31 };
```

---

#### 🔹 `record struct`
- Introduced in C# 10.
- A **value type**, like `struct`, but with `record` benefits:
  - Value-based comparison (`Equals`, `GetHashCode`).
  - Recommended immutability (not mandatory).
- Ideal for small, immutable structures that need to be compared by value.
- More memory efficient than `record` since it avoids heap allocation.

```csharp
public readonly record struct Coordinates(double X, double Y);
```

---

#### 🔹 Explicit `record class`

From C# 10 onwards, you can explicitly declare a `record class` for clarity:

```csharp
public record class Employee(string Name, int Id);
```

---

### ⚠️ Considerations and trade-offs
- `record` may not be ideal for mutable or complex inheritance hierarchies.
- Use `class` when mutation or identity-based logic is essential.

---

### 🔍 Summary Comparison

| Feature              | `class`          | `record`             | `record struct`         |
|----------------------|------------------|-----------------------|--------------------------|
| Type                 | Reference         | Reference              | Value                    |
| Immutability         | Optional          | Recommended (init)     | Recommended              |
| Comparison           | By reference      | By value (properties)  | By value (properties)    |
| Inheritance          | Supported         | Supported              | Not supported            |
| Introduced in        | Always available  | C# 9                   | C# 10                    |
| `with` expression    | Not supported     | ✅ Supported            | ✅ Supported              |

---

### 🔄 `record` vs `record class`

From C# 9 onwards, writing `record` by default creates a **reference type**, equivalent to `record class`. But starting in C# 10, you can write `record class` explicitly for clarity. Here's the comparison:

| Syntax                        | Actual Type     | Introduced In | Notes                             |
|------------------------------|------------------|----------------|------------------------------------|
| `record`                     | `record class`   | C# 9           | Defaults to reference type        |
| `record class`               | `record class`   | C# 10          | Explicit reference type           |
| `record struct`              | `record struct`  | C# 10          | Value type with record semantics  |

---

## Español

### 📘 `record` vs `class` vs `record struct` en C#

En C#, `record`, `class` y `record struct` son formas de definir tipos personalizados, pero cada uno tiene características únicas que los hacen apropiados para diferentes escenarios.

---

#### 🔹 `class`
- Es el tipo de referencia tradicional.
- Se almacena en el **heap** y se pasa por **referencia**.
- Soporta herencia y polimorfismo.
- Ideal para entidades con identidad mutable (por ejemplo: objetos que cambian con el tiempo).

```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
```

---

#### 🔹 `record`
- Introducido en C# 9.
- Es también un **tipo de referencia**, pero está diseñado para **inmutabilidad** y **comparación estructural**.
- Tiene una implementación por defecto de `Equals`, `GetHashCode` y `ToString()` basada en los valores de sus propiedades.
- Ideal para modelos de datos inmutables como DTOs, resultados, o patrones DDD.

```csharp
public record Person(string Name, int Age);
```

- Las propiedades por defecto son `init`, lo que significa que solo pueden establecerse en la inicialización.
- Se pueden crear copias modificadas fácilmente usando `with`:

```csharp
var original = new Person("Alice", 30);
var updated = original with { Age = 31 };
```

---

#### 🔹 `record struct`
- Introducido en C# 10.
- Es un **tipo por valor**, como `struct`, pero con las ventajas de los `record`:
  - Comparación por valor (`Equals` y `GetHashCode`).
  - Inmutabilidad recomendada (aunque no obligatoria).
- Ideal para estructuras pequeñas que no deben cambiar y que se comparan por contenido.
- Más eficiente en memoria que un `record` porque evita la asignación en el heap.

```csharp
public readonly record struct Coordinates(double X, double Y);
```

---

#### 🔹 `record class` explícito

Desde C# 10 se puede usar `record class` explícitamente para mayor claridad:

```csharp
public record class Employee(string Name, int Id);
```

---

### ⚠️ Consideraciones y advertencias
- `record` no es ideal cuando necesitas mutabilidad o una jerarquía compleja de herencia.
- Usa `class` cuando la lógica depende de la identidad del objeto y este puede cambiar.

---

### 🔍 Comparación resumida

| Característica       | `class`          | `record`             | `record struct`         |
|----------------------|------------------|-----------------------|--------------------------|
| Tipo                 | Referencia       | Referencia            | Valor                    |
| Inmutabilidad        | Opcional         | Recomendada (init)    | Recomendada              |
| Comparación          | Por referencia   | Por valor (propiedades) | Por valor (propiedades) |
| Herencia             | Soportada        | Soportada             | No soportada             |
| Introducido en       | Desde siempre    | C# 9                  | C# 10                    |
| Expresión `with`     | No soportada     | ✅ Soportada           | ✅ Soportada              |
---

### 🔄 `record` vs `record class`

Desde C# 9, al escribir `record` estás creando por defecto un tipo de **referencia**, equivalente a `record class`. A partir de C# 10, puedes usar `record class` explícitamente para dejar clara tu intención:

| Sintaxis                     | Tipo real        | Desde versión | Comentarios                       |
|-----------------------------|------------------|----------------|------------------------------------|
| `record`                    | `record class`   | C# 9           | Por defecto es tipo referencia    |
| `record class`              | `record class`   | C# 10          | Intención explícita               |
| `record struct`             | `record struct`  | C# 10          | Tipo por valor con semántica de record |
