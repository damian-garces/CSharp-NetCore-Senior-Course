// Sample code
using System;
using System.Collections.Generic;

namespace DelegateExamples
{
    // Custom delegate
    public delegate int Operation(int x, int y);

    class Program
    {
        static void Main()
        {
            // Using a custom delegate
            Operation add = (a, b) => a + b;
            Console.WriteLine($"Custom delegate add: {add(3, 5)}");

            // Func<T1, T2, TResult>
            Func<int, int, int> multiply = (a, b) => a * b;
            Console.WriteLine($"Func multiply: {multiply(4, 6)}");

            // Action<T>
            Action<string> greet = name => Console.WriteLine($"Hello, {name}!");
            greet("Damián");

            // Predicate<T>
            Predicate<int> isEven = number => number % 2 == 0;
            Console.WriteLine($"Is 8 even? {isEven(8)}");

            // Using Predicate in a List
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            List<int> evenNumbers = numbers.FindAll(isEven);
            Console.WriteLine("Even numbers found:");
            evenNumbers.ForEach(n => Console.WriteLine(n));
        }
    }
}
