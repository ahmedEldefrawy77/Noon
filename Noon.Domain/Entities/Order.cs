using Noon.Domain.Common;
using Noon.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Entities
{
    public class Order : BaseEntitySetting
    {
        public User? User {  get; set; }
        public Guid UserId {  get; set; } 
        public ICollection<Product>? Products { get; set; }
        public double TotalPrice { get; set; }
    }
}
