using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Realtrend.Library.Interfaces;
using Realtrend.Library.Services;
using Realtrend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazorBootstrap();

// Register HttpClient for AddressService
builder.Services.AddHttpClient<IAddress, AddressService>(client =>
{
    client.BaseAddress = new Uri("https://api.dataforsyningen.dk/");
});

builder.Services.AddScoped<AddressStateService>();
builder.Services.AddScoped<PropertyDataService>();

builder.Services.AddHttpClient();
builder.Services.AddTransient<IHttpService, HttpService>();
builder.Services.AddScoped<IBasicValueSpecification, BasicValueSpecificationService>();

var app = builder.Build();

// Seed mock data
SeedDataToFile.CreateAndSaveMockData();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
