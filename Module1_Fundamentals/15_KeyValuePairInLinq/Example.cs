// Sample code
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Example 1: Basic KeyValuePair iteration
        Dictionary<int, string> numbers = new Dictionary<int, string>
        {
            { 1, "One" },
            { 2, "Two" },
            { 3, "Three" }
        };

        foreach (KeyValuePair<int, string> pair in numbers)
        {
            Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
        }

        Console.WriteLine("\nExample 2: LINQ filter (values starting with 'T'):");
        var filtered = numbers.Where(pair => pair.Value.StartsWith("T"));
        foreach (var pair in filtered)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }

        Console.WriteLine("\nExample 3: LINQ select keys:");
        var keys = numbers.Select(pair => pair.Key);
        foreach (var key in keys)
        {
            Console.WriteLine($"Key: {key}");
        }

        Console.WriteLine("\nExample 4: Flattening nested dictionary:");
        Dictionary<string, List<int>> groups = new Dictionary<string, List<int>>
        {
            { "Even", new List<int> { 2, 4, 6 } },
            { "Odd", new List<int> { 1, 3, 5 } }
        };

        var flattened = groups.SelectMany(
            pair => pair.Value.Select(value => new { Group = pair.Key, Number = value }));

        foreach (var item in flattened)
        {
            Console.WriteLine($"Group: {item.Group}, Number: {item.Number}");
        }
    }
}
