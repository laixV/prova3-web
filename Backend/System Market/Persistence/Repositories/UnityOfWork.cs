using Super_Market.Domain.Repositories;
using Super_Market.Persistence.Contexts;
using System.Threading.Tasks;

namespace Super_Market.Persistence.Repositories
{
    public class UnityOfWork: IUnityOfWork
    {

        private readonly AppDbContext _context;

        public UnityOfWork(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}