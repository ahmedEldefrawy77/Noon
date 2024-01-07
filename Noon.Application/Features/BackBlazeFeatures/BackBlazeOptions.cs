using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.BackBlazeFeatures
{
    public class BackBlazeOptions
    {
        public required string AccountId { get; set; }   
        public required string ApplicationKey { get; set; }
        public required string BucketId { get; set; }
        public required string BucketName { get; set; }
    }
}
