using Polly;
using Polly.Retry;
using System.Net.Sockets;
namespace RetryApp.Services
{
    public class RetryHandler : DelegatingHandler
    {
        readonly AsyncRetryPolicy policy = null;
        readonly AsyncRetryPolicy<HttpResponseMessage> httpResponseMessagePolicy = null;
        //readonly AsyncRetryPolicy<DummyHttpResponseMessage> dummyHttpResponseMessagePolicy = null;
        

        public RetryHandler()
        {
            InnerHandler = new HttpClientHandler();

            policy = Policy
                .Handle<TimeoutException>()
                .Or<SocketException>()
                .RetryAsync(onRetry: OnRetry);

            httpResponseMessagePolicy = Policy
    .Handle<HttpRequestException>()
    .OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
    .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        public RetryHandler(AsyncRetryPolicy policy)
        {
            InnerHandler = new HttpClientHandler();
            this.policy = policy;
        }

        public RetryHandler(AsyncRetryPolicy<HttpResponseMessage> policy)
        {
            InnerHandler = new HttpClientHandler();
            this.httpResponseMessagePolicy = policy;
        }

        //public RetryHandler(AsyncRetryPolicy<DummyHttpResponseMessage> policy)
        //{
        //    InnerHandler = new HttpClientHandler();
        //    this.dummyHttpResponseMessagePolicy = policy;
        //}
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
        {
            if(httpResponseMessagePolicy != null)
            {
                return await httpResponseMessagePolicy.ExecuteAsync(
                async () =>
                {
                    return await base.SendAsync(request, cancellationToken);
                });
            }
            //if (dummyHttpResponseMessagePolicy != null)
            //{
            //    return await dummyHttpResponseMessagePolicy.ExecuteAsync(
            //    async () =>
            //    {
            //        return await base.SendAsync(request, cancellationToken);
            //    });
            //}
            else
            {
                return await policy.ExecuteAsync(
                async () =>
                {
                    return await base.SendAsync(request, cancellationToken);
                });
            }
        }

        private void OnRetry(Exception ex, int retryCount)
        {
            Console.WriteLine("Retrying timed out request");
            Console.WriteLine(ex.Message);
        }
    }

    public class DummyHttpResponseMessage : HttpResponseMessage
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}