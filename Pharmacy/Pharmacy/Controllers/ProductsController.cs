using AutoMapper;
using Pharmacy.BL.Interfaces;
using Pharmacy.Models.DTO;
using Pharmacy.Models.Requests;
using Pharmacy.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;

        public ProductsController(IProductsService productsService, IMapper mapper)
        {
            _productsService = productsService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            var result = _productsService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]

        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _productsService.GetById(id);

            if (result == null) return NotFound(id);

            var response = _mapper.Map<ProductsResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]

        public IActionResult CreateProducts([FromBody] ProductsRequests productsRequests)
        {
            if (productsRequests == null) return BadRequest();

            var products = _mapper.Map<Products>(productsRequests);

            var result = _productsService.Create(products);

            return Ok(result);

        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _productsService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]

        public IActionResult Update([FromBody] ProductsUpdateRequests productsRequests)
        {
            if (productsRequests == null) return BadRequest();

            var searchProducts = _productsService.GetById(productsRequests.Id);

            if (searchProducts == null) return NotFound(productsRequests.Id);

            searchProducts.Name = productsRequests.Name;

            searchProducts.Price = productsRequests.Price;

            var result = _productsService.Update(searchProducts);

            return Ok(result);
        }
    }
}
