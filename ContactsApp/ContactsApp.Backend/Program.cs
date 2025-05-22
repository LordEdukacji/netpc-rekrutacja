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
            policy.WithOrigins(builder.Configuration["FrondendAppUrl"])
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        });
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi :)
builder.Services.AddOpenApi();

// for contacts
builder.Services.AddDbContext<ContactContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ContactDbConnection")));

// for Identity API
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbConnection")));

// authorization
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// to make calls from another domain
app.UseCors(CorsPolicy);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// for Identity API
app.MapIdentityApi<IdentityUser>();

app.Run();
