using RetryApp.Services;
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
    }
}