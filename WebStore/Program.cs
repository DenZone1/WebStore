using WebStore.Imfrastructure.Middleware;

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

app.UseMiddleware<TestMiddleWare>();//промежуточное ПО

app.MapGet("/greetings", () => app.Configuration["ServerGreeting"]);

app.UseWelcomePage("/welcome");

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
