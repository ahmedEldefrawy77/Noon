using Noon.Domain.Common;
using Noon.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Entities
{
    public class WishListProducts  
    {
        public WishList? WishList { get; set; }
        public Guid WishListId { get; set; }    
        public Product? Product { get; set; }
        public Guid ProductId { get; set; }
    }
}
