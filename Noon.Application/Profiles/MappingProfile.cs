using AutoMapper;
using BCrypt.Net;
using Noon.Application.DTOs.AddressDto;
using Noon.Application.DTOs.MoneyDtos;
using Noon.Application.DTOs.ProductDto;
using Noon.Application.DTOs.RefreshTokenDataTransferO;
using Noon.Application.DTOs.UserDtos;
using Noon.Domain.Entities;
using Noon.Domain.Entities.Products;
using Noon.Domain.Entities.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, RegisterUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<RefreshToken, RefreshTokenDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Money,MoneyDto>().ReverseMap();
            CreateMap<User, UserRegisterOutDto>().ReverseMap();  
          
        }
    }
}
