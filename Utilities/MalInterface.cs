using JikanDotNet.Exceptions;
using JikanDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Utills
{
    internal class MalInterface
    {
       private static string getTitle(ICollection<TitleEntry> entries)
        {
            if(entries.Count > 1)
            {
                string def = "";
                foreach(TitleEntry entry in entries)
                {
                    if(entry.Type=="English") return entry.Title;
                    if (entry.Type == "Default") def = entry.Title;
                }
                return def;
            }else return entries.First().Title;
        }
        internal async static void pullAnimeId(long id, AddForm add)
        {
            try
            {
                IJikan jikan = new Jikan();
                var anime = await jikan.GetAnimeAsync(id);
                add.handleAnime(new Anime(
                    id: (long)anime.Data.MalId,
                    name: getTitle(anime.Data.Titles),
                    episodes: (int)anime.Data.Episodes,
                    airing: anime.Data.Airing));
            }
            catch(Exception ex)
            {
                add.idExceptionHandle();
            }
        }
    }
}
