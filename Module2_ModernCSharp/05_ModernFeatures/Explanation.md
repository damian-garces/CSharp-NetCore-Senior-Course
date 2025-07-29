# File-scoped Namespace, Top-level Statements, and Raw String Literals

## English

### 1. File-scoped namespace
Introduced in C# 10, a file-scoped namespace allows you to define a namespace for the entire file without using curly braces.

#### ✅ Traditional:
```csharp
namespace MyApp.Utilities
{
    public class Logger
    {
        public void Log(string message) { }
    }
}
```

#### ✅ File-scoped:
```csharp
namespace MyApp.Utilities;

public class Logger
{
    public void Log(string message) { }
}
```

- Only one file-scoped namespace per file is allowed.
- Helps reduce indentation and improve clarity.

---

### 2. Top-level statements
Since C# 9, you can write code directly without defining a `Program` class or `Main` method explicitly.

#### ✅ Classic:
```csharp
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello world");
    }
}
```

#### ✅ Top-level:
```csharp
Console.WriteLine("Hello world");
```

- You can use `await` directly.
- `args` is available implicitly.
- Great for quick programs or educational examples.

---

### 3. Raw string literals
Introduced in C# 11, they allow writing multi-line strings without escaping backslashes, quotes, or line breaks.

```csharp
string json = """
{
  "name": "Damian",
  "escaped": "C:\\Users\\Damian\\Documents"
}""";

string name = "Damian";
string message = $"""
Hello, {name}!
Welcome to C# 11.
""";
```

- Start and end with triple quotes `"""`
- Supports interpolation with `$"""..."""`

---

## Español

### 1. File-scoped namespace (Espacio de nombres a nivel de archivo)
Introducido en C# 10, permite declarar un espacio de nombres que aplica a todo el archivo sin llaves.

#### ✅ Antes:
```csharp
namespace MyApp.Utilities
{
    public class Logger
    {
        public void Log(string message) { }
    }
}
```

#### ✅ Ahora:
```csharp
namespace MyApp.Utilities;

public class Logger
{
    public void Log(string message) { }
}
```

- Solo puede haber un namespace por archivo en este estilo.
- Reduce indentación y mejora la legibilidad.

---

### 2. Top-level statements (Instrucciones de nivel superior)
Desde C# 9 puedes escribir código directamente, sin definir `Main`.

#### ✅ Antes:
```csharp
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hola mundo");
    }
}
```

#### ✅ Ahora:
```csharp
Console.WriteLine("Hola mundo");
```

- Puedes usar `await` directamente.
- `args` está disponible implícitamente.
- Ideal para scripts o ejemplos educativos.

---

### 3. Raw string literals (Cadenas literales sin escape)
Introducidas en C# 11, permiten escribir strings multilínea sin escapar comillas ni saltos de línea.

```csharp
string json = """
{
  "name": "Damián",
  "escaped": "C:\\Users\\Damian\\Documents"
}""";

string name = "Damián";
string message = $"""
Hola, {name}!
Bienvenido a C# 11.
""";
```

- Se usan tres comillas dobles `"""`
- Soportan interpolación con `$"""..."""`