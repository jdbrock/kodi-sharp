using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KodiSharp
{
    public class KodiMovie : KodiFile
    {
        // ===========================================================================
        // = Public Properties
        // ===========================================================================
        
        public Int32 MovieId { get; set; }
        public String OriginalTitle { get; set; }
        public String Title { get; set; }
        public String Tagline { get; set; }
        public Int32 Year { get; set; }
        public String PlotOutline { get; set; }
        public Double Rating { get; set; }
        public String Votes { get; set; }

        public String ImdbNumber { get; set; }
        public String Mpaa { get; set; }
        public String Set { get; set; }
        public Int32 SetId { get; set; }
        public String SortTitle { get; set; }
        public Int32 Top250 { get; set; }
        public String Trailer { get; set; }

        [JsonProperty("writer")] public List<String> Writers { get; set; }
        [JsonProperty("showlink")] public List<String> ShowLinks { get; set; }
        [JsonProperty("studio")] public List<String> Studios { get; set; }
        [JsonProperty("tag")] public List<String> Tags { get; set; }
        [JsonProperty("cast")] public List<KodiCastMember> CastMembers { get; set; }
        [JsonProperty("country")] public List<String> Countries { get; set; }
        [JsonProperty("genre")] public List<String> Genres { get; set; }

        // ===========================================================================
        // = Public Methods
        // ===========================================================================

        public override String ToString()
        {
            return String.Format("{0} ({1})", Title, Year);
        }

        // ===========================================================================
        // = Kodi JSON-RPC Properties
        // ===========================================================================
        
        [JsonConverter(typeof(StringEnumConverter))]
        internal enum KodiMovieProperty
        {
            title,
            genre,
            year,
            rating,
            director,
            trailer,
            tagline,
            plot,
            plotoutline,
            originaltitle,
            lastplayed,
            playcount,
            writer,
            studio,
            mpaa,
            cast,
            country,
            imdbnumber,
            runtime,
            set,
            showlink,
            streamdetails,
            top250,
            votes,
            fanart,
            thumbnail,
            file,
            sorttitle,
            resume,
            setid,
            dateadded,
            tag,
            art
        }

        internal static IList<KodiMovieProperty> _allProperties;
        internal static IList<KodiMovieProperty> AllProperties
        {
            get
            {
                if (_allProperties == null)
                    _allProperties = Enum.GetValues(typeof(KodiMovieProperty)).Cast<KodiMovieProperty>().ToList();

                return _allProperties;
            }
        }
    }
}
