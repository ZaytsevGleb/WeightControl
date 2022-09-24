using IntegrationTests.Client;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using WeightControl.Application.Exceptions;
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
            var expectedProducts = SeedTestData.GetProducts();
            DbContext.Products.AddRange(expectedProducts);
            await DbContext.SaveChangesAsync();

            // Act
            var response = await ApiClient.GetProductAsync(1);

            // Assert
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            var product = response.Result;
            Assert.Equal(expectedProducts[0].Name, product.Name);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task GetAsync_ShouldReturnNotValidExeptionMessageAnd400BadRequest(int id )
        {
            // Arrange //Act
            var exception = await Assert.ThrowsAsync<ApiException<ErrorDto>>(() => ApiClient.GetProductAsync(id));

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)exception.StatusCode);
            Assert.Equal($"Id: {id} not valid", exception.Result.Description);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNotFoundExeptionMessageAnd404NotFound()
        {
            // Arrange
            var expectedProducts = SeedTestData.GetProducts();
            DbContext.Products.AddRange(expectedProducts);
            await DbContext.SaveChangesAsync();

            int id = 3;

            // Act
            var exception = await Assert.ThrowsAsync<ApiException<ErrorDto>>(() => ApiClient.GetProductAsync(id));

            // Assert  
            Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)exception.StatusCode);
            Assert.Equal($"Product with id: {id} not found", exception.Result.Description);
        }
    }
}
