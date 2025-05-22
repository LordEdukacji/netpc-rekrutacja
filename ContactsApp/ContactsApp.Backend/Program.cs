using ContactsApp.Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var CorsPolicy = builder.Configuration["CorsPolicyName"];

// Add services to the container.

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(CorsPolicy,
        policy =>
        {
            policy.WithOrigins(builder.Configuration["FrondendAppUrl"]);
        });
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ContactContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ContactDbConnection")));

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbConnection")));

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors(CorsPolicy);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapIdentityApi<IdentityUser>();

app.Run();
