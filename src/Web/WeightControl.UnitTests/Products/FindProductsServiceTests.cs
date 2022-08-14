using AutoMapper;
using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WeightControl.Application.Common.Interfaces;
using WeightControl.Application.Products;
using WeightControl.Application.Products.Models;
using WeightControl.Domain.Entities;
using Xunit;

namespace WeightControl.UnitTests.Products
{
    public class FindProductsServiceTests
    {
        private readonly ProductsService productsService;

        private readonly Mock<IRepository<Product>> mockProductsRepository;
        private readonly Mock<IValidator<ProductDto>> mockValidator;
        private readonly Mock<IMapper> mockMapper;

        public FindProductsServiceTests()
        {
            mockProductsRepository = new Mock<IRepository<Product>>();
            mockValidator = new Mock<IValidator<ProductDto>>();
            mockMapper = new Mock<IMapper>();

            productsService = new ProductsService(
                mockProductsRepository.Object,
                mockValidator.Object,
                mockMapper.Object);
        }

        [Fact]
        public async Task Find_ShouldReturnAllProductsDto()
        {
            // Arrange
            var actualProducts = new List<Product>();
            var expectedProducts = new List<Product> {
                new Product {Name = "Tea", Calories = 20, Type = 0, Unit = 0},
                new Product {Name = "Cake", Calories = 269, Type = 5, Unit = 1},
                new Product {Name = "Coffe", Calories = 100, Type = 1, Unit = 0},
                new Product {Name = "Bread", Calories = 265, Type = 6, Unit = 1},
                new Product {Name = "Egg", Calories = 157, Type = 0, Unit = 2},
            };

            mockProductsRepository
              .Setup(x => x.FindAsync(It.IsAny<Expression<Func<Product, bool>>>()))
              .ReturnsAsync(() => expectedProducts);

            mockMapper
                .Setup(x => x.Map<ProductDto>(It.IsAny<Product>()))
                .Returns(() => new ProductDto())
                .Callback<object>(obj =>
                {
                    actualProducts.Add(obj as Product);
                });

            // Act
            var productDtos = await productsService.FindAsync(null);

            // Assert
            Assert.NotNull(productDtos);
            Assert.Equal(expectedProducts, actualProducts);

            mockProductsRepository.Verify(x => x.FindAsync(null), Times.Once);
        }

        [Theory]
        [InlineData("c")]
        public async Task Find_ShouldReturnProductsContainingName(string name)
        {
            // Arrange
            var actualProducts = new List<Product>();
            var expectedProducts = new List<Product> {
                new Product {Name = "Cake", Calories = 269, Type = 5, Unit = 1},
                new Product {Name = "Coffe", Calories = 100, Type = 1, Unit = 0},
            };
            var products = new List<Product> {
                new Product {Name = "Tea", Calories = 20, Type = 0, Unit = 0},
                new Product {Name = "Cake", Calories = 269, Type = 5, Unit = 1},
                new Product {Name = "Coffe", Calories = 100, Type = 1, Unit = 0},
                new Product {Name = "Bread", Calories = 265, Type = 6, Unit = 1},
                new Product {Name = "Egg", Calories = 157, Type = 0, Unit = 2},
            };

            mockProductsRepository
             .Setup(x => x.FindAsync(It.IsAny<Expression<Func<Product, bool>>>()))
             .ReturnsAsync(() => expectedProducts);

            mockMapper
                .Setup(x => x.Map<ProductDto>(It.IsAny<Product>()))
                .Returns(() => new ProductDto())
                .Callback<object>(obj =>
                {
                    actualProducts.Add(obj as Product);
                });

            // Act
            var productDtos = await productsService.FindAsync(name);

            // Assert
            Assert.NotNull(productDtos);
            Assert.Equal(expectedProducts, actualProducts);

            mockProductsRepository.Verify(x => x.FindAsync(x => x.Name.Contains(name)), Times.Once);
        }

        [Theory]
        [InlineData("asdasdasdawawdsa")]
        public async Task Find_ShouldReturnNullList(string name)
        {
            // Arrange
            var actualProducts = new List<Product>();
            var expectedProducts = new List<Product>();
            var products = new List<Product> {
                new Product {Name = "Tea", Calories = 20, Type = 0, Unit = 0},
                new Product {Name = "Cake", Calories = 269, Type = 5, Unit = 1},
                new Product {Name = "Coffe", Calories = 100, Type = 1, Unit = 0},
                new Product {Name = "Bread", Calories = 265, Type = 6, Unit = 1},
                new Product {Name = "Egg", Calories = 157, Type = 0, Unit = 2},
            };

            mockProductsRepository
             .Setup(x => x.FindAsync(It.IsAny<Expression<Func<Product, bool>>>()))
             .ReturnsAsync(() => expectedProducts);

            mockMapper
                .Setup(x => x.Map<ProductDto>(It.IsAny<Product>()))
                .Returns(() => new ProductDto())
                .Callback<object>(obj =>
                {
                    actualProducts.Add(obj as Product);
                });

            // Act
            var productDtos = await productsService.FindAsync(name);

            // Assert
            Assert.Equal(expectedProducts, actualProducts);
            Assert.Empty(productDtos);

            mockProductsRepository.Verify(x => x.FindAsync(x => x.Name.Contains(name)), Times.Once);
            mockMapper.Verify(x => x.Map<ProductDto>(expectedProducts), Times.Never);
        }
    }
}
