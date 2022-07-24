using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightControl.Domain.Entities;

namespace WeightControl.BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsService productsService;

        public ProductsService(IProductsService productsService)
        {
            this.productsService = productsService; 
        }

        public ProductResult Create()
        {
            throw new NotImplementedException();
        }

        public ProductResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ProductResult Get(int id)
        {
            throw new NotImplementedException();
        }

        public ProductResult GetAll()
        {
            throw new NotImplementedException();
        }

        public ProductResult Update()
        {
            throw new NotImplementedException();
        }
    }
}
