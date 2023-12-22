using Noon.Application.Contracts.Persistence.IBaseRepository;
using Noon.Application.DTOs.Record;
using Noon.Application.DTOs.UserDtos;
using Noon.Application.Responses;
using Noon.Domain.Entities;
using Noon.Domain.Entities.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Contracts.Identity
{
    public interface IAuthServices : IGenericRepository<User> 
    {
        Task<BaseCommonResponse> Login(UserLoginRequest userRequest);
        Task<BaseCommonResponse> Register(CreateUserDto  createUserDto);
        Task<BaseCommonResponse> Logout(string refreshToken);
        Task<BaseCommonResponse> Update(UpdateUserDto userRequest, Guid id);
        Task<BaseCommonResponse> UpdatePassword(PasswordRecord password, Guid id);
        Task<BaseCommonResponse> GetUserByToken(string token);

    }
}
