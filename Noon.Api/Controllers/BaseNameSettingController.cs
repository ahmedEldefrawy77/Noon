using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noon.Application.Contracts.Persistence.IBaseRepository;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Domain.Common;
using Noon.Domain.Persistence.IBaseRepository;

namespace Noon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseNameSettingController<T> : BaseController<T>  where T : BaseEntityUserSettings
    {
        private readonly IBaseUserSettingRepository<T> _repository;

        public BaseNameSettingController(IBaseUserSettingRepository<T> repository): base(repository)
        {
            _repository = repository;
        }
        public async virtual Task<IActionResult> SearchByName(string fName,string lName)
        {
            IEnumerable<T?> entities = await _repository.SearchByName(fName, lName);
            return Ok(entities);
        }
    }
}
