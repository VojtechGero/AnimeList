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

        internal Anime(long id, List<string> names, int? episodes, bool airing, List<string> genres,int? year)
        {
            IsAnime=true;
            ID = id;
            this.name = names.Last();
            if (episodes == null)
            {
                episodes = 1;
            }
            else this.count = (int)episodes;
            this.notOut = airing;
            this.genres = genres;
            this.started = year;
            if (names.Count > 1)
            {
                this.otherName = names.First();
            }
            else this.otherName = null;
        }
    }
}
