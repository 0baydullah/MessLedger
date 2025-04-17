using log4net.Config;
using log4net;
using System.Reflection;
using ML.Service;
using ML.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Register Dependency injection of iservice and irepository layer
builder.Services.AddServiceLayer();
builder.Services.AddRepositoryLayer();


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
