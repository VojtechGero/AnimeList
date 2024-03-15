using AnimeList.Data;

namespace AnimeList.Utilities
{
    internal class StringOps
    {

        private static readonly string[] AnimeSet = ["anime", "airing", "aired", "episodes"];
        private static readonly string[] MangaSet = ["manga", "publishing", "published", "chapters"];
        internal static List<Content> sortSearch(List<Content> list, string query)
        {
            return list
            .OrderByDescending(s => relevance(s,query))
            .ToList();
        }

        private static int relevance(Content content, string query)
        {
            string name;
            if (content.otherName is null)
            {
                name = content.name;
            }
            else
            {
                if (value(content.name, query) > value(content.otherName, query))
                {
                    name = content.name;
                }else name= content.otherName;
            }
            return value(name,query);
        }

        private static int value(string name, string query)
        {
            return 50 * relevanceByWords(name, query) - distance(name, query);
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

        internal static string ContentDesc(Content content)
        {
            string output = "";
            const string tab = "    ";
            string[] set;
            if (content.IsAnime) set = AnimeSet;
            else set = MangaSet;
            if(content.otherName is not null)
            {
                output += $"({content.otherName})\n";
            }
            output += set[0] + tab;
            if (content.notOut) output += $"Currently {set[1]}\n";
            else output += $"Finished {set[1]}\n";
            if (content.started is not null)
            {
                string t;
                if (content.count == 1) t = set[2];
                else t = $"Started {set[1]}";
                output += $"{t}: {content.started}\n";
            }
            if (content.count > 0) output += $"{set[3]}: {content.count}\n";
            if (content.authors is not null)
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

