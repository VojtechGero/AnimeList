namespace AnimeList.Data
{
    internal class Manga : AContent
    {

        internal Manga(UnclassifiedContent a)
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
            inProgress = false;
        }

        internal override string Description()
        {
            string output = "";
            const string tab = "    ";
            if (otherName is not null)
            {
                output += $"({otherName})\n";
            }
            output += "Manga" + tab;
            if (notOut) output += "Currently Publishing\n";
            else output += "Finished Publishing\n";
            if (started is not null)
            {
                output += $"Started publishing: {started}\n";
            }
            if (count > 0) output += $"Chapters: {count}\n";
            if (authors is not null)
            {
                int c = authors.Count;
                if (c > 0)
                {
                    output += "Author:\n";
                    foreach (string author in authors)
                    {
                        output += $"{tab}{author}\n";
                    }
                }
            }
            if (genres is not null)
            {
                if (genres.Count > 0) output += "Genres:\n";
                foreach (string g in genres)
                {
                    output += $"{tab}{g}\n";
                }
            }
            return output;
        }
    }
}
