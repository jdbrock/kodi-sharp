using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiSharp
{
    public class KodiRemoveTvShowRequestArgs
    {
        [JsonProperty("tvshowid")]
        public int TvShowId { get; set; }

        public KodiRemoveTvShowRequestArgs(int tvShowId)
        {
            TvShowId = tvShowId;
        }
    }
}
