using Noon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Entities.Products
{
    public class OrderProduct 
    {
        public Order? Orders { get; set; }
        public Guid OrderId { get; set; }
        public Product? Products { get; set; }
        public Guid ProductId { get; set; }
    }
}
