namespace AnimeList
{
    internal class StringOps
    {
        internal static List<AContent> sortSearch(List<AContent> list, string query)
        {
            return list
            .OrderByDescending(s => 50 * relevanceByWords(s.name, query) - distance(s.name, query))
            .ToList();
        }

        private static int distance(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
            {
                if (string.IsNullOrEmpty(t))
                    return 0;
                return t.Length;
            }
            if (string.IsNullOrEmpty(t))
            {
                return s.Length;
            }
            s=s.ToLower();
            t=t.ToLower();
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];
            for (int i = 0; i <= n; d[i, 0] = i++) ;
            for (int j = 1; j <= m; d[0, j] = j++) ;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                    int min1 = d[i - 1, j] + 1;
                    int min2 = d[i, j - 1] + 1;
                    int min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }
            return d[n, m];
        }

        static int relevanceByWords(string str, string query)
        {
            str=str.ToLower();
            query=query.ToLower();
            string[] wordsInQuery = query.Split(' ');
            int count=0;
            foreach(string word in wordsInQuery)
            {
                if (str.Contains(word)) count++;
            }
            return count;
        }

        internal static string ContentDesc(AContent content)
        {
            string output = "";
            const string tab = "    ";
            output += $"Name: {content.name}\n";
            if (content.IsAnime)
            {
                output += "Anime" + tab;
                if (content.notOut) output += "Currently Airing\n";
                else output += "Finished Airing\n";
                if (content.count > 0) output += $"Episodes: {content.count}\n";
            }
            else
            {
                output += "Manga" + tab;
                if (content.notOut) output += "Currently Publishing\n";
                else output += "Finished Publishing\n";
                if (content.count > 0) output += $"Chapters: {content.count}\n";
                if(content.authors is not null)
                {
                    int c = content.authors.Count;
                    if (c > 0)
                    {
                        output += "Author:\n";
                        foreach (string author in content.authors)
                        {
                            output += $"{tab}{author}\n";
                        }
                    }
                }
            }
            if (content.genres is not null)
            {
                if(content.genres.Count > 0) output += "Genres:\n";
                foreach (string g in content.genres)
                {
                    output += $"{tab}{g}\n";
                }
            }
            return output;
        }

        internal static string formatName(string name)
        {
            if(name.Contains(", "))
            {
                string[] s = name.Split(", ");
                name = s[1]+" "+s[0];
            }
            return name;
        }

        internal static string shorten(string inputString,ListBox listBox1)
        {
            int listBoxWidth = listBox1.ClientSize.Width;
            Graphics g = listBox1.CreateGraphics();
            float maxLength = g.MeasureString(inputString, listBox1.Font).Width;
            if (maxLength > listBoxWidth)
            {
                float availableLength = listBoxWidth;
                string shortenedString = "";
                foreach(char c in inputString)
                {
                    string temp = shortenedString + c;
                    if (g.MeasureString(temp, listBox1.Font).Width > availableLength) break;
                    shortenedString += c;
                }
                return shortenedString.Trim()+"...";
            }
            else
            {
                return inputString;
            }
        }

        internal static string getFileName(string filePath)
        {
            string[] strings = filePath.Split("\\");
            return strings.Last();
        }
    }
}

