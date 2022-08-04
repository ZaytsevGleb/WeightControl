using AutoMapper;
using System.Collections.Generic;
using WeightControl.BusinessLogic.Exceptions;
using WeightControl.BusinessLogic.Models;
using WeightControl.DataAccess.Repositories;
using WeightControl.Domain.Entities;

namespace WeightControl.BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository productsRepository;
        private readonly IMapper mapper;

        public ProductsService(IProductsRepository productsRepository, IMapper mapper)
        {
            this.productsRepository = productsRepository;
            this.mapper = mapper;
        }

        public ProductDto Get(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException($"Id: {id} not valid");
            }
            else
            {
                var product = mapper.Map<ProductDto>(productsRepository.Get(id));
                return product ?? throw new NotFoundException($"Product with id: {id} not found");
            }
        }

        public List<ProductDto> GetAll(string name)
        {
            var products = string.IsNullOrEmpty(name)
                ? productsRepository.Find()
                : productsRepository.Find(x => x.Name.Contains(name));

            return mapper.Map<List<ProductDto>>(products);
        }

        public ProductDto Create(ProductDto productDto)
        {
            // подумать как обойти передачу id конкретно только тут, возможно проще свой маппер написать\
            // либо либо реализовать ещё один automapper только для метода Create...
            var product = productsRepository.Create(mapper.Map<Product>(new ProductDto
            {
                Name = productDto.Name,
                Calories = productDto.Calories,
                Type = productDto.Type,
                Unit = productDto.Unit
            }));

            return mapper.Map<ProductDto>(product);
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

            var product = productsRepository.Update(mapper.Map<Product>(productDto));
            return mapper.Map<ProductDto>(product);
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