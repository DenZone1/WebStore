var builder = WebApplication.CreateBuilder(args);
//конфигурирование состаных частей приложения
var app = builder.Build();

var greeting = app.Configuration["ServerGreeting"];
app.MapGet("/", () => greeting);

app.Run();
