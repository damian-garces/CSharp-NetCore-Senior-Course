// Sample code
using System;
using System.Collections.Generic;

namespace VarVsExplicitTypes
{
    public class Client
    {
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // ✔️ var used correctly (type is obvious)
            var names = new List<string> { "Alice", "Bob", "Charlie" };
            Console.WriteLine("Name count (using var): " + names.Count);

            // ❌ var used poorly (type is not clear)
            var result = GetUnknownData(); // What type is this?
            Console.WriteLine("Result: " + result);

            // ✔️ explicit type improves clarity
            Client client = GetClient();
            Console.WriteLine("Client name: " + client.Name);
        }

        static object GetUnknownData()
        {
            return "Some unknown data";
        }

        static Client GetClient()
        {
            return new Client { Name = "Damian" };
        }
    }
}
