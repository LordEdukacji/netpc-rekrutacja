using Microsoft.AspNetCore.Components.Authorization;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace ContactsApp.Frontend.Providers
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient httpClient;

        public CustomAuthenticationStateProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

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

        public void RefreshAuthenticationState()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
