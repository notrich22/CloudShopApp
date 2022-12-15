﻿using CloudShopApp.Model;
using CloudShopApp.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace CloudShopApp.Services
{
    public class ClientsService : IClientService
    {
        async public Task<Client> AddClient(Client client)
        {
            try
            {
                using(var db = new CloudDBContext())
                {
                    await db.Clients.AddAsync(client);
                    await db.SaveChangesAsync();
                    return client;
                }
            }catch(Exception ex) 
            {
                Console.WriteLine(ex);
                return null; 
            }
        }

        async public Task<bool> DeleteClient(int id)
        {
            try
            {
                using (var db = new CloudDBContext())
                {
                    db.Remove(await db.Clients.FirstOrDefaultAsync(x => x.id == id));
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        async public Task<Client> GetClient(int id)
        {
            try
            {
                using (var db = new CloudDBContext())
                {
                    return await db.Clients.FirstOrDefaultAsync(x => x.id == id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<List<Client>> GetClients()
        {
            try
            {
                using (var db = new CloudDBContext())
                {
                    return await db.Clients.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        async public Task<Client> UpdateClient(int id, Client client)
        {
            try
            {
                using (var db = new CloudDBContext())
                {
                    var oldClient = await db.Clients.FirstOrDefaultAsync(x => x.id == id);
                    oldClient.Name = client.Name;
                    oldClient.Contacts = client.Contacts;
                    await db.SaveChangesAsync();
                    return oldClient;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
