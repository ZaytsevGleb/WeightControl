using Microsoft.AspNetCore.Mvc;
using System;
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

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet]
        public IEnumerable<ProductDto> Get([FromQuery] string name)
        {
            var products = productsService.GetAll().Select(product => product.AsDto());
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> Get(int id)
        {
            var _product = productsService.Get(id);
            if (_product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_product.AsDto());
            }
        }

        [HttpPost]
        public ActionResult<ProductDto> Post(ProductDto productDto)
        {
            if (productDto != null)
            {
                Product _product = new()
                {
                    Name = productDto.Name,
                    Calories = productDto.Calories,
                    Type = productDto.Type,
                    Unit = productDto.Unit
                };

                return Created("Product is Created!", productsService.Create(_product).AsDto());
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<ProductDto> Delete(int id)
        {
            try
            {
                productsService.Delete(id);
                return NoContent();

            }
            catch(Exception ex) when (ex.Message.Contains("Bad request"))
            {
                return BadRequest();
            }
            catch (Exception ex) when (ex.Message.Contains("Not found"))
            {
                return NotFound($"Product with id {id} not found");
            }
        }
        [HttpPut]
        public ActionResult<ProductDto> Put(ProductDto productDto)
        {
            if (productDto != null)
            {
                Product _product = new()
                {
                    Id = productDto.Id,
                    Name = productDto.Name,
                    Calories = productDto.Calories,
                    Type = productDto.Type,
                    Unit = productDto.Unit
                };
                var productResult = (productsService.Update(_product).AsDto());
                if (productResult != null)
                    return Ok(productResult);
            }
            return NotFound();
        }
    }
}
