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

        internal Manga(AContent a)
        {
            foreach (var prop in a.GetType().GetProperties())
            {
                this.GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(a, null), null);
            }
        }

        internal Manga(long id, string name, int? count, bool airing, List<string> genres,List<string> authors)
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
            this.authors = authors;
        }
    }
}
