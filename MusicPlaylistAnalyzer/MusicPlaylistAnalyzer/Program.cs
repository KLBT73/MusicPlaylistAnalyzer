using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlaylistAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            //ensure user inputs at least 2 args
            if (args.Length !=2)
            {
                Console.WriteLine("MusicPlaylistAnalyzer <music_playlist_file_path> <report_file_path>");
                Environment.Exit(1);
            }

            string SampleMusicPlaylist = args[0];
            string reportFile = args[1];

            List<MusicStats> musicStatsList = null;
            try
            {
                musicStatsList = MusicStatsLoad.Load(SampleMusicPlaylist);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(2);
            }

            var report = MusicStatsReport.GenText(musicStatsList);

            try
            {
                System.IO.File.WriteAllText(reportFile, report);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(3);
            }
            Console.ReadKey();
        }
    }
}
