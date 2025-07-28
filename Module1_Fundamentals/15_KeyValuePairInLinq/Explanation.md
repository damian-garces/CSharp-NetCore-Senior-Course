# KeyValuePair<TKey, TValue> in LINQ

## English

### 📘 KeyValuePair<TKey, TValue> in LINQ

#### What is KeyValuePair?

`KeyValuePair<TKey, TValue>` is a structure that represents a key-value pair. It is commonly used in collections such as `Dictionary<TKey, TValue>`. Each element in a dictionary is internally a `KeyValuePair`.

```csharp
Dictionary<int, string> dict = new Dictionary<int, string>
{
    { 1, "One" },
    { 2, "Two" }
};

foreach (KeyValuePair<int, string> pair in dict)
{
    Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
}
```

---

### 📌 Using KeyValuePair in LINQ

When working with `Dictionary` and LINQ, the elements processed in queries are of type `KeyValuePair<TKey, TValue>`. This allows you to use the key or value in lambda expressions.

#### 🔍 Example 1: Filter by value

```csharp
var result = dict.Where(pair => pair.Value.StartsWith("T"));
```

#### 🔍 Example 2: Projection with Select

```csharp
var keys = dict.Select(pair => pair.Key);
```

#### 🔍 Example 3: Flatten nested dictionaries

Suppose a structure like this:

```csharp
Dictionary<string, List<int>> groups = new Dictionary<string, List<int>>
{
    { "Even", new List<int> { 2, 4, 6 } },
    { "Odd", new List<int> { 1, 3, 5 } }
};
```

You can use LINQ to flatten the structure:

```csharp
var flat = groups.SelectMany(pair => pair.Value.Select(n => new { Group = pair.Key, Number = n }));
```

---

### 🤔 Why is it useful?

- Allows filtering and projecting directly on keys and values.
- Facilitates the transformation of dictionary-like structures.
- Compatible with `GroupBy`, `ToDictionary`, `Join`, and more.

---

## Español

### 📘 KeyValuePair<TKey, TValue> en LINQ

#### ¿Qué es KeyValuePair?

`KeyValuePair<TKey, TValue>` es una estructura que representa un par clave-valor. Es comúnmente usada en colecciones como `Dictionary<TKey, TValue>`. Cada elemento de un diccionario es internamente un `KeyValuePair`.

```csharp
Dictionary<int, string> dict = new Dictionary<int, string>
{
    { 1, "One" },
    { 2, "Two" }
};

foreach (KeyValuePair<int, string> pair in dict)
{
    Console.WriteLine($"Clave: {pair.Key}, Valor: {pair.Value}");
}
```

---

### 📌 Uso de KeyValuePair en LINQ

Cuando trabajamos con `Dictionary` y LINQ, los elementos que se procesan en las consultas son de tipo `KeyValuePair<TKey, TValue>`. Esto permite usar la clave o el valor en las expresiones lambda.

#### 🔍 Ejemplo 1: Filtrar por valor

```csharp
var result = dict.Where(pair => pair.Value.StartsWith("T"));
```

#### 🔍 Ejemplo 2: Proyección con Select

```csharp
var claves = dict.Select(pair => pair.Key);
```

#### 🔍 Ejemplo 3: Agrupar diccionarios anidados

Supón una estructura como:

```csharp
Dictionary<string, List<int>> grupos = new Dictionary<string, List<int>>
{
    { "Pares", new List<int> { 2, 4, 6 } },
    { "Impares", new List<int> { 1, 3, 5 } }
};
```

Puedes usar LINQ para aplanar la estructura:

```csharp
var planos = grupos.SelectMany(pair => pair.Value.Select(n => new { Grupo = pair.Key, Numero = n }));
```

---

### 🤔 ¿Por qué es útil?

- Permite realizar filtros y proyecciones sobre claves y valores directamente.
- Facilita la transformación de estructuras tipo diccionario.
- Es compatible con `GroupBy`, `ToDictionary`, `Join`, etc.
