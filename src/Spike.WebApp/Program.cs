using Microsoft.AspNetCore.Authentication.Negotiate;
using Spike.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

// base services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// my services
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblyContaining<SimulatorId>();
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();

// This is the only place "_Host" is referenced
app.MapFallbackToPage("/_Host");

app.Run();
