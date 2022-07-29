using System;
using System.Collections.Generic;
using WeightControl.Domain.Entities;

namespace WeightControl.BusinessLogic.Services
{
    public interface IProductsService
    {
        Product Get(int id);
        List<Product> GetAll(string name);
        Product Create(Product product);
        Product Update(int id, Product product);
        void Delete(int id);
    }
}
