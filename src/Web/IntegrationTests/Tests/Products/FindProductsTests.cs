using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using SeedTestData = WeightControl.IntegrationTests.Infrastructure.Persistence.SeedTestData;

namespace WeightControl.IntegrationTests.Tests.Products
{
    public class ProductsControllerTest : TestingWebAppFactory
    {
        [Fact]
        public async Task FindAsync_ShouldReturnAllProductsAnd200OK()
        {
            // Arrange
            var expectedProducts = SeedTestData.GetProducts();
            DbContext.Products.AddRange(expectedProducts);
            await DbContext.SaveChangesAsync();

            // Act
            var response = await ApiClient.FindAsync(null);

            // Assert
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            var products = response.Result.ToList();
            Assert.Equal(expectedProducts.Count, products.Count);
            Assert.Equal(expectedProducts[0].Name, products[0].Name);
        }

        [Fact]
        public async Task FindAsync_ShouldReturnProductStartWithTAnd200OK()
        {
            // Arrange
            var expectedProducts = SeedTestData.GetProducts();
            DbContext.Products.AddRange(expectedProducts);
            await DbContext.SaveChangesAsync();

            // Act
            var response = await ApiClient.FindAsync("T");

            // Assert
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            var products = response.Result.ToList();
            Assert.Single(products);
            Assert.Equal(expectedProducts[0].Name, products[0].Name);
        }
    }
}

