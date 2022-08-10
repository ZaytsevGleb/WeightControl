using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeightControl.BusinessLogic.Models;
using WeightControl.BusinessLogic.Services;

namespace WeightControl.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService) => this.productsService = productsService;

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetAsync(int id)
        {
            var product = await productsService.GetAsync(id);

            return Ok(product);
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetAsync([FromQuery] string name)
        {
            var products = await productsService.FindAsync(name);

            return products;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostAsync(ProductDto productDto)
        {
            var product = await productsService.CreateAsync(productDto);

            return Created("Product is Created!", product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> PutAsync(int id, ProductDto productDto)
        {
            if (id != productDto.Id)
            {
                BadRequest($"Id: {id} and product id: {productDto.Id} must be the same");
            }

            var product = await productsService.UpdateAsync(productDto);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await productsService.DeleteAsync(id);

            return NoContent();
        }
    }
}
