
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using WebStore.DAL.Context;
using WebStore.Data;
using WebStore.Domain.Entites.Identity;
using WebStore.Imfrastructure.Conventions;
using WebStore.Imfrastructure.Middleware;
using WebStore.Sevices.InMemory;
using WebStore.Sevices.InSQL;
using WebStore.Sevices.Interfaces;

var builder = WebApplication.CreateBuilder(args);
//конфигурирование состаных частей приложения

var services = builder.Services;

services.AddIdentity<User, Role>()
   .AddEntityFrameworkStores<WebStoreDB>()
   .AddDefaultTokenProviders();


    services.Configure<IdentityOptions>(opt =>
    {
    #if DEBUG
        opt.Password.RequireDigit = false; //требование необходимости цифр в пароле
        opt.Password.RequireLowercase = false;//требование буквы в нижнем регистре
        opt.Password.RequireUppercase = false;//буквы в верхнем регистре
        opt.Password.RequireNonAlphanumeric = false;//требование неалфавитных симводов
        opt.Password.RequiredLength = 3;//мин длина пароля
        opt.Password.RequiredUniqueChars = 3;//уникальные символы
    #endif

        opt.User.RequireUniqueEmail = false;////требование разных емейлов
        opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIGKLMNOPQRSTUVWXYZ1234567890";//набор букв из которых состоит имя пользователя

        opt.Lockout.AllowedForNewUsers = false;//для новых пользователей учетная запись не заблокирована
        opt.Lockout.MaxFailedAccessAttempts = 10;//макс количество непраильных попыток ввода пароля
        opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);//время блокировки пользователя
    });

   


    services.ConfigureApplicationCookie(opt =>
    {
        opt.Cookie.Name = "WebStore";//название
        opt.Cookie.HttpOnly = true;// передается только по HTTP каналу

        opt.ExpireTimeSpan = TimeSpan.FromDays(10);//через 10 дней пользователь должен перелогиниться

        opt.LoginPath = "/Account/Login";
        opt.LogoutPath = "/Account/Logout";
        opt.AccessDeniedPath = "/Account/AccessDenied";

        opt.SlidingExpiration = true;
    });


services.AddScoped<IEmployeesData, InMemoryEmployeesData>();//контейнер сервисов(самый универсальный)
services.AddScoped<IProductData, SqlProductData>();

services.AddDbContext<WebStoreDB>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
services.AddScoped<DbInitializer>();

builder.Services.AddControllersWithViews(opt => 
{
    opt.Conventions.Add(new TestCoventions()); //использование соглашений
});

services.AddAutoMapper(typeof(Program));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db_initializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();
    await db_initializer.InitializeAsync(
        RemoveBefore: app.Configuration.GetValue("DbRecreate", false),
        AddTestData: app.Configuration.GetValue("DbAddTestData", false));
}

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
