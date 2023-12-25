using MediatR;
using Noon.Application.DTOs.Record.SpecifiedCategory;
using Noon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.SpecifiedCategoryFeatures.Requests.Commands
{
    public class CreateSpecifiedCategoryRequest : IRequest<BaseCommonResponse>
    {
        public SpecifiedCategoryRecord? request { get; set; }
    }
}
