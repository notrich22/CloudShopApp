using CloudShopApp.Model.Entity;
using CloudShopApp.Services;
using static CloudShopApp.Records;

namespace CloudShopApp.Controllers
{
    public class OrdersController
    {
        OrdersService logicService;
        public OrdersController(OrdersService ordersService) {
            this.logicService = ordersService;
        }
        public async Task GetAllOrders(HttpContext context)
        {
            await context.Response.WriteAsJsonAsync(await logicService.GetAllOrders());
        }
        public async Task GetOrder(HttpContext context)
        {
            IdInfo id = await context.Request.ReadFromJsonAsync<IdInfo>();
            Order order = await logicService.GetOrder(id.id);
            await context.Response.WriteAsJsonAsync(order);
        }
        public async Task AddOrder(HttpContext context)
        {
            OrderInfo orderinfo = await context.Request.ReadFromJsonAsync<OrderInfo>();
            Order order = new Order();
            order.ClientId = orderinfo.ClientId;
            order.Description = orderinfo.Description;
            await context.Response.WriteAsJsonAsync(await logicService.AddOrder(order));
        }
        public async Task DeleteOrder(HttpContext context) 
        {
            IdInfo id = await context.Request.ReadFromJsonAsync<IdInfo>();
            await logicService.DeleteOrder(id.id);
        }
        public async Task UpdateOrder(HttpContext context)
        {
            UpdateOrderInfo orderinfo = await context.Request.ReadFromJsonAsync<UpdateOrderInfo>();
            Order order = new Order();
            order.ClientId = orderinfo.ClientId;
            order.Description = orderinfo.Description;
            await context.Response.WriteAsJsonAsync(await logicService.UpdateOrder(orderinfo.id, order));
        }
        public async Task AddOrderComponent(HttpContext context)
        {
            OrderComponentInfo orderinfo = await context.Request.ReadFromJsonAsync<OrderComponentInfo>();
            OrderComponent orderComponent = new OrderComponent();
            orderComponent.OrderId = orderinfo.OrderId;
            orderComponent.ProductId = orderinfo.ProductId;
            orderComponent.Amount = orderinfo.Amount;
            await context.Response.WriteAsJsonAsync(await logicService.AddOrderComponent(orderComponent));
        }
        public async Task GetOrderComponent(HttpContext context)
        {
            IdInfo id = await context.Request.ReadFromJsonAsync<IdInfo>();
            OrderComponent orderComponent = await logicService.GetOrderComponent(id.id);
            await context.Response.WriteAsJsonAsync(orderComponent);
        }
        public async Task GetOrderComponents(HttpContext context)
        {
            await context.Response.WriteAsJsonAsync(await logicService.GetOrderComponents());
        }
        public async Task UpdateOrderComponent(HttpContext context)
        {
            OrderComponentUpdateInfo orderComponentInfo = await context.Request.ReadFromJsonAsync<OrderComponentUpdateInfo>();
            OrderComponent orderComponent = new OrderComponent();
            orderComponent.OrderId = orderComponentInfo.OrderId;
            orderComponent.ProductId = orderComponentInfo.ProductId;
            orderComponent.Amount = orderComponentInfo.Amount;
            await context.Response.WriteAsJsonAsync(await logicService.UpdateOrderComponent(orderComponentInfo.id, orderComponent));
        }
        public async Task DeleteOrderComponent(HttpContext context)
        {

        }
    }
}
