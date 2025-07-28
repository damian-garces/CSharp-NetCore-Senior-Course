// Sample code
using System;
using System.Collections.Immutable;

class Program
{
    static void Main()
    {
        // Basic usage example of ImmutableList<T>
        var fruits = ImmutableList.Create<string>("apple", "banana");
        var newFruits = fruits.Add("cherry");

        Console.WriteLine("Original list:");
        Console.WriteLine(string.Join(", ", fruits));        // Output: apple, banana

        Console.WriteLine("New list after Add:");
        Console.WriteLine(string.Join(", ", newFruits));     // Output: apple, banana, cherry

        // Inefficient way: adding items one by one (creates a new list each time)
        var numbers = ImmutableList<int>.Empty;
        for (int i = 0; i < 1000; i++)
        {
            numbers = numbers.Add(i); // Not recommended for performance
        }

        Console.WriteLine($"Count using Add in loop: {numbers.Count}");

        // Efficient way using Builder
        var builder = ImmutableList.CreateBuilder<int>();
        for (int i = 0; i < 1000; i++)
        {
            builder.Add(i); // Mutates internal builder
        }
        var optimizedList = builder.ToImmutable(); // Single allocation

        Console.WriteLine($"Count using Builder: {optimizedList.Count}");
    }
}
