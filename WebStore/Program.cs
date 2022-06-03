using WebStore.Imfrastructure.Middleware;
using WebStore.Imfrastructure.Conventions;
using WebStore.Sevices;
using WebStore.Sevices.Interfaces;
using WebStore.DAL.Context;
using Microsoft.EntityFrameworkCore;
using WebStore.Data;

var builder = WebApplication.CreateBuilder(args);
//конфигурирование состаных частей приложения

var services = builder.Services;
services.AddScoped<IEmployeesData, InMemoryEmployeesData>();//контейнер сервисов(самый универсальный)
services.AddScoped<IProductData, InMemoryProductData>();
services.AddDbContext<WebStoreDB>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
services.AddScoped<DbInitializer>();

builder.Services.AddControllersWithViews(opt => 
{
    opt.Conventions.Add(new TestCoventions()); //использование соглашений
});

services.AddAutoMapper(typeof(Program));


var app = builder.Build();


if (app.Environment.IsDevelopment())
    { 
        app.UseDeveloperExceptionPage();
    }

app.UseStaticFiles();//использование статических файлов

app.UseRouting();//маршрутизация

app.UseMiddleware<TestMiddleWare>();//промежуточное ПО

app.MapGet("/greetings", () => app.Configuration["ServerGreeting"]);

app.UseWelcomePage("/welcome");

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
