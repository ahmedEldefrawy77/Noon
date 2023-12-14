using Noon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;    
        public ICollection<Brand>? Brands { get; set; }
        public ICollection<SpecifiedCategory>? ProductCategories { get; set; }
       
    }
}
