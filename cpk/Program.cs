using cpk.Controllers;
using cpk.MiddlewareExtensions;
using cpk.Repositories;
using cpk.SubscribeTableDependencies;
using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("No Connection String Was Found");

builder.Services.AddDbContext<Cpk25Context>(options =>
    options.UseSqlServer(ConnectionString));
builder.Services.AddSignalR();

// DI
builder.Services.AddSingleton<DataHub>();
builder.Services.AddSignalR();

builder.Services.AddSingleton<SubscribeLine1003TableDependency>();
builder.Services.AddSingleton<SubscribeLine1010TableDependency>();
builder.Services.AddSingleton<SubscribeLine10113TableDependency>();
builder.Services.AddSingleton<SubscribeLine1011TableDependency>();
builder.Services.AddSingleton<SubscribeLine1013TableDependency>();
builder.Services.AddSingleton<SubscribeLine1014TableDependency>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapHub<DataHub>("/dataHub");
// Log that Table Dependency services are being started
Console.WriteLine(" Starting Table Dependency Subscriptions...");

var tableDependencyServices = app.Services.GetRequiredService<IEnumerable<ISubscribeTableDependencies>>();
foreach (var service in tableDependencyServices)
{
    Console.WriteLine($"Subscribing to table dependency: {service.GetType().Name}");
    service.SubscribeTableDependency(ConnectionString);
}

Console.WriteLine(" All Table Dependency Subscriptions Started Successfully!");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseSqlTableDependency<SubscribeLine1003TableDependency>(ConnectionString);
app.UseSqlTableDependency<SubscribeLine1010TableDependency>(ConnectionString);
app.UseSqlTableDependency<SubscribeLine10113TableDependency>(ConnectionString);
app.UseSqlTableDependency<SubscribeLine1011TableDependency>(ConnectionString);
app.UseSqlTableDependency<SubscribeLine1013TableDependency>(ConnectionString);
app.UseSqlTableDependency<SubscribeLine1014TableDependency>(ConnectionString);
app.Run();
