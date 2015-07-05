using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiSharp
{
    public class KodiStandardRequestArgs
    {
        [JsonProperty("sort")] public KodiSort Sort { get; set; }
        [JsonProperty("limits")] public KodiLimits Limits { get; set; }
        [JsonProperty("properties")] public IList<Object> Properties { get; set; }
    }
}
