
# Advanced Pattern Matching in C#

## English

### Advanced Pattern Matching in C#

Pattern Matching in C# has evolved significantly, enabling developers to write expressive, concise, and safe code. Below are the most important forms of advanced pattern matching:

---

### 1. `switch expressions`

Modern `switch` expressions replace the classic imperative `switch` with a concise, immutable form ideal for assigning values based on complex conditions.

```csharp
string GetRoleDescription(string role) =>
    role switch
    {
        "Admin" => "Has full access",
        "User" => "Has limited access",
        "Guest" => "Has minimal access",
        _ => "Unknown role"
    };
```

Benefits:
- Immutable (no `break` or `goto`)
- Supports complex patterns (tuples, properties, conditions)

---

### 2. `is` with patterns (type, constant, relational)

The `is` keyword now supports not only type checking but also inline assignment and condition checks.

```csharp
if (obj is string s && s.Length > 5)
{
    Console.WriteLine($"String longer than 5: {s}");
}
```

Other examples:

```csharp
if (age is > 18 and < 65)
    Console.WriteLine("Working age adult");
```

---

### 3. `when` condition filters

Used in `switch` or expressions to filter specific cases.

```csharp
string GetSize(int size) => size switch
{
    < 10 => "Small",
    >= 10 and <= 20 => "Medium",
    _ when size % 2 == 0 => "Large and even",
    _ => "Large"
};
```

---

### 4. Pattern Matching on Tuples

Enables evaluation of multiple values together using tuple-based `switch`.

```csharp
(string, int) input = ("Admin", 3);

string result = input switch
{
    ("Admin", >= 3) => "Senior Admin",
    ("Admin", < 3) => "Junior Admin",
    ("User", _) => "Regular User",
    _ => "Unknown Role"
};
```

---

### 5. Property patterns

You can match against object properties directly.

```csharp
bool IsWeekend(DateTime date) => date.DayOfWeek switch
{
    DayOfWeek.Saturday or DayOfWeek.Sunday => true,
    _ => false
};
```

Or with objects:

```csharp
if (person is { Age: >= 18, Country: "Colombia" })
{
    Console.WriteLine("Colombian adult");
}
```

---

### 6. Pattern composition

You can combine different types of patterns:

```csharp
if (obj is Person { Age: > 18 } p && p.Name is not null)
{
    Console.WriteLine($"{p.Name} is an adult.");
}
```

---

## Español

### Pattern Matching avanzado en C#

El Pattern Matching en C# ha evolucionado significativamente, permitiendo escribir código más expresivo, conciso y seguro en tiempo de compilación. A continuación, abordamos las formas avanzadas más comunes:

---

### 1. `switch expressions`

Las expresiones `switch` modernas reemplazan al clásico `switch` imperativo con una forma más concisa, inmutable y orientada a expresiones.

```csharp
string GetRoleDescription(string role) =>
    role switch
    {
        "Admin" => "Has full access",
        "User" => "Has limited access",
        "Guest" => "Has minimal access",
        _ => "Unknown role"
    };
```

Ventajas:
- Inmutable (sin `break`, ni `goto`)
- Soporta patrones complejos (tuplas, propiedades, condiciones)

---

### 2. `is` con patrones (tipo, constante, relacional)

El uso de `is` se ha extendido para permitir no solo verificar el tipo sino también hacer una asignación directa y evaluación de condiciones:

```csharp
if (obj is string s && s.Length > 5)
{
    Console.WriteLine($"String mayor a 5: {s}");
}
```

Otros ejemplos:

```csharp
if (age is > 18 and < 65)
    Console.WriteLine("Adulto trabajador");
```

---

### 3. `when` como filtro de condición

En los `switch` clásicos o expresiones modernas, puedes agregar cláusulas `when` para filtrar condiciones específicas:

```csharp
string GetSize(int size) => size switch
{
    < 10 => "Pequeño",
    >= 10 and <= 20 => "Mediano",
    _ when size % 2 == 0 => "Grande y par",
    _ => "Grande"
};
```

---

### 4. Pattern Matching en Tuplas

Permite combinar múltiples valores en un `switch` usando tuplas para evaluar condiciones más sofisticadas.

```csharp
(string, int) input = ("Admin", 3);

string result = input switch
{
    ("Admin", >= 3) => "Admin Senior",
    ("Admin", < 3) => "Admin Junior",
    ("User", _) => "Usuario común",
    _ => "Rol desconocido"
};
```

---

### 5. Pattern Matching en propiedades

Puedes evaluar directamente propiedades de un objeto dentro del `switch` o `is`:

```csharp
bool IsWeekend(DateTime date) => date.DayOfWeek switch
{
    DayOfWeek.Saturday or DayOfWeek.Sunday => true,
    _ => false
};
```

Otro ejemplo con objetos:

```csharp
if (person is { Age: >= 18, Country: "Colombia" })
{
    Console.WriteLine("Adulto colombiano");
}
```

---

### 6. Composición de patrones

Puedes combinar distintos tipos de patrones como `type`, `relational`, `logical` y `property`:

```csharp
if (obj is Person { Age: > 18 } p && p.Name is not null)
{
    Console.WriteLine($"{p.Name} es un adulto.");
}
```
