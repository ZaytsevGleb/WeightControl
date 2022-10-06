using IntegrationTests.Client;
using System.Net;
using System.Threading.Tasks;
using WeightControl.IntegrationTests.Infrastructure.Persistence;
using Xunit;

namespace WeightControl.IntegrationTests.Tests.Products
{
    public class UpdateProductTests : TestingWebAppFactory
    {
        [Fact]
        public async Task Update_ShouldReturnOK()
        {
            // Arrange
            var expectedProducts = SeedTestData.GetProducts();
            DbContext.Products.AddRange(expectedProducts);
            await DbContext.SaveChangesAsync();

            var productDto = new ProductDto { Id = 1, Name = "Green Tea", Calories = 200, Type = 3, Unit = 1 };

            // Act
            var response = await ApiClient.UpdateProductAsync(productDto.Id, productDto);

            // Assert
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.Equal(response.Result.Name, productDto.Name);
            Assert.Equal(response.Result.ToString(), productDto.ToString());
        }

        [Fact]
        public async Task Update_ShouldReturnBadRequest_IfIdNotTheSame()
        {
            // Arrange
            var expectedProducts = SeedTestData.GetProducts();
            DbContext.Products.AddRange(expectedProducts);
            await DbContext.SaveChangesAsync();

            var productDto = new ProductDto { Id = 1, Name = "Green Tea", Calories = 200, Type = 3, Unit = 1 };

            // Act
            var task = ApiClient.UpdateProductAsync(2, productDto);

            // Assert
            var exception = await Assert.ThrowsAsync<ApiException<ErrorDto>>(() => task);
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)exception.StatusCode);
        }

        [Fact]
        public async Task Update_ShouldReturBadRequest_IfProductNotValid()
        {
            // Arrange
            var expectedProducts = SeedTestData.GetProducts();
            DbContext.Products.AddRange(expectedProducts);
            await DbContext.SaveChangesAsync();

            // Act
            var task = ApiClient.UpdateProductAsync(1, new ProductDto { });

            // Assert
            var exception = Assert.ThrowsAsync<ApiException<ErrorDto>>(() => task);
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)exception.Result.StatusCode);
        }

        [Fact]
        public async Task Update_ShouldReturnNotFound_IfThereIsNoProduct()
        {
            // Arrange
            var expectedProducts = SeedTestData.GetProducts();
            DbContext.Products.AddRange(expectedProducts);
            await DbContext.SaveChangesAsync();

            int notExistedId = 100;
            var productDto = new ProductDto { Id = notExistedId, Name = "Green Tea", Calories = 200, Type = 3, Unit = 1 };

            // Act
            var task = ApiClient.UpdateProductAsync(notExistedId, productDto);

            // Assert
            var exception = await Assert.ThrowsAsync<ApiException<ErrorDto>>(() => task);
            Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)exception.StatusCode);
        }
    }
}
