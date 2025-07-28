// Sample code
// File: example.cs

using System;

namespace RecordVsClassDemo
{
    // Classic reference type
    public class PersonClass
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString() => $"{Name} ({Age})";
    }

    // Reference type with value-based equality
    public record PersonRecord(string Name, int Age);

    // Value type with record-like behavior
    public readonly record struct Coordinates(double X, double Y);

    // Explicit record class (C# 10+)
    public record class Employee(string Name, int Id);

    class Program
    {
        static void Main()
        {
            // ===== CLASS Example =====
            var class1 = new PersonClass { Name = "Alice", Age = 30 };
            var class2 = new PersonClass { Name = "Alice", Age = 30 };

            Console.WriteLine("CLASS comparison:");
            Console.WriteLine($"class1 == class2: {class1 == class2}"); // false, reference comparison
            Console.WriteLine($"Equals: {class1.Equals(class2)}");     // false unless overridden
            Console.WriteLine();

            // ===== RECORD Example =====
            var record1 = new PersonRecord("Alice", 30);
            var record2 = new PersonRecord("Alice", 30);
            var record3 = record1 with { Age = 31 };

            Console.WriteLine("RECORD comparison:");
            Console.WriteLine($"record1 == record2: {record1 == record2}"); // true, value comparison
            Console.WriteLine($"record3 (with Age changed): {record3}");
            Console.WriteLine();

            // ===== RECORD STRUCT Example =====
            var coord1 = new Coordinates(10, 20);
            var coord2 = new Coordinates(10, 20);
            var coord3 = coord1 with { Y = 99 };

            Console.WriteLine("RECORD STRUCT comparison:");
            Console.WriteLine($"coord1 == coord2: {coord1 == coord2}"); // true, value comparison
            Console.WriteLine($"coord3 (modified): {coord3}");
            Console.WriteLine();

            // ===== RECORD CLASS Example =====
            var emp1 = new Employee("John", 1);
            var emp2 = new Employee("John", 1);

            Console.WriteLine("RECORD CLASS comparison:");
            Console.WriteLine($"emp1 == emp2: {emp1 == emp2}"); // true
            Console.WriteLine();

            // Notes on performance
            Console.WriteLine("RECORD STRUCTs avoid heap allocation and are better for small, immutable value types.");
        }
    }
}
