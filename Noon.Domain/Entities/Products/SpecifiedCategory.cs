using Noon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Entities.Products
{
    public class SpecifiedCategory : BaseEntity
    {
        public string? Name { get; set; }
        public ICollection<Product>? Products { get; set; }

    }
}
