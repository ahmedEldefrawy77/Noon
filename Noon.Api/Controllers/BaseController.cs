using Microsoft.AspNetCore.Mvc;
using Noon.Application.Contracts.Persistence.IBaseRepository;
using Noon.Application.Exceptions;
using Noon.Application.Responses;
using Noon.Domain.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Noon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : BaseEntity
    {
        private readonly IGenericRepository<T> _repository;

        public BaseController(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

      
        public virtual async Task<IActionResult> Get(Guid id)
        {
            BaseCommonResponse response = new BaseCommonResponse();

            T? entity = await _repository.GetAsync(id);
            if(entity == null)
            {
                NotFoundException ex = new(nameof(entity), id);
                response.Status = false;
                response.ResponseNumber = 401; 
                response.Response = ex;

                return BadRequest(response);
            }
            else
            {
                response.Id = entity.Id;
                response.Status = true;
                response.ResponseNumber = 200;
                response.Response = entity;
               
                return Ok(response);
            }

        }

      
        public virtual async Task<IActionResult> Post(T entity)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            await _repository.AddAsync(entity);

            response.Id = entity.Id;
            response.Status = true;
            response.ResponseNumber = 200;
            response.Response = entity;

            return Ok(response);
        }

     
        public virtual async Task<IActionResult> Put(T entity)
        {
            await _repository.UpdateAsync(entity);

            BaseCommonResponse response = new BaseCommonResponse();
            response.Status = true;
            response.ResponseNumber = 200;
            response.Response = "Updated Succeded";

            return Ok(response);
        }

      
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            BaseCommonResponse response = new BaseCommonResponse();
           T? entity = await _repository.GetAsync(id);
            if(entity == null)
            {
                NotFoundException ex = new(nameof(entity), id);
                response.Status = false;
                response.ResponseNumber = 401;
                response.Response = ex;

                return BadRequest(response);
            }
            else
            {
                await _repository.DeleteAsync(entity);
                response.Status = true;
                response.ResponseNumber = 200;
                response.Response = "Delete Succeded";
                return Ok(response);
            }
           

        }
        protected void SetCookie(string name, string? value, DateTime expireTime)
        {
            if (value != null)
                Response.Cookies.Append(name, value
                , new CookieOptions()
                {
                    HttpOnly = true,
                    Expires = expireTime
                });
        }
        protected Guid GetUserId()
        => new(User?.FindFirst("Id")?.Value ?? "null");
    }
}
