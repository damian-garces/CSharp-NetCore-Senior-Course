// Sample code
using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine(GetRoleDescription("Admin"));
        Console.WriteLine(GetSize(12));

        object obj = "HelloWorld";
        if (obj is string s && s.Length > 5)
        {
            Console.WriteLine($"String longer than 5: {s}");
        }

        int age = 30;
        if (age is > 18 and < 65)
        {
            Console.WriteLine("Working age adult");
        }

        var input = ("Admin", 3);
        string result = input switch
        {
            ("Admin", >= 3) => "Senior Admin",
            ("Admin", < 3) => "Junior Admin",
            ("User", _) => "Regular User",
            _ => "Unknown Role"
        };
        Console.WriteLine(result);

        DateTime date = DateTime.Today;
        Console.WriteLine($"Is weekend? {IsWeekend(date)}");

        Person person = new() { Name = "John", Age = 25, Country = "Colombia" };
        if (person is { Age: >= 18, Country: "Colombia" })
        {
            Console.WriteLine("Colombian adult");
        }

        object maybePerson = person;
        if (maybePerson is Person { Age: > 18 } p && p.Name is not null)
        {
            Console.WriteLine($"{p.Name} is an adult.");
        }
    }

    public static string GetRoleDescription(string role) =>
        role switch
        {
            "Admin" => "Has full access",
            "User" => "Has limited access",
            "Guest" => "Has minimal access",
            _ => "Unknown role"
        };

    public static string GetSize(int size) => size switch
    {
        < 10 => "Small",
        >= 10 and <= 20 => "Medium",
        _ when size % 2 == 0 => "Large and even",
        _ => "Large"
    };

    public static bool IsWeekend(DateTime date) => date.DayOfWeek switch
    {
        DayOfWeek.Saturday or DayOfWeek.Sunday => true,
        _ => false
    };
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Country { get; set; }
}
