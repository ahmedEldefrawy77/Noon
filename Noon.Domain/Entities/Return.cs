using Noon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Entities
{
    public class Return : BaseEntity
    {
        public User? User { get; set; }
        public Guid ReturnUserId { get; set; }
        public bool Status { get; set; }
    }
}
