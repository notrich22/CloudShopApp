using CloudShopApp.Model.Entity;

namespace CloudShopApp.Services
{
    public interface IClientService
    {
        Task<Client> AddClient(Client client);
        Task<Client> GetClient(int id);
        Task<List<Client>> GetClients();
        Task<Client> UpdateClient(int id, Client client);
        Task DeleteClient(int id);
    }
}
