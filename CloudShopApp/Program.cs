using CloudShopApp.Controllers;
using CloudShopApp.Services;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<OrdersController>();
builder.Services.AddSingleton<OrdersService>();
builder.Services.AddSingleton<ClientsController>();
builder.Services.AddSingleton<ClientsService>();
var app = builder.Build();

app.MapPost("/add-order", app.Services.GetRequiredService<OrdersController>().AddOrder);
app.MapGet("/get-orders", app.Services.GetRequiredService<OrdersController>().GetAllOrders);
app.MapPost("/get-order", app.Services.GetRequiredService<OrdersController>().GetOrder);
app.MapPost("/remove-order", app.Services.GetRequiredService<OrdersController>().DeleteOrder);
app.MapPost("/update-order", app.Services.GetRequiredService<OrdersController>().UpdateOrder);

app.MapPost("/add-client", app.Services.GetRequiredService<ClientsController>().AddClient);
app.MapGet("/get-clients", app.Services.GetRequiredService<ClientsController>().GetClients);
app.MapPost("/get-client", app.Services.GetRequiredService<ClientsController>().GetClient);
app.MapPost("/remove-client", app.Services.GetRequiredService<ClientsController>().DeleteClient);
app.MapPost("/update-client", app.Services.GetRequiredService<ClientsController>().UpdateClient);

app.Run();
