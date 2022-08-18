using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Moq.AutoMock;
using System.Threading.Tasks;
using WeightControl.Application.Common.Interfaces;
using WeightControl.Application.Exceptions;
using WeightControl.Application.Products;
using WeightControl.Application.Products.Models;
using WeightControl.Domain.Entities;
using Xunit;

namespace WeightControl.UnitTests.Products
{
    public class UpdateProductsServiceTests
    {
        private readonly ProductsService productsService;
        private readonly AutoMocker mocker;

        public UpdateProductsServiceTests()
        {
            mocker = new AutoMocker();
            productsService = mocker.CreateInstance<ProductsService>();
        }

        [Fact]
        public async Task Update_ShouldReturnUpdatedProductDto()
        {
            // Arrange
            var productDto = new ProductDto()
            {
                Id = 1,
                Name = "qwerty",
                Calories = 140,
                Type = 4,
                Unit = 1
            };

            var existingProduct = new Product();

            mocker
                .GetMock<IValidator<ProductDto>>()
                .Setup(x => x.Validate(It.IsAny<ProductDto>()))
                .Returns(new ValidationResult());

            mocker
                .GetMock<IRepository<Product>>()
                .Setup(x => x.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(() => existingProduct);

            mocker
                .GetMock<IRepository<Product>>()
                .Setup(x => x.UpdateAsync(It.IsAny<Product>()))
                .Callback<Product>(actualProduct =>
                {
                    // Assert
                    Assert.Equal(actualProduct, existingProduct);
                });

            mocker
                .GetMock<IMapper>()
                .Setup(x => x.Map<ProductDto>(It.IsAny<Product>()))
                .Returns(() => new ProductDto())
                .Callback<object>(obj =>
                {
                    var mapResultProduct = obj as Product;

                    // Assert
                    Assert.Equal(productDto.Name, mapResultProduct.Name);
                    Assert.Equal(productDto.Calories, mapResultProduct.Calories);
                    Assert.Equal(productDto.Type, mapResultProduct.Type);
                    Assert.Equal(productDto.Unit, mapResultProduct.Unit);
                });

            // Act
            var actualProductDto = await productsService.UpdateAsync(productDto);

            // Assert
            Assert.NotNull(actualProductDto);

            mocker
                .GetMock<IValidator<ProductDto>>()
                .Verify(x => x.Validate(It.IsAny<ProductDto>()), Times.Once);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.GetAsync(It.IsAny<int>()), Times.Once);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.UpdateAsync(It.IsAny<Product>()), Times.Once);

            mocker
                .GetMock<IMapper>()
                .Verify(x => x.Map<ProductDto>(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task Update_ShouldReturnNotFoundException_IfDBNotContainProduct()
        {
            // Arrange
            mocker
                .GetMock<IValidator<ProductDto>>()
                .Setup(x => x.Validate(It.IsAny<ProductDto>()))
                .Returns(new ValidationResult());

            mocker
                .GetMock<IRepository<Product>>()
                .Setup(x => x.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            // Act
            var task = productsService.UpdateAsync(new ProductDto { Id = 1 });

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => task);

            mocker
               .GetMock<IValidator<ProductDto>>()
               .Verify(x => x.Validate(It.IsAny<ProductDto>()), Times.Once);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.GetAsync(It.IsAny<int>()), Times.Once);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.UpdateAsync(It.IsAny<Product>()), Times.Never);

            mocker
                .GetMock<IMapper>()
                .Verify(x => x.Map<ProductDto>(It.IsAny<Product>()), Times.Never);
        }

        [Fact]
        public async Task Update_ShouldReturnBadRequestException_IfProductIsNotValid()
        {
            // Arrange
            var validator = new ProductDtoValidator();

            var actualProductDto = new ProductDto();

            mocker
                .GetMock<IValidator<ProductDto>>()
                .Setup(x => x.Validate(It.IsAny<ProductDto>()))
                .Returns(validator.Validate(actualProductDto));

            // Act
            var task = productsService.UpdateAsync(actualProductDto);

            // Assert
            await Assert.ThrowsAsync<BadRequestException>(() => task);

            mocker
                .GetMock<IValidator<ProductDto>>()
                .Verify(x => x.Validate(It.IsAny<ProductDto>()), Times.Once);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.GetAsync(It.IsAny<int>()), Times.Never);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.UpdateAsync(It.IsAny<Product>()), Times.Never);

            mocker
                .GetMock<IMapper>()
                .Verify(x => x.Map<ProductDto>(It.IsAny<Product>()), Times.Never);
        }
    }
}