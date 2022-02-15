using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Super_Market.Domain.Models;

namespace Super_Market.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<IEnumerable<User>> ListAsync();
        Task<User> FindByIdAsync(int Id);
        Task<User> FirstOrDefaultAsync(string email, string password); 
        void Update(User user);
        void Delete(User user);
    }
}
