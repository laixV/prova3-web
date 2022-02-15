using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Super_Market.Domain.Models;
using Super_Market.Domain.Services.Communication;
using Super_Market.Resources;

namespace Super_Market.Domain.Services
{
    public interface IUserService
    {
        public Task<UserResponse> SaveAsync(User user);

        public Task<User> FindByIdAsync(int id);

        public Task<UserResponse> UpdateAsync(int id, User user);

        public Task<UserResponse> DeleteAsync(int id);

        public Task<User> FirstOrDefaultAsync(string email, string password);

        public Task<IEnumerable<User>> ListAsync();
    }
}
