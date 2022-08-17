using AutoMapper;
using FluentValidation;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml.Linq;
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
        private readonly AutoMocker mocker;

        public FindProductsServiceTests()
        {
            mocker = new AutoMocker();
            productsService = mocker.CreateInstance<ProductsService>();
        }

        [Fact]
        public async Task Find_ShouldReturnAllProductsDto()
        {
            // Arrange
            var actualProducts = new List<Product>();
            var expectedProducts = new List<Product> {
                new Product {Name = "Tea", Calories = 20, Type = 0, Unit = 0},
                new Product {Name = "Cake", Calories = 269, Type = 5, Unit = 1},
            };

            mocker
                .GetMock<IRepository<Product>>()
                .Setup(x => x.FindAsync(It.IsAny<Expression<Func<Product, bool>>>()))
                .ReturnsAsync(() => expectedProducts);

            mocker
                .GetMock<IMapper>()
                .Setup(x => x.Map<ProductDto>(It.IsAny<Product>()))
                .Returns(() => new ProductDto())
                .Callback<object>(obj =>
                {
                    actualProducts.Add(obj as Product);
                });

            // Act
            var productDtos = await productsService.FindAsync(name: null);

            // Assert
            Assert.NotNull(productDtos);
            Assert.Equal(expectedProducts.Count, productDtos.Count);
            Assert.Equal(expectedProducts, actualProducts);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.FindAsync(null), Times.Once);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.FindAsync(x => x.Name.Contains(It.IsAny<string>())), Times.Never);
        }

        [Fact]
        public async Task Find_ShouldReturnProductsContainingName()
        {
            // Arrange
            var actualProducts = new List<Product>();
            var expectedProducts = new List<Product> {
                new Product {Name = "Cake", Calories = 269, Type = 5, Unit = 1},
                new Product {Name = "Coffe", Calories = 100, Type = 1, Unit = 0},
            };

            mocker
                .GetMock<IRepository<Product>>()
                .Setup(x => x.FindAsync(It.IsAny<Expression<Func<Product, bool>>>()))
                .ReturnsAsync(() => expectedProducts);

            mocker
                .GetMock<IMapper>()
                .Setup(x => x.Map<ProductDto>(It.IsAny<Product>()))
                .Returns(() => new ProductDto())
                .Callback<object>(obj =>
                {
                    actualProducts.Add(obj as Product);
                });

            // Act
            var productDtos = await productsService.FindAsync("c");

            // Assert
            Assert.NotNull(productDtos);
            Assert.Equal(expectedProducts, actualProducts);
            Assert.Equal(expectedProducts.Count, productDtos.Count);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.FindAsync(x => x.Name.Contains("c")), Times.Once);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.FindAsync(null), Times.Never);
        }
    }
}