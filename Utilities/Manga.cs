using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AnimeList
{
    internal class Manga : AContent
    {
        

        //internal List<string> authors { get; set; }

        internal Manga(AContent a)
        {
            foreach (var prop in a.GetType().GetProperties())
            {
                this.GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(a, null), null);
            }
        }

        internal Manga(long id, string name, int? count, bool airing, List<string> genres)
        {
            IsAnime = false;
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
        
        /*
        internal override string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        */
        public override string ToString()
        {
            return $"M;{ID};{name};{count};{notOut};{StringOps.toFile(genres)}";
        }
    }
}
