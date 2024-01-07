using MediatR;
using Noon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.ProductFeatures.Request.Queries
{
    public class GetAllProductsForCategoryRequest : IRequest<BaseCommonResponse>
    {
        public string CategoryName { get; set; } = string.Empty;
        
    }
}
