// Sample code
// File: example.cs

// 1. File-scoped namespace
namespace MyApp.Demo;

public class Greeter
{
    public void SayHello(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }
}

// 2. Top-level statements
// (If this code is in Program.cs, it can be compiled directly as a console app with no Main method)

using MyApp.Demo;

var greeter = new Greeter();
greeter.SayHello("Damian");

// Top-level also allows using async and args
await Task.Delay(500);
Console.WriteLine($"Number of args: {args.Length}");

// 3. Raw string literals
string json = """
{
  "id": 123,
  "name": "Test",
  "path": "C:\\Users\\Damian\\Documents"
}
""";

string userName = "Damian";
string welcome = $"""
Welcome, {userName}!
This is a raw string with interpolation.
""";

Console.WriteLine(json);
Console.WriteLine(welcome);
