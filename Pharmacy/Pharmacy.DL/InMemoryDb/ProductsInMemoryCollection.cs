using System.Collections.Generic;
using Pharmacy.Models.DTO;

namespace Pharmacy.DL.InMemoryDb
{
    public static class ProductsInMemoryCollection
    {
        public static List<Products> ProductsDb = new List<Products>()
        {
            new Products()
            {
                Id = 1,
                Name = "Aspirin",
                Price = 1.75
            },
            new Products()
            {
                Id = 2,
                Name = "Nurofen",
                Price = 2.95
            },
            new Products()
            {
                Id = 3,
                Name = "Moxogamma",
                Price = 3.60
            },
            new Products()
            {
                Id = 4,
                Name = "Alive",
                Price = 2.15
            },
            new Products()
            {
                Id = 5,
                Name = "Prospan",
                Price = 18.30
            },
            new Products()
            {
                Id = 6,
                Name = "Ibutop",
                Price = 7.15
            }
        };
    }
}
