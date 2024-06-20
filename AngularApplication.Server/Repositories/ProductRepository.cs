using AngularApplication.Server.Data;
using AngularApplication.Server.Entities;
using AngularApplication.Server.Interfaces;
using AngularApplication.Server.Models;

namespace AngularApplication.Server.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int> AddProduct(ProductModel model)
        {
            Product Product = new Product
            {
                Name = model.Name,
                Price = model.Price,
            };

            var result = await Add(Product);
            return result;
        }

        public async Task<IEnumerable<Product>> GetList()
        {
            return await GetAll();
        }

        public async Task<int> DeleteProduct(int Id)
        {
            var Productitem = await GetById(Id);

            var result = await Remove(Productitem);
            return result;
        }

        public async Task<Product> GetProduct(int Id)
        {
            var Productitem = await GetById(Id);
            return Productitem;
        }

        public async Task<int> UpdateProduct(ProductModel model)
        {
            var Productitem = await GetById(model.Id);

            Productitem.Name = model.Name;
            Productitem.Price = model.Price;
            var result = await Update(Productitem);
            return result;

        }

    }
}
