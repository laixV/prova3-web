using Super_Market.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Super_Market.Domain.Repositories
{
    public interface IProductRepository
    {
        public Task AddAsync(Product product);

        public Task<IEnumerable<Product>> ListAsync();

        public Task<Product> FindByIdAsync(int id);

        public void Update(Product product);

        public void Delete(Product product);
    }
}