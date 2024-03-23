namespace AnimeList.Data
{
    internal class Manga : AContent
    {

        internal Manga(AContent a)
        {
            foreach (var prop in a.GetType().GetProperties())
            {
                GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(a, null), null);
            }
        }

        internal Manga(long id, List<string> names, int? count, bool notOut, 
                       List<string> genres, List<string> authors, int? year)
        {
            IsAnime = false;
            ID = id;
            name = names.Last();
            if (count is not null)
            {
                this.count = (int)count;
            }
            this.notOut = notOut;
            this.genres = genres;
            if (authors.Count > 3)
            {
                List<string> a = new List<string>();
                for (int i = 0; i < 3; i++)
                {
                    a.Add(authors[i]);
                }
                this.authors = a;
            }
            else this.authors = authors;
            started = year;
            if (names.Count > 1)
            {
                otherName = names.First();
            }
            else otherName = null;
        }
    }
}
