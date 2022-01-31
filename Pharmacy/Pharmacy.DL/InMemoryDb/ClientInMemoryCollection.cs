using System.Collections.Generic;
using Pharmacy.Models.DTO;

namespace Pharmacy.DL.InMemoryDb
{
    public static class ClientInMemoryCollection
    {
        public static List<Client> ClientDb = new List<Client>()
        {
            new Client()
            {
                Id = 1,
                Name = "Ivan",
                MoneySpend = 2.15
            },
            new Client()
            {
                Id = 2,
                Name = "Petko",
                MoneySpend = 10.80
            },
            new Client()
            {
                Id = 3,
                Name = "Daniela",
                MoneySpend = 3.10
            },
            new Client()
            {
                Id = 4,
                Name = "Neli",
                MoneySpend = 5.90
            },
            new Client()
            {
                Id = 5,
                Name = "Vladimir",
                MoneySpend = 8.60
            }
        };
    }
}
