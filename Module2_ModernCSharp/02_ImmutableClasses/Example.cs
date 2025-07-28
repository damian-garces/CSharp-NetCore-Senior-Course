// Sample code
using System;
using System.Collections.Generic;

public class Product
{
    public string Name { get; init; }
    public decimal Price { get; init; }
}

public class CatalogWithMutable
{
    // This is NOT fully immutable if someone modifies the list directly
    public List<string> Items { get; init; } = new();
}

public class CatalogSafe
{
    public IReadOnlyList<string> Items { get; init; }

    public CatalogSafe(IEnumerable<string> items)
    {
        Items = new List<string>(items);
    }
}

public class Program
{
    public static void Main()
    {
        var product = new Product
        {
            Name = "Smartphone",
            Price = 799.99m
        };

        Console.WriteLine($"Product: {product.Name} - ${product.Price}");

        var catalog = new CatalogWithMutable
        {
            Items = new List<string> { "Book", "Pen" }
        };

        catalog.Items.Add("Notebook"); // ⚠ This breaks immutability

        Console.WriteLine("Mutable Catalog:");
        foreach (var item in catalog.Items)
        {
            Console.WriteLine($" - {item}");
        }

        var safeCatalog = new CatalogSafe(new[] { "Laptop", "Mouse" });

        Console.WriteLine("Safe Catalog:");
        foreach (var item in safeCatalog.Items)
        {
            Console.WriteLine($" - {item}");
        }
    }
}
