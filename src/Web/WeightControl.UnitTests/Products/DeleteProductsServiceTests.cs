using Moq;
using Moq.AutoMock;
using System.Threading.Tasks;
using WeightControl.Application.Common.Interfaces;
using WeightControl.Application.Exceptions;
using WeightControl.Application.Products;
using WeightControl.Domain.Entities;
using Xunit;

namespace WeightControl.UnitTests.Products
{
    public class DeleteProductsServiceTests
    {
        private readonly ProductsService productsService;
        private readonly AutoMocker mocker;

        public DeleteProductsServiceTests()
        {
            mocker = new AutoMocker();
            productsService = mocker.CreateInstance<ProductsService>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task Delete_ShouldThrowBadRequestException_IfIdIsNotValid(int id)
        {
            // Act
            var task = productsService.DeleteAsync(id);

            // Assert
            await Assert.ThrowsAsync<BadRequestException>(() => task);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.GetAsync(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async Task Delete_ShouldThrowNotFoundException_IfDBNotContainProduct()
        {
            // Act
            var task = productsService.DeleteAsync(1);

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => task);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.GetAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task Delete_ShouldDeleteProduct()
        {
            // Arrange
            var expectedProduct = new Product()
            {
                Id = 1,
            };

            mocker
                .GetMock<IRepository<Product>>()
                .Setup(x => x.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(() => expectedProduct);

            mocker
                .GetMock<IRepository<Product>>()
                .Setup(x => x.DeleteAsync(It.IsAny<Product>()));

            // Act
            await productsService.DeleteAsync(expectedProduct.Id);

            // Assert
            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.DeleteAsync(It.IsAny<Product>()), Times.Once);

            mocker
                .GetMock<IRepository<Product>>()
                .Verify(x => x.GetAsync(It.IsAny<int>()), Times.Once);
        }
    }
}