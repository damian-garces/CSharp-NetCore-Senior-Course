// Sample code
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncStreamExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Streaming numbers asynchronously:");

            await foreach (var number in GetNumbersAsync())
            {
                Console.WriteLine($"Received: {number}");
            }

            Console.WriteLine("Done!");
        }

        public static async IAsyncEnumerable<int> GetNumbersAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            for (int i = 1; i <= 5; i++)
            {
                // Simulate a delay for each item (e.g., from database, file, or API)
                await Task.Delay(500, cancellationToken);
                yield return i;
            }
        }
    }
}
