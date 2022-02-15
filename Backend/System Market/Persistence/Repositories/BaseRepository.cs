using Super_Market.Domain.Models;
using Super_Market.Persistence.Contexts;

namespace Super_Market.Persistence.Repositories
{
    public abstract class BaseRepository
    {

        private readonly AppDbContext _context;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
        }

       
    }
}