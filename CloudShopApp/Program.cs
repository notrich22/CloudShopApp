using CloudShopApp.Controllers;
using CloudShopApp.Services;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<OrdersController>();
builder.Services.AddSingleton<OrdersService>();
var app = builder.Build();

app.MapPost("/add-order", app.Services.GetRequiredService<OrdersController>().AddOrder);
app.MapGet("/get-orders", app.Services.GetRequiredService<OrdersController>().GetAllOrders);
app.MapPost("/get-order", app.Services.GetRequiredService<OrdersController>().GetOrder);
app.MapPost("/remove-order", app.Services.GetRequiredService<OrdersController>().RemoveOrder);
app.MapPost("/update-order", app.Services.GetRequiredService<OrdersController>().UpdateOrder);

app.Run();
