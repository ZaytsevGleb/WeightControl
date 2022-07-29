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
            var products = productsService.GetAll(name).Select(product => product.AsDto());
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> Get(int id)
        {
            try
            {
                var _product = productsService.Get(id);
                return Ok(_product.AsDto());
            }
            catch (Exception ex) when (ex.Message.Contains("Bad request"))
            {
                return BadRequest();
            }
            catch (Exception ex) when (ex.Message.Contains("Not found"))
            {
                return NotFound($"Product with id {id} not found");
            }
        }

        [HttpPost]
        public ActionResult<ProductDto> Post(ProductDto productDto)
        {
            try
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
            catch(Exception ex) when (ex.Message.Contains("Bad request"))
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<ProductDto> Delete(int id)
        {
            try
            {
                productsService.Delete(id);
                return NoContent();
            }
            catch (Exception ex) when (ex.Message.Contains("Bad request"))
            {
                return BadRequest();
            }
            catch (Exception ex) when (ex.Message.Contains("Not found"))
            {
                return NotFound($"Product with id {id} not found");
            }
        }
        [HttpPut("{id}")]
        public ActionResult<ProductDto> Put(int id, ProductDto productDto)
        {
            try
            {
                Product _product = new()
                {
                    Id = productDto.Id,
                    Name = productDto.Name,
                    Calories = productDto.Calories,
                    Type = productDto.Type,
                    Unit = productDto.Unit
                };
                var productResult = (productsService.Update(id, _product).AsDto());
                return Ok(productResult);
            }
            catch (Exception ex) when (ex.Message.Contains("Bad request"))
            {
                return BadRequest();
            }
            catch (Exception ex) when (ex.Message.Contains("Not found"))
            {
                return NotFound($"Product with id {id} not found");
            }
        }
    }
}
