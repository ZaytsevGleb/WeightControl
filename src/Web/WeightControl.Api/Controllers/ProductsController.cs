using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public IEnumerable<ProductDto> Get([FromQuery] string name)
        {
            return productsService.GetAll(name).Select(product => product);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> Get(int id)
        {
            return Ok(productsService.Get(id));
        }

        [HttpPost]
        public ActionResult<ProductDto> Post(ProductDto productDto)
        {
            ValidationResult result = validator.Validate(productDto);

            return result.IsValid
                ? Created("Product is Created!", productsService.Create(productDto))
                : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public ActionResult<ProductDto> Delete(int id)
        {
            productsService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult<ProductDto> Put(int id, ProductDto productDto)
        {
            ValidationResult result = validator.Validate(productDto);

            return result.IsValid
                ? Ok(productsService.Update(id, productDto))
                : BadRequest(result);
        }
    }
}
