using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiSharp
{
    //internal class KodiGetRecentlyAddedEpisodesRequest : KodiStandardRequestArgs
    //{
    //    public KodiGetRecentlyAddedEpisodesRequest(KodiSort sort, KodiLimits limits, IEnumerable<Object> properties)
    //    {
    //        Sort       = sort;
    //        Limits     = limits;
    //        Properties = properties.ToList();
    //    }
    //}

    internal class KodiGetRecentlyAddedEpisodesResponse
    {
        [JsonProperty("episodes")]
        public IList<KodiTvEpisode> Episodes { get; set; }
    }
}
