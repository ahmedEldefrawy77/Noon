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
    public class BaseUserSettingRepository<T> : GenericRepository<T>, IBaseUserSettingRepository<T> where T : BaseEntityUserSettings
    {

        public BaseUserSettingRepository(ApplicationDbContext context) : base(context) { }
      
        public async Task<IEnumerable<T?>> SearchByName(string fName, string lName)
        {
            IEnumerable<T?> EntityFromDb = await Task.Run(()=> _dbSet.Where(e=>e.FirstName == fName).ToList());
            if (EntityFromDb == null)
            {
                IEnumerable<T?> lNameEnittyFromDb = await Task.Run(() => _dbSet.Where(e => e.LastName == lName).ToList());
                if (lNameEnittyFromDb == null)
                {
                    
                    throw new ArgumentNullException($"there is no Entity in Db With this First Name {EntityFromDb} or Last Name {lNameEnittyFromDb} you have given");
                }
                return lNameEnittyFromDb;
            }
          
            return EntityFromDb;
        }
    }
}
