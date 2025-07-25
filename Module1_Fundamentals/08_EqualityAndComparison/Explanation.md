# Equality and Comparison in C#

## English

### What does equality and comparison mean in C#?

In C#, **equality** and **comparison** determine whether two objects are considered equal from different perspectives:

- **By reference**: whether two variables point to the same object in memory.
- **By value**: whether the contents of the objects are logically equal, even if they are different instances.

---

### Core mechanisms and methods

#### 🔹 `Equals(object obj)`
- Virtual method from the base `Object` class.
- Can be overridden to define **semantic** comparison.
- Used to check if two objects have **equivalent content**.

#### 🔹 `GetHashCode()`
- Returns an integer used by hash-based collections like `Dictionary` and `HashSet`.
- **Important rule**: if `x.Equals(y)` is `true`, then `x.GetHashCode()` must equal `y.GetHashCode()`.

> ⚠️ If you override `Equals`, you must also override `GetHashCode`.

#### 🔹 `==` and `!=` operators
- Default behavior for classes: compares by **reference**.
- Default behavior for structs: compares by **value**.
- Can be **overloaded** to define custom logic.

```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public override bool Equals(object obj) =>
        obj is Person other && Name == other.Name && Age == other.Age;

    public override int GetHashCode() =>
        HashCode.Combine(Name, Age);

    public static bool operator ==(Person left, Person right) =>
        Equals(left, right);

    public static bool operator !=(Person left, Person right) =>
        !Equals(left, right);
}
```

#### 🔹 `ReferenceEquals(object a, object b)`
- Static method to check whether **two references point to the exact same object in memory**.
- Cannot be overloaded.

```csharp
object a = new object();
object b = a;
Console.WriteLine(object.ReferenceEquals(a, b)); // true
```

---

### `IEqualityComparer<T>` interface

Allows you to define **custom logic** for comparing and hashing objects. Useful for:

- `HashSet<T>`
- `Dictionary<TKey, TValue>`
- LINQ methods like `Distinct`, `GroupBy`, etc.

```csharp
public class PersonComparer : IEqualityComparer<Person>
{
    public bool Equals(Person x, Person y) =>
        x.Name == y.Name && x.Age == y.Age;

    public int GetHashCode(Person obj) =>
        HashCode.Combine(obj.Name, obj.Age);
}
```

---

### Summary Table

| Mechanism             | Primary Use                                           |
|----------------------|--------------------------------------------------------|
| `Equals`             | Semantic object comparison                             |
| `GetHashCode`        | Optimization in hash-based collections                 |
| `==` / `!=`          | Direct comparison (reference by default or overloaded) |
| `ReferenceEquals`    | Checks memory reference equality                       |
| `IEqualityComparer`  | Custom comparison for collections and LINQ             |

---

### 🛑 Advanced considerations

#### ⚠️ Mutable types in hash collections

If you store a mutable object in a `HashSet` or `Dictionary` and then **change** its properties that affect the hash code, it may become **unreachable** within the collection.

#### ⚠️ Equality contract

When implementing `Equals`, you should also:

- Implement `GetHashCode`
- Consider overloading `==` and `!=`
- Ensure consistency: `Equals` must be **reflexive, symmetric, and transitive**
- Be cautious if the class is not `sealed` (inheritance can introduce issues)

---

> 🧠 Note: `Dictionary` and `HashSet` rely on hash functions for fast storage and retrieval. Objects used as keys must correctly implement `Equals` and `GetHashCode`.  
> For a deeper explanation of these collections, see **Topic 11 of Module 1**.

---

## Español

### ¿Qué significa equidad y comparación en C#?

En C#, la **equidad (equality)** y la **comparación** permiten verificar si dos objetos son iguales desde distintos puntos de vista:

- **Por referencia**: si dos variables apuntan al mismo objeto en memoria.
- **Por valor**: si el contenido de los objetos es equivalente aunque sean diferentes instancias.

