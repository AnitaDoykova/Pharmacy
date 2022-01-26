using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Models.DTO;


namespace Pharmacy.BL.Interfaces
{
    public interface IClientService
    {
        Client Create(Client client);

        Client Update(Client client);

        Client Delete(int id);

        Client GetById(int id);

        IEnumerable<Client> GetAll();
    }
}
