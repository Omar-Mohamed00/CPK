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
// DI
builder.Services.AddSingleton<DataHub>();
builder.Services.AddSignalR();

// Register all table dependencies
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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider.GetRequiredService<IEnumerable<ISubscribeTableDependencies>>();

    foreach (var service in services)
    {
        try
        {
            Console.WriteLine($"Subscribing to table dependency: {service.GetType().Name}");
            service.SubscribeTableDependency(ConnectionString);
            Console.WriteLine($"Successfully subscribed: {service.GetType().Name}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error subscribing to {service.GetType().Name}: {ex.Message}");
        }
    }
}


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Register table dependencies with middleware
app.UseSqlTableDependency<SubscribeLine1003TableDependency>(ConnectionString);
app.UseSqlTableDependency<SubscribeLine1010TableDependency>(ConnectionString);
app.UseSqlTableDependency<SubscribeLine10113TableDependency>(ConnectionString);
app.UseSqlTableDependency<SubscribeLine1011TableDependency>(ConnectionString);
app.UseSqlTableDependency<SubscribeLine1013TableDependency>(ConnectionString);
app.UseSqlTableDependency<SubscribeLine1014TableDependency>(ConnectionString);
app.Run();
