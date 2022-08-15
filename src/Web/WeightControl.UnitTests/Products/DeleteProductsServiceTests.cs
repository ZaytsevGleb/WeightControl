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
    public class DeleteProductsServiceTests
    {
        private readonly ProductsService produtsService;
        private readonly AutoMocker mocker;

        public DeleteProductsServiceTests()
        {
            mocker = new AutoMocker();
            produtsService = mocker.CreateInstance<ProductsService>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task Delete_ShouldThrowBadRequestException_IfIdIsNotValid(int id)
        {
            // Act
            var task = produtsService.DeleteAsync(id);

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
        public async Task Delete_ShouldThrowNotFoundException_IfDBNotContainProduct()
        {
            // Act
            var task = produtsService.DeleteAsync(1);

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