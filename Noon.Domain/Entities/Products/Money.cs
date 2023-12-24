using Noon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Entities.Products
{
    public class Money
    {
        public Guid Id { get; set; }
        public Product? Product { get; set; }
        public Guid ProductId { get; set; }
        public decimal Amount { get; set; }
        public decimal Currency { get; set; }
    }
}
