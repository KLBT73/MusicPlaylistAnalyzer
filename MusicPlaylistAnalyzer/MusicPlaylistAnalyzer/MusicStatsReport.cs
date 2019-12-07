using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlaylistAnalyzer
{
    public static class MusicStatsReport
    {
        public static string GenText(List<MusicStats> musicStatsList)
        {
            string report = "Music Playlist Report \n\n";

            //if list contains nothing, tell user no data
            if (musicStatsList.Count() < 1)
            {
                report += "No data is available.\n";

                return report;
            }

            //How many songs rcvd 200+ plays?
            var moreThan200 = (from musicStats in musicStatsList where musicStats.Plays > 200 orderby musicStats.Plays descending select musicStats);
            report += $"Songs that received 200 or more plays: {moreThan200}";


            return report;
        }
    }
}
