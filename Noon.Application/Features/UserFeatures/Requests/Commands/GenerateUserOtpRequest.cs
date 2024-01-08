using MediatR;
using Noon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.UserFeatures.Requests.Commands
{
    public class GenerateUserOtpRequest : IRequest<BaseCommonResponse>
    {
        public string Email { get; set; } = string.Empty;
    }
}
