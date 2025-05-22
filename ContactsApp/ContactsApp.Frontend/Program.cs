using ContactsApp.Frontend;
using ContactsApp.Frontend.Handlers;
using ContactsApp.Frontend.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// for api calls
builder.Services.AddScoped(sp => new HttpClient (new AccountCookieHandler()) { BaseAddress = new Uri(builder.Configuration["ApiSettings:ApiUrl"]) });

// authentication and authorization
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

// to be able to inject this into components
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
    provider.GetRequiredService<CustomAuthenticationStateProvider>());  

await builder.Build().RunAsync();
