// example.cs
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("-- Deferred Execution Example --");
        var numbers1 = new List<int> { 1, 2, 3, 4, 5 };
        var deferred = numbers1.Where(n => n % 2 == 0);

        numbers1.Add(6); // This will affect deferred query

        foreach (var n in deferred)
        {
            Console.WriteLine(n); // Output: 2, 4, 6
        }

        Console.WriteLine("-- Immediate Execution Example --");
        var numbers2 = new List<int> { 1, 2, 3, 4, 5 };
        var immediate = numbers2.Where(n => n % 2 == 0).ToList();

        numbers2.Add(6); // This will NOT affect immediate query

        foreach (var n in immediate)
        {
            Console.WriteLine(n); // Output: 2, 4
        }
    }
}