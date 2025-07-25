# var vs Explicit Types (Best Practices)

## English

In C#, you can declare variables using either `var` or an explicit type. Both are valid, but it's important to understand when each one is more appropriate.

### What is `var`?

The `var` keyword lets the compiler infer the type of the variable from the initialization expression. For example:

```csharp
var name = "Damian"; // Compiler infers string
var number = 10;     // Compiler infers int
```

### Explicit Types

Using explicit types means specifying the type directly:

```csharp
string name = "Damian";
int number = 10;
```

### Advantages of `var`

- **Less repetitive code**: Especially useful for long or complex types like in LINQ.
- **Improves readability**: When the type is obvious from the assignment, `var` makes the code cleaner.
- **Recommended for anonymous types**: Since explicit types can't be used.

### Disadvantages of `var`

- **Can hide the type**: If the initialization is unclear, it makes the code harder to understand.
- **Harder to catch type conversion issues**: For example, if a function returns `object` and you use `var`, you may assume the wrong type.

### Best Practices

- ✅ Use `var` when the type is **clear and obvious** from the assignment.
- ❌ Avoid `var` when the type is not evident.
- ✅ Use explicit types for **clarity**, especially in public variables or fields.
- ✅ Always initialize variables when using `var`.

### Examples

**✔️ Correct (clear type):**

```csharp
var list = new List<string>();
```

**❌ Incorrect (unclear type):**

```csharp
var result = GetData(); // What type is it?
```

**✔️ Explicit type improves clarity:**

```csharp
Client client = GetClient();
```

---

## Español

En C#, puedes declarar variables utilizando `var` o especificando el tipo explícitamente. Ambos enfoques son válidos, pero es importante entender cuándo es más conveniente usar cada uno.

### ¿Qué es `var`?

La palabra clave `var` permite que el compilador infiera automáticamente el tipo de la variable a partir de la expresión de inicialización. Por ejemplo:

```csharp
var nombre = "Damian"; // El compilador infiere que es string
var numero = 10;       // El compilador infiere que es int
```

### Tipos explícitos

Al usar tipos explícitos, indicas el tipo directamente:

```csharp
string nombre = "Damian";
int numero = 10;
```

### Ventajas de `var`

- **Menos código repetitivo**: Especialmente útil cuando el tipo es largo o complejo, como al usar LINQ.
- **Facilita la lectura**: Cuando el tipo es evidente en la asignación, `var` hace que el código sea más limpio.
- **Recomendado en tipos anónimos**: Ya que no puedes especificar un tipo explícito.

### Desventajas de `var`

- **Puede ocultar el tipo**: Si la inicialización no es clara, dificulta la comprensión del código.
- **Difícil de detectar errores de conversión**: Por ejemplo, si una función devuelve `object` y usas `var`, podrías asumir un tipo incorrecto.

### Buenas prácticas recomendadas

- ✅ Usa `var` cuando el tipo sea **obvio y claro** en la asignación.
- ❌ Evita `var` cuando el tipo no sea evidente.
- ✅ Usa tipos explícitos para mejorar la **claridad**, especialmente en variables públicas o campos.
- ✅ Siempre inicializa las variables cuando uses `var`.

### Ejemplos

**✔️ Correcto (tipo claro):**

```csharp
var lista = new List<string>();
```

**❌ Incorrecto (tipo no claro):**

```csharp
var resultado = ObtenerDatos(); // ¿Qué tipo retorna?
```

**✔️ Tipo explícito mejora claridad:**

```csharp
Cliente cliente = ObtenerCliente();
```
