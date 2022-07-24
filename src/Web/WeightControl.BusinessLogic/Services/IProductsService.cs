using WeightControl.Domain.Entities;

namespace WeightControl.BusinessLogic.Services
{
    public interface IProductsService
    {
        ProductResult Get(int id);
        ProductResult GetAll();
        ProductResult Create();
        ProductResult Update();
        ProductResult Delete(int id);
    }
}
