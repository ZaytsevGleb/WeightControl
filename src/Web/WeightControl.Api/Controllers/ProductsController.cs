using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WeightControl.Api.Views;
using WeightControl.BusinessLogic.Services;
using WeightControl.Domain.Entities;

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
            var products = productsService.GetAll(name).Select(product => product.AsDto());
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> Get(int id)
        {
            var product = productsService.Get(id);
            return Ok(product.AsDto());
        }

        // тут уберется преобразование в product, т.к. он передаст в виде дто + будет расширение
        // + сделать async
        [HttpPost]
        public ActionResult<ProductDto> Post(ProductDto productDto)
        {
            ValidationResult result = validator.Validate(productDto);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }
            else 
            {
                Product product = new()
                {
                    Name = productDto.Name,
                    Calories = productDto.Calories,
                    Type = productDto.Type,
                    Unit = productDto.Unit
                };
                
                return Created("Product is Created!", productsService.Create(product).AsDto());
            }
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
            if (!result.IsValid)
            {
                return BadRequest(result);
            }
            else
            {
                Product _product = new()
                {
                    Id = productDto.Id,
                    Name = productDto.Name,
                    Calories = productDto.Calories,
                    Type = productDto.Type,
                    Unit = productDto.Unit
                };
                /*var productResult = (productsService.Update(id, _product).AsDto());*/
                return Ok(productsService.Update(id, _product).AsDto());
            }
            // аналогичено Post
            /*            try
                        {*/
            
            /*            }
                        catch (Exception ex) when (ex.Message.Contains("Bad request"))
                        {
                            return BadRequest();
                        }
                        catch (Exception ex) when (ex.Message.Contains("Not found"))
                        {
                            return NotFound($"Product with id {id} not found");
                        }*/
        }
    }
}
