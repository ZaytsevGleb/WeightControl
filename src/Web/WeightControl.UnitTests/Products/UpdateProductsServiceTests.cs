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
            var inputProduct = new ProductDto()
            {
                Id = 1,
                Name = "qwerty",
                Calories = 140,
                Type = 4,
                Unit = 1
            };

            var expectedProduct = new Product()
            {
                Id = 1,
                Name = "qwerty",
                Calories = 140,
                Type = 4,
                Unit = 1
            };

            mocker
                .GetMock<IValidator<ProductDto>>()
                .Setup(x => x.Validate(It.IsAny<ProductDto>()))
                .Returns(new ValidationResult());

            mocker
                .GetMock<IRepository<Product>>()
                .Setup(x => x.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(() => new Product());

            mocker
                .GetMock<IMapper>()
                .Setup(x => x.Map<Product>(It.IsAny<ProductDto>()))
                .Returns(() => expectedProduct);

            mocker
                .GetMock<IRepository<Product>>()
                .Setup(x => x.UpdateAsync(It.IsAny<Product>()))
                .ReturnsAsync(() => expectedProduct);

            mocker
                .GetMock<IMapper>()
                .Setup(x => x.Map<ProductDto>(It.IsAny<Product>()))
                .Returns(() => inputProduct);

            // Act
            var productDto = await productsService.UpdateAsync(inputProduct);

            // Assert
            Assert.Equal(productDto, inputProduct);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.UpdateAsync(It.IsAny<Product>()), Times.Once);

            mocker
                .GetMock<IMapper>()
                .Verify(x => x.Map<Product>(It.IsAny<ProductDto>()), Times.Once);
        }
        [Fact]
        public async Task Create_ShouldReturnNotFoundException()
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
                .GetMock<IRepository<Product>>()
                .Verify(x => x.GetAsync(It.IsAny<int>()), Times.Once);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.UpdateAsync(It.IsAny<Product>()), Times.Never);
        }
    }
}