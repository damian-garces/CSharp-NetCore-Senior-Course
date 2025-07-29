
# dynamic vs var and Runtime Resolution

## English

### Overview

In C#, both `var` and `dynamic` allow variable declaration without explicitly stating the type. However, there are **fundamental differences** between them, mainly related to **when the type is resolved** and **how they behave at compile-time vs. runtime**.

---

### 🔍 Key Differences

| Feature                  | `var`                       | `dynamic`                              |
|--------------------------|-----------------------------|-----------------------------------------|
| Type resolution          | Compile-time                | Runtime                                 |
| Requires initialization  | Yes                         | No                                      |
| IntelliSense support     | Yes                         | No                                      |
| Type errors              | Compile-time errors         | Runtime exceptions                      |
| Performance              | Better (static typing)      | Worse (dynamic typing)                 |
| Common usage             | Type-safe inference         | Interoperability with COM, JSON, etc.   |

---

### 📌 `var`: Compile-time Type Inference

`var` is used when the compiler **can infer the type** from the assigned value. Though the type isn't written explicitly, it is **strongly typed and checked at compile time**.

```csharp
var name = "Damian";  // string
var age = 30;         // int

// Compile-time error:
// var number;
// number = 5;
```

The type is determined from the initial assignment and **cannot change** later.

---

### 📌 `dynamic`: Runtime Resolution

`dynamic` behaves like a type that can change. The compiler **skips type checking**, allowing more flexibility but also more risk.

```csharp
dynamic data = "Damian";
Console.WriteLine(data.Length);  // OK

data = 123;
// This line will throw an exception at runtime: data.Length
```

This is useful when dealing with:

- Dynamic JSON objects
- ExpandoObject
- COM interoperability
- Reflection

---

### ⚠️ When to Use

✅ Use `var` when:
- The type is obvious from the context.
- You want type safety.
- You need performance and compile-time validation.

⚠️ Use `dynamic` only when:
- The type is unknown until runtime.
- Working with dynamic structures (like untyped JSON).
- Interfacing with external systems (COM, Office, etc.).

---

## Español

### Visión general

En C#, tanto `var` como `dynamic` permiten declarar variables sin especificar explícitamente su tipo, pero existen **diferencias fundamentales** entre ambos, principalmente relacionadas con **cuándo se determina el tipo de la variable** y **cómo se comporta en tiempo de compilación y ejecución**.

---

### 🔍 Diferencias clave

| Característica | `var` | `dynamic` |
|----------------|--------|-----------|
| Resolución de tipo | Tiempo de compilación | Tiempo de ejecución |
| Requiere inicialización | Sí | No |
| IntelliSense y verificación de tipos | Sí | No |
| Errores de tipo | Detectados en compilación | Pueden fallar en ejecución |
| Rendimiento | Mejor (estático) | Menor (dinámico) |
| Uso principal | Inferencia de tipos seguros | Interoperabilidad con COM, JSON, ExpandoObject, etc. |

---

### 📌 `var`: Inferencia de tipo en tiempo de compilación

`var` se usa cuando el compilador **puede inferir el tipo** desde el valor asignado. Aunque el tipo no se escribe explícitamente, sigue siendo **estático y seguro en tiempo de compilación**.

```csharp
var name = "Damian";  // string
var age = 30;         // int

// Error de compilación
// var number;
// number = 5;
```

El compilador infiere el tipo desde el valor inicial. Luego, el tipo **no puede cambiar**.

---

### 📌 `dynamic`: Resolución en tiempo de ejecución

`dynamic` se comporta como si fuera un "tipo que puede cambiar". El compilador **omite la verificación de tipo**, permitiendo más flexibilidad, pero también más riesgo.

```csharp
dynamic data = "Damian";
Console.WriteLine(data.Length);  // OK

data = 123;
// Esta línea lanzará una excepción en ejecución si se hace: data.Length
```

Este enfoque se usa comúnmente cuando trabajas con:

- JSON dinámico
- ExpandoObject
- COM (Component Object Model)
- Reflexión

---

### ⚠️ Cuándo usar cada uno

✅ Usa `var` cuando:
- El tipo es evidente a partir del contexto.
- Quieres mantener seguridad de tipos.
- Buscas rendimiento y validaciones en tiempo de compilación.

⚠️ Usa `dynamic` solo cuando:
- El tipo no se conoce hasta tiempo de ejecución.
- Trabajas con estructuras dinámicas (como JSON sin modelo).
- Haces interop con sistemas externos (COM, Office, etc.).
