using Super_Market.Domain.Models;
using Super_Market.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Super_Market.Domain.Services
{
    public interface ICategoryService
    {
        
        Task<CategoryResponse> SaveAsync(Category category);
        
        Task<Category> FindByIdAsync(int id);

        Task<CategoryResponse> UpdateAsync(int id, Category category);

        Task<CategoryResponse> DeleteAsync(int id);
        
        Task<IEnumerable<Category>> ListAsync();

    }
}