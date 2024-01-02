using MediatR;
using Noon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.WishListFeatures.Requests.Commands
{
    public class AddWishListToUserRequest:  IRequest<BaseCommonResponse>
    {
       
        public string Name {  get; set; }  = string.Empty;
    }
}
