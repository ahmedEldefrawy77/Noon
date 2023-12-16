using Noon.Application.Contracts.Persistence.IBaseRepository;
using Noon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Contracts.Persistence.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByIdAsync(Guid id);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserWithEmail(string email);
        Task<bool> IsEmailUniq(string email);


    }
}
