using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeightControl.Application.Common.Models;
using WeightControl.Application.Products;
using WeightControl.Application.Products.Models;

namespace WeightControl.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/products")]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("{id}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDto))]
        public async Task<ActionResult<ProductDto>> GetAsync(int id)
        {
            var product = await productsService.GetAsync(id);
            return Ok(product);
        }

        [HttpGet(Name = "Find")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDto))]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAsync([FromQuery] string name)
        {
            var productDtos = await productsService.FindAsync(name);
            return Ok(productDtos);
        }

        [Authorize(Roles = "admin")]
        [HttpPost(Name = "CreateProduct")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDto))]
        public async Task<ActionResult<ProductDto>> CreateAsync(ProductDto productDto)
        {
            productDto = await productsService.CreateAsync(productDto);
            return Created($"api/products/{productDto.Id}", productDto);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}", Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDto))]
        public async Task<ActionResult<ProductDto>> UpdateAsync(int id, ProductDto productDto)
        {
            if (id != productDto.Id)
                return BadRequest($"Id: {id} and product id: {productDto.Id} must be the same");

            productDto = await productsService.UpdateAsync(productDto);
            return Ok(productDto);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDto))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDto))]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await productsService.DeleteAsync(id);
            return NoContent();
        }
    }
}
