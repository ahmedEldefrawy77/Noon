using Microsoft.EntityFrameworkCore;
using Noon.Application.Contracts.Persistence.IRepository;
using Noon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User> , IUserRepository
    {
        

        public UserRepository(ApplicationDbContext context) :base(context) { }
        

        public async Task<IReadOnlyCollection<User>> GetAllUsersAsync() => await GetAllAsync();
       

        public async Task<User?> GetUserByIdAsync(Guid? id)
            => await _dbSet.Include(t => t.RefreshToken).FirstOrDefaultAsync(e => e.Id == id);
        public async Task<User?> GetUserByToken(string token)
        => await _dbSet.Include(u => u.RefreshToken).FirstOrDefaultAsync(p=> p.RefreshToken.Value == token);

        public async Task<User?> GetUserWithEmail(string email)
        {
            User? user = await Task.Run(() => _dbSet.Include(t => t.RefreshToken).FirstOrDefaultAsync(e => e.Email == email));
            return user;
        }

        public async Task<bool> IsEmailUniq(string email)
        {
            return !await _dbSet.AnyAsync(e => e.Email == email);
        }

    }
}
