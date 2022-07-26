using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WeightControl.Api.Views;
using WeightControl.BusinessLogic.Services;

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
        public IEnumerable<ProductsDto> Get()
        {
            var products = productsService.GetAll().Select(product => product.AsDto());
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductsDto> Get(int id)
        {
            var _product = productsService.Get(id);
            if(_product == null)
            {
                return NotFound();
            }
            else
            {
                return _product.AsDto();
            }
        }

        [HttpDelete]
        public ActionResult<ProductsDto> Delete(int  id)
        {
            var product = new ProductsDto(){Id = id};
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<ProductsDto> Post(int id)
        {
            var products = new ProductsDto() { Id = id };
            return Ok(products);
        }
    }
}
