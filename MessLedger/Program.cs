using log4net.Config;
using log4net;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ML.Service;
using ML.Repository;
using ML.Repository.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("cs"))
);


builder.Services.AddServiceLayer(); // for dependency injection
builder.Services.AddRepositoryLayer(); // for dependency injection


var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());  // for logger
XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));   // for logger

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
