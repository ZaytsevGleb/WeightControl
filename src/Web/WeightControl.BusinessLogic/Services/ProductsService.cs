using System.Collections.Generic;
using WeightControl.BusinessLogic.Exceptions;
using WeightControl.BusinessLogic.Mapping;
using WeightControl.BusinessLogic.Models;
using WeightControl.DataAccess.Repositories;

namespace WeightControl.BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public ProductDto Get(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException($"Id: {id} not valid");
            }
            else
            {
                var product = productsRepository.Get(id);
                return product.AsProductDto() ?? throw new NotFoundException($"Product with id: {id} not found");
            }
        }

        public List<ProductDto> GetAll(string name)
        {
            var products = string.IsNullOrEmpty(name)
                ? productsRepository.Find()
                : productsRepository.Find(x => x.Name.Contains(name));

            return products.AsProductDto();
        }

        public ProductDto Create(ProductDto productDto)
        {
            var product = productsRepository.Create(productDto.AsProductCreate());

            return product.AsProductDto();
        }

        public ProductDto Update(int id, ProductDto productDto)
        {
            if (id != productDto.Id)
            {
                throw new BadRequestException($"Id: {id} and product id: {productDto.Id} must be the same");
            }

            var productId = productsRepository.Get(id);
            if (productId == null)
            {
                throw new NotFoundException("Not found");
            }

            var product = productsRepository.Update(productDto.AsProduct());
            return product.AsProductDto();
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException($"Id: {id} is not valid");
            }

            var product = productsRepository.Get(id);
            if (product == null)
            {
                throw new NotFoundException($"Product with id: {id} not found");
            }

            productsRepository.Delete(product);
        }
    }
}