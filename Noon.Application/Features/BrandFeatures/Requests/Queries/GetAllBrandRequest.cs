using MediatR;
using Noon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.BrandFeatures.Requests.Queries
{
    public class GetAllBrandRequest : IRequest<BaseCommonResponse>
    {
    }
}
