# Delegates, Func, Action, Predicate

## English

### What is a Delegate?

A **delegate** in C# is a type that represents references to methods with a specific parameter list and return type. Think of it as a type-safe function pointer. Delegates are essential for implementing patterns such as events, callbacks, or dynamic strategies.

```csharp
public delegate int Operation(int a, int b);

Operation add = (x, y) => x + y;
int result = add(2, 3); // result = 5
```

### Func, Action and Predicate

These are *generic delegates* defined by .NET to simplify usage without having to declare custom ones.

#### Func

`Func<T1, T2, ..., TResult>` represents a method that accepts parameters (`T1`, `T2`, ...) and returns a value of type `TResult`.

```csharp
Func<int, int, int> add = (a, b) => a + b;
int result = add(4, 6); // result = 10
```

#### Action

`Action<T1, T2, ...>` represents a method that accepts parameters and **returns no value** (`void`).

```csharp
Action<string> print = message => Console.WriteLine(message);
print("Hello world");
```

#### Predicate

`Predicate<T>` represents a method that accepts a parameter of type `T` and returns a `bool`. Commonly used for filtering.

```csharp
Predicate<int> isEven = x => x % 2 == 0;
bool result = isEven(4); // true
```

## Español

### ¿Qué es un Delegate?

Un **delegate** en C# es un tipo que representa referencias a métodos con una lista de parámetros y tipo de retorno específicos. Se puede pensar como un puntero a función en otros lenguajes, pero seguro y orientado a objetos. Son esenciales para implementar patrones como eventos, callbacks o estrategias dinámicas.

```csharp
public delegate int Operacion(int a, int b);

Operacion suma = (x, y) => x + y;
int resultado = suma(2, 3); // resultado = 5
```

### Func, Action y Predicate

Son *delegados genéricos* definidos por .NET para facilitar el uso sin tener que declarar uno personalizado.

#### Func

`Func<T1, T2, ..., TResult>` representa un método que acepta parámetros (`T1`, `T2`, ...) y devuelve un valor de tipo `TResult`.

```csharp
Func<int, int, int> sumar = (a, b) => a + b;
int resultado = sumar(4, 6); // resultado = 10
```

#### Action

`Action<T1, T2, ...>` representa un método que acepta parámetros y **no devuelve ningún valor** (`void`).

```csharp
Action<string> imprimir = mensaje => Console.WriteLine(mensaje);
imprimir("Hola mundo");
```

#### Predicate

`Predicate<T>` representa un método que acepta un parámetro de tipo `T` y devuelve un `bool`. Se usa comúnmente en métodos de filtrado.

```csharp
Predicate<int> esPar = x => x % 2 == 0;
bool resultado = esPar(4); // true
```
