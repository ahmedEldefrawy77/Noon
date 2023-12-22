using Noon.Application.Contracts.Identity;
using Noon.Application.DTOs.Record;
using Noon.Application.DTOs.UserDtos;
using Noon.Application.Features.JwtFeatures.Options;
using Noon.Domain.Entities.Options;
using Noon.Domain.Entities;
using Noon.Domain.Entities.Tokens;
using Noon.Infrastructure.IdentityProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Noon.Application.Features.UserFeatures.Requests.Commands;
using Noon.Application.Responses;
using Noon.Application.Contracts.Persistence.IRepository;
using Noon.Application.Exceptions;
using Noon.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Options;
using Noon.Domain.Persistence.IRepository;

namespace Noon.Infrastructure.AuthServices
{
    public class AuthService : GenericRepository<User>, IAuthServices
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly RefreshOptions _refreshOptions;
        private readonly AccessOptions _accessOptions;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly RefreshTokenValidator _refreshTokenValidator;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AuthService(ApplicationDbContext context,IJwtProvider jwtProvider,
            IOptions<RefreshOptions> refreshOptions,
            IOptions<AccessOptions> accessOptions,
            IMediator mediator,
            IMapper mapper,
            IUserRepository userRepository,
            RefreshTokenValidator refreshTokenValidator,
            IRefreshTokenRepository refreshTokenRepository) : base(context)
        {
            _jwtProvider = jwtProvider;
            _refreshOptions = refreshOptions.Value;
            _accessOptions = accessOptions.Value;
            _mediator = mediator;
            _mapper = mapper;
            _userRepository = userRepository;
            _refreshTokenValidator = refreshTokenValidator;
            _refreshTokenRepository = refreshTokenRepository;
        }
        #region Generating Token
        private Token GenerateToken(User user, RefreshToken refreshToken)
        {
            Token token = new()
            {
                AccessToken = _jwtProvider.GetAccessToken(user),
                AccessTokenExDate = DateTime.UtcNow.AddMinutes(_accessOptions.ExpireTimeInMintes),
                RefreshToken = refreshToken.Value,
                RefreshTokenExDate = DateTime.UtcNow.AddMonths(_refreshOptions.ExpireTimeInMonths),
                role = user.Role = "User"
            };
            return token;
        }
        private RefreshToken GenerateRefreshToken(Guid Userid = default(Guid),
       Guid id = default(Guid))
        {
            string tokenValue = _jwtProvider.GetRefreshtoken();
            RefreshToken token = new()
            {
                CreatedAt = DateTime.UtcNow,
                ExpiredAt = DateTime.UtcNow.AddMonths(_refreshOptions.ExpireTimeInMonths),
                Id = id,
                UserId = Userid,
                Value = tokenValue
            };
            return token;
        }
        #endregion
        public async Task<BaseCommonResponse> Login(UserLoginRequest userRequest)
        {
            

            BaseCommonResponse response = new BaseCommonResponse();
            User? userFromDb = await _userRepository.GetUserWithEmail(userRequest.Email);
            if (userFromDb == null)
            {
                NotFoundException ex = new ("User" ,  userRequest.Email);
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = ex;
                return response;
            }

            if (!BCrypt.Net.BCrypt.Verify(userRequest.Password, userFromDb.Password))
            {
             
                response.Status = false;
                response.ResponseNumber = 400;
                response.Response = "Password is not Correct please try again Later";
                return response;
            }

            if (userFromDb.RefreshToken == null)
            {
                userFromDb.RefreshToken = GenerateRefreshToken(userFromDb.Id);

                await _userRepository.UpdateAsync(userFromDb);

            }

            if (!_refreshTokenValidator.Validate(userFromDb.RefreshToken.Value!))
            {
                userFromDb.RefreshToken = GenerateRefreshToken(userFromDb.Id);

               await _userRepository.UpdateAsync(userFromDb);
 
            }
            Token token = GenerateToken(userFromDb, userFromDb.RefreshToken);
            response.Id = userFromDb.Id;
            response.Status = true;
            response.ResponseNumber = 200;
            response.Response = "Login Succeded";
            response.Token = token;
            return response;
        }

        public async Task<BaseCommonResponse> Register(CreateUserDto createUserDto)
        {
           User user =  _mapper.Map<User>(createUserDto);   
            user.RefreshToken = GenerateRefreshToken();

            user.DateCreatedAt = DateTime.UtcNow;
            RegisterUserDto userDto = _mapper.Map<RegisterUserDto>(user);

           BaseCommonResponse response = await _mediator.Send(new CreateUserRequest { RegisterUserDto = userDto});

            if(response.ResponseNumber == 200)
            {
                Token token = GenerateToken(user, user.RefreshToken);
                response.Token = token;
            }
            else
            {
                return response;
            }

            return response;
        }

        public async Task<BaseCommonResponse> Logout(string refreshToken)
        {
            BaseCommonResponse response = new BaseCommonResponse();

            if (refreshToken == null || refreshToken == string.Empty)
                throw new ArgumentException("Invalid Token");

            User? userFromDb = await _userRepository.GetUserByToken(refreshToken);
            if (userFromDb == null || !_refreshTokenValidator.Validate(refreshToken))
            {

                response.Status = false;
                response.ResponseNumber = 400;
                response.Response = "Invalid Token";
                return response;
            }
            await _refreshTokenRepository.DeleteWithIdAsync(userFromDb.RefreshToken.Id);

            response.Status = true;
            response.ResponseNumber = 200;
            response.Response = "User Loged Out ";

            return response;

           
        }

        public async Task<BaseCommonResponse> Update(UpdateUserDto request, Guid id)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            User? userFromDb = await _userRepository.GetUserByIdAsync(id);
            if (userFromDb == null)
                throw new ArgumentNullException(nameof(request), "Invalid Token");

            if (request == null)
                throw new ArgumentNullException(nameof(request));

           Unit unit =  await _mediator.Send(new UpdateUserRequest { UserRequest = request ,Id = id});

            response.Status = true;
            response.ResponseNumber =200;
            response.Response = unit;

            return response;
        }

        public async Task<BaseCommonResponse> UpdatePassword(PasswordRecord password, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseCommonResponse> GetUserByToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
