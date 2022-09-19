using System.Collections.Generic;
using System.Linq;
using WeightControl.Domain.Entities;

namespace WeightControl.Persistence
{
    public static class SeedData
    {
        public static void AddSeedData(this ApplicationDBContext dbContext)
        {
            if (!dbContext.Products.Any())
            {
                var products = new[]
                {
                new Product {Name = "Tea", Calories = 20, Type = 0, Unit = 0},
                new Product {Name = "Cake", Calories = 269, Type = 5, Unit = 1},
                new Product {Name = "Coffe", Calories = 100, Type = 1, Unit = 0},
                new Product {Name = "Bread", Calories = 265, Type = 6, Unit = 1},
                new Product {Name = "Egg", Calories = 157, Type = 0, Unit = 2},
                new Product {Name = "Potato", Calories = 76, Type = 3, Unit = 1},
                new Product {Name = "Bacon", Calories = 500, Type = 0, Unit = 1},
                new Product {Name = "Apple", Calories = 47, Type = 4, Unit = 2},
                new Product {Name = "Banana", Calories = 96, Type = 4, Unit = 2},
                new Product {Name = "Fish", Calories = 112, Type = 0, Unit = 1},
                new Product {Name = "Avocado", Calories = 160, Type = 8, Unit = 2},
                new Product {Name = "Сhicken", Calories = 190, Type = 0, Unit = 1},
                new Product {Name = "Beef", Calories = 173, Type = 0, Unit = 1},
                new Product {Name = "Pork", Calories = 364, Type = 0, Unit = 1},
                new Product {Name = "Pasta", Calories = 157, Type = 7, Unit = 1},
                new Product {Name = "Buckwheat", Calories = 343, Type = 2, Unit = 1},
                new Product {Name = "Rice", Calories = 130, Type = 2, Unit = 1},
                new Product {Name = "Strawberry", Calories = 33, Type = 8, Unit = 1},
                new Product {Name = "Blueberry", Calories = 57, Type = 8, Unit = 1},
                new Product {Name = "Raspberry", Calories = 53, Type = 8, Unit = 1},
                new Product {Name = "Peach", Calories = 39, Type = 4,Unit = 2},
                new Product {Name = "Milk", Calories = 42, Type = 1,Unit = 0},
                new Product {Name = "Pear", Calories = 57, Type = 4, Unit = 2},
                new Product {Name = "Pineapple", Calories = 50, Type = 4, Unit = 1},
                new Product {Name = "Tomato", Calories = 22, Type = 3, Unit = 2},
                new Product {Name = "Cucumber", Calories = 18, Type = 3, Unit =2},
                new Product {Name = "Orange", Calories = 75, Type = 4, Unit = 2},
                new Product {Name = "Mandarin", Calories = 50, Type = 4, Unit = 1},
                new Product {Name = "Beans", Calories = 123, Type = 3, Unit = 1},
                new Product {Name = "Cherry", Calories = 50, Type = 8, Unit = 1}
                };

                dbContext.AddRange(products);
                dbContext.SaveChanges();
            }

            if (dbContext.Users.Any())
            {
                return;
            }
            else
            {
                var roles = new List<Role> { new Role { Name = "user" }, new Role { Name = "admin" } };

                var users = new[]
                {
                    new User{Email = "gzaytsev2000@gmail.com", Name = "Zaytsev Gleb", Password = "qwerty", Roles = roles},
                    new User{Email = "testUser@mail.com", Name = "TestUser", Password = "test", Roles = new List<Role>{ roles[0] } }
                };

                dbContext.AddRange(users);
                dbContext.SaveChanges();
            }
        }
    }
}
