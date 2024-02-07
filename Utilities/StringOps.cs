using AnimeList;
using JikanDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList
{
    internal class StringOps
    {
        internal static List<Anime> sortSearch(List<Anime> list, string query)
        {
            return list
            .OrderBy(s => distance(s.name, query) - 50 * relevanceByWords(s.name, query))
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
            return wordsInQuery.Sum(word => str.Split(' ').Count(s => s.Equals(word, StringComparison.OrdinalIgnoreCase)));
        }

        internal static string animeDesc(Anime anime)
        {
            string output = "";
            const string tab = "    ";
            output += $"Name: {anime.name}\n";
            if (anime.episodes > 0) output += $"Episodes: {anime.episodes}\n";
            if (anime.airing) output += "Currently Airing\n";
            else output += "Finished Airing\n";
            if (anime.genres.Count > 0)
            {
                output += "Genres:\n";
                foreach (string g in anime.genres)
                {
                    output += $"{tab}{g}\n";
                }
            }
            return output;
        }


        internal static string shorten(string name)
        {
            string output = "";
            for (int i = 0; i < 29; i++)
            {
                output += name[i];
            }
            return output + "...";
        }

        internal static string toFile(List<string> genres)
        {
            string output = "";
            for(int i = 0;i < genres.Count-1;i++)
            {
                output += genres[i] + ",";
            }
            output += genres.Last();
            return output;
        }
    }
}