---

### Métodos y mecanismos clave

#### 🔹 `Equals(object obj)`
- Método virtual definido en la clase base `Object`.
- Se puede sobreescribir para definir una comparación **semántica** entre objetos.
- Se usa para saber si dos objetos **tienen el mismo contenido lógico**.

#### 🔹 `GetHashCode()`
- Devuelve un número entero (hash) utilizado por colecciones basadas en hash (`Dictionary`, `HashSet`, etc.).
- **Regla fundamental**: si `x.Equals(y)` es `true`, entonces `x.GetHashCode()` debe ser igual a `y.GetHashCode()`.

> ⚠️ Si sobreescribes `Equals`, debes también sobreescribir `GetHashCode`.

#### 🔹 `==` y `!=` (operadores)
- Por defecto en clases: compara por **referencia**.
- Por defecto en structs: compara por **valor**.
- Puedes **sobrecargarlos** para definir lógica personalizada.

```csharp
public class Persona
{
    public string Nombre { get; set; }
    public int Edad { get; set; }

    public override bool Equals(object obj) =>
        obj is Persona other && Nombre == other.Nombre && Edad == other.Edad;

    public override int GetHashCode() =>
        HashCode.Combine(Nombre, Edad);

    public static bool operator ==(Persona left, Persona right) =>
        Equals(left, right);

    public static bool operator !=(Persona left, Persona right) =>
        !Equals(left, right);
}
```

#### 🔹 `ReferenceEquals(object a, object b)`
- Método estático que comprueba si **dos referencias apuntan exactamente al mismo objeto en memoria**.
- No se puede sobrecargar.

```csharp
object a = new object();
object b = a;
Console.WriteLine(object.ReferenceEquals(a, b)); // true
```

---

### Interfaz `IEqualityComparer<T>`

Permite definir una lógica **personalizada** de comparación e igualdad, especialmente útil para colecciones como:

- `HashSet<T>`
- `Dictionary<TKey, TValue>`
- Métodos LINQ como `Distinct`, `GroupBy`, etc.

```csharp
public class PersonaComparer : IEqualityComparer<Persona>
{
    public bool Equals(Persona x, Persona y) =>
        x.Nombre == y.Nombre && x.Edad == y.Edad;

    public int GetHashCode(Persona obj) =>
        HashCode.Combine(obj.Nombre, obj.Edad);
}
```

---

### Tabla comparativa

| Mecanismo             | Uso principal                                           |
|----------------------|----------------------------------------------------------|
| `Equals`             | Comparación semántica entre objetos                      |
| `GetHashCode`        | Clave de eficiencia en colecciones hash                  |
| `==` / `!=`          | Comparación directa (por defecto referencia o sobrecarga)|
| `ReferenceEquals`    | Verifica si dos referencias apuntan al mismo objeto      |
| `IEqualityComparer`  | Comparación personalizada en colecciones y LINQ          |

---

### 🛑 Consideraciones avanzadas

#### ⚠️ Tipos mutables en colecciones hash

Si colocas un objeto mutable en un `HashSet` o `Dictionary`, y luego **modificas** sus propiedades que afectan el `hash`, el objeto podría volverse **inaccesible** en la colección.

#### ⚠️ Contrato de igualdad

Si implementas `Equals`, debes:

- Implementar `GetHashCode`
- Considerar sobrecargar `==` y `!=`
- Ser coherente: `Equals` debe ser **reflexiva, simétrica y transitiva**
- Tener cuidado si la clase no es `sealed` (puede haber problemas con la herencia)

---

> 🧠 Nota: Las estructuras `Dictionary` y `HashSet` se basan en funciones hash para almacenar y buscar datos de forma eficiente. Por eso es vital que los objetos usados como claves implementen correctamente `Equals` y `GetHashCode`.  
> Si deseas profundizar en estas colecciones, revisaremos su funcionamiento en el **tema 11 del módulo 1**.