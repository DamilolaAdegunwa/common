using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetryApp.Services
{
    public class LoggingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Log details of the request
            Console.WriteLine($"{request.Method} {request.RequestUri}");

            if (request.Content != null)
            {
                Console.WriteLine(await request.Content.ReadAsStringAsync());
            }

            // Call the base SendAsync method to send the request to the server
            var response = await base.SendAsync(request, cancellationToken);

            // Log details of the response
            Console.WriteLine($"Status: {(int)response.StatusCode} {response.ReasonPhrase}");

            if (response.Content != null)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

            return response;
        }
    }

}
