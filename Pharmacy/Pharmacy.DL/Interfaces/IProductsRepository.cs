using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Models.DTO;

namespace Pharmacy.DL.Interfaces
{
    public interface IProductsRepository
    {
        Products Create(Products products);

        Products Update(Products products);

        Products Dalete(int id);

        Products GetById(int id);

        IEnumerable<Products> GetAll();
    }
}
