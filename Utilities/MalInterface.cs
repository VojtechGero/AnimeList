using JikanDotNet.Exceptions;
using JikanDotNet.Config;
using JikanDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList
{
    internal class MalInterface
    {
        IJikan jikan;
        internal MalInterface()
        {
            JikanClientConfiguration config = new JikanClientConfiguration()
            {
                LimiterConfigurations = TaskLimiterConfiguration.None
            };
            jikan = new Jikan(config);
        }

        private string getTitle(ICollection<TitleEntry> entries)
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

        internal async Task<Anime> pullAnimeId(long id)
        {
            try
            {
                var res = await jikan.GetAnimeAsync(id);
                Anime? anime =new Anime(
                    id: (long)res.Data.MalId,
                    name: getTitle(res.Data.Titles),
                    episodes: res.Data.Episodes,
                    airing: res.Data.Airing);
                return anime;
            }
            catch (JikanRequestException)
            {
                return null;
            }
            catch (JikanValidationException)
            {
                return null;
            }
        }

        internal async Task<List<Anime>> searchAnime(string query)
        {
            try
            {
                var animes = await jikan.SearchAnimeAsync(query);
                List<Anime> animeList = new List<Anime>();
                int i = 0;
                foreach (var item in animes.Data)
                {
                    if (i > 4) break;
                    i++;
                    Anime a = new Anime(
                        id: (long)item.MalId,
                        name: getTitle(item.Titles),
                        episodes: item.Episodes,
                        airing: item.Airing
                        );
                    animeList.Add(a);
                }
                animeList= StringOps.sortSearch(animeList,query);
                return animeList;
            }
            catch (JikanRequestException)
            {
                return await searchAnime(query);
            }
        }
    }
}
