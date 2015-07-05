using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiSharp.WindowsConsole
{
    public class Program
    {
        // ===========================================================================
        // = Private Properties
        // ===========================================================================
        
        private static KodiClient Kodi { get; set; }

        // ===========================================================================
        // = Entry Point
        // ===========================================================================
        
        static void Main(string[] args)
        {
            Kodi = new KodiClient("192.168.1.50", 8009);
            RunExamples().Wait();

            Console.ReadLine();
        }

        // ===========================================================================
        // = Example Methods
        // ===========================================================================

        private static async Task RunExamples()
        {
            await ExampleGetMovies();
            await ExampleGetShows();
            await ExampleGetRecentlyAddedEpisodes();
        }

        private static async Task ExampleGetMovies()
        {
            var movies = await Kodi.Movies.GetMovies();

            Console.WriteLine(String.Format("{0} movies.", movies.Count));
            Console.WriteLine();
        }

        private static async Task ExampleGetShows()
        {
            var shows = (await Kodi.TV.GetShows())
                .OrderBy(X => X.Title);

            foreach (var show in shows)
                Console.WriteLine(show);

            Console.WriteLine();
        }

        private static async Task ExampleGetRecentlyAddedEpisodes()
        {
            var episodes = await Kodi.TV.GetRecentlyAddedEpisodes();

            foreach (var episode in episodes)
                Console.WriteLine(episode);

            Console.WriteLine();
        }
    }
}
