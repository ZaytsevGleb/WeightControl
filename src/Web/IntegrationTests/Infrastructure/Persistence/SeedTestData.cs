using WeightControl.Domain.Entities;

namespace WeightControl.IntegrationTests.Infrastructure.Persistence
{
    public static class SeedTestData
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product {Name = "Tea", Calories = 20, Type = 0, Unit = 0},
                new Product {Name = "Cake", Calories = 269, Type = 5, Unit = 1}
            };
        }
    }
}
