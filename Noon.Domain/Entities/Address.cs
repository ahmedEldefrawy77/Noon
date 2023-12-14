using Noon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Entities
{
    public class Address : BaseEntity
    {
        public User? User { get; set; }
        public Guid UserId { get; set; }    
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } =string.Empty;
    }
}
