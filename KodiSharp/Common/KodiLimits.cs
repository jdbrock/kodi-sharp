using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiSharp
{
    public class KodiLimits
    {
        [JsonProperty("start")] public Int32 Start { get; set; }
        [JsonProperty("end")]   public Int32 End { get; set; }

        public KodiLimits(Int32 start, Int32 end)
        {
            Start = start;
            End = end;
        }
    }
}
