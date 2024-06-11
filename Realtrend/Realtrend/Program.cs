using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Realtrend.Library.Interfaces;
using Realtrend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazorBootstrap();

// Register HTTP clients for services
builder.Services.AddHttpClient<IDataForsyningService, DataForsyningService>(client =>
{
    client.BaseAddress = new Uri("https://api.dataforsyningen.dk/");
});

builder.Services.AddHttpClient<IDataFordelerService, DataFordelerService>(client =>
{
    client.BaseAddress = new Uri("https://services.datafordeler.dk/");
});

// Register other services
builder.Services.AddScoped<IAddressValidator, AddressValidator>();
builder.Services.AddScoped<IAddressService, AddressService>(); // Register IAddressService
builder.Services.AddScoped<AddressStateService>();
builder.Services.AddScoped<PropertyDataService>();

var app = builder.Build();

// Seed mock data (ensure this is only done in development)
if (app.Environment.IsDevelopment())
{
    SeedDataToFile.CreateAndSaveMockData();
}

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
