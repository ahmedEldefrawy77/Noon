using Noon.Application.Contracts.Persistence.IBaseRepository;
using Noon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Persistence.IBaseRepository
{
    public interface IBaseUserSettingRepository<T> : IGenericRepository<T> where T : BaseEntityUserSettings
    {
        Task<IEnumerable<T?>> SearchByName(string fName, string lName);
    }
}
