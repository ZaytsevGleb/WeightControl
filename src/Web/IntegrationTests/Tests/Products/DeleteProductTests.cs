using IntegrationTests.Client;
using System.Net;
using System.Threading.Tasks;
using WeightControl.IntegrationTests.Infrastructure.Persistence;
using Xunit;

namespace WeightControl.IntegrationTests.Tests.Products
{
    public class DeleteProductTests : TestingWebAppFactory
    {
        [Fact]
        public async Task DeleteAsync_ShouldReturnNoContent()
        {
            // Arrange
            var expectedProducts = SeedTestData.GetProducts();
            DbContext.Products.AddRange(expectedProducts);
            await DbContext.SaveChangesAsync();

            // Act
            var response = await Assert.ThrowsAsync<ApiException>(() => ApiClient.DeleteProductAsync(1));

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, (HttpStatusCode)response.StatusCode);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnBadRequest()
        {
            // Act
            var task = ApiClient.DeleteProductAsync(0);

            // Assert
            var exception = await Assert.ThrowsAsync<ApiException<ErrorDto>>(() => task);
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)exception.StatusCode);
        }

        [Fact]
        public async Task Delete_ShouldReturnNotFound_IfThereIsNoProduct()
        {
            // Arrange
            var expectedProducts = SeedTestData.GetProducts();
            DbContext.Products.AddRange(expectedProducts);
            await DbContext.SaveChangesAsync();

            int id = 3;

            // Act
            var exception = await Assert.ThrowsAsync<ApiException<ErrorDto>>(() => ApiClient.DeleteProductAsync(id));

            // Assert  
            Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)exception.StatusCode);
        }
    }
}
