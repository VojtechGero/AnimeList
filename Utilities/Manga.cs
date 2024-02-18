﻿namespace AnimeList
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

        internal Manga(long id, List<string> names, int? count, bool airing, List<string> genres,List<string> authors, int? year)
        {
            IsAnime = false;
            ID = id;
            this.name = names.Last();
            if (count == null)
            {
                count = 1;
            }
            else this.count = (int)count;
            this.notOut = airing;
            this.genres = genres;
            if(authors.Count > 3)
            {
                List<string> a=new List<string>();
                for(int i=0; i<3; i++)
                {
                    a.Add(authors[i]);
                }
                this.authors = a;
            }else this.authors = authors;
            this.started = year;
            if (names.Count > 1)
            {
                this.otherName = names.First();
            }
            else this.otherName = null;
        }
    }
}
