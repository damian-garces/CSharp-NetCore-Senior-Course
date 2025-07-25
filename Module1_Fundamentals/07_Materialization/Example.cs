// Sample code
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaterializationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate a sequence of numbers from 1 to 10
            IEnumerable<int> numbers = Enumerable.Range(1, 10);

            // Materialize using ToList()
            List<int> list = numbers.ToList();
            Console.WriteLine("Contents of the list:");
            foreach (var n in list)
            {
                Console.Write(n + " ");
            }

            // Lists are mutable, so we can add more elements
            list.Add(11);
            Console.WriteLine("\nAfter adding an element to the list:");
            Console.WriteLine(string.Join(", ", list));

            // Materialize using ToArray()
            int[] array = numbers.ToArray();
            Console.WriteLine("\nContents of the array:");
            foreach (var n in array)
            {
                Console.Write(n + " ");
            }

            // Fast index-based access with arrays
            Console.WriteLine("\nSecond element of the array: " + array[1]);

            // Using First()
            int first = numbers.First(); // Throws if the sequence is empty
            Console.WriteLine("\nFirst number using First(): " + first);

            // Using FirstOrDefault()
            IEnumerable<int> empty = Enumerable.Empty<int>();
            int defaultFirst = empty.FirstOrDefault(); // Returns default value instead of throwing
            Console.WriteLine("FirstOrDefault() on empty sequence: " + defaultFirst);
        }
    }
}
