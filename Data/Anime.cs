namespace AnimeList.Data
{
    internal class Anime : AContent
    {
        internal Anime(UnclassifiedContent a)
        {
            foreach (var prop in a.GetType().GetProperties())
            {
                GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(a, null), null);
            }
        }

        internal Anime(long id, List<string> names, int? episodes, bool notOut, 
                       List<string> genres, int? year,float? score)
        {
            IsAnime = true;
            ID = id;
            name = names.Last();
            if (episodes is not null)
            {
                this.count = (int)episodes;
            }
            this.notOut = notOut;
            this.genres = genres;
            started = year;
            if (names.Count > 1)
            {
                otherName = names.First();
            }
            else otherName = null;
            inProgress = false;
            this.Score = score;
        }

        internal override string Description()
        {
            string output = "";
            const string tab = "    ";
            if (otherName is not null)
            {
                output += $"({otherName})\n";
            }
            output += "Anime" + tab;
            if (notOut) output += "Currently Airing\n";
            else output += "Finished Airing\n";
            if (Score is not null) output += $"Score: {Score:F2}\n";
            if (started is not null)
            {
                if (count == 1) output += $"Aired: {started}\n";
                else output += $"Started airing: {started}\n";
            }
            if (count > 0) output += $"Episodes: {count}\n";
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
