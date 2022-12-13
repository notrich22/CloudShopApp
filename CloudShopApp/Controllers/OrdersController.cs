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
        public async Task RemoveOrder(HttpContext context) 
        {
            IdInfo id = await context.Request.ReadFromJsonAsync<IdInfo>();
            await logicService.RemoveOrder(id.id);
        }
        public async Task UpdateOrder(HttpContext context)
        {
            UpdateOrderInfo orderinfo = await context.Request.ReadFromJsonAsync<UpdateOrderInfo>();
            Order order = new Order();
            order.ClientId = orderinfo.ClientId;
            order.Description = orderinfo.Description;
            await context.Response.WriteAsJsonAsync(await logicService.UpdateOrder(orderinfo.id, order));
        }
    }
}
