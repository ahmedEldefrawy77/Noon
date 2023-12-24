using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.DictionaryComparer
{
    public class DictionaryComparer<TKey, TValue> : ValueComparer<Dictionary<TKey, TValue>>
    {
        public DictionaryComparer(bool favorStructuralComparisons = false)
            : base(
                  (c1, c2) => JsonConvert.SerializeObject(c1) == JsonConvert.SerializeObject(c2),
                  c => c == null ? 0 : JsonConvert.SerializeObject(c).GetHashCode(),
                  c => c == null ? null : JsonConvert.DeserializeObject<Dictionary<TKey, TValue>>(JsonConvert.SerializeObject(c)))
        {
        }
    }
}
