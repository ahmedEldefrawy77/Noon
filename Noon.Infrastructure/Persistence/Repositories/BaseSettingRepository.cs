using Microsoft.EntityFrameworkCore;
using Noon.Domain.Common;
using Noon.Domain.Persistence.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Persistence.Repositories
{
    public class BaseSettingRepository<T> : GenericRepository<T>, IBaseSettinRepository<T> where T :  BaseEntitySetting
    {
       
        public BaseSettingRepository(ApplicationDbContext context) : base(context) { }
    
        public async Task<ICollection<T>> SearchByName(string name)
        {
            ICollection<T> EntitiesFromDb = await  Task.Run(() => _dbSet.Where(e =>e.Name == name).ToList());
            return EntitiesFromDb;
        }
    }
}
