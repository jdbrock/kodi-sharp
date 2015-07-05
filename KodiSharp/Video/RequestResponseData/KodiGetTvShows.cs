using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiSharp
{
    internal class KodiGetTvShowsResponse
    {
        [JsonProperty("tvshows")] public IList<KodiTvShow> Shows { get; set; }
    }
}
