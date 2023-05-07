using Polly;
using Polly.Retry;
using RetryApp.Services;
using System.Net.Http;

namespace RetryApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            new Program().RetrySample1().Wait();

            Console.WriteLine("done!");
        }

        public async Task RetrySample1()
        {
            var client = new HttpClient(new RetryHandler());
            var response = await client.GetAsync("http://example.com");
            Console.WriteLine(response);
        }

        public async Task RetrySample2()
        {
            AsyncRetryPolicy policy = Policy
    .Handle<HttpRequestException>()
    //.OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
    .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
            var handler = new RetryHandler(policy);
            var client = new HttpClient(handler);
            var response = await client.GetAsync("http://example.com");

        }

        public async Task RetrySample3()
        {
            var policy = Policy
    .Handle<TimeoutException>()
    .RetryAsync(3, onRetry: (ex, count) => Console.WriteLine($"Timeout retry #{count}"));
            var handlers = new List<DelegatingHandler>()
            {
                new RetryHandler(policy),
                new AuthenticationHandler(),
                new LoggingHandler(),
                new TimeoutHandler()
            };
            var client = HttpClientFactory.Create(handlers.ToArray());
            var response = await client.GetAsync("http://example.com");

        }
    }
}