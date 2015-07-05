using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiSharp
{
    public class KodiTvEpisode : KodiFile
    {
        // ===========================================================================
        // = Public Properties
        // ===========================================================================

        public String ShowTitle { get; set; }
        public Int32 EpisodeId { get; set; }
        public String FirstAired { get; set; }
        public String OriginalTitle { get; set; }
        public String ProductionCode { get; set; }
        public Double Rating { get; set; }

        [JsonProperty("episode")]
        public Int32 EpisodeNumber { get; set; }

        [JsonProperty("season")]
        public Int32 SeasonNumber { get; set; }

        [JsonProperty("tvshowid")]
        public Int32 ShowId { get; set; }

        [JsonProperty("title")]
        public String EpisodeTitle { get; set; }

        // ===========================================================================
        // = Public Methods
        // ===========================================================================

        public override String ToString()
        {
            return String.Format("{0} - S{1:00}E{2:00} - {3}", ShowTitle, SeasonNumber, EpisodeNumber, EpisodeTitle);
        }

        // ===========================================================================
        // = Kodi JSON-RPC Properties
        // ===========================================================================

        [JsonConverter(typeof(StringEnumConverter))]
        internal enum KodiTvEpisodeProperty
        {
            title,
            plot,
            votes,
            rating,
            writer,
            firstaired,
            playcount,
            runtime,
            director,
            productioncode,
            season,
            episode,
            originaltitle,
            showtitle,
            cast,
            streamdetails,
            lastplayed,
            fanart,
            thumbnail,
            file,
            resume,
            tvshowid,
            dateadded,
            uniqueid,
            art
        }

        internal static IList<KodiTvEpisodeProperty> _allProperties;
        internal static IList<KodiTvEpisodeProperty> AllProperties
        {
            get
            {
                if (_allProperties == null)
                    _allProperties = Enum.GetValues(typeof(KodiTvEpisodeProperty)).Cast<KodiTvEpisodeProperty>().ToList();

                return _allProperties;
            }
        }
    }
}
