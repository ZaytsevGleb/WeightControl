using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")]
        public ActionResult<ProductsDto> Get(int id)
        {
            var productsResult = productsService.Get(id);
            
            if(productsResult != null)
            {
                var productsDto = new ProductsDto()
                {
                    Id = productsResult.Id,
                    Name = productsResult.Name,
                    Calories = productsResult.Calories,
                    Type = productsResult.Type,
                    Unit = productsResult.Unit
                };
                return Ok(productsDto);
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpPut]
        public ActionResult<ProductsDto> Put(int id)
        {
            var product = new ProductsDto() { Id = id };
            return Ok(product);
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
