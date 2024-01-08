using Noon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.IdentityProvider
{
    public interface IJwtProvider
    {
        string GetAccessToken(User user);
        string GetRefreshtoken();
        string GetTemporarilyAccessToken(User user);
    }
}
