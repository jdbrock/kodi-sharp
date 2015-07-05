using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiSharp
{
    public class KodiMovieLibrary
    {
        private KodiClient _client;

        public KodiMovieLibrary(KodiClient client)
	    {
            _client = client;
	    }

        public async Task<IList<KodiMovie>> GetMovies()
        {
            var cmd = new KodiCommand<KodiStandardRequestArgs, KodiGetMoviesResponse>(
                "VideoLibrary.GetMovies", new KodiStandardRequestArgs(KodiMovie.AllProperties));

            var response = await _client.ExecuteCommandAsync(cmd);

            return response.Movies;
        }
    }
}
