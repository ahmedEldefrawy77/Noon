using MediatR;
using Noon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.CategoryFeatures.Requests.Commands
{
    public class CreateCategoryRequest : IRequest<BaseCommonResponse>
    {
        public string? Name { get; set; }
    }
}
