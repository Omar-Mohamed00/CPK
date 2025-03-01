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
//builder.Services.AddSingleton<LineRepositorie>();

builder.Services.AddSingleton<SubscribeLine1003TableDependency>();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseSqlTableDependency<SubscribeLine1003TableDependency>(ConnectionString);
app.Run();
