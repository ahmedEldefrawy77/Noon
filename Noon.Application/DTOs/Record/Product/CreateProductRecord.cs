using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.DTOs.Record.Product
{
    public class CreateProductRecord
    {
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency {  get; set; } = string.Empty;
        public string SpecifiedCategoryName { get; set; } = string.Empty;
        public string BrandName {  get; set; } = string.Empty;
        public int Quantity { get; set; }
        public Dictionary<string , string> Specifications { get; set; } = new Dictionary<string , string>();

    }
}
