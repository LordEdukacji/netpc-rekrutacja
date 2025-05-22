using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;

namespace ContactsApp.Frontend.Handlers
{
    public class AccountCookieHandler : DelegatingHandler
    {
        public AccountCookieHandler()
        {
            InnerHandler = new HttpClientHandler();
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellation)
        {
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            return base.SendAsync(request, cancellation);
        }
    }
}
