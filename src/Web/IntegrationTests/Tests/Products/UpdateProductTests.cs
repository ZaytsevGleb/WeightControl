using IntegrationTests.Client;
using System.Net;
using System.Threading.Tasks;
using WeightControl.Domain.Entities;
using WeightControl.IntegrationTests.Infrastructure.Persistence;
using Xunit;

namespace WeightControl.IntegrationTests.Tests.Products
{
    public class UpdateProductTests : TestingWebAppFactory
    {
        [Fact]
        public async Task UpdateProduct_ShouldReturnUpdatedProductAnd200OK()
        {
            // Arrange
            var expectedProducts = SeedTestData.GetProducts();
            DbContext.Products.AddRange(expectedProducts);
            await DbContext.SaveChangesAsync();

            var productDto = new ProductDto { Id = 1, Name = "Green Tea", Calories = 200, Type = 3, Unit = 1 };

            // Act
            var response = await ApiClient.UpdateProductAsync(1, productDto);

            // Assert
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.Equal(response.Result.Name, productDto.Name);
            Assert.Equal(response.Result.ToString(), productDto.ToString());
        }

      /*  [Fact]
        public async Task UpdateProduct_ShouldReturnSameIdErrorMessageAnd400BadRequest()
        {
            // Arrange
            var expectedProducts = SeedTestData.GetProducts();
            DbContext.Products.AddRange(expectedProducts);
            await DbContext.SaveChangesAsync();

            var id = 2;

            var productDto = new ProductDto { Id = 1, Name = "Green Tea", Calories = 200, Type = 3, Unit = 1 };

            // Act
            var exception = await Assert.ThrowsAsync<ApiException<ErrorDto>>(() => ApiClient.UpdateProductAsync(id, productDto));

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)exception.StatusCode);
            Assert.Equal($"Id: {id} and product id: {productDto.Id} must be the same", exception.Result.Description);
        }*/

        [Fact]
        public async Task UpdateProduct_ShouldReturnNotValidAnd400BadRequest()
        {
            // Arrange
            var expectedProducts = SeedTestData.GetProducts();
            DbContext.Products.AddRange(expectedProducts);
            await DbContext.SaveChangesAsync();

            // Act
            var exception = Assert.ThrowsAsync<ApiException<ErrorDto>>(() => ApiClient.UpdateProductAsync(1, new ProductDto {Id = 1 }));

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)exception.Result.StatusCode);
        }

        [Fact]
        public async Task UpdateProduct_ShouldReturnNotFoundExceptionMessageAnd404NotFound()
        {
            // Arrange
            var expectedProducts = SeedTestData.GetProducts();
            DbContext.Products.AddRange(expectedProducts);
            await DbContext.SaveChangesAsync();

            var id = 3;
            var productDto = new ProductDto { Id = id, Name = "Green Tea", Calories = 200, Type = 3, Unit = 1 };

            // Act

            var exception = await Assert.ThrowsAsync<ApiException<ErrorDto>>(() => ApiClient.UpdateProductAsync(id, productDto));
            // Assert
            Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)exception.StatusCode);
            Assert.Equal($"Product with id: {id} not found", exception.Result.Description);
        }
    }
}
