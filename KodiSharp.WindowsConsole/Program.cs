using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiSharp.WindowsConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var details = new KodiClientConnectionDetails("192.168.1.50", 8009, "xbmc", null);
            var client = new KodiClient(details);

            var episodes = client.Video.GetRecentlyAddedEpisodes(250).Result;

            foreach (var episode in episodes)
                Console.WriteLine(String.Format("{0} - S{1:00}E{2:00} - {3}", episode.ShowTitle, episode.SeasonNumber, episode.EpisodeNumber, episode.Title));

            Console.ReadLine();
        }
    }
}
