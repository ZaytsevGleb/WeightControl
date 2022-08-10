using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeightControl.BusinessLogic.Exceptions;
using WeightControl.BusinessLogic.Models;
using WeightControl.DataAccess.Repositories;
using WeightControl.Domain.Entities;

namespace WeightControl.BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IRepository<Product> productsRepository;
        private readonly IValidator<ProductDto> validator;
        private readonly IMapper mapper;

        public ProductsService(IRepository<Product> productsRepository,
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

            return mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> CreateAsync(ProductDto productDto)
        {
            ValidationResult result = validator.Validate(productDto);

            if (!result.IsValid)
            {
                throw new BadRequestException(result.ToString());
            }

            var unique = await productsRepository.FindAsync(x => x.Name == productDto.Name);
            if (unique.Count == 0)
            {
                var product = await productsRepository.CreateAsync(mapper.Map<Product>(productDto));
                return mapper.Map<ProductDto>(product);
            }
            else
            {
                throw new BadRequestException("A product with the same name already exists in the database");
            }
        }

        public async Task<ProductDto> UpdateAsync(ProductDto productDto)
        {
            ValidationResult result = validator.Validate(productDto);

            if (!result.IsValid)
            {
                throw new BadRequestException(result.ToString());
            }

            var productId = await productsRepository.GetAsync(productDto.Id);
            if (productId == null)
            {
                throw new NotFoundException("Not found");
            }

            var product = await productsRepository.UpdateAsync(mapper.Map<Product>(productDto));

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