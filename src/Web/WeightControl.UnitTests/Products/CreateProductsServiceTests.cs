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
            var productDto = new ProductDto()
            {
                Name = "Product",
                Calories = 20,
                Type = 2,
                Unit = 2
            };

            var expectedProduct = new Product();

            mocker
                .GetMock<IValidator<ProductDto>>()
                .Setup(x => x.Validate(It.IsAny<ProductDto>()))
                .Returns(new ValidationResult());

            mocker
                .GetMock<IRepository<Product>>()
                .Setup(x => x.FindAsync(It.IsAny<Expression<Func<Product, bool>>>()))
                .ReturnsAsync(() => new List<Product>());

            mocker
                .GetMock<IRepository<Product>>()
                .Setup(x => x.CreateAsync(It.IsAny<Product>()))
                .ReturnsAsync(() => new Product())
                .Callback<Product>( p =>
                {
                    // Assert
                    Assert.Equal(productDto.Name, p.Name);
                    Assert.Equal(productDto.Calories, p.Calories);
                    Assert.Equal(productDto.Type, p.Type);
                    Assert.Equal(productDto.Unit, p.Unit);
                });

            mocker
                .GetMock<IMapper>()
                .Setup(x => x.Map<ProductDto>(It.IsAny<Product>()))
                .Returns(() => new ProductDto());

            // Act
            var actualProductDto = await productsService.CreateAsync(productDto);

            // Assert
            Assert.NotNull(productDto);

            mocker
                .GetMock<IValidator<ProductDto>>()
                .Verify(x => x.Validate(It.IsAny<ProductDto>()), Times.Once);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.FindAsync(It.IsAny<Expression<Func<Product, bool>>>()), Times.Once);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.CreateAsync(It.IsAny<Product>()), Times.Once);

            mocker
                .GetMock<IMapper>()
                .Verify(x => x.Map<ProductDto>(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task Create_ShouldReturnBadRequestException_IfProductDtoIsNotValid()
        {
            // Arrange
            var validator = new ProductDtoValidator();

            var actualProductDto = new ProductDto();

            mocker
                .GetMock<IValidator<ProductDto>>()
                .Setup(x => x.Validate(It.IsAny<ProductDto>()))
                .Returns(validator.Validate(actualProductDto));

            // Act
            var task = productsService.CreateAsync(actualProductDto);


            // Assert
            await Assert.ThrowsAsync<BadRequestException>(() => task);

            mocker
                .GetMock<IValidator<ProductDto>>()
                .Verify(x => x.Validate(It.IsAny<ProductDto>()), Times.Once);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.FindAsync(It.IsAny<Expression<Func<Product, bool>>>()), Times.Never);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.CreateAsync(It.IsAny<Product>()), Times.Never);

            mocker
                .GetMock<IMapper>()
                .Verify(x => x.Map<ProductDto>(It.IsAny<Product>()), Times.Never);
        }

        [Fact]
        public async Task Create_ShouldReturnBadRequestException_IfDBAlreadyContainProduct()
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
            await Assert.ThrowsAsync<NotFoundException>(() => task);

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