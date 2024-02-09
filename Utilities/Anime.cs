using JikanDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AnimeList
{
    internal class Anime : AContent
    {
        internal Anime(AContent a)
        {
            foreach (var prop in a.GetType().GetProperties())
            {
                this.GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(a, null), null);
            }
        }

        internal Anime(long id, string name, int? episodes, bool airing, List<string> genres)
        {
            IsAnime=true;
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

        internal string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public override string ToString()
        {
            return $"A;{ID};{name};{count};{notOut};{StringOps.toFile(genres)}";
        }
    }
}
