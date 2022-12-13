using CloudShopApp.Model.Entity;

namespace CloudShopApp.Services
{
    public interface IOrderService
    {
        Task<Order> AddOrder(Order order);
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrder(int id);
        Task DeleteOrder(int id);
        Task<Order> UpdateOrder(int id, Order order);

    }
}
