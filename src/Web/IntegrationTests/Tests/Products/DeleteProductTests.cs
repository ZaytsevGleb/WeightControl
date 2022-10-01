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
        public async Task Delete_ShouldReturnNoContent()
        {
            // Arrange
            var expectedProducts = SeedTestData.GetProducts();
            DbContext.Products.AddRange(expectedProducts);
            await DbContext.SaveChangesAsync();

            // Act
            var task = ApiClient.DeleteProductAsync(1);

            // Assert
            var response = await Assert.ThrowsAsync<ApiException>(() => task);
            Assert.Equal(HttpStatusCode.NoContent, (HttpStatusCode)response.StatusCode);
        }

        [Fact]
        public async Task Delete_ShouldReturnBadRequest_IfIdNorValid()
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

            int notExistedId = 100;

            // Act
            var task = ApiClient.DeleteProductAsync(notExistedId);

            // Assert  
            var exception = await Assert.ThrowsAsync<ApiException<ErrorDto>>(() => task);
            Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)exception.StatusCode);
        }
    }
}
