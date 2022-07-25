using System.Collections.Generic;
using WeightControl.Domain.Entities;

namespace WeightControl.BusinessLogic.Services
{
    public interface IProductsService
    {
        Product Get(int id);
        List<Product> GetAll();
        Product Create(Product product);
        Product Update(Product product);
        void Delete(int id);
    }
}
