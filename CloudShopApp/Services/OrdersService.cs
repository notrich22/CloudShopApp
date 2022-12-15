using CloudShopApp.Model;
using CloudShopApp.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace CloudShopApp.Services
{
    public class OrdersService : IOrderService
    {
        public async Task<Order> AddOrder(Order order)
        {
            try
            {
                using (var db = new CloudDBContext())
                {
                    order.Client =await db.Clients.FirstOrDefaultAsync(n=> n.id == order.ClientId);
                    await db.Orders.AddAsync(order);
                    await db.SaveChangesAsync();
                    return order;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
        }
        public async Task<List<Order>> GetAllOrders()
        {
            try
            {
                using(var db = new CloudDBContext())
                {
                    return await db.Orders.ToListAsync();
                }
            }catch(Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
        }
        public async Task<Order> GetOrder(int id)
        {
            try
            {
                using (var db = new CloudDBContext())
                {
                    return await db.Orders.FirstOrDefaultAsync(n=>n.id==id);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
        }
        public async Task<bool> DeleteOrder(int id)
        {
            try
            {
                using (var db = new CloudDBContext())
                {
                    db.Remove(await db.Orders.FirstOrDefaultAsync(n => n.id == id));
                    db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
        }
        public async Task<Order> UpdateOrder(int id, Order order)
        {
            try
            {
                using (var db = new CloudDBContext())
                {
                    Order oldOrder = await db.Orders.FirstOrDefaultAsync(n => n.id == id);
                    oldOrder.Description = order.Description;
                    oldOrder.ClientId= order.ClientId;
                    oldOrder.Client = await db.Clients.FirstOrDefaultAsync(n=> n.id == order.ClientId);
                    await db.SaveChangesAsync();
                    return oldOrder;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
        }

        public async Task<OrderComponent> AddOrderComponent(OrderComponent orderComponent)
        {
            try
            {
                using (var db = new CloudDBContext())
                {
                    orderComponent.Product = await db.Products.FirstOrDefaultAsync(n => n.id == orderComponent.ProductId);
                    orderComponent.Order = await db.Orders.FirstOrDefaultAsync(n => n.id == orderComponent.OrderId);
                    await db.OrderComponents.AddAsync(orderComponent);
                    await db.SaveChangesAsync();
                    return orderComponent;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
        }

        public async Task<List<OrderComponent>> GetOrderComponents()
        {
            try
            {
                using (var db = new CloudDBContext())
                {
                    return await db.OrderComponents.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
        }

        public async Task<OrderComponent> GetOrderComponent(int id)
        {
            try
            {
                using (var db = new CloudDBContext())
                {
                    return await db.OrderComponents.FirstOrDefaultAsync(n => n.id == id);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
        }

        public async Task<OrderComponent> UpdateOrderComponent(int id, OrderComponent orderComponent)
        {
            try
            {
                using (var db = new CloudDBContext())
                {
                    OrderComponent oldOrderComponent = await db.OrderComponents.FirstOrDefaultAsync(n => n.id == id);
                    oldOrderComponent.OrderId = orderComponent.OrderId;
                    oldOrderComponent.ProductId = orderComponent.ProductId;
                    oldOrderComponent.Amount = orderComponent.Amount;
                    oldOrderComponent.Product = await db.Products.FirstOrDefaultAsync(n => n.id == oldOrderComponent.ProductId);
                    oldOrderComponent.Order = await db.Orders.FirstOrDefaultAsync(n => n.id == oldOrderComponent.OrderId);
                    await db.SaveChangesAsync();
                    return oldOrderComponent;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
        }

        public async Task<bool> DeleteOrderComponent(int id)
        {
            try
            {
                using (var db = new CloudDBContext())
                {
                    db.Remove(await db.OrderComponents.FirstOrDefaultAsync(n => n.id == id));
                    db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
        }
    }
}
