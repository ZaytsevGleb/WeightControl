﻿using IntegrationTests.Client;
using System.Net;
using System.Threading.Tasks;
using WeightControl.IntegrationTests.Infrastructure.Persistence;
using Xunit;

namespace WeightControl.IntegrationTests.Tests.Products
{
    public class DeleteProductTests : TestingWebAppFactory
    {
        [Fact]
        public async Task DeleteAsync_ShouldReturn204NoContent()
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

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task DeleteAsync_ShouldReturn400BadRequest(int id)
        {
            // Arrange //Act
            var exception = await Assert.ThrowsAsync<ApiException<ErrorDto>>(() => ApiClient.DeleteProductAsync(id));

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)exception.StatusCode);
            Assert.Equal($"Id: {id} not valid", exception.Result.Description);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturn404NotFound()
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
            Assert.Equal($"Product with id: {id} not found", exception.Result.Description);
        }
    }
}