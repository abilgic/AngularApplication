using AngularApplication.Server.Entities;
using AngularApplication.Server.Interfaces;
using AngularApplication.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularApplication.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _ProductRepository;
        public ProductController(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var result = await _ProductRepository.GetById(id);

            return result;
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            var result = await _ProductRepository.GetAll();
            return result;
        }

        [HttpPut]
        public async Task<bool> Put([FromBody] ProductModel model)
        {
            var result = await _ProductRepository.UpdateProduct(model);
            return result > 0;
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] ProductModel model)
        {
            var result = await _ProductRepository.AddProduct(model);
            return result > 0;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var result = await _ProductRepository.DeleteProduct(id);
            return result > 0;
        }
    }
}
