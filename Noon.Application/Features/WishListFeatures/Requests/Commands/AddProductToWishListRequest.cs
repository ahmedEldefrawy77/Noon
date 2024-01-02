using MediatR;
using Noon.Application.DTOs.Record.WishListProducts;
using Noon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.WishListFeatures.Requests.Commands
{
    public class AddProductToWishListRequest : IRequest<BaseCommonResponse>
    {
        public Guid PrdId { get; set; }
    }
}
