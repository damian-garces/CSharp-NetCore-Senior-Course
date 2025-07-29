// Sample code
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("=== Task and Task<T> ===");
        await DoSomethingAsync();
        int result = await GetNumberAsync();
        Console.WriteLine($"Received: {result}");

        Console.WriteLine("\n=== ValueTask<T> ===");
        var value = await GetCachedValueAsync();
        Console.WriteLine($"Cached value: {value}");

        Console.WriteLine("\n=== Thread ===");
        var thread = new Thread(() =>
        {
            Console.WriteLine($"Running in thread: {Thread.CurrentThread.ManagedThreadId}");
        });
        thread.Start();
        thread.Join();

        Console.WriteLine("\n=== Task.Run ===");
        int computeResult = await Task.Run(() => ComputeHeavyWork());
        Console.WriteLine($"Computed: {computeResult}");

        Console.WriteLine("\n=== Task.WhenAll ===");
        await Task.WhenAll(Task1(), Task2());

        Console.WriteLine("\n=== Task.WhenAny ===");
        var finished = await Task.WhenAny(Task1(), Task2());
        Console.WriteLine("One task finished.");

        Console.WriteLine("\n=== Task.WaitAll (blocking) ===");
        Task.WaitAll(Task1(), Task2());

        Console.WriteLine("\n=== Task.WaitAny (blocking) ===");
        int index = Task.WaitAny(Task1(), Task2());
        Console.WriteLine($"Task {index} completed first.");
    }

    static async Task DoSomethingAsync()
    {
        await Task.Delay(500);
        Console.WriteLine("Done with DoSomethingAsync.");
    }

    static async Task<int> GetNumberAsync()
    {
        await Task.Delay(300);
        return 100;
    }

    static int? _cached = 42;
    static ValueTask<int> GetCachedValueAsync()
    {
        if (_cached.HasValue)
            return new ValueTask<int>(_cached.Value);
        return new ValueTask<int>(GetNumberAsync());
    }

    static int ComputeHeavyWork()
    {
        Thread.Sleep(500); // Simulate heavy sync operation
        return 999;
    }

    static async Task Task1()
    {
        await Task.Delay(400);
        Console.WriteLine("Task 1 completed.");
    }

    static async Task Task2()
    {
        await Task.Delay(600);
        Console.WriteLine("Task 2 completed.");
    }
}
