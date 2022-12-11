using CloudShopApp.Controllers;
using CloudShopApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<OrdersController>();
builder.Services.AddSingleton<OrdersService>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
