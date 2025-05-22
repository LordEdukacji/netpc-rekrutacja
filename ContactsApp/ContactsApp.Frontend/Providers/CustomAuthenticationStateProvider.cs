using Microsoft.AspNetCore.Components.Authorization;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace ContactsApp.Frontend.Providers
{
    // handles authorization
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient httpClient;

        // to make requests to cookie endpoint
        public CustomAuthenticationStateProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        // checks if authorized by calling cookie endpoint
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var response = await httpClient.GetAsync("/api/contact/cookie");

            if (response.IsSuccessStatusCode)
            {
                var claims = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "Authenticated") }, "Authenticated");
                return new AuthenticationState(new ClaimsPrincipal(claims));
            }

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        // for forcing checking authorization state
        // used for refreshing sidebar buttons
        public void RefreshAuthenticationState()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
