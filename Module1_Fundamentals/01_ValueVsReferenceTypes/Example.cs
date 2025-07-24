// Sample code
using System;

namespace ValueVsReferenceTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Value type example
            int x = 10;
            int y = x; // y is a copy of x
            y = 20;

            Console.WriteLine("Value types:");
            Console.WriteLine($"x = {x}"); // 10
            Console.WriteLine($"y = {y}"); // 20

            // Reference type example
            Person person1 = new Person { Name = "Alice" };
            Person person2 = person1; // person2 references the same object as person1
            person2.Name = "Bob";

            Console.WriteLine("\nReference types:");
            Console.WriteLine($"person1.Name = {person1.Name}"); // Bob
            Console.WriteLine($"person2.Name = {person2.Name}"); // Bob
        }
    }

    class Person
    {
        public string Name { get; set; }
    }
}
