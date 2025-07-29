// Sample code
// example.cs

// Minimal API Example (Program.cs)
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/minimal/products/{id}", (int id) =>
{
    return Results.Ok(new Product { Id = id, Name = $"Product {id}" });
});

app.Run();

public record Product
{
    public int Id { get; init; }
    public string Name { get; init; }
}

// Controller Example (ProductsController.cs)
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var product = new Product { Id = id, Name = $"Product {id}" };
        return Ok(product);
    }
}
