using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;

namespace ContactsApp.Frontend.Handlers
{
    // for attaching cookies to requests for authorization
    public class AccountCookieHandler : DelegatingHandler
    {
        public AccountCookieHandler()
        {
            InnerHandler = new HttpClientHandler();
        }

        // attaches the cookie
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellation)
        {
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            return base.SendAsync(request, cancellation);
        }
    }
}
