using AngularApplication.Server.Entities;
using AngularApplication.Server.Models;

namespace AngularApplication.Server.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetList();
        Task<Product> GetProduct(int Id);
        Task<int> AddProduct(ProductModel Productmodel);
        Task<int> UpdateProduct(ProductModel Productmodel);
        Task<int> DeleteProduct(int Id);
    }
}
