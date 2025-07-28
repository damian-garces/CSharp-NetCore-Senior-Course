// Sample code
using System;

class Program
{
    static void Main()
    {
        // Example 1: Tuple with named fields
        var person = GetPersonData();
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");

        // Example 2: Deconstruction of a tuple
        var (name, age) = GetPersonData();
        Console.WriteLine($"Deconstructed -> Name: {name}, Age: {age}");

        // Example 3: Deconstructing a class with a Deconstruct method
        var anotherPerson = new Person("Vanne", 30);
        var (n, a) = anotherPerson;
        Console.WriteLine($"Deconstructed Class -> Name: {n}, Age: {a}");
    }

    // Returns a named tuple
    static (string Name, int Age) GetPersonData() => ("Damian", 35);
}

// Class with Deconstruct method
public class Person
{
    public string Name { get; }
    public int Age { get; }

    public Person(string name, int age) => (Name, Age) = (name, age);

    public void Deconstruct(out string name, out int age)
    {
        name = Name;
        age = Age;
    }
}
