var builder = WebApplication.CreateBuilder(args);
//конфигурирование состаных частей приложения

builder.Services.AddControllersWithViews();


var app = builder.Build();


if (app.Environment.IsDevelopment())
    { 
        app.UseDeveloperExceptionPage();
    }

app.UseStaticFiles();//использование статическиз файлов

app.UseRouting();//маршрутизация


app.MapGet("/greetings", () => app.Configuration["ServerGreeting"]);


    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
