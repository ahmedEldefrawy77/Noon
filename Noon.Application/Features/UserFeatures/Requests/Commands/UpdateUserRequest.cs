using MediatR;
using Noon.Application.DTOs.UserDtos;
using Noon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.UserFeatures.Requests.Commands
{
    public class UpdateUserRequest : IRequest<Unit>
    {
        public UpdateUserDto? UserRequest { get; set; }
        public Guid Id { get; set; }    
    }
}
