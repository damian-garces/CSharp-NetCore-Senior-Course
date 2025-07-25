# Advanced LINQ: SelectMany, GroupBy, Join

## English

### SelectMany – Flattening and projecting collections

`SelectMany` is used when working with nested collections and you want to flatten them into a single sequence. It can also be used to project new data based on both parent and child items.

**Example:**
```csharp
var students = new[]
{
    new { Name = "Ana", Courses = new[] { "C#", "SQL" } },
    new { Name = "Luis", Courses = new[] { "Java", "SQL" } }
};

var result = students.SelectMany(
    student => student.Courses,
    (student, course) => new { student.Name, Course = course }
);
```

**Result:**
```
[
  { Name = "Ana", Course = "C#" },
  { Name = "Ana", Course = "SQL" },
  { Name = "Luis", Course = "Java" },
  { Name = "Luis", Course = "SQL" }
]
```

---

### GroupBy – Grouping and transforming data

`GroupBy` groups a collection by a key and allows further transformation and aggregation, such as counting or sorting within groups.

**Example:**
```csharp
var people = new[]
{
    new { Name = "Ana", City = "Bogotá" },
    new { Name = "Luis", City = "Medellín" },
    new { Name = "Pedro", City = "Bogotá" }
};

var summary = people
    .GroupBy(p => p.City)
    .Select(g => new
    {
        City = g.Key,
        Count = g.Count(),
        People = g.Select(p => p.Name).OrderBy(n => n).ToList()
    });
```

**Result:**
```
[
  { City = "Bogotá", Count = 2, People = ["Ana", "Pedro"] },
  { City = "Medellín", Count = 1, People = ["Luis"] }
]
```

---

### Join – Inner Join vs GroupJoin (Left Join)

#### Inner Join

An `Inner Join` combines elements from two collections based on matching keys. If no match is found, the element is excluded.

**Example:**
```csharp
var employees = new[]
{
    new { Id = 1, Name = "Ana", DepartmentId = 1 },
    new { Id = 2, Name = "Luis", DepartmentId = 2 }
};

var departments = new[]
{
    new { Id = 1, Name = "IT" },
    new { Id = 2, Name = "HR" },
    new { Id = 3, Name = "Sales" }
};

var result = employees.Join(
    departments,
    emp => emp.DepartmentId,
    dep => dep.Id,
    (emp, dep) => new { emp.Name, Department = dep.Name }
);
```

**Result:**
```
[
  { Name = "Ana", Department = "IT" },
  { Name = "Luis", Department = "HR" }
]
```

---

#### GroupJoin (Left Join)

`GroupJoin` simulates a `LEFT JOIN` by including all elements from the left collection, even if there are no matching elements in the right collection.

**Example:**
```csharp
var groupJoinResult = departments.GroupJoin(
    employees,
    dep => dep.Id,
    emp => emp.DepartmentId,
    (dep, emps) => new
    {
        Department = dep.Name,
        Employees = emps.Select(e => e.Name).ToList()
    }
);
```

**Result:**
```
[
  { Department = "IT", Employees = ["Ana"] },
  { Department = "HR", Employees = ["Luis"] },
  { Department = "Sales", Employees = [] }
]
```

---

**Query syntax alternative:**
```csharp
var result = from emp in employees
             join dep in departments
             on emp.DepartmentId equals dep.Id
             select new { emp.Name, Department = dep.Name };
```

---

## Español

### SelectMany – Aplanamiento y proyección de colecciones

`SelectMany` se utiliza para trabajar con colecciones anidadas y aplanarlas en una sola secuencia. También permite proyectar nuevos datos a partir del padre y el hijo.

**Ejemplo:**
```csharp
var alumnos = new[]
{
    new { Nombre = "Ana", Cursos = new[] { "C#", "SQL" } },
    new { Nombre = "Luis", Cursos = new[] { "Java", "SQL" } }
};

var resultado = alumnos.SelectMany(
    alumno => alumno.Cursos,
    (alumno, curso) => new { alumno.Nombre, Curso = curso }
);
```

**Resultado:**
```
[
  { Nombre = "Ana", Curso = "C#" },
  { Nombre = "Ana", Curso = "SQL" },
  { Nombre = "Luis", Curso = "Java" },
  { Nombre = "Luis", Curso = "SQL" }
]
```

---

### GroupBy – Agrupación y transformación de datos

`GroupBy` agrupa elementos por una clave y permite transformar y agregar datos, como contar o ordenar.

**Ejemplo:**
```csharp
var personas = new[]
{
    new { Nombre = "Ana", Ciudad = "Bogotá" },
    new { Nombre = "Luis", Ciudad = "Medellín" },
    new { Nombre = "Pedro", Ciudad = "Bogotá" }
};

var resumen = personas
    .GroupBy(p => p.Ciudad)
    .Select(g => new
    {
        Ciudad = g.Key,
        Cantidad = g.Count(),
        Personas = g.Select(p => p.Nombre).OrderBy(n => n).ToList()
    });
```

**Resultado:**
```
[
  { Ciudad = "Bogotá", Cantidad = 2, Personas = ["Ana", "Pedro"] },
  { Ciudad = "Medellín", Cantidad = 1, Personas = ["Luis"] }
]
```

---

### Join – Join interno vs GroupJoin (Left Join)

#### Join interno

Un `Join` interno une dos colecciones basándose en claves coincidentes. Si no hay coincidencia, el elemento se excluye del resultado.

**Ejemplo:**
```csharp
var empleados = new[]
{
    new { Id = 1, Nombre = "Ana", DepartamentoId = 1 },
    new { Id = 2, Nombre = "Luis", DepartamentoId = 2 }
};

var departamentos = new[]
{
    new { Id = 1, Nombre = "TI" },
    new { Id = 2, Nombre = "RRHH" },
    new { Id = 3, Nombre = "Ventas" }
};

var resultado = empleados.Join(
    departamentos,
    emp => emp.DepartamentoId,
    dep => dep.Id,
    (emp, dep) => new { emp.Nombre, Departamento = dep.Nombre }
);
```

**Resultado:**
```
[
  { Nombre = "Ana", Departamento = "TI" },
  { Nombre = "Luis", Departamento = "RRHH" }
]
```

---

#### GroupJoin (LEFT JOIN)

`GroupJoin` simula un `LEFT JOIN`, incluyendo todos los elementos de la colección izquierda aunque no tengan coincidencias en la derecha.

**Ejemplo:**
```csharp
var resultadoConDepartamentos = departamentos.GroupJoin(
    empleados,
    dep => dep.Id,
    emp => emp.DepartamentoId,
    (dep, empleadosDelDep) => new
    {
        Departamento = dep.Nombre,
        Empleados = empleadosDelDep.Select(e => e.Nombre).ToList()
    }
);
```

**Resultado:**
```
[
  { Departamento = "TI", Empleados = ["Ana"] },
  { Departamento = "RRHH", Empleados = ["Luis"] },
  { Departamento = "Ventas", Empleados = [] }
]
```

---

**Sintaxis de consulta alternativa:**
```csharp
var resultado = from emp in empleados
                join dep in departamentos
                on emp.DepartamentoId equals dep.Id
                select new { emp.Nombre, Departamento = dep.Nombre };
```