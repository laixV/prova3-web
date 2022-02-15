using Super_Market.Domain.Models;
using Super_Market.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Super_Market.Domain.Services
{
    public interface IProductService
    {
        public Task<ProductResponse> SaveAsync(Product product);

        public Task<Product> FindByIdAsync(int id);

        public Task<ProductResponse> UpdateAsync(int id, Product product);

        public Task<ProductResponse> DeleteAsync(int id);
        
        public Task<IEnumerable<Product>> ListAsync();
    }
}