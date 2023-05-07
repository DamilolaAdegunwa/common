using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetryApp.Services
{
    public class TimeoutHandler : DelegatingHandler
    {
        private static TimeSpan Timeout = TimeSpan.FromMilliseconds(60000);

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(Timeout);
            var timeoutToken = cts.Token;

            var linkedToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutToken);

            try
            {
                return await base.SendAsync(request, linkedToken.Token);
            }
            catch (OperationCanceledException ex) when (timeoutToken.IsCancellationRequested)
            {
                throw new TimeoutException();
            }
        }
    }
}
