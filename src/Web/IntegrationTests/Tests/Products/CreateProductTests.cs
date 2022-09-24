using IntegrationTests.Client;
using System.Net;
using System.Threading.Tasks;
using WeightControl.Application.Products.Models;
using WeightControl.IntegrationTests.Infrastructure.Persistence;
using Xunit;
using ProductDto = IntegrationTests.Client.ProductDto;

namespace WeightControl.IntegrationTests.Tests.Products
{
    public class CreateProductTests : TestingWebAppFactory
    {
        [Fact]
        public async Task CreateProduct_ShouldReturnCreatedProductAnd201Created()
        {
            // Arrange
            var expectedProducts = SeedTestData.GetProducts();
            DbContext.Products.AddRange(expectedProducts);
            await DbContext.SaveChangesAsync();

            var productDto = new ProductDto { Name = "Orange", Calories = 200, Type = 1, Unit = 2 };

            // Act
            var response = await ApiClient.CreateProductAsync(productDto);

            // Assert
            Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)response.StatusCode);
            var product = response.Result;
            Assert.Equal(productDto.Name, product.Name);
            Assert.Equal(expectedProducts.Count + 1, product.Id);
        }

        [Fact]
        public async Task CreateProduct_ShouldReturnNotValidAnd400BadRequest()
        {
            // Arrange Act
            var exception = await Assert.ThrowsAsync<ApiException<ErrorDto>>(() => ApiClient.CreateProductAsync(null));

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)exception.StatusCode);
        }

        [Fact]
        public async Task CreateProduct_ShouldReturnProductIsAlreadyExist400BadRequest()
        {
            // Arrange
            var expectedProducts = SeedTestData.GetProducts();
            DbContext.Products.AddRange(expectedProducts);
            await DbContext.SaveChangesAsync();

            var productDto = new ProductDto { Name = "Tea", Calories = 20, Type = 1, Unit = 1 };

            // Act
            var exception = await Assert.ThrowsAsync<ApiException<ErrorDto>>(() => ApiClient.CreateProductAsync(productDto));

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)exception.StatusCode);
            Assert.Equal($"Product with name: {productDto.Name} already exists.", exception.Result.Description);
        }
    }
}
