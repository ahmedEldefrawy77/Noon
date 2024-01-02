using MediatR;
using Noon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.WishListFeatures.Requests.Commands
{
    public class DeleteProductFromWishListRequest : IRequest<BaseCommonResponse>
    {
        public Guid wishListId { get; set; }
        public Guid productId { get; set; }
    }
}
