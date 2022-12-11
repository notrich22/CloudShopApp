using CloudShopApp.Model;
using CloudShopApp.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace CloudShopApp.Services
{
    public class OrdersService
    {
        public async Task<Order> AddOrder(Order order)
        {
            try
            {
                using (var db = new CloudDBContext())
                {
                    
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
        public async Task RemoveOrder(int id)
        {
            try
            {
                using (var db = new CloudDBContext())
                {
                    db.Remove(await db.Orders.FirstOrDefaultAsync(n => n.id == id));
                    db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
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
                    oldOrder.FeedbackContacts = order.FeedbackContacts;
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
    }
}
