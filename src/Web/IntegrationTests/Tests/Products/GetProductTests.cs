using IntegrationTests.Client;
using System.Net;
using System.Threading.Tasks;
using WeightControl.IntegrationTests.Infrastructure.Persistence;
using Xunit;

namespace WeightControl.IntegrationTests.Tests.Products
{
    public class GetProductTests : TestingWebAppFactory
    {
        [Fact]
        public async Task GetAsync_ShouldReturnProductAnd200OK()
        {
            // Arrange
            var products = SeedTestData.GetProducts();
            DbContext.Products.AddRange(products);
            await DbContext.SaveChangesAsync();

            var targetProduct = products[0];

            // Act
            var response = await ApiClient.GetProductAsync(targetProduct.Id);

            // Assert
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            var product = response.Result;
            Assert.Equal(targetProduct.Name, product.Name);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNotValidExeptionMessageAnd400BadRequest()
        {
            // Arrange //Act
            var exception = await Assert.ThrowsAsync<ApiException<ErrorDto>>(() => ApiClient.GetProductAsync(0));

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)exception.StatusCode);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNotFoundExeptionMessageAnd404NotFound()
        {
            // Arrange
            DbContext.Products.AddRange(SeedTestData.GetProducts());
            await DbContext.SaveChangesAsync();

            int netExistedId = 100;

            // Act
            var exception = await Assert.ThrowsAsync<ApiException<ErrorDto>>(() => ApiClient.GetProductAsync(netExistedId));

            // Assert  
            Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)exception.StatusCode);
        }
    }
}
