using Noon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Noon.Domain.Entities.Products
{
    public class Product : BaseEntitySetting
    {

        public User? User { get; set; }
        public Guid UserId { get; set; }
        //public Money? Price { get; set; }
        public SpecifiedCategory SpecifiedCategory { get; set; } = new SpecifiedCategory();
        public Guid CategoryId { get; set; }
        public Brand Brand { get; set; } = new Brand();
        public Guid BrandId { get; set; }
        //public Dictionary<string, string> Specifications { get; set; } = new Dictionary<string, string>();
    }

}
