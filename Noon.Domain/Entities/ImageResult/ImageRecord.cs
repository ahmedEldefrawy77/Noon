using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Entities.ImageResult
{
    public class ImageRecord
    {
        public List<string> imagePaths { get; set; } = new List<string>();
        public int passCount { get; set; }
        public int passFail { get; set; }
    }
}
