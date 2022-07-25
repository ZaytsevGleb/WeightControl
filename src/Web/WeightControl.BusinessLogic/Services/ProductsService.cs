using System;
using WeightControl.DataAccess.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightControl.Domain.Entities;
using WeightControl.Domain.Enums;

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
           productsRepository.Delete(id);
        }

        public Product Get(int id)
        {
            var _product = productsRepository.Get(id);
            return _product ?? null;
        }

        public List<Product> GetAll()
        {
            var _products = productsRepository.GetAll();
            return _products ?? null;

        }

        public Product Update(Product product)
        {
            var _product = productsRepository.Update(product);
            return _product ?? null;
        }
    }
}