var builder = WebApplication.CreateBuilder(args);
//���������������� �������� ������ ����������
var app = builder.Build();

var greeting = app.Configuration["ServerGreeting"];
app.MapGet("/", () => greeting);

app.Run();
