// Sample code
using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is not Person other)
            return false;

        return Name == other.Name && Age == other.Age;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Age);
    }

    public static bool operator ==(Person left, Person right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Person left, Person right)
    {
        return !Equals(left, right);
    }
}

public class PersonComparer : IEqualityComparer<Person>
{
    public bool Equals(Person x, Person y)
    {
        return x.Name == y.Name && x.Age == y.Age;
    }

    public int GetHashCode(Person obj)
    {
        return HashCode.Combine(obj.Name, obj.Age);
    }
}

public class Program
{
    public static void Main()
    {
        var person1 = new Person { Name = "Alice", Age = 30 };
        var person2 = new Person { Name = "Alice", Age = 30 };
        var person3 = person1;

        Console.WriteLine($"person1 == person2: {person1 == person2}"); // True (custom operator)
        Console.WriteLine($"ReferenceEquals(person1, person2): {ReferenceEquals(person1, person2)}"); // False
        Console.WriteLine($"ReferenceEquals(person1, person3): {ReferenceEquals(person1, person3)}"); // True

        var people = new HashSet<Person>(new PersonComparer());
        people.Add(person1);
        people.Add(person2); // Won't be added because comparer sees them as equal

        Console.WriteLine($"People count in HashSet: {people.Count}"); // 1
    }
}
