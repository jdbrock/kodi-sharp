using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiSharp
{
    public class KodiVideoLibrary
    {
        private KodiClient _client;

        public KodiVideoLibrary(KodiClient client)
	    {
            _client = client;
	    }

        public async Task<IList<KodiTvEpisode>> GetRecentlyAddedEpisodes(Int32 numberOfEpisodes)
        {
            var sort       = new KodiSort(KodiSortMethod.episode, KodiSortOrder.ascending);
            var limits     = new KodiLimits(0, numberOfEpisodes);
            var properties = KodiTvEpisodeCommon.AllProperties.Cast<Object>();

            var cmd = new KodiCommand<KodiGetRecentlyAddedEpisodesRequest, KodiGetRecentlyAddedEpisodesResponse>(
                "VideoLibrary.GetRecentlyAddedEpisodes", new KodiGetRecentlyAddedEpisodesRequest(sort, limits, properties));

            var response = await _client.ExecuteCommandAsync(cmd);

            return response.Episodes;
        }
    }
}
