using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Super_Market.Domain.Models;
using Super_Market.Domain.Repositories;
using Super_Market.Persistence.Contexts;

namespace Super_Market.Persistence.Repositories
{
    public class UserRepository: BaseRepository, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context): base(context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);           
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<User> FindByIdAsync(int Id)
        {
            return await _context.Users.FindAsync(Id);
        }

        public async Task<User> FirstOrDefaultAsync(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Email == email && p.Password == password);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
