using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ContactsApp.Frontend.Providers
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var claims = new ClaimsIdentity();
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(claims)));
        }
    }
}
