using AnimeList;
using JikanDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList
{
    internal class StringOps
    {
        
        private static int compare(string s, string t)
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

        internal static List<Anime> sortSearch(List<Anime> list,string query)
        {
            List<int> keys = new List<int>();
            List<Anime> close = new List<Anime>();
            foreach (Anime anime in list)
            {
                int i = compare(query, anime.name);
                keys.Add(i);
                if(i<6)
                {
                    close.Add(anime);
                }
            }
            List<Anime> output= new List<Anime>();
            if (close.Count > 0)
            {
                foreach(Anime a in close)
                {
                    output.Add(a);
                    list.Remove(a);
                }
            }
            foreach (Anime a in list)
            {
                output.Add(a);
            }
            return output;
        }


        internal static string animeDesc(Anime anime)
        {
            string output = "";
            output += $"Name: {anime.name}\n";
            if (anime.episodes > 0) output += $"Episodes: {anime.episodes}\n";
            if (anime.airing) output += "Currently Airing\n";
            else output += "Finished Airing";
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
    }
}

