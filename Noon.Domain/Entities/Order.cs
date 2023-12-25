using Noon.Domain.Common;
using Noon.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Entities
{
    public class Order : BaseEntity
    {
        public User? User {  get; set; }
        public Guid OrderUserId {  get; set; } 
        
        public double TotalPrice { get; set; }
        public double TotalPriceAfterTax { get; set; }
        public DateTime DateOrderdAt { get; set; }

        public ICollection<OrderProduct>? OrdersProducts { get; set; }
    }
}
