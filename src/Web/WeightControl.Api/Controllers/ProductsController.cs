using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeightControl.Application.Products;
using WeightControl.Application.Products.Models;

namespace WeightControl.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetAsync(int id)
        {
            var product = await productsService.GetAsync(id);

            return Ok(product);
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetAsync([FromQuery] string name)
        {
            var productDtos = await productsService.FindAsync(name);

            return productDtos;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateAsync(ProductDto productDto)
        {
            productDto = await productsService.CreateAsync(productDto);

            return Created($"api/products/{productDto.Id}", productDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateAsync(int id, ProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest($"Id: {id} and product id: {productDto.Id} must be the same");
            }

            productDto = await productsService.UpdateAsync(productDto);

            return Ok(productDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await productsService.DeleteAsync(id);

            return NoContent();
        }
    }
}
