using Noon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Noon.Domain.Entities.Products
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<SpecifiedCategory>? SpecifiedCategories { get; set; }
        public ICollection<Brand>? Brands { get; set; }
        [JsonIgnore]
        public ICollection<Product>? Products { get; set; }
    }
}
