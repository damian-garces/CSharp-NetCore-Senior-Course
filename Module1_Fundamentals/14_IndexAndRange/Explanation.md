# Index and Range (`^` and `..`)

## English

### Index (`^`) — From the End

C# 8.0 introduced the `Index` type using the `^` symbol, which allows you to access elements from the end of a collection.

```csharp
var numbers = new[] { 10, 20, 30, 40, 50 };

int last = numbers[^1]; // 50
int secondLast = numbers[^2]; // 40
```

This is useful when you want to retrieve items from the end without knowing the array's length.

---

### Range (`..`) — Subranges of a Collection

The `..` operator creates a range to slice a collection. It can be used with arrays, `Span<T>`, `ReadOnlySpan<T>`, and other types.

```csharp
var numbers = new[] { 10, 20, 30, 40, 50 };

var slice = numbers[1..4]; // Contains 20, 30, 40
```

The syntax `[start..end]` includes the `start` index and excludes the `end` index.

---

### Common Combinations

```csharp
var numbers = new[] { 10, 20, 30, 40, 50 };

var firstThree = numbers[..3];    // 10, 20, 30
var lastTwo = numbers[^2..];      // 40, 50
var middle = numbers[1..^1];      // 20, 30, 40
```

---

### Key Points

- Negative indices are not allowed; use `^` for reverse indexing.
- Range results in a new array (for arrays) or a memory view (for Span types).
- Does not modify the original collection.

> ✅ Note: These operators also work with `Span<T>`, which is covered in detail in the topic: “Efficient Strings with Span<T> and StringBuilder”.

---

## Español

### Index (`^`) — Desde el final

C# 8.0 introdujo el tipo `Index` con el símbolo `^`, que permite acceder a elementos desde el final de una colección.

```csharp
var numbers = new[] { 10, 20, 30, 40, 50 };

int ultimo = numbers[^1]; // 50
int penultimo = numbers[^2]; // 40
```

Es útil para obtener elementos sin conocer la longitud del array.

---

### Range (`..`) — Subrangos de una colección

El operador `..` permite crear subconjuntos (slicing) de una colección. Se puede usar con arrays, `Span<T>`, `ReadOnlySpan<T>`, entre otros.

```csharp
var numbers = new[] { 10, 20, 30, 40, 50 };

var subrango = numbers[1..4]; // Contiene 20, 30, 40
```

La notación `[start..end]` incluye el índice inicial pero excluye el final.

---

### Combinaciones comunes

```csharp
var numbers = new[] { 10, 20, 30, 40, 50 };

var primerosTres = numbers[..3];    // 10, 20, 30
var ultimosDos = numbers[^2..];     // 40, 50
var intermedios = numbers[1..^1];   // 20, 30, 40
```

---

### Puntos clave

- No se permiten índices negativos; para eso se usa `^`.
- El resultado de un rango puede ser una copia (arrays) o una vista en memoria (`Span<T>`).
- No modifica la colección original.

> ✅ Nota: Estos operadores también funcionan con `Span<T>`, explicado en detalle en el tema: “Strings eficientes con Span<T> y StringBuilder”.
