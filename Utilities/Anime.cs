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

        internal Anime(long id, string name, int? episodes, bool airing, List<string> genres,int? year)
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
            this.started = year;
        }
    }
}
