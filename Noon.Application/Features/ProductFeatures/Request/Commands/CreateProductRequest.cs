using MediatR;
using Noon.Application.DTOs.Record.Product;
using Noon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.ProductFeatures.Request.Commands
{
    public class CreateProductRequest : IRequest<BaseCommonResponse>
    {
        public CreateProductRecord? Productrecord { get; set; }
    }
}
