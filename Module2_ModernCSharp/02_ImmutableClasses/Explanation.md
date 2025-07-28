
# Immutable Classes and Init Properties in C#

## English

### 🧱 Immutable Classes and `init` Properties in C#

#### 🔹 What is an immutable class?

An immutable class is one whose state (its properties) cannot be changed after it's created. Once you instantiate the class, none of its properties can be modified.

This is useful for:
- **Thread safety**
- **Modeling consistent data** (e.g., Value Objects in DDD)
- **Functional and defensive programming**

#### 🔹 How were immutable classes created before C# 9?

Before C# 9, you needed to use constructors and read-only properties to enforce immutability:

```csharp
public class User
{
    public string Name { get; }
    public int Age { get; }

    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
```

This approach requires constructors and can get verbose with many properties.

---

### 🆕 `init` Properties (C# 9+)

The `init` modifier allows setting properties **only during object initialization**. After that, they become effectively read-only.

It simplifies creating immutable objects using object initializer syntax:

```csharp
public class Product
{
    public string Name { get; init; }
    public decimal Price { get; init; }
}

var product = new Product
{
    Name = "Laptop",
    Price = 1299.99m
};

// product.Price = 999.99m; ❌ Compile-time error
```

#### 📝 Key Differences: `set` vs `init`

| Feature              | `set`                   | `init`                       |
|----------------------|--------------------------|-------------------------------|
| Mutable after init   | ✅ Yes                  | ❌ No                         |
| Requires constructor | ❌ No                   | ❌ No                         |
| `with` expression support | ❌ No           | ✅ Yes                        |

---

### 🧠 Best Practices

- Use `init` to easily build immutable objects.
- Ideal for DTOs, Value Objects, config models.
- Works well with `record`, but not mandatory.

---

### 🔐 Additional Considerations on Immutability

- If your `init` properties are mutable reference types (like lists, dictionaries, or classes), they **can still be changed internally**.
  - Use immutable types (`ImmutableList`, etc.)
  - Or expose defensive copies (`readonly`, `AsReadOnly()`).

```csharp
public class Catalog
{
    public IReadOnlyList<string> Items { get; init; }

    public Catalog(IEnumerable<string> items)
    {
        Items = new List<string>(items);
    }
}
```

---

## Español

### 🧱 Clases inmutables y propiedades `init` en C#

#### 🔹 ¿Qué es una clase inmutable?

Una clase inmutable es una clase cuyo estado (sus propiedades) no puede cambiar después de su creación. Esto significa que una vez que creas una instancia de la clase, no puedes modificar ninguna de sus propiedades.

Esto es muy útil para:
- **Seguridad en la concurrencia (thread safety)**
- **Modelado de datos consistentes** (por ejemplo, en DDD los Value Objects suelen ser inmutables)
- **Estilo funcional y programación defensiva**

#### 🔹 ¿Cómo se creaban clases inmutables antes de C# 9?

Antes de C# 9, se requería declarar propiedades solo con getter y establecer los valores solo desde el constructor:

```csharp
public class User
{
    public string Name { get; }
    public int Age { get; }

    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
```

El problema es que esto requiere múltiples sobrecargas si tienes varias combinaciones de propiedades o necesitas un constructor largo.

---

### 🆕 Propiedades `init` (desde C# 9)

Las propiedades con el modificador `init` permiten que las propiedades sean asignadas **solo durante la inicialización del objeto**. Luego de eso, son efectivamente de solo lectura (readonly).

Esto permite mantener la **inmutabilidad**, pero usando una sintaxis más simple con inicialización con objetos (`object initializer`):

```csharp
public class Product
{
    public string Name { get; init; }
    public decimal Price { get; init; }
}

// Así se usa:
var product = new Product
{
    Name = "Laptop",
    Price = 1299.99m
};

// product.Price = 999.99m; ❌ Error de compilación
```

#### 📝 Diferencias clave entre `init` y `set`

| Característica     | `set`                       | `init`                        |
|--------------------|-----------------------------|--------------------------------|
| Modificable luego  | ✅ Sí                        | ❌ No                          |
| Requiere constructor | ❌ No                       | ❌ No                          |
| Compatible con `with` (record) | ❌ No           | ✅ Sí                          |

---

### 🧠 Buenas prácticas

- Usa `init` para construir objetos inmutables de manera más sencilla.
- Ideal para DTOs, Value Objects, configuraciones y objetos que no deben cambiar.
- No es necesario usar `record` para usar `init`, pero ambos se complementan muy bien.

---

### 🔐 Consideraciones adicionales sobre inmutabilidad

- Aunque uses `init`, si las propiedades son tipos de referencia mutables (como listas, diccionarios, o clases propias), **pueden modificarse internamente**. Por eso, para lograr inmutabilidad real, se recomienda:
  - Usar tipos inmutables o colecciones inmutables (`ImmutableList`, etc.).
  - O exponer copias defensivas (`readonly` en campos o `AsReadOnly()`).

```csharp
public class Catalog
{
    public IReadOnlyList<string> Items { get; init; }

    public Catalog(IEnumerable<string> items)
    {
        Items = new List<string>(items);
    }
}
```
