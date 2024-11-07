

using HW_Week11.Entities;

namespace HW_Week11.Contracts
{
    public interface IProductRepository
    {
        void Create(Product product);
        Product Get(int id);
        List<Product> GetAll();
        void Update(Product p);
        void Delete(int id);
    }
}
