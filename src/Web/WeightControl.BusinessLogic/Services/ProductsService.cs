using System;
using System.Collections.Generic;
using WeightControl.DataAccess.Repositories;
using WeightControl.Domain.Entities;

namespace WeightControl.BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public Product Create(Product product)
        {
            var _product = productsRepository.Create(product);
            return _product ?? null;
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Bad request");
            }

            var product= productsRepository.Get(id);
            if(product == null)
            {
                throw new Exception("Not found");
            }

            productsRepository.Delete(product);
        }

        public Product Get(int id)
        {
            var _product = productsRepository.Get(id);
            return _product ?? null;
        }

        public List<Product> GetAll()
        {
            var _products = productsRepository.Find();
            return _products ?? null;

        }

        public Product Update(Product product)
        {
            var _product = productsRepository.Update(product);
            return _product ?? null;
        }
    }
}