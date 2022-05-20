var builder = WebApplication.CreateBuilder(args);
//конфигурирование состаных частей приложения
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
