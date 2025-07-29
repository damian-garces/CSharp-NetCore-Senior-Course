// Sample code
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitExamples
{
    public class AsyncService
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task RunAsyncOperations(CancellationToken cancellationToken)
        {
            try
            {
                Console.WriteLine("Starting async operations...");

                // Await with ConfigureAwait(false) to avoid capturing the context
                string data = await DownloadDataAsync("https://example.com", cancellationToken)
                                    .ConfigureAwait(false);
                Console.WriteLine($"Downloaded data: {data.Substring(0, Math.Min(data.Length, 50))}");

                // Fire-and-forget task with error handling
                _ = SafeFireAndForget();

                // Running multiple tasks in parallel
                await RunMultipleTasks(cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        }

        private async Task<string> DownloadDataAsync(string url, CancellationToken token)
        {
            Console.WriteLine($"Fetching data from {url}");
            var result = await httpClient.GetStringAsync(url, token);
            return result;
        }

        private async Task SafeFireAndForget()
        {
            try
            {
                await Task.Delay(500); // Simulate background work
                Console.WriteLine("Background task completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in fire-and-forget: {ex.Message}");
            }
        }

        private async Task RunMultipleTasks(CancellationToken cancellationToken)
        {
            var task1 = Task.Delay(1000, cancellationToken);
            var task2 = Task.Delay(1500, cancellationToken);

            try
            {
                await Task.WhenAll(task1, task2);
                Console.WriteLine("Both tasks completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"One or more tasks failed: {ex.Message}");
            }
        }
    }

    class Program
    {
        static async Task Main()
        {
            var service = new AsyncService();
            using var cts = new CancellationTokenSource();
            await service.RunAsyncOperations(cts.Token);
        }
    }
}
