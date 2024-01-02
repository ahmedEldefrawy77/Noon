using MediatR;
using Noon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.ProductFeatures.Request.Queries
{
    public class GetAllProductWithSpecifiedCategoryNameRequest : IRequest<BaseCommonResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
