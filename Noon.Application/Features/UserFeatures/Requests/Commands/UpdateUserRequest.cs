using MediatR;
using Noon.Application.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.UserFeatures.Requests.Commands
{
    public class UpdateUserRequest : IRequest<Unit>
    {
        public UpdateUserDto? UpdateUserDto { get; set; }
    }
}
