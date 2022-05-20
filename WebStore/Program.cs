var builder = WebApplication.CreateBuilder(args);
//конфигурирование состаных частей приложения

builder.Services.AddControllersWithViews();


var app = builder.Build();

//var greeting = app.Configuration["ServerGreeting"];
//app.MapGet("/", () => greeting);

app.MapGet("/greetings", () => app.Configuration["ServerGreeting"]);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
