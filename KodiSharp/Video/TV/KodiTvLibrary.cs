using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiSharp
{
    public class KodiTvLibrary
    {
        private KodiClient _client;

        public KodiTvLibrary(KodiClient client)
	    {
            _client = client;
	    }

        public async Task<IList<KodiTvEpisode>> GetRecentlyAddedEpisodes()
        {
            var cmd = new KodiCommand<KodiStandardRequestArgs, KodiGetRecentlyAddedEpisodesResponse>(
                "VideoLibrary.GetRecentlyAddedEpisodes", new KodiStandardRequestArgs(KodiTvEpisode.AllProperties));

            var response = await _client.ExecuteCommandAsync(cmd);

            return response.Episodes;
        }

        public async Task<IList<KodiTvShow>> GetShows()
        {
            var cmd = new KodiCommand<KodiStandardRequestArgs, KodiGetTvShowsResponse>(
                "VideoLibrary.GetTVShows", new KodiStandardRequestArgs(KodiTvShow.AllProperties));

            var response = await _client.ExecuteCommandAsync(cmd);

            return response.Shows;
        }
    }
}
