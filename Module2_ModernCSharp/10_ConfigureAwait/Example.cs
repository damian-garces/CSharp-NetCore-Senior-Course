// Sample code
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Starting...");
        await RunAsync();
        Console.WriteLine("Finished.");
    }

    private static async Task RunAsync()
    {
        await LogToFileAsync("Operation started").ConfigureAwait(false);

        var data = await FetchDataFromApiAsync("https://jsonplaceholder.typicode.com/posts/1")
                           .ConfigureAwait(false);

        Console.WriteLine("Data received:");
        Console.WriteLine(data);

        await LogToFileAsync("Operation finished").ConfigureAwait(false);
    }

    // Example 1: Async file I/O - safe to use ConfigureAwait(false)
    private static async Task LogToFileAsync(string message)
    {
        using var writer = new StreamWriter("log.txt", append: true);
        await writer.WriteLineAsync($"{DateTime.UtcNow}: {message}").ConfigureAwait(false);
    }

    // Example 2: HTTP request - safe to use ConfigureAwait(false)
    private static async Task<string> FetchDataFromApiAsync(string url)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(url).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
    }
}
