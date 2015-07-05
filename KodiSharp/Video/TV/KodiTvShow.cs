using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiSharp
{
    public class KodiTvShow
    {
        [JsonProperty("cast")] public List<KodiCastMember> CastMembers { get; set; }
        [JsonProperty("genre")] public List<String> Genres { get; set; }
        [JsonProperty("studio")] public List<String> Studios { get; set; }
        [JsonProperty("tag")] public List<String> Tags { get; set; }

        public Int32 Episode { get; set; }
        public String EpisodeGuide { get; set; }
        public String ImdbNumber { get; set; }
        public String Mpaa { get; set; }
        public String OriginalTitle { get; set; }
        public String Title { get; set; }
        public String Premiered { get; set; }
        public Double Rating { get; set; }
        public Int32 Season { get; set; }
        public String SortTitle { get; set; }
        public Int32 TvShowId { get; set; }
        public String Votes { get; set; }
        public Int32 WatchedEpisodes { get; set; }
        public Int32 Year { get; set; }

        // ===========================================================================
        // = Public Methods
        // ===========================================================================

        public override String ToString()
        {
            return Title;
        }

        // ===========================================================================
        // = Kodi JSON-RPC Properties
        // ===========================================================================

        [JsonConverter(typeof(StringEnumConverter))]
        internal enum KodiTvShowProperty
        {
            title,
            genre,
            year,
            rating,
            plot,
            studio,
            mpaa,
            cast,
            playcount,
            episode,
            imdbnumber,
            premiered,
            votes,
            lastplayed,
            fanart,
            thumbnail,
            file,
            originaltitle,
            sorttitle,
            episodeguide,
            season,
            watchedepisodes,
            dateadded,
            tag,
            art
        }

        internal static IList<KodiTvShowProperty> _allProperties;
        internal static IList<KodiTvShowProperty> AllProperties
        {
            get
            {
                if (_allProperties == null)
                    _allProperties = Enum.GetValues(typeof(KodiTvShowProperty)).Cast<KodiTvShowProperty>().ToList();

                return _allProperties;
            }
        }
    }
}
