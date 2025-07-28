// Sample code
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

class Program
{
    static void Main()
    {
        // Example 1: ReadOnlyCollection<T>
        var list = new List<string> { "apple", "banana", "cherry" };
        var readOnly = new ReadOnlyCollection<string>(list);

        Console.WriteLine("ReadOnlyCollection:");
        foreach (var item in readOnly)
        {
            Console.WriteLine(item);
        }

        // Modifying original list reflects in the read-only wrapper
        list.Add("date");
        Console.WriteLine("\nAfter adding 'date' to the original list:");
        foreach (var item in readOnly)
        {
            Console.WriteLine(item);
        }

        // Example 2: ReadOnlySpan<T> from string
        ReadOnlySpan<char> span = "Hello World".AsSpan(0, 5);
        Console.WriteLine($"\nReadOnlySpan sample: {span.ToString()}");

        // Example 3: Advanced ReadOnlySpan<T> - Split words without allocations
        Console.WriteLine("\nSplitting words from sentence without allocations:");
        ReadOnlySpan<char> sentence = "C# is fast and memory-efficient!".AsSpan();
        int wordStart = 0;

        for (int i = 0; i < sentence.Length; i++)
        {
            if (sentence[i] == ' ' || i == sentence.Length - 1)
            {
                int wordEnd = (i == sentence.Length - 1) ? i + 1 : i;
                ReadOnlySpan<char> word = sentence.Slice(wordStart, wordEnd - wordStart);
                Console.WriteLine(word.ToString());
                wordStart = i + 1;
            }
        }
    }
}
