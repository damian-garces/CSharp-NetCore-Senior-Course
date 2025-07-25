using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsExample
{
    public class Program
    {
        public static void Main()
        {
            // List<T>: concrete, mutable
            List<string> names = new List<string> { "Alice", "Bob", "Charlie", "David" };

            // ICollection<T>: can add/remove/count, but no index access directly
            ICollection<string> nameCollection = names;
            nameCollection.Add("Eva");

            // IList<T>: supports index-based access
            IList<string> nameList = names;
            nameList[0] = "Alex";

            // IEnumerable<T>: read-only, supports iteration
            IEnumerable<string> nameEnumerable = names.Where(n => n.StartsWith("A")); // Deferred execution

            Console.WriteLine("IEnumerable result:");
            foreach (var name in nameEnumerable) // Deferred executed here
            {
                Console.WriteLine(name);
            }

            // IQueryable<T>: would be used with a database context
            // Example (commented because it needs EF):
            // IQueryable<User> users = dbContext.Users.Where(u => u.IsActive);

            Console.WriteLine("\nIList access:");
            Console.WriteLine($"First name: {nameList[0]}");

            Console.WriteLine("\nICollection count:");
            Console.WriteLine($"Total names: {nameCollection.Count}");
        }
    }
}