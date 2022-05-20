var builder = WebApplication.CreateBuilder(args);
//���������������� �������� ������ ����������

builder.Services.AddControllersWithViews();


var app = builder.Build();

//var greeting = app.Configuration["ServerGreeting"];
//app.MapGet("/", () => greeting);

app.MapGet("/greetings", () => app.Configuration["ServerGreeting"]);

app.MapDefaultControllerRoute();   


app.Run();
