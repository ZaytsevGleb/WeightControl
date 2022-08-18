using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeightControl.Application.Common.Interfaces;
using WeightControl.Application.Exceptions;
using WeightControl.Application.Products.Models;
using WeightControl.Domain.Entities;

namespace WeightControl.Application.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IRepository<Product> productsRepository;
        private readonly IValidator<ProductDto> validator;
        private readonly IMapper mapper;

        public ProductsService(
            IRepository<Product> productsRepository,
            IValidator<ProductDto> validator,
            IMapper mapper)
        {
            this.productsRepository = productsRepository;
            this.validator = validator;
            this.mapper = mapper;
        }

        public async Task<ProductDto> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException($"Id: {id} not valid");
            }

            var product = await productsRepository.GetAsync(id);
            if (product == null)
            {
                throw new NotFoundException($"Product with id: {id} not found");
            }

            return mapper.Map<ProductDto>(product);
        }

        public async Task<List<ProductDto>> FindAsync(string name)
        {
            var products = string.IsNullOrEmpty(name)
                ? await productsRepository.FindAsync()
                : await productsRepository.FindAsync(x => x.Name.Contains(name));

            return products
                .Select(product => mapper.Map<ProductDto>(product))
                .ToList();
        }

        public async Task<ProductDto> CreateAsync(ProductDto productDto)
        {
            var result = validator.Validate(productDto);
            if (!result.IsValid)
            {
                throw new BadRequestException(result.ToString());
            }

            var products = await productsRepository.FindAsync(x => x.Name == productDto.Name);
            if (products.Any())
            {
                throw new NotFoundException($"Product with name: {productDto.Name} already exists.");
            }

            var product = new Product
            {
                Name = productDto.Name,
                Calories = productDto.Calories,
                Type = productDto.Type,
                Unit = productDto.Unit
            };

            product = await productsRepository.CreateAsync(product);

            return mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateAsync(ProductDto productDto)
        {
            var result = validator.Validate(productDto);
            if (!result.IsValid)
            {
                throw new BadRequestException(result.ToString());
            }

            var product = await productsRepository.GetAsync(productDto.Id);
            if (product == null)
            {
                throw new NotFoundException($"Product with id: {productDto.Id} not found");
            }

            product.Name = productDto.Name;
            product.Calories = productDto.Calories;
            product.Type = productDto.Type;
            product.Unit = productDto.Unit;

            await productsRepository.UpdateAsync(product);

            return mapper.Map<ProductDto>(product);
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException($"Id: {id} is not valid");
            }

            var product = await productsRepository.GetAsync(id);
            if (product == null)
            {
                throw new NotFoundException($"Product with id: {id} not found");
            }

            await productsRepository.DeleteAsync(product);
        }
    }
}