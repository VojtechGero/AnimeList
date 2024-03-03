namespace AnimeList.Data
{
    internal class Anime : AContent
    {
        internal Anime(AContent a)
        {
            foreach (var prop in a.GetType().GetProperties())
            {
                GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(a, null), null);
            }
        }

        internal Anime(long id, List<string> names, int? episodes, bool notOut, 
                       List<string> genres, int? year)
        {
            IsAnime = true;
            ID = id;
            name = names.Last();
            if (episodes == null)
            {
                episodes = 1;
            }
            else count = (int)episodes;
            notOut = notOut;
            this.genres = genres;
            started = year;
            if (names.Count > 1)
            {
                otherName = names.First();
            }
            else otherName = null;
        }
    }
}
