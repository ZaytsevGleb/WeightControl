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
        // В принципе я мог бы вынести логику проверок в расширение, но 
        // middleware скорее всего и так этим занимается так что сейчас в этом нету смысла
        public Product Get(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Bad request");
            }

            var _product = productsRepository.Get(id);
            return _product ?? throw new Exception("Not Found");
        }

        public List<Product> GetAll()
        {
            var _products = productsRepository.Find();
            return _products ?? null;

        }

        public Product Create(Product product)
        {
            if(product.Name == null && product.Calories == 0)
            {
                throw new Exception("Bad request");
            }

            var _product = productsRepository.Create(product);
            return _product ?? null;
        }

        public Product Update(int id ,Product product)
        {
            if(id<= 0 || id != product.Id )
            {
                throw new Exception("Bad request");
            }

            var _product = productsRepository.Get(id);
            if(_product == null)
            {
                throw new Exception("Not found");
            }

            return productsRepository.Update(product);
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
    }
}