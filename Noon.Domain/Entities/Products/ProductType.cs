using Noon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Entities.Products
{
    public class ProductType :BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
