# Deconstruction and Tuples

## English

### ✅ What is a Tuple?

A **tuple** in C# is a lightweight data structure that allows grouping multiple values into a single object. It's often used to return multiple values from a method without creating a class.

```csharp
(string, int) GetPersonData() => ("Damian", 35);
```

Since C# 7, tuples support **named fields**, improving readability:

```csharp
(string Name, int Age) GetPersonData() => ("Damian", 35);
```

Accessing values:

```csharp
var person = GetPersonData();
Console.WriteLine(person.Name); // Damian
Console.WriteLine(person.Age);  // 35
```

---

### ✅ What is Deconstruction?

**Deconstruction** allows you to unpack a tuple or object into separate variables:

```csharp
var (name, age) = GetPersonData();
Console.WriteLine(name); // Damian
Console.WriteLine(age);  // 35
```

It also works with classes or structs that implement a `Deconstruct` method.

---

### ✅ Deconstruct in Classes or Structs

You can enable deconstruction by adding a `Deconstruct` method:

```csharp
public class Person
{
    public string Name { get; }
    public int Age { get; }

    public Person(string name, int age) => (Name, Age) = (name, age);

    public void Deconstruct(out string name, out int age)
    {
        name = Name;
        age = Age;
    }
}
```

Usage:

```csharp
var person = new Person("Vanne", 30);
var (name, age) = person;
```

---

### ✅ Tuples vs Objects

| Feature             | Tuples                  | Objects / Classes         |
|---------------------|--------------------------|----------------------------|
| Simple and fast     | ✅                        | ❌ (requires class)         |
| Named properties    | ✅ (since C# 7)           | ✅                          |
| Immutability        | ❌                        | ✅ (if defined readonly)    |
| Recommended use     | Temporary returns        | Business logic structures  |

---

### ✅ Best Practices

- Use tuples for returning multiple *unrelated* values.
- Prefer classes or structs if logic or reuse is involved.
- Always name tuple properties for clarity.

---

## Español

### ✅ ¿Qué es una Tupla?

Una **tupla** en C# es una estructura que permite agrupar múltiples valores en una sola unidad de datos. Es útil cuando quieres devolver más de un valor desde un método sin crear una clase específica para eso.

```csharp
(string, int) GetPersonData() => ("Damián", 35);
```

A partir de C# 7, las tuplas tienen **nombres de campos**, lo que mejora la legibilidad:

```csharp
(string Name, int Age) GetPersonData() => ("Damián", 35);
```

Puedes acceder así:

```csharp
var person = GetPersonData();
Console.WriteLine(person.Name); // Damián
Console.WriteLine(person.Age);  // 35
```

---

### ✅ ¿Qué es la Deconstrucción?

**Deconstrucción** es la capacidad de extraer los valores de una tupla u objeto en variables separadas:

```csharp
var (name, age) = GetPersonData();
Console.WriteLine(name); // Damián
Console.WriteLine(age);  // 35
```

Esto también funciona con clases o structs si implementan un método `Deconstruct`.

---

### ✅ Deconstruct en Clases o Structs

Puedes personalizar la deconstrucción agregando un método `Deconstruct`:

```csharp
public class Person
{
    public string Name { get; }
    public int Age { get; }

    public Person(string name, int age) => (Name, Age) = (name, age);

    public void Deconstruct(out string name, out int age)
    {
        name = Name;
        age = Age;
    }
}
```

Uso:

```csharp
var person = new Person("Vanne", 30);
var (name, age) = person;
```

---

### ✅ Tuplas vs Objetos

| Característica     | Tuplas                    | Objetos / Clases         |
|--------------------|---------------------------|--------------------------|
| Simples y rápidas  | ✅                         | ❌ (requiere definir clase) |
| Nombradas          | ✅ (desde C# 7)            | ✅                        |
| Inmutabilidad      | ❌                         | ✅ (si defines `readonly`) |
| Uso recomendado    | Retornos temporales       | Entidades con lógica      |

---

### ✅ Buenas prácticas

- Usa tuplas si necesitas retornar múltiples valores *sin lógica asociada*.
- Prefiere clases o structs si la estructura tiene lógica de negocio o será reutilizada.
- Dale nombres a las propiedades de la tupla para mejor legibilidad.
