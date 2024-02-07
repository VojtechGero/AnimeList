using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList
{
    internal class Anime
    {
        internal long ID { get; set; }
        internal string name { get; set; }
        internal int episodes { get; set; }
        internal bool airing { get; set; }
        internal List<string> genres { get; set; }
        internal Anime(string line)
        {
            //read order
            // id;name;episodes;airing;gerner1,gerner2
            string[] vals = line.Split(";");
            if (!string.IsNullOrWhiteSpace(vals[0]))
            {
                ID = long.Parse(vals[0]);
            }
            else ID = 0;
            name = vals[1];
            if (string.IsNullOrWhiteSpace(vals[2]))
            {
                episodes = 0;
            }
            else episodes = int.Parse(vals[2]);
            if (vals[3] == "True")
            {
                airing = true;
            }
            else airing = false;
            genres = vals[4].Split(",", StringSplitOptions.RemoveEmptyEntries ).ToList();
        }

        internal Anime(long id, string name, int? episodes, bool airing, List<string> genres)
        {
            ID = id;
            this.name = name;
            if (episodes == null)
            {
                episodes = 1;
            }
            else this.episodes = (int)episodes;
            this.airing = airing;
            this.genres = genres;
        }

        public override string ToString()
        {
            return $"{ID};{name};{episodes};{airing};{StringOps.toFile(genres)}";
        }
    }
}
