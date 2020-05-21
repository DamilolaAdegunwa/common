using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Web.Http.Filters;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
namespace Auth.API.Filters
{
    public class AddChallengeOnUnauthorizedResult : IHttpActionResult
    {
        public AddChallengeOnUnauthorizedResult(AuthenticationHeaderValue challengeAuthenticationHeaderValue, IHttpActionResult iHttpActionResult)
        {
            ChallengeAuthenticationHeaderValue = challengeAuthenticationHeaderValue;
            IHttpActionResult = iHttpActionResult;
        }
        public AuthenticationHeaderValue ChallengeAuthenticationHeaderValue { get; private set; }
        public IHttpActionResult IHttpActionResult { get; set; }
        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await IHttpActionResult.ExecuteAsync(cancellationToken);
            if(response.StatusCode == HttpStatusCode.Unauthorized)
            {
                if(response.Headers.WwwAuthenticate.All(h => h.Scheme == ChallengeAuthenticationHeaderValue.Scheme))
                {
                    response.Headers.WwwAuthenticate.Add(ChallengeAuthenticationHeaderValue);
                }
            }
            return response;
            //throw new NotImplementedException();
        }
    }
}
