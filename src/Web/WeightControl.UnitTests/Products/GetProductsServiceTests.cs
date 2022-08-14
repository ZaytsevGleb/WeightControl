using AutoMapper;
using FluentValidation;
using Moq;
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
        private readonly ProductsService produtsService;

        private readonly Mock<IRepository<Product>> mockProductsRepository;
        private readonly Mock<IValidator<ProductDto>> mockValidator;
        private readonly Mock<IMapper> mockMapper;

        public GetProductsServiceTests()
        {
            mockProductsRepository = new Mock<IRepository<Product>>();
            mockValidator = new Mock<IValidator<ProductDto>>();
            mockMapper = new Mock<IMapper>();

            produtsService = new ProductsService(
                mockProductsRepository.Object,
                mockValidator.Object,
                mockMapper.Object);
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

            mockProductsRepository
                .Setup(x => x.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(() => expectedProduct);

            mockMapper
                .Setup(x => x.Map<ProductDto>(It.IsAny<Product>()))
                .Returns(() => new ProductDto())
                .Callback<object>(obj =>
                {
                    var actualProduct = obj as Product;

                    // Assert
                    Assert.Equal(expectedProduct, actualProduct);
                });

            // Act
            var productDto = await produtsService.GetAsync(expectedProduct.Id);

            // Assert
            Assert.NotNull(productDto);

            mockProductsRepository.Verify(x => x.GetAsync(expectedProduct.Id), Times.Once);
            mockMapper.Verify(x => x.Map<ProductDto>(expectedProduct), Times.Once);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task Get_ShouldThrowBadRequestException_IfIdIsNotValid(int id)
        {
            // Act
            var task = produtsService.GetAsync(id);

            // Assert
            await Assert.ThrowsAsync<BadRequestException>(() => task);

            mockProductsRepository.Verify(x => x.GetAsync(It.IsAny<int>()), Times.Never);
            mockMapper.Verify(x => x.Map<ProductDto>(It.IsAny<Product>()), Times.Never);
        }

        [Theory]
        [InlineData(1)]
        public async Task Get_ShouldThrowNotFoundException_IfDBNotContainProduct(int id)
        {
            // Act
            var task = produtsService.GetAsync(id);

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => task);

            mockProductsRepository.Verify(x => x.GetAsync(It.IsAny<int>()), Times.Once);
            mockMapper.Verify(x => x.Map<ProductDto>(It.IsAny<Product>()), Times.Never);
        }
    }
}
