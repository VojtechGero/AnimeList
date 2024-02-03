using JikanDotNet;
using JikanDotNet.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList
{
    internal class Anime
    {
        internal long ID { get; set; }
        internal string name {  get; set; }
        internal int episodes { get; set; }
        internal bool airing { get; set; }
        internal Anime(string line)
        {
            //read order
            // id;name;episodes;airing
            string[] vals = line.Split(";");
            ID = long.Parse(vals[0]);
            this.name = vals[1];
            if (string.IsNullOrWhiteSpace(vals[2]))
            {
                this.episodes = 0;
            }else episodes = int.Parse(vals[2]);
            if (vals[3]=="true")
            {
                this.airing = true;
            }else this.airing = false;
        }
        internal Anime(long id,string name,int episodes,bool airing)
        {
            ID = id;
            this.name = name;
            this.episodes = episodes;
            this.airing= airing;
        }
        public override string ToString()   
        {
            return $"{ID};{name};{episodes};{airing.ToString().ToLower()}";
        }

        

        
    }
}
