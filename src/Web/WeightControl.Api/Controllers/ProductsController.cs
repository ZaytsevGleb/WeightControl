using FluentValidation;
using FluentValidation.Results;
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
        private readonly IValidator<ProductDto> validator;

        public ProductsController(IProductsService productsService, IValidator<ProductDto> validator)
        {
            this.productsService = productsService;
            this.validator = validator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            return Ok(await productsService.GetAsync(id));
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get([FromQuery] string name)
        {
            return await productsService.FindAsync(name);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Post(ProductDto productDto)
        {
            ValidationResult result = validator.Validate(productDto);

            return result.IsValid
                ? Created("Product is Created!", await productsService.CreateAsync(productDto))
                : BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Put(int id, ProductDto productDto)
        {
            ValidationResult result = validator.Validate(productDto);

            return result.IsValid
                ? Ok(await productsService.UpdateAsync(id, productDto))
                : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await productsService.DeleteAsync(id);

            return NoContent();
        }
    }
}
