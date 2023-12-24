using MediatR;
using Noon.Application.DTOs.Record.Brand;
using Noon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.BrandFeatures.Requests.Commands
{
    public class CreateBrandRequest : IRequest<BaseCommonResponse>
    {
        public CreateBrandRecord? CreateBrandRecord { get; set; }
    }
}
