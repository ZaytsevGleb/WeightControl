using System;
using System.Collections.Generic;
using WeightControl.Domain.Entities;

namespace WeightControl.BusinessLogic.Services
{
    public interface IProductsService
    {
        Product Get(int id);
        List<Product> GetAll();
        Product Create(string name, int Calories, int Type, int Unit);
        Product Update(Product product);
        void Delete(int id);
    }
}
