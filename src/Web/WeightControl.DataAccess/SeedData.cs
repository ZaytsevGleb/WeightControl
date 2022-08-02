using System.Linq;
using WeightControl.Domain.Entities;

namespace WeightControl.DataAccess
{
    public static class SeedData
    {
        public static void AddSeedData(this ApplicationDBContext dbContext)
        {
            if(dbContext.Products.Any()) 
            {
                return; 
            }

            var products = new[]
            {
                new Product {Name = "Qiwi", Type = 1, Unit = 1},
                new Product { Name = "Banana", Type = 2, Unit = 2}
            };

            dbContext.AddRange(products);
            dbContext.SaveChanges();
        }
    }
}
