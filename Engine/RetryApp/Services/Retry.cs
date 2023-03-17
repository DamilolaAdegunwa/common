using Polly;
using Polly.Retry;
using System.Net.Sockets;
namespace RetryApp.Services
{
    public class RetryHandler : DelegatingHandler
    {
        readonly AsyncRetryPolicy policy;
        

        public RetryHandler()
        {
            InnerHandler = new HttpClientHandler();
            policy = Policy
                .Handle<TimeoutException>()
                .Or<SocketException>()
                .RetryAsync(onRetry: OnRetry);
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
        {
            return await policy.ExecuteAsync(
                async () =>
                {
                    return await base.SendAsync(request, cancellationToken);
                });
        }

        private void OnRetry(Exception ex, int retryCount)
        {
            Console.WriteLine("Retrying timed out request");
            Console.WriteLine(ex.Message);
        }
    }
}