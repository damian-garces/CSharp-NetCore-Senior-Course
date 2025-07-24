// Sample code
using System;

class Program
{
    static void Main()
    {
        // Using nullable value type (?)
        int? age = null;
        Console.WriteLine($"Age is: {(age.HasValue ? age.Value.ToString() : "null")}");

        // Using null-coalescing operator (??)
        int finalAge = age ?? 25;
        Console.WriteLine($"Final age with ?? operator: {finalAge}");

        // Using ?? with reference type
        string name = null;
        string displayName = name ?? "Unknown";
        Console.WriteLine($"Name is: {displayName}");

        // Using null-coalescing assignment operator (??=)
        string nickname = null;
        nickname ??= "Guest";
        Console.WriteLine($"Nickname after ??= assignment: {nickname}");

        // Demonstrating all in one go
        int? score = null;
        Console.WriteLine($"Score: {score ?? 100}");

        string title = null;
        title ??= "Untitled";
        Console.WriteLine($"Title: {title}");
    }
}
