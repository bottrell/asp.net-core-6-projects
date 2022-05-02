using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Service property is used to set up objects, known as services
//that can be used throughout the application and that are accessed through a features
//called dependency injection!
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(opts => {
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:SportsStoreConnection"]);
});

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();

//This line tells ASP.NET  Core how to match URLs to controller classes
app.MapDefaultControllerRoute();

app.Run();
