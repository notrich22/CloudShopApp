using CloudShopApp.Model.Entity;
using CloudShopApp.Services;
using static CloudShopApp.Records;

namespace CloudShopApp.Controllers
{
    public class ClientsController
    {
        ClientsService logicService;
        public ClientsController(ClientsService logicService)
        {
            this.logicService = logicService;
        }
        public async Task AddClient(HttpContext context)
        {
            ClientInfo clientInfo = await context.Request.ReadFromJsonAsync<ClientInfo>();
            Client client = new Client();
            client.Name = clientInfo.Name;
            client.Contacts = clientInfo.Contacts;
            await context.Response.WriteAsJsonAsync(await logicService.AddClient(client));
        }
        public async Task GetClient(HttpContext context)
        {
            IdInfo id = await context.Request.ReadFromJsonAsync<IdInfo>();
            Client client = await logicService.GetClient(id.id);
            await context.Response.WriteAsJsonAsync(client);
        }
        public async Task GetClients(HttpContext context)
        {
            await context.Response.WriteAsJsonAsync(await logicService.GetClients());
        }
        public async Task UpdateClient(HttpContext context)
        {
            ClientUpdateInfo updateClient = await context.Request.ReadFromJsonAsync<ClientUpdateInfo>();
            Client client = new Client();
            client.Name = updateClient.Name;
            client.Contacts = updateClient.Contacts;
            await context.Response.WriteAsJsonAsync(await logicService.UpdateClient(updateClient.id, client));

        }
        public async Task DeleteClient(HttpContext context)
        {
            IdInfo id = await context.Request.ReadFromJsonAsync<IdInfo>();
            await logicService.DeleteClient(id.id);
        }
    }
}
