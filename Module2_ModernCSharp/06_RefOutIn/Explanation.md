## 📘 ref, out, in and When to Use Them

### English

In C#, the `ref`, `out`, and `in` keywords allow you to pass parameters by reference rather than by value. This enables methods to affect the caller’s variables directly. Each modifier has a specific use case and distinct rules.

---

### 🔹 `ref` – Pass by Reference (Read and Write)

- Allows a method to both **read and modify** the value of a variable.
- The variable **must be initialized** before being passed.
- Useful when the caller expects the method to modify the value.

**Example:**
```csharp
void Increment(ref int number)
{
    number++;
}
```

---

### 🔹 `out` – Pass by Reference (Write Only)

- Allows a method to **assign a value** to a variable.
- The variable **does not need to be initialized** before being passed.
- The method is **required** to assign a value before exiting.
- Commonly used to return multiple values from a method.

**Example:**
```csharp
bool TryParseAge(string input, out int age)
{
    return int.TryParse(input, out age);
}
```

---

### 🔹 `in` – Pass by Reference (Read Only)

- Introduced in C# 7.2.
- Passes a variable by reference **without allowing modification**.
- Ideal for large structs where copying is costly.
- Promotes immutability and performance.

**Example:**
```csharp
void PrintLength(in ReadOnlySpan<char> input)
{
    Console.WriteLine(input.Length);
}
```

---

### 🧠 Quick Comparison

| Modifier | Read | Write | Requires Initialization | Common Use Case |
|----------|------|-------|--------------------------|------------------|
| `ref`    | ✅    | ✅     | ✅                        | Modify existing values |
| `out`    | ❌    | ✅     | ❌                        | Return multiple values |
| `in`     | ✅    | ❌     | ✅                        | Avoid copy of large structs |

---

### ⚠️ Best Practices

- **Avoid overusing** `ref` and `out`; prefer returning objects or tuples for clarity.
- Use `in` when performance matters and the struct is large.
- In public APIs, minimize the use of these keywords unless absolutely necessary.
- `ref struct` and `in ref struct` are intended for high-performance stack-only types like `Span<T>`.

---

### Español

En C#, los modificadores `ref`, `out` e `in` permiten pasar argumentos por referencia en lugar de por valor. Esto significa que el método llamado puede modificar directamente el valor de una variable en el método llamador. Aunque se parecen, cada uno tiene propósitos distintos y reglas específicas.

---

### 🔹 `ref` – Pasar por referencia (lectura y escritura)

- Permite que un método lea **y modifique** el valor de una variable.
- La variable **debe estar inicializada** antes de pasarla al método.
- Ideal cuando se desea modificar el valor de una variable y que el cambio se refleje fuera del método.

**Ejemplo:**
```csharp
void Increment(ref int number)
{
    number++;
}
```

---

### 🔹 `out` – Pasar por referencia (solo escritura)

- Permite que un método **asigne un valor** a una variable.
- La variable **no necesita estar inicializada** antes de pasarla.
- El método **está obligado** a asignar un valor a la variable antes de salir.
- Se usa comúnmente para devolver múltiples valores sin usar tuplas.

**Ejemplo:**
```csharp
bool TryParseAge(string input, out int age)
{
    return int.TryParse(input, out age);
}
```

---

### 🔹 `in` – Pasar por referencia (solo lectura)

- Introducido en C# 7.2.
- Pasa una variable por referencia para evitar copias costosas (especialmente en estructuras grandes), pero **no permite modificarla** dentro del método.
- Aporta eficiencia sin sacrificar inmutabilidad.

**Ejemplo:**
```csharp
void PrintLength(in ReadOnlySpan<char> input)
{
    Console.WriteLine(input.Length);
}
```

---

### 🧠 Comparación rápida

| Modificador | Lectura | Escritura | Requiere inicialización previa | Uso común |
|-------------|---------|-----------|-------------------------------|-----------|
| `ref`       | ✅       | ✅         | ✅                             | Modificar valores existentes |
| `out`       | ❌       | ✅         | ❌                             | Devolver múltiples valores |
| `in`        | ✅       | ❌         | ✅                             | Mejorar rendimiento con estructuras grandes |

---

### ⚠️ Buenas prácticas

- **Evita el uso excesivo** de `ref` y `out`. Prefiere devolver objetos, tuplas o usar patrones modernos.
- Usa `in` solo cuando sepas que el costo de copiar la estructura es significativo.
- En APIs públicas, evita `ref` y `out` si no es necesario, ya que pueden reducir la claridad del código.
- El uso de `ref struct` y `in ref struct` está reservado para estructuras como `Span<T>` por razones de eficiencia y stack-only allocation.