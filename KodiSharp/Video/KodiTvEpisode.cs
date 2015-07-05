using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiSharp
{
    public class KodiTvEpisode : KodiFile
    {
        public String ShowTitle { get; set; }
        public Int32 EpisodeId { get; set; }

        [JsonProperty("episode")]
        public Int32 EpisodeNumber { get; set; }

        [JsonProperty("season")]
        public Int32 SeasonNumber { get; set; }

        [JsonProperty("tvshowid")]
        public Int32 ShowId { get; set; }

        [JsonProperty("title")]
        public String Title { get; set; }

        //public string firstaired { get; set; }
        //public string originaltitle { get; set; }
        //public string productioncode { get; set; }
        //public double rating { get; set; }
    }
}
