using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.DTOs.Record.Product
{
    public class ProductPricingRecord
    {
        public string Name { get; set; }  = string.Empty;
        public decimal? MinPrice { get; set; }   
        public decimal? MaxPrice { get; set; }
    }
}
