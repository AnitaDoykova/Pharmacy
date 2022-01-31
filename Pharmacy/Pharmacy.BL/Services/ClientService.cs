using System.Collections.Generic;
using System.Linq;
using Pharmacy.DL.Interfaces;
using Pharmacy.BL.Interfaces;
using Pharmacy.Models.DTO;
using Serilog;

namespace Pharmacy.BL.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientrepository;
        private readonly ILogger _logger;

        public ClientService(IClientRepository clientrepository, ILogger logger)
        {
            _clientrepository = clientrepository;
            _logger = logger;
        }
        public Client Create(Client client)
        {
            var index = _clientrepository.GetAll().OrderByDescending(X => X.Id).FirstOrDefault()?.Id;

            client.Id = (int)(index != null ? index + 1 : 1);

            return _clientrepository.Create(client);
        }

        public Client Delete(int id)
        {
            return _clientrepository.Delete(id);
        }

        public IEnumerable<Client> GetAll()
        {
            return _clientrepository.GetAll();
        }

        public Client GetById(int id)
        {
            return _clientrepository.GetById(id);
        }

        public Client Update(Client client)
        {
            return _clientrepository.Update(client);
        }
    }
}