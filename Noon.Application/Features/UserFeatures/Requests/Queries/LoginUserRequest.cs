using MediatR;
using Noon.Application.DTOs.Record;
using Noon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.UserFeatures.Requests.Queries
{
    public class LoginUserRequest : IRequest<BaseCommonResponse>
    {
        public UserLoginRequest? userRequest { get; set; }
    }
}
