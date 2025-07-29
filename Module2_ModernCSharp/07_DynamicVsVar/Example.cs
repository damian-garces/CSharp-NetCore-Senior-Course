// Sample code
using System;

class Program
{
    static void Main()
    {
        // Example with 'var': the compiler infers the type at compile-time
        var message = "Hello, Damian!";
        Console.WriteLine($"message is of type: {message.GetType().Name} and value: {message}");

        // Uncommenting the following line would cause a compile-time error
        // message = 123; // Error: Cannot implicitly convert type 'int' to 'string'

        // Example with 'dynamic': the type is resolved at runtime
        dynamic data = "Dynamic Damian";
        Console.WriteLine($"data is of type: {data.GetType().Name} and value: {data}");
        Console.WriteLine($"Length of data: {data.Length}");

        // Changing the type at runtime
        data = 42;
        Console.WriteLine($"data is now of type: {data.GetType().Name} and value: {data}");

        try
        {
            // This will throw a runtime exception because 'int' has no Length property
            Console.WriteLine($"Trying to access Length: {data.Length}");
        }
        catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
        {
            Console.WriteLine($"Runtime error: {ex.Message}");
        }
    }
}
