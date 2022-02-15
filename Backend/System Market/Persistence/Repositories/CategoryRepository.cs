using Super_Market.Domain.Models;
using Super_Market.Domain.Repositories;
using Super_Market.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Super_Market.Persistence.Repositories
{
    public class CategoryRepository: BaseRepository , ICategoryRepository
    {
        private readonly AppDbContext _context;
        
        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public async  Task<IEnumerable<Category>> ListAsync()
        {
            var categoriesWithProducts = _context.Categories.Include(p => p.Products).AsNoTracking();
            return await categoriesWithProducts.ToListAsync();
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            var categoriesWithProducts = _context.Categories.Include(p => p.Products).AsNoTracking();
            return await categoriesWithProducts.FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Update(Category category)
        {
             _context.Categories.Update(category);
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
        }
    }
}