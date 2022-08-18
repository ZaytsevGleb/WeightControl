using AutoMapper;
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
    public class GetProductsServiceTests
    {
        private readonly ProductsService productsService;
        private readonly AutoMocker mocker;

        public GetProductsServiceTests()
        {
            mocker = new AutoMocker();
            productsService = mocker.CreateInstance<ProductsService>();
        }

        [Fact]
        public async Task Get_ShouldReturnProductDto()
        {
            // Arrange
            var expectedProduct = new Product()
            {
                Id = 1,
                Name = "Product",
                Calories = 20
            };

            mocker
                .GetMock<IRepository<Product>>()
                .Setup(x => x.GetAsync(It.IsAny<int>()))
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
            var productDto = await productsService.GetAsync(expectedProduct.Id);

            // Assert
            Assert.NotNull(productDto);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.GetAsync(expectedProduct.Id), Times.Once);

            mocker
                .GetMock<IMapper>()
                .Verify(x => x.Map<ProductDto>(expectedProduct), Times.Once);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task Get_ShouldThrowBadRequestException_IfIdIsNotValid(int id)
        {
            // Act
            var task = productsService.GetAsync(id);

            // Assert
            await Assert.ThrowsAsync<BadRequestException>(() => task);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.GetAsync(It.IsAny<int>()), Times.Never);

            mocker
                .GetMock<IMapper>()
                .Verify(x => x.Map<ProductDto>(It.IsAny<Product>()), Times.Never);
        }

        [Fact]
        public async Task Get_ShouldThrowNotFoundException_IfDBNotContainProduct()
        {
            // Act
            var task = productsService.GetAsync(1);

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => task);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.GetAsync(It.IsAny<int>()), Times.Once);

            mocker
                .GetMock<IMapper>()
                .Verify(x => x.Map<ProductDto>(It.IsAny<Product>()), Times.Never);
        }
    }
}
