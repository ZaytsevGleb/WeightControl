using Microsoft.AspNetCore.Mvc;
using WeightControl.Api.Views;
using WeightControl.BusinessLogic.Services;

namespace WeightControl.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        /*private readonly IProductsService productsService;*/

        [HttpGet("{id}")]
        public ActionResult<ProductsDto> Get(int id)
        {
            var product = new ProductsDto() { Id = id };
            return Ok(product);
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
