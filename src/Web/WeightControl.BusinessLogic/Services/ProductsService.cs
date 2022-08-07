using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<ProductDto> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException($"Id: {id} not valid");
            }
            else
            {
                var product = await productsRepository.GetAsync(id);
                return product.AsProductDto() ?? throw new NotFoundException($"Product with id: {id} not found");
            }
        }

        public async Task<List<ProductDto>> FindAsync(string name)
        {
            var products = string.IsNullOrEmpty(name)
                ? await productsRepository.FindAsync()
                : await productsRepository.FindAsync(x => x.Name.Contains(name));

            return products.AsProductDto();
        }

        public async Task<ProductDto> CreateAsync(ProductDto productDto)
        {
            var unique = await productsRepository.FindAsync(x => x.Name == productDto.Name);
            if (unique.Count == 0)
            {
                var product = await productsRepository.CreateAsync(productDto.AsProductCreate());
                return product.AsProductDto();
            }
            else
            {
                throw new BadRequestException("A product with the same name already exists in the database");
            }
        }

        public async Task<ProductDto> UpdateAsync(int id, ProductDto productDto)
        {
            //подумать, мб что-то можно сократить + нужно как-то менять отделные поля но при этом нельзя создавать
            //такое же имя помимо сущности которую меняешь xd
            if (id != productDto.Id)
            {
                throw new BadRequestException($"Id: {id} and product id: {productDto.Id} must be the same");
            }

            var productId = await productsRepository.GetAsync(id);
            if (productId == null)
            {
                throw new NotFoundException("Not found");
            }

            var unique = await productsRepository.FindAsync(x => x.Name == productDto.Name);
            if (unique.Count == 0)
            {
                var product = await productsRepository.UpdateAsync(productDto.AsProduct());
                return product.AsProductDto();
            }
            else
            {
                throw new BadRequestException("A product with the same name already exists in the database");

            }
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