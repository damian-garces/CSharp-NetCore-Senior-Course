# Nullable types (?, ??, ??=)

## English

### What are Nullable Types?

In C#, **value types** (like `int`, `double`, `bool`, `DateTime`, etc.) cannot be null by default. However, there are many scenarios where we need to represent a missing or unknown value — often indicated by `null`. C# allows making value types **nullable** using the `?` suffix.

```csharp
int? age = null;
```

This means the variable `age` can either contain an integer or `null`.

---

### The `??` operator (null-coalescing)

This operator lets you provide a **default value** when the evaluated value is `null`.

```csharp
int? age = null;
int result = age ?? 18; // If age is null, result will be 18
```

It also works with reference types:

```csharp
string name = null;
string finalValue = name ?? "Unknown";
```

---

### The `??=` operator (null-coalescing assignment)

Assigns a value **only if the variable is null**.

```csharp
string name = null;
name ??= "Anonymous"; // name is now "Anonymous"
```

---

### Quick Comparison Table

| Operator | Purpose | Example | Meaning |
|----------|---------|---------|---------|
| `?` | Makes a value type nullable | `int? age` | Can be `int` or `null` |
| `??` | Returns alternate if value is null | `age ?? 18` | If `age` is null, returns 18 |
| `??=` | Assigns only if null | `name ??= "Anonymous"` | Assigns only if `name` is null |

---

## Español

### ¿Qué son los tipos anulables?

En C#, los **tipos por valor** (como `int`, `double`, `bool`, `DateTime`, etc.) no pueden ser nulos por defecto. Sin embargo, hay situaciones donde necesitas representar "sin valor" o "desconocido", algo que normalmente se expresa con `null`. Para resolver esto, C# permite hacer que los tipos por valor sean **anulables** usando `?`.

```csharp
int? edad = null;
```

Esto significa que la variable `edad` puede tener un número entero o `null`.

---

### El operador `??` (null-coalescing operator)

Este operador permite proporcionar un **valor predeterminado** cuando el valor evaluado es `null`.

```csharp
int? edad = null;
int resultado = edad ?? 18; // Si edad es null, resultado será 18
```

También funciona con tipos por referencia:

```csharp
string nombre = null;
string valorFinal = nombre ?? "Desconocido";
```

---

### El operador `??=` (null-coalescing assignment)

Asigna un valor a la variable **solo si es null**.

```csharp
string nombre = null;
nombre ??= "Anónimo"; // nombre ahora es "Anónimo"
```

---

### Comparación rápida de los tres operadores

| Operador | Uso | Ejemplo | Significado |
|----------|-----|---------|-------------|
| `?` | Hace un tipo por valor anulable | `int? edad` | Puede ser `int` o `null` |
| `??` | Devuelve un valor alternativo si el primero es `null` | `edad ?? 18` | Si `edad` es null, devuelve 18 |
| `??=` | Asigna un valor si la variable es `null` | `nombre ??= "Anónimo"` | Solo asigna si `nombre` es null |
