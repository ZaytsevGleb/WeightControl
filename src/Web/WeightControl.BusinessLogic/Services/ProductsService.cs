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
                throw new BadRequestException($"Id: {id} not valid");
            }

            var _product = productsRepository.Get(id);
            return _product ?? throw new NotFoundException($"Product with id: {id} not found");
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
            var _product = productsRepository.Create(product);
            return _product ?? null;
        }

        public Product Update(int id ,Product product)
        {
            if(id != product.Id)
            {
                throw new BadRequestException($"Id: {id} and product id: {product.Id} must be the same");
            }

            var _product = productsRepository.Get(id);
            if (_product == null)
            {
                throw new NotFoundException("Not found");
            }
            return productsRepository.Update(product);
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException($"Id: {id} is not valid");
            }

            var product= productsRepository.Get(id);
            if(product == null)
            {
                throw new NotFoundException($"Product with id: {id} not found");
            }

            productsRepository.Delete(product);
        }
    }
}