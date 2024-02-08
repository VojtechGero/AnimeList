﻿using JikanDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList
{
    internal class Anime : AContent
    {
        internal override long ID { get; set; }
        internal override string name { get; set; }
        internal override int count { get; set; }
        internal override bool notOut { get; set; }
        internal override List<string> genres { get; set; }
        internal Anime(string line)
        {
            //read order
            // id;name;episodes;airing;gerner1,gerner2
            string[] vals = line.Split(";");
            if (!string.IsNullOrWhiteSpace(vals[1]))
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
            genres = vals[5].Split(",", StringSplitOptions.RemoveEmptyEntries ).ToList();
        }

        internal Anime(long id, string name, int? episodes, bool airing, List<string> genres)
        {
            ID = id;
            this.name = name;
            if (episodes == null)
            {
                episodes = 1;
            }
            else this.count = (int)episodes;
            this.notOut = airing;
            this.genres = genres;
        }

        public override string ToString()
        {
            return $"A;{ID};{name};{count};{notOut};{StringOps.toFile(genres)}";
        }
    }
}
