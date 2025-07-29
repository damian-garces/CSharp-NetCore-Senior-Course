// Sample code
using System;

namespace RefOutInExamples
{
    class Program
    {
        static void Main()
        {
            // Example using ref
            int a = 5;
            Console.WriteLine($"Original a: {a}");
            Increment(ref a);
            Console.WriteLine($"After ref Increment: {a}");

            // Example using out
            int result;
            bool success = TryParseToInt("123", out result);
            Console.WriteLine(success
                ? $"Parsed successfully: {result}"
                : "Parsing failed.");

            // Example using in
            ReadOnlySpan<char> name = "Damian".AsSpan();
            PrintLength(in name);
        }

        // ref example: allows read and write
        static void Increment(ref int number)
        {
            number++;
        }

        // out example: must assign value before returning
        static bool TryParseToInt(string input, out int value)
        {
            return int.TryParse(input, out value);
        }

        // in example: read-only and passed by reference
        static void PrintLength(in ReadOnlySpan<char> span)
        {
            Console.WriteLine($"Length is: {span.Length}");
        }
    }
}
