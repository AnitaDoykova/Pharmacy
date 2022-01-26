using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Models.DTO;
using Pharmacy.DL.InMemoryDb;
using Pharmacy.DL.Interfaces;

namespace Pharmacy.DL.Repositories
{
    public class ClientInMemoryRepository : IClientRepository
    {
        public ClientInMemoryRepository()
        { }

        public Client Create(Client client)
        {
            ClientInMemoryCollection.ClientDb.Add(client);

            return client;
        }

        public Client Delete(int id)
        {
            var client = ClientInMemoryCollection.ClientDb.FirstOrDefault(client => client.Id == id);

            ClientInMemoryCollection.ClientDb.Remove(client);

            return client;
        }

        public IEnumerable<Client> GetAll()
        {
            return ClientInMemoryCollection.ClientDb;
        }

        public Client GetById(int id)
        {
            return ClientInMemoryCollection.ClientDb.FirstOrDefault(x => x.Id == id);
        }

        public Client Update(Client client)
        {
            var result = ClientInMemoryCollection.ClientDb.FirstOrDefault(x => x.Id == client.Id);

            result.Name = client.Name;

            return result;
        }
    }
}
