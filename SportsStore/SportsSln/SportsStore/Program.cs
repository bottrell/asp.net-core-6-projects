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

//Creates a service where each HTTP request gets its own repository object
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

builder.Services.AddRazorPages();

//Sets up the in-memory data store
builder.Services.AddDistributedMemoryCache();

//Registers the services used to access session data
builder.Services.AddSession();

//The AddScoped method specifies that the same object should be used to satisfy related requests for Cart instances
//by default this means that any Cart required by the components handling the same HTTP request will receive the same object
//recieves the collection of services that have been registered and passes the collection to the GetCart method of the SessionCart class
builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));

//Specfiies the same object should always be used
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();

//Allows the session system to automatically associate requests with sessions when they arrive from the client
app.UseSession();

//overriding ASP.NET routing to change the URL scheme of the application
//Routing scheme: 
    // "/"                Lists the first page of products from all categories
    // "/Page2"           Lists the specified page showing items from all categories
    // "/Soccer"          Shows the first page of items from a specific category (in this case, the Soccer category)
    // "/Soccer/Page2"    Shows the specified page of items from the specified category
app.MapControllerRoute("catpage", "{category}/Page{productPage:int}", new { Controller = "Home", action = "Index"});
app.MapControllerRoute("page", "Page{productPage:int}", new { Controller = "Home", action = "Index", productPage = 1});
app.MapControllerRoute("category", "{category}", new { Controller = "Home", action = "Index", productPage = 1});
app.MapControllerRoute("pagination", "Products/Page{productPage}", new { Controller = "Home", action = "Index", productPage = 1});

//This line tells ASP.NET  Core how to match URLs to controller classes
app.MapDefaultControllerRoute();

app.MapRazorPages();

//Remember that EnsurePopulated accepts an IApplicationBuilder object as a parameter
SeedData.EnsurePopulated(app);
app.Run();

//Note To self, if you need to reset the database, then run the following command in the SportsStore folder
//dotnet ef database drop --force --context StoreDbContext