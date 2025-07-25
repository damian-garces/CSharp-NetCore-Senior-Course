# Deferred Execution vs Immediate Execution (LINQ)

## English

### 🔹 What is Deferred Execution?

**Deferred execution** means that a LINQ operation is **not executed when it is defined**, but only when the result is actually iterated (e.g., with a `foreach`, `ToList()`, `Count()`, etc).

#### Benefits:

- More efficient: nothing happens until you actually need the data.
- You can modify the data source before the query runs.
- Queries can be chained and composed.

#### Example:

```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5 };
var evens = numbers.Where(n => n % 2 == 0); // Not executed yet

numbers.Add(6);

foreach (var num in evens)
{
    Console.WriteLine(num); // Now it executes
}
```

**Output:**

```
2
4
6
```

---

### 🔹 What is Immediate Execution?

**Immediate execution** means that the LINQ operation is **executed at the moment** it is declared, usually because a terminal operation is called, such as `ToList()`, `Count()`, `First()`, etc.

#### Benefits:

- Captures the data at the current moment.
- Useful when the source might change later.

#### Example:

```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5 };
var evens = numbers.Where(n => n % 2 == 0).ToList(); // Executed now

numbers.Add(6);

foreach (var num in evens)
{
    Console.WriteLine(num); // 6 is not included
}
```

**Output:**

```
2
4
```

---

### 🔸 Summary Table

| Feature                 | Deferred Execution           | Immediate Execution               |
| ----------------------- | ---------------------------- | --------------------------------- |
| Execution time          | When iterated                | When declared                     |
| Reflects source changes | ✅ Yes                        | ❌ No                              |
| Ideal for               | Lazy and composable queries  | Taking snapshot of current data   |
| Typical methods         | `Where`, `Select`, `OrderBy` | `ToList`, `Count`, `First`, `Any` |

---

# Ejecución Diferida vs Ejecución Inmediata (LINQ)

## Español

### 🔹 ¿Qué es la Ejecución Diferida?

La **ejecución diferida** significa que una operación de LINQ **no se ejecuta cuando se declara**, sino solo cuando se itera el resultado (por ejemplo, con `foreach`, `ToList()`, `Count()`, etc).

#### Ventajas:

- Más eficiente: nada ocurre hasta que realmente se necesita.
- Puedes modificar la fuente de datos antes de que se ejecute la consulta.
- Se pueden encadenar consultas.

#### Ejemplo:

```csharp
var numeros = new List<int> { 1, 2, 3, 4, 5 };
var pares = numeros.Where(n => n % 2 == 0); // No se ejecuta aún

numeros.Add(6);

foreach (var num in pares)
{
    Console.WriteLine(num); // Aquí se ejecuta
}
```

**Resultado:**

```
2
4
6
```

---

### 🔹 ¿Qué es la Ejecución Inmediata?

La **ejecución inmediata** significa que la operación de LINQ **se ejecuta en el momento** en que se declara, usualmente porque se llama a un método terminal como `ToList()`, `Count()`, `First()`, etc.

#### Ventajas:

- Captura los datos del momento actual.
- Útil si la fuente podría cambiar después.

#### Ejemplo:

```csharp
var numeros = new List<int> { 1, 2, 3, 4, 5 };
var pares = numeros.Where(n => n % 2 == 0).ToList(); // Se ejecuta inmediatamente

numeros.Add(6);

foreach (var num in pares)
{
    Console.WriteLine(num); // No incluye el 6
}
```

**Resultado:**

```
2
4
```

---

### 🔸 Tabla Resumen

| Característica               | Ejecución Diferida                 | Ejecución Inmediata               |
| ---------------------------- | ---------------------------------- | --------------------------------- |
| Momento de ejecución         | Al iterar                          | Al declarar                       |
| Refleja cambios en la fuente | ✅ Sí                               | ❌ No                              |
| Ideal para                   | Consultas perezosas y encadenables | Capturar datos actuales           |
| Métodos típicos              | `Where`, `Select`, `OrderBy`       | `ToList`, `Count`, `First`, `Any` |



