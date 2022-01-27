using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.DL.Interfaces;
using Pharmacy.BL.Interfaces;
using Pharmacy.Models.DTO;
using Serilog;

namespace Pharmacy.BL.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsrepository;
        private readonly ILogger _logger;
        public ProductsService(IProductsRepository productsrepository, ILogger logger)
        {
            _productsrepository = productsrepository;
            _logger = logger;
        }
        public Products Create(Products products)
        {
            var index = _productsrepository.GetAll().OrderByDescending(X => X.Id).FirstOrDefault()?.Id;

            products.Id = (int)(index != null ? index + 1 : 1);

            return _productsrepository.Create(products);
        }

        public Products Delete(int id)
        {
            return _productsrepository.Delete(id);
        }

        public IEnumerable<Products> GetAll()
        {
            return _productsrepository.GetAll();
        }

        public Products GetById(int id)
        {
            return _productsrepository.GetById(id);
        }

        public Products Update(Products products)
        {
            return _productsrepository.Update(products);
        }
    }
}