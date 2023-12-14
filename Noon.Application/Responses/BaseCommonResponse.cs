using Noon.Application.Exceptions;
using Noon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Responses
{
   
    public class BaseCommonResponse
    {
        public Guid Id { get; set; }
        public  bool Status { get;  set; }
        public  int ResponseNumber { get;  set; }
        public dynamic? Response { get;  set; }
        
    }
}
