using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Realtrend.Interfaces;
using Realtrend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient<IAddress, AddressService>(client =>
{
    client.BaseAddress = new Uri("https://api.dataforsyningen.dk/");
});

builder.Services.AddScoped<AddressStateService>();

var app = builder.Build();

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
