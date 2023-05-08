using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RetryApp.Services
{
    public class AuthenticationHandler : DelegatingHandler
    {
        private readonly string _apiKey;

        public AuthenticationHandler(string apiKey)
        {
            _apiKey = apiKey;
        }

        public AuthenticationHandler()
        {
            _apiKey = "guest-apikey";
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Add an Authorization header to the request using the API key
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            // Call the base SendAsync method to send the request to the server
            var response = await base.SendAsync(request, cancellationToken);

            return response;
        }
    }

}
