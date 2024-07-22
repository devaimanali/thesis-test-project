using Microsoft.EntityFrameworkCore;
using thesis_exercise.Repositories;
using thesis_exercise.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("db");
// Use connectionString variable inside the AddDbContextPool that provided by EntityFrameworkCore
builder.Services.AddDbContextPool<AppDbContext>(option =>
    option.UseSqlServer(connectionString)
);
builder.Services.AddScoped<IComputerService, ComputerService>();
var app = builder.Build();
// Retrieve ConnectionString from appsettings.json 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
