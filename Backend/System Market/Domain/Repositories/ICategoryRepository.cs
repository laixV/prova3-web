using Super_Market.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Super_Market.Domain.Repositories
{
    public interface ICategoryRepository
    {

        Task AddAsync(Category category);
        Task<IEnumerable<Category>> ListAsync();

        Task<Category> FindByIdAsync(int Id);

        void Update(Category category);

        void Delete(Category category);
    }
}