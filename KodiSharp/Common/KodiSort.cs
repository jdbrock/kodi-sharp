using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiSharp
{
    public class KodiSort
    {
        [JsonProperty("method")]
        [JsonConverter(typeof(StringEnumConverter))]
        public KodiSortMethod SortMethod { get; set; }

        [JsonProperty("order")]
        [JsonConverter(typeof(StringEnumConverter))]
        public KodiSortOrder SortOrder { get; set; }

        public KodiSort(KodiSortMethod sortMethod, KodiSortOrder sortOrder)
        {
            SortMethod = sortMethod;
            SortOrder = sortOrder;
        }
    }
}
