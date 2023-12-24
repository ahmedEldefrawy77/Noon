using Newtonsoft.Json;
using Noon.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Noon.Domain.Entities.Products
{
    public class Product : BaseEntitySetting
    {
        public Money? Price { get; set; }
        public SpecifiedCategory? SpecifiedCategory { get; set; }
        public Guid? SpecifiedCategoryId { get; set; }
        public Brand? Brand { get; set; }
        public Guid BrandId { get; set; }
        public int Quantity { get; set; } = 0;
        public Order? Order { get; set; }
        public Guid OrderId { get; set; }
        public decimal? TotalPriceAfterTax { get; set; }
        [NotMapped] // Exclude from database mapping
        public Dictionary<string, string> Specifications { get; set; } = new Dictionary<string, string>();
       

        // Database column for serialized JSON
       
    }

}
