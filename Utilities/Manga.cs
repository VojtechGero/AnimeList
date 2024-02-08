using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList
{
    internal class Manga : AContent
    {
        internal override long ID { get; set; }
        internal override string name { get; set; }
        internal override int count { get; set; }
        internal override bool notOut { get; set; }
        internal override List<string> genres { get; set; }
        

        //internal List<string> authors { get; set; }

        internal Manga(string line)
        {
            //read order
            // id;name;episodes;airing;gerner1,gerner2
            string[] vals = line.Split(";");
            if (!string.IsNullOrWhiteSpace(vals[0]))
            {
                ID = long.Parse(vals[1]);
            }
            else ID = 0;
            name = vals[2];
            if (string.IsNullOrWhiteSpace(vals[3]))
            {
                count = 0;
            }
            else count = int.Parse(vals[3]);
            if (vals[4] == "True")
            {
                notOut = true;
            }
            else notOut = false;
            genres = vals[5].Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        internal Manga(long id, string name, int? count, bool airing, List<string> genres)
        {
            ID = id;
            this.name = name;
            if (count == null)
            {
                count = 1;
            }
            else this.count = (int)count;
            this.notOut = airing;
            this.genres = genres;
        }
        

        public override string ToString()
        {
            return $"M;{ID};{name};{count};{notOut};{StringOps.toFile(genres)}";
        }
    }
}
