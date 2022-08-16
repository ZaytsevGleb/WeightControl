using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WeightControl.Application.Common.Interfaces;
using WeightControl.Application.Exceptions;
using WeightControl.Application.Products;
using WeightControl.Application.Products.Models;
using WeightControl.Domain.Entities;
using Xunit;

namespace WeightControl.UnitTests.Products
{
    public class CreateProductsServiceTests
    {
        private readonly ProductsService productsService;
        private readonly AutoMocker mocker;

        public CreateProductsServiceTests()
        {
            mocker = new AutoMocker();
            productsService = mocker.CreateInstance<ProductsService>();
        }

        [Fact]
        public async Task Create_ShouldReturnProductDto()
        {
            // Arrange
            var inputProductDto = new ProductDto()
            {
                Name = "Product",
                Calories = 20,
                Type = 2,
                Unit = 2
            };

            var expectedProduct = new Product()
            {
                Id = 1,
                Name = "Product",
                Calories = 20,
                Type = 2,
                Unit = 2
            };

            mocker
                .GetMock<IValidator<ProductDto>>()
                .Setup(x => x.Validate(It.IsAny<ProductDto>()))
                .Returns(new ValidationResult());

            mocker
                .GetMock<IRepository<Product>>()
                .Setup(x => x.FindAsync(It.IsAny<Expression<Func<Product, bool>>>()))
                .ReturnsAsync(() => new List<Product>());

            mocker
                .GetMock<IMapper>()
               .Setup(x => x.Map<Product>(It.IsAny<ProductDto>()))
               .Returns(() => new Product());

            mocker
                .GetMock<IRepository<Product>>()
                .Setup(x => x.CreateAsync(It.IsAny<Product>()))
                .ReturnsAsync(() => expectedProduct);

            mocker
                .GetMock<IMapper>()
                .Setup(x => x.Map<ProductDto>(It.IsAny<Product>()))
                .Returns(() => new ProductDto())
                .Callback<object>(obj =>
                {
                    var actualProduct = obj as Product;

                    // Assert 
                    Assert.Equal(expectedProduct, actualProduct);
                });

            // Act
            var productDto = await productsService.CreateAsync(inputProductDto);

            // Assert
            Assert.NotNull(productDto);

            mocker
                .GetMock<IValidator<ProductDto>>()
                .Verify(x => x.Validate((It.IsAny<ProductDto>())), Times.Once);

            mocker
                .GetMock<IMapper>()
                .Verify(x => x.Map<ProductDto>(It.IsAny<Product>()), Times.Once);

            mocker
                .GetMock<IMapper>()
                .Verify(x => x.Map<Product>(It.IsAny<ProductDto>()), Times.Once);
        }

        [Fact]
        public async Task Create_ShouldReturnBadRequestException()
        {
            // Arrange
            mocker
                .GetMock<IValidator<ProductDto>>()
                .Setup(x => x.Validate(It.IsAny<ProductDto>()))
                .Returns(new ValidationResult());

            mocker
                .GetMock<IRepository<Product>>()
                .Setup(x => x.FindAsync(It.IsAny<Expression<Func<Product, bool>>>()))
                .ReturnsAsync(() => new List<Product> { new Product { } });

            // Act
            var task = productsService.CreateAsync(new ProductDto());

            // Assert
            await Assert.ThrowsAsync<BadRequestException>(() => task);

            mocker
                .GetMock<IValidator<ProductDto>>()
                .Verify(x => x.Validate(It.IsAny<ProductDto>()), Times.Once);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.FindAsync(It.IsAny<Expression<Func<Product, bool>>>()), Times.Once);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.GetAsync(It.IsAny<int>()), Times.Never);
        }
    }
}