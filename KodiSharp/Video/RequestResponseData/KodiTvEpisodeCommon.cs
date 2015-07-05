using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiSharp
{
    internal static class KodiTvEpisodeCommon
    {
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
