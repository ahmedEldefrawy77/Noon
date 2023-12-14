using MediatR;
using Noon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.UserFeatures.Requests.Queries
{
    public class GetUserWithIdRequest : IRequest<BaseCommonResponse>
    {
        public Guid Id { get; set; }
    }
}
