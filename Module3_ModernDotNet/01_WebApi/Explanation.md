# Web API: Controllers vs Minimal APIs

## English

### ✅ Introduction

In .NET 6 and later, Microsoft introduced **Minimal APIs** as a concise and functional way to build REST APIs, complementing traditional **Controllers** in ASP.NET Core.

Both approaches enable building robust HTTP APIs, but they follow different philosophies and suit different project needs.

---

### 🧱 Controllers

- Follow the classical ASP.NET Core MVC approach.
- Use classes decorated with `[ApiController]`, `[Route]`, `[HttpGet]`, etc.
- Separate responsibilities into methods per HTTP verb.
- Easily support filters (authorization, validation), versioning, conventions, and testing.
- More structured, ideal for large or complex projects.

**Example:**
```csharp
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetById(int id) => Ok(new { Id = id });
}
```

---

### ⚡ Minimal APIs

- Introduced in .NET 6 as part of top-level statements.
- Less ceremonious: no need for classes or attributes.
- Ideal for microservices, simple APIs, or prototypes.
- Defined directly in `Program.cs`.

**Example:**
```csharp
var app = WebApplication.Create(args);
app.MapGet("/products/{id}", (int id) => Results.Ok(new { Id = id }));
app.Run();
```

---

### 🤔 Which One to Choose?

| Feature                          | Controllers                 | Minimal APIs              |
|----------------------------------|-----------------------------|---------------------------|
| Verbosity                        | High                        | Low                       |
| Structure                        | Strong, class-based         | Lightweight, function-based |
| Testing                          | Very robust                 | Fewer tools available     |
| Extensibility                    | High                        | Medium                    |
| Scalability                      | High                        | Requires care             |
| Recommended For                  | Medium/large projects       | Microservices, prototypes |

---

### 💡 Recommendations

- Use **Minimal APIs** for small projects, microservices, or proof-of-concept APIs where agility and simplicity are key.
- Use **Controllers** if you need filters, versioning, complete testing support, and a robust structure.

---

## Español

### ✅ Introducción

En .NET 6 y versiones posteriores, Microsoft introdujo las **Minimal APIs**, una forma más concisa y funcional de construir APIs REST, que complementa a los tradicionales **Controllers** de ASP.NET Core.

Ambos enfoques permiten construir APIs HTTP robustas, pero tienen filosofías distintas y se adaptan a diferentes necesidades de proyecto.

---

### 🧱 Controllers

- Siguen el enfoque clásico de ASP.NET Core MVC.
- Utilizan clases decoradas con `[ApiController]`, `[Route]`, `[HttpGet]`, etc.
- Separan responsabilidades en métodos por verbo HTTP.
- Soportan fácilmente filtros (autorización, validación), versionamiento, convenciones y testing.
- Más estructurados, ideales para proyectos grandes o complejos.

**Ejemplo:**
```csharp
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetById(int id) => Ok(new { Id = id });
}
```

---

### ⚡ Minimal APIs

- Introducidos en .NET 6 como parte del paradigma de top-level statements.
- Menos ceremoniosos: no requieren clases ni atributos.
- Ideales para microservicios, APIs simples o prototipos.
- Se definen directamente en `Program.cs`.

**Ejemplo:**
```csharp
var app = WebApplication.Create(args);
app.MapGet("/products/{id}", (int id) => Results.Ok(new { Id = id }));
app.Run();
```

---

### 🤔 ¿Cuál elegir?

| Característica                   | Controllers                 | Minimal APIs              |
|----------------------------------|-----------------------------|---------------------------|
| Verbosidad                       | Alta                        | Baja                      |
| Estructura                       | Fuerte, basada en clases    | Ligera, basada en funciones |
| Testing                          | Muy robusto                 | Menos herramientas disponibles |
| Extensibilidad                   | Alta                        | Media                     |
| Escalabilidad                    | Alta                        | Requiere más cuidado      |
| Recomendado para                 | Proyectos medianos/grandes  | Microservicios, prototipos |

---

### 💡 Recomendaciones

- Usa **Minimal APIs** para proyectos pequeños, microservicios o pruebas de concepto donde la agilidad y simpleza son clave.
- Usa **Controllers** si necesitas filtros, versionamiento, soporte completo de testing y una estructura robusta.