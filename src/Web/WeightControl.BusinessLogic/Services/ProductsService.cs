using System;
using System.Collections.Generic;
using WeightControl.BusinessLogic.Exceptions;
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

        public Product Get(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Bad request");
            }
            var _product = productsRepository.Get(id);
            return _product ?? throw new NotFoundException($"Product with {id} not found");
        }

        public List<Product> GetAll(string name)
        {
            var products = string.IsNullOrEmpty(name)
                ? productsRepository.Find()
                : productsRepository.Find(x => x.Name.Contains(name));

            return products;
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
            if(id<= 0 || id != product.Id || product == null)
            {
                throw new Exception("Bad request");
            }

            var _product = productsRepository.Get(id);
            if (_product == null)
            {
                throw new Exception("Not found");
            }
            return productsRepository.Update(product);
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is not valid");
            }

            var product= productsRepository.Get(id);
            if(product == null)
            {
                throw new BadRequestException($"Product with {id} not found");
            }

            productsRepository.Delete(product);
        }
    }
}