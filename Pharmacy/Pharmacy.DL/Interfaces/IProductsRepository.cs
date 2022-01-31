using System.Collections.Generic;
using Pharmacy.Models.DTO;

namespace Pharmacy.DL.Interfaces
{
    public interface IProductsRepository
    {
        Products Create(Products products);

        Products Update(Products products);

        Products Delete(int id);

        Products GetById(int id);

        IEnumerable<Products> GetAll();
    }
}
