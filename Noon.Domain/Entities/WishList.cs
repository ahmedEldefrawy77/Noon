using Noon.Domain.Common;
using Noon.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Entities
{
    public class WishList : BaseEntity
    {
        public string Name { get; set; } = "default";
        public User? User { get; set; }
        public Guid WishListUserId { get; set; }
        public ICollection<WishListProducts>? WishListProducts{ get; set; }
        public bool Default { get; set; } = false;
    }
}
