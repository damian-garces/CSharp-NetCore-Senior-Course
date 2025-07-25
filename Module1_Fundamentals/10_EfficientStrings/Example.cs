// Sample code
using System;
using System.Text;

class Program
{
    static void Main()
    {
        // Example 1: Using StringBuilder for efficient concatenation
        var sb = new StringBuilder();
        for (int i = 0; i < 10; i++)
        {
            sb.Append("Line ").Append(i).AppendLine();
        }

        string result = sb.ToString();
        Console.WriteLine("StringBuilder result:");
        Console.WriteLine(result);

        // Example 2: Using Span<T> for slicing a string
        ReadOnlySpan<char> span = "Hello, World!".AsSpan();
        ReadOnlySpan<char> hello = span.Slice(0, 5);
        ReadOnlySpan<char> world = span.Slice(7, 5);

        Console.WriteLine("Span slicing result:");
        Console.WriteLine($"hello = {hello.ToString()}");
        Console.WriteLine($"world = {world.ToString()}");

        // Example 3: Using Span<T> for manual parsing
        ReadOnlySpan<char> input = "1234,5678,91011";
        int total = 0;

        while (!input.IsEmpty)
        {
            int index = input.IndexOf(',');
            ReadOnlySpan<char> numberSpan;

            if (index == -1)
            {
                numberSpan = input;
                input = ReadOnlySpan<char>.Empty;
            }
            else
            {
                numberSpan = input.Slice(0, index);
                input = input.Slice(index + 1);
            }

            if (int.TryParse(numberSpan, out int number))
            {
                total += number;
            }
        }

        Console.WriteLine($"Total sum: {total}");
    }
}
