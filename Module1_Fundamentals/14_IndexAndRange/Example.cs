// Sample code
using System;

class Program
{
    static void Main()
    {
        int[] numbers = { 10, 20, 30, 40, 50 };

        // Index from the end
        Console.WriteLine($"Last element: {numbers[^1]}");       // 50
        Console.WriteLine($"Second to last: {numbers[^2]}");     // 40

        // Range: slice of the array
        int[] slice1 = numbers[1..4];  // Elements 20, 30, 40
        Console.WriteLine("Slice 1 (1..4): " + string.Join(", ", slice1));

        int[] firstThree = numbers[..3];  // 10, 20, 30
        Console.WriteLine("First three (..3): " + string.Join(", ", firstThree));

        int[] lastTwo = numbers[^2..];    // 40, 50
        Console.WriteLine("Last two (^2..): " + string.Join(", ", lastTwo));

        int[] middle = numbers[1..^1];    // 20, 30, 40
        Console.WriteLine("Middle (1..^1): " + string.Join(", ", middle));

        // Span<T> + Range
        Span<int> span = numbers;
        Span<int> spanSlice = span[1..4]; // 20, 30, 40
        Console.WriteLine("Span slice (1..4): " + string.Join(", ", spanSlice.ToArray()));
    }
}
