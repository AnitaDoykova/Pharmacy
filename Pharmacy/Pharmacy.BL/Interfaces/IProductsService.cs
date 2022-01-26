using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Models.DTO;


namespace Pharmacy.BL.Interfaces
{
    public interface IProductsService
    {
        Products Create(Products products);

        Products Update(Products products);

        Products Delete(int id);

        Products GetById(int id);

        IEnumerable<Products> GetAll();
    }
}
